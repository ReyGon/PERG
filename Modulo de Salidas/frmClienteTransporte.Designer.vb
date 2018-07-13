<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClienteTransporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClienteTransporte))
        Me.btnLocal = New System.Windows.Forms.Button()
        Me.btnTransporte = New System.Windows.Forms.Button()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'btnLocal
        '
        Me.btnLocal.BackColor = System.Drawing.Color.SteelBlue
        Me.btnLocal.FlatAppearance.BorderSize = 0
        Me.btnLocal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnLocal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLocal.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocal.ForeColor = System.Drawing.Color.Transparent
        Me.btnLocal.Location = New System.Drawing.Point(26, 57)
        Me.btnLocal.Name = "btnLocal"
        Me.btnLocal.Size = New System.Drawing.Size(183, 48)
        Me.btnLocal.TabIndex = 234
        Me.btnLocal.Text = "Local/Mostrador"
        Me.btnLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLocal.UseVisualStyleBackColor = False
        '
        'btnTransporte
        '
        Me.btnTransporte.BackColor = System.Drawing.Color.SteelBlue
        Me.btnTransporte.FlatAppearance.BorderSize = 0
        Me.btnTransporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnTransporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransporte.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransporte.ForeColor = System.Drawing.Color.Transparent
        Me.btnTransporte.Location = New System.Drawing.Point(254, 57)
        Me.btnTransporte.Name = "btnTransporte"
        Me.btnTransporte.Size = New System.Drawing.Size(183, 48)
        Me.btnTransporte.TabIndex = 235
        Me.btnTransporte.Text = "Transporte"
        Me.btnTransporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTransporte.UseVisualStyleBackColor = False
        '
        'frmClienteTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(467, 114)
        Me.Controls.Add(Me.btnTransporte)
        Me.Controls.Add(Me.btnLocal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClienteTransporte"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.btnLocal, 0)
        Me.Controls.SetChildIndex(Me.btnTransporte, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLocal As System.Windows.Forms.Button
    Friend WithEvents btnTransporte As System.Windows.Forms.Button

End Class
