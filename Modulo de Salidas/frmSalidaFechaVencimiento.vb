Imports Telerik.WinControls

Public Class frmSalidaFechaVencimiento
    Public fecha As Date
    Public dias As Integer

    Private Sub frmSalidaFechaVencimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        calendario.SelectedDate = Now
        Me.Text = "Fecha Vencimiento"
    End Sub


    Private Sub pbAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAgregar.Click, lblAgregar.Click
        Dim fechaVencimiento As Date = calendario.SelectedDate

        Dim diasDif As Integer = DateDiff(DateInterval.Day, fecha, fechaVencimiento)

        If diasDif < 0 Then
            alerta.contenido = "La fecha debe ser mayor o igual a " + fecha.ToString
            alerta.fnErrorContenido()
            Exit Sub
        End If

        If diasDif > dias Then
            If RadMessageBox.Show("Excede el limite de dias !!! dias credito=" + dias.ToString + " dias de vencimiento " + diasDif.ToString + " DESEA CONTINUAR ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                mdlPublicVars.superSearchFecha = fechaVencimiento
                Me.Close()
            End If
        Else
            mdlPublicVars.superSearchFecha = fechaVencimiento
            Me.Close()
        End If
    End Sub
End Class
