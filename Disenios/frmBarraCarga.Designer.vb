<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarraCarga
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Progreso = New Telerik.WinControls.UI.RadProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.Progreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Progreso
        '
        Me.Progreso.Dash = False
        Me.Progreso.Location = New System.Drawing.Point(0, -1)
        Me.Progreso.Name = "Progreso"
        Me.Progreso.Size = New System.Drawing.Size(795, 25)
        Me.Progreso.TabIndex = 226
        Me.Progreso.Text = "0 %"
        Me.Progreso.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmBarraCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 23)
        Me.ControlBox = False
        Me.Controls.Add(Me.Progreso)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBarraCarga"
        Me.Text = "Form1"
        CType(Me.Progreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Progreso As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
