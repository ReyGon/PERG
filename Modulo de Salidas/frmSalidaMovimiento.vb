Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmSalidaMovimiento
    Dim b As New clsBase
    Dim nextItem As Object

    'Variables para guardar el total a pagar y descuento de la salida que se selecciona.
    Dim totalPagar As Double = 0
    Dim descuento As Double = 0

    Private Sub frmSalidaMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion

        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        FnLlenarCombos()
        fnLlenarGrid()
        fnConfiguracion()

    End Sub


    Private Sub fnLlenarGrid()
        Dim fechai As DateTime = dtpFechaInicio.Text + " 00:00:00"
        Dim fechaf As DateTime = dtpFechaFin.Text + " 23:59:59"
        Dim codclie As Integer = cmbCliente.SelectedValue
        Dim codven As Integer = cmbVendedor.SelectedValue


        Try
            Dim sp = ctx.sp_salida_mov_lista(mdlPublicVars.idEmpresa, fechai, fechaf, codven)


            'Dim list = (From x In ctx.tblSalidas Where x.idSalida >= 1150 And x.idEmpresa = mdlPublicVars.idEmpresa And x.anulado = False _
            '        And x.fechaRegistro >= fechai And x.fechaRegistro <= fechaf And (codclie = 0 Or (codclie > 0 And x.tblCliente.idCliente = codclie)) _
            '        And (codven = 0 Or (codven > 0 And x.tblVendedor.idVendedor = codven)) _
            '      Select Codigo = x.idSalida, Fecha = x.fechaRegistro, Cliente = x.tblCliente.nombre, Vendedor = x.tblVendedor.nombre, Documento = x.documento, _
            '     Cotizado = x.cotizado, Reservado = x.reservado, Despachado = x.despachar, Facturado = x.facturado, Total = x.total)

            Me.grdDatos.DataSource = sp

        Catch ex As Exception
        End Try

        'Agregamos un color para cada tipo de estado de salida.
        'Aqui la columna estado para a color rojo cuando solo ha sido cotizado
        'mdlPublicVars.GridColor(grdDatos, Color.DarkRed, "Cotizado", "Estado")

        'Asignamos al estado un color Anaranjado cuando ha sido Resevado
        'mdlPublicVars.GridColor(grdDatos, Color.Orange, "Reservado", "Estado")

        'Asignamos el color Verde cuando la Salida ha sido por despacho.
        'mdlPublicVars.GridColor(grdDatos, Color.Green, "Despachado", "Estado")


    End Sub


    Private Sub FnLlenarCombos()
        Dim t As New DataTable
        t.Columns.Add("Codigo")
        t.Columns.Add("Nombre")

        t.Rows.Add(0, "Todos ...")

        Dim cli = (From x In ctx.tblClientes Where x.habillitado = True Select Codigo = x.idCliente, Nombre = x.Negocio)

        Dim v
        For Each v In cli
            t.Rows.Add(CType(v.codigo, Integer), v.nombre)
        Next

        With Me.cmbCliente
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = t
        End With

        Dim t2 As New DataTable
        t2.Columns.Add("Codigo")
        t2.Columns.Add("Nombre")

        t2.Rows.Add(0, "Todos ...")


        Dim ven = From x In ctx.tblVendedors Select Codigo = x.idVendedor, Nombre = x.nombre

        For Each v In ven
            t2.Rows.Add(CType(v.codigo, Integer), v.nombre)
        Next

        With Me.cmbVendedor
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = t2
        End With


    End Sub

    Private Sub fnConfiguracion()
        dtpFechaInicio.Value = mdlPublicVars.fnFecha_horaServidor
        dtpFechaFin.Value = mdlPublicVars.fnFecha_horaServidor

        Try
            If Me.grdDatos.Columns.Count > 0 Then
                Me.grdDatos.Columns(0).Width = 40 '  codigo
                Me.grdDatos.Columns(1).Width = 60 '  Fecha
                Me.grdDatos.Columns(2).Width = 70 '  cliente
                Me.grdDatos.Columns(3).Width = 70 '  vendedor
                Me.grdDatos.Columns(4).Width = 70 '  docu

                Me.grdDatos.Columns(5).Width = 70 '  cotizado
                Me.grdDatos.Columns(6).Width = 70 '  reservado
                Me.grdDatos.Columns(7).Width = 70 '  despachado
                Me.grdDatos.Columns(8).Width = 50 '  facturado
                Me.grdDatos.Columns(9).Width = 100 '  Total


                Me.grdDatos.Columns(0).ReadOnly = True ' codigo
                Me.grdDatos.Columns(1).ReadOnly = True ' fecha
                Me.grdDatos.Columns(2).ReadOnly = True ' cliente
                Me.grdDatos.Columns(3).ReadOnly = True ' vendedor
                Me.grdDatos.Columns(4).ReadOnly = True ' doc
                Me.grdDatos.Columns(5).ReadOnly = True ' coti
                Me.grdDatos.Columns(6).ReadOnly = True ' reser
                Me.grdDatos.Columns(7).ReadOnly = True ' des
                Me.grdDatos.Columns(8).ReadOnly = True ' fac
                Me.grdDatos.Columns(9).ReadOnly = True ' total

                'Me.grdDatos.Columns(10).ReadOnly = True ' tipoGuia


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub pbBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBuscar.Click, lblBuscar.Click
        fnLlenarGrid()
    End Sub

    
    Private Sub pbReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReporte.Click, lblEnvio.Click
        Try
            Dim codigo As Integer = Me.grdDatos.Rows(Me.grdDatos.SelectedRows(0).Index).Cells(0).Value

            Dim s As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codigo Select x).First

            'no facturado y despachado.

            If s.facturado = False And s.despachar = True Then
                frmSalidaEnvio.Codigo = codigo
                frmSalidaEnvio.Text = "Envios ..."
                frmSalidaEnvio.StartPosition = FormStartPosition.CenterScreen
                frmSalidaEnvio.ShowDialog()
            Else
                alerta.fnNoEditable()
            End If

        Catch ex As Exception
            alerta.fnError()
        End Try

    End Sub

    Private Sub pbModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbModificar.Click, lblModificar.Click
        Try
            Dim codigo As Integer = Me.grdDatos.Rows(Me.grdDatos.SelectedRows(0).Index).Cells(0).Value
            frmSalidas.Text = "Editar Salida "
            frmSalidas.codigo = codigo
            frmSalidas.bitEditarBodega = False
            frmSalidas.bitEditarSalida = True
            frmSalidas.MdiParent = frmMenuPrincipal
            frmSalidas.Show()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub grdDatos_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdDatos.CellFormatting
        b.fnFormato(sender, e)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbldespachar.Click
        DespacharSalida()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbdespachar.Click
        DespacharSalida()
    End Sub

    Private Sub DespacharSalida()
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""

        'Variable para conocer el codigo ó IdSalida que se tiene seleccinado de la tabla.
        Dim Codigo As Integer = grdDatos.SelectedRows.Item(0).Cells(0).Value

        'Realizamos la consulta del primer registro con el codigo seleccionado en el grid.
        Dim Datos As tblSalida = (From d In ctx.tblSalidas Where d.idSalida = Codigo Select d).First()


        'Revisamos si la consulta viene con resultado, de lo contrario mandamos un error.
        If Datos.idSalida = Nothing Then

            alerta.contenido = "No se encontró el registro seleccinado, Trate de Acualizar el listado!!!"
            alerta.fnErrorContenido()
            success = False

        Else

            'Verificamos que la salida no haya sido Despachado ó Facturado.
            If Datos.despachar = True Then
                alerta.contenido = "Vaya!, La salida que ha selecciona ya ha sido Despachado.!!!"
                alerta.fnErrorContenido()
                success = False
                Exit Sub
            End If

            totalPagar = Datos.total
            descuento = Datos.descuento

            'Si el estado de la salida es Cotizado, es necesario verificar la existencia de todos los productos cotizados
            'Si estan disponibles se procede a bajar de inventario
            If Datos.cotizado = True And Datos.reservado = False And Datos.despachar = False Then
                'Funcion que permite modificar el registro de salida y el registro de Articulos empresa
                'pasando de una salida cotizado a despachado.
                CambiacotizarAdespacho(Codigo, Datos.credito, Datos.idCliente)

            ElseIf Datos.reservado = True And Datos.despachar = False Then
                ''Funcion que permite modificar los registros de salida y de articulsoempresa
                'Permite pasar de estado Reservado a Despachado
                CambiaReservarAdespacho(Codigo, Datos.credito, Datos.idCliente)

            End If
            fnLlenarGrid()
        End If
    End Sub

    'Procedimiento que permite cambiar el Estado de una salida de Cotizado a Despachado.
    Public Sub CambiacotizarAdespacho(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer)
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()

        Using transaction As New TransactionScope
            Try

                'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
                Dim Detalles
                Dim ArtEmpresa
                Dim fila

                'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                Dim NombreArt As String
                Dim CodArticulo As Integer
                Dim Pedido As Integer
                Dim saldo As Integer

                Detalles = From x In ctx.tblSalidaDetalles Join y In ctx.tblArticuloes On x.idArticulo Equals y.idArticulo Where x.idSalida = codigo Select x.idArticulo, x.cantidad, y.nombre1


                'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
                For Each fila In Detalles
                    NombreArt = fila.nombre1
                    CodArticulo = fila.idarticulo
                    Pedido = fila.cantidad

                    'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                    ArtEmpresa = (From AE In ctx.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa And AE.idArticulo = CodArticulo Select AE).First

                    If ArtEmpresa.saldo < Pedido Then
                        saldo = Pedido - ArtEmpresa.saldo
                        'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                        errContenido = errContenido & "El articulo: " & NombreArt & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo & vbCrLf
                        success = False
                    End If

                Next

                'Si existe un error mandamos el mensaje e interrumpimos la aplicación
                If success = False Then
                    alerta.contenido = errContenido
                    alerta.fnFaltantes()
                    Exit Try
                End If

                'VERIFICAR CREDITO.

                If EsCredito = True Then
                    Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = CodCliente Select x).First

                    Dim saldoCredito As Double = 0
                    'consultar cta por cobrar del cliente.
                    Dim cta = From x In ctx.tblCtaCobrars _
                        Where x.idCliente = CodCliente _
                        Group By x.idCliente _
                        Into SaldoCobrar = Sum(x.saldo) _
                        Select SaldoCobrar

                    Dim item
                    For Each item In cta
                        saldoCredito = saldoCredito + item
                    Next

                    'Paso 2, si excede limite de credito.
                    If VerificaCredito(cli.porcentajeCredito, cli.limiteCredito, cli.diasCredito, saldoCredito) = True Then

                        'Paso 3, solicitar autorizacion
                        If RadMessageBox.Show("Desea Autorizar", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            RadMessageBox.Show("Autorizacion correcta, despacho aceptado ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        Else
                            alerta.contenido = "Registro no guardado !!!"
                            alerta.fnErrorContenido()
                            success = False
                            Exit Try
                        End If
                    End If
                End If

                'crear registro de salida bodega.

                Dim sb As New tblsalidaBodega
                sb.idsalida = codigo
                ctx.AddTotblsalidaBodegas(sb)
                ctx.SaveChanges()

                'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                Dim salida As tblSalida = (From x In ctx.tblSalidas _
                                              Where x.idSalida = codigo Select x).First


                'pasar despachar a true
                If EsCredito = True Then
                    salida.despachar = True
                    Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim dia = Weekday(fechaVencimiento, vbMonday)
                    Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = CodCliente Select x).First
                    Dim diasCredito As Integer = (From x In ctx.tblClienteTipoPagoes Where x.idtipoPago = cli.idTipoPago Select x.dias).First

                    If diasCredito = 5 Then
                        If dia = 1 Then
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito)
                        Else
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 1)
                        End If
                    End If

                    If diasCredito = 20 Then
                        If dia >= 1 And dia <= 4 Then
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 3)
                        Else
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 4)
                        End If
                    End If
                Else
                    salida.despachar = True
                End If

                ctx.SaveChanges()

                'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                For Each fila In Detalles
                    CodArticulo = fila.idarticulo
                    Pedido = fila.cantidad

                    'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                    Dim inve As tblInventario = (From x In ctx.tblInventarios _
                                                  Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = CodArticulo Select x).First

                    'descontar existencias.
                    inve.saldo = inve.saldo - Pedido
                    saldo = 0
                    ctx.SaveChanges()

                Next

                'completar la transaccion.
                transaction.Complete()

            Catch ex As System.Data.EntityException
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
        Else
            Console.WriteLine("La operacion no pudo ser completada")
        End If


    End Sub

    'Procedimiento que permite cambiar el estado de una cotización a Despachado.
    Public Sub CambiaReservarAdespacho(ByVal codigo As String, ByVal escredito As Boolean, ByVal codcliente As Integer)
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()

        Using transaction As New TransactionScope

            Try
                'VERIFICAR CREDITO.

                If escredito = True Then
                    Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codcliente Select x).First

                    Dim saldoCredito As Double = 0
                    'consultar cta por cobrar del cliente.
                    Dim cta = From x In ctx.tblCtaCobrars _
                        Where x.idCliente = codcliente _
                        Group By x.idCliente _
                        Into SaldoCobrar = Sum(x.saldo) _
                        Select SaldoCobrar

                    Dim item
                    For Each item In cta
                        saldoCredito = saldoCredito + item
                    Next

                    'Paso 2, si excede limite de credito.
                    If VerificaCredito(cli.porcentajeCredito, cli.limiteCredito, cli.diasCredito, saldoCredito) = True Then

                        'Paso 3, solicitar autorizacion
                        If RadMessageBox.Show("Desea Autorizar", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            RadMessageBox.Show("Autorizacion correcta, despacho aceptado ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        Else
                            alerta.contenido = "Registro no guardado !!!"
                            alerta.fnErrorContenido()
                            success = False
                            Exit Try
                        End If
                    End If
                End If


                'crear registro de salida bodega.

                Dim sb As New tblsalidaBodega
                sb.idsalida = codigo
                ctx.AddTotblsalidaBodegas(sb)
                ctx.SaveChanges()


                'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                Dim salida As tblSalida = (From x In ctx.tblSalidas _
                                              Where x.idSalida = codigo Select x).First


                'pasar despachar a true
                If escredito = True Then
                    salida.despachar = True
                    Dim fechaVencimiento As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim dia = Weekday(fechaVencimiento, vbMonday)
                    Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codcliente Select x).First
                    Dim diasCredito As Integer = (From x In ctx.tblClienteTipoPagoes Where x.idtipoPago = cli.idTipoPago Select x.dias).First

                    If diasCredito = 5 Then
                        If dia = 1 Then
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito)
                        Else
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 1)
                        End If
                    End If

                    If diasCredito = 20 Then
                        If dia >= 1 And dia <= 4 Then
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 3)
                        Else
                            salida.fechaVencimientoCredito = fechaVencimiento.AddDays(diasCredito + 4)
                        End If
                    End If
                Else
                    salida.despachar = True
                End If

                salida.fechaVencimientoReserva = Nothing
                ctx.SaveChanges()

                'descontar la reserva de inventario.
                Dim consulta = (From x In ctx.tblSalidaDetalles Where x.idSalida = codigo Select x)
                Dim fila
                For Each fila In consulta
                    Dim id As Integer = fila.idarticulo
                    'seleccionar el registro de inventario por medio del idempresa y articulo.
                    Dim inventario As tblInventario = (From x In ctx.tblInventarios Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = id Select x).First
                Next

                'paso 8, completar la transaccion.
                transaction.Complete()

            Catch ex As System.Data.EntityException
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
        Else
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    Private Sub pbreservar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbreservar.Click
        Reservarsalida()
    End Sub

    Private Sub lblreservar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblreservar.Click
        ReservarSalida()
    End Sub

    Private Sub ReservarSalida()
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""

        'Variable para conocer el codigo ó IdSalida que se tiene seleccinado de la tabla.
        Dim Codigo As Integer = grdDatos.SelectedRows.Item(0).Cells(0).Value
        Dim EsCotizado = grdDatos.SelectedRows.Item(0).Cells(7).Value

        'Solo es posible seguir si la salida seleccionada es una Cotización
        If EsCotizado <> "Cotizado" Then
            MsgBox("Estado del Pedido:  " & EsCotizado)
            Exit Sub
        End If
        'Realizamos la consulta del primer registro con el codigo seleccionado en el grid.
        Dim Datos As tblSalida = (From d In ctx.tblSalidas Where d.idSalida = Codigo Select d).First()


        'Revisamos si la consulta viene con resultado, de lo contrario mandamos un error.
        If Datos.idSalida = Nothing Then
            alerta.contenido = "No se encontró el registro seleccinado, Trate de Acualizar el listado!!!"
            alerta.fnErrorContenido()
            success = False
        Else

            'Verificamos que la salida no haya sido Despachado ó Facturado.
            If Datos.reservado = True Or Datos.despachar = True Then
                alerta.contenido = "Vaya!, El producto selecciona ya ha sido Reservado ó Despachado.!!!"
                alerta.fnErrorContenido()
                success = False
                Exit Sub
            End If

            totalPagar = Datos.total
            descuento = Datos.descuento

            'Si el estado de la salida es Cotizado, es necesario verificar la existencia de todos los productos cotizados
            'Si estan disponibles se procede a bajar de inventario
            If Datos.cotizado = True Then
                'Funcion que permite modificar el registro de salida y el registro de Articulos empresa
                'pasando de una salida cotizado a despachado.
                CambiacotizarAreservar(Codigo, Datos.credito, Datos.idCliente)
            End If
            fnLlenarGrid()
        End If
    End Sub


    'Procedimiento que permite cambiar el Estado de una salida de Cotizado a á Reservado.
    Public Sub CambiacotizarAreservar(ByVal codigo As Integer, ByVal EsCredito As Boolean, ByVal CodCliente As Integer)
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()

        Using transaction As New TransactionScope
            Try

                'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
                Dim Detalles
                Dim ArtEmpresa
                Dim fila

                'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                Dim NombreArt As String
                Dim CodArticulo As Integer
                Dim Pedido As Integer
                Dim saldo As Integer

                Detalles = From x In ctx.tblSalidaDetalles Join y In ctx.tblArticuloes On x.idArticulo Equals y.idArticulo Where x.idSalida = codigo Select x.idArticulo, x.cantidad, y.nombre1


                'Entramos a revisar cada registro en detalle de salida, si existe un articulo que no cubre existencia se guarda el error.
                For Each fila In Detalles
                    NombreArt = fila.nombre1
                    CodArticulo = fila.idarticulo
                    Pedido = fila.cantidad

                    'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                    ArtEmpresa = (From AE In ctx.tblInventarios Where AE.tblArticulo.empresa = mdlPublicVars.idEmpresa And AE.idArticulo = CodArticulo Select AE).First

                    If ArtEmpresa.saldo < Pedido Then
                        saldo = Pedido - ArtEmpresa.saldo
                        'Guardamos el error con los datos del producto en una variable para q se agruen todos lo productos que tengan error.
                        errContenido = errContenido & "El articulo: " & NombreArt & ", Pedido " & Pedido.ToString & " en existencia " & ArtEmpresa.saldo.ToString & ", Faltantes " & saldo & vbCrLf
                        success = False
                    End If

                Next

                'Si existe un error mandamos el mensaje e interrumpimos la aplicación
                If success = False Then
                    alerta.contenido = errContenido
                    alerta.fnFaltantes()
                    Exit Try
                End If

                'VERIFICAR CREDITO.

                If EsCredito = True Then
                    Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = CodCliente Select x).First

                    Dim saldoCredito As Double = 0
                    'consultar cta por cobrar del cliente.
                    Dim cta = From x In ctx.tblCtaCobrars _
                        Where x.idCliente = CodCliente _
                        Group By x.idCliente _
                        Into SaldoCobrar = Sum(x.saldo) _
                        Select SaldoCobrar

                    Dim item
                    For Each item In cta
                        saldoCredito = saldoCredito + item
                    Next

                    Dim diaSemana As Integer = Weekday(mdlPublicVars.fnFecha_horaServidor, vbMonday)
                    Dim fechaActual As DateTime = mdlPublicVars.fnFecha_horaServidor
                    Dim fechaReserva As DateTime = mdlPublicVars.fnFecha_horaServidor

                    If (diaSemana = 1) Then
                        fechaReserva = fechaActual.AddDays(mdlPublicVars.Salida_ReservaDias)
                    Else
                        fechaReserva = fechaActual.AddDays(mdlPublicVars.Salida_ReservaDias + 1)
                    End If


                    'Paso 2, si excede limite de credito.
                    If VerificaCredito(cli.porcentajeCredito, cli.limiteCredito, cli.diasCredito, saldoCredito) = True Then

                        'Paso 3, solicitar autorizacion
                        If RadMessageBox.Show("Desea Autorizar", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            RadMessageBox.Show("Autorizacion correcta, despacho aceptado ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        Else
                            alerta.contenido = "Registro no guardado !!!"
                            alerta.fnErrorContenido()
                            success = False
                            Exit Try
                        End If
                    End If
                End If


                'Se Consulta en la tabla Salida y se cambia el estado de Despachado a True.
                Dim salida As tblSalida = (From x In ctx.tblSalidas _
                                              Where x.idSalida = codigo Select x).First


                'pasar reservado  a true
                salida.reservado = True
                salida.fechaVencimientoReserva = fecha

                ctx.SaveChanges()

                'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                For Each fila In Detalles
                    CodArticulo = fila.idarticulo
                    Pedido = fila.cantidad

                    'Se Consulta en la tabla ArticulosEmpresa para consusltar la existencia real  "Saldo".
                    Dim inve As tblInventario = (From x In ctx.tblInventarios _
                                                  Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                                  And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idArticulo = CodArticulo Select x).First

                    'descontar existencias.
                    inve.saldo = inve.saldo - Pedido
                    inve.reserva = inve.reserva + Pedido
                    saldo = 0
                    ctx.SaveChanges()

                Next

                'completar la transaccion.
                transaction.Complete()

            Catch ex As System.Data.EntityException
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
        Else
            Console.WriteLine("La operacion no pudo ser completada")
        End If


    End Sub

    Private Function VerificaCredito(ByVal porcentaje As Double, ByVal limite As Double, ByVal Dias As Integer, ByVal saldo As Double)

        Dim total As Double = 0
        Dim retorno As Boolean = False

        total = totalPagar - descuento

        Dim msj As String = ""

        'paso 1, verificar si escede el limite de credito.
        If (saldo + total) > limite Then
            msj = " Excede limite de credito " + Format(saldo + total - limite, mdlPublicVars.formatoMoneda).ToString
            retorno = True
        End If

        'paso 2, verificar si excede el porcentaje.
        If ((total / limite) * 100) > porcentaje Then
            msj = " Excede porcentaje de credito " + Format(((total / limite) * 100), mdlPublicVars.formatoNumero).ToString
            retorno = True
        End If



        alerta.contenido = msj
        alerta.fnErrorContenido()

        Return retorno
    End Function

    Private Sub AnularSalida()
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim esReserva As Boolean = False
        Dim esCotizado As Boolean = False

        'Variable para conocer el codigo ó IdSalida que se tiene seleccinado de la tabla.
        Dim Codigo As Integer = grdDatos.SelectedRows.Item(0).Cells(0).Value

        'Realizamos la consulta del primer registro con el codigo seleccionado en el grid.
        Dim Datos As tblSalida = (From d In ctx.tblSalidas Where d.idSalida = Codigo Select d).First()

        'Revisamos si la consulta viene con resultado, de lo contrario mandamos un error.
        If Datos.idSalida = Nothing Then
            alerta.contenido = "No se encontró el registro seleccinado, Trate de Acualizar el listado!!!"
            alerta.fnErrorContenido()
            success = False
        ElseIf Datos.facturado = True Then
            'Si la salida que está seleccionado ya ha sido facturado mandamos un error. Porque ya no es posible seguir
            alerta.contenido = "No es posible anular la salida, ésta ya ha sido Facturado.!!!"
            alerta.fnErrorContenido()
            success = False
        Else

            'Iniciamos con La Transacción para modificar y revertir las cantidades de productos en inventario.

            Using transaction As New TransactionScope
                Try

                    'Verificamos el ultimo estado de salida válida: Cotizado, Reservado ó Despachado.
                    If Datos.cotizado = True And Datos.reservado = False And Datos.despachar = False Then
                        esCotizado = True
                    ElseIf Datos.reservado = True And Datos.despachar = False Then
                        esReserva = True
                    ElseIf Datos.despachar = True Then
                        esReserva = False
                    End If

                    If esCotizado = True Then

                        ActivarAnulado(Datos.idSalida)

                    Else

                        ActivarAnulado(Datos.idSalida)

                        'Variables para Guardar los resultado de las Consultas, El de Salidadetalle, ArticuloEmpresa y cada fila del Detalle...
                        Dim Detalles
                        Dim fila

                        'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                        Dim CodArticulo As Integer
                        Dim Pedido As Integer


                        'Consultamos el detalle de la salida correspondiente a la salida que está seleccionado.
                        Detalles = From x In ctx.tblSalidaDetalles Where x.idSalida = Codigo Select x.idArticulo, x.cantidad


                        'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                        For Each fila In Detalles
                            CodArticulo = fila.idarticulo
                            Pedido = fila.cantidad

                            'Se Consulta los datos del articulo en revisión, en la tabla Articulos empresa para que posteriormente se actualice.
                            Dim inve As tblInventario = (From x In ctx.tblInventarios _
                                                          Where x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idArticulo = CodArticulo Select x).First


                            'Actualizar la cantidad del producto en inventario, disminuir la reserva y aumentar la cantidad.
                            inve.saldo = inve.saldo + Pedido

                            'Verificamos el estado de la salida es Reserva, si es así modificamos la cantidad de Reserva en inventario.
                            If esReserva = True Then
                                inve.reserva = inve.reserva - Pedido
                            End If

                            'Guardamos los cambios realizados sobre el Articulo en la Empresa que se ha.
                            ctx.SaveChanges()

                        Next

                    End If

                    'completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alerta.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try

            End Using

            If success = True Then
                ctx.AcceptAllChanges()
                alerta.fnAnulado()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'Si fue anulado la salida  se vuelve a llenar el grid de salidas.
            fnLlenarGrid()
        End If

    End Sub

    'Prodecimiento que permite modificar la salida y dejar el estado de Anulado en True.
    Private Sub ActivarAnulado(ByVal CodigoSalida As Int64)

        'Se Consulta en la tabla Salidas la salida con el Codigo recibido y se Actualiza el campo Anulado a True.
        Dim DatSalida As tblSalida = (From x In ctx.tblSalidas _
                                      Where x.idSalida = CodigoSalida Select x).First

        'Modificar el campo Anulado a True.
        DatSalida.anulado = True
        'Guardamos los cambios efectuados..
        ctx.SaveChanges()

    End Sub


    Private Sub pbanular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbanular.Click, lblanular.Click
        AnularSalida()
    End Sub

End Class
