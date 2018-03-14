Imports System.Linq
Imports Telerik.WinControls

Public Class frmListadoImpresiones
    Private _cliente As Integer
    Private permiso As New clsPermisoUsuario

    Public Property cliente() As Integer
        Get
            cliente = _cliente
        End Get
        Set(ByVal value As Integer)
            _cliente = value
        End Set
    End Property

    Private Sub frmListadoImpresiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnListaImpresion()
    End Sub

    'Funcion utilizada para llenar el grid con los datos de la lista de impresion
    Private Sub fnListaImpresion()

        Me.grdDatos.Rows.Clear()
        Dim lista As List(Of tblImpresion) = (From x In ctx.tblImpresions Where x.cliente = cliente _
                                              And x.tblTipoImpresion.bitFoto = False Select x Order By x.fechaRegistro Descending).ToList

        Dim impresion As tblImpresion
        'Recorremos la lista y llenamos el grid
        Dim usuarioImprimio As String = ""
        For Each impresion In lista
            Dim fila As Object()
            Try
                usuarioImprimio = impresion.tblUsuario1.nombre
            Catch ex As Exception
                usuarioImprimio = ""
            End Try

            fila = {impresion.codigo, Format(impresion.fechaRegistro, mdlPublicVars.formatoFecha), impresion.tblTipoImpresion.nombre, impresion.descripcion,
                        impresion.tblUsuario.nombre, usuarioImprimio, impresion.bitImpreso}
            Me.grdDatos.Rows.Add(fila)
        Next

        'seleccionar el primer registro
        If Me.grdDatos.Rows.Count > 0 Then
            Me.grdDatos.Rows(0).IsCurrent = True
        End If


    End Sub

    'Cuando el usuario quiere borrar un registro de impresion
    Private Sub grdDatos_UserDeletingRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowCancelEventArgs) Handles grdDatos.UserDeletingRow
        'Obtenemos el codigo del registro, y si ya ha sido impresio
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdDatos)
        Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("iddetalle").Value
        Dim impreso As Boolean = Me.grdDatos.Rows(fila).Cells("impreso").Value

        If impreso Then
            alerta.contenido = "El registro ya ha sido impreso, no se puede eliminar"
            alerta.fnErrorContenido()
            Exit Sub
        End If

        If RadMessageBox.Show("¿Desea eliminar el registro de impresión?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Obtenemos el registro de la BD
            Dim impresion As tblImpresion = (From x In ctx.tblImpresions Where x.codigo = codigo _
                                             Select x).FirstOrDefault

            'Eliminamos el registro
            ctx.DeleteObject(impresion)
            ctx.SaveChanges()

            alerta.contenido = "Registro eliminado exitosamente"
            alerta.fnErrorContenido()
        Else
            e.Cancel = True
        End If
    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
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
End Class
