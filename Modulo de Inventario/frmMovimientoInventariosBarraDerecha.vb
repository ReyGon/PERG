Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmMovimientoInventariosBarraDerecha
    Public alerta As New bl_Alertas
    Dim permiso As New clsPermisoUsuario

    Private Sub frmMovimientoInventarioBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Dim frm As Form = frmMovimientoInventarios
        frm.Text = "Mov. de Inventario"
        frm.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmEspeciales(frm, True)
        Me.Hide()
    End Sub

    Private Sub fnPanel2() Handles Me.panel2

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim movimiento As String = mdlPublicVars.superSearchNombre

            If movimiento = "Ajuste en Bodega" Or movimiento = "Traslado entre bodega" Then
                frmMovimientoInventariosConceptos.Text = "Movimientos"
                frmMovimientoInventariosConceptos.StartPosition = FormStartPosition.CenterScreen
                frmMovimientoInventariosConceptos.BringToFront()
                frmMovimientoInventariosConceptos.Focus()
                permiso.PermisoDialogEspeciales(frmMovimientoInventariosConceptos)
                frmMovimientoInventariosConceptos.Dispose()
            ElseIf movimiento = "Devolucion Cliente" Then
                frmClienteDevolucionConceptos.Text = "Devolucion"
                frmClienteDevolucionConceptos.StartPosition = FormStartPosition.CenterScreen
                frmClienteDevolucionConceptos.BringToFront()
                frmClienteDevolucionConceptos.Focus()
                permiso.PermisoDialogEspeciales(frmClienteDevolucionConceptos)
                frmClienteDevolucionConceptos.Dispose()
            End If
        End If
    End Sub

    Private Sub frmMovimientoInventariosBarraDerecha_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmMovimientoInventariosLista.frm_llenarLista()
    End Sub
End Class
