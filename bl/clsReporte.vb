Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Imports System.Linq
Imports Telerik.WinControls



Public Class clsReporte
    Private _bitDataSet As Boolean
    Private _tabla As System.Data.DataTable
    Private _reporte As System.String
    Private _nombreParametro As System.String
    Private _parametro As System.String
    Private _subReporte As String = ""
    Private _tablaSubReporte As System.Data.DataTable
    'nombre de archivo y extension
    Private _nombreArchivo As System.String
    Private _extension As System.String
    Private _emailCuerpo As System.String
    Private _emailTitulo As System.String
    Private _dataSet As System.Data.DataSet

    Public Property dataSet As DataSet
        Get
            dataSet = _dataSet
        End Get
        Set(ByVal value As DataSet)
            _dataSet = value
        End Set
    End Property

    Public Property bitDataSet As Boolean
        Get
            bitDataSet = _bitDataSet
        End Get
        Set(ByVal value As Boolean)
            _bitDataSet = value
        End Set
    End Property

    Public Property emailTitulo() As System.String
        Get
            emailTitulo = _emailTitulo
        End Get
        Set(ByVal value As System.String)
            _emailTitulo = value
        End Set
    End Property

    Public Property emailCuerpo() As System.String
        Get
            emailCuerpo = _emailCuerpo
        End Get
        Set(ByVal value As System.String)
            _emailCuerpo = value
        End Set
    End Property


    Public Property nombreArchivo() As System.String
        Get
            nombreArchivo = _nombreArchivo
        End Get
        Set(ByVal value As System.String)
            _nombreArchivo = value
        End Set
    End Property

    Public Property extension() As System.String
        Get
            extension = _extension
        End Get
        Set(ByVal value As System.String)
            _extension = value
        End Set
    End Property

    Public Property subReporte() As String
        Get
            subReporte = _subReporte
        End Get
        Set(ByVal value As String)
            _subReporte = value
        End Set
    End Property

    Public Property tablaSubReporte() As System.Data.DataTable
        Get
            tablaSubReporte = _tablaSubReporte
        End Get
        Set(ByVal value As System.Data.DataTable)
            _tablaSubReporte = value
        End Set
    End Property

    Public Property tabla() As System.Data.DataTable
        Get
            tabla = _tabla
        End Get
        Set(ByVal value As System.Data.DataTable)
            _tabla = value
        End Set
    End Property

    Public Property reporte() As System.String
        Get
            reporte = _reporte
        End Get
        Set(ByVal value As System.String)
            _reporte = value
        End Set
    End Property


    Public Property nombreParametro() As System.String
        Get
            nombreParametro = _nombreParametro
        End Get
        Set(ByVal value As System.String)
            _nombreParametro = value
        End Set
    End Property

    Public Property parametro() As System.String
        Get
            parametro = _parametro
        End Get
        Set(ByVal value As System.String)
            _parametro = value
        End Set
    End Property

    Public Function EntitiToDataTable(ByVal parIList As System.Collections.IEnumerable) As System.Data.DataTable
        Dim ret As New System.Data.DataTable()
        Try
            Dim ppi As System.Reflection.PropertyInfo() = Nothing
            If parIList Is Nothing Then Return ret

            Dim itm As System.Collections.IEnumerable
            For Each itm In parIList
                If ppi Is Nothing Then
                    ppi = DirectCast(itm.[GetType](), System.Type).GetProperties()
                    For Each pi As System.Reflection.PropertyInfo In ppi
                        Dim colType As System.Type = pi.PropertyType
                        If (colType.IsGenericType) AndAlso
                           (colType.GetGenericTypeDefinition() Is GetType(System.Nullable(Of ))) Then colType = colType.GetGenericArguments()(0)
                        ret.Columns.Add(New System.Data.DataColumn(pi.Name, colType))
                    Next
                End If
                Dim dr As System.Data.DataRow = ret.NewRow
                For Each pi As System.Reflection.PropertyInfo In ppi
                    dr(pi.Name) = If(pi.GetValue(itm, Nothing) Is Nothing, DBNull.Value, pi.GetValue(itm, Nothing))
                Next
                ret.Rows.Add(dr)
            Next
            For Each c As System.Data.DataColumn In ret.Columns
                c.ColumnName = c.ColumnName.Replace("_", " ")
            Next
        Catch ex As Exception
            ret = New System.Data.DataTable()
        End Try
        Return ret
    End Function

    Public Sub verReporte()
        'Assign the datasource and set the properties for Report viewer
        Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim rutaReporte As String
        Dim path As String
        Try
            path = System.AppDomain.CurrentDomain.BaseDirectory()
            rutaReporte = path & Me.reporte
            rptDocument.Load(rutaReporte)

            If bitDataSet Then
                rptDocument.SetDataSource(dataSet)
            Else
                rptDocument.SetDataSource(Me.tabla)
            End If

            If Me.subReporte <> "" Then
                rptDocument.Subreports(Me.subReporte).SetDataSource(Me.tablaSubReporte)
            End If

            With frmCrystalViewver
                .parametroReporteNombre = Me.nombreParametro
                .parametroReporte = Me.parametro
                .reporte = rptDocument
                .WindowState = FormWindowState.Maximized
                .BringToFront()
                .ShowDialog()
                .Dispose()
            End With

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    Public Sub imprimirReporte()
        'Assign the datasource and set the properties for Report viewer
        Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim rutaReporte As String
        Dim path As String
        Try
            path = System.AppDomain.CurrentDomain.BaseDirectory()
            rutaReporte = path & Me.reporte
            rptDocument.Load(rutaReporte)
            rptDocument.SetDataSource(Me.tabla)
            If Me.subReporte <> "" Then
                rptDocument.Subreports(Me.subReporte).SetDataSource(Me.tablaSubReporte)
            End If

            rptDocument.PrintToPrinter(1, False, 1, 1)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try

    End Sub

    'exporta el archivo de cristal reports al formato indicado.
    Public Function Exportar() As String
        nombreArchivo = nombreArchivo + "." + extension
        'Asignar propiedades del reporte view.
        Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim rutaGuardar As String = path + nombreArchivo
        Dim rutaReporte As String = path & Me.reporte

        Try
            'llenar el documento
            rptDocument.Load(rutaReporte)
            rptDocument.SetDataSource(Me.tabla)
            With rptDocument.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With


            Dim diskOpts As New DiskFileDestinationOptions

            'verifica si existe el archivo con ese nombre
            If File.Exists(nombreArchivo) Then File.Delete(nombreArchivo)
            diskOpts.DiskFileName = nombreArchivo
            rptDocument.ExportOptions.DestinationOptions = diskOpts
            rptDocument.Export()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try

        Return rutaGuardar
    End Function

    Public Function ExportarX(ByRef rpt As ReportDocument, ByVal tbl As DataTable)

        'rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Path.Combine(Application.StartupPath, "demo.pdf"))

        Dim Os As MemoryStream
        Os = DirectCast(rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), MemoryStream)
        Dim file As New FileStream("demo.rpt", FileMode.Create, FileAccess.Write)
        Os.WriteTo(file)
        file.Close()
        Os.Close()





        Return 0
    End Function

    'exporta el archivo de cristal reports al formato indicado.
    Public Function Exportar(ByVal rpt As ReportDocument, ByVal parametros As ParameterFields) As String
        nombreArchivo = nombreArchivo + "." + extension
        'Asignar propiedades del reporte view.
        Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim rutaGuardar As String = path + nombreArchivo
        Dim rutaReporte As String = path & Me.reporte

        If rpt Is Nothing Then
        Else
            rptDocument = rpt
        End If
        Try
            'llenar el documento
            rptDocument.Load(rutaReporte)
            rptDocument.SetDataSource(Me.tabla)


            With rptDocument.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With

            Dim diskOpts As New DiskFileDestinationOptions

            'verifica si existe el archivo con ese nombre
            If File.Exists(nombreArchivo) Then File.Delete(nombreArchivo)
            diskOpts.DiskFileName = nombreArchivo
            rptDocument.ExportOptions.DestinationOptions = diskOpts
            rptDocument.Export()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try

        Return rutaGuardar
    End Function


    Public Function EnviarCorreo(ByVal listaCorreos As Hashtable, ByVal url As String) As String
        Dim msj As String = ""

        Try

            Dim em As tblEmpresa = (From x In ctx.tblEmpresas
                                    Where x.idEmpresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault


            Dim correoEmpresa As String = mdlPublicVars.Empresa_Correo
            Dim clave As String = mdlPublicVars.Empresa_CorreoClave
            Dim host As String = mdlPublicVars.Empresa_CorreoHost
            Dim puerto As Integer = mdlPublicVars.Empresa_CorreoPuerto


            Dim correo As New System.Net.Mail.MailMessage()

            correo.From = New System.Net.Mail.MailAddress(correoEmpresa)

            For index As Integer = 0 To listaCorreos.Count - 1
                correo.To.Add(listaCorreos(index + 1)) ' destinatarios.
            Next


            correo.Subject = emailTitulo
            correo.Body = emailCuerpo.ToString


            correo.IsBodyHtml = False
            correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim attachment As New System.Net.Mail.Attachment(url)
            correo.Attachments.Add(attachment)
            Dim smtp As New System.Net.Mail.SmtpClient()
            smtp.Credentials = New System.Net.NetworkCredential(correoEmpresa, clave)

            smtp.Host = host
            smtp.Port = puerto
            smtp.EnableSsl = True
            Try
                smtp.Send(correo)
            Catch except As Exception

            End Try
            correo.Dispose()

        Catch ex As Exception
            msj = vbCrLf + "Correo No Enviado".ToString
        End Try

        Return msj
    End Function

    'funcion no usada de aca parte la funcion Exportar
    Public Function ExportToPDF(ByVal rpt As ReportDocument, ByVal ruta As String, ByVal NombreArchivo As String) As String
        Dim vFileName As String
        Dim diskOpts As New DiskFileDestinationOptions
        Try
            rpt.Load(ruta & NombreArchivo)
            With rpt.ExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
            End With
            vFileName = ruta & NombreArchivo
            If File.Exists(vFileName) Then File.Delete(vFileName)
            diskOpts.DiskFileName = vFileName
            rpt.ExportOptions.DestinationOptions = diskOpts
            rpt.Export()
        Catch ex As Exception
            Throw ex
        End Try

        Return vFileName
    End Function

    'genera un doc tipo reportDocument con la informacion
    Public Function DocumentoReporte() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Assign the datasource and set the properties for Report viewer
        Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim rutaReporte As String
        Dim path As String
        Try
            path = System.AppDomain.CurrentDomain.BaseDirectory()
            rutaReporte = path & Me.reporte
            rptDocument.Load(rutaReporte)

            If bitDataSet Then
                rptDocument.SetDataSource(dataSet)
            Else
                rptDocument.SetDataSource(Me.tabla)
            End If

            If Me.subReporte <> "" Then
                rptDocument.Subreports(Me.subReporte).SetDataSource(Me.tablaSubReporte)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try

        Return rptDocument
    End Function


End Class
