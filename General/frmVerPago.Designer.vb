<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVerPago))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx1Imprimir = New System.Windows.Forms.Panel()
        Me.lbl1Imprimir = New System.Windows.Forms.Label()
        Me.pbx1Imprimir = New System.Windows.Forms.PictureBox()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lbl0Salir = New System.Windows.Forms.Label()
        Me.pbx0Salir = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblTransito = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblConfirmado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblFechaConfirmado = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFechaRegistro = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCodigoPago = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.rgbCierre = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblBoletaCierre = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblDocCierre = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblFechaCierre = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbRechazo = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblRechazado = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblObservacionRechazo = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblUsuarioRechazo = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblFechaRechazo = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx1Imprimir.SuspendLayout()
        CType(Me.pbx1Imprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbCierre.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbRechazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbRechazo.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx1Imprimir)
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(337, 51)
        Me.pnlBarra.TabIndex = 128
        '
        'pnx1Imprimir
        '
        Me.pnx1Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Imprimir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Imprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Imprimir.Controls.Add(Me.lbl1Imprimir)
        Me.pnx1Imprimir.Controls.Add(Me.pbx1Imprimir)
        Me.pnx1Imprimir.Location = New System.Drawing.Point(117, 6)
        Me.pnx1Imprimir.Name = "pnx1Imprimir"
        Me.pnx1Imprimir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Imprimir.TabIndex = 197
        '
        'lbl1Imprimir
        '
        Me.lbl1Imprimir.AutoSize = True
        Me.lbl1Imprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Imprimir.ForeColor = System.Drawing.Color.White
        Me.lbl1Imprimir.Location = New System.Drawing.Point(43, 5)
        Me.lbl1Imprimir.Name = "lbl1Imprimir"
        Me.lbl1Imprimir.Size = New System.Drawing.Size(48, 30)
        Me.lbl1Imprimir.TabIndex = 72
        Me.lbl1Imprimir.Text = "Nota " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Crédito"
        Me.lbl1Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbx1Imprimir
        '
        Me.pbx1Imprimir.Image = Global.laFuente.My.Resources.Resources.entrada_Blanco
        Me.pbx1Imprimir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Imprimir.Name = "pbx1Imprimir"
        Me.pbx1Imprimir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Imprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Imprimir.TabIndex = 71
        Me.pbx1Imprimir.TabStop = False
        '
        'pnx0Salir
        '
        Me.pnx0Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lbl0Salir)
        Me.pnx0Salir.Controls.Add(Me.pbx0Salir)
        Me.pnx0Salir.Location = New System.Drawing.Point(227, 6)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 195
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
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.lblusuario)
        Me.rgbInformacion.Controls.Add(Me.Label21)
        Me.rgbInformacion.Controls.Add(Me.lblTransito)
        Me.rgbInformacion.Controls.Add(Me.Label12)
        Me.rgbInformacion.Controls.Add(Me.lblConfirmado)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.Controls.Add(Me.lblObservacion)
        Me.rgbInformacion.Controls.Add(Me.Label9)
        Me.rgbInformacion.Controls.Add(Me.lblFechaConfirmado)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.lblCP)
        Me.rgbInformacion.Controls.Add(Me.lblProveedor)
        Me.rgbInformacion.Controls.Add(Me.lblCliente)
        Me.rgbInformacion.Controls.Add(Me.lblMonto)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.lblFechaRegistro)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.lblTipoPago)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.lblDocumento)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.lblCodigoPago)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(8, 73)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(782, 232)
        Me.rgbInformacion.TabIndex = 129
        '
        'lblusuario
        '
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblusuario.ForeColor = System.Drawing.Color.Black
        Me.lblusuario.Location = New System.Drawing.Point(437, 100)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(173, 30)
        Me.lblusuario.TabIndex = 221
        Me.lblusuario.Text = "Usuario"
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DimGray
        Me.Label21.Location = New System.Drawing.Point(356, 103)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 25)
        Me.Label21.TabIndex = 220
        Me.Label21.Text = "Usuario"
        '
        'lblTransito
        '
        Me.lblTransito.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTransito.ForeColor = System.Drawing.Color.Black
        Me.lblTransito.Location = New System.Drawing.Point(442, 16)
        Me.lblTransito.Name = "lblTransito"
        Me.lblTransito.Size = New System.Drawing.Size(118, 30)
        Me.lblTransito.TabIndex = 219
        Me.lblTransito.Text = "Tipo Pago"
        Me.lblTransito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(345, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 25)
        Me.Label12.TabIndex = 218
        Me.Label12.Text = "Transito :"
        '
        'lblConfirmado
        '
        Me.lblConfirmado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblConfirmado.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmado.Location = New System.Drawing.Point(158, 135)
        Me.lblConfirmado.Name = "lblConfirmado"
        Me.lblConfirmado.Size = New System.Drawing.Size(118, 30)
        Me.lblConfirmado.TabIndex = 217
        Me.lblConfirmado.Text = "Tipo Pago"
        Me.lblConfirmado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(29, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 25)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "Confirmado :"
        '
        'lblObservacion
        '
        Me.lblObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.ForeColor = System.Drawing.Color.Black
        Me.lblObservacion.Location = New System.Drawing.Point(442, 137)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(317, 81)
        Me.lblObservacion.TabIndex = 215
        Me.lblObservacion.Text = "Monto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(307, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 25)
        Me.Label9.TabIndex = 214
        Me.Label9.Text = "Observación :"
        '
        'lblFechaConfirmado
        '
        Me.lblFechaConfirmado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaConfirmado.ForeColor = System.Drawing.Color.Black
        Me.lblFechaConfirmado.Location = New System.Drawing.Point(158, 175)
        Me.lblFechaConfirmado.Name = "lblFechaConfirmado"
        Me.lblFechaConfirmado.Size = New System.Drawing.Size(118, 43)
        Me.lblFechaConfirmado.TabIndex = 213
        Me.lblFechaConfirmado.Text = "Fecha Confirmación"
        Me.lblFechaConfirmado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(21, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 50)
        Me.Label8.TabIndex = 212
        Me.Label8.Text = "Fecha " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Confirmación :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblCP
        '
        Me.lblCP.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblCP.ForeColor = System.Drawing.Color.Black
        Me.lblCP.Location = New System.Drawing.Point(441, 43)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(328, 30)
        Me.lblCP.TabIndex = 211
        Me.lblCP.Text = "Cliente / Proveedor"
        Me.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCP.Visible = False
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProveedor.ForeColor = System.Drawing.Color.DimGray
        Me.lblProveedor.Location = New System.Drawing.Point(326, 45)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(110, 25)
        Me.lblProveedor.TabIndex = 210
        Me.lblProveedor.Text = "Proveedor :"
        Me.lblProveedor.Visible = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.DimGray
        Me.lblCliente.Location = New System.Drawing.Point(354, 47)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(82, 25)
        Me.lblCliente.TabIndex = 209
        Me.lblCliente.Text = "Cliente :"
        Me.lblCliente.Visible = False
        '
        'lblMonto
        '
        Me.lblMonto.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(437, 72)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(173, 30)
        Me.lblMonto.TabIndex = 208
        Me.lblMonto.Text = "Monto"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(356, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 25)
        Me.Label7.TabIndex = 207
        Me.Label7.Text = "Monto :"
        '
        'lblFechaRegistro
        '
        Me.lblFechaRegistro.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaRegistro.ForeColor = System.Drawing.Color.Black
        Me.lblFechaRegistro.Location = New System.Drawing.Point(156, 103)
        Me.lblFechaRegistro.Name = "lblFechaRegistro"
        Me.lblFechaRegistro.Size = New System.Drawing.Size(146, 30)
        Me.lblFechaRegistro.TabIndex = 206
        Me.lblFechaRegistro.Text = "Tipo Pago"
        Me.lblFechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(5, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 25)
        Me.Label4.TabIndex = 205
        Me.Label4.Text = "Fecha Registro :"
        '
        'lblTipoPago
        '
        Me.lblTipoPago.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPago.ForeColor = System.Drawing.Color.Black
        Me.lblTipoPago.Location = New System.Drawing.Point(156, 73)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(162, 30)
        Me.lblTipoPago.TabIndex = 204
        Me.lblTipoPago.Text = "Tipo Pago"
        Me.lblTipoPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(20, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 25)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Tipo de Pago :"
        '
        'lblDocumento
        '
        Me.lblDocumento.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblDocumento.Location = New System.Drawing.Point(156, 43)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(118, 30)
        Me.lblDocumento.TabIndex = 202
        Me.lblDocumento.Text = "Documento"
        Me.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(30, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 25)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Documento :"
        '
        'lblCodigoPago
        '
        Me.lblCodigoPago.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodigoPago.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoPago.Location = New System.Drawing.Point(156, 15)
        Me.lblCodigoPago.Name = "lblCodigoPago"
        Me.lblCodigoPago.Size = New System.Drawing.Size(118, 30)
        Me.lblCodigoPago.TabIndex = 200
        Me.lblCodigoPago.Text = "Nombre"
        Me.lblCodigoPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(88, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 25)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "Pago :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(63, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 26)
        Me.Label16.TabIndex = 195
        Me.Label16.Text = "Información"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox7.Location = New System.Drawing.Point(21, 52)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(41, 37)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 194
        Me.PictureBox7.TabStop = False
        '
        'rgbCierre
        '
        Me.rgbCierre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rgbCierre.Controls.Add(Me.lblBoletaCierre)
        Me.rgbCierre.Controls.Add(Me.Label11)
        Me.rgbCierre.Controls.Add(Me.lblDocCierre)
        Me.rgbCierre.Controls.Add(Me.Label14)
        Me.rgbCierre.Controls.Add(Me.lblFechaCierre)
        Me.rgbCierre.Controls.Add(Me.Label17)
        Me.rgbCierre.FooterImageIndex = -1
        Me.rgbCierre.FooterImageKey = ""
        Me.rgbCierre.HeaderImageIndex = -1
        Me.rgbCierre.HeaderImageKey = ""
        Me.rgbCierre.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbCierre.HeaderText = ""
        Me.rgbCierre.Location = New System.Drawing.Point(8, 338)
        Me.rgbCierre.Name = "rgbCierre"
        Me.rgbCierre.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbCierre.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbCierre.Size = New System.Drawing.Size(383, 169)
        Me.rgbCierre.TabIndex = 196
        '
        'lblBoletaCierre
        '
        Me.lblBoletaCierre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblBoletaCierre.ForeColor = System.Drawing.Color.Black
        Me.lblBoletaCierre.Location = New System.Drawing.Point(137, 82)
        Me.lblBoletaCierre.Name = "lblBoletaCierre"
        Me.lblBoletaCierre.Size = New System.Drawing.Size(237, 30)
        Me.lblBoletaCierre.TabIndex = 231
        Me.lblBoletaCierre.Text = "Boleta Cierre"
        Me.lblBoletaCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(55, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 25)
        Me.Label11.TabIndex = 230
        Me.Label11.Text = "Boleta :"
        '
        'lblDocCierre
        '
        Me.lblDocCierre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocCierre.ForeColor = System.Drawing.Color.Black
        Me.lblDocCierre.Location = New System.Drawing.Point(137, 53)
        Me.lblDocCierre.Name = "lblDocCierre"
        Me.lblDocCierre.Size = New System.Drawing.Size(118, 30)
        Me.lblDocCierre.TabIndex = 229
        Me.lblDocCierre.Text = "Doc Cierre"
        Me.lblDocCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(8, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(123, 25)
        Me.Label14.TabIndex = 228
        Me.Label14.Text = "Documento :"
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaCierre.ForeColor = System.Drawing.Color.Black
        Me.lblFechaCierre.Location = New System.Drawing.Point(137, 26)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(118, 30)
        Me.lblFechaCierre.TabIndex = 227
        Me.lblFechaCierre.Text = "Fecha Cierre"
        Me.lblFechaCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DimGray
        Me.Label17.Location = New System.Drawing.Point(59, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 25)
        Me.Label17.TabIndex = 226
        Me.Label17.Text = "Fecha :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(63, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 26)
        Me.Label6.TabIndex = 198
        Me.Label6.Text = "Cierre de Caja"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.laFuente.My.Resources.Resources.cajaNegro32
        Me.PictureBox3.Location = New System.Drawing.Point(21, 320)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(41, 37)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 197
        Me.PictureBox3.TabStop = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(471, 325)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 26)
        Me.Label13.TabIndex = 201
        Me.Label13.Text = "Rechazo"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.cerrarNegro32
        Me.PictureBox4.Location = New System.Drawing.Point(429, 320)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 37)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 200
        Me.PictureBox4.TabStop = False
        '
        'rgbRechazo
        '
        Me.rgbRechazo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbRechazo.Controls.Add(Me.lblRechazado)
        Me.rgbRechazo.Controls.Add(Me.Label19)
        Me.rgbRechazo.Controls.Add(Me.lblObservacionRechazo)
        Me.rgbRechazo.Controls.Add(Me.Label18)
        Me.rgbRechazo.Controls.Add(Me.lblUsuarioRechazo)
        Me.rgbRechazo.Controls.Add(Me.Label20)
        Me.rgbRechazo.Controls.Add(Me.lblFechaRechazo)
        Me.rgbRechazo.Controls.Add(Me.Label22)
        Me.rgbRechazo.FooterImageIndex = -1
        Me.rgbRechazo.FooterImageKey = ""
        Me.rgbRechazo.HeaderImageIndex = -1
        Me.rgbRechazo.HeaderImageKey = ""
        Me.rgbRechazo.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbRechazo.HeaderText = ""
        Me.rgbRechazo.Location = New System.Drawing.Point(406, 338)
        Me.rgbRechazo.Name = "rgbRechazo"
        Me.rgbRechazo.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbRechazo.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbRechazo.Size = New System.Drawing.Size(382, 169)
        Me.rgbRechazo.TabIndex = 199
        '
        'lblRechazado
        '
        Me.lblRechazado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRechazado.ForeColor = System.Drawing.Color.Black
        Me.lblRechazado.Location = New System.Drawing.Point(142, 21)
        Me.lblRechazado.Name = "lblRechazado"
        Me.lblRechazado.Size = New System.Drawing.Size(118, 25)
        Me.lblRechazado.TabIndex = 233
        Me.lblRechazado.Text = "Rechazado"
        Me.lblRechazado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(26, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 25)
        Me.Label19.TabIndex = 232
        Me.Label19.Text = "Rechazado :"
        '
        'lblObservacionRechazo
        '
        Me.lblObservacionRechazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObservacionRechazo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacionRechazo.ForeColor = System.Drawing.Color.Black
        Me.lblObservacionRechazo.Location = New System.Drawing.Point(143, 93)
        Me.lblObservacionRechazo.Name = "lblObservacionRechazo"
        Me.lblObservacionRechazo.Size = New System.Drawing.Size(227, 69)
        Me.lblObservacionRechazo.TabIndex = 231
        Me.lblObservacionRechazo.Text = "Observación"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(13, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(129, 25)
        Me.Label18.TabIndex = 230
        Me.Label18.Text = "Observación :"
        '
        'lblUsuarioRechazo
        '
        Me.lblUsuarioRechazo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsuarioRechazo.ForeColor = System.Drawing.Color.Black
        Me.lblUsuarioRechazo.Location = New System.Drawing.Point(142, 64)
        Me.lblUsuarioRechazo.Name = "lblUsuarioRechazo"
        Me.lblUsuarioRechazo.Size = New System.Drawing.Size(151, 30)
        Me.lblUsuarioRechazo.TabIndex = 229
        Me.lblUsuarioRechazo.Text = "Usuario Rechazo"
        Me.lblUsuarioRechazo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DimGray
        Me.Label20.Location = New System.Drawing.Point(54, 67)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 25)
        Me.Label20.TabIndex = 228
        Me.Label20.Text = "Usuario :"
        '
        'lblFechaRechazo
        '
        Me.lblFechaRechazo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaRechazo.ForeColor = System.Drawing.Color.Black
        Me.lblFechaRechazo.Location = New System.Drawing.Point(143, 44)
        Me.lblFechaRechazo.Name = "lblFechaRechazo"
        Me.lblFechaRechazo.Size = New System.Drawing.Size(150, 24)
        Me.lblFechaRechazo.TabIndex = 227
        Me.lblFechaRechazo.Text = "Fecha Rechazo"
        Me.lblFechaRechazo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DimGray
        Me.Label22.Location = New System.Drawing.Point(69, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 25)
        Me.Label22.TabIndex = 226
        Me.Label22.Text = "Fecha :"
        '
        'frmVerPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(800, 519)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.rgbRechazo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.rgbCierre)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVerPago"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox7, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.rgbCierre, 0)
        Me.Controls.SetChildIndex(Me.PictureBox3, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.rgbRechazo, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx1Imprimir.ResumeLayout(False)
        Me.pnx1Imprimir.PerformLayout()
        CType(Me.pbx1Imprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbx0Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbCierre.ResumeLayout(False)
        Me.rgbCierre.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbRechazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbRechazo.ResumeLayout(False)
        Me.rgbRechazo.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl0Salir As System.Windows.Forms.Label
    Friend WithEvents pbx0Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTipoPago As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCodigoPago As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblTransito As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblConfirmado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFechaConfirmado As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rgbCierre As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblBoletaCierre As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDocCierre As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbRechazo As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents lblObservacionRechazo As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioRechazo As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblFechaRechazo As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblRechazado As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pnx1Imprimir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Imprimir As System.Windows.Forms.Label
    Friend WithEvents pbx1Imprimir As System.Windows.Forms.PictureBox

End Class
