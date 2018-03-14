Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data

Public Class frmReporteVentas
    Private permiso As New clsPermisoUsuario
    Private _datos As DataTable

    Public Property datos() As DataTable
        Get
            datos = _datos
        End Get
        Set(ByVal value As DataTable)
            _datos = value
        End Set
    End Property

#Region "LOAD"
    Private Sub frmReporteVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        grdDatos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        fnSumarios()
        Me.grdDatos.EnableGrouping = True
        Me.grdDatos.ShowGroupPanel = True
        Me.grdDatos.MasterTemplate.ShowTotals = True
    End Sub
#End Region

#Region "Eventos"

    Private Sub panelCopiar() Handles Me.panel0
        fnCopiar()
    End Sub

    Private Sub panelDocSalida() Handles Me.panel1
        fnReporte()
    End Sub


    'FILTROS
    Private Sub panelFiltro() Handles Me.panel2
        fnFiltros()
    End Sub

    'GRAFICAR
    Private Sub panelGrafica() Handles Me.panel3
        fnGrafica()
    End Sub

    Private Sub panelSalir() Handles Me.panel4
        Me.Close()
    End Sub

    Private Sub grdDatos_GroupSummaryEvaluate(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs) Handles grdDatos.GroupSummaryEvaluate
        fnResumen(e, "Region")
        fnResumen(e, "Cliente")
        fnResumen(e, "Anho")
        fnResumen(e, "Departamento")
        fnResumen(e, "Municipio")
        fnResumen(e, "Articulo")
    End Sub

    Private Sub frmReporteVentas_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
#End Region

#Region "Funciones"


    Private Sub fnCopiar()
        Try
            mdlPublicVars.ConvertSelectedDataToString(grdDatos, False)
            alerta.contenido = "Copiado "
            alerta.fnErrorContenido()
        Catch ex As Exception
        End Try


    End Sub


    Private Sub fnReporte()

        frmDocumentosSalida.txtTitulo.Text = "Reporte de Ventas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub fnGrafica()
        frmReporteVentasGrafica.Text = "Grafica de Ventas"
        frmReporteVentasGrafica.StartPosition = FormStartPosition.CenterScreen
        frmReporteVentasGrafica.datos = Me.datos
        frmReporteVentasGrafica.grdBase = Me.grdDatos
        permiso.PermisoFrmEspeciales(frmReporteVentasGrafica, False)
    End Sub

    Private Sub fnFiltros()
        frmReporteVentasFiltro.Text = "Filtro"
        frmReporteVentasFiltro.StartPosition = FormStartPosition.CenterScreen
        frmReporteVentasFiltro.ShowDialog()
        'llenar la tabla de datos.
        Me.grdDatos.DataSource = datos

        frmReporteVentasFiltro.Dispose()
    End Sub

    'Funcion utilizada para configurar el grid
    Public Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Try
                'codigo_Detalle Dia,Mes,Anho,Vendedor,Region,Departamento,Municipio,TipoNegocio,Articulo,Cliente,
                'MarcaRepuesto, TipoVehiculo, Modelos, Precio, Costo, Utilidad

                Me.grdDatos.Columns("codigoDetalle").IsVisible = False
                Me.grdDatos.Columns("Anho").HeaderText = "Año"
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Precio")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Costo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Utilidad")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "TotalVenta")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "TotalCosto")

                mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "UltimaVenta")

                Me.grdDatos.Columns("Dia").Width = 50
                Me.grdDatos.Columns("Mes").Width = 50
                Me.grdDatos.Columns("Anho").Width = 50
                Me.grdDatos.Columns("Vendedor").Width = 110
                Me.grdDatos.Columns("Region").Width = 170
                Me.grdDatos.Columns("Departamento").Width = 120
                Me.grdDatos.Columns("Municipio").Width = 150
                Me.grdDatos.Columns("TipoNegocio").Width = 80
                Me.grdDatos.Columns("Documento").Width = 50
                Me.grdDatos.Columns("Codigo").Width = 80
                Me.grdDatos.Columns("Articulo").Width = 180
                Me.grdDatos.Columns("Cliente").Width = 140
                Me.grdDatos.Columns("MarcaRepuesto").Width = 120
                Me.grdDatos.Columns("TipoVehiculo").Width = 80
                Me.grdDatos.Columns("Modelos").Width = 200
                Me.grdDatos.Columns("Cantidad").Width = 80
                Me.grdDatos.Columns("Precio").Width = 100
                Me.grdDatos.Columns("Costo").Width = 100
                Me.grdDatos.Columns("TotalVenta").Width = 115
                Me.grdDatos.Columns("TotalCosto").Width = 115
                Me.grdDatos.Columns("Utilidad").Width = 100
                Me.grdDatos.Columns("UltimaVenta").Width = 70
            Catch ex As Exception
            End Try
        End If
    End Sub


    ''Funcion utilizada para agregar los sumarios al grid
    Private Sub fnSumarios()
        'Agregamos antes las filas de sumas
        Dim summaryPrecio As New GridViewSummaryItem("Precio", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        Dim summaryCosto As New GridViewSummaryItem("Costo", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        Dim summaryUtilidad As New GridViewSummaryItem("Utilidad", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryCosto, summaryPrecio, summaryUtilidad})

        grdDatos.SummaryRowsTop.Add(summaryRowItem)

    End Sub

    Private Sub fnResumen(ByVal e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs, ByVal col As String)

        If e.SummaryItem.Name = col Then
            Dim contactsCount As Integer = e.Group.ItemCount
            Dim precios As Double = 0
            Dim costos As Double = 0
            Dim utilidad As Double = 0
            For Each row As GridViewRowInfo In e.Group
                costos += row.Cells("Costo").Value
                precios += row.Cells("Precio").Value
                utilidad += row.Cells("Utilidad").Value
            Next
            e.FormatString = [String].Format("{0} : Precio {1: ###,###.#0},     Costo: {2: ###,###.#0},     Utilidad: {3: ###,###.#0} ", e.Value, precios, costos, utilidad)
        End If
    End Sub
#End Region

End Class
