Public Class frmAlertasPantalla

    Private Sub frmAlertasPantalla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 5000
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Hide()
        Timer1.Enabled = False
    End Sub
End Class