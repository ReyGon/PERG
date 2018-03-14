Imports System.Linq
Imports Telerik.WinControls

Public Class frmPendientePedirLista

    Public registroActual As Integer = 0
    Private Sub frmPedidosPendienteSurtir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl2Eliminar.Text = "Anular"

        Try
            Dim iz As New frmProductosBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try
        llenagrid()
        fnConfiguracion()
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text

            'Realizamos la consulta
            Dim consulta = (From x In ctx.tblPendientePorPedirs Where x.tblCliente.Negocio.Contains(filtro) Or x.descripcion.Contains(filtro)
                            Select codigo = x.codigo, Fecha = x.fechaRegistro, Cliente = x.tblCliente.Negocio, Articulo = x.descripcion, _
                            Importancia = x.tblArticuloImportancia.nombre, Saldo = x.saldo, chkCreado = x.bitCreado, chkAnulado = x.anulado)

            Me.grdDatos.DataSource = consulta

            Me.grdDatos.Rows(registroActual).IsCurrent = True

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            If Me.grdDatos.Rows.Count = 1 Then
                fnConfiguracion()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Columns.Count > 0 Then
                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")

                'codigo, Fecha , Cliente , Articulo , _
                'Importancia , Saldo , chkCreado , chkAnulado 

                Me.grdDatos.Columns("codigo").IsVisible = False
                Me.grdDatos.Columns("Fecha").Width = 60
                Me.grdDatos.Columns("Cliente").Width = 80
                Me.grdDatos.Columns("Articulo").Width = 95
                Me.grdDatos.Columns("Importancia").Width = 65
                Me.grdDatos.Columns("Saldo").Width = 50
                Me.grdDatos.Columns("chkCreado").Width = 60
                Me.grdDatos.Columns("chkAnulado").Width = 60


            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        If Me.grdDatos.CurrentRow.Index >= 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(fila).Cells("codigo").Value, Integer)
        End If

    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Dim codigo As Integer = mdlPublicVars.superSearchId
        If RadMessageBox.Show("¿Desea anular el pendiente por pedir?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnEliminaPendiente(codigo)
        End If

    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        RadMessageBox.Show("No se puede modificar un pendiente por pedir", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    End Sub

    Private Sub frmPedidosPendienteSurtir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'Elimina pendiente por pedir
    Private Sub fnEliminaPendiente(idPendiente As Integer)
        Dim fechaServer As DateTime = mdlPublicVars.nombreSistema
        Try
            Dim respuesta As String = InputBox("Observación del por que de la anulación", mdlPublicVars.nombreSistema, "Observacion")

            Dim pendiente As tblPendientePorPedir = (From x In ctx.tblPendientePorPedirs
                                                Where x.codigo = idPendiente
                                                Select x).FirstOrDefault
            pendiente.anulado = True
            pendiente.anuladofecha = fechaServer
            pendiente.anuladoComentario = respuesta
            pendiente.anuladoUsuario = mdlPublicVars.idUsuario

            ctx.SaveChanges()
            alertas.contenido = "Pendiente anulado exitosamente"
            alertas.fnErrorContenido()
            llenagrid()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try




    End Sub

End Class