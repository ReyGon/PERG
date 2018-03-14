Imports System.Linq
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class frmBuscarArticuloOfertas

    Dim permiso As New clsPermisoUsuario
    Dim b As New clsBase
    Private _codCliente As Integer
    Private _venta As Integer
    Private _bitCliente As Boolean
    Private _formSalida As frmSalidas

    Private _bitProveedor As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

    Public Property venta() As Integer
        Get
            venta = _venta
        End Get
        Set(value As Integer)
            _venta = value
        End Set
    End Property


    Public Property codCliente() As Integer
        Get
            codCliente = _codCliente
        End Get
        Set(value As Integer)
            _codCliente = value
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


    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property

    Public Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
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



    Private Sub frmArticulosNoComprados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            grdProductos1.ImageList = frmControles.ImageListAdministracion
            mdlPublicVars.fnFormatoGridMovimientos(grdProductos1)
            mdlPublicVars.fnFormatoGridMovimientos(grdProductos2)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoVehiculo)
            mdlPublicVars.fnGrid_iconos(grdTipoVehiculo)

            lblGrid1.Text = ProductoGrid1
            pnx1Foto.Visible = False
            fnLllenarcombo()

            fnConfigurarSumarios()
            mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblContador, "chmAgregar")

        Catch ex As Exception

        End Try
    End Sub


    'Llenar combo
    Private Sub fnLllenarcombo()

        Try

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim datos = (From x In conexion.tblListaFiltroFechas Where x.bitBusqueda = True Select x.orden, codigo = x.dias, x.nombre
                             Order By orden Ascending)
                With cmbTiempoNoComprado
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = datos
                End With

                If bitCliente = True Then
                    Me.grdTipoVehiculo.Rows.Clear()
                    'tipo de vehiculo con grid
                    Dim tp = (From x In conexion.tblArticuloTipoVehiculoes Order By x.nombre _
                             Select Agregar = If(((From y In conexion.tblCliente_clasificacionCompra _
                                        Where x.codigo = y.tipoVehiculo And y.idCliente = codCliente _
                                        Select y.codigo).FirstOrDefault) > 0, True, False), _
                                        IdDetalle = (From y In conexion.tblCliente_clasificacionCompra _
                                        Where x.codigo = y.tipoVehiculo And y.idCliente = codCliente _
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
                End If

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenar_productos()
        Try
            Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
            Dim fechaFiltro As DateTime = fechaActual.AddDays(-cmbTiempoNoComprado.SelectedValue)
            Dim fecha As String = Format(fechaFiltro, "dd/MM/yyyy hh:mm:ss")

            grdProductos1.DataSource = Nothing


            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


                Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)

                'consulta ofertas
                Dim cons = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fecha.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", codCliente, 6, True, False, "", venta)

                grdProductos1.DataSource = cons

                'consulta ofernas no comprados
                Dim cons2 = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, fecha.ToString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, "", codCliente, 11, True, False, "", venta)
                grdProductos2.DataSource = cons2



                conn.Close()
            End Using

            fnConfiguracion()
        Catch ex As Exception

            grdProductos1.DataSource = Nothing
        End Try

        If grdProductos1.Rows.Count <= 0 Then
        Else
            grdProductos1.Focus()
            grdProductos1.Rows(0).IsCurrent = True
            grdProductos1.Columns(2).IsCurrent = True
            'fnProductos_agregados(grdProductos)
        End If
        mdlPublicVars.fnGrid_iconos(grdProductos1)
        mdlPublicVars.fnGrid_iconos(grdProductos2)


    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion()
        Try
            grdProductos1.Columns(1).IsVisible = False 'id
            grdProductos1.Columns(11).IsVisible = False 'observacion
            grdProductos1.Columns(12).IsVisible = False 'empaque
            grdProductos1.Columns(14).IsVisible = False 'clrEstado
            grdProductos1.Columns(15).IsVisible = False 'numero de articulo en catalogo
            grdProductos1.Columns(16).IsVisible = False 'fecha ultima compra
            grdProductos1.Columns(17).IsVisible = False 'marca
            grdProductos1.Columns(18).IsVisible = False 'bitVentaMaxima
            grdProductos1.Columns(19).IsVisible = False 'minimo
            grdProductos1.Columns("TipoPrecio").IsVisible = False 'minimo
            grdProductos1.Columns("Compatibilidad").IsVisible = False 'compatibilidad
            grdProductos1.Columns("UbicacionEstanteria").IsVisible = False 'Ubicacion Estanteria

            grdProductos1.Columns(0).Width = 60 ' agregar
            grdProductos1.Columns(2).Width = 70 ' codigo
            grdProductos1.Columns(3).Width = 180 ' nombre
            grdProductos1.Columns(4).Width = 70 ' cantidad
            grdProductos1.Columns(5).Width = 70 ' existencia
            grdProductos1.Columns(6).Width = 70 ' reserva
            grdProductos1.Columns(7).Width = 70 ' transito
            grdProductos1.Columns(8).Width = 50 ' costo
            grdProductos1.Columns(9).Width = 70 ' precio
            grdProductos1.Columns(10).Width = 70 ' cantidadmax
            grdProductos1.Columns(11).Width = 50 ' observacion
            grdProductos1.Columns(12).Width = 60 'unidadempaque
            grdProductos1.Columns(13).Width = 70 'surtir

            grdProductos1.Columns(0).ReadOnly = False
            grdProductos1.Columns(1).ReadOnly = True
            grdProductos1.Columns(2).ReadOnly = True
            grdProductos1.Columns(3).ReadOnly = True
            grdProductos1.Columns(4).ReadOnly = False
            grdProductos1.Columns(5).ReadOnly = True
            grdProductos1.Columns(6).ReadOnly = True
            grdProductos1.Columns(7).ReadOnly = True
            grdProductos1.Columns(8).ReadOnly = False
            grdProductos1.Columns(9).ReadOnly = True
            grdProductos1.Columns(10).ReadOnly = True
            grdProductos1.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos1, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos1, "txmCosto")
            grdProductos1.Columns("txbPrecio").HeaderText = "Precio"


            If bitCliente = True Or bitDevolucionCliente = True Then
                grdProductos1.Columns("txmCosto").IsVisible = False
                grdProductos1.Columns("txbPrecio").IsVisible = True
                grdProductos1.Columns("Transito").IsVisible = False


            End If

            'ElseIf bitProveedor = True Or bitMovimientoInventario = True Then
            '    grdProductos1.Columns("Reserva").IsVisible = False
            '    grdProductos1.Columns("clrEstado").IsVisible = False
            '    grdProductos1.Columns("txbPrecio").IsVisible = False
            '    grdProductos1.Columns("txmSurtir").IsVisible = False
            '    grdProductos1.Columns("CantidadMax").IsVisible = False
            '    grdProductos1.Columns.Move(8, 5)

            'ElseIf OpcionRetorno = "consulta" Then
            '    grdProductos1.Columns("txmCosto").IsVisible = False
            '    grdProductos1.Columns("clrEstado").IsVisible = False
            '    grdProductos1.Columns("txbPrecio").IsVisible = False
            'End If



            '---------------grid de ofertas-----------------------

            grdProductos2.Columns(1).IsVisible = False 'id
            grdProductos2.Columns(11).IsVisible = False 'observacion
            grdProductos2.Columns(12).IsVisible = False 'empaque
            grdProductos2.Columns(14).IsVisible = False 'clrEstado
            grdProductos2.Columns(15).IsVisible = False 'numero de articulo en catalogo
            grdProductos2.Columns(16).IsVisible = False 'fecha ultima compra
            grdProductos2.Columns(17).IsVisible = False 'marca
            grdProductos2.Columns(18).IsVisible = False 'bitVentaMaxima
            grdProductos2.Columns(19).IsVisible = False 'minimo
            grdProductos2.Columns("TipoPrecio").IsVisible = False 'minimo
            grdProductos2.Columns("Compatibilidad").IsVisible = False 'compatibilidad
            grdProductos2.Columns("UbicacionEstanteria").IsVisible = False 'Ubicacion Estanteria

            grdProductos2.Columns(0).Width = 60 ' agregar
            grdProductos2.Columns(2).Width = 70 ' codigo
            grdProductos2.Columns(3).Width = 180 ' nombre
            grdProductos2.Columns(4).Width = 70 ' cantidad
            grdProductos2.Columns(5).Width = 70 ' existencia
            grdProductos2.Columns(6).Width = 70 ' reserva
            grdProductos2.Columns(7).Width = 70 ' transito
            grdProductos2.Columns(8).Width = 50 ' costo
            grdProductos2.Columns(9).Width = 70 ' precio
            grdProductos2.Columns(10).Width = 70 ' cantidadmax
            grdProductos2.Columns(11).Width = 50 ' observacion
            grdProductos2.Columns(12).Width = 60 'unidadempaque
            grdProductos2.Columns(13).Width = 70 'surtir

            grdProductos2.Columns(0).ReadOnly = False
            grdProductos2.Columns(1).ReadOnly = True
            grdProductos2.Columns(2).ReadOnly = True
            grdProductos2.Columns(3).ReadOnly = True
            grdProductos2.Columns(4).ReadOnly = False
            grdProductos2.Columns(5).ReadOnly = True
            grdProductos2.Columns(6).ReadOnly = True
            grdProductos2.Columns(7).ReadOnly = True
            grdProductos2.Columns(8).ReadOnly = False
            grdProductos2.Columns(9).ReadOnly = True
            grdProductos2.Columns(10).ReadOnly = True
            grdProductos2.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos2, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos2, "txmCosto")
            grdProductos2.Columns("txbPrecio").HeaderText = "Precio"


            If bitCliente = True Or bitDevolucionCliente = True Then
                grdProductos2.Columns("txmCosto").IsVisible = False
                grdProductos2.Columns("txbPrecio").IsVisible = True
                grdProductos2.Columns("Transito").IsVisible = False
            End If





        Catch ex As Exception
        End Try
    End Sub

    'sumarios
    Private Sub fnConfigurarSumarios()

        'Activar barra de totales y crear operaciones.
        grdProductos1.MasterTemplate.ShowTotals = True
        Dim SCodigo As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)

        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {SCodigo})

        'agregar summario arreglo a grid
        grdProductos1.SummaryRowsTop.Add(summaryRowItem)
        grdProductos2.SummaryRowsTop.Add(summaryRowItem)


    End Sub



    'Funcion que se utiliza para agregar los productos en el grid 
    Private Sub fnAgregar_Productos(ByRef grd As Telerik.WinControls.UI.RadGridView)
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
        mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario

        If bitCliente = True Then
            If mdlPublicVars.superSearchInventario <> formSalida.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If



        For index = 0 To grd.Rows.Count - 1
            'agrega = CType(grd.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then

            If grd.Rows(index).Cells("txmCantidad").Value.ToString.Length > 0 Then
                cantidad = grd.Rows(index).Cells("txmCantidad").Value
                surtir = grd.Rows(index).Cells("txmSurtir").Value

                If cantidad > 0 Or surtir > 0 Then
                    cont += 1
                    If cont = 1 Then
                        If bitCliente = True Then
                            formSalida.fnRemoverFila()
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
                    estado = grd.Rows(index).Cells("clrEstado").Value
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
                    If bitCliente = True Then
                        mdlPublicVars.superSearchPrecio = precio
                        mdlPublicVars.superSearchSurtir = surtir

                        'Verificamos si la empresa valida la venta maxima por cliente
                        If Empresa_ValidaVenta = True Then
                            If fnCantidadMax(index) = False Then
                                formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                            Else
                                grd.Rows(index).Cells("txmCantidad").BeginEdit()
                                Exit For
                            End If
                        Else
                            formSalida.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
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
                End If
                grd.Rows(index).Cells("txmCantidad").Value = 0
                grd.Rows(index).Cells("txmSurtir").Value = 0
            Else
                cantidad = 0
                surtir = 0
            End If

        Next


        If cont > 0 Then
            If bitCliente = True Then
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
    End Sub

    'Funcion utilizada para elegir precios
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try

            If rpvInformacion.SelectedPage.Name = "pgDatos1" Then
                grdProductos1.Rows(grdProductos1.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
                grdProductos1.Rows(grdProductos1.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
                If especial = False Then
                    grdProductos1.Rows(grdProductos1.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If

            If rpvInformacion.SelectedPage.Name = "pgDatos2" Then
                grdProductos2.Rows(grdProductos2.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
                grdProductos2.Rows(grdProductos2.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
                If especial = False Then
                    grdProductos2.Rows(grdProductos2.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And grdProductos1.Focused = True Then
            fnAgregar_Productos(grdProductos1)
        End If

        b.fnGrid_seleccionarEspacio(grdProductos1, 0, e, True)
    End Sub

    Private Sub grdProductos2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdProductos2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And grdProductos2.Focused = True Then
            fnAgregar_Productos(grdProductos2)
        End If

        b.fnGrid_seleccionarEspacio(grdProductos2, 0, e, True)
    End Sub


    Private Sub grdProductos1_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grdProductos1.CellDoubleClick
        Try
            Dim estado As Integer = CType(grdProductos1.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(grdProductos1.Rows(grdProductos1.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(grdProductos1.Rows(grdProductos1.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codCliente
                frmBuscarArticuloPrecios.bitOfertas = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdProductos2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles grdProductos2.CellDoubleClick
        Try
            Dim estado As Integer = CType(grdProductos2.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(grdProductos2.Rows(grdProductos2.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(grdProductos2.Rows(grdProductos2.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codCliente
                frmBuscarArticuloPrecios.bitOfertas = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = grdProductos1.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = grdProductos1.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = grdProductos1.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = grdProductos1.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = grdProductos1.Rows(fila).Cells("minimo").Value

            'Si el saldo es menor que el minimo y bitVentaMaxima = true, se activa la restriccion
            'Pero si la cantidadMaxima es igual a cero no se valida
            If saldo < minimo And valida = True Then
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


    Private Sub grdTipoVehiculo_ValueChanged(sender As Object, e As EventArgs) Handles grdTipoVehiculo.ValueChanged
        'contador
        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblContador, "chmAgregar")
    End Sub

    Private Sub chkTodosTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosTipo.CheckedChanged
        Try
            'Llamamos a la funcion que activa o desactiva los filtros
            mdlPublicVars.fnCheckbox_ActivaDesactivar(grdTipoVehiculo, chkTodosTipo.Checked)

        Catch ex As Exception
        End Try
    End Sub


    Private Sub grdProductos1_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles grdProductos1.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If grdProductos1.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(grdProductos2.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos2_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles grdProductos2.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If grdProductos2.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(grdProductos2.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdProductos1_SelectionChanged(sender As Object, e As EventArgs) Handles grdProductos1.SelectionChanged
        fnInformacion(grdProductos1)
    End Sub

    Private Sub grdProductos2_SelectionChanged(sender As Object, e As EventArgs) Handles grdProductos2.SelectionChanged
        fnInformacion(grdProductos2)
    End Sub



    'iformacion del articulo
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


        Catch ex As Exception
            RadMessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub btnBusqueda_Click(sender As Object, e As EventArgs) Handles btnBusqueda.Click

        fnLlenar_productos()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If rpvInformacion.SelectedPage.Name = "pgDatos1" Then
            fnAgregar_Productos(grdProductos1)
        End If

        If rpvInformacion.SelectedPage.Name = "pgDatos2" Then
            fnAgregar_Productos(grdProductos2)
        End If

    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
