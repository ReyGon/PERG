Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions

Public Class frmSustitutos

    Public grdBase As Telerik.WinControls.UI.RadGridView
    Public base2 As Integer = 0
    Private categoriaSustituto As Integer = 0
    Public filtro As String = ""

    Private Sub frmSustitu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFiltro.Text = filtro
        fnLlenarGrid()
        txtFiltro.Focus()
    End Sub

    'llena el lista en base al filtro.
    Private Sub fnLlenarGrid()
        Dim filtro As String = txtFiltro.Text
        Dim sustitutos = (From x In ctx.tblInventarios _
                            Where x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                            And (x.tblArticulo.nombre1.Contains(filtro) Or CType(x.tblArticulo.codigo1, String).Contains(filtro)) And _
                            x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo <> base2
                            Select detalle = 0, ID = x.idArticulo, Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1)

        grdSustitutos.DataSource = sustitutos
        fnConfiguracion()
        fnBuscarSustitutos()

    End Sub
     
    'grid base de sustitutos en productos.
    Private Sub fnBuscarSustitutos()
        Dim index As Integer
        Dim idSustituto As Integer
        Dim detalle As Integer
        Dim idBase As Integer
        For index = 0 To Me.grdSustitutos.Rows.Count - 1
            Dim contador As Integer
            For contador = 0 To grdBase.Rows.Count - 1
                idBase = Me.grdBase.Rows(contador).Cells("id").Value
                idSustituto = Me.grdSustitutos.Rows(index).Cells("ID").Value
                detalle = Me.grdBase.Rows(contador).Cells("iddetalle").Value
                If idBase = idSustituto Then
                    Me.grdSustitutos.Rows(index).Cells(0).Value = True
                    Me.grdSustitutos.Rows(index).Cells("detalle").Value = detalle
                End If
            Next
        Next

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnLlenarBase()
        Me.Close()
    End Sub

    Private Sub fnConfiguracion()
        Try
            mdlPublicVars.fnFormatoGridMovimientos(grdSustitutos)
            mdlPublicVars.fnGrid_iconos(grdSustitutos)

            Me.grdSustitutos.Columns("ID").IsVisible = False
            grdSustitutos.Columns("detalle").IsVisible = False
            Me.grdSustitutos.Columns("chmSustituto").Width = 80 'agregar
            Me.grdSustitutos.Columns("Codigo").Width = 120 'Codigo
            Me.grdSustitutos.Columns("Nombre").Width = 300 'Nombre

            Me.grdSustitutos.Columns("Sustituto").ReadOnly = False
        Catch ex As Exception
        End Try
    End Sub

    'devuelve los 
    Private Sub fnLlenarBase()
        Dim index As Integer
        Dim detalle As Integer = 0
        grdBase.Rows.Clear()
        For index = 0 To Me.grdSustitutos.Rows.Count - 1
            If grdSustitutos.Rows(index).Cells(0).Value = True Then
                detalle = grdSustitutos.Rows(index).Cells("detalle").Value
                Dim fila As String()
                Dim idArticulo As Integer = Me.grdSustitutos.Rows(index).Cells("id").Value
                Dim art As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = idArticulo).FirstOrDefault
                fila = {detalle, art.idArticulo, art.codigo1, art.codigo2, art.nombre1, art.nombre2, 0}
                'iddetalle,id,codigo1,codigo2,nombre1,nombre2,elimina,marca

                Me.grdBase.Rows.Add(fila)
            End If
        Next

    End Sub

    Private Sub grdSustitutos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdSustitutos.KeyPress
        txtFiltro.Focus()
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            fnLlenarGrid()
            fnConfiguracion()
        End If


    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
