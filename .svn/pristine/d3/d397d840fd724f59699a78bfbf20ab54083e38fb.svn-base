Imports System.Linq

Public Class frmProductoPedirFiltro

#Region "LOAD"
    Private Sub frmProductoPedirFiltro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdMarca)
        fnLlenarGrid()
    End Sub
#End Region

#Region "Funciones"
    'LLENAR EL GRID
    Private Sub fnLlenarGrid()
        'Tipo de Negocio
        Dim marca = (From x In ctx.tblArticuloMarcaRepuestoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)
        Me.grdMarca.DataSource = EntitiToDataTable(marca)

        mdlPublicVars.fnGrid_iconos(grdMarca)

        With grdMarca
            .Columns("Codigo").IsVisible = False
            .Columns("chmAgregar").Width = 30
            .Columns("Nombre").Width = 70
            .Columns("Nombre").ReadOnly = True
        End With
    End Sub

    'FILTRAR
    Public Sub fnFiltrar()
        Dim desde As DateTime = dtpDesde.Text
        Dim hasta As DateTime = dtpHasta.Text & " 23:59:59"
        Dim marcas As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)

        Dim datos = ctx.sp_lista_articulosPedir(mdlPublicVars.General_idTipoInventario, mdlPublicVars.idEmpresa, desde, hasta, marcas)
        frmProductoPedirLista.grdDatos.DataSource = datos

        frmProductoPedirLista.filtroActivo = True
    End Sub
#End Region

#Region "Eventos"
    'CLIC EN FILTRAR
    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        fnFiltrar()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Hide()
    End Sub

    'SALIR 2
    Private Sub frmProductoPedirFiltro_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    'CHECK TODOS
    Private Sub chkTipoInventario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarca.CheckedChanged
        mdlPublicVars.fnActivaTodos(chkTodosMarca.Checked, grdMarca, "chmAgregar")
    End Sub

    'Cambio en el grid
    Private Sub grdMarca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarca.ValueChanged
        mdlPublicVars.fngrd_contador(grdMarca, lblRecuentoMarcaRepuesto, txtFoco, 0)
    End Sub
#End Region
End Class