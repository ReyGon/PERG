<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaConceptoConDescuento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaConceptoConDescuento))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblSerieFactura = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblResolucion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDireccionEnvio = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblDireccionFacturacion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblNit = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombreFacturacion = New System.Windows.Forms.Label()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFactura = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblFechaRegistro = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbDetalle = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnx1Imprimir = New System.Windows.Forms.Panel()
        Me.lbl1Imprimir = New System.Windows.Forms.Label()
        Me.pbx1Imprimir = New System.Windows.Forms.PictureBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDetalle.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Imprimir.SuspendLayout()
        CType(Me.pbx1Imprimir, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx1Imprimir)
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(546, 48)
        Me.pnlBarra.TabIndex = 60
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(432, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 196
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 72
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 71
        Me.pbx0Salir.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.lblDescuento)
        Me.rgbInformacion.Controls.Add(Me.Label12)
        Me.rgbInformacion.Controls.Add(Me.lblSerieFactura)
        Me.rgbInformacion.Controls.Add(Me.Label9)
        Me.rgbInformacion.Controls.Add(Me.lblResolucion)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.lblDireccionEnvio)
        Me.rgbInformacion.Controls.Add(Me.Label16)
        Me.rgbInformacion.Controls.Add(Me.lblDireccionFacturacion)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.Label14)
        Me.rgbInformacion.Controls.Add(Me.lblNit)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.lblNombreFacturacion)
        Me.rgbInformacion.Controls.Add(Me.lblVendedor)
        Me.rgbInformacion.Controls.Add(Me.Label13)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.lblFactura)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.lblCliente)
        Me.rgbInformacion.Controls.Add(Me.lblFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblTotal)
        Me.rgbInformacion.Controls.Add(Me.Label11)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 66)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(970, 252)
        Me.rgbInformacion.TabIndex = 177
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescuento.ForeColor = System.Drawing.Color.Black
        Me.lblDescuento.Location = New System.Drawing.Point(819, 187)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(106, 25)
        Me.lblDescuento.TabIndex = 184
        Me.lblDescuento.Text = "Descuento"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(703, 187)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 25)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Descuento :"
        '
        'lblSerieFactura
        '
        Me.lblSerieFactura.AutoSize = True
        Me.lblSerieFactura.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblSerieFactura.ForeColor = System.Drawing.Color.Black
        Me.lblSerieFactura.Location = New System.Drawing.Point(218, 212)
        Me.lblSerieFactura.Name = "lblSerieFactura"
        Me.lblSerieFactura.Size = New System.Drawing.Size(127, 25)
        Me.lblSerieFactura.TabIndex = 182
        Me.lblSerieFactura.Text = "Serie Factura"
        Me.lblSerieFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(77, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 25)
        Me.Label9.TabIndex = 181
        Me.Label9.Text = "Serie Factura :"
        '
        'lblResolucion
        '
        Me.lblResolucion.AutoSize = True
        Me.lblResolucion.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblResolucion.ForeColor = System.Drawing.Color.Black
        Me.lblResolucion.Location = New System.Drawing.Point(525, 214)
        Me.lblResolucion.Name = "lblResolucion"
        Me.lblResolucion.Size = New System.Drawing.Size(109, 25)
        Me.lblResolucion.TabIndex = 180
        Me.lblResolucion.Text = "Resolucion"
        Me.lblResolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(404, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 25)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Resolucion :"
        '
        'lblDireccionEnvio
        '
        Me.lblDireccionEnvio.AutoSize = True
        Me.lblDireccionEnvio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDireccionEnvio.ForeColor = System.Drawing.Color.Black
        Me.lblDireccionEnvio.Location = New System.Drawing.Point(217, 138)
        Me.lblDireccionEnvio.Name = "lblDireccionEnvio"
        Me.lblDireccionEnvio.Size = New System.Drawing.Size(116, 20)
        Me.lblDireccionEnvio.TabIndex = 178
        Me.lblDireccionEnvio.Text = "Direccion Envio"
        Me.lblDireccionEnvio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(55, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(155, 25)
        Me.Label16.TabIndex = 177
        Me.Label16.Text = "Dirección Envío :"
        '
        'lblDireccionFacturacion
        '
        Me.lblDireccionFacturacion.AutoSize = True
        Me.lblDireccionFacturacion.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblDireccionFacturacion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccionFacturacion.Location = New System.Drawing.Point(213, 109)
        Me.lblDireccionFacturacion.Name = "lblDireccionFacturacion"
        Me.lblDireccionFacturacion.Size = New System.Drawing.Size(137, 25)
        Me.lblDireccionFacturacion.TabIndex = 176
        Me.lblDireccionFacturacion.Text = "Direccion Fact"
        Me.lblDireccionFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(3, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(208, 25)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "Direccion Facturacion :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(162, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 25)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "Nit :"
        '
        'lblNit
        '
        Me.lblNit.AutoSize = True
        Me.lblNit.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblNit.ForeColor = System.Drawing.Color.Black
        Me.lblNit.Location = New System.Drawing.Point(213, 36)
        Me.lblNit.Name = "lblNit"
        Me.lblNit.Size = New System.Drawing.Size(39, 25)
        Me.lblNit.TabIndex = 174
        Me.lblNit.Text = "Nit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(14, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(198, 25)
        Me.Label7.TabIndex = 171
        Me.Label7.Text = "Nombre Facturación :"
        '
        'lblNombreFacturacion
        '
        Me.lblNombreFacturacion.AutoSize = True
        Me.lblNombreFacturacion.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombreFacturacion.ForeColor = System.Drawing.Color.Black
        Me.lblNombreFacturacion.Location = New System.Drawing.Point(213, 82)
        Me.lblNombreFacturacion.Name = "lblNombreFacturacion"
        Me.lblNombreFacturacion.Size = New System.Drawing.Size(116, 25)
        Me.lblNombreFacturacion.TabIndex = 172
        Me.lblNombreFacturacion.Text = "Facturación"
        Me.lblNombreFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblVendedor.ForeColor = System.Drawing.Color.Black
        Me.lblVendedor.Location = New System.Drawing.Point(216, 162)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(101, 25)
        Me.lblVendedor.TabIndex = 168
        Me.lblVendedor.Text = "Vendedor"
        Me.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(105, 162)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 25)
        Me.Label13.TabIndex = 167
        Me.Label13.Text = "Vendedor :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(9, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(201, 25)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "Factura Electronica # :"
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblFactura.ForeColor = System.Drawing.Color.Black
        Me.lblFactura.Location = New System.Drawing.Point(218, 187)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(94, 25)
        Me.lblFactura.TabIndex = 164
        Me.lblFactura.Text = "Factura #"
        Me.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(130, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 25)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Cliente :"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(213, 57)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(86, 25)
        Me.lblCliente.TabIndex = 148
        Me.lblCliente.Text = "Nombre"
        '
        'lblFechaRegistro
        '
        Me.lblFechaRegistro.AutoSize = True
        Me.lblFechaRegistro.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblFechaRegistro.Location = New System.Drawing.Point(213, 10)
        Me.lblFechaRegistro.Name = "lblFechaRegistro"
        Me.lblFechaRegistro.Size = New System.Drawing.Size(62, 25)
        Me.lblFechaRegistro.TabIndex = 160
        Me.lblFechaRegistro.Text = "Fecha"
        Me.lblFechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(703, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 25)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "Total Venta :"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.Location = New System.Drawing.Point(819, 212)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 25)
        Me.lblTotal.TabIndex = 152
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(139, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 25)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Fecha :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(68, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 25)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Información"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(25, 52)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 180
        Me.PictureBox4.TabStop = False
        '
        'rgbDetalle
        '
        Me.rgbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDetalle.Controls.Add(Me.grdProductos)
        Me.rgbDetalle.FooterImageIndex = -1
        Me.rgbDetalle.FooterImageKey = ""
        Me.rgbDetalle.HeaderImageIndex = -1
        Me.rgbDetalle.HeaderImageKey = ""
        Me.rgbDetalle.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDetalle.HeaderText = ""
        Me.rgbDetalle.Location = New System.Drawing.Point(13, 342)
        Me.rgbDetalle.Name = "rgbDetalle"
        Me.rgbDetalle.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDetalle.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDetalle.Size = New System.Drawing.Size(969, 258)
        Me.rgbDetalle.TabIndex = 181
        '
        'grdProductos
        '
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(10, 20)
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
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(949, 228)
        Me.grdProductos.TabIndex = 161
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox5.Location = New System.Drawing.Point(31, 325)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 182
        Me.PictureBox5.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Gray
        Me.Label15.Location = New System.Drawing.Point(73, 330)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 25)
        Me.Label15.TabIndex = 183
        Me.Label15.Text = "Detalle"
        '
        'pnx1Imprimir
        '
        Me.pnx1Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Imprimir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Imprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Imprimir.Controls.Add(Me.lbl1Imprimir)
        Me.pnx1Imprimir.Controls.Add(Me.pbx1Imprimir)
        Me.pnx1Imprimir.Location = New System.Drawing.Point(324, 4)
        Me.pnx1Imprimir.Name = "pnx1Imprimir"
        Me.pnx1Imprimir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Imprimir.TabIndex = 197
        '
        'lbl1Imprimir
        '
        Me.lbl1Imprimir.AutoSize = True
        Me.lbl1Imprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Imprimir.ForeColor = System.Drawing.Color.White
        Me.lbl1Imprimir.Location = New System.Drawing.Point(43, 5)
        Me.lbl1Imprimir.Name = "lbl1Imprimir"
        Me.lbl1Imprimir.Size = New System.Drawing.Size(54, 30)
        Me.lbl1Imprimir.TabIndex = 72
        Me.lbl1Imprimir.Text = "Docs de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Salida"
        Me.lbl1Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx1Imprimir
        '
        Me.pbx1Imprimir.Image = Global.laFuente.My.Resources.Resources.entrada_Blanco
        Me.pbx1Imprimir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Imprimir.Name = "pbx1Imprimir"
        Me.pbx1Imprimir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Imprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Imprimir.TabIndex = 71
        Me.pbx1Imprimir.TabStop = False
        '
        'frmFacturaConceptoConDescuento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1011, 612)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbDetalle)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFacturaConceptoConDescuento"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.rgbDetalle, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDetalle.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Imprimir.ResumeLayout(False)
        Me.pnx1Imprimir.PerformLayout()
        CType(Me.pbx1Imprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblDireccionEnvio As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblDireccionFacturacion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNit As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNombreFacturacion As System.Windows.Forms.Label
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblSerieFactura As System.Windows.Forms.Label
    Friend WithEvents lblResolucion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbDetalle As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnx1Imprimir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Imprimir As System.Windows.Forms.Label
    Friend WithEvents pbx1Imprimir As System.Windows.Forms.PictureBox

End Class
