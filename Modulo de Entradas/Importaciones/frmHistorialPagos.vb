''Option Strict On

''Imports System.Data
''Imports System.Data.EntityClient
''Imports Telerik.WinControls
''Imports Telerik.WinControls.UI
''Imports Telerik.WinControls.Data
''Imports System.Linq
''Imports System.Transactions

''Public Class frmHistorialPagos
''    Private permiso As New clsPermisoUsuario
''    Private _idproveedor As Integer

''    Public Property idproveedor As Integer
''        Get
''            idproveedor = _idproveedor
''        End Get
''        Set(ByVal value As Integer)
''            _idproveedor = value
''        End Set
''    End Property

''#Region "Eventos"
''    'LOAD
''    Private Sub frmFacturasElegir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
''        mdlPublicVars.fnFormatoGridMovimientos(grdPagos)
''        mdlPublicVars.fnFormatoGridEspeciales(grdPagos)

''        fnLlenarGrid()
''        mdlPublicVars.fnGrid_iconos(grdPagos)
''    End Sub

''    'CLIC EN ACEPTAR PARA AGREGAR EMPLEADOS

''    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

''        If idproveedor > 0 Then

''            Dim entradas As List(Of GridViewRowInfo) = (From x In grdPagos.Rows Where CBool(x.Cells("chmElegir").Value) Select x).ToList

''            For Each entrada As GridViewRowInfo In entradas

''                listaEntradas.Add(New Tuple(Of Integer, String, Decimal)(CInt(entrada.Cells("Id").Value), CStr2(entrada.Cells("Factura").Value), CDec(entrada.Cells("txmMontoPagar").Value)))

''            Next
''            mdlPublicVars.superSearchLista3 = listaEntradas
''        ElseIf idcliente > 0 Then
''            listaSalidas = New List(Of Tuple(Of Integer, String, Decimal))

''            Dim salidas As List(Of GridViewRowInfo) = (From x In grdPagos.Rows Where CBool(x.Cells("chmElegir").Value) Select x).ToList

''            For Each salida As GridViewRowInfo In salidas

''                listaSalidas.Add(New Tuple(Of Integer, String, Decimal)(CInt(salida.Cells("id").Value), CStr(salida.Cells("Facturas").Value), CDec(salida.Cells("txmMontoPagar").Value)))

''            Next

''            mdlPublicVars.superSearchLista3 = listaSalidas
''        End If

''        Me.Close()
''    End Sub

''    'SALIR DEL FORMULARIO
''    Private Sub fnLlenarGrid()
''        Try
''            Dim dt As New DataTable
''            Dim conexion As dsi_pos_demoEntities
''            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
''                conn.Open()
''                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
''                Dim elegir As Boolean = False

''                If idproveedor > 0 Then


''                    dt = EntitiToDataTable(conexion.sp_ConsultafacturasCompras(idproveedor))



''                    Me.grdPagos.DataSource = dt

''                    ' Dim entradas As List(Of tblEntrada) = (From x In conexion.tblEntradas.AsEnumerable Where x.idProveedor = idproveedor Where x.saldo > 0 Select x Order By x.fechaRegistro Descending).ToList()

''                    'For Each entrada As tblEntrada In entradas
''                    'elegir = If((From x In listaEntradas Where x.Item1 = entrada.idEntrada Select x).Count() > 0, True, False)
''                    'Me.grdFacturas.Rows.Add({elegir, entrada.idEntrada, CStr(entrada.serieDocumento + "-" + entrada.documento), entrada.saldo, 0, entrada.fechaRegistro.ToShortDateString})
''                    'Next
''                    conn.Close()

''                ElseIf idcliente > 0 Then

''                    dt = EntitiToDataTable(conexion.sp_ConsultafacturasVentas(idcliente))
''                    Me.grdPagos.DataSource = dt

''                    ' Dim salidas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.idCliente = idcliente Where x.saldo > 0 And (x.facturado = True Or x.despachar = True Or x.empacado = True) And x.anulado = False Select x Order By x.fechaRegistro Descending).ToList

''                    'For Each salida As tblSalida In salidas
''                    'elegir = If((From x In listaSalidas Where x.Item1 = salida.idSalida Select x).Count() > 0, True, False)
''                    'Me.grdFacturas.Rows.Add({elegir, salida.idSalida, CStr(salida.documento), salida.saldo, 0, salida.fechaRegistro.ToShortDateString})
''                    'Next


''                    conn.Close()

''                End If

''                fnConfiguracion()

''            End Using
''        Catch

''        End Try

''    End Sub


''    Public Sub fnConfiguracion()
''        Try
''            Me.grdPagos.Columns("Id").IsVisible = False
''            Me.grdPagos.Columns("chmElegir").Width = 75
''            Me.grdPagos.Columns("chmElegir").ReadOnly = True
''            Me.grdPagos.Columns("Saldo").Width = 75
''            Me.grdPagos.Columns("Factura").Width = 75
''            Me.grdPagos.Columns("Factura").ReadOnly = True
''            Me.grdPagos.Columns("Fecha").Width = 75
''            Me.grdPagos.Columns("chmElegir").ReadOnly = True
''        Catch ex As Exception

''        End Try
''    End Sub

''#End Region

''    Private Sub grdFacturas_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles grdPagos.CellEndEdit
''        Try

''            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)

''            Dim saldo As Decimal = CDec(Me.grdPagos.Rows(fila).Cells("Saldo").Value)
''            Dim monto As Decimal = CDec(Me.grdPagos.Rows(fila).Cells("txmMontoPagar").Value)

''            If monto > saldo Then
''                alerta.contenido = "El monto ingresado es mayor al saldo del documento!"
''                alerta.fnErrorContenido()

''                Me.grdPagos.Rows(fila).Cells("txmMontoPagar").Value = 0
''            End If

''            For i As Integer = 0 To Me.grdPagos.Rows.Count - 1
''                If CInt(Me.grdPagos.Rows(i).Cells("txmMontoPagar").Value) > 0 Then
''                    Me.grdPagos.Rows(i).Cells("chmElegir").Value = True
''                End If
''            Next

''            fnTotales()
''        Catch ex As Exception

''        End Try
''    End Sub

''    Private Sub fntotales()
''        Try
''            Dim acreditacion As Decimal = CDec(Me.txtAcreditacionTotal.Text)

''            For Index As Integer = 0 To Me.grdPagos.Rows.Count - 1
''                acreditacion -= CDec(Me.grdPagos.Rows(Index).Cells("txmMontoPagar").Value)
''            Next

''            Me.txtAcreditacionPendiente.Text = CStr(acreditacion)

''        Catch ex As Exception

''        End Try
''    End Sub

''    Private Sub grdFacturas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdPagos.MouseDoubleClick
''        Try

''            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)
''            Dim salida As Integer = CInt(Me.grdPagos.Rows(index).Cells("id").Value)
''            frmPedidoConcepto.Text = "Ventas"
''            frmPedidoConcepto.idSalida = salida
''            frmPedidoConcepto.WindowState = FormWindowState.Normal
''            frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
''            permiso.PermisoDialogEspeciales(frmPedidoConcepto)
''            frmPedidoConcepto.Dispose()

''        Catch ex As Exception

''        End Try

''    End Sub

''    Private Sub fnSalir() Handles Me.panel0
''        Try
''            Me.Close()
''        Catch ex As Exception

''        End Try
''    End Sub

''End Class