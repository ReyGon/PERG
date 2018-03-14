Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmFacturasListaBarraDerecha
    Private permiso As New clsPermisoUsuario
    Public alerta As bl_Alertas


    Private Sub frmFacturasBarraDerecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                Dim codigo As Integer = mdlPublicVars.superSearchId

                If codigo > 0 Then
                    frmSalidaEnvio.Text = "Guias"
                    frmSalidaEnvio.Codigo = codigo
                    frmSalidaEnvio.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoMantenimientoTelerik(frmSalidaEnvio, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        frmClienteDevolucion.Text = "Devoluciones"
        frmClienteDevolucion.MdiParent = frmMenuPrincipal
        frmClienteDevolucion.WindowState = FormWindowState.Maximized
        permiso.PermisoFrmEspeciales(frmClienteDevolucion, False)
    End Sub


    Private Sub fnPanel3() Handles Me.panel3

        If fnError() Then
            RadMessageBox.Show("No se Puede Ajustar la Factura, esta ya ha sido Anulada", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            Try
                frmFacturasLista.fnCambioFila()
                If mdlPublicVars.superSearchFilasGrid > 0 Then
                    frmFacturaDescuento.codigo = mdlPublicVars.superSearchId
                    frmFacturaDescuento.Text = "Ajuste Factura"
                    frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
                    frmFacturaDescuento.ShowDialog()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If



    End Sub


    'Private Sub fnPanel4() Handles Me.panel4
    '    Try
    '        If mdlPublicVars.superSearchFilasGrid > 0 Then
    '            Dim codigo As Integer = mdlPublicVars.superSearchId

    '            If codigo > 0 Then
    '                frmEstadisticaVenta.Text = "Estadistica"
    '                frmEstadisticaVenta.codigoFactura = codigo
    '                frmEstadisticaVenta.StartPosition = FormStartPosition.CenterScreen
    '                frmEstadisticaVenta.ShowDialog()

    '                'permiso.PermisoMantenimientoTelerik(frmEstadisticaVenta, False)
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Function fnError() As Boolean

        frmFacturasLista.fnCambioFila()
        Dim codigo As Integer = mdlPublicVars.superSearchId

        Dim f As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigo).FirstOrDefault

        If (f.anulado = True) Then
            Return True
        Else
            Return False
        End If

    End Function



    Private Sub fnEstadoFactura() Handles Me.panel4
        Try

            frmEstadoFacturas.Text = "Reporte Factura"
            frmEstadoFacturas.StartPosition = FormStartPosition.CenterScreen
            frmEstadoFacturas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

End Class
