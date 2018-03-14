Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmCierreCajaConfirma

#Region "Variables"
    Private _codigo As Integer

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

#End Region
    Private Sub frmCierreCajaConfirma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarCombo()
    End Sub

    'Funcion utilizada para llenar el combo de cuentas
    Private Sub fnLlenarCombo()
        Dim cuenta = (From x In ctx.tblBanco_Cuenta Select x.codigo, nombre = x.numeroCuenta & "( " & x.tblBanco.nombre & " )")

        With cmbCuenta
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = cuenta
        End With
    End Sub

    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        If RadMessageBox.Show("¿Dese confirmar el cierre?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnConfirmarCierre()
        End If
    End Sub

    'Funcion utilizada para confirmar un cierre de caja
    Private Sub fnConfirmarCierre()
        Dim success As Boolean = True
        If cmbCuenta.DataSource IsNot Nothing Then
            Using transaction As New TransactionScope
                Try
                    Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim vendedor As String = ""
                    'Obtenemos el registro del cierre de caja
                    Dim cierre As tblCierreCaja = (From x In ctx.tblCierreCajas Where x.codigo = codigo Select x).FirstOrDefault

                    cierre.documentoBoleta = txtBoleta.Text
                    cierre.cuenta = CInt(cmbCuenta.SelectedValue)
                    cierre.fechaConfirmado = fechaServer
                    cierre.usuarioConfirmado = mdlPublicVars.idUsuario
                    cierre.bitConfirmado = True
                    ctx.SaveChanges()

                    vendedor = cierre.tblUsuario2.tblVendedor.nombre
                    alerta.fnGuardar()

                    'Se confirman los saldos del cliente4
                    Dim lPagos As List(Of tblCaja) = (From x In ctx.tblCierreCajaDetalleCajas Where x.idCierreCaja = cierre.codigo And x.bitCheque Select x.tblCaja).ToList
                    Dim totalUsuario As Decimal = cierre.tblCierreCajaDetalles.Select(Function(y) y.total).Sum
                    Dim totalCheques As Decimal = 0

                    For Each pago As tblCaja In lPagos
                        If Not pago.confirmado Then
                            pago.confirmado = True
                            pago.fechaCobro = fechaServer
                            If pago.transito Then
                                pago.transito = False
                            End If

                            ctx.SaveChanges()
                            'Obtenemos el cliente
                            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                            cliente.pagosTransito -= pago.monto
                            totalCheques += pago.monto
                            cliente.pagos += pago.monto
                            cliente.saldo -= pago.monto
                            ctx.SaveChanges()
                        End If
                    Next

                    ' ACREDITACION, SISTEMA DE BANCOS
                    Dim numeroCorrelativo As Integer = 0
                    
                    'CORRELATIVO
                    Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                         Select x).FirstOrDefault

                    correlativo.correlativo += 1
                    numeroCorrelativo = correlativo.correlativo
                    ctx.SaveChanges()

                    'Obtenemos el acreditador
                    Dim acreditador As tblBanco_Beneficiario = (From x In ctx.tblBanco_Beneficiario Where x.bitCredito And x.nombre.Equals(vendedor)
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
                        nuevoAcreditador.nombre = vendedor

                        ctx.AddTotblBanco_Beneficiario(nuevoAcreditador)
                        ctx.SaveChanges()

                        idAcreditador = nuevoAcreditador.codigo
                        nombreAcreditador = nuevoAcreditador.nombre
                    End If

                    'Creamos el encabezado de la acreditacion
                    Dim movimiento As New tblBanco_Creditos
                    movimiento.bitAnulado = False
                    movimiento.correlativo = numeroCorrelativo
                    movimiento.documento = txtBoleta.Text
                    movimiento.fechaRegistro = cierre.fechaConfirmado
                    movimiento.total = totalUsuario + If(cierre.bitAjuste, cierre.montoAjuste, 0) + totalCheques
                    movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                    movimiento.bitConfirmado = True
                    movimiento.fechaConfirmado = fechaServer
                    movimiento.usuarioConfirma = mdlPublicVars.idUsuario
                    movimiento.cuenta = CInt(cmbCuenta.SelectedValue)
                    ctx.AddTotblBanco_Creditos(movimiento)
                    ctx.SaveChanges()

                    'Creamos el detalle de la acreditacion
                    Dim detalle As New tblBanco_CreditosDetalle
                    detalle.credito = movimiento.codigo
                    detalle.acreditador = idAcreditador
                    detalle.concepto = Banco_CierreCaja
                    detalle.descripcion = "Cierre de Caja, del " & cierre.desde.Value.ToShortDateString & " hasta " & cierre.hasta.Value.ToShortDateString
                    detalle.monto = movimiento.total
                    detalle.nombre = nombreAcreditador
                    ctx.AddTotblBanco_CreditosDetalle(detalle)
                    ctx.SaveChanges()

                    'Aumentamos el saldo de la cuenta a la que se confirmo el cierre
                    Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = cierre.cuenta
                                                     Select x).FirstOrDefault

                    If cuenta.saldo Is Nothing Then
                        cuenta.saldo = totalUsuario + cierre.montoAjuste + totalCheques
                    Else
                        cuenta.saldo += totalUsuario + cierre.montoAjuste + totalCheques
                    End If

                    If cuenta.saldoTransito Is Nothing Then
                        cuenta.saldoTransito = 0
                    End If

                    ctx.SaveChanges()

                    transaction.Complete()
                Catch ex As Exception
                    success = False
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End Try
            End Using
        Else
            RadMessageBox.Show("No tiene cuentas bancarias", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

        If success Then
            Me.Close()
            frmCierreCajaLista.frm_llenarLista()
            alerta.fnGuardar()
        End If
        
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
