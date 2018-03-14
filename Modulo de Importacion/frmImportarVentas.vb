Imports System.Data.OleDb
Imports System.Linq
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmImportarVentas


    Private Sub frmImportarVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridMovimientos(Me.grdVentas)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDetalle)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductosNoEncontrados)
        txtUrl.Text = ""
        cmbHojas.Items.Clear()
        cmbHojas.Text = ""
        mdlPublicVars.comboActivarFiltroLista(cmbHojas)

        rbnCotizacion.Checked = True

        fnLLenarCombo()

        'grdVentas.ActiveEditor.BeginEdit()

    End Sub


    Private Sub fnLLenarCombo()
        Try
            Dim resolucion = (From r In ctx.tblResolucionFacturas Select Codigo = r.idResolucion, Nombre = r.resolucion).ToList


            With Me.cmbResolucionFactura
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = resolucion
            End With

        Catch ex As Exception

        End Try
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

            '---------------------------------------    llenar el encabezado.

            grdVentas.DataSource = From x In Ds.Tables(0).AsEnumerable
                                   Where x!documento IsNot DBNull.Value
                                   Select documento = x.Field(Of String)("documento").Trim,
                                    fecha = x.Field(Of String)("fecha"),
                                    cliente = x.Field(Of String)("cliente"),
                                    vendedor = x.Field(Of String)("vendedor"),
                                    codigo = x.Field(Of String)("codigo"),
                                    cantidad = x.Field(Of String)("cantidad"),
                                    costo = x.Field(Of String)("costo"),
                                    precio = x.Field(Of String)("precio") Order By documento Ascending


            lblContadoSi.Text = grdVentas.Rows.Count


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
            Select Codigo = r.Codigo, IdArticulo = a.idArticulo, r.Cantidad, i.saldo, Diferencia = (i.saldo - r.Cantidad)


            Me.grdDetalle.DataSource = consulta



            If Me.grdDetalle.Rows.Count > 0 Then
                Me.grdDetalle.Columns("IdArticulo").IsVisible = False
            End If

            lblContador.Text = grdDetalle.Rows.Count


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

            '-------------------------  CLIENTES NO ENCONTRADOS.

            'clientes que no existen en la base de datos.

            Dim consulta2 =
                From r In (From y In Ds.Tables(0).AsEnumerable
                Where Trim(y.Field(Of String)("cliente")).Length > 0 And y!cliente IsNot DBNull.Value _
                Group By Codigo = Trim(y.Field(Of String)("cliente"))
                Into Cantidad = Count(y.Field(Of String)("cliente"))
                Select Codigo, Cantidad)
                Where (From a In ctx.tblClientes Where a.clave.Trim.ToLower = r.Codigo.Trim.ToLower Select a.idCliente).FirstOrDefault = 0
                Select r.Codigo, r.Cantidad


            'asignar clientes no encontrados.
            Me.grdClientes.DataSource = consulta2


            'contador de clientes.
            lblContadorClientes.Text = Me.grdClientes.Rows.Count

            'cerrar la conexion
            cnConex.Close()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



    End Sub

    Private Function fnGuardar() As Boolean

        Dim success As Boolean = True

        Dim documento As String
        Dim fecha As String = Format(Now, "dd/MM/yyyy").ToString
        Dim claveCliente As String
        Dim vendedor As Integer
        Dim codigoArticulo As String
        Dim cantidad As Integer = 0
        Dim costo As Double = 0
        Dim precio As Double = 0

        Dim docAnterior As String = "0"
        Dim idSalidaAnterior As Integer = 0
        Dim msjError As String = ""
        Dim idfacturaAnterior As Integer = 0

        ' ---------------- DESPACHO ------------------------------
        If rbnDespacho.Checked = True Then
            'If fnErrores() Then
            '    alerta.fnError()
            '    Exit Function

            'Else


            If success = True Then

                Using transaction As New TransactionScope
                    Try

                        For i As Integer = 0 To grdVentas.Rows.Count - 1

                            'verificar que tenga valores el documento.

                            If LTrim(RTrim(grdVentas.Rows(i).Cells("documento").Value)).Length > 0 Then
                                'obtener el documento de la columna
                                documento = LTrim(RTrim(grdVentas.Rows(i).Cells("documento").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(0).ToString))


                                If documento = docAnterior Then

                                    ' agregar el detalle a la salida anterior, id de salida anterior.
                                    Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalidaAnterior Select x).FirstOrDefault

                                    'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                                    codigoArticulo = LTrim(RTrim(grdVentas.Rows(i).Cells("codigo").Value))   ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(4).ToString))
                                    Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1 = codigoArticulo Select y).FirstOrDefault

                                    cantidad = LTrim(RTrim(grdVentas.Rows(i).Cells("cantidad").Value))      'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(5).ToString))
                                    costo = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("costo").Value)), Double), 2)  'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(6).ToString))
                                    precio = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("precio").Value)), Double), 2) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(7).ToString))

                                    'agregar el detalle
                                    Dim detalleNuevo As New tblSalidaDetalle

                                    detalleNuevo.idSalida = salida.idSalida
                                    detalleNuevo.idArticulo = articulo.idArticulo
                                    detalleNuevo.cantidad = cantidad
                                    detalleNuevo.precio = precio
                                    detalleNuevo.comentario = ""
                                    detalleNuevo.costo = costo
                                    detalleNuevo.anulado = 0  'el detalle no stara anulado
                                    detalleNuevo.tipoInventario = mdlPublicVars.General_idTipoInventario     '1 ' Inventario estanteria por defecto
                                    detalleNuevo.tipoPrecio = mdlPublicVars.Empresa_PrecioNormal             ' 5 tipo precio normal por defecto

                                    'guardar el detalle
                                    ctx.AddTotblSalidaDetalles(detalleNuevo)
                                    ctx.SaveChanges()


                                    'Actualizamos el total a la tabla salidas
                                    Dim total = (From x In ctx.tblSalidaDetalles Where x.idSalida = salida.idSalida And x.anulado = False Select x.cantidad * x.precio).Sum

                                    salida.total = total
                                    salida.subtotal = total
                                    ctx.SaveChanges()

                                Else

                                    '   agregar(nuevo)
                                    fecha = LTrim(RTrim(grdVentas.Rows(i).Cells("fecha").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(1).ToString))
                                    claveCliente = LTrim(RTrim(grdVentas.Rows(i).Cells("cliente").Value)) ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(2).ToString))
                                    vendedor = LTrim(RTrim(grdVentas.Rows(i).Cells("vendedor").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(3).ToString))

                                    'capturamos la clave del cliente para hacer una consulta a la tabla tblclientes 
                                    ' y capturar la informacion del cliente para añadirla a la salida

                                    Dim micliente As tblCliente = (From z In ctx.tblClientes Where z.clave = claveCliente Select z).FirstOrDefault

                                    Dim nuevaSalida As New tblSalida

                                    nuevaSalida.documento = documento
                                    nuevaSalida.idEmpresa = mdlPublicVars.idEmpresa
                                    nuevaSalida.idUsuario = mdlPublicVars.idUsuario

                                    nuevaSalida.idCliente = micliente.idCliente
                                    nuevaSalida.idTipoMovimiento = mdlPublicVars.Salida_TipoMovimientoVenta
                                    nuevaSalida.idVendedor = vendedor
                                    nuevaSalida.fechaRegistro = fecha
                                    nuevaSalida.fechaTransaccion = fecha



                                    nuevaSalida.cliente = micliente.Nombre1
                                    nuevaSalida.nit = micliente.nit1
                                    nuevaSalida.direccionFacturacion = micliente.direccionFactura1
                                    nuevaSalida.direccionEnvio = micliente.direccionEnvio1

                                    nuevaSalida.cotizado = 1 'ponemos cotizado por defecto

                                    nuevaSalida.anulado = 0
                                    nuevaSalida.reservado = 0
                                    nuevaSalida.despachar = 1
                                    nuevaSalida.facturado = 0
                                    nuevaSalida.descuento = 0
                                    nuevaSalida.contado = 1
                                    nuevaSalida.credito = 0

                                    nuevaSalida.fechaDespachado = fecha

                                    nuevaSalida.empacado = 0
                                    nuevaSalida.idTipoInventario = mdlPublicVars.General_idTipoInventario
                                    nuevaSalida.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                                    ' guardar.
                                    ctx.AddTotblSalidas(nuevaSalida)
                                    ctx.SaveChanges()

                                    'agregar el detalle
                                    Dim detalle As New tblSalidaDetalle

                                    'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                                    codigoArticulo = LTrim(RTrim(grdVentas.Rows(i).Cells("codigo").Value))  ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(4).ToString))
                                    Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1 = codigoArticulo Select y).FirstOrDefault

                                    cantidad = LTrim(RTrim(grdVentas.Rows(i).Cells("cantidad").Value))    'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(5).ToString))
                                    costo = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("costo").Value)), Double), 2)   'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(6).ToString))
                                    precio = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("precio").Value)), Double), 2) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(7).ToString))

                                    detalle.idSalida = nuevaSalida.idSalida
                                    detalle.idArticulo = articulo.idArticulo
                                    detalle.cantidad = cantidad
                                    detalle.precio = precio
                                    detalle.comentario = ""
                                    detalle.costo = costo

                                    detalle.anulado = 0
                                    detalle.tipoInventario = mdlPublicVars.General_idTipoInventario ' 1 'Inventario estanteria por defecto
                                    detalle.tipoPrecio = mdlPublicVars.Empresa_PrecioNormal ' tipo precio normal 

                                    'guardar el detalle
                                    ctx.AddTotblSalidaDetalles(detalle)
                                    ctx.SaveChanges()

                                    'obtener el id salida para ser utilizado posteriormente si existe un registro con el mismo numero de documento.
                                    idSalidaAnterior = nuevaSalida.idSalida


                                    'actualizamos el total a la tabla salidas en base al detalle de la salida
                                    If documento = 0 Then

                                    Else
                                        Dim total = (From x In ctx.tblSalidaDetalles Where x.idSalida = nuevaSalida.idSalida Select x.cantidad * x.precio).Sum

                                        nuevaSalida.total = total
                                        nuevaSalida.subtotal = total
                                        ctx.SaveChanges()


                                        'ingresamos el despacho en la tabla tblsalidaBodega
                                        Dim despacho As New tblsalidaBodega
                                        despacho.idsalida = nuevaSalida.idSalida

                                        ctx.AddTotblsalidaBodegas(despacho)
                                        ctx.SaveChanges()


                                    End If

                                End If

                                'asignar el documento anterior 
                                docAnterior = documento

                            End If
                        Next


                        'Actualizamos el inventario

                        For i As Integer = 0 To grdDetalle.Rows.Count - 1
                            Dim idArticulo As Integer
                            Dim cantidadVendida As Integer


                            idArticulo = CType(LTrim(RTrim(grdDetalle.Rows(i).Cells("IdArticulo").Value)), Integer)
                            cantidadVendida = CType(LTrim(RTrim(grdDetalle.Rows(i).Cells("Cantidad").Value)), Integer)


                            Dim inventario = (From z In ctx.tblInventarios Where z.idArticulo = idArticulo And z.idTipoInventario = mdlPublicVars.General_idTipoInventario And z.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal Select z).FirstOrDefault

                            'sumamos a la salida la cantidad de articulos
                            inventario.salida = inventario.salida + cantidadVendida

                            'Descontamos del saldo la cantidad
                            inventario.saldo = inventario.saldo - cantidadVendida
                            ctx.SaveChanges()
                        Next




                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        ' Handle errors and deadlocks here and retry if needed. 
                        ' Allow an UpdateException to pass through and 
                        ' retry, otherwise stop the execution. 
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            success = False
                            MessageBox.Show("Error ")
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

        End If
        'End If




        ' ----------------COTIZACION------------------------------

        If rbnCotizacion.Checked = True Then

            If success = True Then

                Using transaction As New TransactionScope
                    Try


                        For i As Integer = 0 To grdVentas.Rows.Count - 1
                            documento = LTrim(RTrim(grdVentas.Rows(i).Cells("documento").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(0).ToString))

                            If documento = docAnterior Then

                                ' agregar el detalle a la salida anterior, id de salida anterior.
                                Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalidaAnterior Select x).FirstOrDefault

                                'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                                codigoArticulo = LTrim(RTrim(grdVentas.Rows(i).Cells("codigo").Value))   ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(4).ToString))
                                Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1 = codigoArticulo Select y).FirstOrDefault

                                cantidad = LTrim(RTrim(grdVentas.Rows(i).Cells("cantidad").Value))      'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(5).ToString))
                                costo = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("costo").Value)), Double), 2)  'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(6).ToString))
                                precio = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("precio").Value)), Double), 2) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(7).ToString))

                                'agregar el detalle
                                Dim detalleNuevo As New tblSalidaDetalle

                                detalleNuevo.idSalida = salida.idSalida
                                detalleNuevo.idArticulo = articulo.idArticulo
                                detalleNuevo.cantidad = cantidad
                                detalleNuevo.precio = precio
                                detalleNuevo.comentario = ""
                                detalleNuevo.costo = costo
                                detalleNuevo.anulado = 0  'el detalle no stara anulado
                                detalleNuevo.tipoInventario = mdlPublicVars.General_idTipoInventario     '1 ' Inventario estanteria por defecto
                                detalleNuevo.tipoPrecio = mdlPublicVars.Empresa_PrecioNormal             ' 5 tipo precio normal por defecto

                                'guardar el detalle
                                ctx.AddTotblSalidaDetalles(detalleNuevo)
                                ctx.SaveChanges()


                                'Actualizamos el total a la tabla salidas
                                Dim total = (From x In ctx.tblSalidaDetalles Where x.idSalida = salida.idSalida And x.anulado = False Select x.cantidad * x.precio).Sum

                                salida.total = total
                                salida.subtotal = total
                                ctx.SaveChanges()


                            Else

                                '   agregar(nuevo)
                                fecha = LTrim(RTrim(grdVentas.Rows(i).Cells("fecha").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(1).ToString))
                                claveCliente = LTrim(RTrim(grdVentas.Rows(i).Cells("cliente").Value)) ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(2).ToString))
                                vendedor = LTrim(RTrim(grdVentas.Rows(i).Cells("vendedor").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(3).ToString))

                                'capturamos la clave del cliente para hacer una consulta a la tabla tblclientes 
                                ' y capturar la informacion del cliente para añadirla a la salida

                                Dim micliente As tblCliente = (From z In ctx.tblClientes Where z.clave = claveCliente Select z).FirstOrDefault

                                Dim nuevaSalida As New tblSalida

                                nuevaSalida.documento = documento
                                nuevaSalida.idEmpresa = mdlPublicVars.idEmpresa
                                nuevaSalida.idUsuario = mdlPublicVars.idUsuario

                                nuevaSalida.idCliente = micliente.idCliente
                                nuevaSalida.idTipoMovimiento = mdlPublicVars.Salida_TipoMovimientoVenta
                                nuevaSalida.idVendedor = vendedor
                                nuevaSalida.fechaRegistro = fecha
                                nuevaSalida.fechaTransaccion = fecha

                                nuevaSalida.cliente = micliente.Nombre1
                                nuevaSalida.nit = micliente.nit1
                                nuevaSalida.direccionFacturacion = micliente.direccionFactura1
                                nuevaSalida.direccionEnvio = micliente.direccionEnvio1

                                nuevaSalida.cotizado = 1 'ponemos cotizado por defecto

                                nuevaSalida.anulado = 0
                                nuevaSalida.reservado = 0
                                nuevaSalida.despachar = 0
                                nuevaSalida.facturado = 0
                                nuevaSalida.descuento = 0
                                nuevaSalida.contado = 1
                                nuevaSalida.credito = 0

                                nuevaSalida.empacado = 0
                                nuevaSalida.idTipoInventario = mdlPublicVars.General_idTipoInventario
                                nuevaSalida.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                                ' guardar.
                                ctx.AddTotblSalidas(nuevaSalida)
                                ctx.SaveChanges()

                                'agregar el detalle
                                Dim detalle As New tblSalidaDetalle

                                'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                                codigoArticulo = LTrim(RTrim(grdVentas.Rows(i).Cells("codigo").Value))  ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(4).ToString))
                                Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1 = codigoArticulo Select y).FirstOrDefault

                                cantidad = LTrim(RTrim(grdVentas.Rows(i).Cells("cantidad").Value))    'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(5).ToString))
                                costo = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("costo").Value)), Double), 2)   'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(6).ToString))
                                precio = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("precio").Value)), Double), 2) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(7).ToString))

                                detalle.idSalida = nuevaSalida.idSalida
                                detalle.idArticulo = articulo.idArticulo
                                detalle.cantidad = cantidad
                                detalle.precio = precio
                                detalle.comentario = ""
                                detalle.costo = costo

                                detalle.anulado = 0
                                detalle.tipoInventario = mdlPublicVars.General_idTipoInventario ' 1 'Inventario estanteria por defecto
                                detalle.tipoPrecio = mdlPublicVars.Empresa_PrecioNormal ' tipo precio normal 

                                'guardar el detalle
                                ctx.AddTotblSalidaDetalles(detalle)
                                ctx.SaveChanges()

                                'obtener el id salida para ser utilizado posteriormente si existe un registro con el mismo numero de documento.
                                idSalidaAnterior = nuevaSalida.idSalida


                                'actualizamos el total a la tabla salidas en base al detalle de la salida
                                If documento = 0 Then

                                Else
                                    Dim total = (From x In ctx.tblSalidaDetalles Where x.idSalida = nuevaSalida.idSalida Select x.cantidad * x.precio).Sum

                                    nuevaSalida.total = total
                                    ctx.SaveChanges()

                                End If

                                '' ------------------------------------------------------------------------------

                                ''Actualizamos el inventario
                                'Dim inventario = (From z In ctx.tblInventarios Where z.idArticulo = articulo.idArticulo And z.idTipoInventario = mdlPublicVars.General_idTipoInventario And z.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal Select z).FirstOrDefault

                                ''sumamos a la salida la cantidad de articulos
                                'inventario.salida = inventario.salida + cantidad

                                ''Descontamos del saldo la cantidad
                                'inventario.saldo = inventario.saldo - cantidad
                                'ctx.SaveChanges()


                                '' -----------------------------------------------------------

                            End If

                            docAnterior = documento
                        Next

                        'paso 8, completar la transaccion.
                        transaction.Complete()
                    Catch ex As System.Data.EntityException
                        success = False
                    Catch ex As Exception
                        ' Handle errors and deadlocks here and retry if needed. 
                        ' Allow an UpdateException to pass through and 
                        ' retry, otherwise stop the execution. 
                        If ex.[GetType]() <> GetType(UpdateException) Then
                            success = False
                            Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                            alerta.fnErrorGuardar()
                            Exit Try
                            ' If we get to this point, the operation will be retried. 
                        End If
                    End Try
                End Using
            End If

        End If





        ' ---------------- FATURACION ------------------------------


        If rbnFacturacion.Checked = True Then
            Dim idsalida As Integer = 0
            Dim contadorDetalle As Integer = 0
            'If fnErrores() Then
            '    alerta.fnError()
            '    Exit Function
            'Else
            barraProceso.StartWaiting()

            If success = True Then


                'Using transaction As New TransactionScope
                Try

                    barDocumentos.Value1 = 0

                    For i As Integer = 0 To grdVentas.Rows.Count - 1
                        msjError = i
                        barDocumentos.Value1 = (i / grdVentas.Rows.Count) * 100
                        barDocumentos.Text = (i / grdVentas.Rows.Count) * 100
                        System.Threading.Thread.Sleep(100)

                        documento = LTrim(RTrim(grdVentas.Rows(i).Cells("documento").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(0).ToString))

                        If documento = docAnterior Then



                            contadorDetalle = 1

                            ' agregar el detalle a la salida anterior, id de salida anterior.
                            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalidaAnterior Select x).FirstOrDefault
                            'obtener el id de salida 
                            idsalida = salida.idSalida

                            If salida Is Nothing Then
                                msjError += " id salida " & idSalidaAnterior
                                MessageBox.Show("Salida no existe " & msjError)
                            End If

                            'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                            codigoArticulo = LTrim(RTrim(grdVentas.Rows(i).Cells("codigo").Value))   ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(4).ToString))
                            Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1.Trim.ToLower = codigoArticulo.Trim.ToLower Select y).FirstOrDefault

                            If articulo Is Nothing Then
                                msjError += " articulo " & codigoArticulo
                                MessageBox.Show(" articulo no existe " & msjError)
                            End If

                            cantidad = LTrim(RTrim(grdVentas.Rows(i).Cells("cantidad").Value))      'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(5).ToString))
                            costo = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("costo").Value)), Double), 2)  'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(6).ToString))
                            precio = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("precio").Value)), Double), 2) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(7).ToString))

                            'agregar el detalle
                            Dim detalleNuevo As New tblSalidaDetalle

                            detalleNuevo.idSalida = salida.idSalida
                            detalleNuevo.idArticulo = articulo.idArticulo
                            detalleNuevo.cantidad = cantidad
                            detalleNuevo.precio = precio
                            detalleNuevo.comentario = ""
                            detalleNuevo.costo = costo
                            detalleNuevo.anulado = 0  'el detalle no stara anulado
                            detalleNuevo.tipoInventario = mdlPublicVars.General_idTipoInventario     '1 ' Inventario estanteria por defecto
                            detalleNuevo.tipoPrecio = mdlPublicVars.Empresa_PrecioNormal             ' 5 tipo precio normal por defecto

                            'guardar el detalle
                            ctx.AddTotblSalidaDetalles(detalleNuevo)
                            ctx.SaveChanges()

                            'actualizar el saldo del cliente.
                            'Actualizar el total de la salida e incrementar en clientes.
                            Dim clientActualizar As tblCliente = (From c In ctx.tblClientes Where c.idCliente = detalleNuevo.tblSalida.idCliente Select c).FirstOrDefault
                            clientActualizar.saldo += detalleNuevo.cantidad * detalleNuevo.precio
                            ctx.SaveChanges()


                            'Actualizamos el total a la tabla salidas
                            Dim total = (From x In ctx.tblSalidaDetalles Where x.idSalida = salida.idSalida And x.anulado = False Select x.cantidad * x.precio).Sum

                            salida.total = total
                            salida.subtotal = total
                            ctx.SaveChanges()

                            'Actualizamos la tabla factura 
                            Dim factura = (From y In ctx.tblFacturas Where y.IdFactura = idfacturaAnterior Select y).FirstOrDefault
                            factura.monto = salida.total
                            factura.saldo = salida.total
                            ctx.SaveChanges()



                        Else
                            contadorDetalle += 1
                            'Se crea un nuevo registro.


                            '   agregar(nuevo)
                            fecha = LTrim(RTrim(grdVentas.Rows(i).Cells("fecha").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(1).ToString))
                            claveCliente = LTrim(RTrim(grdVentas.Rows(i).Cells("cliente").Value)) ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(2).ToString))
                            vendedor = LTrim(RTrim(grdVentas.Rows(i).Cells("vendedor").Value)) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(3).ToString))

                            'capturamos la clave del cliente para hacer una consulta a la tabla tblclientes 
                            ' y capturar la informacion del cliente para añadirla a la salida

                            Dim micliente As tblCliente = (From z In ctx.tblClientes Where z.clave = claveCliente Select z).FirstOrDefault

                            If micliente Is Nothing Then
                                msjError += " id cliente " & claveCliente
                                MessageBox.Show("cliente no existe " & msjError)
                            End If

                            Dim nuevaSalida As New tblSalida

                            nuevaSalida.documento = documento
                            nuevaSalida.idEmpresa = mdlPublicVars.idEmpresa
                            nuevaSalida.idUsuario = mdlPublicVars.idUsuario

                            nuevaSalida.idCliente = micliente.idCliente
                            nuevaSalida.idTipoMovimiento = mdlPublicVars.Salida_TipoMovimientoVenta
                            nuevaSalida.idVendedor = vendedor
                            nuevaSalida.fechaRegistro = fecha
                            nuevaSalida.fechaTransaccion = fecha



                            nuevaSalida.cliente = micliente.Nombre1
                            nuevaSalida.nit = micliente.nit1
                            nuevaSalida.direccionFacturacion = micliente.direccionFactura1
                            nuevaSalida.direccionEnvio = micliente.direccionEnvio1

                            nuevaSalida.cotizado = 1 'ponemos cotizado por defecto

                            nuevaSalida.anulado = 0
                            nuevaSalida.reservado = 0
                            nuevaSalida.despachar = 1
                            nuevaSalida.facturado = 0
                            nuevaSalida.descuento = 0
                            nuevaSalida.contado = 1
                            nuevaSalida.credito = 0
                            nuevaSalida.fechaDespachado = fecha

                            nuevaSalida.empacado = 0
                            nuevaSalida.idTipoInventario = mdlPublicVars.General_idTipoInventario
                            nuevaSalida.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                            ' guardar.
                            ctx.AddTotblSalidas(nuevaSalida)
                            ctx.SaveChanges()

                            'obtener el id de salida
                            idsalida = nuevaSalida.idSalida

                            'agregar el detalle
                            Dim detalle As New tblSalidaDetalle

                            'capturamos el codigo del articulo y acemos una consulta para obtener el idArticulo y agregar al detalle
                            codigoArticulo = LTrim(RTrim(grdVentas.Rows(i).Cells("codigo").Value))  ' LTrim(RTrim(Ds.Tables(0).Rows(index).Item(4).ToString))
                            Dim articulo As tblArticulo = (From y In ctx.tblArticuloes Where y.codigo1.Trim.ToLower = codigoArticulo.Trim.ToLower Select y).FirstOrDefault

                            If articulo Is Nothing Then
                                msjError += " id articulo " & codigoArticulo
                                MessageBox.Show("articulo no existe " & msjError)
                            Else

                            End If

                            cantidad = LTrim(RTrim(grdVentas.Rows(i).Cells("cantidad").Value))    'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(5).ToString))
                            costo = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("costo").Value)), Double), 2)   'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(6).ToString))
                            precio = Math.Round(CType(LTrim(RTrim(grdVentas.Rows(i).Cells("precio").Value)), Double), 2) 'LTrim(RTrim(Ds.Tables(0).Rows(index).Item(7).ToString))

                            detalle.idSalida = nuevaSalida.idSalida
                            detalle.idArticulo = articulo.idArticulo
                            detalle.cantidad = cantidad
                            detalle.precio = precio
                            detalle.comentario = ""
                            detalle.costo = costo

                            detalle.anulado = 0
                            detalle.tipoInventario = mdlPublicVars.General_idTipoInventario ' 1 'Inventario estanteria por defecto
                            detalle.tipoPrecio = mdlPublicVars.Empresa_PrecioNormal ' tipo precio normal 

                            'guardar el detalle
                            ctx.AddTotblSalidaDetalles(detalle)
                            ctx.SaveChanges()

                            'actualizar el saldo del cliente.
                            'Actualizar el total de la salida e incrementar en clientes.
                            Dim clientActualizar As tblCliente = (From c In ctx.tblClientes Where c.idCliente = detalle.tblSalida.idCliente Select c).FirstOrDefault
                            clientActualizar.saldo += detalle.cantidad * detalle.precio
                            ctx.SaveChanges()

                            'obtener el id salida para ser utilizado posteriormente si existe un registro con el mismo numero de documento.
                            idSalidaAnterior = nuevaSalida.idSalida




                            'actualizamos el total a la tabla salidas en base al detalle de la salida
                            If documento = 0 Then

                            Else
                                Dim total = (From x In ctx.tblSalidaDetalles Where x.idSalida = nuevaSalida.idSalida Select x.cantidad * x.precio).Sum

                                nuevaSalida.total = total
                                nuevaSalida.subtotal = total
                                ctx.SaveChanges()


                                'ingresamos el despacho en la tabla tblsalidaBodega
                                Dim despacho As New tblsalidaBodega
                                despacho.idsalida = nuevaSalida.idSalida
                                despacho.empacado = mdlPublicVars.idUsuario
                                despacho.sacado = mdlPublicVars.idUsuario
                                despacho.revisado = mdlPublicVars.idUsuario
                                despacho.fechaEmpacado = fecha
                                despacho.fechaRevisado = fecha
                                despacho.fechaSacado = fecha

                                ctx.AddTotblsalidaBodegas(despacho)
                                ctx.SaveChanges()



                                '---------- Creamos la Factura a la nueva Salida ---------------
                                Dim NoCorrelativo As Integer = 0
                                Dim codigoFactura As Integer = 0
                                Dim serie As String = ""



                                Dim DataCorrelativo = (From x In ctx.tblCorrelativos _
                                 Where x.idTipoMovimiento = mdlPublicVars.Factura_CodigoMovimiento And x.idEmpresa = mdlPublicVars.idEmpresa _
                                 Select x).FirstOrDefault


                                If DataCorrelativo Is Nothing Then
                                    Dim nuevoCorrelativo As New tblCorrelativo
                                    nuevoCorrelativo.idEmpresa = mdlPublicVars.idEmpresa
                                    nuevoCorrelativo.idTipoMovimiento = mdlPublicVars.Factura_CodigoMovimiento
                                    nuevoCorrelativo.correlativo = 1
                                    nuevoCorrelativo.serie = "A"
                                    ctx.AddTotblCorrelativos(nuevoCorrelativo)
                                    ctx.SaveChanges()
                                    NoCorrelativo = nuevoCorrelativo.correlativo
                                    nuevoCorrelativo.correlativo = NoCorrelativo
                                    ctx.SaveChanges()

                                    serie = nuevoCorrelativo.serie
                                Else
                                    NoCorrelativo = DataCorrelativo.correlativo + 1
                                    DataCorrelativo.correlativo = (NoCorrelativo)
                                    ctx.SaveChanges()

                                    serie = DataCorrelativo.serie
                                End If


                                ' Dim resolucion = (From r In ctx.tblResolucionFacturas Select r)

                                Dim factura As New tblFactura

                                factura.Fecha = fecha
                                factura.Idusuario = mdlPublicVars.idUsuario
                                factura.Monto = nuevaSalida.total
                                factura.pagos = 0
                                factura.pagosTransito = 0
                                factura.saldo = nuevaSalida.total
                                factura.FechaTransaccion = fecha
                                factura.serieFactura = serie
                                factura.DocumentoFactura = NoCorrelativo
                                factura.anulado = 0
                                factura.pagado = 0
                                factura.credito = 0
                                factura.contado = 1
                                factura.idResolucion = cmbResolucionFactura.SelectedValue



                                ctx.AddTotblFacturas(factura)
                                ctx.SaveChanges()

                                idfacturaAnterior = factura.IdFactura

                                'igresamos el idFactura a la salida
                                nuevaSalida.IdFactura = factura.IdFactura
                                nuevaSalida.facturado = 1
                                nuevaSalida.empacado = 1
                                ctx.SaveChanges()

                            End If

                        End If


                        docAnterior = documento


                    Next


                    'Actualizamos el inventario

                    For i As Integer = 0 To grdDetalle.Rows.Count - 1
                        Dim idArticulo As Integer
                        Dim cantidadVendida As Integer


                        idArticulo = CType(LTrim(RTrim(grdDetalle.Rows(i).Cells("IdArticulo").Value)), Integer)
                        cantidadVendida = CType(LTrim(RTrim(grdDetalle.Rows(i).Cells("Cantidad").Value)), Integer)


                        Dim inventario = (From z In ctx.tblInventarios Where z.idArticulo = idArticulo And z.idTipoInventario = mdlPublicVars.General_idTipoInventario And z.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal Select z).FirstOrDefault

                        'sumamos a la salida la cantidad de articulos
                        inventario.salida = inventario.salida + cantidadVendida

                        'Descontamos del saldo la cantidad
                        inventario.saldo = inventario.saldo - cantidadVendida
                        ctx.SaveChanges()
                    Next


                    'paso 8, completar la transaccion.
                    ' transaction.Complete()
                    'Catch ex As System.Data.EntityException
                    ' success = False
                Catch ex As Exception
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        success = False
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        MessageBox.Show("Error al guardar " + msjError)
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try
                ' End Using
            End If

        End If



        barraProceso.EndWaiting()

        If success = True Then
            'ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()

            ' grdVentas.DataSource = Nothing

        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If


    End Function


    Private Sub frm_GuardarRegistros() Handles Me.panel0
        fnGuardar()
    End Sub


    Private Sub frm_Salir() Handles Me.panel1
        Me.Close()
    End Sub



    Private Sub fnLLenarDetalle()

        Try
            Dim dt As New DataTable
            dt = TryCast(grdVentas.DataSource, DataTable)

            Try
                'Dim consulta = (From y In dt.AsEnumerable
                '            Join z In ctx.tblArticuloes On z.codigo1.Trim.ToLower Equals y.Field(Of String)("codigo").Trim.ToLower Join
                '            w In ctx.tblInventarios On w.idArticulo Equals z.idArticulo
                '            Where w.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And y.Field(Of String)("documento").Length > 0 _
                '            And w.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                '            And y.Field(Of String)("codigo").Length > 0
                '           Group By Codigo = y.Field(Of String)("codigo"), IdArticulo = z.idArticulo, Saldo = w.saldo _
                '           Into Cantidad = Sum(y.Field(Of Double)("cantidad"))
                '           Select Codigo, IdArticulo, Cantidad, Saldo, Diferencia = (Saldo - Cantidad))
                

                Dim consulta =
                    From r In
                    (From y In dt.AsEnumerable
                    Where Trim(y.Field(Of String)("codigo")).Length > 0 And y!codigo IsNot DBNull.Value _
                    Group By Codigo = Trim(y.Field(Of String)("codigo"))
                    Into Cantidad = Sum(y.Field(Of Double)("cantidad"))
                    Select Codigo, Cantidad)
                Join a In ctx.tblArticuloes On a.codigo1.Trim.ToLower Equals r.Codigo.ToLower
                Select Codigo = r.Codigo, IdArticulo = a.idArticulo, r.Cantidad


                Me.grdDetalle.DataSource = consulta

            Catch ex As Exception

            End Try
            



            If Me.grdDetalle.Rows.Count > 0 Then
                Me.grdDetalle.Columns("IdArticulo").IsVisible = False
            End If

            lblContador.Text = grdDetalle.Rows.Count

        Catch ex As Exception

        End Try



    End Sub




    'Private Function fnErrores() As Boolean
    '    Dim errorres As Boolean = False

    '    For i As Integer = 0 To grdDetalle.Rows.Count - 1
    '        Dim valor As Integer

    '        valor = CType(LTrim(RTrim(grdDetalle.Rows(i).Cells("Diferencia").Value)), Integer)


    '        If valor < 0 Then
    '            errorres = True
    '        End If

    '    Next

    '    Return errorres

    'End Function



    Private Sub grdVentas_CellEndEdit(sender As System.Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdVentas.CellEndEdit

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        fnActualizar()
    End Sub
End Class