<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportar
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim FilterDescriptor1 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportar))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbHojas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rgbArticulos = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnCopiarGrid = New System.Windows.Forms.Button()
        Me.btnPendientesPedir = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.grdProductos = New Telerik.WinControls.UI.RadGridView()
        Me.pnlEntrada = New System.Windows.Forms.Panel()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pnx2Salir = New System.Windows.Forms.Panel()
        Me.pbx2Salir = New System.Windows.Forms.PictureBox()
        Me.lbl2Salir = New System.Windows.Forms.Label()
        Me.pnx1Importar = New System.Windows.Forms.Panel()
        Me.pbx1Importar = New System.Windows.Forms.PictureBox()
        Me.lbl1Importar = New System.Windows.Forms.Label()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblContadoSi = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblContadorNo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbArticulos.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEntrada.SuspendLayout()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx2Salir.SuspendLayout()
        CType(Me.pbx2Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Importar.SuspendLayout()
        CType(Me.pbx1Importar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
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
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(78, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 29)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "Informacion"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox5.Location = New System.Drawing.Point(36, 61)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 85
        Me.PictureBox5.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.BackColor = System.Drawing.Color.Transparent
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.btnAgregar)
        Me.rgbInformacion.Controls.Add(Me.btnImportar)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.txtUrl)
        Me.rgbInformacion.Controls.Add(Me.lblTitulo)
        Me.rgbInformacion.Controls.Add(Me.cmbHojas)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = "dinero.png"
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 77)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(434, 328)
        Me.rgbInformacion.TabIndex = 86
        Me.rgbInformacion.ThemeName = "radGroupBoxAzul"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(59, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(311, 76)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "Agregar Titulo a las Columnas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Compra : Codigo, Cantidad, Costo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Venta : Codigo, " & _
    "Cantidad, Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Movimiento : Codigo, Cantidad, Tipo Movimiento"
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatAppearance.BorderSize = 0
        Me.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnAgregar.Location = New System.Drawing.Point(146, 257)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(142, 55)
        Me.btnAgregar.TabIndex = 176
        Me.btnAgregar.Text = "  Agregar "
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnImportar.FlatAppearance.BorderSize = 0
        Me.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.ForeColor = System.Drawing.Color.Transparent
        Me.btnImportar.Image = Global.laFuente.My.Resources.Resources.import_blanco24
        Me.btnImportar.Location = New System.Drawing.Point(59, 27)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(124, 31)
        Me.btnImportar.TabIndex = 175
        Me.btnImportar.Text = "Abrir Doc."
        Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "URL :"
        '
        'txtUrl
        '
        Me.txtUrl.Enabled = False
        Me.txtUrl.Location = New System.Drawing.Point(59, 154)
        Me.txtUrl.Multiline = True
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(358, 59)
        Me.txtUrl.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTitulo.Location = New System.Drawing.Point(13, 229)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(44, 19)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Hoja :"
        '
        'cmbHojas
        '
        Me.cmbHojas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbHojas.FormattingEnabled = True
        Me.cmbHojas.Location = New System.Drawing.Point(59, 227)
        Me.cmbHojas.Name = "cmbHojas"
        Me.cmbHojas.Size = New System.Drawing.Size(358, 21)
        Me.cmbHojas.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(527, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(290, 29)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Articulo no Encontrados"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.detalles
        Me.PictureBox3.Location = New System.Drawing.Point(485, 61)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 88
        Me.PictureBox3.TabStop = False
        '
        'rgbArticulos
        '
        Me.rgbArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbArticulos.BackColor = System.Drawing.Color.Transparent
        Me.rgbArticulos.Controls.Add(Me.btnCopiarGrid)
        Me.rgbArticulos.Controls.Add(Me.btnPendientesPedir)
        Me.rgbArticulos.Controls.Add(Me.btnActualizar)
        Me.rgbArticulos.Controls.Add(Me.grdProductos)
        Me.rgbArticulos.FooterImageIndex = -1
        Me.rgbArticulos.FooterImageKey = ""
        Me.rgbArticulos.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbArticulos.HeaderImageIndex = -1
        Me.rgbArticulos.HeaderImageKey = "dinero.png"
        Me.rgbArticulos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbArticulos.HeaderText = ""
        Me.rgbArticulos.Location = New System.Drawing.Point(461, 77)
        Me.rgbArticulos.Name = "rgbArticulos"
        Me.rgbArticulos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbArticulos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbArticulos.Size = New System.Drawing.Size(553, 328)
        Me.rgbArticulos.TabIndex = 89
        Me.rgbArticulos.ThemeName = "radGroupBoxAzul"
        '
        'btnCopiarGrid
        '
        Me.btnCopiarGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopiarGrid.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCopiarGrid.FlatAppearance.BorderSize = 0
        Me.btnCopiarGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnCopiarGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnCopiarGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopiarGrid.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiarGrid.ForeColor = System.Drawing.Color.Transparent
        Me.btnCopiarGrid.Location = New System.Drawing.Point(249, 15)
        Me.btnCopiarGrid.Name = "btnCopiarGrid"
        Me.btnCopiarGrid.Size = New System.Drawing.Size(161, 31)
        Me.btnCopiarGrid.TabIndex = 179
        Me.btnCopiarGrid.Text = "Copiar GRID"
        Me.btnCopiarGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCopiarGrid.UseVisualStyleBackColor = False
        '
        'btnPendientesPedir
        '
        Me.btnPendientesPedir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPendientesPedir.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPendientesPedir.FlatAppearance.BorderSize = 0
        Me.btnPendientesPedir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnPendientesPedir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnPendientesPedir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendientesPedir.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendientesPedir.ForeColor = System.Drawing.Color.Transparent
        Me.btnPendientesPedir.Location = New System.Drawing.Point(82, 15)
        Me.btnPendientesPedir.Name = "btnPendientesPedir"
        Me.btnPendientesPedir.Size = New System.Drawing.Size(161, 31)
        Me.btnPendientesPedir.TabIndex = 178
        Me.btnPendientesPedir.Text = "Pendientes por Pedir"
        Me.btnPendientesPedir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPendientesPedir.UseVisualStyleBackColor = False
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnActualizar.FlatAppearance.BorderSize = 0
        Me.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.ForeColor = System.Drawing.Color.Transparent
        Me.btnActualizar.Image = Global.laFuente.My.Resources.Resources.refresh_blanco24
        Me.btnActualizar.Location = New System.Drawing.Point(416, 16)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(124, 31)
        Me.btnActualizar.TabIndex = 177
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'grdProductos
        '
        Me.grdProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProductos.AutoScroll = True
        Me.grdProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdProductos.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditOnEnter
        Me.grdProductos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdProductos.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdProductos.Location = New System.Drawing.Point(13, 53)
        '
        'grdProductos
        '
        Me.grdProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdProductos.MasterTemplate.AutoGenerateColumns = False
        GridViewTextBoxColumn1.HeaderText = "Codigo"
        GridViewTextBoxColumn1.Name = "txmCodigo"
        GridViewTextBoxColumn1.Width = 100
        GridViewTextBoxColumn2.HeaderText = "Cantidad"
        GridViewTextBoxColumn2.Name = "txmCantidad"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 75
        GridViewTextBoxColumn3.HeaderText = "Costo"
        GridViewTextBoxColumn3.Name = "txmCosto"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 111
        Me.grdProductos.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3})
        Me.grdProductos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdProductos.MasterTemplate.EnableGrouping = False
        FilterDescriptor1.PropertyName = Nothing
        Me.grdProductos.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor1})
        Me.grdProductos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdProductos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdProductos.Size = New System.Drawing.Size(527, 247)
        Me.grdProductos.TabIndex = 1
        Me.grdProductos.Text = "RadGridView1"
        Me.grdProductos.ThemeName = "Office2007Black"
        '
        'pnlEntrada
        '
        Me.pnlEntrada.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEntrada.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlEntrada.Controls.Add(Me.pnx0Guardar)
        Me.pnlEntrada.Controls.Add(Me.pnx2Salir)
        Me.pnlEntrada.Controls.Add(Me.pnx1Importar)
        Me.pnlEntrada.Location = New System.Drawing.Point(466, -3)
        Me.pnlEntrada.Name = "pnlEntrada"
        Me.pnlEntrada.Size = New System.Drawing.Size(584, 51)
        Me.pnlEntrada.TabIndex = 90
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(220, 6)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(111, 40)
        Me.pnx0Guardar.TabIndex = 100
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = Global.laFuente.My.Resources.Resources.guardarCirculo_blanco32
        Me.pbx0Guardar.Location = New System.Drawing.Point(3, 4)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 95
        Me.pbx0Guardar.TabStop = False
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(44, 11)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Guardar.TabIndex = 96
        Me.lbl0Guardar.Text = "Guardar"
        '
        'pnx2Salir
        '
        Me.pnx2Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx2Salir.Controls.Add(Me.pbx2Salir)
        Me.pnx2Salir.Controls.Add(Me.lbl2Salir)
        Me.pnx2Salir.Location = New System.Drawing.Point(454, 6)
        Me.pnx2Salir.Name = "pnx2Salir"
        Me.pnx2Salir.Size = New System.Drawing.Size(117, 40)
        Me.pnx2Salir.TabIndex = 100
        '
        'pbx2Salir
        '
        Me.pbx2Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx2Salir.Location = New System.Drawing.Point(8, 3)
        Me.pbx2Salir.Name = "pbx2Salir"
        Me.pbx2Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx2Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Salir.TabIndex = 75
        Me.pbx2Salir.TabStop = False
        '
        'lbl2Salir
        '
        Me.lbl2Salir.AutoSize = True
        Me.lbl2Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Salir.ForeColor = System.Drawing.Color.White
        Me.lbl2Salir.Location = New System.Drawing.Point(48, 10)
        Me.lbl2Salir.Name = "lbl2Salir"
        Me.lbl2Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl2Salir.TabIndex = 76
        Me.lbl2Salir.Text = "Salir"
        '
        'pnx1Importar
        '
        Me.pnx1Importar.BackColor = System.Drawing.Color.Navy
        Me.pnx1Importar.Controls.Add(Me.pbx1Importar)
        Me.pnx1Importar.Controls.Add(Me.lbl1Importar)
        Me.pnx1Importar.Location = New System.Drawing.Point(337, 6)
        Me.pnx1Importar.Name = "pnx1Importar"
        Me.pnx1Importar.Size = New System.Drawing.Size(111, 40)
        Me.pnx1Importar.TabIndex = 99
        '
        'pbx1Importar
        '
        Me.pbx1Importar.Image = Global.laFuente.My.Resources.Resources.entrada_Blanco
        Me.pbx1Importar.Location = New System.Drawing.Point(3, 4)
        Me.pbx1Importar.Name = "pbx1Importar"
        Me.pbx1Importar.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Importar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Importar.TabIndex = 95
        Me.pbx1Importar.TabStop = False
        '
        'lbl1Importar
        '
        Me.lbl1Importar.AutoSize = True
        Me.lbl1Importar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Importar.ForeColor = System.Drawing.Color.White
        Me.lbl1Importar.Location = New System.Drawing.Point(49, 3)
        Me.lbl1Importar.Name = "lbl1Importar"
        Me.lbl1Importar.Size = New System.Drawing.Size(50, 38)
        Me.lbl1Importar.TabIndex = 96
        Me.lbl1Importar.Text = "Docs." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Salida"
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.lblContadoSi)
        Me.rgbObservacion.Controls.Add(Me.Label9)
        Me.rgbObservacion.FooterImageIndex = -1
        Me.rgbObservacion.FooterImageKey = ""
        Me.rgbObservacion.HeaderImageIndex = -1
        Me.rgbObservacion.HeaderImageKey = ""
        Me.rgbObservacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbObservacion.HeaderText = ""
        Me.rgbObservacion.Location = New System.Drawing.Point(12, 426)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(435, 49)
        Me.rgbObservacion.TabIndex = 174
        '
        'lblContadoSi
        '
        Me.lblContadoSi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContadoSi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContadoSi.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContadoSi.ForeColor = System.Drawing.Color.Black
        Me.lblContadoSi.Location = New System.Drawing.Point(265, 8)
        Me.lblContadoSi.Name = "lblContadoSi"
        Me.lblContadoSi.Size = New System.Drawing.Size(106, 33)
        Me.lblContadoSi.TabIndex = 175
        Me.lblContadoSi.Text = "0"
        Me.lblContadoSi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(32, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 25)
        Me.Label9.TabIndex = 174
        Me.Label9.Text = "Articulo Encontrados :"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox2.Controls.Add(Me.lblContadorNo)
        Me.RadGroupBox2.Controls.Add(Me.Label5)
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = ""
        Me.RadGroupBox2.Location = New System.Drawing.Point(461, 426)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox2.Size = New System.Drawing.Size(554, 49)
        Me.RadGroupBox2.TabIndex = 176
        '
        'lblContadorNo
        '
        Me.lblContadorNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContadorNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContadorNo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContadorNo.ForeColor = System.Drawing.Color.Black
        Me.lblContadorNo.Location = New System.Drawing.Point(342, 9)
        Me.lblContadorNo.Name = "lblContadorNo"
        Me.lblContadorNo.Size = New System.Drawing.Size(106, 33)
        Me.lblContadorNo.TabIndex = 175
        Me.lblContadorNo.Text = "0"
        Me.lblContadorNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(97, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 25)
        Me.Label5.TabIndex = 174
        Me.Label5.Text = "Articulo  No Encontrados :"
        '
        'frmImportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1049, 476)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.rgbObservacion)
        Me.Controls.Add(Me.pnlEntrada)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbArticulos)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportar"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.rgbArticulos, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.pnlEntrada, 0)
        Me.Controls.SetChildIndex(Me.rgbObservacion, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox2, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbArticulos.ResumeLayout(False)
        CType(Me.grdProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEntrada.ResumeLayout(False)
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx2Salir.ResumeLayout(False)
        Me.pnx2Salir.PerformLayout()
        CType(Me.pbx2Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Importar.ResumeLayout(False)
        Me.pnx1Importar.PerformLayout()
        CType(Me.pbx1Importar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents cmbHojas As System.Windows.Forms.ComboBox
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents rgbArticulos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Public WithEvents grdProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents pnlEntrada As System.Windows.Forms.Panel
    Friend WithEvents pnx2Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx2Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl2Salir As System.Windows.Forms.Label
    Friend WithEvents pnx1Importar As System.Windows.Forms.Panel
    Friend WithEvents pbx1Importar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Importar As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblContadoSi As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblContadorNo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents btnPendientesPedir As System.Windows.Forms.Button
    Friend WithEvents btnCopiarGrid As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
