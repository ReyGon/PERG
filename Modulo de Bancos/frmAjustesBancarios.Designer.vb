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
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.pnx0Guardar = New System.Windows.Forms.Panel()
        Me.lbl0Guardar = New System.Windows.Forms.Label()
        Me.pbx0Guardar = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rgbEncabezado = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblotrosal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.rbtAjustes = New System.Windows.Forms.RadioButton()
        Me.rbtTransferencia = New System.Windows.Forms.RadioButton()
        Me.cmbCuentas2 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbBancos = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbAjuste = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTransaccion = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
        Me.cmbCuenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Guardar.SuspendLayout()
        CType(Me.pbx0Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbEncabezado.SuspendLayout()
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
        Me.pnlBarra.Size = New System.Drawing.Size(230, 48)
        Me.pnlBarra.TabIndex = 126
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(143, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(84, 40)
        Me.pnx1Salir.TabIndex = 118
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
        Me.pnx0Guardar.Location = New System.Drawing.Point(31, 3)
        Me.pnx0Guardar.Name = "pnx0Guardar"
        Me.pnx0Guardar.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Guardar.TabIndex = 117
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
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(52, 50)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 142
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(96, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 25)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "Información"
        '
        'rgbEncabezado
        '
        Me.rgbEncabezado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbEncabezado.Controls.Add(Me.txtMonto)
        Me.rgbEncabezado.Controls.Add(Me.lblotrosal)
        Me.rgbEncabezado.Controls.Add(Me.Label5)
        Me.rgbEncabezado.Controls.Add(Me.txtObservacion)
        Me.rgbEncabezado.Controls.Add(Me.lblObservacion)
        Me.rgbEncabezado.Controls.Add(Me.lblSaldo)
        Me.rgbEncabezado.Controls.Add(Me.rbtAjustes)
        Me.rgbEncabezado.Controls.Add(Me.rbtTransferencia)
        Me.rgbEncabezado.Controls.Add(Me.cmbCuentas2)
        Me.rgbEncabezado.Controls.Add(Me.Label20)
        Me.rgbEncabezado.Controls.Add(Me.Label21)
        Me.rgbEncabezado.Controls.Add(Me.cmbBancos)
        Me.rgbEncabezado.Controls.Add(Me.Label22)
        Me.rgbEncabezado.Controls.Add(Me.cmbAjuste)
        Me.rgbEncabezado.Controls.Add(Me.Label25)
        Me.rgbEncabezado.Controls.Add(Me.txtTransaccion)
        Me.rgbEncabezado.Controls.Add(Me.Label23)
        Me.rgbEncabezado.Controls.Add(Me.Label3)
        Me.rgbEncabezado.Controls.Add(Me.dtpFechaRegistro)
        Me.rgbEncabezado.Controls.Add(Me.cmbCuenta)
        Me.rgbEncabezado.Controls.Add(Me.Label2)
        Me.rgbEncabezado.Controls.Add(Me.Label8)
        Me.rgbEncabezado.Controls.Add(Me.Label24)
        Me.rgbEncabezado.Controls.Add(Me.cmbBanco)
        Me.rgbEncabezado.FooterImageIndex = -1
        Me.rgbEncabezado.FooterImageKey = ""
        Me.rgbEncabezado.HeaderImageIndex = -1
        Me.rgbEncabezado.HeaderImageKey = ""
        Me.rgbEncabezado.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbEncabezado.HeaderText = ""
        Me.rgbEncabezado.Location = New System.Drawing.Point(12, 70)
        Me.rgbEncabezado.Name = "rgbEncabezado"
        Me.rgbEncabezado.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbEncabezado.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbEncabezado.Size = New System.Drawing.Size(673, 213)
        Me.rgbEncabezado.TabIndex = 140
        Me.rgbEncabezado.ThemeName = "Office2007Black"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(135, 185)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(202, 20)
        Me.txtMonto.TabIndex = 231
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblotrosal
        '
        Me.lblotrosal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblotrosal.Location = New System.Drawing.Point(460, 105)
        Me.lblotrosal.Name = "lblotrosal"
        Me.lblotrosal.Size = New System.Drawing.Size(206, 18)
        Me.lblotrosal.TabIndex = 230
        Me.lblotrosal.Text = "0"
        Me.lblotrosal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(402, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 19)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "Saldo :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(463, 132)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(203, 72)
        Me.txtObservacion.TabIndex = 228
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblObservacion.ForeColor = System.Drawing.Color.DimGray
        Me.lblObservacion.Location = New System.Drawing.Point(356, 131)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(101, 19)
        Me.lblObservacion.TabIndex = 227
        Me.lblObservacion.Text = "Observacion :"
        '
        'lblSaldo
        '
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(131, 108)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(206, 18)
        Me.lblSaldo.TabIndex = 198
        Me.lblSaldo.Text = "0"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbtAjustes
        '
        Me.rbtAjustes.AutoSize = True
        Me.rbtAjustes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtAjustes.Location = New System.Drawing.Point(463, 22)
        Me.rbtAjustes.Name = "rbtAjustes"
        Me.rbtAjustes.Size = New System.Drawing.Size(63, 19)
        Me.rbtAjustes.TabIndex = 224
        Me.rbtAjustes.Text = "Ajustes"
        Me.rbtAjustes.UseVisualStyleBackColor = True
        '
        'rbtTransferencia
        '
        Me.rbtTransferencia.AutoSize = True
        Me.rbtTransferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtTransferencia.Location = New System.Drawing.Point(570, 22)
        Me.rbtTransferencia.Name = "rbtTransferencia"
        Me.rbtTransferencia.Size = New System.Drawing.Size(96, 19)
        Me.rbtTransferencia.TabIndex = 225
        Me.rbtTransferencia.Text = "Transferencia"
        Me.rbtTransferencia.UseVisualStyleBackColor = True
        '
        'cmbCuentas2
        '
        Me.cmbCuentas2.FormattingEnabled = True
        Me.cmbCuentas2.Location = New System.Drawing.Point(463, 79)
        Me.cmbCuentas2.Name = "cmbCuentas2"
        Me.cmbCuentas2.Size = New System.Drawing.Size(203, 21)
        Me.cmbCuentas2.TabIndex = 202
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.DimGray
        Me.Label20.Location = New System.Drawing.Point(394, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 19)
        Me.Label20.TabIndex = 201
        Me.Label20.Text = "Cuenta :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.DimGray
        Me.Label21.Location = New System.Drawing.Point(399, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 19)
        Me.Label21.TabIndex = 200
        Me.Label21.Text = "Banco :"
        '
        'cmbBancos
        '
        Me.cmbBancos.FormattingEnabled = True
        Me.cmbBancos.Location = New System.Drawing.Point(463, 52)
        Me.cmbBancos.Name = "cmbBancos"
        Me.cmbBancos.Size = New System.Drawing.Size(203, 21)
        Me.cmbBancos.TabIndex = 199
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.DimGray
        Me.Label22.Location = New System.Drawing.Point(67, 185)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 19)
        Me.Label22.TabIndex = 197
        Me.Label22.Text = "Monto :"
        '
        'cmbAjuste
        '
        Me.cmbAjuste.FormattingEnabled = True
        Me.cmbAjuste.Location = New System.Drawing.Point(135, 132)
        Me.cmbAjuste.Name = "cmbAjuste"
        Me.cmbAjuste.Size = New System.Drawing.Size(202, 21)
        Me.cmbAjuste.TabIndex = 196
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(47, 132)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(81, 19)
        Me.Label25.TabIndex = 195
        Me.Label25.Text = "Concepto :"
        '
        'txtTransaccion
        '
        Me.txtTransaccion.Location = New System.Drawing.Point(134, 159)
        Me.txtTransaccion.Name = "txtTransaccion"
        Me.txtTransaccion.Size = New System.Drawing.Size(203, 20)
        Me.txtTransaccion.TabIndex = 194
        Me.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.DimGray
        Me.Label23.Location = New System.Drawing.Point(4, 159)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(124, 19)
        Me.Label23.TabIndex = 193
        Me.Label23.Text = "No. Transaccion :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(73, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 19)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "Fecha :"
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(134, 23)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(203, 20)
        Me.dtpFechaRegistro.TabIndex = 191
        '
        'cmbCuenta
        '
        Me.cmbCuenta.FormattingEnabled = True
        Me.cmbCuenta.Location = New System.Drawing.Point(134, 82)
        Me.cmbCuenta.Name = "cmbCuenta"
        Me.cmbCuenta.Size = New System.Drawing.Size(203, 21)
        Me.cmbCuenta.TabIndex = 190
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(73, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 19)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Saldo :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(65, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 19)
        Me.Label8.TabIndex = 189
        Me.Label8.Text = "Cuenta :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.DimGray
        Me.Label24.Location = New System.Drawing.Point(70, 55)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(58, 19)
        Me.Label24.TabIndex = 188
        Me.Label24.Text = "Banco :"
        '
        'cmbBanco
        '
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(134, 55)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(203, 21)
        Me.cmbBanco.TabIndex = 187
        '
        'frmAjustesBancarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(697, 295)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rgbEncabezado)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAjustesBancarios"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "frmAjustesBancarios"
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbEncabezado, 0)
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
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbEncabezado.ResumeLayout(False)
        Me.rgbEncabezado.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rgbEncabezado As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransaccion As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbCuentas2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbBancos As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbAjuste As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents rbtAjustes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents pnx0Guardar As System.Windows.Forms.Panel
    Friend WithEvents lbl0Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx0Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents lblotrosal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
