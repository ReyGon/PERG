Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls


Public Class frmBuscarArticuloPendienteSurtir
    Public salida As Integer = 0
    Public cliente As Integer = 0
    Public inventario As Integer = 0
    Private permiso As New clsPermisoUsuario
    Public grd As New RadGridView
    Dim b As New clsBase

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

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

    Private Sub frmBuscarArticuloPendienteSurtir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(grdDocumento)
            mdlPublicVars.fnFormatoGridEspeciales(grdPendientes)
            fnLlenaDocumento(grd)
            fnLlenaPendientes()
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenaDocumento(ByVal grid As RadGridView)
        Try
            Me.grdDocumento.Rows.Clear()
            Dim surtir As Integer = 0
            Dim idSurtir As Integer = 0
            If salida = 0 Then
                Dim index = 0
                For index = 0 To grid.Rows.Count - 1
                    Dim articulo As String = CType(grid.Rows(index).Cells("txbProducto").Value, String)

                    If articulo IsNot Nothing Then
                        surtir = CType(grid.Rows(index).Cells("txmCantidadSurtir").Value, Integer)
                        idSurtir = CType(grid.Rows(index).Cells("idSurtir").Value, Integer)
                        If surtir > 0 And idSurtir = 0 Then
                            Dim id As Integer = CType(grid.Rows(index).Cells("Id").Value, Integer)
                            Dim codigo As String = CType(grid.Rows(index).Cells("txmCodigo").Value, String)
                            Dim precio As Decimal = CType(grid.Rows(index).Cells("Precio").Value, Decimal)

                            Dim art As tblInventario = (From x In ctx.tblInventarios.AsEnumerable Where x.idArticulo = id And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                                      Select x).FirstOrDefault

                            Dim fila As Object()
                            fila = {False, codigo, articulo, surtir, art.saldo, art.reserva, precio}
                            grdDocumento.Rows.Add(fila)

                        End If
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenaPendientes()
        Try
            'Obtenemos los articulos pendientes por surtir de ese documento

            'Dim consulta = ctx.sp_buscar_Pendientes(mdlPublicVars.idEmpresa, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, cliente)

            'Me.grdPendientes.DataSource = EntitiToDataTable(consulta)
            'mdlPublicVars.fnGrid_iconos(grdPendientes)
            'fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion()
        Try
            grdPendientes.Columns(1).IsVisible = False 'codSurtir
            grdPendientes.Columns(2).IsVisible = False 'id
            'grdPendientes.Columns(12).IsVisible = False 'observacion
            grdPendientes.Columns(13).IsVisible = False 'empaque
            grdPendientes.Columns(14).IsVisible = False 'clrEstado
            grdPendientes.Columns(15).IsVisible = False 'numero de articulo en catalogo
            grdPendientes.Columns(16).IsVisible = False 'fecha ultima compra
            grdPendientes.Columns(17).IsVisible = False 'marca
            grdPendientes.Columns(18).IsVisible = False 'bitVentaMaxima
            grdPendientes.Columns(19).IsVisible = False 'minimo
            grdPendientes.Columns(20).IsVisible = False 'minimo
            grdPendientes.Columns(21).IsVisible = False 'minimo
            grdPendientes.Columns("TipoPrecio").IsVisible = False 'minimo
            grdPendientes.Columns("Compatibilidad").IsVisible = False 'compatibilidad

            grdPendientes.Columns(0).Width = 60 ' agregar
            grdPendientes.Columns(3).Width = 70 ' codigo
            grdPendientes.Columns(4).Width = 180 ' nombre
            grdPendientes.Columns(5).Width = 70 ' cantidad
            grdPendientes.Columns(6).Width = 70 ' saldo
            grdPendientes.Columns(7).Width = 70 ' existencia
            grdPendientes.Columns(8).Width = 70 ' reserva
            grdPendientes.Columns(9).Width = 70 ' transito
            grdPendientes.Columns(10).Width = 50 ' costo
            grdPendientes.Columns(11).Width = 70 ' precio
            grdPendientes.Columns(12).Width = 70 ' cantidadmax
            grdPendientes.Columns(13).Width = 50 ' observacion
            grdPendientes.Columns(14).Width = 60 'unidadempaque
            grdPendientes.Columns(15).Width = 70 'surtir

            grdPendientes.Columns(0).ReadOnly = False
            grdPendientes.Columns(1).ReadOnly = True
            grdPendientes.Columns(2).ReadOnly = True
            grdPendientes.Columns(3).ReadOnly = True
            grdPendientes.Columns(4).ReadOnly = True
            grdPendientes.Columns(5).ReadOnly = False
            grdPendientes.Columns(6).ReadOnly = True
            grdPendientes.Columns(7).ReadOnly = True
            grdPendientes.Columns(8).ReadOnly = True
            grdPendientes.Columns(9).ReadOnly = True
            grdPendientes.Columns(10).ReadOnly = False
            grdPendientes.Columns(11).ReadOnly = True
            grdPendientes.Columns(12).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(grdPendientes, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdPendientes, "txmCosto")
            If bitProveedor = True Or bitMovimientoInventario = True Then
                grdPendientes.Columns("Reserva").IsVisible = False
                grdPendientes.Columns("clrEstado").IsVisible = False
                grdPendientes.Columns("txbPrecio").IsVisible = False
                grdPendientes.Columns("txmSurtir").IsVisible = False
                grdPendientes.Columns("CantidadMax").IsVisible = False
                grdPendientes.Columns.Move(8, 5)

            ElseIf bitCliente = True Or bitDevolucionCliente = True Then
                grdPendientes.Columns("txmCosto").IsVisible = False
                grdPendientes.Columns("txbPrecio").IsVisible = True
                grdPendientes.Columns("Transito").IsVisible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdDocumento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdDocumento.Focused = True Then
            fnAgregar_Productos()
        End If
        b.fnGrid_seleccionarEspacio(grdDocumento, 0, e, True)
    End Sub

    Private Sub grdPendientes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdPendientes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdDocumento.Focused = True Then
            fnAgregar_Productos()
        End If
        b.fnGrid_seleccionarEspacio(grdPendientes, 0, e, True)
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdPendientes.Rows(Me.grdPendientes.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdPendientes.Rows(Me.grdPendientes.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            If especial = False Then
                Me.grdPendientes.Rows(Me.grdPendientes.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Agregar productos del inventario principal
    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdPendientes.KeyPress
        If Me.grdPendientes.Rows.Count > 0 Then
            If Me.grdPendientes.CurrentRow.Index >= 0 Then
                Dim col As Integer = Me.grdPendientes.CurrentColumn.Index
                Dim nombre As String = Me.grdPendientes.Columns(col).Name
                If e.KeyChar = ChrW(Keys.Enter) And Me.grdPendientes.Focused = True Then
                    fnAgregar_Productos()
                End If
            End If
        End If
    End Sub

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdPendientes.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdPendientes.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdPendientes.Rows(Me.grdPendientes.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.bitPrincipal = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Funcion que se utiliza para agregar los productos en el grid 
    Private Sub fnAgregar_Productos()
        Dim index As Integer
        Dim cont As Integer = 0
        Dim id As Integer = 0
        Dim cantidad As Integer = 0
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim precio As Decimal = 0
        Dim costo As Decimal = 0
        Dim surtir As Integer = 0
        Dim codSurtir As Integer = 0
        Dim tipoPrecio As Integer = 0
        If salida > 0 Then
            'Primero consultamos para saber si la salida no ha sido un despacho
            Dim pedido As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = salida Select x).FirstOrDefault

            If pedido.despachar = True Then
                alerta.contenido = "No se pueden agregar pendientes, el pedido ha sido DESPACHADO"
                alerta.fnErrorContenido()
                Exit Sub
            End If
        End If

        mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario

        If bitCliente = True And bitDevolucionCliente = False Then
            If mdlPublicVars.superSearchInventario <> frmSalidas.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If

        For index = 0 To grdPendientes.Rows.Count - 1
            'agrega = CType(grd.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then
            cantidad = grdPendientes.Rows(index).Cells("txmCantidad").Value

            If cantidad > 0 Then
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
                id = Me.grdPendientes.Rows(index).Cells("ID").Value
                codigo = Me.grdPendientes.Rows(index).Cells("Codigo").Value
                nombre = Me.grdPendientes.Rows(index).Cells("nombre").Value
                surtir = Me.grdPendientes.Rows(index).Cells("Saldo").Value
                codSurtir = Me.grdPendientes.Rows(index).Cells("codSurtir").Value
                tipoPrecio = Me.grdPendientes.Rows(index).Cells("TipoPrecio").Value
                Try
                    precio = Me.grdPendientes.Rows(index).Cells("txbPrecio").Value
                Catch ex As Exception
                    precio = 0
                End Try

                mdlPublicVars.superSearchId = id
                mdlPublicVars.superSearchCodigo = codigo
                mdlPublicVars.superSearchNombre = nombre
                mdlPublicVars.superSearchCantidad = cantidad
                mdlPublicVars.superSearchSurtir = surtir
                mdlPublicVars.superSearchCodSurtir = codSurtir
                mdlPublicVars.superSearchTipoPrecio = tipoPrecio
                Try
                    costo = grdPendientes.Rows(index).Cells("txmCosto").Value
                Catch ex As Exception
                    costo = 0
                End Try

                If bitCliente = True And bitDevolucionCliente = False Then
                    mdlPublicVars.superSearchPrecio = precio
                    'Verificamos si la empresa valida la venta maxima por cliente
                    If Empresa_ValidaVenta = True Then
                        If fnCantidadMax(index) = False Then
                            frmSalidas.fnAgregar_Pendientes()
                        Else
                            Me.grdPendientes.Rows(index).Cells("txmCantidad").BeginEdit()
                            Exit For
                        End If
                    Else
                        frmSalidas.fnAgregar_Pendientes()
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
                grdPendientes.Rows(index).Cells("txmCantidad").Value = 0

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
    End Sub

    'Funcion utilizada para agregar los formatos al grid
    Private Sub grdProductos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdPendientes.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If Me.grdPendientes.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(Me.grdPendientes.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se maneja para poder ver los precios del producto
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdPendientes.KeyDown
        Try
            If Me.grdPendientes.CurrentRow.Index >= 0 Then
                Dim col As Integer = Me.grdPendientes.CurrentColumn.Index
                Dim nombre As String = Me.grdPendientes.Columns(col).Name
                If nombre = "txbPrecio" And e.KeyCode = Keys.F2 Then
                    Dim estado As Integer = CType(Me.grdPendientes.Rows(Me.grdPendientes.CurrentRow.Index).Cells("clrEstado").Value, Integer)
                    If (estado = 1 Or estado = 2) Then
                        frmBuscarArticuloPrecios.Text = "Precios"
                        frmBuscarArticuloPrecios.codigo = CType(Me.grdPendientes.Rows(Me.grdPendientes.CurrentRow.Index).Cells("ID").Value, Integer)
                        frmBuscarArticuloPrecios.bitPrincipal = True
                        frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    'DOC SALIDA < DOCUMENTO >
    Private Sub fnSalidaDocumento() Handles Me.panel0
        Try
            
            frmDocumentosSalida.txtTitulo.Text = "Pendiente por Surtir < DOCUMENTO >"
            frmDocumentosSalida.grd = Me.grdDocumento
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = cliente 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    'DOC SALIDA < ACUMULADO >
    Private Sub fnSalidaAcumulado() Handles Me.panel1
        Try
            frmDocumentosSalida.txtTitulo.Text = "Pendiente por Surtir < ACUMULADO >"
            frmDocumentosSalida.grd = Me.grdPendientes
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = cliente 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = Me.grdPendientes.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = Me.grdPendientes.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = Me.grdPendientes.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = Me.grdPendientes.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = Me.grdPendientes.Rows(fila).Cells("minimo").Value

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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnAgregar_Productos()
    End Sub
End Class
