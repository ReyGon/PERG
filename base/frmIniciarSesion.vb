Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Linq
Imports Telerik.WinControls

Public Class frmIniciarSesion
    Dim tbl As New clsDevuelveTabla
    Dim blUsr As New bl_Usuario
    Dim alerta As New bl_Alertas

    Private Function verificaUsuario() As Boolean
        Dim bitValido As Boolean = False
        Dim codempresa As Integer = 2
        mdlPublicVars.usuarioSistema = mdlPublicVars.usuarioSistema
        mdlPublicVars.claveSistema = mdlPublicVars.claveSistema
        mdlPublicVars.bd = "dsi_pos_" & cmbEmpresa.Text
        mdlPublicVars.usuario = txtUsuario.Text
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
            bitValido = blUsr.ValidaUsuarioExiste(txtClave.Text, txtUsuario.Text)

        Catch ex As Exception
            RadMessageBox.Show("Usuario / Clave no coinciden", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            bitValido = False
        End Try

        Return bitValido
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Function fnIniciarSesion()
        If Me.txtUsuario.Text = "" Then
            RadMessageBox.Show("Debe de ingresar un usuario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End If

        If Me.txtClave.Text = "" Then
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
        mdlPublicVars.BaseDatosNombre = cmbEmpresa.Text
        'Dim bitacora As New clsBitacoraRegistro
        'bitacora.Registro("usuario", "login", "0", "1", "inicio de sesion")
        proyecto = "Sistema Empresarial de Ventas"
        Me.Hide()
        frmMenuPrincipal.Show()

        Return False
    End Function

    Protected Function fnLlenar_DatosDeConexion() As Boolean
        fnLlenar_DatosDeConexion = False

        Try
            'leer el archivo xml con nombre config.
            Dim xmlConfig As String = "config.xml"
            Dim ds As New System.Data.DataSet
            ds.ReadXml(xmlConfig)
            Dim dr As System.Data.DataRow

            'recorre los datos del archivo.
            For Each dr In ds.Tables(0).Rows
                'Llenar los datos de configuracion en las variables publicas.
                mdlPublicVars.servidor = dr.Item(0)
                mdlPublicVars.bd = dr.Item(1)
                mdlPublicVars.urlLicencia = dr.Item(2)
            Next

            fnLlenar_DatosDeConexion = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Function

    Private Sub fnLlenarbd()
        Dim bd As New clsBaseDatos
        bd.fnLlenarBaseDatos(cmbEmpresa)


    End Sub

    Private Sub IniciarSesion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fnLlenar_DatosDeConexion() = False Then
            Exit Sub
        End If
        fnLlenarbd()

        ''Me.WindowState = FormWindowState.Maximized

        Try
            mdlPublicVars.comboActivarListaTelerik(cmbEmpresa)
            mdlPublicVars.fnFormulario_quitaBarraTitulo(Me)


            'conexion con modelo entity
            'mdlPublicVars.conexionEntity()

            ''llenar el combo de empresas
            'Dim em = (From x In ctx.tblEmpresas Select Codigo = x.idEmpresa, Nombre = x.nombre)

            'cmbEmpresa.DataSource = Nothing
            'cmbEmpresa.ValueMember = "Codigo"
            'cmbEmpresa.DisplayMember = "Nombre"
            'cmbEmpresa.DataSource = em
        Catch ex As Exception

        End Try


        'Ocultar la barra de titulo.


        'Dim bl As New bl_licencia
        'Dim txt As New TextBox

        ''si retorna true, deja pasar, FALSE muestra el formulario de Licencia.
        'If bl.fnInicio(txt) = False Then
        '    mdlPublicVars.bitLicencia = False
        '    Me.Hide()
        '    Me.Visible = False
        '    FrmLicencia.ShowDialog()
        'Else
        '    'bit licencia true, indica que ya se ingreso correctamente la licencia.
        '    bitLicencia = True
        'End If

        'If bitLicencia = False Then
        '    txtUsuario.Enabled = False
        '    txtContraseña.Enabled = False
        '    pbOk.Enabled = False

        'End If
    End Sub

    Private Sub txtContraseña_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            fnIniciarSesion()
        End If

    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs)
        frmCrearEmpresa.Text = "Empresa"
        frmCrearEmpresa.ShowDialog()
        fnLlenarbd()
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        fnIniciarSesion()
    End Sub
End Class