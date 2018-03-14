Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmTiposPago

    Private Sub frmTiposPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmClientesBarraIzquierda
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
            Dim Data = From x In ctx.tblTipoPagoes Select Codigo = x.codigo, Nombre = x.nombre, chkCalendarizada = x.calendarizada, _
                       chkEntrada = x.entrada, chkSalida = x.salida

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            grdDatos.Columns(0).Width = 150
        Catch e As Exception
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

        Dim m As New tblTipoPago
        Try
            m.nombre = txtNombre.Text

            If chkCalendarizada.Checked = True Then
                m.calendarizada = True
                m.transito = True
            Else
                m.calendarizada = False
                m.transito = False
            End If

            m.entrada = chkEntrada.Checked
            m.salida = chkSalida.Checked

            ctx.AddTotblTipoPagoes(m)
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

            Dim m As tblTipoPago = (From e1 In ctx.tblTipoPagoes Where e1.codigo = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            If chkCalendarizada.Checked = True Then
                m.calendarizada = True
                m.transito = True
            Else
                m.calendarizada = False
                m.transito = False
            End If

            m.entrada = chkEntrada.Checked
            m.salida = chkSalida.Checked
            ctx.SaveChanges()

            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblTipoPago = (From e1 In ctx.tblTipoPagoes Where e1.codigo = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub chkEntrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEntrada.CheckedChanged
        If chkEntrada.Checked = True Then
            chkSalida.Checked = False
        Else
            chkSalida.Checked = True
        End If
    End Sub

    Private Sub chkSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalida.CheckedChanged
        If chkSalida.Checked = True Then
            chkEntrada.Checked = False
        Else
            chkEntrada.Checked = True
        End If
    End Sub
End Class
