<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespachoFacturaProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDespachoFacturaProductos))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rgbListadoProductos = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdListadoProductos = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbListadoProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbListadoProductos.SuspendLayout()
        CType(Me.grdListadoProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListadoProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(565, 48)
        Me.pnlBarra.TabIndex = 108
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(443, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 177
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(48, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 66
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 65
        Me.pbx0Salir.TabStop = False
        '
        'rgbListadoProductos
        '
        Me.rgbListadoProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbListadoProductos.Controls.Add(Me.grdListadoProductos)
        Me.rgbListadoProductos.FooterImageIndex = -1
        Me.rgbListadoProductos.FooterImageKey = ""
        Me.rgbListadoProductos.HeaderImageIndex = -1
        Me.rgbListadoProductos.HeaderImageKey = ""
        Me.rgbListadoProductos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbListadoProductos.HeaderText = "Listado de Productos"
        Me.rgbListadoProductos.Location = New System.Drawing.Point(12, 54)
        Me.rgbListadoProductos.Name = "rgbListadoProductos"
        Me.rgbListadoProductos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbListadoProductos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbListadoProductos.Size = New System.Drawing.Size(1004, 358)
        Me.rgbListadoProductos.TabIndex = 109
        Me.rgbListadoProductos.Text = "Listado de Productos"
        '
        'grdListadoProductos
        '
        Me.grdListadoProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdListadoProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdListadoProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadoProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdListadoProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdListadoProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdListadoProductos.Location = New System.Drawing.Point(10, 20)
        '
        'grdListadoProductos
        '
        Me.grdListadoProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdListadoProductos.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.HeaderText = "Cliente"
        GridViewTextBoxColumn1.Name = "Cliente"
        GridViewTextBoxColumn1.Width = 181
        GridViewTextBoxColumn2.HeaderText = "Doc"
        GridViewTextBoxColumn2.Name = "Doc"
        GridViewTextBoxColumn2.Width = 64
        GridViewTextBoxColumn3.HeaderText = "Ubicacion"
        GridViewTextBoxColumn3.Name = "Ubicacion"
        GridViewTextBoxColumn3.Width = 189
        GridViewTextBoxColumn4.HeaderText = "Codigo"
        GridViewTextBoxColumn4.Name = "Codigo"
        GridViewTextBoxColumn4.Width = 65
        GridViewTextBoxColumn5.HeaderText = "Producto"
        GridViewTextBoxColumn5.Name = "Producto"
        GridViewTextBoxColumn5.Width = 174
        GridViewTextBoxColumn6.HeaderText = "Cantidad"
        GridViewTextBoxColumn6.Name = "Cantidad"
        GridViewTextBoxColumn6.Width = 60
        Me.grdListadoProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.grdListadoProductos.Name = "grdListadoProductos"
        Me.grdListadoProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdListadoProductos.ReadOnly = True
        Me.grdListadoProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdListadoProductos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdListadoProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdListadoProductos.Size = New System.Drawing.Size(984, 328)
        Me.grdListadoProductos.TabIndex = 0
        Me.grdListadoProductos.Text = "Listado de Productos"
        Me.grdListadoProductos.ThemeName = "Office2007Black"
        '
        'frmDespachoFacturaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1026, 424)
        Me.Controls.Add(Me.rgbListadoProductos)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDespachoFacturaProductos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbListadoProductos, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbListadoProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbListadoProductos.ResumeLayout(False)
        CType(Me.grdListadoProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListadoProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbListadoProductos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdListadoProductos As Telerik.WinControls.UI.RadGridView

End Class
