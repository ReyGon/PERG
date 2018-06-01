Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Windows
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmValidacionClave

    Private Sub frmValidacionClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtClave.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtClave.Text = "" Then
                    RadMessageBox.Show("Debe ingresar una clave valida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    txtClave.Focus()
                    Exit Sub
                End If

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    mdlPublicVars.ClaveVencidos = (From x In conexion.tblConfiguracions Where x.id = 124 Select x.valor).FirstOrDefault

                    conn.Close()
                End Using

                mdlPublicVars.superSearchClaveVencidos = Me.txtClave.Text

                If mdlPublicVars.superSearchClaveVencidos = mdlPublicVars.ClaveVencidos Then
                    Me.Close()
                    mdlPublicVars.ClaveVencidosStatus = True
                Else
                    RadMessageBox.Show("Clave Incorrecta", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    txtClave.Focus()
                    Exit Sub
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
