Imports System.Linq
Imports Telerik.WinControls

Public Class frmConceptosAjustes
    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmMovimientoInventariosBarraIzquierda
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
            Dim Data = From x In ctx.tblTipoMovimientoes Where x.traslado Or x.ajuste
                       Select Codigo = x.idTipoMovimiento, x.nombre, chkActualizaCosto = x.actualizaCosto, chkAjuste = x.ajuste, _
                       chkAumentaInventario = x.aumentaInventario, chkDisminuyeInventario = x.disminuyeInventario, chkEntrada = x.entrada, _
                       chkSalida = x.salida, chkTraslado = x.traslado

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            grdDatos.Columns(0).Width = 60
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

        Dim m As New tblTipoMovimiento
        Try
            m.nombre = txtNombre.Text
            m.actualizaCosto = chkActualizaCosto.Checked
            m.aumentaInventario = chkAumentaInventario.Checked
            m.disminuyeInventario = chkDisminuyeInventario.Checked
            m.entrada = chkEntrada.Checked
            m.salida = chkSalida.Checked
            m.ajuste = chkAjuste.Checked
            m.traslado = chkTraslado.Checked
            If m.traslado Then
                m.aumentaInventario = False
                m.disminuyeInventario = True
                m.salida = True
                m.entrada = False
            End If
            m.empresa = mdlPublicVars.idEmpresa
            ctx.AddTotblTipoMovimientoes(m)
            ctx.SaveChanges()

            alertas.fnGuardar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try

            Dim m As tblTipoMovimiento = (From e1 In ctx.tblTipoMovimientoes Where e1.idTipoMovimiento = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.actualizaCosto = chkActualizaCosto.Checked
            m.aumentaInventario = chkAumentaInventario.Checked
            m.disminuyeInventario = chkDisminuyeInventario.Checked
            m.entrada = chkEntrada.Checked
            m.salida = chkSalida.Checked
            m.ajuste = chkAjuste.Checked
            m.traslado = chkTraslado.Checked
            If m.traslado Then
                m.aumentaInventario = False
                m.disminuyeInventario = True
                m.salida = True
                m.entrada = False
            End If
            m.empresa = mdlPublicVars.idEmpresa
            ctx.SaveChanges()

            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If RadMessageBox.Show("Esta seguro de eliminar este registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblTipoMovimiento = (From e1 In ctx.tblTipoMovimientoes Where e1.idTipoMovimiento = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub frmSalir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Conceptos de Ajuste y Traslado"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub chkAumentaInventario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAumentaInventario.CheckedChanged
        chkDisminuyeInventario.Checked = Not chkAumentaInventario.Checked
    End Sub

    Private Sub chkEntrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEntrada.CheckedChanged
        chkSalida.Checked = Not chkEntrada.Checked
    End Sub

    Private Sub chkAjuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAjuste.CheckedChanged
        chkTraslado.Checked = Not chkAjuste.Checked
    End Sub

    Private Sub chkDisminuyeInventario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisminuyeInventario.CheckedChanged
        chkAumentaInventario.Checked = Not chkDisminuyeInventario.Checked
    End Sub

    Private Sub chkSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalida.CheckedChanged
        chkEntrada.Checked = Not chkSalida.Checked
    End Sub

    Private Sub chkTraslado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTraslado.CheckedChanged
        chkAjuste.Checked = Not chkTraslado.Checked
    End Sub
End Class
