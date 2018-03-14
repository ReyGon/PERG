Imports System.Linq
Imports Telerik.WinControls.UI
Imports System.Transactions
Imports Telerik.WinControls

Public Class frmCierreCajaNuevoNormal

#Region "LOAD"
    Private Sub frmListadoCierreCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenaCombo()
        fnLlenarGrid()
        fnSumarios()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para llenar el combo de usuarios
    Private Sub fnLlenaCombo()
        Dim usuario = (From x In ctx.tblUsuarios Select codigo = x.idUsuario, x.nombre)

        With cmbUsuario
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = usuario
        End With
    End Sub

    'Funcion utilizada para llenar el grid
    Private Sub fnLlenarGrid()
        If CInt(cmbUsuario.SelectedValue) Then
            'Variables utilizadas de filtro
            Dim desde As DateTime = CType(dtpDesde.Text, DateTime)
            Dim hasta As DateTime = CType(dtpHasta.Text + " 23:59:59", DateTime)
            Dim idUsuario As Integer = CInt(cmbUsuario.SelectedValue)
            'Obtenemos la lista de entradas y salidas
            Dim listado = (From x In ctx.tblCajas
                           Where x.fechaCobro >= desde And x.fechaCobro <= hasta And x.usuario = idUsuario And x.confirmado _
                           And x.tblCierreCajaDetalleCajas.Count <= 0 And x.cuenta Is Nothing And x.empresa = mdlPublicVars.idEmpresa
                           Select Codigo = x.codigo, Fecha = x.fechaCobro, Documento = x.documento,
                           Nombre = If(x.cliente > 0, x.tblCliente.Negocio,
                                      If(x.proveedor > 0, x.tblProveedor.negocio,
                                         If(x.cliente Is Nothing And x.proveedor Is Nothing, x.observacion, ""))),
                           Descripcion = x.tblTipoPago.nombre,
                           Entrada = If(x.cliente > 0, x.monto, If(x.tblTipoPago.caja And x.tblTipoPago.entrada, x.monto, 0)),
                           Salida = If(x.proveedor > 0, x.monto, If(x.tblTipoPago.caja And x.tblTipoPago.salida, x.monto, 0)))

            Me.grdDatos.DataSource = listado
            fnConfiguracion()
            fnActualizaTotal()
        End If
    End Sub

    'Funcion utilizada para agregar las fila summary
    Private Sub fnSumarios()
        Try
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Fecha", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryEntradas As New GridViewSummaryItem("Entrada", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            Dim summarySalida As New GridViewSummaryItem("Salida", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryEntradas, summarySalida})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para configurar el grid
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            Me.grdDatos.Columns("Codigo").IsVisible = False

            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).ReadOnly = True
            Next

            'Select Codigo, Fecha, Documento,
            '           Nombre ,Descripcion,Entrada,Salida 

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Entrada")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Salida")

            Me.grdDatos.Columns("Fecha").Width = 70
            Me.grdDatos.Columns("Documento").Width = 80
            Me.grdDatos.Columns("Nombre").Width = 120
            Me.grdDatos.Columns("Descripcion").Width = 125
            Me.grdDatos.Columns("Entrada").Width = 80
            Me.grdDatos.Columns("Salida").Width = 80
        End If
    End Sub

    'Funcion utilizada para obtener el saldo final
    Private Sub fnActualizaTotal()
        'Recorremos el grid
        Dim entrada As Decimal
        Dim salida As Decimal
        For i As Integer = 0 To Me.grdDatos.RowCount - 1
            entrada += CDec(Me.grdDatos.Rows(i).Cells("Entrada").Value)
            salida += CDec(Me.grdDatos.Rows(i).Cells("Salida").Value)
        Next

        lblEntradas.Text = Format(entrada, mdlPublicVars.formatoMoneda)
        lblSalidas.Text = Format(salida, mdlPublicVars.formatoMoneda)

        lblSaldo.Text = Format(entrada - salida, mdlPublicVars.formatoMoneda)

    End Sub

    'Funcion utilizada para poder guardar un cierre de caja
    Private Sub fnGuardarCierre()
        Dim success As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim desde As DateTime = dtpDesde.Text
        Dim hasta As DateTime = dtpHasta.Text & " 23:59:59"
        Using transaction As New TransactionScope
            Try
                'actualizar el correlativo.
                Dim numeroCorrelativo As String = 0

                Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.CierreCaja_CodigoMovimiento _
                                                     And x.idEmpresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                If correlativo IsNot Nothing Then
                    correlativo.correlativo += 1
                    ctx.SaveChanges()
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
                    ctx.AddTotblCorrelativos(correlativoNuevo)
                    ctx.SaveChanges()

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
                cierre.salida = CDec(lblSalidas.Text)
                cierre.entrada = CDec(lblEntradas.Text)
                cierre.usuario = mdlPublicVars.idUsuario
                cierre.empresa = mdlPublicVars.idEmpresa
                ctx.AddTotblCierreCajas(cierre)
                ctx.SaveChanges()

                'Modificamos los pagos asociados al cierre de caja, recorremos el grid
                Dim codMovimiento As Integer = 0
                For i As Integer = 0 To Me.grdDatos.RowCount - 1
                    'Obtenemos el codigo del movimiento
                    codMovimiento = Me.grdDatos.Rows(i).Cells("Codigo").Value

                    'Obtenemos el registro del movimiento
                    Dim movimiento As tblCaja = (From x In ctx.tblCajas Where x.codigo = codMovimiento _
                                                 Select x).FirstOrDefault

                    'movimiento.cierrecaja = cierre.codigo

                    'Guardamos los cambios
                    ctx.SaveChanges()
                Next

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
            ctx.AcceptAllChanges()
        Else
            'No guarda los cambios
        End If
    End Sub
#End Region

#Region "Eventos"
    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    'GUARDAR
    Private Sub fnGuardar()
        If RadMessageBox.Show("¿Desea realizar cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardarCierre()
            If RadMessageBox.Show("¿Desea realizar un nuevo cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnLlenarGrid()
            Else
                Me.Close()
                frmCierreCajaLista.frm_llenarLista()
            End If
        End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        fnLlenarGrid()
    End Sub

    'Doble clic en el grid de pagos
    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

        frmVerPago.Text = "Pago No.: " & codigo
        frmVerPago.codigo = codigo
        frmVerPago.StartPosition = FormStartPosition.CenterScreen
        frmVerPago.ShowDialog()
        frmVerPago.Dispose()
    End Sub
#End Region

End Class
