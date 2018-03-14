Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Linq
Imports System.Data.EntityClient


Public Class frmCorrelativoFactura

    Private _idsalida As Integer

    Public Property idsalida As Integer
        Get
            idsalida = _idsalida
        End Get
        Set(value As Integer)
            _idsalida = value
        End Set
    End Property

    Private Sub frmCorrelativoFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            fnLlenarCombo()
            fnllenarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim codigo As Integer = Me.cmbResolucion.SelectedValue

                Dim correlativos As Integer = (From x In conexion.tblResolucionFacturas Where x.habilitado = True And x.idResolucion = codigo Select x.correlativo).FirstOrDefault

                Me.txtCorrelativo.Text = CStr(correlativos + 1)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombo()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim resolucion = (From x In conexion.tblResolucionFacturas Where x.habilitado = True Select Id = x.idResolucion, Nombre = x.resolucion)

                With cmbResolucion
                    .DataSource = Nothing
                    .ValueMember = "Id"
                    .DisplayMember = "Nombre"
                    .DataSource = resolucion
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim correcto As String = Me.txtCorrelativoNuevo.Text

                If correcto = "" Then
                    RadMessageBox.Show("El Correlativo no puede estar Vacio!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End If

                Dim codigo As Integer = Me.cmbResolucion.SelectedValue

                Dim resolucion As tblResolucionFactura = (From x In conexion.tblResolucionFacturas Where x.idResolucion = codigo Select x).FirstOrDefault

                If correcto < resolucion.inicio Or correcto > resolucion.final Then
                    RadMessageBox.Show("El Correlativo no se Encuentra dentro del Rango Valido!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    conn.Close()
                    Exit Sub
                End If

                resolucion.correlativo = CInt(correcto - 1)

                conexion.SaveChanges()
                conn.Close()

                alerta.fnGuardar()
                Me.Close()
            End Using
        Catch ex As Exception
            alerta.fnError()
        End Try

    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
