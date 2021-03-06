﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmPedidosPendienteSurtir

    Private permiso As New clsPermisoUsuario

    Public registroActual As Integer = 0
    Private Sub frmPedidosPendienteSurtir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"

        Try
            Dim iz As New frmPedidosFacturasBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try
        llenagrid()
        fnConfiguracion()
    End Sub

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        Try

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

            If Me.grdDatos.Rows.Count > 0 Then
                If (Me.grdDatos.CurrentColumn.Name = "chmEliminar") And Me.grdDatos.CurrentRow.Index >= 0 Then
                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmEliminar").Value
                    Dim idsurtir As Integer = Me.grdDatos.Rows(fila).Cells("ID").Value

                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim surtir As tblSurtir = (From x In conexion.tblSurtirs Where x.codigo = idsurtir Select x).FirstOrDefault

                        If valor = True Then
                            surtir.Eliminar = False
                        Else
                            surtir.Eliminar = True
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
            Dim filtro As String = txtFiltro.Text

            Dim fechalimite As DateTime = fnFecha_horaServidor()
            Dim fechauso As Date = DateAdd(DateInterval.Month, -1, Today()).ToShortDateString

            'Realizamos la consulta
            Dim consulta = (From z In (From x In ctx.tblSurtirs _
                           Where (x.tblCliente.Negocio.Contains(filtro) Or x.tblVendedor.nombre.Contains(filtro) Or x.tblArticulo.nombre1.Contains(filtro)) And x.cantidad = x.saldo And x.saldo > 0 And x.Eliminar = False And (((From i In ctx.tblInventarios Where i.idTipoInventario = x.tblSalidaDetalle.tipoInventario And i.idArticulo = x.articulo Select i.saldo).FirstOrDefault) > 0) And x.fechaTransaccion > fechauso _
                           Select Fecha = x.fechaTransaccion, ID = x.codigo, Codigo = x.tblArticulo.codigo1, Articulo = x.tblArticulo.nombre1, _
                           Cliente = x.tblCliente.Negocio, Vendedor = x.tblVendedor.nombre, Cantidad = x.cantidad, Saldo = x.saldo, _
                           Existencia = (From y In ctx.tblInventarios Where y.idArticulo = x.articulo And y.idTipoInventario = mdlPublicVars.General_idTipoInventario And y.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal Select y.saldo).FirstOrDefault, _
                           Precio = If(x.salidaDetalle Is Nothing, 0, x.tblSalidaDetalle.precio), Total = x.cantidad * If(x.salidaDetalle Is Nothing, 1, x.tblSalidaDetalle.precio), chkAnulado = If(x.anulado = True, "Si", "No"), chmEliminar = x.Eliminar _
                           Order By Fecha Descending) Select z.Fecha, z.ID, z.Codigo, z.Articulo, z.Cliente, z.Vendedor, z.Cantidad, z.Saldo, z.Existencia, z.Precio, z.chmEliminar)

            ''Where z.Existencia > 0

            Me.grdDatos.DataSource = consulta

            Me.grdDatos.Rows(registroActual).IsCurrent = True

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            If Me.grdDatos.Rows.Count = 1 Then
                fnConfiguracion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                Me.grdDatos.Columns(1).IsVisible = False
                Me.grdDatos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(8).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(9).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(10).TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns(0).Width = 80
                Me.grdDatos.Columns(2).Width = 80
                Me.grdDatos.Columns(3).Width = 200
                Me.grdDatos.Columns(4).Width = 200
                Me.grdDatos.Columns(5).Width = 150
                Me.grdDatos.Columns(6).Width = 70
                Me.grdDatos.Columns(7).Width = 70
                Me.grdDatos.Columns(8).Width = 70
                Me.grdDatos.Columns(9).Width = 70
                Me.grdDatos.Columns(10).Width = 70
                Me.grdDatos.Columns(11).Width = 50

                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        If Me.grdDatos.CurrentRow.Index >= 0 Then
            mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("ID").Value, Integer)
        End If

    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Dim codigo As Integer = mdlPublicVars.superSearchId
        'AnularSalida(codigo)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmPedidosPendienteSurtir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub


    'Documento salida
    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Ventas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

End Class
