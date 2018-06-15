Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
''Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq
Imports System.Data

Public Class frmReportesDinamicos

    Dim tbl As clsDevuelveTabla
    Dim consulta As String
    Dim vfechafin As Boolean = False
    Dim vfechainicio As Boolean = False
    Dim vhabilitado As Boolean = False
    Dim bitsp As Boolean = False

    Private Sub frmConsultasDinamicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombos()
        fnconfiguracion()
        rbtRotaciones.Checked = True
        fnActivarFiltros()
    End Sub

    Private Sub fnActivarFiltros()
        Try
            mdlPublicVars.comboActivarFiltro(cmbTipoVehiculo)
            mdlPublicVars.comboActivarFiltro(cmbMarcaRepuesto)
            mdlPublicVars.comboActivarFiltro(cmbVendedor)
            mdlPublicVars.comboActivarFiltro(cmbCliente)
            mdlPublicVars.comboActivarFiltro(cmbProducto)
            mdlPublicVars.comboActivarFiltro(cmbClienteCategoria)
            mdlPublicVars.comboActivarFiltro(cmbPais)
            mdlPublicVars.comboActivarFiltro(cmbDepartamento)
            mdlPublicVars.comboActivarFiltro(cmbMunicipio)
            mdlPublicVars.comboActivarFiltro(cmbTipoPrecio)
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

                Dim cliente = (From x In conexion.tblClientes Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblClientes Where x.habillitado = True Select Codigo = x.idCliente, Nombre = (x.Negocio + " (" + x.Nombre1 + ")"))

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

                Dim categorias = (From x In conexion.tblClienteCategorias Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblClienteCategorias Select Codigo = x.idcategoria, Nombre = x.descripcion)

                With Me.cmbClienteCategoria
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = categorias
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCargarCombos()
        Try
            If Me.rbtRotaciones.Checked = True Then
                Me.cmbVendedor.Enabled = True
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbProducto.Enabled = True
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasCliente.Checked = True Then
                Me.cmbVendedor.Enabled = True
                Me.cmbCliente.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = True
                Me.cmbDepartamento.Enabled = True
                Me.cmbMunicipio.Enabled = True
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasLinea.Checked = True Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = True
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasProducto.Checked = True Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtSurtir.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = True
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtClientesVencer.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtProductosNuevos.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = True
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtTipoPrecios.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = True
            ElseIf Me.rbtFrecuencias.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbCliente.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtSurtirVentas.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = True
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtPromedioCompras.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbCliente.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtPedirNuevos.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = True
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
                Me.cmbPais.Enabled = True
                Me.cmbDepartamento.Enabled = True
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtImpactoPS.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtClientes23WH.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbCliente.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = True
                Me.cmbDepartamento.Enabled = True
                Me.cmbMunicipio.Enabled = True
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentasGeneral.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
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
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtVentaLineaPais.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = True
                Me.cmbTipoVehiculo.Enabled = True
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = True
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
            ElseIf Me.rbtClientesPrecios.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = False
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = True
                Me.cmbDepartamento.Enabled = True
                Me.cmbMunicipio.Enabled = True
                Me.cmbTipoPrecio.Enabled = False
                Me.cmbClienteCategoria.Enabled = False
            ElseIf Me.rbtClientesFacturas.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
                Me.cmbClienteCategoria.Enabled = False
            ElseIf Me.rbtCreditoClientes.Checked Then
                Me.cmbVendedor.Enabled = False
                Me.cmbCliente.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
                Me.cmbClienteCategoria.Enabled = False
            ElseIf Me.rbtFacturaPagos.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbCliente.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
                Me.cmbClienteCategoria.Enabled = False
            ElseIf Me.rbtSurtirI.Checked Then
                Me.cmbVendedor.Enabled = True
                Me.cmbCliente.Enabled = True
                Me.cmbMarcaRepuesto.Enabled = False
                Me.cmbTipoVehiculo.Enabled = False
                Me.cmbProducto.Enabled = False
                Me.cmbPais.Enabled = False
                Me.cmbDepartamento.Enabled = False
                Me.cmbMunicipio.Enabled = False
                Me.cmbTipoPrecio.Enabled = False
                Me.cmbClienteCategoria.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        Try
            Me.grdListado.DataSource = Nothing

            Dim r As SqlClient.SqlDataReader
            Dim dt As New DataTable
            Dim tabla As DataTable
            Dim adp As New SqlClient.SqlDataAdapter
            Dim sqlcomando As System.Data.SqlClient.SqlCommand
            Dim IdtipoIventario As Integer
            ''Dim SqlConexion As New System.Data.SqlClient.SqlConnection

            Try

                Me.grdListado.Rows.Clear()
                Me.grdListado.Columns.Clear()
                Me.Progreso.Minimum = 0
                Me.Progreso.Maximum = 100
                Me.Progreso.Value1 = 0
                Me.Progreso.Text = "0 %"
                Application.DoEvents()

                Dim fechainicio As Date = dtpDesde.Value.ToShortDateString + " 00:00:00.000"
                Dim fechafin As Date = dtpHasta.Value.ToShortDateString + " 23:59:59.999"

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                    conexion.CommandTimeout = 10000

                    If Me.rbtRotaciones.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteRotacionArticulos(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue)))
                    ElseIf Me.rbtVentasProducto.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteVentasVendedorArticulo(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue)))
                    ElseIf Me.rbtVentasLinea.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteVentasVendedorLinea(fechainicio, fechafin, CInt(Me.cmbMarcaRepuesto.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue), CInt(Me.cmbVendedor.SelectedValue)))
                    ElseIf Me.rbtVentasCliente.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteVentasVendedorClientes(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbPais.SelectedValue), CInt(Me.cmbDepartamento.SelectedValue), CInt(Me.cmbMunicipio.SelectedValue)))
                    ElseIf Me.rbtSurtir.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReportePendientesSurtir(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    ElseIf Me.rbtClientesVencer.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteCarteraVencidaClientesVendedor(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue)))
                    ElseIf Me.rbtProductosNuevos.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteArticulosNuevosVendedor(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    ElseIf Me.rbtTipoPrecios.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteProductosOfertasVendedor(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbTipoPrecio.SelectedValue)))
                    ElseIf Me.rbtSurtirVentas.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReportePendientesSurtirVentas(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    ElseIf Me.rbtFrecuencias.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteFrecuenciaArticulos(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue)))
                    ElseIf Me.rbtPromedioCompras.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReportePromedioArticulos(fechainicio, fechafin, CInt(Me.cmbProducto.SelectedValue), CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbTipoVehiculo.SelectedValue)))
                    ElseIf Me.rbtPedirNuevos.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReportePendientesPedirNuevos(fechainicio, fechafin, CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbVendedor.SelectedValue)))
                    ElseIf Me.rbtParticipacionMercado.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteParticipacionMercado(fechainicio, fechafin, CInt(Me.cmbDepartamento.SelectedValue)))
                    ElseIf Me.rbtImpactoPS.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ImpactoPendientesSurtir(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue)))
                    ElseIf Me.rbtClientes23WH.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteVentasVendedorClientes23Ruedas(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbPais.SelectedValue), CInt(Me.cmbDepartamento.SelectedValue), CInt(Me.cmbMunicipio.SelectedValue)))
                    ElseIf Me.rbtVentasGeneral.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteVentasGeneral(fechainicio, fechafin))
                    ElseIf Me.rbtPagosGeneral.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReportePagosGeneral(fechainicio, fechafin))
                    ElseIf Me.rbtVentaLineaPais.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteVentasVendedorLineaMeses(fechainicio, fechafin, CInt(Me.cmbMarcaRepuesto.SelectedValue), CInt(cmbTipoVehiculo.SelectedValue), CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbPais.SelectedValue)))
                    ElseIf Me.rbtClientesPrecios.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteClientesTipoPrecio(CInt(Me.cmbPais.SelectedValue), CInt(Me.cmbDepartamento.SelectedValue), CInt(Me.cmbMunicipio.SelectedValue)))
                    ElseIf Me.rbtClientesFacturas.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteClientesFacturas(CInt(Me.cmbCliente.SelectedValue)))
                    ElseIf Me.rbtCreditoClientes.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReporteCreditosClientes(CDate(Me.dtpHasta.Value)))
                    ElseIf Me.rbtFacturaPagos.Checked Then
                        dt = EntitiToDataTable(conexion.sp_FacturasPagos(CDate(Me.dtpDesde.Value), CDate(Me.dtpHasta.Value), CInt(Me.cmbCliente.SelectedValue), CInt(Me.cmbVendedor.SelectedValue)))
                    ElseIf Me.rbtSurtirI.Checked Then
                        dt = EntitiToDataTable(conexion.sp_ReportePendientesSurtirInventario(fechainicio, fechafin, CInt(Me.cmbVendedor.SelectedValue), CInt(Me.cmbCliente.SelectedValue)))
                    Else
                        RadMessageBox.Show("Seleccione una opcion valida!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Exit Sub
                    End If

                    conn.Close()
                End Using

            Catch ex As Exception

            End Try

            tabla = dt

            MostrarCarga(tabla)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnconfiguracion()
        Try
            Me.grdListado.AutoResizeColumns()
            Me.grdListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarCarga(ByVal tabla As DataTable)
        Try
            Dim IntFila As Integer = 0
            Dim IntStock As Integer = 0
            Dim IntFilas As Integer = 0
            Dim fila As Object()
            Dim columnas As Integer = 0

            Progreso.Minimum = 0
            Progreso.Maximum = IIf(tabla.Rows.Count = 1, 1, tabla.Rows.Count)

            columnas = tabla.Columns.Count - 1

            ''fnGridBlanco()

            For c As Integer = 0 To tabla.Columns.Count - 1
                Dim Col As New DataGridViewTextBoxColumn

                Col.HeaderText = tabla.Columns(c).ColumnName
                Col.Name = tabla.Columns(c).ColumnName

                Me.grdListado.Columns.Add(Col)

            Next

            For i As Integer = 0 To tabla.Rows.Count - 1

                Progreso.Value1 = IIf(i = 0, 1, i)
                Progreso.Text = Convert.ToInt32((Progreso.Value1 * 100) / Progreso.Maximum) & " % "
                Application.DoEvents()

                If columnas = 0 Then
                    fila = {tabla.Rows(i).Item(0)}
                ElseIf columnas = 1 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1)}
                ElseIf columnas = 2 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2)}
                ElseIf columnas = 3 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3)}
                ElseIf columnas = 4 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4)}
                ElseIf columnas = 5 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5)}
                ElseIf columnas = 6 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6)}
                ElseIf columnas = 7 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7)}
                ElseIf columnas = 8 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8)}
                ElseIf columnas = 9 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9)}
                ElseIf columnas = 10 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10)}
                ElseIf columnas = 11 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11)}
                ElseIf columnas = 12 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12)}
                ElseIf columnas = 13 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13)}
                ElseIf columnas = 14 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14)}
                ElseIf columnas = 15 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15)}
                ElseIf columnas = 16 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16)}
                ElseIf columnas = 17 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17)}
                ElseIf columnas = 18 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18)}
                ElseIf columnas = 19 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18), tabla.Rows(i).Item(19)}
                ElseIf columnas = 20 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18), tabla.Rows(i).Item(19), tabla.Rows(i).Item(20)}
                ElseIf columnas = 21 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18), tabla.Rows(i).Item(19), tabla.Rows(i).Item(20), tabla.Rows(i).Item(21)}
                ElseIf columnas = 22 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18), tabla.Rows(i).Item(19), tabla.Rows(i).Item(20), tabla.Rows(i).Item(21), tabla.Rows(i).Item(22)}
                ElseIf columnas = 23 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18), tabla.Rows(i).Item(19), tabla.Rows(i).Item(20), tabla.Rows(i).Item(21), tabla.Rows(i).Item(22), tabla.Rows(i).Item(23)}
                ElseIf columnas = 24 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15), tabla.Rows(i).Item(16), tabla.Rows(i).Item(17), tabla.Rows(i).Item(18), tabla.Rows(i).Item(19), tabla.Rows(i).Item(20), tabla.Rows(i).Item(21), tabla.Rows(i).Item(22), tabla.Rows(i).Item(23), tabla.Rows(i).Item(24)}
                End If

                Me.grdListado.Rows.Add(fila)

                IntFila += 1

            Next

            fila = {"Contador", CStr(IntFila)}

            Me.grdListado.Rows.Add(fila)

            Me.grdListado.Rows(IntFila).DefaultCellStyle.ForeColor = Color.Blue
            Me.grdListado.Rows(IntFila).DefaultCellStyle.Font = New Font("Footlight MT Light ", 14, FontStyle.Regular)


            Progreso.Value1 = Progreso.Maximum
            Progreso.Text = "100 %"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCopiarFilas_Click(sender As Object, e As EventArgs) Handles btnCopiarFilas.Click
        Try
            CopiarGrid(grdListado)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CopiarGrid(grd As DataGridView)
        Try
            Me.grdListado.SelectAll()

            Dim dataObj As DataObject

            grd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dataObj = grd.GetClipboardContent()
            If Me.grdListado.Rows.Count - 1 > 0 Then
                Clipboard.SetDataObject(dataObj)
            End If

            Me.grdListado.ClearSelection()
        Catch ex As Exception

        End Try
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

#Region "Checked"
    Private Sub rbtRotaciones_CheckedChanged(sender As Object, e As EventArgs) Handles rbtRotaciones.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub rbtSurtir_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSurtir.CheckedChanged
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

    Private Sub rbtVentasCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVentasCliente.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtVentasProducto_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVentasProducto.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtClientesVencer_CheckedChanged(sender As Object, e As EventArgs) Handles rbtClientesVencer.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtProductosNuevos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtProductosNuevos.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtTipoPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles rbtTipoPrecios.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtSurtirVentas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtSurtirVentas.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtFrecuencias_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFrecuencias.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtPromedioCompras_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPromedioCompras.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtPedirNuevos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPedirNuevos.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtParticipacionMercado_CheckedChanged(sender As Object, e As EventArgs) Handles rbtParticipacionMercado.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtImpactoPS_CheckedChanged(sender As Object, e As EventArgs) Handles rbtImpactoPS.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtClientes23WH_CheckedChanged(sender As Object, e As EventArgs) Handles rbtClientes23WH.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtVentasGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVentasGeneral.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtPagosGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rbtPagosGeneral.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtVentaLineaPais_CheckedChanged(sender As Object, e As EventArgs) Handles rbtVentaLineaPais.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles rbtClientesPrecios.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rbtClientesFacturas.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCreditoClientes.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFacturaPagos.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs)
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class
