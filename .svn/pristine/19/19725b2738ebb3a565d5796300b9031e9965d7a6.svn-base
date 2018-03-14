Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmBancoConceptos
    Private Sub frmBancoConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmBancoBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

        Catch ex As Exception
        End Try
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblBanco_MovimientoConcepto
                       Select Codigo = x.codigo, Nombre = x.nombre, chkCredito = x.bitCredito, chkDebito = x.bitDebito, chkCheque = x.bitCheque

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            grdDatos.Columns(0).Width = 150
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

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        If Not chkCheque.Checked And Not chkCredito.Checked And Not chkDebito.Checked Then
            RadMessageBox.Show("Debe elegir un tipo de concepto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
            chkCredito.Focus()
            Exit Sub
        End If

        Dim m As New tblBanco_MovimientoConcepto
        Try
            m.nombre = txtNombre.Text
            m.bitCheque = chkCheque.Checked
            m.bitCredito = chkCredito.Checked
            m.bitDebito = chkDebito.Checked

            ctx.AddTotblBanco_MovimientoConcepto(m)
            ctx.SaveChanges()

            alertas.fnGuardar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        If Not chkCheque.Checked And Not chkCredito.Checked And Not chkDebito.Checked Then
            RadMessageBox.Show("Debe elegir un tipo de concepto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
            chkCredito.Focus()
            Exit Sub
        End If

        Try
            Dim m As tblBanco_MovimientoConcepto = (From e1 In ctx.tblBanco_MovimientoConcepto Where e1.codigo = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.bitCheque = chkCheque.Checked
            m.bitCredito = chkCredito.Checked
            m.bitDebito = chkDebito.Checked
            ctx.SaveChanges()

            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub


    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If RadMessageBox.Show("¿Esta seguro de eliminar este registro?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblBanco_MovimientoConcepto = (From e1 In ctx.tblBanco_MovimientoConcepto Where e1.codigo = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Conceptos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    'CHEQUEA - Credito -
    Private Sub chkCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCredito.CheckedChanged
        If chkCredito.Checked Then
            chkCheque.Checked = False
            chkDebito.Checked = False
        End If
    End Sub

    'CHEQUEA - Debito -
    Private Sub chkDebito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebito.CheckedChanged
        If chkDebito.Checked Then
            chkCredito.Checked = False
            chkCheque.Checked = False
        End If
    End Sub

    'CHEQUEA - Cheque -
    Private Sub chkCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheque.CheckedChanged
        If chkCheque.Checked Then
            chkCredito.Checked = False
            chkDebito.Checked = False
        End If
    End Sub
End Class
