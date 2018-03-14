<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloPrecios
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
        Me.components = New System.ComponentModel.Container()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Precio = New System.Windows.Forms.Panel()
        Me.lbl0Precio = New System.Windows.Forms.Label()
        Me.pbx0Precio = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Cerrar = New System.Windows.Forms.PictureBox()
        Me.grdModelos = New Telerik.WinControls.UI.RadGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPrecioNormal = New System.Windows.Forms.Label()
        Me.lblVentaPromedio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.rpvPrecios = New Telerik.WinControls.UI.RadPageView()
        Me.pgPrecios = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPrecioPromedio = New System.Windows.Forms.Label()
        Me.lblCantidadPromedio = New System.Windows.Forms.Label()
        Me.lblCantidadMaxima = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgUltimasVentas = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdUltimasVentas = New Telerik.WinControls.UI.RadGridView()
        Me.Pv2012EntitiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Precio.SuspendLayout()
        CType(Me.pbx0Precio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Cerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rpvPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpvPrecios.SuspendLayout()
        Me.pgPrecios.SuspendLayout()
        Me.pgUltimasVentas.SuspendLayout()
        CType(Me.grdUltimasVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdUltimasVentas.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pv2012EntitiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Precio)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(465, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(304, 51)
        Me.pnlBarra.TabIndex = 122
        '
        'pnx0Precio
        '
        Me.pnx0Precio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Precio.BackColor = System.Drawing.Color.Navy
        Me.pnx0Precio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Precio.Controls.Add(Me.lbl0Precio)
        Me.pnx0Precio.Controls.Add(Me.pbx0Precio)
        Me.pnx0Precio.Location = New System.Drawing.Point(44, 8)
        Me.pnx0Precio.Name = "pnx0Precio"
        Me.pnx0Precio.Size = New System.Drawing.Size(107, 37)
        Me.pnx0Precio.TabIndex = 192
        '
        'lbl0Precio
        '
        Me.lbl0Precio.AutoSize = True
        Me.lbl0Precio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Precio.ForeColor = System.Drawing.Color.White
        Me.lbl0Precio.Location = New System.Drawing.Point(50, 5)
        Me.lbl0Precio.Name = "lbl0Precio"
        Me.lbl0Precio.Size = New System.Drawing.Size(48, 26)
        Me.lbl0Precio.TabIndex = 190
        Me.lbl0Precio.Text = "Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Especial"
        Me.lbl0Precio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx0Precio
        '
        Me.pbx0Precio.Image = Global.laFuente.My.Resources.Resources.precios_Blanco
        Me.pbx0Precio.Location = New System.Drawing.Point(11, 5)
        Me.pbx0Precio.Name = "pbx0Precio"
        Me.pbx0Precio.Size = New System.Drawing.Size(32, 26)
        Me.pbx0Precio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Precio.TabIndex = 188
        Me.pbx0Precio.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Cerrar)
        Me.pnx1Salir.Location = New System.Drawing.Point(158, 8)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 37)
        Me.pnx1Salir.TabIndex = 191
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(50, 11)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(29, 13)
        Me.lbl1Salir.TabIndex = 190
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Cerrar
        '
        Me.pbx1Cerrar.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Cerrar.Location = New System.Drawing.Point(12, 5)
        Me.pbx1Cerrar.Name = "pbx1Cerrar"
        Me.pbx1Cerrar.Size = New System.Drawing.Size(32, 26)
        Me.pbx1Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Cerrar.TabIndex = 188
        Me.pbx1Cerrar.TabStop = False
        '
        'grdModelos
        '
        Me.grdModelos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdModelos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdModelos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdModelos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdModelos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdModelos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdModelos.Location = New System.Drawing.Point(3, 77)
        '
        'grdModelos
        '
        Me.grdModelos.MasterTemplate.AllowAddNewRow = False
        Me.grdModelos.MasterTemplate.EnableGrouping = False
        Me.grdModelos.Name = "grdModelos"
        Me.grdModelos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdModelos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdModelos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdModelos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdModelos.Size = New System.Drawing.Size(693, 161)
        Me.grdModelos.TabIndex = 0
        Me.grdModelos.ThemeName = "Office2007Black"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(69, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 29)
        Me.Label5.TabIndex = 195
        Me.Label5.Text = "Información"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox8.Location = New System.Drawing.Point(29, 54)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(40, 33)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 196
        Me.PictureBox8.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.Label9)
        Me.rgbInformacion.Controls.Add(Me.lblPrecioNormal)
        Me.rgbInformacion.Controls.Add(Me.lblVentaPromedio)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblCodigo)
        Me.rgbInformacion.Controls.Add(Me.lblArticulo)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(9, 71)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(721, 89)
        Me.rgbInformacion.TabIndex = 194
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(312, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 25)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Precio Normal :"
        '
        'lblPrecioNormal
        '
        Me.lblPrecioNormal.AutoSize = True
        Me.lblPrecioNormal.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioNormal.ForeColor = System.Drawing.Color.Black
        Me.lblPrecioNormal.Location = New System.Drawing.Point(473, 15)
        Me.lblPrecioNormal.Name = "lblPrecioNormal"
        Me.lblPrecioNormal.Size = New System.Drawing.Size(72, 30)
        Me.lblPrecioNormal.TabIndex = 169
        Me.lblPrecioNormal.Text = "Precio"
        '
        'lblVentaPromedio
        '
        Me.lblVentaPromedio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVentaPromedio.AutoSize = True
        Me.lblVentaPromedio.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentaPromedio.Location = New System.Drawing.Point(693, 15)
        Me.lblVentaPromedio.Name = "lblVentaPromedio"
        Me.lblVentaPromedio.Size = New System.Drawing.Size(15, 17)
        Me.lblVentaPromedio.TabIndex = 131
        Me.lblVentaPromedio.Text = "0"
        Me.lblVentaPromedio.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(29, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 25)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Código :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(22, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 25)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Artículo :"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(111, 15)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(83, 30)
        Me.lblCodigo.TabIndex = 167
        Me.lblCodigo.Text = "Codigo"
        '
        'lblArticulo
        '
        Me.lblArticulo.AutoSize = True
        Me.lblArticulo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo.ForeColor = System.Drawing.Color.Black
        Me.lblArticulo.Location = New System.Drawing.Point(111, 44)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(80, 25)
        Me.lblArticulo.TabIndex = 165
        Me.lblArticulo.Text = "Articulo"
        '
        'rpvPrecios
        '
        Me.rpvPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpvPrecios.Controls.Add(Me.pgPrecios)
        Me.rpvPrecios.Controls.Add(Me.pgUltimasVentas)
        Me.rpvPrecios.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpvPrecios.Location = New System.Drawing.Point(9, 172)
        Me.rpvPrecios.Name = "rpvPrecios"
        Me.rpvPrecios.SelectedPage = Me.pgPrecios
        Me.rpvPrecios.Size = New System.Drawing.Size(725, 360)
        Me.rpvPrecios.TabIndex = 197
        Me.rpvPrecios.Text = "RadPageView1"
        CType(Me.rpvPrecios.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pgPrecios
        '
        Me.pgPrecios.Controls.Add(Me.btnAgregar)
        Me.pgPrecios.Controls.Add(Me.lblSaldo)
        Me.pgPrecios.Controls.Add(Me.lblObservacion)
        Me.pgPrecios.Controls.Add(Me.Label10)
        Me.pgPrecios.Controls.Add(Me.lblPrecioPromedio)
        Me.pgPrecios.Controls.Add(Me.lblCantidadPromedio)
        Me.pgPrecios.Controls.Add(Me.lblCantidadMaxima)
        Me.pgPrecios.Controls.Add(Me.Label4)
        Me.pgPrecios.Controls.Add(Me.Label6)
        Me.pgPrecios.Controls.Add(Me.Label3)
        Me.pgPrecios.Controls.Add(Me.Label2)
        Me.pgPrecios.Controls.Add(Me.grdModelos)
        Me.pgPrecios.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pgPrecios.Location = New System.Drawing.Point(10, 40)
        Me.pgPrecios.Name = "pgPrecios"
        Me.pgPrecios.Size = New System.Drawing.Size(704, 309)
        Me.pgPrecios.Text = "Precios"
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
        Me.btnAgregar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.Location = New System.Drawing.Point(582, 250)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(114, 55)
        Me.btnAgregar.TabIndex = 172
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'lblSaldo
        '
        Me.lblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(603, 44)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(15, 17)
        Me.lblSaldo.TabIndex = 171
        Me.lblSaldo.Text = "0"
        '
        'lblObservacion
        '
        Me.lblObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.ForeColor = System.Drawing.Color.Black
        Me.lblObservacion.Location = New System.Drawing.Point(106, 250)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(429, 54)
        Me.lblObservacion.TabIndex = 170
        Me.lblObservacion.Text = "Observación"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 17)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "Observación :"
        '
        'lblPrecioPromedio
        '
        Me.lblPrecioPromedio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrecioPromedio.AutoSize = True
        Me.lblPrecioPromedio.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioPromedio.Location = New System.Drawing.Point(603, 11)
        Me.lblPrecioPromedio.Name = "lblPrecioPromedio"
        Me.lblPrecioPromedio.Size = New System.Drawing.Size(15, 17)
        Me.lblPrecioPromedio.TabIndex = 130
        Me.lblPrecioPromedio.Text = "0"
        '
        'lblCantidadPromedio
        '
        Me.lblCantidadPromedio.AutoSize = True
        Me.lblCantidadPromedio.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPromedio.Location = New System.Drawing.Point(163, 45)
        Me.lblCantidadPromedio.Name = "lblCantidadPromedio"
        Me.lblCantidadPromedio.Size = New System.Drawing.Size(15, 17)
        Me.lblCantidadPromedio.TabIndex = 129
        Me.lblCantidadPromedio.Text = "0"
        '
        'lblCantidadMaxima
        '
        Me.lblCantidadMaxima.AutoSize = True
        Me.lblCantidadMaxima.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadMaxima.Location = New System.Drawing.Point(163, 11)
        Me.lblCantidadMaxima.Name = "lblCantidadMaxima"
        Me.lblCantidadMaxima.Size = New System.Drawing.Size(15, 17)
        Me.lblCantidadMaxima.TabIndex = 128
        Me.lblCantidadMaxima.Text = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(511, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 20)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Existencia :"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(462, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "Precio Promedio :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(11, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 20)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Cantidad Promedio :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(23, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 20)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Cantidad Máxima :"
        '
        'pgUltimasVentas
        '
        Me.pgUltimasVentas.Controls.Add(Me.grdUltimasVentas)
        Me.pgUltimasVentas.Location = New System.Drawing.Point(10, 40)
        Me.pgUltimasVentas.Name = "pgUltimasVentas"
        Me.pgUltimasVentas.Size = New System.Drawing.Size(704, 309)
        Me.pgUltimasVentas.Text = "Ultimas Ventas"
        '
        'grdUltimasVentas
        '
        Me.grdUltimasVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdUltimasVentas.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdUltimasVentas.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdUltimasVentas.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdUltimasVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdUltimasVentas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdUltimasVentas.Location = New System.Drawing.Point(3, 12)
        '
        '
        '
        Me.grdUltimasVentas.MasterTemplate.AllowAddNewRow = False
        Me.grdUltimasVentas.MasterTemplate.EnableGrouping = False
        Me.grdUltimasVentas.Name = "grdUltimasVentas"
        Me.grdUltimasVentas.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdUltimasVentas.ReadOnly = True
        Me.grdUltimasVentas.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdUltimasVentas.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdUltimasVentas.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdUltimasVentas.Size = New System.Drawing.Size(698, 294)
        Me.grdUltimasVentas.TabIndex = 1
        Me.grdUltimasVentas.ThemeName = "Office2007Black"
        '
        'Pv2012EntitiesBindingSource
        '
        Me.Pv2012EntitiesBindingSource.DataSource = GetType(laFuente.pv2013Entities)
        '
        'frmBuscarArticuloPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(738, 533)
        Me.Controls.Add(Me.rpvPrecios)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Name = "frmBuscarArticuloPrecios"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox8, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.rpvPrecios, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Precio.ResumeLayout(False)
        Me.pnx0Precio.PerformLayout()
        CType(Me.pbx0Precio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Cerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rpvPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpvPrecios.ResumeLayout(False)
        Me.pgPrecios.ResumeLayout(False)
        Me.pgPrecios.PerformLayout()
        Me.pgUltimasVentas.ResumeLayout(False)
        CType(Me.grdUltimasVentas.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdUltimasVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pv2012EntitiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents grdModelos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Cerrar As System.Windows.Forms.PictureBox
    Friend WithEvents rpvPrecios As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgPrecios As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pgUltimasVentas As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdUltimasVentas As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblVentaPromedio As System.Windows.Forms.Label
    Friend WithEvents lblPrecioPromedio As System.Windows.Forms.Label
    Friend WithEvents lblCantidadPromedio As System.Windows.Forms.Label
    Friend WithEvents lblCantidadMaxima As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPrecioNormal As System.Windows.Forms.Label
    Friend WithEvents Pv2012EntitiesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents pnx0Precio As System.Windows.Forms.Panel
    Friend WithEvents lbl0Precio As System.Windows.Forms.Label
    Friend WithEvents pbx0Precio As System.Windows.Forms.PictureBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button

End Class
