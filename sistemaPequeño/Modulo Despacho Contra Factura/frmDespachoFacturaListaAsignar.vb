''Option Strict On

Imports System.Linq
Imports System.Data
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmDespachoFacturaListaAsignar

#Region "Eventos"

    Private Sub frmDespachoFacturaListaAsignar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub
    'LOAD
    Private Sub frmDespachoFacturaLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim iz As New frmVentaPequeniaBarraIzquierda
        iz.frmAnterior = Me
        frmBarraLateralBaseIzquierda = iz
        ActivarBarraLateral = True

        lbl0Nuevo.Text = "Nueva " & vbCrLf & " Asignacion"
        ''Me.grdDatos.Font = New System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        fnLlenarLista()
        filtrarTecla = False
        mdlPublicVars.fnGrid_iconos(grdDatos)
    End Sub

    'LLENAR LISTA
    Private Sub fnLlenarLista() Handles Me.llenarLista
        fnLlenarGrid()
    End Sub

    'ACTUALIZAR LISTA
    Public Sub frm_llenarLista() Handles Me.llenarLista
        fnLlenarGrid()
        fnCambioFila()
    End Sub

    'NUEVO REGISTRO ( Se realiza una nueva asignacion)
    Private Sub fnNuevoRegistro() Handles Me.nuevoRegistro
        Me.fnCambioFila()
        If mdlPublicVars.superSearchFilasGrid > 0 Then
            'Obtenemos las filas que se van a agregar
            frmDespachoFacturaAsignar.listaAgregar = (From x In Me.grdDatos.Rows Where CType(x.Cells("txmCantEnviar").Value, Double) > 0 Select x).ToList
            frmDespachoFacturaAsignar.Text = "Asignar Transporte"
            frmDespachoFacturaAsignar.StartPosition = FormStartPosition.CenterScreen
            frmDespachoFacturaAsignar.ShowDialog()
            frmDespachoFacturaAsignar.Dispose()
        End If
    End Sub

    'VER REGISTRO
    Private Sub fnVerRegistro() Handles Me.verRegistro

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
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' INGRESAR DE CANTIDAD A ENVIAR
    Private Sub grdDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDatos.KeyDown
        Try

            If Me.grdDatos.CurrentRow.Index >= 0 Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                Dim col As Integer = Me.grdDatos.CurrentColumn.Index
                Dim nombre As String = Me.grdDatos.Columns(col).Name
                Dim cantVenta As Integer = Me.grdDatos.Rows(fila).Cells("CantVenta").Value
                Dim cantEnviada As Integer = Me.grdDatos.Rows(fila).Cells("CantEnviada").Value

                If nombre = "txmCantEnviar" Then

                    If e.KeyCode = Keys.Delete Then
                        Me.grdDatos.Rows(fila).Cells(nombre).Value = "0"
                    End If

                    If e.KeyCode = Keys.Back Then
                        If Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length > 0 Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Substring(0, Me.grdDatos.Rows(fila).Cells(nombre).Value.ToString.Length - 1)
                        End If
                    End If

                    If e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
                        If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                            If CInt(Me.grdDatos.Rows(fila).Cells(nombre).Value) > (cantVenta - cantEnviada) Then
                                RadMessageBox.Show("La Cantidad ingresada no es valida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = "0"
                            End If
                        Else
                            Me.grdDatos.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                            If CInt(Me.grdDatos.Rows(fila).Cells(nombre).Value) > (cantVenta - cantEnviada) Then
                                RadMessageBox.Show("La Cantidad ingresada no es valida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = "0"
                            End If
                        End If

                    ElseIf e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9 Then
                        If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            If CInt(Me.grdDatos.Rows(fila).Cells(nombre).Value) > (cantVenta - cantEnviada) Then
                                RadMessageBox.Show("La Cantidad ingresada no es valida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = "0"
                            End If
                        Else
                            Me.grdDatos.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                            If CInt(Me.grdDatos.Rows(fila).Cells(nombre).Value) > (cantVenta - cantEnviada) Then
                                RadMessageBox.Show("La Cantidad ingresada no es valida", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                                Me.grdDatos.Rows(fila).Cells(nombre).Value = "0"
                            End If
                        End If

                    ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then
                        If Me.grdDatos.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                        Else
                            Me.grdDatos.Rows(fila).Cells(nombre).Value += "."
                        End If

                    ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                        Me.grdDatos.Columns(nombre).ReadOnly = True
                        Me.grdDatos.Rows(fila).Cells(nombre).EndEdit()
                    End If

                    End If

                End If


                ''Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                ''If fila >= 0 Then
                ''    Dim columna As String = Me.grdDatos.CurrentColumn.Name

                ''    If columna.Equals("txmCantEnviar") Then

                ''        If e.KeyCode = Keys.Delete Then
                ''            Me.grdDatos.Rows(fila).Cells("txmCantEnviar").Value = "0"
                ''        Else
                ''            Dim valorActual As String = CStr(Me.grdDatos.Rows(fila).Cells("txmCantEnviar").Value)
                ''            Dim valorStr As String = Chr(e.KeyCode)
                ''            Dim valor As Integer = 0

                ''            Dim cantVenta As Integer = CInt(Me.grdDatos.Rows(fila).Cells("CantVenta").Value)
                ''            Dim cantEnviada As Integer = CInt(Me.grdDatos.Rows(fila).Cells("CantEnviada").Value)

                ''            If IsNumeric(valorStr) Then
                ''                valor = CInt(valorStr)
                ''                If valor > 0 Or (valor = 0 And Not valorActual.Equals("0")) Then
                ''                    valorActual = valorActual + valorStr

                ''                    If CInt(valorActual) > (cantVenta - cantEnviada) Then
                ''                        RadMessageBox.Show("La cantidad ingresada no es valida", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                ''                    Else
                ''                        Me.grdDatos.Rows(fila).Cells("txmCantEnviar").Value = valorActual
                ''                    End If
                ''                End If
                ''            End If
                ''        End If
                ''    End If
                ''End If
        Catch
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
                Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_lista_despachosFactura(mdlPublicVars.idEmpresa, 30, filtro) Select x)

                Me.grdDatos.DataSource = datos
                fnConfiguracion()
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

            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaRegistro")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Total")

            Me.grdDatos.Columns("ID").IsVisible = False
            Me.grdDatos.Columns("idSalidaDetalle").IsVisible = False

            Me.grdDatos.Columns("FechaRegistro").Width = 125
            Me.grdDatos.Columns("Documento").Width = 100
            Me.grdDatos.Columns("Cliente").Width = 250
            Me.grdDatos.Columns("Telefono").Width = 150
            Me.grdDatos.Columns("Observacion").Width = 250
            Me.grdDatos.Columns("Total").Width = 175
            Me.grdDatos.Columns("Cantidad").Width = 100
            Me.grdDatos.Columns("Contacto").Width = 175
            Me.grdDatos.Columns("Vendedor").Width = 175
            Me.grdDatos.Columns("Sucursal").Width = 175
            Me.grdDatos.Columns("Sector").Width = 300
            Me.grdDatos.Columns("TipoVehiculo").Width = 200
            Me.grdDatos.Columns("Direccion").Width = 275
            Me.grdDatos.Columns("CodigoProd").Width = 200
            Me.grdDatos.Columns("Producto").Width = 300
            Me.grdDatos.Columns("ID").Width = 120
            Me.grdDatos.Columns("CantVenta").Width = 125
            Me.grdDatos.Columns("CantEnviada").Width = 125
            Me.grdDatos.Columns("txmCantEnviar").Width = 125
            Me.grdDatos.Columns("CantPenEnviar").Width = 125

        End If
    End Sub
#End Region



End Class