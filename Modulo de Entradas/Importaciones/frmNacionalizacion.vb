Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmNacionalizacion

    Dim _idinvoice As Integer
    Public tasaCambio As Decimal

    Public Property idinvoice As Integer
        Get
            idinvoice = _idinvoice
        End Get
        Set(value As Integer)
            _idinvoice = value
        End Set
    End Property

    Private Sub frmNacionalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarInformacion()
        fnTotal()
    End Sub

    Public Sub fnLlenarInformacion()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim invoice As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = idinvoice Select x).FirstOrDefault
                Dim contadorproductos As Integer = (From x In conexion.tblEntradasDetalles Where x.idEntrada = idinvoice Select x).Count
                Dim sumatasaproveedor As Decimal
                Dim contadortasaproveedor As Integer

                frmHistorialPagos.Text = "Pagos/Anticipos a Proveedor"
                frmHistorialPagos.WindowState = FormWindowState.Normal
                frmHistorialPagos.StartPosition = FormStartPosition.CenterScreen
                frmHistorialPagos.idInvoice = CInt(idinvoice)
                frmHistorialPagos.idproveedor = CInt(invoice.idProveedor)
                frmHistorialPagos.ShowDialog()
                frmHistorialPagos.Dispose()

                Me.lblDocumentoImportacion.Text = CStr(invoice.serieDocumento + "-" + invoice.documento)
                Me.lblCantidadProductos.Text = CStr(contadorproductos)
                Me.lblTotalImportacionDolar.Text = Format(CDec(invoice.total), formatoMonedaDolar)
                Me.lblTasaCambio.Text = Format(tasaCambio, formatoMoneda5dec)
                Me.lblValorMercaderiaQ.Text = Format(CDec(CDec(Replace(Me.lblTotalImportacionDolar.Text, "$", "")) * CDec(Replace(Me.lblTasaCambio.Text, "Q", ""))), formatoMoneda5dec)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnTotal()
        Try
            Dim totalGastos As Decimal = 0

            totalGastos += CDec(Me.txtGastosNaviera.Text) + CDec(Me.txtIvaImportacion.Text) + CDec(Me.txtImpuestoImportacion.Text) + CDec(Me.txtTramitesAduanales.Text) +
                  CDec(Me.txtTransporte.Text) + CDec(Me.txtSeguridad.Text) + CDec(Me.txtComisiones.Text) + CDec(Me.txtOtrosGastos.Text) + CDec(Me.txtFleteNaviera.Text)

            Me.lblTotalGastos.Text = Format(totalGastos, formatoMoneda)
            Me.lblTasaIncremento.Text = Format((CDec((Replace(Me.lblTotalGastos.Text, "Q", ""))) / CDec(Replace(Me.lblValorMercaderiaQ.Text, "Q", ""))), formatoNumero5dec) + " %"
            fnTotalMercaderiaQuetzalez()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnTotalMercaderiaQuetzalez()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim tasaincremento As Decimal = CDec(Replace(Me.lblTasaIncremento.Text, "%", "")) + 1
                Dim tasapromedio As Decimal = CDec(Replace(Me.lblTasaCambio.Text, "Q", ""))
                Dim totalmercaderiaquetzalez As Decimal = 0

                Dim productos As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = idinvoice Select x).ToList

                For Each articulos As tblEntradasDetalle In productos
                    totalmercaderiaquetzalez += CDec(Format(((articulos.costoIVA * tasaincremento * tasapromedio) * CDec(articulos.cantidad)), formatoNumero5dec))
                Next

                Me.lblTotalMercaderiaQ.Text = Format(totalmercaderiaquetzalez, formatoMoneda5dec)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub



#Region "Evento Formatos y Totales"



#End Region

#Region "Registrar"
    Private Sub fnGuardar() Handles Me.panel0
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim idnacionalizacion As Integer

                idnacionalizacion = fnCrearNacionalizacion(idinvoice)

                If idnacionalizacion = 0 Then
                    RadMessageBox.Show("Ocurrio un error al nacionalizar la Invoice", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End If

                mdlPublicVars.superSearchId = idnacionalizacion

                Dim inv As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = idnacionalizacion Select x).FirstOrDefault

                Dim n As New tblNacionalizacion
                n.identradainvoice = idinvoice
                n.documento = inv.serieDocumento + "-" + inv.documento
                n.tasacambio = CDec(Me.lblTasaCambio.Text)
                n.gastosnaviera = CDec(Me.txtGastosNaviera.Text)
                n.ivaimportacion = CDec(Me.txtIvaImportacion.Text)
                n.impuestosimportacion = CDec(Me.txtImpuestoImportacion.Text)
                n.tramitesaduanales = CDec(Me.txtTramitesAduanales.Text)
                n.transporte = CDec(Me.txtTransporte.Text)
                n.seguridad = CDec(Me.txtTransporte.Text)
                n.comisiones = CDec(Me.txtComisiones.Text)
                n.otrosgastos = CDec(Me.txtOtrosGastos.Text)
                n.fletenaviera = CDec(Me.txtFleteNaviera.Text)
                n.numeropoliza = Me.txtNumeroPoliza.Text
                n.tasaincremento = CDec(Replace(Me.lblTasaIncremento.Text, "%", ""))

                conexion.AddTotblNacionalizacions(n)
                conexion.SaveChanges()

                ''fnModificarCostosNacionalizados(idnacionalizacion, idinvoice)

                conn.Close()

                frmNotificacion.lblNotificacion.Text = "Registro Guardado Correctamente"
                frmNotificacion.Show()

                Me.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnModificarCostosNacionalizados(ByVal id As Integer, ByVal idinvoice As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim tasaincremento As Decimal = 1
                Dim tasapromedio As Decimal = 0


                Dim n As tblNacionalizacion = (From x In conexion.tblNacionalizacions Where x.identradainvoice = idinvoice Select x).FirstOrDefault

                tasaincremento += CDec(n.tasaincremento)
                tasapromedio = CDec(n.tasacambio)

                Dim det As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = id Select x).ToList

                For Each c As tblEntradasDetalle In det

                    Dim d As tblEntradasDetalle = (From x In conexion.tblEntradasDetalles Where x.idEntradaDetalle = c.idEntradaDetalle Select x).FirstOrDefault

                    d.costoIVA = (d.costoIVA * tasaincremento * tasapromedio) + d.costoIVA
                    d.costoSinIVA = (d.costoSinIVA * tasaincremento * tasapromedio) + d.costoSinIVA

                    conexion.SaveChanges()

                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnCrearNacionalizacion(ByVal identrada As Integer) As Integer

        Dim codigo As Integer
        Dim tasaincremento As Decimal = CDec(Replace(Me.lblTasaIncremento.Text, "%", "")) + 1
        Dim tasapromedio As Decimal = CDec(Replace(Me.lblTasaCambio.Text, "Q", ""))

        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim en As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = identrada Select x).FirstOrDefault

                Dim e As New tblEntrada

                e.idEmpresa = en.idEmpresa
                e.idUsuario = en.idUsuario
                e.idTipoMovimiento = en.idTipoMovimiento
                e.idProveedor = en.idProveedor
                e.fechaRegistro = CDate(fnFecha_horaServidor())
                e.fechaTransaccion = CDate(fnFecha_horaServidor())
                e.fechaAnulado = en.fechaAnulado
                e.fechaCompra = en.fechaCompra
                e.serieDocumento = en.serieDocumento
                e.documento = en.documento
                e.observacion = en.observacion
                e.anulado = en.anulado
                e.preforma = en.preforma
                e.transito = en.transito
                e.compra = en.compra
                e.flete = en.flete
                e.total = en.total
                e.correlativo = en.correlativo
                e.idtipoInventario = en.idtipoInventario
                e.idalmacen = en.idalmacen
                e.cancelado = en.cancelado
                e.saldo = en.saldo
                e.pagos = en.pagos
                e.credito = en.credito
                e.contado = en.contado
                e.fechaPago = en.fechaPago
                e.usuarioCompra = en.usuarioCompra
                e.fechaFiltro = en.fechaFiltro
                e.fechadocumento = en.fechadocumento
                e.estadocuenta = en.estadocuenta
                e.preformaimportacion = False
                e.IdPreformaInvoice = 0
                e.Invoice = False
                e.IdInvoiceNacionalizacion = identrada
                e.Nacionalizacion = True
                e.FechaIngresoTransito = en.FechaIngresoTransito
                e.finalizada = False

                conexion.AddTotblEntradas(e)
                conexion.SaveChanges()

                codigo = e.idEntrada

                Dim d As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = identrada Select x).ToList

                For Each w As tblEntradasDetalle In d

                    Dim r As New tblEntradasDetalle

                    r.idEntrada = codigo
                    r.idArticulo = w.idArticulo
                    r.cantidad = w.cantidad
                    r.costoIVA = CDec(Format(w.costoIVA * tasaincremento * tasapromedio, formatoNumero5dec))
                    r.costoSinIVA = CDec(Format(w.costoIVA * tasaincremento * tasapromedio, formatoNumero5dec))
                    r.preformaCantidad = w.preformaCantidad
                    r.preformaCostoIVA = w.preformaCostoIVA
                    r.preformaCostoSinIVA = w.preformaCostoSinIVA
                    r.costoprorrateo = w.costoprorrateo
                    r.idunidadmedida = w.idunidadmedida
                    r.valormedida = w.valormedida
                    r.nocaja = w.nocaja

                    conexion.AddTotblEntradasDetalles(r)
                    conexion.SaveChanges()

                Next

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Return 0
        End Try
        Return codigo
    End Function

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

#End Region

#Region "Eventos Enter"

    Private Sub txtGastosNaviera_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGastosNaviera.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtGastosNaviera.Text = Format(CDec(Me.txtGastosNaviera.Text), formatoMoneda)
            fnTotal()
            Me.txtIvaImportacion.Focus()
        End If
    End Sub

    Private Sub txtIvaImportacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIvaImportacion.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtIvaImportacion.Text = Format(CDec(Me.txtIvaImportacion.Text), formatoMoneda)
            fnTotal()
            Me.txtImpuestoImportacion.Focus()
        End If
    End Sub

    Private Sub txtImpuestoImportacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImpuestoImportacion.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtImpuestoImportacion.Text = Format(CDec(Me.txtImpuestoImportacion.Text), formatoMoneda)
            fnTotal()
            Me.txtTramitesAduanales.Focus()
        End If
    End Sub

    Private Sub txtTramitesAduanales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTramitesAduanales.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtTramitesAduanales.Text = Format(CDec(Me.txtTramitesAduanales.Text), formatoMoneda)
            fnTotal()
            Me.txtTransporte.Focus()
        End If
    End Sub

    Private Sub txtTransporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransporte.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtTransporte.Text = Format(CDec(Me.txtTransporte.Text), formatoMoneda)
            fnTotal()
            Me.txtSeguridad.Focus()
        End If
    End Sub

    Private Sub txtSeguridad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSeguridad.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtSeguridad.Text = Format(CDec(Me.txtSeguridad.Text), formatoMoneda)
            fnTotal()
            Me.txtComisiones.Focus()
        End If
    End Sub

    Private Sub txtComisiones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComisiones.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtComisiones.Text = Format(CDec(Me.txtComisiones.Text), formatoMoneda)
            fnTotal()
            Me.txtOtrosGastos.Focus()
        End If
    End Sub

    Private Sub txtOtrosGastos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtrosGastos.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtOtrosGastos.Text = Format(CDec(Me.txtOtrosGastos.Text), formatoMoneda)
            fnTotal()
            Me.txtFleteNaviera.Focus()
        End If
    End Sub

    Private Sub txtFleteNaviera_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFleteNaviera.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtFleteNaviera.Text = Format(CDec(Me.txtFleteNaviera.Text), formatoMoneda)
            fnTotal()
            Me.txtNumeroPoliza.Focus()
        End If
    End Sub

    Private Sub txtNumeroPoliza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroPoliza.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Me.txtGastosNaviera.Focus()
        End If
    End Sub
#End Region

#Region "Eventos Lost Focus"
    Private Sub txtGastosNaviera_LostFocus(sender As Object, e As EventArgs) Handles txtGastosNaviera.LostFocus
        Me.txtGastosNaviera.Text = Format(CDec(Me.txtGastosNaviera.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtComisiones_LostFocus(sender As Object, e As EventArgs) Handles txtComisiones.LostFocus
        Me.txtComisiones.Text = Format(CDec(Me.txtComisiones.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtIvaImportacion_LostFocus(sender As Object, e As EventArgs) Handles txtIvaImportacion.LostFocus
        Me.txtIvaImportacion.Text = Format(CDec(Me.txtIvaImportacion.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtImpuestoImportacion_LostFocus(sender As Object, e As EventArgs) Handles txtImpuestoImportacion.LostFocus
        Me.txtImpuestoImportacion.Text = Format(CDec(Me.txtImpuestoImportacion.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtTramitesAduanales_LostFocus(sender As Object, e As EventArgs) Handles txtTramitesAduanales.LostFocus
        Me.txtTramitesAduanales.Text = Format(CDec(Me.txtTramitesAduanales.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtTransporte_LostFocus(sender As Object, e As EventArgs) Handles txtTransporte.LostFocus
        Me.txtTransporte.Text = Format(CDec(Me.txtTransporte.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtSeguridad_LostFocus(sender As Object, e As EventArgs) Handles txtSeguridad.LostFocus
        Me.txtSeguridad.Text = Format(CDec(Me.txtSeguridad.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtOtrosGastos_LostFocus(sender As Object, e As EventArgs) Handles txtOtrosGastos.LostFocus
        Me.txtOtrosGastos.Text = Format(CDec(Me.txtOtrosGastos.Text), formatoMoneda)
        fnTotal()
    End Sub

    Private Sub txtFleteNaviera_LostFocus(sender As Object, e As EventArgs) Handles txtFleteNaviera.LostFocus
        Me.txtFleteNaviera.Text = Format(CDec(Me.txtFleteNaviera.Text), formatoMoneda)
        fnTotal()
    End Sub
#End Region

End Class
