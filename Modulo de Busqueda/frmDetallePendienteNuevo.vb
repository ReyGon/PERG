Imports System.Linq
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports Telerik.WinControls.UI

Public Class frmDetallePendienteNuevo

#Region "Variables"

    Dim permiso As New clsPermisoUsuario
    Private _cliente As Integer
    Private _bitPendiente As Boolean
    Private _bitNuevo As Boolean
    Private _bitOferta As Boolean
    Private _bitPedir As Boolean
    Private _venta As Integer
    Private cargo As Boolean 'si el combo la tiene info
    Private _ventaPequenia As Integer

    Private _formSalida As frmSalidas
    Public frmRetornoSalidas As frmSalidas
    Private _formVentaPequenia As frmVentaPequenia 'Venta pequenia
    Public frmRetornoVentaPequenia As frmVentaPequenia

    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property

    Public Property formVentaPequenia As frmVentaPequenia
        Get
            formVentaPequenia = _formVentaPequenia
        End Get
        Set(value As frmVentaPequenia)
            _formVentaPequenia = value
        End Set
    End Property

    Public Property ventaPequenia As Integer
        Get
            ventaPequenia = _ventaPequenia
        End Get
        Set(value As Integer)
            _ventaPequenia = value
        End Set
    End Property

    Public Property cliente As Integer
        Get
            cliente = _cliente
        End Get
        Set(ByVal value As Integer)
            _cliente = value
        End Set
    End Property

    Public Property bitPendiente As Boolean
        Get
            bitPendiente = _bitPendiente
        End Get
        Set(ByVal value As Boolean)
            _bitPendiente = value
        End Set
    End Property

    Public Property bitNuevo As Boolean
        Get
            bitNuevo = _bitNuevo
        End Get
        Set(ByVal value As Boolean)
            _bitNuevo = value
        End Set
    End Property

    Public Property bitOferta As Boolean
        Get
            bitOferta = _bitOferta
        End Get
        Set(ByVal value As Boolean)
            _bitOferta = value
        End Set
    End Property

    Public Property venta As Integer
        Get
            venta = _venta
        End Get
        Set(ByVal value As Integer)
            _venta = value
        End Set
    End Property

    Public Property bitPedir As Boolean
        Get
            bitPedir = _bitPedir
        End Get
        Set(ByVal value As Boolean)
            _bitPedir = value
        End Set
    End Property

#End Region

#Region "LOAD"
    Private Sub frmDetallePendienteNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        mdlPublicVars.fnGrid_iconos(grdDatos)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        mdlPublicVars.fnGrid_iconos(grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos2)
        mdlPublicVars.fnGrid_iconos(grdDatos2)
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        lblGrid1.Text = ProductoGrid1
        If bitOferta Then
            'grdDatos.AutoSizeRows = True
        End If

        fnLLenarDatos()
        cargo = True

        ' cmbTiempoNoComprado.SelectedItem = 3
        ' fnLlenarGrid()

        fnConfigurarSumarios()

        Try
            mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblContador, "chmAgregar")
        Catch ex As Exception

        End Try

        If bitPendiente = True Then
            pgDatos2.Text = "Articulos con Existencia No Comprados"
        End If

    End Sub
#End Region

#Region "Funciones"

    'funcion que llena el combo y el gridtipovehicullo
    Private Sub fnLLenarDatos()

        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                'If bitCliente = True Or bitMovimientoInventario = True Then
                Me.grdTipoVehiculo.Rows.Clear()
                'tipo de vehiculo con grid
                Dim tp = (From x In conexion.tblArticuloTipoVehiculoes Order By x.nombre _
                         Select Agregar = If(((From y In conexion.tblCliente_clasificacionCompra _
                                    Where x.codigo = y.tipoVehiculo And y.idCliente = cliente _
                                    Select y.codigo).FirstOrDefault) > 0, True, False), _
                                    IdDetalle = (From y In conexion.tblCliente_clasificacionCompra _
                                    Where x.codigo = y.tipoVehiculo And y.idCliente = cliente _
                                    Select y.codigo).FirstOrDefault,
                                   Codigo = x.codigo, Nombre = x.nombre)

                Me.grdTipoVehiculo.Rows.Clear()
                Dim cont As Integer = 0
                Dim verd As Integer = 0
                Dim v
                For Each v In tp
                    cont += 1
                    Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
                    If v.AGREGAR = False Then
                        verd += 1
                    End If
                Next
                'End If

                Dim datos = (From x In conexion.tblListaFiltroFechas Where x.bitBusqueda = True Select x.orden, codigo = x.dias, x.nombre
                             Order By orden Ascending)

                With cmbTiempoNoComprado
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = datos
                End With

                conn.Close()
            End Using

        Catch ex As Exception

        End Try

    End Sub

    'funcion para contar las filas del grid
    Private Sub fnConfigurarSumarios()
        Try

            'Activar barra de totales y crear operaciones.
            grdDatos.MasterTemplate.ShowTotals = True

            grdDatos2.MasterTemplate.ShowTotals = True

            Dim SCodigo As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)

            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {SCodigo})

            'agregar summario arreglo a grid
            grdDatos.SummaryRowsTop.Add(summaryRowItem)
            grdDatos2.SummaryRowsTop.Add(summaryRowItem)


        Catch ex As Exception

        End Try

    End Sub


    'Funcion utilizada para llenar el grid
    Private Sub fnLlenarGrid()

        Try
            Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
            Dim diferenciaMes As DateTime = fechaActual.AddDays(-mdlPublicVars.Empresa_DiasUltimosProductos)

            Dim fechaFiltro As DateTime = fechaActual.AddDays(-cmbTiempoNoComprado.SelectedValue)
            ''Dim fechaBusqueda As String = Format(fechaFiltro, "dd/MM/yyyy hh:mm:ss")

            Dim fechauso As DateTime = DateAdd(DateInterval.Month, -1, Today())
            Dim fechabusqueda As String = Format(fechauso, "dd/MM/yyyy hh:mm:ss")

            Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                If bitPendiente Then
                    grdDatos.DataSource = Nothing
                    Dim consulta = conexion.sp_PendientesPorSurtir(mdlPublicVars.idEmpresa, fechaBusqueda.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 1, True, False, "", venta)
                    grdDatos.DataSource = consulta ' EntitiToDataTable(consulta)

                    grdDatos2.DataSource = Nothing
                    Dim consulta2 = conexion.sp_PendientesPorSurtir(mdlPublicVars.idEmpresa, fechaBusqueda.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 2, True, False, "", venta)

                    grdDatos2.DataSource = consulta2

                ElseIf bitNuevo Then

                    Me.grdDatos.DataSource = Nothing

                    Dim cons = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fechaBusqueda.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 4, True, False, "", venta)
                    grdDatos.DataSource = mdlPublicVars.EntitiToDataTable(cons)

                    Me.grdDatos2.DataSource = Nothing
                    'nuevos no comprados
                    Dim cons2 = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fechaBusqueda.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 9, True, False, "", venta)
                    grdDatos2.DataSource = mdlPublicVars.EntitiToDataTable(cons2)


                ElseIf bitOferta Then
                    Me.grdDatos.DataSource = Nothing

                    Dim prom As Boolean = (From x In conexion.tblClientes Where x.idCliente = cliente Select x.bitPromociones).FirstOrDefault

                    Dim ofertas

                    If prom = True Then
                        ofertas = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, "", mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 12, True, False, "", venta)
                    Else
                        ofertas = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fechabusqueda.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 12, True, False, "", venta)
                    End If

                    grdDatos.DataSource = ofertas

                    ''Dim ofertas2 = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fechabusqueda.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", cliente, 12, True, False, "", venta)
                    ''grdDatos2.DataSource = ofertas2

                ElseIf bitPedir Then

                    Dim pendientes = (From x In conexion.tblPendientePorPedirs Where x.cliente = cliente And x.saldo > 0 And Not x.anulado _
                                     Select codigo = x.codigo, Fecha = x.fechaRegistro, Articulo = x.descripcion, Importancia = x.tblArticuloImportancia.nombre,
                                     Saldo = x.saldo, Creado = x.bitCreado)

                    grdDatos.DataSource = pendientes
                End If

                conn.Close()
            End Using

        Catch ex As Exception

            MessageBox.Show("Error")
        End Try

        fnConfiguracion()

    End Sub

    'Funcion utilizada para configurar el grid
    Private Sub fnConfiguracion()
        Try
            If bitPendiente Then

                If Me.grdDatos.ColumnCount > 1 Then
                    grdDatos.Columns(1).IsVisible = False 'id
                    grdDatos.Columns(13).IsVisible = False 'observacion
                    grdDatos.Columns(14).IsVisible = False 'empaque
                    grdDatos.Columns("clrEstado").IsVisible = False 'clrEstado
                    grdDatos.Columns(17).IsVisible = False 'numero de articulo en catalogo
                    grdDatos.Columns(18).IsVisible = False 'fecha ultima compra
                    grdDatos.Columns(19).IsVisible = False 'marca
                    grdDatos.Columns(20).IsVisible = False 'bitVentaMaxima
                    grdDatos.Columns(21).IsVisible = False 'minimo
                    grdDatos.Columns("TipoPrecio").IsVisible = False 'minimo
                    grdDatos.Columns("Compatibilidad").IsVisible = False ' compatibilidad

                    grdDatos.Columns("numeroArt").IsVisible = False

                    ' grdDatos.Columns("codSurtir").IsVisible = False 'codSurtir

                    grdDatos.Columns("txmSurtir").IsVisible = False 'codSurtir
                    grdDatos.Columns("CantidadMax").IsVisible = False
                    grdDatos.Columns("UbicacionEstanteria").IsVisible = False
                    grdDatos.Columns("Observacion").IsVisible = False
                    grdDatos.Columns("UnidadEmpaque").IsVisible = False
                    grdDatos.Columns("CodigoSurtir").IsVisible = False
                    grdDatos.Columns("chmEliminar").IsVisible = True

                    ' mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                    grdDatos.Columns(0).Width = 60 ' id
                    grdDatos.Columns(2).Width = 40 ' codigo
                    grdDatos.Columns(3).Width = 250 ' nombre
                    grdDatos.Columns(4).Width = 70 'saldo
                    grdDatos.Columns(5).Width = 70 ' cantidad
                    grdDatos.Columns(6).Width = 50 ' existencia
                    grdDatos.Columns(7).Width = 70 ' reserva
                    grdDatos.Columns(8).Width = 70 ' transito
                    grdDatos.Columns(9).Width = 50 ' costo
                    grdDatos.Columns(10).Width = 70 ' precio
                    grdDatos.Columns(11).Width = 50 ' cantidadmax
                    grdDatos.Columns("Fecha").Width = 50 ' cantidadmax

                    ' grdDatos.Columns(14).Width = 60 'unidadempaque
                    mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "txbPrecio")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "txmCosto")
                    mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")

                    grdDatos.Columns("txmCosto").IsVisible = False
                    grdDatos.Columns("txbPrecio").IsVisible = True
                    grdDatos.Columns("Transito").IsVisible = False
                    'grdDatos.Columns("txmCantidad").IsVisible = True

                    grdDatos.Columns("txbPrecio").HeaderText = "Precio"
                    grdDatos.Columns("CantidadMax").HeaderText = "Cant. Max"


                End If

                'configurar el grid2
                If Me.grdDatos2.ColumnCount > 1 Then
                    grdDatos2.Columns(1).IsVisible = False 'id
                    grdDatos2.Columns(13).IsVisible = False 'observacion
                    grdDatos2.Columns(14).IsVisible = False 'empaque
                    grdDatos2.Columns(16).IsVisible = False 'clrEstado
                    grdDatos2.Columns(17).IsVisible = False 'numero de articulo en catalogo
                    grdDatos2.Columns(18).IsVisible = False 'fecha ultima compra
                    grdDatos2.Columns(19).IsVisible = False 'marca
                    grdDatos2.Columns(20).IsVisible = False 'bitVentaMaxima
                    grdDatos2.Columns(21).IsVisible = False 'minimo
                    grdDatos2.Columns("TipoPrecio").IsVisible = False 'minimo
                    grdDatos2.Columns("Compatibilidad").IsVisible = False ' compatibilidad

                    ' grdDatos.Columns("codSurtir").IsVisible = False 'codSurtir

                    grdDatos2.Columns("numeroArt").IsVisible = False

                    grdDatos2.Columns("txmSurtir").IsVisible = False 'codSurtir
                    grdDatos2.Columns("CantidadMax").IsVisible = False
                    grdDatos2.Columns("UbicacionEstanteria").IsVisible = False
                    grdDatos2.Columns("Observacion").IsVisible = False
                    grdDatos2.Columns("UnidadEmpaque").IsVisible = False
                    grdDatos2.Columns("CodigoSurtir").IsVisible = False

                    grdDatos2.Columns(0).Width = 60 ' agregar
                    grdDatos2.Columns(2).Width = 40 ' id
                    grdDatos2.Columns(3).Width = 250 ' nombre
                    grdDatos2.Columns(4).Width = 70 ' cantidad
                    grdDatos2.Columns(5).Width = 70 ' saldo
                    grdDatos2.Columns(6).Width = 70 ' existencia
                    grdDatos2.Columns(7).Width = 70 ' reserva
                    grdDatos2.Columns(8).Width = 70 ' transito
                    grdDatos2.Columns(9).Width = 50 ' costo
                    grdDatos2.Columns(10).Width = 70 ' precio
                    grdDatos2.Columns(11).Width = 70 ' cantidadmax
                    grdDatos2.Columns(12).Width = 50 ' observacion
                    grdDatos2.Columns(13).Width = 60 'unidadempaque
                    grdDatos2.Columns(14).Width = 70 'surtir
                    grdDatos2.Columns(15).Width = 70 'surtir
                    grdDatos2.Columns("Fecha").Width = 75 'surtir

                    mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos2, "txbPrecio")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos2, "txmCosto")
                    mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos2, "Fecha")

                    grdDatos2.Columns("txmCosto").IsVisible = False
                    grdDatos2.Columns("txbPrecio").IsVisible = True
                    grdDatos2.Columns("Transito").IsVisible = False
                    'grdDatos2.Columns("txmCantidad").IsVisible = False
                    grdDatos2.Columns("txbPrecio").HeaderText = "Precio"

                End If




            ElseIf bitNuevo Then
                If Me.grdDatos.ColumnCount > 1 Then
                    Me.grdDatos.Columns("id").IsVisible = False 'id
                    ' Me.grdDatos.Columns("Saldo").IsVisible = False 'saldo
                    ' Me.grdDatos.Columns("Observacion").IsVisible = True 'observacion
                    ' Me.grdDatos.Columns("UnidadEmpaque").IsVisible = False 'empaque
                    Me.grdDatos.Columns("clrEstado").IsVisible = False 'clrEstado
                    Me.grdDatos.Columns("numeroArt").IsVisible = False 'numero de articulo en catalogo
                    Me.grdDatos.Columns("UltimaCompra").IsVisible = False 'fecha ultima compra
                    ' Me.grdDatos.Columns("Marca").IsVisible = True 'marca

                    Me.grdDatos.Columns("bitVentaMaxima").IsVisible = False 'bitVentaMaxima
                    Me.grdDatos.Columns("minimo").IsVisible = False 'minimo
                    grdDatos.Columns("TipoPrecio").IsVisible = False 'minimo
                    grdDatos.Columns("Compatibilidad").IsVisible = False 'compatibilidad
                    grdDatos.Columns("txmSurtir").IsVisible = False 'codSurtir
                    grdDatos.Columns("UbicacionEstanteria").IsVisible = False
                    grdDatos.Columns("CantidadMax").IsVisible = False
                    grdDatos.Columns("Observacion").IsVisible = False
                    grdDatos.Columns("UnidadEmpaque").IsVisible = False
                    grdDatos.Columns("Marca").IsVisible = False

                    Me.grdDatos.Columns(1).Width = 60 ' agregar
                    Me.grdDatos.Columns(2).Width = 40 ' codigo
                    Me.grdDatos.Columns(3).Width = 250 ' nombre
                    Me.grdDatos.Columns(3).Width = 70 ' cantidad
                    Me.grdDatos.Columns(4).Width = 50 ' existencia
                    Me.grdDatos.Columns(5).Width = 50 ' reserva
                    Me.grdDatos.Columns(6).Width = 70 ' transito
                    Me.grdDatos.Columns(7).Width = 50 ' costo
                    Me.grdDatos.Columns(8).Width = 70 ' precio
                    Me.grdDatos.Columns(9).Width = 50 ' cantidadmax
                    Me.grdDatos.Columns(10).Width = 50 ' observacion
                    Me.grdDatos.Columns(11).Width = 60 'unidadempaque
                    Me.grdDatos.Columns(12).Width = 60 'unidadempaque
                    Me.grdDatos.Columns(13).Width = 60 'unidadempaque
                    'Me.grdDatos.Columns(13).Width = 70 'surtir

                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "txbPrecio")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "txmCosto")

                    Me.grdDatos.Columns("txmCosto").IsVisible = False
                    Me.grdDatos.Columns("txbPrecio").IsVisible = True
                    Me.grdDatos.Columns("Transito").IsVisible = False
                    'Me.grdDatos.Columns("txmCantidad").IsVisible = False
                    'Me.grdDatos.Columns("Fecha").IsVisible = False

                    grdDatos.Columns("txbPrecio").HeaderText = "Precio"
                    grdDatos.Columns("CantidadMax").HeaderText = "Cant. Max"

                End If

                If Me.grdDatos2.ColumnCount > 1 Then
                    Me.grdDatos2.Columns("id").IsVisible = False 'id
                    ' Me.grdDatos2.Columns("Saldo").IsVisible = False 'saldo
                    ' Me.grdDatos2.Columns("Observacion").IsVisible = True 'observacion
                    ' Me.grdDatos2.Columns("UnidadEmpaque").IsVisible = False 'empaque
                    Me.grdDatos2.Columns("clrEstado").IsVisible = False 'clrEstado
                    Me.grdDatos2.Columns("numeroArt").IsVisible = False 'numero de articulo en catalogo
                    Me.grdDatos2.Columns("UltimaCompra").IsVisible = False 'fecha ultima compra


                    Me.grdDatos2.Columns("bitVentaMaxima").IsVisible = False 'bitVentaMaxima
                    Me.grdDatos2.Columns("minimo").IsVisible = False 'minimo
                    Me.grdDatos2.Columns("TipoPrecio").IsVisible = False 'minimo
                    Me.grdDatos2.Columns("txmSurtir").IsVisible = False 'codSurtir
                    Me.grdDatos2.Columns("UbicacionEstanteria").IsVisible = False
                    Me.grdDatos2.Columns("CantidadMax").IsVisible = False
                    Me.grdDatos2.Columns("Observacion").IsVisible = False
                    Me.grdDatos2.Columns("UnidadEmpaque").IsVisible = False
                    Me.grdDatos2.Columns("Marca").IsVisible = False
                    Me.grdDatos2.Columns("Compatibilidad").IsVisible = False 'compatibilidad


                    Me.grdDatos2.Columns(1).Width = 60 ' agregar
                    Me.grdDatos2.Columns(2).Width = 40 ' codigo
                    Me.grdDatos2.Columns(3).Width = 250 ' nombre
                    Me.grdDatos2.Columns(4).Width = 70 ' cantidad
                    Me.grdDatos2.Columns(5).Width = 45 ' existencia
                    Me.grdDatos2.Columns(6).Width = 45 ' reserva
                    Me.grdDatos2.Columns(7).Width = 70 ' transito
                    Me.grdDatos2.Columns(8).Width = 50 ' costo
                    Me.grdDatos2.Columns(9).Width = 70 ' precio
                    Me.grdDatos2.Columns(10).Width = 50 ' cantidadmax
                    Me.grdDatos2.Columns(11).Width = 50 ' observacion
                    Me.grdDatos2.Columns(12).Width = 60 'unidadempaque
                    'Me.grdDatos2.Columns(13).Width = 70 'surtir

                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos2, "txbPrecio")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos2, "txmCosto")

                    Me.grdDatos2.Columns("txmCosto").IsVisible = False
                    Me.grdDatos2.Columns("txbPrecio").IsVisible = True
                    Me.grdDatos2.Columns("Transito").IsVisible = False
                    'Me.grdDatos2.Columns("txmCantidad").IsVisible = False
                    Me.grdDatos2.Columns("txbPrecio").HeaderText = "Precio"
                    Me.grdDatos2.Columns("CantidadMax").HeaderText = "Cant. Max"


                End If


            ElseIf bitOferta Then
                
                ' mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
                ' grdDatos.Columns("Fecha").Width = 50
                '  grdDatos.Columns("Articulo").Width = 120
                'grdDatos.Columns("Observacion").Width = 170
                ' grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns("id").IsVisible = False
                '  Me.grdDatos.Columns("Saldo").IsVisible = False 'id

                Me.grdDatos.Columns(11).IsVisible = False 'observacion
                Me.grdDatos.Columns(12).IsVisible = False 'empaque
                Me.grdDatos.Columns(14).IsVisible = False 'clrEstado
                Me.grdDatos.Columns(15).IsVisible = False 'numero de articulo en catalogo
                Me.grdDatos.Columns(16).IsVisible = False 'fecha ultima compra
                Me.grdDatos.Columns(17).IsVisible = False 'marca
                Me.grdDatos.Columns(18).IsVisible = False 'bitVentaMaxima
                Me.grdDatos.Columns(19).IsVisible = False 'minimo
                Me.grdDatos.Columns("TipoPrecio").IsVisible = False 'minimo
                Me.grdDatos.Columns("Compatibilidad").IsVisible = False 'compatibilidad
                Me.grdDatos.Columns("txmSurtir").IsVisible = False 'codSurtir
                Me.grdDatos.Columns("UbicacionEstanteria").IsVisible = False
                grdDatos.Columns("UbicacionEstanteria").IsVisible = False
                grdDatos.Columns("CantidadMax").IsVisible = False
                grdDatos.Columns("Observacion").IsVisible = False
                grdDatos.Columns("UnidadEmpaque").IsVisible = False
                grdDatos.Columns("Marca").IsVisible = False

                Me.grdDatos.Columns(2).Width = 40 ' codigo
                Me.grdDatos.Columns(3).Width = 250 ' nombre
                Me.grdDatos.Columns(4).Width = 70 ' cantidad
                Me.grdDatos.Columns(5).Width = 70 ' existencia
                Me.grdDatos.Columns(6).Width = 70 ' reserva
                Me.grdDatos.Columns(7).Width = 70 ' transito
                Me.grdDatos.Columns(8).Width = 50 ' costo
                Me.grdDatos.Columns(9).Width = 70 ' precio
                Me.grdDatos.Columns(10).Width = 70 ' cantidadmax
                Me.grdDatos.Columns(11).Width = 50 ' observacion
                Me.grdDatos.Columns(12).Width = 60 'unidadempaque
                Me.grdDatos.Columns(13).Width = 70 'surtir
                Me.grdDatos.Columns(14).Width = 70 'surtir
                Me.grdDatos.Columns(23).Width = 60
                Me.grdDatos.Columns(24).Width = 60


                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "txbPrecio")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "txmCosto")

                Me.grdDatos.Columns("txmCosto").IsVisible = False
                Me.grdDatos.Columns("txbPrecio").IsVisible = True
                Me.grdDatos.Columns("Transito").IsVisible = False
                'Me.grdDatos.Columns("txmCantidad").IsVisible = False
                'Me.grdDatos.Columns("Fecha").IsVisible = False
                Me.grdDatos.Columns("txbPrecio").HeaderText = "Precio"

                ' '' ''configurar el grid2
                '' ''Me.grdDatos2.Columns("id").IsVisible = False
                ' '' '' Me.grdDatos2.Columns("Saldo").IsVisible = False 'saldo
                '' ''Me.grdDatos2.Columns(11).IsVisible = False 'observacion
                '' ''Me.grdDatos2.Columns(12).IsVisible = False 'empaque
                '' ''Me.grdDatos2.Columns(14).IsVisible = False 'clrEstado
                '' ''Me.grdDatos2.Columns(15).IsVisible = False 'numero de articulo en catalogo
                '' ''Me.grdDatos2.Columns(16).IsVisible = False 'fecha ultima compra
                '' ''Me.grdDatos2.Columns(17).IsVisible = False 'marca
                '' ''Me.grdDatos2.Columns(18).IsVisible = False 'bitVentaMaxima
                '' ''Me.grdDatos2.Columns(19).IsVisible = False 'minimo
                '' ''Me.grdDatos2.Columns("TipoPrecio").IsVisible = False 'minimo
                '' ''Me.grdDatos2.Columns("Compatibilidad").IsVisible = False 'compatibilidad
                '' ''Me.grdDatos2.Columns("txmSurtir").IsVisible = False 'codSurtir
                '' ''Me.grdDatos2.Columns("UbicacionEstanteria").IsVisible = False
                '' ''Me.grdDatos2.Columns("CantidadMax").IsVisible = False

                '' ''Me.grdDatos2.Columns(2).Width = 40 ' codigo
                '' ''Me.grdDatos2.Columns(3).Width = 250 ' nombre
                '' ''Me.grdDatos2.Columns(4).Width = 180 ' nombre
                '' ''Me.grdDatos2.Columns(5).Width = 70 ' cantidad
                '' ''Me.grdDatos2.Columns(6).Width = 70 ' existencia
                '' ''Me.grdDatos2.Columns(7).Width = 70 ' reserva
                '' ''Me.grdDatos2.Columns(8).Width = 70 ' transito
                '' ''Me.grdDatos2.Columns(9).Width = 50 ' costo
                '' ''Me.grdDatos2.Columns(10).Width = 70 ' precio
                '' ''Me.grdDatos2.Columns(11).Width = 70 ' cantidadmax
                '' ''Me.grdDatos2.Columns(12).Width = 50 ' observacion
                '' ''Me.grdDatos2.Columns(13).Width = 60 'unidadempaque
                '' ''Me.grdDatos2.Columns(14).Width = 70 'surtir


                '' ''mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos2, "txbPrecio")
                '' ''mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos2, "txmCosto")

                '' ''Me.grdDatos2.Columns("txmCosto").IsVisible = False
                '' ''Me.grdDatos2.Columns("txbPrecio").IsVisible = True
                '' ''Me.grdDatos2.Columns("Transito").IsVisible = False
                ' '' ''Me.grdDatos2.Columns("txmCantidad").IsVisible = False
                ' '' ''Me.grdDatos2.Columns("Fecha").IsVisible = False
                '' ''Me.grdDatos2.Columns("txbPrecio").HeaderText = "Precio"

            ElseIf bitPedir Then
                Me.grdDatos.Columns("codigo").IsVisible = False
                mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
                grdDatos.Columns("Fecha").Width = 50
                grdDatos.Columns("Articulo").Width = 120
                grdDatos.Columns("Importancia").Width = 70
                grdDatos.Columns("Creado").Width = 70
                grdDatos.Columns("Saldo").Width = 80
                'grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
            End If

            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).ReadOnly = True
            Next

            For i As Integer = 0 To Me.grdDatos2.ColumnCount - 1
                Me.grdDatos2.Columns(i).ReadOnly = True
            Next

            mdlPublicVars.fnGrid_iconos(Me.grdDatos)
            mdlPublicVars.fnGrid_iconos(Me.grdDatos2)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            'MessageBox.Show("Error al llenar el listado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



#End Region

#Region "Eventos"
   
    Private Sub chkTodosTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosTipo.CheckedChanged
        Try
            'Llamamos a la funcion que activa o desactiva los filtros
            mdlPublicVars.fnCheckbox_ActivaDesactivar(grdTipoVehiculo, chkTodosTipo.Checked)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdTipoVehiculo_ValueChanged(sender As Object, e As EventArgs) Handles grdTipoVehiculo.ValueChanged
        Try
            mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblContador, "chmAgregar")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBusqueda_Click(sender As Object, e As EventArgs) Handles btnBusqueda.Click
        Try
            If cargo Then
                fnLlenarGrid()
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub fnFoto() Handles Me.panel1
        If Me.grdDatos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If fila >= 0 Then
                frmBuscarArticuloFoto.Text = "Informacion Articulo"
                frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
                frmBuscarArticuloFoto.codigo = CType(Me.grdDatos.Rows(fila).Cells("id").Value, Integer)
                frmBuscarArticuloFoto.cliente = cliente
                permiso.PermisoDialogEspeciales(frmBuscarArticuloFoto)
                frmBuscarArticuloFoto.Dispose()
            End If
        End If
    End Sub

#End Region

    Private Sub grdDatos2_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles grdDatos2.SelectionChanged
        fnInformacion(grdDatos2)
    End Sub

    Private Sub grdDatos_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles grdDatos.SelectionChanged
        fnInformacion(grdDatos)
    End Sub


    Private Sub fnInformacion(grd As Telerik.WinControls.UI.RadGridView)
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
            Dim ubicacion As String

            Dim fila As Integer = CInt(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grd))

            Try
                observacion = CType(grd.Rows(fila).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(grd.Rows(fila).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(grd.Rows(fila).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(grd.Rows(fila).Cells("Compatibilidad").Value, String)
            Catch ex As Exception
                compatibilidad = ""
            End Try

            Try
                ubicacion = CType(grd.Rows(fila).Cells("UbicacionEstanteria").Value, String)
            Catch ex As Exception
                ubicacion = ""
            End Try

            lblUbicacion.Text = ubicacion
            lblObservacion.Text = observacion
            lblMarca.Text = marca
            lblCompatibilidad.Text = compatibilidad
            If empaque <> "" Then

                lblEmpaque.Text = empaque
            Else
                lblEmpaque.Text = ""
            End If

            Dim codigoArt As Integer
            Try
                codigoArt = CType(Me.grdDatos.Rows(fila).Cells("id").Value, String)
            Catch ex As Exception
                codigoArt = ""
            End Try

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim art As tblArticulo = (From a In conexion.tblArticuloes Where a.idArticulo = codigoArt Select a).FirstOrDefault

                If art Is Nothing Then
                    lblPrecioPublico.Text = 0.0
                Else
                    lblPrecioPublico.Text = Format(If(art.precioPublico Is Nothing, 0, art.precioPublico), mdlPublicVars.formatoMoneda)
                End If

                conn.Close()
            End Using

        Catch ex As Exception
            RadMessageBox.Show(ex.ToString)
        End Try
    End Sub


    'Eventos Ingresos de Cantidad
    Private Sub grdDatos2_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDatos2.KeyDown
        fnIngresoCantidad(grdDatos2, e)
    End Sub

    Private Sub grdDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDatos.KeyDown
        fnIngresoCantidad(grdDatos, e)
    End Sub

    Private Function fnPromociones(ByVal Id As Integer, ByVal Cantidad As Integer) As Integer
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cx As Integer
                Dim cr As Integer

                Dim a As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = Id Select x).FirstOrDefault

                If a.bitPromocion = False Then
                    Return 0
                    Exit Function
                End If

                If Cantidad >= a.CuotaPromocion Then
                    cx = Math.Floor(CDec(Cantidad / a.CuotaPromocion))
                    mdlPublicVars.superSearchCuotaPromocion = a.CuotaPromocion
                    mdlPublicVars.superSearchCantidadPromocion = cx
                    cr = cx * a.CantidadPromocion
                End If

                conn.Close()

                Return cr
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'Funcion ingreso de cantidad
    Private Sub fnIngresoCantidad(grid As RadGridView, e As KeyEventArgs)
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grid)
        Dim columna As Integer = grid.CurrentColumn.Index
        Dim nombre As String = grid.Columns(columna).Name

        If Char.ConvertFromUtf32(e.KeyValue) = ChrW(Keys.Enter) And grid.Focused Then
            fnAgregar_Productos(grid, False)
        End If

        If nombre = "txmCantidad" Then
            If e.KeyCode = Keys.Delete Then
                grid.Rows(fila).Cells(nombre).Value = 0
            End If

            If e.KeyCode = Keys.Back Then
                If grid.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                    grid.Rows(fila).Cells(nombre).Value = grid.Rows(fila).Cells(nombre).Value.ToString.Substring(0, grid.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                End If
            End If

            If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                If grid.Rows(fila).Cells(nombre).Value = "0" Then
                    grid.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                Else
                    grid.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                End If

            ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then
                If grid.Rows(fila).Cells(nombre).Value = "0" Then
                    grid.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                Else
                    grid.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                End If
            End If
        End If
    End Sub

    'Funcion utilizada para agregar productos
    Private Sub fnAgregar_Productos(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal liquidacion As Boolean)
        Dim index As Integer
        Dim cont As Integer = 0
        Dim id As Integer = 0
        Dim cantidad As Integer = 0
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim precio As Decimal = 0
        Dim costo As Decimal = 0
        Dim surtir As Integer = 0
        Dim tipoPrecio As Integer = 0
        Dim estado As Integer = 0
        Dim saldo As Double = 0
        Dim codigoSurtir As Integer
        Dim promocion As Integer = 0

        If liquidacion = True Then
            mdlPublicVars.superSearchInventario = mdlPublicVars.General_InventarioLiquidacion
        Else
            mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario
        End If

        If ventaPequenia Then
            If mdlPublicVars.superSearchInventario <> formVentaPequenia.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If

        Else
            If mdlPublicVars.superSearchInventario <> formSalida.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If

        For index = 0 To grd.Rows.Count - 1

            id = grd.Rows(index).Cells(1).Value
            codigo = grd.Rows(index).Cells(2).Value
            nombre = grd.Rows(index).Cells(3).Value
            tipoPrecio = grd.Rows(index).Cells("TipoPrecio").Value
            estado = grd.Rows(index).Cells("clrEstado").Value

            Try
                cantidad = grd.Rows(index).Cells("txmCantidad").Value
            Catch ex As Exception
                cantidad = 0
            End Try

            surtir = grd.Rows(index).Cells("txmSurtir").Value

            ''Validador de Promociones
            If bitOferta = True Then

                promocion = fnPromociones(id, cantidad)

                If promocion > 0 Then
                    cantidad += promocion
                End If

            End If
            ''Fin Validad de Promociones

            Dim art As tblInventario

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                art = (From x In conexion.tblInventarios Where x.idArticulo = id And x.tblTipoInventario.idTipoinventario = mdlPublicVars.General_idTipoInventario
                                       Select x).FirstOrDefault

                conn.Close()
            End Using

            saldo = art.saldo
            If surtir = 0 And cantidad > 0 And (cantidad > saldo) Then
                If RadMessageBox.Show("Saldo Insuficiente, Enviar a Surtir " + art.tblArticulo.nombre1, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    surtir = cantidad - art.saldo
                    cantidad = art.saldo
                End If
            End If

            If cantidad > 0 Or surtir > 0 Then
                cont += 1
                If cont = 1 Then
                    If ventaPequenia = True Then
                        formVentaPequenia.fnRemoverFila() 'Agregado para la VentaPequenia
                    Else
                        formSalida.fnRemoverFila()
                    End If
                End If

                Try
                    precio = grd.Rows(index).Cells("txbPrecio").Value
                Catch ex As Exception
                    precio = 0
                End Try

                Try
                    costo = grd.Rows(index).Cells("txmCosto").Value
                Catch ex As Exception
                    costo = 0
                End Try

                mdlPublicVars.superSearchId = id
                mdlPublicVars.superSearchCodigo = codigo
                mdlPublicVars.superSearchNombre = nombre
                mdlPublicVars.superSearchCantidad = cantidad
                mdlPublicVars.superSearchPromocion = promocion
                mdlPublicVars.superSearchTipoPrecio = tipoPrecio
                mdlPublicVars.superSearchEstado = estado
                mdlPublicVars.superSearchPrecio = precio
                mdlPublicVars.superSearchSurtir = surtir

                If bitPendiente = True Then
                    mdlPublicVars.superSearchBitSurtir = 1
                    mdlPublicVars.superSearchBitOferta = 0
                    mdlPublicVars.superSearchBitNuevo = 0
                    mdlPublicVars.superSearchCodigoSurtir = grd.Rows(index).Cells("CodigoSurtir").Value
                ElseIf bitNuevo = True Then
                    mdlPublicVars.superSearchBitSurtir = 0
                    mdlPublicVars.superSearchBitNuevo = 1
                    mdlPublicVars.superSearchBitOferta = 0
                    mdlPublicVars.superSearchCodigoSurtir = 0
                ElseIf bitOferta = True Then
                    mdlPublicVars.superSearchBitSurtir = 0
                    mdlPublicVars.superSearchBitNuevo = 0
                    mdlPublicVars.superSearchBitOferta = 1
                    mdlPublicVars.superSearchCodigoSurtir = 0
                End If

                'Verificamos si la empresa valida la venta maxima por cliente
                If mdlPublicVars.Empresa_ValidaVenta Then
                    If fnCantidadMax(index, grd) = False Then
                        If venta Then
                            formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        End If
                        ' formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                    Else
                        grd.Rows(index).Cells("txmCantidad").BeginEdit()
                        Exit For
                    End If
                Else
                    If ventaPequenia = True Then 'Agregado si es venta pequenia 
                        formVentaPequenia.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                    Else
                        ''If bitPendiente = True Then
                        formSalida.fnAgregar_ArticulosGestion(If(surtir > 0 And cantidad = 0, True, False))
                        ''Else
                        ''formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        ''End If
                    End If
                    End If
                    grd.Rows(index).Cells("txmCantidad").Value = 0
                    grd.Rows(index).Cells("txmSurtir").Value = 0
                End If
        Next

        If cont > 0 Then
            If Not ventaPequenia Then
                formSalida.fnNuevaFila()
                formSalida.fnBloquearCombo()
            Else
                formVentaPequenia.fnNuevaFila()
                formVentaPequenia.fnBloquearCombo()
            End If
        End If

        'grd.SortDescriptors.Remove("txmCantidad")
    End Sub

    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer, grid As RadGridView) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = grid.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = grid.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = grid.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = grid.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = grid.Rows(fila).Cells("minimo").Value

            'Si el saldo es menor que el minimo y bitVentaMaxima = true, se activa la restriccion
            'Pero si la cantidadMaxima es igual a cero no se valida
            If saldo < minimo And valida Then
                If limite > 0 Then
                    If cantidad > limite Then
                        RadMessageBox.Show("Cantidad a vender sobrepasa la cantida maxima de venta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Return True
                        Exit Function
                    End If
                End If
            End If

            Return False
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Function

    'Doble clic en la celda de precios
    Private Sub grdDatos_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        fnCambioPrecio(grdDatos, e)
    End Sub

    Private Sub grdDatos2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grdDatos2.CellDoubleClick
        fnCambioPrecio(grdDatos2, e)
    End Sub

    Private Sub fnCambioPrecio(grid As RadGridView, e As GridViewCellEventArgs)
        Dim estado As Integer = CType(grid.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
        If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
            frmBuscarArticuloPrecios.Text = "Precios"
            frmBuscarArticuloPrecios.codigo = CType(grid.Rows(grid.CurrentRow.Index).Cells("ID").Value, Integer)
            frmBuscarArticuloPrecios.precioNormal = CType(grid.Rows(grid.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
            frmBuscarArticuloPrecios.codClie = Me.cliente
            frmBuscarArticuloPrecios.bitIndicadores = True
            frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
        End If
    End Sub

    'Funcion utilizada para elegir precios
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Dim fila As Integer = 0
            If rpvInformacion.SelectedPage.Name = "pgDatos1" Then
                fila = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                grdDatos.Rows(fila).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
                grdDatos.Rows(fila).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
                If especial = False Then
                    grdDatos.Rows(fila).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If

            If rpvInformacion.SelectedPage.Name = "pgDatos2" Then
                fila = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos2)
                grdDatos2.Rows(fila).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
                grdDatos2.Rows(fila).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
                If especial = False Then
                    grdDatos2.Rows(fila).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
