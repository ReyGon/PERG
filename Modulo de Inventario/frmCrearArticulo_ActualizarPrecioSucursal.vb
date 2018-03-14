Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Imports System.Data.EntityClient
Public Class frmCrearArticulo_ActualizarPrecioSucursal

    Private Sub btnActualizarCosto_Click(sender As Object, e As EventArgs) Handles btnActualizarPrecio.Click
        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                ' Dim cons = Nothing
                conexion.CommandTimeout = 10000
                Dim cons = conexion.sp_Sucursal_ActualizarPrecios(2)
                '' Dim pPublico As sp_Articulo_PrecioPublico1_Result = (From x In conexion.sp_Articulo_PrecioPublico1(codigo, codClie) Select x).FirstOrDefault

                RadMessageBox.Show("Precios Creados y/o Actualizados", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                conn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al actualizar precios " + ex.ToString())
        End Try
    End Sub

    Private Sub btnActualizarArticulos_Click(sender As Object, e As EventArgs) Handles btnActualizarArticulos.Click
        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim cons = Nothing
                cons = conexion.sp_Sucursal_buscarycreararticulo(2)
                RadMessageBox.Show("Articulos Creados y/o Actualizados", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                conn.Close()
            End Using
 Catch ex As Exception
            MessageBox.Show("Error a crear articulos " + ex.ToString())
        End Try
        

    End Sub

    Private Sub fnsalir_Click() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnInventario.Click

    End Sub
End Class
