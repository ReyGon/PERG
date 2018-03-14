<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoVentaPequenia
    Inherits laFuente.FrmBaseEspeciales

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoVentaPequenia))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1cuenta = New System.Windows.Forms.Panel()
        Me.lbl1cuenta = New System.Windows.Forms.Label()
        Me.pbx1cuenta = New System.Windows.Forms.PictureBox()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTipoPago = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rgbInfoVenta = New Telerik.WinControls.UI.RadGroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFechaCobro = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.nm2SaldoFavor = New System.Windows.Forms.NumericUpDown()
        Me.nm2TotalPagar = New System.Windows.Forms.NumericUpDown()
        Me.nm2MontoRecibido = New System.Windows.Forms.NumericUpDown()
        Me.chkSaldoFavor = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1cuenta.SuspendLayout()
        CType(Me.pbx1cuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInfoVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInfoVenta.SuspendLayout()
        CType(Me.nm2SaldoFavor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2TotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2MontoRecibido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx1cuenta)
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(266, 48)
        Me.pnlBarra.TabIndex = 106
        '
        'pnx1cuenta
        '
        Me.pnx1cuenta.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.pnx1cuenta.BackColor = System.Drawing.Color.Navy
        Me.pnx1cuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1cuenta.Controls.Add(Me.lbl1cuenta)
        Me.pnx1cuenta.Controls.Add(Me.pbx1cuenta)
        Me.pnx1cuenta.Location = New System.Drawing.Point(116, 3)
        Me.pnx1cuenta.Name = "pnx1cuenta"
        Me.pnx1cuenta.Size = New System.Drawing.Size(124, 42)
        Me.pnx1cuenta.TabIndex = 194
        '
        'lbl1cuenta
        '
        Me.lbl1cuenta.AutoSize = True
        Me.lbl1cuenta.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1cuenta.ForeColor = System.Drawing.Color.White
        Me.lbl1cuenta.Location = New System.Drawing.Point(45, 0)
        Me.lbl1cuenta.Name = "lbl1cuenta"
        Me.lbl1cuenta.Size = New System.Drawing.Size(78, 38)
        Me.lbl1cuenta.TabIndex = 66
        Me.lbl1cuenta.Text = "Estado de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cuenta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pbx1cuenta
        '
        Me.pbx1cuenta.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1cuenta.Location = New System.Drawing.Point(9, 2)
        Me.pbx1cuenta.Name = "pbx1cuenta"
        Me.pbx1cuenta.Size = New System.Drawing.Size(40, 33)
        Me.pbx1cuenta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1cuenta.TabIndex = 65
        Me.pbx1cuenta.TabStop = False
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(3, 3)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 42)
        Me.pnx0Salir.TabIndex = 177
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(50, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 66
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(9, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 65
        Me.pbx0Salir.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(68, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 25)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Tipo de Pago :"
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoPago.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.Location = New System.Drawing.Point(214, 94)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(462, 28)
        Me.cmbTipoPago.TabIndex = 112
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(75, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 25)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Total a Pagar:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(25, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 25)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Monto Recibido Q.:"
        '
        'rgbInfoVenta
        '
        Me.rgbInfoVenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInfoVenta.Controls.Add(Me.txtFactura)
        Me.rgbInfoVenta.Controls.Add(Me.Label7)
        Me.rgbInfoVenta.Controls.Add(Me.Button1)
        Me.rgbInfoVenta.Controls.Add(Me.Label10)
        Me.rgbInfoVenta.Controls.Add(Me.dtpFechaCobro)
        Me.rgbInfoVenta.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbInfoVenta.Controls.Add(Me.Label3)
        Me.rgbInfoVenta.Controls.Add(Me.Label8)
        Me.rgbInfoVenta.Controls.Add(Me.cmbCliente)
        Me.rgbInfoVenta.Controls.Add(Me.nm2SaldoFavor)
        Me.rgbInfoVenta.Controls.Add(Me.nm2TotalPagar)
        Me.rgbInfoVenta.Controls.Add(Me.nm2MontoRecibido)
        Me.rgbInfoVenta.Controls.Add(Me.chkSaldoFavor)
        Me.rgbInfoVenta.Controls.Add(Me.Label9)
        Me.rgbInfoVenta.Controls.Add(Me.txtDocumento)
        Me.rgbInfoVenta.Controls.Add(Me.Label2)
        Me.rgbInfoVenta.Controls.Add(Me.btnAceptar)
        Me.rgbInfoVenta.Controls.Add(Me.Label6)
        Me.rgbInfoVenta.Controls.Add(Me.Label4)
        Me.rgbInfoVenta.Controls.Add(Me.cmbTipoPago)
        Me.rgbInfoVenta.Controls.Add(Me.Label5)
        Me.rgbInfoVenta.FooterImageIndex = -1
        Me.rgbInfoVenta.FooterImageKey = ""
        Me.rgbInfoVenta.HeaderImageIndex = -1
        Me.rgbInfoVenta.HeaderImageKey = ""
        Me.rgbInfoVenta.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInfoVenta.HeaderText = "INFORMACION VENTA"
        Me.rgbInfoVenta.Location = New System.Drawing.Point(12, 54)
        Me.rgbInfoVenta.Name = "rgbInfoVenta"
        Me.rgbInfoVenta.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInfoVenta.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInfoVenta.Size = New System.Drawing.Size(695, 445)
        Me.rgbInfoVenta.TabIndex = 119
        Me.rgbInfoVenta.Text = "INFORMACION VENTA"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.SteelBlue
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = Global.laFuente.My.Resources.Resources.reservar_Blanco
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(13, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 56)
        Me.Button1.TabIndex = 194
        Me.Button1.Text = "Resolucio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Factura" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(48, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 25)
        Me.Label10.TabIndex = 193
        Me.Label10.Text = "Fecha de Cobro :"
        '
        'dtpFechaCobro
        '
        Me.dtpFechaCobro.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCobro.Location = New System.Drawing.Point(214, 128)
        Me.dtpFechaCobro.Name = "dtpFechaCobro"
        Me.dtpFechaCobro.Size = New System.Drawing.Size(181, 25)
        Me.dtpFechaCobro.TabIndex = 192
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(214, 29)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(133, 25)
        Me.dtpFechaRegistro.TabIndex = 191
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(136, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 25)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = "Fecha :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(125, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 25)
        Me.Label8.TabIndex = 188
        Me.Label8.Text = "Cliente :"
        '
        'cmbCliente
        '
        Me.cmbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(214, 60)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(462, 28)
        Me.cmbCliente.TabIndex = 189
        '
        'nm2SaldoFavor
        '
        Me.nm2SaldoFavor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nm2SaldoFavor.DecimalPlaces = 2
        Me.nm2SaldoFavor.Enabled = False
        Me.nm2SaldoFavor.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm2SaldoFavor.Location = New System.Drawing.Point(214, 197)
        Me.nm2SaldoFavor.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2SaldoFavor.Name = "nm2SaldoFavor"
        Me.nm2SaldoFavor.Size = New System.Drawing.Size(310, 33)
        Me.nm2SaldoFavor.TabIndex = 187
        Me.nm2SaldoFavor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm2TotalPagar
        '
        Me.nm2TotalPagar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nm2TotalPagar.DecimalPlaces = 2
        Me.nm2TotalPagar.Enabled = False
        Me.nm2TotalPagar.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm2TotalPagar.Location = New System.Drawing.Point(214, 237)
        Me.nm2TotalPagar.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2TotalPagar.Name = "nm2TotalPagar"
        Me.nm2TotalPagar.Size = New System.Drawing.Size(466, 33)
        Me.nm2TotalPagar.TabIndex = 185
        Me.nm2TotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm2MontoRecibido
        '
        Me.nm2MontoRecibido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nm2MontoRecibido.DecimalPlaces = 2
        Me.nm2MontoRecibido.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm2MontoRecibido.Location = New System.Drawing.Point(214, 276)
        Me.nm2MontoRecibido.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2MontoRecibido.Name = "nm2MontoRecibido"
        Me.nm2MontoRecibido.Size = New System.Drawing.Size(466, 33)
        Me.nm2MontoRecibido.TabIndex = 184
        Me.nm2MontoRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkSaldoFavor
        '
        Me.chkSaldoFavor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSaldoFavor.AutoSize = True
        Me.chkSaldoFavor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSaldoFavor.Location = New System.Drawing.Point(532, 204)
        Me.chkSaldoFavor.Name = "chkSaldoFavor"
        Me.chkSaldoFavor.Size = New System.Drawing.Size(150, 21)
        Me.chkSaldoFavor.TabIndex = 183
        Me.chkSaldoFavor.Text = "Utilizar saldo a favor"
        Me.chkSaldoFavor.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(69, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 25)
        Me.Label9.TabIndex = 181
        Me.Label9.Text = "Saldo a favor :"
        '
        'txtDocumento
        '
        Me.txtDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDocumento.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(214, 162)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(462, 27)
        Me.txtDocumento.TabIndex = 180
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(81, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 25)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Documento :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Image = Global.laFuente.My.Resources.Resources.aceptarBlanco
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(561, 352)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(115, 56)
        Me.btnAceptar.TabIndex = 176
        Me.btnAceptar.Text = "Guardar"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(353, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 25)
        Me.Label7.TabIndex = 195
        Me.Label7.Text = "Factura :"
        '
        'txtFactura
        '
        Me.txtFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFactura.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(447, 27)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(229, 27)
        Me.txtFactura.TabIndex = 196
        '
        'frmPagoVentaPequenia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(718, 511)
        Me.Controls.Add(Me.rgbInfoVenta)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPagoVentaPequenia"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInfoVenta, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1cuenta.ResumeLayout(False)
        Me.pnx1cuenta.PerformLayout()
        CType(Me.pbx1cuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInfoVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInfoVenta.ResumeLayout(False)
        Me.rgbInfoVenta.PerformLayout()
        CType(Me.nm2SaldoFavor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2TotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2MontoRecibido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rgbInfoVenta As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkSaldoFavor As System.Windows.Forms.CheckBox
    Friend WithEvents nm2TotalPagar As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm2MontoRecibido As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm2SaldoFavor As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaCobro As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnx1cuenta As System.Windows.Forms.Panel
    Friend WithEvents lbl1cuenta As System.Windows.Forms.Label
    Friend WithEvents pbx1cuenta As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox

End Class
