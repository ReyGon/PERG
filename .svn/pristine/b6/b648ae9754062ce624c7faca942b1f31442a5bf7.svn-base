Imports System.Linq
Imports Telerik.WinControls.UI

Public Class frmReporteVentasFiltro

#Region "LOAD"
    Private Sub frmReporteVentasFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdArticulo)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdClientes)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDepartamento)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdMarcaRepuesto)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdModelo)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdMunicipio)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdRegion)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoNegocio)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdVendedores)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdAnho)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdMes)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDia)

        Try
            fnLlenarGrid()

            fngrd_contador(grdArticulo, lblRecuentoArticulo)
            fngrd_contador(grdClientes, lblRecuentoClientes)
            fngrd_contador(grdDepartamento, lblRecuentoDepartamentos)
            fngrd_contador(grdMarcaRepuesto, lblRecuentoMarcaRepuesto)
            fngrd_contador(grdModelo, lblRecuentoModelo)
            fngrd_contador(grdMunicipio, lblRecuentoMunicipio)
            fngrd_contador(grdRegion, lblRecuentoRegion)
            fngrd_contador(grdTipoNegocio, lblRecuentoTipoNegocio)
            fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
            fngrd_contador(grdVendedores, lblRecuentoVendedores)
            fngrd_contador(grdAnho, lblRecuentoAnho)
            fngrd_contador(grdMes, lblRecuentoMes)
            fngrd_contador(grdDia, lblRecuentoDia)
            rbnAnho.Checked = True
            chkPorFecha.Checked = True
            chkTodosArticulo.Checked = True
            chkTodosClientes.Checked = True
            chkTodosDepartamento.Checked = True
            chkTodosMarcaRepuesto.Checked = True
            chkTodosModelo.Checked = True
            chkTodosMunicipios.Checked = True
            chkTodosRegion.Checked = True
            chkTodosTipoNegocio.Checked = True
            chkTodosVendedores.Checked = True
        Catch ex As Exception
        End Try


    End Sub
#End Region

#Region "Funciones"

    'Funcion utilizada para llenar los grids
    Private Sub fnLlenarGrid()
        Try
            'Vendedores
            Dim vendedores = (From x In ctx.tblVendedors Where x.empresa = mdlPublicVars.idEmpresa _
                              Select Agregar = CType(True, Boolean), Codigo = x.idVendedor, Nombre = x.nombre)
            Me.grdVendedores.DataSource = EntitiToDataTable(vendedores)
        Catch ex As Exception

        End Try
        

        '-----------UBICACION ----------
        Try
            'Region
            Dim region = (From x In ctx.tblregions _
                              Select Agregar = CType(True, Boolean), Codigo = x.idregion, Nombre = x.nombre)

            Me.grdRegion.DataSource = EntitiToDataTable(region)
        Catch ex As Exception
        End Try
        


        'Departamentos
        Try
            Dim departamentos = (From x In ctx.tbldepartamentoes _
                              Select Agregar = CType(True, Boolean), Codigo = x.iddepartamento, Nombre = x.nombre)

            Me.grdDepartamento.DataSource = EntitiToDataTable(departamentos)
        Catch ex As Exception
        End Try

        'Municipios
        Try
            Dim municipios = (From x In ctx.tblMunicipios _
                          Select Agregar = CType(True, Boolean), Codigo = x.idmunicipio, Nombre = x.nombre)

            Me.grdMunicipio.DataSource = EntitiToDataTable(municipios)
        Catch ex As Exception
        End Try
        
        '-----------UBICACION ----------
        Try

        Catch ex As Exception

        End Try

        '-----------CLIENTES------------
        'Tipo de Negocio
        Try
            Dim tipoNegocio = (From x In ctx.tblClienteTipoNegocios _
                          Select Agregar = CType(True, Boolean), Codigo = x.idTipoNegocio, Nombre = x.nombre)
            Me.grdTipoNegocio.DataSource = EntitiToDataTable(tipoNegocio)
        Catch ex As Exception
        End Try
        


        'Clasificacion
        Try
            Dim clasificacion = (From x In ctx.tblArticuloes _
                          Select Agregar = CType(True, Boolean), Codigo = x.idArticulo, Nombre = x.nombre1)

            Me.grdArticulo.DataSource = EntitiToDataTable(clasificacion)
        Catch ex As Exception
        End Try
        


        'Clientes
        Try
            Dim Clientes = (From x In ctx.tblClientes _
                          Select Agregar = CType(True, Boolean), Codigo = x.idCliente, Nombre = x.Negocio)
            Me.grdClientes.DataSource = EntitiToDataTable(Clientes)

        Catch ex As Exception
        End Try
        
        '-----------CLIENTES------------

        '-----------INVENTARIO----------
        'Marca
        Dim marca = (From x In ctx.tblArticuloMarcaRepuestoes _
                          Select Agregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdMarcaRepuesto.DataSource = EntitiToDataTable(marca)

        'Tipo Vehiculo
        Dim tipoVehiculo = (From x In ctx.tblArticuloTipoVehiculoes _
                          Select Agregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.DataSource = EntitiToDataTable(tipoVehiculo)


        'Modelo
        Dim modelo = (From x In ctx.tblArticuloModeloVehiculoes _
                          Select Agregar = CType(True, Boolean), Codigo = x.codigo, Nombre = x.nombre)

        Me.grdModelo.DataSource = EntitiToDataTable(modelo)

        '-----------INVENTARIO----------

        'Año
        Dim anho = (From x In ctx.tblFacturas _
                    Group By An = CType(x.Fecha, Date).Year _
                    Into Group _
                    Select Agregar = CType(True, Boolean), Codigo = 0, Nombre = An)
        Me.grdAnho.DataSource = EntitiToDataTable(anho)

        Me.grdAnho.Columns("Nombre").HeaderText = "Año"

        'Mes y dia
        For i As Integer = 1 To 31
            If (i < 13) Then
                grdMes.Rows.Add(True, 0, i)
            End If
            grdDia.Rows.Add(True, 0, i)
        Next

        fnConfiguracion(Me.grdArticulo)
        fnConfiguracion(Me.grdClientes)
        fnConfiguracion(Me.grdDepartamento)
        fnConfiguracion(Me.grdMarcaRepuesto)
        fnConfiguracion(Me.grdModelo)
        fnConfiguracion(Me.grdMunicipio)
        fnConfiguracion(Me.grdRegion)
        fnConfiguracion(Me.grdTipoNegocio)
        fnConfiguracion(Me.grdTipoVehiculo)
        fnConfiguracion(Me.grdVendedores)
        fnConfiguracion(Me.grdMes)
        fnConfiguracion(Me.grdDia)
        fnConfiguracion(Me.grdAnho)
    End Sub

    'Funcion utilizada cuando se realiza un cambio en el grid
    Private Sub fnCambiarFoco(ByVal grd As Telerik.WinControls.UI.RadGridView)
        If grd.Columns("Agregar").IsCurrent Then
            grd.Columns("Nombre").IsCurrent = True
            grd.Columns("Agregar").IsCurrent = True
        End If
    End Sub

    'Funcion utilizada para cuando cambian los valores en el grid de region
    Private Sub fnCambioRegion()
        Dim regiones As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdRegion, 1, 0)
        grdDepartamento.DataSource = EntitiToDataTable(ctx.sp_VentasDepartamentos(regiones))
        fnConfiguracion(grdDepartamento)
        fnCambioDepartamento(1)
    End Sub

    'Funcion utilizada para cuando cambian los valores en el grid de departamentos
    Private Sub fnCambioDepartamento(ByVal orden As Integer)
        Try
            Dim departamentos As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdDepartamento, 1, 0)
            grdMunicipio.DataSource = EntitiToDataTable(ctx.sp_VentasMunicipios(departamentos, orden))
            fnConfiguracion(grdMunicipio)
        Catch ex As Exception
        End Try
        
    End Sub

    'Funcion utilizada para cuando cambian los valores en el grdi de clasificacion y tipo de negocio
    Private Sub fnCambioTipoNegocioClasificacion()
        Try
            Dim tipoNegocio As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoNegocio, 1, 0)

            grdClientes.DataSource = EntitiToDataTable(ctx.sp_VentasClientes(tipoNegocio))
            fnConfiguracion(grdClientes)
        Catch ex As Exception

        End Try
        
    End Sub

    'Funcion utilizada para configurar un grid
    Private Sub fnConfiguracion(ByVal grd As Telerik.WinControls.UI.RadGridView)
        If grd.ColumnCount > 0 Then
            With grd
                .Columns("Codigo").IsVisible = False
                .Columns("Agregar").HeaderText = "Agregar"
                .Columns("Agregar").Width = 40
                .Columns("Nombre").ReadOnly = True
            End With
        End If
    End Sub

    'Funcion utilizada para contar el numero de registros seleccionados en un grid, y establecer el resultado en una LABEL
    Private Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label)
        Try
            Dim indice As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grd)

            Dim contador As Integer = 0
            Dim estado As Boolean
            For index As Integer = 0 To grd.Rows.Count - 1
                estado = grd.Rows(index).Cells("Agregar").Value
                If estado Then
                    contador = contador + 1
                End If
            Next
            lbl.Text = contador.ToString
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

    End Sub

    'Funcion utilizada para el manejo del checkbutton "Todos"
    Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells("Agregar").Value = estado
        Next
    End Sub

    'Funcion utilizada para obtener el numero de registros activos
    Private Function fngrd_activos(ByVal grd As Telerik.WinControls.UI.RadGridView) As Integer
        fngrd_activos = 0
        For Each fila As GridViewRowInfo In grd.Rows
            If fila.Cells("Agregar").Value Then
                fngrd_activos += 1
            End If
        Next
    End Function

    'Funcion utilizada para obtener el valor de los registros activos
    Private Function fngrd_valoresActivos(ByVal grd As Telerik.WinControls.UI.RadGridView) As String
        fngrd_valoresActivos = ""
        Dim contador As Integer = 0
        For Each fila As GridViewRowInfo In grd.Rows
            If fila.Cells("Agregar").Value Then
                If contador = 0 Then
                    fngrd_valoresActivos += fila.Cells("Nombre").Value
                Else
                    fngrd_valoresActivos += "," & fila.Cells("Nombre").Value
                End If
                contador += 1
            End If
        Next
    End Function

    'Funcion utilizada para devolver la descripcion de los filtros
    Private Function fnFiltroDescripcion() As String
        fnFiltroDescripcion = ""

        For Each ctl As Control In Me.Controls
            If tbl.tipoControl(ctl.Name).Equals("rgb") Then
                For Each ctlHijo As Control In ctl.Controls
                    If tbl.tipoControl(ctlHijo.Name).Equals("grd") Then
                        Dim grd As Telerik.WinControls.UI.RadGridView = TryCast(ctlHijo, Telerik.WinControls.UI.RadGridView)
                        Dim activos As Integer = fngrd_activos(grd)
                        If activos = grd.RowCount Then
                            fnFiltroDescripcion += grd.Text & "Todos" & vbCrLf
                        ElseIf activos < 5 Then
                            fnFiltroDescripcion += grd.Text & fngrd_valoresActivos(grd) & vbCrLf
                        Else
                            fnFiltroDescripcion += grd.Text & "Varios" & vbCrLf
                        End If
                    End If
                Next
            End If
        Next
    End Function

    'Funcion utilizada para obtener la description de filtro de un grid
    Private Function fnDescripcion(ByVal grd As Telerik.WinControls.UI.RadGridView) As String
        fnDescripcion = ""
        Dim activos As Integer = fngrd_activos(grd)
        If activos = grd.RowCount Then
            fnDescripcion += "Todos" & vbCrLf
        ElseIf activos < 5 Then
            fnDescripcion += fngrd_valoresActivos(grd) & vbCrLf
        Else
            fnDescripcion += "Varios" & vbCrLf
        End If
    End Function

#End Region

#Region "Eventos"
    'Cambio VENDEDOR
    Private Sub grdVendedores_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdVendedores.ValueChanged
        fnCambiarFoco(grdVendedores)
        fngrd_contador(grdVendedores, lblRecuentoVendedores)
    End Sub

    'Cambio REGION
    Private Sub grdRegion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRegion.ValueChanged
        Try
            fnCambiarFoco(grdRegion)
            fnCambioRegion()
            fngrd_contador(grdRegion, lblRecuentoRegion)
            fngrd_contador(grdDepartamento, lblRecuentoDepartamentos)
        Catch ex As Exception
        End Try
    End Sub

    'Cambio DEPARTAMENTO
    Private Sub grdDepartamento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDepartamento.ValueChanged
        Try
            fnCambiarFoco(grdDepartamento)
            fnCambioDepartamento(1)
            fngrd_contador(grdDepartamento, lblRecuentoDepartamentos)
            fngrd_contador(grdMunicipio, lblRecuentoMunicipio)
        Catch ex As Exception
        End Try
        
    End Sub

    'Cambio MUNICIPIO
    Private Sub grdMunicipio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMunicipio.ValueChanged
        Try
            fnCambiarFoco(grdMunicipio)
            fngrd_contador(grdMunicipio, lblRecuentoMunicipio)
        Catch ex As Exception
        End Try

    End Sub

    'Cambio TIPO DE NEGOCIO
    Private Sub grdTipoNegocio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoNegocio.ValueChanged
        Try
            fnCambiarFoco(grdTipoNegocio)
            fnCambioTipoNegocioClasificacion()
            fngrd_contador(grdTipoNegocio, lblRecuentoTipoNegocio)
        Catch ex As Exception
        End Try
        
    End Sub

    'Cambio CLASIFICACION
    Private Sub grdClasificacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdArticulo.ValueChanged
        fnCambiarFoco(grdArticulo)
        fngrd_contador(grdArticulo, lblRecuentoArticulo)
    End Sub

    'Cambio CLIENTES
    Private Sub grdClientes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdClientes.ValueChanged
        fnCambiarFoco(grdClientes)
        fngrd_contador(grdClientes, lblRecuentoClientes)
    End Sub

    'Cambio MARCA
    Private Sub grdMarca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarcaRepuesto.ValueChanged
        fnCambiarFoco(grdMarcaRepuesto)
        fngrd_contador(grdMarcaRepuesto, lblRecuentoMarcaRepuesto)
    End Sub

    'Cambio TIPO VEHICULO
    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        fnCambiarFoco(grdTipoVehiculo)
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    'Cambio MODELO
    Private Sub grdModelo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdModelo.ValueChanged
        fnCambiarFoco(grdModelo)
        fngrd_contador(grdModelo, lblRecuentoModelo)
    End Sub

    'Cuando se cierra el formulario
    Private Sub frmSalir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'FILTRAR
    Private Sub fnFiltrar() Handles Me.panel0
        Dim vendedores As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdVendedores, 1, 0)
        Dim municipio As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMunicipio, 1, 0)
        Dim tipoNegocio As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoNegocio, 1, 0)
        Dim articulo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdArticulo, 1, 0)
        Dim clientes As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdClientes, 1, 0)
        Dim marcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarcaRepuesto, 1, 0)
        Dim modeloRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelo, 1, 0)
        Dim tipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
        Dim anhos As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdAnho, 2, 0)
        Dim meses As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMes, 2, 0)
        Dim dias As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdDia, 2, 0)
        Dim desde As String = dtpDesde.Text
        Dim hasta As String = dtpHasta.Text & " 23:59:59"

        frmReporteVentas.datos = EntitiToDataTable(ctx.sp_VentasReporte(mdlPublicVars.idEmpresa, vendedores, municipio, clientes,
                                                                    tipoNegocio, articulo, marcaRepuesto, tipoVehiculo, modeloRepuesto,
                                                                    If(chkPorFecha.Checked, 1, 0), anhos, meses, dias,
                                                                    If(chkPorRango.Checked, 1, 0), desde, hasta))

        frmReporteVentas.grdDatos.DataSource = ctx.sp_VentasReporte(mdlPublicVars.idEmpresa, vendedores, municipio, clientes,
                                                                   tipoNegocio, articulo, marcaRepuesto, tipoVehiculo, modeloRepuesto,
                                                                   If(chkPorFecha.Checked, 1, 0), anhos, meses, dias,
                                                                   If(chkPorRango.Checked, 1, 0), desde, hasta)

        'Enviamos la descripcion de los filtros
        frmReporteVentas.lblAnho.Text = fnDescripcion(grdAnho)
        frmReporteVentas.lblArticulos.Text = fnDescripcion(grdArticulo)
        frmReporteVentas.lblClientes.Text = fnDescripcion(grdClientes)
        frmReporteVentas.lblDepartamento.Text = fnDescripcion(grdDepartamento)
        frmReporteVentas.lblDia.Text = fnDescripcion(grdDia)
        frmReporteVentas.lblMarcaRepuesto.Text = fnDescripcion(grdMarcaRepuesto)
        frmReporteVentas.lblMes.Text = fnDescripcion(grdMes)
        frmReporteVentas.lblModeloVehiculo.Text = fnDescripcion(grdModelo)
        frmReporteVentas.lblMunicipio.Text = fnDescripcion(grdMunicipio)
        frmReporteVentas.lblRegion.Text = fnDescripcion(grdRegion)
        frmReporteVentas.lblTipoNegocio.Text = fnDescripcion(grdTipoNegocio)
        frmReporteVentas.lblTipoVehiculo.Text = fnDescripcion(grdTipoVehiculo)
        frmReporteVentas.lblVendedor.Text = fnDescripcion(grdVendedores)
        frmReporteVentas.fnConfiguracion()
        Me.Hide()
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub chkPorFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPorFecha.CheckedChanged
        chkPorRango.Checked = Not chkPorFecha.Checked
    End Sub

    Private Sub chkPorRango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPorRango.CheckedChanged
        chkPorFecha.Checked = Not chkPorRango.Checked
    End Sub

    Private Sub grdAnho_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAnho.ValueChanged
        fnCambiarFoco(grdAnho)
        fngrd_contador(grdAnho, lblRecuentoAnho)
    End Sub

    Private Sub grdDia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDia.ValueChanged
        fnCambiarFoco(grdDia)
        fngrd_contador(grdDia, lblRecuentoDia)
    End Sub

    Private Sub grdMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMes.ValueChanged
        fnCambiarFoco(grdMes)
        fngrd_contador(grdMes, lblRecuentoMes)
    End Sub

    Private Sub chkTodosVendedores_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosVendedores.CheckedChanged
        fnActivaTodos(chkTodosVendedores.Checked, grdVendedores)
        fngrd_contador(grdVendedores, lblRecuentoVendedores)
    End Sub

    Private Sub chkTodosRegion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosRegion.CheckedChanged
        fnActivaTodos(chkTodosRegion.Checked, grdRegion)
        fngrd_contador(grdRegion, lblRecuentoRegion)
    End Sub

    Private Sub chkTodosDepartamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosDepartamento.CheckedChanged
        fnActivaTodos(chkTodosDepartamento.Checked, grdDepartamento)
        fngrd_contador(grdDepartamento, lblRecuentoDepartamentos)
    End Sub

    Private Sub chkTodosMunicipios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMunicipios.CheckedChanged
        fnCambioDepartamento(CInt(If(chkTodosMunicipios.Checked, 1, 0)))
        fngrd_contador(grdMunicipio, lblRecuentoMunicipio)
    End Sub

    Private Sub chkTodosTipoNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoNegocio.CheckedChanged
        fnActivaTodos(chkTodosTipoNegocio.Checked, grdTipoNegocio)
        fngrd_contador(grdTipoNegocio, lblRecuentoTipoNegocio)
    End Sub

    Private Sub chkTodosArticulo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosArticulo.CheckedChanged
        'Clasificacion
        Dim articulos = (From x In ctx.tblArticuloes _
                          Select Agregar = CType(chkTodosArticulo.Checked, Boolean), Codigo = x.idArticulo, Nombre = x.nombre1)
        Me.grdArticulo.DataSource = EntitiToDataTable(articulos)
        fngrd_contador(grdArticulo, lblRecuentoArticulo)
    End Sub

    Private Sub chkTodosClientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosClientes.CheckedChanged
        fnActivaTodos(chkTodosClientes.Checked, grdClientes)
        fngrd_contador(grdClientes, lblRecuentoClientes)
    End Sub

    Private Sub chkTodosMarcaRepuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarcaRepuesto.CheckedChanged
        fnActivaTodos(chkTodosMarcaRepuesto.Checked, grdMarcaRepuesto)
        fngrd_contador(grdMarcaRepuesto, lblRecuentoMarcaRepuesto)
    End Sub

    Private Sub chkTiposVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTiposVehiculo.CheckedChanged
        fnActivaTodos(chkTiposVehiculo.Checked, grdTipoVehiculo)
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        fnActivaTodos(chkTodosModelo.Checked, grdModelo)
        fngrd_contador(grdModelo, lblRecuentoModelo)
    End Sub
#End Region

End Class
