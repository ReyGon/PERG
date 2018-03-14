<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoCierreCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoCierreCaja))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Size = New System.Drawing.Size(352, 48)
        Me.pnlBarra.TabIndex = 106
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(123, 4)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Guardar.TabIndex = 121
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(37, 0)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(66, 38)
        Me.lbl0Guardar.TabIndex = 72
        Me.lbl0Guardar.Text = "Cambiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Foto"
        Me.lbl0Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = Global.laFuente.My.Resources.Resources.fotoBlanco
        Me.pbx0Guardar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 71
        Me.pbx0Guardar.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(234, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 120
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
        'frmListadoCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(815, 400)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoCierreCaja"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox

End Class
