﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmMovimientoInventarios
    Public bitModificar As Boolean = False
    Public idMovimiento As Integer = 0
    Private permiso As New clsPermisoUsuario

    Private Sub frmInventarioMovimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        dtpFechaRegistro.Value = mdlPublicVars.fnFecha_horaServidor
        rbtAjuste.Checked = True
        fnEstablecerCorrelativo()
        FnLlenar_combos()
        fnLlenar_Datos()

        mdlPublicVars.fnGrid_iconos(grdProductos)

        If mdlPublicVars.bitUnidadMedida_Activado = True Then
            Me.grdProductos.Columns("txbUnidadMedida").IsVisible = True
        Else
            Me.grdProductos.Columns("txbUnidadMedida").IsVisible = False
        End If
    End Sub

    'ESTABLECE EL CORRELATIVOdnue
    Private Sub fnEstablecerCorrelativo()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            'Buscamos el correlativo en la tabla correlativo...
            Dim Correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos _
                                  Where x.idTipoMovimiento = mdlPublicVars.Ajuste_CodigoMovimiento And x.idEmpresa = mdlPublicVars.idEmpresa _
                                  Select x).First
            Me.lblCorrelativo.Text = CStr(Correlativo.correlativo + 1)
            conn.Close()
        End Using

    End Sub

    Private Sub fnLlenar_Datos()
        If bitModificar = True Or verRegistro = True Then

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Try
                    lbl1Guardar.Text = "Modificar"

                    Me.grdProductos.AllowDeleteRow = False

                    'Obtenemos el encabezado
                    Dim movimiento As tblMovimientoInventario = (From x In conexion.tblMovimientoInventarios Where x.codigo = idMovimiento Select x).FirstOrDefault

                    '---------ENCABEZADO-------------
                    'Establecemos si es ajuste o traslado
                    If movimiento.ajuste = True Then
                        rbtAjuste.Checked = True
                    Else
                        rbtTraslado.Checked = True
                    End If

                    rbtAjuste.Enabled = False
                    rbtTraslado.Enabled = False

                    ''lblUsuario.Text = movimiento.tblUsuario.nombre
                    ''lblEUsuario.Visible = True
                    ''lblUsuario.Visible = True
                    'Establecemos el documento y la observacion
                    lblCorrelativo.Text = movimiento.correlativo
                    txtObservacion.Text = movimiento.observacion

                    'Establecemos la fecha de registro
                    dtpFechaRegistro.Text = movimiento.fechaRegistro.Date
                    dtpFechaRegistro.Enabled = False

                    'Establecemos los inventarios
                    cmbInventarioInicial.SelectedValue = movimiento.inventarioInicial
                    cmbInventarioFinal.SelectedValue = movimiento.inventarioFinal
                    '------------FIN ENCABEZADO--------------

                    'Obtenemos el detalle
                    '--------------DETALLE--------------
                    Dim listaDetalles As List(Of tblMovimientoInventarioDetalle) = (From x In conexion.tblMovimientoInventarioDetalles Where x.movimientoInventario = idMovimiento _
                                                                                    Select x).ToList
                    Dim detalle As tblMovimientoInventarioDetalle

                    For Each detalle In listaDetalles
                        Dim fila As Object()
                        fila = {detalle.codigo, detalle.articulo, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, detalle.tipoMovimiento, detalle.tblTipoMovimiento.nombre, _
                                detalle.cantidad, detalle.costo, detalle.total, "0"}
                        Me.grdProductos.Rows.Add(fila)
                    Next

                    If verRegistro = False Then
                        fnNuevaFila()
                    Else
                        pnx0Nuevo.Visible = False
                        pnx1Guardar.Visible = False
                    End If

                Catch ex As Exception

                End Try

                conn.Close()
            End Using

        Else
            fnNuevaFila()
        End If

        fnActualizar_Total()
    End Sub

    Private Sub FnLlenar_combos()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                Dim inveInicial = From x In conexion.tblTipoInventarios Where x.empresa = mdlPublicVars.idEmpresa _
                                  Select codigo = x.idTipoinventario, nombre = x.nombre

                With cmbInventarioInicial
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = inveInicial
                End With


                Dim bodInicial = From x In conexion.tblAlmacens Where x.empresa = mdlPublicVars.idEmpresa _
                                    Select Codigo = x.codigo, Nombre = x.nombre

                With cmbBodegaInicial
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = bodInicial
                End With

                Dim bodFinal = From x In conexion.tblAlmacens Where x.empresa = mdlPublicVars.idEmpresa _
                                    Select Codigo = x.codigo, Nombre = x.nombre

                With cmbBodegaFinal
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = bodFinal
                End With


            Catch ex As Exception
            End Try
            conn.Close()
        End Using

        fnLlenarInveFinal(cmbInventarioInicial.SelectedValue)
        fnLlenaMovimiento(rbtAjuste.Checked)
    End Sub

    Private Sub grdProductos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdProductos.KeyPress

        fnActualizar_Total()
    End Sub

    Public Sub fnActualizar_Total()
        Dim filas As Integer = 0
        If bitModificar = True Then
            For index As Integer = 0 To Me.grdProductos.Rows.Count - 1
                Dim elimina As Integer = CType(Me.grdProductos.Rows(index).Cells("elimina").Value, Integer)
                If elimina = 0 Then
                    filas += 1
                End If
            Next
        Else
            filas = Me.grdProductos.Rows.Count
        End If

        lblRecuento.Text = filas

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                If Me.grdProductos.Rows.Count > 0 Then

                    Dim suma As Double = 0
                    Dim sumaPositivo As Double = 0
                    Dim sumaNegativo As Double = 0

                    Dim tipoMovimiento As Integer = 0

                    Dim cantidad As Double = 0
                    Dim precio As Double = 0
                    Dim total As Double = 0
                    Dim elimina As Integer = 0
                    For index As Integer = 0 To Me.grdProductos.Rows.Count - 1
                        elimina = CType(Me.grdProductos.Rows(index).Cells("elimina").Value, Integer)
                        tipoMovimiento = CType(Me.grdProductos.Rows(index).Cells("tipoMovimiento").Value, Integer)
                        cantidad = CType(Me.grdProductos.Rows(index).Cells("txmCantidad").Value, Double)
                        precio = CType(Me.grdProductos.Rows(index).Cells("txmCosto").Value, Double)

                        If elimina = 0 Then
                            'Vemos si el tipo movimiento es de aumento o de disminucion
                            Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes.AsEnumerable Where x.idTipoMovimiento = tipoMovimiento Select x).FirstOrDefault

                            If (cantidad * precio) = 0 Then
                                Me.grdProductos.Rows(index).Cells("Total").Value = "0"
                                total = 0
                            Else
                                Me.grdProductos.Rows(index).Cells("Total").Value = Format(cantidad * precio, mdlPublicVars.formatoMoneda).ToString
                                total = CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)

                                If tipoMov.aumentaInventario = True Then
                                    sumaPositivo += CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                                ElseIf tipoMov.disminuyeInventario = True Then
                                    sumaNegativo += CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                                End If
                            End If

                        End If
                    Next
                    suma = sumaPositivo - sumaNegativo

                    lblTotal.Text = Format(suma, mdlPublicVars.formatoMoneda)
                    lblPositivo.Text = Format(sumaPositivo, mdlPublicVars.formatoMoneda)
                    lblNegativo.Text = Format(-sumaNegativo, mdlPublicVars.formatoMoneda)
                    If suma = 0 Then
                        lblTotal.Text = Format(0, mdlPublicVars.formatoMoneda)
                    End If

                    If sumaNegativo = 0 Then
                        lblNegativo.Text = Format(0, mdlPublicVars.formatoMoneda)
                    End If

                    If sumaPositivo = 0 Then
                        lblPositivo.Text = Format(0, mdlPublicVars.formatoMoneda)
                    End If
                Else
                    lblTotal.Text = 0
                End If
            Catch ex As Exception
            End Try

            conn.Close()
        End Using

    End Sub

    Public Sub fnAgregar_Articulos()
        'agregar productos a grid.
        Dim filas() As String

        If mdlPublicVars.bitUnidadMedida_Activado = True Then
            'id, codigo,nombre,precio,cantidad
            filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchIdUnidadMedida, mdlPublicVars.superSearchUnidadMedida, mdlPublicVars.superSearchUnidadMedidaValor, "", "", mdlPublicVars.superSearchCantidad, Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", "0"}
            grdProductos.Rows.Add(filas)
            grdProductos.Columns(6).IsCurrent = True
            grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
            fnActualizar_Total()
        Else
            'id, codigo,nombre,precio,cantidad

            Dim uni As tblUnidadMedida = (From x In ctx.tblUnidadMedidas Where x.idunidadMedida = mdlPublicVars.UnidadMedidaDefault Select x).FirstOrDefault

            filas = {"0", mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.UnidadMedidaDefault, uni.nombre, "1", "", "", mdlPublicVars.superSearchCantidad, Format(mdlPublicVars.superSearchPrecio, mdlPublicVars.formatoMoneda), "0", "0"}
            grdProductos.Rows.Add(filas)
            grdProductos.Columns(6).IsCurrent = True
            grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
            fnActualizar_Total()
        End If
        
    End Sub


    Private Sub fnLlenarInveFinal(ByVal inveInicial As Integer)

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim inveFinal = From x In conexion.tblTipoInventarios Where x.idTipoinventario <> inveInicial _
                                Select codigo = x.idTipoinventario, nombre = x.nombre

            With cmbInventarioFinal
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = inveFinal
            End With

            conn.Close()
        End Using

    End Sub

    Private Sub cmbInventarioInicial_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInventarioInicial.SelectedValueChanged
        fnLlenarInveFinal(cmbInventarioInicial.SelectedValue)
    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Try
            If e.Column.Name = "txmCodigo" Then

                If e.Value IsNot Nothing Then
                    Dim codigo As String = e.Value

                    If codigo.Length > 0 Then
                        fnBuscarArticulo(codigo, e.RowIndex)
                    End If
                End If

            End If

            If e.Column.Name = "txmCantidad" Or e.Column.Name = "txmCosto" Then
                fnActualizar_Total()
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Buscar Articulo Unico
    Public Sub fnBuscarArticulo(ByVal codigo As String, ByVal posicion As Integer)
        Try
            'Buscamos el articulo en base al codigo
            Dim articulo As tblArticulo
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                articulo = (From x In conexion.tblArticuloes Where x.codigo1 = codigo And x.empresa = mdlPublicVars.idEmpresa _
                                              Select x).FirstOrDefault

                conn.Close()
            End Using


            If articulo Is Nothing Then
                RadMessageBox.Show("Este producto no existe ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Me.grdProductos.Rows(posicion).Cells("iddetalle").Value = "0"
                Me.grdProductos.Rows(posicion).Cells("id").Value = articulo.idArticulo
                Me.grdProductos.Rows(posicion).Cells("txmCodigo").Value = articulo.codigo1
                Me.grdProductos.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                Me.grdProductos.Rows(posicion).Cells("tipoMovimiento").Value = ""
                Me.grdProductos.Rows(posicion).Cells("txbConcepto").Value = ""
                Me.grdProductos.Rows(posicion).Cells("txmCantidad").Value = "0"
                Me.grdProductos.Rows(posicion).Cells("txmCosto").Value = Format(articulo.costoIVA, mdlPublicVars.formatoMoneda)
                Me.grdProductos.Rows(posicion).Cells("Total").Value = 0
                Me.grdProductos.Rows(posicion).Cells("elimina").Value = 0
                Me.fnNuevaFila()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMovimiento_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'fnEstableceCorrelativo(cmbMovimiento.SelectedValue)
    End Sub

    Public Function fnErrores() As Boolean

        Dim bitAjustarTodos As Boolean = False
        Dim bitPreguntaAjuste As Boolean = False
        Dim bitErrores As Boolean = False

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            'Recorremos el grid para verificar si tiene concepto
            Dim i
            For i = 0 To Me.grdProductos.Rows.Count - 1
                Dim nombre As String = Me.grdProductos.Rows(i).Cells("txbProducto").Value

                If nombre IsNot Nothing Then
                    'Obtenemos el id del movimiento
                    Dim tipoMovimiento As Integer = 0
                    Try
                        tipoMovimiento = CInt(Me.grdProductos.Rows(i).Cells("tipoMovimiento").Value)

                        If rbtAjuste.Checked = True Then
                            Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes Where x.idTipoMovimiento = tipoMovimiento Select x).FirstOrDefault

                            Dim id As Integer = CType(Me.grdProductos.Rows(i).Cells("Id").Value, Integer)
                            Dim inveInicial As Integer = CType(cmbInventarioInicial.SelectedValue, Integer)
                            Dim cantidad As Integer = CType(Me.grdProductos.Rows(i).Cells("txmcantidad").Value, Integer)

                            'Depende al tipo movimiento y al inventario final, aumentaremos o dismuniremos los articulos
                            Dim inventario1 As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = id And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                              And x.IdAlmacen = General_idAlmacenPrincipal And x.idTipoInventario = inveInicial Select x).FirstOrDefault

                            If (inventario1.saldo < cantidad) And tipoMov.disminuyeInventario = True And mdlPublicVars.ExistenciaCero = False Then

                                If bitPreguntaAjuste = False Then
                                    If MessageBox.Show("Se detectaron articulos con cantidad mayor al saldo desea realizar un ajuste automatico", nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                        bitAjustarTodos = True
                                        bitPreguntaAjuste = True
                                    End If
                                End If

                                If bitAjustarTodos = True Then
                                    Me.grdProductos.Rows(i).Cells("txmCantidad").Value = inventario1.saldo
                                Else
                                    If MessageBox.Show("Desea Ajustar el articulo : " & inventario1.tblArticulo.nombre1 & " de :" & cantidad & " a :" & inventario1.saldo, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                        Me.grdProductos.Rows(i).Cells("txmCantidad").Value = inventario1.saldo
                                    End If
                                End If

                            End If
                        End If
                    Catch ex As Exception
                        alerta.contenido = "Debe de ingresar un concepto!, corrija ERROR!"
                        alerta.fnErrorContenido()
                        Me.grdProductos.Rows(i).Cells("txbConcepto").IsSelected = True
                        bitErrores = True

                    End Try

                End If
            Next

            conn.Close()
        End Using

        'verificar si hay errores.
        If bitErrores = False Then
            fnActualizar_Total()
        End If



        Return False
    End Function

    Public Sub fnNuevo()
        Me.grdProductos.Rows.Clear()
        Me.grdProductos.AllowDeleteRow = True
        txtObservacion.Text = ""
        rbtAjuste.Enabled = True
        rbtTraslado.Enabled = True
        rbtAjuste.Checked = True
        lblTotal.Text = "0.00"
        lblPositivo.Text = "0.00"
        lblNegativo.Text = "0.00"
        lblRecuento.Text = "0"
        FnLlenar_combos()
        fnEstablecerCorrelativo()
        fnActualizar_Total()
        fnNuevaFila()
    End Sub

    Private Sub fnGuardarMovimiento()
        Dim contador As Integer = 0
        Dim success As Boolean = True
        Dim bitErrorSistema As Boolean = False
        Dim msj As String = ""

        'Dim tipoMovimiento As Integer = CType(cmbMovimiento.SelectedValue, Integer)
        Dim inveInicial As Integer = CType(cmbInventarioInicial.SelectedValue, Integer)
        Dim inveFinal As Integer = CType(cmbInventarioFinal.SelectedValue, Integer)
        Dim bodInical As Integer = CType(cmbBodegaInicial.SelectedValue, Integer)
        Dim bodFinal As Integer = CType(cmbBodegaFinal.SelectedValue, Integer)
        Dim idSalida As Integer = 0
        Dim idEntrada As Integer = 0
        Dim cantidadInsuficiente As Boolean = False
        Dim nombreArticuloInsuficiente As String = ""
        Dim cantidadRequerida As Decimal = 0
        Dim existencia As Integer = 0
        Dim fechaServidor As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
        Dim hora As String = mdlPublicVars.fnHoraServidor
        Dim idCorrelativo As String = ""
        If fnErrores() = True Then
            Exit Sub
        End If

        If RadMessageBox.Show("¿Desea guardar el registro?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
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
                    'Obtenemos el correlativo de la compra
                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = Ajuste_CodigoMovimiento _
                                                         Select x).FirstOrDefault

                    If correlativo IsNot Nothing Then
                        correlativo.correlativo += 1
                        conexion.SaveChanges()
                        idCorrelativo = correlativo.serie & correlativo.correlativo
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

                    'Creamos el encabezado del movimiento
                    '--------ENCABEZADO MOVIMIENTO-------------
                    Dim movimiento As New tblMovimientoInventario
                    movimiento.empresa = mdlPublicVars.idEmpresa
                    movimiento.usuario = mdlPublicVars.idUsuario
                    movimiento.almacen = bodInical
                    movimiento.almacenFinal = bodFinal
                    'movimiento.documento = txtDocumento.Text
                    movimiento.bitBodega = True
                    movimiento.bitVenta = False
                    movimiento.tipoMovimiento = mdlPublicVars.Ajuste_CodigoMovimiento
                    movimiento.correlativo = idCorrelativo
                    movimiento.revisado = False
                    If rbtAjuste.Checked = True Then
                        movimiento.inventarioInicial = inveInicial
                        movimiento.inventarioFinal = inveInicial
                        movimiento.ajuste = 1
                        movimiento.traslado = 0
                    Else
                        movimiento.inventarioInicial = inveInicial
                        movimiento.inventarioFinal = inveFinal
                        movimiento.traslado = 1
                        movimiento.ajuste = 0
                    End If
                    movimiento.anulado = 0

                    movimiento.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                    movimiento.fechaTransaccion = fechaServidor
                    movimiento.observacion = txtObservacion.Text

                    conexion.AddTotblMovimientoInventarios(movimiento)
                    conexion.SaveChanges()

                    Dim codigoMovimiento As Integer = movimiento.codigo
                    '----------FIN DE ENCABEZADO---------------

                    '-----------DETALLE MOVIMIENTO---------------
                    Dim index As Integer
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        contador = contador + 1
                        Dim articulo As Integer = CType(Me.grdProductos.Rows(index).Cells("Id").Value, Integer)
                        Dim cantidad As Double = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Double)
                        Dim tipoMovimiento As Integer = 0
                        Dim valmedida As Integer = 1 'CType(Me.grdProductos.Rows(index).Cells("valorUnidadMedida").Value, Double)
                        Dim idmedida As Integer = 1 'CType(Me.grdProductos.Rows(index).Cells("idUnidadMedida").Value, Integer)
                        Try
                            tipoMovimiento = CType(Me.grdProductos.Rows(index).Cells("tipoMovimiento").Value, Integer)
                        Catch ex As Exception
                            tipoMovimiento = 0
                        End Try

                        Dim costo As Double = CType(Me.grdProductos.Rows(index).Cells("txmCosto").Value, Double)
                        Dim total As Double = CType(Me.grdProductos.Rows(index).Cells("total").Value, Double)
                        Dim nombre As String = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)

                        If nombre IsNot Nothing Then
                            If tipoMovimiento = 0 Then
                                bitErrorSistema = True
                                msj = "Debe agregar un concepto, para el articulo " & articulo
                                success = False
                                Exit Try
                            End If


                            'Creamos el nuevo detalle del movimiento
                            Dim detalle As New tblMovimientoInventarioDetalle
                            detalle.movimientoInventario = codigoMovimiento
                            detalle.articulo = articulo
                            detalle.cantidad = cantidad
                            detalle.idunidadmedida = UnidadMedidaDefault
                            detalle.valormedida = valmedida
                            detalle.tipoMovimiento = tipoMovimiento
                            detalle.costo = costo
                            detalle.total = total

                            'Verificamos si es entrada o salida
                            Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes Where x.idTipoMovimiento = tipoMovimiento Select x).FirstOrDefault
                            If tipoMov.aumentaInventario = True Then
                                detalle.entrada = True
                                detalle.salida = False
                            ElseIf tipoMov.disminuyeInventario = True Then
                                detalle.salida = True
                                detalle.entrada = False
                            End If
                            conexion.AddTotblMovimientoInventarioDetalles(detalle)
                            conexion.SaveChanges()

                            'Depende al tipo movimiento y al inventario final, aumentaremos o dismuniremos los articulos
                            Dim inventario1 As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                              And x.IdAlmacen = bodInical And x.idTipoInventario = inveInicial Select x).FirstOrDefault



                            Dim inventario2 As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                              And x.IdAlmacen = bodFinal And x.idTipoInventario = inveFinal Select x).FirstOrDefault


                            If rbtAjuste.Checked Then
                                If tipoMov.aumentaInventario Then
                                    inventario1.saldo += cantidad * valmedida
                                    inventario1.entrada += cantidad * valmedida
                                    conexion.SaveChanges()

                                ElseIf tipoMov.disminuyeInventario = True Then
                                    'Verificamos si existe esa cantidad de producto

                                    If inventario1.saldo >= cantidad * valmedida Or mdlPublicVars.ExistenciaCero = True Then
                                        inventario1.saldo -= cantidad * valmedida
                                        inventario1.salida += cantidad * valmedida
                                        conexion.SaveChanges()
                                    Else
                                        If RadMessageBox.Show("Desea Ajustar el articulo : " & inventario1.tblArticulo.nombre1 & " de :" & cantidad * valmedida & " a :" & inventario1.saldo, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                            detalle.cantidad = inventario1.saldo
                                            detalle.total = detalle.cantidad * detalle.costo
                                            inventario1.saldo = 0
                                            inventario1.salida += detalle.cantidad
                                            conexion.SaveChanges()
                                        Else
                                            cantidadInsuficiente = True
                                            nombreArticuloInsuficiente = inventario1.tblArticulo.nombre1
                                            cantidadRequerida = cantidad * valmedida
                                            existencia = inventario1.saldo
                                            success = False
                                            bitErrorSistema = True
                                            msj = "Existencia Insuficiente !!!" & vbCrLf & "Articulo : " & inventario1.tblArticulo.nombre1 & vbCrLf & "Saldo : " & inventario1.saldo _
                                                & vbCrLf & "Cantidad Ajuste : " & cantidad * valmedida & vbCrLf & "Diferencia : " & (inventario1.saldo - cantidad * valmedida)
                                            Exit Try
                                        End If

                                    End If
                                End If
                                'Modificamos la fecha de ultimo ajuste del articulo
                                inventario1.tblArticulo.fechaUltAjuste = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                                conexion.SaveChanges()

                                'Modificamos el costo promedio del articulo
                                If tipoMov.actualizaCosto Then
                                    Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = detalle.articulo).First

                                    Dim precios As Double = 0

                                    If inventario1 IsNot Nothing Then
                                        precios = (producto.costoIVA * inventario1.saldo) + (detalle.costo * cantidad)
                                        producto.costoIVA = precios / (inventario1.saldo + cantidad)
                                        producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                    Else
                                        If cantidad > 0 Then
                                            precios = (detalle.costo * cantidad)
                                            producto.costoIVA = precios / cantidad
                                            producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                                        End If
                                    End If
                                    conexion.SaveChanges()
                                End If
                            Else
                                If inventario1.saldo >= cantidad * valmedida Then
                                    inventario1.saldo -= cantidad * valmedida
                                    inventario1.salida += cantidad * valmedida
                                    conexion.SaveChanges()
                                    'Si no existe el registro del articulo en el invetario lo creamos, y aumentamos o dismminimos el saldo
                                    If inventario2 Is Nothing Then
                                        Dim nuevoInventario As New tblInventario
                                        nuevoInventario.idArticulo = articulo
                                        nuevoInventario.IdAlmacen = bodFinal
                                        nuevoInventario.idTipoInventario = inveFinal

                                        nuevoInventario.entrada = cantidad * valmedida
                                        nuevoInventario.saldo = cantidad * valmedida
                                        nuevoInventario.reserva = 0
                                        nuevoInventario.salida = 0
                                        nuevoInventario.transito = 0
                                        conexion.AddTotblInventarios(nuevoInventario)
                                        nuevoInventario.tblArticulo.fechaUltAjuste = fechaServidor
                                        conexion.SaveChanges()
                                    Else
                                        inventario2.saldo += cantidad * valmedida
                                        inventario2.entrada += cantidad * valmedida
                                        conexion.SaveChanges()
                                        'Si existe el articulo le aumentamos o dismnuimos el saldo
                                    End If
                                Else
                                    cantidadInsuficiente = True
                                    nombreArticuloInsuficiente = inventario1.tblArticulo.nombre1
                                    cantidadRequerida = cantidad * valmedida
                                    existencia = inventario1.saldo

                                    success = False
                                    bitErrorSistema = True
                                    msj = "Existencia Insuficiente !!!" & vbCrLf & "Articulo : " & inventario1.tblArticulo.nombre1 & vbCrLf & "Saldo : " & inventario1.saldo _
                                        & vbCrLf & "Cantidad Ajuste : " & cantidad * valmedida & vbCrLf & "Diferencia : " & (inventario1.saldo - cantidad * valmedida)
                                    Exit Try
                                End If
                                'Modificamos la fecha de ultimo ajuste del articulo
                                inventario1.tblArticulo.fechaUltAjuste = fechaServidor
                                If inventario2 IsNot Nothing Then
                                    inventario2.tblArticulo.fechaUltAjuste = fechaServidor
                                End If


                            End If
                        End If
                    Next

                    'GUARDAR TODOS LOS CAMBIOS.
                    conexion.SaveChanges()
                    'paso 8, completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    success = False
                    MessageBox.Show("No se Guardo el Registro :" + vbCrLf + ex.ToString, mdlPublicVars.nombreSistema)
                Catch ex As Exception
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        success = False
                        MessageBox.Show("No se Guardo el Registro :" + vbCrLf + ex.ToString, mdlPublicVars.nombreSistema)

                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using

            If success = True And bitErrorSistema = False Then
                conexion.AcceptAllChanges()
                alerta.contenido = "Registro guardado correctamente"
                alerta.fnGuardar()
            Else

                If bitErrorSistema = True Then
                    RadMessageBox.Show(msj, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                Else
                    alerta.fnError()
                End If

            End If
            conn.Close()
        End Using


        If success = True And bitErrorSistema = False Then
            fnNuevo()
        End If
    End Sub

    Public Sub fnModificarMovimiento()
        Dim success As Boolean = True
        'Dim tipoMovimiento As Integer = CType(cmbMovimiento.SelectedValue, Integer)
        Dim inveInicial As Integer = CType(cmbInventarioInicial.SelectedValue, Integer)
        Dim inveFinal As Integer = CType(cmbInventarioFinal.SelectedValue, Integer)
        Dim idSalida As Integer = 0
        Dim idEntrada As Integer = 0
        Dim fechaTransaccion As DateTime = fnFecha_horaServidor()

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
                    'Obtenemos el encabezado del movimiento,para realizar las modificaciones
                    '--------ENCABEZADO MOVIMIENTO-------------
                    Dim movimiento As tblMovimientoInventario = (From x In conexion.tblMovimientoInventarios Where x.codigo = idMovimiento Select x).FirstOrDefault
                    movimiento.empresa = mdlPublicVars.idEmpresa
                    movimiento.usuario = mdlPublicVars.idUsuario
                    ''movimiento.almacen = mdlPublicVars.General_idAlmacenPrincipal
                    ''movimiento.documento = txtDocumento.Text
                    movimiento.revisado = False
                    movimiento.fechaTransaccion = fechaTransaccion
                    movimiento.observacion = txtObservacion.Text
                    conexion.SaveChanges()

                    Dim codigoMovimiento As Integer = movimiento.codigo
                    '----------FIN DE ENCABEZADO---------------

                    '-----------DETALLE MOVIMIENTO---------------
                    Dim index As Integer
                    For index = 0 To Me.grdProductos.Rows.Count - 1
                        Dim idDetalle As Integer = CType(Me.grdProductos.Rows(index).Cells("iddetalle").Value, Integer)
                        Dim elimina As Integer = CType(Me.grdProductos.Rows(index).Cells("elimina").Value, Integer)
                        Dim articulo As Integer = CType(Me.grdProductos.Rows(index).Cells("Id").Value, Integer)
                        Dim cantidad As Double = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Double)
                        Dim tipoMovimiento As Integer = CType(Me.grdProductos.Rows(index).Cells("tipoMovimiento").Value, Integer)
                        Dim costo As Double = CType(Me.grdProductos.Rows(index).Cells("txmCosto").Value, Double)
                        Dim total As Double = CType(Me.grdProductos.Rows(index).Cells("total").Value, Double)

                        If articulo > 0 Then
                            If elimina > 0 Then
                                Dim detalle As tblMovimientoInventarioDetalle = (From x In conexion.tblMovimientoInventarioDetalles Where x.codigo = idDetalle Select x).FirstOrDefault
                                conexion.DeleteObject(detalle)
                                conexion.SaveChanges()
                            ElseIf idDetalle > 0 Then

                                'Obtenemos el detalle del movimiento
                                Dim detalle As tblMovimientoInventarioDetalle = (From x In conexion.tblMovimientoInventarioDetalles Where x.codigo = idDetalle Select x).FirstOrDefault

                                detalle.movimientoInventario = codigoMovimiento
                                detalle.articulo = articulo
                                detalle.cantidad = cantidad
                                detalle.tipoMovimiento = tipoMovimiento
                                detalle.costo = costo
                                detalle.total = total

                                'Verificamos si es estrada o salida
                                Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes Where x.idTipoMovimiento = tipoMovimiento Select x).FirstOrDefault
                                If tipoMov.aumentaInventario = True Then
                                    detalle.entrada = True
                                ElseIf tipoMov.disminuyeInventario = True Then
                                    detalle.salida = True
                                End If
                                conexion.SaveChanges()

                            Else
                                'Si no existe el detalle lo creamos
                                Dim detalle As New tblMovimientoInventarioDetalle

                                detalle.movimientoInventario = codigoMovimiento
                                detalle.articulo = articulo
                                detalle.cantidad = cantidad
                                detalle.tipoMovimiento = tipoMovimiento
                                detalle.costo = costo
                                detalle.total = total

                                'Verificamos si es estrada o salida
                                Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes Where x.idTipoMovimiento = tipoMovimiento Select x).FirstOrDefault
                                If tipoMov.aumentaInventario = True Then
                                    detalle.entrada = True
                                ElseIf tipoMov.disminuyeInventario = True Then
                                    detalle.salida = True
                                End If

                                conexion.AddTotblMovimientoInventarioDetalles(detalle)
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
            fnNuevaFila()

        End If
    End Sub

    Private Sub fnLlenaMovimiento(ByVal ajuste As Boolean)
        If ajuste = True Then
            cmbInventarioFinal.Enabled = False
            cmbBodegaFinal.Enabled = False
        Else
            cmbInventarioFinal.Enabled = True
            cmbBodegaFinal.Enabled = True
        End If

    End Sub

    Private Sub rbtAjuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAjuste.CheckedChanged, rbtTraslado.CheckedChanged
        If verRegistro = False Then
            fnLlenaMovimiento(rbtAjuste.Checked)
        End If
    End Sub

    Private Sub fnConcepto()
        Dim consulta

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            If rbtAjuste.Checked = True Then
                consulta = (From x In conexion.tblTipoMovimientoes Where x.ajuste And Not x.ajusteVenta Select codigo = x.idTipoMovimiento, nombre = x.nombre)
            Else
                consulta = (From x In conexion.tblTipoMovimientoes Where x.traslado And Not x.ajusteVenta Select codigo = x.idTipoMovimiento, nombre = x.nombre)
            End If

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
        frmCombo.Text = "Concepto"
        frmCombo.ShowDialog()

        If mdlPublicVars.superSearchId > 0 And Me.grdProductos.Rows.Count > 0 Then
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("tipoMovimiento").Value = mdlPublicVars.superSearchId
            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbconcepto").Value = mdlPublicVars.superSearchNombre
        End If
    End Sub

    'Maneja el evento de la tecla DELETE
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If bitModificar = True And verRegistro = False Then
            mdlPublicVars.fnGrid_EliminarFila(sender, e, grdProductos, "iddetalle")

            fnActualizar_Total()
        End If

        If e.KeyCode = Keys.F2 And verRegistro = False Then

            If Me.grdProductos.Columns("txbUnidadMedida").IsCurrent Then
                mdlPublicVars.superSearchId = 0
                mdlPublicVars.superSearchNombre = ""
                fnConceptoUnidad()
                fnActualizar_Total()
                ''If e.KeyCode = Keys.F2 Then

            ElseIf Me.grdProductos.Columns("txbconcepto").IsCurrent Then
                mdlPublicVars.superSearchId = 0
                mdlPublicVars.superSearchNombre = ""
                fnConcepto()
                fnActualizar_Total()
            Else
                Dim idinventario As Integer = mdlPublicVars.General_idTipoInventario
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdProductos)
                mdlPublicVars.General_idTipoInventario = cmbInventarioInicial.SelectedValue
                If Me.grdProductos.Rows(fila).Cells("txbProducto").Value Is Nothing Then
                    mdlPublicVars.superSearchNombre = ""
                Else
                    mdlPublicVars.superSearchNombre = LTrim(RTrim(Me.grdProductos.Rows(fila).Cells("txbProducto").Value))
                End If
                If mdlPublicVars.bitUnidadMedida_Activado = True Then

                    frmBuscarArticulo2.OpcionRetorno = "movimientoInventario"
                    frmBuscarArticulo2.Text = "Buscar Articulos"
                    frmBuscarArticulo2.bitMovimientoInventario = True
                    frmBuscarArticulo2.bitProduccion = True
                    frmBuscarArticulo2.bitProduccionSalida = False
                    frmBuscarArticulo2.bitProduccionEntrada = False
                    frmBuscarArticulo2.idTipoInventario = Me.cmbInventarioInicial.SelectedValue
                    frmBuscarArticulo2.idBodega = Me.cmbBodegaInicial.SelectedValue
                    frmBuscarArticulo2.venta = 0
                    permiso.PermisoFrmEspeciales(frmBuscarArticulo2, False)

                    mdlPublicVars.General_idTipoInventario = idinventario

                Else

                    frmBuscarArticulo.OpcionRetorno = "movimientoInventario"
                    frmBuscarArticulo.Text = "Buscar Articulos"
                    frmBuscarArticulo.bitMovimientoInventario = True
                    frmBuscarArticulo.idInventario = Me.cmbInventarioInicial.SelectedValue
                    frmBuscarArticulo.idBodega = Me.cmbBodegaInicial.SelectedValue
                    frmBuscarArticulo.venta = 0
                    permiso.PermisoFrmEspeciales(frmBuscarArticulo, False)

                    mdlPublicVars.General_idTipoInventario = idinventario
                End If

            End If
        End If

    End Sub

    'NUEVO
    Private Sub pbx0Nuevo_Click() Handles Me.panel0
        Try
            fnNuevo()
        Catch ex As Exception

        End Try
    End Sub

    'GUARDAR
    Private Sub pbxGuardar_Click() Handles Me.panel1
        If lbl1Guardar.Text = "Guardar" Then

            Dim validacion As Boolean = False

            If rbtTraslado.Checked Then
                validacion = fnVerificarSaldos()
            End If

            If validacion = False Then
                fnGuardarMovimiento()
            Else
                Exit Sub
            End If
        Else
            fnModificarMovimiento()
        End If
    End Sub

    Private Sub pbxSalir_Click() Handles Me.panel2
        If RadMessageBox.Show("Esta Seguro de Salir", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    'Funcion que se utiliza para remover la fila actual
    Public Sub fnRemoverFila()
        If Me.grdProductos.CurrentRow.Index = -1 Then
            Exit Sub
        End If

        Dim filaActual As Integer = CType(Me.grdProductos.CurrentRow.Index, Integer)

        If filaActual >= 0 Then
            Dim index
            Dim yaBorro As Boolean = False

            For index = filaActual To Me.grdProductos.Rows.Count - 1
                Dim codigoArt As Integer = CType(Me.grdProductos.Rows(filaActual).Cells("Id").Value, Integer)
                If Not yaBorro Then
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

    Private Sub frmMovimientoInventarios_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmMovimientoInventariosLista.frm_llenarLista()
    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        Try
            If Me.grdProductos.Rows.Count = 0 Then
                Me.grdProductos.Rows.AddNew()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Importar 
    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
        Try
            frmImportar.Text = "Importar"
            frmImportar.bitMovInventario = True
            frmImportar.ShowDialog()

            Dim tblR As DataTable = frmImportar.tblRetorno
            frmImportar.Dispose()
            If tblR.Rows.Count > 0 Then
                'buscar fila con id en blanco.
                Dim filaBlanco As Integer = -1


                For index As Integer = 0 To Me.grdProductos.Rows.Count - 1
                    If Me.grdProductos.Rows(index).Cells("id").Value Is Nothing Then
                        Me.grdProductos.Rows.RemoveAt(index)
                    ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)).Length = 0 Then
                        filaBlanco = index
                    ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)).Length = 1 And LTrim(RTrim(Me.grdProductos.Rows(index).Cells("id").Value.ToString)) = 0 Then
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
                    Me.grdProductos.Rows(filaBlanco).Cells("txmCosto").Value = tblR.Rows(0).Item("Costo")
                    Me.grdProductos.Rows(filaBlanco).Cells("tipoMovimiento").Value = tblR.Rows(0).Item("idTipoMovimiento")
                    Me.grdProductos.Rows(filaBlanco).Cells("txbConcepto").Value = tblR.Rows(0).Item("Concepto")
                    inicio = 1
                End If

                'agregar los elementos restantes al grid.
                For index As Integer = inicio To tblR.Rows.Count - 1
                    Me.grdProductos.Rows.Add(0, tblR.Rows(index).Item("id"), tblR.Rows(index).Item("Codigo"), tblR.Rows(index).Item("Nombre"),
                                             1, "Unidad Medida", 1, tblR.Rows(index).Item("idTipoMovimiento"), tblR.Rows(index).Item("Concepto"), tblR.Rows(index).Item("Cantidad"),
                                             tblR.Rows(index).Item("Costo"), 0, 0)
                Next
                fnActualizar_Total()
                Me.grdProductos.Rows.AddNew()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Function fnVerificarSaldos()

        Dim inventariosalida As Integer
        Dim bodegasalida As Integer
        ''Dim filas As Integer = Me.grdProductos.Rows.Count - 1
        Dim filas As Integer = Me.grdProductos.RowCount - 1

        inventariosalida = cmbInventarioInicial.SelectedValue
        bodegasalida = cmbBodegaInicial.SelectedValue

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            For index As Integer = 0 To filas

                Dim cantidad As Integer = 0
                Dim idarticulo As Integer = 0

                cantidad = Me.grdProductos.Rows(index).Cells("txmCantidad").Value
                idarticulo = Me.grdProductos.Rows(index).Cells("Id").Value

                Dim existencia As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = idarticulo And x.idTipoInventario = inventariosalida And x.IdAlmacen = bodegasalida Select x).FirstOrDefault


                If cantidad > 0 Then
                    If cantidad > existencia.saldo Then
                        RadMessageBox.Show("El Producto: " & LTrim(RTrim(existencia.tblArticulo.nombre1)) & " no tiene saldo suficiente. Existencia: " & CInt(existencia.saldo), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        Return True
                        Exit Function
                    Else

                    End If
                End If
            Next

            conn.Close()
        End Using
        Return False
    End Function

    Private Sub fnConceptoUnidad()
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
                frmSeleccion.bitVenta = False
                frmSeleccion.bitMovimientoInventario = True
                frmSeleccion.StartPosition = FormStartPosition.CenterScreen
                frmSeleccion.ShowDialog()
                frmSeleccion.Dispose()

                If mdlPublicVars.superSearchIdUnidadMedida > 0 Then
                    Me.grdProductos.Rows(fila).Cells("IdUnidadMedida").Value = mdlPublicVars.superSearchIdUnidadMedida
                    Me.grdProductos.Rows(fila).Cells("txbUnidadMedida").Value = mdlPublicVars.superSearchUnidadMedida
                    Me.grdProductos.Rows(fila).Cells("ValorUnidadMedida").Value = mdlPublicVars.superSearchUnidadMedidaValor
                    If mdlPublicVars.bitUnidadMedida_Activado = True Then
                        Me.grdProductos.Rows(fila).Cells("txmCosto").Value = Format(mdlPublicVars.superSearchCosto, formatoMoneda)
                    Else
                        Me.grdProductos.Rows(fila).Cells("txbPrecioBase").Value = Format(mdlPublicVars.superSearchPrecio, formatoMoneda)
                    End If
                End If
            End If

            conn.Close()
        End Using
    End Sub

End Class
