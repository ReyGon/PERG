Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmPagosLista
    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitCompra As Boolean
    Private _bitVenta As Boolean

    Public codigoCP As Integer = 0
    Public contadorActualizar As Integer = 0
    Public filtroActivo As Boolean
    Private permiso As New clsPermisoUsuario

    Public Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Public Property bitCompra() As Boolean
        Get
            bitCompra = _bitCompra
        End Get
        Set(ByVal value As Boolean)
            _bitCompra = value
        End Set
    End Property

    Public Property bitVenta() As Boolean
        Get
            bitVenta = _bitVenta
        End Get
        Set(ByVal value As Boolean)
            _bitVenta = value
        End Set
    End Property

    Private Sub frmPagosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdDatos.ImageList = frmControles.ImageListAdministracion

            If bitCliente = True Then
                Dim iz As New frmClientesBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            ElseIf bitProveedor = True Then
                Dim iz As New frmProveedorBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            ElseIf bitCompra = True Then
                Dim iz As New frmComprasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            ElseIf bitVenta = True Then
                Dim iz As New frmPedidosFacturasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If

            If bitCliente Or bitVenta Then
                frmBarraLateralBaseDerecha = frmPagosListaBarraDerecha
                pnlOpciones.Enabled = True
                pnlOpciones.Visible = True
            Else
                pnlOpciones.Enabled = False
                pnlOpciones.Visible = False
            End If

            ActivarBarraLateral = True
            lbl2Eliminar.Text = "Anular"

         
        Catch ex As Exception

        End Try

        llenagrid()
    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click

        If Me.grdDatos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If (Me.grdDatos.CurrentColumn.Name.Equals("chmConfirmar")) And fila >= 0 Then
                'Verficamos si el pago no ha sido anulado
                Dim anulado As Boolean = Me.grdDatos.Rows(fila).Cells("chkAnulado").Value
                Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value
                If anulado Then
                    RadMessageBox.Show("El pago ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                ElseIf valor = False Then
                    'Verificamos si el usuario puede confirmar pagos
                    Dim user As tblUsuario = (From x In ctx.tblUsuarios.AsEnumerable Where x.idUsuario = mdlPublicVars.idUsuario _
                                              Select x).FirstOrDefault

                    If user.bitConfirmaPago Then
                        Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = True
                        If RadMessageBox.Show("Desea confirmar pago?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                            fnConfirmarPago()
                        Else
                            Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = False
                        End If
                    Else
                        RadMessageBox.Show("No tiene permisos para confirmar pagos", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End If

                End If
            End If
        End If

        Return False
    End Function

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            Dim companyInfo = Nothing
            If bitCliente = True Then

                companyInfo = (From x In (
                                (From x In ctx.tblCajas _
                               Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                                And x.bitEntrada = True _
                               Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave,
                               Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto,
                               clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                               chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado).Union(
                               From x In ctx.tblCajas _
                               Where (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                               And x.proveedor Is Nothing And x.codigoEntrada Is Nothing And x.codigoSalida Is Nothing And x.cliente Is Nothing _
                               And x.bitEntrada = True
                               Select Codigo = x.codigo, Fecha = x.fecha, ID = 0, Clave = "",
                               Negocio = "", TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto,
                               clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                               chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado)) Select x Order By x.Fecha Descending)



                'Order By Fecha Descending


            ElseIf bitProveedor = True Or bitCompra = True Then
                companyInfo = From x In ctx.tblCajas _
                           Where x.proveedor > 0 And (x.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblProveedor.idProveedor, Clave = x.tblProveedor.clave, Negocio = x.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32), chkAnulado = x.anulado,
                           FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                           Order By Fecha Descending
            ElseIf bitCompra = True Then
                companyInfo = From x In ctx.tblCajas Join y In ctx.tblEntradas On x.codigoSalida Equals y.idEntrada _
                           Where x.anulado = False And x.codigoSalida > 0 And (y.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           Select Codigo = x.codigo, Numero = y.correlativo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = y.idProveedor, Negocio = y.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")), Int32), chmConfirmar = x.confirmado
            ElseIf bitVenta = True Then
                companyInfo = From x In ctx.tblCajas _
                           Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.bitRechazado, "3", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")))), Int32),
                           chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                           Order By Fecha Descending
            End If

            Me.grdDatos.DataSource = companyInfo
            'cambiar iconos del grid.
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Public Sub llenagrid(desde As DateTime, hasta As DateTime)
        Try
            Dim filtro As String = txtFiltro.Text
            Dim companyInfo = Nothing
            If bitCliente = True Then
                companyInfo = From x In ctx.tblCajas _
                           Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           And x.fecha > desde And x.fecha < hasta _
                           Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                           chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                           Order By Fecha Descending
            ElseIf bitProveedor = True Or bitCompra = True Then
                companyInfo = From x In ctx.tblCajas _
                           Where x.proveedor > 0 And (x.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           And x.fecha > desde And x.fecha < hasta _
                           Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblProveedor.idProveedor, Clave = x.tblProveedor.clave, Negocio = x.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32), chkAnulado = x.anulado,
                           FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                           Order By Fecha Descending
            ElseIf bitCompra = True Then
                companyInfo = From x In ctx.tblCajas Join y In ctx.tblEntradas On x.codigoSalida Equals y.idEntrada _
                           Where x.anulado = False And x.codigoSalida > 0 And (y.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           And x.fecha > desde And x.fecha < hasta _
                           Select Codigo = x.codigo, Numero = y.correlativo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = y.idProveedor, Negocio = y.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")), Int32), chmConfirmar = x.confirmado
            ElseIf bitVenta = True Then
                companyInfo = From x In ctx.tblCajas _
                           Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                           And x.fecha > desde And x.fecha < hasta _
                           Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                           chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                           Order By Fecha Descending
            End If

            Me.grdDatos.DataSource = companyInfo
            'cambiar iconos del grid.
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                If contadorActualizar = 0 Then
                    contadorActualizar += 1
                Else
                    Exit Sub
                End If
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaConfirmado")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

                Me.grdDatos.Columns("ID").IsVisible = False

                Me.grdDatos.Columns("chkAnulado").HeaderText = "Anulado"
                Me.grdDatos.Columns("clrEstado").HeaderText = "Estado"
                Me.grdDatos.Columns("FechaConfirmado").HeaderText = "Fecha Confirm."

                Me.grdDatos.Columns("Codigo").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Clave").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Negocio").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("TipoPago").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("FechaConfirmado").TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns("Codigo").Width = 60
                Me.grdDatos.Columns("Fecha").Width = 80
                Me.grdDatos.Columns("Clave").Width = 60
                Me.grdDatos.Columns("Negocio").Width = 200
                Me.grdDatos.Columns("TipoPago").Width = 130
                Me.grdDatos.Columns("Doc").Width = 80
                Me.grdDatos.Columns("Monto").Width = 70
                Me.grdDatos.Columns("clrEstado").Width = 70
                Me.grdDatos.Columns("chkAnulado").Width = 50
                Me.grdDatos.Columns("chmConfirmar").Width = 110

            End If
        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub fnConfirmarPago()
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)


        Dim idPago As Integer = CType(Me.grdDatos.Rows(fila).Cells("Codigo").Value, Integer)
        Dim idCliente As Integer
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(fila).Cells("chkAnulado").Value, Boolean)
        If bitCliente = True Then
            idCliente = CType(Me.grdDatos.Rows(fila).Cells("ID").Value, Integer)
        End If
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim success As Boolean = True

        Using transaction As New TransactionScope

            Try
                If anulado = True Then
                    success = False
                    Exit Try
                Else
                    'Confirmamos el pago
                    Dim pago As tblCaja = (From x In ctx.tblCajas Where x.codigo = idPago Select x).FirstOrDefault
                    pago.confirmado = 1
                    pago.fechaCobro = fechaServer
                    If pago.transito = True Then
                        pago.transito = False
                    End If
                    'Si es una salida
                    If pago.codigoEntrada > 0 Then
                        Dim factura As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = pago.codigoEntrada Select x).FirstOrDefault

                        If factura.contado = True Then
                            'Realizamos las transacciones correspondientes
                            factura.saldo -= pago.monto
                            factura.pagos += pago.monto
                            If factura.saldo = 0 Then
                                factura.pagado = 1
                            End If
                        Else
                            Dim montoPagar = pago.monto

                            Dim listaSalidas As List(Of tblSalida) = (From x In ctx.tblSalidas Where x.IdFactura = factura.IdFactura Select x).ToList
                            Dim salida As tblSalida

                            For Each salida In listaSalidas
                                Dim ctaCobrar As tblCtaCobrar = (From x In ctx.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                If montoPagar > ctaCobrar.saldo Then
                                    montoPagar -= ctaCobrar.saldo
                                    ctaCobrar.saldo = 0
                                    ctaCobrar.cancelada = 1
                                Else
                                    ctaCobrar.saldo -= montoPagar
                                    montoPagar = 0
                                End If
                            Next

                        End If
                        ctx.SaveChanges()

                        'Si es una entrada
                    ElseIf pago.codigoSalida > 0 Then
                        Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = pago.codigoSalida Select x).FirstOrDefault
                        If entrada.contado = True Then
                            'Realizamos las transacciones correspondientes
                            entrada.saldo -= pago.monto
                            entrada.pagos += pago.monto

                            If entrada.saldo = 0 Then
                                entrada.cancelado = 1
                            End If
                        Else
                            Dim montoPagar = pago.monto

                            Dim ctaPagar As tblCtaPagar = (From x In ctx.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                            If montoPagar > ctaPagar.saldo Then
                                montoPagar -= ctaPagar.saldo
                                ctaPagar.saldo = 0
                                ctaPagar.cancelada = 1
                            Else
                                ctaPagar.saldo -= montoPagar
                                montoPagar = 0
                            End If

                        End If

                        'Si en un cliente
                    ElseIf pago.cliente > 0 Then
                        Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In ctx.tblCtaCobrars Where x.idCliente = pago.cliente And x.cancelada = False Select x Order By x.fecha Ascending).ToList
                        Dim ctaCobrar As tblCtaCobrar

                        Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                        cliente.pagosTransito -= pago.monto

                        Dim montoPagar = pago.monto

                        cliente.pagos += pago.monto
                        cliente.saldo -= pago.monto

                        For Each ctaCobrar In listasCtaCobrar

                            If montoPagar > ctaCobrar.saldo Then
                                montoPagar -= ctaCobrar.saldo
                                ctaCobrar.pagado += ctaCobrar.saldo
                                ctaCobrar.saldo = 0
                                ctaCobrar.cancelada = 1
                            Else
                                ctaCobrar.saldo -= montoPagar
                                ctaCobrar.pagado += montoPagar
                                montoPagar = 0
                            End If
                        Next

                        'SISTEMA BANCOS
                        If pago.cuenta > 0 Then
                            Dim numeroCorrelativo As Integer = 0

                            'CORRELATIVO
                            Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                                 Select x).FirstOrDefault

                            correlativo.correlativo += 1
                            numeroCorrelativo = correlativo.correlativo
                            ctx.SaveChanges()

                            'Obtenemos el acreditador
                            Dim acreditador As tblBanco_Beneficiario = (From x In ctx.tblBanco_Beneficiario Where x.bitCredito And x.nombre.Equals(pago.tblCliente.Negocio)
                                                                        Select x).FirstOrDefault
                            Dim idAcreditador As Integer = 0
                            Dim nombreAcreditador As String = ""

                            If acreditador IsNot Nothing Then
                                idAcreditador = acreditador.codigo
                                nombreAcreditador = acreditador.nombre
                            Else
                                'Creamos el acreditador
                                Dim nuevoAcreditador As New tblBanco_Beneficiario
                                nuevoAcreditador.bitCredito = True
                                nuevoAcreditador.bitDebitoCheque = False
                                nuevoAcreditador.nombre = pago.tblCliente.Negocio

                                ctx.AddTotblBanco_Beneficiario(nuevoAcreditador)
                                ctx.SaveChanges()

                                idAcreditador = nuevoAcreditador.codigo
                                nombreAcreditador = nuevoAcreditador.nombre
                            End If

                            'Creamos el encabezado de la acreditacion
                            Dim movimiento As New tblBanco_Creditos
                            movimiento.bitAnulado = False
                            movimiento.correlativo = numeroCorrelativo
                            movimiento.documento = pago.documento
                            movimiento.fechaRegistro = pago.fecha
                            movimiento.total = pago.monto
                            movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                            movimiento.bitConfirmado = True
                            movimiento.usuarioConfirma = mdlPublicVars.idUsuario
                            movimiento.fechaConfirmado = fechaServer
                            movimiento.cuenta = CInt(pago.cuenta)
                            ctx.AddTotblBanco_Creditos(movimiento)
                            ctx.SaveChanges()

                            'Verificamos si existe el concepto
                            Dim concepto As tblBanco_MovimientoConcepto = (From x In ctx.tblBanco_MovimientoConcepto Where x.nombre.Equals(pago.tblTipoPago.nombre) Select x).FirstOrDefault
                            Dim idConcepto As Integer = 0

                            If concepto IsNot Nothing Then
                                idConcepto = concepto.codigo
                            Else
                                Dim nuevoConcepto As New tblBanco_MovimientoConcepto
                                nuevoConcepto.nombre = pago.tblTipoPago.nombre
                                nuevoConcepto.bitCredito = True
                                nuevoConcepto.bitCheque = False
                                nuevoConcepto.bitDebito = False

                                ctx.AddTotblBanco_MovimientoConcepto(nuevoConcepto)
                                ctx.SaveChanges()

                                idConcepto = nuevoConcepto.codigo
                            End If

                            'Creamos el detalle de la acreditacion
                            Dim detalle As New tblBanco_CreditosDetalle
                            detalle.credito = movimiento.codigo
                            detalle.acreditador = idAcreditador
                            detalle.concepto = idConcepto
                            detalle.descripcion = pago.tblCliente.Negocio & " - " & pago.tblTipoPago.nombre & " - "
                            detalle.monto = movimiento.total
                            detalle.nombre = nombreAcreditador
                            ctx.AddTotblBanco_CreditosDetalle(detalle)
                            ctx.SaveChanges()

                            'Aumentamos el saldo de la cuenta a la que se confirmo el cierre
                            Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = movimiento.cuenta
                                                             Select x).FirstOrDefault

                            If cuenta.saldo Is Nothing Then
                                cuenta.saldo = pago.monto
                            Else
                                cuenta.saldo += pago.monto
                            End If

                            If cuenta.saldoTransito Is Nothing Then
                                cuenta.saldoTransito = 0
                            End If

                            ctx.SaveChanges()
                        End If



                        'Si es un proveedor
                    ElseIf pago.proveedor > 0 Then

                        Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                        If proveedor.procedencia = 1 Then

                            Dim montoPagar = pago.monto
                            proveedor.pagosTransito -= pago.monto



                            proveedor.pagos += pago.monto

                            proveedor.saldoActual -= pago.monto
                            Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 Select x Order By x.fecha Ascending).ToList
                            Dim ctaPagar As tblCtaPagar

                            For Each ctaPagar In listaCtaPagar

                                If montoPagar > ctaPagar.saldo Then
                                    montoPagar -= ctaPagar.saldo
                                    ctaPagar.saldo = 0
                                    ctaPagar.cancelada = 1
                                Else
                                    ctaPagar.saldo -= montoPagar
                                    ctaPagar.pagado += montoPagar
                                    montoPagar = 0
                                End If
                            Next


                            ' si es proveedor extranjero
                        ElseIf proveedor.procedencia = 2 Then

                            Dim totalQuetzales = pago.monto * pago.tipoCambio  'calculamos el total en quetzales del pago en dolar

                            Dim montoPagar = pago.monto

                            proveedor.saldoDolar -= pago.monto
                            proveedor.pagosTransitoDolar -= pago.monto

                            If proveedor.pagosDolar Is Nothing Then
                                proveedor.pagosDolar = pago.monto
                            Else
                                proveedor.pagosDolar += pago.monto
                            End If


                            proveedor.pagosTransito -= totalQuetzales
                            proveedor.pagos += totalQuetzales
                            proveedor.saldoActual -= totalQuetzales


                            'If proveedor.pagosDolar Is Nothing Then
                            '    proveedor.pagosDolar = pago.monto
                            'Else
                            '    proveedor.pagosDolar += pago.monto
                            '    proveedor.saldoDolar -= pago.monto
                            'End If

                            'proveedor.pagos += totalQuetzales
                            'proveedor.pagosTransito -= totalQuetzales
                            'proveedor.saldoActual -= totalQuetzales





                            Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 Select x Order By x.fecha Ascending).ToList
                            Dim ctaPagar As tblCtaPagar

                            For Each ctaPagar In listaCtaPagar

                                If montoPagar > ctaPagar.saldo Then
                                    montoPagar -= ctaPagar.saldo
                                    ctaPagar.saldo = 0
                                    ctaPagar.cancelada = 1
                                Else
                                    ctaPagar.saldo -= montoPagar
                                    ctaPagar.pagado += montoPagar
                                    montoPagar = 0
                                End If
                            Next

                        End If

                    End If

                End If

                ctx.SaveChanges()

                'paso 8, completar la transaccion.
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
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
            llenagrid()

        Else
            If anulado = True Then
                alertas.contenido = "El pago ha sido anulado"
                alertas.fnErrorContenido()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If
            'alerta.fnErrorGuardar()

        End If
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        If filtroActivo Then
            frmPagosFiltro.fnFiltrar()
        Else
            llenagrid()
        End If
    End Sub

    'NUEVO
    Private Sub frm_nuevo() Handles Me.nuevoRegistro

        If bitCliente = True Or bitVenta = True Then
            frmPagoNuevo.bitCliente = True
            frmPagoNuevo.Text = "Pagos de Clientes"
        ElseIf bitProveedor = True Or bitCompra = True Then
            frmPagoNuevo.bitProveedor = True
            frmPagoNuevo.Text = "Pagos de Proveedores"
        End If

        frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmPagoNuevo)
        frmPagoNuevo.Dispose()
    End Sub

    'ANULAR
    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        If RadMessageBox.Show("Desea anular pago", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
            fnAnularPagoUnico()
        End If
    End Sub

    'VER
    Private Sub frm_ver() Handles Me.verRegistro
        Try
            'Obtenemos el codigo del pago
            frmVerPago.Text = "Pago No.: " & mdlPublicVars.superSearchId
            frmVerPago.codigo = mdlPublicVars.superSearchId
            frmVerPago.StartPosition = FormStartPosition.CenterScreen
            frmVerPago.ShowDialog()
            frmVerPago.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    'MODIFICAR
    Private Sub frm_modificar() Handles Me.modificaRegistro
        alertas.contenido = "No se puede modificar un pago"
        alertas.fnErrorContenido()
    End Sub

    Private Sub fnAnularPagoUnico()
        Dim success As Boolean = True
        Dim codigo As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Codigo").Value, Integer)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chkAnulado").Value, Boolean)
        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                If anulado = True Then

                    success = False
                    Exit Try

                Else
                    'Anulamos un pago unico
                    'Confirmamos el pago
                    Dim pago As tblCaja = (From x In ctx.tblCajas Where x.codigo = codigo Select x).FirstOrDefault
                    Dim fechaAnulado As DateTime = fnFecha_horaServidor()
                    pago.anulado = 1
                    pago.fechaAnulado = fechaAnulado

                    'Si es una salida
                    If pago.codigoEntrada > 0 Then
                        Dim factura As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = pago.codigoEntrada Select x).FirstOrDefault

                        If factura.contado = True Then
                            'Realizamos las transacciones correspondientes
                            factura.saldo += pago.monto

                            If factura.saldo = 0 Then
                                factura.pagado = 0
                            End If
                        Else
                            Dim montoPagar = pago.monto

                            Dim listaSalidas As List(Of tblSalida) = (From x In ctx.tblSalidas Where x.IdFactura = factura.IdFactura Select x).ToList
                            Dim salida As tblSalida
                            Dim montoSalida As Double = 0

                            For Each salida In listaSalidas
                                Dim ctaCobrar As tblCtaCobrar = (From x In ctx.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                montoSalida += ctaCobrar.pagado
                                ctaCobrar.pagado = 0
                                ctaCobrar.saldo = ctaCobrar.monto
                                ctaCobrar.cancelada = 0
                            Next

                            Dim nuevoMonto = montoSalida - montoPagar


                            For Each salida In listaSalidas
                                Dim ctaCobrar As tblCtaCobrar = (From x In ctx.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault
                                If nuevoMonto > ctaCobrar.saldo Then
                                    nuevoMonto -= ctaCobrar.saldo
                                    ctaCobrar.saldo = 0
                                    ctaCobrar.cancelada = 1
                                Else
                                    ctaCobrar.saldo -= nuevoMonto
                                    nuevoMonto = 0
                                End If
                            Next

                        End If
                        ctx.SaveChanges()
                        'Si en un cliente
                    ElseIf pago.cliente > 0 Then
                        Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In ctx.tblCtaCobrars Where x.idCliente = pago.cliente Select x Order By x.fecha Ascending).ToList
                        Dim ctaCobrar As tblCtaCobrar

                        Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                        Dim montoPagar = pago.monto
                        Dim montoSalida As Double = 0

                        If pago.confirmado = True Then
                            cliente.pagos -= pago.monto
                            cliente.saldo += pago.monto
                            For Each ctaCobrar In listasCtaCobrar
                                montoSalida += ctaCobrar.pagado
                                ctaCobrar.pagado = 0
                                ctaCobrar.saldo = ctaCobrar.monto
                                ctaCobrar.cancelada = 0
                            Next

                            Dim nuevoMonto = montoSalida - montoPagar

                            For Each ctaCobrar In listasCtaCobrar
                                If nuevoMonto > ctaCobrar.saldo Then
                                    nuevoMonto -= ctaCobrar.saldo
                                    ctaCobrar.pagado += ctaCobrar.saldo
                                    ctaCobrar.saldo = 0
                                    ctaCobrar.cancelada = 1
                                Else
                                    ctaCobrar.saldo -= nuevoMonto
                                    ctaCobrar.pagado += nuevoMonto
                                    nuevoMonto = 0
                                End If
                            Next
                            'El pago no ha sido confirmado
                        Else
                            cliente.pagosTransito -= pago.monto
                        End If


                        ctx.SaveChanges()
                        'Si es una entrada
                    ElseIf pago.codigoSalida > 0 Then
                        Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = pago.codigoSalida Select x).FirstOrDefault
                        If entrada.contado = True Then
                            'Realizamos las transacciones correspondientes
                            entrada.saldo += pago.monto
                            If entrada.saldo = 0 Then
                                entrada.cancelado = 1
                            Else
                                entrada.cancelado = 0
                            End If
                        Else
                            Dim montoPagar = pago.monto

                            Dim ctaPagar As tblCtaPagar = (From x In ctx.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                            ctaPagar.saldo += montoPagar
                            ctaPagar.pagado -= montoPagar
                            ctaPagar.cancelada = 0

                        End If
                        'Si es un proveedor
                    ElseIf pago.proveedor > 0 Then

                        Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                        Dim montoPagar = pago.monto
                        Dim montoSalida As Double = 0

                        If pago.confirmado = True Then
                            proveedor.saldoActual += pago.monto
                            proveedor.pagos -= pago.monto
                            Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars Where x.idProveedor = pago.proveedor Select x Order By x.fecha Ascending).ToList
                            Dim ctaPagar As tblCtaPagar

                            For Each ctaPagar In listaCtaPagar
                                montoSalida += ctaPagar.pagado
                                ctaPagar.pagado = 0
                                ctaPagar.saldo = ctaPagar.monto
                                ctaPagar.cancelada = 0
                            Next

                            Dim nuevoMonto = montoSalida - montoPagar

                            For Each ctaPagar In listaCtaPagar
                                If nuevoMonto > ctaPagar.saldo Then
                                    nuevoMonto -= ctaPagar.saldo
                                    ctaPagar.pagado += ctaPagar.saldo
                                    ctaPagar.saldo = 0
                                    ctaPagar.cancelada = 1
                                Else
                                    ctaPagar.saldo -= nuevoMonto
                                    ctaPagar.pagado += nuevoMonto
                                    nuevoMonto = 0
                                End If
                            Next
                        Else
                            'proveedor.saldoTransito -= pago.monto
                            proveedor.pagosTransito -= pago.monto
                        End If
                        ctx.SaveChanges()
                    End If
                End If


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
            ctx.AcceptAllChanges()
            alertas.contenido = "Pago anulado exitosamente"
            alertas.fnErrorContenido()
            llenagrid()
        Else
            If anulado = True Then
                alertas.contenido = "Pago ya ha sido anulado!!!"
                alertas.fnErrorContenido()
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

        End If

    End Sub

    Private Sub frmPagosLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Codigo").Value, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Pagos de: " & If(bitCliente, "Clientes", If(bitProveedor, "Proveedores", ""))
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmPagosFiltro.Text = "Filtro: PAGOS"
        frmPagosFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmPagosFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
        llenagrid()
    End Sub
End Class