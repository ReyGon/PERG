Option Strict On

Public Class clsResolver

    'Resuelve un expresion infija
    Public Function fnResolver(expresion As String) As Decimal
        Dim pila As New Stack
        Dim cadena As String = expresion
        Dim tokens() As String = cadena.Trim.Split(CChar(" "))

        For Each item As Object In tokens
            Try
                Dim numero As Decimal = CDec(CStr(item))
                pila.Push(numero)
            Catch ex As Exception
                pila.Push(fnOpera(pila, CStr(item)))
            End Try
        Next

        Return CDec(pila.Peek)
    End Function

    'Realiza una operacion
    Private Function fnOpera(pila As Stack, operador As String) As Decimal
        Dim z As Decimal = 0
        Dim op2 As Decimal = CDec(pila.Pop())
        Dim op1 As Decimal = CDec(pila.Pop())

        Select Case operador
            Case "+"
                z = op1 + op2
            Case "-"
                z = op1 - op2
            Case "/"
                z = op1 / op2
            Case "*"
                z = op1 * op2
        End Select

        Return z
    End Function

End Class
