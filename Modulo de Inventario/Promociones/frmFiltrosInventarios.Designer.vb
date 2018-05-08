<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosInventarios
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosInventarios))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbProducto = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosMarca = New System.Windows.Forms.CheckBox()
        Me.grdMarca = New Telerik.WinControls.UI.RadGridView()
        Me.lblEMarca = New System.Windows.Forms.Label()
        Me.chkTodosModelo = New System.Windows.Forms.CheckBox()
        Me.chkTodosTipo = New System.Windows.Forms.CheckBox()
        Me.grdModelos = New Telerik.WinControls.UI.RadGridView()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.lblEtiquetaFiltro2 = New System.Windows.Forms.Label()
        Me.lblGrid1 = New System.Windows.Forms.Label()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Facturar = New System.Windows.Forms.Panel()
        Me.lbl0Facturar = New System.Windows.Forms.Label()
        Me.pbx0Facturar = New System.Windows.Forms.PictureBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbProducto.SuspendLayout()
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMarca.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Facturar.SuspendLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(51, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 29)
        Me.Label16.TabIndex = 161
        Me.Label16.Text = "Filtros"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox5.Location = New System.Drawing.Point(16, 50)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(35, 29)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 162
        Me.PictureBox5.TabStop = False
        '
        'rgbProducto
        '
        Me.rgbProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbProducto.Controls.Add(Me.chkTodosMarca)
        Me.rgbProducto.Controls.Add(Me.grdMarca)
        Me.rgbProducto.Controls.Add(Me.lblEMarca)
        Me.rgbProducto.Controls.Add(Me.chkTodosModelo)
        Me.rgbProducto.Controls.Add(Me.chkTodosTipo)
        Me.rgbProducto.Controls.Add(Me.grdModelos)
        Me.rgbProducto.Controls.Add(Me.grdTipoVehiculo)
        Me.rgbProducto.Controls.Add(Me.lblEtiquetaFiltro2)
        Me.rgbProducto.Controls.Add(Me.lblGrid1)
        Me.rgbProducto.FooterImageIndex = -1
        Me.rgbProducto.FooterImageKey = ""
        Me.rgbProducto.HeaderImageIndex = -1
        Me.rgbProducto.HeaderImageKey = ""
        Me.rgbProducto.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbProducto.HeaderText = ""
        Me.rgbProducto.Location = New System.Drawing.Point(3, 67)
        Me.rgbProducto.Name = "rgbProducto"
        Me.rgbProducto.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbProducto.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbProducto.Size = New System.Drawing.Size(939, 400)
        Me.rgbProducto.TabIndex = 160
        '
        'chkTodosMarca
        '
        Me.chkTodosMarca.AutoSize = True
        Me.chkTodosMarca.Location = New System.Drawing.Point(868, 16)
        Me.chkTodosMarca.Name = "chkTodosMarca"
        Me.chkTodosMarca.Size = New System.Drawing.Size(57, 17)
        Me.chkTodosMarca.TabIndex = 148
        Me.chkTodosMarca.Text = "Todos"
        Me.chkTodosMarca.UseVisualStyleBackColor = True
        '
        'grdMarca
        '
        Me.grdMarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdMarca.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdMarca.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdMarca.ForeColor = System.Drawing.Color.Black
        Me.grdMarca.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdMarca.Location = New System.Drawing.Point(625, 36)
        '
        'grdMarca
        '
        Me.grdMarca.MasterTemplate.AllowAddNewRow = False
        Me.grdMarca.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmAgregar"
        GridViewCheckBoxColumn1.Width = 52
        GridViewTextBoxColumn1.HeaderText = "codigo"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "codigo"
        GridViewTextBoxColumn2.HeaderText = "Nombre"
        GridViewTextBoxColumn2.Name = "nombre"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 140
        Me.grdMarca.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.grdMarca.MasterTemplate.EnableGrouping = False
        Me.grdMarca.MasterTemplate.EnableSorting = False
        Me.grdMarca.Name = "grdMarca"
        Me.grdMarca.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdMarca.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdMarca.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdMarca.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdMarca.Size = New System.Drawing.Size(300, 360)
        Me.grdMarca.TabIndex = 147
        Me.grdMarca.Text = "RadGridView1"
        Me.grdMarca.ThemeName = "Office2007Black"
        '
        'lblEMarca
        '
        Me.lblEMarca.AutoSize = True
        Me.lblEMarca.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEMarca.ForeColor = System.Drawing.Color.DimGray
        Me.lblEMarca.Location = New System.Drawing.Point(625, 14)
        Me.lblEMarca.Name = "lblEMarca"
        Me.lblEMarca.Size = New System.Drawing.Size(51, 19)
        Me.lblEMarca.TabIndex = 146
        Me.lblEMarca.Text = "Marca"
        '
        'chkTodosModelo
        '
        Me.chkTodosModelo.AutoSize = True
        Me.chkTodosModelo.Location = New System.Drawing.Point(562, 16)
        Me.chkTodosModelo.Name = "chkTodosModelo"
        Me.chkTodosModelo.Size = New System.Drawing.Size(57, 17)
        Me.chkTodosModelo.TabIndex = 144
        Me.chkTodosModelo.Text = "Todos"
        Me.chkTodosModelo.UseVisualStyleBackColor = True
        '
        'chkTodosTipo
        '
        Me.chkTodosTipo.AutoSize = True
        Me.chkTodosTipo.Location = New System.Drawing.Point(256, 16)
        Me.chkTodosTipo.Name = "chkTodosTipo"
        Me.chkTodosTipo.Size = New System.Drawing.Size(57, 17)
        Me.chkTodosTipo.TabIndex = 143
        Me.chkTodosTipo.Text = "Todos"
        Me.chkTodosTipo.UseVisualStyleBackColor = True
        '
        'grdModelos
        '
        Me.grdModelos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdModelos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdModelos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdModelos.ForeColor = System.Drawing.Color.Black
        Me.grdModelos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdModelos.Location = New System.Drawing.Point(319, 36)
        '
        'grdModelos
        '
        Me.grdModelos.MasterTemplate.AllowAddNewRow = False
        Me.grdModelos.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "chmAgregar"
        GridViewCheckBoxColumn2.Width = 52
        GridViewTextBoxColumn3.HeaderText = "codigo"
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.Name = "codigo"
        GridViewTextBoxColumn4.HeaderText = "Nombre"
        GridViewTextBoxColumn4.Name = "nombre"
        GridViewTextBoxColumn4.ReadOnly = True
        GridViewTextBoxColumn4.Width = 180
        Me.grdModelos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.grdModelos.MasterTemplate.EnableGrouping = False
        Me.grdModelos.MasterTemplate.EnableSorting = False
        Me.grdModelos.Name = "grdModelos"
        Me.grdModelos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdModelos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdModelos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdModelos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdModelos.Size = New System.Drawing.Size(300, 360)
        Me.grdModelos.TabIndex = 142
        Me.grdModelos.Text = "RadGridView1"
        Me.grdModelos.ThemeName = "Office2007Black"
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoVehiculo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoVehiculo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoVehiculo.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoVehiculo.Location = New System.Drawing.Point(13, 36)
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoVehiculo.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn3.MinWidth = 20
        GridViewCheckBoxColumn3.Name = "chmAgregar"
        GridViewCheckBoxColumn3.Width = 55
        GridViewTextBoxColumn5.HeaderText = "codigo"
        GridViewTextBoxColumn5.IsVisible = False
        GridViewTextBoxColumn5.Name = "codigo"
        GridViewTextBoxColumn6.HeaderText = "Nombre"
        GridViewTextBoxColumn6.Name = "nombre"
        GridViewTextBoxColumn6.ReadOnly = True
        GridViewTextBoxColumn6.Width = 150
        Me.grdTipoVehiculo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn3, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.grdTipoVehiculo.MasterTemplate.EnableGrouping = False
        Me.grdTipoVehiculo.MasterTemplate.EnableSorting = False
        Me.grdTipoVehiculo.Name = "grdTipoVehiculo"
        Me.grdTipoVehiculo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoVehiculo.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.Size = New System.Drawing.Size(300, 360)
        Me.grdTipoVehiculo.TabIndex = 141
        Me.grdTipoVehiculo.Text = "RadGridView1"
        Me.grdTipoVehiculo.ThemeName = "Office2007Black"
        '
        'lblEtiquetaFiltro2
        '
        Me.lblEtiquetaFiltro2.AutoSize = True
        Me.lblEtiquetaFiltro2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaFiltro2.ForeColor = System.Drawing.Color.DimGray
        Me.lblEtiquetaFiltro2.Location = New System.Drawing.Point(319, 14)
        Me.lblEtiquetaFiltro2.Name = "lblEtiquetaFiltro2"
        Me.lblEtiquetaFiltro2.Size = New System.Drawing.Size(67, 19)
        Me.lblEtiquetaFiltro2.TabIndex = 140
        Me.lblEtiquetaFiltro2.Text = "Modelos"
        '
        'lblGrid1
        '
        Me.lblGrid1.AutoSize = True
        Me.lblGrid1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrid1.ForeColor = System.Drawing.Color.DimGray
        Me.lblGrid1.Location = New System.Drawing.Point(14, 14)
        Me.lblGrid1.Name = "lblGrid1"
        Me.lblGrid1.Size = New System.Drawing.Size(121, 19)
        Me.lblGrid1.TabIndex = 131
        Me.lblGrid1.Text = "Tipo de Vehículo"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Controls.Add(Me.pnx0Facturar)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(483, 48)
        Me.pnlBarra.TabIndex = 163
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(367, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 117
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
        'pnx0Facturar
        '
        Me.pnx0Facturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Facturar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Facturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Facturar.Controls.Add(Me.lbl0Facturar)
        Me.pnx0Facturar.Controls.Add(Me.pbx0Facturar)
        Me.pnx0Facturar.Location = New System.Drawing.Point(254, 3)
        Me.pnx0Facturar.Name = "pnx0Facturar"
        Me.pnx0Facturar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Facturar.TabIndex = 116
        '
        'lbl0Facturar
        '
        Me.lbl0Facturar.AutoSize = True
        Me.lbl0Facturar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Facturar.ForeColor = System.Drawing.Color.White
        Me.lbl0Facturar.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Facturar.Name = "lbl0Facturar"
        Me.lbl0Facturar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Facturar.TabIndex = 72
        Me.lbl0Facturar.Text = "Guardar"
        '
        'pbx0Facturar
        '
        Me.pbx0Facturar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx0Facturar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Facturar.Name = "pbx0Facturar"
        Me.pbx0Facturar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Facturar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Facturar.TabIndex = 71
        Me.pbx0Facturar.TabStop = False
        '
        'frmFiltrosInventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(945, 471)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbProducto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFiltrosInventarios"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbProducto, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbProducto.ResumeLayout(False)
        Me.rgbProducto.PerformLayout()
        CType(Me.grdMarca.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Facturar.ResumeLayout(False)
        Me.pnx0Facturar.PerformLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbProducto As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosMarca As System.Windows.Forms.CheckBox
    Friend WithEvents grdMarca As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblEMarca As System.Windows.Forms.Label
    Friend WithEvents chkTodosModelo As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodosTipo As System.Windows.Forms.CheckBox
    Friend WithEvents grdModelos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblEtiquetaFiltro2 As System.Windows.Forms.Label
    Friend WithEvents lblGrid1 As System.Windows.Forms.Label
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Facturar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Facturar As System.Windows.Forms.Label
    Friend WithEvents pbx0Facturar As System.Windows.Forms.PictureBox

End Class
