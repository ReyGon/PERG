Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.EntityClient

Public Class frmFacturaImprimir

    Private _bitContado As Boolean
    Private _bitCredito As Boolean
    Private _codClie As Integer
    Private _dirFact As String
    Private facturado As Boolean
    Private _bitFacturar As Boolean

    Public Property bitFacturar As Boolean
        Get
            bitFacturar = _bitFacturar
        End Get
        Set(ByVal value As Boolean)
            _bitFacturar = value
        End Set
    End Property

    Public Property bitContado() As Boolean
        Get
            bitContado = _bitContado
        End Get
        Set(ByVal value As Boolean)
            _bitContado = value
        End Set
    End Property

    Public Property bitCredito() As Boolean
        Get
            bitCredito = _bitCredito
        End Get
        Set(ByVal value As Boolean)
            _bitCredito = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Public Property dirFact() As String
        Get
            dirFact = _dirFact
        End Get
        Set(ByVal value As String)
            _dirFact = value
        End Set
    End Property

    Private Sub frmFacturaImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdImpresiones)
        fnListaImpresion()
        facturado = False
        frmPedidosLista.frm_llenarLista()
    End Sub

    'Funcion utilizada para llenar el grid con los datos de la lista de impresion
    Private Sub fnListaImpresion()
        Me.grdImpresiones.Rows.Clear()
        Dim lista As List(Of tblImpresion) = (From x In ctx.tblImpresions Where x.cliente = codClie And x.bitImpreso = False _
                                              Select x Order By x.fechaRegistro Descending).ToList

        Dim impresion As tblImpresion
        'Recorremos la lista y llenamos el grid
        Dim usuarioImprimio As String = ""
        For Each impresion In lista
            Dim fila As Object()

            fila = {impresion.codigo, Format(impresion.fechaRegistro, mdlPublicVars.formatoFecha),
                    impresion.tblTipoImpresion.nombre, impresion.descripcion, impresion.tblUsuario.nombre}
            Me.grdImpresiones.Rows.Add(fila)
        Next

        'seleccionar el primer registro
        If Me.grdImpresiones.Rows.Count > 0 Then
            Me.grdImpresiones.Rows(0).IsCurrent = True
        End If

    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel2
        Me.Close()
    End Sub

    'IMPRIMIR
    Private Sub fnImprimir() Handles Me.panel1


        'Obtenemos la fila
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdImpresiones)
        Dim codigo As Integer = Me.grdImpresiones.Rows(fila).Cells("iddetalle").Value

        'codigo de la factura para pasar el bitimpreso a true
        Dim codFactura As Integer = Me.grdImpresiones.Rows(fila).Cells("descripcion").Value
        Dim bitError As Boolean = False
       

            Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor

            Dim conexion As New dsi_pos_demoEntities

            'abrir la conexion
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Try

                    'Obtenemos el registro
                    Dim impresion As tblImpresion = (From x In conexion.tblImpresions Where x.codigo = codigo _
                                                     Select x).FirstOrDefault

                    Dim tipoReporte As tblTipoImpresion = (From x In conexion.tblTipoImpresions.AsEnumerable Where x.codigo = impresion.tipoImpresion _
                                                                   Select x).FirstOrDefault

                    If tipoReporte IsNot Nothing Then
                        Dim c As New clsReporte

                        If tipoReporte.codigo = 1 Then
                            c.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_reporteEstadoCuentaCliente1("", impresion.cliente, fechaServidor.AddMonths(-1), fechaServidor, impresion.tblCliente.idEmpresa))
                        ElseIf tipoReporte.codigo = 2 Then
                            c.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_reporteOfertas("", mdlPublicVars.idEmpresa, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal))
                        ElseIf tipoReporte.codigo = 18 Or tipoReporte.codigo = 19 Then
                        Dim factura As tblFactura = (From x In conexion.tblFacturas Where x.IdFactura = codFactura).FirstOrDefault

                        If factura.idResolucion Is Nothing Then
                            bitError = True
                            MessageBox.Show("Debe verificar datos de impresion")

                            'mostrar el formulario
                            frmFacturaDescuento.codigo = factura.IdFactura
                            frmFacturaDescuento.Text = "Datos de Impresión"
                            frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
                            frmFacturaDescuento.ShowDialog()

                        Else
                            c.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_ReporteFactura1("", impresion.descripcion, mdlPublicVars.idEmpresa))

                            'captuamos la factura y actualizamos el bitimpreso a true
                            factura.bitImpreso = True
                            conexion.SaveChanges()
                            alerta.fnGuardar()

                        End If
                        
                        ElseIf tipoReporte.codigo = 17 Then
                            c.tabla = mdlPublicVars.EntitiToDataTable(conexion.sp_reporteEstadoCuentaClientePicking("", impresion.descripcion, mdlPublicVars.idEmpresa))
                        End If

                    If bitError = False Then
                        c.nombreParametro = "@filtro"
                        c.reporte = tipoReporte.reporte
                        c.parametro = ""
                        c.imprimirReporte()
                        impresion.bitImpreso = True
                        impresion.usuarioImprime = mdlPublicVars.idUsuario
                        conexion.SaveChanges()
                    End If
                        
                    End If

                Catch ex As Exception
                    alerta.fnError()
                End Try

                conn.Close()
            End Using
       
    End Sub

    'VISTA PREVIA
    Private Sub fnVistaPrevia() Handles Me.panel0
        ''Obtenemos la fila
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdImpresiones)
        Dim codigo As Integer = Me.grdImpresiones.Rows(fila).Cells("iddetalle").Value
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
        'Obtenemos el registro
        Dim impresion As tblImpresion = (From x In ctx.tblImpresions Where x.codigo = codigo _
                                         Select x).FirstOrDefault

        Dim tipoReporte As tblTipoImpresion = (From x In ctx.tblTipoImpresions.AsEnumerable Where x.codigo = impresion.tipoImpresion _
                                                       Select x).FirstOrDefault

        If tipoReporte IsNot Nothing Then
            Dim c As New clsReporte

            If tipoReporte.codigo = 1 Then
                c.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_reporteEstadoCuentaCliente1("", impresion.cliente, fechaServidor.AddMonths(-1), fechaServidor, impresion.tblCliente.idEmpresa))
            ElseIf tipoReporte.codigo = 2 Then
                c.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_reporteOfertas("", mdlPublicVars.idEmpresa, mdlPublicVars.General_idTipoInventario, mdlPublicVars.General_idAlmacenPrincipal))
            ElseIf tipoReporte.codigo = 18 Or tipoReporte.codigo = 19 Then
                c.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_ReporteFactura1("", impresion.descripcion, mdlPublicVars.idEmpresa))
            ElseIf tipoReporte.codigo = 17 Then
                c.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_reporteEstadoCuentaClientePicking("", impresion.descripcion, mdlPublicVars.idEmpresa))
            End If

            c.nombreParametro = "@filtro"
            c.reporte = tipoReporte.reporte
            c.parametro = ""

            frmDocumentosSalida.reporteBase = c.DocumentoReporte
            frmDocumentosSalida.bitGenerico = False
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitImg = False
            frmDocumentosSalida.codigo = codClie
            frmDocumentosSalida.bitListaCombo = False
            frmDocumentosSalida.ListaCombo = ""
            frmDocumentosSalida.Text = "Impresión"
            frmDocumentosSalida.ShowDialog()
            frmDocumentosSalida.Dispose()
        End If
    End Sub



    Private Sub fnAjustarFactura() Handles Me.panel3
        Try
            mdlPublicVars.superSearchId = 0

            frmFacturasLista.fnCambioFila()




            If mdlPublicVars.superSearchFilasGrid > 0 Then


                Dim codigo As Integer = fnGrid_codigoFilaSeleccionada(grdImpresiones)

                frmFacturaDescuento.codigo = grdImpresiones.Rows(codigo).Cells("Descripcion").Value
                frmFacturaDescuento.Text = "Datos de Impresión"
                frmFacturaDescuento.StartPosition = FormStartPosition.CenterScreen
                frmFacturaDescuento.ShowDialog()





                'Dim codigo As Integer = fnGrid_codigoFilaSeleccionada(grdImpresiones)
                'mdlPublicVars.superSearchId = grdDatos.Rows(codigo).Cells("Codigo").Value
                'mdlPublicVars.superSearchNombre = grdDatos.Rows(codigo).Cells("Nombre").Value
                'mdlPublicVars.superSearchClave = grdDatos.Rows(codigo).Cells("Clave").Value
                'mdlPublicVars.superSearchNit = grdDatos.Rows(codigo).Cells("Nit").Value
                'Me.Close()


            End If

        Catch ex As Exception

        End Try
    End Sub

    'Private Function fnValidarResolucionFactura(ByVal codigoFactura As Integer) As Boolean
    '    Try
    '        Dim fac As tblFactura = (From x In ctx.tblFacturas Where x.IdFactura = codigoFactura Select x).FirstOrDefault

    '        If (fac.idResolucion Is Nothing) Then
    '            Return False
    '        Else
    '            Return True
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Function


End Class
