Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

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

    Private permiso As New clsPermisoUsuario

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
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

    Public Property precioNormal() As Decimal
        Get
            precioNormal = _precioNormal
        End Get
        Set(ByVal value As Decimal)
            _precioNormal = value
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
        Try
            Me.grdModelos.Rows.Clear()
            'Obtenemos el articulo
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault
            lblArticulo.Text = articulo.nombre1
            lblCodigo.Text = articulo.codigo1

            Dim inv As tblInventario = (From x In ctx.tblInventarios.AsEnumerable Where x.idArticulo = codigo Select x).First
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

            Dim pPublico = ctx.sp_Articulo_PrecioPublico(codigo, codClie)
            Dim item
            For Each item In pPublico
                lblPrecioNormal.Text = Format(item.PrecioPublico, mdlPublicVars.formatoMoneda)
            Next


            fnLlenarGrid()
            fnLlenarUltimas()
            fnConfiguracion()
            fnEstadisticas()
        Catch ex As Exception

        End Try
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
            Dim datos = ctx.sp_articulo_precios(codigo, mdlPublicVars.General_idTipoInventario, General_idAlmacenPrincipal, codClie)
            Me.grdModelos.DataSource = datos
            mdlPublicVars.fnGrid_iconos(grdModelos)
            fnConfiguracion()
            fnActualizar_porcentaje()
            fnActualizarColores()
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
        Try
            grdModelos.DataSource = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnAgregarPrecio()
        Try
            If Me.grdModelos.CurrentRow.Index >= 0 Then

                If fnErrores() = True Then
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
                End If

            End If
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


            Dim lista = (From x In ctx.tblSalidaDetalles Where x.tblSalida.anulado = False And x.tblSalida.empacado = True And x.idArticulo = codigo And x.tblSalida.idCliente = codClie _
                        Select Fecha = x.tblSalida.fechaRegistro, Documento = x.tblSalida.documento, Cantidad = x.cantidad, Precio = x.precio, TipoPrecio = (From tp In ctx.tblArticuloTipoPrecios Where x.tipoPrecio = tp.codigo Select tp.nombre).FirstOrDefault _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

            Me.grdUltimasVentas.DataSource = lista
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdModelos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdModelos.CellEndEdit
        If e.Column.Name = "txmCantidad" Then
            fnActualizar_porcentaje()
            fnActualizarColores()
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
            frmIngresaClave.Text = "Ingrese clave"
            frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmIngresaClave)
            frmIngresaClave.Dispose()
            If mdlPublicVars.fnAutorizaClave(mdlPublicVars.superSearchClave) = True Then
                'Obtenemos el costo del producto
                Dim costo As Decimal = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = codigo _
                                        Select x.costoIVA).FirstOrDefault

                frmEditaPrecio.Text = "Editar Precio"
                frmEditaPrecio.bitCatalogo = Me.bitCatalogo
                frmEditaPrecio.bitNuevos = Me.bitNuevos
                frmEditaPrecio.bitPendientes = Me.bitPendientes
                frmEditaPrecio.bitPrincipal = Me.bitPrincipal
                frmEditaPrecio.bitSugerir = Me.bitSugerir
                frmEditaPrecio.bitSustitutos = Me.bitSustitutos
                frmEditaPrecio.costo = costo
                frmEditaPrecio.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmEditaPrecio)
                frmEditaPrecio.Dispose()
                Me.Close()
            Else
                RadMessageBox.Show(Me, "Clave incorrecta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
            mdlPublicVars.superSearchId = ""
        Catch ex As Exception
        End Try
    End Sub

    'ERRORRES
    Private Function fnErrores() As Boolean
        'Obtenemos la fila actual
        Dim fila As Integer = Me.grdUltimasVentas.CurrentRow.Index

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
End Class
