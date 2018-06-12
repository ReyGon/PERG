''Option Strict On

Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmPagoVentaPequenia

    Dim permiso As New clsPermisoUsuario
#Region "Variables"

    Private _idCliente As Integer
    Private _idSalida As Integer
    Private _bitDocumentoCliente As Boolean
    Private _bitCliente As Boolean
    Private _bitDescontarSalidas As Boolean
    Dim pagototal As Decimal = 0.0
    Dim saldofavortotal As Decimal = 0.0
    Dim nopago As Integer = 1
    ''Dim bitdescontarsalidas As Boolean = False
    Dim valida As New bl_Pedidos

#End Region

#Region "Propiedades"
    Public Property idCliente As Integer
        Get
            idCliente = _idCliente
        End Get
        Set(value As Integer)
            _idCliente = value
        End Set
    End Property

    Public Property bitDescontarSalidas As Boolean
        Get
            bitDescontarSalidas = _bitDescontarSalidas
        End Get
        Set(value As Boolean)
            _bitDescontarSalidas = value
        End Set
    End Property

    Public Property idSalida As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(value As Integer)
            _idSalida = value
        End Set
    End Property

    Public Property bitDocumentoCliente As Boolean
        Get
            bitDocumentoCliente = _bitDocumentoCliente
        End Get
        Set(value As Boolean)
            _bitDocumentoCliente = value
        End Set
    End Property

    Public Property bitCliente As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Dim combocliente As Boolean = False

#End Region

#Region "Eventos"
    'INICO DEL FORMULARIO
    Private Sub frmPagoVentaPequenia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbTipoPago)
        mdlPublicVars.comboActivarFiltro(cmbCliente)

        fnLlenarCombos()
        fnObtenerFactura()
        If mdlPublicVars.supersearchclientelibre = True Then
            Me.cmbCliente.Enabled = True
            Me.txtFecha.Enabled = False
            '  Me.nm2Cambio.Enabled = False
            Me.nm2SaldoFavor.Enabled = False
        Else
            cmbCliente.Enabled = False
            fnLlenarDatos()
        End If

        Me.dtpFechaRegistro.Enabled = False

        Me.Button1.Enabled = False

    End Sub

    Private Sub fnObtenerFactura()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim idfactura As Integer = (From x In conexion.tblSalida_Factura Where x.salida = idSalida Select x.factura).FirstOrDefault

                Dim docfactura As String = (From x In conexion.tblFacturas Where x.IdFactura = CInt(idfactura) Select x.DocumentoFactura).FirstOrDefault

                Me.txtFactura.Text = CStr(docfactura)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'CAMBIO EN EL MONTO RECIBIDO
    Private Sub nm2MontoRecibido_ValueChanged(sender As Object, e As EventArgs) Handles nm2MontoRecibido.ValueChanged
        Dim montoRecibido As Decimal = nm2MontoRecibido.Value
        Dim totalPagar As Decimal = nm2TotalPagar.Value
        'nm2Cambio.Value = If(montoRecibido > totalPagar, montoRecibido - totalPagar, 0)
    End Sub

    'ACTIVO O DESACTIVA EL USO DE SALDO A FAVOR
    Private Sub chkSaldoFavor_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaldoFavor.CheckedChanged
        Try
            Dim pagar As Decimal
            Dim saldofavor As Decimal
            Dim nuevopago As Decimal
            Dim nuevosaldofavor As Decimal
            ''Dim pago As Decimal = 0.0


            If nm2TotalPagar.Value >= 0 And chkSaldoFavor.Checked = True Then
                pagototal = nm2TotalPagar.Value
                saldofavortotal = nm2SaldoFavor.Value
            End If

            pagar = nm2TotalPagar.Value
            saldofavor = nm2SaldoFavor.Value

            If chkSaldoFavor.Checked = True Then
                If saldofavor >= pagar Then
                    nuevopago = 0
                    nuevosaldofavor = saldofavor - pagar
                    ''saldofavorcalculo = nuevosaldofavor
                ElseIf saldofavor < pagar Then
                    nuevopago = pagar - saldofavor
                    ''saldofavorcalculo = saldofavor
                    saldofavor = 0
                ElseIf saldofavor = 0 Then
                    nuevopago = nm2TotalPagar.Value
                    ''saldofavorcalculo = 0
                End If
            End If

            If chkSaldoFavor.Checked Then
                If nuevopago = 0 Then
                    nm2TotalPagar.Value = 0
                    nm2SaldoFavor.Value = nuevosaldofavor
                Else
                    nm2TotalPagar.Value = nuevopago
                    nm2SaldoFavor.Value = 0
                End If
            Else
                nm2TotalPagar.Value = pagototal
                nm2SaldoFavor.Value = saldofavortotal
            End If
        Catch

        End Try
    End Sub

    'CLICK EN GUARDAR PAGO              
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If RadMessageBox.Show("¿Desea realizar el pago?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardarPago()

            frmCorrelativoFactura.Text = "Correlativo Factura"
            frmCorrelativoFactura.StartPosition = FormStartPosition.CenterScreen
            frmCorrelativoFactura.WindowState = FormWindowState.Normal
            frmCorrelativoFactura.ShowDialog()
            frmCorrelativoFactura.Dispose()

            ''impresion de la factura si el pago fue realizado
            If supersearchPagado = True And supersearchclientelibre = False Then
                ''If RadMessageBox.Show("Desea Imprimir la Factura", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                valida.fnImprimirFactura(idSalida)
                ''End If
            End If

        End If
    End Sub

    Private Sub fnEstadoCuenta_Click() Handles Me.panel1
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmClienteEstadoCuenta.Text = "Estado de Cuenta"
                frmClienteEstadoCuenta.cliente = idCliente
                frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmClienteEstadoCuenta.BringToFront()
                frmClienteEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
                frmClienteEstadoCuenta.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub
    'SALIR DEL FORMULARIO
    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub

#End Region

#Region "Funciones"
    'LLENAR LOS COMBOS DE SELECCION
    Private Sub fnLlenarCombos()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            If mdlPublicVars.bitTransportePesado = True Then

                Dim clientes As IQueryable = (From x In conexion.tblClientes Select id = x.idCliente, valor = x.Negocio Order By valor Ascending)
                Dim tiposmovimientos As iqueryable = (From x In conexion.tblTipoPagoes Where x.entrada Select id = x.codigo, valor = x.nombre Order By id Ascending)

                mdlPublicVars.llenarCombo(cmbCliente, clientes)
                mdlPublicVars.llenarCombo(cmbTipoPago, tiposmovimientos)

            ElseIf mdlPublicVars.bitEncomienda = True Then

                Dim clientes As IQueryable = (From x In conexion.tblClientes Select id = x.idCliente, valor = x.Negocio Order By valor Ascending)
                Dim tiposmovimientos As iqueryable = (From x In conexion.tblTipoPagoes Where x.entrada And x.codigo >= 1 And x.codigo <= 3 Select id = x.codigo, valor = x.nombre Order By id Ascending)

                mdlPublicVars.llenarCombo(cmbCliente, clientes)
                mdlPublicVars.llenarCombo(cmbTipoPago, tiposmovimientos)

            End If

            conn.Close()
        End Using
    End Sub

    'LLENAR DATOS DEL CLIENTE
    Private Sub fnLlenarDatos()
        'Obtenemos la informacion del cliente
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            If mdlPublicVars.supersearchclientelibre = True And combocliente = True Then
                idCliente = Me.cmbCliente.SelectedValue
            End If

            Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).FirstOrDefault
            If mdlPublicVars.supersearchclientelibre = False Then
                cmbCliente.SelectedValue = idCliente
                combocliente = False
            Else
                combocliente = True
            End If


            If cliente.saldo < 0 Then
                nm2SaldoFavor.Value = CDec(cliente.saldo * -1)
            End If

            Dim salidas As Decimal
            Dim saldoTotal As Decimal
            Try
                salidas = CDec((From x In conexion.tblSalidas Where x.idCliente = cliente.idCliente And x.idSalida = idSalida And x.anulado = False _
                           And x.facturado = True Select x.saldo).Sum)

                saldoTotal = CDec((From x In conexion.tblClientes Where x.idCliente = cliente.idCliente Select x.saldo).Sum)

            Catch ex As Exception
                salidas = 0
            End Try

            If bitDocumentoCliente = True Then
                If salidas <= 0 And saldoTotal >= 0 Then
                    nm2TotalPagar.Value = CDec(saldoTotal)
                    bitdescontarsalidas = True
                ElseIf salidas >= 0 Then
                    nm2TotalPagar.Value = CDec(salidas)
                    bitdescontarsalidas = False
                Else
                    nm2TotalPagar.Value = 0.0
                End If

            ElseIf bitCliente = True Then
                nm2TotalPagar.Value = CDec(If(cliente.saldo < 0, 0, cliente.saldo) + salidas)
            End If
            conn.Close()
        End Using
    End Sub

    'REALIZAR NUEVO PAGO
    Private Sub fnNuevoPago()
        txtDocumento.Text = ""
        txtDocumento.Text = ""
        chkSaldoFavor.Checked = False
        nm2MontoRecibido.Value = 0
        cmbCliente.Enabled = True
    End Sub

    'GUARDAR EL PAGO
    Private Sub fnGuardarPago()
        Dim conexion As dsi_pos_demoEntities
        Dim success As Boolean = True

        Dim montorecibido As Decimal = nm2MontoRecibido.Value
        Dim saldofavor As Decimal

        If montorecibido <> 0 Then
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Using Transaction As New TransactionScope()
                    Try
                        'VARIABLES PARA EL PROCESO
                        Dim idCliente As Integer = CInt(cmbCliente.SelectedValue)
                        Dim idTipoPago As Integer = CInt(cmbTipoPago.SelectedValue)
                        Dim documento As String = txtDocumento.Text
                        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)

                        '' ''TIPO DE PAGO
                        ''Dim tipoPago As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = idTipoPago Select x).FirstOrDefault

                        ''Dim pago As New tblCaja
                        ''pago.documento = If(documento Is Nothing, "", documento)
                        ''pago.anulado = False
                        ''If mdlPublicVars.supersearchclientelibre = False Then
                        ''    pago.codigoSalida = idSalida
                        ''End If
                        '' ''If bitDocumentoCliente Then
                        '' ''    ''pago.codigoSalida = idSalida
                        '' ''End If

                        ''pago.fecha = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
                        ''pago.fechaTransaccion = fecha
                        ''pago.fechaCobro = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
                        ''pago.monto = If(nm2TotalPagar.Value > 0, If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value), nm2MontoRecibido.Value)
                        '' ''pago.monto = If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value)
                        ''pago.tipoCambio = 1
                        ''pago.tipoPago = idTipoPago
                        ''pago.empresa = mdlPublicVars.idEmpresa
                        ''pago.usuario = mdlPublicVars.idUsuario
                        ''pago.observacion = Observacion
                        ''pago.descripcion = tipoPago.nombre
                        ''pago.bitRechazado = False
                        ''If nm2TotalPagar.Value > 0 Then
                        ''    pago.consumido = pago.monto
                        ''    pago.afavor = 0
                        ''Else
                        ''    pago.consumido = 0
                        ''    pago.afavor = pago.monto
                        ''End If
                        ''pago.confirmado = True
                        ''pago.transito = False
                        ''pago.cliente = idCliente
                        ''pago.bitEntrada = True
                        ''pago.bitSalida = False

                        ''conexion.AddTotblCajas(pago)
                        ''conexion.SaveChanges()

                        If mdlPublicVars.supersearchclientelibre = False Then
                            Dim salidamod As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                            If chkSaldoFavor.Checked = True Then
                                saldofavor = nm2SaldoFavor.Value
                            Else
                                saldofavor = 0
                            End If

                            If nm2TotalPagar.Value < nm2MontoRecibido.Value Then
                                bitDescontarSalidas = True
                            Else
                                bitDescontarSalidas = False
                            End If

                            ''Valicaciones para ver si descuenta por documento o por saldo
                            If bitDescontarSalidas = False Then
                                Dim salidapagada As Decimal
                                Dim salidatotal As Decimal
                                Dim validacionpago As Decimal

                                salidatotal = salidamod.total
                                salidapagada = salidamod.pagado

                                validacionpago = (CDec(salidapagada) + (montorecibido + (saldofavortotal - saldofavor)))

                                If validacionpago >= salidatotal Then

                                    fnGuardaCajaPago(salidamod.saldo, salidamod.idSalida, conexion)

                                    salidamod.saldo = 0
                                    salidamod.pagado = salidatotal

                                Else
                                    '---
                                    salidamod.saldo -= (montorecibido + (saldofavortotal - saldofavor))
                                    salidamod.pagado += (montorecibido + (saldofavortotal - saldofavor))

                                    fnGuardaCajaPago((montorecibido + (saldofavortotal - saldofavor)), salidamod.idSalida, conexion)
                                End If

                                conexion.SaveChanges()

                            Else
                                Dim montopago As Decimal
                                montopago = montorecibido

                                While montopago > 0
                                    Dim saldosalidafecha As tblSalida = (From x In conexion.tblSalidas Where x.idCliente = idCliente And x.facturado = True And x.anulado = False And x.saldo > 0 Order By x.fechaFacturado Descending Select x).Take(1).FirstOrDefault

                                    If saldosalidafecha Is Nothing Then

                                        fnGuardaCajaPago(montopago, 0, conexion)

                                        montopago = 0
                                        Exit While
                                    End If

                                    If montopago > saldosalidafecha.saldo Then

                                        fnGuardaCajaPago(saldosalidafecha.saldo, saldosalidafecha.idSalida, conexion)

                                        montopago -= saldosalidafecha.saldo
                                        saldosalidafecha.pagado += saldosalidafecha.saldo
                                        saldosalidafecha.saldo = 0

                                    ElseIf montopago <= saldosalidafecha.saldo Then

                                        fnGuardaCajaPago(montopago, saldosalidafecha.idSalida, conexion)

                                        saldosalidafecha.saldo -= montopago
                                        saldosalidafecha.pagado += montopago
                                        montopago = 0

                                    End If

                                    conexion.SaveChanges()
                                    nopago = nopago + 1
                                End While

                            End If
                            ''fin de la validacion del tipo de descuento

                            Dim clientemod As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).FirstOrDefault

                            Dim montopag As Decimal


                            montopag = (montorecibido + (saldofavortotal - saldofavor))

                            If saldofavortotal <> saldofavor Then
                                montopag *= -1
                            End If

                            clientemod.saldo -= montopag
                            clientemod.pagos += montopag

                            conexion.SaveChanges()

                            ''Pago por Saldo General del Cliente
                        Else

                            ''Para Descontar de las salidas que tengan saldo todavia

                            Dim montopago As Decimal
                            montopago = montorecibido

                            While montopago > 0
                                Dim saldosalidafecha As tblSalida = (From x In conexion.tblSalidas Where x.idCliente = idCliente And x.facturado = True And x.anulado = False And x.saldo > 0 Order By x.fechaFacturado Descending Select x).Take(1).FirstOrDefault

                                If saldosalidafecha Is Nothing Then

                                    fnGuardaCajaPago(montopago, 0, conexion)

                                    montopago = 0
                                    Exit While
                                End If

                                If montopago > saldosalidafecha.saldo Then

                                    fnGuardaCajaPago(saldosalidafecha.saldo, saldosalidafecha.idSalida, conexion)

                                    montopago -= saldosalidafecha.saldo
                                    saldosalidafecha.pagado = saldosalidafecha.saldo
                                    saldosalidafecha.saldo = 0

                                ElseIf montopago < saldosalidafecha.saldo Then

                                    fnGuardaCajaPago(montopago, saldosalidafecha.idSalida, conexion)

                                    saldosalidafecha.saldo -= montopago
                                    saldosalidafecha.pagado += montopago
                                    montopago = 0

                                End If

                                conexion.SaveChanges()
                            End While

                            ''Fin del descuento de saldos de las ventas

                            Dim clien As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente And x.habillitado = True Select x).FirstOrDefault


                            If montopago <> 0 Then
                                clien.saldo -= montorecibido
                                clien.pagos += montorecibido

                                conexion.SaveChanges()
                            End If
                        End If
                        Transaction.Complete()
                    Catch ex As Exception
                        success = False
                    End Try
                End Using
                conn.Close()
                alerta.fnGuardar()
                supersearchPagado = True
            End Using

            ''If RadMessageBox.Show("Desea Realizar otro Pago", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ''    fnLlenarDatos()
            ''    fnLlenarCombos()
            ''Else
        End If
        Me.Close()
        ''End If

    End Sub
#End Region

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged
        fnLlenarDatos()
    End Sub

    Private Sub fnGuardaCajaPago(ByVal montopago As Double, ByVal salida As Integer, ByVal conexion As dsi_pos_demoEntities)
        Try

            'VARIABLES PARA EL PROCESO
            Dim idCliente As Integer = CInt(cmbCliente.SelectedValue)
            Dim idTipoPago As Integer = CInt(cmbTipoPago.SelectedValue)
            Dim documento As String = txtDocumento.Text
            Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)

            'TIPO DE PAGO
            Dim tipoPago As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = idTipoPago Select x).FirstOrDefault


            Dim tipoPago2 As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = 27 Select x).FirstOrDefault

            Dim pago As New tblCaja
            pago.documento = If(documento Is Nothing, "", documento)
            pago.anulado = False
            If mdlPublicVars.supersearchclientelibre = False Then
                pago.codigoSalida = salida
            ElseIf salida = 0 Then

            End If
            ''If bitDocumentoCliente Then
            ''    ''pago.codigoSalida = idSalida
            ''End If

            pago.fecha = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
            pago.fechaTransaccion = fecha
            pago.fechaCobro = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
            ''pago.monto = If(nm2TotalPagar.Value > 0, If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value), nm2MontoRecibido.Value)
            ''pago.monto = If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value)
            pago.monto = montopago
            If nopago = 1 Then
                pago.tipoPago = idTipoPago
            Else
                pago.tipoPago = 27
            End If
            pago.empresa = mdlPublicVars.idEmpresa
            pago.usuario = mdlPublicVars.idUsuario
            pago.observacion = Observacion
            If nopago = 1 Then
                pago.descripcion = tipoPago.nombre
            Else
                pago.descripcion = tipoPago2.nombre
            End If
            pago.bitRechazado = False
            ''If nm2TotalPagar.Value > 0 Then
            pago.consumido = pago.monto
            pago.afavor = 0
            ''Else
            ''    pago.consumido = 0
            ''    pago.afavor = pago.monto
            ''End If
            pago.confirmado = True
            pago.transito = False
            pago.cliente = idCliente
            pago.bitEntrada = True
            pago.bitSalida = False
            pago.codutilizado = 0

            conexion.AddTotblCajas(pago)
            conexion.SaveChanges()
            ''            Dim caja As Integer = pago.codigo

            ''fnCajaPagoSalidas(pago.codigo, idSalida, idCliente, montopago, conexion)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCajaPagoSalidas(ByVal idcaja As Integer, ByVal idsalida As Integer, ByVal idcliente As Integer, ByVal monto As Double, ByVal conexion As dsi_pos_demoEntities)

        Try

            Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
            Dim fechafiltro As Date = CType(fnFechaServidor(), Date)

            Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

            Dim pagosalida As New tblCajaSalida

            pagosalida.idCaja = idcaja
            pagosalida.idCliente = idcliente
            pagosalida.idSalida = idsalida
            pagosalida.fechaRegistro = fecha
            pagosalida.fechaFiltro = fechafiltro
            pagosalida.saldoSalida = salida.total
            pagosalida.saldoNuevo = pagosalida.saldoSalida - monto
            pagosalida.monto = monto

            conexion.AddTotblCajaSalidas(pagosalida)
            conexion.SaveChanges()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbTipoPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPago.SelectedValueChanged
        Dim idTipoPago As Integer = CInt(cmbTipoPago.SelectedValue)
        If idTipoPago = 1 Then
            dtpFechaCobro.Enabled = False
        ElseIf idTipoPago = 2 Then
            dtpFechaCobro.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim codigo

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                codigo = (From x In conexion.tblSalida_Factura Where x.salida = idSalida Select x.factura).FirstOrDefault

                conn.Close()
            End Using


            frmFacturaDescuento.codigo = codigo
            frmFacturaDescuento.Text = "Ajuste Factura"
            frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
            frmFacturaDescuento.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class