Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmProductosTransito

    Private _codProducto As Integer

    Public Property codProducto As Integer
        Get
            codProducto = _codProducto
        End Get
        Set(value As Integer)
            _codProducto = value
        End Set
    End Property

    Private Sub frmProductosTransito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdTransito)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdTransito)
            fnLlenarProductos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarProductos()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Dim consulta = (From x In conexion.tblEntradasDetalles Where x.tblEntrada.compra = False And x.tblEntrada.preforma = False And x.tblEntrada.transito = True _
                ''                And x.tblEntrada.anulado = False And x.idArticulo = codProducto Select Fecha = CDate(x.tblEntrada.fechaIngresoTransito), Codigo = x.tblArticulo.codigo1, _
                ''                Producto = x.tblArticulo.nombre1, Cantidad = x.cantidad Order By Fecha Ascending)

                ''Me.grdTransito.DataSource = consulta

                ''Dim salidas As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.idCliente = idCliente Where x.saldo > 0 And (x.facturado = True Or x.despachar = True Or x.empacado = True) And x.anulado = False Select x Order By x.fechaRegistro Descending).ToList

                ''For Each salida As tblSalida In salidas
                ''    elegir = If((From x In listaSalidas Where x.Item1 = salida.idSalida Select x).Count() > 0, True, False)
                ''    Me.grdFacturas.Rows.Add({elegir, salida.idSalida, CStr(salida.documento), salida.saldo, 0, salida.fechaRegistro.ToShortDateString})
                ''Next

                Dim productos As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.tblEntrada.compra = False And x.tblEntrada.preforma = False And x.tblEntrada.Invoice = True _
                                And x.tblEntrada.anulado = False And x.idArticulo = codProducto Select x Order By x.tblEntrada.FechaIngresoTransito Ascending).ToList

                Dim fecha As Date

                For Each detalle As tblEntradasDetalle In productos

                    fecha = detalle.tblEntrada.FechaIngresoTransito

                    Me.grdTransito.Rows.Add({fecha.ToShortDateString, detalle.tblArticulo.codigo1, detalle.tblArticulo.nombre1, detalle.cantidad})

                Next

                Me.grdTransito.Columns("Fecha").Width = 75
                Me.grdTransito.Columns("Codigo").Width = 75
                Me.grdTransito.Columns("Nombre").Width = 200
                Me.grdTransito.Columns("Cantidad").Width = 75

                Me.grdTransito.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdTransito.Columns("Codigo").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdTransito.Columns("Nombre").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdTransito.Columns("Cantidad").TextAlignment = ContentAlignment.MiddleCenter

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
