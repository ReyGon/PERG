Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmProveedorLista
    Public filtroActivo As Boolean
    Dim permiso As New clsPermisoUsuario
    Private Sub frmProveedorLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmProveedorLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            lbl2Eliminar.Text = "Deshabilitar"
            Dim iz As New frmProveedorBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmProveedorBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
        fnLlenarCombo()
        llenagrid()

    End Sub

    Private Sub fnLlenarCombo()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim pro = (From x In conexion.tblProveedorProcedencias Where x.bitLocal = True Select Codigo = x.codigo, Nombre = x.nombre)

                With cmbTipoProveedor
                    .DataSource = Nothing
                    .DisplayMember = "Nombre"
                    .ValueMember = "Codigo"
                    .DataSource = pro
                End With

                conn.Close()
            End Using

            ''Dim dt As DataTable = New DataTable("Tabla")

            ''dt.Columns.Add("Codigo")
            ''dt.Columns.Add("Descripcion")

            ''Dim dr As DataRow

            ''dr = dt.NewRow()
            ''dr("Codigo") = "0"
            ''dr("Descripcion") = "Mercaderia"
            ''dt.Rows.Add(dr)

            ''dr = dt.NewRow()
            ''dr("Codigo") = "1"
            ''dr("Descripcion") = "Insumos"
            ''dt.Rows.Add(dr)

            ''cmbTipoProveedor.DataSource = dt
            ''cmbTipoProveedor.ValueMember = "Codigo"
            ''cmbTipoProveedor.DisplayMember = "Descripcion"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            Dim procedencia As Integer = Me.cmbTipoProveedor.SelectedValue
            Dim conexion As dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim consulta As DataTable = EntitiToDataTable(From x In conexion.sp_lista_proveedores(mdlPublicVars.idEmpresa, filtro, procedencia))
                Me.grdDatos.DataSource = consulta
                'Para saber cuantas filas tiene el grid
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                fnConfiguracion()
                conn.Close()
            End Using

            'fnEstableceFechas()
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para establecer la proxima fecha de pago del cliente
    Public Sub fnEstableceFechas()
        Try
            'Recorremos el grid de proveedores
            Dim i
            Dim codPro As Integer = 0
            For i = 0 To Me.grdDatos.Rows.Count - 1
                'Obtenemos el codigo del proveedor
                codPro = Me.grdDatos.Rows(i).Cells("Codigo").Value

                Dim proximaFecha As DateTime = Today
                Dim minimo As DateTime = Nothing
                'Obtenemos la lista de compras a ese proveedor
                Dim lEntrada As List(Of tblEntrada) = (From x In ctx.tblEntradas Where x.idProveedor = codPro _
                                                     Select x Order By x.fechaPago Ascending).ToList

                For Each entrada As tblEntrada In lEntrada
                    minimo = Today
                    'Si fue al credito
                    If entrada.credito = True Then
                        'Obtenemos la fecha de pago
                        If entrada.fechaPago >= proximaFecha Then
                            minimo = entrada.fechaPago
                            Exit For
                        End If
                    End If
                Next
                Me.grdDatos.Rows(i).Cells("ProximaFechaPago").Value = minimo.ToShortDateString
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count >= 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "UltimaCompra")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "SaldoTransito")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "SaldoFisico")

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("UltimaCompra").HeaderText = "Ultima Compra"
                Me.grdDatos.Columns("chkHabilitado").HeaderText = "Habilitado"
                Me.grdDatos.Columns("Codigo").IsVisible = False
                Me.grdDatos.Columns("Clasificacion").Width = 110
                Me.grdDatos.Columns("Codigo").Width = 80
                Me.grdDatos.Columns("Clave").Width = 60
                Me.grdDatos.Columns("Nombre").Width = 200
                Me.grdDatos.Columns("chkHabilitado").Width = 60
                Me.grdDatos.Columns("Telefono").Width = 90
                Me.grdDatos.Columns("UltimaCompra").Width = 80
                Me.grdDatos.Columns("SaldoFisico").Width = 80
                Me.grdDatos.Columns("SaldoTransito").Width = 80
                Me.grdDatos.Columns("Procedencia").Width = 65
                Me.grdDatos.Columns("ProximaFechaPago").Width = 80
                Me.grdDatos.Columns("TipoPago").Width = 75
                Me.grdDatos.Columns("TipoGasto").Width = 75
                Me.grdDatos.Columns("Procedencia").IsVisible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        Try
            frmProveedor.Text = "Modulo de Proveedores"
            frmProveedor.NuevoIniciar = True
            frmProveedor.proveedorlocal = True
            frmProveedor.StartPosition = FormStartPosition.CenterScreen
            frmProveedor.WindowState = FormWindowState.Normal
            permiso.PermisoDialogMantenimientoTelerik2(frmProveedor)
            frmProveedor.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Dim codigo As Integer = fnCambioFila()
        If codigo = -1 Then
            Exit Sub
        End If

        Try
            frmProveedor.seleccionDefault = True
            frmProveedor.codigoDefault = codigo
            frmProveedor.NuevoIniciar = False
            frmProveedor.proveedorlocal = True
            frmProveedor.Text = "Modulo de Proveedores"
            permiso.PermisoDialogMantenimientoTelerik2(frmProveedor)
            frmProveedor.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            Dim codigo As Integer = fnCambioFila()
            If codigo = -1 Then
                Exit Sub
            End If

            fnDeshabilita(codigo)
            Call llenagrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Try

            Dim codigo As Integer = fnCambioFila()
            If codigo = -1 Then
                Exit Sub
            End If

            Dim permiso As New clsPermisoUsuario
            frmProveedor.seleccionDefault = True
            frmProveedor.codigoDefault = codigo
            frmProveedor.NuevoIniciar = False
            frmProveedor.proveedorlocal = True
            frmProveedor.verRegistro = True
            frmProveedor.Text = "Modulo de Proveedores"
            permiso.PermisoDialogMantenimientoTelerik2(frmProveedor)
            frmProveedor.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para desabilitar un proveedor
    Private Sub fnDeshabilita(ByVal codigo As Integer)

        If RadMessageBox.Show("Desea anular !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim success As Boolean = True

            Try
                'Obtenemos el cliente con ese codigo
                Dim cli As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault

                'Deshabilitamos al cliente
                cli.habilitado = False
                ctx.SaveChanges()
            Catch ex As Exception
                success = False
            End Try

            If success = True Then
                alertas.fnModificar()
            Else
                alertas.fnErrorModificar()
            End If
        End If

    End Sub

    Public Function fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Dim codigo As Integer = 0
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim index As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                codigo = CType(Me.grdDatos.Rows(index).Cells("Codigo").Value, Integer)
                mdlPublicVars.superSearchId = codigo
            End If
        Catch ex As Exception
            codigo = -1
            alertas.contenido = "Error al seleccionar Registro "
        End Try

        Return codigo
    End Function

    Private Sub fnFiltros() Handles Me.Exportar
        frmProveedorFiltro.Text = "Filtro: PROVEEDORES"
        frmProveedorFiltro.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoFrmEspeciales(frmProveedorFiltro, False)
    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Proveedores"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub cmbTipoProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoProveedor.SelectedValueChanged
        Try
            If Me.cmbTipoProveedor.SelectedValue >= 0 Then
                llenagrid()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class