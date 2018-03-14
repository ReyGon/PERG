Imports System.Threading
Imports System.IO

Public Class bl_ManejaCarpetas
    Private _direccion As String
    Private hilo As Thread

    Public Property direccion As String
        Get
            direccion = _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property

    Public Sub fnPreparar()
        Me.hilo = New Thread(AddressOf Me.fnCrearCarpeta)
        Me.hilo.Start()
    End Sub

    Private Sub fnCrearCarpeta()
        Try
            If _direccion IsNot Nothing Then
                If _direccion.Length > 0 Then
                    If Not Directory.Exists(_direccion) Then
                        Directory.CreateDirectory(_direccion)
                        Dim folder_info As IO.DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(_direccion)
                        'folder_info.Attributes = IO.FileAttributes.Hidden
                    End If
                End If
            End If

        Catch ex As Exception
            Dim alerta As New bl_Alertas
            alerta.contenido = "Ocurrio un error al intentar crear la carpeta: " & vbCrLf & direccion
            alerta.fnErrorContenido()
        End Try
    End Sub
End Class
