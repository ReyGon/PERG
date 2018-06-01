Option Strict On

Imports System.Linq
Imports Telerik.WinControls
Imports System.Data.EntityClient


Public Class frmDetalleAjustes
    Private _codigo As Integer

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmDetalleSurtirReserva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenarDatos()

        fnConfiguracion()
    End Sub

    'DATOS PRODUCTO
    Private Sub fnLlenarDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim producto As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = codigo _
                                         Select x).FirstOrDefault

                lblCodigo.Text = producto.codigo1
                lblArticulo.Text = producto.nombre1

                Dim ajustes As Linq.IQueryable = (From x In conexion.tblMovimientoInventarioDetalles Where x.tblMovimientoInventario.anulado = False _
                                                  And x.tblMovimientoInventario.revisado = False And x.articulo = codigo And x.tblMovimientoInventario.bitVenta = True _
                                                  Select Fecha = x.tblMovimientoInventario.fechaRegistro, Correlativo = x.tblMovimientoInventario.correlativo, _
                                                  Descripcion = x.tblMovimientoInventario.observacion, Movimiento = x.tblTipoMovimiento.nombre, Cantidad = x.cantidad)

                Me.grdDatos.DataSource = ajustes

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'CONFIGURACION
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")

            Me.grdDatos.Columns("Fecha").Width = 50
            Me.grdDatos.Columns("Correlativo").Width = 50
            Me.grdDatos.Columns("Descripcion").Width = 180
            Me.grdDatos.Columns("Movimiento").Width = 50
            Me.grdDatos.Columns("Cantidad").Width = 50
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
