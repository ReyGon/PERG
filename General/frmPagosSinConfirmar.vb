Imports System.Linq

Public Class frmPagosSinConfirmar

    Private _codigo As Integer
    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property


    Private _bitCliente As Boolean
    Public Property bitCliente As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property


    Private _bitProveedor As Boolean
    Public Property bitProveedor As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property


    Private Sub frmPagosSinConfirmar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridMovimientos(RadGridView1)

            If bitCliente Then

                Dim Listado = From x In ctx.tblCajas Where x.anulado = False And x.confirmado = False
                                                  Select Codigo = x.codigo, Cliente = x.tblCliente.Nombre1, Fecha = x.fecha, FechaCobro = x.fechaCobro, TipoDePago = x.tblTipoPago.nombre, x.documento, Monto = x.monto, Observacion = x.observacion

                Me.RadGridView1.DataSource = Listado

                mdlPublicVars.fnGridTelerik_formatoMoneda(RadGridView1, "Monto")
                mdlPublicVars.fnGridTelerik_formatoFecha(RadGridView1, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(RadGridView1, "FechaCobro")

                RadGridView1.Columns(0).Width = 100
                RadGridView1.Columns(1).Width = 300
                RadGridView1.Columns(2).Width = 100
                RadGridView1.Columns(3).Width = 100
                RadGridView1.Columns(4).Width = 150
                RadGridView1.Columns(5).Width = 150
                RadGridView1.Columns(6).Width = 150
                RadGridView1.Columns(7).Width = 250

            End If
        Catch ex As Exception
            RadGridView1.DataSource = Nothing
        End Try
    End Sub


    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class

