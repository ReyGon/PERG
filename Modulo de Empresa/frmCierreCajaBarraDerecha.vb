Imports Telerik.WinControls

Public Class frmCierreCajaBarraDerecha

    Public frmAnterior As New Form
    Private permiso As New clsPermisoUsuario

    Private Sub frmPedidosFacturasBarraIzquierda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            frmCajaMovimiento.Text = "Movimiento de Caja"
            frmCajaMovimiento.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmCajaMovimiento)
            frmCajaMovimiento.Dispose()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'PANEL2
    Private Sub fnPanel2() Handles Me.panel2
        Try
            frmCierreCajaPagosPendientes.Text = "Cheques Pendientes"
            frmCierreCajaPagosPendientes.StartPosition = FormStartPosition.CenterScreen
            frmCierreCajaPagosPendientes.ShowDialog()
            frmCierreCajaPagosPendientes.Dispose()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


End Class
