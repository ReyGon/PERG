Imports System.Linq
Imports Telerik.WinControls

Public Class frmListadoImpresionDocumento

#Region "Variables"
    Private permiso As New clsPermisoUsuario
    Private _salida As Integer

    Public Property salida As Integer
        Get
            salida = _salida
        End Get
        Set(ByVal value As Integer)
            _salida = value
        End Set
    End Property
#End Region

#Region "LOAD"
    Private Sub frmListadoImpresionDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        rbnDocumento.Checked = True
        fnListaImpresion()
    End Sub
#End Region

#Region "Funciones"
    'Funcion utilizada para llenar el grid con los datos de la lista de impresion
    Private Sub fnListaImpresion()
        Me.grdDatos.DataSource = Nothing
        Me.grdDatos.Rows.Clear()

        Dim lista As List(Of tblImpresion) = Nothing
        Dim desde As DateTime = CDate(dtpDesde.Text)
        Dim hasta As DateTime = CDate(dtpHasta.Text & " 23:59:59")
        If rbnDocumento.Checked Then
            'Obtenemos informacion de la salida
            Dim salidaEn As tblSalida = (From x In ctx.tblSalidas.AsEnumerable Where x.idSalida = salida _
                                         Select x).FirstOrDefault


            If (salidaEn.IdFactura > 0 Or salidaEn.IdFactura IsNot Nothing) Then
                Dim codSalida As String = CStr(salidaEn.IdFactura)

                lista = (From x In ctx.tblImpresions
                Where (x.tblTipoImpresion.bitFactura = True And x.descripcion = codSalida) _
                Select x Order By x.fechaRegistro Descending).ToList

            End If
        ElseIf rbnTodos.Checked Then
            lista = (From x In ctx.tblImpresions
                    Where x.usuarioRegistro = mdlPublicVars.idUsuario _
                    And x.fechaRegistro > desde And x.fechaRegistro < hasta And (x.tblTipoImpresion.bitFactura) _
                    Select x Order By x.fechaRegistro Descending).ToList

        End If
        'Recorremos la lista y llenamos el grid
        Dim usuarioImprimio As String = ""
        If lista IsNot Nothing Then
            For Each impresion As tblImpresion In lista
                Dim fila As Object()

                fila = {impresion.codigo, Format(impresion.fechaRegistro, mdlPublicVars.formatoFecha),
                        impresion.tblTipoImpresion.nombre, impresion.descripcion, impresion.tblUsuario.nombre}
                Me.grdDatos.Rows.Add(fila)
            Next
        End If

    End Sub

#End Region

#Region "Eventos"
    'Chequear el boton de documento
    Private Sub rbnDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnDocumento.CheckedChanged
        rgbFiltros.Enabled = Not rbnDocumento.Checked
        fnListaImpresion()
    End Sub

    'Chequear el boton de todos
    Private Sub rbnTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnTodos.CheckedChanged
        fnListaImpresion()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnListaImpresion()
    End Sub

    'IMPRIMIR
    Private Sub fnImprimir() Handles Me.panel0
        'Obtenemos la fila
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
        Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("iddetalle").Value
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

            frmDocumentosSalida.txtTitulo.Text = "Re-Impresion"
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.reporteBase = c.DocumentoReporte()
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub
#End Region

End Class