﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmClientePequenioLista
    Public filtroActivo As Boolean
    Dim permiso As New clsPermisoUsuario

    Private Sub frmClientePequenioLista_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            lbl2Eliminar.Text = "Deshabilitar"
            Dim iz As New frmClientePequenioBarraIzquierda
            iz.frmAnterior = Me

            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmClientePequenioBarraDerecha
            ActivarBarraLateral = True
            Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Catch ex As Exception

        End Try
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ' llenagrid()
        fnLlenarCombo()
        Me.cmbEstado.SelectedValue = 1
    End Sub

    Private Sub fnLlenarCombo()
        Try

            Dim dt As DataTable = New DataTable("Tabla")

            dt.Columns.Add("Codigo")
            dt.Columns.Add("Descripcion")

            Dim dr As DataRow

            dr = dt.NewRow()
            dr("Codigo") = "0"
            dr("Descripcion") = "Deshabilitados"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "1"
            dr("Descripcion") = "Habilitados"
            dt.Rows.Add(dr)

            cmbEstado.DataSource = dt
            cmbEstado.ValueMember = "Codigo"
            cmbEstado.DisplayMember = "Descripcion"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenagrid()
        Try


            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim validacion As Integer = Me.cmbEstado.SelectedValue
                Dim val As Boolean

                Dim filtro As String = txtFiltro.Text
                conexion.CommandTimeout = 9000
                Dim companyInfo = conexion.sp_lista_clientes(mdlPublicVars.idEmpresa, filtro, validacion)

            Me.grdDatos.DataSource = companyInfo
            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                fnConfiguracion()
                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
      
    End Sub


    Private Sub fnConfiguracion()
        If Me.grdDatos.Columns.Count > 0 Then
            Try
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Saldo")
                ' mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "LimiteSaldo")
                ' mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaUltimaCompra")
                ' Me.grdDatos.Columns("LimiteSaldo").HeaderText = "Limite de Saldo"
                ' Me.grdDatos.Columns("FechaUltimaCompra").HeaderText = "Ult.Compra"

                For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("ID").IsVisible = False

                Me.grdDatos.Columns("Clave").Width = 50
                Me.grdDatos.Columns("Negocio").Width = 160
                Me.grdDatos.Columns("Saldo").Width = 80
                Me.grdDatos.Columns("Telefono").Width = 140

                'Me.grdDatos.Columns("chkHabilitado").Width = 62
                Me.grdDatos.Columns("chkHabilitado").IsVisible = False

                'Me.grdDatos.Columns("Pais").Width = 70
                Me.grdDatos.Columns("Pais").IsVisible = False

                'Me.grdDatos.Columns("Region").Width = 120
                Me.grdDatos.Columns("Categoria").IsVisible = False

                'Me.grdDatos.Columns("Departamento").Width = 90
                Me.grdDatos.Columns("Departamento").IsVisible = False

                'Me.grdDatos.Columns("Municipio").Width = 90
                Me.grdDatos.Columns("Municipio").IsVisible = False

                'Me.grdDatos.Columns("LimiteSaldo").Width = 80
                Me.grdDatos.Columns("LimiteSaldo").IsVisible = False
                'Me.grdDatos.Columns("FechaUltimaCompra").Width = 80
                Me.grdDatos.Columns("FechaUltimaCompra").IsVisible = False
                'Me.grdDatos.Columns("Vendedor").Width = 95
                Me.grdDatos.Columns("Vendedor").IsVisible = False

                Me.grdDatos.Columns("clrEstadoCred").Width = 70
                Me.grdDatos.Columns("DiasCred").Width = 60
                Me.grdDatos.Columns("clrFrecCompra").Width = 70
                Me.grdDatos.Columns("DiasCompra").Width = 60

            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub


    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        frmClienteMotrisa.seleccionDefault = False
        frmClienteMotrisa.Text = "Modulo de Clientes"
        frmClienteMotrisa.NuevoIniciar = True
        permiso.PermisoMantenimientoTelerik2(frmClienteMotrisa, False)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        frmClienteMotrisa.seleccionDefault = True
        frmClienteMotrisa.codigoDefault = mdlPublicVars.superSearchId
        frmClienteMotrisa.NuevoIniciar = False
        frmClienteMotrisa.Text = "Modulo de Clientes"
        permiso.PermisoMantenimientoTelerik2(frmClienteMotrisa, False)
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        fnDeshabilita(grdDatos.Rows(fila).Cells(0).Value())
        Call llenagrid()
    End Sub



    Private Sub frm_ver() Handles Me.verRegistro
        frmClientes.seleccionDefault = True
        frmClientes.codigoDefault = mdlPublicVars.superSearchId
        frmClientes.NuevoIniciar = False
        frmClientes.verRegistro = True
        frmClientes.Text = "Modulo de Clientes"
        permiso.PermisoMantenimientoTelerik2(frmClientes, False)
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("ID").Value, Integer)
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.RowCount
            End If

        Catch ex As Exception

        End Try

    End Sub



    'Funcion utilizada para desabilitar un cliente
    Private Sub fnDeshabilita(ByVal codigo As Integer)
        Dim success As Boolean = True

        Try
            'Obtenemos el cliente con ese codigo
            Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault

            'Deshabilitamos al cliente
            cli.habillitado = False
            ctx.SaveChanges()
        Catch ex As Exception
            success = False
        End Try

        If success = True Then
            alertas.fnModificar()
        Else
            alertas.fnErrorModificar()
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        Try
            Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = Me.grdDatos.Rows(index).Cells(0).Value

            frmDocumentosSalida.txtTitulo.Text = "Lista de Clientes"
            frmDocumentosSalida.grd = Me.grdDatos
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.codigo = codigo
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitGenerico = True
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedValueChanged
        Try
            llenagrid()
        Catch ex As Exception

        End Try
    End Sub

End Class
