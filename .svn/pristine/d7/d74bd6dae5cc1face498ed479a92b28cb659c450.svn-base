Public Class frmPagoContadoCredito

    Private Sub frmPagoContadoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAgregar.Click, pbAgregar.Click, pnlAgregar.Click
        'si el pago es contado, super search ID=1 y si es credito super search ID=0

        If rbnContado.Checked = True Then
            mdlPublicVars.superSearchId = 1
        Else
            mdlPublicVars.superSearchId = 0
        End If
        Me.Close()

    End Sub
End Class
