''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmReasignacionProductos

#Region "Variables Publicas"
    Public _salida As Integer
#End Region

#Region "Propiedades"
    Public Property salida As Integer
        Get
            salida = _salida
        End Get
        Set(value As Integer)
            _salida = value
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmReasignacionProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdClientes)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdClientes)

        fnLlenarGrid()
        fnConfiguracion()

        mdlPublicVars.fnGrid_iconos(Me.grdClientes)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Try
            Dim filas As Integer = Me.grdClientes.Rows.Count - 1

            For index As Integer = 0 To filas

                Dim valor As Boolean = False

                valor = Me.grdClientes.Rows(index).Cells("chmAgregar").Value

                RadMessageBox.Show("El Valor de Agregado de la Fila " + CStr(index) + " es de " + CStr(valor), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

            Next
        Catch
        End Try
    End Sub

    Private Sub fn_Guardar() Handles Me.panel0
        fnGuardarReasignacion()
        alerta.fnGuardar()
        Me.Close()
    End Sub

    Private Sub fnGuardarReasignacion()
        Try
            Dim filas As Integer = Me.grdClientes.Rows.Count - 1

            Dim transporte As Integer
            Dim transportemedio As Integer

            For index As Integer = 0 To filas

                Dim valor As Boolean = False

                valor = Me.grdClientes.Rows(index).Cells("chmAgregar").Value

                If valor = True Then
                    transportemedio = CInt(Me.grdClientes.Rows(index).Cells("SalidaTransporte").Value)
                    transporte = CInt(Me.grdClientes.Rows(index).Cells("Transporte").Value)

                    Dim conexion As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim contador As Object = (From x In conexion.tblSalidasTransportesMediosDetalles Where x.idSalidaTransporteMedio = transportemedio And x.idSalidaTransporte = transporte And x.reenviado = False Select x).Count

                        For fila As Integer = 0 To contador - 1

                            Dim salida As tblSalidasTransportesMediosDetalle = (From x In conexion.tblSalidasTransportesMediosDetalles Where x.idSalidaTransporte = transporte And x.idSalidaTransporteMedio = transportemedio And x.reenviado = False Select x).Take(1).FirstOrDefault

                            salida.cantidad = 0
                            salida.reenviado = True

                            conexion.SaveChanges()

                        Next
                        conn.Close()
                    End Using

                End If

            Next
        Catch

        End Try
    End Sub

    Private Sub fn_Salir() Handles Me.panel1

        Dim fila As Integer = Me.grdClientes.Rows.Count - 1
        Dim contador As Integer = 0

        For index As Integer = 0 To fila
            Dim agregar As Boolean

            agregar = CBool(Me.grdClientes.Rows(index).Cells("chmAgregar").Value)

            If agregar = True Then
                contador += 1
            End If
        Next

        If contador <= 0 Then
            RadMessageBox.Show("Debe Seleccionar al Menos un Cliente y Guardar el Registro", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    ''Private Sub grdClientes_Click(sender As Object, e As EventArgs) Handles grdClientes.Click
    ''    If Me.grdClientes.CurrentColumn.Name = "chmAgregar" Then

    ''        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdClientes)

    ''        Dim valor As Boolean

    ''        valor = Me.grdClientes.Rows(fila).Cells("chmAgregar").Value

    ''        If valor = True Then
    ''            Me.grdClientes.Rows(fila).Cells("chmAgregar").Value = False
    ''        Else
    ''            Me.grdClientes.Rows(fila).Cells("chmAgregar").Value = True
    ''        End If

    ''    End If
    ''End Sub
#End Region

#Region "Funciones"
    Private Sub fnLlenarGrid()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_ListaReasignacionTransporte(salida) Select x)

            Me.grdClientes.DataSource = datos

            conn.Close()
        End Using

    End Sub

    Private Sub fnConfiguracion()
        ''Tamanios
        Me.grdClientes.Columns("Cliente").Width = 125
        Me.grdClientes.Columns("Nit").Width = 75
        Me.grdClientes.Columns("CantidadProductos").Width = 75
        Me.grdClientes.Columns("chmAgregar").Width = 75

        ''Visibles
        Me.grdClientes.Columns("Cliente").IsVisible = True
        Me.grdClientes.Columns("Nit").IsVisible = True
        Me.grdClientes.Columns("CantidadProductos").IsVisible = True
        Me.grdClientes.Columns("SalidaTransporte").IsVisible = False
        Me.grdClientes.Columns("Transporte").IsVisible = False
        Me.grdClientes.Columns("chmAgregar").IsVisible = True

        ''Editables
        Me.grdClientes.Columns("Cliente").ReadOnly = True
        Me.grdClientes.Columns("Nit").ReadOnly = True
        Me.grdClientes.Columns("CantidadProductos").ReadOnly = True
        Me.grdClientes.Columns("SalidaTransporte").ReadOnly = True
        Me.grdClientes.Columns("Transporte").ReadOnly = True
        Me.grdClientes.Columns("chmAgregar").ReadOnly = False
    End Sub
#End Region

    Private Sub grdClientes_ValueChanged(sender As Object, e As EventArgs) Handles grdClientes.ValueChanged
        Try
            Dim fil As Integer = CInt(Me.grdClientes.CurrentRow.Index)
            Dim col As Integer = CInt(Me.grdClientes.CurrentColumn.Index)
            Dim nombre = mdlPublicVars.tipoControl(Me.grdClientes.Columns(col).Name)

            If mdlPublicVars.tipoControl(nombre) = "chm" Then
                txtFecha.Focus()
                txtFecha.Select()
                grdClientes.Focus()
                Me.grdClientes.Rows(fil).Cells(col).IsSelected = True
            End If

            'contador
            mdlPublicVars.fngrd_contador(grdClientes, lblContadorClientes, "chmAgregar")
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub
End Class
