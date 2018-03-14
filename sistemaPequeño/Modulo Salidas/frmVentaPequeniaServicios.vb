Public Class frmVentaPequeniaServicios

#Region "Variables"
    Dim _idSalida As Integer
#End Region

#Region "Propiedades"
    Public Property idSalida As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(value As Integer)
            _idSalida = value
        End Set
    End Property
#End Region

#Region "Eventos"
    'CLICK EN EL BOTON TRANSPORTE
    Private Sub btnTransporte_Click(sender As Object, e As EventArgs) Handles btnTransporte.Click
        Dim formTransporte As New frmVentaPequeniaTransporteAgregar
        formTransporte.Text = "Agregar transporte"
        formTransporte.StartPosition = FormStartPosition.CenterScreen
        formTransporte.ShowDialog()
        formTransporte.Dispose()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

#Region "Funciones"

#End Region

    
End Class
