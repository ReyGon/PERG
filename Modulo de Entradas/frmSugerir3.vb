Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Imports System.Data.EntityClient
Public Class frmSugerir3
    Private estadoProgeso As Integer = 0

    Dim permiso As New clsPermisoUsuario
    Private _codBuscar As Integer
    Private _codclie As Integer
    Private _codvendedor As Integer
    Private _OpcionRetorno As String
    Private _idInventario As Integer
    Private _idBodega As Integer

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitFiltro As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

    Private _ventaPequenia As Integer

    Private _venta As Integer
    Private _grdIngresados As Telerik.WinControls.UI.RadGridView

    Private _formSalida As frmSalidas
    Public frmRetornoSalidas As frmSalidas


    Private _formVentaPequenia As frmVentaPequenia 'Venta pequenia
    Public frmRetornoVentaPequenia As frmVentaPequenia

    Dim b As New clsBase
    Dim dt As New clsDevuelveTabla
    Dim borrar As Boolean = False
    Dim cheques As Boolean = True

    Public Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property

    Public Property idInventario() As Integer
        Get
            idInventario = _idInventario
        End Get
        Set(value As Integer)
            _idInventario = value
        End Set
    End Property

    Public Property idBodega() As Integer
        Get
            idBodega = _idBodega
        End Get
        Set(value As Integer)
            _idBodega = value
        End Set
    End Property

    ' esta varible si esta en True sirve para enviar de parametro el id al sp y una opcion filtro para que busque ese articulo solamente.
    Public Property bitFiltro() As Boolean
        Get
            bitFiltro = _bitFiltro
        End Get
        Set(ByVal value As Boolean)
            _bitFiltro = value
        End Set
    End Property

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Public Property bitMovimientoInventario() As Boolean
        Get
            bitMovimientoInventario = _bitMovimientoInventario
        End Get
        Set(ByVal value As Boolean)
            _bitMovimientoInventario = value
        End Set
    End Property

    Public Property bitDevolucionCliente() As Boolean
        Get
            bitDevolucionCliente = _bitDevolucionCliente
        End Get
        Set(ByVal value As Boolean)
            _bitDevolucionCliente = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codclie
        End Get
        Set(ByVal value As Integer)
            _codclie = value
        End Set
    End Property

    Public Property codBuscar() As Integer
        Get
            codBuscar = _codBuscar
        End Get
        Set(ByVal value As Integer)
            _codBuscar = value
        End Set
    End Property

    Public Property codVendedor() As Integer
        Get
            codVendedor = _codvendedor
        End Get
        Set(ByVal value As Integer)
            _codvendedor = value
        End Set
    End Property

    Public Property OpcionRetorno() As String
        Get
            OpcionRetorno = _OpcionRetorno
        End Get
        Set(ByVal value As String)
            _OpcionRetorno = value
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

    Public Property grdIngresados As Telerik.WinControls.UI.RadGridView
        Get
            grdIngresados = _grdIngresados
        End Get
        Set(ByVal value As Telerik.WinControls.UI.RadGridView)
            _grdIngresados = value
        End Set
    End Property

    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property


    ' Agregado para la ventapequenia
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


    Private Sub frmSugerir3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdProductos.ImageList = frmControles.ImageListAdministracion
        'Me.grdProductos.BeginEditMode = RadGridViewBeginEditMode.BeginEditProgrammatically
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdModelos)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdMarca)

        lblGrid1.Text = mdlPublicVars.ProductoGrid1
        lblEtiquetaFiltro2.Text = mdlPublicVars.ProductoGrid2
        lblEMarca.Text = mdlPublicVars.ProductoCombo2

        'ajustar columnas. auto size.
        txtFiltro.Text = ""

        If bitProveedor = True Or bitCliente = True Or bitMovimientoInventario = True Then
            fnActivaFiltros()
        End If

        mdlPublicVars.fnGrid_iconos(Me.grdTipoVehiculo)
        mdlPublicVars.fnGrid_iconos(Me.grdModelos)

        txtFiltro.Focus()
        txtFiltro.Select()

        Me.grdModelos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        ''Me.rgbInfo.Visible = False
        ''Me.rgbSustitutos.Visible = False
        ''Me.txtFiltro.Visible = False
        ''Me.pgbProgreso.Visible = False
        ''Me.PictureBox3.Visible = False

        fnLlenar_gridsinfiltro()

        fnIdArticulosCorrectos()

    End Sub

    Private Sub fnIdArticulosCorrectos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim codigo As String
                Dim articulo As Integer

                For fila As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    codigo = Me.grdProductos.Rows(fila).Cells("Codigo").Value

                    articulo = (From x In conexion.tblArticuloes Where x.codigo1 = LTrim(RTrim(codigo)) Select x.idArticulo).FirstOrDefault

                    Me.grdProductos.Rows(fila).Cells("Id").Value = CInt(articulo)
                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para activar los filtros
    Private Sub fnActivaFiltros()
        Try
            chkTodosModelo.Checked = False
            chkTodosTipo.Checked = False

            If bitCliente = True Or bitMovimientoInventario = True Then
                Me.grdTipoVehiculo.Rows.Clear()
                'tipo de vehiculo con grid
                Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre _
                         Select Agregar = If(((From y In ctx.tblCliente_clasificacionCompra _
                                    Where x.codigo = y.tipoVehiculo And y.idCliente = codClie _
                                    Select y.codigo).FirstOrDefault) > 0, True, False), _
                                    IdDetalle = (From y In ctx.tblCliente_clasificacionCompra _
                                    Where x.codigo = y.tipoVehiculo And y.idCliente = codClie _
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

                'Si no tiene clasificaciones
                If cont = verd Then
                    Dim i
                    For i = 0 To Me.grdTipoVehiculo.Rows.Count - 1
                        Me.grdTipoVehiculo.Rows(i).Cells("chmAgregar").Value = True
                    Next
                    chkTodosTipo.Checked = True
                End If

                cont = 0
                verd = 0

                Me.grdModelos.Rows.Clear()
                'modelo de vehiculo con grid
                Dim mo = (From x In ctx.tblArticuloModeloVehiculoes Order By x.nombre _
                         Select Agregar = If(((From y In ctx.tblCliente_ModeloVehiculo _
                                    Where x.codigo = y.modeloVehiculo And y.cliente = codClie _
                                    Select y.codigo).FirstOrDefault) > 0, True, False), _
                                    IdDetalle = (From y In ctx.tblCliente_ModeloVehiculo _
                                    Where x.codigo = y.modeloVehiculo And y.cliente = codClie _
                                    Select y.codigo).FirstOrDefault,
                                   Codigo = x.codigo, Nombre = x.nombre)

                Me.grdModelos.Rows.Clear()
                For Each v In mo
                    cont += 1
                    Me.grdModelos.Rows.Add(True, v.CODIGO, v.NOMBRE)
                    'If v.AGREGAR = False Then
                    verd += 1
                    'End If
                Next

                'Si no tiene clasificaciones
                If cont = verd Then
                    Dim i
                    For i = 0 To Me.grdModelos.Rows.Count - 1
                        Me.grdModelos.Rows(i).Cells("chmAgregar").Value = True
                    Next
                    chkTodosModelo.Checked = True
                End If

                'Llenamos las marcas
                Dim mar = (From x In ctx.tblArticuloMarcaRepuestoes Order By x.nombre _
                          Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)
                Me.grdMarca.Rows.Clear()
                For Each v In mar
                    cont += 1
                    Me.grdMarca.Rows.Add(True, v.CODIGO, v.NOMBRE)
                    'If v.AGREGAR = False Then
                    verd += 1
                    'End If
                Next
                chkTodosMarca.Checked = True
            ElseIf bitProveedor = True Then
                Me.grdMarca.Visible = False
                lblEMarca.Visible = False
                chkTodosMarca.Visible = False
                Me.grdTipoVehiculo.Rows.Clear()
                'tipo de vehiculo con grid
                Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre _
                         Select Agregar = If(((From y In ctx.tblProveedor_TipoVehiculo _
                                    Where x.codigo = y.tipoVehiculo And y.proveedor = codClie _
                                    Select y.codigo).FirstOrDefault) > 0, True, False), _
                                    IdDetalle = (From y In ctx.tblProveedor_TipoVehiculo _
                                    Where x.codigo = y.tipoVehiculo And y.proveedor = codClie _
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

                'Si no tiene clasificaciones
                If cont = verd Then
                    Dim i
                    For i = 0 To Me.grdTipoVehiculo.Rows.Count - 1
                        Me.grdTipoVehiculo.Rows(i).Cells("chmAgregar").Value = True
                    Next
                    chkTodosTipo.Checked = True
                End If

                cont = 0
                verd = 0

                Me.grdModelos.Rows.Clear()
                'modelo de vehiculo con grid
                Dim mo = (From x In ctx.tblArticuloMarcaRepuestoes Order By x.nombre _
                         Select Agregar = If(((From y In ctx.tblProveedor_marca _
                                    Where x.codigo = y.marcaRepuesto And y.proveedor = codClie _
                                    Select y.codigo).FirstOrDefault) > 0, True, False), _
                                    IdDetalle = (From y In ctx.tblProveedor_marca _
                                    Where x.codigo = y.marcaRepuesto And y.proveedor = codClie _
                                    Select y.codigo).FirstOrDefault,
                                   Codigo = x.codigo, Nombre = x.nombre)

                Me.grdModelos.Rows.Clear()
                For Each v In mo
                    cont += 1
                    Me.grdModelos.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
                    If v.AGREGAR = False Then
                        verd += 1
                    End If
                Next

                'Si no tiene clasificaciones
                If cont = verd Then
                    Dim i
                    For i = 0 To Me.grdModelos.Rows.Count - 1
                        Me.grdModelos.Rows(i).Cells("chmAgregar").Value = True
                    Next
                    chkTodosModelo.Checked = True
                End If

                lblEtiquetaFiltro2.Text = "Marcas"
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            If especial = False Then
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

  

    ''Private Sub grdProductos_CellClick(sender As Object, e As GridViewCellEventArgs) Handles grdProductos.CellClick

    ''    Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
    ''    Dim col As Integer = Me.grdProductos.CurrentColumn.Index
    ''    Dim nombre As String = Me.grdProductos.Columns(col).Name

    ''    If nombre = "txmCosto" Then
    ''        ''RadMessageBox.Show("El Costo ah sido Borrado del Grid", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    ''        ''Me.grdProductos.Rows(fila).Cells("txmCosto").IsSelected = True
    ''        ''Me.grdProductos.Rows(fila).Cells("txmCosto").ReadOnly = False
    ''        Me.grdProductos.Rows(fila).Cells("txmCosto").Value = ""
    ''    End If

    ''End Sub



    '----------------------------EVENTOS DE COLORES PARA GRID DE PRODUCTOS Y SUSTITUTOS.

    Private Sub grdProductos_SelectionChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        Dim fila As Nullable(Of Integer) = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdProductos)

        'finalizar edicion del componente.

        Me.grdProductos.EndEdit()

        Me.grdProductos.PerformLayout()
        Me.grdProductos.Refresh()

        If fila IsNot Nothing And Me.grdProductos.RowCount > 0 Then
            lbFondoSustituto.Visible = True
            lblESustituto.Visible = True

            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
            Dim ubicacion As String
            Try
                observacion = CType(Me.grdProductos.Rows(fila).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(Me.grdProductos.Rows(fila).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(Me.grdProductos.Rows(fila).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(Me.grdProductos.Rows(fila).Cells("Compatibilidad").Value, String)
            Catch ex As Exception
                compatibilidad = ""
            End Try

            Try
                ubicacion = CType(Me.grdProductos.Rows(fila).Cells("UbicacionEstanteria").Value, String)
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

            'Obtenemos el id del articulo
            Dim codArticulo As Integer = Me.grdProductos.Rows(fila).Cells("id").Value

            'Verificamos si tiene sustitutos
            Dim categoria As Nullable(Of Integer) = (From x In ctx.tblSustitutoes Where x.idarticulo = codArticulo _
                                        Select x.idSustitutoCategoria).FirstOrDefault

            If categoria IsNot Nothing Then
                Dim sustitutos As Integer = (From x In ctx.tblSustitutoes Where x.idSustitutoCategoria = categoria _
                                         Select x).Count

                If sustitutos >= 2 Then
                    lbFondoSustituto.BackColor = Color.LimeGreen
                    lblESustituto.Text = "Tiene Sustitutos"
                Else
                    lbFondoSustituto.BackColor = Color.Red
                    lblESustituto.Text = "NO Tiene Sustitutos"
                End If
            Else
                lbFondoSustituto.BackColor = Color.Red
                lblESustituto.Text = "NO Tiene Sustitutos"
            End If
        Else
            lbFondoSustituto.Visible = False
            lblESustituto.Visible = False
            lblObservacion.Text = ""
            lblMarca.Text = ""
            lblCompatibilidad.Text = ""
            lblEmpaque.Text = ""
        End If
    End Sub

    'FUNCION QUE LLENA EL GRID PRODUCTOS
    Private Sub fnLlenar_productos()
        Try
            pgbProgreso.Value = 10
            Me.grdProductos.DataSource = Nothing

            Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            Dim codigomodeloVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            Dim codigoMarcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
            Dim cons = Nothing
            Dim cons2 = Nothing
            Dim buscar As Boolean = False

            If txtFiltro.Text.Trim.Length >= 0 And codigoTipoVehiculo.IndexOf(",") <= 0 Then
                buscar = True
            ElseIf txtFiltro.Text.Trim.Length >= 0 And codigoTipoVehiculo.IndexOf(",") >= 0 Then
                buscar = True
            End If

            If buscar Then
                If bitMovimientoInventario = True Then
                    cons = ctx.sp_buscarsugerir(mdlPublicVars.idEmpresa, txtFiltro.Text, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, True, False, codigoMarcaRepuesto, venta)

                    pgbProgreso.Value = 30
                Else
                    cons = ctx.sp_buscarsugerir(mdlPublicVars.idEmpresa, txtFiltro.Text, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
                    pgbProgreso.Value = 15
                    If Not bitProveedor Then
                        cons2 = ctx.sp_buscarsugerir(mdlPublicVars.idEmpresa, txtFiltro.Text, mdlPublicVars.General_InventarioLiquidacion, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
                        pgbProgreso.Value = 15
                    End If
                End If
            Else
                RadMessageBox.Show("Debe ingresar al menos una palabra para filtrar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

            grdProductos.DataSource = cons

            fnConfiguracion(grdProductos)

            Me.grdProductos.PerformLayout()

            fnIngresados()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            grdProductos.DataSource = Nothing
        End Try

        mdlPublicVars.fnGrid_iconos(Me.grdProductos)

        Me.BringToFront()

    End Sub

    Private Sub fnLlenar_gridsinfiltro()
        Try
            pgbProgreso.Value = 10
            Me.grdProductos.DataSource = Nothing

            Dim cons = Nothing

            Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            Dim codigomodeloVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            Dim codigoMarcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                conexion.CommandTimeout = 10000
                cons = conexion.sp_EjecutaSugerirSucursal(mdlPublicVars.idEmpresa, ServidorSucursal, BDSucursal, codigoTipoVehiculo, codigoMarcaRepuesto)
                pgbProgreso.Value = 15
                pgbProgreso.Value = 30

                Me.grdProductos.DataSource = cons

                Me.fnConfiguracion(Me.grdProductos)

                Me.grdProductos.PerformLayout()

                fnIngresados()

                conn.Close()
            End Using

            ''Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            ''Dim codigomodeloVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            ''Dim codigoMarcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
            ''Dim cons = Nothing
            ''Dim cons2 = Nothing
            ''Dim buscar As Boolean = False

            ''If txtFiltro.Text.Trim.Length >= 0 And codigoTipoVehiculo.IndexOf(",") <= 0 Then
            ''    buscar = True
            ''ElseIf txtFiltro.Text.Trim.Length >= 0 And codigoTipoVehiculo.IndexOf(",") >= 0 Then
            ''    buscar = True
            ''End If

            ''Dim conexion As New dsi_pos_demoEntities
            ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            ''    conn.Open()
            ''    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            ''    If venta = 1 Then
            ''        If buscar Then
            ''            If bitMovimientoInventario = True Then
            ''                conexion.CommandTimeout = 10000
            ''                cons = conexion.sp_cargarproductoventa(mdlPublicVars.idEmpresa, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, True, False, codigoMarcaRepuesto, venta)

            ''                pgbProgreso.Value = 30
            ''            Else
            ''                conexion.CommandTimeout = 10000
            ''                cons = conexion.sp_cargarproductoventa(mdlPublicVars.idEmpresa, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
            ''                pgbProgreso.Value = 15
            ''                If Not bitProveedor Then
            ''                    conexion.CommandTimeout = 10000
            ''                    cons2 = conexion.sp_cargarproductoventa(mdlPublicVars.idEmpresa, mdlPublicVars.General_InventarioLiquidacion, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
            ''                    pgbProgreso.Value = 15
            ''                End If
            ''            End If
            ''        Else
            ''            RadMessageBox.Show("Debe ingresar al menos una palabra para filtrar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            ''        End If

            ''        grdProductos.DataSource = cons

            ''        fnConfiguracion(grdProductos)

            ''        Me.grdProductos.PerformLayout()

            ''        fnIngresados()

            ''    Else

            ''        If buscar Then
            ''            If bitMovimientoInventario = True Then

            ''                cons = conexion.sp_cargarProductoscompra2(mdlPublicVars.idEmpresa, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, True, False, codigoMarcaRepuesto, venta)

            ''                pgbProgreso.Value = 30
            ''            Else

            ''                cons = conexion.sp_cargarProductoscompra2(mdlPublicVars.idEmpresa, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
            ''                pgbProgreso.Value = 15

            ''                If Not bitProveedor Then
            ''                    cons2 = conexion.sp_cargarProductoscompra2(mdlPublicVars.idEmpresa, mdlPublicVars.General_InventarioLiquidacion, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
            ''                    pgbProgreso.Value = 15
            ''                End If
            ''            End If

            ''        Else
            ''            RadMessageBox.Show("Debe ingresar al menos una palabra para filtrar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            ''        End If

            ''        grdProductos.DataSource = cons

            ''        fnConfiguracion(grdProductos)

            ''        Me.grdProductos.PerformLayout()

            ''        fnIngresados()
            ''    End If
            ''    conn.Close()
            ''End Using

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            grdProductos.DataSource = Nothing
        End Try

        mdlPublicVars.fnGrid_iconos(Me.grdProductos)

        Me.BringToFront()

    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion(ByRef grd As Telerik.WinControls.UI.RadGridView)
        Try
            If grd.ColumnCount > 2 Then
                grd.Columns.Move(grd.Columns("ingresado").Index, grd.Columns(grd.ColumnCount - 1).Index)

                Me.grdModelos.Columns("chmAgregar").HeaderText = ""
                Me.grdTipoVehiculo.Columns("chmAgregar").HeaderText = ""

                grd.Columns("id").IsVisible = False 'id
                grd.Columns("cantidadMax").IsVisible = False 'reserva
                grd.Columns("observacion").IsVisible = False 'cantidad Maxima
                grd.Columns("UnidadEmpaque").IsVisible = False 'observacion
                grd.Columns("clrEstado").IsVisible = False 'empaque
                grd.Columns("NumeroArt").IsVisible = False 'surtir
                grd.Columns("ultimaCompra").IsVisible = False 'clrEstado
                grd.Columns("marca").IsVisible = False 'numero de articulo en catalogo
                grd.Columns("bitventamaxima").IsVisible = False 'fecha ultima compra
                grd.Columns("minimo").IsVisible = False 'marca
                grd.Columns("TipoPrecio").IsVisible = False 'minimo
                grd.Columns("Compatibilidad").IsVisible = False ' compatibilidad
                grd.Columns("UbicacionEstanteria").IsVisible = False 'Ubicacion en estanteria
                grd.Columns("chmAgregar").IsVisible = True
                grd.Columns("txmCantidad").IsVisible = True
                grd.Columns("Sugerida").IsVisible = True
                grd.Columns("Minimo").IsVisible = True
                grd.Columns("Minimo2").IsVisible = False
                grd.Columns("Maximo").IsVisible = True


                grd.Columns(0).Width = 40 ' agregar
                grd.Columns(2).Width = 40 ' codigo
                grd.Columns(3).Width = 150 ' nombre
                grd.Columns("txmCantidad").Width = 35 ' cantidad
                grd.Columns(5).Width = 30 ' existencia
                grd.Columns(6).Width = 30 ' reserva
                grd.Columns("Transito").Width = 40 ' transito

                If venta = 1 Then
                    grd.Columns("txmCosto").Width = 40 ' costo
                    grd.Columns("txmCosto").IsVisible = False
                    grd.Columns("txmPrecio").IsVisible = True
                    grd.Columns("txmPrecio").Width = 40
                    grd.Columns("txmSurtir").IsVisible = False


                    mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "txmPrecio")
                Else
                    grd.Columns("txmPrecio").Width = 40 ' precio
                    grd.Columns("txmPrecio").IsVisible = False
                End If

                grd.Columns("Maximo").Width = 40 ' cantidadmax
                grd.Columns(11).Width = 50 ' observacion
                grd.Columns(12).Width = 60 'unidadempaque
                grd.Columns(13).Width = 70 'surtir


                grd.Columns(0).ReadOnly = False
                grd.Columns(1).ReadOnly = True
                grd.Columns(2).ReadOnly = True
                grd.Columns(3).ReadOnly = True
                grd.Columns(4).ReadOnly = True 'columna editable, cantidad
                grd.Columns(5).ReadOnly = True
                grd.Columns(6).ReadOnly = True
                grd.Columns(7).ReadOnly = True
                grd.Columns(8).ReadOnly = False
                grd.Columns(9).ReadOnly = True
                grd.Columns(10).ReadOnly = True
                grd.Columns(11).ReadOnly = True
                grd.Columns("txmCantidad").ReadOnly = True

                pgbProgreso.Value = 40


                mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "txmCosto")

                If bitProveedor = True Or bitMovimientoInventario = True Then
                    grd.Columns("Reserva").IsVisible = False
                    grd.Columns("clrEstado").IsVisible = False
                    grd.Columns("txmPrecio").IsVisible = False
                    grd.Columns("txmSurtir").IsVisible = False
                    grd.Columns("CantidadMax").IsVisible = False
                    grd.Columns.Move(8, 5)


                    grd.Columns("txmCosto").ReadOnly = True

                ElseIf bitCliente = True Or bitDevolucionCliente = True Then
                    grd.Columns("txmCosto").IsVisible = False
                    grd.Columns("txmPrecio").IsVisible = True
                    grd.Columns("Transito").IsVisible = False
                ElseIf OpcionRetorno = "consulta" Then
                    grd.Columns("txmCosto").IsVisible = False
                    grd.Columns("clrEstado").IsVisible = False
                    grd.Columns("txmPrecio").IsVisible = False
                End If
                pgbProgreso.Value = 60
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion que se utiliza para agregar los productos en el grid 
    Private Sub fnAgregar_Productos(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal liquidacion As Boolean)
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

        If liquidacion = True Then
            mdlPublicVars.superSearchInventario = mdlPublicVars.General_InventarioLiquidacion
        Else
            mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario
        End If

        If bitCliente = True And bitDevolucionCliente = False And grd.Rows.Count > 0 Then
            If ventaPequenia = True Then
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
        End If

        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                'Obtener las filas con cantidad o surtir mayor a 0
                Dim listaArticulo As List(Of GridViewRowInfo) = Nothing

                If bitProveedor Or bitDevolucionCliente Or bitMovimientoInventario Then
                    listaArticulo = (From x In grd.Rows.AsEnumerable Where Not x.Cells("txmCantidad").Value.Equals("") Select x).Where(Function(x) x.Cells("chmAgregar").Value = True).ToList.AsEnumerable
                Else
                    listaArticulo = (From x In grd.Rows.AsEnumerable Where CType(x.Cells("txmCantidad").Value, Double) > 0 Or CType(x.Cells("txmSurtir").Value, Double) > 0 Select x).ToList.AsEnumerable
                End If

                For Each fila As GridViewRowInfo In listaArticulo
                    id = fila.Cells("id").Value
                    codigo = fila.Cells("Codigo").Value
                    nombre = fila.Cells("Nombre").Value
                    tipoPrecio = fila.Cells("TipoPrecio").Value
                    estado = fila.Cells("clrEstado").Value
                    Try
                        cantidad = fila.Cells("txmCantidad").Value
                    Catch ex As Exception
                        cantidad = 0
                    End Try

                    surtir = fila.Cells("txmSurtir").Value
                    Dim art As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = id And x.tblTipoInventario.idTipoinventario = mdlPublicVars.General_idTipoInventario
                                               Select x).FirstOrDefault

                    saldo = art.saldo
                    If surtir = 0 And cantidad > 0 And (cantidad > saldo) And bitCliente = True And bitDevolucionCliente = False Then
                        If RadMessageBox.Show("Saldo Insuficiente, Enviar a Surtir " + art.tblArticulo.nombre1, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                            surtir = cantidad - art.saldo
                            cantidad = art.saldo
                        End If
                    End If

                    If cantidad > 0 Or surtir > 0 Then
                        cont += 1
                        If cont = 1 Then
                            If bitCliente = True And bitDevolucionCliente = False Then

                                If ventaPequenia = True Then

                                    formVentaPequenia.fnRemoverFila() 'Agregado para la VentaPequenia
                                Else
                                    formSalida.fnRemoverFila()
                                End If

                            ElseIf bitProveedor = True Then
                                frmEntrada.fnRemoverFila()
                            ElseIf bitMovimientoInventario = True Then
                                frmMovimientoInventarios.fnRemoverFila()
                            ElseIf bitDevolucionCliente = True Then
                                frmClienteDevolucion.fnRemoverFila()
                            End If
                        End If

                        Try
                            precio = fila.Cells("txmPrecio").Value
                        Catch ex As Exception
                            precio = 0
                        End Try

                        Try
                            costo = fila.Cells("txmCosto").Value
                        Catch ex As Exception
                            costo = 0
                        End Try

                        mdlPublicVars.superSearchId = id
                        mdlPublicVars.superSearchCodigo = codigo
                        mdlPublicVars.superSearchNombre = nombre
                        mdlPublicVars.superSearchCantidad = cantidad
                        mdlPublicVars.superSearchTipoPrecio = tipoPrecio
                        mdlPublicVars.superSearchEstado = estado
                        mdlPublicVars.superSearchIdUnidadMedida = mdlPublicVars.UnidadMedidaDefault
                        mdlPublicVars.superSearchUnidadMedida = "Unidad"
                        mdlPublicVars.superSearchUnidadMedidaValor = 1


                        If bitCliente = True And bitDevolucionCliente = False Then
                            mdlPublicVars.superSearchPrecio = precio
                            mdlPublicVars.superSearchCosto = costo
                            mdlPublicVars.superSearchSurtir = surtir

                            'Verificamos si la empresa valida la venta maxima por cliente
                            If Empresa_ValidaVenta Then

                                If fnCantidadMax(fila.Index) = False Then
                                    If venta = True Then
                                        formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                                    End If
                                    ' formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                                Else
                                    fila.Cells("txmCantidad").BeginEdit()
                                    Exit For
                                End If
                            Else
                                If ventaPequenia = True Then 'Agregado si es venta pequenia 
                                    formVentaPequenia.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                                Else
                                    formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                                End If

                            End If
                        ElseIf bitProveedor = True Then
                            mdlPublicVars.superSearchPrecio = costo
                            frmEntrada.fnAgregar_Articulos()
                        ElseIf bitMovimientoInventario = True Then
                            mdlPublicVars.superSearchPrecio = costo
                            frmMovimientoInventarios.fnAgregar_Articulos()
                        ElseIf bitDevolucionCliente = True Then
                            mdlPublicVars.superSearchPrecio = precio
                            frmClienteDevolucion.fnAgregar_Articulos()
                        End If
                        fila.Cells("txmCantidad").Value = 0
                        fila.Cells("txmSurtir").Value = 0
                    End If
                Next
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
            conn.Close()
        End Using

        If cont > 0 Then
            If bitCliente = True And bitDevolucionCliente = False Then
                formSalida.fnNuevaFila()
                formSalida.fnBloquearCombo()
            ElseIf bitProveedor = True Then
                frmEntrada.fnNuevaFila()
            ElseIf bitMovimientoInventario = True Then
                frmMovimientoInventarios.fnNuevaFila()
            ElseIf bitDevolucionCliente = True Then
                frmClienteDevolucion.fnNuevaFila()
            End If
        End If

        'grd.SortDescriptors.Remove("cantidad")
    End Sub


    Public Shared Function ConvertirLinqAtabla(Of T)(items As IQueryable) As DataTable
        Dim type As Type = GetType(T)


        Dim props = TypeDescriptor.GetProperties(type).Cast(Of PropertyDescriptor)().Where(Function(propertyInfo) propertyInfo.PropertyType.[Namespace].Equals("System")).Where(Function(propertyInfo) propertyInfo.IsReadOnly = False).ToArray()

        Dim table = New DataTable()

        Dim i
        For Each i In props
            table.Columns.Add(i.Name, If(Nullable.GetUnderlyingType(i.PropertyType), i.PropertyType))
        Next

        Dim item
        For Each item In items
            table.Rows.Add(props.[Select](Function([property]) [property].GetValue(item)).ToArray())
        Next

        Return table
    End Function
    'Agregar productos del inventario principal y de liquidacion
    Private Sub frmSugerir3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Enter Then
            fnAgregar_Productos(grdProductos, False)

        End If
    End Sub

    'Funcion utilizada para agregar los formatos al grid
    Private Sub grdProductos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos.CellFormatting
        Try
            Dim inicio As Integer = CType(Me.grdProductos.Columns("Existencia").Index, Integer)

            mdlPublicVars.fnGrid_FormatoPrecios(sender, e, inicio)
            If e.CellElement.RowInfo.Cells("ingresado").Value IsNot Nothing Then
                mdlPublicVars.GridColor_fila(e, Color.Goldenrod)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try


    End Sub

    'Sustitutos
    Private Sub fnSustitutos() Handles Me.panel0

        Me.Close()

        ''If Me.grdProductos.Rows.Count > 0 Then
        ''    If Me.grdProductos.CurrentRow.Index >= 0 Then
        ''        frmBuscarArticuloSustitutos.Text = "Sustitutos"
        ''        frmBuscarArticuloSustitutos.codClie = codClie
        ''        frmBuscarArticuloSustitutos.codigoArticulo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
        ''        frmBuscarArticuloSustitutos.bitDevolucionCliente = Me.bitDevolucionCliente
        ''        frmBuscarArticuloSustitutos.bitProveedor = Me.bitProveedor
        ''        frmBuscarArticuloSustitutos.bitMovimientoInventario = Me.bitMovimientoInventario
        ''        frmBuscarArticuloSustitutos.bitCliente = Me.bitCliente
        ''        frmBuscarArticuloSustitutos.venta = Me.venta
        ''        frmBuscarArticuloSustitutos.StartPosition = FormStartPosition.CenterScreen
        ''        frmBuscarArticuloSustitutos.formSalida = formSalida
        ''        permiso.PermisoDialogEspeciales(frmBuscarArticuloSustitutos)
        ''    End If
        ''End If

    End Sub

    'Compatibilidad
    Private Sub fnCompatibilidad() Handles Me.panel1
        If Me.grdProductos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            If fila >= 0 Then
                frmBuscarArticuloCompatibilidad.Text = "Compatibilidad"
                frmBuscarArticuloCompatibilidad.StartPosition = FormStartPosition.CenterScreen
                frmBuscarArticuloCompatibilidad.codigo = CType(Me.grdProductos.Rows(fila).Cells("ID").Value, Integer)
                permiso.PermisoDialogEspeciales(frmBuscarArticuloCompatibilidad)
                frmBuscarArticuloCompatibilidad.Dispose()
            End If
        End If
    End Sub

    'Foto
    Private Sub fnFoto() Handles Me.panel2

        If Me.grdProductos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            If fila >= 0 Then
                frmBuscarArticuloFoto.Text = "Informacion Articulo"
                frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
                frmBuscarArticuloFoto.codigo = CType(Me.grdProductos.Rows(fila).Cells("ID").Value, Integer)
                frmBuscarArticuloFoto.cliente = codClie
                permiso.PermisoDialogEspeciales(frmBuscarArticuloFoto)
                frmBuscarArticuloFoto.Dispose()
            End If
        End If

    End Sub

    'Catalogo
    Private Sub fnCatalogo() Handles Me.panel3

        If Me.grdProductos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            If fila >= 0 Then
                frmBuscarArticuloCatalogo.Text = "Catalogo"
                frmBuscarArticuloCatalogo.codClie = codClie
                'frmBuscarArticuloCatalogo.OpcionRetorno = Me.OpcionRetorno
                frmBuscarArticuloCatalogo.bitCliente = Me.bitCliente
                frmBuscarArticuloCatalogo.bitDevolucionCliente = Me.bitDevolucionCliente
                frmBuscarArticuloCatalogo.bitProveedor = Me.bitProveedor
                frmBuscarArticuloCatalogo.bitMovimientoInventario = Me.bitMovimientoInventario
                frmBuscarArticuloCatalogo.StartPosition = FormStartPosition.CenterScreen
                frmBuscarArticuloCatalogo.codigo = CType(Me.grdProductos.Rows(fila).Cells("ID").Value, Integer)
                frmBuscarArticuloCatalogo.venta = Me.venta
                frmBuscarArticuloCatalogo.formSalida = formSalida

                permiso.PermisoDialogEspeciales(frmBuscarArticuloCatalogo)
                frmBuscarArticuloCatalogo.Dispose()
            End If
        End If
    End Sub

    'Ultimas Ventas o Compras
    Private Sub fnUltimasVentas() Handles Me.panel4
        If Me.grdProductos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            If fila >= 0 Then
                frmBuscarArticuloVentas.tipo = OpcionRetorno
                frmBuscarArticuloVentas.codClie = Me.codClie
                frmBuscarArticuloVentas.StartPosition = FormStartPosition.CenterScreen
                frmBuscarArticuloVentas.codigo = CType(Me.grdProductos.Rows(fila).Cells("ID").Value, Integer)
                permiso.PermisoDialogEspeciales(frmBuscarArticuloVentas)
                frmBuscarArticuloVentas.Dispose()
            End If
        End If
    End Sub

    'Precios Competencia
    Private Sub fnCompetencia() Handles Me.panel5
        If Me.grdProductos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            If fila >= 0 Then
                Try
                    frmBuscarArticuloPrecioCompetencia.Text = "Precios Competencia"
                    frmBuscarArticuloPrecioCompetencia.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloPrecioCompetencia.codigoArticulo = CType(Me.grdProductos.Rows(fila).Cells("ID").Value, Integer)
                    frmBuscarArticuloPrecioCompetencia.codigoCliente = CType(formSalida.cmbCliente.SelectedValue, Integer)
                    frmBuscarArticuloPrecioCompetencia.bitBloquearCombo = True ' bloqueamos el combo cliente para que no se pueda cambiar
                    permiso.PermisoDialogEspeciales(frmBuscarArticuloPrecioCompetencia)


                    frmBuscarArticuloPrecioCompetencia.Dispose()

                Catch ex As Exception
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End Try

            End If
        End If
    End Sub

   

    'Productos Nuevos
   

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdProductos.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txmPrecio" And e.RowIndex >= 0 Then 'And (estado = 1 Or estado = 2) 
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.bitPrincipal = True
                frmBuscarArticuloPrecios.codClie = codClie
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        Try
            Dim fil As Integer = CInt(Me.grdTipoVehiculo.CurrentRow.Index)
            Dim col As Integer = CInt(Me.grdTipoVehiculo.CurrentColumn.Index)
            Dim nombre = mdlPublicVars.tipoControl(Me.grdTipoVehiculo.Columns(col).Name)

            If mdlPublicVars.tipoControl(nombre) = "chm" Then
                txtFecha.Focus()
                txtFecha.Select()
                grdTipoVehiculo.Focus()
                Me.grdTipoVehiculo.Rows(fil).Cells(col).IsSelected = True
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdModelos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdModelos.ValueChanged
        Try
            Dim fil As Integer = CInt(Me.grdModelos.CurrentRow.Index)
            Dim col As Integer = CInt(Me.grdModelos.CurrentColumn.Index)
            Dim nombre = mdlPublicVars.tipoControl(Me.grdModelos.Columns(col).Name)
            If mdlPublicVars.tipoControl(nombre) = "chm" Then
                txtFecha.Focus()
                txtFecha.Select()
                grdModelos.Focus()
                Me.grdModelos.Rows(fil).Cells(col).IsSelected = True
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdMarca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarca.ValueChanged
        Try
            Dim fil As Integer = CInt(Me.grdMarca.CurrentRow.Index)
            Dim col As Integer = CInt(Me.grdMarca.CurrentColumn.Index)
            Dim nombre = mdlPublicVars.tipoControl(Me.grdMarca.Columns(col).Name)
            If mdlPublicVars.tipoControl(nombre) = "chm" Then
                txtFecha.Focus()
                txtFecha.Select()
                grdMarca.Focus()
                Me.grdMarca.Rows(fil).Cells(col).IsSelected = True
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Evento que maneja la activacion del checkbutton todos del grid de modelos
    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        Try
            'Llamamos a la funcion que activa o desactiva los filtros
            fnActivaTodos(chkTodosModelo.Checked, grdModelos)
        Catch ex As Exception

        End Try
    End Sub

    'Evento que maneja la activacion del checkbutton todos del grid de marcas
    Private Sub chkTodosMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        Try
            'Llamamos a la funcion que activa o desactiva los filtros
            fnActivaTodos(chkTodosMarca.Checked, grdMarca)
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para el manejo del checkbutton "Todos"
    Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells("chmAgregar").Value = estado
        Next
    End Sub

    'Evento que maneja la activacion del checkbutton todos del grid de modelos
    Private Sub chkTodosTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipo.CheckedChanged
        Try
            'Llamamos a la funcion que activa o desactiva los filtros
            fnActivaTodos(chkTodosTipo.Checked, grdTipoVehiculo)
        Catch ex As Exception
        End Try
    End Sub

    'Cuadro de Busqueda
    Private Sub txtFiltro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                'Realiza el proceso
                fnLlenar_productos()
                borrar = True
            ElseIf e.KeyValue = Keys.Down Then
                Me.grdProductos.Focus()
                Me.grdProductos.Columns("txmCantidad").IsCurrent = True
            ElseIf borrar = True Then
                txtFiltro.Text = ""
                borrar = False
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        Try
            Dim valor As String

            If Me.grdProductos.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
                Dim col As Integer = Me.grdProductos.CurrentColumn.Index
                Dim nombre As String = CStr(Me.grdProductos.Columns(col).Name)

                'si la columna es igual a enter, agrega los productos al formulario padre, al que lo llamo.
                If Char.ConvertFromUtf32(e.KeyValue) = ChrW(Keys.Enter) And Me.grdProductos.Focused = True Then
                    fnAgregar_Productos(Me.grdProductos, False)
                ElseIf nombre = "txmPrecio" And e.KeyCode = Keys.F2 Then
                    frmBuscarArticuloPrecios.Text = "Precios"
                    frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                    frmBuscarArticuloPrecios.codClie = codClie
                    frmBuscarArticuloPrecios.bitPrincipal = True
                    frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloPrecios.ShowDialog()
                    frmBuscarArticuloPrecios.Dispose()


                ElseIf nombre = "txmCantidad" Then

                    If e.KeyCode = Keys.Delete Then
                        Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = 0
                    End If

                    If e.KeyCode = Keys.Back Then
                        Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = 0
                    End If


                    If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                        If Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = "0" Then
                            Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                        Else
                            valor = Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value
                            valor = CStr(valor)
                            valor += Char.ConvertFromUtf32(e.KeyValue)
                            Me.grdProductos.Rows(fila).Cells(nombre).Value = valor
                        End If



                    ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                        If Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = "0" Then
                            Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                        Else
                            valor = Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value
                            valor = CStr(valor)
                            valor += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = valor
                        End If


                    ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                        If Me.grdProductos.Rows(CStr(fila)).Cells(nombre).Value = "0" Then

                            Me.grdProductos.Rows(fila).Cells(nombre).Value += "." 'e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                        Else

                            Me.grdProductos.Rows(fila).Cells(nombre).Value += "." 'e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)

                        End If
                    ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                        Me.grdProductos.Columns(nombre).ReadOnly = True
                        Me.grdProductos.Rows(fila).Cells(nombre).EndEdit()
                        txtFiltro.Focus()
                        txtFiltro.Text = e.KeyData.ToString
                        txtFiltro.Select(txtFiltro.TextLength, 0)
                        borrar = False




                    ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                        Me.grdProductos.Columns(nombre).ReadOnly = True
                        Me.grdProductos.Rows(fila).Cells(nombre).EndEdit()
                        txtFiltro.Focus()
                        txtFiltro.Text = e.KeyData.ToString
                        txtFiltro.Select(txtFiltro.TextLength, 0)
                        borrar = False
                    End If



                ElseIf nombre = "txmCosto" Then
                    If e.KeyCode = Keys.Delete Then
                        Me.grdProductos.Rows(fila).Cells(nombre).Value = 0
                    ElseIf e.KeyCode = Keys.Back Then
                        Me.grdProductos.Rows(fila).Cells(nombre).Value = 0
                    End If

                    ''If e.KeyCode = Keys.Back Then
                    ''    If Me.grdProductos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                    ''        Me.grdProductos.Rows(fila).Cells(nombre).Value = Me.grdProductos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdProductos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                    ''    End If
                    ''End If

                    If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Then
                        If Me.grdProductos.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdProductos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                        Else
                            Me.grdProductos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                        End If
                    ElseIf (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) Then
                        If Me.grdProductos.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdProductos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)


                        Else
                            Me.grdProductos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                        End If


                    ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                        If Me.grdProductos.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdProductos.Rows(fila).Cells(nombre).Value += "." 'e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                        Else
                            Me.grdProductos.Rows(fila).Cells(nombre).Value += "."
                        End If
                    ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                        Me.grdProductos.Columns(nombre).ReadOnly = True
                        Me.grdProductos.Rows(fila).Cells(nombre).EndEdit()
                        txtFiltro.Focus()
                        txtFiltro.Text = e.KeyData.ToString
                        txtFiltro.Select(txtFiltro.TextLength, 0)
                        borrar = False
                    End If
                Else
                    'era el unico else qu etabsa
                    If e.KeyValue >= 65 And e.KeyValue <= 90 Then
                        txtFiltro.Focus()
                        Me.grdProductos.Rows(fila).Cells(nombre).EndEdit()
                        txtFiltro.Focus()
                        txtFiltro.Text = e.KeyData.ToString
                        txtFiltro.Select(txtFiltro.TextLength, 0)
                        borrar = False
                    End If
                End If
            End If



            b.fnGrid_seleccionarEspacio(grdProductos, 0, e, True)
        Catch ex As Exception
            'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = Me.grdProductos.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = Me.grdProductos.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = Me.grdProductos.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = Me.grdProductos.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = Me.grdProductos.Rows(fila).Cells("minimo").Value

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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnAgregar_Productos(grdProductos, False)

        grdProductos.PerformLayout()
    End Sub

    Private Sub chkTodosMarca_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarca.CheckedChanged
        fnActivaTodos(chkTodosMarca.Checked, grdMarca)
    End Sub

    'DOC'S DE SALIDA
    Private Sub fnDocSalida() Handles Me.panel10
        Dim pestaña As String = rpv.SelectedPage.Name

        Try
            If pestaña = "pgPrincipal" Then
                frmDocumentosSalida.grd = Me.grdProductos
                frmDocumentosSalida.txtTitulo.Text = "Articulos"
            End If

            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'POR PEDIR
    Private Sub fnPorPedir() Handles Me.panel11
        frmBuscarArticuloPendientePedir.Text = "Productos por Pedir"
        frmBuscarArticuloPendientePedir.codigo = codClie
        frmBuscarArticuloPendientePedir.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmBuscarArticuloPendientePedir, False)
    End Sub

    'MODIFICAR
    Private Sub fnModificar() Handles Me.panel12
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdProductos)
            frmProducto.seleccionDefault = True
            frmProducto.codigoDefault = Me.grdProductos.Rows(fila).Cells(1).Value
            frmProducto.NuevoIniciar = False
            frmProducto.Text = "Modulo de Productos"
            permiso.PermisoDialogMantenimientoTelerik2(frmProducto)
            frmProducto.Dispose()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'VERIFICA SI ESTA INGRESADO EN VENTAS
    Private Sub fnIngresados()
        Try
            If venta > 0 And bitCliente And bitProveedor = False Then
                If grdIngresados.RowCount > 0 And grdProductos.RowCount > 0 Then
                    Dim lFilas As List(Of GridViewRowInfo) = (From x As GridViewRowInfo In grdIngresados.Rows Join y As GridViewRowInfo In grdProductos.Rows
                                                         On Trim(x.Cells("txmCodigo").Value) Equals Trim(y.Cells("Codigo").Value) _
                                                         Select y).ToList
                    Dim numeroArticulos As Integer = lFilas.Count
                    Dim contador As Integer = 0
                    For Each fila As GridViewRowInfo In lFilas
                        fila.Cells("ingresado").Value = 1
                        pgbProgreso.Value = (60 + (contador * 40) / numeroArticulos)
                        contador += 1
                    Next

                    pgbProgreso.Value = 100
                Else
                    pgbProgreso.Value = 100
                End If
            Else
                pgbProgreso.Value = 100
            End If
        Catch ex As Exception
            RadMessageBox.Show("Error " + ex.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnInformacion() Handles Me.panel13
        Try

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdProductos)
            frmProductoInformacion.codigoProduto = Me.grdProductos.Rows(fila).Cells(1).Value
            frmProductoInformacion.Text = "Informacion"
            frmProductoInformacion.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmProductoInformacion)
            frmProductoInformacion.Dispose()


        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnOfertas() Handles Me.panel14
        frmBuscarArticuloOfertas.Text = "Ofertas"
        frmBuscarArticuloOfertas.codCliente = codClie
        frmBuscarArticuloOfertas.venta = Me.venta
        frmBuscarArticuloOfertas.bitCliente = Me.bitCliente
        frmBuscarArticuloOfertas.formSalida = Me.formSalida
        frmBuscarArticuloOfertas.bitProveedor = Me.bitProveedor
        frmBuscarArticuloOfertas.bitMovimientoInventario = Me.bitMovimientoInventario
        frmBuscarArticuloOfertas.StartPosition = FormStartPosition.CenterScreen
        frmBuscarArticuloOfertas.ShowDialog()
        frmBuscarArticuloOfertas.Dispose()
    End Sub

    Private Sub chkTodosProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosProductos.CheckedChanged
        Try
            Dim cantidad As Integer
            If chkTodosProductos.Checked = True Then

                For Index As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    cantidad = Me.grdProductos.Rows(Index).Cells("Sugerida").Value
                    Me.grdProductos.Rows(Index).Cells("txmCantidad").Value = cantidad
                    Me.grdProductos.Rows(Index).Cells("chmAgregar").Value = True

                Next

            Else

                For Index As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    Me.grdProductos.Rows(Index).Cells("txmCantidad").Value = ""
                    Me.grdProductos.Rows(Index).Cells("chmAgregar").Value = False

                Next

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
