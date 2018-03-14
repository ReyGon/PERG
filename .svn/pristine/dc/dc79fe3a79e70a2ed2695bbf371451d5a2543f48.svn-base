Imports System.Data.EntityClient
Imports System.Linq

Public Class frmGuiasListaImprimir
    Public idFactura As Integer

    Private Sub frmGuiasListaImprimir_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        fnLlenarLista()
        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
    End Sub

    Private Sub fnLlenarLista()
        'conexion nueva.
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            '---------------------------------


            'consultar si existe una sola guia.
            Dim listaImpresiones = (From im In conexion.tblImpresions
                                        Join en In conexion.tblEnvios On CType(en.codigo, String) Equals im.descripcion
                                     Join es In conexion.tblEnvio_Salida On en.codigo Equals es.envio
                                     Join s In conexion.tblSalidas On s.idSalida Equals es.salida
                                     Where s.IdFactura = idFactura And im.tblTipoImpresion.bitGuia = True And im.bitImpreso = False
                                     Select Codigo = im.codigo, Fecha = im.fechaRegistro, Reporte = im.tblTipoImpresion.nombre,
                                     NoEnvio = en.numero, Tipo = en.tblEnvioTipo.nombre, im.bitImpreso).ToList

            '------------------------------------- fin del proceso
            Me.grdDatos.DataSource = listaImpresiones

            If Me.grdDatos.Columns.Count > 0 Then
                Me.grdDatos.Columns("Codigo").IsVisible = False
            End If
            conn.Close()
        End Using
    End Sub

    Private Sub fnImprimir() Handles Me.panel0
        Dim bitImpreso As Boolean = False

        Try

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If fila >= 0 Then
                Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

                'conexion nueva.
                Dim conexion As New dsi_pos_demoEntities

                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)
                    '---------------------------------
                    Dim codigoImpresion As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                    Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where x.codigo = codigoImpresion Select x).FirstOrDefault

                    If impresion.bitImpreso = False Then

                        'seleccionar impresora
                        frmImpresoras.Text = "Impresoras"
                        frmImpresoras.ShowDialog()
                        frmImpresoras.Dispose()

                        Dim r As New clsReporte
                        r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_reporteDeGuias(mdlPublicVars.idEmpresa, impresion.descripcion))
                        r.nombreParametro = "@filtro"
                        r.reporte = impresion.tblTipoImpresion.reporte
                        r.parametro = ""
                        r.imprimirReporte()

                        If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                            impresion.bitImpreso = True
                            impresion.usuarioImprime = mdlPublicVars.idUsuario
                            impresion.fechaImpresion = fechaServer
                            conexion.SaveChanges()
                            bitImpreso = True
                        End If
                    Else
                        alerta.contenido = "Registro Impreso"
                        alerta.fnErrorContenido()
                    End If




                    '---------------------------------
                    conn.Close()
                End Using

            End If

        Catch ex As Exception
            alerta.fnError()
        End Try

        'llenar la lista de nuevo.
        If bitImpreso = True Then
            fnLlenarLista()
        End If
    End Sub
End Class
