Imports Telerik.WinControls

Public Class frmEditaPrecio
    Private _precio As Decimal
    Private _bitLiquidacion As Boolean
    Private _bitPrincipal As Boolean
    Private _bitSustitutos As Boolean
    Private _bitCatalogo As Boolean
    Private _bitNuevos As Boolean
    Private _bitSugerir As Boolean
    Private _bitPendientes As Boolean
    Private _bitVentas As Boolean
    Private _costo As Decimal
    Private _bitOfertas As Boolean
    Private _bitIndicadores As Boolean  'Agregado YOEL
    Private _formSalida As frmSalidas
    Private _formVentaPequenia As frmVentaPequenia 'para la venta pequenia

    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property

    Public Property formVentaPequenia As frmVentaPequenia
        Get
            formVentaPequenia = _formVentaPequenia
        End Get
        Set(value As frmVentaPequenia)
            _formVentaPequenia = value
        End Set
    End Property


    Public Property precio() As Decimal
        Get
            precio = _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property bitLiquidacion() As Boolean
        Get
            bitLiquidacion = _bitLiquidacion
        End Get
        Set(ByVal value As Boolean)
            _bitLiquidacion = value
        End Set
    End Property

    Public Property bitPrincipal() As Boolean
        Get
            bitPrincipal = _bitPrincipal
        End Get
        Set(ByVal value As Boolean)
            _bitPrincipal = value
        End Set
    End Property

    Public Property bitSustitutos() As Boolean
        Get
            bitSustitutos = _bitSustitutos
        End Get
        Set(ByVal value As Boolean)
            _bitSustitutos = value
        End Set
    End Property

    Public Property bitNuevos() As Boolean
        Get
            bitNuevos = _bitNuevos
        End Get
        Set(ByVal value As Boolean)
            _bitNuevos = value
        End Set
    End Property

    Public Property bitCatalogo() As Boolean
        Get
            bitCatalogo = _bitCatalogo
        End Get
        Set(ByVal value As Boolean)
            _bitCatalogo = value
        End Set
    End Property

    Public Property bitSugerir() As Boolean
        Get
            bitSugerir = _bitSugerir
        End Get
        Set(ByVal value As Boolean)
            _bitSugerir = value
        End Set
    End Property

    Public Property bitPendientes() As Boolean
        Get
            bitPendientes = _bitPendientes
        End Get
        Set(ByVal value As Boolean)
            _bitPendientes = value
        End Set
    End Property

    Public Property costo() As Decimal
        Get
            costo = _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
        End Set
    End Property

    Public Property bitVentas As Boolean
        Get
            bitVentas = _bitVentas
        End Get
        Set(value As Boolean)
            _bitVentas = value
        End Set
    End Property

    Public Property bitOfertas As Boolean
        Get
            bitOfertas = _bitOfertas
        End Get
        Set(value As Boolean)
            _bitOfertas = value
        End Set
    End Property

    Public Property bitIndicadores As Boolean
        Get
            bitIndicadores = _bitIndicadores
        End Get
        Set(value As Boolean)
            _bitIndicadores = value
        End Set
    End Property

    Private Sub frmEditaPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nm2Precio.Value = precio
        If costo > 0 Then
            lblCosto.Text = Format(costo, mdlPublicVars.formatoMoneda)
        Else
            lblCosto.Visible = False
            lblECosto.Visible = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            fnAgregarPrecio()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnAgregarPrecio()
        Try
            If nm2Precio.Value > 0 Then
                mdlPublicVars.superSearchPrecio = nm2Precio.Value
                mdlPublicVars.superSearchTipoPrecio = mdlPublicVars.Empresa_PrecioEspecial
                Me.Close()

                If bitPrincipal = True Then
                    If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                        frmBuscarArticulo.fnAgregarPrecio(True)
                    ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                        frmBuscarArticuloVentaPequenia.fnAgregarPrecio(True)
                    End If
                ElseIf bitSustitutos = True Then
                    frmBuscarArticuloSustitutos.fnAgregarPrecio(True)
                ElseIf bitCatalogo = True Then
                    frmBuscarArticuloCatalogo.fnAgregarPrecio(True)
                ElseIf bitNuevos = True Then
                    frmBuscarArticuloProductosNuevos.fnAgregarPrecio(True)
                ElseIf bitSugerir = True Then
                    frmBuscarArticuloSugeridos.fnAgregarPrecio(True)
                ElseIf bitPendientes = True Then
                    frmBuscarArticuloPendienteSurtir.fnAgregarPrecio(True)
                ElseIf bitLiquidacion = True Then
                    frmBuscarArticulo.fnAgregarPrecioLiquidacion()
                ElseIf bitOfertas = True Then
                    frmBuscarArticuloOfertas.fnAgregarPrecio(True)
                ElseIf bitIndicadores Then
                    frmDetallePendienteNuevo.fnAgregarPrecio(True)
                ElseIf bitVentas Then
                    If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                        formSalida.fnAgregarPrecio(False)
                        formSalida.fnActualizar_Total()
                    ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                        formVentaPequenia.fnAgregarPrecio(False)
                        formVentaPequenia.fnActualizar_Total()
                    End If
                End If
            Else
                RadMessageBox.Show(Me, "Clave incorrecta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
