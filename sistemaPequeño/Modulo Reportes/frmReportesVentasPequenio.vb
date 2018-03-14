Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows
Imports System.IO

Public Class frmReportesVentasPequenio

    Private Sub frmReportesVentasPequenio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbSucursal)
        mdlPublicVars.comboActivarFiltro(cmbVendedor)
        mdlPublicVars.comboActivarFiltro(cmbTipoPago)

        Me.cmbSucursal.Enabled = False
        Me.cmbVendedor.Enabled = False
        Me.cmbTipoPago.Enabled = False

    End Sub

    Private Sub rbtnMasVendidos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnMasVendidos.CheckedChanged

        If Me.rbtnMasVendidos.Checked = True Then
            Me.txtTopVendidos.Visible = True
        Else
            Me.txtTopVendidos.Visible = False
        End If

    End Sub

    Private Sub fnImprimirReporte()

        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechainicio As DateTime = Me.dtpDesde.Value
                Dim fechafin As DateTime = Me.dtpHasta.Value
                Dim opcion As Integer
                Dim topvendidos As Integer

                Dim sucursal As Integer = 0
                Dim vendedor As Integer = 0
                Dim tipopago As Integer = 0

                Dim r As New clsReporte

                If rbtnMasVendidos.Checked = True Then
                    opcion = 1
                ElseIf rbtnSinVender.Checked = True Then
                    opcion = 2
                ElseIf rbtnTodosVendidos.Checked = True Then
                    opcion = 3
                End If

                Try
                    topvendidos = Me.txtTopVendidos.Text
                Catch ex As Exception
                    topvendidos = 0
                End Try

                r.tabla = EntitiToDataTable(conexion.sp_ReportesVentasPequenio(opcion, fechainicio, fechafin, sucursal, tipopago, vendedor, topvendidos))

                If opcion = 1 Then
                    r.reporte = "rptMasVendidos.rpt"
                ElseIf opcion = 2 Then
                    r.reporte = "rptNoVendidos.rpt"
                ElseIf opcion = 3 Then
                    r.reporte = "rptTodosVendidos.rpt"
                End If

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
