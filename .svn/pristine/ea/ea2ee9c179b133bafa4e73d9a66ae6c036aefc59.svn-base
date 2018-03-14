Imports System.Linq

Public Class frmPriceFiltro

    Private Sub frmProductoFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnNoModificarTam(Me)
        mdlPublicVars.fnFormatoGridMovimientos(grdImportancia)
        mdlPublicVars.fnFormatoGridMovimientos(grdInventario)
        mdlPublicVars.fnFormatoGridMovimientos(grdMarca)
        mdlPublicVars.fnFormatoGridMovimientos(grdModelo)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoRepuesto)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoPrecio)
        fnLlenarGrid()
        chkTipoInventario.Checked = True
        chkTodosImportancia.Checked = True
        chkTodosMarca.Checked = True
        chkTodosModelo.Checked = True
        chkTodosTipoRepuesto.Checked = True
        chkTodosTipoVehiculo.Checked = True
        chkTodosTipoPrecio.Checked = True
        mdlPublicVars.fngrd_contador(grdImportancia, lblRecuentoImportancia, txtCodigo, 0)
        mdlPublicVars.fngrd_contador(grdInventario, lblRecuentoInventario, txtCodigo, 0)
        mdlPublicVars.fngrd_contador(grdMarca, lblRecuentoMarcaRepuesto, txtCodigo, 0)
        mdlPublicVars.fngrd_contador(grdModelo, lblRecuentoModelo, txtCodigo, 0)
        mdlPublicVars.fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto, txtCodigo, 0)
        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo, txtCodigo, 0)
        mdlPublicVars.fngrd_contador(grdTipoPrecio, lblRecuentoTipoPrecio, txtCodigo, 0)
    End Sub

    'Funcion utilizada para llenar los grid
    Private Sub fnLlenarGrid()
        'INVENTARIOS
        Dim tp = (From x In ctx.tblTipoInventarios Where x.empresa = mdlPublicVars.idEmpresa _
                  Select Agregar = True, Codigo = x.idTipoinventario, Nombre = x.nombre)

        Me.grdInventario.Rows.Clear()
        Dim v
        For Each v In tp
            Me.grdInventario.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'MODELOS
        Dim modelos = (From x In ctx.tblArticuloModeloVehiculoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdModelo.Rows.Clear()
        For Each v In modelos
            Me.grdModelo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'TIPO VEHICULOS
        Dim tipoVehiculos = (From x In ctx.tblArticuloTipoVehiculoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.Rows.Clear()
        For Each v In tipoVehiculos
            Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'MARCA
        Dim marca = (From x In ctx.tblArticuloMarcaRepuestoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdMarca.Rows.Clear()
        For Each v In marca
            Me.grdMarca.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'IMPORTANCIA
        Dim importancia = (From x In ctx.tblArticuloImportancias _
                        Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdImportancia.Rows.Clear()
        For Each v In importancia
            Me.grdImportancia.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'TIPO REPUESTO
        Dim tipoRepuesto = (From x In ctx.tblArticuloRepuestoes _
                        Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoRepuesto.Rows.Clear()
        For Each v In tipoRepuesto
            Me.grdTipoRepuesto.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next

        'TIPO PRECIO
        Dim tipoPrecio = (From x In ctx.tblArticuloTipoPrecios Where x.bitEspecial = False _
                        Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoPrecio.Rows.Clear()
        For Each v In tipoPrecio
            Me.grdTipoPrecio.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next
    End Sub

    'Funcion utilizada para el manejo del checkbutton "Todos"
    Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
        'Recorremos el grid
        Dim i
        For i = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells("chmAgregar").Value = estado
        Next
    End Sub

    'Boton FILTRAR
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnFiltrar()
    End Sub

    'Filtrrar
    Public Sub fnFiltrar()
        Dim inventario As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdInventario, 1, 0)
        Dim modelo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelo, 1, 0)
        Dim tipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
        Dim marca As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
        Dim importancia As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdImportancia, 1, 0)
        Dim tipoRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoRepuesto, 1, 0)
        Dim tipoPrecio As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoPrecio, 1, 0)

        frmPriceLista.grdDatos.DataSource = ctx.sp_Filtro_lista_price_articulos(mdlPublicVars.idEmpresa, mdlPublicVars.General_idAlmacenPrincipal, inventario, _
                                                  modelo, tipoVehiculo, marca, tipoRepuesto, importancia, tipoPrecio, If(chkBuscaCodigo.Checked, 1, 0), txtCodigo.Text, _
                                                   If(chkBuscarNombre.Checked, 1, 0), txtNombre.Text)
        frmPriceLista.filtroActivo = True
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Hide()
    End Sub

    Private Sub chkTipoInventario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTipoInventario.CheckedChanged
        fnActivaTodos(chkTipoInventario.Checked, grdInventario)
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        fnActivaTodos(chkTodosModelo.Checked, grdModelo)
    End Sub

    Private Sub chkTodosTipoVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoVehiculo.CheckedChanged
        fnActivaTodos(chkTodosTipoVehiculo.Checked, grdTipoVehiculo)
    End Sub

    Private Sub chkTodosMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarca.CheckedChanged
        fnActivaTodos(chkTodosMarca.Checked, grdMarca)
    End Sub

    Private Sub chkTodosImportancia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosImportancia.CheckedChanged
        fnActivaTodos(chkTodosImportancia.Checked, grdImportancia)
    End Sub

    Private Sub chkTodosTipoRepuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoRepuesto.CheckedChanged
        fnActivaTodos(chkTodosTipoRepuesto.Checked, grdTipoRepuesto)
    End Sub

    Private Sub chkTodosTipoPrecio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoPrecio.CheckedChanged
        fnActivaTodos(chkTodosTipoPrecio.Checked, grdTipoPrecio)
    End Sub

    Private Sub grdInventario_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdInventario.ValueChanged
        mdlPublicVars.fngrd_contador(grdInventario, lblRecuentoInventario, txtCodigo, 0)
    End Sub

    Private Sub grdMarca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarca.ValueChanged
        mdlPublicVars.fngrd_contador(grdMarca, lblRecuentoMarcaRepuesto, txtCodigo, 0)
    End Sub

    Private Sub grdModelo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdModelo.ValueChanged
        mdlPublicVars.fngrd_contador(grdModelo, lblRecuentoModelo, txtCodigo, 0)
    End Sub

    Private Sub grdImportancia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdImportancia.ValueChanged
        mdlPublicVars.fngrd_contador(grdImportancia, lblRecuentoImportancia, txtCodigo, 0)
    End Sub

    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo, txtCodigo, 0)
    End Sub

    Private Sub grdTipoRepuesto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoRepuesto.ValueChanged
        mdlPublicVars.fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto, txtCodigo, 0)
    End Sub

    Private Sub grdTipoPrecio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoPrecio.ValueChanged
        mdlPublicVars.fngrd_contador(grdTipoPrecio, lblRecuentoTipoPrecio, txtCodigo, 0)
    End Sub

End Class