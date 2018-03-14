Public Class frmPagosListaBarraDerecha
    Private alerta As New bl_Alertas
    Private permiso As New clsPermisoUsuario

    Private Sub frmPagosListaBarraDerecha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    'PAGOS
    Private Sub fnPanel1() Handles Me.panel1
        If frmPagosLista.grdDatos.RowCount > 0 Then
            Dim idCaja As Integer = mdlPublicVars.superSearchId
            frmPagoRechazar.Text = "Rechazar Pago"
            frmPagoRechazar.idCaja = idCaja
            frmPagoRechazar.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmPagoRechazar)
        End If

    End Sub


    Private Sub fnPanel2() Handles Me.panel2
        Try
            frmClienteBoleta.Text = "Agregar Boleta"
            frmClienteBoleta.ShowDialog()
            frmClienteBoleta.Dispose()
        Catch ex As Exception
            alerta.fnError()
        End Try

    End Sub
End Class