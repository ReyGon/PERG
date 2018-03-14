<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSucursales
    Inherits laFuente.frmBaseTelerik

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
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pageDatos = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pageDatos.SuspendLayout()
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
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(125, 32)
        Me.lbTituloFrm.Text = "FrmBaseT"
        '
        'rpv
        '
        Me.rpv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpv.BackColor = System.Drawing.Color.White
        Me.rpv.Controls.Add(Me.pageDatos)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rpv.Location = New System.Drawing.Point(4, 56)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pageDatos
        Me.rpv.Size = New System.Drawing.Size(1136, 217)
        Me.rpv.TabIndex = 106
        Me.rpv.Text = "Datos"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pageDatos
        '
        Me.pageDatos.BackColor = System.Drawing.Color.White
        Me.pageDatos.Controls.Add(Me.Label6)
        Me.pageDatos.Controls.Add(Me.txtDireccion)
        Me.pageDatos.Controls.Add(Me.Label7)
        Me.pageDatos.Controls.Add(Me.txtTelefono)
        Me.pageDatos.Controls.Add(Me.Label5)
        Me.pageDatos.Controls.Add(Me.txtDescripcion)
        Me.pageDatos.Controls.Add(Me.Label4)
        Me.pageDatos.Controls.Add(Me.txtCodigo)
        Me.pageDatos.Controls.Add(Me.cmbEmpresa)
        Me.pageDatos.Controls.Add(Me.Label1)
        Me.pageDatos.Controls.Add(Me.Label3)
        Me.pageDatos.Controls.Add(Me.Label2)
        Me.pageDatos.Controls.Add(Me.txtServidor)
        Me.pageDatos.Controls.Add(Me.txtId)
        Me.pageDatos.Location = New System.Drawing.Point(10, 44)
        Me.pageDatos.Name = "pageDatos"
        Me.pageDatos.Size = New System.Drawing.Size(1115, 162)
        Me.pageDatos.Text = " Información "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(465, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Direccion :"
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(528, 39)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(296, 22)
        Me.txtDireccion.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(468, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Telefono :"
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtTelefono.Location = New System.Drawing.Point(528, 70)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(296, 22)
        Me.txtTelefono.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(9, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Descripcion : "
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(87, 124)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(296, 22)
        Me.txtDescripcion.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(34, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Codigo :"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(87, 96)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(296, 22)
        Me.txtCodigo.TabIndex = 3
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(87, 39)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(296, 21)
        Me.cmbEmpresa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(28, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Empresa :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(61, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "ID :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(29, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Servidor :"
        '
        'txtServidor
        '
        Me.txtServidor.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtServidor.Location = New System.Drawing.Point(87, 67)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(296, 22)
        Me.txtServidor.TabIndex = 2
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtId.Enabled = False
        Me.txtId.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtId.Location = New System.Drawing.Point(87, 11)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 22)
        Me.txtId.TabIndex = 0
        '
        'frmSucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1143, 529)
        Me.Controls.Add(Me.rpv)
        Me.Name = "frmSucursales"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.Controls.SetChildIndex(Me.rgbDatos, 0)
        Me.Controls.SetChildIndex(Me.rpv, 0)
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv.ResumeLayout(False)
        Me.pageDatos.ResumeLayout(False)
        Me.pageDatos.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pageDatos As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox

End Class
