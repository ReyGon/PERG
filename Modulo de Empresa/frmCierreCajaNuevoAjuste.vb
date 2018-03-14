Imports System.Linq
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmCierreCajaNuevoAjuste

#Region "Variables"

#End Region

#Region "LOAD"
    Private Sub frmCierreCajaNuevoAjuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        mdlPublicVars.fnFormatoGridMovimientos(grdCheques)
        fnDatosUsuario()
        fnLlenarGrid()
        fnllenarGridCheques()
        'fnLlenarCombo()
        fnActualizaTotal()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para obtener los datos del usuario
    Private Sub fnDatosUsuario()

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim usuario As tblUsuario = (From x In conexion.tblUsuarios.AsEnumerable
                                        Where x.idUsuario = mdlPublicVars.idUsuario
                                        Select x).FirstOrDefault
                lblUsuario.Text = usuario.nombre
            Catch ex As Exception
            End Try
            conn.Close()
        End Using
    End Sub

    'Funcion utilizada para agregar la columna de combo
    Private Sub fnLlenarCombo()
        If grdDatos.ColumnCount > 2 Then
            Exit Sub
        End If

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                'Le asignamos el data source al grid
                Dim cuenta = (From x In conexion.tblCajaConceptoes
                              Select codigo = x.codigo, valor = x.nombre + " U: " + CStr(x.unidad))

                Dim cajaConcepto As New GridViewComboBoxColumn()
                cajaConcepto.FieldName = "caja"
                cajaConcepto.Name = "Concepto"
                cajaConcepto.HeaderText = "Concepto"
                cajaConcepto.Width = 150
                With cajaConcepto
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "valor"
                    .DataSource = cuenta
                End With

                Me.grdDatos.Columns.Add(cajaConcepto)
                Me.grdDatos.Columns.Move(Me.grdDatos.ColumnCount - 1, Me.grdDatos.Columns("txmCantidad").Index)
            Catch

            End Try

            conn.Close()
        End Using

    End Sub

    'Funcion utilizada para llenar el grid
    Private Sub fnLlenarGrid()
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim consulta = (From x In conexion.tblCajaConceptoes
                           Select x.codigo, x.unidad, Descripcion = x.tblCajaCategoria.nombre + " : " + x.nombre,
                           txmCantidad = CType(0, Integer), Total = CType(0, String))
                Me.grdDatos.DataSource = EntitiToDataTable(consulta)

                'Llenamos el grid de cheques
                'Dim cheques = (From x In conexion.tblCajas Where Not x.confirmado And Not x.anulado And x.fecha <= fechaServidor _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And x.tblCierreCajaDetalleCajas.Count <= 0
                '               Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False)

                'Dim cheques = (From x In conexion.tblCajas Where x.confirmado = True And Not x.anulado And (x.fechaCobro >= desde And x.fechaCobro <= hasta) _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And x.tblCierreCajaDetalleCajas.Count <= 0
                '               Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False)

                'grdCheques.DataSource = EntitiToDataTable(cheques)

            Catch ex As Exception

            End Try
            conn.Close()
        End Using
        mdlPublicVars.fnGrid_iconos(grdDatos)

        fnConfiguracion()
    End Sub

    Private Sub fnllenarGridCheques()

        Dim desde As DateTime = CType(dtpDesde.Text, DateTime)
        Dim hasta As DateTime = CType(dtpHasta.Text + " 23:59:59", DateTime)

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
              
                'Llenamos el grid de cheques
                'Dim cheques = (From x In conexion.tblCajas Where Not x.confirmado And Not x.anulado And x.fecha <= fechaServidor _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And x.tblCierreCajaDetalleCajas.Count <= 0
                '               Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False)

                'Dim cheques = (From x In conexion.tblCajas Where x.confirmado = True And Not x.anulado And (x.fechaCobro >= desde And x.fechaCobro <= hasta) _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And x.tblCierreCajaDetalleCajas.Count <= 0
                '                Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False)


                'Dim cheques = (From x In conexion.tblCajas Join y In conexion.tblCierreCajaDetalleCajas On x.codigo Equals y.idCaja Where x.confirmado = True And Not x.anulado And (x.fechaCobro >= desde And x.fechaCobro <= hasta) _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And If((x.tblCierreCajaDetalleCajas.Count > 0 And y.tblCierreCaja.bitAnulado), x.tblCierreCajaDetalleCajas.Count >= 0, x.tblCierreCajaDetalleCajas.Count <= 0)
                '                Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False).Union(
                '               From x In conexion.tblCajas Join y In conexion.tblCierreCajaDetalleCajas On x.codigo Equals y.idCaja Where x.confirmado = True And Not x.anulado And (x.fechaCobro >= desde And x.fechaCobro <= hasta) _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And x.tblCierreCajaDetalleCajas.Count <= 0
                '                Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False
                '               )




                'Dim cheques = (From x In conexion.tblCajas Join y In conexion.tblCierreCajaDetalleCajas On x.codigo Equals y.idCaja Where x.confirmado = True And Not x.anulado And (x.fechaCobro >= desde And x.fechaCobro <= hasta) _
                '               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And If((x.tblCierreCajaDetalleCajas.Count > 0 And y.tblCierreCaja.bitAnulado), x.tblCierreCajaDetalleCajas.Count >= 0, x.tblCierreCajaDetalleCajas.Count <= 0)
                '                Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                '               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False)




                Dim cheques = (From x In conexion.tblCajas Where x.confirmado = True And Not x.anulado And (x.fechaCobro >= desde And x.fechaCobro <= hasta) _
                               And x.cliente IsNot Nothing And x.tblTipoPago.cheque And x.codutilizado = 0
                                Select x.codigo, Fecha = x.fecha, Cliente = x.tblCliente.Negocio, Documento = x.documento, Descripcion = x.descripcion, _
                               FechaCobro = x.fechaCobro, Monto = x.monto, chmAgregar = False)

                grdCheques.DataSource = EntitiToDataTable(cheques)

            Catch ex As Exception

            End Try
            conn.Close()
        End Using

        mdlPublicVars.fnGrid_iconos(grdCheques)
        fnConfiguracion()
    End Sub

    'Funcion utilizada para configurar grid
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).ReadOnly = True
            Next

            Me.grdDatos.Columns("codigo").IsVisible = False
            Me.grdDatos.Columns("unidad").IsVisible = False

            Me.grdDatos.Columns("Descripcion").Width = 60
            Me.grdDatos.Columns("txmCantidad").Width = 16
            Me.grdDatos.Columns("Total").Width = 24

            Me.grdDatos.Columns("txmCantidad").ReadOnly = False
        End If

        If Me.grdCheques.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdCheques.ColumnCount - 1
                Me.grdCheques.Columns(i).ReadOnly = True
            Next

            Me.grdCheques.Columns("codigo").IsVisible = False
            'x.codigo, Fecha, Cliente, Documento, Descripcion,Monto = x.monto, chmAgregar
            mdlPublicVars.fnGridTelerik_formatoFecha(grdCheques, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdCheques, "Monto")

            Me.grdCheques.Columns("Fecha").Width = 40
            Me.grdCheques.Columns("Cliente").Width = 90
            Me.grdCheques.Columns("Documento").Width = 60
            Me.grdCheques.Columns("Descripcion").Width = 70
            Me.grdCheques.Columns("Monto").Width = 50
            Me.grdCheques.Columns("chmAgregar").Width = 45

            Me.grdCheques.Columns("chmAgregar").ReadOnly = False
        End If
    End Sub

    'Funcion utilizada para actualizar el total
    Private Sub fnActualizaTotal()
        'Recorremos el grid
        Dim unidad As Decimal = 0
        Dim cantidad As Integer = 0
        Dim total As Decimal = 0
        For i As Integer = 0 To Me.grdDatos.RowCount - 1
            unidad = Me.grdDatos.Rows(i).Cells("unidad").Value
            cantidad = Me.grdDatos.Rows(i).Cells("txmCantidad").Value

            'Establecemos el total
            Me.grdDatos.Rows(i).Cells("Total").Value = Format(unidad * cantidad, mdlPublicVars.formatoMoneda)
            total += cantidad * unidad
        Next

        'Establecemos el total
        lblTotalEfectivo.Text = Format(total, mdlPublicVars.formatoMoneda)

        'Recorremos el grid de cheques
        Dim agrega As Boolean = False
        Dim monto As Decimal = 0
        Dim totalCheques As Decimal = 0
        For i As Integer = 0 To Me.grdCheques.RowCount - 1
            agrega = Me.grdCheques.Rows(i).Cells("chmAgregar").Value
            monto = CDec(Replace(Me.grdCheques.Rows(i).Cells("Monto").Value, "Q", "").Trim)
            If agrega Then
                total += monto
                totalCheques += monto
            End If
        Next

        'Establecemos el total
        lblTotalCheques.Text = Format(totalCheques, mdlPublicVars.formatoMoneda)

        'Establecemos el total
        lblTotalFinal.Text = Format(total, mdlPublicVars.formatoMoneda)
    End Sub

    'Funcion utilizada para validar el cierre de caja
    Private Sub fnValidar()
        Dim desde As DateTime = CType(dtpDesde.Text, DateTime)
        Dim hasta As DateTime = CType(dtpHasta.Text + " 23:59:59", DateTime)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        'Dim idUsuario As Integer = CInt(cmbUsuario.SelectedValue)


        Dim totalSistema As Decimal
        Dim entradas
        Dim salidas
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                
                ''seleccionar registros de caja que esten en una fecha determinada, confirmados,

                If mdlPublicVars.PuntoVentaPequeno_Activado = True And mdlPublicVars.bitTransportePesado = True Then

                    entradas = (From z In (From x In conexion.tblCajas.AsEnumerable
                                    Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True And x.anulado = False And x.codutilizado = 0) _
                                            And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                                            And (x.tblTipoPago.cierreCaja = True Or x.tblTipoPago.caja = True) _
                                            And (x.cliente > 0 Or x.tblTipoPago.caja = True Or x.tblTipoPago.cierreCaja = True)
                                            )
                                            Select z.monto).Sum()

                    salidas = (From z In (From x In conexion.tblCajas.AsEnumerable
                                           Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True And x.anulado = False And x.codutilizado = 0) _
                                           And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                                           And (x.tblTipoPago.cierreCaja = True Or x.tblTipoPago.caja) _
                                           And (x.proveedor > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.salida = True)
                                           )
                                           Select z.monto).Sum()

                Else

                    entradas = (From z In (From x In conexion.tblCajas.AsEnumerable
                                   Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True) _
                                           And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                                           And (x.tblTipoPago.cierreCaja = True Or x.tipoPago = mdlPublicVars.Pagos_codigoEfectivo) _
                                           And (x.cliente > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.entrada)
                                           ) Select z.monto).Sum



                    salidas = (From z In (From x In conexion.tblCajas.AsEnumerable
                                            Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True) _
                                            And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                                            And (x.tblTipoPago.cierreCaja = True Or x.tipoPago = mdlPublicVars.Pagos_codigoEfectivo) _
                                            And (x.proveedor > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.salida)
                                            ) Select z.monto).Sum()

                End If

                totalSistema = entradas - salidas
                'totalSistema = (From y In (From x In ctx.tblCajas.AsEnumerable
                '        Where (x.fecha >= desde And x.fecha <= hasta And x.confirmado = True _
                '        And (From y In ctx.tblCierreCajaDetalleCajas Where y.idCierreCaja = y.idCierreCaja Select y).Count <= 0 _
                '        And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                '        And (x.tipoPago = mdlPublicVars.Pagos_codigoEfectivo Or x.tblTipoPago.caja)) _
                '        Select Entrada = If(x.cliente > 0, x.monto, If(x.tblTipoPago.caja And x.tblTipoPago.entrada, x.monto, 0)),
                '        Salida = If(x.proveedor > 0, x.monto, If(x.tblTipoPago.caja And x.tblTipoPago.salida, x.monto, 0)))
                '        Select y.Entrada - y.Salida).Sum

            Catch ex As Exception
                totalSistema = 0
            End Try

            'cerrar la conexion
            conn.Close()

            'fin del proceso.
        End Using

        Dim totalUsuario As Decimal = CDec(Replace(lblTotalEfectivo.Text, "Q", "").Trim)
        Dim totalFinal As Decimal = CDec(Replace(lblTotalFinal.Text, "Q", "").Trim)


        If Math.Abs(totalFinal - totalSistema) <= mdlPublicVars.CierreCaja_Tolerancia Then
            RadMessageBox.Show("Válido!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        ElseIf totalSistema <> totalFinal Then
            RadMessageBox.Show("Cierre del Usuario no coinde con Cierre del Sistema" & vbCrLf & "Revisar!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If
    End Sub

    'Funcion utilizada para guardar el movimiento
    Private Function fnGuardarCierre() As Boolean

        Dim codcierrecaja As Integer
        Dim success As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim desde As DateTime = dtpDesde.Text & " 00:00:00"
        Dim hasta As DateTime = dtpHasta.Text & " 23:59:59"
        Dim total As Decimal = CDec(lblTotalFinal.Text)

        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            Using transaction As New TransactionScope
                Try
                    'Calcula el total del sistema
                    Dim totalSistema As Decimal


                    Try
                        Dim entradas = (From z In (From x In conexion.tblCajas.AsEnumerable
                               Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True) _
                                       And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa And x.codutilizado = 0 _
                                       And (x.tblTipoPago.cierreCaja = True Or x.tipoPago = mdlPublicVars.Pagos_codigoEfectivo) _
                                       And (x.cliente > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.entrada)
                                       ) Select z.monto).Sum

                        Dim salidas = (From z In (From x In conexion.tblCajas.AsEnumerable
                                                Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True) _
                                                And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa And x.codutilizado = 0 _
                                                And (x.tblTipoPago.cierreCaja = True Or x.tipoPago = mdlPublicVars.Pagos_codigoEfectivo) _
                                                And (x.proveedor > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.salida)
                                                ) Select z.monto).Sum()

                        totalSistema = entradas - salidas

                    Catch ex As Exception
                        totalSistema = 0
                    End Try

                    'actualizar el correlativo.
                    Dim numeroCorrelativo As String = 0

                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.CierreCaja_CodigoMovimiento _
                                                         And x.idEmpresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                    If correlativo IsNot Nothing Then
                        correlativo.correlativo += 1
                        conexion.SaveChanges()
                        'asignar el numero de correlativo.
                        numeroCorrelativo = correlativo.serie & correlativo.correlativo
                    Else
                        'crear registro de correlativo.
                        Dim correlativoNuevo As New tblCorrelativo
                        correlativoNuevo.correlativo = 1
                        correlativoNuevo.serie = ""
                        correlativoNuevo.inicio = 1
                        correlativoNuevo.fin = 1000
                        correlativoNuevo.porcentajeAviso = 20
                        correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                        correlativoNuevo.idTipoMovimiento = mdlPublicVars.CierreCaja_CodigoMovimiento
                        conexion.AddTotblCorrelativos(correlativoNuevo)
                        conexion.SaveChanges()

                        'asignar el numero de correlativo.
                        numeroCorrelativo = 1
                    End If

                    'Creamos el encabezado del cierre de caja
                    Dim cierre As New tblCierreCaja
                    cierre.fechaRegistro = fechaServer
                    cierre.bitAnulado = False
                    cierre.bitConfirmado = False
                    cierre.correlativo = numeroCorrelativo
                    cierre.documentoBoleta = ""
                    cierre.desde = desde
                    cierre.hasta = hasta
                    cierre.salida = 0
                    cierre.entrada = total
                    cierre.usuario = mdlPublicVars.idUsuario
                    cierre.empresa = mdlPublicVars.idEmpresa
                    cierre.montoAjuste = 0
                    cierre.bitAjuste = False
                    conexion.AddTotblCierreCajas(cierre)
                    conexion.SaveChanges()

                    codcierrecaja = cierre.codigo

                    'Guardamos el detalle de conceptos de caja
                    Dim cantidad As Integer = 0
                    Dim concepto As String = ""
                    Dim totalConcepto As Decimal = 0
                    For i As Integer = 0 To Me.grdDatos.RowCount - 1
                        cantidad = Me.grdDatos.Rows(i).Cells("txmCantidad").Value
                        concepto = Me.grdDatos.Rows(i).Cells("codigo").Value
                        totalConcepto = Me.grdDatos.Rows(i).Cells("total").Value

                        If cantidad > 0 And concepto > 0 Then
                            'Creamos el registro del detalle
                            Dim cierreDetalle As New tblCierreCajaDetalle
                            cierreDetalle.cajaConcepto = concepto
                            cierreDetalle.cantidad = cantidad
                            cierreDetalle.total = totalConcepto
                            cierreDetalle.cierreCaja = cierre.codigo

                            conexion.AddTotblCierreCajaDetalles(cierreDetalle)
                            conexion.SaveChanges()
                        End If
                    Next

                    'Guardamos el detalle de cheques
                    Dim idCaja As Integer = 0
                    Dim agrega As Boolean = False

                    For i As Integer = 0 To Me.grdCheques.RowCount - 1
                        agrega = Me.grdCheques.Rows(i).Cells("chmAgregar").Value
                        idCaja = Me.grdCheques.Rows(i).Cells("codigo").Value
                        If agrega Then
                            'Creamos el detalle del cheque    
                            Dim chequeDetalle As New tblCierreCajaDetalleCaja
                            chequeDetalle.idCierreCaja = cierre.codigo
                            chequeDetalle.idCaja = idCaja
                            chequeDetalle.bitCheque = True
                            chequeDetalle.bitEfectivo = False

                            conexion.AddTotblCierreCajaDetalleCajas(chequeDetalle)
                            conexion.SaveChanges()
                        End If
                    Next

                    Dim lPagos As List(Of tblCaja) = (From z In (From x In conexion.tblCajas.AsEnumerable
                                                                Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado _
                                                                And x.cuenta Is Nothing And x.codutilizado = 0 _
                                                                And x.empresa = mdlPublicVars.idEmpresa And (x.tipoPago = mdlPublicVars.Pagos_codigoEfectivo Or x.tblTipoPago.caja Or x.tblTipoPago.cierreCaja And Not x.tblTipoPago.cheque))
                                                                Select x, detalle = (From y In conexion.tblCierreCajaDetalleCajas Where y.idCaja = x.codigo _
                                                                And y.tblCierreCaja.bitAnulado = False Select y).Count) _
                                                        Select z.x).ToList()

                    'Recorremos el grid y actualizar
                    For Each pago As tblCaja In lPagos
                        'Creo el registro en la table de detalle del cierre de caja
                        Dim efectivoDetalle As New tblCierreCajaDetalleCaja
                        efectivoDetalle.idCierreCaja = cierre.codigo
                        efectivoDetalle.idCaja = pago.codigo
                        efectivoDetalle.bitCheque = False
                        efectivoDetalle.bitEfectivo = True

                        conexion.AddTotblCierreCajaDetalleCajas(efectivoDetalle)
                        conexion.SaveChanges()

                        'Guardamos los cambios
                        conexion.SaveChanges()

                    Next

                    ''Actualizamos para que los pagos y cheques ya utilizados no los tome de nuevo
                    If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                        fnCierreCajaParcial(cierre.codigo, conexion)
                    End If

                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine("An error occured. " & "The operation cannot be retried." + ex.Message)
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If

                End Try
            End Using
            If success = True Then
                conexion.AcceptAllChanges()
                alerta.fnGuardar()
                Return True
            Else
                'No guarda los cambios
                alerta.fnError()
                Return False
            End If
            conn.Close()
        End Using

    End Function

#End Region

#Region "Eventos"
    'Utilizado cuando se termina de editar
    Private Sub grdDatos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellEndEdit
        fnActualizaTotal()
    End Sub

    'Utilizada cuando se agrega otra fila
    Private Sub grdDatos_UserAddedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdDatos.UserAddedRow
        fnActualizaTotal()
    End Sub

    'Utilizado para validar
    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        fnValidar()
    End Sub

    'Guardar
    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea realizar cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

            If fnGuardarCierre() = True Then
                If RadMessageBox.Show("¿Desea realizar un nuevo cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
                    Me.Close()
                    frmCierreCajaLista.frm_llenarLista()
                Else
                    fnLlenarGrid()
                    fnActualizaTotal()
                End If
            End If


        End If
    End Sub

    'Salir 
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'Cambio de valor
    Private Sub grdCheques_ValueChanged(sender As System.Object, e As System.EventArgs) Handles grdCheques.ValueChanged
        Try
            Dim columna As Integer = Me.grdCheques.CurrentColumn.Index
            If Me.grdCheques.RowCount > 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                dtpDesde.Focus()
                dtpHasta.Select()
                fnActualizaTotal()
                Me.grdCheques.Rows(fila).Cells(columna).IsSelected = True
            End If
        Catch ex As Exception

        End Try

        '¿Me.grdCheques.EndEdit()
    End Sub
#End Region

    Private Sub fnCierreCajaParcial(ByVal cierrecaja As Integer, ByVal conexion As dsi_pos_demoEntities)
        Try

            Dim desde As DateTime = CType(dtpDesde.Text, DateTime)
            Dim hasta As DateTime = CType(dtpHasta.Text + " 23:59:59", DateTime)
            Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor

            ''Dim entradas = (From z In (From x In conexion.tblCajas.AsEnumerable
            ''    Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True And x.anulado = False) _
            ''            And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
            ''            And (x.tblTipoPago.cierreCaja = True Or x.tblTipoPago.caja = True) _
            ''            And (x.cliente > 0 Or x.tblTipoPago.caja = True Or x.tblTipoPago.cierreCaja = True)
            ''            Select x.monto, detalle = (From y In conexion.tblCierreCajaDetalleCajas Where y.idCaja = x.codigo Select y).Count)
            ''        Where z.detalle = 0 Select z.monto).Sum()

            Dim entradas As List(Of tblCaja) = (From x In conexion.tblCajas
                                                Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True And x.anulado = False And x.codutilizado = 0) _
                                                And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                                                And (x.tblTipoPago.cierreCaja = True Or x.tblTipoPago.caja = True) _
                                                And (x.cliente > 0 Or x.tblTipoPago.caja = True Or x.tblTipoPago.cierreCaja = True)
                                                Select x).ToList


            For Each ent As tblCaja In entradas

                ent.codutilizado = cierrecaja
                conexion.SaveChanges()

            Next

            ''Dim salidas = (From z In (From x In conexion.tblCajas.AsEnumerable
            ''                       Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True And x.anulado = False) _
            ''                       And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
            ''                       And (x.tblTipoPago.cierreCaja = True Or x.tblTipoPago.caja) _
            ''                       And (x.proveedor > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.salida = True)
            ''                       Select x.monto, detalle = (From y In conexion.tblCierreCajaDetalleCajas Where y.idCierreCaja = y.idCierreCaja Select y).Count)
            ''                       Where z.detalle = 0 Select z.monto).Sum()

            Dim salidas As List(Of tblCaja) = (From x In conexion.tblCajas
                                               Where (x.fechaCobro >= desde And x.fechaCobro <= hasta And x.confirmado = True And x.anulado = False) _
                                               And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa _
                                               And (x.tblTipoPago.cierreCaja = True Or x.tblTipoPago.caja) _
                                               And (x.proveedor > 0 Or x.tblTipoPago.caja Or x.tblTipoPago.salida = True)
                                               Select x).ToList

            For Each sal As tblCaja In salidas

                sal.codutilizado = cierrecaja
                conexion.SaveChanges()

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
        fnllenarGridCheques()
    End Sub

    Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
        fnllenarGridCheques()
    End Sub
End Class
