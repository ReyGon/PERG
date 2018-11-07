''Option Strict On

Imports System.Data
Imports System.Data.EntityClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.Linq
Imports System.Transactions

Public Class frmHistorialPagos
    Private permiso As New clsPermisoUsuario
    Private _idproveedor As Integer
    Private _idInvoice As Integer

    Public Property idproveedor As Integer
        Get
            idproveedor = _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property

    Public Property idInvoice As Integer
        Get
            idInvoice = _idInvoice
        End Get
        Set(value As Integer)
            _idInvoice = value
        End Set
    End Property

#Region "Eventos"

    Private Property listaEntradas As Object

    'LOAD
    Private Sub frmFacturasElegir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdPagos)
        mdlPublicVars.fnFormatoGridEspeciales(grdPagos)

        Me.rbListado.Checked = True
        fnLlenarDatos()
        fnLlenarGrid()
        mdlPublicVars.fnGrid_iconos(grdPagos)
    End Sub

    Private Sub fnLlenarDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim inv As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = idInvoice Select x).FirstOrDefault

                Me.txtTotalInvoice.Text = Format(inv.total, formatoMonedaDolar)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    'SALIR DEL FORMULARIO
    Private Sub fnLlenarGrid()
        Try
            Dim dt As New DataTable
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim elegir As Boolean = False

                If idproveedor > 0 Then

                    Dim idpreforma As Integer = CInt((From x In conexion.tblEntradas Where x.idEntrada = idInvoice Select x.IdPreformaInvoice).FirstOrDefault)

                    dt = EntitiToDataTable(conexion.sp_PagosProveedoresImportacion(idproveedor, idInvoice, idpreforma))

                    Me.grdPagos.DataSource = dt

                    conn.Close()

                End If

                fnConfiguracion()

            End Using
        Catch

        End Try

    End Sub

    Public Sub fnConfiguracion()
        Try
            Me.grdPagos.Columns("IdPago").IsVisible = False
            Me.grdPagos.Columns("Tipo Pago").Width = 120
            Me.grdPagos.Columns("Proveedor").Width = 75
            Me.grdPagos.Columns("Fecha Pago").Width = 60
            Me.grdPagos.Columns("Pago Q").Width = 50
            Me.grdPagos.Columns("Tasa Cambio").Width = 60
            Me.grdPagos.Columns("Pago D").Width = 50
            Me.grdPagos.Columns("Documento Asociado").Width = 70
            Me.grdPagos.Columns("txmConsumir").ReadOnly = False
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub grdPagos_Click(sender As Object, e As EventArgs) Handles grdPagos.Click
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)
            If Me.rbListado.Checked = True Then
                Me.txtTasaCambio.Text = CStr(Me.grdPagos.Rows(fila).Cells("TasaCambio").Value)
            Else
                Me.txtTasaCambio.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function fnValidarConsumo() As Boolean
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)

            Dim disponible As Decimal = Me.grdPagos.Rows(fila).Cells("Disponible").Value
            Dim consumir As Decimal = Me.grdPagos.Rows(fila).Cells("txmConsumir").Value

            If consumir > disponible Then
                frmNotificacion.Dispose()
                frmNotificacion.lblNotificacion.Text = "El monto a consumir es mayor" + vbLf + "al monto disponible"
                frmNotificacion.Show()
                Me.Focus()
                Return False
                Exit Function
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub grdPagos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPagos.KeyDown
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)
            Dim col As Integer = Me.grdPagos.CurrentColumn.Index
            Dim nombre As String = Me.grdPagos.Columns(col).Name

            If nombre = "txmConsumir" Then

                If e.KeyCode = Keys.Delete Then
                    Me.grdPagos.Rows(fila).Cells(nombre).Value = 0
                End If

                If e.KeyCode = Keys.Back Then
                    If Me.grdPagos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                        Me.grdPagos.Rows(fila).Cells(nombre).Value = Me.grdPagos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdPagos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                    End If
                End If

                If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                    If Me.grdPagos.Rows(fila).Cells(nombre).Value = "0" Then
                        Me.grdPagos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                    Else
                        Me.grdPagos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                    End If

                ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                    If Me.grdPagos.Rows(fila).Cells(nombre).Value = "0" Then
                        Me.grdPagos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                    Else
                        Me.grdPagos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                    End If

                ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                    If Me.grdPagos.Rows(fila).Cells(nombre).Value = "0.00" Then
                        Me.grdPagos.Rows(fila).Cells(nombre).Value += "."
                    Else
                        Me.grdPagos.Rows(fila).Cells(nombre).Value += "."
                    End If

                ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                    Me.grdPagos.Columns(nombre).ReadOnly = True
                    Me.grdPagos.Rows(fila).Cells(nombre).EndEdit()
                End If


                If fnValidarConsumo() = False Then
                    Me.grdPagos.Rows(fila).Cells(nombre).Value = 0
                End If

                fnValidadorPagos()
                fnTasaCambio()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnTasaCambio()
        Try
            Dim contador As Integer = 0
            Dim pagos As Decimal = 0
            Dim totalconv As Decimal = 0

            For i As Integer = 0 To Me.grdPagos.Rows.Count - 1
                If Me.grdPagos.Rows(i).Cells("txmConsumir").Value > 0 Then
                    totalconv += Me.grdPagos.Rows(i).Cells("txmConsumir").Value * Me.grdPagos.Rows(i).Cells("Tasa Cambio").Value
                    pagos += Me.grdPagos.Rows(i).Cells("txmConsumir").Value
                End If
            Next

            Me.txtTasaCambio.Text = Format(totalconv / pagos, formatoMoneda5dec)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnValidadorPagos()
        Try
            Me.txtPagosInvoice.Text = Format("0", formatoMonedaDolar)
            Dim pagos As Decimal = 0

            For i As Integer = 0 To Me.grdPagos.Rows.Count - 1
                If Me.grdPagos.Rows(i).Cells("txmConsumir").Value > 0 Then
                    pagos += Me.grdPagos.Rows(i).Cells("txmConsumir").Value
                End If
            Next

            Me.txtPagosInvoice.Text = Format(pagos, formatoMonedaDolar)

            Dim total As Decimal = Replace(Me.txtTotalInvoice.Text, "$", "")

            If pagos < total Then
                Me.txtPagosInvoice.ForeColor = Color.Black
                Me.btnAceptar.Enabled = False
            ElseIf pagos > total Then
                Me.txtPagosInvoice.ForeColor = Color.Red
                Me.btnAceptar.Enabled = False
            ElseIf pagos = total Then
                Me.txtPagosInvoice.ForeColor = Color.Blue
                Me.btnAceptar.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdFacturas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdPagos.MouseDoubleClick
        Try

            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)
            Dim salida As Integer = CInt(Me.grdPagos.Rows(index).Cells("id").Value)
            frmPedidoConcepto.Text = "Ventas"
            frmPedidoConcepto.idSalida = salida
            frmPedidoConcepto.WindowState = FormWindowState.Normal
            frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmPedidoConcepto)
            frmPedidoConcepto.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbListado_CheckedChanged(sender As Object, e As EventArgs) Handles rbListado.CheckedChanged
        Try
            If rbListado.Checked = True Then
                rbManual.Checked = False
                Me.txtTasaCambio.Enabled = False
                Me.btnAceptar.Enabled = False
            Else
                rbManual.Checked = True
                Me.txtTasaCambio.Enabled = True
                Me.txtTasaCambio.Focus()
                Me.btnAceptar.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Me.txtTasaCambio.Text <> "" Or CDec(Me.txtTasaCambio.Text) > 0 Then
                fnConsumirPagoNacionalizacion()
                frmNacionalizacion.tasaCambio = CDec(Replace(Me.txtTasaCambio.Text, "Q", ""))
                Me.Close()
            Else
                frmNotificacion.lblNotificacion.Text = "La tasa de cambio" + vbLf + "no es valida"
                frmNotificacion.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConsumirPagoNacionalizacion()
        Try
            Dim idpago As Integer
            Dim consumo As Decimal

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                For filas As Integer = 0 To Me.grdPagos.Rows.Count - 1

                    consumo = Me.grdPagos.Rows(filas).Cells("txmConsumir").Value

                    If consumo > 0 Then
                        idpago = Me.grdPagos.Rows(filas).Cells("IdPago").Value

                        Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = idpago Select x).FirstOrDefault

                        pago.afavor -= consumo
                        pago.consumido += consumo
                        conexion.SaveChanges()

                    End If

                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class