Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmCierreCajaLista
    Public filtroActivo As Boolean
    Dim permiso As New clsPermisoUsuario
    Private cargo As Boolean
    Dim fechaActual As DateTime = Now

    Private Sub frmCierreCajaLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.grdDatos.ImageList = frmControles.ImageListAdministracion
            lbl2Eliminar.Text = "Anular"

            If mdlPublicVars.PuntoVentaPequeno_Activado Then
                Dim iz As New frmVentaPequeniaBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            Else
                Dim iz As New frmPedidosFacturasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If
            frmBarraLateralBaseDerecha = frmCierreCajaBarraDerecha
            ActivarBarraLateral = True
            Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Catch ex As Exception
        End Try

        cmbFiltroFecha.Visible = True
        lblFiltroFecha.Visible = True
        fnLlenarCombo()
        cargo = True
        llenagrid()
        mdlPublicVars.fnGrid_iconos(grdDatos)
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


    Private Sub llenagrid() Handles Me.llenarLista
        Try

            Dim filtro As String = txtFiltro.Text
            Dim fechaFiltro As DateTime = fechaActual.AddDays(-cmbFiltroFecha.SelectedValue)
            Dim fechaBusqueda As String = Format(fechaFiltro, "dd/MM/yyyy hh:mm:ss")

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                Dim datos = From x In (From x In conexion.tblCierreCajas
                           Where (x.documentoBoleta.Contains(filtro) Or x.tblUsuario2.nombre.Contains(filtro) Or CType(x.correlativo, String).Contains(filtro)) And x.empresa = mdlPublicVars.idEmpresa _
                           And x.fechaRegistro > fechaBusqueda
                           Group By Codigo = x.codigo, Registro = x.fechaRegistro, Desde = x.desde, Hasta = x.hasta,
                           Usuario = x.tblUsuario2.nombre, Total = If(x.tblCierreCajaDetalles.Count > 0, x.tblCierreCajaDetalles.Select(Function(z) z.total).Sum, 0) _
                                                             + CType(If(x.bitAjuste, x.montoAjuste, 0), Decimal) _
                                                             + If(x.tblCierreCajaDetalleCajas.Where(Function(z) z.bitCheque).Count > 0, _
                                                                  x.tblCierreCajaDetalleCajas.Where(Function(z) z.bitCheque).Select(
                                                                      Function(z) If(x.tblCierreCajaDetalles.Count = 0 And z.tblCaja.bitRechazado, -z.tblCaja.monto,
                                                                                     z.tblCaja.monto)).Sum, 0),
                           Diferencia = If(x.bitConfirmado, (If(x.tblCierreCajaDetalles.Count > 0, (x.tblCierreCajaDetalles.Select(Function(z) z.total).Sum), 0) + x.montoAjuste) _
                                           - If(x.tblCierreCajaDetalleCajas.Where(Function(z) z.bitEfectivo).Count > 0, _
                                                (x.tblCierreCajaDetalleCajas.Where(Function(y) y.bitEfectivo).Select(Function(y) y.tblCaja.monto).Sum), 0), 0),
                           chkAnulado = x.bitAnulado, FechaAnulado = x.fechaAnulado, chkAjustado = x.bitAjuste,
                           FechaConfirmado = x.fechaConfirmado,
                           clrEstado = If(x.bitAnulado, 0, If(x.bitConfirmado, 4, If(Not x.bitConfirmado, 1, 0))),
                           Estado = CType(If(x.bitAnulado, "Anulado", If(Not x.bitConfirmado, "No Confirmado", "Confirmado")), String),
                           chmConfirmar = x.bitConfirmado, Correlativo = x.correlativo
               Into Group
                           Select Codigo, Registro, Desde, Hasta, Usuario, Correlativo, Total, Resultado = If(Total < 0, "Contra-Cierre", If(Diferencia <= mdlPublicVars.CierreCaja_Tolerancia, "Cuadra", "No Cuadra")), Diferencia,
                           chkAnulado, FechaAnulado, chkAjustado, FechaConfirmado, clrEstado, Estado, chmConfirmar) Select x Order By x.Registro Descending

                Me.grdDatos.DataSource = datos
                'Para saber cuantas filas tiene el grid
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count

                conn.Close()

            End Using

            fnConfiguracion()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count >= 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Registro")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaConfirmado")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Desde")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Hasta")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Diferencia")

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("Codigo").IsVisible = False
                Me.grdDatos.Columns("Registro").Width = 70
                Me.grdDatos.Columns("Desde").Width = 70
                Me.grdDatos.Columns("Hasta").Width = 70
                Me.grdDatos.Columns("Usuario").Width = 120
                Me.grdDatos.Columns("Correlativo").Width = 80
                Me.grdDatos.Columns("Total").Width = 110
                Me.grdDatos.Columns("Diferencia").Width = 70
                Me.grdDatos.Columns("chkAnulado").Width = 60
                Me.grdDatos.Columns("FechaAnulado").Width = 80
                Me.grdDatos.Columns("chkAjustado").Width = 60
                Me.grdDatos.Columns("chmConfirmar").Width = 60
                Me.grdDatos.Columns("clrEstado").Width = 50
                Me.grdDatos.Columns("FechaConfirmado").Width = 80
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Public Sub frm_llenarLista()
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            frmCierreCajaNuevoAjuste.Text = "Cierre de Caja"
            frmCierreCajaNuevoAjuste.StartPosition = FormStartPosition.CenterScreen
            frmCierreCajaNuevoAjuste.ShowDialog()
            frmCierreCajaNuevoAjuste.Dispose()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        alertas.contenido = "No se puede modificar un cierre"
        alertas.fnErrorContenido()
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            Dim codigo As Integer = fnCambioFila()
            If codigo = -1 Then
                Exit Sub
            End If

            fnDeshabilita(codigo)
            Call llenagrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Try
            Dim codigo As Integer = fnCambioFila()
            If codigo = -1 Then
                Exit Sub
            End If
            frmCierreCajaConcepto.Text = "Cierre de Caja"
            frmCierreCajaConcepto.codigo = codigo
            frmCierreCajaConcepto.StartPosition = FormStartPosition.CenterScreen
            frmCierreCajaConcepto.bitAjuste = True
            frmCierreCajaConcepto.ShowDialog()
            frmCierreCajaConcepto.Dispose()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para desabilitar un proveedor
    Private Sub fnDeshabilita(ByVal codigo As Integer)

        If RadMessageBox.Show("¿Desea anular el cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim success As Boolean = True
            Dim fechaServer As DateTime = fnFecha_horaServidor()

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Try
                    'Obtenemos el cierre con ese codigo
                    Dim cierre As tblCierreCaja = (From x In conexion.tblCierreCajas Where x.codigo = codigo Select x).FirstOrDefault

                    If Not cierre.bitConfirmado Then
                        'Deshabilitamos al cliente
                        cierre.bitAnulado = True
                        cierre.usuarioAnulado = mdlPublicVars.idUsuario
                        cierre.fechaAnulado = fechaServer
                        conexion.SaveChanges()

                        If mdlPublicVars.PuntoVentaPequeno_Activado = True And mdlPublicVars.bitTransportePesado = True Then

                            Dim cajas As List(Of tblCierreCajaDetalleCaja) = (From x In conexion.tblCierreCajaDetalleCajas Where x.idCierreCaja = codigo Select x).ToList

                            If cajas Is Nothing Then

                            Else

                                For Each pago As tblCierreCajaDetalleCaja In cajas

                                    Dim pagocaja As tblCaja = (From x In conexion.tblCajas Where x.codigo = pago.idCaja Select x).FirstOrDefault

                                    pagocaja.codutilizado = 0
                                    conexion.SaveChanges()

                                Next

                            End If

                        End If

                    Else
                        alertas.contenido = "El cierre de caja ya ha sido confirmado"

                        success = False
                    End If

                Catch ex As Exception
                    success = False
                End Try

                conn.Close()
            End Using


            If success Then
                alertas.fnModificar()
            Else
                alertas.fnErrorContenido()
            End If
        End If

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

    Private Sub fnFiltros()
        'Codigo para filtro
    End Sub

    Private Sub fnQuitarFiltro()
        'Quitar el filtro
    End Sub

    Private Sub fnDocSalida()
        frmDocumentosSalida.txtTitulo.Text = "Lista de Cierres de Caja"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        If Me.grdDatos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If (Me.grdDatos.CurrentColumn.Name.Equals("chmConfirmar")) And Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value
                Dim anulado As Boolean = Me.grdDatos.Rows(fila).Cells("chkAnulado").Value
                Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                If anulado Then
                    RadMessageBox.Show("El cierre ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ElseIf valor Then
                    RadMessageBox.Show("El cierre ya ha sido confirmado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Else
                    Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = True
                    If RadMessageBox.Show("¿Desea confirmar cierre de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                        fnConfirmarCierre(codigo)
                    Else
                        Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("chmConfirmar").Value = False
                    End If
                End If
            End If
        End If

        Return False
    End Function

    'Funcion utilizada para confirmar un cierre de caja
    Private Sub fnConfirmarCierre(ByVal codigo As Integer)
        frmCierreCajaConfirma.Text = "Confirmar Cierre"
        frmCierreCajaConfirma.StartPosition = FormStartPosition.CenterScreen
        frmCierreCajaConfirma.codigo = codigo
        frmCierreCajaConfirma.ShowDialog()
        frmCierreCajaConfirma.Dispose()
    End Sub

    Private Sub frmCierreCajaLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'CAMBIO DE FILTRO FECHA
    Public Overloads Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbFiltroFecha.SelectedValueChanged
        If cargo Then
            frm_llenarLista()
        End If
    End Sub
End Class