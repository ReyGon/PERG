Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Windows

Public Class frmPagoClientes

    Public anula As Boolean = False
    Public anularPago As Boolean = False
    Public modifica As Boolean = False
    Public codigoPagoDetalle As Integer = 0

    'Variables de estado
    Public bitSalida As Boolean = False
    Public bitEntrada As Boolean = False
    Public bitCliente As Boolean = False
    Public bitProveedor As Boolean = False

    Public codigoPagoModificar As Integer = 0 'Nos permite identificar el pago que vamos a modificar
    Public bitModificar As Boolean = False 'Para saber si va a ser modificacion
    Public montoModificar As Double 'monto a restar al modifcar el pago

    Public codigoES As Integer = 0
    Public codigoCP As Integer = 0

    Private _diasProgramado As Integer
    Private permiso As New clsPermisoUsuario

    'Private _bitPagoVentaPequenia As Boolean = False 'si es pago de venta pequenia
    Private _listaSalidas As List(Of Tuple(Of Integer, String, Decimal))

    Private tipoCambio As Double

    Public Property diasProgramado As Integer
        Get
            diasProgramado = _diasProgramado
        End Get
        Set(ByVal value As Integer)
            _diasProgramado = value
        End Set
    End Property

    Public Property listaSalidas As List(Of Tuple(Of Integer, String, Decimal))
        Get
            listaSalidas = _listaSalidas
        End Get
        Set(value As List(Of Tuple(Of Integer, String, Decimal)))
            _listaSalidas = value
        End Set
    End Property

    Private Sub frmPagoClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            ''Me.pnlGeneral.BackColor = Color.Gray
            ''Me.pnlHora.BackColor = Color.Gray
            ''Me.TableLayoutPanel1.BackColor = Color.Gray
            ''Me.ContenedorMenu.BackColor = Color.Gray

            Me.rbtFactuaVarias.Enabled = False
            Me.rbtFacturaUnica.Enabled = False
            Me.rbtFacturaUnica.Checked = True

            mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
            fnLlenarCombos()

            lblTotal.Text = "0"
            lblSaldoActual.Text = "0"
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "txmMonto")
            mdlPublicVars.comboActivarFiltro(cmbClientes)

            Me.rbtFacturaUnica.Checked = True

            listaSalidas = New List(Of Tuple(Of Integer, String, Decimal))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombos()
        Me.grdProductos.Rows.Clear()
        If bitModificar = False Then
            Me.grdProductos.Rows.AddNew()
        End If

        Me.grdProductos.Select()

        lblTotal.Text = "0"
        'Me.grdProductos.AllowAddNewRow = True
        dtpFechaInicio.Text = mdlPublicVars.fnFecha_horaServidor
        Dim consulta = Nothing

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                consulta = (From x In conexion.tblClientes Select Codigo = 0, Nombre = "< .. Ninguno .. >").Union(From x In conexion.tblClientes _
                           Where x.habillitado = True Order By x.Negocio
                          Select codigo = x.idCliente, nombre = x.Negocio + " (" + x.nit1 + ") ")

                With cmbClientes
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = consulta
                End With

                Me.dtpFechaInicio.Focus()
                mdlPublicVars.comboActivarFiltro(cmbClientes)

                consulta = (From x In conexion.tblTipoPagoes Where x.entrada = True And Not x.caja Select codigo = x.codigo, nombre = x.nombre)

            Catch ex As Exception

            End Try
            conn.Close()
        End Using


        'agregar columna de tipo combo.
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

    Private Sub cmbClientes_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedValueChanged
        Try

            If Me.cmbClientes.SelectedValue > 0 Then
                Me.rbtFactuaVarias.Enabled = True
                Me.rbtFacturaUnica.Enabled = True
            End If

            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim codigo As Integer = cmbClientes.SelectedValue
                Dim c As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault

                lblDocumento.Visible = True
                lblPago.Visible = True
                lblPagos.Visible = True
                cmbDocumento.Visible = True
                lblSal.Visible = True
                lblSaldos.Visible = True

                fnLlenaComboMovimientos()

                If c.saldo <> 0 Then

                    lblSaldo.Text = Format(c.saldo, mdlPublicVars.formatoMoneda)

                Else
                    lblSaldo.Text = 0
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenaComboMovimientos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cliente As Integer = Me.cmbClientes.SelectedValue()

                Dim mov = (From x In conexion.tblSalidas Select Codigo = CInt(0), Nombre = "Ningun Documento").Union(From x In conexion.tblSalidas Where x.idCliente = cliente And x.saldo > 0 And x.anulado = False And (x.facturado = True Or x.despachar = True Or x.empacado = True) Order By x.idSalida Select Codigo = CInt(x.idSalida), Nombre = CStr("Doc: " & CStr(If(CStr(x.documento) Is Nothing, "S/D", CStr(x.documento)))))

                With cmbDocumento
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = mov
                End With

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
        Me.cmbDocumento.SelectedValue = 0
    End Sub

    Private Sub cmbDocumento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDocumento.SelectedValueChanged
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim codigo As Integer = Me.cmbDocumento.SelectedValue()

                Dim saldos = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x.saldo).FirstOrDefault
                Dim pago = (From x In conexion.tblSalidas Where x.idSalida = codigo Select x.pagado).FirstOrDefault

                Me.lblSaldos.Text = Format(saldos, formatoMoneda)
                Me.lblPagos.Text = Format(pago, formatoMoneda)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtFacturaUnica_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFacturaUnica.CheckedChanged
        Try

            If Me.cmbClientes.SelectedValue = 0 And Me.grdProductos.Rows.Count = 1 Then
                RadMessageBox.Show("Debe Seleccionar Un Proveedor Antes!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If

            If rbtFacturaUnica.Checked = True Then
                Me.lblDocumento.Visible = True
                Me.cmbDocumento.Visible = True
                Me.lblPagos.Visible = True
                Me.lblPago.Visible = True
                Me.lblSal.Visible = True
                Me.lblSaldos.Visible = True
                Me.lblTotalFacturas.Visible = False
                Me.txtTotalFacturas.Visible = False
                Me.lblFacturas.Visible = False
                Me.txtFacturas.Visible = False
                Me.btnFacturas.Visible = False
                Me.lblNumeroFacturas.Enabled = False
                Me.txtNumeroFacturas.Enabled = False
            Else
                Me.lblDocumento.Visible = False
                Me.cmbDocumento.Visible = False
                Me.lblPagos.Visible = False
                Me.lblPago.Visible = False
                Me.lblSal.Visible = False
                Me.lblSaldos.Visible = False
                Me.lblTotalFacturas.Visible = True
                Me.txtTotalFacturas.Visible = True
                Me.lblFacturas.Visible = True
                Me.txtFacturas.Visible = True
                Me.btnFacturas.Visible = True
                Me.lblNumeroFacturas.Enabled = True
                Me.txtNumeroFacturas.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles grdProductos.CellEndEdit
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
                                If bitModificar = False Then
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

    Private Sub fnTotal()

        Dim index
        Dim total As Double = 0
        Dim totalquetzal As Double = 0

        Dim saldo As Double = 0
        Dim saldoActual As Double = 0
        Dim enProceso As Decimal = CDbl(lblEnProceso.Text)
        For index = 0 To Me.grdProductos.Rows.Count - 1
            If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                total = total + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double))
                '  totalquetzal = totalquetzal + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * tipoCambio)
                total = total
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

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                fnTotal()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFacturas_Click(sender As Object, e As EventArgs) Handles btnFacturas.Click
        Try

            mdlPublicVars.superSearchLista3 = Nothing

            listaSalidas = New List(Of Tuple(Of Integer, String, Decimal))

            Dim form As New frmFacturasElegir
            form.listaSalidas = listaSalidas
            form.Text = "Facturas Clientes"
            form.StartPosition = FormStartPosition.CenterScreen
            form.WindowState = FormWindowState.Normal
            form.idcliente = Me.cmbClientes.SelectedValue
            form.txtAcreditacionTotal.Text = Me.grdProductos.Rows(0).Cells("txmMonto").Value
            form.ShowDialog()
            form.Dispose()
            listaSalidas = mdlPublicVars.superSearchLista3

            txtNumeroFacturas.Text = CStr(listaSalidas.Count)
            txtFacturas.Text = ""
            Dim total As Decimal = 0

            For Each empleado As Tuple(Of Integer, String, Decimal) In listaSalidas
                txtFacturas.Text += empleado.Item2 & ", "
                total += empleado.Item3
                txtTotalFacturas.Text = Format(total, formatoMoneda)
            Next

        Catch

        End Try
    End Sub

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

                        If rbtFactuaVarias.Checked Then
                            If Me.grdProductos.Rows(index).Cells("txmMonto").Value <> CDec(Me.txtTotalFacturas.Text) Then
                                ''RadMessageBox.Show("El monto digitado es diferente al total de las facturas seleccionadas", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                errores = True
                                contenidoer = "¡El monto digitado es diferente al total de las facturas seleccionadas!"
                            End If
                        ElseIf rbtFacturaUnica.Checked And Me.cmbDocumento.SelectedValue > 0 Then
                            If Me.grdProductos.Rows(index).Cells("txmMonto").Value > CDec(Replace(Me.lblSaldos.Text, "Q", "")) Then ''> CDec(Replace(Me.lblsal) Then
                                ''RadMessageBox.Show("El monto digitado es diferente al total de las facturas seleccionadas", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                errores = True
                                contenidoer = "¡El monto digitado es diferente al total de las facturas seleccionadas!"
                            End If
                        End If

                    Else
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells("txmMonto").Value + " " + vbCrLf
                    End If

                    If Me.grdProductos.Rows(index).Cells("txmMonto").Value = 0 Then
                        errores = True
                        contenidoer = "Requiere monto numerico: " + Me.grdProductos.Rows(index).Cells("txmMonto").Value + " " + vbCrLf
                    End If
                End If

                If tipoPago = "2" And bitModificar = False Then
                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim doc As String = Me.grdProductos.Rows(index).Cells("txmDocumento").Value

                        Dim nocheque As Integer = (From x In conexion.tblCajas Where x.documento.Equals(doc) And x.tipoPago = tipoPago Select x).Count

                        If nocheque = 0 Then
                        Else
                            errores = True
                            contenidoer = "El Cheque No." & Me.grdProductos.Rows(index).Cells("txmDocumento").Value & " ya esta registrado"
                        End If

                        conn.Close()
                    End Using
                End If

            End If
        Next

        Dim totval As String
        Dim total

        totval = Replace(Me.lblTotal.Text, "Q", "")

        total = CDec(Val(totval))

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

    'GUARDAR
    Private Sub fnGuardar_Click() Handles Me.panel0
        Try
            fnGuardar()
        Catch ex As Exception

        End Try
    End Sub

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
        codcliente = CType(cmbClientes.SelectedValue, Integer)

        If codcliente = 0 Then
            If RadMessageBox.Show("Desea Guardar el Pago Sin Cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                Exit Sub
            End If
        End If

        Dim documento As String = ""
        Dim monto As Double = 0
        Dim tipoPago As Integer = 0
        Dim totalEfectivo As Double = 0
        Dim totalTransito As Double = 0
        Dim observacionpago As String

        'fecha y hora del servidor.
        Dim fecha As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()

        'variables de transaccion.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim observacion As String = ""

        If rbtFacturaUnica.Checked = True Then

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                'crear el encabezado de la transaccion
                Using transaction As New TransactionScope
                    'inicio de excepcion
                    Try
                        'paso 1, guardar el encabezado del pago
                        Dim index As Integer

                        'variable de pago modificado.
                        Dim PagoModificado As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigoPagoModificar Select x).FirstOrDefault() 'para modificar pago

                        'variable de cliente para moficiar el pagon (cliente anterior)
                        Dim clienteAnteriorModificar As tblCliente = (From x In conexion.tblClientes
                                                                      Join c In conexion.tblCajas On c.cliente Equals x.idCliente
                                                                      Where c.codigo = codigoPagoModificar Select x).FirstOrDefault

                        For index = 0 To Me.grdProductos.Rows.Count - 1
                            '2do. obtener el tipo de pago
                            tipoPago = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, Integer)

                            '3ro. verificar si tipo de pago es mayor a cero / si existe un tipo de pago.
                            If tipoPago > 0 Then
                                'Obtenemos el tipo de Pago
                                Dim pagoTipo As tblTipoPago = (From x In conexion.tblTipoPagoes.AsEnumerable
                                                               Where x.codigo = tipoPago Select x).FirstOrDefault

                                'obtener datos del grid
                                documento = Me.grdProductos.Rows(index).Cells("txmDocumento").Value
                                monto = Me.grdProductos.Rows(index).Cells("txmMonto").Value
                                observacion = Me.grdProductos.Rows(index).Cells("observacion").Value

                                Dim pago As New tblCaja ' para guardar pago 

                                If bitModificar = True Then  ' comparamos si es una modificacion de pago
                                    'guardar temporalmente el monto 
                                    montoModificar = PagoModificado.monto ' Capturamos el monto del pago para restarselo a pagos transito del cliente o proveedor

                                    'guardar nuevos valores del pago.
                                    PagoModificado.documento = If(documento Is Nothing, "", documento)
                                    PagoModificado.anulado = 0
                                    PagoModificado.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                                    PagoModificado.fechaTransaccion = fecha
                                    PagoModificado.monto = monto
                                    ''PagoModificado.afavor = monto
                                    PagoModificado.consumido = 0
                                    PagoModificado.tipoCambio = 1
                                    PagoModificado.tipoPago = tipoPago
                                    PagoModificado.empresa = mdlPublicVars.idEmpresa
                                    PagoModificado.usuario = mdlPublicVars.idUsuario
                                    PagoModificado.observacion = observacion
                                    PagoModificado.descripcion = pagoTipo.nombre
                                    PagoModificado.bitRechazado = False

                                    'agregar cuenta bancaria al pago.
                                    If pagoTipo.cuenta IsNot Nothing Then
                                        PagoModificado.cuenta = pagoTipo.cuenta
                                        PagoModificado.numeroCuenta = pagoTipo.tblBanco_Cuenta.numeroCuenta
                                    End If

                                    'agregar configuracion de cliente
                                    If bitCliente = True And codcliente > 0 Then
                                        PagoModificado.proveedor = codcliente
                                        PagoModificado.bitEntrada = True
                                        PagoModificado.bitSalida = False

                                        'agregar configuracion de entrada
                                    ElseIf bitEntrada = True And codcliente > 0 Then
                                        PagoModificado.codigoEntrada = codigoES

                                        'agregar configuracion de salida.
                                    End If


                                    If pagoTipo.prefechado = True Then
                                        Dim f = Me.grdProductos.Rows(index).Cells("txbFecha").Value
                                        f = f.substring(0, 10)
                                        Dim fechaConfirma As DateTime = CType(f + " 00:00:00", DateTime)
                                        PagoModificado.fechaCobro = fechaConfirma
                                    End If

                                    If pagoTipo.calendarizada Then
                                        PagoModificado.transito = 1
                                        PagoModificado.confirmado = 0
                                    Else
                                        PagoModificado.transito = 0
                                        PagoModificado.confirmado = 1
                                        PagoModificado.fechaCobro = fecha
                                    End If

                                    'Guardamos los cambios.
                                    conexion.SaveChanges()
                                Else
                                    'Si no es modificaion entramos a este bloque
                                    'Creamos el registro
                                    pago.documento = If(documento Is Nothing, "", documento)
                                    pago.anulado = 0
                                    pago.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                                    pago.fechaTransaccion = fecha
                                    pago.monto = monto
                                    pago.tipoCambio = 1
                                    pago.tipoPago = tipoPago
                                    pago.empresa = mdlPublicVars.idEmpresa
                                    pago.usuario = mdlPublicVars.idUsuario
                                    If Me.cmbDocumento.SelectedValue > 0 Then
                                        pago.observacion = Me.cmbDocumento.Text
                                    ElseIf Me.cmbDocumento.Visible = False Then
                                        pago.observacion = Me.txtFacturas.Text
                                    End If
                                    pago.observacionpago = observacionpago
                                    pago.descripcion = pagoTipo.nombre
                                    pago.bitRechazado = False
                                    pago.consumido = 0
                                    ''pago.afavor = monto
                                    pago.codutilizado = 0

                                    If Me.cmbDocumento.Visible = True Then
                                        pago.documentofactura = Me.cmbDocumento.Text
                                    End If

                                    pago.docboletadeposito = Me.txtdocumentoboleta.Text

                                    If Me.cmbDocumento.Visible = True And Me.cmbDocumento.SelectedValue > 0 Then

                                        pago.idsalidapago = CInt(Me.cmbDocumento.SelectedValue())

                                    End If

                                    If pagoTipo.cuenta IsNot Nothing Then
                                        pago.cuenta = pagoTipo.cuenta
                                        pago.numeroCuenta = pagoTipo.tblBanco_Cuenta.numeroCuenta
                                    End If

                                    If bitCliente = True And codcliente > 0 Then
                                        pago.cliente = codcliente
                                        pago.bitEntrada = True
                                        pago.bitSalida = False
                                    ElseIf bitEntrada = True And codcliente > 0 Then
                                        pago.codigoEntrada = codigoES
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
                                        pago.fechaCobro = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                                    End If

                                    conexion.AddTotblCajas(pago)
                                    conexion.SaveChanges()

                                End If

                                'Fin de proceso de creacion de pago o Actualizacion.
                                'Decidimos que hacer dependiendo del tipo pago
                                'Si el pago es de una entrada (FACTURA)
                                If bitEntrada = True Then
                                    ''Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigoES Select x).FirstOrDefault

                                    ''If pagoTipo.calendarizada = True Then
                                    ''    factura.pagosTransito += pago.monto
                                    ''Else
                                    ''    If factura.contado = True Then
                                    ''        'Realizamos las transacciones correspondientes
                                    ''        factura.saldo -= pago.monto
                                    ''        factura.pagos += pago.monto
                                    ''        If factura.saldo = 0 Then
                                    ''            factura.pagado = 1
                                    ''        End If
                                    ''        conexion.SaveChanges()
                                    ''    Else
                                    ''        Dim montoPagar = pago.monto

                                    ''        Dim listaSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                    ''                                                  Where x.IdFactura = factura.IdFactura Select x).ToList
                                    ''        Dim salida As tblSalida
                                    ''        For Each salida In listaSalidas
                                    ''            Dim ctaCobrar As tblCtaCobrar = (From x In conexion.tblCtaCobrars
                                    ''                                             Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                    ''            If montoPagar > ctaCobrar.saldo Then
                                    ''                montoPagar -= ctaCobrar.saldo
                                    ''                ctaCobrar.saldo = 0
                                    ''                ctaCobrar.cancelada = 1
                                    ''            Else
                                    ''                ctaCobrar.saldo -= montoPagar
                                    ''                montoPagar = 0
                                    ''            End If
                                    ''        Next
                                    ''        conexion.SaveChanges()
                                    ''    End If
                                    ''End If

                                ElseIf bitCliente = True And cmbClientes.SelectedValue > 0 Then
                                    Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                                    ''If cliente.habilitado = 1 Then
                                    If pagoTipo.calendarizada = True Then
                                        cliente.pagosTransito += pago.monto
                                    Else
                                        Dim montoPagar = pago.monto
                                        cliente.pagos += pago.monto
                                        cliente.saldo -= pago.monto
                                        Dim listaCtaCobrar As List(Of tblCtaCobrar) = (From x In conexion.tblCtaCobrars
                                                                                     Where x.idCliente = pago.cliente And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                        Dim ctaCobrar As tblCtaCobrar

                                        For Each ctaCobrar In listaCtaCobrar

                                            If montoPagar > ctaCobrar.saldo Then
                                                montoPagar -= ctaCobrar.saldo
                                                ctaCobrar.pagado = ctaCobrar.monto
                                                ctaCobrar.saldo = 0
                                                ctaCobrar.cancelada = 1
                                            Else
                                                ctaCobrar.saldo -= montoPagar
                                                ctaCobrar.pagado += montoPagar
                                                montoPagar = 0
                                            End If
                                        Next
                                    End If

                                    ''Descuento de la tabla de entradas para las cuentas por pagar Macora

                                    Dim filas As Integer = Me.grdProductos.Rows.Count - 1
                                    Dim pagoclie As Double
                                    Dim clientepago As Integer = Me.cmbClientes.SelectedValue

                                    For fil As Integer = 0 To filas
                                        Try
                                            pagoclie = Me.grdProductos.Rows(fil).Cells("txmMonto").Value
                                        Catch ex As Exception
                                            pagoclie = 0
                                        End Try

                                        If pagoclie > 0 And cmbDocumento.SelectedValue = 0 Then
                                            ''While pagoclie > 0

                                            ''    Dim salidaspendientes As tblSalida = (From x In conexion.tblSalidas Where x.idCliente = clientepago And x.saldo > 0 And x.anulado = False Order By x.fechaRegistro Select x).Take(1).FirstOrDefault

                                            ''    If salidaspendientes Is Nothing Then
                                            ''        Exit While
                                            ''    End If

                                            ''    If pagoclie > salidaspendientes.saldo Then

                                            ''        pagoclie -= salidaspendientes.saldo
                                            ''        salidaspendientes.saldo = 0
                                            ''        salidaspendientes.pagado = salidaspendientes.total

                                            ''    ElseIf pagoclie <= salidaspendientes.saldo Then

                                            ''        salidaspendientes.saldo -= pagoclie
                                            ''        salidaspendientes.pagado += pagoclie
                                            ''        pagoclie = 0

                                            ''    End If

                                            ''    conexion.SaveChanges()

                                            ''End While
                                        ElseIf pagoclie > 0 And cmbDocumento.SelectedValue > 0 Then

                                            If pagoTipo.calendarizada = False Then
                                                While pagoclie > 0

                                                    Dim docrelacion As Integer = Me.cmbDocumento.SelectedValue

                                                    Dim salidaspendientes As tblSalida = (From x In conexion.tblSalidas Where x.idCliente = clientepago And x.saldo > 0 And x.anulado = False And x.idSalida = docrelacion Select x).FirstOrDefault

                                                    salidaspendientes.saldo -= pagoclie
                                                    salidaspendientes.pagado += pagoclie
                                                    pagoclie = 0

                                                End While
                                            End If
                                            ''ElseIf pagoclie > 0 And cmbDocumento.Visible = False Then

                                            ''    For Each salidas As Tuple(Of Integer, String, Decimal) In listaSalidas
                                            ''        ''txtFacturas.Text += empleado.Item2 & ", "
                                            ''        ''total += empleado.Item3
                                            ''        ''txtTotalFacturas.Text = Format(total, formatoMoneda)

                                            ''        Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salidas.Item1 Select x).FirstOrDefault

                                            ''        sal.saldo -= salidas.Item3
                                            ''        sal.pagado += salidas.Item3

                                            ''        conexion.SaveChanges()

                                            ''    Next

                                        End If

                                    Next



                                    ''Finalizacion del descuento de saldos para las cuentas por pagar de macora

                                    'guardar los cambios
                                    conexion.SaveChanges()

                                    'Modificaciones
                                    ' Sis es proveedore Extranjero e
                                    ''ElseIf proveedor.procedencia = 2 Then

                                    ''    If pagoTipo.calendarizada = True Then

                                    ''        If proveedor.pagosTransitoDolar Is Nothing Then
                                    ''            proveedor.pagosTransitoDolar = monto

                                    ''            If proveedor.saldoDolar Is Nothing Then
                                    ''                proveedor.saldoDolar = monto
                                    ''            Else
                                    ''                proveedor.saldoDolar += monto
                                    ''            End If

                                    ''            If proveedor.pagosTransito Is Nothing Then
                                    ''                proveedor.pagosTransito = pago.monto
                                    ''            Else
                                    ''                proveedor.pagosTransito += pago.monto
                                    ''            End If


                                    ''        Else
                                    ''            proveedor.pagosTransitoDolar += monto

                                    ''            If proveedor.saldoDolar Is Nothing Then
                                    ''                proveedor.saldoDolar = monto
                                    ''            Else
                                    ''                proveedor.saldoDolar += monto
                                    ''            End If

                                    ''            If proveedor.pagosTransito Is Nothing Then
                                    ''                proveedor.pagosTransito = monto
                                    ''            Else
                                    ''                proveedor.pagosTransito += monto
                                    ''            End If

                                    ''            If Me.cmbDocumento.SelectedValue > 0 Then
                                    ''                Try

                                    ''                    Dim identrada As Integer = Me.cmbDocumento.SelectedValue
                                    ''                    Dim idproveedor As Integer = Me.cmbClientes.SelectedValue

                                    ''                    Dim salidaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = idproveedor And x.saldo > 0 And x.anulado = False And x.idEntrada = identrada Select x).FirstOrDefault

                                    ''                    salidaspendientes.saldo -= monto
                                    ''                    salidaspendientes.pagos += monto
                                    ''                    monto = 0

                                    ''                    conexion.SaveChanges()

                                    ''                Catch ex As Exception

                                    ''                End Try
                                    ''            End If


                                    ''        End If
                                    ''        proveedor.saldoActual -= monto

                                    ''    Else
                                    ''        Dim montoPagar = monto

                                    ''        If proveedor.pagosDolar Is Nothing Then
                                    ''            proveedor.pagosDolar = monto
                                    ''            proveedor.saldoDolar = monto
                                    ''        Else
                                    ''            proveedor.pagosDolar += monto
                                    ''            proveedor.saldoDolar -= monto
                                    ''        End If
                                    ''        proveedor.saldoActual -= monto


                                    ''        If Me.cmbDocumento.SelectedValue > 0 Then
                                    ''            Try

                                    ''                Dim salidaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = CInt(Me.cmbClientes.SelectedValue) And x.saldo > 0 And x.anulado = False And x.idEntrada = CInt(Me.cmbDocumento.SelectedValue) Select x).FirstOrDefault

                                    ''                salidaspendientes.saldo -= monto
                                    ''                salidaspendientes.pagos += monto
                                    ''                monto = 0

                                    ''            Catch ex As Exception

                                    ''            End Try
                                    ''        End If


                                    ''        Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                    ''        Dim ctaPagar As tblCtaPagar

                                    ''        For Each ctaPagar In listaCtaPagar

                                    ''            If montoPagar > ctaCobrar.saldo Then
                                    ''                montoPagar -= ctaCobrar.saldo
                                    ''                ctaCobrar.pagado = ctaCobrar.monto
                                    ''                ctaCobrar.saldo = 0
                                    ''                ctaCobrar.cancelada = 1
                                    ''            Else
                                    ''                ctaCobrar.saldo -= montoPagar
                                    ''                ctaCobrar.pagado += montoPagar
                                    ''                montoPagar = 0
                                    ''            End If
                                    ''        Next
                                    ''    End If

                                    ''    conexion.SaveChanges()    ' verificar si va aqui. inicialmente estaba aqui
                                    ''End If

                                    conexion.SaveChanges() ' verificar si va aqui. inicialmente estaba aqui

                                End If


                                fecha = fecha.AddSeconds(1)
                            End If
                        Next
                        'generar un recibo de caja de pago, con el detalle de pago.

                        conexion.SaveChanges()

                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        success = False
                    Catch ex As Exception
                        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
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
                    conexion.AcceptAllChanges()
                    alerta.fnGuardar()

                Else
                    alerta.fnErrorGuardar()
                    Console.WriteLine("La operacion no pudo ser completada")
                End If

                'cerrar la conexion.
                conn.Close()

                'finalizar el proceso.
            End Using
        ElseIf rbtFactuaVarias.Checked = True Then
            Try
                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim index As Integer
                    ''Dim Totalpago As Decimal = 0
                    Dim pagoTipo As tblTipoPago

                    For index = 0 To Me.grdProductos.Rows.Count - 2

                        tipoPago = CType(Me.grdProductos.Rows(index).Cells("txmTipoPago").Value, Integer)

                        pagoTipo = (From x In conexion.tblTipoPagoes.AsEnumerable Where x.codigo = tipoPago Select x).FirstOrDefault

                        documento = Me.grdProductos.Rows(0).Cells("txmDocumento").Value

                        observacionpago = Me.grdProductos.Rows(0).Cells("observacion").Value

                    Next

                    Dim codpago As Integer = 0

                    For Each salida As Tuple(Of Integer, String, Decimal) In listaSalidas

                        If tipoPago > 0 Then
                            Dim pago As New tblCaja

                            pago.tipoPago = tipoPago
                            pago.empresa = mdlPublicVars.idEmpresa
                            pago.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                            pago.fechaTransaccion = fecha
                            pago.confirmado = False
                            pago.transito = 0
                            pago.monto = salida.Item3
                            pago.documento = documento
                            pago.usuario = mdlPublicVars.idUsuario
                            pago.anulado = 0
                            pago.idsalidapago = salida.Item1
                            pago.cliente = codcliente
                            pago.observacionpago = observacionpago
                            If Me.cmbDocumento.Visible = False Then
                                pago.observacion = Me.txtFacturas.Text
                            Else
                                pago.observacion = observacion
                            End If
                            pago.descripcion = pagoTipo.nombre
                            pago.bitRechazado = False
                            pago.bitEntrada = 1
                            pago.bitSalida = 0
                            pago.tipoCambio = 1
                            pago.fecharegistro = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                            pago.fechaFiltro = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                            pago.consumido = 0
                            pago.afavor = 0
                            pago.codutilizado = False
                            pago.docboletadeposito = txtdocumentoboleta.Text

                            conexion.AddTotblCajas(pago)
                            conexion.SaveChanges()
                            codpago = pago.codigo

                            ''Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codproveedor Select x).FirstOrDefault

                            ''proveedor.saldoActual -= entrada.Item3
                            ''proveedor.pagos += entrada.Item3

                            ''conexion.SaveChanges()
                        End If
                        If pagoTipo.calendarizada = False Then


                            Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = codpago Select x).FirstOrDefault

                            pago.confirmado = True

                            conexion.SaveChanges()



                            Dim totalpago As Decimal = salida.Item3

                            Dim clie As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codcliente Select x).FirstOrDefault

                            clie.saldo -= totalpago
                            clie.pagos += totalpago

                            conexion.SaveChanges()


                            Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salida.Item1 Select x).FirstOrDefault

                            If totalpago > 0 And sal.saldo > 0 Then
                                If totalpago = sal.saldo Then

                                    sal.saldo = 0
                                    sal.pagado = sal.total

                                ElseIf totalpago < sal.saldo Then

                                    sal.saldo -= totalpago
                                    sal.pagado += totalpago
                                    totalpago = 0

                                End If

                                conexion.SaveChanges()

                            Else
                                Exit For
                            End If

                        End If

                    Next
                    conn.Close()
                End Using

                Me.txtNumeroFacturas.Text = ""
                Me.txtFacturas.Text = ""
                Me.txtTotalFacturas.Text = ""
                mdlPublicVars.superSearchLista3 = Nothing

            Catch ex As Exception

            End Try
        End If

        If success = True Then

            If RadMessageBox.Show("Desea realizar nuevo pago", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                bitModificar = False
                fnLlenarCombos()
                Me.dtpFechaInicio.Focus()

                fnTotal()

            Else
                bitCliente = False   'agregado 
                bitProveedor = False 'agregado
                Me.Close()
            End If
        End If

    End Sub

    Private Sub fnEstadoCuenta() Handles Me.panel2
        Try
            frmClienteEstadoCuenta.Text = "Estado de Cuenta"
            frmClienteEstadoCuenta.cliente = CInt(Me.cmbClientes.SelectedValue)
            frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
            frmClienteEstadoCuenta.BringToFront()
            frmClienteEstadoCuenta.Focus()
            permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
            frmClienteEstadoCuenta.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Try
            frmBuscarCliente.Text = "Buscar Cliente"
            frmBuscarCliente.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmBuscarCliente)
            frmBuscarCliente.Dispose()

            If superSearchId > 0 Then
                Dim codigo As Integer = CType(superSearchId, Integer)
                Me.cmbClientes.SelectedValue = codigo
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
