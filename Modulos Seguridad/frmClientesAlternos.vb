Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Windows
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmClientesAlternos

    Private Sub frmClientesAlternos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtNombre.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtNombre.Text = "" Then
                    RadMessageBox.Show("Debe escribir un nombre", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    txtNombre.Focus()
                    Exit Sub
                End If

                txtDireccion.Focus()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtNombre.Text = "" Then
                    RadMessageBox.Show("Debe escribir un nombre", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    txtNombre.Focus()
                    Exit Sub
                End If

                If txtDireccion.Text = "" Then
                    RadMessageBox.Show("Debe escribir una dirección", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    txtDireccion.Focus()
                    Exit Sub
                End If

                mdlPublicVars.superSearchNombreAlterno = Me.txtNombre.Text
                mdlPublicVars.superSearchDireccionAlterno = Me.txtDireccion.Text

                Me.Close()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
