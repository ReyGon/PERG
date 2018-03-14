Public Class Pl_errores

    Public Function fntxtNumero(ByVal txt As TextBox, ByVal er As ErrorProvider)
        If IsNumeric(txt.Text) Then
            er.SetError(txt, "")
        Else
            er.SetError(txt, "Requiere Numero")
            Return True
        End If
        Return False

    End Function

    Public Function fntxtNumeroMayorCero(ByVal txt As TextBox, ByVal er As ErrorProvider)
        If IsNumeric(txt.Text) Then

            Dim n As Double = txt.Text
            If n > 0 Then
                er.SetError(txt, "")
            Else
                er.SetError(txt, "Numero mayor a cero")
                Return True
            End If
        Else
            er.SetError(txt, "Requiere Numero")
            Return True
        End If

        Return False
    End Function



    Public Function fntxtNumeroMayorCeroIguales(ByVal txt1 As TextBox, ByVal txt2 As TextBox, ByVal er As ErrorProvider)
        If fntxtNumeroMayorCero(txt1, er) = True Then
            Return True
        End If

        If fntxtNumeroMayorCero(txt2, er) = True Then
            Return True
        End If

        Dim uno As Double = txt1.Text
        Dim dos As Double = txt2.Text
        If uno = dos Then
            er.SetError(txt1, "")
            er.SetError(txt2, "")
        Else
            er.SetError(txt1, "Valores desiguales")
            er.SetError(txt2, "Valores desiguales")
            Return True
        End If

        Return False
    End Function


    Public Function fnComboVacio(ByVal cmb As ComboBox, ByVal er As ErrorProvider)

        If cmb.Items.Count = 0 Then
            er.SetError(cmb, "No Existen valores")
            Return True
        Else
            er.SetError(cmb, "")
        End If

        If cmb.SelectedValue Is Nothing Then
            er.SetError(cmb, "Seleccione un valor")
            Return True
        Else
            er.SetError(cmb, "")
        End If

        If cmb.Text.Length > 0 Then
            er.SetError(cmb, "")
        Else
            er.SetError(cmb, "Seleccione un valor")
            Return True
        End If

        Return False
    End Function

End Class
