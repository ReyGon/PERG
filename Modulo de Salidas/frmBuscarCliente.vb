Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports System.Windows
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmBuscarCliente

    Private _nombrecliente As String

    Public Property nombrecliente As String
        Get
            nombrecliente = _nombrecliente
        End Get
        Set(value As String)
            _nombrecliente = value
        End Set
    End Property

    Private Sub frmBuscarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdCliente)
        superSearchId = 0
        superSearchNit = ""

        If nombrecliente <> "" Then
            Me.txtFiltro.Text = nombrecliente
            fnBuscarCliente()
        End If

    End Sub

    Private Sub fnConfiguracion()
        ''para el tamanio de las columnas
        Me.grdCliente.Columns(0).Width = 50
        Me.grdCliente.Columns(1).Width = 90
        Me.grdCliente.Columns(2).Width = 150
        Me.grdCliente.Columns(3).Width = 300
        Me.grdCliente.Columns(4).Width = 300

        Me.grdCliente.Columns(0).IsVisible = False

        For i As Integer = 1 To grdCliente.ColumnCount - 1
            Me.grdCliente.Columns(i).IsVisible = True
            Me.grdCliente.Columns(i).ReadOnly = False
        Next
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Public Sub fnBuscarCliente()
        Dim filtro As String

        filtro = Me.txtFiltro.Text

        Dim conexion As dsi_pos_demoEntities
        Using conn = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim cliente = (From x In conexion.tblClientes Where x.Nombre1.Contains(filtro) Or x.Negocio.Contains(filtro) Or x.nit1.Contains(filtro) And x.habillitado = True Select ID = x.idCliente, Clave = x.clave, Nit = x.nit1, Nombre = x.Nombre1, Negocio = x.Negocio)

            Me.grdCliente.DataSource = mdlPublicVars.EntitiToDataTable(cliente)

            If Me.grdCliente.RowCount > 0 Then
                fnConfiguracion()
            Else
                RadMessageBox.Show("No Existen Clientes con esa Referencia!!!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Me.txtFiltro.Text = ""
            End If

            conn.close()
        End Using

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        fnBuscarCliente()
    End Sub

    Private Sub fnAgregar()
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdCliente)
        Dim errores As Boolean
        If fila >= 0 Then
            Dim codigo As String

            If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                codigo = Me.grdCliente.Rows(fila).Cells(2).Value

                superSearchNit = CType(codigo, String)

                If codigo.ToLower = "c/f" Then
                    superSearchId = CType(Me.grdCliente.Rows(fila).Cells(0).Value, Integer)
                End If
            Else
                codigo = Me.grdCliente.Rows(fila).Cells(0).Value

                superSearchId = CType(codigo, Integer)
            End If

        Else
            errores = True
        End If

        If errores = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim filas As Integer = Me.grdCliente.Rows.Count - 1
        If filas >= 0 Then
            fnAgregar()
        Else
            RadMessageBox.Show("Debe seleccionar al menos un cliente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End If

    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFiltro.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then
            fnBuscarCliente()
        End If

        If Asc(e.KeyChar) = Keys.Enter Then
            Me.grdCliente.Focus()
            frmVentaPequenia.grdProductos.Focus()
            frmVentaPequenia.grdProductos.Columns("txbProducto").IsCurrent = True

        End If

    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Me.grdCliente.Rows.Count > 0 Then
            If e.KeyCode = Keys.Enter Then
                fnAgregar()
            Else
                Dim letra As String
                letra = ChrW(e.KeyValue)

                Me.txtFiltro.Clear()
                Me.txtFiltro.Text = letra
                Me.txtFiltro.Focus()
            End If
        Else
            RadMessageBox.Show("No ha seleccionado ningun cliente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.txtFiltro.Focus()
        End If
        If e.KeyCode = Keys.Enter Then
            frmVentaPequenia.grdProductos.Focus()
            frmVentaPequenia.grdProductos.Columns("txbProducto").IsCurrent = True

        End If


    End Sub

    Private Sub grdCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            frmVentaPequenia.grdProductos.Focus()
            frmVentaPequenia.grdProductos.Columns("txbProducto").IsCurrent = True

        End If
    End Sub

    Private Sub grdCliente_Click(sender As Object, e As EventArgs) Handles grdCliente.Click

    End Sub
End Class
