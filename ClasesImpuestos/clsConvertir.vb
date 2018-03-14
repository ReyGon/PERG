Public Class clsConvertir
    Private expresionSalida As String

    'Convierte la expresion infija a una expresion postfija
    Public Function fnConvierte(expresion As String) As String
        Dim expresionInfija As String = expresion
        expresionSalida = ""

        Dim tokens() As String = expresionInfija.Split(" ")
        Dim pila As New Stack

        For Each item As Object In tokens
            Try
                Dim operando As Decimal = CDec(CStr(item))
                expresionSalida += item.ToString & " "
            Catch ex As Exception
                Dim operador As String = CStr(item)

                If Not operador.Equals(")") Then
                    If pila.Count = 0 Then
                        pila.Push(operador)
                    Else
                        expresionSalida = fnPrioridad(operador, pila, expresionSalida)
                    End If
                Else
                    While (Not pila.Peek.ToString.Equals("("))
                        If Not pila.Count = 0 Then
                            expresionSalida += pila.Pop() + " "
                        End If
                    End While
                    pila.Pop()
                End If
            End Try
        Next

        While Not pila.Count = 0
            expresionSalida += pila.Pop() + " "
        End While

        Return expresionSalida
    End Function

    'Verifica la priodad de los elementos
    Private Function fnPrioridad(operador As String, pila As Stack, expresionSalida As String)
        Dim infija As New Hashtable
        Dim dentro As New Hashtable

        infija.Add("^", "4")
        infija.Add("*", "2")
        infija.Add("/", "2")
        infija.Add("+", "1")
        infija.Add("-", "1")
        infija.Add("(", "5")

        dentro.Add("^", "3")
        dentro.Add("*", "2")
        dentro.Add("/", "2")
        dentro.Add("+", "1")
        dentro.Add("-", "1")
        dentro.Add("(", "0")

        If (CInt(infija.Item(operador)) > CInt(dentro.Item(pila.Peek()))) Then
            pila.Push(operador)
        Else
            expresionSalida += pila.Pop().ToString & " "
            pila.Push(operador)
        End If

        Return expresionSalida
    End Function

End Class
