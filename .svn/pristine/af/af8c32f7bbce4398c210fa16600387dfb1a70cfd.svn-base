Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmGruposFormas
    Private Sub frmGruposFormas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltroLista(cmbGrupo)
        mdlPublicVars.comboActivarFiltro(cmbFormulario)
        llenarCombos()
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar los combos
    Private Sub llenarCombos()
        Try
            'Grupos
            Dim grupos = (From x In ctx.tblGrupoUsuarios Select Codigo = x.idGrupo, Nombre = x.nombre)

            With cmbGrupo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = grupos
            End With
            'Grupos
            Dim formularios = (From x In ctx.tblFormas Select Codigo = x.idForma, Nombre = x.descripcion _
                               Order By Nombre Ascending)

            With cmbFormulario
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = formularios
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblGrupoFormas _
                       Select Codigo = x.idGrupoForma, Grupo = x.tblGrupoUsuario.nombre, Formulario = x.tblForma.descripcion, _
                       chkCrea = x.crea, chkElimina = x.elimina, chkModifica = x.modifica, chkNuevo = x.nuevo


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
        Me.cmbGrupo.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.cmbGrupo.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblGrupoForma
        Try
            m.idgrupo = CInt(cmbGrupo.SelectedValue)
            m.idForma = CInt(cmbFormulario.SelectedValue)
            m.crea = chkCrea.Checked
            m.modifica = chkModifica.Checked
            m.elimina = chkElimina.Checked
            m.nuevo = chkNuevo.Checked
            ctx.AddTotblGrupoFormas(m)
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
            Dim m As tblGrupoForma = (From e1 In ctx.tblGrupoFormas Where e1.idGrupoForma = Me.txtCodigo.Text Select e1).First()
            m.idgrupo = CInt(cmbGrupo.SelectedValue)
            m.idForma = CInt(cmbFormulario.SelectedValue)
            m.crea = chkCrea.Checked
            m.modifica = chkModifica.Checked
            m.elimina = chkElimina.Checked
            m.nuevo = chkNuevo.Checked
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
            Dim m As tblGrupoForma = (From e1 In ctx.tblGrupoFormas Where e1.idGrupoForma = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub frmGruposFormas_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Grupos y Formularios"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class