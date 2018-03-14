<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarArticuloVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarArticuloVentas))
        Me.grdModelos = New Telerik.WinControls.UI.RadGridView()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Cerrar = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblClienteProveedor = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rpvDatos = New Telerik.WinControls.UI.RadPageView()
        Me.pgCliente = New Telerik.WinControls.UI.RadPageViewPage()
        Me.pgGeneral = New Telerik.WinControls.UI.RadPageViewPage()
        Me.grdGeneral = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Cerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpvDatos.SuspendLayout()
        Me.pgCliente.SuspendLayout()
        Me.pgGeneral.SuspendLayout()
        CType(Me.grdGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'grdModelos
        '
        Me.grdModelos.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdModelos.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdModelos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdModelos.ForeColor = System.Drawing.Color.Black
        Me.grdModelos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdModelos.Location = New System.Drawing.Point(7, 3)
        '
        'grdModelos
        '
        Me.grdModelos.MasterTemplate.AllowAddNewRow = False
        Me.grdModelos.MasterTemplate.EnableGrouping = False
        Me.grdModelos.Name = "grdModelos"
        Me.grdModelos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdModelos.ReadOnly = True
        Me.grdModelos.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdModelos.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdModelos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdModelos.Size = New System.Drawing.Size(539, 206)
        Me.grdModelos.TabIndex = 0
        Me.grdModelos.ThemeName = "Office2007Black"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(465, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(144, 51)
        Me.pnlBarra.TabIndex = 125
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Cerrar)
        Me.pnx0Salir.Location = New System.Drawing.Point(15, 7)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 194
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(48, 7)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(44, 21)
        Me.lbl0Salir.TabIndex = 190
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Cerrar
        '
        Me.pbx0Cerrar.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Cerrar.Location = New System.Drawing.Point(3, 3)
        Me.pbx0Cerrar.Name = "pbx0Cerrar"
        Me.pbx0Cerrar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Cerrar.TabIndex = 188
        Me.pbx0Cerrar.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(69, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 29)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "Información"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.lblClienteProveedor)
        Me.rgbInformacion.Controls.Add(Me.lblCliente)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.lblCodigo)
        Me.rgbInformacion.Controls.Add(Me.lblArticulo)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(7, 71)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(580, 106)
        Me.rgbInformacion.TabIndex = 193
        '
        'lblClienteProveedor
        '
        Me.lblClienteProveedor.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteProveedor.ForeColor = System.Drawing.Color.DimGray
        Me.lblClienteProveedor.Location = New System.Drawing.Point(5, 71)
        Me.lblClienteProveedor.Name = "lblClienteProveedor"
        Me.lblClienteProveedor.Size = New System.Drawing.Size(123, 25)
        Me.lblClienteProveedor.TabIndex = 168
        Me.lblClienteProveedor.Text = "Cliente :"
        Me.lblClienteProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(134, 67)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(95, 30)
        Me.lblCliente.TabIndex = 169
        Me.lblCliente.Text = "Articulo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(47, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 25)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Código :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(38, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 25)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "Artículo :"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(134, 17)
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
        Me.lblArticulo.Location = New System.Drawing.Point(134, 43)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(95, 30)
        Me.lblArticulo.TabIndex = 165
        Me.lblArticulo.Text = "Articulo"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox3.Location = New System.Drawing.Point(23, 54)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(45, 36)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 195
        Me.PictureBox3.TabStop = False
        '
        'rpvDatos
        '
        Me.rpvDatos.Controls.Add(Me.pgCliente)
        Me.rpvDatos.Controls.Add(Me.pgGeneral)
        Me.rpvDatos.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.rpvDatos.Location = New System.Drawing.Point(7, 184)
        Me.rpvDatos.Name = "rpvDatos"
        Me.rpvDatos.SelectedPage = Me.pgCliente
        Me.rpvDatos.Size = New System.Drawing.Size(580, 265)
        Me.rpvDatos.TabIndex = 196
        Me.rpvDatos.Text = "RadPageView1"
        CType(Me.rpvDatos.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pgCliente
        '
        Me.pgCliente.Controls.Add(Me.grdModelos)
        Me.pgCliente.Location = New System.Drawing.Point(10, 42)
        Me.pgCliente.Name = "pgCliente"
        Me.pgCliente.Size = New System.Drawing.Size(559, 212)
        Me.pgCliente.Text = "Clientes"
        '
        'pgGeneral
        '
        Me.pgGeneral.Controls.Add(Me.grdGeneral)
        Me.pgGeneral.Location = New System.Drawing.Point(10, 42)
        Me.pgGeneral.Name = "pgGeneral"
        Me.pgGeneral.Size = New System.Drawing.Size(559, 212)
        Me.pgGeneral.Text = "General"
        '
        'grdGeneral
        '
        Me.grdGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdGeneral.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdGeneral.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdGeneral.ForeColor = System.Drawing.Color.Black
        Me.grdGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdGeneral.Location = New System.Drawing.Point(5, 3)
        '
        'grdGeneral
        '
        Me.grdGeneral.MasterTemplate.AllowAddNewRow = False
        Me.grdGeneral.MasterTemplate.EnableGrouping = False
        Me.grdGeneral.Name = "grdGeneral"
        Me.grdGeneral.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdGeneral.ReadOnly = True
        Me.grdGeneral.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdGeneral.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdGeneral.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdGeneral.Size = New System.Drawing.Size(539, 206)
        Me.grdGeneral.TabIndex = 1
        Me.grdGeneral.ThemeName = "Office2007Black"
        '
        'frmBuscarArticuloVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(594, 460)
        Me.Controls.Add(Me.rpvDatos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuscarArticuloVentas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.rpvDatos, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Cerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpvDatos.ResumeLayout(False)
        Me.pgCliente.ResumeLayout(False)
        Me.pgGeneral.ResumeLayout(False)
        CType(Me.grdGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdModelos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblClienteProveedor As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents rpvDatos As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgCliente As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents pgGeneral As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdGeneral As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Cerrar As System.Windows.Forms.PictureBox

End Class
