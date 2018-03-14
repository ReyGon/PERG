<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizadorCreador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActualizadorCreador))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Bodega = New System.Windows.Forms.Panel()
        Me.lbl0Bodega = New System.Windows.Forms.Label()
        Me.pbx0Bodega = New System.Windows.Forms.PictureBox()
        Me.rbtnPrecios = New System.Windows.Forms.RadioButton()
        Me.rbtnArticulos = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Bodega.SuspendLayout()
        CType(Me.pbx0Bodega, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Bodega)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(128, 48)
        Me.pnlBarra.TabIndex = 183
        '
        'pnx0Bodega
        '
        Me.pnx0Bodega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Bodega.BackColor = System.Drawing.Color.Navy
        Me.pnx0Bodega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Bodega.Controls.Add(Me.lbl0Bodega)
        Me.pnx0Bodega.Controls.Add(Me.pbx0Bodega)
        Me.pnx0Bodega.Location = New System.Drawing.Point(23, 4)
        Me.pnx0Bodega.Name = "pnx0Bodega"
        Me.pnx0Bodega.Size = New System.Drawing.Size(94, 39)
        Me.pnx0Bodega.TabIndex = 200
        '
        'lbl0Bodega
        '
        Me.lbl0Bodega.AutoSize = True
        Me.lbl0Bodega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Bodega.ForeColor = System.Drawing.Color.White
        Me.lbl0Bodega.Location = New System.Drawing.Point(52, 12)
        Me.lbl0Bodega.Name = "lbl0Bodega"
        Me.lbl0Bodega.Size = New System.Drawing.Size(31, 15)
        Me.lbl0Bodega.TabIndex = 72
        Me.lbl0Bodega.Text = "Salir"
        Me.lbl0Bodega.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx0Bodega
        '
        Me.pbx0Bodega.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Bodega.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Bodega.Name = "pbx0Bodega"
        Me.pbx0Bodega.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Bodega.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Bodega.TabIndex = 71
        Me.pbx0Bodega.TabStop = False
        '
        'rbtnPrecios
        '
        Me.rbtnPrecios.AutoSize = True
        Me.rbtnPrecios.Location = New System.Drawing.Point(49, 78)
        Me.rbtnPrecios.Name = "rbtnPrecios"
        Me.rbtnPrecios.Size = New System.Drawing.Size(114, 17)
        Me.rbtnPrecios.TabIndex = 184
        Me.rbtnPrecios.TabStop = True
        Me.rbtnPrecios.Text = "Actualizar Precios"
        Me.rbtnPrecios.UseVisualStyleBackColor = True
        '
        'rbtnArticulos
        '
        Me.rbtnArticulos.AutoSize = True
        Me.rbtnArticulos.Location = New System.Drawing.Point(308, 78)
        Me.rbtnArticulos.Name = "rbtnArticulos"
        Me.rbtnArticulos.Size = New System.Drawing.Size(100, 17)
        Me.rbtnArticulos.TabIndex = 185
        Me.rbtnArticulos.TabStop = True
        Me.rbtnArticulos.Text = "Crear Articulos"
        Me.rbtnArticulos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "Sucursal :"
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(108, 128)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(297, 20)
        Me.txtSucursal.TabIndex = 187
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEjecutar.FlatAppearance.BorderSize = 0
        Me.btnEjecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnEjecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEjecutar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnEjecutar.ForeColor = System.Drawing.Color.Transparent
        Me.btnEjecutar.Image = Global.laFuente.My.Resources.Resources.aceptarBlanco
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEjecutar.Location = New System.Drawing.Point(466, 78)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(117, 79)
        Me.btnEjecutar.TabIndex = 188
        Me.btnEjecutar.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ejecutar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'frmActualizadorCreador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(595, 181)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rbtnArticulos)
        Me.Controls.Add(Me.rbtnPrecios)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmActualizadorCreador"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rbtnPrecios, 0)
        Me.Controls.SetChildIndex(Me.rbtnArticulos, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtSucursal, 0)
        Me.Controls.SetChildIndex(Me.btnEjecutar, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Bodega.ResumeLayout(False)
        Me.pnx0Bodega.PerformLayout()
        CType(Me.pbx0Bodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Bodega As System.Windows.Forms.Panel
    Friend WithEvents lbl0Bodega As System.Windows.Forms.Label
    Friend WithEvents pbx0Bodega As System.Windows.Forms.PictureBox
    Friend WithEvents rbtnPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnArticulos As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button

End Class
