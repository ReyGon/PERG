
Imports System.Management
Imports System.Windows.Forms

Public Class bl_licencia
    Dim sContent As String = vbNullString

    Public Function fnInicio(ByVal txtEncriptado As TextBox)
        'retorna true si deja pasar al formulario de login.

        Dim retorno As Boolean = False
        'Dim pathLiciencia As String = mdlPublicVars.urlLicencia.ToString 'Application.StartupPath & "\lic.lic"
        Dim Archivo As System.IO.FileStream
        Try

            'si el archivo no existe.
            If Not System.IO.File.Exists(mdlPublicVars.urlLicencia.ToString) Then
                MsgBox("No existe archivo de licencia" + mdlPublicVars.urlLicencia.ToString, MsgBoxStyle.Critical, "!!!")
                ' crea un archivo vacio prueba.txt  
                Archivo = System.IO.File.Create(mdlPublicVars.urlLicencia.ToString)
                ' error
                retorno = False
            Else

                'leer licencia de la pc que usa el programa.
                Dim licenciaPcGuardada As String = fnLeerLicencia()

                Dim serie As String = fnSerieEncriptadaValida()

                If serie <> licenciaPcGuardada Then
                    'MsgBox("Licencia No valida" & Chr(13) & "Serie:" & SerieEncriptada(), MsgBoxStyle.Critical, "!!!")
                    txtEncriptado.Text = fnSerieEncriptada()
                Else
                    retorno = True
                End If
                'MsgBox("Licencia" & sContent)
            End If
        Catch oe As Exception
            'MsgBox(oe.Message, MsgBoxStyle.Critical)
            retorno = False
        End Try

        Return retorno
    End Function

    Public Function fnLeerLicencia() As String
        'lee la licencia solo de esta maquina.
        Dim LicenciaPC As String = ""

        Try
            Dim SPath As String = mdlPublicVars.urlLicencia.ToString
            Dim licencias() As String
            Dim unaLic() As String

            With My.Computer.FileSystem
                ' verifica si existe el path  
                If .FileExists(SPath) Then
                    ' lee todo el contenido  
                    sContent = .ReadAllText(SPath)

                    'guarda todas las licencias y las separa una por una.
                    licencias = Split(sContent, vbNewLine)
                    Dim i As Integer = 0
                    For i = 0 To licencias.Length - 1

                        unaLic = Split(licencias(i), "__")

                        'si el nombre de la pc de la maquina es igual al nombre de la pc almacenada en .lic.
                        If My.Computer.Name.ToUpper.ToString = unaLic(0).ToUpper.ToString Then
                            'retornar la licencia.
                            LicenciaPC = unaLic(1).ToString
                            'finalizar el ciclo
                            i = licencias.Length
                        End If
                    Next


                Else
                    MsgBox("ruta inválida", MsgBoxStyle.Critical, "error")
                End If
            End With
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return LicenciaPC
    End Function

    Private Function fnSerie() As String
        Dim valor As String = ""
        Dim mosBios As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Bios")
        For Each bios As ManagementObject In mosBios.Get()
            Try
                'MessageBox.Show(bios("SerialNumber").ToString())
                valor = bios("SerialNumber").ToString()
            Catch ex As Exception
            End Try
        Next

        Dim mosProc As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Processor")
        For Each processor As ManagementObject In mosProc.Get()
            Try
                'MessageBox.Show(processor("ProcessorId").ToString())
                'MessageBox.Show(processor("UniqueId").ToString())
                'MessageBox.Show(processor("PNPDeviceID").ToString())
                valor = valor + processor("ProcessorId").ToString()
            Catch ex As Exception
            End Try
        Next
        Return valor & Application.ProductVersion & Application.ProductName.ToString
    End Function

    Public Function fnSerieEncriptada() As String
        Return RijndaelSimple.Encrypt(Me.fnSerie, "1", "2", "MD5", "2", "@1B2c3D4e5F6g7H8", 256)
    End Function

    Public Function fnSerieEncriptadaValida() As String
        Return RijndaelSimple.Encrypt("GPI" & Me.fnSerie & "GPI", "1", "2", "MD5", "2", "@1B2c3D4e5F6g7H8", 256)
    End Function


End Class
