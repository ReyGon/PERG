Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmSalidaBodega
    Dim dt As New clsDevuelveTabla

    Private Sub frmSalidaBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenarGrid()
        fnConfiguracion()
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Columns.Count > 0 Then
            Me.grdDatos.Columns(0).Width = 40 '  Salida
            Me.grdDatos.Columns(1).Width = 40 '  Bodega
            Me.grdDatos.Columns(2).Width = 40 '  Fecha
            Me.grdDatos.Columns(3).Width = 70 '  cliente
            Me.grdDatos.Columns(4).Width = 70 '  vendedor
            Me.grdDatos.Columns(5).Width = 70 '  sacado
            Me.grdDatos.Columns(6).Width = 70 '  revisado
            Me.grdDatos.Columns(7).Width = 70 '  empacado
            Me.grdDatos.Columns(8).Width = 250 ' observacion



            Me.grdDatos.Columns(0).ReadOnly = True ' Salida
            Me.grdDatos.Columns(1).ReadOnly = True ' Bodega
            Me.grdDatos.Columns(2).ReadOnly = True ' Fecha
            Me.grdDatos.Columns(3).ReadOnly = True ' Cliente
            Me.grdDatos.Columns(4).ReadOnly = True ' Vendedor
            Me.grdDatos.Columns(5).ReadOnly = True ' Sacado
            Me.grdDatos.Columns(6).ReadOnly = True ' revisado
            Me.grdDatos.Columns(7).ReadOnly = True ' empacado
            Me.grdDatos.Columns(8).ReadOnly = False ' observacion



        End If

    End Sub

    Private Sub pbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbActualizar.Click
        fnLlenarGrid()
    End Sub

    Private Sub fnLlenarGrid()
        Try
            Dim sp = ctx.sp_bodega_lista(mdlPublicVars.idEmpresa)
            Me.grdDatos.DataSource = sp
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        Dim codpuesbodegaConfig As Integer = 15
        Dim fechahoraserver As DateTime = mdlPublicVars.fnFecha_horaServidor



        Try
            Dim config As tblConfiguracion = (From x In ctx.tblConfiguracions Where x.id = codpuesbodegaConfig Select x).First

            Dim fil As Integer = e.RowIndex
            Dim col As Integer = e.ColumnIndex

            Dim codbodega As Integer = Me.grdDatos.Rows(fil).Cells(1).Value

            'Sacado
            If Me.grdDatos.Columns(col).Name.ToString.ToLower = "sacado" Then
                Dim cons = (From x In ctx.tblEmpleadoes Where x.idpuesto = config.valor Select Codigo = x.idEmpleado, Nombre = x.nombre)
                frmCombo.lblTitulo.Text = "Seleccionar Sacado"
                With frmCombo.combo
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = cons
                End With
                frmCombo.ShowDialog()

                If mdlPublicVars.superSearchId = 0 Then
                Else
                    'actualizar
                    Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codbodega Select x).First
                    bodega.sacado = mdlPublicVars.superSearchId
                    bodega.fechaSacado = fechahoraserver
                    ctx.SaveChanges()
                    alerta.contenido = "Registro Actualizado"
                    alerta.fnErrorContenido()
                    fnLlenarGrid()
                End If
            End If ' fin de sacado.

            'Sacado
            If Me.grdDatos.Columns(col).Name.ToString.ToLower = "revisado" Then
                Dim cons = (From x In ctx.tblEmpleadoes Where x.idpuesto = config.valor Select Codigo = x.idEmpleado, Nombre = x.nombre)
                frmCombo.lblTitulo.Text = "Seleccionar Sacado"
                With frmCombo.combo
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = cons
                End With
                frmCombo.ShowDialog()

                If mdlPublicVars.superSearchId = 0 Then
                Else
                    'actualizar
                    Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codbodega Select x).First
                    bodega.revisado = mdlPublicVars.superSearchId
                    bodega.fechaRevisado = fechahoraserver
                    ctx.SaveChanges()
                    alerta.contenido = "Registro Actualizado"
                    alerta.fnErrorContenido()
                    fnLlenarGrid()
                End If
            End If ' fin de revisado

            'Empacado
            If Me.grdDatos.Columns(col).Name.ToString.ToLower = "empacado" Then
                Dim cons = (From x In ctx.tblEmpleadoes Where x.idpuesto = config.valor Select Codigo = x.idEmpleado, Nombre = x.nombre)
                frmCombo.lblTitulo.Text = "Seleccionar Sacado"
                With frmCombo.combo
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = cons
                End With
                frmCombo.ShowDialog()

                If mdlPublicVars.superSearchId = 0 Then
                Else
                    'actualizar
                    Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codbodega Select x).First
                    bodega.empacado = mdlPublicVars.superSearchId
                    bodega.fechaEmpacado = fechahoraserver
                    ctx.SaveChanges()
                    alerta.contenido = "Registro Actualizado"
                    alerta.fnErrorContenido()
                    fnLlenarGrid()
                End If
            End If ' fin de Empacado




        Catch ex As Exception
            alerta.fnError()
        End Try
    End Sub

    Private Sub grdDatos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellEndEdit


        Try
            Dim fil As Integer = e.RowIndex
            Dim col As Integer = e.ColumnIndex
            Dim dato As String = ""
            Dim codigo As Integer = grdDatos.Rows(fil).Cells(1).Value
            Dim nombreCol As String = Me.grdDatos.Columns(col).Name.ToString.ToLower

            If nombreCol = "observacion" Then

                dato = Me.grdDatos.Rows(fil).Cells(col).Value
                Dim bod As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = codigo Select x).First

                If nombreCol = "observacion" Then
                    bod.observacion = dato
                End If

                ctx.SaveChanges()
                alerta.fnGuardar()

            End If

        Catch ex As Exception
            alerta.fnError()
        End Try
    End Sub

    Private Sub pbModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxModificar.Click
        Try
            Dim codigo As Integer = Me.grdDatos.Rows(Me.grdDatos.SelectedRows(0).Index).Cells(0).Value

            frmSalidas.Text = "Revision en bodega "
            frmSalidas.codigo = codigo
            frmSalidas.bitEditarBodega = True
            frmSalidas.MdiParent = frmMenuPrincipal
            frmSalidas.Show()

        Catch ex As Exception
            alerta.fnError()
        End Try
    End Sub

    Private Sub pbReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReporte.Click, lblEnvio.Click
        Try
            Dim codigo As Integer = Me.grdDatos.Rows(Me.grdDatos.SelectedRows(0).Index).Cells(0).Value
            Dim s As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codigo Select x).First

            'no facturado y despachado.
            If s.facturado = False And s.despachar = True Then
                frmSalidaEnvio.Codigo = codigo
                frmSalidaEnvio.Text = "Envios ..."
                frmSalidaEnvio.StartPosition = FormStartPosition.CenterScreen
                frmSalidaEnvio.ShowDialog()
            Else
                alerta.fnNoEditable()
            End If

        Catch ex As Exception
            alerta.fnError()
        End Try


    End Sub
End Class
