﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetallePendienteNuevo
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
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewCheckBoxColumn3 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetallePendienteNuevo))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Foto = New System.Windows.Forms.Panel()
        Me.pbx1Foto = New System.Windows.Forms.PictureBox()
        Me.lbl1Foto = New System.Windows.Forms.Label()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rpvInformacion = New Telerik.WinControls.UI.RadPageView()
        Me.pgDatos1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        Me.pgDatos2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdDatos2 = New Telerik.WinControls.UI.RadGridView()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.chkTodosTipo = New System.Windows.Forms.CheckBox()
        Me.grdTipoVehiculo = New Telerik.WinControls.UI.RadGridView()
        Me.lblGrid1 = New System.Windows.Forms.Label()
        Me.btnBusqueda = New System.Windows.Forms.Button()
        Me.cmbTiempoNoComprado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbFiltro = New Telerik.WinControls.UI.RadGroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblPrecioPublico = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCompatibilidad = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblEmpaque = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Foto.SuspendLayout()
        CType(Me.pbx1Foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpvInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpvInformacion.SuspendLayout()
        Me.pgDatos1.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgDatos2.SuspendLayout()
        CType(Me.grdDatos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFiltro.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(574, 48)
        Me.pnlBarra.TabIndex = 199
        '
        'pnx1Foto
        '
        Me.pnx1Foto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Foto.BackColor = System.Drawing.Color.Navy
        Me.pnx1Foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Foto.Controls.Add(Me.pbx1Foto)
        Me.pnx1Foto.Controls.Add(Me.lbl1Foto)
        Me.pnx1Foto.Location = New System.Drawing.Point(346, 4)
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
        Me.lbl1Foto.Location = New System.Drawing.Point(36, 9)
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
        Me.pnx0Salir.Location = New System.Drawing.Point(458, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 195
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(45, 9)
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
        'rpvInformacion
        '
        Me.rpvInformacion.Controls.Add(Me.pgDatos1)
        Me.rpvInformacion.Controls.Add(Me.pgDatos2)
        Me.rpvInformacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpvInformacion.Location = New System.Drawing.Point(10, 20)
        Me.rpvInformacion.Name = "rpvInformacion"
        Me.rpvInformacion.SelectedPage = Me.pgDatos1
        Me.rpvInformacion.Size = New System.Drawing.Size(995, 293)
        Me.rpvInformacion.TabIndex = 202
        Me.rpvInformacion.Text = "Iformacion"
        CType(Me.rpvInformacion.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        '
        'pgDatos1
        '
        Me.pgDatos1.Controls.Add(Me.grdDatos)
        Me.pgDatos1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pgDatos1.Location = New System.Drawing.Point(10, 37)
        Me.pgDatos1.Name = "pgDatos1"
        Me.pgDatos1.Size = New System.Drawing.Size(974, 245)
        Me.pgDatos1.Text = "Articulos General"
        '
        'grdDatos
        '
        Me.grdDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdDatos.Location = New System.Drawing.Point(0, 0)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        Me.grdDatos.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn1.HeaderText = "Agregar"
        GridViewCheckBoxColumn1.IsVisible = False
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmAgregar"
        Me.grdDatos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1})
        Me.grdDatos.MasterTemplate.EnableGrouping = False
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdDatos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(974, 245)
        Me.grdDatos.TabIndex = 3
        Me.grdDatos.Text = "RadGridView1"
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'pgDatos2
        '
        Me.pgDatos2.Controls.Add(Me.grdDatos2)
        Me.pgDatos2.Location = New System.Drawing.Point(10, 37)
        Me.pgDatos2.Name = "pgDatos2"
        Me.pgDatos2.Size = New System.Drawing.Size(974, 245)
        Me.pgDatos2.Text = "Articulos No Comprados"
        '
        'grdDatos2
        '
        Me.grdDatos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdDatos2.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDatos2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdDatos2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdDatos2.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.grdDatos2.MasterTemplate.AllowAddNewRow = False
        Me.grdDatos2.MasterTemplate.AllowDeleteRow = False
        GridViewCheckBoxColumn2.HeaderText = "column1"
        GridViewCheckBoxColumn2.IsVisible = False
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "chmAgregar"
        Me.grdDatos2.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn2})
        Me.grdDatos2.MasterTemplate.EnableGrouping = False
        Me.grdDatos2.Name = "grdDatos2"
        Me.grdDatos2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos2.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdDatos2.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos2.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos2.Size = New System.Drawing.Size(974, 245)
        Me.grdDatos2.TabIndex = 4
        Me.grdDatos2.Text = "RadGridView1"
        Me.grdDatos2.ThemeName = "Office2007Black"
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
        Me.grdTipoVehiculo.Location = New System.Drawing.Point(116, 38)
        '
        'grdTipoVehiculo
        '
        Me.grdTipoVehiculo.MasterTemplate.AllowAddNewRow = False
        Me.grdTipoVehiculo.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn3.HeaderText = "Agregar"
        GridViewCheckBoxColumn3.MinWidth = 20
        GridViewCheckBoxColumn3.Name = "chmAgregar"
        GridViewCheckBoxColumn3.Width = 55
        GridViewTextBoxColumn1.HeaderText = "codigo"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "codigo"
        GridViewTextBoxColumn2.HeaderText = "Nombre"
        GridViewTextBoxColumn2.Name = "nombre"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 150
        Me.grdTipoVehiculo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn3, GridViewTextBoxColumn1, GridViewTextBoxColumn2})
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
        'lblGrid1
        '
        Me.lblGrid1.AutoSize = True
        Me.lblGrid1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrid1.ForeColor = System.Drawing.Color.DimGray
        Me.lblGrid1.Location = New System.Drawing.Point(119, 15)
        Me.lblGrid1.Name = "lblGrid1"
        Me.lblGrid1.Size = New System.Drawing.Size(121, 19)
        Me.lblGrid1.TabIndex = 203
        Me.lblGrid1.Text = "Tipo de Vehículo"
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
        Me.btnBusqueda.Location = New System.Drawing.Point(710, 52)
        Me.btnBusqueda.Name = "btnBusqueda"
        Me.btnBusqueda.Size = New System.Drawing.Size(131, 59)
        Me.btnBusqueda.TabIndex = 207
        Me.btnBusqueda.Text = "Buscar"
        Me.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBusqueda.UseVisualStyleBackColor = False
        '
        'cmbTiempoNoComprado
        '
        Me.cmbTiempoNoComprado.FormattingEnabled = True
        Me.cmbTiempoNoComprado.Location = New System.Drawing.Point(529, 73)
        Me.cmbTiempoNoComprado.Name = "cmbTiempoNoComprado"
        Me.cmbTiempoNoComprado.Size = New System.Drawing.Size(175, 21)
        Me.cmbTiempoNoComprado.TabIndex = 208
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
        Me.rgbFiltro.Location = New System.Drawing.Point(12, 74)
        Me.rgbFiltro.Name = "rgbFiltro"
        Me.rgbFiltro.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFiltro.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFiltro.Size = New System.Drawing.Size(1015, 156)
        Me.rgbFiltro.TabIndex = 210
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox3.Location = New System.Drawing.Point(30, 55)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 38)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 210
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(67, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 25)
        Me.Label3.TabIndex = 211
        Me.Label3.Text = "Seleccionar Filtros"
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
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 256)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(1015, 323)
        Me.rgbInformacion.TabIndex = 212
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox5.Location = New System.Drawing.Point(30, 236)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(37, 38)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 215
        Me.PictureBox5.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(68, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 25)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "Informacion"
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.lblPrecioPublico)
        Me.rgbObservacion.Controls.Add(Me.Label12)
        Me.rgbObservacion.Controls.Add(Me.lblUbicacion)
        Me.rgbObservacion.Controls.Add(Me.Label10)
        Me.rgbObservacion.Controls.Add(Me.lblCompatibilidad)
        Me.rgbObservacion.Controls.Add(Me.Label8)
        Me.rgbObservacion.Controls.Add(Me.lblMarca)
        Me.rgbObservacion.Controls.Add(Me.Label7)
        Me.rgbObservacion.Controls.Add(Me.lblObservacion)
        Me.rgbObservacion.Controls.Add(Me.lblEmpaque)
        Me.rgbObservacion.Controls.Add(Me.Label6)
        Me.rgbObservacion.Controls.Add(Me.Label9)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(12, 593)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(1015, 85)
        Me.rgbObservacion.TabIndex = 216
        '
        'lblPrecioPublico
        '
        Me.lblPrecioPublico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecioPublico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecioPublico.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioPublico.ForeColor = System.Drawing.Color.Black
        Me.lblPrecioPublico.Location = New System.Drawing.Point(684, 9)
        Me.lblPrecioPublico.Name = "lblPrecioPublico"
        Me.lblPrecioPublico.Size = New System.Drawing.Size(106, 33)
        Me.lblPrecioPublico.TabIndex = 179
        Me.lblPrecioPublico.Text = "Precio P"
        Me.lblPrecioPublico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(532, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(143, 25)
        Me.Label12.TabIndex = 178
        Me.Label12.Text = "Precio Publico :"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUbicacion.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicacion.ForeColor = System.Drawing.Color.Black
        Me.lblUbicacion.Location = New System.Drawing.Point(395, 53)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(395, 24)
        Me.lblUbicacion.TabIndex = 177
        Me.lblUbicacion.Text = "Ubic"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(334, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 25)
        Me.Label10.TabIndex = 176
        Me.Label10.Text = "Ubic :"
        '
        'lblCompatibilidad
        '
        Me.lblCompatibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompatibilidad.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompatibilidad.ForeColor = System.Drawing.Color.Black
        Me.lblCompatibilidad.Location = New System.Drawing.Point(167, 54)
        Me.lblCompatibilidad.Name = "lblCompatibilidad"
        Me.lblCompatibilidad.Size = New System.Drawing.Size(161, 24)
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
        Me.lblMarca.Location = New System.Drawing.Point(896, 8)
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
        Me.Label7.Location = New System.Drawing.Point(824, 10)
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
        Me.lblObservacion.Size = New System.Drawing.Size(359, 40)
        Me.lblObservacion.TabIndex = 169
        Me.lblObservacion.Text = "Codigo"
        '
        'lblEmpaque
        '
        Me.lblEmpaque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpaque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpaque.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpaque.ForeColor = System.Drawing.Color.Black
        Me.lblEmpaque.Location = New System.Drawing.Point(896, 45)
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
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(798, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 25)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = "Empaque :"
        '
        'frmDetallePendienteNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1039, 692)
        Me.Controls.Add(Me.rgbObservacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbFiltro)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDetallePendienteNuevo"
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
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Foto.ResumeLayout(False)
        Me.pnx1Foto.PerformLayout()
        CType(Me.pbx1Foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpvInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpvInformacion.ResumeLayout(False)
        Me.pgDatos1.ResumeLayout(False)
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgDatos2.ResumeLayout(False)
        CType(Me.grdDatos2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFiltro.ResumeLayout(False)
        Me.rgbFiltro.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rpvInformacion As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgDatos1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pgDatos2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents lblContador As System.Windows.Forms.Label
    Friend WithEvents chkTodosTipo As System.Windows.Forms.CheckBox
    Friend WithEvents grdTipoVehiculo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblGrid1 As System.Windows.Forms.Label
    Friend WithEvents btnBusqueda As System.Windows.Forms.Button
    Friend WithEvents cmbTiempoNoComprado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdDatos2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbFiltro As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnx1Foto As System.Windows.Forms.Panel
    Friend WithEvents pbx1Foto As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Foto As System.Windows.Forms.Label
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCompatibilidad As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblEmpaque As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPrecioPublico As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
