Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmBancoChequeConcepto
    Private _idCheque As Integer
    Public Property idCheque As Integer
        Get
            idCheque = _idCheque
        End Get
        Set(ByVal value As Integer)
            _idCheque = value
        End Set
    End Property

    Private Sub frmBancoChequeConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        fnLlenarDatos()
        fnSumarios()
    End Sub

    'LLENA LOS DATOS
    Private Sub fnLlenarDatos()
        'Obtenemos el encabezado del cheque
        Dim cheque As tblBanco_Cheque = (From x In ctx.tblBanco_Cheque Where x.codigo = idCheque
                                         Select x).FirstOrDefault

        If cheque IsNot Nothing Then
            'Llenamos los datos del cheque
            lblFechaRegistro.Text = Format(cheque.fechaRegistro, mdlPublicVars.formatoFecha)
            lblAnulado.Text = If(cheque.bitAnulado, "SI", "NO")
            lblBanco.Text = cheque.tblBanco_Chequera.tblBanco_Cuenta.tblBanco.nombre
            lblBeneficiario.Text = cheque.nombre
            lblChequera.Text = cheque.tblBanco_Chequera.descripcion
            lblConfirmado.Text = If(cheque.bitConfirmado, "SI", "NO")
            lblCorrelativo.Text = cheque.correlativo
            lblCuenta.Text = cheque.tblBanco_Chequera.tblBanco_Cuenta.numeroCuenta
            lblDocumento.Text = cheque.documento
            lblFechaAnulado.Text = If(cheque.fechaAnulado Is Nothing, "", Format(cheque.fechaAnulado, mdlPublicVars.formatoFecha))
            lblFechaConfirmado.Text = If(cheque.fechaConfirmado Is Nothing, "", Format(cheque.fechaConfirmado, mdlPublicVars.formatoFecha))
            lblTotal.Text = Format(cheque.total, mdlPublicVars.formatoMoneda)
            lblUsuarioAnulo.Text = If(cheque.usuarioAnula Is Nothing, "", cheque.tblUsuario.nombre)
            lblUsuarioConfirmo.Text = If(cheque.usuarioConfirma Is Nothing, "", cheque.tblUsuario1.nombre)

            'Obtenemos el detalle del cheque
            Dim detalle = (From x In ctx.tblBanco_ChequeDetalle Where x.cheque = cheque.codigo
                           Select Descripcion = x.descripcion, Concepto = x.tblBanco_MovimientoConcepto.nombre, Monto = x.monto)

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
            Me.grdDatos.Columns("Concepto").Width = 120
            Me.grdDatos.Columns("Monto").Width = 80
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

End Class
