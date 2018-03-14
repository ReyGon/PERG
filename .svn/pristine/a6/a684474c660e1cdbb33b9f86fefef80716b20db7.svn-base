Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient



Public Class frmClienteNegocio

    Public codigoCliente As Integer

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenagrid()
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub


    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(panelDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()

        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblclienteNegocios _
                       Where x.idcliente = codigoCliente
                       Select Codigo = x.idclientenegocio, Nombre = x.nombre, Nit = x.nit

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data

        Catch ex As Exception

        End Try

    End Sub


    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblclienteNegocio
        Try
            m.nombre = txtNombre.Text
            m.nit = txtNit.Text
            m.idcliente = codigoCliente

            ctx.AddTotblclienteNegocios(m)
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

            Dim m As tblclienteNegocio = (From e1 In ctx.tblclienteNegocios Where e1.idclientenegocio = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.nit = txtNit.Text

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
            Dim m As tblclienteNegocio = (From e1 In ctx.tblclienteNegocios Where e1.idclientenegocio = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

End Class
