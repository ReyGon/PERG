<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoImpresiones
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoImpresiones))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Imprimir = New System.Windows.Forms.Panel()
        Me.lbl0Imprimir = New System.Windows.Forms.Label()
        Me.pbx0Imprimir = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Imprimir.SuspendLayout()
        CType(Me.pbx0Imprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Imprimir)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(343, 48)
        Me.pnlBarra.TabIndex = 106
        '
        'pnx0Imprimir
        '
        Me.pnx0Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Imprimir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Imprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Imprimir.Controls.Add(Me.lbl0Imprimir)
        Me.pnx0Imprimir.Controls.Add(Me.pbx0Imprimir)
        Me.pnx0Imprimir.Location = New System.Drawing.Point(113, 4)
        Me.pnx0Imprimir.Name = "pnx0Imprimir"
        Me.pnx0Imprimir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Imprimir.TabIndex = 118
        '
        'lbl0Imprimir
        '
        Me.lbl0Imprimir.AutoSize = True
        Me.lbl0Imprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Imprimir.ForeColor = System.Drawing.Color.White
        Me.lbl0Imprimir.Location = New System.Drawing.Point(46, 5)
        Me.lbl0Imprimir.Name = "lbl0Imprimir"
        Me.lbl0Imprimir.Size = New System.Drawing.Size(54, 30)
        Me.lbl0Imprimir.TabIndex = 76
        Me.lbl0Imprimir.Text = "Docs de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Salida"
        Me.lbl0Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx0Imprimir
        '
        Me.pbx0Imprimir.Image = Global.laFuente.My.Resources.Resources.entrada_Blanco
        Me.pbx0Imprimir.Location = New System.Drawing.Point(4, 3)
        Me.pbx0Imprimir.Name = "pbx0Imprimir"
        Me.pbx0Imprimir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Imprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Imprimir.TabIndex = 75
        Me.pbx0Imprimir.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(226, 4)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(71, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 25)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Lista"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox3.Location = New System.Drawing.Point(28, 59)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 190
        Me.PictureBox3.TabStop = False
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.grdDatos)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(7, 78)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(792, 442)
        Me.RadGroupBox1.TabIndex = 189
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDatos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdDatos.Location = New System.Drawing.Point(13, 23)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        GridViewTextBoxColumn1.HeaderText = "iddetalle"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "iddetalle"
        GridViewTextBoxColumn1.Width = 64
        GridViewTextBoxColumn2.HeaderText = "Fecha de Registro"
        GridViewTextBoxColumn2.Name = "fecha"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 107
        GridViewTextBoxColumn3.HeaderText = "Tipo de Impresión"
        GridViewTextBoxColumn3.Name = "tipo"
        GridViewTextBoxColumn3.ReadOnly = True
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn3.Width = 119
        GridViewTextBoxColumn4.HeaderText = "Descripción"
        GridViewTextBoxColumn4.Name = "descripcion"
        GridViewTextBoxColumn4.ReadOnly = True
        GridViewTextBoxColumn4.Width = 171
        GridViewTextBoxColumn5.HeaderText = "Usuario Reigstro"
        GridViewTextBoxColumn5.Name = "usuarioRegistro"
        GridViewTextBoxColumn5.ReadOnly = True
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn5.Width = 95
        GridViewTextBoxColumn6.HeaderText = "Usuario Imprimio"
        GridViewTextBoxColumn6.Name = "usuarioImprime"
        GridViewTextBoxColumn6.ReadOnly = True
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn6.Width = 96
        GridViewCheckBoxColumn1.HeaderText = "Impreso"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "impreso"
        GridViewCheckBoxColumn1.ReadOnly = True
        GridViewCheckBoxColumn1.Width = 57
        Me.grdDatos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewCheckBoxColumn1})
        Me.grdDatos.MasterTemplate.EnableGrouping = False
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdDatos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(766, 419)
        Me.grdDatos.TabIndex = 0
        Me.grdDatos.Text = "RadGridView1"
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'frmListadoImpresiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(804, 532)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoImpresiones"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Imprimir.ResumeLayout(False)
        Me.pnx0Imprimir.PerformLayout()
        CType(Me.pbx0Imprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Imprimir As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lbl0Imprimir As System.Windows.Forms.Label
    Friend WithEvents pbx0Imprimir As System.Windows.Forms.PictureBox

End Class
