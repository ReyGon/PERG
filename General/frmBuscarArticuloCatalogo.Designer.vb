<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloCatalogo
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
        Dim Label2 As System.Windows.Forms.Label
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0DocSalida = New System.Windows.Forms.Panel()
        Me.pbx0DocSalida = New System.Windows.Forms.PictureBox()
        Me.lbl0DocSalida = New System.Windows.Forms.Label()
        Me.pnx1Imprimir = New System.Windows.Forms.Panel()
        Me.lbl1Imprimir = New System.Windows.Forms.Label()
        Me.pbx1Imprimir = New System.Windows.Forms.PictureBox()
        Me.pnx2Salir = New System.Windows.Forms.Panel()
        Me.lbl2Salir = New System.Windows.Forms.Label()
        Me.pbx2Cerrar = New System.Windows.Forms.PictureBox()
        Me.CachedrptComprasResumen1 = New laFuente.CachedrptComprasResumen()
        Me.rpv0Catalogo = New Telerik.WinControls.UI.RadPageView()
        Me.pgCatalogo1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.rgbObservacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblCompatibilidad = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblEmpaque = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdInformacion = New Telerik.WinControls.UI.RadGridView()
        Me.rgbFoto = New Telerik.WinControls.UI.RadGroupBox()
        Me.pbxFoto = New System.Windows.Forms.PictureBox()
        Me.cmbCatalogo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0DocSalida.SuspendLayout()
        CType(Me.pbx0DocSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Imprimir.SuspendLayout()
        CType(Me.pbx1Imprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx2Salir.SuspendLayout()
        CType(Me.pbx2Cerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv0Catalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv0Catalogo.SuspendLayout()
        Me.pgCatalogo1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbObservacion.SuspendLayout()
        CType(Me.grdInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInformacion.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFoto.SuspendLayout()
        CType(Me.pbxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.ForeColor = System.Drawing.Color.DimGray
        Label2.Location = New System.Drawing.Point(49, 7)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(66, 29)
        Label2.TabIndex = 194
        Label2.Text = "Foto"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0DocSalida)
        Me.pnlBarra.Controls.Add(Me.pnx1Imprimir)
        Me.pnlBarra.Controls.Add(Me.pnx2Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(463, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(797, 51)
        Me.pnlBarra.TabIndex = 121
        '
        'pnx0DocSalida
        '
        Me.pnx0DocSalida.BackColor = System.Drawing.Color.Navy
        Me.pnx0DocSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0DocSalida.Controls.Add(Me.pbx0DocSalida)
        Me.pnx0DocSalida.Controls.Add(Me.lbl0DocSalida)
        Me.pnx0DocSalida.Location = New System.Drawing.Point(452, 6)
        Me.pnx0DocSalida.Name = "pnx0DocSalida"
        Me.pnx0DocSalida.Size = New System.Drawing.Size(107, 40)
        Me.pnx0DocSalida.TabIndex = 199
        '
        'pbx0DocSalida
        '
        Me.pbx0DocSalida.Image = Global.laFuente.My.Resources.Resources.upload
        Me.pbx0DocSalida.Location = New System.Drawing.Point(2, 4)
        Me.pbx0DocSalida.Name = "pbx0DocSalida"
        Me.pbx0DocSalida.Size = New System.Drawing.Size(32, 29)
        Me.pbx0DocSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0DocSalida.TabIndex = 93
        Me.pbx0DocSalida.TabStop = False
        '
        'lbl0DocSalida
        '
        Me.lbl0DocSalida.AutoSize = True
        Me.lbl0DocSalida.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0DocSalida.ForeColor = System.Drawing.Color.White
        Me.lbl0DocSalida.Location = New System.Drawing.Point(32, 9)
        Me.lbl0DocSalida.Name = "lbl0DocSalida"
        Me.lbl0DocSalida.Size = New System.Drawing.Size(76, 19)
        Me.lbl0DocSalida.TabIndex = 94
        Me.lbl0DocSalida.Text = "DocSalida"
        '
        'pnx1Imprimir
        '
        Me.pnx1Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Imprimir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Imprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Imprimir.Controls.Add(Me.lbl1Imprimir)
        Me.pnx1Imprimir.Controls.Add(Me.pbx1Imprimir)
        Me.pnx1Imprimir.Location = New System.Drawing.Point(565, 6)
        Me.pnx1Imprimir.Name = "pnx1Imprimir"
        Me.pnx1Imprimir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Imprimir.TabIndex = 192
        '
        'lbl1Imprimir
        '
        Me.lbl1Imprimir.AutoSize = True
        Me.lbl1Imprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl1Imprimir.ForeColor = System.Drawing.Color.White
        Me.lbl1Imprimir.Location = New System.Drawing.Point(42, 4)
        Me.lbl1Imprimir.Name = "lbl1Imprimir"
        Me.lbl1Imprimir.Size = New System.Drawing.Size(63, 30)
        Me.lbl1Imprimir.TabIndex = 72
        Me.lbl1Imprimir.Text = "Agregar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Impresión" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pbx1Imprimir
        '
        Me.pbx1Imprimir.Image = Global.laFuente.My.Resources.Resources.imprimirBlanco
        Me.pbx1Imprimir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Imprimir.Name = "pbx1Imprimir"
        Me.pbx1Imprimir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Imprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Imprimir.TabIndex = 71
        Me.pbx1Imprimir.TabStop = False
        '
        'pnx2Salir
        '
        Me.pnx2Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx2Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx2Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx2Salir.Controls.Add(Me.lbl2Salir)
        Me.pnx2Salir.Controls.Add(Me.pbx2Cerrar)
        Me.pnx2Salir.Location = New System.Drawing.Point(678, 6)
        Me.pnx2Salir.Name = "pnx2Salir"
        Me.pnx2Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx2Salir.TabIndex = 193
        '
        'lbl2Salir
        '
        Me.lbl2Salir.AutoSize = True
        Me.lbl2Salir.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl2Salir.ForeColor = System.Drawing.Color.White
        Me.lbl2Salir.Location = New System.Drawing.Point(48, 7)
        Me.lbl2Salir.Name = "lbl2Salir"
        Me.lbl2Salir.Size = New System.Drawing.Size(44, 21)
        Me.lbl2Salir.TabIndex = 190
        Me.lbl2Salir.Text = "Salir"
        '
        'pbx2Cerrar
        '
        Me.pbx2Cerrar.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx2Cerrar.Location = New System.Drawing.Point(3, 3)
        Me.pbx2Cerrar.Name = "pbx2Cerrar"
        Me.pbx2Cerrar.Size = New System.Drawing.Size(40, 33)
        Me.pbx2Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Cerrar.TabIndex = 188
        Me.pbx2Cerrar.TabStop = False
        '
        'rpv0Catalogo
        '
        Me.rpv0Catalogo.Controls.Add(Me.pgCatalogo1)
        Me.rpv0Catalogo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpv0Catalogo.Location = New System.Drawing.Point(2, 130)
        Me.rpv0Catalogo.Name = "rpv0Catalogo"
        Me.rpv0Catalogo.SelectedPage = Me.pgCatalogo1
        Me.rpv0Catalogo.Size = New System.Drawing.Size(1247, 579)
        Me.rpv0Catalogo.TabIndex = 122
        Me.rpv0Catalogo.Text = "Catalogo"
        CType(Me.rpv0Catalogo.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.RightScroll
        '
        'pgCatalogo1
        '
        Me.pgCatalogo1.Controls.Add(Me.PictureBox3)
        Me.pgCatalogo1.Controls.Add(Me.Label3)
        Me.pgCatalogo1.Controls.Add(Me.PictureBox5)
        Me.pgCatalogo1.Controls.Add(Me.rgbInformacion)
        Me.pgCatalogo1.Controls.Add(Label2)
        Me.pgCatalogo1.Controls.Add(Me.rgbFoto)
        Me.pgCatalogo1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pgCatalogo1.Location = New System.Drawing.Point(10, 44)
        Me.pgCatalogo1.Name = "pgCatalogo1"
        Me.pgCatalogo1.Size = New System.Drawing.Size(1226, 524)
        Me.pgCatalogo1.Text = "Catálogo"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.fotoNegro
        Me.PictureBox3.Location = New System.Drawing.Point(6, 1)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(47, 37)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 198
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(588, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 29)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Información"
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox5.Location = New System.Drawing.Point(541, 1)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(47, 37)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 196
        Me.PictureBox5.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.rgbObservacion)
        Me.rgbInformacion.Controls.Add(Me.btnBuscar)
        Me.rgbInformacion.Controls.Add(Me.grdInformacion)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(518, 21)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(715, 503)
        Me.rgbInformacion.TabIndex = 195
        '
        'rgbObservacion
        '
        Me.rgbObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbObservacion.Controls.Add(Me.lblCompatibilidad)
        Me.rgbObservacion.Controls.Add(Me.Label4)
        Me.rgbObservacion.Controls.Add(Me.lblMarca)
        Me.rgbObservacion.Controls.Add(Me.Label6)
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
        Me.rgbObservacion.Location = New System.Drawing.Point(15, 408)
        Me.rgbObservacion.Name = "rgbObservacion"
        Me.rgbObservacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbObservacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbObservacion.Size = New System.Drawing.Size(539, 85)
        Me.rgbObservacion.TabIndex = 183
        '
        'lblCompatibilidad
        '
        Me.lblCompatibilidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompatibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompatibilidad.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompatibilidad.ForeColor = System.Drawing.Color.Black
        Me.lblCompatibilidad.Location = New System.Drawing.Point(167, 54)
        Me.lblCompatibilidad.Name = "lblCompatibilidad"
        Me.lblCompatibilidad.Size = New System.Drawing.Size(157, 24)
        Me.lblCompatibilidad.TabIndex = 175
        Me.lblCompatibilidad.Text = "Compatibilidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(8, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 25)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Compatibilidad :"
        '
        'lblMarca
        '
        Me.lblMarca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMarca.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(420, 8)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(106, 33)
        Me.lblMarca.TabIndex = 173
        Me.lblMarca.Text = "Marca"
        Me.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(348, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 25)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "Marca :"
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
        Me.lblObservacion.Size = New System.Drawing.Size(157, 40)
        Me.lblObservacion.TabIndex = 169
        Me.lblObservacion.Text = "Codigo"
        '
        'lblEmpaque
        '
        Me.lblEmpaque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpaque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpaque.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpaque.ForeColor = System.Drawing.Color.Black
        Me.lblEmpaque.Location = New System.Drawing.Point(420, 45)
        Me.lblEmpaque.Name = "lblEmpaque"
        Me.lblEmpaque.Size = New System.Drawing.Size(106, 33)
        Me.lblEmpaque.TabIndex = 171
        Me.lblEmpaque.Text = "Empaque"
        Me.lblEmpaque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(33, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 25)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Observación :"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(322, 46)
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
        Me.btnBuscar.Location = New System.Drawing.Point(576, 423)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(126, 70)
        Me.btnBuscar.TabIndex = 182
        Me.btnBuscar.Text = "Agregar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'grdInformacion
        '
        Me.grdInformacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdInformacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdInformacion.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdInformacion.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdInformacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdInformacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdInformacion.Location = New System.Drawing.Point(15, 23)
        '
        'grdInformacion
        '
        Me.grdInformacion.MasterTemplate.AllowAddNewRow = False
        Me.grdInformacion.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn1.HeaderText = "Agregar"
        GridViewCheckBoxColumn1.IsVisible = False
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chmAgregar"
        Me.grdInformacion.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1})
        Me.grdInformacion.MasterTemplate.EnableGrouping = False
        Me.grdInformacion.Name = "grdInformacion"
        Me.grdInformacion.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdInformacion.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdInformacion.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdInformacion.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdInformacion.Size = New System.Drawing.Size(679, 374)
        Me.grdInformacion.TabIndex = 0
        Me.grdInformacion.ThemeName = "Office2007Black"
        '
        'rgbFoto
        '
        Me.rgbFoto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbFoto.Controls.Add(Me.pbxFoto)
        Me.rgbFoto.Controls.Add(Me.cmbCatalogo)
        Me.rgbFoto.FooterImageIndex = -1
        Me.rgbFoto.FooterImageKey = ""
        Me.rgbFoto.HeaderImageIndex = -1
        Me.rgbFoto.HeaderImageKey = ""
        Me.rgbFoto.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbFoto.HeaderText = ""
        Me.rgbFoto.Location = New System.Drawing.Point(-7, 21)
        Me.rgbFoto.Name = "rgbFoto"
        Me.rgbFoto.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFoto.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFoto.Size = New System.Drawing.Size(519, 503)
        Me.rgbFoto.TabIndex = 193
        '
        'pbxFoto
        '
        Me.pbxFoto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxFoto.Location = New System.Drawing.Point(13, 34)
        Me.pbxFoto.Name = "pbxFoto"
        Me.pbxFoto.Size = New System.Drawing.Size(493, 456)
        Me.pbxFoto.TabIndex = 0
        Me.pbxFoto.TabStop = False
        '
        'cmbCatalogo
        '
        Me.cmbCatalogo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCatalogo.FormattingEnabled = True
        Me.cmbCatalogo.Location = New System.Drawing.Point(140, 7)
        Me.cmbCatalogo.Name = "cmbCatalogo"
        Me.cmbCatalogo.Size = New System.Drawing.Size(237, 21)
        Me.cmbCatalogo.TabIndex = 168
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(56, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 29)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Información"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox8.Location = New System.Drawing.Point(21, 54)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(35, 29)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 166
        Me.PictureBox8.TabStop = False
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.Controls.Add(Me.Label7)
        Me.RadGroupBox3.Controls.Add(Me.Label8)
        Me.RadGroupBox3.Controls.Add(Me.lblCodigo)
        Me.RadGroupBox3.Controls.Add(Me.lblArticulo)
        Me.RadGroupBox3.FooterImageIndex = -1
        Me.RadGroupBox3.FooterImageKey = ""
        Me.RadGroupBox3.HeaderImageIndex = -1
        Me.RadGroupBox3.HeaderImageKey = ""
        Me.RadGroupBox3.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox3.HeaderText = ""
        Me.RadGroupBox3.Location = New System.Drawing.Point(8, 70)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox3.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox3.Size = New System.Drawing.Size(1230, 54)
        Me.RadGroupBox3.TabIndex = 164
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
        Me.Label8.Location = New System.Drawing.Point(335, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 25)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Artículo :"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(111, 15)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 30)
        Me.lblCodigo.TabIndex = 167
        Me.lblCodigo.Text = "Codigo"
        '
        'lblArticulo
        '
        Me.lblArticulo.AutoSize = True
        Me.lblArticulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblArticulo.ForeColor = System.Drawing.Color.Black
        Me.lblArticulo.Location = New System.Drawing.Point(424, 16)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(95, 30)
        Me.lblArticulo.TabIndex = 165
        Me.lblArticulo.Text = "Articulo"
        '
        'frmBuscarArticuloCatalogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1254, 712)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.RadGroupBox3)
        Me.Controls.Add(Me.rpv0Catalogo)
        Me.Controls.Add(Me.pnlBarra)
        Me.Name = "frmBuscarArticuloCatalogo"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rpv0Catalogo, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox3, 0)
        Me.Controls.SetChildIndex(Me.PictureBox8, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0DocSalida.ResumeLayout(False)
        Me.pnx0DocSalida.PerformLayout()
        CType(Me.pbx0DocSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Imprimir.ResumeLayout(False)
        Me.pnx1Imprimir.PerformLayout()
        CType(Me.pbx1Imprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx2Salir.ResumeLayout(False)
        Me.pnx2Salir.PerformLayout()
        CType(Me.pbx2Cerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpv0Catalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv0Catalogo.ResumeLayout(False)
        Me.pgCatalogo1.ResumeLayout(False)
        Me.pgCatalogo1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        CType(Me.rgbObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbObservacion.ResumeLayout(False)
        Me.rgbObservacion.PerformLayout()
        CType(Me.grdInformacion.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFoto.ResumeLayout(False)
        CType(Me.pbxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        Me.RadGroupBox3.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents CachedrptComprasResumen1 As laFuente.CachedrptComprasResumen
    Friend WithEvents rpv0Catalogo As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgCatalogo1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdInformacion As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbFoto As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents pbxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents cmbCatalogo As System.Windows.Forms.ComboBox
    Friend WithEvents pnx1Imprimir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Imprimir As System.Windows.Forms.Label
    Friend WithEvents pbx1Imprimir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx2Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl2Salir As System.Windows.Forms.Label
    Friend WithEvents pbx2Cerrar As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents rgbObservacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblCompatibilidad As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblEmpaque As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnx0DocSalida As System.Windows.Forms.Panel
    Friend WithEvents pbx0DocSalida As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0DocSalida As System.Windows.Forms.Label

End Class
