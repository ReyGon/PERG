Imports System.Data.EntityClient
Imports System.Linq
Imports Telerik.WinControls

Public Class frmEmpleado

    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombo()
        llenagrid()
        mdlPublicVars.comboActivarFiltro(cmbPuesto)
        mdlPublicVars.fnGrid_iconos(Me.grdDatos)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)
    End Sub

    'Llenar combos
    Private Sub fnLlenarCombo()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim puestos = From x In conexion.tblpuestoes Select codigo = x.idpuesto, nombre = x.nombre
            With cmbPuesto
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = puestos
            End With
            conn.Close()
        End Using
    End Sub

    'Llenar grid
    Private Sub llenagrid()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'CONSULTAR REGISTROS
            ''Dim data = From x In conexion.tblEmpleadoes Select Codigo = x.idEmpleado, Puesto = x.tblpuesto.nombre, Nombre = x.nombre, Direccion = x.direccion, Telefono = x.telefono, chmPordillero = CBool(x.bitpordillero), chmPiloto = CBool(x.bitpiloto)

            Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_lista_empleados(mdlPublicVars.idEmpresa, "") Select x)

            Me.grdDatos.DataSource = datos

            conn.Close()
        End Using
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim m As New tblEmpleado
            Try
                m.idpuesto = cmbPuesto.SelectedValue
                m.nombre = txtNombre.Text
                m.direccion = txtDireccion.Text
                m.telefono = txtTelefono.Text

                conexion.AddTotblEmpleadoes(m)
                conexion.SaveChanges()
                alertas.fnGuardar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorGuardar()
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim m As tblEmpleado = (From e1 In conexion.tblEmpleadoes Where e1.idEmpleado = Me.txtCodigo.Text Select e1).First()
                m.idpuesto = cmbPuesto.SelectedValue
                m.nombre = txtNombre.Text
                m.direccion = txtDireccion.Text
                m.telefono = txtTelefono.Text

                conexion.SaveChanges()
                alertas.fnModificar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorModificar()
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro
        If RadMessageBox.Show("Esta seguro de eliminar este registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
                Dim m As tblEmpleado = (From e1 In conexion.tblEmpleadoes Where e1.idEmpleado = Me.txtCodigo.Text Select e1).First()

                conexion.DeleteObject(m)
                conexion.SaveChanges()

                alertas.fnEliminar()

                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorEliminar()
            End Try
            conn.Close()
        End Using
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub rbtAjuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPordillero.CheckedChanged, rbtPiloto.CheckedChanged

    End Sub

End Class