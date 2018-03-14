Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFacturasTipoImpresion
    Private Sub frmFacturasTipoImpresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar las impresoras
    Private Sub llenarCombos()
        Try
            'Vendedores
            Dim impresora = (From x In ctx.tblImpresoras Select Codigo = x.codigo, Nombre = x.nombre)

            With cmbImpresora
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = impresora
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblFacturaTipoImpresions _
                       Select Codigo = x.codigo, Nombre = x.nombre, PorcentajeDescuento = x.porcentajeDescuento, _
                       Impresora = x.tblImpresora.nombre, Observacion = x.observacion


            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            'grdDatos.Columns(0).Width = 150
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

        Dim m As New tblFacturaTipoImpresion
        Try
            m.nombre = txtNombre.Text
            m.impresora = CInt(cmbImpresora.SelectedValue)
            m.observacion = txtObservacion.Text
            m.porcentajeDescuento = nm2PorcentajeDescuento.Value

            ctx.AddTotblFacturaTipoImpresions(m)
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
            Dim m As tblFacturaTipoImpresion = (From e1 In ctx.tblFacturaTipoImpresions Where e1.codigo = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.impresora = CInt(cmbImpresora.SelectedValue)
            m.observacion = txtObservacion.Text
            m.porcentajeDescuento = nm2PorcentajeDescuento.Value
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
            Dim m As tblFacturaTipoImpresion = (From e1 In ctx.tblFacturaTipoImpresions Where e1.codigo = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub frmFacturasTipoImpresion_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
End Class
