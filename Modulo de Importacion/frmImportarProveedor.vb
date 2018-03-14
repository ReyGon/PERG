Option Strict On

Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmImportarProveedor

#Region "Variables"

#End Region

#Region "Load"
    Private Sub frmImportarClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)
        txtUrl.Text = ""
        cmbHojas.Items.Clear()
        cmbHojas.Text = ""
        mdlPublicVars.comboActivarFiltroLista(cmbHojas)
    End Sub
#End Region

#Region "Eventos"
    'ABRIR ARCHIVO
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        fnAbrirDocumento()
    End Sub

    'AGREGAR DATOS
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        fnActualizar()
    End Sub

    'GUARDAR PROVEEDORES
    Private Sub fnGuardarProveedores_Click() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar los proveedores?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardarProveedores()
        End If
    End Sub

    'SALIR
    Private Sub fnSalir_Click() Handles Me.panel1
        Me.Close()
    End Sub
#End Region

#Region "Funciones"
    'ABRIR DOCUMENTO
    Private Sub fnAbrirDocumento()
        Try
            Dim ruta As String = ""
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Seleccionar archivos"
                .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*.xlsx|Todos los archivos (*.*)|*.*"
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtUrl.Text = .FileName
                Else
                    Exit Sub
                End If
            End With
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (txtUrl.Text.ToString & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=2"";")))
            'Leer las hojas del libro de excel
            Dim connExcel As New OleDbConnection(stConexion)
            Dim cmdExcel As New OleDbCommand()
            'Dim oda As New OleDbDataAdapter()
            'Dim dt2 As New DataTable()
            cmdExcel.Connection = connExcel

            'obtener nombre de la primer hoja
            connExcel.Open()
            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            'recorrer y mostrar las hojas en un combox
            cmbHojas.Items.Clear()
            'cblhojas.items.clear()
            For index As Integer = 0 To dtExcelSchema.Rows.Count - 1
                cmbHojas.Items.Add(dtExcelSchema.Rows(index)("TABLE_NAME").ToString())
            Next

            If dtExcelSchema.Rows.Count > 0 Then
                cmbHojas.SelectedIndex = 0
            End If
            connExcel.Close()

        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

    End Sub

    'AGREGAR DATOS A GRID
    Private Sub fnActualizar()

        Dim conexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (txtUrl.Text.ToString & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=2"";")))

        Try

            Dim cnConex As New OleDbConnection(conexion)
            Dim Cmd As New OleDbCommand("SELECT * FROM [" + cmbHojas.Text.ToString + "]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)

            'pasamos el el dataset ya ordenado al gridview 
            grdDatos.DataSource = Dt
            lblContador.Text = CStr(grdDatos.Rows.Count)

            'Ocultar columnas
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).IsVisible = False
            Next

            Me.grdDatos.Columns("Clave").IsVisible = True
            Me.grdDatos.Columns("Negocio").IsVisible = True
            Me.grdDatos.Columns("Direccion").IsVisible = True
            Me.grdDatos.Columns("Telefono").IsVisible = True
            Me.grdDatos.Columns("Contacto").IsVisible = True

            cnConex.Close()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'GUARDAR CLIENTES
    Private Sub fnGuardarProveedores()
        Dim conexion As dsi_pos_demoEntities
        Dim fechaServidor As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor())
        Dim success As Boolean = True

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope
                Try
                    'Recorrer el grid con los clientes
                    For Each proveedor As GridViewRowInfo In Me.grdDatos.Rows
                        Dim nuevoproveedor As New tblProveedor
                        nuevoproveedor.clave = Cstr2(proveedor.Cells("Clave").Value)
                        nuevoproveedor.negocio = Cstr2(proveedor.Cells("Negocio").Value)
                        nuevoproveedor.direccion = Cstr2(proveedor.Cells("Direccion").Value)
                        nuevoproveedor.telefono = Cstr2(proveedor.Cells("Telefono").Value)
                        nuevoproveedor.habilitado = True
                        nuevoproveedor.contacto = Cstr2(proveedor.Cells("Contacto").Value)
                        nuevoproveedor.diasCredito = CShort(proveedor.Cells("DiasCredito").Value)
                        nuevoproveedor.telefonoContacto = Cstr2(proveedor.Cells("TelefonoContacto").Value)
                        nuevoproveedor.correo1 = Cstr2(proveedor.Cells("Correo1").Value)
                        nuevoproveedor.correo2 = Cstr2(proveedor.Cells("Correo2").Value)
                        nuevoproveedor.nit = Cstr2(proveedor.Cells("Nit").Value)
                        nuevoproveedor.codigoVenta = Cstr2(proveedor.Cells("CodigoVenta").Value)
                        nuevoproveedor.procedencia = CInt(proveedor.Cells("Procedencia").Value)
                        nuevoproveedor.montoCredito = CDec(proveedor.Cells("MontoCredito").Value)
                        nuevoproveedor.tipoPago = CInt(proveedor.Cells("TipoPago").Value)
                        nuevoproveedor.saldoTransito = 0
                        nuevoproveedor.saldoActual = 0
                        nuevoproveedor.pagos = 0
                        nuevoproveedor.pagosTransito = 0
                        nuevoproveedor.empresa = mdlPublicVars.idEmpresa
                        nuevoproveedor.pagosTransitoDolar = 0
                        nuevoproveedor.pagosDolar = 0
                        nuevoproveedor.saldoDolar = 0

                        'CLASIFICACION DE NEGOCIO
                        Dim clasificacion As tblProveedorClasificacionNegocio = (From x In conexion.tblProveedorClasificacionNegocios.AsEnumerable Where x.nombre.Equals(CStr(proveedor.Cells("Clasificacion").Value)) Select x).FirstOrDefault
                        If clasificacion IsNot Nothing Then
                            nuevoproveedor.idClasificacionNegocio = clasificacion.idProveedorClasificacionNegocio
                        Else
                            'Creamos el nuevo tipo de negocio
                            Dim nuevaClasificacion As New tblProveedorClasificacionNegocio
                            nuevaClasificacion.nombre = CStr(proveedor.Cells("Clasificacion").Value)

                            conexion.AddTotblProveedorClasificacionNegocios(nuevaClasificacion)
                            conexion.SaveChanges()

                            nuevoproveedor.idClasificacionNegocio = nuevaClasificacion.idProveedorClasificacionNegocio
                        End If

                        conexion.AddTotblProveedors(nuevoproveedor)
                        conexion.SaveChanges()
                    Next

                    transaction.Complete()
                Catch ex As Exception
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    success = False
                End Try
            End Using
            conn.Close()
        End Using

        If success Then
            alerta.fnGuardar()
            If RadMessageBox.Show("¿Desea cargar otro archivo?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnNuevo()
            Else
                Me.Close()
            End If
        End If
    End Sub

    'NUEVA EXPORTACION
    Private Sub fnNuevo()
        Me.grdDatos.DataSource = Nothing
        txtUrl.Text = ""
        cmbHojas.Items.Clear()
        cmbHojas.Text = ""
    End Sub
#End Region

End Class
