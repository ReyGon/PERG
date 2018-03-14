Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Linq
Imports System.Windows.Forms
Imports System.Data.EntityClient

Public Class frmImpuestoCobrarMovimiento

    Private Sub frmSizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frmImpuestoCobrarMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaGrid()
        fnLlenarCombo()
    End Sub

    Private Sub fnLlenarCombo()

        Dim cargar = (From y In ctx.tblImpuestoCobrars Select idImpuestoCobrar = y.idImpuestoCobrar, Nombre = y.nombre)

        With cmbImpuestoCobrar
            .DataSource = Nothing
            .ValueMember = "idImpuestoCobrar"
            .DisplayMember = "Nombre"
            .DataSource = cargar
        End With

        Dim carga = (From y In ctx.tblTipoMovimientoes Where y.impuestocobrar = True And y.impuestopagar = False Select idTipoMovimiento = y.idTipoMovimiento, Nombre = y.nombre)

        With cmbTipoMovimiento
            .DataSource = Nothing
            .ValueMember = "idTipoMovimiento"
            .DisplayMember = "Nombre"
            .DataSource = carga
        End With

    End Sub

    Private Sub LlenaGrid()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim inventario = (From y In conexion.tblImpuestoCobrar_TipoMovimiento, z In conexion.tblImpuestoCobrars, m In conexion.tblTipoMovimientoes Where z.idImpuestoCobrar = y.idImpuestoCobrar And m.idTipoMovimiento = y.idTipoMovimiento Select Id = y.idImpuestoCobrar_TipoMovimiento, ImpuestoCobrar = z.nombre, TipoMovimiento = m.nombre)

            Me.grdDatos.DataSource = mdlPublicVars.EntitiToDataTable(inventario)
            conn.Close()
        End Using

    End Sub

    Private Sub frmImpuestoCobrarMovimiento_grabarRegistro() Handles Me.grabaRegistro
        If Me.grdDatos.RowCount > 0 Then
            Dim fila = Me.grdDatos.CurrentRow.Index
        End If

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            If Me.txtId.Text = "" Then

                Dim nuevo As New tblImpuestoCobrar_TipoMovimiento

                nuevo.idImpuestoCobrar = CInt(cmbImpuestoCobrar.SelectedValue)
                nuevo.idTipoMovimiento = CInt(cmbTipoMovimiento.SelectedValue)

                conexion.AddTotblImpuestoCobrar_TipoMovimiento(nuevo)
                conexion.SaveChanges()

                conn.Close()
                RadMessageBox.Show("Registro Guardado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                RadMessageBox.Show("Para actualizar utilice Modificar", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        End Using
        LlenaGrid()
    End Sub

    Private Sub frmImpuestoCobrarMovimiento_modificarRegistro() Handles Me.modificaRegistro
        Dim fila = Me.grdDatos.CurrentRow.Index

        Dim idregistro As Integer = Me.txtId.Text

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim editar As tblImpuestoCobrar_TipoMovimiento = (From y In conexion.tblImpuestoCobrar_TipoMovimiento Where y.idImpuestoCobrar_TipoMovimiento = idregistro Select y).FirstOrDefault

            editar.idImpuestoCobrar = CInt(cmbImpuestoCobrar.SelectedValue)
            editar.idTipoMovimiento = CInt(cmbTipoMovimiento.SelectedValue)

            conexion.SaveChanges()
            conn.Close()

            If Me.txtId.Text <> "" Then
                RadMessageBox.Show("Registro Modificaco Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                RadMessageBox.Show("Para crear utilice Nuevo", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
            LlenaGrid()

        End Using
    End Sub

    Private Sub frmImpuestoCobrarMovimiento_nuevoRegistro() Handles Me.nuevoRegistro
        mdlPublicVars.limpiaCampos(Me)
        cmbTipoMovimiento.Focus()
        Me.txtId.Clear()
        fnLlenarCombo()

    End Sub

    Private Sub frmImpuestoCobrarMovimiento_eliminarRegistro() Handles Me.eliminaRegistro
        Dim fila = 0

        If Me.txtId.Text = "" Then
            RadMessageBox.Show("Muevase a un registro con informacion", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim ideliminar As Integer = Me.txtId.Text

                Dim eliminar = (From y In conexion.tblImpuestoCobrar_TipoMovimiento Where y.idImpuestoCobrar_TipoMovimiento = ideliminar Select y).FirstOrDefault

                conexion.DeleteObject(eliminar)
                conexion.SaveChanges()

                conn.Close()
            End Using

            RadMessageBox.Show("Impuesto Eliminado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            LlenaGrid()

        End If
    End Sub

End Class
