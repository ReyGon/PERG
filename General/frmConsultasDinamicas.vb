Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
''Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq
Imports System.Data

Public Class frmConsultasDinamicas

    Dim tbl As clsDevuelveTabla
    Dim consulta As String
    Dim vfechafin As Boolean = False
    Dim vfechainicio As Boolean = False
    Dim vhabilitado As Boolean = False
    Dim bitsp As Boolean = False

    Private Sub frmConsultasDinamicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombo()
        fnconfiguracion()
        rbtConsultas.Checked = True
        rbtCompras.Checked = True
        ''Me.grdListado.AutoResizeColumns()
        ''mdlPublicVars.fnFormatoGridEspeciales(Me.grdListado)
        ''mdlPublicVars.fnFormatoGridMovimientos(Me.grdListado)
    End Sub

    Private Sub fnLlenarCombo()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim consultas = (From x In conexion.tblConsultasDinamicas Where x.habilitada Select Codigo = x.idconsulta, Nombre = x.Nombre).ToList

            With cmbConsulta
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = consultas
            End With

            Dim tipoinventarios = (From x In conexion.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre).ToList

            With cmbTipoInventarios
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tipoinventarios
            End With

            conn.Close()
        End Using
    End Sub

    Private Sub cmbConsulta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConsulta.SelectedValueChanged
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim idconsulta As Integer = Me.cmbConsulta.SelectedValue

                consulta = (From x In conexion.tblConsultasDinamicas Where x.idconsulta = idconsulta Select x.Consulta).FirstOrDefault

                vhabilitado = (From x In conexion.tblConsultasDinamicas Where x.idconsulta = idconsulta Select x.habilitada).FirstOrDefault

                vfechafin = (From x In conexion.tblConsultasDinamicas Where x.idconsulta = idconsulta Select x.fechafin).FirstOrDefault

                vfechainicio = (From x In conexion.tblConsultasDinamicas Where x.idconsulta = idconsulta Select x.fechainicio).FirstOrDefault

                If vfechafin = False Then
                    Me.dtpHasta.Enabled = False
                Else
                    Me.dtpHasta.Enabled = True
                End If

                If vfechainicio = False Then
                    Me.dtpDesde.Enabled = False
                Else
                    Me.dtpDesde.Enabled = True
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConsulta_Click(sender As Object, e As EventArgs) Handles btnConsulta.Click
        Try
            Me.grdListado.DataSource = Nothing

            Dim r As SqlClient.SqlDataReader
            Dim dt As New DataTable
            Dim tabla As DataTable
            Dim adp As New SqlClient.SqlDataAdapter
            Dim sqlcomando As System.Data.SqlClient.SqlCommand
            Dim IdtipoIventario As Integer
            ''Dim SqlConexion As New System.Data.SqlClient.SqlConnection

            Try

                Me.grdListado.Rows.Clear()
                Me.grdListado.Columns.Clear()
                Me.Progreso.Minimum = 0
                Me.Progreso.Maximum = 100
                Me.Progreso.Value1 = 0
                Me.Progreso.Text = "0 %"
                Application.DoEvents()

                Dim fechainicio As Date = dtpDesde.Value.ToShortDateString + " 00:00:00.000"
                Dim fechafin As Date = dtpHasta.Value.ToShortDateString + " 23:59:59.999"

                IdtipoIventario = CInt(Me.cmbTipoInventarios.SelectedValue())

                If rbtConsultas.Checked = True Then

                    mdlPublicVars.conexion()
                    Dim cnn As New System.Data.SqlClient.SqlConnection

                    cnn.ConnectionString = mdlPublicVars.cnn
                    cnn.Open()

                    Dim Transaccion As System.Data.IDbTransaction

                    If vfechafin = False And vfechainicio = False Then
                        Me.dtpDesde.Enabled = False
                        Me.dtpHasta.Enabled = False
                        sqlcomando = New System.Data.SqlClient.SqlCommand(consulta, cnn)
                    End If

                    Try

                        sqlcomando.Transaction = Transaccion
                        r = sqlcomando.ExecuteReader()

                        For index As Integer = 0 To r.FieldCount - 1
                            dt.Columns.Add(r.GetName(index))
                        Next

                        Dim filas As Integer = 0

                        While r.Read
                            dt.Rows.Add()
                            For index As Integer = 0 To r.FieldCount - 1
                                dt.Rows(filas).Item(index) = r.Item(index)
                            Next
                            filas = filas + 1
                        End While
                        r.Close()

                        cnn.Close()
                        cnn.Dispose()
                    Catch ex As Exception
                        Transaccion.Rollback()
                        cnn.Close()
                    End Try

                ElseIf rbtProcedimientos.Checked = True Then

                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                        conexion.CommandTimeout = 10000

                        ''If vfechainicio And vfechafin Then

                        ''    dt = EntitiToDataTable(conexion.sp_ComprasConAjustes(fechainicio, fechafin))

                        ''ElseIf vfechainicio = False And vfechafin = True Then

                        ''ElseIf vfechainicio = True And vfechafin = False Then

                        ''End If

                        If rbtCompras.Checked Then
                            dt = EntitiToDataTable(conexion.sp_ComprasConAjustes(fechainicio, fechafin))
                        ElseIf rbtRetroactividadInv.Checked Then
                            dt = EntitiToDataTable(conexion.sp_Retroactividad_Inventario(fechafin, IdtipoIventario))
                        ElseIf rbtDevAjustes.Checked Then
                            dt = EntitiToDataTable(conexion.sp_Devoluciones_Ajustes(fechainicio, fechafin))
                        ElseIf rbtRetroactividadCli.Checked Then
                            dt = EntitiToDataTable(conexion.sp_Retroactividad_Clientes(fechafin))
                        ElseIf rbtVentasCosto.Checked Then
                            dt = EntitiToDataTable(conexion.sp_Ventas_Costo(fechainicio, fechafin))
                        End If

                        conn.Close()
                    End Using

                End If

            Catch ex As Exception

            End Try

            ''Dim valor As Integer = tbl.FnDevulveDato("select nombre1 from tblarticulo where idarticulo=65")

            tabla = dt

            MostrarCarga(tabla)

        Catch ex As Exception

        End Try

        ''fnConfiguracion()
    End Sub

    Private Sub fnconfiguracion()
        Try
            Me.grdListado.AutoResizeColumns()
            Me.grdListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarCarga(ByVal tabla As DataTable)
        Try
            Dim IntFila As Integer = 0
            Dim IntStock As Integer = 0
            Dim IntFilas As Integer = 0
            Dim fila As Object()
            Dim columnas As Integer = 0

            Progreso.Minimum = 0
            Progreso.Maximum = IIf(tabla.Rows.Count = 1, 1, tabla.Rows.Count)

            columnas = tabla.Columns.Count - 1

            ''fnGridBlanco()

            For c As Integer = 0 To tabla.Columns.Count - 1
                Dim Col As New DataGridViewTextBoxColumn

                Col.HeaderText = tabla.Columns(c).ColumnName
                Col.Name = tabla.Columns(c).ColumnName

                Me.grdListado.Columns.Add(Col)

            Next

            For i As Integer = 0 To tabla.Rows.Count - 1

                Progreso.Value1 = IIf(i = 0, 1, i)
                Progreso.Text = Convert.ToInt32((Progreso.Value1 * 100) / Progreso.Maximum) & " % "
                Application.DoEvents()

                If columnas = 0 Then
                    fila = {tabla.Rows(i).Item(0)}
                ElseIf columnas = 1 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1)}
                ElseIf columnas = 2 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2)}
                ElseIf columnas = 3 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3)}
                ElseIf columnas = 4 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4)}
                ElseIf columnas = 5 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5)}
                ElseIf columnas = 6 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6)}
                ElseIf columnas = 7 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7)}
                ElseIf columnas = 8 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8)}
                ElseIf columnas = 9 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9)}
                ElseIf columnas = 10 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10)}
                ElseIf columnas = 11 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11)}
                ElseIf columnas = 12 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12)}
                ElseIf columnas = 13 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13)}
                ElseIf columnas = 14 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14)}
                ElseIf columnas = 15 Then
                    fila = {tabla.Rows(i).Item(0), tabla.Rows(i).Item(1), tabla.Rows(i).Item(2), tabla.Rows(i).Item(3), tabla.Rows(i).Item(4), tabla.Rows(i).Item(5), tabla.Rows(i).Item(6), tabla.Rows(i).Item(7), tabla.Rows(i).Item(8), tabla.Rows(i).Item(9), tabla.Rows(i).Item(10), tabla.Rows(i).Item(11), tabla.Rows(i).Item(12), tabla.Rows(i).Item(13), tabla.Rows(i).Item(14), tabla.Rows(i).Item(15)}
                End If

                Me.grdListado.Rows.Add(fila)

                IntFila += 1

            Next

            fila = {"Contador", CStr(IntFila)}

            Me.grdListado.Rows.Add(fila)

            Me.grdListado.Rows(IntFila).DefaultCellStyle.ForeColor = Color.Blue
            Me.grdListado.Rows(IntFila).DefaultCellStyle.Font = New Font("Footlight MT Light ", 14, FontStyle.Regular)


            Progreso.Value1 = Progreso.Maximum
            Progreso.Text = "100 %"

        Catch ex As Exception

        End Try
    End Sub

    ''Private Sub fnConfiguracion()
    ''    Try
    ''        Try
    ''            grdListado.SummaryRowsTop.Clear()
    ''        Catch ex As Exception

    ''        End Try
    ''        Dim nombre As String = Me.grdListado.Columns(0).Name
    ''        Dim summaryId As New GridViewSummaryItem(nombre, mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)

    ''        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId})

    ''        grdListado.SummaryRowsTop.Add(summaryRowItem)

    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCopiarFilas_Click(sender As Object, e As EventArgs) Handles btnCopiarFilas.Click
        Try
            CopiarGrid(grdListado)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CopiarGrid(grd As DataGridView)
        Try
            Me.grdListado.SelectAll()

            Dim dataObj As DataObject

            grd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dataObj = grd.GetClipboardContent()
            If Me.grdListado.Rows.Count - 1 > 0 Then
                Clipboard.SetDataObject(dataObj)
            End If

            Me.grdListado.ClearSelection()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtConsultas.CheckedChanged
        If rbtConsultas.Checked Then
            Me.cmbConsulta.Enabled = True
            Me.rgbProcedimientos.Enabled = False
        Else
            Me.cmbConsulta.Enabled = False
            Me.rgbProcedimientos.Enabled = True
        End If
    End Sub

    Private Sub rbtProcedimientos_CheckedChanged(sender As Object, e As EventArgs) Handles rbtProcedimientos.CheckedChanged
        Try
            If rbtProcedimientos.Checked Then
                Me.dtpDesde.Enabled = False
                Me.dtpHasta.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtCompras_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCompras.CheckedChanged
        If rbtCompras.Checked Then
            Me.dtpDesde.Enabled = True
            Me.dtpHasta.Enabled = True
        End If
    End Sub

    Private Sub rbtRetroactividadInv_CheckedChanged(sender As Object, e As EventArgs) Handles rbtRetroactividadInv.CheckedChanged
        If rbtRetroactividadInv.Checked Then
            Me.cmbTipoInventarios.Enabled = True
            Me.dtpDesde.Enabled = False
            Me.dtpHasta.Enabled = True
        ElseIf rbtCompras.Checked Then
            Me.cmbTipoInventarios.Enabled = False
            Me.dtpDesde.Enabled = True
            Me.dtpHasta.Enabled = True
        ElseIf rbtDevAjustes.Checked Then
            Me.cmbTipoInventarios.Enabled = False
            Me.dtpDesde.Enabled = True
            Me.dtpHasta.Enabled = True
        ElseIf rbtRetroactividadCli.Checked Then
            Me.cmbTipoInventarios.Enabled = False
            Me.dtpDesde.Enabled = False
            Me.dtpHasta.Enabled = True
        ElseIf rbtVentasCosto.Checked Then
            Me.cmbTipoInventarios.Enabled = False
            Me.dtpDesde.Enabled = True
            Me.dtpHasta.Enabled = True

        End If
    End Sub
End Class
