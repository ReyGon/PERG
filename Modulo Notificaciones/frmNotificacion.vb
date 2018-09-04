Public Class frmNotificacion

    Dim x As Integer = 0

    Private Sub frmNotificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(
        Screen.PrimaryScreen.Bounds.Width - 300, _
        Screen.PrimaryScreen.Bounds.Height)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Me.Opacity = 0 Then Me.Close()

        If x = 200 Then
            Me.Opacity -= 0.02
        End If

        If Not Me.Location.Y = Screen.PrimaryScreen.WorkingArea.Height - 100 Then
            Me.Location = New Point(Me.Location.X, Me.Location.Y - 2)
        End If

        If Not x = 200 Then x += 1

    End Sub
End Class