<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespachoFacturaAsignar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDespachoFacturaAsignar))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.rgbInfoViaje = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblKMGalon = New System.Windows.Forms.Label()
        Me.txtNoViaje = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cmbTransporte = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblCorrelativo = New System.Windows.Forms.Label()
        Me.lblPordilleros = New System.Windows.Forms.Label()
        Me.lblNoPordilleros = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmbSucursalSalida = New System.Windows.Forms.ComboBox()
        Me.cmbTipoTransporte = New System.Windows.Forms.ComboBox()
        Me.cmbPiloto = New System.Windows.Forms.ComboBox()
        Me.lblPlaca = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdClientes = New Telerik.WinControls.UI.RadGridView()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.rpvContenido = New Telerik.WinControls.UI.RadPageView()
        Me.pgClientes = New Telerik.WinControls.UI.RadPageViewPage()
        Me.pgProductos = New Telerik.WinControls.UI.RadPageViewPage()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInfoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInfoViaje.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdClientes.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpvContenido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpvContenido.SuspendLayout()
        Me.pgClientes.SuspendLayout()
        Me.pgProductos.SuspendLayout()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Guardar)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(636, 48)
        Me.pnlBarra.TabIndex = 107
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(404, 4)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Guardar.TabIndex = 178
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(41, 9)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Guardar.TabIndex = 66
        Me.lbl0Guardar.Text = "Guardar"
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx0Guardar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 65
        Me.pbx0Guardar.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(517, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 177
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(48, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 66
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 65
        Me.pbx1Salir.TabStop = False
        '
        'rgbInfoViaje
        '
        Me.rgbInfoViaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInfoViaje.Controls.Add(Me.lblKMGalon)
        Me.rgbInfoViaje.Controls.Add(Me.txtNoViaje)
        Me.rgbInfoViaje.Controls.Add(Me.Label14)
        Me.rgbInfoViaje.Controls.Add(Me.Label8)
        Me.rgbInfoViaje.Controls.Add(Me.btnAgregar)
        Me.rgbInfoViaje.Controls.Add(Me.cmbTransporte)
        Me.rgbInfoViaje.Controls.Add(Me.Label4)
        Me.rgbInfoViaje.Controls.Add(Me.txtObservacion)
        Me.rgbInfoViaje.Controls.Add(Me.lblCorrelativo)
        Me.rgbInfoViaje.Controls.Add(Me.lblPordilleros)
        Me.rgbInfoViaje.Controls.Add(Me.lblNoPordilleros)
        Me.rgbInfoViaje.Controls.Add(Me.dtpFecha)
        Me.rgbInfoViaje.Controls.Add(Me.cmbSucursalSalida)
        Me.rgbInfoViaje.Controls.Add(Me.cmbTipoTransporte)
        Me.rgbInfoViaje.Controls.Add(Me.cmbPiloto)
        Me.rgbInfoViaje.Controls.Add(Me.lblPlaca)
        Me.rgbInfoViaje.Controls.Add(Me.Label13)
        Me.rgbInfoViaje.Controls.Add(Me.Label12)
        Me.rgbInfoViaje.Controls.Add(Me.Label11)
        Me.rgbInfoViaje.Controls.Add(Me.Label10)
        Me.rgbInfoViaje.Controls.Add(Me.Label9)
        Me.rgbInfoViaje.Controls.Add(Me.Label6)
        Me.rgbInfoViaje.Controls.Add(Me.Label5)
        Me.rgbInfoViaje.Controls.Add(Me.Label3)
        Me.rgbInfoViaje.Controls.Add(Me.Label2)
        Me.rgbInfoViaje.FooterImageIndex = -1
        Me.rgbInfoViaje.FooterImageKey = ""
        Me.rgbInfoViaje.HeaderImageIndex = -1
        Me.rgbInfoViaje.HeaderImageKey = ""
        Me.rgbInfoViaje.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInfoViaje.HeaderText = "Informacion Viaje"
        Me.rgbInfoViaje.Location = New System.Drawing.Point(12, 54)
        Me.rgbInfoViaje.Name = "rgbInfoViaje"
        Me.rgbInfoViaje.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInfoViaje.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInfoViaje.Size = New System.Drawing.Size(1078, 227)
        Me.rgbInfoViaje.TabIndex = 108
        Me.rgbInfoViaje.Text = "Informacion Viaje"
        '
        'lblKMGalon
        '
        Me.lblKMGalon.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKMGalon.Location = New System.Drawing.Point(151, 189)
        Me.lblKMGalon.Name = "lblKMGalon"
        Me.lblKMGalon.Size = New System.Drawing.Size(281, 21)
        Me.lblKMGalon.TabIndex = 188
        Me.lblKMGalon.Text = "Km Galon"
        '
        'txtNoViaje
        '
        Me.txtNoViaje.Location = New System.Drawing.Point(568, 50)
        Me.txtNoViaje.Name = "txtNoViaje"
        Me.txtNoViaje.Size = New System.Drawing.Size(222, 20)
        Me.txtNoViaje.TabIndex = 182
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(32, 189)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 21)
        Me.Label14.TabIndex = 181
        Me.Label14.Text = "KM por Galon :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(449, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 21)
        Me.Label8.TabIndex = 180
        Me.Label8.Text = "Numero Viaje :"
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(336, 64)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(96, 29)
        Me.btnAgregar.TabIndex = 177
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'cmbTransporte
        '
        Me.cmbTransporte.FormattingEnabled = True
        Me.cmbTransporte.Location = New System.Drawing.Point(155, 148)
        Me.cmbTransporte.Name = "cmbTransporte"
        Me.cmbTransporte.Size = New System.Drawing.Size(277, 21)
        Me.cmbTransporte.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 21)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Transporte :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(568, 101)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(343, 104)
        Me.txtObservacion.TabIndex = 22
        '
        'lblCorrelativo
        '
        Me.lblCorrelativo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrelativo.Location = New System.Drawing.Point(568, 77)
        Me.lblCorrelativo.Name = "lblCorrelativo"
        Me.lblCorrelativo.Size = New System.Drawing.Size(299, 21)
        Me.lblCorrelativo.TabIndex = 21
        Me.lblCorrelativo.Text = "Correlativo"
        '
        'lblPordilleros
        '
        Me.lblPordilleros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPordilleros.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPordilleros.Location = New System.Drawing.Point(155, 97)
        Me.lblPordilleros.Name = "lblPordilleros"
        Me.lblPordilleros.Size = New System.Drawing.Size(277, 23)
        Me.lblPordilleros.TabIndex = 20
        '
        'lblNoPordilleros
        '
        Me.lblNoPordilleros.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoPordilleros.Location = New System.Drawing.Point(151, 66)
        Me.lblNoPordilleros.Name = "lblNoPordilleros"
        Me.lblNoPordilleros.Size = New System.Drawing.Size(179, 21)
        Me.lblNoPordilleros.TabIndex = 19
        Me.lblNoPordilleros.Text = "#"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(155, 14)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(277, 20)
        Me.dtpFecha.TabIndex = 18
        '
        'cmbSucursalSalida
        '
        Me.cmbSucursalSalida.FormattingEnabled = True
        Me.cmbSucursalSalida.Location = New System.Drawing.Point(568, 20)
        Me.cmbSucursalSalida.Name = "cmbSucursalSalida"
        Me.cmbSucursalSalida.Size = New System.Drawing.Size(299, 21)
        Me.cmbSucursalSalida.TabIndex = 17
        '
        'cmbTipoTransporte
        '
        Me.cmbTipoTransporte.FormattingEnabled = True
        Me.cmbTipoTransporte.Location = New System.Drawing.Point(155, 123)
        Me.cmbTipoTransporte.Name = "cmbTipoTransporte"
        Me.cmbTipoTransporte.Size = New System.Drawing.Size(277, 21)
        Me.cmbTipoTransporte.TabIndex = 16
        '
        'cmbPiloto
        '
        Me.cmbPiloto.FormattingEnabled = True
        Me.cmbPiloto.Location = New System.Drawing.Point(155, 37)
        Me.cmbPiloto.Name = "cmbPiloto"
        Me.cmbPiloto.Size = New System.Drawing.Size(277, 21)
        Me.cmbPiloto.TabIndex = 15
        '
        'lblPlaca
        '
        Me.lblPlaca.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlaca.Location = New System.Drawing.Point(151, 168)
        Me.lblPlaca.Name = "lblPlaca"
        Me.lblPlaca.Size = New System.Drawing.Size(281, 21)
        Me.lblPlaca.TabIndex = 14
        Me.lblPlaca.Text = "Placa"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(88, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 21)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Piloto :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(25, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 21)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "No. Pordilleros :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(53, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 21)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Pordilleros :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(34, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 21)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Tipo Vehiculo :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(92, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 21)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Placa :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(440, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 21)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Sucursal Salida :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(468, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Correlativo :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(458, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Observacion :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(88, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha :"
        '
        'grdClientes
        '
        Me.grdClientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdClientes.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdClientes.Location = New System.Drawing.Point(0, 0)
        '
        'grdClientes
        '
        Me.grdClientes.MasterTemplate.AllowAddNewRow = False
        Me.grdClientes.MasterTemplate.AllowColumnReorder = False
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientes.ReadOnly = True
        Me.grdClientes.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdClientes.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdClientes.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientes.Size = New System.Drawing.Size(1057, 301)
        Me.grdClientes.TabIndex = 0
        Me.grdClientes.Text = "Clientes"
        Me.grdClientes.ThemeName = "Office2007Black"
        '
        'grdProductos
        '
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.HeaderText = "idSalidaDetalle"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "idSalidaDetalle"
        GridViewTextBoxColumn1.Width = 93
        GridViewTextBoxColumn2.HeaderText = "idSalidaTransporte"
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "idSalidaTransporte"
        GridViewTextBoxColumn3.HeaderText = "Codigo"
        GridViewTextBoxColumn3.Name = "codigo"
        GridViewTextBoxColumn3.Width = 94
        GridViewTextBoxColumn4.HeaderText = "Producto"
        GridViewTextBoxColumn4.Name = "producto"
        GridViewTextBoxColumn4.Width = 233
        GridViewTextBoxColumn5.HeaderText = "Cantidad"
        GridViewTextBoxColumn5.Name = "cantidad"
        GridViewTextBoxColumn5.Width = 82
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.ReadOnly = True
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(1057, 305)
        Me.grdProductos.TabIndex = 1
        Me.grdProductos.Text = "Clientes"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'rpvContenido
        '
        Me.rpvContenido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpvContenido.Controls.Add(Me.pgClientes)
        Me.rpvContenido.Controls.Add(Me.pgProductos)
        Me.rpvContenido.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpvContenido.Location = New System.Drawing.Point(12, 287)
        Me.rpvContenido.Name = "rpvContenido"
        Me.rpvContenido.SelectedPage = Me.pgClientes
        Me.rpvContenido.Size = New System.Drawing.Size(1078, 352)
        Me.rpvContenido.TabIndex = 111
        Me.rpvContenido.Text = "RadPageView1"
        CType(Me.rpvContenido.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pgClientes
        '
        Me.pgClientes.Controls.Add(Me.grdClientes)
        Me.pgClientes.Location = New System.Drawing.Point(10, 40)
        Me.pgClientes.Name = "pgClientes"
        Me.pgClientes.Size = New System.Drawing.Size(1057, 301)
        Me.pgClientes.Text = "Clientes"
        '
        'pgProductos
        '
        Me.pgProductos.Controls.Add(Me.grdProductos)
        Me.pgProductos.Location = New System.Drawing.Point(10, 40)
        Me.pgProductos.Name = "pgProductos"
        Me.pgProductos.Size = New System.Drawing.Size(1057, 305)
        Me.pgProductos.Text = "Productos"
        '
        'frmDespachoFacturaAsignar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1098, 651)
        Me.Controls.Add(Me.rpvContenido)
        Me.Controls.Add(Me.rgbInfoViaje)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDespachoFacturaAsignar"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInfoViaje, 0)
        Me.Controls.SetChildIndex(Me.rpvContenido, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInfoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInfoViaje.ResumeLayout(False)
        Me.rgbInfoViaje.PerformLayout()
        CType(Me.grdClientes.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpvContenido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpvContenido.ResumeLayout(False)
        Me.pgClientes.ResumeLayout(False)
        Me.pgProductos.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInfoViaje As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdClientes As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
    Friend WithEvents lblPordilleros As System.Windows.Forms.Label
    Friend WithEvents lblNoPordilleros As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbSucursalSalida As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPiloto As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlaca As System.Windows.Forms.Label
    Friend WithEvents cmbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents rpvContenido As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgClientes As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pgProductos As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents txtNoViaje As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblKMGalon As System.Windows.Forms.Label

End Class
