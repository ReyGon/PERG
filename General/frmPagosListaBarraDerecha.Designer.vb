<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosListaBarraDerecha
    Inherits laFuente.FrmBarraLateral

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
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.pbx1 = New System.Windows.Forms.PictureBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.pnl2Boleta = New System.Windows.Forms.Panel()
        Me.pbx2Boleta = New System.Windows.Forms.PictureBox()
        Me.lbl2Boleta = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl1.SuspendLayout()
        CType(Me.pbx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl2Boleta.SuspendLayout()
        CType(Me.pbx2Boleta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(46, 303)
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(5, 292)
        '
        'pnl1
        '
        Me.pnl1.BackColor = System.Drawing.Color.SteelBlue
        Me.pnl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnl1.Controls.Add(Me.pbx1)
        Me.pnl1.Controls.Add(Me.lbl1)
        Me.pnl1.Location = New System.Drawing.Point(17, 115)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(98, 77)
        Me.pnl1.TabIndex = 66
        '
        'pbx1
        '
        Me.pbx1.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx1.Location = New System.Drawing.Point(27, 8)
        Me.pbx1.Name = "pbx1"
        Me.pbx1.Size = New System.Drawing.Size(46, 39)
        Me.pbx1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1.TabIndex = 64
        Me.pbx1.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.White
        Me.lbl1.Location = New System.Drawing.Point(15, 50)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(70, 19)
        Me.lbl1.TabIndex = 63
        Me.lbl1.Text = "Rechazar"
        '
        'pnl2Boleta
        '
        Me.pnl2Boleta.BackColor = System.Drawing.Color.SteelBlue
        Me.pnl2Boleta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnl2Boleta.Controls.Add(Me.pbx2Boleta)
        Me.pnl2Boleta.Controls.Add(Me.lbl2Boleta)
        Me.pnl2Boleta.Location = New System.Drawing.Point(16, 200)
        Me.pnl2Boleta.Name = "pnl2Boleta"
        Me.pnl2Boleta.Size = New System.Drawing.Size(98, 77)
        Me.pnl2Boleta.TabIndex = 67
        '
        'pbx2Boleta
        '
        Me.pbx2Boleta.Image = Global.laFuente.My.Resources.Resources.pagos_Blanco
        Me.pbx2Boleta.Location = New System.Drawing.Point(27, 5)
        Me.pbx2Boleta.Name = "pbx2Boleta"
        Me.pbx2Boleta.Size = New System.Drawing.Size(46, 39)
        Me.pbx2Boleta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Boleta.TabIndex = 64
        Me.pbx2Boleta.TabStop = False
        '
        'lbl2Boleta
        '
        Me.lbl2Boleta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2Boleta.AutoSize = True
        Me.lbl2Boleta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Boleta.ForeColor = System.Drawing.Color.White
        Me.lbl2Boleta.Location = New System.Drawing.Point(17, 46)
        Me.lbl2Boleta.Name = "lbl2Boleta"
        Me.lbl2Boleta.Size = New System.Drawing.Size(61, 30)
        Me.lbl2Boleta.TabIndex = 63
        Me.lbl2Boleta.Text = "Registrar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Boleta"
        Me.lbl2Boleta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPagosListaBarraDerecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(135, 740)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnl2Boleta)
        Me.Controls.Add(Me.pnl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPagosListaBarraDerecha"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.lbTituloFrm, 0)
        Me.Controls.SetChildIndex(Me.PictureBox2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.pnl1, 0)
        Me.Controls.SetChildIndex(Me.pnl2Boleta, 0)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        CType(Me.pbx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl2Boleta.ResumeLayout(False)
        Me.pnl2Boleta.PerformLayout()
        CType(Me.pbx2Boleta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents pbx1 As System.Windows.Forms.PictureBox
    Public WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents pnl2Boleta As System.Windows.Forms.Panel
    Friend WithEvents pbx2Boleta As System.Windows.Forms.PictureBox
    Public WithEvents lbl2Boleta As System.Windows.Forms.Label

End Class
