<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBancoCuentaChequera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBancoCuentaChequera))
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pgInformacion = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nm0Correlativo = New System.Windows.Forms.NumericUpDown()
        Me.nm0Fin = New System.Windows.Forms.NumericUpDown()
        Me.nm0Inicio = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.label02 = New System.Windows.Forms.Label()
        Me.chkHabilitada = New System.Windows.Forms.CheckBox()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pgInformacion.SuspendLayout()
        CType(Me.nm0Correlativo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm0Fin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nm0Inicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgbDatos
        '
        Me.rgbDatos.Location = New System.Drawing.Point(7, 277)
        '
        '
        '
        Me.rgbDatos.RootElement.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDatos.Size = New System.Drawing.Size(830, 170)
        '
        'rpv
        '
        Me.rpv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpv.Controls.Add(Me.pgInformacion)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rpv.Location = New System.Drawing.Point(4, 51)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pgInformacion
        Me.rpv.Size = New System.Drawing.Size(833, 209)
        Me.rpv.TabIndex = 88
        Me.rpv.Text = "RadPageView1"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pgInformacion
        '
        Me.pgInformacion.Controls.Add(Me.chkHabilitada)
        Me.pgInformacion.Controls.Add(Me.lblCodigo)
        Me.pgInformacion.Controls.Add(Me.Label4)
        Me.pgInformacion.Controls.Add(Me.nm0Correlativo)
        Me.pgInformacion.Controls.Add(Me.nm0Fin)
        Me.pgInformacion.Controls.Add(Me.nm0Inicio)
        Me.pgInformacion.Controls.Add(Me.Label3)
        Me.pgInformacion.Controls.Add(Me.Label2)
        Me.pgInformacion.Controls.Add(Me.Label1)
        Me.pgInformacion.Controls.Add(Me.txtDescripcion)
        Me.pgInformacion.Controls.Add(Me.label02)
        Me.pgInformacion.Location = New System.Drawing.Point(10, 44)
        Me.pgInformacion.Name = "pgInformacion"
        Me.pgInformacion.Size = New System.Drawing.Size(812, 154)
        Me.pgInformacion.Text = "Información"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigo.Location = New System.Drawing.Point(694, 135)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(0, 21)
        Me.lblCodigo.TabIndex = 140
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCodigo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(637, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Código :"
        Me.Label4.Visible = False
        '
        'nm0Correlativo
        '
        Me.nm0Correlativo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.nm0Correlativo.Location = New System.Drawing.Point(122, 117)
        Me.nm0Correlativo.Name = "nm0Correlativo"
        Me.nm0Correlativo.Size = New System.Drawing.Size(120, 25)
        Me.nm0Correlativo.TabIndex = 129
        Me.nm0Correlativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm0Fin
        '
        Me.nm0Fin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.nm0Fin.Location = New System.Drawing.Point(122, 87)
        Me.nm0Fin.Name = "nm0Fin"
        Me.nm0Fin.Size = New System.Drawing.Size(120, 25)
        Me.nm0Fin.TabIndex = 128
        Me.nm0Fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nm0Inicio
        '
        Me.nm0Inicio.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nm0Inicio.Location = New System.Drawing.Point(122, 58)
        Me.nm0Inicio.Name = "nm0Inicio"
        Me.nm0Inicio.Size = New System.Drawing.Size(120, 25)
        Me.nm0Inicio.TabIndex = 127
        Me.nm0Inicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(20, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Correlativo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(76, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 19)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Fin :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(59, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 19)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Inicio :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(121, 15)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(318, 37)
        Me.txtDescripcion.TabIndex = 122
        '
        'label02
        '
        Me.label02.AutoSize = True
        Me.label02.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.label02.Location = New System.Drawing.Point(20, 17)
        Me.label02.Name = "label02"
        Me.label02.Size = New System.Drawing.Size(95, 19)
        Me.label02.TabIndex = 123
        Me.label02.Text = "Descripción :"
        '
        'chkHabilitada
        '
        Me.chkHabilitada.AutoSize = True
        Me.chkHabilitada.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.chkHabilitada.Location = New System.Drawing.Point(445, 12)
        Me.chkHabilitada.Name = "chkHabilitada"
        Me.chkHabilitada.Size = New System.Drawing.Size(99, 24)
        Me.chkHabilitada.TabIndex = 141
        Me.chkHabilitada.Text = "Habilitada"
        Me.chkHabilitada.UseVisualStyleBackColor = True
        '
        'frmBancoCuentaChequera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(841, 459)
        Me.Controls.Add(Me.rpv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBancoCuentaChequera"
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
        CType(Me.nm0Correlativo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm0Fin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nm0Inicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pgInformacion As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents nm0Correlativo As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm0Fin As System.Windows.Forms.NumericUpDown
    Friend WithEvents nm0Inicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents label02 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkHabilitada As System.Windows.Forms.CheckBox

End Class
