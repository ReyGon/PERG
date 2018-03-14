Option Strict On

Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmImportarClientes

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

    'GUARDAR CLIENTES
    Private Sub fnGuardarClientes_Click() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar los clientes?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardarClientes()
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
            grdDatos.DataSource = Ds.Tables(0)
            lblContador.Text = CStr(grdDatos.Rows.Count)

            'Ocultar columnas
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).IsVisible = False
            Next

            Me.grdDatos.Columns("Clave").IsVisible = True
            Me.grdDatos.Columns("Negocio").IsVisible = True
            Me.grdDatos.Columns("Nombre1").IsVisible = True
            Me.grdDatos.Columns("DirEnvio1").IsVisible = True
            Me.grdDatos.Columns("Nit1").IsVisible = True

            cnConex.Close()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'GUARDAR CLIENTES
    Private Sub fnGuardarClientes()
        Dim conexion As dsi_pos_demoEntities
        Dim fechaServidor As DateTime = CDate(mdlPublicVars.fnFecha_horaServidor())
        Dim success As Boolean = True
        Dim nombrecliente As String = ""
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            'Recorrer el grid con los clientes
            For Each cliente As GridViewRowInfo In Me.grdDatos.Rows
                If Not IsDBNull(cliente.Cells("Negocio").Value) Then
                    Try
                        Dim nuevocliente As New tblCliente
                        nombrecliente = CStr(cliente.Cells("Negocio").Value)
                        nuevocliente.habillitado = True
                        nuevocliente.clave = CStr(cliente.Cells("Clave").Value)
                        nuevocliente.Negocio = nombrecliente
                        nuevocliente.Nombre1 = CStr(cliente.Cells("Nombre1").Value)
                        nuevocliente.Nombre2 = Cstr2(cliente.Cells("Nombre2").Value)
                        nuevocliente.nit1 = Cstr2(cliente.Cells("Nit1").Value)
                        nuevocliente.nit2 = Cstr2(cliente.Cells("Nit2").Value)
                        nuevocliente.direccionEnvio1 = Cstr2(cliente.Cells("DirEnvio1").Value)
                        nuevocliente.direccionEnvio2 = Cstr2(cliente.Cells("DirEnvio2").Value)
                        nuevocliente.telefono = Cstr2(cliente.Cells("Telefono").Value)
                        nuevocliente.contacto = Cstr2(cliente.Cells("Contacto").Value)
                        nuevocliente.email = Cstr2(cliente.Cells("Email").Value)
                        nuevocliente.observacion = Cstr2(cliente.Cells("Observacion").Value)
                        nuevocliente.limiteCredito = CDec(cliente.Cells("LimiteCredito").Value)
                        nuevocliente.porcentajeCredito = CDec(cliente.Cells("PorcentajeCredito").Value)
                        nuevocliente.diasCredito = CShort(cliente.Cells("DiasCredito").Value)
                        nuevocliente.idMunicipio = mdlPublicVars.General_MunicipioLocal
                        nuevocliente.idVendedor = mdlPublicVars.idVendedor
                        nuevocliente.saldo = 0
                        nuevocliente.pagos = 0
                        nuevocliente.pagosTransito = 0
                        nuevocliente.devoluciones = 0
                        nuevocliente.idTipoPago = CInt(cliente.Cells("TipoPago").Value)
                        nuevocliente.idClasificacionNegocio = CInt(cliente.Cells("ClasificacionNegocio").Value)
                        nuevocliente.direccionFactura1 = Cstr2(cliente.Cells("DirFactura1").Value)
                        nuevocliente.direccionFactura2 = Cstr2(cliente.Cells("DirFactura2").Value)
                        nuevocliente.idEmpresa = mdlPublicVars.idEmpresa
                        nuevocliente.bitMostrador = False

                        'TIPO DE NEGOCIO
                        Dim tipoNegocio As tblClienteTipoNegocio = (From x In conexion.tblClienteTipoNegocios.AsEnumerable Where x.nombre.Equals(CStr(cliente.Cells("TipoNegocio").Value)) Select x).FirstOrDefault

                        If tipoNegocio IsNot Nothing Then
                            nuevocliente.idTipoNegocio = tipoNegocio.idTipoNegocio
                        Else
                            'Creamos el nuevo tipo de negocio
                            Dim nuevoTipoNegocio As New tblClienteTipoNegocio
                            nuevoTipoNegocio.nombre = CStr(cliente.Cells("TipoNegocio").Value)
                            nuevoTipoNegocio.porcentaje = 0

                            conexion.AddTotblClienteTipoNegocios(nuevoTipoNegocio)
                            conexion.SaveChanges()

                            nuevocliente.idTipoNegocio = nuevoTipoNegocio.idTipoNegocio
                        End If

                        conexion.AddTotblClientes(nuevocliente)
                        conexion.SaveChanges()
                    Catch ex As Exception
                        RadMessageBox.Show("Ocurrio un error al intentar exportar los datos de: " & nombrecliente, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                        success = False
                    End Try
                End If
            Next
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
