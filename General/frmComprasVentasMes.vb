Imports System.Linq

Public Class frmComprasVentasMes

#Region "Variables"
    Private _bitCompra As Boolean
    Private _bitVenta As Boolean

    Public Property bitCompra As Boolean
        Get
            bitCompra = _bitCompra
        End Get
        Set(ByVal value As Boolean)
            _bitCompra = value
        End Set
    End Property

    Public Property bitVenta As Boolean
        Get
            bitVenta = _bitVenta
        End Get
        Set(ByVal value As Boolean)
            _bitVenta = value
        End Set
    End Property
#End Region

#Region "LOAD"
    Private Sub frmComprasVentasMes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarCombos()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para llenar los combos
    Private Sub fnLlenarCombos()
        Dim meses = Nothing
        Dim anhos = Nothing
        If bitVenta Then
            meses = (From x In ctx.tblFacturas
                            Where x.anulado = 0
                            Group By Fecha = Month(x.Fecha)
                            Into Group
                            Select Fecha)

            anhos = (From x In ctx.tblFacturas
                            Where x.anulado = 0
                            Group By Fecha = Year(x.Fecha)
                            Into Group
                            Select Fecha)
        ElseIf bitCompra Then
            meses = (From x In ctx.tblEntradas
                         Where x.anulado = 0 And x.compra = 1 And x.fechaCompra IsNot Nothing
                         Group By Fecha = Month(x.fechaCompra)
                         Into Group
                         Select Fecha)

            anhos = (From x In ctx.tblEntradas
                        Where x.anulado = 0 And x.compra = 1 And x.fechaCompra IsNot Nothing
                        Group By Fecha = Year(x.fechaCompra)
                        Into Group
                        Select Fecha)
        End If

        'Llenamos los combos
        With cmbMes
            .DataSource = Nothing
            .ValueMember = "Fecha"
            .DisplayMember = "Fecha"
            .DataSource = meses
        End With

        With cmbAnho
            .DataSource = Nothing
            .ValueMember = "Fecha"
            .DisplayMember = "Fecha"
            .DataSource = anhos
        End With
    End Sub

    'Funcion utilizada para generar el reporte
    Private Sub fnGeneraReporte()
        Dim c As New clsReporte

        c.parametro = ""
        c.nombreParametro = "@filtro"

        If bitVenta Then
            c.reporte = "rptReporteVentasMes.rpt"
            c.tabla = EntitiToDataTable(ctx.sp_ReporteVentasMes("", CInt(cmbMes.SelectedValue), CInt(cmbAnho.SelectedValue), mdlPublicVars.idEmpresa))

        ElseIf bitCompra Then
            c.reporte = "rptReporteComprasMes.rpt"
            c.tabla = EntitiToDataTable(ctx.sp_ReporteComprasMes("", CInt(cmbMes.SelectedValue), CInt(cmbAnho.SelectedValue), mdlPublicVars.idEmpresa))
        End If

        c.verReporte()
    End Sub
#End Region

#Region "Eventos"
    'CLIC EN REPORTE
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        fnGeneraReporte()
    End Sub
#End Region


End Class
