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
            Me.grdPreformasImportaciones.Columns("chmElegir").ReadOnly = False
            Me.grdPreformasImportaciones.Columns("Documento").ReadOnly = True

        Catch ex As Exception

        End Try
    End Sub

    ''Private Sub fnGuardar() Handles Me.panel0
    ''    Try

    ''        Dim contador As Integer = 0

    ''        Me.grdPreformasImportaciones.Select()
    ''        Me.grdPreformasImportaciones.Focus()

    ''        For index As Integer = 0 To Me.grdPreformasImportaciones.Rows.Count - 1
    ''            If Me.grdPreformasImportaciones.Rows(index).Cells("chmElegir").Value = True Then
    ''                contador += 1
    ''            End If
    ''        Next

    ''        If contador > 1 Then
    ''            RadMessageBox.Show("Solamente puede elegir una preforma de importacion", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    ''            Exit Sub
    ''        End If

    ''        ''Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPreformasImportaciones)

    ''        ''If Me.grdPreformasImportaciones.Rows(fila).Cells("chmElegir").Value = True Then
    ''        ''    mdlPublicVars.superSearchId = Me.grdPreformasImportaciones.Rows(fila).Cells("IdPreforma").Value
    ''        ''End If

    ''        For index As Integer = 0 To Me.grdPreformasImportaciones.Rows.Count - 1
    ''            If Me.grdPreformasImportaciones.Rows(index).Cells("chmElegir").Value = True Then
    ''                mdlPublicVars.superSearchId = Me.grdPreformasImportaciones.Rows(index).Cells("IdPreforma").Value
    ''            End If
    ''        Next


    ''        Me.Close()
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Private Sub frmPreformasImportacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPreformasImportaciones.Click
        Try
            If Me.grdPreformasImportaciones.Rows.Count > 0 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPreformasImportaciones)

                If Me.grdPreformasImportaciones.CurrentColumn.Name.Equals("chmElegir") Then
                    Me.grdPreformasImportaciones.Rows(fila).Cells("chmElegir").Value = True

                    If RadMessageBox.Show("¿Desea seleccionar esta preforma para la Invoice?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Forms.DialogResult.Yes Then
                        mdlPublicVars.superSearchId = Me.grdPreformasImportaciones.Rows(fila).Cells("IdPreforma").Value
                        Me.Close()
                    Else
                        mdlPublicVars.superSearchId = 0
                        Me.grdPreformasImportaciones.Rows(fila).Cells("chmElegir").Value = False
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class
