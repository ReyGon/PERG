<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialPagos))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rgbEmpleados = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdPagos = New Telerik.WinControls.UI.RadGridView()
        Me.txtTasaCambio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rbListado = New System.Windows.Forms.RadioButton()
        Me.rbManual = New System.Windows.Forms.RadioButton()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbEmpleados.SuspendLayout()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPagos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Size = New System.Drawing.Size(452, 48)
        Me.pnlBarra.TabIndex = 109
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(330, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 177
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(48, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 66
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 65
        Me.pbx0Salir.TabStop = False
        '
        'rgbEmpleados
        '
        Me.rgbEmpleados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbEmpleados.Controls.Add(Me.grdPagos)
        Me.rgbEmpleados.FooterImageIndex = -1
        Me.rgbEmpleados.FooterImageKey = ""
        Me.rgbEmpleados.HeaderImageIndex = -1
        Me.rgbEmpleados.HeaderImageKey = ""
        Me.rgbEmpleados.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbEmpleados.HeaderText = "Pagos Proveedor"
        Me.rgbEmpleados.Location = New System.Drawing.Point(12, 103)
        Me.rgbEmpleados.Name = "rgbEmpleados"
        Me.rgbEmpleados.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbEmpleados.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbEmpleados.Size = New System.Drawing.Size(891, 322)
        Me.rgbEmpleados.TabIndex = 110
        Me.rgbEmpleados.Text = "Pagos Proveedor"
        Me.rgbEmpleados.ThemeName = "Office2007Black"
        '
        'grdPagos
        '
        Me.grdPagos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdPagos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPagos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdPagos.ForeColor = System.Drawing.Color.Black
        Me.grdPagos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdPagos.Location = New System.Drawing.Point(10, 20)
        '
        'grdPagos
        '
        Me.grdPagos.MasterTemplate.AllowAddNewRow = False
        Me.grdPagos.MasterTemplate.AllowColumnReorder = False
        Me.grdPagos.Name = "grdPagos"
        Me.grdPagos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPagos.ReadOnly = True
        Me.grdPagos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdPagos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdPagos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPagos.Size = New System.Drawing.Size(871, 292)
        Me.grdPagos.TabIndex = 0
        Me.grdPagos.Text = "Empleados"
        Me.grdPagos.ThemeName = "Office2007Black"
        '
        'txtTasaCambio
        '
        Me.txtTasaCambio.Enabled = False
        Me.txtTasaCambio.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtTasaCambio.Location = New System.Drawing.Point(436, 68)
        Me.txtTasaCambio.Name = "txtTasaCambio"
        Me.txtTasaCambio.Size = New System.Drawing.Size(206, 25)
        Me.txtTasaCambio.TabIndex = 185
        Me.txtTasaCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(353, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "Tasa Cambio :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(683, 58)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(104, 43)
        Me.btnAceptar.TabIndex = 183
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'rbListado
        '
        Me.rbListado.AutoSize = True
        Me.rbListado.Location = New System.Drawing.Point(82, 72)
        Me.rbListado.Name = "rbListado"
        Me.rbListado.Size = New System.Drawing.Size(62, 17)
        Me.rbListado.TabIndex = 186
        Me.rbListado.TabStop = True
        Me.rbListado.Text = "Listado"
        Me.rbListado.UseVisualStyleBackColor = True
        '
        'rbManual
        '
        Me.rbManual.AutoSize = True
        Me.rbManual.Location = New System.Drawing.Point(192, 72)
        Me.rbManual.Name = "rbManual"
        Me.rbManual.Size = New System.Drawing.Size(64, 17)
        Me.rbManual.TabIndex = 187
        Me.rbManual.TabStop = True
        Me.rbManual.Text = "Manual"
        Me.rbManual.UseVisualStyleBackColor = True
        '
        'frmHistorialPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(914, 437)
        Me.Controls.Add(Me.rbManual)
        Me.Controls.Add(Me.rbListado)
        Me.Controls.Add(Me.txtTasaCambio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rgbEmpleados)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHistorialPagos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbEmpleados, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtTasaCambio, 0)
        Me.Controls.SetChildIndex(Me.rbListado, 0)
        Me.Controls.SetChildIndex(Me.rbManual, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbEmpleados.ResumeLayout(False)
        CType(Me.grdPagos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbEmpleados As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdPagos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtTasaCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rbListado As System.Windows.Forms.RadioButton
    Friend WithEvents rbManual As System.Windows.Forms.RadioButton

End Class
