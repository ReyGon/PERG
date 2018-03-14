Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmPagosSinConfirmar
    Public idCliente As Integer = 0

    Private Sub frmPagosSinConfirmar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenarCombos()
        fnLlenarGrid()
        fnConfiguracion()
    End Sub

    Private Sub fnLlenarCombos()
        
    End Sub

    Private Sub fnLlenarGrid()
        'Dim cli As Integer = CType(cmbClientes.SelectedValue, Integer)
        'Try
        '    Dim consulta = (From x In ctx.tblPagoDetalles Where x.transito = True And x.confirmado = False And  Select Confirmado=x.confirmado,Movimiento=x.tblTipoPago.nombre, _
        '                    )

        '    Me.grdDatos.DataSource = consulta
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub fnConfiguracion()

    End Sub

    Private Sub pbBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fnLlenarGrid()
    End Sub
End Class
