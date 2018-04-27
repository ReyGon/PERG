Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmFiltrosInventarios

    Dim codClie As Integer = mdlPublicVars.supersearchclientelibre

    Private Sub FiltrosInventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdMarca)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdMarca)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdModelos)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdModelos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoVehiculo)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdTipoVehiculo)
            fnActivaFiltros()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnActivaFiltros()
        Try
            chkTodosModelo.Checked = False
            chkTodosTipo.Checked = False
            chkTodosMarca.Checked = False

            Me.grdTipoVehiculo.Rows.Clear()
            'tipo de vehiculo con grid
            Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre _
                     Select Agregar = If(((From y In ctx.tblCliente_clasificacionCompra _
                                Where x.codigo = y.tipoVehiculo And y.idCliente = codClie _
                                Select y.codigo).FirstOrDefault) > 0, True, False), _
                                IdDetalle = (From y In ctx.tblCliente_clasificacionCompra _
                                Where x.codigo = y.tipoVehiculo And y.idCliente = codClie _
                                Select y.codigo).FirstOrDefault,
                               Codigo = x.codigo, Nombre = x.nombre)

            Me.grdTipoVehiculo.Rows.Clear()
            Dim cont As Integer = 0
            Dim verd As Integer = 0
            Dim v
            For Each v In tp
                cont += 1
                Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
                If v.AGREGAR = False Then
                    verd += 1
                End If
            Next

            'Si no tiene clasificaciones
            If cont = verd Then
                Dim i
                For i = 0 To Me.grdTipoVehiculo.Rows.Count - 1
                    Me.grdTipoVehiculo.Rows(i).Cells("chmAgregar").Value = True
                Next
                chkTodosTipo.Checked = True
            End If

            cont = 0
            verd = 0

            Me.grdModelos.Rows.Clear()
            'modelo de vehiculo con grid
            Dim mo = (From x In ctx.tblArticuloModeloVehiculoes Order By x.nombre _
                     Select Agregar = If(((From y In ctx.tblCliente_ModeloVehiculo _
                                Where x.codigo = y.modeloVehiculo And y.cliente = codClie _
                                Select y.codigo).FirstOrDefault) > 0, True, False), _
                                IdDetalle = (From y In ctx.tblCliente_ModeloVehiculo _
                                Where x.codigo = y.modeloVehiculo And y.cliente = codClie _
                                Select y.codigo).FirstOrDefault,
                               Codigo = x.codigo, Nombre = x.nombre)

            Me.grdModelos.Rows.Clear()
            For Each v In mo
                cont += 1
                Me.grdModelos.Rows.Add(True, v.CODIGO, v.NOMBRE)
                'If v.AGREGAR = False Then
                verd += 1
                'End If
            Next

            'Si no tiene clasificaciones
            If cont = verd Then
                Dim i
                For i = 0 To Me.grdModelos.Rows.Count - 1
                    Me.grdModelos.Rows(i).Cells("chmAgregar").Value = True
                Next
                chkTodosModelo.Checked = True
            End If

            'Llenamos las marcas
            Dim mar = (From x In ctx.tblArticuloMarcaRepuestoes Order By x.nombre _
                      Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)
            Me.grdMarca.Rows.Clear()
            For Each v In mar
                cont += 1
                Me.grdMarca.Rows.Add(True, v.CODIGO, v.NOMBRE)
                'If v.AGREGAR = False Then
                verd += 1
                'End If
            Next
            chkTodosMarca.Checked = True

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells("chmAgregar").Value = estado
        Next
    End Sub


    Private Sub chkTodosMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosMarca.CheckedChanged
        fnActivaTodos(chkTodosMarca.Checked, grdMarca)
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosModelo.CheckedChanged
        fnActivaTodos(chkTodosModelo.Checked, grdModelos)
    End Sub

    Private Sub chkTodosTipo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosTipo.CheckedChanged
        fnActivaTodos(chkTodosTipo.Checked, grdTipoVehiculo)
    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Try
            Me.Close()
        Catch ex As Exception
            Dim codigoTipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            Dim codigomodeloVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            Dim codigoMarcaRepuesto As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
        End Try
    End Sub

    Private Sub fnGuardar() Handles Me.panel0
        Try
            mdlPublicVars.superSearchTipos = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            mdlPublicVars.superSearchModelos = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            mdlPublicVars.superSearchMarcas = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub frmFiltrosInventarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            mdlPublicVars.superSearchTipos = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)
            mdlPublicVars.superSearchModelos = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdModelos, 1, 0)
            mdlPublicVars.superSearchMarcas = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdMarca, 1, 0)
        Catch ex As Exception

        End Try
    End Sub

End Class
