Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.EntityClient

Public Class frmFacturaDescuento

    Public bitNuevo As Boolean
    Public bitAnular As Boolean
    Public codigo As Integer


    Private Sub frmFacturaDescuento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fnCargarInformacion()
    End Sub


    Private Sub fnCargarInformacion()

        Dim conexion As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim c = From x In conexion.tblResolucionFacturas Where x.habilitado = True Select Codigo = x.idResolucion, Nombre = x.resolucion

                'llenar el como de Resolulcion
                With Me.cmbResolucionFactura
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = c
                End With

                Dim des = (From x In conexion.tblFacturaDescuentoes Select Codigo = x.idDescuento, Valor = x.valor).ToList

                With Me.cmbDescuento
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Valor"
                    .DataSource = des
                End With

                Dim consulta = (From x In conexion.tblSalidaDetalle_Factura Join s In conexion.tblSalidaDetalles On s.idSalidaDetalle Equals x.idSalidaDetalle
                                Where x.idFactura = codigo Select Nit = x.tblSalidaDetalle.tblSalida.nit,
                                 DireccionFacturacion = x.tblSalidaDetalle.tblSalida.tblCliente.direccionFactura1,
                                  NombreFacturacion = x.tblSalidaDetalle.tblSalida.cliente).FirstOrDefault


                txtNit.Text = consulta.Nit
                txtDireccionFactura.Text = consulta.DireccionFacturacion
                txtNombreFacturacion.Text = consulta.NombreFacturacion

            Catch ex As Exception

            End Try

            conn.Close()
        End Using

    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub cmbResolucionFactura_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbResolucionFactura.SelectedValueChanged
        Dim rf As Integer = CType(cmbResolucionFactura.SelectedValue, Integer)


        Dim conexion As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
            Try
                Dim c As tblResolucionFactura = (From x In conexion.tblResolucionFacturas Where x.idResolucion = rf).FirstOrDefault
                If c IsNot Nothing Then
                    lblResolucion.Text = c.resolucion
                    If c.fechaResolucion Is Nothing Then
                        lblFechaResolucion.Text = ""
                    Else
                        lblFechaResolucion.Text = c.fechaResolucion
                    End If

                    txtSerie.Text = c.serie
                    lblInicio.Text = c.inicio
                    lblFinal.Text = c.final
                    lblCorrelativo.Text = c.correlativo + 1
                    txtCorrelativo.Text = lblCorrelativo.Text
                End If

            Catch ex As Exception
                alerta.fnError()
            End Try

            conn.Close()
        End Using


    End Sub

    Private Sub fnGuardar() Handles Me.panel0
        fnGuardarRegistro()
        Me.Close()
    End Sub


    Private Sub fnGuardarRegistro()

        Dim codigoResolucion As Integer = CType(cmbResolucionFactura.SelectedValue, Integer)
        Dim descuento As Integer = CType(cmbDescuento.Text, Integer)
        Dim conexion As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                'consultar el registro de resolucion segun el codigo seleccionado.
                Dim c As tblResolucionFactura = (From y In conexion.tblResolucionFacturas Where y.idResolucion = codigoResolucion Select y).FirstOrDefault

                If c Is Nothing Then
                    conexion.SaveChanges()
                    alerta.contenido = "No existen resoluciones, debe crear una para facturar"
                    alerta.fnErrorContenido()
                Else
                    If c.correlativo Is Nothing Then
                        c.correlativo = 1
                    End If

                    'actualizar el registro de factura.
                    Dim f As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigo).FirstOrDefault
                    f.idResolucion = cmbResolucionFactura.SelectedValue
                    f.descuento = descuento
                    f.serieFactura = txtSerie.Text
                    f.DocumentoFactura = txtCorrelativo.Text
                    conexion.SaveChanges()


                    Dim detallesSalida As List(Of tblSalidaDetalle_Factura) = (From z In conexion.tblSalidaDetalle_Factura Where z.idFactura = codigo Select
                                                                           z).ToList
                    Dim detalle
                    Dim idDetalle As Integer = 0
                    For Each detalle In detallesSalida
                        idDetalle = detalle.idSalidaDetalle
                        Dim detalleActualizar As tblSalidaDetalle = (From s In conexion.tblSalidaDetalles Where s.idSalidaDetalle = idDetalle Select s).FirstOrDefault
                        detalleActualizar.precioFactura = detalleActualizar.precioFactura - (detalleActualizar.precioFactura * descuento / 100)
                        conexion.SaveChanges()
                    Next


                    Dim lSalida As List(Of tblSalida) = (From x In conexion.tblSalidas Where x.IdFactura = f.IdFactura).ToList

                    Dim indexSalida As tblSalida
                    For Each indexSalida In lSalida
                        indexSalida.nit = txtNit.Text
                        indexSalida.direccionFacturacion = txtDireccionFactura.Text
                        indexSalida.cliente = txtNombreFacturacion.Text
                        indexSalida.documentoFactura = f.DocumentoFactura
                        conexion.SaveChanges()
                    Next

                    c.correlativo = txtCorrelativo.Text

                    If c.correlativo >= c.final Then
                        c.habilitado = False
                        conexion.SaveChanges()
                    End If
                    conexion.SaveChanges()
                    alerta.fnGuardar()
                End If
                
            Catch ex As Exception
                alerta.fnError()
            End Try

            conn.Close()
        End Using

      

    End Sub
End Class
