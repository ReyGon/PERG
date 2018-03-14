Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmBancoCreditoConcepto
    Private _idMovimiento As Integer
    Public Property idMovimiento As Integer
        Get
            idMovimiento = _idMovimiento
        End Get
        Set(ByVal value As Integer)
            _idMovimiento = value
        End Set
    End Property

    Private Sub frmBancoCreditoConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        fnLlenarDatos()
        fnSumarios()
    End Sub

    'LLENA LOS DATOS
    Private Sub fnLlenarDatos()
        'Obtenemos el encabezado del cheque
        Dim movimiento As tblBanco_Creditos = (From x In ctx.tblBanco_Creditos Where x.codigo = idMovimiento
                                         Select x).FirstOrDefault

        If movimiento IsNot Nothing Then
            'Llenamos los datos del movimiento
            lblFechaRegistro.Text = Format(movimiento.fechaRegistro, mdlPublicVars.formatoFecha)
            lblAnulado.Text = If(movimiento.bitAnulado, "SI", "NO")
            lblBanco.Text = movimiento.tblBanco_Cuenta.tblBanco.nombre

            lblConfirmado.Text = If(movimiento.bitConfirmado, "SI", "NO")
            lblCorrelativo.Text = movimiento.correlativo
            lblCuenta.Text = movimiento.tblBanco_Cuenta.numeroCuenta
            lblDocumento.Text = movimiento.documento
            lblFechaAnulado.Text = If(movimiento.fechaAnulado Is Nothing, "", Format(movimiento.fechaAnulado, mdlPublicVars.formatoFecha))
            lblFechaConfirmado.Text = If(movimiento.fechaConfirmado Is Nothing, "", Format(movimiento.fechaConfirmado, mdlPublicVars.formatoFecha))
            lblTotal.Text = Format(movimiento.total, mdlPublicVars.formatoMoneda)
            lblUsuarioAnulo.Text = If(movimiento.usuarioAnula Is Nothing, "", movimiento.tblUsuario.nombre)
            lblUsuarioConfirmo.Text = If(movimiento.usuarioConfirma Is Nothing, "", movimiento.tblUsuario1.nombre)

            'Obtenemos el detalle del movimiento
            Dim detalle = (From x In ctx.tblBanco_CreditosDetalle Where x.credito = movimiento.codigo
                           Select Descripcion = x.descripcion, Beneficiario = x.tblBanco_Beneficiario.nombre, Concepto = x.tblBanco_MovimientoConcepto.nombre, Monto = x.monto)

            grdDatos.DataSource = detalle
            fnConfigurar()
        End If
    End Sub

    'FILAS SUMMARY'S
    Private Sub fnSumarios()
        Try
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Descripcion", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryMonto As New GridViewSummaryItem("Monto", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryMonto})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'CONFIGURAR EL GRID
    Private Sub fnConfigurar()
        If grdDatos.ColumnCount > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Monto")

            Me.grdDatos.Columns("Descripcion").Width = 120
            Me.grdDatos.Columns("Beneficiario").Width = 100
            Me.grdDatos.Columns("Concepto").Width = 120
            Me.grdDatos.Columns("Monto").Width = 80
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
