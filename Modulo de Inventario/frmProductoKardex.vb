Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmProductoKardex
    Private _articulo As Integer
    Public cambia As Boolean = False
    Public permiso As New clsPermisoUsuario

    Public Property articulo() As Integer
        Get
            articulo = _articulo
        End Get
        Set(ByVal value As Integer)
            _articulo = value
        End Set
    End Property

    Private Sub frmProductoKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fechaServidor As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
        dtpFechaInicio.Text = fechaServidor.AddMonths(-1)
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        mdlPublicVars.comboActivarFiltro(cmbArticulo)
        mdlPublicVars.comboActivarFiltro(cmbClientes)
        mdlPublicVars.comboActivarFiltro(cmbMovimientos)
        mdlPublicVars.comboActivarFiltro(cmbProveedor)
        mdlPublicVars.comboActivarFiltro(cmbInventario)
        fnLlenarCombos()
        Try
            fnLlenarGrid()
            fnConfiguracion()
            fnSumarios()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnLlenarCombos()
        'Agregamos los movimientos
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim movimientos = (From x In conexion.tblTipoMovimientoes Select Codigo = x.idTipoMovimiento, Nombre = x.nombre)

            Dim mov As New DataTable
            mov.Columns.Add("Codigo")
            mov.Columns.Add("Nombre")
            mov.Rows.Add(0, "Todos ...")

            Dim v
            For Each v In movimientos
                mov.Rows.Add(CType(v.codigo, Integer), v.nombre)
            Next

            With Me.cmbMovimientos
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = mov
            End With

            'Agregamos los clientes
            Dim clientes = (From x In conexion.tblClientes Select Codigo = x.idCliente, Nombre = x.Negocio)

            Dim cli As New DataTable
            cli.Columns.Add("Codigo")
            cli.Columns.Add("Nombre")

            cli.Rows.Add(0, "Todos ...")

            Dim w
            For Each w In clientes
                cli.Rows.Add(CType(w.codigo, Integer), w.nombre)
            Next

            With Me.cmbClientes
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cli
            End With

            'Agregamos los proveedores
            Dim proveedores = (From x In conexion.tblProveedors Select Codigo = x.idProveedor, Nombre = x.negocio)
            Dim pro As New DataTable
            pro.Columns.Add("Codigo")
            pro.Columns.Add("Nombre")

            pro.Rows.Add(0, "Todos ...")

            Dim y
            For Each y In proveedores
                pro.Rows.Add(CType(y.codigo, Integer), y.nombre)
            Next

            With Me.cmbProveedor
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = pro
            End With

            'Agregamos los inventarios
            Dim inventarios = (From x In conexion.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre)
            Dim inve As New DataTable
            inve.Columns.Add("Codigo")
            inve.Columns.Add("Nombre")

            'inve.Rows.Add(0, "Todos ...")
            For Each y In inventarios
                inve.Rows.Add(CType(y.codigo, Integer), y.nombre)
            Next

            With Me.cmbInventario
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = inve
            End With

            'Llenamos el combo de articulos
            Dim art = From x In conexion.tblArticuloes Select Codigo = x.idArticulo, Nombre = x.nombre1

            With Me.cmbArticulo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = art
            End With
            cambia = True
            If articulo > 0 Then
                cmbArticulo.SelectedValue = articulo
                'lblClave.Text = articulo
                Dim ar As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = articulo Select x).FirstOrDefault
                lblCodigo.Text = ar.codigo1
            End If

            conn.Close()
        End Using

    End Sub

    Private Sub fnLlenarGrid()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                conexion.CommandTimeout = 100000

                Dim fechaInicio As DateTime = dtpFechaInicio.Text + " 00:00:00"
                Dim fechaFinal As DateTime = dtpFechaFin.Text + " 23:59:59"
                Dim cli As Integer = CType(cmbClientes.SelectedValue, Integer)
                Dim pro As Integer = CType(cmbProveedor.SelectedValue, Integer)
                Dim tipo As Integer = CType(cmbMovimientos.SelectedValue, Integer)
                Dim inv As Integer = CType(cmbInventario.SelectedValue, Integer)

                Dim consulta = conexion.sp_kardexProducto(articulo, cli, pro, tipo, inv, txtDocumento.Text, fechaInicio, fechaFinal, mdlPublicVars.idEmpresa)
                Me.grdDatos.DataSource = consulta
                Dim historial = conexion.sp_SaldoInicialReservaOtros(articulo, cli, tipo, inv, txtDocumento.Text, fechaInicio, fechaFinal, mdlPublicVars.idEmpresa)
                Dim reservaActual As Integer = 0
                Dim ajustesactual As Integer = 0
                'Recorremos el historial
                For Each hist As sp_SaldoInicialReservaOtros_Result In historial
                    lblSaldoInicial.Text = Format(hist.SaldoInicial, mdlPublicVars.formatoNumero)
                    lblReservaHistorial.Text = Format(hist.ReservaHistorial, mdlPublicVars.formatoNumero)
                    lblAjustesHistorial.Text = Format(hist.AjustesHistorial, mdlPublicVars.formatoNumero)
                    lblSaldoNetoInicial.Text = Format(hist.SaldoInicial - hist.ReservaHistorial, mdlPublicVars.formatoNumero)
                    lblReserva.Text = Format(hist.ReservaActual, mdlPublicVars.formatoNumero)
                    lblAjustes.Text = Format(hist.AjustesActual, mdlPublicVars.formatoNumero)
                    reservaActual = hist.ReservaActual
                    ajustesactual = hist.AjustesActual
                Next

                'Establecemos el saldo final
                Try
                    lblFinal.Text = Format(Me.grdDatos.Rows(Me.grdDatos.RowCount - 1).Cells("Saldo").Value, mdlPublicVars.formatoNumero)
                Catch ex As Exception
                    lblFinal.Text = lblSaldoNetoInicial.Text
                End Try

                Dim final As Decimal = CDec(lblFinal.Text)
                'Establecemos el saldo final neto
                Try
                    lblFinalNeto.Text = Format((final - reservaActual) + ajustesactual, mdlPublicVars.formatoNumero)
                Catch ex As Exception
                    RadMessageBox.Show("ERROR!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End Try

                fnConfiguracion()

                conn.Close()
            End Using

        Catch ex As Exception
        End Try
    End Sub

    ''Funcion utilizada para agregar los sumarios al grid
    Private Sub fnSumarios()
        Try
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryEntrada As New GridViewSummaryItem("Entrada", mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
            Dim summarySalida As New GridViewSummaryItem("Salida", mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryEntrada, summarySalida})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para calcular los saldos
    Private Sub fnSaldos()
        Try
            Dim totalEntradas As Decimal = 0
            Dim totalSalidas As Decimal = 0
            Dim saldo As Decimal = 0
            'Dim saldoInicial As Decimal = CType(lblInicial1.Text, Decimal)
            Dim saldoInicial As Decimal = CType(0, Decimal)

            Dim reserva As Integer = CInt(lblReservaHistorial.Text)
            Try
                lblFinal.Text = Format(CType(Me.grdDatos.Rows(Me.grdDatos.RowCount - 1).Cells("Saldo").Value - reserva, Decimal), mdlPublicVars.formatoCantidad)
            Catch ex As Exception
                lblFinal.Text = 0
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Columns.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                Me.grdDatos.Columns("Codigo").IsVisible = False
                Me.grdDatos.Columns("TipoMov").IsVisible = False
                Me.grdDatos.Columns("Estado").IsVisible = False
                Me.grdDatos.Columns("Fecha").Width = 90
                Me.grdDatos.Columns("Movimiento").Width = 150
                Me.grdDatos.Columns("Descripcion").Width = 250
                Me.grdDatos.Columns("Entrada").Width = 70
                Me.grdDatos.Columns("Salida").Width = 70
                Me.grdDatos.Columns("Documento").Width = 70
                Me.grdDatos.Columns("Saldo").Width = 70
                Me.grdDatos.Columns("Inventario").Width = 150

                Me.grdDatos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Documento").HeaderText = "Doc"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArticulo.SelectedValueChanged
        Try
            If cambia = True Then
                articulo = CType(cmbArticulo.SelectedValue, Integer)
                Dim codigo As String = CType((From x In ctx.tblArticuloes Where x.idArticulo = articulo Select x.codigo1).FirstOrDefault, String)
                lblCodigo.Text = codigo
                fnLlenarGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    'Evento que se maneja cuando se da doble click en el grid
    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        Try
            Dim tipo As String = e.Row.Cells("TipoMov").Value
            Dim codigo As Integer = e.Row.Cells("Codigo").Value

            If tipo = mdlPublicVars.Entrada_CodigoMovimiento Then
                frmComprasConcepto.Text = "Compras"
                frmComprasConcepto.idEntrada = codigo
                frmComprasConcepto.WindowState = FormWindowState.Normal
                frmComprasConcepto.StartPosition = FormStartPosition.CenterScreen
                frmComprasConcepto.ShowDialog()
                frmComprasConcepto.Dispose()
            ElseIf tipo = mdlPublicVars.Proveedor_DevolucionCodigoMovimiento Or tipo = mdlPublicVars.Proveedor_AjusteCodigoMovimiento Then
                frmProveedorDevolucion.Text = "Ajustes y Devoluciones"
                frmProveedorDevolucion.bitEditarDevolucion = True
                frmProveedorDevolucion.codigoDev = codigo
                frmProveedorDevolucion.StartPosition = FormStartPosition.CenterScreen
                frmProveedorDevolucion.verRegistro = True
                permiso.PermisoDialogEspeciales(frmProveedorDevolucion)
                frmProveedorDevolucion.BringToFront()
                frmProveedorDevolucion.Dispose()
            ElseIf tipo = mdlPublicVars.Salida_TipoMovimientoVenta Then
                frmPedidoConcepto.Text = "Pedidos"
                frmPedidoConcepto.idSalida = codigo
                frmPedidoConcepto.WindowState = FormWindowState.Normal
                frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmPedidoConcepto)
                frmPedidoConcepto.Dispose()
            ElseIf tipo = Ajuste_CodigoMovimiento Then
                frmMovimientoInventarioConcepto.Text = "Movimiento Inventario"
                frmMovimientoInventarioConcepto.StartPosition = FormStartPosition.CenterScreen
                frmMovimientoInventarioConcepto.codigo = codigo
                frmMovimientoInventarioConcepto.ShowDialog()
                frmMovimientoInventarioConcepto.Dispose()
            ElseIf tipo = Cliente_DevolucionCodigoMovimiento Then
                frmClienteDevolucion.Text = "Devolucion de Cliente"
                frmClienteDevolucion.codigoReclamo = codigo
                frmClienteDevolucion.WindowState = FormWindowState.Normal
                frmClienteDevolucion.StartPosition = FormStartPosition.CenterScreen
                frmClienteDevolucion.bitModificar = True
                frmClienteDevolucion.verRegistro = True
                permiso.PermisoDialogEspeciales(frmClienteDevolucion)
                frmClienteDevolucion.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Evento que le deara el color a la fila
    Private Sub grdDatos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdDatos.CellFormatting
        Try
            'Obtenemos el color de la fila
            If Me.grdDatos.Rows.Count > 0 Then
                If e.CellElement.RowInfo.Cells("Estado").Value = 1 Then
                    mdlPublicVars.GridColor_fila(e, Color.Black)
                ElseIf e.CellElement.RowInfo.Cells("Estado").Value = 0 Then
                    mdlPublicVars.GridColor_fila(e, Color.Red)
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnLlenarGrid()
        alerta.contenido = "Finalizo la Busqueda"
        alerta.fnErrorContenido()
    End Sub

    Private Sub btnDetalleReserva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleReserva.Click

        Dim ar As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = articulo Select x).FirstOrDefault
        Dim codigo As Integer
        codigo = ar.idArticulo

        frmDetalleSurtirReserva.Text = "Detalle de Reserva"
        frmDetalleSurtirReserva.codigo = CInt(codigo)
        frmDetalleSurtirReserva.bitReserva = True
        frmDetalleSurtirReserva.StartPosition = FormStartPosition.CenterScreen
        frmDetalleSurtirReserva.ShowDialog()
        frmDetalleSurtirReserva.Dispose()

    End Sub

    Private Sub btnajustarkardex_Click(sender As Object, e As EventArgs) Handles btnajustarkardex.Click
        Dim idarticulo As Integer
        Dim idinventario As Integer

        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                If cmbArticulo.SelectedValue = Nothing Then
                    RadMessageBox.Show("Necesita escojer un Articulo", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ElseIf cmbInventario.SelectedValue = Nothing Then
                    RadMessageBox.Show("Necesita escojer un Tipo de Inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                Else
                    idarticulo = cmbArticulo.SelectedValue
                    idinventario = CType(cmbInventario.SelectedValue, Integer)

                    Dim cons = Nothing
                    cons = conexion.sp_herramientas_productosSaldosIndividual(idinventario, idarticulo, mdlPublicVars.idEmpresa)
                    RadMessageBox.Show("Producto Ajustado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                    fnLlenarGrid()
                    conn.Close()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al ajustar Producto " + ex.ToString())
        End Try

    End Sub

    Private Sub fnajustar() Handles Me.panel1
        Dim idinventario As Integer

        If cmbInventario.SelectedValue = Nothing Then
            RadMessageBox.Show("Necesita escojer un Tipo de Inventario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Else
            If RadMessageBox.Show("Desea Ajustar todos los saldos del Kardex? ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim conexion As New dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                        idinventario = CType(cmbInventario.SelectedValue, Integer)
                        Dim cons = Nothing
                        conexion.CommandTimeout = 8000
                        cons = conexion.sp_herramientas_productosSaldos(idinventario, mdlPublicVars.idEmpresa)
                        RadMessageBox.Show("Kardex Ajustado correctamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        conn.Close()

                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al ajustar Kardex " + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub btnAjustesDetalle_Click(sender As Object, e As EventArgs) Handles btnAjustesDetalle.Click
        Try

            Dim ar As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = articulo Select x).FirstOrDefault
            Dim codigo As Integer
            codigo = ar.idArticulo

            frmDetalleAjustes.Text = "Detalle de Ajustes"
            frmDetalleAjustes.codigo = CInt(codigo)
            frmDetalleAjustes.StartPosition = FormStartPosition.CenterScreen
            frmDetalleAjustes.ShowDialog()
            frmDetalleAjustes.Dispose()

        Catch ex As Exception

        End Try
    End Sub
End Class