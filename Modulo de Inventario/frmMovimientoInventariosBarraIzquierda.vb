Public Class frmMovimientoInventariosBarraIzquierda
    Public frmAnterior As New Form
    Public permiso As New clsPermisoUsuario

    Private Sub frmMovimientoInventariosBarraIzquierda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        frmMovimientoInventariosLista.Text = "Ajustes y Traslados"
        frmMovimientoInventariosLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmMovimientoInventariosLista, True) = True Then
            fnFRMhijos_cerrar(frmMovimientoInventariosLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        frmMovimientoInventariosConceptosLista.Text = "Detalles de Ajustes"
        frmMovimientoInventariosConceptosLista.MdiParent = frmMenuPrincipal

        If permiso.PermisoMantenimientoLista(frmMovimientoInventariosConceptosLista, True) = True Then
            fnFRMhijos_cerrar(frmMovimientoInventariosConceptosLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        frmClienteDevolucionLista.Text = "Devoluciones de Clientes"
        frmClienteDevolucionLista.MdiParent = frmMenuPrincipal
        frmClienteDevolucionLista.WindowState = FormWindowState.Maximized
        frmClienteDevolucionLista.bitAjuste = True
        If permiso.PermisoMantenimientoLista(frmClienteDevolucionLista, True) = True Then
            fnFRMhijos_cerrar(frmClienteDevolucionLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub fnPanel4() Handles Me.panel4
        frmClienteDevolucionConceptosLista.Text = "Detalles de Devoluciones"
        frmClienteDevolucionConceptosLista.MdiParent = frmMenuPrincipal
        frmClienteDevolucionConceptosLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmClienteDevolucionConceptosLista, True) = True Then
            fnFRMhijos_cerrar(frmClienteDevolucionConceptosLista)
            Me.Hide()
        End If
        
    End Sub

    Private Sub itemConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemConceptos.Click
        Dim frm = frmConceptosAjustes
        frm.Text = "Conceptos de Ajustes y Traslados "
        frm.MdiParent = frmMenuPrincipal
        If permiso.PermisoFrmEspeciales(frm, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If
    End Sub
End Class