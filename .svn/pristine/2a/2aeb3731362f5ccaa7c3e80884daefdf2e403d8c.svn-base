Public Class frmClientesBarraIzquierda

    Public frmAnterior As New Form
    Private permiso As New clsPermisoUsuario

    Private Sub frmClientesBarraLateral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1

        If mdlPublicVars.PuntoVentaPequeno_Activado = True Then

            Dim frm = frmClientePequenioLista
            frm.Text = "Modulo de Clientes"
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoMantenimientoLista(frmClientePequenioLista, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Else

            Dim frm = frmClienteLista
            frm.Text = "Modulo de Clientes"
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoMantenimientoLista(frmClienteLista, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        End If





        
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        frmPagosLista.Dispose()
        frmPagosLista.Text = "Modulo de Pagos"
        frmPagosLista.bitCliente = True
        frmPagosLista.bitCompra = False
        frmPagosLista.bitProveedor = False
        frmPagosLista.bitVenta = False
        frmPagosLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmPagosLista, True) = True Then
            fnFRMhijos_cerrar(frmPagosLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        frmBitacoraLista.Dispose()
        frmBitacoraLista.Text = "Bitacoras"
        frmBitacoraLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmBitacoraLista, True) = True Then
            fnFRMhijos_cerrar(frmBitacoraLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        Dim frm As New Form
        frm = frmClienteDevolucionLista
        frm.Name = "frmClienteDevolucionLista"
        frm.Text = "Lista de Devoluciones"
        frm.MdiParent = frmMenuPrincipal
        frmClienteDevolucionLista.bitCliente = True
        If permiso.PermisoMantenimientoLista(frm, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel5() Handles Me.panel5
        frmGuiasLista.Dispose()
        frmGuiasLista.Text = "Guias Devolucion Cliente"
        frmGuiasLista.MdiParent = frmMenuPrincipal
        frmGuiasLista.WindowState = FormWindowState.Maximized
        frmGuiasLista.bitDevolucionCliente = True
        frmGuiasLista.bitCompra = False
        frmGuiasLista.bitDevolucionProveedor = False
        frmGuiasLista.bitFactura = False
        If permiso.PermisoMantenimientoLista(frmGuiasLista, True) = True Then
            fnFRMhijos_cerrar(frmGuiasLista)
            Me.Hide()
        End If

    End Sub


    Private Sub ItemClasificacionCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemClasificacionCliente.Click
        Try
            Dim frm = frmClasificacionCompra
            frm.Text = "Clasificacion de Compras"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemClasificacionNegocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemClasificacionNegocio.Click
        Try
            Dim frm = frmClasificacionNegocio
            frm.Text = "Clasificacion de Negocios"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemTipoNegocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemTipoNegocio.Click
        Try
            Dim frm = frmTipoNegocio
            frm.Text = "Tipo de Negocio"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ItemTipoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTipoPago.Click
        Try
            Dim frm = frmClienteTipoPago
            frm.Text = "Tipo de Pago"
            frm.MdiParent = frmMenuPrincipal


            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMunicipio.Click
        Try
            Dim frm = frmMunicipio
            frm.Text = "Municipios"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub itemDepartamentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemDepartamentos.Click
        Try
            Dim frm = frmDepartamento
            frm.Text = "Departamentos"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub itemRegion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemRegion.Click
        Try
            Dim frm As Form = frmRegion
            frm.Text = "Region"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub itemPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemPais.Click
        Try
            Dim frm As Form = frmPais
            frm.Text = "Pais"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub itemTiposPago_Click(sender As System.Object, e As System.EventArgs) Handles itemTiposPago.Click
        Try
            frmTiposPago.bitProveedor = False
            frmTiposPago.bitCliente = True
            frmTiposPago.Text = "Tipo de Pago"
            frmTiposPago.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frmTiposPago, True) = True Then
                fnFRMhijos_cerrar(frmTiposPago)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemSectores_Click(sender As Object, e As EventArgs) Handles itemSectores.Click
        Try
            Dim frm As Form = frmSector
            frm.Text = "Sectores"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
