﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloOfertas
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarArticuloOfertas))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Foto = New System.Windows.Forms.Panel()
        Me.pbx1Foto = New System.Windows.Forms.PictureBox()
        Me.lbl1Foto = New System.Windows.Forms.Label()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rgbFiltro = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbTiempoNoComprado = New System.Windows.Forms.ComboBox()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.lblGrid1 = New System.Windows.Forms.Label()
        Me.chkTodosTipo = New System.Windows.Forms.CheckBox()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.rpvInformacion = New Telerik.WinControls.UI.RadPageView()
        Me.pgDatos1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdProductos1 = New Telerik.WinControls.UI.RadGridView()
        Me.pgDatos2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdProductos2 = New Telerik.WinControls.UI.RadGridView()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCompatibilidad = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblEmpaque = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Foto.SuspendLayout()
        CType(Me.pbx1Foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFiltro.SuspendLayout()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rpvInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpvInformacion.SuspendLayout()
        Me.pgDatos1.SuspendLayout()
        CType(Me.grdProductos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgDatos2.SuspendLayout()
        CType(Me.grdProductos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
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
        Me.pnlBarra.Controls.Add(Me.pnx1Foto)
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, -1)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(590, 48)
        Me.pnlBarra.TabIndex = 200
        '
        'pnx1Foto
        '
        Me.pnx1Foto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Foto.BackColor = System.Drawing.Color.Navy
        Me.pnx1Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Foto.Controls.Add(Me.pbx1Foto)
        Me.pnx1Foto.Controls.Add(Me.lbl1Foto)
        Me.pnx1Foto.Location = New System.Drawing.Point(359, 4)
        Me.pnx1Foto.Name = "pnx1Foto"
        Me.pnx1Foto.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Foto.TabIndex = 202
        '
        'pbx1Foto
        '
        Me.pbx1Foto.Image = Global.laFuente.My.Resources.Resources.fotoBlanco
        Me.pbx1Foto.Location = New System.Drawing.Point(2, 4)
        Me.pbx1Foto.Name = "pbx1Foto"
        Me.pbx1Foto.Size = New System.Drawing.Size(32, 29)
        Me.pbx1Foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Foto.TabIndex = 93
        Me.pbx1Foto.TabStop = False
        '
        'lbl1Foto
        '
        Me.lbl1Foto.AutoSize = True
        Me.lbl1Foto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Foto.ForeColor = System.Drawing.Color.White
        Me.lbl1Foto.Location = New System.Drawing.Point(32, 9)
        Me.lbl1Foto.Name = "lbl1Foto"
        Me.lbl1Foto.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Foto.TabIndex = 94
        Me.lbl1Foto.Text = "Foto"
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(474, 3)
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
        'rgbFiltro
        '
        Me.rgbFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbFiltro.Controls.Add(Me.cmbTiempoNoComprado)
        Me.rgbFiltro.Controls.Add(Me.btnBusqueda)
        Me.rgbFiltro.Controls.Add(Me.Label2)
        Me.rgbFiltro.Controls.Add(Me.lblContador)
        Me.rgbFiltro.Controls.Add(Me.lblGrid1)
        Me.rgbFiltro.Controls.Add(Me.chkTodosTipo)
        Me.rgbFiltro.Controls.Add(Me.grdTipoVehiculo)
        Me.rgbFiltro.FooterImageIndex = -1
        Me.rgbFiltro.FooterImageKey = ""
        Me.rgbFiltro.HeaderImageIndex = -1
        Me.rgbFiltro.HeaderImageKey = ""
        Me.rgbFiltro.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbFiltro.HeaderText = ""
        Me.rgbFiltro.Location = New System.Drawing.Point(12, 75)
        Me.rgbFiltro.Name = "rgbFiltro"
        Me.rgbFiltro.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFiltro.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFiltro.Size = New System.Drawing.Size(1035, 156)
        Me.rgbFiltro.TabIndex = 211
        '
        'cmbTiempoNoComprado
        '
        Me.cmbTiempoNoComprado.FormattingEnabled = True
        Me.cmbTiempoNoComprado.Location = New System.Drawing.Point(529, 73)
        Me.cmbTiempoNoComprado.Name = "cmbTiempoNoComprado"
        Me.cmbTiempoNoComprado.Size = New System.Drawing.Size(175, 21)
        Me.cmbTiempoNoComprado.TabIndex = 208
        '
        'btnBusqueda
        '
        Me.btnBusqueda.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnBusqueda.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBusqueda.FlatAppearance.BorderSize = 0
        Me.btnBusqueda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBusqueda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBusqueda.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusqueda.ForeColor = System.Drawing.Color.Transparent
        Me.btnBusqueda.Image = Global.laFuente.My.Resources.Resources.buscar_Blanco
        Me.btnBusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBusqueda.Location = New System.Drawing.Point(723, 35)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(131, 59)
        Me.btnBusqueda.TabIndex = 207
        Me.btnBusqueda.Text = "Buscar"
        Me.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBusqueda.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(421, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 21)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "Desde Hace :"
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblContador.ForeColor = System.Drawing.Color.DimGray
        Me.lblContador.Location = New System.Drawing.Point(336, 15)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(19, 21)
        Me.lblContador.TabIndex = 206
        Me.lblContador.Text = "0"
        '
        'lblGrid1
        '
        Me.lblGrid1.AutoSize = True
        Me.lblGrid1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrid1.ForeColor = System.Drawing.Color.DimGray
        Me.lblGrid1.Location = New System.Drawing.Point(119, 15)
        Me.lblGrid1.Name = "lblGrid1"
        Me.lblGrid1.Size = New System.Drawing.Size(120, 19)
        Me.lblGrid1.TabIndex = 203
        Me.lblGrid1.Text = "Tipo de Vehículo"
        '
        'chkTodosTipo
        '
        Me.chkTodosTipo.AutoSize = True
        Me.chkTodosTipo.Location = New System.Drawing.Point(355, 19)
        Me.chkTodosTipo.Name = "chkTodosTipo"
        Me.chkTodosTipo.Size = New System.Drawing.Size(57, 17)
        Me.chkTodosTipo.TabIndex = 205
        Me.chkTodosTipo.Text = "Todos"
        Me.chkTodosTipo.UseVisualStyleBackColor = True
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTipoVehiculo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTipoVehiculo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTipoVehiculo.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTipoVehiculo.Location = New System.Drawing.Point(116, 39)
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoVehiculo.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn1.HeaderText = "Agregar"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmAgregar"
        GridViewCheckBoxColumn1.Width = 55
        GridViewTextBoxColumn1.HeaderText = "codigo"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "codigo"
        GridViewTextBoxColumn2.HeaderText = "Nombre"
        GridViewTextBoxColumn2.Name = "nombre"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 150
        Me.grdTipoVehiculo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.grdTipoVehiculo.MasterTemplate.EnableGrouping = False
        Me.grdTipoVehiculo.MasterTemplate.EnableSorting = False
        Me.grdTipoVehiculo.Name = "grdTipoVehiculo"
        Me.grdTipoVehiculo.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTipoVehiculo.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTipoVehiculo.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTipoVehiculo.Size = New System.Drawing.Size(296, 112)
        Me.grdTipoVehiculo.TabIndex = 204
        Me.grdTipoVehiculo.Text = "RadGridView1"
        Me.grdTipoVehiculo.ThemeName = "Office2007Black"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(57, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 25)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "Seleccionar Filtros"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox3.Location = New System.Drawing.Point(20, 58)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 38)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 212
        Me.PictureBox3.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(57, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 25)
        Me.Label5.TabIndex = 216
        Me.Label5.Text = "Informacion"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox5.Location = New System.Drawing.Point(14, 237)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(37, 38)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 218
        Me.PictureBox5.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.rpvInformacion)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(6, 263)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(1041, 248)
        Me.rgbInformacion.TabIndex = 217
        '
        'rpvInformacion
        '
        Me.rpvInformacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpvInformacion.Controls.Add(Me.pgDatos1)
        Me.rpvInformacion.Controls.Add(Me.pgDatos2)
        Me.rpvInformacion.Location = New System.Drawing.Point(13, 18)
        Me.rpvInformacion.Name = "rpvInformacion"
        Me.rpvInformacion.SelectedPage = Me.pgDatos2
        Me.rpvInformacion.Size = New System.Drawing.Size(1015, 217)
        Me.rpvInformacion.TabIndex = 202
        Me.rpvInformacion.Text = "Iformacion"
        CType(Me.rpvInformacion.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'pgDatos1
        '
        Me.pgDatos1.Controls.Add(Me.grdProductos1)
        Me.pgDatos1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pgDatos1.Location = New System.Drawing.Point(10, 37)
        Me.pgDatos1.Name = "pgDatos1"
        Me.pgDatos1.Size = New System.Drawing.Size(994, 169)
        Me.pgDatos1.Text = "Ofertas"
        '
        'grdProductos1
        '
        Me.grdProductos1.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdProductos1.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos1.Location = New System.Drawing.Point(0, 0)
        '
        'grdProductos1
        '
        Me.grdProductos1.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos1.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn2.HeaderText = "column1"
        GridViewCheckBoxColumn2.IsVisible = False
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "chmAgregar"
        Me.grdProductos1.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn2})
        Me.grdProductos1.MasterTemplate.EnableGrouping = False
        Me.grdProductos1.Name = "grdProductos1"
        Me.grdProductos1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos1.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos1.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos1.Size = New System.Drawing.Size(994, 169)
        Me.grdProductos1.TabIndex = 3
        Me.grdProductos1.Text = "RadGridView1"
        Me.grdProductos1.ThemeName = "Office2007Black"
        '
        'pgDatos2
        '
        Me.pgDatos2.Controls.Add(Me.grdProductos2)
        Me.pgDatos2.Location = New System.Drawing.Point(10, 37)
        Me.pgDatos2.Name = "pgDatos2"
        Me.pgDatos2.Size = New System.Drawing.Size(994, 169)
        Me.pgDatos2.Text = "Ofertas  No Comprados"
        '
        'grdProductos2
        '
        Me.grdProductos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdProductos2.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos2.Location = New System.Drawing.Point(0, 0)
        '
        'grdProductos2
        '
        Me.grdProductos2.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos2.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn3.HeaderText = "column1"
        GridViewCheckBoxColumn3.IsVisible = False
        GridViewCheckBoxColumn3.MinWidth = 20
        GridViewCheckBoxColumn3.Name = "chmAgregar"
        Me.grdProductos2.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn3})
        Me.grdProductos2.MasterTemplate.EnableGrouping = False
        Me.grdProductos2.Name = "grdProductos2"
        Me.grdProductos2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos2.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos2.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdProductos2.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos2.Size = New System.Drawing.Size(994, 169)
        Me.grdProductos2.TabIndex = 4
        Me.grdProductos2.Text = "RadGridView1"
        Me.grdProductos2.ThemeName = "Office2007Black"
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.lblUbicacion)
        Me.rgbObservacion.Controls.Add(Me.Label6)
        Me.rgbObservacion.Controls.Add(Me.lblCompatibilidad)
        Me.rgbObservacion.Controls.Add(Me.Label8)
        Me.rgbObservacion.Controls.Add(Me.lblMarca)
        Me.rgbObservacion.Controls.Add(Me.Label7)
        Me.rgbObservacion.Controls.Add(Me.lblObservacion)
        Me.rgbObservacion.Controls.Add(Me.lblEmpaque)
        Me.rgbObservacion.Controls.Add(Me.Label9)
        Me.rgbObservacion.Controls.Add(Me.Label10)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(6, 517)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(917, 84)
        Me.rgbObservacion.TabIndex = 219
        '
        'lblUbicacion
        '
        Me.lblUbicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUbicacion.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicacion.ForeColor = System.Drawing.Color.Black
        Me.lblUbicacion.Location = New System.Drawing.Point(554, 47)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(138, 24)
        Me.lblUbicacion.TabIndex = 177
        Me.lblUbicacion.Text = "Ubicacion"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(488, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 25)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "Ubic :"
        '
        'lblCompatibilidad
        '
        Me.lblCompatibilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompatibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompatibilidad.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompatibilidad.ForeColor = System.Drawing.Color.Black
        Me.lblCompatibilidad.Location = New System.Drawing.Point(167, 47)
        Me.lblCompatibilidad.Name = "lblCompatibilidad"
        Me.lblCompatibilidad.Size = New System.Drawing.Size(282, 24)
        Me.lblCompatibilidad.TabIndex = 175
        Me.lblCompatibilidad.Text = "Compatibilidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(8, 45)
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
        Me.lblMarca.Location = New System.Drawing.Point(798, 6)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(106, 30)
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
        Me.Label7.Location = New System.Drawing.Point(726, 9)
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
        Me.lblObservacion.Location = New System.Drawing.Point(167, 13)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(525, 30)
        Me.lblObservacion.TabIndex = 169
        Me.lblObservacion.Text = "Codigo"
        '
        'lblEmpaque
        '
        Me.lblEmpaque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpaque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpaque.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpaque.ForeColor = System.Drawing.Color.Black
        Me.lblEmpaque.Location = New System.Drawing.Point(798, 40)
        Me.lblEmpaque.Name = "lblEmpaque"
        Me.lblEmpaque.Size = New System.Drawing.Size(106, 32)
        Me.lblEmpaque.TabIndex = 171
        Me.lblEmpaque.Text = "Empaque"
        Me.lblEmpaque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(33, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 25)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Observación :"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(700, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 25)
        Me.Label10.TabIndex = 170
        Me.Label10.Text = "Empaque :"
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
        Me.btnBuscar.Location = New System.Drawing.Point(929, 522)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(94, 70)
        Me.btnBuscar.TabIndex = 220
        Me.btnBuscar.Text = "Agregar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'frmBuscarArticuloOfertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1056, 604)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.rgbObservacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbFiltro)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuscarArticuloOfertas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbFiltro, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.rgbObservacion, 0)
        Me.Controls.SetChildIndex(Me.btnBuscar, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Foto.ResumeLayout(False)
        Me.pnx1Foto.PerformLayout()
        CType(Me.pbx1Foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFiltro.ResumeLayout(False)
        Me.rgbFiltro.PerformLayout()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        CType(Me.rpvInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpvInformacion.ResumeLayout(False)
        Me.pgDatos1.ResumeLayout(False)
        CType(Me.grdProductos1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgDatos2.ResumeLayout(False)
        CType(Me.grdProductos2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Foto As System.Windows.Forms.Panel
    Friend WithEvents pbx1Foto As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Foto As System.Windows.Forms.Label
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbFiltro As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbTiempoNoComprado As System.Windows.Forms.ComboBox
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents lblGrid1 As System.Windows.Forms.Label
    Friend WithEvents chkTodosTipo As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rpvInformacion As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgDatos1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdProductos1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pgDatos2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdProductos2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCompatibilidad As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblEmpaque As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button

End Class
