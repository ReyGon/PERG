Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmDetalleSaldo

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _codigo As Integer
    Private _saldo As Decimal

    Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property

    Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Property saldo() As Decimal
        Get
            saldo = _saldo
        End Get
        Set(ByVal value As Decimal)
            _saldo = value
        End Set
    End Property


    Private Sub frmDetalleSaldo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDetalle)
        fnLimpiar()
        fnLlenarDatos()
        fnConfiguracion()
    End Sub

    Private Sub fnLimpiar()
        lblCodigo.Text = ""
        lblCP.Text = ""
        lblSaldo.Text = ""
        Me.grdDetalle.Rows.Clear()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If bitProveedor = True Then
                If Me.grdDetalle.Rows.Count > 0 Then

                    'Centramos las columnas
                    For i As Integer = 0 To Me.grdDetalle.ColumnCount - 1
                        Me.grdDetalle.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                    Next

                    mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDetalle, "Fecha")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDetalle, "Saldo")

                    Me.grdDetalle.Columns(0).IsVisible = False

                    Me.grdDetalle.Columns("Fecha").Width = 80
                    Me.grdDetalle.Columns("Proveedor").Width = 150
                    Me.grdDetalle.Columns("Documento").Width = 80
                    Me.grdDetalle.Columns("Tipo").Width = 80
                    Me.grdDetalle.Columns("Saldo").Width = 100
                End If

            ElseIf bitCliente = True Then
                If Me.grdDetalle.Rows.Count > 0 Then

                    'Centramos las columnas
                    For i As Integer = 0 To Me.grdDetalle.ColumnCount - 1
                        Me.grdDetalle.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                    Next

                    mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDetalle, "Fecha")
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDetalle, "Saldo")

                    Me.grdDetalle.Columns(0).IsVisible = False

                    Me.grdDetalle.Columns("Fecha").Width = 115
                    Me.grdDetalle.Columns("Cliente").Width = 150
                    Me.grdDetalle.Columns("Documento").Width = 80
                    Me.grdDetalle.Columns("Saldo").Width = 85
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para calcular el detalle de saldo
    Private Sub fnLlenarDatos()
        Try
            lblSaldo.Text = Format(saldo, mdlPublicVars.formatoMoneda)
            lblCodigo.Text = codigo
            If bitCliente = True Then
                'Obtenemos los datos del cliente
                Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo _
                                                 Select x).FirstOrDefault

                lblCP.Text = cliente.Negocio

                'Creamos la datatable
                Dim data As New DataTable
                data.Columns.Add("Codigo")
                data.Columns.Add("Fecha")
                data.Columns.Add("Cliente")
                data.Columns.Add("Documento")
                data.Columns.Add("Saldo")

                'Obtenemos todas las facturas
                Dim lFacturas As List(Of tblFactura) = (From x In ctx.tblFacturas, y In ctx.tblSalidas _
                                                        Where (x.anulado = False And y.idCliente = codigo And y.IdFactura = x.IdFactura) _
                                                        Select x Distinct).ToList

                Dim factura As tblFactura

                'Recorremos la lista de facturas
                For Each factura In lFacturas

                    Dim totalCompras As Decimal = factura.Monto

                    If saldo > totalCompras Then
                        'Si el saldo es mayor a la compra, esto quiere decir que no se ha cancelado esa compra
                        'Creamos la fila, para agregar al grid
                        Dim fila As Object()

                        fila = {factura.IdFactura, factura.Fecha, lblCP.Text, factura.DocumentoFactura, Format(totalCompras, mdlPublicVars.formatoMoneda)}
                        data.Rows.Add(fila)
                        saldo -= totalCompras
                    Else
                        Dim fila As Object()
                        fila = {factura.IdFactura, factura.Fecha, lblCP.Text, factura.DocumentoFactura, Format(saldo, mdlPublicVars.formatoMoneda)}
                        data.Rows.Add(fila)
                        saldo = 0
                    End If

                    If saldo = 0 Then
                        Exit For
                    End If

                Next
                Me.grdDetalle.DataSource = data
            ElseIf bitProveedor = True Then
                'Obtenemos los datos del proveedor
                Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigo _
                                                 Select x).FirstOrDefault

                lblCP.Text = proveedor.negocio

                'Creamos la datatable
                Dim data As New DataTable
                data.Columns.Add("Codigo")
                data.Columns.Add("Fecha")
                data.Columns.Add("Proveedor")
                data.Columns.Add("Documento")
                data.Columns.Add("Tipo")
                data.Columns.Add("Saldo")

                'Obtenemos todas las compras realizadas al proveedor y las devoluciones
                Dim lCompras As List(Of tblEntrada) = (From x In ctx.tblEntradas Where x.idProveedor = codigo _
                                                      And x.anulado = False Select x Order By x.fechaRegistro Descending).ToList

                Dim compra As tblEntrada

                'Recorremos la lista de compras
                For Each compra In lCompras
                    'Verificamos si se han realizado devoluciones de esa compra
                    Dim lDevoluciones As List(Of tblDevolucionProveedor) = (From x In ctx.tblDevolucionProveedors Where x.proveedor = codigo And _
                                                                            x.acreditado = True And x.anulado = False And x.entrada = compra.idEntrada _
                                                                            Select x).ToList
                    Dim devolucion As tblDevolucionProveedor

                    Dim totalDevoluciones As Decimal = 0
                    Dim totalCompras As Decimal = compra.total
                    For Each devolucion In lDevoluciones
                        totalDevoluciones += devolucion.monto
                    Next

                    totalCompras -= totalDevoluciones


                    If saldo > totalCompras Then
                        'Si el saldo es mayor a la compra, esto quiere decir que no se ha cancelado esa compra
                        'Creamos la fila, para agregar al grid
                        Dim fila As Object()
                        fila = {compra.idEntrada, compra.fechaRegistro.ToShortDateString, devolucion.tblProveedor.negocio, compra.documento, If(compra.credito = True, "Credito", "Contado"), Format(totalCompras, mdlPublicVars.formatoMoneda)}
                        data.Rows.Add(fila)
                        saldo -= totalCompras
                    Else
                        Dim fila As Object()
                        fila = {compra.idEntrada, compra.fechaRegistro.ToShortDateString, devolucion.tblProveedor.negocio, compra.documento, If(compra.credito = True, "Credito", "Contado"), Format(saldo, mdlPublicVars.formatoMoneda)}
                        data.Rows.Add(fila)
                        saldo = 0
                    End If

                    If saldo = 0 Then
                        Exit For
                    End If

                Next

                Me.grdDetalle.DataSource = data

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDetalle.CellDoubleClick
        Try
            Dim codigo As Integer = e.Row.Cells("Codigo").Value
            If bitProveedor Then
                frmEntrada.codigo = codigo
                frmEntrada.bitEditarEntrada = True
                frmEntrada.verRegistro = True
                frmEntrada.StartPosition = FormStartPosition.CenterScreen
                frmEntrada.Text = "Compras"
                frmEntrada.Show()
            ElseIf bitCliente Then
                frmFacturaConcepto.Text = "Pedidos"
                frmFacturaConcepto.codigo = codigo
                frmFacturaConcepto.WindowState = FormWindowState.Normal
                frmFacturaConcepto.StartPosition = FormStartPosition.CenterScreen
                frmFacturaConcepto.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
