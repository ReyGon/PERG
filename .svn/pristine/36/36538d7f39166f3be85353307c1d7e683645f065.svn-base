Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI

Public Class frmPedidosAjustesConceptos
    Private _codClie As Integer
    Private _codSalida As Integer

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Public Property codSalida() As Integer
        Get
            codSalida = _codSalida
        End Get
        Set(ByVal value As Integer)
            _codSalida = value
        End Set
    End Property

    Private Sub frmSalidasAjustesConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)
        fnFilasTotales()
        fnLlenar()
        fnConfiguracion()
    End Sub

    'Funcion utilizada para agregar los row's summary
    Private Sub fnFilasTotales()
        grdDatos.MasterTemplate.ShowTotals = True
        Dim summaryCantidad As New GridViewSummaryItem("Total", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        Dim summaryDisponible As New GridViewSummaryItem("Positivo", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summaryTransito As New GridViewSummaryItem("Negativo", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        
        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryCantidad, summaryDisponible, summaryTransito})

        grdDatos.SummaryRowsTop.Add(summaryRowItem)
    End Sub

    Private Sub fnLlenar()
        Try
            'Llenamos los datos del cliente y del encabezado
            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codClie Select x).FirstOrDefault
            lblCliente.Text = cliente.Negocio

            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codSalida Select x).FirstOrDefault
            lblSalida.Text = salida.documento
            lblTotal.Text = Format(salida.total, mdlPublicVars.formatoMoneda)
            lblFechaRegistro.Text = salida.fechaRegistro.ToShortDateString

            'Realizamos la consulta para obtener los ajustes
            Dim ajustes = (From x In ctx.tblMovimientoInventarioDetalles Where x.tblMovimientoInventario.bitVenta = True _
                           And x.tblMovimientoInventario.codigoSalida = salida.idSalida And x.tblMovimientoInventario.anulado = False _
                           Select Fecha = x.tblMovimientoInventario.fechaRegistro, Concepto = x.tblTipoMovimiento.nombre, _
                           Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, _
                           Cantidad = If(x.cantidad Is Nothing, 0, x.cantidad), Precio = x.tblSalidaDetalle.precio,
            Positivo = If(x.cantidad > 0, CType(If(x.tblTipoMovimiento.aumentaInventario = True, x.cantidad * x.costo, 0), Decimal), 0), _
            Negativo = If(x.cantidad > 0, CType(If(x.tblTipoMovimiento.aumentaInventario = True, 0, -(x.cantidad * x.tblSalidaDetalle.precio)), Decimal), 0), _
            Total = If(x.cantidad > 0, CType(If(x.tblTipoMovimiento.aumentaInventario = True, x.cantidad * x.tblSalidaDetalle.precio, -(x.cantidad * x.tblSalidaDetalle.precio)), Decimal), 0), Aumenta = x.tblTipoMovimiento.aumentaInventario)

            Me.grdDatos.DataSource = ajustes
            fnTotal()
        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try
    End Sub

    'Funcion utilizada para calcular el total del ajuste
    Private Sub fnTotal()
        Try
            Dim fila As GridViewRowInfo
            Dim total As Decimal = 0
            For Each fila In grdDatos.Rows
                total += fila.Cells("Total").Value
            Next

            lblTotalAjuste.Text = Format(total, mdlPublicVars.formatoMoneda)
            Dim totFinal As Decimal = CDec(lblTotal.Text)

            lblTotalInicial.Text = Format(totFinal - total, mdlPublicVars.formatoMoneda)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then
            Try
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Precio")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Positivo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Negativo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

                For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.BottomCenter
                Next


                Me.grdDatos.Columns(0).Width = 80
                Me.grdDatos.Columns(1).Width = 100
                Me.grdDatos.Columns(2).Width = 90
                Me.grdDatos.Columns(3).Width = 180
                Me.grdDatos.Columns(4).Width = 70
                Me.grdDatos.Columns(5).Width = 70
                Me.grdDatos.Columns(6).Width = 90

                Me.grdDatos.Columns("Aumenta").IsVisible = False
            Catch ex As Exception

            End Try
            

        End If

    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class