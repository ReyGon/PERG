<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClienteEstadistica
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
        Dim AGaugeRange1 As System.Windows.Forms.AGaugeRange = New System.Windows.Forms.AGaugeRange()
        Dim AGaugeRange2 As System.Windows.Forms.AGaugeRange = New System.Windows.Forms.AGaugeRange()
        Dim AGaugeRange3 As System.Windows.Forms.AGaugeRange = New System.Windows.Forms.AGaugeRange()
        Dim ChartSeries1 As Telerik.Charting.ChartSeries = New Telerik.Charting.ChartSeries()
        Dim ChartSeries2 As Telerik.Charting.ChartSeries = New Telerik.Charting.ChartSeries()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClienteEstadistica))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnInfoCliente = New System.Windows.Forms.Button()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.tlpContenedor = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlInfoVentas = New System.Windows.Forms.Panel()
        Me.lblUltimaCompra = New System.Windows.Forms.Label()
        Me.lblCompraAcumulada = New System.Windows.Forms.Label()
        Me.lblFrecuenciaCompra = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlTipo2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdTipoRepuesto = New Telerik.WinControls.UI.RadGridView()
        Me.pnlTipo1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.panelGrafica = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gaugeVenta = New System.Windows.Forms.AGauge()
        Me.rgbEstadistica = New Telerik.WinControls.UI.RadGroupBox()
        Me.rgbGrafica = New Telerik.WinControls.UI.RadGroupBox()
        Me.rcGrafica = New Telerik.WinControls.UI.RadChart()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        Me.tlpContenedor.SuspendLayout()
        Me.pnlInfoVentas.SuspendLayout()
        Me.pnlTipo2.SuspendLayout()
        CType(Me.grdTipoRepuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoRepuesto.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTipo1.SuspendLayout()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelGrafica.SuspendLayout()
        CType(Me.rgbEstadistica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbEstadistica.SuspendLayout()
        CType(Me.rgbGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbGrafica.SuspendLayout()
        CType(Me.rcGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Size = New System.Drawing.Size(809, 51)
        Me.pnlBarra.TabIndex = 123
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(690, 6)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 194
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(80, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 29)
        Me.Label16.TabIndex = 193
        Me.Label16.Text = "Cliente"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox5.Location = New System.Drawing.Point(32, 49)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(47, 37)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 192
        Me.PictureBox5.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.Controls.Add(Me.btnInfoCliente)
        Me.rgbInformacion.Controls.Add(Me.cmbCliente)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.lblClave)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 67)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(1250, 89)
        Me.rgbInformacion.TabIndex = 191
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(972, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(263, 60)
        Me.Label10.TabIndex = 202
        Me.Label10.Text = "Cantidades de Graficas representadas en miles (K)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnInfoCliente
        '
        Me.btnInfoCliente.BackColor = System.Drawing.Color.SteelBlue
        Me.btnInfoCliente.FlatAppearance.BorderSize = 0
        Me.btnInfoCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnInfoCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnInfoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfoCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoCliente.ForeColor = System.Drawing.Color.Transparent
        Me.btnInfoCliente.Image = Global.laFuente.My.Resources.Resources.buscar_Blanco
        Me.btnInfoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInfoCliente.Location = New System.Drawing.Point(655, 23)
        Me.btnInfoCliente.Name = "btnInfoCliente"
        Me.btnInfoCliente.Size = New System.Drawing.Size(103, 58)
        Me.btnInfoCliente.TabIndex = 179
        Me.btnInfoCliente.Text = "Buscar"
        Me.btnInfoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInfoCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInfoCliente.UseVisualStyleBackColor = False
        '
        'cmbCliente
        '
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(288, 42)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(350, 23)
        Me.cmbCliente.TabIndex = 176
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(30, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 25)
        Me.Label6.TabIndex = 170
        Me.Label6.Text = "Clave :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(200, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 25)
        Me.Label4.TabIndex = 168
        Me.Label4.Text = "Cliente :"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblClave.ForeColor = System.Drawing.Color.Black
        Me.lblClave.Location = New System.Drawing.Point(105, 37)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(36, 25)
        Me.lblClave.TabIndex = 171
        Me.lblClave.Text = "---"
        '
        'tlpContenedor
        '
        Me.tlpContenedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpContenedor.ColumnCount = 2
        Me.tlpContenedor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpContenedor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpContenedor.Controls.Add(Me.pnlInfoVentas, 0, 1)
        Me.tlpContenedor.Controls.Add(Me.pnlTipo2, 1, 0)
        Me.tlpContenedor.Controls.Add(Me.pnlTipo1, 0, 0)
        Me.tlpContenedor.Controls.Add(Me.panelGrafica, 1, 1)
        Me.tlpContenedor.Location = New System.Drawing.Point(13, 11)
        Me.tlpContenedor.Name = "tlpContenedor"
        Me.tlpContenedor.RowCount = 2
        Me.tlpContenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpContenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpContenedor.Size = New System.Drawing.Size(625, 366)
        Me.tlpContenedor.TabIndex = 194
        '
        'pnlInfoVentas
        '
        Me.pnlInfoVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfoVentas.Controls.Add(Me.lblUltimaCompra)
        Me.pnlInfoVentas.Controls.Add(Me.lblCompraAcumulada)
        Me.pnlInfoVentas.Controls.Add(Me.lblFrecuenciaCompra)
        Me.pnlInfoVentas.Controls.Add(Me.Label9)
        Me.pnlInfoVentas.Controls.Add(Me.Label8)
        Me.pnlInfoVentas.Controls.Add(Me.Label7)
        Me.pnlInfoVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInfoVentas.Location = New System.Drawing.Point(3, 186)
        Me.pnlInfoVentas.Name = "pnlInfoVentas"
        Me.pnlInfoVentas.Size = New System.Drawing.Size(306, 177)
        Me.pnlInfoVentas.TabIndex = 3
        '
        'lblUltimaCompra
        '
        Me.lblUltimaCompra.BackColor = System.Drawing.Color.Transparent
        Me.lblUltimaCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUltimaCompra.ForeColor = System.Drawing.Color.Black
        Me.lblUltimaCompra.Location = New System.Drawing.Point(13, 137)
        Me.lblUltimaCompra.Name = "lblUltimaCompra"
        Me.lblUltimaCompra.Size = New System.Drawing.Size(299, 18)
        Me.lblUltimaCompra.TabIndex = 201
        Me.lblUltimaCompra.Text = "-----"
        Me.lblUltimaCompra.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCompraAcumulada
        '
        Me.lblCompraAcumulada.BackColor = System.Drawing.Color.Transparent
        Me.lblCompraAcumulada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompraAcumulada.ForeColor = System.Drawing.Color.Black
        Me.lblCompraAcumulada.Location = New System.Drawing.Point(13, 84)
        Me.lblCompraAcumulada.Name = "lblCompraAcumulada"
        Me.lblCompraAcumulada.Size = New System.Drawing.Size(299, 18)
        Me.lblCompraAcumulada.TabIndex = 200
        Me.lblCompraAcumulada.Text = "0"
        Me.lblCompraAcumulada.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFrecuenciaCompra
        '
        Me.lblFrecuenciaCompra.BackColor = System.Drawing.Color.Transparent
        Me.lblFrecuenciaCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblFrecuenciaCompra.ForeColor = System.Drawing.Color.Black
        Me.lblFrecuenciaCompra.Location = New System.Drawing.Point(11, 37)
        Me.lblFrecuenciaCompra.Name = "lblFrecuenciaCompra"
        Me.lblFrecuenciaCompra.Size = New System.Drawing.Size(302, 18)
        Me.lblFrecuenciaCompra.TabIndex = 199
        Me.lblFrecuenciaCompra.Text = "0"
        Me.lblFrecuenciaCompra.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(16, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(296, 18)
        Me.Label9.TabIndex = 198
        Me.Label9.Text = "Fecha de Ultima Compra :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(13, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(299, 18)
        Me.Label8.TabIndex = 197
        Me.Label8.Text = "Compras acumulada del mes:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(11, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(301, 18)
        Me.Label7.TabIndex = 196
        Me.Label7.Text = "Frecuencia de Compra :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTipo2
        '
        Me.pnlTipo2.Controls.Add(Me.Label3)
        Me.pnlTipo2.Controls.Add(Me.grdTipoRepuesto)
        Me.pnlTipo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTipo2.Location = New System.Drawing.Point(315, 3)
        Me.pnlTipo2.Name = "pnlTipo2"
        Me.pnlTipo2.Size = New System.Drawing.Size(307, 177)
        Me.pnlTipo2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(65, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 24)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "Tipo de Repuesto"
        '
        'grdTipoRepuesto
        '
        Me.grdTipoRepuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTipoRepuesto.Location = New System.Drawing.Point(0, 45)
        '
        'grdTipoRepuesto
        '
        Me.grdTipoRepuesto.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoRepuesto.Name = "grdTipoRepuesto"
        Me.grdTipoRepuesto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoRepuesto.ReadOnly = True
        '
        '
        '
        Me.grdTipoRepuesto.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoRepuesto.Size = New System.Drawing.Size(307, 129)
        Me.grdTipoRepuesto.TabIndex = 195
        Me.grdTipoRepuesto.Text = "RadGridView1"
        Me.grdTipoRepuesto.ThemeName = "Office2007Black"
        '
        'pnlTipo1
        '
        Me.pnlTipo1.Controls.Add(Me.Label2)
        Me.pnlTipo1.Controls.Add(Me.grdTipoVehiculo)
        Me.pnlTipo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTipo1.Location = New System.Drawing.Point(3, 3)
        Me.pnlTipo1.Name = "pnlTipo1"
        Me.pnlTipo1.Size = New System.Drawing.Size(306, 177)
        Me.pnlTipo1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(67, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 24)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "Tipo de Vehiculo"
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTipoVehiculo.Location = New System.Drawing.Point(0, 45)
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoVehiculo.Name = "grdTipoVehiculo"
        Me.grdTipoVehiculo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.ReadOnly = True
        '
        '
        '
        Me.grdTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.Size = New System.Drawing.Size(306, 129)
        Me.grdTipoVehiculo.TabIndex = 0
        Me.grdTipoVehiculo.Text = "RadGridView1"
        Me.grdTipoVehiculo.ThemeName = "Office2007Black"
        '
        'panelGrafica
        '
        Me.panelGrafica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelGrafica.Controls.Add(Me.Label5)
        Me.panelGrafica.Controls.Add(Me.gaugeVenta)
        Me.panelGrafica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelGrafica.Location = New System.Drawing.Point(315, 186)
        Me.panelGrafica.Name = "panelGrafica"
        Me.panelGrafica.Size = New System.Drawing.Size(307, 177)
        Me.panelGrafica.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(4, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 80)
        Me.Label5.TabIndex = 197
        Me.Label5.Text = "Indicador de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Venta Acumulada:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gaugeVenta
        '
        Me.gaugeVenta.BaseArcColor = System.Drawing.Color.Gray
        Me.gaugeVenta.BaseArcRadius = 80
        Me.gaugeVenta.BaseArcStart = 135
        Me.gaugeVenta.BaseArcSweep = 270
        Me.gaugeVenta.BaseArcWidth = 2
        Me.gaugeVenta.Center = New System.Drawing.Point(100, 100)
        AGaugeRange1.Color = System.Drawing.Color.Red
        AGaugeRange1.EndValue = 80.0!
        AGaugeRange1.InnerRadius = 60
        AGaugeRange1.InRange = False
        AGaugeRange1.Name = "rango1"
        AGaugeRange1.OuterRadius = 80
        AGaugeRange1.StartValue = 0.0!
        AGaugeRange2.Color = System.Drawing.Color.Yellow
        AGaugeRange2.EndValue = 100.0!
        AGaugeRange2.InnerRadius = 60
        AGaugeRange2.InRange = False
        AGaugeRange2.Name = "rango2"
        AGaugeRange2.OuterRadius = 80
        AGaugeRange2.StartValue = 81.0!
        AGaugeRange3.Color = System.Drawing.Color.Lime
        AGaugeRange3.EndValue = 200.0!
        AGaugeRange3.InnerRadius = 60
        AGaugeRange3.InRange = False
        AGaugeRange3.Name = "rango3"
        AGaugeRange3.OuterRadius = 80
        AGaugeRange3.StartValue = 101.0!
        Me.gaugeVenta.GaugeRanges.Add(AGaugeRange1)
        Me.gaugeVenta.GaugeRanges.Add(AGaugeRange2)
        Me.gaugeVenta.GaugeRanges.Add(AGaugeRange3)
        Me.gaugeVenta.Location = New System.Drawing.Point(98, 3)
        Me.gaugeVenta.MaxValue = 200.0!
        Me.gaugeVenta.MinValue = 0.0!
        Me.gaugeVenta.Name = "gaugeVenta"
        Me.gaugeVenta.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray
        Me.gaugeVenta.NeedleColor2 = System.Drawing.Color.Silver
        Me.gaugeVenta.NeedleRadius = 80
        Me.gaugeVenta.NeedleType = System.Windows.Forms.NeedleType.Simple
        Me.gaugeVenta.NeedleWidth = 2
        Me.gaugeVenta.ScaleLinesInterColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gaugeVenta.ScaleLinesInterInnerRadius = 73
        Me.gaugeVenta.ScaleLinesInterOuterRadius = 80
        Me.gaugeVenta.ScaleLinesInterWidth = 1
        Me.gaugeVenta.ScaleLinesMajorColor = System.Drawing.Color.SteelBlue
        Me.gaugeVenta.ScaleLinesMajorInnerRadius = 70
        Me.gaugeVenta.ScaleLinesMajorOuterRadius = 80
        Me.gaugeVenta.ScaleLinesMajorStepValue = 10.0!
        Me.gaugeVenta.ScaleLinesMajorWidth = 2
        Me.gaugeVenta.ScaleLinesMinorColor = System.Drawing.Color.DodgerBlue
        Me.gaugeVenta.ScaleLinesMinorInnerRadius = 80
        Me.gaugeVenta.ScaleLinesMinorOuterRadius = 80
        Me.gaugeVenta.ScaleLinesMinorTicks = 9
        Me.gaugeVenta.ScaleLinesMinorWidth = 1
        Me.gaugeVenta.ScaleNumbersColor = System.Drawing.Color.Black
        Me.gaugeVenta.ScaleNumbersFormat = Nothing
        Me.gaugeVenta.ScaleNumbersRadius = 90
        Me.gaugeVenta.ScaleNumbersRotation = 0
        Me.gaugeVenta.ScaleNumbersStartScaleLine = 0
        Me.gaugeVenta.ScaleNumbersStepScaleLines = 1
        Me.gaugeVenta.Size = New System.Drawing.Size(204, 175)
        Me.gaugeVenta.TabIndex = 4
        Me.gaugeVenta.Text = "Ventas Acumulada"
        Me.gaugeVenta.Value = 0.0!
        '
        'rgbEstadistica
        '
        Me.rgbEstadistica.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbEstadistica.Controls.Add(Me.tlpContenedor)
        Me.rgbEstadistica.FooterImageIndex = -1
        Me.rgbEstadistica.FooterImageKey = ""
        Me.rgbEstadistica.HeaderImageIndex = -1
        Me.rgbEstadistica.HeaderImageKey = ""
        Me.rgbEstadistica.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbEstadistica.HeaderText = ""
        Me.rgbEstadistica.Location = New System.Drawing.Point(12, 162)
        Me.rgbEstadistica.Name = "rgbEstadistica"
        Me.rgbEstadistica.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbEstadistica.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbEstadistica.Size = New System.Drawing.Size(651, 390)
        Me.rgbEstadistica.TabIndex = 195
        '
        'rgbGrafica
        '
        Me.rgbGrafica.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbGrafica.Controls.Add(Me.rcGrafica)
        Me.rgbGrafica.FooterImageIndex = -1
        Me.rgbGrafica.FooterImageKey = ""
        Me.rgbGrafica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.rgbGrafica.HeaderImageIndex = -1
        Me.rgbGrafica.HeaderImageKey = ""
        Me.rgbGrafica.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbGrafica.HeaderText = ""
        Me.rgbGrafica.Location = New System.Drawing.Point(667, 162)
        Me.rgbGrafica.Name = "rgbGrafica"
        Me.rgbGrafica.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbGrafica.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.rgbGrafica.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbGrafica.Size = New System.Drawing.Size(595, 394)
        Me.rgbGrafica.TabIndex = 196
        Me.rgbGrafica.ThemeName = "Office2007Black"
        CType(Me.rgbGrafica.GetChildAt(0).GetChildAt(2), Telerik.WinControls.UI.GroupBoxFooter).Alignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'rcGrafica
        '
        Me.rcGrafica.ChartTitle.TextBlock.Text = "Grafica Ventas"
        Me.rcGrafica.DefaultType = Telerik.Charting.ChartSeriesType.Line
        Me.rcGrafica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rcGrafica.IntelligentLabelsEnabled = True
        Me.rcGrafica.Location = New System.Drawing.Point(10, 20)
        Me.rcGrafica.Name = "rcGrafica"
        Me.rcGrafica.PlotArea.XAxis.MinValue = 1.0R
        Me.rcGrafica.PlotArea.YAxis.MaxValue = 100.0R
        Me.rcGrafica.PlotArea.YAxis.Step = 10.0R
        ChartSeries1.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(255, Byte), Integer))
        ChartSeries1.Name = "Series 1"
        ChartSeries1.Type = Telerik.Charting.ChartSeriesType.Line
        ChartSeries2.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(122, Byte), Integer))
        ChartSeries2.Name = "Series 2"
        ChartSeries2.Type = Telerik.Charting.ChartSeriesType.Line
        Me.rcGrafica.Series.AddRange(New Telerik.Charting.ChartSeries() {ChartSeries1, ChartSeries2})
        Me.rcGrafica.Size = New System.Drawing.Size(575, 364)
        Me.rcGrafica.SkinsOverrideStyles = True
        Me.rcGrafica.TabIndex = 0
        '
        'frmClienteEstadistica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1270, 564)
        Me.Controls.Add(Me.rgbGrafica)
        Me.Controls.Add(Me.rgbEstadistica)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClienteEstadistica"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.rgbEstadistica, 0)
        Me.Controls.SetChildIndex(Me.rgbGrafica, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        Me.tlpContenedor.ResumeLayout(False)
        Me.pnlInfoVentas.ResumeLayout(False)
        Me.pnlTipo2.ResumeLayout(False)
        Me.pnlTipo2.PerformLayout()
        CType(Me.grdTipoRepuesto.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoRepuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTipo1.ResumeLayout(False)
        Me.pnlTipo1.PerformLayout()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelGrafica.ResumeLayout(False)
        CType(Me.rgbEstadistica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbEstadistica.ResumeLayout(False)
        CType(Me.rgbGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbGrafica.ResumeLayout(False)
        CType(Me.rcGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btnInfoCliente As System.Windows.Forms.Button
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents tlpContenedor As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rgbEstadistica As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rgbGrafica As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents pnlInfoVentas As System.Windows.Forms.Panel
    Friend WithEvents pnlTipo2 As System.Windows.Forms.Panel
    Friend WithEvents pnlTipo1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdTipoRepuesto As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblUltimaCompra As System.Windows.Forms.Label
    Friend WithEvents lblCompraAcumulada As System.Windows.Forms.Label
    Friend WithEvents lblFrecuenciaCompra As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents panelGrafica As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gaugeVenta As System.Windows.Forms.AGauge
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rcGrafica As Telerik.WinControls.UI.RadChart

End Class
