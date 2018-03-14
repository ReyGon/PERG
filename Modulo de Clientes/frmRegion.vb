﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRegion
    Private Sub frmTipoNegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmClientesBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            ActivarBarraLateral = True

        Catch ex As Exception
        End Try

        llenagrid()
        fnLlenaCombo()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblregions Select Codigo = x.idregion, x.nombre, _
                       Pais = x.tblpai.nombre

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

    'Llena el combo de departamentos
    Private Sub fnLlenaCombo()
        Try
            Dim pais = From x In ctx.tblpais _
                      Select Codigo = x.idpais, Nombre = x.nombre

            With cmbPais
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = pais
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblregion
        Try
            m.nombre = txtNombre.Text
            m.idpais = CType(cmbPais.SelectedValue, Integer)
            ctx.AddTotblregions(m)
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

            Dim m As tblregion = (From e1 In ctx.tblregions Where e1.idregion = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.idpais = CType(cmbPais.SelectedValue, Integer)

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
            Dim m As tblregion = (From e1 In ctx.tblregions Where e1.idpais = Me.txtCodigo.Text Select e1).First()

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
        frmDocumentosSalida.txtTitulo.Text = "Lista: Regiones "
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
