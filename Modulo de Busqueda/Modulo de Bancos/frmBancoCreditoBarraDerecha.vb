
Public Class frmBancoCreditoBarraDerecha
    Private Sub frmBancoCuentaBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    'ARCHIVOS ADJUNTOS
    Private Sub fnPanel1() Handles Me.panel1
        frmBancoCreditoLista.fnCambioFila()
        frmBancoCreditoAdjuntarArchivo.Text = "Adjuntar Archivo"
        frmBancoCreditoAdjuntarArchivo.StartPosition = FormStartPosition.CenterScreen
        frmBancoCreditoAdjuntarArchivo.idMovimiento = mdlPublicVars.superSearchId
        frmBancoCreditoAdjuntarArchivo.ShowDialog()
        frmBancoCreditoAdjuntarArchivo.Dispose()
    End Sub
End Class
