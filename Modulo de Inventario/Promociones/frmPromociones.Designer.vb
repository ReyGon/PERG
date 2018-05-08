<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromociones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPromociones))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Facturar = New System.Windows.Forms.Panel()
        Me.lbl0Facturar = New System.Windows.Forms.Label()
        Me.pbx0Facturar = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCantidadPromocion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCuotaPromocion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtExistenciaMinima = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.chkActivado = New System.Windows.Forms.CheckBox()
        Me.chkExistenciaEstado = New System.Windows.Forms.CheckBox()
        Me.chkFechaEstado = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.lblNumeroFacturas = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lbldocumentoboleta = New System.Windows.Forms.Label()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Facturar.SuspendLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Controls.Add(Me.pnx0Facturar)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(767, 48)
        Me.pnlBarra.TabIndex = 157
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(655, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 117
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
        'pnx0Facturar
        '
        Me.pnx0Facturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Facturar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Facturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Facturar.Controls.Add(Me.lbl0Facturar)
        Me.pnx0Facturar.Controls.Add(Me.pbx0Facturar)
        Me.pnx0Facturar.Location = New System.Drawing.Point(542, 3)
        Me.pnx0Facturar.Name = "pnx0Facturar"
        Me.pnx0Facturar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Facturar.TabIndex = 116
        '
        'lbl0Facturar
        '
        Me.lbl0Facturar.AutoSize = True
        Me.lbl0Facturar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Facturar.ForeColor = System.Drawing.Color.White
        Me.lbl0Facturar.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Facturar.Name = "lbl0Facturar"
        Me.lbl0Facturar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Facturar.TabIndex = 72
        Me.lbl0Facturar.Text = "Guardar"
        '
        'pbx0Facturar
        '
        Me.pbx0Facturar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx0Facturar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Facturar.Name = "pbx0Facturar"
        Me.pbx0Facturar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Facturar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Facturar.TabIndex = 71
        Me.pbx0Facturar.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(18, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 25)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "Productos Promociones"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.Label9)
        Me.RadGroupBox1.Controls.Add(Me.txtCantidadPromocion)
        Me.RadGroupBox1.Controls.Add(Me.Label8)
        Me.RadGroupBox1.Controls.Add(Me.txtCuotaPromocion)
        Me.RadGroupBox1.Controls.Add(Me.Label7)
        Me.RadGroupBox1.Controls.Add(Me.txtExistenciaMinima)
        Me.RadGroupBox1.Controls.Add(Me.Label6)
        Me.RadGroupBox1.Controls.Add(Me.Label5)
        Me.RadGroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.RadGroupBox1.Controls.Add(Me.chkActivado)
        Me.RadGroupBox1.Controls.Add(Me.chkExistenciaEstado)
        Me.RadGroupBox1.Controls.Add(Me.chkFechaEstado)
        Me.RadGroupBox1.Controls.Add(Me.Label4)
        Me.RadGroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.RadGroupBox1.Controls.Add(Me.txtId)
        Me.RadGroupBox1.Controls.Add(Me.Label3)
        Me.RadGroupBox1.Controls.Add(Me.txtProducto)
        Me.RadGroupBox1.Controls.Add(Me.lblNumeroFacturas)
        Me.RadGroupBox1.Controls.Add(Me.txtCodigo)
        Me.RadGroupBox1.Controls.Add(Me.lbldocumentoboleta)
        Me.RadGroupBox1.Controls.Add(Me.grdProductos)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(2, 68)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(1223, 518)
        Me.RadGroupBox1.TabIndex = 204
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(10, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1200, 23)
        Me.Label9.TabIndex = 246
        Me.Label9.Text = "F2 -> Permite visualizar ultimas Compras;   F3-> Permite visualizar ultimas Venta" & _
    "s;   F4-> Permite visualizar modulo Pricing;   F6-> Permite visualizar modulo Ar" & _
    "ticulos"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCantidadPromocion
        '
        Me.txtCantidadPromocion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCantidadPromocion.Location = New System.Drawing.Point(1054, 82)
        Me.txtCantidadPromocion.Name = "txtCantidadPromocion"
        Me.txtCantidadPromocion.Size = New System.Drawing.Size(136, 22)
        Me.txtCantidadPromocion.TabIndex = 243
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(1062, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 13)
        Me.Label8.TabIndex = 244
        Me.Label8.Text = "Cantidad Promocion :"
        '
        'txtCuotaPromocion
        '
        Me.txtCuotaPromocion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCuotaPromocion.Location = New System.Drawing.Point(902, 82)
        Me.txtCuotaPromocion.Name = "txtCuotaPromocion"
        Me.txtCuotaPromocion.Size = New System.Drawing.Size(136, 22)
        Me.txtCuotaPromocion.TabIndex = 241
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(920, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Cuota Promocion :"
        '
        'txtExistenciaMinima
        '
        Me.txtExistenciaMinima.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtExistenciaMinima.Location = New System.Drawing.Point(710, 82)
        Me.txtExistenciaMinima.Name = "txtExistenciaMinima"
        Me.txtExistenciaMinima.Size = New System.Drawing.Size(136, 22)
        Me.txtExistenciaMinima.TabIndex = 239
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(723, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 240
        Me.Label6.Text = "Existencia Minima :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(471, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 238
        Me.Label5.Text = "Fecha Fin :"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(537, 86)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(103, 20)
        Me.dtpFechaFin.TabIndex = 237
        '
        'chkActivado
        '
        Me.chkActivado.AutoSize = True
        Me.chkActivado.Location = New System.Drawing.Point(1014, 40)
        Me.chkActivado.Name = "chkActivado"
        Me.chkActivado.Size = New System.Drawing.Size(70, 17)
        Me.chkActivado.TabIndex = 236
        Me.chkActivado.Text = "Activado"
        Me.chkActivado.UseVisualStyleBackColor = True
        '
        'chkExistenciaEstado
        '
        Me.chkExistenciaEstado.AutoSize = True
        Me.chkExistenciaEstado.Location = New System.Drawing.Point(721, 39)
        Me.chkExistenciaEstado.Name = "chkExistenciaEstado"
        Me.chkExistenciaEstado.Size = New System.Drawing.Size(114, 17)
        Me.chkExistenciaEstado.TabIndex = 235
        Me.chkExistenciaEstado.Text = "Existencia Estado"
        Me.chkExistenciaEstado.UseVisualStyleBackColor = True
        '
        'chkFechaEstado
        '
        Me.chkFechaEstado.AutoSize = True
        Me.chkFechaEstado.Location = New System.Drawing.Point(514, 37)
        Me.chkFechaEstado.Name = "chkFechaEstado"
        Me.chkFechaEstado.Size = New System.Drawing.Size(94, 17)
        Me.chkFechaEstado.TabIndex = 234
        Me.chkFechaEstado.Text = "Fecha Estado"
        Me.chkFechaEstado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(459, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 233
        Me.Label4.Text = "Fecha Inicio :"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(537, 60)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(103, 20)
        Me.dtpFechaInicio.TabIndex = 232
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtId.Location = New System.Drawing.Point(299, 55)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(136, 22)
        Me.txtId.TabIndex = 230
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(270, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 231
        Me.Label3.Text = "Id :"
        '
        'txtProducto
        '
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtProducto.Location = New System.Drawing.Point(81, 83)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(354, 22)
        Me.txtProducto.TabIndex = 228
        '
        'lblNumeroFacturas
        '
        Me.lblNumeroFacturas.AutoSize = True
        Me.lblNumeroFacturas.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumeroFacturas.Location = New System.Drawing.Point(15, 86)
        Me.lblNumeroFacturas.Name = "lblNumeroFacturas"
        Me.lblNumeroFacturas.Size = New System.Drawing.Size(61, 13)
        Me.lblNumeroFacturas.TabIndex = 229
        Me.lblNumeroFacturas.Text = "Producto :"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(81, 55)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(149, 22)
        Me.txtCodigo.TabIndex = 226
        '
        'lbldocumentoboleta
        '
        Me.lbldocumentoboleta.AutoSize = True
        Me.lbldocumentoboleta.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbldocumentoboleta.Location = New System.Drawing.Point(24, 58)
        Me.lbldocumentoboleta.Name = "lbldocumentoboleta"
        Me.lbldocumentoboleta.Size = New System.Drawing.Size(51, 13)
        Me.lbldocumentoboleta.TabIndex = 227
        Me.lbldocumentoboleta.Text = "Codigo :"
        '
        'grdProductos
        '
        Me.grdProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(13, 114)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AllowDeleteRow = False
        Me.grdProductos.MasterTemplate.AllowEditRow = False
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.ReadOnly = True
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(1205, 391)
        Me.grdProductos.TabIndex = 162
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'frmPromociones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1232, 598)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPromociones"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Facturar.ResumeLayout(False)
        Me.pnx0Facturar.PerformLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Facturar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Facturar As System.Windows.Forms.Label
    Friend WithEvents pbx0Facturar As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroFacturas As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lbldocumentoboleta As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPromocion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCuotaPromocion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtExistenciaMinima As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkActivado As System.Windows.Forms.CheckBox
    Friend WithEvents chkExistenciaEstado As System.Windows.Forms.CheckBox
    Friend WithEvents chkFechaEstado As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
