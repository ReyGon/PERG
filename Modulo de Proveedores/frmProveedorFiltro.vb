Imports System.Linq

Public Class frmProveedorFiltro

#Region "LOAD"
    Private Sub frmProveedorFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnNoModificarTam(Me)
        mdlPublicVars.fnFormatoGridMovimientos(grdProcedencia)
        mdlPublicVars.fnFormatoGridMovimientos(grdMarcaRepuesto)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoPago)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoRepuesto)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        fnLlenarGrid()
        chkTodosProcedencia.Checked = True
    End Sub
#End Region

#Region "Eventos"

    'Se activa el check de todas las procedencias
    Private Sub chkTodosProcedencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosProcedencia.CheckedChanged
        fnActivaTodos(chkTodosProcedencia.Checked, grdProcedencia)
    End Sub

    'Se da click al boton de FILTRAR
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Dim procedencia As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdProcedencia, 1, 0)
        Dim tipoPago As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoPago, 1, 0)
        Dim tipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
        Dim tipoRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoRepuesto, 1, 0)
        Dim marcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarcaRepuesto, 1, 0)

        Dim datos = ctx.sp_Filtro_lista_Proveedores(procedencia, tipoPago, tipoVehiculo, tipoRepuesto, marcaRepuesto, If(chkBuscarPorFecha.Checked, 1, 0),
                                                    dtpFechaUltCompraDesde.Text, dtpFechaUltCompraHasta.Text & " 23:59:59",
                                                    If(chkBuscaCodigo.Checked, 1, 0), txtClave.Text, If(chkBuscarNombre.Checked, 1, 0), txtNombre.Text)
        frmProveedorLista.grdDatos.DataSource = datos
        frmProveedorLista.filtroActivo = True
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Hide()
    End Sub

#End Region

#Region "Funciones"

    'Funcion utilizada para llenar los grid's
    Private Sub fnLlenarGrid()
        'Procedencia
        Dim procedencia = (From x In ctx.tblProveedorProcedencias _
                           Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)
        Me.grdProcedencia.DataSource = EntitiToDataTable(procedencia)

        'Tipo de Pago
        Dim tipoPago = (From x In ctx.tblProveedorTipoPagoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)
        Me.grdTipoPago.DataSource = EntitiToDataTable(tipoPago)


        'Tipo de Vehiculo
        Dim tipoVehiculo = (From x In ctx.tblArticuloTipoVehiculoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.DataSource = EntitiToDataTable(tipoVehiculo)


        'Tipo de Repuesto
        Dim tipoRepuesto = (From x In ctx.tblArticuloRepuestoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoRepuesto.DataSource = EntitiToDataTable(tipoRepuesto)

        'Tipo Pago
        Dim marcaRepuesto = (From x In ctx.tblArticuloMarcaRepuestoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdMarcaRepuesto.DataSource = EntitiToDataTable(marcaRepuesto)
        fnConfiguracion(grdProcedencia)
        fnConfiguracion(grdMarcaRepuesto)
        fnConfiguracion(grdTipoPago)
        fnConfiguracion(grdTipoRepuesto)
        fnConfiguracion(grdTipoVehiculo)
    End Sub

    'Funcion utilizada para configurar un grid
    Private Sub fnConfiguracion(ByVal grd As Telerik.WinControls.UI.RadGridView)
        If grd.ColumnCount > 0 Then
            With grd
                .Columns("chmAgregar").HeaderText = "Agregar"
                .Columns("chmAgregar").Width = 30
                .Columns("Nombre").ReadOnly = True
                .Columns("Codigo").IsVisible = False
            End With
        End If
    End Sub

    'Funcion utilizada para activar todos los estados en un grid con la columna agregar
    Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells("chmAgregar").Value = estado
        Next
    End Sub

#End Region

End Class
