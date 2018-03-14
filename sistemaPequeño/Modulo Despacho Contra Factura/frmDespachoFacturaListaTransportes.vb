''Option Strict On

Imports System.Linq
Imports System.Data
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmDespachoFacturaListaTransportes

    Dim permiso As New clsPermisoUsuario
    Dim b As New clsBase
    Public confirmarentrada As Boolean = False

#Region "Eventos"

    Private Sub frmDespachoFacturaListaTransportes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
    'LOAD
    Private Sub frmDespachoFacturaLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim iz As New frmVentaPequeniaBarraIzquierda
        iz.frmAnterior = Me
        frmBarraLateralBaseIzquierda = iz

        frmBarraLateralBaseDerecha = frmDespachoFacturaBarraDerecha
        EliminarFila = False

        Me.txtFiltro.Enabled = False
        Me.txtFiltro.Visible = False
        Me.Label2.Enabled = False
        Me.Label2.Visible = False

        fnLlenarLista()

        ''mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        ''mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        mdlPublicVars.fnGrid_iconos(grdDatos)

    End Sub

    'LLENAR LISTA
    Public Sub fnLlenarLista() Handles Me.llenarLista
        fnLlenarGrid()
        fnConfiguracion()
    End Sub

    'NUEVO REGISTRO 
    Private Sub fnNuevoRegistro() Handles Me.nuevoRegistro
        Try
            Try
                frmDespachoFacturaListaAsignar.Text = "Asignar productos"
                frmDespachoFacturaListaAsignar.MdiParent = frmMenuPrincipal
                frmDespachoFacturaListaAsignar.WindowState = FormWindowState.Maximized
                If permiso.PermisoMantenimientoLista(frmDespachoFacturaListaAsignar, True) = True Then
                    fnFRMhijos_cerrar(frmDespachoFacturaListaAsignar)
                    Me.Hide()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    'VER REGISTRO ('Detalle de una nueva asignacion')
    Private Sub fnVerRegistro() Handles Me.verRegistro
        fnCambioFila()

        If Me.grdDatos.RowCount > 0 Then

            Dim formConcepto As New frmDespachoFacturaTransporteConcepto
            formConcepto.Text = "Ventas"
            formConcepto.idSalidaTransporteMedio = mdlPublicVars.superSearchId
            formConcepto.StartPosition = FormStartPosition.CenterScreen
            formConcepto.ShowDialog()
        End If
    End Sub

    'MODIFICAR REGISTRO
    Private Sub fnModificarRegistro() Handles Me.modificaRegistro

    End Sub

    'ELIMINAR REGISTRO
    Private Sub fnEliminarRegistro() Handles Me.eliminaRegistro

    End Sub

    'CAMBIO DE FILA
    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(fila).Cells("ID").Value, Integer)
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                mdlPublicVars.superSearchConfirmado = CType(Me.grdDatos.Rows(fila).Cells("chmEntrada").Value, Boolean)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub fnCambioFilaTransporte() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(fila).Cells("ID").Value, Integer)
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                mdlPublicVars.superSearchConfirmado = CType(Me.grdDatos.Rows(fila).Cells("chmEntrada").Value, Boolean)
                mdlPublicVars.superSearchTotalKms = Me.grdDatos.Rows(fila).Cells("txmTotalKms").Value
                mdlPublicVars.superSearchCostoCombustible = Me.grdDatos.Rows(fila).Cells("txmCostoCombustible").Value
                mdlPublicVars.superSearchTotalCombustible = Me.grdDatos.Rows(fila).Cells("txmTotalCombustible").Value
                mdlPublicVars.superSearchTotalPlanilla = Me.grdDatos.Rows(fila).Cells("txmTotalPlanilla").Value
                mdlPublicVars.superSearchCosto = Me.grdDatos.Rows(fila).Cells("txmCosto").Value
                mdlPublicVars.superSearchTotalCobro = Me.grdDatos.Rows(fila).Cells("txmTotalCobro").Value
                mdlPublicVars.superSearchGastosConfirmado = Me.grdDatos.Rows(fila).Cells("chmGastosEnvio").Value
            End If
        Catch ex As Exception
        End Try
    End Sub


#End Region

#Region "Funciones"
    'LLENAR LISTA
    Private Sub fnLlenarGrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim filtro As String = txtFiltro.Text
                Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_lista_despachosFacturaTransporte(mdlPublicVars.idEmpresa, "") Select x)

                Me.grdDatos.DataSource = datos
                ''fnConfiguracion()
                conn.Close()
            End Using
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'CONFIGURAR ESTILOS EN EL GRID
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            Me.grdDatos.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
            ''mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Costo")
            Me.grdDatos.Columns("ID").IsVisible = False

            Me.grdDatos.Columns("Fecha").Width = 100
            Me.grdDatos.Columns("TipoTransporte").Width = 125
            Me.grdDatos.Columns("Transporte").Width = 175
            Me.grdDatos.Columns("Pordilleros").Width = 100
            Me.grdDatos.Columns("Placas").Width = 100
            Me.grdDatos.Columns("SucursalSalida").Width = 175
            Me.grdDatos.Columns("Piloto").Width = 150
            Me.grdDatos.Columns("txmTotalKms").Width = 100
            Me.grdDatos.Columns("txmCostoCombustible").Width = 175
            Me.grdDatos.Columns("txmTotalCombustible").Width = 175
            Me.grdDatos.Columns("txmTotalPlanilla").Width = 175
            Me.grdDatos.Columns("txmCosto").Width = 100
            Me.grdDatos.Columns("txmTotalCobro").Width = 175
            Me.grdDatos.Columns("chmSalida").Width = 90
            Me.grdDatos.Columns("EstadoSalida").Width = 150
            Me.grdDatos.Columns("chmEntrada").Width = 90
            Me.grdDatos.Columns("EstadoEntrada").Width = 150
            Me.grdDatos.Columns("chmGastosEnvio").Width = 120
        End If
    End Sub

#End Region

    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)

                If (Me.grdDatos.CurrentColumn.Name = "chmSalida") Then
                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmSalida").Value
                    Dim descripcion As String = Me.grdDatos.Rows(fila).Cells("EstadoSalida").Value
                    Dim idsalida As Integer = Me.grdDatos.Rows(fila).Cells("ID").Value

                    If valor = False Then
                        If RadMessageBox.Show("Desea Enviar El Pedido", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                            Dim conexion As dsi_pos_demoEntities
                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                Dim salida As tblSalidasTransportesMedio = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = idsalida Select x).FirstOrDefault

                                salida.salida = True

                                conexion.SaveChanges()
                                conn.Close()
                            End Using
                            fnLlenarLista()
                        Else
                            fnLlenarLista()
                        End If
                    Else
                        RadMessageBox.Show("El pedido ya ha sido enviado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                        fnLlenarGrid()
                        Exit Try
                    End If

                ElseIf (Me.grdDatos.CurrentColumn.Name = "chmEntrada") Then
                    If (Me.grdDatos.Rows(fila).Cells("chmSalida").Value = True) Then
                        Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmEntrada").Value
                        Dim descripcion As String = Me.grdDatos.Rows(fila).Cells("EstadoEntrada").Value
                        Dim idsalida As Integer = Me.grdDatos.Rows(fila).Cells("ID").Value
                        Dim totalkms As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalKms").Value
                        Dim costocombustible As Decimal = Me.grdDatos.Rows(fila).Cells("txmCostoCombustible").Value
                        Dim totalcombustible As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalCombustible").Value
                        Dim totalplanilla As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalPlanilla").Value
                        Dim costo As Decimal = Me.grdDatos.Rows(fila).Cells("txmCosto").Value
                        Dim totalcobro As Decimal = Me.grdDatos.Rows(fila).Cells("txmTotalCobro").Value

                        If valor = False Then
                            If RadMessageBox.Show("Desea Confirmar que el Camion Retorno", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                frmConfirmacionEntradaTransporte.Text = "Confirmar Transporte"
                                frmConfirmacionEntradaTransporte.WindowState = FormWindowState.Normal
                                frmConfirmacionEntradaTransporte.StartPosition = FormStartPosition.CenterScreen
                                frmConfirmacionEntradaTransporte.ShowDialog()
                                frmConfirmacionEntradaTransporte.Dispose()

                                If confirmarentrada = False Then
                                    Return False
                                    Exit Function
                                End If

                                Dim conexion As dsi_pos_demoEntities
                                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                    conn.Open()
                                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                    Dim salida As tblSalidasTransportesMedio = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = idsalida Select x).FirstOrDefault

                                    salida.entrada = True
                                    If superSearchConfirmado = False Then
                                        salida.conceptoEntrada = superSearchId
                                    Else
                                        salida.conceptoEntrada = superSearchId
                                    End If
                                    conexion.SaveChanges()

                                    If superSearchConfirmado = False Then

                                        Dim reasigna As Boolean = (From x In conexion.tblConceptosEntradaTransportes Where x.codigo = superSearchId Select x.reasignar).FirstOrDefault

                                        If CBool(reasigna) = True Then

                                            frmReasignacionProductos.salida = idsalida
                                            frmReasignacionProductos.WindowState = FormWindowState.Normal
                                            frmReasignacionProductos.StartPosition = FormStartPosition.CenterScreen
                                            frmReasignacionProductos.ShowDialog()
                                            frmReasignacionProductos.Dispose()

                                        End If

                                    End If

                                    conn.Close()
                                End Using

                                fnLlenarLista()
                            Else
                                fnLlenarLista()
                            End If
                        Else
                            RadMessageBox.Show("El retorno del vehiculo ya esta confirmado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                            fnLlenarGrid()
                            Exit Try
                        End If

                    End If
                    End If

            End If
        Catch

        End Try
        Return False
    End Function

    Private Sub grdDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyDown
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                Dim col As Integer = Me.grdDatos.CurrentColumn.Index
                Dim nombre As String = Me.grdDatos.Columns(col).Name
                Dim gastosconf As Boolean = Me.grdDatos.Rows(fila).Cells("chmGastosEnvio").Value

                If gastosconf = False Then

                    If nombre = "txmTotalKms" Then

                        If e.KeyCode = Keys.Delete Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00"
                        End If

                        If e.KeyCode = Keys.Back Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                            End If
                        End If

                        If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            End If

                        ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            End If

                        ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            End If

                        ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            Me.grdDatos.Columns(nombre).ReadOnly = True
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    ElseIf nombre = "txmCostoCombustible" Then

                        If e.KeyCode = Keys.Delete Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00"
                        End If

                        If e.KeyCode = Keys.Back Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                            End If
                        End If

                        If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            End If

                        ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            End If

                        ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            End If

                        ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            Me.grdDatos.Columns(nombre).ReadOnly = True
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    ElseIf nombre = "txmTotalCombustible" Then

                        If e.KeyCode = Keys.Delete Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00"
                        End If

                        If e.KeyCode = Keys.Back Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                            End If
                        End If

                        If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            End If

                        ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            End If

                        ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            End If

                        ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            Me.grdDatos.Columns(nombre).ReadOnly = True
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    ElseIf nombre = "txmTotalPlanilla" Then

                        If e.KeyCode = Keys.Delete Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00"
                        End If

                        If e.KeyCode = Keys.Back Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                            End If
                        End If

                        If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            End If

                        ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            End If

                        ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            End If

                        ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            Me.grdDatos.Columns(nombre).ReadOnly = True
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    ElseIf nombre = "txmCosto" Then

                        If e.KeyCode = Keys.Delete Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00"
                        End If

                        If e.KeyCode = Keys.Back Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                            End If
                        End If

                        If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            End If

                        ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            End If

                        ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            End If

                        ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            Me.grdDatos.Columns(nombre).ReadOnly = True
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    ElseIf nombre = "txmTotalCobro" Then

                        If e.KeyCode = Keys.Delete Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00"
                        End If

                        If e.KeyCode = Keys.Back Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                            End If
                        End If

                        If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            End If

                        ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            End If

                        ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                            If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0.00" Then
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            Else
                                Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                            End If

                        ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            Me.grdDatos.Columns(nombre).ReadOnly = True
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    Else

                        If e.KeyValue >= 65 And e.KeyValue <= 90 Then
                            txtFiltro.Focus()
                            Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                            txtFiltro.Focus()
                            txtFiltro.Text = e.KeyData.ToString
                            txtFiltro.Select(txtFiltro.TextLength, 0)
                            borrar = False
                        End If

                    End If

                End If

            End If

                b.fnGrid_seleccionarEspacio(grdDatos, 0, e, True)
        Catch ex As Exception

            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

End Class
