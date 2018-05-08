Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmPromociones

    Private Modelos As String
    Private Marcas As String
    Private Tipos As String

    Private permiso As New clsPermisoUsuario

    Private Sub frmPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
            fnFiltros()
            fnLlenaGrid()
            fnBloquear()
            mdlPublicVars.fnGrid_iconos(grdProductos)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenaGrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Me.grdProductos.DataSource = Nothing

                Dim consulta As Object

                ''consulta = (From a In conexion.tblArticuloes Where a.Habilitado = True
                ''              Select Id = a.idArticulo, Codigo = a.codigo1, Producto = a.nombre1, chmFechaEstado = If(a.bitFecha = False, False, True), txbFechaI = a.FechaInicio, txbFechaF = a.FechaFin,
                ''              chmCantEstado = If(a.bitCantidad = False, False, True), CantMin = a.CantidadMinima, Cuota = a.CuotaPromocion, Cantidad = a.CantidadPromocion,
                ''              chmActivado = If(a.bitPromocion = False, False, True)).ToList

                consulta = conexion.sp_ListadoArticulosPromociones(Tipos, Modelos, Marcas)

                Me.grdProductos.DataSource = consulta

                fnConfiguracion()
                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try

            Me.grdProductos.Columns("Id").IsVisible = False
            Me.grdProductos.Columns("Codigo").Width = 80
            Me.grdProductos.Columns("Producto").Width = 180
            Me.grdProductos.Columns("FechaInicio").Width = 75
            Me.grdProductos.Columns("FechaFin").Width = 75
            Me.grdProductos.Columns("chmFechaEstado").Width = 50
            Me.grdProductos.Columns("ExisMin").Width = 50
            Me.grdProductos.Columns("chmCantEstado").Width = 50
            Me.grdProductos.Columns("CuotaProm").Width = 50
            Me.grdProductos.Columns("CantidadProm").Width = 50
            Me.grdProductos.Columns("chmPromocion").Width = 50

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_Click(sender As Object, e As EventArgs) Handles grdProductos.Click
        Try
            If Me.grdProductos.Rows.Count > 0 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdProductos)

                Dim id As Integer = CInt(Me.grdProductos.Rows(fila).Cells("Id").Value)

                fnLimpiar()

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim a As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).FirstOrDefault

                    Me.txtId.Text = CStr(a.idArticulo)
                    Me.txtCodigo.Text = a.codigo1
                    Me.txtProducto.Text = a.nombre1
                    Me.chkFechaEstado.Checked = CBool(a.bitFecha)
                    Try
                        Me.dtpFechaInicio.Value = If(a.FechaInicio Is Nothing, Nothing, CDate(a.FechaInicio))

                    Catch ex As Exception

                    End Try
                    Try
                        Me.dtpFechaFin.Value = If(a.FechaFin Is Nothing, Nothing, CDate(a.FechaFin))
                    Catch ex As Exception

                    End Try
                    Me.chkExistenciaEstado.Checked = CBool(a.bitCantidad)
                    Me.txtExistenciaMinima.Text = CStr(a.CantidadMinima)
                    Me.chkActivado.Checked = CBool(a.bitPromocion)
                    Me.txtCuotaPromocion.Text = CStr(a.CuotaPromocion)
                    Me.txtCantidadPromocion.Text = CStr(a.CantidadPromocion)

                    

                    conn.Close()
                End Using

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guardar() Handles Me.panel0
        Try
            fnGuardar()
            fnLlenaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnGuardar()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim Id As Integer = CInt(Me.txtId.Text)

                Dim a As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = Id Select x).FirstOrDefault

                a.bitFecha = Me.chkFechaEstado.Checked
                a.FechaInicio = Me.dtpFechaInicio.Value
                a.FechaFin = Me.dtpFechaFin.Value
                a.bitCantidad = Me.chkExistenciaEstado.Checked
                a.CantidadMinima = CInt(Me.txtExistenciaMinima.Text)
                a.CuotaPromocion = CInt(Me.txtCuotaPromocion.Text)
                a.CantidadPromocion = CInt(Me.txtCantidadPromocion.Text)
                a.bitPromocion = Me.chkActivado.Checked

                conexion.SaveChanges()

                conn.Close()

                fnLimpiar()
                alerta.fnGuardar()
            End Using
        Catch ex As Exception
            alerta.fnErrorGuardar()
        End Try
    End Sub

    Private Sub fnLimpiar()
        Try
            Me.txtId.Text = ""
            Me.txtCodigo.Text = ""
            Me.txtProducto.Text = ""
            Me.txtExistenciaMinima.Text = ""
            Me.txtCantidadPromocion.Text = ""
            Me.txtCuotaPromocion.Text = ""
            Me.chkFechaEstado.Checked = False
            Me.chkExistenciaEstado.Checked = False
            Me.chkActivado.Checked = False
            Me.dtpFechaInicio.Value = CDate(fnFechaServidor())
            Me.dtpFechaFin.Value = CDate(fnFechaServidor())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Try
            Me.Close()
            frmMenu.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPricing_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProductos.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                Try

                Catch ex As Exception

                End Try
            End If

            If e.KeyCode = Keys.F3 Then
                Try

                Catch ex As Exception

                End Try
            End If

            If e.KeyCode = Keys.F4 Then
                Try
                    If Me.txtId.Text = "" Then
                        RadMessageBox.Show("Debe Seleccionar un Producto", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        Exit Sub
                    End If

                    mdlPublicVars.superSearchId = CInt(Me.txtId.Text)
                    frmProductoPrecio.Text = "Precios"
                    frmProductoPrecio.StartPosition = FormStartPosition.CenterScreen
                    frmProductoPrecio.BringToFront()
                    frmProductoPrecio.Focus()
                    permiso.PermisoFrmEspeciales(frmProductoPrecio, False)
                Catch ex As Exception

                End Try
            End If

            If e.KeyCode = Keys.F6 Then
                Try

                Catch ex As Exception

                End Try
            End If

            If e.KeyCode = Keys.F8 Then
                Try
                    fnFiltros()
                    fnLlenaGrid()
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnFiltros()
        Try
            frmFiltrosInventarios.Text = "Filtros Categorias"
            frmFiltrosInventarios.StartPosition = FormStartPosition.CenterScreen
            frmFiltrosInventarios.WindowState = FormWindowState.Normal
            frmFiltrosInventarios.ShowDialog()
            frmFiltrosInventarios.Dispose()

            Modelos = mdlPublicVars.superSearchModelos
            Tipos = mdlPublicVars.superSearchTipos
            Marcas = mdlPublicVars.superSearchMarcas
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkExistenciaEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chkExistenciaEstado.CheckedChanged
        Try
            If Me.chkExistenciaEstado.Checked = True Then
                Me.txtExistenciaMinima.Enabled = True
            Else
                Me.txtExistenciaMinima.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkFechaEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaEstado.CheckedChanged
        Try
            If Me.chkFechaEstado.Checked = True Then
                Me.dtpFechaInicio.Enabled = True
                Me.dtpFechaFin.Enabled = True
            Else
                Me.dtpFechaInicio.Enabled = False
                Me.dtpFechaFin.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkActivado_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivado.CheckedChanged
        If Me.chkActivado.Checked = True Then
            Me.txtCuotaPromocion.Enabled = True
            Me.txtCantidadPromocion.Enabled = True
        Else
            Me.txtCuotaPromocion.Enabled = False
            Me.txtCantidadPromocion.Enabled = False
        End If
    End Sub

    Private Sub fnBloquear()
        Try
            Me.txtCuotaPromocion.Enabled = False
            Me.txtCantidadPromocion.Enabled = False
            Me.dtpFechaInicio.Enabled = False
            Me.dtpFechaFin.Enabled = False
            Me.txtExistenciaMinima.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
End Class
