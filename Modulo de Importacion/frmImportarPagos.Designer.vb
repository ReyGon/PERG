<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarPagos))
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbHojas = New System.Windows.Forms.ComboBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblContadorPagos = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rgbPagos = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdPagos = New Telerik.WinControls.UI.RadGridView()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pnlbarra = New System.Windows.Forms.Panel()
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblcontadorClientes = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdClientes = New Telerik.WinControls.UI.RadGridView()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox5 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbPagos.SuspendLayout()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPagos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlbarra.SuspendLayout()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdClientes.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox5.SuspendLayout()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.btnAgregar)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.txtUrl)
        Me.rgbInformacion.Controls.Add(Me.lblTitulo)
        Me.rgbInformacion.Controls.Add(Me.cmbHojas)
        Me.rgbInformacion.Controls.Add(Me.btnImportar)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 87)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(399, 209)
        Me.rgbInformacion.TabIndex = 182
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(140, 128)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(142, 55)
        Me.btnAgregar.TabIndex = 181
        Me.btnAgregar.Text = "  Agregar "
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(7, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "URL :"
        '
        'txtUrl
        '
        Me.txtUrl.Enabled = False
        Me.txtUrl.Location = New System.Drawing.Point(55, 57)
        Me.txtUrl.Multiline = True
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(321, 22)
        Me.txtUrl.TabIndex = 179
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTitulo.Location = New System.Drawing.Point(7, 90)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(44, 19)
        Me.lblTitulo.TabIndex = 178
        Me.lblTitulo.Text = "Hoja :"
        '
        'cmbHojas
        '
        Me.cmbHojas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbHojas.FormattingEnabled = True
        Me.cmbHojas.Location = New System.Drawing.Point(57, 90)
        Me.cmbHojas.Name = "cmbHojas"
        Me.cmbHojas.Size = New System.Drawing.Size(321, 21)
        Me.cmbHojas.TabIndex = 177
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnImportar.FlatAppearance.BorderSize = 0
        Me.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.ForeColor = System.Drawing.Color.Transparent
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.Location = New System.Drawing.Point(55, 18)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(124, 31)
        Me.btnImportar.TabIndex = 176
        Me.btnImportar.Text = "Abrir Doc."
        Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.Label4)
        Me.rgbObservacion.Controls.Add(Me.lblContadorPagos)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(876, -32)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(142, 32)
        Me.rgbObservacion.TabIndex = 194
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(21, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 25)
        Me.Label4.TabIndex = 176
        Me.Label4.Text = "#"
        '
        'lblContadorPagos
        '
        Me.lblContadorPagos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContadorPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContadorPagos.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContadorPagos.ForeColor = System.Drawing.Color.Black
        Me.lblContadorPagos.Location = New System.Drawing.Point(50, 4)
        Me.lblContadorPagos.Name = "lblContadorPagos"
        Me.lblContadorPagos.Size = New System.Drawing.Size(85, 25)
        Me.lblContadorPagos.TabIndex = 175
        Me.lblContadorPagos.Text = "0"
        Me.lblContadorPagos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(467, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 29)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "Pagos Encontrados"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(426, 71)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 193
        Me.PictureBox3.TabStop = False
        '
        'rgbPagos
        '
        Me.rgbPagos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbPagos.Controls.Add(Me.grdPagos)
        Me.rgbPagos.FooterImageIndex = -1
        Me.rgbPagos.FooterImageKey = ""
        Me.rgbPagos.HeaderImageIndex = -1
        Me.rgbPagos.HeaderImageKey = ""
        Me.rgbPagos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbPagos.HeaderText = ""
        Me.rgbPagos.Location = New System.Drawing.Point(419, 87)
        Me.rgbPagos.Name = "rgbPagos"
        Me.rgbPagos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbPagos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbPagos.Size = New System.Drawing.Size(614, 209)
        Me.rgbPagos.TabIndex = 191
        '
        'grdPagos
        '
        Me.grdPagos.Location = New System.Drawing.Point(9, 22)
        '
        'grdPagos
        '
        Me.grdPagos.MasterTemplate.AllowAddNewRow = False
        Me.grdPagos.Name = "grdPagos"
        Me.grdPagos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPagos.ReadOnly = True
        '
        '
        '
        Me.grdPagos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPagos.Size = New System.Drawing.Size(596, 170)
        Me.grdPagos.TabIndex = 1
        Me.grdPagos.Text = "RadGridView1"
        Me.grdPagos.ThemeName = "Office2007Black"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(21, 61)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(52, 42)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 196
        Me.PictureBox5.TabStop = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(74, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 29)
        Me.Label16.TabIndex = 195
        Me.Label16.Text = "Informacion"
        '
        'pnx1Salir
        '
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(457, 3)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(111, 40)
        Me.pnx1Salir.TabIndex = 198
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = CType(resources.GetObject("pbx1Salir.Image"), System.Drawing.Image)
        Me.pbx1Salir.Location = New System.Drawing.Point(3, 4)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 95
        Me.pbx1Salir.TabStop = False
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(44, 11)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 96
        Me.lbl1Salir.Text = "Salir"
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(342, 3)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(111, 40)
        Me.pnx0Guardar.TabIndex = 197
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = CType(resources.GetObject("pbx0Guardar.Image"), System.Drawing.Image)
        Me.pbx0Guardar.Location = New System.Drawing.Point(3, 4)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 95
        Me.pbx0Guardar.TabStop = False
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(44, 11)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Guardar.TabIndex = 96
        Me.lbl0Guardar.Text = "Guardar"
        '
        'pnlbarra
        '
        Me.pnlbarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlbarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlbarra.Controls.Add(Me.pnx0Guardar)
        Me.pnlbarra.Controls.Add(Me.pnx1Salir)
        Me.pnlbarra.Location = New System.Drawing.Point(465, 1)
        Me.pnlbarra.Name = "pnlbarra"
        Me.pnlbarra.Size = New System.Drawing.Size(577, 48)
        Me.pnlbarra.TabIndex = 199
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox4.Controls.Add(Me.lblContador)
        Me.RadGroupBox4.Controls.Add(Me.Label14)
        Me.RadGroupBox4.FooterImageIndex = -1
        Me.RadGroupBox4.FooterImageKey = ""
        Me.RadGroupBox4.HeaderImageIndex = -1
        Me.RadGroupBox4.HeaderImageKey = ""
        Me.RadGroupBox4.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox4.HeaderText = ""
        Me.RadGroupBox4.Location = New System.Drawing.Point(900, 73)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox4.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox4.Size = New System.Drawing.Size(120, 33)
        Me.RadGroupBox4.TabIndex = 205
        '
        'lblContador
        '
        Me.lblContador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContador.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContador.ForeColor = System.Drawing.Color.Black
        Me.lblContador.Location = New System.Drawing.Point(28, 6)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(80, 21)
        Me.lblContador.TabIndex = 175
        Me.lblContador.Text = "0"
        Me.lblContador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(4, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(19, 21)
        Me.Label14.TabIndex = 174
        Me.Label14.Text = "#"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.lblcontadorClientes)
        Me.RadGroupBox1.Controls.Add(Me.Label6)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(893, 304)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(126, 33)
        Me.RadGroupBox1.TabIndex = 209
        '
        'lblcontadorClientes
        '
        Me.lblcontadorClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcontadorClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcontadorClientes.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcontadorClientes.ForeColor = System.Drawing.Color.Black
        Me.lblcontadorClientes.Location = New System.Drawing.Point(34, 6)
        Me.lblcontadorClientes.Name = "lblcontadorClientes"
        Me.lblcontadorClientes.Size = New System.Drawing.Size(80, 21)
        Me.lblcontadorClientes.TabIndex = 175
        Me.lblcontadorClientes.Text = "0"
        Me.lblcontadorClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(8, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 21)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "#"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(467, 308)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(303, 29)
        Me.Label7.TabIndex = 207
        Me.Label7.Text = "Clientes No Encontrados"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(426, 304)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 208
        Me.PictureBox4.TabStop = False
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox2.Controls.Add(Me.grdClientes)
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = ""
        Me.RadGroupBox2.Location = New System.Drawing.Point(419, 323)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox2.Size = New System.Drawing.Size(614, 171)
        Me.RadGroupBox2.TabIndex = 206
        '
        'grdClientes
        '
        Me.grdClientes.Location = New System.Drawing.Point(9, 19)
        '
        'grdClientes
        '
        Me.grdClientes.MasterTemplate.AllowAddNewRow = False
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientes.ReadOnly = True
        '
        '
        '
        Me.grdClientes.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientes.Size = New System.Drawing.Size(596, 142)
        Me.grdClientes.TabIndex = 1
        Me.grdClientes.Text = "RadGridView1"
        Me.grdClientes.ThemeName = "Office2007Black"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox3.Controls.Add(Me.Label5)
        Me.RadGroupBox3.Controls.Add(Me.Label8)
        Me.RadGroupBox3.FooterImageIndex = -1
        Me.RadGroupBox3.FooterImageKey = ""
        Me.RadGroupBox3.HeaderImageIndex = -1
        Me.RadGroupBox3.HeaderImageKey = ""
        Me.RadGroupBox3.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox3.HeaderText = ""
        Me.RadGroupBox3.Location = New System.Drawing.Point(299, 301)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox3.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox3.Size = New System.Drawing.Size(103, 33)
        Me.RadGroupBox3.TabIndex = 213
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(31, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 21)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "0"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(10, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 21)
        Me.Label8.TabIndex = 174
        Me.Label8.Text = "#"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(47, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(246, 24)
        Me.Label9.TabIndex = 211
        Me.Label9.Text = "Concep. No Encontrados"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(9, 304)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 212
        Me.PictureBox7.TabStop = False
        '
        'RadGroupBox5
        '
        Me.RadGroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox5.Controls.Add(Me.RadGridView1)
        Me.RadGroupBox5.FooterImageIndex = -1
        Me.RadGroupBox5.FooterImageKey = ""
        Me.RadGroupBox5.HeaderImageIndex = -1
        Me.RadGroupBox5.HeaderImageKey = ""
        Me.RadGroupBox5.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox5.HeaderText = ""
        Me.RadGroupBox5.Location = New System.Drawing.Point(2, 323)
        Me.RadGroupBox5.Name = "RadGroupBox5"
        Me.RadGroupBox5.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox5.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox5.Size = New System.Drawing.Size(409, 171)
        Me.RadGroupBox5.TabIndex = 210
        '
        'RadGridView1
        '
        Me.RadGridView1.Location = New System.Drawing.Point(9, 19)
        '
        'RadGridView1
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.RadGridView1.ReadOnly = True
        '
        '
        '
        Me.RadGridView1.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.RadGridView1.Size = New System.Drawing.Size(387, 142)
        Me.RadGridView1.TabIndex = 1
        Me.RadGridView1.Text = "RadGridView1"
        Me.RadGridView1.ThemeName = "Office2007Black"
        '
        'frmImportarPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1045, 496)
        Me.Controls.Add(Me.RadGroupBox3)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.RadGroupBox4)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.RadGroupBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.pnlbarra)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbObservacion)
        Me.Controls.Add(Me.rgbPagos)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportarPagos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.rgbPagos, 0)
        Me.Controls.SetChildIndex(Me.rgbObservacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox2, 0)
        Me.Controls.SetChildIndex(Me.pnlbarra, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.PictureBox7, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox3, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbPagos.ResumeLayout(False)
        CType(Me.grdPagos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlbarra.ResumeLayout(False)
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        Me.RadGroupBox4.PerformLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        CType(Me.grdClientes.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        Me.RadGroupBox3.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox5.ResumeLayout(False)
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents cmbHojas As System.Windows.Forms.ComboBox
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblContadorPagos As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbPagos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdPagos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pnlbarra As System.Windows.Forms.Panel
    Friend WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblcontadorClientes As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdClientes As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents RadGroupBox5 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView

End Class
