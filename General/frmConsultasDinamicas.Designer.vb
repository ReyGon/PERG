<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultasDinamicas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultasDinamicas))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.cmbConsulta = New System.Windows.Forms.ComboBox()
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.btnCopiarFilas = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListado = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Progreso = New Telerik.WinControls.UI.RadProgressBar()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.rbtConsultas = New System.Windows.Forms.RadioButton()
        Me.rbtProcedimientos = New System.Windows.Forms.RadioButton()
        Me.rgbProcedimientos = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbtVentasCosto = New System.Windows.Forms.RadioButton()
        Me.rbtRetroactividadCli = New System.Windows.Forms.RadioButton()
        Me.rbtDevAjustes = New System.Windows.Forms.RadioButton()
        Me.rbtCompras = New System.Windows.Forms.RadioButton()
        Me.rbtRetroactividadInv = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTipoInventarios = New System.Windows.Forms.ComboBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Progreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.rgbProcedimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbProcedimientos.SuspendLayout()
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
        Me.pnlBarra.Size = New System.Drawing.Size(753, 48)
        Me.pnlBarra.TabIndex = 106
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(643, 3)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 117
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
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
        'lblCP
        '
        Me.lblCP.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.Location = New System.Drawing.Point(464, 62)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(61, 18)
        Me.lblCP.TabIndex = 108
        Me.lblCP.Text = "Consulta :"
        Me.lblCP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbConsulta
        '
        Me.cmbConsulta.FormattingEnabled = True
        Me.cmbConsulta.Location = New System.Drawing.Point(536, 59)
        Me.cmbConsulta.Name = "cmbConsulta"
        Me.cmbConsulta.Size = New System.Drawing.Size(374, 21)
        Me.cmbConsulta.TabIndex = 107
        '
        'btnConsulta
        '
        Me.btnConsulta.BackColor = System.Drawing.Color.SteelBlue
        Me.btnConsulta.FlatAppearance.BorderSize = 0
        Me.btnConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsulta.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.ForeColor = System.Drawing.Color.Transparent
        Me.btnConsulta.Location = New System.Drawing.Point(1055, 55)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(153, 43)
        Me.btnConsulta.TabIndex = 184
        Me.btnConsulta.Text = "Generar Consulta"
        Me.btnConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsulta.UseVisualStyleBackColor = False
        '
        'btnCopiarFilas
        '
        Me.btnCopiarFilas.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCopiarFilas.FlatAppearance.BorderSize = 0
        Me.btnCopiarFilas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnCopiarFilas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnCopiarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopiarFilas.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiarFilas.ForeColor = System.Drawing.Color.Transparent
        Me.btnCopiarFilas.Location = New System.Drawing.Point(1055, 104)
        Me.btnCopiarFilas.Name = "btnCopiarFilas"
        Me.btnCopiarFilas.Size = New System.Drawing.Size(153, 43)
        Me.btnCopiarFilas.TabIndex = 187
        Me.btnCopiarFilas.Text = "Copiar Filas"
        Me.btnCopiarFilas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCopiarFilas.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdListado)
        Me.Panel1.Location = New System.Drawing.Point(2, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1214, 378)
        Me.Panel1.TabIndex = 188
        '
        'grdListado
        '
        Me.grdListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListado.Location = New System.Drawing.Point(3, 3)
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(1208, 372)
        Me.grdListado.TabIndex = 111
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(936, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 19)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Hasta :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(933, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "Desde :"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(933, 124)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(101, 20)
        Me.dtpHasta.TabIndex = 222
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(933, 75)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(101, 20)
        Me.dtpDesde.TabIndex = 221
        '
        'Progreso
        '
        Me.Progreso.Dash = False
        Me.Progreso.Location = New System.Drawing.Point(467, 122)
        Me.Progreso.Name = "Progreso"
        Me.Progreso.Size = New System.Drawing.Size(444, 25)
        Me.Progreso.TabIndex = 225
        Me.Progreso.Text = "0 %"
        Me.Progreso.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Controls.Add(Me.rbtConsultas)
        Me.RadGroupBox1.Controls.Add(Me.rbtProcedimientos)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Tipo Consulta"
        Me.RadGroupBox1.Location = New System.Drawing.Point(5, 55)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(126, 92)
        Me.RadGroupBox1.TabIndex = 244
        Me.RadGroupBox1.Text = "Tipo Consulta"
        '
        'rbtConsultas
        '
        Me.rbtConsultas.AutoSize = True
        Me.rbtConsultas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtConsultas.Location = New System.Drawing.Point(9, 27)
        Me.rbtConsultas.Name = "rbtConsultas"
        Me.rbtConsultas.Size = New System.Drawing.Size(77, 19)
        Me.rbtConsultas.TabIndex = 221
        Me.rbtConsultas.TabStop = True
        Me.rbtConsultas.Text = "Consultas"
        Me.rbtConsultas.UseVisualStyleBackColor = True
        '
        'rbtProcedimientos
        '
        Me.rbtProcedimientos.AutoSize = True
        Me.rbtProcedimientos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtProcedimientos.Location = New System.Drawing.Point(9, 57)
        Me.rbtProcedimientos.Name = "rbtProcedimientos"
        Me.rbtProcedimientos.Size = New System.Drawing.Size(108, 19)
        Me.rbtProcedimientos.TabIndex = 223
        Me.rbtProcedimientos.TabStop = True
        Me.rbtProcedimientos.Text = "Procedimientos"
        Me.rbtProcedimientos.UseVisualStyleBackColor = True
        '
        'rgbProcedimientos
        '
        Me.rgbProcedimientos.Controls.Add(Me.RadioButton1)
        Me.rgbProcedimientos.Controls.Add(Me.rbtVentasCosto)
        Me.rgbProcedimientos.Controls.Add(Me.rbtRetroactividadCli)
        Me.rgbProcedimientos.Controls.Add(Me.rbtDevAjustes)
        Me.rgbProcedimientos.Controls.Add(Me.rbtCompras)
        Me.rgbProcedimientos.Controls.Add(Me.rbtRetroactividadInv)
        Me.rgbProcedimientos.FooterImageIndex = -1
        Me.rgbProcedimientos.FooterImageKey = ""
        Me.rgbProcedimientos.HeaderImageIndex = -1
        Me.rgbProcedimientos.HeaderImageKey = ""
        Me.rgbProcedimientos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbProcedimientos.HeaderText = "Procedimientos"
        Me.rgbProcedimientos.Location = New System.Drawing.Point(137, 58)
        Me.rgbProcedimientos.Name = "rgbProcedimientos"
        Me.rgbProcedimientos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbProcedimientos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbProcedimientos.Size = New System.Drawing.Size(305, 89)
        Me.rgbProcedimientos.TabIndex = 245
        Me.rgbProcedimientos.Text = "Procedimientos"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButton1.Location = New System.Drawing.Point(170, 67)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 19)
        Me.RadioButton1.TabIndex = 227
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Sin Efecto"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbtVentasCosto
        '
        Me.rbtVentasCosto.AutoSize = True
        Me.rbtVentasCosto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtVentasCosto.Location = New System.Drawing.Point(35, 67)
        Me.rbtVentasCosto.Name = "rbtVentasCosto"
        Me.rbtVentasCosto.Size = New System.Drawing.Size(84, 19)
        Me.rbtVentasCosto.TabIndex = 226
        Me.rbtVentasCosto.TabStop = True
        Me.rbtVentasCosto.Text = "Vtas. Costo"
        Me.rbtVentasCosto.UseVisualStyleBackColor = True
        '
        'rbtRetroactividadCli
        '
        Me.rbtRetroactividadCli.AutoSize = True
        Me.rbtRetroactividadCli.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtRetroactividadCli.Location = New System.Drawing.Point(170, 41)
        Me.rbtRetroactividadCli.Name = "rbtRetroactividadCli"
        Me.rbtRetroactividadCli.Size = New System.Drawing.Size(114, 19)
        Me.rbtRetroactividadCli.TabIndex = 225
        Me.rbtRetroactividadCli.TabStop = True
        Me.rbtRetroactividadCli.Text = "Historial Clientes"
        Me.rbtRetroactividadCli.UseVisualStyleBackColor = True
        '
        'rbtDevAjustes
        '
        Me.rbtDevAjustes.AutoSize = True
        Me.rbtDevAjustes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtDevAjustes.Location = New System.Drawing.Point(35, 41)
        Me.rbtDevAjustes.Name = "rbtDevAjustes"
        Me.rbtDevAjustes.Size = New System.Drawing.Size(98, 19)
        Me.rbtDevAjustes.TabIndex = 224
        Me.rbtDevAjustes.TabStop = True
        Me.rbtDevAjustes.Text = "Dev. y Ajustes"
        Me.rbtDevAjustes.UseVisualStyleBackColor = True
        '
        'rbtCompras
        '
        Me.rbtCompras.AutoSize = True
        Me.rbtCompras.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtCompras.Location = New System.Drawing.Point(35, 16)
        Me.rbtCompras.Name = "rbtCompras"
        Me.rbtCompras.Size = New System.Drawing.Size(73, 19)
        Me.rbtCompras.TabIndex = 221
        Me.rbtCompras.TabStop = True
        Me.rbtCompras.Text = "Compras"
        Me.rbtCompras.UseVisualStyleBackColor = True
        '
        'rbtRetroactividadInv
        '
        Me.rbtRetroactividadInv.AutoSize = True
        Me.rbtRetroactividadInv.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbtRetroactividadInv.Location = New System.Drawing.Point(170, 16)
        Me.rbtRetroactividadInv.Name = "rbtRetroactividadInv"
        Me.rbtRetroactividadInv.Size = New System.Drawing.Size(125, 19)
        Me.rbtRetroactividadInv.TabIndex = 223
        Me.rbtRetroactividadInv.TabStop = True
        Me.rbtRetroactividadInv.Text = "Historial Inventario"
        Me.rbtRetroactividadInv.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(464, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.TabIndex = 247
        Me.Label4.Text = "Tipo Inv :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbTipoInventarios
        '
        Me.cmbTipoInventarios.FormattingEnabled = True
        Me.cmbTipoInventarios.Location = New System.Drawing.Point(536, 86)
        Me.cmbTipoInventarios.Name = "cmbTipoInventarios"
        Me.cmbTipoInventarios.Size = New System.Drawing.Size(374, 21)
        Me.cmbTipoInventarios.TabIndex = 246
        '
        'frmConsultasDinamicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1220, 532)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbTipoInventarios)
        Me.Controls.Add(Me.rgbProcedimientos)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Progreso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCopiarFilas)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.lblCP)
        Me.Controls.Add(Me.cmbConsulta)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultasDinamicas"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.cmbConsulta, 0)
        Me.Controls.SetChildIndex(Me.lblCP, 0)
        Me.Controls.SetChildIndex(Me.btnConsulta, 0)
        Me.Controls.SetChildIndex(Me.btnCopiarFilas, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.dtpDesde, 0)
        Me.Controls.SetChildIndex(Me.dtpHasta, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Progreso, 0)
        Me.Controls.SetChildIndex(Me.RadGroupBox1, 0)
        Me.Controls.SetChildIndex(Me.rgbProcedimientos, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoInventarios, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Progreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.rgbProcedimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbProcedimientos.ResumeLayout(False)
        Me.rgbProcedimientos.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents cmbConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents btnConsulta As System.Windows.Forms.Button
    Friend WithEvents btnCopiarFilas As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdListado As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Progreso As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rbtConsultas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtProcedimientos As System.Windows.Forms.RadioButton
    Friend WithEvents rgbProcedimientos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rbtCompras As System.Windows.Forms.RadioButton
    Friend WithEvents rbtRetroactividadInv As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoInventarios As System.Windows.Forms.ComboBox
    Friend WithEvents rbtDevAjustes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtRetroactividadCli As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtVentasCosto As System.Windows.Forms.RadioButton


End Class
