Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmImpuestoPagar

    Dim impuesto As New tblImpuestoPagar
    Dim fila As Int16

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    ''Eliminar Impuestos
    Private Sub frmPagarImpuesto_eliminarRegistro() Handles Me.eliminaRegistro

        Dim fila As Integer

        If Me.txtId.Text = "" Then
            RadMessageBox.Show("Seleccione un registro que contenga informacion", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else

            fila = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)

            ''Dim idimpuestopagaimpuesto As Integer
            Dim idimpuestopaga As Integer
            ''Dim idimpuesto As Integer
            Dim existe As Integer

            idimpuestopaga = Me.grdDatos.Rows(fila).Cells(0).Value
            ''idimpuestopaga = Me.grdDatos.Rows(fila).Cells(0).Value
            ''idimpuesto = Me.grdDatos.Rows(fila).Cells(0).Value

            Dim borrar As List(Of tblImpuestoPagar_Impuesto) = (From y In ctx.tblImpuestoPagar_Impuesto Where y.idImpuestoPagar = idimpuestopaga Select y).ToList

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                For Each elim As tblImpuestoPagar_Impuesto In borrar

                    existe = elim.idImpuestoPagar

                    Dim borrado As tblImpuestoPagar_Impuesto = (From y In conexion.tblImpuestoPagar_Impuesto Where y.idImpuestoPagar = existe Select y).FirstOrDefault

                    conexion.DeleteObject(borrado)
                    conexion.SaveChanges()

                Next
                Dim borrarimpuesto As tblImpuestoPagar = (From y In conexion.tblImpuestoPagars Where y.idImpuestoPagar = idimpuestopaga Select y).FirstOrDefault

                conexion.DeleteObject(borrarimpuesto)
                conexion.SaveChanges()

                conn.Close()
                RadMessageBox.Show("Registro Eliminado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End Using
        End If
        llenaGrid()
        fnLlenarImpuesto()

    End Sub

    ''Guardar Registro Impuesto
    Private Sub frmPagarImpuesto_grabarRegistro() Handles Me.grabaRegistro

        Dim idimpuestopaga As Integer

        If Me.grdDatos.RowCount > 0 Then
            fila = Me.grdDatos.CurrentRow.Index
        End If

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim aimpuesto As New tblImpuestoPagar

            aimpuesto.nombre = Me.txtNombre.Text
            aimpuesto.observacion = Me.txtObservacion.Text

            conexion.AddTotblImpuestoPagars(aimpuesto)
            conexion.SaveChanges()

            conn.Close()
        End Using

        If Me.txtId.Text = "" Then

            ''Obtenemos el id del impuesto

            idimpuestopaga = (From y In ctx.tblImpuestoPagars Select y.idImpuestoPagar).max

            If idimpuestopaga > 0 Then
                fnGuardarImpuesto(idimpuestopaga)
            End If
        Else
            RadMessageBox.Show("Para actulizar utilice modificar", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

        llenaGrid()
        fnLlenarImpuesto()
    End Sub

    ''Load
    Private Sub frmImpuestoPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbImpuesto)
        mdlPublicVars.fnFormatoGridMovimientos(grdImpuestos)
        mdlPublicVars.fnFormatoGridEspeciales(grdImpuestos)
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        llenaGrid()
        fnLlenarImpuesto()
        fnllenarCombo()
    End Sub

    ''Llena Grid
    Private Sub llenaGrid()

        Try
            Dim detalle

            detalle = (From y In ctx.tblImpuestoPagars Select Id = y.idImpuestoPagar, Nombre = y.nombre, Observacion = y.observacion)
            Me.grdDatos.DataSource = detalle

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End Try

    End Sub

    ''Modificar Registro
    Private Sub frmImpuestoPagar_modificarRegistro() Handles Me.modificaRegistro
        Dim fila As Integer
        Dim nombre As String
        Dim observacion As String

        fila = Me.grdDatos.CurrentRow.Index
        nombre = Me.txtNombre.Text
        Observacion = Me.txtObservacion.Text

        If Me.txtId.Text <> "" Then

            Dim idimpuesto As Integer = Me.txtId.Text

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim editar As tblImpuestoPagar = (From y In conexion.tblImpuestoPagars Where y.idImpuestoPagar = idimpuesto Select y).FirstOrDefault

                editar.nombre = nombre
                editar.observacion = observacion

                conexion.SaveChanges()

                fnGuardarImpuesto(editar.idImpuestoPagar)

                conn.Close()
            End Using
            RadMessageBox.Show("Registro Modificado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            RadMessageBox.Show("Para crear utilice Nuevo", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If
        llenaGrid()
        fnLlenarImpuesto()
    End Sub

    ''Nuevo Registro
    Private Sub frmImpuestoPagar_nuevoRegistro() Handles Me.nuevoRegistro
        mdlPublicVars.limpiaCampos(Me)
        Me.grdImpuestos.Rows.Clear()
        fnLlenarCombo()
        Me.txtNombre.Focus()
    End Sub

    ''Llenar Combo
    Private Sub fnLlenarCombo()
        Dim idImpuestoPagar As Integer = If(txtId.Text.Equals(""), 0, CInt(txtId.Text))

        Dim detalle = (From y In ctx.tblImpuestoes Select idImpuesto = CType(y.idImpuesto, Integer), Nombre = y.nombre).Except(From y In ctx.tblImpuestoPagar_Impuesto, m In ctx.tblImpuestoes Where m.idImpuesto = y.idImpuesto And idImpuestoPagar > 0 And y.idImpuestoPagar = idImpuestoPagar Select idImpuesto = CType(y.idImpuesto, Integer), Nombre = m.nombre)

        With cmbImpuesto
            .DataSource = Nothing
            .ValueMember = "idImpuesto"
            .DisplayMember = "Nombre"
            .DataSource = detalle
        End With
    End Sub

    ''Cambio de Impuesto
    Private Sub cmbImpuesto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbImpuesto.SelectedValueChanged
        Dim idImpuesto As Integer = CInt(cmbImpuesto.SelectedValue)

        If idImpuesto > 0 Then
            ''Obtenemos la formula del impuesto

            Dim detalle = (From y In ctx.tblImpuestoes Where y.idImpuesto = idImpuesto Select y.formula).FirstOrDefault

            lblFormula.Text = CType(detalle, String)
        Else
            lblFormula.Text = ""
        End If
    End Sub

    ''Agregar Impuesto
    Private Sub btnAgregarCodigo_Click(sender As Object, e As EventArgs) Handles btnAgregarCodigo.Click
        Dim idImpuesto As Integer = CInt(cmbImpuesto.SelectedValue)

        If idImpuesto > 0 Then
            Dim fila As Object() = {0, idImpuesto, cmbImpuesto.Text, lblFormula.Text, 0}
            Me.grdImpuestos.Rows.Add(fila)
            RadMessageBox.Show("Agregado Exitosamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        Else
            RadMessageBox.Show("Debe elegir un impuesto", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If
    End Sub

    ''Eliminar impuesto uno por uno
    Private Sub grdImpuestos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdImpuestos.KeyDown

        If e.KeyCode = Keys.Delete Then
            If RadMessageBox.Show("¿Desea eliminar el impuesto?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdImpuestos)

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim idimpuestoborrar As Integer = Me.grdImpuestos.Rows(fila).Cells(1).Value

                    Dim eliminarimpuesto As tblImpuestoPagar_Impuesto = (From y In conexion.tblImpuestoPagar_Impuesto Where y.idImpuesto = idimpuestoborrar Select y).FirstOrDefault

                    conexion.DeleteObject(eliminarimpuesto)
                    conexion.SaveChanges()

                    conn.Close()

                    RadMessageBox.Show("Impuesto Eliminado Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End Using

            End If
        End If
        fnLlenarImpuesto()
    End Sub

    ''Llenar Impuesto
    Private Sub fnLlenarImpuesto()
        grdImpuestos.Rows.Clear()
        Dim idImpuestoPagar As Integer = If(txtId.Text.Equals(""), 0, CInt(txtId.Text))

        If idImpuestoPagar > 0 Then

            Dim detalle = (From y In ctx.tblImpuestoPagar_Impuesto, m In ctx.tblImpuestoes Where m.idImpuesto = y.idImpuesto And y.idImpuestoPagar = idImpuestoPagar Select iddetalle = y.idImpuestoPagar_Impuesto, m.idImpuesto, m.nombre, m.formula)

            Dim datos As DataTable = mdlPublicVars.EntitiToDataTable(detalle)

            For Each fila As DataRow In datos.Rows
                Me.grdImpuestos.Rows.Add(fila.Item("iddetalle"), fila.Item("idImpuesto"), fila.Item("nombre"), fila.Item("Formula"), 0)
            Next
        End If
    End Sub

    ''Guardar Impuestos
    Private Sub fnGuardarImpuesto(idImpuestoPagar As Integer)
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

                        Dim agregar As New tblImpuestoPagar_Impuesto

                        agregar.idImpuestoPagar = idImpuestoPagar
                        agregar.idImpuesto = idImpuesto

                        conexion.AddTotblImpuestoPagar_Impuesto(agregar)
                        conexion.SaveChanges()

                    End If
                Next

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    ''Cambio Registro
    Private Sub txtId_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtId.TextChanged
        fnLlenarCombo()
        fnLlenarImpuesto()
    End Sub
End Class
