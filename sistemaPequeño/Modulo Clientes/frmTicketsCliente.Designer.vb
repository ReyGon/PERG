<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTicketsCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTicketsCliente))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rgbEmpleados = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdTickets = New Telerik.WinControls.UI.RadGridView()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbNegocio = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtCobrados = New System.Windows.Forms.RadioButton()
        Me.rbtSinCobrar = New System.Windows.Forms.RadioButton()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbEmpleados.SuspendLayout()
        CType(Me.grdTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTickets.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
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
        Me.pnlBarra.Size = New System.Drawing.Size(215, 48)
        Me.pnlBarra.TabIndex = 110
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(93, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 177
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(48, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 66
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 65
        Me.pbx0Salir.TabStop = False
        '
        'rgbEmpleados
        '
        Me.rgbEmpleados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbEmpleados.Controls.Add(Me.grdTickets)
        Me.rgbEmpleados.FooterImageIndex = -1
        Me.rgbEmpleados.FooterImageKey = ""
        Me.rgbEmpleados.HeaderImageIndex = -1
        Me.rgbEmpleados.HeaderImageKey = ""
        Me.rgbEmpleados.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbEmpleados.HeaderText = "Tickets"
        Me.rgbEmpleados.Location = New System.Drawing.Point(12, 137)
        Me.rgbEmpleados.Name = "rgbEmpleados"
        Me.rgbEmpleados.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbEmpleados.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbEmpleados.Size = New System.Drawing.Size(657, 273)
        Me.rgbEmpleados.TabIndex = 111
        Me.rgbEmpleados.Text = "Tickets"
        Me.rgbEmpleados.ThemeName = "Office2007Black"
        '
        'grdTickets
        '
        Me.grdTickets.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTickets.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTickets.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTickets.ForeColor = System.Drawing.Color.Black
        Me.grdTickets.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTickets.Location = New System.Drawing.Point(10, 20)
        '
        'grdTickets
        '
        Me.grdTickets.MasterTemplate.AllowAddNewRow = False
        Me.grdTickets.MasterTemplate.AllowColumnReorder = False
        Me.grdTickets.Name = "grdTickets"
        Me.grdTickets.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTickets.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTickets.RootElement.ForeColor = System.Drawing.Color.Black
        Me.grdTickets.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTickets.Size = New System.Drawing.Size(637, 243)
        Me.grdTickets.TabIndex = 0
        Me.grdTickets.Text = "Empleados"
        Me.grdTickets.ThemeName = "Office2007Black"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.rbtCobrados)
        Me.RadGroupBox1.Controls.Add(Me.rbtSinCobrar)
        Me.RadGroupBox1.Controls.Add(Me.cmbNegocio)
        Me.RadGroupBox1.Controls.Add(Me.Label2)
        Me.RadGroupBox1.Controls.Add(Me.cmbCliente)
        Me.RadGroupBox1.Controls.Add(Me.Label4)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Cliente"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(657, 77)
        Me.RadGroupBox1.TabIndex = 112
        Me.RadGroupBox1.Text = "Cliente"
        Me.RadGroupBox1.ThemeName = "Office2007Black"
        '
        'cmbCliente
        '
        Me.cmbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(80, 20)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(323, 23)
        Me.cmbCliente.TabIndex = 178
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(15, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 19)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "Cliente :"
        '
        'cmbNegocio
        '
        Me.cmbNegocio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbNegocio.FormattingEnabled = True
        Me.cmbNegocio.Location = New System.Drawing.Point(80, 49)
        Me.cmbNegocio.Name = "cmbNegocio"
        Me.cmbNegocio.Size = New System.Drawing.Size(323, 23)
        Me.cmbNegocio.TabIndex = 180
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 19)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Negocio :"
        '
        'rbtCobrados
        '
        Me.rbtCobrados.AutoSize = True
        Me.rbtCobrados.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtCobrados.Location = New System.Drawing.Point(443, 21)
        Me.rbtCobrados.Name = "rbtCobrados"
        Me.rbtCobrados.Size = New System.Drawing.Size(76, 19)
        Me.rbtCobrados.TabIndex = 224
        Me.rbtCobrados.TabStop = True
        Me.rbtCobrados.Text = "Cobrados"
        Me.rbtCobrados.UseVisualStyleBackColor = True
        '
        'rbtSinCobrar
        '
        Me.rbtSinCobrar.AutoSize = True
        Me.rbtSinCobrar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtSinCobrar.Location = New System.Drawing.Point(555, 21)
        Me.rbtSinCobrar.Name = "rbtSinCobrar"
        Me.rbtSinCobrar.Size = New System.Drawing.Size(80, 19)
        Me.rbtSinCobrar.TabIndex = 225
        Me.rbtSinCobrar.TabStop = True
        Me.rbtSinCobrar.Text = "Sin Cobrar"
        Me.rbtSinCobrar.UseVisualStyleBackColor = True
        '
        'frmTicketsCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(681, 422)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.rgbEmpleados)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTicketsCliente"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Tickets Cliente"
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbEmpleados, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbEmpleados.ResumeLayout(False)
        CType(Me.grdTickets.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTickets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbEmpleados As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdTickets As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbNegocio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbtCobrados As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSinCobrar As System.Windows.Forms.RadioButton

End Class
