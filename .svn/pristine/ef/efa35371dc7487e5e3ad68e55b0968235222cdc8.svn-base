Imports System.Linq

Public Class frmVendedor

    Private Sub frmCorrelativos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnCrearCarpeta(mdlPublicVars.General_CarpetaFotosVendedor)
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar los combos
    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblVendedors Select Codigo = x.idVendedor, Nombre = x.nombre, chkHabilitado = x.habilitado

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblVendedor
        Try
            m.nombre = txtNombre.Text
            m.habilitado = chkHabilitado.Checked
            m.empresa = mdlPublicVars.idEmpresa
            ctx.AddTotblVendedors(m)
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
            Dim m As tblVendedor = (From e1 In ctx.tblVendedors Where e1.idVendedor = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.habilitado = chkHabilitado.Checked

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
            Dim m As tblVendedor = (From e1 In ctx.tblVendedors Where e1.idVendedor = Me.txtCodigo.Text Select e1).First()
            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub frmUsuario_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Vendedores"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub btnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagen.Click
        If Not txtCodigo.Text.Equals("") Then
            frmCapturarFoto.Text = "Imagen: Vendedor"
            frmCapturarFoto.bitVendedor = True
            frmCapturarFoto.codigo = CInt(txtCodigo.Text)
            frmCapturarFoto.StartPosition = FormStartPosition.CenterScreen
            frmCapturarFoto.ShowDialog()
            frmCapturarFoto.Dispose()
        End If
    End Sub
End Class
