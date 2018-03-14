''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Transactions
Imports Telerik.WinControls.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net.Mail
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmListaDevolucionesTransporte

    Dim b As New clsBase

#Region "Variables"

#End Region

#Region "Propiedades"

#End Region

#Region "Eventos"

    Private Sub frmListaDevoluciontesTransporte_Load(sender As Object, e As EventArgs) Handles Me.Load
        fnLlenarLista()
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
                Me.grdDatos.Columns("CodigoCliente").IsVisible = False
            End If
        Catch
        End Try


    End Sub


    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        Try

            Dim codigodev As Integer = 0

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
                                devtransporte.anuladoFecha = CDate(fnFecha_horaServidor())

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

                                    Dim iddevoluciontrans As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                                    Dim devtransporte As tblDevolucionTransporte = (From x In conexion.tblDevolucionTransportes Where x.idDevolucionTransporte = iddevoluciontrans Select x).FirstOrDefault

                                    devtransporte.Confirmado = True
                                    conexion.SaveChanges()

                                    codigodev = fnGuardarDevolucion(Me.grdDatos.Rows(fila).Cells("Codigo").Value)

                                    fnReasignarInventario(Me.grdDatos.Rows(fila).Cells("Codigo").Value)

                                    If RadMessageBox.Show("Desea Acreditar el Efectivo al Cliente", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Forms.DialogResult.Yes Then

                                        Dim total = (From x In conexion.tblDevolucionTransportes Where x.idDevolucionTransporte = iddevolucion Select x.montoTotal).FirstOrDefault

                                        fnGuardarPago(CInt(total), Me.grdDatos.Rows(fila).Cells("CodigoCliente").Value, sali)

                                    End If

                                    ''Enviar la Devolucion por Correo

                                    Dim devcliente As tblDevolucionCliente = (From x In conexion.tblDevolucionClientes Where x.codigo = codigodev Select x).FirstOrDefault

                                    fnEnviarDevolucionCorreo(devcliente.cliente, codigodev)

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

    Private Sub fnEnviarDevolucionCorreo(ByVal cliente As Integer, ByVal devolucion As Integer)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim tablaParametros As New DataTable

        Dim reporteBase As ReportDocument

        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim archivo As String = ""
        Dim msj As String = ""

        ''Variables
        Dim x As New tblImpresion
        Dim r As New clsReporte
        Dim listacorreos As New Hashtable
        Dim tabladatos As New DataTable
        Dim dsr As New dsReporte

        r.tabla = EntitiToDataTable(ctx.sp_ReporteDevolucionClientePequenio("", devolucion))
        r.reporte = "rptDevolucionCientePequenio.rpt"
        reporteBase = r.DocumentoReporte()

        Try
            ''Guardar registro en el sistema
            x.bitImpreso = True
            x.tipoImpresion = 5
            x.usuarioRegistro = mdlPublicVars.idUsuario
            x.fechaImpresion = fechaServidor
            x.cliente = cliente
            x.descripcion = "Devolucion de Productos"
            x.url = archivo

            ctx.AddTotblImpresions(x)
            ctx.SaveChanges()

            x.url = fnExportar(x.codigo, path, reporteBase, tablaParametros)

            Dim empresa As tblEmpresa = (From y In ctx.tblEmpresas Where y.idEmpresa = mdlPublicVars.idEmpresa Select y).FirstOrDefault

            Dim txtcorreos As String = empresa.Correos

            Dim correos() As String = txtcorreos.Split(",")
            Dim i
            For i = LBound(correos) To UBound(correos)
                listacorreos.Add(i + 1, correos(i))
            Next

            r.emailTitulo = "Devolucion de Productos"
            r.emailCuerpo = "Concepto de Devolucion Correo enviado desde Sistema Pos Dsi"
            msj += r.EnviarCorreo(listacorreos, x.url).ToString

        Catch ex As Exception

        End Try

    End Sub

    Public Function fnExportar(ByVal codigo As String, ByVal path As String, ByVal reporteExportar As ReportDocument, ByVal tblparametros As DataTable) As String
        Dim carpeta As String = "DocImpresion\" + mdlPublicVars.idEmpresa.ToString + "\"
        Dim archivo As String = ""
        path = path & carpeta

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()

            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            Dim CrFormatTypeOptionsXls As New ExcelFormatOptions

            CrDiskFileDestinationOptions.DiskFileName = path & codigo.ToString & ".pdf"
            archivo = CrDiskFileDestinationOptions.DiskFileName

            CrExportOptions = reporteExportar.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .FormatOptions = CrFormatTypeOptions

                .DestinationOptions = CrDiskFileDestinationOptions
            End With

            reporteExportar.Export()

        Catch ex As Exception
            MsgBox(ex.ToString)
            archivo = ""
        End Try

        Return archivo

    End Function

    Private Sub fnReasignarInventario(ByVal idDevolucionTransporte As Integer)

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim listaDetalles As List(Of tblDevolucionTransporteDetalle) = (From x In conexion.tblDevolucionTransporteDetalles Where x.idDevolucionTransporte = idDevolucionTransporte Select x).ToList
            Dim detalle As tblDevolucionTransporteDetalle

            Dim f As Integer = 0
            For Each detalle In listaDetalles

                Dim inventario As Integer = detalle.inventario
                Dim articulo As Integer = detalle.idArticulo

                Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.idTipoInventario = inventario And x.idArticulo = articulo Select x).FirstOrDefault

                If inve Is Nothing Then

                    Dim inv As New tblInventario

                    inv.idArticulo = articulo
                    inv.entrada = detalle.cantidadAceptada
                    inv.salida = 0
                    inv.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                    inv.reserva = 0
                    inv.transito = 0
                    inv.idTipoInventario = inventario
                    inv.saldo = detalle.cantidadAceptada

                    conexion.AddTotblInventarios(inv)
                    conexion.SaveChanges()

                Else

                    inve.saldo += detalle.cantidadAceptada
                    inve.entrada += detalle.cantidadAceptada

                    conexion.SaveChanges()

                End If

            Next

            conn.Close()
        End Using

    End Sub

    Private Function fnGuardarDevolucion(ByVal idDevolucionTransporte As Integer) As Integer

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

        Dim success As Boolean = True
        Dim idCliente As Integer = Me.grdDatos.Rows(fila).Cells("CodigoCliente").Value
        Dim idVendedor As Integer = mdlPublicVars.idVendedor
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim hora As String = mdlPublicVars.fnHoraServidor
        Dim codigodevolucion As Integer = 0

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            '-------------------Creamos el encabezado de la compra------------'
            Using transaction As New TransactionScope
                Try

                    Dim caso = (From x In conexion.tblClientes Where x.idCliente = idCliente Select x.casos).FirstOrDefault

                    If caso = 0 Then
                        caso = 1
                    Else
                        caso += 1
                    End If

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
                    devolucion.bitFactura = 0
                    devolucion.bitFacturaVarios = 0
                    devolucion.observacion = Me.grdDatos.Rows(fila).Cells("Observacion").Value
                    devolucion.caso = caso
                    devolucion.acreditado = True
                    devolucion.idempresa = mdlPublicVars.idEmpresa

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
                    codigodevolucion = devolucion.codigo

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

                    Dim listaDetalles As List(Of tblDevolucionTransporteDetalle) = (From x In conexion.tblDevolucionTransporteDetalles Where x.idDevolucionTransporte = idDevolucionTransporte Select x).ToList
                    Dim detalle As tblDevolucionTransporteDetalle

                    Dim f As Integer = 0
                    For Each detalle In listaDetalles

                        Dim dev As New tblDevolucionClienteDetalle

                        dev.devolucion = idDevolucion
                        dev.articulo = detalle.idArticulo
                        dev.cantidadRecibida = detalle.cantidadRecibida
                        dev.cantidadAceptada = detalle.cantidadAceptada
                        dev.costo = detalle.precio
                        dev.total = detalle.total
                        dev.observacion = detalle.observacion
                        dev.tipoInventario = detalle.inventario
                        dev.vendedor = mdlPublicVars.idVendedor
                        dev.solucion = True

                        conexion.AddTotblDevolucionClienteDetalles(dev)
                        conexion.SaveChanges()

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
                        alertas.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
            End Using


            If success = True Then
                conexion.AcceptAllChanges()
                alertas.contenido = "Registro guardado correctamente"
                alertas.fnGuardar()
                Return codigodevolucion
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
                Return -1
            End If

            conn.Close()
        End Using

    End Function

    Private Sub fnGuardarPago(ByVal total As Decimal, ByVal idcliente As Integer, ByVal idsalida As Integer)
        Dim conexion As dsi_pos_demoEntities
        Dim success As Boolean = True

        Dim montorecibido As Decimal = total
        Dim saldofavor As Decimal

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Using Transaction As New TransactionScope()
                Try
                    'VARIABLES PARA EL PROCESO
                    ''Dim idCliente As Integer = CInt(cmbCliente.SelectedValue)
                    Dim idTipoPago As Integer = mdlPublicVars.Pagos_codigoEfectivo
                    Dim documento As String = "Acreditacion Devolucion"
                    Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)

                    'TIPO DE PAGO
                    Dim tipoPago As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = idTipoPago Select x).FirstOrDefault

                    Dim pago As New tblCaja
                    pago.documento = If(documento Is Nothing, "", documento)
                    pago.anulado = False
                    pago.codigoSalida = idsalida
                    pago.fecha = fecha
                    pago.fechaTransaccion = fecha
                    pago.monto = montorecibido
                    pago.tipoCambio = 1
                    pago.tipoPago = idTipoPago
                    pago.empresa = mdlPublicVars.idEmpresa
                    pago.usuario = mdlPublicVars.idUsuario
                    pago.observacion = Observacion
                    pago.descripcion = tipoPago.nombre
                    pago.bitRechazado = False
                    pago.consumido = 0
                    pago.afavor = pago.monto
                    pago.confirmado = True
                    pago.transito = False
                    pago.cliente = idcliente
                    pago.bitEntrada = True
                    pago.bitSalida = False

                    conexion.AddTotblCajas(pago)
                    conexion.SaveChanges()

                    ''If bitDocumentoCliente = True Then
                    Dim salidamod As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                    ''Valicaciones para ver si descuenta por documento o por saldo
                    Dim salidapagada As Decimal
                    Dim salidatotal As Decimal
                    Dim validacionpago As Decimal

                    salidatotal = salidamod.saldo
                    salidapagada = salidamod.pagado

                    validacionpago = montorecibido

                    If validacionpago > salidatotal Then
                        salidamod.saldo = 0
                        salidamod.pagado = salidatotal
                    Else
                        salidamod.saldo -= montorecibido
                        salidamod.pagado += montorecibido
                    End If

                    conexion.SaveChanges()


                    ''fin de la validacion del tipo de descuento

                    Dim clientemod As tblCliente = (From x In conexion.tblClientes Where x.idCliente = idcliente Select x).FirstOrDefault

                    Dim montopag As Decimal

                    montopag = montorecibido

                    clientemod.saldo -= montopag
                    clientemod.pagos += montopag

                    conexion.SaveChanges()
                    ''End If
                    Transaction.Complete()
                Catch ex As Exception
                    success = False
                End Try
            End Using
            conn.Close()
        End Using

    End Sub

#End Region

End Class
