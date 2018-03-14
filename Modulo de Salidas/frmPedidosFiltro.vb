Imports System.Linq

Public Class frmPedidosFiltro

    Private Sub frmPedidosFiltro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdTipoVehiculo)
        mdlPublicVars.comboActivarFiltroLista(cmbFechas)
        fnLlenarGrid()
        fnLlenarCombo()
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    'Llenar grid
    Private Sub fnLlenarGrid()
        Dim tipoVehiculos = (From x In ctx.tblArticuloTipoVehiculoes _
                     Select Agregar = True, Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.Rows.Clear()
        For Each v As Object In tipoVehiculos
            Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.CODIGO, v.NOMBRE)
        Next
    End Sub

    'Llenar Combo
    Private Sub fnLlenarCombo()
        Dim datos = (From x In ctx.tblListaFiltroFechas Select x.orden, codigo = x.dias, x.nombre
                     Order By orden Ascending)

        With cmbFechas
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = datos
        End With
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        fnFiltrar()
    End Sub

    Private Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label)
        Try
            Dim contador As Integer = 0
            Dim estado As Boolean
            For index As Integer = 0 To grd.Rows.Count - 1
                estado = grd.Rows(index).Cells("chmAgregar").Value
                If estado Then
                    contador = contador + 1
                End If
            Next
            lbl.Text = contador.ToString
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try
    End Sub

    'Funcion utilizada para el manejo del checkbutton "Todos"
    Private Sub fnActivaTodos(ByVal estado As Boolean, ByRef grd As Telerik.WinControls.UI.RadGridView)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells("chmAgregar").Value = estado
        Next
    End Sub

    'Filtrar
    Public Sub fnFiltrar()
        Dim tipoVehiculo As String = tbl.fnExtraerCadenaCodigosGridViewTelerik(grdTipoVehiculo, 1, 0)

        Dim datos = ctx.sp_filtro_lista_salidas(mdlPublicVars.idEmpresa, "", dtpDesde.Text, dtpHasta.Text & " 23:59:59", CInt(cmbFechas.SelectedValue),
                                                rbnRango.Checked, rbnTiempo.Checked, tipoVehiculo)

        frmPedidosLista.grdDatos.DataSource = datos
        frmPedidosLista.filtroActivo = True
    End Sub

    Private Sub chkTodosTipoVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosTipoVehiculo.CheckedChanged
        fnActivaTodos(chkTodosTipoVehiculo.Checked, grdTipoVehiculo)
    End Sub

    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged

        mdlPublicVars.fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo, "chmAgregar")
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
