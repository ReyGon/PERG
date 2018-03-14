Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCorrelativos

    Private Sub frmCorrelativos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar los combos
    Private Sub llenarCombos()
        Try
            'Tipos de Movimientos
            Dim movimientos = (From x In ctx.tblTipoMovimientoes Where x.ajuste = False And x.traslado = False _
                               Select Codigo = x.idTipoMovimiento, Nombre = x.nombre)

            With cmbTipoMovimiento
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = movimientos
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblCorrelativos _
                       Select Codigo = x.idCorrelativo, TipoMovimiento = x.tblTipoMovimiento.nombre, Correlativo = x.correlativo, _
                        Inicio = x.inicio, Fin = x.fin, Serie = x.serie, Aviso = x.porcentajeAviso

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
        Me.cmbTipoMovimiento.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.cmbTipoMovimiento.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblCorrelativo
        Try
            m.idTipoMovimiento = CInt(cmbTipoMovimiento.SelectedValue)
            m.correlativo = CInt(txtCorrelativo.Text)
            m.inicio = CInt(txtInicio.Text)
            m.fin = CInt(txtFin.Text)
            m.serie = txtSerie.Text
            m.porcentajeAviso = CInt(txtAviso.Text)
            ctx.AddTotblCorrelativos(m)
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
            Dim m As tblCorrelativo = (From e1 In ctx.tblCorrelativos Where e1.idCorrelativo = Me.txtCodigo.Text Select e1).First()
            m.idTipoMovimiento = CInt(cmbTipoMovimiento.SelectedValue)
            m.correlativo = CInt(txtCorrelativo.Text)
            m.inicio = CInt(txtInicio.Text)
            m.fin = CInt(txtFin.Text)
            m.serie = txtSerie.Text
            m.porcentajeAviso = CInt(txtAviso.Text)
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
            Dim m As tblCorrelativo = (From e1 In ctx.tblCorrelativos Where e1.idCorrelativo = Me.txtCodigo.Text Select e1).First()
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
        frmDocumentosSalida.txtTitulo.Text = "Lista: Correlativos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
