Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows
Imports System.Windows.Forms
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmImpresionGuias

    Private _idSalida As Integer
    Private _idcliente As Integer

    Public Property idSalida() As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(ByVal value As Integer)
            _idSalida = value
        End Set
    End Property

    Public Property idcliente As Integer
        Get
            idcliente = _idcliente
        End Get
        Set(value As Integer)
            _idcliente = value
        End Set
    End Property

    Private Sub btnGuatex_Click(sender As Object, e As EventArgs) Handles btnGuatex.Click

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim r As New clsReporte
            r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteGuiasImpresion(idcliente, idSalida))
            ''r.nombreParametro = "@filtro"
            r.reporte = "rptReporteGuiaGuatexImpresion.rpt"
            r.imprimirReporte()

            conn.Close()
        End Using
        fnActivarGuia()
        Me.Close()
    End Sub

    Private Sub btnCargoExpress_Click(sender As Object, e As EventArgs) Handles btnCargoExpress.Click
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim r As New clsReporte
            r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteGuiasImpresion(idcliente, idSalida))
            ''r.nombreParametro = "@filtro"
            r.reporte = "rptReporteGuiaCargoImpresion.rpt"
            r.imprimirReporte()

            conn.Close()
        End Using
        fnActivarGuia()
        Me.Close()
    End Sub

    Private Sub frmImpresionGuias_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub fnActivarGuia()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                salida.bitguia = True

                conexion.SaveChanges()
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
