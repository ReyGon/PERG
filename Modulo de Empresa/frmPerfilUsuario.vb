Imports System.Linq

Public Class frmPerfilUsuario

    Private Sub frmPerfilUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarDatos()
    End Sub

    'CAMBIAR FOTO
    Private Sub fnCambiarFoto() Handles Me.panel0
        Dim user As tblUsuario = (From x In ctx.tblUsuarios.AsEnumerable
                                       Where x.idUsuario = mdlPublicVars.idUsuario
                                       Select x).FirstOrDefault
        frmCapturarFoto.Text = "Imagen: Vendedor"
        frmCapturarFoto.bitVendedor = True
        frmCapturarFoto.codigo = user.tblVendedor.idVendedor
        frmCapturarFoto.StartPosition = FormStartPosition.CenterScreen
        frmCapturarFoto.ShowDialog()
        frmCapturarFoto.Dispose()
        fnLlenarDatos()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.Panel1
        Me.Close()
    End Sub

    'Utilizada para llenar los datos
    Private Sub fnLlenarDatos()

        Dim usuario As tblUsuario = (From x In ctx.tblUsuarios.AsEnumerable
                                       Where x.idUsuario = mdlPublicVars.idUsuario
                                       Select x).FirstOrDefault

        lblUsuario.Text = usuario.nombre
        lblGrupo.Text = usuario.tblGrupoUsuario.nombre
        lblVendedor.Text = usuario.tblVendedor.nombre

        'Obtenemos la ruta de la foto
        Dim ruta As String = usuario.tblVendedor.foto

        If ruta IsNot Nothing Then
            fnCargarFoto(pbxFoto, ruta)
        End If
    End Sub

    'CARGAR FOTO
    Private Sub fnCargarFoto(ByRef pct As PictureBox, ByVal direccion As String)
        Try
            'Vaciamos la imagen
            If pct.Image IsNot Nothing Then
                pct.Image = Nothing
            End If

            If direccion IsNot Nothing Then
                If direccion.Length > 0 Then
                    Dim stream As New System.IO.StreamReader(direccion)
                    pct.Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    pct.SizeMode = PictureBoxSizeMode.StretchImage
                    pct.BorderStyle = BorderStyle.Fixed3D
                End If
            End If
        Catch ex As Exception
            alerta.contenido = "Ocurrio un error al intentar abrir la imagen"
            alerta.fnErrorContenido()
        End Try
    End Sub
End Class
