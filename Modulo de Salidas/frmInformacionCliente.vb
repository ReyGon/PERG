Imports System.Linq
Imports System.Data.EntityClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows

Public Class frmInformacionCliente
    Private permiso As New clsPermisoUsuario
    Private _codcliente As Integer
    'dim tbl As New clsDevuelveTabla

    Public Property codcliente() As Integer
        Get
            codcliente = _codcliente
        End Get
        Set(ByVal value As Integer)
            _codcliente = value
        End Set
    End Property

    Private _ventaActual As Double
    Public Property ventaActual As Double
        Get
            ventaActual = _ventaActual
        End Get
        Set(ByVal value As Double)
            _ventaActual = value
        End Set
    End Property

    'ESTADISTICA
    Private Sub fnEstadistica() Handles Me.panel0
        If CInt(cmbCliente.SelectedValue > 0) Then
            frmClienteEstadistica.idCliente = CInt(cmbCliente.SelectedValue)
            frmClienteEstadistica.StartPosition = FormStartPosition.CenterScreen
            frmClienteEstadistica.WindowState = FormWindowState.Normal
            frmClienteEstadistica.frecuenciacompra = CDec(Me.txtFrecuenciaCompra.Text)
            frmClienteEstadistica.ventaAcumulada = CDec(Me.txtVentaAcumMes.Text)
            frmClienteEstadistica.ventapromedio = CDec(Me.txtPromedioCompra.Text)
            frmClienteEstadistica.Text = "Estadistica de Venta"
            frmClienteEstadistica.ShowDialog()
        End If
    End Sub


    'ESTADO DE CUENTA
    Private Sub fnEstadoCuenta() Handles Me.panel1
        If CInt(cmbCliente.SelectedValue > 0) Then
            frmClienteEstadoCuenta.Text = "Estado de Cuenta"
            frmClienteEstadoCuenta.cliente = CInt(cmbCliente.SelectedValue)
            frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
            frmClienteEstadoCuenta.BringToFront()
            frmClienteEstadoCuenta.Focus()
            permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
            frmClienteEstadoCuenta.Dispose()
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    Private Sub frmInformacionCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        fnLlenarCombo()
        If codcliente > 0 Then
            cmbCliente.SelectedValue = codcliente
        End If

        fnLlenarDatos()
    End Sub

    Private Sub fnLlenarDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechaactual As DateTime = fnFecha_horaServidor()
                Dim fecha1 As Date
                Dim fecha2 As DateTime
                Dim fecha3 As DateTime
                Dim fecha4 As DateTime
                Dim codcliente As Integer = Me.cmbCliente.SelectedValue

                fecha1 = fechaactual.ToShortDateString
                fecha2 = DateAdd(DateInterval.Month, -3, fecha1)
                fecha3 = DateAdd(DateInterval.Month, -1, fecha1)

                ''Variables para datos de resultados.
                Dim PromedioMes As Decimal
                Dim FrecuenciaCompra As Integer
                Dim IndiceRotacionMes As Decimal
                Dim IndiceRotacionPedido As Integer
                Dim PedidosMes As Integer
                Dim FechaUltCompra As Date
                Dim MontoUltimaCompra As Decimal
                Dim MetaVenta As Decimal
                Dim VentaAcumladaMes As Decimal
                Dim VentaPendienteMes As Decimal
                ''Fin variables para datos de resultados.

                ''Promedio Por 3 meses
                ''Dim totcompras = (From x In conexion.tblEntradas Where (x.fechaRegistro >= fecha2 And x.fechaRegistro <= fechaactual) And x.anulado = False And x.compra = True Select x.total).Sum
                ''Dim contcompras = (From x In conexion.tblEntradas Where (x.fechaRegistro >= fecha2 And x.fechaRegistro <= fechaactual) And x.anulado = False And x.compra = True Select x.total).Count

                Dim totcompras = (From x In conexion.tblSalidas Where (x.fechaRegistro >= fecha2 And x.fechaRegistro <= fechaactual) And x.anulado = False And x.facturado = True And x.idCliente = codcliente Select x.total).Sum
                Dim contcompras = (From x In conexion.tblSalidas Where (x.fechaRegistro >= fecha2 And x.fechaRegistro <= fechaactual) And x.anulado = False And x.facturado = True And x.idCliente = codcliente Select x.total).Count

                PromedioMes = totcompras / 3
                txtPromedioCompra.Text = Format(PromedioMes, formatoMoneda)
                ''Fin Promedio Por 3 meses

                ''Fecuencia Compra
                ''FrecuenciaCompra = (From x In conexion.tblEntradas Where (x.fechaRegistro >= fecha3 And x.fechaRegistro <= fechaactual) And x.anulado = False And x.compra = True Select x.total).Count
                FrecuenciaCompra = (From x In conexion.tblSalidas Where (x.fechaRegistro >= fecha3 And x.fechaRegistro <= fechaactual) And x.anulado = False And x.facturado = True And x.idCliente = codcliente Select x.total).Count
                Try
                    txtFrecuenciaCompra.Text = Format((31 / FrecuenciaCompra), formatoNumero)
                Catch ex As Exception
                    txtFrecuenciaCompra.Text = Format(0, formatoNumero)
                End Try
                ''Fin Fecuencia Compra

                ''Rotacion Articulos Mes
                Dim totArticulosCliente = (From x In conexion.tblSalidas, y In conexion.tblSalidaDetalles Where x.idSalida = y.idSalida And x.facturado = True And x.anulado = False _
                                    And (x.fechaRegistro >= fecha3 And x.fechaRegistro <= fechaactual) And x.idCliente = codcliente _
                                    Group By IdArticulo = y.idArticulo _
                                    Into Group _
                                    Select IdArticulo).Count

                Dim totArticulos = (From x In conexion.tblArticuloes Where x.Habilitado = True Select x.idArticulo).Count

                IndiceRotacionMes = (totArticulosCliente / totArticulos) * 100
                txtIndiceRotacion.Text = Format(IndiceRotacionMes, formatoNumero)
                ''Fin Rotacion Articulos Mes

                ''Rotacion Articulos Pedidos
                Dim totPedidosClientes = (From x In conexion.tblSalidas Where x.facturado = True And x.anulado = False And x.idCliente = codcliente And (x.fechaRegistro >= fecha3 And x.fechaRegistro <= fechaactual) Select x.idSalida).Count

                txtIndiceRotacionPedido.Text = Format(totArticulosCliente / totPedidosClientes, formatoNumero)
                ''Fin Rotacion Articulos Pedidos

                ''Total Pedidos Mes
                txtPedidosMes.Text = Format(totPedidosClientes, formatoNumero)
                ''Fin Total Pedidos Mes

                ''Fecha Ultima Compra
                Dim fechaultima As Date = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x.FechaUltimaCompra).FirstOrDefault

                FechaUltCompra = fechaultima.ToShortDateString
                txtUltimaCompraFecha.Text = FechaUltCompra.ToShortDateString
                ''Fin Fecha Ultima Compra

                ''Monto Ultima Compra

                Dim monto = (From x In conexion.tblSalidas Where x.facturado = True And x.anulado = False And x.idCliente = codcliente Order By x.fechaFacturado Descending Select x.total).Take(1).FirstOrDefault

                Dim montos As Decimal = monto

                MontoUltimaCompra = Format(montos, formatoNumero)

                txtUltimaCompraMonto.Text = Format(MontoUltimaCompra, formatoMoneda)
                ''Fin Monto Ultima Compra

                ''Meta Venta
                MetaVenta = (PromedioMes * 0.06) + PromedioMes

                txtMetaVenta.Text = Format(MetaVenta, formatoMoneda)
                ''Fin Meta Venta

                ''Venta Acumulada Mes

                Dim dias As Integer = fechaactual.Day
                Dim diaresta As Integer

                If dias > 1 Then
                    diaresta = dias - 1

                    fecha4 = DateAdd(DateInterval.Day, -(diaresta), fecha1)
                ElseIf dias = 1 Then
                    fecha4 = fecha1
                End If

                Dim ventasmes = (From x In conexion.tblSalidas Where x.facturado = True And x.anulado = False And x.idCliente = codcliente And (x.fechaFacturado >= fecha4 And x.fechaFacturado <= fechaactual) Select x.total).Sum

                VentaAcumladaMes = Format(ventasmes, formatoNumero)

                txtVentaAcumMes.Text = Format(VentaAcumladaMes, formatoMoneda)
                ''Fin Venta Acumulada Mes

                ''Venta Pendiente Mes
                txtVentaPendienteMes.Text = Format(MetaVenta - VentaAcumladaMes, formatoMoneda)
                ''Fin Venta Pendiente Mes
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Llenar COMBOS
    Private Sub fnLlenarCombo()
        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim cliente = (From x In conexion.tblClientes Select codigo = x.idCliente, nombre = x.Negocio)

            With cmbCliente
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = cliente
            End With

            conn.Close()
        End Using
    End Sub

    'Funcion utilizada para obtener los tipos de precio de un cliente
    Private Sub fnTiposPrecio(ByVal idCliente As Integer)
        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim precios As List(Of tblCliente_Precio) = (From x In conexion.tblCliente_Precio Where x.cliente = idCliente Select x).ToList
            lblTiposPrecio.Text = "No tiene otros precios"

            For Each precio As tblCliente_Precio In precios
                If lblTiposPrecio.Text.Equals("No tiene otros precios") Then
                    lblTiposPrecio.Text = ""
                End If
                lblTiposPrecio.Text = lblTiposPrecio.Text & precio.tblArticuloTipoPrecio.nombre & vbCrLf
            Next
            conn.Close()
        End Using
    End Sub

    'Funcion utilizada para llenar los saldos del cliente
    Private Sub fnSaldos(ByVal idCliente As Integer)

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            'Obtenemos el cliente
            Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = idCliente _
                                         Select x).FirstOrDefault

            Dim salidas As Double
            Try
                salidas = (From x In conexion.tblSalidas Where x.idCliente = cliente.idCliente And x.anulado = False _
                           And x.facturado = False And x.despachar = True _
                           Select x.total).Sum
            Catch ex As Exception
                salidas = 0
            End Try

            'Obtenemos el credito disponible, sobregiro, y sobre pago programado
            Dim creditoDisponible As Double = cliente.limiteCredito - (cliente.saldo) - salidas
            Dim sobreGiro As Double = (cliente.porcentajeCredito / 100) * cliente.limiteCredito

            lblCreditoLimite.Text = Format(cliente.limiteCredito, mdlPublicVars.formatoMoneda)

            lblPagosProgramados.Text = Format(cliente.pagosTransito, mdlPublicVars.formatoMoneda)
            lblSaldo.Text = Format(cliente.saldo, mdlPublicVars.formatoMoneda)
            lblSobregiro.Text = Format(sobreGiro, mdlPublicVars.formatoMoneda)
            lblVentasDespachadas.Text = Format(salidas, mdlPublicVars.formatoMoneda)
            'lblVentaActual.Text = Format(ventaActual, mdlPublicVars.formatoMoneda)

            If cliente.limiteCredito > 0 Then
                lblCreditoDisponible.Text = Format(cliente.limiteCredito - cliente.saldo - salidas + cliente.pagosTransito, mdlPublicVars.formatoMoneda)
            Else
                lblCreditoDisponible.Text = Format(0, mdlPublicVars.formatoMoneda)
            End If

            conn.Close()
        End Using
    End Sub

    'DETALLE DE VENTAS
    Private Sub btnDetalleVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleVentas.Click
        frmDetalleVentasPagos.Text = "Ventas"
        frmDetalleVentasPagos.bitVentas = True
        frmDetalleVentasPagos.cliente = codcliente
        frmDetalleVentasPagos.total = CDec(lblVentasDespachadas.Text)
        frmDetalleVentasPagos.StartPosition = FormStartPosition.CenterScreen
        frmDetalleVentasPagos.ShowDialog()
        frmDetalleVentasPagos.Dispose()
    End Sub

    'DETALE DE PAGOS
    Private Sub btnDetallePagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetallePagos.Click
        frmDetalleVentasPagos.Text = "Pagos"
        frmDetalleVentasPagos.bitPagos = True
        frmDetalleVentasPagos.cliente = codcliente
        frmDetalleVentasPagos.total = CDec(lblPagosProgramados.Text)
        frmDetalleVentasPagos.StartPosition = FormStartPosition.CenterScreen
        frmDetalleVentasPagos.ShowDialog()
        frmDetalleVentasPagos.Dispose()
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        'Obtenemos el id del cliente
        If CInt(cmbCliente.SelectedValue) > 0 Then
            Dim conexion As dsi_pos_demoEntities
            Dim idCliente As Integer = CInt(cmbCliente.SelectedValue)
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                'Informacoin del cliente
                Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = idCliente Select x).FirstOrDefault
                lblClave.Text = cliente.clave
                lblDireccion.Text = If(cliente.direccionFactura1 Is Nothing, "", cliente.direccionFactura1) & " ; " & If(cliente.direccionFactura2 Is Nothing, "", cliente.direccionFactura2)

                conn.Close()
            End Using
            fnSaldos(idCliente)
            fnTiposPrecio(idCliente)
            fnLlenarDatos()
        End If
    End Sub

    Private Sub btnTelefono_Click(sender As System.Object, e As System.EventArgs) Handles btnTelefono.Click
        frmDetalleTelefono.Text = "Teléfonos"
        frmDetalleTelefono.StartPosition = FormStartPosition.CenterScreen
        frmDetalleTelefono.idCliente = CInt(cmbCliente.SelectedValue)
        frmDetalleTelefono.ShowDialog()
        frmDetalleTelefono.Dispose()
    End Sub
End Class