<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario
    Inherits laFuente.frmBaseTelerik

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
        Me.rpv = New Telerik.WinControls.UI.RadPageView()
        Me.pageDatos = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkAutorizaPrecios = New System.Windows.Forms.CheckBox()
        Me.chkPrecioUltimasVentas = New System.Windows.Forms.CheckBox()
        Me.chkConfirmaPago = New System.Windows.Forms.CheckBox()
        Me.chkAutorizaVentas = New System.Windows.Forms.CheckBox()
        Me.chkModuloImpresionCorreo = New System.Windows.Forms.CheckBox()
        Me.btnCambioClave = New System.Windows.Forms.Button()
        Me.chkEditaPreciosLiquidacion = New System.Windows.Forms.CheckBox()
        Me.chkAutorizaCreditos = New System.Windows.Forms.CheckBox()
        Me.chkSuperUsuario = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.chkBloqueado = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoPrecio = New System.Windows.Forms.ComboBox()
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rpv.SuspendLayout()
        Me.pageDatos.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rgbDatos
        '
        '
        '
        '
        Me.rgbDatos.RootElement.ForeColor = System.Drawing.Color.DimGray
        Me.rgbDatos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbDatos.Size = New System.Drawing.Size(1136, 395)
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(125, 32)
        Me.lbTituloFrm.Text = "FrmBaseT"
        '
        'rpv
        '
        Me.rpv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpv.BackColor = System.Drawing.Color.White
        Me.rpv.Controls.Add(Me.pageDatos)
        Me.rpv.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.rpv.Location = New System.Drawing.Point(2, 59)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pageDatos
        Me.rpv.Size = New System.Drawing.Size(1133, 247)
        Me.rpv.TabIndex = 103
        Me.rpv.Text = "Datos"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pageDatos
        '
        Me.pageDatos.BackColor = System.Drawing.Color.White
        Me.pageDatos.Controls.Add(Me.Label1)
        Me.pageDatos.Controls.Add(Me.cmbTipoPrecio)
        Me.pageDatos.Controls.Add(Me.chkAutorizaPrecios)
        Me.pageDatos.Controls.Add(Me.chkPrecioUltimasVentas)
        Me.pageDatos.Controls.Add(Me.chkConfirmaPago)
        Me.pageDatos.Controls.Add(Me.chkAutorizaVentas)
        Me.pageDatos.Controls.Add(Me.chkModuloImpresionCorreo)
        Me.pageDatos.Controls.Add(Me.btnCambioClave)
        Me.pageDatos.Controls.Add(Me.chkEditaPreciosLiquidacion)
        Me.pageDatos.Controls.Add(Me.chkAutorizaCreditos)
        Me.pageDatos.Controls.Add(Me.chkSuperUsuario)
        Me.pageDatos.Controls.Add(Me.Label10)
        Me.pageDatos.Controls.Add(Me.cmbGrupo)
        Me.pageDatos.Controls.Add(Me.Label9)
        Me.pageDatos.Controls.Add(Me.cmbVendedor)
        Me.pageDatos.Controls.Add(Me.Label6)
        Me.pageDatos.Controls.Add(Me.txtClave)
        Me.pageDatos.Controls.Add(Me.chkBloqueado)
        Me.pageDatos.Controls.Add(Me.Label3)
        Me.pageDatos.Controls.Add(Me.Label2)
        Me.pageDatos.Controls.Add(Me.txtNombre)
        Me.pageDatos.Controls.Add(Me.txtCodigo)
        Me.pageDatos.Location = New System.Drawing.Point(10, 44)
        Me.pageDatos.Name = "pageDatos"
        Me.pageDatos.Size = New System.Drawing.Size(1112, 192)
        Me.pageDatos.Text = " Información "
        '
        'chkAutorizaPrecios
        '
        Me.chkAutorizaPrecios.AutoSize = True
        Me.chkAutorizaPrecios.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkAutorizaPrecios.Location = New System.Drawing.Point(516, 18)
        Me.chkAutorizaPrecios.Name = "chkAutorizaPrecios"
        Me.chkAutorizaPrecios.Size = New System.Drawing.Size(138, 23)
        Me.chkAutorizaPrecios.TabIndex = 34
        Me.chkAutorizaPrecios.Text = "Autoriza Precios"
        Me.chkAutorizaPrecios.UseVisualStyleBackColor = True
        '
        'chkPrecioUltimasVentas
        '
        Me.chkPrecioUltimasVentas.AutoSize = True
        Me.chkPrecioUltimasVentas.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkPrecioUltimasVentas.Location = New System.Drawing.Point(516, 154)
        Me.chkPrecioUltimasVentas.Name = "chkPrecioUltimasVentas"
        Me.chkPrecioUltimasVentas.Size = New System.Drawing.Size(172, 23)
        Me.chkPrecioUltimasVentas.TabIndex = 33
        Me.chkPrecioUltimasVentas.Text = "Precio Ultimas Ventas"
        Me.chkPrecioUltimasVentas.UseVisualStyleBackColor = True
        '
        'chkConfirmaPago
        '
        Me.chkConfirmaPago.AutoSize = True
        Me.chkConfirmaPago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkConfirmaPago.Location = New System.Drawing.Point(516, 130)
        Me.chkConfirmaPago.Name = "chkConfirmaPago"
        Me.chkConfirmaPago.Size = New System.Drawing.Size(135, 23)
        Me.chkConfirmaPago.TabIndex = 32
        Me.chkConfirmaPago.Text = "Confirma Pagos"
        Me.chkConfirmaPago.UseVisualStyleBackColor = True
        '
        'chkAutorizaVentas
        '
        Me.chkAutorizaVentas.AutoSize = True
        Me.chkAutorizaVentas.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkAutorizaVentas.Location = New System.Drawing.Point(516, 108)
        Me.chkAutorizaVentas.Name = "chkAutorizaVentas"
        Me.chkAutorizaVentas.Size = New System.Drawing.Size(132, 23)
        Me.chkAutorizaVentas.TabIndex = 31
        Me.chkAutorizaVentas.Text = "Autoriza Ventas"
        Me.chkAutorizaVentas.UseVisualStyleBackColor = True
        '
        'chkModuloImpresionCorreo
        '
        Me.chkModuloImpresionCorreo.AutoSize = True
        Me.chkModuloImpresionCorreo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkModuloImpresionCorreo.Location = New System.Drawing.Point(516, 84)
        Me.chkModuloImpresionCorreo.Name = "chkModuloImpresionCorreo"
        Me.chkModuloImpresionCorreo.Size = New System.Drawing.Size(308, 23)
        Me.chkModuloImpresionCorreo.TabIndex = 30
        Me.chkModuloImpresionCorreo.Text = "Modulo de Liquidacion, Enviar por correo"
        Me.chkModuloImpresionCorreo.UseVisualStyleBackColor = True
        '
        'btnCambioClave
        '
        Me.btnCambioClave.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCambioClave.FlatAppearance.BorderSize = 0
        Me.btnCambioClave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue
        Me.btnCambioClave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnCambioClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCambioClave.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambioClave.ForeColor = System.Drawing.Color.Transparent
        Me.btnCambioClave.Image = Global.laFuente.My.Resources.Resources.claveBlanco
        Me.btnCambioClave.Location = New System.Drawing.Point(835, 8)
        Me.btnCambioClave.Name = "btnCambioClave"
        Me.btnCambioClave.Size = New System.Drawing.Size(171, 57)
        Me.btnCambioClave.TabIndex = 6
        Me.btnCambioClave.Text = "Cambiar Clave"
        Me.btnCambioClave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCambioClave.UseVisualStyleBackColor = False
        '
        'chkEditaPreciosLiquidacion
        '
        Me.chkEditaPreciosLiquidacion.AutoSize = True
        Me.chkEditaPreciosLiquidacion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkEditaPreciosLiquidacion.Location = New System.Drawing.Point(516, 62)
        Me.chkEditaPreciosLiquidacion.Name = "chkEditaPreciosLiquidacion"
        Me.chkEditaPreciosLiquidacion.Size = New System.Drawing.Size(215, 23)
        Me.chkEditaPreciosLiquidacion.TabIndex = 29
        Me.chkEditaPreciosLiquidacion.Text = "Edita Precios en Liquidación"
        Me.chkEditaPreciosLiquidacion.UseVisualStyleBackColor = True
        '
        'chkAutorizaCreditos
        '
        Me.chkAutorizaCreditos.AutoSize = True
        Me.chkAutorizaCreditos.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkAutorizaCreditos.Location = New System.Drawing.Point(516, 39)
        Me.chkAutorizaCreditos.Name = "chkAutorizaCreditos"
        Me.chkAutorizaCreditos.Size = New System.Drawing.Size(149, 23)
        Me.chkAutorizaCreditos.TabIndex = 28
        Me.chkAutorizaCreditos.Text = "Autoriza Créditos "
        Me.chkAutorizaCreditos.UseVisualStyleBackColor = True
        '
        'chkSuperUsuario
        '
        Me.chkSuperUsuario.AutoSize = True
        Me.chkSuperUsuario.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkSuperUsuario.Location = New System.Drawing.Point(374, 166)
        Me.chkSuperUsuario.Name = "chkSuperUsuario"
        Me.chkSuperUsuario.Size = New System.Drawing.Size(122, 23)
        Me.chkSuperUsuario.TabIndex = 27
        Me.chkSuperUsuario.Text = "Super Usuario"
        Me.chkSuperUsuario.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(79, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Grupo :"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(127, 55)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(370, 21)
        Me.cmbGrupo.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(61, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Vendedor :"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(127, 82)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(370, 21)
        Me.cmbVendedor.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(4, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Clave Autorizaciones :"
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtClave.Location = New System.Drawing.Point(127, 109)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(370, 22)
        Me.txtClave.TabIndex = 16
        '
        'chkBloqueado
        '
        Me.chkBloqueado.AutoSize = True
        Me.chkBloqueado.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.chkBloqueado.Location = New System.Drawing.Point(126, 166)
        Me.chkBloqueado.Name = "chkBloqueado"
        Me.chkBloqueado.Size = New System.Drawing.Size(101, 23)
        Me.chkBloqueado.TabIndex = 12
        Me.chkBloqueado.Text = "Bloqueado"
        Me.chkBloqueado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(74, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(69, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre :"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtNombre.Location = New System.Drawing.Point(127, 29)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(370, 22)
        Me.txtNombre.TabIndex = 7
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(127, 3)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(60, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Precio : "
        '
        'cmbTipoPrecio
        '
        Me.cmbTipoPrecio.FormattingEnabled = True
        Me.cmbTipoPrecio.Location = New System.Drawing.Point(126, 137)
        Me.cmbTipoPrecio.Name = "cmbTipoPrecio"
        Me.cmbTipoPrecio.Size = New System.Drawing.Size(370, 21)
        Me.cmbTipoPrecio.TabIndex = 35
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1143, 720)
        Me.Controls.Add(Me.rpv)
        Me.Name = "frmUsuario"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.RootElement.ForeColor = System.Drawing.Color.Gray
        Me.Controls.SetChildIndex(Me.rgbDatos, 0)
        Me.Controls.SetChildIndex(Me.rpv, 0)
        CType(Me.rgbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx4Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rpv.ResumeLayout(False)
        Me.pageDatos.ResumeLayout(False)
        Me.pageDatos.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpv As Telerik.WinControls.UI.RadPageView
    Friend WithEvents pageDatos As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents chkBloqueado As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents chkEditaPreciosLiquidacion As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorizaCreditos As System.Windows.Forms.CheckBox
    Friend WithEvents chkSuperUsuario As System.Windows.Forms.CheckBox
    Friend WithEvents btnCambioClave As System.Windows.Forms.Button
    Friend WithEvents chkModuloImpresionCorreo As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorizaVentas As System.Windows.Forms.CheckBox
    Friend WithEvents chkConfirmaPago As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrecioUltimasVentas As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutorizaPrecios As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPrecio As System.Windows.Forms.ComboBox

End Class
