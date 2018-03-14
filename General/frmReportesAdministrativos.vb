Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmReportesAdministrativos

    Private Sub frmReporteEstadisticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.comboActivarFiltro(Me.cmbVendedor)
            mdlPublicVars.comboActivarFiltro(Me.cmbMarcaRepuesto)
            mdlPublicVars.comboActivarFiltro(Me.cmbTipoVehiculo)
            mdlPublicVars.comboActivarFiltro(Me.cmbProducto)
            mdlPublicVars.comboActivarFiltro(Me.cmbCliente)
            Me.rbtUtilidad.Checked = True
            fnLlenarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombos()
        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim vendedor = (From x In conexion.tblUsuarios Select Codigo = 0, Nombre = "<-Todos->").Union(From u In conexion.tblUsuarios, v In conexion.tblVendedors Where u.idVendedor = v.idVendedor And u.bloqueado = False And u.idGrupo = 4 Select Codigo = u.idUsuario, Nombre = v.nombre)

                With cmbVendedor
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = vendedor
                End With

                Dim repuesto = (From x In conexion.tblArticuloMarcaRepuestoes Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblArticuloMarcaRepuestoes Select Codigo = x.codigo, Nombre = x.nombre)

                With cmbMarcaRepuesto
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = repuesto
                End With

                Dim vehiculo = (From x In conexion.tblArticuloTipoVehiculoes Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblArticuloTipoVehiculoes Select Codigo = x.codigo, Nombre = x.nombre)

                With cmbTipoVehiculo
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = vehiculo
                End With

                Dim articulo = (From x In conexion.tblArticuloes Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblArticuloes Select Codigo = x.idArticulo, Nombre = x.nombre1)

                With cmbProducto
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = articulo
                End With

                Dim cliente = (From x In conexion.tblClientes Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblClientes Where x.habillitado = True Select Codigo = x.idCliente, Nombre = x.Nombre1)

                With cmbCliente
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = cliente
                End With

                Dim pais = (From x In conexion.tblpais Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblpais Select Codigo = x.idpais, Nombre = x.nombre)

                With Me.cmbPais
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = pais
                End With

                Dim tipoprecio = (From x In conexion.tblArticuloTipoPrecios Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblArticuloTipoPrecios Select Codigo = x.codigo, Nombre = x.nombre)

                With Me.cmbTipoPrecio
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = tipoprecio
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtRotaciones_CheckedChanged(sender As Object, e As EventArgs) Handles rbtUtilidad.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCargarCombos()
        Try
            If Me.rbtUtilidad.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = True
                Me.cmbCliente.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.txtTop.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasCliente.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasLinea.Checked = True Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasProducto.Checked = True Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtSurtir.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtClientesVencer.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtProductosNuevos.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtTipoPrecios.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtFrecuencias.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtSurtirVentas.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtPromedioCompras.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtPedirNuevos.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtParticipacionMercado.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtImpactoPS.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtClientes23WH.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasGeneral.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtPagosGeneral.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentaLineaPais.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.pbInformacion.Enabled = False
                Me.txtTop.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtVentasCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVentasCliente.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtVentasLinea_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVentasLinea.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            Dim fechainicio As Date
            Dim fechafin As Date

            Dim r As New clsReporte

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                conexion.CommandTimeout = 10000

                fechainicio = Me.dtpDesde.Value.ToShortDateString + " 00:00:00.000"
                fechafin = Me.dtpHasta.Value.ToShortDateString + " 23:59:59.999"

                If Me.rbtUtilidad.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteUtilidades(fechainicio, fechafin, CInt(Me.cmbTipoVehiculo.SelectedValue), CInt(Me.cmbMarcaRepuesto.SelectedValue)))
                    r.reporte = "rptUtilidades.rpt"
                    ''r.nombreParametro = "filtro"
                    ''r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text) + " | Tipo Vehiculo: " + CStr(Me.cmbTipoVehiculo.Text)
                ElseIf Me.rbtVentasProducto.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteVentasVendedorArticulo(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue)))
                    r.reporte = "rptVentasVendedorProducto.rpt"
                ElseIf Me.rbtVentasLinea.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteVentasVendedorLinea(fechainicio, fechafin, CInt(Me.cmbMarcaRepuesto.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue), CInt(Me.cmbVendedor.SelectedValue)))
                    r.reporte = "rptReporteVentasVendedorLinea.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtVentasCliente.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteVentasVendedorClientes(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbPais.SelectedValue), CInt(Me.cmbDepartamento.SelectedValue), CInt(Me.cmbMunicipio.SelectedValue)))
                    r.reporte = "rptVentasVendedorCliente.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtSurtir.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReportePendientesSurtir(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    r.reporte = "rptPendienteSurtirVendedorCliente.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtClientesVencer.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteCarteraVencidaClientesVendedor(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue)))
                    r.reporte = "rptReporteCarteraVencidaVendedor.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtProductosNuevos.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteArticulosNuevosVendedor(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    r.reporte = "rptReporteProductosNuevosVendedor.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtTipoPrecios.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteProductosOfertasVendedor(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbTipoPrecio.SelectedValue)))
                    r.reporte = "rptReporteProductosVendedorPrecios.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtSurtirVentas.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReportePendientesSurtirVentas(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    r.reporte = "rptPendienteSurtirVentasVendedorCliente.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtFrecuencias.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteFrecuenciaArticulos(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue)))
                    r.reporte = "rptFrecuencia.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtPromedioCompras.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReportePromedioArticulos(fechainicio, fechafin, CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue)))
                    r.reporte = "rptPromedioCompra.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Producto: " + CStr(Me.cmbProducto.Text)
                ElseIf Me.rbtPedirNuevos.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReportePendientesPedirNuevos(fechainicio, fechafin, CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbVendedor.SelectedValue)))
                    r.reporte = "rptPendientesPedirNuevos.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtParticipacionMercado.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteParticipacionMercado(fechainicio, fechafin, CInt(Me.cmbDepartamento.SelectedValue)))
                    r.reporte = "rptParticipacionMercado.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Departamento: " + CStr(Me.cmbDepartamento.Text)
                ElseIf Me.rbtImpactoPS.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ImpactoPendientesSurtir(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue)))
                    r.reporte = "rptImpactoPS.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtClientes23WH.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteVentasVendedorClientes23Ruedas(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbPais.SelectedValue), CInt(Me.cmbDepartamento.SelectedValue), CInt(Me.cmbMunicipio.SelectedValue)))
                    r.reporte = "rptVentasVendedorCliente23WH.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                ElseIf Me.rbtVentasGeneral.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteVentasGeneral(fechainicio, fechafin))
                    r.reporte = "rptReporteVentasGeneral.rpt"
                ElseIf Me.rbtPagosGeneral.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReportePagosGeneral(fechainicio, fechafin))
                    r.reporte = "rptReportePagosGeneral.rpt"
                ElseIf Me.rbtVentaLineaPais.Checked Then
                    r.tabla = EntitiToDataTable(conexion.sp_ReporteVentasVendedorLineaMeses(fechainicio, fechafin, CInt(Me.cmbMarcaRepuesto.SelectedValue), CInt(cmbTipoVehiculo.SelectedValue), CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbPais.SelectedValue)))
                    r.reporte = "rptReporteVentasLineaMeses.rpt"
                    r.nombreParametro = "filtro"
                    r.parametro = "Vendedor: " + CStr(Me.cmbVendedor.Text)
                Else
                    RadMessageBox.Show("Seleccione una opcion valida!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End If

                r.verReporte()

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles lblTop.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pbInformacion.Click
        Dim alerta As New bl_Alertas

        alerta.contenido = "El Top 0 muestra todos los productos." & vbCrLf & "Un top mayor a 0 hace el filtro."
        alerta.fnErrorContenido()
    End Sub

    Private Sub cmbDirDepartamento_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedValueChanged
        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim dep As Integer = CType(cmbDepartamento.SelectedValue, Integer)
                Dim muni = (From x In conexion.tblMunicipios Select Codigo = 0, Nombre = "<-Todos->").Union(From s In conexion.tblMunicipios Where s.iddepartamento = dep Select Codigo = s.idmunicipio, Nombre = s.nombre Order By Nombre Ascending)

                With Me.cmbMunicipio
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = muni
                End With
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPais_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedValueChanged
        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim pais As Integer = CType(cmbPais.SelectedValue, Integer)
                Dim depto = (From x In conexion.tbldepartamentoes Select Codigo = 0, Nombre = "<-Todos->").Union(From s In conexion.tbldepartamentoes Where s.tblregion.tblpai.idpais = pais Select Codigo = s.iddepartamento, Nombre = s.nombre Order By Nombre Ascending)

                With Me.cmbDepartamento
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = depto
                End With
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
