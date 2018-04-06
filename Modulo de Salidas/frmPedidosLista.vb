Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmPedidosLista
    Private permiso As New clsPermisoUsuario
    Private cargo As Boolean
    Public registroActual As Integer = 0
    Public filtroActivo As Boolean
    Dim alerta As New bl_Alertas


    Private Sub fnFacturar(ByVal salida As tblSalida)
        'variables.
        Dim nFacturas As Integer = 0
        Dim xx
        Dim agregar As Integer = 0
        Dim codigoCliente
        Dim direccion1
        Dim total1
        Dim vendedor1
        Dim documento1
        Dim fecha1
        Dim pagos1
        Dim codigo1

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'consultas a bd.
            Dim consulta = (From x In conexion.tblSalidas _
                                                      Where x.idSalida = salida.idSalida And salida.facturado = False And x.anulado = False _
                                                      Select Codigo = x.idSalida, Pagos = If(x.contado = True, "Contado", "Credito"),
                                                      Fecha = x.fechaRegistro, Documento = x.documento, _
                                                      DireccionFacturacion = x.direccionFacturacion,
                                                      Vendedor = x.tblVendedor.nombre, Total = x.total, clrEstado = 0, Estado = "Revisado",
                                                      Descripcion = "", Clave = salida.idCliente).FirstOrDefault

            codigo1 = consulta.Codigo
            pagos1 = consulta.Pagos
            fecha1 = consulta.Fecha
            documento1 = consulta.Documento
            vendedor1 = consulta.Vendedor
            total1 = consulta.Total
            direccion1 = consulta.DireccionFacturacion
            codigoCliente = consulta.Clave

            Dim consFacturas = (From x In conexion.tblSalidas
                                    Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa _
                                    And x.idCliente = salida.idCliente And x.cliente = salida.cliente And x.direccionEnvio = salida.direccionEnvio And x.nit = salida.nit _
                                     And x.anulado = False Select x.idSalida).ToList()


            For Each xx In consFacturas
                Dim estado = conexion.sp_salida_Estado(mdlPublicVars.idEmpresa, xx).ToList
                For Each es As sp_salida_Estado_Result In estado
                    nFacturas = nFacturas + 1
                Next
            Next
            'seleccionar todos los detalles 
            ' Dim detalles As List(Of tblSalidaDetalle) = (From y In conexion.tblSalidaDetalles Where y.idSalida = salida.idSalida Select y).ToList

            'cerrar la conexion.
            conn.Close()

            'fin de proceso.
        End Using

        If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
            Dim codigoFactura As Integer = 0
            Dim total As Decimal = mdlPublicVars.fnTotalTablaFacturas

            codigoFactura = mdlPublicVars.GuardarFacturacion(codigo1) 'codigo1 guarda el idsalida en la consulta de arriba
        End If

        frm_llenarLista()

    End Sub

    ''Private Sub fnValidarSalida(ByVal salida As tblSalida)
    ''    Try
    ''        Dim conexion As dsi_pos_demoEntities
    ''        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    ''            conn.Open()
    ''            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

    ''            If CInt(ClienteSucursal) = CInt(salida.idCliente) Then

    ''                Dim val = conexion.sp_crear_compra_sucursal(salida.idSalida, "Trans-", ServidorSucursal, BDSucursal)

    ''            End If

    ''            conn.Close()
    ''        End Using
    ''    Catch ex As Exception
    ''        alerta.fnError()
    ''    End Try
    ''End Sub

    Private Sub frmPedidosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"

        ''chkFacturado.Checked = True

        Me.cmbFiltroFecha.Visible = False
        Me.txtFiltro.Visible = False
        Me.lblFiltroFecha.Visible = False
        Me.Label2.Visible = False
        ''Me.rbtDespachado.Checked = True


        Try
            Dim iz As New frmPedidosFacturasBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmPedidosListaBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try

        Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ''fnLlenarCombo()
        llenagrid()
        ''fnConfiguracion()
        ''cmbFiltroFecha.Visible = True
        ''lblFiltroFecha.Visible = True
        cargo = True
        grdDatos.Focus()

        Try
            ''fnVerificarReserva()
        Catch ex As Exception

        End Try
    End Sub

    'LLENAR COMBO
    ''Private Sub fnLlenarCombo()
    ''    Dim datos = (From x In ctx.tblListaFiltroFechas Select x.orden, codigo = x.dias, x.nombre
    ''                 Order By orden Ascending)

    ''    With cmbFiltroFecha
    ''        .DataSource = Nothing
    ''        .ValueMember = "codigo"
    ''        .DisplayMember = "nombre"
    ''        .DataSource = datos
    ''    End With
    ''End Sub

    Private Sub fnVerificarReserva()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim reservas As String = ""

                Dim listareservas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.reservado = True And x.anulado = False And x.despachar = False And x.facturado = False And x.cotizado = False Select x).ToList

                For Each reserva As tblSalida In listareservas

                    Dim fecha As DateTime = Today.AddDays(-20)

                    If reserva.fechaRegistro < fecha Then
                        reservas += reserva.documento + ", "
                    End If
                Next

                ''Dim contador = (From x In conexion.tblSalidas Where x.reservado = True Select x).Count
                If reservas.Length > 0 Then
                    RadMessageBox.Show("La Reservar Mayores a 20 dias son: " + CStr(reservas), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenagrid()
        Try
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                conexion.CommandTimeout = 10000

                Dim fechainicio As DateTime
                Dim fechafin As DateTime

                fechainicio = dtpFechaInicio.Value.ToShortDateString + " 00:00:00.000"
                fechafin = dtpFechaFin.Value.ToShortDateString + " 23:59:59.999"

                Me.grdDatos.DataSource = conexion.sp_salida_mov_lista(mdlPublicVars.idEmpresa, fechainicio, fechafin, txtFiltro.Text, "")

                conn.Close()
            End Using

            mdlPublicVars.fnGrid_iconos(Me.grdDatos)
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            If grdDatos.RowCount > 0 Then
                Me.grdDatos.Rows(registroActual).IsCurrent = True
            End If

            fnConfiguracion()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
        fnCambioFila()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                ''mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaAnulado")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")
                ''mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "VenceReserva")

                '' Me.grdDatos.Columns("FechaAnulado").HeaderText = "Fecha Anulado"

                Me.grdDatos.Columns("Codigo").IsVisible = False
                Me.grdDatos.Columns("Clave").IsVisible = False

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("Codigo").Width = 55
                Me.grdDatos.Columns("Fecha").Width = 80
                Me.grdDatos.Columns("Clave").Width = 60
                Me.grdDatos.Columns("Cliente").Width = 140
                Me.grdDatos.Columns("Vendedor").Width = 100
                ''Me.grdDatos.Columns("Doc").Width = 55
                Me.grdDatos.Columns("Total").Width = 70
                Me.grdDatos.Columns("clrEstado").Width = 70
                Me.grdDatos.Columns("Estado").Width = 100
                ''Me.grdDatos.Columns("Pagos").Width = 55
                ''Me.grdDatos.Columns("chkSurtir").Width = 55
                ''Me.grdDatos.Columns("chkAjustes").Width = 55
                Me.grdDatos.Columns("clrEnvio").Width = 60
                Me.grdDatos.Columns("Envio").Width = 90
                ''Me.grdDatos.Columns("FechaAnulado").Width = 75
                ''Me.grdDatos.Columns("VenceReserva").Width = 75
                Me.grdDatos.Columns("chmRevisado").Width = 150
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(fila).Cells("Codigo").Value, Integer)
                mdlPublicVars.superSearchNombre = CType(Me.grdDatos.Rows(fila).Cells("Estado").Value, String)
                mdlPublicVars.superSearchFecha = CType(Me.grdDatos.Rows(fila).Cells("Fecha").Value, DateTime)
                'Contiene el codigo del cliente
                mdlPublicVars.superSearchCodSurtir = CType(Me.grdDatos.Rows(fila).Cells("Clave").Value, String)
                mdlPublicVars.superSearchEstado = CType(Me.grdDatos.Rows(fila).Cells("clrEnvio").Value, Integer)
                mdlPublicVars.superSearchEnvio = CType(Me.grdDatos.Rows(fila).Cells("Envio").Value, String)
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                registroActual = fila
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            Dim formPedido As New frmSalidas
            formPedido.Text = "Ventas"
            formPedido.bitEditarBodega = False
            formPedido.bitEditarSalida = False
            formPedido.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(formPedido, False)
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        If RadMessageBox.Show("¿Desea anular el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnCambioFila()
            Dim codigo As Integer = mdlPublicVars.superSearchId
            AnularSalida(codigo)
        End If
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                fnCambioFila()

                Dim tipoSalida As String = mdlPublicVars.superSearchNombre
                Dim codigo As Integer = mdlPublicVars.superSearchId
                If tipoSalida = "Cotizado" Or tipoSalida = "Reservado" Then
                    frmSalidas.Text = "Editar Ventas"
                    frmSalidas.codigo = codigo
                    frmSalidas.bitEditarBodega = False
                    frmSalidas.bitEditarSalida = True
                    frmSalidas.MdiParent = frmMenuPrincipal
                    permiso.PermisoFrmEspeciales(frmSalidas, False)
                ElseIf tipoSalida = "Despachado" Then
                    Try
                        frmSalidas.Text = "Revision en bodega "
                        frmSalidas.codigo = codigo
                        frmSalidas.bitEditarBodega = True
                        frmSalidas.bitEditarSalida = False
                        frmSalidas.MdiParent = frmMenuPrincipal
                        permiso.PermisoFrmEspeciales(frmSalidas, False)
                    Catch ex As Exception
                        alertas.fnError()
                    End Try
                Else
                    alertas.contenido = "El pedido ya ha sido " & tipoSalida
                    alertas.fnErrorContenido()
                End If
                mdlPublicVars.superSearchNombre = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    'VER
    Private Sub frm_Ver() Handles Me.verRegistro
        Try
            fnCambioFila()

            If Me.grdDatos.RowCount > 0 Then
                If Me.grdDatos.CurrentRow.Index >= 0 Then
                    Dim codigo As Integer = mdlPublicVars.superSearchId
                    Dim estado As String = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Estado").Value

                    frmPedidoConcepto.Text = "Ventas"
                    frmPedidoConcepto.idSalida = codigo
                    frmPedidoConcepto.WindowState = FormWindowState.Normal
                    frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoDialogEspeciales(frmPedidoConcepto)
                    frmPedidoConcepto.Dispose()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnularSalida(ByVal Codigo As Integer)

        Try

            'variables para errores.
            Dim success As Boolean = True
            Dim errContenido As String = ""
            Dim esReserva As Boolean = False
            Dim esCotizado As Boolean = False
            Dim esDespacho As Boolean = True
            Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                'Realizamos la consulta del primer registro con el codigo seleccionado en el grid.
                Dim Datos As tblSalida = (From d In conexion.tblSalidas Where d.idSalida = Codigo Select d).FirstOrDefault()

                'Revisamos si la consulta viene con resultado, de lo contrario mandamos un error.
                If Datos.idSalida = Nothing Then
                    alertas.contenido = "No se encontró el registro seleccinado, Trate de Acualizar el listado!!!"
                    alertas.fnErrorContenido()
                    success = False
                ElseIf Datos.facturado = True And Datos.empacado = True Then
                    'Si la salida que está seleccionado ya ha sido facturado mandamos un error. Porque ya no es posible seguir
                    alertas.contenido = "No es posible anular la salida, ésta ya ha sido Facturado.!!!"
                    alertas.fnErrorContenido()
                    success = False

                ElseIf Datos.anulado Then
                    'La salida ya ha sido anulada
                    alertas.contenido = "La salida ya ha sido anulada"
                    alertas.fnErrorContenido()
                    success = False
                Else

                    'Iniciamos con La Transacción para modificar y revertir las cantidades de productos en inventario.
                    Using transaction As New TransactionScope
                        Try
                            'Verificamos el ultimo estado de salida válida: Cotizado, Reservado ó Despachado.
                            If Datos.cotizado = True And Datos.reservado = False And Datos.despachar = False Then
                                esCotizado = True
                            ElseIf Datos.reservado = True And Datos.despachar = False Then
                                esReserva = True
                            ElseIf Datos.despachar = True Then
                                esDespacho = True
                            End If

                            If esCotizado = True Then
                                Datos.anulado = True
                                Datos.fechaAnulado = fechaServer
                            Else
                                Datos.anulado = True
                                Datos.fechaAnulado = fechaServer


                                'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                                Dim CodArticulo As Integer
                                Dim Pedido As Integer
                                Dim CodInventario As Integer

                                'Consultamos el detalle de la salida correspondiente a la salida que está seleccionado.
                                Dim detalles As List(Of tblSalidaDetalle) = (From x In conexion.tblSalidaDetalles Where x.idSalida = Codigo).ToList

                                'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                                For Each fila As tblSalidaDetalle In detalles
                                    CodArticulo = fila.idArticulo
                                    Pedido = fila.cantidad
                                    CodInventario = fila.tipoInventario

                                    fila.anulado = True
                                    conexion.SaveChanges()

                                    'Se Consulta los datos del articulo en revisión, en la tabla Articulos empresa para que posteriormente se actualice.
                                    Dim inve As tblInventario = (From x In conexion.tblInventarios _
                                                                  Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = CodArticulo And x.idTipoInventario = CodInventario Select x).First


                                    'Actualizar la cantidad del producto en inventario, disminuir la reserva y aumentar la cantidad.
                                    inve.saldo = inve.saldo + Pedido

                                    'Verificamos el estado de la salida es Reserva, si es así modificamos la cantidad de Reserva en inventario.
                                    If esReserva = True Then
                                        inve.reserva = inve.reserva - Pedido
                                    End If

                                    If esDespacho Then
                                        inve.salida = inve.salida - Pedido
                                    End If
                                    'Guardamos los cambios realizados sobre el Articulo en la Empresa que se ha.
                                    conexion.SaveChanges()

                                    'Anulamos el detalle tambien

                                Next
                            End If

                            conexion.SaveChanges()
                            'completar la transaccion.
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
                                alertas.fnErrorGuardar()
                                Exit Try
                                ' If we get to this point, the operation will be retried. 
                            End If
                        End Try

                    End Using

                    If success = True Then
                        conexion.AcceptAllChanges()
                        alertas.fnAnulado()
                    Else
                        Console.WriteLine("La operacion no pudo ser completada")
                    End If
                End If

                'cerrar la conexion
                conn.Close()

                'finalizar proceso.
            End Using


            'Si fue anulado la salida  se vuelve a llenar el grid de salidas.
            frm_llenarLista()
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click



        If Me.grdDatos.Rows.Count > 0 Then
            'obtener el indice seleccionado.
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim fechaservidor As DateTime = CType(fnFecha_horaServidor(), DateTime)
            If (Me.grdDatos.CurrentColumn.Name = "chmRevisado") And fila >= 0 Then
                Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmRevisado").Value
                Dim descripcion As String = Me.grdDatos.Rows(fila).Cells("Estado").Value
                Dim idSalida As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                If valor = False Then
                    Me.grdDatos.Rows(fila).Cells("chmRevisado").Value = True
                    ''If descripcion = "Despachado" And Not mdlPublicVars.superSearchEnvio.Equals("Autorizacion") Then
                    If RadMessageBox.Show("Desea confirmar que se ha revisado el Pedido", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                        registroActual = fila
                        'conexion nueva.
                        Dim conexion As New dsi_pos_demoEntities
                        Dim estado
                        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            conn.Open()
                            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                            'Obtenemos la salida a modificar
                            Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault
                            salida.empacado = True
                            salida.fechaFiltro = fechaservidor
                            conexion.SaveChanges()
                            'Obtenemos el estado
                            estado = (From x In conexion.sp_salida_Estado(mdlPublicVars.idEmpresa, idSalida) Select x).FirstOrDefault

                            'YOEL
                            'Verificamos si tiene pagos a favor
                            Dim listadoPagos As List(Of tblCaja) = (From x In conexion.tblCajas Where x.cliente = salida.idCliente _
                                                                    And x.afavor > 0 And x.confirmado And x.anulado = False Select x).ToList()
                            Dim montoPagar As Decimal = 0
                            Dim consumido As Decimal = 0
                            For Each pago As tblCaja In listadoPagos
                                'Obtenemos la lista de salidas
                                montoPagar = pago.afavor
                                consumido = 0

                                Dim listadoSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                                                           Where x.idCliente = pago.cliente And x.empacado And Not x.anulado And Not x.facturado _
                                                                            And x.saldo > 0
                                                                           Order By x.fechaDespachado Select x).ToList

                                For Each salidaPendiente As tblSalida In listadoSalidas
                                    If montoPagar = 0 Then
                                        Exit For
                                    End If

                                    Dim detallePago As New tblCajaSalida
                                    detallePago.idCaja = pago.codigo
                                    detallePago.idSalida = salidaPendiente.idSalida
                                    detallePago.idCliente = pago.cliente
                                    detallePago.fechaRegistro = fechaservidor
                                    detallePago.fechaFiltro = fechaservidor

                                    'puede que sea aqui
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
                                Next
                                pago.consumido += consumido
                                pago.afavor -= consumido
                                conexion.SaveChanges()
                            Next


                            frmPedidosBodega.Text = "Bodega"
                            frmPedidosBodega.idSalida = idSalida
                            frmPedidosBodega.StartPosition = FormStartPosition.CenterScreen
                            frmPedidosBodega.BringToFront()
                            frmPedidosBodega.Focus()
                            permiso.PermisoDialogEspeciales(frmPedidosBodega)
                            frmPedidosBodega.Dispose()

                            'Obtenemos el estado
                            'Dim estado = (From x In ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, idSalida) Select x).FirstOrDefault

                            If estado IsNot Nothing Then
                                ''If estado.clrEnvio <> 1 Then
                                fnFacturar(idSalida)
                                ''Else
                                ''RadMessageBox.Show("No se puede facturar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                ''End If
                            End If

                            Dim sfactura As Integer = (From x In conexion.tblSalida_Factura Where x.salida = idSalida Select x).Count

                            If sfactura > 0 Then

                                Try
                                    RadMessageBox.Show("La cantidad de Facturas a Imprimir son: " & CStr(sfactura), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                Catch ex As Exception
                                    RadMessageBox.Show("La cantidad de Facturas a Imprimir son: " + CStr(sfactura), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                End Try

                                Dim facturas As List(Of tblSalida_Factura) = (From x In conexion.tblSalida_Factura Where x.salida = idSalida Select x).ToList

                                For Each f As tblSalida_Factura In facturas

                                    Try

                                        Dim bitAnulado As Boolean = False
                                        Dim bitSugerirResolucion As Boolean = False
                                        Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = f.factura Select x).FirstOrDefault
                                        bitAnulado = factura.anulado

                                        ''Validacion si la factura no tiene resolucion
                                        If factura.idResolucion Is Nothing And factura.anulado = False Then
                                            bitSugerirResolucion = True
                                        Else
                                            bitSugerirResolucion = False
                                        End If

                                        ''Verificacion de que no este anulada
                                        If bitAnulado = True Then
                                            MessageBox.Show("Factura Anualda !!!", mdlPublicVars.nombreSistema)
                                            Exit For
                                        End If

                                        ''Verificacion de Asignacion de Resolucion
                                        If bitSugerirResolucion = True Then
                                            Try

                                                ''MessageBox.Show("Debe verificar datos de impresion !!!")

                                                ''Desplega el formulario de asignacion de Resolucion
                                                frmFacturaDescuento.codigo = factura.IdFactura
                                                frmFacturaDescuento.Text = "Datos de Impresión"
                                                frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
                                                frmFacturaDescuento.ShowDialog()

                                            Catch ex As Exception
                                                RadMessageBox.Show(ex.Message, nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                            End Try

                                        End If

                                        Try

                                            Dim conection As dsi_pos_demoEntities
                                            Using con As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                                con.Open()
                                                conection = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                                Dim nfactura As tblFactura = (From x In conection.tblFacturas Where x.IdFactura = f.factura Select x).FirstOrDefault

                                                If nfactura.idResolucion > 0 Or nfactura.idResolucion IsNot Nothing Then

                                                    Dim impresion As tblImpresion = (From x In conection.tblImpresions Where CType(x.descripcion, String) = CType(nfactura.IdFactura, String) And x.tblTipoImpresion.bitFactura = True Select x).FirstOrDefault
                                                    If impresion IsNot Nothing Then
                                                        If impresion.bitImpreso = False Then

                                                            Dim reportetipo As String = ""

                                                            Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                                                            If sal.credito = True Then
                                                                reportetipo = "factura_FacturaSinDescCR.rpt"
                                                            ElseIf sal.contado = True Then
                                                                reportetipo = "factura_FacturaSinDesc.rpt"
                                                            End If

                                                            Dim r As New clsReporte
                                                            conection.CommandTimeout = 10000
                                                            r.tabla = mdlPublicVars.EntitiToDataTable(conection.sp_ReporteFactura1("", impresion.descripcion, mdlPublicVars.idEmpresa))
                                                            r.nombreParametro = "@filtro"
                                                            r.reporte = reportetipo
                                                            r.parametro = ""
                                                            ''r.verReporte()
                                                            r.imprimirReporte()

                                                            ''frmImpresionFacturas.Text = "Impresion Facturas"
                                                            ''frmImpresionFacturas.StartPosition = FormStartPosition.CenterScreen
                                                            ''frmImpresionFacturas.WindowState = FormWindowState.Normal
                                                            ''frmImpresionFacturas.descripcion = impresion.descripcion
                                                            ''frmImpresionFacturas.ShowDialog()
                                                            ''frmImpresionFacturas.Dispose()

                                                            If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                                                impresion.bitImpreso = True
                                                                impresion.usuarioImprime = mdlPublicVars.idUsuario
                                                                impresion.fechaImpresion = CDate(fnFecha_horaServidor())
                                                                conection.SaveChanges()

                                                                Dim facturam As tblFactura = (From x In conection.tblFacturas Where x.IdFactura = factura.IdFactura Select x).FirstOrDefault
                                                                facturam.bitImpreso = True

                                                                conection.SaveChanges()
                                                                ''Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = True
                                                            Else
                                                                ''Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False
                                                            End If

                                                        End If
                                                    End If
                                                Else
                                                    RadMessageBox.Show("No se Encontro Resolucion", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                                End If

                                                con.Close()
                                            End Using
                                        Catch ex As Exception
                                            RadMessageBox.Show(ex.Message, nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                        End Try
                                    Catch ex As Exception
                                    End Try
                                Next
                                ''RadMessageBox.Show("Proceso de Facturacion Finalizada", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            Else
                                RadMessageBox.Show("Ocurrio un Error", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            End If
                            conn.Close()
                        End Using
                    Else
                        Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmRevisado").Value = False
                    End If
                End If
                llenagrid()
            End If
        End If

        Return False
    End Function

    Private Sub frmPedidosLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'Funcion utilizada para facturar
    Private Sub fnFacturar(ByVal idSalida As Integer)
        'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos

        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault


            If salida IsNot Nothing Then
                Dim consulta = (From x In ctx.tblSalidas _
                            Where x.idSalida = salida.idSalida _
                            Select Codigo = x.idSalida, Pagos = If(x.contado = True, "Contado", "Credito"), Fecha = x.fechaRegistro, Documento = x.documento, _
                            DireccionFacturacion = x.direccionFacturacion, Vendedor = x.tblVendedor.nombre, Total = x.total, clrEstado = 0, Estado = "Revisado", Descripcion = "", Clave = salida.idCliente).FirstOrDefault

                Dim codigo1 = consulta.Codigo
                Dim pagos1 = consulta.Pagos
                Dim fecha1 = consulta.Fecha
                Dim documento1 = consulta.Documento
                Dim vendedor1 = consulta.Vendedor
                Dim total1 = consulta.Total
                Dim direccion1 = consulta.DireccionFacturacion

                Dim agregar As Integer = 0


                If salida IsNot Nothing Then
                    'Si la salida ya esta revisada
                    If salida.empacado = True And salida.anulado = False Then
                        'Verificamos si el cliente tiene mas facturas

                        Dim consFacturas = (From x In ctx.tblSalidas
                                  Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa And x.idCliente = salida.idCliente _
                                   And x.anulado = False Select Codigo = x.idSalida).ToList()

                        Dim nFacturas As Integer = 0
                        Dim xx
                        For Each xx In consFacturas
                            Dim estado = conexion.sp_salida_Estado(mdlPublicVars.idEmpresa, xx).ToList
                            'From x In ctx.sp_salida_Estado1(mdlPublicVars.idEmpresa, xx).ToList
                            'Dim estado As Integer = ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, xx).First()

                            For Each es As sp_salida_Estado_Result In estado
                                If es.clrEnvio <> 1 Then
                                    nFacturas = nFacturas + 1
                                End If
                            Next
                        Next


                        If nFacturas > 1 Then
                            If RadMessageBox.Show("¿Tiene " & nFacturas & " Pedidos, desea elegir cuales facturar?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                                frmFactura.Text = "Factura"
                                frmFactura.MdiParent = frmMenuPrincipal
                                frmFactura.codigoCliente = mdlPublicVars.superSearchCodSurtir
                                frmFactura.WindowState = FormWindowState.Maximized
                                permiso.PermisoFrmEspeciales(frmFactura, False)
                            Else
                                If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                                    agregar = 1
                                End If
                            End If
                        Else
                            If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                                agregar = 1
                            End If
                        End If




                        If agregar = 1 Then
                            'Vaciamos la tabla con los codigos
                            mdlPublicVars.General_CodigoSalida.Rows.Clear()
                            mdlPublicVars.General_CodigoSalida.Rows.Add(codigo1, Format(fecha1, mdlPublicVars.formatoFecha), documento1, vendedor1, Format(total1, mdlPublicVars.formatoMoneda))
                            Dim total As Decimal = mdlPublicVars.fnTotalTablaFacturas

                            mdlPublicVars.GuardarFacturacion(idSalida)


                            'comentamos esto para no mostrar el formulario de impresion

                            frmFacturaImprimir.Text = "Facturar"

                            'If pagos1 = "Contado" Then
                            '    frmFacturaImprimir.bitContado = True
                            '    frmFacturaImprimir.bitCredito = False
                            'Else
                            '    frmFacturaImprimir.bitContado = False
                            '    frmFacturaImprimir.bitCredito = True
                            'End If
                            'frmFacturaImprimir.codClie = salida.idCliente
                            'frmFacturaImprimir.dirFact = direccion1
                            'frmFacturaImprimir.StartPosition = FormStartPosition.CenterScreen
                            'permiso.PermisoFrmEspeciales(frmFacturaImprimir, False)


                        End If

                        ''Dim sfactura As Integer = (From x In conexion.tblSalida_Factura Where x.salida = idSalida Select x).Count

                        ''If sfactura > 0 Then

                        ''    Dim facturas As List(Of tblSalida_Factura) = (From x In conexion.tblSalida_Factura Where x.salida = idSalida Select x).ToList

                        ''    For Each f As tblSalida_Factura In facturas

                        ''        Try

                        ''            Dim bitAnulado As Boolean = False
                        ''            Dim bitSugerirResolucion As Boolean = False
                        ''            Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = f.factura Select x).FirstOrDefault
                        ''            bitAnulado = factura.anulado

                        ''            ''Validacion si la factura no tiene resolucion
                        ''            If factura.idResolucion Is Nothing And factura.anulado = False Then
                        ''                bitSugerirResolucion = True
                        ''            Else
                        ''                bitSugerirResolucion = False
                        ''            End If

                        ''            ''Verificacion de que no este anulada
                        ''            If bitAnulado = True Then
                        ''                MessageBox.Show("Factura Anualda !!!", mdlPublicVars.nombreSistema)
                        ''                Exit For
                        ''            End If

                        ''            ''Verificacion de Asignacion de Resolucion
                        ''            If bitSugerirResolucion = True Then

                        ''                MessageBox.Show("Debe verificar datos de impresion !!!")

                        ''                ''Desplega el formulario de asignacion de Resolucion
                        ''                frmFacturaDescuento.codigo = factura.IdFactura
                        ''                frmFacturaDescuento.Text = "Datos de Impresión"
                        ''                frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
                        ''                frmFacturaDescuento.ShowDialog()

                        ''            End If

                        ''            If factura.idResolucion > 0 Or factura.idResolucion IsNot Nothing Then

                        ''                Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where CType(x.descripcion, String) = CType(factura.IdFactura, String) And x.tblTipoImpresion.bitFactura = True Select x).FirstOrDefault
                        ''                If impresion IsNot Nothing Then
                        ''                    If impresion.bitImpreso = False Then

                        ''                        Dim r As New clsReporte
                        ''                        conexion.CommandTimeout = 10000
                        ''                        r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", impresion.descripcion, mdlPublicVars.idEmpresa))
                        ''                        r.nombreParametro = "@filtro"
                        ''                        r.reporte = impresion.tblTipoImpresion.reporte
                        ''                        r.parametro = ""
                        ''                        r.verReporte()
                        ''                        ''r.imprimirReporte()

                        ''                        If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        ''                            impresion.bitImpreso = True
                        ''                            impresion.usuarioImprime = mdlPublicVars.idUsuario
                        ''                            impresion.fechaImpresion = CDate(fnFecha_horaServidor())
                        ''                            conexion.SaveChanges()


                        ''                            Dim facturam As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = factura.IdFactura Select x).FirstOrDefault
                        ''                            facturam.bitImpreso = True


                        ''                            conexion.SaveChanges()
                        ''                            ''Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = True
                        ''                        Else
                        ''                            ''Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False
                        ''                        End If

                        ''                    End If
                        ''                End If
                        ''            End If

                        ''        Catch ex As Exception
                        ''        End Try

                        ''        conn.Close()


                        ''    Next

                        ''Else
                        ''    alerta.contenido = "Ocurrio un Error"
                        ''    alerta.fnErrorContenido()
                        ''End If


                        Me.frm_llenarLista()
                    Else
                        alertas.contenido = "No se puede facturar"
                        alertas.fnErrorContenido()
                    End If
                Else
                    If salida.anulado Then
                        alertas.contenido = "El pedido ya ha sido anulado"
                    Else
                        alertas.contenido = "El pedido no ha sido revisado"
                    End If
                    alertas.fnErrorContenido()
                End If
            Else
                alertas.contenido = "Error en la operacion"
                alertas.fnErrorContenido()
            End If
            conn.Close()
        End Using
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Ventas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    'CAMBIO DE FILTRO FECHA
    Public Overloads Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
        If cargo Then

            frm_llenarLista()
        End If
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmPedidosFiltro.Text = "Filtro: PEDIDOS"
        frmPedidosFiltro.StartPosition = FormStartPosition.CenterScreen
        frmPedidosFiltro.Show()
        'permiso.PermisoFrmEspeciales(frmProductoFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
        llenagrid()
    End Sub

    Private Sub btnDetalleVentas_Click(sender As Object, e As EventArgs) Handles btnDetalleVentas.Click
        Try
            fnCambioFila()

            If mdlPublicVars.superSearchFilasGrid > 0 Then

                Dim salida As tblSalida
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos
                    salida = (From x In conexion.tblSalidas Where x.idSalida = mdlPublicVars.superSearchId Select x).FirstOrDefault
                    conn.Close()
                End Using

                Dim conx3 As dsi_pos_demoEntities
                Using conn3 As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn3.Open()
                    conx3 = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim tblsal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                    If tblsal.facturado = True Then

                        frmAlertasPantalla.Text = "Alertas Pantalla"
                        frmAlertasPantalla.lblMensaje.Text = "¡ESTA SALIDA YA FUE FACTURADA!"
                        frmAlertasPantalla.lblPiePagina.Text = "¡SE ENVIARA CORREO INFORMATIVO A GERENCIA GENERAL!"
                        frmAlertasPantalla.WindowState = FormWindowState.Maximized
                        frmAlertasPantalla.StartPosition = FormStartPosition.CenterScreen
                        frmAlertasPantalla.ShowDialog()
                        frmAlertasPantalla.Dispose()

                        conn3.Close()
                        Exit Sub
                    End If

                    conn3.Close()
                End Using

                If salida.anulado = True Or salida.facturado = True Then
                    alerta.contenido = "Venta Facturada o Anulada "
                    alerta.fnErrorContenido()
                    Exit Sub
                End If

                If salida IsNot Nothing Then
                    'Si la salida ya esta revisada
                    If salida.empacado = True And salida.anulado = False Then



                        Dim estado

                        Dim conexion2 As New dsi_pos_demoEntities

                        Using conn2 As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            conn2.Open()
                            conexion2 = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                            'Obtenemos el estado
                            estado = New List(Of sp_salida_Estado_Result)
                            estado = From x In conexion2.sp_salida_Estado(mdlPublicVars.idEmpresa, salida.idSalida).ToList()
                            conn2.Close()
                        End Using

                        For Each es As sp_salida_Estado_Result In estado
                            ''If es.clrEnvio <> 1 Then
                            fnFacturar(salida)
                            ''fnValidarSalida(salida)
                            ''Else
                            '' RadMessageBox.Show("Debe autorizar el pedido", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            ''End If
                        Next
                    Else
                        If salida.anulado Then
                            alerta.contenido = "El pedido ya ha sido anulado"
                        Else
                            alerta.contenido = "El pedido no ha sido revisado"
                        End If
                        alerta.fnErrorContenido()
                    End If
                Else
                    alerta.contenido = "Error en la operacion"
                    alerta.fnErrorContenido()
                End If
            End If
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    Private Sub fnautorizarventa()
        fnCambioFila()

        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim codigo As Integer = mdlPublicVars.superSearchId
            Dim tipoVenta As String = mdlPublicVars.superSearchEnvio
            'Obtenemos la salida y el usuario

            Dim salida As tblSalida
            Dim usuario As tblUsuario
            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                salida = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x).FirstOrDefault
                usuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                If mdlPublicVars.superSearchEstado = 1 Then
                    'Fecha del servidor
                    Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
                    If usuario.bitAutorizaVenta Then
                        If RadMessageBox.Show("¿Desea autorizar la venta?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            frmIngresaClave.Text = "Ingrese clave"
                            frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
                            permiso.PermisoDialogEspeciales(frmIngresaClave)
                            frmIngresaClave.Dispose()
                            If mdlPublicVars.fnAutorizaClave(mdlPublicVars.superSearchClave) Then
                                salida.autorizado = True
                                salida.usuarioAutorizo = usuario.idUsuario
                                salida.fechaAutorizado = fechaServidor
                                conexion.SaveChanges()
                                RadMessageBox.Show("Venta autorizada correctamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Question)
                                frm_llenarLista()
                            Else
                                RadMessageBox.Show("Clave ingresada incorrecta!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                            End If
                        End If
                    Else
                        RadMessageBox.Show("No tiene permisos para autorizar una venta ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End If
                End If

                'cerrar la conexion
                conn.Close()
            End Using

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            fnautorizarventa()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnRealizarPago()
        Try
            fnCambioFila()

            If mdlPublicVars.superSearchFilasGrid > 0 Then
                'Obtenemos el saldo del cliente

                Dim cliente As tblCliente
                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                    cliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = mdlPublicVars.superSearchCodSurtir
                                                 Select x).FirstOrDefault
                    conn.Close()
                End Using


                frmPagoClientes.Text = "Pagos"
                frmPagoClientes.bitCliente = True
                frmPagoClientes.codigoCP = mdlPublicVars.superSearchCodSurtir
                frmPagoClientes.lblSaldo.Text = cliente.saldo
                frmPagoClientes.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmPagoClientes)
                frmPagoClientes.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fnRealizarPago()
    End Sub

    Private Sub bntBuscar_Click(sender As Object, e As EventArgs)
        Try
            Me.grdDatos.DataSource = Nothing

            llenagrid()
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

                    Dim idsalida As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                    Dim idclie As Integer = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x.idCliente).FirstOrDefault

                    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                    ''frmInformacionGuia.Text = "Informacion Guia"
                    ''frmInformacionGuia.idSalida = idsalida
                    ''frmInformacionGuia.StartPosition = FormStartPosition.CenterScreen
                    ''frmInformacionGuia.WindowState = FormWindowState.Normal
                    ''permiso.PermisoDialogEspeciales(frmInformacionGuia)
                    ''frmInformacionGuia.Dispose() 

                    ''Dim r As New clsReporte
                    ''r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteGuiasImpresion(idclie, idsalida))
                    '' ''r.nombreParametro = "@filtro"
                    ''r.reporte = "rptReporteGuiaGuatexImpresion.rpt"
                    ''r.imprimirReporte()
                    If salida.bitguia = True Then
                        If RadMessageBox.Show("La Guia ya fue impresa!, Quiere reimprimirla?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            frmImpresionGuias.Text = "Impresion Guias"
                            frmImpresionGuias.idSalida = idsalida
                            frmImpresionGuias.idcliente = idclie
                            frmImpresionGuias.WindowState = FormWindowState.Normal
                            frmImpresionGuias.StartPosition = FormStartPosition.CenterScreen
                            permiso.PermisoDialogEspeciales(frmImpresionGuias)
                            frmImpresionGuias.Dispose()
                        End If
                    Else
                        frmImpresionGuias.Text = "Impresion Guias"
                        frmImpresionGuias.idSalida = idsalida
                        frmImpresionGuias.idcliente = idclie
                        frmImpresionGuias.WindowState = FormWindowState.Normal
                        frmImpresionGuias.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoDialogEspeciales(frmImpresionGuias)
                        frmImpresionGuias.Dispose()
                    End If

                    conn.Close()
                End Using
            ElseIf e.KeyCode = Keys.F10 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

                Dim idsalida As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                frmInformacionGuia.Text = "Informacion Guia"
                frmInformacionGuia.idSalida = idsalida
                frmInformacionGuia.WindowState = FormWindowState.Normal
                frmInformacionGuia.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmInformacionGuia)
                frmInformacionGuia.Dispose()

            End If
        Catch ex As Exception

        End Try
    End Sub

    ''Private Sub rbtReservado_CheckedChanged(sender As Object, e As EventArgs)
    ''    If rbtReservado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtReservado.Text
    ''    ElseIf rbtCotizado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtCotizado.Text
    ''    ElseIf rbtEmpacado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtEmpacado.Text
    ''    ElseIf rbtDespachado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtDespachado.Text
    ''    ElseIf rbtFacturado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtFacturado.Text
    ''    ElseIf rbtAnulado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtAnulado.Text
    ''    End If
    ''End Sub

    ''Private Sub rbtCotizado_CheckedChanged(sender As Object, e As EventArgs)
    ''    If rbtReservado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtReservado.Text
    ''    ElseIf rbtCotizado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtCotizado.Text
    ''    ElseIf rbtEmpacado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtEmpacado.Text
    ''    ElseIf rbtDespachado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtDespachado.Text
    ''    ElseIf rbtFacturado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtFacturado.Text
    ''    ElseIf rbtAnulado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtAnulado.Text
    ''    End If
    ''End Sub

    ''Private Sub rbtDespachado_CheckedChanged(sender As Object, e As EventArgs)
    ''    If rbtReservado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtReservado.Text
    ''    ElseIf rbtCotizado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtCotizado.Text
    ''    ElseIf rbtEmpacado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtEmpacado.Text
    ''    ElseIf rbtDespachado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtDespachado.Text
    ''    ElseIf rbtFacturado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtFacturado.Text
    ''    ElseIf rbtAnulado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtAnulado.Text
    ''    End If
    ''End Sub

    ''Private Sub rbtEmpacado_CheckedChanged(sender As Object, e As EventArgs)
    ''    If rbtReservado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtReservado.Text
    ''    ElseIf rbtCotizado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtCotizado.Text
    ''    ElseIf rbtEmpacado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtEmpacado.Text
    ''    ElseIf rbtDespachado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtDespachado.Text
    ''    ElseIf rbtFacturado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtFacturado.Text
    ''    ElseIf rbtAnulado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtAnulado.Text
    ''    End If
    ''End Sub

    ''Private Sub rbtFacturado_CheckedChanged(sender As Object, e As EventArgs)
    ''    If rbtReservado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtReservado.Text
    ''    ElseIf rbtCotizado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtCotizado.Text
    ''    ElseIf rbtEmpacado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtEmpacado.Text
    ''    ElseIf rbtDespachado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtDespachado.Text
    ''    ElseIf rbtFacturado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtFacturado.Text
    ''    ElseIf rbtAnulado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtAnulado.Text
    ''    End If
    ''End Sub

    ''Private Sub rbtAnulado_CheckedChanged(sender As Object, e As EventArgs)
    ''    If rbtReservado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtReservado.Text
    ''    ElseIf rbtCotizado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtCotizado.Text
    ''    ElseIf rbtEmpacado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtEmpacado.Text
    ''    ElseIf rbtDespachado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtDespachado.Text
    ''    ElseIf rbtFacturado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtFacturado.Text
    ''    ElseIf rbtAnulado.Checked Then
    ''        Me.txtEstado.Text = Me.rbtAnulado.Text
    ''    End If
    ''End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            llenagrid()
        Catch ex As Exception

        End Try
    End Sub
End Class
