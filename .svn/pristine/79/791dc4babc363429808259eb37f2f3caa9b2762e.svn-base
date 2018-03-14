
Partial Class frmReportesVentas
    Inherits System.Web.UI.Page
    Dim sp As String
    Dim filtro As String

    Private Sub infoReporte(ByVal opcion As Int16, ByVal procedimiento As System.String)
        Dim retorno As System.String
        Dim g As New clsGenerales
        retorno = procedimiento & " " & opcion & ","
        retorno = retorno & g.fechaSQL(Me.fechaInicio.SelectedDate) & "," & g.fechaSQL(Me.fechaFin.SelectedDate) & ","
        filtro = filtro & "Desde " & Me.fechaInicio.SelectedDate.ToString & " Hasta " & Me.fechaFin.SelectedDate.ToString
        If Me.Empresa.SelectedIndex = 0 Then
            filtro = filtro & "- Todas las empresas"
            retorno = retorno & "0,0,"
        Else
            filtro = "Empresa:" & Me.Empresa.SelectedItem.Text
            retorno = retorno & Me.Empresa.Text & ",1,"
        End If

        If Me.cliente.SelectedIndex = 0 Then
            filtro = filtro & " - Todos los clientes"
            retorno = retorno & "0,0,"
        Else
            filtro = filtro & " Cliente: " & Me.cliente.SelectedItem.Text
            retorno = retorno & Me.cliente.Text & ",1,"
        End If

        If Me.vendedor.SelectedIndex = 0 Then
            filtro = filtro & " - " & "Todos los vendedores"
            retorno = retorno & "0,0,"
        Else
            filtro = filtro & " - Vendedor: " & Me.vendedor.SelectedItem.Text
            retorno = retorno & Me.vendedor.Text & ",1,"
        End If

        If Me.articulo.SelectedIndex = 0 Then
            filtro = filtro & " - " & "Todos los articulos"
            retorno = retorno & "0,0,"
        Else
            filtro = filtro & " - Articulo: " & Me.articulo.SelectedItem.Text
            retorno = retorno & Me.articulo.Text & ",1,"
        End If

        If Me.categoria.SelectedIndex = 0 Then
            filtro = filtro & " - " & "Todas las categorias"
            retorno = retorno & "0,0,"
        Else
            filtro = filtro & " - Categoria: " & Me.categoria.SelectedItem.Text
            retorno = retorno & Me.categoria.Text & ",1,"
        End If

        If Me.tipoMovimiento.SelectedIndex = 0 Then
            filtro = filtro & " - " & "Todos los tipos de movimientos"
            retorno = retorno & "0,0"
        Else
            filtro = filtro & " - Tipo movimiento: " & Me.tipoMovimiento.SelectedItem.Text
            retorno = retorno & Me.tipoMovimiento.Text & ",1"
        End If
        'Se agrega el parametro de idSalida para el reporte de salida en movimiento
        retorno = retorno & ",0," & Session("idUsuario")
        sp = retorno
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Call llenaCombos()
        Me.fechaInicio.SelectedDate = Today
        Me.fechaFin.SelectedDate = Today


        If Session("su") <> "True" Then
            Me.fechaFin.Enabled = False
            Me.fechaInicio.Enabled = False
        End If


    End Sub



    Private Sub llenaCombos()
        Dim e As New clsEmpresa
        Dim c As New clsClientes
        Dim v As New clsVendedor
        Dim a As New clsArticulos
        Dim cat As New clsCategoria
        Dim t As New clsDevuelveTabla

        If Session("su") = "True" Then
            Me.Empresa.DataSource = e.Tabla
            Me.Empresa.DataTextField = "nombre"
            Me.Empresa.DataValueField = "idEmpresa"
            Me.Empresa.DataBind()
        Else
            t.sqlString = "select ' Vacio' nombre,0 idEmpresa from tblempresa union select nombre,idempresa from tblEmpresa where idEmpresa = " & CInt(Session("idEmpresa"))
            Me.Empresa.DataSource = t.Tabla
            Me.Empresa.DataTextField = "nombre"
            Me.Empresa.DataValueField = "idEmpresa"
            Me.Empresa.DataBind()
        End If

        Me.cliente.DataSource = c.Tabla
        Me.cliente.DataTextField = "nombre"
        Me.cliente.DataValueField = "idCliente"
        Me.cliente.DataBind()

        Me.vendedor.DataSource = v.Tabla
        Me.vendedor.DataValueField = "idVendedor"
        Me.vendedor.DataTextField = "nombre"
        Me.vendedor.DataBind()

        t.sqlString = "select 0 idarticulo,' Vacio' nombre " _
        & "from tblarticulos union " _
        & "SELECT idarticulo,nombre from tblarticulos " _
        & "where idarticulo <> 0 order by nombre asc"

        'LLenamos el combo con la informacion del articulo
        Me.articulo.DataSource = t.Tabla
        Me.articulo.DataTextField = "nombre"
        Me.articulo.DataValueField = "idArticulo"
        Me.articulo.DataBind()

        Me.categoria.DataSource = cat.Tabla
        Me.categoria.DataTextField = "nombre"
        Me.categoria.DataValueField = "idCAtegoria"
        Me.categoria.DataBind()

        t.sqlString = "select idTipoMovimiento,nombre from tblTipoMovimiento where disminuyeInventario = 1 or idTipoMovimiento = 0"
        Me.tipoMovimiento.DataSource = t.Tabla
        Me.tipoMovimiento.DataTextField = "nombre"
        Me.tipoMovimiento.DataValueField = "idTipoMovimiento"
        Me.tipoMovimiento.DataBind()




    End Sub

    Protected Sub lnkVentasDetallado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVentasDetallado.Click
        Dim t As New clsDevuelveTabla
        Dim r As New clsReporte
        If Session("su") = "False" Then
            If Me.fechaInicio.SelectedDate > Me.fechaFin.SelectedDate Then
                MsgBox1.ShowMessage("Rango de fechas no valido!!!")
                Exit Sub
            End If

        End If


        If Session("su") <> "True" And Me.Empresa.SelectedIndex = 0 Then
            Exit Sub
        End If


        r.nombreParametro = "filtro"
        infoReporte(1, "spReportesVentas")
        r.parametro = filtro
        r.reporte = "rptVentasDetalle.rpt"
        r.tabla = t.tablaSP(sp)
        r.verReporte()
    End Sub

    Protected Sub lnkVentasResumido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVentasResumido.Click
        Dim t As New clsDevuelveTabla
        Dim r As New clsReporte
        If Session("su") <> "True" And Me.Empresa.SelectedIndex = 0 Then
            Exit Sub
        End If

        r.nombreParametro = "filtro"
        infoReporte(2, "spReportesVentas")
        r.parametro = filtro
        r.reporte = "rptVentasResumido.rpt"
        r.tabla = t.tablaSP(sp)
        r.verReporte()
    End Sub

    Protected Sub lnkVentasInfoTelefono_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVentasInfoTelefono.Click
        Dim t As New clsDevuelveTabla
        Dim r As New clsReporte
        If Session("su") <> "True" And Me.Empresa.SelectedIndex = 0 Then
            Exit Sub
        End If

        r.nombreParametro = "filtro"
        infoReporte(3, "spReportesVentas")
        r.parametro = filtro
        r.reporte = "rptVentaInfoTelefono.rpt"
        r.tabla = t.tablaSP(sp)
        r.verReporte()
    End Sub

    Protected Sub lnkVentasUtilidades_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVentasUtilidades.Click
        Dim t As New clsDevuelveTabla
        Dim r As New clsReporte
        If Session("su") <> "True" And Me.Empresa.SelectedIndex = 0 Then
            Exit Sub
        End If

        r.nombreParametro = "filtro"
        infoReporte(5, "spReportesVentas")
        r.parametro = filtro
        r.reporte = "rptVentasUtilidad.rpt"
        r.tabla = t.tablaSP(sp)
        r.verReporte()
    End Sub

    Protected Sub lnkVentaActivacionReparacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVentaActivacionReparacion.Click
        Dim t As New clsDevuelveTabla
        Dim r As New clsReporte
        If Session("su") = "False" Then
            If Me.fechaInicio.SelectedDate > Me.fechaFin.SelectedDate Then
                MsgBox1.ShowMessage("Rango de fechas no valido!!!")
                Exit Sub
            End If

        End If


        If Session("su") <> "True" And Me.Empresa.SelectedIndex = 0 Then
            Exit Sub
        End If


        r.nombreParametro = "filtro"
        infoReporte(6, "spReportesVentas")
        r.parametro = filtro
        r.reporte = "rptVentasDetalle.rpt"
        r.tabla = t.tablaSP(sp)
        r.verReporte()
    End Sub



    Protected Sub lnkActivacionReparacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkActivacionReparacion.Click
        Dim t As New clsDevuelveTabla
        Dim r As New clsReporte
        If Session("su") = "False" Then
            If Me.fechaInicio.SelectedDate > Me.fechaFin.SelectedDate Then
                MsgBox1.ShowMessage("Rango de fechas no valido!!!")
                Exit Sub
            End If

        End If


        If Session("su") <> "True" And Me.Empresa.SelectedIndex = 0 Then
            Exit Sub
        End If


        r.nombreParametro = "filtro"
        infoReporte(7, "spReportesVentas")
        r.parametro = filtro
        r.reporte = "rptVentasDetalle.rpt"
        r.tabla = t.tablaSP(sp)
        r.verReporte()
    End Sub
End Class
