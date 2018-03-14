Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmConfiguracion

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frmConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenagrid()
    End Sub

    Private Sub llenagrid()

        Dim Datos = From x In ctx.tblConfiguracions
                    Select Codigo = x.id, x.parametro, x.valor

        Me.grdDatos.DataSource = Datos
    End Sub


    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblConfiguracion
        Try
            m.parametro = txtParametro.Text
            m.valor = txtValor.Text


            ctx.AddTotblConfiguracions(m)
            ctx.SaveChanges()
            alertas.fnGuardar()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro

        Try
            Dim m As tblConfiguracion = (From e1 In ctx.tblConfiguracions Where e1.id = Me.txtCodigo.Text Select e1).First()
            m.parametro = txtParametro.Text
            m.valor = txtValor.Text

            ctx.SaveChanges()
            alertas.fnModificar()
            Call llenagrid()
            llenarVariables()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Sub


    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If


        Try
            'obtenemos el municipio
            Dim m As tblConfiguracion = (From e1 In ctx.tblConfiguracions Where e1.id = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()
            alertas.fnEliminar()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Sub

    Private Sub llenarvariables()
        Dim val = From v In ctx.tblConfiguracions Select v.parametro, v.valor

        'Empezamos a llamar a cada variable de la clase mdlpublicvars y le asignamos el valor consultado
        'mdlPublicVars.InventarioMin0 

    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Configuración del Sistema"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
