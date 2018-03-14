Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMovimientoInventariosConceptosLista
    Private permiso As New clsPermisoUsuario

    Private Sub frmMovimientoInventariosConceptosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"
        Try
            Dim iz As New frmMovimientoInventariosBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmMovimientoInventariosBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try

        llenagrid()
        fnConfiguracion()
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            Dim listaMovimientos = (From x In ctx.tblMovimientoInventarioDetalles Where x.movimientoInventario > 0 Select Codigo = x.tblArticulo.codigo1, _
                                      Articulo = x.tblArticulo.nombre1, Concepto = x.tblTipoMovimiento.nombre, Documento = x.tblMovimientoInventario.documento, Cantidad = x.cantidad, Costo = x.costo, Total = x.total)

            Me.grdDatos.DataSource = listaMovimientos

        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnConfiguracion()
        Try
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Costo")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

            For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdDatos.Columns("Codigo").Width = 50
            Me.grdDatos.Columns("Articulo").Width = 200
            Me.grdDatos.Columns("Concepto").Width = 100
            Me.grdDatos.Columns("Documento").Width = 80
            Me.grdDatos.Columns("Cantidad").Width = 80
            Me.grdDatos.Columns("Costo").Width = 80
            Me.grdDatos.Columns("Total").Width = 80
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        alertas.contenido = "Concepto no se puede modificar"
        alertas.fnErrorContenido()
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        alertas.contenido = "Concepto no se puede eliminar"
        alertas.fnErrorContenido()
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro

    End Sub

    Private Sub frmMovimientoInventariosConceptosLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Conceptos de Movimientos de Inventario"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
