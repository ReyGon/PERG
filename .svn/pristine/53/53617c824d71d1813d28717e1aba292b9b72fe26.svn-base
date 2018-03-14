Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmMovimientoInventarioConcepto
    Dim permiso As New clsPermisoUsuario

    Private _codigo As Integer

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmPedidoConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        fnLlenarDatos()
        fnSumarios()
        mdlPublicVars.fnGrid_iconos(Me.grdProductos)
    End Sub

    'Funcion utilizada para agregar las filas summary
    Private Sub fnSumarios()
        'Agregamos antes las filas de sumas
        Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
        Dim summaryTotal As New GridViewSummaryItem("Total", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

        grdProductos.SummaryRowsTop.Add(summaryRowItem)
    End Sub

    'Funcion que se utliza para llenar los datos de unqa salida cuando se esta en modificar
    Private Sub fnLlenarDatos()
        Try
            grdProductos.Rows.Clear()
            Dim movimiento As tblMovimientoInventario = (From x In ctx.tblMovimientoInventarios Where x.codigo = codigo Select x).FirstOrDefault


            lblUsuario.Text = movimiento.tblUsuario.nombre
            lblDocumento.Text = movimiento.correlativo
            lblFechaRegistro.Text = Format(movimiento.fechaRegistro, mdlPublicVars.formatoFecha)
            lblInventarioInicial.Text = movimiento.tblTipoInventario.nombre
            lblInventarioFinal.Text = movimiento.tblTipoInventario1.nombre
            lblRevisado.Text = If(movimiento.revisado, "SI", "NO")
            lblFechaRevisado.Text = If(movimiento.fechaRevisado Is Nothing, "", movimiento.fechaRevisado)

            'Obtenemos el total del movimiento
            Dim saldo As Decimal = (From x In ctx.tblMovimientoInventarioDetalles Where x.movimientoInventario = codigo _
                                    Select If(x.entrada, x.total, -x.total)).Sum

            lblTotal.Text = Format(saldo, mdlPublicVars.formatoMoneda)
            'AGREGAMOS LOS PRODUCTOS AL GRID
            'Obtenemos el detalle de ese pedido
            Dim lDetalles As IQueryable = (From x In ctx.tblMovimientoInventarioDetalles Where x.movimientoInventario = movimiento.codigo
                                           Select Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, Concepto = x.tblTipoMovimiento.nombre,
                                           Cantidad = x.cantidad, Costo = x.costo, Total = x.costo * x.cantidad)

            Me.grdProductos.DataSource = lDetalles
            fnConfiguracion()
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para configurar el grid
    Private Sub fnConfiguracion()
        If Me.grdProductos.ColumnCount > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Total")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Costo")

            Me.grdProductos.Columns("Codigo").Width = 80
            Me.grdProductos.Columns("Nombre").Width = 170
            Me.grdProductos.Columns("Concepto").Width = 80
            Me.grdProductos.Columns("Cantidad").Width = 60
            Me.grdProductos.Columns("Costo").Width = 70
            Me.grdProductos.Columns("Total").Width = 80
        End If
    End Sub

    'IMPRIMIR
    Private Sub fnImpresion() Handles Me.panel0
        fnDocSalida()
    End Sub

    Private Sub fnDocSalida()
        Try
            'Obtenemos informacion sobre el movimiento de inventario
            Dim movimiento As tblMovimientoInventario = (From x In ctx.tblMovimientoInventarios.AsEnumerable Where x.codigo = codigo
                                                         Select x).FirstOrDefault

            Dim r As New clsReporte
            r.reporte = "rptMovimientoInventario.rpt"
            r.tabla = EntitiToDataTable(From x In ctx.sp_reporteMovimientoInventario("", codigo))
            r.nombreParametro = "@filtro"
            r.parametro = "Filtro del reporte:  "

            frmDocumentosSalida.txtTitulo.Text = "Movimiento de Inventario: " & If(movimiento.ajuste, "Ajuste", If(movimiento.traslado, "Traslado", "")) & "; Documento: " & movimiento.correlativo
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.bitCliente = False
            frmDocumentosSalida.reporteBase = r.DocumentoReporte()
            permiso.PermisoDialogEspeciales(frmDocumentosSalida)
            frmDocumentosSalida.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

End Class
