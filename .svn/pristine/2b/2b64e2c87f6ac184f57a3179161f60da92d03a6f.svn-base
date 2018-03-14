Option Strict On

Imports System.Linq
Imports Telerik.WinControls

Public Class frmDetalleSurtirReserva
    Private _bitSurtir As Boolean
    Private _bitReserva As Boolean
    Private _codigo As Integer

    Public Property bitSurtir As Boolean
        Get
            bitSurtir = _bitSurtir
        End Get
        Set(ByVal value As Boolean)
            _bitSurtir = value
        End Set
    End Property

    Public Property bitReserva As Boolean
        Get
            bitReserva = _bitReserva
        End Get
        Set(ByVal value As Boolean)
            _bitReserva = value
        End Set
    End Property

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
        If bitSurtir Then
            fnDetalleSurtir()
        ElseIf bitReserva Then
            fnDetalleReserva()
        End If
        fnConfiguracion()
    End Sub

    'DATOS PRODUCTO
    Private Sub fnLlenarDatos()
        'Obtenemos el producto
        Dim producto As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = codigo _
                                       Select x).FirstOrDefault

        lblCodigo.Text = producto.codigo1
        lblArticulo.Text = producto.nombre1
    End Sub

    'DETALLE SURTIR
    Private Sub fnDetalleSurtir()
        'Obtenemos el detalle de surtir

        'fecha, cliente, documento, precio, cantidad, tipo Precio.
        Dim surtir As Linq.IQueryable = (From x In ctx.tblSurtirs Where x.articulo = codigo And x.saldo > 0 _
                        Select Fecha = x.tblSalidaDetalle.tblSalida.fechaRegistro, Cliente = x.tblCliente.Negocio, _
                        Documento = x.tblSalidaDetalle.tblSalida.documento, Precio = x.tblSalidaDetalle.precio, Cantidad = x.saldo, _
                        TipoPrecio = x.tblSalidaDetalle.tblArticuloTipoPrecio.nombre)

        Me.grdDatos.DataSource = surtir
    End Sub

    'DETALLE RESERVA
    Private Sub fnDetalleReserva()
        'Obtenemos el detalle de la reserva

        Try

            Dim reserva As Linq.IQueryable = (From x In ctx.tblSalidaDetalles Where x.tblSalida.anulado = False And x.tblSalida.despachar = False _
                                              And x.tblSalida.facturado = False And x.tblSalida.reservado = True And x.idArticulo = codigo _
                                              Select Fecha = x.tblSalida.fechaRegistro, Cliente = x.tblSalida.tblCliente.Negocio, _
                                              Documento = x.tblSalida.documento, Precio = x.precio, Cantidad = x.cantidad, TipoPrecio = x.tblArticuloTipoPrecio.nombre)


            Me.grdDatos.DataSource = reserva
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

            'fecha, cliente, documento, precio, cantidad, tipo Precio.
            Me.grdDatos.Columns("fecha").Width = 55
            Me.grdDatos.Columns("cliente").Width = 120
            Me.grdDatos.Columns("documento").Width = 55
            Me.grdDatos.Columns("precio").Width = 50
            Me.grdDatos.Columns("cantidad").Width = 50
            Me.grdDatos.Columns("tipoPrecio").Width = 70
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
