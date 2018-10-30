Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient


Public Class frmBancoConceptoAjuste
    'Cargar la barra izquierda de opciones del banco
    Private Sub frmBancoConceptoAjuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim iz As New frmBancoBarraIzquierda
            iz.frmAnterior = Me
            frmBancoBarraIzquierda = iz
            ActivarBarraLateral = True
        Catch ex As Exception
            llenagrid()
        End Try
    End Sub

    Private Sub frm_siceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Consultamos todos los registros de la tabla
                Dim Data = From x In conexion.tblconcepto_ajustebancario
                           Select Codigo = x.idconcepto, Nombre = x.concepto, chkCredito = x.bitAumento, chkDebito = x.bitDecremento, chkEstado = x.habilitado

                ''Llenamos el grid de los datos con la consulta..
                Me.grdDatos.DataSource = Data
                grdDatos.Columns(0).Width = 150

                lbl4Reporte.Visible = False
                pbx4Reporte.Visible = False
                pnx4Reporte.Visible = False

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaregistro() Handles Me.grabaRegistro
        Try
            If Not chkCredito.Checked And Not chkDebito.Checked Then
                RadMessageBox.Show("Debe de elegir un tipo de concepto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                chkCredito.Focus()
                Exit Sub
            End If

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim m As New tblconcepto_ajustebancario

                m.concepto = txtNombre.Text
                m.bitAumento = chkCredito.Checked
                m.bitDecremento = chkDebito.Checked
                m.habilitado = chkEstado.Checked

                conexion.AddTotblconcepto_ajustebancario(m)
                conexion.SaveChanges()

                conn.Close()
            End Using

            frmNotificacion.lblNotificacion.Text = "Registo Guardado" + vbLf + "Correctamente"
            frmNotificacion.Show()

            llenagrid()
        Catch ex As Exception
            frmNotificacion.lblNotificacion.Text = "El error: " + vbLf + CStr(ex.Message)
            frmNotificacion.Show()
        End Try

    End Sub

    Private Sub frm_modificarRegistro() Handles Me.modificaRegistro
        Try
            If Not chkCredito.Checked And Not chkDebito.Checked Then
                RadMessageBox.Show("Debe de elegir un tipo de concepto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                chkCredito.Focus()
                Exit Sub
            End If

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim m As tblconcepto_ajustebancario = (From e1 In conexion.tblconcepto_ajustebancario Where e1.idconcepto = Me.txtCodigo.Text Select e1).FirstOrDefault()
                m.concepto = txtNombre.Text
                m.bitAumento = chkCredito.Checked
                m.bitDecremento = chkDebito.Checked
                m.habilitado = chkEstado.Checked

                conexion.SaveChanges()

                conn.Close()
            End Using

            frmNotificacion.lblNotificacion.Text = "Registro Modificado" + vbLf + "Correctamente"
            frmNotificacion.Show()

            llenagrid()
        Catch ex As Exception
            frmNotificacion.lblNotificacion.Text = "El error: " + vbLf + CStr(ex.Message)
        End Try
    End Sub

    Private Sub frm_eliminarRegistro() Handles Me.eliminaRegistro
        Try
            If RadMessageBox.Show("¿Esta seguro de eliminar este registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
                Exit Sub
            End If

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim m As tblconcepto_ajustebancario = (From e1 In conexion.tblconcepto_ajustebancario Where e1.idconcepto = Me.txtCodigo.Text Select e1).FirstOrDefault()

                conexion.DeleteObject(m)
                conexion.SaveChanges()

                conn.Close()
            End Using

            frmNotificacion.lblNotificacion.Text = "Registro Eliminado" + vbLf + "Correctamente"
            frmNotificacion.Show()

            llenagrid()
        Catch ex As Exception
            frmNotificacion.lblNotificacion.Text = "El error: " + vbLf + CStr(ex.Message)
        End Try 
    End Sub

    Private Sub Salir_formClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    'Concepto Debito
    Private Sub chkDebito_chekedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebito.CheckedChanged
        If chkDebito.Checked Then
            chkCredito.Checked = False
        End If
    End Sub

    'Concepto Creditos
    Private Sub chkCredito_chekedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCredito.CheckedChanged
        If chkCredito.Checked Then
            chkDebito.Checked = False
        End If
    End Sub

End Class

