Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmComprasPagos

    Private Sub frmComprasPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
    End Sub

    Private Sub fnLlenar()
        Try
            Dim id As Integer = mdlPublicVars.superSearchId
            Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = id Select x).FirstOrDefault

            lblProveedor.Text = proveedor.negocio
            lblPagos.Text = FormatCurrency(proveedor.pagos)
            lblSaldo.Text = FormatCurrency(proveedor.saldoActual)
            lblEnTransito.Text = FormatCurrency(proveedor.pagosTransito)

            'Consultamos los pagos hechos a esa entrada
            Dim pagos = (From x In ctx.tblCajas Where x.proveedor > 0 And x.proveedor = id _
                         Select Codigo = x.codigo, Fecha = x.fecha, Tipo = x.tblTipoPago.nombre, _
                         Monto = x.monto, Transito = x.transito, Pago = x.fechaCobro, chkAnulado = x.anulado,
                         FechaAnulado = x.fechaAnulado)

            Me.grdDatos.DataSource = pagos
            fnConfiguracion()
        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try

    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Monto")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Pago")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaAnulado")

            Me.grdDatos.Columns("chkAnulado").HeaderText = "Anulado"
            Me.grdDatos.Columns("FechaAnulado").HeaderText = "Fecha Anulado"

            Me.grdDatos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(7).TextAlignment = ContentAlignment.MiddleCenter

            
            Me.grdDatos.Columns("Codigo").Width = 40
            Me.grdDatos.Columns("Fecha").Width = 80
            Me.grdDatos.Columns("Tipo").Width = 150
            Me.grdDatos.Columns("Monto").Width = 90
            Me.grdDatos.Columns("Transito").Width = 80
            Me.grdDatos.Columns("Pago").Width = 80
            Me.grdDatos.Columns("chkAnulado").Width = 60
            Me.grdDatos.Columns("FechaAnulado").Width = 90
        End If

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
