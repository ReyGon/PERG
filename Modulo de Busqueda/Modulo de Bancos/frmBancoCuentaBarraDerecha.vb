Public Class frmBancoCuentaBarraDerecha

    Private Sub frmBancoCuentaBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    'ESTADO DE CUENTA
    Private Sub fnPanel1() Handles Me.panel1
        frmBancoReporteEstadoCuenta.Text = "Estado de Cuenta"
        frmBancoReporteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
        frmBancoReporteEstadoCuenta.ShowDialog()
        frmBancoReporteEstadoCuenta.Dispose()
    End Sub

    'REPORTE DE CHEQUES
    Private Sub fnPanel2() Handles Me.panel2
        frmBancoReporteCheques.Text = "Reporte de Cheques"
        frmBancoReporteCheques.StartPosition = FormStartPosition.CenterScreen
        frmBancoReporteCheques.ShowDialog()
        frmBancoReporteCheques.Dispose()
    End Sub

    'REPORTE DE DEBITOS
    Private Sub fnPanel3() Handles Me.panel3
        frmBancoReporteDebitos.Text = "Reporte de Débitos"
        frmBancoReporteDebitos.StartPosition = FormStartPosition.CenterScreen
        frmBancoReporteDebitos.ShowDialog()
        frmBancoReporteDebitos.Dispose()
    End Sub

    'REPORTE DE CREDITOS
    Private Sub fnPanel4() Handles Me.panel4
        frmBancoReporteCreditos.Text = "Reporte de Créditos"
        frmBancoReporteCreditos.StartPosition = FormStartPosition.CenterScreen
        frmBancoReporteCreditos.ShowDialog()
        frmBancoReporteCreditos.Dispose()
    End Sub
End Class
