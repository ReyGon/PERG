Public Class FrmBaseMovimientos
    Public alerta As New bl_Alertas

    Private Sub tmrHora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHora.Tick
        Me.lbHora.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub FrmBaseMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtFecha.Text = Format(Now, "dd/MM/yyyy").ToString
        lbTituloFrm.Text = Me.Text
    End Sub
End Class
