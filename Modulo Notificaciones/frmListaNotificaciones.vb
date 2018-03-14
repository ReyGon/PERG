Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmListaNotificaciones

    Dim contadornotificaciones As Integer = 0
    Dim usuarioSeleccion As Integer = 0
    Dim vendedorSeleccion As Integer = 0

    Private Sub frmListaNotificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.grdReservas.Rows.Clear()
        fnLlenarCombo()
        fnLlenarListados()
    End Sub

    Private Sub fnLlenarListados()
        Try
            Me.grdReservas.Rows.Clear()
            Me.grdCreditosVencidos.Rows.Clear()
           
            fnLlenarReservas()
            ''fnLlenarCreditosVencidos()
            ''fnLlenarPendientesSurtir()
            ''fnLlenarComprasClientes()
            ''fnLlenarClientesNuevos()
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdReservas)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdReservas)
            mdlPublicVars.fnGrid_iconos(Me.grdReservas)
            ''mdlPublicVars.fnFormatoGridEspeciales(Me.grdCreditosVencidos)
            ''mdlPublicVars.fnFormatoGridMovimientos(Me.grdCreditosVencidos)
            ''mdlPublicVars.fnGrid_iconos(Me.grdCreditosVencidos)
            ''mdlPublicVars.fnFormatoGridEspeciales(Me.grdPendientesSurtir)
            ''mdlPublicVars.fnFormatoGridMovimientos(Me.grdPendientesSurtir)
            ''mdlPublicVars.fnGrid_iconos(Me.grdPendientesSurtir)
            ''mdlPublicVars.fnFormatoGridEspeciales(Me.grdClientes15Dias)
            ''mdlPublicVars.fnFormatoGridMovimientos(Me.grdClientes15Dias)
            ''mdlPublicVars.fnGrid_iconos(Me.grdClientes15Dias)
            ''mdlPublicVars.fnFormatoGridEspeciales(Me.grdClientesNuevos)
            ''mdlPublicVars.fnFormatoGridMovimientos(Me.grdClientesNuevos)
            ''mdlPublicVars.fnGrid_iconos(Me.grdClientesNuevos)

            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombo()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim dato = (From x In conexion.tblUsuarios Where x.bloqueado = False Order By x.tblVendedor.nombre Select Codigo = x.idUsuario, Nombre = x.tblVendedor.nombre + " (" + x.nombre + ")")

                With Me.cmbUsuarioFiltro
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = dato
                End With

                Dim usuarios As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                If usuarios.superUsuario = False Then
                    Me.cmbUsuarioFiltro.Enabled = False
                End If

                conn.Close()
            End Using

            Dim usuario As Integer = mdlPublicVars.idUsuario
            Me.cmbUsuarioFiltro.SelectedValue = usuario

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        ''Reservas
        Me.grdReservas.Columns(0).Width = 50
        Me.grdReservas.Columns(0).Width = 50
        Me.grdReservas.Columns(1).Width = 40
        Me.grdReservas.Columns(2).Width = 150
        Me.grdReservas.Columns(3).Width = 50
        Me.grdReservas.Columns(4).Width = 50

        '' ''Creditos Vencidos
        ''Me.grdCreditosVencidos.Columns(0).IsVisible = False
        ''Me.grdCreditosVencidos.Columns(3).IsVisible = True
        ''Me.grdCreditosVencidos.Columns(4).IsVisible = False
        ''Me.grdCreditosVencidos.Columns(1).Width = 125
        ''Me.grdCreditosVencidos.Columns(2).Width = 50
        ''Me.grdCreditosVencidos.Columns(3).Width = 50
        ''Me.grdCreditosVencidos.Columns(4).Width = 75
        ''Me.grdCreditosVencidos.Columns(5).Width = 50

        '' ''PendientesSurtir
        ''Me.grdPendientesSurtir.Columns(0).IsVisible = False
        ''Me.grdPendientesSurtir.Columns(1).IsVisible = False
        ''Me.grdPendientesSurtir.Columns(6).IsVisible = False
        ''Me.grdPendientesSurtir.Columns(2).Width = 40
        ''Me.grdPendientesSurtir.Columns(3).Width = 125
        ''Me.grdPendientesSurtir.Columns(4).Width = 50
        ''Me.grdPendientesSurtir.Columns(5).Width = 50
        ''Me.grdPendientesSurtir.Columns(6).Width = 75
        ''Me.grdPendientesSurtir.Columns(7).Width = 50
        ''Me.grdPendientesSurtir.Columns(8).Width = 50

        '' ''Clientes 15 Dias
        ''Me.grdClientes15Dias.Columns(0).IsVisible = False
        ''Me.grdClientes15Dias.Columns(3).IsVisible = False
        ''Me.grdClientes15Dias.Columns(1).Width = 125
        ''Me.grdClientes15Dias.Columns(2).Width = 75
        ''Me.grdClientes15Dias.Columns(3).Width = 75
        ''Me.grdClientes15Dias.Columns(4).Width = 50

        '' ''Clientes Nuevos
        ''Me.grdClientesNuevos.Columns(0).IsVisible = False
        ''Me.grdClientesNuevos.Columns(4).IsVisible = False
        ''Me.grdClientesNuevos.Columns(6).IsVisible = False
        ''Me.grdClientesNuevos.Columns(1).Width = 125
        ''Me.grdClientesNuevos.Columns(2).Width = 40
        ''Me.grdClientesNuevos.Columns(3).Width = 75
        ''Me.grdClientesNuevos.Columns(5).Width = 50
        ''Me.grdClientesNuevos.Columns(6).Width = 50

    End Sub

    Public Sub fnVerificarNotificaciones()
        fnVerificarReserva()
        fnVerificarCreditos()
        fnVerificarPendientesSurtir()
        fnVerificarCompraClientes()
        fnVerificarClientesNuevos()
        If contadornotificaciones >= 1 Then
            frmMenu.lbl7.Text = "Notificaciones (" & CStr(contadornotificaciones) & ")"
            frmMenu.lbl7.TextAlign = ContentAlignment.TopLeft
        End If
    End Sub

    Private Sub fnVerificarClientesNuevos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechahoy As Date = Now
                Dim fecha As Date
                Dim resultado
                Dim dias As Integer = 0

                Dim cliente As List(Of tblCliente) = (From x In conexion.tblClientes Where x.habillitado = True And x.idVendedor = mdlPublicVars.idVendedor Select x).ToList

                For Each Clientes As tblCliente In cliente

                    Dim salida As Integer
                    Try
                        salida = (From x In conexion.tblSalidas Where x.idCliente = Clientes.idCliente Select x).Count
                    Catch ex As Exception
                        salida = 0
                    End Try


                    If salida <= 2 Then
                        contadornotificaciones += 1
                    End If

                Next
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnVerificarCompraClientes()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim fechahoy As Date = Now
                Dim fecha As Date
                Dim resultado
                Dim dias As Integer = 0

                Dim cliente As List(Of tblCliente) = (From x In conexion.tblClientes Where x.habillitado = True And x.idVendedor = mdlPublicVars.idVendedor Select x).ToList

                For Each Clientes As tblCliente In cliente

                    resultado = conexion.sp_ObtenerFrecuenciaCompra(mdlPublicVars.idEmpresa, mdlPublicVars.idCliente)

                    For Each fila As sp_ObtenerFrecuenciaCompra_Result In resultado

                        fecha = Clientes.FechaUltimaCompra
                        dias = DateDiff(DateInterval.Day, fecha, fechahoy)

                        If (fila.valor - dias) <= 0 Then
                            contadornotificaciones += 1
                        End If
                    Next

                Next
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnVerificarPendientesSurtir()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Dim datos
                ''datos = conexion.sp_PendientesSurtirNotificaciones(mdlPublicVars.idEmpresa, mdlPublicVars.idUsuario, 0, 0)

                ''Me.grdPendientesSurtir.DataSource = datos

                Dim psurtir As List(Of tblSurtir) = (From x In conexion.tblSurtirs Where x.saldo > 0 And x.saldo = x.cantidad And x.vendedor = mdlPublicVars.idVendedor Select x).ToList

                Dim filas As Object()

                For Each surtir As tblSurtir In psurtir

                    Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = surtir.articulo And x.idTipoInventario = mdlPublicVars.General_idTipoInventario And x.saldo > 0 Select x).FirstOrDefault

                    If inventario Is Nothing Then
                        ''Exit Sub
                    End If

                    If inventario.saldo > 0 Then
                        contadornotificaciones += 1
                    End If
                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnVerificarCreditos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim resultado

                Dim cliente As List(Of tblCliente) = (From x In conexion.tblClientes Where x.habillitado = True And x.limiteCredito > 0 And x.idVendedor = mdlPublicVars.idVendedor Select x).ToList

                For Each Clientes As tblCliente In cliente

                    resultado = conexion.sp_VerificaCreditoCliente(Clientes.idCliente)

                    For Each fila As sp_VerificaCreditoCliente_Result In resultado
                        If fila.SaldoVencido = 1 Then
                            contadornotificaciones += 1
                        End If
                    Next

                Next
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnVerificarReserva()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim reservas As String = ""

                Dim listareservas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.reservado = True And x.anulado = False And x.despachar = False And x.facturado = False And x.cotizado = False And x.idVendedor = mdlPublicVars.idVendedor Select x).ToList

                For Each reserva As tblSalida In listareservas

                    Dim fecha As DateTime = Today.AddDays(-20)

                    If reserva.fechaRegistro < fecha Then
                        contadornotificaciones += 1
                        ''reservas += reserva.documento + ", "
                        Dim fila As Object()

                        fila = {reserva.idSalida, Format(reserva.fechaTransaccion, formatoFechaGridTeleric), reserva.cliente, reserva.total, 0}
                        Me.grdReservas.Rows.Add(fila)

                    End If
                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnLlenarReservas()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Dim reservas As String = ""
                ''Dim fechau As Date
                ''Dim listareservas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.reservado = True And x.anulado = False And x.despachar = False And x.facturado = False And x.cotizado = False And x.idVendedor = vendedorSeleccion Select x).ToList

                ''For Each reserva As tblSalida In listareservas

                ''    Dim fecha As DateTime = Today.AddDays(-20)

                ''    If reserva.fechaRegistro < fecha Then

                ''        Dim fila As Object()

                ''        fechau = reserva.fechaTransaccion

                ''        fila = {reserva.idSalida, fechau.ToShortDateString(), reserva.cliente, Format(reserva.total, formatoNumero), 0, Notificacion_Reserva}
                ''        Me.grdReservas.Rows.Add(fila)

                ''    End If
                ''Next

                Dim productos As String = ""
                Dim fecha As DateTime = Today.AddMonths(-1)
                Dim fechausar As Date
                Dim listaarticulos As List(Of tblArticulo) = (From x In conexion.tblArticuloes Where x.fechaprecio IsNot Nothing And x.Habilitado = True Select x).ToList

                For Each articulos As tblArticulo In listaarticulos

                    If articulos.fechaprecio > fecha Then
                        Dim fila As Object()

                        fechausar = articulos.fechaprecio

                        Dim inv As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulos.idArticulo And x.idTipoInventario = 1 Select x).FirstOrDefault

                        fila = {fechausar.ToShortDateString, articulos.codigo1, articulos.nombre1, inv.saldo}
                        Me.grdReservas.Rows.Add(fila)
                    End If

                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
        If (Me.grdReservas.Rows.Count - 1) >= 0 Then
            Me.grdReservas.Rows(0).IsCurrent = True
        End If
    End Sub

    Private Sub fnLlenarCreditosVencidos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim resultado
                Dim filas As Object()
                Dim saldovencido As Decimal
                Dim fechahoy As Date = Now
                Dim numero As Decimal
                Dim fechavencido As Date
                Dim salidafecha As Date

                Dim cliente As List(Of tblCliente) = (From x In conexion.tblClientes Where x.habillitado = True And x.idVendedor = vendedorSeleccion Select x).ToList

                For Each Clientes As tblCliente In cliente

                    saldovencido = 0

                    resultado = conexion.sp_VerificaCreditoCliente(Clientes.idCliente)

                    For Each fila As sp_VerificaCreditoCliente_Result In resultado
                        If fila.SaldoVencido > 0 Then

                            Dim salidas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.anulado = False And x.empacado = True And x.idCliente = Clientes.idCliente And x.saldo > 0 Select x).ToList

                            For Each salida As tblSalida In salidas

                                numero = CDec(Clientes.diasCredito)
                                salidafecha = salida.fechaDespachado

                                fechavencido = DateAdd(DateInterval.Day, numero, salidafecha)

                                If fechavencido < fechahoy Then
                                    Try
                                        saldovencido += CDec(salida.saldo)
                                    Catch ex As Exception
                                        saldovencido += 0
                                    End Try
                                End If

                            Next

                            filas = {Clientes.idCliente, Clientes.Negocio, Clientes.saldo, Format(saldovencido, formatoNumero), Clientes.tblVendedor.nombre, 0, Notificacion_CreditosVencidos}
                            Me.grdCreditosVencidos.Rows.Add(filas)
                        End If
                    Next

                Next
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
        If (Me.grdCreditosVencidos.Rows.Count - 1) >= 0 Then
            Me.grdCreditosVencidos.Rows(0).IsCurrent = True
        End If
    End Sub

    Private Sub grdReservas_Click(sender As Object, e As EventArgs) Handles grdReservas.Click
        If (Me.grdReservas.Rows.Count - 1) >= 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdReservas)

            If fila >= 0 Then
                Dim columna As Integer = Me.grdReservas.CurrentColumn.Index

                If columna >= 0 Then
                    If grdReservas.Columns(columna).Name = "chkRevisado" Then

                        Dim conexion As dsi_pos_demoEntities
                        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            conn.Open()
                            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                            If Me.grdReservas.Rows(fila).Cells("chkRevisado").Value = True Then
                                RadMessageBox.Show("La Notificacion ya fue Revisada", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                Exit Sub
                            End If

                            If RadMessageBox.Show("¿Desea Confirmar la Revision de la Reserva (Notificacion)?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Try
                                    Dim idsalida As Integer = Me.grdReservas.Rows(fila).Cells("idsalida").Value

                                    Dim nuevo As New tblNotificacione
                                    nuevo.codigonotificacion = mdlPublicVars.Notificacion_Reserva
                                    nuevo.idsalida = idsalida
                                    nuevo.idusuario = mdlPublicVars.idUsuario
                                    nuevo.Fecha = mdlPublicVars.fnFecha_horaServidor

                                    conexion.AddTotblNotificaciones(nuevo)
                                    conexion.SaveChanges()

                                    alerta.contenido = "Se Reviso Correctamente la Notificacion"
                                    alerta.fnErrorContenido()

                                    Me.grdReservas.Rows(fila).Cells("chkRevisado").Value = True

                                Catch ex As Exception

                                End Try
                            End If

                            conn.Close()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdCreditosVencidos_Click(sender As Object, e As EventArgs) Handles grdCreditosVencidos.Click
        If (Me.grdCreditosVencidos.Rows.Count - 1) >= 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdCreditosVencidos)

            If fila >= 0 Then
                Dim columna As Integer = Me.grdCreditosVencidos.CurrentColumn.Index

                If columna >= 0 Then
                    If grdCreditosVencidos.Columns(columna).Name = "chkRevisado" Then

                        Dim conexion As dsi_pos_demoEntities
                        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                            conn.Open()
                            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                            If Me.grdCreditosVencidos.Rows(fila).Cells("chkRevisado").Value = True Then
                                RadMessageBox.Show("La Notificacion ya fue Revisada", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                Exit Sub
                            End If

                            If RadMessageBox.Show("¿Desea Confirmar la Revision del Credito Vencido (Notificacion)?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Try
                                    Dim idcliente As Integer = Me.grdCreditosVencidos.Rows(fila).Cells("idcliente").Value

                                    Dim nuevo As New tblNotificacione
                                    nuevo.codigonotificacion = mdlPublicVars.Notificacion_CreditosVencidos
                                    nuevo.idcliente = idcliente
                                    nuevo.idusuario = mdlPublicVars.idUsuario
                                    nuevo.Fecha = mdlPublicVars.fnFecha_horaServidor

                                    conexion.AddTotblNotificaciones(nuevo)
                                    conexion.SaveChanges()

                                    alerta.contenido = "Se Reviso Correctamente la Notificacion"
                                    alerta.fnErrorContenido()

                                    Me.grdCreditosVencidos.Rows(fila).Cells("chkRevisado").Value = True

                                Catch ex As Exception

                                End Try
                            End If

                            conn.Close()
                        End Using
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub cmbUsuarioFiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbUsuarioFiltro.SelectedValueChanged
        Try
            usuarioSeleccion = Me.cmbUsuarioFiltro.SelectedValue

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                vendedorSeleccion = (From x In conexion.tblUsuarios Where x.idUsuario = usuarioSeleccion Select x.idVendedor).FirstOrDefault

                conn.Close()
            End Using

            fnLlenarListados()
        Catch ex As Exception

        End Try
    End Sub
End Class
