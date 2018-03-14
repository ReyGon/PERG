Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.ComponentModel

Public Class frmBuscarArticulo

    Dim permiso As New clsPermisoUsuario
    Private _codclie As Integer
    Private _codvendedor As Integer
    Private _OpcionRetorno As String

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

    Public frmRetornoSalidas As frmSalidas
    Dim b As New clsBase
    Dim alertar As New bl_Alertas
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

    Private Sub FrmBuscarArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdProductos.ImageList = frmControles.ImageListAdministracion
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdLiquidacion)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdModelos)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdMarca)

        'ajustar columnas. auto size.
        txtFiltro.Text = ""
        fnLlenar_productos()
        'fnLlenarFiltros()

        If bitProveedor = True Or bitCliente = True Or bitMovimientoInventario = True Then
            fnActivaFiltros()
        End If

        mdlPublicVars.fnGrid_iconos(Me.grdTipoVehiculo)
        mdlPublicVars.fnGrid_iconos(Me.grdModelos)

        txtFiltro.Focus()
        txtFiltro.Select()
        Me.grdModelos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        End Try
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            If especial = False Then
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fnAgregarPrecioLiquidacion()
        Try
            Me.grdLiquidacion.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
        Catch ex As Exception
        End Try
    End Sub

    '----------------------------EVENTOS DE COLORES PARA GRID DE PRODUCTOS Y SUSTITUTOS.

    Private Sub grdProductos_SelectionChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        Dim fila As Nullable(Of Integer) = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdProductos)

        If fila IsNot Nothing Then
            lblFondoSustituto.Visible = True
            lblESustituto.Visible = True

            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
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
                    lblFondoSustituto.BackColor = Color.LimeGreen
                    lblESustituto.Text = "--> Tiene Sustitutos"
                Else
                    lblFondoSustituto.BackColor = Color.Red
                    lblESustituto.Text = "--> NO Tiene Sustitutos"
                End If
            Else
                lblFondoSustituto.BackColor = Color.Red
                lblESustituto.Text = "--> NO Tiene Sustitutos"
            End If
        Else
            lblFondoSustituto.Visible = False
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
            Me.grdProductos.DataSource = Nothing

            Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            Dim codigomodeloVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            Dim codigoMarcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
            Dim cons = Nothing
            Dim cons2 = Nothing

            If bitMovimientoInventario = True Then
                cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, txtFiltro.Text, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, True, False, codigoMarcaRepuesto)
                pgLiquidacion.Dispose()
            Else
                cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, txtFiltro.Text, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto)
                cons2 = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, txtFiltro.Text, mdlPublicVars.General_InventarioLiquidacion, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto)
            End If

            grdProductos.DataSource = mdlPublicVars.EntitiToDataTable(cons)
            grdLiquidacion.DataSource = mdlPublicVars.EntitiToDataTable(cons2)
            fnConfiguracion(grdProductos)
            fnConfiguracion(grdLiquidacion)
            Me.grdProductos.PerformLayout()
            Me.grdLiquidacion.PerformLayout()
        Catch ex As Exception
            'Me.grdProductos.Rows.Clear()
            grdProductos.DataSource = Nothing
        End Try

        mdlPublicVars.fnGrid_iconos(Me.grdProductos)
        mdlPublicVars.fnGrid_iconos(Me.grdLiquidacion)
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion(ByRef grd As Telerik.WinControls.UI.RadGridView)
        Try
            Me.grdModelos.Columns("chmAgregar").HeaderText = ""
            Me.grdTipoVehiculo.Columns("chmAgregar").HeaderText = ""

            grd.Columns(1).IsVisible = False 'id
            grd.Columns(11).IsVisible = False 'observacion
            grd.Columns(12).IsVisible = False 'empaque
            grd.Columns(14).IsVisible = False 'clrEstado
            grd.Columns(15).IsVisible = False 'numero de articulo en catalogo
            grd.Columns(16).IsVisible = False 'fecha ultima compra
            grd.Columns(17).IsVisible = False 'marca
            grd.Columns(18).IsVisible = False 'bitVentaMaxima
            grd.Columns(19).IsVisible = False 'minimo
            grd.Columns("TipoPrecio").IsVisible = False 'minimo
            grd.Columns("Compatibilidad").IsVisible = False ' compatibilidad

            grd.Columns(0).Width = 60 ' agregar
            grd.Columns(2).Width = 70 ' codigo
            grd.Columns(3).Width = 180 ' nombre
            grd.Columns(4).Width = 70 ' cantidad
            grd.Columns(5).Width = 70 ' existencia
            grd.Columns(6).Width = 70 ' reserva
            grd.Columns(7).Width = 70 ' transito
            grd.Columns(8).Width = 50 ' costo
            grd.Columns(9).Width = 70 ' precio
            grd.Columns(10).Width = 70 ' cantidadmax
            grd.Columns(11).Width = 50 ' observacion
            grd.Columns(12).Width = 60 'unidadempaque
            grd.Columns(13).Width = 70 'surtir

            grd.Columns(0).ReadOnly = False
            grd.Columns(1).ReadOnly = True
            grd.Columns(2).ReadOnly = True
            grd.Columns(3).ReadOnly = True
            grd.Columns(4).ReadOnly = False
            grd.Columns(5).ReadOnly = True
            grd.Columns(6).ReadOnly = True
            grd.Columns(7).ReadOnly = True
            grd.Columns(8).ReadOnly = False
            grd.Columns(9).ReadOnly = True
            grd.Columns(10).ReadOnly = True
            grd.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grd, "txmCosto")
            If bitProveedor = True Or bitMovimientoInventario = True Then
                grd.Columns("Reserva").IsVisible = False
                grd.Columns("clrEstado").IsVisible = False
                grd.Columns("txbPrecio").IsVisible = False
                grd.Columns("txmSurtir").IsVisible = False
                grd.Columns("CantidadMax").IsVisible = False
                grd.Columns.Move(8, 5)
                pnx8Precios.Visible = False
                lbl4Ventas.Text = "U. Compras"
            ElseIf bitCliente = True Or bitDevolucionCliente = True Then
                grd.Columns("txmCosto").IsVisible = False
                grd.Columns("txbPrecio").IsVisible = True
                grd.Columns("Transito").IsVisible = False
            ElseIf OpcionRetorno = "consulta" Then
                grd.Columns("txmCosto").IsVisible = False
                grd.Columns("clrEstado").IsVisible = False
                grd.Columns("txbPrecio").IsVisible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para agregar los productos en el grid 
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
        If liquidacion = True Then
            mdlPublicVars.superSearchInventario = mdlPublicVars.General_InventarioLiquidacion
        Else
            mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario
        End If

        If bitCliente = True And bitDevolucionCliente = False Then
            If mdlPublicVars.superSearchInventario <> frmSalidas.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If


        For index = 0 To grd.Rows.Count - 1
            Try
                cantidad = grd.Rows(index).Cells("txmCantidad").Value
            Catch ex As Exception
                cantidad = 0
            End Try

            surtir = grd.Rows(index).Cells("txmSurtir").Value

            If cantidad > 0 Or surtir > 0 Then
                cont += 1
                If cont = 1 Then
                    If bitCliente = True And bitDevolucionCliente = False Then
                        frmSalidas.fnRemoverFila()
                    ElseIf bitProveedor = True Then
                        frmEntrada.fnRemoverFila()
                    ElseIf bitMovimientoInventario = True Then
                        frmMovimientoInventarios.fnRemoverFila()
                    ElseIf bitDevolucionCliente = True Then
                        frmClienteDevolucion.fnRemoverFila()
                    End If
                End If

                id = grd.Rows(index).Cells(1).Value
                codigo = grd.Rows(index).Cells(2).Value
                nombre = grd.Rows(index).Cells(3).Value
                tipoPrecio = grd.Rows(index).Cells("TipoPrecio").Value

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
                mdlPublicVars.superSearchTipoPrecio = tipoPrecio

                If bitCliente = True And bitDevolucionCliente = False Then
                    mdlPublicVars.superSearchPrecio = precio
                    mdlPublicVars.superSearchSurtir = surtir

                    'Verificamos si la empresa valida la venta maxima por cliente
                    If Empresa_ValidaVenta Then
                        If fnCantidadMax(index) = False Then
                            frmSalidas.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        Else
                            grd.Rows(index).Cells("txmCantidad").BeginEdit()
                            Exit For
                        End If
                    Else
                        frmSalidas.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
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
                grd.Rows(index).Cells("txmCantidad").Value = 0
                grd.Rows(index).Cells("txmSurtir").Value = 0
            End If
        Next

        If cont > 0 Then
            If bitCliente = True And bitDevolucionCliente = False Then
                frmSalidas.fnNuevaFila()
                frmSalidas.fnBloquearCombo()
            ElseIf bitProveedor = True Then
                frmEntrada.fnNuevaFila()
            ElseIf bitMovimientoInventario = True Then
                frmMovimientoInventarios.fnNuevaFila()
            ElseIf bitDevolucionCliente = True Then
                frmClienteDevolucion.fnNuevaFila()
            End If
        End If

        'grd.SortDescriptors.Remove("txmCantidad")
    End Sub

    'Agregar productos del inventario principal
    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos.KeyPress
        If Me.grdProductos.Rows.Count > 0 Then
            If Me.grdProductos.CurrentRow.Index >= 0 Then
                Dim col As Integer = Me.grdProductos.CurrentColumn.Index
                Dim nombre As String = Me.grdProductos.Columns(col).Name
                If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos.Focused = True Then
                    fnAgregar_Productos(Me.grdProductos, False)
                ElseIf e.KeyChar <> ChrW(Keys.Space) Then
                    If Not (nombre = "txmSurtir" Or nombre = "txmCantidad") Then
                        txtFiltro.Focus()
                        txtFiltro.Text = e.KeyChar
                        txtFiltro.Select(txtFiltro.TextLength, 0)
                        borrar = False
                    End If
                End If

                b.fnGrid_seleccionarEspacio(grdProductos, 0, e, True)
            End If
        End If
    End Sub

    'Agregar productos de liquidacion
    Private Sub grdLiquidacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdLiquidacion.KeyPress
        If Me.grdLiquidacion.Rows.Count > 0 Then
            If Me.grdLiquidacion.CurrentRow.Index >= 0 Then
                Dim col As Integer = Me.grdLiquidacion.CurrentColumn.Index
                Dim nombre As String = Me.grdLiquidacion.Columns(col).Name
                If e.KeyChar = ChrW(Keys.Enter) And Me.grdLiquidacion.Focused = True Then

                    If OpcionRetorno = "salidas" Then
                        txtFiltro.Focus()
                    End If
                ElseIf e.KeyChar <> ChrW(Keys.Space) Then
                    If Not (nombre = "txmSurtir" Or nombre = "txmCantidad") Then
                        txtFiltro.Focus()
                        txtFiltro.Text = e.KeyChar
                        txtFiltro.Select(txtFiltro.TextLength, 0)
                        borrar = False
                    End If
                End If

                b.fnGrid_seleccionarEspacio(grdLiquidacion, 0, e, True)
            End If
        End If
    End Sub

    'Agregar productos del inventario principal y de liquidacion
    Private Sub frmBuscarArticulo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Enter Then
            fnAgregar_Productos(grdProductos, False)
            fnAgregar_Productos(grdLiquidacion, True)
        End If
    End Sub

    'Funcion utilizada para agregar los formatos al grid
    Private Sub grdProductos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If Me.grdProductos.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(Me.grdProductos.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Sustitutos
    Private Sub fnSustitutos() Handles Me.panel0
        If Me.grdProductos.Rows.Count > 0 Then
            If Me.grdProductos.CurrentRow.Index >= 0 Then
                frmBuscarArticuloSustitutos.Text = "Sustitutos"
                frmBuscarArticuloSustitutos.codClie = codClie
                frmBuscarArticuloSustitutos.codigoArticulo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloSustitutos.bitDevolucionCliente = Me.bitDevolucionCliente
                frmBuscarArticuloSustitutos.bitProveedor = Me.bitProveedor
                frmBuscarArticuloSustitutos.bitMovimientoInventario = Me.bitMovimientoInventario
                frmBuscarArticuloSustitutos.bitCliente = Me.bitCliente
                frmBuscarArticuloSustitutos.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloSustitutos, False)
            End If
        End If
    End Sub

    'Compatibilidad
    Private Sub fnCompatibilidad() Handles Me.panel1
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    frmBuscarArticuloCompatibilidad.Text = "Compatibilidad"
                    frmBuscarArticuloCompatibilidad.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloCompatibilidad.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                    permiso.PermisoFrmEspeciales(frmBuscarArticuloCompatibilidad, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Foto
    Private Sub fnFoto() Handles Me.panel2
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    frmBuscarArticuloFoto.Text = "Informacion Articulo"
                    frmBuscarArticuloFoto.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloFoto.codigo = CType(Me.grdProductos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)).Cells("ID").Value, Integer)
                    frmBuscarArticuloFoto.cliente = codClie
                    permiso.PermisoFrmEspeciales(frmBuscarArticuloFoto, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Catalogo
    Private Sub fnCatalogo() Handles Me.panel3
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    frmBuscarArticuloCatalogo.Text = "Catalogo"
                    frmBuscarArticuloCatalogo.codClie = codClie
                    'frmBuscarArticuloCatalogo.OpcionRetorno = Me.OpcionRetorno
                    frmBuscarArticuloCatalogo.bitCliente = Me.bitCliente
                    frmBuscarArticuloCatalogo.bitDevolucionCliente = Me.bitDevolucionCliente
                    frmBuscarArticuloCatalogo.bitProveedor = Me.bitProveedor
                    frmBuscarArticuloCatalogo.bitMovimientoInventario = Me.bitMovimientoInventario
                    frmBuscarArticuloCatalogo.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloCatalogo.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                    permiso.PermisoFrmEspeciales(frmBuscarArticuloCatalogo, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Ultimas Ventas o Compras
    Private Sub fnUltimasVentas() Handles Me.panel4
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    frmBuscarArticuloVentas.tipo = OpcionRetorno
                    frmBuscarArticuloVentas.codClie = Me.codClie
                    frmBuscarArticuloVentas.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloVentas.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                    permiso.PermisoFrmEspeciales(frmBuscarArticuloVentas, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Precios Competencia
    Private Sub fnCompetencia() Handles Me.panel5
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    frmBuscarArticuloPrecioCompetencia.Text = "Precios Competencia"
                    frmBuscarArticuloPrecioCompetencia.StartPosition = FormStartPosition.CenterScreen
                    frmBuscarArticuloPrecioCompetencia.codigoArticulo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                    frmBuscarArticuloPrecioCompetencia.codigoCliente = CType(frmSalidas.cmbCliente.SelectedValue, Integer)
                    permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecioCompetencia, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Surtir
    Private Sub fnSurtir() Handles Me.panel6
        Try
            frmBuscarArticuloPendienteSurtir.Text = "Pendientes Surtir"
            frmBuscarArticuloPendienteSurtir.StartPosition = FormStartPosition.CenterScreen
            frmBuscarArticuloPendienteSurtir.salida = frmSalidas.codigo
            frmBuscarArticuloPendienteSurtir.inventario = frmSalidas.inventario
            frmBuscarArticuloPendienteSurtir.grd = frmSalidas.grdProductos
            frmBuscarArticuloPendienteSurtir.cliente = CType(frmSalidas.cmbCliente.SelectedValue, Integer)
            frmBuscarArticuloPendienteSurtir.bitCliente = Me.bitCliente
            frmBuscarArticuloPendienteSurtir.bitDevolucionCliente = Me.bitDevolucionCliente
            frmBuscarArticuloPendienteSurtir.bitProveedor = Me.bitProveedor
            frmBuscarArticuloPendienteSurtir.bitMovimientoInventario = Me.bitMovimientoInventario
            permiso.PermisoFrmEspeciales(frmBuscarArticuloPendienteSurtir, False)
        Catch ex As Exception

        End Try
    End Sub

    'Productos Nuevos
    Private Sub fnNuevos() Handles Me.panel7
        Try
            frmBuscarArticuloProductosNuevos.Text = "Productos Nuevos"
            frmBuscarArticuloProductosNuevos.codClie = codClie
            frmBuscarArticuloProductosNuevos.StartPosition = FormStartPosition.CenterScreen
            'frmBuscarArticuloProductosNuevos.OpcionRetorno = Me.OpcionRetorno
            frmBuscarArticuloProductosNuevos.bitCliente = Me.bitCliente
            frmBuscarArticuloProductosNuevos.bitDevolucionCliente = Me.bitDevolucionCliente
            frmBuscarArticuloProductosNuevos.bitProveedor = Me.bitProveedor
            frmBuscarArticuloProductosNuevos.bitMovimientoInventario = Me.bitMovimientoInventario
            permiso.PermisoFrmEspeciales(frmBuscarArticuloProductosNuevos, False)
        Catch ex As Exception

        End Try
    End Sub

    'Precios
    Private Sub fnPrecios() Handles Me.panel8
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                If Me.grdProductos.CurrentRow.Index >= 0 Then
                    Dim estado As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("clrEstado").Value, Integer)
                    'If (estado = 1 Or estado = 2) Then
                    frmBuscarArticuloPrecios.Text = "Precios"
                    frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                    frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                    frmBuscarArticuloPrecios.bitPrincipal = True
                    frmBuscarArticuloPrecios.codClie = codClie
                    frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
                    'End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Sugerir
    Private Sub fnSugerir() Handles Me.panel9
        Try
            frmBuscarArticuloSugeridos.Text = "Productos Sugeridos"
            frmBuscarArticuloSugeridos.codClie = codClie
            frmBuscarArticuloSugeridos.StartPosition = FormStartPosition.CenterScreen
            frmBuscarArticuloSugeridos.bitCliente = Me.bitCliente
            frmBuscarArticuloSugeridos.bitDevolucionCliente = Me.bitDevolucionCliente
            frmBuscarArticuloSugeridos.bitProveedor = Me.bitProveedor
            frmBuscarArticuloSugeridos.bitMovimientoInventario = Me.bitMovimientoInventario
            frmBuscarArticuloSugeridos.modelos = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            frmBuscarArticuloSugeridos.tipos = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            permiso.PermisoFrmEspeciales(frmBuscarArticuloSugeridos, False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdProductos.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2) 
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.bitPrincipal = True
                frmBuscarArticuloPrecios.codClie = codClie
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdLiquidacion_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdLiquidacion.CellDoubleClick
        Try
            If e.Column.Name = "txbPrecio" Then
                'Verificamos si el usuario puede editar precios
                Dim usuario As tblUsuario = (From x In ctx.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario
                                             Select x).FirstOrDefault
                Dim precio As Decimal = Me.grdLiquidacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                If usuario.editaPreciosLiquidacion = True Then
                    frmEditaPrecio.Text = "Editar Precio"
                    frmEditaPrecio.bitLiquidacion = True
                    frmEditaPrecio.precio = precio
                    frmEditaPrecio.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoFrmEspeciales(frmEditaPrecio, False)
                Else
                    RadMessageBox.Show("No tiene los permisos para editar el precio", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End If
            End If
        Catch ex As Exception
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
        Try
            'Recorremos el grid
            Dim i
            For i = 0 To grd.Rows.Count - 1
                grd.Rows(i).Cells("chmAgregar").Value = estado
            Next

        Catch ex As Exception

        End Try
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
                fnLlenar_productos()
                borrar = True
            ElseIf e.KeyValue = Keys.Down Then
                Me.grdProductos.Focus()
                Me.grdProductos.Columns("txmCantidad").IsCurrent = True
                fnEdicion()
            ElseIf borrar = True Then
                txtFiltro.Text = ""
                borrar = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Inicia edicion
    Private Sub fnEdicion()
        Try
            If Me.grdProductos.CurrentRow.Index >= 0 Then
                Dim fila As GridViewRowInfo = grdProductos.Rows(grdProductos.CurrentRow.Index)
                Dim cell As GridViewCellInfo = fila.Cells("txmCantidad")
                'fila.EnsureVisible()
                'cell.BeginEdit()
                'cell.EnsureVisible()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        Try
            If Me.grdProductos.CurrentRow.Index >= 0 Then
                Dim col As Integer = Me.grdProductos.CurrentColumn.Index
                Dim nombre As String = Me.grdProductos.Columns(col).Name
                If nombre = "txbPrecio" And e.KeyCode = Keys.F2 Then
                    Dim estado As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("clrEstado").Value, Integer)
                    If (estado = 1 Or estado = 2) Then
                        frmBuscarArticuloPrecios.Text = "Precios"
                        frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                        frmBuscarArticuloPrecios.bitPrincipal = True
                        frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdLiquidacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdLiquidacion.KeyDown
        Try
            If Me.grdLiquidacion.CurrentRow.Index >= 0 Then
                Dim col As Integer = Me.grdLiquidacion.CurrentColumn.Index
                Dim fila As Integer = Me.grdLiquidacion.CurrentRow.Index
                Dim nombre As String = Me.grdLiquidacion.Columns(col).Name

                If nombre = "txbPrecio" And e.KeyCode = Keys.F2 Then
                    'Verificamos si el usuario puede editar precios
                    Dim usuario As tblUsuario = (From x In ctx.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario
                                                 Select x).FirstOrDefault
                    Dim precio As Decimal = Me.grdLiquidacion.Rows(fila).Cells(col).Value
                    If usuario.editaPreciosLiquidacion = True Then
                        frmEditaPrecio.Text = "Editar Precio"
                        frmEditaPrecio.precio = precio
                        frmEditaPrecio.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoFrmEspeciales(frmEditaPrecio, False)
                    Else
                        RadMessageBox.Show("No tiene los permisos para editar el precio", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Try
            'For i As Integer = 0 To Me.grdProductos.RowCount - 1
            '    Me.grdProductos.Rows(e.RowIndex).Cells(e.ColumnIndex).EndEdit()
            'Next
        Catch ex As Exception
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
        End Try
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnAgregar_Productos(grdProductos, False)
        fnAgregar_Productos(grdLiquidacion, True)
    End Sub

    Private Sub chkTodosMarca_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarca.CheckedChanged
        fnActivaTodos(chkTodosMarca.Checked, grdMarca)
    End Sub

    Private Sub fnDocSalida() Handles Me.panel10
        Dim pestaña As String = rpv.SelectedPage.Name

        Try
            If pestaña = "pgPrincipal" Then
                frmDocumentosSalida.grd = Me.grdProductos
                frmDocumentosSalida.txtTitulo.Text = "Articulos"
            End If
            If pestaña = "pgLiquidacion" Then
                frmDocumentosSalida.grd = Me.grdLiquidacion
                frmDocumentosSalida.txtTitulo.Text = "Articulos Liquidación"
            End If
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

End Class