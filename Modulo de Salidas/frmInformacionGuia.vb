Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows
Imports System.Windows.Forms
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmInformacionGuia

    Private _idSalida As Integer

    Public Property idSalida() As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(ByVal value As Integer)
            _idSalida = value
        End Set
    End Property

    Private Sub frmInformacionGuia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdTelefonos)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdTelefonos)

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

            Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = salida.idCliente Select x).FirstOrDefault

            Me.lblCliente.Text = cliente.Nombre1
            Me.lblNegocio.Text = cliente.Negocio
            Me.lblDireccionEnvio.Text = cliente.direccionEnvio1
            Me.lblDireccionFactura.Text = salida.direccionFacturacion
            Me.lblObservacion.Text = salida.observacion

            fnLlenarGrid(salida.idCliente)

            salida.bitguia = True
            conexion.SaveChanges()

            conn.Close()
        End Using
    End Sub

    Public Sub fnLlenarGrid(ByVal idcliente As Integer)

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim datos = (From x In conexion.tblClientes_Telefono Where x.cliente = idCliente Select Codigo = x.codigo, Telefono = x.telefono, Observacion = x.observacion)

            Me.grdTelefonos.DataSource = datos
            fnConfiguraTelefonos()

            conn.Close()
        End Using

    End Sub

    Private Sub fnConfiguraTelefonos()
        If Me.grdTelefonos.ColumnCount > 0 Then
            Me.grdTelefonos.Columns("Codigo").IsVisible = False

            Me.grdTelefonos.Columns("Telefono").Width = 35
            Me.grdTelefonos.Columns("Observacion").Width = 65
        End If
    End Sub

    Private Sub fnSalir() Handles Me.panel0

        ''Dim conexion As dsi_pos_demoEntities
        ''Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
        ''    conn.Open()
        ''    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

        ''    Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

        ''    salida.bitguia = True

        ''    conexion.SaveChanges()
        ''    conn.Close()
        ''End Using

        Me.Close()
    End Sub

    Private Sub btnTelefono_Click(sender As Object, e As EventArgs) Handles btnTelefono.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault

                salida.direccionEnvio = Me.lblDireccionEnvio.Text

                conexion.SaveChanges()

                Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = salida.idCliente Select x).First

                cliente.direccionEnvio1 = Me.lblDireccionEnvio.Text

                conexion.SaveChanges()

                Me.lblResultado.Text = "Actualizado!"
                conn.Close()
            End Using
        Catch ex As Exception
            Me.lblResultado.Text = "Fallo!"
        End Try
    End Sub
End Class
