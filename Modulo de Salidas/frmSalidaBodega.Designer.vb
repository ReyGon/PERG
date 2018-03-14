<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalidaBodega
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
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Salir = New System.Windows.Forms.Panel()
        Me.lblEnvio = New System.Windows.Forms.Label()
        Me.pbReporte = New System.Windows.Forms.PictureBox()
        Me.pnx2Actualizar = New System.Windows.Forms.Panel()
        Me.pbActualizar = New System.Windows.Forms.PictureBox()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.pnx0Modificar = New System.Windows.Forms.Panel()
        Me.pbxModificar = New System.Windows.Forms.PictureBox()
        Me.lblModificar = New System.Windows.Forms.Label()
        Me.grdDatos = New Telerik.WinControls.UI.RadGridView()
        Me.BreezeExtendedTheme1 = New Telerik.WinControls.Themes.BreezeExtendedTheme()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Salir.SuspendLayout()
        CType(Me.pbReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx2Actualizar.SuspendLayout()
        CType(Me.pbActualizar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx0Modificar.SuspendLayout()
        CType(Me.pbxModificar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Salir)
        Me.pnlBarra.Controls.Add(Me.pnx2Actualizar)
        Me.pnlBarra.Controls.Add(Me.pnx0Modificar)
        Me.pnlBarra.Location = New System.Drawing.Point(348, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(471, 51)
        Me.pnlBarra.TabIndex = 79
        '
        'pnx0Salir
        '
        Me.pnx0Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx0Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Salir.Controls.Add(Me.lblEnvio)
        Me.pnx0Salir.Controls.Add(Me.pbReporte)
        Me.pnx0Salir.Location = New System.Drawing.Point(312, 4)
        Me.pnx0Salir.Name = "pnx0Salir"
        Me.pnx0Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Salir.TabIndex = 190
        '
        'lblEnvio
        '
        Me.lblEnvio.AutoSize = True
        Me.lblEnvio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnvio.ForeColor = System.Drawing.Color.White
        Me.lblEnvio.Location = New System.Drawing.Point(47, 9)
        Me.lblEnvio.Name = "lblEnvio"
        Me.lblEnvio.Size = New System.Drawing.Size(45, 19)
        Me.lblEnvio.TabIndex = 76
        Me.lblEnvio.Text = "Guias"
        '
        'pbReporte
        '
        Me.pbReporte.Image = Global.laFuente.My.Resources.Resources.upload
        Me.pbReporte.Location = New System.Drawing.Point(10, 2)
        Me.pbReporte.Name = "pbReporte"
        Me.pbReporte.Size = New System.Drawing.Size(40, 33)
        Me.pbReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbReporte.TabIndex = 75
        Me.pbReporte.TabStop = False
        '
        'pnx2Actualizar
        '
        Me.pnx2Actualizar.BackColor = System.Drawing.Color.Navy
        Me.pnx2Actualizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx2Actualizar.Controls.Add(Me.pbActualizar)
        Me.pnx2Actualizar.Controls.Add(Me.lblActualizar)
        Me.pnx2Actualizar.Location = New System.Drawing.Point(168, 6)
        Me.pnx2Actualizar.Name = "pnx2Actualizar"
        Me.pnx2Actualizar.Size = New System.Drawing.Size(125, 40)
        Me.pnx2Actualizar.TabIndex = 190
        '
        'pbActualizar
        '
        Me.pbActualizar.Image = Global.laFuente.My.Resources.Resources.refresh
        Me.pbActualizar.Location = New System.Drawing.Point(3, 2)
        Me.pbActualizar.Name = "pbActualizar"
        Me.pbActualizar.Size = New System.Drawing.Size(40, 33)
        Me.pbActualizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbActualizar.TabIndex = 66
        Me.pbActualizar.TabStop = False
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualizar.ForeColor = System.Drawing.Color.White
        Me.lblActualizar.Location = New System.Drawing.Point(43, 9)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(76, 19)
        Me.lblActualizar.TabIndex = 68
        Me.lblActualizar.Text = "Actualizar"
        '
        'pnx0Modificar
        '
        Me.pnx0Modificar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Modificar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Modificar.Controls.Add(Me.pbxModificar)
        Me.pnx0Modificar.Controls.Add(Me.lblModificar)
        Me.pnx0Modificar.Location = New System.Drawing.Point(37, 7)
        Me.pnx0Modificar.Name = "pnx0Modificar"
        Me.pnx0Modificar.Size = New System.Drawing.Size(125, 40)
        Me.pnx0Modificar.TabIndex = 190
        '
        'pbxModificar
        '
        Me.pbxModificar.Image = Global.laFuente.My.Resources.Resources.modificar_Blanco
        Me.pbxModificar.Location = New System.Drawing.Point(3, 2)
        Me.pbxModificar.Name = "pbxModificar"
        Me.pbxModificar.Size = New System.Drawing.Size(40, 33)
        Me.pbxModificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxModificar.TabIndex = 71
        Me.pbxModificar.TabStop = False
        '
        'lblModificar
        '
        Me.lblModificar.AutoSize = True
        Me.lblModificar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModificar.ForeColor = System.Drawing.Color.White
        Me.lblModificar.Location = New System.Drawing.Point(44, 9)
        Me.lblModificar.Name = "lblModificar"
        Me.lblModificar.Size = New System.Drawing.Size(74, 19)
        Me.lblModificar.TabIndex = 72
        Me.lblModificar.Text = "Modificar"
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDatos.Location = New System.Drawing.Point(2, 54)
        '
        'grdDatos
        '
        Me.grdDatos.MasterTemplate.AllowAddNewRow = False
        Me.grdDatos.MasterTemplate.AllowColumnReorder = False
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        '
        '
        '
        Me.grdDatos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdDatos.Size = New System.Drawing.Size(813, 477)
        Me.grdDatos.TabIndex = 80
        Me.grdDatos.Text = "RadGridView1"
        Me.grdDatos.ThemeName = "Office2007Black"
        '
        'frmSalidaBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(815, 532)
        Me.Controls.Add(Me.grdDatos)
        Me.Controls.Add(Me.pnlBarra)
        Me.Name = "frmSalidaBodega"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.grdDatos, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Salir.ResumeLayout(False)
        Me.pnx0Salir.PerformLayout()
        CType(Me.pbReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx2Actualizar.ResumeLayout(False)
        Me.pnx2Actualizar.PerformLayout()
        CType(Me.pbActualizar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx0Modificar.ResumeLayout(False)
        Me.pnx0Modificar.PerformLayout()
        CType(Me.pbxModificar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents pbActualizar As System.Windows.Forms.PictureBox
    Friend WithEvents grdDatos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblModificar As System.Windows.Forms.Label
    Friend WithEvents pbxModificar As System.Windows.Forms.PictureBox
    Friend WithEvents BreezeExtendedTheme1 As Telerik.WinControls.Themes.BreezeExtendedTheme
    Friend WithEvents lblEnvio As System.Windows.Forms.Label
    Friend WithEvents pbReporte As System.Windows.Forms.PictureBox
    Friend WithEvents pnx0Modificar As System.Windows.Forms.Panel
    Friend WithEvents pnx2Actualizar As System.Windows.Forms.Panel
    Friend WithEvents pnx0Salir As System.Windows.Forms.Panel

End Class
