Public Class clsCodigoTienda
    Private _codigo As String

    Public Property codigo() As String
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property


    Public Function costo() As String

        Dim i As Int16 = 0
        Dim caracter As String = ""
        Dim acumulado As String = ""

        For i = 0 To codigo.Length - 1
            caracter = codigo.Substring(i, 1)
            If caracter = "J" Then
                acumulado = acumulado & "1"
            ElseIf caracter = "E" Then
                acumulado = acumulado & "2"
            ElseIf caracter = "S" Then
                acumulado = acumulado & "3"
            ElseIf caracter = "U" Then
                acumulado = acumulado & "4"
            ElseIf caracter = "C" Then
                acumulado = acumulado & "5"
            ElseIf caracter = "R" Then
                acumulado = acumulado & "6"
            ElseIf caracter = "I" Then
                acumulado = acumulado & "7"
            ElseIf caracter = "Z" Then
                acumulado = acumulado & "8"
            ElseIf caracter = "T" Then
                acumulado = acumulado & "9"
            ElseIf caracter = "O" Then
                acumulado = acumulado & "0"
            Else
                acumulado = "ERROR"
                i = codigo.Length - 1
            End If
        Next

        If acumulado <> "ERROR" Then
            If acumulado.Length >= 3 Then
                acumulado = acumulado.Insert(acumulado.Length - 2, ".")
            Else
                acumulado = "0." & acumulado
            End If
        End If

        Return acumulado
    End Function


End Class
