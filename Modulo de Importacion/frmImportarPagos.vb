﻿Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions


Public Class frmImportarPagos

    Private Sub frmImportarPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdPagos)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdPagos)


        txtUrl.Text = ""
        cmbHojas.Items.Clear()
        cmbHojas.Text = ""
        mdlPublicVars.comboActivarFiltroLista(cmbHojas)

    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        fnAbrirDocumento()
    End Sub

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
                'cblhojas.items.add(dtExcelSchema.Rows(index)("TABLE_NAME").ToString())
                'cblHojas.SetItemChecked(index, True)
            Next

            If dtExcelSchema.Rows.Count > 0 Then
                cmbHojas.SelectedIndex = 0
            End If

            'Obtener el nombre de la primera Hoja.
            'Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()

            connExcel.Close()

        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        fnActualizar()
    End Sub


    Private Sub fnActualizar()
        Dim Conexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (txtUrl.Text.ToString & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=2"";")))

        Try
            Dim cnConex As New OleDbConnection(Conexion)
            Dim Cmd As New OleDbCommand("Select * from [" + cmbHojas.Text.ToString + "]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable



            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)

            'ordenar el dataset.
            Ds.Tables(0).DefaultView.Sort = "boleta asc"
            'pasamos el el dataset ya ordenado al gridview 
            grdPagos.DataSource = Ds.Tables(0)

            lblContador.Text = grdPagos.Rows.Count


            'clientes que no existen en la base de datos.

            Dim consulta2 =
                From r In (From y In Ds.Tables(0).AsEnumerable
                Where Trim(y.Field(Of String)("cliente")).Length > 0 And y!cliente IsNot DBNull.Value _
                Group By Codigo = Trim(y.Field(Of String)("cliente"))
                Into Cantidad = Count(y.Field(Of String)("cliente"))
                Select Codigo, Cantidad)
                Where (From a In ctx.tblClientes Where a.clave.Trim.ToLower = r.Codigo.Trim.ToLower Select a.idCliente).FirstOrDefault = 0
                Select r.Codigo


            'asignar clientes no encontrados.
            Me.grdClientes.DataSource = consulta2


            'contador de clientes.
            lblcontadorClientes.Text = Me.grdClientes.Rows.Count


            cnConex.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub fnGuardar()
        Dim success As Boolean = True


        Dim boleta As String
        Dim fecha As String = Format(Now, "dd/MM/yyyy").ToString
        Dim claveCliente As String
        Dim monto As Decimal = 0
        Dim usuario As String
        Dim tipoPago As Integer

        If success = True Then

            'Using transaction As New TransactionScope

            Dim msgerror As String = ""
            Try



                For i As Integer = 0 To grdPagos.Rows.Count - 1

                    msgerror = i


                    boleta = CType(LTrim(RTrim(grdPagos.Rows(i).Cells("boleta").Value)), String)
                    fecha = LTrim(RTrim(grdPagos.Rows(i).Cells("fecha").Value))
                    claveCliente = CType(LTrim(RTrim(grdPagos.Rows(i).Cells("cliente").Value)), String)
                    monto = CType(LTrim(RTrim(grdPagos.Rows(i).Cells("monto").Value)), Decimal)
                    usuario = CType(LTrim(RTrim(grdPagos.Rows(i).Cells("usuario").Value)), Integer)
                    tipoPago = CType(LTrim(RTrim(grdPagos.Rows(i).Cells("concepto").Value)), Integer)

                    'Consulta a la tabla clientes para extraer el id en base en base a la clave clavee
                    Dim cliente = (From x In ctx.tblClientes Where x.clave.Trim.ToLower = claveCliente.Trim.ToLower Select x).FirstOrDefault

                    If cliente Is Nothing Then
                        MsgBox("cliente no existe " & i)
                    End If

                    Dim pago As tblTipoPago = (From y In ctx.tblTipoPagoes Where y.codigo = tipoPago Select y).FirstOrDefault

                    If pago Is Nothing Then
                        MsgBox("Pago no existe " & i)
                    End If


                    'Creamos el nuevo pago
                    Dim nuevoPago As New tblCaja
                    nuevoPago.tipoPago = tipoPago
                    nuevoPago.empresa = mdlPublicVars.idEmpresa
                    nuevoPago.fecha = fecha
                    nuevoPago.fechaTransaccion = fecha

                    nuevoPago.monto = monto
                    nuevoPago.confirmado = 1 'confirmado por defecto
                    nuevoPago.fechaCobro = fecha
                    nuevoPago.documento = boleta
                    nuevoPago.usuario = usuario
                    nuevoPago.anulado = 0 'anulado falso por defecto
                    nuevoPago.cliente = cliente.idcliente
                    nuevoPago.observacion = ""
                    nuevoPago.descripcion = pago.nombre
                    nuevoPago.bitEntrada = 1 ' Entrada

                    ctx.AddTotblCajas(nuevoPago)
                    ctx.SaveChanges()


                    'Actualizamos la tabla clientes 

                    If pago.entrada = True Then

                        If cliente.saldo < 0 Then
                            cliente.saldo = cliente.saldo - monto
                            cliente.pagos = cliente.pagos + monto

                        ElseIf cliente.saldo = 0 Then
                            cliente.saldo = (monto) * (-1)
                            cliente.pagos = cliente.pagos + monto

                        ElseIf cliente.saldo > 0 Then
                            cliente.saldo = cliente.saldo - monto
                            cliente.pagos = cliente.pagos + monto
                        End If

                    End If

                    If pago.salida = True Then

                        'verificar si va
                        If cliente.saldo < 0 Then
                            cliente.saldo = cliente.saldo - monto
                            cliente.pagos = cliente.pagos + monto

                        ElseIf cliente.saldo = 0 Then
                            cliente.saldo = (monto) * (-1)
                            cliente.pagos = cliente.pagos + monto

                        ElseIf cliente.saldo > 0 Then
                            cliente.saldo = cliente.saldo - monto
                            cliente.pagos = cliente.pagos + monto
                        End If


                    End If


                    ctx.SaveChanges()

                Next


                'paso 8, completar la transaccion.
                ' Transaction.Complete()

            Catch ex As System.Data.EntityException
                MsgBox(msgerror)
                success = False
                'Catch ex As Exception
                '    ' Handle errors and deadlocks here and retry if needed. 
                '    ' Allow an UpdateException to pass through and 
                '    ' retry, otherwise stop the execution. 
                '    If ex.[GetType]() <> GetType(UpdateException) Then
                '        success = False
                '        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                '        alerta.fnErrorGuardar()
                '        Exit Try
                '        ' If we get to this point, the operation will be retried. 
                '    End If
            End Try
            ' End Using

        End If

        If success = True Then
            ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()

        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    Private Sub frm_GuardarRegistros() Handles Me.panel0
        fnGuardar()
    End Sub


    Private Sub frm_Salir() Handles Me.panel1
        Me.Close()
    End Sub

End Class
