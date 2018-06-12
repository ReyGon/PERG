Public Class frmProveedorBarraIzquierda

    Private permiso As New clsPermisoUsuario
    Public frmAnterior As New Form

    Private Sub frmProveedorBarraLateral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            frmProveedorLista.Text = "Proveedores Locales"
            frmProveedorLista.MdiParent = frmMenuPrincipal
            frmProveedorLista.frm_llenarLista()

            If permiso.PermisoMantenimientoLista(frmProveedorLista, True) = True Then
                fnFRMhijos_cerrar(frmProveedorLista)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub



    Private Sub fnPanel2() Handles Me.panel2

        Try
            frmProveedorListaImportacion.Text = "Proveedores de Importacion"
            frmProveedorListaImportacion.MdiParent = frmMenuPrincipal
            frmProveedorListaImportacion.frm_llenarLista()

            If permiso.PermisoMantenimientoLista(frmProveedorListaImportacion, True) = True Then
                fnFRMhijos_cerrar(frmProveedorListaImportacion)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        Try
            frmPagosLista.Dispose()
            frmPagosLista.Text = "Modulo de Pagos"
            frmPagosLista.bitProveedor = True
            frmPagosLista.bitCompra = False
            frmPagosLista.bitCliente = False
            frmPagosLista.bitVenta = False
            frmPagosLista.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoLista(frmPagosLista, False) = True Then
                fnFRMhijos_cerrar(frmPagosLista)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try



    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        Try
            frmBitacoraLista.Text = "Bitacoras"
            frmBitacoraLista.proveedor = True
            frmBitacoraLista.MdiParent = frmMenuPrincipal

            If permiso.PermisoMantenimientoLista(frmBitacoraLista, False) = True Then
                fnFRMhijos_cerrar(frmBitacoraLista)
                Me.Hide()
            End If

        Catch ex As Exception

        End Try



    End Sub


    Private Sub fnPanel6() Handles Me.panel6
        Try
            Dim frm = frmBitacoraCategoria
            frm.Text = "Categoria de Bitacoras"
            frm.MdiParent = frmMenuPrincipal

            'Dim bit As New frmBitacoraCategoria
            'bit.bitCliente = True

            If permiso.PermisoMantenimientoTelerik(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub itemFletes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemFletes.Click
        Try
            Dim frm = frmFletes
            frm.Text = "Fletes"
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then

                fnFRMhijos_cerrar(frm)
                Me.Hide()

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemBancos.Click
        Try
            Dim frm = frmBanco
            frm.Text = "Bancos"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemCategoriaBitacora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemCategoriaBitacora.Click
        Try
            Dim frm = frmCategoriaBitacoraProveedor
            frm.Text = "Categoria Bitacora Proveedor"
            frm.MdiParent = frmMenuPrincipal

            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemTipoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemTipoPago.Click
        Try
            frmTiposPago.bitProveedor = True
            frmTiposPago.bitCliente = False
            frmTiposPago.Text = "Tipo de Pago"
            frmTiposPago.MdiParent = frmMenuPrincipal

            If permiso.PermisoFrmEspeciales(frmTiposPago, True) = True Then
                fnFRMhijos_cerrar(frmTiposPago)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub itemTransporte_Click(sender As Object, e As EventArgs) Handles itemTransporte.Click
        Try
            ''Dim frm = frmEmpresaTransporte
            ''frm.Text = "Transporte Envio"
            ''frm.MdiParent = frmMenuPrincipal

            ''If permiso.PermisoFrmEspeciales(frm, True) = True Then
            ''    fnFRMhijos_cerrar(frm)
            ''    Me.Hide()
            ''End If
        Catch ex As Exception
        End Try
    End Sub

    'CLASIFICACION
    Private Sub itemClasificacion_Click(sender As Object, e As EventArgs) Handles itemClasificacion.Click
        Try
            Dim frm = frmProveedorClasificacionNegocio
            frm.Text = "Clasificacion"
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
