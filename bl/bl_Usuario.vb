Imports System.Linq
Imports System.Management
Imports System.Windows.Forms


Public Class bl_Usuario
    Dim sContent As String = vbNullString

    'funcion principal, que valida si el usuario tiene acceso a la base de datos.


    Public Function ValidaUsuarioExiste(ByVal clave As String, usuario As String)
        'retorna true si deja pasar al formulario de login.

        Dim retorno As Boolean = False

        Try

            Dim ClaveEncriptada As String = fnSerieEncriptadaValida(clave)


            Dim usr As tblUsuario = (From x In ctx.tblUsuarios Where x.bloqueado = 0 And x.nombre = usuario And x.clave = ClaveEncriptada).FirstOrDefault


            Dim usrEmpresa = (From x In ctx.tblUsuarios Join y In ctx.tblusuarioEmpresas On x.idUsuario Equals y.idusuario
                                     Where x.bloqueado = 0 And x.nombre = usuario And y.idempresa = mdlPublicVars.idEmpresa And x.clave = ClaveEncriptada
                                     ).FirstOrDefault

            If usrEmpresa IsNot Nothing Then
                mdlPublicVars.idUsuario = usrEmpresa.x.idUsuario
                mdlPublicVars.usuario = usr.nombre
                mdlPublicVars.superUsuario = usrEmpresa.x.superUsuario
                retorno = False

            Else
                If usr.superUsuario = True Then
                    mdlPublicVars.idUsuario = usr.idUsuario
                    mdlPublicVars.superUsuario = usr.superUsuario
                    retorno = True
                Else
                    retorno = False
                End If

            End If
            If usr IsNot Nothing Then
                retorno = True
            Else
                retorno = False
            End If

        Catch oe As Exception
            retorno = False
        End Try

        Return retorno
    End Function


    Public Function fnCrearClave(clave As String)
        Return RijndaelSimple.Encrypt("DSI" & clave & "POS_ver1.0", "1", "2", "MD5", "2", "@a19b05c88F6g7H8", 256)
    End Function

    Public Function fnSerieEncriptada(clave As String) As String
        Return RijndaelSimple.Encrypt(clave, "1", "2", "MD5", "2", "@a19b05c88F6g7H8", 256)
    End Function

    Public Function fnSerieEncriptadaValida(clave As String) As String
        Return RijndaelSimple.Encrypt("DSI" & clave & "POS_ver1.0", "1", "2", "MD5", "2", "@a19b05c88F6g7H8", 256)
    End Function


End Class
