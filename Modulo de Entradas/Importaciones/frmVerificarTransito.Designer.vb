<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerificarTransito
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
        Me.components = New System.ComponentModel.Container()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVerificarTransito))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Validar = New System.Windows.Forms.Panel()
        Me.lbl0Validar = New System.Windows.Forms.Label()
        Me.pbx0Validar = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdPreforma = New Telerik.WinControls.UI.RadGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbPreforma = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdInvoice = New Telerik.WinControls.UI.RadGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbInvoice = New System.Windows.Forms.ComboBox()
        Me.tmCronometro = New System.Windows.Forms.Timer(Me.components)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Validar.SuspendLayout()
        CType(Me.pbx0Validar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.grdPreforma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPreforma.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.grdInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInvoice.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Validar)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(683, 48)
        Me.pnlBarra.TabIndex = 184
        '
        'pnx0Validar
        '
        Me.pnx0Validar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Validar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Validar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Validar.Controls.Add(Me.lbl0Validar)
        Me.pnx0Validar.Controls.Add(Me.pbx0Validar)
        Me.pnx0Validar.Location = New System.Drawing.Point(451, 4)
        Me.pnx0Validar.Name = "pnx0Validar"
        Me.pnx0Validar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Validar.TabIndex = 196
        '
        'lbl0Validar
        '
        Me.lbl0Validar.AutoSize = True
        Me.lbl0Validar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Validar.ForeColor = System.Drawing.Color.White
        Me.lbl0Validar.Location = New System.Drawing.Point(46, 12)
        Me.lbl0Validar.Name = "lbl0Validar"
        Me.lbl0Validar.Size = New System.Drawing.Size(45, 15)
        Me.lbl0Validar.TabIndex = 72
        Me.lbl0Validar.Text = "Validar"
        Me.lbl0Validar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx0Validar
        '
        Me.pbx0Validar.Image = Global.laFuente.My.Resources.Resources.refresh
        Me.pbx0Validar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Validar.Name = "pbx0Validar"
        Me.pbx0Validar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Validar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Validar.TabIndex = 71
        Me.pbx0Validar.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(563, 3)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 195
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 72
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 71
        Me.pbx1Salir.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(760, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 25)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "Preforma"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(717, 51)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 193
        Me.PictureBox4.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.grdPreforma)
        Me.rgbInformacion.Controls.Add(Me.Label13)
        Me.rgbInformacion.Controls.Add(Me.cmbPreforma)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(579, 68)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(570, 459)
        Me.rgbInformacion.TabIndex = 192
        '
        'grdPreforma
        '
        Me.grdPreforma.AutoScroll = True
        Me.grdPreforma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdPreforma.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdPreforma.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.grdPreforma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdPreforma.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdPreforma.Location = New System.Drawing.Point(11, 50)
        '
        'grdPreforma
        '
        Me.grdPreforma.MasterTemplate.AllowAddNewRow = False
        Me.grdPreforma.MasterTemplate.AllowDeleteRow = False
        Me.grdPreforma.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn1.HeaderText = "Codigo"
        GridViewTextBoxColumn1.Name = "Codigo"
        GridViewTextBoxColumn2.HeaderText = "Producto"
        GridViewTextBoxColumn2.Name = "Producto"
        GridViewTextBoxColumn3.HeaderText = "Cantidad"
        GridViewTextBoxColumn3.Name = "Cantidad"
        GridViewTextBoxColumn4.HeaderText = "Costo"
        GridViewTextBoxColumn4.Name = "Costo"
        GridViewTextBoxColumn5.HeaderText = "Faltante"
        GridViewTextBoxColumn5.Name = "Faltante"
        Me.grdPreforma.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.grdPreforma.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdPreforma.MasterTemplate.EnableGrouping = False
        Me.grdPreforma.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdPreforma.Name = "grdPreforma"
        Me.grdPreforma.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPreforma.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdPreforma.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdPreforma.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPreforma.Size = New System.Drawing.Size(550, 402)
        Me.grdPreforma.TabIndex = 162
        Me.grdPreforma.Text = "RadGridView1"
        Me.grdPreforma.ThemeName = "Office2007Black"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(107, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Preforma :"
        '
        'cmbPreforma
        '
        Me.cmbPreforma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPreforma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPreforma.FormattingEnabled = True
        Me.cmbPreforma.Location = New System.Drawing.Point(172, 23)
        Me.cmbPreforma.Name = "cmbPreforma"
        Me.cmbPreforma.Size = New System.Drawing.Size(290, 21)
        Me.cmbPreforma.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(68, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 25)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Invoice"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox3.Location = New System.Drawing.Point(25, 51)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 196
        Me.PictureBox3.TabStop = False
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Controls.Add(Me.grdInvoice)
        Me.RadGroupBox1.Controls.Add(Me.Label3)
        Me.RadGroupBox1.Controls.Add(Me.cmbInvoice)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(4, 68)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(569, 459)
        Me.RadGroupBox1.TabIndex = 195
        '
        'grdInvoice
        '
        Me.grdInvoice.AutoScroll = True
        Me.grdInvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdInvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdInvoice.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.grdInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdInvoice.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdInvoice.Location = New System.Drawing.Point(11, 50)
        '
        'grdInvoice
        '
        Me.grdInvoice.MasterTemplate.AllowAddNewRow = False
        Me.grdInvoice.MasterTemplate.AllowDeleteRow = False
        Me.grdInvoice.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn6.HeaderText = "Codigo"
        GridViewTextBoxColumn6.Name = "Codigo"
        GridViewTextBoxColumn7.HeaderText = "Producto"
        GridViewTextBoxColumn7.Name = "Producto"
        GridViewTextBoxColumn8.HeaderText = "Cantidad"
        GridViewTextBoxColumn8.Name = "Cantidad"
        GridViewTextBoxColumn9.HeaderText = "Costo"
        GridViewTextBoxColumn9.Name = "Costo"
        Me.grdInvoice.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.grdInvoice.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdInvoice.MasterTemplate.EnableGrouping = False
        Me.grdInvoice.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdInvoice.Name = "grdInvoice"
        Me.grdInvoice.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdInvoice.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdInvoice.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdInvoice.Size = New System.Drawing.Size(546, 402)
        Me.grdInvoice.TabIndex = 162
        Me.grdInvoice.Text = "RadGridView1"
        Me.grdInvoice.ThemeName = "Office2007Black"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(101, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Invoice :"
        '
        'cmbInvoice
        '
        Me.cmbInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInvoice.FormattingEnabled = True
        Me.cmbInvoice.Location = New System.Drawing.Point(166, 23)
        Me.cmbInvoice.Name = "cmbInvoice"
        Me.cmbInvoice.Size = New System.Drawing.Size(290, 21)
        Me.cmbInvoice.TabIndex = 37
        '
        'frmVerificarTransito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1151, 532)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVerificarTransito"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = resources.GetString("$this.Text")
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Validar.ResumeLayout(False)
        Me.pnx0Validar.PerformLayout()
        CType(Me.pbx0Validar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.grdPreforma.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPreforma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.grdInvoice.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Validar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Validar As System.Windows.Forms.Label
    Friend WithEvents pbx0Validar As System.Windows.Forms.PictureBox
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbPreforma As System.Windows.Forms.ComboBox
    Public WithEvents grdPreforma As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdInvoice As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbInvoice As System.Windows.Forms.ComboBox
    Friend WithEvents tmCronometro As System.Windows.Forms.Timer

End Class
