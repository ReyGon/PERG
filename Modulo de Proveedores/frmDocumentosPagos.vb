Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmDocumentosPagos

    Private _codigo As Integer

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmDocumentosPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnCargarDatos()
    End Sub

    Private Sub fnCargarDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigo Select x).FirstOrDefault

                Me.txtdocumentoboleta.Text = pago.docboletadeposito
                Me.txtdocumentofactura.Text = pago.documentofactura
                Me.txtDocumentoPago.Text = pago.documento

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim pago As tblCaja = (From x In conexion.tblCajas Where x.codigo = codigo Select x).FirstOrDefault

                pago.docboletadeposito = Me.txtdocumentoboleta.Text
                pago.documentofactura = Me.txtdocumentofactura.Text
                pago.documento = Me.txtDocumentoPago.Text

                conexion.SaveChanges()

                conn.Close()
            End Using

            RadMessageBox.Show("Documentos Actualizados Correctamente!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        Catch ex As Exception
            RadMessageBox.Show("Ocurrio un Error al actualizar los documentos!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End Try
    End Sub
End Class
