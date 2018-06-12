Public Class frmClientePequenioBarraIzquierda

    Public frmAnterior As New Form
    Private permiso As New clsPermisoUsuario

    Private Sub frmClientePequenioBarraIzquierda_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub


    Private Sub fnPanel1() Handles Me.panel1
        Dim frm = frmClientePequenioLista
        frm.Text = "Modulo de Clientes"
        frm.MdiParent = frmMenuPrincipal
        If permiso.PermisoMantenimientoLista(frmClientePequenioLista, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If

    End Sub


    Private Sub fnPanel2() Handles Me.panel2
        frmPagosLista.Dispose()
        frmPagosLista.Text = "Modulo de Pagos"

        'frmPagosLista.bitVentaPequenia = True 'para la venta pequeña motrisa

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

    Private Sub itemClasificacionCliente_Click(sender As Object, e As EventArgs) Handles itemClasificacionCliente.Click
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

    Private Sub itemClasificacionNegocio_Click(sender As Object, e As EventArgs) Handles itemClasificacionNegocio.Click
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

    Private Sub itemTipoNegocio_Click(sender As Object, e As EventArgs) Handles itemTipoNegocio.Click
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

    Private Sub itemOpcionesPago_Click(sender As Object, e As EventArgs) Handles itemOpcionesPago.Click
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

    Private Sub itemTiposPago_Click(sender As Object, e As EventArgs) Handles itemTiposPago.Click
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

    Private Sub itemPais_Click(sender As Object, e As EventArgs) Handles itemPais.Click
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

    Private Sub itemRegion_Click(sender As Object, e As EventArgs) Handles itemRegion.Click
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

    Private Sub itemDepartamento_Click(sender As Object, e As EventArgs) Handles itemDepartamento.Click
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

    Private Sub itemMunicipio_Click(sender As Object, e As EventArgs) Handles itemMunicipio.Click
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

    Private Sub itemSector_Click(sender As Object, e As EventArgs) Handles itemSector.Click
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
