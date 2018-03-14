Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports System.Transactions
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmClienteDevolucionLista
    Public permiso As New clsPermisoUsuario

    Private _bitCliente As Boolean
    Private _bitAjuste As Boolean
    Private _bitVenta As Boolean

    Public Property bitCliente As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Public Property bitAjuste As Boolean
        Get
            bitAjuste = _bitAjuste
        End Get
        Set(ByVal value As Boolean)
            _bitAjuste = value
        End Set
    End Property

    Public Property bitVenta As Boolean
        Get
            bitVenta = _bitVenta
        End Get
        Set(ByVal value As Boolean)
            _bitVenta = value
        End Set
    End Property

    Private Sub frmMovimientoInventariosLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmClienteDevolucionLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"
        Try
            If bitAjuste Then
                Dim iz As New frmMovimientoInventariosBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If

            If bitCliente Then
                Dim iz As New frmClientesBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If

            If bitVenta Then
                Dim iz As New frmPedidosFacturasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If

            frmBarraLateralBaseDerecha = frmClienteDevolucionBarraDerecha

            ActivarBarraLateral = True

        Catch ex As Exception

        End Try

        llenagrid()
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        fnConfiguracion()

        Me.txtFiltro.Visible = False
        Me.Label2.Visible = False
        Me.lblFiltroFecha.Visible = False
    End Sub

    Private Sub llenagrid()
        Try
            Me.grdDatos.Columns.Clear()
            Dim filtro As String = txtFiltro.Text

            Dim fechainicio As DateTime = Me.dtpFechaInicio.Value.ToShortDateString() + " 00:00:00.000"
            Dim fechafin As DateTime = Me.dtpFechaFin.Value.ToShortDateString() + " 23:59:59.999"

            Dim consulta = From y In ctx.tblDevolucionClientes _
                           Where (y.tblCliente.Negocio.Contains(filtro) Or (filtro = "Devolucion") Or (filtro = "Devolucion Cliente")) And (y.fechaRegistro > fechainicio And y.fechaRegistro < fechafin) _
                           Select Codigo = y.codigo, Fecha = y.fechaFiltro, Usuario = y.tblVendedor.nombre, CodigoCliente = y.tblCliente.clave, Cliente = y.tblCliente.Negocio, Documento = y.documento, _
                           Total = (From x In ctx.tblDevolucionClienteDetalles Where x.devolucion = y.codigo Select (x.cantidadAceptada * x.costo)).Sum, _
                           Observacion = y.observacion, chkAnulado = y.anulado, clrEstado = CType(If(y.anulado = True, "0", If(y.acreditado = False, "1", If(y.acreditado = True, "4", ""))), Integer),
                           chmConfirmar = y.acreditado _
                           Order By Fecha Descending, Codigo Descending

            Me.grdDatos.DataSource = consulta

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)
            fnConfiguracion()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")
                Me.grdDatos.Columns("clrEstado").HeaderText = "Estado"

                Me.grdDatos.Columns("Codigo").TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns("Usuario").TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns("Cliente").TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns("Documento").TextAlignment = ContentAlignment.BottomCenter

                Me.grdDatos.Columns("Codigo").Width = 50
                Me.grdDatos.Columns("Fecha").Width = 70
                Me.grdDatos.Columns("Total").Width = 80
                Me.grdDatos.Columns("Usuario").Width = 100
                Me.grdDatos.Columns("CodigoCliente").Width = 50
                Me.grdDatos.Columns("Cliente").Width = 150
                Me.grdDatos.Columns("Documento").Width = 60
                Me.grdDatos.Columns("Observacion").Width = 200
                Me.grdDatos.Columns("chkAnulado").Width = 100
                Me.grdDatos.Columns("clrEstado").Width = 80
                Me.grdDatos.Columns("chmConfirmar").Width = 80
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            Dim frm As Form = frmClienteDevolucion
            frm.Text = "Devolución de Cliente"
            frm.MdiParent = frmMenuPrincipal
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
            'permiso.PermisoFrmBaseEspeciales(frm, True)

        Catch ex As Exception
        End Try

    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Dim acreditado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value, Boolean)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)

        If anulado = True Then
            alertas.contenido = "La devolución ya ha sido anulada"
            alertas.fnErrorContenido()
        ElseIf acreditado = True Then
            alertas.contenido = "La devolucion ya ha sido acreditada"
            alertas.fnErrorContenido()
        Else
            frmClienteDevolucion.Text = "Devolucion de Cliente"
            frmClienteDevolucion.MdiParent = frmMenuPrincipal
            frmClienteDevolucion.codigoReclamo = mdlPublicVars.superSearchId
            frmClienteDevolucion.bitModificar = True
            permiso.PermisoFrmEspeciales(frmClienteDevolucion, False)
            'End If
        End If
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        fnAnularMovimiento()
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Try
            frmClienteDevolucionConceptos.Text = "Devolución de Cliente"
            frmClienteDevolucionConceptos.WindowState = FormWindowState.Normal
            frmClienteDevolucionConceptos.StartPosition = FormStartPosition.CenterScreen
            frmClienteDevolucionConceptos.idDevolucion = mdlPublicVars.superSearchId
            permiso.PermisoDialogEspeciales(frmClienteDevolucionConceptos)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Codigo").Value, Integer)
                ''mdlPublicVars.superSearchNombre = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Movimiento").Value, String)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click

        If Me.grdDatos.Rows.Count > 0 Then
            If (Me.grdDatos.CurrentColumn.Name = "chmConfirmar") And Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim valor As Boolean = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value
                If valor = False Then
                    Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value = True
                    'Dim movimiento As String = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Movimiento").Value, String)

                    If RadMessageBox.Show("¿Desea confirmar devolución?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                        'If movimiento = "Ajuste en Bodega" Or movimiento = "Traslado entre bodegas" Or movimiento = "Ajuste en Venta" Then
                        'fnAcreditarMovimiento()
                        'ElseIf movimiento = "Devolucion Cliente" Then
                        fnAcreditarDevolucionCliente()


                    End If
                Else
                    Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value = False
                End If
            End If
        End If

        Return False
    End Function

    Private Sub fnAcreditarMovimiento()
        Dim success As Boolean = True
        Dim codigo As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Codigo").Value, Integer)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
        Dim tipoMovimiento As String = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Movimiento").Value, String)
        Dim cantidadInsuficiente As Boolean = False
        Dim nombreArticuloInsuficiente As String = ""
        Dim fechaServidor As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)

        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope

                'inicio de excepcion
                Try
                    If anulado = True Then
                        success = False
                        Exit Try
                    End If

                    'Primero obtenemos el encabezado del movimiento de inventario
                    Dim movimiento As tblMovimientoInventario = (From x In conexion.tblMovimientoInventarios Where x.codigo = codigo Select x).FirstOrDefault
                    Dim fechaAcreditado As DateTime = fnFecha_horaServidor()
                    'Acreditamos el encabezado
                    movimiento.revisado = True
                    movimiento.fechaRevisado = fechaAcreditado
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
                alertas.contenido = tipoMovimiento + " acreditado exitosamente!!!"
                alertas.fnErrorContenido()

            Else
                If anulado = True Then
                    alertas.contenido = tipoMovimiento + " ya ha sido anulado!!!"
                    alertas.fnErrorContenido()

                ElseIf cantidadInsuficiente = True Then
                    alertas.contenido = "Cantidad insuficiente de " & nombreArticuloInsuficiente + ". Revisar " & tipoMovimiento
                    alertas.fnErrorContenido()
                Else

                    alertas.fnErrorGuardar()
                    Console.WriteLine("La operacion no pudo ser completada")
                End If
            End If

            conn.Close()
        End Using

        Dim fila As Integer = CType(Me.grdDatos.CurrentRow.Index, Integer)
        llenagrid()
        Me.grdDatos.Rows(fila).IsCurrent = True
    End Sub

    Private Sub fnAcreditarDevolucionCliente()
        Dim codigo As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Codigo").Value, Integer)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
        Dim success As Boolean = True
        Dim fechaAcreditado As DateTime = fnFecha_horaServidor()

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope

                'inicio de excepcion
                Try
                    Dim negativo As Double = 0
                    'Obtenemos el encabezado de la devolucion de cliente
                    Dim devolucion As tblDevolucionCliente = (From x In conexion.tblDevolucionClientes Where x.codigo = codigo Select x).FirstOrDefault

                    'Acreditamos la devolucion de cliente
                    devolucion.acreditado = True
                    devolucion.acreditadoFecha = fechaAcreditado
                    conexion.SaveChanges()

                    'Obtenemos la lista de los detalles de la devolucion
                    Dim listaDetalles As List(Of tblDevolucionClienteDetalle) = (From x In conexion.tblDevolucionClienteDetalles Where x.devolucion = codigo Select x).ToList
                    Dim detalle As tblDevolucionClienteDetalle

                    For Each detalle In listaDetalles
                        Dim articulo As Integer = CType(detalle.articulo, Integer)
                        Dim cantidad As Integer = CType(detalle.cantidadAceptada, Integer)
                        Dim idTipoInventario As Integer

                        Dim inventario As tblInventario

                        If detalle.cantidadAceptada > 0 Then
                            If detalle.solucion = True Then

                                'Aumentamos la cantidad que se le debitara al saldo del cliente
                                negativo += detalle.total
                            End If

                            idTipoInventario = CType(detalle.tipoInventario, Integer)
                            'Si se soluciona la devoulucion, entonces...
                            'Seleccionamos el articulo filtrando por el inventario
                            inventario = (From x In conexion.tblInventarios
                                          Where x.idArticulo = articulo And x.idTipoInventario = idTipoInventario And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                           Select x).FirstOrDefault

                            If inventario Is Nothing Then
                                'Si el registro en inventario no existiera se crea el registro de inventario
                                Dim nuevoInventario As New tblInventario
                                nuevoInventario.idArticulo = articulo
                                nuevoInventario.saldo = cantidad
                                nuevoInventario.entrada = cantidad
                                nuevoInventario.salida = 0
                                nuevoInventario.reserva = 0
                                nuevoInventario.transito = 0
                                'If detalle.solucion = True Then
                                nuevoInventario.idTipoInventario = idTipoInventario
                                'Else
                                '    nuevoInventario.idTipoInventario = mdlPublicVars.Cliente_InventarioDevolucion
                                'End If

                                nuevoInventario.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                                conexion.AddTotblInventarios(nuevoInventario)
                                conexion.SaveChanges()
                            Else
                                inventario.saldo += cantidad
                                inventario.entrada += cantidad
                                conexion.SaveChanges()
                            End If
                        End If
                    Next
                    'Modificamos el saldo del cliented
                    Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = devolucion.cliente Select x).FirstOrDefault
                    If cliente.devoluciones Is Nothing Then
                        cliente.devoluciones = negativo
                        cliente.saldo -= negativo
                    Else
                        cliente.devoluciones += negativo
                        cliente.saldo -= negativo
                    End If
                    conexion.SaveChanges()

                    ' PROCESO PARA AFECTAR LA SALIDAS
                    If negativo > 0 Then
                        Dim montoPagar2 As Decimal = negativo
                        Dim listaSalidas As List(Of tblSalida) = Nothing
                        'If devolucion.bitFactura Then
                        '    'Obtenemos las salidas de la factura
                        '    listaSalidas = (From x In conexion.tblSalida_Factura
                        '                    Where x.factura = devolucion.factura
                        '                    Order By x.tblSalida.fechaDespachado Descending
                        '                    Select x.tblSalida).ToList

                        '    For Each salida As tblSalida In listaSalidas
                        '        If montoPagar2 > 0 Then

                        '        End If
                        '    Next
                        'Else
                        '    'Obtenemos la salidas con pago > cero
                        '    listaSalidas = (From x In conexion.tblSalidas
                        '                    Where x.idCliente = devolucion.cliente And x.empacado And Not x.anulado And x.pagado > 0 _
                        '                    Order By x.fechaDespachado Descending Select x).ToList

                        '    If listaSalidas.Count = 0 Then
                        '        'Obtenemos las salidas con pagos >=0
                        '        listaSalidas = (From x In conexion.tblSalidas
                        '                    Where x.idCliente = devolucion.cliente And x.empacado And Not x.anulado And x.saldo > 0 _
                        '                    Order By x.fechaDespachado Descending Select x).ToList
                        '    End If
                        'End If
                        listaSalidas = (From x In conexion.tblSalidas
                                                                       Where x.idCliente = cliente.idCliente And x.empacado And Not x.anulado _
                                                                       And x.saldo > 0
                                                                       Order By x.fechaDespachado Ascending Select x).ToList

                        For Each salida As tblSalida In listaSalidas
                            If montoPagar2 = 0 Then
                                Exit For
                            End If

                            If montoPagar2 > salida.saldo Then
                                montoPagar2 -= salida.saldo
                                salida.devoluciones = salida.total
                                salida.saldo = 0
                                If salida.pagado > 0 Then
                                    'Igualamos lo pagado a  0
                                    salida.pagado = 0
                                    'Obtenemos los pagos que afectaron a la salida
                                    Dim listadoPagosDetalle As List(Of tblCajaSalida) = (From x In conexion.tblCajaSalidas Where x.idSalida = salida.idSalida).ToList()
                                    'Recorremos y eliminamos cada detalle de pago
                                    For Each pagodetalle As tblCajaSalida In listadoPagosDetalle
                                        ' Aumentamos el saldo a favor, y disminuimos lo consumido
                                        pagodetalle.tblCaja.consumido -= pagodetalle.monto
                                        pagodetalle.tblCaja.afavor += pagodetalle.monto
                                        conexion.DeleteObject(pagodetalle)
                                    Next
                                End If
                            Else
                                salida.saldo -= montoPagar2
                                salida.devoluciones += montoPagar2
                                montoPagar2 = 0
                            End If
                            conexion.SaveChanges()
                        Next
                    End If

                    'completar la transaccion.
                    success = True
                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
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
                alertas.contenido = " Devolución acreditada exitosamente!!!"
                alertas.fnErrorContenido()

                If RadMessageBox.Show("¿Desea Imprimir?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim r As New clsReporte

                    Try
                        Dim devolucion As tblDevolucionCliente = (From x In ctx.tblDevolucionClientes.AsEnumerable Where x.codigo = codigo Select x).FirstOrDefault

                        r.reporte = "rptDevolucionCliente.rpt"
                        r.tabla = EntitiToDataTable(From x In ctx.sp_reporteDevolucionCliente("", devolucion.codigo))
                        r.nombreParametro = "filtro"
                        r.parametro = "Filtro del reporte:  "

                        frmDocumentosSalida.txtTitulo.Text = "Devolución de Cliente "
                        frmDocumentosSalida.Text = "Docs. de Salida"
                        frmDocumentosSalida.bitCliente = True
                        frmDocumentosSalida.codigo = devolucion.cliente
                        frmDocumentosSalida.reporteBase = r.DocumentoReporte()
                        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

                    Catch ex As Exception
                        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End Try

                End If
            Else
                If anulado = True Then
                    alertas.contenido = "Devolución ya ha sido anulado!!!"
                    alertas.fnErrorContenido()
                Else
                    alertas.fnErrorGuardar()
                    Console.WriteLine("La operacion no pudo ser completada")
                End If
            End If

            'cerrar conexion.
            conn.Close()
        End Using

        'si termino bien el proceso, llenar el grid nuevamente.

        If success = True Then
            Dim fila As Integer = CType(Me.grdDatos.CurrentRow.Index, Integer)
            llenagrid()
            Me.grdDatos.Rows(fila).IsCurrent = True
        End If

    End Sub

    Private Sub fnAnularMovimiento()
        Dim id As Integer = mdlPublicVars.superSearchId
        Dim filas As Integer = fnGrid_codigoFilaSeleccionada(Me.grdDatos)
        Dim tipo As String = mdlPublicVars.superSearchNombre
        Dim acreditado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value, Boolean)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
        Dim fechaAnulado As DateTime = fnFecha_horaServidor()
        Try
            If acreditado = True Then
                alertas.contenido = "El " & tipo & " ya ha sido acreditado"
                alertas.fnErrorContenido()
            ElseIf anulado = True Then
                alertas.contenido = "El " & tipo & " ya ha sido anulado"
                alertas.fnErrorContenido()
            Else
                ''If tipo = "Ajuste en Venta" Or tipo = "Ajuste en Bodega" Or tipo = "Traslado entre Bodegas" Then
                'Seleccionamos el movimiento de inventario a anular
                ''Dim movimiento As tblMovimientoInventario = (From x In ctx.tblMovimientoInventarios Where x.codigo = id Select x).FirstOrDefault
                ''movimiento.anulado = 1
                ''movimiento.anuladoFecha = fechaAnulado
                '' ctx.SaveChanges()
                ''ElseIf tipo = "Devolucion Cliente" Then
                'Seleccionamos la devolucion del cliente
                Dim devolucion As tblDevolucionCliente = (From x In ctx.tblDevolucionClientes Where x.codigo = id Select x).FirstOrDefault
                devolucion.anulado = 1
                devolucion.anuladoFecha = fechaAnulado
                ctx.SaveChanges()
                ''End If
            End If
            Dim fila As Integer = CType(Me.grdDatos.CurrentRow.Index, Integer)
            llenagrid()
            Me.grdDatos.Rows(fila).IsCurrent = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmClienteDevolucionLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Devoluciones de Clientes"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub bntBuscar_Click(sender As Object, e As EventArgs) Handles bntBuscar.Click
        Try
            llenagrid()
        Catch ex As Exception

        End Try
    End Sub
End Class
