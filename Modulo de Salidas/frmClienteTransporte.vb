Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows
Imports System.Windows.Forms
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmClienteTransporte

    Private _idSalida As Integer

    Public Property idSalida() As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(ByVal value As Integer)
            _idSalida = value
        End Set
    End Property

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
    
    Private Sub btnLocal_Click(sender As Object, e As EventArgs) Handles btnLocal.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim s As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                s.BITTRANSPORTE = False

                conexion.SaveChanges()

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub btnTransporte_Click(sender As Object, e As EventArgs) Handles btnTransporte.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim s As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                s.BITTRANSPORTE = True

                conexion.SaveChanges()

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
End Class
