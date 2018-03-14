Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows
Imports System.Windows.Forms
Imports System.Data.EntityClient


Public Class frmActualizadorCreador

    Private Sub frmActualizadorCreador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtSucursal.Text = ServidorSucursal
            Me.txtSucursal.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
        Try
            fnEjecutar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnEjecutar()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cons = Nothing

                If Me.rbtnPrecios.Checked = True Then
                    cons = conexion.sp_Sucursal_ActualizarPrecios(mdlPublicVars.idEmpresa)
                ElseIf Me.rbtnArticulos.Checked = True Then
                    cons = conexion.sp_Sucursal_buscarycreararticulo(mdlPublicVars.idEmpresa)
                End If

                conn.Close()
            End Using
        Catch ex As Exception
            alerta.fnErrorContenido()
            alerta.contenido = "Ocurrio un Problema durante la Ejecucion"
        End Try
        alerta.fnGuardar()
    End Sub
End Class
