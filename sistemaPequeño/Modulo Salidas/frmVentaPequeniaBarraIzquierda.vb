Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.Objects.DataClasses


Public Class frmVentaPequeniaBarraIzquierda
    Public frmAnterior As New Form
    Private permiso As New clsPermisoUsuario

    Private Sub frmVentaPequeniaBarraIzquierda_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl3.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            frmVentaPequeniaLista.Text = "Modulo de Pedidos"
            frmVentaPequeniaLista.MdiParent = frmMenuPrincipal
            frmVentaPequeniaLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmVentaPequeniaLista, True) = True Then
                fnFRMhijos_cerrar(frmVentaPequeniaLista)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''Private Sub fnAsignacionesTransportes_Click() Handles Me.panel2
    ''    ''Try
    ''    ''    Try
    ''    ''        frmDespachoFacturaListaAsignar.Text = "Asignar productos"
    ''    ''        frmDespachoFacturaListaAsignar.MdiParent = frmMenuPrincipal
    ''    ''        frmDespachoFacturaListaAsignar.WindowState = FormWindowState.Maximized
    ''    ''        If permiso.PermisoMantenimientoLista(frmDespachoFacturaListaAsignar, True) = True Then
    ''    ''            fnFRMhijos_cerrar(frmDespachoFacturaListaAsignar)
    ''    ''            Me.Hide()
    ''    ''        End If
    ''    ''    Catch ex As Exception
    ''    ''    End Try
    ''    ''Catch ex As Exception
    ''    ''End Try
    ''End Sub

    Private Sub fnDespachosFacturas_Click() Handles Me.panel2

        If bitEncomienda Then
            frmGuiasLista.Dispose()
            frmGuiasLista.Text = "Guias de Facturas"
            frmGuiasLista.MdiParent = frmMenuPrincipal
            frmGuiasLista.bitFactura = True
            frmGuiasLista.bitCompra = False
            frmGuiasLista.bitDevolucionCliente = False
            frmGuiasLista.bitDevolucionProveedor = False
            If permiso.PermisoMantenimientoLista(frmGuiasLista, False) = True Then
                fnFRMhijos_cerrar(frmGuiasLista)
                Me.Hide()
            End If
        ElseIf bitTransportePesado Then
            ''frmDespachoFacturaListaTransportes.Text = "Despachos vs Facturas"
            ''frmDespachoFacturaListaTransportes.MdiParent = frmMenuPrincipal
            ''frmDespachoFacturaListaTransportes.WindowState = FormWindowState.Maximized
            ''If permiso.PermisoMantenimientoLista(frmDespachoFacturaListaTransportes, True) = True Then
            ''    fnFRMhijos_cerrar(frmDespachoFacturaListaTransportes)
            ''    Me.Hide()
            ''End If
        End If

    End Sub

    Private Sub fnFacturas_Click() Handles Me.panel3
        Try
            frmFacturasLista.Text = "Modulo de Facturas"
            frmFacturasLista.MdiParent = frmMenuPrincipal
            frmFacturasLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmFacturasLista, True) = True Then
                fnFRMhijos_cerrar(frmFacturasLista)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPagos_Click() Handles Me.panel4
        frmPagosLista.Dispose()
        frmPagosLista.Text = "Modulo de Pagos"
        frmPagosLista.bitCliente = False
        frmPagosLista.bitCompra = False
        frmPagosLista.bitProveedor = False
        frmPagosLista.bitVenta = True
        frmPagosLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmPagosLista, True) = True Then
            fnFRMhijos_cerrar(frmPagosLista)
            Me.Hide()
        End If
    End Sub

    Private Sub fnDevolucionesClientes_Click() Handles Me.panel5
        frmClienteDevolucionLista.Name = "frmClienteDevolucionLista"
        frmClienteDevolucionLista.Text = "Lista de Devoluciones"
        frmClienteDevolucionLista.MdiParent = frmMenuPrincipal
        frmClienteDevolucionLista.bitVenta = True
        If permiso.PermisoMantenimientoLista(frmClienteDevolucionLista, True) = True Then
            fnFRMhijos_cerrar(frmClienteDevolucionLista)
            Me.Hide()
        End If
    End Sub


    'LISTA DE CIERRES DE CAJA
    Private Sub fnCierresCajas_Click() Handles Me.panel6
        frmCierreCajaLista.Text = "Cierres de Caja"
        frmCierreCajaLista.MdiParent = frmMenuPrincipal
        If permiso.PermisoMantenimientoLista(frmCierreCajaLista, True) = True Then
            fnFRMhijos_cerrar(frmCierreCajaLista)
            Me.Hide()
        End If
    End Sub

    Private Sub fnListadoDevolucionesTransportes_Click() Handles Me.panel7
        ''frmListaDevolucionesTransporte.Text = "Listado Devols. Transporte"
        ''frmListaDevolucionesTransporte.MdiParent = frmMenuPrincipal
        ''frmListaDevolucionesTransporte.WindowState = FormWindowState.Maximized
        ''If permiso.PermisoMantenimientoLista(frmListaDevolucionesTransporte, True) = True Then
        ''    fnFRMhijos_cerrar(frmListaDevolucionesTransporte)
        ''    Me.Hide()
        ''End If
        frmReportesAdministrativos.Text = "Estadisticas"
        frmReportesAdministrativos.StartPosition = FormStartPosition.CenterScreen
        frmReportesAdministrativos.WindowState = FormWindowState.Normal
        frmReportesAdministrativos.ShowDialog()
        frmReportesAdministrativos.Dispose()
    End Sub

    Private Sub fnReportesVentas_Click() Handles Me.panel8
        frmReportesVentasPequenio.Text = "Reportes de Ventas"
        frmReportesVentasPequenio.WindowState = FormWindowState.Normal
        frmReportesVentasPequenio.StartPosition = FormStartPosition.CenterScreen
        frmReportesVentasPequenio.ShowDialog()
        frmReportesVentasPequenio.Dispose()
    End Sub

    Private Sub pbx7_Click(sender As Object, e As EventArgs) Handles pbx7.Click

    End Sub
End Class
