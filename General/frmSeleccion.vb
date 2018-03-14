Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports System.Linq
Imports System.Windows.Forms

Public Class frmSeleccion

    Private _bitunidamedida As Boolean
    Private _bitProduccion As Boolean
    Private _bitMovimientoInventario As Boolean
    Private _bitVenta As Boolean
    Private _codigo As Integer

    Public Property bitunidadmedida() As Boolean
        Get
            bitunidadmedida = _bitunidamedida
        End Get
        Set(value As Boolean)
            _bitunidamedida = value
        End Set
    End Property

    Public Property bitProduccion() As Boolean
        Get
            bitProduccion = _bitProduccion
        End Get
        Set(value As Boolean)
            _bitProduccion = value
        End Set
    End Property

    Public Property bitMovimientoInventario As Boolean
        Get
            bitMovimientoInventario = _bitMovimientoInventario
        End Get
        Set(value As Boolean)
            _bitMovimientoInventario = value
        End Set
    End Property



    Public Property bitVenta() As Boolean
        Get
            bitVenta = _bitVenta
        End Get
        Set(value As Boolean)
            _bitVenta = value
        End Set
    End Property

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmSeleccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        mdlPublicVars.fnFormulario_quitaBarraTitulo(Me)
        fnLlenarArticulos()
    End Sub

    Private Sub fnLlenarArticulos()
        If bitunidadmedida = True Then

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim detalle

                If bitProduccion Then
                    detalle = (From x In conexion.tblArticulo_UnidadMedida, y In conexion.tblUnidadMedidas Where x.idUnidadMedida = y.idunidadMedida And x.idArticulo = codigo Select Id = x.idUnidadMedida, UnidadMedida = y.nombre, Valor = x.valor, Costo = (x.tblArticulo.costoIVA * x.valor))
                ElseIf bitVenta = True Then
                    detalle = (From x In conexion.tblArticulo_UnidadMedida, y In conexion.tblUnidadMedidas Where x.idUnidadMedida = y.idunidadMedida And x.idArticulo = codigo Select Id = x.idUnidadMedida, UnidadMedida = y.nombre, Valor = x.valor, Precio = x.precio)
                ElseIf bitMovimientoInventario = True Then
                    detalle = (From x In conexion.tblArticulo_UnidadMedida, y In conexion.tblUnidadMedidas Where x.idUnidadMedida = y.idunidadMedida And x.idArticulo = codigo Select Id = x.idUnidadMedida, UnidadMedida = y.nombre, Valor = x.valor, Costo = (x.tblArticulo.costoIVA * x.valor))
                End If


                Me.grdDatos.DataSource = mdlPublicVars.EntitiToDataTable(detalle)

                conn.Close()
            End Using

        End If
    End Sub

    Private Sub fnconfiguracion()
        Me.grdDatos.Columns("Id").IsVisible = True
        Me.grdDatos.Columns("UnidadMedida").IsVisible = True
        Me.grdDatos.Columns("Valor").IsVisible = True
        If bitProduccion Then
            Me.grdDatos.Columns("Costo").IsVisible = True
        ElseIf bitVenta = True Then
            Me.grdDatos.Columns("Precio").IsVisible = True
        End If

        Me.grdDatos.Columns("Id").Width = 50
        Me.grdDatos.Columns("UnidadMedida").Width = 100
        Me.grdDatos.Columns("Valor").Width = 75
        If bitProduccion Then
            Me.grdDatos.Columns("Costo").Width = 75
        ElseIf bitVenta = True Then
            Me.grdDatos.Columns("Precio").Width = 75
        End If
    End Sub

    Private Sub fnAgregar()
        Dim idunidad As Integer
        Dim unidad As String
        Dim valor As Decimal
        Dim costo As Decimal
        Dim precio As Decimal
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)

        idunidad = Me.grdDatos.Rows(fila).Cells("Id").Value
        unidad = Me.grdDatos.Rows(fila).Cells("UnidadMedida").Value
        valor = Me.grdDatos.Rows(fila).Cells("Valor").Value
        If bitVenta Then
            precio = Me.grdDatos.Rows(fila).Cells("Precio").Value
        ElseIf bitProduccion = True Then
            costo = Me.grdDatos.Rows(fila).Cells("Costo").Value
        ElseIf bitMovimientoInventario = True Then
            costo = Me.grdDatos.Rows(fila).Cells("Costo").Value
        End If

        mdlPublicVars.superSearchIdUnidadMedida = idunidad
        mdlPublicVars.superSearchUnidadMedida = unidad
        mdlPublicVars.superSearchUnidadMedidaValor = valor
        If bitProduccion Then
            mdlPublicVars.superSearchCosto = Format(costo, formatoNumero)
        ElseIf bitVenta = True Then
            mdlPublicVars.superSearchPrecio = Format(precio, formatoNumero)
        ElseIf bitMovimientoInventario = True Then
            mdlPublicVars.superSearchCosto = Format(costo, formatoNumero)
        End If

        Me.Close()
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        fnAgregar()
    End Sub

    Private Sub grdDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            fnAgregar()
        End If
    End Sub
End Class
