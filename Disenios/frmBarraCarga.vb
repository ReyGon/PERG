Public Class frmBarraCarga

    Private Sub frmBarraCarga_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Me.Progreso.Minimum = 0
            Me.Progreso.Maximum = 100
            Me.Progreso.Value1 = 0
            Me.Progreso.Text = "0 %"



        Catch ex As Exception

        End Try
    End Sub
End Class