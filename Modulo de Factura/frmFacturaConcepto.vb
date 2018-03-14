Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports System.Transactions

Public Class frmFacturaConcepto

    Private permiso As New clsPermisoUsuario
    Dim descuento As Integer
    Dim b As New clsBase

    Private codigoCliente As Integer

    Private _codigo As Integer

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmPedidoConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        ' mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
        mdlPublicVars.fnFormatoGridMovimientos(grdGuias)
        mdlPublicVars.fnFormatoGridMovimientos(grdImpresiones)
        fnLlenarDatos()
        fnSumarios()
        
    End Sub


    'Funcion utilizada para agregar las filas summary
    Private Sub fnSumarios()

        grdProductos.MasterTemplate.ShowTotals = True
        'Agregamos antes las filas de sumas
        Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
        Dim summaryTotal As New GridViewSummaryItem("Total", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

        grdProductos.SummaryRowsTop.Add(summaryRowItem)
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato

    Private Sub fnConfiguracion(ByRef grd As Telerik.WinControls.UI.RadGridView)
        Try
            If grd.ColumnCount > 2 Then
                grd.Columns.Move(grd.Columns("ingresado").Index, grd.Columns(grd.ColumnCount - 1).Index)

                grd.Columns("idSalidaDetalle").IsVisible = False 'idsalidadetalle        
                grd.Columns("Codigo").Width = 60
                grd.Columns("Nombre").Width = 180
                grd.Columns("Cantidad").Width = 70
                grd.Columns("txmPrecio").Width = 90
                grd.Columns("TipoPrecio").Width = 100

                grd.Columns("Codigo").ReadOnly = True
                grd.Columns("Nombre").ReadOnly = True
                grd.Columns("Cantidad").ReadOnly = True
                grd.Columns("txmPrecio").ReadOnly = False
                grd.Columns("TipoPrecio").ReadOnly = True


                mdlPublicVars.fnGrid_iconos(grdProductos)
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Total")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "txmPrecio")
               
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try


    End Sub


    Private Sub fnLlenarDatos()

        'crear la conexion
        Dim conexion As New dsi_pos_demoEntities
        Dim descuentoResolucion As Decimal = 0

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                'Obtenemos los datos de la factura
                Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigo Select x).FirstOrDefault

                'fecha de facturacion y total
                'txtFechaRegistro.Text = Format(factura.Fecha, mdlPublicVars.formatoFecha)
                dtpFecha.Text = Format(factura.Fecha, mdlPublicVars.formatoFecha)
                lblTotal.Text = Format(factura.Monto, mdlPublicVars.formatoMoneda)

                txtObservacion.Text = factura.observacion
                ' lblCodigoFactura.Text = codigo


                'consultar el descuento de resolucion.
                If IsNumeric(factura.descuento) Then
                    descuentoResolucion = factura.descuento
                End If

                'obtenemos el descuento de la factura
                If factura.descuento Is Nothing Then
                    descuento = 0
                    lblDescuento.Text = ""

                Else
                    descuento = factura.descuento
                    lblDescuento.Text = factura.descuento
                End If

                If factura.idResolucion Is Nothing Then
                    lblResolucion.Text = ""
                Else
                    Dim r As tblResolucionFactura = (From w In conexion.tblResolucionFacturas Where w.idResolucion = factura.idResolucion Select w).FirstOrDefault
                    lblResolucion.Text = r.resolucion
                End If

                Dim lDetalle
                Dim lDetalleTotal As Double

                ''---------------------asi estaba al 9-7-2014
                'lDetalle = (From z In conexion.tblSalidaDetalle_Factura
                '             Where z.idFactura = factura.IdFactura _
                '            And z.tblSalidaDetalle.anulado = False _
                '            Select Codigo = z.tblSalidaDetalle.tblArticulo.codigo1, Nombre = z.tblSalidaDetalle.tblArticulo.nombre1,
                '            Cantidad = z.tblSalidaDetalle.cantidad, Precio = z.tblSalidaDetalle.precio - (z.tblSalidaDetalle.precio * (descuentoResolucion / 100)),
                '            TipoPrecio = z.tblSalidaDetalle.tblArticuloTipoPrecio.nombre, Total = z.tblSalidaDetalle.cantidad * (z.tblSalidaDetalle.precio - (z.tblSalidaDetalle.precio * (descuentoResolucion / 100)))).ToList
                '-----------------------------------------------------------


                lDetalle = (From z In conexion.tblSalidaDetalle_Factura
                             Where z.idFactura = factura.IdFactura _
                            And z.tblSalidaDetalle.anulado = False _
                            Select idSalidaDetalle = z.tblSalidaDetalle.idSalidaDetalle, Codigo = z.tblSalidaDetalle.tblArticulo.codigo1, Nombre = z.tblSalidaDetalle.tblArticulo.nombre1,
                            Cantidad = z.tblSalidaDetalle.cantidad, txmPrecio = z.tblSalidaDetalle.precioFactura,
                            TipoPrecio = z.tblSalidaDetalle.tblArticuloTipoPrecio.nombre, Total = z.tblSalidaDetalle.cantidad * z.tblSalidaDetalle.precioFactura).ToList


                Me.grdProductos.DataSource = mdlPublicVars.EntitiToDataTable(lDetalle)
                'Me.grdProductos.DataSource = lDetalle
                ''---------------------asi estaba al 9-7-2014--------------------------------
                'lDetalleTotal = (From x In conexion.tblSalidaDetalle_Factura Where x.idFactura = factura.IdFactura _
                '          Where x.tblSalidaDetalle.anulado = False
                '          Select (x.tblSalidaDetalle.cantidad * (x.tblSalidaDetalle.precio - (x.tblSalidaDetalle.precio * (descuentoResolucion / 100))))).Sum
                '-----------------------------------------------------------------------------------


                lDetalleTotal = (From x In conexion.tblSalidaDetalle_Factura Where x.idFactura = factura.IdFactura _
                          Where x.tblSalidaDetalle.anulado = False
                          Select (x.tblSalidaDetalle.cantidad * x.tblSalidaDetalle.precioFactura)).Sum

                lblTotal.Text = Format(lDetalleTotal, mdlPublicVars.formatoMoneda)

                Dim dirEnvios As String = ""
                Dim vendedores As String = ""
                Dim documentos As String = ""

                'Obtenemos los pedidos de la factura

                If factura.anulado = True Then
                    Dim salida As tblSalida = (From x In conexion.tblSalidas
                                        Join d In conexion.tblSalidaDetalles On x.idSalida Equals d.idSalida
                                        Join df In conexion.tblSalidaDetalle_Factura On d.idSalidaDetalle Equals df.idSalidaDetalle
                                        Where df.idFactura = codigo Select x).FirstOrDefault

                    txtNombreFacturacion.Text = salida.cliente
                    lblVendedor.Text = salida.tblVendedor.nombre
                    txtDireccionEnvio.Text = salida.direccionEnvio
                    vendedores += salida.tblVendedor.nombre & ", "
                    dirEnvios += salida.direccionEnvio & ", "
                    lblCliente.Text = salida.tblCliente.Negocio
                    txtDireccionFacturacion.Text = salida.direccionFacturacion
                    txtNit.Text = salida.nit
                    documentos += salida.documento & ", "
                    '  txtObservacion.Text = salida.observacion
                    codigoCliente = salida.idCliente
                    'Guias 
                    Dim companyInfo = From x In conexion.tblEnvio_Salida Where x.salida = salida.idSalida
                    Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
                    envioTipo = x.tblEnvio.tblEnvioTipo.nombre, Empresa = x.tblEnvio.tblEnvio_Empresa.nombre, Observacion = x.tblEnvio.observacion,
                     Precio = x.tblEnvio.precio, Documento = x.tblEnvio.documento
                    Me.grdGuias.DataSource = companyInfo
                Else

                    Dim salida As tblSalida = (From x In conexion.tblSalidas
                                    Join d In conexion.tblSalidaDetalles On x.idSalida Equals d.idSalida
                                    Join df In conexion.tblSalidaDetalle_Factura On d.idSalidaDetalle Equals df.idSalidaDetalle
                                    Where df.idFactura = codigo Select x).FirstOrDefault


                    txtNombreFacturacion.Text = salida.cliente
                    lblVendedor.Text = salida.tblVendedor.nombre
                    txtDireccionEnvio.Text = salida.direccionEnvio
                    vendedores += salida.tblVendedor.nombre & ", "
                    dirEnvios += salida.direccionEnvio & ", "
                    lblCliente.Text = salida.tblCliente.Negocio
                    txtDireccionFacturacion.Text = salida.direccionFacturacion
                    txtNit.Text = salida.nit
                    documentos += salida.documento & ", "
                    ' txtObservacion.Text = salida.observacion
                    codigoCliente = salida.idCliente

                    'llenado del grid de guias
                    Dim companyInfo = From x In conexion.tblEnvio_Salida Where x.salida = salida.idSalida
                   Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
                   envioTipo = x.tblEnvio.tblEnvioTipo.nombre, Empresa = x.tblEnvio.tblEnvio_Empresa.nombre, Observacion = x.tblEnvio.observacion,
                   Precio = x.tblEnvio.precio, Documento = x.tblEnvio.documento

                    Me.grdGuias.DataSource = companyInfo
                End If

                txtDireccionEnvio.Text = dirEnvios
                lblVendedor.Text = vendedores
                lblDocumentos.Text = documentos

                'Resolucion existe en facura.
                If factura.idResolucion > 0 Then
                    'ya existe resolucion.
                    lblSerie.Text = factura.tblResolucionFactura.serie
                    lblSiguienteFactura.Text = factura.tblResolucionFactura.correlativo + 1
                    txtFacElectronica.Text = factura.DocumentoFactura
                Else
                    lblSerie.Text = ""
                    lblSiguienteFactura.Text = ""
                    txtFacElectronica.Text = ""
                End If

                'verificar si la factura esta anulada.
                If factura.anulado = True Then
                    txtFacElectronica.Enabled = False

                Else
                    If factura.idResolucion Is Nothing Then
                        'resolucion no existe en Factura electronica.
                        Dim rf As tblResolucionFactura = (From x In conexion.tblResolucionFacturas Where x.idResolucion = 4 Select x).FirstOrDefault
                        lblSiguienteFactura.Text = rf.correlativo + 1
                        lblSerie.Text = rf.serie
                        txtFacElectronica.Text = rf.correlativo + 1
                    End If

                    txtFacElectronica.Enabled = True
                End If

                'llenado del grid de impresiones
                grdImpresiones.DataSource = (From x In conexion.sp_listadoImpresiones(factura.IdFactura) Select x).ToList
                fnConfiguracion(grdProductos)
            Catch ex As Exception
                alerta.fnError()
            End Try
            conn.Close()
        End Using

    End Sub

    'PANEL 0, Modificar datos de encabezado.
    Private Sub fnModificarEncabezado() Handles Me.panel0

        Dim success As Boolean = True

        'crear la conexion
        Dim conexion As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope
                Try
                    Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigo Select x).FirstOrDefault
                    Dim lPedidos As List(Of tblSalida) = (From x In conexion.tblSalidas Join sf In conexion.tblSalida_Factura On x.idSalida Equals sf.salida Where sf.factura = codigo _
                                                      And x.anulado = False Select x).ToList

                    Dim pedido As tblSalida
                    For Each pedido In lPedidos
                        pedido.direccionEnvio = txtDireccionEnvio.Text
                        pedido.nit = txtNit.Text
                        pedido.cliente = txtNombreFacturacion.Text
                        pedido.direccionFacturacion = txtDireccionFacturacion.Text
                        pedido.observacion = txtObservacion.Text
                        'guardar los cambios.
                        conexion.SaveChanges()
                    Next
                    factura.Fecha = dtpFecha.Text
                    factura.fechaFiltro = dtpFecha.Text
                    factura.DocumentoFactura = txtFacElectronica.Text
                    factura.bitImpreso = True
                    'guardar los cambios
                    conexion.SaveChanges()
                    Dim codigoSalidaDetalle As Integer = 0
                    Dim precio As Double = 0
                    'vamos a actualizar los detalles de salida
                    For i As Integer = 0 To grdProductos.RowCount - 1
                        codigoSalidaDetalle = grdProductos.Rows(i).Cells("idSalidaDetalle").Value
                        precio = grdProductos.Rows(i).Cells("txmPrecio").Value

                        If precio > 0 Then
                            Dim salidaDetalle As tblSalidaDetalle = (From sd In conexion.tblSalidaDetalles Where sd.idSalidaDetalle = codigoSalidaDetalle Select sd).FirstOrDefault
                            salidaDetalle.precioFactura = precio
                            conexion.SaveChanges()
                        End If
                    Next
                    success = True
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
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion
            conn.Close()
            'finalizar el proceso de conexion.
        End Using

    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel3
        Me.Close()
    End Sub


    Private Sub fnDocSalida() Handles Me.panel2
        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario

        Try

            Try
                Dim salida As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigo).FirstOrDefault
                frmDocumentosSalida.tabla = EntitiToDataTable(ctx.sp_ReporteFactura1("", codigo, mdlPublicVars.idEmpresa))
                frmDocumentosSalida.reporteBase = Nothing
                frmDocumentosSalida.bitGenerico = False
                frmDocumentosSalida.bitImg = False
                frmDocumentosSalida.bitListaCombo = True
                frmDocumentosSalida.ListaCombo = "factura"

                frmDocumentosSalida.codigo = codigoCliente                    'codigo enviamos codigo del cliente
                frmDocumentosSalida.txtTitulo.Text = "Factura : " & salida.DocumentoFactura
                frmDocumentosSalida.Text = "Doc de Salida, Ventas"
                frmDocumentosSalida.bitCliente = True
                frmDocumentosSalida.codigoFactura = codigo ' enviamos el codigo de la factura
                permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try

    End Sub



    Private Sub fnReimprimir() Handles Me.panel1

        If fnErrores() = True Then
            Exit Sub
        End If

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdImpresiones)
        Dim bitImpreso As Boolean = True

        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim codigoImpresion As Integer
        Dim resultadoReporte = Nothing


        'crear la conexion
        Dim conection As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conection = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                codigoImpresion = Me.grdImpresiones.Rows(fila).Cells("codigo").Value

                Dim impresion As tblImpresion = (From x In conection.tblImpresions Where x.codigo = codigoImpresion Select x).FirstOrDefault

                'seleccionar una impresora
                'frmImpresoras.Text = "Impresoras"
                'frmImpresoras.ShowDialog()
                'frmImpresoras.Dispose()

                'asignar impresora default.
                'mdlPublicVars.fnImpresoraDefault(impresion.tblTipoImpresion.impresora)


                'elegir opcion.
                If impresion.tblTipoImpresion.bitGuia Then
                    resultadoReporte = conection.sp_reporteDeGuias(mdlPublicVars.idEmpresa, impresion.descripcion)
                ElseIf impresion.tblTipoImpresion.bitFactura Then
                    resultadoReporte = conection.sp_ReporteFactura1("", impresion.descripcion, mdlPublicVars.idEmpresa)
                ElseIf impresion.tblTipoImpresion.bitEstadoCuenta Then
                    resultadoReporte = conection.sp_reporteEstadoCuentaClientePicking("", impresion.cliente, mdlPublicVars.idEmpresa)
                End If


                Dim r As New clsReporte
                r.tabla = mdlPublicVars.EntitiToDataTable(resultadoReporte)
                r.nombreParametro = "@filtro"
                r.reporte = impresion.tblTipoImpresion.reporte
                r.parametro = ""
                r.imprimirReporte()

                If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    impresion.bitImpreso = True
                    impresion.usuarioImprime = mdlPublicVars.idUsuario
                    impresion.fechaImpresion = fechaServer
                    conection.SaveChanges()
                    bitImpreso = True
                End If


            Catch ex As Exception
            End Try
            conn.Close()
        End Using


        If bitImpreso = True Then
            fnLlenarDatos()
        End If

    End Sub


    Private Function fnErrores()

        If Me.grdImpresiones.Rows.Count > 0 Then
            '1ro. consulta el tipo de impresion.
            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdImpresiones)
            Dim codigoImpresion As Boolean = Me.grdImpresiones.Rows(index).Cells("codigo").Value


            'si bitError retorno false existen errores
            Dim bitError As Boolean = False
            Dim bitAnulado As Boolean = False


            'si bitSugerir Resolucion = verdadero abre el formulario.
            Dim bitSugerirResolucion As Boolean = False

            'crear la conexion
            Dim conection As New dsi_pos_demoEntities


            'abrir la conexion
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conection = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Try
                    Dim impresion As tblImpresion = (From x In conection.tblImpresions Where x.codigo = codigoImpresion Select x).FirstOrDefault
                    If impresion.tblTipoImpresion.bitFactura = True Then
                        Dim codigoFactura As String = Me.grdImpresiones.Rows(index).Cells("descripcion").Value

                        Dim factura As tblFactura = (From x In conection.tblFacturas Where x.IdFactura = codigoFactura Select x).FirstOrDefault
                        bitAnulado = factura.anulado

                        'si la factura no tiene resolucion 
                        If factura.idResolucion Is Nothing And factura.anulado = False Then
                            bitSugerirResolucion = True
                        Else
                            bitSugerirResolucion = False
                        End If
                    End If

                Catch ex As Exception
                End Try
                'cerrar la conexion
                conn.Close()

                'finalizar el proceso de conexion.
            End Using




            '1ro. verificar si la factura esta anulada, si esta anulada debe salir del proceso.
            If bitAnulado = True Then

                'salir del proceso.
                MessageBox.Show("Factura Anualda !!!", mdlPublicVars.nombreSistema)
                'returno que si existe un erorr
                Return True
            End If

            '2do. verificar si tiene asignada una resolucion, de no tener abrir el formulario.
            If bitSugerirResolucion = True Then

                MessageBox.Show("Debe verificar datos de impresion")

                'mostrar el formulario
                frmFacturaDescuento.codigo = codigo
                frmFacturaDescuento.Text = "Datos de Impresión"
                frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
                frmFacturaDescuento.ShowDialog()
                fnLlenarDatos()

                'retorna que si existen errores.
                Return True

            End If

        End If




        'retorna que no existen errores en la funcion.
        Return False


    End Function


  


End Class
