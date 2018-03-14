<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpresionGuias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpresionGuias))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.btnGuatex = New System.Windows.Forms.Button()
        Me.btnCargoExpress = New System.Windows.Forms.Button()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Size = New System.Drawing.Size(145, 48)
        Me.pnlBarra.TabIndex = 185
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(26, 3)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 195
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 72
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 71
        Me.pbx0Salir.TabStop = False
        '
        'btnGuatex
        '
        Me.btnGuatex.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGuatex.FlatAppearance.BorderSize = 0
        Me.btnGuatex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuatex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuatex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuatex.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuatex.ForeColor = System.Drawing.Color.Transparent
        Me.btnGuatex.Location = New System.Drawing.Point(62, 97)
        Me.btnGuatex.Name = "btnGuatex"
        Me.btnGuatex.Size = New System.Drawing.Size(227, 48)
        Me.btnGuatex.TabIndex = 234
        Me.btnGuatex.Text = "GuatEx"
        Me.btnGuatex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGuatex.UseVisualStyleBackColor = False
        '
        'btnCargoExpress
        '
        Me.btnCargoExpress.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCargoExpress.FlatAppearance.BorderSize = 0
        Me.btnCargoExpress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCargoExpress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCargoExpress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargoExpress.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargoExpress.ForeColor = System.Drawing.Color.Transparent
        Me.btnCargoExpress.Location = New System.Drawing.Point(326, 97)
        Me.btnCargoExpress.Name = "btnCargoExpress"
        Me.btnCargoExpress.Size = New System.Drawing.Size(227, 48)
        Me.btnCargoExpress.TabIndex = 235
        Me.btnCargoExpress.Text = "CargoExpress"
        Me.btnCargoExpress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCargoExpress.UseVisualStyleBackColor = False
        '
        'frmImpresionGuias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(614, 186)
        Me.Controls.Add(Me.btnCargoExpress)
        Me.Controls.Add(Me.btnGuatex)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImpresionGuias"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.btnGuatex, 0)
        Me.Controls.SetChildIndex(Me.btnCargoExpress, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents btnGuatex As System.Windows.Forms.Button
    Friend WithEvents btnCargoExpress As System.Windows.Forms.Button

End Class
