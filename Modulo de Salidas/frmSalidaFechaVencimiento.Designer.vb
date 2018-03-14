<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalidaFechaVencimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalidaFechaVencimiento))
        Me.lblAgregar = New System.Windows.Forms.Label()
        Me.pbAgregar = New System.Windows.Forms.PictureBox()
        Me.calendario = New Telerik.WinControls.UI.RadCalendar()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.calendario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTituloFrm
        '
        Me.lbTituloFrm.Size = New System.Drawing.Size(226, 32)
        Me.lbTituloFrm.Text = "FrmBaseEspeciales"
        '
        'lblAgregar
        '
        Me.lblAgregar.AutoSize = True
        Me.lblAgregar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregar.ForeColor = System.Drawing.Color.DimGray
        Me.lblAgregar.Location = New System.Drawing.Point(128, 269)
        Me.lblAgregar.Name = "lblAgregar"
        Me.lblAgregar.Size = New System.Drawing.Size(65, 19)
        Me.lblAgregar.TabIndex = 84
        Me.lblAgregar.Text = "Agregar"
        '
        'pbAgregar
        '
        Me.pbAgregar.Image = Global.laFuente.My.Resources.Resources.info_gris
        Me.pbAgregar.Location = New System.Drawing.Point(89, 261)
        Me.pbAgregar.Name = "pbAgregar"
        Me.pbAgregar.Size = New System.Drawing.Size(40, 33)
        Me.pbAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbAgregar.TabIndex = 83
        Me.pbAgregar.TabStop = False
        '
        'calendario
        '
        Me.calendario.CellAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.calendario.Culture = New System.Globalization.CultureInfo("es-GT")
        Me.calendario.FastNavigationNextImage = CType(resources.GetObject("calendario.FastNavigationNextImage"), System.Drawing.Image)
        Me.calendario.FastNavigationPrevImage = CType(resources.GetObject("calendario.FastNavigationPrevImage"), System.Drawing.Image)
        Me.calendario.HeaderHeight = 17
        Me.calendario.HeaderWidth = 17
        Me.calendario.Location = New System.Drawing.Point(16, 54)
        Me.calendario.Name = "calendario"
        Me.calendario.NavigationNextImage = CType(resources.GetObject("calendario.NavigationNextImage"), System.Drawing.Image)
        Me.calendario.NavigationPrevImage = CType(resources.GetObject("calendario.NavigationPrevImage"), System.Drawing.Image)
        Me.calendario.RangeMaxDate = New Date(2099, 12, 30, 0, 0, 0, 0)
        Me.calendario.SelectedDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.calendario.Size = New System.Drawing.Size(257, 197)
        Me.calendario.TabIndex = 85
        Me.calendario.Text = "RadCalendar1"
        Me.calendario.TitleAlign = System.Windows.Forms.VisualStyles.ContentAlignment.Center
        '
        'frmSalidaFechaVencimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(285, 312)
        Me.Controls.Add(Me.calendario)
        Me.Controls.Add(Me.lblAgregar)
        Me.Controls.Add(Me.pbAgregar)
        Me.Name = "frmSalidaFechaVencimiento"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pbAgregar, 0)
        Me.Controls.SetChildIndex(Me.lblAgregar, 0)
        Me.Controls.SetChildIndex(Me.calendario, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.calendario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAgregar As System.Windows.Forms.Label
    Friend WithEvents pbAgregar As System.Windows.Forms.PictureBox
    Friend WithEvents calendario As Telerik.WinControls.UI.RadCalendar

End Class
