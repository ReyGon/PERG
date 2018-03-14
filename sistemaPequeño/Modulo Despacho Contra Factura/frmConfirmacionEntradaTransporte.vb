Option Strict On

Imports System.Data.EntityClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports Telerik.Data
Imports System.Windows.Forms
Imports System.Linq
Imports System.Windows

Public Class frmConfirmacionEntradaTransporte

#Region "Variables"

#End Region

#Region "Eventos"
    Private Sub frmConfirmacionEntradaTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rbnConfirmado.Checked = True
        Me.rbnNoConfirmado.Checked = False

        fnActivarCombo()
        fnLlenarCombo()

    End Sub

    Private Sub rbnConfirmado_CheckedChanged(sender As Object, e As EventArgs) Handles rbnConfirmado.CheckedChanged
        fnActivarCombo()
    End Sub

    Private Sub rbnNoConfirmado_CheckedChanged(sender As Object, e As EventArgs) Handles rbnNoConfirmado.CheckedChanged
        fnActivarCombo()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If RadMessageBox.Show("Esta Seguro de Confirmar el Concepto de Entrada", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If rbnConfirmado.Checked Then
                superSearchConfirmado = True
                superSearchId = 2
            Else
                superSearchConfirmado = False
                superSearchId = CInt(cmbNoConfirmado.SelectedValue)
            End If

        End If
        frmDespachoFacturaListaTransportes.confirmarentrada = True
        Me.Close()
    End Sub
#End Region

#Region "Funciones"
    Private Sub fnActivarCombo()

        If Me.rbnNoConfirmado.Checked = True Then
            Me.cmbNoConfirmado.Enabled = True
        Else
            Me.cmbNoConfirmado.Enabled = False
        End If

    End Sub

    Private Sub fnLlenarCombo()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim combo As Object = (From x In conexion.tblConceptosEntradaTransportes Where x.combo = True Select Id = x.codigo, Nombre = x.nombre)

            With cmbNoConfirmado
                .DataSource = Nothing
                .ValueMember = "Id"
                .DisplayMember = "Nombre"
                .DataSource = combo
            End With

            conn.Close()
        End Using

    End Sub

    Private Sub frmConfirmacionEntradaTransporte_MenuComplete(sender As Object, e As EventArgs) Handles Me.MenuComplete
        frmDespachoFacturaListaTransportes.confirmarentrada = False
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        frmDespachoFacturaListaTransportes.confirmarentrada = False
        Me.Close()
    End Sub
#End Region
End Class
