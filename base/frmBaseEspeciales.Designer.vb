<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBaseEspeciales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaseEspeciales))
        Me.ContenedorMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlGeneral = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lbTituloFrm = New System.Windows.Forms.Label()
        Me.pnlHora = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lbHora = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.Label()
        Me.tmrHora = New System.Windows.Forms.Timer(Me.components)
        Me.Office2007BlackTheme1 = New Telerik.WinControls.Themes.Office2007BlackTheme()
        Me.ContenedorMenu.SuspendLayout()
        Me.pnlGeneral.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHora.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContenedorMenu
        '
        Me.ContenedorMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.ContenedorMenu.ColumnCount = 1
        Me.ContenedorMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.ContenedorMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ContenedorMenu.Controls.Add(Me.pnlGeneral, 0, 0)
        Me.ContenedorMenu.Location = New System.Drawing.Point(-4, 0)
        Me.ContenedorMenu.Name = "ContenedorMenu"
        Me.ContenedorMenu.RowCount = 1
        Me.ContenedorMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.ContenedorMenu.Size = New System.Drawing.Size(470, 48)
        Me.ContenedorMenu.TabIndex = 59
        '
        'pnlGeneral
        '
        Me.pnlGeneral.AutoSize = True
        Me.pnlGeneral.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlGeneral.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGeneral.Location = New System.Drawing.Point(3, 3)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.Size = New System.Drawing.Size(464, 42)
        Me.pnlGeneral.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.56896!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.43103!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlTitulo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlHora, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(464, 42)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlTitulo.Controls.Add(Me.PictureBox6)
        Me.pnlTitulo.Controls.Add(Me.lbTituloFrm)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(3, 3)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(340, 36)
        Me.pnlTitulo.TabIndex = 0
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.laFuente.My.Resources.Resources.play
        Me.PictureBox6.Location = New System.Drawing.Point(-3, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(56, 36)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 59
        Me.PictureBox6.TabStop = False
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.AutoSize = True
        Me.lbTituloFrm.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloFrm.ForeColor = System.Drawing.Color.White
        Me.lbTituloFrm.Location = New System.Drawing.Point(54, 3)
        Me.lbTituloFrm.Name = "lbTituloFrm"
        Me.lbTituloFrm.Size = New System.Drawing.Size(160, 32)
        Me.lbTituloFrm.TabIndex = 55
        Me.lbTituloFrm.Text = "Nombre Frm"
        '
        'pnlHora
        '
        Me.pnlHora.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlHora.Controls.Add(Me.PictureBox1)
        Me.pnlHora.Controls.Add(Me.Label1)
        Me.pnlHora.Controls.Add(Me.PictureBox2)
        Me.pnlHora.Controls.Add(Me.lbHora)
        Me.pnlHora.Controls.Add(Me.txtFecha)
        Me.pnlHora.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHora.Location = New System.Drawing.Point(349, 3)
        Me.pnlHora.Name = "pnlHora"
        Me.pnlHora.Size = New System.Drawing.Size(112, 36)
        Me.pnlHora.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.laFuente.My.Resources.Resources.calendar
        Me.PictureBox1.Location = New System.Drawing.Point(9, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 19)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-262, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Label3"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = Global.laFuente.My.Resources.Resources.clock
        Me.PictureBox2.Location = New System.Drawing.Point(13, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 60
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'lbHora
        '
        Me.lbHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbHora.AutoSize = True
        Me.lbHora.BackColor = System.Drawing.Color.Transparent
        Me.lbHora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHora.ForeColor = System.Drawing.Color.White
        Me.lbHora.Location = New System.Drawing.Point(42, 21)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(43, 15)
        Me.lbHora.TabIndex = 58
        Me.lbHora.Text = "Label3"
        Me.lbHora.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.AutoSize = True
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Location = New System.Drawing.Point(43, 0)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(43, 15)
        Me.txtFecha.TabIndex = 56
        Me.txtFecha.Text = "Label3"
        Me.txtFecha.Visible = False
        '
        'tmrHora
        '
        Me.tmrHora.Enabled = True
        '
        'FrmBaseEspeciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(815, 532)
        Me.Controls.Add(Me.ContenedorMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmBaseEspeciales"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "FrmBaseEspeciales"
        Me.ThemeName = "Office2007Black"
        Me.ContenedorMenu.ResumeLayout(False)
        Me.ContenedorMenu.PerformLayout()
        Me.pnlGeneral.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHora.ResumeLayout(False)
        Me.pnlHora.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContenedorMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlGeneral As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents lbTituloFrm As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFecha As System.Windows.Forms.Label
    Friend WithEvents lbHora As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlHora As System.Windows.Forms.Panel
    Friend WithEvents tmrHora As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Office2007BlackTheme1 As Telerik.WinControls.Themes.Office2007BlackTheme
End Class

