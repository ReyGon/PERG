﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespachoFacturaTransporteConcepto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDespachoFacturaTransporteConcepto))
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.pnx0Reporte = New System.Windows.Forms.Panel()
        Me.lbl0Reporte = New System.Windows.Forms.Label()
        Me.pbx0Reporte = New System.Windows.Forms.PictureBox()
        Me.pnx1Salir = New System.Windows.Forms.Panel()
        Me.lbl1Salir = New System.Windows.Forms.Label()
        Me.pbx1Salir = New System.Windows.Forms.PictureBox()
        Me.rgbInformacion = New Telerik.WinControls.UI.RadGroupBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblCorrelativo = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblSucursalSalida = New System.Windows.Forms.Label()
        Me.lblFechaTransporte = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.lblTransporte = New System.Windows.Forms.Label()
        Me.lblTipoTransporte = New System.Windows.Forms.Label()
        Me.lblPiloto = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rgbPordilleros = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdPordilleros = New Telerik.WinControls.UI.RadGridView()
        Me.rgbClienteProductos = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdClientesProductos = New Telerik.WinControls.UI.RadGridView()
        CType(Me.errores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnx0Reporte.SuspendLayout()
        CType(Me.pbx0Reporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnx1Salir.SuspendLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbInformacion.SuspendLayout()
        CType(Me.rgbPordilleros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbPordilleros.SuspendLayout()
        CType(Me.grdPordilleros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPordilleros.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgbClienteProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgbClienteProductos.SuspendLayout()
        CType(Me.grdClientesProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdClientesProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlBarra.Controls.Add(Me.pnx0Reporte)
        Me.pnlBarra.Controls.Add(Me.pnx1Salir)
        Me.pnlBarra.Location = New System.Drawing.Point(466, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(590, 48)
        Me.pnlBarra.TabIndex = 110
        '
        'pnx0Reporte
        '
        Me.pnx0Reporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx0Reporte.BackColor = System.Drawing.Color.Navy
        Me.pnx0Reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx0Reporte.Controls.Add(Me.lbl0Reporte)
        Me.pnx0Reporte.Controls.Add(Me.pbx0Reporte)
        Me.pnx0Reporte.Location = New System.Drawing.Point(355, 4)
        Me.pnx0Reporte.Name = "pnx0Reporte"
        Me.pnx0Reporte.Size = New System.Drawing.Size(107, 40)
        Me.pnx0Reporte.TabIndex = 178
        '
        'lbl0Reporte
        '
        Me.lbl0Reporte.AutoSize = True
        Me.lbl0Reporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl0Reporte.ForeColor = System.Drawing.Color.White
        Me.lbl0Reporte.Location = New System.Drawing.Point(44, 9)
        Me.lbl0Reporte.Name = "lbl0Reporte"
        Me.lbl0Reporte.Size = New System.Drawing.Size(63, 19)
        Me.lbl0Reporte.TabIndex = 66
        Me.lbl0Reporte.Text = "Reporte"
        '
        'pbx0Reporte
        '
        Me.pbx0Reporte.Image = Global.laFuente.My.Resources.Resources.reporte_Blanco
        Me.pbx0Reporte.Location = New System.Drawing.Point(2, 2)
        Me.pbx0Reporte.Name = "pbx0Reporte"
        Me.pbx0Reporte.Size = New System.Drawing.Size(40, 33)
        Me.pbx0Reporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx0Reporte.TabIndex = 65
        Me.pbx0Reporte.TabStop = False
        '
        'pnx1Salir
        '
        Me.pnx1Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnx1Salir.BackColor = System.Drawing.Color.Navy
        Me.pnx1Salir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnx1Salir.Controls.Add(Me.lbl1Salir)
        Me.pnx1Salir.Controls.Add(Me.pbx1Salir)
        Me.pnx1Salir.Location = New System.Drawing.Point(468, 4)
        Me.pnx1Salir.Name = "pnx1Salir"
        Me.pnx1Salir.Size = New System.Drawing.Size(107, 40)
        Me.pnx1Salir.TabIndex = 177
        '
        'lbl1Salir
        '
        Me.lbl1Salir.AutoSize = True
        Me.lbl1Salir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Salir.ForeColor = System.Drawing.Color.White
        Me.lbl1Salir.Location = New System.Drawing.Point(48, 9)
        Me.lbl1Salir.Name = "lbl1Salir"
        Me.lbl1Salir.Size = New System.Drawing.Size(39, 19)
        Me.lbl1Salir.TabIndex = 66
        Me.lbl1Salir.Text = "Salir"
        '
        'pbx1Salir
        '
        Me.pbx1Salir.Image = Global.laFuente.My.Resources.Resources.cerrar
        Me.pbx1Salir.Location = New System.Drawing.Point(2, 2)
        Me.pbx1Salir.Name = "pbx1Salir"
        Me.pbx1Salir.Size = New System.Drawing.Size(40, 33)
        Me.pbx1Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbx1Salir.TabIndex = 65
        Me.pbx1Salir.TabStop = False
        '
        'rgbInformacion
        '
        Me.rgbInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbInformacion.Controls.Add(Me.lblPrecio)
        Me.rgbInformacion.Controls.Add(Me.lblCorrelativo)
        Me.rgbInformacion.Controls.Add(Me.lblEstado)
        Me.rgbInformacion.Controls.Add(Me.lblSucursalSalida)
        Me.rgbInformacion.Controls.Add(Me.lblFechaTransporte)
        Me.rgbInformacion.Controls.Add(Me.lblObservacion)
        Me.rgbInformacion.Controls.Add(Me.lblPlacas)
        Me.rgbInformacion.Controls.Add(Me.lblTransporte)
        Me.rgbInformacion.Controls.Add(Me.lblTipoTransporte)
        Me.rgbInformacion.Controls.Add(Me.lblPiloto)
        Me.rgbInformacion.Controls.Add(Me.Label11)
        Me.rgbInformacion.Controls.Add(Me.Label10)
        Me.rgbInformacion.Controls.Add(Me.Label9)
        Me.rgbInformacion.Controls.Add(Me.Label8)
        Me.rgbInformacion.Controls.Add(Me.Label7)
        Me.rgbInformacion.Controls.Add(Me.Label6)
        Me.rgbInformacion.Controls.Add(Me.Label5)
        Me.rgbInformacion.Controls.Add(Me.Label4)
        Me.rgbInformacion.Controls.Add(Me.Label3)
        Me.rgbInformacion.Controls.Add(Me.Label2)
        Me.rgbInformacion.FooterImageIndex = -1
        Me.rgbInformacion.FooterImageKey = ""
        Me.rgbInformacion.HeaderImageIndex = -1
        Me.rgbInformacion.HeaderImageKey = ""
        Me.rgbInformacion.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbInformacion.HeaderText = "Informacion"
        Me.rgbInformacion.Location = New System.Drawing.Point(12, 54)
        Me.rgbInformacion.Name = "rgbInformacion"
        Me.rgbInformacion.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbInformacion.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbInformacion.Size = New System.Drawing.Size(676, 227)
        Me.rgbInformacion.TabIndex = 111
        Me.rgbInformacion.Text = "Informacion"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(401, 121)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(45, 17)
        Me.lblPrecio.TabIndex = 19
        Me.lblPrecio.Text = "Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCorrelativo
        '
        Me.lblCorrelativo.AutoSize = True
        Me.lblCorrelativo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrelativo.Location = New System.Drawing.Point(401, 100)
        Me.lblCorrelativo.Name = "lblCorrelativo"
        Me.lblCorrelativo.Size = New System.Drawing.Size(74, 17)
        Me.lblCorrelativo.TabIndex = 18
        Me.lblCorrelativo.Text = "Correlativo"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(401, 78)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(49, 17)
        Me.lblEstado.TabIndex = 17
        Me.lblEstado.Text = "Estado"
        '
        'lblSucursalSalida
        '
        Me.lblSucursalSalida.AutoSize = True
        Me.lblSucursalSalida.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursalSalida.Location = New System.Drawing.Point(401, 56)
        Me.lblSucursalSalida.Name = "lblSucursalSalida"
        Me.lblSucursalSalida.Size = New System.Drawing.Size(93, 17)
        Me.lblSucursalSalida.TabIndex = 16
        Me.lblSucursalSalida.Text = "SucursalSalida"
        '
        'lblFechaTransporte
        '
        Me.lblFechaTransporte.AutoSize = True
        Me.lblFechaTransporte.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaTransporte.Location = New System.Drawing.Point(401, 36)
        Me.lblFechaTransporte.Name = "lblFechaTransporte"
        Me.lblFechaTransporte.Size = New System.Drawing.Size(108, 17)
        Me.lblFechaTransporte.TabIndex = 15
        Me.lblFechaTransporte.Text = "FechaTransporte"
        '
        'lblObservacion
        '
        Me.lblObservacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.Location = New System.Drawing.Point(122, 121)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(208, 96)
        Me.lblObservacion.TabIndex = 14
        Me.lblObservacion.Text = "Observacion"
        '
        'lblPlacas
        '
        Me.lblPlacas.AutoSize = True
        Me.lblPlacas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.Location = New System.Drawing.Point(122, 100)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(45, 17)
        Me.lblPlacas.TabIndex = 13
        Me.lblPlacas.Text = "Placas"
        '
        'lblTransporte
        '
        Me.lblTransporte.AutoSize = True
        Me.lblTransporte.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransporte.Location = New System.Drawing.Point(122, 78)
        Me.lblTransporte.Name = "lblTransporte"
        Me.lblTransporte.Size = New System.Drawing.Size(73, 17)
        Me.lblTransporte.TabIndex = 12
        Me.lblTransporte.Text = "Transporte"
        '
        'lblTipoTransporte
        '
        Me.lblTipoTransporte.AutoSize = True
        Me.lblTipoTransporte.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoTransporte.Location = New System.Drawing.Point(122, 56)
        Me.lblTipoTransporte.Name = "lblTipoTransporte"
        Me.lblTipoTransporte.Size = New System.Drawing.Size(103, 17)
        Me.lblTipoTransporte.TabIndex = 11
        Me.lblTipoTransporte.Text = "Tipo Transporte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPiloto
        '
        Me.lblPiloto.AutoSize = True
        Me.lblPiloto.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiloto.Location = New System.Drawing.Point(122, 36)
        Me.lblPiloto.Name = "lblPiloto"
        Me.lblPiloto.Size = New System.Drawing.Size(43, 17)
        Me.lblPiloto.TabIndex = 10
        Me.lblPiloto.Text = "Piloto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(344, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 17)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Precio :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(340, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Estado :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(37, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 17)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Transporte :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Tipo Transporte :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(65, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Placas :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(274, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Sucursal de Salida :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(316, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Correlativo :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(279, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha Transporte :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Observacion :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Piloto :"
        '
        'rgbPordilleros
        '
        Me.rgbPordilleros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbPordilleros.Controls.Add(Me.grdPordilleros)
        Me.rgbPordilleros.FooterImageIndex = -1
        Me.rgbPordilleros.FooterImageKey = ""
        Me.rgbPordilleros.HeaderImageIndex = -1
        Me.rgbPordilleros.HeaderImageKey = ""
        Me.rgbPordilleros.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbPordilleros.HeaderText = "Pordilleros"
        Me.rgbPordilleros.Location = New System.Drawing.Point(694, 54)
        Me.rgbPordilleros.Name = "rgbPordilleros"
        Me.rgbPordilleros.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbPordilleros.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbPordilleros.Size = New System.Drawing.Size(352, 227)
        Me.rgbPordilleros.TabIndex = 112
        Me.rgbPordilleros.Text = "Pordilleros"
        '
        'grdPordilleros
        '
        Me.grdPordilleros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPordilleros.Location = New System.Drawing.Point(10, 20)
        '
        'grdPordilleros
        '
        Me.grdPordilleros.MasterTemplate.AllowAddNewRow = False
        Me.grdPordilleros.MasterTemplate.AllowColumnReorder = False
        Me.grdPordilleros.Name = "grdPordilleros"
        Me.grdPordilleros.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPordilleros.ReadOnly = True
        '
        '
        '
        Me.grdPordilleros.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdPordilleros.Size = New System.Drawing.Size(332, 197)
        Me.grdPordilleros.TabIndex = 1
        Me.grdPordilleros.Text = "Pordilleros"
        Me.grdPordilleros.ThemeName = "Office2007Black"
        '
        'rgbClienteProductos
        '
        Me.rgbClienteProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rgbClienteProductos.Controls.Add(Me.grdClientesProductos)
        Me.rgbClienteProductos.FooterImageIndex = -1
        Me.rgbClienteProductos.FooterImageKey = ""
        Me.rgbClienteProductos.HeaderImageIndex = -1
        Me.rgbClienteProductos.HeaderImageKey = ""
        Me.rgbClienteProductos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.rgbClienteProductos.HeaderText = "Clientes y Productos"
        Me.rgbClienteProductos.Location = New System.Drawing.Point(12, 287)
        Me.rgbClienteProductos.Name = "rgbClienteProductos"
        Me.rgbClienteProductos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.rgbClienteProductos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.rgbClienteProductos.Size = New System.Drawing.Size(1034, 315)
        Me.rgbClienteProductos.TabIndex = 113
        Me.rgbClienteProductos.Text = "Clientes y Productos"
        '
        'grdClientesProductos
        '
        Me.grdClientesProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesProductos.Location = New System.Drawing.Point(10, 20)
        '
        'grdClientesProductos
        '
        Me.grdClientesProductos.MasterTemplate.AllowAddNewRow = False
        Me.grdClientesProductos.MasterTemplate.AllowColumnReorder = False
        Me.grdClientesProductos.Name = "grdClientesProductos"
        Me.grdClientesProductos.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientesProductos.ReadOnly = True
        '
        '
        '
        Me.grdClientesProductos.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.grdClientesProductos.Size = New System.Drawing.Size(1014, 285)
        Me.grdClientesProductos.TabIndex = 0
        Me.grdClientesProductos.Text = "Clientes Productos"
        Me.grdClientesProductos.ThemeName = "Office2007Black"
        '
        'frmDespachoFacturaTransporteConcepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1052, 614)
        Me.Controls.Add(Me.rgbClienteProductos)
        Me.Controls.Add(Me.rgbPordilleros)
        Me.Controls.Add(Me.rgbInformacion)
        Me.Controls.Add(Me.pnlBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDespachoFacturaTransporteConcepto"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Controls.SetChildIndex(Me.pnlBarra, 0)
        Me.Controls.SetChildIndex(Me.rgbInformacion, 0)
        Me.Controls.SetChildIndex(Me.rgbPordilleros, 0)
        Me.Controls.SetChildIndex(Me.rgbClienteProductos, 0)
        CType(Me.errores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnx0Reporte.ResumeLayout(False)
        Me.pnx0Reporte.PerformLayout()
        CType(Me.pbx0Reporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnx1Salir.ResumeLayout(False)
        Me.pnx1Salir.PerformLayout()
        CType(Me.pbx1Salir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbInformacion.ResumeLayout(False)
        Me.rgbInformacion.PerformLayout()
        CType(Me.rgbPordilleros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbPordilleros.ResumeLayout(False)
        CType(Me.grdPordilleros.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPordilleros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgbClienteProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgbClienteProductos.ResumeLayout(False)
        CType(Me.grdClientesProductos.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdClientesProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBarra As System.Windows.Forms.Panel
    Friend WithEvents pnx1Salir As System.Windows.Forms.Panel
    Friend WithEvents lbl1Salir As System.Windows.Forms.Label
    Friend WithEvents pbx1Salir As System.Windows.Forms.PictureBox
    Friend WithEvents rgbInformacion As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rgbPordilleros As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdPordilleros As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rgbClienteProductos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents grdClientesProductos As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPiloto As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblCorrelativo As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblSucursalSalida As System.Windows.Forms.Label
    Friend WithEvents lblFechaTransporte As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents lblTransporte As System.Windows.Forms.Label
    Friend WithEvents lblTipoTransporte As System.Windows.Forms.Label
    Friend WithEvents pnx0Reporte As System.Windows.Forms.Panel
    Friend WithEvents lbl0Reporte As System.Windows.Forms.Label
    Friend WithEvents pbx0Reporte As System.Windows.Forms.PictureBox

End Class
