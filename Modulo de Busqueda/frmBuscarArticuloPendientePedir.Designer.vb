<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloPendientePedir
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
        Dim GridViewCommandColumn1 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Dim GridViewCommandColumn2 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarArticuloPendientePedir))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0 = New System.Windows.Forms.Panel()
        Me.pbx0 = New System.Windows.Forms.PictureBox()
        Me.lbl0 = New System.Windows.Forms.Label()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Cerrar = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pgInformacion = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbArticulo = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.nm0Cantidad = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbImportancia = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pgHistorial = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbDetalle = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0.SuspendLayout()
        CType(Me.pbx0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Cerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pgInformacion.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbArticulo.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm0Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgHistorial.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDetalle.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(549, 51)
        Me.pnlBarra.TabIndex = 171
        '
        'pnx0
        '
        Me.pnx0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0.BackColor = System.Drawing.Color.Navy
        Me.pnx0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0.Controls.Add(Me.pbx0)
        Me.pnx0.Controls.Add(Me.lbl0)
        Me.pnx0.Location = New System.Drawing.Point(319, 7)
        Me.pnx0.Name = "pnx0"
        Me.pnx0.Size = New System.Drawing.Size(107, 40)
        Me.pnx0.TabIndex = 202
        '
        'pbx0
        '
        Me.pbx0.Image = Global.laFuente.My.Resources.Resources.upload
        Me.pbx0.Location = New System.Drawing.Point(2, 4)
        Me.pbx0.Name = "pbx0"
        Me.pbx0.Size = New System.Drawing.Size(32, 29)
        Me.pbx0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0.TabIndex = 93
        Me.pbx0.TabStop = False
        '
        'lbl0
        '
        Me.lbl0.AutoSize = True
        Me.lbl0.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl0.ForeColor = System.Drawing.Color.White
        Me.lbl0.Location = New System.Drawing.Point(40, 4)
        Me.lbl0.Name = "lbl0"
        Me.lbl0.Size = New System.Drawing.Size(54, 30)
        Me.lbl0.TabIndex = 94
        Me.lbl0.Text = "Docs. de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Salida"
        Me.lbl0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Cerrar)
        Me.pnx1Salir.Location = New System.Drawing.Point(431, 7)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 200
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(48, 7)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(44, 21)
        Me.lbl1Salir.TabIndex = 190
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Cerrar
        '
        Me.pbx1Cerrar.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Cerrar.Location = New System.Drawing.Point(3, 2)
        Me.pbx1Cerrar.Name = "pbx1Cerrar"
        Me.pbx1Cerrar.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Cerrar.TabIndex = 188
        Me.pbx1Cerrar.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(65, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 29)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Información"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox3.Location = New System.Drawing.Point(26, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 41)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 174
        Me.PictureBox3.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.cmbCliente)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.lblClave)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(8, 27)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(966, 79)
        Me.rgbInformacion.TabIndex = 172
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(107, 49)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(410, 21)
        Me.cmbCliente.TabIndex = 172
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(34, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 25)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Clave :"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblClave.ForeColor = System.Drawing.Color.Black
        Me.lblClave.Location = New System.Drawing.Point(102, 14)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(69, 30)
        Me.lblClave.TabIndex = 171
        Me.lblClave.Text = "Clave"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(19, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 25)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "Cliente :"
        '
        'rpv
        '
        Me.rpv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpv.Controls.Add(Me.pgInformacion)
        Me.rpv.Controls.Add(Me.pgHistorial)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpv.Location = New System.Drawing.Point(4, 59)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pgInformacion
        Me.rpv.Size = New System.Drawing.Size(1000, 471)
        Me.rpv.TabIndex = 181
        Me.rpv.Text = "RadPageView1"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pgInformacion
        '
        Me.pgInformacion.Controls.Add(Me.Label4)
        Me.pgInformacion.Controls.Add(Me.PictureBox4)
        Me.pgInformacion.Controls.Add(Me.rgbArticulo)
        Me.pgInformacion.Controls.Add(Me.PictureBox3)
        Me.pgInformacion.Controls.Add(Me.Label2)
        Me.pgInformacion.Controls.Add(Me.rgbInformacion)
        Me.pgInformacion.Location = New System.Drawing.Point(10, 43)
        Me.pgInformacion.Name = "pgInformacion"
        Me.pgInformacion.Size = New System.Drawing.Size(979, 417)
        Me.pgInformacion.Text = "Crear"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(67, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 29)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "Artículo"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.agregar
        Me.PictureBox4.Location = New System.Drawing.Point(26, 112)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 180
        Me.PictureBox4.TabStop = False
        '
        'rgbArticulo
        '
        Me.rgbArticulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbArticulo.Controls.Add(Me.grdProductos)
        Me.rgbArticulo.Controls.Add(Me.btnVerificar)
        Me.rgbArticulo.Controls.Add(Me.btnAgregar)
        Me.rgbArticulo.Controls.Add(Me.nm0Cantidad)
        Me.rgbArticulo.Controls.Add(Me.Label11)
        Me.rgbArticulo.Controls.Add(Me.cmbImportancia)
        Me.rgbArticulo.Controls.Add(Me.Label10)
        Me.rgbArticulo.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbArticulo.Controls.Add(Me.Label9)
        Me.rgbArticulo.Controls.Add(Me.txtObservacion)
        Me.rgbArticulo.Controls.Add(Me.Label7)
        Me.rgbArticulo.Controls.Add(Me.txtDescripcion)
        Me.rgbArticulo.Controls.Add(Me.txtCodigo)
        Me.rgbArticulo.Controls.Add(Me.Label6)
        Me.rgbArticulo.Controls.Add(Me.Label8)
        Me.rgbArticulo.FooterImageIndex = -1
        Me.rgbArticulo.FooterImageKey = ""
        Me.rgbArticulo.HeaderImageIndex = -1
        Me.rgbArticulo.HeaderImageKey = ""
        Me.rgbArticulo.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbArticulo.HeaderText = ""
        Me.rgbArticulo.Location = New System.Drawing.Point(15, 132)
        Me.rgbArticulo.Name = "rgbArticulo"
        Me.rgbArticulo.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbArticulo.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbArticulo.Size = New System.Drawing.Size(959, 282)
        Me.rgbArticulo.TabIndex = 178
        '
        'grdProductos
        '
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(516, 21)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.ReadOnly = True
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(430, 193)
        Me.grdProductos.TabIndex = 183
        Me.grdProductos.Text = "Productos"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'btnVerificar
        '
        Me.btnVerificar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnVerificar.FlatAppearance.BorderSize = 0
        Me.btnVerificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerificar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerificar.ForeColor = System.Drawing.Color.Transparent
        Me.btnVerificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVerificar.Location = New System.Drawing.Point(430, 48)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(80, 25)
        Me.btnVerificar.TabIndex = 182
        Me.btnVerificar.Text = "Verificar"
        Me.btnVerificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerificar.UseVisualStyleBackColor = False
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
        Me.btnAgregar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(829, 220)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(117, 56)
        Me.btnAgregar.TabIndex = 181
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'nm0Cantidad
        '
        Me.nm0Cantidad.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm0Cantidad.Location = New System.Drawing.Point(139, 238)
        Me.nm0Cantidad.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm0Cantidad.Name = "nm0Cantidad"
        Me.nm0Cantidad.Size = New System.Drawing.Size(120, 23)
        Me.nm0Cantidad.TabIndex = 180
        Me.nm0Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(33, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 25)
        Me.Label11.TabIndex = 179
        Me.Label11.Text = "Cantidad :"
        '
        'cmbImportancia
        '
        Me.cmbImportancia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbImportancia.FormattingEnabled = True
        Me.cmbImportancia.Location = New System.Drawing.Point(139, 210)
        Me.cmbImportancia.Name = "cmbImportancia"
        Me.cmbImportancia.Size = New System.Drawing.Size(284, 23)
        Me.cmbImportancia.TabIndex = 178
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(6, 205)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 25)
        Me.Label10.TabIndex = 177
        Me.Label10.Text = "Importancia :"
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(141, 21)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(107, 23)
        Me.dtpFechaRegistro.TabIndex = 176
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(63, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 25)
        Me.Label9.TabIndex = 175
        Me.Label9.Text = "Fecha :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(141, 107)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(283, 92)
        Me.txtObservacion.TabIndex = 174
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(6, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 25)
        Me.Label7.TabIndex = 173
        Me.Label7.Text = "Observación :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(141, 79)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(283, 23)
        Me.txtDescripcion.TabIndex = 172
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(141, 51)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(283, 23)
        Me.txtCodigo.TabIndex = 171
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(52, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 25)
        Me.Label6.TabIndex = 170
        Me.Label6.Text = "Código :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(13, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 25)
        Me.Label8.TabIndex = 168
        Me.Label8.Text = "Descripción :"
        '
        'pgHistorial
        '
        Me.pgHistorial.Controls.Add(Me.Label12)
        Me.pgHistorial.Controls.Add(Me.PictureBox5)
        Me.pgHistorial.Controls.Add(Me.rgbDetalle)
        Me.pgHistorial.Location = New System.Drawing.Point(10, 43)
        Me.pgHistorial.Name = "pgHistorial"
        Me.pgHistorial.Size = New System.Drawing.Size(979, 417)
        Me.pgHistorial.Text = "Historial"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(61, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 29)
        Me.Label12.TabIndex = 185
        Me.Label12.Text = "Detalles"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox5.Location = New System.Drawing.Point(20, 27)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 186
        Me.PictureBox5.TabStop = False
        '
        'rgbDetalle
        '
        Me.rgbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDetalle.Controls.Add(Me.grdDatos)
        Me.rgbDetalle.FooterImageIndex = -1
        Me.rgbDetalle.FooterImageKey = ""
        Me.rgbDetalle.HeaderImageIndex = -1
        Me.rgbDetalle.HeaderImageKey = ""
        Me.rgbDetalle.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDetalle.HeaderText = ""
        Me.rgbDetalle.Location = New System.Drawing.Point(10, 53)
        Me.rgbDetalle.Name = "rgbDetalle"
        Me.rgbDetalle.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDetalle.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDetalle.Size = New System.Drawing.Size(958, 337)
        Me.rgbDetalle.TabIndex = 184
        '
        'grdDatos
        '
        Me.grdDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdDatos.Location = New System.Drawing.Point(10, 20)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        GridViewCommandColumn1.HeaderText = "Crear"
        GridViewCommandColumn1.Name = "crear"
        GridViewCommandColumn1.Width = 88
        GridViewCommandColumn2.HeaderText = "Modificar"
        GridViewCommandColumn2.Name = "modificar"
        GridViewCommandColumn2.Width = 93
        Me.grdDatos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCommandColumn1, GridViewCommandColumn2})
        Me.grdDatos.MasterTemplate.EnableGrouping = False
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdDatos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(938, 307)
        Me.grdDatos.TabIndex = 0
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'frmBuscarArticuloPendientePedir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1010, 542)
        Me.Controls.Add(Me.rpv)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuscarArticuloPendientePedir"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rpv, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0.ResumeLayout(False)
        Me.pnx0.PerformLayout()
        CType(Me.pbx0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Cerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv.ResumeLayout(False)
        Me.pgInformacion.ResumeLayout(False)
        Me.pgInformacion.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbArticulo.ResumeLayout(False)
        Me.rgbArticulo.PerformLayout()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm0Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgHistorial.ResumeLayout(False)
        Me.pgHistorial.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDetalle.ResumeLayout(False)
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0 As System.Windows.Forms.Panel
    Friend WithEvents pbx0 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0 As System.Windows.Forms.Label
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Cerrar As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgInformacion As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbArticulo As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents nm0Cantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbImportancia As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pgHistorial As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbDetalle As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnVerificar As System.Windows.Forms.Button
    Friend WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox

End Class
