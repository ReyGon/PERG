<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjustesBancarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesBancarios))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx4Salir = New System.Windows.Forms.Panel()
        Me.lbl4Salir = New System.Windows.Forms.Label()
        Me.pbx4Salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Facturar = New System.Windows.Forms.Panel()
        Me.lbl0Facturar = New System.Windows.Forms.Label()
        Me.pbx0Facturar = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbConcepto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCorrelativo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nm2Monto = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.cmbCuenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx4Salir.SuspendLayout()
        CType(Me.pbx4Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Facturar.SuspendLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.nm2Monto, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx4Salir)
        Me.pnlBarra.Controls.Add(Me.pnx0Facturar)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(247, 48)
        Me.pnlBarra.TabIndex = 126
        '
        'pnx4Salir
        '
        Me.pnx4Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx4Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx4Salir.Controls.Add(Me.lbl4Salir)
        Me.pnx4Salir.Controls.Add(Me.pbx4Salir)
        Me.pnx4Salir.Location = New System.Drawing.Point(119, 3)
        Me.pnx4Salir.Name = "pnx4Salir"
        Me.pnx4Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx4Salir.TabIndex = 117
        '
        'lbl4Salir
        '
        Me.lbl4Salir.AutoSize = True
        Me.lbl4Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4Salir.ForeColor = System.Drawing.Color.White
        Me.lbl4Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl4Salir.Name = "lbl4Salir"
        Me.lbl4Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl4Salir.TabIndex = 72
        Me.lbl4Salir.Text = "Salir"
        '
        'pbx4Salir
        '
        Me.pbx4Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx4Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx4Salir.Name = "pbx4Salir"
        Me.pbx4Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx4Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx4Salir.TabIndex = 71
        Me.pbx4Salir.TabStop = False
        '
        'pnx0Facturar
        '
        Me.pnx0Facturar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Facturar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Facturar.Controls.Add(Me.lbl0Facturar)
        Me.pnx0Facturar.Controls.Add(Me.pbx0Facturar)
        Me.pnx0Facturar.Location = New System.Drawing.Point(6, 4)
        Me.pnx0Facturar.Name = "pnx0Facturar"
        Me.pnx0Facturar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Facturar.TabIndex = 116
        '
        'lbl0Facturar
        '
        Me.lbl0Facturar.AutoSize = True
        Me.lbl0Facturar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Facturar.ForeColor = System.Drawing.Color.White
        Me.lbl0Facturar.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Facturar.Name = "lbl0Facturar"
        Me.lbl0Facturar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Facturar.TabIndex = 72
        Me.lbl0Facturar.Text = "Guardar"
        '
        'pbx0Facturar
        '
        Me.pbx0Facturar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx0Facturar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Facturar.Name = "pbx0Facturar"
        Me.pbx0Facturar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Facturar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Facturar.TabIndex = 71
        Me.pbx0Facturar.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(35, 54)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 129
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(84, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 25)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Información"
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.cmbConcepto)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblCorrelativo)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.nm2Monto)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.txtDocumento)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.cmbCuenta)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.Label24)
        Me.rgbInformacion.Controls.Add(Me.cmbBanco)
        Me.rgbInformacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(11, 76)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(688, 211)
        Me.rgbInformacion.TabIndex = 127
        '
        'cmbConcepto
        '
        Me.cmbConcepto.FormattingEnabled = True
        Me.cmbConcepto.Location = New System.Drawing.Point(135, 121)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(231, 21)
        Me.cmbConcepto.TabIndex = 150
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(48, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 19)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "Concepto :"
        '
        'lblCorrelativo
        '
        Me.lblCorrelativo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCorrelativo.AutoSize = True
        Me.lblCorrelativo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCorrelativo.Location = New System.Drawing.Point(136, 47)
        Me.lblCorrelativo.Name = "lblCorrelativo"
        Me.lblCorrelativo.Size = New System.Drawing.Size(19, 21)
        Me.lblCorrelativo.TabIndex = 148
        Me.lblCorrelativo.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(36, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 19)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Correlativo :"
        '
        'nm2Monto
        '
        Me.nm2Monto.DecimalPlaces = 2
        Me.nm2Monto.Location = New System.Drawing.Point(135, 177)
        Me.nm2Monto.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nm2Monto.Name = "nm2Monto"
        Me.nm2Monto.Size = New System.Drawing.Size(232, 25)
        Me.nm2Monto.TabIndex = 146
        Me.nm2Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(68, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 19)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "Monto :"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(135, 147)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(232, 25)
        Me.txtDocumento.TabIndex = 144
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(35, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 19)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Transacción:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(74, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 19)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Fecha :"
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(135, 22)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(232, 25)
        Me.dtpFechaRegistro.TabIndex = 140
        '
        'cmbCuenta
        '
        Me.cmbCuenta.FormattingEnabled = True
        Me.cmbCuenta.Location = New System.Drawing.Point(135, 97)
        Me.cmbCuenta.Name = "cmbCuenta"
        Me.cmbCuenta.Size = New System.Drawing.Size(232, 21)
        Me.cmbCuenta.TabIndex = 137
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(66, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 19)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Cuenta :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.DimGray
        Me.Label24.Location = New System.Drawing.Point(71, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(58, 19)
        Me.Label24.TabIndex = 135
        Me.Label24.Text = "Banco :"
        '
        'cmbBanco
        '
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(135, 70)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(232, 21)
        Me.cmbBanco.TabIndex = 134
        '
        'frmAjustesBancarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(714, 296)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAjustesBancarios"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "frmAjustesBancarios"
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx4Salir.ResumeLayout(False)
        Me.pnx4Salir.PerformLayout()
        CType(Me.pbx4Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Facturar.ResumeLayout(False)
        Me.pnx0Facturar.PerformLayout()
        CType(Me.pbx0Facturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.nm2Monto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx4Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl4Salir As System.Windows.Forms.Label
    Friend WithEvents pbx4Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Facturar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Facturar As System.Windows.Forms.Label
    Friend WithEvents pbx0Facturar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nm2Monto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox

End Class
