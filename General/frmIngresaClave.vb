Imports System.Linq
Imports Telerik.WinControls
Imports System.Data.EntityClient


Public Class frmIngresaClave
    Private acepto As Boolean

    Private Sub frmIngresaClave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If mdlPublicVars.bitEncomienda = True Then
                Me.lblUsuario.Visible = True
                Me.txtUsuario.Visible = False
                Me.cmbUsuario.Visible = False
                fnUsuario()
            Else
                Me.cmbUsuario.Visible = True
                Me.txtUsuario.Visible = False
                Me.lblUsuario.Visible = False

                Me.txtUsuario.Select()
                Me.txtUsuario.Focus()

                fnLlenarUsuarios()

            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub fnLlenarUsuarios()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim usuario = (From x In conexion.tblUsuarios Where x.bloqueado = False Select Codigo = x.idUsuario, Nombre = x.nombre)

            With cmbUsuario
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = usuario
            End With

            conn.Close()
        End Using

    End Sub

    'Funcion utilizada para obtener los datos del usuario
    Private Sub fnUsuario()
        Try
            Dim usuario As tblUsuario = (From x In ctx.tblUsuarios _
                                          Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault

            lblUsuario.Text = usuario.nombre
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If mdlPublicVars.bitEncomienda = True Then
            fnIngreso()
        Else
            fnIngreso2()
        End If
    End Sub

    'Funcion de ingreso
    Private Sub fnIngreso()
        acepto = True
        mdlPublicVars.superSearchClave = txtClave.Text
        Me.Close()
    End Sub

    Private Sub fnIngreso2()
        acepto = True
        mdlPublicVars.supersearchUsuario = Me.cmbUsuario.Text
        mdlPublicVars.superSearchClave = Me.txtClave.Text
        mdlPublicVars.superSearchIdUsuario = Me.cmbUsuario.SelectedValue
        Me.Close()
    End Sub
    Private Sub frmIngresaClave_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If acepto = False Then
            If mdlPublicVars.bitEncomienda = True Then
                mdlPublicVars.superSearchClave = ""
            Else
                mdlPublicVars.superSearchClave = ""
                mdlPublicVars.supersearchUsuario = ""
            End If

        End If
    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If mdlPublicVars.bitEncomienda = True Then
                fnIngreso()
            Else
                fnIngreso2()
            End If
        End If
    End Sub

End Class
