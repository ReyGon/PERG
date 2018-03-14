Imports System.Windows.Forms
Imports System.Drawing

Public Class frmControles
    Dim ctlMDI As MdiClient
    Dim permiso As New clsPermisoUsuario
    Private mdiChildCount As Integer = 0
    Dim tbl As New clsDevuelveTabla



    Private Sub FrmInicio_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub FrmInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FnLoad()
    End Sub
    Public Function FnLoad()



        Me.WindowState = FormWindowState.Maximized
        Me.usuario.Text = mdlPublicVars.usuario
        Me.Servidor.Text = mdlPublicVars.servidor & "\" & mdlPublicVars.bd


        Dim ctl As Control

        'Estamos buscando en control que representa el area cliente MDI
        For Each ctl In Me.Controls

            Try

                ctlMDI = CType(ctl, MdiClient)

                ' Asignamos el color de fondo
                ctlMDI.BackColor = Color.White

                'Aquí asignamos el manejador para pintar el fondo con degradados o lo que
                'queramos. Si solo queremos cambiar el color de fondo no hace falta, ni las funciones siguientes tampoco AddHandler ctlMDI.Paint, AddressOf PintarFondo

            Catch ex As InvalidCastException

            End Try

        Next

        'Llamamos a la funcion que carga los parametros de configuracion
        Call mdlPublicVars.configuracion()



        Return False
    End Function



    Private Sub btSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalir.Click
        If (MsgBox("Esta seguro de Salir de " + Me.Text.ToString, MsgBoxStyle.YesNo, "Informacion")) = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub



     
End Class
