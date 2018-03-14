Imports Telerik.WinControls
Imports System.Linq
Imports System.Data.EntityClient
Imports System.Transactions

Public Class bl_Pedidos
    Protected alerta As New bl_Alertas

    'VERIFICAR CREDITO DE CLIENTE
    Public Function fnVerificaCredito(ByVal cliente As tblCliente, ByVal clave As String, ByVal credito As Double) As Integer

        Dim salidas As Double
        Try
            salidas = (From x In ctx.tblSalidas Where x.idCliente = cliente.idCliente And x.anulado = False _
                       And x.empacado = False And x.despachar = True And x.credito = True _
                       Select x.total).Sum
        Catch ex As Exception
            salidas = 0
        End Try

        'Obtenemos el credito disponible, sobregiro, y sobre pago programado
        Dim creditoDisponible As Double = cliente.limiteCredito - (cliente.saldo) - salidas
        Dim sobreGiro As Double = (cliente.porcentajeCredito / 100) * cliente.limiteCredito

        If credito > (creditoDisponible) Then
            If credito > (creditoDisponible + sobreGiro) Then
                If credito >= (creditoDisponible + sobreGiro + cliente.pagosTransito) Then
                    If RadMessageBox.Show("¿Debe realizar un pago programado, desea realizarlo?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        frmPagoNuevo.bitCliente = True
                        frmPagoNuevo.codigoCP = cliente.idCliente
                        frmPagoNuevo.Text = "Modulo de Clientes"
                        frmPagoNuevo.ShowDialog()
                        frmPagoNuevo.Dispose()
                        Return -2
                    Else
                        Return -1
                    End If
                Else
                    If fnAutorizaCredito(clave) Then
                        RadMessageBox.Show("Autorizacion correcta, despacho aceptado ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        Return 0
                    Else
                        RadMessageBox.Show("Autorizacion incorreta, contraseña no valida", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        Return -1
                    End If
                End If

            Else
                If RadMessageBox.Show("¿La venta está en sobregiro, desea seguir con la venta?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If fnAutorizaCredito(clave) Then
                        RadMessageBox.Show("Autorizacion correcta, despacho aceptado ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        Return 0
                    Else
                        RadMessageBox.Show("Autorizacion incorreta, contraseña no valida", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        Return -1
                    End If
                Else
                    Return -1
                End If
            End If
        Else
            Return 0
        End If
    End Function

    'AUTORIZAR CREDITO
    Public Function fnAutorizaCredito(ByVal passUsuario As String) As Boolean
        'se pide el password para autorizar
        Dim pass As String = InputBox("Ingrese contraseña de autorizacion:", "Autorizacion")
        If (pass = passUsuario) Then
            Return True
        Else
            Return False
        End If
    End Function

    'COTIZACION A DESPACHO
    Public Function fnCotizarDespachar(ByVal idSalida As Integer, ByVal credito As Boolean, ByVal idCliente As Integer, conexion As dsi_pos_demoEntities) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim faltantes As Boolean = False
        Dim empacado As Boolean = False
        Try
            'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
            Dim ArtEmpresa
            'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
            Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                          Where x.idSalida = idSalida Select x).FirstOrDefault

            'verificar despachado.
            If salida.anulado = True Or salida.empacado = True Or salida.despachar = True And salida.reservado = True Then
                alerta.contenido = "Salida Anulada/Empacada/Reservado/Despachada/Facturada No se puede convertir !!!  "
                alerta.fnErrorContenido()
                empacado = True
                success = False
                Exit Try
            End If

            'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
            Dim NombreArt As String
            Dim CodArticulo As Integer
            Dim Pedido As Integer
            Dim saldo As Integer
            Dim tInventario As Integer

            Dim Detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles
                                                     Join y In conexion.tblArticuloes On x.idArticulo Equals y.idArticulo
                                                     Where x.idSalida = idSalida And Not x.anulado
                                                     Select x).ToList

            'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
            For Each fila As tblSalidaDetalle In Detalles
                NombreArt = fila.tblArticulo.nombre1
                CodArticulo = fila.idArticulo
                Pedido = fila.cantidad
                tInventario = fila.tipoInventario

                If Not fila.tblArticulo.bitKit And Not fila.tblArticulo.bitServicio Then
                    'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                    ArtEmpresa = (From AE In conexion.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                              And AE.idArticulo = CodArticulo And AE.idTipoInventario = tInventario Select AE).First

                    If ArtEmpresa.saldo < Pedido Then
                        saldo = Pedido - ArtEmpresa.saldo
                        'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                        errContenido = errContenido & "El articulo: " & Trim(NombreArt) & ", Pedido " & Trim(Pedido).ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo & vbCrLf
                        success = False
                    End If
                End If
            Next

            'Si existe un error mandamos el mensaje e interrumpimos la aplicación
            If success = False Then
                RadMessageBox.Show(errContenido, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                faltantes = True
                Exit Try
            End If

            'crear registro de salida bodega.
            Dim sb As New tblsalidaBodega
            sb.idsalida = idSalida
            conexion.AddTotblsalidaBodegas(sb)
            conexion.SaveChanges()

            salida.despachar = True
            salida.fechaRegistro = fecha
            salida.fechaDespachado = fecha
            salida.fechaFiltro = fecha
            salida.pagado = 0
            salida.saldo = salida.total
            conexion.SaveChanges()

            'Actualizamos la fecha de ultima compra del cliente
            Dim cliente As tblCliente = (From c In conexion.tblClientes Where c.idCliente = salida.idCliente Select c).FirstOrDefault
            cliente.FechaUltimaCompra = salida.fechaDespachado
            conexion.SaveChanges()

            'pasar despachar a true
            If credito Then
                Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor
                Dim dia = Weekday(fechaVencimiento, vbMonday)
                Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).First
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
            conexion.SaveChanges()

            'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
            Dim idInventario As Integer = 0
            Dim idDetalle As Integer = 0

            For Each fila As tblSalidaDetalle In Detalles
                CodArticulo = fila.idArticulo
                Pedido = fila.cantidad
                idInventario = fila.tipoInventario
                idDetalle = fila.idSalidaDetalle
                fila.precioFactura = fila.precio
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
                            RadMessageBox.Show("Existencia insuficiente en Kit, articulo: " + detallekit.tblArticulo.nombre1, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            success = False
                            Exit Try
                        End If
                    Next
                ElseIf fila.tblArticulo.bitProducto Then
                    conexion.SaveChanges()
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
                        RadMessageBox.Show("Existencia insuficiente !!! " & fila.tblArticulo.nombre1 & " (" & fila.tblArticulo.codigo1 & "), Por " & (fila.cantidad - inve.saldo), mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        success = False
                        Exit Try
                    End If

                    'Verificamos si tiene pendientes por pedir
                    Dim lPendientes As List(Of tblSurtir) = (From x In conexion.tblSurtirs
                                                            Where Not x.anulado And x.saldo > 0 And x.articulo = CodArticulo
                                                            Select x).ToList

                    Dim cantidadDescontar As Integer = fila.cantidad
                    'Recorremos la lista de pendientes
                    For Each pendiente As tblSurtir In lPendientes

                        If cantidadDescontar > pendiente.saldo Then
                            cantidadDescontar -= pendiente.saldo
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

            'guardar los cambios
            conexion.SaveChanges()
        Catch ex As System.Data.EntityException
            success = False
        Catch ex As Exception
            If ex.[GetType]() <> GetType(UpdateException) Then
                Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                alerta.fnErrorGuardar()
                Exit Try
            End If
        End Try

        If success Then
            conexion.AcceptAllChanges()
            alerta.fnGuardar()
        Else
            If Not faltantes And Not empacado Then
                alerta.fnErrorGuardar()
            End If
        End If
        Return success
    End Function

    'RESERVACION A DESPACHO
    Public Function fnReservarDesparchar(ByVal idSalida As Integer, ByVal credito As Boolean, ByVal idCliente As Integer, conexion As dsi_pos_demoEntities) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor

        Try
            'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
            Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                          Where x.idSalida = idSalida Select x).FirstOrDefault

            'verificar opciones de conversion.
            If salida.anulado = True Or salida.empacado = True Or salida.despachar = True Then
                alerta.contenido = "Salida Anulada/Empacada/Despachada/Facturada No se puede convertir !!!  "
                alerta.fnErrorContenido()
                success = False
                Exit Try
            End If

            'verificar si esta reservado
            If salida.reservado = False Then
                alerta.contenido = "Salida no esta en reserva !!!"
                alerta.fnErrorContenido()
                success = False
                Exit Try
            End If

            'crear registro de salida bodega.
            Dim sb As New tblsalidaBodega
            sb.idsalida = idSalida
            conexion.AddTotblsalidaBodegas(sb)
            conexion.SaveChanges()

            'pasar despachar a true
            If credito Then
                salida.despachar = True
                Dim dia = Weekday(fechaVencimiento, vbMonday)
                Dim cli As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x).First
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
                salida.fechaDespachado = fecha
            Else
                salida.despachar = True
                salida.fechaDespachado = fecha
            End If

            salida.saldo = salida.total
            salida.pagado = 0
            salida.fechaVencimientoReserva = Nothing
            salida.fechaFiltro = fecha
            conexion.SaveChanges()
            Dim sal As Decimal
            sal = salida.total

            'Actualizamos la fecha de ultima compra del cliente
            Dim cliente As tblCliente = (From c In conexion.tblClientes
                                         Where c.idCliente = salida.idCliente Select c).FirstOrDefault
            cliente.FechaUltimaCompra = salida.fechaDespachado
            conexion.SaveChanges()


            'descontar la reserva de inventario.
            Dim consulta As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = idSalida And x.anulado = False Select x).ToList
            Dim fila As tblSalidaDetalle

            For Each fila In consulta
                fila.precioFactura = fila.precio
                Dim id As Integer = fila.idArticulo
                'seleccionar el registro de inventario por medio del idempresa y articulo.
                Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                   Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = id _
                                                   And fila.tipoInventario
                                                   Select x).First

                If fila.tblArticulo.bitProducto Then
                    'Descontamos de reserva
                    inventario.reserva = inventario.reserva - fila.cantidad
                    inventario.salida = inventario.salida + fila.cantidad

                    conexion.SaveChanges()
                End If

                'Verificamos si tiene pendientes por pedir
                Dim lPendientes As List(Of tblPendientePorPedir) = (From x In conexion.tblPendientePorPedirs
                                                                     Where x.bitCreado And Not x.anulado And x.saldo > 0 And x.articulo = id
                                                                     Select x).ToList
                Dim cantidadDescontar As Integer = fila.cantidad
                'Recorremos la lista de pendientes
                For Each pendiente As tblPendientePorPedir In lPendientes
                    If cantidadDescontar > pendiente.saldo Then
                        cantidadDescontar -= pendiente.saldo
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

            'confirmar todos los cambios.
            conexion.SaveChanges()

            ''-----********------------IMPUESTOS-*-*-*-*--*-*-------------------**************
            If Activar_Impuestos = True Then
                Dim totalcon As Decimal
                totalcon = CDec(Replace(sal, "Q", "").Trim)

                Dim impuesto = (From x In conexion.tblImpuestoPagar_TipoMovimiento, y In conexion.tblImpuestoPagar_Impuesto, z In conexion.tblImpuestoes Where y.idImpuestoPagar = x.idImpuestoPagar _
                                And z.idImpuesto = y.idImpuesto And x.idTipoMovimiento = Salida_TipoMovimientoVenta Select z.idImpuesto, z.nombre, z.formula)

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

                For Each fil As DataRow In impuestos.Rows

                    totalString = CStr(totalcon)
                    idimpues = fil.Item("idImpuesto")
                    nombreimpuesto = fil.Item("nombre")
                    formu = fil.Item("formula")
                    formu = formu.Replace("dato", CStr(totalString))

                    If validador.validar(formu) Then
                        expresionpostfija = convertidor.fnConvierte(formu)
                        impues = CDec(resuelve.fnResolver(expresionpostfija))

                        Dim impuestosalida As New tblImpuesto_Salida
                        impuestosalida.idImpuesto = idimpues
                        impuestosalida.idSalida = idSalida
                        impuestosalida.descripcion = nombreimpuesto
                        impuestosalida.valor = impues

                        conexion.AddTotblImpuesto_Salida(impuestosalida)
                        conexion.SaveChanges()

                    End If

                Next
            End If
            ''-------------************FIN DE IMPUESTOS************----------------------------


        Catch ex As System.Data.EntityException
        Catch ex As Exception
            ' Handle errors and deadlocks here and retry if needed. 
            ' Allow an UpdateException to pass through and 
            ' retry, otherwise stop the execution. 
            If ex.[GetType]() <> GetType(UpdateException) Then
                RadMessageBox.Show("Error al Guardar " + ex.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Try
                ' If we get to this point, the operation will be retried. 
            End If
        End Try

        If success = True Then
            conexion.AcceptAllChanges()
            alerta.fnGuardar()
        End If

        Return success

    End Function

    'CONSUMIR PAGOS CLIENTES
    Public Function fnConsumirPagos(idCliente As Integer, conexion As dsi_pos_demoEntities)
        Try
            fnConsumirPagos = True
            Dim fechaServidor As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
            Dim codigopago As Integer
            'Verificamos si tiene pagos a favor
            Dim listadoPagos As List(Of tblCaja) = (From x In ctx.tblCajas Where x.cliente = idCliente _
                                                    And x.afavor > 0 And x.confirmado Order By x.fecha Ascending Select x).ToList()
            Dim montoPagar As Decimal = 0
            Dim consumido As Decimal = 0
            For Each pago As tblCaja In listadoPagos
                'Obtenemos la lista de salidas
                montoPagar = pago.afavor
                consumido = 0
                Dim listadoSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                                           Where x.idCliente = pago.cliente And Not x.anulado And x.facturado _
                                                            And x.saldo > 0
                                                           Order By x.fechaDespachado Ascending Select x).ToList

                For Each salidaPendiente As tblSalida In listadoSalidas
                    If montoPagar = 0 Then
                        Exit For
                    End If
                    Dim detallePago As New tblCajaSalida
                    detallePago.idCaja = pago.codigo
                    detallePago.idSalida = salidaPendiente.idSalida
                    detallePago.idCliente = pago.cliente
                    detallePago.fechaRegistro = fechaServidor
                    detallePago.fechaFiltro = fechaServidor
                    If montoPagar > salidaPendiente.saldo Then
                        detallePago.monto = salidaPendiente.saldo
                        detallePago.saldoNuevo = 0
                        detallePago.saldoSalida = salidaPendiente.saldo

                        montoPagar -= salidaPendiente.saldo
                        salidaPendiente.pagado += salidaPendiente.saldo
                        salidaPendiente.saldo = 0
                    Else
                        detallePago.monto = montoPagar
                        detallePago.saldoNuevo = (salidaPendiente.saldo - montoPagar)
                        detallePago.saldoSalida = salidaPendiente.saldo

                        salidaPendiente.saldo -= montoPagar
                        salidaPendiente.pagado += montoPagar
                        montoPagar = 0
                    End If
                    consumido += detallePago.monto
                    conexion.AddTotblCajaSalidas(detallePago)
                    conexion.SaveChanges()
                Next
                codigopago = pago.codigo


                Dim pagoval As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigopago Select x).FirstOrDefault

                pagoval.consumido += consumido
                pagoval.afavor -= consumido

                conexion.SaveChanges()

            Next
        Catch ex As Exception
            fnConsumirPagos = False
        End Try
    End Function

    'FACTURAR E IMPRIMIR, PV PEQUEÑO
    Public Sub fnFacturarImprimir(codigoSalida As Integer)
        Dim conexion As dsi_pos_demoEntities
        'Facturar
        mdlPublicVars.GuardarFacturacion(codigoSalida)

        'Verificar si imprime factura

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim idCliente As Integer = (From x In conexion.tblSalidas Where x.idSalida = codigoSalida Select x).FirstOrDefault.idCliente
            Me.fnConsumirPagos(idCliente, conexion)

            If mdlPublicVars.bitImprimirFacturaVentaPequenia = True Then
                Dim fechaServer As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
                For Each idFactura As Integer In mdlPublicVars.listaDeFacturas
                    Dim factura As tblFactura = (From f In conexion.tblFacturas Where f.IdFactura = idFactura Select f).FirstOrDefault
                    Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where CType(x.descripcion, String) = CType(idFactura, String) And x.tblTipoImpresion.bitFactura = True Select x).FirstOrDefault

                    If impresion IsNot Nothing Then
                        If impresion.bitImpreso = False Then
                            Try
                                Dim r As New clsReporte
                                If mdlPublicVars.bitTransportePesado = True Then
                                    r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFacturaPequenio(codigoSalida, mdlPublicVars.idEmpresa))
                                    r.reporte = "rptFacturaPequenio.rpt"
                                Else
                                    r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", CInt(impresion.descripcion), mdlPublicVars.idEmpresa))
                                    r.nombreParametro = "@filtro"
                                    r.reporte = impresion.tblTipoImpresion.reporte
                                    r.parametro = ""
                                End If
                                r.imprimirReporte()

                                'If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                impresion.bitImpreso = True
                                impresion.usuarioImprime = mdlPublicVars.idUsuario
                                impresion.fechaImpresion = fechaServer
                                factura.bitImpreso = True

                                conexion.SaveChanges()
                            Catch ex As Exception
                                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            End Try
                        End If
                    End If
                Next
                mdlPublicVars.listaDeFacturas.Clear() 'limpiamos los idFacturas que se imprimieron
                mdlPublicVars.bitCrearFacturaVentaPequenia = False
                mdlPublicVars.bitImprimirFacturaVentaPequenia = False
                superSearchCodigoPagoVentaPequenia = 0
            End If
            conn.Close()
        End Using

    End Sub

    Public Sub fnImprimirFactura(codigoSalida As Integer)
        Dim conexion As dsi_pos_demoEntities
        'Verificar si imprime factura

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim idCliente As Integer = (From x In conexion.tblSalidas Where x.idSalida = codigoSalida Select x).FirstOrDefault.idCliente
            ''Me.fnConsumirPagos(idCliente, conexion)

            If mdlPublicVars.bitImprimirFacturaVentaPequenia = True Then
                Dim fechaServer As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
                For Each idFactura As Integer In mdlPublicVars.listaDeFacturas
                    Dim factura As tblFactura = (From f In conexion.tblFacturas Where f.IdFactura = idFactura Select f).FirstOrDefault
                    Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where CType(x.descripcion, String) = CType(idFactura, String) And x.tblTipoImpresion.bitFactura = True Select x).FirstOrDefault

                    If impresion IsNot Nothing Then
                        If impresion.bitImpreso = False Then
                            Try
                                Dim r As New clsReporte
                                If mdlPublicVars.bitTransportePesado = True Then
                                    r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFacturaPequenio(codigoSalida, mdlPublicVars.idEmpresa))
                                    r.reporte = "rptFacturaPequenio.rpt"
                                Else
                                    r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", CInt(impresion.descripcion), mdlPublicVars.idEmpresa))
                                    r.nombreParametro = "@filtro"
                                    r.reporte = impresion.tblTipoImpresion.reporte
                                    r.parametro = ""
                                End If
                                r.imprimirReporte()

                                'If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                impresion.bitImpreso = True
                                impresion.usuarioImprime = mdlPublicVars.idUsuario
                                impresion.fechaImpresion = fechaServer
                                factura.bitImpreso = True

                                conexion.SaveChanges()
                            Catch ex As Exception
                                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            End Try
                        End If
                    End If
                Next
                mdlPublicVars.listaDeFacturas.Clear() 'limpiamos los idFacturas que se imprimieron
                mdlPublicVars.bitCrearFacturaVentaPequenia = False
                mdlPublicVars.bitImprimirFacturaVentaPequenia = False
                superSearchCodigoPagoVentaPequenia = 0
            End If
            conn.Close()
        End Using

    End Sub

End Class
