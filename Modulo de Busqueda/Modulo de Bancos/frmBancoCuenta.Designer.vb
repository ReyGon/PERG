<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancoCuenta
    Inherits laFuente.frmBaseTelerik2

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBancoCuenta))
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pgInformacion = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lblPagosTransito = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSaldoTransito = New System.Windows.Forms.Label()
        Me.lblSaldoActual = New System.Windows.Forms.Label()
        Me.chkHabilitada = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.label02 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pgChequera = New Telerik.WinControls.UI.RadPageViewPage()
        Me.btnAgregarChequera = New System.Windows.Forms.Button()
        Me.grdChequeras = New Telerik.WinControls.UI.RadGridView()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pgInformacion.SuspendLayout()
        Me.pgChequera.SuspendLayout()
        CType(Me.grdChequeras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChequeras.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgbDatos
        '
        '
        '
        '
        Me.rgbDatos.RootElement.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDatos.Size = New System.Drawing.Size(957, 0)
        '
        'rpv
        '
        Me.rpv.Controls.Add(Me.pgInformacion)
        Me.rpv.Controls.Add(Me.pgChequera)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rpv.Location = New System.Drawing.Point(6, 50)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pgInformacion
        Me.rpv.Size = New System.Drawing.Size(952, 245)
        Me.rpv.TabIndex = 88
        Me.rpv.Text = "RadPageView1"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pgInformacion
        '
        Me.pgInformacion.Controls.Add(Me.lblPagosTransito)
        Me.pgInformacion.Controls.Add(Me.Label6)
        Me.pgInformacion.Controls.Add(Me.lblCodigo)
        Me.pgInformacion.Controls.Add(Me.Label4)
        Me.pgInformacion.Controls.Add(Me.lblSaldoTransito)
        Me.pgInformacion.Controls.Add(Me.lblSaldoActual)
        Me.pgInformacion.Controls.Add(Me.chkHabilitada)
        Me.pgInformacion.Controls.Add(Me.Label2)
        Me.pgInformacion.Controls.Add(Me.Label1)
        Me.pgInformacion.Controls.Add(Me.txtDescripcion)
        Me.pgInformacion.Controls.Add(Me.txtCuenta)
        Me.pgInformacion.Controls.Add(Me.cmbBanco)
        Me.pgInformacion.Controls.Add(Me.label02)
        Me.pgInformacion.Controls.Add(Me.Label24)
        Me.pgInformacion.Controls.Add(Me.Label19)
        Me.pgInformacion.Location = New System.Drawing.Point(10, 44)
        Me.pgInformacion.Name = "pgInformacion"
        Me.pgInformacion.Size = New System.Drawing.Size(931, 190)
        Me.pgInformacion.Text = "Información"
        '
        'lblPagosTransito
        '
        Me.lblPagosTransito.AutoSize = True
        Me.lblPagosTransito.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPagosTransito.ForeColor = System.Drawing.Color.Black
        Me.lblPagosTransito.Location = New System.Drawing.Point(511, 72)
        Me.lblPagosTransito.Name = "lblPagosTransito"
        Me.lblPagosTransito.Size = New System.Drawing.Size(19, 21)
        Me.lblPagosTransito.TabIndex = 140
        Me.lblPagosTransito.Text = "0"
        Me.lblPagosTransito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(399, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Pagos en Tránsito :"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(891, 166)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(0, 21)
        Me.lblCodigo.TabIndex = 138
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCodigo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(834, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Código :"
        Me.Label4.Visible = False
        '
        'lblSaldoTransito
        '
        Me.lblSaldoTransito.AutoSize = True
        Me.lblSaldoTransito.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSaldoTransito.ForeColor = System.Drawing.Color.Black
        Me.lblSaldoTransito.Location = New System.Drawing.Point(511, 51)
        Me.lblSaldoTransito.Name = "lblSaldoTransito"
        Me.lblSaldoTransito.Size = New System.Drawing.Size(19, 21)
        Me.lblSaldoTransito.TabIndex = 135
        Me.lblSaldoTransito.Text = "0"
        Me.lblSaldoTransito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSaldoActual.ForeColor = System.Drawing.Color.Black
        Me.lblSaldoActual.Location = New System.Drawing.Point(511, 27)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(19, 21)
        Me.lblSaldoActual.TabIndex = 134
        Me.lblSaldoActual.Text = "0"
        Me.lblSaldoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkHabilitada
        '
        Me.chkHabilitada.AutoSize = True
        Me.chkHabilitada.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHabilitada.Location = New System.Drawing.Point(125, 3)
        Me.chkHabilitada.Name = "chkHabilitada"
        Me.chkHabilitada.Size = New System.Drawing.Size(91, 21)
        Me.chkHabilitada.TabIndex = 126
        Me.chkHabilitada.Text = "Habilitada"
        Me.chkHabilitada.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(402, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Saldo en Tránsito :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(427, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Saldo Actual :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(125, 88)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(241, 65)
        Me.txtDescripcion.TabIndex = 120
        '
        'txtCuenta
        '
        Me.txtCuenta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCuenta.Location = New System.Drawing.Point(125, 33)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(241, 22)
        Me.txtCuenta.TabIndex = 118
        '
        'cmbBanco
        '
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(125, 61)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(241, 21)
        Me.cmbBanco.TabIndex = 119
        '
        'label02
        '
        Me.label02.AutoSize = True
        Me.label02.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label02.Location = New System.Drawing.Point(7, 36)
        Me.label02.Name = "label02"
        Me.label02.Size = New System.Drawing.Size(112, 13)
        Me.label02.TabIndex = 121
        Me.label02.Text = "Numero de Cuenta :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(74, 61)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 13)
        Me.Label24.TabIndex = 123
        Me.Label24.Text = "Banco :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(51, 91)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "Descripión :"
        '
        'pgChequera
        '
        Me.pgChequera.Controls.Add(Me.btnAgregarChequera)
        Me.pgChequera.Controls.Add(Me.grdChequeras)
        Me.pgChequera.Location = New System.Drawing.Point(10, 44)
        Me.pgChequera.Name = "pgChequera"
        Me.pgChequera.Size = New System.Drawing.Size(931, 190)
        Me.pgChequera.Text = "Chequeras"
        '
        'btnAgregarChequera
        '
        Me.btnAgregarChequera.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregarChequera.FlatAppearance.BorderSize = 0
        Me.btnAgregarChequera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregarChequera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAgregarChequera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarChequera.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarChequera.ForeColor = System.Drawing.Color.Transparent
        Me.btnAgregarChequera.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.btnAgregarChequera.Location = New System.Drawing.Point(18, 16)
        Me.btnAgregarChequera.Name = "btnAgregarChequera"
        Me.btnAgregarChequera.Size = New System.Drawing.Size(186, 56)
        Me.btnAgregarChequera.TabIndex = 130
        Me.btnAgregarChequera.Text = "Agregar"
        Me.btnAgregarChequera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarChequera.UseVisualStyleBackColor = False
        '
        'grdChequeras
        '
        Me.grdChequeras.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.grdChequeras.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdChequeras.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdChequeras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdChequeras.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdChequeras.Location = New System.Drawing.Point(210, 16)
        '
        'grdChequeras
        '
        Me.grdChequeras.MasterTemplate.AllowAddNewRow = False
        Me.grdChequeras.MasterTemplate.EnableGrouping = False
        Me.grdChequeras.Name = "grdChequeras"
        Me.grdChequeras.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdChequeras.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdChequeras.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdChequeras.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdChequeras.Size = New System.Drawing.Size(718, 164)
        Me.grdChequeras.TabIndex = 0
        Me.grdChequeras.Text = "RadGridView1"
        Me.grdChequeras.ThemeName = "Office2007Black"
        '
        'frmBancoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(964, 307)
        Me.Controls.Add(Me.rpv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBancoCuenta"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.Controls.SetChildIndex(Me.rgbDatos, 0)
        Me.Controls.SetChildIndex(Me.rpv, 0)
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv.ResumeLayout(False)
        Me.pgInformacion.ResumeLayout(False)
        Me.pgInformacion.PerformLayout()
        Me.pgChequera.ResumeLayout(False)
        CType(Me.grdChequeras.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChequeras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgInformacion As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents chkHabilitada As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoTransito As System.Windows.Forms.Label
    Friend WithEvents lblSaldoActual As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pgChequera As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents grdChequeras As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnAgregarChequera As System.Windows.Forms.Button
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents label02 As System.Windows.Forms.Label
    Friend WithEvents lblPagosTransito As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
