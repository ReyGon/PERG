﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI


Public Class frmPagoNuevo

    Public anula As Boolean = False
    Public anularPago As Boolean = False
    Public modifica As Boolean = False
    Public codigoPagoDetalle As Integer = 0

    'Variables de estado
    Public bitSalida As Boolean = False
    Public bitEntrada As Boolean = False
    Public bitCliente As Boolean = False
    Public bitProveedor As Boolean = False

    Public codigoES As Integer = 0
    Public codigoCP As Integer = 0

    Private _diasProgramado As Integer
    Private permiso As New clsPermisoUsuario

    Private tipoCambio As Double

    Public Property diasProgramado As Integer
        Get
            diasProgramado = _diasProgramado
        End Get
        Set(ByVal value As Integer)
            _diasProgramado = value
        End Set
    End Property


    Private Sub frmClientesPagoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
        fnLlenarCombos()
        lblTotal.Text = "0"
        lblSaldoActual.Text = "0"
        mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "txmMonto")
        mdlPublicVars.comboActivarFiltro(cmbCliente)
        If bitProveedor = True Then
            lblCP.Text = "Proveedor"
        Else
            lblCP.Text = "Cliente"
        End If

        lblEDirFac.Visible = bitCliente
        lblENomFac.Visible = bitCliente
        lblNomFac.Visible = bitCliente
        lblDirFac.Visible = bitCliente

        If diasProgramado > 0 Then
            lblEFechaLimite.Visible = True
            lblFechaLimite.Visible = True
            Dim fechaLimite As DateTime = CType(fnFecha_horaServidor(), DateTime).AddDays(diasProgramado)
            lblFechaLimite.Text = Format(fechaLimite, mdlPublicVars.formatoFecha)
        End If

        mdlPublicVars.fnGrid_iconos(grdProductos)

        fnTotal()
    End Sub

    Private Sub fnLlenarCombos()
        Me.grdProductos.Rows.Clear()
        Me.grdProductos.Rows.AddNew()
        Me.grdProductos.Select()

        lblTotal.Text = "0"
        'Me.grdProductos.AllowAddNewRow = True
        dtpFechaInicio.Text = mdlPublicVars.fnFecha_horaServidor
        Dim consulta = Nothing

        If bitProveedor = True Then

            consulta = (From x In ctx.tblProveedors Select Codigo = 0, Nombre = "< .. Ninguno .. >").Union(From x In ctx.tblProveedors _
                       Order By x.negocio
                      Select codigo = x.idProveedor, nombre = x.negocio)

        ElseIf bitCliente = True Then
            consulta = From y In (From x In ctx.tblClientes Select Codigo = 0, Nombre = "< .. Ninguno .. >").Union(From x In ctx.tblClientes _
                       Select codigo = x.idCliente, nombre = Trim(x.Negocio)).Union(From x In ctx.tblClientes Where Trim(x.Nombre1).Length > 0
                                                                              Select Codigo = x.idCliente, Nombre = Trim(x.Nombre1))
                                                                          Order By y.Nombre
                                                                          Select y

        End If


        If bitProveedor = True Or bitCliente = True Then
            With cmbCliente
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = consulta
            End With
            'cmbCliente.Enabled = True
        Else
            'cmbCliente.Enabled = False
        End If

        If (bitProveedor = True Or bitCliente = True) And codigoCP > 0 Then
            cmbCliente.SelectedValue = codigoCP
            cmbCliente.Enabled = False
        End If
        Me.dtpFechaInicio.Focus()
        mdlPublicVars.comboActivarFiltro(cmbCliente)

        'Agregamos la columna al grid
        'Le asignamos el data source al grid
         If bitCliente = True Then
            consulta = (From x In ctx.tblTipoPagoes Where x.entrada = True And Not x.caja Select codigo = x.codigo, nombre = x.nombre)
        ElseIf bitProveedor = True Then
            consulta = (From x In ctx.tblTipoPagoes Where x.salida = True And Not x.caja Select codigo = x.codigo, nombre = x.nombre)
        End If

        Dim tipoPago As New GridViewComboBoxColumn()
        tipoPago.FieldName = "txmTipoPago"
        tipoPago.Name = "txmTipoPago"
        tipoPago.HeaderText = "Tipo de Pago"
        tipoPago.Width = 150
        With tipoPago
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = consulta
        End With

        Try
            'Agregamos la columna al grid
            Me.grdProductos.Columns.Add(tipoPago)
            'Movemos la columna
            Me.grdProductos.Columns.Move(Me.grdProductos.ColumnCount - 1, 0)
        Catch ex As Exception
            Console.WriteLine("Ya existe columna")
        End Try
        

    End Sub

    Private Sub fnTotal()

        Dim index
        Dim total As Double = 0
        Dim saldo As Double = 0
        Dim saldoActual As Double = 0
        Dim enProceso As Decimal = CDbl(lblEnProceso.Text)
        For index = 0 To Me.grdProductos.Rows.Count - 1
            If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                total = total + CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double)
            End If
        Next

        If IsNumeric(lblSaldo.Text) Then
            saldo = lblSaldo.Text
        Else
            saldo = 0
        End If


        If total > 0 Then
            saldoActual = saldo - total + enProceso
        Else
            saldoActual = saldo + Math.Abs(total) + enProceso
        End If



        'Mostrar resultados.
        If total <> 0 Then
            lblTotal.Text = Format(total, mdlPublicVars.formatoMoneda)
        Else
            lblTotal.Text = 0
        End If

        If saldoActual <> 0 Then
            lblSaldoActual.Text = Format(saldoActual, mdlPublicVars.formatoMoneda)
        Else
            lblSaldoActual.Text = "0"
        End If
    End Sub

    Private Sub grdProductos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Try
            If e.Column.Name = "observacion" Or e.Column.Name = "txmMonto" Then
                fnTotal()
                'agregar fila
                Dim filas() As String

                'Verificamos si es necesario ingresar una fecha
                Dim idTipoPago As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmTipoPago").Value, Integer)

                If idTipoPago = Nothing Then
                    RadMessageBox.Show("Elija un tipo de pago", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                    Me.grdProductos.Columns("txmTipoPago").IsCurrent = True
                Else

                    Dim tipoPago As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = idTipoPago Select x).First
                    Dim fecha = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").Value
                    Dim monto = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmMonto").Value

                    If monto Is Nothing Or monto = 0 Then
                        RadMessageBox.Show("Debe ingresar una monto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                        Me.grdProductos.Columns("txmMonto").IsCurrent = True
                    Else
                        If tipoPago.prefechado = True And fecha = Nothing Then
                            RadMessageBox.Show("Debe ingresar una fecha", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).IsCurrent = True
                            Me.grdProductos.Columns("txbFecha").IsCurrent = True
                            frmFecha.Text = "Fecha"
                            frmFecha.opcionRetorno = "pagoNuevo"
                            frmFecha.StartPosition = FormStartPosition.CenterScreen
                            frmFecha.ShowDialog()
                        Else
                            'antes de agregar una fila verificar si la ultima es vacia para que no agregue otra.
                            If Me.grdProductos.Rows(Me.grdProductos.Rows.Count - 1).Cells("txmTipoPago").Value = "0" Then
                            Else
                                'Id, codigo,nombre,precio,cantidad
                                filas = {0, 0, "", "?", 0, ""}
                                grdProductos.Rows.Add(filas)
                                grdProductos.Columns("txmTipoPago").IsCurrent = True
                                'grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                                If Me.grdProductos.Rows.Count > 1 Then
                                    Me.grdProductos.AllowAddNewRow = False
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf e.Column.Name = "Fecha" Then
                'id, codigo,nombre,precio,cantidad
                Dim fecha = Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").Value
                If fecha = Nothing Then
                Else
                    Dim filas As String()
                    filas = {0, 0, "", "?", 0, ""}
                    grdProductos.Rows.Add(filas)
                    grdProductos.Columns("txmTipoPago").IsCurrent = True
                    grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                End If
            ElseIf e.Column.Name.Equals("txmTipoPago") Then
                Dim idTipoPago As Integer = CType(Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txmTipoPago").Value, Integer)
                Dim tipo As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = idTipoPago Select x).FirstOrDefault

                If tipo.tblBanco_Cuenta IsNot Nothing Then
                    'Establecemos la cuenta
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("Cuenta").Value = tipo.tblBanco_Cuenta.numeroCuenta & " (" & tipo.tblBanco_Cuenta.tblBanco.nombre & ")"
                End If

                If tipo.transito Then
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").ReadOnly = False
                Else
                    Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").ReadOnly = True
                End If
            End If
            fnTotal()
        Catch ex As Exception
            'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If e.KeyValue = Keys.Delete Then
            fnTotal()
        End If
    End Sub

    'Funcion para agregar la fecha seleecionada
    Public Sub fnAgregarFecha()
        Try
            If mdlPublicVars.superSearchId = 1 Then
                Me.grdProductos.Rows(Me.grdProductos.CurrentRow.Index).Cells("txbFecha").Value = mdlPublicVars.superSearchFecha.ToShortDateString
                If Me.grdProductos.Rows(Me.grdProductos.Rows.Count - 1).Cells("txmTipoPago").Value = "0" Then
                Else

                    'agregar una fila vacia.
                    Dim filas() As String
                    'Id, codigo,nombre,precio,cantidad
                    filas = {0, 0, "", "?", 0, ""}
                    grdProductos.Rows.Add(filas)
                    grdProductos.Columns(1).IsCurrent = True
                    grdProductos.Rows(grdProductos.Rows.Count - 1).IsCurrent = True
                    If Me.grdProductos.Rows.Count > 1 Then
                        Me.grdProductos.AllowAddNewRow = False
                    End If
                End If
            Else
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function fnErrores() As Boolean
        Dim errores As Boolean = False
        Dim contenidoer As String = ""

        If Me.grdProductos.Rows.Count > 0 Then
        Else
            contenidoer = "Ingrese un pago"
            errores = True
        End If

        Dim index
        For index = 0 To Me.grdProductos.Rows.Count - 1
            'si la columna 0 de codigo
            Dim tipoPago As String = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, String)

            If tipoPago <> "0" Then

                If Me.grdProductos.Rows(index).Cells("txmTipoPago").Value.ToString.Length > 0 Then

                    If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                    Else
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells("txmMonto").Value + " " + vbCrLf
                    End If

                    If Me.grdProductos.Rows(index).Cells("txmMonto").Value = 0 Then
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells("txmMonto").Value + " " + vbCrLf
                    End If
                End If
            End If
        Next

        Dim total = CType(Me.lblTotal.Text, Double)
        If bitSalida = True Then
            If total > CType(lblSaldo.Text, Double) Then
                errores = True
                contenidoer = "Monto pagado es mayor al de entrada"
            End If
        End If

        If total <= 0 And bitSalida = True Then
            errores = True
            contenidoer = "Debe ingresar un pago"
        End If

        If errores = True Then
            alerta.contenido = contenidoer
            alerta.fnErrorContenido()
        End If

        Return errores
    End Function

    'Funcion utilizada para guardar el pago
    Private Sub fnGuardar()
        If fnErrores() = True Then
            Exit Sub
        End If

        If diasProgramado > 0 Then
            If fnPagosProgramados() = False Then
                Exit Sub
            End If
        End If


        'declarar variable de codcliente o codprove
        Dim codcliente As Integer

        'seleccionar el codigo de cliente.

        codcliente = CType(cmbCliente.SelectedValue, Integer)


        Dim documento As String = ""
        Dim monto As Double = 0
        Dim tipoPago As Integer = 0
        Dim totalEfectivo As Double = 0
        Dim totalTransito As Double = 0


        'fecha y hora del servidor.
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()

        'variables de transaccion.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim observacion As String = ""


        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                'paso 1, guardar el encabezado del pago
                Dim index As Integer
                For index = 0 To Me.grdProductos.Rows.Count - 1
                    tipoPago = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, Integer)

                    If tipoPago > 0 Then

                        'Obtenemos el tipo de Pago
                        Dim pagoTipo As tblTipoPago = (From x In ctx.tblTipoPagoes.AsEnumerable Where x.codigo = tipoPago Select x).FirstOrDefault

                        'obtener datos del grid
                        documento = Me.grdProductos.Rows(index).Cells("txmDocumento").Value
                        monto = Me.grdProductos.Rows(index).Cells("txmMonto").Value
                        tipoPago = Me.grdProductos.Rows(index).Cells("txmTipoPago").Value
                        observacion = Me.grdProductos.Rows(index).Cells("observacion").Value

                        'Creamos el registro
                        Dim pago As New tblCaja
                        pago.documento = If(documento Is Nothing, "", documento)
                        pago.anulado = 0
                        pago.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                        pago.fechaTransaccion = fecha

                        pago.monto = monto


                        pago.tipoCambio = Convert.ToDecimal(nm5Cambio.Value).ToString



                        pago.tipoPago = tipoPago
                        pago.empresa = mdlPublicVars.idEmpresa
                        pago.usuario = mdlPublicVars.idUsuario
                        pago.observacion = observacion
                        pago.descripcion = pagoTipo.nombre
                        pago.bitRechazado = False

                        If pagoTipo.cuenta IsNot Nothing Then
                            pago.cuenta = pagoTipo.cuenta
                            pago.numeroCuenta = pagoTipo.tblBanco_Cuenta.numeroCuenta
                        End If


                        If bitCliente = True And codcliente > 0 Then
                            pago.cliente = codcliente
                            pago.bitEntrada = True
                            pago.bitSalida = False

                        ElseIf bitProveedor = True And codcliente > 0 Then
                            pago.proveedor = codcliente
                            pago.bitEntrada = False
                            pago.bitSalida = True

                        ElseIf bitEntrada = True And codcliente > 0 Then
                            pago.codigoEntrada = codigoES
                        ElseIf bitSalida = True And codcliente > 0 Then
                            pago.codigoSalida = codigoES
                        ElseIf bitCliente = True And codcliente = 0 Then
                            pago.bitEntrada = True
                            pago.bitSalida = True
                        End If


                        If pagoTipo.prefechado = True Then
                            Dim f = Me.grdProductos.Rows(index).Cells("txbFecha").Value
                            Dim fechaConfirma As DateTime = CType(f + " 00:00:00", DateTime)
                            pago.fechaCobro = fechaConfirma
                        End If

                        If pagoTipo.calendarizada Then
                            pago.transito = 1
                            pago.confirmado = 0
                        Else
                            pago.transito = 0
                            pago.confirmado = 1
                            pago.fechaCobro = fecha
                        End If

                        ctx.AddTotblCajas(pago)
                        ctx.SaveChanges()
                        'Decidimos que hacer dependiendo del tipo pago



                        'Si el pago es de una entrada (FACTURA)
                        If bitEntrada = True Then
                            Dim factura As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigoES Select x).FirstOrDefault

                            If pagoTipo.calendarizada = True Then
                                factura.pagosTransito += pago.monto
                            Else
                                If factura.contado = True Then
                                    'Realizamos las transacciones correspondientes
                                    factura.saldo -= pago.monto
                                    factura.pagos += pago.monto
                                    If factura.saldo = 0 Then
                                        factura.pagado = 1
                                    End If
                                    ctx.SaveChanges()
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
                                    ctx.SaveChanges()
                                End If
                            End If

                        ElseIf bitSalida = True Then
                            Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = codigoES Select x).FirstOrDefault
                            If pagoTipo.calendarizada = True Then

                            Else
                                If entrada.contado = True Then
                                    'Realizamos las transacciones correspondientes
                                    entrada.saldo -= pago.monto
                                    entrada.pagos += pago.monto
                                    If entrada.saldo = 0 Then
                                        entrada.cancelado = 1
                                    End If
                                    'Else
                                    '    Dim montoPagar = pago.monto

                                    '    Dim ctaPagar As tblCtaPagar = (From x In ctx.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                                    '    If montoPagar > ctaPagar.saldo Then
                                    '        montoPagar -= ctaPagar.saldo
                                    '        ctaPagar.saldo = 0
                                    '        ctaPagar.cancelada = 1
                                    '    Else
                                    '        ctaPagar.saldo -= montoPagar
                                    '        montoPagar = 0
                                    '    End If
                                End If
                            End If


                        ElseIf bitCliente = True And cmbCliente.SelectedValue > 0 Then
                            Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In ctx.tblCtaCobrars Where x.idCliente = pago.cliente And x.cancelada = False Select x Order By x.fecha Ascending).ToList
                            Dim ctaCobrar As tblCtaCobrar

                            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                            If pagoTipo.calendarizada = True Then
                                cliente.pagosTransito += pago.monto
                            Else
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
                            End If

                            ctx.SaveChanges()


                            'Sis es proveedor entra en este bloque
                        ElseIf bitProveedor = True And cmbCliente.SelectedValue > 0 Then
                            Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                            If proveedor.procedencia = 1 Then


                                If pagoTipo.calendarizada = True Then
                                    proveedor.pagosTransito += pago.monto
                                Else
                                    Dim montoPagar = pago.monto
                                    proveedor.pagos += pago.monto
                                    proveedor.saldoActual -= pago.monto
                                    Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                    Dim ctaPagar As tblCtaPagar

                                    For Each ctaPagar In listaCtaPagar

                                        If montoPagar > ctaPagar.saldo Then
                                            montoPagar -= ctaPagar.saldo
                                            ctaPagar.pagado = ctaPagar.monto
                                            ctaPagar.saldo = 0
                                            ctaPagar.cancelada = 1
                                        Else
                                            ctaPagar.saldo -= montoPagar
                                            ctaPagar.pagado += montoPagar
                                            montoPagar = 0
                                        End If
                                    Next
                                End If


                                ctx.SaveChanges()

                                'Modificaciones
                                ' Sis es proveedore Extranjero e
                            ElseIf proveedor.procedencia = 2 Then

                                If pagoTipo.calendarizada = True Then

                                    If proveedor.pagosTransitoDolar Is Nothing Then
                                        proveedor.pagosTransitoDolar = pago.monto

                                        If proveedor.saldoDolar Is Nothing Then
                                            proveedor.saldoDolar = pago.monto
                                        Else
                                            proveedor.saldoDolar += pago.monto
                                        End If

                                        If proveedor.pagosTransito Is Nothing Then
                                            proveedor.pagosTransito = pago.monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                        Else
                                            proveedor.pagosTransito += pago.monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                        End If

                                    Else
                                        proveedor.pagosTransitoDolar += pago.monto

                                        If proveedor.saldoDolar Is Nothing Then
                                            proveedor.saldoDolar = pago.monto
                                        Else
                                            proveedor.saldoDolar += pago.monto
                                        End If

                                        If proveedor.pagosTransito Is Nothing Then
                                            proveedor.pagosTransito = pago.monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                        Else
                                            proveedor.pagosTransito += pago.monto * Convert.ToDecimal(nm5Cambio.Value).ToString
                                        End If


                                    End If


                                Else
                                    Dim montoPagar = pago.monto

                                    If proveedor.pagosDolar Is Nothing Then
                                        proveedor.pagosDolar = pago.monto
                                        proveedor.saldoDolar = pago.monto
                                    Else
                                        proveedor.pagosDolar += pago.monto
                                        proveedor.saldoDolar -= pago.monto
                                    End If



                                    Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                    Dim ctaPagar As tblCtaPagar

                                    For Each ctaPagar In listaCtaPagar

                                        If montoPagar > ctaPagar.saldo Then
                                            montoPagar -= ctaPagar.saldo
                                            ctaPagar.pagado = ctaPagar.monto
                                            ctaPagar.saldo = 0
                                            ctaPagar.cancelada = 1
                                        Else
                                            ctaPagar.saldo -= montoPagar
                                            ctaPagar.pagado += montoPagar
                                            montoPagar = 0
                                        End If
                                    Next
                                End If

                                ctx.SaveChanges()    ' verificar si va aqui. inicialmente estaba aqui
                            End If

                            'ctx.SaveChanges() ' verificar si va aqui. inicialmente estaba aqui

                        End If


                        fecha = fecha.AddSeconds(1)
                    End If
                Next
                'generar un recibo de caja de pago, con el detalle de pago.

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
                    success = False
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()



            If RadMessageBox.Show("Desea realizar nuevo pago", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                fnLlenarCombos()


                Me.dtpFechaInicio.Focus()
                fnTotal()

            Else
                bitCliente = False   'agregado 
                bitProveedor = False 'agregado

                Me.Close()
            End If
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Sub


    'GUARDAR
    Private Sub fnGuardar_Click() Handles Me.panel0
        Try
            fnGuardar()
        Catch ex As Exception

        End Try
    End Sub

    'DETALLE DE SALDO
    Private Sub fnDetalle() Handles Me.panel1
        Try
            Dim codigo As Integer = CInt(cmbCliente.SelectedValue)
            Dim saldo As Decimal = lblSaldo.Text
            If bitProveedor = True Then
                frmDetalleSaldo.Text = "Saldo Proveedor"
                frmDetalleSaldo.codigo = codigo
                frmDetalleSaldo.bitProveedor = True
                frmDetalleSaldo.bitCliente = False
                frmDetalleSaldo.saldo = saldo
                frmDetalleSaldo.StartPosition = FormStartPosition.CenterScreen
                frmDetalleSaldo.ShowDialog()
                frmDetalleSaldo.Dispose()
            ElseIf bitCliente = True Then
                frmDetalleSaldo.Text = "Detalle Cliente"
                frmDetalleSaldo.codigo = codigo
                frmDetalleSaldo.bitProveedor = False
                frmDetalleSaldo.bitCliente = True
                frmDetalleSaldo.saldo = saldo
                frmDetalleSaldo.StartPosition = FormStartPosition.CenterScreen
                frmDetalleSaldo.ShowDialog()
                frmDetalleSaldo.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'ESTADO DE CUENTA
    Private Sub fnEstadoCuentas() Handles Me.panel2
        Try
            Dim codigo As Integer = CInt(cmbCliente.SelectedValue)
            If bitCliente = True Then
                frmClienteEstadoCuenta.Text = "Estado de Cuenta"
                frmClienteEstadoCuenta.cliente = codigo
                frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmClienteEstadoCuenta.BringToFront()
                frmClienteEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
                frmClienteEstadoCuenta.Dispose()
            ElseIf bitProveedor = True Then
                frmProveedorEstadoCuenta.Text = "Estado de Cuenta"
                frmProveedorEstadoCuenta.proveedor = codigo
                frmProveedorEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmProveedorEstadoCuenta.BringToFront()
                frmProveedorEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmProveedorEstadoCuenta)
                frmProveedorEstadoCuenta.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnBoletasNoConfirmadas() Handles Me.panel3
        Try
            frmPagosSinConfirmar.Text = "Pagos Sin Confirmas"
            frmPagosSinConfirmar.bitCliente = True
            frmPagosSinConfirmar.bitProveedor = False
            frmPagosSinConfirmar.codigo = cmbCliente.SelectedValue
            frmPagosSinConfirmar.StartPosition = FormStartPosition.CenterScreen
            frmPagosSinConfirmar.BringToFront()
            frmPagosSinConfirmar.Focus()
            permiso.PermisoDialogEspeciales(frmPagosSinConfirmar)
            frmProveedorEstadoCuenta.Dispose()
        Catch ex As Exception
            alerta.fnError()
        End Try
        
    End Sub
    'SALIR
    Private Sub pbx1Salir_Click() Handles Me.panel4
        Me.Close()
    End Sub
    '3184

    Private Sub cmbCliente_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        If CInt(cmbCliente.SelectedValue) > 0 Then
            If bitCliente = True Then
                Dim codigo As Integer = cmbCliente.SelectedValue
                Dim c As tblCliente = (From x In ctx.tblClientes.AsEnumerable Where x.idCliente = codigo Select x).FirstOrDefault
                If c.saldo <> 0 Then
                    lblSaldo.Text = Format(c.saldo, mdlPublicVars.formatoMoneda)
                Else
                    lblSaldo.Text = 0
                End If

                Dim salidas As Double
                Try
                    salidas = (From x In ctx.tblSalidas Where x.idCliente = codigo And x.anulado = False _
                               And x.facturado = False And x.despachar = True _
                               Select x.total).Sum
                Catch ex As Exception
                    salidas = 0
                End Try

                lblEnProceso.Text = Format(salidas, mdlPublicVars.formatoMoneda)

                'Obtenemos la informacion del cliente
                lblNomFac.Text = c.Nombre1
                lblDirFac.Text = c.direccionFactura1
            Else
                lblNomFac.Text = ""
                lblDirFac.Text = ""

            End If

            If bitProveedor = True Then
                Dim codigo As Integer = cmbCliente.SelectedValue
                Dim c As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault

                If c.saldoActual <> 0 Then
                    lblSaldo.Text = Format(c.saldoActual, mdlPublicVars.formatoMoneda)
                Else
                    lblSaldo.Text = 0
                End If

                'procediencia, codigo =2 es extranjero.
                If c.tblProveedorProcedencia.codigo = 2 Then
                    lblCambio.Visible = True
                    nm5Cambio.Visible = True
                Else
                    lblCambio.Visible = False
                    nm5Cambio.Visible = False
                End If

            End If

            fnTotal()
        Else
            lblNomFac.Text = ""
            lblDirFac.Text = ""

            lblCambio.Visible = False
            nm5Cambio.Visible = False
        End If
    End Sub

    Private Sub frmPagoNuevo_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmPagosLista.frm_llenarLista()
    End Sub

    Private Sub grdProductos_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdProductos.UserDeletedRow
        If grdProductos.Rows.Count = 0 Then
            Me.grdProductos.Rows.AddNew()
        End If
    End Sub

    'Funcion utilizada para verificar los dias de programacion de cada pago
    Private Function fnPagosProgramados() As Boolean
        Dim fechaPago As DateTime = Nothing
        Dim fechaLimite As DateTime = fnFecha_horaServidor()
        fechaLimite = fechaLimite.AddDays(diasProgramado)

        'Recorremos el grid
        Dim tipoPago As Integer
        For index As Integer = 0 To Me.grdProductos.RowCount - 1
            tipoPago = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, Integer)
            fechaPago = CType(Me.grdProductos.Rows(index).Cells("txbFecha").Value, DateTime)
            If tipoPago > 0 Then
                'Obtenemos el tipo de Pago
                Dim pagoTipo As tblTipoPago = (From x In ctx.tblTipoPagoes.AsEnumerable Where x.codigo = tipoPago Select x).FirstOrDefault
                If pagoTipo.transito = True Then
                    If fechaPago > fechaLimite Then
                        alerta.contenido = "Debe ingresar una fecha menor o igual a la fecha limite!"
                        alerta.fnErrorContenido()
                        Me.grdProductos.Rows(index).IsCurrent = True
                        Me.grdProductos.Columns("txbFecha").IsCurrent = True
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Sub btnDetalleVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalleVentas.Click
        If bitCliente Then

            If cmbCliente.SelectedValue > 0 Then
                frmDetalleVentasPagos.Text = "Ventas"
                frmDetalleVentasPagos.bitVentas = True
                frmDetalleVentasPagos.cliente = CInt(cmbCliente.SelectedValue)
                frmDetalleVentasPagos.total = CDec(lblEnProceso.Text)
                frmDetalleVentasPagos.StartPosition = FormStartPosition.CenterScreen
                frmDetalleVentasPagos.ShowDialog()
                frmDetalleVentasPagos.Dispose()
            Else
                alerta.contenido = "Seleccionar un Cliente"
                alerta.fnErrorContenido()

            End If
            
        End If
    End Sub
End Class