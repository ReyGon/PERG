<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoLista
    Inherits laFuente.frmBaseLista

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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTipoInventario = New System.Windows.Forms.ComboBox()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgbDatos
        '
        Me.rgbDatos.Location = New System.Drawing.Point(6, 76)
        '
        '
        '
        Me.rgbDatos.RootElement.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDatos.Size = New System.Drawing.Size(1266, 451)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(889, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "Tipo Inventario :"
        '
        'cmbTipoInventario
        '
        Me.cmbTipoInventario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoInventario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoInventario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoInventario.FormattingEnabled = True
        Me.cmbTipoInventario.Location = New System.Drawing.Point(985, 49)
        Me.cmbTipoInventario.Name = "cmbTipoInventario"
        Me.cmbTipoInventario.Size = New System.Drawing.Size(228, 21)
        Me.cmbTipoInventario.TabIndex = 167
        '
        'frmProductoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1282, 529)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbTipoInventario)
        Me.Name = "frmProductoLista"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.Controls.SetChildIndex(Me.rgbDatos, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblFiltroFecha, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoInventario, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoInventario As System.Windows.Forms.ComboBox

End Class
