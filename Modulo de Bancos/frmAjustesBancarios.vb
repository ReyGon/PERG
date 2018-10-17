Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmAjustesBancarios

    Private permiso As New clsPermisoUsuario

    Private Sub frmAjustesbancarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
End Class
