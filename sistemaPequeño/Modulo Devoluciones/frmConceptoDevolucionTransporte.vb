''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Linq
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Windows

Public Class frmConceptoDevolucionTransporte

    Private Sub frmConceptoDevolucionTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbConceptoDevolucionTransporte)

        fnLlenarCombo()
    End Sub

    Private Sub fnLlenarCombo()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim conceptos = (From x In conexion.tblTipoMovimientoes Where x.devtransporte = True And x.aumentaInventario = True Select Id = x.idTipoMovimiento, Nombre = x.nombre)

            With cmbConceptoDevolucionTransporte
                .DataSource = Nothing
                .ValueMember = "ID"
                .DisplayMember = "Nombre"
                .DataSource = conceptos
            End With

            conn.Close()
        End Using
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        superSearchId = cmbConceptoDevolucionTransporte.SelectedValue
        superSearchNombre = cmbConceptoDevolucionTransporte.Text
        Me.Close()
    End Sub
End Class
