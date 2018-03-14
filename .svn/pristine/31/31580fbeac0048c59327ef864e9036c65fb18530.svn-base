Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmPedidosPendientesSurtirConceptos
    Private _codClie As Integer
    Private _codSalida As Integer
    Private permiso As New clsPermisoUsuario


    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Public Property codSalida() As Integer
        Get
            codSalida = _codSalida
        End Get
        Set(ByVal value As Integer)
            _codSalida = value
        End Set
    End Property

    Private Sub frmSalidasAjustesConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()
        fnConfiguracion()
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
    End Sub

    Private Sub fnLlenar()
        Try


            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codClie Select x).FirstOrDefault
                lblCliente.Text = cliente.Negocio

                Dim salida As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = codSalida Select x).FirstOrDefault
                lblSalida.Text = salida.documento
                lblFechaRegistro.Text = salida.fechaRegistro.ToShortDateString

                'Realizamos la consulta para obtener los ajustes
                Dim pendientes = (From x In conexion.tblSurtirs Where x.tblSalidaDetalle.tblSalida.idSalida = salida.idSalida _
                                  Select Fecha = x.fechaTransaccion, Codigo = x.tblArticulo.codigo1, Nombre = x.tblArticulo.nombre1, _
                                  Cantidad = x.cantidad, x.tblSalidaDetalle.precio, Total = x.cantidad * x.tblSalidaDetalle.precio, Saldo = x.saldo, Anulado = x.anulado)


                Me.grdDatos.DataSource = pendientes

                conn.Close()
            End Using

        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")

            For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.BottomCenter
            Next

            Me.grdDatos.Columns(0).Width = 80
            Me.grdDatos.Columns(1).Width = 80
            Me.grdDatos.Columns(2).Width = 180
            Me.grdDatos.Columns(3).Width = 80
            Me.grdDatos.Columns(4).Width = 80
            Me.grdDatos.Columns(5).Width = 80

            Dim index
            Dim total As Double = 0
            For index = 0 To Me.grdDatos.Rows.Count - 1
                total += CType(Me.grdDatos.Rows(index).Cells("Total").Value, Double)
            Next

            lblTotal.Text = Format(total, mdlPublicVars.formatoMoneda)
        End If
    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub



    'Documento salida
    Private Sub fnDocSalida() Handles Me.panel1
        frmDocumentosSalida.txtTitulo.Text = "Lista de Ventas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub





End Class
