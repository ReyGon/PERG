<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturasTipoImpresion
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbImpresora = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nm2PorcentajeDescuento = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pageDatos.SuspendLayout()
        CType(Me.nm2PorcentajeDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.rpv.Location = New System.Drawing.Point(3, 56)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pageDatos
        Me.rpv.Size = New System.Drawing.Size(1133, 192)
        Me.rpv.TabIndex = 105
        Me.rpv.Text = "Datos"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pageDatos
        '
        Me.pageDatos.BackColor = System.Drawing.Color.White
        Me.pageDatos.Controls.Add(Me.Label4)
        Me.pageDatos.Controls.Add(Me.cmbImpresora)
        Me.pageDatos.Controls.Add(Me.Label1)
        Me.pageDatos.Controls.Add(Me.nm2PorcentajeDescuento)
        Me.pageDatos.Controls.Add(Me.Label6)
        Me.pageDatos.Controls.Add(Me.txtObservacion)
        Me.pageDatos.Controls.Add(Me.Label3)
        Me.pageDatos.Controls.Add(Me.Label2)
        Me.pageDatos.Controls.Add(Me.txtNombre)
        Me.pageDatos.Controls.Add(Me.txtCodigo)
        Me.pageDatos.Location = New System.Drawing.Point(10, 44)
        Me.pageDatos.Name = "pageDatos"
        Me.pageDatos.Size = New System.Drawing.Size(1112, 137)
        Me.pageDatos.Text = " Información "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(60, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Impresora :"
        '
        'cmbImpresora
        '
        Me.cmbImpresora.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbImpresora.FormattingEnabled = True
        Me.cmbImpresora.Location = New System.Drawing.Point(127, 98)
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(370, 25)
        Me.cmbImpresora.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(-1, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Porcentaje Descuento :"
        '
        'nm2PorcentajeDescuento
        '
        Me.nm2PorcentajeDescuento.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm2PorcentajeDescuento.Location = New System.Drawing.Point(127, 63)
        Me.nm2PorcentajeDescuento.Name = "nm2PorcentajeDescuento"
        Me.nm2PorcentajeDescuento.Size = New System.Drawing.Size(100, 29)
        Me.nm2PorcentajeDescuento.TabIndex = 17
        Me.nm2PorcentajeDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(526, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Observación :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(605, 26)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(370, 97)
        Me.txtObservacion.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(74, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(69, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre :"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(127, 31)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(370, 25)
        Me.txtNombre.TabIndex = 7
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(127, 3)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigo.TabIndex = 6
        '
        'frmFacturasTipoImpresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1143, 529)
        Me.Controls.Add(Me.rpv)
        Me.Name = "frmFacturasTipoImpresion"
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
        CType(Me.nm2PorcentajeDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pageDatos As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nm2PorcentajeDescuento As System.Windows.Forms.NumericUpDown

End Class
