Imports System.Linq
Imports Telerik.WinControls

Public Class frmCambioUsuario
    Dim blUsr As New bl_Usuario

    Public Function fnIniciarSesion() As Boolean

        If Me.txtUsuario.Text = "" Then
            RadMessageBox.Show("Debe de ingresar un usuario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End If

        If Me.txtContraseña.Text = "" Then
            RadMessageBox.Show("Debe de ingresar una contraseña", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End If

        '1ro. Revisamos la existencia del usuario en la BD de configuraciones
        If verificaUsuario() = False Then
            alerta.contenido = "Clave/Usuario Incorrecta !!!"
            alerta.fnErrorContenido()
            Return False
        End If

        'Cargar la configuración del sistema
        mdlPublicVars.CargarVariablesdeConfiguracion()

        'Dim bitacora As New clsBitacoraRegistro
        'bitacora.Registro("usuario", "login", "0", "1", "inicio de sesion")
        frmMenuPrincipal.Show()

        proyecto = "Sistema Empresarial de Ventas"

        Return True
    End Function

    Private Function verificaUsuario() As Boolean
        Dim bitValido As Boolean = False

        Dim codempresa As Integer = mdlPublicVars.idProyecto
        mdlPublicVars.usuarioSistema = mdlPublicVars.usuarioSistema
        mdlPublicVars.claveSistema = mdlPublicVars.claveSistema
        mdlPublicVars.conexion()

        Dim cnn As New System.Data.SqlClient.SqlConnection
        Try
            cnn.ConnectionString = mdlPublicVars.cnn
            cnn.Open()
            cnn.Close()
            cnn.Dispose()

            'conectar el modelo de datos.
            mdlPublicVars.conexionEntity()

            'validar usuario
            bitValido = blUsr.ValidaUsuarioExiste(txtContraseña.Text, txtUsuario.Text)

        Catch ex As Exception
            RadMessageBox.Show("Usuario / Clave no coinciden", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            bitValido = False
        End Try

        Return bitValido
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If fnIniciarSesion() Then
            alerta.contenido = "Cambio de usuario realizado exitosamente"
            alerta.fnErrorContenido()
            mdlPublicVars.fnFRMhijos_cerrar(Me)
            Me.Close()
            mdlPublicVars.fnMenu_Hijos(Me)
            frmMenuPrincipal.itemUsuario.Text = mdlPublicVars.usuario
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, btnSalir.Click
        Me.Close()
    End Sub

End Class
