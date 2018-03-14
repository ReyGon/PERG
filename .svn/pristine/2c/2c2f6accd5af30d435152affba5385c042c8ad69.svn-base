Public Class frmImpresoras

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        mdlPublicVars.fnImpresoraDefault(cmbImpresora.Text)
        Me.Close()
    End Sub

    Private Sub frmImpresoras_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        mdlPublicVars.comboActivarFiltroLista(cmbImpresora)
        mdlPublicVars.fnImpresorasSistema(cmbImpresora)
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
