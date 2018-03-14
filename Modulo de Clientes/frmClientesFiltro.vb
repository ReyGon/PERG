Imports System.Linq

Public Class frmClientesFiltro

#Region "LOAD"
    Private Sub frmClientesFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnNoModificarTam(Me)
        mdlPublicVars.fnFormatoGridEspeciales(grdClasificacionNegocio)
        mdlPublicVars.fnFormatoGridEspeciales(grdPrecios)
        mdlPublicVars.fnFormatoGridEspeciales(grdTipoNegocio)
        mdlPublicVars.fnFormatoGridEspeciales(grdTipoPago)
        mdlPublicVars.fnFormatoGridEspeciales(grdTipoVehiculo)
        fnLlenarGrid()
        mdlPublicVars.fnGrid_iconos(grdClasificacionNegocio)
        mdlPublicVars.fnGrid_iconos(grdPrecios)
        mdlPublicVars.fnGrid_iconos(grdTipoNegocio)
        mdlPublicVars.fnGrid_iconos(grdTipoPago)
        mdlPublicVars.fnGrid_iconos(grdTipoVehiculo)

        chkTodosClasificacionNegocio.Checked = True
        chkTodosPrecios.Checked = True
        chkTodosTipoNegocio.Checked = True
        chkTodosTipoPago.Checked = True
        chkTodosTipoVehiculo.Checked = True
    End Sub
#End Region

#Region "Eventos"
    'Check de todos los TIPOS de VEHICULO
    Private Sub chkTodosTipoNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoNegocio.CheckedChanged
        fnActivaTodos(chkTodosTipoNegocio.Checked, grdTipoNegocio)
    End Sub

    'Check de todos los TIPOS de VEHICULO
    Private Sub chkTodosClasificacionNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosClasificacionNegocio.CheckedChanged
        fnActivaTodos(chkTodosClasificacionNegocio.Checked, grdClasificacionNegocio)
    End Sub

    'Check de todos los TIPOS de VEHICULO
    Private Sub chkTodosTipoPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoPago.CheckedChanged
        fnActivaTodos(chkTodosTipoPago.Checked, grdTipoPago)
    End Sub

    'Check de todos los TIPOS de VEHICULO
    Private Sub chkTodosPrecios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosPrecios.CheckedChanged
        fnActivaTodos(chkTodosPrecios.Checked, grdPrecios)
    End Sub

    'Check de todos los TIPOS de VEHICULO
    Private Sub chkTodosTipoVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoVehiculo.CheckedChanged
        fnActivaTodos(chkTodosTipoVehiculo.Checked, grdTipoVehiculo)
    End Sub

    'Presiona el boton filtrar
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim tipoNegocio As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoNegocio, 1, 0)
        Dim clasificacion As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdClasificacionNegocio, 1, 0)
        Dim tipoPago As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoPago, 1, 0)
        Dim tipoPrecio As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdPrecios, 1, 0)
        Dim tipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)

        frmClienteLista.grdDatos.DataSource = ctx.sp_Filtro_lista_clientes(tipoNegocio, clasificacion, tipoPago, tipoVehiculo, tipoPrecio,
                                                 If(chkBuscaCodigo.Checked, 1, 0), txtClave.Text, If(chkBuscarNombre.Checked, 1, 0), txtNombre.Text,
                                                 mdlPublicVars.idEmpresa)
        frmClienteLista.filtroActivo = True
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Hide()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para configurar un grid
    Private Sub fnConfiguracion(ByVal grd As Telerik.WinControls.UI.RadGridView)
        If grd.ColumnCount > 0 Then
            With grd
                .Columns("chmAgregar").HeaderText = "Agregar"
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

    'Funcion utilizada para llenar los grid's
    Private Sub fnLlenarGrid()
        'Tipo de Negocio
        Dim tipoNegocio = (From x In ctx.tblClienteTipoNegocios _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.idTipoNegocio, Nombre = x.nombre)
        Me.grdTipoNegocio.DataSource = EntitiToDataTable(tipoNegocio)


        'Clasificacion
        Dim clasificacion = (From x In ctx.tblClienteClasificacionNegocios _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.idClasificacionNegocio, Nombre = x.nombre)

        Me.grdClasificacionNegocio.DataSource = EntitiToDataTable(clasificacion)


        'Tipo Vehiculo
        Dim tipoVehiculo = (From x In ctx.tblArticuloTipoVehiculoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.DataSource = EntitiToDataTable(tipoVehiculo)

        'Tipo Pago
        Dim tipoPago = (From x In ctx.tblClienteTipoPagoes _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.idtipoPago, Nombre = x.nombre)

        Me.grdTipoPago.DataSource = EntitiToDataTable(tipoPago)

        'Tipo Precio
        Dim tipoPrecio = (From x In ctx.tblArticuloTipoPrecios Where x.bitEspecial = False _
                          Select chmAgregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdPrecios.DataSource = EntitiToDataTable(tipoPrecio)

        fnConfiguracion(grdClasificacionNegocio)
        fnConfiguracion(grdPrecios)
        fnConfiguracion(grdTipoNegocio)
        fnConfiguracion(grdTipoPago)
        fnConfiguracion(grdTipoVehiculo)
    End Sub

#End Region
End Class
