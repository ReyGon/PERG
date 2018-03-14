<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentosPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentosPagos))
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rgbEncabezado = New Telerik.WinControls.UI.RadGroupBox()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.txtdocumentoboleta = New System.Windows.Forms.TextBox()
        Me.lbldocumentoboleta = New System.Windows.Forms.Label()
        Me.txtdocumentofactura = New System.Windows.Forms.TextBox()
        Me.lbldocumentofactura = New System.Windows.Forms.Label()
        Me.txtDocumentoPago = New System.Windows.Forms.TextBox()
        Me.lblDocumentoPago = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbEncabezado.SuspendLayout()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(15, 49)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 41)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 104
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(59, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(167, 25)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Documentos Pago"
        '
        'rgbEncabezado
        '
        Me.rgbEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbEncabezado.Controls.Add(Me.btnGuardar)
        Me.rgbEncabezado.Controls.Add(Me.txtDocumentoPago)
        Me.rgbEncabezado.Controls.Add(Me.lblDocumentoPago)
        Me.rgbEncabezado.Controls.Add(Me.txtdocumentoboleta)
        Me.rgbEncabezado.Controls.Add(Me.lbldocumentoboleta)
        Me.rgbEncabezado.Controls.Add(Me.txtdocumentofactura)
        Me.rgbEncabezado.Controls.Add(Me.lbldocumentofactura)
        Me.rgbEncabezado.FooterImageIndex = -1
        Me.rgbEncabezado.FooterImageKey = ""
        Me.rgbEncabezado.HeaderImageIndex = -1
        Me.rgbEncabezado.HeaderImageKey = ""
        Me.rgbEncabezado.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbEncabezado.HeaderText = ""
        Me.rgbEncabezado.Location = New System.Drawing.Point(2, 69)
        Me.rgbEncabezado.Name = "rgbEncabezado"
        Me.rgbEncabezado.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbEncabezado.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbEncabezado.Size = New System.Drawing.Size(581, 123)
        Me.rgbEncabezado.TabIndex = 102
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(117, 48)
        Me.pnlBarra.TabIndex = 106
        '
        'pnx0Salir
        '
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(6, 5)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 117
        '
        'lbl0Salir
        '
        Me.lbl0Salir.AutoSize = True
        Me.lbl0Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Salir.ForeColor = System.Drawing.Color.White
        Me.lbl0Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Salir.Name = "lbl0Salir"
        Me.lbl0Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl0Salir.TabIndex = 72
        Me.lbl0Salir.Text = "Salir"
        '
        'pbx0Salir
        '
        Me.pbx0Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx0Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Salir.Name = "pbx0Salir"
        Me.pbx0Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Salir.TabIndex = 71
        Me.pbx0Salir.TabStop = False
        '
        'txtdocumentoboleta
        '
        Me.txtdocumentoboleta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtdocumentoboleta.Location = New System.Drawing.Point(184, 59)
        Me.txtdocumentoboleta.Name = "txtdocumentoboleta"
        Me.txtdocumentoboleta.Size = New System.Drawing.Size(180, 22)
        Me.txtdocumentoboleta.TabIndex = 193
        '
        'lbldocumentoboleta
        '
        Me.lbldocumentoboleta.AutoSize = True
        Me.lbldocumentoboleta.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbldocumentoboleta.Location = New System.Drawing.Point(68, 62)
        Me.lbldocumentoboleta.Name = "lbldocumentoboleta"
        Me.lbldocumentoboleta.Size = New System.Drawing.Size(110, 13)
        Me.lbldocumentoboleta.TabIndex = 194
        Me.lbldocumentoboleta.Text = "Documento Boleta :"
        '
        'txtdocumentofactura
        '
        Me.txtdocumentofactura.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtdocumentofactura.Location = New System.Drawing.Point(184, 32)
        Me.txtdocumentofactura.Name = "txtdocumentofactura"
        Me.txtdocumentofactura.Size = New System.Drawing.Size(180, 22)
        Me.txtdocumentofactura.TabIndex = 191
        '
        'lbldocumentofactura
        '
        Me.lbldocumentofactura.AutoSize = True
        Me.lbldocumentofactura.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lbldocumentofactura.Location = New System.Drawing.Point(63, 35)
        Me.lbldocumentofactura.Name = "lbldocumentofactura"
        Me.lbldocumentofactura.Size = New System.Drawing.Size(115, 13)
        Me.lbldocumentofactura.TabIndex = 192
        Me.lbldocumentofactura.Text = "Documento Factura :"
        '
        'txtDocumentoPago
        '
        Me.txtDocumentoPago.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtDocumentoPago.Location = New System.Drawing.Point(184, 87)
        Me.txtDocumentoPago.Name = "txtDocumentoPago"
        Me.txtDocumentoPago.Size = New System.Drawing.Size(180, 22)
        Me.txtDocumentoPago.TabIndex = 195
        '
        'lblDocumentoPago
        '
        Me.lblDocumentoPago.AutoSize = True
        Me.lblDocumentoPago.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumentoPago.Location = New System.Drawing.Point(68, 90)
        Me.lblDocumentoPago.Name = "lblDocumentoPago"
        Me.lblDocumentoPago.Size = New System.Drawing.Size(104, 13)
        Me.lblDocumentoPago.TabIndex = 196
        Me.lblDocumentoPago.Text = "Documento Pago :"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(431, 40)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(119, 55)
        Me.btnGuardar.TabIndex = 197
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmDocumentosPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(584, 192)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rgbEncabezado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDocumentosPagos"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rgbEncabezado, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbEncabezado.ResumeLayout(False)
        Me.rgbEncabezado.PerformLayout()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rgbEncabezado As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents txtDocumentoPago As System.Windows.Forms.TextBox
    Friend WithEvents lblDocumentoPago As System.Windows.Forms.Label
    Friend WithEvents txtdocumentoboleta As System.Windows.Forms.TextBox
    Friend WithEvents lbldocumentoboleta As System.Windows.Forms.Label
    Friend WithEvents txtdocumentofactura As System.Windows.Forms.TextBox
    Friend WithEvents lbldocumentofactura As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button

End Class
