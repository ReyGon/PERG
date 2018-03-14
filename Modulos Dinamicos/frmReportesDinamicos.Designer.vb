<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportesDinamicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportesDinamicos))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnCopiarFilas = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListado = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Progreso = New Telerik.WinControls.UI.RadProgressBar()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.rbtCreditoClientes = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.rbtFacturaPagos = New System.Windows.Forms.RadioButton()
        Me.rbtClientesFacturas = New System.Windows.Forms.RadioButton()
        Me.rbtPagosGeneral = New System.Windows.Forms.RadioButton()
        Me.rbtClientesPrecios = New System.Windows.Forms.RadioButton()
        Me.rbtVentaLineaPais = New System.Windows.Forms.RadioButton()
        Me.rbtVentasGeneral = New System.Windows.Forms.RadioButton()
        Me.rbtParticipacionMercado = New System.Windows.Forms.RadioButton()
        Me.rbtClientes23WH = New System.Windows.Forms.RadioButton()
        Me.rbtImpactoPS = New System.Windows.Forms.RadioButton()
        Me.rbtPedirNuevos = New System.Windows.Forms.RadioButton()
        Me.rbtSurtirVentas = New System.Windows.Forms.RadioButton()
        Me.rbtPromedioCompras = New System.Windows.Forms.RadioButton()
        Me.rbtFrecuencias = New System.Windows.Forms.RadioButton()
        Me.rbtTipoPrecios = New System.Windows.Forms.RadioButton()
        Me.rbtVentasCliente = New System.Windows.Forms.RadioButton()
        Me.rbtSurtir = New System.Windows.Forms.RadioButton()
        Me.rbtProductosNuevos = New System.Windows.Forms.RadioButton()
        Me.rbtRotaciones = New System.Windows.Forms.RadioButton()
        Me.rbtClientesVencer = New System.Windows.Forms.RadioButton()
        Me.rbtVentasLinea = New System.Windows.Forms.RadioButton()
        Me.rbtVentasProducto = New System.Windows.Forms.RadioButton()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbTipoPrecio = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMunicipio = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoVehiculo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbMarcaRepuesto = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbClienteCategoria = New System.Windows.Forms.ComboBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Progreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
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
        Me.pnlBarra.Size = New System.Drawing.Size(753, 48)
        Me.pnlBarra.TabIndex = 106
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(643, 3)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 117
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
        'btnConsulta
        '
        Me.btnConsulta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsulta.BackColor = System.Drawing.Color.SteelBlue
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.ForeColor = System.Drawing.Color.Transparent
        Me.btnConsulta.Location = New System.Drawing.Point(901, 60)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(153, 30)
        Me.btnConsulta.TabIndex = 184
        Me.btnConsulta.Text = "Generar Consulta"
        Me.btnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsulta.UseVisualStyleBackColor = False
        '
        'btnCopiarFilas
        '
        Me.btnCopiarFilas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopiarFilas.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCopiarFilas.FlatAppearance.BorderSize = 0
        Me.btnCopiarFilas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnCopiarFilas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnCopiarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopiarFilas.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiarFilas.ForeColor = System.Drawing.Color.Transparent
        Me.btnCopiarFilas.Location = New System.Drawing.Point(1060, 60)
        Me.btnCopiarFilas.Name = "btnCopiarFilas"
        Me.btnCopiarFilas.Size = New System.Drawing.Size(153, 30)
        Me.btnCopiarFilas.TabIndex = 187
        Me.btnCopiarFilas.Text = "Copiar Informacion"
        Me.btnCopiarFilas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCopiarFilas.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdListado)
        Me.Panel1.Location = New System.Drawing.Point(2, 261)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1214, 270)
        Me.Panel1.TabIndex = 188
        '
        'grdListado
        '
        Me.grdListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListado.Location = New System.Drawing.Point(3, 3)
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(1208, 264)
        Me.grdListado.TabIndex = 111
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(689, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 19)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Hasta :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(490, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "Desde :"
        '
        'dtpHasta
        '
        Me.dtpHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(746, 64)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(101, 20)
        Me.dtpHasta.TabIndex = 222
        '
        'dtpDesde
        '
        Me.dtpDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(550, 65)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(101, 20)
        Me.dtpDesde.TabIndex = 221
        '
        'Progreso
        '
        Me.Progreso.Dash = False
        Me.Progreso.Location = New System.Drawing.Point(5, 230)
        Me.Progreso.Name = "Progreso"
        Me.Progreso.Size = New System.Drawing.Size(453, 25)
        Me.Progreso.TabIndex = 225
        Me.Progreso.Text = "0 %"
        Me.Progreso.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Controls.Add(Me.RadioButton5)
        Me.RadGroupBox1.Controls.Add(Me.rbtCreditoClientes)
        Me.RadGroupBox1.Controls.Add(Me.RadioButton7)
        Me.RadGroupBox1.Controls.Add(Me.rbtFacturaPagos)
        Me.RadGroupBox1.Controls.Add(Me.rbtClientesFacturas)
        Me.RadGroupBox1.Controls.Add(Me.rbtPagosGeneral)
        Me.RadGroupBox1.Controls.Add(Me.rbtClientesPrecios)
        Me.RadGroupBox1.Controls.Add(Me.rbtVentaLineaPais)
        Me.RadGroupBox1.Controls.Add(Me.rbtVentasGeneral)
        Me.RadGroupBox1.Controls.Add(Me.rbtParticipacionMercado)
        Me.RadGroupBox1.Controls.Add(Me.rbtClientes23WH)
        Me.RadGroupBox1.Controls.Add(Me.rbtImpactoPS)
        Me.RadGroupBox1.Controls.Add(Me.rbtPedirNuevos)
        Me.RadGroupBox1.Controls.Add(Me.rbtSurtirVentas)
        Me.RadGroupBox1.Controls.Add(Me.rbtPromedioCompras)
        Me.RadGroupBox1.Controls.Add(Me.rbtFrecuencias)
        Me.RadGroupBox1.Controls.Add(Me.rbtTipoPrecios)
        Me.RadGroupBox1.Controls.Add(Me.rbtVentasCliente)
        Me.RadGroupBox1.Controls.Add(Me.rbtSurtir)
        Me.RadGroupBox1.Controls.Add(Me.rbtProductosNuevos)
        Me.RadGroupBox1.Controls.Add(Me.rbtRotaciones)
        Me.RadGroupBox1.Controls.Add(Me.rbtClientesVencer)
        Me.RadGroupBox1.Controls.Add(Me.rbtVentasLinea)
        Me.RadGroupBox1.Controls.Add(Me.rbtVentasProducto)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Reportes"
        Me.RadGroupBox1.Location = New System.Drawing.Point(3, 55)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(455, 169)
        Me.RadGroupBox1.TabIndex = 248
        Me.RadGroupBox1.Text = "Reportes"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButton5.Location = New System.Drawing.Point(349, 140)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton5.TabIndex = 240
        Me.RadioButton5.Text = "Sin Efecto"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'rbtCreditoClientes
        '
        Me.rbtCreditoClientes.AutoSize = True
        Me.rbtCreditoClientes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtCreditoClientes.Location = New System.Drawing.Point(5, 140)
        Me.rbtCreditoClientes.Name = "rbtCreditoClientes"
        Me.rbtCreditoClientes.Size = New System.Drawing.Size(109, 19)
        Me.rbtCreditoClientes.TabIndex = 237
        Me.rbtCreditoClientes.Text = "Credito Clientes"
        Me.rbtCreditoClientes.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButton7.Location = New System.Drawing.Point(239, 140)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton7.TabIndex = 238
        Me.RadioButton7.Text = "Sin Efecto"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'rbtFacturaPagos
        '
        Me.rbtFacturaPagos.AutoSize = True
        Me.rbtFacturaPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtFacturaPagos.Location = New System.Drawing.Point(123, 140)
        Me.rbtFacturaPagos.Name = "rbtFacturaPagos"
        Me.rbtFacturaPagos.Size = New System.Drawing.Size(99, 19)
        Me.rbtFacturaPagos.TabIndex = 239
        Me.rbtFacturaPagos.Text = "Factura Pagos"
        Me.rbtFacturaPagos.UseVisualStyleBackColor = True
        '
        'rbtClientesFacturas
        '
        Me.rbtClientesFacturas.AutoSize = True
        Me.rbtClientesFacturas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtClientesFacturas.Location = New System.Drawing.Point(349, 115)
        Me.rbtClientesFacturas.Name = "rbtClientesFacturas"
        Me.rbtClientesFacturas.Size = New System.Drawing.Size(91, 19)
        Me.rbtClientesFacturas.TabIndex = 236
        Me.rbtClientesFacturas.Text = "Fac. Clientes"
        Me.rbtClientesFacturas.UseVisualStyleBackColor = True
        '
        'rbtPagosGeneral
        '
        Me.rbtPagosGeneral.AutoSize = True
        Me.rbtPagosGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtPagosGeneral.Location = New System.Drawing.Point(5, 115)
        Me.rbtPagosGeneral.Name = "rbtPagosGeneral"
        Me.rbtPagosGeneral.Size = New System.Drawing.Size(100, 19)
        Me.rbtPagosGeneral.TabIndex = 233
        Me.rbtPagosGeneral.Text = "Pagos General"
        Me.rbtPagosGeneral.UseVisualStyleBackColor = True
        '
        'rbtClientesPrecios
        '
        Me.rbtClientesPrecios.AutoSize = True
        Me.rbtClientesPrecios.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtClientesPrecios.Location = New System.Drawing.Point(239, 115)
        Me.rbtClientesPrecios.Name = "rbtClientesPrecios"
        Me.rbtClientesPrecios.Size = New System.Drawing.Size(103, 19)
        Me.rbtClientesPrecios.TabIndex = 234
        Me.rbtClientesPrecios.Text = "Precios Cliente"
        Me.rbtClientesPrecios.UseVisualStyleBackColor = True
        '
        'rbtVentaLineaPais
        '
        Me.rbtVentaLineaPais.AutoSize = True
        Me.rbtVentaLineaPais.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtVentaLineaPais.Location = New System.Drawing.Point(123, 115)
        Me.rbtVentaLineaPais.Name = "rbtVentaLineaPais"
        Me.rbtVentaLineaPais.Size = New System.Drawing.Size(94, 19)
        Me.rbtVentaLineaPais.TabIndex = 235
        Me.rbtVentaLineaPais.Text = "Vtas. Linea P."
        Me.rbtVentaLineaPais.UseVisualStyleBackColor = True
        '
        'rbtVentasGeneral
        '
        Me.rbtVentasGeneral.AutoSize = True
        Me.rbtVentasGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtVentasGeneral.Location = New System.Drawing.Point(349, 90)
        Me.rbtVentasGeneral.Name = "rbtVentasGeneral"
        Me.rbtVentasGeneral.Size = New System.Drawing.Size(103, 19)
        Me.rbtVentasGeneral.TabIndex = 232
        Me.rbtVentasGeneral.Text = "Ventas General"
        Me.rbtVentasGeneral.UseVisualStyleBackColor = True
        '
        'rbtParticipacionMercado
        '
        Me.rbtParticipacionMercado.AutoSize = True
        Me.rbtParticipacionMercado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtParticipacionMercado.Location = New System.Drawing.Point(5, 90)
        Me.rbtParticipacionMercado.Name = "rbtParticipacionMercado"
        Me.rbtParticipacionMercado.Size = New System.Drawing.Size(99, 19)
        Me.rbtParticipacionMercado.TabIndex = 229
        Me.rbtParticipacionMercado.Text = "Part. Mercado"
        Me.rbtParticipacionMercado.UseVisualStyleBackColor = True
        '
        'rbtClientes23WH
        '
        Me.rbtClientes23WH.AutoSize = True
        Me.rbtClientes23WH.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtClientes23WH.Location = New System.Drawing.Point(239, 90)
        Me.rbtClientes23WH.Name = "rbtClientes23WH"
        Me.rbtClientes23WH.Size = New System.Drawing.Size(105, 19)
        Me.rbtClientes23WH.TabIndex = 230
        Me.rbtClientes23WH.Text = "Clientes 2,3WH"
        Me.rbtClientes23WH.UseVisualStyleBackColor = True
        '
        'rbtImpactoPS
        '
        Me.rbtImpactoPS.AutoSize = True
        Me.rbtImpactoPS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtImpactoPS.Location = New System.Drawing.Point(123, 90)
        Me.rbtImpactoPS.Name = "rbtImpactoPS"
        Me.rbtImpactoPS.Size = New System.Drawing.Size(85, 19)
        Me.rbtImpactoPS.TabIndex = 231
        Me.rbtImpactoPS.Text = "Impacto PS"
        Me.rbtImpactoPS.UseVisualStyleBackColor = True
        '
        'rbtPedirNuevos
        '
        Me.rbtPedirNuevos.AutoSize = True
        Me.rbtPedirNuevos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtPedirNuevos.Location = New System.Drawing.Point(349, 66)
        Me.rbtPedirNuevos.Name = "rbtPedirNuevos"
        Me.rbtPedirNuevos.Size = New System.Drawing.Size(95, 19)
        Me.rbtPedirNuevos.TabIndex = 228
        Me.rbtPedirNuevos.Text = "Pedir Nuevos"
        Me.rbtPedirNuevos.UseVisualStyleBackColor = True
        '
        'rbtSurtirVentas
        '
        Me.rbtSurtirVentas.AutoSize = True
        Me.rbtSurtirVentas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtSurtirVentas.Location = New System.Drawing.Point(5, 66)
        Me.rbtSurtirVentas.Name = "rbtSurtirVentas"
        Me.rbtSurtirVentas.Size = New System.Drawing.Size(96, 19)
        Me.rbtSurtirVentas.TabIndex = 225
        Me.rbtSurtirVentas.Text = "P. Sur. Ventas"
        Me.rbtSurtirVentas.UseVisualStyleBackColor = True
        '
        'rbtPromedioCompras
        '
        Me.rbtPromedioCompras.AutoSize = True
        Me.rbtPromedioCompras.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtPromedioCompras.Location = New System.Drawing.Point(239, 66)
        Me.rbtPromedioCompras.Name = "rbtPromedioCompras"
        Me.rbtPromedioCompras.Size = New System.Drawing.Size(108, 19)
        Me.rbtPromedioCompras.TabIndex = 226
        Me.rbtPromedioCompras.Text = "Prom. Compras"
        Me.rbtPromedioCompras.UseVisualStyleBackColor = True
        '
        'rbtFrecuencias
        '
        Me.rbtFrecuencias.AutoSize = True
        Me.rbtFrecuencias.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtFrecuencias.Location = New System.Drawing.Point(123, 66)
        Me.rbtFrecuencias.Name = "rbtFrecuencias"
        Me.rbtFrecuencias.Size = New System.Drawing.Size(87, 19)
        Me.rbtFrecuencias.TabIndex = 227
        Me.rbtFrecuencias.Text = "Frecuencias"
        Me.rbtFrecuencias.UseVisualStyleBackColor = True
        '
        'rbtTipoPrecios
        '
        Me.rbtTipoPrecios.AutoSize = True
        Me.rbtTipoPrecios.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtTipoPrecios.Location = New System.Drawing.Point(349, 42)
        Me.rbtTipoPrecios.Name = "rbtTipoPrecios"
        Me.rbtTipoPrecios.Size = New System.Drawing.Size(90, 19)
        Me.rbtTipoPrecios.TabIndex = 224
        Me.rbtTipoPrecios.Text = "Tipo Precios"
        Me.rbtTipoPrecios.UseVisualStyleBackColor = True
        '
        'rbtVentasCliente
        '
        Me.rbtVentasCliente.AutoSize = True
        Me.rbtVentasCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtVentasCliente.Location = New System.Drawing.Point(349, 19)
        Me.rbtVentasCliente.Name = "rbtVentasCliente"
        Me.rbtVentasCliente.Size = New System.Drawing.Size(100, 19)
        Me.rbtVentasCliente.TabIndex = 224
        Me.rbtVentasCliente.Text = "Ventas Cliente"
        Me.rbtVentasCliente.UseVisualStyleBackColor = True
        '
        'rbtSurtir
        '
        Me.rbtSurtir.AutoSize = True
        Me.rbtSurtir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtSurtir.Location = New System.Drawing.Point(123, 19)
        Me.rbtSurtir.Name = "rbtSurtir"
        Me.rbtSurtir.Size = New System.Drawing.Size(66, 19)
        Me.rbtSurtir.TabIndex = 221
        Me.rbtSurtir.Text = "P. Surtir"
        Me.rbtSurtir.UseVisualStyleBackColor = True
        '
        'rbtProductosNuevos
        '
        Me.rbtProductosNuevos.AutoSize = True
        Me.rbtProductosNuevos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtProductosNuevos.Location = New System.Drawing.Point(239, 42)
        Me.rbtProductosNuevos.Name = "rbtProductosNuevos"
        Me.rbtProductosNuevos.Size = New System.Drawing.Size(96, 19)
        Me.rbtProductosNuevos.TabIndex = 222
        Me.rbtProductosNuevos.Text = "Prod. Nuevos"
        Me.rbtProductosNuevos.UseVisualStyleBackColor = True
        '
        'rbtRotaciones
        '
        Me.rbtRotaciones.AutoSize = True
        Me.rbtRotaciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtRotaciones.Location = New System.Drawing.Point(5, 19)
        Me.rbtRotaciones.Name = "rbtRotaciones"
        Me.rbtRotaciones.Size = New System.Drawing.Size(83, 19)
        Me.rbtRotaciones.TabIndex = 221
        Me.rbtRotaciones.Text = "Rotaciones"
        Me.rbtRotaciones.UseVisualStyleBackColor = True
        '
        'rbtClientesVencer
        '
        Me.rbtClientesVencer.AutoSize = True
        Me.rbtClientesVencer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtClientesVencer.Location = New System.Drawing.Point(123, 42)
        Me.rbtClientesVencer.Name = "rbtClientesVencer"
        Me.rbtClientesVencer.Size = New System.Drawing.Size(96, 19)
        Me.rbtClientesVencer.TabIndex = 223
        Me.rbtClientesVencer.Text = "Carter Vencer"
        Me.rbtClientesVencer.UseVisualStyleBackColor = True
        '
        'rbtVentasLinea
        '
        Me.rbtVentasLinea.AutoSize = True
        Me.rbtVentasLinea.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtVentasLinea.Location = New System.Drawing.Point(239, 19)
        Me.rbtVentasLinea.Name = "rbtVentasLinea"
        Me.rbtVentasLinea.Size = New System.Drawing.Size(91, 19)
        Me.rbtVentasLinea.TabIndex = 222
        Me.rbtVentasLinea.Text = "Ventas Linea"
        Me.rbtVentasLinea.UseVisualStyleBackColor = True
        '
        'rbtVentasProducto
        '
        Me.rbtVentasProducto.AutoSize = True
        Me.rbtVentasProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtVentasProducto.Location = New System.Drawing.Point(5, 42)
        Me.rbtVentasProducto.Name = "rbtVentasProducto"
        Me.rbtVentasProducto.Size = New System.Drawing.Size(112, 19)
        Me.rbtVentasProducto.TabIndex = 223
        Me.rbtVentasProducto.Text = "Ventas Producto"
        Me.rbtVentasProducto.UseVisualStyleBackColor = True
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox2.Controls.Add(Me.cmbTipoPrecio)
        Me.RadGroupBox2.Controls.Add(Me.Label14)
        Me.RadGroupBox2.Controls.Add(Me.cmbPais)
        Me.RadGroupBox2.Controls.Add(Me.Label12)
        Me.RadGroupBox2.Controls.Add(Me.cmbMunicipio)
        Me.RadGroupBox2.Controls.Add(Me.Label10)
        Me.RadGroupBox2.Controls.Add(Me.cmbDepartamento)
        Me.RadGroupBox2.Controls.Add(Me.Label11)
        Me.RadGroupBox2.Controls.Add(Me.cmbVendedor)
        Me.RadGroupBox2.Controls.Add(Me.Label4)
        Me.RadGroupBox2.Controls.Add(Me.cmbCliente)
        Me.RadGroupBox2.Controls.Add(Me.Label8)
        Me.RadGroupBox2.Controls.Add(Me.cmbProducto)
        Me.RadGroupBox2.Controls.Add(Me.Label7)
        Me.RadGroupBox2.Controls.Add(Me.cmbTipoVehiculo)
        Me.RadGroupBox2.Controls.Add(Me.Label6)
        Me.RadGroupBox2.Controls.Add(Me.cmbMarcaRepuesto)
        Me.RadGroupBox2.Controls.Add(Me.Label5)
        Me.RadGroupBox2.Controls.Add(Me.Label13)
        Me.RadGroupBox2.Controls.Add(Me.cmbClienteCategoria)
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = "Filtros"
        Me.RadGroupBox2.Location = New System.Drawing.Point(466, 97)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox2.Size = New System.Drawing.Size(750, 158)
        Me.RadGroupBox2.TabIndex = 249
        Me.RadGroupBox2.Text = "Filtros"
        '
        'cmbTipoPrecio
        '
        Me.cmbTipoPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoPrecio.FormattingEnabled = True
        Me.cmbTipoPrecio.Location = New System.Drawing.Point(544, 128)
        Me.cmbTipoPrecio.Name = "cmbTipoPrecio"
        Me.cmbTipoPrecio.Size = New System.Drawing.Size(198, 21)
        Me.cmbTipoPrecio.TabIndex = 285
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(455, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 19)
        Me.Label14.TabIndex = 284
        Me.Label14.Text = "Tipo Precio :"
        '
        'cmbPais
        '
        Me.cmbPais.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(544, 47)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(198, 21)
        Me.cmbPais.TabIndex = 283
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(498, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 19)
        Me.Label12.TabIndex = 282
        Me.Label12.Text = "Pais :"
        '
        'cmbMunicipio
        '
        Me.cmbMunicipio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMunicipio.FormattingEnabled = True
        Me.cmbMunicipio.Location = New System.Drawing.Point(544, 101)
        Me.cmbMunicipio.Name = "cmbMunicipio"
        Me.cmbMunicipio.Size = New System.Drawing.Size(198, 21)
        Me.cmbMunicipio.TabIndex = 281
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(462, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 19)
        Me.Label10.TabIndex = 280
        Me.Label10.Text = "Municipio :"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(544, 74)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(198, 21)
        Me.cmbDepartamento.TabIndex = 279
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(433, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 278
        Me.Label11.Text = "Departamento :"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(124, 76)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(302, 21)
        Me.cmbVendedor.TabIndex = 277
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(41, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 19)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Vendedor :"
        '
        'cmbCliente
        '
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(124, 130)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(302, 21)
        Me.cmbCliente.TabIndex = 275
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(59, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 19)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Cliente :"
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(124, 103)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(302, 21)
        Me.cmbProducto.TabIndex = 273
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(45, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 19)
        Me.Label7.TabIndex = 272
        Me.Label7.Text = "Producto :"
        '
        'cmbTipoVehiculo
        '
        Me.cmbTipoVehiculo.FormattingEnabled = True
        Me.cmbTipoVehiculo.Location = New System.Drawing.Point(124, 49)
        Me.cmbTipoVehiculo.Name = "cmbTipoVehiculo"
        Me.cmbTipoVehiculo.Size = New System.Drawing.Size(302, 21)
        Me.cmbTipoVehiculo.TabIndex = 271
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 19)
        Me.Label6.TabIndex = 270
        Me.Label6.Text = "Tipo Vehiculo :"
        '
        'cmbMarcaRepuesto
        '
        Me.cmbMarcaRepuesto.FormattingEnabled = True
        Me.cmbMarcaRepuesto.Location = New System.Drawing.Point(124, 22)
        Me.cmbMarcaRepuesto.Name = "cmbMarcaRepuesto"
        Me.cmbMarcaRepuesto.Size = New System.Drawing.Size(302, 21)
        Me.cmbMarcaRepuesto.TabIndex = 269
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(2, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 19)
        Me.Label5.TabIndex = 268
        Me.Label5.Text = "Marca Repuesto :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(436, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 19)
        Me.Label13.TabIndex = 267
        Me.Label13.Text = "Clasificacion C :"
        '
        'cmbClienteCategoria
        '
        Me.cmbClienteCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbClienteCategoria.FormattingEnabled = True
        Me.cmbClienteCategoria.Location = New System.Drawing.Point(544, 22)
        Me.cmbClienteCategoria.Name = "cmbClienteCategoria"
        Me.cmbClienteCategoria.Size = New System.Drawing.Size(198, 21)
        Me.cmbClienteCategoria.TabIndex = 266
        '
        'frmReportesDinamicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1220, 532)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Progreso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCopiarFilas)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportesDinamicos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.btnConsulta, 0)
        Me.Controls.SetChildIndex(Me.btnCopiarFilas, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dtpDesde, 0)
        Me.Controls.SetChildIndex(Me.dtpHasta, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Progreso, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox2, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Progreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnCopiarFilas As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdListado As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Progreso As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCreditoClientes As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFacturaPagos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtClientesFacturas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPagosGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents rbtClientesPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVentaLineaPais As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVentasGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents rbtParticipacionMercado As System.Windows.Forms.RadioButton
    Friend WithEvents rbtClientes23WH As System.Windows.Forms.RadioButton
    Friend WithEvents rbtImpactoPS As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPedirNuevos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSurtirVentas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPromedioCompras As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFrecuencias As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTipoPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVentasCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSurtir As System.Windows.Forms.RadioButton
    Friend WithEvents rbtProductosNuevos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtRotaciones As System.Windows.Forms.RadioButton
    Friend WithEvents rbtClientesVencer As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVentasLinea As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVentasProducto As System.Windows.Forms.RadioButton
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbClienteCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbMarcaRepuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label


End Class
