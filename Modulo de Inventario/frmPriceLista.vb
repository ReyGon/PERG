Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmPriceLista
    Private permiso As New clsPermisoUsuario
    Public filtroActivo As Boolean


    Private Sub frmProductoLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmProductosBarraIzquierda
            iz.frmAnterior = Me

            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmProductosBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try
        pnx0Nuevo.Visible = False
        llenagrid()
        fnConfiguracion()
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.Focus()
    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        Try

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

            If Me.grdDatos.Rows.Count > 0 Then
                If (Me.grdDatos.CurrentColumn.Name = "chmUltimoPrecio") And Me.grdDatos.CurrentRow.Index >= 0 Then
                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmUltimoPrecio").Value
                    Dim idproducto As Integer = Me.grdDatos.Rows(fila).Cells("ID").Value

                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = idproducto Select x).FirstOrDefault

                        If valor = True Then
                            articulo.ultimoprecio = False
                        Else
                            articulo.ultimoprecio = True
                        End If

                        conexion.SaveChanges()

                        llenagrid()
                        fnConfiguracion()

                        conn.Close()
                    End Using
                End If
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub llenagrid()
        Try
            If filtroActivo Then
                frmPriceFiltro.fnFiltrar()
            Else
                Dim filtro As String = txtFiltro.Text

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim productoInfo = _
                        From x In conexion.tblInventarios Order By x.tblArticulo.codigo1 Where x.idArticulo > 0 _
                        And x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                        And x.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                        And (x.tblArticulo.nombre1.Contains(filtro) Or CType(x.tblArticulo.codigo1, String).Contains(filtro)) And x.tblArticulo.Habilitado = True _
                        Group By ID = x.tblArticulo.idArticulo, Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, _
                        Existencia = x.saldo, PrecioPublico = x.tblArticulo.precioPublico, _
                        PrecioVentaPromedio = (From y In conexion.tblSalidaDetalles Where y.idArticulo = x.idArticulo And y.tblSalida.anulado = False And y.tblSalida.facturado = True
                        Group By y.idArticulo Into totalP = Sum(y.precio * y.cantidad), contador = Sum(y.cantidad) Select If(contador = 0, 0, totalP / contador)).FirstOrDefault, _
                        PrecioA = (From z In conexion.tblArticulo_Precio Where z.tipoPrecio = 1 And z.articulo = x.idArticulo Select z.precio).FirstOrDefault, _
                        PrecioB = (From z In conexion.tblArticulo_Precio Where z.tipoPrecio = 2 And z.articulo = x.idArticulo Select z.precio).FirstOrDefault, _
                        PrecioOferta = (From z In conexion.tblArticulo_Precio Where z.tipoPrecio = 3 And z.articulo = x.idArticulo Select z.precio).FirstOrDefault, _
                        CostoPromedio = x.tblArticulo.costoIVA, Total = x.saldo * x.tblArticulo.costoIVA, chmUltimoPrecio = x.tblArticulo.UltimoPrecio
                        Into Group
                        Select ID, Codigo, Nombre, Existencia, PrecioPublico, PrecioVentaPromedio, PrecioA, PrecioB, PrecioOferta, CostoPromedio,
                        MargenPromedio = If((PrecioVentaPromedio = 0 Or CostoPromedio = 0), 0, 1 - (CostoPromedio / PrecioVentaPromedio)), chmUltimoPrecio

                Me.grdDatos.DataSource = productoInfo ''EntitiToDataTable(productoInfo)
                    fnConfiguracion()

                    conn.Close()
                End Using
            End If

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub fnConfiguracion()
        Try

            Me.grdDatos.Columns("ID").IsVisible = False

            mdlPublicVars.fnGridTelerik_formatoPorcentaje(Me.grdDatos, "MargenPromedio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioPublico")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioVentaPromedio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "CostoPromedio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioA")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioB")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioOferta")        

            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next



            Me.grdDatos.Columns("ID").Width = 50 'ID
            Me.grdDatos.Columns("Codigo").Width = 80 'Codigo
            Me.grdDatos.Columns("Nombre").Width = 250 'Nombre
            Me.grdDatos.Columns("Existencia").Width = 80 'Existencia
            Me.grdDatos.Columns("PrecioPublico").Width = 90 'Precio Publico
            Me.grdDatos.Columns("PrecioVentaPromedio").Width = 90 'PrecioVentaPromedio
            Me.grdDatos.Columns("PrecioA").Width = 90 'PrecioA
            Me.grdDatos.Columns("PrecioB").Width = 90 'PrecioB
            Me.grdDatos.Columns("PrecioOferta").Width = 90 'PrecioOferta
            Me.grdDatos.Columns("CostoPromedio").Width = 90 'CostoPromedio
            Me.grdDatos.Columns("MargenPromedio").Width = 90 'MargenPromedio
            Me.grdDatos.Columns("CostoPromedio").Width = 90 'CostoPromedio
            Me.grdDatos.Columns("MargenPromedio").Width = 90 'MargenPromedio

        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        fnCambioFila()
        frmProducto.seleccionDefault = False
        frmProducto.Text = "Modulo de Productos"
        frmProducto.NuevoIniciar = True
        permiso.PermisoMantenimientoTelerik2(frmProducto, False)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try
            fnCambioFila()
            frmProductoPrecio.Text = "Precios"
            frmProductoPrecio.StartPosition = FormStartPosition.CenterScreen
            frmProductoPrecio.BringToFront()
            frmProductoPrecio.Focus()
            permiso.PermisoFrmEspeciales(frmProductoPrecio, False)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            mdlPublicVars.superSearchId = grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("ID").Value()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Price de Productos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub frmSalir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmPriceFiltro.Text = "Filtro: PRODUCTOS"
        frmPriceFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmPriceFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
    End Sub

End Class


