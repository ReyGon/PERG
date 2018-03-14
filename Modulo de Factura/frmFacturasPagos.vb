Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmFacturasPagos

    Private Sub frmFacturasPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()
        fnConfiguracion()
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
    End Sub

    Private Sub fnLlenar()
        Try
            Dim id As Integer = mdlPublicVars.superSearchId

            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = id Select x).FirstOrDefault
            lblCliente.Text = cliente.Negocio
            lblPagos.Text = cliente.pagos
            lblSaldo.Text = cliente.saldo

            lblEnTransito.Text = cliente.pagosTransito
            'Consultamos los pagos hechos a esa entrada
            Dim pagos = (From x In ctx.tblCajas Where x.cliente > 0 And x.cliente = id Select Codigo = x.codigo, Fecha = x.fecha, Tipo = x.tblTipoPago.nombre, _
                                    Monto = x.monto, Transito = x.transito, Pago = x.fechaCobro, chkAnulado = x.anulado, FechaAnulado = x.fecha)

            Me.grdDatos.DataSource = pagos
        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try

    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Monto")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Pago")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaAnulado")

            Me.grdDatos.Columns(6).HeaderText = "Anulado"
            Me.grdDatos.Columns(7).HeaderText = "Fecha Anulado"
            Me.grdDatos.Columns("Pago").HeaderText = "Fecha de Pago"

            Me.grdDatos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        End If

    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
