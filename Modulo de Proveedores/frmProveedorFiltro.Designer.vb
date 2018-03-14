<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedorFiltro
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
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbFiltro = New Telerik.WinControls.UI.RadGroupBox()
        Me.rgbTipoPago = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosTipoPago = New System.Windows.Forms.CheckBox()
        Me.grdTipoPago = New Telerik.WinControls.UI.RadGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaUltCompraHasta = New System.Windows.Forms.DateTimePicker()
        Me.chkBuscarPorFecha = New System.Windows.Forms.CheckBox()
        Me.dtpFechaUltCompraDesde = New System.Windows.Forms.DateTimePicker()
        Me.rgbMarcaRepuesto = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosMarcaRepuesto = New System.Windows.Forms.CheckBox()
        Me.grdMarcaRepuesto = New Telerik.WinControls.UI.RadGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rgbTipoRepuesto = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosTipoRepuesto = New System.Windows.Forms.CheckBox()
        Me.grdTipoRepuesto = New Telerik.WinControls.UI.RadGridView()
        Me.rgbTipoVehiculo = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosTipoVehiculo = New System.Windows.Forms.CheckBox()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkBuscarNombre = New System.Windows.Forms.CheckBox()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkBuscaCodigo = New System.Windows.Forms.CheckBox()
        Me.rgbInventario = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosProcedencia = New System.Windows.Forms.CheckBox()
        Me.grdProcedencia = New Telerik.WinControls.UI.RadGridView()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFiltro.SuspendLayout()
        CType(Me.rgbTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTipoPago.SuspendLayout()
        CType(Me.grdTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoPago.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbMarcaRepuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbMarcaRepuesto.SuspendLayout()
        CType(Me.grdMarcaRepuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMarcaRepuesto.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbTipoRepuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTipoRepuesto.SuspendLayout()
        CType(Me.grdTipoRepuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoRepuesto.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTipoVehiculo.SuspendLayout()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInventario.SuspendLayout()
        CType(Me.grdProcedencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProcedencia.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox4.Location = New System.Drawing.Point(36, 55)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 172
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(75, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 32)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Filtro"
        '
        'rgbFiltro
        '
        Me.rgbFiltro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbFiltro.Controls.Add(Me.rgbTipoPago)
        Me.rgbFiltro.Controls.Add(Me.Label6)
        Me.rgbFiltro.Controls.Add(Me.dtpFechaUltCompraHasta)
        Me.rgbFiltro.Controls.Add(Me.chkBuscarPorFecha)
        Me.rgbFiltro.Controls.Add(Me.dtpFechaUltCompraDesde)
        Me.rgbFiltro.Controls.Add(Me.rgbMarcaRepuesto)
        Me.rgbFiltro.Controls.Add(Me.Label5)
        Me.rgbFiltro.Controls.Add(Me.rgbTipoRepuesto)
        Me.rgbFiltro.Controls.Add(Me.rgbTipoVehiculo)
        Me.rgbFiltro.Controls.Add(Me.txtNombre)
        Me.rgbFiltro.Controls.Add(Me.Label4)
        Me.rgbFiltro.Controls.Add(Me.chkBuscarNombre)
        Me.rgbFiltro.Controls.Add(Me.btnFiltrar)
        Me.rgbFiltro.Controls.Add(Me.txtClave)
        Me.rgbFiltro.Controls.Add(Me.Label3)
        Me.rgbFiltro.Controls.Add(Me.chkBuscaCodigo)
        Me.rgbFiltro.Controls.Add(Me.rgbInventario)
        Me.rgbFiltro.FooterImageIndex = -1
        Me.rgbFiltro.FooterImageKey = ""
        Me.rgbFiltro.HeaderImageIndex = -1
        Me.rgbFiltro.HeaderImageKey = ""
        Me.rgbFiltro.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbFiltro.HeaderText = ""
        Me.rgbFiltro.Location = New System.Drawing.Point(11, 76)
        Me.rgbFiltro.Name = "rgbFiltro"
        Me.rgbFiltro.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFiltro.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFiltro.Size = New System.Drawing.Size(831, 499)
        Me.rgbFiltro.TabIndex = 170
        '
        'rgbTipoPago
        '
        Me.rgbTipoPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbTipoPago.Controls.Add(Me.chkTodosTipoPago)
        Me.rgbTipoPago.Controls.Add(Me.grdTipoPago)
        Me.rgbTipoPago.FooterImageIndex = -1
        Me.rgbTipoPago.FooterImageKey = ""
        Me.rgbTipoPago.HeaderImageIndex = -1
        Me.rgbTipoPago.HeaderImageKey = ""
        Me.rgbTipoPago.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbTipoPago.HeaderText = "Tipo de Pago"
        Me.rgbTipoPago.Location = New System.Drawing.Point(291, 100)
        Me.rgbTipoPago.Name = "rgbTipoPago"
        Me.rgbTipoPago.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTipoPago.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTipoPago.Size = New System.Drawing.Size(248, 194)
        Me.rgbTipoPago.TabIndex = 137
        Me.rgbTipoPago.Text = "Tipo de Pago"
        Me.rgbTipoPago.ThemeName = "Office2007Black"
        '
        'chkTodosTipoPago
        '
        Me.chkTodosTipoPago.AutoSize = True
        Me.chkTodosTipoPago.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosTipoPago.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosTipoPago.Name = "chkTodosTipoPago"
        Me.chkTodosTipoPago.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosTipoPago.TabIndex = 7
        Me.chkTodosTipoPago.Text = "Todos"
        Me.chkTodosTipoPago.UseVisualStyleBackColor = True
        '
        'grdTipoPago
        '
        Me.grdTipoPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoPago.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoPago.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoPago.ForeColor = System.Drawing.Color.Black
        Me.grdTipoPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoPago.Location = New System.Drawing.Point(12, 45)
        '
        'grdTipoPago
        '
        Me.grdTipoPago.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoPago.MasterTemplate.EnableGrouping = False
        Me.grdTipoPago.Name = "grdTipoPago"
        Me.grdTipoPago.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoPago.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoPago.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoPago.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoPago.Size = New System.Drawing.Size(223, 135)
        Me.grdTipoPago.TabIndex = 1
        Me.grdTipoPago.ThemeName = "Office2007Black"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(269, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Desde :"
        '
        'dtpFechaUltCompraHasta
        '
        Me.dtpFechaUltCompraHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaUltCompraHasta.Location = New System.Drawing.Point(524, 75)
        Me.dtpFechaUltCompraHasta.Name = "dtpFechaUltCompraHasta"
        Me.dtpFechaUltCompraHasta.Size = New System.Drawing.Size(145, 20)
        Me.dtpFechaUltCompraHasta.TabIndex = 135
        '
        'chkBuscarPorFecha
        '
        Me.chkBuscarPorFecha.AutoSize = True
        Me.chkBuscarPorFecha.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkBuscarPorFecha.Location = New System.Drawing.Point(25, 74)
        Me.chkBuscarPorFecha.Name = "chkBuscarPorFecha"
        Me.chkBuscarPorFecha.Size = New System.Drawing.Size(215, 19)
        Me.chkBuscarPorFecha.TabIndex = 136
        Me.chkBuscarPorFecha.Text = "Buscar por Ultima Fecha de Compra"
        Me.chkBuscarPorFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaUltCompraDesde
        '
        Me.dtpFechaUltCompraDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaUltCompraDesde.Location = New System.Drawing.Point(322, 74)
        Me.dtpFechaUltCompraDesde.Name = "dtpFechaUltCompraDesde"
        Me.dtpFechaUltCompraDesde.Size = New System.Drawing.Size(144, 20)
        Me.dtpFechaUltCompraDesde.TabIndex = 134
        '
        'rgbMarcaRepuesto
        '
        Me.rgbMarcaRepuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbMarcaRepuesto.Controls.Add(Me.chkTodosMarcaRepuesto)
        Me.rgbMarcaRepuesto.Controls.Add(Me.grdMarcaRepuesto)
        Me.rgbMarcaRepuesto.FooterImageIndex = -1
        Me.rgbMarcaRepuesto.FooterImageKey = ""
        Me.rgbMarcaRepuesto.HeaderImageIndex = -1
        Me.rgbMarcaRepuesto.HeaderImageKey = ""
        Me.rgbMarcaRepuesto.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbMarcaRepuesto.HeaderText = "Marca de Repuesto"
        Me.rgbMarcaRepuesto.Location = New System.Drawing.Point(560, 298)
        Me.rgbMarcaRepuesto.Name = "rgbMarcaRepuesto"
        Me.rgbMarcaRepuesto.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbMarcaRepuesto.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbMarcaRepuesto.Size = New System.Drawing.Size(248, 194)
        Me.rgbMarcaRepuesto.TabIndex = 134
        Me.rgbMarcaRepuesto.Text = "Marca de Repuesto"
        Me.rgbMarcaRepuesto.ThemeName = "Office2007Black"
        '
        'chkTodosMarcaRepuesto
        '
        Me.chkTodosMarcaRepuesto.AutoSize = True
        Me.chkTodosMarcaRepuesto.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosMarcaRepuesto.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosMarcaRepuesto.Name = "chkTodosMarcaRepuesto"
        Me.chkTodosMarcaRepuesto.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosMarcaRepuesto.TabIndex = 7
        Me.chkTodosMarcaRepuesto.Text = "Todos"
        Me.chkTodosMarcaRepuesto.UseVisualStyleBackColor = True
        '
        'grdMarcaRepuesto
        '
        Me.grdMarcaRepuesto.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdMarcaRepuesto.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdMarcaRepuesto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdMarcaRepuesto.ForeColor = System.Drawing.Color.Black
        Me.grdMarcaRepuesto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdMarcaRepuesto.Location = New System.Drawing.Point(12, 45)
        '
        'grdMarcaRepuesto
        '
        Me.grdMarcaRepuesto.MasterTemplate.AllowAddNewRow = False
        Me.grdMarcaRepuesto.MasterTemplate.EnableGrouping = False
        Me.grdMarcaRepuesto.Name = "grdMarcaRepuesto"
        Me.grdMarcaRepuesto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdMarcaRepuesto.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdMarcaRepuesto.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdMarcaRepuesto.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdMarcaRepuesto.Size = New System.Drawing.Size(223, 135)
        Me.grdMarcaRepuesto.TabIndex = 1
        Me.grdMarcaRepuesto.ThemeName = "Office2007Black"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(472, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Hasta :"
        '
        'rgbTipoRepuesto
        '
        Me.rgbTipoRepuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbTipoRepuesto.Controls.Add(Me.chkTodosTipoRepuesto)
        Me.rgbTipoRepuesto.Controls.Add(Me.grdTipoRepuesto)
        Me.rgbTipoRepuesto.FooterImageIndex = -1
        Me.rgbTipoRepuesto.FooterImageKey = ""
        Me.rgbTipoRepuesto.HeaderImageIndex = -1
        Me.rgbTipoRepuesto.HeaderImageKey = ""
        Me.rgbTipoRepuesto.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbTipoRepuesto.HeaderText = "Tipo de Repuesto"
        Me.rgbTipoRepuesto.Location = New System.Drawing.Point(291, 298)
        Me.rgbTipoRepuesto.Name = "rgbTipoRepuesto"
        Me.rgbTipoRepuesto.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTipoRepuesto.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTipoRepuesto.Size = New System.Drawing.Size(248, 194)
        Me.rgbTipoRepuesto.TabIndex = 133
        Me.rgbTipoRepuesto.Text = "Tipo de Repuesto"
        Me.rgbTipoRepuesto.ThemeName = "Office2007Black"
        '
        'chkTodosTipoRepuesto
        '
        Me.chkTodosTipoRepuesto.AutoSize = True
        Me.chkTodosTipoRepuesto.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosTipoRepuesto.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosTipoRepuesto.Name = "chkTodosTipoRepuesto"
        Me.chkTodosTipoRepuesto.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosTipoRepuesto.TabIndex = 7
        Me.chkTodosTipoRepuesto.Text = "Todos"
        Me.chkTodosTipoRepuesto.UseVisualStyleBackColor = True
        '
        'grdTipoRepuesto
        '
        Me.grdTipoRepuesto.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoRepuesto.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoRepuesto.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoRepuesto.ForeColor = System.Drawing.Color.Black
        Me.grdTipoRepuesto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoRepuesto.Location = New System.Drawing.Point(12, 45)
        '
        'grdTipoRepuesto
        '
        Me.grdTipoRepuesto.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoRepuesto.MasterTemplate.EnableGrouping = False
        Me.grdTipoRepuesto.Name = "grdTipoRepuesto"
        Me.grdTipoRepuesto.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoRepuesto.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoRepuesto.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoRepuesto.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoRepuesto.Size = New System.Drawing.Size(223, 135)
        Me.grdTipoRepuesto.TabIndex = 1
        Me.grdTipoRepuesto.ThemeName = "Office2007Black"
        '
        'rgbTipoVehiculo
        '
        Me.rgbTipoVehiculo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbTipoVehiculo.Controls.Add(Me.chkTodosTipoVehiculo)
        Me.rgbTipoVehiculo.Controls.Add(Me.grdTipoVehiculo)
        Me.rgbTipoVehiculo.FooterImageIndex = -1
        Me.rgbTipoVehiculo.FooterImageKey = ""
        Me.rgbTipoVehiculo.HeaderImageIndex = -1
        Me.rgbTipoVehiculo.HeaderImageKey = ""
        Me.rgbTipoVehiculo.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbTipoVehiculo.HeaderText = "Tipo de Vehiculo"
        Me.rgbTipoVehiculo.Location = New System.Drawing.Point(25, 298)
        Me.rgbTipoVehiculo.Name = "rgbTipoVehiculo"
        Me.rgbTipoVehiculo.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTipoVehiculo.Size = New System.Drawing.Size(248, 194)
        Me.rgbTipoVehiculo.TabIndex = 132
        Me.rgbTipoVehiculo.Text = "Tipo de Vehiculo"
        Me.rgbTipoVehiculo.ThemeName = "Office2007Black"
        '
        'chkTodosTipoVehiculo
        '
        Me.chkTodosTipoVehiculo.AutoSize = True
        Me.chkTodosTipoVehiculo.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosTipoVehiculo.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosTipoVehiculo.Name = "chkTodosTipoVehiculo"
        Me.chkTodosTipoVehiculo.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosTipoVehiculo.TabIndex = 7
        Me.chkTodosTipoVehiculo.Text = "Todos"
        Me.chkTodosTipoVehiculo.UseVisualStyleBackColor = True
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoVehiculo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoVehiculo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoVehiculo.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoVehiculo.Location = New System.Drawing.Point(12, 45)
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoVehiculo.MasterTemplate.EnableGrouping = False
        Me.grdTipoVehiculo.Name = "grdTipoVehiculo"
        Me.grdTipoVehiculo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoVehiculo.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.Size = New System.Drawing.Size(223, 135)
        Me.grdTipoVehiculo.TabIndex = 1
        Me.grdTipoVehiculo.ThemeName = "Office2007Black"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(320, 50)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(248, 20)
        Me.txtNombre.TabIndex = 131
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(258, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "Nombre :"
        '
        'chkBuscarNombre
        '
        Me.chkBuscarNombre.AutoSize = True
        Me.chkBuscarNombre.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBuscarNombre.Location = New System.Drawing.Point(25, 51)
        Me.chkBuscarNombre.Name = "chkBuscarNombre"
        Me.chkBuscarNombre.Size = New System.Drawing.Size(128, 19)
        Me.chkBuscarNombre.TabIndex = 129
        Me.chkBuscarNombre.Text = "Buscar por Nombre"
        Me.chkBuscarNombre.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnFiltrar.FlatAppearance.BorderSize = 0
        Me.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.ForeColor = System.Drawing.Color.Transparent
        Me.btnFiltrar.Image = Global.laFuente.My.Resources.Resources.filtroBlanco
        Me.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFiltrar.Location = New System.Drawing.Point(560, 119)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(115, 55)
        Me.btnFiltrar.TabIndex = 128
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFiltrar.UseVisualStyleBackColor = False
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(320, 24)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(248, 20)
        Me.txtClave.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(272, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Clave :"
        '
        'chkBuscaCodigo
        '
        Me.chkBuscaCodigo.AutoSize = True
        Me.chkBuscaCodigo.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBuscaCodigo.Location = New System.Drawing.Point(25, 29)
        Me.chkBuscaCodigo.Name = "chkBuscaCodigo"
        Me.chkBuscaCodigo.Size = New System.Drawing.Size(114, 19)
        Me.chkBuscaCodigo.TabIndex = 9
        Me.chkBuscaCodigo.Text = "Buscar por Clave"
        Me.chkBuscaCodigo.UseVisualStyleBackColor = True
        '
        'rgbInventario
        '
        Me.rgbInventario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbInventario.Controls.Add(Me.chkTodosProcedencia)
        Me.rgbInventario.Controls.Add(Me.grdProcedencia)
        Me.rgbInventario.FooterImageIndex = -1
        Me.rgbInventario.FooterImageKey = ""
        Me.rgbInventario.HeaderImageIndex = -1
        Me.rgbInventario.HeaderImageKey = ""
        Me.rgbInventario.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInventario.HeaderText = "Procedencia"
        Me.rgbInventario.Location = New System.Drawing.Point(25, 100)
        Me.rgbInventario.Name = "rgbInventario"
        Me.rgbInventario.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInventario.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInventario.Size = New System.Drawing.Size(248, 192)
        Me.rgbInventario.TabIndex = 2
        Me.rgbInventario.Text = "Procedencia"
        Me.rgbInventario.ThemeName = "Office2007Black"
        '
        'chkTodosProcedencia
        '
        Me.chkTodosProcedencia.AutoSize = True
        Me.chkTodosProcedencia.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosProcedencia.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosProcedencia.Name = "chkTodosProcedencia"
        Me.chkTodosProcedencia.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosProcedencia.TabIndex = 7
        Me.chkTodosProcedencia.Text = "Todos"
        Me.chkTodosProcedencia.UseVisualStyleBackColor = True
        '
        'grdProcedencia
        '
        Me.grdProcedencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdProcedencia.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProcedencia.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProcedencia.ForeColor = System.Drawing.Color.Black
        Me.grdProcedencia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProcedencia.Location = New System.Drawing.Point(12, 45)
        '
        'grdProcedencia
        '
        Me.grdProcedencia.MasterTemplate.AllowAddNewRow = False
        Me.grdProcedencia.MasterTemplate.EnableGrouping = False
        Me.grdProcedencia.Name = "grdProcedencia"
        Me.grdProcedencia.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProcedencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProcedencia.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdProcedencia.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProcedencia.Size = New System.Drawing.Size(223, 135)
        Me.grdProcedencia.TabIndex = 1
        Me.grdProcedencia.ThemeName = "Office2007Black"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(465, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(392, 48)
        Me.pnlBarra.TabIndex = 169
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(270, 2)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 195
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
        'frmProveedorFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(852, 587)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rgbFiltro)
        Me.Controls.Add(Me.pnlBarra)
        Me.Name = "frmProveedorFiltro"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbFiltro, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFiltro.ResumeLayout(False)
        Me.rgbFiltro.PerformLayout()
        CType(Me.rgbTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTipoPago.ResumeLayout(False)
        Me.rgbTipoPago.PerformLayout()
        CType(Me.grdTipoPago.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbMarcaRepuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbMarcaRepuesto.ResumeLayout(False)
        Me.rgbMarcaRepuesto.PerformLayout()
        CType(Me.grdMarcaRepuesto.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMarcaRepuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbTipoRepuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTipoRepuesto.ResumeLayout(False)
        Me.rgbTipoRepuesto.PerformLayout()
        CType(Me.grdTipoRepuesto.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoRepuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTipoVehiculo.ResumeLayout(False)
        Me.rgbTipoVehiculo.PerformLayout()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInventario.ResumeLayout(False)
        Me.rgbInventario.PerformLayout()
        CType(Me.grdProcedencia.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProcedencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rgbFiltro As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkBuscarNombre As System.Windows.Forms.CheckBox
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkBuscaCodigo As System.Windows.Forms.CheckBox
    Friend WithEvents rgbInventario As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosProcedencia As System.Windows.Forms.CheckBox
    Friend WithEvents grdProcedencia As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaUltCompraHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaUltCompraDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents chkBuscarPorFecha As System.Windows.Forms.CheckBox
    Friend WithEvents rgbMarcaRepuesto As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosMarcaRepuesto As System.Windows.Forms.CheckBox
    Friend WithEvents grdMarcaRepuesto As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbTipoRepuesto As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosTipoRepuesto As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoRepuesto As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbTipoVehiculo As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosTipoVehiculo As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbTipoPago As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosTipoPago As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoPago As Telerik.WinControls.UI.RadGridView

End Class
