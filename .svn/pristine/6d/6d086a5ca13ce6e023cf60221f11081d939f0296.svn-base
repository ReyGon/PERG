Option Strict On

Imports System
Imports System.Collections
Imports Telerik.WinControls

Public Class clsValidar

    Private valida As Boolean
    Private expresion As String
    Private pila As Stack

    'Valida la expresion
    Public Function validar(exp As String) As Boolean
        valida = False
        expresion = exp
        Dim tokens() As String = expresion.Split(CChar(" "))
        pila = New Stack

        'Establezco un delegado para cada valor
        Dim delegado As New Action(Of Object)(AddressOf fnVerifica)

        Array.ForEach(tokens, delegado)

        If pila.Count = 0 Then
            valida = True
            expresion = expresion.Replace("{", "(")
            expresion = expresion.Replace("[", "(")
            expresion = expresion.Replace("]", ")")
            expresion = expresion.Replace("}", ")")
        End If

        Return valida
    End Function

    'Verifica si es un operando o un operado
    Private Sub fnVerifica(token As Object)
        Try
            Dim operando As Decimal = CDec(token)
        Catch ex As Exception
            Dim operador As String = CStr(token)
            If esAgrupador(operador) Then
                If (pila.Count = 0) Then
                    pila.Push(operador)
                Else
                    fnAnaliza(operador, pila)
                End If
            End If
        End Try
    End Sub

    'Analiza si es un agrupador de cierre o de abertura
    Private Shared Sub fnAnaliza(operador As String, pila As Stack)
        Dim agrupadores As New Hashtable
        agrupadores.Add(")", "(")
        agrupadores.Add("}", "{")
        agrupadores.Add("]", "[")

        If abre(operador) Then
            pila.Push(operador)
        Else
            If agrupadores.Item(operador).ToString.Equals(pila.Peek) Then
                pila.Pop()
            Else
                RadMessageBox.Show("Expresion DESBALANCEADA", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        End If
    End Sub

    'Verifica si es un operador de apertura
    Private Shared Function abre(operador As String) As Boolean
        Select Case operador
            Case "(", "{", "["
                Return True
        End Select

        Return False
    End Function

    'Verifica si es un operador
    Private Shared Function esAgrupador(agrupador As String) As Boolean
        Select Case agrupador
            Case "(", "[", "{", ")", "]", "}"
                Return True
        End Select

        Return False
    End Function
End Class
