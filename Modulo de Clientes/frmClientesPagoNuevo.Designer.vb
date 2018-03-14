<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesPagoNuevo
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim FilterDescriptor1 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesPagoNuevo))
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rgbDetalle = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.lblSaldoActual = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pbGuardar = New System.Windows.Forms.PictureBox()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.pbNuevo = New System.Windows.Forms.PictureBox()
        Me.BreezeExtendedTheme1 = New Telerik.WinControls.Themes.BreezeExtendedTheme()
        Me.Office2010Theme1 = New Telerik.WinControls.Themes.Office2010Theme()
        Me.VistaTheme1 = New Telerik.WinControls.Themes.VistaTheme()
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.HighContrastBlackTheme1 = New Telerik.WinControls.Themes.HighContrastBlackTheme()
        Me.DesertTheme1 = New Telerik.WinControls.Themes.DesertTheme()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.rgbSaldo = New Telerik.WinControls.UI.RadGroupBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDetalle.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        CType(Me.pbGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rgbSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbSaldo.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.lista_gris
        Me.PictureBox5.Location = New System.Drawing.Point(14, 206)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 100
        Me.PictureBox5.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Gray
        Me.Label7.Location = New System.Drawing.Point(55, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 25)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Detalle de pago"
        '
        'rgbDetalle
        '
        Me.rgbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDetalle.Controls.Add(Me.grdProductos)
        Me.rgbDetalle.FooterImageIndex = -1
        Me.rgbDetalle.FooterImageKey = ""
        Me.rgbDetalle.HeaderImageIndex = -1
        Me.rgbDetalle.HeaderImageKey = ""
        Me.rgbDetalle.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDetalle.HeaderText = ""
        Me.rgbDetalle.Location = New System.Drawing.Point(3, 226)
        Me.rgbDetalle.Name = "rgbDetalle"
        Me.rgbDetalle.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDetalle.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDetalle.Size = New System.Drawing.Size(862, 296)
        Me.rgbDetalle.TabIndex = 96
        '
        'grdProductos
        '
        Me.grdProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(6, 23)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.HeaderText = "codigoTipoPago"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "codigoTipoPago"
        GridViewTextBoxColumn2.FormatString = ""
        GridViewTextBoxColumn2.HeaderText = "TipoPago"
        GridViewTextBoxColumn2.Name = "txbTipoPago"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 250
        GridViewTextBoxColumn3.FormatString = ""
        GridViewTextBoxColumn3.HeaderText = ""
        GridViewTextBoxColumn3.Name = "Imagen"
        GridViewTextBoxColumn3.ReadOnly = True
        GridViewTextBoxColumn3.Width = 30
        GridViewTextBoxColumn4.FormatString = ""
        GridViewTextBoxColumn4.HeaderText = "Documento"
        GridViewTextBoxColumn4.Name = "txmDocumento"
        GridViewTextBoxColumn4.Width = 350
        GridViewTextBoxColumn5.FormatString = ""
        GridViewTextBoxColumn5.HeaderText = "Monto"
        GridViewTextBoxColumn5.Name = "txmMonto"
        GridViewTextBoxColumn5.Width = 100
        GridViewTextBoxColumn6.FormatString = ""
        GridViewTextBoxColumn6.HeaderText = "Fecha"
        GridViewTextBoxColumn6.Name = "txmFecha"
        GridViewTextBoxColumn6.Width = 100
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        FilterDescriptor1.PropertyName = Nothing
        Me.grdProductos.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor1})
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(843, 260)
        Me.grdProductos.TabIndex = 65
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblSaldoActual.Location = New System.Drawing.Point(184, 75)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(35, 41)
        Me.lblSaldoActual.TabIndex = 104
        Me.lblSaldoActual.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(49, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 25)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Saldo Actual :"
        '
        'lblSaldo
        '
        Me.lblSaldo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblSaldo.Location = New System.Drawing.Point(184, 8)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(34, 41)
        Me.lblSaldo.TabIndex = 102
        Me.lblSaldo.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(109, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 25)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Saldo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(112, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 25)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Total :"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblTotal.Location = New System.Drawing.Point(184, 41)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(34, 41)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "0"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.info_gris
        Me.PictureBox4.Location = New System.Drawing.Point(20, 63)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(56, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 101
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(73, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 25)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Informacion de Pago"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(97, 27)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(103, 23)
        Me.dtpFechaInicio.TabIndex = 0
        '
        'cmbCliente
        '
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(97, 56)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(282, 23)
        Me.cmbCliente.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(44, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(48, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha :"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.lblGuardar)
        Me.pnlBarra.Controls.Add(Me.pbGuardar)
        Me.pnlBarra.Controls.Add(Me.lblNuevo)
        Me.pnlBarra.Controls.Add(Me.pbNuevo)
        Me.pnlBarra.Location = New System.Drawing.Point(348, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(524, 51)
        Me.pnlBarra.TabIndex = 101
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.White
        Me.lblGuardar.Location = New System.Drawing.Point(146, 18)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(64, 19)
        Me.lblGuardar.TabIndex = 76
        Me.lblGuardar.Text = "Guardar"
        '
        'pbGuardar
        '
        Me.pbGuardar.Image = CType(resources.GetObject("pbGuardar.Image"), System.Drawing.Image)
        Me.pbGuardar.Location = New System.Drawing.Point(106, 11)
        Me.pbGuardar.Name = "pbGuardar"
        Me.pbGuardar.Size = New System.Drawing.Size(40, 33)
        Me.pbGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbGuardar.TabIndex = 75
        Me.pbGuardar.TabStop = False
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevo.ForeColor = System.Drawing.Color.White
        Me.lblNuevo.Location = New System.Drawing.Point(41, 16)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(53, 19)
        Me.lblNuevo.TabIndex = 64
        Me.lblNuevo.Text = "Nuevo"
        '
        'pbNuevo
        '
        Me.pbNuevo.Image = CType(resources.GetObject("pbNuevo.Image"), System.Drawing.Image)
        Me.pbNuevo.Location = New System.Drawing.Point(0, 9)
        Me.pbNuevo.Name = "pbNuevo"
        Me.pbNuevo.Size = New System.Drawing.Size(40, 33)
        Me.pbNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbNuevo.TabIndex = 63
        Me.pbNuevo.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.dinero_gris
        Me.PictureBox3.Location = New System.Drawing.Point(528, 63)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(60, 44)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 105
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(584, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 25)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Saldo"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.cmbCliente)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.dtpFechaInicio)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(6, 88)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(488, 95)
        Me.rgbInformacion.TabIndex = 97
        '
        'rgbSaldo
        '
        Me.rgbSaldo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbSaldo.Controls.Add(Me.lblSaldoActual)
        Me.rgbSaldo.Controls.Add(Me.Label5)
        Me.rgbSaldo.Controls.Add(Me.Label6)
        Me.rgbSaldo.Controls.Add(Me.Label2)
        Me.rgbSaldo.Controls.Add(Me.lblTotal)
        Me.rgbSaldo.Controls.Add(Me.lblSaldo)
        Me.rgbSaldo.FooterImageIndex = -1
        Me.rgbSaldo.FooterImageKey = ""
        Me.rgbSaldo.HeaderImageIndex = -1
        Me.rgbSaldo.HeaderImageKey = ""
        Me.rgbSaldo.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbSaldo.HeaderText = ""
        Me.rgbSaldo.Location = New System.Drawing.Point(528, 88)
        Me.rgbSaldo.Name = "rgbSaldo"
        Me.rgbSaldo.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbSaldo.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbSaldo.Size = New System.Drawing.Size(331, 121)
        Me.rgbSaldo.TabIndex = 98
        '
        'frmClientesPagoNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(871, 532)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rgbDetalle)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.rgbSaldo)
        Me.Name = "frmClientesPagoNuevo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbSaldo, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.rgbDetalle, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDetalle.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        CType(Me.pbGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rgbSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbSaldo.ResumeLayout(False)
        Me.rgbSaldo.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rgbDetalle As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents pbGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents pbNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BreezeExtendedTheme1 As Telerik.WinControls.Themes.BreezeExtendedTheme
    Friend WithEvents Office2010Theme1 As Telerik.WinControls.Themes.Office2010Theme
    Friend WithEvents VistaTheme1 As Telerik.WinControls.Themes.VistaTheme
    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents HighContrastBlackTheme1 As Telerik.WinControls.Themes.HighContrastBlackTheme
    Friend WithEvents DesertTheme1 As Telerik.WinControls.Themes.DesertTheme
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoActual As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rgbSaldo As Telerik.WinControls.UI.RadGroupBox

End Class
