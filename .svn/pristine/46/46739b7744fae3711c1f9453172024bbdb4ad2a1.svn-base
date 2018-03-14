Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmClienteDevolucionConceptosLista
    Private permiso As New clsPermisoUsuario

    Private Sub frmClienteDevolucionConceptosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            Dim listaMovimientos = (From x In ctx.tblDevolucionClienteDetalles _
                                    Where x.tblDevolucionCliente.acreditado = True And x.tblDevolucionCliente.anulado = False And x.cantidadAceptada > 0 _
                                    Select Codigo = x.tblArticulo.codigo1, Fecha = x.tblDevolucionCliente.fechaRegistro, Cliente = x.tblDevolucionCliente.tblCliente.Negocio, Responsable = x.tblVendedor.nombre, _
                                    Articulo = x.tblArticulo.nombre1, Inventario = x.tblTipoInventario.nombre, Documento = x.tblDevolucionCliente.documento, Cantidad = x.cantidadAceptada, Precio = x.costo, Total = x.total)

            Me.grdDatos.DataSource = listaMovimientos
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnConfiguracion()
        Try
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Precio")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
            For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdDatos.Columns("Codigo").Width = 60
            Me.grdDatos.Columns("Fecha").Width = 70
            Me.grdDatos.Columns("Articulo").Width = 180
            Me.grdDatos.Columns("Responsable").Width = 120
            Me.grdDatos.Columns("Inventario").Width = 100
            Me.grdDatos.Columns("Cliente").Width = 120
            Me.grdDatos.Columns("Documento").Width = 65
            Me.grdDatos.Columns("Cantidad").Width = 50
            Me.grdDatos.Columns("Precio").Width = 70
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
        frmDocumentosSalida.txtTitulo.Text = "Lista Conceptos de Devoluciones de Clientes"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
