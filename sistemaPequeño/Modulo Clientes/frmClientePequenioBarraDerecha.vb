Public Class frmClientePequenioBarraDerecha

    Dim permiso As New clsPermisoUsuario



    Private Sub frmClientePequenioBarraDerecha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl2.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                'Dim frm As Form = frmClienteDevolucion
                frmClienteDevolucion.Text = "Devolución de Cliente"
                frmClienteDevolucion.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmEspeciales(frmClienteDevolucion, True)
                Me.Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmClienteEstadoCuenta.Text = "Estado de Cuenta"
                frmClienteEstadoCuenta.cliente = CType(mdlPublicVars.superSearchId, Integer)
                frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmClienteEstadoCuenta.BringToFront()
                frmClienteEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
                frmClienteEstadoCuenta.Dispose()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        frmConsultaCtaCobrar.Text = "Ctas. por Cobrar"
        ''frmConsultaCtaCobrar.MdiParent = Me
        frmConsultaCtaCobrar.WindowState = FormWindowState.Normal
        frmConsultaCtaCobrar.StartPosition = FormStartPosition.CenterScreen
        frmConsultaCtaCobrar.ShowDialog()
        ''permiso.PermisoFrmEspeciales(frmConsultaCtaCobrar, True)
        ''Me.Hide()
    End Sub

    Private Sub pnl2_Paint(sender As Object, e As PaintEventArgs) Handles pnl2.Paint

    End Sub
End Class
