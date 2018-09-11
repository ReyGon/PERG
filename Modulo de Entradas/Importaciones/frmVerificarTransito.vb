Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq
Imports System.ComponentModel
Imports System.IO

Public Class frmVerificarTransito

    Dim _idPreforma As Integer

    Public Property idPreforma As Integer
        Get
            idPreforma = _idPreforma
        End Get
        Set(value As Integer)
            _idPreforma = value
        End Set
    End Property

    Private Sub frmVerificarTransito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdInvoice)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdInvoice)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdPreforma)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdPreforma)
            fnLlenarCombos()
            fnLlenarGrids(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim invoice = (From x In conexion.tblEntradas Select Codigo = 0, Nombre = "<-Todas->").Union(From x In conexion.tblEntradas Where x.IdPreformaInvoice = idPreforma And x.anulado = False Select Codigo = x.idEntrada, Nombre = CStr(x.serieDocumento & "-" & x.documento))

                With cmbInvoice
                    .DataSource = Nothing
                    .DisplayMember = "Nombre"
                    .ValueMember = "Codigo"
                    .DataSource = invoice
                End With

                Dim prefor = (From x In conexion.tblEntradas Where x.idEntrada = idPreforma And x.anulado = False Select Codigo = x.idEntrada, Nombre = CStr(x.serieDocumento & "-" & x.documento))

                With cmbPreforma
                    .DataSource = Nothing
                    .DisplayMember = "Nombre"
                    .ValueMember = "Codigo"
                    .DataSource = prefor
                End With

                Me.cmbPreforma.Enabled = False

                If idPreforma > 0 Then
                    Me.cmbPreforma.SelectedValue = idPreforma
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarGrids(ByVal Todo As Boolean)

        Try

            Me.grdInvoice.Rows.Clear()
            ''Me.grdInvoice.DataSource = Nothing
            If todo = True Then
                Me.grdPreforma.Rows.Clear()
            End If
            ''Me.grdPreforma.DataSource = Nothing

            Dim idinvoice As Integer
            Dim idpreforma As Integer

            idinvoice = Me.cmbInvoice.SelectedValue
            idpreforma = Me.cmbPreforma.SelectedValue

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim Invoices As List(Of tblEntradasDetalle)

                ''Dim Invoices

                If Me.cmbInvoice.SelectedValue > 0 Then
                    Invoices = (From x In conexion.tblEntradasDetalles
                    Where x.tblEntrada.IdPreformaInvoice = idpreforma And x.idEntrada = idinvoice And x.tblEntrada.anulado = False).ToList()

                    ''Invoices = (From x In conexion.tblEntradasDetalles, y In conexion.tblEntradas, a In conexion.tblArticuloes Where x.idEntrada = y.idEntrada _
                    ''          And x.idArticulo = a.idArticulo And y.IdPreformaInvoice = idpreforma _
                    ''          And x.idEntrada = idinvoice And y.anulado = False Select Codigo = a.codigo1, Producto = a.nombre1, Cantidad = x.cantidad Order By Codigo)
                Else
                    Invoices = (From x In conexion.tblEntradasDetalles
                    Where x.tblEntrada.IdPreformaInvoice = idpreforma And x.tblEntrada.anulado = False).ToList()

                    ''Invoices = (From x In conexion.tblEntradasDetalles, y In conexion.tblEntradas, a In conexion.tblArticuloes Where x.idEntrada = y.idEntrada _
                    ''          And x.idArticulo = a.idArticulo And y.IdPreformaInvoice = idpreforma _
                    ''          And y.anulado = False Select Codigo = a.codigo1, Producto = a.nombre1, Cantidad = x.cantidad Order By Codigo)
                End If

                Dim fila As Object()

                For Each invoice As tblEntradasDetalle In Invoices
                    fila = {invoice.tblArticulo.codigo1, invoice.tblArticulo.nombre1, invoice.cantidad}
                    Me.grdInvoice.Rows.Add(fila)
                Next

                ''Me.grdInvoice.DataSource = Invoices

                ''Dim Preformas As List(Of tblEntradasDetalle)
                ''Dim Preformas

                If todo = True Then
                    Dim Preformas As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.tblEntrada.idEntrada = idpreforma And x.tblEntrada.anulado = False).ToList()

                    ''Preformas = (From x In conexion.tblEntradasDetalles Where x.tblEntrada.idEntrada = idpreforma And x.tblEntrada.anulado = False).ToList

                    For Each preforma As tblEntradasDetalle In Preformas
                        fila = {preforma.tblArticulo.codigo1, preforma.tblArticulo.nombre1, preforma.cantidad, 0}
                        Me.grdPreforma.Rows.Add(fila)
                    Next

                    ''Preformas = (From x In conexion.tblEntradasDetalles, y In conexion.tblEntradas, a In conexion.tblArticuloes Where y.idEntrada = idpreforma _
                    ''          And y.anulado = False And x.idArticulo = a.idArticulo And x.idEntrada = y.idEntrada _
                    ''          Select Codigo = a.codigo1, Producto = a.nombre1, Cantidad = x.cantidad, Faltante = 0 Order By Codigo)

                    ''Me.grdPreforma.DataSource = Preformas

                End If

                conn.Close()
            End Using

            fnConfigurar()
            fnFaltantes()

        Catch ex As Exception

        End Try

    End Sub

    ''Private Sub fnValidar()
    ''    ''Try
    ''    ''    Dim codigo As String = ""

    ''    ''    For index As Integer = 0 To Me.grdInvoice.Rows.Count - 1
    ''    ''        codigo = Me.grdInvoice.Rows(index).Cells("Codigo").Value

    ''    ''        For fila As Integer = 0 To Me.grdPreforma.Rows.Count - 1
    ''    ''            If Me.grdPreforma.Rows(fila).Cells("Codigo").Value = codigo Then
    ''    ''                Me.grdPreforma.Rows(fila).Cells("Invoice").Value = CBool(True)

    ''    ''            End If
    ''    ''        Next
    ''    ''    Next

    ''    ''Catch ex As Exception

    ''    ''End Try
    ''End Sub

    Private Sub fnConfigurar()
        Try
            Me.grdInvoice.Columns("Codigo").Width = 50
            Me.grdInvoice.Columns("Producto").Width = 100
            Me.grdInvoice.Columns("Cantidad").Width = 50
            Me.grdPreforma.Columns("Codigo").Width = 50
            Me.grdPreforma.Columns("Producto").Width = 100
            Me.grdPreforma.Columns("Cantidad").Width = 50
            Me.grdPreforma.Columns("Faltante").Width = 50
            Me.grdPreforma.Columns("Invoice").Width = 50
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbInvoice_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbInvoice.SelectedValueChanged
        Try
            If Me.grdInvoice.Rows.Count - 1 > 0 Then
                fnLlenarGrids(False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdPreforma_CellEditorInitialized(sender As Object, e As CellFormattingEventArgs) Handles grdPreforma.CellFormatting
        Try
            ''Dim codigo As String = ""
            ''Dim cantidad As Integer = 0

            '' ''e.CellElement.DrawFill = True
            ''e.CellElement.NumberOfColors = 1
            ''e.CellElement.ForeColor = Color.Black

            ''For index As Integer = 0 To Me.grdInvoice.Rows.Count - 1
            ''    codigo = Me.grdInvoice.Rows(index).Cells("Codigo").Value
            ''    cantidad = Me.grdInvoice.Rows(index).Cells("Cantidad").Value


            ''    If e.CellElement.RowInfo.Cells("Codigo").Value = codigo And e.CellElement.RowInfo.Cells("Cantidad").Value = cantidad Then
            ''        e.CellElement.NumberOfColors = 1
            ''        e.CellElement.ForeColor = Color.Blue
            ''    ElseIf e.CellElement.RowInfo.Cells("Codigo").Value = codigo And e.CellElement.RowInfo.Cells("Cantidad").Value > cantidad Then
            ''        e.CellElement.NumberOfColors = 1
            ''        e.CellElement.ForeColor = Color.Red
            ''    End If
            ''Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnFaltantes()
        Try
            For index As Integer = 0 To Me.grdPreforma.Rows.Count - 1
                For fila As Integer = 0 To Me.grdInvoice.Rows.Count - 1
                    If Me.grdPreforma.Rows(index).Cells("Codigo").Value = Me.grdInvoice.Rows(fila).Cells("Codigo").Value Then
                        If Me.grdPreforma.Rows(index).Cells("Faltante").Value = 0 Then
                            Me.grdPreforma.Rows(index).Cells("Faltante").Value = Me.grdPreforma.Rows(index).Cells("Cantidad").Value - Me.grdInvoice.Rows(fila).Cells("Cantidad").Value
                        ElseIf Me.grdPreforma.Rows(index).Cells("Faltante").Value > 0 Then
                            Me.grdPreforma.Rows(index).Cells("Faltante").Value -= Me.grdInvoice.Rows(fila).Cells("Cantidad").Value
                        End If
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnValidar() Handles Me.panel0
        Try
            fnFaltantes()
        Catch ex As Exception

        End Try
    End Sub

End Class

