Option Strict On

Imports System.Data
Imports System.Data.EntityClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.Linq
Imports System.Transactions

Public Class frmHistorialPagos
    Private permiso As New clsPermisoUsuario
    Private _idproveedor As Integer

    Public Property idproveedor As Integer
        Get
            idproveedor = _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property

#Region "Eventos"

    Private Property listaEntradas As Object

    'LOAD
    Private Sub frmFacturasElegir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdPagos)
        mdlPublicVars.fnFormatoGridEspeciales(grdPagos)

        Me.rbListado.Checked = True

        fnLlenarGrid()
        mdlPublicVars.fnGrid_iconos(grdPagos)
    End Sub

    'CLIC EN ACEPTAR PARA AGREGAR EMPLEADOS

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)


        Me.Close()
    End Sub

    'SALIR DEL FORMULARIO
    Private Sub fnLlenarGrid()
        Try
            Dim dt As New DataTable
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim elegir As Boolean = False

                If idproveedor > 0 Then


                    dt = EntitiToDataTable(conexion.sp_PagosProveedoresImportacion(idproveedor, 0, 0))

                    Me.grdPagos.DataSource = dt

                    conn.Close()

                End If

                fnConfiguracion()

            End Using
        Catch

        End Try

    End Sub

    Public Sub fnConfiguracion()
        Try
            ''Me.grdPagos.Columns("Id").IsVisible = False
            Me.grdPagos.Columns("chmElegir").IsVisible = False
            Me.grdPagos.Columns("chmElegir").ReadOnly = True
            Me.grdPagos.Columns("TipoPago").Width = 75
            Me.grdPagos.Columns("Proveedor").Width = 75
            Me.grdPagos.Columns("DocPago").ReadOnly = True
            Me.grdPagos.Columns("FechaPago").Width = 75
            Me.grdPagos.Columns("PagoQ").Width = 60
            Me.grdPagos.Columns("TasaCambio").Width = 50
            Me.grdPagos.Columns("PagoD").Width = 50
            Me.grdPagos.Columns("DocumentoAfectado").Width = 60
            Me.grdPagos.Columns("chmElegir").ReadOnly = True
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub grdPagos_Click(sender As Object, e As EventArgs) Handles grdPagos.Click
        Try
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)
            If Me.rbListado.Checked = True Then
                Me.txtTasaCambio.Text = CStr(Me.grdPagos.Rows(fila).Cells("TasaCambio").Value)
            Else
                Me.txtTasaCambio.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdFacturas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdPagos.MouseDoubleClick
        Try

            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPagos)
            Dim salida As Integer = CInt(Me.grdPagos.Rows(index).Cells("id").Value)
            frmPedidoConcepto.Text = "Ventas"
            frmPedidoConcepto.idSalida = salida
            frmPedidoConcepto.WindowState = FormWindowState.Normal
            frmPedidoConcepto.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogEspeciales(frmPedidoConcepto)
            frmPedidoConcepto.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbListado_CheckedChanged(sender As Object, e As EventArgs) Handles rbListado.CheckedChanged
        Try
            If rbListado.Checked = True Then
                rbManual.Checked = False
                Me.txtTasaCambio.Enabled = False
            Else
                rbManual.Checked = True
                Me.txtTasaCambio.Enabled = True
                Me.txtTasaCambio.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Me.txtTasaCambio.Text <> "" Or CDec(Me.txtTasaCambio.Text) > 0 Then
                frmNacionalizacion.tasaCambio = CDec(Me.txtTasaCambio.Text)
                Me.Close()
            Else
                frmNotificacion.lblNotificacion.Text = "La tasa de cambio" + vbLf + "no es valida"
                frmNotificacion.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class