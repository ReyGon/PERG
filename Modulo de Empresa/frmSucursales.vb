Imports System.Data.EntityClient
Imports System.Linq
Imports Telerik.WinControls

Public Class frmSucursales
    Private Sub frmSucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombo()
        llenagrid()
    End Sub

    'Llenar combos
    Private Sub fnLlenarCombo()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim empresas = From x In conexion.tblEmpresas Select codigo = x.idEmpresa, nombre = x.nombre
            With cmbEmpresa
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = empresas
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
            Dim data = From x In conexion.tblSucursales Select ID = x.idSucursal, Empresa = x.tblEmpresa.nombre, Codigo = x.codigo, _
                       Servidor = x.servidor, Descripcion = x.descripcion, Direccion = x.direccion, Telefono = x.telefono

            Me.grdDatos.DataSource = data

            conn.Close()
        End Using
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtServidor.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.txtServidor.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim m As New tblSucursale
            Try
                m.idEmpresa = CInt(cmbEmpresa.SelectedValue)
                m.servidor = txtServidor.Text
                m.codigo = txtCodigo.Text
                m.descripcion = txtDescripcion.Text
                m.direccion = txtDireccion.Text
                m.telefono = txtTelefono.Text

                conexion.AddTotblSucursales(m)
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
                Dim m As tblSucursale = (From e1 In conexion.tblSucursales Where e1.idSucursal = Me.txtId.Text Select e1).First()
                m.idEmpresa = CInt(cmbEmpresa.SelectedValue)
                m.servidor = txtServidor.Text
                m.codigo = txtCodigo.Text
                m.descripcion = txtDescripcion.Text
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
                Dim m As tblSucursale = (From e1 In conexion.tblSucursales Where e1.idSucursal = Me.txtId.Text Select e1).First()

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
End Class