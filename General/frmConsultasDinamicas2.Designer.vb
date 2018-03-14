<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultasDinamicas2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultasDinamicas2))
        Me.lblCP = New System.Windows.Forms.Label()
        Me.cmbConsulta = New System.Windows.Forms.ComboBox()
        Me.grdListado2 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListado2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'lblCP
        '
        Me.lblCP.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.Location = New System.Drawing.Point(32, 77)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(87, 18)
        Me.lblCP.TabIndex = 110
        Me.lblCP.Text = "Consulta :"
        Me.lblCP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbConsulta
        '
        Me.cmbConsulta.FormattingEnabled = True
        Me.cmbConsulta.Location = New System.Drawing.Point(130, 74)
        Me.cmbConsulta.Name = "cmbConsulta"
        Me.cmbConsulta.Size = New System.Drawing.Size(402, 21)
        Me.cmbConsulta.TabIndex = 109
        '
        'grdListado2
        '
        Me.grdListado2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListado2.Location = New System.Drawing.Point(57, 73)
        Me.grdListado2.Name = "grdListado2"
        Me.grdListado2.Size = New System.Drawing.Size(264, 113)
        Me.grdListado2.TabIndex = 111
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdListado2)
        Me.Panel1.Location = New System.Drawing.Point(21, 101)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(361, 255)
        Me.Panel1.TabIndex = 112
        '
        'frmConsultasDinamicas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(815, 532)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblCP)
        Me.Controls.Add(Me.cmbConsulta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultasDinamicas2"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.cmbConsulta, 0)
        Me.Controls.SetChildIndex(Me.lblCP, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListado2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents cmbConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents grdListado2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
