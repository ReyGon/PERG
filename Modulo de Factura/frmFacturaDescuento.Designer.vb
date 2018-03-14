<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaDescuento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaDescuento))
        Me.rgbDatos = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtDireccionFactura = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNombreFacturacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbDescuento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbResolucionFactura = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1salir = New System.Windows.Forms.Panel()
        Me.lbl1salir = New System.Windows.Forms.Label()
        Me.pbx1salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCorrelativo = New System.Windows.Forms.TextBox()
        Me.lblCorrelativo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFinal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFechaResolucion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblResolucion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDatos.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1salir.SuspendLayout()
        CType(Me.pbx1salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'rgbDatos
        '
        Me.rgbDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDatos.Controls.Add(Me.txtDireccionFactura)
        Me.rgbDatos.Controls.Add(Me.Label15)
        Me.rgbDatos.Controls.Add(Me.txtNit)
        Me.rgbDatos.Controls.Add(Me.Label14)
        Me.rgbDatos.Controls.Add(Me.txtNombreFacturacion)
        Me.rgbDatos.Controls.Add(Me.Label4)
        Me.rgbDatos.Controls.Add(Me.Label8)
        Me.rgbDatos.Controls.Add(Me.cmbDescuento)
        Me.rgbDatos.Controls.Add(Me.Label5)
        Me.rgbDatos.Controls.Add(Me.cmbResolucionFactura)
        Me.rgbDatos.Controls.Add(Me.Label3)
        Me.rgbDatos.FooterImageIndex = -1
        Me.rgbDatos.FooterImageKey = ""
        Me.rgbDatos.HeaderImageIndex = -1
        Me.rgbDatos.HeaderImageKey = ""
        Me.rgbDatos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDatos.HeaderText = ""
        Me.rgbDatos.Location = New System.Drawing.Point(21, 78)
        Me.rgbDatos.Name = "rgbDatos"
        Me.rgbDatos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDatos.Size = New System.Drawing.Size(559, 244)
        Me.rgbDatos.TabIndex = 60
        '
        'txtDireccionFactura
        '
        Me.txtDireccionFactura.Location = New System.Drawing.Point(199, 165)
        Me.txtDireccionFactura.Multiline = True
        Me.txtDireccionFactura.Name = "txtDireccionFactura"
        Me.txtDireccionFactura.Size = New System.Drawing.Size(323, 66)
        Me.txtDireccionFactura.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Enabled = False
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 176)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(187, 21)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Direccion de Facturacion :"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(199, 70)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(323, 20)
        Me.txtNit.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Enabled = False
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(157, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 21)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Nit :"
        '
        'txtNombreFacturacion
        '
        Me.txtNombreFacturacion.Location = New System.Drawing.Point(199, 96)
        Me.txtNombreFacturacion.Multiline = True
        Me.txtNombreFacturacion.Name = "txtNombreFacturacion"
        Me.txtNombreFacturacion.Size = New System.Drawing.Size(323, 61)
        Me.txtNombreFacturacion.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 21)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Nombre de Facturacion :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(530, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "%"
        '
        'cmbDescuento
        '
        Me.cmbDescuento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbDescuento.FormattingEnabled = True
        Me.cmbDescuento.Location = New System.Drawing.Point(199, 41)
        Me.cmbDescuento.Name = "cmbDescuento"
        Me.cmbDescuento.Size = New System.Drawing.Size(323, 23)
        Me.cmbDescuento.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 21)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Descuento :"
        '
        'cmbResolucionFactura
        '
        Me.cmbResolucionFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbResolucionFactura.FormattingEnabled = True
        Me.cmbResolucionFactura.Location = New System.Drawing.Point(199, 14)
        Me.cmbResolucionFactura.Name = "cmbResolucionFactura"
        Me.cmbResolucionFactura.Size = New System.Drawing.Size(323, 23)
        Me.cmbResolucionFactura.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(100, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Resolucion :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(74, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Seleccionar"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox3.Location = New System.Drawing.Point(31, 55)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(44, 35)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 61
        Me.PictureBox3.TabStop = False
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx1salir)
        Me.pnlBarra.Controls.Add(Me.pnx0Guardar)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(455, 48)
        Me.pnlBarra.TabIndex = 62
        '
        'pnx1salir
        '
        Me.pnx1salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1salir.Controls.Add(Me.lbl1salir)
        Me.pnx1salir.Controls.Add(Me.pbx1salir)
        Me.pnx1salir.Location = New System.Drawing.Point(349, 3)
        Me.pnx1salir.Name = "pnx1salir"
        Me.pnx1salir.Size = New System.Drawing.Size(95, 40)
        Me.pnx1salir.TabIndex = 64
        '
        'lbl1salir
        '
        Me.lbl1salir.AutoSize = True
        Me.lbl1salir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1salir.ForeColor = System.Drawing.Color.White
        Me.lbl1salir.Location = New System.Drawing.Point(44, 13)
        Me.lbl1salir.Name = "lbl1salir"
        Me.lbl1salir.Size = New System.Drawing.Size(35, 17)
        Me.lbl1salir.TabIndex = 64
        Me.lbl1salir.Text = "Salir"
        '
        'pbx1salir
        '
        Me.pbx1salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx1salir.Location = New System.Drawing.Point(5, 1)
        Me.pbx1salir.Name = "pbx1salir"
        Me.pbx1salir.Size = New System.Drawing.Size(36, 38)
        Me.pbx1salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1salir.TabIndex = 0
        Me.pbx1salir.TabStop = False
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(239, 3)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(104, 40)
        Me.pnx0Guardar.TabIndex = 63
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(41, 12)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(57, 17)
        Me.lbl0Guardar.TabIndex = 64
        Me.lbl0Guardar.Text = "Guardar"
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = Global.laFuente.My.Resources.Resources.guardar
        Me.pbx0Guardar.Location = New System.Drawing.Point(9, 1)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(29, 38)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 0
        Me.pbx0Guardar.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.txtSerie)
        Me.rgbInformacion.Controls.Add(Me.Label16)
        Me.rgbInformacion.Controls.Add(Me.txtCorrelativo)
        Me.rgbInformacion.Controls.Add(Me.lblCorrelativo)
        Me.rgbInformacion.Controls.Add(Me.Label13)
        Me.rgbInformacion.Controls.Add(Me.lblFinal)
        Me.rgbInformacion.Controls.Add(Me.Label11)
        Me.rgbInformacion.Controls.Add(Me.lblInicio)
        Me.rgbInformacion.Controls.Add(Me.Label9)
        Me.rgbInformacion.Controls.Add(Me.Label12)
        Me.rgbInformacion.Controls.Add(Me.lblFechaResolucion)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.Controls.Add(Me.lblResolucion)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(594, 78)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(319, 244)
        Me.rgbInformacion.TabIndex = 63
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(188, 199)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(106, 20)
        Me.txtSerie.TabIndex = 67
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(91, 168)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 25)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Factura :"
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Location = New System.Drawing.Point(188, 173)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(106, 20)
        Me.txtCorrelativo.TabIndex = 65
        '
        'lblCorrelativo
        '
        Me.lblCorrelativo.AutoSize = True
        Me.lblCorrelativo.Enabled = False
        Me.lblCorrelativo.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrelativo.Location = New System.Drawing.Point(183, 143)
        Me.lblCorrelativo.Name = "lblCorrelativo"
        Me.lblCorrelativo.Size = New System.Drawing.Size(111, 25)
        Me.lblCorrelativo.TabIndex = 12
        Me.lblCorrelativo.Text = "Correlativo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(18, 145)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(158, 25)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Siguiente # Fact :"
        '
        'lblFinal
        '
        Me.lblFinal.AutoSize = True
        Me.lblFinal.Enabled = False
        Me.lblFinal.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinal.Location = New System.Drawing.Point(183, 113)
        Me.lblFinal.Name = "lblFinal"
        Me.lblFinal.Size = New System.Drawing.Size(54, 25)
        Me.lblFinal.TabIndex = 10
        Me.lblFinal.Text = "Final"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(119, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 25)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Final:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Enabled = False
        Me.lblInicio.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(185, 82)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(61, 25)
        Me.lblInicio.TabIndex = 8
        Me.lblInicio.Text = "Inicio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(113, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 25)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Inicio:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(51, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 25)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Serie Factura:"
        '
        'lblFechaResolucion
        '
        Me.lblFechaResolucion.AutoSize = True
        Me.lblFechaResolucion.Enabled = False
        Me.lblFechaResolucion.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaResolucion.Location = New System.Drawing.Point(184, 56)
        Me.lblFechaResolucion.Name = "lblFechaResolucion"
        Me.lblFechaResolucion.Size = New System.Drawing.Size(62, 25)
        Me.lblFechaResolucion.TabIndex = 4
        Me.lblFechaResolucion.Text = "Fecha"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(110, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 25)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Fecha:"
        '
        'lblResolucion
        '
        Me.lblResolucion.AutoSize = True
        Me.lblResolucion.Enabled = False
        Me.lblResolucion.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolucion.Location = New System.Drawing.Point(183, 27)
        Me.lblResolucion.Name = "lblResolucion"
        Me.lblResolucion.Size = New System.Drawing.Size(122, 25)
        Me.lblResolucion.TabIndex = 2
        Me.lblResolucion.Text = "Informacion"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(26, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 25)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "No. Resolucion :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(654, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 25)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Resolucion"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(607, 55)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 35)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 62
        Me.PictureBox4.TabStop = False
        '
        'frmFacturaDescuento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(919, 349)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rgbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFacturaDescuento"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbDatos, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDatos.ResumeLayout(False)
        Me.rgbDatos.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1salir.ResumeLayout(False)
        Me.pnx1salir.PerformLayout()
        CType(Me.pbx1salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rgbDatos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbDescuento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbResolucionFactura As System.Windows.Forms.ComboBox
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1salir As System.Windows.Forms.Label
    Friend WithEvents pbx1salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblFinal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFechaResolucion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblResolucion As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNombreFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCorrelativo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox

End Class
