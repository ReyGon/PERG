﻿
Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Data.Metadata.Edm
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Telerik.WinControls
Imports System.Drawing.Printing


Public Module mdlPublicVars

    Dim clsForm As New elGuille.Util.clsFormulario

    Public frmPosX As Integer
    Public frmPosY As Integer
    Public frmX As Integer
    Public frmY As Integer

    Public coneccion As String
    Friend trial As Boolean
    Friend pideVuelto As Boolean

    Friend idVendedor As Short = 0
    Public idUsuario As Int16 = 0
    Public idEmpresa As Integer = 2

    Public usuario As String
    Public proyecto As String
    Public empresa As String
    Public idProyecto As Integer
    Public servidor As String
    Public bd As String
    Public cnn As String
    Public contraseña As String
    Public superSearchId As Int32
    Public superSearchConfirmado As Boolean
    Public superSearchNombre As String
    Public superSearchCodigo As String
    Public superSearchPrecio As Decimal
    Public superSearchCantidad As Double
    Public superSearchPromocion As Double
    Public superSearchCantidadPromocion As Double
    Public superSearchCuotaPromocion As Double
    Public superSearchFecha As DateTime
    Public superSearchCosto As Decimal
    Public superSearchUnidadMedidaValor As Decimal
    Public superSearchFechaString As String
    Public superSearchLista2 As List(Of Tuple(Of Integer, String))
    Public superSearchLista3 As List(Of Tuple(Of Integer, String, Decimal))
    Public superSearchIdUnidadMedida As Integer
    Public superSearchUnidadMedida As String
    Public superSearchIdDescuento As Integer
    Public superSearchValorDescuento As Decimal
    Public supersearchDescuentoPorcentaje As Boolean
    Public supersearchPagado As Boolean
    Public supersearchclientelibre As Boolean = False
    Public supergridview As RadGridView = Nothing

    Public superSearchSurtir As Integer
    Public superSearchCodSurtir As String
    Public superSearchFilasGrid As Integer
    Public superSearchInventario As Integer
    Public superSearchBodega As Integer
    Public superSearchEstado As Integer
    Public superSearchBitSurtir As String = "0"
    Public superSearchBitNuevo As String = "0"
    Public superSearchBitOferta As String = "0"
    Public superSearchCodigoSurtir As Integer = 0
    Public superSearchTipoPrecio As Integer
    Public supersearchUsuario As String
    Public superSearchClave As String
    Public superSearchIdUsuario As Integer
    Public superSearchEnvio As String
    Public superSearchGenerico1 As String
    Public superUsuario As Boolean = False
    Public filtro As String
    Public bitConecionSQL As Boolean = True
    Public bitConecionAccess As Boolean = False

    ''Variables para confirmacion de Transporte Datos
    Public superSearchTotalKms As Decimal
    Public superSearchCostoCombustible As Decimal
    Public superSearchTotalCombustible As Decimal
    Public superSearchTotalPlanilla As Decimal
    Public superSearchTotalCobro As Decimal
    Public superSearchGastosConfirmado As Boolean

    Public superSearchModelos As String
    Public superSearchMarcas As String
    Public superSearchTipos As String

    ' el nit pa la venta pequenia
    Public superSearchNit As String

    Public urlLicencia As String
    Public formatoNumero As String = "####0.00"
    Public formatoCantidad As String = "#####0"

    Public formatoPorcentaje As String = formatoNumero + " %"
    Public formatoFecha As String = "dd/MM/yyyy"
    Public MonedaSimbolo As String = "Q"
    Public MonedaSimboloDolar As String = "$"
    Public SimboloSuma As String = "Σ"
    Public SimboloRecuento As String = "#"
    Public formatoMoneda As String = MonedaSimbolo.ToString + " ###,##0.00"
    Public formatoMonedaDolar As String = MonedaSimboloDolar.ToString + "###,##0.00"

    Public formatoMoneda5dec As String = MonedaSimbolo.ToString + " ###,##0.00000"
    Public formatoNumeroGridTelerik As String = "{0: ###,###.#0}"
    Public formatoMonedaGridTelerik As String = "{0:" + MonedaSimbolo.ToString + "  ###,##0.00}"
    Public formatoMonedaDolarGridTelerik As String = "{0:" + MonedaSimboloDolar.ToString + "  ###,##0.00}"

    Public formatoFechaGridTeleric As String = "{0:dd/MM/yyyy}"
    Public formatoPorcentajeGridTelerik As String = "{0:#.#0%}"
    Public formatoPorcentajeGridTelerik2 As String = "{0:##0.00%}"

    'Punto de venta
    Public idCliente As Integer

    'modelo de entity framework
    Public ctx As dsi_pos_demoEntities
    Public entityBuilder As New EntityConnectionStringBuilder
    Public Const nombreModelo As String = "mdlModeloDatos"

    'Variables de configuracion
    Dim tbl As New clsDevuelveTabla

    'Variables de configuracion
    Public bitLicencia As Boolean = False
    Public ExistenciaCero As Boolean = False

    'Tabla de articulos
    Public tblArticulos As New DataTable

    Public MovVenta As String
    Public Ult5Costos As String
    Public MustraCod As String
    Public EditPrecioV As String
    Public PorcentajeDescV As String

    Public IdConceptoCP As String
    Public NoProductoF As String
    Public Mov As String
    Public CargoVisa As String
    Public GeneraRegBodega As String
    Public InventarioMin0 As String

    Public Salida_TipoMovimientoVenta As Integer = 0
    Public Notificacion_Reserva As Integer = 0
    Public Notificacion_CreditosVencidos As Integer = 0
    Public Notificacion_PendientesSurtir As Integer = 0
    Public Notificacion_ClientesNuevos As Integer = 0
    Public Notificacion_Clientes15Dias As Integer = 0
    Public Notificacion_Otro As Integer = 0
    Public ProveedorSucursal As String
    Public Salida_BitacoraAlCotizar As Boolean = False
    Public Salida_BitaraAlReservar As Boolean = False
    Public Salida_BitaAlDespachar As Boolean = False
    Public Salida_ReservaDias As Integer = 0
    Public Devolucion_Transporte As Integer = 0
    Public Devolucion_TransporteDaño As Integer = 0
    Public InventarioDañoDevolucion As Integer = 0
    Public Dias_Devolucion As Integer = 0

    Public Factura_CodigoMovimiento As Integer = 0
    Public Factura_UsaRegistroBodega As Boolean = False

    Public Bodega_CodigoPuestoBodegero As Integer = 0

    Public Entrada_CodigoMovimiento As Integer = 0
    Public Entrada_CodigoMovimientoImportacion As Integer = 0
    Public Entrada_CodigoMovimientoImportacionmotriza As Integer = 0
    Public Entrada_Flete As Boolean = False
    Public Entrada_numeroDecimales As String = ""

    Public Cliente_InventarioDevolucion As Integer = 0
    Public Cliente_DevolucionCodigoMovimiento As Integer = 0

    Public General_idAlmacenPrincipal As Integer = 0
    Public General_idTipoInventario As Integer = 0
    Public General_InventarioLiquidacion As Integer = 0
    Public General_IVA As Decimal = 0
    Public General_CodigoSalida As New DataTable
    Public General_NombreInventarioGeneral As String = ""
    Public General_TiempoNoComprado As Integer = 0
    Public General_CarpetaImagenes As String = ""
    Public General_CarpetaDocImpresion As String = ""
    Public General_NumeroProductosNuevos As Integer = 0
    Public General_NumeroDiasBitacoraProductos As Integer = 0
    Public General_CarpetaFotosVendedor As String = ""
    Public General_MunicipioLocal As Integer = 0
    Public General_HabilitaPV As Boolean = False
    Public General_HabilitaBanco As Boolean = False
    Public General_ImportanciaDefault As Integer = 0
    Public bitUnidadMedida_Activado As Boolean = False


    Public buscarArticulo_cantidadUltimasVentas As Integer = 0
    Public BuscarArticulo_CarpetaCatalogo As String = ""
    Public BuscarArticulo_CodigoOferta As Integer = 0
    Public Observacion As String

    Public Empresa_DiasUltimosProductos As Integer = 0
    Public Empresa_ValidaVenta As Boolean = False
    Public Empresa_MargenMonetario As Decimal = 0
    Public Empresa_OfertaMinimoDias As Integer = 0
    Public Empresa_PrecioEspecial As Integer = 0
    Public Empresa_PrecioNormal As Integer = 0
    Public Empresa_editaPreciosVentas As Boolean = False 'agregado

    'para precios de ultimas ventas
    Public Empresa_PrecioUltimasVentas As Integer = 0

    Public Empresa_Correo As String
    Public Empresa_CorreoClave As String
    Public Empresa_CorreoHost As String
    Public Empresa_CorreoPuerto As String

    Public CierreCaja_CodigoMovimiento As Integer = 0
    Public CierreCaja_Tolerancia As Decimal = 0

    Public Proveedor_DevolucionCodigoMovimiento As Integer = 0
    Public Proveedor_AjusteCodigoMovimiento As Integer = 0

    Public Ajuste_CodigoMovimiento As Short = 0

    Public Cheque_CodigoMovimieto As Integer = 0
    Public Debito_CodigoMovimiento As Integer = 0
    Public Credito_CodigoMovimiento As Integer = 0
    Public bitTransportePesado As Boolean = False
    Public bitEncomienda As Boolean = False
    Public CompraUltimoCosto As Boolean = False

    Public BancoCredito_CarpetaArchivos As String = ""

    Public Banco_CierreCaja As Integer = 0

    Public Pagos_codigoEfectivo As Integer = 0

    Public FrecuenciaCompra_MesesRango As Integer = 0
    Public FrecuenciaCompra_DiasMargen As Integer = 0


    Public nombreSistema As String = "POS PRIMSA 2.0"
    Public usuarioSistema As String = "sa"
    Public claveSistema As String = "Informatica"
    Dim alerta As New bl_Alertas

    Public BaseDatosNombre As String = ""

    'variables del punto de venta pequenio
    Public PuntoVentaPequeno_codigoMunicipio As Integer = 0   'Agregado para ventapequenia
    Public PuntoVentaPequeno_tipoPago As Integer = 0 'Agregado para ventapequenia Definimos Pago contado
    Public PuntoVentaPequeno_tipoNegocio As Integer = 0 '
    Public PuntoVentaPequeno_ClasificacionNegocio As Integer = 0 'Agregado para la venta pequenia
    Public PuntoVentaPequeno_bitMostrador As Boolean = False
    Public PuntoVentaPequeno_Activado As Boolean = False
    Public bitImprimirFacturaVentaPequenia As Boolean = False 'para imprimirfactura
    Public bitCrearFacturaVentaPequenia As Boolean = False
    Public listaDeFacturas As New List(Of Integer) ' par guardar las facturas creadas para imprimirlas
    Public superSearchCodigoPagoVentaPequenia As Int16
    Public bitVenta_Pequenia_Descuentos As Boolean
    Public bitVenta_Pequenia_Recargos As Boolean
    Public BusquedaVentaPequenia As Boolean
    Public PorcentajePrecio As Double

    ' Etiquetas dinamicas
    Public ProductoCombo1 As String
    Public ProductoCombo2 As String
    Public ProductoGrid1 As String
    Public ProductoGrid2 As String
    ' Fin de Etiquetas

    Public Produccion_CodigoMovimiento As Integer
    Public Produccion_Habilitado As Boolean
    Public UnidadMedidaDefault As Integer

    ''Validacion para Ventas Vencidas
    Public superSearchClaveVencidos As String = ""
    Public ClaveVencidos As String
    Public ClaveVencidosStatus As Boolean = False

    Public Activar_Impuestos As Boolean

    ' Venta Pequenia
    Public VentaPequenia_bitCaja As Integer = 0
    Public numeroDeItemsDeFactura As Integer = 0    'Numero de Items que tendera la factura fisica

    Public ServidorSucursal As String
    Public BDSucursal As String
    Public ClienteSucursal As Integer

    Public PagoPresupuestado As Integer = 1
    Public PagoProgramado As Integer = 2

    Public Sub SiempreEncima(ByVal handle As Integer)
        elGuille.Util.clsFormulario.WinAPI.SiempreEncima(handle)
        'SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, wFlags)
    End Sub


    Public Sub CargarVariablesdeConfiguracion()

        General_CodigoSalida.Columns.Clear()
        Dim Datos = (From x In ctx.tblConfiguracions Select x.id, x.valor).ToList
        'Variable para guardar cada linea de la consulta
        Dim config
        For Each config In Datos
            If config.id = 15 Then Bodega_CodigoPuestoBodegero = config.valor
            If config.id = 17 Then Salida_TipoMovimientoVenta = config.valor
            If config.id = 20 Then If config.valor.ToString = "1" Then Salida_BitacoraAlCotizar = True Else Salida_BitacoraAlCotizar = False
            If config.id = 21 Then If config.valor.ToString = "1" Then Salida_BitaraAlReservar = True Else Salida_BitaraAlReservar = False
            If config.id = 22 Then If config.valor.ToString = "1" Then Salida_BitaAlDespachar = True Else Salida_BitaAlDespachar = False
            If config.id = 25 Then Factura_CodigoMovimiento = config.valor
            If config.id = 32 Then If config.valor.ToString = "1" Then Factura_UsaRegistroBodega = True Else Factura_UsaRegistroBodega = False
            If config.id = 33 Then Entrada_CodigoMovimiento = config.valor
            If config.id = 34 Then General_CarpetaImagenes = Path.Combine(config.valor, CStr(mdlPublicVars.idEmpresa))
            If config.id = 35 Then buscarArticulo_cantidadUltimasVentas = config.valor
            If config.id = 36 Then BuscarArticulo_CarpetaCatalogo = Path.Combine(config.valor, CStr(mdlPublicVars.idEmpresa))
            If config.id = 37 Then Cliente_DevolucionCodigoMovimiento = config.valor
            If config.id = 38 Then Proveedor_DevolucionCodigoMovimiento = config.valor
            If config.id = 39 Then Proveedor_AjusteCodigoMovimiento = config.valor
            If config.id = 40 Then General_IVA = config.valor
            If config.id = 42 Then General_TiempoNoComprado = config.valor
            If config.id = 43 Then Ajuste_CodigoMovimiento = config.valor
            If config.id = 44 Then General_NumeroProductosNuevos = config.valor
            If config.id = 45 Then General_CarpetaDocImpresion = config.valor
            If config.id = 46 Then Empresa_PrecioNormal = config.valor
            If config.id = 48 Then Empresa_DiasUltimosProductos = config.valor
            If config.id = 49 Then General_NumeroDiasBitacoraProductos = config.valor
            If config.id = 50 Then General_CarpetaFotosVendedor = Path.Combine(config.valor, CStr(mdlPublicVars.idEmpresa))
            If config.id = 52 Then General_idTipoInventario = config.valor
            If config.id = 53 Then General_idAlmacenPrincipal = config.valor
            If config.id = 54 Then Salida_ReservaDias = config.valor
            If config.id = 55 Then Cliente_InventarioDevolucion = config.valor
            If config.id = 56 Then General_InventarioLiquidacion = config.valor
            If config.id = 57 Then Empresa_ValidaVenta = config.valor
            If config.id = 58 Then Empresa_MargenMonetario = config.valor
            If config.id = 60 Then Empresa_OfertaMinimoDias = config.valor
            If config.id = 61 Then Empresa_PrecioEspecial = config.valor
            If config.id = 63 Then BuscarArticulo_CodigoOferta = config.valor
            If config.id = 64 Then Empresa_Correo = config.valor
            If config.id = 65 Then Empresa_CorreoClave = config.valor
            If config.id = 66 Then Empresa_CorreoPuerto = config.valor
            If config.id = 67 Then Empresa_CorreoHost = config.valor
            If config.id = 68 Then CierreCaja_CodigoMovimiento = config.valor
            If config.id = 69 Then General_MunicipioLocal = config.valor
            If config.id = 70 Then
                For i As Integer = 1 To config.valor
                    Entrada_numeroDecimales += "0"
                Next
            End If
            If config.id = 71 Then General_HabilitaPV = config.valor
            If config.id = 72 Then General_HabilitaBanco = config.valor
            If config.id = 73 Then Cheque_CodigoMovimieto = config.valor
            If config.id = 74 Then Debito_CodigoMovimiento = config.valor
            If config.id = 75 Then Credito_CodigoMovimiento = config.valor
            If config.id = 76 Then BancoCredito_CarpetaArchivos = Path.Combine(config.valor, CStr(mdlPublicVars.idEmpresa))
            If config.id = 77 Then General_ImportanciaDefault = config.valor
            If config.id = 78 Then Pagos_codigoEfectivo = config.valor
            If config.id = 79 Then CierreCaja_Tolerancia = config.valor
            If config.id = 80 Then Banco_CierreCaja = config.valor

            If config.id = 81 Then PuntoVentaPequeno_codigoMunicipio = config.valor ' 1 Retalhuleu.
            If config.id = 82 Then PuntoVentaPequeno_tipoPago = config.valor ' 3 contado
            If config.id = 83 Then PuntoVentaPequeno_tipoNegocio = config.valor ' 1 local
            If config.id = 84 Then PuntoVentaPequeno_ClasificacionNegocio = config.valor ' 2 Normal
            If config.id = 85 Then PuntoVentaPequeno_Activado = config.valor ' 0 default

            'para el precio de ultimas ventas
            If config.id = 86 Then Empresa_PrecioUltimasVentas = config.valor
            If config.id = 87 Then numeroDeItemsDeFactura = config.valor ' 
            If config.id = 88 Then FrecuenciaCompra_MesesRango = config.valor
            If config.id = 89 Then FrecuenciaCompra_DiasMargen = config.valor
            If config.id = 90 Then ProductoCombo1 = config.valor
            If config.id = 91 Then ProductoCombo2 = config.valor
            If config.id = 92 Then ProductoGrid1 = config.valor
            If config.id = 93 Then ProductoGrid2 = config.valor
            If config.id = 94 Then Produccion_CodigoMovimiento = config.valor
            If config.id = 95 Then UnidadMedidaDefault = config.valor
            If config.id = 96 Then Activar_Impuestos = config.valor
            If config.id = 97 Then VentaPequenia_bitCaja = config.valor
            If config.id = 98 Then Produccion_Habilitado = config.valor
            If config.id = 99 Then bitTransportePesado = config.valor
            If config.id = 100 Then bitEncomienda = config.valor
            If config.id = 101 Then bitVenta_Pequenia_Descuentos = config.valor
            If config.id = 102 Then bitVenta_Pequenia_Recargos = config.valor
            If config.id = 103 Then bitUnidadMedida_Activado = config.valor
            If config.id = 104 Then Devolucion_Transporte = config.valor
            If config.id = 105 Then Devolucion_TransporteDaño = config.valor
            If config.id = 106 Then InventarioDañoDevolucion = config.valor
            If config.id = 107 Then Entrada_Flete = config.valor
            If config.id = 108 Then ExistenciaCero = config.valor
            If config.id = 109 Then Dias_Devolucion = config.valor
            If config.id = 110 Then PorcentajePrecio = config.valor
            If config.id = 111 Then BusquedaVentaPequenia = config.valor
            If config.id = 112 Then CompraUltimoCosto = config.valor
            If config.id = 113 Then Entrada_CodigoMovimientoImportacion = config.valor
            ''If config.id = 114 Then Entrada_CodigoMovimientoImportacionmotriza = config.valor
            If config.id = 114 Then ServidorSucursal = config.valor
            If config.id = 115 Then BDSucursal = config.valor
            If config.id = 116 Then ClienteSucursal = config.valor
            If config.id = 117 Then ProveedorSucursal = config.valor
            If config.id = 118 Then Notificacion_Reserva = config.valor
            If config.id = 119 Then Notificacion_CreditosVencidos = config.valor
            If config.id = 120 Then Notificacion_PendientesSurtir = config.valor
            If config.id = 121 Then Notificacion_ClientesNuevos = config.valor
            If config.id = 122 Then Notificacion_Clientes15Dias = config.valor
            If config.id = 123 Then Notificacion_Otro = config.valor
            If config.id = 124 Then ClaveVencidos = config.valor

        Next

        Dim codigoVendedor As Integer = (From x In ctx.tblUsuarios Where x.idUsuario = idUsuario Select x.idVendedor).FirstOrDefault
        idVendedor = codigoVendedor

        General_CodigoSalida.Columns.Add("Codigo")
        General_CodigoSalida.Columns.Add("Fecha")
        General_CodigoSalida.Columns.Add("Documento")
        General_CodigoSalida.Columns.Add("Vendedor")
        General_CodigoSalida.Columns.Add("Total")

        'Obtenemos el nombre del inventario principal
        Dim inv As tblTipoInventario = (From x In ctx.tblTipoInventarios.AsEnumerable
                                        Where x.idTipoinventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

        General_NombreInventarioGeneral = inv.nombre

    End Sub

    '---------------------------------------COPIAR PEGAS EN EL GRID VIEW. TELERIK
    Public Sub gridcopyPaste(ByVal sender As Object, ByVal e As KeyEventArgs)
        Try
            Dim grd As RadGridView = DirectCast(sender, RadGridView)

            If e.KeyCode = Keys.C AndAlso e.Shift Then
                mdlPublicVars.ConvertSelectedDataToString(grd, True)
                Dim al As New bl_Alertas
                al.contenido = "Seleccion Copiada..."
                al.fnErrorContenido()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'funcion que copia el contenido del grid todo/seleccion.
    Public Function ConvertSelectedDataToString(ByVal grid As RadGridView, ByVal seleccion As Boolean) As String
        Dim strBuild As New StringBuilder()

        'solo selecion
        If seleccion = True Then
            For row As Integer = 0 To grid.SelectedRows.Count - 1
                For cell As Integer = 0 To grid.SelectedRows(row).Cells.Count - 1
                    If grid.SelectedRows(row).Cells(cell).Value Is Nothing Then
                        strBuild.Append("")
                    Else
                        strBuild.Append(grid.SelectedRows(row).Cells(cell).Value.ToString())
                    End If
                    strBuild.Append(vbTab)
                Next

                strBuild.Append(vbLf)
            Next
        Else

            'copiar las columans
            Dim index As Integer
            For index = 0 To grid.Columns.Count - 1
                strBuild.Append(grid.Columns(index).HeaderText.ToString)
                strBuild.Append(vbTab)
            Next
            strBuild.Append(vbLf)

            'todo el contenido.
            For row As Integer = 0 To grid.Rows.Count - 1
                For cell As Integer = 0 To grid.Rows(row).Cells.Count - 1
                    If grid.Rows(row).Cells(cell).Value = Nothing Then
                        strBuild.Append("")
                    Else
                        strBuild.Append(grid.Rows(row).Cells(cell).Value.ToString())
                    End If
                    strBuild.Append(vbTab)
                Next
                strBuild.Append(vbLf)
            Next

        End If

        'copiar al clipboard o memoria.        
        Clipboard.SetDataObject(strBuild.ToString)

        Return strBuild.ToString()
    End Function


    Public Function conexionEntity()

        ' Specify the provider name, server and database.
        Dim providerName As String = "System.Data.SqlClient"
        Dim serverName As String = mdlPublicVars.servidor
        Dim databaseName As String = mdlPublicVars.bd

        ' Initialize the connection string builder for the
        ' underlying provider.
        Dim sqlBuilder As New SqlConnectionStringBuilder

        Try

            ' Set the properties for the data source.
            sqlBuilder.DataSource = serverName
            sqlBuilder.InitialCatalog = databaseName
            sqlBuilder.IntegratedSecurity = True
            sqlBuilder.UserID = mdlPublicVars.usuarioSistema
            sqlBuilder.Password = mdlPublicVars.claveSistema
            sqlBuilder.IntegratedSecurity = False
            sqlBuilder.MultipleActiveResultSets = True

            ' Build the SqlConnection connection string.
            Dim providerString As String = sqlBuilder.ToString

            ' Initialize the EntityConnectionStringBuilder.
            Dim entityBuilderx As New EntityConnectionStringBuilder

            'Set the provider name.
            entityBuilderx.Provider = providerName
            ' Set the provider-specific connection string.
            entityBuilderx.ProviderConnectionString = providerString
            ' Set the Metadata location to the current directory.
            entityBuilderx.Metadata = "res://*/" + nombreModelo.ToString + ".csdl|" & _
                                        "res://*/" + nombreModelo.ToString + ".ssdl|" & _
                                        "res://*/" + nombreModelo.ToString + ".msl"

            entityBuilder = entityBuilderx

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()

                ctx = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                'RadMessageBox.Show("No pudo abrir la conexion")
                conn.Close()
            End Using

        Catch ex As EntityException
            RadMessageBox.Show("Error Conexion Incorrecta, el sistema debe cerrarse !!! ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Application.Exit()
        End Try

        Return 0
    End Function

    Public Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label, ByVal txtFoco As TextBox, ByVal columna As Integer)
        Try
            Dim indice As Integer = grd.CurrentRow.Index
            Dim col As Integer = grd.CurrentColumn.Index
            If col = columna Then
            Else
                Exit Sub
            End If
            txtFoco.Focus()
            txtFoco.Select()
            Dim contador As Integer = 0
            Dim estado As Boolean
            For index As Integer = 0 To grd.Rows.Count - 1
                estado = grd.Rows(index).Cells(0).Value
                If estado = True Then
                    contador = contador + 1
                End If
            Next
            lbl.Text = contador.ToString
            grd.Rows(indice).Cells(0).IsSelected = True
        Catch ex As Exception
        End Try
    End Sub

    'esta funcion recibe un grid y la columna que retona como codigo cuando se ha seleccionado una fila.    
    Public Function fnGrid_codigoFilaSeleccionada(ByVal grd As Telerik.WinControls.UI.RadGridView) As Integer
        Dim ValorRetorno As Integer = Nothing
        Dim index
        If grd.Rows.Count = 0 Then
            Return ValorRetorno
        End If
        For index = 0 To grd.Rows.Count - 1
            If grd.Rows(index).IsSelected = True Then
                ValorRetorno = index
                Exit For
            End If
        Next
        Return ValorRetorno
    End Function

    Public Function fnFechaServidor()

        Dim fecha As String = ""
        mdlPublicVars.conexion()
        'Using contex As New mdlPaciente(mdlPublicVars.entityBuilder.ConnectionString)
        Dim sp = ctx.sp_herramientas
        For Each x As sp_herramientas_Result In sp
            fecha = x.Fecha
        Next
        'End Using

        Return fecha
    End Function

    Public Function fnFecha_horaServidor()
        Dim fecha As String = ""
        mdlPublicVars.conexion()
        'Using contex As New mdlPaciente(mdlPublicVars.entityBuilder.ConnectionString)
        Dim sp = ctx.sp_herramientas
        For Each x As sp_herramientas_Result In sp
            fecha = x.fecha_Hora
        Next
        'End Using

        fecha = tbl.fnQuitarPuntodeFecha(fecha)
        Return fecha
    End Function

    Public Function fnHoraServidor()
        Dim hora As String = ""
        mdlPublicVars.conexion()
        Dim sp = ctx.sp_herramientas
        For Each x As sp_herramientas_Result In sp
            hora = x.hora
        Next

        Return hora
    End Function

    Public Sub fnFormatoGridMovimientos(ByVal grd As Telerik.WinControls.UI.RadGridView)

        'grd.ThemeName = "BreezeExtendedTheme1"
        'ajustar columnas. auto size.
        grd.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        grd.EnableGrouping = False

        'Opciones de filtro.
        grd.EnableFiltering = True
        grd.MasterTemplate.ShowFilteringRow = True

        'Multi Selecteccion
        grd.MultiSelect = True


    End Sub

    Public Sub fnFormatoGridMovimientosAgrupado(ByVal grd As Telerik.WinControls.UI.RadGridView, agrupado As Boolean, filtro As Boolean)

        'grd.ThemeName = "BreezeExtendedTheme1"
        'ajustar columnas. auto size.
        grd.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        grd.EnableGrouping = agrupado

        'Opciones de filtro.
        grd.EnableFiltering = filtro
        grd.MasterTemplate.ShowFilteringRow = filtro

        'Multi Selecteccion
        ''grd.MultiSelect = True

    End Sub

    Public Function fnGrid_iconos(ByVal grd As Telerik.WinControls.UI.RadGridView)
        Try
            Dim index
            Dim col As String
            Dim iniciales As String

            For index = 0 To grd.Columns.Count - 1
                col = grd.Columns(index).name
                If col.Length > 3 Then
                    iniciales = tbl.tipoControl(col)

                    If iniciales = "txm" Or iniciales = "txb" Then
                        grd.Columns(index).HeaderText = col.Substring(3, col.Length - 3)
                    End If

                    If iniciales = "chm" Or iniciales = "chb" Then
                        grd.Columns(index).HeaderText = col.Substring(3, col.Length - 3)
                    End If

                    If iniciales = "chm" Or iniciales = "txm" Then
                        grd.Columns(index).HeaderImage = laFuente.My.Resources.Resources.edit20x20
                        grd.Columns(index).TextImageRelation = TextImageRelation.TextBeforeImage
                    End If

                    If iniciales = "chb" Or iniciales = "txb" Then
                        grd.Columns(index).HeaderImage = laFuente.My.Resources.Resources.search20x20
                        grd.Columns(index).TextImageRelation = TextImageRelation.TextBeforeImage
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error en Iconos de Listado " + ex.ToString)
        End Try

        Return False
    End Function

    Public Sub fnFormatoGridEspeciales(ByVal grd As Telerik.WinControls.UI.RadGridView)
        'ajustar columnas. auto size.
        grd.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        'grd.ThemeName = "BreezeExtendedTheme1"
        grd.AllowDeleteRow = True
        grd.EnableGrouping = False
        'Opciones de filtro.
        grd.EnableFiltering = False
        grd.MasterTemplate.ShowFilteringRow = False

        Dim index
        For index = 0 To grd.Columns.Count - 1
            If grd.Columns(index).Name.ToString.ToLower = "codigo" Then
                grd.Columns(index).Width = 100
            End If
        Next
    End Sub

    '******* FUNCIONES YOEL
    Public Sub llenarCombo(combo As ComboBox, datos As IQueryable, Optional ByVal id As String = "id", Optional ByVal valor As String = "valor")
        With combo
            .DataSource = Nothing
            .ValueMember = id
            .DisplayMember = valor
            .DataSource = datos
        End With
    End Sub

    '******* FIN DE FUNCIONES

    Public Sub comboActivarFiltro(ByVal cmb As ComboBox)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub comboActivarFiltroTelerik(ByVal cmb As RadDropDownList)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteDataSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub comboActivarListaTelerik(ByVal cmb As RadDropDownList)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteDataSource = AutoCompleteSource.ListItems

    End Sub

    Public Sub comboActivarFiltroLista(ByVal cmb As ComboBox)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteSource = AutoCompleteSource.ListItems
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub fnInicio()

        'crear columnas para la tabla de articulos.
        tblArticulos.Columns.Add("id")
        tblArticulos.Columns.Add("codigo")
        tblArticulos.Columns.Add("articulo")
        tblArticulos.Columns.Add("cantidad")
        tblArticulos.Columns.Add("precio")


    End Sub

    Public Function EntitiToDataTable(ByVal parIList As System.Collections.IEnumerable) As System.Data.DataTable

        Dim ret As New System.Data.DataTable()
        Try
            Dim ppi As System.Reflection.PropertyInfo() = Nothing
            If parIList Is Nothing Then Return ret
            Dim itm

            For Each itm In parIList
                If ppi Is Nothing Then

                    ppi = DirectCast(itm.[GetType](), System.Type).GetProperties()

                    For Each pi As System.Reflection.PropertyInfo In ppi

                        Dim colType As System.Type = pi.PropertyType
                        If (colType.IsGenericType) AndAlso
                           (colType.GetGenericTypeDefinition() Is GetType(System.Nullable(Of ))) Then colType = colType.GetGenericArguments()(0)
                        ret.Columns.Add(New System.Data.DataColumn(pi.Name, colType))
                    Next
                End If

                Dim dr As System.Data.DataRow = ret.NewRow

                For Each pi As System.Reflection.PropertyInfo In ppi
                    dr(pi.Name) = If(pi.GetValue(itm, Nothing) Is Nothing, DBNull.Value, pi.GetValue(itm, Nothing))
                Next
                ret.Rows.Add(dr)
            Next
            For Each c As System.Data.DataColumn In ret.Columns
                c.ColumnName = c.ColumnName.Replace("_", " ")
            Next
        Catch ex As Exception
            ret = New System.Data.DataTable()
        End Try
        Return ret
    End Function

    Public Sub fnLlenar_Articulos_Telerik(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal colChk As Integer)
        Dim index
        Dim fila() As String
        For index = 0 To grd.Rows.Count - 1
            If CType(grd.Rows(index).Cells(colChk).Value, Boolean) = True Then

                'agregar fila a la tabla
                '1= id,2= codigo, 3=nombre, 5= precio, 6= cantidad
                fila = {grd.Rows(index).Cells(1).Value, grd.Rows(index).Cells(2).Value, grd.Rows(index).Cells(3).Value, grd.Rows(index).Cells(5).Value, grd.Rows(index).Cells(6).Value}
                tblArticulos.Rows.Add(fila)

                'colocar el valor en falso
                grd.Rows(index).Cells(colChk).Value = False
            End If
        Next

    End Sub

    'Public Function configuracion(ByVal nombre As String) As String
    '    Dim tbl As New clsDevuelveTabla
    '    Dim valor As String
    '    tbl.sqlString = "select valor from tblConfiguracion where nombre = '" & nombre & "'"
    '    valor = tbl.Tabla.Rows(0).Item(0).ToString

    '    Return valor
    'End Function



    'utilizada en proyectos antiguos

    Public Sub conexion()
        If bitConecionSQL = True Then
            cnn = "server=" & servidor & ";database=" & bd & ";uid=" & usuarioSistema & ";password=" & claveSistema & ";connection timeout = 60000"
        ElseIf bitConecionAccess = True Then
            cnn = servidor.ToString + ";Data Source=" + bd.ToString
        End If

    End Sub

    Public Function fechaSQL(ByVal fecha As Date) As String
        Dim dia, mes As String
        If fecha.Day < 10 Then
            dia = "0" & fecha.Day
        Else
            dia = fecha.Day
        End If

        If fecha.Month < 10 Then
            mes = "0" & fecha.Month
        Else
            mes = fecha.Month
        End If

        Return "'" & fecha.Year & mes & dia & "'"
    End Function

    Public Sub limpiaCampos(ByRef frm As Form)

        Dim index
        Dim chkstate As CheckState = CheckState.Unchecked

        Dim ctl As New Control
        Dim nombre As String
        Dim txt As TextBox
        Dim cmb As ComboBox
        Dim chk As CheckBox
        Dim pnl As Panel
        Dim msk As MaskedTextBox
        Dim nm0 As NumericUpDown
        Dim lst As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView


        For Each ctl In frm.Controls
            nombre = ctl.Name
            If nombre <> "" Then


                If tipoControl(nombre) = "txt" Then
                    txt = ctl
                    txt.Text = ""

                ElseIf tipoControl(nombre) = "cmb" Then
                    cmb = ctl
                    cmb.Text = ""
                ElseIf tipoControl(nombre) = "chk" Then
                    chk = ctl
                    chk.Checked = False
                ElseIf tipoControl(nombre) = "pnl" Then
                    pnl = ctl
                    Call limpiaCamposPanel(pnl)
                ElseIf tipoControl(nombre) = "msk" Then
                    msk = ctl
                    msk.Text = ""
                ElseIf tipoControl(nombre) = "rpv" Then
                    limpiaCamposPaginas(ctl)
                ElseIf tipoControl(nombre) = "nm0" Or tipoControl(nombre) = "nm1" Or tipoControl(nombre) = "nm2" Or tipoControl(nombre) = "nm3" Or tipoControl(nombre) = "nm4" Or tipoControl(nombre) = "nm5" Then
                    nm0 = ctl
                    nm0.Value = 0
                ElseIf tipoControl(nombre) = "lst" Then
                    lst = ctl
                    For index = 0 To lst.Items.Count - 1
                        lst.SetItemCheckState(index, chkstate)
                    Next
                ElseIf tipoControl(nombre) = "grd" Then
                    grd = ctl
                    If grd.DataSource IsNot Nothing Then
                        grd.DataSource = Nothing
                    ElseIf grd.RowCount > 0 Then
                        grd.Rows.Clear()
                    End If

                End If

            End If

        Next
    End Sub

    Public Sub limpiaCamposPanel(ByRef pnl As Panel)
        Dim index
        Dim chkstate As CheckState = CheckState.Unchecked
        Dim lst As CheckedListBox

        Dim ctl As New Control
        Dim nombre As String
        Dim txt As TextBox
        Dim cmb As ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim nm0 As NumericUpDown
        Dim grd As Telerik.WinControls.UI.RadGridView

        For Each ctl In pnl.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                If tipoControl(nombre) = "txt" Then
                    txt = ctl
                    txt.Text = ""
                ElseIf tipoControl(nombre) = "cmb" Then
                    cmb = ctl
                    cmb.Text = ""
                ElseIf tipoControl(nombre) = "chk" Then
                    chk = ctl
                    chk.Checked = False
                ElseIf tipoControl(nombre) = "msk" Then
                    msk = ctl
                    msk.Text = ""
                ElseIf tipoControl(nombre) = "rpv" Then
                    limpiaCamposPaginas(ctl)
                ElseIf tipoControl(nombre) = "nm0" Or tipoControl(nombre) = "nm1" Or tipoControl(nombre) = "nm2" Or tipoControl(nombre) = "nm3" Or tipoControl(nombre) = "nm4" Or tipoControl(nombre) = "nm5" Then
                    nm0 = ctl
                    nm0.Value = 0
                ElseIf tipoControl(nombre) = "lst" Then
                    lst = ctl
                    For index = 0 To lst.Items.Count - 1
                        lst.SetItemCheckState(index, chkstate)
                    Next
                ElseIf tipoControl(nombre) = "grd" Then
                    grd = ctl
                    If grd.DataSource IsNot Nothing Then
                        grd.DataSource = Nothing
                    ElseIf grd.RowCount > 0 Then
                        grd.Rows.Clear()
                    End If

                End If
            End If

        Next
    End Sub

    Public Sub limpiaCamposPaginas(ByRef paginas As Telerik.WinControls.UI.RadPageView)
        Dim index
        Dim chkstate As CheckState = CheckState.Unchecked
        Dim lst As CheckedListBox

        Dim ctl As New Control
        Dim nombre As String
        Dim txt As TextBox
        Dim cmb As ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim nm0 As NumericUpDown
        Dim grd As Telerik.WinControls.UI.RadGridView

        Dim pagina
        For Each pagina In paginas.Pages
            For Each ctl In pagina.Controls

                nombre = ctl.Name
                If nombre <> "" Then
                    If tipoControl(nombre) = "txt" Then
                        txt = ctl
                        txt.Text = ""
                    ElseIf tipoControl(nombre) = "cmb" Then
                        cmb = ctl
                        cmb.Text = ""
                    ElseIf tipoControl(nombre) = "chk" Then
                        chk = ctl
                        chk.Checked = False
                    ElseIf tipoControl(nombre) = "msk" Then
                        msk = ctl
                        msk.Text = ""
                    ElseIf tipoControl(nombre) = "rpv" Then
                        limpiaCamposPaginas(ctl)
                    ElseIf tipoControl(nombre) = "nm0" Or tipoControl(nombre) = "nm1" Or tipoControl(nombre) = "nm2" Or tipoControl(nombre) = "nm3" Or tipoControl(nombre) = "nm4" Or tipoControl(nombre) = "nm5" Then
                        nm0 = ctl
                        nm0.Value = 0
                    ElseIf tipoControl(nombre) = "lst" Then
                        lst = ctl
                        For index = 0 To lst.Items.Count - 1
                            lst.SetItemCheckState(index, chkstate)
                        Next
                    ElseIf tipoControl(nombre) = "grd" Then
                        grd = ctl
                        If grd.DataSource IsNot Nothing Then
                            grd.DataSource = Nothing
                        ElseIf grd.RowCount > 0 Then
                            grd.Rows.Clear()
                        End If
                    End If
                End If

            Next
        Next

    End Sub

    Public Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function

    Public Function nombrecampo(ByVal nombre As String) As String
        Dim campo As String
        campo = nombre.Substring(3, nombre.Length - 3)
        Return campo
    End Function

    Public Function RevisaCampo(ByVal tabla As String, ByVal id As String, ByVal nombre As String, ByVal idValor As Int16, Optional ByVal filtro As String = "") As Boolean
        RevisaCampo = False
        Dim tbl As New clsDevuelveTabla
        Try
            If filtro = "" Then
                tbl.sqlString = "select " & id & "," & nombre & " from " & tabla & " where " & id & " = " & idValor
            Else
                tbl.sqlString = "select " & id & "," & nombre & " from " & tabla & " where " & id & " = " & idValor & " and " & filtro
            End If
            If tbl.Tabla.Rows.Count = 0 Then
                Return False
            Else
                superSearchNombre = tbl.Tabla.Rows(0).Item(1).ToString
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
            Return False
        End Try
    End Function

    Public Function Nz(ByVal valor As String) As Decimal
        Nz = 0
        If IsDBNull(valor) Or valor = "" Then
            Nz = 0
        Else
            Nz = CDec(valor)
        End If
    End Function

    Public Function CStr2(ByVal valor As Object) As String
        If IsDBNull(valor) Or valor Is Nothing Then
            Return ""
        Else
            Return CStr(valor)
        End If
    End Function

    'Hace disponible los valores de configuracion para toda la aplicacion
    Public Function configuracion() As Decimal

        Return 0

    End Function

    'articulo = 1

    'asigna colores a (griddatos,Red,1,0)

    Public Sub GridColor(ByRef grid As RadGridView, ByVal color As Color, ByVal tipo As String, ByVal columna As String)
        'tipo: es el valor que debe ser igual para que asigne el formato.
        Dim objeto As New ConditionalFormattingObject("MyCondition", ConditionTypes.Equal, tipo, "", False)

        objeto.CellForeColor = color
        grid.Columns(columna).ConditionalFormattingObjectList.Add(objeto)

    End Sub

    Public Sub GridColor_fila(ByVal fila As Integer, ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        If e.CellElement.RowIndex = fila Then
            e.CellElement.DrawFill = True
            e.CellElement.NumberOfColors = 1
            e.CellElement.BackColor = color
        End If
    End Sub

    Public Sub GridColor_TextoFila(ByVal fila As Integer, ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        If e.CellElement.RowIndex = fila Then
            e.CellElement.DrawFill = False
            e.CellElement.NumberOfColors = 1
            e.CellElement.ForeColor = color
        End If
    End Sub

    Public Sub GridColor_celda(ByVal fila As Integer, ByVal col As Integer, ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        If e.CellElement.RowIndex = fila And e.CellElement.ColumnIndex = col Then
            'e.CellElement.DrawFill = True
            e.CellElement.NumberOfColors = 1
            e.CellElement.BackColor = color
        End If
    End Sub

    Public Sub GridColor_fila(ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        'e.CellElement.DrawFill = True
        e.CellElement.NumberOfColors = 1
        e.CellElement.ForeColor = color
    End Sub

    Public Sub GridColor_fila(ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color, ByVal inicio As Integer)
        If e.ColumnIndex >= inicio And e.RowIndex >= 0 Then
            e.CellElement.DrawFill = False
            e.CellElement.NumberOfColors = 1
            e.CellElement.ForeColor = color
        End If
    End Sub

    Public Function fnGridTelerik_formatoMoneda(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        Try
            grd.Columns(nombre).FormatString = formatoMonedaGridTelerik
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

        Return 0
    End Function


    'Agregado para simbolos $
    Public Function fnGridTelerik_formatoMonedaDolar(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        Try
            grd.Columns(nombre).FormatString = formatoMonedaDolarGridTelerik
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
        Return 0
    End Function

    Public Function fnGridTelerik_formatoPorcentaje(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        grd.Columns(nombre).FormatString = formatoPorcentajeGridTelerik
        Return 0
    End Function

    Public Function fnGridTelerik_formatoPorcentaje2(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        grd.Columns(nombre).FormatString = formatoPorcentajeGridTelerik2
        Return 0
    End Function

    Public Function fnGridTelerik_formatoFecha(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        Try
            grd.Columns(nombre).FormatString = formatoFechaGridTeleric
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

        Return 0
    End Function

    Public Function fnFormulario_quitaBarraTitulo(ByVal frm As Telerik.WinControls.UI.RadForm)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.ControlBox = False
        Return False
    End Function

    Public Function fnFormulario_colocarBarraTitulo(ByVal frm As Telerik.WinControls.UI.RadForm)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.MaximizeBox = True
        frm.MinimizeBox = True
        frm.ControlBox = True
        Return False
    End Function

    Public Function tipoControlRango(ByVal nombre As String, ByVal inicio As Integer, ByVal fin As Integer) As String
        Dim acronimo As String
        acronimo = nombre.Substring(inicio, fin)
        Return acronimo
    End Function

    Public Sub fnSeleccionarDefault(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal codigoDef As Integer, ByVal seleccion As Boolean)
        If seleccion = True Then
            Dim index
            For index = 0 To grd.Rows.Count - 1
                If grd.Rows(index).Cells(0).Value = codigoDef Then
                    grd.MasterView.Rows(index).IsSelected = True
                    grd.MasterView.Rows(index).IsCurrent = True
                    grd.MasterView.Rows(index).EnsureVisible()
                    index = grd.Rows.Count
                End If
            Next
        End If
    End Sub

    'Funcion utilizada para verificar si el menu principal tiene hijos, de lo contrario mostramos el menu
    Public Sub fnMenu_Hijos(ByRef form As Form)
        Try
            form.Visible = False
            form.MdiParent = Nothing
            Dim contador As Integer = 0

            For Each hijo As Form In frmMenuPrincipal.MdiChildren
                If hijo.Visible = True And Not hijo.Name.Equals("frmMenu") Then
                    contador += 1
                End If
            Next
            If contador = 0 Then
                Dim frm As Form = frmMenu
                frm.Text = "MENU PRINCIPAL"
                frm.MdiParent = frmMenuPrincipal
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            End If
        Catch ex As Exception
        End Try

    End Sub

    'Funcion para establecer los indicadores
    Public Sub fnIndicadores(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal col As Integer)
        Try
            'Recorremos el grid para establecer los indicadores
            Dim i As Integer = 0
            For i = 0 To grd.RowCount - 1
                'Obtenemos las variables
                Dim tipo As String = grd.Rows(i).Cells("Pagos").Value
                Dim codSalida As Integer = grd.Rows(i).Cells("Codigo").Value
                Dim total As Decimal = grd.Rows(i).Cells("Total").Value
                Dim codClie As Integer = grd.Rows(i).Cells("Clave").Value
                Dim estado As Integer = 0
                Dim descripcion As String = ""

                'If nFac <> 0 Then
                'Analizamos si el pedido ya tiene guias
                Dim sl As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codSalida).FirstOrDefault

                If sl.despachar = False Then
                    estado = 0
                    descripcion = ""
                Else
                    Dim guias = (From x In ctx.tblEnvio_Salida
                                 Join z In ctx.tblSalidas On x.salida Equals z.idSalida Where z.idSalida = codSalida Select x).Count

                    If guias > 0 Then
                        'Si el documento ya tiene guias pues establecemos el estado como enviado, y lo ponemos color azul
                        estado = 2
                        descripcion = "Enviado"
                    Else
                        'Obtenemos la informacion del cliente
                        Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codClie Select x).FirstOrDefault

                        'Obtenemos el estado
                        Dim dEstado As String = grd.Rows(i).Cells("Estado").Value

                        If dEstado = "Anulado" Then
                            estado = 0
                            descripcion = ""
                        ElseIf tipo = "Contado" Then
                            'Si no tiene guias y fue al contado

                            'Obtenemos el saldo a favor del cliente que es igual al valor absoluto del saldo negativo - el saldo de la empresa
                            Dim saldoFavor As Decimal = cliente.saldo - mdlPublicVars.Empresa_MargenMonetario

                            'Obtenemos el saldo en transito del cliente
                            Dim saldoTransito As Decimal = cliente.pagosTransito + mdlPublicVars.Empresa_MargenMonetario

                            'Al saldo a favor le sumamos la venta 
                            Dim residuo As Decimal = saldoFavor + total

                            ' si da diferencia negativa es porque el cliente tiene saldo para pagar
                            If residuo <= 0 Then
                                estado = 4
                                descripcion = "Liberado"
                            Else
                                'Verificamos si el cliente tiene en saldo en transito para pagar la venta
                                Dim residuo2 = saldoTransito - total

                                If residuo2 > 0 Then
                                    'Si el cliente tiene saldo en transito para pagar
                                    estado = 5
                                    descripcion = "Pend.Confirmar"
                                Else
                                    'De lo contrario, el cliente no tiene ni saldo a favor, ni saldo en transito
                                    estado = 1
                                    descripcion = "No depositado"
                                End If
                            End If
                        ElseIf tipo = "Credito" Then
                            'Obtemos el saldo del cliente, el limite de credito, ademas le añadimos su sobregiro y por consecuente su saldo disponible
                            Dim saldoDisponible = (cliente.limiteCredito + (cliente.limiteCredito * (If(cliente.porcentajeCredito = 0, 0, cliente.porcentajeCredito / 100)))) - cliente.saldo

                            'Sacamos la diferencia entre el saldo disponible y el total de la venta
                            Dim residuo = saldoDisponible - total

                            'Si da un residuo positivo es porque el cliente tiene el suficiente credito para que se le venda
                            If residuo > 0 Then
                                estado = 4
                                descripcion = "Liberado"
                            Else
                                estado = 1
                                descripcion = "Sobregiro"
                            End If
                        End If
                    End If
                    'Else
                    'End If

                End If

                'Establecemos el estado y la descripcion
                grd.Rows(i).Cells(col).Value = estado
                grd.Rows(i).Cells("Descripcion").Value = descripcion
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para eliminar un registro en un grid
    Public Sub fnGrid_EliminarFila(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs, ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal columna As String)
        Dim f As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grd)


        Dim filas As Integer = -1

        For index As Integer = 0 To grd.Rows.Count - 1
            Dim elimina As Integer = CInt(grd.Rows(index).Cells("elimina").Value)
            If elimina = 0 Then
                filas += 1
            End If
        Next

        Dim detalle As Integer = 0
        If f >= 0 Then
            detalle = CInt(grd.Rows(f).Cells(columna).Value)
        End If

        If e.KeyCode = Keys.Delete And detalle > 0 Then
            grd.Rows(f).Cells("elimina").Value = 1
            grd.Rows(f).IsVisible = False

            If f >= 0 And f < filas Then
                grd.Rows(f + 1).IsCurrent = True
            ElseIf f = filas And f <> 0 Then
                grd.Rows(f - 1).IsCurrent = True
            End If
        ElseIf e.KeyCode = Keys.Delete And detalle = 0 Then
            grd.Rows.RemoveAt(f)
            If f >= 0 And f < filas Then
                grd.Rows(f).IsCurrent = True
            ElseIf f = filas And f <> 0 Then
                grd.Rows(f - 1).IsCurrent = True
            End If
        End If
    End Sub

    'Funcion utilizada para validar la clave del usuario activo
    Public Function fnAutorizaClave(ByVal clave As String) As Boolean
        Try
            'Obtenemos la clave del usuario
            Dim usuarioActivo As tblUsuario = (From x In ctx.tblUsuarios _
                                               Where x.idUsuario = mdlPublicVars.idUsuario _
                                               Select x).FirstOrDefault

            If clave.Equals(usuarioActivo.ClaveAccesos) Then
                Return True
            End If
        Catch ex As Exception
        End Try

        Return False
    End Function

    Public Function fnAutorizaClave2(ByVal clave As String, ByVal usuario As String) As Boolean
        Try

            Dim usuarioactivo As tblUsuario = (From x In ctx.tblUsuarios _
                                               Where RTrim(LTrim(x.nombre)) = RTrim(LTrim(usuario)) _
                                               Select x).FirstOrDefault

            Dim usuarioval As tblUsuario = (From x In ctx.tblUsuarios _
                                         Where x.idUsuario = usuarioactivo.idUsuario _
                                         Select x).FirstOrDefault

            If usuarioval.bitAutorizaPrecios = True Then

                If clave.Equals(usuarioval.ClaveAccesos) Then
                    Return True
                Else
                    RadMessageBox.Show("Clave de Acceso Incorrecta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Return False
                End If
            Else

                RadMessageBox.Show("El Usuario no Tiene Autorizacion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

            End If

        Catch ex As Exception

        End Try

        Return False
    End Function

    'Funcion utilizada para crear una carpeta en el sistema
    Public Sub fnCrearCarpeta(ByVal direccion As String)
        Try
            If direccion IsNot Nothing Then
                If direccion.Length > 0 Then
                    If Not Directory.Exists(direccion) Then
                        Directory.CreateDirectory(direccion)
                        Dim folder_info As IO.DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(direccion)
                        'folder_info.Attributes = IO.FileAttributes.Hidden
                    End If
                End If
            End If

        Catch ex As Exception
            alerta.contenido = "Ocurrio un error al intentar crear la carpeta: " & vbCrLf & direccion
            alerta.fnErrorContenido()
        End Try

    End Sub

    'Funcion utilizada para calcular el total de la tabla temporal
    Public Function fnTotalTablaFacturas() As Decimal
        'Recorremos la tabla
        Dim total As Decimal = 0

        For Each fila As DataRow In mdlPublicVars.General_CodigoSalida.Rows
            total += fila.Item("Total")
        Next

        Return total
    End Function


    '------------------------------------------------------------------------------------------------------------------------------
    '1. CREAR LA PRIMER FACTURA.
    '1.1 consultar el correlativo para la primer factura.
    '1.2 crear la primer factura.
    '1.3 actualizar el correaltivo de tbl correlativo.
    '1.4 crear el registro en tblsalidafactura.

    '2. RECORRER EL DETALLE DE LA SALIDA.

    '2.1 Contador es mayor a numero de items. 
    '2.1.1 consultar el correlativo para la factura dinamica.
    '2.1.2 crear otra factura.
    '2.1.3 actualizar el correlativo de tbl correlativo.
    '2.1.4 actualizar el montototal de factura anterior
    '2.1.5 asignar idfactura globla el nuevo idfactura.
    '2.1.6 guarda la nueva factura.
    '2.1.7 actualizar el idfactura en tblsalidadetalle.
    '2.1.8 guarda el registro en tblsalidafactura
    '2.1.9 si contador es igual a numero de items reiniciar el contador


    '2.2 Contador es menor o igual a numero de items.
    '2.2.1 Actualizar el idfactura en tblsalidaDetalle.
    '2.2.2 Si el recuento del detalle (longitud) es igual a contador del ciclo.
    '2.2.2.1 actualizar el total en factura con el idfactura global.

    '------------------------------------------------2.3 actualizar el idfactura en tblsalidadetalle

    '3. ACTUALIZACION DE SALDOS
    '3.1 obtener sumatoria de precios por cantidad cuando el idsalida sea igual al recibido por parametros, cuando no este anulado y kitsalidadetalle es null
    '3.2 consulta el cliente por medio de la salida.
    '3.3 actualizar el saldo del cliente.
    '3.4 guardar los cambios.

    '4. IMPRESION.
    '4.1 consulta tblsalidafactura cuando la salida sea igual a la recibida por paramero.
    '4.2 Agregamos al modulo de impresion los formatos de impresion del cliente factura y estadoCuenta.
    '4.3 Recorremos el listado de formatos de impresion
    '4.4 Agregamos a tblimpresionel listado de formatos de impresion del cliente asignandole el numero de factura del listado de salida_factura
    '4.5 Sin no tiene formato de imprsion crear uno por defecto y agregar este a tblimpresion
    '4.6 Agregar a lista de impresion las guias de tblenviosalida que tenga como idsalida el idsalida enviada como parametro

    'GUARDAR FACTURA
    Public Function GuardarFacturacion(ByVal idSalida As Integer) As Integer
        'variables para errores.

        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim fact As Integer = 0 'valor retorno

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Dim conteo As Integer = 0
            Dim saldo As Double = 0
            Dim longitud As Integer = 0 'variable que nos 

            Using transaction As New TransactionScope
                Try
                    'Variables para Guardar el numero de correlativo consultado...
                    ' Dim NoCorrelativo As Int64 = 0
                    '    Dim codigoFactura As Int64 = 0
                    Dim serie As String = ""
                    Dim contador As Integer = 0 ' contador que va a permitir insertar solo 15 detalles a la factura
                    Dim numeroDeItems As Integer = mdlPublicVars.numeroDeItemsDeFactura
                    Dim idFactura As Integer 'Variable que nos va a a permitir capturar el idfactura para insertar al detallesalida
                    Dim montoFactura As Double = 0.0
                    Dim descuentofactura As Double = 0.0

                    'Consultamos la salida para obtener los datos de la misma
                    Dim salida As tblSalida = (From z In conexion.tblSalidas Where z.idSalida = idSalida Select z).FirstOrDefault

                    salida.fechaDespachado = fecha
                    salida.fechaFiltro = fecha

                    'CREAMOS LA VARIABLE QUE PERMITA CONECTAR A LA TABLA FACTURA..
                    Dim NewFactura1 As New tblFactura
                    NewFactura1.Idusuario = mdlPublicVars.idUsuario
                    '  NewFactura1.Monto = totalFactura
                    NewFactura1.Fecha = fecha
                    NewFactura1.FechaTransaccion = fecha
                    NewFactura1.anulado = 0
                    'Guardamos el nuevo numero de Factura....
                    NewFactura1.DocumentoFactura = ""
                    NewFactura1.serieFactura = ""

                    NewFactura1.observacion = CStr2(salida.observacion)

                    'Si la factura fue al contado
                    If salida.contado Then
                        NewFactura1.contado = True
                        ' NewFactura1.saldo = totalFactura
                        NewFactura1.pagos = 0
                        NewFactura1.pagosTransito = 0
                        NewFactura1.pagado = 0
                        NewFactura1.credito = False
                    Else
                        NewFactura1.credito = True
                        NewFactura1.contado = False
                    End If

                    conexion.AddTotblFacturas(NewFactura1)
                    conexion.SaveChanges()

                    idFactura = NewFactura1.IdFactura

                    If mdlPublicVars.PuntoVentaPequeno_Activado Then
                        'agregamos al factura a la lista
                        listaDeFacturas.Add(idFactura)
                    End If


                    'Creamos el registro en tblsalida_factura
                    Dim sf As New tblSalida_Factura
                    sf.factura = idFactura
                    sf.salida = idSalida
                    conexion.AddTotblSalida_Factura(sf)
                    conexion.SaveChanges()


                    'catuparamos los detalles de la salida 
                    Dim detallesSalida As List(Of tblSalidaDetalle) = (From z In conexion.tblSalidaDetalles Where z.idSalida = idSalida Select
                                                                        z).ToList

                    Dim idSalidaDetalle As Integer = 0 'variable para reiniciar surtir
                    Dim idArticulo As Integer = 0
                    Dim detalle

                    'Inicia recorrido de los detalles de la salida
                    For Each detalle In detallesSalida
                        idArticulo = detalle.idArticulo 'capturamos el idarticulo para actualizar la fechaUltimaVenta
                        contador += 1
                        longitud += 1
                        idSalidaDetalle = detalle.idSalidaDetalle
                        If contador = numeroDeItems Then
                            contador = 1

                            'Creamos la factuar dinamica
                            Dim NewFactura2 As New tblFactura
                            NewFactura2.Idusuario = mdlPublicVars.idUsuario
                            NewFactura2.Fecha = fecha
                            NewFactura2.FechaTransaccion = fecha
                            NewFactura2.anulado = 0
                            NewFactura2.DocumentoFactura = ""
                            NewFactura2.serieFactura = ""
                            NewFactura2.observacion = salida.observacion

                            'Si la factura fue al contado
                            If salida.contado = True Then
                                NewFactura2.contado = True
                                NewFactura2.pagos = 0
                                NewFactura2.pagosTransito = 0
                                NewFactura2.pagado = 0
                                NewFactura2.credito = False
                            ElseIf salida.credito = True Then
                                NewFactura2.credito = True
                                NewFactura2.contado = False
                            End If

                            conexion.AddTotblFacturas(NewFactura2)
                            conexion.SaveChanges()

                            'Actualizamos el monto de la factura anterior 
                            Dim factura As tblFactura = (From f In conexion.tblFacturas Where f.IdFactura = idFactura Select f).FirstOrDefault
                            factura.Monto = montoFactura
                            factura.descuento = descuentofactura
                            conexion.SaveChanges()

                            'reiniciamos el montofactura
                            montoFactura = 0.0
                            descuentofactura = 0.0
                            idFactura = NewFactura2.IdFactura 'aisgmaos a la variable el nuevo idfactura creada

                            'si es venta pequenia agregamos la factura a la lista para imprimir
                            If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                                listaDeFacturas.Add(idFactura)
                            End If

                            'creamos el nuevo registro en tblsalida_factura
                            Dim sf2 As New tblSalida_Factura
                            sf2.salida = idSalida
                            sf2.factura = idFactura
                            conexion.AddTotblSalida_Factura(sf2)
                            conexion.SaveChanges()
                            montoFactura += (detalle.cantidad * detalle.precio) - (detalle.promocion * detalle.precio)
                            descuentofactura += (detalle.promocion * detalle.precio)

                            'creamos registro en tblsalidaDetalleFactura
                            Dim sdf2 As New tblSalidaDetalle_Factura
                            sdf2.idFactura = idFactura
                            sdf2.idSalidaDetalle = detalle.idSalidaDetalle

                            conexion.AddTotblSalidaDetalle_Factura(sdf2)
                            conexion.SaveChanges()

                            If detalle.anulado = False Then
                                'Actualizamos la fechaUltimacompraarticulo
                                Dim articulo As tblArticulo = (From a In conexion.tblArticuloes Where a.idArticulo = idArticulo Select a).FirstOrDefault
                                articulo.fechaUltimaVenta = fecha
                                conexion.SaveChanges()
                            End If
                        Else

                            'detalle.idFactura = idFactura
                            conexion.SaveChanges()

                            'sumar los que no esten anulados.
                            If detalle.anulado = False Then
                                montoFactura += (detalle.cantidad * detalle.precio) - (detalle.promocion * detalle.precio)
                                descuentofactura += (detalle.promocion * detalle.precio)

                                'Actualizamos la fechaUltimacompraarticulo
                                Dim articulo As tblArticulo = (From a In conexion.tblArticuloes Where a.idArticulo = idArticulo Select a).FirstOrDefault
                                articulo.fechaUltimaVenta = fecha
                                conexion.SaveChanges()

                                'Vamos a actualizar los pendientes de surtir y reiniciar a 0 
                                Dim surtir As tblSurtir = (From s In conexion.tblSurtirs Where s.articulo = idArticulo And s.cliente = salida.idCliente And s.fechaTransaccion < fecha _
                                    And s.salidaDetalle <> idSalidaDetalle Select s).FirstOrDefault
                                If surtir IsNot Nothing Then
                                    surtir.saldo = 0
                                    'surtir.cantidad = 0
                                    conexion.SaveChanges()
                                End If
                            Else
                                contador = contador - 1
                            End If

                            'Ingresamos el detallesalida y idFactura en tblsalidaDetalle_factura
                            Dim sdf As New tblSalidaDetalle_Factura
                            sdf.idFactura = idFactura
                            sdf.idSalidaDetalle = detalle.idSalidaDetalle

                            conexion.AddTotblSalidaDetalle_Factura(sdf)
                            conexion.SaveChanges()
                        End If

                        'si es el final del ciclo
                        If detallesSalida.Count = longitud Then
                            Dim factura As tblFactura = (From f In conexion.tblFacturas Where f.IdFactura = idFactura Select f).FirstOrDefault
                            factura.Monto = montoFactura
                            factura.descuento = descuentofactura
                            conexion.SaveChanges()

                        End If
                    Next

                    'Actualizamos la salida poniendo true a facturado
                    salida.facturado = True
                    salida.fechaFacturado = fecha
                    conexion.SaveChanges()

                    'Actualizacion de saldos
                    'Dim total As Double = (From sd In conexion.tblSalidaDetalles Where sd.idSalida = idSalida And sd.kitSalidaDetalle Is Nothing _
                    '     And sd.anulado = False Select sd.cantidad * sd.precio).Sum

                    'Actualizamos datos del cliente
                    Dim cliente As tblCliente = (From c In conexion.tblClientes Where c.idCliente = salida.idCliente Select c).FirstOrDefault
                    ''If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                    cliente.saldo += salida.total
                    ''End If
                    cliente.FechaUltimaCompra = fecha
                    conexion.SaveChanges()

                    Dim facturasAImprimir As List(Of tblSalida_Factura) = (From fi In conexion.tblSalida_Factura, sdf In conexion.tblSalidaDetalle_Factura Where fi.factura = sdf.idFactura And fi.salida = idSalida And sdf.tblSalidaDetalle.cantidad > 0 And sdf.tblSalidaDetalle.anulado = False And sdf.tblSalidaDetalle.kitSalidaDetalle.Equals(Nothing) Select fi).ToList

                    Dim factIm
                    Dim codigoFactura As Integer = 0

                    For Each factIm In facturasAImprimir
                        codigoFactura = factIm.factura

                        'Agregamos al modulo de impresion los formatos de impresion del cliente
                        Dim lFormatosImpresion As List(Of tblCliente_FacturaTipoImpresion) = (From x In conexion.tblCliente_FacturaTipoImpresion.AsEnumerable
                                                                                              Where x.cliente = salida.idCliente
                                                                                      Select x).ToList
                        'Recorremos el listado de formatos de impresion
                        For Each formatoImpresion As tblCliente_FacturaTipoImpresion In lFormatosImpresion

                            'Agregamos a la lista de impresion la factura
                            Dim impresion As New tblImpresion
                            impresion.bitImpreso = False
                            impresion.cliente = cliente.idCliente
                            impresion.descripcion = codigoFactura
                            impresion.fechaRegistro = fecha
                            impresion.usuarioRegistro = mdlPublicVars.idUsuario
                            impresion.url = ""


                            If formatoImpresion.tblTipoImpresion.bitFactura Then
                                impresion.descripcion = codigoFactura
                            ElseIf formatoImpresion.tblTipoImpresion.bitEstadoCuenta Then
                                ' impresion.descripcion = cli.idCliente
                                impresion.descripcion = codigoFactura
                            End If

                            impresion.tipoImpresion = formatoImpresion.tblTipoImpresion.codigo
                            conexion.AddTotblImpresions(impresion)
                            conexion.SaveChanges()
                        Next

                        'si no existe el formato se crea
                        Dim contadorFormatoFactura As Integer = (From x In conexion.tblImpresions Where x.descripcion = CType(codigoFactura, String) Select x).Count

                        If contadorFormatoFactura = 0 Then
                            'crear el formato default.
                            Dim tipoImpresionFactura As tblTipoImpresion = (From x In conexion.tblTipoImpresions Where x.bitFactura = True Order By x.codigo Ascending Select x).FirstOrDefault

                            'crear registro en tblimpresion.

                            'Agregamos a la lista de impresion la factura
                            Dim impresion As New tblImpresion
                            impresion.bitImpreso = False
                            impresion.cliente = cliente.idCliente
                            impresion.descripcion = codigoFactura
                            impresion.fechaRegistro = fecha
                            impresion.usuarioRegistro = mdlPublicVars.idUsuario
                            impresion.url = ""
                            impresion.tipoImpresion = tipoImpresionFactura.codigo
                            conexion.AddTotblImpresions(impresion)
                            conexion.SaveChanges()

                        End If
                    Next

                    Dim ListaGuias As List(Of tblEnvio_Salida) = (From es In conexion.tblEnvio_Salida Where es.salida = idSalida).ToList

                    For Each guia As tblEnvio_Salida In ListaGuias

                        Dim impresion As New tblImpresion
                        impresion.cliente = cliente.idCliente
                        impresion.tipoImpresion = guia.tblEnvio.tblEnvio_Empresa.tipoImpresion
                        impresion.descripcion = guia.envio
                        impresion.fechaRegistro = fecha
                        impresion.usuarioRegistro = mdlPublicVars.idUsuario
                        impresion.url = ""
                        impresion.bitImpreso = False

                        conexion.AddTotblImpresions(impresion)
                        conexion.SaveChanges()
                    Next

                    'completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                    MsgBox(ex.Message)
                    success = False
                    ' MsgBox(longitud)

                Catch ex As Exception
                    success = False
                    MsgBox(ex.Message)
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
                If mdlPublicVars.PuntoVentaPequeno_Activado Then

                Else
                    alerta.fnGuardar()
                End If


                'si es ventapequenia devolvemo true a imprimir factura
                If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                    ' Dim form As New frmVentaPequenia_2
                    ' Form.bitImprimirFactura = True
                    bitImprimirFacturaVentaPequenia = True
                End If

            Else
                Console.WriteLine("La operacion no pudo ser completada")
                fact = 0
            End If

            'liberar la conexion.
            conn.Close()
        End Using

        Return fact
    End Function


    'Funcion utilizada para no poder modificar el tamaño de un formulario
    Public Sub fnNoModificarTam(ByRef form As Form)
        form.MaximumSize = form.Size
        form.MinimumSize = form.Size
    End Sub

    'Funcion utilizada para activar todos los elementos de un grid
    Public Sub fnCheckbox_ActivaDesactivar(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal estado As Boolean)
        Try
            'Recorremos el grid
            For i As Integer = 0 To grd.Rows.Count - 1
                grd.Rows(i).Cells(0).Value = estado
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fnGrid_FormatoPrecios(sender As System.Object, e As Telerik.WinControls.UI.CellFormattingEventArgs, inicio As Integer)
        Try
            'Cambia el color de la fuente(letra) en el grid

            If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                mdlPublicVars.GridColor_fila(e, Color.Green)
            ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                mdlPublicVars.GridColor_fila(e, Color.Red)
            ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                mdlPublicVars.GridColor_fila(e, Color.Black)
            ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 3 Then
                mdlPublicVars.GridColor_fila(e, Color.Blue)
            ElseIf e.CellElement.RowInfo.Cells("ingresado").Value IsNot Nothing Then
                mdlPublicVars.GridColor_fila(e, Color.Yellow)
            End If

            '
            mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)

        Catch ex As Exception

        End Try
    End Sub

    'funcion para cerrar los formularios hijos del menu.
    Public Sub fnFRMhijos_cerrar(ByVal frm As Form)
        For i As Integer = 0 To frmMenuPrincipal.MdiChildren.Length - 1
            Dim frmHijo As Form = frmMenuPrincipal.MdiChildren(i)
            If frmHijo.Name = frm.Name Then
            Else
                frmHijo.Hide()
            End If
        Next
    End Sub

    'Contador del grid
    Public Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label, ByVal columna As String)
        Try
            lbl.Focus()

            Dim contador As Integer = 0
            Dim estado As Boolean
            For index As Integer = 0 To grd.Rows.Count - 1
                estado = grd.Rows(index).Cells(columna).Value
                If estado Then
                    contador = contador + 1
                End If
            Next
            lbl.Text = contador.ToString
            grd.Focus()
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    'Funcion utilizada para el manejo del checkbutton "Todos"
    Public Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal columna As String)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells(columna).Value = estado
        Next
    End Sub

    Public Function fnImpresoraDefault(ByVal nombre As String) As String

        If Len(LTrim(RTrim(nombre))) = 0 Then
            Return "Impresora no existe"
        End If

        Dim printDialog1 As New PrintDialog
        If printDialog1.PrinterSettings.PrinterName.ToString = nombre Then

        Else
            'Dim valor As String = "RUNDLL32 PRINTUI.DLL,PrintUIEntry /y /n " & nombre
            'Shell(valor)

            'Variable de referencia  
            Dim obj_Impresora As Object

            'Creamos la referencia  
            obj_Impresora = CreateObject("WScript.Network")
            obj_Impresora.setdefaultprinter(nombre)
            obj_Impresora = Nothing

        End If
        Return ""

    End Function

    Public Sub fnImpresorasSistema(cmb As ComboBox)
        Dim pd As New PrintDocument
        Dim Impresoras As String

        ' Default printer      
        Dim s_Default_Printer As String = pd.PrinterSettings.PrinterName

        ' recorre las impresoras instaladas  
        For Each Impresoras In PrinterSettings.InstalledPrinters
            cmb.Items.Add(Impresoras.ToString)
        Next
        ' selecciona la impresora predeterminada  
        cmb.Text = s_Default_Printer
    End Sub
End Module
