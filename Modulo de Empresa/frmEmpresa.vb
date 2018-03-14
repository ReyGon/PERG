Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI

Public Class frmEmpresa

    Private Sub frmEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        llenagrid()
        grdDatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None

        Dim index
        For index = 0 To Me.grdDatos.Columns.Count - 1
            grdDatos.Columns(index).Width = 150
        Next

    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar los paises
    Private Sub llenarCombos()
        Try
            'Paises
            Dim pais = (From x In ctx.tblpais Select Codigo = x.idpais, Nombre = x.nombre)

            With cmbPais
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = pais
            End With

            'Inventarios
            Dim inv = (From x In ctx.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre)
            Dim inv2 = (From x In ctx.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre)
            Dim inv3 = (From x In ctx.tblTipoInventarios Select Codigo = x.idTipoinventario, Nombre = x.nombre)

            With cmbInventarioGeneral
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = inv
            End With

            With cmbLiquidacion
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = inv2
            End With

            With cmbDevolucionCliente
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = inv3
            End With


            Dim precio1 = (From x In ctx.tblArticuloTipoPrecios Select Codigo = x.codigo, Nombre = x.nombre)
            Dim precio2 = (From x In ctx.tblArticuloTipoPrecios Select Codigo = x.codigo, Nombre = x.nombre)
            Dim precio3 = (From x In ctx.tblArticuloTipoPrecios Select Codigo = x.codigo, Nombre = x.nombre)

            With cmbPrecioEspecial
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = precio1
            End With

            With cmbPrecioNormal
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = precio2
            End With

            With cmbPrecioOferta
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = precio2
            End With



        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblEmpresas _
                       Select Codigo = x.idEmpresa, Nombre = x.nombre, Direccion = x.direccion, Telefono = x.telefono, Nit = x.nit, _
                       CodigoPostal = x.codigoPostal, Responsable = x.responsable, Pais = x.tblMunicipio.tbldepartamento.tblregion.tblpai.nombre, _
                       Departamento = x.tblMunicipio.tbldepartamento.nombre, Municipio = x.tblMunicipio.nombre, chkHabilitada = x.habilitada


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

        Dim m As New tblEmpresa
        Try
            m.nombre = txtNombre.Text
            m.codigoPostal = txtCodigoPostal.Text
            m.direccion = txtDireccion.Text
            m.habilitada = chkHabilitada.Checked
            m.idmunicipio = cmbMunicipio.SelectedValue

            m.nit = txtNit.Text
            m.nombre = txtNombre.Text
            m.responsable = txtResponsable.Text
            m.telefono = txtTelefono.Text

            ctx.AddTotblEmpresas(m)
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

            Dim m As tblEmpresa = (From e1 In ctx.tblEmpresas Where e1.idEmpresa = Me.txtCodigo.Text Select e1).First()

            m.nombre = txtNombre.Text
            m.codigoPostal = txtCodigoPostal.Text
            m.direccion = txtDireccion.Text
            m.habilitada = chkHabilitada.Checked
            m.idmunicipio = cmbMunicipio.SelectedValue

            m.nit = txtNit.Text
            m.nombre = txtNombre.Text
            m.responsable = txtResponsable.Text
            m.telefono = txtTelefono.Text

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
            Dim m As tblEmpresa = (From e1 In ctx.tblEmpresas Where e1.idEmpresa = Me.txtCodigo.Text Select e1).First()

            m.habilitada = False
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub cmbPais_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedValueChanged
        Try
            Dim pais As Integer = cmbPais.SelectedValue
            Dim departamentos = (From x In ctx.tbldepartamentoes Where x.tblregion.idpais = pais _
                                 Select Codigo = x.iddepartamento, Nombre = x.nombre)

            With cmbDepartamento
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = departamentos
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbDepartamento_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedValueChanged
        Try
            Dim departamento As Integer = cmbDepartamento.SelectedValue
            Dim municipios = (From x In ctx.tblMunicipios Where x.iddepartamento = departamento _
                             Select Codigo = x.idmunicipio, Nombre = x.nombre)

            With cmbMunicipio
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = municipios
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmEmpresa_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Empresas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

End Class
