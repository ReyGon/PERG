''Option Strict On

Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmVentaPequeniaBarraDerecha

    Public alerta As New bl_Alertas
    Dim blPedidos As New bl_Pedidos
    Private permiso As New clsPermisoUsuario
    Private _bitCrearImprimpir As Boolean
    'Variables para guardar el total a pagar y descuento de la salida que se selecciona.
    Dim totalPagar As Double = 0
    Dim descuento As Double = 0

    Private Sub frmVentaPequeniaBarraDerecha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmVentaPequeniaLista.llenagrid()
    End Sub

    'LOAD
    Private Sub frmVentaPequeniaBarraDerecha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    'FACTURAR
    Private Sub fnFacturar() Handles Me.panel1
        Try
            frmVentaPequeniaLista.fnCambioFila()
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                Dim codigoSalida As Integer = 0
                Dim fechaservidor As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
                Dim despacho As Boolean = False
                Dim facturar As Boolean = False
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    Using transaction As New TransactionScope
                        Try
                            'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos
                            Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = mdlPublicVars.superSearchId Select x).FirstOrDefault
                            If salida.anulado Or salida.facturado Then
                                alerta.contenido = "Venta Facturada o Anulada "
                                alerta.fnErrorContenido()
                                Exit Sub
                            End If

                            If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Info) = Windows.Forms.DialogResult.Yes Then
                                '********** YOEL
                                'VERIFICAMOS SI ES RESERVA o COTIZACION
                                If salida.reservado Then
                                    despacho = blPedidos.fnReservarDesparchar(salida.idSalida, CBool(salida.credito), CInt(salida.idCliente), conexion)
                                ElseIf salida.cotizado Then
                                    despacho = blPedidos.fnCotizarDespachar(salida.idSalida, CBool(salida.credito), CInt(salida.idCliente), conexion)
                                ElseIf salida.empacado Then
                                    despacho = True
                                End If

                                If despacho Then
                                    'Empacar la salida
                                    salida.empacado = True
                                    salida.fechaFiltro = fechaservidor
                                    conexion.SaveChanges()

                                    'Consumir pagos de cliente
                                    blPedidos.fnConsumirPagos(CInt(salida.idCliente), conexion)
                                    codigoSalida = salida.idSalida
                                    facturar = True
                                End If
                            End If

                            transaction.Complete()
                        Catch ex As Exception
                            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        End Try
                    End Using
                    conn.Close()
                End Using

                If facturar Then
                    blPedidos.fnFacturarImprimir(codigoSalida)
                    frmVentaPequeniaLista.frm_llenarLista()
                End If
            End If
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

    End Sub

    Private Sub fnReservar() Handles Me.panel2
        frmVentaPequeniaLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then

            Dim tipoSalida As String = mdlPublicVars.superSearchNombre
            Dim codigo As Integer = mdlPublicVars.superSearchId

            Dim salida As tblSalida


            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using


            If tipoSalida = "Cotizado" Then
                If RadMessageBox.Show("¿Desea pasar la cotización a reserva?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    If CambiacotizarAreservar(salida.idSalida, salida.credito, salida.idCliente) = False Then
                        If RadMessageBox.Show("¿Desea modificar los datos?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            fnSugerir(salida.idSalida, False)
                            frmPedidosLista.frm_llenarLista()
                        End If
                    End If
                End If
            Else
                alerta.contenido = "El pedido ya ha sido " & tipoSalida & "no se puede Reservar"
                alerta.fnErrorContenido()
            End If


            Me.Hide()
        End If
    End Sub

    'RESERVA A COTIZACION
    Private Sub fnReservaCotizacion() Handles Me.panel3

        frmVentaPequeniaLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim tipoSalida As String = mdlPublicVars.superSearchNombre
            Dim codigo As Integer = mdlPublicVars.superSearchId
            Dim salida As tblSalida

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                conn.Close()
            End Using

            If tipoSalida = "Reservado" Then
                If RadMessageBox.Show("¿Desea pasar la reserva a cotización?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    fnCambiarReservaCotizacion(salida.idSalida, CType(salida.idCliente, Integer))
                    frmPedidosLista.frm_llenarLista()
                End If
            Else
                alerta.contenido = "El pedido ya ha sido " & tipoSalida & "no se puede Reservar"
                alerta.fnErrorContenido()
            End If
            Me.Hide()

        End If

        ''RadMessageBox.Show("El Boton no tiene ninguna funcion", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    End Sub

    Public Sub fnCambiarReservaCotizacion(ByVal codigo As Integer, ByVal codCliente As Integer)

        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), Date)

        'crear variable de conexion.
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope

                Try

                    'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                    Dim salida As tblSalida = (From x In conexion.tblSalidas _
                                                  Where x.idSalida = codigo Select x).First

                    'verificar si esta anulado.
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


                    salida.reservado = False
                    salida.fechaVencimientoReserva = Nothing
                    salida.cotizado = True
                    salida.fechaFiltro = fecha
                    conexion.SaveChanges()

                    'descontar la reserva de inventario.
                    Dim consulta As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = codigo And x.anulado = False Select x).ToList
                    Dim fila As tblSalidaDetalle
                    For Each fila In consulta
                        Dim id As Integer = fila.idArticulo
                        If fila.tblArticulo.bitProducto Then
                            'seleccionar el registro de inventario por medio del idempresa y articulo.
                            Dim inventario As tblInventario = (From x In conexion.tblInventarios
                                                               Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = id Select x).First

                            'Descontamos de inventario
                            inventario.reserva -= fila.cantidad
                            inventario.saldo += fila.cantidad
                            conexion.SaveChanges()
                        End If
                    Next

                    'paso 8, completar la transaccion.
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
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion.
            conn.Close()

        End Using
    End Sub

    'COBRAR SALIDA
    Private Sub fnCobrarSalida() Handles Me.panel4
        frmVentaPequeniaLista.fnCambioFila()
        Dim codigoSalida As Integer = 0
        Dim fechaservidor As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
        Dim despacho As Boolean = False
        Dim facturar As Boolean = False
        Dim conexion As New dsi_pos_demoEntities
        If mdlPublicVars.superSearchFilasGrid > 0 Then

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                'Obtenemos el saldo del cliente para realizar el cobro
                Dim cliente As tblCliente
                cliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = CInt(mdlPublicVars.superSearchCodSurtir)
                                                 Select x).FirstOrDefault
                frmPagoNuevo.Text = "Pagos"
                frmPagoNuevo.bitCliente = True
                frmPagoNuevo.codigoCP = cliente.idCliente
                frmPagoNuevo.lblSaldo.Text = Format(cliente.saldo, mdlPublicVars.formatoMoneda)
                frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                frmPagoNuevo.ShowDialog()

                conn.Close()
            End Using

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                Using transaction As New TransactionScope
                    Try
                        'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos
                        Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = mdlPublicVars.superSearchId Select x).FirstOrDefault
                        If salida.anulado Or salida.empacado Or salida.facturado Then
                            alerta.contenido = "Venta Facturada o Anulada "
                            alerta.fnErrorContenido()
                            Exit Sub
                        End If

                        'YOEL
                        'MODIFICAMOS LA SALIDA
                        despacho = blPedidos.fnCotizarDespachar(salida.idSalida, CBool(salida.credito), CInt(salida.idCliente), conexion)
                        If despacho Or salida.despachar Then
                            'Empacar la salida
                            salida.empacado = True
                            salida.fechaFiltro = fechaservidor
                            conexion.SaveChanges()

                            'Consumir pagos de cliente
                            blPedidos.fnConsumirPagos(CInt(salida.idCliente), conexion)
                            facturar = True
                            codigoSalida = salida.idSalida
                        End If

                        transaction.Complete()
                    Catch ex As Exception
                        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End Try
                End Using

                conn.Close()
            End Using

            If facturar Then
                blPedidos.fnFacturarImprimir(codigoSalida)
                Me.Hide()
                frmVentaPequeniaLista.frm_llenarLista()
            End If
        End If
    End Sub

    'REALIZAR PAGO
    Private Sub fnRealizarPago() Handles Me.panel5
        frmVentaPequeniaLista.fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            frmPagoVentaPequenia.Text = "Realizar pago"
            frmPagoVentaPequenia.idCliente = CInt(mdlPublicVars.superSearchCodSurtir)
            frmPagoVentaPequenia.idSalida = CInt(mdlPublicVars.superSearchId)
            If mdlPublicVars.supersearchPagado = True Then
                frmPagoVentaPequenia.bitDocumentoCliente = False
                frmPagoVentaPequenia.bitCliente = True
                frmPagoVentaPequenia.bitDescontarSalidas = True
            Else
                frmPagoVentaPequenia.bitDocumentoCliente = True
                frmPagoVentaPequenia.bitCliente = False
                frmPagoVentaPequenia.bitDescontarSalidas = False
            End If
            frmPagoVentaPequenia.ShowDialog()
            frmPagoVentaPequenia.Dispose()
        End If
    End Sub

    ''ANULAR VENTA
    Private Sub fnAnular() Handles Me.panel6
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                frmVentaPequeniaLista.fnCambioFila()

                Dim idsalida As Integer = mdlPublicVars.superSearchId
                Dim fecha As DateTime = fnFechaServidor()
                Dim fechaayer As DateTime = fecha.AddDays(-1)
                Dim fechamaniana As DateTime = fecha.AddDays(1)
                Dim valfecha As Boolean = False
                Dim anula As Boolean = True

                Dim ldetalle As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = idsalida Select x).ToList

                For Each detalle As tblSalidaDetalle In ldetalle

                    Dim iddetalle As Integer

                    iddetalle = detalle.idSalidaDetalle


                    Dim envdetalle As List(Of tblSalidasTransportesMediosDetalle) = (From x In conexion.tblSalidasTransportesMediosDetalles Where x.idSalidaDetalle = iddetalle Select x).ToList

                    For Each envio As tblSalidasTransportesMediosDetalle In envdetalle

                        If envio.cantidad > 0 Then
                            anula = False
                            Exit For
                        End If

                    Next

                    If anula = False Then
                        Exit For
                    End If

                Next

                Dim fechaventa As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                If fechaventa.fechaRegistro >= fechamaniana Or fechaventa.fechaRegistro <= fechaayer Then
                    valfecha = True
                Else
                    valfecha = False
                End If

                ''If valfecha = True Then
                ''RadMessageBox.Show("No se puede anular la venta por la fecha", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ''Else
                    If anula = False Then
                        RadMessageBox.Show("Debe Reasignar los productos del envio", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Exit Sub
                    Else

                        Dim salmod As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                        If salmod.anulado = True Then

                            RadMessageBox.Show("La Venta ya ah Sido Anulada", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            Exit Sub

                        Else

                            salmod.anulado = True

                            conexion.SaveChanges()

                            ''Reasignacion de Inventario de los Articulos

                            Dim artdetalle As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = idsalida Select x).ToList

                            For Each art As tblSalidaDetalle In artdetalle

                                Dim articulo As Integer = art.idArticulo
                                Dim invent As Integer = art.tipoInventario
                                Dim bodeg As Integer = art.tipobodega

                                Dim inventa As tblInventario = (From x In conexion.tblInventarios Where x.idTipoInventario = invent And x.IdAlmacen = bodeg And x.idArticulo = articulo Select x).FirstOrDefault

                                If art.cantidad > 0 Then
                                    inventa.saldo += art.cantidad
                                    inventa.entrada += art.cantidad

                                    conexion.SaveChanges()
                                End If

                            Next


                            Dim pagosal As List(Of tblCaja) = (From x In conexion.tblCajas Where x.codigoEntrada = idsalida Select x).ToList

                            For Each pg As tblCaja In pagosal

                                pg.anulado = True

                                conexion.SaveChanges()

                            Next
                            ''Finalizacion de Reasignacion de Inventario de los articulos

                            RadMessageBox.Show("Venta Anulada Correctamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                            Dim salacred As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                            If salacred.pagado > 0 Then

                                If RadMessageBox.Show("Desea Acreditar el Efectivo Cancelado de la Venta al Cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                    Dim cliente As Integer = salacred.idCliente
                                    Dim abono As Double = salacred.pagado

                                    Dim clienteabono As tblCliente = (From x In conexion.tblClientes Where x.idCliente = cliente Select x).FirstOrDefault

                                    clienteabono.saldo -= abono

                                    conexion.SaveChanges()

                                    RadMessageBox.Show("El Saldo fue Acreditado Correctamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                                End If

                            End If

                        End If
                    End If
                    ''End If

                    conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'AJUSTES
    Private Sub fnAjustes() Handles Me.panel7
        Try
            frmVentaPequeniaLista.fnCambioFila()
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                'Muestra la paqueteria de esa salida
                Dim codigo As Integer = mdlPublicVars.superSearchId
                Dim salida As tblSalida = (From x In ctx.tblSalidas.AsEnumerable Where x.idSalida = codigo Select x).FirstOrDefault

                frmPedidosAjustesConceptos.Text = "Ajustes"
                frmPedidosAjustesConceptos.StartPosition = FormStartPosition.CenterScreen
                frmPedidosAjustesConceptos.BringToFront()
                frmPedidosAjustesConceptos.codClie = CInt(salida.idCliente)
                frmPedidosAjustesConceptos.codSalida = codigo
                frmPedidosAjustesConceptos.Focus()
                permiso.PermisoDialogEspeciales(frmPedidosAjustesConceptos)
                frmPedidosAjustesConceptos.Dispose()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Public Function CambiacotizarAreservar(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer) As Boolean
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = CDate(fnFecha_horaServidor())

        'agregar variable de conexion.
        Dim conexion As New dsi_pos_demoEntities

        'agregar cadena de conexion.
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)

            'abrir la conexion.
            conn.Open()

            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Using transaction As New TransactionScope
                Try

                    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault

                    'verificar si esta anulado.
                    If salida.anulado = True Or salida.empacado = True Or salida.despachar = True Then
                        alerta.contenido = "Salida Anulada/Empacada/Despachada/Facturada Actualice la Lista !!!  "
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    'verificar si esta reservado
                    If salida.reservado = True Then
                        alerta.contenido = "Salida ya esta Reservada !!!"
                        alerta.fnErrorContenido()
                        success = False
                        Exit Try
                    End If

                    Dim ArtEmpresa As Object

                    'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                    Dim NombreArt As String
                    Dim CodArticulo As Integer
                    Dim Pedido As Integer
                    Dim saldo As Integer
                    Dim tInventario As Integer
                    Dim Detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles
                                                                 Join y In conexion.tblArticuloes On x.idArticulo Equals y.idArticulo
                                                                 Where x.idSalida = codigo And x.anulado = False
                                                                 Select x).ToList


                    'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
                    For Each fila As tblSalidaDetalle In Detalles
                        NombreArt = fila.tblArticulo.nombre1
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        tInventario = CInt(fila.tipoInventario)

                        If fila.tblArticulo.bitProducto Then
                            'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                            ArtEmpresa = (From AE In conexion.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                          And AE.idArticulo = CodArticulo And AE.idTipoInventario = tInventario Select AE).First

                            ''Dim saldos As Decimal = ArtEmpresa.saldo

                            If ArtEmpresa.saldo < Pedido Then
                                saldo = Pedido - ArtEmpresa.saldo
                                'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                                errContenido += "El articulo: " & NombreArt & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo.ToString + vbCrLf
                                success = False
                            End If
                        End If
                    Next

                    'Si existe un error mandamos el mensaje e interrumpimos la aplicación
                    If success = False Then
                        RadMessageBox.Show(errContenido, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        Exit Try
                    End If

                    'Definimos la fecha en que vencerá la reserva
                    Dim diaSemana As Integer = Weekday(CDate(mdlPublicVars.fnFecha_horaServidor), vbMonday)
                    Dim fechaActual As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
                    Dim fechaReserva As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor)
                    Dim dias As Integer = 0
                    Try
                        Dim cadDias As String = InputBox("Ingrese dias de reserva", "Informacion", CStr(mdlPublicVars.Salida_ReservaDias))
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
                    For Each fila As tblSalidaDetalle In Detalles
                        CodArticulo = fila.idArticulo
                        Pedido = fila.cantidad
                        fila.precioFactura = fila.precio
                        ''actualizar el modelo
                        'conexion.Refresh(System.Data.Objects.RefreshMode.ClientWins, conexion.tblInventarios)
                        'conexion.SaveChanges()


                        'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                        Dim inve As tblInventario = (From x In conexion.tblInventarios _
                                                      Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                                      And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idArticulo = CodArticulo Select x).First

                        'descontar existencias.
                        inve.saldo = inve.saldo - Pedido
                        inve.reserva = inve.reserva + Pedido

                        conexion.SaveChanges()
                    Next

                    'completar la transaccion.
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                Catch ex As Exception
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        success = False
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

            'liberar la conexion
            conn.Close()
        End Using
        Return success
    End Function

    'Cotizacion a despacho
    Private Sub fnSugerir(ByVal codigo As Integer, ByVal bitSugerirDespacho As Boolean)
        frmSalidas.Text = "Editar Pedido "
        frmSalidas.codigo = codigo
        frmSalidas.bitEditarBodega = False
        frmSalidas.bitEditarSalida = True
        frmSalidas.bitSugerirDespacho = bitSugerirDespacho
        frmSalidas.bitSugerirReserva = Not bitSugerirDespacho
        frmSalidas.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmEspeciales(frmSalidas, False)
    End Sub

End Class