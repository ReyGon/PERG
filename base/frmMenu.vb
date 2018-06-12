Imports Telerik.WinControls

Public Class frmMenu

    Dim permiso As New clsPermisoUsuario

    Private Sub frmMenu_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            fnPanel0()
        End If
    End Sub

    Private Sub frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If PuntoVentaPequeno_Activado = True Then

        Else
            ''frmListaNotificaciones.fnVerificarNotificaciones()
        End If
        pnl0.Focus()
        Me.ControlBox = False
    End Sub


    Private Sub fnPanel0() Handles Me.panel0
        Try
            If PuntoVentaPequeno_Activado = False Then
                Dim frm As Form = frmPedidosLista
                frm.Text = "Lista de Ventas"
                frm.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmEspeciales(frm, True)
            Else
                Dim frm As Form = frmVentaPequeniaLista
                frm.Text = "Lista de Ventas"
                frm.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmEspeciales(frm, True)
            End If
            

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            Dim frm As Form = frmComprasLista
            frm.Text = "Modulo de Compras"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        Try
            Dim frm As Form = frmMovimientoInventariosLista
            frm.Text = "Ajustes y Traslados"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)

        Catch ex As Exception
        End Try
    End Sub

    'BANCOS
    Private Sub fnPanel3() Handles Me.panel3
        Try
            Dim frm As Form = frmBancoCuentaLista
            frm.Text = "Cuentas Bancarias"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        Try
            If PuntoVentaPequeno_Activado = False Then
                Dim frm As Form = frmClienteLista
                frm.Text = "Modulo de Clientes"
                ''frmClienteLista.frm_llenarLista()
                frm.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmEspeciales(frm, True)
            Else
                Dim frm As Form = frmClientePequenioLista
                frm.Text = "Modulo de Clientes"
                ''frmClientePequenioLista.frm_llenarLista()
                frm.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmEspeciales(frm, True)
            End If
            

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel5() Handles Me.panel5
        Try
            Dim frm As Form = frmProveedorLista
            frm.Text = "Lista de Proveedores"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel6() Handles Me.panel6
        Try
            Dim frm As Form = frmProductoLista
            frm.Text = "Lista de Productos"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel7() Handles Me.panel7
        Try
            Dim frm As Form = frmListaNotificaciones
            frm.Text = "Lista de Notificaciones"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)
        Catch ex As Exception

        End Try
    End Sub

End Class
