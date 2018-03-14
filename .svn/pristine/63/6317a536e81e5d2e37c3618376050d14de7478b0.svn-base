Imports System.Linq

Public Class frmReporteInventario
    Dim r As New clsReporte

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    'Reporte
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        fnCreaReporte()
    End Sub

    'Funcion utilizada pra ver el reporte
    Private Sub fnCreaReporte()
        Try
            r.parametro = dtpHasta.Text
            r.nombreParametro = "filtro"
            r.tabla = EntitiToDataTable(ctx.sp_ReporteInventario(dtpHasta.Text & " 23:59:59", dtpHasta.Text & " 23:59:59", mdlPublicVars.idEmpresa))
            r.reporte = "rptReporteInventario.rpt"
            r.verReporte()
        Catch ex As Exception
        End Try

        
    End Sub

End Class
