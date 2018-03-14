Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI

Public Class frmComprasAjustesConceptos
    Private _codEntrada As Integer

    Public Property codEntrada() As Integer
        Get
            codEntrada = _codEntrada
        End Get
        Set(ByVal value As Integer)
            _codEntrada = value
        End Set
    End Property

    Private Sub frmComprasAjustesConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)
        fnSumarios()
        fnLlenar()
        fnConfiguracion()
    End Sub

    'Funcion utilizada para agregar los row's summary
    Private Sub fnSumarios()
        grdDatos.MasterTemplate.ShowTotals = True
        Dim summaryCantidad As New GridViewSummaryItem("Total", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)


        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryCantidad})

        grdDatos.SummaryRowsTop.Add(summaryRowItem)
    End Sub

    Private Sub fnLlenar()
        Try
            'Llenamos los datos del cliente y del encabezado
            Dim entrada As tblEntrada = (From x In ctx.tblEntradas.AsEnumerable Where x.idEntrada = codEntrada Select x).FirstOrDefault
            lblEntrada.Text = entrada.correlativo
            lblTotal.Text = Format(entrada.total, mdlPublicVars.formatoMoneda)
            lblFechaRegistro.Text = entrada.fechaRegistro.ToShortDateString

            Dim prov As tblProveedor = (From x In ctx.tblProveedors.AsEnumerable Where x.idProveedor = entrada.idProveedor Select x).FirstOrDefault
            lblProveedor.Text = prov.negocio

            'Realizamos la consulta para obtener los ajustes
            Dim ajustes = (From x In ctx.tblDevolucionProveedorDetalles Where x.tblDevolucionProveedor.entrada = codEntrada _
                           And x.tblDevolucionProveedor.anulado = False And x.tblDevolucionProveedor.tipoMovimiento = mdlPublicVars.Proveedor_AjusteCodigoMovimiento _
                           Select Fecha = x.tblDevolucionProveedor.fechaRegistro, Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, _
                           Cantidad = x.cantidad, Costo = x.costo, Total = x.cantidad * x.costo)

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
            Dim aumenta As Boolean = False
            For Each fila In grdDatos.Rows
                total += fila.Cells("Total").Value
            Next

            lblTotalAjuste.Text = Format(total, mdlPublicVars.formatoMoneda)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Costo")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

            For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.BottomCenter
            Next


            'Select Fecha  Codigo, Nombre 
            '              Cantidad, Precio, Total )

            Me.grdDatos.Columns("Fecha").Width = 80
            Me.grdDatos.Columns("Codigo").Width = 80
            Me.grdDatos.Columns("Nombre").Width = 180
            Me.grdDatos.Columns("Cantidad").Width = 80
            Me.grdDatos.Columns("Costo").Width = 80
            Me.grdDatos.Columns("Total").Width = 100
        End If

    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
