<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrystalViewver
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.crView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'crView
        '
        Me.crView.ActiveViewIndex = -1
        Me.crView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        'Me.crView.DisplayGroupTree = False
        Me.crView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CNetHelpProvider.SetHelpKeyword(Me.crView, "almacen_Form_frmCrystalViewver.htm#frmCrystalViewver_crView")
        Me.CNetHelpProvider.SetHelpNavigator(Me.crView, System.Windows.Forms.HelpNavigator.Topic)
        Me.crView.Location = New System.Drawing.Point(0, 0)
        Me.crView.Name = "crView"
        Me.crView.SelectionFormula = ""
        Me.crView.ShowGroupTreeButton = False
        Me.CNetHelpProvider.SetShowHelp(Me.crView, True)
        Me.crView.Size = New System.Drawing.Size(660, 489)
        Me.crView.TabIndex = 0
        Me.crView.ViewTimeSelectionFormula = ""
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "almacen.chm"
        '
        'frmCrystalViewver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 489)
        Me.Controls.Add(Me.crView)
        Me.CNetHelpProvider.SetHelpKeyword(Me, "almacen_Form_frmCrystalViewver.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "frmCrystalViewver"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.Text = "Reporte"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crView As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
End Class
