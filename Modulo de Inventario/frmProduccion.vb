﻿''Option Strict On

Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient
Imports System.Windows.Forms
Imports System.Linq
Imports System.Transactions

Public Class frmProduccion
    Public bitModificar As Boolean = False
    Dim permiso As New clsPermisoUsuario
    Dim idinventario As Integer

    Private Sub frmProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdEntrada)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdSalida)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdEntrada)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdSalida)
        mdlPublicVars.fnGrid_iconos(Me.grdSalida)
        mdlPublicVars.fnGrid_iconos(Me.grdEntrada)
        Me.grdSalida.AllowDeleteRow = False

        fnNuevaFilaEntrada()
        fnNuevafilaSalida()
        fnLlenarCombo()
        fnEstablecerCorrelativo()
        lblUsuario.Text = mdlPublicVars.usuario
        fnConfiguracionSalida()
        fnConfiguracionEntrada()
    End Sub

    Private Sub fnEstablecerCorrelativo()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            'Buscamos el correlativo en la tabla correlativo...
            Dim Correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos _
                                  Where x.idTipoMovimiento = mdlPublicVars.Produccion_CodigoMovimiento And x.idEmpresa = mdlPublicVars.idEmpresa _
                                  Select x).First
            Me.lblCorrelativo.Text = CStr(Correlativo.correlativo + 1)
            conn.Close()
        End Using

    End Sub

    Public Sub fnNuevaFilaEntrada()
        eliminaVaciasEntrada()
        Me.grdEntrada.Rows.AddNew()    
    End Sub

    Public Sub fnNuevaFilaSalida()
        eliminaVaciasSalida()
        Me.grdSalida.Rows.AddNew()
    End Sub

    Public Sub eliminaVaciasSalida()
        Try

            Dim i
            Dim nombre As String = ""
            For i = 0 To Me.grdSalida.Rows.Count - 1
                'Obtenemo el valor del nombre
                nombre = Me.grdSalida.Rows(i).Cells("txbProducto").Value

                If IsNothing(nombre) Then
                    Me.grdSalida.Rows.RemoveAt(i)
                End If
            Next

            Dim a
            Dim nombres As String = ""
            For a = 0 To Me.grdSalida.Rows.Count - 1
                'Obtenemos el valor del nombre
                nombres = Me.grdSalida.Rows(a).Cells("txbProducto").Value

                If IsNothing(nombres) Then
                    Me.grdSalida.Rows.RemoveAt(a)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub eliminaVaciasEntrada()
        Try

            Dim i
            Dim nombre As String = ""
            For i = 0 To Me.grdEntrada.Rows.Count - 1
                'Obtenemo el valor del nombre
                nombre = Me.grdEntrada.Rows(i).Cells("txbProducto").Value

                If IsNothing(nombre) Then
                    Me.grdEntrada.Rows.RemoveAt(i)
                End If
            Next

            Dim a
            Dim nombres As String = ""
            For a = 0 To Me.grdEntrada.Rows.Count - 1
                'Obtenemos el valor del nombre
                nombres = Me.grdEntrada.Rows(a).Cells("txbProducto").Value

                If IsNothing(nombres) Then
                    Me.grdEntrada.Rows.RemoveAt(a)
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombo()

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim inventarioentrada = (From y In conexion.tblTipoInventarios Select idInventario = 0, Nombre = "< Seleccione un Inventario >").Union(From y In conexion.tblTipoInventarios Select idInventario = y.idTipoinventario, Nombre = y.nombre)

            With cmbInventarioEntrada
                .DataSource = Nothing
                .ValueMember = "idInventario"
                .DisplayMember = "Nombre"
                .DataSource = inventarioentrada
            End With

            Dim bodegaentrada = (From y In conexion.tblAlmacens Select idAlmacen = 0, Nombre = "< Seleccione una Bodega >").Union(From y In conexion.tblAlmacens Select idAlmacen = y.codigo, Nombre = y.nombre)

            With cmbBodegaEntrada
                .DataSource = Nothing
                .ValueMember = "idAlmacen"
                .DisplayMember = "Nombre"
                .DataSource = bodegaentrada
            End With

            Dim inventariosalida = (From y In conexion.tblInventarios Select idinventario = 0, nombre = "< Seleccione un Inventario >").Union(From y In conexion.tblTipoInventarios Select idinventario = y.idTipoinventario, nombre = y.nombre)

            With cmbInventarioSalida
                .DataSource = Nothing
                .ValueMember = "idinventario"
                .DisplayMember = "nombre"
                .DataSource = inventariosalida
            End With

            Dim bodegasalida = (From y In conexion.tblAlmacens Select idalmacen = 0, nombre = "< Seleccione una Bodega >").Union(From y In conexion.tblAlmacens Select idalmacen = y.codigo, nombre = y.nombre)

            With cmbBodegaSalida
                .DataSource = Nothing
                .ValueMember = "idalmacen"
                .DisplayMember = "nombre"
                .DataSource = bodegasalida
            End With

            Dim conceptosalida = (From y In conexion.tblTipoMovimientoes Where y.produccion = True And y.disminuyeInventario = True And y.aumentaInventario = False Select idconcepto = y.idTipoMovimiento, nombre = y.nombre)

            With cmbConceptoSalida
                .DataSource = Nothing
                .ValueMember = "idconcepto"
                .DisplayMember = "nombre"
                .DataSource = conceptosalida
            End With

            Dim conceptoentrada = (From y In conexion.tblTipoMovimientoes Where y.produccion = True And y.aumentaInventario = True And y.disminuyeInventario = False Select idconcepto = y.idTipoMovimiento, nombre = y.nombre)

            With cmbConceptoEntrada
                .DataSource = Nothing
                .ValueMember = "idconcepto"
                .DisplayMember = "nombre"
                .DataSource = conceptoentrada
            End With

            conn.Close()
        End Using

    End Sub

    Private Sub grdEntrada_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles grdEntrada.CellEndEdit
        Dim fila As Integer = Me.grdSalida.CurrentRow.Index
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        If e.Column.Name = "txmcodigo" Then
            Dim codigo As String = e.Value

            If codigo IsNot Nothing Then
                If codigo.Length > 0 Then
                    fnBuscarArticulo(codigo, e.RowIndex, True)
                End If
            End If
        End If
        If e.Column.Name = "txmCantidad" Then
            fnCostoTerminado()
        End If

        grdSalida.CloseEditor()
        grdSalida.CancelEdit()
        grdSalida.EditorManager.CloseEditor()
        grdSalida.EditorManager.CancelEdit()
    End Sub

    Private Sub grdEntrada_Click(sender As Object, e As EventArgs) Handles grdEntrada.Click
        If Me.cmbInventarioEntrada.SelectedValue = 0 Then
            RadMessageBox.Show("Seleccione un Inventario de Entrada", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.cmbInventarioEntrada.Focus()
        ElseIf Me.cmbBodegaEntrada.SelectedValue = 0 Then
            RadMessageBox.Show("Seleccione una Bodega de Entrada", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.cmbBodegaEntrada.Focus()
        End If
    End Sub

    Private Sub fnConcepto()
       'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            ''If rbtAjuste.Checked = True Then
            ''    consulta = (From x In conexion.tblTipoMovimientoes Where x.ajuste And Not x.ajusteVenta Select codigo = x.idTipoMovimiento, nombre = x.nombre)
            ''Else
            ''    consulta = (From x In conexion.tblTipoMovimientoes Where x.traslado And Not x.ajusteVenta Select codigo = x.idTipoMovimiento, nombre = x.nombre)
            ''End If

            Dim articulo As Integer
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdSalida)

            articulo = Me.grdSalida.Rows(fila).Cells("id").Value

            Dim lista As tblArticulo_UnidadMedida = (From x In conexion.tblArticulo_UnidadMedida Where x.idArticulo = articulo Select x).FirstOrDefault

            If lista Is Nothing Then
                RadMessageBox.Show("El Producto no es Unidad de Medida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                frmSeleccion.Text = "Buscar Cliente"
                frmSeleccion.bitunidadmedida = True
                frmSeleccion.codigo = articulo
                frmSeleccion.bitProduccion = True
                frmSeleccion.bitVenta = False
                frmSeleccion.StartPosition = FormStartPosition.CenterScreen
                frmSeleccion.ShowDialog()
                frmSeleccion.Dispose()

                If mdlPublicVars.superSearchIdUnidadMedida > 0 Then
                    Me.grdSalida.Rows(fila).Cells("idunidadmedida").Value = mdlPublicVars.superSearchIdUnidadMedida
                    Me.grdSalida.Rows(fila).Cells("txbunidadmedida").Value = mdlPublicVars.superSearchUnidadMedida
                    Me.grdSalida.Rows(fila).Cells("valor").Value = mdlPublicVars.superSearchUnidadMedidaValor
                    Me.grdSalida.Rows(fila).Cells("costo").Value = CType(mdlPublicVars.superSearchCosto, Decimal)
                End If
            End If
            
            conn.Close()
        End Using



    End Sub

    Private Sub grdSalida_Click(sender As Object, e As EventArgs) Handles grdSalida.Click
        If Me.cmbInventarioSalida.SelectedValue = 0 Then
            RadMessageBox.Show("Seleccione un Inventario de Salida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.cmbInventarioSalida.Focus()
        ElseIf Me.cmbBodegaSalida.SelectedValue = 0 Then
            RadMessageBox.Show("Seleccione una Bodega de Salida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.cmbBodegaSalida.Focus()
        End If
    End Sub

    Private Sub grdEntrada_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdEntrada.KeyDown

        If e.KeyCode = Keys.Delete Then
            If RadMessageBox.Show("¿Desea Eliminar el Producto de la Lista?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdEntrada, "iddetalle")
                ''RadMessageBox.Show("Se ah eliminado el Producto!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                RadMessageBox.Show("El Registro no se ah Eliminado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        End If

        If e.KeyCode = Keys.F2 And verRegistro = False Then

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdEntrada)

            If Me.grdEntrada.Rows(fila).Cells("txbProducto").Value Is Nothing Then
                mdlPublicVars.superSearchNombre = ""
            Else
                mdlPublicVars.superSearchNombre = LTrim(RTrim(Me.grdEntrada.Rows(fila).Cells("txbProducto").Value))
            End If
            frmBuscarArticulo2.OpcionRetorno = "movimientoInventario"
            frmBuscarArticulo2.Text = "Buscar Articulos"
            frmBuscarArticulo2.bitMovimientoInventario = True
            frmBuscarArticulo2.bitProduccionEntrada = True
            frmBuscarArticulo2.idTipoInventario = mdlPublicVars.General_idTipoInventario
            frmBuscarArticulo2.idBodega = mdlPublicVars.General_idAlmacenPrincipal
            frmBuscarArticulo2.bitProduccion = True
            frmBuscarArticulo2.venta = 0
            permiso.PermisoFrmEspeciales(frmBuscarArticulo2, False)

        End If
        fnActualizar_Total()

    End Sub

    Private Sub grdSalida_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSalida.KeyDown

        If e.KeyCode = Keys.Delete Then
            If RadMessageBox.Show("¿Desea Eliminar el Producto de la Lista?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                mdlPublicVars.fnGrid_EliminarFila(sender, e, grdSalida, "iddetalle")
                ''RadMessageBox.Show("Se ah eliminado el Producto!!!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Else
                RadMessageBox.Show("El Registro no se ah Eliminado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        End If


        If e.KeyCode = Keys.F2 And verRegistro = False Then
            If Me.grdSalida.Columns("txbunidadmedida").IsCurrent Then
                mdlPublicVars.superSearchId = 0
                mdlPublicVars.superSearchNombre = ""
                fnConcepto()
                fnActualizar_Total()
                ''If e.KeyCode = Keys.F2 Then
            Else
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdSalida)

                If Me.grdSalida.Rows(fila).Cells("txbProducto").Value Is Nothing Then
                    mdlPublicVars.superSearchNombre = ""
                Else
                    mdlPublicVars.superSearchNombre = LTrim(RTrim(Me.grdSalida.Rows(fila).Cells("txbProducto").Value))
                End If
                frmBuscarArticulo2.OpcionRetorno = "movimientoInventario"
                frmBuscarArticulo2.Text = "Buscar Articulos"
                frmBuscarArticulo2.bitMovimientoInventario = True
                frmBuscarArticulo2.bitProduccionSalida = True
                frmBuscarArticulo2.idTipoInventario = Me.cmbInventarioSalida.SelectedValue
                frmBuscarArticulo2.idBodega = Me.cmbBodegaSalida.SelectedValue
                frmBuscarArticulo2.bitProduccion = True
                frmBuscarArticulo2.venta = 0
                permiso.PermisoFrmEspeciales(frmBuscarArticulo2, False)

            End If
        End If
        fnActualizar_Total()

    End Sub

    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    Public Sub fnAgregar_ArticulosSalida()

        Dim filas() As String

        filas = {0, mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchIdUnidadMedida, mdlPublicVars.superSearchUnidadMedida, mdlPublicVars.superSearchUnidadMedidaValor, mdlPublicVars.superSearchCantidad, Format(mdlPublicVars.superSearchPrecio, formatoNumero), Format((mdlPublicVars.superSearchCantidad * mdlPublicVars.superSearchPrecio), mdlPublicVars.formatoNumero), "0"}

        grdSalida.Rows.Add(filas)
        grdSalida.Columns(6).IsCurrent = True
        grdSalida.Rows(grdSalida.Rows.Count - 1).IsCurrent = True
        fnActualizar_Total()

    End Sub

    Public Sub fnAgregar_ArticulosEntrada()

        Dim filas() As String

        filas = {0, mdlPublicVars.superSearchId, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre, mdlPublicVars.superSearchCantidad, Me.dspTotal.DigitText, Format((mdlPublicVars.superSearchCantidad * Me.dspTotal.DigitText), formatoNumero), "0"}
        grdEntrada.Rows.Add(filas)
        grdEntrada.Columns(6).IsCurrent = True
        grdEntrada.Rows(grdEntrada.Rows.Count - 1).IsCurrent = True
    End Sub

    Public Sub fnRemoverFilaSalida()
        If Me.grdSalida.CurrentRow.Index = -1 Then
            Exit Sub
        End If

        Dim filaActual As Integer = CType(Me.grdSalida.CurrentRow.Index, Integer)

        If filaActual >= 0 Then
            Dim index
            Dim yaBorro As Boolean = False

            For index = filaActual To Me.grdSalida.Rows.Count - 1
                Dim codigoArt As Integer = CType(Me.grdSalida.Rows(filaActual).Cells("Id").Value, Integer)
                If Not yaBorro Then
                    'Si borrar es igual a false, elimina la fila
                    Me.grdSalida.Rows.RemoveAt(filaActual)
                    yaBorro = True
                Else
                    'Si estamos es una fila que no tiene datos la eliminamos
                    If codigoArt = 0 Then
                        Me.grdSalida.Rows.RemoveAt(filaActual)
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub fnRemoverFilaEntrada()
        If Me.grdEntrada.CurrentRow.Index = -1 Then
            Exit Sub
        End If

        Dim filaActual As Integer = CType(Me.grdEntrada.CurrentRow.Index, Integer)

        If filaActual >= 0 Then
            Dim index
            Dim yaBorro As Boolean = False

            For index = filaActual To Me.grdEntrada.Rows.Count - 1
                Dim codigoArt As Integer = CType(Me.grdEntrada.Rows(filaActual).Cells("Id").Value, Integer)
                If Not yaBorro Then
                    'Si borrar es igual a false, elimina la fila
                    Me.grdEntrada.Rows.RemoveAt(filaActual)
                    yaBorro = True
                Else
                    'Si estamos es una fila que no tiene datos la eliminamos
                    If codigoArt = 0 Then
                        Me.grdEntrada.Rows.RemoveAt(filaActual)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub fnCostoTerminado()
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdEntrada)

        If Me.grdEntrada.Rows(fila).Cells("total").Value > 0 Then
            If Me.grdEntrada.Rows.Count > 0 Then
                Dim total As Decimal = 0
                Dim cantidad As Decimal = 0
                Dim nuevoCosto As Decimal = 0

                cantidad = Me.grdEntrada.Rows(fila).Cells("txmCantidad").Value
                total = Me.grdEntrada.Rows(fila).Cells("total").Value

                If cantidad > 1 Then
                    nuevoCosto = total / cantidad
                    Me.grdEntrada.Rows(fila).Cells("costo").Value = Format(nuevoCosto, formatoNumero)
                Else
                    Me.grdEntrada.Rows(fila).Cells("costo").Value = Me.grdEntrada.Rows(fila).Cells("total").Value
                End If

            End If
        Else
            If Me.grdSalida.Rows.Count > 0 Then
                fnActualizar_Total()
            End If
        End If
    End Sub

    Private Sub fnActualizar_Total()
        Dim index

        Try
            If Me.grdSalida.Rows.Count > 0 Then
                Dim suma As Decimal = 0

                Dim cantidad As Double = 0
                Dim costo As Decimal = 0
                Dim total As Decimal = 0
                Dim nombre As String = ""
                Dim numeroProductos As Integer = 0
                Dim totalVenta As Double = 0
                Dim recuento As Integer

                recuento = Me.grdSalida.Rows.Count
                lblRecuento.Text = recuento

                For index = 0 To Me.grdSalida.Rows.Count - 1
                    cantidad = CType(Me.grdSalida.Rows(index).Cells("txmCantidad").Value, Double)
                    nombre = CType(Me.grdSalida.Rows(index).Cells("txbProducto").Value, String)

                    If nombre IsNot Nothing Then
                        costo = CType(Replace(Me.grdSalida.Rows(index).Cells("costo").Value, "Q", ""), Decimal)

                        If (cantidad * costo) = 0 Then
                            Me.grdSalida.Rows(index).Cells("total").Value = "0"
                            total = 0

                        Else
                            If Me.grdSalida.Rows(index).IsVisible Then
                                Me.grdSalida.Rows(index).Cells("total").Value = Format(cantidad * costo, mdlPublicVars.formatoMoneda).ToString

                                totalVenta += cantidad * costo

                            End If
                        End If

                    End If
                Next

                If totalVenta = 0 Then
                    dspTotal.Text = Format(0, mdlPublicVars.formatoMoneda)
                Else
                    dspTotal.DigitText = Format(totalVenta, mdlPublicVars.formatoNumero)
                End If

                If Me.grdEntrada.Rows.Count > 0 Then

                    Dim totalterminado As Decimal = 0

                    Me.grdEntrada.Rows(0).Cells(5).Value = Me.dspTotal.DigitText

                    totalterminado = Me.grdEntrada.Rows(0).Cells(5).Value * Me.grdEntrada.Rows(0).Cells(4).Value

                    Me.grdEntrada.Rows(0).Cells(6).Value = Format(totalterminado, formatoNumero)

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    '' ''TOTAL GRID
    ''Public Sub fnActualizar_Total()
    ''    Dim filas As Integer = 0
    ''    If bitModificar = True Then
    ''        For index As Integer = 0 To Me.grdSalida.Rows.Count - 1
    ''            Dim elimina As Integer = CType(Me.grdSalida.Rows(index).Cells("elimina").Value, Integer)
    ''            If elimina = 0 Then
    ''                filas += 1
    ''            End If
    ''        Next
    ''    Else
    ''        filas = Me.grdSalida.Rows.Count
    ''    End If

    ''    lblRecuento.Text = filas

    ''    'conexion nueva.
    ''    Dim conexion As New dsi_pos_demoEntities

    ''    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    ''        conn.Open()
    ''        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

    ''        Try
    ''            If Me.grdSalida.Rows.Count > 0 Then

    ''                Dim suma As Double = 0

    ''                Dim tipoMovimiento As Integer = 0

    ''                Dim cantidad As Double = 0
    ''                Dim costo As Double = 0
    ''                Dim total As Double = 0
    ''                Dim elimina As Integer = 0
    ''                Dim valor As Double = 0
    ''                For index As Integer = 0 To Me.grdSalida.Rows.Count - 1
    ''                    elimina = CType(Me.grdSalida.Rows(index).Cells("elimina").Value, Integer)
    ''                    cantidad = CType(Me.grdSalida.Rows(index).Cells("txmCantidad").Value, Double)
    ''                    costo = CType(Me.grdSalida.Rows(index).Cells("costo").Value, Double)
    ''                    valor = CType(Me.grdSalida.Rows(index).Cells("valor").Value, Double)

    ''                    If elimina = 0 Then
    ''                        'Vemos si el tipo movimiento es de aumento o de disminucion
    ''                        Dim tipoMov As tblTipoMovimiento = (From x In conexion.tblTipoMovimientoes.AsEnumerable Where x.idTipoMovimiento = tipoMovimiento Select x).FirstOrDefault

    ''                        Me.grdSalida.Rows(index).Cells("Total").Value = Format(valor * cantidad * costo, mdlPublicVars.formatoMoneda).ToString
    ''                        total += CType(Me.grdSalida.Rows(index).Cells("Total").Value, Double)

    ''                    End If
    ''                Next

    ''                dspTotal.DigitText = Format(total, mdlPublicVars.formatoNumero)

    ''                If total = 0 Then
    ''                    dspTotal.Text = Format(0, mdlPublicVars.formatoMoneda)
    ''                End If

    ''                If Me.grdEntrada.Rows.Count - 1 > 0 Then

    ''                    Dim totalterminado As Decimal = 0

    ''                    Me.grdEntrada.Rows(0).Cells(5).Value = Me.dspTotal.DigitText

    ''                    totalterminado = Me.grdEntrada.Rows(0).Cells(5).Value * Me.grdEntrada.Rows(0).Cells(4).Value

    ''                    Me.grdEntrada.Rows(0).Cells(6).Value = Format(totalterminado, formatoNumero)

    ''                End If

    ''            End If
    ''        Catch ex As Exception
    ''        End Try

    ''        conn.Close()
    ''    End Using

    ''End Sub

    Private Sub grdSalida_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdSalida.CellEndEdit
        Dim fila As Integer = Me.grdSalida.CurrentRow.Index
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        If e.Column.Name = "txmcodigo" Then
            Dim codigo As String = e.Value

            If codigo IsNot Nothing Then
                If codigo.Length > 0 Then
                    fnBuscarArticulo(codigo, e.RowIndex, False)
                End If
            End If
        End If
        If e.Column.Name = "txmCantidad" Then
            fnActualizar_Total()
        End If

        grdSalida.CloseEditor()
        grdSalida.CancelEdit()
        grdSalida.EditorManager.CloseEditor()
        grdSalida.EditorManager.CancelEdit()
    End Sub

    Public Sub fnBuscarArticulo(ByVal codigo As String, ByVal posicion As Integer, ByVal gentrada As Boolean)
        Try
            'Buscamos el articulo en base al codigo
            Dim articulo As tblArticulo
            Dim unidad As tblArticulo_UnidadMedida
            Dim artunidad As tblUnidadMedida

            'conexion nueva.
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                articulo = (From x In conexion.tblArticuloes Where x.codigo1 = codigo And x.empresa = mdlPublicVars.idEmpresa _
                                              Select x).FirstOrDefault

                If gentrada = False Then
                    unidad = (From x In conexion.tblArticulo_UnidadMedida Where x.idArticulo = articulo.idArticulo And x.bitDefault = True Select x).FirstOrDefault

                    If unidad IsNot Nothing Then
                        artunidad = (From x In conexion.tblUnidadMedidas Where x.idunidadMedida = unidad.idUnidadMedida Select x).FirstOrDefault
                    End If
                End If

                conn.Close()
            End Using

            If articulo Is Nothing Then
                RadMessageBox.Show("Este producto no existe ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                If gentrada = False Then
                    Me.grdSalida.Rows(posicion).Cells("iddetalle").Value = "0"
                    Me.grdSalida.Rows(posicion).Cells("id").Value = articulo.idArticulo
                    Me.grdSalida.Rows(posicion).Cells("txmcodigo").Value = articulo.codigo1
                    Me.grdSalida.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                    Me.grdSalida.Rows(posicion).Cells("txmCantidad").Value = "0"
                    Me.grdSalida.Rows(posicion).Cells("costo").Value = Format(articulo.costoIVA, mdlPublicVars.formatoNumero)
                    Me.grdSalida.Rows(posicion).Cells("total").Value = 0
                    Me.grdSalida.Rows(posicion).Cells("elimina").Value = 0

                    If unidad IsNot Nothing Then
                        Me.grdSalida.Rows(posicion).Cells("idunidadmedida").Value = unidad.idUnidadMedida
                        Me.grdSalida.Rows(posicion).Cells("txbUniadMedida").Value = artunidad.nombre
                        Me.grdSalida.Rows(posicion).Cells("valor").Value = unidad.valor
                    Else
                        Me.grdSalida.Rows(posicion).Cells("idunidadmedida").Value = mdlPublicVars.UnidadMedidaDefault
                        Me.grdSalida.Rows(posicion).Cells("txbUnidadMedida").Value = "Unidad"
                        Me.grdSalida.Rows(posicion).Cells("valor").Value = 1
                    End If

                    Me.fnNuevaFilaSalida()

                Else
                    Me.grdEntrada.Rows(posicion).Cells("iddetalle").Value = "0"
                    Me.grdEntrada.Rows(posicion).Cells("id").Value = articulo.idArticulo
                    Me.grdEntrada.Rows(posicion).Cells("txmcodigo").Value = articulo.codigo1
                    Me.grdEntrada.Rows(posicion).Cells("txbProducto").Value = articulo.nombre1
                    Me.grdEntrada.Rows(posicion).Cells("txmCantidad").Value = "0"
                    Me.grdEntrada.Rows(posicion).Cells("costo").Value = Format(articulo.costoIVA, mdlPublicVars.formatoNumero)
                    Me.grdEntrada.Rows(posicion).Cells("total").Value = 0
                    Me.grdEntrada.Rows(posicion).Cells("elimina").Value = 0

                    Me.fnNuevaFilaEntrada()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSalida_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdSalida.UserDeletedRow
        Try
            If Me.grdSalida.Rows.Count = 0 Then
                Me.grdSalida.Rows.AddNew()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdEntrada_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdEntrada.UserDeletedRow
        Try
            If Me.grdEntrada.Rows.Count = 0 Then
                Me.grdEntrada.Rows.AddNew()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracionEntrada()
        Me.grdEntrada.Columns("iddetalle").IsVisible = False
        Me.grdEntrada.Columns("id").IsVisible = False
        Me.grdEntrada.Columns("txmcodigo").IsVisible = True
        Me.grdEntrada.Columns("txbProducto").IsVisible = True
        Me.grdEntrada.Columns("txmCantidad").IsVisible = True
        Me.grdEntrada.Columns("costo").IsVisible = True
        Me.grdEntrada.Columns("elimina").IsVisible = False

        ''Celdas Editables Entradas
        Me.grdEntrada.Columns("txmcodigo").ReadOnly = False
        Me.grdEntrada.Columns("txbProducto").ReadOnly = True
        Me.grdEntrada.Columns("txmCantidad").ReadOnly = False
        Me.grdEntrada.Columns("costo").ReadOnly = True
        Me.grdEntrada.Columns("total").ReadOnly = True
    End Sub

    Private Sub fnConfiguracionSalida()

        Me.grdSalida.Columns("iddetalle").IsVisible = False
        Me.grdSalida.Columns("id").IsVisible = False
        Me.grdSalida.Columns("txmcodigo").IsVisible = True
        Me.grdSalida.Columns("txbProducto").IsVisible = True
        Me.grdSalida.Columns("txmCantidad").IsVisible = True
        Me.grdSalida.Columns("costo").IsVisible = True
        ''Me.grdSalida.Columns("idtipoinventario").IsVisible = False
        ''Me.grdSalida.Columns("unidadmedida").IsVisible = True
        Me.grdSalida.Columns("total").IsVisible = True
        Me.grdSalida.Columns("elimina").IsVisible = False

        ''Celdas Editable Salidas
        Me.grdSalida.Columns("txmcodigo").ReadOnly = False
        Me.grdSalida.Columns("txbProducto").ReadOnly = True
        Me.grdSalida.Columns("txmCantidad").ReadOnly = False
        Me.grdSalida.Columns("costo").ReadOnly = True
        Me.grdSalida.Columns("total").ReadOnly = True
        Me.grdSalida.Columns("txbunidadmedida").ReadOnly = True

    End Sub

    Private Sub fnNuevo() Handles Me.panel0

        fnLlenarCombo()
        Me.grdSalida.Rows.Clear()
        Me.grdEntrada.Rows.Clear()
        fnNuevaFilaEntrada()
        fnNuevaFilaSalida()
        fnActualizar_Total()
        Me.dspTotal.DigitText = "0.00"
        Me.txtObservacion.Clear()

    End Sub

    Private Sub fnGuardarProduccion()
        Dim contador As Integer = 0
        Dim success As Boolean = True
        Dim bitErrorSistema As Boolean = False
        Dim msj As String = ""

        Dim inveSalida As Integer = CType(cmbInventarioSalida.SelectedValue, Integer)
        Dim inveEntrada As Integer = CType(cmbInventarioEntrada.SelectedValue, Integer)
        Dim bodegasalida As Integer = CType(cmbBodegaSalida.SelectedValue, Integer)
        Dim bodegaentrada As Integer = CType(cmbBodegaEntrada.SelectedValue, Integer)
        Dim idsalida As Integer = 0
        Dim identrada As Integer = 0
        Dim cantidadInsuficiente As Boolean = False
        Dim nombreArticuloInsuficiente As String = ""
        Dim cantidadRequerida As Integer = 0
        Dim existencia As Integer = 0
        Dim fechaSerividor As DateTime = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
        Dim hora As String = mdlPublicVars.fnHoraServidor
        Dim idcorrelativo As String = ""
        Dim idunidamedi As Integer

        ''Valores para determinar si es perteneciente a un kit, unidad medida o es producto

        ''Dim bitkit As Boolean = False
        ''Dim bitunidadmedida As Boolean = False
        ''Dim bitproducto As Boolean = False
        ''Dim bitservicio As Boolean = False

        ''Dim conection As dsi_pos_demoEntities
        ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
        ''    conn.Open()
        ''    conection = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

        ''    Dim detallekit = (From x In conection.tblArticulo_Kit, y In conection.tblArticuloes Where y.idArticulo = x.articulo And x.articuloBase = 

        ''    conn.Close()
        ''End Using

        ''If fnErrores() = True Then
        ''    Exit Sub
        ''End If

        If RadMessageBox.Show("¿Desea guardar el Registro?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Using transaction As New TransactionScope
                Try
                    Dim correlativo As tblCorrelativo = (From x In conexion.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Produccion_CodigoMovimiento _
                                                         Select x).FirstOrDefault

                    If correlativo IsNot Nothing Then
                        correlativo.correlativo += 1
                        conexion.SaveChanges()
                        idcorrelativo = correlativo.serie & correlativo.correlativo
                    Else
                        Dim correlativoNuevo As New tblCorrelativo
                        correlativoNuevo.correlativo = 1
                        correlativoNuevo.serie = ""
                        correlativoNuevo.inicio = 1
                        correlativoNuevo.fin = 1000
                        correlativoNuevo.porcentajeAviso = 20
                        correlativoNuevo.idEmpresa = mdlPublicVars.idEmpresa
                        correlativoNuevo.idTipoMovimiento = mdlPublicVars.Produccion_CodigoMovimiento
                        conexion.AddTotblCorrelativos(correlativoNuevo)
                        conexion.SaveChanges()

                        idcorrelativo = 1
                    End If

                    ''ENCABEZADO MOVIMIENTO-----------------------------------------------
                    Dim movimiento As New tblMovimientoInventario

                    movimiento.empresa = mdlPublicVars.idEmpresa
                    movimiento.usuario = mdlPublicVars.idUsuario
                    movimiento.almacen = Me.cmbBodegaSalida.SelectedValue
                    movimiento.bitBodega = False
                    movimiento.bitVenta = False
                    movimiento.tipoMovimiento = mdlPublicVars.Produccion_CodigoMovimiento
                    movimiento.correlativo = idcorrelativo
                    movimiento.revisado = False

                    movimiento.inventarioInicial = Me.cmbInventarioSalida.SelectedValue
                    movimiento.inventarioFinal = Me.cmbInventarioEntrada.SelectedValue
                    movimiento.traslado = 1
                    movimiento.ajuste = 0

                    movimiento.anulado = 0
                    movimiento.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                    movimiento.fechaTransaccion = fechaSerividor
                    movimiento.observacion = Me.txtObservacion.Text

                    conexion.AddTotblMovimientoInventarios(movimiento)
                    conexion.SaveChanges()

                    Dim codigomovimiento As Integer = movimiento.codigo
                    ''FIN DE ENCABEZADO--------------------------------------------------------------------

                    ''DETALLE DEL MOVIMIENTO-------------------------------------------------------------------
                    Dim index As Integer
                    For index = 0 To Me.grdSalida.Rows.Count - 1
                        contador = contador + 1

                        Dim articulof As Integer = CType(Me.grdSalida.Rows(index).Cells("id").Value, Integer)
                        Dim cantidadf As Integer = CType(Me.grdSalida.Rows(index).Cells("txmCantidad").Value, Integer)
                        Dim tipomovimiento As Integer = 0
                        idunidamedi = Me.grdSalida.Rows(index).Cells("idunidadmedida").Value

                        ''VERIFICACION DE QUE TIPO DE PRODUCTO ES KIT, UNIDAD MEDIDA, PRODUCTO, SERVICIO--------------------------------------

                        Dim bikit = (From x In conexion.tblArticuloes Where x.idArticulo = articulof Select x.bitKit).FirstOrDefault

                        Dim biunidadmedida = (From x In conexion.tblArticuloes Where x.idArticulo = articulof Select x.bitUnidadMedida).FirstOrDefault

                        Dim biproducto = (From x In conexion.tblArticuloes Where x.idArticulo = articulof Select x.bitProducto).FirstOrDefault


                        ''VERIFICAMOS SI ES KIT
                        If bikit Then

                            ''Dim detallekit As List(Of GridViewRowInfo) = Nothing

                            Dim detallekit = (From x In conexion.tblArticulo_Kit, y In conexion.tblArticuloes Where y.idArticulo = x.articulo And x.articuloBase = articulof
                                                Select codigo = x.articulo, cantidad = x.cantidad, cost = y.costoIVA,
                                                codigomedida = CType(If(x.idArticulo_UnidadMedida > 0, x.idArticulo_UnidadMedida, 0), String),
                                                idunidadmedida = CType(If(x.idArticulo_UnidadMedida > 0, (From z In conexion.tblArticulo_UnidadMedida Where x.idArticulo_UnidadMedida = z.idArticulo_UnidadMedida Select z.idUnidadMedida).FirstOrDefault, 1), String),
                                                valo = CType(If(x.idArticulo_UnidadMedida > 0, (From m In conexion.tblArticulo_UnidadMedida Where x.idArticulo_UnidadMedida = m.idArticulo_UnidadMedida Select m.valor).FirstOrDefault, 1), String))

                            Dim lkit As DataTable = mdlPublicVars.EntitiToDataTable(detallekit)
                            Dim val As String = 0

                            Dim idunidadmedid As String
                            Dim fila
                            For Each fila In lkit.Rows

                                If fila.item(4).ToString.Length > 0 Then
                                    idunidadmedid = "'" & fila.item(4) & "'"
                                Else
                                    idunidadmedid = "null"
                                End If

                                If fila.item(5).ToString.Length > 0 Then
                                    val = "'" & fila.item(5) & "'"
                                Else
                                    val = "null"
                                End If

                                Dim articulo As String

                                articulo = fila.item(0)

                                If val = "null" Then

                                    Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                              And x.IdAlmacen = bodegasalida And x.idTipoInventario = inveSalida Select x).FirstOrDefault
                                    If inve.saldo >= (fila.item(1) * fila.item(5)) Then
                                        inve.saldo -= CType((fila.item(1) * fila.item(5)), Decimal)
                                        inve.salida += CType((fila.item(1) * fila.item(5).Value), Decimal)
                                    End If

                                Else

                                    Dim inve As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                    And x.IdAlmacen = bodegasalida And x.idTipoInventario = inveSalida Select x).FirstOrDefault
                                    If inve.saldo >= (cantidadf * fila.item(1) * fila.item(5)) Then
                                        inve.saldo -= CType((fila.item(1) * cantidadf * fila.item(5)), Decimal)
                                        inve.salida += CType((fila.item(1) * cantidadf * fila.item(5)), Decimal)
                                    End If

                                End If
                                conexion.SaveChanges()
                            Next

                            ''VERIFICAMOS SI ES UNIDAD MEDIDA
                            ''ElseIf biunidadmedida = True Then

                            ''    Dim consulta = (From x In conexion.tblArticulo_UnidadMedida, y In conexion.tblArticuloes Where x.idArticulo = y.idArticulo And y.idArticulo = articulof And x.idUnidadMedida = idunidamedi Select resultado = CType(If(x.kit = True, 1, 0), String)).FirstOrDefault

                            ''    If CType(consulta, Integer) = 0 Then



                            ''    End If


                            End If

                        ''FIN DE LA VERIFICACION DE QUE TIPO DE PRODUCTO ES EL QUE SE ESTA DANDO DE BAJA--------------------------------------

                        Try
                            tipomovimiento = Me.cmbConceptoSalida.SelectedValue
                        Catch ex As Exception
                            tipomovimiento = 0
                        End Try

                        Dim costo As Double = CType(Me.grdSalida.Rows(index).Cells("costo").Value, Double)
                        Dim total As Double = CType(Me.grdSalida.Rows(index).Cells("total").Value, Double)
                        Dim nombre As String = CType(Me.grdSalida.Rows(index).Cells("txbProducto").Value, String)
                        Dim va As String = CType(Me.grdSalida.Rows(index).Cells("valor").Value, String)

                        If nombre IsNot Nothing Then
                            If tipomovimiento = 0 Then
                                bitErrorSistema = True
                                msj = "Debe agregar un Producto" & articulof
                                success = False
                                Exit Try
                            End If

                            Dim detalle As New tblMovimientoInventarioDetalle
                            detalle.movimientoInventario = codigomovimiento
                            detalle.articulo = articulof
                            detalle.cantidad = cantidadf * va
                            detalle.tipoMovimiento = tipomovimiento
                            detalle.costo = costo
                            detalle.total = total

                            ''Dim tipomov As tblTipoMovimiento = (From y In conexion.tblTipoMovimientoes Where y.idTipoMovimiento = tipomovimiento Select y).FirstOrDefault

                            detalle.salida = True
                            detalle.entrada = False

                            conexion.AddTotblMovimientoInventarioDetalles(detalle)
                            conexion.SaveChanges()

                            Dim inventario As tblInventario = (From y In conexion.tblInventarios Where y.idArticulo = articulof And y.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                And y.IdAlmacen = bodegasalida And y.idTipoInventario = inveSalida Select y).FirstOrDefault

                            ''Descuenta de Inventario
                            If inventario.saldo >= cantidadf * va Then
                                inventario.saldo -= cantidadf * va
                                inventario.salida += cantidadf * va
                                conexion.SaveChanges()
                            Else
                                cantidadInsuficiente = True
                                nombreArticuloInsuficiente = inventario.tblArticulo.nombre1
                                cantidadRequerida = cantidadf * va
                                existencia = inventario.saldo

                                success = False
                                bitErrorSistema = True
                                msj = "Existencia Insuficiente !!!" & vbCrLf & "Articulo : " & inventario.tblArticulo.nombre1 & vbCrLf & "Saldo : " & inventario.saldo _
                                & vbCrLf & "Cantidad Ajuste : " & cantidadf * va & vbCrLf & "Diferencia : " & (inventario.saldo - cantidadf)
                                Exit Try
                            End If
                            inventario.tblArticulo.fechaUltAjuste = fechaSerividor
                            conexion.SaveChanges()
                        End If
                    Next

                    ''Aumento del Inventario y Modificiacion del Detalle de la Produccion---------------------------------

                    Dim inde As Integer
                    For inde = 0 To Me.grdEntrada.Rows.Count - 1
                        contador = contador + 1

                        Dim articulo As Integer = CType(Me.grdEntrada.Rows(inde).Cells("id").Value, Integer)
                        Dim cantidad As Integer = CType(Me.grdEntrada.Rows(inde).Cells("txmCantidad").Value, Integer)
                        Dim tipomovimiento As Integer = 0
                        Try
                            tipomovimiento = Me.cmbConceptoEntrada.SelectedValue
                        Catch ex As Exception
                            tipomovimiento = 0
                        End Try

                        Dim costo As Double = CType(Me.grdEntrada.Rows(inde).Cells("costo").Value, Double)
                        Dim total As Double = CType(Me.grdEntrada.Rows(inde).Cells("total").Value, Double)
                        Dim nombre As String = CType(Me.grdEntrada.Rows(inde).Cells("txbProducto").Value, String)

                        If nombre IsNot Nothing Then
                            If tipomovimiento = 0 Then
                                bitErrorSistema = True
                                msj = "Debe agregar un Producto Terminado" & articulo
                                success = False
                                Exit Try
                            End If

                            Dim detalle As New tblMovimientoInventarioDetalle
                            detalle.movimientoInventario = codigomovimiento
                            detalle.articulo = articulo
                            detalle.cantidad = cantidad
                            detalle.tipoMovimiento = tipomovimiento
                            detalle.costo = costo
                            detalle.total = total

                            detalle.salida = False
                            detalle.entrada = True

                            conexion.AddTotblMovimientoInventarioDetalles(detalle)
                            conexion.SaveChanges()

                            Dim inventario As tblInventario = (From x In conexion.tblInventarios Where x.idArticulo = articulo And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                                                                And x.IdAlmacen = bodegaentrada And x.idTipoInventario = inveEntrada Select x).FirstOrDefault

                            If inventario Is Nothing Then
                                Dim nuevoinventario As New tblInventario
                                nuevoinventario.idArticulo = articulo
                                nuevoinventario.IdAlmacen = Me.cmbBodegaEntrada.SelectedValue
                                nuevoinventario.idTipoInventario = inveEntrada

                                nuevoinventario.entrada = cantidad
                                nuevoinventario.saldo = cantidad
                                nuevoinventario.reserva = 0
                                nuevoinventario.salida = 0
                                nuevoinventario.transito = 0
                                conexion.AddTotblInventarios(nuevoinventario)
                                nuevoinventario.tblArticulo.fechaUltAjuste = fechaSerividor
                                conexion.SaveChanges()
                            Else
                                inventario.saldo += cantidad
                                inventario.entrada += cantidad
                                conexion.SaveChanges()
                            End If
                            ''inventario.tblArticulo.fechaUltAjuste = fechaSerividor
                            ''conexion.SaveChanges()
                        End If

                    Next

                    ''Guardamos todos los cambios
                    conexion.SaveChanges()
                    ''Completamos la transaccion
                    transaction.Complete()
                Catch ex As Exception
                    success = False
                    MessageBox.Show("No se Guardo el Registro:" + vbCrLf + ex.ToString, mdlPublicVars.nombreSistema)
                End Try

            End Using


            If success = True And bitErrorSistema = False Then
                conexion.AcceptAllChanges()
                alerta.contenido = "Registro guardado correctamente"
                alerta.fnGuardar()
            Else
                If bitErrorSistema = True Then
                    RadMessageBox.Show(msj, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Else
                    alerta.fnError()
                End If
            End If
            conn.Close()
        End Using

        If success = True And bitErrorSistema = False Then
            fnNuevo()
            fnEstablecerCorrelativo()
        End If

    End Sub

    Private Sub fnGuardar() Handles Me.panel1
        fnGuardarProduccion()
    End Sub

End Class
