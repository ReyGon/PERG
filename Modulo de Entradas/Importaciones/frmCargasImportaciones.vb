Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Transactions
Imports System.Linq

Public Class frmCargasImportaciones

    Private _Invoice As Integer

    Public Property Invoice As Integer
        Get
            Invoice = _Invoice
        End Get
        Set(value As Integer)
            _Invoice = value
        End Set
    End Property


    Private Sub frmCargasImportaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtFiltroArticulo.Enabled = False
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)

            fnDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim i As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = Invoice Select x).FirstOrDefault

                lblInvoice.Text = i.serieDocumento + "-" + i.documento

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImportacion_Click(sender As Object, e As EventArgs) Handles btnImportacion.Click
        Try
            frmImportarImportaciones.Text = "Importar"
            frmImportarImportaciones.bitEntrada = True
            frmImportarImportaciones.ShowDialog()

            Dim tblR As DataTable = frmImportarImportaciones.tblRetorno
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
                    Me.grdProductos.Rows(filaBlanco).Cells(5).Value = tblR.Rows(0).Item(4)

                    inicio = 1
                End If

                Dim idarticulo As Integer
                Dim cajano As String
                Dim costo As Decimal

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                'agregar los elementos restantes al grid.
                For index = inicio To tblR.Rows.Count - 1

                    idarticulo = tblR.Rows(index).Item(0)
                    cajano = tblR.Rows(index).Item(7)

                        costo = (From x In conexion.tblEntradasDetalles Where x.idEntrada = Invoice And x.nocaja.Equals(cajano) And x.idArticulo = idarticulo Select x.costoIVA).FirstOrDefault

                        Me.grdProductos.Rows.Add(tblR.Rows(index).Item(0), tblR.Rows(index).Item(7), tblR.Rows(index).Item(1), tblR.Rows(index).Item(2), tblR.Rows(index).Item(3), Format(CType(costo, Double), formatoNumero), Format(tblR.Rows(index).Item(3) * CDec(costo), formatoNumero))
                Next

                    conn.Close()
                End Using

                Dim j As Integer
                Dim filas As Integer
                Dim costod As Decimal
                Dim cantidad As Integer
                filas = grdProductos.Rows.Count - 1

                For m As Integer = 0 To filas
                    costod = grdProductos.Rows(m).Cells("CostoTotal").Value

                    Dim lbtotalcarga As Decimal
                    Try
                        lbtotalcarga = Replace(lblTotalCarga.Text, "Q", "")
                    Catch ex As Exception
                        lbtotalcarga = 0
                    End Try

                    'lbltotaldolares.Text = lbltotaldolares.Text + costod
                    lblTotalCarga.Text = Format(CDec(If(lbtotalcarga = 0, 0, CDec(lbtotalcarga))) + (CDec(grdProductos.Rows(m).Cells("CostoTotal").Value)), mdlPublicVars.formatoMoneda)

                    ''''fnTotalProrrateo()
                    fnActualizar_Total()
                    ''Me.grdproductos.Rows.AddNew()

                Next

                fnEliminaVacias()
                fnConfiguracion()
                fnActivarFiltro()
                Me.grdProductos.Rows.AddNew()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnActivarFiltro()
        Try
            If Me.grdProductos.Rows.Count - 1 > 0 Then
                Me.txtFiltroArticulo.Enabled = True
            Else
                Me.txtFiltroArticulo.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            Me.grdProductos.Columns("Codigo").Width = 75
            Me.grdProductos.Columns("Producto").Width = 150
            Me.grdProductos.Columns("Cantidad").Width = 60
            Me.grdProductos.Columns("Costo").Width = 50
            Me.grdProductos.Columns("CostoTotal").Width = 50
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fnActualizar_Total()
        ''lblRecuento.Text = Me.grdproductos.Rows.Count

        Try
            If Me.grdproductos.Rows.Count > 0 Then
                Dim cantidad As Double = 0
                Dim precio As Double = 0
                Dim totalCompra As Double = 0

                For index As Integer = 0 To Me.grdproductos.Rows.Count - 1
                    Dim producto As String = CType(Me.grdProductos.Rows(index).Cells("Producto").Value, String)

                    If producto IsNot Nothing Then

                        cantidad = CType(Me.grdProductos.Rows(index).Cells("Cantidad").Value, Double)
                        precio = CType(Me.grdProductos.Rows(index).Cells("Costo").Value.ToString, Double)

                        If (cantidad * precio) = 0 Then
                            Me.grdProductos.Rows(index).Cells("CotoTotal").Value = "0"
                        Else
                            Me.grdProductos.Rows(index).Cells("CostoTotal").Value = Format(cantidad * precio, "###,###.##").ToString
                        End If

                        totalCompra += (cantidad * precio)

                    End If

                Next

                lblTotalCarga.Text = Format(totalCompra, mdlPublicVars.formatoMoneda)
            Else
                lblTotalCarga.Text = 0
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnEliminaVacias()
        Try
            If Me.grdproductos.Rows.Count > 0 Then
                'Recorremos el grid
                Dim nombre As String = ""
                For i As Integer = 0 To Me.grdproductos.Rows.Count - 1
                    'Obtenemo el valor del nombre
                    nombre = Me.grdProductos.Rows(i).Cells("Producto").Value
                    If IsNothing(nombre) Then
                        Me.grdproductos.Rows.RemoveAt(i)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtFiltroArticulo_Click(sender As Object, e As EventArgs) Handles txtFiltroArticulo.Click
        Try
            Me.txtFiltroArticulo.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFiltroArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltroArticulo.KeyDown
        Try

            If Me.txtFiltroArticulo.Text = "" Then

                For a As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    Me.grdProductos.Rows(a).IsVisible = True

                Next

            ElseIf Me.txtFiltroArticulo.Text <> "" Then

                For a As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    If Me.grdProductos.Rows(a).Cells("Producto").Value.ToString.ToLower.Contains(Me.txtFiltroArticulo.Text.ToString.ToLower) Then

                    Else
                        Me.grdProductos.Rows(a).IsVisible = False
                    End If

                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnGuardar() Handles Me.panel0
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                conexion.CommandTimeout = 100000

                Using transaction As New TransactionScope

                    Dim idinvoice As Integer = (From x In conexion.tblEntradas Where x.idEntrada = Invoice Select x.IdInvoiceNacionalizacion).FirstOrDefault

                    Dim inv As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = idinvoice Select x).FirstOrDefault

                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento _
                                                            And x.idEmpresa = mdlPublicVars.idEmpresa Select x).First

                    Dim numeroCorrelativo As String = 0

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

                    Dim identrada As Integer

                    Dim c As New tblEntrada

                    c.idEmpresa = inv.idEmpresa
                    c.idUsuario = mdlPublicVars.idUsuario
                    c.idTipoMovimiento = inv.idTipoMovimiento
                    c.idProveedor = inv.idProveedor
                    c.fechaRegistro = CDate(fnFecha_horaServidor())
                    c.fechaTransaccion = CDate(fnFecha_horaServidor())
                    c.fechaCompra = CDate(fnFecha_horaServidor())
                    c.serieDocumento = inv.serieDocumento
                    c.documento = inv.documento
                    c.observacion = "Precarga/Carga Importacion"
                    c.anulado = False
                    c.preforma = False
                    c.transito = False
                    c.compra = True
                    c.flete = 0
                    c.total = CDec(Replace(Me.lblTotalCarga.Text, "Q", ""))
                    c.correlativo = numeroCorrelativo
                    c.idtipoInventario = mdlPublicVars.General_idTipoInventario
                    c.idalmacen = mdlPublicVars.General_idAlmacenPrincipal
                    c.cancelado = False
                    c.saldo = CDec(Replace(Me.lblTotalCarga.Text, "Q", ""))
                    c.pagos = 0
                    c.credito = True
                    c.contado = False
                    c.usuarioCompra = mdlPublicVars.idUsuario
                    c.fechaFiltro = CDate(fnFecha_horaServidor())
                    c.preformaimportacion = False
                    c.IdPreformaInvoice = 0
                    c.Invoice = False
                    c.IdInvoiceNacionalizacion = 0
                    c.Nacionalizacion = False
                    c.finalizada = 1
                    c.IdNacionalizacion = Invoice

                    conexion.AddTotblEntradas(c)
                    conexion.SaveChanges()

                    identrada = c.idEntrada

                    ''El detalle de la compra

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
                    Dim cajano As String

                    For index = 0 To Me.grdProductos.Rows.Count - 1

                        idArticulo = Me.grdProductos.Rows(index).Cells("IdArticulo").Value
                        cantidad = Me.grdProductos.Rows(index).Cells("Cantidad").Value
                        costo = Me.grdProductos.Rows(index).Cells("Costo").Value
                        costopro = Me.grdProductos.Rows(index).Cells("CostoTotal").Value
                        valmedida = 1
                        idmedida = mdlPublicVars.UnidadMedidaDefault
                        nombreArticulo = Me.grdProductos.Rows(index).Cells("Producto").Value
                        cajano = Me.grdProductos.Rows(index).Cells("cajano").Value

                        Try
                            idDetalle = Me.grdProductos.Rows(index).Cells("idDetalle").Value
                        Catch ex As Exception
                            idDetalle = 0
                        End Try

                        If nombreArticulo IsNot Nothing Then

                            Dim detalleEntrada As New tblEntradasDetalle
                            detalleEntrada.idEntrada = identrada
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
                            detalleEntrada.nocaja = cajano

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
                                                               And x.idTipoInventario = c.idtipoInventario And x.IdAlmacen = c.idalmacen _
                                                               Select x).FirstOrDefault

                            Dim producto As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idArticulo).First

                            Dim precios As Double = 0

                            If inventario IsNot Nothing Then

                                precios = (producto.costoIVA * inventario.saldo) + (costo * cantidad)
                                If inventario.saldo + cantidad <> 0 Then
                                    producto.costoIVA = precios / (inventario.saldo + cantidad)
                                Else
                                    producto.costoIVA = producto.costoIVA
                                End If
                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))

                            Else

                                precios = (costo * cantidad)
                                producto.costoIVA = precios / cantidad
                                producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))

                            End If

                            'Actualizamos la fecha de ultimacompra del articulo
                            producto.fechaUltimaCompra = CDate(fnFechaServidor())
                            conexion.SaveChanges()

                            If inventario Is Nothing Then
                                'crear el registro en inventario.
                                Dim inveNuevo As New tblInventario

                                inveNuevo.idInventario = c.idtipoInventario
                                inveNuevo.IdAlmacen = c.idalmacen
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
                                inventario.transito -= cantidad * valmedida
                                conexion.SaveChanges()
                            End If

                            conexion.SaveChanges()
                        End If

                        If Activar_Impuestos = True Then
                            Dim totalcon As Decimal
                            totalcon = CDec(Replace(lblTotalCarga.Text, "Q", "").Trim)

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
                                    impuestoentrada.idEntrada = identrada
                                    impuestoentrada.descripcion = nombreimpuesto
                                    impuestoentrada.valor = impues

                                    conexion.AddTotblImpuesto_Entrada(impuestoentrada)
                                    conexion.SaveChanges()

                                End If

                            Next
                        End If
                        ''-------------************FIN DE IMPUESTOS************----------------------------

                    Next

                    'paso 8, completar la transaccion.
                    transaction.Complete()

                    ''alerta.fnGuardar()
                    ''conn.Close()
                    frmNotificacion.lblNotificacion.Text = "Registro Guardado" + vbLf + "Correctamente"
                    frmNotificacion.Show()
                End Using

            End Using
        Catch ex As Exception

        End Try
        Me.Close()

    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            frmCargaSelectivaImportacion.Text = "Carga Selectiva"
            frmCargaSelectivaImportacion.StartPosition = FormStartPosition.CenterScreen
            frmCargaSelectivaImportacion.WindowState = FormWindowState.Normal
            frmCargaSelectivaImportacion.id = Invoice
            frmCargaSelectivaImportacion.ShowDialog()

            Dim tblR As DataTable = frmCargaSelectivaImportacion.tblRetorno

            frmCargaSelectivaImportacion.Dispose()

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
                    Me.grdProductos.Rows(filaBlanco).Cells(5).Value = tblR.Rows(0).Item(4)

                    inicio = 1
                End If

                Dim idarticulo As Integer
                Dim cajano As String
                Dim costo As Decimal

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    'agregar los elementos restantes al grid.
                    For index = inicio To tblR.Rows.Count - 1

                        idarticulo = tblR.Rows(index).Item(0)
                        cajano = tblR.Rows(index).Item(1)

                        costo = (From x In conexion.tblEntradasDetalles Where x.idEntrada = Invoice And x.nocaja.Equals(cajano) And x.idArticulo = idarticulo Select x.costoIVA).FirstOrDefault

                        Me.grdProductos.Rows.Add(tblR.Rows(index).Item(0), tblR.Rows(index).Item(1), tblR.Rows(index).Item(2), tblR.Rows(index).Item(3), tblR.Rows(index).Item(4), Format(CType(costo, Double), formatoNumero), Format(tblR.Rows(index).Item(4) * CDec(costo), formatoNumero))
                    Next

                    conn.Close()
                End Using

                Dim j As Integer
                Dim filas As Integer
                Dim costod As Decimal
                Dim cantidad As Integer
                filas = grdProductos.Rows.Count - 1

                For m As Integer = 0 To filas
                    costod = grdProductos.Rows(m).Cells("CostoTotal").Value

                    Dim lbtotalcarga As Decimal
                    Try
                        lbtotalcarga = Replace(lblTotalCarga.Text, "Q", "")
                    Catch ex As Exception
                        lbtotalcarga = 0
                    End Try

                    'lbltotaldolares.Text = lbltotaldolares.Text + costod
                    lblTotalCarga.Text = Format(CDec(If(lbtotalcarga = 0, 0, CDec(lbtotalcarga))) + (CDec(grdProductos.Rows(m).Cells("CostoTotal").Value)), mdlPublicVars.formatoMoneda)

                    ''''fnTotalProrrateo()
                    fnActualizar_Total()
                    ''Me.grdproductos.Rows.AddNew()

                Next

                fnEliminaVacias()
                fnConfiguracion()
                fnActivarFiltro()
                Me.grdProductos.Rows.AddNew()
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
