Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmBuscarArticuloCatalogo
    Private permiso As New clsPermisoUsuario
    Private _codigo As Integer
    Private _OpcionRetorno As String
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

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
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

    Private Sub frmBuscarArticuloCatalogo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdInformacion.ImageList = frmControles.ImageListAdministracion
            mdlPublicVars.fnGrid_iconos(Me.grdInformacion)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdInformacion)
            mdlPublicVars.comboActivarFiltroLista(Me.cmbCatalogo)
            fnLimpiar()
            fnLlenarDatos()
            fnLlenarCombo()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar los datos del articulo
    Private Sub fnLlenarDatos()
        Try
            'Llenamos el encabezado
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault
            lblArticulo.Text = articulo.nombre1
            lblCodigo.Text = articulo.codigo1
        Catch ex As Exception
        End Try
    End Sub

    'Funcion que se utilizara para llenar los combos
    Private Sub fnLlenarCombo()

        'Obtenemos los catalogos de ese articulo
        Dim catalogos = (From x In ctx.tblArticulo_Catalogo Where x.articulo = codigo _
                            Select Codigo = x.imagen, Nombre = x.observacion)

        'Agregamos los catalogos al combo
        With Me.cmbCatalogo
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = catalogos
        End With
    End Sub

    Private Sub fnLlenarDatos(ByVal catalogo As String)
        Try
            grdInformacion.DataSource = Nothing
            'Obtenemos la direccion del catalogo
            If catalogo IsNot Nothing Then
                cargaFoto(catalogo)
                Dim cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, catalogo, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, "", "", codClie, 3, True, False, "")

                grdInformacion.DataSource = mdlPublicVars.EntitiToDataTable(cons)

                If Me.grdInformacion.Rows.Count > 0 Then
                    grdInformacion.Focus()
                    grdInformacion.Rows(0).IsCurrent = True
                    grdInformacion.Columns(2).IsCurrent = True
                End If

                mdlPublicVars.fnGrid_iconos(Me.grdInformacion)

                fnConfiguracion()
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Funcion que configura el ancho de las columnas, y el formato
    Private Sub fnConfiguracion()
        Try
            Me.grdInformacion.Columns(1).IsVisible = False 'id
            Me.grdInformacion.Columns(11).IsVisible = False 'observacion
            Me.grdInformacion.Columns(12).IsVisible = False 'empaque
            Me.grdInformacion.Columns(14).IsVisible = False 'clrEstado
            Me.grdInformacion.Columns(16).IsVisible = False 'fecha ultima compra
            Me.grdInformacion.Columns(17).IsVisible = False 'marca
            Me.grdInformacion.Columns(18).IsVisible = False 'bitVentaMaxima
            Me.grdInformacion.Columns(19).IsVisible = False 'minimo
            Me.grdInformacion.Columns("TipoPrecio").IsVisible = False 'minimo
            Me.grdInformacion.Columns("Compatibilidad").IsVisible = False 'compatibilidad

            Me.grdInformacion.Columns(0).Width = 60 ' agregar
            Me.grdInformacion.Columns(2).Width = 45 ' codigo
            Me.grdInformacion.Columns(3).Width = 230 ' nombre
            Me.grdInformacion.Columns(4).Width = 70 ' cantidad
            Me.grdInformacion.Columns(5).Width = 50 ' existencia
            Me.grdInformacion.Columns(6).Width = 50 ' reserva
            Me.grdInformacion.Columns(7).Width = 50 ' transito
            Me.grdInformacion.Columns(8).Width = 50 ' costo
            Me.grdInformacion.Columns(9).Width = 70 ' precio
            Me.grdInformacion.Columns(10).Width = 50 ' cantidadmax
            Me.grdInformacion.Columns(11).Width = 50 ' observacion
            Me.grdInformacion.Columns(12).Width = 60 'unidadempaque
            Me.grdInformacion.Columns(13).Width = 60 'surtir

            Me.grdInformacion.Columns(0).ReadOnly = False
            Me.grdInformacion.Columns(1).ReadOnly = True
            Me.grdInformacion.Columns(2).ReadOnly = True
            Me.grdInformacion.Columns(3).ReadOnly = True
            Me.grdInformacion.Columns(4).ReadOnly = False
            Me.grdInformacion.Columns(5).ReadOnly = True
            Me.grdInformacion.Columns(6).ReadOnly = True
            Me.grdInformacion.Columns(7).ReadOnly = True
            Me.grdInformacion.Columns(8).ReadOnly = False
            Me.grdInformacion.Columns(9).ReadOnly = True
            Me.grdInformacion.Columns(10).ReadOnly = True
            Me.grdInformacion.Columns(11).ReadOnly = True

            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdInformacion, "txbPrecio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdInformacion, "txmCosto")

            grdInformacion.Columns("numeroArt").HeaderText = "Imagen"
            If bitCliente = True Or bitDevolucionCliente = True Then
                Me.grdInformacion.Columns("txmCosto").IsVisible = False
                Me.grdInformacion.Columns("txbPrecio").IsVisible = True
                Me.grdInformacion.Columns("Transito").IsVisible = False
            ElseIf bitProveedor = True Or bitMovimientoInventario = True Then
                Me.grdInformacion.Columns("Reserva").IsVisible = False
                Me.grdInformacion.Columns("clrEstado").IsVisible = False
                Me.grdInformacion.Columns("txbPrecio").IsVisible = False
                Me.grdInformacion.Columns("txmSurtir").IsVisible = False
                Me.grdInformacion.Columns("CantidadMax").IsVisible = False
                Me.grdInformacion.Columns.Move(8, 5)
            ElseIf OpcionRetorno = "consulta" Then
                Me.grdInformacion.Columns("txmCosto").IsVisible = False
                Me.grdInformacion.Columns("clrEstado").IsVisible = False
                Me.grdInformacion.Columns("txbPrecio").IsVisible = False
            End If

            'Reordenar le imagen
            Dim c As Integer = grdInformacion.Columns("numeroArt").Index
            grdInformacion.Columns.Move(c, 0)

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

        For index = 0 To Me.grdInformacion.Rows.Count - 1
            'agrega = CType(Me.grdInformacion.Rows(index).Cells(0).Value, Boolean)
            ' If agrega = True Then
            cantidad = Me.grdInformacion.Rows(index).Cells("txmCantidad").Value
            surtir = Me.grdInformacion.Rows(index).Cells("txmSurtir").Value

            If cantidad > 0 Or surtir = 0 Then
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

                id = Me.grdInformacion.Rows(index).Cells(2).Value
                codigo = Me.grdInformacion.Rows(index).Cells(3).Value
                nombre = Me.grdInformacion.Rows(index).Cells(4).Value
                tipoPrecio = Me.grdInformacion.Rows(index).Cells("TipoPrecio").Value

                Try
                    precio = Me.grdInformacion.Rows(index).Cells("txbPrecio").Value
                Catch ex As Exception
                    precio = 0
                End Try

                Try
                    costo = Me.grdInformacion.Rows(index).Cells("txmCosto").Value
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
                            Me.grdInformacion.Rows(index).Cells("txmCantidad").BeginEdit()
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
            Me.grdInformacion.Rows(index).Cells("txmCantidad").Value = 0
            Me.grdInformacion.Rows(index).Cells("txmSurtir").Value = 0
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

    Private Sub cargaFoto(ByVal direccion As String)
        'Quitamos la imagen que tenia
        If pbxFoto.Image IsNot Nothing Then
            pbxFoto.Image = Nothing
        End If

        Dim picture = New Bitmap(direccion)
        With pbxFoto
            .Image = picture
            .SizeMode = PictureBoxSizeMode.StretchImage
            .BorderStyle = BorderStyle.Fixed3D
        End With
    End Sub

    Private Sub fnLimpiar()
        Try
            With pbxFoto
                .Image = Nothing
            End With
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para dar
    Private Sub grdInformacion1_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdInformacion.CellFormatting
        Try
            'Cambia el color de la fuente(letra) en el grid
            If Me.grdInformacion.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Green)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                End If

                Dim inicio As Integer = CType(Me.grdInformacion.Columns("Existencia").Index, Integer)
                mdlPublicVars.GridColor_fila(e, Color.Blue, inicio)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdInformacion1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdInformacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And Me.grdInformacion.Focused = True Then
            fnAgregar_Productos()
        End If

        b.fnGrid_seleccionarEspacio(grdInformacion, 0, e, True)
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdInformacion.Rows(Me.grdInformacion.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdInformacion.Rows(Me.grdInformacion.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            If especial = False Then
                Me.grdInformacion.Rows(Me.grdInformacion.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdInformacion1_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdInformacion.CellDoubleClick
        Try
            Dim estado As Integer = CType(Me.grdInformacion.Rows(e.RowIndex).Cells("clrEstado").Value, Integer)
            If e.Column.Name = "txbPrecio" Then 'And (estado = 1 Or estado = 2)
                frmBuscarArticuloPrecios.Text = "Precios"
                frmBuscarArticuloPrecios.codigo = CType(Me.grdInformacion.Rows(Me.grdInformacion.CurrentRow.Index).Cells("ID").Value, Integer)
                frmBuscarArticuloPrecios.precioNormal = CType(Me.grdInformacion.Rows(Me.grdInformacion.CurrentRow.Index).Cells("txbPrecio").Value, Decimal)
                frmBuscarArticuloPrecios.codClie = Me.codClie
                frmBuscarArticuloPrecios.bitCatalogo = True
                permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCatalogo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCatalogo.SelectedValueChanged
        Try
            fnLlenarDatos(cmbCatalogo.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdInformacion_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdInformacion.SelectionChanged
        Try
            'Modificamos la observacion y el empaque
            Dim observacion As String
            Dim empaque As String
            Dim marca As String
            Dim compatibilidad As String

            Try
                observacion = CType(Me.grdInformacion.Rows(Me.grdInformacion.SelectedRows(0).Index).Cells("Observacion").Value, String)
            Catch ex As Exception
                observacion = ""
            End Try
            Try
                empaque = CType(Me.grdInformacion.Rows(Me.grdInformacion.SelectedRows(0).Index).Cells("UnidadEmpaque").Value, String)
            Catch ex As Exception
                empaque = ""
            End Try

            Try
                marca = CType(Me.grdInformacion.Rows(Me.grdInformacion.SelectedRows(0).Index).Cells("Marca").Value, String)
            Catch ex As Exception
                marca = ""
            End Try

            Try
                compatibilidad = CType(Me.grdInformacion.Rows(Me.grdInformacion.SelectedRows(0).Index).Cells("Compatibilidad").Value, String)
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

    'Funcion que utiliza para validar si la cantidad a comprar sobrepasa el limite de compra
    Private Function fnCantidadMax(ByVal fila As Integer) As Boolean
        Try
            'Obtenemos la cantidad que comprara y la cantidad Max
            Dim cantidad As Integer = Me.grdInformacion.Rows(fila).Cells("txmCantidad").Value
            Dim limite As Integer = Me.grdInformacion.Rows(fila).Cells("CantidadMax").Value
            Dim valida As Boolean = Me.grdInformacion.Rows(fila).Cells("bitVentaMaxima").Value
            Dim saldo As Integer = Me.grdInformacion.Rows(fila).Cells("Existencia").Value
            Dim minimo As Integer = Me.grdInformacion.Rows(fila).Cells("minimo").Value

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

    'SALIR
    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    'AGREGAR IMPRESION
    Private Sub fnImprimir() Handles Me.panel1
        Try
            Dim informacion As String()
            Dim separador As Char = "-"

            informacion = Split(CStr(cmbCatalogo.SelectedValue), separador)

            Dim pagina As String = Trim(informacion(0))
            Dim direccion As String = Path.Combine(mdlPublicVars.BuscarArticulo_CarpetaCatalogo, (pagina & ".png"))
            fnAgregarImpresion(direccion)
            RadMessageBox.Show("Foto agregada a la lista de impresión, exitosamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        Catch ex As Exception
            RadMessageBox.Show("Ocurrio un error al intentar agregar la foto a la lista de impresion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'DOCUMENTO SALIDA
    Private Sub fnDocSalida() Handles Me.panel0
        Try
            frmDocumentosSalida.txtTitulo.Text = "Catálogo de: " & lblArticulo.Text
            frmDocumentosSalida.grd = Me.grdInformacion
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codClie 'codigo del clientes.
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para agregar la foto actual a la lista de impresion
    Private Sub fnAgregarImpresion(ByVal ruta As String)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor

        Dim tipoImpresion As Integer = (From x In ctx.tblTipoImpresions Where x.bitFoto = True And x.nombre.Contains("Catalogo") _
                                        Select x.codigo).FirstOrDefault

        'Creamos el nuevo registro
        Dim impresion As New tblImpresion
        impresion.cliente = codClie
        impresion.bitImpreso = False
        impresion.fechaRegistro = fechaServidor
        impresion.tipoImpresion = tipoImpresion
        impresion.descripcion = lblArticulo.Text
        impresion.url = ruta
        impresion.usuarioRegistro = mdlPublicVars.idUsuario

        'Añadimos el registro
        ctx.AddTotblImpresions(impresion)
        ctx.SaveChanges()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnAgregar_Productos()
    End Sub
End Class