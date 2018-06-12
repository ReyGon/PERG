Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports Telerik.WinControls.UI
Imports System.Transactions
Imports Telerik.WinControls

Public Class frmComprasLista
    Public registroActual As Integer = 0
    Private cargo As Boolean
    Dim permiso As New clsPermisoUsuario

    Private Sub frmComprasLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmComprasLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"
        Try
            Dim iz As New frmComprasBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmComprasBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception
        End Try
        fnLlenarCombo()
        llenagrid()
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        cargo = True
        lblFiltroFecha.Visible = True
        cmbFiltroFecha.Visible = True
    End Sub

    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Dim datos = (From x In ctx.tblListaFiltroFechas Select x.orden, codigo = x.dias, x.nombre
                     Order By orden Ascending)

        With cmbFiltroFecha
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = datos
        End With
    End Sub

    Private Sub llenagrid()

        Try
            Me.grdDatos.Columns.Clear()
            Dim diasFiltro As Integer = CInt(cmbFiltroFecha.SelectedValue)
            Dim fechaFiltro As DateTime = Today.AddDays(-diasFiltro)
            Dim filtro As String = txtFiltro.Text
            Dim consulta = (From x In ctx.tblEntradas Where (CType(x.fechaRegistro, String).Contains(filtro) Or (x.tblProveedor.negocio.Contains(filtro))) And x.idEmpresa = mdlPublicVars.idEmpresa And (x.preforma = True Or x.compra = True) And _
                                    (diasFiltro = -1 Or (diasFiltro >= 0 And x.fechaRegistro > fechaFiltro))
                                   Select Codigo = x.idEntrada, Fecha = x.fechaFiltro, Proveedor = x.tblProveedor.negocio, Correlativo = x.correlativo, _
                                    Documento = x.serieDocumento & "-" & x.documento, TotalQ = (From a In ctx.tblEntradasDetalles Where a.idEntrada = x.idEntrada And x.preformaimportacion = False Select a.costoIVA * a.cantidad).Sum, _
                                    chkCredito = x.credito, chkContado = x.contado, chkAnulado = x.anulado, FechaAnulado = x.fechaAnulado, _
                                    chkAjustes = If((From y In ctx.tblDevolucionProveedors Where y.entrada = x.idEntrada And y.tipoMovimiento = mdlPublicVars.Proveedor_AjusteCodigoMovimiento Select y).Count > 0, True, False), _
                                    chkDevoluciones = If((From z In ctx.tblDevolucionProveedors Where z.entrada = x.idEntrada And z.tipoMovimiento = mdlPublicVars.Proveedor_DevolucionCodigoMovimiento Select z).Count > 0, True, False),
                                    clrEstado = If(x.anulado = True, 0, If(x.compra = True, 4, If(x.transito = True, 5, If(x.preforma = True, 1, 0)))), _
                                    Descripcion = If(x.anulado = True, "Anulado", If(x.compra = True, "Comprado", If(x.transito = True, "Tránsito", If(x.preforma = True, "Preforma", "Ninguno"))))
                                    Order By Fecha Descending, Codigo Descending)

            ''chkModPreforma = If(x.preforma And x.compra, True, False), _
            ''TotalD = (From a In ctx.tblEntradasDetalles Where a.idEntrada = x.idEntrada And x.preformaimportacion = True Select a.costoIVA * a.cantidad).Sum,

            Me.grdDatos.DataSource = consulta
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaAnulado")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "TotalQ")
                ''mdlPublicVars.fnGridTelerik_formatoMonedaDolar(Me.grdDatos, "TotalD")

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                'Codigo , Fecha , Clave, Proveedor , _
                'Documento , Total , chkCredito , chkContado , chkAnulado , FechaAnulado 
                Me.grdDatos.Columns("Codigo").Width = 60
                Me.grdDatos.Columns("Fecha").Width = 70
                Me.grdDatos.Columns("Proveedor").Width = 180
                Me.grdDatos.Columns("Correlativo").Width = 65
                Me.grdDatos.Columns("Documento").Width = 80
                ''Me.grdDatos.Columns("TotalD").Width = 90
                Me.grdDatos.Columns("TotalQ").Width = 90
                Me.grdDatos.Columns("chkCredito").Width = 55
                Me.grdDatos.Columns("chkContado").Width = 55
                Me.grdDatos.Columns("chkAnulado").Width = 55
                ''Me.grdDatos.Columns("chkModPreforma").Width = 55
                Me.grdDatos.Columns("FechaAnulado").Width = 80
                Me.grdDatos.Columns("chkAjustes").Width = 45
                Me.grdDatos.Columns("chkDevoluciones").Width = 75
                Me.grdDatos.Columns("clrEstado").Width = 70
                Me.grdDatos.Columns("Descripcion").Width = 100

                ''Me.grdDatos.Columns("preformaimportacioextranjero").IsVisible = False
                Me.grdDatos.Columns("Codigo").IsVisible = False

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        frmEntrada.Text = "Compras"
        frmEntrada.MdiParent = frmMenuPrincipal
        permiso.PermisoFrmEspeciales(frmEntrada, True)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Dim codigo As Integer = fnCambioFila()
        If codigo = -1 Then
            Exit Sub
        End If

        Try
            Dim estado As Integer = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("clrEstado").Value, Integer)
            ''Dim preformaimportacion As Integer = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("preformaimportacioextranjero").Value, Integer)
            'Estado: 1 --> Preforma, 5 --> Transito, 4 --> Compra
            
            ''If estado = 1 And preformaimportacion = 1 Then
            ''    frmImportaciones.Text = "Compra Importación"
            ''    frmImportaciones.MdiParent = frmMenuPrincipal
            ''    frmImportaciones.codigo = codigo
            ''    frmImportaciones.bitEditarEntrada = True
            ''    frmImportaciones.Show()
            ''ElseIf estado = 5 And preformaimportacion = 2 Then
            ''    frmImportaciones.Text = "Compra Importación"
            ''    frmImportaciones.MdiParent = frmMenuPrincipal
            ''    frmImportaciones.codigo = codigo
            ''    frmImportaciones.bitEditarTransito = True
            ''    'frmproformaimportacion.bitPreformaToEntrada = False
            ''    'frmproformaimportacion.bitPreformaToTransito = True
            ''    frmImportaciones.Show()

            ''Else
            If estado = 1 Then
                frmEntrada.Text = "Compras"
                frmEntrada.MdiParent = frmMenuPrincipal
                frmEntrada.codigo = codigo
                frmEntrada.bitEditarEntrada = True
                permiso.PermisoFrmEspeciales(frmEntrada, True)
            Else

                If RadMessageBox.Show("No se puede modificar, ya ha sido confirmada la compra. ¿Desea modificar el documento?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    fnModificardocumento()
                End If
                ''alertas.contenido = "No se puede modificar, ya ha sido comprada, realizar un AJUSTE !"
                ''alertas.fnErrorContenido()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Evento que maneja la funcion anular compra
    Private Sub frm_Eliminar() Handles Me.eliminaRegistro
        Try
            'Obtenemos el estado y verificamos si es una compra o una preforma
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
            Dim estado As Integer = Me.grdDatos.Rows(fila).Cells("clrEstado").Value

            If estado = 1 Then
                fnAnularPreforma()
            ElseIf estado = 4 Then
                'fnAnularCompra()
                RadMessageBox.Show("Una compra no se puede anular!" & vbCrLf & "Realize un ajuste en inventario. ", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Dim codigo As Integer = fnCambioFila()
        If codigo = -1 Then
            Exit Sub
        End If
        frmComprasConcepto.Text = "Compras"
        frmComprasConcepto.idEntrada = codigo
        frmComprasConcepto.WindowState = FormWindowState.Normal
        frmComprasConcepto.StartPosition = FormStartPosition.CenterScreen
        frmComprasConcepto.ShowDialog()
        frmComprasConcepto.Dispose()
    End Sub

    Public Function fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Dim codigo As Integer = 0
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                codigo = CType(Me.grdDatos.Rows(index).Cells("Codigo").Value, Integer)
                mdlPublicVars.superSearchId = codigo
            End If
        Catch ex As Exception
            codigo = -1
            alertas.contenido = "Error al seleccionar Registro "
        End Try

        Return codigo
    End Function

    'Funcion que se utiliza para confirmar un compra
    Private Sub fnAnularCompra()

        If RadMessageBox.Show("Desea Anular !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim success As Boolean = True
        Dim contado As Boolean = False
        Dim codigoProveedor As Integer = 0

        Dim codigo As Integer = fnCambioFila()
        If codigo = -1 Then
            Exit Sub
        End If

        Dim fechaServidor As DateTime = CType(fnFecha_horaServidor(), DateTime)

        Using transaction As New TransactionScope
            Try
                'Obtenemos la compra a anular
                Dim compra As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                If compra.anulado = True Then
                    alertas.contenido = "Compra ya esta anulada !!!"
                    success = False
                    Exit Try
                End If

                'Anulamos la compra
                compra.anulado = True
                compra.fechaAnulado = fechaServidor
                ctx.SaveChanges()

                'Obtenemos el detalle de la compra
                Dim lDetalles As List(Of tblEntradasDetalle) = (From x In ctx.tblEntradasDetalles Where x.idEntrada = codigo _
                                                              Select x).ToList
                Dim detalle As tblEntradasDetalle

                'Recorremos la lista de detalles de la compra
                For Each detalle In lDetalles
                    'Obtenemos el registro de inventario del articulo
                    Dim art As tblInventario = (From x In ctx.tblInventarios Where x.idArticulo = detalle.idArticulo _
                                             Select x).FirstOrDefault

                    If detalle.cantidad > art.saldo Then
                        'Si la cantidad es mayor a la existencia, generamos una alerta, y nos salimos de la funcion
                        alertas.contenido = "Existencia menor a la requerida, " & vbCrLf & "Articulo: " & art.tblArticulo.nombre1 & vbCrLf _
                            & "Cantidad Requerida: " & detalle.cantidad & vbCrLf & "Existencia: " & art.saldo & vbCrLf & vbCrLf _
                            & "Realize una devolución"
                        success = False
                        Exit Try
                    Else

                        'Volvemos a recalcular el costo del producto
                        'Modificamos el costo del producto
                        'Dim lista As List(Of tblEntradasDetalle) = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False And x.idArticulo = detalle.idArticulo _
                        '                                            And x.idEntradaDetalle <> detalle.idEntradaDetalle Select x).ToList
                        'Dim prod As New tblEntradasDetalle
                        Dim costo As Double = 0

                        'For Each prod In lista
                        'elementos += prod.cantidad
                        'precios += (prod.cantidad * prod.costoIVA)
                        'Next

                        Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = detalle.idArticulo _
                                                  Select x).FirstOrDefault

                        costo = detalle.cantidad * detalle.costoIVA

                        'Actualizamos el costo del articulo
                        articulo.costoIVA = ((articulo.costoIVA * art.saldo) - costo) / (art.saldo - detalle.cantidad)
                        articulo.costoSinIVA = articulo.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                        ctx.SaveChanges()

                        'Si existe la cantidad, descontamos de inventario
                        art.saldo -= detalle.cantidad
                        art.entrada -= detalle.cantidad
                        ctx.SaveChanges()
                    End If
                Next

                'Decrementamos el saldo del proveedor
                Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = compra.idProveedor Select x).FirstOrDefault
                proveedor.saldoActual -= compra.total
                ctx.SaveChanges()

                transaction.Complete()
            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alertas.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alertas.contenido = "Compra anulada exitosamente"
            alertas.fnErrorContenido()
            llenagrid()
        Else
            alertas.fnErrorContenido()
        End If
    End Sub

    'Funcion utilizada para anular preforma
    Private Sub fnAnularPreforma()
        If RadMessageBox.Show("Desea Anular !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim success As Boolean = True
        Dim contado As Boolean = False
        Dim codigoProveedor As Integer = 0

        Dim codigo As Integer = fnCambioFila()
        If codigo = -1 Then
            Exit Sub
        End If

        Dim fechaServidor As DateTime = CType(fnFecha_horaServidor(), DateTime)

        Using transaction As New TransactionScope
            Try
                'Obtenemos la compra a anular
                Dim compra As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = codigo Select x).FirstOrDefault

                If compra.anulado = True Then
                    alertas.contenido = "Compra ya esta anulada !!!"
                    success = False
                    Exit Try
                End If

                'Anulamos la compra
                compra.anulado = True
                compra.fechaAnulado = fechaServidor
                ctx.SaveChanges()
                transaction.Complete()
            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alertas.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alertas.contenido = "Compra anulada exitosamente"
            alertas.fnErrorContenido()
            llenagrid()
        Else
            alertas.fnErrorContenido()
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Compras"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    'CAMBIO DE FILTRO FECHA
    Public Overloads Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbFiltroFecha.SelectedValueChanged
        If cargo Then
            frm_llenarLista()
        End If
    End Sub

    Private Sub fnModificardocumento()
        Try

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim fila As Integer = 0
                    fila = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

                    Dim id As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                    Dim doc As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = id Select x).FirstOrDefault

                    ''Dim cadDias As String = InputBox("Ingrese dias de reserva", "Informacion", mdlPublicVars.Salida_ReservaDias)

                    ''Dim serie As String = InputBox("Ingrese la serie del documento", "Compras", doc.serieDocumento)
                    ''Dim documento As String = InputBox("Ingrese el documento", "Compras", doc.documento)
                    Dim serie As String = RadInputBox.Show("Ingrese la serie", "Compras", doc.serieDocumento)
                    Dim documento As String = RadInputBox.Show("Ingrese el documento", "Compras", doc.documento)

                If RadMessageBox.Show("El nuevo documento es: " + CStr(serie + "-" + documento) + " ¿Desea Guardarlo?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    doc.serieDocumento = serie
                    doc.documento = documento
                    conexion.SaveChanges()

                    alertas.fnModificar()
                    llenagrid()
                End If

                    conn.Close()
                End Using

        Catch ex As Exception

        End Try
    End Sub

End Class
