Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.OleDb
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmEntrada
    Private _bitEditarEntrada As Boolean = False
    Private _bitPreformaToEntrada As Boolean = False
    Private _codigo As Integer
    Public _compra As Boolean
    Public _entrada As frmEntrada
    Private permiso As New clsPermisoUsuario


    Public Property bitPreformaToEntrada As Boolean
        Get
            bitPreformaToEntrada = _bitPreformaToEntrada
        End Get
        Set(ByVal value As Boolean)
            _bitPreformaToEntrada = value
        End Set
    End Property

    Property bitEditarEntrada() As Boolean
        Get
            bitEditarEntrada = _bitEditarEntrada
        End Get
        Set(ByVal value As Boolean)
            _bitEditarEntrada = value
        End Set
    End Property

    Public Property compra As Boolean
        Get
            compra = _compra
        End Get
        Set(value As Boolean)
            _compra = value
        End Set
    End Property

    Public Property Entrada As frmEntrada
        Get
            Entrada = _Entrada
        End Get
        Set(value As frmEntrada)
            _Entrada = value
        End Set
    End Property

    Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmEntrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        compra = True
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
        mdlPublicVars.superSearchNombre = ""
        fnNuevo()

        fnActualizar_Total()

        Me.grdProductos.AllowDeleteRow = True

        If bitEditarEntrada = True Then
            pnx2Guardar.Visible = False
            pnx1Preforma.Visible = False
            fnLlenarDatos()
        End If

        If bitPreformaToEntrada Then
            pnx0Nuevo.Visible = False
            pnx3Modificar.Visible = False
            pnx2Guardar.Visible = True
            Me.grdProductos.Columns(3).Width = 300
            Me.grdProductos.Columns(4).Width = 75
            Me.grdProductos.Columns(5).Width = 75
            Me.grdProductos.Columns(6).Width = 100
            Me.grdProductos.Columns(8).Width = 110
            Me.grdProductos.Columns(9).Width = 80
            Me.grdProductos.Columns(10).Width = 80
            'mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txmCantidad")
            'mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txmCosto")
            'mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "Total")
        End If

        dtpFechaRegistro.Focus()
        dtpFechaRegistro.Select()
        mdlPublicVars.fnGrid_iconos(grdProductos)

        mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "txmCostoCompra")
        mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "TotalCompra")

        If mdlPublicVars.Entrada_Flete = True Then
            Me.lblFlete.Visible = True
            Me.txtFlete.Visible = True

            Me.grdProductos.Columns("prorrateo").IsVisible = False
            Me.grdProductos.Columns("costoTotal").IsVisible = False
        Else
            Me.lblFlete.Visible = False
            Me.txtFlete.Visible = False

            'Me.grdProductos.Columns("prorrateo").IsVisible = False
            'Me.grdProductos.Columns("costoTotal").IsVisible = False
        End If

        If mdlPublicVars.bitUnidadMedida_Activado = True Then
            Me.grdProductos.Columns("txbUnidadMedida").IsVisible = True
        Else
            Me.grdProductos.Columns("txbUnidadMedida").IsVisible = False
        End If

    End Sub

    'Funcion utilizada para llenar los datos de una entrada que se va a modificar
    Private Sub fnLlenarDatos()
        Try
            'no permite eliminar productos del grid.
            Me.grdProductos.AllowDeleteRow = False

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                'Obtenemos la entrada
                Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                dtpFechaRegistro.Value = entrada.fechaRegistro
                txtDocumento.Text = entrada.documento
                txtSerie.Text = entrada.serieDocumento
                txtCorrelativo.Text = entrada.correlativo
                cmbProveedores.Text = entrada.tblProveedor.negocio
                txtObservacion.Text = entrada.observacion
                chkComprado.Checked = entrada.compra
                chkPreforma.Checked = entrada.preforma
                chkTransito.Checked = entrada.transito
                txtFlete.Text = entrada.flete
                'Bloqueamos los controles
                dtpFechaRegistro.Enabled = False
                txtCorrelativo.Enabled = False

                'Obtenomos el detalle
                Dim lDetalles As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = codigo Select x).ToList
                Dim detalle As tblEntradasDetalle

                Dim entradam As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                'Limpiar las filas del grid View.
                Me.grdProductos.Rows.Clear()
                For Each detalle In lDetalles
                    'Creamos la fila

                    Dim unidadm As tblUnidadMedida = (From x In conexion.tblUnidadMedidas Where x.idunidadMedida = detalle.idunidadmedida Select x).FirstOrDefault

                    Dim fila As Object()
                    fila = {detalle.idEntradaDetalle, detalle.idArticulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, _
                         detalle.cantidad, detalle.idunidadmedida, unidadm.nombre, detalle.valormedida, detalle.costoIVA, "0", detalle.costoprorrateo, "0", "0", "0", detalle.cantidad, detalle.costoIVA, "0"}

                    'idDetalle,id,txmCodigo,txbProducto,txmCantidad,txmCosto,Total,elimina,txmCantidadCompra,txmCostoCompra,TotalCompra

                    'La añadimos al grid
                    grdProductos.Rows.Add(fila)
                Next

                'cerrar la conexion.
                conn.Close()

                'finalizar el proceso.
            End Using


            If bitPreformaToEntrada Then
                Me.grdProductos.Columns("txmCantidad").ReadOnly = True
                Me.grdProductos.Columns("txmCosto").ReadOnly = True
                Me.grdProductos.Columns("txmCodigo").ReadOnly = True
                Me.grdProductos.Columns("txmCantidadCompra").IsVisible = True
                Me.grdProductos.Columns("txmCostoCompra").IsVisible = True
                Me.grdProductos.Columns("TotalCompra").IsVisible = True
                Me.grdProductos.AllowDeleteRow = False

                Me.grdProductos.Columns("txmCantidad").Name = "Cantidad"
                Me.grdProductos.Columns("txmCosto").Name = "Costo"
                Me.grdProductos.Columns("txmCodigo").Name = "Codigo"
            End If

            ''fnTotalProrrateo()
            ''fnActualizar_Total()
            ''fnTotalProrrateo()
            fnActualizar_Total()
            fnNuevaFila()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnNuevo()
        Try
            llenarCombos()
            fnEstablecerCorrelativo()
            Me.grdProductos.AllowDeleteRow = True
            dtpFechaRegistro.Enabled = True
            cmbProveedores.Enabled = True
            cmbMovimiento.Enabled = False
            txtDocumento.Text = ""
            txtDocumento.Enabled = True
            lblSaldoAjuste.Text = "0"
            lblSubtotal.Text = "0"
            lblTotal.Text = "0"
            lblSaldoPreforma.Text = "0"
            txtObservacion.Text = ""
            txtSerie.Text = ""
            dtpFechaRegistro.Text = Format(Now, mdlPublicVars.formatoFecha).ToString
            Me.txtFlete.Text = "0"

            Me.grdProductos.Rows.Clear()

            'If bitEditarEntrada = False Then
            fnNuevaFila()
            'End If

            If verRegistro = True Then
                txtDocumento.Enabled = False
                cmbProveedores.Enabled = False
                pnx0Nuevo.Visible = False
                pnx2Guardar.Visible = False
                pnx3Modificar.Visible = False
                btnImportar.Enabled = False
            End If

            Me.grdProductos.Columns(4).ReadOnly = False
            Me.grdProductos.Columns(5).ReadOnly = False
            Me.grdProductos.Columns("txmCantidadCompra").IsVisible = False
            Me.grdProductos.Columns("txmCostoCompra").IsVisible = False
            Me.grdProductos.Columns("TotalCompra").IsVisible = False

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema)
        End Try

    End Sub

    Private Sub llenarCombos()
        Dim movimiento = (From x In ctx.tblTipoMovimientoes Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento _
                          And x.entrada = True Select Codigo = x.idTipoMovimiento, Nombre = x.nombre)
        'llenar el combo.
        With Me.cmbMovimiento
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = movimiento
        End With

        'consultar proveedores
        'Creamos la tabla
        Dim prov As New DataTable
        prov.Columns.Add("Codigo")
        prov.Columns.Add("Nombre")

        prov.Rows.Add("0", "")

        Dim proveedores = (From x In ctx.tblProveedors Where x.habilitado = True Select Codigo = x.idProveedor, Nombre = x.negocio)
        Dim c

        For Each c In proveedores
            prov.Rows.Add(c.Codigo, c.Nombre)
        Next

        'llenar combo de proveedores
        With Me.cmbProveedores
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = prov
        End With
    End Sub

    Private Sub fnEstablecerCorrelativo()
        'Buscamos el correlativo en la tabla correlativo...
        Dim Correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos _
                              Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento And x.idEmpresa = mdlPublicVars.idEmpresa _
                              Select x).First
        Me.txtCorrelativo.Text = CStr(Correlativo.correlativo + 1)
    End Sub

    Private Sub grdProductos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos.KeyPress
        Dim c As Integer = Me.grdProductos.CurrentColumn.Index
        Dim f As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdProductos)

        If c = 4 And e.KeyChar = ChrW(Keys.Enter) Then
            grdProductos.Columns(5).IsCurrent = True
            grdProductos.Rows(f).IsCurrent = True

        ElseIf c = 5 And e.KeyChar = ChrW(Keys.Enter) Then

            fnAgregarFilaBlanco()
            Me.grdProductos.Columns("txmCodigo").IsCurrent = True
        End If

        '' fnTotalProrrateo()
        fnActualizar_Total()
        ''fnTotalProrrateo()
    End Sub

    Public Sub fnActualizar_Total()
        lblRecuento.Text = Me.grdProductos.Rows.Count

        Try
            If Me.grdProductos.Rows.Count > 0 Then
                Dim cantidad As Double = 0
                Dim precio As Double = 0
                Dim totalCompra As Double = 0
                Dim totalPreforma As Double = 0
                Dim costoCompra As Double = 0
                Dim cantidadCompra As Double = 0

                ''Prorrateo
                Dim cantidadp As Double = 0
                Dim preciop As Double = 0
                Dim totalComprap As Double = 0
                Dim totalPreformap As Double = 0
                Dim costoComprap As Double = 0
                Dim cantidadComprap As Double = 0
                Dim eliminar As Integer

                For index As Integer = 0 To Me.grdProductos.Rows.Count - 1
                    Dim producto As String = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)
                    eliminar = CInt(Me.grdProductos.Rows(index).Cells("elimina").Value)
                    If Me.grdProductos.Rows(index).Cells("elimina").Value = "0" Then

                        If producto IsNot Nothing Then

                            If Not bitPreformaToEntrada Then
                                cantidad = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Double)
                                precio = CType(Me.grdProductos.Rows(index).Cells("txmCosto").Value, Double)

                                ''Prorrateo
                                cantidadp = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Double)
                                preciop = CType(Me.grdProductos.Rows(index).Cells("costoTotal").Value, Double)
                            Else
                                cantidad = CType(Me.grdProductos.Rows(index).Cells("Cantidad").Value, Double)
                                precio = CType(Me.grdProductos.Rows(index).Cells("Costo").Value, Double)

                                ''Prorrateo
                                cantidadp = CType(Me.grdProductos.Rows(index).Cells("Cantidad").Value, Double)
                                preciop = CType(Me.grdProductos.Rows(index).Cells("costoTotal").Value, Double)
                            End If

                            If (cantidad * precio) = 0 Then
                                Me.grdProductos.Rows(index).Cells("Total").Value = "0"
                            Else
                                If mdlPublicVars.Entrada_Flete = True Then
                                    Me.grdProductos.Rows(index).Cells("Total").Value = Format(cantidadp * preciop, "###,###.##").ToString
                                Else
                                    Me.grdProductos.Rows(index).Cells("Total").Value = Format(cantidad * precio, "###,###.##").ToString
                                End If

                            End If

                            totalPreforma += (cantidad * precio)
                            ''Prorrateo
                            totalPreformap += (cantidadp * preciop)

                            If bitPreformaToEntrada Then
                                costoCompra = CType(Me.grdProductos.Rows(index).Cells("costo").Value, Decimal)
                                cantidadCompra = CType(Me.grdProductos.Rows(index).Cells("Cantidad").Value, Double)

                                If (cantidadCompra * costoCompra) = 0 Then
                                    Me.grdProductos.Rows(index).Cells("TotalCompra").Value = "0"
                                Else
                                    Me.grdProductos.Rows(index).Cells("TotalCompra").Value = Format(cantidadCompra * costoCompra, "###,###.##").ToString
                                End If

                                totalCompra += (costoCompra * cantidadCompra)
                            End If
                        End If
                    End If


                Next

                lblSaldoPreforma.Text = Format(totalPreforma, mdlPublicVars.formatoMoneda)

                If bitPreformaToEntrada Then
                    lblSubtotal.Text = Format(totalCompra, mdlPublicVars.formatoMoneda)
                    lblTotal.Text = Format(totalCompra, mdlPublicVars.formatoMoneda)
                    lblSaldoAjuste.Text = Format(totalCompra - totalPreforma, mdlPublicVars.formatoMoneda)
                Else
                    lblSubtotal.Text = Format(totalPreforma, mdlPublicVars.formatoMoneda)
                    lblTotal.Text = Format(totalPreforma, mdlPublicVars.formatoMoneda)
                    lblSaldoAjuste.Text = Format(0, mdlPublicVars.formatoMoneda)
                End If
            Else
                lblSaldoAjuste.Text = 0
                lblTotal.Text = 0
                lblSaldoPreforma.Text = 0
                lblSubtotal.Text = 0
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
        ''fnTotalProrrateo()
    End Sub

    Public Sub fnAgregar_Articulos()
        'agregar productos a grid.
        Dim filas() As String

        'id, codigo,nombre,precio,cantidad
        ''"###,###." & mdlPublicVars.Entrada_numeroDecimales
        filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, superSearchCantidad, mdlPublicVars.superSearchIdUnidadMedida, mdlPublicVars.superSearchUnidadMedida, mdlPublicVars.superSearchUnidadMedidaValor, Format(mdlPublicVars.superSearchPrecio, formatoNumero), "0", "0", "0", "0", "0"}
        grdProductos.Rows.Add(filas)
        grdProductos.Columns(3).IsCurrent = True
        grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        ''fnActualizar_Total()
        ''fnTotalProrrateo()
        fnActualizar_Total()
    End Sub

    'Evento utilizada para la busqueda de articulo manual
    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Try
            If e.Column.Name = "txmCodigo" Then

                If e.Value IsNot Nothing Then
                    Dim codigo As String = e.Value

                    If codigo.Length > 0 Then
                        fnBuscarArticulo(codigo, e.RowIndex)
                    End If
                    Me.grdProductos.Columns("txmCantidad").IsCurrent = True

                    fnAgregarFilaBlanco()
                End If

            ElseIf e.Column.Name = "txmCosto" Then

                'fnAgregarFilaBlanco()
                Me.grdProductos.Columns("txmCodigo").IsCurrent = True

                ''fnActualizar_Total()
                ''fnTotalProrrateo()
                fnActualizar_Total()

            ElseIf e.Column.Name = "txmCantidad" Then
                '' fnActualizar_Total()
                ''fnTotalProrrateo()
                fnActualizar_Total()

                Me.grdProductos.Columns("txmCosto").IsCurrent = True

            ElseIf e.Column.Name = "txmPrecioPublico" Then

                Dim filas As Integer = Me.grdProductos.Rows.Count - 1
                Dim costo As Decimal
                Dim precio As Decimal
                Dim producto As String
                For index As Integer = 0 To filas
                    costo = Me.grdProductos.Rows(index).Cells("costototal").Value
                    precio = Me.grdProductos.Rows(index).Cells("txmPrecioPublico").Value
                    producto = Me.grdProductos.Rows(index).Cells("txbProducto").Value

                    If producto <> "" Then
                        If precio < costo Then
                            RadMessageBox.Show("El precio  del producto: " + LTrim(RTrim(CStr(producto))) + " es menor al costo", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        ElseIf precio = costo Then
                            RadMessageBox.Show("El precio del producto: " + LTrim(RTrim(CStr(producto))) + " es igual al costo", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        End If
                    End If
                Next

            Else
                ''fnActualizar_Total()
                ''fnTotalProrrateo()
                fnActualizar_Total()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

        'cerrar opciones de edicion
        grdProductos.CloseEditor()
        grdProductos.CancelEdit()
        grdProductos.EditorManager.CloseEditor()
        grdProductos.EditorManager.CancelEdit()
    End Sub

    'Buscar Articulo Unico
    Public Sub fnBuscarArticulo(ByVal codigo As String, ByVal posicion As Integer)
        Try
            'Buscamos el articulo en base al codigo
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.codigo1 = codigo And x.empresa = mdlPublicVars.idEmpresa _
                                          Select x).FirstOrDefault

            If articulo Is Nothing Then
                If RadMessageBox.Show("Este producto no existe desea agregarlo", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    Try
                        frmProducto.seleccionDefault = False
                        frmProducto.Text = "Modulo de Productos"
                        frmProducto.codigoProductoNuevo = codigo
                        frmProducto.posicion = posicion
                        frmProducto.NuevoIniciar = True
                        frmProducto.nuevoProducto = True

                        permiso.PermisoMantenimientoTelerik2(frmProducto, False)
                    Catch ex As Exception
                        alerta.fnError()
                    End Try
                End If
            Else
                Me.grdProductos.Rows(posicion).Cells("iddetalle").Value = "0"
                Me.grdProductos.Rows(posicion).Cells("id").Value = articulo.idArticulo
                Me.grdProductos.Rows(posicion).Cells("txmCodigo").Value = articulo.codigo1
                Me.grdProductos.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                Me.grdProductos.Rows(posicion).Cells("txmCantidad").Value = "0"
                Me.grdProductos.Rows(posicion).Cells("txmCosto").Value = Format(articulo.costoIVA, "###,###." & mdlPublicVars.Entrada_numeroDecimales)
                Me.grdProductos.Rows(posicion).Cells("Total").Value = 0
                Me.grdProductos.Rows(posicion).Cells("elimina").Value = 0

            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para guardar una compra
    Private Sub fnGuardarCompra()

        Dim codigoCompra As Integer = 0

        If fnErrores(False, True, False) = True Then
            Exit Sub
        End If

        Dim fechaServidor As DateTime = fnFecha_horaServidor()
        Dim hora As String = mdlPublicVars.fnHoraServidor
        Dim success As Boolean = True
        Dim contado As Boolean = False
        Dim costoflete As Boolean = False
        Dim codigoProveedor As Integer = 0
        ''fnActualizar_Total()
        ''fnTotalProrrateo()
        fnActualizar_Total()

        If RadMessageBox.Show("Desea Guardar la Compra", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            conexion.CommandTimeout = 100000

            '-------------------Creamos el encabezado de la compra------------'
            Using transaction As New TransactionScope
                Try
                    'Guardamos el codigo de la entrada (idEntrada)

                    'actualizar el correlativo.
                    Dim numeroCorrelativo As String = 0

                    If Not bitPreformaToEntrada Then

                        Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento _
                                                         And x.idEmpresa = mdlPublicVars.idEmpresa Select x).First

                        If correlativo IsNot Nothing Then
                            correlativo.correlativo += 1
                            conexion.SaveChanges()

                            'asignar el numero de correlativo.
                            numeroCorrelativo = correlativo.serie & correlativo.correlativo
                        Else
                            'crear registro de correlativo.
                            Dim correlativoNuevo As New tblCorrelativo
                            correlativoNuevo.correlativo = 1
                            correlativoNuevo.serie = ""
                            correlativoNuevo.inicio = 1
                            correlativoNuevo.fin = 1000
                            correlativoNuevo.porcentajeAviso = 20
                            correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                            correlativoNuevo.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                            conexion.AddTotblCorrelativos(correlativoNuevo)
                            conexion.SaveChanges()

                            'asignar el numero de correlativo.
                            numeroCorrelativo = 1
                        End If
                    End If

                    'Creamos la fila que se agregara a la tblEntrada
                    Dim nuevaCompra As New tblEntrada
                    Dim ltotal As Decimal = 0
                    If bitPreformaToEntrada Then
                        'Obtenemos la compra
                        nuevaCompra = (From x In conexion.tblEntradas Where x.idEntrada = codigo _
                                       Select x).FirstOrDefault
                        ltotal = CDec(Replace(lblTotal.Text, "Q", "").Trim)
                        ' Dim lbtotal As Decimal = Replace(lblTotal.Text, "Q", "")
                        nuevaCompra.total = CDbl(ltotal)
                        nuevaCompra.fechaCompra = fechaServidor
                        nuevaCompra.compra = True
                        nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
                        nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                        nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                        nuevaCompra.documento = txtDocumento.Text
                        nuevaCompra.serieDocumento = txtSerie.Text
                        nuevaCompra.observacion = txtObservacion.Text
                        conexion.SaveChanges()
                    Else
                        nuevaCompra.idEmpresa = mdlPublicVars.idEmpresa
                        nuevaCompra.idUsuario = mdlPublicVars.idUsuario
                        nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                        nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                        nuevaCompra.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                        nuevaCompra.fechaTransaccion = fechaServidor
                        nuevaCompra.documento = txtDocumento.Text
                        nuevaCompra.serieDocumento = txtSerie.Text
                        nuevaCompra.observacion = txtObservacion.Text
                        nuevaCompra.anulado = 0
                        nuevaCompra.flete = Me.txtFlete.Text
                        nuevaCompra.total = CDbl(lblTotal.Text)
                        nuevaCompra.saldo = CDbl(lblTotal.Text)
                        nuevaCompra.pagos = 0
                        nuevaCompra.correlativo = numeroCorrelativo
                        nuevaCompra.cancelado = 0
                        nuevaCompra.anulado = False
                        nuevaCompra.fechaCompra = nuevaCompra.fechaRegistro
                        nuevaCompra.compra = True
                        nuevaCompra.preforma = False
                        nuevaCompra.transito = False
                        nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
                        nuevaCompra.preformaimportacion = False
                        nuevaCompra.estadocuenta = True
                        'ubicaciones
                        nuevaCompra.idalmacen = mdlPublicVars.General_idAlmacenPrincipal
                        nuevaCompra.idtipoInventario = mdlPublicVars.General_idTipoInventario
                        nuevaCompra.fechadocumento = Me.dtpFechaDocumento.Value

                        If dtpProxFecha.Visible = True Then
                            nuevaCompra.credito = True
                            nuevaCompra.contado = False
                            nuevaCompra.fechaPago = dtpProxFecha.Text
                        Else
                            nuevaCompra.credito = False
                            nuevaCompra.contado = True
                        End If

                        conexion.AddTotblEntradas(nuevaCompra)
                        conexion.SaveChanges()
                    End If


                    codigoCompra = nuevaCompra.idEntrada

                    If Me.txtFlete.Text > 0 Then
                        If RadMessageBox.Show("Desea Aplicar el Costo con el Flete", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            costoflete = True
                        Else
                            costoflete = False
                        End If
                    Else
                        costoflete = False
                    End If


                    'Creamos el detalle de nuestra compra, que se agregara en la tblEntradasDetalle
                    'Consultamos el idEntrada y creamos las variables para guardar los datos por cada articulo
                    Dim idArticulo As Integer = 0
                    Dim cantidad As Double = 0
                    Dim costo As Double = 0
                    Dim costopro As Double = 0
                    Dim nombreArticulo As String = ""
                    Dim index As Integer = 0
                    Dim cantidadCompra As Double = 0
                    Dim costoCompra As Double = 0
                    Dim idDetalle As Integer = 0
                    Dim valmedida As Double = 0
                    Dim idmedida As Integer = 0
                    Dim nuevoprecio As Decimal = 0

                    'Recorremos el grid de productos 
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        'Creamos la fila de detalle
                        idArticulo = Me.grdProductos.Rows(index).Cells("Id").Value

                        If Not bitPreformaToEntrada Then
                            cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
                            costo = Me.grdProductos.Rows(index).Cells("txmCosto").Value
                            costopro = Me.grdProductos.Rows(index).Cells("costoTotal").Value
                            valmedida = Me.grdProductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdProductos.Rows(index).Cells("idmedida").Value
                            nuevoprecio = Me.grdProductos.Rows(index).Cells("txmPrecioPublico").Value
                        Else
                            cantidad = Me.grdProductos.Rows(index).Cells("Cantidad").Value
                            costo = Me.grdProductos.Rows(index).Cells("Costo").Value
                            costopro = Me.grdProductos.Rows(index).Cells("costoTotal").Value
                            valmedida = Me.grdProductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdProductos.Rows(index).Cells("idmedida").Value
                            nuevoprecio = Me.grdProductos.Rows(index).Cells("txmPrecioPublico").Value
                        End If

                        nombreArticulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value

                        Try
                            idDetalle = Me.grdProductos.Rows(index).Cells("idDetalle").Value
                        Catch ex As Exception
                            idDetalle = 0
                        End Try



                        If nombreArticulo IsNot Nothing Then
                            If bitPreformaToEntrada Then
                                'Si se quiere pasar una preforma a entrada

                                'Obtenemos el costo de compra y cantidad de compra
                                costoCompra = Me.grdProductos.Rows(index).Cells("txmCostoCompra").Value
                                cantidadCompra = Me.grdProductos.Rows(index).Cells("txmCantidadCompra").Value


                                'Modificamos el detalle
                                Dim detalle As tblEntradasDetalle = (From x In conexion.tblEntradasDetalles Where x.idEntradaDetalle = idDetalle _
                                                                    Select x).FirstOrDefault

                                detalle.cantidad = cantidadCompra
                                detalle.costoIVA = costoCompra
                                detalle.costoSinIVA = costoCompra / (1 + (mdlPublicVars.General_IVA / 100))

                                conexion.SaveChanges()

                                'Aumentos las existencias, y entradas en el inventario
                                Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo _
                                                                   And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                   And x.idTipoInventario = nuevaCompra.idtipoInventario And x.IdAlmacen = nuevaCompra.idalmacen _
                                                                   Select x).FirstOrDefault

                                Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idArticulo).FirstOrDefault

                                Dim precios As Double = 0

                                If inventario IsNot Nothing Then
                                    If mdlPublicVars.bitTransportePesado = True Then
                                        If mdlPublicVars.CompraUltimoCosto = True Then
                                            If costoflete = True Then
                                                producto.costoIVA = costopro
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            Else
                                                producto.costoIVA = costo
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            End If
                                        Else
                                            precios = (producto.costoIVA * inventario.saldo) + (costoCompra * cantidadCompra)
                                            producto.costoIVA = precios / (inventario.saldo + cantidadCompra)
                                            producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                        End If
                                    Else
                                        precios = (producto.costoIVA * inventario.saldo) + (costoCompra * cantidadCompra)
                                        producto.costoIVA = precios / (inventario.saldo + cantidadCompra)
                                        producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                    End If
                                Else
                                    If cantidadCompra > 0 Then
                                        If mdlPublicVars.bitTransportePesado = True Then
                                            If mdlPublicVars.CompraUltimoCosto = True Then
                                                If costoflete = True Then
                                                    producto.costoIVA = costopro
                                                    producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                                Else
                                                    producto.costoIVA = costo
                                                    producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                                End If
                                            Else
                                                precios = (costoCompra * cantidadCompra)
                                                producto.costoIVA = precios / cantidadCompra
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            End If
                                        Else
                                            precios = (costoCompra * cantidadCompra)
                                            producto.costoIVA = precios / cantidadCompra
                                            producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                        End If
                                    End If
                                End If

                                'guardar los cambios
                                conexion.SaveChanges()

                                If inventario Is Nothing Then
                                    'crear el registro en inventario.
                                    Dim inveNuevo As New tblInventario

                                    inveNuevo.idInventario = nuevaCompra.idtipoInventario
                                    inveNuevo.IdAlmacen = nuevaCompra.idalmacen
                                    inveNuevo.entrada = cantidadCompra * valmedida
                                    inveNuevo.saldo = cantidadCompra * valmedida
                                    inveNuevo.salida = 0
                                    conexion.AddTotblInventarios(inveNuevo)
                                    conexion.SaveChanges()
                                Else
                                    'Aumentamos entradas
                                    inventario.entrada = inventario.entrada + cantidadCompra * valmedida
                                    'Aumentamos saldo
                                    inventario.saldo = inventario.saldo + cantidadCompra * valmedida
                                    conexion.SaveChanges()
                                End If

                                'guardar los cambios
                                conexion.SaveChanges()

                                If costoCompra <> costo Then
                                    'Creamos el pendiente
                                    Dim ajuste As New tblPendiente
                                    ajuste.entradaDetalle = idDetalle
                                    ajuste.valor_compra = costoCompra * valmedida
                                    ajuste.valor_preforma = costo

                                    If costoCompra > costo Then
                                        ajuste.tipo = 1
                                    Else
                                        ajuste.tipo = 2
                                    End If

                                    conexion.AddTotblPendientes(ajuste)
                                    conexion.SaveChanges()
                                End If

                                If cantidadCompra <> cantidad Then
                                    'Creamos el pendiente
                                    Dim ajuste As New tblPendiente
                                    ajuste.entradaDetalle = idDetalle
                                    ajuste.valor_compra = cantidadCompra
                                    ajuste.valor_preforma = cantidad * valmedida

                                    If cantidadCompra > cantidad Then
                                        ajuste.tipo = 4
                                    Else
                                        ajuste.tipo = 3
                                    End If

                                    conexion.AddTotblPendientes(ajuste)
                                    conexion.SaveChanges()
                                End If
                            Else
                                'Si solo es una compra
                                Dim detalleEntrada As New tblEntradasDetalle
                                detalleEntrada.idEntrada = codigoCompra
                                detalleEntrada.idArticulo = idArticulo
                                detalleEntrada.cantidad = cantidad
                                detalleEntrada.costoIVA = costo
                                detalleEntrada.costoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))
                                detalleEntrada.preformaCantidad = cantidad * valmedida
                                detalleEntrada.preformaCostoIVA = costo
                                detalleEntrada.preformaCostoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))
                                detalleEntrada.costoprorrateo = costopro
                                detalleEntrada.idunidadmedida = idmedida
                                detalleEntrada.valormedida = valmedida
                                conexion.AddTotblEntradasDetalles(detalleEntrada)
                                conexion.SaveChanges()

                                ''Comenzo la Actualizacion de Precios para la Compra
                                If nuevoprecio > 0.0 Then
                                    Dim prod As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = detalleEntrada.idArticulo Select x).FirstOrDefault

                                    prod.precioPublico = nuevoprecio

                                    conexion.SaveChanges()
                                End If
                                ''Finalizo la Actualizacion de Precios para la Compra

                                'Aumentos las existencias, y entradas en el inventario
                                Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                   And x.idTipoInventario = nuevaCompra.idtipoInventario And x.IdAlmacen = nuevaCompra.idalmacen _
                                                                   Select x).FirstOrDefault

                                Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idArticulo).First

                                Dim precios As Double = 0

                                If inventario IsNot Nothing Then
                                    If mdlPublicVars.bitTransportePesado = True Then
                                        If mdlPublicVars.CompraUltimoCosto = True Then
                                            If costoflete = True Then
                                                producto.costoIVA = costopro
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            Else
                                                producto.costoIVA = costo
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            End If
                                        Else
                                            precios = (producto.costoIVA * inventario.saldo) + (costo * cantidad)
                                            If inventario.saldo + cantidad <> 0 Then
                                                producto.costoIVA = precios / (inventario.saldo + cantidad)
                                            Else
                                                producto.costoIVA = producto.costoIVA
                                            End If
                                            producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                        End If
                                    Else
                                        precios = (producto.costoIVA * inventario.saldo) + (costo * cantidad)
                                        If inventario.saldo + cantidad <> 0 Then
                                            producto.costoIVA = precios / (inventario.saldo + cantidad)
                                        Else
                                            producto.costoIVA = producto.costoIVA
                                        End If
                                        producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                    End If
                                Else
                                    If mdlPublicVars.bitTransportePesado = True Then
                                        If mdlPublicVars.CompraUltimoCosto = True Then
                                            If costoflete = True Then
                                                producto.costoIVA = costopro
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            Else
                                                producto.costoIVA = costo
                                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                            End If
                                        Else
                                            precios = (costo * cantidad)
                                            producto.costoIVA = precios / cantidad
                                            producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                        End If
                                    Else
                                        precios = (costo * cantidad)
                                        producto.costoIVA = precios / cantidad
                                        producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                    End If
                                End If

                                'Actualizamos la fecha de ultimacompra del articulo
                                producto.fechaUltimaCompra = fechaServidor
                                conexion.SaveChanges()

                                If inventario Is Nothing Then
                                    'crear el registro en inventario.
                                    Dim inveNuevo As New tblInventario

                                    inveNuevo.idInventario = nuevaCompra.idtipoInventario
                                    inveNuevo.IdAlmacen = nuevaCompra.idalmacen
                                    inveNuevo.entrada = cantidad * valmedida
                                    inveNuevo.saldo = cantidad * valmedida
                                    inveNuevo.salida = 0
                                    conexion.AddTotblInventarios(inveNuevo)
                                    conexion.SaveChanges()
                                Else
                                    'Aumentamos entradas
                                    inventario.entrada += cantidad * valmedida
                                    'Aumentamos saldo
                                    inventario.saldo += cantidad * valmedida
                                    conexion.SaveChanges()
                                End If

                                conexion.SaveChanges()
                            End If
                        End If
                    Next

                    'Si la compra fue al credito generamos cuenta por cobrar
                    If nuevaCompra.contado Then
                        contado = True
                        codigoProveedor = nuevaCompra.idProveedor
                    End If

                    'Aumentamos el saldo del proveedor y establecemos la ultima compra
                    Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = nuevaCompra.idProveedor Select x).FirstOrDefault

                    If proveedor.saldoActual Is Nothing Then
                        proveedor.saldoActual = nuevaCompra.total
                    Else
                        proveedor.saldoActual += nuevaCompra.total
                    End If
                    proveedor.ultimaCompra = nuevaCompra.fechaRegistro

                    conexion.SaveChanges()


                    ''AQUI TENEMOS QUE COLOCAR LAS OPRACIONES DE LOS IMPUESTOS

                    ''-----********------------IMPUESTOS-*-*-*-*--*-*-------------------**************
                    If Activar_Impuestos = True Then
                        Dim totalcon As Decimal
                        totalcon = CDec(Replace(lblTotal.Text, "Q", "").Trim)

                        Dim impuesto = (From x In conexion.tblImpuestoCobrar_TipoMovimiento, y In conexion.tblImpuestoCobrar_Impuesto, z In conexion.tblImpuestoes Where y.idImpuestoCobrar = x.idImpuestoCobrar _
                                        And z.idImpuesto = y.idImpuesto And x.idTipoMovimiento = Entrada_CodigoMovimiento Select z.idImpuesto, z.nombre, z.formula)

                        Dim impuestos As DataTable = mdlPublicVars.EntitiToDataTable(impuesto)

                        Dim idimpues As Integer = 0
                        Dim nombreimpuesto As String = ""
                        Dim formu As String = ""
                        Dim expresionpostfija As String = ""
                        Dim validador As New clsValidar
                        Dim convertidor As New clsConvertir
                        Dim resuelve As New clsResolver
                        Dim impues As Decimal = 0
                        Dim totalString As String = ""

                        For Each fila As DataRow In impuestos.Rows

                            totalString = CStr(totalcon)
                            idimpues = fila.Item("idImpuesto")
                            nombreimpuesto = fila.Item("nombre")
                            formu = fila.Item("formula")
                            formu = formu.Replace("dato", CStr(totalString))

                            If validador.validar(formu) Then
                                expresionpostfija = convertidor.fnConvierte(formu)
                                impues = CDec(resuelve.fnResolver(expresionpostfija))

                                Dim impuestoentrada As New tblImpuesto_Entrada
                                impuestoentrada.idImpuesto = idimpues
                                impuestoentrada.idEntrada = codigoCompra
                                impuestoentrada.descripcion = nombreimpuesto
                                impuestoentrada.valor = impues

                                conexion.AddTotblImpuesto_Entrada(impuestoentrada)
                                conexion.SaveChanges()

                            End If

                        Next
                    End If
                    ''-------------************FIN DE IMPUESTOS************----------------------------

                    'paso 8, completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        success = False
                        MessageBox.Show("Error al Guardar !!!" + ex.ToString)
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                    success = False
                    MessageBox.Show("Error al Guardar !!!" + ex.ToString)
                    Exit Try
                End Try
            End Using
            If success = True Then
                conexion.AcceptAllChanges()
                fnNuevo()
                ''fnTotalProrrateo()
                fnActualizar_Total()
                bitPreformaToEntrada = False
                RadMessageBox.Show("Compra guardada exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
            End If
            conn.Close()
        End Using

        If success Then
            If contado Then
                ''If RadMessageBox.Show("Desea realizar un pago al proveedor", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                ''    Dim prov As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigoProveedor Select x).FirstOrDefault
                ''    ''frmPagoNuevo.Text = "Pagos"
                ''    ''frmPagoNuevo.bitProveedor = True
                ''    ''frmPagoNuevo.codigoCP = prov.idProveedor
                ''    ''frmPagoNuevo.lblSaldo.Text = prov.saldoActual
                ''    ''frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                ''    ''permiso.PermisoFrmEspeciales(frmPagoNuevo, False)
                ''    frmPagoProveedores.Text = "Pagos"
                ''    frmPagoProveedores.bitProveedor = True
                ''    frmPagoProveedores.codigoCP = prov.idProveedor
                ''    frmPagoProveedores.lblSaldo.Text = prov.saldoActual
                ''    frmPagoProveedores.StartPosition = FormStartPosition.CenterScreen
                ''    permiso.PermisoFrmEspeciales(frmPagoProveedores, False)
                ''End If
            End If
        End If
    End Sub

    'Funcion utilizada para modificar una compra
    Private Sub fnModificarCompra()


        If MessageBox.Show("Desea Guardar los cambios", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            If fnErrores(False, True, False) = True Then
                Exit Sub
            End If


            Dim success As Boolean = True
            Dim codigoProveedor As Integer = 0


            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)



                '-------------------Creamos el encabezado de la compra------------'
                Using transaction As New TransactionScope
                    Try
                        'Guardamos el codigo de la entrada (idEntrada)
                        Dim codigoCompra As Long = codigo

                        'Obtenemos la entrada a modificar
                        Dim nuevaCompra As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = codigoCompra Select x).FirstOrDefault

                        'Creamos la fila que se agregara a la tblEntrada
                        'nuevaCompra.idEmpresa = mdlPublicVars.idEmpresa
                        'nuevaCompra.idUsuario = mdlPublicVars.idUsuario
                        'nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento

                        nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                        nuevaCompra.fechaRegistro = dtpFechaRegistro.Text
                        nuevaCompra.documento = txtDocumento.Text
                        nuevaCompra.serieDocumento = txtSerie.Text
                        nuevaCompra.observacion = txtObservacion.Text
                        nuevaCompra.anulado = 0
                        nuevaCompra.flete = 0
                        nuevaCompra.total = CDbl(lblTotal.Text)

                        nuevaCompra.cancelado = 0
                        conexion.SaveChanges()


                        'Creamos el detalle de nuestra compra, que se agregara en la tblEntradasDetalle
                        'Consultamos el idEntrada y creamos las variables para guardar los datos por cada articulo
                        Dim idArticulo As Integer = 0
                        Dim cantidad As Integer = 0
                        Dim costo As Double = 0
                        Dim nombreArticulo As String = ""
                        Dim index As Integer = 0
                        Dim detalle As Integer = 0
                        Dim elimina As Integer = 0
                        Dim valmedida As Double = 0
                        Dim idmedida As Integer = 0
                        'Recorremos el grid de productos 
                        For index = 0 To Me.grdProductos.Rows.Count - 1
                            'Creamos la fila de detalle
                            idArticulo = Me.grdProductos.Rows(index).Cells(1).Value
                            cantidad = Me.grdProductos.Rows(index).Cells(4).Value

                           
                            costo = Me.grdProductos.Rows(index).Cells(8).Value

                            nombreArticulo = Me.grdProductos.Rows(index).Cells(3).Value
                            detalle = Me.grdProductos.Rows(index).Cells(0).Value
                            elimina = Me.grdProductos.Rows(index).Cells("elimina").Value
                            valmedida = Me.grdProductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdProductos.Rows(index).Cells("idmedida").Value

                            If nombreArticulo IsNot Nothing Then
                                If elimina > 0 Then
                                    'Si es un detalle y se va a eliminar

                                    'Obtenemo el registro del detalle que se va a eliminar
                                    Dim detalleEntrada As tblEntradasDetalle = (From x In conexion.tblEntradasDetalles Where x.idEntradaDetalle = detalle).FirstOrDefault

                                    'eliminar el detalle cuando no es vacio.
                                    If detalleEntrada IsNot Nothing Then
                                        conexion.DeleteObject(detalleEntrada)
                                        conexion.SaveChanges()
                                    End If

                                ElseIf detalle > 0 Then
                                    'Si ya existe registro

                                    'Obtenemos el registro
                                    Dim detalleEntrada As tblEntradasDetalle = (From x In conexion.tblEntradasDetalles Where x.idEntradaDetalle = detalle Select x).FirstOrDefault
                                    detalleEntrada.idEntrada = codigoCompra
                                    detalleEntrada.idArticulo = idArticulo
                                    detalleEntrada.cantidad = cantidad
                                    detalleEntrada.costoIVA = costo
                                    conexion.SaveChanges()
                                Else
                                    'Si es un registro nuevo
                                    Dim detalleEntrada As New tblEntradasDetalle
                                    detalleEntrada.idEntrada = codigoCompra
                                    detalleEntrada.idArticulo = idArticulo
                                    detalleEntrada.cantidad = cantidad
                                    detalleEntrada.costoIVA = costo
                                    detalleEntrada.idunidadmedida = idmedida
                                    detalleEntrada.valormedida = valmedida
                                    conexion.AddTotblEntradasDetalles(detalleEntrada)
                                    conexion.SaveChanges()
                                End If

                            End If
                        Next

                        'guardar todos los cambios.
                        conexion.SaveChanges()

                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        ' Handle errors and deadlocks here and retry if needed. 
                        ' Allow an UpdateException to pass through and 
                        ' retry, otherwise stop the execution. 
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            success = False
                            MessageBox.Show("Error al guardar !!!" + ex.ToString)
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using

                If success = True Then
                    ctx.AcceptAllChanges()
                    fnLlenarDatos()
                    MessageBox.Show("Registro Guardado")
                End If

                'cerrar la conexion
                conn.Close()

                'finalizar proceso.
            End Using


        End If

    End Sub

    'Funcion utilizada para verificar si hay errores en la compra
    Private Function fnErrores(bitCrearProforma As Boolean, bitCrearCompra As Boolean, bitModificarProforma As Boolean) As Boolean

        Dim producto As String
        Dim filas As Integer = 0
        For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
            producto = Me.grdProductos.Rows(i).Cells("txbProducto").Value

            If producto IsNot Nothing Then
                filas += 1
            End If
        Next

        If Me.grdProductos.RowCount = 0 Then
            alerta.contenido = "Debe agregar productos a la compra"
            alerta.fnErrorContenido()

            Me.grdProductos.Focus()
            Return True
            Exit Function
        End If

        If LTrim(RTrim(txtDocumento.Text.Equals(""))) Then
            alerta.contenido = "Falta No. Documento "
            alerta.fnErrorContenido()
            txtDocumento.Focus()
            Return True
            Exit Function
        End If

        'Verificamos que todos los productos tengan cantidad
        Dim index
        Dim cantidad As Double = 0
        For index = 0 To Me.grdProductos.Rows.Count - 1

            Dim art As String = Me.grdProductos.Rows(index).Cells(3).Value

            If art IsNot Nothing Then

                If bitPreformaToEntrada Then
                    cantidad = Me.grdProductos.Rows(index).Cells("txmCantidadCompra").Value
                Else
                    cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
                End If

                If cantidad <= 0 Then
                    MessageBox.Show("Debe ingresar una cantidad al Articulo : " & Me.grdProductos.Rows(index).Cells("txbProducto").Value & " (" & Me.grdProductos.Rows(index).Cells("txbProducto").Value & " )", mdlPublicVars.nombreSistema)
                    Return True
                    Exit Function
                End If
            End If
        Next
        Return False
    End Function

    'PREFORMA
    Private Sub fnPreforma() Handles Me.panel1
        If verRegistro = True Then
            alerta.fnNoEditable()
            Exit Sub
        End If

        If fnErrores(True, False, False) = False Then
            If bitEditarEntrada = False Then
                fnGuardarPreforma()
            Else
                alerta.contenido = "Utilice Modificar!"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    'COMPRAR
    Private Sub pbxGuardar_Click() Handles Me.panel2
        If verRegistro = True Then
            alerta.fnNoEditable()
            Exit Sub
        End If

        If fnErrores(False, True, False) = False Then
            If bitEditarEntrada = False Or bitPreformaToEntrada Then
                fnGuardarCompra()
            Else
                alerta.contenido = "Utilice Modificar!"
                alerta.fnErrorContenido()
            End If
        End If
    End Sub

    ''PRODUCTOS
    Private Sub fnSalir_Click() Handles Me.panel5
        Me.Close()
    End Sub

    Private Sub fnProductos_Click() Handles Me.panel4
        Dim permiso As New clsPermisoUsuario
        frmProducto.seleccionDefault = False
        frmProducto.Text = "Modulo de Productos"
        frmProducto.NuevoIniciar = True
        permiso.PermisoDialogMantenimientoTelerik2(frmProducto)
        frmProducto.Dispose()
    End Sub

    'MODIFICAR
    Private Sub fnModificar() Handles Me.panel3
        If verRegistro = True Then
            alerta.fnNoEditable()
            Exit Sub
        End If

        Try
            If fnErrores(False, False, True) = False Then
                If bitEditarEntrada = True Then
                    fnModificarCompra()
                Else
                    alerta.contenido = "Utilice GUARDAR !!"
                    alerta.fnErrorContenido()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'NUEVO
    Private Sub pbNuevo_Click() Handles Me.panel0
        fnNuevo()
    End Sub

    'GUARDAR PREFORMA
    Private Sub fnGuardarPreforma()


        If fnErrores(True, False, False) = True Then
            Exit Sub
        End If

        'Esta funcion se utiliza para guardar una preforma
        Dim fechaServidor As DateTime = fnFecha_horaServidor()
        Dim hora As String = mdlPublicVars.fnHoraServidor
        Dim success As Boolean = True
        Dim contado As Boolean = False
        Dim codigoProveedor As Integer = 0




        If RadMessageBox.Show("Desea Guardar los cambios ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If


        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)




            '-------------------Creamos el encabezado de la compra------------'
            Using transaction As New TransactionScope
                Try

                    'Guardamos el codigo de la entrada (idEntrada)
                    Dim codigoCompra As Integer = 0

                    'actualizar el correlativo.
                    Dim numeroCorrelativo As String = 0

                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento _
                                                     And x.idEmpresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                    If correlativo IsNot Nothing Then
                        correlativo.correlativo += 1
                        conexion.SaveChanges()

                        'asignar el numero de correlativo.
                        numeroCorrelativo = correlativo.serie & correlativo.correlativo
                    Else
                        'crear registro de correlativo.
                        Dim correlativoNuevo As New tblCorrelativo
                        correlativoNuevo.correlativo = 1
                        correlativoNuevo.serie = ""
                        correlativoNuevo.inicio = 1
                        correlativoNuevo.fin = 1000
                        correlativoNuevo.porcentajeAviso = 20
                        correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                        correlativoNuevo.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                        conexion.AddTotblCorrelativos(correlativoNuevo)
                        conexion.SaveChanges()

                        'asignar el numero de correlativo.
                        numeroCorrelativo = 1
                    End If

                    'Creamos la fila que se agregara a la tblEntrada
                    Dim nuevaCompra As New tblEntrada
                    nuevaCompra.idEmpresa = mdlPublicVars.idEmpresa
                    nuevaCompra.idUsuario = mdlPublicVars.idUsuario
                    nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                    nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                    nuevaCompra.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                    nuevaCompra.fechaTransaccion = fechaServidor
                    nuevaCompra.documento = txtDocumento.Text
                    nuevaCompra.serieDocumento = txtSerie.Text
                    nuevaCompra.observacion = txtObservacion.Text
                    nuevaCompra.anulado = 0
                    nuevaCompra.flete = 0
                    nuevaCompra.total = CDbl(lblTotal.Text)
                    nuevaCompra.correlativo = numeroCorrelativo
                    nuevaCompra.cancelado = 0
                    nuevaCompra.anulado = False

                    'Estados de la compra
                    nuevaCompra.transito = False
                    nuevaCompra.compra = False
                    nuevaCompra.preforma = True

                    'ubicaciones
                    nuevaCompra.idalmacen = mdlPublicVars.General_idAlmacenPrincipal
                    nuevaCompra.idtipoInventario = mdlPublicVars.General_idTipoInventario

                    If dtpProxFecha.Visible = True Then
                        nuevaCompra.credito = True
                        nuevaCompra.contado = False
                        nuevaCompra.fechaPago = dtpProxFecha.Text
                    Else
                        nuevaCompra.credito = False
                        nuevaCompra.contado = True
                    End If

                    conexion.AddTotblEntradas(nuevaCompra)
                    conexion.SaveChanges()


                    codigoCompra = nuevaCompra.idEntrada

                    'Creamos el detalle de nuestra compra, que se agregara en la tblEntradasDetalle
                    'Consultamos el idEntrada y creamos las variables para guardar los datos por cada articulo
                    Dim idArticulo As Integer = 0
                    Dim cantidad As Double = 0
                    Dim costo As Double = 0
                    Dim nombreArticulo As String = ""
                    Dim index As Integer = 0
                    'Recorremos el grid de productos 
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        'Creamos la fila de detalle
                        idArticulo = Me.grdProductos.Rows(index).Cells("Id").Value
                        cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
                        costo = Me.grdProductos.Rows(index).Cells("txmCosto").Value
                        nombreArticulo = Me.grdProductos.Rows(index).Cells("txbProducto").Value

                        If nombreArticulo IsNot Nothing Then
                            Dim detalleEntrada As New tblEntradasDetalle
                            detalleEntrada.idEntrada = codigoCompra
                            detalleEntrada.idArticulo = idArticulo
                            detalleEntrada.preformaCantidad = cantidad
                            detalleEntrada.preformaCostoIVA = costo
                            detalleEntrada.preformaCostoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))
                            detalleEntrada.cantidad = cantidad
                            detalleEntrada.costoIVA = costo
                            detalleEntrada.costoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))
                            detalleEntrada.idunidadmedida = mdlPublicVars.UnidadMedidaDefault
                            detalleEntrada.valormedida = 1
                            conexion.AddTotblEntradasDetalles(detalleEntrada)
                            conexion.SaveChanges()
                        End If
                    Next

                    conexion.SaveChanges()
                    'paso 8, completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        success = False
                        MessageBox.Show("Error al Guardar " + ex.ToString)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                ctx.AcceptAllChanges()
                fnNuevo()
                MessageBox.Show("Registro Guardado")
            End If


            'cerrar la conexion()
            conn.Close()
            'finalizar el proceso
        End Using
    End Sub

    'Funcion que se utiliza para remover la fila actual
    Public Sub fnRemoverFila()
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
    End Sub

    'Funcion que se utiliza para agregar una nueva fila
    Public Sub fnNuevaFila()
        fnEliminaVacias()
        Me.grdProductos.Rows.AddNew()
    End Sub

    'Funcion utilizada para eliminar filas vacias
    Private Sub fnEliminaVacias()
        Try
            If Me.grdProductos.Rows.Count > 0 Then
                'Recorremos el grid
                Dim nombre As String = ""
                For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
                    'Obtenemo el valor del nombre
                    nombre = Me.grdProductos.Rows(i).Cells("txbProducto").Value
                    If IsNothing(nombre) Then
                        Me.grdProductos.Rows.RemoveAt(i)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbProveedores_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedores.SelectedValueChanged
        Try
            'Obtenemos el tipo de pago del proveedor
            Dim cPro As Integer = CInt(cmbProveedores.SelectedValue)

            If cPro > 0 Then
                Dim pro As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = cPro Select x).FirstOrDefault
                
                If pro.diasCredito > 0 Then
                    'Calculamos la proxima fehca de pago
                    Dim fechaProx As Date = Me.dtpFechaDocumento.Value
                    fechaProx = fechaProx.AddDays(pro.diasCredito - 1)

                    dtpProxFecha.Value = fechaProx
                Else
                    dtpProxFecha.Value = Today
                End If

            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Maneja el evento de la tecla DELETE, cuando se quiere modificar una salida
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If verRegistro = True Then
            Exit Sub
        End If


        Try
            If bitEditarEntrada And Not bitPreformaToEntrada Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdProductos, "iddetalle")
                ''fnTotalProrrateo()
                fnActualizar_Total()
            End If
            If e.KeyCode = Keys.F2 Then
                If Me.grdProductos.Columns("txbunidadmedida").IsCurrent Then
                    mdlPublicVars.superSearchId = 0
                    mdlPublicVars.superSearchNombre = ""
                    fnConcepto()
                    fnActualizar_Total()
                ElseIf IsNumeric(cmbProveedores.SelectedValue) Then
                    If CInt(cmbProveedores.SelectedValue > 0) Then
                        frmBuscarArticulo.StartPosition = FormStartPosition.CenterScreen
                        frmBuscarArticulo.OpcionRetorno = "entrada"
                        frmBuscarArticulo.Text = "Buscar Articulos"
                        frmBuscarArticulo.codClie = cmbProveedores.SelectedValue
                        frmBuscarArticulo.bitCliente = False
                        frmBuscarArticulo.idInventario = mdlPublicVars.General_idTipoInventario
                        frmBuscarArticulo.idBodega = mdlPublicVars.General_idAlmacenPrincipal
                        frmBuscarArticulo.bitProveedor = True
                        frmBuscarArticulo.venta = 0
                        permiso.PermisoFrmEspeciales(frmBuscarArticulo, False)
                    Else
                        alerta.contenido = "Seleccionar Proveedor...!!!"
                        alerta.fnErrorContenido()
                        cmbProveedores.Focus()
                    End If

                Else
                    alerta.contenido = "Seleccionar Proveedor...!!!"
                    alerta.fnErrorContenido()
                    cmbProveedores.Focus()
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        Try

            If Me.grdProductos.Rows.Count = 0 Then
                Me.grdProductos.Rows.AddNew()
                cmbProveedores.Enabled = True
            Else
                fnAgregarFilaBlanco()
            End If

            fnBloquearCombo()
            ''fnTotalProrrateo()
            fnActualizar_Total()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnAgregarFilaBlanco()

        Dim filaBlanco As Boolean = False
        Dim index

        For index = 0 To Me.grdProductos.Rows.Count - 1

            If Me.grdProductos.Rows(index).Cells(1).Value Is Nothing Then
                filaBlanco = True
            ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value)).ToString.Length = 0 Then
                filaBlanco = True
            End If
        Next

        If filaBlanco = False Then
            Me.grdProductos.Rows.AddNew()
        End If
    End Sub

    'Funcion utilizada para bloquear cliente
    Public Sub fnBloquearCombo()
        Try
            'Obtenemos  el numero de filas
            Dim filas As Integer = CInt(Me.grdProductos.Rows.Count)

            If filas > 1 Then
                cmbProveedores.Enabled = False
            ElseIf filas = 1 Then
                'Verificamos si tiene informacion la fila
                Dim nombre As String = ""
                Try
                    nombre = Me.grdProductos.Rows(0).Cells(3).Value
                Catch ex As Exception
                    nombre = ""
                End Try

                If nombre IsNot Nothing Then
                    cmbProveedores.Enabled = False
                Else
                    cmbProveedores.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEntrada_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmComprasLista.frm_llenarLista()
    End Sub


    Private Sub fnArticulo_informacion()
        Try
            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
            Dim codigo As String = Me.grdProductos.Rows(index).Cells("id").Value.ToString

            If IsNumeric(codigo) Then
                If CType(codigo, Integer) > 0 Then
                    Dim datos = ctx.sp_CadenaCompatibilidad(codigo, mdlPublicVars.General_idTipoInventario)
                    For Each fila As sp_CadenaCompatibilidad_Result In datos
                        lblObservacion.Text = fila.Obs
                        lblSaldo.Text = fila.Saldo
                        lblCompatibilidad.Text = fila.Compatibilidad
                    Next
                Else
                    lblObservacion.Text = ""
                    lblSaldo.Text = 0
                End If
            Else
                lblObservacion.Text = ""
                lblSaldo.Text = 0
                lblCompatibilidad.Text = ""
            End If


            Dim idproveedor As Integer = cmbProveedores.SelectedValue

            If IsNothing(Me.grdProductos.Rows(index).Cells("id").Value) = True Then
                lblObservacion.Text = ""
                lblCompatibilidad.Text = ""
                lblSaldo.Text = 0
                lblUltPrecio.Text = 0
                ' lblUltTipoPrecio.Text = ""
                Exit Sub
            End If


            If IsNumeric(codigo) Then
                If CType(codigo, Integer) > 0 Then

                    Dim datos = ctx.sp_CadenaCompatibilidad(codigo, mdlPublicVars.General_idTipoInventario)
                    For Each fila As sp_CadenaCompatibilidad_Result In datos
                        lblObservacion.Text = fila.Obs
                        lblSaldo.Text = fila.Saldo
                        lblCompatibilidad.Text = fila.Compatibilidad
                    Next

                    Dim ultPrecio As tblEntradasDetalle = (From x In ctx.tblEntradasDetalles
                                                         Where x.tblEntrada.compra = True And x.tblEntrada.anulado = False _
                                    And x.idArticulo = codigo And x.tblEntrada.idProveedor = idproveedor
                                    Order By x.tblEntrada.fechaCompra Descending Select x).FirstOrDefault

                    If ultPrecio IsNot Nothing Then
                        lblUltPrecio.Text = ultPrecio.costoIVA
                        'lblUltTipoPrecio.Text = ultPrecio.tblArticuloTipoPrecio.nombre
                    Else
                        ' lblUltTipoPrecio.Text = 0
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
    End Sub

    Private Sub grdProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        fnArticulo_informacion()
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            frmImportar.Text = "Importar"
            frmImportar.bitEntrada = True
            frmImportar.ShowDialog()

            Dim tblR As DataTable = frmImportar.tblRetorno
            frmImportar.Dispose()
            If tblR.Rows.Count > 0 Then

                'buscar fila con id en blanco.
                Dim filaBlanco As Integer = -1

                Dim index
                For index = 0 To Me.grdProductos.Rows.Count - 1
                    If Me.grdProductos.Rows(index).Cells(1).Value Is Nothing Then
                        Me.grdProductos.Rows.RemoveAt(index)
                    ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value.ToString)).Length = 0 Then
                        filaBlanco = index
                    ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value.ToString)).Length = 1 And LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value.ToString)) = 0 Then
                        filaBlanco = index
                    End If
                Next

                Dim inicio As Integer = 0

                If filaBlanco = -1 Then
                Else
                    'agregar al grid si nueva fila.
                    Me.grdProductos.Rows(filaBlanco).Cells(1).Value = tblR.Rows(0).Item(0)
                    Me.grdProductos.Rows(filaBlanco).Cells(2).Value = tblR.Rows(0).Item(1)
                    Me.grdProductos.Rows(filaBlanco).Cells(3).Value = tblR.Rows(0).Item(2)
                    Me.grdProductos.Rows(filaBlanco).Cells(4).Value = tblR.Rows(0).Item(3)
                    Me.grdProductos.Rows(filaBlanco).Cells(8).Value = tblR.Rows(0).Item(4)
                    Me.grdProductos.Rows(filaBlanco).Cells(9).Value = tblR.Rows(0).Item(5)
                    inicio = 1
                End If

                'agregar los elementos restantes al grid.
                For index = inicio To tblR.Rows.Count - 1
                    '    Me.grdProductos.Rows.Add("", tblR.Rows(index).Item(0), tblR.Rows(index).Item(1), tblR.Rows(index).Item(2), tblR.Rows(index).Item(3), tblR.Rows(index).Item(4), 0, 0, 0, 0)

                    Me.grdProductos.Rows.Add("", tblR.Rows(index).Item(0), tblR.Rows(index).Item(1), tblR.Rows(index).Item(2), tblR.Rows(index).Item(3), tblR.Rows(index).Item(5), "", 1, tblR.Rows(index).Item(4), 0, 0, 0, tblR.Rows(index).Item(3) * tblR.Rows(index).Item(4), "0", 0)
                    fnActualizar_Total()
                Next

                ''fnTotalProrrateo()
                ''fnActualizar_Total()
                Me.grdProductos.Rows.AddNew()

            End If
        Catch ex As Exception
        End Try
        ''fnActualizar_Total()
    End Sub


    Private Sub txtFlete_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFlete.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.grdProductos.Rows.Count - 1 > 0 Then
                '' fnTotalProrrateo()
                fnActualizar_Total()
            End If
        End If
    End Sub

    Private Sub fnTotalProrrateo()

        Try
            Dim flete As Decimal = 0.0
            Dim subtotal As Decimal = 0.0
            Dim filas As Integer = Me.grdProductos.Rows.Count - 1

            flete = Me.txtFlete.Text
            subtotal = Replace(Me.lblSubtotal.Text, "Q", "")

            For index As Integer = 0 To filas
                Dim totalf As Decimal = 0.0
                Dim cantf As Double = 0
                Dim costf As Decimal = 0.0
                Dim totalgasto As Decimal = 0.0
                Dim gastoprod As Decimal = 0.0
                Dim costoprod As Decimal = 0.0

                If bitPreformaToEntrada = True Then
                    cantf = Me.grdProductos.Rows(index).Cells("Cantidad").Value
                    costf = Me.grdProductos.Rows(index).Cells("Costo").Value
                    totalf = (Me.grdProductos.Rows(index).Cells("Cantidad").Value * Me.grdProductos.Rows(index).Cells("Costo").Value)
                Else
                    cantf = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
                    costf = Me.grdProductos.Rows(index).Cells("txmCosto").Value
                    totalf = (Me.grdProductos.Rows(index).Cells("txmCantidad").Value * Me.grdProductos.Rows(index).Cells("txmCosto").Value)
                End If


                Try
                    totalgasto = (totalf / subtotal) * flete
                    gastoprod = totalgasto / cantf
                    costoprod = gastoprod + costf
                Catch
                    totalgasto = 0
                    gastoprod = 0
                    costoprod = 0
                End Try

                If Me.grdProductos.Rows(index).Cells("txbProducto").Value = "" Then
                    Me.grdProductos.Rows(index).Cells("prorrateo").Value = Nothing
                    Me.grdProductos.Rows(index).Cells("CostoTotal").Value = Nothing
                Else
                    Me.grdProductos.Rows(index).Cells("prorrateo").Value = Format(gastoprod, mdlPublicVars.formatoNumero)
                    Me.grdProductos.Rows(index).Cells("CostoTotal").Value = Format(costoprod, mdlPublicVars.formatoNumero)
                End If
            Next
        Catch

        End Try
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
                frmSeleccion.bitProduccion = True
                frmSeleccion.bitVenta = False
                frmSeleccion.StartPosition = FormStartPosition.CenterScreen
                frmSeleccion.ShowDialog()
                frmSeleccion.Dispose()

                If mdlPublicVars.superSearchIdUnidadMedida > 0 Then
                    Me.grdProductos.Rows(fila).Cells("idmedida").Value = mdlPublicVars.superSearchIdUnidadMedida
                    Me.grdProductos.Rows(fila).Cells("txbUnidadMedida").Value = mdlPublicVars.superSearchUnidadMedida
                    Me.grdProductos.Rows(fila).Cells("valormedida").Value = mdlPublicVars.superSearchUnidadMedidaValor
                    Me.grdProductos.Rows(fila).Cells("txmCosto").Value = mdlPublicVars.superSearchCosto
                End If
            End If

            conn.Close()
        End Using
    End Sub

    Private Sub dtpFechaDocumento_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDocumento.ValueChanged
        Try
            Dim cPro As Integer = CInt(cmbProveedores.SelectedValue)

            If cPro > 0 Then
                Dim pro As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = cPro Select x).FirstOrDefault

                If pro.diasCredito > 0 Then
                    'Calculamos la proxima fehca de pago
                    Dim fechaProx As Date = Me.dtpFechaDocumento.Value
                    fechaProx = fechaProx.AddDays(pro.diasCredito - 1)

                    dtpProxFecha.Value = fechaProx
                Else
                    dtpProxFecha.Value = Today
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
