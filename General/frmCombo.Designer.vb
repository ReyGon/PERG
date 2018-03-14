<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCombo
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
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.combo = New System.Windows.Forms.ComboBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.btnImportar)
        Me.RadGroupBox1.Controls.Add(Me.lblTitulo)
        Me.RadGroupBox1.Controls.Add(Me.combo)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = "dinero.png"
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(3, 81)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(313, 145)
        Me.RadGroupBox1.TabIndex = 80
        Me.RadGroupBox1.ThemeName = "radGroupBoxAzul"
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
        Me.btnImportar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnImportar.Location = New System.Drawing.Point(82, 83)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(142, 55)
        Me.btnImportar.TabIndex = 175
        Me.btnImportar.Text = "  Agregar "
        Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTitulo.Location = New System.Drawing.Point(117, 28)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(76, 19)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Seleccionar"
        '
        'combo
        '
        Me.combo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.combo.FormattingEnabled = True
        Me.combo.Location = New System.Drawing.Point(13, 50)
        Me.combo.Name = "combo"
        Me.combo.Size = New System.Drawing.Size(287, 21)
        Me.combo.TabIndex = 0
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox5.Location = New System.Drawing.Point(16, 64)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 74
        Me.PictureBox5.TabStop = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(57, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 29)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Informacion"
        '
        'frmCombo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(319, 228)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Name = "frmCombo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents combo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnImportar As System.Windows.Forms.Button

End Class
