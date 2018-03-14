''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports Telerik.WinControls.Data

Public Class frmDevolucionTransporte


#Region "Variables"
    Public _idenvio As Integer
    Private _listaAgregar As List(Of GridViewRowInfo)
    Public _DevListado As Boolean
#End Region

#Region "Propiedades"
    Public Property idenvio As Integer
        Get
            idenvio = _idenvio
        End Get
        Set(value As Integer)
            _idenvio = value
        End Set
    End Property

    Public Property DevListado As Boolean
        Get
            DevListado = _DevListado
        End Get
        Set(value As Boolean)
            _DevListado = value
        End Set
    End Property
#End Region

#Region "Funciones"
    Private Sub frmDevolucionTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientosAgrupado(Me.grdClientesProductos, True, True)
        ''mdlPublicVars.fnFormatoGridEspeciales(Me.grdClientesProductos)

        Me.cmbInventario.Enabled = False

        fnCorrelativo()
        fnLlenarCombos()
        fnLlenarComboEnvios()
        fnLlenarComboPedidos()

        If DevListado = True Then
            fnllenarInformacion(cmbEnvioTransporte.SelectedValue)
            fnLlenarGrid(cmbPedidoCliente.SelectedValue, cmbEnvioTransporte.SelectedValue)
        Else
            fnllenarInformacion(idenvio)
            fnLlenarGrid(cmbPedidoCliente.SelectedValue, cmbEnvioTransporte.SelectedValue)
        End If

        mdlPublicVars.fnGrid_iconos(Me.grdClientesProductos)

        If DevListado = False Then
            Me.cmbEnvioTransporte.Enabled = False
        End If

    End Sub

    Private Sub fnCorrelativo()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim correlativode As Integer

                Dim correlativod As Object = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Devolucion_Transporte Select x.correlativo).FirstOrDefault

                If CInt(correlativod) >= 0 Then
                    correlativode = CInt(correlativod) + 1
                End If

                Me.txtCodigo.Text = CStr(correlativode)

                conn.Close()
            End Using
        Catch
        End Try

    End Sub

    Private Sub fnLlenarComboPedidos()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''select st.idsalida from tblsalidastransportesmedios stm
                ''inner join tblsalidastransportesmediosdetalles stmd on stm.idsalidatransportemedio=stmd.idsalidatransportemedio
                ''inner join tblsalidastransportes st on stmd.idsalidatransporte=st.idsalidatransporte
                ''where stm.idsalidatransportemedio=3
                ''group by st.idsalida

                Dim enviotran As Integer = 0
                enviotran = Me.cmbEnvioTransporte.SelectedValue

                Dim envios = (From stm In conexion.tblSalidasTransportesMedios, stmd In conexion.tblSalidasTransportesMediosDetalles, st In conexion.tblSalidasTransportes, s In conexion.tblSalidas, c In conexion.tblClientes
                              Where stm.idSalidaTransporteMedio = stmd.idSalidaTransporteMedio And stmd.idSalidaTransporte = st.idSalidaTransporte And st.idSalida = s.idSalida And s.idCliente = c.idCliente And stm.idSalidaTransporteMedio = enviotran
                              Group By Codigo = st.idSalidaTransporte, Nombre = c.Nombre1 Into Group
                              Select Codigo, Nombre)

                Dim dt As New DataTable
                dt.Columns.Add("Codigo")
                dt.Columns.Add("Nombre")

                Dim x
                For Each x In envios
                    dt.Rows.Add(x.codigo, x.nombre)
                Next

                With cmbPedidoCliente
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = dt
                End With

                conn.Close()
            End Using


        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarComboEnvios()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim fac = (From s In conexion.tblSalidasTransportesMedios Where s.salida = True
                Group By Codigo = s.idSalidaTransporteMedio, Vehiculo = s.tblTransporte.descripcion, Placas = s.tblTransporte.placas, Piloto = s.tblEmpleado.nombre, Sucursal = s.tblSucursale.descripcion, Viaje = s.NumeroViaje Into Group
                Order By Codigo Descending
                Select Codigo, Vehiculo, Placas, Piloto, Sucursal, Viaje)

            Dim dt As New DataTable
            dt.Columns.Add("Codigo")
            dt.Columns.Add("Nombre")

            Dim x
            For Each x In fac
                dt.Rows.Add(x.codigo, ("Vehiculo: " & x.Vehiculo & "(" & x.Placas & "); Piloto: " & x.Piloto & "; Sucursal: " & x.Sucursal & "; Viaje:" & x.Viaje))
            Next

            With cmbEnvioTransporte
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = dt
            End With

            If idenvio > 0 Then
                cmbEnvioTransporte.SelectedValue = idenvio
            End If



            conn.Close()
        End Using
        
    End Sub

    Private Sub fnLlenarCombos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Cargamos el inventario default

                Dim inve As Object = (From x In conexion.tblTipoInventarios Where x.idTipoinventario = mdlPublicVars.General_idTipoInventario Select Id = x.idTipoinventario, Nombre = x.nombre)

                With cmbInventario
                    .DataSource = Nothing
                    .ValueMember = "Id"
                    .DisplayMember = "Nombre"
                    .DataSource = inve
                End With

                conn.Close()
            End Using
        Catch
        End Try

    End Sub

    Private Sub fnllenarInformacion(envio As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim sucursal As Object = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = envio Select x.tblSucursale.direccion).FirstOrDefault

                Dim viaje As Object = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = envio Select x.NumeroViaje).FirstOrDefault

                Dim observacionenvio As Object = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = envio Select x.observacion).FirstOrDefault

                Me.lblSucursal.Text = CStr(sucursal)
                Me.lblNumeroViaje.Text = CStr(CInt(viaje))
                ''Me.txtObservacion.Text = CStr(observacionenvio)

                conn.Close()
            End Using
        Catch
        End Try

    End Sub

    Private Sub fnLlenarGrid(ByVal envio As Integer, ByVal pedido As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_ListaEnvioTransportePedido(envio, pedido) Select x)

                Me.grdClientesProductos.DataSource = datos

                conn.Close()
            End Using

            If Me.grdClientesProductos.Rows.Count > 0 Then
                ''Tamanios
                Me.grdClientesProductos.Columns(0).Width = 50   ''CodigoCliente
                Me.grdClientesProductos.Columns(1).Width = 150  ''Cliente
                Me.grdClientesProductos.Columns(2).Width = 75   ''Nit   
                Me.grdClientesProductos.Columns(3).Width = 50   ''IdArticulo
                Me.grdClientesProductos.Columns(4).Width = 75   ''Codigo Articulo
                Me.grdClientesProductos.Columns(5).Width = 150  ''Articulo
                Me.grdClientesProductos.Columns(6).Width = 75   ''Cantidad Enviada
                Me.grdClientesProductos.Columns(7).Width = 75   ''Cantidad Recibida
                Me.grdClientesProductos.Columns(8).Width = 25   ''idDestino
                Me.grdClientesProductos.Columns(9).Width = 100  ''Destino
                Me.grdClientesProductos.Columns(10).Width = 25   ''idResponsable
                Me.grdClientesProductos.Columns(11).Width = 100 ''Responsable
                Me.grdClientesProductos.Columns(12).Width = 75   ''Precio
                Me.grdClientesProductos.Columns(13).Width = 75   ''Total
                Me.grdClientesProductos.Columns(14).Width = 100  ''Observacion

                ''Visibles
                Me.grdClientesProductos.Columns(0).IsVisible = False
                Me.grdClientesProductos.Columns(1).IsVisible = False
                Me.grdClientesProductos.Columns(2).IsVisible = False
                Me.grdClientesProductos.Columns(3).IsVisible = False
                Me.grdClientesProductos.Columns(8).IsVisible = False
                Me.grdClientesProductos.Columns(10).IsVisible = False

                ''Editables
                Me.grdClientesProductos.Columns(0).ReadOnly = True
                Me.grdClientesProductos.Columns(1).ReadOnly = True
                Me.grdClientesProductos.Columns(2).ReadOnly = True
                Me.grdClientesProductos.Columns(3).ReadOnly = True
                Me.grdClientesProductos.Columns(4).ReadOnly = True
                Me.grdClientesProductos.Columns(5).ReadOnly = True
                Me.grdClientesProductos.Columns(6).ReadOnly = True
                Me.grdClientesProductos.Columns(7).ReadOnly = False
                Me.grdClientesProductos.Columns(8).ReadOnly = True
                Me.grdClientesProductos.Columns(9).ReadOnly = True
                Me.grdClientesProductos.Columns(10).ReadOnly = True
                Me.grdClientesProductos.Columns(11).ReadOnly = True
                Me.grdClientesProductos.Columns(12).ReadOnly = True
                Me.grdClientesProductos.Columns(13).ReadOnly = True
                Me.grdClientesProductos.Columns(14).ReadOnly = False

            End If


            '' ''Agrupar por Codigo Cliente
            ''Me.grdClientesProductos.MasterTemplate.AutoExpandGroups = True
            ''Me.grdClientesProductos.GroupDescriptors.Clear()

            ''Dim gbCliente As New GroupDescriptor
            ''gbCliente.GroupNames.Add("Cliente", System.ComponentModel.ListSortDirection.Ascending)
            ''Me.grdClientesProductos.GroupDescriptors.Add(gbCliente)

        Catch

        End Try

    End Sub

    Private Sub fnActualizarTotal()
        Try

            Dim total As Decimal = 0

            For Index As Integer = 0 To Me.grdClientesProductos.Rows.Count - 1

                Me.grdClientesProductos.Rows(Index).Cells("Total").Value = CDec(CDec(Me.grdClientesProductos.Rows(Index).Cells("Precio").Value) * CDec(Me.grdClientesProductos.Rows(Index).Cells("txmCantidadRecibida").Value))

                Dim valor As Decimal = 0

                valor = CDec(Me.grdClientesProductos.Rows(Index).Cells("Total").Value)

                total += valor
            Next

            Me.dspTotal.DigitText = CStr(total)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnGuardar()
        If RadMessageBox.Show("Esta Seguro de Guardar la Devolucion", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardar_Devolucion()
        End If
    End Sub

    Private Function fnVerificacionDevolucion()

        Dim filas As Integer = Me.grdClientesProductos.Rows.Count - 1

        For Index As Integer = 0 To filas
            Dim cantidad As Double

            cantidad = Me.grdClientesProductos.Rows(Index).Cells("txmCantidadRecibida").Value

            If cantidad > 0 Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function

    Private Sub fnGuardar_Devolucion()

        Dim errores As Boolean = False

        errores = fnVerificacionDevolucion()

        If errores = False Then
            RadMessageBox.Show("Debe devolver al menos un producto", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        End If

        Try
            Dim iddevolucion As Integer
            Dim fecha As DateTime = mdlPublicVars.fnFechaServidor
            Dim hora As String = mdlPublicVars.fnHoraServidor()

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Encabezado de la Devolucion
                Dim devol As New tblDevolucionTransporte

                devol.fechaRegistro = CType(dtpFechaRegistro.Text & " " & hora, DateTime)
                devol.vendedor = mdlPublicVars.idVendedor
                devol.anulado = False
                devol.anuladoFecha = Nothing
                devol.montoTotal = CDec(dspTotal.DigitText)
                devol.correlativo = CInt(txtCodigo.Text)
                devol.idSalidaTransporte = cmbPedidoCliente.SelectedValue
                devol.idSalidaTransporteMedio = cmbEnvioTransporte.SelectedValue
                devol.Observacion = txtObservacion.Text
                devol.tipoMovimiento = mdlPublicVars.Devolucion_Transporte
                devol.Confirmado = 0

                conexion.AddTotblDevolucionTransportes(devol)
                conexion.SaveChanges()
                iddevolucion = devol.idDevolucionTransporte


                ''Detalle de la Devolucion de Transporte

                For Index As Integer = 0 To Me.grdClientesProductos.Rows.Count - 1

                    Dim idarticulo As Integer = 0
                    Dim cantidad As Double = 0
                    Dim Precio As Decimal = 0
                    Dim total As Decimal = 0
                    Dim observacion As String = ""
                    Dim cliente As Integer = 0
                    Dim inventario As Integer = 0

                    idarticulo = Me.grdClientesProductos.Rows(Index).Cells("IdArticulo").Value
                    cantidad = Me.grdClientesProductos.Rows(Index).Cells("txmCantidadRecibida").Value
                    precio = Me.grdClientesProductos.Rows(Index).Cells("Precio").Value
                    total = Me.grdClientesProductos.Rows(Index).Cells("Total").Value
                    observacion = Me.grdClientesProductos.Rows(Index).Cells("txmObservacion").Value
                    cliente = Me.grdClientesProductos.Rows(Index).Cells("CodigoCliente").Value
                    inventario = Me.grdClientesProductos.Rows(Index).Cells("idtipoInventario").Value

                    Dim detalle As New tblDevolucionTransporteDetalle

                    If cantidad > 0 Then
                        detalle.idDevolucionTransporte = iddevolucion
                        detalle.idCliente = cliente
                        detalle.idArticulo = idarticulo
                        detalle.cantidadRecibida = cantidad
                        detalle.cantidadAceptada = cantidad
                        detalle.precio = Precio
                        detalle.total = total
                        detalle.observacion = observacion
                        detalle.inventario = inventario

                        conexion.AddTotblDevolucionTransporteDetalles(detalle)
                        conexion.SaveChanges()
                    End If

                Next

                conn.Close()
            End Using

        Catch ex As Exception
            errores = False
        End Try

        If errores = True Then
            alerta.fnGuardar()
            frmDespachoFacturaBarraDerecha.creadevolucion = True
            If DevListado = True Then
                fnNuevo()
            Else
                If RadMessageBox.Show("Desea crear otra devolucion", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Forms.DialogResult.Yes Then
                    fnLlenarGrid(Me.cmbPedidoCliente.SelectedValue, cmbEnvioTransporte.SelectedValue)
                Else
                    Me.Close()
                    frmDespachoFacturaBarraDerecha.creadevolucion = True
                End If


            End If

        End If

    End Sub

    Private Sub fnNuevo()
        fnLlenarCombos()
        fnLlenarComboEnvios()
        fnLlenarGrid(cmbEnvioTransporte.SelectedValue, cmbEnvioTransporte.SelectedValue)
        fnCorrelativo()
        cmbEnvioTransporte.Enabled = True
    End Sub

    Private Sub fnNuevo_Click() Handles Me.panel0
        fnNuevo()
    End Sub

    Private Sub fnGuardar_Click() Handles Me.panel1
        fnGuardar()
    End Sub

    Private Sub fnSalida_Click() Handles Me.panel2
        Me.Close()
    End Sub

#End Region

#Region "Eventos"

    Private Sub cmbEnvioTransporte_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEnvioTransporte.SelectedValueChanged
        Try

            Dim codigoenvio As Integer

            codigoenvio = cmbEnvioTransporte.SelectedValue

            fnllenarInformacion(codigoenvio)
            fnLlenarGrid(codigoenvio, cmbEnvioTransporte.SelectedValue)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdClientesProductos_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles grdClientesProductos.CellEndEdit

        If Me.grdClientesProductos.CurrentColumn.Name = "txmCantidadRecibida" Then

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdClientesProductos)

            Dim enviado As Double = 0
            Dim recibido As Double = 0

            enviado = CDec(Me.grdClientesProductos.Rows(fila).Cells("CantidadEnviada").Value)
            recibido = CDec(Me.grdClientesProductos.Rows(fila).Cells("txmCantidadRecibida").Value)

            If recibido > enviado Then
                RadMessageBox.Show("La cantidad Devuelta es mayor a la cantidad enviada", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Me.grdClientesProductos.Rows(fila).Cells("txmCantidadRecibida").Value = 0

                Exit Sub
            End If

            fnActualizarTotal()

        End If

    End Sub

#End Region

    Private Sub grdClientesProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdClientesProductos.KeyDown

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdClientesProductos)
        If Me.grdClientesProductos.CurrentColumn.Name = "txbDestino" Then
            If e.KeyCode = Keys.F2 Then

                fnDestino()

            End If
        ElseIf Me.grdClientesProductos.CurrentColumn.Name = "txbResponsable" Then
            If e.KeyCode = Keys.F2 Then

                fnResponsable()

            End If
        End If
    End Sub

    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub

    'DESTINO
    Private Sub fnDestino()

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdClientesProductos)

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

            Dim cantidad As Double = CType(Me.grdClientesProductos.Rows(fila).Cells("txmCantidadRecibida").Value, Double)

            If mdlPublicVars.superSearchId > 0 And Me.grdClientesProductos.Rows.Count > 0 And cantidad > 0 Then

                Me.grdClientesProductos.Rows(fila).Cells("idTipoInventario").Value = mdlPublicVars.superSearchId
                Me.grdClientesProductos.Rows(fila).Cells("txbDestino").Value = mdlPublicVars.superSearchNombre

            ElseIf cantidad <= 0 Then
                RadMessageBox.Show("Primero debe indicar la cantidad a devolver!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

        End If
    End Sub

    Private Sub fnResponsable()

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdClientesProductos)

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

            Dim cantidad As Double = CType(Me.grdClientesProductos.Rows(fila).Cells("txmCantidadRecibida").Value, Double)

            If mdlPublicVars.superSearchId > 0 And Me.grdClientesProductos.Rows.Count > 0 And cantidad > 0 Then

                Me.grdClientesProductos.Rows(fila).Cells("idVendedor").Value = mdlPublicVars.superSearchId
                Me.grdClientesProductos.Rows(fila).Cells("txbResponsable").Value = mdlPublicVars.superSearchNombre

            End If
        End If
    End Sub

    Private Sub cmbPedidoCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPedidoCliente.SelectedValueChanged
        fnLlenarGrid(Me.cmbPedidoCliente.SelectedValue, cmbEnvioTransporte.SelectedValue)
    End Sub
End Class
