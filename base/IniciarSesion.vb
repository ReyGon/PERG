Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient


Public Class IniciarSesion
    Dim tbl As New clsDevuelveTabla

    

    Private Function verificaUsuario(ByVal usuario As String) As Boolean

        verificaUsuario = False
        tbl.sqlString = " select u.idusuario,nombre,superUsuario,idGrupo from tblusuarios u, tblusuarioempresa ue  where u.idusuario=ue.idusuario and bloqueado = 0 and nombre='" & usuario.ToString & "'"
        If tbl.Tabla.Rows.Count = 0 Then
            MessageBox.Show("Solicite privilegios a su administrador !!!", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Function
        End If

        mdlPublicVars.idUsuario = tbl.Tabla.Rows(0).Item(0)
        frmMenuPrincipal.usuario.Text = tbl.Tabla.Rows(0).Item(1)
        mdlPublicVars.superUsuario = tbl.Tabla.Rows(0).Item(2)
        mdlPublicVars.idEmpresa = cmbEmpresa.SelectedValue
        Return True

    End Function


    Private Sub Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOk.Click
        fnIniciarSesion()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Function fnIniciarSesion()

        If Me.txtUsuario.Text = "" Then
            MsgBox("Debe de ingresar un usuario", vbInformation, "!!!")
            Return False
        End If

        If Me.txtContraseña.Text = "" Then
            MsgBox("Debe de ingresar una contraseña", vbInformation, "!!!")
            Return False
        End If

        usuario = "sa" 'Me.txtUsuario.Text
        contraseña = "GpiSistemas" 'Me.txtContraseña.Text


        mdlPublicVars.conexion()

        Dim cnn As New System.Data.SqlClient.SqlConnection
        Try
            cnn.ConnectionString = mdlPublicVars.cnn
            cnn.Open()
            cnn.Close()
            cnn.Dispose()

            '1ro. Revisamos la existencia del usuario en la BD de configuraciones
            If verificaUsuario(usuario) = False Then
                Return False
            End If


            'conexion con modelo entity
            Call conexion()


            'Cargar la configuración del sistema
            mdlPublicVars.CargarVariablesdeConfiguracion()

            'Dim em = (From x In ctx.tblConfiguracions Select x.parametro, x.valor)

            ''Variable para guardar cada linea de la consulta
            'Dim config
            'Dim valores As String
            'Dim parametros As String

            'For Each config In em
            '    parametros = config.parametro
            '    valores = config.valor

            '    If parametros = "Bitacora al Cotizar" And valores = "1" Then
            '        mdlPublicVars.BitaEnCotizar = True
            '    End If
            '    If parametros = "Bitacora al Reservar" And valores = "1" Then
            '        mdlPublicVars.BitaEnReservar = True
            '    End If
            '    If parametros = "Bitacora al Despachar" And valores = "1" Then
            '        mdlPublicVars.BitaEnDespachar = True
            '    End If

            'Next

            'Dim bitacora As New clsBitacoraRegistro
            'bitacora.Registro("usuario", "login", "0", "1", "inicio de sesion")
            frmMenuPrincipal.Show()

            proyecto = "Sistema Empresarial de Ventas"


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
        Return False
    End Function

    Protected Function llenaPublicVars() As Boolean

        llenaPublicVars = False

        Try
            Dim xmlConfig As String = "config.xml"
            Dim ds As New System.Data.DataSet
            ds.ReadXml(xmlConfig)
            Dim dr As System.Data.DataRow
            For Each dr In ds.Tables(0).Rows
                mdlPublicVars.servidor = dr.Item(0)
                mdlPublicVars.bd = dr.Item(1)
                mdlPublicVars.urlLicencia = dr.Item(2)
            Next

            llenaPublicVars = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try



    End Function

    Private Sub IniciarSesion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        If llenaPublicVars() = False Then
            Exit Sub
        End If

        Try
            mdlPublicVars.comboActivarFiltro(cmbEmpresa)
            mdlPublicVars.fnFormulario_quitaBarraTitulo(Me)

            'conexion con modelo entity
            mdlPublicVars.conexionEntity()

            'llenar el combo de empresas
            Dim em = (From x In ctx.tblEmpresas Select Codigo = x.idEmpresa, Nombre = x.nombre)

            cmbEmpresa.DataSource = Nothing
            cmbEmpresa.ValueMember = "Codigo"
            cmbEmpresa.DisplayMember = "Nombre"
            cmbEmpresa.DataSource = em
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

    Private Sub txtContraseña_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContraseña.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            fnIniciarSesion()
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
    End Sub
End Class
