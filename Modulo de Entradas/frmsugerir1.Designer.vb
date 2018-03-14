<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsugerir1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmsugerir1))
        Me.pnlbarra2 = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProducto = New Telerik.WinControls.UI.RadGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBuscar1 = New System.Windows.Forms.TextBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlbarra2.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.grdProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProducto.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'pnlbarra2
        '
        Me.pnlbarra2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlbarra2.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlbarra2.Controls.Add(Me.pnx0Salir)
        Me.pnlbarra2.Location = New System.Drawing.Point(466, 0)
        Me.pnlbarra2.Name = "pnlbarra2"
        Me.pnlbarra2.Size = New System.Drawing.Size(374, 48)
        Me.pnlbarra2.TabIndex = 151
        '
        'pnx0Salir
        '
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(271, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(100, 40)
        Me.pnx0Salir.TabIndex = 84
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(50, 12)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(31, 15)
        Me.lbl0Salir.TabIndex = 66
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx0Salir.Location = New System.Drawing.Point(9, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 65
        Me.pbx0Salir.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Image = Global.laFuente.My.Resources.Resources.check1
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.Location = New System.Drawing.Point(686, 74)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(106, 59)
        Me.btnAceptar.TabIndex = 158
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(73, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 29)
        Me.Label7.TabIndex = 155
        Me.Label7.Text = "Información"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(25, 119)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 156
        Me.PictureBox4.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.BackColor = System.Drawing.Color.Transparent
        Me.rgbInformacion.Controls.Add(Me.grdProducto)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = "Creative player 256_green.png"
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 143)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(838, 236)
        Me.rgbInformacion.TabIndex = 154
        Me.rgbInformacion.ThemeName = "radGroupBoxAzul"
        '
        'grdProducto
        '
        Me.grdProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProducto.BackColor = System.Drawing.Color.White
        Me.grdProducto.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProducto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProducto.ForeColor = System.Drawing.Color.Gray
        Me.grdProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProducto.Location = New System.Drawing.Point(13, 23)
        '
        'grdProducto
        '
        Me.grdProducto.MasterTemplate.AllowAddNewRow = False
        Me.grdProducto.MasterTemplate.AllowDeleteRow = False
        Me.grdProducto.MasterTemplate.EnableGrouping = False
        Me.grdProducto.Name = "grdProducto"
        Me.grdProducto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProducto.ReadOnly = True
        Me.grdProducto.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProducto.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.grdProducto.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProducto.Size = New System.Drawing.Size(812, 200)
        Me.grdProducto.TabIndex = 212
        Me.grdProducto.Text = "Unidad de Medida"
        Me.grdProducto.ThemeName = "Office2007Black"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Image = Global.laFuente.My.Resources.Resources.buscar_Blanco
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(554, 74)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(106, 59)
        Me.btnBuscar.TabIndex = 157
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(97, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 153
        Me.Label10.Text = "Filtro :"
        '
        'txtBuscar1
        '
        Me.txtBuscar1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar1.Location = New System.Drawing.Point(154, 88)
        Me.txtBuscar1.Name = "txtBuscar1"
        Me.txtBuscar1.Size = New System.Drawing.Size(361, 23)
        Me.txtBuscar1.TabIndex = 152
        Me.txtBuscar1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmsugerir1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(876, 532)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBuscar1)
        Me.Controls.Add(Me.pnlbarra2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmsugerir1"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlbarra2, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar1, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.btnBuscar, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlbarra2.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        CType(Me.grdProducto.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlbarra2 As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdProducto As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar1 As System.Windows.Forms.TextBox

End Class
