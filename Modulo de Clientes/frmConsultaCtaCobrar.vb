Imports System.Linq
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class frmConsultaCtaCobrar

    Private Sub frmConsultaCtaCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        Me.rbtnTodas.Checked = True
        fnllenarCombo()
    End Sub

    Private Sub fnllenarCombo()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim clientes = (From x In conexion.tblClientes Select Codigo = 0, Nombre = "<Todos>").Union(From x In conexion.tblClientes Select Codigo = x.idCliente, Nombre = x.Negocio)

            With cmbCliente
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = clientes
            End With

            conn.Close()
        End Using
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim opcion As Integer
            Dim cliente As Integer

            cliente = cmbCliente.SelectedValue

            If rbtnTodas.Checked = True Then
                opcion = 1
            ElseIf rbtnPagadas.Checked = True Then
                opcion = 2
            ElseIf rbtnPendientes.Checked = True Then
                opcion = 3
            End If


            Dim r As New clsReporte

            r.tabla = EntitiToDataTable(conexion.sp_ReporteCtaCobrar(dtpFechaInicio.Text, dtpFechaFin.Text, cliente, opcion))
            r.reporte = "rptCtacobrarPequenio.rpt"
            r.verReporte()

            conn.Close()
        End Using
    End Sub
End Class
