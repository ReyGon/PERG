Imports Telerik.WinControls
Imports System.Transactions
Imports System.Linq

Public Class frmPagoRechazar

#Region "Variables"
    Private _idCaja As Integer
    Public Property idCaja As Integer
        Get
            idCaja = _idCaja
        End Get
        Set(value As Integer)
            _idCaja = value
        End Set
    End Property
#End Region

#Region "Funciones"
    'RECHAZAR PAGO
    Private Sub fnRechazar()
        Dim success As Boolean = True
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor

        Using transaction As New TransactionScope
            Try
                'Obtenemos el encabezado del pago
                Dim caja As tblCaja = (From x In ctx.tblCajas Where x.codigo = idCaja Select x).FirstOrDefault

                'Verificamos si el pago ha sido anulado o rechazado
                If caja.anulado Then
                    RadMessageBox.Show("El pago ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ElseIf caja.bitRechazado Then
                    RadMessageBox.Show("El pago ya ha sido rechazado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ElseIf caja.tblTipoPago.cheque Then
                    'Actualimos el registro de el cierre de caja
                    caja.bitRechazado = True
                    caja.usuarioRechazado = mdlPublicVars.idUsuario
                    caja.fechaRechazado = fechaServidor
                    caja.anulado = True
                    caja.fechaAnulado = fechaServidor
                    caja.observacionRechazado = txtObservacion.Text
                    ctx.SaveChanges()

                    If caja.confirmado Then
                        'Verificamos si ya fue asociado a un cierre de caja
                        If caja.tblCierreCajaDetalleCajas.Count > 0 Then
                            'Revertimos el proceso
                            'actualizar el correlativo.
                            Dim numeroCorrelativo As String = 0

                            Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.CierreCaja_CodigoMovimiento _
                                                                 And x.idEmpresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                            If correlativo IsNot Nothing Then
                                correlativo.correlativo += 1
                                ctx.SaveChanges()
                                'asignar el numero de correlativo.
                                numeroCorrelativo = correlativo.serie & correlativo.correlativo
                            Else
                                'crear registro de correlativo.
                                Dim correlativoNuevo As New tblCorrelativo
                                correlativoNuevo.correlativo = 1
                                correlativoNuevo.serie = ""
                                correlativoNuevo.inicio = 1
                                correlativoNuevo.fin = 1000
                                correlativoNuevo.porcentajeAviso = 20
                                correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                                correlativoNuevo.idTipoMovimiento = mdlPublicVars.CierreCaja_CodigoMovimiento
                                ctx.AddTotblCorrelativos(correlativoNuevo)
                                ctx.SaveChanges()

                                'asignar el numero de correlativo.
                                numeroCorrelativo = 1
                            End If

                            'Creamos el encabezado del cierre de caja
                            Dim cierre As New tblCierreCaja
                            cierre.fechaRegistro = fechaServidor
                            cierre.bitAnulado = False
                            cierre.bitConfirmado = False
                            cierre.correlativo = numeroCorrelativo
                            cierre.documentoBoleta = ""
                            cierre.desde = fechaServidor
                            cierre.hasta = fechaServidor
                            cierre.salida = 0
                            cierre.entrada = -caja.monto
                            cierre.usuario = mdlPublicVars.idUsuario
                            cierre.empresa = mdlPublicVars.idEmpresa
                            cierre.montoAjuste = 0
                            cierre.bitAjuste = False
                            cierre.documentoBoleta = caja.tblCierreCajaDetalleCajas.Select(Function(x) x.tblCierreCaja.documentoBoleta).FirstOrDefault
                            cierre.cuenta = caja.tblCierreCajaDetalleCajas.Select(Function(x) x.tblCierreCaja.cuenta).FirstOrDefault
                            cierre.fechaConfirmado = fechaServidor
                            cierre.usuarioConfirmado = mdlPublicVars.idUsuario
                            cierre.bitConfirmado = True
                            ctx.AddTotblCierreCajas(cierre)
                            ctx.SaveChanges()

                            'Creamos el detalle del cheque    
                            Dim chequeDetalle As New tblCierreCajaDetalleCaja
                            chequeDetalle.idCierreCaja = cierre.codigo
                            chequeDetalle.idCaja = idCaja
                            chequeDetalle.bitCheque = True
                            chequeDetalle.bitEfectivo = False
                            ctx.AddTotblCierreCajaDetalleCajas(chequeDetalle)
                            ctx.SaveChanges()


                            Dim totalUsuario As Decimal = -caja.monto

                            'SISTEMA DE BANCOS
                            Dim vendedor As String = ""
                            Dim usuarioRechaza As tblUsuario = (From x In ctx.tblUsuarios.AsEnumerable Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault
                            vendedor = usuarioRechaza.tblVendedor.nombre

                            'CORRELATIVO
                            correlativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                                 Select x).FirstOrDefault

                            correlativo.correlativo += 1
                            numeroCorrelativo = correlativo.correlativo
                            ctx.SaveChanges()

                            'Obtenemos el acreditador
                            Dim acreditador As tblBanco_Beneficiario = (From x In ctx.tblBanco_Beneficiario Where x.bitCredito And x.nombre.Equals(vendedor)
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
                                nuevoAcreditador.nombre = vendedor

                                ctx.AddTotblBanco_Beneficiario(nuevoAcreditador)
                                ctx.SaveChanges()

                                idAcreditador = nuevoAcreditador.codigo
                                nombreAcreditador = nuevoAcreditador.nombre
                            End If

                            'Creamos el encabezado de la acreditacion
                            Dim movimiento As New tblBanco_Creditos
                            movimiento.bitAnulado = False
                            movimiento.correlativo = numeroCorrelativo
                            movimiento.documento = cierre.documentoBoleta
                            movimiento.fechaRegistro = cierre.fechaConfirmado
                            movimiento.total = totalUsuario
                            movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                            movimiento.bitConfirmado = True
                            movimiento.fechaConfirmado = fechaServidor
                            movimiento.usuarioConfirma = mdlPublicVars.idUsuario
                            movimiento.cuenta = cierre.cuenta
                            ctx.AddTotblBanco_Creditos(movimiento)
                            ctx.SaveChanges()

                            'Creamos el detalle de la acreditacion
                            Dim detalle As New tblBanco_CreditosDetalle
                            detalle.credito = movimiento.codigo
                            detalle.acreditador = idAcreditador
                            detalle.concepto = Banco_CierreCaja
                            detalle.descripcion = "Rechazo de Cheque, Cierre de Caja : " & caja.tblCierreCajaDetalleCajas.Select(Function(x) x.tblCierreCaja.codigo).LastOrDefault _
                                & ", del " & Format(caja.tblCierreCajaDetalleCajas.Select(Function(x) x.tblCierreCaja.desde).LastOrDefault, mdlPublicVars.formatoFecha) _
                                & " hasta " & Format(caja.tblCierreCajaDetalleCajas.Select(Function(x) x.tblCierreCaja.hasta).LastOrDefault, mdlPublicVars.formatoFecha)
                            detalle.monto = movimiento.total
                            detalle.nombre = nombreAcreditador
                            ctx.AddTotblBanco_CreditosDetalle(detalle)
                            ctx.SaveChanges()

                            'Aumentamos el saldo de la cuenta a la que se confirmo el cierre
                            Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = cierre.cuenta
                                                             Select x).FirstOrDefault

                            If cuenta.saldo Is Nothing Then
                                cuenta.saldo = totalUsuario
                            Else
                                cuenta.saldo += totalUsuario
                            End If

                            If cuenta.saldoTransito Is Nothing Then
                                cuenta.saldoTransito = 0
                            End If
                            ctx.SaveChanges()
                        Else

                            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = caja.cliente Select x).FirstOrDefault
                            cliente.pagos -= caja.monto
                            cliente.saldo += caja.monto
                            ctx.SaveChanges()
                        End If
                    End If
                Else
                    RadMessageBox.Show("El pago no es un cheque", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                End If

                'Completar transaccion
                transaction.Complete()
            Catch ex As Exception
                success = False
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End Using

        If success Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
            Me.Close()
        End If
    End Sub

#End Region

#Region "Eventos"
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If txtObservacion.Text.Trim.Length > 0 Then
            If RadMessageBox.Show("¿Desea guardar los cambios?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnRechazar()
            End If
        Else
            RadMessageBox.Show("Debe ingresar una observación", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
#End Region

End Class
