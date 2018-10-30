Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmPedidoConcepto

    Dim es As Telerik.WinControls.UI.CellFormattingEventArgs

    Dim permiso As New clsPermisoUsuario

    Private _idSalida As Integer

    Public Property idSalida() As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(ByVal value As Integer)
            _idSalida = value
        End Set
    End Property

    Private Property lblEnvio As Object

    Private Sub frmPedidoConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        fnLlenarDatos()
        fnSumarios()
        mdlPublicVars.fnGrid_iconos(Me.grdProductos)
    End Sub

    'Funcion utilizada para agregar las filas summary
    Private Sub fnSumarios()
        'Agregamos antes las filas de sumas
        Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
        Dim summaryTotal As New GridViewSummaryItem("Total", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

        grdProductos.SummaryRowsTop.Add(summaryRowItem)
    End Sub

    'funcion para recotizar las ventas anuladas.
    Private Sub fnRecotiza() Handles Me.panel1
        fnRecotizar()
    End Sub

    'Funcion que se utliza para llenar los datos de unqa salida cuando se esta en modificar
    Private Sub fnLlenarDatos()
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                grdProductos.Rows.Clear()

                '//--------------------------------------------  AJUSTES

                Dim ajustes = (From x In conexion.tblMovimientoInventarioDetalles Where x.tblMovimientoInventario.bitVenta = True _
                               And x.tblMovimientoInventario.codigoSalida = idSalida And x.tblMovimientoInventario.anulado = False _
                               Select Total = If(x.cantidad > 0, CType(If(x.tblTipoMovimiento.aumentaInventario = True, x.cantidad * x.tblSalidaDetalle.precio, -(x.cantidad * x.tblSalidaDetalle.precio)), Decimal), 0))

                Dim fila
                Dim totalAjuste As Double = 0
                For Each fila In ajustes
                    totalAjuste = totalAjuste + fila
                Next

                totalAjuste = totalAjuste
                lblTotalAjustes.Text = Format(totalAjuste, mdlPublicVars.formatoMoneda)

                '//--------------------------------------------  AJUSTES


                '/-------------------------------------------- Pendientes por surtir
                Dim pendientes = (From x In conexion.tblSurtirs Where x.tblSalidaDetalle.tblSalida.idSalida = idSalida _
                                  Select Total = x.cantidad * x.tblSalidaDetalle.precio)

                Dim fila2
                Dim totalSurtir As Double = 0
                For Each fila2 In pendientes
                    totalSurtir = totalSurtir + fila2
                Next

                totalSurtir = totalSurtir * -1
                lblTotalSurtir.Text = Format(totalSurtir, mdlPublicVars.formatoMoneda)

                Dim pedido As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida _
                                           Select x).FirstOrDefault


                Dim totalVentaInicial As Double = pedido.total - totalAjuste - totalSurtir + pedido.descuento
                lblVentaInicial.Text = Format(totalVentaInicial, mdlPublicVars.formatoMoneda)


                ' lblCliente.Text = pedido.tblCliente.Negocio
                lblCliente.Text = pedido.cliente
                lblNit.Text = pedido.nit
                lblNegocio.Text = pedido.tblCliente.Negocio

                lblFechaRegistro.Text = Format(pedido.fechaRegistro, mdlPublicVars.formatoFecha)
                lblVendedor.Text = pedido.tblVendedor.nombre
                lblTotal.Text = Format(pedido.total, mdlPublicVars.formatoMoneda)
                lblSaldo.Text = Format(pedido.saldo, mdlPublicVars.formatoMoneda)
                lblDevoluciones.Text = Format(pedido.devoluciones, mdlPublicVars.formatoMoneda)
                lblPagado.Text = Format(pedido.pagado, mdlPublicVars.formatoMoneda)
                lblDocumento.Text = pedido.documento
                lblCotizado.Text = If(pedido.cotizado, "SI", "NO")
                lblReservado.Text = If(pedido.reservado, "SI", "NO")
                lblDespachado.Text = If(pedido.despachar, "SI", "NO")
                lblEmpacado.Text = If(pedido.empacado, "SI", "NO")
                lblFacturado.Text = If(pedido.facturado, "SI", "NO")
                lblDireccionEnvio.Text = pedido.direccionEnvio
                lblDireccionFacturacion.Text = pedido.direccionFacturacion
                lblObservacion.Text = pedido.observacion
                lblDescuento.Text = pedido.descuento

                If pedido.efectividaVenta Is Nothing Then
                    lblEfectividadVenta.Text = ""
                Else
                    Dim numero As Double
                    numero = pedido.efectividaVenta

                    lblEfectividadVenta.Text = Math.Truncate(numero)
                End If

                Try
                    Dim empacado As tblsalidaBodega = (From x In conexion.tblsalidaBodegas Where x.idsalida = idSalida Select x).FirstOrDefault

                    Dim fecha As DateTime = empacado.fechaEmpacado

                    Me.lblEmpaque.Text = CStr(fecha)
                Catch ex As Exception

                End Try

                'AGREGAMOS LOS PRODUCTOS AL GRID
                'Obtenemos el detalle de ese pedido
                Dim lDetalles As IQueryable = (From x In conexion.tblSalidaDetalles, y In conexion.tblUnidadMedidas Where x.idSalida = pedido.idSalida And x.idunidadmedida = y.idunidadMedida _
                                               And If(x.tblSalida.anulado = False, x.anulado = False, If(x.tblSalida.anulado = True And x.tblSalida.cotizado = True And x.tblSalida.despachar = False And x.tblSalida.reservado = False, x.anulado = False, x.anulado = True)) _
                                               And x.kitSalidaDetalle Is Nothing And x.cantidad > 0 _
                                                Select Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, Cantidad = x.cantidad, UnidadMedida = y.nombre, _
                                                Precio = x.precio, Total = (x.precio * x.cantidad), CodigoTipoPrecio = x.tipoPrecio, TipoPrecio = x.tblArticuloTipoPrecio.nombre, _
                                                txbObservacion = x.comentario)

                Me.grdProductos.DataSource = lDetalles


                'Llenamos las facturas relacionadas al pedido
                Dim lfacturas As List(Of tblSalida_Factura) = (From f In conexion.tblSalida_Factura Where f.salida = pedido.idSalida And f.tblFactura.anulado = False Select f).ToList

                Dim facturas As String = ""
                Dim fac
                For Each fac In lfacturas
                    facturas += fac.tblFactura.DocumentoFactura & ",  "
                Next

                If facturas Is Nothing Then
                    lblFacturasImpresas.Text = ""
                Else
                    lblFacturasImpresas.Text = facturas
                End If

                Dim lfacturasAnuladas As List(Of tblSalida_Factura) = (From fa In conexion.tblSalida_Factura Where fa.salida = pedido.idSalida And fa.tblFactura.anulado = True Select fa).ToList

                Dim facturasAnuladas As String = ""
                Dim facAn
                For Each facAn In lfacturasAnuladas
                    facturasAnuladas += facAn.tblFactura.DocumentoFactura & ",  "
                Next

                If facturasAnuladas Is Nothing Then
                    lblFacturasAnuladas.Text = ""
                Else
                    lblFacturasAnuladas.Text = facturasAnuladas
                End If
            Catch ex As Exception
                alerta.contenido = ex.ToString
                alerta.fnErrorContenido()
            End Try

            conn.close()
        End Using

        fnConfiguracion()

    End Sub

    'Funcion utilizada para configurar el grid
    Private Sub fnConfiguracion()
        If Me.grdProductos.ColumnCount > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Total")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Precio")

            If mdlPublicVars.bitUnidadMedida_Activado Then
                Me.grdProductos.Columns("UnidadMedida").IsVisible = True
            Else
                Me.grdProductos.Columns("UnidadMedida").IsVisible = False
            End If

            Me.grdProductos.Columns("CodigoTipoPrecio").IsVisible = False
            Me.grdProductos.Columns("Codigo").Width = 80
            Me.grdProductos.Columns("Nombre").Width = 170
            Me.grdProductos.Columns("Cantidad").Width = 60
            Me.grdProductos.Columns("UnidadMedida").Width = 100
            Me.grdProductos.Columns("Precio").Width = 70
            Me.grdProductos.Columns("Total").Width = 80
            Me.grdProductos.Columns("TipoPrecio").Width = 60
            Me.grdProductos.Columns("txbObservacion").Width = 80

        End If
    End Sub

    'Funcion utilizada para imprimir el despacho
    Private Sub fnImprimir(ByVal codSalida)
        Dim c As New clsReporte
        c.tabla = EntitiToDataTable(ctx.sp_reportePickingPedido("", codSalida))
        c.nombreParametro = "@filtro"
        c.reporte = "ventas_Picking.rpt"
        c.parametro = ""
        c.verReporte()
    End Sub

    'BODEGA CONCEPTO
    Private Sub fnBodega() Handles Me.panel0

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(entityBuilder.ToString)

            Dim salida As tblSalida = (From x In conexion.tblSalidas.AsEnumerable Where x.idSalida = idSalida Select x).FirstOrDefault

            If (salida.empacado Or salida.facturado) And Not salida.anulado Then
                frmPedidosBodega.Text = "Bodega"
                frmPedidosBodega.idSalida = idSalida
                frmPedidosBodega.StartPosition = FormStartPosition.CenterScreen
                frmPedidosBodega.ShowDialog()
            Else
                RadMessageBox.Show("No tiene registro en bodega", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If

            conn.Close()
        End Using
    End Sub

    'INFORMACION DEL CLIENTE
    Private Sub fnInfoCLiente() Handles Me.panel2

        Dim pedido As tblSalida = (From x In ctx.tblSalidas.AsEnumerable Where x.idSalida = idSalida _
                                       Select x).FirstOrDefault


        frmInformacionCliente.codcliente = pedido.idCliente
        frmInformacionCliente.Text = "Informacion de Cliente"
        frmInformacionCliente.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmInformacionCliente)
        frmInformacionCliente.Dispose()

    End Sub

    'LISTADO DE IMPRESION
    Private Sub fnListadoImpresion() Handles Me.panel3

        frmListadoImpresionDocumento.Text = "Lista de Impresiones"
        frmListadoImpresionDocumento.StartPosition = FormStartPosition.CenterScreen
        frmListadoImpresionDocumento.salida = idSalida
        frmListadoImpresionDocumento.ShowDialog()
        frmListadoImpresionDocumento.Dispose()
    End Sub

    'IMPRIMIR
    Private Sub fnImpresion() Handles Me.panel4
        'fnImprimir(codigo)
        fnDocSalida()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel5
        Me.Close()
    End Sub

    Private Sub fnDocSalida()
        Try
            Dim salida As tblSalida = (From x In ctx.tblSalidas.AsEnumerable Where x.idSalida = idSalida).FirstOrDefault
            frmDocumentosSalida.tabla = EntitiToDataTable(ctx.sp_ReporteVenta("", False, idSalida))
            frmDocumentosSalida.tablaCodigo = EntitiToDataTable(ctx.sp_ReporteVenta("", True, idSalida))
            frmDocumentosSalida.tablaPicking = EntitiToDataTable(ctx.sp_reportePickingPedido("", idSalida))
            frmDocumentosSalida.reporteBase = Nothing
            frmDocumentosSalida.bitGenerico = False
            frmDocumentosSalida.bitImg = False
            frmDocumentosSalida.bitListaCombo = True
            frmDocumentosSalida.ListaCombo = "ventas"
            frmDocumentosSalida.codigo = idSalida
            frmDocumentosSalida.txtTitulo.Text = "Venta : " & salida.documento
            frmDocumentosSalida.Text = "Doc de Salida, Ventas"
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.codigo = salida.idCliente
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnRecotizar()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechaServidor As DateTime = fnFecha_horaServidor()
                Dim s As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault()
                Dim documento As String = ""
                If s.anulado = True Then

                    If RadMessageBox.Show("Desea Re Cotizar", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Dim success As Boolean = False

                        'crear el encabezado de la transaccion
                        Using transaction As New TransactionScope
                            'inicio de excepcion
                            Try
                                '1ro. Crear el correlativo del documento.
                                Dim codMovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
                                Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codMovimiento _
                                                                     Select x).FirstOrDefault

                                Dim usuario As tblUsuario = (From x In ctx.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                                '2do. crer el encabezado de la salida.
                                Dim salidaNueva As New tblSalida

                                salidaNueva.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                                salidaNueva.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                                salidaNueva.idTipoInventario = s.idTipoInventario
                                salidaNueva.idAlmacen = s.idAlmacen
                                salidaNueva.idTipoMovimiento = s.idTipoMovimiento
                                salidaNueva.idVendedor = usuario.idVendedor

                                salidaNueva.idCliente = s.idCliente
                                salidaNueva.cliente = s.cliente
                                salidaNueva.nit = s.nit

                                salidaNueva.fechaTransaccion = fechaServidor
                                salidaNueva.fechaRegistro = fechaServidor
                                salidaNueva.fechaDespachado = Nothing
                                salidaNueva.observacion = s.observacion

                                salidaNueva.cotizado = True
                                salidaNueva.reservado = False
                                salidaNueva.despachar = False
                                salidaNueva.facturado = False
                                salidaNueva.empacado = False
                                salidaNueva.anulado = False
                                salidaNueva.fechaAnulado = Nothing
                                salidaNueva.idMunicipio = s.idMunicipio
                                salidaNueva.descuento = 0
                                salidaNueva.subtotal = s.total
                                salidaNueva.total = s.total


                                salidaNueva.direccionFacturacion = s.direccionFacturacion
                                salidaNueva.direccionEnvio = s.direccionEnvio

                                salidaNueva.contado = True
                                salidaNueva.credito = False

                                salidaNueva.documento = correlativo.correlativo + 1
                                correlativo.correlativo = correlativo.correlativo + 1
                                documento = salidaNueva.documento
                                'agregar salida al modelo
                                ctx.AddTotblSalidas(salidaNueva)

                                'guardar cambios
                                ctx.SaveChanges()
                                Dim codigoSalidaNuevo = salidaNueva.idSalida

                                '3ro. seleccionar el detalle de la salida
                                Dim lDetalle As List(Of tblSalidaDetalle) = (From x In ctx.tblSalidaDetalles
                                                                             Where x.idSalida = s.idSalida _
                                                                             And ((x.tblSalida.cotizado = True And x.tblSalida.reservado = False And x.tblSalida.despachar = False And x.anulado = False) Or (x.tblSalida.cotizado = False And x.anulado = True Or (x.tblSalida.reservado = True Or x.tblSalida.despachar = True))) Select x).ToList()


                                '4to. guardar el nuevo detalle.
                                Dim fila As tblSalidaDetalle

                                For Each fila In lDetalle

                                    Dim filaNueva As New tblSalidaDetalle
                                    filaNueva.idArticulo = fila.idArticulo
                                    filaNueva.idSalida = codigoSalidaNuevo
                                    filaNueva.precio = fila.precio
                                    filaNueva.comentario = fila.comentario
                                    filaNueva.costo = fila.costo
                                    filaNueva.anulado = False
                                    filaNueva.cantidad = fila.cantidad
                                    filaNueva.tipoInventario = fila.tipoInventario
                                    filaNueva.tipoPrecio = fila.tipoPrecio
                                    filaNueva.kitSalidaDetalle = fila.kitSalidaDetalle
                                    filaNueva.idunidadmedida = 1
                                    filaNueva.valormedida = 1


                                    If fila.cantidad > 0 Then
                                        If (s.cotizado = True And (s.reservado = False Or s.despachar = False) And fila.anulado = True) Or (s.cotizado = True And s.reservado = False And s.despachar = False And fila.anulado = False) Or (s.cotizado = False And (s.reservado = True Or s.despachar = True) And fila.anulado = True) Then
                                            'agregar los registro no anulados, porque fue una cotizacion.
                                            ctx.AddTotblSalidaDetalles(filaNueva)
                                            ctx.SaveChanges()
                                        Else
                                            RadMessageBox.Show("Producto anulado no agregado " + fila.tblArticulo.nombre1)
                                        End If
                                    End If

                                Next

                                alerta.fnGuardar()

                                'paso 8, completar la transaccion.
                                transaction.Complete()
                                success = True

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
                            RadMessageBox.Show("Pedido Creado con Documento: " + documento, mdlPublicVars.nombreSistema)
                        Else
                            alerta.fnError()
                        End If

                    End If
                Else
                    RadMessageBox.Show("Pedido no anulado !!!")
                End If
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        'Obtenemos el valor de la observacion
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
        Dim observacion As String = CStr(Me.grdProductos.Rows(fila).Cells("txbObservacion").Value)
        RadMessageBox.Show(observacion, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
    End Sub

    Private Sub grdProductos_CellFormatting(sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos.CellFormatting
        Try

            For index As Integer = 0 To Me.grdProductos.Rows.Count - 1
                If Me.grdProductos.Rows(index).Cells("CodigoTipoPrecio").Value = mdlPublicVars.BuscarArticulo_CodigoOferta Then
                    mdlPublicVars.GridColor_TextoFila(index, e, Color.Red)
                Else
                    mdlPublicVars.GridColor_TextoFila(index, e, Color.Black)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rgbInformacion_Click(sender As Object, e As EventArgs) Handles rgbInformacion.Click

    End Sub
End Class
