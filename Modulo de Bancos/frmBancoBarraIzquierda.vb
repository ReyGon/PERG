Public Class frmBancoBarraIzquierda
    Public frmAnterior As Form
    Dim permiso As New clsPermisoUsuario

    Private Sub frmBancoBarraIzquierda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = True
        derecha = False
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    'PANEL1 - Cuentas -
    Private Sub fnPanel1() Handles Me.panel1
        frmBancoCuentaLista.Text = "Cuentas Bancarias"
        frmBancoCuentaLista.MdiParent = frmMenuPrincipal
        frmBancoCuentaLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmBancoCuentaLista, True) = True Then
            fnFRMhijos_cerrar(frmBancoCuentaLista)
            Me.Hide()
        End If
    End Sub

    'PANEL2 - Cheques -
    Private Sub fnPanel2() Handles Me.panel2
        frmBancoChequesLista.Text = "Lista de Cheques"
        frmBancoChequesLista.MdiParent = frmMenuPrincipal
        frmBancoChequesLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmBancoChequesLista, True) = True Then
            fnFRMhijos_cerrar(frmBancoChequesLista)
            Me.Hide()
        End If
    End Sub

    'PANEL3 - Debito -
    Private Sub fnPanel3() Handles Me.panel3
        frmBancoDebitoLista.Text = "Lista de Débitos"
        frmBancoDebitoLista.MdiParent = frmMenuPrincipal
        frmBancoDebitoLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmBancoDebitoLista, True) = True Then
            fnFRMhijos_cerrar(frmBancoDebitoLista)
            Me.Hide()
        End If
    End Sub

    'PANEL4 - Credito -
    Private Sub fnPanel4() Handles Me.panel4
        frmBancoCreditoLista.Text = "Lista de Créditos"
        frmBancoCreditoLista.MdiParent = frmMenuPrincipal
        frmBancoCreditoLista.WindowState = FormWindowState.Maximized
        If permiso.PermisoMantenimientoLista(frmBancoCreditoLista, True) = True Then
            fnFRMhijos_cerrar(frmBancoCreditoLista)
            Me.Hide()
        End If
    End Sub

    'BANCOS
    Private Sub itemBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemBancos.Click
        Dim frm = frmBanco
        frm.Text = "Bancos"
        frm.MdiParent = frmMenuPrincipal

        If permiso.PermisoFrmEspeciales(frm, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If
    End Sub

    'BENEFICIARIO
    Private Sub itemBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemBeneficiario.Click
        Dim frm = frmBancoBeneficiarios
        frm.Text = "Beneficiarios"
        frm.MdiParent = frmMenuPrincipal

        If permiso.PermisoFrmEspeciales(frm, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If
    End Sub

    'CONCEPTOS
    Private Sub itemConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemConceptos.Click
        Dim frm = frmBancoConceptos
        frm.Text = "Conceptos de Movimientos"
        frm.MdiParent = frmMenuPrincipal

        If permiso.PermisoFrmEspeciales(frm, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If
    End Sub

    'ACREDITADORES
    Private Sub itemAcreditatores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemAcreditatores.Click
        Dim frm = frmBancoAcreditadores
        frm.Text = "Acreditadores"
        frm.MdiParent = frmMenuPrincipal

        If permiso.PermisoFrmEspeciales(frm, True) = True Then
            fnFRMhijos_cerrar(frm)
            Me.Hide()
        End If
    End Sub
End Class
