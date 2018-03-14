Imports System.Linq

Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions


Public Class frmClientesPagoNuevo

    Public montos As New ArrayList
    Public tiposPagos As New ArrayList
    Public anula As Boolean = False
    Public anularPago As Boolean = False
    Public modifica As Boolean = False
    Public codigoPagoDetalle As Integer = 0

    'Variables de estado
    Public bitSalida As Boolean = False
    Public bitEntrada As Boolean = False
    Public bitCliente As Boolean = False
    Public bitProveedor As Boolean = False
    Public codigoES As Integer = 0
    Public codigoCP As Integer = 0

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        If e.Column.Name = "TipoPago" Then
            fnTipoPago()
        ElseIf e.Column.Name = "Monto" Then
            'Agregar una fila
            Dim filas() As String
            filas = {0, 0, "", 0}
            grdProductos.Rows.Add(filas)
            grdProductos.Columns(2).IsCurrent = True
            grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        End If
    End Sub

    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos.Columns("TipoPago").IsCurrent Then
            fnTipoPago()
        End If
    End Sub

    Public Sub fnTipoPago()
        Try
            Dim consulta = (From x In ctx.tblTipoPagoes Select codigo = x.codigo, nombre = x.nombre)

            Dim mov As New DataTable
            mov.Columns.Add("Codigo")
            mov.Columns.Add("Nombre")

            mov.Rows.Add(0, "Ninguno")

            Dim v
            For Each v In consulta
                mov.Rows.Add(CType(v.codigo, Integer), v.nombre)
            Next


            frmCombo.combo.DataSource = mov
            frmCombo.combo.ValueMember = "codigo"
            frmCombo.combo.DisplayMember = "nombre"
            frmCombo.Text = "Tipo Pago"
            frmCombo.ShowDialog()

            If mdlPublicVars.superSearchId > 0 Then
                'agregar datos.
                'agregar productos a grid.

                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    'modificar
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(0).Value = mdlPublicVars.superSearchId
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(1).Value = mdlPublicVars.superSearchNombre

                    Dim tipo As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = mdlPublicVars.superSearchId Select x).FirstOrDefault

                    If tipo.transito = True Then
                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(5).ReadOnly = False
                    Else
                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(5).ReadOnly = True
                    End If
                Else

                    'crear
                    Dim filas() As String
                    'id, codigo,nombre,precio,cantidad
                    filas = {mdlPublicVars.superSearchId, mdlPublicVars.superSearchNombre, "?", "", 0}
                    grdProductos.Rows.Add(filas)
                    Dim tipo As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = mdlPublicVars.superSearchId Select x).FirstOrDefault

                    If tipo.transito = True Then
                        Me.grdProductos.Rows(Me.grdProductos.Rows.Count - 1).Cells(5).ReadOnly = False
                    Else
                        Me.grdProductos.Rows(Me.grdProductos.Rows.Count - 1).Cells(5).ReadOnly = False
                    End If

                    grdProductos.Columns(2).IsCurrent = True
                    grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                End If




                fnTotal()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmClientesPagoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
        fnLlenar()
        lblTotal.Text = "0"
        lblSaldoActual.Text = "0"
        mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Monto")
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        mdlPublicVars.fnGrid_iconos(grdProductos)

    End Sub

    Private Sub fnLlenar()
        Me.grdProductos.Rows.Clear()
        Me.grdProductos.AllowAddNewRow = True
        dtpFechaInicio.Text = mdlPublicVars.fnFecha_horaServidor
        Dim consulta = Nothing

        If bitProveedor = True Then
            consulta = From x In ctx.tblProveedors _
                      Select codigo = x.idProveedor, nombre = x.negocio
        ElseIf bitCliente = True Then
            consulta = From x In ctx.tblClientes _
                       Select codigo = x.idCliente, nombre = x.Negocio
        End If
        
        If bitProveedor = True Or bitCliente = True Then
            With cmbCliente
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = consulta
            End With
        Else
            cmbCliente.Enabled = False
        End If

        If bitProveedor = True And codigoCP > 0 Then
            cmbCliente.SelectedValue = codigoCP
            cmbCliente.Enabled = False
        End If

        mdlPublicVars.comboActivarFiltro(cmbCliente)
    End Sub

    Private Sub fnTotal()

        Dim index
        Dim total As Double = 0
        Dim saldo As Double = 0
        Dim saldoActual As Double = 0

        For index = 0 To Me.grdProductos.Rows.Count - 1
            If IsNumeric(Me.grdProductos.Rows(index).Cells("Monto").Value) Then
                total = total + CType(Me.grdProductos.Rows(index).Cells("Monto").Value, Double)
            End If
        Next

        If IsNumeric(lblSaldo.Text) Then
            saldo = lblSaldo.Text
        Else
            saldo = 0
        End If

        saldoActual = saldo - total


        'Mostrar resultados.
        If total > 0 Then
            lblTotal.Text = Format(total, mdlPublicVars.formatoMoneda)
        Else
            lblTotal.Text = 0
        End If

        If saldoActual <> 0 Then
            lblSaldoActual.Text = Format(saldoActual, mdlPublicVars.formatoMoneda)
        Else
            lblSaldoActual.Text = "0"
        End If

    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        If e.Column.Name = "Monto" Then
            fnTotal()
            'agregar fila
            Dim filas() As String

            'Verificamos si es necesario ingresar una fecha
            Dim idTipoPago As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(0).Value, Integer)

            If idTipoPago = Nothing Then
                MsgBox("Elija un tipo de pago", , "Informacion")
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                Me.grdProductos.Columns(1).IsCurrent = True
            Else

                Dim tipoPago As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = idTipoPago Select x).First
                Dim fecha = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(5).Value
                Dim monto = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(4).Value

                If monto Is Nothing Or monto = 0 Then
                    MsgBox("Debe ingresar una monto", , "Informacion")
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                    Me.grdProductos.Columns("Monto").IsCurrent = True
                Else
                    If tipoPago.calendarizada = True And fecha = Nothing Then
                        MsgBox("Debe ingresar una fecha", , "Informacion")
                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                        Me.grdProductos.Columns("Fecha").IsCurrent = True
                    Else
                        'id, codigo,nombre,precio,cantidad
                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(5).ReadOnly = True
                        filas = {0, 0, "?", "", 0}
                        grdProductos.Rows.Add(filas)
                        grdProductos.Columns(2).IsCurrent = True
                        grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                        If Me.grdProductos.Rows.Count > 1 Then
                            Me.grdProductos.AllowAddNewRow = False
                        End If

                    End If
                End If
            End If



        ElseIf e.Column.Name = "Fecha" Then
            'id, codigo,nombre,precio,cantidad
            Dim fecha = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(5).Value
            If fecha = Nothing Then

            Else
                Dim filas As String()
                filas = {0, 0, "?", "", 0}
                grdProductos.Rows.Add(filas)
                grdProductos.Columns(2).IsCurrent = True
                grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
            End If

        End If
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If e.KeyValue = Keys.F2 Then
            fnTipoPago()
        ElseIf e.KeyValue = Keys.Delete Then
            fnTotal()
        End If
    End Sub

    Private Function fnErrores() As Boolean
        Dim errores As Boolean = False
        Dim contenidoer As String = ""


        If Me.grdProductos.Rows.Count > 0 Then
        Else
            contenidoer = "Ingrese un pago"
            errores = True
        End If

        Dim index
        For index = 0 To Me.grdProductos.Rows.Count - 1
            'si la columna 0 de codigo
            Dim tipoPago As String = CType(Me.grdProductos.Rows(index).Cells(1).Value, String)

            If tipoPago <> "0" Then

                If Me.grdProductos.Rows(index).Cells(0).Value.ToString.Length > 0 Then

                    If IsNumeric(Me.grdProductos.Rows(index).Cells(4).Value) Then
                    Else
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells(4).Value + " " + vbCrLf
                    End If

                    If Me.grdProductos.Rows(index).Cells(4).Value = 0 Then
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells(3).Value + " " + vbCrLf
                    End If


                End If


            End If

        Next

        Dim total = CType(Me.lblTotal.Text, Double)
        If bitSalida = True Then
            If total > CType(lblSaldo.Text, Double) Then
                errores = True
                contenidoer = "Monto pagado es mayor al de entrada"
            End If
        End If

        If total <= 0 And bitSalida = True Then
            errores = True
            contenidoer = "Debe ingresar un pago"
        End If

        If errores = True Then
            alerta.contenido = contenidoer
            alerta.fnErrorContenido()
        End If

        Return errores
    End Function

    Private Sub pbGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbGuardar.Click

        If fnErrores() = True Then
            Exit Sub
        End If

        Dim codcliente As Integer = cmbCliente.SelectedValue
        Dim documento As String = ""
        Dim monto As Double = 0

        Dim tipoPago As Integer = 0

        Dim totalEfectivo As Double = 0
        Dim totalTransito As Double = 0

        Dim fecha As DateTime = fnFecha_horaServidor()

        Dim success As Boolean = True
        Dim errContenido As String = ""

        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try

                'paso 1, guardar el encabezado del pago

                Dim index As Integer
                For index = 0 To Me.grdProductos.Rows.Count - 1
                    tipoPago = CType(Me.grdProductos.Rows(index).Cells("codigoTipoPago").Value, Integer)
                    If tipoPago = 0 Then

                    Else
                        'obtener datos del grid
                        documento = Me.grdProductos.Rows(index).Cells(3).Value
                        monto = Me.grdProductos.Rows(index).Cells(4).Value
                        tipoPago = Me.grdProductos.Rows(index).Cells(0).Value


                        'Creamos el registro
                        Dim pago As New tblCaja
                        pago.documento = documento
                        pago.anulado = 0
                        pago.fecha = dtpFechaInicio.Text
                        pago.fechaTransaccion = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                        pago.monto = monto
                        pago.tipoPago = tipoPago
                        pago.empresa = mdlPublicVars.idEmpresa
                        pago.usuario = mdlPublicVars.idUsuario

                        If bitCliente = True Then
                            pago.cliente = codcliente
                        ElseIf bitProveedor = True Then
                            pago.proveedor = codcliente
                        ElseIf bitEntrada = True Then
                            pago.codigoEntrada = codigoES
                        ElseIf bitSalida = True Then
                            pago.codigoSalida = codigoES
                        End If

                        'Obtenemos el tipo de Pago
                        Dim pagoTipo As tblTipoPago = (From x In ctx.tblTipoPagoes.AsEnumerable Where x.codigo = tipoPago Select x).FirstOrDefault
                        If pagoTipo.transito = True Then
                            pago.transito = 1
                            pago.confirmado = 0
                            Dim f = Me.grdProductos.Rows(index).Cells("Fecha").Value
                            Dim fechaConfirma As DateTime = CType(f + " 00:00:00", DateTime)
                            pago.fechaCobro = fechaConfirma
                        Else
                            pago.confirmado = 1
                        End If

                        ctx.AddTotblCajas(pago)
                        ctx.SaveChanges()
                        'Decidimos que hacer dependiendo del tipo pago

                        'Si el pago es de una entrada (FACTURA)


                        If bitEntrada = True Then
                            Dim factura As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigoES Select x).FirstOrDefault

                            If pagoTipo.transito = True Then
                                
                            Else
                                If factura.contado = True Then
                                    'Realizamos las transacciones correspondientes
                                    factura.saldo -= pago.monto
                                    If factura.saldo = 0 Then
                                        factura.pagado = 1
                                    End If
                                Else
                                    Dim montoPagar = pago.monto

                                    Dim listaSalidas As List(Of tblSalida) = (From x In ctx.tblSalidas Where x.IdFactura = factura.IdFactura Select x).ToList
                                    Dim salida As tblSalida

                                    For Each salida In listaSalidas
                                        Dim ctaCobrar As tblCtaCobrar = (From x In ctx.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                        If montoPagar > ctaCobrar.saldo Then
                                            montoPagar -= ctaCobrar.saldo
                                            ctaCobrar.saldo = 0
                                            ctaCobrar.cancelada = 1
                                        Else
                                            ctaCobrar.saldo -= montoPagar
                                            montoPagar = 0
                                        End If
                                    Next

                                End If
                            End If

                        ElseIf bitSalida = True Then
                            Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = codigoES Select x).FirstOrDefault
                            If pagoTipo.transito = True Then

                            Else
                                If entrada.contado = True Then
                                    'Realizamos las transacciones correspondientes
                                    entrada.saldo -= pago.monto
                                    entrada.pagos += pago.monto
                                    If entrada.saldo = 0 Then
                                        entrada.cancelado = 1
                                    End If
                                    'Else
                                    '    Dim montoPagar = pago.monto

                                    '    Dim ctaPagar As tblCtaPagar = (From x In ctx.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                                    '    If montoPagar > ctaPagar.saldo Then
                                    '        montoPagar -= ctaPagar.saldo
                                    '        ctaPagar.saldo = 0
                                    '        ctaPagar.cancelada = 1
                                    '    Else
                                    '        ctaPagar.saldo -= montoPagar
                                    '        montoPagar = 0
                                    '    End If
                                End If
                            End If
                        ElseIf bitCliente = True Then
                            Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In ctx.tblCtaCobrars Where x.idCliente = pago.cliente And x.cancelada = False Select x Order By x.fecha Ascending).ToList
                            Dim ctaCobrar As tblCtaCobrar

                            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                            If pagoTipo.transito = True Then
                                cliente.pagosTransito += pago.monto
                            Else

                                Dim montoPagar = pago.monto

                                cliente.pagos += pago.monto
                                cliente.saldo -= pago.monto

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
                        ElseIf bitProveedor = True Then
                            Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                            If pagoTipo.transito = True Then
                                proveedor.pagosTransito += pago.monto

                            Else
                                Dim montoPagar = pago.monto

                                proveedor.pagos += pago.monto
                                proveedor.saldoActual -= pago.monto
                                Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                Dim ctaPagar As tblCtaPagar

                                For Each ctaPagar In listaCtaPagar

                                    If montoPagar > ctaPagar.saldo Then
                                        montoPagar -= ctaPagar.saldo
                                        ctaPagar.pagado = ctaPagar.monto
                                        ctaPagar.saldo = 0
                                        ctaPagar.cancelada = 1
                                    Else
                                        ctaPagar.saldo -= montoPagar
                                        ctaPagar.pagado += montoPagar
                                        montoPagar = 0
                                    End If

                                Next
                            End If
                        End If
                    End If
                Next
                'generar un recibo de caja de pago, con el detalle de pago.

                ctx.SaveChanges()
                'paso 8, completar la transaccion.
                transaction.Complete()


            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
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
            fnLlenar()
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    Private Sub cmbCliente_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        Try
            Dim codigo As Integer = CType(cmbCliente.SelectedValue, Integer)
            Dim saldoCP As Double
            If bitCliente = True Then
                Dim c As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault
                saldoCP = c.saldo
            ElseIf bitProveedor = True Then
                Dim c As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault
                saldoCP = c.saldoActual
            End If

            If saldoCP > 0 Then
                lblSaldo.Text = Format(saldoCP, mdlPublicVars.formatoMoneda)
            Else
                lblSaldo.Text = "0"
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub pbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNuevo.Click, lblNuevo.Click
        fnLlenar()
    End Sub

End Class
