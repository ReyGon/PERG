<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreformasImportacion
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreformasImportacion))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Facturar = New System.Windows.Forms.Panel()
        Me.lbl0Facturar = New System.Windows.Forms.Label()
        Me.pbx0Facturar = New System.Windows.Forms.PictureBox()
        Me.grdPreformasImportaciones = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Facturar.SuspendLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPreformasImportaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPreformasImportaciones.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Controls.Add(Me.pnx0Facturar)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(408, 48)
        Me.pnlBarra.TabIndex = 156
        '
        'pnx1Salir
        '
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(294, 4)
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
        Me.pnx0Facturar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Facturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Facturar.Controls.Add(Me.lbl0Facturar)
        Me.pnx0Facturar.Controls.Add(Me.pbx0Facturar)
        Me.pnx0Facturar.Location = New System.Drawing.Point(181, 3)
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
        'grdPreformasImportaciones
        '
        Me.grdPreformasImportaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdPreformasImportaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdPreformasImportaciones.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdPreformasImportaciones.ForeColor = System.Drawing.Color.Black
        Me.grdPreformasImportaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdPreformasImportaciones.Location = New System.Drawing.Point(2, 56)
        '
        'grdPreformasImportaciones
        '
        Me.grdPreformasImportaciones.MasterTemplate.AllowAddNewRow = False
        Me.grdPreformasImportaciones.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.HeaderText = "IdPreforma"
        GridViewTextBoxColumn1.Name = "IdPreforma"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewCheckBoxColumn1.HeaderText = "Elegir"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmElegir"
        GridViewTextBoxColumn2.HeaderText = "Fecha"
        GridViewTextBoxColumn2.Name = "Fecha"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 75
        GridViewTextBoxColumn3.HeaderText = "Proveedor"
        GridViewTextBoxColumn3.Name = "Proveedor"
        GridViewTextBoxColumn3.ReadOnly = True
        GridViewTextBoxColumn4.HeaderText = "Documento"
        GridViewTextBoxColumn4.Name = "Documento"
        Me.grdPreformasImportaciones.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewCheckBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.grdPreformasImportaciones.Name = "grdPreformasImportaciones"
        Me.grdPreformasImportaciones.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPreformasImportaciones.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdPreformasImportaciones.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdPreformasImportaciones.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPreformasImportaciones.Size = New System.Drawing.Size(865, 350)
        Me.grdPreformasImportaciones.TabIndex = 157
        Me.grdPreformasImportaciones.Text = "Empleados"
        Me.grdPreformasImportaciones.ThemeName = "Office2007Black"
        '
        'frmPreformasImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(872, 416)
        Me.Controls.Add(Me.grdPreformasImportaciones)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreformasImportacion"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.grdPreformasImportaciones, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Facturar.ResumeLayout(False)
        Me.pnx0Facturar.PerformLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPreformasImportaciones.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPreformasImportaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Facturar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Facturar As System.Windows.Forms.Label
    Friend WithEvents pbx0Facturar As System.Windows.Forms.PictureBox
    Friend WithEvents grdPreformasImportaciones As Telerik.WinControls.UI.RadGridView

End Class
