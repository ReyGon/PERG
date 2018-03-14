Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Imports System.Data.EntityClient
Public Class frmsugerir1
    Dim tbl As New clsDevuelveTabla

    Private _idCliente As Int32
    Private _bitBusqueda As Boolean
    Private _bitVentaContado As Boolean
    Private _bitVentaCredito As Boolean
    Private _bitOtros As Boolean
    Private _bitConfig As Boolean
    Private _bitConsignacion As Boolean
    Private _bitCotizacion As Boolean
    Private _bitEntrada As Boolean
    Private _bitRestaurant As Boolean
    Private _codBuscar As Integer
    Private _codclie As Integer
    Private _codvendedor As Integer
    Private _OpcionRetorno As String
    Private _idInventario As Integer
    Private _idBodega As Integer

    Private _bitProveedor As Boolean
    Private _bitCliente As Boolean
    Private _bitFiltro As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitDevolucionCliente As Boolean

    Private _venta As Integer
    Private _grdIngresados As Telerik.WinControls.UI.RadGridView

    Private _formSalida As frmSalidas
    Public frmRetornoSalidas As frmSalidas


    Private _formVentaPequenia As frmVentaPequenia 'Venta pequenia
    Public frmRetornoVentaPequenia As frmVentaPequenia
    Private _ventaPequenia As Integer





    Public Property bitProveedor() As Boolean
        Get
            bitProveedor = _bitProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitProveedor = value
        End Set
    End Property

    Public Property idInventario() As Integer
        Get
            idInventario = _idInventario
        End Get
        Set(value As Integer)
            _idInventario = value
        End Set
    End Property

    Public Property idBodega() As Integer
        Get
            idBodega = _idBodega
        End Get
        Set(value As Integer)
            _idBodega = value
        End Set
    End Property

    ' esta varible si esta en True sirve para enviar de parametro el id al sp y una opcion filtro para que busque ese articulo solamente.
    Public Property bitFiltro() As Boolean
        Get
            bitFiltro = _bitFiltro
        End Get
        Set(ByVal value As Boolean)
            _bitFiltro = value
        End Set
    End Property

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(ByVal value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Public Property bitMovimientoInventario() As Boolean
        Get
            bitMovimientoInventario = _bitMovimientoInventario
        End Get
        Set(ByVal value As Boolean)
            _bitMovimientoInventario = value
        End Set
    End Property

    Public Property bitDevolucionCliente() As Boolean
        Get
            bitDevolucionCliente = _bitDevolucionCliente
        End Get
        Set(ByVal value As Boolean)
            _bitDevolucionCliente = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codclie
        End Get
        Set(ByVal value As Integer)
            _codclie = value
        End Set
    End Property

    Public Property codBuscar() As Integer
        Get
            codBuscar = _codBuscar
        End Get
        Set(ByVal value As Integer)
            _codBuscar = value
        End Set
    End Property

    Public Property codVendedor() As Integer
        Get
            codVendedor = _codvendedor
        End Get
        Set(ByVal value As Integer)
            _codvendedor = value
        End Set
    End Property

    Public Property OpcionRetorno() As String
        Get
            OpcionRetorno = _OpcionRetorno
        End Get
        Set(ByVal value As String)
            _OpcionRetorno = value
        End Set
    End Property

    Public Property venta As Integer
        Get
            venta = _venta
        End Get
        Set(ByVal value As Integer)
            _venta = value
        End Set
    End Property

    Public Property grdIngresados As Telerik.WinControls.UI.RadGridView
        Get
            grdIngresados = _grdIngresados
        End Get
        Set(ByVal value As Telerik.WinControls.UI.RadGridView)
            _grdIngresados = value
        End Set
    End Property

    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property


    ' Agregado para la ventapequenia
    Public Property formVentaPequenia As frmVentaPequenia
        Get
            formVentaPequenia = _formVentaPequenia
        End Get
        Set(value As frmVentaPequenia)
            _formVentaPequenia = value
        End Set
    End Property

    Public Property ventaPequenia As Integer
        Get
            ventaPequenia = _ventaPequenia
        End Get
        Set(value As Integer)
            _ventaPequenia = value
        End Set
    End Property



    Public Property bitRestaurant As Boolean
        Get
            bitRestaurant = _bitRestaurant
        End Get
        Set(value As Boolean)
            _bitRestaurant = value
        End Set
    End Property

    Public Property bitConsignacion As Boolean
        Get
            bitConsignacion = _bitConsignacion
        End Get
        Set(value As Boolean)
            _bitConsignacion = value
        End Set
    End Property

    Public Property idCliente() As Int32
        Get
            idCliente = _idCliente
        End Get
        Set(ByVal value As Int32)
            _idCliente = value
        End Set
    End Property

    Public Property bitBusqueda() As Boolean
        Get
            bitBusqueda = _bitBusqueda
        End Get
        Set(ByVal value As Boolean)
            _bitBusqueda = value
        End Set
    End Property

    Public Property bitEntrada() As Boolean
        Get
            bitEntrada = _bitEntrada
        End Get
        Set(ByVal value As Boolean)
            _bitEntrada = value
        End Set
    End Property

    Public Property bitVentaContado() As Boolean
        Get
            bitVentaContado = _bitVentaContado
        End Get
        Set(value As Boolean)
            _bitVentaContado = value
        End Set
    End Property

    Public Property bitVentaCredito() As Boolean
        Get
            bitVentaCredito = _bitVentaCredito
        End Get
        Set(value As Boolean)
            _bitVentaCredito = value
        End Set
    End Property

    Public Property bitOtros As Boolean
        Get
            bitOtros = _bitOtros
        End Get
        Set(value As Boolean)
            _bitOtros = value
        End Set
    End Property

    Public Property bitConfig As Boolean
        Get
            bitConfig = _bitConfig
        End Get
        Set(value As Boolean)
            _bitConfig = value
        End Set
    End Property

    Public Property bitCotizacion As Boolean
        Get
            bitCotizacion = _bitCotizacion
        End Get
        Set(value As Boolean)
            _bitCotizacion = value
        End Set
    End Property

    Private Sub frmsugerir1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.grdProducto.DataSource = tbl.tablaSP("exec cargarProductosCompra")
        'Me.grdProducto.Columns(0).Width = 50
        'Me.grdProducto.Columns(1).Width = 90
        'Me.grdProducto.Columns(2).Width = 350
        'Me.grdProducto.Columns(3).Width = 90
        'Me.grdProducto.Columns(4).Width = 90
        'Me.grdProducto.Columns(5).Width = 90

    End Sub


    'Private Sub fnLlenar_productos()
    '    Try
    '        Me.grdProducto.DataSource = Nothing

    '        Dim cons = Nothing
    '        Dim cons2 = Nothing

    '        If bitMovimientoInventario = True Then
    '            cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, txtFiltro.Text, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, True, False, codigoMarcaRepuesto, venta)
    '        Else
    '            cons = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, txtFiltro.Text, idInventario, idBodega, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)

    '        End If
    '        If Not bitProveedor Then
    '            cons2 = ctx.sp_buscar_Articulo(mdlPublicVars.idEmpresa, txtFiltro.Text, mdlPublicVars.General_InventarioLiquidacion, mdlPublicVars.General_idAlmacenPrincipal, codigoTipoVehiculo, codigomodeloVehiculo, codClie, 1, bitCliente, bitProveedor, codigoMarcaRepuesto, venta)
    '        End If
    '        Else
    '        RadMessageBox.Show("Debe ingresar al menos una palabra para filtrar", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    '        End If

    '        grdProducto.DataSource = cons

    '    Catch ex As Exception
    '        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
    '        grdProducto.DataSource = Nothing
    '    End Try

    '    mdlPublicVars.fnGrid_iconos(Me.grdProducto)
    '    Me.BringToFront()

    'End Sub

    Private Sub buscar()


        If mdlPublicVars.superSearchBuscador IsNot Nothing Then
            If mdlPublicVars.superSearchBuscador.Length > 0 And txtBuscar1.Text.Length = 0 Then
                txtBuscar1.Text = mdlPublicVars.superSearchBuscador
            End If
        End If

        If Me.txtBuscar1.Text = "" Then
            RadMessageBox.Show("Defina al menos un filtro de busqueda", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Sub
        End If

        Dim filtros() As String
        Dim filtro1 As String
        Dim i As Integer
        Dim filtro As String = ""

        ''filtros = Split(Me.txtBusqueda.Text, " ")

        ''For i = 0 To 6
        ''    If i <= UBound(filtros) Then
        ''        filtro = filtro & "'" & filtros(i) & "',"
        ''    Else
        ''        filtro = filtro & "'',"
        ''    End If
        ''Next i

        ''filtro = Mid(filtro, 1, Len(filtro) - 1)

        For i = 0 To 6
            If i <= 0 Then
                filtro = filtro & "'" & Me.txtBuscar1.Text & "',"

            Else
                filtro = filtro & "'',"
            End If
        Next

        filtro = Mid(filtro, 1, Len(filtro) - 1)

        'Dim opcion As Integer = If(bitEntrada Or bitConsignacion, 2, 1)



        Me.grdProducto.DataSource = tbl.tablaSP("exec sp_articulosFiltro2 " & filtro)
        '' Me.grdProducto.DataSource = ctx.sp_articulosFiltro2(filtro, "", "", "", "", "", "")


        mdlPublicVars.superSearchNombre = ""
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call buscar()
    End Sub

    Private Sub txtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Do something here
            Call buscar()
            e.Handled = True
        End If
    End Sub

    Private Sub txtFiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar1.KeyPress

    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar1.TextChanged
        buscar()
    End Sub

    
    ''PRODUCTOS
    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub


End Class
