Imports System.Linq
Imports System.Data.OleDb
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmComprasConcepto
    Dim permiso As New clsPermisoUsuario
    Dim esproformaimportacion As Boolean
    Dim proformaimportacion As Integer
    Private _idEntrada As Integer

    Public Property idEntrada() As Integer
        Get
            idEntrada = _idEntrada
        End Get
        Set(ByVal value As Integer)
            _idEntrada = value
        End Set
    End Property

    Private Sub frmComprasConcepto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        fnLlenarDatos()
        fnSumarios()
        mdlPublicVars.fnGrid_iconos(Me.grdProductos)
    End Sub

    'Funcion utilizada para agregar las filas summary
    Private Sub fnSumarios()
        'Agregamos antes las filas de sumas
        Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
        If proformaimportacion = Nothing Then
            Dim summaryTotal As New GridViewSummaryItem("Total", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

            grdProductos.SummaryRowsTop.Add(summaryRowItem)
        ElseIf proformaimportacion = 1 Or proformaimportacion = 2 Then
            Dim summaryTotal As New GridViewSummaryItem("Total", mdlPublicVars.formatoMonedaDolarGridTelerik, GridAggregateFunction.Sum)
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

            grdProductos.SummaryRowsTop.Add(summaryRowItem)
        End If
        'agregar la fila de operaciones aritmeticas


    End Sub

    'Funcion que se utliza para llenar los datos de unqa salida cuando se esta en modificar
    Private Sub fnLlenarDatos()

        Try

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                grdProductos.DataSource = Nothing

                Dim entrada As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = idEntrada
                                           Select x).FirstOrDefault

                Dim gasto = (From x In conexion.tblgastosimportacions Where x.identrada = idEntrada
                                        Select x.totalgasto).FirstOrDefault


                ''If entrada.preformaimportacioextranjero Is Nothing Then

                ''Else
                ''    proformaimportacion = entrada.preformaimportacioextranjero
                ''End If
                ''lblProveedor.Text = entrada.tblProveedor.negocio
                ''lblFechaRegistro.Text = Format(entrada.fechaCompra, mdlPublicVars.formatoFecha)
                ''lblUsuario.Text = entrada.tblUsuario1.nombre

                ''If entrada.preformaimportacioextranjero = 1 Or entrada.preformaimportacioextranjero = 2 Then
                ''    lblTotal.Text = Format(entrada.total, mdlPublicVars.formatoMonedaDolar)
                ''Else
                ''    lblTotal.Text = Format(entrada.total, mdlPublicVars.formatoMoneda)

                ''End If

                lblDocumento.Text = entrada.documento
                lblPreforma.Text = If(entrada.preforma, "SI", "NO")
                lblCompra.Text = If(entrada.compra, "SI", "NO")
                lblAnulada.Text = If(entrada.anulado, "SI", "NO")
                lblFlete.Text = Format(entrada.flete, mdlPublicVars.formatoMoneda)
                If gasto Is Nothing Then
                    lblgasto.Text = 0
                ElseIf gasto IsNot Nothing Then
                    lblgasto.Text = Format(gasto, mdlPublicVars.formatoMoneda)
                ElseIf gasto IsNot Nothing Then
                    lblgasto.Text = 0
                End If
                'AGREGAMOS LOS PRODUCTOS AL GRID
                'Obtenemos el detalle de ese pedido
                Dim lDetalles As IQueryable = (From x In conexion.tblEntradasDetalles, y In conexion.tblUnidadMedidas Where x.idEntrada = idEntrada And x.idunidadmedida = y.idunidadMedida _
                                                Select Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, Cantidad = x.cantidad, UnidadMedida = y.nombre, _
                                                Costo = x.costoIVA, CostoProrrateo = x.costoprorrateo, Total = (x.costoIVA * x.cantidad))

                Me.grdProductos.DataSource = lDetalles
                fnConfiguracion()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para configurar el grid
    Private Sub fnConfiguracion()
        If Me.grdProductos.ColumnCount > 0 Then

            If mdlPublicVars.Entrada_Flete = True Then
                Me.grdProductos.Columns("CostoProrrateo").IsVisible = True
            Else
                Me.grdProductos.Columns("CostoProrrateo").IsVisible = False
            End If

            If mdlPublicVars.bitUnidadMedida_Activado Then
                Me.grdProductos.Columns("UnidadMedida").IsVisible = True
            Else
                Me.grdProductos.Columns("UnidadMedida").IsVisible = False
            End If

            If proformaimportacion = Nothing Then
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Total")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Costo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "CostoProrrateo")

            ElseIf proformaimportacion = 1 Or proformaimportacion = 2 Then
                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(grdProductos, "Total")
                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(grdProductos, "Costo")
                mdlPublicVars.fnGridTelerik_formatoMonedaDolar(grdProductos, "CostoProrrateo")

            End If
            Me.grdProductos.Columns("Codigo").Width = 100
            Me.grdProductos.Columns("Nombre").Width = 200
            Me.grdProductos.Columns("Cantidad").Width = 60
            Me.grdProductos.Columns("UnidadMedida").Width = 100
            Me.grdProductos.Columns("Costo").Width = 80
            Me.grdProductos.Columns("CostoProrrateo").Width = 100
            Me.grdProductos.Columns("Total").Width = 90
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.panel0
        Try
            frmDocumentosSalida.txtTitulo.Text = "Compra a: " & lblProveedor.Text & ", Doc: " & lblDocumento.Text
            frmDocumentosSalida.grd = Me.grdProductos
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = 0
            frmDocumentosSalida.bitCliente = False
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        'Obtenemos el valor de la observacion
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            Dim observacion As String = CStr(Me.grdProductos.Rows(fila).Cells("txbObservacion").Value)

            RadMessageBox.Show(observacion, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        Catch ex As Exception
        End Try

    End Sub

End Class
