Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Imports System.IO
Imports System.Data

Imports System.Transactions

Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Imports System.Windows.Forms

Public Class frmImportaciones
    Public tblRetorno As New DataTable
    Public tblCodigos As New DataTable
    Dim listo As Boolean = False

    Private _bitEditarTransito As Boolean
    Private _bitEntrada As Boolean
    Private _bitSalida As Boolean
    Private _bitMovInventario As Boolean
    Private _cliente As Integer
    Public _total1 As Decimal

    Public totalgastos As Decimal

    Public filasgasto As Integer
    Public filasg As Integer

    Public grddatos As RadGridView = Nothing

    Private _bitEditarEntrada As Boolean = False
    Private _bitConvertirTransito As Boolean = False
    Private _bitPreformaToEntrada As Boolean = False
    Private _bitPreformaToTransito As Boolean = False
    Private _preforma As Integer
    Private _codigo As Integer
    Public _compra As Boolean
    Public _entrada As frmEntrada
    Public _bitCrearTransito As Boolean
    Private permiso As New clsPermisoUsuario


    Public Property bitPreformaToEntrada As Boolean
        Get
            bitPreformaToEntrada = _bitPreformaToEntrada
        End Get
        Set(ByVal value As Boolean)
            _bitPreformaToEntrada = value
        End Set
    End Property

    Public Property bitCrearTransito As Boolean
        Get
            bitCrearTransito = _bitCrearTransito
        End Get
        Set(value As Boolean)
            _bitCrearTransito = value
        End Set
    End Property

    Public Property preforma As Integer
        Get
            preforma = _preforma
        End Get
        Set(value As Integer)
            _preforma = value
        End Set
    End Property

    Public Property bitConvertirTransito As Boolean
        Get
            bitConvertirTransito = _bitConvertirTransito
        End Get
        Set(value As Boolean)
            _bitConvertirTransito = value
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


    Public Property bitPreformaToTransito As Boolean
        Get
            bitPreformaToTransito = _bitPreformaToTransito
        End Get
        Set(ByVal value As Boolean)
            _bitPreformaToTransito = value
        End Set
    End Property

    Property bitEditarTransito() As Boolean
        Get
            bitEditarTransito = _bitEditarTransito
        End Get
        Set(ByVal value As Boolean)
            _bitEditarTransito = value
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

    Public Property bitEntrada As Boolean
        Get
            bitEntrada = _bitEntrada
        End Get
        Set(ByVal value As Boolean)
            _bitEntrada = value
        End Set
    End Property

    Public Property bitSalida As Boolean
        Get
            bitSalida = _bitSalida
        End Get
        Set(ByVal value As Boolean)
            _bitSalida = value
        End Set
    End Property

    Public Property bitMovInventario As Boolean
        Get
            bitMovInventario = _bitMovInventario
        End Get
        Set(value As Boolean)
            _bitMovInventario = value
        End Set
    End Property

    Public Property cliente As Integer
        Get
            cliente = _cliente
        End Get
        Set(ByVal value As Integer)
            _cliente = value
        End Set
    End Property

    Public Property total1 As Decimal
        Get
            total1 = _total1
        End Get
        Set(ByVal value As Decimal)
            _total1 = value
        End Set
    End Property
    Private Sub frmproformaimportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listo = False
        bitEntrada = True
        llenarCombos()

        compra = True
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdproductos)
        mdlPublicVars.superSearchNombre = ""
        fnNuevo()

        ''fnActualizar_Total()
        Me.grdproductos.AllowDeleteRow = True

        If bitEditarEntrada = True And bitConvertirTransito = False And bitCrearTransito = False Then
            lbl1Guardar.Text = "Modificar Proforma"
            pnx5transito.Visible = False
            pnx0Nuevo.Visible = False
            pnx2Compra.Visible = False
            pnx1Guardar.Visible = True
            fnLlenarDatos()
        End If

        If bitEditarTransito = True And bitCrearTransito = False Then
            lbl1Guardar.Text = "Modificar Transito"
            pnx5transito.Visible = True

            chkTransito.Visible = True
            fnLlenarDatos()
            chkTransito.Checked = True
        End If

        If bitEditarEntrada = False And bitEditarTransito = False And bitCrearTransito = False Then
            pnx5transito.Visible = False
            pnx3Gasto.Visible = False
            pnx2Compra.Visible = False
        End If

        If bitConvertirTransito And bitEditarEntrada And bitCrearTransito = False Then
            pnx5transito.Visible = True
            pnx1Guardar.Visible = False
            pnx0Nuevo.Visible = False
            pnx2Compra.Visible = False
            pnx1Guardar.Visible = False
            fnLlenarDatos()
        End If

        If bitCrearTransito = True Then
            Try

                pnx5transito.Visible = True
                pnx1Guardar.Visible = False
                pnx0Nuevo.Visible = False
                pnx2Compra.Visible = False
                pnx1Guardar.Visible = False
                lblFechaIngreso.Enabled = True
                dtpFechaIngresoEstimado.Enabled = True

                lblPreforma.Visible = True
                txtPreforma.Visible = True
                txtPreforma.Enabled = False
                cmbProveedores.Enabled = False

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim pre As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                    Me.txtPreforma.Text = CStr(pre.serieDocumento & "-" & pre.documento)
                    Me.cmbProveedores.SelectedValue = pre.idProveedor

                    conn.Close()
                End Using

            Catch ex As Exception

            End Try
        End If

        dtpFechaRegistro.Focus()
        dtpFechaRegistro.Select()
        mdlPublicVars.fnGrid_iconos(grdproductos)

        mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdproductos, "txmCosto")
        mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdproductos, "Total")


        If mdlPublicVars.Entrada_Flete = True Then


            Me.grdproductos.Columns("prorrateo").IsVisible = False
            Me.grdproductos.Columns("costoTotal").IsVisible = False
        Else
            Me.grdproductos.Columns("prorrateo").IsVisible = False
            Me.grdproductos.Columns("costoTotal").IsVisible = False
        End If

        If mdlPublicVars.bitUnidadMedida_Activado = True Then
            Me.grdproductos.Columns("txbUnidadMedida").IsVisible = False
        Else
            Me.grdproductos.Columns("txbUnidadMedida").IsVisible = False
        End If

        listo = True

        fnActualizar_Total()
    End Sub


    Private Sub fnsalir() Handles Me.panel4
        Me.Close()
    End Sub

    Private Sub fncargarpromediotipocambio()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            '-------------------Creamos el encabezado de la compra------------'

            Try
                'Guardamos el codigo de la entrada (idEntrada)

                'actualizar el correlativo.
                If listo = True Then
                    Dim tipocambioq As Double
                    Dim tipocambio2 As Decimal
                    Dim cant As Integer

                    cant = (From x In ctx.tblCajas, y In ctx.tblProveedors Where x.proveedor = y.idProveedor And y.procedencia = 2 _
                        Select x.tipoCambio).Count

                    If cant = 0 Then
                        MsgBox("No existe tipo de cambio para este proveedor, Digítelo Manualmente")
                    Else
                        tipocambioq = (From x In ctx.tblCajas, y In ctx.tblProveedors Where x.proveedor = y.idProveedor And y.procedencia = 2 _
                         Select x.tipoCambio).Sum

                        tipocambio2 = tipocambioq / cant

                        ''nm5Cambio.Value = tipocambio2

                    End If
                End If


            Catch ex As Exception

            End Try
        End Using


    End Sub
    Private Sub llenarCombos()

        Dim movimiento = (From x In ctx.tblTipoMovimientoes Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimientoImportacion _
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

        Dim proveedores = (From x In ctx.tblProveedors Where x.habilitado = True And x.procedencia = 2 Select Codigo = x.idProveedor, Nombre = x.negocio)
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
                         detalle.cantidad, detalle.costoIVA, detalle.idunidadmedida, unidadm.nombre, detalle.valormedida, "0", detalle.costoprorrateo, "0", "0", "0", detalle.cantidad, detalle.costoIVA, "0"}

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

            ElseIf bitPreformaToTransito Then
                Me.grdproductos.Columns("txmCantidad").ReadOnly = True
                Me.grdproductos.Columns("txmCosto").ReadOnly = True
                Me.grdproductos.Columns("txmCodigo").ReadOnly = True
                Me.grdproductos.Columns("txmCantidadCompra").IsVisible = True
                Me.grdproductos.Columns("txmCostoCompra").IsVisible = True
                Me.grdproductos.Columns("TotalCompra").IsVisible = True
                Me.grdproductos.AllowDeleteRow = False

                Me.grdproductos.Columns("txmCantidad").Name = "Cantidad"
                Me.grdproductos.Columns("txmCosto").Name = "Costo"
                Me.grdproductos.Columns("txmCodigo").Name = "Codigo"

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

    Private Sub fnTotales()
        Try
            'lblContadoSi.Text = tblRetorno.Rows.Count
            'lblContadorNo.Text = Me.grdProductos.Rows.Count

        Catch ex As Exception

        End Try
    End Sub


    Private Sub fnguardatransito() Handles Me.panel5
        Try
            ''fnModificarPreformatoTransito()
            ''fnGuardarTransito()
            fnCrearTransito()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCrearTransito()


        If fnErrores(True, False, False) = True Then
            Exit Sub
        End If

        'Esta funcion se utiliza para guardar un Transito
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

                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimientoImportacion _
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
                        correlativoNuevo.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimientoImportacion
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
                    nuevaCompra.FechaIngresoTransito = dtpFechaIngresoEstimado.Text & " " & hora
                    nuevaCompra.fechaTransaccion = fechaServidor
                    nuevaCompra.documento = txtDocumento.Text
                    nuevaCompra.serieDocumento = txtSerie.Text
                    nuevaCompra.observacion = txtObservacion.Text
                    nuevaCompra.anulado = 0
                    nuevaCompra.flete = 0
                    Dim lbtotal As Decimal
                    lbtotal = Replace(lbltotaldolares.Text, "$", "")
                    nuevaCompra.total = CDbl(lbtotal)
                    nuevaCompra.saldo = CDbl(lbtotal)
                    nuevaCompra.pagos = 0
                    nuevaCompra.correlativo = numeroCorrelativo
                    nuevaCompra.cancelado = 0
                    nuevaCompra.anulado = False
                    nuevaCompra.preformaimportacion = False
                    nuevaCompra.Invoice = True
                    nuevaCompra.IdPreformaInvoice = codigo
                    nuevaCompra.nacionalizacion = False


                    'Estados de la compra
                    nuevaCompra.transito = False
                    nuevaCompra.compra = False
                    nuevaCompra.preforma = False

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
                    For index = 0 To Me.grdproductos.Rows.Count - 1
                        'Creamos la fila de detalle
                        idArticulo = Me.grdproductos.Rows(index).Cells("Id").Value
                        cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                        costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                        nombreArticulo = Me.grdproductos.Rows(index).Cells("txbProducto").Value

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

                            Dim inv As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                            inv.transito += cantidad

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
                conexion.AcceptAllChanges()
                listo = False
                fnNuevo()
                ''RadMessageBox.Show("Registro Guardado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                alerta.fnGuardar()
                ''MessageBox.Show("Registro Guardado")
            End If

            'cerrar la conexion()
            conn.Close()
            Me.Close()
            'finalizar el proceso
        End Using
    End Sub

    Private Sub fnGuardarTransito()
        Try
            Try
                'Obtenemos el encabezado de la compra
                Dim compra As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = mdlPublicVars.superSearchId _
                                            Select x).FirstOrDefault
                If compra.anulado = True Then
                    alerta.contenido = "La compra ya a sido anulada"
                    alerta.fnErrorContenido()
                ElseIf compra.compra = True Then
                    alerta.contenido = "La compra ya ha sido confirmada"
                    alerta.fnErrorContenido()
                ElseIf compra.preforma = True And compra.transito = False Then
                    If RadMessageBox.Show("¿Desea pasar la PREFORMA a Transito?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        codigo = compra.idEntrada
                        bitPreformaToEntrada = False
                        bitPreformaToTransito = True
                        bitEditarTransito = True
                        bitEditarEntrada = False

                    End If
                End If
            Catch ex As Exception
            End Try

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
            '' fnActualizar_Total()
            ''fnTotalProrrateo()
            fnActualizar_Total()

            If RadMessageBox.Show("Desea Guardar en Transito?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                Exit Sub
            End If

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                '-------------------Creamos el encabezado de la compra------------'
                Using transaction As New TransactionScope
                    Try
                        'Guardamos el codigo de la entrada (idEntrada)

                        'actualizar el correlativo.
                        Dim numeroCorrelativo As String = 0

                        If Not bitPreformaToTransito Then

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
                        If bitPreformaToTransito Then
                            'Obtenemos la compra
                            nuevaCompra = (From x In conexion.tblEntradas Where x.idEntrada = codigo _
                                           Select x).FirstOrDefault

                            Dim lbtotal As Decimal
                            lbtotal = Replace(lbltotaldolares.Text, "$", "")
                            nuevaCompra.total = CDbl(lbtotal)
                            nuevaCompra.compra = False
                            nuevaCompra.preforma = False
                            nuevaCompra.transito = True
                            nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
                            nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                            nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                            nuevaCompra.documento = txtDocumento.Text
                            nuevaCompra.preforma = False
                            nuevaCompra.serieDocumento = txtSerie.Text
                            nuevaCompra.observacion = txtObservacion.Text
                            nuevaCompra.preformaimportacion = 2
                            ''nuevaCompra.preformatotransito = True
                            nuevaCompra.observacion = Me.txtObservacion.Text
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
                            nuevaCompra.observacion = Me.txtObservacion.Text
                            ''nuevaCompra.preformatotransito = True

                            nuevaCompra.anulado = 0

                            nuevaCompra.total = CDbl(lbltotaldolares.Text)
                            nuevaCompra.saldo = CDbl(lbltotaldolares.Text)
                            nuevaCompra.pagos = 0
                            nuevaCompra.correlativo = numeroCorrelativo
                            nuevaCompra.cancelado = 0
                            nuevaCompra.anulado = False
                            nuevaCompra.fechaCompra = nuevaCompra.fechaRegistro
                            nuevaCompra.compra = True
                            nuevaCompra.preforma = False
                            nuevaCompra.transito = False
                            nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
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
                        End If

                        codigoCompra = nuevaCompra.idEntrada

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
                        For index = 0 To Me.grdproductos.Rows.Count - 1
                            'Creamos la fila de detalle
                            idArticulo = Me.grdproductos.Rows(index).Cells("Id").Value

                            If Not bitPreformaToTransito Then
                                cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                                costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                                costopro = Me.grdproductos.Rows(index).Cells("txmcosto").Value
                                valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                                idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value
                                nuevoprecio = Me.grdproductos.Rows(index).Cells("txmPrecioPublico").Value
                            Else
                                cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                                costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                                costopro = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                                valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                                idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value
                                nuevoprecio = Me.grdproductos.Rows(index).Cells("txmPrecioPublico").Value
                            End If

                            nombreArticulo = Me.grdproductos.Rows(index).Cells("txbProducto").Value

                            Try
                                idDetalle = Me.grdproductos.Rows(index).Cells("idDetalle").Value
                            Catch ex As Exception
                                idDetalle = 0
                            End Try

                            If nombreArticulo IsNot Nothing Then
                                If bitPreformaToTransito Then
                                    'Si se quiere pasar una preforma a entrada

                                    'Obtenemos el costo de compra y cantidad de compra
                                    costoCompra = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                                    cantidadCompra = Me.grdproductos.Rows(index).Cells("txmCantidad").Value

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
                                        inveNuevo.transito = cantidad
                                        conexion.AddTotblInventarios(inveNuevo)
                                        conexion.SaveChanges()
                                    Else

                                        inventario.transito += cantidad
                                        conexion.SaveChanges()
                                    End If

                                    'guardar los cambios
                                    conexion.SaveChanges()

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


                                    ''Finalizo la Actualizacion de Precios para la Compra

                                    'Aumentos las existencias, y entradas en el inventario
                                    Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                       And x.idTipoInventario = nuevaCompra.idtipoInventario And x.IdAlmacen = nuevaCompra.idalmacen _
                                                                       Select x).FirstOrDefault



                                    'Actualizamos la fecha de ultimacompra del articulo
                                    conexion.SaveChanges()

                                    If inventario Is Nothing Then
                                        'crear el registro en inventario.
                                        Dim inveNuevo As New tblInventario

                                        inveNuevo.idInventario = nuevaCompra.idtipoInventario
                                        inveNuevo.IdAlmacen = nuevaCompra.idalmacen
                                        inveNuevo.entrada = cantidad * valmedida
                                        inveNuevo.saldo = cantidad * valmedida
                                        inveNuevo.transito = cantidad
                                        inveNuevo.salida = 0
                                        conexion.AddTotblInventarios(inveNuevo)
                                        conexion.SaveChanges()
                                    Else
                                        'Aumentamos entradas
                                        inventario.transito += cantidad
                                        conexion.SaveChanges()
                                    End If

                                    conexion.SaveChanges()
                                End If
                            End If
                        Next


                        'Aumentamos el saldo del proveedor y establecemos la ultima compra

                        Dim lbtota As Decimal
                        lbtota = Replace(lbltotaldolares.Text, "$", "")
                        Dim idproveedor As Integer = CInt(Me.cmbProveedores.SelectedValue)

                        Dim prov As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = idproveedor Select x).FirstOrDefault

                        prov.saldoDolar += CDbl(lbtota)
                        prov.saldoActual += CDbl(lbtota)

                        conexion.SaveChanges()

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
                    End Try
                End Using
                If success = True Then
                    conexion.AcceptAllChanges()
                    listo = False
                    fnNuevo()
                    ''fnTotalProrrateo()
                    fnActualizar_Total()
                    bitPreformaToEntrada = False
                    bitPreformaToTransito = False
                    RadMessageBox.Show("Convertido exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                End If
                conn.Close()
            End Using


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs)
        'fnActualizar()

        mdlPublicVars.fnFormatoGridMovimientos(grdproductos)
        grdproductos.MasterTemplate.ShowTotals = True
        Dim summary5 As New GridViewSummaryItem("Cantidad", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summary6 As New GridViewSummaryItem("costod", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoMonedaDolarGridTelerik, GridAggregateFunction.Sum)
        Dim summary7 As New GridViewSummaryItem("totald", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summary8 As New GridViewSummaryItem("costoq", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoMonedaDolarGridTelerik, GridAggregateFunction.Sum)
        Dim summary9 As New GridViewSummaryItem("totalq", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)

        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summary5, summary6, summary7, summary8, summary9})
        grdproductos.SummaryRowsTop.Add(summaryRowItem)


        Dim j As Integer
        Dim filas As Integer
        Dim costod As Decimal
        filas = grdproductos.Rows.Count
        For j = 0 To filas - 1
            costod = costod + grdproductos.Rows(j).Cells("txmcosto").Value
        Next
        lbltotaldolares.Text = Format(CDec(costod), mdlPublicVars.formatoMonedaDolar)

    End Sub

    Public Sub fnActualizar_Total()
        lblRecuento.Text = Me.grdproductos.Rows.Count

        Try
            If Me.grdproductos.Rows.Count > 0 Then
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

                For index As Integer = 0 To Me.grdproductos.Rows.Count - 1
                    Dim producto As String = CType(Me.grdproductos.Rows(index).Cells("txbProducto").Value, String)
                    eliminar = CInt(Me.grdproductos.Rows(index).Cells("elimina").Value)
                    If Me.grdproductos.Rows(index).Cells("elimina").Value = "0" Then

                        If producto IsNot Nothing Then

                            If Not bitPreformaToEntrada Then
                                cantidad = CType(Me.grdproductos.Rows(index).Cells("txmCantidad").Value, Double)
                                precio = CType(Me.grdproductos.Rows(index).Cells("txmCosto").Value, Double)

                                ''Prorrateo
                                cantidadp = CType(Me.grdproductos.Rows(index).Cells("txmCantidad").Value, Double)
                                preciop = CType(Me.grdproductos.Rows(index).Cells("costoTotal").Value, Double)
                            Else
                                cantidad = CType(Me.grdproductos.Rows(index).Cells("Cantidad").Value, Double)
                                precio = CType(Me.grdproductos.Rows(index).Cells("Costo").Value, Double)

                                ''Prorrateo
                                cantidadp = CType(Me.grdproductos.Rows(index).Cells("Cantidad").Value, Double)
                                preciop = CType(Me.grdproductos.Rows(index).Cells("costoTotal").Value, Double)
                            End If

                            If (cantidad * precio) = 0 Then
                                Me.grdproductos.Rows(index).Cells("Total").Value = "0"
                            Else
                                If mdlPublicVars.Entrada_Flete = True Then
                                    Me.grdproductos.Rows(index).Cells("Total").Value = Format(cantidadp * preciop, "###,###.##").ToString
                                Else
                                    Me.grdproductos.Rows(index).Cells("Total").Value = Format(cantidad * precio, "###,###.##").ToString
                                End If

                            End If

                            totalPreforma += (cantidad * precio)
                            ''Prorrateo
                            totalPreformap += (cantidadp * preciop)

                            If bitPreformaToEntrada Then
                                costoCompra = CType(Me.grdproductos.Rows(index).Cells("costo").Value, Decimal)
                                cantidadCompra = CType(Me.grdproductos.Rows(index).Cells("Cantidad").Value, Double)

                                If (cantidadCompra * costoCompra) = 0 Then
                                    Me.grdproductos.Rows(index).Cells("TotalCompra").Value = "0"
                                Else
                                    Me.grdproductos.Rows(index).Cells("TotalCompra").Value = Format(cantidadCompra * costoCompra, "###,###.##").ToString
                                End If

                                totalCompra += (costoCompra * cantidadCompra)
                            End If
                        End If
                    End If


                Next



                If bitPreformaToEntrada Then
                    lblSubtotal.Text = Format(totalCompra, mdlPublicVars.formatoMonedaDolar)
                    lbltotaldolares.Text = Format(totalCompra, mdlPublicVars.formatoMonedaDolar)
                Else
                    lblSubtotal.Text = Format(totalPreforma, mdlPublicVars.formatoMonedaDolar)
                    lbltotaldolares.Text = Format(totalPreforma, mdlPublicVars.formatoMonedaDolar)
                End If
            Else

                lbltotaldolares.Text = 0

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
        filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, superSearchCantidad, mdlPublicVars.superSearchPrecio, mdlPublicVars.superSearchIdUnidadMedida, mdlPublicVars.superSearchUnidadMedida, mdlPublicVars.superSearchUnidadMedidaValor, Format(mdlPublicVars.superSearchPrecio, "###,###." & mdlPublicVars.Entrada_numeroDecimales), "0", "0", "0", "0", "0"}
        grdproductos.Rows.Add(filas)
        grdproductos.Columns(3).IsCurrent = True
        grdproductos.Rows(grdproductos.Rows.Count - 1).IsCurrent = True
        ''fnActualizar_Total()
        ''fnTotalProrrateo()
        fnActualizar_Total()
    End Sub

    Private Sub fnTotalProrrateo()

        Try
            Dim flete As Decimal = 0.0
            Dim subtotal As Decimal = 0.0
            Dim filas As Integer = Me.grdproductos.Rows.Count - 1

            subtotal = Replace(Me.lblSubtotal.Text, "$", "")

            For index As Integer = 0 To filas
                Dim totalf As Decimal = 0.0
                Dim cantf As Double = 0
                Dim costf As Decimal = 0.0
                Dim totalgasto As Decimal = 0.0
                Dim gastoprod As Decimal = 0.0
                Dim costoprod As Decimal = 0.0

                If bitPreformaToEntrada = True Then
                    cantf = Me.grdproductos.Rows(index).Cells("Cantidad").Value
                    costf = Me.grdproductos.Rows(index).Cells("Costo").Value
                    totalf = (Me.grdproductos.Rows(index).Cells("Cantidad").Value * Me.grdproductos.Rows(index).Cells("Costo").Value)
                Else
                    cantf = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                    costf = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                    totalf = (Me.grdproductos.Rows(index).Cells("txmCantidad").Value * Me.grdproductos.Rows(index).Cells("txmCosto").Value)
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

                If Me.grdproductos.Rows(index).Cells("txbProducto").Value = "" Then
                    Me.grdproductos.Rows(index).Cells("prorrateo").Value = Nothing
                    Me.grdproductos.Rows(index).Cells("CostoTotal").Value = Nothing
                Else
                    Me.grdproductos.Rows(index).Cells("prorrateo").Value = Format(gastoprod, mdlPublicVars.formatoNumero)
                    Me.grdproductos.Rows(index).Cells("CostoTotal").Value = Format(costoprod, mdlPublicVars.formatoNumero)
                End If
            Next
        Catch

        End Try
    End Sub

    Private Sub fnguardarcompra_click() Handles Me.panel2

        fnGuardarCompra()
    End Sub


    'Funcion utilizada para modificar una compra
    Private Sub fnModificarTransito()


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

                        Dim lbtotal As Decimal
                        lbtotal = Replace(lbltotaldolares.Text, "$", "")
                        nuevaCompra.total = CDbl(lbtotal)
                        'nuevaCompra.total = CDbl(lblTotal.Text)

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
                        For index = 0 To Me.grdproductos.Rows.Count - 1
                            'Creamos la fila de detalle
                            idArticulo = Me.grdproductos.Rows(index).Cells(1).Value
                            cantidad = Me.grdproductos.Rows(index).Cells(4).Value
                            costo = Me.grdproductos.Rows(index).Cells(5).Value
                            nombreArticulo = Me.grdproductos.Rows(index).Cells(3).Value
                            detalle = Me.grdproductos.Rows(index).Cells(0).Value
                            elimina = Me.grdproductos.Rows(index).Cells("elimina").Value
                            valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value

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



                                'Aumentos las existencias, y entradas en el inventario
                                Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idArticulo _
                                                                   And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                   And x.idTipoInventario = nuevaCompra.idtipoInventario And x.IdAlmacen = nuevaCompra.idalmacen _
                                                                   Select x).FirstOrDefault


                                If inventario Is Nothing Then
                                    'crear el registro en inventario.
                                    Dim inveNuevo As New tblInventario

                                    inveNuevo.idInventario = nuevaCompra.idtipoInventario
                                    inveNuevo.IdAlmacen = nuevaCompra.idalmacen
                                    inveNuevo.entrada = cantidad * valmedida
                                    inveNuevo.saldo = cantidad * valmedida
                                    inveNuevo.salida = 0
                                    inveNuevo.transito = cantidad
                                    conexion.AddTotblInventarios(inveNuevo)
                                    conexion.SaveChanges()
                                Else

                                    inventario.transito = cantidad
                                    conexion.SaveChanges()
                                End If

                                'guardar los cambios
                                conexion.SaveChanges()

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
                    fnNuevo()
                End If

                'cerrar la conexion
                conn.Close()

                'finalizar proceso.
            End Using


        End If

    End Sub

    Private Sub fnModificarPreformatoTransito()


        If RadMessageBox.Show("¿Desea guardar los cambios?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

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

                        Dim lbtotal As Decimal
                        lbtotal = Replace(lbltotaldolares.Text, "$", "")
                        nuevaCompra.total = CDbl(lbtotal)
                        nuevaCompra.saldo = nuevaCompra.total - nuevaCompra.pagos
                        'nuevaCompra.total = CDbl(lblTotal.Text)

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
                        For index = 0 To Me.grdproductos.Rows.Count - 1
                            'Creamos la fila de detalle
                            idArticulo = Me.grdproductos.Rows(index).Cells(1).Value
                            cantidad = Me.grdproductos.Rows(index).Cells(4).Value
                            costo = Me.grdproductos.Rows(index).Cells(5).Value
                            nombreArticulo = Me.grdproductos.Rows(index).Cells(3).Value
                            detalle = Me.grdproductos.Rows(index).Cells(0).Value
                            elimina = Me.grdproductos.Rows(index).Cells("elimina").Value
                            valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value

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
                    ''MessageBox.Show("Registro Guardado")
                    alerta.fnGuardar()
                    listo = False
                    ''fnNuevo()
                End If

                'cerrar la conexion
                conn.Close()

                'finalizar proceso.
            End Using

            ''Me.Close()
        End If

    End Sub

    'Funcion utilizada para modificar una compra
    Private Sub fnModificarCompra()


        If RadMessageBox.Show("¿Desea guardar los cambios?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

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

                        Dim lbtotal As Decimal
                        lbtotal = Replace(lbltotaldolares.Text, "$", "")
                        nuevaCompra.total = CDbl(lbtotal)
                        nuevaCompra.saldo = nuevaCompra.total - nuevaCompra.pagos
                        'nuevaCompra.total = CDbl(lblTotal.Text)

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
                        For index = 0 To Me.grdproductos.Rows.Count - 1
                            'Creamos la fila de detalle
                            idArticulo = Me.grdproductos.Rows(index).Cells(1).Value
                            cantidad = Me.grdproductos.Rows(index).Cells(4).Value
                            costo = Me.grdproductos.Rows(index).Cells(5).Value
                            nombreArticulo = Me.grdproductos.Rows(index).Cells(3).Value
                            detalle = Me.grdproductos.Rows(index).Cells(0).Value
                            elimina = Me.grdproductos.Rows(index).Cells("elimina").Value
                            valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value

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
                    ''MessageBox.Show("Registro Guardado")
                    alerta.fnGuardar()
                    listo = False
                    fnNuevo()
                End If

                'cerrar la conexion
                conn.Close()

                'finalizar proceso.
            End Using

            Me.Close()
        End If

    End Sub


    Private Sub fngastos_Click() Handles Me.panel3

        frmgastosimportacion.Text = "Gastos"
        frmgastosimportacion.StartPosition = FormStartPosition.CenterScreen
        frmgastosimportacion.ShowDialog()
        frmgastosimportacion.Dispose()
        ''lbltgastos.Text = 0
        ''lbltgastos.Text = Format(CDec(totalgastos), mdlPublicVars.formatoMoneda)
        filasgasto = frmgastosimportacion.filas
        filasg = filasgasto



    End Sub

    ''Private Sub lblSubtotal_TextChanged(sender As Object, e As EventArgs)

    ''    ''lblTotaldolares.Text = CDec(If(Me.lblSubtotal.Text = "", 0, CDec(Me.lblSubtotal.Text)) + If(Me.lbltgastos.Text = "", 0, CDec(Me.lbltgastos.Text)))

    ''End Sub

    ''Private Sub lbltgastos_TextChanged(sender As Object, e As EventArgs)

    ''    'lblTotal.Text = CDec(If(Me.lblSubtotal.Text = "", 0, CDec(Me.lblSubtotal.Text)) + If(Me.lbltgastos.Text = "", 0, CDec(Me.lbltgastos.Text)))
    ''    lblTotal.Text = Format(CDec(If(Me.lblSubtotal.Text = "", 0, CDec(Me.lblSubtotal.Text)) + If(Me.lbltgastos.Text = "", 0, CDec(Me.lbltgastos.Text))), mdlPublicVars.formatoMoneda)


    ''End Sub

    Private Sub lbltotaldolares_TextChanged(sender As Object, e As EventArgs)
        Dim subtotal As Decimal
        Dim gastos As Decimal
        If lbltotaldolares.Text = "" Then
        Else
            subtotal = Replace(Me.lblSubtotal.Text, "$", "")
            ''gastos = Replace(Me.lbltgastos.Text, "Q", "")
            ''lblTotal.Text = Format(CDec(If(subtotal = 0, 0, CDec(subtotal))) + CDec(If(gastos = 0, 0, CDec(gastos))), mdlPublicVars.formatoMoneda)

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            frmImportarImportaciones.Text = "Importar"
            frmImportarImportaciones.bitEntrada = True
            frmImportarImportaciones.ShowDialog()

            Dim tblR As DataTable = frmImportarImportaciones.tblRetorno
            frmImportarImportaciones.Dispose()
            If tblR.Rows.Count > 0 Then

                'buscar fila con id en blanco.
                Dim filaBlanco As Integer = -1

                Dim index
                For index = 0 To Me.grdproductos.Rows.Count - 1
                    If Me.grdproductos.Rows(index).Cells(1).Value Is Nothing Then
                        Me.grdproductos.Rows.RemoveAt(index)
                    ElseIf LTrim(RTrim(Me.grdproductos.Rows(index).Cells(1).Value.ToString)).Length = 0 Then
                        filaBlanco = index
                    ElseIf LTrim(RTrim(Me.grdproductos.Rows(index).Cells(1).Value.ToString)).Length = 1 And LTrim(RTrim(Me.grdproductos.Rows(index).Cells(1).Value.ToString)) = 0 Then
                        filaBlanco = index
                    End If
                Next

                Dim inicio As Integer = 0

                If filaBlanco = -1 Then
                Else
                    'agregar al grid si nueva fila.
                    Me.grdproductos.Rows(filaBlanco).Cells(1).Value = tblR.Rows(0).Item(0)
                    Me.grdproductos.Rows(filaBlanco).Cells(2).Value = tblR.Rows(0).Item(1)
                    Me.grdproductos.Rows(filaBlanco).Cells(3).Value = tblR.Rows(0).Item(2)
                    Me.grdproductos.Rows(filaBlanco).Cells(4).Value = tblR.Rows(0).Item(3)
                    Me.grdproductos.Rows(filaBlanco).Cells(5).Value = tblR.Rows(0).Item(4)
                    Me.grdproductos.Rows(filaBlanco).Cells(6).Value = tblR.Rows(0).Item(5)

                    inicio = 1
                End If

                'agregar los elementos restantes al grid.
                For index = inicio To tblR.Rows.Count - 1
                    Me.grdproductos.Rows.Add("", tblR.Rows(index).Item(0), tblR.Rows(index).Item(1), tblR.Rows(index).Item(2), tblR.Rows(index).Item(3), tblR.Rows(index).Item(4), tblR.Rows(index).Item(5), 0, 0, 0, 0, 0, tblR.Rows(index).Item(3) * tblR.Rows(index).Item(4), "0", 0, 0, 0, tblR.Rows(index).Item(7))
                Next


                Dim j As Integer
                Dim filas As Integer
                Dim costod As Decimal
                Dim cantidad As Integer
                filas = grdproductos.Rows.Count - 1

                For m As Integer = 0 To filas
                    costod = grdproductos.Rows(m).Cells("Total").Value

                    Dim lbtotaldolares As Decimal
                    lbtotaldolares = Replace(lbltotaldolares.Text, "$", "")
                    'lbltotaldolares.Text = lbltotaldolares.Text + costod
                    lbltotaldolares.Text = Format(CDec(If(lbtotaldolares = 0, 0, CDec(lbtotaldolares))) + (CDec(grdproductos.Rows(m).Cells("Total").Value)), mdlPublicVars.formatoMonedaDolar)

                    ''''fnTotalProrrateo()
                    fnActualizar_Total()
                    ''Me.grdproductos.Rows.AddNew()

                Next
                fnEliminaVacias()
                Me.grdproductos.Rows.AddNew()
            End If
        Catch ex As Exception
        End Try
    End Sub

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
                    Dim lbtotal As Decimal
                    lbtotal = Replace(lbltotaldolares.Text, "$", "")
                    nuevaCompra.total = CDbl(lbtotal)
                    nuevaCompra.saldo = CDbl(lbtotal)
                    nuevaCompra.pagos = 0
                    nuevaCompra.correlativo = numeroCorrelativo
                    nuevaCompra.cancelado = 0
                    nuevaCompra.anulado = False
                    nuevaCompra.preformaimportacion = 1
                    nuevaCompra.IdPreformaInvoice = 0
                    nuevaCompra.nacionalizacion = False
                    nuevaCompra.Invoice = False
                    nuevaCompra.IdInvoiceNacionalizacion = 0
                    nuevaCompra.finalizada = 0


                    'Estados de la compra
                    nuevaCompra.transito = False
                    nuevaCompra.compra = False
                    nuevaCompra.preforma = False

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
                    For index = 0 To Me.grdproductos.Rows.Count - 1
                        'Creamos la fila de detalle
                        idArticulo = Me.grdproductos.Rows(index).Cells("Id").Value
                        cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                        costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                        nombreArticulo = Me.grdproductos.Rows(index).Cells("txbProducto").Value

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

                            Dim art As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idArticulo Select x).FirstOrDefault

                            art.CostoDolar = costo

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
                conexion.AcceptAllChanges()
                listo = False
                fnNuevo()
                ''MessageBox.Show("Registro Guardado")
                alerta.fnGuardar()

            End If
            'cerrar la conexion()
            conn.Close()
            Me.Close()
            'finalizar el proceso
        End Using
    End Sub

    Private Sub fnArticulo_informacion()
        Try
            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdproductos)
            Dim codigo As String = Me.grdproductos.Rows(index).Cells("id").Value.ToString

            If IsNumeric(codigo) Then
                If CType(codigo, Integer) > 0 Then
                    Dim datos = ctx.sp_CadenaCompatibilidad(codigo, mdlPublicVars.General_idTipoInventario)
                    For Each fila As sp_CadenaCompatibilidad_Result In datos
                        lblObservacion.Text = fila.Obs
                        lblSaldo.Text = fila.Saldo
                        lbltransito.Text = fila.transito
                        lblCompatibilidad.Text = fila.Compatibilidad
                    Next
                Else
                    lblObservacion.Text = ""
                    lblSaldo.Text = 0
                    lbltransito.Text = 0
                End If
            Else
                lblObservacion.Text = ""
                lblSaldo.Text = 0
                lblCompatibilidad.Text = ""
                lbltransito.Text = 0
            End If
        Catch ex As NullReferenceException
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            lblObservacion.Text = ""
            lblCompatibilidad.Text = ""
            lblSaldo.Text = 0
            lbltransito.Text = 0
        End Try
    End Sub


    Private Sub txtFlete_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If Me.grdproductos.Rows.Count - 1 > 0 Then
                ''fnTotalProrrateo()
                fnActualizar_Total()
            End If
        End If
    End Sub

    Private Sub grdproductos_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles grdproductos.CellEndEdit
        Dim j As Integer
        Dim filas As Integer
        Dim costod As Decimal
        Dim cantidad As Integer
        filas = grdproductos.Rows.Count - 1
        Dim lbsubtotal As Decimal
        Dim lbtotal As Decimal
        Dim lbgastos As Decimal
        Dim lbtotaldolares As Decimal

        lbsubtotal = Replace(lblSubtotal.Text, "$", "")
        ''lbtotal = Replace(lblTotal.Text, "Q", "")
        ''lbgastos = Replace(lbltgastos.Text, "Q", "")
        lbtotaldolares = Replace(lbltotaldolares.Text, "$", "")
        Dim fila2 = CType(Me.grdproductos.CurrentColumn.Index, Integer)

        If CType(Me.grdproductos.CurrentColumn.Index, Integer) = 4 Or CType(Me.grdproductos.CurrentColumn.Index, Integer) = 8 Then
            lbtotaldolares = 0

            Dim fila As Integer = CType(Me.grdproductos.CurrentRow.Index, Integer)
            costod = grdproductos.Rows(fila).Cells("txmcosto").Value
            'lbltotaldolares.Text = lbltotaldolares.Text + costod
            cantidad = grdproductos.Rows(fila).Cells("txmCantidad").Value
            grdproductos.Rows(fila).Cells("Total").Value = costod * cantidad

            For x As Integer = 0 To filas
                lbtotaldolares = CDec(If(lbtotaldolares = 0, 0, CDec(lbtotaldolares))) + (If(grdproductos.Rows(x).Cells("Total").Value = "", 0, CDec(grdproductos.Rows(x).Cells("Total").Value)))
                lbltotaldolares.Text = Format(CDec(lbtotaldolares), mdlPublicVars.formatoMonedaDolar)
            Next
        End If
        fnActualizar_Total()
    End Sub

    Private Sub grdproductos_SelectionChanged(sender As Object, e As EventArgs) Handles grdproductos.SelectionChanged
        fnArticulo_informacion()
    End Sub

    Public Sub fn_grabaRegistro()
        Dim entradas As Integer
        Dim identrada5 As Long
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim success As Boolean = True
            Dim m As New tblgastosimportacion

            Dim e = (From x In conexion.tblEntradas Select x.idEntrada).Max

            identrada5 = e + 1


            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope
                'inicio de excepcion
                Dim consulta As String
                Try
                    Dim totalgasto As Decimal
                    Dim filas2 As Integer
                    filas2 = Me.grdproductos.Rows.Count - 1
                    For y As Integer = 0 To filas2
                        totalgasto = totalgasto + frmgastosimportacion.grdproductos.Rows(y).Cells("txmMonto").Value
                    Next

                    m.fechagasto = Today.ToString
                    m.idusuario = mdlPublicVars.idUsuario
                    m.totalgasto = totalgasto


                    conexion.AddTotblgastosimportacions(m)
                    conexion.SaveChanges()

                    Dim filas = frmgastosimportacion.grdproductos.Rows.Count - 1
                    Dim idgasto As Integer
                    Dim idrubro As Integer
                    Dim monto As Decimal


                    idgasto = m.idgasto


                    For x As Integer = 0 To filas
                        Dim d As New tblgastosimportaciondetalle
                        idrubro = frmgastosimportacion.grdproductos.Rows(x).Cells("idrubro").Value

                        monto = frmgastosimportacion.grdproductos.Rows(x).Cells("txmMonto").Value
                        d.idrubro = idrubro
                        d.idgasto = idgasto
                        d.monto = monto
                        conexion.AddTotblgastosimportaciondetalles(d)
                        conexion.SaveChanges()
                    Next

                    'completar la transaccion.
                    success = True
                    transaction.Complete()
                    MsgBox("Guardado")
                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)

                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True Then
                ctx.AcceptAllChanges()


            Else

                Console.WriteLine("La operacion no pudo ser completada")
            End If
        End Using
    End Sub

    Private Sub fnGuardarCompra()

        Dim success As Boolean = True
        Dim transito As Boolean

        Dim fechaServidor As DateTime = fnFecha_horaServidor()
        Dim hora As String = mdlPublicVars.fnHoraServidor

        Dim contado As Boolean = False
        Dim costoflete As Boolean = False
        Dim codigoProveedor As Integer = 0

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            '-------------------Creamos el encabezado de la compra------------'
            Using transaction As New TransactionScope
                Try

                    'Obtenemos el encabezado de la compra
                    Dim compra As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = mdlPublicVars.superSearchId _
                                                Select x).FirstOrDefault

                    If compra.anulado = True Then
                        alerta.contenido = "La compra ya a sido anulada"
                        alerta.fnErrorContenido()
                    ElseIf compra.compra = True Then
                        alerta.contenido = "La compra ya ha sido confirmada"
                        alerta.fnErrorContenido()
                    ElseIf compra.preforma = True And compra.transito = False Then
                        If RadMessageBox.Show("¿Desea pasar la PREFORMA a COMPRA?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            codigo = compra.idEntrada
                            transito = compra.transito

                            If transito = True Then
                                bitPreformaToTransito = True
                                bitEditarTransito = True
                            Else

                                bitPreformaToEntrada = True
                                bitEditarEntrada = True

                            End If

                        End If
                    ElseIf compra.preforma = False And compra.transito = True Then
                        If RadMessageBox.Show("¿Desea pasar de Transito a COMPRA?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            codigo = compra.idEntrada
                            transito = compra.transito

                            If transito = True Then
                                bitPreformaToTransito = True
                                bitEditarTransito = True
                            Else

                                bitPreformaToEntrada = True
                                bitEditarEntrada = True

                            End If

                        End If
                    End If

                    Dim codigoCompra As Integer = 0
                    If fnErrores(False, True, False) = True Then
                        Exit Sub
                    End If

                    ''fnActualizar_Total()
                    ''fnTotalProrrateo()
                    fnActualizar_Total()

                    If RadMessageBox.Show("Desea Guardar la Compra", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                        Exit Sub
                    End If


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

                    ElseIf Not bitPreformaToTransito Then
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
                    If bitPreformaToEntrada Then
                        'Obtenemos la compra
                        nuevaCompra = (From x In conexion.tblEntradas Where x.idEntrada = codigo _
                                       Select x).FirstOrDefault
                        nuevaCompra.total = CDbl(lbltotaldolares.Text)
                        nuevaCompra.fechaCompra = fechaServidor
                        nuevaCompra.compra = True
                        nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
                        nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                        nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                        nuevaCompra.documento = txtDocumento.Text
                        nuevaCompra.preforma = False
                        nuevaCompra.preformaimportacion = 0
                        nuevaCompra.serieDocumento = txtSerie.Text
                        nuevaCompra.observacion = txtObservacion.Text
                        conexion.SaveChanges()

                    ElseIf bitPreformaToTransito Then

                        'Obtenemos la compra
                        nuevaCompra = (From x In conexion.tblEntradas Where x.idEntrada = codigo _
                                       Select x).FirstOrDefault


                        Dim lbtotal As Decimal
                        lbtotal = Replace(lbltotaldolares.Text, "$", "")
                        nuevaCompra.total = CDbl(lbtotal)

                        nuevaCompra.fechaCompra = fechaServidor
                        nuevaCompra.compra = True
                        nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
                        nuevaCompra.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                        nuevaCompra.idProveedor = cmbProveedores.SelectedValue
                        nuevaCompra.documento = txtDocumento.Text
                        nuevaCompra.preforma = False
                        nuevaCompra.transito = False
                        nuevaCompra.preformaimportacion = 0
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


                        nuevaCompra.total = CDbl(lbltotaldolares.Text)
                        nuevaCompra.saldo = CDbl(lbltotaldolares.Text)
                        nuevaCompra.pagos = 0
                        nuevaCompra.correlativo = numeroCorrelativo
                        nuevaCompra.cancelado = 0
                        nuevaCompra.anulado = False
                        nuevaCompra.fechaCompra = nuevaCompra.fechaRegistro
                        nuevaCompra.compra = True
                        nuevaCompra.preforma = False
                        nuevaCompra.transito = False
                        nuevaCompra.preformaimportacion = 0
                        nuevaCompra.usuarioCompra = mdlPublicVars.idUsuario
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
                    End If


                    codigoCompra = nuevaCompra.idEntrada




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
                    For index = 0 To Me.grdproductos.Rows.Count - 1
                        'Creamos la fila de detalle
                        idArticulo = Me.grdproductos.Rows(index).Cells("Id").Value

                        If idArticulo.ToString Is Nothing Or idArticulo = 0 Then
                            Exit For
                        End If

                        If Not bitPreformaToEntrada Then
                            cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                            costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                            costopro = Me.grdproductos.Rows(index).Cells("txmcosto").Value
                            valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value
                            nuevoprecio = Me.grdproductos.Rows(index).Cells("txmPrecioPublico").Value
                        ElseIf Not bitPreformaToTransito Then
                            cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                            costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                            costopro = Me.grdproductos.Rows(index).Cells("txmcosto").Value
                            valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value
                            nuevoprecio = Me.grdproductos.Rows(index).Cells("txmPrecioPublico").Value

                        Else
                            cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                            costo = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                            costopro = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                            valmedida = Me.grdproductos.Rows(index).Cells("valormedida").Value
                            idmedida = Me.grdproductos.Rows(index).Cells("idmedida").Value
                            nuevoprecio = Me.grdproductos.Rows(index).Cells("txmPrecioPublico").Value
                        End If

                        nombreArticulo = Me.grdproductos.Rows(index).Cells("txbProducto").Value

                        Try
                            idDetalle = Me.grdproductos.Rows(index).Cells("idDetalle").Value
                        Catch ex As Exception
                            idDetalle = 0
                        End Try



                        If nombreArticulo IsNot Nothing Then
                            If bitPreformaToEntrada Then
                                'Si se quiere pasar una preforma a entrada

                                'Obtenemos el costo de compra y cantidad de compra
                                costoCompra = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                                cantidadCompra = Me.grdproductos.Rows(index).Cells("txmCantidad").Value


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
                                    inventario.transito = inventario.transito - cantidadCompra
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

                            ElseIf bitPreformaToTransito Then
                                'Si se quiere pasar una preforma a entrada

                                'Obtenemos el costo de compra y cantidad de compra
                                costoCompra = Me.grdproductos.Rows(index).Cells("txmCosto").Value
                                cantidadCompra = Me.grdproductos.Rows(index).Cells("txmCantidad").Value


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
                                    inveNuevo.transito = inveNuevo.transito - cantidadCompra
                                    inveNuevo.salida = 0
                                    conexion.AddTotblInventarios(inveNuevo)
                                    conexion.SaveChanges()
                                Else
                                    'Aumentamos entradas
                                    inventario.entrada = inventario.entrada + cantidadCompra * valmedida
                                    'Aumentamos saldo
                                    inventario.saldo = inventario.saldo + cantidadCompra * valmedida
                                    inventario.transito = inventario.transito - cantidadCompra
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
                        proveedor.saldoDolar = nuevaCompra.total
                    Else
                        proveedor.saldoActual += nuevaCompra.total
                        proveedor.saldoDolar += nuevaCompra.total
                    End If
                    proveedor.ultimaCompra = nuevaCompra.fechaRegistro

                    conexion.SaveChanges()




                    Dim entradas As Integer
                    Dim identrada5 As Long

                    Dim m As New tblgastosimportacion

                    Dim e = (From x In conexion.tblEntradas Select x.idEntrada).Max

                    'inicio de excepcion
                    Dim consulta As String

                    Dim totalgasto As Decimal
                    Dim filas2 As Integer
                    filas2 = mdlPublicVars.supergridview.Rows.Count - 1
                    For y As Integer = 0 To filas2
                        totalgasto = totalgasto + mdlPublicVars.supergridview.Rows(y).Cells("txmMonto").Value
                    Next

                    m.fechagasto = Today.ToString
                    m.idusuario = mdlPublicVars.idUsuario
                    m.totalgasto = totalgasto
                    m.identrada = codigoCompra

                    conexion.AddTotblgastosimportacions(m)
                    conexion.SaveChanges()

                    Dim filas = mdlPublicVars.supergridview.Rows.Count - 1
                    Dim idgasto As Integer
                    Dim idrubro As Integer
                    Dim monto As Decimal


                    idgasto = m.idgasto


                    For x As Integer = 0 To filas
                        Dim d As New tblgastosimportaciondetalle
                        idrubro = mdlPublicVars.supergridview.Rows(x).Cells("idrubro").Value

                        monto = mdlPublicVars.supergridview.Rows(x).Cells("txmMonto").Value
                        d.idrubro = idrubro
                        d.idgasto = idgasto
                        d.monto = monto
                        conexion.AddTotblgastosimportaciondetalles(d)
                        conexion.SaveChanges()
                    Next









                    ''AQUI TENEMOS QUE COLOCAR LAS OPRACIONES DE LOS IMPUESTOS

                    ''-----********------------IMPUESTOS-*-*-*-*--*-*-------------------**************
                    If Activar_Impuestos = True Then
                        Dim totalcon As Decimal
                        totalcon = CDec(Replace(lbltotaldolares.Text, "$", "").Trim)

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
                End Try
            End Using
            If success = True Then

                'frmgastosimportacion.fn_grabaRegistro()
                conexion.AcceptAllChanges()
                listo = False
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
                If RadMessageBox.Show("Desea realizar un pago al proveedor", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    Dim prov As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codigoProveedor Select x).FirstOrDefault
                    frmPagoNuevo.Text = "Pagos"
                    frmPagoNuevo.bitProveedor = True
                    frmPagoNuevo.codigoCP = prov.idProveedor
                    frmPagoNuevo.lblSaldo.Text = prov.saldoActual
                    frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoFrmEspeciales(frmPagoNuevo, False)
                End If
            End If
        End If
    End Sub

    Public Sub fnNuevaFila()
        fnEliminaVacias()
        Me.grdproductos.Rows.AddNew()
    End Sub

    Private Sub fnEstablecerCorrelativo()
        'Buscamos el correlativo en la tabla correlativo...
        Dim empresa As tblEmpresa = (From x In ctx.tblEmpresas Select x).First


        If empresa.nombre = "Motriza" Then
            Dim Correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos _
                                  Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimientoImportacionmotriza And x.idEmpresa = mdlPublicVars.idEmpresa _
                                  Select x).First
            Me.txtCorrelativo.Text = CStr(Correlativo.correlativo + 1)
        Else
            Dim Correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos _
                                            Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimientoImportacion And x.idEmpresa = mdlPublicVars.idEmpresa _
                                            Select x).First
            Me.txtCorrelativo.Text = CStr(Correlativo.correlativo + 1)
        End If
    End Sub

    Private Sub fnEliminaVacias()
        Try
            If Me.grdproductos.Rows.Count > 0 Then
                'Recorremos el grid
                Dim nombre As String = ""
                For i As Integer = 0 To Me.grdproductos.Rows.Count - 1
                    'Obtenemo el valor del nombre
                    nombre = Me.grdproductos.Rows(i).Cells("txbProducto").Value
                    If IsNothing(nombre) Then
                        Me.grdproductos.Rows.RemoveAt(i)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function fnErrores(bitCrearProforma As Boolean, bitCrearCompra As Boolean, bitModificarProforma As Boolean) As Boolean

        Dim producto As String
        Dim filas As Integer = 0
        For i As Integer = 0 To Me.grdproductos.Rows.Count - 1
            producto = Me.grdproductos.Rows(i).Cells("txbProducto").Value

            If producto IsNot Nothing Then
                filas += 1
            End If
        Next

        If Me.grdproductos.RowCount = 0 Then
            alerta.contenido = "Debe agregar productos a la compra"
            alerta.fnErrorContenido()

            Me.grdproductos.Focus()
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
        For index = 0 To Me.grdproductos.Rows.Count - 1

            Dim art As String = Me.grdproductos.Rows(index).Cells(3).Value

            If art IsNot Nothing Then

                If bitPreformaToEntrada Then
                    cantidad = Me.grdproductos.Rows(index).Cells("txmCantidadCompra").Value
                Else
                    cantidad = Me.grdproductos.Rows(index).Cells("txmCantidad").Value
                End If

                If cantidad <= 0 Then
                    MessageBox.Show("Debe ingresar una cantidad al Articulo : " & Me.grdproductos.Rows(index).Cells("txbProducto").Value & " (" & Me.grdproductos.Rows(index).Cells("txbProducto").Value & " )", mdlPublicVars.nombreSistema)
                    Return True
                    Exit Function
                End If
            End If
        Next
        Return False
    End Function
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdproductos.KeyDown
        If verRegistro = True Then
            Exit Sub
        End If


        Try

            If e.KeyCode = Keys.Enter Then
                fnActualizar_Total()
            End If
            If bitEditarEntrada And Not bitPreformaToEntrada Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdproductos, "iddetalle")
                ''fnTotalProrrateo()
                fnActualizar_Total()
            End If
            If e.KeyCode = Keys.F2 Then
                If Me.grdproductos.Columns("txbunidadmedida").IsCurrent Then
                    mdlPublicVars.superSearchId = 0
                    mdlPublicVars.superSearchNombre = ""
                    fnConcepto()
                    fnActualizar_Total()
                ElseIf IsNumeric(cmbProveedores.SelectedValue) Then
                    If CInt(cmbProveedores.SelectedValue > 0) Then
                        frmBuscarArticuloDolar.StartPosition = FormStartPosition.CenterScreen
                        frmBuscarArticuloDolar.OpcionRetorno = "entrada"
                        frmBuscarArticuloDolar.Text = "Buscar Articulos"
                        frmBuscarArticuloDolar.codClie = cmbProveedores.SelectedValue
                        frmBuscarArticuloDolar.bitCliente = False
                        frmBuscarArticuloDolar.idInventario = mdlPublicVars.General_idTipoInventario
                        frmBuscarArticuloDolar.idBodega = mdlPublicVars.General_idAlmacenPrincipal
                        frmBuscarArticuloDolar.bitProveedor = True
                        frmBuscarArticuloDolar.bitProformaImportacion = True
                        frmBuscarArticuloDolar.venta = 0
                        permiso.PermisoFrmEspeciales(frmBuscarArticuloDolar, False)
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

            Dim j As Integer
            Dim filas As Integer
            Dim costod As Decimal
            filas = grdproductos.Rows.Count


            'For j = 0 To filas - 1
            '    costod = CDec(grdproductos.Rows(j).Cells("txmcosto").Value)
            '    lbltotaldolares.Text = lbltotaldolares.Text + costod


            'Next

            'If CType(Me.grdproductos.CurrentColumn.Index, Integer) = 5 Or CType(Me.grdproductos.CurrentColumn.Index, Integer) = 8 Then
            '    Dim fila As Integer = CType(Me.grdproductos.CurrentRow.Index, Integer)
            '    costod = grdproductos.Rows(fila).Cells("txmcosto").Value
            '    'lbltotaldolares.Text = lbltotaldolares.Text + costod

            '    lbltotaldolares.Text = CDec(If(Me.lbltotaldolares.Text = "", 0, CDec(Me.lbltotaldolares.Text)) + If(costod = 0, 0, CDec(costod)))
            '    cantidad = grdproductos.Rows(fila).Cells("txmCantidad").Value

            '    grdproductos.Rows(fila).Cells("Total").Value = costod * cantidad
            'End If

            ''If e.KeyCode = Keys.Delete Then
            ''    Try

            ''        If Me.grdproductos.Rows.Count = 0 Then
            ''            Me.grdproductos.Rows.AddNew()
            ''            cmbProveedores.Enabled = True
            ''        Else
            ''            fnAgregarFilaBlanco()
            ''        End If

            ''        fnBloquearCombo()
            ''        ''fnTotalProrrateo()
            ''        fnActualizar_Total()
            ''    Catch ex As Exception

            ''    End Try
            ''End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdproductos.UserDeletedRow
        Try

            If Me.grdproductos.Rows.Count = 0 Then
                Me.grdproductos.Rows.AddNew()
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

        For index = 0 To Me.grdproductos.Rows.Count - 1

            If Me.grdproductos.Rows(index).Cells(1).Value Is Nothing Then
                filaBlanco = True
            ElseIf LTrim(RTrim(Me.grdproductos.Rows(index).Cells(1).Value)).ToString.Length = 0 Then
                filaBlanco = True
            End If
        Next

        If filaBlanco = False Then
            Me.grdproductos.Rows.AddNew()
        End If
    End Sub

    'Funcion utilizada para bloquear cliente
    Public Sub fnBloquearCombo()
        Try
            'Obtenemos  el numero de filas
            Dim filas As Integer = CInt(Me.grdproductos.Rows.Count)

            If filas > 1 Then
                cmbProveedores.Enabled = False
            ElseIf filas = 1 Then
                'Verificamos si tiene informacion la fila
                Dim nombre As String = ""
                Try
                    nombre = Me.grdproductos.Rows(0).Cells(3).Value
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


    Private Sub fnNuevo()
        listo = False
        Try
            llenarCombos()
            fnEstablecerCorrelativo()
            Me.grdproductos.AllowDeleteRow = True
            dtpFechaRegistro.Enabled = True
            cmbProveedores.Enabled = True
            cmbMovimiento.Enabled = False
            txtDocumento.Text = ""
            txtDocumento.Enabled = True

            lblSubtotal.Text = "0"
            ''lblTotal.Text = "0"
            lbltotaldolares.Text = "0"
            ''lbltgastos.Text = "0"

            txtObservacion.Text = ""
            txtSerie.Text = ""
            dtpFechaRegistro.Text = Format(Now, mdlPublicVars.formatoFecha).ToString


            Me.grdproductos.Rows.Clear()

            If bitEditarEntrada = False Then
                fnNuevaFila()
            End If

            If verRegistro = True Then
                txtDocumento.Enabled = False
                cmbProveedores.Enabled = False
                pnx0Nuevo.Visible = False

            End If

            Me.grdproductos.Columns(4).ReadOnly = False
            Me.grdproductos.Columns(5).ReadOnly = False
            Me.grdproductos.Columns("txmCantidadCompra").IsVisible = False
            Me.grdproductos.Columns("txmCostoCompra").IsVisible = False
            Me.grdproductos.Columns("TotalCompra").IsVisible = False

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema)
        End Try

    End Sub

    ''Private Sub nm5Cambio_ValueChanged_1(sender As Object, e As EventArgs)

    ''    Dim lbsubtotal As Decimal
    ''    Dim lbtotal As Decimal
    ''    Dim lbgastos As Decimal
    ''    Dim lbtotaldolares As Decimal
    ''    lbsubtotal = Replace(lblSubtotal.Text, "Q", "")
    ''    lbtotal = Replace(lblTotal.Text, "Q", "")
    ''    lbgastos = Replace(lbltgastos.Text, "Q", "")
    ''    lbtotaldolares = Replace(lbltotaldolares.Text, "$", "")


    ''    Dim totaldolares As Decimal
    ''    If lbltotaldolares.Text = "" Then
    ''        totaldolares = 0
    ''    Else
    ''        totaldolares = lbtotaldolares
    ''    End If
    ''    lblSubtotal.Text = Format(CDec(totaldolares) * Convert.ToDecimal(nm5Cambio.Value).ToString, mdlPublicVars.formatoMoneda)
    ''    lbsubtotal = Replace(lblSubtotal.Text, "Q", "")
    ''    lblTotal.Text = Format(CDec(If(lbsubtotal = 0, 0, CDec(lbsubtotal))) + If(lbgastos = 0, 0, CDec(lbgastos)), mdlPublicVars.formatoMoneda)

    ''End Sub

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
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdproductos)

            articulo = CType(Me.grdproductos.Rows(fila).Cells("id").Value, Integer)

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
                    Me.grdproductos.Rows(fila).Cells("idmedida").Value = mdlPublicVars.superSearchIdUnidadMedida
                    Me.grdproductos.Rows(fila).Cells("txbUnidadMedida").Value = mdlPublicVars.superSearchUnidadMedida
                    Me.grdproductos.Rows(fila).Cells("valormedida").Value = mdlPublicVars.superSearchUnidadMedidaValor
                    Me.grdproductos.Rows(fila).Cells("txmCosto").Value = mdlPublicVars.superSearchCosto
                End If
            End If

            conn.Close()
        End Using
    End Sub


    Private Sub lbltotaldolares_TextChanged1(sender As Object, e As EventArgs) Handles lbltotaldolares.TextChanged
        'lblSubtotal.Text = lbltotaldolares.Text * Convert.ToDecimal(nm5Cambio.Value).ToString

        Dim lbtotaldolares As Double
        Dim lbgastos As Double
        Dim lbsubtotal As Double

        lbtotaldolares = Replace(lbltotaldolares.Text, "$", "")
        ''lbgastos = Replace(lbltgastos.Text, "Q", "")
        lbsubtotal = Replace(lblSubtotal.Text, "$", "")

        lblSubtotal.Text = Format(CDec(If(lbtotaldolares = 0, 0, CDec(lbtotaldolares))), mdlPublicVars.formatoMonedaDolar)

        lbsubtotal = Replace(lblSubtotal.Text, "$", "")
        ''lbgastos = Replace(lbltgastos.Text, "Q", "")

        ''lblTotal.Text = Format(CDec(If(lbsubtotal = 0, 0, CDec(lbsubtotal))) + If(lbgastos = 0, 0, CDec(lbgastos)), mdlPublicVars.formatoMoneda)
    End Sub

    Private Sub GuardarProforma() Handles Me.panel1
        If lbl1Guardar.Text = "Modificar Proforma" Then
            fnModificarCompra()
        ElseIf lbl1Guardar.Text = "Modificar Transito" Then
            fnModificarTransito()
        Else
            fnGuardarPreforma()
        End If
    End Sub


    Private Sub cmbProveedores_SelectedvalueChanged(sender As Object, e As EventArgs) Handles cmbProveedores.SelectedValueChanged

        If listo = True Then
            fncargarpromediotipocambio()
        End If

    End Sub

    'Funcion que se utiliza para remover la fila actual
    Public Sub fnRemoverFila()
        Dim filaActual As Integer = CType(Me.grdproductos.CurrentRow.Index, Integer)

        If filaActual >= 0 Then
            Dim index
            Dim yaBorro As Boolean = False

            For index = filaActual To Me.grdproductos.Rows.Count - 1
                Dim codigoArt As Integer = CType(Me.grdproductos.Rows(filaActual).Cells("Id").Value, Integer)
                If yaBorro = False Then
                    'Si borrar es igual a false, elimina la fila
                    Me.grdproductos.Rows.RemoveAt(filaActual)
                    yaBorro = True
                Else
                    'Si estamos es una fila que no tiene datos la eliminamos
                    If codigoArt = 0 Then
                        Me.grdproductos.Rows.RemoveAt(filaActual)
                    End If
                End If
            Next


        End If
    End Sub

    Private Sub fnNuevos() Handles Me.panel0
        Try
            fnNuevo()
        Catch ex As Exception

        End Try
    End Sub
End Class
