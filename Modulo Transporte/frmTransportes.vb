Imports System.Data.EntityClient
Imports System.Linq
Imports Telerik.WinControls

Public Class frmTransportes
    Private Sub frmTransportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombo()
        llenagrid()
    End Sub

    'Llenar combo
    Private Sub fnLlenarCombo()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim tipostransportes = (From x In ctx.tblTiposTransportes Select codigo = x.idTipoTransporte, nombre = x.descripcion)
            With cmbTipoTransporte
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = tipostransportes
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
            Dim data = From x In ctx.tblTransportes Select Codigo = x.idTransporte, TipoTransporte = x.tblTiposTransporte.descripcion,
                       Descripcion = x.descripcion, Placas = x.placas, Capacidad = x.capacidad, KmGalon = x.KMGalon

            Me.grdDatos.DataSource = data
            fnConfiguracion()
            conn.Close()
        End Using
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count - 1 > 0 Then
            Me.grdDatos.Columns("Codigo").Width = 75
            Me.grdDatos.Columns("TipoTransporte").Width = 125
            Me.grdDatos.Columns("Descripcion").Width = 150
            Me.grdDatos.Columns("Placas").Width = 75
            Me.grdDatos.Columns("Capacidad").Width = 75
            Me.grdDatos.Columns("KmGalon").Width = 75
        End If
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.cmbTipoTransporte.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.cmbTipoTransporte.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim m As New tblTransporte
            Try
                m.idTipoTransporte = CInt(cmbTipoTransporte.SelectedValue)
                m.descripcion = txtDescripcion.Text
                m.placas = txtPlacas.Text
                m.capacidad = txtCapacidad.Text
                m.KMGalon = txtKmGalon.Text

                ctx.AddTotblTransportes(m)
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
                Dim m As tblTransporte = (From e1 In ctx.tblTransportes Where e1.idTransporte = Me.txtCodigo.Text Select e1).First()
                m.idTipoTransporte = CInt(cmbTipoTransporte.SelectedValue)
                m.descripcion = txtDescripcion.Text
                m.placas = txtPlacas.Text
                m.capacidad = txtCapacidad.Text
                m.KMGalon = txtKmGalon.Text


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
                Dim m As tblTransporte = (From e1 In ctx.tblTransportes Where e1.idTransporte = Me.txtCodigo.Text Select e1).First()

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
