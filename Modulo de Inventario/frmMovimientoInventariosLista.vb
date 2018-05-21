Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports System.Transactions
Imports Telerik.WinControls
Imports System.Data.EntityClient


Public Class frmMovimientoInventariosLista
    Public permiso As New clsPermisoUsuario

    Private Sub frmInventarioMovimientosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"
        Try
            Dim iz As New frmMovimientoInventariosBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmMovimientoInventariosBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try
        fnllenarCombo()
        llenagrid()
        fnConfiguracion()
    End Sub

    Private Sub fnLlenarCombo()
        Try

            Dim dt As DataTable = New DataTable("Tabla")

            dt.Columns.Add("Codigo")
            dt.Columns.Add("Descripcion")

            Dim dr As DataRow

            dr = dt.NewRow()
            dr("Codigo") = "0"
            dr("Descripcion") = "Ajuste de Ventas"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "1"
            dr("Descripcion") = "Ajustes de Bodega"
            dt.Rows.Add(dr)

            cmbVendedor.DataSource = dt
            cmbVendedor.ValueMember = "Codigo"
            cmbVendedor.DisplayMember = "Descripcion"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenagrid()
        Try
            Me.grdDatos.Columns.Clear()
            ''Dim filtro As String = txtFiltro.Text
            ''Dim consulta = (From x In ctx.tblMovimientoInventarios _
            ''                Where ((filtro = "") Or (filtro = "Ajuste" And x.ajuste = True) Or (filtro = "Traslado" And x.traslado = True)) _
            ''                And x.tblMovimientoInventarioDetalles.Count > 0 And x.empresa = mdlPublicVars.idEmpresa _
            ''                Select Codigo = x.codigo, Fecha = x.fechaFiltro, _
            ''                Movimiento = CType(If(x.bitVenta = True, "Ajuste en Venta", If(x.ajuste = True, "Ajuste en Bodega", "Traslado entre bodegas")), String), _
            ''                Correlativo = x.correlativo,
            ''                Total = (From y In ctx.tblMovimientoInventarioDetalles Where y.movimientoInventario = x.codigo Select If(y.entrada, y.total, -y.total)).Sum, _
            ''                Observacion = x.observacion, chkAnulado = x.anulado, _
            ''                clrEstado = CType(If(x.anulado = True, "0", If(x.revisado = False, "1", If(x.revisado = True, "4", ""))), Integer), chkBodega = x.bitBodega, _
            ''                chmConfirmar = x.revisado Order By Fecha Descending, Codigo Descending)


            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codigo As Integer

            Try
                codigo = Me.cmbVendedor.SelectedValue
            Catch ex As Exception
                codigo = 0
            End Try

            Dim bitventa As Integer
            Dim bitajuste As Integer

            If codigo = 0 Then
                bitventa = 1
                bitajuste = 0
            ElseIf codigo = 1 Then
                bitventa = 0
                bitajuste = 1
            End If

                Dim consulta = conexion.Sp_ListaMovimientoInventario(mdlPublicVars.idEmpresa, bitventa, bitajuste)

            Me.grdDatos.DataSource = consulta

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)
                fnConfiguracion()

                conn.Close()
            End Using

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")
                Me.grdDatos.Columns("chkBodega").IsVisible = False
                Me.grdDatos.Columns("clrEstado").HeaderText = "Estado"
                Me.grdDatos.Columns("chmConfirmar").HeaderText = "Acreditado"

                'Codigo, Fecha ,  Movimiento, Usuario ,Documento,Total , Observacion, chkAnulado , clrEstado , chkBodega , _
                '            chmConfirmar)
                Me.grdDatos.Columns(0).TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns(1).TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns(2).TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns(3).TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns(4).TextAlignment = ContentAlignment.BottomCenter
                Me.grdDatos.Columns(5).TextAlignment = ContentAlignment.BottomCenter

                Me.grdDatos.Columns("Codigo").Width = 50
                Me.grdDatos.Columns("Fecha").Width = 70
                Me.grdDatos.Columns("Movimiento").Width = 130
                Me.grdDatos.Columns("Correlativo").Width = 55
                Me.grdDatos.Columns("Total").Width = 80
                Me.grdDatos.Columns("Observacion").Width = 180
                Me.grdDatos.Columns("chkAnulado").Width = 50
                Me.grdDatos.Columns("clrEstado").Width = 80
                Me.grdDatos.Columns("chkBodega").Width = 80
                Me.grdDatos.Columns("chmConfirmar").Width = 70

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            If Produccion_Habilitado Then
                frmTipoMovimientoInventario.Text = "Movimiento Inventario"
                frmTipoMovimientoInventario.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmTipoMovimientoInventario)
                frmTipoMovimientoInventario.Dispose()
            Else
                frmMovimientoInventarios.bitModificar = False
                frmMovimientoInventarios.Text = "Ajustes y Traslados"
                frmMovimientoInventarios.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmBaseEspeciales(frmMovimientoInventarios, True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try


            Dim acreditado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value, Boolean)
            Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
            Dim movimiento As String = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Movimiento").Value, String)

            If anulado = True Then
                alertas.contenido = "El " & movimiento & " ya ha sido anulado"
                alertas.fnErrorContenido()
            ElseIf acreditado = True Then
                alertas.contenido = "El " & movimiento & " ya ha sido acreditado"
                alertas.fnErrorContenido()
            Else
                If movimiento = "Ajuste en Bodega" Or movimiento = "Traslado" Then
                    frmMovimientoInventarios.Text = "Movimiento de Inventarios"
                    frmMovimientoInventarios.MdiParent = frmMenuPrincipal
                    frmMovimientoInventarios.bitModificar = True
                    permiso.PermisoFrmEspeciales(frmMovimientoInventarios, False)
                ElseIf movimiento = "Devolucion Cliente" Then
                    frmClienteDevolucion.Text = "Devolucion de Cliente"
                    frmClienteDevolucion.MdiParent = frmMenuPrincipal
                    frmClienteDevolucion.bitModificar = True
                    permiso.PermisoFrmEspeciales(frmClienteDevolucion, False)
                End If

            End If
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        alertas.contenido = "No se puede modificar el registro"
        alertas.fnErrorContenido()
        Exit Sub

        If RadMessageBox.Show("Desea anular el movimiento", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
            fnAnularMovimiento()
        End If
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Try
            'Obtenemos el codigo seleccionado
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = CInt(Me.grdDatos.Rows(fila).Cells("Codigo").Value)

            frmMovimientoInventariosConceptos.Text = "Movimiento Inventario"
            frmMovimientoInventariosConceptos.StartPosition = FormStartPosition.CenterScreen
            frmMovimientoInventariosConceptos.codigo = codigo
            frmMovimientoInventariosConceptos.ShowDialog()
            frmMovimientoInventariosConceptos.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Codigo").Value, Integer)
                mdlPublicVars.superSearchNombre = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Movimiento").Value, String)
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

                    Dim movimiento As String = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Movimiento").Value, String)

                    If RadMessageBox.Show("Desea confirmar " & movimiento & " ??", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) = vbYes Then
                        If movimiento = "Ajuste en Bodega" Or movimiento = "Traslado entre Bodegas" Or movimiento = "Ajuste en Venta" Then
                            fnAcreditarMovimiento()
                        ElseIf movimiento = "Devolucion Cliente" Then
                            fnAcreditarDevolucionCliente()
                        End If
                    Else
                        Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value = False
                    End If
                End If
            End If
            If (Me.grdDatos.CurrentColumn.Name = "chkAnulado") And Me.grdDatos.CurrentRow.Index >= 0 Then
                fnAnularMovimiento()
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
        'crear el encabezado de la transaccion
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                If anulado = True Then
                    success = False
                    Exit Try
                End If

                'Primero obtenemos el encabezado del movimiento de inventario
                Dim movimiento As tblMovimientoInventario = (From x In ctx.tblMovimientoInventarios Where x.codigo = codigo Select x).FirstOrDefault
                Dim fechaAcreditado As DateTime = fnFecha_horaServidor()
                'Acreditamos el encabezado
                movimiento.revisado = True
                movimiento.fechaRevisado = fechaAcreditado
                ctx.SaveChanges()

                fnAcreditarInventario(codigo, conexion)

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
            conn.Close()
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
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
        Dim fila As Integer = CType(Me.grdDatos.CurrentRow.Index, Integer)
        llenagrid()
        Me.grdDatos.Rows(fila).IsCurrent = True
    End Sub

    Private Sub fnAcreditarInventario(ByVal id As Integer, ByVal conexion As dsi_pos_demoEntities)
        Try

            Dim m As tblMovimientoInventario = (From x In conexion.tblMovimientoInventarios Where x.codigo = id Select x).FirstOrDefault

            Dim lista As List(Of tblMovimientoInventarioDetalle) = (From x In conexion.tblMovimientoInventarioDetalles Where x.movimientoInventario = id Select x).ToList()

            Dim t As tblTipoMovimiento
            Dim i As tblInventario
            Dim i2 As tblInventario

            For Each d As tblMovimientoInventarioDetalle In lista

                If m.bitVenta = True Then

                    If m.ajuste Then
                        t = (From x In conexion.tblTipoMovimientoes Where x.idTipoMovimiento = d.tipoMovimiento Select x).FirstOrDefault

                        If t.aumentaInventario = True Then

                            i = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                            i.saldo += d.cantidad

                            conexion.SaveChanges()

                        ElseIf t.disminuyeInventario Then

                            i = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                            i.salida += d.cantidad

                            conexion.SaveChanges()
                        End If
                    ElseIf m.traslado Then

                        i = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.IdAlmacen = m.almacen And x.idTipoInventario = m.inventarioInicial Select x).FirstOrDefault
                        i2 = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.IdAlmacen = m.almacenFinal And x.idTipoInventario = m.inventarioFinal Select x).FirstOrDefault

                        ''i.saldo -= d.cantidad * d.valormedida
                        i.salida += d.cantidad * d.valormedida
                        conexion.SaveChanges()

                        i2.saldo += d.cantidad * d.valormedida
                        i2.entrada += d.cantidad * d.valormedida
                        conexion.SaveChanges()

                    End If

                ElseIf m.bitBodega = True Then

                    t = (From x In conexion.tblTipoMovimientoes Where x.idTipoMovimiento = d.tipoMovimiento Select x).FirstOrDefault

                    i = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.IdAlmacen = m.almacen And x.idTipoInventario = m.inventarioInicial Select x).FirstOrDefault
                    i2 = (From x In conexion.tblInventarios Where x.idArticulo = d.articulo And x.IdAlmacen = m.almacenFinal And x.idTipoInventario = m.inventarioFinal Select x).FirstOrDefault

                    If m.ajuste = True Then
                        If t.aumentaInventario = True Then
                            i.saldo += d.cantidad * d.valormedida
                            i.entrada += d.cantidad * d.valormedida
                            conexion.SaveChanges()
                        ElseIf t.disminuyeInventario = True Then
                            i.saldo -= d.cantidad * d.valormedida
                            i.salida += d.cantidad * d.valormedida
                            conexion.SaveChanges()
                        End If
                    ElseIf m.traslado = True Then
                        i.saldo -= d.cantidad * d.valormedida
                        i.salida += d.cantidad * d.valormedida
                        conexion.SaveChanges()

                        i2.saldo += d.cantidad * d.valormedida
                        i2.entrada += d.cantidad * d.valormedida
                        conexion.SaveChanges()
                    End If

                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnAcreditarDevolucionCliente()
        Dim codigo As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Codigo").Value, Integer)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
        Dim tipoMovimiento As String = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Movimiento").Value, String)

        Dim success As Boolean = True

        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                Dim negativo As Double = 0
                'Obtenemos el encabezado de la devolucion de cliente
                Dim devolucion As tblDevolucionCliente = (From x In ctx.tblDevolucionClientes Where x.codigo = codigo Select x).FirstOrDefault
                Dim fechaAcreditado As DateTime = fnFecha_horaServidor()

                'Acreditamos la devolucion de cliente
                devolucion.acreditado = True
                devolucion.acreditadoFecha = fechaAcreditado
                ctx.SaveChanges()

                'Obtenemos la lista de los detalles de la devolucion
                Dim listaDetalles As List(Of tblDevolucionClienteDetalle) = (From x In ctx.tblDevolucionClienteDetalles Where x.devolucion = codigo Select x).ToList
                Dim detalle As tblDevolucionClienteDetalle

                For Each detalle In listaDetalles
                    Dim articulo As Integer = CType(detalle.articulo, Integer)
                    Dim cantidad As Integer = CType(detalle.cantidadAceptada, Integer)
                    Dim idTipoInventario As Integer

                    Dim inventario As tblInventario
                    If detalle.solucion = True Then
                        idTipoInventario = CType(detalle.tipoInventario, Integer)
                        'Si se soluciona la devoulucion, entonces...
                        'Seleccionamos el articulo filtrando por el inventario
                        inventario = (From x In ctx.tblInventarios Where x.idArticulo = articulo And x.idTipoInventario = idTipoInventario And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                       Select x).FirstOrDefault
                        'Aumentamos la cantidad que se le debitara al saldo del cliente
                        negativo += detalle.total

                    Else
                        'Si no se soluciono la devolucion, entonces
                        'Seleccionamos el registro del inventario devolucion cliente del articulo
                        inventario = (From x In ctx.tblInventarios Where x.idArticulo = articulo And _
                                      x.idTipoInventario = mdlPublicVars.Cliente_InventarioDevolucion And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                      Select x).FirstOrDefault

                    End If

                    If inventario Is Nothing Then
                        'Si el registro en inventario no existiera se crea el registro de inventario
                        Dim nuevoInventario As New tblInventario
                        nuevoInventario.idArticulo = articulo
                        nuevoInventario.saldo = cantidad
                        nuevoInventario.entrada = cantidad
                        nuevoInventario.salida = 0
                        nuevoInventario.reserva = 0
                        nuevoInventario.transito = 0
                        If detalle.solucion = True Then
                            nuevoInventario.idTipoInventario = idTipoInventario
                        Else
                            nuevoInventario.idTipoInventario = mdlPublicVars.Cliente_InventarioDevolucion
                        End If

                        nuevoInventario.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                        ctx.AddTotblInventarios(nuevoInventario)
                        ctx.SaveChanges()
                    Else
                        inventario.saldo += cantidad
                        inventario.entrada += cantidad
                        ctx.SaveChanges()
                    End If

                Next
                'Modificamos el saldo del cliente
                Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = devolucion.cliente Select x).FirstOrDefault
                If cliente.devoluciones Is Nothing Then
                    cliente.devoluciones = negativo
                    cliente.saldo -= negativo
                Else
                    cliente.devoluciones += negativo
                    cliente.saldo -= negativo
                End If
                ctx.SaveChanges()

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
            ctx.AcceptAllChanges()
            alertas.contenido = tipoMovimiento + " acreditado exitosamente!!!"
            alertas.fnErrorContenido()

        Else
            If anulado = True Then
                alertas.contenido = tipoMovimiento + " ya ha sido anulado!!!"
                alertas.fnErrorContenido()
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If
        End If
        Dim fila As Integer = CType(Me.grdDatos.CurrentRow.Index, Integer)
        llenagrid()
        Me.grdDatos.Rows(fila).IsCurrent = True

    End Sub

    Private Sub fnAnularMovimiento()
        Dim id As Integer = mdlPublicVars.superSearchId
        Dim tipo As String = mdlPublicVars.superSearchNombre
        Dim acreditado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value, Boolean)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
        Dim fechaAnulado As DateTime = fnFecha_horaServidor()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            If acreditado = True Then
                alertas.contenido = "El " & tipo & " ya ha sido acreditado"
                alertas.fnErrorContenido()
            ElseIf anulado = True Then
                alertas.contenido = "El " & tipo & " ya ha sido anulado"
                alertas.fnErrorContenido()
            Else
                If tipo = "Ajuste en Venta" Then
                        Dim m As tblMovimientoInventario = (From x In conexion.tblMovimientoInventarios Where x.codigo = id Select x).FirstOrDefault
                    If m.ajuste Then
                            Dim md As List(Of tblMovimientoInventarioDetalle) = (From x In conexion.tblMovimientoInventarioDetalles Where x.movimientoInventario = id Select x).ToList()

                            Dim i As tblInventario

                            For Each d As tblMovimientoInventarioDetalle In md
                                i = (From x In conexion.tblInventarios Where x.idTipoInventario = m.inventarioInicial And x.idArticulo = d.articulo Select x).FirstOrDefault

                                i.saldo += d.cantidad * d.valormedida
                                conexion.SaveChanges()
                            Next
                    ElseIf m.traslado Then
                            Dim md As List(Of tblMovimientoInventarioDetalle) = (From x In conexion.tblMovimientoInventarioDetalles Where x.movimientoInventario = id Select x).ToList()

                            Dim i As tblInventario

                            For Each d As tblMovimientoInventarioDetalle In md
                                i = (From x In conexion.tblInventarios Where x.idTipoInventario = m.inventarioInicial And x.idArticulo = d.articulo Select x).FirstOrDefault

                                i.saldo += d.cantidad * d.valormedida
                                conexion.SaveChanges()
                            Next
                    End If
                        m.anulado = True
                        m.anuladoFecha = fechaAnulado
                        conexion.SaveChanges()
                ElseIf tipo = "Ajuste en Bodega" Or tipo = "Traslado entre bodegas" Then
                    'Seleccionamos el movimiento de inventario a anular
                        Dim movimiento As tblMovimientoInventario = (From x In conexion.tblMovimientoInventarios Where x.codigo = id Select x).FirstOrDefault
                    movimiento.anulado = True
                    movimiento.anuladoFecha = fechaAnulado
                        conexion.SaveChanges()
                ElseIf tipo = "Devolucion Cliente" Then
                    'Seleccionamos la devolucion del cliente
                        Dim devolucion As tblDevolucionCliente = (From x In conexion.tblDevolucionClientes Where x.codigo = id Select x).FirstOrDefault
                    devolucion.anulado = True
                    devolucion.anuladoFecha = fechaAnulado
                        conexion.SaveChanges()
                End If
            End If
            Dim fila As Integer = CType(Me.grdDatos.CurrentRow.Index, Integer)
            llenagrid()
                Me.grdDatos.Rows(fila).IsCurrent = True
                conn.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMovimientoInventariosLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Movimientos de Inventario"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub cmbVendedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedValueChanged
        Try
            llenagrid()
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub
End Class
