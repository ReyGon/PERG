Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmEmpresas
    Dim r As New clsReporte


    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub



    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.errores.Controls.Add(Me.txtNombre, "Nombre")
        Me.errores.SummaryMessage = "Faltan datos"
        llenarCombos()
        llenagrid()
    End Sub

    Private Sub llenarCombos()


        Dim cas2 = From s In ctx.tblpais _
                  Select Codigo = s.idpais, Nombre = s.nombre

        With Me.cmbPais
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = cas2
        End With


    End Sub

    Private Sub llenagrid()

        Dim companyInfo = From x In ctx.tblEmpresas Where x.idEmpresa > 0 _
                Select Codigo = x.idEmpresa, Nombre = x.nombre, chkHabilitada = x.habilitada, Direccion = x.direccion, Telefono = x.telefono, _
                CodigoPostal = x.codigoPostal, Nit = x.nit, Responsable = x.responsable, Pais = x.tblMunicipio.tbldepartamento.tblregion.tblpai.nombre, _
                Region = x.tblMunicipio.tbldepartamento.tblregion.nombre, Departamento = x.tblMunicipio.tbldepartamento.nombre, Municipio = x.tblMunicipio.nombre

        Me.grdDatos.DataSource = companyInfo
    End Sub


    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblEmpresa
        Try
            m.nombre = txtNombre.Text
            m.nit = txtNit.Text
            m.direccion = txtDireccion.Text
            m.idmunicipio = CType(cmbMunicipio.SelectedValue, Integer)
            m.habilitada = chkHabilitada.Checked
            m.telefono = txtTelefono.Text
            m.responsable = txtResponsable.Text

            ctx.AddTotblEmpresas(m)
            ctx.SaveChanges()

            alertas.fnGuardar()

            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro

        Try
            Dim m As tblEmpresa = (From e1 In ctx.tblEmpresas Where e1.idEmpresa = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.nit = txtNit.Text
            m.direccion = txtDireccion.Text
            m.idmunicipio = CType(cmbMunicipio.SelectedValue, Integer)
            m.habilitada = chkHabilitada.Checked
            m.telefono = txtTelefono.Text
            m.responsable = txtResponsable.Text

            ctx.SaveChanges()
            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If


        Try
            'obtenemos el municipio
            Dim m As tblEmpresa = (From e1 In ctx.tblEmpresas Where e1.idEmpresa = Me.txtCodigo.Text Select e1).First()
            ctx.DeleteObject(m)
            ctx.SaveChanges()
            alertas.fnEliminar()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub cmbPais_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedValueChanged
        Try
            Dim cas = From s In ctx.tblregions.AsEnumerable _
                      Where s.idpais = CType(cmbPais.SelectedValue, Integer)
                      Select Codigo = s.idregion, Nombre = s.nombre

            Dim tbl As New DataTable
            tbl.Columns.Add("Codigo")
            tbl.Columns.Add("Nombre")

            Dim u
            For Each u In cas
                tbl.Rows.Add(CType(u.codigo, Integer), u.nombre)
            Next


            With Me.cmbRegion
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tbl
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbDepartamento_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedValueChanged
        Try
            Dim cas = From s In ctx.tblMunicipios.AsEnumerable _
                        Where s.iddepartamento = CType(cmbDepartamento.SelectedValue, Integer)
                        Select Codigo = s.idmunicipio, Nombre = s.nombre
            Dim tbl As New DataTable
            tbl.Columns.Add("Codigo")
            tbl.Columns.Add("Nombre")

            Dim u
            For Each u In cas
                tbl.Rows.Add(CType(u.codigo, Integer), u.nombre)
            Next


            With Me.cmbMunicipio
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tbl
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbRegion_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedValueChanged
        Try
            Dim cas = From s In ctx.tbldepartamentoes.AsEnumerable _
                        Where s.idregion = CType(cmbRegion.SelectedValue, Integer)
                        Select Codigo = s.iddepartamento, Nombre = s.nombre

            Dim tbl As New DataTable
            tbl.Columns.Add("Codigo")
            tbl.Columns.Add("Nombre")

            Dim u
            For Each u In cas
                tbl.Rows.Add(CType(u.codigo, Integer), u.nombre)
            Next


            With Me.cmbDepartamento
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tbl
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class
