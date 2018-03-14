<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDescuentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDescuentos))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.rbtPorcentaje = New System.Windows.Forms.RadioButton()
        Me.rbtValor = New System.Windows.Forms.RadioButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rgbCostos = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnQuitarDescuento = New System.Windows.Forms.Button()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDescuento = New System.Windows.Forms.ComboBox()
        Me.btnAgregarDescuento = New System.Windows.Forms.Button()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbCostos.SuspendLayout()
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
        Me.pnlBarra.Size = New System.Drawing.Size(118, 48)
        Me.pnlBarra.TabIndex = 191
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(5, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(106, 40)
        Me.pnx0Salir.TabIndex = 90
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 69
        Me.pbx0Salir.TabStop = False
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 70
        Me.lbl0Salir.Text = "Salir"
        '
        'rbtPorcentaje
        '
        Me.rbtPorcentaje.AutoSize = True
        Me.rbtPorcentaje.Location = New System.Drawing.Point(306, 17)
        Me.rbtPorcentaje.Name = "rbtPorcentaje"
        Me.rbtPorcentaje.Size = New System.Drawing.Size(79, 17)
        Me.rbtPorcentaje.TabIndex = 193
        Me.rbtPorcentaje.TabStop = True
        Me.rbtPorcentaje.Text = "Porcentaje"
        Me.rbtPorcentaje.UseVisualStyleBackColor = True
        '
        'rbtValor
        '
        Me.rbtValor.AutoSize = True
        Me.rbtValor.Location = New System.Drawing.Point(158, 17)
        Me.rbtValor.Name = "rbtValor"
        Me.rbtValor.Size = New System.Drawing.Size(52, 17)
        Me.rbtValor.TabIndex = 192
        Me.rbtValor.TabStop = True
        Me.rbtValor.Text = "Valor"
        Me.rbtValor.UseVisualStyleBackColor = True
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.dinero_gris
        Me.PictureBox5.Location = New System.Drawing.Point(25, 51)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(44, 40)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 195
        Me.PictureBox5.TabStop = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(69, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 24)
        Me.Label16.TabIndex = 194
        Me.Label16.Text = "Tipos"
        '
        'rgbCostos
        '
        Me.rgbCostos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbCostos.BackColor = System.Drawing.Color.Transparent
        Me.rgbCostos.Controls.Add(Me.btnQuitarDescuento)
        Me.rgbCostos.Controls.Add(Me.txtValor)
        Me.rgbCostos.Controls.Add(Me.Label3)
        Me.rgbCostos.Controls.Add(Me.Label2)
        Me.rgbCostos.Controls.Add(Me.cmbDescuento)
        Me.rgbCostos.Controls.Add(Me.btnAgregarDescuento)
        Me.rgbCostos.Controls.Add(Me.rbtPorcentaje)
        Me.rgbCostos.Controls.Add(Me.rbtValor)
        Me.rgbCostos.FooterImageIndex = -1
        Me.rgbCostos.FooterImageKey = ""
        Me.rgbCostos.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbCostos.HeaderImageIndex = -1
        Me.rgbCostos.HeaderImageKey = "dinero.png"
        Me.rgbCostos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbCostos.HeaderText = ""
        Me.rgbCostos.Location = New System.Drawing.Point(3, 67)
        Me.rgbCostos.Name = "rgbCostos"
        Me.rgbCostos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbCostos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbCostos.Size = New System.Drawing.Size(575, 118)
        Me.rgbCostos.TabIndex = 196
        Me.rgbCostos.ThemeName = "radGroupBoxAzul"
        '
        'btnQuitarDescuento
        '
        Me.btnQuitarDescuento.BackColor = System.Drawing.Color.SteelBlue
        Me.btnQuitarDescuento.FlatAppearance.BorderSize = 0
        Me.btnQuitarDescuento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnQuitarDescuento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnQuitarDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitarDescuento.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarDescuento.ForeColor = System.Drawing.Color.Transparent
        Me.btnQuitarDescuento.Location = New System.Drawing.Point(438, 74)
        Me.btnQuitarDescuento.Name = "btnQuitarDescuento"
        Me.btnQuitarDescuento.Size = New System.Drawing.Size(124, 38)
        Me.btnQuitarDescuento.TabIndex = 204
        Me.btnQuitarDescuento.Text = "Quitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Descuento"
        Me.btnQuitarDescuento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuitarDescuento.UseVisualStyleBackColor = False
        '
        'txtValor
        '
        Me.txtValor.Enabled = False
        Me.txtValor.Location = New System.Drawing.Point(240, 85)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(100, 20)
        Me.txtValor.TabIndex = 203
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(121, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 202
        Me.Label3.Text = "Valor Descuento :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Descuento :"
        '
        'cmbDescuento
        '
        Me.cmbDescuento.FormattingEnabled = True
        Me.cmbDescuento.Location = New System.Drawing.Point(105, 50)
        Me.cmbDescuento.Name = "cmbDescuento"
        Me.cmbDescuento.Size = New System.Drawing.Size(316, 21)
        Me.cmbDescuento.TabIndex = 198
        '
        'btnAgregarDescuento
        '
        Me.btnAgregarDescuento.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregarDescuento.FlatAppearance.BorderSize = 0
        Me.btnAgregarDescuento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregarDescuento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregarDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarDescuento.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarDescuento.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregarDescuento.Image = Global.laFuente.My.Resources.Resources.aceptarBlanco
        Me.btnAgregarDescuento.Location = New System.Drawing.Point(438, 8)
        Me.btnAgregarDescuento.Name = "btnAgregarDescuento"
        Me.btnAgregarDescuento.Size = New System.Drawing.Size(124, 62)
        Me.btnAgregarDescuento.TabIndex = 197
        Me.btnAgregarDescuento.Text = "Aceptar"
        Me.btnAgregarDescuento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarDescuento.UseVisualStyleBackColor = False
        '
        'frmDescuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(583, 188)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.rgbCostos)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDescuentos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbCostos, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbCostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbCostos.ResumeLayout(False)
        Me.rgbCostos.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents rbtPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents rbtValor As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents rgbCostos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnAgregarDescuento As System.Windows.Forms.Button
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDescuento As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuitarDescuento As System.Windows.Forms.Button

End Class
