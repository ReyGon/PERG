<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCtaPagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCtaPagar))
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rgbFiltros = New Telerik.WinControls.UI.RadGroupBox()
        Me.rbtnPagadas = New System.Windows.Forms.RadioButton()
        Me.rbtnPendientes = New System.Windows.Forms.RadioButton()
        Me.rbtnTodas = New System.Windows.Forms.RadioButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rgbCliente = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbFiltros.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbCliente.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.SteelBlue
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Image = Global.laFuente.My.Resources.Resources.reporte_Blanco
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(361, 342)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(91, 70)
        Me.btnImprimir.TabIndex = 198
        Me.btnImprimir.Text = "Ver Reporte"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.filtroNegro
        Me.PictureBox4.Location = New System.Drawing.Point(18, 240)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 192
        Me.PictureBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(69, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 25)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Filtros"
        '
        'rgbFiltros
        '
        Me.rgbFiltros.Controls.Add(Me.rbtnPagadas)
        Me.rgbFiltros.Controls.Add(Me.rbtnPendientes)
        Me.rgbFiltros.Controls.Add(Me.rbtnTodas)
        Me.rgbFiltros.FooterImageIndex = -1
        Me.rgbFiltros.FooterImageKey = ""
        Me.rgbFiltros.HeaderImageIndex = -1
        Me.rgbFiltros.HeaderImageKey = ""
        Me.rgbFiltros.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbFiltros.HeaderText = ""
        Me.rgbFiltros.Location = New System.Drawing.Point(5, 263)
        Me.rgbFiltros.Name = "rgbFiltros"
        Me.rgbFiltros.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbFiltros.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbFiltros.Size = New System.Drawing.Size(447, 73)
        Me.rgbFiltros.TabIndex = 197
        '
        'rbtnPagadas
        '
        Me.rbtnPagadas.AutoSize = True
        Me.rbtnPagadas.Checked = True
        Me.rbtnPagadas.Location = New System.Drawing.Point(84, 43)
        Me.rbtnPagadas.Name = "rbtnPagadas"
        Me.rbtnPagadas.Size = New System.Drawing.Size(96, 17)
        Me.rbtnPagadas.TabIndex = 2
        Me.rbtnPagadas.TabStop = True
        Me.rbtnPagadas.Text = "Ctas. Pagadas"
        Me.rbtnPagadas.UseVisualStyleBackColor = True
        '
        'rbtnPendientes
        '
        Me.rbtnPendientes.AutoSize = True
        Me.rbtnPendientes.Location = New System.Drawing.Point(267, 43)
        Me.rbtnPendientes.Name = "rbtnPendientes"
        Me.rbtnPendientes.Size = New System.Drawing.Size(110, 17)
        Me.rbtnPendientes.TabIndex = 1
        Me.rbtnPendientes.Text = "Ctas. Pendientes"
        Me.rbtnPendientes.UseVisualStyleBackColor = True
        '
        'rbtnTodas
        '
        Me.rbtnTodas.AutoSize = True
        Me.rbtnTodas.Location = New System.Drawing.Point(201, 23)
        Me.rbtnTodas.Name = "rbtnTodas"
        Me.rbtnTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbtnTodas.TabIndex = 0
        Me.rbtnTodas.Text = "Todas"
        Me.rbtnTodas.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.clienteNegro
        Me.PictureBox3.Location = New System.Drawing.Point(15, 148)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 50)
        Me.PictureBox3.TabIndex = 195
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(63, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 25)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "Proveedor"
        '
        'rgbCliente
        '
        Me.rgbCliente.Controls.Add(Me.cmbProveedor)
        Me.rgbCliente.Controls.Add(Me.Label5)
        Me.rgbCliente.FooterImageIndex = -1
        Me.rgbCliente.FooterImageKey = ""
        Me.rgbCliente.HeaderImageIndex = -1
        Me.rgbCliente.HeaderImageKey = ""
        Me.rgbCliente.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbCliente.HeaderText = ""
        Me.rgbCliente.Location = New System.Drawing.Point(5, 171)
        Me.rgbCliente.Name = "rgbCliente"
        Me.rgbCliente.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbCliente.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbCliente.Size = New System.Drawing.Size(447, 64)
        Me.rgbCliente.TabIndex = 194
        '
        'cmbProveedor
        '
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(83, 30)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(351, 21)
        Me.cmbProveedor.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "Proveedor :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(63, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 25)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Fecha"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.laFuente.My.Resources.Resources.fechaNegro
        Me.PictureBox5.Location = New System.Drawing.Point(15, 53)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(48, 50)
        Me.PictureBox5.TabIndex = 191
        Me.PictureBox5.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Controls.Add(Me.dtpFechaFin)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.dtpFechaInicio)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(2, 74)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(450, 68)
        Me.rgbInformacion.TabIndex = 189
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(276, 35)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaFin.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Desde :"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(96, 35)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaInicio.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(302, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Hasta :"
        '
        'frmConsultaCtaPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(463, 415)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rgbFiltros)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rgbCliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaCtaPagar"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox5, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.rgbCliente, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.rgbFiltros, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbFiltros.ResumeLayout(False)
        Me.rgbFiltros.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbCliente.ResumeLayout(False)
        Me.rgbCliente.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rgbFiltros As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rbtnPagadas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTodas As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rgbCliente As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
