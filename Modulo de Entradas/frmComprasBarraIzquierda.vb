Public Class frmComprasBarraIzquierda
    Public frmAnterior As New Form
    Private permiso As New clsPermisoUsuario
    Private Sub frmComprasBarraIzquierda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        frmComprasLista.Text = "Modulo de Compras"
        frmComprasLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmComprasLista, True) = True Then
            fnFRMhijos_cerrar(frmComprasLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        frmPagosLista.Dispose()
        frmPagosLista.Text = "Modulo de Pagos"
        frmPagosLista.bitCompra = True
        frmPagosLista.bitVenta = False
        frmPagosLista.bitCliente = False
        frmPagosLista.bitProveedor = False
        frmPagosLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmPagosLista, True) = True Then
            fnFRMhijos_cerrar(frmPagosLista)
            Me.Hide()
        End If

    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        frmProveedorDevolucionLista.Text = "Ajustes y Devoluciones"
        frmProveedorDevolucionLista.MdiParent = frmMenuPrincipal
        frmProveedorDevolucionLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmProveedorDevolucionLista, True) = True Then
            fnFRMhijos_cerrar(frmProveedorDevolucionLista)
            Me.Hide()
        End If
    End Sub

    Private Sub fnPanel4() Handles Me.panel4

        frmPreformasLista.Text = "Preformas Importacion"
        frmPreformasLista.MdiParent = frmMenuPrincipal
        ''frmPreformasLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmPreformasLista, True) = True Then
            fnFRMhijos_cerrar(frmPreformasLista)
            Me.Close()
        End If

        ''frmGuiasLista.Dispose()
        ''frmGuiasLista.Text = "Guias Compras"
        ''frmGuiasLista.MdiParent = frmMenuPrincipal
        ''frmGuiasLista.bitCompra = True
        ''frmGuiasLista.bitFactura = False
        ''frmGuiasLista.bitDevolucionCliente = False
        ''frmGuiasLista.bitDevolucionProveedor = False
        ''If permiso.PermisoMantenimientoLista(frmGuiasLista, True) = True Then
        ''    fnFRMhijos_cerrar(frmGuiasLista)
        ''    Me.Hide()
        ''End If
        ''frmGuiasLista.Update()
    End Sub

    Private Sub fnPanel5() Handles Me.panel5

        frmInvoicesLista.Text = "Invoices"
        frmInvoicesLista.MdiParent = frmMenuPrincipal
        ''frmInvoicesLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmInvoicesLista, True) = True Then
            fnFRMhijos_cerrar(frmInvoicesLista)
            Me.Close()
        End If

        ''frmGuiasLista.Dispose()
        ''frmGuiasLista.Text = "Guias Devolucion Proveedor"
        ''frmGuiasLista.MdiParent = frmMenuPrincipal
        ''frmGuiasLista.bitDevolucionProveedor = True
        ''frmGuiasLista.bitCompra = False
        ''frmGuiasLista.bitFactura = False
        ''frmGuiasLista.bitDevolucionCliente = False
        ''If permiso.PermisoMantenimientoLista(frmGuiasLista, True) = True Then
        ''    fnFRMhijos_cerrar(frmGuiasLista)
        ''    Me.Hide()
        ''End If
        ''frmGuiasLista.Update()

    End Sub

    Private Sub fnPanel6() Handles Me.panel6

        frmNacionalizacionesLista.Text = "Nacionalizaciones"
        frmNacionalizacionesLista.MdiParent = frmMenuPrincipal
        ''frmNacionalizacionesLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmNacionalizacionesLista, True) = True Then
            fnFRMhijos_cerrar(frmNacionalizacionesLista)
            Me.Close()
        End If

        ''frmImportacionesLista.Text = "Listado de Importación"
        ''frmImportacionesLista.MdiParent = frmMenuPrincipal
        ''frmImportacionesLista.Show()
        ''Me.Hide()

        'frmproformaimportacion.Text = "Proforma de Importación"
        'frmproformaimportacion.MdiParent = frmMenuPrincipal
        'frmproformaimportacion.Show()
        'Me.Hide()
    End Sub
End Class
