Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmClienteDevolucionConceptos

    Private _idDevolucion As Integer
    Public Property idDevolucion As Integer
        Get
            idDevolucion = _idDevolucion
        End Get
        Set(value As Integer)
            _idDevolucion = value
        End Set
    End Property

    Private permiso As New clsPermisoUsuario

    Private Sub frmDevolucionConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
        'mdlPublicVars.fnFormatoGridMovimientos(grdDatos)

        fnSumarios()
    End Sub

    Private Sub fnLlenar()
        Try
            Dim id As Integer = mdlPublicVars.superSearchId

            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                Dim devolucion As tblDevolucionCliente = (From x In ctx.tblDevolucionClientes Where x.codigo = idDevolucion Select x).FirstOrDefault

                lblCliente.Text = devolucion.tblCliente.Negocio
                lblCodigo.Text = id
                lblFecha.Text = devolucion.fechaRegistro.Date
                lblVendedor.Text = devolucion.tblVendedor.nombre
                lblTotal.Text = Format(devolucion.monto, mdlPublicVars.formatoMoneda)
                'Si fue por varias facturas, o por una factura
                If devolucion.bitFactura = True Then
                    lblTipo.Text = "Por Factura"
                    lblFactura.Text = devolucion.factura
                Else
                    lblTipo.Text = "Por varias facturas"
                    lblFactura.Visible = False
                    lbFactura.Visible = False
                End If

                'Si ya fue acreditada o anulada
                If devolucion.acreditado = True Then
                    lblAcreditado.Text = "SI"
                    lblFechaAcreditado.Text = devolucion.acreditadoFecha.Value.Date
                    lblAnulado.Visible = False
                    lblFechaAnulado.Visible = False
                    lbAnulado.Visible = False
                    lbFechaAnulado.Visible = False

                ElseIf devolucion.anulado = True Then
                    lblAnulado.Text = "SI"
                    lblFechaAnulado.Text = devolucion.anuladoFecha.Value.Date
                    lblAcreditado.Visible = False
                    lblFechaAcreditado.Visible = False
                    lbFechaAcreditado.Visible = False
                    lbAcreditado.Visible = False
                Else
                    lblAnulado.Text = "NO"
                    lblAcreditado.Text = "NO"
                    lbFechaAcreditado.Visible = False
                    lbFechaAnulado.Visible = False
                    lblFechaAcreditado.Visible = False
                    lblFechaAnulado.Visible = False
                End If

                Dim consulta = (From x In ctx.tblDevolucionClienteDetalles Where x.devolucion = id _
                                Select Codigo = x.tblArticulo.codigo1, Articulo = x.tblArticulo.nombre1, _
                                Inventario = (From y In ctx.tblTipoInventarios Where y.idTipoinventario = x.tipoInventario Select y.nombre).FirstOrDefault, _
                                Observacion = x.observacion, Vendedor = x.tblVendedor.nombre, Cantidad = x.cantidadRecibida, CantRecibida = x.cantidadAceptada, Precio = x.costo, Total = x.total)

                Me.grdDatos.DataSource = consulta                   'CantRecibida
                conn.close()
            End Using

            
            fnConfiguracion()
        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try

    End Sub

    'Funcion utilizada para agregar las filas summary
    Private Sub fnSumarios()

        Try
            grdDatos.MasterTemplate.ShowTotals = True
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryTotal As New GridViewSummaryItem("Total", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryTotal})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Precio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdDatos.Columns("Codigo").Width = 40
            Me.grdDatos.Columns("Articulo").Width = 170
            Me.grdDatos.Columns("Inventario").Width = 90
            Me.grdDatos.Columns("Observacion").Width = 60
            Me.grdDatos.Columns("Vendedor").Width = 60
            Me.grdDatos.Columns("CantRecibida").Width = 60
            Me.grdDatos.Columns("Cantidad").Width = 55
            Me.grdDatos.Columns("Precio").Width = 60
            Me.grdDatos.Columns("Total").Width = 70
        End If
    End Sub



    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub



    'REPORTE
    Public Function fnReporte() Handles Me.panel0
        Dim r As New clsReporte

        Try
            Dim devolucion As tblDevolucionCliente = (From x In ctx.tblDevolucionClientes.AsEnumerable Where x.codigo = idDevolucion Select x).FirstOrDefault

            r.reporte = "rptDevolucionCliente.rpt"
            r.tabla = EntitiToDataTable(From x In ctx.sp_reporteDevolucionCliente("", devolucion.codigo))
            r.nombreParametro = "filtro"
            r.parametro = "Filtro del reporte:  "

            frmDocumentosSalida.txtTitulo.Text = "Devolución de Cliente "
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.codigo = devolucion.cliente
            frmDocumentosSalida.reporteBase = r.DocumentoReporte()
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

        Return 0
    End Function
End Class
