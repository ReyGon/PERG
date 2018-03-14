<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleTelefono
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleTelefono))
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        Me.pbBuscarProducto = New System.Windows.Forms.PictureBox()
        Me.lblProductos = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBuscarProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.txtObservacion)
        Me.rgbInformacion.Controls.Add(Me.btnAgregar)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.txtTelefono)
        Me.rgbInformacion.Controls.Add(Me.grdDatos)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(5, 77)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(458, 182)
        Me.rgbInformacion.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Observación :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(17, 75)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(150, 62)
        Me.txtObservacion.TabIndex = 76
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold)
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Location = New System.Drawing.Point(17, 143)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(150, 26)
        Me.btnAgregar.TabIndex = 75
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Teléfono :"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(17, 36)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(150, 20)
        Me.txtTelefono.TabIndex = 1
        '
        'grdDatos
        '
        Me.grdDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDatos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdDatos.Location = New System.Drawing.Point(176, 19)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        Me.grdDatos.MasterTemplate.EnableGrouping = False
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdDatos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(269, 150)
        Me.grdDatos.TabIndex = 0
        Me.grdDatos.Text = " "
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'pbBuscarProducto
        '
        Me.pbBuscarProducto.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.pbBuscarProducto.Location = New System.Drawing.Point(25, 55)
        Me.pbBuscarProducto.Name = "pbBuscarProducto"
        Me.pbBuscarProducto.Size = New System.Drawing.Size(40, 33)
        Me.pbBuscarProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBuscarProducto.TabIndex = 75
        Me.pbBuscarProducto.TabStop = False
        '
        'lblProductos
        '
        Me.lblProductos.AutoSize = True
        Me.lblProductos.BackColor = System.Drawing.Color.Transparent
        Me.lblProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductos.ForeColor = System.Drawing.Color.DimGray
        Me.lblProductos.Location = New System.Drawing.Point(60, 59)
        Me.lblProductos.Name = "lblProductos"
        Me.lblProductos.Size = New System.Drawing.Size(149, 29)
        Me.lblProductos.TabIndex = 74
        Me.lblProductos.Text = "Información"
        '
        'frmDetalleTelefono
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(465, 271)
        Me.Controls.Add(Me.pbBuscarProducto)
        Me.Controls.Add(Me.lblProductos)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDetalleTelefono"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.lblProductos, 0)
        Me.Controls.SetChildIndex(Me.pbBuscarProducto, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBuscarProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pbBuscarProducto As System.Windows.Forms.PictureBox
    Friend WithEvents lblProductos As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox

End Class
