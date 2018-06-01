Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmClienteDevolucion
    Public codigoReclamo As Integer = 0
    Public bitModificar As Boolean = False
    Public bitNuevo As Boolean = False

    Private Sub frmDevolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdProductos)
        mdlPublicVars.fnGrid_iconos(grdProductos)
        Me.grdProductos.Columns("txmCantidad").HeaderText = "Cant. Recibida"
        dtpFechaRegistro.Value = mdlPublicVars.fnFecha_horaServidor
        fnCorrelativo()
        FnLlenar_combos()
        fnLlenar_Datos()
        fnNuevaFila()

        chkTodos.Visible = False

    End Sub

    Private Sub fnLlenar_Datos()
        If bitModificar = True Then

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Try
                    lbl1Guardar.Text = "Modificar"
                    Me.grdProductos.AllowDeleteRow = False

                    'Obtenemos el encabezado de la devolucion
                    Dim devolucion As tblDevolucionCliente = (From x In conexion.tblDevolucionClientes Where x.codigo = codigoReclamo Select x).FirstOrDefault

                    '-------------ENCABEZADO--------------------
                    lblCaso.Text = devolucion.caso
                    txtObservacion.Text = devolucion.observacion
                    txtFecha.Text = devolucion.fechaRegistro.Date
                    cmbCliente.SelectedValue = devolucion.cliente
                    cmbVendedor.SelectedValue = devolucion.vendedor
                    lblCorrelativo.Text = devolucion.documento
                    cmbFactura.Text = devolucion.documentoAfectado
                    chkAcreditado.Checked = devolucion.acreditado
                    chkAnulado.Checked = devolucion.anulado

                    If devolucion.anuladoFecha IsNot Nothing Then
                        lblFechaAnulado.Text = Format(devolucion.anuladoFecha, mdlPublicVars.formatoFecha)
                    End If
                    If devolucion.bitFactura = True Then
                        rbnPorFactura.Checked = True
                    Else
                        rbnPorVarios.Checked = True
                    End If

                    rbnPorFactura.Enabled = False
                    rbnPorVarios.Enabled = False
                    cmbCliente.Enabled = False
                    cmbFactura.Enabled = False
                    '-----------FIN DE ENCABEZADO--------------

                    '-----------DETALLE---------------
                    'Seleccionamos la lista de detalles de la devolucion
                    Dim listaDetalles As List(Of tblDevolucionClienteDetalle) = (From x In conexion.tblDevolucionClienteDetalles Where x.devolucion = codigoReclamo Select x).ToList
                    Dim detalle As tblDevolucionClienteDetalle

                    Dim f As Integer = 0
                    For Each detalle In listaDetalles
                        If verRegistro = False Then
                            If rbnPorFactura.Checked = True Then
                                'txmObservacion,chmsolucion,idtipoinventario,txbdestino,idvendedor,txbresponsable
                                Me.grdProductos.Rows(f).Cells("iddetalle").Value = detalle.codigo
                                Me.grdProductos.Rows(f).Cells("txmCantidad").Value = detalle.cantidadAceptada
                                Me.grdProductos.Rows(f).Cells("txmObservacion").Value = detalle.observacion
                                Me.grdProductos.Rows(f).Cells("chmSolucion").Value = detalle.solucion

                                If detalle.cantidadAceptada > 0 Then
                                    Me.grdProductos.Rows(f).Cells("idTipoInventario").Value = detalle.tipoInventario
                                    Me.grdProductos.Rows(f).Cells("txbDestino").Value = detalle.tblTipoInventario.nombre
                                    Me.grdProductos.Rows(f).Cells("idVendedor").Value = detalle.vendedor
                                    Me.grdProductos.Rows(f).Cells("txbResponsable").Value = detalle.tblVendedor.nombre
                                    Me.grdProductos.Rows(f).Cells("idtipomovimiento").Value = detalle.idtipomovimiento
                                    Me.grdProductos.Rows(f).Cells("txbConcepto").Value = detalle.tblTipoMovimiento.nombre
                                End If
                                f += 1
                            ElseIf rbnPorVarios.Checked = True Then
                                Dim fila As Object()
                                fila = {detalle.codigo, detalle.articulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, detalle.cantidadRecibida, detalle.cantidadAceptada, detalle.costo, detalle.total, _
                                        detalle.observacion, detalle.solucion, detalle.tipoInventario, detalle.tblTipoInventario.nombre, _
                                        detalle.vendedor, detalle.tblVendedor.nombre, detalle.idtipomovimiento, detalle.tblTipoMovimiento.nombre, "0", Format(detalle.fechaVenta, mdlPublicVars.formatoFecha)}

                                Me.grdProductos.Rows.Add(fila)
                            End If
                        Else
                            Dim fila As Object()
                            If detalle.cantidadAceptada > 0 Then
                                fila = {detalle.codigo, detalle.articulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, detalle.cantidadRecibida, detalle.cantidadAceptada, detalle.costo, detalle.total, _
                                   detalle.observacion, detalle.solucion, detalle.tipoInventario, detalle.tblTipoInventario.nombre, _
                                   detalle.vendedor, detalle.tblVendedor.nombre, "0", Format(detalle.fechaVenta, mdlPublicVars.formatoFecha)}
                                Me.grdProductos.Rows.Add(fila)
                            End If
                        End If
                    Next



                    If verRegistro = True Then
                        pnx0Nuevo.Visible = False
                        pnx1Guardar.Visible = False
                    End If
                Catch ex As Exception
                End Try
                conn.Close()
            End Using


            fnActualizar_Total()
        End If
    End Sub

    Private Sub FnLlenar_combos()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim vend = From x In conexion.tblVendedors Where x.habilitado = True And x.empresa = mdlPublicVars.idEmpresa _
                           Select Codigo = x.idVendedor, Nombre = x.nombre
                Dim cl = From x In conexion.tblClientes Where x.habillitado = True Select Codigo = x.idCliente, Nombre = x.Negocio + " (" + x.nit1 + ")"


                With cmbVendedor
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = vend
                End With



                With cmbCliente
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = cl
                End With
            Catch ex As Exception
            End Try

            conn.Close()
        End Using

    End Sub

    Private Sub cmbCliente_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        fnLlenar_facturas()
        fnEstableceCaso()
    End Sub

    Private Sub rbnPorFactura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnPorFactura.CheckedChanged
        If Me.grdProductos.ColumnCount > 0 And verRegistro = False Then
            If rbnPorFactura.Checked = True Then
                fnLlenar_facturas()
                Me.grdProductos.Columns("cantidadVendida").ReadOnly = True
                Me.grdProductos.Columns("txmCodigo").ReadOnly = True

                'si el cheque por factura esta activo mostramos el check todos
                chkTodos.Visible = True
            Else
                Me.grdProductos.Columns("cantidadVendida").ReadOnly = False
                Me.grdProductos.Columns("txmCodigo").ReadOnly = False

                chkTodos.Checked = False
                chkTodos.Visible = False

            End If
        End If
    End Sub

    'Llena el combo de facturas
    Private Sub fnLlenar_facturas()

        Dim fechafiltro As DateTime = fnFecha_horaServidor()

        Dim fechaf As DateTime = fechafiltro.AddDays(mdlPublicVars.Dias_Devolucion * -1)
        ''Dim fechaf As DateTime = CDate(fechaSQL(fechafiltro))
        ''Dim fechaServidor As DateTime = fnFecha_horaServidor()

        If rbnPorFactura.Checked = True Then
            cmbFactura.Enabled = True
        Else
            cmbFactura.Enabled = False
            cmbFactura.DataSource = Nothing
            Exit Sub
        End If
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim codigoCliente As Integer = cmbCliente.SelectedValue

                'mostrar las facturas del cliente
                'Dim fac = From x In conexion.tblFacturas Join s In conexion.tblSalidas On x.IdFactura Equals s.IdFactura _
                '          Where s.tblCliente.idCliente = codigoCliente And x.anulado = False _
                '          Group By Codigo = x.IdFactura, x.Fecha, x.DocumentoFactura Into Group
                '          Order By Fecha Descending
                '            Select Codigo, Nombre = Fecha.Value + "  Doc: " + DocumentoFactura


                'Dim fac = (From f In conexion.tblFacturas Join sf In conexion.tblSalida_Factura On sf.factura Equals f.IdFactura
                '   Join s In conexion.tblSalidas On s.idSalida Equals sf.salida Where s.tblCliente.idCliente = codigoCliente _
                '   And f.anulado = False Group By Codigo = f.IdFactura, f.Fecha, f.DocumentoFactura Into Group
                '   Order By Fecha Descending
                '   Select Codigo, Nombre = Fecha.Value + "  Doc: " + DocumentoFactura)

                ' If(q.HasValue, q.Value.ToString("dd/MM/yyyy"), "")).Distinct()

                'Dim fac = (From sf In conexion.tblSalida_Factura Where sf.tblSalida.idCliente = codigoCliente And sf.tblFactura.anulado = False
                '   Group By Codigo = sf.factura, sf.tblFactura.Fecha, sf.tblFactura.DocumentoFactura Into Group
                '   Order By Fecha Descending
                '   Select Codigo, Nombre = Fecha + "  Doc: " + DocumentoFactura)

                ' r.date.GetValueOrDefault().ToString("dd.MM.yyyy")
                'If(q.HasValue, q.Value.ToString("dd/MM/yyyy"), "")).Distinct()

                'Dim fac = (From sf In conexion.tblSalida_Factura Where sf.tblSalida.idCliente = codigoCliente And sf.tblFactura.anulado = False
                '   Group By Codigo = sf.factura, Fecha = sf.tblFactura.Fecha, Pedido = sf.tblSalida.documento, Factura = sf.tblFactura.DocumentoFactura Into Group
                '   Order By Fecha Descending
                '   Select Codigo, Fecha, Pedido, Factura)

                Dim fac = (From sf In conexion.tblSalida_Factura Where sf.tblSalida.idCliente = codigoCliente And sf.tblFactura.anulado = False And sf.tblSalida.fechaRegistro < fechaf
                  Group By Codigo = sf.factura, Fecha = sf.tblFactura.Fecha, Pedido = sf.tblSalida.documento, Factura = sf.tblFactura.DocumentoFactura, codfact = sf.codigo Into Group
                  Order By Fecha Descending
                  Select Codigo, Fecha, Pedido, Factura, codfact)

                Dim dt As New DataTable
                dt.Columns.Add("Codigo")
                dt.Columns.Add("Nombre")

                Dim x
                Dim nfac As String = ""

                For Each x In fac
                    If x.Factura = "" Then
                        nfac = x.codfact
                        dt.Rows.Add(x.codigo, (x.Fecha.toShortDateString & " Pedido : " & x.Pedido & " CodFac " & nfac))
                    Else
                        nfac = x.Factura
                        dt.Rows.Add(x.codigo, (x.Fecha.toShortDateString & " Pedido : " & x.Pedido & " Factura " & nfac))
                    End If

                Next

                With cmbFactura
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = dt
                End With
            Catch ex As Exception

            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub cmbFactura_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFactura.SelectedValueChanged
        fnLlenar_facturasDetalle()
    End Sub

    'Llena el grid de productos, si se selecciona una factura unica
    Private Sub fnLlenar_facturasDetalle()
        Me.grdProductos.Rows.Clear()

        If rbnPorFactura.Checked = False Then
            Exit Sub
        End If

        If cmbFactura.Items.Count <= 0 Then
            Exit Sub
        End If
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                Dim codfac As Integer = cmbFactura.SelectedValue

                'Dim detalle = From f In conexion.tblFacturas Join s In conexion.tblSalidas On f.IdFactura Equals s.IdFactura _
                '                Join d In conexion.tblSalidaDetalles On s.idSalida Equals d.idSalida _
                '                Where f.IdFactura = codfac _
                '                Select codigoDetalle = 0, idarticulo = d.idArticulo, d.cantidad, _
                '                codigoArticulo = d.tblArticulo.codigo1, _
                '                nombre = d.tblArticulo.nombre1, d.precio, Total = d.cantidad * d.precio, Observacion = "", _
                '                Solucion = False, idTipoInventario = 0, Destino = "", idResponsable = 0, Responsable = ""


                Dim detalle = From df In conexion.tblSalidaDetalle_Factura Join sd In conexion.tblSalidaDetalles On sd.idSalidaDetalle Equals df.idSalidaDetalle
                                Where df.idFactura = codfac _
                                Select codigoDetalle = 0, idarticulo = sd.idArticulo, sd.cantidad, _
                                codigoArticulo = sd.tblArticulo.codigo1, _
                                nombre = sd.tblArticulo.nombre1, sd.precio, Total = sd.cantidad * sd.precio, Observacion = "", _
                                Solucion = False, idTipoInventario = 0, Destino = "", idResponsable = 0, Responsable = "", _
                                IdTipoMovimiento = 0, Concepto = ""



                Dim x
                For Each x In detalle
                    Me.grdProductos.Rows.Add(x.codigodetalle.ToString, x.idarticulo, x.codigoarticulo.ToString, x.nombre.ToString, x.cantidad, 0, x.precio.ToString, x.total.ToString, x.observacion.ToString, CType(x.solucion, Boolean), x.idtipoinventario.ToString, x.destino.ToString, x.idResponsable.ToString, x.responsable.ToString, 0)
                Next
            Catch ex As Exception
                Me.grdProductos.Rows.Clear()
            End Try

            conn.Close()
        End Using

        fnActualizar_Total()
    End Sub

    'ACTUALIZAR TOTAL
    Public Sub fnActualizar_Total()
        Dim elimina As Integer = 0
        Dim filas As Integer = 0
        If bitModificar = True Then
            Dim index
            For index = 0 To Me.grdProductos.Rows.Count - 1
                elimina = CType(Me.grdProductos.Rows(index).Cells("elimina").Value, Integer)
                If elimina = 0 Then
                    filas += 1
                End If
            Next
        Else
            filas = Me.grdProductos.Rows.Count
        End If

        lblRecuento.Text = filas
        Dim suma As Double = 0
        Dim cantidad As Double = 0

        Dim precio As Double = 0
        Dim total As Double = 0
        Dim solucion As Boolean = False
        elimina = 0
        Dim tipoInventario As tblTipoInventario = Nothing
        Dim inventario As Integer = 0


        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                If Me.grdProductos.Rows.Count > 0 Then


                    For index As Integer = 0 To Me.grdProductos.Rows.Count - 1

                        cantidad = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Double)
                        precio = CType(Me.grdProductos.Rows(index).Cells("txmPrecio").Value, Double)
                        inventario = CType(Me.grdProductos.Rows(index).Cells("IdTipoInventario").Value, Integer)
                        elimina = CType(Me.grdProductos.Rows(index).Cells("elimina").Value, Boolean)

                        'Obtenemos el tipo de inventario
                        tipoInventario = (From x In conexion.tblTipoInventarios.AsEnumerable Where x.idTipoinventario = inventario _
                                          Select x).FirstOrDefault

                        If tipoInventario IsNot Nothing Then
                            If tipoInventario.bitEstadoCuenta And elimina = 0 Then
                                If (cantidad * precio) = 0 Then
                                    Me.grdProductos.Rows(index).Cells("Total").Value = "0"
                                    total = 0
                                Else
                                    Me.grdProductos.Rows(index).Cells("Total").Value = Format(cantidad * precio, "###,###.##").ToString
                                    total = CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                                End If

                                suma = suma + total
                            ElseIf tipoInventario.bitEstadoCuenta = False And elimina = 0 Then
                                If (cantidad * precio) = 0 Then
                                    Me.grdProductos.Rows(index).Cells("Total").Value = "0"
                                    total = 0
                                Else
                                    Me.grdProductos.Rows(index).Cells("Total").Value = Format(cantidad * precio, "###,###.##").ToString
                                    total = CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                                End If
                                suma = suma + total
                            End If

                            If cantidad = 0 Then
                                Me.grdProductos.Rows(index).Cells("Total").Value = "0"
                            End If
                        End If
                    Next

                    lblTotal.Text = Format(suma, mdlPublicVars.formatoMoneda)
                    If suma = 0 Then
                        lblTotal.Text = 0
                    End If

                Else
                    lblTotal.Text = 0
                End If
            Catch ex As Exception
            End Try

            conn.Close()
        End Using

    End Sub

    'DESTINO
    Private Sub fnDestino()
        If verRegistro = False Then
            Dim consulta = Nothing
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                Try
                    consulta = (From x In conexion.tblTipoInventarios Where x.empresa = mdlPublicVars.idEmpresa _
                               Select codigo = x.idTipoinventario, nombre = x.nombre)
                Catch ex As Exception

                End Try
                conn.Close()
            End Using



            Dim mov As New DataTable
            mov.Columns.Add("Codigo")
            mov.Columns.Add("Nombre")

            mov.Rows.Add(0, "Ninguno")

            Dim v
            For Each v In consulta
                mov.Rows.Add(CType(v.codigo, Integer), v.nombre)
            Next
            frmCombo.combo.DataSource = mov
            frmCombo.combo.ValueMember = "codigo"
            frmCombo.combo.DisplayMember = "nombre"
            frmCombo.Text = "Inventario"
            frmCombo.ShowDialog()

            Dim cantidad As Double = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value, Double)

            If mdlPublicVars.superSearchId > 0 And Me.grdProductos.Rows.Count > 0 And cantidad > 0 Then

                If chkTodos.Checked = True Then

                    For i As Integer = 0 To grdProductos.Rows.Count - 1
                        Me.grdProductos.Rows(i).Cells("IdTipoInventario").Value = mdlPublicVars.superSearchId
                        Me.grdProductos.Rows(i).Cells("txbDestino").Value = mdlPublicVars.superSearchNombre
                    Next

                Else
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("IdTipoInventario").Value = mdlPublicVars.superSearchId
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbDestino").Value = mdlPublicVars.superSearchNombre
                End If


            ElseIf cantidad <= 0 Then
                RadMessageBox.Show("Primero debe indicar la cantidad a devolver!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        End If
    End Sub

    Private Sub fnConcepto()
        Try
            If verRegistro = False Then
                Dim consulta = Nothing

                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Try
                        consulta = (From x In conexion.tblTipoMovimientoes Where x.devolucion = True Select Codigo = x.idTipoMovimiento, Nombre = x.nombre)
                    Catch ex As Exception

                    End Try

                    Dim mov As New DataTable
                    mov.Columns.Add("Codigo")
                    mov.Columns.Add("Nombre")
                    mov.Rows.Add(0, "Ninguno")

                    Dim v
                    For Each v In consulta
                        mov.Rows.Add(CType(v.codigo, Integer), v.nombre)
                    Next
                    frmCombo.combo.DataSource = mov
                    frmCombo.combo.ValueMember = "Codigo"
                    frmCombo.combo.DisplayMember = "Nombre"
                    frmCombo.Text = "Concepto"
                    frmCombo.ShowDialog()

                    Dim cantidad As Double = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value, Double)

                    If mdlPublicVars.superSearchId > 0 And Me.grdProductos.Rows.Count > 0 And cantidad > 0 Then

                        If chkTodos.Checked = True Then

                            For i As Integer = 0 To grdProductos.Rows.Count - 1
                                Me.grdProductos.Rows(i).Cells("idtipomovimiento").Value = mdlPublicVars.superSearchId
                                Me.grdProductos.Rows(i).Cells("txbConcepto").Value = mdlPublicVars.superSearchNombre
                            Next

                        Else
                            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("idtipomovimiento").Value = mdlPublicVars.superSearchId
                            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbConcepto").Value = mdlPublicVars.superSearchNombre
                        End If

                    End If
                    conn.Close()
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

    'RESPONSABLE
    Private Sub fnResponsable()
        If verRegistro = False Then
            Dim consulta = Nothing
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                Try
                    consulta = (From x In conexion.tblVendedors Where x.empresa = mdlPublicVars.idEmpresa And x.habilitado = True _
                                                Select codigo = x.idVendedor, nombre = x.nombre)
                Catch ex As Exception

                End Try
                conn.Close()
            End Using


            Dim mov As New DataTable
            mov.Columns.Add("Codigo")
            mov.Columns.Add("Nombre")
            mov.Rows.Add(0, "Ninguno")

            Dim v
            For Each v In consulta
                mov.Rows.Add(CType(v.codigo, Integer), v.nombre)
            Next
            frmCombo.combo.DataSource = mov
            frmCombo.combo.ValueMember = "codigo"
            frmCombo.combo.DisplayMember = "nombre"
            frmCombo.Text = "Responsable"
            frmCombo.ShowDialog()

            Dim cantidad As Double = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmCantidad").Value, Double)

            If mdlPublicVars.superSearchId > 0 And Me.grdProductos.Rows.Count > 0 And cantidad > 0 Then


                If chkTodos.Checked = True Then

                    For i As Integer = 0 To grdProductos.Rows.Count - 1
                        Me.grdProductos.Rows(i).Cells("idVendedor").Value = mdlPublicVars.superSearchId
                        Me.grdProductos.Rows(i).Cells("txbResponsable").Value = mdlPublicVars.superSearchNombre
                    Next

                Else
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("idVendedor").Value = mdlPublicVars.superSearchId
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbResponsable").Value = mdlPublicVars.superSearchNombre
                End If

               

            End If
        End If
    End Sub

    Private Sub grdProductos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.DoubleClick

        If Me.grdProductos.CurrentRow.Index >= 0 Then
            If Me.grdProductos.Columns("txbDestino").IsCurrent Then
                fnDestino()
            ElseIf Me.grdProductos.Columns("txbResponsable").IsCurrent Then
                fnResponsable()
            End If
        End If
        fnActualizar_Total()
    End Sub

    'ESTABLECE CASO
    Private Sub fnEstableceCaso()
        'Realizamos la consulta en base al cliente
        Dim idCliente As Integer = CType(Me.cmbCliente.SelectedValue, Integer)
        Dim cliente As tblCliente

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            cliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).FirstOrDefault
            conn.Close()
        End Using

        Dim numeroCaso As Integer = 1

        If cliente Is Nothing Then
        Else
            If cliente.casos Is Nothing Then
            Else
                numeroCaso += cliente.casos
            End If
        End If

        lblCaso.Text = numeroCaso
    End Sub

    'ESTABLECE CORRELATIVO
    Private Sub fnCorrelativo()
        Dim corr As String = ""

        Dim correlativo As tblCorrelativo
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            correlativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Cliente_DevolucionCodigoMovimiento _
                                                 Select x).FirstOrDefault
            conn.Close()
        End Using

        If correlativo Is Nothing Then
            corr = 1
        Else
            corr = correlativo.serie & (correlativo.correlativo + 1).ToString
        End If
        lblCorrelativo.Text = corr
    End Sub

    '------------GUARDAR DEVOLUCION------------
    Private Sub fnGuardarDevolucion()

        Dim success As Boolean = True
        Dim idCliente As Integer = CType(Me.cmbCliente.SelectedValue, Integer)
        Dim idVendedor As Integer = CType(Me.cmbVendedor.SelectedValue, Integer)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim hora As String = mdlPublicVars.fnHoraServidor

        If fnErrores() = True Then
            Exit Sub
        End If

        'If fnValidacion() = True Then
        '    Exit Sub
        'End If

        fnActualizar_Total()

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            '-------------------Creamos el encabezado de la compra------------'
            Using transaction As New TransactionScope
                Try

                    Dim NoCorrelativo As String = 0
                    'Guardamos el encabezado de la devolucion
                    '-----------ENCABEZADO DEVOLUCION --------------
                    Dim devolucion As New tblDevolucionCliente
                    devolucion.cliente = idCliente
                    devolucion.vendedor = idVendedor
                    devolucion.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                    devolucion.fechaTransaccion = fechaServidor
                    devolucion.acreditado = False
                    devolucion.anulado = False
                    devolucion.monto = CDec(lblTotal.Text)
                    devolucion.tipoMovimiento = mdlPublicVars.Cliente_DevolucionCodigoMovimiento
                    devolucion.idusuario = mdlPublicVars.idUsuario
                    'Decidimos si fueron varias facturas o solo una, si fue sobre una factura tambien guardamos el id de la factura
                    If rbnPorFactura.Checked = True Then
                        devolucion.bitFactura = 1
                        devolucion.factura = CType(cmbFactura.SelectedValue, Integer)
                        devolucion.bitFacturaVarios = 0
                        devolucion.documentoAfectado = cmbFactura.Text
                    Else
                        devolucion.documentoAfectado = ""
                        devolucion.bitFacturaVarios = 1
                        devolucion.bitFactura = 0
                    End If
                    devolucion.observacion = txtObservacion.Text
                    devolucion.caso = lblCaso.Text
                    devolucion.idempresa = mdlPublicVars.idEmpresa

                    'Buscamos el correlativo en la tabla correlativo...
                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos _
                                          Where x.idTipoMovimiento = mdlPublicVars.Cliente_DevolucionCodigoMovimiento And x.idEmpresa = mdlPublicVars.idEmpresa _
                                          Select x).FirstOrDefault

                    If correlativo IsNot Nothing Then
                        correlativo.correlativo += 1
                        conexion.SaveChanges()

                        'asignar el numero de correlativo.
                        NoCorrelativo = correlativo.serie & correlativo.correlativo
                    Else
                        'crear registro de correlativo.
                        Dim correlativoNuevo As New tblCorrelativo
                        correlativoNuevo.correlativo = 1
                        correlativoNuevo.serie = ""
                        correlativoNuevo.inicio = 1
                        correlativoNuevo.fin = 1000
                        correlativoNuevo.porcentajeAviso = 20
                        correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                        correlativoNuevo.idTipoMovimiento = mdlPublicVars.Cliente_DevolucionCodigoMovimiento
                        conexion.AddTotblCorrelativos(correlativoNuevo)
                        conexion.SaveChanges()

                        'asignar el numero de correlativo.
                        NoCorrelativo = 1
                    End If

                    'Agregamos el numero de documento
                    devolucion.documento = NoCorrelativo
                    conexion.AddTotblDevolucionClientes(devolucion)
                    conexion.SaveChanges()
                    'Obtenemos el codigo de la devolucion
                    Dim idDevolucion As Integer = devolucion.codigo

                    '---------------FIN DE ENCABEZADO ---------------

                    'Actualizamos el numero de casos del cliente
                    Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).FirstOrDefault
                    cliente.casos = lblCaso.Text
                    conexion.SaveChanges()

                    'Guardamos el detalle de la devolucion
                    '-------------DETALLE DEVOLUCION---------------
                    Dim index As Integer = 0
                    Dim nombre As String = ""
                    Dim cantidadRecibida As Double = 0

                    Dim fechaUltCompra As String

                    Dim solucion As Boolean = False
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        Dim articulo As Integer = CType(Me.grdProductos.Rows(index).Cells("Id").Value, Integer)
                        Dim cantidad As Double = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Double)
                        cantidadRecibida = CType(Me.grdProductos.Rows(index).Cells("cantidadVendida").Value, Double)
                        Dim costo As Double = CType(Me.grdProductos.Rows(index).Cells("txmPrecio").Value, Double)
                        Dim total As Double = CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                        Dim tipoInventario As Integer = CType(Me.grdProductos.Rows(index).Cells("IdTipoInventario").Value, Integer)
                        Dim idtipomovimiento As Integer = CType(Me.grdProductos.Rows(index).Cells("IdTipoMovimiento").Value, Integer)

                        fechaUltCompra = CType(LTrim(RTrim(Me.grdProductos.Rows(index).Cells("fechaUltCompra").Value)), String)


                        nombre = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)
                        If cantidad > 0 Then
                            If nombre IsNot Nothing Then
                                Dim vendedor As Integer = 0
                                If Me.grdProductos.Rows(index).Cells("idVendedor").Value.ToString.Length = 0 Then
                                    vendedor = 0
                                Else
                                    vendedor = CType(grdProductos.Rows(index).Cells("idVendedor").Value, Integer)
                                End If

                                Dim observacion = Me.grdProductos.Rows(index).Cells("txmObservacion").Value

                                'Obtenemos el tipo de inventario y en base a eso el tipo de inventario
                                Dim tipoIn As tblTipoInventario = (From x In conexion.tblTipoInventarios.AsEnumerable Where x.idTipoinventario = tipoInventario
                                                                  Select x).FirstOrDefault

                                If tipoIn IsNot Nothing Then
                                    If tipoIn.bitEstadoCuenta Then
                                        solucion = True
                                    Else
                                        solucion = False
                                    End If
                                Else
                                    solucion = False
                                End If

                                'Creamos el nuevo detalle
                                Dim detalle As New tblDevolucionClienteDetalle
                                detalle.devolucion = idDevolucion
                                detalle.articulo = articulo
                                detalle.cantidadRecibida = cantidadRecibida
                                detalle.cantidadAceptada = cantidad
                                detalle.costo = costo
                                detalle.total = total
                                detalle.solucion = solucion
                                detalle.idtipomovimiento = idtipomovimiento





                                If Not rbnPorFactura.Checked Then

                                    If fechaUltCompra = "" Then
                                        detalle.fechaVenta = Nothing
                                    Else
                                        detalle.fechaVenta = fechaUltCompra
                                    End If


                                End If

                                If cantidad > 0 Then
                                    detalle.tipoInventario = tipoInventario
                                    detalle.vendedor = vendedor
                                End If

                                detalle.observacion = observacion
                                conexion.AddTotblDevolucionClienteDetalles(detalle)
                                conexion.SaveChanges()
                            End If
                        End If
                    Next

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
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using


            If success = True Then
                conexion.AcceptAllChanges()
                alerta.contenido = "Registro guardado correctamente"
                alerta.fnGuardar()
            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            conn.Close()
        End Using

        If success = True Then
            fnNuevo()
        End If

    End Sub

    '------------MODIFICAR DEVOLUCION------------
    Private Sub fnModificarDevolucion()
        Dim success As Boolean = True

        If fnErrores() = True Then
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
                    'Obtenemos el encabezado de la devolucion
                    '------------ENCABEZADO---------------
                    Dim devolucion As tblDevolucionCliente = (From x In conexion.tblDevolucionClientes Where x.codigo = codigoReclamo Select x).FirstOrDefault
                    devolucion.monto = CDec(lblTotal.Text)
                    devolucion.observacion = txtObservacion.Text
                    devolucion.vendedor = cmbVendedor.SelectedValue
                    conexion.SaveChanges()
                    '------------FIN DE ENCABEZADO-------

                    '-------------DETALLE---------------
                    'Obtenemos la lista de los detalles
                    Dim index
                    Dim nombre As String = ""
                    Dim cantidadRecibida As Double = 0

                    Dim fechaUltCompra As String


                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        Dim idDetalle As Integer = CType(Me.grdProductos.Rows(index).Cells("iddetalle").Value, Integer)
                        cantidadRecibida = CType(Me.grdProductos.Rows(index).Cells("cantidadVendida").Value, Double)
                        Dim elimina As Integer = CType(Me.grdProductos.Rows(index).Cells("elimina").Value, Integer)
                        Dim articulo As Integer = CType(Me.grdProductos.Rows(index).Cells("Id").Value, Integer)
                        Dim cantidad As Double = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Double)
                        Dim costo As Double = CType(Me.grdProductos.Rows(index).Cells("txmPrecio").Value, Double)
                        Dim total As Double = CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                        Dim tipoInvetario As Integer = CType(Me.grdProductos.Rows(index).Cells("IdTipoInventario").Value, Integer)
                        Dim vendedor As Integer = CType(Me.grdProductos.Rows(index).Cells("idVendedor").Value, Integer)
                        Dim observacion = Me.grdProductos.Rows(index).Cells("txmObservacion").Value
                        Dim solucion As Boolean = CType(Me.grdProductos.Rows(index).Cells("chmSolucion").Value, Boolean)
                        Dim idtipomovimiento As Integer = CType(Me.grdProductos.Rows(index).Cells("IdTipoMovimiento").Value, Integer)
                        nombre = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)
                        fechaUltCompra = CType(LTrim(RTrim(Me.grdProductos.Rows(index).Cells("fechaUltCompra").Value)), String)

                        If nombre IsNot Nothing Then
                            If elimina > 0 Then
                                'Obtenemos el detalle a eliminar
                                Dim detalle As tblDevolucionClienteDetalle = (From x In conexion.tblDevolucionClienteDetalles Where x.codigo = idDetalle Select x).FirstOrDefault
                                conexion.DeleteObject(detalle)
                                conexion.SaveChanges()
                            ElseIf idDetalle > 0 Then
                                'Seleccionamos el detalle a modificar
                                'Creamos el nuevo detalle
                                Dim detalle As tblDevolucionClienteDetalle = (From x In conexion.tblDevolucionClienteDetalles Where x.codigo = idDetalle Select x).FirstOrDefault

                                detalle.articulo = articulo
                                detalle.cantidadRecibida = cantidadRecibida
                                detalle.cantidadAceptada = cantidad
                                detalle.costo = costo
                                detalle.total = total
                                detalle.solucion = solucion

                                If fechaUltCompra = "" Then
                                    detalle.fechaVenta = Nothing
                                Else
                                    detalle.fechaVenta = fechaUltCompra
                                End If






                                If cantidad > 0 Then
                                    detalle.tipoInventario = tipoInvetario
                                    detalle.vendedor = vendedor
                                Else
                                    detalle.tipoInventario = Nothing
                                    detalle.vendedor = Nothing
                                End If
                                'If cantidad > 0 Then
                                '    detalle.solucion = True
                                '    detalle.tipoInventario = tipoInvetario
                                '    detalle.vendedor = vendedor
                                'Else
                                '    detalle.solucion = False
                                '    detalle.tipoInventario = mdlPublicVars.Cliente_InventarioDevolucion
                                'End If
                                detalle.observacion = observacion

                                conexion.SaveChanges()
                            Else
                                'Creamos el nuevo detalle
                                Dim detalle As New tblDevolucionClienteDetalle
                                detalle.devolucion = codigoReclamo
                                detalle.articulo = articulo
                                detalle.cantidadRecibida = cantidadRecibida
                                detalle.cantidadAceptada = cantidad
                                detalle.costo = costo
                                detalle.total = total
                                detalle.solucion = solucion
                                detalle.idtipomovimiento = idtipomovimiento
                                If cantidad > 0 Then
                                    detalle.tipoInventario = tipoInvetario
                                    detalle.vendedor = vendedor
                                End If
                                detalle.observacion = observacion
                                conexion.AddTotblDevolucionClienteDetalles(detalle)
                                conexion.SaveChanges()
                            End If
                        End If
                    Next

                    '---------FIN DE DETALLE-----------

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
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using


            If success = True Then
                conexion.AcceptAllChanges()
                alerta.contenido = "Registro guardado correctamente"
                alerta.fnGuardar()
            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            conn.Close()
        End Using

        If success = True Then
            fnNuevo()
        End If
    End Sub

    'Funcion utilizada para verificar si hay errores
    Private Function fnErrores() As Boolean
        'Si la devolucion es por facturas analizamos que se ingrese al menos un producto
        If rbnPorVarios.Checked = True Then
            If Me.grdProductos.Rows.Count < 1 Then
                alerta.contenido = "Debe ingresar productos"
                alerta.fnErrorContenido()
                Return True
                Exit Function
            End If
        End If

        'Analizamos si la fila ha sido activado el chek solucion, que se le haya asignado un destino y un responsable
        Dim index As Integer = 0
        Dim solucion As Boolean = False
        Dim cantidad As Integer = 0

        For index = 0 To Me.grdProductos.Rows.Count - 1
            solucion = CType(Me.grdProductos.Rows(index).Cells("chmSolucion").Value, Boolean)
            cantidad = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Integer)

            'If solucion = True Then
            If cantidad > 0 Then
                Dim responsable = Me.grdProductos.Rows(index).Cells("txbResponsable").Value
                Dim destino = Me.grdProductos.Rows(index).Cells("txbDestino").Value
                Dim concepto = Me.grdProductos.Rows(index).Cells("txbConcepto").Value

                'Analizamos que tenga asignado un responsable
                If responsable Is Nothing Or responsable = "" Then
                    alerta.contenido = "Debe asignarle un responsable a la solucion"
                    alerta.fnErrorContenido()
                    Me.grdProductos.Focus()
                    Me.grdProductos.Rows(index).IsCurrent = True
                    Me.grdProductos.Columns("txbResponsable").IsCurrent = True
                    Return True
                    Exit Function
                End If

                If destino Is Nothing Or destino = "" Then
                    alerta.contenido = "Debe asignarle un destino al producto"
                    alerta.fnErrorContenido()
                    Me.grdProductos.Rows(index).IsCurrent = True
                    Me.grdProductos.Columns("txbDestino").IsCurrent = True
                    Return True
                    Exit Function
                End If

                If concepto Is Nothing Or concepto = "" Then
                    alerta.contenido = "Debe asignarle un Concepto al producto"
                    alerta.fnErrorContenido()
                    Me.grdProductos.Rows(index).IsCurrent = True
                    Me.grdProductos.Columns("txbConcepto").IsCurrent = True
                    Return True
                    Exit Function
                End If
            End If

        Next
        Return False
    End Function

    'NUEVO
    Private Sub fnNuevo()
        Me.grdProductos.Rows.Clear()
        Me.grdProductos.AllowDeleteRow = True
        cmbCliente.Enabled = True
        cmbVendedor.Enabled = True
        rbnPorFactura.Enabled = True
        rbnPorVarios.Enabled = True
        FnLlenar_combos()
        fnEstableceCaso()
        txtObservacion.Text = ""
        lblTotal.Text = ""
        rbnPorVarios.Checked = True
        fnNuevaFila()
        fnCorrelativo()
    End Sub

    'GUARDAR
    Private Sub pbxGuardar_Click() Handles Me.panel1
        If verRegistro = False Then
            If bitModificar = True Then
                fnModificarDevolucion()
            Else
                fnGuardarDevolucion()
            End If
        End If
    End Sub

    'NUEVO
    Private Sub pbxNuevo_Click() Handles Me.panel0
        fnNuevo()
    End Sub

    'AGREGAR ARTICULOS
    Public Sub fnAgregar_Articulos()
        'agregar productos a grid.
        Dim filas() As Object
        Dim cliente As Integer = CInt(cmbCliente.SelectedValue)


        'Obtenemos la fecha de la ultima vez que el cliente compro ese producto
        Dim fechaUltCompra As Nullable(Of DateTime)

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            fechaUltCompra = (From x In conexion.tblSalidaDetalles _
                                              Where x.idArticulo = mdlPublicVars.superSearchId And x.tblSalida.idCliente = cliente _
                                              Select x.tblSalida.fechaFacturado Order By fechaFacturado Descending Take 1).FirstOrDefault

            conn.Close()
        End Using

        'id, codigo,nombre,precio,cantidad
        filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, _
                 mdlPublicVars.superSearchCantidad, mdlPublicVars.superSearchCantidad, mdlPublicVars.superSearchPrecio, _
                 mdlPublicVars.superSearchPrecio, "", False}


        grdProductos.Rows.Add(filas)
        grdProductos.Columns(4).IsCurrent = True
        grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
        grdProductos.Rows(grdProductos.Rows.Count - 1).Cells("elimina").Value = 0
        grdProductos.Rows(grdProductos.Rows.Count - 1).Cells("fechaUltCompra").Value = If(fechaUltCompra Is Nothing, "", Format(fechaUltCompra, mdlPublicVars.formatoFecha))


        fnActualizar_Total()
    End Sub

    'Funcion que se utiliza para remo        ver la fila actual
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
            'Recorremos el grid
            Dim i
            Dim nombre As String = ""
            For i = 0 To Me.grdProductos.Rows.Count - 1
                'Obtenemo el valor del nombre
                nombre = Me.grdProductos.Rows(i).Cells("txbProducto").Value

                If IsNothing(nombre) Then
                    Me.grdProductos.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Dim fila As Integer = Me.grdProductos.CurrentRow.Index

        If e.Column.Name = "txmCodigo" Then
            Dim codigo As String = e.Value

            If codigo IsNot Nothing Then
                If codigo.Length > 0 Then
                    fnBuscarArticulo(codigo, e.RowIndex)
                End If
            End If
        Else
            fnActualizar_Total()
        End If
    End Sub

    'Buscar Articulo Unico
    Public Sub fnBuscarArticulo(ByVal codigo As String, ByVal posicion As Integer)
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities
        Dim bitNuevaFila As Boolean = False

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                'Verificamos si existe en codigos de barra
                Dim codigoBarra As tblArticulo_CodigoBarra = (From x In conexion.tblArticulo_CodigoBarra Where x.codigoBarra = codigo _
                                                              Select x).FirstOrDefault

                Dim cantidad As Integer = 0
                Dim articulo As tblArticulo = Nothing
                If codigoBarra Is Nothing Then
                    'Buscamos el articulo en base al codigo
                    articulo = (From x In conexion.tblArticuloes Where x.codigo1 = codigo And x.empresa = mdlPublicVars.idEmpresa _
                               Select x).FirstOrDefault
                Else
                    articulo = (From x In conexion.tblArticuloes Where x.idArticulo = codigoBarra.articulo And x.empresa = mdlPublicVars.idEmpresa _
                               Select x).FirstOrDefault
                    cantidad = codigoBarra.unidadEmpaque
                End If

                If articulo Is Nothing And codigoBarra Is Nothing Then
                    alerta.contenido = "Este producto no existe"
                    alerta.fnErrorContenido()
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(2).Value = ""
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(2).BeginEdit()
                Else
                    Dim codCliente As Integer = CInt(cmbCliente.SelectedValue)
                    'Obtenemos el tipo de negocio del cliente
                    Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codCliente Select x).FirstOrDefault
                    Dim tNegocio As Integer = cliente.idTipoNegocio

                    'Seleccionamos el precio del articulo
                    Dim precioArt As tblArticulo_TipoNegocio = (From x In conexion.tblArticulo_TipoNegocio Where x.articulo = articulo.idArticulo And _
                                                               x.tipoNegocio = tNegocio Select x).FirstOrDefault
                    Dim precio As Decimal = 0
                    'Asignamos el precio
                    If precioArt IsNot Nothing Then
                        precio = precioArt.tblArticulo.precioPublico * (100 - precioArt.descuento) / 100
                    Else
                        alerta.contenido = "Producto: " & articulo.nombre1 & " no tiene precio!"
                        alerta.fnErrorContenido()

                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells(2).BeginEdit()
                        Exit Sub
                    End If

                    'Agregamos el producto
                    Me.grdProductos.Rows(posicion).Cells("iddetalle").Value = "0"
                    Me.grdProductos.Rows(posicion).Cells("id").Value = articulo.idArticulo
                    Me.grdProductos.Rows(posicion).Cells("txmCodigo").Value = codigo
                    Me.grdProductos.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                    Me.grdProductos.Rows(posicion).Cells("cantidadVendida").Value = If(codigoBarra Is Nothing, 0, cantidad)
                    Me.grdProductos.Rows(posicion).Cells("txmCantidad").Value = If(codigoBarra Is Nothing, 0, cantidad)
                    Me.grdProductos.Rows(posicion).Cells("txmPrecio").Value = Format(precio, mdlPublicVars.formatoMoneda)
                    Me.grdProductos.Rows(posicion).Cells("Total").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txmObservacion").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("chmSolucion").Value = False
                    Me.grdProductos.Rows(posicion).Cells("idTipoInventario").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txbDestino").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("idVendedor").Value = 0
                    Me.grdProductos.Rows(posicion).Cells("txbResponsable").Value = ""
                    Me.grdProductos.Rows(posicion).Cells("elimina").Value = 0

                    'Obtenemos la fecha de la ultima vez que el cliente compro ese producto
                    Dim fechaUltCompra As Nullable(Of DateTime) = (From x In conexion.tblSalidaDetalles _
                                                      Where x.idArticulo = mdlPublicVars.superSearchId And x.tblSalida.idCliente = codCliente _
                                                      Select x.tblSalida.fechaFacturado Order By fechaFacturado Descending Take 1).FirstOrDefault
                    grdProductos.Rows(posicion).Cells("fechaUltCompra").Value = If(fechaUltCompra Is Nothing, "", Format(fechaUltCompra, mdlPublicVars.formatoFecha))

                    bitNuevaFila = True
                End If
            Catch ex As Exception
            End Try

            conn.Close()
        End Using

        If bitNuevaFila = True Then
            Me.fnNuevaFila()
        End If

    End Sub

    'Maneja el evento de la tecla DELETE
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If verRegistro = False Then
            If Me.grdProductos.Rows.Count > 0 Then
                Dim f As Integer = grdProductos.CurrentRow.Index
                Dim c As Integer = grdProductos.CurrentColumn.Index

                If e.KeyCode = Keys.F2 And grdProductos.Columns(c).Name = "txbProducto" And rbnPorFactura.Checked = False Then
                    frmBuscarArticulo.codClie = cmbCliente.SelectedValue
                    frmBuscarArticulo.codVendedor = cmbVendedor.SelectedValue
                    frmBuscarArticulo.OpcionRetorno = "salidas"
                    frmBuscarArticulo.bitDevolucionCliente = True
                    frmBuscarArticulo.idInventario = mdlPublicVars.General_idTipoInventario
                    frmBuscarArticulo.idBodega = mdlPublicVars.General_idAlmacenPrincipal
                    frmBuscarArticulo.bitCliente = True
                    frmBuscarArticulo.Text = "Buscar Articulos"
                    frmBuscarArticulo.venta = 0
                    frmBuscarArticulo.Show()
                ElseIf grdProductos.Columns(c).Name = "txbDestino" Then
                    fnDestino()
                    fnActualizar_Total()
                ElseIf grdProductos.Columns(c).Name = "txbResponsable" Then
                    fnResponsable()
                    fnActualizar_Total()
                ElseIf grdProductos.Columns(c).Name = "txbConcepto" Then
                    fnConcepto()
                    fnActualizar_Total()
                End If
            End If

            If bitModificar = True And rbnPorVarios.Checked = True Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdProductos, "iddetalle")
                fnActualizar_Total()
            End If
        End If
    End Sub

    Private Sub rbnPorVarios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnPorVarios.CheckedChanged
        If Me.grdProductos.ColumnCount > 0 And verRegistro = False Then
            Me.grdProductos.Rows.Clear()
            If rbnPorVarios.Checked = True Then
                fnNuevaFila()
                Me.grdProductos.Columns("cantidadVendida").ReadOnly = False
                Me.grdProductos.Columns("txmCodigo").ReadOnly = False
            Else
                Me.grdProductos.Columns("cantidadVendida").ReadOnly = True
                Me.grdProductos.Columns("txmCodigo").ReadOnly = True
            End If
        End If
    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        fnActualizar_Total()
        If Me.grdProductos.RowCount = 0 And rbnPorVarios.Checked = True Then
            Me.grdProductos.Rows.AddNew()
        End If
    End Sub

    Private Sub grdProductos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdProductos.ValueChanged
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
        Dim col As Integer = Me.grdProductos.CurrentColumn.Index
        Try
            If Me.grdProductos.Columns(col).Name = "chmSolucion" Then
                dtpFechaRegistro.Focus()
                'dtpFechaRegistro.Select()
                fnActualizar_Total()
                Me.grdProductos.Rows(fila).Cells(col).IsSelected = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmClienteDevolucion_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmClienteDevolucionLista.frm_llenarLista()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked = True Then
            'recorrer el gri para poner en la cela
            For i As Integer = 0 To grdProductos.RowCount - 1
                ' Dim cantidad As Integer = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Integer)
                grdProductos.Rows(i).Cells(5).Value = grdProductos.Rows(i).Cells(4).Value
            Next
        Else
            For i As Integer = 0 To grdProductos.RowCount - 1
                ' Dim cantidad As Integer = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Integer)
                grdProductos.Rows(i).Cells(5).Value = 0

                Me.grdProductos.Rows(i).Cells("IdTipoInventario").Value = 0
                Me.grdProductos.Rows(i).Cells("txbDestino").Value = ""

                Me.grdProductos.Rows(i).Cells("idVendedor").Value = 0
                Me.grdProductos.Rows(i).Cells("txbResponsable").Value = ""
            Next
        End If
    End Sub

    Private Function fnValidacion() As Boolean
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim filas As Integer = Me.grdProductos.Rows.Count - 1
            Dim fact As Integer = CType(Me.cmbFactura.SelectedValue, Integer)
            Dim cvendido As Double
            Dim cdevuelto As Double
            Dim idarticulo As Integer
            Dim cdevolver As Double
            Dim devuelto As Boolean = False
            Dim mayor As Boolean = False

            For index As Integer = 0 To filas

                cdevuelto = 0

                idarticulo = Me.grdProductos.Rows(index).Cells("id").Value
                cvendido = Me.grdProductos.Rows(index).Cells("cantidadvendida").Value
                cdevolver = Me.grdProductos.Rows(index).Cells("txmCantidad").Value

                Dim devoluciones As List(Of tblDevolucionCliente) = (From x In conexion.tblDevolucionClientes Where x.factura = fact And x.anulado = False Select x).ToList

                For Each dev As tblDevolucionCliente In devoluciones

                    Dim devolucionesdetalle As List(Of tblDevolucionClienteDetalle) = (From x In conexion.tblDevolucionClienteDetalles Where x.devolucion = dev.codigo And x.articulo = idarticulo Select x).ToList

                    For Each devo As tblDevolucionClienteDetalle In devolucionesdetalle

                        cdevuelto += devo.cantidadAceptada

                    Next

                Next

                If cdevuelto = cvendido Then
                    devuelto = True
                    mayor = False
                    Exit For
                ElseIf (cdevuelto + cdevolver) > cvendido Then
                    devuelto = False
                    mayor = True
                    Exit For
                End If

            Next

            If devuelto = True And mayor = False Then

                Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).FirstOrDefault
                If articulo Is Nothing Then

                Else
                    RadMessageBox.Show("El Articulo " + RTrim(LTrim(CStr(articulo.nombre1))) + " ya fue devuelto completamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Return True
                    Exit Function
                End If
            ElseIf mayor = True And devuelto = False Then

                Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idarticulo Select x).FirstOrDefault

                RadMessageBox.Show("Del Articulo " + RTrim(LTrim(CStr(articulo.nombre1))) + " ya se devolvieron: " + CStr(cdevuelto) + ", quedan pendiente " + CStr((cvendido - cdevuelto)), mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Return True
                Exit Function

            End If

            conn.Close()
        End Using
        Return False
    End Function

    Private Function fnDevolucionValida() As Boolean

        ''Validacion de que no existan Devoluciones o que no se haya devuelto todo el producto

        Dim conex As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conex = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim cantidaddevueltatotal As Double
            Dim cantidadvendida As Double

            Dim fac As Integer = CType(cmbFactura.SelectedValue, Integer)

            Dim sal As Integer = (From x In conex.tblSalida_Factura Where x.factura = fac Select x.salida).FirstOrDefault

            Dim detalle As List(Of tblSalidaDetalle) = (From x In conex.tblSalidaDetalles Where x.idSalida = sal Select x).ToList

            For Each det As tblSalidaDetalle In detalle

                cantidadvendida = det.cantidad

                Dim dev As List(Of tblDevolucionCliente) = (From x In conex.tblDevolucionClientes Where x.factura = fac Select x).ToList

                For Each devo As tblDevolucionCliente In dev

                    Dim devd As List(Of tblDevolucionClienteDetalle) = (From x In conex.tblDevolucionClienteDetalles Where x.devolucion = devo.codigo Select x).ToList

                    For Each devde As tblDevolucionClienteDetalle In devd


                        cantidaddevueltatotal += devde.cantidadRecibida

                        RadMessageBox.Show("La Cantidad Devuelta del Articulo es: " + CStr(cantidaddevueltatotal) + ", La cantidad vendida es:" + CStr(cantidadvendida), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                    Next

                Next

            Next


            Return False

            conn.Close()
        End Using
        ''fin de la Validacion

    End Function

    Private Sub btnValidar_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        fnValidacion()
    End Sub
End Class
