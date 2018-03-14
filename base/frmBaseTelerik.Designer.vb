

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaseTelerik
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaseTelerik))
        Dim FilterDescriptor1 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.contMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OcultarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarFiltro = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrHora = New System.Windows.Forms.Timer(Me.components)
        Me.RadToolStripItem6 = New Telerik.WinControls.UI.RadToolStripItem()
        Me.Office2010Theme1 = New Telerik.WinControls.Themes.Office2010Theme()
        Me.BreezeExtendedTheme1 = New Telerik.WinControls.Themes.BreezeExtendedTheme()
        Me.rgbDatos = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        Me.RadDesktopAlert1 = New Telerik.WinControls.UI.RadDesktopAlert(Me.components)
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.pnx4Reporte = New System.Windows.Forms.Panel()
        Me.pbx4Reporte = New System.Windows.Forms.PictureBox()
        Me.lbl4Reporte = New System.Windows.Forms.Label()
        Me.pnx2Guardar = New System.Windows.Forms.Panel()
        Me.lbl2Guardar = New System.Windows.Forms.Label()
        Me.pbx2Guardar = New System.Windows.Forms.PictureBox()
        Me.pnx3Eliminar = New System.Windows.Forms.Panel()
        Me.lbl3Eliminar = New System.Windows.Forms.Label()
        Me.pbx3Eliminar = New System.Windows.Forms.PictureBox()
        Me.pnx1Modificar = New System.Windows.Forms.Panel()
        Me.pbx1Modificar = New System.Windows.Forms.PictureBox()
        Me.lbl1Modificar = New System.Windows.Forms.Label()
        Me.pnx0Nuevo = New System.Windows.Forms.Panel()
        Me.pbx0Nuevo = New System.Windows.Forms.PictureBox()
        Me.lbl0Nuevo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtFecha = New System.Windows.Forms.Label()
        Me.lbHora = New System.Windows.Forms.Label()
        Me.pnlNombreFormulario = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lbTituloFrm = New System.Windows.Forms.Label()
        Me.tlpMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.contMenu.SuspendLayout()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbDatos.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMenu.SuspendLayout()
        Me.pnx4Reporte.SuspendLayout()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx2Guardar.SuspendLayout()
        CType(Me.pbx2Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx3Eliminar.SuspendLayout()
        CType(Me.pbx3Eliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Modificar.SuspendLayout()
        CType(Me.pbx1Modificar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Nuevo.SuspendLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNombreFormulario.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMenu.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "calendario.png")
        Me.ImageList1.Images.SetKeyName(1, "eliminar.png")
        Me.ImageList1.Images.SetKeyName(2, "guardar.png")
        Me.ImageList1.Images.SetKeyName(3, "llave.png")
        Me.ImageList1.Images.SetKeyName(4, "modificar1.png")
        Me.ImageList1.Images.SetKeyName(5, "nuevo0.png")
        Me.ImageList1.Images.SetKeyName(6, "ok2.png")
        Me.ImageList1.Images.SetKeyName(7, "procesar.png")
        Me.ImageList1.Images.SetKeyName(8, "reloj.png")
        Me.ImageList1.Images.SetKeyName(9, "reportes.png")
        Me.ImageList1.Images.SetKeyName(10, "salir1.png")
        Me.ImageList1.Images.SetKeyName(11, "usuario.png")
        '
        'contMenu
        '
        Me.contMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OcultarFiltro, Me.MostrarFiltro})
        Me.contMenu.Name = "contMenu"
        Me.contMenu.Size = New System.Drawing.Size(146, 48)
        '
        'OcultarFiltro
        '
        Me.OcultarFiltro.Name = "OcultarFiltro"
        Me.OcultarFiltro.Size = New System.Drawing.Size(145, 22)
        Me.OcultarFiltro.Text = "Ocultar Filtro"
        '
        'MostrarFiltro
        '
        Me.MostrarFiltro.Name = "MostrarFiltro"
        Me.MostrarFiltro.Size = New System.Drawing.Size(145, 22)
        Me.MostrarFiltro.Text = "Mostrar Filtro"
        '
        'tmrHora
        '
        Me.tmrHora.Enabled = True
        '
        'RadToolStripItem6
        '
        Me.RadToolStripItem6.Key = "4"
        Me.RadToolStripItem6.Name = "RadToolStripItem6"
        Me.RadToolStripItem6.Text = "RadToolStripItem6"
        '
        'rgbDatos
        '
        Me.rgbDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbDatos.BackColor = System.Drawing.Color.White
        Me.rgbDatos.Controls.Add(Me.lblRegistros)
        Me.rgbDatos.Controls.Add(Me.grdDatos)
        Me.rgbDatos.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rgbDatos.FooterImageIndex = -1
        Me.rgbDatos.FooterImageKey = ""
        Me.rgbDatos.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.HeaderImage = Global.laFuente.My.Resources.Resources.listaDatos_gris
        Me.rgbDatos.HeaderImageAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.rgbDatos.HeaderImageIndex = -1
        Me.rgbDatos.HeaderImageKey = ""
        Me.rgbDatos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbDatos.HeaderText = ""
        Me.rgbDatos.HeaderTextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.rgbDatos.HeaderTextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rgbDatos.ImageList = Me.ImageList1
        Me.rgbDatos.Location = New System.Drawing.Point(4, 320)
        Me.rgbDatos.Name = "rgbDatos"
        Me.rgbDatos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbDatos.RootElement.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDatos.Size = New System.Drawing.Size(1136, 204)
        Me.rgbDatos.TabIndex = 87
        '
        'lblRegistros
        '
        Me.lblRegistros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRegistros.Location = New System.Drawing.Point(534, 179)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(41, 20)
        Me.lblRegistros.TabIndex = 59
        Me.lblRegistros.Text = "N-M"
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDatos.AutoScroll = True
        Me.grdDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdDatos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDatos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.grdDatos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdDatos.Location = New System.Drawing.Point(9, 20)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        Me.grdDatos.MasterTemplate.AllowDeleteRow = False
        Me.grdDatos.MasterTemplate.AllowEditRow = False
        Me.grdDatos.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdDatos.MasterTemplate.EnableGrouping = False
        FilterDescriptor1.PropertyName = Nothing
        Me.grdDatos.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor1})
        Me.grdDatos.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdDatos.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(1116, 155)
        Me.grdDatos.TabIndex = 58
        Me.grdDatos.Text = "RadGridView1"
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'RadDesktopAlert1
        '
        Me.RadDesktopAlert1.AutoCloseDelay = 2
        Me.RadDesktopAlert1.ContentImage = Global.laFuente.My.Resources.Resources.ayuda2
        Me.RadDesktopAlert1.PlaySound = False
        Me.RadDesktopAlert1.PopupAnimation = True
        Me.RadDesktopAlert1.PopupAnimationDirection = Telerik.WinControls.UI.RadDirection.Left
        Me.RadDesktopAlert1.ScreenPosition = Telerik.WinControls.UI.AlertScreenPosition.TopRight
        Me.RadDesktopAlert1.SoundToPlay = Nothing
        Me.RadDesktopAlert1.ThemeName = Nothing
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlMenu.Controls.Add(Me.pnx4Reporte)
        Me.pnlMenu.Controls.Add(Me.pnx2Guardar)
        Me.pnlMenu.Controls.Add(Me.pnx3Eliminar)
        Me.pnlMenu.Controls.Add(Me.pnx1Modificar)
        Me.pnlMenu.Controls.Add(Me.pnx0Nuevo)
        Me.pnlMenu.Controls.Add(Me.PictureBox1)
        Me.pnlMenu.Controls.Add(Me.PictureBox2)
        Me.pnlMenu.Controls.Add(Me.txtFecha)
        Me.pnlMenu.Controls.Add(Me.lbHora)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenu.Location = New System.Drawing.Point(422, 3)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(718, 44)
        Me.pnlMenu.TabIndex = 2
        '
        'pnx4Reporte
        '
        Me.pnx4Reporte.BackColor = System.Drawing.Color.Navy
        Me.pnx4Reporte.Controls.Add(Me.pbx4Reporte)
        Me.pnx4Reporte.Controls.Add(Me.lbl4Reporte)
        Me.pnx4Reporte.Location = New System.Drawing.Point(425, -1)
        Me.pnx4Reporte.Name = "pnx4Reporte"
        Me.pnx4Reporte.Size = New System.Drawing.Size(122, 45)
        Me.pnx4Reporte.TabIndex = 89
        '
        'pbx4Reporte
        '
        Me.pbx4Reporte.Image = Global.laFuente.My.Resources.Resources.reporte
        Me.pbx4Reporte.Location = New System.Drawing.Point(14, 4)
        Me.pbx4Reporte.Name = "pbx4Reporte"
        Me.pbx4Reporte.Size = New System.Drawing.Size(40, 33)
        Me.pbx4Reporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx4Reporte.TabIndex = 61
        Me.pbx4Reporte.TabStop = False
        '
        'lbl4Reporte
        '
        Me.lbl4Reporte.AutoSize = True
        Me.lbl4Reporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4Reporte.ForeColor = System.Drawing.Color.White
        Me.lbl4Reporte.Location = New System.Drawing.Point(51, 10)
        Me.lbl4Reporte.Name = "lbl4Reporte"
        Me.lbl4Reporte.Size = New System.Drawing.Size(63, 19)
        Me.lbl4Reporte.TabIndex = 62
        Me.lbl4Reporte.Text = "Reporte"
        '
        'pnx2Guardar
        '
        Me.pnx2Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx2Guardar.Controls.Add(Me.lbl2Guardar)
        Me.pnx2Guardar.Controls.Add(Me.pbx2Guardar)
        Me.pnx2Guardar.Location = New System.Drawing.Point(158, -1)
        Me.pnx2Guardar.Name = "pnx2Guardar"
        Me.pnx2Guardar.Size = New System.Drawing.Size(131, 45)
        Me.pnx2Guardar.TabIndex = 88
        '
        'lbl2Guardar
        '
        Me.lbl2Guardar.AutoSize = True
        Me.lbl2Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl2Guardar.Location = New System.Drawing.Point(51, 14)
        Me.lbl2Guardar.Name = "lbl2Guardar"
        Me.lbl2Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl2Guardar.TabIndex = 58
        Me.lbl2Guardar.Text = "Guardar"
        Me.lbl2Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx2Guardar
        '
        Me.pbx2Guardar.Image = Global.laFuente.My.Resources.Resources.guardar
        Me.pbx2Guardar.Location = New System.Drawing.Point(5, 7)
        Me.pbx2Guardar.Name = "pbx2Guardar"
        Me.pbx2Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx2Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Guardar.TabIndex = 57
        Me.pbx2Guardar.TabStop = False
        '
        'pnx3Eliminar
        '
        Me.pnx3Eliminar.BackColor = System.Drawing.Color.Navy
        Me.pnx3Eliminar.Controls.Add(Me.lbl3Eliminar)
        Me.pnx3Eliminar.Controls.Add(Me.pbx3Eliminar)
        Me.pnx3Eliminar.Location = New System.Drawing.Point(295, 0)
        Me.pnx3Eliminar.Name = "pnx3Eliminar"
        Me.pnx3Eliminar.Size = New System.Drawing.Size(122, 45)
        Me.pnx3Eliminar.TabIndex = 88
        '
        'lbl3Eliminar
        '
        Me.lbl3Eliminar.AutoSize = True
        Me.lbl3Eliminar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3Eliminar.ForeColor = System.Drawing.Color.White
        Me.lbl3Eliminar.Location = New System.Drawing.Point(50, 14)
        Me.lbl3Eliminar.Name = "lbl3Eliminar"
        Me.lbl3Eliminar.Size = New System.Drawing.Size(63, 19)
        Me.lbl3Eliminar.TabIndex = 58
        Me.lbl3Eliminar.Text = "Eliminar"
        Me.lbl3Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx3Eliminar
        '
        Me.pbx3Eliminar.Image = Global.laFuente.My.Resources.Resources.delete
        Me.pbx3Eliminar.Location = New System.Drawing.Point(12, 6)
        Me.pbx3Eliminar.Name = "pbx3Eliminar"
        Me.pbx3Eliminar.Size = New System.Drawing.Size(40, 33)
        Me.pbx3Eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx3Eliminar.TabIndex = 57
        Me.pbx3Eliminar.TabStop = False
        '
        'pnx1Modificar
        '
        Me.pnx1Modificar.BackColor = System.Drawing.Color.Navy
        Me.pnx1Modificar.Controls.Add(Me.pbx1Modificar)
        Me.pnx1Modificar.Controls.Add(Me.lbl1Modificar)
        Me.pnx1Modificar.Location = New System.Drawing.Point(158, 0)
        Me.pnx1Modificar.Name = "pnx1Modificar"
        Me.pnx1Modificar.Size = New System.Drawing.Size(131, 45)
        Me.pnx1Modificar.TabIndex = 88
        '
        'pbx1Modificar
        '
        Me.pbx1Modificar.Image = Global.laFuente.My.Resources.Resources.editar
        Me.pbx1Modificar.Location = New System.Drawing.Point(7, 6)
        Me.pbx1Modificar.Name = "pbx1Modificar"
        Me.pbx1Modificar.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Modificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Modificar.TabIndex = 59
        Me.pbx1Modificar.TabStop = False
        '
        'lbl1Modificar
        '
        Me.lbl1Modificar.AutoSize = True
        Me.lbl1Modificar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Modificar.ForeColor = System.Drawing.Color.White
        Me.lbl1Modificar.Location = New System.Drawing.Point(48, 13)
        Me.lbl1Modificar.Name = "lbl1Modificar"
        Me.lbl1Modificar.Size = New System.Drawing.Size(64, 19)
        Me.lbl1Modificar.TabIndex = 60
        Me.lbl1Modificar.Text = "Guardar"
        Me.lbl1Modificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnx0Nuevo
        '
        Me.pnx0Nuevo.BackColor = System.Drawing.Color.Navy
        Me.pnx0Nuevo.Controls.Add(Me.pbx0Nuevo)
        Me.pnx0Nuevo.Controls.Add(Me.lbl0Nuevo)
        Me.pnx0Nuevo.Location = New System.Drawing.Point(30, -1)
        Me.pnx0Nuevo.Name = "pnx0Nuevo"
        Me.pnx0Nuevo.Size = New System.Drawing.Size(122, 45)
        Me.pnx0Nuevo.TabIndex = 63
        '
        'pbx0Nuevo
        '
        Me.pbx0Nuevo.Image = Global.laFuente.My.Resources.Resources.add
        Me.pbx0Nuevo.Location = New System.Drawing.Point(17, 7)
        Me.pbx0Nuevo.Name = "pbx0Nuevo"
        Me.pbx0Nuevo.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Nuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Nuevo.TabIndex = 55
        Me.pbx0Nuevo.TabStop = False
        '
        'lbl0Nuevo
        '
        Me.lbl0Nuevo.AutoSize = True
        Me.lbl0Nuevo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Nuevo.ForeColor = System.Drawing.Color.White
        Me.lbl0Nuevo.Location = New System.Drawing.Point(60, 14)
        Me.lbl0Nuevo.Name = "lbl0Nuevo"
        Me.lbl0Nuevo.Size = New System.Drawing.Size(53, 19)
        Me.lbl0Nuevo.TabIndex = 56
        Me.lbl0Nuevo.Text = "Nuevo"
        Me.lbl0Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.laFuente.My.Resources.Resources.calendar
        Me.PictureBox1.Location = New System.Drawing.Point(610, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 19)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = Global.laFuente.My.Resources.Resources.clock
        Me.PictureBox2.Location = New System.Drawing.Point(614, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 54
        Me.PictureBox2.TabStop = False
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.AutoSize = True
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(644, 4)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(43, 15)
        Me.txtFecha.TabIndex = 51
        Me.txtFecha.Text = "Label3"
        '
        'lbHora
        '
        Me.lbHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbHora.AutoSize = True
        Me.lbHora.BackColor = System.Drawing.Color.Transparent
        Me.lbHora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHora.ForeColor = System.Drawing.Color.White
        Me.lbHora.Location = New System.Drawing.Point(643, 27)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(43, 15)
        Me.lbHora.TabIndex = 53
        Me.lbHora.Text = "Label3"
        '
        'pnlNombreFormulario
        '
        Me.pnlNombreFormulario.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlNombreFormulario.Controls.Add(Me.PictureBox6)
        Me.pnlNombreFormulario.Controls.Add(Me.lbTituloFrm)
        Me.pnlNombreFormulario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNombreFormulario.Location = New System.Drawing.Point(3, 3)
        Me.pnlNombreFormulario.Name = "pnlNombreFormulario"
        Me.pnlNombreFormulario.Size = New System.Drawing.Size(413, 44)
        Me.pnlNombreFormulario.TabIndex = 57
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.laFuente.My.Resources.Resources.play
        Me.PictureBox6.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(56, 36)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 54
        Me.PictureBox6.TabStop = False
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.AutoSize = True
        Me.lbTituloFrm.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloFrm.ForeColor = System.Drawing.Color.White
        Me.lbTituloFrm.Location = New System.Drawing.Point(58, 4)
        Me.lbTituloFrm.Name = "lbTituloFrm"
        Me.lbTituloFrm.Size = New System.Drawing.Size(160, 32)
        Me.lbTituloFrm.TabIndex = 0
        Me.lbTituloFrm.Text = "Nombre Frm"
        '
        'tlpMenu
        '
        Me.tlpMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.tlpMenu.ColumnCount = 2
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.69973!))
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.30027!))
        Me.tlpMenu.Controls.Add(Me.pnlNombreFormulario, 0, 0)
        Me.tlpMenu.Controls.Add(Me.pnlMenu, 1, 0)
        Me.tlpMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlpMenu.Name = "tlpMenu"
        Me.tlpMenu.RowCount = 1
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMenu.Size = New System.Drawing.Size(1143, 50)
        Me.tlpMenu.TabIndex = 55
        '
        'frmBaseTelerik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1143, 529)
        Me.Controls.Add(Me.rgbDatos)
        Me.Controls.Add(Me.tlpMenu)
        Me.ForeColor = System.Drawing.Color.Gray
        Me.Name = "frmBaseTelerik"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.Text = "FrmBaseT"
        Me.contMenu.ResumeLayout(False)
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbDatos.ResumeLayout(False)
        Me.rgbDatos.PerformLayout()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.pnx4Reporte.ResumeLayout(False)
        Me.pnx4Reporte.PerformLayout()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx2Guardar.ResumeLayout(False)
        Me.pnx2Guardar.PerformLayout()
        CType(Me.pbx2Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx3Eliminar.ResumeLayout(False)
        Me.pnx3Eliminar.PerformLayout()
        CType(Me.pbx3Eliminar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Modificar.ResumeLayout(False)
        Me.pnx1Modificar.PerformLayout()
        CType(Me.pbx1Modificar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Nuevo.ResumeLayout(False)
        Me.pnx0Nuevo.PerformLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNombreFormulario.ResumeLayout(False)
        Me.pnlNombreFormulario.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMenu.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents contMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OcultarFiltro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MostrarFiltro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrHora As System.Windows.Forms.Timer
    Friend WithEvents RadToolStripItem6 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents Office2010Theme1 As Telerik.WinControls.Themes.Office2010Theme
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents RadDesktopAlert1 As Telerik.WinControls.UI.RadDesktopAlert
    Friend WithEvents BreezeExtendedTheme1 As Telerik.WinControls.Themes.BreezeExtendedTheme
    Public WithEvents rgbDatos As Telerik.WinControls.UI.RadGroupBox
    Public WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents lbl3Eliminar As System.Windows.Forms.Label
    Friend WithEvents lbl1Modificar As System.Windows.Forms.Label
    Friend WithEvents pbx3Eliminar As System.Windows.Forms.PictureBox
    Friend WithEvents pbx1Modificar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl2Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx2Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Nuevo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFecha As System.Windows.Forms.Label
    Friend WithEvents pbx0Nuevo As System.Windows.Forms.PictureBox
    Friend WithEvents lbHora As System.Windows.Forms.Label
    Friend WithEvents pnlNombreFormulario As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Public WithEvents lbTituloFrm As System.Windows.Forms.Label
    Friend WithEvents tlpMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnx0Nuevo As System.Windows.Forms.Panel
    Friend WithEvents pnx4Reporte As System.Windows.Forms.Panel
    Friend WithEvents pnx3Eliminar As System.Windows.Forms.Panel
    Friend WithEvents pnx1Modificar As System.Windows.Forms.Panel
    Friend WithEvents pnx2Guardar As System.Windows.Forms.Panel
    Public WithEvents lbl4Reporte As System.Windows.Forms.Label
    Public WithEvents pbx4Reporte As System.Windows.Forms.PictureBox
End Class

