Imports System.Data.EntityClient
Imports System.Linq
Imports Telerik.WinControls

Public Class frmTipoEmpleado
    Private Sub frmTipoEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenagrid()
    End Sub

    'Llenar grid
    Private Sub llenagrid()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'CONSULTAR REGISTROS
            Dim data = From x In ctx.tblpuestoes Select Codigo = x.idpuesto, Nombre = x.nombre
            Me.grdDatos.DataSource = data

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

            Dim m As New tblpuesto
            Try
                m.nombre = txtNombre.Text
                ctx.AddTotblpuestoes(m)
                ctx.SaveChanges()
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
                Dim m As tblpuesto = (From e1 In ctx.tblpuestoes Where e1.idpuesto = Me.txtCodigo.Text Select e1).First()
                m.nombre = txtNombre.Text

                ctx.SaveChanges()
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
                Dim m As tblpuesto = (From e1 In ctx.tblpuestoes Where e1.idpuesto = Me.txtCodigo.Text Select e1).First()

                ctx.DeleteObject(m)
                ctx.SaveChanges()
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

End Class