Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmPreformasImportacion

    Private Sub frmPreformasImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.superSearchId = 0
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdPreformasImportaciones)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdPreformasImportaciones)
            mdlPublicVars.fnGrid_iconos(Me.grdPreformasImportaciones)
            fnCargarImportaciones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCargarImportaciones()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


                Dim entradas As List(Of tblEntrada) = (From x In conexion.tblEntradas Where x.preformaimportacion = True And x.Invoice = False And x.Nacionalizacion = False And x.finalizada = False Order By x.fechaRegistro Descending).ToList()

                Dim elegir As Boolean = False
                Dim fecha As Date

                For Each preforma As tblEntrada In entradas

                    fecha = preforma.fechaFiltro

                    Me.grdPreformasImportaciones.Rows.Add({preforma.idEntrada, elegir, fecha.ToShortDateString, preforma.tblProveedor.negocio, preforma.serieDocumento + "-" + preforma.documento})
                Next

                fnConfiguracion()

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            Me.grdPreformasImportaciones.Columns("IdPreforma").IsVisible = False
            Me.grdPreformasImportaciones.Columns("chmElegir").Width = 50
            Me.grdPreformasImportaciones.Columns("Fecha").Width = 75
            Me.grdPreformasImportaciones.Columns("Proveedor").Width = 80
            Me.grdPreformasImportaciones.Columns("Documento").Width = 75
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnGuardar() Handles Me.panel0
        Try

            Dim contador As Integer = 0

            For index As Integer = 0 To Me.grdPreformasImportaciones.Rows.Count - 1
                If Me.grdPreformasImportaciones.Rows(index).Cells("chmElegir").Value = True Then
                    contador += 1
                End If
            Next

            If contador > 1 Then
                RadMessageBox.Show("Solamente puede elegir una preforma de importacion", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPreformasImportaciones)

            If Me.grdPreformasImportaciones.Rows(fila).Cells("chmElegir").Value = True Then
                mdlPublicVars.superSearchId = Me.grdPreformasImportaciones.Rows(fila).Cells("IdPreforma").Value
            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class
