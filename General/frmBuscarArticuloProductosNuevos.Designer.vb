<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloProductosNuevos
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbProducto = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblCompatibilidad = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblEmpaque = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnx0DocSalida = New System.Windows.Forms.Panel()
        Me.pbx0DocSalida = New System.Windows.Forms.PictureBox()
        Me.lbl0DocSalida = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbProducto.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
        Me.pnx0DocSalida.SuspendLayout()
        CType(Me.pbx0DocSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(78, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(226, 29)
        Me.Label16.TabIndex = 152
        Me.Label16.Text = "Productos Nuevos"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox5.Location = New System.Drawing.Point(43, 70)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(34, 34)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 153
        Me.PictureBox5.TabStop = False
        '
        'rgbProducto
        '
        Me.rgbProducto.Controls.Add(Me.grdProductos)
        Me.rgbProducto.FooterImageIndex = -1
        Me.rgbProducto.FooterImageKey = ""
        Me.rgbProducto.HeaderImageIndex = -1
        Me.rgbProducto.HeaderImageKey = ""
        Me.rgbProducto.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbProducto.HeaderText = ""
        Me.rgbProducto.Location = New System.Drawing.Point(14, 89)
        Me.rgbProducto.Name = "rgbProducto"
        Me.rgbProducto.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbProducto.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbProducto.Size = New System.Drawing.Size(1040, 232)
        Me.rgbProducto.TabIndex = 151
        '
        'grdProductos
        '
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(13, 23)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AllowColumnReorder = False
        Me.grdProductos.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn1.HeaderText = "Agregar"
        GridViewCheckBoxColumn1.IsVisible = False
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmAgregar"
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1})
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(1011, 191)
        Me.grdProductos.TabIndex = 133
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0DocSalida)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(601, 51)
        Me.pnlBarra.TabIndex = 175
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(480, 6)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 195
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
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(930, 342)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(126, 70)
        Me.btnBuscar.TabIndex = 184
        Me.btnBuscar.Text = "Agregar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.lblCompatibilidad)
        Me.rgbObservacion.Controls.Add(Me.Label8)
        Me.rgbObservacion.Controls.Add(Me.lblMarca)
        Me.rgbObservacion.Controls.Add(Me.Label7)
        Me.rgbObservacion.Controls.Add(Me.lblObservacion)
        Me.rgbObservacion.Controls.Add(Me.lblEmpaque)
        Me.rgbObservacion.Controls.Add(Me.Label6)
        Me.rgbObservacion.Controls.Add(Me.Label5)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(14, 327)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(895, 85)
        Me.rgbObservacion.TabIndex = 185
        '
        'lblCompatibilidad
        '
        Me.lblCompatibilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompatibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompatibilidad.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompatibilidad.ForeColor = System.Drawing.Color.Black
        Me.lblCompatibilidad.Location = New System.Drawing.Point(167, 54)
        Me.lblCompatibilidad.Name = "lblCompatibilidad"
        Me.lblCompatibilidad.Size = New System.Drawing.Size(504, 24)
        Me.lblCompatibilidad.TabIndex = 175
        Me.lblCompatibilidad.Text = "Compatibilidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(8, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 25)
        Me.Label8.TabIndex = 174
        Me.Label8.Text = "Compatibilidad :"
        '
        'lblMarca
        '
        Me.lblMarca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMarca.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(776, 8)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(106, 33)
        Me.lblMarca.TabIndex = 173
        Me.lblMarca.Text = "Marca"
        Me.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(704, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 25)
        Me.Label7.TabIndex = 172
        Me.Label7.Text = "Marca :"
        '
        'lblObservacion
        '
        Me.lblObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblObservacion.ForeColor = System.Drawing.Color.Black
        Me.lblObservacion.Location = New System.Drawing.Point(167, 10)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(503, 40)
        Me.lblObservacion.TabIndex = 169
        Me.lblObservacion.Text = "Codigo"
        '
        'lblEmpaque
        '
        Me.lblEmpaque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpaque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpaque.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpaque.ForeColor = System.Drawing.Color.Black
        Me.lblEmpaque.Location = New System.Drawing.Point(776, 45)
        Me.lblEmpaque.Name = "lblEmpaque"
        Me.lblEmpaque.Size = New System.Drawing.Size(106, 33)
        Me.lblEmpaque.TabIndex = 171
        Me.lblEmpaque.Text = "Empaque"
        Me.lblEmpaque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(33, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 25)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "Observación :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(678, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 25)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Empaque :"
        '
        'pnx0DocSalida
        '
        Me.pnx0DocSalida.BackColor = System.Drawing.Color.Navy
        Me.pnx0DocSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0DocSalida.Controls.Add(Me.pbx0DocSalida)
        Me.pnx0DocSalida.Controls.Add(Me.lbl0DocSalida)
        Me.pnx0DocSalida.Location = New System.Drawing.Point(364, 6)
        Me.pnx0DocSalida.Name = "pnx0DocSalida"
        Me.pnx0DocSalida.Size = New System.Drawing.Size(107, 40)
        Me.pnx0DocSalida.TabIndex = 200
        '
        'pbx0DocSalida
        '
        Me.pbx0DocSalida.Image = Global.laFuente.My.Resources.Resources.upload
        Me.pbx0DocSalida.Location = New System.Drawing.Point(2, 4)
        Me.pbx0DocSalida.Name = "pbx0DocSalida"
        Me.pbx0DocSalida.Size = New System.Drawing.Size(32, 29)
        Me.pbx0DocSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0DocSalida.TabIndex = 93
        Me.pbx0DocSalida.TabStop = False
        '
        'lbl0DocSalida
        '
        Me.lbl0DocSalida.AutoSize = True
        Me.lbl0DocSalida.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0DocSalida.ForeColor = System.Drawing.Color.White
        Me.lbl0DocSalida.Location = New System.Drawing.Point(32, 9)
        Me.lbl0DocSalida.Name = "lbl0DocSalida"
        Me.lbl0DocSalida.Size = New System.Drawing.Size(76, 19)
        Me.lbl0DocSalida.TabIndex = 94
        Me.lbl0DocSalida.Text = "DocSalida"
        '
        'frmBuscarArticuloProductosNuevos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1065, 423)
        Me.Controls.Add(Me.rgbObservacion)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbProducto)
        Me.Name = "frmBuscarArticuloProductosNuevos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbProducto, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.btnBuscar, 0)
        Me.Controls.SetChildIndex(Me.rgbObservacion, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbProducto.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        Me.pnx0DocSalida.ResumeLayout(False)
        Me.pnx0DocSalida.PerformLayout()
        CType(Me.pbx0DocSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbProducto As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblCompatibilidad As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblEmpaque As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0DocSalida As System.Windows.Forms.Panel
    Friend WithEvents pbx0DocSalida As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0DocSalida As System.Windows.Forms.Label

End Class
