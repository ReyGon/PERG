
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaPequeniaTransporteAgregar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaPequeniaTransporteAgregar))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.rgbServicio = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbMunicipio = New System.Windows.Forms.ComboBox()
        Me.nm2PrecioMinimo = New System.Windows.Forms.NumericUpDown()
        Me.nm2TotalFinal = New System.Windows.Forms.NumericUpDown()
        Me.nm2Descuento = New System.Windows.Forms.NumericUpDown()
        Me.nm2Total = New System.Windows.Forms.NumericUpDown()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkPrecioMinimo = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nm2Cantidad = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nm2Precio = New System.Windows.Forms.NumericUpDown()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.cmbCosteo = New System.Windows.Forms.ComboBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbServicio.SuspendLayout()
        CType(Me.nm2PrecioMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2TotalFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2Descuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm2Precio, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Location = New System.Drawing.Point(465, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(314, 51)
        Me.pnlBarra.TabIndex = 191
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(199, 7)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(106, 40)
        Me.pnx0Salir.TabIndex = 91
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 69
        Me.pbx0Salir.TabStop = False
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 70
        Me.lbl0Salir.Text = "Salir"
        '
        'rgbServicio
        '
        Me.rgbServicio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbServicio.Controls.Add(Me.Label14)
        Me.rgbServicio.Controls.Add(Me.cmbSucursal)
        Me.rgbServicio.Controls.Add(Me.Label15)
        Me.rgbServicio.Controls.Add(Me.cmbMunicipio)
        Me.rgbServicio.Controls.Add(Me.nm2PrecioMinimo)
        Me.rgbServicio.Controls.Add(Me.nm2TotalFinal)
        Me.rgbServicio.Controls.Add(Me.nm2Descuento)
        Me.rgbServicio.Controls.Add(Me.nm2Total)
        Me.rgbServicio.Controls.Add(Me.txtTelefono)
        Me.rgbServicio.Controls.Add(Me.Label12)
        Me.rgbServicio.Controls.Add(Me.btnAgregar)
        Me.rgbServicio.Controls.Add(Me.txtContacto)
        Me.rgbServicio.Controls.Add(Me.Label13)
        Me.rgbServicio.Controls.Add(Me.Label11)
        Me.rgbServicio.Controls.Add(Me.Label10)
        Me.rgbServicio.Controls.Add(Me.Label9)
        Me.rgbServicio.Controls.Add(Me.chkPrecioMinimo)
        Me.rgbServicio.Controls.Add(Me.Label8)
        Me.rgbServicio.Controls.Add(Me.Label2)
        Me.rgbServicio.Controls.Add(Me.nm2Cantidad)
        Me.rgbServicio.Controls.Add(Me.Label7)
        Me.rgbServicio.Controls.Add(Me.Label6)
        Me.rgbServicio.Controls.Add(Me.Label5)
        Me.rgbServicio.Controls.Add(Me.Label4)
        Me.rgbServicio.Controls.Add(Me.nm2Precio)
        Me.rgbServicio.Controls.Add(Me.txtObservacion)
        Me.rgbServicio.Controls.Add(Me.cmbCosteo)
        Me.rgbServicio.Controls.Add(Me.txtDireccion)
        Me.rgbServicio.FooterImageIndex = -1
        Me.rgbServicio.FooterImageKey = ""
        Me.rgbServicio.HeaderImageIndex = -1
        Me.rgbServicio.HeaderImageKey = ""
        Me.rgbServicio.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbServicio.HeaderText = "INFORMACION"
        Me.rgbServicio.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rgbServicio.Location = New System.Drawing.Point(12, 54)
        Me.rgbServicio.Name = "rgbServicio"
        Me.rgbServicio.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbServicio.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbServicio.Size = New System.Drawing.Size(758, 334)
        Me.rgbServicio.TabIndex = 204
        Me.rgbServicio.Text = "INFORMACION"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(47, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = "Sucursal :"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(106, 21)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(267, 21)
        Me.cmbSucursal.TabIndex = 221
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(38, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 217
        Me.Label15.Text = "Municipio :"
        '
        'cmbMunicipio
        '
        Me.cmbMunicipio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbMunicipio.FormattingEnabled = True
        Me.cmbMunicipio.Location = New System.Drawing.Point(106, 48)
        Me.cmbMunicipio.Name = "cmbMunicipio"
        Me.cmbMunicipio.Size = New System.Drawing.Size(267, 21)
        Me.cmbMunicipio.TabIndex = 215
        '
        'nm2PrecioMinimo
        '
        Me.nm2PrecioMinimo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nm2PrecioMinimo.DecimalPlaces = 2
        Me.nm2PrecioMinimo.Enabled = False
        Me.nm2PrecioMinimo.Location = New System.Drawing.Point(106, 216)
        Me.nm2PrecioMinimo.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2PrecioMinimo.Name = "nm2PrecioMinimo"
        Me.nm2PrecioMinimo.Size = New System.Drawing.Size(191, 20)
        Me.nm2PrecioMinimo.TabIndex = 214
        Me.nm2PrecioMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm2TotalFinal
        '
        Me.nm2TotalFinal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nm2TotalFinal.DecimalPlaces = 2
        Me.nm2TotalFinal.Enabled = False
        Me.nm2TotalFinal.Location = New System.Drawing.Point(106, 271)
        Me.nm2TotalFinal.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2TotalFinal.Name = "nm2TotalFinal"
        Me.nm2TotalFinal.Size = New System.Drawing.Size(267, 20)
        Me.nm2TotalFinal.TabIndex = 213
        Me.nm2TotalFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm2Descuento
        '
        Me.nm2Descuento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nm2Descuento.DecimalPlaces = 2
        Me.nm2Descuento.Enabled = False
        Me.nm2Descuento.Location = New System.Drawing.Point(106, 297)
        Me.nm2Descuento.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2Descuento.Name = "nm2Descuento"
        Me.nm2Descuento.Size = New System.Drawing.Size(267, 20)
        Me.nm2Descuento.TabIndex = 212
        Me.nm2Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm2Total
        '
        Me.nm2Total.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nm2Total.DecimalPlaces = 2
        Me.nm2Total.Enabled = False
        Me.nm2Total.Location = New System.Drawing.Point(106, 245)
        Me.nm2Total.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2Total.Name = "nm2Total"
        Me.nm2Total.Size = New System.Drawing.Size(267, 20)
        Me.nm2Total.TabIndex = 211
        Me.nm2Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTelefono
        '
        Me.txtTelefono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono.Location = New System.Drawing.Point(473, 53)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(262, 20)
        Me.txtTelefono.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(412, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Telefono :"
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnAgregar.Location = New System.Drawing.Point(521, 245)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(159, 63)
        Me.btnAgregar.TabIndex = 210
        Me.btnAgregar.Text = "AGREGAR"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'txtContacto
        '
        Me.txtContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContacto.Location = New System.Drawing.Point(473, 27)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(262, 20)
        Me.txtContacto.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(410, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Contacto :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(38, 273)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Total Final :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(35, 299)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Descuento :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Total :"
        '
        'chkPrecioMinimo
        '
        Me.chkPrecioMinimo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrecioMinimo.AutoSize = True
        Me.chkPrecioMinimo.Location = New System.Drawing.Point(306, 219)
        Me.chkPrecioMinimo.Name = "chkPrecioMinimo"
        Me.chkPrecioMinimo.Size = New System.Drawing.Size(61, 17)
        Me.chkPrecioMinimo.TabIndex = 6
        Me.chkPrecioMinimo.Text = "Aplicar"
        Me.chkPrecioMinimo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Precio Minimo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cantidad :"
        '
        'nm2Cantidad
        '
        Me.nm2Cantidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nm2Cantidad.Location = New System.Drawing.Point(106, 164)
        Me.nm2Cantidad.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2Cantidad.Name = "nm2Cantidad"
        Me.nm2Cantidad.Size = New System.Drawing.Size(267, 20)
        Me.nm2Cantidad.TabIndex = 3
        Me.nm2Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Precio :"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Observacion :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Direccion :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Costeo :"
        '
        'nm2Precio
        '
        Me.nm2Precio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nm2Precio.DecimalPlaces = 2
        Me.nm2Precio.Enabled = False
        Me.nm2Precio.Location = New System.Drawing.Point(106, 190)
        Me.nm2Precio.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2Precio.Name = "nm2Precio"
        Me.nm2Precio.Size = New System.Drawing.Size(267, 20)
        Me.nm2Precio.TabIndex = 4
        Me.nm2Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.Location = New System.Drawing.Point(473, 79)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(262, 117)
        Me.txtObservacion.TabIndex = 12
        '
        'cmbCosteo
        '
        Me.cmbCosteo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbCosteo.FormattingEnabled = True
        Me.cmbCosteo.Location = New System.Drawing.Point(106, 76)
        Me.cmbCosteo.Name = "cmbCosteo"
        Me.cmbCosteo.Size = New System.Drawing.Size(267, 21)
        Me.cmbCosteo.TabIndex = 1
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Location = New System.Drawing.Point(106, 103)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(267, 57)
        Me.txtDireccion.TabIndex = 2
        '
        'frmVentaPequeniaTransporteAgregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(775, 400)
        Me.Controls.Add(Me.rgbServicio)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVentaPequeniaTransporteAgregar"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbServicio, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbServicio.ResumeLayout(False)
        Me.rgbServicio.PerformLayout()
        CType(Me.nm2PrecioMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2TotalFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2Descuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm2Precio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents rgbServicio As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nm2Precio As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents cmbCosteo As System.Windows.Forms.ComboBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkPrecioMinimo As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nm2Cantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents nm2PrecioMinimo As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm2TotalFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm2Descuento As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm2Total As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label

End Class
