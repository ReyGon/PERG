Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows
Imports System.Windows.Forms
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmImpresionFacturas

    Private _descripcion As String

    Public Property descripcion As String
        Get
            descripcion = _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Private Sub btnGuatex_Click(sender As Object, e As EventArgs) Handles btnCredito.Click

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim r As New clsReporte
            conexion.CommandTimeout = 10000
            r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", descripcion, mdlPublicVars.idEmpresa))
            r.nombreParametro = "@filtro"
            r.reporte = "factura_FacturaSinDescCR.rpt"
            r.parametro = ""
            ''r.verReporte()
            r.imprimirReporte()

            ''Dim r As New clsReporte
            ''r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteGuiasImpresion(idcliente, idSalida))
            '' ''r.nombreParametro = "@filtro"
            ''r.reporte = "rptReporteGuiaGuatexImpresion.rpt"
            ''r.imprimirReporte()

            conn.Close()
        End Using

        Me.Close()
    End Sub

    Private Sub btnCargoExpress_Click(sender As Object, e As EventArgs) Handles btnContado.Click
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim r As New clsReporte
            conexion.CommandTimeout = 10000
            r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", descripcion, mdlPublicVars.idEmpresa))
            r.nombreParametro = "@filtro"
            r.reporte = "factura_FacturaSinDesc.rpt"
            r.parametro = ""
            ''r.verReporte()
            r.imprimirReporte()

            ''Dim r As New clsReporte
            ''r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteGuiasImpresion(idcliente, idSalida))
            '' ''r.nombreParametro = "@filtro"
            ''r.reporte = "rptReporteGuiaCargoImpresion.rpt"
            ''r.imprimirReporte()

            conn.Close()
        End Using

        Me.Close()
    End Sub

    Private Sub frmImpresionGuias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    
End Class
