Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmBuscarArticuloPrecios

    Private _codigo As Integer
    Private _codClie As Integer
    Private _precioNormal As Decimal

    Private _bitPrincipal As Boolean
    Private _bitSustitutos As Boolean
    Private _bitCatalogo As Boolean
    Private _bitNuevos As Boolean
    Private _bitSugerir As Boolean
    Private _bitPendientes As Boolean
    Private _bitVentas As Boolean
    Private _bitOfetas As Boolean
    Private _bitIndicadores As Boolean      'Agregado YOEL
    Private _idtipoinventario As Integer

    Private _bitVentaPequenia As Boolean 'Agregado para la venta pequeña

    Private permiso As New clsPermisoUsuario

    Private _formSalida As frmSalidas
    Private _formVentaPequenia As frmVentaPequenia

    Public Property formSalida As frmSalidas
        Get
            formSalida = _formSalida
        End Get
        Set(value As frmSalidas)
            _formSalida = value
        End Set
    End Property


    'Agregado para la venta pequeña
    Public Property formVentaPequenia As frmVentaPequenia
        Get
            formVentaPequenia = _formVentaPequenia
        End Get
        Set(value As frmVentaPequenia)
            _formVentaPequenia = value
        End Set
    End Property

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property idtipoinventario() As Integer
        Get
            idtipoinventario = _idtipoinventario
        End Get
        Set(value As Integer)
            _idtipoinventario = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
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
            bitOfertas = _bitOfetas
        End Get
        Set(value As Boolean)
            _bitOfetas = value
        End Set
    End Property

    Public Property precioNormal() As Decimal
        Get
            precioNormal = _precioNormal
        End Get
        Set(ByVal value As Decimal)
            _precioNormal = value
        End Set
    End Property


    'Agregado para venta pequeña 4-3-2014
    Public Property bitVentaPequenia() As Boolean
        Get
            bitVentaPequenia = _bitVentaPequenia
        End Get
        Set(value As Boolean)
            _bitVentaPequenia = value
        End Set
    End Property

    'Cambios YOEL
    Public Property bitIndicadores() As Boolean
        Get
            bitIndicadores = _bitIndicadores
        End Get
        Set(value As Boolean)
            _bitIndicadores = value
        End Set
    End Property

    Private Sub frmBuscarArticuloPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdModelos)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdUltimasVentas)
            Me.grdModelos.ImageList = frmControles.ImageListAdministracion
            fnLimpiar()
            fnLlenarDatos()
            fnConfiguracion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarDatos()


        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                Me.grdModelos.Rows.Clear()
                'Obtenemos el articulo
                Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault
                lblArticulo.Text = articulo.nombre1
                lblCodigo.Text = articulo.codigo1

                Dim inv As tblInventario = (From x In conexion.tblInventarios.AsEnumerable Where x.idArticulo = codigo Select x).First
                If inv IsNot Nothing Then
                    lblSaldo.Text = inv.saldo
                Else
                    lblSaldo.Text = 0
                End If

                Try
                    lblObservacion.Text = articulo.observacionPrecio
                Catch ex As Exception
                    lblObservacion.Text = ""
                End Try


                Dim pPublico = (From x In conexion.sp_Articulo_PrecioPublico(codigo, codClie) Select x).FirstOrDefault

                Dim pre As Double
                pre = pPublico.PrecioPublico


                Dim pr = (From x In conexion.sp_redondearPrecio(pre)).FirstOrDefault

                lblPrecioNormal.Text = Format(pr.Precio, mdlPublicVars.formatoMoneda)
            Catch ex As Exception
            End Try

        End Using

        fnLlenarGrid()
        fnLlenarUltimas()
        fnConfiguracion()
        fnEstadisticas()
    End Sub

    'Funcion utilizada para obtener las estadisticas
    Private Sub fnEstadisticas()
        Try
            Dim cons As sp_PriceCalculos_Result = ctx.sp_PriceCalculos(codigo, codClie).FirstOrDefault

            If cons IsNot Nothing Then
                lblCantidadMaxima.Text = cons.CantidadMaxima
                lblCantidadPromedio.Text = cons.CantidadPromedioFactura
                lblPrecioPromedio.Text = cons.PrecioPromedio
                lblVentaPromedio.Text = cons.VentaPromedio
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para llenar el grid de precios
    Private Sub fnLlenarGrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim datos

                ''RadMessageBox.Show(idtipoinventario, nombreSistema)

                If mdlPublicVars.bitTransportePesado = True Then
                    ''datos = conexion.sp_articulo_precios_pequenio(codigo,mdlpu
                    Dim porcentajepublico As Double

                    porcentajepublico = mdlPublicVars.PorcentajePrecio / 100

                    datos = conexion.sp_articulo_precios_Pequenio(codigo, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal, codClie, porcentajepublico, mdlPublicVars.Empresa_PrecioNormal)
                Else
                    datos = conexion.sp_articulo_precios(codigo, mdlPublicVars.General_idTipoInventario, General_idAlmacenPrincipal, codClie, idtipoinventario)
                End If

                Me.grdModelos.DataSource = datos
                mdlPublicVars.fnGrid_iconos(grdModelos)
                fnConfiguracion()
                fnActualizar_porcentaje()
                fnActualizarColores()

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para actualizar el color en el grid de precios
    Private Sub fnActualizarColores()
        Try
            'Variables que se utilizaran temporalmente
            Dim tPrecio As Integer = 0
            Dim porcentaje As Decimal = 0
            Dim color As Integer = 0
            'Recorremos el grid
            For i As Integer = 0 To Me.grdModelos.RowCount - 1
                color = 0
                'Obtenemos los valores del tipo de precio y el porcentaje
                tPrecio = Me.grdModelos.Rows(i).Cells("codigo").Value
                porcentaje = Me.grdModelos.Rows(i).Cells("Porcentaje").Value

                'Realizamos la consulta para obtener el estado
                Dim rango As tblTipoPrecio_Rango = (From x In ctx.tblTipoPrecio_Rango _
                                                    Where porcentaje >= x.inicio And porcentaje <= x.fin And x.tipoPrecio = tPrecio _
                                                    Select x).FirstOrDefault

                'Establecemos el color
                If rango IsNot Nothing Then
                    color = rango.color
                End If

                Me.grdModelos.Rows(i).Cells("clrEstado").Value = color

              

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If mdlPublicVars.bitTransportePesado = True Then
                If grdModelos.ColumnCount > 0 Then
                    Me.grdModelos.Columns(0).Width = 100
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdModelos, "Precio")
                    Me.grdModelos.Columns("codigo").IsVisible = False
                    Me.grdModelos.Columns("VentaPromedio").IsVisible = False
                    Me.grdModelos.Columns("clrEstado").IsVisible = False
                    Me.grdModelos.Columns("Porcentaje").IsVisible = False
                    Me.grdModelos.Columns("bitCantidadMinima").IsVisible = False
                    Me.grdModelos.Columns("cantidadMinima").IsVisible = False
                    Me.grdModelos.Columns("Muestra").IsVisible = False
                    Me.grdModelos.Columns("Usuario").IsVisible = False
                    Me.grdModelos.Columns("Contrasenia").IsVisible = False
                    Me.grdModelos.Columns("txmCantidad").IsVisible = False

                    Me.grdModelos.Columns("tipoPrecio").HeaderText = "Tipo de Precio"
                    ''Me.grdModelos.Columns("precio"). = "txmPrecio"

                    For i As Integer = 0 To Me.grdModelos.ColumnCount - 1
                        Me.grdModelos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                        Me.grdModelos.Columns(i).ReadOnly = True
                    Next

                    Me.grdModelos.Columns("txmCantidad").ReadOnly = False

                    'codigo,tipoPrecio,Precio,Minimo,txmCantidad,VentaPromedio,0 Porcentaje,'' Estado, Observacion
                    Me.grdModelos.Columns("tipoPrecio").Width = 75
                    Me.grdModelos.Columns("Precio").Width = 75
                    Me.grdModelos.Columns("Minimo").Width = 75
                    Me.grdModelos.Columns("Maximo").Width = 75
                    Me.grdModelos.Columns("txmCantidad").Width = 75
                    Me.grdModelos.Columns("Porcentaje").Width = 20
                    Me.grdModelos.Columns("clrEstado").Width = 50
                    Me.grdModelos.Columns("Observacion").Width = 100
                    Me.grdModelos.Columns("Usuario").Width = 75
                    Me.grdModelos.Columns("Contrasenia").Width = 90

                    Me.grdModelos.Columns("Precio").ReadOnly = False
                End If
            Else
                If grdModelos.ColumnCount > 0 Then
                    Me.grdModelos.Columns(0).Width = 100
                    mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdModelos, "Precio")
                    Me.grdModelos.Columns("codigo").IsVisible = False
                    Me.grdModelos.Columns("VentaPromedio").IsVisible = False
                    Me.grdModelos.Columns("clrEstado").IsVisible = False
                    Me.grdModelos.Columns("Porcentaje").IsVisible = False
                    Me.grdModelos.Columns("bitCantidadMinima").IsVisible = False
                    Me.grdModelos.Columns("cantidadMinima").IsVisible = False

                    Me.grdModelos.Columns("tipoPrecio").HeaderText = "Tipo de Precio"

                    For i As Integer = 0 To Me.grdModelos.ColumnCount - 1
                        Me.grdModelos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                        Me.grdModelos.Columns(i).ReadOnly = True
                    Next

                    Me.grdModelos.Columns("txmCantidad").ReadOnly = False

                    'codigo,tipoPrecio,Precio,Minimo,txmCantidad,VentaPromedio,0 Porcentaje,'' Estado, Observacion
                    Me.grdModelos.Columns("tipoPrecio").Width = 20
                    Me.grdModelos.Columns("Precio").Width = 20
                    Me.grdModelos.Columns("Minimo").Width = 20
                    Me.grdModelos.Columns("txmCantidad").Width = 20
                    Me.grdModelos.Columns("Porcentaje").Width = 20
                    Me.grdModelos.Columns("clrEstado").Width = 20
                    Me.grdModelos.Columns("Observacion").Width = 40
                End If
            End If
            

            If Me.grdUltimasVentas.ColumnCount > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdUltimasVentas, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdUltimasVentas, "Precio")

                Me.grdUltimasVentas.Columns(0).Width = 70
                Me.grdUltimasVentas.Columns(1).Width = 60
                Me.grdUltimasVentas.Columns(2).Width = 70
                Me.grdUltimasVentas.Columns(3).Width = 70
                Me.grdUltimasVentas.Columns(4).Width = 120

                For i As Integer = 0 To Me.grdUltimasVentas.ColumnCount - 1
                    Me.grdUltimasVentas.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnActualizar_porcentaje()
        Dim index
        Dim porcentaje As Double
        Dim cantidad As Double
        Dim precio As Double
        Dim VentaPromedio As Double
        Try
            For index = 0 To grdModelos.Rows.Count - 1
                If IsNothing(grdModelos.Rows(index).Cells("txmCantidad").Value) Then
                    porcentaje = 0
                Else

                    If IsNumeric(grdModelos.Rows(index).Cells("txmCantidad").Value) Then
                        cantidad = grdModelos.Rows(index).Cells("txmCantidad").Value
                        precio = grdModelos.Rows(index).Cells("Precio").Value
                        VentaPromedio = grdModelos.Rows(index).Cells("VentaPromedio").Value
                        porcentaje = (((cantidad * precio) - VentaPromedio) / VentaPromedio) * 100
                    Else
                        porcentaje = 0
                    End If

                End If

                grdModelos.Rows(index).Cells("Porcentaje").Value = porcentaje   'Format(porcentaje, mdlPublicVars.formatoNumero)
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnLimpiar()
        grdModelos.DataSource = Nothing
    End Sub

    Private Sub fnAgregarPrecio()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            If Me.grdModelos.CurrentRow.Index >= 0 Then

                If fnErrores() = True Then
                    Exit Sub
                End If

                If mdlPublicVars.bitTransportePesado = True Then

                    Dim codigo As Integer

                    codigo = Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("codigo").Value

                    If codigo = mdlPublicVars.Empresa_PrecioNormal Then
                        mdlPublicVars.superSearchPrecio = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("Precio").Value, Decimal)
                        mdlPublicVars.superSearchCantidad = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("txmCantidad").Value, Integer)
                        mdlPublicVars.superSearchTipoPrecio = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("codigo").Value, Integer)
                        Me.Close()

                        If bitPrincipal = True Then
                            frmBuscarArticulo.fnAgregarPrecio(False)
                        ElseIf bitSustitutos = True Then
                            frmBuscarArticuloSustitutos.fnAgregarPrecio(False)
                        ElseIf bitCatalogo = True Then
                            frmBuscarArticuloCatalogo.fnAgregarPrecio(False)
                        ElseIf bitNuevos = True Then
                            frmBuscarArticuloProductosNuevos.fnAgregarPrecio(False)
                        ElseIf bitSugerir = True Then
                            frmBuscarArticuloSugeridos.fnAgregarPrecio(False)
                        ElseIf bitPendientes = True Then
                            frmBuscarArticuloPendienteSurtir.fnAgregarPrecio(False)
                        ElseIf bitOfertas = True Then
                            frmBuscarArticuloOfertas.fnAgregarPrecio(False)
                        ElseIf bitIndicadores Then
                            frmDetallePendienteNuevo.fnAgregarPrecio(False)
                        ElseIf bitVentas Then
                            If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                                formSalida.fnAgregarPrecio(True)
                                formSalida.fnActualizar_Total()

                            ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                                formVentaPequenia.fnAgregarPrecio(True)
                                formVentaPequenia.fnActualizar_Total()
                            End If
                        End If
                    Else
                        frmIngresaClave.Text = "Acceso Administrativo"
                        frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoDialogEspeciales(frmIngresaClave)
                        frmIngresaClave.Dispose()

                        If mdlPublicVars.fnAutorizaClave2(mdlPublicVars.superSearchClave, mdlPublicVars.supersearchUsuario) = True Then

                                Dim usua As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.superSearchIdUsuario Select x).FirstOrDefault

                                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdModelos)

                                Dim prec As Integer = Me.grdModelos.Rows(fila).Cells("codigo").Value

                                If prec = usua.tipoprecio Then

                                    If usua.bitAutorizaPrecios = False Then
                                        RadMessageBox.Show("No Tiene los Permisos Necesarios!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                        Exit Sub
                                    End If

                                    mdlPublicVars.superSearchPrecio = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("Precio").Value, Decimal)
                                    mdlPublicVars.superSearchCantidad = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("txmCantidad").Value, Integer)
                                    mdlPublicVars.superSearchTipoPrecio = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("codigo").Value, Integer)
                                    Me.Close()

                                    If bitPrincipal = True Then
                                        frmBuscarArticulo.fnAgregarPrecio(False)
                                    ElseIf bitSustitutos = True Then
                                        frmBuscarArticuloSustitutos.fnAgregarPrecio(False)
                                    ElseIf bitCatalogo = True Then
                                        frmBuscarArticuloCatalogo.fnAgregarPrecio(False)
                                    ElseIf bitNuevos = True Then
                                        frmBuscarArticuloProductosNuevos.fnAgregarPrecio(False)
                                    ElseIf bitSugerir = True Then
                                        frmBuscarArticuloSugeridos.fnAgregarPrecio(False)
                                    ElseIf bitPendientes = True Then
                                        frmBuscarArticuloPendienteSurtir.fnAgregarPrecio(False)
                                    ElseIf bitOfertas = True Then
                                        frmBuscarArticuloOfertas.fnAgregarPrecio(False)
                                    ElseIf bitIndicadores Then
                                        frmDetallePendienteNuevo.fnAgregarPrecio(False)
                                    ElseIf bitVentas Then
                                        If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                                            formSalida.fnAgregarPrecio(True)
                                            formSalida.fnActualizar_Total()

                                        ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                                            formVentaPequenia.fnAgregarPrecio(True)
                                            formVentaPequenia.fnActualizar_Total()
                                        End If
                                    End If

                                Else
                                    RadMessageBox.Show("No Tiene los Permisos Necesarios para Activar el Precio!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                                    Exit Sub
                                End If

                            End If
                        End If

                    Else
                        mdlPublicVars.superSearchPrecio = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("Precio").Value, Decimal)
                        mdlPublicVars.superSearchCantidad = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("txmCantidad").Value, Integer)
                        mdlPublicVars.superSearchTipoPrecio = CType(Me.grdModelos.Rows(Me.grdModelos.CurrentRow.Index).Cells("codigo").Value, Integer)
                        Me.Close()

                        If bitPrincipal = True Then
                            frmBuscarArticulo.fnAgregarPrecio(False)
                        ElseIf bitSustitutos = True Then
                            frmBuscarArticuloSustitutos.fnAgregarPrecio(False)
                        ElseIf bitCatalogo = True Then
                            frmBuscarArticuloCatalogo.fnAgregarPrecio(False)
                        ElseIf bitNuevos = True Then
                            frmBuscarArticuloProductosNuevos.fnAgregarPrecio(False)
                        ElseIf bitSugerir = True Then
                            frmBuscarArticuloSugeridos.fnAgregarPrecio(False)
                        ElseIf bitPendientes = True Then
                            frmBuscarArticuloPendienteSurtir.fnAgregarPrecio(False)
                        ElseIf bitOfertas = True Then
                            frmBuscarArticuloOfertas.fnAgregarPrecio(False)
                        ElseIf bitIndicadores Then
                            frmDetallePendienteNuevo.fnAgregarPrecio(False)
                        ElseIf bitVentas Then
                            If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                                formSalida.fnAgregarPrecio(True)
                                formSalida.fnActualizar_Total()

                            ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                                formVentaPequenia.fnAgregarPrecio(True)
                                formVentaPequenia.fnActualizar_Total()
                            End If
                        End If
                End If

                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdModelos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdModelos.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                fnAgregarPrecio()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnlAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        fnAgregarPrecio()
    End Sub

    'Funcion utilizada para llenar el grid de ultimas ventas de un producot
    Private Sub fnLlenarUltimas()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim lista = (From x In conexion.tblSalidaDetalles
                         Where x.tblSalida.anulado = False And x.tblSalida.empacado = True And x.idArticulo = codigo And x.tblSalida.idCliente = codClie _
                        Select Fecha = x.tblSalida.fechaRegistro, Documento = x.tblSalida.documento, Cantidad = x.cantidad, Precio = x.precio, TipoPrecio = (From tp In conexion.tblArticuloTipoPrecios Where x.tipoPrecio = tp.codigo Select tp.nombre).FirstOrDefault _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

                Me.grdUltimasVentas.DataSource = lista
                fnConfiguracion()

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdModelos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdModelos.CellEndEdit

        If e.Column.Name = "txmCantidad" Then
            fnActualizar_porcentaje()
            fnActualizarColores()
        End If
        If e.Column.Name = "Precio" Then
            fnCalculoPrecios()
        End If

    End Sub

    Private Sub grdModelos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdModelos.CellFormatting
        Try
            Try
                'Cambia el color de la fuente(letra) en el grid
                If Me.grdModelos.Rows.Count > 0 Then
                    If e.CellElement.RowInfo.Cells("clrEstado").Value = 1 Then
                        mdlPublicVars.GridColor_fila(e, Color.Red)

                    ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 5 Then
                        mdlPublicVars.GridColor_fila(e, Color.YellowGreen)

                    ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 4 Then
                        mdlPublicVars.GridColor_fila(e, Color.Green)

                    ElseIf e.CellElement.RowInfo.Cells("clrEstado").Value = 2 Then
                        mdlPublicVars.GridColor_fila(e, Color.Blue)
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'PRECIO ESPECIAL
    Private Sub fnPrecioEspecial() Handles Me.panel0
        Try
            'Obtenemos la informacion del usuario
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim userInfo As tblUsuario = (From x In conexion.tblUsuarios.AsEnumerable Where x.idUsuario = mdlPublicVars.idUsuario _
                                          Select x).FirstOrDefault


                If userInfo.superUsuario Then
                    frmIngresaClave.Text = "Ingrese clave"
                    frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoDialogEspeciales(frmIngresaClave)
                    frmIngresaClave.Dispose()

                    If mdlPublicVars.fnAutorizaClave(mdlPublicVars.superSearchClave) = True Then
                        'Obtenemos el costo del producto
                        Dim costo As Decimal = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = codigo _
                                                Select x.costoIVA).FirstOrDefault

                        frmEditaPrecio.Text = "Editar Precio"
                        frmEditaPrecio.bitCatalogo = Me.bitCatalogo
                        frmEditaPrecio.bitNuevos = Me.bitNuevos
                        frmEditaPrecio.bitPendientes = Me.bitPendientes
                        frmEditaPrecio.bitPrincipal = Me.bitPrincipal
                        frmEditaPrecio.bitSugerir = Me.bitSugerir
                        frmEditaPrecio.bitSustitutos = Me.bitSustitutos
                        frmEditaPrecio.bitVentas = Me.bitVentas
                        frmEditaPrecio.bitOfertas = Me.bitOfertas
                        frmEditaPrecio.bitIndicadores = Me.bitIndicadores
                        frmEditaPrecio.costo = costo

                        If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                            frmEditaPrecio.formSalida = Me.formSalida
                        ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                            frmEditaPrecio.formVentaPequenia = Me.formVentaPequenia
                        End If

                        frmEditaPrecio.StartPosition = FormStartPosition.CenterScreen
                        permiso.PermisoDialogEspeciales(frmEditaPrecio)
                        frmEditaPrecio.Dispose()
                        Me.Close()
                    Else
                        RadMessageBox.Show(Me, "Clave incorrecta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                    End If

                    'mdlPublicVars.superSearchId = ""
                Else
                    RadMessageBox.Show("No tiene permisos para esta opción", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End If

                conn.Close()
            End Using

        Catch ex As Exception
        End Try
    End Sub

    'ERRORRES
    Private Function fnErrores() As Boolean
        If grdModelos.RowCount = 0 Then
            Return False
        End If

        'Obtenemos la fila actual
        Dim fila As Integer = Me.grdModelos.CurrentRow.Index

        'Verificamos que la restriccion de cantidad minima este activada
        Dim bitCantidadMinima As Boolean = Me.grdModelos.Rows(fila).Cells("bitCantidadMinima").Value

        If bitCantidadMinima Then
            Dim cantidad As Integer = Me.grdModelos.Rows(fila).Cells("txmCantidad").Value
            Dim minima As Integer = Me.grdModelos.Rows(fila).Cells("cantidadMinima").Value
            'Verificamos que la existencia menos la cantidad que queremos vender sea mayor a la minima
            Dim resto As Integer = CInt(lblSaldo.Text) - cantidad

            If resto >= minima Then
                Return False
            Else
                alerta.contenido = "No se puede vender!! Restriccion de cantidad minima"
                alerta.fnErrorContenido()
                Return True
            End If
        End If

        Return False
    End Function

    'PRECIO ULTIMAS VENTAS
    Private Sub fnPrecioUltimasVentas()
        Try

            If Me.grdUltimasVentas.CurrentRow.Index >= 0 Then

                mdlPublicVars.superSearchPrecio = CType(Me.grdUltimasVentas.Rows(Me.grdUltimasVentas.CurrentRow.Index).Cells("Precio").Value, Decimal)

                mdlPublicVars.superSearchTipoPrecio = mdlPublicVars.Empresa_PrecioUltimasVentas

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
                    'ElseIf bitLiquidacion = True Then
                    '    frmBuscarArticulo.fnAgregarPrecioLiquidacion()
                ElseIf bitVentas Then

                    If mdlPublicVars.PuntoVentaPequeno_Activado = False Then
                        formSalida.fnAgregarPrecio(True)
                        formSalida.fnActualizar_Total()

                    ElseIf mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                        formVentaPequenia.fnAgregarPrecio(True)
                        formVentaPequenia.fnActualizar_Total()

                    End If

                End If
                Me.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnPrecioU_Click(sender As Object, e As EventArgs) Handles btnPrecioU.Click

        'crear la conexion
        Dim conexion As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            Try
                Dim usuario As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                If usuario.bitUltimasVentas = True Then

                    fnPrecioUltimasVentas()
                Else
                    RadMessageBox.Show("No Tiene Privilegios Para Asignar Este Precio", mdlPublicVars.nombreSistema)

                End If

            Catch ex As System.Data.EntityException

            Catch ex As Exception

                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
            conn.Close()
        End Using

    End Sub

    Private Sub fnCalculoPrecios()

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdModelos)

        Dim minimo As Double
        Dim maximo As Double
        Dim precio As Double

        minimo = Me.grdModelos.Rows(fila).Cells("Minimo").Value
        maximo = Me.grdModelos.Rows(fila).Cells("Maximo").Value
        precio = Me.grdModelos.Rows(fila).Cells("Precio").Value

        If precio < minimo Then
            RadMessageBox.Show("El Precio es Menor al Minimo", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Sub
        ElseIf precio > maximo Then
            RadMessageBox.Show("El Precio es Mayor al Maximo", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Sub
        End If

    End Sub

End Class
