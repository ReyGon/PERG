Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions

Public Class frmBuscarArticuloPendientePedir
    Private _codigo As Integer
    Private permiso As New clsPermisoUsuario

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmBuscarArticuloPendientePedir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        mdlPublicVars.fnFormatoGridEspeciales(grdProductos)
        mdlPublicVars.comboActivarFiltroLista(cmbImportancia)

        fnLlenarCombo()
        fnLlenarGrid()
    End Sub

    'LLENAR GRID 
    Public Sub fnLlenarGrid()
        'Obtenemos los pendientes por pedir del cliente
        Dim datos = (From x In ctx.tblPendientePorPedirs Select idPendiente = x.codigo, Cliente = x.tblCliente.Negocio, Codigo = x.codigoArticulo, Descripcion = x.descripcion, Observacion = x.observacion, _
                        Importancia = x.tblArticuloImportancia.nombre, Creado = x.bitCreado, Anulado = x.anulado, Cantidad = x.cantidad,
                        Saldo = If(x.pendienteSurtir Is Nothing, x.saldo, x.tblSurtir.saldo))

        Me.grdDatos.DataSource = datos
        fnConfiguracion()
    End Sub

    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Dim importancia = (From x In ctx.tblArticuloImportancias Select x.codigo, x.nombre)

        With cmbImportancia
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = importancia
        End With

        'CLIENTES
        Dim clientes = (From x In ctx.tblClientes Select codigo = x.idCliente, x.Negocio)

        With cmbCliente
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "Negocio"
            .DataSource = clientes
        End With

        If codigo > 0 Then
            cmbCliente.SelectedValue = codigo
            fnLlenarDatos()
        End If

    End Sub

    'LLENAR DATOS DE CLIENTE
    Private Sub fnLlenarDatos()
        If CInt(cmbCliente.SelectedValue) > 0 Then
            Dim idCliente As Integer = cmbCliente.SelectedValue
            Dim cliente As tblCliente = (From x In ctx.tblClientes.AsEnumerable Where x.idCliente = idCliente Select x).FirstOrDefault

            lblClave.Text = cliente.clave
        End If
       
    End Sub

    'CONFIGURAR GRID
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(i).ReadOnly = True
            Next

            Me.grdDatos.Columns("idPendiente").IsVisible = False

            Me.grdDatos.Columns("crear").Width = 50
            Me.grdDatos.Columns("modificar").Width = 50
            Me.grdDatos.Columns("Cliente").Width = 100
            Me.grdDatos.Columns("Codigo").Width = 90
            Me.grdDatos.Columns("Descripcion").Width = 120
            Me.grdDatos.Columns("Observacion").Width = 110
            Me.grdDatos.Columns("Creado").Width = 60
            Me.grdDatos.Columns("Anulado").Width = 60
            Me.grdDatos.Columns("Importancia").Width = 65
            Me.grdDatos.Columns("Cantidad").Width = 70
            Me.grdDatos.Columns("Saldo").Width = 70
        End If
    End Sub

    'BOTON AGREGAR
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Not fnErrores() Then
            'Verificamos si el codigo no existe
            If Not fnBuscarArticulo(txtCodigo.Text) Then
                If RadMessageBox.Show("¿Desea agregar el pendiente por pedir?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    fnAgregarPendiente(False, txtCodigo.Text)
                    RadMessageBox.Show("Pendiente por pedir agregado exitosamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                    fnLlenarGrid()
                End If
            Else
                If RadMessageBox.Show("Ya existe un articulo con ese código, Desea agregarlo? ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    fnAgregarPendiente(True, txtCodigo.Text)
                    RadMessageBox.Show("Pendiente por pedir agregado exitosamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                    fnLlenarGrid()
                End If
            End If
        End If
    End Sub

    'BUSCA ARTICULO
    Private Function fnBuscarArticulo(ByVal codArt As String) As Boolean
        Dim articulo As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable
                                       Where x.codigo1 = codArt
                                       Select x).FirstOrDefault

        If articulo IsNot Nothing Then
            Return True
        End If

        Return False
    End Function

    'VERIFICA ERRORES
    Private Function fnErrores() As Boolean
        If txtCodigo.Text.Equals("") Or txtCodigo.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar un codigo!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If txtDescripcion.Text.Equals("") Or txtDescripcion.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar un descripción!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbImportancia.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir una importancia!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If nm0Cantidad.Value <= 0 Then
            RadMessageBox.Show("Cantidad debe de ser mayor a cero (0)!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        Return False
    End Function

    'AGREGA NUEVO PENDIENTE
    Private Sub fnAgregarPendiente(codigoExiste As Boolean, codArt As String)
        Dim idCliente As Integer = cmbCliente.SelectedValue
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim hora As String = mdlPublicVars.fnHoraServidor

        'Agregamos el articulo a la tabla de pendientes por pedir
        Dim pendiente As New tblPendientePorPedir
        pendiente.cliente = idCliente
        pendiente.bitCreado = codigoExiste
        pendiente.anulado = False
        pendiente.cantidad = nm0Cantidad.Value
        pendiente.codigoArticulo = codArt
        pendiente.descripcion = txtDescripcion.Text
        pendiente.fechaRegistro = dtpFechaRegistro.Text & " " & hora
        pendiente.importancia = CInt(cmbImportancia.SelectedValue)
        pendiente.observacion = txtObservacion.Text
        pendiente.saldo = nm0Cantidad.Value
        pendiente.usuario = mdlPublicVars.idUsuario

        ctx.AddTotblPendientePorPedirs(pendiente)
        ctx.SaveChanges()

        'Si el codigo existe agregamos un nuevo pendiente por surtir
        If codigoExiste Then
            'Obtenemos informacion del articulo
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.codigo1 = codArt Select x).FirstOrDefault

            Dim surtir As New tblSurtir
            'Creamos el pendiente por surtir
            surtir.articulo = articulo.idArticulo
            surtir.cantidad = nm0Cantidad.Value
            surtir.saldo = nm0Cantidad.Value
            surtir.fechaTransaccion = pendiente.fechaRegistro
            surtir.anulado = False
            surtir.usuario = mdlPublicVars.idUsuario
            surtir.vendedor = mdlPublicVars.idVendedor
            surtir.cliente = idCliente

            ctx.AddTotblSurtirs(surtir)
            ctx.SaveChanges()

            pendiente.pendienteSurtir = surtir.codigo
            ctx.SaveChanges()
        End If

        'Actualizamos el grid
        fnLlenarGrid()
    End Sub

    Private Sub grdDatos_CommandCellClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDatos.CommandCellClick
        Try
            Dim c As Integer = (TryCast(sender, GridCommandCellElement)).ColumnIndex

            If Me.grdDatos.Columns(c).Name.Equals("crear") Or Me.grdDatos.Columns(c).Name.Equals("modificar") Then
                'Obtenemos la fila
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                Dim anulado As Boolean = Me.grdDatos.Rows(fila).Cells("Anulado").Value
                Dim creado As Boolean = Me.grdDatos.Rows(fila).Cells("Creado").Value
                Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("idPendiente").Value

                If anulado Then
                    RadMessageBox.Show("El artículo ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ElseIf creado Then
                    RadMessageBox.Show("El artículo ya ha sido creado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Else
                    If Me.grdDatos.Columns(c).Name.Equals("crear") Then
                        'Crea el articulo
                        If RadMessageBox.Show("¿Desea agregar el artículo al inventario?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            fnCrearArticulo(codigo)
                        End If
                    ElseIf Me.grdDatos.Columns(c).Name.Equals("modificar") Then
                        'Modifica el articulo
                        If RadMessageBox.Show("¿Desea modificar la información del articulo?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            fnModificarArticulo(codigo)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'CREAR ARTICULO
    Private Function fnCrearArticulo(ByVal idPendiente As Integer) As Boolean
        Dim success As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFechaServidor

        Try
            'Obtenemos el pendiente por pedir
            Dim pendiente As tblPendientePorPedir = (From x In ctx.tblPendientePorPedirs.AsEnumerable Where x.codigo = idPendiente Select x).FirstOrDefault

            frmProducto.Text = "Modulo de Productos"
            frmProducto.StartPosition = FormStartPosition.CenterScreen
            frmProducto.NuevoIniciar = True
            frmProducto.seleccionDefault = False
            frmProducto.nuevoProducto = True
            frmProducto.bitNuevoPendiente = True
            frmProducto.codigoProductoNuevo = pendiente.codigoArticulo
            frmProducto.nombreProductoNuevo = pendiente.descripcion
            frmProducto.importanciaProductoNuevo = pendiente.importancia
            frmProducto.idPendientePedir = pendiente.codigo
            frmProducto.ShowDialog()
            frmProducto.Dispose()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            success = False
        End Try

        Return success
    End Function

    'MODIFICAR ARTICULO
    Private Sub fnModificarArticulo(idPendiente As Integer)
        frmBusquedaArticuloModificaPendiente.idPendiente = idPendiente
        frmBusquedaArticuloModificaPendiente.Text = "Pendiente por Surtir"
        frmBusquedaArticuloModificaPendiente.StartPosition = FormStartPosition.CenterScreen
        frmBusquedaArticuloModificaPendiente.ShowDialog()
        frmBusquedaArticuloModificaPendiente.Dispose()
        fnLlenarGrid()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'VERIFICAR
    Private Sub btnVerificar_Click(sender As System.Object, e As System.EventArgs) Handles btnVerificar.Click
        Dim codArt As String = txtCodigo.Text
        grdProductos.DataSource = Nothing

        If Not codArt.Equals("") Then
            'Verifica si hay productos con ese codigo
            Dim productos = (From x In ctx.tblInventarios Where x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                             And x.tblArticulo.codigo1.Contains(codArt)
                             Select Codigo = x.tblArticulo.codigo1, Articulo = x.tblArticulo.nombre1)
            Me.grdProductos.DataSource = productos

            fnConfiguraProductos()
        End If
    End Sub

    'CONFIGURA PRODUCTOS
    Private Sub fnConfiguraProductos()
        If Me.grdProductos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdProductos.ColumnCount - 1
                Me.grdProductos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdProductos.Columns("Codigo").Width = 25
            Me.grdProductos.Columns("Articulo").Width = 75
        End If
    End Sub

    'IMPLRESION
    Private Sub fnDocSalida() Handles Me.panel0
        frmDocumentosSalida.txtTitulo.Text = "Lista de Productos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        fnLlenarDatos()
    End Sub
End Class