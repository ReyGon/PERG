Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions


Public Class frmImportarCompras

    Private Sub frmImportarCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdCompras)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDetalleArticulos)

        txtUrl.Text = ""
        cmbHojas.Items.Clear()
        cmbHojas.Text = ""
        mdlPublicVars.comboActivarFiltroLista(cmbHojas)
    End Sub



    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
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


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
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


            Dim Ds2 As New DataSet
            Dim Da2 As New OleDbDataAdapter
            Dim Dt2 As New DataTable


            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)

            'ordenar el dataset.
            Ds.Tables(0).DefaultView.Sort = "documento asc"
            'pasamos el el dataset ya ordenado al gridview 
            grdCompras.DataSource = Ds.Tables(0)

            lblContadorCompras.Text = grdCompras.Rows.Count


            '--------------------------------Llenar el detalle.
            Dim consulta =
                From r In
                (From y In Ds.Tables(0).AsEnumerable
                Where Trim(y.Field(Of String)("codigo")).Length > 0 And y!codigo IsNot DBNull.Value _
                Group By Codigo = Trim(y.Field(Of String)("codigo"))
                Into Cantidad = Sum(Convert.ToDouble(y.Field(Of String)("cantidad")))
                Select Codigo, Cantidad)
            Join a In ctx.tblArticuloes On a.codigo1.Trim.ToLower Equals r.Codigo.ToLower
            Join i In ctx.tblInventarios On a.idArticulo Equals i.idArticulo
            Where i.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And i.idTipoInventario = mdlPublicVars.General_idTipoInventario
            Select Codigo = r.Codigo, IdArticulo = a.idArticulo, r.Cantidad, i.saldo, NuevoSaldo = (i.saldo + r.Cantidad)


            Me.grdDetalleArticulos.DataSource = consulta



            If Me.grdDetalleArticulos.Rows.Count > 0 Then
                Me.grdDetalleArticulos.Columns("IdArticulo").IsVisible = False
            End If

            lblContadorArticulos.Text = grdDetalleArticulos.Rows.Count


            '--------------------------------------------Productos que no existen en la base de datos.

            Dim consultaProductos =
                From r In (From y In Ds.Tables(0).AsEnumerable
                Where Trim(y.Field(Of String)("codigo")).Length > 0 And y!codigo IsNot DBNull.Value _
                Group By Codigo = Trim(y.Field(Of String)("codigo"))
                Into Cantidad = Count(y.Field(Of String)("cantidad"))
                Select Codigo, Cantidad)
                Where (From a In ctx.tblArticuloes Where a.codigo1.Trim.ToLower = r.Codigo.Trim.ToLower Select a.idArticulo).FirstOrDefault = 0
                Select r.Codigo, r.Cantidad



            Me.grdProductosNoEncontrados.DataSource = consultaProductos


            cnConex.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



    End Sub






    Private Sub fnGuardar()

        Dim success As Boolean = True


        Dim documento As String
        Dim fecha As String = Format(Now, "dd/MM/yyyy").ToString
        Dim claveProveedor As String
        Dim codigoArticulo As String
        Dim cantidad As Integer = 0
        Dim costo As Double = 0

        Dim docAnterior As String = "0"
        Dim idEntradaAnterior As Integer = 0
        '    Dim idFacturaAnterior As Integer = 0

        Dim numeroError As Integer = 0
        Dim errores As String = ""

        Dim contadorDetalle As Integer = 0
        Dim id As Integer = 0

        If success = True Then

            'crear el encabezado de la transaccion
            'Using transaction As New TransactionScope
            'inicio de excepcion
            Try

                For i As Integer = 0 To grdCompras.Rows.Count - 1

                    documento = LTrim(RTrim(grdCompras.Rows(i).Cells("documento").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(0).ToString))
                    errores = documento

                    numeroError = i

                    If documento = docAnterior Then







                        contadorDetalle = 1

                        'si ya existe el docuemtno solo agregamos el detalle
                        ' agregar el detalle a la entrada anterior, id de entrda anterior.
                        Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = idEntradaAnterior Select x).FirstOrDefault
                        id = idEntradaAnterior

                        'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                        codigoArticulo = LTrim(RTrim(grdCompras.Rows(i).Cells("codigo").Value))
                        Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1 = codigoArticulo Select y).FirstOrDefault

                        errores += " " & codigoArticulo

                        cantidad = LTrim(RTrim(grdCompras.Rows(i).Cells("cantidad").Value))
                        costo = Math.Round(CType(LTrim(RTrim(grdCompras.Rows(i).Cells("costo").Value)), Double), 2)


                        'agregar el detalle
                        Dim detalleEntrada As New tblEntradasDetalle

                        detalleEntrada.idEntrada = entrada.idEntrada
                        detalleEntrada.idArticulo = articulo.idArticulo
                        detalleEntrada.cantidad = cantidad
                        detalleEntrada.costoIVA = costo
                        detalleEntrada.costoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))
                        detalleEntrada.preformaCostoIVA = costo
                        detalleEntrada.preformaCostoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))

                        'guardar el detalle
                        ctx.AddTotblEntradasDetalles(detalleEntrada)
                        ctx.SaveChanges()

                        'actualizar el saldo.
                        'Actualizar el total de la salida e incrementar en clientes.
                        Dim ProveedorActualizar As tblProveedor = (From c In ctx.tblProveedors Where c.idProveedor = detalleEntrada.tblEntrada.idProveedor Select c).FirstOrDefault
                        ProveedorActualizar.saldoActual += detalleEntrada.costoIVA * detalleEntrada.cantidad
                        ctx.SaveChanges()


                        'Actualizamos el total a la tabla entrada
                        Dim total As Double = 0
                        total = (From x In ctx.tblEntradasDetalles Where x.idEntrada = entrada.idEntrada Select x.cantidad * x.costoIVA).Sum
                        entrada.total = total
                        ctx.SaveChanges()




                    Else
                        contadorDetalle += 1
                        'Creamos la nueva entrada
                        fecha = LTrim(RTrim(grdCompras.Rows(i).Cells("fecha").Value))
                        claveProveedor = CType(LTrim(RTrim(grdCompras.Rows(i).Cells("proveedor").Value)), Integer)

                        errores += " " & claveProveedor

                        'capturamos la clave del proveedor para hacer una consulta a la tabla tblproveedor 
                        ' y capturar la informacion del cliente para añadirla a la salida
                        Dim proveedor As tblProveedor = (From z In ctx.tblProveedors Where z.clave = claveProveedor Select z).FirstOrDefault

                        If proveedor Is Nothing Then
                            MessageBox.Show("Proveedor no existe " & claveProveedor)
                        End If

                        'Consultamos el correlativo para la nueva entrada
                        Dim numeroCorrelativo As Integer

                        Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento _
                                                         And x.idEmpresa = mdlPublicVars.idEmpresa Select x).First

                        If correlativo IsNot Nothing Then
                            correlativo.correlativo += 1
                            ctx.SaveChanges()

                            'asignar el numero de correlativo.
                            'numeroCorrelativo = correlativo.serie & correlativo.correlativo
                            numeroCorrelativo = correlativo.correlativo
                        Else
                            'crear registro de correlativo.
                            Dim correlativoNuevo As New tblCorrelativo
                            correlativoNuevo.correlativo = 1
                            correlativoNuevo.serie = ""
                            correlativoNuevo.inicio = 1
                            correlativoNuevo.fin = 1000
                            correlativoNuevo.porcentajeAviso = 20
                            correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                            correlativoNuevo.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                            ctx.AddTotblCorrelativos(correlativoNuevo)
                            ctx.SaveChanges()

                            'asignar el numero de correlativo.
                            numeroCorrelativo = 1
                        End If

                        'creamos la nueva entrada
                        Dim nuevaEntrada As New tblEntrada

                        nuevaEntrada.idEmpresa = mdlPublicVars.idEmpresa
                        nuevaEntrada.idUsuario = mdlPublicVars.idUsuario
                        nuevaEntrada.idTipoMovimiento = mdlPublicVars.Entrada_CodigoMovimiento
                        nuevaEntrada.idProveedor = proveedor.idProveedor
                        nuevaEntrada.fechaRegistro = fecha
                        nuevaEntrada.fechaTransaccion = fecha
                        nuevaEntrada.fechaCompra = fecha
                        nuevaEntrada.serieDocumento = ""
                        nuevaEntrada.documento = documento
                        nuevaEntrada.observacion = ""
                        nuevaEntrada.anulado = 0
                        nuevaEntrada.preforma = 0
                        nuevaEntrada.transito = 0
                        nuevaEntrada.compra = 1 'por defecto 1 compra confirmada
                        nuevaEntrada.flete = 0
                        nuevaEntrada.correlativo = numeroCorrelativo
                        nuevaEntrada.idtipoInventario = mdlPublicVars.General_idTipoInventario
                        nuevaEntrada.idalmacen = mdlPublicVars.General_idAlmacenPrincipal
                        nuevaEntrada.cancelado = 0 ' canceldo falso
                        'nuevaEntrada.saldo
                        'nuevaEntrada.pagos
                        nuevaEntrada.credito = 0
                        nuevaEntrada.contado = 1
                        'nuevaEntrada.fechaPago
                        nuevaEntrada.usuarioCompra = mdlPublicVars.idUsuario

                        ' guardar la entrada
                        ctx.AddTotblEntradas(nuevaEntrada)
                        ctx.SaveChanges()


                        id = nuevaEntrada.idEntrada

                        'creamos el detalle de la entrada
                        Dim detalleEntrada As New tblEntradasDetalle

                        'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                        codigoArticulo = LTrim(RTrim(grdCompras.Rows(i).Cells("codigo").Value))
                        Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1 = codigoArticulo Select y).FirstOrDefault

                        If articulo Is Nothing Then
                            MessageBox.Show("articulo")
                        End If

                        cantidad = LTrim(RTrim(grdCompras.Rows(i).Cells("cantidad").Value))
                        costo = Math.Round(CType(LTrim(RTrim(grdCompras.Rows(i).Cells("costo").Value)), Double), 2)

                        detalleEntrada.idEntrada = nuevaEntrada.idEntrada
                        detalleEntrada.idArticulo = articulo.idArticulo
                        detalleEntrada.cantidad = cantidad
                        detalleEntrada.costoIVA = costo
                        detalleEntrada.costoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))
                        detalleEntrada.preformaCantidad = cantidad
                        detalleEntrada.preformaCostoIVA = costo
                        detalleEntrada.preformaCostoSinIVA = costo / (1 + (mdlPublicVars.General_IVA / 100))

                        'guardar el detalle
                        ctx.AddTotblEntradasDetalles(detalleEntrada)
                        ctx.SaveChanges()

                        'actualizar el saldo.
                        'Actualizar el total de la salida e incrementar en clientes.
                        Dim ProveedorActualizar As tblProveedor = (From c In ctx.tblProveedors Where c.idProveedor = detalleEntrada.tblEntrada.idProveedor Select c).FirstOrDefault
                        ProveedorActualizar.saldoActual += detalleEntrada.costoIVA * detalleEntrada.cantidad
                        ctx.SaveChanges()


                        idEntradaAnterior = nuevaEntrada.idEntrada

                        'Consultamos el detalle de la compra para guardar el total en la tabla compra
                        If documento = "0" Then
                        Else
                            Dim total As Double = 0
                            total = (From x In ctx.tblEntradasDetalles Where x.idEntrada = nuevaEntrada.idEntrada Select x.cantidad * x.costoIVA).Sum
                            nuevaEntrada.total = total
                            ctx.SaveChanges()

                        End If

                    End If





                    docAnterior = documento

                Next


                'Actualizamos el inventario
                For i As Integer = 0 To grdDetalleArticulos.Rows.Count - 1
                    Dim idArticulo As Integer
                    Dim cantidadComprada As Integer

                    idArticulo = CType(LTrim(RTrim(grdDetalleArticulos.Rows(i).Cells("IdArticulo").Value)), Integer)
                    cantidadComprada = CType(LTrim(RTrim(grdDetalleArticulos.Rows(i).Cells("Cantidad").Value)), Integer)

                    Dim inventario = (From z In ctx.tblInventarios Where z.idArticulo = idArticulo And z.idTipoInventario = mdlPublicVars.General_idTipoInventario And z.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal Select z).FirstOrDefault

                    If inventario Is Nothing Then
                        MessageBox.Show("no existe inventario ")
                    End If

                    'sumamos a la entrada la cantidad de articulos
                    inventario.entrada = inventario.entrada + cantidadComprada

                    'Descontamos del saldo la cantidad
                    inventario.saldo = inventario.saldo + cantidadComprada
                    ctx.SaveChanges()
                Next



                'completar la transaccion.
                'transaction.Complete()


                'Catch ex As System.Data.EntityException
                'success = False
            Catch ex As Exception

                MsgBox(numeroError & " " & errores)
                success = False

                RadMessageBox.Show(ex.Message + errores + numeroError.ToString + vbCrLf + ex.InnerException.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried. numero " + numeroError.ToString) + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
            'End Using
        End If




        If success = True Then
            'ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()

            ' grdVentas.DataSource = Nothing

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
