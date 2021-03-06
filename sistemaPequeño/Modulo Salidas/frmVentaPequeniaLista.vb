﻿Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Transactions
Imports Telerik.WinControls.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net.Mail
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmVentaPequeniaLista

    Private permiso As New clsPermisoUsuario
    Private cargo As Boolean
    Public registroActual As Integer = 0
    Public filtroActivo As Boolean

    Private Sub frmVentaPequeniaLista_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"

        Try
            Dim iz As New frmVentaPequeniaBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz

            frmBarraLateralBaseDerecha = frmVentaPequeniaBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try

        Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        fnLlenarCombo()
        llenagrid()
        fnConfiguracion()
        cmbFiltroFecha.Visible = True
        lblFiltroFecha.Visible = True
        cargo = True
        grdDatos.Focus()
        llenagrid()

        Me.cmbFiltroFecha.Visible = False
        Me.lblFiltroFecha.Visible = False
        Me.txtFiltro.Visible = False
        Me.Label2.Visible = False

    End Sub

    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Dim datos = (From x In ctx.tblListaFiltroFechas Select x.orden, codigo = x.dias, x.nombre
                     Order By orden Ascending)

        With cmbFiltroFecha
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = datos
        End With
    End Sub

    Public Sub llenagrid()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechainicio As DateTime
                Dim fechafin As DateTime

                fechainicio = dtpFechaInicio.Value.ToShortDateString + " 01:00:00.000"
                fechafin = dtpFechaFin.Value.ToShortDateString + " 22:59:59.999"

                Dim consulta = conexion.sp_salida_mov_lista_pequenia(mdlPublicVars.idEmpresa, fechainicio, fechafin, txtFiltro.Text, 0)

                Me.grdDatos.DataSource = EntitiToDataTable(consulta)
                mdlPublicVars.fnGrid_iconos(Me.grdDatos)

                'Para saber cuantas filas tiene el grid
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                If grdDatos.RowCount > 0 Then
                    Me.grdDatos.Rows(registroActual).IsCurrent = True
                End If

                fnConfiguracion()

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
        fnCambioFila()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaAnulado")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "VenceReserva")

                Me.grdDatos.Columns("FechaAnulado").HeaderText = "Fecha Anulado"

                Me.grdDatos.Columns("Codigo").IsVisible = False
                Me.grdDatos.Columns("Clave").IsVisible = False

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                '  Me.grdDatos.Columns("Codigo").Width = 55
                Me.grdDatos.Columns("Fecha").Width = 80
                '  Me.grdDatos.Columns("Clave").Width = 60

                Me.grdDatos.Columns("Cliente").Width = 140

                Me.grdDatos.Columns("Vendedor").Width = 100
                Me.grdDatos.Columns("Doc").Width = 55
                Me.grdDatos.Columns("Total").Width = 70

                Me.grdDatos.Columns("clrEstado").Width = 70
                Me.grdDatos.Columns("clrEstado").IsVisible = True

                Me.grdDatos.Columns("Estado").Width = 100
                Me.grdDatos.Columns("Estado").IsVisible = True

                Me.grdDatos.Columns("clrPagado").Width = 70
                Me.grdDatos.Columns("clrPagado").IsVisible = True

                Me.grdDatos.Columns("Pagado").Width = 75
                Me.grdDatos.Columns("Pagado").IsVisible = True

                '   Me.grdDatos.Columns("Pagos").Width = 55
                Me.grdDatos.Columns("Pagos").IsVisible = False

                '   Me.grdDatos.Columns("chkSurtir").Width = 55
                Me.grdDatos.Columns("chkSurtir").IsVisible = False

                '  Me.grdDatos.Columns("chkAjustes").Width = 55
                Me.grdDatos.Columns("chkAjustes").IsVisible = False

                '   Me.grdDatos.Columns("clrEnvio").Width = 60
                Me.grdDatos.Columns("clrEnvio").IsVisible = False

                ' Me.grdDatos.Columns("Envio").Width = 90
                Me.grdDatos.Columns("Envio").IsVisible = False

                '  Me.grdDatos.Columns("FechaAnulado").Width = 75
                Me.grdDatos.Columns("FechaAnulado").IsVisible = False

                '   Me.grdDatos.Columns("VenceReserva").Width = 75
                Me.grdDatos.Columns("VenceReserva").IsVisible = False

                ' Me.grdDatos.Columns("chmRevisado").Width = 150
                Me.grdDatos.Columns("chmRevisado").IsVisible = False


                Me.grdDatos.Columns("chkCarroceria").IsVisible = False
                Me.grdDatos.Columns("chkLlanta").IsVisible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(fila).Cells("Codigo").Value, Integer)
                mdlPublicVars.superSearchNombre = CType(Me.grdDatos.Rows(fila).Cells("Estado").Value, String)
                mdlPublicVars.superSearchFecha = CType(Me.grdDatos.Rows(fila).Cells("Fecha").Value, DateTime)
                'Contiene el codigo del cliente
                mdlPublicVars.superSearchCodSurtir = CType(Me.grdDatos.Rows(fila).Cells("Clave").Value, String)
                mdlPublicVars.superSearchEstado = CType(Me.grdDatos.Rows(fila).Cells("clrEnvio").Value, Integer)
                mdlPublicVars.superSearchEnvio = CType(Me.grdDatos.Rows(fila).Cells("Envio").Value, String)
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count


                If (Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Cancelada" And Me.grdDatos.Rows(fila).Cells("Estado").Value = "Cotizado") Or (Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Sin Abonar" And Me.grdDatos.Rows(fila).Cells("Estado").Value = "Cotizado") Or (Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Abonado" And Me.grdDatos.Rows(fila).Cells("Estado").Value = "Cotizado") Then
                    mdlPublicVars.supersearchPagado = True

                ElseIf Me.grdDatos.Rows(fila).Cells("Estado").Value = "Facturado" And Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Cancelada" Then
                    mdlPublicVars.supersearchclientelibre = True

                ElseIf (Me.grdDatos.Rows(fila).Cells("Estado").Value = "Anulado" And Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Cancelada") Or (Me.grdDatos.Rows(fila).Cells("Estado").Value = "Anulado" And Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Sin Abonar") Or (Me.grdDatos.Rows(fila).Cells("Estado").Value = "Anulado" And Me.grdDatos.Rows(fila).Cells("Pagado").Value = "Abonado") Then
                    mdlPublicVars.supersearchclientelibre = True

                Else
                    mdlPublicVars.supersearchclientelibre = False
                    mdlPublicVars.supersearchPagado = False
                End If

                registroActual = fila
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try

            ''frmVentaPequenia.Text = "Ventas"
            ''frmVentaPequenia.bitEditarBodega = False
            ''frmVentaPequenia.bitEditarSalida = False
            ''frmVentaPequenia.MdiParent = frmMenuPrincipal
            ''permiso.PermisoFrmEspeciales(frmVentaPequenia, False)

            Dim formPedido As New frmSalidas
            formPedido.Text = "Ventas"
            formPedido.bitEditarBodega = False
            formPedido.bitEditarSalida = False
            formPedido.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(formPedido, False)

        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub


    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        If RadMessageBox.Show("¿Desea anular el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnCambioFila()
            Dim codigo As Integer = mdlPublicVars.superSearchId
            AnularSalida(codigo)
        End If
    End Sub


    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                fnCambioFila()

                Dim tipoSalida As String = mdlPublicVars.superSearchNombre
                Dim codigo As Integer = mdlPublicVars.superSearchId

                ''If tipoSalida = "Cotizado" Or tipoSalida = "Reservado" Then
                ''    frmVentaPequenia.Text = "Editar Ventas"
                ''    frmVentaPequenia.codigo = codigo
                ''    frmVentaPequenia.bitEditarBodega = False
                ''    frmVentaPequenia.bitEditarSalida = True
                ''    frmVentaPequenia.MdiParent = frmMenuPrincipal
                ''    permiso.PermisoFrmEspeciales(frmVentaPequenia, False)
                ''ElseIf tipoSalida = "Despachado" Then
                ''    Try
                ''        frmVentaPequenia.Text = "Revision en bodega "
                ''        frmVentaPequenia.codigo = codigo
                ''        frmVentaPequenia.bitEditarBodega = True
                ''        frmVentaPequenia.bitEditarSalida = False
                ''        frmVentaPequenia.MdiParent = frmMenuPrincipal
                ''        permiso.PermisoFrmEspeciales(frmVentaPequenia, False)
                ''    Catch ex As Exception
                ''        alertas.fnError()
                ''    End Try
                ''Else
                ''    alertas.contenido = "El pedido ya ha sido " & tipoSalida
                ''    alertas.fnErrorContenido()
                ''End If

                If tipoSalida = "Cotizado" Or tipoSalida = "Reservado" Then
                    frmSalidas.Text = "Editar Ventas"
                    frmSalidas.codigo = codigo
                    frmSalidas.bitEditarBodega = False
                    frmSalidas.bitEditarSalida = True
                    frmSalidas.MdiParent = frmMenuPrincipal
                    permiso.PermisoFrmEspeciales(frmSalidas, False)
                ElseIf tipoSalida = "Despachado" Then
                    Try
                        frmSalidas.Text = "Revision en bodega "
                        frmSalidas.codigo = codigo
                        frmSalidas.bitEditarBodega = True
                        frmSalidas.bitEditarSalida = False
                        frmSalidas.MdiParent = frmMenuPrincipal
                        permiso.PermisoFrmEspeciales(frmSalidas, False)
                    Catch ex As Exception
                        alertas.fnError()
                    End Try
                Else
                    alertas.contenido = "El pedido ya ha sido " & tipoSalida
                    alertas.fnErrorContenido()
                End If

                mdlPublicVars.superSearchNombre = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    'VER
    Private Sub frm_Ver() Handles Me.verRegistro


        Try
            fnCambioFila()

            If Me.grdDatos.RowCount > 0 Then
                If Me.grdDatos.CurrentRow.Index >= 0 Then
                    Dim codigo As Integer = mdlPublicVars.superSearchId
                    Dim estado As String = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Estado").Value

                    frmPedidoConcepto.Text = "Ventas"
                    frmPedidoConcepto.idSalida = codigo
                    frmPedidoConcepto.WindowState = FormWindowState.Normal
                    frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoDialogEspeciales(frmPedidoConcepto)
                    frmPedidoConcepto.Dispose()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnularSalida(ByVal Codigo As Integer)


        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim esReserva As Boolean = False
        Dim esCotizado As Boolean = False

        'Realizamos la consulta del primer registro con el codigo seleccionado en el grid.
        Dim Datos As tblSalida = (From d In ctx.tblSalidas Where d.idSalida = Codigo Select d).FirstOrDefault()

        'Revisamos si la consulta viene con resultado, de lo contrario mandamos un error.
        If Datos.idSalida = Nothing Then
            alertas.contenido = "No se encontró el registro seleccinado, Trate de Acualizar el listado!!!"
            alertas.fnErrorContenido()
            success = False
        ElseIf Datos.facturado = True And Datos.empacado = True Then
            'Si la salida que está seleccionado ya ha sido facturado mandamos un error. Porque ya no es posible seguir
            alertas.contenido = "No es posible anular la salida, ésta ya ha sido Facturado.!!!"
            alertas.fnErrorContenido()
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

                        'Variable para guardar temporalmene el codigo del articulo y la cantidad solicitada..
                        Dim CodArticulo As Integer
                        Dim Pedido As Integer


                        'Consultamos el detalle de la salida correspondiente a la salida que está seleccionado.
                        Dim detalles As List(Of tblSalidaDetalle) = (From x In ctx.tblSalidaDetalles Where x.idSalida = Codigo).ToList

                        'Entramos y modificamos a cada registro en detalle de salida, empezamos a cambiar el saldo del producto en inventario.
                        For Each fila As tblSalidaDetalle In detalles
                            CodArticulo = fila.idArticulo
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

                            'Anulamos el detalle tambien
                            fila.anulado = True
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
                        alertas.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try

            End Using

            If success = True Then
                ctx.AcceptAllChanges()
                alertas.fnAnulado()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'Si fue anulado la salida  se vuelve a llenar el grid de salidas.
            frm_llenarLista()
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

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click

        If Me.grdDatos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If (Me.grdDatos.CurrentColumn.Name = "chmRevisado") And fila >= 0 Then
                Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmRevisado").Value
                Dim descripcion As String = Me.grdDatos.Rows(fila).Cells("Estado").Value
                Dim idSalida As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value
                If valor = False Then
                    Me.grdDatos.Rows(fila).Cells("chmRevisado").Value = True
                    If descripcion = "Despachado" And Not mdlPublicVars.superSearchEnvio.Equals("Autorizacion") Then
                        If RadMessageBox.Show("Desea confirmar que se ha revisado el Pedido", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                            registroActual = fila
                            fnEmpacarPedido(fila)

                            frmPedidosBodega.Text = "Bodega"
                            frmPedidosBodega.idSalida = idSalida
                            frmPedidosBodega.StartPosition = FormStartPosition.CenterScreen
                            frmPedidosBodega.BringToFront()
                            frmPedidosBodega.Focus()
                            permiso.PermisoDialogEspeciales(frmPedidosBodega)
                            frmPedidosBodega.Dispose()

                            'Obtenemos el estado
                            Dim estado = (From x In ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, idSalida) Select x).FirstOrDefault

                            If estado IsNot Nothing Then
                                If estado.clrEnvio <> 1 Then
                                    fnFacturar(idSalida)
                                Else
                                    'Realizar pagoe
                                    If RadMessageBox.Show("No se puede facturar, ¿Desea realizar un pago?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        'Obtenemos el saldo del cliente
                                        Dim cliente As tblCliente = (From x In ctx.tblClientes.AsEnumerable Where x.idCliente = mdlPublicVars.superSearchCodSurtir
                                                                     Select x).FirstOrDefault

                                        frmPagoNuevo.Text = "Pagos"
                                        frmPagoNuevo.bitCliente = True
                                        frmPagoNuevo.codigoCP = mdlPublicVars.superSearchCodSurtir
                                        frmPagoNuevo.lblSaldo.Text = cliente.saldo
                                        frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                                        frmPagoNuevo.ShowDialog()

                                        'Actualizamo la salida
                                        Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                                        'Obtenemos nuevamente el estado
                                        Dim estado2 = (From x In ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, idSalida) Select x).FirstOrDefault

                                        If estado2 IsNot Nothing Then
                                            If estado2.clrEnvio <> 1 Then
                                                mdlPublicVars.superSearchEstado = estado2.clrEnvio
                                                fnFacturar(idSalida)
                                            Else
                                                RadMessageBox.Show("No se puede facturar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                            End If
                                        Else
                                            RadMessageBox.Show("No se puede facturar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                        End If
                                    End If
                                End If
                            Else
                                RadMessageBox.Show("No se puede facturar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            End If
                        Else
                            Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmRevisado").Value = False
                        End If
                    ElseIf mdlPublicVars.superSearchEnvio.Equals("Autorizacion") Then
                        alertas.contenido = "El pedido necesita autorización"
                        alertas.fnErrorContenido()
                        Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmRevisado").Value = False
                    Else

                        alertas.contenido = "Estado del pedido: " & descripcion
                        alertas.fnErrorContenido()
                        Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmRevisado").Value = False
                    End If
                End If
                llenagrid()
            End If
        End If

        Return False
    End Function

    Private Sub fnEmpacarPedido(ByVal fila As Integer)

        Dim idSalida As Integer = CType(Me.grdDatos.Rows(fila).Cells("Codigo").Value, Integer)
        Dim anulado As String = CType(Me.grdDatos.Rows(fila).Cells("Estado").Value, String)

        Dim success As Boolean = True

        Using transaction As New TransactionScope

            Try
                If anulado = "Anulado" Then
                    success = False
                    Exit Try
                Else
                    Dim fechaEmpacado As DateTime = fnFecha_horaServidor()
                    'Obtenemos la salida a modificar
                    Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault
                    salida.empacado = True
                    ctx.SaveChanges()
                End If

                ctx.SaveChanges()

                'paso 8, completar la transaccion.
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
                    alertas.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
        Else
            If anulado = "Despachado" Then
                alertas.contenido = "El pedido ya ha sido anulado"
                alertas.fnErrorContenido()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If
            'alertas.fnErrorGuardar()
        End If

    End Sub

    Private Sub frmPedidosLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'Funcion utilizada para facturar
    Private Sub fnFacturar(ByVal idSalida As Integer)
        'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos
        Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

        If salida IsNot Nothing Then
            Dim consulta = (From x In ctx.tblSalidas _
                        Where x.idSalida = salida.idSalida _
                        Select Codigo = x.idSalida, Pagos = If(x.contado = True, "Contado", "Credito"), Fecha = x.fechaRegistro, Documento = x.documento, _
                        DireccionFacturacion = x.direccionFacturacion, Vendedor = x.tblVendedor.nombre, Total = x.total, clrEstado = 0, Estado = "Revisado", Descripcion = "", Clave = salida.idCliente).FirstOrDefault

            Dim codigo1 = consulta.Codigo
            Dim pagos1 = consulta.Pagos
            Dim fecha1 = consulta.Fecha
            Dim documento1 = consulta.Documento
            Dim vendedor1 = consulta.Vendedor
            Dim total1 = consulta.Total
            Dim direccion1 = consulta.DireccionFacturacion

            Dim agregar As Integer = 0


            If salida IsNot Nothing Then
                'Si la salida ya esta revisada
                If salida.empacado = True And salida.anulado = False Then
                    'Verificamos si el cliente tiene mas facturas

                    Dim consFacturas = (From x In ctx.tblSalidas
                              Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa And x.idCliente = salida.idCliente _
                               And x.anulado = False Select Codigo = x.idSalida).ToList()

                    Dim nFacturas As Integer = 0
                    Dim xx
                    For Each xx In consFacturas
                        Dim estado = From x In ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, xx).ToList
                        For Each es As sp_salida_Estado_Result In estado
                            If es.clrEnvio <> 1 Then
                                nFacturas = nFacturas + 1
                            End If
                        Next
                    Next

                    If nFacturas > 1 Then
                        If RadMessageBox.Show("¿Tiene " & nFacturas & " Pedidos, desea elegir cuales facturar?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                            frmFactura.Text = "Factura"
                            frmFactura.MdiParent = frmMenuPrincipal
                            frmFactura.codigoCliente = mdlPublicVars.superSearchCodSurtir
                            frmFactura.WindowState = FormWindowState.Maximized
                            permiso.PermisoFrmEspeciales(frmFactura, False)
                        Else
                            If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                                agregar = 1
                            End If
                        End If
                    Else
                        If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                            agregar = 1
                        End If
                    End If

                    If agregar = 1 Then
                        'Vaciamos la tabla con los codigos
                        mdlPublicVars.General_CodigoSalida.Rows.Clear()
                        mdlPublicVars.General_CodigoSalida.Rows.Add(codigo1, Format(fecha1, mdlPublicVars.formatoFecha), documento1, vendedor1, Format(total1, mdlPublicVars.formatoMoneda))
                        Dim total As Decimal = mdlPublicVars.fnTotalTablaFacturas

                        mdlPublicVars.GuardarFacturacion(idSalida)

                        frmFacturaImprimir.Text = "Facturar"

                        If pagos1 = "Contado" Then
                            frmFacturaImprimir.bitContado = True
                            frmFacturaImprimir.bitCredito = False
                        Else
                            frmFacturaImprimir.bitContado = False
                            frmFacturaImprimir.bitCredito = True
                        End If
                        frmFacturaImprimir.codClie = salida.idCliente
                        frmFacturaImprimir.dirFact = direccion1
                        frmFacturaImprimir.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoFrmEspeciales(frmFacturaImprimir, False)
                    End If

                    Me.frm_llenarLista()
                Else
                    alertas.contenido = "No se puede facturar"
                    alertas.fnErrorContenido()
                End If
            Else
                If salida.anulado Then
                    alertas.contenido = "El pedido ya ha sido anulado"
                Else
                    alertas.contenido = "El pedido no ha sido revisado"
                End If
                alertas.fnErrorContenido()
            End If
        Else
            alertas.contenido = "Error en la operacion"
            alertas.fnErrorContenido()
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Ventas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub


    'CAMBIO DE FILTRO FECHA
    Public Overloads Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
        If cargo Then
            frm_llenarLista()
        End If
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmPedidosFiltro.Text = "Filtro: PEDIDOS"
        frmPedidosFiltro.StartPosition = FormStartPosition.CenterScreen
        frmPedidosFiltro.Show()
        'permiso.PermisoFrmEspeciales(frmProductoFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
        llenagrid()
    End Sub

    Private Sub grdDatos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F8 Then

            Dim idsalida As Integer
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

            idsalida = Me.grdDatos.Rows(fila).Cells("Codigo").Value

            If Me.grdDatos.Rows(fila).Cells("Estado").Value = "Facturado" Then

                If mdlPublicVars.bitTransportePesado = True Then
                    If RadMessageBox.Show("Desea Reimprimir el Envio", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnImprimir(idsalida)
                    End If
                End If

            Else
                RadMessageBox.Show("No es un Pedido", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        End If

        If e.KeyCode = Keys.F9 Then
            Dim idsalida As Integer
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

            idsalida = Me.grdDatos.Rows(fila).Cells("Codigo").Value

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                If Me.grdDatos.Rows(fila).Cells("Estado").Value = "Facturado" Then

                    Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault
                    If sal.bitFacReimpreso = False Then
                        If mdlPublicVars.bitTransportePesado = True Then
                            If RadMessageBox.Show("Desea Reimprimir la Factura", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                fnImprimirFactura(idsalida)

                                Dim salfac As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idsalida Select x).FirstOrDefault

                                fnEnviarCorreo(salfac.idCliente, idsalida)

                            End If
                        End If
                    Else
                        RadMessageBox.Show("La Factura ya fue Reimpresa", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    End If
                Else
                    RadMessageBox.Show("El Pedido no esta Facturado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If

                conn.Close()
            End Using

        End If

    End Sub

    Private Sub fnEnviarCorreo(ByVal cliente As Integer, ByVal salida As Integer)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim tablaParametros As New DataTable

        Dim reporteBase As ReportDocument

        Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim archivo As String = ""
        Dim msj As String = ""

        ''Variables
        Dim x As New tblImpresion
        Dim r As New clsReporte
        Dim listacorreos As New Hashtable
        Dim tabladatos As New DataTable
        Dim dsr As New dsReporte

        r.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_ReporteFacturaPequenio(salida, mdlPublicVars.idEmpresa))
        r.reporte = "rptFacturaPequenioReimpresion.rpt"
        reporteBase = r.DocumentoReporte()

        Try
            ''Guardar registro en el sistema
            x.bitImpreso = True
            x.tipoImpresion = 5
            x.usuarioRegistro = mdlPublicVars.idUsuario
            x.fechaImpresion = fechaServidor
            x.cliente = cliente
            x.descripcion = "Devolucion de Productos"
            x.url = archivo

            ctx.AddTotblImpresions(x)
            ctx.SaveChanges()

            x.url = fnExportar(x.codigo, path, reporteBase, tablaParametros)

            Dim empresa As tblEmpresa = (From y In ctx.tblEmpresas Where y.idEmpresa = mdlPublicVars.idEmpresa Select y).FirstOrDefault

            Dim txtcorreos As String = empresa.Correos

            Dim correos() As String = txtcorreos.Split(",")
            Dim i
            For i = LBound(correos) To UBound(correos)
                listacorreos.Add(i + 1, correos(i))
            Next

            r.emailTitulo = "Reimpresion de Factura"
            r.emailCuerpo = "Reimpresion de Factura Correo enviado desde Sistema Pos Dsi"
            msj += r.EnviarCorreo(listacorreos, x.url).ToString

        Catch ex As Exception

        End Try

    End Sub

    Public Function fnExportar(ByVal codigo As String, ByVal path As String, ByVal reporteExportar As ReportDocument, ByVal tblparametros As DataTable) As String
        Dim carpeta As String = "DocImpresion\" + mdlPublicVars.idEmpresa.ToString + "\"
        Dim archivo As String = ""
        path = path & carpeta

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()

            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            Dim CrFormatTypeOptionsXls As New ExcelFormatOptions

            CrDiskFileDestinationOptions.DiskFileName = path & codigo.ToString & ".pdf"
            archivo = CrDiskFileDestinationOptions.DiskFileName

            CrExportOptions = reporteExportar.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .FormatOptions = CrFormatTypeOptions

                .DestinationOptions = CrDiskFileDestinationOptions
            End With

            reporteExportar.Export()

        Catch ex As Exception
            MsgBox(ex.ToString)
            archivo = ""
        End Try

        Return archivo

    End Function

    Private Sub fnImprimirFactura(ByVal codsalida As Integer)
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim r As New clsReporte

                r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFacturaPequenio(codsalida, mdlPublicVars.idEmpresa))
                r.reporte = "rptFacturaPequenioReimpresion.rpt"

                r.verReporte()

                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codsalida Select x).FirstOrDefault

                salida.bitFacReimpreso = True

                conexion.SaveChanges()

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnImprimir(ByVal codSalida As Integer)
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim c As New clsReporte
                If mdlPublicVars.bitTransportePesado Then
                    c.tabla = EntitiToDataTable(conexion.sp_ReporteEnvioPequenio(codSalida, mdlPublicVars.idEmpresa))
                Else
                    c.tabla = EntitiToDataTable(conexion.sp_reportePickingPedido("", codSalida))
                End If

                If mdlPublicVars.bitTransportePesado Then
                    c.reporte = "rptEnvioPequenio.rpt"
                Else
                    c.nombreParametro = "@filtro"
                    c.reporte = "ventas_Picking.rpt"
                    c.parametro = ""
                End If
                c.imprimirReporte()

                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            llenagrid()
        Catch ex As Exception

        End Try
    End Sub

End Class
