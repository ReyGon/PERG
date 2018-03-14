Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.IO
Imports System.Transactions
Imports System.Data.SqlClient

Public Class frmTipoMovimientoInventario

    Public permiso As New clsPermisoUsuario

    Private Sub btnAgregarCodigo_Click(sender As Object, e As EventArgs) Handles btnAgregarCodigo.Click
        frmMovimientoInventarios.bitModificar = False
        frmMovimientoInventarios.Text = "Ajustes y Traslados"
        frmMovimientoInventarios.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmBaseEspeciales(frmMovimientoInventarios, True)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmProduccion.Text = "Produccion"
        frmProduccion.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmBaseEspeciales(frmProduccion, True)
        Me.Close()
    End Sub
End Class
