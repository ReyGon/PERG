Imports Telerik.WinControls

Public Class frmProductosBarraIzquierda
    Public frmAnterior As Form
    Dim permiso As New clsPermisoUsuario

    Private Sub frmProductosBarraIzquierda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = True
        derecha = False
        itemCombo1.Text = mdlPublicVars.ProductoCombo1
        itemCombo2.Text = mdlPublicVars.ProductoCombo2
        ItemGrid1.Text = mdlPublicVars.ProductoGrid1
        itemGrid2.Text = mdlPublicVars.ProductoGrid2

        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            frmProductoLista.Text = "Modulo de Productos"
            frmProductoLista.MdiParent = frmMenuPrincipal
            frmProductoLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmProductoLista, True) = True Then
                fnFRMhijos_cerrar(frmProductoLista)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        Try
            frmPriceLista.Text = "Modulo de Price"
            frmPriceLista.MdiParent = frmMenuPrincipal
            frmPriceLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmPriceLista, True) = True Then
                fnFRMhijos_cerrar(frmPriceLista)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        Try
            frmProductoPreciosCompeLista.Text = "Modulo Precios Competencia"
            frmProductoPreciosCompeLista.MdiParent = frmMenuPrincipal
            frmProductoPreciosCompeLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmProductoPreciosCompeLista, True) = True Then
                fnFRMhijos_cerrar(frmProductoPreciosCompeLista)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        Try
            frmProductoPedirLista.Text = "Modulo Pendientes Pedir"
            frmProductoPedirLista.MdiParent = frmMenuPrincipal
            frmProductoPedirLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmProductoPedirLista, True) = True Then
                fnFRMhijos_cerrar(frmProductoPedirLista)
                Me.Hide()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnPanel5() Handles Me.panel5
        Try
            frmProductoPedirLista.Text = "Modulo Pendientes Pedir"
            frmProductoPedirLista.MdiParent = frmMenuPrincipal
            frmProductoPedirLista.WindowState = FormWindowState.Maximized
            If permiso.PermisoMantenimientoLista(frmProductoPedirLista, True) = True Then
                fnFRMhijos_cerrar(frmProductoPedirLista)
                Me.Hide()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub ItemMarcaVehiculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm = frmMarcaVehiculos
            frm.Text = "Marca de Vehiculos"
            frm.MdiParent = frmMenuPrincipal
            frm.WindowState = FormWindowState.Maximized
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ItemGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemGrid1.Click
        Try
            Dim frm = frmTipoVehiculo
            frm.Text = mdlPublicVars.ProductoGrid1
            frm.MdiParent = frmMenuPrincipal
            frm.WindowState = FormWindowState.Maximized
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemGrid2.Click
        Try
            Dim frm = frmModeloVehiculo
            frm.Text = mdlPublicVars.ProductoGrid2
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemCombo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemCombo1.Click
        Try
            Dim frm = frmTipoRepuestos
            frm.Text = mdlPublicVars.ProductoCombo1
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub itemCombo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemCombo2.Click
        Try
            Dim frm = frmMarcaRepuestos
            frm.Text = mdlPublicVars.ProductoCombo2
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ItemAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemAlmacen.Click
        Try
            Dim frm = frmAlmacen
            frm.Text = "Almacenes"
            frm.MdiParent = frmMenuPrincipal
            frm.WindowState = FormWindowState.Maximized
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ItemTipoInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTipoInventario.Click
        Try
            Dim frm = frmTipoInventario
            frm.Text = "Tipo de Inventario"
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ItemImportancia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemImportancia.Click
        Try
            Dim frm = frmImportancia
            frm.Text = "Importancia"
            frm.MdiParent = frmMenuPrincipal
            If permiso.PermisoFrmEspeciales(frm, True) = True Then
                fnFRMhijos_cerrar(frm)
                Me.Hide()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
