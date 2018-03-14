Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.EntityClient

Public Class frmFacturaResoluciones
    Private Sub frmFacturaResoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                'Consultamos todos los registros en la tabla Surtir Categoria.. 
                Dim Data = From x In conexion.tblResolucionFacturas
                           Select Codigo = x.idResolucion, Inicio = x.inicio, Fin = x.final, Correlativo = x.correlativo, _
                                Serie = x.serie, FechaResolucion = x.fechaResolucion, Resolucion = x.resolucion, chkHabilitado = x.habilitado


                'Llenamos el grid de los datos con la consulta..
                Me.grdDatos.DataSource = Data
                grdDatos.Columns(0).Width = 150

                conn.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.nm0Inicio.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.nm0Inicio.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim m As New tblResolucionFactura
            Try
                m.inicio = nm0Inicio.Value
                m.final = nm0Fin.Value
                m.correlativo = nm0Correlativo.Value
                m.serie = txtSerie.Text
                m.fechaResolucion = dtpFechaResolucion.Text
                m.resolucion = txtResolucion.Text
                m.habilitado = chkHabilitado.Checked

                conexion.AddTotblResolucionFacturas(m)
                conexion.SaveChanges()
                alertas.fnGuardar()

                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorGuardar()
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
            Try
                Dim m As tblResolucionFactura = (From e1 In conexion.tblResolucionFacturas Where e1.idResolucion = Me.txtCodigo.Text Select e1).First()
                m.inicio = nm0Inicio.Value
                m.final = nm0Fin.Value
                m.correlativo = nm0Correlativo.Value
                m.serie = txtSerie.Text
                m.fechaResolucion = dtpFechaResolucion.Text
                m.resolucion = txtResolucion.Text
                m.habilitado = chkHabilitado.Checked

                conexion.SaveChanges()
                alertas.fnModificar()

                Call llenagrid()

            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alertas.fnErrorModificar()
            End Try
            conn.Close()
        End Using
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim m As tblResolucionFactura = (From e1 In conexion.tblResolucionFacturas Where e1.idResolucion = Me.txtCodigo.Text Select e1).First()

                conexion.DeleteObject(m)
                conexion.SaveChanges()

                alertas.fnEliminar()

                Call llenagrid()
            End Using
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
End Class