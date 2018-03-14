Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.Objects
Imports System.Management
Imports System.Data.Common
Imports System.Data.EntityClient

Public Class frmPagosTranstio

    Private _codigoCliente As Integer

    Public Property codigoCliente() As Integer
        Get
            codigoCliente = _codigoCliente
        End Get
        Set(value As Integer)
            _codigoCliente = value
        End Set
    End Property




    Private Sub frmPagosTranstio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdPagos)

        fnLlenarDatos()
        fnSumarios()
        fnConfiguracion()
    End Sub


    ''Funcion utilizada para agregar los sumarios al grid
    Private Sub fnSumarios()
        Try

            'Agregamos antes las filas de sumas
            grdPagos.MasterTemplate.ShowTotals = True
            grdPagos.MasterTemplate.ShowTotals = True
         
            Dim summaryId As New GridViewSummaryItem("Fecha", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryMonto As New GridViewSummaryItem("Monto", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)

            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryMonto})
            grdPagos.SummaryRowsTop.Add(summaryRowItem)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdPagos, "Fecha")
        mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdPagos, "FechaCobro")
        mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdPagos, "Monto")

        grdPagos.Columns("FechaCobro").HeaderText = "Fecha Cobro"
    End Sub


    Private Sub fnLlenarDatos()

        Dim conexion As New dsi_pos_demoEntities

        Try


            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim cliente As tblCliente = (From cl In conexion.tblClientes Where cl.idCliente = codigoCliente Select cl).FirstOrDefault
                lblClave.Text = cliente.clave
                lblCliente.Text = cliente.Nombre1


                Dim consulta = (From c In conexion.tblCajas Where c.cliente = codigoCliente And c.transito = True _
                                    And c.confirmado = False And c.anulado = False Select Fecha = c.fecha, Monto = c.monto, _
                                    TipoPago = c.tblTipoPago.nombre, FechaCobro = c.fechaCobro, Documento = c.documento, Observacion = c.observacion)


                grdPagos.DataSource = consulta


                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub



    Private Sub fnSalida() Handles Me.panel0
        Me.Close()
    End Sub
End Class
