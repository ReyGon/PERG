Imports System.Linq
Imports System.IO
Imports System.Transactions
Imports Telerik.WinControls

Public Class frmClienteBoleta

    Dim codigo As Integer

    Dim _cliente As Integer

    Public Property cliente() As Integer
        Get
            cliente = _cliente
        End Get
        Set(ByVal value As Integer)
            _cliente = value
        End Set
    End Property



    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub panelGuardar() Handles Me.panel0
        If RadMessageBox.Show("Guardar Cambios", "Informacion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            fnGuardar()
        End If
    End Sub

    Private Sub frmClienteBoleta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim consulta = (From x In ctx.tblClientes Select Codigo = x.idCliente, Nombre = x.Negocio)

        With Me.cmbCliente
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = consulta
        End With


        mdlPublicVars.comboActivarFiltro(cmbCliente)

        If cliente > 0 Then
            cmbCliente.SelectedValue = cliente
        End If

        lblEstado.Text = ""
        lblFecha.Text = ""
        lblMonto.Text = "0"
        codigo = 0

    End Sub


    Private Sub btnDetallePendienteSurtir_Click(sender As System.Object, e As System.EventArgs) Handles btnDetallePendienteSurtir.Click
        fnValidar()
    End Sub

    Private Sub fnValidar()
        Try

            Dim caja As tblCaja = (From x In ctx.tblCajas
                                   Where x.documento = txtBoleta.Text And x.cliente Is Nothing And x.proveedor Is Nothing And x.codigoEntrada Is Nothing And x.codigoSalida Is Nothing
                                   Select x).FirstOrDefault

            If caja IsNot Nothing Then

                lblEstado.Text = "Boleta si existe"
                codigo = caja.codigo
                lblMonto.Text = Format(caja.monto, mdlPublicVars.formatoMoneda)
                lblFecha.Text = caja.fecha

                If caja.cliente IsNot Nothing Then
                    lblNegocio.Text = caja.tblCliente.Negocio
                Else
                    lblNegocio.Text = "No asociado"
                End If

            Else
                lblEstado.Text = ""
                codigo = 0
                lblFecha.Text = ""
                lblMonto.Text = ""
                lblNegocio.Text = ""
            End If

        Catch ex As Exception
            alerta.fnError()
        End Try
    End Sub
    Private Sub fnGuardar()

        'codigo mayor a cero
        If codigo = 0 Then
            alerta.contenido = "No existe boleta"
            alerta.fnErrorContenido()
            Exit Sub
        End If


        'fecha y hora del servidor.
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()

        'variables de transaccion.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim observacion As String = ""


        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                Dim caja As tblCaja = (From x In ctx.tblCajas Where x.codigo = codigo Select x).FirstOrDefault
                caja.fechaCobro = fecha
                caja.cliente = cmbCliente.SelectedValue
                caja.confirmado = True

                ctx.SaveChanges()


                Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In ctx.tblCtaCobrars Where x.idCliente = caja.cliente And x.cancelada = False Select x Order By x.fecha Ascending).ToList

                Dim ctaCobrar As tblCtaCobrar

                Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = caja.cliente Select x).FirstOrDefault


                If caja.tblTipoPago.calendarizada = True Then
                    ' no confirmar solo descontar de saldo.
                    cliente.pagosTransito += caja.monto


                    Dim montoPagar = caja.monto

                    cliente.pagos += caja.monto
                    cliente.saldo -= caja.monto

                    For Each ctaCobrar In listasCtaCobrar

                        If montoPagar > ctaCobrar.saldo Then
                            montoPagar -= ctaCobrar.saldo
                            ctaCobrar.pagado += ctaCobrar.saldo
                            ctaCobrar.saldo = 0
                            ctaCobrar.cancelada = 1
                        Else
                            ctaCobrar.saldo -= montoPagar
                            ctaCobrar.pagado += montoPagar
                            montoPagar = 0
                        End If
                    Next

                    'SISTEMA BANCOS
                    If caja.cuenta > 0 Then
                        Dim numeroCorrelativo As Integer = 0

                        'CORRELATIVO
                        Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                             Select x).FirstOrDefault

                        correlativo.correlativo += 1
                        numeroCorrelativo = correlativo.correlativo
                        ctx.SaveChanges()

                        'Obtenemos el acreditador
                        Dim acreditador As tblBanco_Beneficiario = (From x In ctx.tblBanco_Beneficiario Where x.bitCredito And x.nombre.Equals(caja.tblCliente.Negocio)
                                                                    Select x).FirstOrDefault
                        Dim idAcreditador As Integer = 0
                        Dim nombreAcreditador As String = ""

                        If acreditador IsNot Nothing Then
                            idAcreditador = acreditador.codigo
                            nombreAcreditador = acreditador.nombre
                        Else
                            'Creamos el acreditador
                            Dim nuevoAcreditador As New tblBanco_Beneficiario
                            nuevoAcreditador.bitCredito = True
                            nuevoAcreditador.bitDebitoCheque = False
                            nuevoAcreditador.nombre = caja.tblCliente.Negocio

                            ctx.AddTotblBanco_Beneficiario(nuevoAcreditador)
                            ctx.SaveChanges()

                            idAcreditador = nuevoAcreditador.codigo
                            nombreAcreditador = nuevoAcreditador.nombre
                        End If

                        'Creamos el encabezado de la acreditacion
                        Dim movimiento As New tblBanco_Creditos
                        movimiento.bitAnulado = False
                        movimiento.correlativo = numeroCorrelativo
                        movimiento.documento = caja.documento
                        movimiento.fechaRegistro = caja.fecha
                        movimiento.total = caja.monto
                        movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                        movimiento.bitConfirmado = True
                        movimiento.usuarioConfirma = mdlPublicVars.idUsuario
                        movimiento.fechaConfirmado = fecha
                        movimiento.cuenta = CInt(caja.cuenta)
                        ctx.AddTotblBanco_Creditos(movimiento)
                        ctx.SaveChanges()

                        'Verificamos si existe el concepto
                        Dim concepto As tblBanco_MovimientoConcepto = (From x In ctx.tblBanco_MovimientoConcepto Where x.nombre.Equals(caja.tblTipoPago.nombre) Select x).FirstOrDefault
                        Dim idConcepto As Integer = 0

                        If concepto IsNot Nothing Then
                            idConcepto = concepto.codigo
                        Else
                            Dim nuevoConcepto As New tblBanco_MovimientoConcepto
                            nuevoConcepto.nombre = caja.tblTipoPago.nombre
                            nuevoConcepto.bitCredito = True
                            nuevoConcepto.bitCheque = False
                            nuevoConcepto.bitDebito = False

                            ctx.AddTotblBanco_MovimientoConcepto(nuevoConcepto)
                            ctx.SaveChanges()

                            idConcepto = nuevoConcepto.codigo
                        End If

                        'Creamos el detalle de la acreditacion
                        Dim detalle As New tblBanco_CreditosDetalle
                        detalle.credito = movimiento.codigo
                        detalle.acreditador = idAcreditador
                        detalle.concepto = idConcepto
                        detalle.descripcion = caja.tblCliente.Negocio & " - " & caja.tblTipoPago.nombre & " - "
                        detalle.monto = movimiento.total
                        detalle.nombre = nombreAcreditador
                        ctx.AddTotblBanco_CreditosDetalle(detalle)
                        ctx.SaveChanges()

                        'Aumentamos el saldo de la cuenta a la que se confirmo el cierre
                        Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = movimiento.cuenta
                                                         Select x).FirstOrDefault

                        If cuenta.saldo Is Nothing Then
                            cuenta.saldo = caja.monto
                        Else
                            cuenta.saldo += caja.monto
                        End If

                        If cuenta.saldoTransito Is Nothing Then
                            cuenta.saldoTransito = 0
                        End If

                        ctx.SaveChanges()

                    Else


                        'el tipo de pago ya esta confirmado de una vez afecta el estado de cuenta del cliente.
                        montoPagar = caja.monto

                        cliente.pagos += caja.monto
                        cliente.saldo -= caja.monto

                        For Each ctaCobrar In listasCtaCobrar

                            If montoPagar > ctaCobrar.saldo Then
                                montoPagar -= ctaCobrar.saldo
                                ctaCobrar.pagado += ctaCobrar.saldo
                                ctaCobrar.saldo = 0
                                ctaCobrar.cancelada = 1
                            Else
                                ctaCobrar.saldo -= montoPagar
                                ctaCobrar.pagado += montoPagar
                                montoPagar = 0
                            End If
                        Next
                    End If
                End If

                ctx.SaveChanges()
                'paso 8, completar la transaccion.
                transaction.Complete()

            Catch ex As System.Data.EntityException
                success = False

            Catch ex As Exception
                success = False
                RadMessageBox.Show(ex.Message + vbCrLf + ex.InnerException.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using



        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
            txtBoleta.Text = ""
            lblEstado.Text = ""
            lblMonto.Text = "0"
            lblFecha.Text = ""
        End If



    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbCliente.SelectedValueChanged

        Try
            Dim codigo As Integer = cmbCliente.SelectedValue

            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault
            lblClave.Text = cliente.clave

        Catch ex As Exception
            lblClave.Text = ""
        End Try

    End Sub

    Private Sub txtBoleta_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBoleta.KeyDown
        If e.KeyValue = Keys.Enter Then
            fnValidar()
        End If
    End Sub
End Class
