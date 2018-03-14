''Imports Telerik.WinControls.UI
''Imports Telerik.WinControls
Imports System.Windows.Forms
''Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmConsultasDinamicas2

    Private Sub frmConsultasDinamicas2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombo()
    End Sub

    Private Sub fnLlenarCombo()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim consultas = (From x In conexion.tblConsultasDinamicas Where x.habilitada Select Codigo = x.idconsulta, Nombre = x.Nombre).ToList

            With cmbConsulta
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = consultas
            End With

            conn.Close()
        End Using
    End Sub

End Class
