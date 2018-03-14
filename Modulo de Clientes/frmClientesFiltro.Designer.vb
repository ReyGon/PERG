<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientesFiltro
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
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbFiltro = New Telerik.WinControls.UI.RadGroupBox()
        Me.rgbClasificacionNegocio = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosClasificacionNegocio = New System.Windows.Forms.CheckBox()
        Me.grdClasificacionNegocio = New Telerik.WinControls.UI.RadGridView()
        Me.rgbTipoVehiculo = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosTipoVehiculo = New System.Windows.Forms.CheckBox()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.rgbPrecios = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosPrecios = New System.Windows.Forms.CheckBox()
        Me.grdPrecios = New Telerik.WinControls.UI.RadGridView()
        Me.rgbTipoNegocio = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosTipoNegocio = New System.Windows.Forms.CheckBox()
        Me.grdTipoNegocio = New Telerik.WinControls.UI.RadGridView()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkBuscarNombre = New System.Windows.Forms.CheckBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkBuscaCodigo = New System.Windows.Forms.CheckBox()
        Me.rgbTipoPago = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkTodosTipoPago = New System.Windows.Forms.CheckBox()
        Me.grdTipoPago = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFiltro.SuspendLayout()
        CType(Me.rgbClasificacionNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbClasificacionNegocio.SuspendLayout()
        CType(Me.grdClasificacionNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdClasificacionNegocio.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTipoVehiculo.SuspendLayout()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbPrecios.SuspendLayout()
        CType(Me.grdPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPrecios.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTipoNegocio.SuspendLayout()
        CType(Me.grdTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoNegocio.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTipoPago.SuspendLayout()
        CType(Me.grdTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoPago.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Size = New System.Drawing.Size(387, 48)
        Me.pnlBarra.TabIndex = 170
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(265, 2)
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
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox4.Location = New System.Drawing.Point(37, 54)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 175
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(76, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 32)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Filtro"
        '
        'rgbFiltro
        '
        Me.rgbFiltro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbFiltro.Controls.Add(Me.rgbClasificacionNegocio)
        Me.rgbFiltro.Controls.Add(Me.rgbTipoVehiculo)
        Me.rgbFiltro.Controls.Add(Me.rgbPrecios)
        Me.rgbFiltro.Controls.Add(Me.rgbTipoNegocio)
        Me.rgbFiltro.Controls.Add(Me.txtNombre)
        Me.rgbFiltro.Controls.Add(Me.Label4)
        Me.rgbFiltro.Controls.Add(Me.chkBuscarNombre)
        Me.rgbFiltro.Controls.Add(Me.btnAgregar)
        Me.rgbFiltro.Controls.Add(Me.txtClave)
        Me.rgbFiltro.Controls.Add(Me.Label3)
        Me.rgbFiltro.Controls.Add(Me.chkBuscaCodigo)
        Me.rgbFiltro.Controls.Add(Me.rgbTipoPago)
        Me.rgbFiltro.FooterImageIndex = -1
        Me.rgbFiltro.FooterImageKey = ""
        Me.rgbFiltro.HeaderImageIndex = -1
        Me.rgbFiltro.HeaderImageKey = ""
        Me.rgbFiltro.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbFiltro.HeaderText = ""
        Me.rgbFiltro.Location = New System.Drawing.Point(13, 75)
        Me.rgbFiltro.Name = "rgbFiltro"
        Me.rgbFiltro.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFiltro.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFiltro.Size = New System.Drawing.Size(820, 500)
        Me.rgbFiltro.TabIndex = 173
        '
        'rgbClasificacionNegocio
        '
        Me.rgbClasificacionNegocio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbClasificacionNegocio.Controls.Add(Me.chkTodosClasificacionNegocio)
        Me.rgbClasificacionNegocio.Controls.Add(Me.grdClasificacionNegocio)
        Me.rgbClasificacionNegocio.FooterImageIndex = -1
        Me.rgbClasificacionNegocio.FooterImageKey = ""
        Me.rgbClasificacionNegocio.HeaderImageIndex = -1
        Me.rgbClasificacionNegocio.HeaderImageKey = ""
        Me.rgbClasificacionNegocio.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbClasificacionNegocio.HeaderText = "Clasificación de Negocio"
        Me.rgbClasificacionNegocio.Location = New System.Drawing.Point(291, 84)
        Me.rgbClasificacionNegocio.Name = "rgbClasificacionNegocio"
        Me.rgbClasificacionNegocio.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbClasificacionNegocio.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbClasificacionNegocio.Size = New System.Drawing.Size(248, 194)
        Me.rgbClasificacionNegocio.TabIndex = 9
        Me.rgbClasificacionNegocio.Text = "Clasificación de Negocio"
        Me.rgbClasificacionNegocio.ThemeName = "Office2007Black"
        '
        'chkTodosClasificacionNegocio
        '
        Me.chkTodosClasificacionNegocio.AutoSize = True
        Me.chkTodosClasificacionNegocio.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosClasificacionNegocio.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosClasificacionNegocio.Name = "chkTodosClasificacionNegocio"
        Me.chkTodosClasificacionNegocio.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosClasificacionNegocio.TabIndex = 7
        Me.chkTodosClasificacionNegocio.Text = "Todos"
        Me.chkTodosClasificacionNegocio.UseVisualStyleBackColor = True
        '
        'grdClasificacionNegocio
        '
        Me.grdClasificacionNegocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdClasificacionNegocio.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdClasificacionNegocio.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdClasificacionNegocio.ForeColor = System.Drawing.Color.Black
        Me.grdClasificacionNegocio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdClasificacionNegocio.Location = New System.Drawing.Point(12, 45)
        '
        'grdClasificacionNegocio
        '
        Me.grdClasificacionNegocio.MasterTemplate.AllowAddNewRow = False
        Me.grdClasificacionNegocio.MasterTemplate.EnableGrouping = False
        Me.grdClasificacionNegocio.Name = "grdClasificacionNegocio"
        Me.grdClasificacionNegocio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClasificacionNegocio.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdClasificacionNegocio.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdClasificacionNegocio.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClasificacionNegocio.Size = New System.Drawing.Size(223, 135)
        Me.grdClasificacionNegocio.TabIndex = 1
        Me.grdClasificacionNegocio.ThemeName = "Office2007Black"
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
        Me.rgbTipoVehiculo.HeaderText = "Tipo de Vehiculos"
        Me.rgbTipoVehiculo.Location = New System.Drawing.Point(560, 293)
        Me.rgbTipoVehiculo.Name = "rgbTipoVehiculo"
        Me.rgbTipoVehiculo.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTipoVehiculo.Size = New System.Drawing.Size(248, 194)
        Me.rgbTipoVehiculo.TabIndex = 10
        Me.rgbTipoVehiculo.Text = "Tipo de Vehiculos"
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
        'rgbPrecios
        '
        Me.rgbPrecios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbPrecios.Controls.Add(Me.chkTodosPrecios)
        Me.rgbPrecios.Controls.Add(Me.grdPrecios)
        Me.rgbPrecios.FooterImageIndex = -1
        Me.rgbPrecios.FooterImageKey = ""
        Me.rgbPrecios.HeaderImageIndex = -1
        Me.rgbPrecios.HeaderImageKey = ""
        Me.rgbPrecios.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbPrecios.HeaderText = "Precios"
        Me.rgbPrecios.Location = New System.Drawing.Point(291, 293)
        Me.rgbPrecios.Name = "rgbPrecios"
        Me.rgbPrecios.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbPrecios.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbPrecios.Size = New System.Drawing.Size(248, 194)
        Me.rgbPrecios.TabIndex = 9
        Me.rgbPrecios.Text = "Precios"
        Me.rgbPrecios.ThemeName = "Office2007Black"
        '
        'chkTodosPrecios
        '
        Me.chkTodosPrecios.AutoSize = True
        Me.chkTodosPrecios.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosPrecios.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosPrecios.Name = "chkTodosPrecios"
        Me.chkTodosPrecios.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosPrecios.TabIndex = 7
        Me.chkTodosPrecios.Text = "Todos"
        Me.chkTodosPrecios.UseVisualStyleBackColor = True
        '
        'grdPrecios
        '
        Me.grdPrecios.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdPrecios.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdPrecios.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdPrecios.ForeColor = System.Drawing.Color.Black
        Me.grdPrecios.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdPrecios.Location = New System.Drawing.Point(12, 45)
        '
        'grdPrecios
        '
        Me.grdPrecios.MasterTemplate.AllowAddNewRow = False
        Me.grdPrecios.MasterTemplate.EnableGrouping = False
        Me.grdPrecios.Name = "grdPrecios"
        Me.grdPrecios.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPrecios.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdPrecios.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdPrecios.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPrecios.Size = New System.Drawing.Size(223, 135)
        Me.grdPrecios.TabIndex = 1
        Me.grdPrecios.ThemeName = "Office2007Black"
        '
        'rgbTipoNegocio
        '
        Me.rgbTipoNegocio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbTipoNegocio.Controls.Add(Me.chkTodosTipoNegocio)
        Me.rgbTipoNegocio.Controls.Add(Me.grdTipoNegocio)
        Me.rgbTipoNegocio.FooterImageIndex = -1
        Me.rgbTipoNegocio.FooterImageKey = ""
        Me.rgbTipoNegocio.HeaderImageIndex = -1
        Me.rgbTipoNegocio.HeaderImageKey = ""
        Me.rgbTipoNegocio.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbTipoNegocio.HeaderText = "Tipo de Negocio"
        Me.rgbTipoNegocio.Location = New System.Drawing.Point(25, 84)
        Me.rgbTipoNegocio.Name = "rgbTipoNegocio"
        Me.rgbTipoNegocio.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTipoNegocio.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTipoNegocio.Size = New System.Drawing.Size(248, 194)
        Me.rgbTipoNegocio.TabIndex = 8
        Me.rgbTipoNegocio.Text = "Tipo de Negocio"
        Me.rgbTipoNegocio.ThemeName = "Office2007Black"
        '
        'chkTodosTipoNegocio
        '
        Me.chkTodosTipoNegocio.AutoSize = True
        Me.chkTodosTipoNegocio.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.chkTodosTipoNegocio.Location = New System.Drawing.Point(178, 23)
        Me.chkTodosTipoNegocio.Name = "chkTodosTipoNegocio"
        Me.chkTodosTipoNegocio.Size = New System.Drawing.Size(58, 19)
        Me.chkTodosTipoNegocio.TabIndex = 7
        Me.chkTodosTipoNegocio.Text = "Todos"
        Me.chkTodosTipoNegocio.UseVisualStyleBackColor = True
        '
        'grdTipoNegocio
        '
        Me.grdTipoNegocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoNegocio.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoNegocio.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoNegocio.ForeColor = System.Drawing.Color.Black
        Me.grdTipoNegocio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoNegocio.Location = New System.Drawing.Point(12, 45)
        '
        'grdTipoNegocio
        '
        Me.grdTipoNegocio.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoNegocio.MasterTemplate.EnableGrouping = False
        Me.grdTipoNegocio.Name = "grdTipoNegocio"
        Me.grdTipoNegocio.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoNegocio.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoNegocio.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoNegocio.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoNegocio.Size = New System.Drawing.Size(223, 135)
        Me.grdTipoNegocio.TabIndex = 1
        Me.grdTipoNegocio.ThemeName = "Office2007Black"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(279, 50)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(248, 20)
        Me.txtNombre.TabIndex = 131
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(217, 51)
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
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Image = Global.laFuente.My.Resources.Resources.filtroBlanco
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(560, 119)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(115, 55)
        Me.btnAgregar.TabIndex = 128
        Me.btnAgregar.Text = "Filtrar"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(279, 24)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(248, 20)
        Me.txtClave.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Berlin Sans FB", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(231, 26)
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
        Me.rgbTipoPago.Location = New System.Drawing.Point(25, 293)
        Me.rgbTipoPago.Name = "rgbTipoPago"
        Me.rgbTipoPago.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTipoPago.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTipoPago.Size = New System.Drawing.Size(248, 194)
        Me.rgbTipoPago.TabIndex = 2
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
        'frmClientesFiltro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(852, 587)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rgbFiltro)
        Me.Controls.Add(Me.pnlBarra)
        Me.Name = "frmClientesFiltro"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbFiltro, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFiltro.ResumeLayout(False)
        Me.rgbFiltro.PerformLayout()
        CType(Me.rgbClasificacionNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbClasificacionNegocio.ResumeLayout(False)
        Me.rgbClasificacionNegocio.PerformLayout()
        CType(Me.grdClasificacionNegocio.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdClasificacionNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTipoVehiculo.ResumeLayout(False)
        Me.rgbTipoVehiculo.PerformLayout()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbPrecios.ResumeLayout(False)
        Me.rgbPrecios.PerformLayout()
        CType(Me.grdPrecios.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTipoNegocio.ResumeLayout(False)
        Me.rgbTipoNegocio.PerformLayout()
        CType(Me.grdTipoNegocio.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTipoPago.ResumeLayout(False)
        Me.rgbTipoPago.PerformLayout()
        CType(Me.grdTipoPago.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rgbFiltro As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rgbTipoNegocio As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosTipoNegocio As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoNegocio As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkBuscarNombre As System.Windows.Forms.CheckBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkBuscaCodigo As System.Windows.Forms.CheckBox
    Friend WithEvents rgbTipoPago As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosTipoPago As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoPago As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbClasificacionNegocio As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosClasificacionNegocio As System.Windows.Forms.CheckBox
    Friend WithEvents grdClasificacionNegocio As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbTipoVehiculo As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosTipoVehiculo As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbPrecios As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkTodosPrecios As System.Windows.Forms.CheckBox
    Friend WithEvents grdPrecios As Telerik.WinControls.UI.RadGridView

End Class
