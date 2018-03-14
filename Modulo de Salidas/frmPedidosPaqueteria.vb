Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmPedidosPaqueteria

    Public id As Integer

    Private Sub frmPedidosPaqueteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()
        fnConfiguracion()
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
    End Sub

    Private Sub fnLlenar()
        Try


            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = id Select x).FirstOrDefault
            lblCodigoSalida.Text = salida.idSalida
            lblDocumento.Text = salida.documento
            lblFactura.Text = salida.documentoFactura
            lblFecha.Text = salida.fechaRegistro
            lblObservacion.Text = salida.observacion
            lblTotal.Text = Format(salida.total, mdlPublicVars.formatoMoneda)
            lblCliente.Text = salida.tblCliente.Negocio
            lblVendedor.Text = salida.tblVendedor.nombre

            Dim guias = (From x In ctx.tblEnvio_Salida Where x.salida = salida.idSalida _
                         Select Codigo = x.tblEnvio.codigo, Empresa = x.tblEnvio.tblEnvio_Empresa.nombre, Tipo = x.tblEnvio.tblEnvioTipo.nombre,
                         Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes, Usuario = x.tblEnvio.tblUsuario.nombre,
                         Observacion = x.tblEnvio.observacion)

            Me.grdDatos.DataSource = guias
 
        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try

    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Rows.Count > 0 Then

            'tamaño de columnas.
            Me.grdDatos.Columns(0).IsVisible = False
            Me.grdDatos.Columns(1).Width = 100 ' Empresa
            Me.grdDatos.Columns(2).Width = 100 ' Tipo
            Me.grdDatos.Columns(3).Width = 75 'Numero
            Me.grdDatos.Columns(4).Width = 75 ' paquetes
            Me.grdDatos.Columns(5).Width = 75 ' Usuario
            Me.grdDatos.Columns(6).Width = 150 ' observacion

            'alineacion
            Me.grdDatos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
            Me.grdDatos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        End If

    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
