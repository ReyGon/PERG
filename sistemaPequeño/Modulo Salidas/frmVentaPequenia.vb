Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
''Imports System.Windows
Imports System.Data.EntityClient
Imports System.Transactions
Imports Telerik.WinControls.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net.Mail
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmVentaPequenia

#Region "Variables Publicas"
    Public inventario As Integer = 0
    Public facturarVentaPequenia As New cls_FacturarVentaPequenia
    Public codigoSalida As Integer = 0
#End Region

#Region "Variables"
    Dim municipio As Integer = 0
    Dim clavecli As Integer = 0
    Dim totProrrateo As Double = 0.0
    Public nombrecliente As String
#End Region

#Region "Variables Privadas"
    Private codigoCliente As Integer  'variable que nos va a capturar el idcliente cuandose va modificar una cotizacion
    Private codigoSalidaAFacturar As Integer ' para facturar las salida Venta pequenia
    Private permiso As New clsPermisoUsuario
    Private valida As New bl_Pedidos

    Private _bitEditarSalida As Boolean
    Private _bitEditarBodega As Boolean
    Private _bitFactura As Boolean
    Private _bitSugerirDespacho As Boolean
    Private _bitSugerirReserva As Boolean
    Private _codigo As Integer
    Private _codFact As Integer
    Private _ventaPequenia As Integer
    Private _venta As Integer
    Private _tblGuias As New DataTable

    ''Private _listaTransportes As List(Of tblSalidasTransporte)
    ''Private _listaTransportesEliminar As List(Of tblSalidasTransporte)
    Private _codigoCosteo As String

    Public Property tblGuias As DataTable
        Get
            tblGuias = _tblGuias
        End Get
        Set(ByVal value As DataTable)
            _tblGuias = value
        End Set
    End Property

#End Region

#Region "Propiedades"
    Public Property venta As Integer
        Get
            venta = _venta
        End Get
        Set(ByVal value As Integer)
            _venta = value
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

    Public Property bitEditarBodega() As Boolean
        Get
            bitEditarBodega = _bitEditarBodega
        End Get
        Set(ByVal value As Boolean)
            _bitEditarBodega = value
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

    Public Property ventaPequenia() As Integer
        Get
            ventaPequenia = _ventaPequenia
        End Get
        Set(value As Integer)
            _ventaPequenia = value
        End Set
    End Property

    Public Property codigoCosteo As String
        Get
            codigoCosteo = _codigoCosteo
        End Get
        Set(value As String)
            _codigoCosteo = value
        End Set
    End Property

    ''Public Property listaTransportes As List(Of tblSalidasTransporte)
    ''    Get
    ''        listaTransportes = _listaTransportes
    ''    End Get
    ''    Set(value As List(Of tblSalidasTransporte))
    ''        _listaTransportes = value
    ''    End Set
    ''End Property

    ''Public Property listaTransportesEliminar As List(Of tblSalidasTransporte)
    ''    Get
    ''        listaTransportesEliminar = _listaTransportesEliminar
    ''    End Get
    ''    Set(value As List(Of tblSalidasTransporte))
    ''        _listaTransportesEliminar = value
    ''    End Set
    ''End Property

#End Region

#Region "Eventos"
    'LOAD
    Private Sub frmVentaPequenia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        mdlPublicVars.supersearchclientelibre = False
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        mdlPublicVars.fnGrid_iconos(grdProductos)
        mdlPublicVars.comboActivarFiltroLista(cmbInventario)

        inventario = mdlPublicVars.General_idTipoInventario
        fnNuevo()
        fnNuevaFila()
        Me.grdProductos.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        grdProductos.CloseEditorWhenValidationFails = True
        grdProductos.StandardTab = False

        If bitEditarBodega Or bitEditarSalida Then
            txtClave.Enabled = False
            lbl3.Text = "Modificar"
            pbx3.Image = Global.laFuente.My.Resources.Resources.modificar_Blanco
        End If

        If mdlPublicVars.bitVenta_Pequenia_Descuentos Then
            Me.grdProductos.Columns("txmDescuento").IsVisible = True
            Me.grdProductos.Columns("txmDescuento").Width = 100
        Else
            Me.grdProductos.Columns("txmDescuento").IsVisible = False
        End If

        If mdlPublicVars.bitVenta_Pequenia_Recargos Then
            Me.grdProductos.Columns("txmRecargo").IsVisible = True
        Else
            Me.grdProductos.Columns("txmRecargo").IsVisible = False
        End If

        If mdlPublicVars.bitUnidadMedida_Activado = False Then
            Me.grdProductos.Columns("txbUnidadMedida").IsVisible = False
            Me.grdProductos.Columns("precio").IsVisible = False
        Else
            Me.grdProductos.Columns("txbUnidadMedida").IsVisible = True
            Me.grdProductos.Columns("precio").IsVisible = True
        End If

        If mdlPublicVars.bitTransportePesado Then
            Me.grdProductos.Columns("chmTransporte").IsVisible = True
        Else
            Me.grdProductos.Columns("chmTransporte").IsVisible = False
        End If
      

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

        '       fnSumarios()

    End Sub

    'BUSCAR POR NIT
    Private Sub txtNit_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNit.KeyDown

        If e.KeyCode = Keys.F4 Then
            Try
                frmBuscarCliente.Text = "Buscar Cliente"
                frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmBuscarCliente)
                frmBuscarCliente.Dispose()

                If superSearchNit.Length > 0 Then
                    Dim codigo As String = CType(superSearchNit, String)
                    Me.txtNit.Text = codigo
                    clavecli = superSearchId

                    If codigo.Trim = "C/F" Then
                        fnClave()
                    Else
                        fnNit()
                    End If

                End If
            Catch
            End Try
        End If

        If e.KeyCode = Keys.F4 Then
            Me.grdProductos.Focus()
            Me.grdProductos.Columns("txbProducto").IsCurrent = True
        End If

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            'hacer que codigo cliente sea cero
            codigoCliente = 0
            'Verifica si presiono la tecla ENTER
            If e.KeyCode = Keys.Enter Then
                Try
                    txtClave.Text = ""
                    txtCliente.Text = ""
                    codigoCliente = 0
                    'conexion nueva.
                    Dim conexion As New dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                        '1ro. buscar el cliente.
                        Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.nit1.Equals(Me.txtNit.Text.Trim) Select x).FirstOrDefault

                        '2do. si no existe crearlo.
                        If cliente Is Nothing Then
                            If RadMessageBox.Show("El Cliente no Existe. ¿Desea Crearlo?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                frmClientePequenio.Text = "Clientes"
                                frmClientePequenio.txtNit.Text = txtNit.Text
                                frmClientePequenio.ShowDialog()
                                frmClientePequenio.Dispose()

                                If mdlPublicVars.superSearchId = 0 Then
                                    'si el retorno no es correcto salir de la funcion.
                                    Exit Sub
                                Else
                                    txtClave.Text = mdlPublicVars.superSearchClave
                                    txtCliente.Text = mdlPublicVars.superSearchNombre
                                    codigoCliente = mdlPublicVars.superSearchId
                                    lblFaltante.Text = "0.00"
                                End If
                            Else
                                Exit Sub
                            End If
                        Else
                            'codigo de cliente existe.
                            codigoCliente = cliente.idCliente
                        End If

                        If codigoCliente > 0 Then
                            Me.grdProductos.Columns("txmCodigo").ReadOnly = False
                        Else
                            Me.grdProductos.Columns("txmCodigo").ReadOnly = True
                        End If

                        If codigoCliente <> Nothing Then
                            'consulta el cliente
                            Dim cliente2 As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codigoCliente Select x).FirstOrDefault

                            'informacion del cliente
                            txtClave.Text = cliente2.clave
                            txtNit.Text = cliente2.nit1
                            txtCliente.Text = cliente2.Nombre1
                            txtNombreFacturacion.Text = cliente2.Negocio
                            municipio = cliente2.idMunicipio

                            If cliente2.bitMostrador = True Then
                                txtNombreFacturacion.Enabled = True
                            Else
                                Me.txtNombreFacturacion.Enabled = False
                            End If

                            'informacion de credito.
                            lblFaltante.Text = "0.00"
                            rbnCredito.Checked = CBool(cliente2.tblClienteTipoPago.credito)
                            rbnContado.Checked = Not CBool(cliente2.tblClienteTipoPago.credito)
                        End If
                        conn.Close()
                    End Using
                Catch ex As Exception
                    txtClave.Text = ""
                    txtNit.Text = ""
                    txtCliente.Text = ""
                    rbnCredito.Checked = False
                    rbnContado.Checked = False
                End Try
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            Me.grdProductos.Focus()
            Me.grdProductos.Columns("txbProducto").IsCurrent = True
        End If
    End Sub

    'EVENTOS PARA F2 EN ARTICULOS
    Private Sub grdProductos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If Me.grdProductos.RowCount > 0 Then
            ''fnBloquearCombo()
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
                    If Me.grdProductos.Columns("txbunidadmedida").IsCurrent Then
                        mdlPublicVars.superSearchId = 0
                        mdlPublicVars.superSearchNombre = ""
                        fnConcepto()
                        fnActualizar_Total()
                        ''If e.KeyCode = Keys.F2 Then
                    Else
                        'frm BuscarArticulo.bandera = True 'Cambio de estado para saber que se esta llamando de este formulario
                        If Me.grdProductos.Columns(c).Name = "txbPrecioBase" Then
                            frmBuscarArticuloPrecios.Text = "Precios"
                            frmBuscarArticuloPrecios.codigo = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("ID").Value, Integer)
                            frmBuscarArticuloPrecios.codClie = codigoCliente
                            frmBuscarArticuloPrecios.bitVentas = True
                            frmBuscarArticuloPrecios.StartPosition = FormStartPosition.CenterScreen
                            frmBuscarArticuloPrecios.formVentaPequenia = Me
                            permiso.PermisoFrmEspeciales(frmBuscarArticuloPrecios, False)
                        ElseIf Me.grdProductos.Columns(c).Name = "precio" Then
                            'Verificamos si se tiene que proratear
                            Dim conexion As dsi_pos_demoEntities
                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                conn.Close()
                            End Using
                        ElseIf Me.grdProductos.Columns(c).Name = "txbObservacion" Then
                            'Obtenemos el valor de la observacion actual
                            Dim texto As String = CStr(Me.grdProductos.Rows(f).Cells(c).Value)
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
                            If (codigoCliente > 0) Then
                                If Me.grdProductos.CurrentRow.Index >= 0 Then
                                    If Me.grdProductos.Rows(f).Cells(c).Value Is Nothing Then
                                        mdlPublicVars.superSearchNombre = ""
                                    Else
                                        mdlPublicVars.superSearchNombre = LTrim(RTrim(CStr(Me.grdProductos.Rows(f).Cells(c).Value)))
                                    End If

                                    frmBuscarArticuloVentaPequenia.codClie = codigoCliente
                                    frmBuscarArticuloVentaPequenia.codVendedor = CInt(cmbVendedor.SelectedValue)
                                    frmBuscarArticuloVentaPequenia.StartPosition = FormStartPosition.CenterScreen
                                    frmBuscarArticuloVentaPequenia.OpcionRetorno = "salidas"
                                    frmBuscarArticuloVentaPequenia.Text = "Buscar Articulos"
                                    frmBuscarArticuloVentaPequenia.bitCliente = True
                                    frmBuscarArticuloVentaPequenia.bitProveedor = False
                                    frmBuscarArticuloVentaPequenia.grdIngresados = grdProductos
                                    frmBuscarArticuloVentaPequenia.ventaPequenia = 1
                                    frmBuscarArticuloVentaPequenia.formVentaPequenia = Me
                                    mdlPublicVars.SiempreEncima(Me.Handle.ToInt32)

                                    permiso.PermisoDialogEspeciales(frmBuscarArticuloVentaPequenia)
                                End If
                            Else
                                alerta.contenido = "Seleccione Cliente"
                                alerta.fnErrorContenido()
                                txtCliente.Focus()
                            End If
                        End If
                    End If
                End If
            ElseIf bitEditarBodega And f >= 0 Then
                If Me.grdProductos.Columns(c).Name = "txbAjuste" Then
                    'fnMuestraCombo()
                    mdlPublicVars.superSearchId = 0
                    mdlPublicVars.superSearchNombre = ""
                    fnMuestraCombo()
                ElseIf e.KeyCode = Keys.F2 Then
                    If Me.grdProductos.Columns(c).Name = "txbObservacion" Then
                        'Obtenemos el valor de la observacion actual
                        Dim texto As String = CStr(Me.grdProductos.Rows(f).Cells(c).Value)

                        frmTexto.Text = "Ingresar Observacion"
                        frmTexto.texto = If(texto Is Nothing, "", texto)
                        frmTexto.StartPosition = FormStartPosition.CenterScreen
                        frmTexto.ShowDialog()

                        If mdlPublicVars.superSearchId > 0 Then
                            If frmTexto.guarda = True Then
                                Me.grdProductos.Rows(f).Cells(c).Value = mdlPublicVars.superSearchNombre
                            End If
                        End If
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

    Private Sub fnConcepto()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            ''If rbtAjuste.Checked = True Then
            ''    consulta = (From x In conexion.tblTipoMovimientoes Where x.ajuste And Not x.ajusteVenta Select codigo = x.idTipoMovimiento, nombre = x.nombre)
            ''Else
            ''    consulta = (From x In conexion.tblTipoMovimientoes Where x.traslado And Not x.ajusteVenta Select codigo = x.idTipoMovimiento, nombre = x.nombre)
            ''End If

            Dim articulo As Integer
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)

            articulo = CType(Me.grdProductos.Rows(fila).Cells("id").Value, Integer)

            Dim lista As tblArticulo_UnidadMedida = (From x In conexion.tblArticulo_UnidadMedida Where x.idArticulo = articulo Select x).FirstOrDefault

            If lista Is Nothing Then
                RadMessageBox.Show("El Producto no es Unidad de Medida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                frmSeleccion.Text = "Buscar Cliente"
                frmSeleccion.bitunidadmedida = True
                frmSeleccion.codigo = articulo
                frmSeleccion.bitProduccion = False
                frmSeleccion.bitVenta = True
                frmSeleccion.StartPosition = FormStartPosition.CenterScreen
                frmSeleccion.ShowDialog()
                frmSeleccion.Dispose()

                If mdlPublicVars.superSearchIdUnidadMedida > 0 Then
                    Me.grdProductos.Rows(fila).Cells("IdUnidadMedida").Value = mdlPublicVars.superSearchIdUnidadMedida
                    Me.grdProductos.Rows(fila).Cells("txbUnidadMedida").Value = mdlPublicVars.superSearchUnidadMedida
                    Me.grdProductos.Rows(fila).Cells("ValorUnidadMedida").Value = mdlPublicVars.superSearchUnidadMedidaValor
                    Me.grdProductos.Rows(fila).Cells("txbPrecioBase").Value = mdlPublicVars.superSearchPrecio
                End If
            End If

            conn.Close()
        End Using
    End Sub

    'FIN DE EDICION DE ARTICULOS
    Private Sub grdProductos_CellEndEdit(sender As System.Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Dim fila As Integer = Me.grdProductos.CurrentRow.Index
        If e.Column.Name = "txmCodigo" Then
            Dim codigo As String = CStr(e.Value)

            If codigo IsNot Nothing Then
                If codigo.Length > 0 Then
                    fnBuscarArticulo(codigo, e.RowIndex)
                End If
            End If
        End If

        If e.Column.Name = "txmCantidad" Or e.Column.Name = "txmCosto" Or e.Column.Name = "txmCantidadAjuste" Or e.Column.Name = "txmRecargo" Or e.Column.Name = "txmDescuento" Then
            fnActualizar_Total()
        End If

        grdProductos.CloseEditor()
        grdProductos.CancelEdit()
        grdProductos.EditorManager.CloseEditor()
        grdProductos.EditorManager.CancelEdit()
    End Sub

    'INVOCACION DEL EDITOR EN EL GRID
    Private Sub grdProductos_EditorRequired(sender As System.Object, e As Telerik.WinControls.UI.EditorRequiredEventArgs) Handles grdProductos.EditorRequired
        grdProductos.BeginUpdate()
        grdProductos.EndUpdate()
    End Sub

    'CAMBIA DE SELECCION DE PRODUCTO
    Private Sub grdProductos_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles grdProductos.SelectionChanged
        fnArticulo_informacion()
    End Sub

    'DOBLE CLICK EN EL GRID DE PRODUCTOS
    Private Sub grdProductos_CellDoubleClick(sender As System.Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellDoubleClick
        fnMuestraCombo()
    End Sub

    'EL USUARIO ELIMINA UNA FILA
    Private Sub grdProductos_UserDeletedRow(sender As System.Object, e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        If Me.grdProductos.Rows.Count = 0 Then
            Me.grdProductos.Rows.AddNew()
        End If
        fnActualizar_Total()
    End Sub

    'INFORMACION DEL CLIENTE
    Private Sub btnInfoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoCliente.Click
        Try
            Dim codCliente As Integer = CInt(codigoCliente)
            If codCliente > 0 Then
                frmInformacionCliente.codcliente = codigoCliente
                frmInformacionCliente.ventaActual = CDbl(lblTotal.Text)
                frmInformacionCliente.Text = "Informacion de Cliente"
                frmInformacionCliente.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmInformacionCliente)
                frmInformacionCliente.Dispose()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub
#End Region

#Region "Funciones Basicas"
    'NUEVO PEDIDO
    Private Sub fnNuevo()
        llenarCombos()
        ''listaTransportes = New List(Of tblSalidasTransporte)
        lblTotal.Text = Format(0, mdlPublicVars.formatoMoneda)
        lblSubtotal.Text = Format(0, mdlPublicVars.formatoMoneda)
        lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)
        ''lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)
        ''lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)
        ''lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)
        ''lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)
        lblRecuento.Text = "0"
        txtClave.Enabled = True
        If verRegistro = True Or bitEditarBodega = True Or bitEditarSalida = True Then
            pnx1Cotizar.Visible = False
            pnx2Reservar.Visible = False
            Me.grdProductos.AllowDeleteRow = False
        End If
        fnNuevaFila()

        'si esta en modo edicion, que no permita eliminar productos solo colocar en existencia 0
        If bitEditarBodega = True Then
            'EDITAR EN BODEGA.
            Me.grdProductos.AllowDeleteRow = False
            dtpFechaRegistro.Enabled = False
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
            End If
        ElseIf bitEditarSalida = True Then
            'EDITAR SALIDA
            'no permite eliminar productos del grid.
            Me.grdProductos.AllowDeleteRow = False

            'deshabilita opciones de encabezado.
            dtpFechaRegistro.Enabled = False
            'cmbCliente.Enabled = False
            cmbInventario.Enabled = False
            cmbVendedor.Enabled = False
            'cmbDirEnvios.Enabled = False

            'oculta las columnas que sirven en ajuste de bodega.
            'Me.grdProductos.Columns("idajuste").IsVisible = False
            Me.grdProductos.Columns("idajustecategoria").IsVisible = False
            Me.grdProductos.Columns("txbAjuste").IsVisible = False
            Me.grdProductos.Columns("txmCantidadAjuste").IsVisible = False

            If chkCotizado.Checked And Not chkDespachado.Checked Then
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

            If verRegistro = True Then
                Me.grdProductos.Columns("txmCantidadSurtir").IsVisible = False
            End If
        Else
            'NUEVO PEDIDO
            'asignacion de vendedor.
            cmbVendedor.SelectedValue = mdlPublicVars.idVendedor
            ''cmbVendedor.Enabled = False

            'estado del pedido.
            chkCotizado.Checked = False
            chkDespachado.Checked = False

            'si editar = false,  nuevo
            Me.grdProductos.AllowDeleteRow = True
            dtpFechaRegistro.Enabled = True

            txtNit.Text = ""
            txtCodigo.Text = ""
            txtCliente.Text = ""
            txtClave.Text = ""
            txtNombreFacturacion.Text = ""
            dtpFechaRegistro.Text = Format(Now, mdlPublicVars.formatoFecha).ToString
            lblDocumento.Text = fnCorrelativo().ToString
            Me.grdProductos.Rows.Clear()

            'Me.grdProductos.Columns("idajuste").IsVisible = False
            Me.grdProductos.Columns("idajustecategoria").IsVisible = False
            Me.grdProductos.Columns("txbAjuste").IsVisible = False
            Me.grdProductos.Columns("txmCantidadAjuste").IsVisible = False
            Me.grdProductos.Columns("txmCantidad").ReadOnly = False
            Me.grdProductos.Columns("txmCantidadSurtir").IsVisible = False

            'fnNuevaFila()

            'ponemos false imprimir factuar
            mdlPublicVars.bitImprimirFacturaVentaPequenia = False
            mdlPublicVars.bitCrearFacturaVentaPequenia = False
            mdlPublicVars.listaDeFacturas.Clear()
        End If
        'fnVerificaCredito()
        ''dtpFechaRegistro.Select()
        ''dtpFechaRegistro.Focus()
        Me.txtNit.Select()
        Me.txtNit.Focus()
    End Sub

    'LLENAR LOS COMBOS EN LA VENTANA PRINCIPAL
    Private Sub llenarCombos()
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            'consultar vendedores.
            ''Dim lVendedores As IQueryable = (From x In conexion.tblVendedors Select Codigo = CType(0, Integer), Nombre = CType("<-- Ninguno -->", String)).Union( _
            ''                From s In conexion.tblVendedors _
            ''                Select Codigo = CType(s.idVendedor, Integer), Nombre = CType(s.nombre, String) Order By Nombre)

            Dim lVendedores As IQueryable = (From s In conexion.tblVendedors Select Codigo = CType(s.idVendedor, Integer), Nombre = CType(s.nombre, String) Order By Nombre)

            'llenar el combo de vendedores.
            With Me.cmbVendedor
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = lVendedores
            End With
            cmbVendedor.Select(0, 0)
            'consultar clientes
            Me.cmbVendedor.SelectedValue = mdlPublicVars.idVendedor

            'Llenamos los inventario
            Dim lInventarios As IQueryable = (From x In conexion.tblTipoInventarios _
                                            Select Codigo = x.idTipoinventario, Nombre = x.nombre)

            With Me.cmbInventario
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = lInventarios
            End With

            conn.Close()
        End Using
    End Sub

    'INDICADORES PRINCIPALES
    Private Sub fnIndicadores()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                'NUEVO
                Dim fechaActual As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                Dim diferenciaMes As DateTime = fechaActual.AddDays(-mdlPublicVars.Empresa_DiasUltimosProductos)

                'ulo.tblUnidadMedida.nombre, txmSurtir = 0)
                Dim tabla As List(Of sp_buscar_Articulo_Result) = conexion.sp_buscar_Articulo(mdlPublicVars.idEmpresa, diferenciaMes.ToShortDateString, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, "", "", 1, 8, True, False, "", venta).ToList

                lblConteoNuevo.Text = tabla.Count.ToString
                If tabla.Count > 0 Then
                    lblFondoNuevo.BackColor = Color.Green
                Else
                    lblFondoNuevo.BackColor = Color.White
                End If

                'OFERTAS
                diferenciaMes = fechaActual.AddDays(-mdlPublicVars.General_NumeroDiasBitacoraProductos)
                Dim ofertas As Integer = (From x In conexion.tblBitacoraPreciosArticuloes Where x.fechaRegistro > diferenciaMes _
                                        And x.tblArticulo_Precio.tipoPrecio = mdlPublicVars.BuscarArticulo_CodigoOferta And x.tblArticulo_Precio.habilitado = True Select x).Count

                lblConteoOfertas.Text = ofertas.ToString
                If tabla.Count > 0 Then
                    lblFondoOferta.BackColor = Color.Green
                Else
                    lblFondoOferta.BackColor = Color.White
                End If
            Catch ex As Exception
                RadMessageBox.Show("Error en Indicadores : " + ex.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
            conn.Close()
        End Using
    End Sub

    'OBTENER EL CORRELATIVO
    Private Function fnCorrelativo() As Integer
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
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
                    correlativoNuevo.idTipoMovimiento = CShort(mdlPublicVars.Salida_TipoMovimientoVenta)
                    conexion.AddTotblCorrelativos(correlativoNuevo)
                    conexion.SaveChanges()
                    Return 1
                End If
            Catch ex As Exception
                Return 0
            End Try
            conn.Close()
        End Using
    End Function

    'AGREGAR NUEVA FILA AL GRID DE PRODUCTOS
    Public Sub fnNuevaFila()
        fnEliminaVacias()
        Me.grdProductos.Rows.AddNew()
        ''If superSearchValorDescuento > 0 Then
        ''    fnAgregarDescuento(superSearchValorDescuento)
        ''End If
    End Sub

    'ELIMINA FILAS VACIAS
    Private Sub fnEliminaVacias()
        Try
            'Recorremos el grid

            Dim nombre As String = ""
            For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
                'Obtenemo el valor del nombre
                nombre = CStr(Me.grdProductos.Rows(i).Cells("txbProducto").Value)

                If IsNothing(nombre) Then
                    Me.grdProductos.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'LLENAR LOS DATOS DE UN PEDIDO
    Private Sub fnLlenarDatos()
        Try
            grdProductos.Rows.Clear()
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim salida As tblSalida = (From x In conexion.tblSalidas.AsEnumerable Where x.idSalida = codigo Select x).First()
                inventario = CInt(salida.idTipoInventario)
                codigoCliente = CInt(salida.idCliente)
                txtCodigo.Text = salida.idSalida.ToString

                'llenamos datos del cliente
                Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codigoCliente Select x).FirstOrDefault
                txtClave.Text = cliente.clave
                'se agrego para mostrar datos de mostrador
                txtCliente.Text = salida.cliente
                txtNit.Text = salida.nit
                cmbVendedor.SelectedValue = salida.idVendedor
                cmbVendedor.Select(0, 0)
                lblDocumento.Text = salida.documento
                dtpFechaRegistro.Text = Format(salida.fechaRegistro, mdlPublicVars.formatoFecha)
                rbnContado.Checked = CBool(salida.contado)
                rbnCredito.Checked = CBool(salida.credito)
                ' estado
                chkCotizado.Checked = CBool(salida.cotizado)
                chkReservado.Checked = CBool(salida.reservado)
                chkDespachado.Checked = CBool(salida.despachar)

                'Obtenemos la lista de detalles
                Dim listaDetalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = codigo Select x).ToList
                Dim detalle As tblSalidaDetalle

                For Each detalle In listaDetalles
                    If detalle.anulado = False And detalle.kitSalidaDetalle Is Nothing Then

                        Dim idunidadmedida As Integer = 0
                        Dim valormedida As Integer = 0
                        Dim unidadmedida As String = ""

                        Try
                            Dim unidad As tblArticulo_UnidadMedida = (From x In conexion.tblArticulo_UnidadMedida Where x.idArticulo = detalle.idArticulo Select x).FirstOrDefault

                            idunidadmedida = unidad.idUnidadMedida
                            valormedida = unidad.valor
                            unidadmedida = unidad.tblUnidadMedida.nombre

                        Catch ex As Exception

                            idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                            valormedida = 1
                            unidadmedida = "Unidad"

                        End Try


                        Dim fila As Object()
                        fila = {detalle.idSalidaDetalle, detalle.idArticulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, idunidadmedida, unidadmedida, valormedida, detalle.cantidad, Format(detalle.precioOriginal, mdlPublicVars.formatoMoneda), _
                             "0", "0", 0, 0, detalle.comentario, "0", "", "0", "0", "0", "0", detalle.tipoInventario, detalle.tipoPrecio, "", "0.00", True, detalle.tipobodega}
                        grdProductos.Rows.Add(fila)
                    End If
                Next

                '********* TRANSPORTE
                ''listaTransportes = salida.tblSalidasTransportes.ToList
                '********* FIN DE TRANSPORTE
                'fnNuevaFila()

                fnActualizar_Total()
                conn.Close()
            End Using

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'AGREGAR ARTICULO
    Public Sub fnAgregar_Articulos(ByVal surtir As Boolean)
        'agregar productos a grid.
        Dim filas() As Object

        '' ''Buscamos si el producto a agregar ya esta agregado
        ''Dim fila As GridViewRowInfo = (From x In Me.grdProductos.Rows Where x.Cells("txmCodigo").Value.Equals(mdlPublicVars.superSearchCodigo) _
        ''                 And x.Cells("txbProducto").Value.Equals(mdlPublicVars.superSearchNombre) Select x).FirstOrDefault

        ''If fila IsNot Nothing Then
        ''    fila.Cells("txmCantidad").Value = CInt(fila.Cells("txmCantidad").Value) + mdlPublicVars.superSearchCantidad
        ''    fila.Cells("txmCantidadSurtir").Value = mdlPublicVars.superSearchSurtir
        ''Else

        '' Agregar el costo
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim articulo As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = mdlPublicVars.superSearchId Select x).FirstOrDefault

            'id, codigo,nombre,precio,cantidad
            filas = {"0", mdlPublicVars.superSearchId.ToString, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchIdUnidadMedida, mdlPublicVars.superSearchUnidadMedida, mdlPublicVars.superSearchUnidadMedidaValor, mdlPublicVars.superSearchCantidad.ToString,
                     Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), 0, 0, Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", "", 0, "", 0, 0, 0,
                     mdlPublicVars.superSearchSurtir.ToString, mdlPublicVars.superSearchInventario.ToString, mdlPublicVars.superSearchTipoPrecio.ToString, mdlPublicVars.superSearchEstado.ToString,
                     articulo.costoIVA, True, superSearchBodega}
            conn.Close()
        End Using

        Try
            grdProductos.Rows.Add(filas)
        Catch ex As Exception

        End Try

        If surtir Then
            Me.grdProductos.Rows(Me.grdProductos.RowCount - 1).IsVisible = False
        End If

        ''End If

        grdProductos.Columns("txbProducto").IsCurrent = True
        grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        fnActualizar_Total()
    End Sub

    'LLENAR FACTURA
    Private Sub fnLlenarFactura(ByVal codigo As Integer)
        Try
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                'Obtenemos los datos de la factura
                Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigo Select x).FirstOrDefault
                dtpFechaRegistro.Value = CDate(factura.Fecha)
                rbnContado.Checked = CBool(factura.contado)
                rbnCredito.Checked = CBool(factura.contado)

                'Obtenemos los pedidos de la factura
                Dim lPedidos As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.IdFactura = codigo _
                                                  And x.anulado = False Select x).ToList

                Dim pedido As tblSalida
                Dim dirEnvios As String = ""
                Dim vendedores As String = ""
                Dim documentos As String = ""
                For Each pedido In lPedidos
                    codigoCliente = CInt(pedido.idCliente)
                    vendedores += pedido.tblVendedor.nombre & ", "
                    dirEnvios += pedido.direccionEnvio & ","
                    documentos += pedido.documento & ", "
                    txtCliente.Text = pedido.cliente
                    txtNit.Text = pedido.nit

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

                'cmbDirEnvios.Text = dirEnvios
                cmbVendedor.Text = vendedores
                cmbVendedor.Select(0, 0)
                lblDocumento.Text = documentos

                conn.Close()
            End Using

            fnActualizar_Total()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'COMBO PARA TIPO DE AJUSTE
    Private Sub fnMuestraCombo()
        Try
            Dim col As Integer = Me.grdProductos.CurrentColumn.Index
            Dim fil As Integer = Me.grdProductos.CurrentRow.Index

            'Sacado
            If Me.grdProductos.Columns(col).Name.ToString.ToLower = "txbajuste" Then

                Dim lAjustes As IQueryable = Nothing
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


                    lAjustes = (From x In conexion.tblTipoMovimientoes.AsQueryable Select Codigo = CType(0, Integer), Nombre = CType("<-- Ninguno -->", String)).Union( _
                                From x In conexion.tblTipoMovimientoes.AsQueryable
                                Where x.ajusteVenta
                                Select Codigo = CType(x.idTipoMovimiento, Integer), Nombre = CType(x.nombre + " : " + If(x.idTipoInventario Is Nothing, "", x.tblTipoInventario.nombre), String))

                    conn.Close()
                End Using

                With frmCombo.combo
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = lAjustes
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

                fnActualizar_Total()

            End If ' fin de sacado.

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'REMOVER LA FILA ACTUAL DEL GRID DE PRODUCTOS
    Public Sub fnRemoverFila()
        Try
            Dim filaActual As Integer = CType(Me.grdProductos.CurrentRow.Index, Integer)

            If filaActual >= 0 Then
                Dim index As Integer = 0
                Dim yaBorro As Boolean = False

                For index = filaActual To Me.grdProductos.Rows.Count - 1
                    Dim codigoArt As Integer = CType(Me.grdProductos.Rows(filaActual).Cells("Id").Value, Integer)
                    If yaBorro = False And codigo = 0 Then
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

        End Try
        
    End Sub

    'AGREGAR PENDIENTES POR SURTIR
    Public Sub fnAgregar_Pendientes()
        'agregar productos a grid.
        Dim filas() As Object

        'id, codigo,nombre,precio,cantidad
        filas = {"0", mdlPublicVars.superSearchId.ToString, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchCantidad.ToString,
                 Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", False, "", 0, "", 0, 0,
                 mdlPublicVars.superSearchCodSurtir, mdlPublicVars.superSearchSurtir, mdlPublicVars.General_idTipoInventario.ToString,
                 mdlPublicVars.superSearchTipoPrecio, mdlPublicVars.superSearchEstado}
        grdProductos.Rows.Add(filas)
        grdProductos.Columns("txmCantidad").IsCurrent = True
        grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        fnActualizar_Total()
    End Sub

    'AGREGAR PRECIO
    Public Sub fnAgregarPrecio(ByVal especial As Boolean)
        Try
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbPrecioBase").Value = Format(CType(mdlPublicVars.superSearchPrecio, Decimal), mdlPublicVars.formatoMoneda)
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("TipoPrecio").Value = CType(mdlPublicVars.superSearchTipoPrecio, Integer)



            'validar que la salida no este en estado de despacho.
            If bitEditarBodega = True And codigo > 0 Then
                Dim s As tblSalida
                Dim conexion As New dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    s = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                    conn.Close()
                End Using

                'si despachado es falso actualizar la cantidad, de lo contrario no actualizar, solo precio.
                If Not s.despachar Then
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value = CType(mdlPublicVars.superSearchCantidad, Integer)
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'FUNCION UTILIZADA PARA VERIFICAR SI TIENE ARTICULOS EL GRID
    Private Function fnCuentaArticulos() As Boolean
        Dim nombre As String = ""
        For i As Integer = 0 To Me.grdProductos.RowCount - 1
            nombre = CStr(Me.grdProductos.Rows(i).Cells("txbProducto").Value)

            If nombre IsNot Nothing Then
                Return True
            End If
        Next
        Return False
    End Function

    'BUSCAR ARTICULO EN BASE A CODIGO
    Public Sub fnBuscarArticulo(ByVal codigo As String, ByVal posicion As Integer)
        Dim bitNuevaFila As Boolean = False
        Try

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

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
                    cantidad = CInt(codigoBarra.unidadEmpaque)
                End If

                If articulo Is Nothing And codigoBarra Is Nothing Then
                    alerta.contenido = "Este producto no existe"
                    alerta.fnErrorContenido()
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCodigo").Value = ""
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCodigo").BeginEdit()
                Else
                    Dim codCliente As Integer = codigoCliente
                    'Obtenemos el tipo de negocio del cliente
                    Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codCliente Select x).FirstOrDefault
                    Dim tNegocio As Integer = CInt(cliente.idTipoNegocio)

                    'Seleccionamos el precio del articulo
                    Dim precioArt As tblArticulo_TipoNegocio = (From x In conexion.tblArticulo_TipoNegocio.AsEnumerable Where x.articulo = articulo.idArticulo And _
                                                               x.tipoNegocio = tNegocio Select x).FirstOrDefault
                    Dim precio As Decimal = 0
                    'Asignamos el precio
                    If precioArt IsNot Nothing Then
                        precio = CDec((From x In conexion.sp_redondearPrecio(precioArt.tblArticulo.precioPublico * (100 - precioArt.descuento) / 100) Select PrecioRetornado = x.Value).FirstOrDefault)
                    Else
                        alerta.contenido = "Producto: " & articulo.nombre1 & " no tiene precio!"
                        alerta.fnErrorContenido()

                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCodigo").BeginEdit()
                        Exit Sub
                    End If

                    Dim artEstado As tblArticulo = (From x In conexion.tblArticuloes Where x.codigo1 = codigo Select x).FirstOrDefault
                    Dim estadoPedido As Integer = CInt((From x In conexion.spArticulo_EstadoDePrecio(artEstado.idArticulo, codCliente) Select x.Estado).FirstOrDefault)

                    'Agregamos el producto
                    Me.grdProductos.Rows(posicion).Cells("iddetalle").Value = "0"
                    Me.grdProductos.Rows(posicion).Cells("id").Value = articulo.idArticulo
                    Me.grdProductos.Rows(posicion).Cells("txmCodigo").Value = codigo
                    Me.grdProductos.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                    Me.grdProductos.Rows(posicion).Cells("txbObservacion").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("txmCantidad").Value = If(codigoBarra Is Nothing, 0, cantidad)
                    Me.grdProductos.Rows(posicion).Cells("txbPrecioBase").Value = Format(precio, mdlPublicVars.formatoMoneda)
                    Me.grdProductos.Rows(posicion).Cells("Total").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("idajustecategoria").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txbAjuste").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("txmCantidadAjuste").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("elimina").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("idSurtir").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txmCantidadSurtir").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("idInventario").Value = mdlPublicVars.General_idTipoInventario
                    Me.grdProductos.Rows(posicion).Cells("tipoPrecio").Value = mdlPublicVars.Empresa_PrecioNormal
                    Me.grdProductos.Rows(posicion).Cells("clrEstado").Value = estadoPedido
                    Me.fnNuevaFila()
                End If
                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    'INFORMACION DE ARTICULO
    Private Sub fnArticulo_informacion()
        Dim idcliente As Integer = codigoCliente
        Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                If IsNothing(Me.grdProductos.Rows(index).Cells("id").Value) = True Then
                    lblObservacion.Text = ""
                    lblCompatibilidad.Text = ""
                    lblSaldo.Text = "0"
                    lblUltPrecio.Text = Format(0, mdlPublicVars.formatoMoneda)
                    lblUltTipoPrecio.Text = ""
                    Exit Sub
                End If

                Dim codigo As Integer = CInt(Me.grdProductos.Rows(index).Cells("id").Value)
                lblObservacion.Text = ""
                lblSaldo.Text = "0"
                lblUltPrecio.Text = Format(0, mdlPublicVars.formatoMoneda)
                If CInt(codigo) > 0 Then
                    codigo = CInt(codigo)
                    Dim datos As sp_CadenaCompatibilidad_Result = (From x In conexion.sp_CadenaCompatibilidad(codigo, mdlPublicVars.General_idTipoInventario) Select x).First
                    lblObservacion.Text = datos.Obs
                    lblSaldo.Text = datos.Saldo.ToString
                    lblCompatibilidad.Text = datos.Compatibilidad

                    Dim ultPrecio As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles
                                                         Where x.tblSalida.facturado = True And x.tblSalida.anulado = False And x.tblSalida.despachar = True _
                                    And x.idArticulo = codigo And x.tblSalida.idCliente = idcliente
                                    Order By x.tblSalida.fechaFacturado Descending Select x).FirstOrDefault

                    If ultPrecio IsNot Nothing Then
                        lblUltPrecio.Text = Format(ultPrecio.precio, mdlPublicVars.formatoMoneda)
                        lblUltTipoPrecio.Text = ultPrecio.tblArticuloTipoPrecio.nombre
                    End If
                End If

            Catch ex As NullReferenceException
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                lblObservacion.Text = ""
                lblCompatibilidad.Text = ""
                lblSaldo.Text = Format(0, mdlPublicVars.formatoMoneda)
            End Try

            'cerrar conexion
            conn.Close()
        End Using
    End Sub

    'REPORTE COTIZACION
    Private Sub fnReporte_Cotizacion(ByVal codigo As Integer)
        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario
        Dim success As Boolean = False
        Dim salida As tblSalida = Nothing
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
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
            frmDocumentosSalida.codigo = CInt(salida.idCliente)
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        End If

    End Sub

    'ACTUALIZAR TOTAL
    Public Sub fnActualizar_Total()
        totProrrateo = 0.0
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                Dim cantidad As Double = 0
                Dim precio As Decimal = 0
                Dim nombre As String = ""
                Dim precioOriginal As Decimal = 0
                Dim prorrateoProducto As Decimal = 0
                Dim descuentoProducto As Decimal = 0
                Dim descuentoVenta As Decimal = 0

                Dim totalVenta As Decimal = 0
                Dim subTotalVenta As Decimal = 0
                Dim totalFlete As Decimal = 0
                Dim totalProrrateoManual As Decimal = 0
                Dim totalProrrateoAutomatico As Decimal = 0
                Dim totalProrrateoManualU As Decimal = 0
                Dim totalDescuentoManual As Decimal = 0
                Dim totalCostoPrecio As Decimal = 0
                Dim precioRecargo As Decimal = 0.0

                lblRecuento.Text = CStr2((From x As GridViewRowInfo In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Count)

                ' CALCULAR TOTALES RECARGO Y DESCUENTO
                For Each fila As GridViewRowInfo In Me.grdProductos.Rows
                    nombre = CType(fila.Cells("txbProducto").Value, String)
                    If nombre IsNot Nothing Then
                        precioOriginal = CType(Replace(CStr2(fila.Cells("txbPrecioBase").Value), "Q", ""), Double)
                        cantidad = CType(fila.Cells("txmCantidad").Value, Double)

                        prorrateoProducto = CType(fila.Cells("txmRecargo").Value, Decimal)
                        descuentoProducto = CType(fila.Cells("txmDescuento").Value, Decimal)
                        precioRecargo = CType(fila.Cells("precio").Value, Double)

                        subTotalVenta += CDec(precioOriginal * cantidad)

                        If Me.grdProductos.Columns("txmRecargo").IsVisible = True Or Me.grdProductos.Columns("txmDescuento").IsVisible = True Then
                            totalProrrateoManualU += CDec(cantidad * prorrateoProducto)
                            totalDescuentoManual += CDec(cantidad * descuentoProducto)
                            If Me.grdProductos.Columns("txmRecargo").IsVisible = False Then
                                totProrrateo += Format(CDec((precioRecargo * cantidad) - (precioOriginal * cantidad)), formatoNumero)
                            Else
                                totProrrateo += Format(CDec(prorrateoProducto * cantidad), formatoNumero)
                            End If
                            fila.Cells("precio").Value = Format(precioOriginal + prorrateoProducto - descuentoProducto, mdlPublicVars.formatoMoneda)
                            fila.Cells("Total").Value = Format((precioOriginal * cantidad) + (cantidad * prorrateoProducto) - (cantidad * descuentoProducto), mdlPublicVars.formatoMoneda)
                        Else
                            fila.Cells("precio").Value = Format(precioOriginal, mdlPublicVars.formatoMoneda)
                            fila.Cells("Total").Value = Format((precioOriginal * cantidad), mdlPublicVars.formatoMoneda)
                        End If
                    End If
                Next

                lblSubtotal.Text = Format(subTotalVenta, mdlPublicVars.formatoMoneda)

                ' CALCULAR COSTEO
                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    ' Reseteamos el flete
                    lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)
                    ''lblRecargos.Text = Format(0, mdlPublicVars.formatoMoneda)

                    Me.grdProductos.Columns("txmRecargo").IsVisible = False

                    ' Recorremos el listado de costeos
                    ''For Each salidaTransporte As tblSalidasTransporte In listaTransportes
                    ''    Dim transporteCosteo As tblTransporteCosteo = (From x In conexion.tblTransporteCosteos.AsEnumerable Where x.idTransporteCosteo = salidaTransporte.idTransporteCosteo _
                    ''                                                    Select x).FirstOrDefault()

                    ''    Select Case transporteCosteo.codigo

                    ''        ''Case "1"

                    ''        ''    ''RadMessageBox.Show("Este es el Case #1", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    ''        ''    totalFlete = CDec(salidaTransporte.precio * salidaTransporte.cantidad)

                    ''        Case "2"
                    ''            ''Prorratear automaticamente en el precio
                    ''            ''Variables para calculos
                    ''            Dim porcentaje As Decimal = 0
                    ''            Dim cociente As Decimal = 0
                    ''            Dim porUnidad As Decimal = 0
                    ''            Dim totalProducto As Decimal = 0

                    ''            Dim totalVentaOriginal As Decimal = (From x As GridViewRowInfo In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing _
                    ''            Select CType(x.Cells("txbPrecioBase").Value, Decimal) * CType(x.Cells("txmCantidad").Value, Decimal)).Sum

                    ''            ' Recorremos cada una de las filas
                    ''            totalProrrateoAutomatico = 0
                    ''            For Each fila As GridViewRowInfo In Me.grdProductos.Rows
                    ''                nombre = CType(fila.Cells("txbProducto").Value, String)
                    ''                If nombre IsNot Nothing Then
                    ''                    precio = CType(Replace(fila.Cells("precio").Value.ToString, "Q", ""), Decimal)

                    ''                    precioOriginal = CType(Replace(fila.Cells("txbPrecioBase").Value.ToString, "Q", ""), Decimal)
                    ''                    cantidad = CType(fila.Cells("txmCantidad").Value, Double)

                    ''                    totalProducto = CDec(precioOriginal * cantidad)
                    ''                    porcentaje = (totalProducto * 100) / totalVentaOriginal
                    ''                    cociente = CDec((porcentaje / 100) * (salidaTransporte.cantidad * salidaTransporte.precio))
                    ''                    porUnidad = CDec(cociente / cantidad)

                    ''                    precioOriginal += porUnidad
                    ''                    precio = precioOriginal
                    ''                    fila.Cells("precio").Value = Format(precio, mdlPublicVars.formatoMoneda)
                    ''                    fila.Cells("Total").Value = Format((precio * cantidad), mdlPublicVars.formatoMoneda)

                    ''                    totalProrrateoAutomatico += CDec(porUnidad * cantidad)
                    ''                End If
                    ''            Next

                    ''            'lblTotal.Text = Format(total, mdlPublicVars.formatoMoneda)
                    ''        Case "3"
                    ''            ' Prorrateo manual en el precio
                    ''            totalProrrateoManual += CDec(salidaTransporte.precio * salidaTransporte.cantidad)
                    ''            Me.grdProductos.Columns("txmRecargo").IsVisible = True
                    ''        Case "4"
                    ''            ' Precio como flete
                    ''            totalFlete += CDec(salidaTransporte.precio * salidaTransporte.cantidad)
                    ''    End Select
                    ''Next

                    totProrrateo = (totalProrrateoAutomatico + totalProrrateoManual + totalFlete)

                    ' Prorrateo Manual
                    lblRecargos.Text = Format(totalProrrateoManual + CDec(Replace(lblRecargos.Text, "Q", "").Trim), mdlPublicVars.formatoMoneda)

                    ' Prorrateo Manual Faltante
                    lblFaltante.Text = Format((totalProrrateoManual - totalProrrateoManualU), mdlPublicVars.formatoMoneda)
                    If (totalProrrateoManual - totalProrrateoManualU) < 0 Then
                        lblRecargos.ForeColor = Color.Red
                    ElseIf (totalProrrateoManual - totalProrrateoManualU) > 0 Then
                        lblRecargos.ForeColor = Color.Blue
                    Else
                        lblRecargos.ForeColor = Color.Black
                    End If

                    ' Prorrateo Automatico
                    lblRecargos.Text = Format(totalProrrateoAutomatico + CDec(Replace(lblRecargos.Text, "Q", "").Trim), mdlPublicVars.formatoMoneda)

                    ' Flete
                    lblFlete.Text = Format(totalFlete, mdlPublicVars.formatoMoneda)
                    lblRecargos.Text = Format(totalFlete + CDec(Replace(lblRecargos.Text, "Q", "").Trim), mdlPublicVars.formatoMoneda)

                    'Calculamos el Descuento General
                    Dim descuento As Decimal

                    If superSearchValorDescuento > 0 Then

                        Dim calculardescuento As Decimal
                        If supersearchDescuentoPorcentaje Then
                            calculardescuento = superSearchValorDescuento / 100
                            descuento = (subTotalVenta * calculardescuento)
                        Else
                            calculardescuento = superSearchValorDescuento
                            descuento = calculardescuento
                        End If

                    End If

                    'Descuento  
                    lblDescuentos.Text = Format(descuento + totalDescuentoManual, mdlPublicVars.formatoMoneda)

                    ' Total
                    lblTotal.Text = Format(subTotalVenta + totalFlete + totalProrrateoManual + totalProrrateoAutomatico - totalDescuentoManual - descuento, mdlPublicVars.formatoMoneda)

                    conn.Close()
                End Using
            Else
                lblTotal.Text = Format(0, mdlPublicVars.formatoMoneda)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'IMPRIMIR DESPACHO
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

    Private Sub fnImprimirPequenio(ByVal codSalida As Integer, ByVal contado As Boolean)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim c As New clsReporte
                If mdlPublicVars.bitTransportePesado Then
                    If contado = True Then
                        c.tabla = EntitiToDataTable(conexion.sp_ReporteEnvioPequenio("", codSalida))
                    ElseIf contado = False Then
                        c.tabla = EntitiToDataTable(conexion.sp_ReporteValePequenio("", codSalida))
                    End If
                Else
                    c.tabla = EntitiToDataTable(conexion.sp_reportePickingPedido("", codSalida))
                End If

                If mdlPublicVars.bitTransportePesado Then
                    If contado = True Then
                        c.reporte = "rptEnvioPequenio.rpt"
                    ElseIf contado = False Then
                        c.reporte = "rptValePequenio.rpt"
                    End If
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

    'BLOQUEAR COMBO
    Public Sub fnBloquearCombo()
        Try
            'Obtenemos  el numero de filas
            Dim filas As Integer = CInt(Me.grdProductos.Rows.Count)
            If filas > 1 Then
                txtClave.Enabled = False
                cmbInventario.Enabled = False
            ElseIf filas = 1 Then
                'Verificamos si tiene informacion la fila
                Dim nombre As String = ""
                Try
                    nombre = Me.grdProductos.Rows(0).Cells("txbProducto").Value.ToString
                Catch ex As Exception
                    nombre = ""
                End Try

                If nombre.Trim.Length > 0 Then
                    txtClave.Enabled = False
                    cmbInventario.Enabled = False
                Else
                    txtClave.Enabled = True
                    cmbInventario.Enabled = True
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'BUSCAR CLIENTE POR CLAVE
    Private Sub txtClave_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                Try
                    frmBuscarCliente.Text = "Buscar Cliente"
                    frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoDialogEspeciales(frmBuscarCliente)
                    frmBuscarCliente.Dispose()

                    If superSearchNit.Length > 0 Then
                        Dim codigo As String = CType(superSearchNit, String)
                        Me.txtNit.Text = codigo
                        clavecli = superSearchId

                        If codigo.Trim = "C/F" Then
                            fnClave()
                        Else
                            fnNit()
                        End If

                    End If
                Catch
                End Try
            End If

            If e.KeyCode = Keys.Enter Then
                Dim clave As String = txtClave.Text.Trim

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    'Obtenemos el cliente
                    Dim cliente As tblCliente = (From x In conexion.tblClientes _
                                                 Where LTrim(RTrim(x.clave)) = LTrim(RTrim(clave)) _
                                                 Select x).FirstOrDefault

                    If cliente IsNot Nothing Then
                        codigoCliente = cliente.idCliente
                        txtNit.Text = cliente.nit1
                        txtCliente.Text = cliente.Nombre1
                        txtNombreFacturacion.Text = cliente.Negocio
                        municipio = cliente.idMunicipio

                        If cliente.bitMostrador = True Then
                            Me.txtNombreFacturacion.Enabled = True
                        Else
                            Me.txtNombreFacturacion.Enabled = False
                        End If

                        'asignar vendedor Default
                        cmbVendedor.SelectedValue = cliente.idVendedor

                        'activa si tien credito el cliente
                        lblFaltante.Text = "0.00"
                        rbnCredito.Checked = CBool(cliente.tblClienteTipoPago.credito)
                        rbnContado.Checked = Not CBool(cliente.tblClienteTipoPago.credito)

                        rbnCredito.Enabled = CBool(cliente.tblClienteTipoPago.credito)
                        rbnContado.Enabled = CBool(cliente.tblClienteTipoPago.credito)
                    Else
                        RadMessageBox.Show("Cliente no encontrado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        codigoCliente = 0
                        txtNit.Text = ""
                        txtCliente.Text = ""
                    End If

                    conn.Close()
                End Using
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'BOTON DETALLE PRODUCTOS NUEVOS
    Private Sub btnDetalleNuevos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleNuevos.Click
        If CInt(codigoCliente) > 0 Then
            frmDetallePendienteNuevo.Text = "Productos Nuevo"
            frmDetallePendienteNuevo.bitNuevo = True
            frmDetallePendienteNuevo.cliente = CInt(codigoCliente)
            frmDetallePendienteNuevo.StartPosition = FormStartPosition.CenterScreen
            frmDetallePendienteNuevo.ShowDialog()
            frmDetallePendienteNuevo.Dispose()
        End If
    End Sub

    'CERRANDO EL FORMULARIO
    Private Sub frmSalidas_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If fnCuentaArticulos() And Not bitEditarSalida Then
            If RadMessageBox.Show("¿ Desea Salir ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        ElseIf RadMessageBox.Show("¿ Desea salir ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            frmVentaPequeniaLista.frm_llenarLista()
        End If
    End Sub

    'VER TELEFONOS
    Private Sub btnTelefono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTelefono.Click
        If CInt(codigoCliente) > 0 Then
            frmDetalleTelefono.Text = "Teléfonos"
            frmDetalleTelefono.StartPosition = FormStartPosition.CenterScreen
            frmDetalleTelefono.idCliente = CInt(codigoCliente)
            frmDetalleTelefono.ShowDialog()
            frmDetalleTelefono.Dispose()
        End If
    End Sub

    'CAMBIO TIPO DE VENTA
    Private Sub rbnContado_CheckedChanged(sender As Object, e As EventArgs) Handles rbnContado.CheckedChanged
        fnActualizar_Total()
    End Sub
#End Region

#Region "Botones de Barra"
    'NUEVO PEDIDO
    Private Sub fnNuevo_Click() Handles Me.panel0
        Dim formPedido As New frmVentaPequenia
        formPedido.Text = "Ventas"
        formPedido.bitEditarBodega = False
        formPedido.bitEditarSalida = False
        formPedido.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmEspeciales(formPedido, False)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    'COTIZAR
    Private Sub fnCotizar_Click() Handles Me.panel1
        If bitEditarBodega Or bitEditarSalida Then
            alerta.fnUtiliceModificar()
            Exit Sub
        End If

        fnActualizar_Total()
        If fnErrores() = False Then
            If RadMessageBox.Show("¿Desea guardar la cotizacion?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                fnGuardarCotizacion()
            End If
        End If
    End Sub

    'RESERVAR
    Private Sub fnReservar_Click() Handles Me.panel2
        If bitEditarBodega Or bitEditarSalida Then
            alerta.fnUtiliceModificar()
            Exit Sub
        End If

        fnActualizar_Total()
        If fnErrores() = False Then
            If RadMessageBox.Show("¿Desea guardar la reserva?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                fnGuardarReserva()
            End If
        End If
    End Sub

    'DESPACHAR O MODIFICAR
    Private Sub fnPanel3() Handles Me.panel3
        If bitEditarBodega Or bitEditarSalida And Not bitSugerirDespacho Then
            fnModificar_Click()
        Else
            fnDespachar_Click()
        End If
    End Sub


    ''Calculo de PAgos y Saldos
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

    Private Sub fnGuardarPagoCaja(ByVal montopago As Double, ByVal salida As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                'VARIABLES PARA EL PROCESO
                Dim cliente As Integer = codigoCliente
                Dim pagotipo As Integer = mdlPublicVars.Pagos_codigoEfectivo
                Dim documento As String = ""
                Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)

                'TIPO DE PAGO
                Dim tipoPago As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = pagotipo Select x).FirstOrDefault

                Dim pago As New tblCaja
                pago.documento = If(documento Is Nothing, "", documento)
                pago.anulado = False
                pago.codigoSalida = salida
                pago.fecha = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
                pago.fechaTransaccion = fecha
                pago.fechaCobro = CDate(dtpFechaRegistro.Text & " " & fecha.ToLongTimeString)
                ''pago.monto = If(nm2TotalPagar.Value > 0, If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value), nm2MontoRecibido.Value)
                ''pago.monto = If(nm2Cambio.Value > 0, nm2MontoRecibido.Value - nm2Cambio.Value, nm2MontoRecibido.Value)
                pago.monto = montopago
                pago.tipoCambio = 1
                pago.tipoPago = pagotipo
                pago.empresa = mdlPublicVars.idEmpresa
                pago.usuario = mdlPublicVars.idUsuario
                pago.observacion = Observacion
                pago.descripcion = tipoPago.nombre
                pago.bitRechazado = False
                pago.consumido = pago.monto
                pago.afavor = 0
                pago.confirmado = True
                pago.transito = False
                pago.cliente = cliente
                pago.bitEntrada = True
                pago.bitSalida = False

                conexion.AddTotblCajas(pago)
                conexion.SaveChanges()

                ''fnCajaPagoSalidas(pago.codigo, salida, cliente, montopago, conexion)

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCajaPagoSalidas(ByVal idcaja As Integer, ByVal idsalida As Integer, ByVal idcliente As Integer, ByVal monto As Double, ByVal conexion As dsi_pos_demoEntities)

        Try

            Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
            Dim fechafiltro As Date = CType(fnFechaServidor(), Date)

            Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

            Dim pagosalida As New tblCajaSalida

            pagosalida.idCaja = idcaja
            pagosalida.idCliente = idcliente
            pagosalida.idSalida = idsalida
            pagosalida.fechaRegistro = fecha
            pagosalida.fechaFiltro = fechafiltro
            pagosalida.saldoSalida = salida.saldo
            pagosalida.saldoNuevo = pagosalida.saldoSalida - monto
            pagosalida.monto = monto

            conexion.AddTotblCajaSalidas(pagosalida)
            conexion.SaveChanges()

        Catch ex As Exception

        End Try

    End Sub

    'DESPACHAR
    Private Sub fnDespachar_Click()
        fnActualizar_Total()
        Dim ejecutaPago As Boolean
        Dim tipopago As Object

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
                Dim idSalida As Integer

                If tipopago <> mdlPublicVars.PuntoVentaPequeno_tipoPago Then
                    If RadMessageBox.Show("¿Desea Realizar la venta al Contado?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        idSalida = fnGuardarDespacho(True)

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
                        idSalida = fnGuardarDespacho(False)

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

                                    Dim totalventa As Double = CDec(Replace(Me.lblTotal.Text, "Q", ""))
                                    Dim saldocliente As Double = 0
                                    Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codigoCliente Select x).FirstOrDefault

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
                                        pago.cliente = codigoCliente
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
                    idSalida = fnGuardarDespacho(True)

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



    End Sub

    'MODIFICAR
    Private Sub fnModificar_Click()
        If fnErrores() Then
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
        ElseIf chkReservado.Checked Then
            If RadMessageBox.Show("Desea modificar la reserva ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                success = fnModificarReserva()
            End If
        ElseIf chkCotizado.Checked Then
            If RadMessageBox.Show("Desea modificar la cotización ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                success = fnModificarCotizacion()
            End If
        End If

        If success Then
            fnLlenarDatos()
            Me.Close()
        End If
    End Sub

    'TRANSPORTE
    Private Sub fnAgregarTransporte_Click() Handles Me.panel4
        If bitTransportePesado = True Then

            ''Dim formTransporteLista As New frmVentaPequeniaTransporteLista
            ''formTransporteLista.Text = "Agregar Transporte"
            ''formTransporteLista.WindowState = FormWindowState.Normal
            ''formTransporteLista.StartPosition = FormStartPosition.CenterScreen
            ''formTransporteLista.listaTransportes = listaTransportes
            ''formTransporteLista.ShowDialog()

            ''Me.listaTransportes = formTransporteLista.listaTransportes
            ''Me.listaTransportesEliminar = formTransporteLista.listaTransportesEliminar

            ''fnActualizar_Total()

            ''formTransporteLista.Dispose()
        ElseIf bitEncomienda = True Then

            ''frmGuiasLista.Dispose()
            ''frmGuiasLista.Text = "Guias de Facturas"
            ''frmGuiasLista.MdiParent = frmMenuPrincipal
            ''frmGuiasLista.bitFactura = True
            ''frmGuiasLista.bitCompra = False
            ''frmGuiasLista.bitDevolucionCliente = False
            ''frmGuiasLista.bitDevolucionProveedor = False
            ''frmGuiasLista.WindowState = FormWindowState.Normal
            ''frmGuiasLista.StartPosition = FormStartPosition.CenterParent
            ''frmGuiasLista.ShowDialog()
            ''permiso.PermisoFrmEspeciales(frmGuiasLista, False)
            ''If permiso.PermisoMantenimientoLista(frmGuiasLista, False) = True Then
            ''    fnFRMhijos_cerrar(frmGuiasLista)
            ''    Me.Hide()
            ''End If
            ''fnActualizar_Total()
            ''frmGuiasLista.Dispose()

            ''frmVentasGuia.Text = "Guias de Venta"
            ''frmVentasGuia.bitFactura = True
            ''frmVentasGuia.bitCompra = False
            ''frmVentasGuia.bitDevolucionCliente = False
            ''frmVentasGuia.bitDevolucionProveedor = False


            ''    frmVentasGuia.Codigo = codigo
            ''    frmVentasGuia.MdiParent = frmMenuPrincipal
            ''    permiso.PermisoMantenimientoTelerik(frmVentasGuia, True)
            ''    ''Me.Close()




            Try

                Dim conexion As New dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim nitc As String
                    nitc = txtNit.Text

                    Dim codigo = (From x In conexion.tblClientes Where x.nit1 = nitc Select x.idCliente).FirstOrDefault


                    If txtCodigo.Text = "" Then
                        frmSalidaEnvio.bitTemporal = True
                    Else
                        frmSalidaEnvio.bitTemporal = False
                    End If

                    'abrir el formulario
                    frmSalidaEnvio.tblGuias = Me.tblGuias
                    frmSalidaEnvio.Codigo = codigo
                    frmSalidaEnvio.codigoCliente = CType(codigo, Integer)
                    frmSalidaEnvio.Text = "Paqueteria"
                    frmSalidaEnvio.ShowDialog()
                    frmSalidaEnvio.Dispose()

                    conn.Close()
                End Using
            Catch ex As Exception

            End Try


        Else
            RadMessageBox.Show("No Tiene Asignado Ningun Transporte...!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    ''Descuentos
    Private Sub fnDescuento_Click() Handles Me.panel5

        Dim contado As Boolean
        Dim credito As Boolean

        contado = rbnContado.Checked
        credito = rbnCredito.Checked

        If mdlPublicVars.bitVenta_Pequenia_Descuentos Then
            frmDescuentos.bitVentaContado = contado
            frmDescuentos.bitVentaCredito = credito
            frmDescuentos.WindowState = FormWindowState.Normal
            frmDescuentos.StartPosition = FormStartPosition.CenterScreen
            frmDescuentos.ShowDialog()
            frmDescuentos.Dispose()
            ''fnAgregarDescuento(superSearchValorDescuento)
        Else
            RadMessageBox.Show("Los Descuentos estan Desactivados", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

        fnActualizar_Total()

    End Sub

    'SALIR
    Private Sub fnSalir_Click() Handles Me.panel6
        ''If RadMessageBox.Show("¿ Desea Salir ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        ''End If
    End Sub
#End Region

#Region "Procesos Principales"
    'AGREGAR BITACORA
    Private Sub AgregaBitacora(ByVal seguir As Boolean)
        If seguir = True Then
            Try
                frmBitacora.idCliente = codigoCliente
                frmBitacora.idVendedor = CInt(cmbVendedor.SelectedValue)
                frmBitacora.fecha = dtpFechaRegistro.Value
                frmBitacora.Text = "Bitacora"
                frmBitacora.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmBitacora)
                frmBitacora.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    'VERIFICAR ERRORES
    Private Function fnErrores() As Boolean
        If bitEditarBodega = False Then
            If Me.grdProductos.Rows.Count = 0 Then
                alerta.contenido = "Faltan articulos"
                alerta.fnErrorContenido()
                Return True
            End If

            Dim index As Integer = 0
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

            '******* YOEL
            'Verificar si esta todo prorrateado
            Dim prorrateoManual As Decimal
            Try
                prorrateoManual = CType(Replace(lblRecargos.Text, "Q", "").Trim, Decimal) - totProrrateo - CType(Replace(lblFlete.Text, "Q", "").Trim, Decimal)
            Catch ex As Exception
                prorrateoManual = 0
            End Try

            If prorrateoManual > 0.99 Then
                alerta.contenido = "Debe prorreatear el transporte le falta: " & Format(prorrateoManual, mdlPublicVars.formatoMoneda)
                alerta.fnErrorContenido()
                totProrrateo = 0.0
                Return True
            End If

            '******* FIN DE YOEL

        Else
            'errores de modificar.
            If IsNumeric(txtCodigo.Text) Then
                If IsNumeric(lblTotal.Text) Then
                Else
                    alerta.contenido = "Requiere Numero"
                    alerta.fnErrorContenido()
                    Return True
                End If

                Dim t As Double = CDbl(lblTotal.Text)
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
            Dim index As Integer
            Dim idajuste As Integer = 0
            Dim cantidad As Integer = 0
            Dim cantidadAjuste As Integer = 0
            Dim idarticulo As Integer = 0
            Dim articulo As String = ""

            For index = 0 To Me.grdProductos.Rows.Count - 1
                idajuste = CInt(Me.grdProductos.Rows(index).Cells("idajustecategoria").Value)
                idarticulo = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) 'id articulo
                articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value.ToString ' articulo

                If articulo.Length > 0 Then
                    ''revisar si cantidad es numerico.
                    If IsNumeric(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) Then
                        cantidad = CInt(Me.grdProductos.Rows(index).Cells("txmCantidad").Value)
                    Else
                        alerta.contenido = "Requiere numero en linea " + (index + 1).ToString + " Articulo " + articulo.ToString
                        alerta.fnErrorContenido()
                        Return True
                    End If

                    'revisar cantidad de ajuste, si es numerico.
                    If idajuste > 0 Then
                        If IsNumeric(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value) And CInt(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value) > 0 Then
                            cantidadAjuste = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value)
                        ElseIf CInt(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value) = 0 Then
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
            codArt = CStr(Me.grdProductos.Rows(i).Cells("id").Value)
            If codArt IsNot Nothing Then
                numeroProductos += 1
            End If
        Next

        If numeroProductos = 0 Then
            alerta.contenido = "Debe de ingresar al menos un producto"
            alerta.fnErrorContenido()
            Return True
        End If

        Return False
    End Function

    'GUARDAR COTIZACION
    Private Sub fnGuardarCotizacion()
        'validaciones
        If IsNumeric(txtCodigo.Text) Then
            alerta.fnUtiliceModificar()
            Exit Sub
        End If

        Dim codcliente As Integer = codigoCliente
        Dim cliente As String = txtCliente.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = CInt(cmbVendedor.SelectedValue)
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor().ToString
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim errorContenido As Boolean = False
        Dim codigoSalida As Integer = Nothing
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'consultar un cliente
            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First
            Dim usr As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault

            If success = True Then
                'crear el encabezado de la transaccion
                Using transaction As New TransactionScope
                    'inicio de excepcion
                    Try
                        Dim salida As New tblSalida
                        Dim totalContado As Decimal = 0
                        Dim totalCostoSalida As Decimal = 0
                        Try
                            totalContado = CType(Replace(lblTotal.Text, "Q", "").Trim, Decimal)
                        Catch ex As Exception
                            totalContado = 0
                        End Try


                        'Sustraemos el correlativo
                        Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = codmovimiento _
                                                             Select x).FirstOrDefault ' se agreg ordefault

                        salida.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                        salida.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                        salida.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                        salida.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                        salida.idTipoMovimiento = CShort(codmovimiento)
                        salida.idVendedor = CShort(usr.idVendedor)
                        salida.idCliente = codcliente
                        salida.cliente = txtCliente.Text
                        salida.nit = txtNit.Text
                        salida.fechaTransaccion = fecha
                        salida.fechaRegistro = CDate(dtpFechaRegistro.Text & " " & hora)
                        salida.observacion = txtObservacion.Text
                        salida.idMunicipio = mdlPublicVars.PuntoVentaPequeno_codigoMunicipio
                        salida.cotizado = True
                        salida.reservado = False
                        salida.despachar = False
                        salida.facturado = False
                        salida.empacado = False
                        salida.anulado = False
                        salida.fechaAnulado = Nothing
                        salida.descuento = 0
                        salida.subtotal = totalContado
                        salida.total = totalContado
                        salida.direccionFacturacion = cli.direccionFactura1
                        salida.direccionEnvio = cli.direccionFactura1
                        salida.contado = rbnContado.Checked
                        salida.credito = rbnCredito.Checked
                        salida.documento = (correlativo.correlativo + 1).ToString
                        salida.bitFacReimpreso = False

                        salida.pagado = 0
                        salida.saldo = salida.total
                        salida.devoluciones = 0

                        correlativo.correlativo = correlativo.correlativo + 1

                        'agregar salida al modelo
                        conexion.AddTotblSalidas(salida)
                        'guardar cambios
                        conexion.SaveChanges()
                        ' codigoSalidaAFacturar = salida.idSalida 'para la venta pequenia
                        codigoSalida = salida.idSalida

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

                        totalCostoSalida = (From x In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Select(Function(x) CType(x.Cells("txmCantidad").Value, Decimal) * CType(x.Cells("costo").Value, Decimal)).Sum
                        '************** FIN DE CALCULAR EL COSTO TOTAL DE LA VENTA

                        'paso 6, guardar el detalle
                        Dim index As Integer
                        Dim cantidad As Double = 0
                        Dim precio As Decimal = 0
                        Dim precioOriginal As Decimal = 0
                        Dim total As Decimal = 0
                        Dim id As Integer = 0
                        Dim nombre As String = ""
                        Dim cantSurtir As Integer = 0
                        Dim idSurtir As Integer = 0
                        Dim contado As Boolean = True
                        Dim idInventario As Integer = 0
                        Dim tipoPrecio As Integer = 0
                        Dim observacion As String = ""

                        ' Variables para transporte
                        Dim totalCosto As Decimal
                        Dim porcentajeCosto As Decimal
                        Dim cociente As Decimal
                        Dim porUnidad As Decimal
                        Dim bodegasalida As Integer
                        Dim valmedida As Double
                        Dim transporte As Boolean
                        Dim idmedida As Integer

                        For index = 0 To Me.grdProductos.Rows.Count - 1
                            id = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) ' id articulo
                            nombre = CStr(Me.grdProductos.Rows(index).Cells("txbProducto").Value) ' articulo

                            If nombre IsNot Nothing Then
                                cantidad = CDec(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) 'cantidad
                                precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("precio").Value.ToString, "Q", "").Trim) ' precio
                                precioOriginal = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecioBase").Value.ToString, "Q", "").Trim)
                                total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value.ToString, "Q", "").Trim) ' total
                                cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value) 'cantidadSurtir
                                idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value)
                                idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value)
                                tipoPrecio = CDec(Me.grdProductos.Rows(index).Cells("tipoPrecio").Value)
                                observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value.ToString
                                valmedida = Me.grdProductos.Rows(index).Cells("ValorUnidadMedida").Value
                                transporte = Me.grdProductos.Rows(index).Cells("chmTransporte").Value
                                idmedida = Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value
                                bodegasalida = CType(Me.grdProductos.Rows(index).Cells("idBodega").Value, Integer)

                                If precio <= 0 Then
                                    alerta.contenido = "No se puede guardar artículo: " & nombre & vbCrLf & "No tiene precio"
                                    errorContenido = True
                                    success = False
                                    Exit Try
                                End If

                                Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).First
                                Dim detalle As New tblSalidaDetalle
                                detalle.idSalida = salida.idSalida
                                detalle.anulado = False
                                detalle.idArticulo = id
                                detalle.cantidad = cantidad
                                detalle.precio = precio
                                detalle.precioOriginal = precioOriginal
                                detalle.costo = producto.costoIVA
                                detalle.tipoInventario = idInventario
                                detalle.tipoPrecio = tipoPrecio
                                detalle.comentario = observacion
                                detalle.precioFactura = precio
                                detalle.otrosCostos = 0
                                detalle.agregarTransporte = transporte
                                detalle.idunidadmedida = idmedida
                                detalle.valormedida = valmedida
                                detalle.tipobodega = bodegasalida
                                '************** COSTEO
                                If totalCosteoCosto > 0 Then
                                    'Proceso para el prorrateo por costo
                                    totalCosto = CDec(detalle.costo * detalle.cantidad)
                                    porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                    cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                    porUnidad = CDec(cociente / cantidad)

                                    detalle.otrosCostos = porUnidad
                                End If
                                '************** FIN DE COSTEO

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
                                        detalleHijo.idArticulo = CInt(detalleKit.articulo)
                                        detalleHijo.anulado = False
                                        detalleHijo.cantidad = CDec(detalleKit.cantidad * detalle.cantidad)
                                        detalleHijo.comentario = ""
                                        detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                        detalleHijo.precio = 0
                                        detalleHijo.precioOriginal = 0
                                        detalleHijo.otrosCostos = 0
                                        detalleHijo.idSalida = detalle.idSalida
                                        detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                        detalleHijo.tipoInventario = detalle.tipoInventario
                                        detalleHijo.tipoPrecio = detalle.tipoPrecio
                                        detalleHijo.idunidadmedida = detalle.idunidadmedida
                                        detalleHijo.valormedida = detalle.valormedida
                                        detalleHijo.tipobodega = detalle.tipobodega
                                        detalleHijo.agregarTransporte = detalle.agregarTransporte

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
                                        If cantidad > p.saldo Then
                                            cantidad = CDec(cantidad - p.saldo)
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
                            End If
                        Next

                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        success = False
                        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
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

            'cerrar conexion
            conn.Close()
        End Using

        If success = True Then
            conexion.AcceptAllChanges()
            alerta.fnGuardar()
            totProrrateo = 0.0
            bitEditarSalida = False
            fnNuevo()
            'Mostramos la ventana de Bitacora, Usando la Variable global de configuración para conocer si se pide bitacora o No.
            AgregaBitacora(mdlPublicVars.Salida_BitacoraAlCotizar)
            If mdlPublicVars.bitTransportePesado = True Then

                Dim salcot As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigoSalida Select x).FirstOrDefault

                fnEnviarCorreo(salcot.idCliente, codigoSalida)

            ElseIf mdlPublicVars.bitEncomienda = True Then
                If RadMessageBox.Show("¿Desea mostrar documento de salida?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    fnReporte_Cotizacion(codigoSalida)
                End If
            End If
            'Iniciamos un nueva venta 
            fnNuevo()
        Else
            If errorContenido Then
                alerta.fnErrorContenido()
            Else
                alerta.fnErrorGuardar()
            End If
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    Private Sub fnEnviarCorreo(ByVal cliente As Integer, ByVal salida As Integer)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim tablaParametros As New DataTable

        Dim reporteBase As ReportDocument

        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim archivo As String = ""
        Dim msj As String = ""

        ''Variables
        Dim x As New tblImpresion
        Dim r As New clsReporte
        Dim listacorreos As New Hashtable
        Dim tabladatos As New DataTable
        Dim dsr As New dsReporte

        r.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_ReporteCotizacionPequenio("", salida))
        r.reporte = "rptCotizacionPequenio.rpt"
        reporteBase = r.DocumentoReporte()

        Try
            ''Guardar registro en el sistema
            x.bitImpreso = True
            x.tipoImpresion = 5
            x.usuarioRegistro = mdlPublicVars.idUsuario
            x.fechaImpresion = fechaServidor
            x.cliente = cliente
            x.descripcion = "Devolucion de Productos"
            x.url = archivo

            ctx.AddTotblImpresions(x)
            ctx.SaveChanges()

            x.url = fnExportar(x.codigo, path, reporteBase, tablaParametros)

            Dim empresa As tblEmpresa = (From y In ctx.tblEmpresas Where y.idEmpresa = mdlPublicVars.idEmpresa Select y).FirstOrDefault

            Dim txtcorreos As String = empresa.Correos

            Dim correos() As String = txtcorreos.Split(",")
            Dim i
            For i = LBound(correos) To UBound(correos)
                listacorreos.Add(i + 1, correos(i))
            Next

            r.emailTitulo = "Cotizacion"
            r.emailCuerpo = "Envio de Cotizacion, Correo enviado desde Sistema Pos Dsi"
            msj += r.EnviarCorreo(listacorreos, x.url).ToString

        Catch ex As Exception

        End Try

    End Sub

    Public Function fnExportar(ByVal codigo As String, ByVal path As String, ByVal reporteExportar As ReportDocument, ByVal tblparametros As DataTable) As String
        Dim carpeta As String = "DocImpresion\" + mdlPublicVars.idEmpresa.ToString + "\"
        Dim archivo As String = ""
        path = path & carpeta

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()

            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            Dim CrFormatTypeOptionsXls As New ExcelFormatOptions

            CrDiskFileDestinationOptions.DiskFileName = path & codigo.ToString & ".pdf"
            archivo = CrDiskFileDestinationOptions.DiskFileName

            CrExportOptions = reporteExportar.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .FormatOptions = CrFormatTypeOptions

                .DestinationOptions = CrDiskFileDestinationOptions
            End With

            reporteExportar.Export()

        Catch ex As Exception
            MsgBox(ex.ToString)
            archivo = ""
        End Try

        Return archivo

    End Function

    'MODIFICAR COTIZACION
    Private Function fnModificarCotizacion() As Boolean
        Dim codcliente As Integer = codigoCliente
        Dim cliente As String = txtCliente.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Integer = CInt(cmbVendedor.SelectedValue)

        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim success As Boolean = True
        Dim errContenido As String = ""

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope
                Try
                    Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).First

                    'GUARDAR REGISTRO DE SALIDA.

                    '------------------------------------------------------  crear encabezado.-----------------------------
                    'paso 5, guardar el registro de encabezado
                    Dim totalCostoSalida As Decimal = 0
                    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault

                    salida.descuento = 0
                    salida.subtotal = CDec(lblTotal.Text)
                    salida.total = CDec(lblTotal.Text)
                    salida.contado = rbnContado.Checked
                    salida.credito = rbnCredito.Checked

                    salida.pagado = 0
                    salida.saldo = salida.total
                    salida.devoluciones = 0

                    conexion.SaveChanges()

                    '************** TRANSPORTE

                    Dim validos As String() = {"idSalidaTransporte", "idSector", "idSucursal", "idTipoTransporte", "idTransporteCosteo", "bitDescuento", "cantidad",
                                                       "contacto", "descuento", "direccion", "estado", "observacion", "precio", "telefono"}



                    Dim totalCosteoCosto As Decimal = 0
                    ''For Each salidaTransporte As tblSalidasTransporte In listaTransportes
                    ''    Dim salidaTransporteModificar As tblSalidasTransporte = (From x In conexion.tblSalidasTransportes Where x.idSalidaTransporte = salidaTransporte.idSalidaTransporte
                    ''            Select x).FirstOrDefault

                    ''    Dim propiedades() As System.Reflection.PropertyInfo = salidaTransporte.GetType().GetProperties()

                    ''    For Each pi As System.Reflection.PropertyInfo In propiedades
                    ''        If validos.Contains(pi.Name) Then
                    ''            CallByName(salidaTransporteModificar, pi.Name, CallType.Set, pi.GetValue(salidaTransporte, Nothing))
                    ''        End If
                    ''    Next

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

                    totalCostoSalida = (From x In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Select(Function(x) CType(x.Cells("txmCantidad").Value, Decimal) * CType(x.Cells("costo").Value, Decimal)).Sum
                    '************** FIN DE CALCULAR EL COSTO TOTAL DE LA VENTA

                    '--------------------------------------- fin de crear encabezado. -------------------

                    'paso 6, guardar el detalle
                    Dim index As Integer
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

                    'COSTEO
                    Dim totalCosto As Decimal = 0
                    Dim porcentajeCosto As Decimal = 0
                    Dim cociente As Decimal = 0
                    Dim porUnidad As Decimal = 0
                    Dim bodegasalida As Integer
                    Dim transporte As Integer
                    Dim valmedida As Double
                    Dim idmedida As Integer

                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        iddetalle = CInt(Me.grdProductos.Rows(index).Cells("iddetalle").Value) ' id detalle
                        idarticulo = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) ' id articulo
                        articulo = CStr(Me.grdProductos.Rows(index).Cells("txbProducto").Value) ' codigo

                        If articulo IsNot Nothing Then
                            cantidad = CInt(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) ' cantidad
                            precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("precio").Value.ToString, "Q", "").Trim) ' precio
                            total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value.ToString, "Q", "").Trim) ' total
                            elimina = CInt(Me.grdProductos.Rows(index).Cells("elimina").Value)
                            cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value)
                            idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value)
                            idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value)
                            tipoPrecio = CInt(Me.grdProductos.Rows(index).Cells("tipoPrecio").Value)
                            observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value.ToString
                            valmedida = Me.grdProductos.Rows(index).Cells("ValorUnidadMedida").Value
                            transporte = Me.grdProductos.Rows(index).Cells("chmTransporte").Value
                            idmedida = Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value
                            bodegasalida = CType(Me.grdProductos.Rows(index).Cells("idBodega").Value, Integer)

                            Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).FirstOrDefault
                            If elimina > 0 Then
                                'modificar registro de detalle.
                                Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                detalle.anulado = True
                                'Verificamos si tiene pendientes por surtir
                                Dim surtir As tblSurtir = (From x In conexion.tblSurtirs Where x.salidaDetalle = detalle.idSalidaDetalle Select x).FirstOrDefault
                                If surtir IsNot Nothing Then
                                    surtir.anulado = True
                                    conexion.SaveChanges()
                                End If
                                conexion.SaveChanges()

                            ElseIf iddetalle > 0 Then
                                'modificar registro de detalle.
                                Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                Dim cantidadAntigua As Integer = detalle.cantidad

                                detalle.cantidad = CInt(cantidad)
                                detalle.precio = precio
                                detalle.precioFactura = precio
                                detalle.agregarTransporte = transporte
                                detalle.idunidadmedida = idmedida
                                detalle.valormedida = valmedida

                                '************** COSTEO
                                If totalCosteoCosto > 0 Then
                                    'Proceso para el prorrateo por costo
                                    totalCosto = CDec(detalle.costo * detalle.cantidad)
                                    porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                    cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                    porUnidad = CDec(cociente / cantidad)

                                    detalle.otrosCostos = porUnidad
                                End If
                                '************** FIN DE COSTEO

                                conexion.SaveChanges()

                                If detalle.tblArticulo.bitKit Then
                                    'Obtenemos la lista de salidas detalle asociadas a el kit
                                    Dim lSalidaDetallKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = detalle.idSalidaDetalle _
                                                                                         Select x).ToList

                                    'Recorremos el grid para actualizarlo
                                    Dim cantidadKit As Integer = 0
                                    For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetallKit
                                        'Realizamos el calculo para la cantidad nueva
                                        cantidadKit = CInt(salidaDetalleKit.cantidad / cantidadAntigua)
                                        salidaDetalleKit.cantidad = cantidadKit * detalle.cantidad
                                        conexion.SaveChanges()
                                    Next
                                End If
                            Else
                                'crear registro de detalle
                                Dim detalle As New tblSalidaDetalle
                                detalle.idSalida = salida.idSalida
                                detalle.idArticulo = idarticulo
                                detalle.cantidad = CInt(cantidad)
                                detalle.precio = precio
                                detalle.anulado = False
                                detalle.costo = producto.costoIVA
                                detalle.tipoInventario = idInventario
                                detalle.tipoPrecio = tipoPrecio
                                detalle.comentario = observacion
                                detalle.precioFactura = precio
                                detalle.precioOriginal = precio
                                detalle.agregarTransporte = transporte
                                detalle.tipobodega = bodegasalida
                                detalle.idunidadmedida = idmedida
                                detalle.valormedida = valmedida

                                conexion.AddTotblSalidaDetalles(detalle)

                                '************** COSTEO
                                If totalCosteoCosto > 0 Then
                                    'Proceso para el prorrateo por costo
                                    totalCosto = CDec(detalle.costo * detalle.cantidad)
                                    porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                    cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                    porUnidad = CDec(cociente / cantidad)

                                    detalle.otrosCostos = porUnidad
                                End If
                                '************** FIN DE COSTEO

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
                                        detalleHijo.idArticulo = CInt(detalleKit.articulo)
                                        detalleHijo.anulado = False
                                        detalleHijo.cantidad = CInt(detalleKit.cantidad * detalle.cantidad)
                                        detalleHijo.comentario = ""
                                        detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                        detalleHijo.precio = 0
                                        detalleHijo.idSalida = detalle.idSalida
                                        detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                        detalleHijo.tipoInventario = detalle.tipoInventario
                                        detalleHijo.tipoPrecio = detalle.tipoPrecio
                                        detalleHijo.idunidadmedida = idmedida
                                        detalleHijo.valormedida = valmedida
                                        detalleHijo.tipobodega = bodegasalida
                                        detalleHijo.agregarTransporte = transporte

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
                                            cantidad = CDbl(cantidad - p.saldo)
                                            p.saldo = 0
                                        Else
                                            p.saldo = CType(p.saldo - cantidad, Integer?)
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
                                    pendiente.anulado = False
                                    pendiente.usuario = mdlPublicVars.idUsuario
                                    pendiente.vendedor = CShort(mdlPublicVars.idVendedor)
                                    pendiente.cliente = salida.idCliente
                                    conexion.AddTotblSurtirs(pendiente)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

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

            conn.Close()
        End Using


        If success = True Then
            conexion.AcceptAllChanges()
            If Not bitSugerirDespacho Then
                alerta.fnGuardar()
                Return True
            End If
            Return False
        Else
            Return False
            'alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Function

    'GUARDAR RESERVA
    Private Function fnGuardarReserva() As Boolean
        'variable que guardan los codigos.
        Dim idCliente As Integer = codigoCliente
        Dim cliente As String = txtCliente.Text
        Dim idTipoMovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim idVendedor As Integer = CInt(cmbVendedor.SelectedValue)

        'variable de sistema.
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = CStr(fnHoraServidor())
        Dim existenciaIns As Boolean = False
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'consultar un cliente
            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).First
            Dim usr As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario).FirstOrDefault

            If success = True Then
                Using transaction As New TransactionScope
                    Try

                        'GUARDAR REGISTRO DE SALIDA.
                        Dim diaSemana As Integer = Weekday(fecha, vbMonday)
                        Dim fechaActual As DateTime = fecha
                        Dim fechaReserva As DateTime = fecha
                        Dim dias As Integer = 0
                        Try
                            Dim cadDias As String = InputBox("Ingrese dias de reserva", "Informacion", CStr2(mdlPublicVars.Salida_ReservaDias))
                            dias = CInt(cadDias)
                        Catch ex As Exception
                            dias = mdlPublicVars.Salida_ReservaDias
                        End Try

                        If (diaSemana = 1) Then
                            fechaReserva = fechaActual.AddDays(dias)
                        Else
                            fechaReserva = fechaActual.AddDays(dias + 1)
                        End If

                        Dim salida As New tblSalida
                        Dim totalSalida As Decimal = 0
                        Dim totalCostoSalida As Decimal = 0

                        Try
                            totalSalida = CDec(Replace(lblTotal.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalSalida = 0
                            RadMessageBox.Show("No se puede realizar la venta con precio 0", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            success = False
                            Exit Try
                        End Try

                        'Sustraemos el correlativo
                        Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idTipoMovimiento = idTipoMovimiento _
                                                             Select x).First

                        salida.idEmpresa = CType(mdlPublicVars.idEmpresa, Integer)
                        salida.idUsuario = CType(mdlPublicVars.idUsuario, Integer)
                        salida.idTipoInventario = CType(mdlPublicVars.General_idTipoInventario, Integer)
                        salida.idAlmacen = CType(mdlPublicVars.General_idAlmacenPrincipal, Integer)
                        salida.idTipoMovimiento = CShort(idTipoMovimiento)
                        salida.idVendedor = CShort(usr.idVendedor)
                        salida.idMunicipio = mdlPublicVars.General_MunicipioLocal

                        salida.idCliente = idCliente
                        salida.cliente = cliente
                        salida.nit = txtNit.Text
                        salida.fechaVencimientoReserva = fechaReserva

                        salida.fechaTransaccion = fecha
                        salida.fechaRegistro = CDate(dtpFechaRegistro.Text & " " & hora)
                        salida.observacion = txtObservacion.Text

                        salida.cotizado = False
                        salida.reservado = True
                        salida.despachar = False
                        salida.facturado = False
                        salida.empacado = False
                        salida.anulado = False
                        salida.fechaAnulado = Nothing

                        ' salida.direccionFacturacion = cmbDireccionFacturacion.Text
                        salida.descuento = 0
                        salida.subtotal = totalSalida
                        salida.total = totalSalida
                        salida.pagado = 0
                        salida.saldo = salida.total
                        salida.devoluciones = 0
                        salida.bitFacReimpreso = False

                        salida.contado = rbnContado.Checked
                        salida.credito = rbnCredito.Checked

                        salida.documento = CStr2(correlativo.correlativo + 1)
                        correlativo.correlativo = correlativo.correlativo + 1

                        'agregar salida al modelo
                        conexion.AddTotblSalidas(salida)

                        'guardar cambios
                        conexion.SaveChanges()

                        '************** TRANSPORTE
                        Dim totalCosteoCosto As Decimal = 0
                        ''For Each salidaTransporte As tblSalidasTransporte In listaTransportes
                        ''    salidaTransporte.idSalida = salida.idSalida
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
                        totalCostoSalida = (From x In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Select(Function(x) CType(x.Cells("txmCantidad").Value, Decimal) * CType(x.Cells("costo").Value, Decimal)).Sum
                        '************** FIN DE CALCULAR EL COSTO TOTAL DE LA VENTA


                        'paso 6, guardar el detalle
                        Dim index As Integer
                        Dim cantidad As Double = 0
                        Dim precio As Decimal = 0
                        Dim precioOriginal As Decimal = 0
                        Dim total As Decimal = 0
                        Dim id As Integer = 0
                        Dim nombre As String = ""
                        Dim cantSurtir As Integer = 0
                        Dim idSurtir As Integer = 0
                        Dim idInventario As Integer = 0
                        Dim tipoPrecio As Integer = 0
                        Dim observacion As String = ""

                        Dim totalCosto As Decimal
                        Dim porcentajeCosto As Decimal
                        Dim cociente As Decimal
                        Dim porUnidad As Decimal
                        Dim bodegasalida As Integer
                        Dim valmedida As Double
                        Dim idmedida As Integer
                        Dim transporte As Boolean

                        For index = 0 To Me.grdProductos.Rows.Count - 1

                            id = CInt(Me.grdProductos.Rows(index).Cells("id").Value)
                            nombre = CStr2(Me.grdProductos.Rows(index).Cells("txbProducto").Value)

                            If Not nombre.Equals("") Then
                                cantidad = CDec(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) ' cantidad
                                precio = CDec(Replace(CStr2(Me.grdProductos.Rows(index).Cells("precio").Value), "Q", "").Trim) ' precio
                                precioOriginal = CDec(Replace(CStr2(Me.grdProductos.Rows(index).Cells("txbPrecioBase").Value), "Q", "").Trim) ' precio original
                                total = CDec(Replace(CStr2(Me.grdProductos.Rows(index).Cells("Total").Value), "Q", "").Trim) ' total
                                cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value) 'surtir
                                idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value)
                                idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value)
                                tipoPrecio = CInt(Me.grdProductos.Rows(index).Cells("tipoPrecio").Value)
                                observacion = CStr2(Me.grdProductos.Rows(index).Cells("txbObservacion").Value)
                                valmedida = Me.grdProductos.Rows(index).Cells("ValorUnidadMedida").Value
                                transporte = Me.grdProductos.Rows(index).Cells("chmTransporte").Value
                                idmedida = Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value
                                bodegasalida = CType(Me.grdProductos.Rows(index).Cells("idBodega").Value, Integer)

                                Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).First

                                Dim detalle As New tblSalidaDetalle
                                detalle.idSalida = salida.idSalida
                                detalle.anulado = False
                                detalle.idArticulo = id
                                detalle.cantidad = cantidad
                                detalle.precio = precio
                                detalle.costo = articulo.costoIVA
                                detalle.tipoInventario = idInventario
                                detalle.tipoPrecio = tipoPrecio
                                detalle.comentario = observacion
                                detalle.precioFactura = precio
                                detalle.otrosCostos = 0
                                detalle.precioOriginal = precioOriginal
                                detalle.idunidadmedida = idmedida
                                detalle.valormedida = valmedida
                                detalle.agregarTransporte = transporte
                                detalle.tipobodega = bodegasalida
                                '************** COSTEO
                                If totalCosteoCosto > 0 Then
                                    'Proceso para el prorrateo por costo
                                    totalCosto = CDec(detalle.costo * detalle.cantidad)
                                    porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                    cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                    porUnidad = CDec(cociente / cantidad)

                                    detalle.otrosCostos = porUnidad
                                End If
                                '************** FIN DE COSTEO

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
                                        detalleHijo.idArticulo = CInt(detalleKit.articulo)
                                        detalleHijo.anulado = False
                                        detalleHijo.cantidad = CDec(detalleKit.cantidad * detalle.cantidad)
                                        detalleHijo.comentario = ""
                                        detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                        detalleHijo.precio = 0
                                        detalleHijo.otrosCostos = 0
                                        detalleHijo.precioOriginal = 0

                                        detalleHijo.idSalida = detalle.idSalida
                                        detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                        detalleHijo.tipoInventario = detalle.tipoInventario
                                        detalleHijo.tipoPrecio = detalle.tipoPrecio
                                        detalleHijo.agregarTransporte = detalle.agregarTransporte
                                        detalleHijo.valormedida = detalle.valormedida
                                        detalleHijo.idunidadmedida = detalle.idunidadmedida
                                        detalleHijo.tipobodega = detalle.tipobodega

                                        'Agregamos el detalle a la BD
                                        conexion.AddTotblSalidaDetalles(detalleHijo)
                                        conexion.SaveChanges()
                                    Next
                                End If

                                'Verifiamos si es surtir
                                If idSurtir > 0 Then

                                    'Modificamos el pendiente por surtir
                                    Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where (x.cliente = salida.idCliente) And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

                                    Dim p As tblSurtir

                                    For Each p In pendiente
                                        If cantidad > p.saldo Then
                                            cantidad -= CInt(p.saldo)
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
                                    pendiente.salidaDetalle = detalle.idSalidaDetalle
                                    pendiente.articulo = detalle.idArticulo
                                    pendiente.cantidad = cantSurtir
                                    pendiente.saldo = cantSurtir
                                    pendiente.fechaTransaccion = fecha
                                    pendiente.anulado = False
                                    pendiente.usuario = mdlPublicVars.idUsuario
                                    pendiente.vendedor = mdlPublicVars.idVendedor

                                    pendiente.cliente = salida.idCliente
                                    conexion.AddTotblSurtirs(pendiente)
                                    conexion.SaveChanges()
                                End If

                                'guardar los cambios.
                                conexion.SaveChanges()

                                If articulo.bitKit Then
                                    'Obtenemos la lista de los productos asociados a ese kit
                                    Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = articulo.idArticulo _
                                                                                   Select x).ToList

                                    For Each detallekit As tblArticulo_Kit In lDetalleKit
                                        'descontar existencias.
                                        Dim codArtKit As Integer = CInt(detallekit.articulo)
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
                                        RadMessageBox.Show("Existencia insuficiente de " & articulo.nombre1 & " (" & articulo.codigo1 & ")  por :" & (cantidad - inve.saldo), mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                        existenciaIns = True
                                        success = False
                                        Exit Try
                                    End If
                                End If
                            End If
                        Next


                        If totalSalida > 0 Then
                            Dim totalSalidaFinal As Decimal = (From x In conexion.tblSalidaDetalles Where x.tblSalida.idSalida = salida.idSalida And x.anulado = False Select x.cantidad * x.precio).Sum
                            Dim sContado As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salida.idSalida Select x).FirstOrDefault
                            sContado.total = totalSalidaFinal
                            sContado.subtotal = totalSalidaFinal
                            conexion.SaveChanges()
                        End If


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
                totProrrateo = 0.0
                bitEditarSalida = False
                'Mostramos la ventana de Bitacora, Usando la Variable global de configuración para conocer si se pide bitacora o No.
                AgregaBitacora(mdlPublicVars.Salida_BitaraAlReservar)

                fnNuevo()
            End If
        End Using

    End Function

    Private Function fnModificarReserva() As Boolean
        Dim idCliente As Integer = CInt(codigoCliente)
        Dim cliente As String = txtCliente.Text
        Dim idTipoMovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim idVendedor As Integer = CInt(cmbVendedor.SelectedValue)

        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim success As Boolean = True
        Dim errContenido As String = ""

        'conexion nueva.
        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'consultar un cliente
            Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).First

            If success = True Then
                Using transaction As New TransactionScope

                    Try
                        'GUARDAR REGISTRO DE SALIDA.

                        '------------------------------------------------------  crear encabezado.-----------------------------
                        'paso 5, guardar el registro de encabezado
                        Dim totalCostoSalida As Decimal = 0
                        Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).First

                        salida.observacion = txtObservacion.Text

                        salida.descuento = 0
                        salida.subtotal = CDec(Replace(lblTotal.Text, "Q", "").Trim)
                        salida.total = CDec(Replace(lblTotal.Text, "Q", "").Trim)

                        salida.contado = rbnContado.Checked
                        salida.credito = rbnCredito.Checked

                        salida.pagado = 0
                        salida.saldo = salida.total
                        salida.devoluciones = 0

                        conexion.SaveChanges()

                        '************** TRANSPORTE
                        Dim totalCosteoCosto As Decimal = 0
                        Dim validos As String() = {"idSalidaTransporte", "idSector", "idSucursal", "idTipoTransporte", "idTransporteCosteo", "bitDescuento", "cantidad",
                                                       "contacto", "descuento", "direccion", "estado", "observacion", "precio", "telefono"}

                        ''For Each salidaTransporte As tblSalidasTransporte In listaTransportes
                        ''    Dim salidaTransporteModificar As tblSalidasTransporte = (From x In conexion.tblSalidasTransportes Where x.idSalidaTransporte = salidaTransporte.idSalidaTransporte
                        ''            Select x).FirstOrDefault

                        ''    Dim propiedades() As System.Reflection.PropertyInfo = salidaTransporte.GetType().GetProperties()

                        ''    For Each pi As System.Reflection.PropertyInfo In propiedades
                        ''        If validos.Contains(pi.Name) Then
                        ''            CallByName(salidaTransporteModificar, pi.Name, CallType.Set, pi.GetValue(salidaTransporte, Nothing))
                        ''        End If
                        ''    Next

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

                        totalCostoSalida = (From x In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Select(Function(x) CType(x.Cells("txmCantidad").Value, Decimal) * CType(x.Cells("costo").Value, Decimal)).Sum
                        '************** FIN DE CALCULAR EL COSTO TOTAL DE LA VENTA

                        '--------------------------------------- fin de crear encabezado. -------------------

                        'paso 6, guardar el detalle
                        Dim index As Integer
                        Dim cantidad As Integer = 0
                        Dim precio As Decimal = 0
                        Dim precioOriginal As Decimal = 0
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

                        Dim totalCosto As Decimal
                        Dim porcentajeCosto As Decimal
                        Dim cociente As Decimal
                        Dim porUnidad As Decimal
                        Dim transporte As Boolean
                        Dim valmedida As Double
                        Dim idmedida As Integer
                        Dim bodegasalida As Integer

                        For index = 0 To Me.grdProductos.Rows.Count - 1

                            iddetalle = CInt(Me.grdProductos.Rows(index).Cells("iddetalle").Value) ' id detalle
                            idarticulo = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) ' id articulo
                            articulo = CStr2(Me.grdProductos.Rows(index).Cells("txbProducto").Value) ' codigo

                            If Not articulo.Equals("") Then
                                cantidad = CInt(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) ' cantidad
                                precio = CDec(Replace(CStr2(Me.grdProductos.Rows(index).Cells("precio").Value), "Q", "").Trim) ' precio
                                precioOriginal = CDec(Replace(CStr2(Me.grdProductos.Rows(index).Cells("txbPrecioBase").Value), "Q", "").Trim) ' precio
                                total = CDec(Replace(CStr2(Me.grdProductos.Rows(index).Cells("Total").Value), "Q", "").Trim) ' total
                                elimina = CInt(Me.grdProductos.Rows(index).Cells("elimina").Value)
                                idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value)
                                cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value)
                                idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value)
                                tipoPrecio = CInt(Me.grdProductos.Rows(index).Cells("tipoPrecio").Value)
                                valmedida = Me.grdProductos.Rows(index).Cells("ValorUnidadMedida").Value
                                transporte = Me.grdProductos.Rows(index).Cells("chmTransporte").Value
                                idmedida = Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value
                                bodegasalida = CType(Me.grdProductos.Rows(index).Cells("idBodega").Value, Integer)

                                Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).FirstOrDefault

                                If elimina > 0 Then
                                    Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                    detalle.anulado = True

                                    'Verificamos si tiene pendientes por surtir
                                    Dim surtir As tblSurtir = (From x In conexion.tblSurtirs Where x.salidaDetalle = detalle.idSalidaDetalle Select x).FirstOrDefault
                                    If surtir IsNot Nothing Then
                                        surtir.anulado = True
                                        conexion.SaveChanges()
                                    End If
                                    cantidadAnterior = detalle.cantidad
                                    conexion.SaveChanges()

                                ElseIf iddetalle > 0 Then
                                    'modificar registro de detalle.
                                    Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                                    cantidadAnterior = detalle.cantidad
                                    detalle.cantidad = CInt(cantidad)
                                    detalle.precio = precio
                                    detalle.precioFactura = precio
                                    detalle.idunidadmedida = idmedida
                                    detalle.valormedida = valmedida
                                    detalle.agregarTransporte = transporte
                                    detalle.tipobodega = bodegasalida

                                    '************** COSTEO
                                    If totalCosteoCosto > 0 Then
                                        'Proceso para el prorrateo por costo
                                        totalCosto = CDec(detalle.costo * detalle.cantidad)
                                        porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                        cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                        porUnidad = CDec(cociente / cantidad)

                                        detalle.otrosCostos = porUnidad
                                    End If
                                    '************** FIN DE COSTEO

                                    conexion.SaveChanges()


                                    If detalle.tblArticulo.bitKit Then
                                        'Obtenemos la lista de salidas detalle asociadas a el kit
                                        Dim lSalidaDetallKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = detalle.idSalidaDetalle _
                                                                                             Select x).ToList

                                        'Recorremos el grid para actualizarlo
                                        Dim cantidadKit As Integer = 0
                                        For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetallKit
                                            'Realizamos el calculo para la cantidad nueva
                                            cantidadKit = CInt(salidaDetalleKit.cantidad / cantidadAnterior)
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
                                    detalle.anulado = False
                                    detalle.tipoPrecio = tipoPrecio
                                    detalle.comentario = observacion

                                    detalle.precioFactura = precio
                                    detalle.idunidadmedida = idmedida
                                    detalle.valormedida = valmedida
                                    detalle.agregarTransporte = transporte
                                    detalle.tipobodega = bodegasalida

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
                                            detalleHijo.idArticulo = CInt(detalleKit.articulo)
                                            detalleHijo.anulado = False
                                            detalleHijo.cantidad = CInt(detalleKit.cantidad * detalle.cantidad)
                                            detalleHijo.comentario = ""
                                            detalleHijo.costo = detalleKit.tblArticulo1.costoIVA
                                            detalleHijo.precio = 0
                                            detalleHijo.idSalida = detalle.idSalida
                                            detalleHijo.kitSalidaDetalle = detalle.idSalidaDetalle
                                            detalleHijo.tipoInventario = detalle.tipoInventario
                                            detalleHijo.tipoPrecio = detalle.tipoPrecio
                                            detalleHijo.idunidadmedida = idmedida
                                            detalleHijo.valormedida = valmedida
                                            detalleHijo.agregarTransporte = transporte
                                            detalleHijo.tipobodega = bodegasalida

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
                                                cantSurtir = CInt(cantSurtir - p.saldo)
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
                                        pendiente.anulado = False
                                        pendiente.usuario = mdlPublicVars.idUsuario
                                        pendiente.vendedor = mdlPublicVars.idVendedor
                                        pendiente.cliente = salida.idCliente

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
                                            Dim inventario As Integer = CInt(salidaDetalleKit.tipoInventario)

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
                                            Dim inventario As Integer = CInt(salidaDetalleKit.tipoInventario)
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
                                            Dim inventario As Integer = CInt(salidaDetalleKit.tipoInventario)

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
                        Dim totalVenta As Decimal = (From x In conexion.tblSalidas Join y In conexion.tblSalidaDetalles On x.idSalida Equals y.idSalida
                                                  Where x.idSalida = codigo And y.anulado = False Select y.cantidad * y.precio).Sum()

                        salida.total = totalVenta
                        salida.subtotal = totalVenta

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

    'GUARDAR DESPACHO
    Private Function fnGuardarDespacho(ByVal ventacontado As Boolean) As Integer
        Dim codcliente As Integer = codigoCliente
        Dim cliente As String = txtCliente.Text
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
                            totalSalida = CDec(Replace(lblTotal.Text, "Q", "").Trim)
                        Catch ex As Exception
                            totalSalida = 0
                        End Try

                        Dim salida As New tblSalida
                        Dim totalCostoSalida As Decimal = 0
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
                            salida.cliente = txtNombreFacturacion.Text
                        Else
                            salida.cliente = txtCliente.Text
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

                        totalCostoSalida = (From x In Me.grdProductos.Rows Where x.Cells("txbProducto").Value IsNot Nothing Select x).Select(Function(x) CType(x.Cells("txmCantidad").Value, Decimal) * CType(x.Cells("costo").Value, Decimal)).Sum
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
                        Dim bodegasalida As Integer = 0


                        For index = 0 To Me.grdProductos.Rows.Count - 1
                            idarticulo = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) ' id articulo
                            nombre = CStr(Me.grdProductos.Rows(index).Cells("txbProducto").Value) ' codigo

                            Dim articulof As Integer = CType(Me.grdProductos.Rows(index).Cells("id").Value, Integer)
                            Dim cantidadf As Double = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Integer)
                            Dim tipomovimiento As Integer = 0
                            idunidamedi = Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value


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
                                precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("precio").Value.ToString, "Q", "").Trim) ' precio
                                precioOriginal = CDec(Replace(Me.grdProductos.Rows(index).Cells("txbPrecioBase").Value.ToString, "Q", "").Trim) ' precio original
                                total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value.ToString, "Q", "").Trim) ' total
                                cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value) 'surtir
                                idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value)
                                idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value)
                                tipoPrecio = CInt(Me.grdProductos.Rows(index).Cells("tipoPrecio").Value)
                                observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value.ToString
                                valmedida = Me.grdProductos.Rows(index).Cells("ValorUnidadMedida").Value
                                transporte = Me.grdProductos.Rows(index).Cells("chmTransporte").Value
                                idmedida = Me.grdProductos.Rows(index).Cells("IdUnidadMedida").Value
                                bodegasalida = CType(Me.grdProductos.Rows(index).Cells("idBodega").Value, Integer)

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
                                detalle.tipobodega = bodegasalida
                                '************** COSTEO
                                If totalCosteoCosto > 0 Then
                                    'Proceso para el prorrateo por costo
                                    totalCosto = CDec(detalle.costo * detalle.cantidad)
                                    porcentajeCosto = CDec((totalCosto * 100) / totalCostoSalida)
                                    cociente = CDec((porcentajeCosto / 100) * (totalCosteoCosto))
                                    porUnidad = CDec(cociente / cantidad)

                                    detalle.otrosCostos = porUnidad
                                End If
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
                                                                     And x.idTipoInventario = idInventario And x.IdAlmacen = bodegasalida _
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
                                                                 And x.idTipoInventario = idInventario And x.IdAlmacen = bodegasalida _
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
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()
            totProrrateo = 0.0
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

    'MODIFICAR DESPACHO
    Private Function fnModificarDespacho() As Boolean
        If fnErrores() = True Then
            Exit Function
        End If

        Dim codcliente As Integer = codigoCliente
        Dim cliente As String = txtCliente.Text
        Dim codmovimiento As Integer = mdlPublicVars.Salida_TipoMovimientoVenta
        Dim codvendedor As Short = CShort(cmbVendedor.SelectedValue)
        Dim hora As String = fnHoraServidor().ToString
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim idCorrelativo As Integer = 0

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            If success = True Then
                Using transaction As New TransactionScope
                    Try
                        'GUARDAR REGISTRO DE SALIDA.
                        '------------------------------------------------------  crear encabezado.-----------------------------
                        'paso 5, guardar el registro de encabezado
                        Dim totalCosteoCosto As Decimal = 0
                        Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).First
                        salida.descuento = 0
                        salida.subtotal = CDec(lblTotal.Text)
                        salida.total = CDec(lblTotal.Text)
                        conexion.SaveChanges()

                        Dim validos As String() = {"idSalidaTransporte", "idSector", "idSucursal", "idTipoTransporte", "idTransporteCosteo", "bitDescuento", "cantidad",
                                                       "contacto", "descuento", "direccion", "estado", "observacion", "precio", "telefono"}

                        ''For Each salidaTransporte As tblSalidasTransporte In listaTransportes
                        ''    Dim salidaTransporteModificar As tblSalidasTransporte = (From x In conexion.tblSalidasTransportes Where x.idSalidaTransporte = salidaTransporte.idSalidaTransporte
                        ''            Select x).FirstOrDefault

                        ''    Dim propiedades() As System.Reflection.PropertyInfo = salidaTransporte.GetType().GetProperties()

                        ''    For Each pi As System.Reflection.PropertyInfo In propiedades
                        ''        If validos.Contains(pi.Name) Then
                        ''            CallByName(salidaTransporteModificar, pi.Name, CallType.Set, pi.GetValue(salidaTransporte, Nothing))
                        ''        End If
                        ''    Next

                        ''    ' Prorrateo al costo'
                        ''    Dim transporteCosteo As tblTransporteCosteo = (From x In conexion.tblTransporteCosteos
                        ''                                                   Where x.idTransporteCosteo = salidaTransporte.idTransporteCosteo
                        ''                                                   Select x).FirstOrDefault

                        ''    If transporteCosteo.codigo = "1" Then
                        ''        totalCosteoCosto += CDec(salidaTransporte.precio * salidaTransporte.cantidad)
                        ''    End If

                        ''    conexion.SaveChanges()
                        ''Next

                        '--------------------------------------- fin de crear encabezado. ------------------
                        'paso 6, guardar el detalle
                        Dim index As Integer = 0
                        Dim cantidad As Double = 0
                        Dim idajustecate As Short = 0
                        Dim cantidadAjuste As Decimal = 0
                        Dim precio As Decimal = 0
                        Dim total As Decimal = 0
                        Dim idarticulo As Integer = 0
                        Dim idInventario As Integer = 0
                        Dim idSurtir As Integer = 0
                        Dim cantSurtir As Integer = 0
                        Dim observacion As String = ""
                        Dim articulo As String = ""
                        Dim iddetalle As Integer = 0

                        ''crear registro de salida bodega.
                        Dim codigobodega As Integer = 0

                        'Verificamos si existe algun ajuste
                        ' Dim totalAjuste As Decimal '= lblSaldoAjuste.Text

                        Dim codigoMovPrincipal As Integer = 0
                        'Dim codigoMovLiquidacion As Integer = 0

                        '      If totalAjuste <> 0 Then
                        'Si existe algun cambio entre el pago inicial y el pago ajuste es porque existe un ajuste

                        'Obtenemos el correlativo del ajuste
                        Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = Ajuste_CodigoMovimiento _
                                                             Select x).FirstOrDefault

                        If correlativo IsNot Nothing Then
                            correlativo.correlativo += 1
                            conexion.SaveChanges()
                            idCorrelativo = correlativo.correlativo
                        Else
                            'Si no existe el correlativo lo creamos
                            Dim correlativoNuevo As New tblCorrelativo
                            correlativoNuevo.correlativo = 1
                            correlativoNuevo.serie = ""
                            correlativoNuevo.inicio = 1
                            correlativoNuevo.fin = 1000
                            correlativoNuevo.porcentajeAviso = 20
                            correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                            correlativoNuevo.idTipoMovimiento = mdlPublicVars.Ajuste_CodigoMovimiento
                            conexion.AddTotblCorrelativos(correlativoNuevo)
                            conexion.SaveChanges()

                            'asignar el numero de correlativo.
                            idCorrelativo = 1
                        End If
                        'Procedemos a crear el ajuste
                        '--------ENCABEZADO MOVIMIENTO INVENTARIO PRINCIPAL -------------
                        Dim movimiento As New tblMovimientoInventario
                        movimiento.correlativo = idCorrelativo
                        movimiento.empresa = mdlPublicVars.idEmpresa
                        movimiento.usuario = mdlPublicVars.idUsuario
                        movimiento.almacen = mdlPublicVars.General_idAlmacenPrincipal
                        movimiento.documento = ""
                        movimiento.bitBodega = True
                        movimiento.bitVenta = False
                        movimiento.tipoMovimiento = Ajuste_CodigoMovimiento
                        movimiento.inventarioInicial = mdlPublicVars.General_idTipoInventario
                        movimiento.inventarioFinal = mdlPublicVars.General_idTipoInventario
                        movimiento.ajuste = True
                        movimiento.traslado = False
                        movimiento.anulado = False
                        movimiento.revisado = False
                        movimiento.fechaRegistro = CType(dtpFechaRegistro.Text & " " & hora, DateTime)
                        movimiento.fechaTransaccion = fecha
                        movimiento.observacion = "Cod: " & salida.idSalida & ",Doc: " & salida.documento & ",Cliente: " & salida.tblCliente.Negocio
                        movimiento.revisado = True
                        movimiento.bitVenta = True
                        movimiento.bitBodega = False
                        movimiento.codigoSalida = salida.idSalida
                        conexion.AddTotblMovimientoInventarios(movimiento)
                        conexion.SaveChanges()

                        codigoMovPrincipal = movimiento.codigo

                        For index = 0 To Me.grdProductos.Rows.Count - 1

                            'consultar datos base del registro de producto.
                            iddetalle = CInt(Me.grdProductos.Rows(index).Cells("iddetalle").Value) ' id detalle
                            idarticulo = CInt(Me.grdProductos.Rows(index).Cells("Id").Value) ' id articulo
                            articulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value.ToString ' codigo
                            cantidad = CDbl(Me.grdProductos.Rows(index).Cells("txmCantidad").Value) ' cantidad
                            precio = CDec(Replace(Me.grdProductos.Rows(index).Cells("precio").Value.ToString, "Q", "").Trim) ' precio
                            total = CDec(Replace(Me.grdProductos.Rows(index).Cells("Total").Value.ToString, "Q", "").Trim) ' total
                            idInventario = CInt(Me.grdProductos.Rows(index).Cells("idInventario").Value) ' total
                            idSurtir = CInt(Me.grdProductos.Rows(index).Cells("idSurtir").Value) ' idsurtir
                            cantSurtir = CInt(Me.grdProductos.Rows(index).Cells("txmCantidadSurtir").Value) ' cant surtir
                            observacion = Me.grdProductos.Rows(index).Cells("txbObservacion").Value.ToString   'observacion
                            'consultar registro de inventario.
                            Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                             And x.idTipoInventario = idInventario And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                                                             And x.idArticulo = idarticulo Select x).FirstOrDefault

                            'modificar registro de detalle.
                            Dim detalle As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = iddetalle Select x).First
                            detalle.comentario = observacion
                            If IsNumeric(Me.grdProductos.Rows(index).Cells("idajustecategoria").Value) Then ' cantidadAjuste

                                'Obtenemos la informacion del articulo
                                Dim producto As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = idarticulo _
                                                               Select x).FirstOrDefault

                                idajustecate = CShort(Me.grdProductos.Rows(index).Cells("idajustecategoria").Value)

                                'si el codigo de ajuste categoria es mayor a cero, existe
                                If idajustecate > 0 Then
                                    cantidadAjuste = CDec(Me.grdProductos.Rows(index).Cells("txmCantidadAjuste").Value)
                                    'Verificamos si es entrada o salida
                                    Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes.AsEnumerable Where x.idTipoMovimiento = idajustecate Select x).FirstOrDefault
                                    'Verificamos si es traslado o ajuste
                                    If tipoMov.traslado Then
                                        'Creamos un nuevo traslado

                                        'Procedemos a crear el ajuste
                                        '--------ENCABEZADO MOVIMIENTO INVENTARIO PRINCIPAL -------------
                                        Dim traslado As New tblMovimientoInventario
                                        traslado.correlativo = idCorrelativo
                                        traslado.empresa = mdlPublicVars.idEmpresa
                                        traslado.usuario = mdlPublicVars.idUsuario
                                        traslado.almacen = mdlPublicVars.General_idAlmacenPrincipal
                                        traslado.documento = ""
                                        traslado.bitBodega = True
                                        traslado.bitVenta = False
                                        traslado.tipoMovimiento = Ajuste_CodigoMovimiento
                                        traslado.inventarioInicial = mdlPublicVars.General_idTipoInventario
                                        traslado.inventarioFinal = tipoMov.idTipoInventario
                                        traslado.ajuste = False
                                        traslado.traslado = True
                                        traslado.anulado = False
                                        traslado.revisado = False
                                        traslado.fechaRegistro = CDate(dtpFechaRegistro.Text & " " & hora)
                                        traslado.fechaTransaccion = fecha
                                        traslado.observacion = "Cod: " & salida.idSalida & ",Doc: " & salida.documento & ",Cliente: " & salida.tblCliente.Negocio
                                        traslado.revisado = True
                                        traslado.bitVenta = True
                                        traslado.bitBodega = False
                                        traslado.codigoSalida = salida.idSalida

                                        conexion.AddTotblMovimientoInventarios(traslado)
                                        conexion.SaveChanges()

                                        'Creamos el nuevo detalle del movimiento
                                        Dim detalleAj As New tblMovimientoInventarioDetalle
                                        detalleAj.movimientoInventario = traslado.codigo
                                        detalleAj.articulo = detalle.idArticulo
                                        detalleAj.cantidad = cantidadAjuste
                                        detalleAj.tipoMovimiento = tipoMov.idTipoMovimiento
                                        detalleAj.costo = producto.costoIVA
                                        detalleAj.total = producto.costoIVA * cantidadAjuste
                                        detalleAj.salidaDetalle = detalle.idSalidaDetalle

                                        detalleAj.entrada = tipoMov.aumentaInventario
                                        detalleAj.salida = tipoMov.disminuyeInventario

                                        conexion.AddTotblMovimientoInventarioDetalles(detalleAj)
                                        conexion.SaveChanges()

                                        'Devolvemos es cantidad al inventario del movimiento
                                        If tipoMov.idTipoInventario IsNot Nothing Then
                                            'Verificamos si aumenta o disminuye
                                            If tipoMov.nombre.Contains("-") Then
                                                traslado.inventarioInicial = mdlPublicVars.General_idTipoInventario
                                                traslado.inventarioFinal = tipoMov.idTipoInventario
                                                conexion.SaveChanges()
                                                'Obtenemos el inventario de se artciulo
                                                Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                                                   Where x.idArticulo = detalle.idArticulo And x.idTipoInventario = tipoMov.idTipoInventario
                                                                                   Select x).FirstOrDefault

                                                'decremental el total de la salida o venta.
                                                'salida.total = salida.total - detalleAj.total

                                                If inventario IsNot Nothing Then
                                                    'Aumentamos el saldo del inventario y disminuimos la salida
                                                    inventario.saldo -= CInt(cantidadAjuste)
                                                    inventario.salida -= CInt(cantidadAjuste)

                                                    'Guardamos los cambios
                                                    conexion.SaveChanges()
                                                Else
                                                    'Cremos el registro en inventario
                                                    Dim inveNuevo As New tblInventario

                                                    inveNuevo.idArticulo = detalle.idArticulo
                                                    inveNuevo.entrada = 0
                                                    inveNuevo.salida = 0
                                                    inveNuevo.transito = 0
                                                    inveNuevo.reserva = 0
                                                    inveNuevo.saldo = -CInt(cantidadAjuste)
                                                    inveNuevo.idTipoInventario = tipoMov.idTipoInventario
                                                    inveNuevo.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                                                    'Agregamos el inventario
                                                    conexion.AddTotblInventarios(inveNuevo)
                                                    conexion.SaveChanges()

                                                End If
                                                detalle.cantidad = detalle.cantidad - CInt(cantidadAjuste)

                                            ElseIf tipoMov.nombre.Contains("+") Then

                                                traslado.inventarioFinal = mdlPublicVars.General_idTipoInventario
                                                traslado.inventarioInicial = tipoMov.idTipoInventario

                                                'Obtenemos el inventario de se artciulo
                                                Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                                                   Where x.idArticulo = detalle.idArticulo And x.idTipoInventario = tipoMov.idTipoInventario
                                                                                   Select x).FirstOrDefault


                                                'incremental el total de la salida o venta.
                                                'salida.total = salida.total + detalleAj.total

                                                If inventario IsNot Nothing Then
                                                    'Aumentamos el saldo del inventario y disminuimos la salida
                                                    inventario.saldo += CInt(cantidadAjuste)
                                                    inventario.entrada += CInt(cantidadAjuste)

                                                    'Guardamos los cambios
                                                    conexion.SaveChanges()
                                                Else
                                                    'Cremos el registro en inventario
                                                    Dim inveNuevo As New tblInventario
                                                    inveNuevo.idArticulo = detalle.idArticulo
                                                    inveNuevo.entrada = 0
                                                    inveNuevo.salida = 0
                                                    inveNuevo.transito = 0
                                                    inveNuevo.reserva = 0
                                                    inveNuevo.saldo = CInt(cantidadAjuste)
                                                    inveNuevo.idTipoInventario = tipoMov.idTipoInventario
                                                    inveNuevo.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                                                    'Agregamos el inventario
                                                    conexion.AddTotblInventarios(inveNuevo)
                                                    conexion.SaveChanges()
                                                End If
                                                detalle.cantidad = detalle.cantidad + CInt(cantidadAjuste)
                                            End If
                                        End If
                                    ElseIf tipoMov.ajuste Then
                                        'Creamos el nuevo detalle del movimiento
                                        Dim detalleAj As New tblMovimientoInventarioDetalle
                                        detalleAj.movimientoInventario = codigoMovPrincipal
                                        detalleAj.articulo = idarticulo
                                        detalleAj.tipoMovimiento = CType(idajustecate, Short?)
                                        detalleAj.costo = precio
                                        detalleAj.total = (precio * cantidadAjuste)
                                        detalleAj.salidaDetalle = detalle.idSalidaDetalle
                                        detalleAj.cantidad = cantidadAjuste
                                        If tipoMov.aumentaInventario Then
                                            detalleAj.entrada = True
                                            detalleAj.salida = False
                                        ElseIf tipoMov.disminuyeInventario Then
                                            detalleAj.salida = True
                                            detalleAj.entrada = False
                                        End If

                                        conexion.AddTotblMovimientoInventarioDetalles(detalleAj)
                                        conexion.SaveChanges()

                                        'si ajuste categoria es una entrada, quiere decir que es un agregado o suma a la cantidad existente, por lo tanto descontar de inventario.
                                        If tipoMov.disminuyeInventario = True Then
                                            'restar de inventario y guardar registro de ajuste.
                                            'inve.saldo = inve.saldo - cantidadAjuste
                                            detalle.cantidad = detalle.cantidad - CInt(cantidadAjuste)

                                            'Obtenemos el inventario de se artciulo
                                            Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                                               Where x.idArticulo = detalle.idArticulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario
                                                                               Select x).FirstOrDefault

                                            'Aumentamos el saldo del inventario y disminuimos la salida
                                            inventario.saldo += CInt(cantidadAjuste)
                                            inventario.salida -= CInt(cantidadAjuste)

                                            conexion.SaveChanges()
                                        Else
                                            'si ajuste movimiento no es entrada, es una salida se debe agregar la cantidad de ajuste al inventario.
                                            'inve.saldo = inve.saldo + cantidadAjuste
                                            detalle.cantidad = CInt(detalle.cantidad + cantidadAjuste)
                                            conexion.SaveChanges()
                                        End If

                                        If producto.bitKit Then
                                            'Obtenemos la lista del detalle del kit en la tblSalidaDetalle
                                            Dim lSalidaDetalleKit As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.kitSalidaDetalle = iddetalle _
                                                                                                  Select x).ToList

                                            'Recorremos el kit detalle y generamos los ajustes
                                            Dim cantidadAnterior As Integer = 0
                                            For Each salidaDetalleKit As tblSalidaDetalle In lSalidaDetalleKit
                                                cantidadAnterior = CInt(salidaDetalleKit.cantidad / salidaDetalleKit.tblSalidaDetalle2.cantidad)

                                                'Creamos el nuevo detalle del movimiento
                                                Dim detalleAju As New tblMovimientoInventarioDetalle

                                                detalleAju.movimientoInventario = codigoMovPrincipal
                                                detalleAju.articulo = salidaDetalleKit.idArticulo
                                                detalleAju.cantidad = cantidadAjuste * salidaDetalleKit.cantidad
                                                detalleAju.tipoMovimiento = idajustecate
                                                detalleAju.costo = 0
                                                detalleAju.total = 0
                                                detalleAju.salidaDetalle = detalle.idSalidaDetalle

                                                If tipoMov.aumentaInventario = True Then
                                                    detalleAju.entrada = True
                                                    detalleAju.salida = False
                                                ElseIf tipoMov.disminuyeInventario = True Then
                                                    detalleAju.salida = True
                                                    detalleAju.entrada = False
                                                End If

                                                conexion.AddTotblMovimientoInventarioDetalles(detalleAju)
                                                conexion.SaveChanges()

                                                'si ajuste categoria es una entrada, quiere decir que es un agregado o suma a la cantidad existente, por lo tanto descontar de inventario.
                                                If tipoMov.disminuyeInventario = True Then
                                                    If (inve.saldo - (cantidadAjuste * cantidadAnterior)) >= 0 Then
                                                        'restar de inventario y guardar registro de ajuste.
                                                        'inve.saldo = inve.saldo - cantidadAjuste
                                                        salidaDetalleKit.cantidad = CInt(salidaDetalleKit.cantidad - (cantidadAjuste * cantidadAnterior))
                                                        conexion.SaveChanges()
                                                    Else
                                                        'cantidad insuficiente, error !!!
                                                        'no hay existencia.
                                                        alerta.contenido = "Error !!!, Existencia insuficiente de articulo: " + articulo.ToString
                                                        alerta.fnErrorContenido()
                                                        success = False
                                                        Exit Try
                                                    End If
                                                Else
                                                    'si ajuste movimiento no es entrada, es una salida se debe agregar la cantidad de ajuste al inventario.
                                                    'inve.saldo = inve.saldo + cantidadAjuste
                                                    salidaDetalleKit.cantidad = CInt(salidaDetalleKit.cantidad + (cantidadAjuste * cantidadAnterior))
                                                    If detalle.cantidad < 0 Then
                                                        alerta.contenido = "Error !!!, Cantidad no puede ser menor a cero en articulo : " + articulo.ToString
                                                        alerta.fnErrorContenido()
                                                        success = False
                                                        Exit Try
                                                    End If
                                                End If
                                            Next
                                        End If
                                        conexion.SaveChanges()
                                    End If

                                    conexion.SaveChanges()
                                End If
                            End If

                            'Verifiamos si es surtir
                            If idSurtir > 0 Then
                                'Modificamos el pendiente por surtir
                                Dim pendiente As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where x.cliente = salida.idCliente And x.saldo > 0 And x.articulo = detalle.idArticulo Select x Order By x.fechaTransaccion Descending).ToList

                                Dim p As tblSurtir
                                For Each p In pendiente
                                    If cantSurtir > p.saldo Then
                                        cantSurtir -= CInt(p.saldo)
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
                                pendiente.anulado = False
                                pendiente.usuario = mdlPublicVars.idUsuario
                                pendiente.vendedor = mdlPublicVars.idVendedor
                                pendiente.cliente = salida.idCliente

                                conexion.AddTotblSurtirs(pendiente)
                                conexion.SaveChanges()
                            End If
                        Next
                        conexion.SaveChanges()
                        'paso 8, completar la transaccion.
                        transaction.Complete()

                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        success = False
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
                Return True
            Else
                alerta.fnErrorGuardar()
                Return False
            End If

            'cerrar la conexion
            conn.Close()
        End Using
    End Function

    'VERIFICAR CREDITO
    Private Function fnVerificaCredito() As Boolean

        Dim codcliente As Integer = codigoCliente
        If codcliente > 0 Then
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim retorno As Boolean = False
                Dim cli As tblCliente = (From i In conexion.tblClientes.AsEnumerable Where i.idCliente = codcliente Select i).First()
                'Obtenemos el monto del credito
                Dim credito As Decimal
                Try
                    credito = CDec(lblTotal.Text)
                Catch ex As Exception
                    credito = 0
                End Try

                'Obtenemos la sumatoria de las venta al cliente, que no esten facturas, ni anuladas, y que esten es estado despachada y al credito
                Dim salidas As Decimal
                Try
                    salidas = CDec((From x In conexion.tblSalidas.AsEnumerable Where x.idCliente = cli.idCliente And Not x.anulado _
                               And Not x.empacado And x.despachar And x.credito _
                               Select x.total).Sum)
                Catch ex As Exception
                    salidas = 0
                End Try

                'Obtenemos el credito disponible, sobregiro, y sobre pago programado
                Dim creditoDisponible As Decimal = CDec(cli.limiteCredito - (cli.saldo) - salidas)
                Dim sobreGiro As Decimal = CDec((cli.porcentajeCredito / 100) * cli.limiteCredito)

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

                lblFaltante.Text = Format((creditoDisponible + sobreGiro) - credito, mdlPublicVars.formatoMoneda)

                conn.Close()
            End Using
        Else
            lblCredito.Visible = False
            lblFondoCredito.BackColor = Color.Transparent
        End If
        'End If
        Return True
    End Function

    'IMPORTAR
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            If CInt(codigoCliente) > 0 Then
                frmImportar.Text = "Importar"
                frmImportar.cliente = CInt(codigoCliente)
                frmImportar.bitSalida = True
                frmImportar.ShowDialog()

                Dim tblR As DataTable = frmImportar.tblRetorno
                frmImportar.Dispose()
                If tblR.Rows.Count > 0 Then

                    'buscar fila con id en blanco.
                    Dim filaBlanco As Integer = -1

                    Dim index As Integer
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        If Me.grdProductos.Rows(index).Cells(1).Value Is Nothing Then
                            Me.grdProductos.Rows.RemoveAt(index)
                        ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)).Length = 0 Then
                            filaBlanco = index
                        ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)).Length = 1 And CDbl(LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString))) = 0 Then
                            filaBlanco = index
                        End If
                    Next

                    Dim inicio As Integer = 0

                    If filaBlanco <> -1 Then
                        'agregar al grid si nueva fila.
                        Me.grdProductos.Rows(filaBlanco).Cells("id").Value = tblR.Rows(0).Item("Id")
                        Me.grdProductos.Rows(filaBlanco).Cells("txmCodigo").Value = tblR.Rows(0).Item("Codigo")
                        Me.grdProductos.Rows(filaBlanco).Cells("txbProducto").Value = tblR.Rows(0).Item("Nombre")
                        Me.grdProductos.Rows(filaBlanco).Cells("txmCantidad").Value = tblR.Rows(0).Item("Cantidad")
                        Me.grdProductos.Rows(filaBlanco).Cells("txbPrecioBase").Value = tblR.Rows(0).Item("Costo")
                        Me.grdProductos.Rows(filaBlanco).Cells("precio").Value = tblR.Rows(0).Item("Costo")
                        inicio = 1
                    End If

                    'agregar los elementos restantes al grid.
                    For index = inicio To tblR.Rows.Count - 1
                        Me.grdProductos.Rows.Add(0, tblR.Rows(index).Item("id"), tblR.Rows(index).Item("Codigo"), tblR.Rows(index).Item("Nombre"),
                                                 tblR.Rows(index).Item("Cantidad"), tblR.Rows(index).Item("Costo"), tblR.Rows(index).Item("Costo"), 0, False, "", 0, "", "", 0, 0, 0,
                                                 mdlPublicVars.General_idTipoInventario, mdlPublicVars.Empresa_PrecioNormal)
                    Next
                    fnActualizar_Total()
                    Me.grdProductos.Rows.AddNew()
                End If
            Else
                RadMessageBox.Show("Debe seleccionar un cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                'cmbCliente.Focus()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'COTIZAR A DESPACHAR
    Public Function CambiacotizarAdespacho(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)

        'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
        Dim ArtEmpresa As tblInventario

        'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
        Dim NombreArt As String
        Dim CodArticulo As Integer
        Dim Pedido As Integer
        Dim saldo As Integer
        Dim tInventario As Integer

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim Detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles.AsEnumerable
                                                     Join y In conexion.tblArticuloes On x.idArticulo Equals y.idArticulo
                                                     Where x.idSalida = codigo And Not x.anulado
                                                     Select x).ToList

            'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
            For Each fila As tblSalidaDetalle In Detalles
                NombreArt = fila.tblArticulo.nombre1
                CodArticulo = fila.idArticulo
                Pedido = fila.cantidad
                tInventario = CInt(fila.tipoInventario)

                'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                ArtEmpresa = (From AE In conexion.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                              And AE.idArticulo = CodArticulo And AE.idTipoInventario = tInventario Select AE).First

                If ArtEmpresa.saldo < Pedido Then
                    saldo = CInt(Pedido - ArtEmpresa.saldo)
                    'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                    errContenido = errContenido & "El articulo: " & NombreArt & ", Codigo: " & fila.tblArticulo.codigo1 & vbCrLf & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo & vbCrLf
                    success = False
                End If
            Next

            'Si existe un error mandamos el mensaje e interrumpimos la aplicación
            If success = False Then
                alerta.contenido = errContenido
                alerta.fnFaltantes()
            End If

            Using transaction As New TransactionScope
                Try
                    'VERIFICAR CREDITO.
                    If success = False Then
                        Exit Try
                    End If

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
                        Dim fechaVencimiento As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                        Dim dia As Integer = Weekday(fechaVencimiento, vbMonday)
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
                        idInventario = CInt(fila.tipoInventario)
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
                                    inve.salida = inve.salida + (fila.cantidad * detallekit.cantidad)
                                    conexion.SaveChanges()
                                Else
                                    alerta.contenido = "Error !!!, Existencia insuficiente en Kit, articulo: " + detallekit.tblArticulo.nombre1
                                    alerta.fnErrorContenido()
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
                                alerta.contenido = "Error !!!, Existencia insuficiente " & fila.tblArticulo.nombre1
                                alerta.fnErrorContenido()
                                success = False
                                Exit Try
                            End If
                        End If

                        'Verificamos si tiene pendientes por pedir
                        Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                                             Where Not x.anulado And x.saldo > 0 And x.articulo = CodArticulo
                                                                             Select x).ToList
                        Dim cantidadDescontar As Integer = fila.cantidad
                        'Recorremos la lista de pendientes
                        For Each pendiente As tblSurtir In lPendientes

                            If cantidadDescontar > pendiente.saldo Then
                                cantidadDescontar = CInt(cantidadDescontar - pendiente.saldo)
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

            conn.Close()
        End Using

        Return success
    End Function

#End Region

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Try
            frmBuscarCliente.Text = "Buscar Cliente"
            frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmBuscarCliente)
            frmBuscarCliente.Dispose()

            If superSearchNit.Length > 0 Then
                Dim codigo As String = CType(superSearchNit, String)
                Me.txtNit.Text = codigo
                clavecli = superSearchId

                If codigo.ToLower = "c/f" Then
                    fnClave()
                Else
                    fnNit()
                End If

            End If
        Catch
        End Try
        Me.grdProductos.Focus()
        Me.grdProductos.Columns("txbProducto").IsCurrent = True
    End Sub

    Private Sub fnNit()
        Try
            txtClave.Text = ""
            txtCliente.Text = ""
            codigoCliente = 0
            'conexion nueva.

            Dim nitcli As String = Me.txtNit.Text

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                '1ro. buscar el cliente.
                Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.nit1.Equals(nitcli) Select x).FirstOrDefault

                '2do. si no existe crearlo.
                If cliente Is Nothing Then
                    If RadMessageBox.Show("El Cliente no Existe. ¿Desea Crearlo?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        frmClientePequenio.Text = "Clientes"
                        frmClientePequenio.txtNit.Text = txtNit.Text
                        frmClientePequenio.ShowDialog()
                        frmClientePequenio.Dispose()

                        If mdlPublicVars.superSearchId = 0 Then
                            'si el retorno no es correcto salir de la funcion.
                            Exit Sub
                        Else
                            txtClave.Text = mdlPublicVars.superSearchClave
                            txtCliente.Text = mdlPublicVars.superSearchNombre
                            codigoCliente = mdlPublicVars.superSearchId
                            lblFaltante.Text = "0.00"
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    'codigo de cliente existe.
                    codigoCliente = cliente.idCliente
                End If

                If codigoCliente > 0 Then
                    Me.grdProductos.Columns("txmCodigo").ReadOnly = False
                Else
                    Me.grdProductos.Columns("txmCodigo").ReadOnly = True
                End If

                If codigoCliente <> Nothing Then
                    'consulta el cliente
                    Dim cliente2 As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codigoCliente Select x).FirstOrDefault

                    'informacion del cliente
                    txtClave.Text = cliente2.clave
                    txtNit.Text = cliente2.nit1
                    txtCliente.Text = cliente2.Nombre1
                    txtNombreFacturacion.Text = cliente2.Negocio

                    If cliente2.bitMostrador = True Then
                        Me.txtNombreFacturacion.Enabled = True
                    Else
                        Me.txtNombreFacturacion.Enabled = False
                    End If

                    If cliente2.idMunicipio Is Nothing Then
                        municipio = mdlPublicVars.General_MunicipioLocal
                    Else
                        municipio = cliente2.idMunicipio
                    End If

                    'informacion de credito.
                    lblFaltante.Text = "0.00"
                    rbnCredito.Checked = CBool(cliente2.tblClienteTipoPago.credito)
                    rbnContado.Checked = Not CBool(cliente2.tblClienteTipoPago.credito)
                End If
                conn.Close()
            End Using
        Catch ex As Exception
            txtClave.Text = ""
            txtNit.Text = ""
            txtCliente.Text = ""
            rbnCredito.Checked = False
            rbnContado.Checked = False
        End Try
    End Sub

    Private Sub fnClave()
        Try

            Dim claves As String

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                claves = (From x In conexion.tblClientes Where x.idCliente = clavecli Select x.clave).FirstOrDefault


                'Obtenemos el cliente
                Dim cliente As tblCliente = (From x In conexion.tblClientes _
                                             Where x.clave = claves _
                                             Select x).FirstOrDefault

                If cliente IsNot Nothing Then
                    codigoCliente = cliente.idCliente
                    txtNit.Text = cliente.nit1
                    txtClave.Text = claves
                    txtCliente.Text = cliente.Nombre1
                    txtNombreFacturacion.Text = cliente.Negocio

                    If cliente.bitMostrador = True Then
                        Me.txtNombreFacturacion.Enabled = True
                    Else
                        Me.txtNombreFacturacion.Enabled = False
                    End If

                    If cliente.idMunicipio Is Nothing Then
                        municipio = mdlPublicVars.General_MunicipioLocal
                    Else
                        municipio = cliente.idMunicipio
                    End If

                    'asignar vendedor Default
                    cmbVendedor.SelectedValue = cliente.idVendedor

                    'activa si tien credito el cliente
                    lblFaltante.Text = "0.00"
                    rbnCredito.Checked = CBool(cliente.tblClienteTipoPago.credito)
                    rbnContado.Checked = Not CBool(cliente.tblClienteTipoPago.credito)

                    rbnCredito.Enabled = CBool(cliente.tblClienteTipoPago.credito)
                    rbnContado.Enabled = CBool(cliente.tblClienteTipoPago.credito)
                Else
                    RadMessageBox.Show("Cliente no encontrado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    codigoCliente = 0
                    txtNit.Text = ""
                    txtCliente.Text = ""
                End If

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    ''Public Sub fnAgregarDescuento(ByVal valor As Decimal)

    ''    Dim fila As Integer = 0
    ''    fila = Me.grdProductos.RowCount - 1

    ''    If fila >= 0 Then

    ''        ''For Index As Integer = 0 To Me.grdProductos.RowCount - 1

    ''        ''    If Me.grdProductos.Rows(Index).Cells("txbProducto").Value <> "" Then
    ''        ''        Me.grdProductos.Rows(Index).Cells("txmDescuento").Value = valor
    ''        ''    End If
    ''        ''Next

    ''    End If

    ''End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDescuentosDetalle.Click

        RadMessageBox.Show("No puede visualizar el Detalle ", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRecargosDetalle.Click
        RadMessageBox.Show("No puede visualizar el Detalle ", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    End Sub

    Private Sub fnSumarios()

        ''Dim summaryItem As New GridViewSummaryItem()
        ''summaryItem.Name = "Freight"
        ''summaryItem.AggregateExpression = "(Sum(Freight) - Max(Freight) - Min(Freight)) / Count(Freight)"

        ''Dim summaryRowItem As New GridViewSummaryRowItem()
        ''summaryRowItem.Add(summaryItem)
        ''Me.RadGridView1.SummaryRowsTop.Add(summaryRowItem)


        ''If Me.grdProductos.Columns("txmRecargo").IsVisible = True Then
        ' ''Agregamos antes las filas de sumas

        Dim summaryItem As New GridViewSummaryItem()
        summaryItem.Name = "txmCantidad"
        summaryItem.Name = "txmRecargo"
        summaryItem.AggregateExpression = "Sum(txmCantidad * txmRecargo)"

        Dim summaryrowitem As New GridViewSummaryRowItem()
        summaryrowitem.Add(summaryItem)
        Me.grdProductos.SummaryRowsTop.Add(summaryrowitem)

        ''Dim summaryRecargo As New GridViewSummaryItem("txmRecargo", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        ' ''agregar la fila de operaciones aritmeticas

        ''Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryRecargo})

        ''grdProductos.SummaryRowsTop.Add(summaryRowItem)
        ''End If
    End Sub

    Private Sub txtNombreFacturacion_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNombreFacturacion.KeyDown
        If e.KeyCode = Keys.F4 Then
            Try
                frmBuscarCliente.Text = "Buscar Cliente"
                frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmBuscarCliente)
                frmBuscarCliente.Dispose()

                If superSearchNit.Length > 0 Then
                    Dim codigo As String = CType(superSearchNit, String)
                    Me.txtNit.Text = codigo
                    clavecli = superSearchId

                    If codigo.Trim = "C/F" Then
                        fnClave()
                    Else
                        fnNit()
                    End If

                End If
            Catch
            End Try
        End If

        If e.KeyCode = Keys.Enter Then
            Dim cliente As String
            cliente = Me.txtNombreFacturacion.Text

            Try
                frmBuscarCliente.Text = "Buscar Cliente"
                frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
                frmBuscarCliente.nombrecliente = cliente
                permiso.PermisoDialogEspeciales(frmBuscarCliente)
                frmBuscarCliente.Dispose()

                If superSearchNit.Length > 0 Then
                    Dim codigo As String = CType(superSearchNit, String)
                    Me.txtNit.Text = codigo
                    clavecli = superSearchId

                    If codigo.Trim = "C/F" Then
                        fnClave()
                    Else
                        fnNit()
                    End If

                End If
            Catch
            End Try

        End If
    End Sub


    Private Sub txtObservacion_KeyDown(ender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.grdProductos.Focus()
        End If
    End Sub

    Private Sub grdProductos_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdProductos.MouseClick
        Try
            Dim fila As Integer = Me.grdProductos.CurrentRow.Index
            Dim col As Integer = Me.grdProductos.CurrentColumn.Index
            If fila >= 0 Then
                If grdProductos.Columns(col).Name = "chmTransporte" Then
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

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            'hacer que codigo cliente sea cero
            codigoCliente = 0
            'Verifica si presiono la tecla ENTER
            If e.KeyCode = Keys.Enter Then
                Try
                    nombrecliente = txtCliente.Text
                    frmBuscarCliente.txtFiltro.Text = nombrecliente
                    frmBuscarCliente.fnBuscarCliente()
                    frmBuscarCliente.Text = "Buscar Cliente"
                    frmBuscarCliente.grdCliente.Focus()
                    frmBuscarCliente.grdCliente.Columns(0).IsCurrent = True
                    frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoDialogEspeciales(frmBuscarCliente)
                    frmBuscarCliente.Dispose()

                    If superSearchNit.Length > 0 Then
                        Dim codigo As String = CType(superSearchNit, String)
                        Me.txtNit.Text = codigo
                        clavecli = superSearchId

                        If codigo.Trim = "C/F" Then
                            fnClave()
                        Else
                            fnNit()
                        End If

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                If e.KeyCode = Keys.Enter Then
                    Me.grdProductos.Focus()
                    Me.grdProductos.Columns("txbProducto").IsCurrent = True
                End If

            End If
        End If

    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then

            frmBuscarCliente.grdCliente.Focus()
            frmBuscarCliente.grdCliente.Columns(1).IsCurrent = True

        End If
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

End Class