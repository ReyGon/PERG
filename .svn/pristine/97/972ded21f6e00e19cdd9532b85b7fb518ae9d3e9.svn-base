Imports System.Linq

Public Class frmPagosFiltro

#Region "Funciones"
    'FILTRAR
    Public Sub fnFiltrar()
        Dim desde As DateTime = dtpDesde.Text
        Dim hasta As DateTime = dtpHasta.Text & " 23:59:59"

        frmPagosLista.filtroActivo = True
        frmPagosLista.llenagrid(desde, hasta)

    End Sub
#End Region

#Region "Eventos"
    'CLIC EN FILTRAR
    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        fnFiltrar()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Hide()
    End Sub

    'SALIR 2
    Private Sub frmProductoPedirFiltro_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
#End Region
End Class
