Public Class clsPresentacion


    Public Function fnNumericoMayorCero(ByVal txt As TextBox, ByVal errorProvider As ErrorProvider)

        Dim mensaje As String

        If txt.Text.Length > 0 Then

            If IsNumeric(txt.Text) Then
                If txt.Text > 0 Then
                    mensaje = ""
                    errorProvider.SetError(txt, mensaje.ToString)
                Else
                    mensaje = "Requiere Numerico > 0"
                    errorProvider.SetError(txt, mensaje.ToString)
                    Return True
                End If
                
            Else
                mensaje = "Requiere Numerico"
                errorProvider.SetError(txt, mensaje.ToString)
                Return True
            End If
        Else
            mensaje = "Requiere caracter numerico"
            errorProvider.SetError(txt, mensaje.ToString)
            Return True
        End If

        Return False
    End Function

End Class
