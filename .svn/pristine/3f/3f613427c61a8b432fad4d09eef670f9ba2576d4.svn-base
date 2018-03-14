Public Class FrmBaseReporteFechaYhora
    Public Event Evento_Reporte()
    Public Event Evento_Ayuda()

    Private Sub FrmBaseReporteFechaYhora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbHora.Text = Format(Now, "hh:mm:ss tt")
        lbTituloFrm.Text = Me.Text
        txtFecha.Text = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub btReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReporte.Click, lblReporte.Click
        RaiseEvent Evento_Reporte()
    End Sub

    Private Sub btSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Esta seguro de cerrar la ventana !!!", MsgBoxStyle.YesNo, "Cerrar Ventana !!") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    'boton para ayuda
    Private Sub btAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Revise el manual del sistema !!!", MsgBoxStyle.Information, "Ayuda ")
    End Sub

    Private Sub tmrHora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHora.Tick
        Me.lbHora.Text = Format(Now, "hh:mm:ss tt")
    End Sub

     
End Class
