Public Class frmTexto
    Public guarda As Boolean = False

    Private _texto As String
    Public Property texto As String
        Get
            texto = _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property

    Private Sub pbAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnAgregar()
    End Sub

    Private Sub fnAgregar()
        Try
            mdlPublicVars.superSearchNombre = txtTexto.Text
            guarda = True
            Me.Close()
        Catch ex As Exception
            mdlPublicVars.superSearchNombre = ""
        End Try

        Me.Close()
    End Sub

    Private Sub frmTexto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTexto.Text = If(texto Is Nothing, "", texto)
        guarda = False
    End Sub

    Private Sub frmTexto_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If guarda = False Then
            mdlPublicVars.superSearchNombre = ""
        End If
    End Sub
End Class
