Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmSalidas
    Dim dt As New clsDevuelveTabla
    Dim grdlistado As New DataGridView

    Public codigoSalida As Integer = 0
    Private codigoSalidaAFacturar As Integer

    Private _bitEditarBodega As Boolean
    Private _bitEditarSalida As Boolean
    Private _bitFactura As Boolean
    Private _bitSugerirDespacho As Boolean
    Private _bitSugerirReserva As Boolean
    Private _codFact As Integer
    Private _codigo As Integer
    Private _Clave As Boolean

    Private _tblGuias As New DataTable

    Public inventario As Integer
    Private verificarexistencia As Boolean = False

    Dim valida As New bl_Pedidos
    Private permiso As New clsPermisoUsuario

    Public Property tblGuias As DataTable
        Get
            tblGuias = _tblGuias
        End Get
        Set(ByVal value As DataTable)
            _tblGuias = value
        End Set
    End Property

    Public Property Clave As Boolean
        Get
            Clave = _Clave
        End Get
        Set(value As Boolean)
            _Clave = value
        End Set
    End Property

    Private _venta As Integer
    Public Property venta As Integer
        Get
            venta = _venta
        End Get
        Set(ByVal value As Integer)
            _venta = value
        End Set
    End Property

    Public Property bitEditarBodega() As Boolean
        Get
            bitEditarBodega = _bitEditarBodega
        End Get
        Set(ByVal value As Boolean)
            _bitEditarBodega = value
        End Set
    End Property

    Public Property bitEditarSalida() As Boolean
        Get
            bitEditarSalida = _bitEditarSalida
        End Get
        Set(ByVal value As Boolean)
            _bitEditarSalida = value
        End Set
    End Property

    Public Property bitSugerirDespacho() As Boolean
        Get
            bitSugerirDespacho = _bitSugerirDespacho
        End Get
        Set(ByVal value As Boolean)
            _bitSugerirDespacho = value
        End Set
    End Property

    Public Property bitSugerirReserva() As Boolean
        Get
            bitSugerirReserva = _bitSugerirReserva
        End Get
        Set(ByVal value As Boolean)
            _bitSugerirReserva = value
        End Set
    End Property

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property


    Public Property bitFactura() As Boolean
        Get
            bitFactura = _bitFactura
        End Get
        Set(ByVal value As Boolean)
            _bitFactura = value
        End Set
    End Property

    Public Property codFact() As Integer
        Get
            codFact = _codFact
        End Get
        Set(ByVal value As Integer)
            _codFact = value
        End Set
    End Property

    Public esventa As Boolean

    Private Sub frmSalidas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.superSearchNombreAlterno = ""
        mdlPublicVars.superSearchDireccionAlterno = ""
    End Sub

    Private Sub frmSalidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If mdlPublicVars.PuntoVentaPequeno_Activado Then
            Me.lbl3Despachar.Text = "Facturar"
        End If

        Clave = False

        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        mdlPublicVars.fnGrid_iconos(grdProductos)
        mdlPublicVars.comboActivarFiltroLista(cmbInventario)
        mdlPublicVars.comboActivarFiltroLista(cmbBodega)
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        mdlPublicVars.comboActivarFiltroLista(cmbDirEnvios)
        inventario = mdlPublicVars.General_idTipoInventario
        fnNuevo()
        fnIndicadores()
        ''fnVerificaLimiteCredito()

        Me.grdProductos.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        grdProductos.CloseEditorWhenValidationFails = True
        grdProductos.StandardTab = False

        'Agragamos las columnas a la tabla temporal
        tblGuias.Columns.Add("codigo")
        tblGuias.Columns.Add("numero")
        tblGuias.Columns.Add("paquetes")
        tblGuias.Columns.Add("noEnvioTipo")
        tblGuias.Columns.Add("envioTipo")
        tblGuias.Columns.Add("envio_empresa")
        tblGuias.Columns.Add("empresa")
        tblGuias.Columns.Add("usuario")
        tblGuias.Columns.Add("fechatransaccion")
        tblGuias.Columns.Add("observacion")
        tblGuias.Columns.Add("precio")

        ''Me.grdProductos.Rows(0).IsSelected = True
        ''Me.grdProductos.SelectedCells("txbProducto").IsSelected = True

        fnCrearColumnasGrid()

    End Sub

    Private Sub fnCrearColumnasGrid()
        Try

            Me.grdlistado.Columns.Add("Codigo", "Codigo")
            Me.grdlistado.Columns.Add("Cantidad", "Cantidad")
            Me.grdlistado.Columns.Add("Precio", "Precio")

        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para ver los indicadores
    Private Sub fnIndicadores()
        Try

            If IsNumeric(cmbCliente.SelectedValue) Then
                If cmbCliente.SelectedValue > 0 Then
                    Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                    Dim diferenciaMes As String = Format(fechaActual.AddDays(-mdlPublicVars.Empresa_DiasUltimosProductos), "dd/MM/yyyy") & " 00:00:00"
                    Dim PrefiltroTipoVehiculo As String = fnClienteTipoVehiculo(cmbCliente.SelectedValue)

                    'conexion nueva.
                    Dim conexion As New dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim indi = conexion.sp_IndicadoresVenta(mdlPublicVars.idEmpresa, diferenciaMes, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, "1,2,5,4", CInt(Me.cmbCliente.SelectedValue), True, False, "", venta, PrefiltroTipoVehiculo)

                        For Each indicador As sp_IndicadoresVenta_Result In indi
                            lblConteoNuevo.Text = indicador.Nuevos
                            If indicador.Nuevos > 0 Then
                                lblFondoNuevo.BackColor = Color.Green
                            Else
                                lblFondoNuevo.BackColor = Color.White
                            End If

                            lblConteoPendiente.Text = indicador.Surtir
                            If indicador.Surtir > 0 Then
                                lblFondoPendienteSurtir.BackColor = Color.Green
                            Else
                                lblFondoPendienteSurtir.BackColor = Color.White
                            End If

                            lblConteoOfertas.Text = indicador.Ofertas
                            If indicador.Ofertas > 0 Then
                                lblFondoOferta.BackColor = Color.Green
                            Else
                                lblFondoOferta.BackColor = Color.White
                            End If

                            lblConteoSugeridos.Text = indicador.Sugeridos
                            If indicador.Sugeridos > 0 Then
                                lblFondoSugeridos.BackColor = Color.Green
                            Else
                                lblFondoSugeridos.BackColor = Color.White
                            End If
                        Next

                        ''Try
                        ''    'NUEVO
                        ''    'ulo.tblUnidadMedida.nombre, txmSurtir = 0)
                        ''    Dim nuevos = (From x In conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, diferenciaMes, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, PrefiltroTipoVehiculo, "", CInt(cmbCliente.SelectedValue), 9, True, False, "", venta) Select x).Count

                        ''    lblConteoNuevo.Text = nuevos
                        ''    If nuevos > 0 Then
                        ''        lblFondoNuevo.BackColor = Color.Green
                        ''    Else
                        ''        lblFondoNuevo.BackColor = Color.White
                        ''    End If

                        ''Catch ex As Exception
                        ''    lblConteoNuevo.Text = "0"
                        ''    lblFondoNuevo.BackColor = Color.White
                        ''End Try

                        ''Try
                        ''    'OFERTAS
                        ''    Dim ofertas2 = (From x In conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, diferenciaMes, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, PrefiltroTipoVehiculo, "", CInt(cmbCliente.SelectedValue), 11, True, False, "", venta) Select x).Count

                        ''    lblConteoOfertas.Text = ofertas2
                        ''    If ofertas2 > 0 Then
                        ''        lblFondoOferta.BackColor = Color.Green
                        ''    Else
                        ''        lblFondoOferta.BackColor = Color.White
                        ''    End If


                        ''Catch ex As Exception
                        ''    MessageBox.Show("Error en Indicadores : " + ex.ToString)
                        ''End Try

                        ''Try
                        ''    'indicador de pendientes por surtir
                        ''    Dim consulta As Integer = (From x In conexion.sp_PendientesPorSurtir(mdlPublicVars.idEmpresa, diferenciaMes, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, PrefiltroTipoVehiculo, "", CType(cmbCliente.SelectedValue, Integer), 1, True, False, "", venta) Select x).Count
                        ''    lblConteoPendiente.Text = consulta
                        ''    If consulta = 0 Then
                        ''        lblFondoPendienteSurtir.BackColor = Color.White
                        ''    Else
                        ''        lblFondoPendienteSurtir.BackColor = Color.Green
                        ''    End If
                        ''Catch ex As Exception
                        ''    lblConteoPendiente.Text = "0"
                        ''    lblFondoPendienteSurtir.BackColor = Color.White
                        ''End Try


                        ''Try
                        ''    ''Indicador de Sugeridos
                        ''    Dim sugeridos As Integer = (From x In conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, diferenciaMes, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, "1,2,5,4", "34,35,24,26,31,1,40,30,27,2,39,38,36,3,6,37,33,7,8,42,28,9,10,43,29,4,41,22,11,13,12,14,21,15,23,16,17,18,19,20,25,32,5", CInt(cmbCliente.SelectedValue), 5, True, False, "", venta) Select x).Count
                        ''    lblConteoSugeridos.Text = sugeridos
                        ''    If sugeridos = 0 Then
                        ''        lblFondoSugeridos.BackColor = Color.White
                        ''    Else
                        ''        lblFondoSugeridos.BackColor = Color.Green
                        ''    End If
                        ''Catch ex As Exception
                        ''    lblConteoSugeridos.Text = "0"
                        ''    lblFondoSugeridos.BackColor = Color.White
                        ''End Try
                        conn.Close()
                    End Using
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnClienteTipoVehiculo(id As Integer)

        Dim retorno As String = "0"

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim tp = (From y In conexion.tblCliente_clasificacionCompra _
                                          Where y.idCliente = id _
                                         Select Codigo = y.tipoVehiculo, Nombre = y.tblArticuloTipoVehiculo.nombre)

            Dim x
            Dim contador As Integer = 0
            For Each x In tp
                contador += 1
                If contador = 1 Then
                    retorno = x.Codigo
                Else
                    retorno = retorno & "," & x.Codigo
                End If
            Next

            conn.Close()
        End Using

        Return retorno
    End Function

    'Private Sub fnPendientesPorSurtir()

    '    If IsNumeric(cmbCliente.SelectedValue) Then
    '        If cmbCliente.SelectedValue > 0 Then

    '            Dim PrefiltroTipoVehiculo As String = fnClienteTipoVehiculo(cmbCliente.SelectedValue)

    '            Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
    '            Dim diferenciaMes As DateTime = fechaActual.AddDays(-mdlPublicVars.Empresa_DiasUltimosProductos)

    '            'conexion nueva.
    '            Dim conexion As New dsi_pos_demoEntities

    '            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    '                conn.Open()
    '                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
    '                Try
    '                    'indicador de pendientes por surtir.
    '                    Dim consulta As Integer = (From x In conexion.sp_PendientesPorSurtir(mdlPublicVars.idEmpresa, diferenciaMes.ToShortDateString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, PrefiltroTipoVehiculo, "", CType(cmbCliente.SelectedValue, Integer), 2, True, False, "", venta) Select x).Count
    '                    lblConteoPendiente.Text = consulta
    '                    If consulta = 0 Then
    '                        lblFondoPendienteSurtir.BackColor = Color.White
    '                    Else
    '                        lblFondoPendienteSurtir.BackColor = Color.Green
    '                    End If

    '                Catch ex As Exception
    '                    lblFondoPendienteSurtir.BackColor = Color.White
    '                    lblConteoPendiente.Text = "0"
    '                End Try

    '                conn.Close()
    '            End Using
    '        End If
    '    End If

    'End Sub

    'Funcion que se utliza para llenar los datos de unqa salida cuando se esta en modificar

    Private Sub fnLlenarDatos()
        Try
            grdProductos.Rows.Clear()

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cliente As Integer

                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).First()

                mdlPublicVars.superSearchNombreAlterno = salida.NOMBREALTERNO
                mdlPublicVars.superSearchDireccionAlterno = salida.DIRECCIONALTERNA

                inventario = salida.idTipoInventario
                txtCodigo.Text = salida.idSalida

                cliente = salida.idCliente

                Try
                    cmbCliente.SelectedValue = cliente
                Catch ex As Exception

                End Try

                'se agrego para mostrar datos de mostrador
                cmbNombre.Text = salida.cliente
                txtNit.Text = salida.nit

                cmbVendedor.SelectedValue = salida.idVendedor
                cmbVendedor.Select(0, 0)
                lblDocumento.Text = salida.documento
                txtObservacion.Text = salida.observacion

                dtpFechaRegistro.Text = salida.fechaRegistro
                rbnContado.Checked = salida.contado
                rbnCredito.Checked = salida.credito

                txtDireccionFacturacion.Text = salida.direccionFacturacion
                ' cmbDireccionFacturacion.Text = salida.direccionFacturacion

                cmbDirEnvios.Text = salida.direccionEnvio

                ' estado
                chkCotizado.Checked = salida.cotizado
                chkReservado.Checked = salida.reservado
                chkDespachado.Checked = salida.despachar

                'Obtenemos la lista de detalles
                Dim detallesp = (From x In conexion.spSalida_detalle(codigo) Select x).ToList


                Dim y As spSalida_detalle_Result

                For Each y In detallesp
                    Dim fila As Object()
                    fila = {y.idSalidaDetalle, y.idArticulo, y.codigo1, _
                            y.nombre1, y.cantidad, y.precio, _
                            y.cantidad * y.precio, y.contado, y.comentario, _
                            "0", "", "0", "0", "0", "0", y.tipoInventario, y.tipoPrecio, y.clrEstado, "0", "0", "0", "0", y.promocion, y.cuotapromo, y.cantprom}
                    grdProductos.Rows.Add(fila)
                Next

                conn.Close()
            End Using

        Catch ex As Exception
        End Try
    End Sub

    'Nuevo
    Private Sub fnNuevo()

        'llenar combos.
        llenarCombos()

        'valores de label a cero.
        lblSaldoInicial.Text = 0
        lblSaldoFinal.Text = 0
        lblRecuento.Text = 0
        rbnContado.Checked = True
        'condiciones para llenar informacion.

        If verRegistro = True Or bitEditarBodega = True Or bitEditarSalida = True Then
            pnx0Nuevo.Visible = False
            pnx1Cotizar.Visible = False
            pnx2Reservar.Visible = False
            pnx3Despachar.Visible = False
            pnx4Modificar.Visible = False
            pnx5Bitacora.Visible = False
            pnx6Impresiones.Visible = False
            Me.grdProductos.AllowDeleteRow = False
        End If

        If (bitEditarBodega = True Or bitEditarSalida = True) And verRegistro = False Then
            pnx4Modificar.Visible = True
        End If
        'si esta en modo edicion, que no permita eliminar productos solo colocar en existencia 0
        If bitEditarBodega = True Then
            'EDITAR EN BODEGA.
            Me.grdProductos.AllowDeleteRow = False
            dtpFechaRegistro.Enabled = False
            cmbCliente.Enabled = False
            cmbVendedor.Enabled = False

            'ocultar columnas
            Me.grdProductos.Columns("idajustecategoria").IsVisible = False

            'ver columnas.
            Me.grdProductos.Columns("txbAjuste").IsVisible = True
            Me.grdProductos.Columns("txmCantidadAjuste").IsVisible = True

            'cantidad no editable.
            Me.grdProductos.Columns("txmCantidad").ReadOnly = True
            Me.grdProductos.Columns("txmCodigo").ReadOnly = True

            'llenar datos de encabezado y detalle.
            If bitFactura = True Then
                fnLlenarFactura(codFact)
            Else
                fnLlenarDatos()
            End If

            If verRegistro = True Then
                Me.grdProductos.Columns("txbAjuste").IsVisible = False
                Me.grdProductos.Columns("txmCantidadAjuste").IsVisible = False
                Me.grdProductos.Columns("txmCantidadSurtir").IsVisible = False
                Me.grdProductos.Columns("chmContado").IsVisible = False
            End If
        ElseIf bitEditarSalida = True Then
            'EDITAR SALIDA

            'no permite eliminar productos del grid.
            Me.grdProductos.AllowDeleteRow = False

            'deshabilita opciones de encabezado.
            dtpFechaRegistro.Enabled = False
            cmbCliente.Enabled = False
            cmbInventario.Enabled = False
            cmbBodega.Enabled = False
            cmbVendedor.Enabled = False
            cmbDirEnvios.Enabled = False

            'oculta las columnas que sirven en ajuste de bodega.
            'Me.grdProductos.Columns("idajuste").IsVisible = False
            Me.grdProductos.Columns("idajustecategoria").IsVisible = False
            Me.grdProductos.Columns("txbAjuste").IsVisible = False
            Me.grdProductos.Columns("txmCantidadAjuste").IsVisible = False

            If chkCotizado.CheckState = True Or chkReservado.CheckState = False And chkDespachado.CheckState = False Then
                'Columna Cantidad de ESCRITURA.
                Me.grdProductos.Columns("txmCantidad").ReadOnly = False
            Else
                'Columna cantidad solo de lectura
                Me.grdProductos.Columns("txmCantidad").ReadOnly = True
            End If

            'LLENAR ENCABEZADO Y DETALLE
            fnLlenarDatos()
            If verRegistro = False Then
                fnNuevaFila()
            End If
            If bitSugerirDespacho = True Or bitSugerirReserva = True Then
                If bitSugerirDespacho = True Then
                    pnx3Despachar.Visible = True
                    pnx4Modificar.Visible = False
                ElseIf bitSugerirReserva Then
                    pnx2Reservar.Visible = True
                    pnx4Modificar.Visible = False
                End If
                fnSugerir()
            End If

            If verRegistro = True Then
                Me.grdProductos.Columns("txmCantidadSurtir").IsVisible = False
                Me.grdProductos.Columns("chmContado").IsVisible = False
            End If
        Else
            'NUEVO
            chkCotizado.Checked = False
            chkReservado.Checked = False
            chkDespachado.Checked = False
            'si editar = false,  nuevo
            Me.grdProductos.AllowDeleteRow = True
            dtpFechaRegistro.Enabled = True
            cmbCliente.Enabled = True

            cmbVendedor.Enabled = False
            txtCodigo.Text = ""
            txtClave.Text = ""
            txtCredito.Text = "0.00"
            txtContado.Text = "0.00"
            dtpFechaRegistro.Text = Format(Now, mdlPublicVars.formatoFecha).ToString
            lblDocumento.Text = fnCorrelativo()
            txtObservacion.Text = ""


            Me.grdProductos.Rows.Clear()

            'Me.grdProductos.Columns("idajuste").IsVisible = False
            Me.grdProductos.Columns("idajustecategoria").IsVisible = False
            Me.grdProductos.Columns("txbAjuste").IsVisible = False
            Me.grdProductos.Columns("txmCantidadAjuste").IsVisible = False
            Me.grdProductos.Columns("txmCantidad").ReadOnly = False
            Me.grdProductos.Columns("chmContado").IsVisible = False

            Me.grdProductos.Columns("txmCantidadSurtir").IsVisible = False

            Me.fnNuevaFila()
        End If
        fnVerificaCredito()

        'Llenar datos
        fnActualizar_Total()

        ''dtpFechaRegistro.Select()
        ''dtpFechaRegistro.Focus()

        'borrar los registros de guias temporales.
        tblGuias.Rows.Clear()

        Me.cmbCliente.Select()
        Me.cmbCliente.Focus()

    End Sub

    'Funcion utilizada para obtener el correlativo
    Private Function fnCorrelativo() As Integer

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            ''Codigo de operaciones
            'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblCorrelativos)
            'conexion.SaveChanges()
            'Obtenemos el correlativo
            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos.AsEnumerable
                                                 Where x.idTipoMovimiento = mdlPublicVars.Salida_TipoMovimientoVenta And x.idEmpresa = mdlPublicVars.idEmpresa
                                                 Select x).FirstOrDefault
            If correlativo IsNot Nothing Then
                Return correlativo.correlativo + 1
            Else
                'Creamos el nuevo correlativo
                Dim correlativoNuevo As New tblCorrelativo
                correlativoNuevo.correlativo = 1
                correlativoNuevo.serie = ""
                correlativoNuevo.inicio = 1
                correlativoNuevo.fin = 1000
                correlativoNuevo.porcentajeAviso = 20
                correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                correlativoNuevo.idTipoMovimiento = mdlPublicVars.Salida_TipoMovimientoVenta
                conexion.AddTotblCorrelativos(correlativoNuevo)
                conexion.SaveChanges()
                Return 1
            End If

            conn.Close()
        End Using
    End Function

    'Funcion utilizada para sugerir productos
    Private Sub fnSugerir()
        Dim codArt As Integer
        Dim cantidad As Integer
        Dim surtir As Integer
        Dim tipoInventario As Integer

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try


                'Recorremos el grid
                For i As Integer = 0 To Me.grdProductos.RowCount - 1
                    codArt = Me.grdProductos.Rows(i).Cells("id").Value
                    cantidad = Me.grdProductos.Rows(i).Cells("txmCantidad").Value
                    tipoInventario = Me.grdProductos.Rows(i).Cells("idInventario").Value
                    surtir = 0

                    'Obtenemos el registro de inventario
                    Dim inve As tblInventario = (From x In conexion.tblInventarios.AsEnumerable Where x.idTipoInventario = tipoInventario _
                                                And x.idTipoInventario = tipoInventario And x.idArticulo = codArt Select x).FirstOrDefault

                    If inve.saldo < cantidad Then
                        surtir = cantidad - inve.saldo
                        cantidad = inve.saldo
                    End If

                    Me.grdProductos.Rows(i).Cells("txmCantidad").Value = cantidad
                    Me.grdProductos.Rows(i).Cells("txmCantidadSurtir").Value = surtir
                Next
            Catch ex As Exception

            End Try

            conn.Close()
        End Using


    End Sub

    'Funcion utilizada para llenar los comboBox
    Private Sub llenarCombos()
        'consultar vendedores.
        Dim ven
        Dim cas2
        Dim inv
        Dim bod
        Dim cl
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            ven = (From x In conexion.tblVendedors Select Codigo = CType(0, Integer), Nombre = CType("<-- Ninguno -->", String)).Union( _
                        From s In conexion.tblVendedors _
                        Select Codigo = CType(s.idVendedor, Integer), Nombre = CType(s.nombre, String) Order By Nombre)

            cas2 = (From x In conexion.tblClientes Select Codigo = CType(0, Integer), Nombre = CType("", String)).Union(From s In conexion.tblClientes Where s.habillitado = True _
                  Select Codigo = CType(s.idCliente, Integer), Nombre = CType(s.Negocio, String) Order By Nombre)


            'Llenamos los inventario
            inv = From x In conexion.tblTipoInventarios _
                      Select Codigo = x.idTipoinventario, Nombre = x.nombre

            bod = From x In conexion.tblAlmacens _
                  Select Codigo = x.codigo, Nombre = x.nombre

            conn.Close()
        End Using

        'llenar el combo de vendedores.
        With Me.cmbVendedor
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = ven
        End With

        cmbVendedor.Select(0, 0)
        '' ''consultar clientes
        ''Dim cli As New DataTable
        ''cli.Columns.Add("Codigo")
        ''cli.Columns.Add("Nombre")

        ''cli.Rows.Add("0", "")



        '' ''Llenamos la datatable
        ''Dim c
        ''For Each c In cas2
        ''    cli.Rows.Add(c.Codigo, c.Nombre)
        ''Next

        'llenar combo de clientes
        With Me.cmbCliente
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = cas2
        End With

        With Me.cmbInventario
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = inv
        End With

        With Me.cmbBodega
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = bod
        End With

    End Sub

    'Funcion utilizada para llenar los datos de una factura
    Private Sub fnLlenarFactura(ByVal codigo As Integer)
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                'Obtenemos los datos de la factura
                Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigo Select x).FirstOrDefault

                'Obtenemos los pedidos de la factura
                Dim lPedidos As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.IdFactura = codigo _
                                                      And x.anulado = False Select x).ToList

                dtpFechaRegistro.Value = factura.Fecha
                rbnContado.Checked = factura.contado
                rbnCredito.Checked = factura.contado

                Dim pedido As tblSalida

                Dim dirEnvios As String = ""
                Dim vendedores As String = ""
                Dim documentos As String = ""
                For Each pedido In lPedidos
                    cmbCliente.SelectedValue = pedido.idCliente

                    vendedores += pedido.tblVendedor.nombre & ", "
                    dirEnvios += pedido.direccionEnvio & ","
                    cmbNombre.Text = pedido.cliente
                    txtNit.Text = pedido.nit
                    ' cmbDireccionFacturacion.Text = pedido.direccionFacturacion
                    txtDireccionFacturacion.Text = pedido.direccionFacturacion


                    documentos += pedido.documento & ", "
                    txtObservacion.Text += pedido.observacion & "; "


                    'AGREGAMOS LOS PRODUCTOS AL GRID

                    'Obtenemos el detalle de ese pedido
                    Dim lDetalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = pedido.idSalida _
                                                                  Select x).ToList

                    Dim detalle As tblSalidaDetalle

                    For Each detalle In lDetalles
                        'Obtenemos si se hicieron ajustes
                        Dim ajuste As tblAjuste = (From x In conexion.tblAjustes Where x.idsalidadetalle = detalle.idSalidaDetalle _
                                                   Select x).FirstOrDefault


                        'Creamos la fila para agregar al grid
                        Dim fila As Object()

                        If ajuste IsNot Nothing Then

                            fila = {detalle.idSalidaDetalle, detalle.idArticulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, detalle.cantidad, _
                            detalle.precio, "0", detalle.tblSalida.contado, ajuste.idAjusteCategoria, ajuste.tblAjusteCategoria.nombre, ajuste.cantidad, "0", "0", "0", _
                            detalle.tipoInventario, detalle.tipoPrecio}
                        Else

                            fila = {detalle.idSalidaDetalle, detalle.idArticulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, detalle.cantidad, _
                            detalle.precio, "0", detalle.tblSalida.contado, "0", "", "", "0", "0", "0", detalle.tipoInventario, detalle.tipoPrecio}
                        End If

                        'Agregamos la fila
                        Me.grdProductos.Rows.Add(fila)
                    Next
                Next

                cmbDirEnvios.Text = dirEnvios
                cmbVendedor.Text = vendedores
                cmbVendedor.Select(0, 0)
                lblDocumento.Text = documentos


            Catch ex As Exception

            End Try

            conn.Close()
        End Using

        fnActualizar_Total()
    End Sub

    'Funcion para llenar el combo de los nombres de facturacion,direcciones de facturacion y direcciones de envio  del cliente
    Private Sub fnNombresFacturacion()

        Dim idCliente As Integer = CType(cmbCliente.SelectedValue, Integer)

        Dim cliente As tblCliente
        Dim dir

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


            cliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).FirstOrDefault

            'Agregamos las direcciones de facturacion y de envio
            dir = (From x In conexion.tblCliente_UbicacionMercado Where x.cliente = idCliente _
                       Group By Codigo = x.municipio, Dire = x.direccion + ", ", Mun = x.tblMunicipio.nombre + ", ", Dep = x.tblMunicipio.tbldepartamento.nombre _
                       Into Group _
                       Select Codigo, Nombre = Dire + Mun + Dep)

            conn.Close()
        End Using


        '-----------------------
        Dim nombres As New DataTable
        nombres.Columns.Add("Codigo")
        nombres.Columns.Add("Nombre")

        Dim nombre1 As String = cliente.Nombre1
        Dim nombre2 As String = cliente.Nombre2

        If nombre1 Is Nothing Then
            nombre1 = ""
        End If

        If nombre2 Is Nothing Then
            nombre2 = ""
        End If

        If nombre1.Length > 0 Then
            Dim n1 As Object() = {1, nombre1}
            nombres.Rows.Add(n1)
        End If

        If nombre2.Length > 0 Then
            Dim n2 As Object() = {2, nombre2}
            nombres.Rows.Add(n2)
        End If

        With Me.cmbNombre
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = nombres
        End With

        'Creamos la fuente
        Dim dires As New DataTable
        dires.Columns.Add("Codigo")
        dires.Columns.Add("Nombre")

        Dim c
        For Each c In dir
            dires.Rows.Add(c.Codigo, c.Nombre)
        Next


        With cmbDirEnvios
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = dires
        End With
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        Try
            Dim cliente As Integer = CType(cmbCliente.SelectedValue, Integer)
            If cliente > 0 Then
                If Me.grdProductos.Rows.Count - 1 >= 0 Then
                    Me.grdProductos.Columns("txbProducto").ReadOnly = False
                    Me.grdProductos.Focus()
                    Me.grdProductos.Rows(0).IsSelected = True
                    Me.grdProductos.Columns(3).IsCurrent = True
                Else

                End If
            Else
                Me.grdProductos.Columns("txbProducto").ReadOnly = True

            End If

            If cliente > 0 Then
                Dim c As tblCliente
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    c = (From x In conexion.tblClientes Where x.idCliente = cliente Select x).FirstOrDefault

                    conn.Close()
                End Using
                txtClave.Text = c.clave
                txtNit.Text = c.nit1
                lblObservacionCliente.Text = c.observacion
                txtCreditoDisponible.Text = "0.00"

                If c.BITSUBCLIENTE = True Then

                    While mdlPublicVars.superSearchNombreAlterno = "" Or mdlPublicVars.superSearchDireccionAlterno = ""
                        frmClientesAlternos.Text = "Datos Cliente"
                        frmClientesAlternos.lblInformacion.Text = "El cliente seleccionado es un cliente dependiente, por favor ingresar la informacion solicitada."
                        frmClientesAlternos.StartPosition = FormStartPosition.CenterScreen
                        frmClientesAlternos.WindowState = FormWindowState.Normal
                        frmClientesAlternos.ShowDialog()
                        frmClientesAlternos.Dispose()
                    End While

                End If


                ''Dim clientetipopago As tblClienteTipoPago = (From x In conexion.tblClienteTipoPagoes Where x.idtipoPago = c.idTipoPago Select x).FirstOrDefault

                ''rbnCredito.Checked = CBool(c.tblClienteTipoPago.credito)

                ''rbnContado.Checked = Not c.tblClienteTipoPago.credito
                rbnContado.Checked = True
                txtNit.Text = ""
                fnNombresFacturacion()
                cmbVendedor.SelectedValue = c.idVendedor
                cmbVendedor.Select(0, 0)
                cmbVendedor.ResumeLayout()

            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
        fnIndicadores()
        fnVerificaLimiteCredito()
    End Sub

    Private Sub grdProductos_CellClick(sender As Object, e As UI.GridViewCellEventArgs) Handles grdProductos.CellClick
        fnLimpiarInformacionArticulo()
    End Sub

    Private Sub grdProductos_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos.CellFormatting
        mdlPublicVars.fnGrid_FormatoPrecios(sender, e, Me.grdProductos.Columns.Count - 1)
    End Sub

    Private Sub rbContado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnContado.CheckedChanged
        If rbnContado.Checked = True Then
            Me.grdProductos.Columns("chmContado").IsVisible = False
            lblCredito.Visible = False
            lblCredito.Text = ""
            txtCreditoDisponible.Text = 0
            fnActualizar_Total()
        End If
    End Sub

    Private Sub rbCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnCredito.CheckedChanged
        Try
            If rbnCredito.Checked = True Then
                If Not bitEditarBodega And Not bitEditarSalida Then
                    Me.grdProductos.Columns("chmContado").IsVisible = True
                    Me.grdProductos.Columns("chmContado").Width = 75
                End If
                If IsNumeric(lblSaldoFinal.Text) Then
                    fnVerificaCredito()
                End If
                fnActualizar_Total()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Dim fila As Integer = Me.grdProductos.CurrentRow.Index
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        If e.Column.Name = "txmCodigo" Then
            Dim codigo As String = e.Value

            If codigo IsNot Nothing Then
                If codigo.Length > 0 Then
                    fnBuscarArticulo(codigo, e.RowIndex)
                End If
            End If
        End If
        If e.Column.Name = "txmCantidad" Or e.Column.Name = "txmCosto" Or e.Column.Name = "txmCantidadAjuste" Then
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim saldo As Double = 0
                If IsNumeric(Me.grdProductos.Rows(fila).Cells(0).Value) Then
                    Dim idarticulo As Integer = Me.grdProductos.Rows(fila).Cells("id").Value
                    Dim idinventario As Integer = mdlPublicVars.General_idTipoInventario

                    Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idarticulo And
                                                     x.idTipoInventario = idinventario
                                                     Select x).FirstOrDefault
                    If inventario IsNot Nothing Then
                        saldo = inventario.saldo
                    End If
                End If
                If IsNumeric(e.Value) Then
                    If CType(e.Value, Decimal) > saldo Then
                        If RadMessageBox.Show("Desea enviar a pendientes por Surtir " & (CType(e.Value, Double) - saldo) & " Articulos ", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            grdProductos.Rows(fila).Cells("txmCantidadSurtir").Value = CType(e.Value, Double) - saldo
                        End If
                    End If
                End If
                conn.Close()
            End Using
            fnActualizar_Total()
        End If

        grdProductos.CloseEditor()
        grdProductos.CancelEdit()
        grdProductos.EditorManager.CloseEditor()
        grdProductos.EditorManager.CancelEdit()

        ''fnCopiarGrid()

    End Sub

    'Buscar Articulo Unico
    Public Sub fnBuscarArticulo(ByVal codigo As String, ByVal posicion As Integer)

        Dim bitNuevaFila As Boolean = False

        Try

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                'Verificamos si existe en codigos de barra
                Dim codigoBarra As tblArticulo_CodigoBarra = (From x In conexion.tblArticulo_CodigoBarra.AsEnumerable Where x.codigoBarra = codigo _
                                                          Select x).FirstOrDefault

                Dim cantidad As Integer = 0
                Dim articulo As tblArticulo = Nothing
                If codigoBarra Is Nothing Then
                    'Buscamos el articulo en base al codigo
                    articulo = (From x In conexion.tblArticuloes Where x.codigo1.ToLower.Equals(codigo.ToLower) _
                           Select x).FirstOrDefault
                Else
                    articulo = (From x In conexion.tblArticuloes Where x.idArticulo = codigoBarra.articulo _
                           Select x).FirstOrDefault
                    cantidad = codigoBarra.unidadEmpaque
                End If

                If articulo Is Nothing And codigoBarra Is Nothing Then
                    alerta.contenido = "Este producto no existe"
                    alerta.fnErrorContenido()
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCodigo").Value = ""
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCodigo").BeginEdit()
                Else
                    Dim codCliente As Integer = CInt(cmbCliente.SelectedValue)
                    'Obtenemos el tipo de negocio del cliente
                    Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codCliente Select x).FirstOrDefault
                    Dim tNegocio As Integer = cliente.idTipoNegocio

                    'Seleccionamos el precio del articulo
                    Dim precioArt As tblArticulo_TipoNegocio = (From x In conexion.tblArticulo_TipoNegocio.AsEnumerable Where x.articulo = articulo.idArticulo And _
                                                           x.tipoNegocio = tNegocio Select x).FirstOrDefault
                    Dim precio As Decimal = 0
                    'Asignamos el precio
                    If precioArt IsNot Nothing Then

                        precio = (From x In conexion.sp_redondearPrecio(precioArt.tblArticulo.precioPublico * (100 - precioArt.descuento) / 100) Select PrecioRetornado = x.Value).FirstOrDefault

                    Else
                        alerta.contenido = "Producto: " & articulo.nombre1 & " no tiene precio!"
                        alerta.fnErrorContenido()

                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCodigo").BeginEdit()
                        Exit Sub
                    End If

                    Dim artEstado As tblArticulo = (From x In conexion.tblArticuloes Where x.codigo1 = codigo Select x).FirstOrDefault
                    Dim estado = From x In conexion.spArticulo_EstadoDePrecio(artEstado.idArticulo, CType(cmbCliente.SelectedValue, Integer)) Select x

                    Dim valorEstado As Integer = 0

                    Dim estadoL As spArticulo_EstadoDePrecio_Result
                    For Each estadoL In estado
                        valorEstado = estadoL.Estado
                    Next

                    'Agregamos el producto
                    Me.grdProductos.Rows(posicion).Cells("iddetalle").Value = "0"
                    Me.grdProductos.Rows(posicion).Cells("id").Value = articulo.idArticulo
                    Me.grdProductos.Rows(posicion).Cells("txmCodigo").Value = codigo
                    Me.grdProductos.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                    Me.grdProductos.Rows(posicion).Cells("txbObservacion").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("txmCantidad").Value = If(codigoBarra Is Nothing, 0, cantidad)
                    Me.grdProductos.Rows(posicion).Cells("txbPrecio").Value = Format(precio, mdlPublicVars.formatoMoneda)
                    Me.grdProductos.Rows(posicion).Cells("Total").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("chmContado").Value = False
                    Me.grdProductos.Rows(posicion).Cells("idajustecategoria").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txbAjuste").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("txmCantidadAjuste").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("elimina").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("idSurtir").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txmCantidadSurtir").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("idInventario").Value = mdlPublicVars.General_idTipoInventario
                    Me.grdProductos.Rows(posicion).Cells("tipoPrecio").Value = mdlPublicVars.Empresa_PrecioNormal
                    Me.grdProductos.Rows(posicion).Cells("clrEstado").Value = valorEstado
                    bitNuevaFila = True

                End If

                conn.Close()
            End Using




            If bitNuevaFila = True Then
                Me.fnNuevaFila()
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Funcion que agrega los pendientes por surtir desde el formulario de busqueda
    Public Sub fnAgregar_Pendientes()
        'agregar productos a grid.
        Dim filas() As String

        'id, codigo,nombre,precio,cantidad
        filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchCantidad,
                 Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", False, "", 0, "", 0, 0,
                 mdlPublicVars.superSearchCodSurtir, mdlPublicVars.superSearchSurtir, mdlPublicVars.General_idTipoInventario,
                 mdlPublicVars.superSearchTipoPrecio, mdlPublicVars.superSearchEstado, mdlPublicVars.superSearchCodigoSurtir, mdlPublicVars.superSearchBitSurtir,
                 mdlPublicVars.superSearchBitNuevo, mdlPublicVars.superSearchBitOferta, mdlPublicVars.superSearchPromocion, mdlPublicVars.superSearchCuotaPromocion, mdlPublicVars.superSearchCantidadPromocion}
        grdProductos.Rows.Add(filas)

        grdProductos.Columns(4).IsCurrent = True
        grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True


        fnActualizar_Total()
    End Sub

    'Funcion que se utiliza para agregar articulos
    Public Sub fnAgregar_Articulos(ByVal surtir As Boolean)
        Try
            'agregar productos a grid.
            Dim filas() As String

            'id, codigo,nombre,precio,cantidad
            filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchCantidad,
                     Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", False, "", 0, "", 0, 0, 0,
                     mdlPublicVars.superSearchSurtir, mdlPublicVars.superSearchInventario, mdlPublicVars.superSearchTipoPrecio, mdlPublicVars.superSearchEstado, mdlPublicVars.superSearchCodigoSurtir, mdlPublicVars.superSearchBitSurtir,
                     mdlPublicVars.superSearchBitNuevo, mdlPublicVars.superSearchBitOferta, mdlPublicVars.superSearchPromocion, mdlPublicVars.superSearchCuotaPromocion, mdlPublicVars.superSearchCantidadPromocion}
            Try
                grdProductos.Rows.Add(filas)
                grdlistado.Rows.Add(mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchCantidad, mdlPublicVars.superSearchPrecio)
            Catch ex As Exception

            End Try

            If surtir = True Then
                Me.grdProductos.Rows(Me.grdProductos.RowCount - 1).IsVisible = False
            End If
            grdProductos.Columns(3).IsCurrent = True
            grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        Catch ex As Exception

        End Try

        ''fnDescuentoPromociones()
        fnActualizar_Total()

    End Sub

    Private Sub fnDescuentoPromociones()
        Try
            Dim desc As Decimal = 0

            For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
                If Me.grdProductos.Rows(i).Cells("Promocion").Value > 0 Then

                    desc += Me.grdProductos.Rows(i).Cells("Promocion").Value * Me.grdProductos.Rows(i).Cells("txbPrecio").Value

                End If
            Next

            Me.lblDescPromociones.Text = Format(desc, formatoMoneda)

        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para agregar articulos
    Public Sub fnAgregar_ArticulosGestion(ByVal surtir As Boolean)
        Try
            'agregar productos a grid.
            Dim filas() As String

            'id, codigo,nombre,precio,cantidad
            filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchCantidad,
                     Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", False, "", 0, "", 0, 0, 0,
                     mdlPublicVars.superSearchSurtir, mdlPublicVars.superSearchInventario, mdlPublicVars.superSearchTipoPrecio, mdlPublicVars.superSearchEstado, mdlPublicVars.superSearchCodigoSurtir, mdlPublicVars.superSearchBitSurtir,
                     mdlPublicVars.superSearchBitNuevo, mdlPublicVars.superSearchBitOferta, mdlPublicVars.superSearchPromocion, mdlPublicVars.superSearchCuotaPromocion, mdlPublicVars.superSearchCantidadPromocion}
            grdProductos.Rows.Add(filas)

            If surtir = True Then
                Me.grdProductos.Rows(Me.grdProductos.RowCount - 1).IsVisible = False
            End If
            grdProductos.Columns(3).IsCurrent = True
            grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        Catch ex As Exception

        End Try


        fnActualizar_Total()

    End Sub

    'Funcion que se utiliza para remover la fila actual
    Public Sub fnRemoverFila()
        Try
            Dim filaActual As Integer = CType(Me.grdProductos.CurrentRow.Index, Integer)

            If filaActual >= 0 Then
                Dim index
                Dim yaBorro As Boolean = False

                For index = filaActual To Me.grdProductos.Rows.Count - 1
                    Dim codigoArt As Integer = CType(Me.grdProductos.Rows(filaActual).Cells("Id").Value, Integer)
                    If yaBorro = False Then
                        'Si borrar es igual a false, elimina la fila
                        Me.grdProductos.Rows.RemoveAt(filaActual)
                        yaBorro = True
                    Else
                        'Si estamos es una fila que no tiene datos la eliminamos
                        If codigoArt = 0 Then
                            Me.grdProductos.Rows.RemoveAt(filaActual)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error " + ex.ToString)
        End Try

    End Sub

    'Funcion que se utiliza para agregar una nueva fila
    Public Sub fnNuevaFila()
        fnEliminaVacias()
        Me.grdProductos.Rows.AddNew()
    End Sub

    'Funcion utilizada para eliminar filas vacias
    Private Sub fnEliminaVacias()
        Try
            'Recorremos el grid

            Dim nombre As String = ""
            For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
                'Obtenemo el valor del nombre
                nombre = Me.grdProductos.Rows(i).Cells("txbProducto").Value

                If IsNothing(nombre) Then
                    Me.grdProductos.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    

    'Funcion utilizada para calcular el total de la venta
    Public Sub fnActualizar_Total()

        fnDescuentoPromociones()
        Dim index

        Try
            If Me.grdProductos.Rows.Count > 0 Then
                Dim suma As Decimal = 0
                Dim sumaCredito As Decimal = 0
                Dim sumaContado As Decimal = 0

                Dim cantidad As Double = 0
                Dim cantidadAjuste As Double = 0
                Dim idajuste As Integer = 0
                Dim precio As Decimal = 0
                Dim total As Decimal = 0
                Dim credito As Boolean = 0
                Dim totalVenta As Double = 0
                Dim ajustePositivo As Decimal = 0
                Dim ajusteNegativo As Decimal = 0
                Dim descuentopromociones As Decimal = 0
                Dim nombre As String = ""
                Dim numeroProductos As Integer = 0

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        cantidad = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Double)

                        nombre = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)

                        If nombre IsNot Nothing Then
                            precio = CType(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", ""), Decimal)
                            If bitEditarBodega = True And verRegistro = False Then
                                If IsNumeric(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value) Then

                                    cantidadAjuste = CType(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value, Double)
                                    Try
                                        idajuste = CType(Me.grdProductos.Rows(index).Cells("idajustecategoria").Value, Integer)
                                    Catch ex As Exception
                                        idajuste = 0
                                    End Try

                                    ''Dim ac As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes.AsEnumerable Where x.idTipoMovimiento = idajuste Select x).FirstOrDefault

                                    ajusteNegativo += (cantidadAjuste * precio)
                                    ''If ac IsNot Nothing Then
                                    ''    If ac.nombre.Contains("-") = True Then
                                    ''        'cantidad = cantidad - cantidadAjuste
                                    ''        ajusteNegativo += (cantidadAjuste * precio)
                                    ''    Else
                                    ''        'cantidad = cantidad + cantidadAjuste
                                    ''        ajustePositivo += (cantidadAjuste * precio)
                                    ''    End If
                                    ''End If
                                End If
                            End If

                            If (cantidad * precio) = 0 Then
                                Me.grdProductos.Rows(index).Cells("Total").Value = "0"
                                total = 0


                            Else
                                If Me.grdProductos.Rows(index).IsVisible Then

                                    Me.grdProductos.Rows(index).Cells("Total").Value = Format(cantidad * precio, mdlPublicVars.formatoMoneda).ToString

                                    totalVenta = cantidad * precio

                                    If rbnCredito.Checked = True Then
                                        If (Me.grdProductos.Rows(index).Cells("chmContado").Value = True) Then
                                            sumaContado = sumaContado + totalVenta
                                        Else
                                            sumaCredito = sumaCredito + totalVenta
                                        End If
                                    Else
                                        sumaContado = sumaContado + totalVenta
                                    End If
                                End If
                            End If

                            If Me.grdProductos.Rows(index).IsVisible Then
                                numeroProductos += 1
                            End If
                        End If
                    Next

                    suma = sumaContado + sumaCredito + suma

                    Try
                        descuentopromociones = Replace(Me.lblDescPromociones.Text, "Q", "")
                    Catch ex As Exception
                        descuentopromociones = 0
                    End Try

                    Me.lblDescPromociones.Text = Format(descuentopromociones, formatoMoneda)

                    'mostrar total menos descuentos.
                    If sumaContado > 0 Then
                        txtContado.Text = Format(sumaContado - descuentopromociones, mdlPublicVars.formatoMoneda)
                    Else
                        txtContado.Text = Format(sumaContado, mdlPublicVars.formatoMoneda)
                    End If
                    If sumaCredito > 0 Then
                        txtCredito.Text = Format(sumaCredito - descuentopromociones, mdlPublicVars.formatoMoneda)
                    Else
                        txtCredito.Text = Format(sumaCredito, mdlPublicVars.formatoMoneda)
                    End If

                    lblSaldoInicial.Text = Format(sumaContado + sumaCredito, mdlPublicVars.formatoMoneda)

                    lblSaldoFinal.Text = Format(sumaContado + sumaCredito + ajustePositivo - ajusteNegativo - descuentopromociones, mdlPublicVars.formatoMoneda)

                    Dim saldoAjuste As Double = (sumaContado + sumaCredito + ajustePositivo - ajusteNegativo) - (sumaContado + sumaCredito)

                    lblSaldoAjuste.Text = Format(saldoAjuste, mdlPublicVars.formatoMoneda)

                    lblRecuento.Text = numeroProductos.ToString

                    conn.Close()
                End Using
            Else
                lblSaldoFinal.Text = Format(0, mdlPublicVars.formatoMoneda)
            End If


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try


        ''verificar el credito del cliente
        fnVerificaCredito()
        fnCopiarGrid()
        ''fnVerificaLimiteCredito()
    End Sub

    Private Function fnVerificaLimiteCredito()
        Try

            Dim cliente As Integer = Me.cmbCliente.SelectedValue
            Dim total As Decimal = CInt(Me.lblSaldoFinal.Text)
            Dim saldo As Decimal
            Dim tot As Decimal
            Dim limitec As Decimal
            Dim sobregiro As Decimal
            Dim porcentajesobregiro As Decimal

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = cliente Select x).FirstOrDefault

                If cli.limiteCredito > 0 Then

                    limitec = cli.limiteCredito
                    porcentajesobregiro = cli.porcentajeCredito

                    sobregiro = (porcentajesobregiro / 100) * limitec

                    saldo = cli.saldo + total

                    Me.txtCreditoDisponible.Text = (limitec + sobregiro) - saldo

                    If saldo > (cli.limiteCredito + sobregiro) Then
                        ''alerta.contenido = "Cliente Excede el Limite de Credito!!!"
                        ''alerta.fnErrorContenido()

                        frmNotificacion.lblNotificacion.Text = "¡Cliente Excede el Limite de Credito!"
                        frmNotificacion.Show()

                    End If
                End If

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Function

    Private Function fnVerificaCredito() As Boolean

        Dim codcliente As Integer = cmbCliente.SelectedValue
        If codcliente > 0 Then
            'si retorno = true, el cliente tiene credito pendiente, por lo tanto necesita autorizacion para generar la venta.
            Dim retorno As Boolean = False

            'verificar si venta es credito, 
            'si es credito verificar excedente de credito.
            'If rbnCredito.Checked = True Then
            'consultar cliente.

            Dim cli As tblCliente
            'Obtenemos la sumatoria de las venta al cliente, que no esten facturas, ni anuladas, y que esten es estado despachada y al credito

            Dim salidas As Double = 0
            Dim credito As Double = 0

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                cli = (From i In conexion.tblClientes.AsEnumerable Where i.idCliente = codcliente Select i).FirstOrDefault

                'Obtenemos el monto del credito

                Try
                    credito = CDbl(txtCredito.Text)
                Catch ex As Exception
                    credito = 0
                End Try


                Try
                    ''salidas = (From x In conexion.tblSalidas.AsEnumerable Where x.idCliente = cli.idCliente And Not x.anulado _
                    ''And Not x.empacado And x.despachar And x.credito _
                    ''Select x.total).Sum

                    ''Dim cliente As Integer = cli.idCliente

                    ''Dim salidac = conexion.sp_VerificarCredito(cliente)

                    ''For Each fila As sp_VerificarCredito_Result In salidac
                    ''    salidas = fila.Column1
                    ''Next

                Catch ex As Exception
                    salidas = 0
                End Try

                conn.Close()
            End Using


            'Obtenemos el credito disponible, sobregiro, y sobre pago programado
            Dim creditoDisponible As Double = cli.limiteCredito - (cli.saldo) - salidas
            Dim sobreGiro As Double = (cli.porcentajeCredito / 100) * cli.limiteCredito


            If credito > (creditoDisponible + sobreGiro) Then
                lblCredito.Visible = True
                lblCredito.Text = "Autorizacion"
                lblFondoCredito.BackColor = Color.Red
            ElseIf credito > (creditoDisponible) Then
                lblCredito.Visible = True
                lblCredito.Text = "Sobregiro"
                lblFondoCredito.BackColor = Color.Yellow
            Else
                lblCredito.Visible = True
                lblCredito.Text = "VENDER!"
                lblFondoCredito.BackColor = Color.Green
            End If

            ''txtCreditoDisponible.Text = Format((creditoDisponible + sobreGiro) - credito, mdlPublicVars.formatoMoneda)
        Else
            lblCredito.Visible = False
            lblFondoCredito.BackColor = Color.Transparent
        End If
        'End If
        Return True
    End Function

    '----------------------------------------  FUNCIONES DE VALIDACION. ---------------------------
    Private Function fnErrores() As Boolean

        If bitEditarBodega = False Then
            If Me.grdProductos.Rows.Count = 0 Then
                alerta.contenido = "Faltan articulos"
                alerta.fnErrorContenido()
                Return True
            End If

            Dim index
            For index = 0 To Me.grdProductos.Rows.Count - 1
                Dim articulo As String = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)

                If articulo IsNot Nothing Then
                    If IsNumeric(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) Then
                    Else
                        alerta.contenido = "Requiere numero !!! " + Me.grdProductos.Rows(index).Cells("Cantidad").Value.ToString
                        alerta.fnErrorContenido()
                        Return True
                    End If
                End If
            Next
        Else
            'errores de modificar.
            If IsNumeric(txtCodigo.Text) Then
                If IsNumeric(lblSaldoFinal.Text) Then
                Else
                    alerta.contenido = "Requiere Numero"
                    alerta.fnErrorContenido()
                    Return True
                End If

                Dim t As Double = lblSaldoFinal.Text
                If t > 0 Then
                Else
                    alerta.contenido = "Requiere mayor a cero."
                    alerta.fnErrorContenido()
                    Return True
                End If
            Else
                alerta.fnUtiliceGuardar()
                Return True
            End If


            'recorrer la existencia y 
            Dim index
            Dim idajuste As Integer = 0
            Dim cantidad As Integer = 0
            Dim cantidadAjuste As Integer = 0
            Dim idarticulo As Integer = 0

            Dim articulo As String = ""

            For index = 0 To Me.grdProductos.Rows.Count - 1

                idajuste = Me.grdProductos.Rows(index).Cells("idajustecategoria").Value
                idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value 'id articulo
                articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' articulo

                If articulo.Length > 0 Then


                    ''revisar si cantidad es numerico.
                    If IsNumeric(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) Then
                        cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
                    Else
                        alerta.contenido = "Requiere numero en linea " + (index + 1).ToString + " Articulo " + articulo.ToString
                        alerta.fnErrorContenido()
                        Return True
                    End If

                    'revisar cantidad de ajuste, si es numerico.
                    If idajuste > 0 Then
                        If IsNumeric(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value) And Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value > 0 Then
                            cantidadAjuste = Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value
                        ElseIf Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value = 0 Then
                            alerta.contenido = "Debe ingresar una cantidad de ajuste en la linea:  " + (index + 1).ToString + ", Articulo :" + articulo.ToString
                            alerta.fnErrorContenido()
                            Return True
                        Else
                            alerta.contenido = "Ingrese cantidad de ajuste en linea: " + (index + 1).ToString + ", Articulo :" + articulo.ToString
                            alerta.fnErrorContenido()
                            Return True
                        End If
                    End If

                End If
            Next
        End If

        'Verificamos que tenga mas de un producto
        Dim numeroProductos As Integer = 0
        Dim codArt As String = ""
        For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
            codArt = Me.grdProductos.Rows(i).Cells("id").Value

            If codArt IsNot Nothing Then
                numeroProductos += 1
            End If
        Next

        If numeroProductos = 0 Then
            alerta.contenido = "Debe de ingresar al menos un producto"
            alerta.fnErrorContenido()
            Return True
        End If



        'If rbnCredito.Checked = True Then
        '    Dim cliente As tblCliente=( From c In coneccion.tb
        'End If



        'Vamos a verificar si la venta es credito  si el cliente no ha sobrepasado su limite

        Dim totalCredito As Decimal = 0
        Try
            totalCredito = FormatNumber(txtCredito.Text)
        Catch ex As Exception
            totalCredito = 0
        End Try



        Dim totalCreditoDisponible As Double = 0
        Try

            ' totCreditodisponible = (Replace(txtCreditoDisponible.Text, "Q", "").Trim)

            totalCreditoDisponible = FormatNumber(txtCreditoDisponible.Text)


        Catch ex As Exception
            totalCreditoDisponible = 0
        End Try


        'If rbnCredito.Checked = True Then
        '    If totalCredito > 0 Then

        '        If totalCredito > totalCreditoDisponible Then
        '            RadMessageBox.Show("La venta Al Credito Supera el Limite Asignado")
        '            Return True
        '        End If

        '    End If
        'End If






        Return False
    End Function

    '--------------------------------------------- COTIZACION --------------------------------------
    Private Sub fnGuardarCotizacion()


        fnVerificaLimiteCredito()

        'validaciones
        If IsNumeric(txtCodigo.Text) Then
            alerta.fnUtiliceModificar()
            Exit Sub
        End If

        Dim codcliente As Integer = cmbCliente.SelectedValue
        Dim cliente As String = cmbNombre.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = cmbVendedor.SelectedValue

        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim hora As String = fnHoraServidor()
        Dim success As Boolean = True
        Dim errContenido As String = ""

        Dim codigoSalidaCredito As Integer = 0
        Dim codigoSalidaContado As Integer = 0
        Dim errorContenido As Boolean = False
        Dim idsalidaimp As Integer

        'conexion nueva.
        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            'consultar un cliente
            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First
            Dim usr As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault

            If success = True Then
                'crear el encabezado de la transaccion
                Using transaction As New TransactionScope
                    'inicio de excepcion
                    Try
                        'paso 5, guardar el registro de encabezado
                        Dim salidaCredito As New tblSalida

                        Dim totalCredito As Decimal = 0
                        Try
                            totalCredito = CDec(Replace(txtCredito.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalCredito = 0
                        End Try


                        If (totalCredito > 0) Then
                            'Sustraemos el correlativo
                            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                                 Select x).FirstOrDefault

                            salidaCredito.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                            salidaCredito.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                            salidaCredito.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                            salidaCredito.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                            salidaCredito.idTipoMovimiento = codmovimiento
                            salidaCredito.idVendedor = usr.idVendedor

                            salidaCredito.idCliente = codcliente
                            salidaCredito.cliente = cmbNombre.Text
                            salidaCredito.nit = txtNit.Text

                            salidaCredito.fechaTransaccion = fecha
                            salidaCredito.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                            salidaCredito.observacion = txtObservacion.Text

                            salidaCredito.direccionFacturacion = txtDireccionFacturacion.Text

                            salidaCredito.direccionEnvio = cmbDirEnvios.Text

                            salidaCredito.cotizado = True
                            salidaCredito.reservado = False
                            salidaCredito.despachar = False
                            salidaCredito.facturado = False
                            salidaCredito.empacado = False
                            salidaCredito.anulado = False
                            salidaCredito.fechaAnulado = Nothing
                            salidaCredito.idMunicipio = If(CInt(cmbDirEnvios.SelectedValue) = 0, mdlPublicVars.General_MunicipioLocal, CInt(cmbDirEnvios.SelectedValue))

                            salidaCredito.descuento = Replace(Me.lblDescPromociones.Text, "Q", "")
                            salidaCredito.subtotal = totalCredito
                            salidaCredito.total = totalCredito

                            salidaCredito.pagado = 0
                            salidaCredito.saldo = 0
                            salidaCredito.NOMBREALTERNO = mdlPublicVars.superSearchNombreAlterno
                            salidaCredito.DIRECCIONALTERNA = mdlPublicVars.superSearchDireccionAlterno

                            salidaCredito.contado = False
                            salidaCredito.credito = True
                            salidaCredito.bitguia = False
                            salidaCredito.bitGuiaImpresa = False

                            salidaCredito.documento = correlativo.correlativo + 1
                            correlativo.correlativo = correlativo.correlativo + 1
                            'agregar salida al modelo
                            conexion.AddTotblSalidas(salidaCredito)

                            'guardar cambios
                            conexion.SaveChanges()
                            codigoSalidaCredito = salidaCredito.idSalida
                            idsalidaimp = salidaCredito.idSalida

                        End If

                        Dim salida As New tblSalida
                        Dim totalContado As Decimal = 0

                        Try
                            totalContado = CType(Replace(txtContado.Text, "Q", "").Trim, Decimal)
                        Catch ex As Exception
                            totalContado = 0
                        End Try


                        If (totalContado > 0) Then
                            'Sustraemos el correlativo
                            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                                 Select x).First

                            salida.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                            salida.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                            salida.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                            salida.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                            salida.idTipoMovimiento = codmovimiento
                            salida.idVendedor = usr.idVendedor

                            salida.idCliente = codcliente
                            salida.cliente = cmbNombre.Text
                            salida.nit = txtNit.Text

                            salida.fechaTransaccion = fecha
                            salida.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                            salida.observacion = txtObservacion.Text
                            salida.idMunicipio = If(CInt(cmbDirEnvios.SelectedValue) = 0, mdlPublicVars.General_MunicipioLocal, CInt(cmbDirEnvios.SelectedValue))
                            salida.cotizado = True
                            salida.reservado = False
                            salida.despachar = False
                            salida.facturado = False
                            salida.empacado = False
                            salida.anulado = False
                            salida.fechaAnulado = Nothing

                            salida.descuento = Replace(Me.lblDescPromociones.Text, "Q", "")
                            salida.subtotal = totalContado
                            salida.total = totalContado
                            salida.pagado = 0
                            salida.saldo = 0
                            salida.NOMBREALTERNO = mdlPublicVars.superSearchNombreAlterno
                            salida.DIRECCIONALTERNA = mdlPublicVars.superSearchDireccionAlterno
                            'salida.direccionFacturacion = cmbDireccionFacturacion.Text
                            salida.direccionFacturacion = txtDireccionFacturacion.Text
                            salida.direccionEnvio = cmbDirEnvios.Text

                            salida.contado = True
                            salida.credito = False

                            salida.documento = correlativo.correlativo + 1
                            correlativo.correlativo = correlativo.correlativo + 1

                            'agregar salida al modelo
                            conexion.AddTotblSalidas(salida)
                            'guardar cambios
                            conexion.SaveChanges()
                            codigoSalidaContado = salida.idSalida
                            idsalidaimp = salida.idSalida
                        End If

                        If (salida.idSalida > 0) Or (salidaCredito.idSalida > 0) Then
                            'paso 6, guardar el detalle
                            Dim index
                            Dim cantidad As Double = 0
                            Dim precio As Decimal = 0
                            Dim total As Decimal = 0
                            Dim id As Integer = 0
                            Dim nombre As String = ""
                            Dim cantSurtir As Integer = 0
                            Dim idSurtir As Integer = 0
                            Dim contado As Boolean = True
                            Dim idInventario As Integer = 0
                            Dim tipoPrecio As Integer = 0
                            Dim observacion As String = ""
                            Dim bitsurtir As Integer
                            Dim bitNuevo As Integer
                            Dim bitOferta As Integer
                            Dim codigoSurtir As Integer
                            Dim promocion As Double = 0
                            Dim cantidadpromocion As Double = 0
                            Dim cuotapromocion As Double = 0

                            For index = 0 To Me.grdProductos.Rows.Count - 1

                                'validar si es numerico el ID de articulo.
                                If IsNumeric(Me.grdProductos.Rows(index).Cells("Id").Value) Then
                                    id = Me.grdProductos.Rows(index).Cells("Id").Value ' id articulo
                                    nombre = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' articulo

                                    'validar que el nombre del articulo tenga texto valido.
                                    If nombre IsNot Nothing Then

                                        'consultar el articulo.
                                        Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).FirstOrDefault
                                        cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value 'cantidad
                                        cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value 'cantidadSurtir
                                        precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio

                                        'filtrar valores.
                                        'si cantidad es mayor a cero y precio mayor a cero, debe avisar.
                                        If cantidad > 0 And precio = 0 Then
                                            precio = 0
                                            MsgBox("Articulo : " & Trim(nombre) & " (" & Trim(producto.codigo1) & "), No tiene precio")
                                            errorContenido = True
                                            success = False
                                            Exit Try
                                        End If

                                        total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total

                                        idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value
                                        idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value
                                        tipoPrecio = Me.grdProductos.Rows(index).Cells("tipoPrecio").Value
                                        observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value

                                        bitsurtir = Me.grdProductos.Rows(index).Cells("bitSurtir").Value
                                        bitNuevo = Me.grdProductos.Rows(index).Cells("bitNuevo").Value
                                        bitOferta = Me.grdProductos.Rows(index).Cells("bitOfertas").Value
                                        codigoSurtir = Me.grdProductos.Rows(index).Cells("CodigoSurtir").Value
                                        promocion = Me.grdProductos.Rows(index).Cells("Promocion").Value
                                        cantidadpromocion = Me.grdProductos.Rows(index).Cells("CantidadPromocion").Value
                                        cuotapromocion = Me.grdProductos.Rows(index).Cells("CuotaPromocion").Value

                                        If rbnContado.Checked = True Then
                                            contado = True
                                        Else
                                            contado = Me.grdProductos.Rows(index).Cells("chmContado").Value
                                        End If

                                        Dim detalle As New tblSalidaDetalle
                                        If rbnContado.Checked = True Then
                                            detalle.idSalida = codigoSalidaContado
                                        Else
                                            If (Me.grdProductos.Rows(index).Cells("chmContado").Value = True) Then
                                                detalle.idSalida = codigoSalidaContado
                                            Else
                                                detalle.idSalida = codigoSalidaCredito
                                            End If
                                        End If

                                        'si cantidad es 0, guarda el registro como anulado por historial de pendientes por surtir.
                                        If CType(cantidad, Double) = 0 Then
                                            detalle.anulado = True
                                        Else
                                            detalle.anulado = False
                                        End If


                                        detalle.idArticulo = id
                                        detalle.cantidad = cantidad
                                        detalle.precio = precio
                                        detalle.costo = producto.costoIVA
                                        detalle.tipoInventario = idInventario
                                        detalle.tipoPrecio = tipoPrecio
                                        detalle.comentario = observacion
                                        detalle.precioFactura = precio
                                        detalle.agregarTransporte = 1
                                        detalle.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                        detalle.valormedida = 1
                                        detalle.bitsurtir = bitsurtir
                                        detalle.bitnuevo = bitNuevo
                                        detalle.bitoferta = bitOferta
                                        detalle.codigosurtir = codigoSurtir
                                        detalle.promocion = promocion
                                        detalle.cuotapromo = cuotapromocion
                                        detalle.cantprom = cantidadpromocion
                                        conexion.AddTotblSalidaDetalles(detalle)
                                        conexion.SaveChanges()

                                        'Verificamos is el producto es un servicio
                                        If producto.bitKit Then
                                            'Guardamos el detalle de los articulos del Kit
                                            'Obtenemos todos los articulos asociados a un kit
                                            Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = detalle.idArticulo
                                                                                          Select x).ToList

                                            For Each detalleKit As tblArticulo_Kit In lDetalleKit
                                                'Creamos un nuevo salida detalle
                                                Dim detalleHijo As New tblSalidaDetalle
                                                detalleHijo.idArticulo = detalleKit.articulo
                                                detalleHijo.anulado = False
                                                detalleHijo.cantidad = detalleKit.cantidad * detalle.cantidad
                                                detalleHijo.comentario = ""
                                                detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                                detalleHijo.precio = 0
                                                detalleHijo.idSalida = detalle.idSalida
                                                detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                                detalleHijo.tipoInventario = detalle.tipoInventario
                                                detalleHijo.tipoPrecio = detalle.tipoPrecio
                                                detalleHijo.agregarTransporte = True
                                                detalleHijo.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                                detalleHijo.valormedida = 1

                                                'Agregamos el detalle a la BD
                                                conexion.AddTotblSalidaDetalles(detalleHijo)
                                                conexion.SaveChanges()
                                            Next
                                        End If

                                        'Verifiamos si es surtir
                                        ''If idSurtir > 0 Then
                                        ' ''Modificamos el pendiente por surtir
                                        ''Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where (x.cliente = salida.idCliente Or x.cliente = salidaCredito.idCliente) And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

                                        ''Dim p As tblSurtir
                                        ''For Each p In pendiente
                                        ''    If cantidad > p.saldo Then
                                        ''        cantidad -= p.saldo
                                        ''        p.saldo = 0

                                        ''    Else
                                        ''        p.saldo -= cantidad
                                        ''        cantidad = 0
                                        ''    End If
                                        ''    conexion.SaveChanges()
                                        ''    If cantidad = 0 Then
                                        ''        Exit For
                                        ''    End If
                                        ''Next
                                        Dim vsurtir As Integer = (From x In conexion.tblSurtirs Where x.articulo = detalle.idArticulo And x.cliente = codcliente And x.saldo > 0 Select x).Count

                                        If vsurtir > 0 Then

                                        Else

                                            If cantSurtir > 0 Then
                                                'Creamos el pendiente por surtir
                                                Dim pendiente As New tblSurtir
                                                pendiente.salidaDetalle = detalle.idSalidaDetalle
                                                pendiente.articulo = detalle.idArticulo
                                                pendiente.cantidad = cantSurtir
                                                pendiente.saldo = cantSurtir
                                                pendiente.fechaTransaccion = fecha
                                                pendiente.anulado = 0
                                                pendiente.usuario = mdlPublicVars.idUsuario
                                                pendiente.vendedor = mdlPublicVars.idVendedor
                                                pendiente.Eliminar = False

                                                If contado = True Then
                                                    pendiente.cliente = salida.idCliente
                                                Else
                                                    pendiente.cliente = salidaCredito.idCliente
                                                End If

                                                conexion.AddTotblSurtirs(pendiente)
                                                conexion.SaveChanges()
                                            End If
                                        End If

                                        ''Inicio Erick Surtir
                                        Dim clientecombo As Integer = Me.cmbCliente.SelectedValue

                                        'Verificamos si tiene pendientes por surtir
                                        Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                                                             Where Not x.anulado And x.saldo > 0 And x.articulo = id And x.cliente = clientecombo _
                                                                                             And x.saldo = x.cantidad Select x).ToList
                                        Dim cantidadDescontar As Integer = cantidad
                                        'Recorremos la lista de pendientes
                                        For Each pendiente As tblSurtir In lPendientes

                                            Dim det As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idArticulo = id And x.idSalida = idsalidaimp Select x).FirstOrDefault

                                            If cantidadDescontar > pendiente.saldo Then
                                                cantidadDescontar -= pendiente.saldo
                                                pendiente.saldo = 0

                                                det.codigosurtir = pendiente.codigo
                                            Else
                                                pendiente.saldo -= cantidadDescontar
                                                cantidadDescontar = 0

                                                det.codigosurtir = pendiente.codigo
                                            End If
                                            conexion.SaveChanges()
                                            conexion.SaveChanges()
                                            If cantidadDescontar = 0 Then
                                                Exit For
                                            End If
                                        Next
                                        ''Fin Erick Surtir
                                    End If
                                End If
                            Next
                        Else
                            RadMessageBox.Show("No se puede realizar una cotizacion, con precio 0", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            success = False
                            Exit Try
                        End If

                        'actualizar el total del pedido en el encabezado
                        If totalCredito > 0 Then
                            Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim totaldesc As Double = 0
                            Try
                                totaldesc = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False And x.promocion > 0 Select x.promocion * x.precio).Sum
                            Catch ex As Exception
                                totaldesc = 0
                            End Try
                            salidaCredito.total = totalSalida - totaldesc
                            salidaCredito.subtotal = totalSalida - totaldesc
                        End If

                        If totalContado > 0 Then
                            Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim totaldesc As Double = 0
                            Try
                                totaldesc = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False And x.promocion > 0 Select x.promocion * x.precio).Sum
                            Catch ex As Exception
                                totaldesc = 0
                            End Try

                            Dim sContado As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigoSalidaContado Select x).FirstOrDefault
                            sContado.total = totalSalida - totaldesc
                            sContado.subtotal = totalSalida - totaldesc
                        End If

                        conexion.SaveChanges()


                        'paso 8, completar la transaccion.
                        transaction.Complete()


                    Catch ex As System.Data.EntityException
                        MessageBox.Show(ex.Message)
                        success = False
                    Catch ex As Exception
                        success = False
                        RadMessageBox.Show(ex.Message + vbCrLf + ex.InnerException.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        ' Handle errors and deadlocks here and retry if needed. 
                        ' Allow an UpdateException to pass through and 
                        ' retry, otherwise stop the execution. 
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                            alerta.fnErrorGuardar()
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

            If success = True Then

                conexion.AcceptAllChanges()
                alerta.fnGuardar()
                bitEditarSalida = False

                mdlPublicVars.superSearchNombreAlterno = ""
                mdlPublicVars.superSearchDireccionAlterno = ""

            End If

            conn.Close()
        End Using

        If success = True Then
            fnNuevo()

            'Mostramos la ventana de Bitacora, Usando la Variable global de configuración para conocer si se pide bitacora o No.
            AgregaBitacora(mdlPublicVars.Salida_BitacoraAlCotizar)

            If RadMessageBox.Show("¿Desea mostrar doc de salida?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If rbnContado.Checked = True Then
                    fnReporte_Cotizacion(codigoSalidaContado)
                End If

                If rbnCredito.Checked = True Then
                    fnReporte_Cotizacion(codigoSalidaCredito)
                End If
            End If

        End If

    End Sub

    Private Sub fnReporte_Cotizacion(ByVal codigo As Integer)
        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario
        Dim success As Boolean = False
        Dim salida As tblSalida = Nothing
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo).FirstOrDefault
                r.reporte = "ventas_Cotizacion1.rpt"
                r.tabla = EntitiToDataTable(From x In conexion.sp_ReporteVenta("", False, codigo))
                r.nombreParametro = "filtro"
                r.parametro = "Filtro del reporte:  "

                success = True
            Catch ex As Exception
                success = False
            End Try

            conn.Close()
        End Using

        If success = True Then
            frmDocumentosSalida.reporteBase = r.DocumentoReporte()
            frmDocumentosSalida.txtTitulo.Text = "Venta : " & salida.documento
            frmDocumentosSalida.Text = "Fact. de Salida"
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.codigo = salida.idCliente
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        End If

    End Sub

    '------------------------------------------------ Modificar Cotizacion
    Private Function fnModificarCotizacion()
        Dim codcliente As Integer = cmbCliente.SelectedValue
        Dim cliente As String = cmbNombre.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = cmbVendedor.SelectedValue

        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim success As Boolean = True
        Dim errContenido As String = ""

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Using transaction As New TransactionScope

                Try
                    Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First

                    'GUARDAR REGISTRO DE SALIDA.
                    '------------------------------------------------------  crear encabezado.-----------------------------
                    'paso 5, guardar el registro de encabezado
                    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault

                    salida.observacion = txtObservacion.Text

                    salida.descuento = 0
                    salida.subtotal = CType(lblSaldoFinal.Text, Double)
                    salida.total = CType(lblSaldoFinal.Text, Double)

                    salida.contado = rbnContado.Checked
                    salida.credito = rbnCredito.Checked

                    conexion.SaveChanges()
                    '--------------------------------------- fin de crear encabezado. -------------------


                    'paso 6, guardar el detalle
                    Dim index
                    Dim cantidad As Double = 0
                    Dim precio As Decimal = 0
                    Dim total As Decimal = 0
                    Dim idarticulo As Integer = 0
                    Dim articulo As String = ""
                    Dim iddetalle As Integer = 0
                    Dim elimina As Integer = 0
                    Dim cantSurtir As Integer = 0
                    Dim idSurtir As Integer = 0
                    Dim idInventario As Integer = 0
                    Dim tipoPrecio As Integer = 0
                    Dim observacion As String = ""
                    Dim codigoArticulo As String = ""
                    For index = 0 To Me.grdProductos.Rows.Count - 1

                        iddetalle = Me.grdProductos.Rows(index).Cells("iddetalle").Value ' id detalle
                        idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value ' id articulo
                        articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' codigo


                        If articulo IsNot Nothing Then

                            codigoArticulo = Me.grdProductos.Rows(index).Cells("txmCodigo").Value ' cantidad
                            cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value ' cantidad
                            precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio
                            total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total
                            elimina = Me.grdProductos.Rows(index).Cells("elimina").Value
                            cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value
                            idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value
                            idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value
                            tipoPrecio = Me.grdProductos.Rows(index).Cells("tipoPrecio").Value
                            observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value

                            'validaciones para precio
                            If elimina = 0 And cantidad > 0 Then
                                If precio = 0 Then
                                    MessageBox.Show("El articulo " & articulo & " ( " & codigoArticulo & " ), no tiene Precio !!!")
                                    success = False
                                    Exit Try
                                End If
                            End If

                            Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).FirstOrDefault

                            If elimina > 0 Then
                                'modificar registro de detalle.
                                Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First

                                detalle.anulado = 1

                                'Verificamos si tiene pendientes por surtir
                                Dim surtir As tblSurtir = (From x In conexion.tblSurtirs Where x.salidaDetalle = detalle.idSalidaDetalle Select x).FirstOrDefault
                                If surtir IsNot Nothing Then
                                    surtir.anulado = 1
                                    conexion.SaveChanges()
                                End If
                                conexion.SaveChanges()

                            ElseIf iddetalle > 0 Then

                                'modificar registro de detalle.
                                Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                Dim cantidadAntigua As Integer = detalle.cantidad
                                detalle.comentario = observacion
                                detalle.cantidad = cantidad
                                detalle.precio = precio
                                detalle.precioFactura = precio
                                conexion.SaveChanges()

                                If detalle.tblArticulo.bitKit Then
                                    'Obtenemos la lista de salidas detalle asociadas a el kit
                                    Dim lSalidaDetallKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = detalle.idSalidaDetalle _
                                                                                         Select x).ToList

                                    'Recorremos el grid para actualizarlo
                                    Dim cantidadKit As Integer = 0
                                    For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetallKit
                                        'Realizamos el calculo para la cantidad nueva
                                        cantidadKit = salidaDetalleKit.cantidad / cantidadAntigua
                                        salidaDetalleKit.cantidad = cantidadKit * detalle.cantidad
                                        conexion.SaveChanges()
                                    Next
                                End If
                            Else
                                'crear registro de detalle
                                Dim detalle As New tblSalidaDetalle
                                detalle.idSalida = salida.idSalida
                                detalle.idArticulo = idarticulo
                                detalle.cantidad = cantidad
                                detalle.precio = precio
                                detalle.anulado = 0
                                detalle.costo = producto.costoIVA
                                detalle.tipoInventario = idInventario
                                detalle.tipoPrecio = tipoPrecio
                                detalle.comentario = observacion
                                detalle.precioFactura = precio
                                detalle.agregarTransporte = True
                                detalle.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                detalle.valormedida = 1

                                conexion.AddTotblSalidaDetalles(detalle)
                                conexion.SaveChanges()
                                'asignar el id detalle 
                                iddetalle = detalle.idSalidaDetalle

                                'Verificamos is el producto es un kit
                                If detalle.tblArticulo.bitKit Then
                                    'Guardamos el detalle de los articulos del Kit

                                    'Obtenemos todos los articulos asociados a un kit
                                    Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = detalle.idArticulo
                                                                                  Select x).ToList

                                    For Each detalleKit As tblArticulo_Kit In lDetalleKit
                                        'Creamos un nuevo salida detalle
                                        Dim detalleHijo As New tblSalidaDetalle
                                        detalleHijo.idArticulo = detalleKit.articulo
                                        detalleHijo.anulado = False
                                        detalleHijo.cantidad = detalleKit.cantidad * detalle.cantidad
                                        detalleHijo.comentario = ""
                                        detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                        detalleHijo.precio = 0
                                        detalleHijo.idSalida = detalle.idSalida
                                        detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                        detalleHijo.tipoInventario = detalle.tipoInventario
                                        detalleHijo.tipoPrecio = detalle.tipoPrecio
                                        detalleHijo.agregarTransporte = True
                                        detalleHijo.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                        detalleHijo.valormedida = 1

                                        'Agregamos el detalle a la BD
                                        conexion.AddTotblSalidaDetalles(detalleHijo)
                                        conexion.SaveChanges()
                                    Next
                                End If
                            End If

                            If elimina = 0 Then
                                'Verifiamos si es surtir
                                If idSurtir > 0 Then
                                    'Modificamos el pendiente por surtir
                                    Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where x.cliente = salida.idCliente And x.saldo > 0 And x.articulo = idarticulo Select x Order By x.fechaTransaccion Descending).ToList

                                    For Each p As tblSurtir In pendiente
                                        If cantidad > p.saldo Then
                                            cantidad -= p.saldo
                                            p.saldo = 0
                                        Else
                                            p.saldo -= cantidad
                                            cantidad = 0
                                        End If
                                        conexion.SaveChanges()
                                        If cantidad = 0 Then
                                            Exit For
                                        End If
                                    Next
                                ElseIf cantSurtir > 0 Then
                                    'Creamos el pendiente por surtir
                                    Dim pendiente As New tblSurtir
                                    pendiente.salidaDetalle = iddetalle
                                    pendiente.articulo = idarticulo
                                    pendiente.cantidad = cantSurtir
                                    pendiente.saldo = cantSurtir
                                    pendiente.fechaTransaccion = fecha
                                    pendiente.anulado = 0
                                    pendiente.usuario = mdlPublicVars.idUsuario
                                    pendiente.vendedor = mdlPublicVars.idVendedor
                                    pendiente.cliente = salida.idCliente
                                    pendiente.Eliminar = False
                                    conexion.AddTotblSurtirs(pendiente)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    'actualizar el total de la venta.
                    Dim TotalVenta As Double = (From x In conexion.tblSalidas Join y In conexion.tblSalidaDetalles On x.idSalida Equals y.idSalida
                                              Where x.idSalida = codigo And y.anulado = False Select y.cantidad * y.precio).Sum()

                    salida.total = TotalVenta
                    salida.subtotal = TotalVenta

                    'paso 8, completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using


            If success = True Then
                conexion.AcceptAllChanges()
                If Not bitSugerirDespacho Then
                    alerta.fnGuardar()
                End If
            End If

            conn.Close()
        End Using

        If success = True Then
            Return True
        Else
            Return False
        End If
    End Function

    '--------------------------------------------- RESERVA ------------------------------------------
    Private Sub fnGuardarReserva()

        fnVerificaLimiteCredito()

        fnVerificarExistencia()

        ''If verificarexistencia = False Then
        ''    RadMessageBox.Show("Debe verificar existencia para poder guardar", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        ''    Exit Sub
        ''End If

        'variable que guardan los codigos.
        Dim codcliente As Integer = cmbCliente.SelectedValue
        Dim cliente As String = cmbNombre.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = cmbVendedor.SelectedValue

        'variable de sistema.
        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim hora As String = fnHoraServidor()
        Dim existenciaIns As Boolean = False
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim idsalidaimp As Integer = 0

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            'consultar un cliente
            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First
            Dim usr As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault

            If success = True Then
                Using transaction As New TransactionScope
                    Try

                        'GUARDAR REGISTRO DE SALIDA.
                        '------------------------------------------------------  crear encabezado.-----------------------------
                        'paso 5, guardar el registro de encabezado
                        Dim codigoSalidaCredito As Integer = 0
                        Dim codigoSalidaContado As Integer = 0

                        Dim diaSemana As Integer = Weekday(mdlPublicVars.fnFecha_horaServidor, vbMonday)
                        Dim fechaActual As DateTime = mdlPublicVars.fnFecha_horaServidor
                        Dim fechaReserva As DateTime = mdlPublicVars.fnFecha_horaServidor
                        Dim dias As Integer = 0
                        Try
                            Dim cadDias As String = InputBox("Ingrese dias de reserva", "Informacion", mdlPublicVars.Salida_ReservaDias)
                            dias = CInt(cadDias)
                        Catch ex As Exception
                            dias = mdlPublicVars.Salida_ReservaDias
                        End Try

                        If (diaSemana = 1) Then
                            fechaReserva = fechaActual.AddDays(dias)
                        Else
                            fechaReserva = fechaActual.AddDays(dias + 1)
                        End If

                        Dim salidaCredito As New tblSalida
                        'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblCorrelativos)
                        'conexion.SaveChanges()

                        Dim totalCredito As Decimal = 0
                        Try
                            totalCredito = CDec(Replace(txtCredito.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalCredito = 0
                        End Try

                        If (totalCredito > 0) Then
                            'Sustraemos el correlativo
                            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                                 Select x).First

                            salidaCredito.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                            salidaCredito.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                            salidaCredito.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                            salidaCredito.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                            salidaCredito.idTipoMovimiento = codmovimiento
                            salidaCredito.idVendedor = usr.idVendedor

                            salidaCredito.idCliente = codcliente
                            salidaCredito.cliente = cmbNombre.Text
                            salidaCredito.nit = txtNit.Text

                            salidaCredito.fechaVencimientoReserva = fechaReserva
                            salidaCredito.fechaTransaccion = fecha
                            salidaCredito.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                            salidaCredito.observacion = txtObservacion.Text

                            salidaCredito.cotizado = False
                            salidaCredito.reservado = True
                            salidaCredito.despachar = False
                            salidaCredito.facturado = False
                            salidaCredito.empacado = False
                            salidaCredito.anulado = False
                            salidaCredito.fechaAnulado = Nothing
                            salidaCredito.idMunicipio = If(CInt(cmbDirEnvios.SelectedValue) = 0, mdlPublicVars.General_MunicipioLocal, CInt(cmbDirEnvios.SelectedValue))
                            salidaCredito.descuento = Replace(Me.lblDescPromociones.Text, "Q", "")
                            salidaCredito.subtotal = totalCredito
                            salidaCredito.total = totalCredito
                            'salidaCredito.direccionFacturacion = cmbDireccionFacturacion.Text
                            salidaCredito.direccionFacturacion = txtDireccionFacturacion.Text
                            salidaCredito.direccionEnvio = cmbDirEnvios.Text

                            salidaCredito.contado = False
                            salidaCredito.credito = True
                            salidaCredito.pagado = 0
                            salidaCredito.saldo = 0
                            salidaCredito.bitguia = False
                            salidaCredito.bitGuiaImpresa = False
                            salidaCredito.NOMBREALTERNO = mdlPublicVars.superSearchNombreAlterno
                            salidaCredito.DIRECCIONALTERNA = mdlPublicVars.superSearchDireccionAlterno

                            salidaCredito.documento = correlativo.correlativo + 1
                            correlativo.correlativo = correlativo.correlativo + 1
                            'agregar salida al modelo
                            conexion.AddTotblSalidas(salidaCredito)

                            'guardar cambios
                            conexion.SaveChanges()
                            codigoSalidaCredito = salidaCredito.idSalida
                            idsalidaimp = salidaCredito.idSalida


                            ' Aca ingresaremos las guias creadas al envio
                            For i As Integer = 0 To tblGuias.Rows.Count - 1
                                Dim envio As New tblEnvio

                                Dim temporal As Integer = CType(tblGuias.Rows(i).Item("Codigo").ToString, Integer)

                                envio.numero = CType(tblGuias.Rows(i).Item("numero").ToString, Integer)
                                envio.paquetes = CType(tblGuias.Rows(i).Item("paquetes").ToString, Integer)
                                envio.envioTipo = CType(tblGuias.Rows(i).Item("noEnvioTipo").ToString, Integer)
                                envio.usuario = mdlPublicVars.idUsuario '
                                envio.fechatransaccion = tblGuias.Rows(i).Item("fechatransaccion").ToString
                                envio.observacion = tblGuias.Rows(i).Item("observacion").ToString
                                envio.precio = tblGuias.Rows(i).Item("precio").ToString
                                envio.envio_empresa = CType(tblGuias.Rows(i).Item("envio_empresa").ToString, Integer)

                                conexion.AddTotblEnvios(envio)
                                conexion.SaveChanges()

                                Dim envioSalida As New tblEnvio_Salida
                                envioSalida.envio = envio.codigo
                                envioSalida.salida = salidaCredito.idSalida

                                conexion.AddTotblEnvio_Salida(envioSalida)
                                conexion.SaveChanges()

                            Next
                        End If

                        Dim salida As New tblSalida
                        Dim totalContado As Decimal = 0
                        Try
                            totalContado = CDec(Replace(txtContado.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalContado = 0
                        End Try

                        If (totalContado > 0) Then

                            'Sustraemos el correlativo
                            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                                 Select x).First

                            salida.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                            salida.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                            salida.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                            salida.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                            salida.idTipoMovimiento = codmovimiento
                            salida.idVendedor = usr.idVendedor

                            salida.idCliente = codcliente
                            salida.cliente = cmbNombre.Text
                            salida.nit = txtNit.Text
                            salida.fechaVencimientoReserva = fechaReserva

                            salida.fechaTransaccion = fecha
                            salida.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                            salida.observacion = txtObservacion.Text
                            salida.idMunicipio = If(CInt(cmbDirEnvios.SelectedValue) = 0, mdlPublicVars.General_MunicipioLocal, CInt(cmbDirEnvios.SelectedValue))
                            salida.cotizado = False
                            salida.reservado = True
                            salida.despachar = False
                            salida.facturado = False
                            salida.empacado = False
                            salida.anulado = False
                            salida.fechaAnulado = Nothing
                            salida.NOMBREALTERNO = mdlPublicVars.superSearchNombreAlterno
                            salida.DIRECCIONALTERNA = mdlPublicVars.superSearchDireccionAlterno


                            ' salida.direccionFacturacion = cmbDireccionFacturacion.Text
                            salida.direccionFacturacion = txtDireccionFacturacion.Text
                            salida.direccionEnvio = cmbDirEnvios.Text

                            salida.descuento = Replace(Me.lblDescPromociones.Text, "Q", "")
                            salida.subtotal = totalContado
                            salida.total = totalContado
                            salida.pagado = 0
                            salida.bitguia = False
                            salida.bitGuiaImpresa = False
                            salida.saldo = 0

                            salida.contado = True
                            salida.credito = False

                            salida.documento = correlativo.correlativo + 1
                            correlativo.correlativo = correlativo.correlativo + 1

                            'agregar salida al modelo
                            conexion.AddTotblSalidas(salida)

                            'guardar cambios
                            conexion.SaveChanges()
                            codigoSalidaContado = salida.idSalida
                            idsalidaimp = salida.idSalida

                            For i As Integer = 0 To tblGuias.Rows.Count - 1
                                Dim envio As New tblEnvio

                                Dim temporal As Integer = CType(tblGuias.Rows(i).Item("Codigo").ToString, Integer)

                                envio.numero = CType(tblGuias.Rows(i).Item("numero").ToString, Integer)
                                envio.paquetes = CType(tblGuias.Rows(i).Item("paquetes").ToString, Integer)
                                envio.envioTipo = CType(tblGuias.Rows(i).Item("noEnvioTipo").ToString, Integer)
                                envio.usuario = mdlPublicVars.idUsuario '
                                envio.fechatransaccion = tblGuias.Rows(i).Item("fechatransaccion").ToString
                                envio.observacion = tblGuias.Rows(i).Item("observacion").ToString
                                envio.precio = tblGuias.Rows(i).Item("precio").ToString
                                envio.envio_empresa = CType(tblGuias.Rows(i).Item("envio_empresa").ToString, Integer)

                                conexion.AddTotblEnvios(envio)
                                conexion.SaveChanges()

                                Dim envioSalida As New tblEnvio_Salida
                                envioSalida.envio = envio.codigo
                                envioSalida.salida = salida.idSalida

                                conexion.AddTotblEnvio_Salida(envioSalida)
                                conexion.SaveChanges()
                            Next
                        End If

                        '--------------------------------------- fin de crear encabezado. -------------------
                        If (salida.idSalida > 0) Or (salidaCredito.idSalida > 0) Then
                            'paso 6, guardar el detalle
                            Dim index As Integer
                            Dim cantidad As Double = 0
                            Dim precio As Decimal = 0
                            Dim total As Decimal = 0
                            Dim id As Integer = 0
                            Dim nombre As String = ""
                            Dim cantSurtir As Integer = 0
                            Dim idSurtir As Integer = 0
                            Dim contado As Boolean = True
                            Dim idInventario As Integer = 0
                            Dim tipoPrecio As Integer = 0
                            Dim observacion As String = ""
                            Dim bitsurtir As Integer
                            Dim bitNuevo As Integer
                            Dim bitOferta As Integer
                            Dim codigoSurtir As Integer
                            Dim promocion As Double = 0
                            Dim cantidadpromocion As Double = 0
                            Dim cuotapromocion As Double = 0

                            For index = 0 To Me.grdProductos.Rows.Count - 1

                                id = Me.grdProductos.Rows(index).Cells("id").Value ' id articulo
                                nombre = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' codigo

                                If nombre IsNot Nothing Then

                                    bitsurtir = Me.grdProductos.Rows(index).Cells("bitSurtir").Value
                                    bitNuevo = Me.grdProductos.Rows(index).Cells("bitNuevo").Value
                                    bitOferta = Me.grdProductos.Rows(index).Cells("bitOfertas").Value
                                    codigoSurtir = Me.grdProductos.Rows(index).Cells("CodigoSurtir").Value
                                    cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value ' cantidad
                                    precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio
                                    total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total
                                    cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value 'surtir
                                    idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value
                                    idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value
                                    tipoPrecio = Me.grdProductos.Rows(index).Cells("tipoPrecio").Value
                                    observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value
                                    promocion = Me.grdProductos.Rows(index).Cells("Promocion").Value
                                    cantidadpromocion = Me.grdProductos.Rows(index).Cells("CantidadPromocion").Value
                                    cuotapromocion = Me.grdProductos.Rows(index).Cells("CuotaPromocion").Value

                                    If rbnContado.Checked = True Then
                                        contado = True
                                    Else
                                        contado = Me.grdProductos.Rows(index).Cells("chmContado").Value
                                    End If

                                    Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).First

                                    Dim detalle As New tblSalidaDetalle
                                    If rbnContado.Checked = True Then
                                        detalle.idSalida = codigoSalidaContado
                                    Else
                                        If (Me.grdProductos.Rows(index).Cells("chmContado").Value = True) Then
                                            detalle.idSalida = codigoSalidaContado
                                        Else
                                            detalle.idSalida = codigoSalidaCredito
                                        End If
                                    End If
                                    detalle.anulado = 0
                                    detalle.idArticulo = id
                                    detalle.cantidad = cantidad
                                    detalle.precio = precio
                                    detalle.costo = articulo.costoIVA
                                    detalle.tipoInventario = idInventario
                                    detalle.tipoPrecio = tipoPrecio
                                    detalle.comentario = observacion
                                    detalle.precioFactura = precio
                                    detalle.agregarTransporte = True
                                    detalle.bitsurtir = bitsurtir
                                    detalle.bitnuevo = bitNuevo
                                    detalle.bitoferta = bitOferta
                                    detalle.codigosurtir = codigoSurtir
                                    detalle.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                    detalle.valormedida = 1
                                    detalle.promocion = promocion
                                    detalle.cantprom = cantidadpromocion
                                    detalle.cuotapromo = cuotapromocion
                                    'Crear el objeto
                                    conexion.AddTotblSalidaDetalles(detalle)
                                    conexion.SaveChanges()

                                    'Verificamos si el producto es un servicio
                                    If detalle.tblArticulo.bitKit Then
                                        'Guardamos el detalle de los articulos del Kit

                                        'Obtenemos todos los articulos asociados a un kit
                                        Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = detalle.idArticulo
                                                                                      Select x).ToList

                                        For Each detalleKit As tblArticulo_Kit In lDetalleKit
                                            'Creamos un nuevo salida detalle
                                            Dim detalleHijo As New tblSalidaDetalle
                                            detalleHijo.idArticulo = detalleKit.articulo
                                            detalleHijo.anulado = False
                                            detalleHijo.cantidad = detalleKit.cantidad * detalle.cantidad
                                            detalleHijo.comentario = ""
                                            detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                            detalleHijo.precio = 0
                                            detalleHijo.idSalida = detalle.idSalida
                                            detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                            detalleHijo.tipoInventario = detalle.tipoInventario
                                            detalleHijo.tipoPrecio = detalle.tipoPrecio
                                            detalleHijo.agregarTransporte = True
                                            detalleHijo.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                            detalleHijo.valormedida = 1

                                            'Agregamos el detalle a la BD
                                            conexion.AddTotblSalidaDetalles(detalleHijo)
                                            conexion.SaveChanges()
                                        Next
                                    End If

                                    'Verifiamos si es surtir
                                    ''If idSurtir > 0 Then

                                    'Modificamos el pendiente por surtir
                                    ''Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where (x.cliente = salida.idCliente Or x.cliente = salidaCredito.idCliente) And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

                                    ''Dim p As tblSurtir

                                    ''For Each p In pendiente

                                    ''    If cantidad > p.saldo Then
                                    ''        cantidad -= p.saldo
                                    ''        p.saldo = 0
                                    ''    Else
                                    ''        p.saldo -= cantidad
                                    ''        cantidad = 0
                                    ''    End If
                                    ''    conexion.SaveChanges()
                                    ''    If cantidad = 0 Then
                                    ''        Exit For
                                    ''    End If
                                    ''Next
                                    Dim vsurtir As Integer = (From x In conexion.tblSurtirs Where x.articulo = detalle.idArticulo And x.cliente = codcliente And x.saldo > 0 Select x).Count

                                    If vsurtir > 0 Then

                                    Else

                                        If cantSurtir > 0 Then
                                            'Creamos el pendiente por surtir
                                            Dim pendiente As New tblSurtir
                                            pendiente.salidaDetalle = detalle.idSalidaDetalle
                                            pendiente.articulo = detalle.idArticulo
                                            pendiente.cantidad = cantSurtir
                                            pendiente.saldo = cantSurtir
                                            pendiente.fechaTransaccion = fecha
                                            pendiente.anulado = 0
                                            pendiente.usuario = mdlPublicVars.idUsuario
                                            pendiente.vendedor = mdlPublicVars.idVendedor
                                            pendiente.Eliminar = False

                                            If contado = True Then
                                                pendiente.cliente = salida.idCliente
                                            Else
                                                pendiente.cliente = salidaCredito.idCliente
                                            End If

                                            conexion.AddTotblSurtirs(pendiente)
                                            conexion.SaveChanges()
                                        End If
                                    End If

                                    'guardar los cambios.
                                    conexion.SaveChanges()

                                    ''Inicio Erick Surtir
                                    Dim clientecombo As Integer = Me.cmbCliente.SelectedValue

                                    'Verificamos si tiene pendientes por surtir
                                    Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                                                         Where Not x.anulado And x.saldo > 0 And x.articulo = id And x.cliente = clientecombo _
                                                                                         And x.saldo = x.cantidad Select x).ToList
                                    Dim cantidadDescontar As Integer = cantidad
                                    'Recorremos la lista de pendientes
                                    For Each pendiente As tblSurtir In lPendientes

                                        Dim det As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idArticulo = id And x.idSalida = idsalidaimp Select x).FirstOrDefault

                                        If cantidadDescontar > pendiente.saldo Then
                                            cantidadDescontar -= pendiente.saldo
                                            pendiente.saldo = 0

                                            det.codigosurtir = pendiente.codigo
                                        Else
                                            pendiente.saldo -= cantidadDescontar
                                            cantidadDescontar = 0

                                            det.codigosurtir = pendiente.codigo
                                        End If
                                        conexion.SaveChanges()
                                        conexion.SaveChanges()
                                        If cantidadDescontar = 0 Then
                                            Exit For
                                        End If
                                    Next
                                    ''Fin Erick Surtir


                                    If articulo.bitKit Then
                                        'Obtenemos la lista de los productos asociados a ese kit
                                        Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = articulo.idArticulo _
                                                                                       Select x).ToList

                                        For Each detallekit As tblArticulo_Kit In lDetalleKit
                                            'descontar existencias.
                                            Dim codArtKit As Integer = detallekit.articulo
                                            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                         And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                         And x.idArticulo = codArtKit Select x).FirstOrDefault

                                            'si es reserva, incrementar la reserva , y decrementar el saldo
                                            If inve.saldo >= (detallekit.cantidad * cantidad) Then
                                                inve.saldo = inve.saldo - (cantidad * detallekit.cantidad)
                                                inve.reserva = inve.reserva + (cantidad * detallekit.cantidad)
                                                conexion.SaveChanges()
                                            Else
                                                'alerta.contenido = ""
                                                RadMessageBox.Show("Existencia insuficiente de " & articulo.nombre1 & " (" & articulo.codigo1 & ")", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                                existenciaIns = True
                                                success = False
                                                Exit Try
                                            End If
                                        Next

                                    ElseIf articulo.bitProducto = True Then
                                        'descontar existencias.
                                        Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                     And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                     And x.idArticulo = id Select x).FirstOrDefault

                                        'si es reserva, incrementar la reserva , y decrementar el saldo
                                        If inve.saldo >= cantidad Then
                                            'descontar cantidad del saldo principal
                                            inve.saldo = inve.saldo - cantidad
                                            'incrementar la reserva.
                                            inve.reserva = inve.reserva + cantidad

                                            'guardar los cambios.
                                            conexion.SaveChanges()
                                        Else
                                            'alerta.contenido = "Error !!!, Existencia insuficiente " + articulo.nombre1
                                            RadMessageBox.Show("Existencia insuficiente de " & articulo.nombre1.Trim() & " (" & articulo.codigo1.Trim() & ")  por: " & CInt((cantidad - inve.saldo)), mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                            existenciaIns = True
                                            success = False
                                            Exit Try
                                        End If
                                    End If
                                End If
                            Next
                        Else
                            RadMessageBox.Show("No se puede realizar la venta, con precio 0", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            success = False
                            Exit Try
                        End If  ' fin de comprara si se crea alguna slida


                        If totalCredito > 0 Then
                            Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim totaldesc As Double = 0
                            Try
                                totaldesc = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False And x.promocion > 0 Select x.promocion * x.precio).Sum
                            Catch ex As Exception
                                totaldesc = 0
                            End Try
                            salidaCredito.total = totalSalida - totaldesc
                            salidaCredito.subtotal = totalSalida - totaldesc
                        End If

                        If totalContado > 0 Then
                            Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim totaldesc As Double = 0
                            Try
                                totaldesc = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False And x.promocion > 0 Select x.promocion * x.precio).Sum
                            Catch ex As Exception
                                totaldesc = 0
                            End Try
                            Dim sContado As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigoSalidaContado Select x).FirstOrDefault
                            sContado.total = totalSalida - totaldesc
                            sContado.subtotal = totalSalida - totaldesc
                        End If

                        ' ''actualizar el total del pedido en el encabezado
                        ''If totalCredito > 0 Then
                        ''    Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False Select x.cantidad * x.precio).Sum
                        ''    salidaCredito.total = totalSalida
                        ''    salidaCredito.subtotal = totalSalida
                        ''End If

                        ''If totalContado > 0 Then
                        ''    Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False Select x.cantidad * x.precio).Sum
                        ''    Dim sContado As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigoSalidaContado Select x).FirstOrDefault
                        ''    sContado.total = totalSalida
                        ''    sContado.subtotal = totalSalida
                        ''End If


                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        success = False
                    Catch ex As Exception
                        success = False
                        ' Handle errors and deadlocks here and retry if needed. 
                        ' Allow an UpdateException to pass through and 
                        ' retry, otherwise stop the execution. 
                        MsgBox("Errores catch: " & ex.Message)

                        If ex.[GetType]() <> GetType(UpdateException) Then
                            Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                            alerta.fnErrorGuardar()
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

            If success = True Then
                conexion.AcceptAllChanges()
            Else
                If Not existenciaIns Then
                    alerta.fnErrorGuardar()
                End If
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion.
            conn.Close()

            If success = True Then
                alerta.fnGuardar()
                bitEditarSalida = False
                mdlPublicVars.superSearchNombreAlterno = ""
                mdlPublicVars.superSearchDireccionAlterno = ""
                'Mostramos la ventana de Bitacora, Usando la Variable global de configuración para conocer si se pide bitacora o No.
                AgregaBitacora(mdlPublicVars.Salida_BitaraAlReservar)

                fnNuevo()
            End If
        End Using

    End Sub

    '----------------------------------- Modificar Reserva ----------------------------------------------------------------
    Private Function fnModificarReserva()

        fnVerificarExistencia()

        Dim codcliente As Integer = cmbCliente.SelectedValue
        Dim cliente As String = cmbNombre.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = cmbVendedor.SelectedValue

        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim codigoSalida As Integer = 0

        'conexion nueva.
        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            'consultar un cliente
            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First

            If success = True Then
                Using transaction As New TransactionScope

                    Try
                        'GUARDAR REGISTRO DE SALIDA.

                        '------------------------------------------------------  crear encabezado.-----------------------------
                        'paso 5, guardar el registro de encabezado
                        Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).First

                        salida.observacion = txtObservacion.Text

                        salida.descuento = 0
                        salida.subtotal = CType(lblSaldoFinal.Text, Double)
                        salida.total = CType(lblSaldoFinal.Text, Double)

                        salida.contado = rbnContado.Checked
                        salida.credito = rbnCredito.Checked

                        conexion.SaveChanges()
                        codigoSalida = salida.idSalida
                        '--------------------------------------- fin de crear encabezado. -------------------

                        'paso 6, guardar el detalle
                        Dim index
                        Dim cantidad As Double = 0
                        Dim precio As Decimal = 0
                        Dim total As Decimal = 0
                        Dim idarticulo As Integer = 0
                        Dim articulo As String = ""
                        Dim iddetalle As Integer = 0
                        Dim elimina As Integer = 0
                        Dim cantidadAnterior As Integer = 0
                        Dim idSurtir As Integer = 0
                        Dim cantSurtir As Integer = 0
                        Dim idInventario As Integer = 0
                        Dim tipoPrecio As Integer = 0
                        Dim observacion As String = ""
                        For index = 0 To Me.grdProductos.Rows.Count - 1

                            iddetalle = Me.grdProductos.Rows(index).Cells("iddetalle").Value ' id detalle
                            idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value ' id articulo
                            articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' codigo

                            If articulo IsNot Nothing Then
                                cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value ' cantidad
                                precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio
                                total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total
                                elimina = Me.grdProductos.Rows(index).Cells("elimina").Value
                                idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value
                                cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value
                                idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value
                                tipoPrecio = Me.grdProductos.Rows(index).Cells("tipoPrecio").Value

                                Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).FirstOrDefault

                                If elimina > 0 Then
                                    Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                    detalle.anulado = 1

                                    'Verificamos si tiene pendientes por surtir
                                    Dim surtir As tblSurtir = (From x In conexion.tblSurtirs Where x.salidaDetalle = detalle.idSalidaDetalle Select x).FirstOrDefault
                                    If surtir IsNot Nothing Then
                                        surtir.anulado = 1
                                        conexion.SaveChanges()
                                    End If
                                    cantidadAnterior = detalle.cantidad
                                    conexion.SaveChanges()

                                ElseIf iddetalle > 0 Then
                                    'modificar registro de detalle.
                                    Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                    cantidadAnterior = detalle.cantidad
                                    detalle.cantidad = cantidad
                                    detalle.precio = precio
                                    detalle.precioFactura = precio
                                    conexion.SaveChanges()


                                    If detalle.tblArticulo.bitKit Then
                                        'Obtenemos la lista de salidas detalle asociadas a el kit
                                        Dim lSalidaDetallKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = detalle.idSalidaDetalle _
                                                                                             Select x).ToList

                                        'Recorremos el grid para actualizarlo
                                        Dim cantidadKit As Integer = 0
                                        For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetallKit
                                            'Realizamos el calculo para la cantidad nueva
                                            cantidadKit = salidaDetalleKit.cantidad / cantidadAnterior
                                            salidaDetalleKit.cantidad = cantidadKit * detalle.cantidad
                                            conexion.SaveChanges()
                                        Next
                                    End If

                                Else
                                    'crear registro de detalle
                                    Dim detalle As New tblSalidaDetalle
                                    detalle.idSalida = salida.idSalida
                                    detalle.idArticulo = idarticulo
                                    detalle.cantidad = cantidad
                                    detalle.precio = precio
                                    detalle.costo = producto.costoIVA
                                    detalle.tipoInventario = idInventario
                                    detalle.anulado = 0
                                    detalle.tipoPrecio = tipoPrecio
                                    detalle.comentario = observacion

                                    detalle.precioFactura = precio
                                    detalle.agregarTransporte = True
                                    detalle.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                    detalle.valormedida = 1
                                    conexion.AddTotblSalidaDetalles(detalle)
                                    conexion.SaveChanges()

                                    'Verificamos is el producto es un kit
                                    If detalle.tblArticulo.bitKit Then
                                        'Guardamos el detalle de los articulos del Kit
                                        'Obtenemos todos los articulos asociados a un kit
                                        Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = detalle.idArticulo
                                                                                      Select x).ToList

                                        For Each detalleKit As tblArticulo_Kit In lDetalleKit
                                            'Creamos un nuevo salida detalle
                                            Dim detalleHijo As New tblSalidaDetalle
                                            detalleHijo.idArticulo = detalleKit.articulo
                                            detalleHijo.anulado = False
                                            detalleHijo.cantidad = detalleKit.cantidad * detalle.cantidad
                                            detalleHijo.comentario = ""
                                            detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                            detalleHijo.precio = 0
                                            detalleHijo.idSalida = detalle.idSalida
                                            detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                            detalleHijo.tipoInventario = detalle.tipoInventario
                                            detalleHijo.tipoPrecio = detalle.tipoPrecio
                                            detalleHijo.agregarTransporte = True
                                            detalleHijo.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                            detalleHijo.valormedida = 1

                                            'Agregamos el detalle a la BD
                                            conexion.AddTotblSalidaDetalles(detalleHijo)
                                            conexion.SaveChanges()
                                        Next
                                    End If

                                    'Verifiamos si es surtir
                                    If idSurtir > 0 Then
                                        'Modificamos el pendiente por surtir
                                        Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where x.cliente = salida.idCliente And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

                                        Dim p As tblSurtir
                                        For Each p In pendiente
                                            If cantSurtir > p.saldo Then
                                                cantSurtir -= p.saldo
                                                p.saldo = 0
                                            Else
                                                p.saldo -= cantSurtir
                                                cantSurtir = 0
                                            End If
                                            conexion.SaveChanges()
                                            If cantSurtir = 0 Then
                                                Exit For
                                            End If
                                        Next

                                    ElseIf cantSurtir > 0 Then
                                        'Creamos el pendiente por surtir
                                        Dim pendiente As New tblSurtir
                                        pendiente.salidaDetalle = detalle.idSalidaDetalle
                                        pendiente.articulo = detalle.idArticulo
                                        pendiente.cantidad = cantSurtir
                                        pendiente.saldo = cantSurtir
                                        pendiente.fechaTransaccion = fecha
                                        pendiente.anulado = 0
                                        pendiente.usuario = mdlPublicVars.idUsuario
                                        pendiente.vendedor = mdlPublicVars.idVendedor
                                        pendiente.cliente = salida.idCliente
                                        pendiente.Eliminar = False

                                        conexion.AddTotblSurtirs(pendiente)
                                        conexion.SaveChanges()
                                    End If
                                End If


                                'descontar existencias.
                                Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                 And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                 And x.idArticulo = idarticulo Select x).FirstOrDefault

                                'RESUMEN DE OPCIONES.

                                'si idDetalleSalida existe
                                '   Eliminar = 0, Saldo + cantidadAnt, Reserva - cantidadAnt y Saldo - CantidadNueva, Reserva + CantidadNueva.
                                '   Eliminar = 1, Saldo + cantidadAnt, Reserva - cantidadAnt

                                'si eliminar mayor a cero.
                                'Saldo + cantidad Anterior y Reserva - cantidad Anterior.

                                'si eliminar =0 y iddetalle = 0, crear el registro.

                                If elimina > 0 Then
                                    'si eliminar mayor a cero el detalle se anula y la cantidad debe incrementar 
                                    If producto.bitKit Then
                                        'Obtenemos todas las salidas detalle relacionadas al codigo detalle
                                        Dim lSalidaDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = iddetalle _
                                                                                              Select x).ToList

                                        'Recorremos la lista de salidas detalles para actualizar el inventario
                                        For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetalleKit
                                            Dim inventario As Integer = salidaDetalleKit.tipoInventario

                                            'Otenemos el inventario de cada articulo
                                            Dim inv As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                 And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                 And x.idArticulo = idarticulo Select x).FirstOrDefault

                                            inv.saldo += cantidadAnterior * salidaDetalleKit.cantidad
                                            inv.reserva -= cantidadAnterior * salidaDetalleKit.cantidad
                                            conexion.SaveChanges()
                                        Next

                                    ElseIf producto.bitProducto Then
                                        'cuando se elimina el detalle se debe devolver a saldo la cantidad y restar de reserva.

                                        'Incrementar cantidad Anterior al saldo.
                                        inve.saldo += cantidadAnterior
                                        'restar la cantidad anterior de reserva
                                        inve.reserva -= cantidadAnterior

                                        conexion.SaveChanges()
                                    End If
                                ElseIf iddetalle > 0 Then
                                    'Verificamos si es un producto  o un kit
                                    If producto.bitKit Then
                                        'Obtenemos todas las salidas detalle relacionadas al codigo detalle
                                        Dim lSalidaDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = iddetalle _
                                                                                              Select x).ToList

                                        'Recorremos la lista de salidas detalles para actualizar el inventario
                                        For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetalleKit
                                            Dim inventario As Integer = salidaDetalleKit.tipoInventario
                                            'Otenemos el inventario de cada articulo
                                            Dim inv As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                 And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                 And x.idArticulo = idarticulo Select x).FirstOrDefault

                                            inv.saldo += cantidadAnterior * salidaDetalleKit.cantidad
                                            inv.reserva -= cantidadAnterior * salidaDetalleKit.cantidad
                                            inv.saldo -= cantidad * salidaDetalleKit.cantidad
                                            inv.reserva += cantidad * salidaDetalleKit.cantidad
                                            conexion.SaveChanges()
                                        Next
                                    ElseIf producto.bitProducto Then
                                        'No se Eliminar y el id salida detalle si existe, se modificar la cantidad anterior y la nueva cantidad.
                                        If elimina = 0 Then
                                            '-------------CANTIDAD ANTERIOR.
                                            'aumentar al saldo
                                            inve.saldo += cantidadAnterior
                                            'restar de reserva
                                            inve.reserva -= cantidadAnterior

                                            '-------------CANTIDAD NUEVA.
                                            '********
                                            'NUEVO : No debe dejar reservar si la cantidad es mayor a cero
                                            '*********

                                            If inve.saldo >= cantidad Then
                                                'Restar de saldo
                                                inve.saldo -= cantidad
                                                'Incrementar en reserva.
                                                inve.reserva += cantidad
                                            Else
                                                'No se puede reservar
                                                success = False
                                                errContenido = "No se puede reservar el articulo : " & articulo & " , Saldo: " & inve.saldo & ", Pedido: " & cantidad
                                                Exit Try
                                            End If


                                            'guardar cambios
                                            conexion.SaveChanges()
                                        End If
                                    End If
                                ElseIf elimina = 0 And iddetalle = 0 Then
                                    ' si eliminar = 0 y iddetalle = 0, el registro se tiene que crear.
                                    If producto.bitKit Then
                                        'Obtenemos todas las salidas detalle relacionadas al codigo detalle
                                        Dim lSalidaDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = iddetalle _
                                                                                              Select x).ToList

                                        'Recorremos la lista de salidas detalles para actualizar el inventario
                                        For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetalleKit
                                            Dim inventario As Integer = salidaDetalleKit.tipoInventario

                                            ''actualizar el modelo
                                            'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
                                            'conexion.SaveChanges()

                                            'Otenemos el inventario de cada articulo
                                            Dim inv As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                 And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                 And x.idArticulo = idarticulo Select x).FirstOrDefault

                                            If inv.saldo > (cantidad * salidaDetalleKit.cantidad) Then
                                                inv.saldo -= cantidad * salidaDetalleKit.cantidad
                                                inv.reserva += cantidad * salidaDetalleKit.cantidad
                                                conexion.SaveChanges()
                                            End If
                                        Next


                                    ElseIf producto.bitProducto Then
                                        'Se creo un registro nuevo en detalle salida, descontar de saldo e incrementar en reserva.
                                        If inve.saldo >= cantidad Then
                                            'Restar cantidad del saldo.
                                            inve.saldo -= cantidad
                                            'incrementar a reserva.
                                            inve.reserva += cantidad
                                        Else
                                            'alerta.contenido = "Cantidad de articulo: " & articulo & " insuficiente!!"
                                            MessageBox.Show("Saldo Insuficiente !!! de Articulo: " & articulo & " (" & inve.tblArticulo.codigo1 & ", Por :" & (cantidad - inve.saldo))
                                            success = False
                                            Exit Try
                                        End If
                                    End If
                                End If
                                conexion.SaveChanges()
                            End If
                        Next

                        'actualizar el total de la venta.
                        Dim TotalVenta As Double = (From x In conexion.tblSalidas Join y In conexion.tblSalidaDetalles On x.idSalida Equals y.idSalida
                                                  Where x.idSalida = codigo And y.anulado = False Select y.cantidad * y.precio).Sum()

                        salida.total = TotalVenta
                        salida.subtotal = TotalVenta

                        'paso 8, completar la transaccion.
                        transaction.Complete()

                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        success = False
                        ' Handle errors and deadlocks here and retry if needed. 
                        ' Allow an UpdateException to pass through and 
                        ' retry, otherwise stop the execution. 
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                            alerta.fnErrorGuardar()
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            Else
                If errContenido.Trim.Length > 0 Then
                    alerta.contenido = errContenido
                    alerta.fnErrorContenido()
                Else
                    alerta.fnErrorGuardar()
                End If
                Console.WriteLine("La operacion no pudo ser completada")
                Return False
            End If

            'liberar la conexion.
            conn.Close()
        End Using


        'retornar la respuesta de la funcion.
        Return success

    End Function

    '--------------------------------------------  DESPACHO -----------------------------------------
    Private Sub fnGuardarDespacho()

        If fnValidarVencido() = False Then
            Exit Sub
        End If

        fnVerificaLimiteCredito()

        fnVerificarExistencia()

        ''If verificarexistencia = False Then
        ''    RadMessageBox.Show("Debe verificar existencia para poder guardar", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        ''    Exit Sub
        ''End If

        Dim idsalidaimp As Integer

        Dim codcliente As Integer = cmbCliente.SelectedValue
        Dim cliente As String = cmbNombre.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = cmbVendedor.SelectedValue

        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim hora As String = fnHoraServidor()
        Dim success As Boolean = True
        Dim errContenido As String = ""

        Dim autorizaCredito As Boolean = False    'variable que se utiliza para saber si se despliega la fnErrorAutorizacionCredito

        Dim codigoSalidaCredito As Integer = 0
        Dim codigoSalidaContado As Integer = 0

        'contador de pendientes por surtir, automaticamente envia el restante de cantidad y saldo a pendientes por surtir.
        Dim contadorSurtir As Integer = 0
        Dim cantidadSurtir As Double = 0

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First
            Dim usr As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault

            If success Then
                Using transaction As New TransactionScope
                    Try
                        'GUARDAR REGISTRO DE SALIDA.
                        Dim codigosalida As Integer = 0
                        '------------------------------------------------------  crear encabezado.-----------------------------
                        'paso 5, guardar el registro de encabezado

                        Dim salidaCredito As New tblSalida

                        Dim totalCredito As Decimal = 0
                        Try
                            totalCredito = CDec(Replace(txtCredito.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalCredito = 0
                        End Try

                        If (totalCredito > 0) Then
                            'Establecemos la fecha de vencimiento del credito

                            'Sustraemos el correlativo
                            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                                 Select x).FirstOrDefault

                            If rbnCredito.Checked = True Then
                                Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor
                                Dim dia = Weekday(fechaVencimiento, vbMonday)
                                Dim diasCredito As Integer = (From x In conexion.tblClienteTipoPagoes Where x.idtipoPago = cli.idTipoPago Select x.credito).First

                                If diasCredito = 5 Then
                                    If dia = 1 Then
                                        salidaCredito.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito)
                                    Else
                                        salidaCredito.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 1)
                                    End If
                                End If



                                If diasCredito = 20 Then
                                    If dia >= 1 And dia <= 4 Then
                                        salidaCredito.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 3)
                                    Else
                                        salidaCredito.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 4)
                                    End If
                                End If

                            End If

                            salidaCredito.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                            salidaCredito.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                            salidaCredito.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                            salidaCredito.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                            salidaCredito.idTipoMovimiento = codmovimiento
                            salidaCredito.idVendedor = usr.idVendedor

                            salidaCredito.idCliente = codcliente
                            salidaCredito.cliente = cmbNombre.Text
                            salidaCredito.nit = txtNit.Text

                            salidaCredito.fechaTransaccion = fecha
                            salidaCredito.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                            salidaCredito.fechaDespachado = dtpFechaRegistro.Text & " " & hora
                            salidaCredito.observacion = txtObservacion.Text

                            salidaCredito.cotizado = False
                            salidaCredito.reservado = False
                            salidaCredito.despachar = True
                            salidaCredito.facturado = False
                            salidaCredito.empacado = False
                            salidaCredito.anulado = False
                            salidaCredito.fechaAnulado = Nothing
                            salidaCredito.idMunicipio = If(CInt(cmbDirEnvios.SelectedValue) = 0, mdlPublicVars.General_MunicipioLocal, CInt(cmbDirEnvios.SelectedValue))
                            ' salidaCredito.direccionFacturacion = cmbDireccionFacturacion.Text
                            salidaCredito.direccionFacturacion = txtDireccionFacturacion.Text
                            salidaCredito.direccionEnvio = cmbDirEnvios.Text

                            salidaCredito.descuento = Replace(Me.lblDescPromociones.Text, "Q", "")
                            salidaCredito.subtotal = totalCredito
                            salidaCredito.total = totalCredito
                            salidaCredito.pagado = 0
                            salidaCredito.saldo = totalCredito
                            salidaCredito.NOMBREALTERNO = mdlPublicVars.superSearchNombreAlterno
                            salidaCredito.DIRECCIONALTERNA = mdlPublicVars.superSearchDireccionAlterno

                            salidaCredito.contado = False
                            salidaCredito.credito = True
                            salidaCredito.bitguia = False
                            salidaCredito.bitGuiaImpresa = False

                            salidaCredito.bitFacReimpreso = False

                            salidaCredito.documento = correlativo.correlativo + 1
                            correlativo.correlativo = correlativo.correlativo + 1
                            'agregar salida al modelo
                            conexion.AddTotblSalidas(salidaCredito)

                            'Actualizamos la fecha de ultima compra del cliente
                            cli.FechaUltimaCompra = salidaCredito.fechaDespachado

                            'guardar cambios
                            conexion.SaveChanges()
                            codigoSalidaCredito = salidaCredito.idSalida
                            idsalidaimp = salidaCredito.idSalida


                            ' Aca ingresaremos las guias creadas al envio
                            For i As Integer = 0 To tblGuias.Rows.Count - 1
                                Dim envio As New tblEnvio

                                Dim temporal As Integer = CType(tblGuias.Rows(i).Item("Codigo").ToString, Integer)

                                envio.numero = tblGuias.Rows(i).Item("numero").ToString
                                envio.paquetes = tblGuias.Rows(i).Item("paquetes").ToString
                                envio.envioTipo = CType(tblGuias.Rows(i).Item("noEnvioTipo").ToString, Integer)
                                envio.usuario = mdlPublicVars.idUsuario '
                                envio.fechatransaccion = tblGuias.Rows(i).Item("fechatransaccion").ToString
                                envio.observacion = tblGuias.Rows(i).Item("observacion").ToString
                                envio.precio = tblGuias.Rows(i).Item("precio").ToString
                                envio.envio_empresa = CType(tblGuias.Rows(i).Item("envio_empresa").ToString, Integer)

                                conexion.AddTotblEnvios(envio)
                                conexion.SaveChanges()

                                Dim envioSalida As New tblEnvio_Salida
                                envioSalida.envio = envio.codigo
                                envioSalida.salida = salidaCredito.idSalida

                                conexion.AddTotblEnvio_Salida(envioSalida)
                                conexion.SaveChanges()
                            Next
                        End If

                        Dim totalContado As Decimal = 0
                        Try
                            totalContado = CDec(Replace(txtContado.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalContado = 0
                        End Try

                        Dim salida As New tblSalida
                        If (totalContado > 0) Then
                            'Sustraemos el correlativo
                            Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                                 Select x).First

                            salida.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                            salida.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                            salida.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                            salida.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                            salida.idTipoMovimiento = codmovimiento
                            salida.idVendedor = usr.idVendedor

                            salida.idCliente = codcliente
                            salida.cliente = cmbNombre.Text
                            salida.nit = txtNit.Text

                            salida.fechaTransaccion = fecha
                            salida.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                            salida.fechaDespachado = dtpFechaRegistro.Text & " " & hora
                            salida.observacion = txtObservacion.Text
                            salida.bitFacReimpreso = False
                            salida.cotizado = False
                            salida.reservado = False
                            salida.despachar = True
                            salida.facturado = False
                            salida.empacado = False
                            salida.anulado = False
                            salida.fechaAnulado = Nothing
                            salida.idMunicipio = If(CInt(cmbDirEnvios.SelectedValue) = 0, mdlPublicVars.General_MunicipioLocal, CInt(cmbDirEnvios.SelectedValue))
                            salida.descuento = Replace(Me.lblDescPromociones.Text, "Q", "")
                            salida.subtotal = totalContado
                            salida.total = totalContado
                            salida.pagado = 0
                            salida.saldo = totalContado
                            'salida.direccionFacturacion = cmbDireccionFacturacion.Text
                            salida.direccionFacturacion = txtDireccionFacturacion.Text
                            salida.NOMBREALTERNO = mdlPublicVars.superSearchNombreAlterno
                            salida.DIRECCIONALTERNA = mdlPublicVars.superSearchDireccionAlterno

                            salida.direccionEnvio = cmbDirEnvios.Text
                            salida.contado = True
                            salida.credito = False
                            salida.bitguia = False
                            salida.bitGuiaImpresa = False

                            salida.documento = correlativo.correlativo + 1
                            correlativo.correlativo = correlativo.correlativo + 1

                            'agregar salida al modelo
                            conexion.AddTotblSalidas(salida)
                            'Actualizamos la fecha de ultima compra del cliente
                            cli.FechaUltimaCompra = CDate(salida.fechaDespachado.ToString)

                            'guardar cambios
                            conexion.SaveChanges()
                            codigoSalidaContado = salida.idSalida
                            idsalidaimp = salida.idSalida

                            ' Aca ingresaremos las guias creadas al envio
                            For i As Integer = 0 To tblGuias.Rows.Count - 1
                                Dim envio As New tblEnvio

                                Dim temporal As Integer = CType(tblGuias.Rows(i).Item("Codigo").ToString, Integer)

                                envio.numero = tblGuias.Rows(i).Item("numero").ToString
                                envio.paquetes = tblGuias.Rows(i).Item("paquetes").ToString
                                envio.envioTipo = CType(tblGuias.Rows(i).Item("noEnvioTipo").ToString, Integer)
                                envio.usuario = mdlPublicVars.idUsuario '
                                envio.fechatransaccion = tblGuias.Rows(i).Item("fechatransaccion").ToString
                                envio.observacion = tblGuias.Rows(i).Item("observacion").ToString
                                envio.precio = tblGuias.Rows(i).Item("precio").ToString
                                envio.envio_empresa = CType(tblGuias.Rows(i).Item("envio_empresa").ToString, Integer)

                                conexion.AddTotblEnvios(envio)
                                conexion.SaveChanges()

                                Dim envioSalida As New tblEnvio_Salida
                                envioSalida.envio = envio.codigo
                                envioSalida.salida = salida.idSalida

                                conexion.AddTotblEnvio_Salida(envioSalida)
                                conexion.SaveChanges()
                            Next

                        End If
                        '--------------------------------------- fin de crear encabezado. ------------------
                        'paso 6, guardar el detall



                        If (salida.idSalida > 0) Or (salidaCredito.idSalida > 0) Then

                            Dim index
                            Dim cantidad As Double = 0
                            Dim cantidaddisp As Double = 0
                            Dim precio As Decimal = 0
                            Dim total As Decimal = 0
                            Dim idarticulo As Integer = 0
                            Dim nombre As String = ""
                            Dim cantSurtir As Integer = 0 ' sirve cuando el usuario ingresa el pendiente por surtir a comparacion de cantidadSurtir que es automatico.
                            Dim idSurtir As Integer = 0
                            Dim contado As Boolean = True
                            Dim idInventario As Integer = 0
                            Dim tipoPrecio As Integer = 0
                            Dim observacion As String = ""
                            Dim elimina As String = ""
                            Dim bitsurtir As Integer
                            Dim bitNuevo As Integer
                            Dim bitOferta As Integer
                            Dim codigoSurtir As Integer
                            Dim promocion As Double = 0
                            Dim cuotapromocion As Double = 0
                            Dim cantidadpromocion As Double = 0

                            'crear registro de salida bodega.
                            If codigoSalidaContado > 0 Then
                                Dim sb As New tblsalidaBodega
                                sb.idsalida = codigoSalidaContado
                                conexion.AddTotblsalidaBodegas(sb)
                                conexion.SaveChanges()
                            End If

                            If codigoSalidaCredito > 0 Then
                                Dim sb As New tblsalidaBodega
                                sb.idsalida = codigoSalidaCredito
                                conexion.AddTotblsalidaBodegas(sb)
                                conexion.SaveChanges()
                            End If

                            For index = 0 To Me.grdProductos.Rows.Count - 1
                                idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value ' id articulo
                                nombre = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' codigo
                                elimina = Me.grdProductos.Rows(index).Cells("elimina").Value ' columna de eliminar


                                If nombre IsNot Nothing Then
                                    cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value ' cantidad
                                    precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio
                                    total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total
                                    cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value 'surtir
                                    idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value
                                    idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value
                                    tipoPrecio = Me.grdProductos.Rows(index).Cells("tipoPrecio").Value
                                    observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value
                                    bitsurtir = Me.grdProductos.Rows(index).Cells("bitSurtir").Value
                                    bitNuevo = Me.grdProductos.Rows(index).Cells("bitNuevo").Value
                                    bitOferta = Me.grdProductos.Rows(index).Cells("bitOfertas").Value
                                    codigoSurtir = Me.grdProductos.Rows(index).Cells("CodigoSurtir").Value
                                    promocion = Me.grdProductos.Rows(index).Cells("Promocion").Value
                                    cantidadpromocion = Me.grdProductos.Rows(index).Cells("CantidadPromocion").Value
                                    cuotapromocion = Me.grdProductos.Rows(index).Cells("CuotaPromocion").Value

                                    Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).First

                                    Dim detalle As New tblSalidaDetalle

                                    If rbnContado.Checked = True Then
                                        contado = True
                                    Else
                                        contado = Me.grdProductos.Rows(index).Cells("chmContado").Value
                                    End If

                                    If rbnContado.Checked = True Then
                                        detalle.idSalida = codigoSalidaContado
                                    Else
                                        If (Me.grdProductos.Rows(index).Cells("chmContado").Value = True) Then
                                            detalle.idSalida = codigoSalidaContado
                                        Else
                                            detalle.idSalida = codigoSalidaCredito
                                        End If
                                    End If
                                    detalle.anulado = 0
                                    detalle.idArticulo = idarticulo
                                    detalle.cantidad = cantidad
                                    detalle.precio = precio
                                    detalle.costo = articulo.costoIVA
                                    detalle.tipoInventario = idInventario
                                    detalle.tipoPrecio = tipoPrecio
                                    detalle.comentario = observacion
                                    detalle.precioFactura = precio
                                    detalle.agregarTransporte = True
                                    detalle.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                    detalle.valormedida = 1
                                    detalle.bitsurtir = bitsurtir
                                    detalle.bitnuevo = bitNuevo
                                    detalle.bitoferta = bitOferta
                                    detalle.codigosurtir = codigoSurtir
                                    detalle.tipobodega = mdlPublicVars.General_idAlmacenPrincipal
                                    detalle.promocion = promocion
                                    detalle.cuotapromo = cuotapromocion
                                    detalle.cantprom = cantidadpromocion

                                    conexion.AddTotblSalidaDetalles(detalle)
                                    conexion.SaveChanges()

                                    If articulo.bitKit Then


                                        'Obtenemos la lista de los productos asociados a ese kit
                                        Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = articulo.idArticulo _
                                                                                       Select x).ToList

                                        For Each detallekit As tblArticulo_Kit In lDetalleKit

                                            Dim salidaKit As New tblSalidaDetalle
                                            salidaKit.anulado = 0
                                            salidaKit.idArticulo = detallekit.articulo
                                            salidaKit.cantidad = cantidad * detallekit.cantidad
                                            salidaKit.precio = 0
                                            salidaKit.costo = detallekit.tblArticulo1.costoIVA
                                            salidaKit.tipoInventario = idInventario
                                            salidaKit.tipoPrecio = detalle.tipoPrecio
                                            salidaKit.comentario = observacion
                                            salidaKit.kitSalidaDetalle = detalle.idSalidaDetalle
                                            salidaKit.idSalida = detalle.idSalida
                                            detalle.agregarTransporte = True
                                            detalle.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                                            detalle.valormedida = 1
                                            conexion.AddTotblSalidaDetalles(salidaKit)
                                            conexion.SaveChanges()

                                            'descontar existencias.
                                            Dim codArtKit As Integer = detallekit.articulo

                                            ''actualizar el modelo
                                            'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
                                            'conexion.SaveChanges()


                                            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                         And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                         And x.idArticulo = codArtKit Select x).FirstOrDefault



                                            'si es reserva, incrementar la reserva , y decrementar el saldo
                                            If inve.saldo >= (salidaKit.cantidad) Then
                                                inve.saldo = inve.saldo - (salidaKit.cantidad)
                                                inve.salida = inve.salida + (salidaKit.cantidad)
                                                conexion.SaveChanges()
                                            Else

                                                'errContenido = "Error !!!, Existencia insuficiente en Kit, articulo: " + articulo.nombre1
                                                MessageBox.Show("Error !!!, Existencia insuficiente en Kit, articulo: " + articulo.nombre1)
                                                success = False
                                                Exit Try
                                            End If
                                        Next

                                    ElseIf articulo.bitProducto Then
                                        'descontar existencias.
                                        Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                     And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                     And x.idArticulo = idarticulo Select x).FirstOrDefault
                                        'descontamos del inventario

                                        If inve.saldo >= cantidad Then
                                            'restar cantidad del saldo
                                            inve.saldo = inve.saldo - cantidad

                                            'incrementar en salida.
                                            inve.salida += cantidad

                                            'guardar los cambios.
                                            conexion.SaveChanges()

                                        Else
                                            'asignar cantidad al detalle.
                                            detalle.cantidad = inve.saldo
                                            'Cantidad a descontar de surtir
                                            ''cantidad = inve.saldo
                                            'cantidad a surtir.
                                            cantidadSurtir = cantidad - inve.saldo
                                            contadorSurtir = contadorSurtir + 1

                                            'descontar el saldo y enviar a pendientes por surtir.
                                            cantidaddisp = inve.saldo
                                            inve.salida = inve.salida + (inve.saldo)
                                            inve.saldo = 0

                                            'PENDIENTES POR SURTIR.

                                            ''Validacion de que el pendiente por surtir no exista
                                            Dim vsurtir2 As Integer = (From x In conexion.tblSurtirs Where x.articulo = detalle.idArticulo And x.cliente = codcliente And x.saldo > 0 Select x).Count

                                            If vsurtir2 > 0 Then

                                            Else
                                                ''If RadMessageBox.Show("Existencia insuficiente para el articulo: " & articulo.nombre1.Trim() & " (" & articulo.codigo1.Trim() & ") " & vbCrLf _
                                                ''                  & "Cantidad Requerida: " & cantidad & vbCrLf _
                                                ''                  & "Disponible:" & cantidaddisp & vbCrLf _
                                                ''                  & "Desea Surtir de " & articulo.nombre1.Trim() & " (" & articulo.codigo1.Trim() & ") la cantidad de " & cantidadSurtir, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                                                ''    Dim pendiente As New tblSurtir
                                                ''    pendiente.salidaDetalle = detalle.idSalidaDetalle
                                                ''    pendiente.articulo = detalle.idArticulo
                                                ''    pendiente.cantidad = cantidadSurtir
                                                ''    pendiente.saldo = cantidadSurtir
                                                ''    pendiente.fechaTransaccion = fecha
                                                ''    pendiente.anulado = 0
                                                ''    pendiente.usuario = mdlPublicVars.idUsuario
                                                ''    pendiente.vendedor = mdlPublicVars.idVendedor
                                                ''    pendiente.Eliminar = False

                                                ''    If contado = True Then
                                                ''        pendiente.cliente = salida.idCliente
                                                ''    Else
                                                ''        pendiente.cliente = salidaCredito.idCliente
                                                ''    End If

                                                ''    'guardar el pendiente por surtir.
                                                ''    conexion.AddTotblSurtirs(pendiente)
                                                ''    conexion.SaveChanges()

                                                ''End If

                                                'alerta.contenido = "Error !!!, Existencia insuficiente " + articulo.nombre1
                                                RadMessageBox.Show("Existencia insuficiente de " & articulo.nombre1.Trim() & " (" & articulo.codigo1.Trim() & ")  por: " & CInt((cantidad - inve.saldo)), mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                                ''existenciaIns = True
                                                success = False
                                                Exit Try
                                            End If
                                            ''Fin de la validacion de que el pendiente por surtir no exista
                                        End If
                                    ElseIf articulo.bitServicio = True Then

                                        ''actualizar el modelo
                                        'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
                                        'conexion.SaveChanges()


                                        Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                     And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                     And x.idArticulo = idarticulo Select x).FirstOrDefault

                                        'incrementar la salida en el servicio.
                                        inve.salida += cantidad
                                        conexion.SaveChanges()

                                    End If
                                    'Verifiamos si es surtir en la columna del grid view.
                                    If articulo.bitServicio = False Then

                                        ' ''Modificamos el pendiente por surtir, para descontar de los pendientes por surtir del cliente.
                                        ''Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where (x.cliente = salida.idCliente Or x.cliente = salidaCredito.idCliente) _
                                        ''                                       And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Ascending).ToList
                                        ''Dim cantidadDescontar2 As Integer = cantidad

                                        ''For Each p As tblSurtir In pendiente

                                        ''    If cantidadDescontar2 > p.saldo Then
                                        ''        cantidadDescontar2 -= p.saldo
                                        ''        p.saldo = 0
                                        ''    Else
                                        ''        p.saldo -= cantidadDescontar2
                                        ''        cantidadDescontar2 = 0
                                        ''    End If
                                        ''    conexion.SaveChanges()
                                        ''    If cantidadDescontar2 = 0 Then
                                        ''        Exit For
                                        ''    End If
                                        ''Next
                                    End If

                                    Dim vsurtir As Integer = (From x In conexion.tblSurtirs Where x.articulo = detalle.idArticulo And x.cliente = codcliente And x.saldo > 0 Select x).Count

                                    If vsurtir > 0 Then

                                    Else

                                        If cantSurtir > 0 Then
                                            'Creamos el pendiente por surtir
                                            Dim pendiente As New tblSurtir
                                            pendiente.salidaDetalle = detalle.idSalidaDetalle
                                            pendiente.articulo = detalle.idArticulo
                                            pendiente.cantidad = cantSurtir
                                            pendiente.saldo = cantSurtir
                                            pendiente.fechaTransaccion = fecha
                                            pendiente.anulado = 0
                                            pendiente.usuario = mdlPublicVars.idUsuario
                                            pendiente.vendedor = mdlPublicVars.idVendedor
                                            pendiente.Eliminar = False

                                            If contado = True Then
                                                pendiente.cliente = salida.idCliente
                                            Else
                                                pendiente.cliente = salidaCredito.idCliente
                                            End If

                                            conexion.AddTotblSurtirs(pendiente)
                                            conexion.SaveChanges()
                                        End If
                                    End If

                                    Dim clientecombo As Integer = Me.cmbCliente.SelectedValue

                                    'Verificamos si tiene pendientes por surtir
                                    Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                                                         Where Not x.anulado And x.saldo > 0 And x.articulo = idarticulo And x.cliente = clientecombo _
                                                                                         And x.saldo = x.cantidad Select x).ToList
                                    Dim cantidadDescontar As Integer = cantidad
                                    'Recorremos la lista de pendientes
                                    For Each pendiente As tblSurtir In lPendientes

                                        Dim det As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idArticulo = idarticulo And x.idSalida = idsalidaimp Select x).FirstOrDefault

                                        If cantidadDescontar > pendiente.saldo Then
                                            cantidadDescontar -= pendiente.saldo
                                            pendiente.saldo = 0

                                            det.codigosurtir = pendiente.codigo
                                        Else
                                            pendiente.saldo -= cantidadDescontar
                                            cantidadDescontar = 0

                                            det.codigosurtir = pendiente.codigo
                                        End If
                                        conexion.SaveChanges()
                                        conexion.SaveChanges()
                                        If cantidadDescontar = 0 Then
                                            Exit For
                                        End If
                                    Next
                                End If

                            Next    ' fin del for que recorre el grid --------------------------------------------------------------
                        Else
                            RadMessageBox.Show("No se puede realizar la venta, con precio 0", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            success = False
                            Exit Try
                        End If  ' fin if salida.idsalid>0
                        conexion.SaveChanges()

                        'actualizar el total del pedido en el encabezado
                        ''If totalCredito > 0 Then
                        ''    Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False Select x.cantidad * x.precio).Sum
                        ''    salidaCredito.total = totalSalida
                        ''    salidaCredito.subtotal = totalSalida
                        ''    conexion.SaveChanges()

                        ''End If

                        ''If totalContado > 0 Then
                        ''    Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False Select x.cantidad * x.precio).Sum
                        ''    Dim sContado As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigoSalidaContado Select x).FirstOrDefault
                        ''    sContado.total = totalSalida
                        ''    sContado.subtotal = totalSalida
                        ''    conexion.SaveChanges()
                        ''End If

                        If totalCredito > 0 Then
                            Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim totaldesc As Double = 0
                            Try
                                totaldesc = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaCredito And x.anulado = False And x.promocion > 0 Select x.promocion * x.precio).Sum
                            Catch ex As Exception
                                totaldesc = 0
                            End Try
                            salidaCredito.total = totalSalida - totaldesc
                            salidaCredito.subtotal = totalSalida - totaldesc
                            conexion.SaveChanges()
                            mdlPublicVars.superSearchId = codigoSalidaCredito
                        End If

                        If totalContado > 0 Then
                            Dim totalSalida As Double = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim totaldesc As Double = 0
                            Try
                                totaldesc = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = codigoSalidaContado And x.anulado = False And x.promocion > 0 Select x.promocion * x.precio).Sum
                            Catch ex As Exception
                                totaldesc = 0
                            End Try
                            Dim sContado As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigoSalidaContado Select x).FirstOrDefault
                            sContado.total = totalSalida - totaldesc
                            sContado.subtotal = totalSalida - totaldesc
                            conexion.SaveChanges()
                            mdlPublicVars.superSearchId = codigoSalidaContado
                        End If

                        'guardar todos los cambios.
                        conexion.SaveChanges()
                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        MessageBox.Show(ex.Message)
                        success = False
                        MessageBox.Show(ex.Message)
                    Catch ex As Exception
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            success = False
                            MessageBox.Show(ex.Message)
                            Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                            alerta.fnErrorGuardar()
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

            '' ''-----********------------IMPUESTOS-*-*-*-*--*-*-------------------**************
            ''If Activar_Impuestos = True Then
            ''    Dim totalcon As Decimal
            ''    totalcon = CDec(Replace(lblSaldoFinal.Text, "Q", "").Trim)

            ''    Dim impuesto = (From x In conexion.tblImpuestoPagar_TipoMovimiento, y In conexion.tblImpuestoPagar_Impuesto, z In conexion.tblImpuestoes Where y.idImpuestoPagar = x.idImpuestoPagar _
            ''                    And z.idImpuesto = y.idImpuesto And x.idTipoMovimiento = Salida_TipoMovimientoVenta Select z.idImpuesto, z.nombre, z.formula)

            ''    Dim impuestos As DataTable = mdlPublicVars.EntitiToDataTable(impuesto)

            ''    Dim idimpues As Integer = 0
            ''    Dim nombreimpuesto As String = ""
            ''    Dim formu As String = ""
            ''    Dim expresionpostfija As String = ""
            ''    Dim validador As New clsValidar
            ''    Dim convertidor As New clsConvertir
            ''    Dim resuelve As New clsResolver
            ''    Dim impues As Decimal = 0
            ''    Dim totalString As String = ""

            ''    For Each fila As DataRow In impuestos.Rows

            ''        totalString = CStr(totalcon)
            ''        idimpues = fila.Item("idImpuesto")
            ''        nombreimpuesto = fila.Item("nombre")
            ''        formu = fila.Item("formula")
            ''        formu = formu.Replace("dato", CStr(totalString))

            ''        If validador.validar(formu) Then
            ''            expresionpostfija = convertidor.fnConvierte(formu)
            ''            impues = CDec(resuelve.fnResolver(expresionpostfija))

            ''            Dim impuestosalida As New tblImpuesto_Salida
            ''            impuestosalida.idImpuesto = idimpues
            ''            impuestosalida.idSalida = idsalidaimp
            ''            impuestosalida.descripcion = nombreimpuesto
            ''            impuestosalida.valor = impues

            ''            conexion.AddTotblImpuesto_Salida(impuestosalida)
            ''            conexion.SaveChanges()

            ''        End If

            ''    Next
            ''End If
            '' ''-------------************FIN DE IMPUESTOS************----------------------------


            If success = True Then
                conexion.AcceptAllChanges()
            End If

            'cerrar la conexion.
            conn.Close()

        End Using

        If success = True Then
            alerta.fnGuardar()
            bitEditarSalida = False

            mdlPublicVars.superSearchNombreAlterno = ""
            mdlPublicVars.superSearchDireccionAlterno = ""

            'Mostramos la ventana de Bitacora, Usando la Variable global de configuración para conocer si se pide bitacora o No.
            AgregaBitacora(mdlPublicVars.Salida_BitaAlDespachar)
            fnNuevo()

            'preguntar si desea imprimir guias.

            If mdlPublicVars.PuntoVentaPequeno_Activado Then

            Else
                If codigoSalidaContado > 0 Then
                    If RadMessageBox.Show("¿Desea Visualizar e imprimir el Picking?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimirPiking(codigoSalidaContado)
                    End If
                    If RadMessageBox.Show("¿Desea Visualizar e imprimir el Despacho?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimirDespacho(codigoSalidaContado)
                    End If
                    fnGuardarClienteTransporte(codigoSalidaContado)
                End If

                If codigoSalidaCredito > 0 Then
                    If RadMessageBox.Show("¿Desea Visualizar e imprimir el Picking?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimirPiking(codigoSalidaCredito)
                    End If
                    If RadMessageBox.Show("¿Desea Visualizar e imprimir el Despacho?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimirDespacho(codigoSalidaCredito)
                    End If
                    fnGuardarClienteTransporte(codigoSalidaCredito)
                End If
            End If

            'si imprime guia colocar estado de impreso.
            
        Else

            If autorizaCredito = True Then
                alerta.fnErrorAutorizacionCredito()
            Else
                alerta.contenido = "No se puede Guardar por Diferencias en Stock"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    Private Sub fnGuardarClienteTransporte(ByVal idsalida As Integer)
        Try

            frmClienteTransporte.Text = "Impresion Guias"
            frmClienteTransporte.idSalida = idsalida
            frmClienteTransporte.WindowState = FormWindowState.Normal
            frmClienteTransporte.StartPosition = FormStartPosition.CenterScreen
            frmClienteTransporte.ShowDialog()
            frmClienteTransporte.Dispose()

        Catch ex As Exception

        End Try
    End Sub


    Private Function fnModificarDespacho()
        Try
            If fnErrores() = True Then
                Return False
            End If

            Dim codcliente As Integer = cmbCliente.SelectedValue
            Dim cliente As String = cmbNombre.Text
            Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
            Dim codvendedor As Integer = cmbVendedor.SelectedValue
            Dim hora As String = fnHoraServidor()
            Dim fecha As DateTime = fnFecha_horaServidor()
            Dim success As Boolean = True
            Dim errContenido As String = ""
            Dim idCorrelativo As String = ""
            Dim codigoMovPrincipal As Integer = 0

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                If success = True Then
                    Using Transaction As New TransactionScope
                        Try
                            ''Guardar Modificacion Encabezado de Salida
                            Dim s As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault

                            s.observacion = Me.txtObservacion.Text
                            s.descuento = 0
                            s.subtotal = CDec(Me.lblSaldoFinal.Text)
                            s.total = CDec(Me.lblSaldoFinal.Text)
                            s.saldo = s.total
                            s.cliente = cmbNombre.Text
                            conexion.SaveChanges()

                            ''Guardar Modificacion Detalle de Salida
                            ''Dim index
                            Dim cantidad As Double = 0
                            Dim idajuste As Integer = 0
                            Dim cantidadAjuste As Double = 0
                            Dim precio As Decimal = 0
                            Dim total As Decimal = 0
                            Dim idarticulo As Integer = 0
                            Dim idInventario As Integer = 0
                            Dim idSurtir As Integer = 0
                            Dim cantSurtir As Integer = 0
                            Dim observacion As String = ""
                            Dim articulo As String = ""
                            Dim iddetalle As Integer = 0
                            Dim totalAjuste As Decimal = Me.lblSaldoAjuste.Text

                            If totalAjuste <> 0 Then

                                Dim inv As tblInventario
                                Dim tm As tblTipoMovimiento

                                For index As Integer = 0 To Me.grdProductos.Rows.Count - 1
                                    iddetalle = Me.grdProductos.Rows(index).Cells("iddetalle").Value ' id detalle
                                    idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value ' id articulo
                                    articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' codigo
                                    cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value ' cantidad
                                    precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio
                                    total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total
                                    idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value ' total
                                    idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value ' idsurtir
                                    cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value ' cant surtir
                                    observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value   'observacion

                                    inv = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                            And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                            And x.idArticulo = idarticulo Select x).FirstOrDefault

                                    Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                    detalle.precio = precio
                                    detalle.precioFactura = precio
                                    detalle.comentario = observacion
                                    conexion.SaveChanges()

                                    If IsNumeric(Me.grdProductos.Rows(index).Cells("idajustecategoria").Value) Then

                                        Dim c As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = Ajuste_CodigoMovimiento Select x).FirstOrDefault

                                        If c IsNot Nothing Then
                                            c.correlativo += 1
                                            conexion.SaveChanges()
                                            idCorrelativo = c.serie & c.correlativo
                                        Else
                                            Dim cn As New tblCorrelativo
                                            cn.correlativo = 1
                                            cn.serie = ""
                                            cn.inicio = 1
                                            cn.fin = 1000
                                            cn.porcentajeAviso = 20
                                            cn.idEmpresa = mdlPublicVars.idEmpresa
                                            cn.idTipoMovimiento = mdlPublicVars.Ajuste_CodigoMovimiento
                                            conexion.AddTotblCorrelativos(cn)
                                            conexion.SaveChanges()

                                            idCorrelativo = 1
                                        End If

                                        Dim producto As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = idarticulo Select x).FirstOrDefault

                                        idajuste = Me.grdProductos.Rows(index).Cells("idajustecategoria").Value

                                        If idajuste > 0 Then

                                            cantidadAjuste = Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value

                                            tm = (From x In conexion.tblTipoMovimientoes.AsEnumerable Where x.idTipoMovimiento = idajuste Select x).FirstOrDefault

                                            If tm.ajuste Then

                                                Dim m As New tblMovimientoInventario
                                                m.correlativo = idCorrelativo
                                                m.empresa = mdlPublicVars.idEmpresa
                                                m.usuario = mdlPublicVars.idUsuario
                                                m.almacen = mdlPublicVars.General_idAlmacenPrincipal
                                                m.documento = "Vta. " & s.documento
                                                m.tipoMovimiento = Ajuste_CodigoMovimiento
                                                m.inventarioInicial = mdlPublicVars.General_idTipoInventario
                                                m.inventarioFinal = mdlPublicVars.General_idTipoInventario
                                                m.ajuste = True
                                                m.traslado = False
                                                m.anulado = False
                                                m.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                                                m.fechaTransaccion = fecha
                                                m.observacion = "Cod: " & s.idSalida & ",Doc: " & s.documento & ",Cliente: " & s.tblCliente.Negocio
                                                m.revisado = False
                                                m.bitVenta = True
                                                m.bitBodega = False
                                                m.codigoSalida = s.idSalida

                                                conexion.AddTotblMovimientoInventarios(m)
                                                conexion.SaveChanges()

                                                Dim d As New tblMovimientoInventarioDetalle
                                                d.movimientoInventario = m.codigo
                                                d.articulo = detalle.idArticulo
                                                d.cantidad = cantidadAjuste
                                                d.tipoMovimiento = tm.idTipoMovimiento
                                                d.costo = producto.costoIVA
                                                d.total = producto.costoIVA * cantidadAjuste
                                                d.salidaDetalle = detalle.idSalidaDetalle
                                                d.idunidadmedida = 1
                                                d.valormedida = 1
                                                d.entrada = tm.aumentaInventario
                                                d.salida = tm.disminuyeInventario

                                                conexion.AddTotblMovimientoInventarioDetalles(d)
                                                conexion.SaveChanges()

                                                If tm.disminuyeInventario Then
                                                    inv.salida -= cantidadAjuste
                                                    detalle.cantidad -= cantidadAjuste
                                                    conexion.SaveChanges()
                                                ElseIf tm.aumentaInventario Then
                                                    inv.salida -= cantidadAjuste
                                                    inv.saldo += cantidadAjuste
                                                    detalle.cantidad -= cantidadAjuste
                                                    conexion.SaveChanges()

                                                    m.revisado = True
                                                    conexion.SaveChanges()
                                                End If

                                                conexion.SaveChanges()

                                            ElseIf tm.traslado Then

                                                Dim t As New tblMovimientoInventario
                                                t.correlativo = idCorrelativo
                                                t.empresa = mdlPublicVars.idEmpresa
                                                t.usuario = mdlPublicVars.idUsuario
                                                t.almacen = mdlPublicVars.General_idAlmacenPrincipal
                                                t.almacenFinal = mdlPublicVars.General_idAlmacenPrincipal
                                                t.documento = "Vta. " & s.documento
                                                t.tipoMovimiento = Ajuste_CodigoMovimiento
                                                t.inventarioInicial = mdlPublicVars.General_idTipoInventario
                                                t.inventarioFinal = tm.idTipoInventario
                                                t.ajuste = False
                                                t.traslado = True
                                                t.anulado = False
                                                t.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                                                t.fechaTransaccion = fecha
                                                t.observacion = "Cod: " & s.idSalida & ",Doc: " & s.documento & ",Cliente: " & s.tblCliente.Negocio
                                                t.revisado = False
                                                t.bitVenta = True
                                                t.bitBodega = False
                                                t.codigoSalida = s.idSalida

                                                conexion.AddTotblMovimientoInventarios(t)
                                                conexion.SaveChanges()

                                                Dim d As New tblMovimientoInventarioDetalle
                                                d.movimientoInventario = t.codigo
                                                d.articulo = detalle.idArticulo
                                                d.cantidad = cantidadAjuste
                                                d.tipoMovimiento = tm.idTipoMovimiento
                                                d.costo = producto.costoIVA
                                                d.total = producto.costoIVA * cantidadAjuste
                                                d.salidaDetalle = detalle.idSalidaDetalle
                                                d.idunidadmedida = 1
                                                d.valormedida = 1
                                                d.entrada = tm.aumentaInventario
                                                d.salida = tm.disminuyeInventario

                                                conexion.AddTotblMovimientoInventarioDetalles(d)
                                                conexion.SaveChanges()

                                                If tm.idTipoInventario IsNot Nothing Then
                                                    If tm.disminuyeInventario Then

                                                        t.inventarioInicial = mdlPublicVars.General_idTipoInventario
                                                        t.inventarioFinal = tm.idTipoInventario
                                                        conexion.SaveChanges()

                                                        Dim inven As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                                                        If inven Is Nothing Then
                                                            Dim invent As New tblInventario
                                                            invent.idArticulo = detalle.idArticulo
                                                            invent.entrada = 0
                                                            invent.salida = 0
                                                            invent.transito = 0
                                                            invent.reserva = 0
                                                            invent.saldo = 0
                                                            invent.idTipoInventario = tm.idTipoInventario
                                                            invent.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                                                            conexion.AddTotblInventarios(invent)
                                                            conexion.SaveChanges()
                                                        Else
                                                            inven.salida -= cantidadAjuste
                                                            detalle.cantidad -= cantidadAjuste
                                                            conexion.SaveChanges()
                                                        End If

                                                    ElseIf tm.aumentaInventario Then

                                                        t.inventarioFinal = mdlPublicVars.General_idTipoInventario
                                                        t.inventarioInicial = tm.idTipoInventario

                                                        Dim inven As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                                                        If inven Is Nothing Then
                                                            Dim invent As New tblInventario
                                                            invent.idArticulo = detalle.idArticulo
                                                            invent.entrada = 0
                                                            invent.salida = 0
                                                            invent.transito = 0
                                                            invent.reserva = 0
                                                            invent.saldo = 0
                                                            invent.idTipoInventario = tm.idTipoInventario
                                                            invent.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                                                            conexion.AddTotblInventarios(invent)
                                                            conexion.SaveChanges()
                                                        Else
                                                            inven.entrada += cantidadAjuste
                                                            detalle.cantidad -= cantidadAjuste
                                                            conexion.SaveChanges()
                                                        End If

                                                    End If
                                                End If
                                                conexion.SaveChanges()
                                            End If
                                            conexion.SaveChanges()
                                        End If
                                    End If

                                    If idSurtir > 0 Then

                                        Dim pen As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where x.cliente = s.idCliente And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

                                        Dim p As tblSurtir
                                        For Each p In pen
                                            If cantSurtir > p.saldo Then
                                                cantSurtir -= p.saldo
                                                p.saldo = 0
                                            Else
                                                p.saldo -= cantSurtir
                                                cantSurtir = 0
                                            End If
                                            conexion.SaveChanges()
                                            If cantSurtir = 0 Then
                                                Exit For
                                            End If
                                        Next
                                    ElseIf cantSurtir > 0 Then

                                        Dim p As New tblSurtir
                                        p.salidaDetalle = detalle.idSalidaDetalle
                                        p.articulo = detalle.idArticulo
                                        p.cantidad = cantSurtir
                                        p.saldo = cantSurtir
                                        p.fechaTransaccion = fecha
                                        p.anulado = 0
                                        p.usuario = mdlPublicVars.idUsuario
                                        p.vendedor = mdlPublicVars.idVendedor
                                        p.cliente = s.idCliente
                                        p.Eliminar = False

                                        conexion.AddTotblSurtirs(p)
                                        conexion.SaveChanges()
                                    End If

                                Next
                                conexion.SaveChanges()

                                Dim totalventa As Double = (From x In conexion.tblSalidas Join y In conexion.tblSalidaDetalles On x.idSalida Equals y.idSalida Where x.idSalida = codigo And y.anulado = False Select y.cantidad * y.precio).Sum()

                                s.total = totalventa
                                s.subtotal = totalventa

                                conexion.SaveChanges()

                            End If
                            Transaction.Complete()

                        Catch ex As System.Data.EntityException
                            MessageBox.Show(ex.Message)
                            success = False
                            MessageBox.Show(ex.Message)
                        Catch ex As Exception
                            success = False
                            MessageBox.Show(ex.Message)
                            If ex.[GetType]() <> GetType(UpdateException) Then
                                Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                                alerta.fnErrorGuardar()
                                Exit Try
                            End If
                        End Try
                    End Using
                End If

                If success Then
                    conexion.AcceptAllChanges()
                    alerta.fnGuardar()
                End If

                conn.Close()
            End Using

            Return success
        Catch ex As Exception

        End Try
    End Function

    ''Private Function fnModificarDespacho()

    ''    ''If verificarexistencia = False Then
    ''    ''    RadMessageBox.Show("Debe verificar existencia para poder guardar", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    ''    ''    Exit Function
    ''    ''End If

    ''    If fnErrores() = True Then
    ''        Return False
    ''    End If

    ''    Dim codcliente As Integer = cmbCliente.SelectedValue
    ''    Dim cliente As String = cmbNombre.Text
    ''    Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
    ''    Dim codvendedor As Integer = cmbVendedor.SelectedValue
    ''    Dim hora As String = fnHoraServidor()
    ''    Dim fecha As DateTime = fnFecha_horaServidor()
    ''    Dim success As Boolean = True
    ''    Dim errContenido As String = ""
    ''    Dim idCorrelativo As String = ""

    ''    'conexion nueva.
    ''    Dim conexion As New dsi_pos_demoEntities

    ''    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    ''        conn.Open()
    ''        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

    ''        If success = True Then
    ''            Using transaction As New TransactionScope
    ''                Try

    ''                    'GUARDAR REGISTRO DE SALIDA.
    ''                    '------------------------------------------------------  crear encabezado.-----------------------------
    ''                    'paso 5, guardar el registro de encabezado
    ''                    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).First

    ''                    salida.observacion = txtObservacion.Text
    ''                    salida.descuento = 0
    ''                    salida.subtotal = CType(lblSaldoFinal.Text, Double)
    ''                    salida.total = CType(lblSaldoFinal.Text, Double)
    ''                    salida.saldo = salida.total
    ''                    salida.cliente = cmbNombre.Text
    ''                    conexion.SaveChanges()

    ''                    '--------------------------------------- fin de crear encabezado. ------------------
    ''                    'paso 6, guardar el detalle
    ''                    Dim index
    ''                    Dim cantidad As Double = 0
    ''                    Dim idajustecate As Integer = 0
    ''                    Dim cantidadAjuste As Double = 0
    ''                    Dim precio As Decimal = 0
    ''                    Dim total As Decimal = 0
    ''                    Dim idarticulo As Integer = 0
    ''                    Dim idInventario As Integer = 0
    ''                    Dim idSurtir As Integer = 0
    ''                    Dim cantSurtir As Integer = 0
    ''                    Dim observacion As String = ""
    ''                    Dim articulo As String = ""
    ''                    Dim iddetalle As Integer = 0

    ''                    ''crear registro de salida bodega.
    ''                    Dim codigobodega As Integer = 0

    ''                    'Verificamos si existe algun ajuste
    ''                    Dim totalAjuste As Decimal = lblSaldoAjuste.Text

    ''                    Dim codigoMovPrincipal As Integer = 0
    ''                    'Dim codigoMovLiquidacion As Integer = 0

    ''                    If totalAjuste <> 0 Then
    ''                        'Si existe algun cambio entre el pago inicial y el pago ajuste es porque existe un ajuste

    ''                        'Obtenemos el correlativo del ajuste
    ''                        Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = Ajuste_CodigoMovimiento _
    ''                                                             Select x).FirstOrDefault

    ''                        If correlativo IsNot Nothing Then
    ''                            correlativo.correlativo += 1
    ''                            conexion.SaveChanges()
    ''                            idCorrelativo = correlativo.serie & correlativo.correlativo
    ''                        Else
    ''                            'Si no existe el correlativo lo creamos
    ''                            Dim correlativoNuevo As New tblCorrelativo
    ''                            correlativoNuevo.correlativo = 1
    ''                            correlativoNuevo.serie = ""
    ''                            correlativoNuevo.inicio = 1
    ''                            correlativoNuevo.fin = 1000
    ''                            correlativoNuevo.porcentajeAviso = 20
    ''                            correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
    ''                            correlativoNuevo.idTipoMovimiento = mdlPublicVars.Ajuste_CodigoMovimiento
    ''                            conexion.AddTotblCorrelativos(correlativoNuevo)
    ''                            conexion.SaveChanges()

    ''                            'asignar el numero de correlativo.
    ''                            idCorrelativo = 1
    ''                        End If
    ''                        'Procedemos a crear el ajuste
    ''                        '--------ENCABEZADO MOVIMIENTO INVENTARIO PRINCIPAL -------------
    ''                        Dim movimiento As New tblMovimientoInventario
    ''                        movimiento.correlativo = idCorrelativo
    ''                        movimiento.empresa = mdlPublicVars.idEmpresa
    ''                        movimiento.usuario = mdlPublicVars.idUsuario
    ''                        movimiento.almacen = mdlPublicVars.General_idAlmacenPrincipal
    ''                        movimiento.documento = "Vta. " & salida.documento
    ''                        movimiento.bitBodega = True
    ''                        movimiento.bitVenta = False
    ''                        movimiento.tipoMovimiento = Ajuste_CodigoMovimiento
    ''                        movimiento.inventarioInicial = mdlPublicVars.General_idTipoInventario
    ''                        movimiento.inventarioFinal = mdlPublicVars.General_idTipoInventario
    ''                        movimiento.ajuste = True
    ''                        movimiento.traslado = False
    ''                        movimiento.anulado = False
    ''                        movimiento.revisado = True
    ''                        movimiento.fechaRegistro = dtpFechaRegistro.Text & " " & hora
    ''                        movimiento.fechaTransaccion = fecha
    ''                        movimiento.observacion = "Cod: " & salida.idSalida & ",Doc: " & salida.documento & ",Cliente: " & salida.tblCliente.Negocio
    ''                        movimiento.revisado = False
    ''                        movimiento.bitVenta = True
    ''                        movimiento.bitBodega = False
    ''                        movimiento.codigoSalida = salida.idSalida

    ''                        conexion.AddTotblMovimientoInventarios(movimiento)
    ''                        conexion.SaveChanges()

    ''                        codigoMovPrincipal = movimiento.codigo
    ''                    End If

    ''                    For index = 0 To Me.grdProductos.Rows.Count - 1

    ''                        'consultar datos base del registro de producto.
    ''                        iddetalle = Me.grdProductos.Rows(index).Cells("iddetalle").Value ' id detalle
    ''                        idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value ' id articulo
    ''                        articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value ' codigo
    ''                        cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value ' cantidad
    ''                        precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value, "Q", "").Trim) ' precio
    ''                        total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value, "Q", "").Trim) ' total
    ''                        idInventario = Me.grdProductos.Rows(index).Cells("idInventario").Value ' total
    ''                        idSurtir = Me.grdProductos.Rows(index).Cells("idSurtir").Value ' idsurtir
    ''                        cantSurtir = Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value ' cant surtir
    ''                        observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value   'observacion

    ''                        'actualizar el modelo
    ''                        'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
    ''                        'conexion.SaveChanges()

    ''                        'consultar registro de inventario.
    ''                        Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
    ''                                                         And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
    ''                                                         And x.idArticulo = idarticulo Select x).FirstOrDefault

    ''                        'modificar registro de detalle.
    ''                        Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First

    ''                        'actualizar el precio del detalle.
    ''                        detalle.precio = precio

    ''                        detalle.precioFactura = precio
    ''                        detalle.comentario = observacion
    ''                        conexion.SaveChanges()

    ''                        'verificar que id ajuste categoria sea numerico.
    ''                        If IsNumeric(Me.grdProductos.Rows(index).Cells("idajustecategoria").Value) Then ' cantidadAjuste

    ''                            'Obtenemos la informacion del articulo
    ''                            Dim producto As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = idarticulo _
    ''                                                           Select x).FirstOrDefault

    ''                            'obtener del grid view el idajustecategoria.
    ''                            idajustecate = Me.grdProductos.Rows(index).Cells("idajustecategoria").Value

    ''                            'si el codigo de ajuste categoria es mayor a cero, existe
    ''                            If idajustecate > 0 Then
    ''                                'obtener la cantidad a ajustar.
    ''                                cantidadAjuste = Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value

    ''                                'Verificamos si es entrada o salida
    ''                                Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes.AsEnumerable
    ''                                                                    Where x.idTipoMovimiento = idajustecate
    ''                                                                    Select x).FirstOrDefault

    ''                                'Verificamos si es traslado o ajuste
    ''                                If tipoMov.traslado Then
    ''                                    'Creamos un nuevo traslado

    ''                                    'Procedemos a crear el ajuste
    ''                                    '--------ENCABEZADO MOVIMIENTO INVENTARIO PRINCIPAL -------------
    ''                                    Dim traslado As New tblMovimientoInventario
    ''                                    traslado.correlativo = idCorrelativo
    ''                                    traslado.empresa = mdlPublicVars.idEmpresa
    ''                                    traslado.usuario = mdlPublicVars.idUsuario
    ''                                    traslado.almacen = mdlPublicVars.General_idAlmacenPrincipal
    ''                                    traslado.documento = ""
    ''                                    traslado.bitBodega = True
    ''                                    traslado.revisado = True
    ''                                    traslado.bitVenta = False
    ''                                    traslado.tipoMovimiento = Ajuste_CodigoMovimiento
    ''                                    traslado.inventarioInicial = mdlPublicVars.General_idTipoInventario
    ''                                    traslado.inventarioFinal = tipoMov.idTipoInventario
    ''                                    traslado.ajuste = False
    ''                                    traslado.traslado = True
    ''                                    traslado.anulado = False

    ''                                    traslado.fechaRegistro = dtpFechaRegistro.Text & " " & hora
    ''                                    traslado.fechaTransaccion = fecha
    ''                                    traslado.observacion = "Cod: " & salida.idSalida & ",Doc: " & salida.documento & ",Cliente: " & salida.tblCliente.Negocio
    ''                                    traslado.revisado = False
    ''                                    traslado.bitVenta = True
    ''                                    traslado.bitBodega = False
    ''                                    traslado.codigoSalida = salida.idSalida

    ''                                    conexion.AddTotblMovimientoInventarios(traslado)
    ''                                    conexion.SaveChanges()

    ''                                    'Creamos el nuevo detalle del movimiento
    ''                                    Dim detalleAj As New tblMovimientoInventarioDetalle
    ''                                    detalleAj.movimientoInventario = traslado.codigo
    ''                                    detalleAj.articulo = detalle.idArticulo
    ''                                    detalleAj.cantidad = cantidadAjuste
    ''                                    detalleAj.tipoMovimiento = tipoMov.idTipoMovimiento
    ''                                    detalleAj.costo = producto.costoIVA
    ''                                    detalleAj.total = producto.costoIVA * cantidadAjuste
    ''                                    detalleAj.salidaDetalle = detalle.idSalidaDetalle
    ''                                    detalleAj.idunidadmedida = 1
    ''                                    detalleAj.valormedida = 1

    ''                                    detalleAj.entrada = tipoMov.aumentaInventario
    ''                                    detalleAj.salida = tipoMov.disminuyeInventario

    ''                                    conexion.AddTotblMovimientoInventarioDetalles(detalleAj)
    ''                                    conexion.SaveChanges()

    ''                                    'Devolvemos es cantidad al inventario del movimiento
    ''                                    'restar cantidad del detalle.
    ''                                    detalle.cantidad = detalle.cantidad - cantidadAjuste
    ''                                    'guardar los cambios.
    ''                                    conexion.SaveChanges()

    ''                                    If tipoMov.idTipoInventario IsNot Nothing Then

    ''                                        'Verificamos si aumenta o disminuye
    ''                                        If tipoMov.disminuyeInventario Then
    ''                                            traslado.inventarioInicial = mdlPublicVars.General_idTipoInventario
    ''                                            traslado.inventarioFinal = tipoMov.idTipoInventario
    ''                                            conexion.SaveChanges()

    ''                                            'Obtenemos el inventario de se artciulo
    ''                                            Dim inventario As tblInventario = (From x In conexion.tblInventarios
    ''                                                                               Where x.idArticulo = detalle.idArticulo And x.idTipoInventario = tipoMov.idTipoInventario
    ''                                                                               Select x).FirstOrDefault

    ''                                            'decremental el total de la salida o venta.
    ''                                            'salida.total = salida.total - detalleAj.total,, 

    ''                                            'se debe restar del inventario cuando sea diferente al inventario principal o inventario de liquidacion.

    ''                                            '**** DEBERIAS VALIDARSE QUE NO SEA INVENTARIO DE ESTANTERIA O LIQUIDACION PARA AUMENTAR AL SALDO.
    ''                                            If inventario IsNot Nothing Then

    ''                                                'disminuir el saldo del inventario y disminuimos la salida, del tipo de inventario del movimiento segun el articulo
    ''                                                inventario.entrada += cantidadAjuste
    ''                                                inventario.saldo += cantidadAjuste
    ''                                                conexion.SaveChanges()
    ''                                                'Guardamos los cambios

    ''                                            Else
    ''                                                'Cremos el registro en inventario
    ''                                                Dim inveNuevo As New tblInventario

    ''                                                inveNuevo.idArticulo = detalle.idArticulo
    ''                                                inveNuevo.entrada = cantidadAjuste
    ''                                                inveNuevo.salida = 0
    ''                                                inveNuevo.transito = 0
    ''                                                inveNuevo.reserva = 0
    ''                                                inveNuevo.saldo = cantidadAjuste
    ''                                                inveNuevo.idTipoInventario = tipoMov.idTipoInventario
    ''                                                inveNuevo.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

    ''                                                'Agregamos el inventario
    ''                                                conexion.AddTotblInventarios(inveNuevo)
    ''                                                conexion.SaveChanges()

    ''                                            End If

    ''                                        ElseIf tipoMov.aumentaInventario Then

    ''                                            traslado.inventarioFinal = mdlPublicVars.General_idTipoInventario
    ''                                            traslado.inventarioInicial = tipoMov.idTipoInventario

    ''                                            'actualizar el modelo
    ''                                            'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
    ''                                            'conexion.SaveChanges()

    ''                                            'Obtenemos el inventario de se artciulo
    ''                                            Dim inventario As tblInventario = (From x In conexion.tblInventarios
    ''                                                                               Where x.idArticulo = detalle.idArticulo And x.idTipoInventario = tipoMov.idTipoInventario
    ''                                                                               Select x).FirstOrDefault


    ''                                            'incremental el total de la salida o venta.
    ''                                            'salida.total = salida.total + detalleAj.total


    ''                                            '***** DEVERIA VALIDARSE QUE NO SEA EL INVENTARIO PRINCIPAL
    ''                                            If inventario IsNot Nothing Then
    ''                                                'Aumentamos el saldo del inventario y disminuimos la salida
    ''                                                inventario.saldo += cantidadAjuste
    ''                                                inventario.entrada += cantidadAjuste

    ''                                                'Guardamos los cambios
    ''                                                conexion.SaveChanges()
    ''                                            Else
    ''                                                'Cremos el registro en inventario
    ''                                                Dim inveNuevo As New tblInventario

    ''                                                inveNuevo.idArticulo = detalle.idArticulo
    ''                                                inveNuevo.entrada = cantidadAjuste
    ''                                                inveNuevo.salida = 0
    ''                                                inveNuevo.transito = 0
    ''                                                inveNuevo.reserva = 0
    ''                                                inveNuevo.saldo = cantidadAjuste
    ''                                                inveNuevo.idTipoInventario = tipoMov.idTipoInventario
    ''                                                inveNuevo.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

    ''                                                'Agregamos el inventario
    ''                                                conexion.AddTotblInventarios(inveNuevo)
    ''                                                conexion.SaveChanges()

    ''                                            End If
    ''                                            detalle.cantidad = detalle.cantidad + cantidadAjuste
    ''                                        End If
    ''                                    End If
    ''                                ElseIf tipoMov.ajuste Then
    ''                                    'Creamos el nuevo detalle del movimiento
    ''                                    Dim detalleAj As New tblMovimientoInventarioDetalle

    ''                                    detalleAj.movimientoInventario = codigoMovPrincipal
    ''                                    detalleAj.articulo = idarticulo

    ''                                    detalleAj.tipoMovimiento = idajustecate
    ''                                    detalleAj.costo = precio
    ''                                    detalleAj.total = (precio * cantidadAjuste)
    ''                                    detalleAj.salidaDetalle = detalle.idSalidaDetalle
    ''                                    detalleAj.idunidadmedida = UnidadMedidaDefault
    ''                                    detalleAj.valormedida = 1
    ''                                    detalleAj.cantidad = cantidadAjuste
    ''                                    If tipoMov.aumentaInventario = True Then

    ''                                        detalleAj.entrada = True
    ''                                        detalleAj.salida = False
    ''                                    ElseIf tipoMov.disminuyeInventario = True Then
    ''                                        detalleAj.salida = True
    ''                                        detalleAj.entrada = False
    ''                                    End If

    ''                                    conexion.AddTotblMovimientoInventarioDetalles(detalleAj)
    ''                                    conexion.SaveChanges()

    ''                                    'si ajuste categoria es una entrada, quiere decir que es un agregado o suma a la cantidad existente, por lo tanto descontar de inventario.
    ''                                    If tipoMov.disminuyeInventario = True Then
    ''                                        'restar de inventario y guardar registro de ajuste.
    ''                                        inve.saldo = inve.saldo - cantidadAjuste
    ''                                        detalle.cantidad = detalle.cantidad - cantidadAjuste


    ''                                        'actualizar el modelo
    ''                                        conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
    ''                                        conexion.SaveChanges()


    ''                                        ' ''Obtenemos el inventario de se artculo
    ''                                        ''Dim inventario As tblInventario = (From x In conexion.tblInventarios
    ''                                        ''                                   Where x.idArticulo = detalle.idArticulo _
    ''                                        ''                                   And x.idTipoInventario = mdlPublicVars.General_idTipoInventario
    ''                                        ''                                   Select x).FirstOrDefault

    ''                                        ' ''Aumentamos el saldo del inventario y disminuimos la salida
    ''                                        ''inventario.saldo += cantidadAjuste
    ''                                        ''inventario.entrada += cantidadAjuste

    ''                                        ''conexion.SaveChanges()
    ''                                    Else
    ''                                        'si ajuste movimiento no es entrada, es una salida se debe agregar la cantidad de ajuste al inventario.
    ''                                        ''inve.saldo = inve.saldo + cantidadAjuste
    ''                                        inve.salida -= cantidadAjuste
    ''                                        detalle.cantidad = detalle.cantidad - cantidadAjuste
    ''                                        conexion.SaveChanges()
    ''                                        'If detalle.cantidad < 0 Then
    ''                                        '    alerta.contenido = "Error !!!, Cantidad no puede ser menor a cero en articulo : " + articulo.ToString
    ''                                        '    alerta.fnErrorContenido()
    ''                                        '    success = False
    ''                                        '    Exit Try
    ''                                        'End If
    ''                                    End If

    ''                                    If producto.bitKit Then
    ''                                        'Obtenemos la lista del detalle del kit en la tblSalidaDetalle
    ''                                        Dim lSalidaDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = iddetalle _
    ''                                                                                              Select x).ToList

    ''                                        'Recorremos el kit detalle y generamos los ajustes
    ''                                        Dim cantidadAnterior As Integer = 0
    ''                                        For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetalleKit
    ''                                            cantidadAnterior = salidaDetalleKit.cantidad / salidaDetalleKit.tblSalidaDetalle2.cantidad

    ''                                            'Creamos el nuevo detalle del movimiento
    ''                                            Dim detalleAju As New tblMovimientoInventarioDetalle

    ''                                            detalleAju.movimientoInventario = codigoMovPrincipal
    ''                                            detalleAju.articulo = salidaDetalleKit.idArticulo
    ''                                            detalleAju.cantidad = cantidadAjuste * salidaDetalleKit.cantidad
    ''                                            detalleAju.tipoMovimiento = idajustecate
    ''                                            detalleAju.costo = 0
    ''                                            detalleAju.total = 0
    ''                                            detalleAju.salidaDetalle = detalle.idSalidaDetalle

    ''                                            If tipoMov.aumentaInventario = True Then
    ''                                                detalleAju.entrada = True
    ''                                                detalleAju.salida = False
    ''                                            ElseIf tipoMov.disminuyeInventario = True Then
    ''                                                detalleAju.salida = True
    ''                                                detalleAju.entrada = False
    ''                                            End If

    ''                                            conexion.AddTotblMovimientoInventarioDetalles(detalleAju)
    ''                                            conexion.SaveChanges()

    ''                                            'si ajuste categoria es una entrada, quiere decir que es un agregado o suma a la cantidad existente, por lo tanto descontar de inventario.
    ''                                            If tipoMov.disminuyeInventario = True Then
    ''                                                If (inve.saldo - (cantidadAjuste * cantidadAnterior)) >= 0 Then
    ''                                                    'restar de inventario y guardar registro de ajuste.
    ''                                                    'inve.saldo = inve.saldo - cantidadAjuste
    ''                                                    salidaDetalleKit.cantidad = salidaDetalleKit.cantidad - (cantidadAjuste * cantidadAnterior)
    ''                                                    conexion.SaveChanges()
    ''                                                Else
    ''                                                    'cantidad insuficiente, error !!!
    ''                                                    'no hay existencia.
    ''                                                    'alerta.contenido = "Error !!!, Existencia insuficiente de articulo: " + articulo.ToString
    ''                                                    'alerta.fnErrorContenido()
    ''                                                    MessageBox.Show("Error !!!, Existencia insuficiente de articulo: " + articulo.ToString)
    ''                                                    success = False
    ''                                                    Exit Try
    ''                                                End If
    ''                                            Else
    ''                                                'si ajuste movimiento no es entrada, es una salida se debe agregar la cantidad de ajuste al inventario.
    ''                                                'inve.saldo = inve.saldo + cantidadAjuste
    ''                                                salidaDetalleKit.cantidad = salidaDetalleKit.cantidad + (cantidadAjuste * cantidadAnterior)
    ''                                                If detalle.cantidad < 0 Then
    ''                                                    alerta.contenido = "Error !!!, Cantidad no puede ser menor a cero en articulo : " + articulo.ToString
    ''                                                    alerta.fnErrorContenido()
    ''                                                    success = False
    ''                                                    Exit Try
    ''                                                End If
    ''                                            End If
    ''                                        Next
    ''                                    End If
    ''                                    conexion.SaveChanges()
    ''                                End If

    ''                                conexion.SaveChanges()
    ''                            End If
    ''                        End If

    ''                        'Verifiamos si es surtir
    ''                        If idSurtir > 0 Then
    ''                            'Modificamos el pendiente por surtir
    ''                            Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where x.cliente = salida.idCliente And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

    ''                            Dim p As tblSurtir
    ''                            For Each p In pendiente
    ''                                If cantSurtir > p.saldo Then
    ''                                    cantSurtir -= p.saldo
    ''                                    p.saldo = 0

    ''                                Else
    ''                                    p.saldo -= cantSurtir
    ''                                    cantSurtir = 0
    ''                                End If
    ''                                conexion.SaveChanges()
    ''                                If cantSurtir = 0 Then
    ''                                    Exit For
    ''                                End If
    ''                            Next
    ''                        ElseIf cantSurtir > 0 Then
    ''                            'Creamos el pendiente por surtir
    ''                            Dim pendiente As New tblSurtir
    ''                            pendiente.salidaDetalle = detalle.idSalidaDetalle
    ''                            pendiente.articulo = detalle.idArticulo
    ''                            pendiente.cantidad = cantSurtir
    ''                            pendiente.saldo = cantSurtir
    ''                            pendiente.fechaTransaccion = fecha
    ''                            pendiente.anulado = 0
    ''                            pendiente.usuario = mdlPublicVars.idUsuario
    ''                            pendiente.vendedor = mdlPublicVars.idVendedor
    ''                            pendiente.cliente = salida.idCliente
    ''                            pendiente.Eliminar = False

    ''                            conexion.AddTotblSurtirs(pendiente)
    ''                            conexion.SaveChanges()
    ''                        End If

    ''                    Next

    ''                    conexion.SaveChanges()

    ''                    'actualizar el total de la venta.
    ''                    Dim TotalVenta As Double = (From x In conexion.tblSalidas Join y In conexion.tblSalidaDetalles On x.idSalida Equals y.idSalida
    ''                                              Where x.idSalida = codigo And y.anulado = False Select y.cantidad * y.precio).Sum()

    ''                    salida.total = TotalVenta
    ''                    salida.subtotal = TotalVenta


    ''                    conexion.SaveChanges()
    ''                    'paso 8, completar la transaccion.
    ''                    transaction.Complete()

    ''                Catch ex As System.Data.EntityException
    ''                    MessageBox.Show(ex.Message)
    ''                    success = False
    ''                    MessageBox.Show(ex.Message)
    ''                Catch ex As Exception
    ''                    success = False
    ''                    MessageBox.Show(ex.Message)
    ''                    If ex.[GetType]() <> GetType(UpdateException) Then
    ''                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
    ''                        alerta.fnErrorGuardar()
    ''                        Exit Try
    ''                        ' If we get to this point, the operation will be retried. 
    ''                    End If
    ''                End Try
    ''            End Using
    ''        End If


    ''        If success Then
    ''            conexion.AcceptAllChanges()
    ''            alerta.fnGuardar()
    ''        End If

    ''        'cerrar la conexion
    ''        conn.Close()
    ''    End Using


    ''    Return success

    ''End Function

    Private Sub grdProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        fnMuestraCombo()
        fnArticulo_informacion()
    End Sub

    'Muestra en el combo de tipo de ajuste
    Private Sub fnMuestraCombo()
        Dim tbl As New DataTable
        tbl.Columns.Add("Codigo")
        tbl.Columns.Add("Nombre")

        Try
            Dim col As Integer = Me.grdProductos.CurrentColumn.Index
            Dim fil As Integer = Me.grdProductos.CurrentRow.Index

            'Sacado
            If Me.grdProductos.Columns(col).Name.ToString.ToLower = "txbajuste" Then

                Dim cons

                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim u As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                    Dim g As String = (From x In conexion.tblGrupoUsuarios Where x.idGrupo = u.idGrupo Select x.nombre).FirstOrDefault

                    If g.Contains("Ventas") Then
                        cons = (From x In conexion.tblTipoMovimientoes.AsEnumerable
                                Where x.ajusteVenta = True And x.produccion = True
                                Select Codigo = x.idTipoMovimiento, Nombre = x.nombre + " : " + If(x.idTipoInventario Is Nothing, "", x.tblTipoInventario.nombre))
                    ElseIf g.Contains("Bodega") Then
                        cons = (From x In conexion.tblTipoMovimientoes.AsEnumerable
                                    Where x.ajusteVenta = True And x.produccion = False
                                    Select Codigo = x.idTipoMovimiento, Nombre = x.nombre + " : " + If(x.idTipoInventario Is Nothing, "", x.tblTipoInventario.nombre))
                    Else
                        cons = (From x In conexion.tblTipoMovimientoes.AsEnumerable
                                  Where x.ajusteVenta = True
                                  Select Codigo = x.idTipoMovimiento, Nombre = x.nombre + " : " + If(x.idTipoInventario Is Nothing, "", x.tblTipoInventario.nombre))
                    End If

                    conn.Close()
                End Using

                'agregar datos.
                tbl.Rows.Add(CType(0, Integer), "Ninguno")

                Dim item
                For Each item In cons
                    tbl.Rows.Add(item.codigo, item.nombre)
                Next

                With frmCombo.combo
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = tbl
                End With

                frmCombo.Text = "Tipo de Ajuste"
                frmCombo.ShowDialog()

                If mdlPublicVars.superSearchId = 0 Then
                    Me.grdProductos.Rows(fil).Cells("idajustecategoria").Value = 0
                    Me.grdProductos.Rows(fil).Cells("txbAjuste").Value = ""
                    Me.grdProductos.Rows(fil).Cells("txmCantidadAjuste").Value = ""
                Else
                    'actualizar
                    Me.grdProductos.Rows(fil).Cells("idajustecategoria").Value = mdlPublicVars.superSearchId
                    Me.grdProductos.Rows(fil).Cells("txbAjuste").Value = mdlPublicVars.superSearchNombre
                End If
            End If ' fin de sacado.

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

        fnActualizar_Total()
    End Sub

    'NUEVO
    Private Sub pbNuevo_Click() Handles Me.panel0
        'bitEditarBodega = False
        'If fnCuentaArticulos() Then
        '    If RadMessageBox.Show("Esta venta no ha sigo guardada, ¿desea realizar una nueva venta?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        fnNuevo()
        '    End If
        'End If
        Dim formPedido As New frmSalidas
        formPedido.Text = "Ventas"
        formPedido.bitEditarBodega = False
        formPedido.bitEditarSalida = False
        formPedido.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmEspeciales(formPedido, False)
        ''Me.LayoutMdi(MdiLayout.Cascade)

        Me.cmbCliente.Select()
        Me.cmbCliente.Focus()
    End Sub

    'COTIZAR
    Private Sub pbCotizar_Click() Handles Me.panel1

        If bitEditarBodega = True Or bitEditarSalida = True Then
            alerta.fnUtiliceModificar()
            Exit Sub
        End If
        If fnErrores() = False Then
            fnGuardarCotizacion()
        End If
    End Sub
    Private Sub pbSugerir_Click() Handles Me.panel9
        esventa = True

        frmSugerir3.StartPosition = FormStartPosition.CenterScreen
        frmSugerir3.OpcionRetorno = "Salida"
        frmSugerir3.Text = "Sugerir Articulos"
        frmSugerir3.codClie = Me.cmbCliente.SelectedValue
        frmSugerir3.bitCliente = True
        frmSugerir3.idInventario = mdlPublicVars.General_idTipoInventario
        frmSugerir3.idBodega = mdlPublicVars.General_idAlmacenPrincipal
        frmSugerir3.bitProveedor = True
        frmSugerir3.venta = 1
        frmSugerir3.formSalida = Me
        permiso.PermisoFrmEspeciales(frmSugerir3, False)
    End Sub

    'RESERVAR
    Private Sub pbReservar_Click() Handles Me.panel2
        If bitEditarBodega = True Or bitEditarSalida = True And bitSugerirDespacho = False And bitSugerirReserva = False Then
            alerta.fnUtiliceModificar()
            Exit Sub
        End If
        If bitSugerirReserva = True Then
            fnModificarCotizacion()
            'Obtenemos la salida
            Dim salida As tblSalida
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using

            CambiacotizarAreservar(salida.idSalida, salida.credito, salida.idCliente)

            Me.Close()
        ElseIf fnErrores() = False Then
            fnGuardarReserva()
        End If
    End Sub

    'DESPACHAR
    Private Sub pbGuardar_Click() Handles Me.panel3
            If bitEditarBodega Or bitEditarSalida And Not bitSugerirDespacho And Not bitEditarSalida Then
                alerta.fnUtiliceModificar()
                Exit Sub
            End If

            If bitSugerirDespacho = True Then
                fnModificarCotizacion()

                'Obtenemos la salida
                Dim salida As tblSalida

                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                    salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                    conn.Close()
                End Using

                If CambiacotizarAdespacho(salida.idSalida, salida.credito, salida.idCliente) Then
                    'Mandar a imprimir el despacho
                    If RadMessageBox.Show("¿Desea Visualizar e imprimir el Picking?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimirPiking(salida.idSalida)
                    End If
                    If RadMessageBox.Show("¿Desea Visualizar e imprimir el Despacho?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimirDespacho(salida.idSalida)
                    End If
                    fnNuevo()
                    Me.Close()
                    bitEditarSalida = False
                    bitSugerirDespacho = False
                    bitSugerirReserva = False
                End If
        ElseIf fnErrores() = False Then

            If mdlPublicVars.PuntoVentaPequeno_Activado Then
                fnDespachar_Click()
            Else
                If RadMessageBox.Show("¿Desea realizar despacho?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    fnGuardarDespacho()
                End If
            End If
        End If
    End Sub

    'Funcion utilizada para imprimir el despacho
    ''Private Sub fnImprimir(ByVal codSalida)
    ''    Dim c As New clsReporte
    ''    'conexion nueva.
    ''    Dim conexion As New dsi_pos_demoEntities

    ''    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    ''        conn.Open()
    ''        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
    ''        Try
    ''            c.tabla = EntitiToDataTable(conexion.sp_reportePickingPedido("", codSalida))
    ''        Catch ex As Exception
    ''        End Try
    ''        conn.Close()
    ''    End Using

    ''    c.nombreParametro = "@filtro"
    ''    c.reporte = "ventas_Picking.rpt"
    ''    c.parametro = ""
    ''    c.verReporte()


    ''End Sub

    'Funcion utilizada para imprimir el despacho
    Private Sub fnImprimirPiking(ByVal codSalida)
        Dim c As New clsReporte
        Dim tabla As DataTable

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            tabla = EntitiToDataTable(conexion.sp_reportePickingPedido("", codSalida))
            conn.Close()
        End Using

        Try
            c.tabla = tabla
            c.nombreParametro = "@filtro"
            c.reporte = "ventas_Picking.rpt"
            c.parametro = ""
            c.verReporte()
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    Private Sub fnImprimirDespacho(ByVal codSalida)
        Dim c As New clsReporte
        Dim tabla As DataTable

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            tabla = EntitiToDataTable(conexion.sp_ReporteVenta("", True, codSalida))
            conn.Close()
        End Using

        Try
            c.tabla = tabla
            c.nombreParametro = "@filtro"
            c.reporte = "ventas_CotizacionLocal.rpt"
            c.parametro = ""
            c.verReporte()
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    'MODIFICAR
    Private Sub pbModificar_Click() Handles Me.panel4

        If fnErrores() = False Then
        Else
            Exit Sub
        End If

        Dim success As Boolean = False

        If chkDespachado.Checked = True And bitEditarBodega = False Then
            alerta.fnNoEditable()
            Exit Sub
        ElseIf chkDespachado.Checked = True And bitEditarBodega = True Then

            If RadMessageBox.Show("Desea modificar el despacho ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                success = fnModificarDespacho()
            End If

        ElseIf chkReservado.Checked = True Then
            If RadMessageBox.Show("Desea modificar la reserva ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                success = fnModificarReserva()
            End If


            'End If

        ElseIf chkCotizado.Checked = True Then
            If RadMessageBox.Show("Desea modificar la cotización ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                success = fnModificarCotizacion()
            End If
        End If


        If success = True Then
            fnLlenarDatos()
            Me.Close()
        End If

    End Sub

    'BITACORA
    Private Sub pbBitacora_Click() Handles Me.panel5
        Try
            If CInt(cmbCliente.SelectedValue) > 0 Then
                frmBitacora.idCliente = cmbCliente.SelectedValue
                frmBitacora.idVendedor = cmbVendedor.SelectedValue
                frmBitacora.fecha = dtpFechaRegistro.Value
                frmBitacora.Text = "Bitacora"
                frmBitacora.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoFrmEspeciales(frmBitacora, False)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pbxInformacionCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoCliente.Click
        Try
            Dim codCliente As Integer = CInt(cmbCliente.SelectedValue)
            If codCliente > 0 Then
                frmInformacionCliente.codcliente = cmbCliente.SelectedValue.ToString
                frmInformacionCliente.ventaActual = txtCredito.Text
                frmInformacionCliente.Text = "Informacion de Cliente"
                frmInformacionCliente.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmInformacionCliente)
                frmInformacionCliente.Dispose()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub AgregaBitacora(ByVal seguir As Boolean)
        If seguir = True Then
            Try
                frmBitacora.idCliente = cmbCliente.SelectedValue
                frmBitacora.idVendedor = cmbVendedor.SelectedValue
                frmBitacora.fecha = dtpFechaRegistro.Value
                frmBitacora.Text = "Bitacora"
                frmBitacora.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmBitacora)
                frmBitacora.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grdProductos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.ValueChanged
        Dim fila As Integer = Me.grdProductos.CurrentRow.Index
        Dim col As Integer = Me.grdProductos.CurrentColumn.Index
        If fila >= 0 Then
            If col = 7 Then
                ''dtpFechaRegistro.Focus()
                ''dtpFechaRegistro.Select()
                fnActualizar_Total()
                Me.grdProductos.Focus()
                Me.grdProductos.Rows(fila).Cells(col).IsSelected = True
            End If
        End If

    End Sub

    Private Sub cmbNombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombre.SelectedIndexChanged
        Dim idCliente As Integer = CType(cmbCliente.SelectedValue, Integer)
        Dim noNit As Integer = CType(cmbNombre.SelectedValue, Integer)

        Dim cliente As tblCliente
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
            cliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).FirstOrDefault
            conn.Close()

            If idCliente > 0 Then
                Try


                    Dim oferta As tblCliente_Precio = (From x In conexion.tblCliente_Precio Where x.precio = mdlPublicVars.BuscarArticulo_CodigoOferta And x.cliente = idCliente Select x).FirstOrDefault

                    If oferta Is Nothing Then

                        btnDetalleOfertas.Visible = False
                        lblConteoOfertas.Visible = False
                        lblFondoOferta.Visible = False
                        Label29.Visible = False
                    Else

                        btnDetalleOfertas.Visible = True
                        lblConteoOfertas.Visible = True
                        lblFondoOferta.Visible = True
                        Label29.Visible = True

                    End If

                Catch ex As Exception

                End Try
            End If



        End Using




        txtNit.Enabled = cliente.bitMostrador

        ' cmbDireccionFacturacion.Enabled = cliente.bitMostrador

        If noNit = 1 Then
            txtNit.Text = cliente.nit1
            txtDireccionFacturacion.Text = cliente.direccionFactura1
            ' cmbDireccionFacturacion.Text = cliente.direccionFactura1

            ''llenar el como de Resolulcion
            'With Me.cmbDireccionFacturacion
            '    .DataSource = Nothing
            '    .ValueMember = "Codigo"
            '    .DisplayMember = "Nombre"
            '    .DataSource = 
            'End With

        ElseIf noNit = 2 Then
            txtNit.Text = cliente.nit2
            'cmbDireccionFacturacion.Text = cliente.direccionFactura2
            txtDireccionFacturacion.Text = cliente.direccionFactura2
        End If

    End Sub

    Private Sub grdProductos_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdProductos.MouseClick
        Try
            Dim fila As Integer = Me.grdProductos.CurrentRow.Index
            Dim col As Integer = Me.grdProductos.CurrentColumn.Index
            If fila >= 0 Then
                If grdProductos.Columns(col).Name = "chmContado" Then
                    ''dtpFechaRegistro.Focus()
                    ''dtpFechaRegistro.Select()
                    fnActualizar_Total()
                    Me.grdProductos.Focus()
                    Me.grdProductos.Rows(fila).Cells(col).IsSelected = True
                Else
                    Me.grdProductos.Rows(fila).Cells(col).IsSelected = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    'Maneja el evento de la tecla DELETE, cuando se quiere modificar una salida
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown

        If Me.grdProductos.RowCount > 0 Then
            If bitEditarSalida = True And verRegistro = False Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdProductos, "iddetalle")
                If e.KeyCode = Keys.Delete And grdProductos.RowCount = 0 Then
                    grdProductos.Rows.AddNew()
                End If

                fnActualizar_Total()
            End If

            Dim c As Integer = Me.grdProductos.CurrentColumn.Index
            Dim f As Integer = 0

            Try
                f = Me.grdProductos.CurrentRow.Index
            Catch ex As Exception
                f = -1
            End Try


            If bitEditarBodega = False And verRegistro = False And f >= 0 Then
                If e.KeyCode = Keys.F2 Then
                    If Me.grdProductos.Columns(c).Name = "txbPrecio" Then

                        ' Dim estado As Integer = CType(Me.grdProductos.Rows(f).Cells("clrEstado").Value, Integer)
                        'If (estado = 1 Or estado = 2) Then

                        frmBuscarArticuloPrecios.Text = "Precios"
                        frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                        frmBuscarArticuloPrecios.codClie = CInt(cmbCliente.SelectedValue)
                        frmBuscarArticuloPrecios.bitVentas = True
                        frmBuscarArticuloPrecios.idtipoinventario = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("idinventario").Value, Integer)
                        frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                        frmBuscarArticuloPrecios.formSalida = Me
                        permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)


                        ' End If



                    ElseIf Me.grdProductos.Columns(c).Name = "txbObservacion" Then
                        'Obtenemos el valor de la observacion actual
                        Dim texto As String = Me.grdProductos.Rows(f).Cells(c).Value

                        frmTexto.Text = "Ingresar Observación"
                        frmTexto.texto = If(texto Is Nothing, "", texto)
                        frmTexto.StartPosition = FormStartPosition.CenterScreen
                        frmTexto.ShowDialog()

                        If mdlPublicVars.superSearchId > 0 Then
                            If frmTexto.guarda = True Then
                                Me.grdProductos.Rows(f).Cells(c).Value = mdlPublicVars.superSearchNombre
                            End If
                        End If

                    Else
                        If (CInt(cmbCliente.SelectedValue > 0)) Then
                            If Me.grdProductos.CurrentRow.Index >= 0 Then
                                If Me.grdProductos.Rows(f).Cells(c).Value Is Nothing Then
                                    mdlPublicVars.superSearchNombre = ""
                                Else
                                    mdlPublicVars.superSearchNombre = LTrim(RTrim(Me.grdProductos.Rows(f).Cells(c).Value))
                                End If

                                Try
                                    frmBuscarArticulo.codClie = cmbCliente.SelectedValue
                                    frmBuscarArticulo.codVendedor = cmbVendedor.SelectedValue
                                    frmBuscarArticulo.StartPosition = FormStartPosition.CenterScreen
                                    frmBuscarArticulo.OpcionRetorno = "salidas"
                                    frmBuscarArticulo.Text = "Buscar Articulos"
                                    frmBuscarArticulo.bitCliente = True
                                    frmBuscarArticulo.idInventario = Me.cmbInventario.SelectedValue
                                    frmBuscarArticulo.idBodega = Me.cmbBodega.SelectedValue
                                    frmBuscarArticulo.bitProveedor = False
                                    frmBuscarArticulo.grdIngresados = grdProductos
                                    frmBuscarArticulo.venta = 1
                                    frmBuscarArticulo.formSalida = Me
                                    permiso.PermisoDialogEspeciales(frmBuscarArticulo)
                                Catch ex As Exception
                                    MessageBox.Show("Error al cargar formulario de buscar " + ex.ToString)
                                End Try



                            End If
                        Else
                            alerta.contenido = "Seleccione Cliente"
                            alerta.fnErrorContenido()
                            cmbCliente.Focus()
                        End If
                    End If
                End If

            ElseIf bitEditarBodega And f >= 0 Then
                If Me.grdProductos.Columns(c).Name = "txbAjuste" Then
                    'fnMuestraCombo()
                    mdlPublicVars.superSearchId = "0"
                    mdlPublicVars.superSearchNombre = ""
                    fnMuestraCombo()
                ElseIf e.KeyCode = Keys.F2 Then


                    If Me.grdProductos.Columns(c).Name = "txbObservacion" Then
                        'Obtenemos el valor de la observacion actual
                        Dim texto As String = Me.grdProductos.Rows(f).Cells(c).Value

                        frmTexto.Text = "Ingresar Observacion"
                        frmTexto.texto = If(texto Is Nothing, "", texto)
                        frmTexto.StartPosition = FormStartPosition.CenterScreen
                        frmTexto.ShowDialog()

                        If mdlPublicVars.superSearchId > 0 Then
                            If frmTexto.guarda = True Then
                                Me.grdProductos.Rows(f).Cells(c).Value = mdlPublicVars.superSearchNombre
                            End If
                        End If
                    ElseIf Me.grdProductos.Columns(c).Name = "txbPrecio" Then
                        Dim estado As Integer = CType(Me.grdProductos.Rows(f).Cells("clrEstado").Value, Integer)
                        ' If (estado = 1 Or estado = 2) Then
                        frmBuscarArticuloPrecios.Text = "Precios"
                        frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                        frmBuscarArticuloPrecios.codClie = CInt(cmbCliente.SelectedValue)
                        frmBuscarArticuloPrecios.bitVentas = True
                        frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                        frmBuscarArticuloPrecios.formSalida = Me
                        permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)


                        'End If
                    End If
                End If
            End If

            'Para poder editar
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            If e.KeyValue >= 48 And e.KeyValue <= 105 Then
                If fila >= 0 Then
                    Me.grdProductos.Rows(fila).Cells(Me.grdProductos.CurrentColumn.Index).BeginEdit()
                End If
            End If
        End If


    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        Try
            If Me.grdProductos.Rows.Count = 0 Then
                Me.grdProductos.Rows.AddNew()
                cmbCliente.Enabled = True
            End If
            fnBloquearCombo()

            fnActualizar_Total()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para bloquear cliente
    Public Sub fnBloquearCombo()
        Try
            'Obtenemos  el numero de filas
            Dim filas As Integer = CInt(Me.grdProductos.Rows.Count)

            If filas > 1 Then
                cmbCliente.Enabled = False
                cmbInventario.Enabled = False
                cmbBodega.Enabled = False
            ElseIf filas = 1 Then
                'Verificamos si tiene informacion la fila
                Dim nombre As String = ""
                Try
                    nombre = Me.grdProductos.Rows(0).Cells("txbProducto").Value
                Catch ex As Exception
                    nombre = ""
                End Try

                If nombre IsNot Nothing Then
                    cmbCliente.Enabled = False
                    cmbInventario.Enabled = False
                    cmbBodega.Enabled = False
                Else
                    cmbCliente.Enabled = True
                    cmbInventario.Enabled = True
                    cmbBodega.Enabled = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Cuando se da TAB en la fecha de registro o simplemente damos el foco a otro control
    Private Sub dtpFechaRegistro_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaRegistro.Leave
        txtClave.Focus()
    End Sub

    'Cuando se da TAB en el combo de cliente o simplemente damos el foco a otro control
    Private Sub cmbCliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.Leave
        ''cmbNombre.Focus()
    End Sub

    'Cuando se da TAB en el combo de elegir nombre o simplemente damos el foco a otro control
    Private Sub cmbNombre_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombre.Leave
        'Nos posicionamos en el grid
        Me.grdProductos.Select()
        Me.grdProductos.Focus()
        Me.grdProductos.Rows(0).IsCurrent = True
        Me.grdProductos.Columns("txbProducto").IsCurrent = True
    End Sub

    'Procedimiento que permite cambiar el Estado de una salida de Cotizado a Despachado.
    Public Function CambiacotizarAdespacho(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()



        'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
        Dim ArtEmpresa

        'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
        Dim NombreArt As String
        Dim CodArticulo As Integer
        Dim Pedido As Integer
        Dim saldo As Integer
        Dim tInventario As Integer



        'conexion nueva.
        Dim conexion2 As New dsi_pos_demoEntities

        Using conn2 As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn2.Open()
            conexion2 = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim Detalles As List(Of tblSalidaDetalle) = (From x In conexion2.tblSalidaDetalles.AsEnumerable
                                                             Join y In conexion2.tblArticuloes On x.idArticulo Equals y.idArticulo
                                                             Where x.idSalida = codigo And Not x.anulado
                                                             Select x).ToList

            'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
            For Each fila As tblSalidaDetalle In Detalles
                NombreArt = fila.tblArticulo.nombre1
                CodArticulo = fila.idArticulo
                Pedido = fila.cantidad
                tInventario = fila.tipoInventario

                'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                ArtEmpresa = (From AE In conexion2.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                  And AE.idArticulo = CodArticulo And AE.idTipoInventario = tInventario Select AE).First

                If ArtEmpresa.saldo < Pedido Then
                    saldo = Pedido - ArtEmpresa.saldo
                    'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                    errContenido = errContenido & "El articulo: " & Trim(NombreArt) & ", Codigo: " & Trim(fila.tblArticulo.codigo1) & vbCrLf & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo & vbCrLf
                    success = False
                End If

            Next

            conn2.Close()
        End Using

        'Si existe un error mandamos el mensaje e interrumpimos la aplicación
        If success = False Then
            MessageBox.Show(errContenido)
            Exit Function
        End If

        'crear la conexion.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


            Using transaction As New TransactionScope
                Try

                    Dim Detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles.AsEnumerable
                                                             Join y In conexion.tblArticuloes On x.idArticulo Equals y.idArticulo
                                                             Where x.idSalida = codigo And Not x.anulado
                                                             Select x).ToList

                    'crear registro de salida bodega.
                    Dim sb As New tblsalidaBodega
                    sb.idsalida = codigo
                    conexion.AddTotblsalidaBodegas(sb)
                    conexion.SaveChanges()

                    'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                    Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                                  Where x.idSalida = codigo Select x).First

                    'pasar despachar a true
                    If EsCredito = True Then
                        Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor
                        Dim dia = Weekday(fechaVencimiento, vbMonday)
                        Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = CodCliente Select x).First
                        Dim diasCredito As Integer = (From x In conexion.tblClienteTipoPagoes Where x.idtipoPago = cli.idTipoPago Select x.dias).First

                        If diasCredito = 5 Then
                            If dia = 1 Then
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito)
                            Else
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 1)
                            End If
                        End If

                        If diasCredito = 20 Then
                            If dia >= 1 And dia <= 4 Then
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 3)
                            Else
                                salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 4)
                            End If
                        End If
                    End If
                    salida.despachar = True
                    salida.fechaDespachado = fecha
                    conexion.SaveChanges()

                    'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                    Dim idInventario As Integer = 0
                    Dim idDetalle As Integer = 0

                    For Each fila As tblSalidaDetalle In Detalles
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        idInventario = fila.tipoInventario
                        idDetalle = fila.idSalidaDetalle

                        If fila.tblArticulo.bitKit Then
                            'Obtenemos la lista de los productos asociados a ese kit
                            Dim lDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = idDetalle And x.anulado = False _
                                                                           Select x).ToList

                            For Each detallekit As tblSalidaDetalle In lDetalleKit
                                'descontar existencias.
                                Dim codArtKit As Integer = detallekit.idArticulo
                                Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                             And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                             And x.idArticulo = codArtKit Select x).FirstOrDefault

                                'si es reserva, incrementar la reserva , y decrementar el saldo
                                If inve.saldo >= (fila.cantidad * detallekit.cantidad) Then
                                    inve.saldo = inve.saldo - (fila.cantidad * detallekit.cantidad)
                                    inve.salida = inve.salida + (fila.cantidad * detallekit.cantidad)
                                    conexion.SaveChanges()
                                Else
                                    'alerta.contenido = "Error !!!, Existencia insuficiente en Kit, articulo: " + detallekit.tblArticulo.nombre1
                                    'alerta.fnErrorContenido()
                                    MessageBox.Show("Error !!!, Existencia insuficiente en Kit, articulo: " + detallekit.tblArticulo.nombre1)
                                    success = False
                                    Exit Try
                                End If
                            Next
                        ElseIf fila.tblArticulo.bitProducto Then

                            'descontar existencias.
                            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                         And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                         And x.idArticulo = CodArticulo Select x).FirstOrDefault

                            'descontamos del inventario
                            If inve.saldo >= fila.cantidad Then
                                inve.saldo = inve.saldo - fila.cantidad
                                inve.salida += fila.cantidad
                                conexion.SaveChanges()
                            Else
                                'alerta.contenido = "Error !!!, Existencia insuficiente " & fila.tblArticulo.nombre1
                                'alerta.fnErrorContenido()
                                MessageBox.Show("Error !!!, Existencia insuficiente " & fila.tblArticulo.nombre1)
                                success = False
                                Exit Try
                            End If
                        End If

                        'Verificamos si tiene pendientes por surtir
                        Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                                             Where Not x.anulado And x.saldo > 0 And x.articulo = CodArticulo
                                                                             Select x).ToList
                        Dim cantidadDescontar As Integer = fila.cantidad
                        'Recorremos la lista de pendientes
                        For Each pendiente As tblSurtir In lPendientes

                            Dim det As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalida = salida.idSalida And x.idArticulo = CodArticulo Select x).FirstOrDefault

                            If cantidadDescontar > pendiente.saldo Then
                                cantidadDescontar -= pendiente.saldo
                                pendiente.saldo = 0

                                det.codigosurtir = pendiente.codigo

                            Else
                                pendiente.saldo -= cantidadDescontar
                                cantidadDescontar = 0

                                det.codigosurtir = pendiente.codigo

                            End If
                            conexion.SaveChanges()
                            conexion.SaveChanges()
                            If cantidadDescontar = 0 Then
                                Exit For
                            End If
                        Next
                    Next

                    'completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                Catch ex As Exception
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                    End If
                End Try
            End Using

            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion.
            conn.Close()

            'finalizar el ciclo.
        End Using


        Return success
    End Function

    'Procedimiento que permite cambiar el Estado de una salida de Cotizado a á Reservado.
    Public Function CambiacotizarAreservar(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()


        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


            Using transaction As New TransactionScope
                Try
                    'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
                    Dim ArtEmpresa
                    'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                    Dim NombreArt As String
                    Dim CodArticulo As Integer
                    Dim Pedido As Integer
                    Dim saldo As Integer
                    Dim tInventario As Integer
                    Dim detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles
                                                                 Where x.idSalida = codigo And x.anulado = False
                                                                Select x).ToList

                    'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
                    For Each fila As tblSalidaDetalle In detalles
                        NombreArt = fila.tblArticulo.nombre1
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        tInventario = fila.tipoInventario
                        'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                        ArtEmpresa = (From AE In conexion.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                      And AE.idArticulo = CodArticulo And AE.idTipoInventario = tInventario Select AE).First

                        If ArtEmpresa.saldo < Pedido Then
                            saldo = Pedido - ArtEmpresa.saldo
                            'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                            errContenido = errContenido & "El articulo: " & NombreArt & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo & vbCrLf
                            success = False
                        End If
                    Next

                    'Si existe un error mandamos el mensaje e interrumpimos la aplicación
                    If success = False Then
                        alerta.contenido = errContenido
                        alerta.fnFaltantes()
                        Exit Try
                    End If

                    If success = False Then
                        Exit Try
                    End If

                    'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                    Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                                  Where x.idSalida = codigo Select x).FirstOrDefault

                    'Definimos la fecha en que vencerá la reserva
                    Dim diaSemana As Integer = Weekday(mdlPublicVars.fnFecha_horaServidor, vbMonday)
                    Dim fechaActual As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim fechaReserva As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim dias As Integer = 0
                    Try
                        Dim cadDias As String = InputBox("Ingrese dias de reserva", "Informacion", mdlPublicVars.Salida_ReservaDias)
                        dias = CInt(cadDias)
                    Catch ex As Exception
                        dias = mdlPublicVars.Salida_ReservaDias
                    End Try

                    If (diaSemana = 1) Then
                        fechaReserva = fechaActual.AddDays(dias)
                    Else
                        fechaReserva = fechaActual.AddDays(dias + 1)
                    End If

                    'pasar reservado  a true
                    salida.reservado = True
                    salida.fechaVencimientoReserva = fechaReserva

                    conexion.SaveChanges()

                    'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                    Dim idInventario As Integer = 0
                    Dim idDetalle As Integer = 0
                    For Each fila As tblSalidaDetalle In detalles
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        idInventario = fila.tipoInventario
                        idDetalle = fila.idSalidaDetalle

                        If fila.tblArticulo.bitKit Then
                            'Obtenemos la lista de los productos asociados a ese kit
                            Dim lDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = idDetalle _
                                                                           Select x).ToList

                            For Each detallekit As tblSalidaDetalle In lDetalleKit
                                'descontar existencias.
                                Dim codArtKit As Integer = detallekit.idArticulo
                                Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                             And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                             And x.idArticulo = codArtKit Select x).FirstOrDefault

                                'si es reserva, incrementar la reserva , y decrementar el saldo
                                If inve.saldo >= (fila.cantidad * detallekit.cantidad) Then
                                    inve.saldo = inve.saldo - (fila.cantidad * detallekit.cantidad)
                                    inve.reserva = inve.reserva + (fila.cantidad * detallekit.cantidad)
                                    conexion.SaveChanges()
                                Else
                                    'alerta.contenido = "Error !!!, Existencia insuficiente en Kit, articulo: " + fila.tblArticulo.nombre1
                                    'alerta.fnErrorContenido()
                                    MessageBox.Show("Error !!!, Existencia insuficiente en Kit, articulo: " + fila.tblArticulo.nombre1)
                                    success = False
                                    Exit Try
                                End If
                            Next
                        ElseIf fila.tblArticulo.bitProducto Then

                            'descontar existencias.
                            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                         And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                         And x.idArticulo = CodArticulo Select x).FirstOrDefault

                            inve.saldo = inve.saldo - fila.cantidad
                            inve.reserva = inve.reserva + fila.cantidad
                            conexion.SaveChanges()

                        End If
                    Next

                    'completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                Catch ex As Exception
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If


            'liberar la conexion.
            conn.Close()
        End Using

        Return success
    End Function

    'Busqueda de cliente por clave
    Private Sub txtClave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        Try

            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim clave As String = txtClave.Text

                'Obtenemos el cliente
                Dim cliente As tblCliente
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    cliente = (From x In conexion.tblClientes _
                                                 Where x.clave = clave _
                                                 Select x).FirstOrDefault
                    conn.Close()
                End Using

                If cliente IsNot Nothing Then
                    cmbCliente.SelectedValue = cliente.idCliente
                    fnIndicadores()
                Else
                    RadMessageBox.Show("Cliente no encontrado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End If
            End If
        Catch ex As Exception
        End Try


    End Sub

    'IMPRESIONES
    Private Sub fnImpresiones() Handles Me.panel6
        'Obtenemos el cliente
        Dim codigo As Integer = CInt(cmbCliente.SelectedValue)

        If codigo > 0 Then
            frmListadoImpresiones.Text = "Lista de Impresiones"
            frmListadoImpresiones.StartPosition = FormStartPosition.CenterScreen
            frmListadoImpresiones.cliente = codigo
            permiso.PermisoDialogEspeciales(frmListadoImpresiones)
            frmListadoImpresiones.Dispose()
        Else
            RadMessageBox.Show("Debe elegir un cliente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

        End If
    End Sub

    Private Sub txtClave_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.Leave
        Dim bitEncontrador As Boolean = False

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


            Try
                Dim clave As String = txtClave.Text

                'Obtenemos el cliente
                Dim cliente As tblCliente = (From x In conexion.tblClientes _
                                                Where x.clave = clave _
                                                Select x).FirstOrDefault

                If Not bitEditarBodega And Not bitEditarSalida Then
                    If cliente IsNot Nothing Then
                        cmbCliente.SelectedValue = cliente.idCliente
                        bitEncontrador = True
                    Else
                        bitEncontrador = False
                        alerta.contenido = "Cliente no encontrado"
                    End If
                End If
                cmbCliente.Focus()

            Catch ex As Exception

            End Try

            conn.Close()
        End Using

        If bitEncontrador = True Then
            fnIndicadores()
        End If

    End Sub

    Private Sub fnArticulo_informacion()
        Dim idcliente As Integer = cmbCliente.SelectedValue

        Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)


        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try

                If IsNothing(Me.grdProductos.Rows(index).Cells("id").Value) = True Then
                    lblObservacion.Text = ""
                    lblCompatibilidad.Text = ""
                    lblSaldo.Text = 0
                    lblUltPrecio.Text = 0
                    lblUltTipoPrecio.Text = ""
                    Exit Sub
                End If

                Dim codigo As String = Me.grdProductos.Rows(index).Cells("id").Value.ToString

                If IsNumeric(codigo) Then
                    If CType(codigo, Integer) > 0 Then

                        Dim datos = conexion.sp_CadenaCompatibilidad(codigo, mdlPublicVars.General_idTipoInventario)
                        For Each fila As sp_CadenaCompatibilidad_Result In datos
                            lblObservacion.Text = fila.Obs
                            lblSaldo.Text = fila.Saldo
                            lblCompatibilidad.Text = fila.Compatibilidad
                        Next

                        Dim ultPrecio As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles
                                                             Where x.tblSalida.facturado = True And x.tblSalida.anulado = False And x.tblSalida.despachar = True _
                                        And x.idArticulo = codigo And x.tblSalida.idCliente = idcliente
                                        Order By x.tblSalida.fechaFacturado Descending Select x).FirstOrDefault

                        If ultPrecio IsNot Nothing Then
                            lblUltPrecio.Text = ultPrecio.precio
                            lblUltTipoPrecio.Text = ultPrecio.tblArticuloTipoPrecio.nombre
                        Else
                            lblUltTipoPrecio.Text = 0
                            lblUltPrecio.Text = 0
                        End If

                    Else
                        lblObservacion.Text = ""
                        lblSaldo.Text = 0
                        lblUltPrecio.Text = 0
                    End If
                Else
                    lblUltPrecio.Text = 0
                    lblObservacion.Text = ""
                    lblSaldo.Text = 0
                    lblCompatibilidad.Text = ""
                End If
            Catch ex As NullReferenceException
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                lblObservacion.Text = ""
                lblCompatibilidad.Text = ""
                lblSaldo.Text = 0
            End Try

            conn.Close()
        End Using


    End Sub

    Private Sub grdProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        ''fnArticulo_informacion()
    End Sub

    'IMPORTAR
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            If CInt(cmbCliente.SelectedValue) > 0 Then
                frmImportar.Text = "Importar"
                frmImportar.cliente = CInt(cmbCliente.SelectedValue)
                frmImportar.bitSalida = True
                frmImportar.ShowDialog()

                Dim fila As Integer = 0
                Dim tblR As DataTable = frmImportar.tblRetorno
                frmImportar.Dispose()
                If tblR.Rows.Count > 0 Then

                    'buscar fila con id en blanco.
                    Dim filaBlanco As Integer = -1

                    Dim index
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        If Me.grdProductos.Rows(index).Cells(1).Value Is Nothing Then
                            Me.grdProductos.Rows.RemoveAt(index)
                        ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)).Length = 0 Then
                            filaBlanco = index
                        ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)).Length = 1 And LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)) = 0 Then
                            filaBlanco = index
                        End If
                    Next

                    Dim inicio As Integer = 0
                    Dim precioExcel As Decimal = 0

                    Dim idArticulo As Integer = 0
                    Dim idCliente As Integer = cmbCliente.SelectedValue

                    Dim conexion As dsi_pos_demoEntities

                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        If filaBlanco <> -1 Then
                            'agregar al grid si nueva fila.
                            Me.grdProductos.Rows(filaBlanco).Cells("id").Value = LTrim(RTrim(tblR.Rows(0).Item("Id")))
                            Me.grdProductos.Rows(filaBlanco).Cells("txmCodigo").Value = tblR.Rows(0).Item("Codigo")
                            Me.grdProductos.Rows(filaBlanco).Cells("txbProducto").Value = LTrim(RTrim(tblR.Rows(0).Item("Nombre")))
                            Me.grdProductos.Rows(filaBlanco).Cells("txmCantidad").Value = LTrim(RTrim(tblR.Rows(0).Item("Cantidad")))

                            precioExcel = CType(tblR.Rows(0).Item("Costo"), Double)
                            idArticulo = CType(LTrim(RTrim(tblR.Rows(0).Item("Id"))), Integer)

                            Dim spprecio = (From x In conexion.sp_redondearPrecio(precioExcel) Select x.Value).FirstOrDefault()
                            Dim estadoProducto = (From x In conexion.spArticulo_EstadoDePrecio(idArticulo, cmbCliente.SelectedValue) Select x.Estado).FirstOrDefault()
                            Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo And x.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer) Select x).FirstOrDefault

                            'verificaciones para agregar a columna de surtir.
                            If IsNumeric(LTrim(RTrim(tblR.Rows(0).Item("Cantidad")))) And inventario IsNot Nothing Then

                                If CType(LTrim(RTrim(tblR.Rows(0).Item("Cantidad"))), Decimal) > inventario.saldo Then

                                    If MessageBox.Show("Desea agregar a surtir " & CType(tblR.Rows(0).Item("Cantidad"), Decimal) & " " & CType(tblR.Rows(0).Item("Nombre"), String) > inventario.saldo & " Articulos", nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                        Me.grdProductos.Rows(filaBlanco).Cells("txmCantidadSurtir").Value = CType(LTrim(RTrim(tblR.Rows(0).Item("Cantidad"))), Decimal) - inventario.saldo
                                    End If
                                End If
                            End If

                            Me.grdProductos.Rows(filaBlanco).Cells("clrEstado").Value = estadoProducto
                            Me.grdProductos.Rows(filaBlanco).Cells("txbPrecio").Value = spprecio
                            inicio = 1
                        End If

                        Dim msj As String = ""
                        Try
                            Dim spprecio
                            'agregar los elementos restantes al grid.
                            For index = inicio To tblR.Rows.Count - 1
                                msj = index


                                If IsNumeric(tblR.Rows(index).Item("costo")) Then
                                    precioExcel = CType(LTrim(RTrim(tblR.Rows(index).Item("Costo"))), Decimal)
                                    spprecio = (From x In conexion.sp_redondearPrecio(precioExcel) Select x.Value).FirstOrDefault()

                                Else
                                    precioExcel = 0
                                    spprecio = 0
                                    MessageBox.Show("El producto: " & LTrim(RTrim(tblR.Rows(index).Item("Codigo"))) & "  " & CType(tblR.Rows(0).Item("Nombre"), String) & "  No tiene Precio")
                                End If

                                idArticulo = CType(LTrim(RTrim(tblR.Rows(index).Item("id"))), Integer)
                                Dim estadoProducto = (From x In conexion.spArticulo_EstadoDePrecio(idArticulo, idCliente) Select x.Estado).FirstOrDefault()
                                'verificar existencia de inventario para agregar a pendientes por surtir.
                                Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo And x.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer) Select x).FirstOrDefault
                                Dim surtir As Integer = 0

                                If IsNumeric(LTrim(RTrim(tblR.Rows(index).Item("Cantidad")))) And inventario IsNot Nothing Then
                                    If CType(tblR.Rows(index).Item("Cantidad"), Integer) > inventario.saldo Then
                                        If MessageBox.Show("Desea agregar a surtir  " & CType(tblR.Rows(index).Item("Cantidad"), Decimal) - inventario.saldo & " Articulos de: " & tblR.Rows(index).Item("Codigo") & "  " & tblR.Rows(index).Item("Nombre"), nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                            surtir = CType(tblR.Rows(index).Item("Cantidad"), Integer) - inventario.saldo
                                        End If
                                    End If
                                End If
                                'agregar productos al grid view.
                                Me.grdProductos.Rows.Add(0, LTrim(RTrim(tblR.Rows(index).Item("id"))), tblR.Rows(index).Item("Codigo"), LTrim(RTrim(tblR.Rows(index).Item("Nombre"))),
                                                         LTrim(RTrim(tblR.Rows(index).Item("Cantidad"))) - surtir, spprecio.ToString, 0, False, "", 0, "", 0, 0, 0,
                                                         surtir, mdlPublicVars.General_idTipoInventario, mdlPublicVars.Empresa_PrecioNormal, estadoProducto)

                                '       filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre,
                                '                mdlPublicVars.superSearchCantidad, Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", False, "", 0, "", 0, 0, 0,
                                'mdlPublicVars.superSearchSurtir, mdlPublicVars.superSearchInventario, mdlPublicVars.superSearchTipoPrecio, mdlPublicVars.superSearchEstado}
                                '       grdProductos.Rows.Add(filas)
                            Next

                        Catch ex As Exception
                            MessageBox.Show(msj)
                        End Try

                        conn.Close()
                    End Using


                    fnActualizar_Total()
                    Me.grdProductos.Rows.AddNew()
                End If
            Else
                RadMessageBox.Show("Debe seleccionar un cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                cmbCliente.Focus()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'BOTON DETALLE PENDIENTES SURTIR
    Private Sub btnDetallePendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetallePendienteSurtir.Click
        If CInt(cmbCliente.SelectedValue > 0) Then
            frmDetallePendienteNuevo.Text = "Pendientes por Surtir"
            frmDetallePendienteNuevo.bitPendiente = True
            frmDetallePendienteNuevo.cliente = CInt(cmbCliente.SelectedValue)
            frmDetallePendienteNuevo.StartPosition = FormStartPosition.CenterScreen
            frmDetallePendienteNuevo.formSalida = Me
            frmDetallePendienteNuevo.ShowDialog()
            frmDetallePendienteNuevo.Dispose()
        End If
    End Sub

    'BOTON DETALLE PRODUCTOS NUEVOS
    Private Sub btnDetalleNuevos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleNuevos.Click
        If CInt(cmbCliente.SelectedValue > 0) Then
            frmDetallePendienteNuevo.Text = "Productos Nuevo"
            frmDetallePendienteNuevo.bitNuevo = True
            frmDetallePendienteNuevo.cliente = CInt(cmbCliente.SelectedValue)
            frmDetallePendienteNuevo.StartPosition = FormStartPosition.CenterScreen
            frmDetallePendienteNuevo.formSalida = Me
            frmDetallePendienteNuevo.ShowDialog()
            frmDetallePendienteNuevo.Dispose()
        End If
    End Sub


    Private Sub btnDetalleSugerir_Click(sender As Object, e As EventArgs) Handles btnDetalleSugerir.Click
        Try
            frmBuscarArticuloSugeridos.Text = "Productos Sugeridos"
            frmBuscarArticuloSugeridos.codClie = idCliente
            frmBuscarArticuloSugeridos.StartPosition = FormStartPosition.CenterScreen
            frmBuscarArticuloSugeridos.bitCliente = True
            frmBuscarArticuloSugeridos.bitDevolucionCliente = False
            frmBuscarArticuloSugeridos.bitProveedor = False
            frmBuscarArticuloSugeridos.bitMovimientoInventario = False
            frmBuscarArticuloSugeridos.modelos = "34,35,24,26,31,1,40,30,27,2,39,38,36,3,6,37,33,7,8,42,28,9,10,43,29,4,41,22,11,13,12,14,21,15,23,16,17,18,19,20,25,32,5"
            frmBuscarArticuloSugeridos.tipos = "1,2,5,4"
            frmBuscarArticuloSugeridos.venta = 1
            frmBuscarArticuloSugeridos.formSalida = Me
            permiso.PermisoDialogEspeciales(frmBuscarArticuloSugeridos)
            frmBuscarArticuloSugeridos.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    'BOTON DETALLE OFERTAS
    Private Sub btnDetalleOfertas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleOfertas.Click
        frmDetallePendienteNuevo.Text = "Ofertas"
        frmDetallePendienteNuevo.bitOferta = True
        frmDetallePendienteNuevo.cliente = CInt(cmbCliente.SelectedValue)
        frmDetallePendienteNuevo.formSalida = Me
        frmDetallePendienteNuevo.StartPosition = FormStartPosition.CenterScreen
        frmDetallePendienteNuevo.ShowDialog()
        frmDetallePendienteNuevo.Dispose()
    End Sub

    Private Sub grdProductos_EditorRequired(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.EditorRequiredEventArgs) Handles grdProductos.EditorRequired
        grdProductos.BeginUpdate()
        grdProductos.EndUpdate()
    End Sub

    Private Sub btnDetallePendientePedir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmDetallePendienteNuevo.Text = "Pendientes por Pedir"
        frmDetallePendienteNuevo.bitPedir = True
        frmDetallePendienteNuevo.cliente = CInt(cmbCliente.SelectedValue)
        frmDetallePendienteNuevo.StartPosition = FormStartPosition.CenterScreen
        frmDetallePendienteNuevo.ShowDialog()
        frmDetallePendienteNuevo.Dispose()
    End Sub

    Private Sub frmSalidas_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If fnCuentaArticulos() And Not bitEditarSalida Then
            If RadMessageBox.Show("¿ Desea Salir ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        ElseIf RadMessageBox.Show("¿ Desea salir ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnTelefono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTelefono.Click
        If CInt(cmbCliente.SelectedValue) > 0 Then
            frmDetalleTelefono.Text = "Teléfonos"
            frmDetalleTelefono.StartPosition = FormStartPosition.CenterScreen
            frmDetalleTelefono.idCliente = CInt(cmbCliente.SelectedValue)
            frmDetalleTelefono.ShowDialog()
            frmDetalleTelefono.Dispose()
        End If
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecio").Value = CType(mdlPublicVars.superSearchPrecio, Decimal)
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)
            'If especial = False Then
            'validar que la salida no este en estado de despacho.
            If bitEditarBodega = True And codigo > 0 Then

                Dim s As tblSalida

                Dim conexion As New dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                    s = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                    conn.Close()
                End Using


                'si despachado es falso actualizar la cantidad, de lo contrario no actualizar, solo precio.
                If s.despachar = False Then
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            Else

            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'REALIZAR PAGO
    Private Sub fnRealizarPago() Handles Me.panel7
        frmPagoNuevo.bitCliente = True
        frmPagoNuevo.Text = "Pagos de Clientes"
        frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmPagoNuevo)
        frmPagoNuevo.Dispose()
    End Sub


    Private Sub fnGuias() Handles Me.panel8

        Try

            If txtCodigo.Text = "" Then
                frmSalidaEnvio.bitTemporal = True
            Else
                frmSalidaEnvio.bitTemporal = False
            End If

            'abrir el formulario
            frmSalidaEnvio.tblGuias = Me.tblGuias
            frmSalidaEnvio.Codigo = codigo
            frmSalidaEnvio.codigoCliente = CType(cmbCliente.SelectedValue, Integer)
            frmSalidaEnvio.Text = "Paqueteria"
            frmSalidaEnvio.ShowDialog()
            frmSalidaEnvio.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    'FUNCION UTILIZADA PARA VERIFICAR SI TIENE ARTICULOS EL GRID
    Private Function fnCuentaArticulos() As Boolean
        Dim nombre As String = ""
        For i As Integer = 0 To Me.grdProductos.RowCount - 1
            nombre = Me.grdProductos.Rows(i).Cells("txbProducto").Value

            If nombre IsNot Nothing Then
                Return True
            End If
        Next

    End Function

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frmBuscarCliente.Text = "Buscar Cliente"
        frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmBuscarCliente)
        frmBuscarCliente.Dispose()

        If superSearchId > 0 Then
            Dim codigo As Integer = CType(superSearchId, Integer)
            Me.cmbCliente.SelectedValue = codigo
        End If
    End Sub

    Private Sub fnLimpiarInformacionArticulo()
        Try
            lblObservacion.Text = ""
            lblCompatibilidad.Text = ""
            lblSaldo.Text = 0
            lblUltPrecio.Text = 0
            lblUltTipoPrecio.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVerificarExistencia_Click(sender As Object, e As EventArgs) Handles btnVerificarExistencia.Click
        Try
            fnVerificarExistencia()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnVerificarExistencia()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim id As Integer = 0
                Dim cantidad As Double = 0.0
                Dim cantidadAnterior As Double = 0.0
                Dim iddetalle As Integer = 0
                Dim ajuste As Boolean = False
                Dim idInventario As Integer

                Dim a As tblInventario
                Dim ar As tblArticulo

                If codigo > 0 Then

                    Dim s As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault

                    If s.facturado = False And s.despachar = False And s.empacado = False And s.reservado = True Then

                        For c As Integer = 0 To Me.grdProductos.Rows.Count - 1

                            id = Me.grdProductos.Rows(c).Cells("Id").Value
                            cantidad = Me.grdProductos.Rows(c).Cells("txmCantidad").Value
                            iddetalle = Me.grdProductos.Rows(c).Cells("iddetalle").Value
                            idInventario = Me.grdProductos.Rows(c).Cells("idInventario").Value

                            Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                            cantidadAnterior = detalle.cantidad

                            a = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                And x.idArticulo = id Select x).FirstOrDefault

                            a.saldo += cantidadAnterior
                            a.reserva -= cantidadAnterior

                            If cantidad > a.saldo Then
                                ar = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).FirstOrDefault

                                RadMessageBox.Show("Existencia insuficiente para el articulo: " & ar.nombre1.Trim() & " (" & ar.codigo1.Trim() & ") " & vbCrLf _
                                & "Cantidad Requerida: " & cantidad & vbCrLf _
                                & "Disponible:" & a.saldo & vbCrLf _
                                & "Faltante: " & cantidad - a.saldo, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                                Me.grdProductos.Rows(c).Cells("CantidadAjustada").Value += cantidad - a.saldo
                                Me.grdProductos.Rows(c).Cells("txmCantidad").Value = a.saldo

                                ajuste = True
                            ElseIf a.saldo >= cantidad Then
                                a.saldo -= cantidadAnterior
                                a.reserva += cantidadAnterior
                            End If

                        Next

                    End If

                Else

                    For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
                        id = Me.grdProductos.Rows(i).Cells("Id").Value
                        cantidad = Me.grdProductos.Rows(i).Cells("txmCantidad").Value

                        a = (From x In conexion.tblInventarios Where x.idArticulo = id And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                        If a Is Nothing Then

                        Else

                            If cantidad > a.saldo Then

                                ar = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).FirstOrDefault

                                RadMessageBox.Show("Existencia insuficiente para el articulo: " & ar.nombre1.Trim() & " (" & ar.codigo1.Trim() & ") " & vbCrLf _
                                & "Cantidad Requerida: " & cantidad & vbCrLf _
                                & "Disponible:" & a.saldo & vbCrLf _
                                & "Faltante: " & cantidad - a.saldo, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                                Me.grdProductos.Rows(i).Cells("CantidadAjustada").Value += cantidad - a.saldo
                                Me.grdProductos.Rows(i).Cells("txmCantidad").Value = a.saldo

                                ajuste = True

                            End If

                        End If
                    Next

                End If



                Dim TotalAjuste As Double = 0.0
                Dim Ajustes As Double = 0.0

                Try
                    Ajustes = Replace(Me.txtAjusteRevisionStock.Text, "Q", "")
                Catch ex As Exception
                    Ajustes = Me.txtAjusteRevisionStock.Text
                End Try

                If ajuste = True Then
                    ''If RadMessageBox.Show("Existen productos ajustados por Stock, ¿Desea conocer el Total de lo Ajustado?", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation) Then
                    For x As Integer = 0 To Me.grdProductos.Rows.Count - 1
                        Try
                            If Me.grdProductos.Rows(x).Cells("CantidadAjustada").Value > 0 Then
                                TotalAjuste += Me.grdProductos.Rows(x).Cells("txbPrecio").Value * Me.grdProductos.Rows(x).Cells("CantidadAjustada").Value
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    ''RadMessageBox.Show("El Monto Total Ajustado Es: " + CStr(Format(TotalAjuste, formatoMoneda)), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Me.txtAjusteRevisionStock.Text = Format(Ajustes + TotalAjuste, formatoMoneda)
                    ''End If
                Else
                    Me.txtAjusteRevisionStock.Text = Format(0, formatoMoneda)
                    RadMessageBox.Show("Stock Disponible", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If
                fnActualizar_Total()
                conn.Close()
            End Using

            verificarexistencia = True

        Catch ex As Exception
            verificarexistencia = False
        End Try
    End Sub

    Private Sub fnCopiarGrid()
        Try

            Clipboard.Clear()

            Me.grdlistado.SelectAll()

            Dim dataObj As DataObject

            grdlistado.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dataObj = grdlistado.GetClipboardContent()
            If Me.grdlistado.Rows.Count >= 0 Then
                Clipboard.SetDataObject(dataObj)
            End If

            Me.grdListado.ClearSelection()
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnValidarVencido() As Boolean
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim salidas As List(Of tblSalida)
                Dim d As tblCliente
                Dim cliente As Integer = Me.cmbCliente.SelectedValue
                Dim suma As Integer
                Dim fecha As Date

                d = (From x In conexion.tblClientes Where x.idCliente = cliente And x.habillitado = True Select x).FirstOrDefault

                salidas = (From x In conexion.tblSalidas Where x.idCliente = cliente And x.facturado = True And x.anulado = False And x.saldo > 0 Select x).ToList

                For Each s As tblSalida In salidas

                    fecha = DateAdd(DateInterval.Day, CDec(d.diasCredito), CDate(s.fechaFacturado))

                    If fecha < Today Then
                        suma += 1
                    End If

                Next

                If suma > 0 Then

                    frmValidacionClave.Text = "Autorizacion"
                    frmValidacionClave.lblInformacion.Text = "¡Se necesita autorizacion administrativa debido a que el cliente posee saldo vencido!"
                    frmValidacionClave.StartPosition = FormStartPosition.CenterScreen
                    frmValidacionClave.WindowState = FormWindowState.Normal
                    frmValidacionClave.ShowDialog()
                    frmValidacionClave.Dispose()

                    If mdlPublicVars.ClaveVencidosStatus = True Then
                        mdlPublicVars.ClaveVencidosStatus = False
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If

                conn.Close()
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

#Region "Ventas Pequenias"
    Private Sub fnDespachar_Click()
        Dim codigocliente As Integer = Me.cmbCliente.SelectedValue
        fnActualizar_Total()
        Dim ejecutaPago As Boolean
        Dim tipopago As Object
        Dim idSalida As Integer

        If bitSugerirDespacho = True Then
            fnModificarCotizacion()
            'Obtenemos la salida
            Dim salida As tblSalida

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using

            If CambiacotizarAdespacho(salida.idSalida, CBool(salida.credito), CInt(salida.idCliente)) Then
                fnImprimir(salida.idSalida)
                fnNuevo()
                Me.Close()
                bitEditarSalida = False
                bitSugerirDespacho = False
                bitSugerirReserva = False
            End If
        ElseIf fnErrores() = False Then

            Dim clave As String
            clave = txtClave.Text
            'conexion nueva.
            Dim conexion1 As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion1 = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim idtipopag = (From x In conexion1.tblClientes Where x.clave = clave Select x.idTipoPago).FirstOrDefault

                Dim idpago As Integer = idtipopag

                tipopago = (From x In conexion1.tblClienteTipoPagoes Where x.idtipoPago = idpago Select x.idtipoPago).FirstOrDefault
                conn.Close()

            End Using

            If RadMessageBox.Show("¿Desea Facturar la Venta?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                Dim bitTransporte As Boolean = False

                If tipopago <> mdlPublicVars.PuntoVentaPequeno_tipoPago Then
                    If RadMessageBox.Show("¿Desea Realizar la venta al Contado?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        idSalida = fnGuardarDespachoPequenio(True)

                        If idSalida > 0 Then
                            Dim conexion As New dsi_pos_demoEntities
                            Dim salida As tblSalida
                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                                salida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault
                                ''    conn.Close()
                                ''End Using

                                ejecutaPago = fnCalculoSaldos(idSalida, salida.idCliente)

                                mdlPublicVars.GuardarFacturacion(idSalida)
                                ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                ''conn.Open()
                                ''conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                                valida.fnConsumirPagos(salida.idSalida, conexion)
                                conn.Close()
                            End Using

                            ''Cobro de la Venta
                            Dim salidamo As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                            If ejecutaPago = True Then
                                frmPagoVentaPequenia.Text = "Realizar pago"
                                frmPagoVentaPequenia.idCliente = salidamo.idCliente
                                frmPagoVentaPequenia.idSalida = idSalida
                                frmPagoVentaPequenia.bitDocumentoCliente = True
                                frmPagoVentaPequenia.bitCliente = False
                                frmPagoVentaPequenia.ShowDialog()
                                frmPagoVentaPequenia.Dispose()
                            End If

                            fnAsignarResolucion(idSalida)

                            Dim salidamodificar As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                            salidamodificar.contado = True
                            salidamodificar.credito = False

                            conexion.SaveChanges()

                            ''impresion de la factura si el pago fue realizado
                            ''If supersearchPagado = True Then
                            ''    If RadMessageBox.Show("Desea Imprimir la Factura", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            ''valida.fnFacturarImprimir(idSalida)
                            ''    End If
                            ''End If

                            ''fnImprimirPequenio(codigoSalida, True)
                            fnNuevo()
                            fnNuevaFila()
                        End If
                    Else
                        idSalida = fnGuardarDespachoPequenio(False)

                        If idSalida > 0 Then
                            Dim conexion As New dsi_pos_demoEntities
                            Dim salida As tblSalida
                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                                salida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault
                                ''    conn.Close()
                                ''End Using

                                If mdlPublicVars.bitTransportePesado = True Then

                                    Dim totalventa As Double = CDec(Replace(Me.lblSaldoFinal.Text, "Q", ""))
                                    Dim saldocliente As Double = 0
                                    Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codigocliente Select x).FirstOrDefault

                                    If cliente.saldo > 0 Then
                                        saldocliente = cliente.saldo
                                    End If

                                    If (saldocliente + totalventa) > cliente.limiteCredito Then

                                        Dim lcredito As Double = cliente.limiteCredito
                                        Dim cantpago As Double
                                        Dim valventavalida As Double

                                        valventavalida = lcredito - saldocliente

                                        cantpago = totalventa - valventavalida

                                        ''Guardado del Pago Pendiente de Confirmacion
                                        Dim pagotipo As Integer = mdlPublicVars.Pagos_codigoEfectivo
                                        Dim documento As String = ""
                                        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)

                                        'TIPO DE PAGO
                                        Dim tipoPagos As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = pagotipo Select x).FirstOrDefault

                                        Dim pago As New tblCaja
                                        pago.documento = If(documento Is Nothing, "", documento)
                                        pago.anulado = False
                                        pago.codigoSalida = idSalida
                                        pago.fecha = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
                                        pago.fechaTransaccion = fecha
                                        pago.fechaCobro = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
                                        ''pago.monto = If(nm2TotalPagar.Value > 0, If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value), nm2MontoRecibido.Value)
                                        ''pago.monto = If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value)
                                        pago.monto = cantpago
                                        pago.tipoCambio = 1
                                        pago.tipoPago = pagotipo
                                        pago.empresa = mdlPublicVars.idEmpresa
                                        pago.usuario = mdlPublicVars.idUsuario
                                        pago.observacion = Observacion
                                        pago.descripcion = tipoPagos.nombre
                                        pago.bitRechazado = False
                                        pago.consumido = cantpago
                                        pago.afavor = 0
                                        pago.confirmado = False
                                        pago.transito = False
                                        pago.cliente = codigocliente
                                        pago.bitEntrada = True
                                        pago.bitSalida = False

                                        conexion.AddTotblCajas(pago)
                                        conexion.SaveChanges()

                                    End If

                                End If

                                ejecutaPago = fnCalculoSaldos(idSalida, salida.idCliente)

                                ''mdlPublicVars.GuardarFacturacion(idSalida)
                                ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                ''conn.Open()
                                ''conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                                valida.fnConsumirPagos(salida.idSalida, conexion)
                                conn.Close()
                            End Using

                            ''Cobro de la Venta
                            ''Dim salidamo As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                            ''If ejecutaPago = True Then
                            ''    frmPagoVentaPequenia.Text = "Realizar pago"
                            ''    frmPagoVentaPequenia.idCliente = salidamo.idCliente
                            ''    frmPagoVentaPequenia.idSalida = idSalida
                            ''    frmPagoVentaPequenia.bitDocumentoCliente = True
                            ''    frmPagoVentaPequenia.bitCliente = False
                            ''    frmPagoVentaPequenia.ShowDialog()
                            ''    frmPagoVentaPequenia.Dispose()
                            ''End If

                            ''impresion de la factura si el pago fue realizado
                            ''If supersearchPagado = True Then


                            fnCorrelativoFac()

                            ''    If RadMessageBox.Show("Desea Imprimir la Factura", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            valida.fnFacturarImprimir(idSalida)
                            ''    End If
                            ''End If

                            ''fnImprimirPequenio(codigoSalida, True)
                            fnAsignarResolucion(idSalida)
                            fnNuevo()
                            fnNuevaFila()
                        End If
                    End If
                Else
                    idSalida = fnGuardarDespachoPequenio(True)
                    ''idSalida = mdlPublicVars.superSearchId

                    If idSalida > 0 Then
                        Dim conexion As New dsi_pos_demoEntities
                        Dim salida As tblSalida
                        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            conn.Open()

                            ''Verificacion de Saldo para la venta al credito

                            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                            salida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault
                            ''    conn.Close()
                            ''End Using

                            ejecutaPago = fnCalculoSaldos(idSalida, salida.idCliente)

                            mdlPublicVars.GuardarFacturacion(idSalida)
                            ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            ''conn.Open()
                            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                            valida.fnConsumirPagos(salida.idSalida, conexion)
                            conn.Close()
                        End Using
                        If mdlPublicVars.VentaPequenia_bitCaja Then

                            ''Cobro de la Venta
                            Dim salidamo As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault


                            If ejecutaPago = True Then
                                frmPagoVentaPequenia.Text = "Realizar pago"
                                frmPagoVentaPequenia.idCliente = salidamo.idCliente
                                frmPagoVentaPequenia.idSalida = idSalida
                                frmPagoVentaPequenia.bitDocumentoCliente = True
                                frmPagoVentaPequenia.bitCliente = False
                                frmPagoVentaPequenia.ShowDialog()
                                frmPagoVentaPequenia.Dispose()
                            End If

                        End If
                        fnAsignarResolucion(idSalida)



                        fnNuevo()
                        fnNuevaFila()
                    End If

                End If
            End If
        End If

        fnCalcularTickets(idSalida)

    End Sub

    Private Sub fnCalcularTickets(ByVal idsalida As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''If Cantidad >= a.CuotaPromocion Then
                ''    cx = Math.Floor(CDec(Cantidad / a.CuotaPromocion))
                ''    mdlPublicVars.superSearchCuotaPromocion = a.CuotaPromocion
                ''    mdlPublicVars.superSearchCantidadPromocion = cx
                ''    cr = cx * a.CantidadPromocion
                ''End If

                Dim NumeroTickets As Integer

                Dim s As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                If s.total > MetricaPromociones Then
                    NumeroTickets = Math.Floor(CDec(s.total / MetricaPromociones))
                End If

                If NumeroTickets > 0 Then

                    For ticket As Integer = 1 To NumeroTickets

                        Dim t As New tblTICKETSVENTA

                        t.FECHACREACION = fnFecha_horaServidor()
                        t.IDSALIDA = idsalida
                        t.IDCLIENTE = s.idCliente
                        t.BITAPLICADO = False
                        t.MONTOVALIDACION = MetricaPromociones

                        conexion.AddTotblTICKETSVENTAS(t)
                        conexion.SaveChanges()

                    Next

                    frmNotificacion.lblNotificacion.Text = "Se crearon " + CStr(NumeroTickets) + " Tickets"
                    frmNotificacion.Show()

                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnAsignarResolucion(ByVal codigo As Integer)
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim codresolucion As Integer
                Dim correlativor As Integer
                Dim codfac As Integer
                Dim seriefac As String

                codresolucion = (From x In conexion.tblResolucionFacturas Where x.habilitado = True Select x.idResolucion).FirstOrDefault

                correlativor = (From x In conexion.tblResolucionFacturas Where x.idResolucion = codresolucion Select x.correlativo).FirstOrDefault

                codfac = (From x In conexion.tblSalida_Factura Where x.salida = codigo Select x.factura).FirstOrDefault

                seriefac = (From x In conexion.tblResolucionFacturas Where x.idResolucion = codresolucion Select x.serie).FirstOrDefault

                Dim fact As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codfac Select x).FirstOrDefault

                fact.idResolucion = codresolucion
                fact.serieFactura = seriefac
                fact.DocumentoFactura = correlativor + 1

                conexion.SaveChanges()

                Dim resol As tblResolucionFactura = (From x In conexion.tblResolucionFacturas Where x.idResolucion = codresolucion Select x).FirstOrDefault

                resol.correlativo += 1

                conexion.SaveChanges()

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnCalculoSaldos(ByVal idsalida As Integer, ByVal idcliente As Integer)

        Dim ejecutapago As Boolean

        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idcliente Select x).FirstOrDefault

                If cliente.saldo >= 0 Then
                    ejecutapago = True
                ElseIf cliente.saldo < 0 Then

                    Dim salpago As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                    Dim saldofavor As Integer = (cliente.saldo * -1)

                    If saldofavor >= salpago.total Then

                        salpago.saldo = 0
                        salpago.pagado = salpago.total
                        ejecutapago = False

                        ''fnGuardarPagoCaja(salpago.total, salpago.idSalida)

                        supersearchPagado = True
                        conexion.SaveChanges()

                    ElseIf saldofavor < salpago.total Then

                        salpago.saldo -= saldofavor
                        salpago.pagado += saldofavor
                        ejecutapago = True

                        ''fnGuardarPagoCaja(saldofavor, salpago.idSalida)

                        supersearchPagado = False
                        conexion.SaveChanges()
                    End If

                    conn.Close()

                End If

            End Using
        Catch ex As Exception
            ejecutapago = False
        End Try
        If ejecutapago = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub fnCorrelativoFac()
        Try
            frmCorrelativoFactura.Text = "Correlativo Factura"
            frmCorrelativoFactura.StartPosition = FormStartPosition.CenterScreen
            frmCorrelativoFactura.WindowState = FormWindowState.Normal
            frmCorrelativoFactura.ShowDialog()
            frmCorrelativoFactura.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnImprimir(ByVal codSalida As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim c As New clsReporte
                If mdlPublicVars.bitTransportePesado Then
                    c.tabla = EntitiToDataTable(conexion.sp_ReporteEnvioPequenio("", codSalida))
                Else
                    c.tabla = EntitiToDataTable(conexion.sp_reportePickingPedido("", codSalida))
                End If

                If mdlPublicVars.bitTransportePesado Then
                    c.reporte = "rptEnvioPequenio.rpt"
                Else
                    c.nombreParametro = "@filtro"
                    c.reporte = "ventas_Picking.rpt"
                    c.parametro = ""
                End If
                c.verReporte()

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Function fnGuardarDespachoPequenio(ByVal ventacontado As Boolean) As Integer
        Dim codcliente As Integer = Me.cmbCliente.SelectedValue
        Dim cliente As String = Me.cmbCliente.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = CInt(cmbVendedor.SelectedValue)

        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor().ToString
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim autorizaCredito As Boolean = False    'variable que se utiliza para saber si se despliega la fnErrorAutorizacionCredito
        Dim idunidamedi

        'contador de pendientes por surtir, automaticamente envia el restante de cantidad y saldo a pendientes por surtir.
        Dim contadorSurtir As Integer = 0
        Dim cantidadSurtir As Double = 0

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First
            Dim usr As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault
            If success Then
                Using transaction As New TransactionScope
                    Try
                        'GUARDAR REGISTRO DE SALIDA.
                        Dim totalSalida As Decimal = 0
                        Try
                            totalSalida = CDec(Replace(lblSaldoFinal.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalSalida = 0
                        End Try

                        Dim salida As New tblSalida
                        ''''Dim totalCostoSalida As Decimal = 0
                        'Sustraemos el correlativo
                        Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                             Select x).First

                        salida.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                        salida.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                        salida.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                        salida.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                        salida.idTipoMovimiento = CShort(codmovimiento)
                        salida.idVendedor = CShort(usr.idVendedor)
                        salida.idCliente = codcliente
                        salida.idMunicipio = mdlPublicVars.General_MunicipioLocal
                        If mdlPublicVars.bitTransportePesado = True Then
                            salida.cliente = cmbNombre.Text
                        Else
                            salida.cliente = cmbCliente.Text
                        End If
                        salida.nit = txtNit.Text
                        salida.fechaTransaccion = fecha
                        salida.fechaRegistro = CDate(dtpFechaRegistro.Text & " " & hora)
                        salida.fechaDespachado = CDate(dtpFechaRegistro.Text & " " & hora)
                        salida.cotizado = False
                        salida.reservado = False
                        salida.despachar = True
                        salida.facturado = False
                        salida.empacado = True        ' ponemos true para ver si nos permite facturar
                        salida.anulado = False
                        salida.fechaAnulado = Nothing

                        salida.descuento = 0
                        salida.subtotal = totalSalida
                        salida.total = totalSalida
                        salida.pagado = 0
                        salida.saldo = salida.total
                        salida.devoluciones = 0
                        salida.bitFacReimpreso = False

                        If ventacontado = True Then
                            salida.contado = True
                            salida.credito = False
                        ElseIf ventacontado = False Then
                            salida.contado = False
                            salida.credito = True
                        End If

                        ''salida.contado = rbnContado.Checked
                        ''salida.credito = rbnCredito.Checked

                        salida.documento = (correlativo.correlativo + 1).ToString
                        correlativo.correlativo = correlativo.correlativo + 1

                        'agregar salida al modelo
                        conexion.AddTotblSalidas(salida)

                        'guardar cambios
                        conexion.SaveChanges()
                        codigoSalida = salida.idSalida
                        codigoSalidaAFacturar = salida.idSalida 'para saber cual se va a facturar en venta pequenia

                        '************** TRANSPORTE
                        Dim totalCosteoCosto As Decimal = 0
                        ''For Each salidaTransporte As tblSalidasTransporte In listaTransportes
                        ''    salidaTransporte.idSalida = codigoSalida
                        ''    conexion.AddTotblSalidasTransportes(salidaTransporte)

                        ''    ' Prorrateo al costo'
                        ''    Dim transporteCosteo As tblTransporteCosteo = (From x In conexion.tblTransporteCosteos
                        ''                                                   Where x.idTransporteCosteo = salidaTransporte.idTransporteCosteo
                        ''                                                   Select x).FirstOrDefault

                        ''    If transporteCosteo.codigo = "1" Then
                        ''        totalCosteoCosto += CDec(salidaTransporte.precio * salidaTransporte.cantidad)
                        ''    End If

                        ''    conexion.SaveChanges()
                        ''Next
                        '************** FIN DE TRANSPORTES

                        '************** CALCULAR EL COSTO TOTAL DE LA VENTA

                        ''''totalCostoSalida = (From x In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Select(Function(x) CType(x.Cells("txmCantidad").Value, Decimal) * CType(x.Cells("costo").Value, Decimal)).Sum
                        '************** FIN DE CALCULAR EL COSTO TOTAL DE LA VENTA

                        '--------------------------------------- fin de crear encabezado. ------------------
                        'paso 6, guardar el detall
                        Dim index As Integer
                        Dim cantidad As Double = 0.0
                        Dim precio As Decimal = 0
                        Dim precioOriginal As Decimal = 0
                        Dim total As Decimal = 0
                        Dim idarticulo As Integer = 0
                        Dim nombre As String = ""
                        Dim cantSurtir As Integer = 0 ' sirve cuando el usuario ingresa el pendiente por surtir a comparacion de cantidadSurtir que es automatico.
                        Dim idSurtir As Integer = 0
                        Dim contado As Boolean = True
                        Dim idInventario As Integer = 0
                        Dim tipoPrecio As Integer = 0
                        Dim observacion As String = ""
                        'crear registro de salida bodega.
                        If codigoSalida > 0 Then
                            Dim sb As New tblsalidaBodega
                            sb.idsalida = codigoSalida
                            conexion.AddTotblsalidaBodegas(sb)
                            conexion.SaveChanges()
                        End If

                        ' Variables para transporte
                        Dim totalCosto As Decimal
                        Dim porcentajeCosto As Decimal
                        Dim cociente As Decimal
                        Dim porUnidad As Decimal
                        Dim valmedida As Double
                        Dim idmedida As Integer = 0
                        Dim inventariosalida As Integer = 0
                        ''Dim bodegasalida As Integer = 0


                        For index = 0 To Me.grdProductos.Rows.Count - 1
                            idarticulo = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) ' id articulo
                            nombre = CStr(Me.grdProductos.Rows(index).Cells("txbProducto").Value) ' codigo

                            Dim articulof As Integer = CType(Me.grdProductos.Rows(index).Cells("id").Value, Integer)
                            Dim cantidadf As Double = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Integer)
                            Dim tipomovimiento As Integer = 0
                            idunidamedi = mdlPublicVars.UnidadMedidaDefault ''Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value


                            '' ''VERIFICACION DE QUE TIPO DE PRODUCTO ES KIT, UNIDAD MEDIDA, PRODUCTO, SERVICIO--------------------------------------

                            ''Dim bikit = (From x In conexion.tblArticuloes Where x.idArticulo = articulof Select x.bitKit).FirstOrDefault

                            ''Dim biunidadmedida = (From x In conexion.tblArticuloes Where x.idArticulo = articulof Select x.bitUnidadMedida).FirstOrDefault

                            ''Dim biproducto = (From x In conexion.tblArticuloes Where x.idArticulo = articulof Select x.bitProducto).FirstOrDefault


                            '' ''VERIFICAMOS SI ES KIT
                            '' ''If bikit Then

                            ''Dim detallekit As List(Of GridViewRowInfo) = Nothing

                            ''Dim detallekit = (From x In conexion.tblArticulo_Kit, y In conexion.tblArticuloes Where y.idArticulo = x.articulo And x.articuloBase = articulof
                            ''                    Select codigo = x.articulo, cantida = x.cantidad, cost = y.costoIVA,
                            ''                    codigomedida = CType(If(x.idArticulo_UnidadMedida > 0, x.idArticulo_UnidadMedida, 0), String),
                            ''                    idunidadmedida = CType(If(x.idArticulo_UnidadMedida > 0, (From z In conexion.tblArticulo_UnidadMedida Where x.idArticulo_UnidadMedida = z.idArticulo_UnidadMedida Select z.idUnidadMedida).FirstOrDefault, 1), String),
                            ''                    valo = CType(If(x.idArticulo_UnidadMedida > 0, (From m In conexion.tblArticulo_UnidadMedida Where x.idArticulo_UnidadMedida = m.idArticulo_UnidadMedida Select m.valor).FirstOrDefault, 1), String))

                            ''Dim lkit As DataTable = mdlPublicVars.EntitiToDataTable(detallekit)
                            ''Dim val As String = 0

                            ''    Dim idunidadmedid As String
                            ''    Dim fila
                            ''    For Each fila In lkit.Rows

                            ''        If fila.item(4).ToString.Length > 0 Then
                            ''            idunidadmedid = "'" & fila.item(4) & "'"
                            ''        Else
                            ''            idunidadmedid = "null"
                            ''        End If

                            ''        If fila.item(5).ToString.Length > 0 Then
                            ''            val = "'" & fila.item(5) & "'"
                            ''        Else
                            ''            val = "null"
                            ''        End If

                            ''        Dim articulo As String

                            ''        articulo = fila.item(0)

                            ''        If val = "null" Then

                            ''            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                            ''                                      And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault
                            ''            If inve.saldo >= (fila.item(1) * fila.item(5)) Then
                            ''                inve.saldo -= CType((fila.item(1) * fila.item(5)), Decimal)
                            ''                inve.salida += CType((fila.item(1) * fila.item(5).Value), Decimal)
                            ''            End If

                            ''        Else

                            ''            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                            ''                                            And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault
                            '' ''            If inve.saldo >= (cantidadf * fila.item(1) * fila.item(5)) Then
                            ''                inve.saldo -= CType((fila.item(1) * cantidadf * fila.item(5)), Decimal)
                            ''                inve.salida += CType((fila.item(1) * cantidadf * fila.item(5)), Decimal)
                            ''            End If

                            ''        End If
                            ''        conexion.SaveChanges()
                            ''Next

                            ''VERIFICAMOS SI ES UNIDAD MEDIDA
                            ''ElseIf biunidadmedida = True Then

                            ''    Dim consulta = (From x In conexion.tblArticulo_UnidadMedida, y In conexion.tblArticuloes Where x.idArticulo = y.idArticulo And y.idArticulo = articulof And x.idUnidadMedida = idunidamedi Select resultado = CType(If(x.kit = True, 1, 0), String)).FirstOrDefault

                            ''    If CType(consulta, Integer) = 0 Then



                            ''    End If


                            ''End If

                            ''FIN DE LA VERIFICACION DE QUE TIPO DE PRODUCTO ES EL QUE SE ESTA DANDO DE BAJA--------------------------------------

                            If nombre IsNot Nothing Then
                                Dim transporte As Boolean = False
                                cantidad = CDec(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) ' cantidad
                                precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecio").Value.ToString, "Q", "").Trim) ' precio
                                ''precioOriginal = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecioBase").Value.ToString, "Q", "").Trim) ' precio original
                                total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value.ToString, "Q", "").Trim) ' total
                                cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value) 'surtir
                                idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value)
                                idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value)
                                tipoPrecio = CInt(Me.grdProductos.Rows(index).Cells("tipoPrecio").Value)
                                observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value.ToString
                                valmedida = 1 ''Me.grdProductos.Rows(index).Cells("ValorUnidadMedida").Value
                                ''transporte = Me.grdProductos.Rows(index).Cells("chmTransporte").Value
                                idmedida = mdlPublicVars.UnidadMedidaDefault
                                ''bodegasalida = CType(Me.grdProductos.Rows(index).Cells("idBodega").Value, Integer)

                                Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).First

                                Dim detalle As New tblSalidaDetalle
                                detalle.idSalida = codigoSalida
                                detalle.anulado = False
                                detalle.idArticulo = idarticulo
                                detalle.cantidad = CDec(cantidad)
                                detalle.precio = precio
                                detalle.precioOriginal = precioOriginal
                                detalle.costo = articulo.costoIVA
                                detalle.tipoInventario = idInventario
                                detalle.tipoPrecio = tipoPrecio
                                detalle.comentario = observacion
                                detalle.precioFactura = precio 'se agrego precio factura
                                detalle.otrosCostos = 0
                                detalle.agregarTransporte = transporte
                                detalle.idunidadmedida = idmedida
                                detalle.valormedida = valmedida
                                detalle.tipobodega = mdlPublicVars.General_idAlmacenPrincipal
                                '************** COSTEO
                                '' ''If totalCosteoCosto > 0 Then
                                '' ''    'Proceso para el prorrateo por costo
                                '' ''    totalCosto = CDec(detalle.costo * detalle.cantidad)
                                '' ''    porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                '' ''    cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                '' ''    porUnidad = CDec(cociente / cantidad)

                                '' ''    detalle.otrosCostos = porUnidad
                                '' ''End If
                                '************** FIN DE COSTEO

                                conexion.AddTotblSalidaDetalles(detalle)
                                conexion.SaveChanges()


                                If articulo.bitKit Then
                                    'Obtenemos la lista de los productos asociados a ese kit
                                    Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = articulo.idArticulo _
                                                                                   Select x).ToList

                                    For Each detallekit As tblArticulo_Kit In lDetalleKit
                                        Dim salidaKit As New tblSalidaDetalle
                                        salidaKit.anulado = False
                                        salidaKit.idArticulo = CInt(detallekit.articulo)
                                        salidaKit.cantidad = CDec(cantidad * detallekit.cantidad)
                                        salidaKit.precio = 0
                                        salidaKit.precioOriginal = 0
                                        salidaKit.otrosCostos = 0
                                        salidaKit.costo = detallekit.tblArticulo1.costoIVA
                                        salidaKit.tipoInventario = idInventario
                                        salidaKit.tipoPrecio = detalle.tipoPrecio
                                        salidaKit.comentario = observacion
                                        salidaKit.kitSalidaDetalle = detalle.idSalidaDetalle
                                        salidaKit.idSalida = detalle.idSalida
                                        salidaKit.agregarTransporte = detalle.agregarTransporte
                                        salidaKit.idunidadmedida = detalle.idunidadmedida
                                        salidaKit.valormedida = detalle.valormedida
                                        conexion.AddTotblSalidaDetalles(salidaKit)
                                        conexion.SaveChanges()

                                        'descontar existencias.
                                        Dim codArtKit As Integer = CInt(detallekit.articulo)
                                        Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                     And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                     And x.idArticulo = codArtKit Select x).FirstOrDefault

                                        'si es reserva, incrementar la reserva , y decrementar el saldo
                                        If inve.saldo >= (salidaKit.cantidad) Then
                                            inve.saldo = inve.saldo - (salidaKit.cantidad)
                                            inve.salida = inve.salida + (salidaKit.cantidad)
                                            conexion.SaveChanges()
                                        Else

                                            errContenido = "Error !!!, Existencia insuficiente en Kit, articulo: " + articulo.nombre1
                                            success = False
                                            Exit Try
                                        End If
                                    Next
                                ElseIf articulo.bitProducto Or articulo.bitUnidadMedida Then

                                    'descontar existencias.
                                    Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                 And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                                 And x.idArticulo = idarticulo Select x).FirstOrDefault

                                    'descontamos del inventario
                                    If inve.saldo >= cantidad * valmedida Or mdlPublicVars.ExistenciaCero = True Then
                                        inve.saldo = inve.saldo - CDec(cantidad * valmedida)
                                        inve.salida += CDec(cantidad * valmedida)
                                        conexion.SaveChanges()

                                    Else
                                        'cantidad a surtir.
                                        cantidadSurtir = CDbl((cantidad * valmedida) - inve.saldo)
                                        contadorSurtir = contadorSurtir + 1

                                        'descontar el saldo y enviar a pendientes por surtir.
                                        inve.salida = inve.salida + (inve.saldo)
                                        inve.saldo = 0

                                        Dim pendiente As New tblSurtir
                                        pendiente.salidaDetalle = detalle.idSalidaDetalle
                                        pendiente.articulo = detalle.idArticulo
                                        pendiente.cantidad = CDec(cantidadSurtir)
                                        pendiente.saldo = CDec(cantidadSurtir)
                                        pendiente.fechaTransaccion = fecha
                                        pendiente.anulado = False
                                        pendiente.usuario = mdlPublicVars.idUsuario
                                        pendiente.vendedor = CShort(mdlPublicVars.idVendedor)
                                        pendiente.cliente = salida.idCliente
                                        conexion.AddTotblSurtirs(pendiente)
                                        conexion.SaveChanges()

                                        If contadorSurtir = 1 Then
                                            errContenido += " Saldo Insuficiente, Desea Surtir :" + vbCrLf & articulo.nombre1 + vbCrLf
                                        ElseIf contadorSurtir > 1 Then
                                            errContenido += ", " & articulo.nombre1
                                        End If

                                        'success = False
                                        'Exit Try
                                    End If
                                End If

                                'Verifiamos si es surtir
                                If idSurtir > 0 Then

                                    'Modificamos el pendiente por surtir, para descontar de los pendientes por surtir del cliente.
                                    Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where (x.cliente = salida.idCliente) _
                                                                           And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Ascending).ToList
                                    Dim cantidadDescontar2 As Integer = CInt(cantidad)
                                    For Each p As tblSurtir In pendiente
                                        If cantidadDescontar2 > p.saldo Then
                                            cantidadDescontar2 -= CDec(p.saldo)
                                            p.saldo = 0
                                        Else
                                            p.saldo -= cantidadDescontar2
                                            cantidadDescontar2 = 0
                                        End If
                                        conexion.SaveChanges()
                                        If cantidadDescontar2 = 0 Then
                                            Exit For
                                        End If
                                    Next
                                ElseIf cantSurtir > 0 Then
                                    'Creamos el pendiente por surtir
                                    Dim pendiente As New tblSurtir
                                    pendiente.salidaDetalle = detalle.idSalidaDetalle
                                    pendiente.articulo = detalle.idArticulo
                                    pendiente.cantidad = cantSurtir
                                    pendiente.saldo = cantSurtir
                                    pendiente.fechaTransaccion = fecha
                                    pendiente.anulado = False
                                    pendiente.usuario = mdlPublicVars.idUsuario
                                    pendiente.vendedor = CShort(mdlPublicVars.idVendedor)
                                    pendiente.cliente = salida.idCliente
                                    conexion.AddTotblSurtirs(pendiente)
                                    conexion.SaveChanges()
                                End If

                                'Verificamos si tiene pendientes por pedir
                                Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                                                     Where Not x.anulado And x.saldo > 0 And x.articulo = idarticulo
                                                                                     Select x).ToList
                                Dim cantidadDescontar As Integer = CInt(cantidad)
                                'Recorremos la lista de pendientes
                                For Each pendiente As tblSurtir In lPendientes

                                    If cantidadDescontar > pendiente.saldo Then
                                        cantidadDescontar -= CInt(pendiente.saldo)
                                        pendiente.saldo = 0
                                    Else
                                        pendiente.saldo -= cantidadDescontar
                                        cantidadDescontar = 0
                                    End If
                                    conexion.SaveChanges()
                                    If cantidadDescontar = 0 Then
                                        Exit For
                                    End If
                                Next
                            End If
                        Next
                        conexion.SaveChanges()
                        If contadorSurtir > 0 Then
                            If RadMessageBox.Show(errContenido + vbCrLf + " Desea Continuar...", "Articulos pendientes por Surtir", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                                errContenido = "No se pudo Guardar"
                                success = False
                                Exit Try
                            End If
                        End If

                        Dim resultado As Integer = 0

                        resultado = fnEvaluarResolucion(codigoSalida, conexion
                                                        )
                        If resultado = 1 Then
                            RadMessageBox.Show("Debe verificar el Estado de la Resolucion Actual!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        ElseIf resultado = 2 Then
                            RadMessageBox.Show("La Resolucion actual ya no permite mas Facturas!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            success = False
                            Exit Function
                        ElseIf resultado = 3 Then
                            RadMessageBox.Show("Es el Final de la Resolucion, Cambiela para poder seguir Facturando!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        End If

                        'paso 8, completar la transaccion.
                        transaction.Complete()

                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            success = False
                            Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                            alerta.fnErrorGuardar()
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

            If success = True Then
                conexion.AcceptAllChanges()
                conexion.Dispose()
            End If
            'cerrar la conexion.
            conn.Close()
        End Using

        If success Then
            conexion.AcceptAllChanges()
            alerta.fnGuardar()
            bitEditarSalida = False
            'fnImprimirPequenio(codigoSalida, ventacontado)

            'Mostramos la ventana de Bitacora, Usando la Variable global de configuración para conocer si se pide bitacora o No.
            AgregaBitacora(mdlPublicVars.Salida_BitaAlDespachar)
            Return codigoSalida
            fnNuevaFila()
        Else
            If autorizaCredito = True Then
                alerta.fnErrorAutorizacionCredito()
            Else
                alerta.contenido = errContenido
                alerta.fnErrorContenido()
                Console.WriteLine("La operacion no pudo ser completada")
            End If
            Return -1
        End If
    End Function

    Private Function fnEvaluarResolucion(ByVal codigo As Integer, ByVal conexion As dsi_pos_demoEntities) As Integer
        Try
            Dim fin As Integer
            Dim correl As Integer

            fin = (From x In conexion.tblResolucionFacturas Where x.habilitado = True Select x.final).FirstOrDefault
            correl = (From x In conexion.tblResolucionFacturas Where x.habilitado = True Select x.correlativo).FirstOrDefault

            If (fin - correl) = 0 Then
                Return 3
            ElseIf (fin - correl) < 0 Then
                Return 2
            ElseIf (fin - correl) <= 5 And (fin - correl) > 0 Then
                Return 1
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 1
        End Try

    End Function

#End Region

End Class
