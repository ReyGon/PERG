﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaPequeniaTransporteLista
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
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCommandColumn3 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Dim GridViewCommandColumn4 As Telerik.WinControls.UI.GridViewCommandColumn = New Telerik.WinControls.UI.GridViewCommandColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaPequeniaTransporteLista))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Agregar = New System.Windows.Forms.Panel()
        Me.pbx0Agregar = New System.Windows.Forms.PictureBox()
        Me.lbl0Agregar = New System.Windows.Forms.Label()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.rgbTransporteLista = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdTransportes = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Agregar.SuspendLayout()
        CType(Me.pbx0Agregar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbTransporteLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbTransporteLista.SuspendLayout()
        CType(Me.grdTransportes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTransportes.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Agregar)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, -3)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(310, 51)
        Me.pnlBarra.TabIndex = 191
        '
        'pnx0Agregar
        '
        Me.pnx0Agregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Agregar.BackColor = System.Drawing.Color.Navy
        Me.pnx0Agregar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Agregar.Controls.Add(Me.pbx0Agregar)
        Me.pnx0Agregar.Controls.Add(Me.lbl0Agregar)
        Me.pnx0Agregar.Location = New System.Drawing.Point(80, 6)
        Me.pnx0Agregar.Name = "pnx0Agregar"
        Me.pnx0Agregar.Size = New System.Drawing.Size(106, 40)
        Me.pnx0Agregar.TabIndex = 91
        '
        'pbx0Agregar
        '
        Me.pbx0Agregar.Image = Global.laFuente.My.Resources.Resources.agregar_Blanco
        Me.pbx0Agregar.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Agregar.Name = "pbx0Agregar"
        Me.pbx0Agregar.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Agregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Agregar.TabIndex = 69
        Me.pbx0Agregar.TabStop = False
        '
        'lbl0Agregar
        '
        Me.lbl0Agregar.AutoSize = True
        Me.lbl0Agregar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Agregar.ForeColor = System.Drawing.Color.White
        Me.lbl0Agregar.Location = New System.Drawing.Point(43, 9)
        Me.lbl0Agregar.Name = "lbl0Agregar"
        Me.lbl0Agregar.Size = New System.Drawing.Size(65, 19)
        Me.lbl0Agregar.TabIndex = 70
        Me.lbl0Agregar.Text = "Agregar"
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(192, 7)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(106, 40)
        Me.pnx1Salir.TabIndex = 90
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar_blanco32
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 69
        Me.pbx1Salir.TabStop = False
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(43, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 70
        Me.lbl1Salir.Text = "Salir"
        '
        'rgbTransporteLista
        '
        Me.rgbTransporteLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbTransporteLista.Controls.Add(Me.grdTransportes)
        Me.rgbTransporteLista.FooterImageIndex = -1
        Me.rgbTransporteLista.FooterImageKey = ""
        Me.rgbTransporteLista.HeaderImageIndex = -1
        Me.rgbTransporteLista.HeaderImageKey = ""
        Me.rgbTransporteLista.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbTransporteLista.HeaderText = "Lista de Transportes"
        Me.rgbTransporteLista.Location = New System.Drawing.Point(12, 54)
        Me.rgbTransporteLista.Name = "rgbTransporteLista"
        Me.rgbTransporteLista.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbTransporteLista.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbTransporteLista.Size = New System.Drawing.Size(750, 370)
        Me.rgbTransporteLista.TabIndex = 192
        Me.rgbTransporteLista.Text = "Lista de Transportes"
        '
        'grdTransportes
        '
        Me.grdTransportes.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdTransportes.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdTransportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTransportes.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdTransportes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdTransportes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdTransportes.Location = New System.Drawing.Point(10, 20)
        '
        'grdTransportes
        '
        Me.grdTransportes.MasterTemplate.AllowAddNewRow = False
        Me.grdTransportes.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn9.HeaderText = "idMetodoCosteo"
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.Name = "idMetodoCosteo"
        GridViewTextBoxColumn9.Width = 106
        GridViewTextBoxColumn10.HeaderText = "idSectorTransporte"
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.Name = "idSectorTransporte"
        GridViewTextBoxColumn10.Width = 81
        GridViewTextBoxColumn11.HeaderText = "Metodo Costeo"
        GridViewTextBoxColumn11.Name = "metodoCosteo"
        GridViewTextBoxColumn11.Width = 151
        GridViewTextBoxColumn12.HeaderText = "Sector"
        GridViewTextBoxColumn12.Name = "sector"
        GridViewTextBoxColumn12.Width = 102
        GridViewTextBoxColumn13.HeaderText = "Direccion"
        GridViewTextBoxColumn13.Name = "direccion"
        GridViewTextBoxColumn13.Width = 68
        GridViewTextBoxColumn14.HeaderText = "Precio"
        GridViewTextBoxColumn14.Name = "precio"
        GridViewTextBoxColumn14.Width = 65
        GridViewTextBoxColumn15.HeaderText = "Cantidad"
        GridViewTextBoxColumn15.Name = "cantidad"
        GridViewTextBoxColumn15.Width = 60
        GridViewTextBoxColumn16.HeaderText = "Observacion"
        GridViewTextBoxColumn16.Name = "observacion"
        GridViewTextBoxColumn16.Width = 153
        GridViewCommandColumn3.HeaderText = "Editar"
        GridViewCommandColumn3.Name = "editar"
        GridViewCommandColumn3.Width = 60
        GridViewCommandColumn4.HeaderText = "Eliminar"
        GridViewCommandColumn4.Name = "eliminar"
        GridViewCommandColumn4.Width = 60
        Me.grdTransportes.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewCommandColumn3, GridViewCommandColumn4})
        Me.grdTransportes.Name = "grdTransportes"
        Me.grdTransportes.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTransportes.ReadOnly = True
        Me.grdTransportes.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.grdTransportes.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grdTransportes.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdTransportes.Size = New System.Drawing.Size(730, 340)
        Me.grdTransportes.TabIndex = 0
        Me.grdTransportes.Text = "Lista de Transportes"
        Me.grdTransportes.ThemeName = "Office2007Black"
        '
        'frmVentaPequeniaTransporteLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(774, 436)
        Me.Controls.Add(Me.rgbTransporteLista)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVentaPequeniaTransporteLista"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbTransporteLista, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Agregar.ResumeLayout(False)
        Me.pnx0Agregar.PerformLayout()
        CType(Me.pbx0Agregar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbTransporteLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbTransporteLista.ResumeLayout(False)
        CType(Me.grdTransportes.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTransportes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents rgbTransporteLista As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdTransportes As Telerik.WinControls.UI.RadGridView
    Friend WithEvents pnx0Agregar As System.Windows.Forms.Panel
    Friend WithEvents pbx0Agregar As System.Windows.Forms.PictureBox
    Friend WithEvents lbl0Agregar As System.Windows.Forms.Label

End Class
