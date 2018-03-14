Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Windows
Imports System.Linq

Public Class frmImpuestoCobrar

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frmImpuestoCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdImpuestos)
        mdlPublicVars.comboActivarFiltro(cmbImpuesto)

        llenaGrid()
        fnLlenarCombo()
    End Sub

    Private Sub frmImpuestoCobrar() Handles Me.grabaRegistro
        If Me.grdDatos.RowCount > 0 Then
            Dim fila = Me.grdDatos.CurrentRow.Index
        End If


    End Sub

    Private Sub llenaGrid()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim mostrar = (From y In conexion.tblImpuestoCobrars Select Id = y.idImpuestoCobrar, Nombre = y.nombre, Observacion = y.observacion)

            Me.grdDatos.DataSource = mdlPublicVars.EntitiToDataTable(mostrar)

            conn.Close()
        End Using

    End Sub

    Private Sub frmImpuestoCobrar_modificarRegistro() Handles Me.modificaRegistro
        Dim fila As Integer
        Dim nombre As String
        Dim observacion As String

        fila = Me.grdDatos.CurrentRow.Index
        nombre = Me.txtNombre.Text
        observacion = Me.txtObservacion.Text

        If Me.txtId.Text <> "" Then
            Dim idimpuesto As Integer = Me.txtId.Text

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim editar As tblImpuestoCobrar = (From y In conexion.tblImpuestoCobrars Where y.idImpuestoCobrar = idimpuesto Select y).FirstOrDefault

                editar.nombre = nombre
                editar.observacion = observacion

                conexion.SaveChanges()

                fnGuardarImpuesto(editar.idImpuestoCobrar)

                conn.Close()
            End Using
            RadMessageBox.Show("Registro Modificado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            RadMessageBox.Show("Para crear utilice Nuevo", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If
        llenaGrid()
        fnLlenarImpuesto()
    End Sub

    Private Sub frmImpuestoCobrar_nuevoRegistro() Handles Me.nuevoRegistro
        mdlPublicVars.limpiaCampos(Me)
        Me.grdImpuestos.Rows.Clear()
        fnLlenarCombo()
        Me.txtNombre.Focus()
    End Sub

    Private Sub fnLlenarCombo()
        Dim idImpuestoCobrar As Integer = If(txtId.Text.Equals(""), 0, CInt(txtId.Text))

        Dim combo = (From y In ctx.tblImpuestoes Select Id = CType(y.idImpuesto, Integer), Nombre = y.nombre).Except(From y In ctx.tblImpuestoCobrar_Impuesto, z In ctx.tblImpuestoes Where idImpuestoCobrar > 0 And y.idImpuestoCobrar = idImpuestoCobrar Select Id = CType(y.idImpuesto, Integer), Nombre = z.nombre)

        With cmbImpuesto
            .DataSource = Nothing
            .ValueMember = "Id"
            .DisplayMember = "Nombre"
            .DataSource = combo
        End With
    End Sub

    Private Sub frmImpuestoCobrar_grabarRegistro() Handles Me.grabaRegistro

        Dim idimpuestocobra As Integer

        If Me.grdDatos.RowCount > 0 Then
            Dim fila = Me.grdDatos.CurrentRow.Index
        End If

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim aimpuesto As New tblImpuestoCobrar

            aimpuesto.nombre = Me.txtNombre.Text
            aimpuesto.observacion = Me.txtObservacion.Text

            conexion.AddTotblImpuestoCobrars(aimpuesto)
            conexion.SaveChanges()

            conn.Close()
        End Using

        If Me.txtId.Text = "" Then

            idimpuestocobra = (From y In ctx.tblImpuestoCobrars Select y.idImpuestoCobrar).Max

            If idimpuestocobra > 0 Then
                fnGuardarImpuesto(idimpuestocobra)
            End If
        Else
            RadMessageBox.Show("Para actualizar utilice modificar", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

        llenaGrid()
        fnLlenarImpuesto()
    End Sub

    Private Sub cmbImpuesto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbImpuesto.SelectedValueChanged
        Dim idImpuesto As Integer = CInt(cmbImpuesto.SelectedValue)

        If idImpuesto > 0 Then
            ''Obtenemos la formalua del impuesto

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim valor = (From y In conexion.tblImpuestoes Where y.idImpuesto = idImpuesto Select y.formula).FirstOrDefault

                lblFormula.Text = valor

                conn.Close()
            End Using
        Else
            lblFormula.Text = ""
        End If
    End Sub

    Private Sub btnAgregarCodigo_Click(sender As Object, e As EventArgs) Handles btnAgregarCodigo.Click
        Dim idImpuesto As Integer = CInt(cmbImpuesto.SelectedValue)

        If idImpuesto > 0 Then
            Dim fila As Object() = {0, idImpuesto, cmbImpuesto.Text, lblFormula.Text, 0}
            Me.grdImpuestos.Rows.Add(fila)
            RadMessageBox.Show("Agregado Exitosamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            RadMessageBox.Show("Debe elegir un Impuesto", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If
    End Sub

    Private Sub grdImpuestoCobrar_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdImpuestos.KeyDown

        If e.KeyCode = Keys.Delete Then
            If RadMessageBox.Show("¿Desea eliminar el impuesto?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Forms.DialogResult.Yes Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdImpuestos)

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim idimpuestoborrar As Integer = Me.grdImpuestos.Rows(fila).Cells(1).Value

                    Dim eliminarimpuesto As tblImpuestoCobrar_Impuesto = (From y In conexion.tblImpuestoCobrar_Impuesto Where y.idImpuesto = idimpuestoborrar Select y).FirstOrDefault

                    conexion.DeleteObject(eliminarimpuesto)
                    conexion.SaveChanges()

                    conn.Close()

                    RadMessageBox.Show("Impuesto Eliminado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End Using

            End If
        End If
        fnLlenarImpuesto()
    End Sub

    Private Sub fnLlenarImpuesto()

        grdImpuestos.Rows.Clear()
        Dim idImpuestoCobrar As Integer = If(txtId.Text.Equals(""), 0, CInt(txtId.Text))

        If idImpuestoCobrar > 0 Then

            Dim detalle = (From y In ctx.tblImpuestoCobrar_Impuesto, m In ctx.tblImpuestoes Where m.idImpuesto = y.idImpuesto And y.idImpuestoCobrar = idImpuestoCobrar Select iddetalle = y.idImpuestoCobrar_Impuesto, m.idImpuesto, m.nombre, m.formula)

            Dim datos As DataTable = mdlPublicVars.EntitiToDataTable(detalle)

            For Each fila As DataRow In datos.Rows
                Me.grdImpuestos.Rows.Add(fila.Item("iddetalle"), fila.Item("idImpuesto"), fila.Item("nombre"), fila.Item("Formula"), 0)
            Next

        End If
    End Sub

    Private Sub fnGuardarImpuesto(idImpuestoCobrar As Integer)
        Try

            Dim idImpuesto As Integer
            Dim iddetalle As Integer
            Dim elimina As Integer

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                For Each fila As GridViewRowInfo In Me.grdImpuestos.Rows
                    idImpuesto = fila.Cells("idImpuesto").Value
                    iddetalle = fila.Cells("idDetalle").Value
                    elimina = fila.Cells("elimina").Value

                    If iddetalle = 0 Then

                        Dim agregar As New tblImpuestoCobrar_Impuesto

                        agregar.idImpuestoCobrar = idImpuestoCobrar
                        agregar.idImpuesto = idImpuesto

                        conexion.AddTotblImpuestoCobrar_Impuesto(agregar)
                        conexion.SaveChanges()

                    End If
                Next

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End Try
    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged
        fnLlenarCombo()
        fnLlenarImpuesto()
    End Sub
End Class
