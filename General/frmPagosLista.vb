Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmPagosLista

    Private _listaSalidas As List(Of Tuple(Of Integer, String, Decimal))
    Private _listaEntradas As List(Of Tuple(Of Integer, String, Decimal))
    Private lista As List(Of Tuple(Of Integer, String, Decimal))

    Public Property listaSalidas As List(Of Tuple(Of Integer, String, Decimal))
        Get
            listaSalidas = _listaSalidas
        End Get
        Set(value As List(Of Tuple(Of Integer, String, Decimal)))
            _listaSalidas = value
        End Set
    End Property

    Public Property listaEntradas As List(Of Tuple(Of Integer, String, Decimal))
        Get
            listaEntradas = _listaEntradas
        End Get
        Set(value As List(Of Tuple(Of Integer, String, Decimal)))
            _listaEntradas = value
        End Set
    End Property

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitCompra As Boolean
    Private _bitVenta As Boolean

    Public codigoCP As Integer = 0
    Public contadorActualizar As Integer = 0
    Public filtroActivo As Boolean
    Private permiso As New clsPermisoUsuario
    Private cargo As Boolean

    Dim _fechaAnterior As DateTime
    Dim fechaActual As DateTime = Now

    Public Property fechaAnterior As DateTime
        Get
            fechaAnterior = _fechaAnterior
        End Get
        Set(value As DateTime)
            _fechaAnterior = value
        End Set
    End Property




    Public Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Public Property bitCompra() As Boolean
        Get
            bitCompra = _bitCompra
        End Get
        Set(ByVal value As Boolean)
            _bitCompra = value
        End Set
    End Property

    Public Property bitVenta() As Boolean
        Get
            bitVenta = _bitVenta
        End Get
        Set(ByVal value As Boolean)
            _bitVenta = value
        End Set
    End Property




    Private Sub frmPagosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.grdDatos.ImageList = frmControles.ImageListAdministracion

            If bitCliente = True Then

                If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                    Dim iz As New frmClientePequenioBarraIzquierda
                    iz.frmAnterior = Me
                    frmBarraLateralBaseIzquierda = iz
                Else
                    Dim iz As New frmClientesBarraIzquierda
                    iz.frmAnterior = Me
                    frmBarraLateralBaseIzquierda = iz
                End If

            ElseIf bitProveedor = True Then
                Dim iz As New frmProveedorBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            ElseIf bitCompra = True Then
                Dim iz As New frmComprasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz

            ElseIf bitVenta = True Then

                If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                    Dim iz As New frmVentaPequeniaBarraIzquierda
                    iz.frmAnterior = Me
                    frmBarraLateralBaseIzquierda = iz
                Else
                    Dim iz As New frmPedidosFacturasBarraIzquierda
                    iz.frmAnterior = Me
                    frmBarraLateralBaseIzquierda = iz
                End If

            End If

            If bitCliente Or bitVenta Then
                frmBarraLateralBaseDerecha = frmPagosListaBarraDerecha
                pnlOpciones.Enabled = True
                pnlOpciones.Visible = True
            Else
                pnlOpciones.Enabled = False
                pnlOpciones.Visible = False
            End If

            ActivarBarraLateral = True
            lbl2Eliminar.Text = "Anular"


        Catch ex As Exception

        End Try

        lblFiltroFecha.Visible = False
        cmbFiltroFecha.Visible = False

        grdDatos.Focus()
        fnLlenarCombo()
        cargo = True
        llenagrid()
    End Sub

    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Dim conexion As New dsi_pos_demoEntities


        Dim datos
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            datos = (From x In conexion.tblListaFiltroFechas Select x.orden, codigo = x.dias, x.nombre
                         Order By orden Ascending)
            conn.Close()
        End Using

        With cmbFiltroFecha
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = datos
        End With
    End Sub


    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click

        If Me.grdDatos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If (Me.grdDatos.CurrentColumn.Name.Equals("chmConfirmar")) And fila >= 0 Then

                'Verficamos si el pago no ha sido anulado
                Dim anulado As Boolean = Me.grdDatos.Rows(fila).Cells("chkAnulado").Value
                Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value
                If anulado Then
                    RadMessageBox.Show("El pago ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                ElseIf valor = False Then
                    Dim user
                    Dim conexion As New dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                        'Verificamos si el usuario puede confirmar pagos
                        user = (From x In conexion.tblUsuarios.AsEnumerable Where x.idUsuario = mdlPublicVars.idUsuario _
                                                  Select x).FirstOrDefault
                        conn.Close()
                    End Using
                    If user.bitConfirmaPago Then
                        Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = True
                        If RadMessageBox.Show("Desea confirmar pago?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                            mdlPublicVars.superSearchFechaString = Nothing
                            If RadMessageBox.Show("Desea cambiar la fecha de confirmacion del Pago?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                                mdlPublicVars.superSearchFechaString = Nothing
                                frmFecha.Text = "Fecha"
                                frmFecha.opcionRetorno = "pagoLista"
                                frmFecha.StartPosition = FormStartPosition.CenterScreen
                                frmFecha.ShowDialog()

                                If mdlPublicVars.superSearchFechaString IsNot Nothing Then
                                    fnConfirmarPago()
                                End If
                            Else
                                fnConfirmarPago()
                            End If

                            If RadMessageBox.Show("¿Desea imprimir recibo de caja?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Dim filas As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                                Dim idPago As Integer = CType(Me.grdDatos.Rows(filas).Cells("Codigo").Value, Integer)

                                Dim r As New clsReporte
                                r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteReciboCajaBancos(idPago))
                                r.reporte = "rptReciboCajaBancos.rpt"
                                r.imprimirReporte()
                            End If

                            llenagrid()

                        Else
                            Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = False
                        End If
                    Else
                        RadMessageBox.Show("No tiene permisos para confirmar pagos", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End If
                End If
            End If

            If (Me.grdDatos.CurrentColumn.Name.Equals("chmAsociado")) And fila >= 0 Then
                ''RadMessageBox.Show("Quiere Asociar el Pago?", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                Dim anulado As Boolean = Me.grdDatos.Rows(fila).Cells("chkAnulado").Value
                Dim asociado As Boolean = Me.grdDatos.Rows(fila).Cells("chmAsociado").Value
                If anulado Then
                    RadMessageBox.Show("El pago ya ha sido anulado!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    Return False
                    Exit Function
                End If
                If asociado Then
                    RadMessageBox.Show("El pago ya esta asociado a un documento!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    Return False
                    Exit Function
                End If

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    If bitCliente Or bitVenta Then

                        Dim filas As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
                        Dim idpago As Integer = Me.grdDatos.Rows(filas).Cells("Codigo").Value
                        Dim totalmovimiento As Decimal = Me.grdDatos.Rows(filas).Cells("Total").Value


                        Dim idcliente As Integer = (From x In conexion.tblCajas Where x.codigo = idpago Select x.cliente).FirstOrDefault

                        Try
                            mdlPublicVars.superSearchLista3 = Nothing

                            listaSalidas = New List(Of Tuple(Of Integer, String, Decimal))

                            Dim form As New frmFacturasElegir
                            form.listaSalidas = listaSalidas
                            form.Text = "Facturas Cliente"
                            form.StartPosition = FormStartPosition.CenterScreen
                            form.WindowState = FormWindowState.Normal
                            form.idcliente = idcliente
                            form.txtAcreditacionTotal.Text = totalmovimiento
                            form.ShowDialog()
                            form.Dispose()
                            listaSalidas = mdlPublicVars.superSearchLista3

                            Dim contador As Integer

                            contador = CStr(listaSalidas.Count)

                            Dim totalpago As Decimal = 0

                            For Each empleado As Tuple(Of Integer, String, Decimal) In listaSalidas
                                ''txtFacturas.Text += empleado.Item2 & ", "
                                totalpago += empleado.Item3
                                ''txtTotalFacturas.Text = Format(total, formatoMoneda)
                            Next

                            If totalpago > totalmovimiento Then
                                alertas.contenido = "El monto ingresado en facturas es mayor al total registado del pago!!!"
                                alertas.fnErrorContenido()
                                Return False
                                Exit Function
                            End If

                            fnAsociarPagos(idpago)
                            llenagrid()
                        Catch

                        End Try

                    ElseIf bitProveedor Or bitCompra Then

                        Dim filas As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
                        Dim idpago As Integer = Me.grdDatos.Rows(filas).Cells("Codigo").Value
                        Dim totalmovimiento As Decimal = Me.grdDatos.Rows(filas).Cells("Total").Value


                        Dim idproveedor As Integer = (From x In conexion.tblCajas Where x.codigo = idpago Select x.proveedor).FirstOrDefault

                        Try
                            mdlPublicVars.superSearchLista3 = Nothing

                            listaEntradas = New List(Of Tuple(Of Integer, String, Decimal))

                            Dim form As New frmFacturasElegir
                            form.listaSalidas = listaEntradas
                            form.Text = "Facturas Proveedor"
                            form.StartPosition = FormStartPosition.CenterScreen
                            form.WindowState = FormWindowState.Normal
                            form.idproveedor = idproveedor
                            form.txtAcreditacionTotal.Text = totalmovimiento
                            form.ShowDialog()
                            form.Dispose()
                            listaEntradas = mdlPublicVars.superSearchLista3

                            Dim contador As Integer

                            contador = CStr(listaEntradas.Count)

                            Dim totalpago As Decimal = 0

                            For Each empleado As Tuple(Of Integer, String, Decimal) In listaEntradas
                                ''txtFacturas.Text += empleado.Item2 & ", "
                                totalpago += empleado.Item3
                                ''txtTotalFacturas.Text = Format(total, formatoMoneda)
                            Next

                            If totalpago > totalmovimiento Then
                                alertas.contenido = "El monto ingresado en facturas es mayor al total registado del pago!!!"
                                alertas.fnErrorContenido()
                                Return False
                                Exit Function
                            End If

                            fnAsociarPagos(idpago)
                            llenagrid()
                        Catch

                        End Try

                    End If

                    conn.Close()
                End Using

            End If

        End If

        Return False
    End Function

    Private Sub fnAsociarPagos(ByVal idpago As Integer)
        Try
            Dim proveedor As Boolean = False
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim pagom As tblCaja = (From x In conexion.tblCajas Where x.codigo = idpago Select x).FirstOrDefault
                Dim pagotipo As tblTipoPago = (From x In conexion.tblTipoPagoes Where x.codigo = pagom.tipoPago Select x).FirstOrDefault

                Dim codpago As Integer

                If pagom.cliente Is Nothing Then
                    lista = listaEntradas
                ElseIf pagom.proveedor Is Nothing Then
                    lista = listaSalidas
                End If

                For Each salida As Tuple(Of Integer, String, Decimal) In lista

                    If pagom.tipoPago > 0 Then
                        Dim pago As New tblCaja

                        pago.tipoPago = pagom.tipoPago
                        pago.empresa = mdlPublicVars.idEmpresa
                        pago.fecha = fnFecha_horaServidor() ''dtpFechaInicio.Text & " " & fecha.ToLongTimeString
                        pago.fechaTransaccion = fnFecha_horaServidor() ''fecha
                        pago.confirmado = False
                        pago.transito = 0
                        pago.monto = salida.Item3
                        pago.documento = pagom.documento
                        pago.usuario = mdlPublicVars.idUsuario
                        pago.anulado = 0
                        If pagom.cliente Is Nothing Or pagom.cliente = 0 Then
                            pago.identradapago = salida.Item1
                            pago.proveedor = pagom.proveedor
                            proveedor = True
                        ElseIf pagom.proveedor Is Nothing Or pagom.proveedor = 0 Then
                            pago.idsalidapago = salida.Item1
                            pago.cliente = pagom.cliente
                            proveedor = False
                        End If
                        pago.observacion = pagom.observacion
                        pago.descripcion = pagotipo.nombre
                        pago.bitRechazado = False
                        pago.bitEntrada = 1
                        pago.bitSalida = 0
                        pago.tipoCambio = 1
                        pago.fecharegistro = CDate(fnFechaServidor())
                        pago.fechaFiltro = CDate(fnFechaServidor())
                        pago.consumido = 0
                        pago.afavor = 0
                        pago.confirmado = True
                        pago.codutilizado = False
                        pago.docboletadeposito = pagom.docboletadeposito

                        conexion.AddTotblCajas(pago)
                        conexion.SaveChanges()
                        codpago = pago.codigo


                    End If
                    If proveedor = False Then
                        Dim salidamod As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salida.Item1 Select x).FirstOrDefault

                        salidamod.saldo -= salida.Item3
                        salidamod.pagado += salida.Item3


                        conexion.SaveChanges()
                    ElseIf proveedor = True Then
                        Dim entradamod As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = salida.Item1 Select x).FirstOrDefault

                        entradamod.saldo -= salida.Item3
                        entradamod.pagos += salida.Item3


                        conexion.SaveChanges()
                    End If
                    Dim pagomod As tblCaja = (From x In conexion.tblCajas Where x.codigo = pagom.codigo Select x).FirstOrDefault

                    pagomod.monto -= salida.Item3
                    pagomod.afavor = pagomod.monto
                    pagomod.consumido = salida.Item3

                    If pagomod.monto = 0 Then
                        pagomod.anulado = True
                    End If

                    conexion.SaveChanges()


                    ''If pagoTipo.calendarizada = False Then


                    ''    Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = codpago Select x).FirstOrDefault

                    ''    pago.confirmado = True

                    ''    conexion.SaveChanges()



                    ''    Dim totalpago As Decimal = salida.Item3

                    ''    Dim clie As tblCliente = (From x In conexion.tblClientes Where x.idCliente = pagom.cliente Select x).FirstOrDefault

                    ''    clie.saldo -= totalpago
                    ''    clie.pagos += totalpago

                    ''    conexion.SaveChanges()


                    ''    Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salida.Item1 Select x).FirstOrDefault

                    ''    If totalpago > 0 And sal.saldo > 0 Then
                    ''        If totalpago = sal.saldo Then

                    ''            sal.saldo = 0
                    ''            sal.pagado = sal.total

                    ''        ElseIf totalpago < sal.saldo Then

                    ''            sal.saldo -= totalpago
                    ''            sal.pagado += totalpago
                    ''            totalpago = 0

                    ''        End If

                    ''        conexion.SaveChanges()

                    ''    Else
                    ''        Exit For
                    ''    End If

                    ''End If

                Next

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    'llena el Grid 
    Private Sub llenagrid()

        ''Dim fechaFiltro As DateTime = fechaActual.AddDays(-cmbFiltroFecha.SelectedValue)
        ''Dim fechaBusqueda As String = Format(fechaFiltro, "dd/MM/yyyy hh:mm:ss")

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim fechainicio As DateTime
            Dim fechafin As DateTime

            fechainicio = dtpFechaInicio.Value.ToShortDateString + " 00:00:00.000"
            fechafin = dtpFechaFin.Value.ToShortDateString + " 23:59:59.999"

            Try
                Dim filtro As String = txtFiltro.Text
                Dim companyInfo = Nothing

                If bitCliente = True Then

                    companyInfo = (From x In (
                                    (From x In conexion.tblCajas _
                                   Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                                    And x.bitEntrada = True And (x.fecha > fechainicio And x.fecha < fechafin) _
                                   Select Codigo = x.codigo, Fecha = CDate(x.fechaFiltro), ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave,
                                   Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                                   Doc = x.documento, Total = x.monto,
                                   clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                                   chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado,
                                   chmAsociado = If(x.idsalidapago Is Nothing, False, True)).Union(
                                   From x In conexion.tblCajas _
                                   Where (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                                   And x.proveedor Is Nothing And x.codigoEntrada Is Nothing And x.codigoSalida Is Nothing And x.cliente Is Nothing _
                                   And x.bitEntrada = True _
                                   And (x.fecha > fechainicio And x.fecha < fechafin)
                                    Select Codigo = x.codigo, Fecha = CDate(x.fechaFiltro), ID = 0, Clave = "",
                                   Negocio = "", TipoPago = x.tblTipoPago.nombre, _
                                   Doc = x.documento, Total = x.monto,
                                   clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                                   chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado,
                                   chmAsociado = If(x.idsalidapago Is Nothing, False, True))) Select x Order By x.Fecha Descending)

                    '  and (@diasFiltro =-1 OR (@diasFiltro>=0 AND  f.Fecha> DATEADD(day,-@diasFiltro,GETDATE())))
                ElseIf bitProveedor = True Or bitCompra = True Then
                    companyInfo = From x In conexion.tblCajas _
                                  Where x.proveedor > 0 And (x.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                                 Order By x.fecha Descending Select Codigo = x.codigo, Fecha = x.fechaFiltro, ID = x.tblProveedor.idProveedor, Clave = x.tblProveedor.clave, Negocio = x.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32), chkAnulado = x.anulado,
                               FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado, _
                               chmAsociado = If(x.identradapago Is Nothing, False, True)


                ElseIf bitCompra = True Then
                    companyInfo = From x In conexion.tblCajas Join y In conexion.tblEntradas On x.codigoSalida Equals y.idEntrada _
                               Where x.anulado = False And x.codigoSalida > 0 And (y.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                                               Select Codigo = x.codigo, Numero = y.correlativo, Fecha = x.fechaFiltro, ID = x.tblCliente.idCliente, Clave = y.idProveedor, Negocio = y.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")), Int32), chmConfirmar = x.confirmado

                ElseIf bitVenta = True Then
                    'companyInfo = From x In conexion.tblCajas _
                    '           Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                    '           And x.fecha > fechaBusqueda
                    '           Select Codigo = x.codigo, Fecha = x.fecha, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                    '           Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.bitRechazado, "3", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")))), Int32),
                    '           chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                    '           Order By Fecha Descending


                    companyInfo = (From x In (From x In conexion.tblCajas _
                               Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                               And (x.fecha > fechainicio And x.fecha < fechafin) _
                               Select Codigo = x.codigo, Fecha = x.fechaFiltro, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.bitRechazado, "3", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")))), Int32),
                               chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado,
                               chmAsociado = If(x.idsalidapago Is Nothing, False, True)).Union(
                                   From x In conexion.tblCajas _
                                   Where (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                                   And x.proveedor Is Nothing And x.codigoEntrada Is Nothing And x.codigoSalida Is Nothing And x.cliente Is Nothing _
                                   And x.bitEntrada = True _
                                   And (x.fecha > fechainicio And x.fecha < fechafin) _
                                    Select Codigo = x.codigo, Fecha = x.fechaFiltro, ID = 0, Clave = "",
                                   Negocio = "", TipoPago = x.tblTipoPago.nombre, _
                                   Doc = x.documento, Total = x.monto,
                                   clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                                   chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado,
                                   chmAsociado = If(x.idsalidapago Is Nothing, False, True)) Select x Order By x.Fecha Descending)

                End If

                Me.grdDatos.DataSource = companyInfo
                'cambiar iconos del grid.
                mdlPublicVars.fnGrid_iconos(Me.grdDatos)
                fnConfiguracion()
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try

            conn.Close()

        End Using

    End Sub


    Public Sub llenagrid(desde As DateTime, hasta As DateTime)

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                Dim filtro As String = txtFiltro.Text
                Dim companyInfo = Nothing

                If bitCliente = True Then
                    companyInfo = From x In conexion.tblCajas _
                               Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                               And x.fecha > desde And x.fecha < hasta _
                               Select Codigo = x.codigo, Fecha = x.fechaFiltro, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                               chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                               Order By Fecha Descending
                ElseIf bitProveedor = True Or bitCompra = True Then
                    companyInfo = From x In conexion.tblCajas _
                               Where x.proveedor > 0 And (x.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                               And x.fecha > desde And x.fecha < hasta _
                               Select Codigo = x.codigo, Fecha = x.fechaFiltro, ID = x.tblProveedor.idProveedor, Clave = x.tblProveedor.clave, Negocio = x.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32), chkAnulado = x.anulado,
                               FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                               Order By Fecha Descending
                ElseIf bitCompra = True Then
                    companyInfo = From x In conexion.tblCajas Join y In conexion.tblEntradas On x.codigoSalida Equals y.idEntrada _
                               Where x.anulado = False And x.codigoSalida > 0 And (y.tblProveedor.negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                               And x.fecha > desde And x.fecha < hasta _
                               Select Codigo = x.codigo, Numero = y.correlativo, Fecha = x.fechaFiltro, ID = x.tblCliente.idCliente, Clave = y.idProveedor, Negocio = y.tblProveedor.negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0")), Int32), chmConfirmar = x.confirmado
                ElseIf bitVenta = True Then
                    companyInfo = From x In conexion.tblCajas _
                               Where (x.cliente > 0) And (x.tblCliente.Negocio.Contains(filtro) Or CType(x.tblTipoPago.nombre, String).Contains(filtro)) _
                               And x.fecha > desde And x.fecha < hasta _
                               Select Codigo = x.codigo, Fecha = x.fechaFiltro, ID = x.tblCliente.idCliente, Clave = x.tblCliente.clave, Negocio = x.tblCliente.Negocio, TipoPago = x.tblTipoPago.nombre, _
                               Doc = x.documento, Total = x.monto, clrEstado = CType(If(x.anulado = True, "0", If(x.confirmado = False, "1", If(x.confirmado = True, "4", "0"))), Int32),
                               chkAnulado = x.anulado, FechaConfirmado = x.fechaCobro, chmConfirmar = x.confirmado
                               Order By Fecha Descending
                End If

                Me.grdDatos.DataSource = companyInfo
                'cambiar iconos del grid.
                mdlPublicVars.fnGrid_iconos(Me.grdDatos)
                fnConfiguracion()
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                If contadorActualizar = 0 Then
                    contadorActualizar += 1
                Else
                    Exit Sub
                End If
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaConfirmado")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

                Me.grdDatos.Columns("ID").IsVisible = False

                Me.grdDatos.Columns("chkAnulado").HeaderText = "Anulado"
                Me.grdDatos.Columns("clrEstado").HeaderText = "Estado"
                Me.grdDatos.Columns("FechaConfirmado").HeaderText = "Fecha Confirm."

                Me.grdDatos.Columns("Codigo").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Clave").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Negocio").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("TipoPago").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("FechaConfirmado").TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns("Codigo").Width = 60
                Me.grdDatos.Columns("Fecha").Width = 80
                Me.grdDatos.Columns("Clave").Width = 60
                Me.grdDatos.Columns("Negocio").Width = 200
                Me.grdDatos.Columns("TipoPago").Width = 130
                Me.grdDatos.Columns("Doc").Width = 80
                Me.grdDatos.Columns("Monto").Width = 70
                Me.grdDatos.Columns("clrEstado").Width = 70
                Me.grdDatos.Columns("chkAnulado").Width = 50
                Me.grdDatos.Columns("chmConfirmar").Width = 110

            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub fnConfirmarPago()
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        Dim idPago As Integer = CType(Me.grdDatos.Rows(fila).Cells("Codigo").Value, Integer)
        Dim idCliente As Integer
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(fila).Cells("chkAnulado").Value, Boolean)
        If bitCliente = True Then
            idCliente = CType(Me.grdDatos.Rows(fila).Cells("ID").Value, Integer)
        End If
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim success As Boolean = True

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Using transaction As New TransactionScope
                Try
                    If anulado = True Then
                        success = False
                        Exit Try
                    Else
                        'Confirmamos el pago
                        Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = idPago Select x).FirstOrDefault
                        pago.confirmado = 1

                        'pago.fechaCobro = fechaServer
                        If mdlPublicVars.superSearchFechaString IsNot Nothing Then
                            pago.fechaCobro = superSearchFechaString
                        Else
                            pago.fechaCobro = fechaServer
                        End If

                        If pago.transito = True Then
                            pago.transito = False
                        End If

                        'guardar los cambios
                        conexion.SaveChanges()

                        'Si es una salida
                        If pago.codigoEntrada > 0 Then
                            Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = pago.codigoEntrada Select x).FirstOrDefault

                            If factura.contado = True Then
                                'Realizamos las transacciones correspondientes
                                factura.saldo -= pago.monto
                                factura.pagos += pago.monto
                                If factura.saldo = 0 Then
                                    factura.pagado = 1
                                End If

                                'guardar los cambios.
                                conexion.SaveChanges()
                            Else
                                Dim montoPagar = pago.monto

                                Dim listaSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.IdFactura = factura.IdFactura Select x).ToList
                                Dim salida As tblSalida

                                For Each salida In listaSalidas
                                    Dim ctaCobrar As tblCtaCobrar = (From x In conexion.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                    If montoPagar > ctaCobrar.saldo Then
                                        montoPagar -= ctaCobrar.saldo
                                        ctaCobrar.saldo = 0
                                        ctaCobrar.cancelada = 1
                                    Else
                                        ctaCobrar.saldo -= montoPagar
                                        montoPagar = 0
                                    End If
                                Next

                            End If

                            'Guardar los cambios.
                            conexion.SaveChanges()

                            'Si es una entrada
                        ElseIf pago.codigoSalida > 0 Then

                            If mdlPublicVars.PuntoVentaPequeno_Activado = True And mdlPublicVars.bitTransportePesado = True Then

                                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = pago.codigoSalida Select x).FirstOrDefault

                                If salida.contado = True Then

                                    salida.saldo -= pago.monto
                                    salida.pagado += pago.monto

                                ElseIf salida.credito = True Then

                                    Dim montopagar = pago.monto

                                    salida.pagado += montopagar
                                    salida.saldo -= montopagar

                                    Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                                    cliente.saldo -= montopagar
                                    cliente.pagos += montopagar

                                    conexion.SaveChanges()



                                End If

                            Else

                                Dim entrada As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = pago.codigoSalida Select x).FirstOrDefault
                                If entrada.contado = True Then
                                    'Realizamos las transacciones correspondientes
                                    entrada.saldo -= pago.monto
                                    entrada.pagos += pago.monto

                                    If entrada.saldo = 0 Then
                                        entrada.cancelado = 1
                                    End If
                                Else
                                    Dim montoPagar = pago.monto

                                    Dim ctaPagar As tblCtaPagar = (From x In conexion.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                                    If montoPagar > ctaPagar.saldo Then
                                        montoPagar -= ctaPagar.saldo
                                        ctaPagar.saldo = 0
                                        ctaPagar.cancelada = 1
                                    Else
                                        ctaPagar.saldo -= montoPagar
                                        montoPagar = 0
                                    End If

                                    'guardar los cambios
                                    conexion.SaveChanges()
                                End If

                            End If

                            'Si en un cliente
                        ElseIf pago.cliente > 0 Then
                            Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In conexion.tblCtaCobrars Where x.idCliente = pago.cliente And x.cancelada = False Select x Order By x.fecha Ascending).ToList
                            Dim ctaCobrar As tblCtaCobrar

                            Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                            'restar el monto del pago de los pagos en transito del cliente.
                            cliente.pagosTransito -= pago.monto

                            'variable que guarda el monto a pagar.
                            Dim montoPagar = pago.monto

                            'incrementar al pago
                            cliente.pagos += pago.monto

                            'Restar del saldo.
                            cliente.saldo -= pago.monto

                            'actualizamos la fecha de ultimo pago
                            'cliente.fechaUltimoPago = fechaServer
                            If superSearchFechaString IsNot Nothing Then
                                cliente.fechaUltimoPago = superSearchFechaString
                            Else
                                cliente.fechaUltimoPago = fechaServer
                            End If

                            'guardar los cambios.
                            conexion.SaveChanges()

                            'Aplicacion a las cuentas por cobrar.
                            Dim montoPagar2 As Decimal = montoPagar
                            For Each ctaCobrar In listasCtaCobrar

                                If montoPagar > ctaCobrar.saldo Then
                                    montoPagar -= ctaCobrar.saldo
                                    ctaCobrar.pagado += ctaCobrar.saldo
                                    ctaCobrar.saldo = 0
                                    ctaCobrar.cancelada = 1
                                Else
                                    ctaCobrar.saldo -= montoPagar
                                    ctaCobrar.pagado += montoPagar
                                    montoPagar = 0
                                End If
                            Next

                            'Aplicacion a las salida - YOEL
                            'Modificamos las salidas
                            Dim consumido As Decimal = 0



                            If pago.idsalidapago IsNot Nothing Then
                                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = pago.idsalidapago Select x).FirstOrDefault

                                salida.saldo -= pago.monto
                                salida.pagado += pago.monto

                                conexion.SaveChanges()

                            Else
                                Dim listasSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas
                                                                           Where x.idCliente = pago.cliente And x.empacado And Not x.anulado _
                                                                           And x.saldo > 0
                                                                           Order By x.fechaDespachado Ascending Select x).ToList
                                Dim salida As tblSalida

                                For Each salida In listasSalidas
                                    If montoPagar2 = 0 Then
                                        Exit For
                                    End If
                                    Dim detallePago As New tblCajaSalida
                                    detallePago.idCaja = pago.codigo
                                    detallePago.idSalida = salida.idSalida
                                    detallePago.idCliente = cliente.idCliente
                                    detallePago.fechaRegistro = fechaServer
                                    detallePago.fechaFiltro = fechaServer

                                    If montoPagar2 > salida.saldo Then
                                        detallePago.monto = salida.saldo
                                        detallePago.saldoNuevo = 0
                                        detallePago.saldoSalida = salida.saldo

                                        montoPagar2 -= salida.saldo
                                        salida.pagado += salida.saldo
                                        salida.saldo = 0
                                    Else
                                        detallePago.monto = montoPagar2
                                        detallePago.saldoNuevo = (salida.saldo - montoPagar2)
                                        detallePago.saldoSalida = salida.saldo

                                        salida.saldo -= montoPagar2
                                        salida.pagado += montoPagar2
                                        montoPagar2 = 0
                                    End If
                                    consumido += detallePago.monto
                                    conexion.AddTotblCajaSalidas(detallePago)
                                    conexion.SaveChanges()
                                Next
                            End If

                            pago.consumido += consumido
                            pago.afavor -= consumido

                            conexion.SaveChanges()

                            'SISTEMA BANCOS
                            If pago.cuenta > 0 Then
                                Dim numeroCorrelativo As Integer = 0

                                'CORRELATIVO
                                Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                                     Select x).FirstOrDefault

                                correlativo.correlativo += 1
                                numeroCorrelativo = correlativo.correlativo
                                conexion.SaveChanges()

                                'Obtenemos el acreditador
                                Dim acreditador As tblBanco_Beneficiario = (From x In conexion.tblBanco_Beneficiario Where x.bitCredito And x.nombre.Equals(pago.tblCliente.Negocio)
                                                                            Select x).FirstOrDefault
                                Dim idAcreditador As Integer = 0
                                Dim nombreAcreditador As String = ""

                                If acreditador IsNot Nothing Then
                                    idAcreditador = acreditador.codigo
                                    nombreAcreditador = acreditador.nombre
                                Else
                                    'Creamos el acreditador
                                    Dim nuevoAcreditador As New tblBanco_Beneficiario
                                    nuevoAcreditador.bitCredito = True
                                    nuevoAcreditador.bitDebitoCheque = False
                                    nuevoAcreditador.nombre = pago.tblCliente.Negocio

                                    conexion.AddTotblBanco_Beneficiario(nuevoAcreditador)
                                    conexion.SaveChanges()

                                    idAcreditador = nuevoAcreditador.codigo
                                    nombreAcreditador = nuevoAcreditador.nombre
                                End If

                                'Creamos el encabezado de la acreditacion
                                Dim movimiento As New tblBanco_Creditos
                                movimiento.bitAnulado = False
                                movimiento.correlativo = numeroCorrelativo
                                movimiento.documento = pago.documento
                                movimiento.fechaRegistro = pago.fecha
                                movimiento.total = pago.monto
                                movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                                movimiento.bitConfirmado = True
                                movimiento.usuarioConfirma = mdlPublicVars.idUsuario

                                'movimiento.fechaConfirmado = fechaServer
                                If superSearchFechaString IsNot Nothing Then
                                    movimiento.fechaConfirmado = superSearchFechaString
                                Else
                                    movimiento.fechaConfirmado = fechaServer
                                End If


                                movimiento.cuenta = CInt(pago.cuenta)
                                conexion.AddTotblBanco_Creditos(movimiento)
                                conexion.SaveChanges()

                                'Verificamos si existe el concepto
                                Dim concepto As tblBanco_MovimientoConcepto = (From x In conexion.tblBanco_MovimientoConcepto Where x.nombre.Equals(pago.tblTipoPago.nombre) Select x).FirstOrDefault
                                Dim idConcepto As Integer = 0

                                If concepto IsNot Nothing Then
                                    idConcepto = concepto.codigo
                                Else
                                    Dim nuevoConcepto As New tblBanco_MovimientoConcepto
                                    nuevoConcepto.nombre = pago.tblTipoPago.nombre
                                    nuevoConcepto.bitCredito = True
                                    nuevoConcepto.bitCheque = False
                                    nuevoConcepto.bitDebito = False

                                    'agregar el movimiento de banco.
                                    conexion.AddTotblBanco_MovimientoConcepto(nuevoConcepto)

                                    'guardar los cambios.
                                    conexion.SaveChanges()

                                    idConcepto = nuevoConcepto.codigo
                                End If

                                'Creamos el detalle de la acreditacion
                                Dim detalle As New tblBanco_CreditosDetalle
                                detalle.credito = movimiento.codigo
                                detalle.acreditador = idAcreditador
                                detalle.concepto = idConcepto
                                detalle.descripcion = pago.tblCliente.Negocio & " - " & pago.tblTipoPago.nombre & " - "
                                detalle.monto = movimiento.total
                                detalle.nombre = nombreAcreditador
                                '
                                conexion.AddTotblBanco_CreditosDetalle(detalle)
                                conexion.SaveChanges()

                                'Aumentamos el saldo de la cuenta a la que se confirmo el cierre
                                Dim cuenta As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = movimiento.cuenta
                                                                 Select x).FirstOrDefault

                                If cuenta.saldo Is Nothing Then
                                    cuenta.saldo = pago.monto
                                Else
                                    cuenta.saldo += pago.monto
                                End If

                                If cuenta.saldoTransito Is Nothing Then
                                    cuenta.saldoTransito = 0
                                End If

                                'guardar los cambios.
                                conexion.SaveChanges()
                            End If

                            'Si es un proveedor
                        ElseIf pago.proveedor > 0 Then

                            Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                            If proveedor.procedencia = 1 Then

                                Dim montoPagar = pago.monto
                                proveedor.pagosTransito -= pago.monto
                                proveedor.pagos += pago.monto
                                proveedor.saldoActual -= pago.monto

                                'guardar los cambios.
                                conexion.SaveChanges()


                                Dim numeroCorrelativo As Integer = 0

                                ' ''CORRELATIVO
                                Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                                    Select x).FirstOrDefault

                                correlativo.correlativo += 1
                                numeroCorrelativo = correlativo.correlativo
                                conexion.SaveChanges()

                                ' ''Obtenemos el acreditador 
                                Dim acreditador As tblBanco_Beneficiario = (From x In conexion.tblBanco_Beneficiario Where x.bitCredito And x.nombre.Equals(pago.tblProveedor.negocio)
                                Select x).FirstOrDefault

                                Dim idAcreditador As Integer = 0
                                Dim nombreAcreditador As String = ""

                                If acreditador IsNot Nothing Then
                                    idAcreditador = acreditador.codigo
                                    nombreAcreditador = acreditador.nombre
                                Else
                                    'Creamos el acreditador
                                    Dim nuevoAcreditador As New tblBanco_Beneficiario
                                    nuevoAcreditador.bitCredito = True
                                    nuevoAcreditador.bitDebitoCheque = False
                                    nuevoAcreditador.nombre = pago.tblProveedor.negocio

                                    conexion.AddTotblBanco_Beneficiario(nuevoAcreditador)
                                    conexion.SaveChanges()

                                    idAcreditador = nuevoAcreditador.codigo
                                    nombreAcreditador = nuevoAcreditador.nombre
                                End If

                                ' ''Creamos el encabezado de la acreditacion
                                Dim movimiento As New tblBanco_Creditos
                                movimiento.bitAnulado = False
                                movimiento.correlativo = numeroCorrelativo
                                movimiento.documento = pago.documento
                                movimiento.fechaRegistro = pago.fecha
                                movimiento.total = pago.monto
                                movimiento.usuarioRegistra = mdlPublicVars.idUsuario

                                If superSearchFechaString IsNot Nothing Then
                                    movimiento.fechaConfirmado = superSearchFechaString
                                Else
                                    movimiento.fechaConfirmado = fechaServer
                                End If

                                movimiento.cuenta = CInt(pago.cuenta)
                                conexion.AddTotblBanco_Creditos(movimiento)
                                conexion.SaveChanges()

                                ' ''Verificamos si existe el concepto
                                Dim concepto As tblBanco_MovimientoConcepto = (From x In conexion.tblBanco_MovimientoConcepto Where x.nombre.Equals(pago.tblTipoPago.nombre) Select x).FirstOrDefault
                                Dim idConcepto As Integer = 0

                                If concepto IsNot Nothing Then
                                    idConcepto = concepto.codigo
                                Else
                                    Dim nuevoConcepto As New tblBanco_MovimientoConcepto
                                    nuevoConcepto.nombre = pago.tblTipoPago.nombre
                                    nuevoConcepto.bitCredito = True
                                    nuevoConcepto.bitCheque = False
                                    nuevoConcepto.bitDebito = False

                                    'agregar el movimiento de banco
                                    conexion.AddTotblBanco_MovimientoConcepto(nuevoConcepto)

                                    ''    'guarda los cambios
                                    conexion.SaveChanges()

                                    idConcepto = nuevoConcepto.codigo
                                End If

                                ' ''creamos el detalle de la acreditacion
                                Dim detalle As New tblBanco_CreditosDetalle
                                detalle.credito = movimiento.codigo
                                detalle.acreditador = idAcreditador
                                detalle.concepto = idConcepto
                                detalle.descripcion = pago.tblProveedor.negocio & "-" & pago.tblTipoPago.nombre & "-"
                                detalle.monto = movimiento.total
                                detalle.nombre = nombreAcreditador
                                '
                                conexion.AddTotblBanco_CreditosDetalle(detalle)
                                conexion.SaveChanges()

                                'Aumentamos el saldo de la cuenta a la que se confirmo el cierre 
                                Dim cuenta As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = movimiento.cuenta
                                                Select x).FirstOrDefault

                                If cuenta.saldo Is Nothing Then
                                    cuenta.saldo = pago.monto
                                Else
                                    cuenta.saldo -= pago.monto
                                End If

                                ' ''guardar los cambios
                                conexion.SaveChanges()

                                Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 Select x Order By x.fecha Ascending).ToList
                                Dim ctaPagar As tblCtaPagar

                                For Each ctaPagar In listaCtaPagar

                                    If montoPagar > ctaPagar.saldo Then
                                        montoPagar -= ctaPagar.saldo
                                        ctaPagar.saldo = 0
                                        ctaPagar.cancelada = 1
                                    Else
                                        ctaPagar.saldo -= montoPagar
                                        ctaPagar.pagado += montoPagar
                                        montoPagar = 0
                                    End If
                                Next

                                'guardar los cambios.
                                conexion.SaveChanges()

                                ' si es proveedor extranjero
                            ElseIf proveedor.procedencia = 2 Then

                                Dim montoPagar = pago.monto
                                proveedor.pagosTransito -= pago.monto
                                proveedor.pagos += pago.monto
                                proveedor.saldoActual -= pago.monto

                                proveedor.saldoDolar -= pago.monto
                                proveedor.pagosTransitoDolar -= pago.monto

                                'guardar los cambios.
                                ''conexion.SaveChanges()

                                ''proveedor.saldoDolar -= pago.monto / pago.tipoCambio
                                ''proveedor.pagosTransitoDolar -= pago.monto / pago.tipoCambio



                                ''proveedor.pagosTransito -= totalQuetzales
                                ''proveedor.pagos += totalQuetzales
                                ''proveedor.saldoActual -= totalQuetzales

                                'If proveedor.pagosDolar Is Nothing Then
                                '    proveedor.pagosDolar = pago.monto
                                'Else
                                '    proveedor.pagosDolar += pago.monto
                                '    proveedor.saldoDolar -= pago.monto
                                'End If

                                'proveedor.pagos += totalQuetzales
                                'proveedor.pagosTransito -= totalQuetzales
                                'proveedor.saldoActual -= totalQuetzales


                                'guardar los cambios
                                conexion.SaveChanges()


                                Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars Where x.idProveedor = pago.proveedor And x.cancelada = 0 Select x Order By x.fecha Ascending).ToList
                                Dim ctaPagar As tblCtaPagar

                                For Each ctaPagar In listaCtaPagar

                                    If montoPagar > ctaPagar.saldo Then
                                        montoPagar -= ctaPagar.saldo
                                        ctaPagar.saldo = 0
                                        ctaPagar.cancelada = 1
                                    Else
                                        ctaPagar.saldo -= montoPagar
                                        ctaPagar.pagado += montoPagar
                                        montoPagar = 0
                                    End If
                                Next

                                Dim filas As Integer = fnGrid_codigoFilaSeleccionada(Me.grdDatos)

                                Dim id As Integer = Me.grdDatos.Rows(filas).Cells("Codigo").Value

                                Dim cj As tblCaja = (From x In conexion.tblCajas Where x.codigo = id Select x).FirstOrDefault

                                Dim ent As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = cj.identradapago Select x).FirstOrDefault

                                ent.saldo -= cj.monto
                                ent.pagos += cj.monto

                                conexion.SaveChanges()

                            End If

                            End If

                    End If

                    'guardar los cambios
                    conexion.SaveChanges()

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
                conexion.AcceptAllChanges()
                alertas.fnGuardar()


            Else
                If anulado = True Then
                    alertas.contenido = "El pago ha sido anulado"
                    alertas.fnErrorContenido()
                Else
                    Console.WriteLine("La operacion no pudo ser completada")
                End If

            End If

            'cerrar la conexion.
            conn.Close()

            'finalizar el proceso.
        End Using


        'llenar grid view si success es verdadero.
        If success = True Then

        End If


    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        If filtroActivo Then
            frmPagosFiltro.fnFiltrar()
        Else
            llenagrid()
        End If
    End Sub

    'NUEVO
    Private Sub frm_nuevo() Handles Me.nuevoRegistro

        If bitCliente = True Or bitVenta = True Then
            ''frmPagoNuevo.bitCliente = True
            ''frmPagoNuevo.Text = "Pagos de Clientes"
            ''frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
            ''permiso.PermisoDialogEspeciales(frmPagoNuevo)
            ''frmPagoNuevo.Dispose()
            frmPagoClientes.Text = "Pago de Clientes"
            frmPagoClientes.bitCliente = True
            frmPagoClientes.StartPosition = FormStartPosition.CenterScreen
            frmPagoClientes.WindowState = FormWindowState.Normal
            permiso.PermisoDialogEspeciales(frmPagoClientes)
            frmPagoClientes.Dispose()

        ElseIf bitProveedor = True Or bitCompra = True Then
            ''frmPagoNuevo.bitProveedor = True
            ''frmPagoNuevo.Text = "Pagos de Proveedores"
            frmPagoProveedores.Text = "Pagos de Proveedores"
            frmPagoProveedores.bitProveedor = True
            frmPagoProveedores.StartPosition = FormStartPosition.CenterScreen
            frmPagoProveedores.WindowState = FormWindowState.Normal
            permiso.PermisoDialogEspeciales(frmPagoProveedores)
            frmPagoProveedores.Dispose()
        End If


    End Sub

    'ANULAR
    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        If RadMessageBox.Show("Desea anular pago", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
            fnAnularPagoUnico()
        End If
    End Sub

    'VER
    Private Sub frm_ver() Handles Me.verRegistro
        Try
            'Obtenemos el codigo del pago
            frmVerPago.Text = "Pago No.: " & mdlPublicVars.superSearchId
            frmVerPago.codigo = mdlPublicVars.superSearchId
            frmVerPago.StartPosition = FormStartPosition.CenterScreen
            frmVerPago.ShowDialog()
            frmVerPago.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    'MODIFICAR
    Private Sub frm_modificar() Handles Me.modificaRegistro
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        Dim codigoPago As Integer = grdDatos.Rows(fila).Cells("Codigo").Value ' captura el codigo de pago


        Dim pago

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            pago = (From x In conexion.tblCajas Where x.codigo = codigoPago Select x).FirstOrDefault

            conn.Close()
        End Using

        If pago.anulado = True Then
            alertas.contenido = "El Pago Ha Sido Anulado"
            alertas.fnError()
            Exit Sub

        End If

        If pago.confirmado = False Then

            If bitCliente = True Then
                frmPagoNuevo.bitCliente = True

            End If

            If bitProveedor = True Then
                frmPagoNuevo.bitProveedor = True

            End If

            frmPagoNuevo.codigoCP = pago.cliente
            frmPagoNuevo.bitModificar = True
            frmPagoNuevo.codigoPagoModificar = codigoPago
            frmPagoNuevo.bitCliente = True
            frmPagoNuevo.Text = "Modificar Pago"
            frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmPagoNuevo)
            frmPagoNuevo.Dispose()

        Else
            ''MessageBox.Show("El pago a sido confirmado, No se puede modificar")
            frmDocumentosPagos.Text = "Documentos Pago"
            frmDocumentosPagos.StartPosition = FormStartPosition.CenterScreen
            frmDocumentosPagos.WindowState = FormWindowState.Normal
            frmDocumentosPagos.codigo = codigoPago
            frmDocumentosPagos.ShowDialog()
            frmDocumentosPagos.Dispose()
        End If
    End Sub

    Private Sub fnAnularPagoUnico()
        Dim success As Boolean = True
        Dim filaseleccionada As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
        Dim codigo As Integer = CType(Me.grdDatos.Rows(filaseleccionada).Cells("Codigo").Value, Integer)
        Dim anulado As Boolean = CType(Me.grdDatos.Rows(filaseleccionada).Cells("chkAnulado").Value, Boolean)
        Dim confirmado As Boolean = CType(Me.grdDatos.Rows(filaseleccionada).Cells("chmConfirmar").Value, Boolean)

        Dim fechaAnulado As DateTime = fnFecha_horaServidor()



        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope

                'inicio de excepcion
                Try

                    Dim pagos As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigo Select x).FirstOrDefault
                    If pagos.anulado = True Then 'si el pago ya a sido anulado salimos ya no se puede anular
                        success = False
                        Exit Try
                    ElseIf pagos.confirmado = True Then ' si el pago ya a sido confirmado salimos ya no se puede anular
                        success = False
                        Exit Try
                    Else

                        'Anulamos un pago unico
                        'Confirmamos el pago
                        Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigo Select x).FirstOrDefault

                        pago.anulado = 1
                        pago.fechaAnulado = fechaAnulado
                        conexion.SaveChanges()

                        'Si es una salida
                        If pago.codigoEntrada > 0 Then

                            Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = pago.codigoEntrada Select x).FirstOrDefault

                            If factura.contado = True Then
                                'Realizamos las transacciones correspondientes
                                factura.saldo += pago.monto

                                If factura.saldo = 0 Then
                                    factura.pagado = 0
                                End If
                            Else
                                Dim montoPagar = pago.monto

                                Dim listaSalidas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.IdFactura = factura.IdFactura Select x).ToList
                                Dim salida As tblSalida
                                Dim montoSalida As Double = 0

                                For Each salida In listaSalidas
                                    Dim ctaCobrar As tblCtaCobrar = (From x In conexion.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault

                                    montoSalida += ctaCobrar.pagado
                                    ctaCobrar.pagado = 0
                                    ctaCobrar.saldo = ctaCobrar.monto
                                    ctaCobrar.cancelada = 0
                                Next

                                Dim nuevoMonto = montoSalida - montoPagar


                                For Each salida In listaSalidas
                                    Dim ctaCobrar As tblCtaCobrar = (From x In conexion.tblCtaCobrars Where x.idSalida = salida.idSalida Select x).FirstOrDefault
                                    If nuevoMonto > ctaCobrar.saldo Then
                                        nuevoMonto -= ctaCobrar.saldo
                                        ctaCobrar.saldo = 0
                                        ctaCobrar.cancelada = 1
                                    Else
                                        ctaCobrar.saldo -= nuevoMonto
                                        nuevoMonto = 0
                                    End If
                                Next

                            End If
                            conexion.SaveChanges()
                            'Si en un cliente

                        ElseIf pago.cliente > 0 Then

                            Dim listasCtaCobrar As List(Of tblCtaCobrar) = (From x In conexion.tblCtaCobrars Where x.idCliente = pago.cliente Select x Order By x.fecha Ascending).ToList
                            Dim ctaCobrar As tblCtaCobrar

                            Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = pago.cliente Select x).FirstOrDefault

                            Dim montoPagar = pago.monto
                            Dim montoSalida As Double = 0

                            If pago.confirmado = True Then
                                cliente.pagos -= pago.monto
                                cliente.saldo += pago.monto
                                For Each ctaCobrar In listasCtaCobrar
                                    montoSalida += ctaCobrar.pagado
                                    ctaCobrar.pagado = 0
                                    ctaCobrar.saldo = ctaCobrar.monto
                                    ctaCobrar.cancelada = 0
                                Next

                                Dim nuevoMonto = montoSalida - montoPagar

                                For Each ctaCobrar In listasCtaCobrar
                                    If nuevoMonto > ctaCobrar.saldo Then
                                        nuevoMonto -= ctaCobrar.saldo
                                        ctaCobrar.pagado += ctaCobrar.saldo
                                        ctaCobrar.saldo = 0
                                        ctaCobrar.cancelada = 1
                                    Else
                                        ctaCobrar.saldo -= nuevoMonto
                                        ctaCobrar.pagado += nuevoMonto
                                        nuevoMonto = 0
                                    End If
                                Next
                                'El pago no ha sido confirmado
                            Else
                                cliente.pagosTransito -= pago.monto
                            End If


                            conexion.SaveChanges()
                            'Si es una entrada
                        ElseIf pago.codigoSalida > 0 Then

                            Dim entrada As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = pago.codigoSalida Select x).FirstOrDefault
                            If entrada.contado = True Then
                                'Realizamos las transacciones correspondientes
                                entrada.saldo += pago.monto
                                If entrada.saldo = 0 Then
                                    entrada.cancelado = 1
                                Else
                                    entrada.cancelado = 0
                                End If
                            Else
                                Dim montoPagar = pago.monto

                                Dim ctaPagar As tblCtaPagar = (From x In conexion.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault

                                ctaPagar.saldo += montoPagar
                                ctaPagar.pagado -= montoPagar
                                ctaPagar.cancelada = 0

                            End If

                            'Si es un proveedor
                        ElseIf pago.proveedor > 0 Then


                            Dim proveedor As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = pago.proveedor Select x).FirstOrDefault

                            Dim montoPagar = pago.monto
                            Dim montoSalida As Double = 0

                            If pago.confirmado = True Then
                                proveedor.saldoActual += pago.monto
                                proveedor.pagos -= pago.monto
                                Dim listaCtaPagar As List(Of tblCtaPagar) = (From x In conexion.tblCtaPagars Where x.idProveedor = pago.proveedor Select x Order By x.fecha Ascending).ToList
                                Dim ctaPagar As tblCtaPagar

                                For Each ctaPagar In listaCtaPagar
                                    montoSalida += ctaPagar.pagado
                                    ctaPagar.pagado = 0
                                    ctaPagar.saldo = ctaPagar.monto
                                    ctaPagar.cancelada = 0
                                Next

                                Dim nuevoMonto = montoSalida - montoPagar

                                For Each ctaPagar In listaCtaPagar
                                    If nuevoMonto > ctaPagar.saldo Then
                                        nuevoMonto -= ctaPagar.saldo
                                        ctaPagar.pagado += ctaPagar.saldo
                                        ctaPagar.saldo = 0
                                        ctaPagar.cancelada = 1
                                    Else
                                        ctaPagar.saldo -= nuevoMonto
                                        ctaPagar.pagado += nuevoMonto
                                        nuevoMonto = 0
                                    End If
                                Next
                            Else
                                'proveedor.saldoTransito -= pago.monto
                                proveedor.pagosTransito -= pago.monto
                            End If
                            conexion.SaveChanges()

                        End If

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
                conexion.AcceptAllChanges()
                alertas.contenido = "Pago anulado exitosamente"
                alertas.fnErrorContenido()
                llenagrid()
            Else
                If anulado = True Then
                    alertas.contenido = "Pago ya ha sido anulado!!!"
                    alertas.fnErrorContenido()

                ElseIf confirmado = True Then
                    alertas.contenido = "Pago ya ha sido Confirmado"
                    alertas.fnErrorContenido()

                Else
                    alertas.fnErrorGuardar()
                    Console.WriteLine("La operacion no pudo ser completada")
                End If

            End If

            conn.Close()
        End Using



    End Sub

    Private Sub frmPagosLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Codigo").Value, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Pagos de: " & If(bitCliente, "Clientes", If(bitProveedor, "Proveedores", ""))
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmPagosFiltro.Text = "Filtro: PAGOS"
        frmPagosFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmPagosFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
        llenagrid()
    End Sub

    'CAMBIO DE FILTRO FECHA
    Public Overloads Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
        If cargo Then

            ' Dim fechaBusqueda As String

            ' fechaAnterior =  Format( fechaActual.AddDays(-cmbFiltroFecha.SelectedValue)

            Me.txtFiltro.Visible = False
            Me.Label2.Visible = False

            frm_llenarLista()
        End If
    End Sub

    Private Sub bntBuscar_Click(sender As Object, e As EventArgs) Handles bntBuscar.Click
        llenagrid()
    End Sub
End Class