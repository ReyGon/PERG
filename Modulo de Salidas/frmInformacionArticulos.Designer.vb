<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformacionArticulos
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
        Dim FilterDescriptor1 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim FilterDescriptor2 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim FilterDescriptor3 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadGridView2 = New Telerik.WinControls.UI.RadGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.grdSurtir = New Telerik.WinControls.UI.RadGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.grdSurtir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSurtir.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.RadGridView2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(2, 417)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(811, 167)
        Me.Panel4.TabIndex = 64
        '
        'RadGridView2
        '
        Me.RadGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGridView2.AutoScroll = True
        Me.RadGridView2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadGridView2.Location = New System.Drawing.Point(3, 33)
        '
        'RadGridView2
        '
        Me.RadGridView2.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView2.MasterTemplate.AllowDeleteRow = False
        Me.RadGridView2.MasterTemplate.AllowEditRow = False
        Me.RadGridView2.MasterTemplate.EnableAlternatingRowColor = True
        Me.RadGridView2.MasterTemplate.EnableGrouping = False
        FilterDescriptor1.PropertyName = Nothing
        Me.RadGridView2.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor1})
        Me.RadGridView2.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.RadGridView2.Name = "RadGridView2"
        Me.RadGridView2.Size = New System.Drawing.Size(804, 131)
        Me.RadGridView2.TabIndex = 64
        Me.RadGridView2.Text = "Saldos de productos por Empresa"
        Me.RadGridView2.ThemeName = "BreezeExtended"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(65, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(226, 23)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Productos en Oferta"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.Controls.Add(Me.RadGridView1)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Location = New System.Drawing.Point(2, 260)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(811, 154)
        Me.Panel5.TabIndex = 63
        '
        'RadGridView1
        '
        Me.RadGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGridView1.AutoScroll = True
        Me.RadGridView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadGridView1.Location = New System.Drawing.Point(2, 32)
        '
        'RadGridView1
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.MasterTemplate.AllowDeleteRow = False
        Me.RadGridView1.MasterTemplate.AllowEditRow = False
        Me.RadGridView1.MasterTemplate.EnableAlternatingRowColor = True
        Me.RadGridView1.MasterTemplate.EnableGrouping = False
        FilterDescriptor2.PropertyName = Nothing
        Me.RadGridView1.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor2})
        Me.RadGridView1.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.RadGridView1.Size = New System.Drawing.Size(806, 119)
        Me.RadGridView1.TabIndex = 62
        Me.RadGridView1.Text = "Saldos de productos por Empresa"
        Me.RadGridView1.ThemeName = "Office2007Black"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(64, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(245, 23)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Productos por Ofrecer"
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.grdSurtir)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Location = New System.Drawing.Point(2, 51)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(811, 194)
        Me.Panel6.TabIndex = 65
        '
        'grdSurtir
        '
        Me.grdSurtir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSurtir.AutoScroll = True
        Me.grdSurtir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdSurtir.Location = New System.Drawing.Point(2, 33)
        '
        'grdSurtir
        '
        Me.grdSurtir.MasterTemplate.AllowAddNewRow = False
        Me.grdSurtir.MasterTemplate.AllowDeleteRow = False
        Me.grdSurtir.MasterTemplate.AllowEditRow = False
        Me.grdSurtir.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdSurtir.MasterTemplate.EnableGrouping = False
        FilterDescriptor3.PropertyName = Nothing
        Me.grdSurtir.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor3})
        Me.grdSurtir.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow
        Me.grdSurtir.Name = "grdSurtir"
        Me.grdSurtir.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdSurtir.Size = New System.Drawing.Size(806, 159)
        Me.grdSurtir.TabIndex = 63
        Me.grdSurtir.Text = "Saldos de productos por Empresa"
        Me.grdSurtir.ThemeName = "Office2007Black"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(74, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(242, 23)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Pendientes por Surtir"
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.Location = New System.Drawing.Point(455, -3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(365, 51)
        Me.Panel8.TabIndex = 80
        '
        'frmInformacionArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(815, 585)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Name = "frmInformacionArticulos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.Panel6, 0)
        Me.Controls.SetChildIndex(Me.Panel5, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Controls.SetChildIndex(Me.Panel8, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.RadGridView2.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.grdSurtir.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSurtir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents RadGridView2 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Public WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Public WithEvents grdSurtir As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel

End Class
