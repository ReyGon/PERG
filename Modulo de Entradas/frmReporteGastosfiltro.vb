Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows
Imports System.IO
Public Class frmReporteGastosfiltro

    Private Sub frmReporteGastosfiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fnsalir() Handles Me.panel0
        Me.Hide()
    End Sub

    Private Sub fnImprimirReporte()

        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechainicio As DateTime = Me.dtpDesde.Value
                Dim fechafin As DateTime = Me.dtpHasta.Value
           Dim r As New clsReporte


                r.tabla = EntitiToDataTable(conexion.sp_reportegastoscompra(fechainicio, fechafin))

              
                r.reporte = "rptGastosImportacion.rpt"
          
                r.verReporte()

                conn.Close()
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        fnImprimirReporte()
    End Sub
End Class
