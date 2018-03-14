<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevolucionTransporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevolucionTransporte))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Guardar = New System.Windows.Forms.Panel()
        Me.pbx1Guardar = New System.Windows.Forms.PictureBox()
        Me.lbl1Guardar = New System.Windows.Forms.Label()
        Me.pnx0Nuevo = New System.Windows.Forms.Panel()
        Me.lbl0Nuevo = New System.Windows.Forms.Label()
        Me.pbx0Nuevo = New System.Windows.Forms.PictureBox()
        Me.pnx2Salir = New System.Windows.Forms.Panel()
        Me.pbx2Salir = New System.Windows.Forms.PictureBox()
        Me.lbl2Salir = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbEnvioTransporte = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNumeroViaje = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbInventario = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rgbClienteProductos = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdClientesProductos = New Telerik.WinControls.UI.RadGridView()
        Me.rgbPordilleros = New Telerik.WinControls.UI.RadGroupBox()
        Me.dspTotal = New Owf.Controls.DigitalDisplayControl()
        Me.cmbPedidoCliente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Guardar.SuspendLayout()
        CType(Me.pbx1Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Nuevo.SuspendLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx2Salir.SuspendLayout()
        CType(Me.pbx2Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rgbClienteProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbClienteProductos.SuspendLayout()
        CType(Me.grdClientesProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdClientesProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbPordilleros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbPordilleros.SuspendLayout()
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
        Me.pnlBarra.Controls.Add(Me.pnx1Guardar)
        Me.pnlBarra.Controls.Add(Me.pnx0Nuevo)
        Me.pnlBarra.Controls.Add(Me.pnx2Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(777, 48)
        Me.pnlBarra.TabIndex = 191
        '
        'pnx1Guardar
        '
        Me.pnx1Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx1Guardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Guardar.Controls.Add(Me.pbx1Guardar)
        Me.pnx1Guardar.Controls.Add(Me.lbl1Guardar)
        Me.pnx1Guardar.Location = New System.Drawing.Point(540, 3)
        Me.pnx1Guardar.Name = "pnx1Guardar"
        Me.pnx1Guardar.Size = New System.Drawing.Size(113, 40)
        Me.pnx1Guardar.TabIndex = 92
        '
        'pbx1Guardar
        '
        Me.pbx1Guardar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx1Guardar.Location = New System.Drawing.Point(1, 2)
        Me.pbx1Guardar.Name = "pbx1Guardar"
        Me.pbx1Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Guardar.TabIndex = 69
        Me.pbx1Guardar.TabStop = False
        '
        'lbl1Guardar
        '
        Me.lbl1Guardar.AutoSize = True
        Me.lbl1Guardar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl1Guardar.Location = New System.Drawing.Point(40, 11)
        Me.lbl1Guardar.Name = "lbl1Guardar"
        Me.lbl1Guardar.Size = New System.Drawing.Size(57, 17)
        Me.lbl1Guardar.TabIndex = 70
        Me.lbl1Guardar.Text = "Guardar"
        '
        'pnx0Nuevo
        '
        Me.pnx0Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Nuevo.BackColor = System.Drawing.Color.Navy
        Me.pnx0Nuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Nuevo.Controls.Add(Me.lbl0Nuevo)
        Me.pnx0Nuevo.Controls.Add(Me.pbx0Nuevo)
        Me.pnx0Nuevo.Location = New System.Drawing.Point(427, 3)
        Me.pnx0Nuevo.Name = "pnx0Nuevo"
        Me.pnx0Nuevo.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Nuevo.TabIndex = 91
        '
        'lbl0Nuevo
        '
        Me.lbl0Nuevo.AutoSize = True
        Me.lbl0Nuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Nuevo.ForeColor = System.Drawing.Color.White
        Me.lbl0Nuevo.Location = New System.Drawing.Point(50, 9)
        Me.lbl0Nuevo.Name = "lbl0Nuevo"
        Me.lbl0Nuevo.Size = New System.Drawing.Size(53, 19)
        Me.lbl0Nuevo.TabIndex = 66
        Me.lbl0Nuevo.Text = "Nuevo"
        '
        'pbx0Nuevo
        '
        Me.pbx0Nuevo.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.pbx0Nuevo.Location = New System.Drawing.Point(4, 2)
        Me.pbx0Nuevo.Name = "pbx0Nuevo"
        Me.pbx0Nuevo.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Nuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Nuevo.TabIndex = 65
        Me.pbx0Nuevo.TabStop = False
        '
        'pnx2Salir
        '
        Me.pnx2Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx2Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx2Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx2Salir.Controls.Add(Me.pbx2Salir)
        Me.pnx2Salir.Controls.Add(Me.lbl2Salir)
        Me.pnx2Salir.Location = New System.Drawing.Point(659, 3)
        Me.pnx2Salir.Name = "pnx2Salir"
        Me.pnx2Salir.Size = New System.Drawing.Size(106, 40)
        Me.pnx2Salir.TabIndex = 90
        '
        'pbx2Salir
        '
        Me.pbx2Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx2Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx2Salir.Name = "pbx2Salir"
        Me.pbx2Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx2Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Salir.TabIndex = 69
        Me.pbx2Salir.TabStop = False
        '
        'lbl2Salir
        '
        Me.lbl2Salir.AutoSize = True
        Me.lbl2Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Salir.ForeColor = System.Drawing.Color.White
        Me.lbl2Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl2Salir.Name = "lbl2Salir"
        Me.lbl2Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl2Salir.TabIndex = 70
        Me.lbl2Salir.Text = "Salir"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.cmbPedidoCliente)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.cmbEnvioTransporte)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.txtObservacion)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.lblNumeroViaje)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.lblSucursal)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.txtCodigo)
        Me.rgbInformacion.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.Label17)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.Controls.Add(Me.cmbInventario)
        Me.rgbInformacion.Controls.Add(Me.Label19)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = "INFORMACION"
        Me.rgbInformacion.Location = New System.Drawing.Point(2, 54)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(963, 121)
        Me.rgbInformacion.TabIndex = 213
        Me.rgbInformacion.Text = "INFORMACION"
        '
        'cmbEnvioTransporte
        '
        Me.cmbEnvioTransporte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEnvioTransporte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEnvioTransporte.FormattingEnabled = True
        Me.cmbEnvioTransporte.Location = New System.Drawing.Point(115, 47)
        Me.cmbEnvioTransporte.Name = "cmbEnvioTransporte"
        Me.cmbEnvioTransporte.Size = New System.Drawing.Size(440, 21)
        Me.cmbEnvioTransporte.TabIndex = 179
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(10, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Envio Transporte :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(693, 45)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(260, 71)
        Me.txtObservacion.TabIndex = 178
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(613, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 26)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Observacion " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Devolucion :"
        '
        'lblNumeroViaje
        '
        Me.lblNumeroViaje.Location = New System.Drawing.Point(112, 98)
        Me.lblNumeroViaje.Name = "lblNumeroViaje"
        Me.lblNumeroViaje.Size = New System.Drawing.Size(119, 18)
        Me.lblNumeroViaje.TabIndex = 173
        Me.lblNumeroViaje.Text = "Numero Viaje"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(27, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 174
        Me.Label5.Text = "Numero Viaje :"
        '
        'lblSucursal
        '
        Me.lblSucursal.Location = New System.Drawing.Point(343, 98)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(212, 18)
        Me.lblSucursal.TabIndex = 171
        Me.lblSucursal.Text = "Sucursal Salida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(250, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 172
        Me.Label3.Text = "Sucursal Salida :"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(115, 18)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(85, 20)
        Me.txtCodigo.TabIndex = 166
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(341, 20)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(92, 20)
        Me.dtpFechaRegistro.TabIndex = 156
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(297, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 157
        Me.Label17.Text = "Fecha :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(58, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 167
        Me.Label10.Text = "Código :"
        '
        'cmbInventario
        '
        Me.cmbInventario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInventario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInventario.FormattingEnabled = True
        Me.cmbInventario.Location = New System.Drawing.Point(693, 18)
        Me.cmbInventario.Name = "cmbInventario"
        Me.cmbInventario.Size = New System.Drawing.Size(260, 21)
        Me.cmbInventario.TabIndex = 169
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(622, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 170
        Me.Label19.Text = "Inventario :"
        '
        'rgbClienteProductos
        '
        Me.rgbClienteProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbClienteProductos.Controls.Add(Me.grdClientesProductos)
        Me.rgbClienteProductos.FooterImageIndex = -1
        Me.rgbClienteProductos.FooterImageKey = ""
        Me.rgbClienteProductos.HeaderImageIndex = -1
        Me.rgbClienteProductos.HeaderImageKey = ""
        Me.rgbClienteProductos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbClienteProductos.HeaderText = "Clientes y Productos"
        Me.rgbClienteProductos.Location = New System.Drawing.Point(2, 181)
        Me.rgbClienteProductos.Name = "rgbClienteProductos"
        Me.rgbClienteProductos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbClienteProductos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbClienteProductos.Size = New System.Drawing.Size(1241, 348)
        Me.rgbClienteProductos.TabIndex = 214
        Me.rgbClienteProductos.Text = "Clientes y Productos"
        '
        'grdClientesProductos
        '
        Me.grdClientesProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesProductos.Location = New System.Drawing.Point(10, 20)
        '
        'grdClientesProductos
        '
        Me.grdClientesProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdClientesProductos.MasterTemplate.AllowColumnReorder = False
        Me.grdClientesProductos.MasterTemplate.AllowDeleteRow = False
        Me.grdClientesProductos.Name = "grdClientesProductos"
        Me.grdClientesProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        '
        '
        '
        Me.grdClientesProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientesProductos.Size = New System.Drawing.Size(1221, 318)
        Me.grdClientesProductos.TabIndex = 1
        Me.grdClientesProductos.Text = "Clientes Productos"
        Me.grdClientesProductos.ThemeName = "Office2007Black"
        '
        'rgbPordilleros
        '
        Me.rgbPordilleros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbPordilleros.Controls.Add(Me.dspTotal)
        Me.rgbPordilleros.FooterImageIndex = -1
        Me.rgbPordilleros.FooterImageKey = ""
        Me.rgbPordilleros.HeaderImageIndex = -1
        Me.rgbPordilleros.HeaderImageKey = ""
        Me.rgbPordilleros.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbPordilleros.HeaderText = "Total"
        Me.rgbPordilleros.Location = New System.Drawing.Point(971, 54)
        Me.rgbPordilleros.Name = "rgbPordilleros"
        Me.rgbPordilleros.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbPordilleros.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbPordilleros.Size = New System.Drawing.Size(272, 120)
        Me.rgbPordilleros.TabIndex = 215
        Me.rgbPordilleros.Text = "Total"
        '
        'dspTotal
        '
        Me.dspTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dspTotal.BackColor = System.Drawing.Color.Black
        Me.dspTotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.dspTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dspTotal.DigitColor = System.Drawing.Color.Lime
        Me.dspTotal.DigitText = "0.00"
        Me.dspTotal.Location = New System.Drawing.Point(30, 24)
        Me.dspTotal.Name = "dspTotal"
        Me.dspTotal.Size = New System.Drawing.Size(213, 83)
        Me.dspTotal.TabIndex = 21
        '
        'cmbPedidoCliente
        '
        Me.cmbPedidoCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPedidoCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPedidoCliente.FormattingEnabled = True
        Me.cmbPedidoCliente.Location = New System.Drawing.Point(115, 74)
        Me.cmbPedidoCliente.Name = "cmbPedidoCliente"
        Me.cmbPedidoCliente.Size = New System.Drawing.Size(440, 21)
        Me.cmbPedidoCliente.TabIndex = 181
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(21, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Pedido Cliente :"
        '
        'frmDevolucionTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1244, 532)
        Me.Controls.Add(Me.rgbPordilleros)
        Me.Controls.Add(Me.rgbClienteProductos)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDevolucionTransporte"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.rgbClienteProductos, 0)
        Me.Controls.SetChildIndex(Me.rgbPordilleros, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Guardar.ResumeLayout(False)
        Me.pnx1Guardar.PerformLayout()
        CType(Me.pbx1Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Nuevo.ResumeLayout(False)
        Me.pnx0Nuevo.PerformLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx2Salir.ResumeLayout(False)
        Me.pnx2Salir.PerformLayout()
        CType(Me.pbx2Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rgbClienteProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbClienteProductos.ResumeLayout(False)
        CType(Me.grdClientesProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdClientesProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbPordilleros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbPordilleros.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Guardar As System.Windows.Forms.Panel
    Friend WithEvents pbx1Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Guardar As System.Windows.Forms.Label
    Friend WithEvents pnx0Nuevo As System.Windows.Forms.Panel
    Friend WithEvents lbl0Nuevo As System.Windows.Forms.Label
    Friend WithEvents pbx0Nuevo As System.Windows.Forms.PictureBox
    Friend WithEvents pnx2Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx2Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl2Salir As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents cmbInventario As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents rgbClienteProductos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroViaje As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdClientesProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbPordilleros As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dspTotal As Owf.Controls.DigitalDisplayControl
    Public WithEvents cmbEnvioTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents cmbPedidoCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
