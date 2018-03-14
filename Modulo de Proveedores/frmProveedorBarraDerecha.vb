Public Class frmProveedorBarraDerecha
    Dim permiso As New clsPermisoUsuario

    Private Sub frmProveedorBarraLateral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl2.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            'Bitacora
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmBitacora.idCliente = CType(mdlPublicVars.superSearchId, Integer)
                frmBitacora.idVendedor = mdlPublicVars.idVendedor
                frmBitacora.fecha = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                frmBitacora.proveedor = True
                frmBitacora.Text = "Bitacora"
                frmBitacora.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmBitacora)
                frmBitacora.Dispose()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub fnPanel2() Handles Me.panel2
        Try
            'Estado de Cuenta
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmProveedorEstadoCuenta.Text = "Estado de Cuenta"
                frmProveedorEstadoCuenta.proveedor = CType(mdlPublicVars.superSearchId, Integer)
                frmProveedorEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmProveedorEstadoCuenta.BringToFront()
                frmProveedorEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmProveedorEstadoCuenta)
                frmProveedorEstadoCuenta.Dispose()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub fnPanel3() Handles Me.panel3
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmComprasPagos.Text = "Pagos Proveedor"
                frmComprasPagos.StartPosition = FormStartPosition.CenterScreen
                frmComprasPagos.BringToFront()
                frmComprasPagos.Focus()
                permiso.PermisoDialogEspeciales(frmComprasPagos)
                frmComprasPagos.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        frmConsultaCtaPagar.Text = "Ctas. por Pagar"
        ''frmConsultaCtaCobrar.MdiParent = Me
        frmConsultaCtaPagar.WindowState = FormWindowState.Normal
        frmConsultaCtaPagar.StartPosition = FormStartPosition.CenterScreen
        frmConsultaCtaPagar.ShowDialog()
        ''permiso.PermisoFrmEspeciales(frmConsultaCtaCobrar, True)
        ''Me.Hide()
    End Sub

    Private Sub frmProveedorBarraDerecha_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmProveedorLista.frm_llenarLista()
    End Sub
End Class
