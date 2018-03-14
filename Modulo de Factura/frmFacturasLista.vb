﻿Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls.UI
Imports System.Collections.Generic
Imports Telerik.WinControls
Imports System.Data.Objects
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmFacturasLista
    Private permiso As New clsPermisoUsuario
    Private cargo As Boolean

    Private Sub frmFacturaMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        lbl1Modificar.Text = "Anular Parcial"
        lbl2Eliminar.Text = "Anular Total"
        lblFiltroFecha.Visible = False
        Label2.Visible = False
        txtFiltro.Visible = False
        cmbFiltroFecha.Visible = False
        Try
            If mdlPublicVars.PuntoVentaPequeno_Activado Then
                Dim iz As New frmVentaPequeniaBarraIzquierda

                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            Else
                Dim iz As New frmPedidosFacturasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If
            frmBarraLateralBaseDerecha = frmFacturasListaBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try

        'damos formato de letra al grid
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        'llenar combo de filtro para fechas.
        fnLlenarCombo()
        cmbFiltroFecha.Visible = False
        lblFiltroFecha.Visible = False
        cargo = True

        llenagrid()
        fnCambioFila()
        fnConfiguracion()


    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            Dim conexion As New dsi_pos_demoEntities

            'abrir la conexion
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                conexion.CommandTimeout = 10000

                Dim fechainicio As DateTime
                Dim fechafin As DateTime

                fechainicio = dtpFechaInicio.Value.ToShortDateString + " 00:00:00.000"
                fechafin = dtpFechaFin.Value.ToShortDateString + " 23:59:59.999"
                ''conexion.CommandTimeout = 0
                Dim consulta = conexion.sp_ListaFacturas(mdlPublicVars.idEmpresa, filtro, fechainicio, fechafin)

                Me.grdDatos.DataSource = consulta
                ''Dim fila As Object()

                ''For Each index As sp_ListaFacturas_Result In consulta
                ''    fila = {index.Codigo, index.clave, index.Negocio, index.Fecha, index.DocsVenta, index.Pedidos, index.TotalDespacho, index.Estado, index.FacElectronica, index.Resolucion, index.Serie, index.Descuento, index.TotalFacturado, index.Observacion, index.chmImprFactura, index.chmImprEstCuenta, index.chmImprGuias, index.ImprEstado}

                ''    Me.grdDatos.Rows.Add(fila)
                ''Next

                'Para saber cuantas filas tiene el grid
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count

                'cerramos conexion
                conn.Close()

                ''fnConfiguracion()
            End Using
        Catch ex As Exception

        End Try



    End Sub

    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Dim datos = (From x In ctx.tblListaFiltroFechas Select x.orden, codigo = x.dias, x.nombre
                     Order By orden Ascending)

        With cmbFiltroFecha
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = datos
        End With
    End Sub

    Private Sub fnConfiguracion()
        Try
            pbx1Modificar.Image = My.Resources.delete
            pbx2Eliminar.Image = My.Resources.eliminar
            If Me.grdDatos.Rows.Count > 0 Then
                fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                fnGridTelerik_formatoMoneda(Me.grdDatos, "TotalDespacho")
                fnGridTelerik_formatoMoneda(Me.grdDatos, "TotalFacturado")

                For i As Integer = 0 To Me.grdDatos.Columns.Count - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                ' Me.grdDatos.Columns("FechaAnulado").HeaderText = "Fecha Anulado"
                'ocultar columnas.
                Me.grdDatos.Columns("Codigo").IsVisible = False


                Me.grdDatos.Columns("Clave").Width = 40
                Me.grdDatos.Columns("Negocio").Width = 125
                Me.grdDatos.Columns("Fecha").Width = 40
                Me.grdDatos.Columns("DocsVenta").Width = 40
                Me.grdDatos.Columns("Pedidos").Width = 30
                Me.grdDatos.Columns("TotalDespacho").Width = 55
                Me.grdDatos.Columns("Estado").Width = 50
                Me.grdDatos.Columns("FacElectronica").Width = 55
                Me.grdDatos.Columns("Resolucion").Width = 45
                Me.grdDatos.Columns("Serie").Width = 30
                Me.grdDatos.Columns("Descuento").Width = 35
                Me.grdDatos.Columns("TotalFacturado").Width = 55
                Me.grdDatos.Columns("chmImprFactura").Width = 35

                Me.grdDatos.Columns("chmImprEstCuenta").IsVisible = False
                Me.grdDatos.Columns("chmImprGuias").IsVisible = False
                Me.grdDatos.Columns("ImprEstado").IsVisible = False

                'si es venta pequenia vamos a ocultar otras columnas
                If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                    Me.grdDatos.Columns("chmImprFactura").IsVisible = False
                    Me.grdDatos.Columns("Descuento").IsVisible = False
                    Me.grdDatos.Columns("Resolucion").IsVisible = False
                    Me.grdDatos.Columns("Serie").IsVisible = False

                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    'cambio de private a public
    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(fila).Cells("Codigo").Value, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        alertas.contenido = "Para realizar una nueva factura, dirigase al MODULO DE VENTAS"
        alertas.fnErrorContenido()
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        Try
            If Me.grdDatos.RowCount > 0 Then
                If Me.grdDatos.CurrentRow.Index >= 0 Then
                    fnCambioFila()
                    Dim codigo As Integer = mdlPublicVars.superSearchId
                    frmFacturaConcepto.Text = "Facturas"
                    frmFacturaConcepto.codigo = codigo
                    frmFacturaConcepto.WindowState = FormWindowState.Normal
                    frmFacturaConcepto.StartPosition = FormStartPosition.CenterScreen
                    permiso.PermisoFrmEspeciales(frmFacturaConcepto, False)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End If

    End Sub

    Private Sub frmFacturasLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Facturas"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub



    Private Sub fnAnularFactura() Handles Me.modificaRegistro

        If RadMessageBox.Show("¿Desea anular la Factura?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnCambioFila()
            Dim codigo As Long = mdlPublicVars.superSearchId

            AnularFactura(codigo)
        End If



    End Sub

    '1. Seleccionar la factura que se va anular
    '2. Poner en estado anulado la factura seleccionada para anular
    '3. Crear un nuevo registro de factura con la informacion de la factura que se anulo
    '4. Seleccionar los detalles de salida con idFactura anulada 
    '5. registrar los detalles seleccionados en tblsalidaDetalle_factura_anulado
    '6. Actualizar los detalles seleccionados con el idFactura de la factura creada.

    Private Sub AnularFactura(ByVal codigo As Long)

        Dim success As Boolean = True
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
        Dim id As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

        'crear la conexion
        Dim conexion As New dsi_pos_demoEntities

        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)



            Using transaction As New TransactionScope
                Try
                    '1ro. consultar la factura que se anulara.
                    Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codigo Select x).FirstOrDefault

                    ' Dim impresio As tblImpresion=(From x In conexion.tblImpresions Where x.cliente


                    If RadMessageBox.Show("Desea Generar otro Documento", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
                        factura.anulado = True


                        'Dim sfa As tblSalida_Factura = (From s In conexion.tblSalida_Factura Where s.factura = codigo Select s).FirstOrDefault
                        'Dim codigoCliente As Integer
                        'codigoCliente = sfa.tblSalida.idCliente

                        'Dim cliente As tblCliente = (From c In conexion.tblClientes Where c.idCliente = codigoCliente Select c).FirstOrDefault
                        'cliente.saldo = cliente.saldo - factura.Monto

                        conexion.SaveChanges()
                        transaction.Complete()

                        Exit Sub
                    End If




                    '4to. anular la factura principal.
                    factura.anulado = True
                    conexion.SaveChanges()


                    '5to. Crear la Nueva Factura.
                    Dim nuevaFactura As New tblFactura
                    nuevaFactura.Fecha = fechaServidor
                    nuevaFactura.Idusuario = mdlPublicVars.idUsuario
                    nuevaFactura.FechaTransaccion = fechaServidor
                    nuevaFactura.anulado = False

                    'montos 
                    nuevaFactura.Monto = factura.Monto
                    nuevaFactura.pagos = factura.pagos
                    nuevaFactura.pagosTransito = factura.pagosTransito
                    nuevaFactura.saldo = factura.saldo
                    nuevaFactura.pagado = factura.pagado

                    'contado o credito.
                    nuevaFactura.credito = factura.credito
                    nuevaFactura.contado = factura.contado

                    'documentos
                    nuevaFactura.DocumentoFactura = ""
                    nuevaFactura.serieFactura = ""
                    nuevaFactura.enviado = factura.enviado
                    nuevaFactura.idResolucion = Nothing
                    nuevaFactura.bitImpreso = False
                    nuevaFactura.descuento = 0

                    'crear la nueva factura.
                    conexion.AddTotblFacturas(nuevaFactura)
                    conexion.SaveChanges()


                    'seleccionamos el idsalida en tblsalida_factura para guardar el nuevo registro
                    Dim salida = (From z In conexion.tblSalida_Factura Where z.factura = factura.IdFactura Select z).FirstOrDefault

                    'crear el nuevo registro en tblSalida_Factura
                    Dim sf As New tblSalida_Factura
                    sf.factura = nuevaFactura.IdFactura
                    sf.salida = salida.salida

                    conexion.AddTotblSalida_Factura(sf)
                    conexion.SaveChanges()


                    'recorremos los detalles 
                    Dim detalles As List(Of tblSalidaDetalle_Factura) = (From x In conexion.tblSalidaDetalle_Factura Where x.idFactura = factura.IdFactura).ToList

                    Dim d As tblSalidaDetalle_Factura
                    For Each d In detalles
                        Dim dfa As New tblSalidaDetalle_Factura

                        dfa.idFactura = nuevaFactura.IdFactura
                        dfa.idSalidaDetalle = d.idSalidaDetalle

                        conexion.AddTotblSalidaDetalle_Factura(dfa)
                        conexion.SaveChanges()

                        conexion.SaveChanges()

                    Next



                    '------------- DOC DE IMPRESION.

                    'Cambiar registros de Estado de Cuenta y Factura de tbl impresion a la nueva factura.
                    Dim ListaImpresionesF As List(Of tblImpresion) = (From x In conexion.tblImpresions Where x.tblTipoImpresion.bitFactura = True _
                                                                      And x.descripcion = CType(factura.IdFactura, String) Select x).ToList

                    'recorrer la lista de impresiones y actualizar el id de factura.
                    For Each impresion As tblImpresion In ListaImpresionesF
                        impresion.descripcion = nuevaFactura.IdFactura
                        impresion.bitImpreso = False
                        conexion.SaveChanges()
                    Next

                    '----------------- FIN DE DOCS DE IMPRESION.


                    '------------- DOC DE IMPRESION.

                    'Cambiar registros de Estado de Cuenta y Factura de tbl impresion a la nueva factura.
                    Dim ListaImpresionesE As List(Of tblImpresion) = (From x In conexion.tblImpresions Where x.tblTipoImpresion.bitEstadoCuenta = True _
                                                                      And x.descripcion = CType(factura.IdFactura, String) Select x).ToList

                    'recorrer la lista de impresiones y actualizar el id de factura.
                    For Each impresion As tblImpresion In ListaImpresionesE
                        impresion.descripcion = nuevaFactura.IdFactura
                        conexion.SaveChanges()
                    Next


                    '----------------- FIN DE DOCS DE IMPRESION.


                    'guarda todos los cambios.
                    conexion.SaveChanges()


                    'completar la transaccion.
                    transaction.Complete()

                Catch ex As System.Data.EntityException
                    success = False
                Catch ex As Exception
                    success = False
                    ' Handle errors and deadlocks here and retry if needed. 
                    ' Allow an UpdateException to pass through and 
                    ' retry, otherwise stop the execution. 
                    If ex.[GetType]() <> GetType(UpdateException) Then
                        Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                        alertas.fnErrorGuardar()
                        Exit Try
                        ' If we get to this point, the operation will be retried. 
                    End If
                End Try

            End Using

            If success = True Then
                conexion.AcceptAllChanges()
                alertas.fnAnulado()
            Else
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            'cerrar la conexion
            conn.Close()

            'finalizar el proceso de conexion.
        End Using


        If success = True Then
            'Si fue anulado la salida  se vuelve a llenar el grid de salidas.
            frm_llenarLista()
        End If



    End Sub


    Private Function fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click
        Try
            'If Me.grdDatos.CurrentRow.Index >= 0 Then
            'Else
            '    Return False
            'End If



            If Me.grdDatos.Rows.Count > 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

                'obtener el indice seleccionado.
                Dim bitGuiasListas As Boolean = False
                Dim id As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

                If (Me.grdDatos.CurrentColumn.Name = "chmImprGuias") And fila >= 0 Then

                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmImprGuias").Value

                    If valor = False Then

                        If RadMessageBox.Show("Desea Imprimir Guias !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then

                            'conexion nueva.
                            Dim conexion As New dsi_pos_demoEntities

                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                                '----------------------------------  inicio

                                'consultar si existe una sola guia.
                                Dim listaImpresiones As List(Of tblImpresion) = (From im In conexion.tblImpresions
                                                            Join en In conexion.tblEnvios On CType(en.codigo, String) Equals im.descripcion
                                                         Join es In conexion.tblEnvio_Salida On en.codigo Equals es.envio
                                                         Join s In conexion.tblSalidas On s.idSalida Equals es.salida
                                                         Where s.IdFactura = id And im.tblTipoImpresion.bitGuia = True And im.bitImpreso = False
                                                         Select im).ToList


                                If listaImpresiones.Count = 0 Then
                                    alertas.contenido = "Utilice Reimprimir / No existen guias"
                                    alertas.fnErrorContenido()
                                    Me.grdDatos.Rows(fila).Cells("chmImprGuias").Value = False
                                ElseIf listaImpresiones.Count = 1 Then
                                    'imprimir la guia.


                                    For Each lImpresion As tblImpresion In listaImpresiones

                                        Dim impresion As tblImpresion = (From im In conexion.tblImpresions Where im.codigo = lImpresion.codigo Select im).FirstOrDefault

                                        'seleccionar una impresora
                                        'frmImpresoras.Text = "Impresoras"
                                        'frmImpresoras.ShowDialog()
                                        'frmImpresoras.Dispose()
                                        'asignar impresora default.
                                        '  mdlPublicVars.fnImpresoraDefault(impresion.tblTipoImpresion.tblImpresora.nombre)

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

                                            Me.grdDatos.Rows(fila).Cells("chmImprGuias").Value = True
                                        Else
                                            Me.grdDatos.Rows(fila).Cells("chmImprGuias").Value = False
                                        End If
                                    Next
                                ElseIf listaImpresiones.Count > 1 Then
                                    bitGuiasListas = True
                                End If


                                '----------------------------------  fin
                                conn.Close()
                            End Using
                        Else
                            Me.grdDatos.Rows(fila).Cells("chmImprGuias").Value = False


                        End If
                        llenagrid()
                    End If

                ElseIf (Me.grdDatos.CurrentColumn.Name = "chmImprFactura") And fila >= 0 Then

                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value

                    Dim conex As dsi_pos_demoEntities
                    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                        conn.Open()
                        conex = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                        Dim tblfac As tblFactura = (From x In conex.tblFacturas Where x.IdFactura = id Select x).FirstOrDefault

                        If tblfac.bitImpreso = True Then

                            frmAlertasPantalla.Text = "Alertas Pantalla"
                            frmAlertasPantalla.lblMensaje.Text = "¡ESTA FACTURA YA FUE IMPRESA!"
                            frmAlertasPantalla.lblPiePagina.Text = "¡SE ENVIARA CORREO INFORMATIVO A GERENCIA GENERAL!"
                            frmAlertasPantalla.WindowState = FormWindowState.Maximized
                            frmAlertasPantalla.StartPosition = FormStartPosition.CenterScreen
                            frmAlertasPantalla.ShowDialog()
                            frmAlertasPantalla.Dispose()

                            conn.Close()
                            Return False
                            Exit Function
                        End If

                        conn.Close()
                    End Using

                    If valor = False Then

                        If RadMessageBox.Show("Desea Imprimir la Factura !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then

                            'verificar si tiene resolucion, de lo contrario sugerir
                            If fnErrores(id) = True Then
                                Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False
                                Return False
                            End If


                            'conexion nueva.
                            Dim conexion As New dsi_pos_demoEntities

                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                                '---------------------------------

                                Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where CType(x.descripcion, String) = CType(id, String) And x.tblTipoImpresion.bitFactura = True Select x).FirstOrDefault
                                If impresion IsNot Nothing Then
                                    If impresion.bitImpreso = False Then

                                        'seleccionar una impresora.
                                        'frmImpresoras.Text = "Impresoras"
                                        'frmImpresoras.ShowDialog()
                                        'frmImpresoras.Dispose()
                                        'asignar impresora default.
                                        'mdlPublicVars.fnImpresoraDefault(impresion.tblTipoImpresion.tblImpresora.nombre)

                                        Dim reportetipo As String = ""

                                        Dim salf As tblSalida_Factura = (From x In conexion.tblSalida_Factura Where x.factura = id Select x).FirstOrDefault

                                        Dim sal As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = salf.salida Select x).FirstOrDefault

                                        If sal.credito = True Then
                                            reportetipo = "factura_FacturaSinDescCR.rpt"
                                        ElseIf sal.contado = True Then
                                            reportetipo = "factura_FacturaSinDesc.rpt"
                                        End If

                                        Dim r As New clsReporte
                                        conexion.CommandTimeout = 10000
                                        r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", impresion.descripcion, mdlPublicVars.idEmpresa))
                                        r.nombreParametro = "@filtro"
                                        r.reporte = reportetipo
                                        ''impresion.tblTipoImpresion.reporte
                                        r.parametro = ""

                                        ' r.verReporte()

                                        r.imprimirReporte()

                                        If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                            impresion.bitImpreso = True
                                            impresion.usuarioImprime = mdlPublicVars.idUsuario
                                            impresion.fechaImpresion = fechaServer


                                            Dim factura As tblFactura = (From f In conexion.tblFacturas Where f.IdFactura = id Select f).FirstOrDefault
                                            factura.bitImpreso = True


                                            conexion.SaveChanges()
                                            Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = True
                                        Else
                                            Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False
                                        End If
                                    Else
                                        Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False
                                        alertas.contenido = "Utilice Reimprimir"
                                        alertas.fnErrorContenido()
                                    End If
                                Else
                                    Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False
                                    alertas.contenido = "No existe Formato de Impresio"
                                    alertas.fnErrorContenido()
                                End If



                                '------------------------------------- fin del proceso

                                conn.Close()
                            End Using
                        Else
                            Me.grdDatos.Rows(fila).Cells("chmImprFactura").Value = False

                        End If
                        llenagrid()
                    End If



                ElseIf (Me.grdDatos.CurrentColumn.Name = "chmImprEstCuenta") And fila >= 0 Then


                    Dim valor As Boolean = Me.grdDatos.Rows(fila).Cells("chmImprEstCuenta").Value

                    If valor = False Then


                        If RadMessageBox.Show("Desea Imprimir la Estado de Cuenta !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then


                            'conexion nueva.
                            Dim conexion As New dsi_pos_demoEntities

                            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                                conn.Open()
                                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                                '---------------------------------

                                Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where CType(x.descripcion, String) = CType(id, String) And x.tblTipoImpresion.bitEstadoCuenta = True Select x).FirstOrDefault
                                If impresion IsNot Nothing Then
                                    If impresion.bitImpreso = False Then

                                        'asignar impresora default.

                                        ' mdlPublicVars.fnImpresoraDefault(impresion.tblTipoImpresion.tblImpresora.nombre)


                                        'frmImpresoras.Text = "Impresoras"
                                        'frmImpresoras.ShowDialog()
                                        'frmImpresoras.Dispose()

                                        Dim r As New clsReporte
                                        r.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_reporteEstadoCuentaClientePicking("", impresion.cliente, mdlPublicVars.idEmpresa))
                                        r.nombreParametro = "@filtro"
                                        r.reporte = impresion.tblTipoImpresion.reporte
                                        r.parametro = ""


                                        r.verReporte()

                                        r.imprimirReporte()

                                        If MessageBox.Show("Se imprimio correctamente !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                                            impresion.bitImpreso = True
                                            impresion.usuarioImprime = mdlPublicVars.idUsuario
                                            impresion.fechaImpresion = fechaServer
                                            conexion.SaveChanges()
                                            Me.grdDatos.Rows(fila).Cells("chmImprEstCuenta").Value = True
                                        Else
                                            Me.grdDatos.Rows(fila).Cells("chmImprEstCuenta").Value = False
                                        End If
                                    Else
                                        Me.grdDatos.Rows(fila).Cells("chmImprEstCuenta").Value = False
                                        alertas.contenido = "Utilice Reimprimir"
                                        alertas.fnErrorContenido()
                                    End If
                                Else
                                    Me.grdDatos.Rows(fila).Cells("chmImprEstCuenta").Value = False
                                    alertas.contenido = "No existe Formato de Impresion"
                                    alertas.fnErrorContenido()
                                End If



                                '------------------------------------- fin del proceso

                                conn.Close()
                            End Using
                        Else
                            Me.grdDatos.Rows(fila).Cells("chmImprEstCuenta").Value = False


                        End If
                        llenagrid()
                    End If


                End If




                If bitGuiasListas Then
                    'abrir el formulario para seleccionar la guia a imprimir.
                    frmGuiasListaImprimir.Text = "Imprimir Guias"
                    frmGuiasListaImprimir.idFactura = id
                    frmGuiasListaImprimir.ShowDialog()
                End If



            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return False

    End Function





    Private Function fnErrores(id As String)


        '1ro. consulta el tipo de impresion.

        'si bitError retorno false existen errores
        Dim bitError As Boolean = False
        Dim bitAnulado As Boolean = False


        'si bitSugerir Resolucion = verdadero abre el formulario.
        Dim bitSugerirResolucion As Boolean = False

        'crear la conexion
        Dim conection As New dsi_pos_demoEntities


        'abrir la conexion
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conection = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                Dim factura As tblFactura = (From x In conection.tblFacturas Where x.IdFactura = id Select x).FirstOrDefault
                bitAnulado = factura.anulado

                'si la factura no tiene resolucion 
                If factura.idResolucion Is Nothing And factura.anulado = False Then
                    bitSugerirResolucion = True
                Else
                    bitSugerirResolucion = False
                End If

            Catch ex As Exception
            End Try
            'cerrar la conexion
            conn.Close()

            'finalizar el proceso de conexion.
        End Using


        '1ro. verificar si la factura esta anulada, si esta anulada debe salir del proceso.
        If bitAnulado = True Then

            'salir del proceso.
            MessageBox.Show("Factura Anualda !!!", mdlPublicVars.nombreSistema)
            'returno que si existe un erorr
            Return True
        End If

        '2do. verificar si tiene asignada una resolucion, de no tener abrir el formulario.
        If bitSugerirResolucion = True Then

            MessageBox.Show("Debe verificar datos de impresion !!!")

            'mostrar el formulario
            frmFacturaDescuento.codigo = id
            frmFacturaDescuento.Text = "Datos de Impresión"
            frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
            frmFacturaDescuento.ShowDialog()


            'retorna que si existen errores.
            Return True

        End If



        'retorna que no existen errores en la funcion.
        Return False


    End Function

    'CAMBIO DE FILTRO FECHA
    Public Overloads Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs)
        If cargo Then
            frm_llenarLista()
        End If
    End Sub

    Private Sub bntBuscar_Click(sender As Object, e As EventArgs) Handles bntBuscar.Click
        Try

            Me.grdDatos.DataSource = Nothing

            llenagrid()
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub


End Class
