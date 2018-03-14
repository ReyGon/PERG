Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmBuscarArticuloProductosNuevos
    Dim permiso As New clsPermisoUsuario
    Dim _opcionRetorno As String
    Private _codClie As Integer
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

    Public Property OpcionRetorno() As String
        Get
            OpcionRetorno = _opcionRetorno
        End Get
        Set(ByVal value As String)
            _opcionRetorno = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Private Sub frmBuscarArticuloProductosNuevos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdProductos.ImageList = frmControles.ImageListAdministracion
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)

            fnLlenar_productos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenar_productos()
        Try
            Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
            Dim diferenciaMes As DateTime = fechaActual.AddMonths(-mdlPublicVars.Empresa_MesesUltimosProductos)

            Me.grdProductos.DataSource = Nothing
            'ulo.tblUnidadMedida.nombre, txmSurtir = 0)
            Dim cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, diferenciaMes.ToShortDateString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, "", "", codClie, 4, True, False, "")
            grdProductos.DataSource = mdlPublicVars.EntitiToDataTable(cons)
            fnConfiguracion()
        Catch ex As Exception
            'Me.grdProductos.Rows.Clear()
            grdProductos.DataSource = Nothing
        End Try

        If Me.grdProductos.Rows.Count <= 0 Then
        Else
            grdProductos.Focus()
            grdProductos.Rows(0).IsCurrent = True
            grdProductos.Columns(2).IsCurrent = True
            'fnProductos_agregados(grdProductos)
        End If
        mdlPublicVars.fnGrid_iconos(Me.grdProductos)
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion()
        Try
            Me.grdProductos.Columns(1).IsVisible = False 'id
            Me.grdProductos.Columns(11).IsVisible = False 'observacion
            Me.grdProductos.Columns(12).IsVisible = False 'empaque
            Me.grdProductos.Columns(14).IsVisible = False 'clrEstado
            Me.grdProductos.Columns(15).IsVisible = False 'numero de articulo en catalogo
            Me.grdProductos.Columns(16).IsVisible = False 'fecha ultima compra
            Me.grdProductos.Columns(17).IsVisible = False 'marca
            Me.grdProductos.Columns(18).IsVisible = False 'bitVentaMaxima
            Me.grdProductos.Columns(19).IsVisible = False 'minimo
            grdProductos.Columns("TipoPrecio").IsVisible = False 'minimo
            grdProductos.Columns("Compatibilidad").IsVisible = False 'compatibilidad

            Me.grdProductos.Columns(0).Width = 60 ' agregar
            Me.grdProductos.Columns(2).Width = 70 ' codigo
            Me.grdProductos.Columns(3).Width = 180 ' nombre
            Me.grdProductos.Columns(4).Width = 70 ' cantidad
            Me.grdProductos.Columns(5).Width = 70 ' existencia
            Me.grdProductos.Columns(6).Width = 70 ' reserva
            Me.grdProductos.Columns(7).Width = 70 ' transito
            Me.grdProductos.Columns(8).Width = 50 ' costo
            Me.grdProductos.Columns(9).Width = 70 ' precio
            Me.grdProductos.Columns(10).Width = 70 ' cantidadmax
            Me.grdProductos.Columns(11).Width = 50 ' observacion
            Me.grdProductos.Columns(12).Width = 60 'unidadempaque
            Me.grdProductos.Columns(13).Width = 70 'surtir

            Me.grdProductos.Columns(0).ReadOnly = False
            Me.grdProductos.Columns(1).ReadOnly = True
            Me.grdProductos.Columns(2).ReadOnly = True
            Me.grdProductos.Columns(3).ReadOnly = True
            Me.grdProductos.Columns(4).ReadOnly = False
            Me.grdProductos.Columns(5).ReadOnly = True
            Me.grdProductos.Columns(6).ReadOnly = True
            Me.grdProductos.Columns(7).ReadOnly = True
            Me.grdProductos.Columns(8).ReadOnly = False
            Me.grdProductos.Columns(9).ReadOnly = True
            Me.grdProductos.Columns(10).ReadOnly = True
            Me.grdProductos.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txmCosto")

            If bitCliente = True Or bitDevolucionCliente = True Then
                Me.grdProductos.Columns("txmCosto").IsVisible = False
                Me.grdProductos.Columns("txbPrecio").IsVisible = True
                Me.grdProductos.Columns("Transito").IsVisible = False
            ElseIf bitProveedor = True Or bitMovimientoInventario = True Then
                Me.grdProductos.Columns("Reserva").IsVisible = False
                Me.grdProductos.Columns("clrEstado").IsVisible = False
                Me.grdProductos.Columns("txbPrecio").IsVisible = False
                Me.grdProductos.Columns("txmSurtir").IsVisible = False
                Me.grdProductos.Columns("CantidadMax").IsVisible = False
                Me.grdProductos.Columns.Move(8, 5)
            ElseIf OpcionRetorno = "consulta" Then
                Me.grdProductos.Columns("txmCosto").IsVisible = False
                Me.grdProductos.Columns("clrEstado").IsVisible = False
                Me.grdProductos.Columns("txbPrecio").IsVisible = False
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

        If bitCliente = True Then
            If mdlPublicVars.superSearchInventario <> frmSalidas.cmbInventario.SelectedValue Then
                RadMessageBox.Show("No se pueden agregar productos de diferente inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If
        End If

        For index = 0 To Me.grdProductos.Rows.Count - 1
            'agrega = CType(Me.grdProductos.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then
            cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
            surtir = Me.grdProductos.Rows(index).Cells("txmSurtir").Value

            If cantidad > 0 Or surtir > 0 Then
                cont += 1
                If cont = 1 Then
                    If bitCliente = True Then
                        frmSalidas.fnRemoverFila()
                    ElseIf bitProveedor = True Then
                        frmEntrada.fnRemoverFila()
                    ElseIf bitMovimientoInventario = True Then
                        frmMovimientoInventarios.fnRemoverFila()
                    ElseIf bitDevolucionCliente = True Then
                        frmClienteDevolucion.fnRemoverFila()
                    End If
                End If

                id = Me.grdProductos.Rows(index).Cells(1).Value
                codigo = Me.grdProductos.Rows(index).Cells(2).Value
                nombre = Me.grdProductos.Rows(index).Cells(3).Value
                tipoPrecio = Me.grdProductos.Rows(index).Cells("TipoPrecio").Value

                Try
                    precio = Me.grdProductos.Rows(index).Cells("txbPrecio").Value
                Catch ex As Exception
                    precio = 0
                End Try

                Try
                    costo = Me.grdProductos.Rows(index).Cells("txmCosto").Value
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
                            frmSalidas.fnAgregar_Articulos(If(surtir > 0 And cantidad = 0, True, False))
                        Else
                            Me.grdProductos.Rows(index).Cells("txmCantidad").BeginEdit()
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
            Me.grdProductos.Rows(index).Cells("txmCantidad").Value = 0
            Me.grdProductos.Rows(index).Cells("txmSurtir").Value = 0
        Next

        If cont > 0 Then
            If bitCliente = True Then
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

    'Funcion utilizada para elegir precios
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

    Private Sub grdInformacion1_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdProductos.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codClie
                frmBuscarArticuloPrecios.bitNuevos = True
                frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

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

    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdProductos.Focused = True Then
            fnAgregar_Productos()
        End If

        b.fnGrid_seleccionarEspacio(grdProductos, 0, e, True)
    End Sub

    Private Sub grdProductos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String

            Try
                observacion = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(Me.grdProductos.Rows(Me.grdProductos.SelectedRows(0).Index).Cells("Compatibilidad").Value, String)
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
            frmDocumentosSalida.txtTitulo.Text = "Productos Nuevos"
            frmDocumentosSalida.grd = Me.grdProductos
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
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
