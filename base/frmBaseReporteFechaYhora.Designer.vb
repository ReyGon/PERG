<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBaseReporteFechaYhora
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContenedorMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbTituloFrm = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pbReporte = New System.Windows.Forms.PictureBox()
        Me.txtFecha = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lbHora = New System.Windows.Forms.Label()
        Me.tmrHora = New System.Windows.Forms.Timer(Me.components)
        Me.ContenedorMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContenedorMenu
        '
        Me.ContenedorMenu.ColumnCount = 1
        Me.ContenedorMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ContenedorMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ContenedorMenu.Controls.Add(Me.Panel2, 0, 0)
        Me.ContenedorMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.ContenedorMenu.Location = New System.Drawing.Point(0, 0)
        Me.ContenedorMenu.Name = "ContenedorMenu"
        Me.ContenedorMenu.RowCount = 1
        Me.ContenedorMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ContenedorMenu.Size = New System.Drawing.Size(913, 51)
        Me.ContenedorMenu.TabIndex = 60
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(907, 45)
        Me.Panel2.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(907, 45)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbTituloFrm)
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 39)
        Me.Panel1.TabIndex = 0
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.AutoSize = True
        Me.lbTituloFrm.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloFrm.ForeColor = System.Drawing.Color.White
        Me.lbTituloFrm.Location = New System.Drawing.Point(61, 3)
        Me.lbTituloFrm.Name = "lbTituloFrm"
        Me.lbTituloFrm.Size = New System.Drawing.Size(160, 32)
        Me.lbTituloFrm.TabIndex = 55
        Me.lbTituloFrm.Text = "Nombre Frm"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = My.Resources.Resources.play
        Me.PictureBox6.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(56, 36)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 59
        Me.PictureBox6.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.pbReporte)
        Me.Panel3.Controls.Add(Me.txtFecha)
        Me.Panel3.Controls.Add(Me.lblReporte)
        Me.Panel3.Controls.Add(Me.lbHora)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(456, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(448, 39)
        Me.Panel3.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = My.Resources.Resources.calendar
        Me.PictureBox1.Location = New System.Drawing.Point(342, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 19)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = My.Resources.Resources.clock
        Me.PictureBox2.Location = New System.Drawing.Point(346, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 60
        Me.PictureBox2.TabStop = False
        '
        'pbReporte
        '
        Me.pbReporte.Image = My.Resources.Resources.reporte
        Me.pbReporte.Location = New System.Drawing.Point(3, 3)
        Me.pbReporte.Name = "pbReporte"
        Me.pbReporte.Size = New System.Drawing.Size(40, 33)
        Me.pbReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbReporte.TabIndex = 65
        Me.pbReporte.TabStop = False
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.AutoSize = True
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(376, 0)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(43, 15)
        Me.txtFecha.TabIndex = 56
        Me.txtFecha.Text = "Label3"
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.White
        Me.lblReporte.Location = New System.Drawing.Point(40, 10)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(63, 19)
        Me.lblReporte.TabIndex = 66
        Me.lblReporte.Text = "Reporte"
        '
        'lbHora
        '
        Me.lbHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbHora.AutoSize = True
        Me.lbHora.BackColor = System.Drawing.Color.Transparent
        Me.lbHora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHora.ForeColor = System.Drawing.Color.White
        Me.lbHora.Location = New System.Drawing.Point(375, 23)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(43, 15)
        Me.lbHora.TabIndex = 58
        Me.lbHora.Text = "Label3"
        '
        'tmrHora
        '
        Me.tmrHora.Enabled = True
        '
        'FrmBaseReporteFechaYhora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(913, 451)
        Me.Controls.Add(Me.ContenedorMenu)
        Me.Name = "FrmBaseReporteFechaYhora"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FrmBaseReporteFechaYhora"
        Me.ContenedorMenu.ResumeLayout(False)
        Me.ContenedorMenu.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContenedorMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lbTituloFrm As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFecha As System.Windows.Forms.Label
    Friend WithEvents lbHora As System.Windows.Forms.Label
    Friend WithEvents pbReporte As System.Windows.Forms.PictureBox
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tmrHora As System.Windows.Forms.Timer
End Class

