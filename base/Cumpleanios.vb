Imports System.Xml

Public NotInheritable Class frmCumpleanios

    Public counter As Integer

    Private Sub frmBienvenida_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Call iniciartimer()

    End Sub

    Private Sub iniciartimer()
        counter = 0
        Timer1.Interval = 2000
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If counter >= 3 Then
            Timer1.Enabled = False
            counter = 0
            Me.Close()
        Else
            counter = counter + 1
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint_1(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class
