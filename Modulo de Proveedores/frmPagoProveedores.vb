Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Windows

Public Class frmPagoProveedores

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
    Private _listaEntradas As List(Of Tuple(Of Integer, String, Decimal))

    Private tipoCambio As Double

    Public Property diasProgramado As Integer
        Get
            diasProgramado = _diasProgramado
        End Get
        Set(ByVal value As Integer)
            _diasProgramado = value
        End Set
    End Property

    Public Property listaEntradas As List(Of Tuple(Of Integer, String, Decimal))
        Get
            listaEntradas = _listaEntradas
        End Get
        Set(value As List(Of Tuple(Of Integer, String, Decimal)))
            _listaEntradas = value
        End Set
    End Property

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

                consulta = (From x In conexion.tblProveedors Select Codigo = 0, Nombre = "< .. Ninguno .. >").Union(From x In conexion.tblProveedors _
                           Where x.habilitado = True Order By x.negocio
                          Select codigo = x.idProveedor, nombre = x.negocio)

                With cmbProveedor
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = consulta
                End With

                Me.dtpFechaInicio.Focus()
                mdlPublicVars.comboActivarFiltro(cmbProveedor)

                consulta = (From x In conexion.tblTipoPagoes Where x.salida = True And Not x.caja Select codigo = x.codigo, nombre = x.nombre)

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

    Private Sub frmPagoProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            ''Me.pnlGeneral.BackColor = Color.Gray
            ''Me.pnlHora.BackColor = Color.Gray
            ''Me.TableLayoutPanel1.BackColor = Color.Gray
            ''Me.ContenedorMenu.BackColor = Color.Gray

            Me.rbtFactuaVarias.Enabled = False
            Me.rbtFacturaUnica.Enabled = False
            Me.rbtFacturaUnica.Checked = True

            Me.nm5Cambio.Value = 1

            mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
            fnLlenarCombos()

            lblTotal.Text = "0"
            lblSaldoActual.Text = "0"
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "txmMonto")
            mdlPublicVars.comboActivarFiltro(cmbProveedor)

            tipoCambio = nm5Cambio.Value

            Me.rbtFacturaUnica.Checked = True

            listaEntradas = New List(Of Tuple(Of Integer, String, Decimal))

        Catch ex As Exception

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
                total = total + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * tipoCambio)
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

    Private Sub fnTotalDolares()

        Dim index
        Dim total As Double = 0
        Dim totalquetzal As Double = 0

        Dim saldo As Double = 0
        Dim saldoActual As Double = 0
        Dim enProceso As Decimal = CDbl(lblEnProceso.Text)
        For index = 0 To Me.grdProductos.Rows.Count - 1
            If IsNumeric(Me.grdProductos.Rows(index).Cells("txmMonto").Value) Then
                total = total + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * 1)
                ''  totalquetzal = totalquetzal + (CType(Me.grdProductos.Rows(index).Cells("txmMonto").Value, Double) * tipoCambio)
                total = total
            End If
        Next

        If IsNumeric(Replace(lblSaldo.Text, "$", "")) Then
            saldo = Replace(lblSaldo.Text, "$", "")
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
            lblTotal.Text = Format(total, mdlPublicVars.formatoMonedaDolar)
        Else
            lblTotal.Text = 0
        End If

        If saldoActual <> 0 Then
            lblSaldoActual.Text = Format(saldoActual, mdlPublicVars.formatoMonedaDolar)
        Else
            lblSaldoActual.Text = "0"
        End If
    End Sub

    Private Sub cmbProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedValueChanged
        Try

            If Me.cmbProveedor.SelectedValue > 0 Then
                Me.rbtFactuaVarias.Enabled = True
                Me.rbtFacturaUnica.Enabled = True
            End If

            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim codigo As Integer = cmbProveedor.SelectedValue
                Dim c As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault

                'procediencia, codigo =2 es extranjero.
                If c.tblProveedorProcedencia.codigo = 2 Then
                    lblCambio.Visible = True
                    nm5Cambio.Visible = True

                    lblDocumento.Visible = False
                    ''lblPago.Visible = True
                    ''lblPagos.Visible = True
                    ''cmbDocumento.Visible = True
                    '' lblSal.Visible = True
                    ''lblSaldos.Visible = True
                    ''lbldocumentofactura.Visible = True
                    ''txtdocfactura.Visible = True
                    lblPreformaD.Visible = True
                    txtPreformaD.Visible = True
                    lblInvoiceD.Visible = True
                    txtInvoiceD.Visible = True

                    fnLlenaComboMovimientos()
                Else
                    lblCambio.Visible = False
                    nm5Cambio.Visible = False

                    lblDocumento.Visible = True
                    lblPago.Visible = True
                    lblPagos.Visible = True
                    cmbDocumento.Visible = True
                    lblSal.Visible = True
                    lblSaldos.Visible = True
                    ''lbldocumentofactura.Visible = True
                    ''txtdocfactura.Visible = True

                    fnLlenaComboMovimientos()

                End If



                If c.saldoActual <> 0 Then
                    If nm5Cambio.Visible = True Then
                        lblSaldo.Text = Format(c.saldoActual, mdlPublicVars.formatoMonedaDolar)
                    Else
                        lblSaldo.Text = Format(c.saldoActual, mdlPublicVars.formatoMoneda)
                    End If
                Else
                    lblSaldo.Text = 0
                End If

                ' ''procediencia, codigo =2 es extranjero.
                ''If c.tblProveedorProcedencia.codigo = 2 Then
                ''    lblCambio.Visible = True
                ''    nm5Cambio.Visible = True

                ''    lblDocumento.Visible = True
                ''    lblPago.Visible = True
                ''    lblPagos.Visible = True
                ''    cmbDocumento.Visible = True
                ''    lblSal.Visible = True
                ''    lblSaldos.Visible = True
                ''    ''lbldocumentofactura.Visible = True
                ''    ''txtdocfactura.Visible = True

                ''    fnLlenaComboMovimientos()
                ''Else
                ''    lblCambio.Visible = False
                ''    nm5Cambio.Visible = False

                ''    lblDocumento.Visible = True
                ''    lblPago.Visible = True
                ''    lblPagos.Visible = True
                ''    cmbDocumento.Visible = True
                ''    lblSal.Visible = True
                ''    lblSaldos.Visible = True
                ''    ''lbldocumentofactura.Visible = True
                ''    ''txtdocfactura.Visible = True

                ''    fnLlenaComboMovimientos()

                ''End If

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

                Dim proveedor As Integer = Me.cmbProveedor.SelectedValue()

                ''Dim mov = (From x In conexion.tblEntradas Where x.saldo > 0 And x.anulado = 0 And x.idProveedor = proveedor Select Codigo = 0, Nombre = "Ninguno").Union(From x In conexion.tblEntradas Where x.saldo > 0 And x.anulado = 0 And x.idProveedor = proveedor Select Codigo = x.idEntrada, Nombre = CStr(x.serieDocumento & "-" & x.documento))

                ''Dim mov = (From x In conexion.tblArticuloTipoPrecios Select Codigo = 0, Nombre = "<-Todos->").Union(From x In conexion.tblArticuloTipoPrecios Select Codigo = x.codigo, Nombre = x.nombre)

                Dim mov = (From x In conexion.tblEntradas Select Codigo = CInt(0), Nombre = "Ningun Documento").Union(From x In conexion.tblEntradas Where x.idProveedor = proveedor And _
                   x.saldo > 0 And x.anulado = False Order By x.idEntrada Select Codigo = CInt(x.idEntrada), _
                   Nombre = CStr(If((x.preformaimportacion = 1 And x.transito = False), CStr("Proforma Invoice: " & x.serieDocumento & "-" & x.documento), _
                    If((x.preforma = True And x.preformaimportacion = 0 And x.compra = False), CStr("Preforma: " & x.serieDocumento & "-" & x.documento), _
                    If((x.compra = True), CStr("Compra: " & x.serieDocumento & "-" & x.documento), _
                    If((x.compra = True And x.preformaimportacion = 1), CStr("Invoice: " & x.serieDocumento & "-" & x.documento), "S/D: "))))))

                ''If((x.preformaimportacion > 0 And x.transito = True And x.preformatotransito = True), CStr("Transito Invoice: " & x.serieDocumento & "-" & x.documento), _

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

                Dim saldos = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x.saldo).FirstOrDefault
                Dim pago = (From x In conexion.tblEntradas Where x.idEntrada = codigo Select x.pagos).FirstOrDefault

                If nm5Cambio.Visible = True Then
                    Me.lblSaldos.Text = Format(saldos, formatoMonedaDolar)
                    Me.lblPagos.Text = Format(pago, formatoMonedaDolar)
                Else
                    Me.lblSaldos.Text = Format(saldos, formatoMoneda)
                    Me.lblPagos.Text = Format(pago, formatoMoneda)
                End If



                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles grdProductos.CellEndEdit
        Try
            If e.Column.Name = "observacion" Or e.Column.Name = "txmMonto" Then

                If nm5Cambio.Visible = True Then
                    fnTotalDolares()
                Else
                    fnTotal()
                End If

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
            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If

        Catch ex As Exception
            'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If e.KeyValue = Keys.Delete Then
            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If

        End If
    End Sub

    Private Sub nm5Cambio_ValueChanged(sender As Object, e As EventArgs) Handles nm5Cambio.ValueChanged
        tipoCambio = nm5Cambio.Value
        If nm5Cambio.Visible = True And nm5Cambio.Value > 1 Then
            If nm5Cambio.Visible = True Then
                fnTotalDolares()
            Else
                fnTotal()
            End If
        End If
    End Sub


    'GUARDAR
    Private Sub fnGuardar_Click() Handles Me.panel0
        Try
            fnGuardar()
        Catch ex As Exception

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

        If nm5Cambio.Visible = True Then
            If nm5Cambio.Value <= 1 Then
                alerta.contenido = "Revise el Tipo de Cambio"
                alerta.fnErrorContenido()
                Return True
                Exit Function
            End If
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

        Dim total

        If nm5Cambio.Visible Then
            total = CType(Replace(Me.lblTotal.Text, "$", ""), Double)
        Else
            total = CType(Replace(Me.lblTotal.Text, "Q", ""), Double)
        End If



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

    Private Sub rbtFacturaUnica_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFacturaUnica.CheckedChanged
        Try

            If Me.cmbProveedor.SelectedValue = 0 And Me.grdProductos.Rows.Count = 1 Then
                RadMessageBox.Show("Debe Seleccionar Un Proveedor Antes!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Exit Sub
            End If

            If rbtFacturaUnica.Checked = True Then
                Me.lblDocumento.Visible = False
                Me.cmbDocumento.Visible = False
                Me.lblPagos.Visible = False
                Me.lblPago.Visible = False
                Me.lblSal.Visible = False
                Me.lblSaldos.Visible = False
                Me.lblTotalFacturas.Visible = False
                Me.txtTotalFacturas.Visible = False
                Me.lblFacturas.Visible = False
                Me.txtFacturas.Visible = False
                Me.btnFacturas.Visible = False
                Me.lblNumeroFacturas.Enabled = False
                Me.txtNumeroFacturas.Enabled = False
                Me.lblPreformaD.Visible = False
                Me.lblInvoiceD.Visible = False
                Me.txtPreformaD.Visible = False
                Me.txtInvoiceD.Visible = False
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
                Me.lblPreformaD.Visible = False
                Me.lblInvoiceD.Visible = False
                Me.txtPreformaD.Visible = False
                Me.txtInvoiceD.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFacturas_Click(sender As Object, e As EventArgs) Handles btnFacturas.Click
        Try

            mdlPublicVars.superSearchLista3 = Nothing

            listaEntradas = New List(Of Tuple(Of Integer, String, Decimal))

            Dim form As New frmFacturasElegir
            form.listaEntradas = listaEntradas
            form.Text = "Facturas Proveedor"
            form.StartPosition = FormStartPosition.CenterScreen
            form.WindowState = FormWindowState.Normal
            form.idproveedor = Me.cmbProveedor.SelectedValue
            form.ShowDialog()
            form.Dispose()
            listaEntradas = mdlPublicVars.superSearchLista3

            txtNumeroFacturas.Text = CStr(listaEntradas.Count)
            txtFacturas.Text = ""
            Dim total As Decimal = 0

            For Each empleado As Tuple(Of Integer, String, Decimal) In listaEntradas
                txtFacturas.Text += empleado.Item2 & ", "
                total += empleado.Item3
                txtTotalFacturas.Text = Format(total, formatoMoneda)
            Next

        Catch

        End Try
    End Sub

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
        Dim codproveedor As Integer

        'seleccionar el codigo de cliente.
        codproveedor = CType(cmbProveedor.SelectedValue, Integer)

        If codproveedor = 0 Then
            If RadMessageBox.Show("Desea Guardar el Pago Sin Cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                Exit Sub
            End If
        End If

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
        Dim observacionpago As String

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
                                observacionpago = Me.grdProductos.Rows(index).Cells("observacion").Value

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
                                    PagoModificado.afavor = monto
                                    PagoModificado.consumido = 0
                                    PagoModificado.tipoCambio = Convert.ToDecimal(nm5Cambio.Value).ToString
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
                                    If bitProveedor = True And codproveedor > 0 Then
                                        PagoModificado.proveedor = codproveedor
                                        PagoModificado.bitEntrada = False
                                        PagoModificado.bitSalida = True

                                        'agregar configuracion de entrada
                                    ElseIf bitEntrada = True And codproveedor > 0 Then
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
                                    pago.tipoCambio = Convert.ToDecimal(nm5Cambio.Value).ToString
                                    pago.tipoPago = tipoPago
                                    pago.empresa = mdlPublicVars.idEmpresa
                                    pago.usuario = mdlPublicVars.idUsuario
                                    pago.estadocuenta = True
                                    If Me.cmbDocumento.SelectedValue > 0 Then
                                        pago.observacion = observacion
                                    ElseIf Me.cmbDocumento.Visible = False Then
                                        pago.observacion = Me.txtFacturas.Text
                                    End If
                                    pago.observacionpago = observacionpago
                                    pago.descripcion = pagoTipo.nombre
                                    pago.bitRechazado = False
                                    pago.consumido = 0
                                    pago.afavor = monto
                                    pago.codutilizado = 0
                                    pago.docpreforma = Me.txtPreformaD.Text
                                    pago.docinvoice = Me.txtInvoiceD.Text

                                    If Me.cmbDocumento.Visible = True Then
                                        pago.documentofactura = Me.cmbDocumento.Text
                                    End If

                                    pago.docboletadeposito = Me.txtdocumentoboleta.Text

                                    If Me.cmbDocumento.Visible = True Then

                                        pago.identradapago = CInt(Me.cmbDocumento.SelectedValue())

                                    End If

                                    If pagoTipo.cuenta IsNot Nothing Then
                                        pago.cuenta = pagoTipo.cuenta
                                        pago.numeroCuenta = pagoTipo.tblBanco_Cuenta.numeroCuenta
                                    End If

                                    If bitProveedor = True And codproveedor > 0 Then
                                        pago.proveedor = codproveedor
                                        pago.bitEntrada = False
                                        pago.bitSalida = True
                                    ElseIf bitEntrada = True And codproveedor > 0 Then
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
                                    'no Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigoES Select x).FirstOrDefault

                                    'noIf pagoTipo.calendarizada = True Then
                                    'nofactura.pagosTransito += pago.monto
                                    'no  Else
                                    'no   If factura.contado = True Then
                                    'Realizamos las transacciones correspondientes
                                    'nofactura.saldo -= pago.monto
                                    'nofactura.pagos += pago.monto
                                    'noIf factura.saldo = 0 Then
                                    'nofactura.pagado = 1
                                    'noEnd If
                                    'no conexion.SaveChanges()
                                    'noElse
                                    'noDim montoPagar = pago.monto

                                    'no Dim listaSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                    'no                                       Where x.IdFactura = factura.IdFactura Select x).ToList
                                    'noDim salida As tblSalida
                                    'noFor Each salida In listaSalidas
                                    'noDim ctaCobrar As tblCtaCobrar = (From x In conexion.tblCtaCobrars
                                    'no                              Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                    'noIf montoPagar > ctaCobrar.saldo Then
                                    'nomontoPagar -= ctaCobrar.saldo
                                    'noctaCobrar.saldo = 0
                                    'noctaCobrar.cancelada = 1
                                    'noElse
                                    'no ctaCobrar.saldo -= montoPagar
                                    'nomontoPagar = 0
                                    'noEnd If
                                    'no   Next
                                    'noconexion.SaveChanges()
                                    'noEnd If
                                    'noEnd If

                                ElseIf bitProveedor = True And cmbProveedor.SelectedValue > 0 Then
                                    Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                                    'noIf proveedor.procedencia = 1 Then
                                    If pagoTipo.calendarizada = True Then
                                        proveedor.pagosTransito += pago.monto
                                    Else
                                        Dim montoPagar = pago.monto
                                        proveedor.pagos += pago.monto
                                        proveedor.saldoActual -= pago.monto
                                        Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars
                                                                                     Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
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

                                    ''Descuento de la tabla de entradas para las cuentas por pagar Macora

                                    Dim filas As Integer = Me.grdProductos.Rows.Count - 1
                                    Dim pagoprov As Double
                                    Dim proveedorpago As Integer = Me.cmbProveedor.SelectedValue

                                    For fil As Integer = 0 To filas
                                        Try
                                            pagoprov = Me.grdProductos.Rows(fil).Cells("txmMonto").Value
                                        Catch ex As Exception
                                            pagoprov = 0
                                        End Try

                                        If pagoprov > 0 And cmbDocumento.SelectedValue = 0 Then
                                            'noWhile pagoprov > 0

                                            'noDim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = proveedorpago And x.saldo > 0 And x.anulado = False Order By x.fechaRegistro Select x).Take(1).FirstOrDefault

                                            'noIf entradaspendientes Is Nothing Then
                                            'noExit While
                                            'noEnd If

                                            'no    If pagoprov > entradaspendientes.saldo Then

                                            'nopagoprov -= entradaspendientes.saldo
                                            'noentradaspendientes.saldo = 0
                                            'noentradaspendientes.pagos = entradaspendientes.total

                                            'noElseIf pagoprov <= entradaspendientes.saldo Then

                                            'noentradaspendientes.saldo -= pagoprov
                                            'noentradaspendientes.pagos += pagoprov
                                            'nopagoprov = 0

                                            'noEnd If

                                            'noconexion.SaveChanges()

                                            'noEnd While
                                        ElseIf pagoprov > 0 And cmbDocumento.SelectedValue > 0 Then
                                            If pagoTipo.calendarizada = False Then ' agregado
                                                While pagoprov > 0

                                                    Dim docrelacion As Integer = Me.cmbDocumento.SelectedValue

                                                    Dim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = proveedorpago And x.saldo > 0 And x.anulado = False And x.idEntrada = docrelacion Select x).FirstOrDefault

                                                    entradaspendientes.saldo -= pagoprov
                                                    entradaspendientes.pagos += pagoprov
                                                    pagoprov = 0

                                                End While
                                            End If ' agregado 
                                            'no ElseIf pagoprov > 0 And cmbDocumento.Visible = False Then

                                            'no For Each empleado As Tuple(Of Integer, String, Decimal) In listaEntradas
                                            ''txtFacturas.Text += empleado.Item2 & ", "
                                            ''total += empleado.Item3
                                            ''txtTotalFacturas.Text = Format(total, formatoMoneda)

                                            'no Dim ent As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = empleado.Item1 Select x).FirstOrDefault

                                            'no ent.saldo -= empleado.Item3
                                            'noent.pagos += empleado.Item3

                                            'noconexion.SaveChanges()

                                            'no  Next

                                        End If

                                    Next



                                    ''Finalizacion del descuento de saldos para las cuentas por pagar de macora

                                    'guardar los cambios
                                    conexion.SaveChanges()

                                    'Modificaciones
                                    ' Sis es proveedore Extranjero e
                                    'no ElseIf proveedor.procedencia = 2 Then

                                    'noIf pagoTipo.calendarizada = True Then

                                    ''proveedor.pagosDolar += monto
                                    'noproveedor.pagosTransitoDolar += monto
                                    ''proveedor.saldoDolar -= monto
                                    ''proveedor.pagos += monto
                                    'noproveedor.pagosTransito += monto
                                    ''proveedor.saldoActual -= monto


                                    'noIf Me.cmbDocumento.SelectedValue > 0 Then
                                    'noTry

                                    'noDim identrada As Integer = Me.cmbDocumento.SelectedValue
                                    'noDim idproveedor As Integer = Me.cmbProveedor.SelectedValue

                                    'noDim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = idproveedor And x.saldo > 0 And x.anulado = False And x.idEntrada = identrada Select x).FirstOrDefault

                                    ''entradaspendientes.saldo -= monto
                                    ''entradaspendientes.pagos += monto
                                    'nomonto = 0

                                    'noconexion.SaveChanges()

                                    'noCatch ex As Exception

                                    'noEnd Try
                                    'no         End If



                                    'no    proveedor.saldoActual -= monto

                                    'noElse
                                    'no Dim montoPagar = monto

                                    'no                                    If proveedor.pagosDolar Is Nothing Then
                                    'noproveedor.pagosDolar = monto
                                    'noproveedor.saldoDolar = monto
                                    'noElse
                                    'no proveedor.pagosDolar += monto
                                    'noproveedor.saldoDolar -= monto
                                    'noEnd If
                                    'noproveedor.saldoActual -= monto * Convert.ToDecimal(nm5Cambio.Value).ToString


                                    'noIf Me.cmbDocumento.SelectedValue > 0 Then
                                    'noTry

                                    'noDim entradaspendientes As tblEntrada = (From x In conexion.tblEntradas Where x.idProveedor = CInt(Me.cmbProveedor.SelectedValue) And x.saldo > 0 And x.anulado = False And x.idEntrada = CInt(Me.cmbDocumento.SelectedValue) Select x).FirstOrDefault

                                    'noentradaspendientes.saldo -= monto
                                    'noentradaspendientes.pagos += monto
                                    'nomonto = 0

                                    'noCatch ex As Exception

                                    'noEnd Try
                                    'noEnd If


                                    'noDim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 And x.anulado = False Select x Order By x.fecha Ascending).ToList
                                    'noDim ctaPagar As tblCtaPagar

                                    'noFor Each ctaPagar In listaCtaPagar

                                    'no If montoPagar > ctaPagar.saldo Then
                                    'nomontoPagar -= ctaPagar.saldo
                                    'no'noctaPagar.pagado = ctaPagar.monto
                                    'noctaPagar.saldo = 0
                                    'noctaPagar.cancelada = 1
                                    'noElse
                                    'no ctaPagar.saldo -= montoPagar
                                    'noctaPagar.pagado += montoPagar
                                    'nomontoPagar = 0
                                    'noEnd If
                                    'noNext
                                    'noEnd If

                                    'noconexion.SaveChanges()    ' verificar si va aqui. inicialmente estaba aqui
                                    'noEnd If

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

                    For Each entrada As Tuple(Of Integer, String, Decimal) In listaEntradas

                        If tipoPago > 0 Then
                            Dim pago As New tblCaja

                            pago.tipoPago = tipoPago
                            pago.empresa = mdlPublicVars.idEmpresa
                            pago.fecha = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                            pago.fechaTransaccion = fecha
                            pago.confirmado = False
                            pago.transito = 0
                            pago.monto = entrada.Item3 * Convert.ToDecimal(nm5Cambio.Value)
                            pago.documento = documento
                            pago.usuario = mdlPublicVars.idUsuario
                            pago.anulado = 0
                            pago.identradapago = entrada.Item1
                            pago.proveedor = codproveedor
                            pago.estadocuenta = True
                            If Me.cmbDocumento.Visible = False Then
                                pago.observacion = Me.txtFacturas.Text
                            Else
                                pago.observacion = observacion
                            End If
                            pago.observacionpago = observacionpago
                            pago.descripcion = pagoTipo.nombre
                            pago.bitRechazado = False
                            pago.bitEntrada = 0
                            pago.bitSalida = 1
                            pago.tipoCambio = Convert.ToDecimal(nm5Cambio.Value).ToString
                            pago.fecharegistro = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                            pago.fechaFiltro = dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                            pago.consumido = 0
                            pago.afavor = 0
                            pago.codutilizado = False
                            pago.docboletadeposito = txtdocumentoboleta.Text
                            pago.docpreforma = Me.txtPreformaD.Text
                            pago.docinvoice = Me.txtInvoiceD.Text

                            conexion.AddTotblCajas(pago)
                            conexion.SaveChanges()
                            codpago = pago.codigo

                            ''Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codproveedor Select x).FirstOrDefault

                            ''proveedor.saldoActual -= entrada.Item3
                            ''proveedor.pagos += entrada.Item3

                            ''conexion.SaveChanges()
                        End If

                        Dim ent As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = entrada.Item1 Select x).FirstOrDefault

                        Dim totalpago As Decimal = entrada.Item3

                        If totalpago > 0 And ent.saldo > 0 Then
                            If totalpago = ent.saldo Then

                                ent.saldo = 0
                                ent.pagos = ent.total

                            ElseIf totalpago < ent.saldo Then

                                ent.saldo -= totalpago
                                ent.pagos += totalpago
                                totalpago = 0

                            End If

                            conexion.SaveChanges()

                        Else
                            Exit For
                        End If

                    Next
                    conn.Close()
                End Using
            Catch ex As Exception

            End Try
        End If

        If success = True Then

            If RadMessageBox.Show("Desea realizar nuevo pago", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                bitModificar = False
                fnLlenarCombos()
                Me.dtpFechaInicio.Focus()
                If nm5Cambio.Visible = True Then
                    fnTotalDolares()
                Else
                    fnTotal()
                End If


            Else
                bitCliente = False   'agregado 
                bitProveedor = False 'agregado
                Me.Close()
            End If
        End If

    End Sub

    Private Sub fnSalir() Handles Me.panel4
        Me.Close()
    End Sub

End Class

