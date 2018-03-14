<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpleados))
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pageDatos = New Telerik.WinControls.UI.RadPageViewPage()
        Me.rbtPiloto = New System.Windows.Forms.RadioButton()
        Me.rbtPordillero = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx2Eliminar = New System.Windows.Forms.Panel()
        Me.lbl2Eliminar = New System.Windows.Forms.Label()
        Me.pbx2Eliminar = New System.Windows.Forms.PictureBox()
        Me.pnx1Guardar = New System.Windows.Forms.Panel()
        Me.lbl1Guardar = New System.Windows.Forms.Label()
        Me.pbx1Guardar = New System.Windows.Forms.PictureBox()
        Me.pnx3Salir = New System.Windows.Forms.Panel()
        Me.lbl3Salir = New System.Windows.Forms.Label()
        Me.pbx3Salir = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdEmpleado = New Telerik.WinControls.UI.RadGridView()
        Me.pnx0Nuevo = New System.Windows.Forms.Panel()
        Me.lbl0Nuevo = New System.Windows.Forms.Label()
        Me.pbx0Nuevo = New System.Windows.Forms.PictureBox()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pageDatos.SuspendLayout()
        Me.pnlBarra.SuspendLayout()
        Me.pnx2Eliminar.SuspendLayout()
        CType(Me.pbx2Eliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Guardar.SuspendLayout()
        CType(Me.pbx1Guardar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx3Salir.SuspendLayout()
        CType(Me.pbx3Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.grdEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEmpleado.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Nuevo.SuspendLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'rpv
        '
        Me.rpv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpv.BackColor = System.Drawing.Color.White
        Me.rpv.Controls.Add(Me.pageDatos)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rpv.Location = New System.Drawing.Point(2, 54)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pageDatos
        Me.rpv.Size = New System.Drawing.Size(1154, 239)
        Me.rpv.TabIndex = 106
        Me.rpv.Text = "Datos"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pageDatos
        '
        Me.pageDatos.BackColor = System.Drawing.Color.White
        Me.pageDatos.Controls.Add(Me.rbtPiloto)
        Me.pageDatos.Controls.Add(Me.rbtPordillero)
        Me.pageDatos.Controls.Add(Me.Label5)
        Me.pageDatos.Controls.Add(Me.txtTelefono)
        Me.pageDatos.Controls.Add(Me.Label4)
        Me.pageDatos.Controls.Add(Me.txtDireccion)
        Me.pageDatos.Controls.Add(Me.cmbPuesto)
        Me.pageDatos.Controls.Add(Me.Label2)
        Me.pageDatos.Controls.Add(Me.Label3)
        Me.pageDatos.Controls.Add(Me.Label6)
        Me.pageDatos.Controls.Add(Me.txtNombre)
        Me.pageDatos.Controls.Add(Me.txtCodigo)
        Me.pageDatos.Location = New System.Drawing.Point(10, 44)
        Me.pageDatos.Name = "pageDatos"
        Me.pageDatos.Size = New System.Drawing.Size(1133, 184)
        Me.pageDatos.Text = " Información "
        '
        'rbtPiloto
        '
        Me.rbtPiloto.AutoSize = True
        Me.rbtPiloto.Location = New System.Drawing.Point(261, 152)
        Me.rbtPiloto.Name = "rbtPiloto"
        Me.rbtPiloto.Size = New System.Drawing.Size(74, 25)
        Me.rbtPiloto.TabIndex = 85
        Me.rbtPiloto.TabStop = True
        Me.rbtPiloto.Text = "Piloto"
        Me.rbtPiloto.UseVisualStyleBackColor = True
        '
        'rbtPordillero
        '
        Me.rbtPordillero.AutoSize = True
        Me.rbtPordillero.Location = New System.Drawing.Point(129, 152)
        Me.rbtPordillero.Name = "rbtPordillero"
        Me.rbtPordillero.Size = New System.Drawing.Size(104, 25)
        Me.rbtPordillero.TabIndex = 84
        Me.rbtPordillero.TabStop = True
        Me.rbtPordillero.Text = "Pordillero"
        Me.rbtPordillero.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(27, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Telefono :"
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtTelefono.Location = New System.Drawing.Point(87, 124)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(296, 22)
        Me.txtTelefono.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(24, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Direccion :"
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(87, 96)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(296, 22)
        Me.txtDireccion.TabIndex = 2
        '
        'cmbPuesto
        '
        Me.cmbPuesto.FormattingEnabled = True
        Me.cmbPuesto.Location = New System.Drawing.Point(87, 39)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(296, 21)
        Me.cmbPuesto.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(36, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Puesto :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(34, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(29, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Nombre :"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtNombre.Location = New System.Drawing.Point(87, 67)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(296, 22)
        Me.txtNombre.TabIndex = 1
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(87, 11)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigo.TabIndex = 6
        '
        'pnlBarra
        '
        Me.pnlBarra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBarra.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlBarra.Controls.Add(Me.pnx0Nuevo)
        Me.pnlBarra.Controls.Add(Me.pnx2Eliminar)
        Me.pnlBarra.Controls.Add(Me.pnx1Guardar)
        Me.pnlBarra.Controls.Add(Me.pnx3Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(690, 48)
        Me.pnlBarra.TabIndex = 151
        '
        'pnx2Eliminar
        '
        Me.pnx2Eliminar.BackColor = System.Drawing.Color.Navy
        Me.pnx2Eliminar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx2Eliminar.Controls.Add(Me.lbl2Eliminar)
        Me.pnx2Eliminar.Controls.Add(Me.pbx2Eliminar)
        Me.pnx2Eliminar.Location = New System.Drawing.Point(466, 5)
        Me.pnx2Eliminar.Name = "pnx2Eliminar"
        Me.pnx2Eliminar.Size = New System.Drawing.Size(115, 40)
        Me.pnx2Eliminar.TabIndex = 86
        '
        'lbl2Eliminar
        '
        Me.lbl2Eliminar.AutoSize = True
        Me.lbl2Eliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Eliminar.ForeColor = System.Drawing.Color.White
        Me.lbl2Eliminar.Location = New System.Drawing.Point(50, 12)
        Me.lbl2Eliminar.Name = "lbl2Eliminar"
        Me.lbl2Eliminar.Size = New System.Drawing.Size(51, 15)
        Me.lbl2Eliminar.TabIndex = 66
        Me.lbl2Eliminar.Text = "Eliminar"
        '
        'pbx2Eliminar
        '
        Me.pbx2Eliminar.Image = Global.laFuente.My.Resources.Resources.buscar_Blanco
        Me.pbx2Eliminar.Location = New System.Drawing.Point(9, 2)
        Me.pbx2Eliminar.Name = "pbx2Eliminar"
        Me.pbx2Eliminar.Size = New System.Drawing.Size(40, 33)
        Me.pbx2Eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx2Eliminar.TabIndex = 65
        Me.pbx2Eliminar.TabStop = False
        '
        'pnx1Guardar
        '
        Me.pnx1Guardar.BackColor = System.Drawing.Color.Navy
        Me.pnx1Guardar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Guardar.Controls.Add(Me.lbl1Guardar)
        Me.pnx1Guardar.Controls.Add(Me.pbx1Guardar)
        Me.pnx1Guardar.Location = New System.Drawing.Point(349, 4)
        Me.pnx1Guardar.Name = "pnx1Guardar"
        Me.pnx1Guardar.Size = New System.Drawing.Size(111, 40)
        Me.pnx1Guardar.TabIndex = 85
        '
        'lbl1Guardar
        '
        Me.lbl1Guardar.AutoSize = True
        Me.lbl1Guardar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Guardar.ForeColor = System.Drawing.Color.White
        Me.lbl1Guardar.Location = New System.Drawing.Point(50, 12)
        Me.lbl1Guardar.Name = "lbl1Guardar"
        Me.lbl1Guardar.Size = New System.Drawing.Size(52, 15)
        Me.lbl1Guardar.TabIndex = 66
        Me.lbl1Guardar.Text = "Guardar"
        '
        'pbx1Guardar
        '
        Me.pbx1Guardar.Image = Global.laFuente.My.Resources.Resources.guardar_Blanco
        Me.pbx1Guardar.Location = New System.Drawing.Point(9, 2)
        Me.pbx1Guardar.Name = "pbx1Guardar"
        Me.pbx1Guardar.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Guardar.TabIndex = 65
        Me.pbx1Guardar.TabStop = False
        '
        'pnx3Salir
        '
        Me.pnx3Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx3Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx3Salir.Controls.Add(Me.lbl3Salir)
        Me.pnx3Salir.Controls.Add(Me.pbx3Salir)
        Me.pnx3Salir.Location = New System.Drawing.Point(587, 4)
        Me.pnx3Salir.Name = "pnx3Salir"
        Me.pnx3Salir.Size = New System.Drawing.Size(100, 40)
        Me.pnx3Salir.TabIndex = 84
        '
        'lbl3Salir
        '
        Me.lbl3Salir.AutoSize = True
        Me.lbl3Salir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3Salir.ForeColor = System.Drawing.Color.White
        Me.lbl3Salir.Location = New System.Drawing.Point(50, 12)
        Me.lbl3Salir.Name = "lbl3Salir"
        Me.lbl3Salir.Size = New System.Drawing.Size(31, 15)
        Me.lbl3Salir.TabIndex = 66
        Me.lbl3Salir.Text = "Salir"
        '
        'pbx3Salir
        '
        Me.pbx3Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx3Salir.Location = New System.Drawing.Point(9, 2)
        Me.pbx3Salir.Name = "pbx3Salir"
        Me.pbx3Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx3Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx3Salir.TabIndex = 65
        Me.pbx3Salir.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(63, 300)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 29)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Información"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.laFuente.My.Resources.Resources.informacion
        Me.PictureBox4.Location = New System.Drawing.Point(15, 291)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(47, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 154
        Me.PictureBox4.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.BackColor = System.Drawing.Color.Transparent
        Me.rgbInformacion.Controls.Add(Me.grdEmpleado)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = "Creative player 256_green.png"
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = ""
        Me.rgbInformacion.Location = New System.Drawing.Point(2, 315)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(1154, 290)
        Me.rgbInformacion.TabIndex = 152
        Me.rgbInformacion.ThemeName = "radGroupBoxAzul"
        '
        'grdEmpleado
        '
        Me.grdEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpleado.BackColor = System.Drawing.Color.White
        Me.grdEmpleado.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdEmpleado.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdEmpleado.ForeColor = System.Drawing.Color.Gray
        Me.grdEmpleado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdEmpleado.Location = New System.Drawing.Point(13, 23)
        '
        'grdEmpleado
        '
        Me.grdEmpleado.MasterTemplate.AllowAddNewRow = False
        Me.grdEmpleado.MasterTemplate.AllowDeleteRow = False
        Me.grdEmpleado.MasterTemplate.EnableGrouping = False
        Me.grdEmpleado.Name = "grdEmpleado"
        Me.grdEmpleado.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdEmpleado.ReadOnly = True
        Me.grdEmpleado.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdEmpleado.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.grdEmpleado.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdEmpleado.Size = New System.Drawing.Size(1128, 257)
        Me.grdEmpleado.TabIndex = 212
        Me.grdEmpleado.Text = "Unidad de Medida"
        Me.grdEmpleado.ThemeName = "Office2007Black"
        '
        'pnx0Nuevo
        '
        Me.pnx0Nuevo.BackColor = System.Drawing.Color.Navy
        Me.pnx0Nuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Nuevo.Controls.Add(Me.lbl0Nuevo)
        Me.pnx0Nuevo.Controls.Add(Me.pbx0Nuevo)
        Me.pnx0Nuevo.Location = New System.Drawing.Point(232, 4)
        Me.pnx0Nuevo.Name = "pnx0Nuevo"
        Me.pnx0Nuevo.Size = New System.Drawing.Size(111, 40)
        Me.pnx0Nuevo.TabIndex = 86
        '
        'lbl0Nuevo
        '
        Me.lbl0Nuevo.AutoSize = True
        Me.lbl0Nuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Nuevo.ForeColor = System.Drawing.Color.White
        Me.lbl0Nuevo.Location = New System.Drawing.Point(50, 12)
        Me.lbl0Nuevo.Name = "lbl0Nuevo"
        Me.lbl0Nuevo.Size = New System.Drawing.Size(44, 15)
        Me.lbl0Nuevo.TabIndex = 66
        Me.lbl0Nuevo.Text = "Nuevo"
        '
        'pbx0Nuevo
        '
        Me.pbx0Nuevo.Image = Global.laFuente.My.Resources.Resources.nuevo_blanco48
        Me.pbx0Nuevo.Location = New System.Drawing.Point(9, 2)
        Me.pbx0Nuevo.Name = "pbx0Nuevo"
        Me.pbx0Nuevo.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Nuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Nuevo.TabIndex = 65
        Me.pbx0Nuevo.TabStop = False
        '
        'frmEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1160, 607)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Controls.Add(Me.rpv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmpleados"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.rpv, 0)
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.PictureBox4, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv.ResumeLayout(False)
        Me.pageDatos.ResumeLayout(False)
        Me.pageDatos.PerformLayout()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx2Eliminar.ResumeLayout(False)
        Me.pnx2Eliminar.PerformLayout()
        CType(Me.pbx2Eliminar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Guardar.ResumeLayout(False)
        Me.pnx1Guardar.PerformLayout()
        CType(Me.pbx1Guardar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx3Salir.ResumeLayout(False)
        Me.pnx3Salir.PerformLayout()
        CType(Me.pbx3Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        CType(Me.grdEmpleado.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Nuevo.ResumeLayout(False)
        Me.pnx0Nuevo.PerformLayout()
        CType(Me.pbx0Nuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pageDatos As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents rbtPiloto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPordillero As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents cmbPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx3Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl3Salir As System.Windows.Forms.Label
    Friend WithEvents pbx3Salir As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdEmpleado As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnx2Eliminar As System.Windows.Forms.Panel
    Friend WithEvents lbl2Eliminar As System.Windows.Forms.Label
    Friend WithEvents pbx2Eliminar As System.Windows.Forms.PictureBox
    Friend WithEvents pnx1Guardar As System.Windows.Forms.Panel
    Friend WithEvents lbl1Guardar As System.Windows.Forms.Label
    Friend WithEvents pbx1Guardar As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Nuevo As System.Windows.Forms.Panel
    Friend WithEvents lbl0Nuevo As System.Windows.Forms.Label
    Friend WithEvents pbx0Nuevo As System.Windows.Forms.PictureBox

End Class
