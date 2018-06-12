''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Transactions

Public Class frmListaDevoluciontesTransporte

    Dim b As New clsBase

#Region "Variables"

#End Region

#Region "Propiedades"

#End Region

#Region "Eventos"

    Private Sub frmListaDevoluciontesTransporte_Load(sender As Object, e As EventArgs) Handles Me.Load
        fnLLenarLista()
    End Sub

#End Region

#Region "Funciones"

    Private Sub fnLlenarLista()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_ListadoDevolucionesTransporte(mdlPublicVars.idEmpresa) Select x)

                Me.grdDatos.DataSource = datos

                conn.Close()
            End Using

            fnConfiguracion()
        Catch
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try

            If Me.grdDatos.ColumnCount > 0 Then
                Me.grdDatos.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None
                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next
                ''Tamanio de Columnas
                Me.grdDatos.Columns("Codigo").Width = 125
                Me.grdDatos.Columns("Fecha").Width = 125
                Me.grdDatos.Columns("Cliente").Width = 200
                Me.grdDatos.Columns("Vendedor").Width = 180
                Me.grdDatos.Columns("Piloto").Width = 180
                Me.grdDatos.Columns("Transporte").Width = 180
                Me.grdDatos.Columns("Productos").Width = 300
                Me.grdDatos.Columns("Correlativo").Width = 125
                Me.grdDatos.Columns("SucursalEncargada").Width = 250
                Me.grdDatos.Columns("Total").Width = 100
                Me.grdDatos.Columns("Observacion").Width = 200
                Me.grdDatos.Columns("chmAnulado").Width = 110
                Me.grdDatos.Columns("chmConfirmado").Width = 110

                ''Visibles
                Me.grdDatos.Columns("Codigo").IsVisible = False
            End If
        Catch
        End Try


    End Sub


    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

                If (Me.grdDatos.CurrentColumn.Name = "chmAnulado") Then
                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmAnulado").Value
                    ''Dim descripcion As String = Me.grdDatos.Rows(fila).Cells("EstadoSalida").Value
                    Dim iddevolucion As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                    If valor = False Then
                        If RadMessageBox.Show("Desea anular la devolucion", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            Dim conexion As dsi_pos_demoEntities
                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                Dim devtransporte As tblDevolucionTransporte = (From x In conexion.tblDevolucionTransportes Where x.idDevolucionTransporte = iddevolucion Select x).FirstOrDefault

                                devtransporte.anulado = True
                                devtransporte.anuladoFecha = fnFechaServidor()

                                conexion.SaveChanges()
                                conn.Close()
                            End Using
                            fnLlenarLista()
                        Else
                            fnLlenarLista()
                        End If
                    Else
                        RadMessageBox.Show("La devolucion ya ha sido anulada", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        fnLlenarLista()
                        Exit Try
                    End If

                ElseIf (Me.grdDatos.CurrentColumn.Name = "chmConfirmado") Then
                    If (Me.grdDatos.Rows(fila).Cells("chmAnulado").Value = False) Then
                        Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmConfirmado").Value
                        ''Dim descripcion As String = Me.grdDatos.Rows(fila).Cells("EstadoEntrada").Value
                        Dim iddevolucion As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value
                        ''Dim totalkms As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalKms").Value
                        ''Dim costocombustible As Decimal = Me.grdDatos.Rows(fila).Cells("txmCostoCombustible").Value
                        ''Dim totalcombustible As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalCombustible").Value
                        ''Dim totalplanilla As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalPlanilla").Value
                        ''Dim costo As Decimal = Me.grdDatos.Rows(fila).Cells("txmCosto").Value
                        ''Dim totalcobro As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalCobro").Value

                        If valor = False Then
                            If RadMessageBox.Show("Desea confirmar la devolucion", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Dim conexion As dsi_pos_demoEntities
                                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                    conn.Open()
                                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                    Dim salidas = (From dt In conexion.tblDevolucionTransportes, dtd In conexion.tblDevolucionTransporteDetalles, st In conexion.tblSalidasTransportes
                                                   Where dt.idDevolucionTransporte = dtd.idDevolucionTransporte And dt.idSalidaTransporte = st.idSalidaTransporte And dt.idDevolucionTransporte = iddevolucion Select st.idSalida).FirstOrDefault

                                    Dim sali As Integer = 0
                                    sali = CInt(salidas)

                                    Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = sali Select x).FirstOrDefault

                                    lblCliente.Text = sal.cliente

                                    conn.Close()
                                End Using
                                fnLlenarLista()
                            Else
                                fnLlenarLista()
                            End If
                        Else
                            RadMessageBox.Show("La devolucion ya ha sido confirmada", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            fnLlenarLista()
                            Exit Try
                        End If

                    End If
                End If

            End If
        Catch

        End Try
        Return False
    End Function


    Private Sub fnGuardarDevolucion()

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

        Dim success As Boolean = True
        Dim idCliente As Integer = Me.grdDatos.Rows(fila).Cells("CodigoCliente").Value
        Dim idVendedor As Integer = mdlPublicVars.idVendedor
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim hora As String = mdlPublicVars.fnHoraServidor

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
                    devolucion.fechaRegistro = fechaServidor
                    devolucion.fechaTransaccion = fechaServidor
                    devolucion.acreditado = False
                    devolucion.anulado = False
                    devolucion.monto = Me.grdDatos.Rows(fila).Cells("Total").Value
                    devolucion.tipoMovimiento = mdlPublicVars.Cliente_DevolucionCodigoMovimiento
                    'Decidimos si fueron varias facturas o solo una, si fue sobre una factura tambien guardamos el id de la factura
                    ''If rbnPorFactura.Checked = True Then
                    devolucion.bitFactura = 1
                    ''devolucion.factura = CType(cmbFactura.SelectedValue, Integer)
                    devolucion.bitFacturaVarios = 0
                    ''devolucion.documentoAfectado = cmbFactura.Text
                    ''Else
                    ''    devolucion.documentoAfectado = ""
                    ''    devolucion.bitFacturaVarios = 1
                    ''    devolucion.bitFactura = 0
                    ''End If
                    devolucion.observacion = Me.grdDatos.Rows(fila).Cells("Observacion").Value
                    ''devolucion.caso = lblCaso.Text

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
                    ''cliente.casos = lblCaso.Text
                    conexion.SaveChanges()

                    'Guardamos el detalle de la devolucion
                    '-------------DETALLE DEVOLUCION---------------
                    Dim index As Integer = 0
                    Dim nombre As String = ""
                    Dim cantidadRecibida As Integer = 0

                    Dim fechaUltCompra As String

                    Dim solucion As Boolean = False


                    'For index = 0 To Me.grdProductos.Rows.Count - 1
                    '    Dim articulo As Integer = CType(Me.grdProductos.Rows(index).Cells("Id").Value, Integer)
                    '    Dim cantidad As Integer = CType(Me.grdProductos.Rows(index).Cells("txmcantidad").Value, Integer)
                    '    cantidadRecibida = CType(Me.grdProductos.Rows(index).Cells("cantidadVendida").Value, Integer)
                    '    Dim costo As Double = CType(Me.grdProductos.Rows(index).Cells("txmPrecio").Value, Double)
                    '    Dim total As Double = CType(Me.grdProductos.Rows(index).Cells("Total").Value, Double)
                    '    Dim tipoInventario As Integer = CType(Me.grdProductos.Rows(index).Cells("IdTipoInventario").Value, Integer)

                    '    fechaUltCompra = CType(LTrim(RTrim(Me.grdProductos.Rows(index).Cells("fechaUltCompra").Value)), String)


                    '    nombre = CType(Me.grdProductos.Rows(index).Cells("txbProducto").Value, String)

                    '    If nombre IsNot Nothing Then
                    '        Dim vendedor As Integer = 0
                    '        If Me.grdProductos.Rows(index).Cells("idVendedor").Value.ToString.Length = 0 Then
                    '            vendedor = 0
                    '        Else
                    '            vendedor = CType(grdProductos.Rows(index).Cells("idVendedor").Value, Integer)
                    '        End If

                    '        Dim observacion = Me.grdProductos.Rows(index).Cells("txmObservacion").Value

                    '        'Obtenemos el tipo de inventario y en base a eso el tipo de inventario
                    '        Dim tipoIn As tblTipoInventario = (From x In conexion.tblTipoInventarios.AsEnumerable Where x.idTipoinventario = tipoInventario
                    '                                          Select x).FirstOrDefault

                    '        If tipoIn IsNot Nothing Then
                    '            If tipoIn.bitEstadoCuenta Then
                    '                solucion = True
                    '            Else
                    '                solucion = False
                    '            End If
                    '        Else
                    '            solucion = False
                    '        End If

                    '        'Creamos el nuevo detalle
                    '        Dim detalle As New tblDevolucionClienteDetalle
                    '        detalle.devolucion = idDevolucion
                    '        detalle.articulo = articulo
                    '        detalle.cantidadRecibida = cantidadRecibida
                    '        detalle.cantidadAceptada = cantidad
                    '        detalle.costo = costo
                    '        detalle.total = total
                    '        detalle.solucion = solucion

                    '        If Not rbnPorFactura.Checked Then

                    '            If fechaUltCompra = "" Then
                    '                detalle.fechaVenta = Nothing
                    '            Else
                    '                detalle.fechaVenta = fechaUltCompra
                    '            End If

                    '        End If

                    '        If cantidad > 0 Then
                    '            detalle.tipoInventario = tipoInventario
                    '            detalle.vendedor = vendedor
                    '        End If

                    '        detalle.observacion = observacion
                    '        conexion.AddTotblDevolucionClienteDetalles(detalle)
                    '        conexion.SaveChanges()
                    '    End If
                    'Next

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
                        ''alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using


            ''If success = True Then
            ''    conexion.AcceptAllChanges()
            ''    alerta.contenido = "Registro guardado correctamente"
            ''    alerta.fnGuardar()
            ''Else
            ''    alerta.fnErrorGuardar()
            ''    Console.WriteLine("La operacion no pudo ser completada")
            ''End If

            conn.Close()
        End Using

        ''If success = True Then
        ''    fnNuevo()
        ''End If

    End Sub

#End Region

End Class
