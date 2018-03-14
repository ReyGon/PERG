<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBarraLateral
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbTituloFrm = New System.Windows.Forms.Label()
        Me.pnl0Cerrar = New System.Windows.Forms.Panel()
        Me.pbx0Cerrar = New System.Windows.Forms.PictureBox()
        Me.lbl0Cerrar = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnl0Cerrar.SuspendLayout()
        CType(Me.pbx0Cerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.AutoSize = True
        Me.lbTituloFrm.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lbTituloFrm.ForeColor = System.Drawing.Color.White
        Me.lbTituloFrm.Location = New System.Drawing.Point(16, 4)
        Me.lbTituloFrm.Name = "lbTituloFrm"
        Me.lbTituloFrm.Size = New System.Drawing.Size(94, 25)
        Me.lbTituloFrm.TabIndex = 55
        Me.lbTituloFrm.Text = "Opciones"
        Me.lbTituloFrm.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnl0Cerrar
        '
        Me.pnl0Cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnl0Cerrar.Controls.Add(Me.pbx0Cerrar)
        Me.pnl0Cerrar.Controls.Add(Me.lbl0Cerrar)
        Me.pnl0Cerrar.Location = New System.Drawing.Point(14, 34)
        Me.pnl0Cerrar.Name = "pnl0Cerrar"
        Me.pnl0Cerrar.Size = New System.Drawing.Size(100, 31)
        Me.pnl0Cerrar.TabIndex = 60
        '
        'pbx0Cerrar
        '
        Me.pbx0Cerrar.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Cerrar.Location = New System.Drawing.Point(3, 3)
        Me.pbx0Cerrar.Name = "pbx0Cerrar"
        Me.pbx0Cerrar.Size = New System.Drawing.Size(29, 26)
        Me.pbx0Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Cerrar.TabIndex = 70
        Me.pbx0Cerrar.TabStop = False
        '
        'lbl0Cerrar
        '
        Me.lbl0Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl0Cerrar.AutoSize = True
        Me.lbl0Cerrar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Cerrar.ForeColor = System.Drawing.Color.White
        Me.lbl0Cerrar.Location = New System.Drawing.Point(36, 6)
        Me.lbl0Cerrar.Name = "lbl0Cerrar"
        Me.lbl0Cerrar.Size = New System.Drawing.Size(52, 19)
        Me.lbl0Cerrar.TabIndex = 69
        Me.lbl0Cerrar.Text = "Cerrar"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.laFuente.My.Resources.Resources.barra
        Me.PictureBox2.Location = New System.Drawing.Point(5, 75)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(116, 10)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 62
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.barra
        Me.PictureBox3.Location = New System.Drawing.Point(5, 128)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(116, 10)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 63
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Acción"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(46, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 20)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Info"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FrmBarraLateral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(127, 706)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pnl0Cerrar)
        Me.Controls.Add(Me.lbTituloFrm)
        Me.Name = "FrmBarraLateral"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Opciones"
        Me.pnl0Cerrar.ResumeLayout(False)
        Me.pnl0Cerrar.PerformLayout()
        CType(Me.pbx0Cerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lbTituloFrm As System.Windows.Forms.Label
    Friend WithEvents pnl0Cerrar As System.Windows.Forms.Panel
    Friend WithEvents pbx0Cerrar As System.Windows.Forms.PictureBox
    Public WithEvents lbl0Cerrar As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Protected WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class

