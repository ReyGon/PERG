<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancoDebito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBancoDebito))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkProgramado = New System.Windows.Forms.CheckBox()
        Me.cmbConcepto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCorrelativo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nm2Monto = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAgregarBeneficiario = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.cmbBeneficiario = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCuenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.nm2Monto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Controls.Add(Me.pnx0Guardar)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(247, 48)
        Me.pnlBarra.TabIndex = 107
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(128, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 117
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 72
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 71
        Me.pbx1Salir.TabStop = False
        '
        'pnx0Guardar
        '
        Me.pnx0Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Guardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Guardar.Controls.Add(Me.lbl0Guardar)
        Me.pnx0Guardar.Controls.Add(Me.pbx0Guardar)
        Me.pnx0Guardar.Location = New System.Drawing.Point(18, 4)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Guardar.TabIndex = 116
        '
        'lbl0Guardar
        '
        Me.lbl0Guardar.AutoSize = True
        Me.lbl0Guardar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl0Guardar.Location = New System.Drawing.Point(42, 9)
        Me.lbl0Guardar.Name = "lbl0Guardar"
        Me.lbl0Guardar.Size = New System.Drawing.Size(64, 19)
        Me.lbl0Guardar.TabIndex = 72
        Me.lbl0Guardar.Text = "Guardar"
        '
        'pbx0Guardar
        '
        Me.pbx0Guardar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx0Guardar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Guardar.Name = "pbx0Guardar"
        Me.pbx0Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Guardar.TabIndex = 71
        Me.pbx0Guardar.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.chkProgramado)
        Me.rgbInformacion.Controls.Add(Me.cmbConcepto)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblCorrelativo)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.nm2Monto)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.txtDocumento)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.btnAgregarBeneficiario)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.cmbBeneficiario)
        Me.rgbInformacion.Controls.Add(Me.Label3)
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
        Me.rgbInformacion.Location = New System.Drawing.Point(13, 76)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(688, 251)
        Me.rgbInformacion.TabIndex = 108
        '
        'chkProgramado
        '
        Me.chkProgramado.AutoSize = True
        Me.chkProgramado.Location = New System.Drawing.Point(373, 27)
        Me.chkProgramado.Name = "chkProgramado"
        Me.chkProgramado.Size = New System.Drawing.Size(103, 21)
        Me.chkProgramado.TabIndex = 151
        Me.chkProgramado.Text = "Programado"
        Me.chkProgramado.UseVisualStyleBackColor = True
        '
        'cmbConcepto
        '
        Me.cmbConcepto.FormattingEnabled = True
        Me.cmbConcepto.Location = New System.Drawing.Point(135, 151)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(231, 21)
        Me.cmbConcepto.TabIndex = 150
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(48, 151)
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
        Me.nm2Monto.Location = New System.Drawing.Point(135, 207)
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
        Me.Label6.Location = New System.Drawing.Point(68, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 19)
        Me.Label6.TabIndex = 145
        Me.Label6.Text = "Monto :"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(135, 177)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(232, 25)
        Me.txtDocumento.TabIndex = 144
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(35, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 19)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Documento :"
        '
        'btnAgregarBeneficiario
        '
        Me.btnAgregarBeneficiario.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregarBeneficiario.FlatAppearance.BorderSize = 0
        Me.btnAgregarBeneficiario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregarBeneficiario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregarBeneficiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarBeneficiario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarBeneficiario.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregarBeneficiario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregarBeneficiario.Location = New System.Drawing.Point(373, 117)
        Me.btnAgregarBeneficiario.Name = "btnAgregarBeneficiario"
        Me.btnAgregarBeneficiario.Size = New System.Drawing.Size(76, 28)
        Me.btnAgregarBeneficiario.TabIndex = 142
        Me.btnAgregarBeneficiario.Text = "Agregar"
        Me.btnAgregarBeneficiario.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregarBeneficiario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarBeneficiario.UseVisualStyleBackColor = False
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
        'cmbBeneficiario
        '
        Me.cmbBeneficiario.FormattingEnabled = True
        Me.cmbBeneficiario.Location = New System.Drawing.Point(135, 124)
        Me.cmbBeneficiario.Name = "cmbBeneficiario"
        Me.cmbBeneficiario.Size = New System.Drawing.Size(232, 21)
        Me.cmbBeneficiario.TabIndex = 139
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(33, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 19)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Beneficiario :"
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
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(37, 54)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 114
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(86, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 25)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Información"
        '
        'frmBancoDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(711, 339)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBancoDebito"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Guardar.ResumeLayout(False)
        Me.pnx0Guardar.PerformLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.nm2Monto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarBeneficiario As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbBeneficiario As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
    Friend WithEvents nm2Monto As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkProgramado As System.Windows.Forms.CheckBox

End Class
