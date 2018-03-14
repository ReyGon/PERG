Imports System.Linq

Public Class frmCierreCajaPagosPendientes

    Private Sub frmCierreCajaPagosPendientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        fnLlenarGrid()
    End Sub

    'Llenar el grid
    Private Sub fnLlenarGrid()
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim cheques = (From x In ctx.tblCajas Where Not x.confirmado And Not x.anulado And x.fecha <= fechaServidor _
                       And x.cliente IsNot Nothing And x.tblTipoPago.cheque
                       Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                       Monto = x.monto)
        grdDatos.DataSource = cheques
        fnConfiguracion()
    End Sub

    'Configurar el grid
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(i).ReadOnly = True
            Next

            Me.grdDatos.Columns("codigo").IsVisible = False

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Monto")

            Me.grdDatos.Columns("Fecha").Width = 25
            Me.grdDatos.Columns("Cliente").Width = 70
            Me.grdDatos.Columns("Documento").Width = 30
            Me.grdDatos.Columns("Descripcion").Width = 80
            Me.grdDatos.Columns("Monto").Width = 30
        End If
    End Sub

    Private Sub grdDatos_CellDoubleClick(sender As System.Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        If Me.grdDatos.RowCount > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)

            If fila >= 0 Then
                Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells(fila).Value
                'Obtenemos el codigo del pago
                frmVerPago.Text = "Pago No.: " & codigo
                frmVerPago.codigo = codigo
                frmVerPago.StartPosition = FormStartPosition.CenterScreen
                frmVerPago.ShowDialog()
                frmVerPago.Dispose()
            End If
        End If
    End Sub

    'SALIR 
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
