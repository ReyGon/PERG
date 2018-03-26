Imports System.Transactions
Imports System.Linq
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmComprasBarraDerecha
    Public alerta As New bl_Alertas
    Private permiso As New clsPermisoUsuario

    Private Sub frmComprasBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl4.Focus()
    End Sub

    'CONFIRMAR PREFORMA
    Private Sub fnPanel1() Handles Me.panel1
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
                If RadMessageBox.Show("¿Desea pasar la PREFORMA a COMPRA?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    frmEntrada.Text = "Compras"
                    frmEntrada.MdiParent = frmMenuPrincipal
                    frmEntrada.codigo = compra.idEntrada
                    frmEntrada.bitPreformaToEntrada = True
                    frmEntrada.bitEditarEntrada = True
                    permiso.PermisoFrmEspeciales(frmEntrada, True)
                End If
            End If
            Me.Hide()
        Catch ex As Exception
        End Try
    End Sub

    'GUIAS
    Private Sub fnPanel2() Handles Me.panel2
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then

                Dim codigo As Integer = mdlPublicVars.superSearchId

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim entrada As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                    If entrada.preforma = False And entrada.Invoice = True And entrada.compra = False And entrada.anulado = False Then
                        frmNacionalizacion.Text = "Nacionalizacion Invoice"
                        frmNacionalizacion.StartPosition = FormStartPosition.CenterScreen
                        frmNacionalizacion.WindowState = FormWindowState.Normal
                        frmNacionalizacion.idinvoice = codigo
                        frmNacionalizacion.ShowDialog()
                        frmNacionalizacion.Dispose()

                        entrada.nacionalizacion = True
                        conexion.SaveChanges()

                    Else
                        alerta.contenido = "No es una Invoice o la Invoice esta anulada"
                        alerta.fnErrorContenido()
                    End If

                    conn.Close()
                End Using

                ''Dim codigo As Integer = mdlPublicVars.superSearchId
                ''frmComprasGuia.Text = "Guias"
                ''frmComprasGuia.Codigo = codigo
                ''frmComprasGuia.StartPosition = FormStartPosition.CenterScreen
                ''permiso.PermisoFrmEspeciales(frmComprasGuia, False)
            End If
        Catch ex As Exception

        End Try
    End Sub
     
    'PENDIENTES
    Private Sub fnPanel3() Handles Me.panel3
        Try
            ''frmComprasPendientesConceptos.Text = "Pendientes por Recibir"
            ''frmComprasPendientesConceptos.codEntrada = mdlPublicVars.superSearchId
            ''frmComprasPendientesConceptos.StartPosition = FormStartPosition.CenterScreen
            ''frmComprasPendientesConceptos.WindowState = FormWindowState.Normal
            ''permiso.PermisoDialogEspeciales(frmComprasPendientesConceptos)
            ''frmComprasPendientesConceptos.Dispose()

            If mdlPublicVars.superSearchFilasGrid > 0 Then

                Dim codigo As Integer = mdlPublicVars.superSearchId

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim entrada As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                    If entrada.nacionalizacion = True And entrada.anulado = False Then

                        frmCargasImportaciones.Text = "Precarga / Carga"
                        frmCargasImportaciones.StartPosition = FormStartPosition.CenterScreen
                        frmCargasImportaciones.WindowState = FormWindowState.Normal
                        frmCargasImportaciones.Invoice = codigo
                        permiso.PermisoDialogEspeciales(frmCargasImportaciones)
                        frmCargasImportaciones.Dispose()
                    Else
                        alerta.contenido = "No esta Nacionalizada la Invoice"
                        alerta.fnErrorContenido()
                    End If

                    conn.Close()
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

    'DEVOLUCIONES
    Private Sub fnPanel4() Handles Me.panel4
        Try
            frmComprasDevolucionesConceptos.Text = "Devoluciones"
            frmComprasDevolucionesConceptos.codEntrada = mdlPublicVars.superSearchId
            frmComprasDevolucionesConceptos.StartPosition = FormStartPosition.CenterScreen
            frmComprasDevolucionesConceptos.WindowState = FormWindowState.Normal
            permiso.PermisoDialogEspeciales(frmComprasDevolucionesConceptos)
            frmComprasDevolucionesConceptos.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'AJUSTES
    Private Sub fnPanel5() Handles Me.panel5
        Try
            frmComprasAjustesConceptos.Text = "Ajustes"
            frmComprasAjustesConceptos.codEntrada = mdlPublicVars.superSearchId
            permiso.PermisoDialogEspeciales(frmComprasAjustesConceptos)
            frmComprasAjustesConceptos.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnPanel6() Handles Me.panel6
        Try
            ''Dim compra As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = mdlPublicVars.superSearchId _
            ''                          Select x).FirstOrDefault

            ''If RadMessageBox.Show("¿Esta seguro de iniciar la operación de Preforma a Tránsito?" & vbCrLf & "¡Esta acción dejárá la Preforma sin opción de modificación y trasladará los anticipos al nuevo documento en tránsito!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

            ''    Dim identrada As Integer = fnPreformatoTransito(compra.idEntrada)

            ''    mdlPublicVars.superSearchId = identrada

            ''    frmproformaimportacion.Text = "Compra Importación"
            ''    frmproformaimportacion.MdiParent = frmMenuPrincipal
            ''    frmproformaimportacion.codigo = identrada
            ''    frmproformaimportacion.bitEditarEntrada = True
            ''    frmproformaimportacion.bitConvertirTransito = True
            ''    frmproformaimportacion.Show()

            ''    Dim conexion As dsi_pos_demoEntities
            ''    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            ''        conn.Open()
            ''        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            ''        Dim c As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = compra.idEntrada Select x).FirstOrDefault

            ''        c.preformatotransito = True

            ''        conexion.SaveChanges()

            ''        conn.Close()
            ''    End Using

            ''    Me.Hide()
            ''End If
            Dim transito As Boolean = False
            Dim preforma As Boolean = False
            Dim anulado As Boolean = False
            Dim comprado As Boolean = False

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim e As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = mdlPublicVars.superSearchId Select x).FirstOrDefault

                transito = e.Invoice
                preforma = e.preformaimportacion
                comprado = e.compra
                anulado = e.anulado

                conn.Close()
            End Using

            If transito = False And preforma = True And comprado = False And anulado = False Then
                frmImportaciones.Text = "Compra Importación"
                frmImportaciones.MdiParent = frmMenuPrincipal
                frmImportaciones.codigo = mdlPublicVars.superSearchId
                ''frmproformaimportacion.bitEditarEntrada = True
                ''frmproformaimportacion.bitConvertirTransito = True
                frmImportaciones.bitCrearTransito = True
                frmImportaciones.MdiParent = frmMenuPrincipal
                ''frmproformaimportacion.Show()
                permiso.PermisoFrmBaseEspeciales(frmImportaciones, True)
                ''frmproformaimportacion.Dispose()
            Else
                RadMessageBox.Show("Seleccione una Preforma Invoice", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
            Me.Hide()
        Catch ex As Exception
        End Try
    End Sub

    Private Function fnPreformatoTransito(ByVal identrada As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim codigo As Integer
                Dim proveedor As Integer

                Dim p As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = identrada Select x).FirstOrDefault

                Dim c As New tblEntrada

                c.idEmpresa = p.idEmpresa
                c.idUsuario = p.idUsuario
                c.idTipoMovimiento = p.idTipoMovimiento
                c.idProveedor = p.idProveedor
                c.fechaRegistro = fnFecha_horaServidor()
                c.fechaTransaccion = fnFecha_horaServidor()
                c.serieDocumento = p.serieDocumento
                c.documento = p.documento
                c.observacion = p.observacion
                c.anulado = False
                c.preforma = True
                c.transito = False
                c.compra = False
                c.flete = p.flete
                c.total = p.total
                c.correlativo = p.correlativo
                c.idtipoInventario = p.idtipoInventario
                c.idalmacen = p.idalmacen
                c.cancelado = p.cancelado
                c.saldo = p.saldo
                c.pagos = p.pagos
                c.credito = p.credito
                c.contado = p.contado
                c.fechaPago = p.fechaPago
                c.usuarioCompra = p.usuarioCompra
                c.fechaFiltro = CDate(fnFechaServidor())
                c.fechadocumento = p.fechadocumento

                conexion.AddTotblEntradas(c)
                conexion.SaveChanges()
                codigo = c.idEntrada
                proveedor = c.idProveedor

                Dim det As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = identrada Select x).ToList

                For Each d As tblEntradasDetalle In det
                    Try
                        Dim ed As New tblEntradasDetalle

                        ed.idEntrada = codigo
                        ed.idArticulo = d.idArticulo
                        ed.cantidad = d.cantidad
                        ed.costoIVA = d.costoIVA
                        ed.costoSinIVA = d.costoSinIVA
                        ed.preformaCantidad = d.preformaCantidad
                        ed.preformaCostoIVA = d.preformaCostoIVA
                        ed.preformaCostoSinIVA = d.preformaCostoSinIVA
                        ed.costoprorrateo = d.costoprorrateo
                        ed.idunidadmedida = d.idunidadmedida
                        ed.valormedida = d.valormedida

                        conexion.AddTotblEntradasDetalles(ed)
                        conexion.SaveChanges()

                    Catch ex As Exception
                        Return False
                    End Try
                Next

                ''Transferimos los pagos al nuevo movimiento Invoice
                Dim dc As List(Of tblCaja) = (From x In conexion.tblCajas Where x.proveedor = proveedor And x.identradapago = identrada Select x).ToList

                For Each pa As tblCaja In dc

                    Dim ca As tblCaja = (From x In conexion.tblCajas Where x.codigo = pa.codigo Select x).FirstOrDefault

                    ca.identradapago = codigo

                    conexion.SaveChanges()

                    ''Dim e As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                    ''e.saldo -= ca.monto
                    ''e.pagos += ca.monto

                    ''conexion.SaveChanges()

                Next


                conn.Close()
                Return codigo
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Funcion utilizada para pasar una preforma a compra
    Private Sub fnPreformaToCompra(ByVal codigo As Integer)
        Dim fechaServidor As DateTime = fnFecha_horaServidor()
        Dim hora As String = mdlPublicVars.fnHoraServidor
        Dim success As Boolean = True
        Dim contado As Boolean = False
        Dim codigoProveedor As Integer = 0
        '-------------------Creamos el encabezado de la compra------------'
        Using transaction As New TransactionScope
            Try
                'Obtenemos el registro de la compra
                Dim compra As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = codigo _
                                            Select x).FirstOrDefault

                compra.compra = True
                compra.fechaCompra = fechaServidor
                compra.usuarioCompra = mdlPublicVars.idUsuario

                ctx.SaveChanges()

                'Obtenemos el detalle de  nuestra compra
                Dim lDetalles As List(Of tblEntradasDetalle) = (From x In ctx.tblEntradasDetalles Where x.idEntrada = codigo _
                                                                Select x).ToList


                Dim detalle As tblEntradasDetalle

                'Recorremos la lista de detalles
                For Each detalle In lDetalles
                    'Aumentos las existencias, y entradas en el inventario
                    Dim inventario As tblInventario = (From x In ctx.tblInventarios Where x.idArticulo = detalle.idArticulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                       And x.idTipoInventario = compra.idtipoInventario And x.IdAlmacen = compra.idalmacen _
                                                       Select x).FirstOrDefault

                    Dim producto As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = detalle.idArticulo).First

                    Dim precios As Double = 0

                    If inventario IsNot Nothing Then
                        precios = (producto.costoIVA * inventario.saldo) + (detalle.costoIVA * detalle.cantidad)
                        producto.costoIVA = precios / (inventario.saldo + detalle.cantidad)
                        producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                    Else
                        precios = (detalle.costoIVA * detalle.cantidad)
                        producto.costoIVA = precios / detalle.cantidad
                        producto.costoSinIVA = producto.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                    End If

                    ctx.SaveChanges()

                    If inventario Is Nothing Then
                        'crear el registro en inventario.
                        Dim inveNuevo As New tblInventario

                        inveNuevo.idInventario = compra.idtipoInventario
                        inveNuevo.IdAlmacen = compra.idalmacen
                        inveNuevo.entrada = detalle.cantidad
                        inveNuevo.saldo = detalle.cantidad
                        inveNuevo.salida = 0
                        ctx.AddTotblInventarios(inveNuevo)
                        ctx.SaveChanges()
                    Else
                        'Aumentamos entradas
                        inventario.entrada = inventario.entrada + detalle.cantidad
                        'Aumentamos saldo
                        inventario.saldo = inventario.saldo + detalle.cantidad
                        ctx.SaveChanges()
                    End If
                Next

                'Si la compra fue al credito generamos cuenta por cobrar
                If compra.contado Then
                    contado = True
                    codigoProveedor = compra.idProveedor
                End If

                'Aumentamos el saldo del proveedor y establecemos la ultima compra
                Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = compra.idProveedor Select x).FirstOrDefault

                If proveedor.saldoActual Is Nothing Then
                    proveedor.saldoActual = compra.total
                Else
                    proveedor.saldoActual += compra.total
                End If
                proveedor.ultimaCompra = compra.fechaCompra

                ctx.SaveChanges()
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
            ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()
            If contado = True Then
                If RadMessageBox.Show("Desea realizar un pago al proveedor", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    Dim prov As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigoProveedor Select x).FirstOrDefault
                    frmPagoNuevo.Text = "Pagos"
                    frmPagoNuevo.bitProveedor = True
                    frmPagoNuevo.codigoCP = prov.idProveedor
                    frmPagoNuevo.lblSaldo.Text = prov.saldoActual
                    frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoFrmEspeciales(frmPagoNuevo, False)
                End If

            End If
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Sub

    Private Sub pnl1_Paint(sender As Object, e As PaintEventArgs) Handles pnl1.Paint

    End Sub
End Class
