Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI


Public Class frmMovimientoInventariosConceptos
    Private _codigo As Integer

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(value As Integer)
            _codigo = value
        End Set
    End Property


    Private Sub frmMovimientoInventarioMovimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()

        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)

        If mdlPublicVars.bitUnidadMedida_Activado Then
            Me.grdDatos.Columns("UnidadMedida").IsVisible = True
        Else
            Me.grdDatos.Columns("UnidadMedida").IsVisible = False
        End If
    End Sub

    Private Sub fnLlenar()
        Try

            Dim movimiento As tblMovimientoInventario = (From x In ctx.tblMovimientoInventarios Where x.codigo = codigo Select x).FirstOrDefault
            lblCodigo.Text = movimiento.codigo
            lblDocumento.Text = movimiento.documento
            lblFecha.Text = movimiento.fechaRegistro.Date
            lblHora.Text = movimiento.fechaRegistro.ToShortTimeString

            lblUsuario.Text = movimiento.tblUsuario.nombre
            lblObservacion.Text = movimiento.observacion

            Dim invIn = (From x In ctx.tblTipoInventarios Where x.idTipoinventario = movimiento.inventarioInicial Select x.nombre).FirstOrDefault
            Dim invFi = (From x In ctx.tblTipoInventarios Where x.idTipoinventario = movimiento.inventarioFinal Select x.nombre).FirstOrDefault

            lblInveInicial.Text = invIn
            lblInveFinal.Text = invFi
            If movimiento.ajuste = True Then
                lblTipoMovimiento.Text = "Ajuste"
            Else
                lblTipoMovimiento.Text = "Traslado"
            End If

            Dim listaMovimientos = (From x In ctx.tblMovimientoInventarioDetalles, y In ctx.tblUnidadMedidas Where x.movimientoInventario = movimiento.codigo And x.idunidadmedida = y.idunidadMedida Select Codigo = x.tblArticulo.codigo1, _
                                    Articulo = x.tblArticulo.nombre1, Concepto = x.tblTipoMovimiento.nombre, Cantidad = x.cantidad, UnidadMedida = y.nombre, Costo = x.costo, Total = x.total)

            Me.grdDatos.DataSource = listaMovimientos
            fnConfiguracion()
            fnCalcularTotal(codigo)
        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try

    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Costo")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

            Me.grdDatos.Columns("Codigo").TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns("Articulo").TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns("Concepto").TextAlignment = ContentAlignment.MiddleCenter

            Me.grdDatos.Columns("Codigo").Width = 40
            Me.grdDatos.Columns("Articulo").Width = 170
            Me.grdDatos.Columns("Concepto").Width = 90
            Me.grdDatos.Columns("Cantidad").Width = 60
            Me.grdDatos.Columns("UnidadMedida").Width = 100
            Me.grdDatos.Columns("Costo").Width = 70
            Me.grdDatos.Columns("Total").Width = 70


            grdDatos.MasterTemplate.ShowTotals = True
            Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryCodigo1 As New GridViewSummaryItem("Total", mdlPublicVars.SimboloSuma + "={0}", GridAggregateFunction.Sum)

            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryCodigo1})


            'agregar summario arreglo a grid
            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub fnCalcularTotal(ByVal id As Integer)
        Dim listaMovimientos As List(Of tblMovimientoInventarioDetalle) = (From x In ctx.tblMovimientoInventarioDetalles Where x.movimientoInventario = id Select x).ToList
        Dim detalle As tblMovimientoInventarioDetalle

        Dim total As Double = 0
        Dim favor As Double = 0
        Dim contra As Double = 0

        For Each detalle In listaMovimientos


            If detalle.entrada = True Then
                favor += detalle.total
            Else
                contra += detalle.total
            End If
        Next
        total = favor - contra

        lblTotal.Text = FormatCurrency(total)
        lblFavor.Text = FormatCurrency(favor)
        lblContra.Text = FormatCurrency(contra)
    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
