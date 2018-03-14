<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptosAjustes
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
        Me.chkActualizaCosto = New System.Windows.Forms.CheckBox()
        Me.chkTraslado = New System.Windows.Forms.CheckBox()
        Me.chkAjuste = New System.Windows.Forms.CheckBox()
        Me.chkSalida = New System.Windows.Forms.CheckBox()
        Me.chkEntrada = New System.Windows.Forms.CheckBox()
        Me.chkDisminuyeInventario = New System.Windows.Forms.CheckBox()
        Me.chkAumentaInventario = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
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
        Me.rpv.Location = New System.Drawing.Point(6, 56)
        Me.rpv.Name = "rpv"
        Me.rpv.SelectedPage = Me.pageDatos
        Me.rpv.Size = New System.Drawing.Size(1133, 210)
        Me.rpv.TabIndex = 101
        Me.rpv.Text = "Datos"
        CType(Me.rpv.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll
        '
        'pageDatos
        '
        Me.pageDatos.BackColor = System.Drawing.Color.White
        Me.pageDatos.Controls.Add(Me.chkActualizaCosto)
        Me.pageDatos.Controls.Add(Me.chkTraslado)
        Me.pageDatos.Controls.Add(Me.chkAjuste)
        Me.pageDatos.Controls.Add(Me.chkSalida)
        Me.pageDatos.Controls.Add(Me.chkEntrada)
        Me.pageDatos.Controls.Add(Me.chkDisminuyeInventario)
        Me.pageDatos.Controls.Add(Me.chkAumentaInventario)
        Me.pageDatos.Controls.Add(Me.Label3)
        Me.pageDatos.Controls.Add(Me.Label2)
        Me.pageDatos.Controls.Add(Me.txtNombre)
        Me.pageDatos.Controls.Add(Me.txtCodigo)
        Me.pageDatos.Location = New System.Drawing.Point(10, 44)
        Me.pageDatos.Name = "pageDatos"
        Me.pageDatos.Size = New System.Drawing.Size(1112, 155)
        Me.pageDatos.Text = " Información "
        '
        'chkActualizaCosto
        '
        Me.chkActualizaCosto.AutoSize = True
        Me.chkActualizaCosto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActualizaCosto.Location = New System.Drawing.Point(408, 35)
        Me.chkActualizaCosto.Name = "chkActualizaCosto"
        Me.chkActualizaCosto.Size = New System.Drawing.Size(122, 21)
        Me.chkActualizaCosto.TabIndex = 14
        Me.chkActualizaCosto.Text = "Actualiza Costo"
        Me.chkActualizaCosto.UseVisualStyleBackColor = True
        '
        'chkTraslado
        '
        Me.chkTraslado.AutoSize = True
        Me.chkTraslado.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTraslado.Location = New System.Drawing.Point(230, 119)
        Me.chkTraslado.Name = "chkTraslado"
        Me.chkTraslado.Size = New System.Drawing.Size(80, 21)
        Me.chkTraslado.TabIndex = 13
        Me.chkTraslado.Text = "Traslado"
        Me.chkTraslado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTraslado.UseVisualStyleBackColor = True
        '
        'chkAjuste
        '
        Me.chkAjuste.AutoSize = True
        Me.chkAjuste.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAjuste.Location = New System.Drawing.Point(74, 119)
        Me.chkAjuste.Name = "chkAjuste"
        Me.chkAjuste.Size = New System.Drawing.Size(66, 21)
        Me.chkAjuste.TabIndex = 12
        Me.chkAjuste.Text = "Ajuste"
        Me.chkAjuste.UseVisualStyleBackColor = True
        '
        'chkSalida
        '
        Me.chkSalida.AutoSize = True
        Me.chkSalida.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSalida.Location = New System.Drawing.Point(230, 92)
        Me.chkSalida.Name = "chkSalida"
        Me.chkSalida.Size = New System.Drawing.Size(64, 21)
        Me.chkSalida.TabIndex = 11
        Me.chkSalida.Text = "Salida"
        Me.chkSalida.UseVisualStyleBackColor = True
        '
        'chkEntrada
        '
        Me.chkEntrada.AutoSize = True
        Me.chkEntrada.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEntrada.Location = New System.Drawing.Point(74, 92)
        Me.chkEntrada.Name = "chkEntrada"
        Me.chkEntrada.Size = New System.Drawing.Size(74, 21)
        Me.chkEntrada.TabIndex = 10
        Me.chkEntrada.Text = "Entrada"
        Me.chkEntrada.UseVisualStyleBackColor = True
        '
        'chkDisminuyeInventario
        '
        Me.chkDisminuyeInventario.AutoSize = True
        Me.chkDisminuyeInventario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisminuyeInventario.Location = New System.Drawing.Point(230, 65)
        Me.chkDisminuyeInventario.Name = "chkDisminuyeInventario"
        Me.chkDisminuyeInventario.Size = New System.Drawing.Size(160, 21)
        Me.chkDisminuyeInventario.TabIndex = 9
        Me.chkDisminuyeInventario.Text = "Disminuye Inventario"
        Me.chkDisminuyeInventario.UseVisualStyleBackColor = True
        '
        'chkAumentaInventario
        '
        Me.chkAumentaInventario.AutoSize = True
        Me.chkAumentaInventario.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAumentaInventario.Location = New System.Drawing.Point(74, 65)
        Me.chkAumentaInventario.Name = "chkAumentaInventario"
        Me.chkAumentaInventario.Size = New System.Drawing.Size(150, 21)
        Me.chkAumentaInventario.TabIndex = 8
        Me.chkAumentaInventario.Text = "Aumenta Inventario"
        Me.chkAumentaInventario.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(21, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre :"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtNombre.Location = New System.Drawing.Point(74, 34)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(316, 22)
        Me.txtNombre.TabIndex = 7
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(74, 8)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigo.TabIndex = 6
        '
        'frmConceptosAjustes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1143, 529)
        Me.Controls.Add(Me.rpv)
        Me.Name = "frmConceptosAjustes"
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents chkTraslado As System.Windows.Forms.CheckBox
    Friend WithEvents chkAjuste As System.Windows.Forms.CheckBox
    Friend WithEvents chkSalida As System.Windows.Forms.CheckBox
    Friend WithEvents chkEntrada As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisminuyeInventario As System.Windows.Forms.CheckBox
    Friend WithEvents chkAumentaInventario As System.Windows.Forms.CheckBox
    Friend WithEvents chkActualizaCosto As System.Windows.Forms.CheckBox

End Class
