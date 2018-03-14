Imports System.Linq
Imports Telerik.WinControls

Public Class frmProveedorDevolucionBarraDerecha
    Public alerta As bl_Alertas
    Private permiso As New clsPermisoUsuario

    Private Sub frmClienteDevolucionBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                Dim codigo As Integer = mdlPublicVars.superSearchId
                frmProveedorDevolucionGuia.Text = "Guias"
                frmProveedorDevolucionGuia.codigo = codigo
                frmProveedorDevolucionGuia.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogMantenimientoTelerik(frmProveedorDevolucionGuia)
                frmProveedorDevolucionGuia.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
