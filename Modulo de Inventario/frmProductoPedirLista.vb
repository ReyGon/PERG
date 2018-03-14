Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI.Export
Imports Telerik.Data
Imports System.ComponentModel

Public Class frmProductoPedirLista
    Private permiso As New clsPermisoUsuario
    Public filtroActivo As Boolean

    Private Sub frmProductoPedirLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmProductosBarraIzquierda
            iz.frmAnterior = Me

            frmBarraLateralBaseIzquierda = iz
            'frmBarraLateralBaseDerecha = frmProductosBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception
        End Try

        pnx0Nuevo.Visible = False
        llenagrid()
        fnConfiguracion()
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.Focus()
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text

            If filtroActivo Then
                frmProductoPedirFiltro.fnFiltrar()
            Else
                Dim productoInfo = ctx.sp_lista_articulosPedir(mdlPublicVars.General_idTipoInventario, mdlPublicVars.idEmpresa, Today.AddYears(-1), Today, "")
                Me.grdDatos.DataSource = productoInfo
            End If

            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.ColumnCount > 0 Then
                Me.grdDatos.Columns("Codigo").Width = 50
                Me.grdDatos.Columns("Codigo2").Width = 40
                Me.grdDatos.Columns("Nombre").Width = 115
                Me.grdDatos.Columns("Nombre2").Width = 60
                Me.grdDatos.Columns("Marca").Width = 50
                Me.grdDatos.Columns("Modelo").Width = 70
                Me.grdDatos.Columns("Existencia").Width = 35
                Me.grdDatos.Columns("Por_Pedir").Width = 35
                Me.grdDatos.Columns("Costo").Width = 45
                Me.grdDatos.Columns("TotalVenta").Width = 45
                Me.grdDatos.Columns("UltimaFechaVenta").Width = 40

                mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Costo")

                mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "UltimaFechaVenta")
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Articulos para Pedidos"
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

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar
        frmProductoPedirFiltro.Text = "Filtro: PRODUCTOS"
        frmProductoPedirFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmProductoPedirFiltro, False)
    End Sub

End Class
