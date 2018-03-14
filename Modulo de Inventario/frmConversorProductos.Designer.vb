<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConversorProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConversorProductos))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.rgbClienteProductos = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbClienteProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbClienteProductos.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Size = New System.Drawing.Size(501, 48)
        Me.pnlBarra.TabIndex = 192
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(264, 3)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(113, 40)
        Me.pnx0Guardar.TabIndex = 92
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = Global.laFuente.My.Resources.Resources.conceptos_Blanco
        Me.pbx0Guardar.Location = New System.Drawing.Point(1, 2)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 69
        Me.pbx0Guardar.TabStop = False
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(40, 11)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(65, 17)
        Me.lbl0Guardar.TabIndex = 70
        Me.lbl0Guardar.Text = "Convertir"
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(383, 3)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(106, 40)
        Me.pnx1Salir.TabIndex = 90
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 69
        Me.pbx1Salir.TabStop = False
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 70
        Me.lbl1Salir.Text = "Salir"
        '
        'rgbClienteProductos
        '
        Me.rgbClienteProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbClienteProductos.Controls.Add(Me.grdProductos)
        Me.rgbClienteProductos.FooterImageIndex = -1
        Me.rgbClienteProductos.FooterImageKey = ""
        Me.rgbClienteProductos.HeaderImageIndex = -1
        Me.rgbClienteProductos.HeaderImageKey = ""
        Me.rgbClienteProductos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbClienteProductos.HeaderText = "Productos"
        Me.rgbClienteProductos.Location = New System.Drawing.Point(-1, 54)
        Me.rgbClienteProductos.Name = "rgbClienteProductos"
        Me.rgbClienteProductos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbClienteProductos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbClienteProductos.Size = New System.Drawing.Size(968, 325)
        Me.rgbClienteProductos.TabIndex = 215
        Me.rgbClienteProductos.Text = "Productos"
        '
        'grdProductos
        '
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Location = New System.Drawing.Point(10, 20)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AllowColumnReorder = False
        Me.grdProductos.MasterTemplate.AllowDeleteRow = False
        GridViewTextBoxColumn1.HeaderText = "idArticulo"
        GridViewTextBoxColumn1.Name = "id"
        GridViewTextBoxColumn2.HeaderText = "Codigo Articulo"
        GridViewTextBoxColumn2.Name = "txmCodigo"
        GridViewTextBoxColumn3.HeaderText = "Articulo"
        GridViewTextBoxColumn3.Name = "txbArticulo"
        GridViewTextBoxColumn4.HeaderText = "Tipo Articulo"
        GridViewTextBoxColumn4.Name = "tipoArticulo"
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.ReadOnly = True
        '
        '
        '
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(948, 295)
        Me.grdProductos.TabIndex = 1
        Me.grdProductos.Text = "Clientes Productos"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'frmConversorProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(968, 383)
        Me.Controls.Add(Me.rgbClienteProductos)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConversorProductos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbClienteProductos, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbClienteProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbClienteProductos.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents rgbClienteProductos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdProductos As Telerik.WinControls.UI.RadGridView

End Class
