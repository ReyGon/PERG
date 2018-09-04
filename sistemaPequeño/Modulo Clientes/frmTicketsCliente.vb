Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmTicketsCliente

    Private _idcliente As Integer

    Public Property idCliente As Integer
        Get
            idCliente = _idcliente
        End Get
        Set(value As Integer)
            _idcliente = value
        End Set
    End Property

    Private Sub frmTicketsCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                mdlPublicVars.comboActivarFiltro(cmbCliente)
                mdlPublicVars.comboActivarFiltro(cmbNegocio)
                mdlPublicVars.fnFormatoGridEspeciales(Me.grdTickets)
                mdlPublicVars.fnFormatoGridMovimientos(Me.grdTickets)

                Me.rbtSinCobrar.Checked = True

                fnLlenarCombos(conexion)
                fnLlenarGrid()

                mdlPublicVars.fnGrid_iconos(Me.grdTickets)

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarCombos(ByVal conexion As dsi_pos_demoEntities)
        Try

            Dim consulta

            consulta = (From x In conexion.tblClientes Select Codigo = x.idCliente, Nombre = x.Nombre1 + " (" + x.clave + ")")

            With Me.cmbCliente
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = consulta
            End With

            consulta = (From x In conexion.tblClientes Select Codigo = x.idCliente, Nombre = x.Negocio + " (" + x.clave + ")")

            With Me.cmbNegocio
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = consulta
            End With

            If idCliente > 0 Then
                Me.cmbCliente.SelectedValue = idCliente
                Me.cmbNegocio.SelectedValue = idCliente
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarGrid()
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim consumido As Boolean
                Dim cliente As Integer

                If Me.rbtCobrados.Checked = True Then
                    consumido = True
                ElseIf Me.rbtSinCobrar.Checked = True Then
                    consumido = False
                End If

                If Me.cmbCliente.SelectedValue > 0 Or Me.cmbNegocio.SelectedValue > 0 Then

                    cliente = Me.cmbCliente.SelectedValue

                    Dim consulta = (From x In conexion.tblTICKETSVENTAS Where x.BITAPLICADO = consumido And x.IDCLIENTE = cliente _
                                    Select Codigo = x.IDTICKET, Fecha = x.FECHACREACION, DocumentoVenta = x.tblSalida.documento, _
                                    chmCobrado = x.BITAPLICADO, ValidacionVenta = x.MONTOVALIDACION)

                    Me.grdTickets.DataSource = consulta

                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged
        Try
            If cmbCliente.SelectedValue > 0 Then
                Me.cmbNegocio.SelectedValue = Me.cmbCliente.SelectedValue
                fnLlenarGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbNegocio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNegocio.SelectedValueChanged
        Try
            If cmbNegocio.SelectedValue > 0 Then
                Me.cmbCliente.SelectedValue = Me.cmbNegocio.SelectedValue
                fnLlenarGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtCobrados_CheckedChanged(sender As Object, e As EventArgs) Handles rbtCobrados.CheckedChanged
        Try
            If Me.cmbCliente.SelectedValue > 0 Or Me.cmbNegocio.SelectedValue > 0 Then
                fnLlenarGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
