Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmBuscarArticuloSustitutos
    Private _codclie As Integer
    Private _codvendedor As Integer
    Private _OpcionRetorno As String

    Public frmRetornoSalidas As frmSalidas
    Dim b As New clsBase
    Dim alertar As New bl_Alertas
    Dim dt As New clsDevuelveTabla
    Dim cheques As Boolean = True
    Public codigoArticulo As Integer = 0

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

    Private permiso As New clsPermisoUsuario

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

    Private Sub FrmBuscarArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.grdSustitutos.ImageList = frmControles.ImageListAdministracion
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdSustitutos)
        mdlPublicVars.fnGrid_iconos(Me.grdSustitutos)

        'fnLlenar_sustitutos(codigoArticulo)
        fnLlenarGrid()
    End Sub

    '----------------------------EVENTOS DE COLORES PARA GRID DE PRODUCTOS Y SUSTITUTOS.

    Private Sub fnLlenar_sustitutos(ByVal codigoBuscar As Integer)
        Try
            'Llenamos el encabezado
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigoBuscar Select x).FirstOrDefault
            lblArticulo.Text = articulo.nombre1
            lblCodigo.Text = articulo.codigo1


            Dim categoria = (From x In ctx.tblSustitutoes _
                           Where x.idarticulo = codigoBuscar And x.idempresa = mdlPublicVars.idEmpresa And x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                           And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                           Select x).ToList

            Dim listaCategoria As List(Of tblSustituto) = categoria

            Dim contador As Integer = 0
            Dim valor As New tblSustituto
            For Each valor In listaCategoria
                contador = contador + 1
            Next

            If contador > 0 Then
                Dim categoriaSustituto As Integer = CType(valor.idSustitutoCategoria, Integer)
                Dim sustitutos = (From x In ctx.tblSustitutoes Join y In ctx.tblArticuloes On x.idarticulo Equals y.idArticulo _
                                Where x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                And x.idempresa = mdlPublicVars.idEmpresa And x.idSustitutoCategoria = categoriaSustituto And x.idarticulo <> codigoBuscar _
                                Select ID = y.idArticulo, Codigo = y.codigo1, Nombre = y.nombre1, txmCantidad = 0, _
                                Existencia = (From v In ctx.tblInventarios Where v.idArticulo = y.idArticulo And v.tblArticulo.empresa = mdlPublicVars.idEmpresa Select Existencia = v.saldo).FirstOrDefault, _
                                Reserva = (From w In ctx.tblInventarios Where w.idArticulo = w.idArticulo And w.tblArticulo.empresa = mdlPublicVars.idEmpresa Select w.reserva).FirstOrDefault, _
                                Transito = (From w In ctx.tblInventarios Where w.idArticulo = w.idArticulo And w.tblArticulo.empresa = mdlPublicVars.idEmpresa Select w.transito).FirstOrDefault, _
                                Costo = y.costoIVA, txbPrecio = y.precioPublico, CantidadMax = 0)

                Me.grdSustitutos.DataSource = mdlPublicVars.EntitiToDataTable(sustitutos)
                mdlPublicVars.fnGrid_iconos(Me.grdSustitutos)
                fnConfiguracion()
                If Me.grdSustitutos.Rows.Count > 0 Then
                    grdSustitutos.Focus()
                    grdSustitutos.Rows(0).IsCurrent = True
                    grdSustitutos.Columns(2).IsCurrent = True
                End If

            Else
                Me.grdSustitutos.DataSource = Nothing

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnLlenarGrid()
        Try
            'Llenamos el encabezado
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigoArticulo Select x).FirstOrDefault
            lblArticulo.Text = articulo.nombre1
            lblCodigo.Text = articulo.codigo1

            Me.grdSustitutos.DataSource = Nothing

            Dim cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, codigoArticulo, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, "", "", codClie, 2, True, False, "")

            grdSustitutos.DataSource = mdlPublicVars.EntitiToDataTable(cons)
            fnConfiguracion()
        Catch ex As Exception
            'Me.grdSustitutos.Rows.Clear()
            grdSustitutos.DataSource = Nothing
        End Try

        mdlPublicVars.fnGrid_iconos(Me.grdSustitutos)
    End Sub

    'Funcion utilizada para armar la cadena
    Private Function fnCadenaDatos(ByVal tipos As List(Of tblArticulo_TipoVehiculo), ByVal modelos As List(Of tblArticuloModeloVehiculo)) As String
        Dim cadena = ""
        Dim contador As Integer = 0
        Dim tp
        If tipos IsNot Nothing Then
            For Each tp In tipos
                contador += 1
                If contador = 1 Then
                    cadena += tp.Codigo
                ElseIf contador > 1 Then
                    cadena += "," & tp.Codigo
                End If
            Next
        Else
            For Each tp In modelos
                contador += 1
                If contador = 1 Then
                    cadena += tp.Codigo
                ElseIf contador > 1 Then
                    cadena += "," & tp.Codigo
                End If
            Next
        End If
        Return cadena
    End Function

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion()
        Try
            Me.grdSustitutos.Columns(1).IsVisible = False 'id
            Me.grdSustitutos.Columns(11).IsVisible = False 'observacion
            Me.grdSustitutos.Columns(12).IsVisible = False 'empaque
            Me.grdSustitutos.Columns(14).IsVisible = False 'clrEstado
            Me.grdSustitutos.Columns(15).IsVisible = False 'numero de articulo en catalogo
            Me.grdSustitutos.Columns(16).IsVisible = False 'fecha ultima compra
            Me.grdSustitutos.Columns(17).IsVisible = False 'marca
            Me.grdSustitutos.Columns(18).IsVisible = False 'bitVentaMaxima
            Me.grdSustitutos.Columns(19).IsVisible = False 'minimo
            Me.grdSustitutos.Columns("TipoPrecio").IsVisible = False 'minimo
            Me.grdSustitutos.Columns("Compatibilidad").IsVisible = False 'compatibilidad

            Me.grdSustitutos.Columns(0).Width = 60 ' agregar
            Me.grdSustitutos.Columns(2).Width = 70 ' codigo
            Me.grdSustitutos.Columns(3).Width = 180 ' nombre
            Me.grdSustitutos.Columns(4).Width = 70 ' cantidad
            Me.grdSustitutos.Columns(5).Width = 70 ' existencia
            Me.grdSustitutos.Columns(6).Width = 70 ' reserva
            Me.grdSustitutos.Columns(7).Width = 70 ' transito
            Me.grdSustitutos.Columns(8).Width = 50 ' costo
            Me.grdSustitutos.Columns(9).Width = 70 ' precio
            Me.grdSustitutos.Columns(10).Width = 70 ' cantidadmax
            Me.grdSustitutos.Columns(11).Width = 50 ' observacion
            Me.grdSustitutos.Columns(12).Width = 60 'unidadempaque
            Me.grdSustitutos.Columns(13).Width = 70 'surtir

            Me.grdSustitutos.Columns(0).ReadOnly = False
            Me.grdSustitutos.Columns(1).ReadOnly = True
            Me.grdSustitutos.Columns(2).ReadOnly = True
            Me.grdSustitutos.Columns(3).ReadOnly = True
            Me.grdSustitutos.Columns(4).ReadOnly = False
            Me.grdSustitutos.Columns(5).ReadOnly = True
            Me.grdSustitutos.Columns(6).ReadOnly = True
            Me.grdSustitutos.Columns(7).ReadOnly = True
            Me.grdSustitutos.Columns(8).ReadOnly = False
            Me.grdSustitutos.Columns(9).ReadOnly = True
            Me.grdSustitutos.Columns(10).ReadOnly = True
            Me.grdSustitutos.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "txmCosto")

            If bitCliente = True Or bitDevolucionCliente = True Then
                Me.grdSustitutos.Columns("txmCosto").IsVisible = False
                Me.grdSustitutos.Columns("txbPrecio").IsVisible = True
                Me.grdSustitutos.Columns("Transito").IsVisible = False
            ElseIf bitProveedor = True Or bitMovimientoInventario = True Or OpcionRetorno = "devolucionCliente" Then
                Me.grdSustitutos.Columns("Reserva").IsVisible = False
                Me.grdSustitutos.Columns("clrEstado").IsVisible = False
                Me.grdSustitutos.Columns("txbPrecio").IsVisible = False
                Me.grdSustitutos.Columns("txmSurtir").IsVisible = False
                Me.grdSustitutos.Columns("CantidadMax").IsVisible = False
                Me.grdSustitutos.Columns.Move(8, 5)
            ElseIf OpcionRetorno = "consulta" Then
                Me.grdSustitutos.Columns("txmCosto").IsVisible = False
                Me.grdSustitutos.Columns("clrEstado").IsVisible = False
                Me.grdSustitutos.Columns("txbPrecio").IsVisible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            If especial = False Then
                Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
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
        Dim tipoPrecio As Integer = 0
        mdlPublicVars.superSearchInventario = mdlPublicVars.General_idTipoInventario

        If bitCliente = True And bitDevolucionCliente = False Then
            If mdlPublicVars.superSearchInventario <> frmSalidas.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If

        For index = 0 To Me.grdSustitutos.Rows.Count - 1
            'agrega = CType(Me.grdSustitutos.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then
            cantidad = Me.grdSustitutos.Rows(index).Cells("txmCantidad").Value
            surtir = Me.grdSustitutos.Rows(index).Cells("txmSurtir").Value

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

                id = Me.grdSustitutos.Rows(index).Cells(1).Value
                codigo = Me.grdSustitutos.Rows(index).Cells(2).Value
                nombre = Me.grdSustitutos.Rows(index).Cells(3).Value
                tipoPrecio = Me.grdSustitutos.Rows(index).Cells("TipoPrecio").Value
                Try
                    precio = Me.grdSustitutos.Rows(index).Cells("txbPrecio").Value
                Catch ex As Exception
                    precio = 0
                End Try

                Try
                    costo = Me.grdSustitutos.Rows(index).Cells("txmCosto").Value
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
                    If Empresa_ValidaVenta = True Then
                        If fnCantidadMax(index) = False Then
                            frmSalidas.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        Else
                            Me.grdSustitutos.Rows(index).Cells("txmCantidad").BeginEdit()
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
            End If
            Me.grdSustitutos.Rows(index).Cells("txmCantidad").Value = 0
            Me.grdSustitutos.Rows(index).Cells("txmSurtir").Value = 0
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

    Private Sub grdSustitutos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdSustitutos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdSustitutos.Focused = True Then
            fnAgregar_Productos()
        End If

        b.fnGrid_seleccionarEspacio(grdSustitutos, 0, e, True)
    End Sub

    Private Sub frmBuscarArticulo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Enter Then
            fnAgregar_Productos()
        End If
    End Sub

    Private Sub grdSustitutos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdSustitutos.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If Me.grdSustitutos.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(Me.grdSustitutos.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSustitutos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdSustitutos.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdSustitutos.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codClie
                frmBuscarArticuloPrecios.bitSustitutos = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticulo, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSustitutos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdSustitutos.SelectionChanged
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String
            Try
                observacion = CType(Me.grdSustitutos.Rows(Me.grdSustitutos.SelectedRows(0).Index).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(Me.grdSustitutos.Rows(Me.grdSustitutos.SelectedRows(0).Index).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(Me.grdSustitutos.Rows(Me.grdSustitutos.SelectedRows(0).Index).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(Me.grdSustitutos.Rows(Me.grdSustitutos.SelectedRows(0).Index).Cells("Compatibilidad").Value, String)
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

        Catch ex As Exception

        End Try

    End Sub

    'DOCUMENTO SALIDA
    Private Sub fnDocSalida() Handles Me.panel0
        Try
            frmDocumentosSalida.txtTitulo.Text = "Sustitutos de: " & lblArticulo.Text
            frmDocumentosSalida.grd = Me.grdSustitutos
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = Me.grdSustitutos.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = Me.grdSustitutos.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = Me.grdSustitutos.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = Me.grdSustitutos.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = Me.grdSustitutos.Rows(fila).Cells("minimo").Value

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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnAgregar_Productos()
    End Sub
End Class
