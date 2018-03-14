Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI

Public Class frmProveedorDevolucionLista
    Dim registroActual As Integer = 0
    Private permiso As New clsPermisoUsuario

    Private Sub frmProveedorDevolucionLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl2Eliminar.Text = "Anular"
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Try
            Dim iz As New frmComprasBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmProveedorDevolucionBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception

        End Try
        llenagrid()
        fnConfiguracion()
    End Sub

    Private Sub llenagrid()
        Try
            Me.grdDatos.Columns.Clear()
            Dim filtro As String = txtFiltro.Text

            Dim consulta = (From x In ctx.tblDevolucionProveedors Select _
                            Codigo = x.codigo, Fecha = x.fechaFiltro, Correlativo = x.documento, Proveedor = x.tblProveedor.negocio, _
                            Tipo = x.tblTipoMovimiento.nombre, Total = x.monto, _
                            clrEstado = CType(If(x.anulado = True, "0", If(x.acreditado = False, "1", If(x.acreditado = True, "4", "0"))), Int32), _
                            chkAnulado = x.anulado, FechaAnulado = x.fechaAnulado, chmAcreditado = x.acreditado _
                            Order By Fecha Descending)

            Me.grdDatos.DataSource = consulta
            mdlPublicVars.fnGrid_iconos(grdDatos)
            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            fnConfiguracion()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaAnulado")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("Codigo").Width = 60
                Me.grdDatos.Columns("Fecha").Width = 80
                Me.grdDatos.Columns("Correlativo").Width = 80
                Me.grdDatos.Columns("Proveedor").Width = 200
                Me.grdDatos.Columns("Tipo").Width = 170
                Me.grdDatos.Columns("Total").Width = 100
                Me.grdDatos.Columns("clrEstado").Width = 70
                Me.grdDatos.Columns("chkAnulado").Width = 70
                Me.grdDatos.Columns("chmAcreditado").Width = 70
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        If Me.grdDatos.CurrentRow.Index >= 0 Then
            mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Codigo").Value, Integer)
            registroActual = Me.grdDatos.CurrentRow.Index
        End If

    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            frmProveedorDevolucion.Text = "Ajuste/Devolucion"
            frmProveedorDevolucion.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frmProveedorDevolucion, True)
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            Dim anulado As Boolean = Me.grdDatos.Rows(registroActual).Cells("chkAnulado").Value
            Dim acreditado As Boolean = Me.grdDatos.Rows(registroActual).Cells("chmAcreditado").Value

            If acreditado = True Or anulado = True Then
                alertas.contenido = "La devolucion ya ha sido " & If(anulado = True, "anulada", "acreditada")
                alertas.fnErrorContenido()
            Else
                'Dim codigo As Integer = mdlPublicVars.superSearchId
                If RadMessageBox.Show("Desea anular la devolucion", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    fnAnularDevolucion()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try
            'Obtenemos el estado de la devolucion y el codigo
            Dim estado As Boolean = Me.grdDatos.Rows(registroActual).Cells("chmAcreditado").Value
            Dim codigo As Integer = Me.grdDatos.Rows(registroActual).Cells("Codigo").Value
            If estado = True Then
                'Si ya ha sido acreditado, no se podra modificar
                alertas.contenido = "Devolucion ya ha sido acreditada"
                alertas.fnErrorContenido()
            Else
                frmProveedorDevolucion.Text = "Ajustes y Devoluciones"
                frmProveedorDevolucion.bitEditarDevolucion = True
                frmProveedorDevolucion.codigoDev = codigo
                frmProveedorDevolucion.verRegistro = False
                frmProveedorDevolucion.MdiParent = frmMenuPrincipal
                frmProveedorDevolucion.WindowState = FormWindowState.Maximized
                permiso.PermisoFrmEspeciales(frmProveedorDevolucion, True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'VER
    Private Sub frm_ver() Handles Me.verRegistro
        Dim codigo As Integer = Me.grdDatos.Rows(registroActual).Cells("Codigo").Value
        frmProveedorDevolucion.Text = "Ajustes y Devoluciones"
        frmProveedorDevolucion.bitEditarDevolucion = True
        frmProveedorDevolucion.codigoDev = codigo
        frmProveedorDevolucion.verRegistro = True
        permiso.PermisoFrmEspeciales(frmProveedorDevolucion, False)
    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click

        If Me.grdDatos.Rows.Count > 0 Then
            If (Me.grdDatos.CurrentColumn.Name = "chmAcreditado") And Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim valor As Boolean = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmAcreditado").Value
                If valor = False Then
                    Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmAcreditado").Value = True
                    registroActual = Me.grdDatos.CurrentRow.Index
                    If RadMessageBox.Show("Desea acreditar la devolucion", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                        registroActual = Me.grdDatos.CurrentRow.Index
                        If fnConfirmarDevolucion() = False Then
                            Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmAcreditado").Value = False
                        End If
                    Else
                        Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmAcreditado").Value = False
                    End If
                Else
                    alertas.contenido = "La devolucion ya se ha acreditado"
                    alertas.fnErrorContenido()
                    Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmAcreditado").Value = False

                End If
            End If
        End If
        Return False
    End Function

    'Funcion utilizada para confirmar una devolucion
    Private Function fnConfirmarDevolucion() As Boolean


        Dim success As Boolean = True
        Dim codDev As Integer = Me.grdDatos.Rows(registroActual).Cells("Codigo").Value
        Dim fechaServidor As DateTime = fnFecha_horaServidor()
        Using transaction As New TransactionScope
            Try
                Dim devolucion As tblDevolucionProveedor = (From x In ctx.tblDevolucionProveedors Where x.codigo = codDev And x.acreditado = False _
                                                            Select x).FirstOrDefault

                'Acreditamos la devolucion
                devolucion.acreditado = True
                devolucion.fechaAcreditado = fechaServidor
                ctx.SaveChanges()

                'Obtenemos la lista de los detalles de la devolucion
                Dim lDetalles As List(Of tblDevolucionProveedorDetalle) = (From x In ctx.tblDevolucionProveedorDetalles _
                                                                          Where x.devolucionProveedor = codDev _
                                                                          Select x).ToList

                Dim detalle As tblDevolucionProveedorDetalle

                'Recorremos la lista de los detalles de la devolucion
                For Each detalle In lDetalles
                    Dim saldo As Integer
                    'Obtenemos el registro de inventario del articulo
                    Dim inve As tblInventario = (From x In ctx.tblInventarios Where x.idArticulo = detalle.articulo _
                                                 And x.idTipoInventario = mdlPublicVars.General_idTipoInventario Select x).FirstOrDefault

                    If detalle.cantidad > inve.saldo Then
                        'Si la cantidad es mayor a la existencia, generamos una alerta, y nos salimos de la funcion
                        alertas.contenido = "Existencia menor a la requerida, " & vbCrLf & "Articulo: " & inve.tblArticulo.nombre1 & vbCrLf _
                            & "Cantidad Requerida: " & detalle.cantidad & vbCrLf & "Existencia: " & inve.saldo & vbCrLf & vbCrLf _
                            & "Realize una devolución"
                        success = False
                        Exit Try
                    Else
                        saldo = inve.saldo
                        'Descontamos de inventario
                        inve.saldo -= detalle.cantidad
                        inve.entrada -= detalle.cantidad
                        ctx.SaveChanges()


                        'COSTO DEL PRODUCTO
                        'Variables que se utilizara para calcular el nuevo costo del producto
                        Dim costo As Decimal = 0

                        'Lista de entradas
                        'Dim lEntradas As List(Of tblEntradasDetalle) = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False _
                        '                                               And x.idArticulo = detalle.articulo Select x).ToList

                        'Dim dEntrada As tblEntradasDetalle
                        'Lista de devoluciones
                        'Dim lDevolucion As List(Of tblDevolucionProveedorDetalle) = (From x In ctx.tblDevolucionProveedorDetalles Where x.articulo = detalle.articulo _
                        '                                                                 Select x).ToList

                        'Dim dDevolucion As tblDevolucionProveedorDetalle
                        'Recorremos la lista de entradas
                        'For Each dEntrada In lEntradas
                        'elementos += dEntrada.cantidad
                        ' costo += (dEntrada.cantidad * dEntrada.costoIVA)
                        'Next

                        'Recorremos la lista de devoluciones
                        'For Each dDevolucion In lDevolucion
                        'elementos -= dDevolucion.cantidad
                        'costo -= (dDevolucion.cantidad * dDevolucion.costo)
                        'Next

                        'Obtenemos el articulo a modificar
                        Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = detalle.articulo _
                                                       Select x).FirstOrDefault
                        costo = detalle.cantidad * detalle.costo

                        If saldo - detalle.cantidad > 0 Then
                            'Actualizamos el costo del articulo
                            articulo.costoIVA = ((articulo.costoIVA * saldo) - costo) / (saldo - detalle.cantidad)
                            articulo.costoSinIVA = articulo.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                            ctx.SaveChanges()
                        End If
                    End If
                Next

                'Modificamos el saldo del proveedor
                Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = devolucion.proveedor _
                                                 Select x).FirstOrDefault

                'Disminuimos el saldo del proveedor
                proveedor.saldoActual -= devolucion.monto
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
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
            Call llenagrid()
        Else
            If alertas.contenido.Length = 0 Then
                alertas.fnError()
            Else
                alertas.fnErrorContenido()
            End If
        End If

        Return success
    End Function

    'Funcion utilizada para anular una devolucion
    Private Sub fnAnularDevolucion(ByVal codDev As Integer)
        Dim success As Boolean = True
        Dim fechaServidor As DateTime = fnFecha_horaServidor()

        Using transaction As New TransactionScope
            Try
                'Obtenemos el registro de la devolucion
                Dim devolucion As tblDevolucionProveedor = (From x In ctx.tblDevolucionProveedors Where x.codigo = codDev _
                                                           Select x).FirstOrDefault

                devolucion.anulado = True
                devolucion.fechaAnulado = fechaServidor
                ctx.SaveChanges()

                If devolucion.acreditado = True Then

                    'Obtenemos el detalle de la devolucion
                    Dim lDetalles As List(Of tblDevolucionProveedorDetalle) = (From x In ctx.tblDevolucionProveedorDetalles Where x.devolucionProveedor = codDev _
                                                                                Select x).ToList

                    Dim detalle As tblDevolucionProveedorDetalle

                    For Each detalle In lDetalles
                        Dim saldo As Integer
                        'Obtenemos el registro de inventario del articulo
                        Dim inve As tblInventario = (From x In ctx.tblInventarios Where x.idArticulo = detalle.articulo _
                                                    Select x).FirstOrDefault
                        saldo = inve.saldo
                        'Descontamos de inventario
                        inve.saldo += detalle.cantidad
                        inve.entrada += detalle.cantidad
                        ctx.SaveChanges()

                        'COSTO DEL PRODUCTO
                        'Variables que se utilizara para calcular el nuevo costo del producto
                        Dim costo As Decimal = 0

                        'Lista de entradas
                        'Dim lEntradas As List(Of tblEntradasDetalle) = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False _
                        '                                        And x.idArticulo = detalle.articulo Select x).ToList

                        'Dim dEntrada As tblEntradasDetalle
                        'Lista de devoluciones
                        'Dim lDevolucion As List(Of tblDevolucionProveedorDetalle) = (From x In ctx.tblDevolucionProveedorDetalles Where x.articulo = detalle.articulo _
                        'And x.tblDevolucionProveedor.anulado = False Select x).ToList

                        'Dim dDevolucion As tblDevolucionProveedorDetalle
                        'Recorremos la lista de entradas
                        'For Each dEntrada In lEntradas
                        'elementos += dEntrada.cantidad
                        'costo += (dEntrada.cantidad * dEntrada.costoIVA)
                        'Next

                        'Recorremos la lista de devoluciones
                        'For Each dDevolucion In lDevolucion
                        'elementos -= dDevolucion.cantidad
                        'costo -= (dDevolucion.cantidad * dDevolucion.costo)
                        'Next

                        'Obtenemos el articulo a modificar
                        Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = detalle.articulo _
                                               Select x).FirstOrDefault

                        costo = (detalle.cantidad * detalle.costo)

                        'Actualizamos el costo del articulo
                        articulo.costoIVA = (costo + (saldo * articulo.costoIVA)) / (saldo + detalle.cantidad)
                        articulo.costoSinIVA = articulo.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                        ctx.SaveChanges()
                    Next

                    'Modificamos el saldo del proveedor
                    Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = devolucion.proveedor _
                                                     Select x).FirstOrDefault

                    'Disminuimos el saldo del proveedor
                    proveedor.saldoActual += devolucion.monto
                    ctx.SaveChanges()
                    transaction.Complete()
                End If
            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alertas.fnErrorGuardar()
                    Exit Try
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
            llenagrid()
        Else
            alertas.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Sub

    'Funcion utilizada para anular una devolucion
    Private Sub fnAnularDevolucion()
        Dim codigo As Integer = mdlPublicVars.superSearchId
        Dim success As Boolean = True
        Dim fechaServidor As DateTime = fnFecha_horaServidor()

        Using transaction As New TransactionScope
            Try
                'Obtenemos el registro de la devolucion
                Dim devolucion As tblDevolucionProveedor = (From x In ctx.tblDevolucionProveedors Where x.codigo = codigo _
                                                           Select x).FirstOrDefault

                devolucion.anulado = True
                devolucion.fechaAnulado = fechaServidor
                ctx.SaveChanges()


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
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
            Call llenagrid()
        Else
            If alertas.contenido.Length = 0 Then
                alertas.fnError()
            Else
                alertas.fnErrorContenido()
            End If
        End If

    End Sub

    Private Sub frmProveedorDevolucionLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Devoluciones a Proveedores"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
