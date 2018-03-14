Option Strict On


Public Class frmDespachoFacturaProductos

#Region "Variables Privadas"
    Private _listaProductos As List(Of Tuple(Of Integer, Integer, Integer, String, String, String, Tuple(Of String, String)))
#End Region

#Region "Propiedades"
    Public Property listaProductos As List(Of Tuple(Of Integer, Integer, Integer, String, String, String, Tuple(Of String, String)))
        Get
            listaProductos = _listaProductos
        End Get
        Set(value As List(Of Tuple(Of Integer, Integer, Integer, String, String, String, Tuple(Of String, String))))
            _listaProductos = value
        End Set
    End Property
#End Region

#Region "Eventos"
    'LOAD
    Private Sub frmDespachoFacturaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdListadoProductos)
        fnLlenarDatos()
    End Sub

    'SALIR
    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub
#End Region

#Region "Funciones"
    'LLENAR EL LISTADO CON LOS PRODUCTOS
    Private Sub fnLlenarDatos()
        Me.grdListadoProductos.Rows.Clear()
        For Each dato As Tuple(Of Integer, Integer, Integer, String, String, String, Tuple(Of String, String)) In listaProductos
            Dim fila As Object() = {dato.Item4, dato.Item5, dato.Item6, dato.Item7.Item1, dato.Item7.Item2, dato.Item3}
            Me.grdListadoProductos.Rows.Add(fila)
        Next
    End Sub
#End Region

End Class