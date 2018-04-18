Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.Objects
Imports System.Management
Imports System.Data.Common
Imports System.Data.EntityClient

Public Class frmProveedorEstadoCuenta
    Dim fechaInicial As DateTime
    Dim fechaFinal As DateTime
    Dim cambia As Boolean = False
    Dim _proveedor As Integer
    Dim extranjero As Boolean = False
    Private permiso As New clsPermisoUsuario


    Public Property proveedor() As Integer
        Get
            proveedor = _proveedor
        End Get
        Set(ByVal value As Integer)
            _proveedor = value
        End Set
    End Property

    Private Sub frmProveedorEstadoCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fechaServidor As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdEstado1)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdEstado2Ventas)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdEstado2Depositos)

        mdlPublicVars.comboActivarFiltro(Me.cmbProveedor)
        'colocar la fecha.
        dtpFechaInicio.Text = fechaServidor.AddMonths(-1)
        dtpFechaFin.Text = fechaServidor

        fnLlenaCombo()
        Try
            fnProveedorProcedencia()
            fnRealizaEstadoCuenta()
        Catch ex As Exception
        End Try
        fnSumarios()

    End Sub

    Private Sub fnProveedorProcedencia()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim idproveedor As Integer = Me.cmbProveedor.SelectedValue

                Dim prove As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = idproveedor Select x).FirstOrDefault

                If prove.procedencia = 2 Then
                    extranjero = True
                ElseIf prove.procedencia = 1 Then
                    extranjero = False
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    ''Funcion utilizada para agregar los sumarios al grid
    Private Sub fnSumarios()
        Try
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryCompras As New GridViewSummaryItem("Compras", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            Dim summaryPagos As New GridViewSummaryItem("Pagos", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryCompras, summaryPagos})

            grdEstado1.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnRealizaEstadoCuenta()
        fnLlenarEstado1()
        fnLlenarEstado2()
        fnconfiguracion()
    End Sub

    'Funcion que se utiliza para llenar el combo de cliente
    Private Sub fnLlenaCombo()
        Try
            Dim consulta = (From x In ctx.tblProveedors Select Codigo = x.idProveedor, Nombre = x.negocio)

            With Me.cmbProveedor
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = consulta
            End With

            If proveedor > 0 Then
                cmbProveedor.SelectedValue = proveedor
                lblClave.Text = proveedor
            End If
            cambia = True
        Catch ex As Exception

        End Try
    End Sub

    'Llena el grid del estado de cuenta 1
    Private Sub fnLlenarEstado1()
        ''Try
        ''    grdEstado1.DataSource = Nothing

        ''    Dim consulta = From y In (From x In ctx.tblEntradas _
        ''                 Where (x.anulado = False And x.idProveedor = proveedor And x.compra = True And x.fechaCompra >= fechaInicial And x.fechaCompra <= fechaFinal) _
        ''                 Group By Codigo = CType(x.idEntrada, Integer), TipoMov = CType(x.idTipoMovimiento, Nullable(Of Int16)), Fecha = x.fechaCompra, Documento = x.documento, Compras = x.total _
        ''                 Into Group _
        ''                 Order By Fecha Ascending _
        ''                 Select Codigo, TipoMov, Fecha = CType(Fecha, Date), Tipo = "Compra", Documento, Compras, Pagos = CType(0, Decimal), Saldo = CType(0, Decimal) _
        ''                 ).Union( _
        ''                 From z In ctx.tblCajas _
        ''                 Where z.proveedor = proveedor And z.anulado = False And z.confirmado = True And z.fecha >= fechaInicial And z.fecha <= fechaFinal _
        ''                 Select Codigo = CType(z.codigo, Integer), TipoMov = CType(0, Nullable(Of Int16)), Fecha = CType(z.fecha, Date), Tipo = z.tblTipoPago.nombre, _
        ''                 Documento = z.documento, Compras = CType(0, Decimal), Pagos = z.monto, Saldo = CType(0, Decimal) Order By Fecha Ascending _
        ''                 ).Union( _
        ''                 From x In ctx.tblDevolucionProveedors _
        ''                 Where x.proveedor = proveedor And x.anulado = False And x.acreditado = True And x.fechaAcreditado >= fechaInicial And x.fechaAcreditado <= fechaFinal _
        ''                 Select Codigo = CType(x.codigo, Integer), TipoMov = x.tipoMovimiento, Fecha = x.fechaAcreditado, Tipo = x.tblTipoMovimiento.nombre,
        ''                 Documento = x.documento, Compras = CType(0, Decimal), Pagos = x.monto, Saldo = CType(0, Decimal) Order By Fecha Ascending)
        ''                 Select y.Codigo, y.TipoMov, y.Fecha, y.Tipo, y.Documento, y.Compras, y.Pagos, y.Saldo Order By Fecha Ascending



        ''        'Select y.Codigo, y.Fecha, y.Tipo, y.Documento, y.Compras, y.Pagos, Saldo Order By Fecha Ascending
        ''    Me.grdEstado1.DataSource = mdlPublicVars.EntitiToDataTable(consulta)

        ''    fnEstableceInicial_Estado1()
        ''    fnEstableceFinal_Estado1()
        ''Catch ex As Exception

        ''End Try

        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                grdEstado1.Rows.Clear()
                Dim fechaInicial As DateTime = dtpFechaInicio.Text + " 00:00:00"
                Dim fechafinal As DateTime = dtpFechaFin.Text + " 23:59:59"

                'Obtenemos el saldo Inicial
                Dim saldoInicial = From x In conexion.sp_saldoInicialProveedor(proveedor, fechaInicial)
                For Each s As sp_saldoInicialProveedor_Result In saldoInicial

                    'Dim saldoInicial As List(Of sp_saldoInicial1_Result) = conexion.sp_saldoInicial1(cliente, fechaInicial).ToList
                    'For Each s As sp_saldoInicial1_Result In saldoInicial
                    If extranjero = True Then
                        lblInicial1.Text = Format(s.SaldoInicial, mdlPublicVars.formatoMonedaDolar)
                    Else
                        lblInicial1.Text = Format(s.SaldoInicial, mdlPublicVars.formatoMoneda)
                    End If

                    'lblTransitoInicial.Text = Format(s.SaldoInicial, mdlPublicVars.formatoMoneda)
                Next



                ' ''Obtenemos el saldo pendiente
                ''Dim saldoPendiente = From x In conexion.sp_SaldoPendiente(cliente)
                ''For Each sp As sp_SaldoPendiente_Result In saldoPendiente
                ''    ''lblSaldoVencid.Text = Format(sp.SaldoVencido, mdlPublicVars.formatoMoneda)
                ''    ''lblSaldoVencido2.Text = lblSaldoVencido.Text
                ''Next

                Dim pagos As Double
                Try
                    'Pagos en Transito
                    pagos = (From c In conexion.tblCajas Where c.proveedor = proveedor And c.transito = True And c.confirmado = False _
                                          And c.anulado = False Select c.monto).Sum
                Catch ex As Exception
                    'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    pagos = 0
                End Try

                'lblPagoTransito1.Text = Format(pagos, mdlPublicVars.formatoMoneda)
                ''lblPagoTransitoEstado1.Text = Format(pagos, mdlPublicVars.formatoMoneda)
                ''lblPagoTransitoEstado2.Text = Format(pagos, mdlPublicVars.formatoMoneda)

                'Llenar el grid de estado 1
                conexion.CommandTimeout = 10000
                ''Dim lFilas As List(Of sp_estadoCuentaProveedor_Result) = conexion.sp_estadoCuentaProveedor("", proveedor, fechaInicial, fechafinal, mdlPublicVars.idEmpresa).ToList

                ''For Each fila As sp_estadoCuentaProveedor_Result In lFilas
                ''    Dim registro As Object()
                ''    registro = {fila.Codigo, Format(fila.Fecha, mdlPublicVars.formatoFecha), If(fila.Clasificacion IsNot Nothing, fila.Clasificacion, ""),
                ''                fila.Tipo, fila.Documento, Format(fila.Compras, mdlPublicVars.formatoMoneda), Format(fila.Deposito, mdlPublicVars.formatoMoneda),
                ''                Format(fila.Saldo, mdlPublicVars.formatoMoneda), fila.EstadoCuenta}
                ''    Me.grdEstado1.Rows.Add(registro)
                ''Next

                Me.grdEstado1.DataSource = conexion.sp_estadoCuentaProveedor("", proveedor, fechaInicial, fechafinal, mdlPublicVars.idEmpresa).ToList
                fnconfiguracion()
            Catch ex As Exception
                'RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
            conn.Close()
        End Using

        fnEstableceFinal_Estado1()

    End Sub

    'Establece el saldo inicial en el estado de cuenta 1
    Private Sub fnEstableceInicial_Estado1()
        Try
            'Realizamos la consulta para saber las ventas y pagos anteriores
            Dim totalVentas As Decimal = 0
            Try
                totalVentas = (From x In ctx.tblEntradas _
                           Where (x.anulado = False And x.idProveedor = proveedor And x.compra = True And x.fechaCompra < fechaInicial) _
                           Group By Compras = x.total _
                           Into Group _
                           Select Compras).Sum
            Catch ex As Exception
                totalVentas = 0
            End Try

            Dim totalPagos As Decimal
            Try
                totalPagos = (From z In ctx.tblCajas Where z.proveedor = proveedor And z.proveedor > 0 And z.anulado = False And z.fecha < fechaInicial _
                                   Select z.monto).Sum
            Catch ex As Exception
                totalPagos = 0
            End Try

            Dim totalDevoluciones As Decimal
            Try
                totalDevoluciones = (From x In ctx.tblDevolucionProveedors Where x.proveedor = proveedor _
                                     And x.acreditado = True And x.fechaRegistro < fechaInicial _
                                     And x.anulado = False Select x.monto).Sum
            Catch ex As Exception
                totalDevoluciones = 0
            End Try

            Dim saldoInicial = totalVentas - totalPagos - totalDevoluciones


            lblInicial1.Text = Format(saldoInicial, mdlPublicVars.formatoMoneda)


        Catch ex As Exception
        End Try
    End Sub

    'Establece el saldo final en el estado de cuenta 1
    Private Sub fnEstableceFinal_Estado1()
        Try
            Dim index
            Dim totalVentas As Decimal = 0
            Dim totalDepositos As Decimal = 0
            Dim saldoInicial As Decimal = CType(Replace(lblInicial1.Text, "$", ""), Decimal)
            Dim saldo As Decimal = 0
            For index = 0 To Me.grdEstado1.Rows.Count - 1
                totalVentas += CType(Me.grdEstado1.Rows(index).Cells("Compras").Value, Decimal)
                totalDepositos += CType(Me.grdEstado1.Rows(index).Cells("Deposito").Value, Decimal)
                saldo = saldoInicial + totalVentas - totalDepositos
                ''If extranjero Then
                ''    Me.grdEstado1.Rows(index).Cells("Saldo").Value = Format(CType(saldo, Decimal), mdlPublicVars.formatoMonedaDolar)
                ''Else
                ''    Me.grdEstado1.Rows(index).Cells("Saldo").Value = Format(saldo, mdlPublicVars.formatoMoneda)
                ''End If
                Me.grdEstado1.Rows(index).Cells("Saldo").Value = saldo

            Next

            Try
                If extranjero Then
                    lblFinal1.Text = Format(CType(Me.grdEstado1.Rows(index - 1).Cells("Saldo").Value, Decimal), mdlPublicVars.formatoMonedaDolar)
                Else
                    lblFinal1.Text = Format(CType(Me.grdEstado1.Rows(index - 1).Cells("Saldo").Value, Decimal), mdlPublicVars.formatoMoneda)
                End If

            Catch ex As Exception
                If extranjero Then
                    lblFinal1.Text = Format(CType(0, Decimal), mdlPublicVars.formatoMonedaDolar)
                Else
                    lblFinal1.Text = Format(CType(0, Decimal), mdlPublicVars.formatoMoneda)
                End If

            End Try

        Catch ex As Exception

        End Try
    End Sub

    'Llena el grid del estado de cuenta 2
    Private Sub fnLlenarEstado2()
        Try
            grdEstado2Ventas.DataSource = Nothing
            grdEstado2Depositos.DataSource = Nothing
            'Llenar el grid de estado 1
            Dim consulta
            If extranjero Then
                consulta = (From x In ctx.tblEntradas _
                         Where (x.anulado = False And x.idProveedor = proveedor And x.transito = True And x.fechaRegistro >= fechaInicial And x.fechaRegistro <= fechaFinal) _
                         Group By Codigo = x.idEntrada, Fecha = x.fechaCompra, Documento = x.documento, Compras = x.total _
                         Into Group _
                         Order By Fecha Ascending _
                         Select Codigo, TipoMov = "Compras", Fecha, Tipo = "Compras", Documento, Compras)
            Else
                consulta = (From x In ctx.tblEntradas _
                         Where (x.anulado = False And x.idProveedor = proveedor And x.compra = True And x.fechaCompra >= fechaInicial And x.fechaCompra <= fechaFinal) _
                         Group By Codigo = x.idEntrada, Fecha = x.fechaCompra, Documento = x.documento, Compras = x.total _
                         Into Group _
                         Order By Fecha Ascending _
                         Select Codigo, TipoMov = "Compras", Fecha, Tipo = "Compras", Documento, Compras)
            End If
          

            'Dim consulta1 = From z In ctx.tblCajas Where z.proveedor = proveedor And z.anulado = False _
            '                            And z.fecha >= fechaInicial And z.fecha <= fechaFinal And z.confirmado = True _
            '                            Select Codigo = CType(z.codigo, Integer), TipoMov = CType(0, Nullable(Of Int16)), Fecha = z.fecha, _
            '                            Tipo = z.tblTipoPago.nombre, Documento = z.documento, Deposito = z.monto Order By Fecha Ascending

            'Dim consulta3 = From x In ctx.tblDevolucionProveedors Where x.proveedor = proveedor And x.anulado = False _
            '               And x.acreditado = True And x.fechaAcreditado >= fechaInicial And x.fechaAcreditado <= fechaFinal _
            '               Select Codigo = CType(x.codigo, Integer), _
            '               TipoMov = CType(x.tipoMovimiento, Nullable(Of Int16)), Fecha = CType(x.fechaAcreditado, Nullable(Of DateTime)), _
            '               Tipo = x.tblTipoMovimiento.nombre, Documento = x.documento, _
            '               Deposito = x.monto Order By Fecha Ascending
            Dim consulta2 = Nothing

            Try
                consulta2 = From y In (From z In ctx.tblCajas Where z.proveedor = proveedor And z.anulado = False _
                            And z.fecha >= fechaInicial And z.fecha <= fechaFinal And z.confirmado = True _
                            Select Codigo = CType(z.codigo, Integer), TipoMov = CType(0, Nullable(Of Int16)), Fecha = CType(z.fecha, Nullable(Of DateTime)), _
                            Tipo = CType(z.tblTipoPago.nombre, String), Documento = CType(z.documento, String), Deposito = CType(z.monto, Decimal) Order By Fecha Ascending).Union( _
                            From x In ctx.tblDevolucionProveedors Where x.proveedor = proveedor And x.anulado = False _
                           And x.acreditado = True And x.fechaAcreditado >= fechaInicial And x.fechaAcreditado <= fechaFinal _
                           Select Codigo = CType(x.codigo, Integer), TipoMov = CType(x.tipoMovimiento, Nullable(Of Int16)), _
                           Fecha = CType(x.fechaAcreditado, Nullable(Of DateTime)), _
                           Tipo = CType(x.tblTipoMovimiento.nombre, String), Documento = CType(x.documento, String), Deposito = CType(x.monto, Decimal) Order By Fecha Ascending) _
                           Select y.Codigo, y.TipoMov, y.Fecha, y.Tipo, y.Documento, y.Deposito Order By Fecha Ascending
             
            Catch ex As Exception

            End Try
            
            


            Me.grdEstado2Ventas.DataSource = mdlPublicVars.EntitiToDataTable(consulta)
            Me.grdEstado2Depositos.DataSource = mdlPublicVars.EntitiToDataTable(consulta2)


            fnEstableceSaldoPeriodo()
            fnEstableceResultados()

        Catch ex As Exception

        End Try
    End Sub

    'Configura los grid's
    Private Sub fnconfiguracion()
        Try
            If Me.grdEstado1.Rows.Count > 0 Then
                Me.grdEstado1.Columns(0).IsVisible = False 'ocultar el codigo.
                Me.grdEstado1.Columns(2).IsVisible = False 'ocultar el tipo de movimiento.
                Me.grdEstado1.Columns(8).IsVisible = False

                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdEstado1, "Fecha")
                If extranjero Then
                    mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdEstado1, "Compras")
                    mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdEstado1, "Deposito")
                    mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdEstado1, "Saldo")
                Else
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdEstado1, "Compras")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdEstado1, "Deposito")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdEstado1, "Saldo")
                End If
                

                Me.grdEstado1.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdEstado1.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdEstado1.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
            End If

            If Me.grdEstado2Ventas.Rows.Count > 0 Then
                Me.grdEstado2Ventas.Columns(0).IsVisible = False 'ocultar el codigo.

                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdEstado2Ventas, "Fecha")
                If extranjero Then
                    mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdEstado2Ventas, "Compras")
                Else
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdEstado2Ventas, "Compras")
                End If

                Me.grdEstado2Ventas.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdEstado2Ventas.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdEstado2Ventas.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            End If

            If Me.grdEstado2Depositos.Rows.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdEstado2Depositos, "Fecha")
                If extranjero Then
                    mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdEstado2Depositos, "Deposito")
                Else
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdEstado2Depositos, "Deposito")
                End If


                Me.grdEstado2Depositos.Columns(0).IsVisible = False 'ocultar el codigo.
                Me.grdEstado2Depositos.Columns(1).IsVisible = False 'ocultar el tipo de movimiento.

                Me.grdEstado2Depositos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdEstado2Depositos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdEstado2Depositos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Establece los resultados del periodo en estaco de cuenta 2
    Private Sub fnEstableceSaldoPeriodo()
        Try
            'Declaramos las variables de resultados
            Dim ventas As Decimal = 0
            Dim depositos As Decimal = 0
            Dim saldo As Decimal = 0

            Dim index
            For index = 0 To Me.grdEstado2Ventas.Rows.Count - 1
                Dim monto As Decimal = CType(Me.grdEstado2Ventas.Rows(index).Cells("Compras").Value, Decimal)
                ventas += monto
            Next

            For index = 0 To Me.grdEstado2Depositos.Rows.Count - 1
                Dim monto As Decimal = CType(Me.grdEstado2Depositos.Rows(index).Cells("Deposito").Value, Decimal)
                depositos += monto
            Next

            saldo = ventas - depositos
            If extranjero Then
                lblVentas.Text = Format(ventas, mdlPublicVars.formatoMonedaDolar)
                lblDepositos.Text = Format(depositos, mdlPublicVars.formatoMonedaDolar)
                lblSaldo.Text = Format(saldo, mdlPublicVars.formatoMonedaDolar)
            Else
                lblVentas.Text = Format(ventas, mdlPublicVars.formatoMoneda)
                lblDepositos.Text = Format(depositos, mdlPublicVars.formatoMoneda)
                lblSaldo.Text = Format(saldo, mdlPublicVars.formatoMoneda)
            End If
            
        Catch ex As Exception

        End Try
    End Sub

    'Establece los resultados finales en el estado de cuenta 2
    Private Sub fnEstableceResultados()
        Try
            lblSaldoAnterior.Text = lblInicial1.Text
            lblSaldoPeriodo.Text = lblSaldo.Text
            If extranjero Then
                lblSaldoFinal.Text = Format(CDec(Replace(lblSaldoAnterior.Text, "$", "")) + CDec(Replace(lblSaldoPeriodo.Text, "$", "")), mdlPublicVars.formatoMonedaDolar)
            Else
                lblSaldoFinal.Text = Format(CDec(Replace(lblSaldoAnterior.Text, "$", "")) + CDec(Replace(lblSaldoPeriodo.Text, "$", "")), mdlPublicVars.formatoMoneda)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        
    End Sub

    Private Sub dtpFechaFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaFin.ValueChanged
        
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedor.SelectedIndexChanged
        Try
            If cambia = True Then
                proveedor = CType(cmbProveedor.SelectedValue, Integer)
                lblClave.Text = proveedor
                fnRealizaEstadoCuenta()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub grdEstado1_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdEstado1.CellDoubleClick
        Try
            Dim tipo As String = e.Row.Cells("TipoMov").Value
            Dim codigo As Integer = e.Row.Cells("Codigo").Value

            If tipo = mdlPublicVars.Entrada_CodigoMovimiento Then
                frmEntrada.codigo = codigo
                frmEntrada.bitEditarEntrada = True
                frmEntrada.verRegistro = True
                frmEntrada.Text = "Compras"
                frmEntrada.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmEntrada)
                frmEntrada.Dispose()
            ElseIf tipo = mdlPublicVars.Proveedor_DevolucionCodigoMovimiento Or tipo = mdlPublicVars.Proveedor_AjusteCodigoMovimiento Then
                frmProveedorDevolucion.Text = "Ajustes y Devoluciones"
                frmProveedorDevolucion.bitEditarDevolucion = True
                frmProveedorDevolucion.codigoDev = codigo
                frmProveedorDevolucion.StartPosition = FormStartPosition.CenterScreen
                frmProveedorDevolucion.verRegistro = True
                permiso.PermisoDialogEspeciales(frmProveedorDevolucion)
                frmProveedorDevolucion.Dispose()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdEstado2Ventas_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdEstado2Ventas.CellDoubleClick
        Try
            Dim codigo As Integer = e.Row.Cells("Codigo").Value
            frmEntrada.codigo = codigo
            frmEntrada.bitEditarEntrada = True
            frmEntrada.verRegistro = True
            frmEntrada.StartPosition = FormStartPosition.CenterScreen
            frmEntrada.Text = "Compras"
            permiso.PermisoDialogEspeciales(frmEntrada)
            frmEntrada.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdEstado2Depositos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdEstado2Depositos.CellDoubleClick
        Try
            Dim tipo As String = e.Row.Cells("TipoMov").Value
            Dim codigo As Integer = e.Row.Cells("Codigo").Value
            If tipo = mdlPublicVars.Proveedor_DevolucionCodigoMovimiento Or tipo = mdlPublicVars.Proveedor_AjusteCodigoMovimiento Then
                frmProveedorDevolucion.Text = "Ajustes y Devoluciones"
                frmProveedorDevolucion.bitEditarDevolucion = True
                frmProveedorDevolucion.StartPosition = FormStartPosition.CenterScreen
                frmProveedorDevolucion.codigoDev = codigo
                frmProveedorDevolucion.verRegistro = True
                permiso.PermisoDialogEspeciales(frmProveedorDevolucion)
                frmProveedorDevolucion.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInfoCliente_Click(sender As Object, e As EventArgs) Handles btnInfoCliente.Click
        fechaInicial = dtpFechaInicio.Text + " 00:00:00.000"
        fechaFinal = dtpFechaFin.Text + " 23:59:59.999"
        fnRealizaEstadoCuenta()
    End Sub

    Private Sub btnajustarsaldo_Click(sender As Object, e As EventArgs) Handles btnajustarsaldo.Click
        Dim idproveedor As Integer
        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                If cmbProveedor.SelectedValue = Nothing Then
                    RadMessageBox.Show("Necesita escojer un Proveedor", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                Else
                    idproveedor = cmbProveedor.SelectedValue
                    Dim cons = Nothing
                    cons = conexion.sp_herramientas_proveedorSaldosIndividual(idproveedor)
                    RadMessageBox.Show("Saldo Ajustado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                    conn.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al ajustar saldo " + ex.ToString())
        End Try

    End Sub

    'REPORTE
    Public Function fnReporte() Handles Me.panel1
        Dim r As New clsReporte
        Try
            If rpvEstados.SelectedPage.Name = "pgEstado1" Then
                r.reporte = "rptEstadoCuentaProveedor1.rpt"
                r.tabla = EntitiToDataTable((From x In ctx.sp_ReporteEstadoProveedor1("", proveedor, dtpFechaInicio.Text, dtpFechaFin.Text & " 23:59:59", mdlPublicVars.idEmpresa))
            ElseIf rpvEstados.SelectedPage.Name = "pgEstado2" Then
                r.reporte = "rptEstadoCuentaProveedor2.rpt"
                r.tabla = EntitiToDataTable((From x In ctx.sp_reporteEstadoCuentaProveedor2("", proveedor, dtpFechaInicio.Text, dtpFechaFin.Text & " 23:59:59", mdlPublicVars.idEmpresa))
            End If
            r.nombreParametro = "filtro"
            r.parametro = "Filtro del reporte:"

            frmDocumentosSalida.txtTitulo.Text = "Estado de Cuenta de " & dtpFechaInicio.Text & " Hasta " & dtpFechaFin.Text
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.codigo = proveedor
            frmDocumentosSalida.reporteBase = r.DocumentoReporte()
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

        Catch ex As Exception

        End Try

        Return 0
    End Function

End Class
