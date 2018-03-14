Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Drawing
Imports System.ComponentModel
Imports System.Linq
Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Net.Mail
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmDocumentosSalida

    Dim r As New clsReporte

    Private _grd As Telerik.WinControls.UI.RadGridView

    Public Property grd() As Telerik.WinControls.UI.RadGridView
        Get
            grd = _grd
        End Get
        Set(ByVal value As Telerik.WinControls.UI.RadGridView)
            _grd = value
        End Set
    End Property

    Private _tabla As DataTable

    Public Property tabla() As DataTable
        Get
            tabla = _tabla
        End Get
        Set(ByVal value As DataTable)
            _tabla = value
        End Set
    End Property

    Private _tablaPicking As DataTable

    Public Property tablaPicking() As DataTable
        Get
            tablaPicking = _tablaPicking
        End Get
        Set(ByVal value As DataTable)
            _tablaPicking = value
        End Set
    End Property

    Private _tablaCodigo As DataTable

    Public Property tablaCodigo() As DataTable
        Get
            tablaCodigo = _tablaCodigo
        End Get
        Set(ByVal value As DataTable)
            _tablaCodigo = value
        End Set
    End Property


    Private _codigoFactura As Integer

    Public Property codigoFactura() As Integer
        Get
            codigoFactura = _codigoFactura
        End Get
        Set(value As Integer)
            _codigoFactura = value
        End Set
    End Property



    Private _codigo As Integer

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set

    End Property

    Private _bitCliente As Boolean

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property


    Private _bitListaCombo As Boolean
    Public Property bitListaCombo() As Boolean
        Get
            bitListaCombo = _bitListaCombo
        End Get
        Set(ByVal value As Boolean)
            _bitListaCombo = value
        End Set
    End Property


    'bitGenerico: si es falso, quiere decir que recibe un reporteBase para mostrarlo en el visor.
    Private _bitGenerico As Boolean

    Public Property bitGenerico() As Boolean
        Get
            bitGenerico = _bitGenerico
        End Get
        Set(ByVal value As Boolean)
            _bitGenerico = value
        End Set

    End Property


    Private _bitImg As Boolean

    Public Property bitImg() As Boolean
        Get
            bitImg = _bitImg
        End Get
        Set(ByVal value As Boolean)
            _bitImg = value
        End Set

    End Property


    Private _ListaCombo As String

    Public Property ListaCombo() As String
        Get
            ListaCombo = _ListaCombo
        End Get
        Set(ByVal value As String)
            _ListaCombo = value
        End Set

    End Property


    Private _UrlImagen As String

    Public Property UrlImagen() As String
        Get
            UrlImagen = _UrlImagen
        End Get
        Set(ByVal value As String)
            _UrlImagen = value
        End Set

    End Property

    Public reporteBase As ReportDocument
    'es el reporte que se usa para las lista y GRD.
    Dim reporteGenerico As New rptReporte

    Dim reporte As New clsReporte

    Private Sub frmDocumentosSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenar_ImpresorasSistema_combo(cmbImpresora)
        Try
            If bitCliente = True Then
                fnllenar_ClienteCorreo()
            Else
                lblClave.Text = ""
                lblCliente.Text = ""
                txtCorreo.Text = ""
            End If

        Catch ex As Exception
        End Try

        If bitImg = True Then

            pbxImagen.Dock = DockStyle.Fill
            pbxImagen.Visible = True
            crVisor.Visible = False

            'ocultar
            lblFormato.Visible = False
            rgbFormato.Visible = False
            pbxFormato.Visible = False
            cmbFormato.Visible = False

            'Nueva Posicion.
            lblTitulo.Location = New Point(52, 153)
            rgbTitulo.Location = New Point(5, 168)
            pbxTitulo.Location = New Point(17, 150)

            'nuevo tamaño
            rgbTitulo.Size = New Size(380, 65)

            Dim picture = New Bitmap(UrlImagen)
            With pbxImagen
                .Image = picture
                .SizeMode = PictureBoxSizeMode.StretchImage
                .BorderStyle = BorderStyle.Fixed3D
            End With


            'OCULTAR el panel de datos.
            rgbDatos.Visible = False
            pbxDatos.Visible = False
            lblDatos.Visible = False
            lblContador.Visible = False

            'AJUSTAR TAMAÑO.
            rgbVistaPrevia.Size = New Size(730, 495)

            'nueva posicion de vista previa
            rgbVistaPrevia.Location = New Point(394, 91)
            pbxVistaPrevia.Location = New Point(405, 66)
            lblVistaPrevia.Location = New Point(444, 68)

            'deshabilitar impresion
            chkImprimir.Enabled = False
            cmbImpresora.Enabled = False

        ElseIf bitGenerico = False Then

            'UTILIZADO PARA REPORTES PRE-CARGADOS.

            If bitListaCombo = True Then

                mdlPublicVars.comboActivarFiltroLista(cmbFormato)

                'REPORTES PRE-CARGADOS DE SALIDA.
                Dim tblReporte As New DataTable
                tblReporte.Columns.Add("Codigo")
                tblReporte.Columns.Add("Nombre")

                Dim listaReportes As String() = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory())
                Dim direccion As String()
                Dim NombreArchivo As String
                'Recorremos el arreglo con catalogos
                For i As Integer = 0 To UBound(listaReportes)
                    direccion = Split(listaReportes(i), "\")
                    NombreArchivo = direccion(UBound(direccion))
                    If NombreArchivo.Split("_").Length = 2 Then
                        Dim ARRAY() As String = NombreArchivo.Split("_")
                        If ARRAY(0).Equals(ListaCombo) Then
                            tblReporte.Rows.Add(listaReportes(i), NombreArchivo)
                        End If
                    End If

                Next

                With cmbFormato
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = tblReporte
                End With

                'OCULTAR/MOSTRAR FORMATOS.
                cmbFormato.Visible = True
                rbnExcel.Visible = False
                rbnPDF.Visible = False
            Else
                'OCULTAR/MOSTRAR FORMATOS.
                cmbFormato.Visible = False
                rbnExcel.Visible = True
                rbnPDF.Visible = True
            End If


            'MAXIMIZAR EL VISOR DE REPORTES
            crVisor.Dock = DockStyle.Fill

            'MOSTAR OCULTAR COMPONENTES
            pbxImagen.Visible = False
            crVisor.Visible = True

            'llena con los parametros el reporte base.
            fnLlenarReporteBase()

            'OCULTAR el panel de datos.
            rgbDatos.Visible = False
            pbxDatos.Visible = False
            lblDatos.Visible = False
            lblContador.Visible = False

            'ajustar tamaño
            rgbVistaPrevia.Size = New Size(730, 495)

            'nueva posicion de vista previa
            rgbVistaPrevia.Location = New Point(394, 91)
            pbxVistaPrevia.Location = New Point(405, 66)
            lblVistaPrevia.Location = New Point(444, 68)

        ElseIf bitGenerico = True Then

            'UTILIZADO PARA LAS LISTAS.

            crVisor.Dock = DockStyle.Fill

            'MOSTRAR/OCULTAR COMPONENTES
            pbxImagen.Visible = False
            crVisor.Visible = True
            cmbFormato.Visible = False

            'nueva posicion de vista previa
            rgbVistaPrevia.Location = New Point(681, 91)
            pbxVistaPrevia.Location = New Point(709, 56)
            lblVistaPrevia.Location = New Point(748, 58)

            'ajustar tamaño
            rgbVistaPrevia.Size = New Size(477, 491)

            'MOSTRAR el panel de datos.
            rgbDatos.Visible = True
            pbxDatos.Visible = True
            lblDatos.Visible = True
            lblContador.Visible = True

            'llenar las columans del grid de parametro en el grid para seleccionar los datos.
            Dim index
            For index = 0 To Me.grd.Columns.Count - 1
                If grd.Columns(index).name.ToString.ToLower.Contains("nombre") Or grd.Columns(index).name.ToString.ToLower.Contains("negocio") Then
                    Me.grdDatos.Rows.Add(False, grd.Columns(index).headerText.ToString, 3000, "", grd.Columns(index).name.ToString)
                ElseIf grd.Columns(index).name.ToString.ToLower.Contains("clave") Or grd.Columns(index).name.ToString.ToLower.Contains("codigo") Then
                    Me.grdDatos.Rows.Add(False, grd.Columns(index).HeaderText.ToString, 1000, "", grd.Columns(index).name.ToString)
                Else
                    Me.grdDatos.Rows.Add(False, grd.Columns(index).HeaderText.ToString, 1000, "", grd.Columns(index).name.ToString)
                End If
            Next
        End If


        'permisos de impresion.
        Dim u As tblUsuario = (From x In ctx.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault
        If u IsNot Nothing Then
            If u.superUsuario = True Then
                txtCorreo.Enabled = True
            Else
                txtCorreo.Enabled = u.ModuloImpresion_correo
            End If
        End If

        grd = fnFiltrarDatos()
    End Sub

    'FILTRAR
    Private Function fnFiltrarDatos() As RadGridView
        Try
            Dim filas As List(Of GridViewRowInfo) = (From x As GridViewRowInfo In grd.Rows.AsEnumerable Where x.Index >= 0 Select x).ToList.AsEnumerable
            Dim columnas As List(Of GridViewColumn) = (From x As GridViewColumn In grd.Columns.AsEnumerable Select x).ToList.AsEnumerable

            Dim gridView As New RadGridView
            For Each columna As GridViewColumn In columnas.AsParallel
                gridView.Columns.Add(columna.Name)
            Next
            gridView.Rows.AddRange(filas.AsEnumerable.ToArray)
            Return gridView
        Catch ex As Exception
            'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return New RadGridView
        End Try

    End Function


    Private Sub fnLlenarReporteBase()

        Dim FieldCollection = New CrystalDecisions.Shared.ParameterFields
        Dim NewField As New CrystalDecisions.Shared.ParameterField
        Dim NewParam As New CrystalDecisions.Shared.ParameterDiscreteValue
        NewParam.IsRange = True
        NewField.Name = "@filtro"
        NewParam.Value = "@filtro"
        NewField.HasCurrentValue = True
        NewField.CurrentValues.Add(NewParam)
        FieldCollection.Add(NewField)
        Me.crVisor.ParameterFieldInfo = FieldCollection
        Me.crVisor.ReportSource = reporteBase
        crVisor.Zoom(75)

    End Sub

    Private Sub fnLlenar_TamañoPapel(ByVal cmb As ComboBox)

        Dim arr As New ArrayList
        arr.Add(New AddValue("Carta", 1))
        arr.Add(New AddValue("Oficio", 2))

        cmb.DataSource = arr
        cmb.ValueMember = "Value"
        cmb.DisplayMember = "Display"
    End Sub

    Private Sub fnLlenar_OrientacionPapel(ByVal cmb As ComboBox)

        Dim arr As New ArrayList
        arr.Add(New AddValue("Vertical", 1))
        arr.Add(New AddValue("Horizontal", 2))

        cmb.DataSource = arr
        cmb.ValueMember = "Value"
        cmb.DisplayMember = "Display"
    End Sub
    'funciones genericas para modulo de impresion.

    Private Sub fnLlenar_ImpresorasSistema_combo(ByVal cmb As ComboBox)
        Dim Impresoras As String

        ' recorre las impresoras instaladas  
        For Each Impresoras In PrinterSettings.InstalledPrinters
            cmb.Items.Add(Impresoras.ToString)
        Next


        Dim printDialog1 As New PrintDialog
        cmb.Text = printDialog1.PrinterSettings.PrinterName.ToString
    End Sub

   

    Public Function fnImprimirDoc(ByVal url As String) As String

        Dim msj As String = ""
        Dim printDialog1 As New PrintDialog
        Dim impresoraAnt As String = printDialog1.PrinterSettings.PrinterName.ToString

        fnImpresoraDefault(cmbImpresora.Text)


        'Try
        '    Dim PrintPDF As New ProcessStartInfo
        '    PrintPDF.UseShellExecute = True
        '    PrintPDF.Verb = "PrintTo"
        '    PrintPDF.WindowStyle = ProcessWindowStyle.Hidden
        '    PrintPDF.Arguments = cmbImpresora.Text
        '    PrintPDF.FileName = url
        '    Process.Start(PrintPDF)
        'Catch ex As Exception
        '    msj = "No Impreso "
        'End Try


        Try
            Dim proc As New Process 
            Console.WriteLine("DocumentName Sent to Process Start is: " + url)
            proc.StartInfo.FileName = url
            proc.StartInfo.Verb = "Print"
            proc.StartInfo.CreateNoWindow = True
            proc.Start()
        Catch ex As Exception

        End Try
        'fnImpresoraDefault(impresoraAnt)

        Return msj
    End Function


    'Private Sub fnConfiguracion()

    '    If bitGenerico = True Then

    '        If cmbHorientacion.SelectedValue = 1 Then ' vertical
    '            reporteGenerico.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Portrait
    '        End If
    '        If cmbHorientacion.SelectedValue = 2 Then 'horizontal
    '            reporteGenerico.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
    '        End If
    '        If cmbTamaño.SelectedValue = 1 Then 'carta
    '            reporteGenerico.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
    '        End If
    '        If cmbTamaño.SelectedValue = 2 Then 'oficio
    '            reporteGenerico.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
    '        End If
    '    Else
    '        If cmbHorientacion.SelectedValue = 1 Then ' vertical
    '            reporteBase.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Portrait
    '        End If
    '        If cmbHorientacion.SelectedValue = 2 Then 'horizontal
    '            reporteBase.PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
    '        End If
    '        If cmbTamaño.SelectedValue = 1 Then 'carta
    '            reporteBase.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
    '        End If
    '        If cmbTamaño.SelectedValue = 2 Then 'oficio
    '            reporteBase.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
    '        End If
    '    End If




    'End Sub

    '-- FUNCIONES DE BARRA

    Private Sub fnEjecutar() Handles Me.panel1

        alerta.contenido = "Exportar !!!"
        alerta.fnErrorContenido()

        FnOpciones()

    End Sub

    Private Sub FnOpciones()

        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim tablaParametros As New DataTable

        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim archivo As String = ""
        Dim msj As String = ""


        'Variables
        Dim x As New tblImpresion
        Dim r As New clsReporte
        Dim listaCorreos As New Hashtable
        Dim tablaDatos As New DataTable
        Dim DsR As New dsReporte

        Try
            If bitGenerico = True Then

                'capturar los datos que van a ser enviados
                tablaDatos = fnDatos(DsR)

                'capturar los parametros del reporte
                tablaParametros = fnDisplayGenerico(tablaDatos)

                'mostrar los datos en el visor
                reporteGenerico.SetDataSource(tablaDatos)

                'mostrar en pantalal
                crVisor.ReportSource = reporteGenerico
                crVisor.Zoom(75)

            End If

            'GUARDAR REGISTRO EN EL SISTEMA.
            x.bitImpreso = True
            x.tipoImpresion = 5
            x.usuarioRegistro = mdlPublicVars.idUsuario
            x.fechaRegistro = fechaServidor
            x.cliente = Nothing
            x.descripcion = txtTitulo.Text
            x.url = archivo

            If bitCliente = True Then
                x.cliente = codigo
            End If

            ctx.AddTotblImpresions(x)
            ctx.SaveChanges()

            If bitImg = True Then
                x.url = UrlImagen
            ElseIf bitGenerico = False Then
                x.url = fnExportar(x.codigo, path, reporteBase, tablaParametros)
            ElseIf bitGenerico = True Then
                x.url = fnExportar(x.codigo, path, reporteGenerico, tablaParametros)
            End If


            If chkModuloImpresion.Checked = True Then
                x.bitImpreso = False
            End If

            ctx.SaveChanges()


            If chkImprimir.Checked = True Then
                msj += fnImprimirDoc(x.url)
            End If

            If chkEnviarPorCorreo.Checked = True Then

                Dim correos() As String = txtCorreo.Text.Split(",")
                Dim i
                For i = LBound(correos) To UBound(correos)
                    listaCorreos.Add(i + 1, correos(i))
                Next

                r.emailTitulo = txtTitulo.Text
                r.emailCuerpo = txtCuerpo.Text & vbCrLf & vbCrLf & "Correo enviado desde Sistema Pos DSI."
                msj += r.EnviarCorreo(listaCorreos, x.url).ToString
            End If

            'actualizamos la factura poniendo el bitImpreso como true
            'Dim factura As tblFactura = (From y In ctx.tblFacturas Where y.IdFactura = codigoFactura Select y).FirstOrDefault
            'factura.bitImpreso = True
            'ctx.SaveChanges()
           


        Catch ex As Exception

        End Try

        If Len(msj) = 0 Then
            If x.url IsNot Nothing Then

                If RadMessageBox.Show("Abrir", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Process.Start(x.url.ToString)

                End If
            Else
                alerta.contenido = "No pudo crear el reporte !!!"
                alerta.fnErrorContenido()
            End If

        Else
            alerta.contenido = msj
            alerta.fnErrorContenido()
        End If
    End Sub

    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    Private Sub fnDisplay() Handles Me.panel0
        Try
            If bitImg = False Then
                Dim tablaDatos As New DataTable
                Dim DsR As New dsReporte
                Dim tablaParametros As New DataTable

                'mostrar en pantalla
                If bitListaCombo = True Then
                    If cmbFormato.Text.Contains("Picking") Then
                        r.tabla = tablaPicking
                    ElseIf cmbFormato.Text.Contains("Codigo") Then
                        r.tabla = tablaCodigo
                    Else
                        r.tabla = tabla
                    End If
                    r.reporte = cmbFormato.Text

                    r.nombreParametro = "filtro"
                    r.parametro = "Filtro del reporte:  "
                    'asignar el reporte usado como base
                    reporteBase = r.DocumentoReporte()
                    'agregar los parametros y ver el reporte
                    fnLlenarReporteBase()
                Else
                    'capturar los datos que van a ser enviados
                    tablaDatos = fnDatos(DsR)

                    'capturar los parametros del reporte
                    tablaParametros = fnDisplayGenerico(tablaDatos)

                    'mostrar los datos en el visor
                    reporteGenerico.SetDataSource(tablaDatos)

                    'ver reportes que no sean de salida.
                    crVisor.ReportSource = reporteGenerico
                    crVisor.Zoom(75)
                End If


            ElseIf bitGenerico = False Then

                crVisor.ReportSource = reporteGenerico
                crVisor.Zoom(75)
            End If

        Catch ex As Exception
            alerta.contenido = "Error en Display"
            alerta.fnErrorContenido()

        End Try


    End Sub

    Private Function fnDatos(ByVal Dsr As DataSet) As DataTable

        'parametros que recibe, data set, grid donde estan las columnas.

        Dsr.Tables(0).Rows.Clear()

        'crear las columnas, seleccionadas del grid.
        Dim index
        Dim contador As Integer = 0
        For index = 0 To Me.grdDatos.Rows.Count - 1
            If CType(Me.grdDatos.Rows(index).Cells(0).Value, Boolean) = True Then
                contador = contador + 1
                Me.grdDatos.Rows(index).Cells("Nombre").Value = "Column" & contador
            End If
        Next

        'agregar valores de columnas seleccionadas.
        Dim col
        Dim col2
        Dim countCol As Integer = 0
        'recorrer las filas de datos.
        For index = 0 To grd.Rows.Count - 1
            countCol = 0

            'crear la fila
            Dim row As DataRow
            row = Dsr.Tables(0).NewRow()

            'recorrer el grid de datos
            For col = 0 To grd.Columns.Count - 1

                'recorrer el grid de filas seleccionadas
                For col2 = 0 To grdDatos.Rows.Count - 1
                    If grd.Columns(col).name.ToString = grdDatos.Rows(col2).Cells(4).Value.ToString And CType(grdDatos.Rows(col2).Cells(0).Value, Boolean) = True Then

                        If Me.grd.Rows(index).Cells(col).value Is Nothing Then
                            row(grdDatos.Rows(col2).Cells("Nombre").Value.ToString) = ""
                            countCol = countCol + 1
                        Else
                            row(grdDatos.Rows(col2).Cells("Nombre").Value.ToString) = Me.grd.Rows(index).Cells(col).value.ToString
                            countCol = countCol + 1
                        End If

                    End If
                Next
            Next
            Dsr.Tables(0).Rows.Add(row)
        Next


        Return Dsr.Tables(0)
    End Function

    'esta funcion retorna los parametros del reportes
    Public Function fnDisplayGenerico(ByVal tbl As DataTable) As DataTable


        Dim nombreParametro As String = "col"

        Dim tblParametros As New DataTable
        tblParametros.Columns.Add("Parametro")
        tblParametros.Columns.Add("Valor")

        Dim inicioLeft As Integer = 75
        Dim espacioLeft As Integer = 50
        Dim TituloLeft As Integer = 75


        Dim columnNo As Integer = 0
        Dim reportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim paramFields As ParameterFields

        Dim paramField As CrystalDecisions.Shared.ParameterField
        Dim paramDiscreteValue As ParameterDiscreteValue

        reportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        paramFields = New ParameterFields()


        'recorrer el grid donde estan el nombre de las columnas y generar los parametros.
        Dim contador = 0
        Dim index = 0
        For index = 0 To grdDatos.Rows.Count - 1

            If CType(Me.grdDatos.Rows(index).Cells(0).Value, Boolean) = True Then
                contador = contador + 1
                paramField = New CrystalDecisions.Shared.ParameterField()
                paramField.Name = nombreParametro & contador.ToString
                paramDiscreteValue = New ParameterDiscreteValue()
                paramDiscreteValue.Value = grdDatos.Rows(index).Cells(1).Value
                paramField.CurrentValues.Add(paramDiscreteValue)
                paramFields.Add(paramField)

                Dim detalle As CrystalDecisions.CrystalReports.Engine.FieldObject
                detalle = CType(reporteGenerico.ReportDefinition.ReportObjects.Item("Column" & contador.ToString), CrystalDecisions.CrystalReports.Engine.FieldObject)
                detalle.Width = grdDatos.Rows(index).Cells(2).Value
                detalle.Left = inicioLeft

                tblParametros.Rows.Add(nombreParametro & contador, grdDatos.Rows(index).Cells(1).Value)

                Dim Encabezado As CrystalDecisions.CrystalReports.Engine.FieldObject
                Encabezado = CType(reporteGenerico.ReportDefinition.ReportObjects.Item(nombreParametro & contador.ToString), CrystalDecisions.CrystalReports.Engine.FieldObject)
                Encabezado.Width = grdDatos.Rows(index).Cells(2).Value
                Encabezado.Left = inicioLeft

                inicioLeft = inicioLeft + grdDatos.Rows(index).Cells(2).Value + espacioLeft
            End If
        Next

        'agregar los parametros que estan fuera del total
        For index = contador + 1 To 20
            paramField = New CrystalDecisions.Shared.ParameterField()
            paramField.Name = nombreParametro & index
            paramDiscreteValue = New ParameterDiscreteValue()
            paramDiscreteValue.Value = ""
            paramField.CurrentValues.Add(paramDiscreteValue)
            paramFields.Add(paramField)
            If index <= grdDatos.RowCount - 1 Then
                inicioLeft = inicioLeft + grdDatos.Rows(index).Cells(2).Value + espacioLeft
            End If
            tblParametros.Rows.Add(nombreParametro & index, "")
        Next

        'agregar filtro de titulo.
        paramField = New CrystalDecisions.Shared.ParameterField()
        paramField.Name = "Titulo"
        paramDiscreteValue = New ParameterDiscreteValue()
        paramDiscreteValue.Value = txtTitulo.Text
        paramField.CurrentValues.Add(paramDiscreteValue)
        paramFields.Add(paramField)
        tblParametros.Rows.Add("Titulo", txtTitulo.Text)

        crVisor.ParameterFieldInfo = paramFields

        Return tblParametros
    End Function

    Public Function fnExportar(ByVal codigo As String, ByVal path As String, ByVal reporteExportar As ReportDocument, ByVal tblparametros As DataTable) As String
        Dim carpeta As String = "DocImpresion\" + mdlPublicVars.idEmpresa.ToString + "\"
        Dim archivo As String = ""
        path = path & carpeta


        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()

            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            Dim crformatTypeOpcionsXls As New ExcelFormatOptions

            If rbnExcel.Checked = True Then
                CrDiskFileDestinationOptions.DiskFileName = path & codigo.ToString & ".xls"
                archivo = CrDiskFileDestinationOptions.DiskFileName
            End If
            If rbnPDF.Checked = True Then
                CrDiskFileDestinationOptions.DiskFileName = path & codigo.ToString & ".pdf"
                archivo = CrDiskFileDestinationOptions.DiskFileName
            End If

            CrExportOptions = reporteExportar.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                If rbnPDF.Checked = True Then
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .FormatOptions = CrFormatTypeOptions
                End If
                If rbnExcel.Checked = True Then
                    .ExportFormatType = ExportFormatType.Excel
                    .FormatOptions = crformatTypeOpcionsXls
                End If
                .DestinationOptions = CrDiskFileDestinationOptions

            End With

            If bitGenerico = True Then
                Dim index
                For index = 0 To tblparametros.Rows.Count - 1
                    If reporteGenerico.ParameterFields(0).DefaultValues.Count = 0 Then
                        reporteGenerico.SetParameterValue(tblparametros.Rows(index).Item(0).ToString, tblparametros.Rows(index).Item(1).ToString)
                    End If
                Next
            End If

            reporteExportar.Export()

        Catch ex As Exception
            MsgBox(ex.ToString)
            archivo = ""
        End Try

        Return archivo

    End Function

    Private Sub grdDatos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDatos.ValueChanged
        mdlPublicVars.fngrd_contador(grdDatos, lblContador, txtCorreo, 0)
    End Sub

    Private Sub fnAgregarArroba()
        If txtCorreo.Enabled = True Then
            txtCorreo.Text = txtCorreo.Text + "@"
            txtCorreo.Focus()
            txtCorreo.SelectionStart = txtCorreo.Text.Length
            txtCorreo.Focus()
        End If

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnAgregarArroba()
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        mdlPublicVars.fnCheckbox_ActivaDesactivar(grdDatos, chkTodos.Checked)
        mdlPublicVars.fngrd_contador(grdDatos, lblContador, txtCorreo, 0)
    End Sub

    Private Sub btnActualizarCorreo_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizarCorreo.Click
        fnllenar_ClienteCorreo()
    End Sub

    Private Sub fnllenar_ClienteCorreo()
        Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault
        If cliente IsNot Nothing Then
            lblClave.Text = cliente.clave
            lblCliente.Text = cliente.Negocio
            txtCorreo.Text = cliente.email
        End If
    End Sub

    Private Sub chkImprimir_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimir.CheckedChanged

    End Sub
End Class
