Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmProductoLista
    Public filtroActivo As Boolean
    Private permiso As New clsPermisoUsuario
    Public esfiltro As Boolean

    Private Sub frmProductoLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmProductoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbl2Eliminar.Text = "Deshabilitar/" & vbCrLf & "Eliminar"
            lbl2Eliminar.Location = New Point(lbl2Eliminar.Location.X, 6)

            Dim iz As New frmProductosBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmProductosBarraDerecha
            ActivarBarraLateral = True

            fnLlenaCombo()

        Catch ex As Exception
        End Try
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ''llenagrid()
        Me.grdDatos.Focus()
    End Sub

    Private Sub fnLlenaCombo()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim inventario = (From x In conexion.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre)

                With cmbTipoInventario
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = inventario
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenagrid()
        Try
            If filtroActivo Then
                frmProductoFiltro.fnFiltrar()
            Else

                Dim conexion As New dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    Dim tipoinventario As Integer = Me.cmbTipoInventario.SelectedValue

                    Dim filtro As String = txtFiltro.Text
                    Dim productoInfo = conexion.sp_lista_articulos(mdlPublicVars.idEmpresa, mdlPublicVars.General_idAlmacenPrincipal, filtro, tipoinventario)
                    Me.grdDatos.DataSource = productoInfo

                    conn.Close()
                End Using
            End If

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            fnCambioFila()
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Columns.Count > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            'Select ID, Codigo1, Nombre, Inventario, Disponible, Transito, Reserva, Surtir,
            ' Estanteria, Cajas, FechaUltAjuste, UltimaVenta)
            Me.grdDatos.Columns("ID").Width = 60
            Me.grdDatos.Columns("Codigo1").Width = 80
            Me.grdDatos.Columns("Nombre").Width = 200
            Me.grdDatos.Columns("Inventario").Width = 70
            Me.grdDatos.Columns("Disponible").Width = 70
            Me.grdDatos.Columns("Transito").Width = 70
            Me.grdDatos.Columns("Reserva").Width = 70
            Me.grdDatos.Columns("Surtir").Width = 50
            Me.grdDatos.Columns("Estanteria").Width = 70
            Me.grdDatos.Columns("Cajas").Width = 70
            Me.grdDatos.Columns("FechaUltAjuste").Width = 70
            Me.grdDatos.Columns("UltimaVenta").Width = 70
            Me.grdDatos.Columns("clrEstado").Width = 70
            Me.grdDatos.Columns("Descripcion").Width = 110
            Me.grdDatos.Columns("ID").IsVisible = False
            Me.grdDatos.Columns("FechaUltAjuste").TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns("FechaUltAjuste").HeaderText = "Ultimo Ajuste"
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaUltAjuste")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "UltimaVenta")
            Me.grdDatos.Columns("CodInventario").IsVisible = False
            Me.grdDatos.Columns("CodBodega").IsVisible = False
        End If
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        fnCambioFila()
        Try
            Dim permiso As New clsPermisoUsuario
            frmProducto.seleccionDefault = False
            frmProducto.Text = "Modulo de Productos"
            frmProducto.NuevoIniciar = True
            permiso.PermisoDialogMantenimientoTelerik2(frmProducto)
            frmProducto.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        fnCambioFila()
        Try
            If Me.grdDatos.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim permiso As New clsPermisoUsuario
            frmProducto.seleccionDefault = True
            frmProducto.codigoDefault = mdlPublicVars.superSearchId
            frmProducto.InventarioPrincipal = mdlPublicVars.superSearchInventario
            frmProducto.BodegaPrincipal = mdlPublicVars.superSearchBodega
            frmProducto.NuevoIniciar = False
            frmProducto.Text = "Modulo de Productos"
            frmProducto.grdBase = grdDatos
            permiso.PermisoDialogMantenimientoTelerik2(frmProducto)
            frmProducto.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            fnDeshabilita(grdDatos.Rows(fila).Cells("ID").Value())
            Call llenagrid()
        Catch ex As Exception
            alertas.fnError()
        End Try

    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        fnCambioFila()
        Dim permiso As New clsPermisoUsuario
        frmProducto.seleccionDefault = True
        frmProducto.codigoDefault = mdlPublicVars.superSearchId
        frmProducto.NuevoIniciar = False
        frmProducto.verRegistro = True
        frmProducto.InventarioPrincipal = mdlPublicVars.superSearchInventario
        frmProducto.BodegaPrincipal = mdlPublicVars.superSearchBodega

        frmProducto.Text = "Modulo de Productos"
        frmProducto.grdBase = grdDatos
        permiso.PermisoDialogMantenimientoTelerik2(frmProducto)
        frmProducto.Dispose()
    End Sub

    Private Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.RowCount > 0 Then
                mdlPublicVars.superSearchId = Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("ID").Value
                If esfiltro = False Then
                    mdlPublicVars.superSearchInventario = Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("CodInventario").Value
                    mdlPublicVars.superSearchBodega = Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("CodBodega").Value
                Else
                    mdlPublicVars.superSearchInventario = 1
                    mdlPublicVars.superSearchBodega = 1
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para desabilitar un producto
    Private Sub fnDeshabilita(ByVal codigo As Integer)
        fnCambioFila()
        Dim success As Boolean = True
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                'verificar si el producto tiene movimientos
                'Obtenemos el articulo con ese codigo
                Dim art As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault
                'Deshabilitamos al cliente
                art.Habilitado = False
                conexion.SaveChanges()
            Catch ex As Exception
                success = False
            End Try

            If success = True Then
                alertas.fnModificar()
            Else
                alertas.fnErrorModificar()
            End If
            conn.Close()
        End Using
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Productos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmProductoFiltro.Text = "Filtro: PRODUCTOS"
        frmProductoFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmProductoFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
        llenagrid()
    End Sub

    Private Sub cmbTipoInventario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoInventario.SelectedValueChanged
        Try
            llenagrid()
        Catch ex As Exception

        End Try
    End Sub
End Class