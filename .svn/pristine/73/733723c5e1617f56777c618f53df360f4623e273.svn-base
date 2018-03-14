Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.EntityClient
Imports System.Data.Metadata.Edm
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Telerik.WinControls

Public Module mdlPublicVars

    Public frmPosX As Integer
    Public frmPosY As Integer
    Public frmX As Integer
    Public frmY As Integer

    Public coneccion As String
    Friend trial As Boolean
    Friend pideVuelto As Boolean

    Friend idVendedor As Integer = 0
    Public idUsuario As Int16 = 0
    Public idEmpresa As Integer = 0

    Public usuario As String
    Public proyecto As String
    Public empresa As String
    Public idProyecto As Integer
    Public servidor As String
    Public bd As String
    Public cnn As String
    Public contraseña As String
    Public superSearchId As Int16
    Public superSearchNombre As String
    Public superSearchCodigo As String
    Public superSearchPrecio As Decimal
    Public superSearchCantidad As Integer
    Public superSearchFecha As DateTime
    Public superSearchSurtir As Integer
    Public superSearchCodSurtir As String
    Public superSearchFilasGrid As Integer
    Public superSearchInventario As Integer
    Public superSearchEstado As Integer

    Public superUsuario As Boolean = False
    Public filtro As String
    Public bitConecionSQL As Boolean = True
    Public bitConecionAccess As Boolean = False

    Public urlLicencia As String

    Public formatoNumero As String = "####0.00"
    Public formatoCantidad As String = "#####0"

    Public formatoPorcentaje As String = formatoNumero + " %"
    Public formatoFecha As String = "dd/MM/yyyy"
    Public MonedaSimbolo As String = "Q"
    Public SimboloSuma As String = "Σ"
    Public SimboloRecuento As String = "#"
    Public formatoMoneda = MonedaSimbolo.ToString + " ###,##0.00"

    Public formatoNumeroGridTelerik = "{0: ###,###.#0}"
    Public formatoMonedaGridTelerik = "{0:" + MonedaSimbolo.ToString + "  ###,###.#0}"
    Public formatoFechaGridTeleric = "{0:dd/MM/yyyy}"
    Public formatoPorcentajeGridTelerik As String = "{0:#.#0%}"

    'Punto de venta
    Public idCliente As Integer

    'modelo de entity framework
    Public ctx As pv2013Entities
    Public entityBuilder As New EntityConnectionStringBuilder
    Dim nombreModelo As String = "mdlModeloDatos"

    'Variables de configuracion
    Dim tbl As New clsDevuelveTabla

    'Variables de configuracion
    Public bitLicencia As Boolean = False

    'Tabla de articulos
    Public tblArticulos As New DataTable

    Public MovVenta As String
    Public Ult5Costos As String
    Public MustraCod As String
    Public EditPrecioV As String
    Public PorcentajeDescV As String

    Public IdConceptoCP As String
    Public NoProductoF As String
    Public Mov As String
    Public CargoVisa As String
    Public GeneraRegBodega As String
    Public InventarioMin0 As String

    Public Salida_TipoMovimientoVenta As Integer = 0
    Public Salida_MensajeCreditoExecido As String = ""
    Public Salida_BitacoraAlCotizar As Boolean = False
    Public Salida_BitaraAlReservar As Boolean = False
    Public Salida_BitaAlDespachar As Boolean = False
    Public Salida_CreaRegistroBodega As Boolean = False

    Public Factura_CodigoMovimiento As Integer = 0
    Public Factura_UsaRegistroBodega As Boolean = False

    Public Bodega_CodigoPuestoBodegero As Integer = 0

    Public Entrada_CodigoMovimiento As Integer = 0

    Public Salida_ReservaDias As Integer = 0

    Public Cliente_InventarioDevolucion As Integer = 0
    Public Cliente_DevolucionCodigoMovimiento As Integer = 0

    Public General_idAlmacenPrincipal As Integer = 0
    Public General_idTipoInventario As Integer = 0
    Public General_InventarioLiquidacion As Integer = 0

    Public Inventario_CarpetaImagenes As String = ""

    Public buscarArticulo_cantidadUltimasVentas As Integer = 0
    Public BuscarArticulo_CarpetaCatalogo As String = ""
    Public BuscarArticulo_CodigoOferta As Integer = 0
    Public Observacion As String

    Public Empresa_MesesUltimosProductos As Integer = 0
    Public Empresa_ValidaVenta As Boolean = False
    Public Empresa_MargenMonetario As Decimal = 0
    Public Empresa_RevisadoDescontarSaldo As Boolean = 0
    Public Empresa_OfertaMinimoDias As Integer = 0


    Public Proveedor_DevolucionCodigoMovimiento As Integer = 0
    Public Proveedor_AjusteCodigoMovimiento As Integer = 0

    Public Ajuste_CodigoMovimiento As Integer = 0

    Public General_IVA As Decimal = 0
    Public General_CodigoSalida As New DataTable
    Public General_NombreInventarioGeneral As String = ""
    Public General_TiempoNoComprado As Integer = 0

    Dim alerta As New bl_Alertas

    'Funcion para Cargar todas las variables de configuración que estan establecidas en la base de datos.
    Public Sub CargarVariablesdeConfiguracion()

        Dim Datos = (From x In ctx.tblConfiguracions Select x.id, x.valor).ToList
        'Variable para guardar cada linea de la consulta
        Dim config
        For Each config In Datos
            If config.id = 18 Then If config.valor.ToString = "1" Then Salida_CreaRegistroBodega = True Else Salida_CreaRegistroBodega = False
            If config.id = 20 Then If config.valor.ToString = "1" Then Salida_BitacoraAlCotizar = True Else Salida_BitacoraAlCotizar = False
            If config.id = 21 Then If config.valor.ToString = "1" Then Salida_BitaraAlReservar = True Else Salida_BitaraAlReservar = False
            If config.id = 22 Then If config.valor.ToString = "1" Then Salida_BitaAlDespachar = True Else Salida_BitaAlDespachar = False
            If config.id = 17 Then Salida_TipoMovimientoVenta = config.valor
            If config.id = 14 Then Salida_MensajeCreditoExecido = config.valor
            If config.id = 15 Then Bodega_CodigoPuestoBodegero = config.valor
            If config.id = 25 Then Factura_CodigoMovimiento = config.valor
            If config.id = 32 Then If config.valor.ToString = "1" Then Factura_UsaRegistroBodega = True Else Factura_UsaRegistroBodega = False
            If config.id = 33 Then Entrada_CodigoMovimiento = config.valor
            If config.id = 34 Then Inventario_CarpetaImagenes = config.valor
            If config.id = 35 Then buscarArticulo_cantidadUltimasVentas = config.valor
            If config.id = 36 Then BuscarArticulo_CarpetaCatalogo = config.valor
            If config.id = 37 Then Cliente_DevolucionCodigoMovimiento = config.valor
            If config.id = 38 Then Proveedor_DevolucionCodigoMovimiento = config.valor
            If config.id = 39 Then Proveedor_AjusteCodigoMovimiento = config.valor
            If config.id = 40 Then General_IVA = config.valor
            If config.id = 41 Then BuscarArticulo_CodigoOferta = config.valor
            If config.id = 42 Then General_TiempoNoComprado = config.valor
        Next

        Dim codigoVendedor As Integer = (From x In ctx.tblUsuarios Where x.idUsuario = idUsuario Select x.idVendedor).First
        idVendedor = codigoVendedor

        Dim emp As tblEmpresa = (From x In ctx.tblEmpresas Where x.idEmpresa = idEmpresa).FirstOrDefault
        Salida_ReservaDias = emp.diasReserva
        General_idTipoInventario = emp.idTipoInventario
        General_idAlmacenPrincipal = emp.idAlmacen
        Cliente_InventarioDevolucion = emp.inventarioDevolucionCliente
        Empresa_MesesUltimosProductos = emp.productoNuevoMeses
        General_InventarioLiquidacion = emp.inventarioLiquidacion
        Empresa_ValidaVenta = emp.validaVentaMax
        Empresa_MargenMonetario = emp.margenMonetario
        Empresa_RevisadoDescontarSaldo = emp.ajusteTraslado_RevisadoDescontarSaldo
        Empresa_OfertaMinimoDias = emp.ofertaMinimoDias


        General_CodigoSalida.Columns.Add("Codigo")
        General_CodigoSalida.Columns.Add("Fecha")
        General_CodigoSalida.Columns.Add("Documento")
        General_CodigoSalida.Columns.Add("Vendedor")
        General_CodigoSalida.Columns.Add("Total")

        'Obtenemos el nombre del inventario principal
        Dim inv As tblTipoInventario = (From x In ctx.tblTipoInventarios.AsEnumerable
                                        Where x.idTipoinventario = emp.idTipoInventario Select x).FirstOrDefault

        General_NombreInventarioGeneral = inv.nombre

    End Sub

    '---------------------------------------COPIAR PEGAS EN EL GRID VIEW. TELERIK
    Public Sub gridcopyPaste(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim grd As RadGridView = DirectCast(sender, RadGridView)

        If e.KeyCode = Keys.C AndAlso e.Shift Then
            mdlPublicVars.ConvertSelectedDataToString(grd, True)
            Dim al As New bl_Alertas
            al.contenido = "Seleccion Copiada..."
            al.fnErrorContenido()
        End If

    End Sub

    'funcion que copia el contenido del grid todo/seleccion.
    Public Function ConvertSelectedDataToString(ByVal grid As RadGridView, ByVal seleccion As Boolean) As String
        Dim strBuild As New StringBuilder()

        'solo selecion
        If seleccion = True Then
            For row As Integer = 0 To grid.SelectedRows.Count - 1
                For cell As Integer = 0 To grid.SelectedRows(row).Cells.Count - 1
                    If grid.SelectedRows(row).Cells(cell).Value Is Nothing Then
                        strBuild.Append("")
                    Else
                        strBuild.Append(grid.SelectedRows(row).Cells(cell).Value.ToString())
                    End If
                    strBuild.Append(vbTab)
                Next

                strBuild.Append(vbLf)
            Next
        Else

            'todo el contenido.
            For row As Integer = 0 To grid.Rows.Count - 1
                For cell As Integer = 0 To grid.Rows(row).Cells.Count - 1
                    If grid.Rows(row).Cells(cell).Value = Nothing Then
                        strBuild.Append("")
                    Else
                        strBuild.Append(grid.Rows(row).Cells(cell).Value.ToString())
                    End If
                    strBuild.Append(vbTab)
                Next

                strBuild.Append(vbLf)
            Next

        End If

        'copiar al clipboard o memoria.        
        Clipboard.SetDataObject(strBuild.ToString)

        Return strBuild.ToString()
    End Function

    Public Function conexionEntity()

        ' Specify the provider name, server and database.
        Dim providerName As String = "System.Data.SqlClient"
        Dim serverName As String = mdlPublicVars.servidor
        Dim databaseName As String = mdlPublicVars.bd

        ' Initialize the connection string builder for the
        ' underlying provider.
        Dim sqlBuilder As New SqlConnectionStringBuilder

        Try

            ' Set the properties for the data source.
            sqlBuilder.DataSource = serverName
            sqlBuilder.InitialCatalog = databaseName
            sqlBuilder.IntegratedSecurity = True
            sqlBuilder.UserID = "sa"
            sqlBuilder.Password = "GpiSistemas"
            sqlBuilder.IntegratedSecurity = False
            sqlBuilder.MultipleActiveResultSets = True



            ' Build the SqlConnection connection string.
            Dim providerString As String = sqlBuilder.ToString

            ' Initialize the EntityConnectionStringBuilder.
            Dim entityBuilderx As New EntityConnectionStringBuilder

            'Set the provider name.
            entityBuilderx.Provider = providerName
            ' Set the provider-specific connection string.
            entityBuilderx.ProviderConnectionString = providerString
            ' Set the Metadata location to the current directory.
            entityBuilderx.Metadata = "res://*/" + nombreModelo.ToString + ".csdl|" & _
                                        "res://*/" + nombreModelo.ToString + ".ssdl|" & _
                                        "res://*/" + nombreModelo.ToString + ".msl"



            entityBuilder = entityBuilderx


            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()

                ctx = New pv2013Entities(mdlPublicVars.entityBuilder.ConnectionString)
                'RadMessageBox.Show("No pudo abrir la conexion")
                conn.Close()
            End Using

        Catch ex As EntityException
            MsgBox("Error Conexion Incorrecta, el sistema debe cerrarse !!! ", vbExclamation, "!!!")
            Application.Exit()
        End Try

        Return 0
    End Function

    Public Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label, ByVal txtFoco As TextBox)
        Try
            Dim indice As Integer = grd.CurrentRow.Index
            txtFoco.Focus()
            txtFoco.Select()
            Dim index
            Dim contador As Integer = 0
            Dim estado As Boolean
            For index = 0 To grd.Rows.Count - 1
                estado = grd.Rows(index).Cells(0).Value
                If estado = True Then
                    contador = contador + 1
                End If
            Next
            lbl.Text = contador.ToString
            grd.Rows(indice).Cells(0).IsSelected = True
            'End If       
        Catch ex As Exception
        End Try
    End Sub

    'esta funcion recibe un grid y la columna que retona como codigo cuando se ha seleccionado una fila.    
    Public Function fnGrid_codigoFilaSeleccionada(ByVal grd As Telerik.WinControls.UI.RadGridView) As String
        Dim ValorRetorno As String = ""
        Dim index
        If grd.Rows.Count = 0 Then
            Return ValorRetorno
        End If
        For index = 0 To grd.Rows.Count - 1
            If grd.Rows(index).IsSelected = True Then
                ValorRetorno = index
                Exit For
            End If
        Next
        Return ValorRetorno
    End Function

    Public Function fnFechaServidor()

        Dim fecha As String = ""
        mdlPublicVars.conexion()
        'Using contex As New mdlPaciente(mdlPublicVars.entityBuilder.ConnectionString)
        Dim sp = ctx.sp_herramientas
        For Each x As sp_herramientas_Result In sp
            fecha = x.Fecha
        Next
        'End Using

        Return fecha
    End Function

    Public Function fnFecha_horaServidor()
        Dim fecha As String = ""
        mdlPublicVars.conexion()
        'Using contex As New mdlPaciente(mdlPublicVars.entityBuilder.ConnectionString)
        Dim sp = ctx.sp_herramientas
        For Each x As sp_herramientas_Result In sp
            fecha = x.fecha_Hora
        Next
        'End Using

        fecha = tbl.fnQuitarPuntodeFecha(fecha)
        Return fecha
    End Function

    Public Function fnHoraServidor()
        Dim hora As String = ""
        mdlPublicVars.conexion()
        Dim sp = ctx.sp_herramientas
        For Each x As sp_herramientas_Result In sp
            hora = x.hora
        Next

        Return hora
    End Function


    Public Sub fnFormatoGridMovimientos(ByVal grd As Telerik.WinControls.UI.RadGridView)

        'grd.ThemeName = "BreezeExtendedTheme1"
        'ajustar columnas. auto size.
        grd.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        grd.EnableGrouping = False

        'Opciones de filtro.
        grd.EnableFiltering = True
        grd.MasterTemplate.ShowFilteringRow = True


        'Multi Selecteccion
        grd.MultiSelect = True

    End Sub

    Public Function fnGrid_iconos(ByVal grd As Telerik.WinControls.UI.RadGridView)
        Dim index
        Dim col As String
        Dim iniciales As String

        For index = 0 To grd.Columns.Count - 1
            col = grd.Columns(index).name
            If col.Length > 3 Then
                iniciales = tbl.tipoControl(col)

                If iniciales = "txm" Or iniciales = "txb" Then
                    grd.Columns(index).HeaderText = col.Substring(3, col.Length - 3)
                End If

                If iniciales = "chm" Or iniciales = "txm" Then
                    grd.Columns(index).HeaderImage = laFuente.My.Resources.Resources.edit20x20
                    grd.Columns(index).TextImageRelation = TextImageRelation.TextBeforeImage
                End If

                If iniciales = "chb" Or iniciales = "txb" Then
                    grd.Columns(index).HeaderImage = laFuente.My.Resources.Resources.search20x20
                    grd.Columns(index).TextImageRelation = TextImageRelation.TextBeforeImage
                End If
            End If
        Next

        Return False
    End Function

    Public Sub fnFormatoGridEspeciales(ByVal grd As Telerik.WinControls.UI.RadGridView)
        'ajustar columnas. auto size.
        grd.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill
        'grd.ThemeName = "BreezeExtendedTheme1"
        grd.AllowDeleteRow = True
        grd.EnableGrouping = False
        'Opciones de filtro.
        grd.EnableFiltering = False
        grd.MasterTemplate.ShowFilteringRow = False

        Dim index
        For index = 0 To grd.Columns.Count - 1
            If grd.Columns(index).Name.ToString.ToLower = "codigo" Then
                grd.Columns(index).Width = 100
            End If
        Next
    End Sub

    Public Sub comboActivarFiltro(ByVal cmb As ComboBox)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub comboActivarFiltroTelerik(ByVal cmb As RadDropDownList)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteDataSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub comboActivarFiltroLista(ByVal cmb As ComboBox)
        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmb.AutoCompleteSource = AutoCompleteSource.ListItems
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub fnInicio()

        'crear columnas para la tabla de articulos.
        tblArticulos.Columns.Add("id")
        tblArticulos.Columns.Add("codigo")
        tblArticulos.Columns.Add("articulo")
        tblArticulos.Columns.Add("cantidad")
        tblArticulos.Columns.Add("precio")


    End Sub

    Public Function EntitiToDataTable(ByVal parIList As System.Collections.IEnumerable) As System.Data.DataTable
        Dim ret As New System.Data.DataTable()
        Try
            Dim ppi As System.Reflection.PropertyInfo() = Nothing
            If parIList Is Nothing Then Return ret
            Dim itm
            For Each itm In parIList
                If ppi Is Nothing Then
                    ppi = DirectCast(itm.[GetType](), System.Type).GetProperties()
                    For Each pi As System.Reflection.PropertyInfo In ppi
                        Dim colType As System.Type = pi.PropertyType
                        If (colType.IsGenericType) AndAlso
                           (colType.GetGenericTypeDefinition() Is GetType(System.Nullable(Of ))) Then colType = colType.GetGenericArguments()(0)
                        ret.Columns.Add(New System.Data.DataColumn(pi.Name, colType))
                    Next
                End If
                Dim dr As System.Data.DataRow = ret.NewRow
                For Each pi As System.Reflection.PropertyInfo In ppi
                    dr(pi.Name) = If(pi.GetValue(itm, Nothing) Is Nothing, DBNull.Value, pi.GetValue(itm, Nothing))
                Next
                ret.Rows.Add(dr)
            Next
            For Each c As System.Data.DataColumn In ret.Columns
                c.ColumnName = c.ColumnName.Replace("_", " ")
            Next
        Catch ex As Exception
            ret = New System.Data.DataTable()
        End Try
        Return ret
    End Function

    Public Sub fnLlenar_Articulos_Telerik(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal colChk As Integer)
        Dim index
        Dim fila() As String
        For index = 0 To grd.Rows.Count - 1
            If CType(grd.Rows(index).Cells(colChk).Value, Boolean) = True Then

                'agregar fila a la tabla
                '1= id,2= codigo, 3=nombre, 5= precio, 6= cantidad
                fila = {grd.Rows(index).Cells(1).Value, grd.Rows(index).Cells(2).Value, grd.Rows(index).Cells(3).Value, grd.Rows(index).Cells(5).Value, grd.Rows(index).Cells(6).Value}
                tblArticulos.Rows.Add(fila)

                'colocar el valor en falso
                grd.Rows(index).Cells(colChk).Value = False
            End If
        Next



    End Sub

    'Public Function configuracion(ByVal nombre As String) As String
    '    Dim tbl As New clsDevuelveTabla
    '    Dim valor As String
    '    tbl.sqlString = "select valor from tblConfiguracion where nombre = '" & nombre & "'"
    '    valor = tbl.Tabla.Rows(0).Item(0).ToString

    '    Return valor
    'End Function



    'utilizada en proyectos antiguos

    Public Sub conexion()
        If bitConecionSQL = True Then
            cnn = "server=" & servidor & ";database=" & bd & ";uid=" & usuario & ";password=" & contraseña & ";connection timeout = 60000"
        ElseIf bitConecionAccess = True Then
            cnn = servidor.ToString + ";Data Source=" + bd.ToString
        End If

    End Sub

    Public Function fechaSQL(ByVal fecha As Date) As String
        Dim dia, mes As String
        If fecha.Day < 10 Then
            dia = "0" & fecha.Day
        Else
            dia = fecha.Day
        End If

        If fecha.Month < 10 Then
            mes = "0" & fecha.Month
        Else
            mes = fecha.Month
        End If

        Return "'" & fecha.Year & mes & dia & "'"
    End Function

    Public Sub limpiaCampos(ByRef frm As Form)

        Dim index
        Dim chkstate As CheckState = CheckState.Unchecked

        Dim ctl As New Control
        Dim nombre As String
        Dim txt As TextBox
        Dim cmb As ComboBox
        Dim chk As CheckBox
        Dim pnl As Panel
        Dim msk As MaskedTextBox
        Dim nm0 As NumericUpDown
        Dim lst As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView


        For Each ctl In frm.Controls
            nombre = ctl.Name
            If nombre <> "" Then


                If tipoControl(nombre) = "txt" Then
                    txt = ctl
                    txt.Text = ""
                ElseIf tipoControl(nombre) = "cmb" Then
                    cmb = ctl
                    cmb.Text = ""
                ElseIf tipoControl(nombre) = "chk" Then
                    chk = ctl
                    chk.Checked = False
                ElseIf tipoControl(nombre) = "pnl" Then
                    pnl = ctl
                    Call limpiaCamposPanel(pnl)
                ElseIf tipoControl(nombre) = "msk" Then
                    msk = ctl
                    msk.Text = ""
                ElseIf tipoControl(nombre) = "rpv" Then
                    limpiaCamposPaginas(ctl)
                ElseIf tipoControl(nombre) = "nm0" Or tipoControl(nombre) = "nm1" Or tipoControl(nombre) = "nm2" Or tipoControl(nombre) = "nm3" Or tipoControl(nombre) = "nm4" Or tipoControl(nombre) = "nm5" Then
                    nm0 = ctl
                    nm0.Value = 0
                ElseIf tipoControl(nombre) = "lst" Then
                    lst = ctl
                    For index = 0 To lst.Items.Count - 1
                        lst.SetItemCheckState(index, chkstate)
                    Next
                ElseIf tipoControl(nombre) = "grd" Then
                    grd = ctl
                    grd.Rows.Clear()
                End If

            End If

        Next
    End Sub

    Public Sub limpiaCamposPanel(ByRef pnl As Panel)
        Dim index
        Dim chkstate As CheckState = CheckState.Unchecked
        Dim lst As CheckedListBox

        Dim ctl As New Control
        Dim nombre As String
        Dim txt As TextBox
        Dim cmb As ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim nm0 As NumericUpDown
        Dim grd As Telerik.WinControls.UI.RadGridView

        For Each ctl In pnl.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                If tipoControl(nombre) = "txt" Then
                    txt = ctl
                    txt.Text = ""
                ElseIf tipoControl(nombre) = "cmb" Then
                    cmb = ctl
                    cmb.Text = ""
                ElseIf tipoControl(nombre) = "chk" Then
                    chk = ctl
                    chk.Checked = False
                ElseIf tipoControl(nombre) = "msk" Then
                    msk = ctl
                    msk.Text = ""
                ElseIf tipoControl(nombre) = "rpv" Then
                    limpiaCamposPaginas(ctl)
                ElseIf tipoControl(nombre) = "nm0" Or tipoControl(nombre) = "nm1" Or tipoControl(nombre) = "nm2" Or tipoControl(nombre) = "nm3" Or tipoControl(nombre) = "nm4" Or tipoControl(nombre) = "nm5" Then
                    nm0 = ctl
                    nm0.Value = 0
                ElseIf tipoControl(nombre) = "lst" Then
                    lst = ctl
                    For index = 0 To lst.Items.Count - 1
                        lst.SetItemCheckState(index, chkstate)
                    Next
                ElseIf tipoControl(nombre) = "grd" Then
                    grd = ctl
                    grd.Rows.Clear()
                End If
            End If

        Next
    End Sub

    Public Sub limpiaCamposPaginas(ByRef paginas As Telerik.WinControls.UI.RadPageView)
        Dim index
        Dim chkstate As CheckState = CheckState.Unchecked
        Dim lst As CheckedListBox

        Dim ctl As New Control
        Dim nombre As String
        Dim txt As TextBox
        Dim cmb As ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim nm0 As NumericUpDown
        Dim grd As Telerik.WinControls.UI.RadGridView

        Dim pagina
        For Each pagina In paginas.Pages
            For Each ctl In pagina.Controls

                nombre = ctl.Name
                If nombre <> "" Then
                    If tipoControl(nombre) = "txt" Then
                        txt = ctl
                        txt.Text = ""
                    ElseIf tipoControl(nombre) = "cmb" Then
                        cmb = ctl
                        cmb.Text = ""
                    ElseIf tipoControl(nombre) = "chk" Then
                        chk = ctl
                        chk.Checked = False
                    ElseIf tipoControl(nombre) = "msk" Then
                        msk = ctl
                        msk.Text = ""
                    ElseIf tipoControl(nombre) = "rpv" Then
                        limpiaCamposPaginas(ctl)
                    ElseIf tipoControl(nombre) = "nm0" Or tipoControl(nombre) = "nm1" Or tipoControl(nombre) = "nm2" Or tipoControl(nombre) = "nm3" Or tipoControl(nombre) = "nm4" Or tipoControl(nombre) = "nm5" Then
                        nm0 = ctl
                        nm0.Value = 0
                    ElseIf tipoControl(nombre) = "lst" Then
                        lst = ctl
                        For index = 0 To lst.Items.Count - 1
                            lst.SetItemCheckState(index, chkstate)
                        Next
                    ElseIf tipoControl(nombre) = "grd" Then
                        grd = ctl
                        grd.Rows.Clear()
                    End If
                End If

            Next
        Next

    End Sub

    Public Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function

    Public Function nombrecampo(ByVal nombre As String) As String
        Dim campo As String
        campo = nombre.Substring(3, nombre.Length - 3)
        Return campo
    End Function

    Public Function RevisaCampo(ByVal tabla As String, ByVal id As String, ByVal nombre As String, ByVal idValor As Int16, Optional ByVal filtro As String = "") As Boolean
        RevisaCampo = False
        Dim tbl As New clsDevuelveTabla
        Try
            If filtro = "" Then
                tbl.sqlString = "select " & id & "," & nombre & " from " & tabla & " where " & id & " = " & idValor
            Else
                tbl.sqlString = "select " & id & "," & nombre & " from " & tabla & " where " & id & " = " & idValor & " and " & filtro
            End If
            If tbl.Tabla.Rows.Count = 0 Then
                Return False
            Else
                superSearchNombre = tbl.Tabla.Rows(0).Item(1).ToString
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
            Return False
        End Try
    End Function

    Public Function Nz(ByVal valor As String) As Decimal
        Nz = 0
        If IsDBNull(valor) Or valor = "" Then
            Nz = 0
        Else
            Nz = CDec(valor)
        End If
    End Function

    'Hace disponible los valores de configuracion para toda la aplicacion
    Public Function configuracion() As Decimal

        Return 0

    End Function

    'articulo = 1

    'asigna colores a (griddatos,Red,1,0)

    Public Sub GridColor(ByRef grid As RadGridView, ByVal color As Color, ByVal tipo As String, ByVal columna As String)
        'tipo: es el valor que debe ser igual para que asigne el formato.
        Dim objeto As New ConditionalFormattingObject("MyCondition", ConditionTypes.Equal, tipo, "", False)
        objeto.CellForeColor = color
        grid.Columns(columna).ConditionalFormattingObjectList.Add(objeto)

    End Sub

    Public Sub GridColor_fila(ByVal fila As Integer, ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        If e.CellElement.RowIndex = fila Then
            e.CellElement.DrawFill = True
            e.CellElement.NumberOfColors = 1
            e.CellElement.BackColor = color
        End If
    End Sub

    Public Sub GridColor_celda(ByVal fila As Integer, ByVal col As Integer, ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        If e.CellElement.RowIndex = fila And e.CellElement.ColumnIndex = col Then
            'e.CellElement.DrawFill = True
            e.CellElement.NumberOfColors = 1
            e.CellElement.BackColor = color
        End If
    End Sub

    Public Sub GridColor_fila(ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color)
        'e.CellElement.DrawFill = True
        e.CellElement.NumberOfColors = 1
        e.CellElement.ForeColor = color
    End Sub

    Public Sub GridColor_fila(ByRef e As Telerik.WinControls.UI.CellFormattingEventArgs, ByVal color As Color, ByVal inicio As Integer)
        If e.ColumnIndex >= inicio And e.RowIndex >= 0 Then
            e.CellElement.DrawFill = False
            e.CellElement.NumberOfColors = 1
            e.CellElement.ForeColor = color
        End If
    End Sub

    Public Function fnGridTelerik_formatoMoneda(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        Try
            grd.Columns(nombre).FormatString = formatoMonedaGridTelerik
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

        Return 0
    End Function

    Public Function fnGridTelerik_formatoPorcentaje(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        grd.Columns(nombre).FormatString = formatoPorcentajeGridTelerik
        Return 0
    End Function


    Public Function fnGridTelerik_formatoFecha(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal nombre As String)
        Try
            grd.Columns(nombre).FormatString = formatoFechaGridTeleric
        Catch ex As Exception
            alerta.contenido = ex.ToString
            alerta.fnErrorContenido()
        End Try

        Return 0
    End Function

    Public Function fnFormulario_quitaBarraTitulo(ByVal frm As Telerik.WinControls.UI.RadForm)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.ControlBox = False
        Return False
    End Function

    Public Function fnFormulario_colocarBarraTitulo(ByVal frm As Telerik.WinControls.UI.RadForm)
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frm.MaximizeBox = True
        frm.MinimizeBox = True
        frm.ControlBox = True
        Return False
    End Function

    Public Function tipoControlRango(ByVal nombre As String, ByVal inicio As Integer, ByVal fin As Integer) As String
        Dim acronimo As String
        acronimo = nombre.Substring(inicio, fin)
        Return acronimo
    End Function

    Public Sub fnSeleccionarDefault(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal codigoDef As Integer, ByVal seleccion As Boolean)
        If seleccion = True Then
            Dim index
            For index = 0 To grd.Rows.Count - 1
                If grd.Rows(index).Cells(0).Value = codigoDef Then
                    grd.MasterView.Rows(index).IsSelected = True
                    grd.MasterView.Rows(index).IsCurrent = True
                    grd.MasterView.Rows(index).EnsureVisible()
                    index = grd.Rows.Count
                End If
            Next
        End If
    End Sub

    'Funcion utilizada para verificar si el menu principal tiene hijos, de lo contrario mostramos el menu
    Public Sub fnMenu_Hijos(ByRef form As Form)
        Try
            form.Visible = False
            form.MdiParent = Nothing
            Dim contador As Integer = 0

            For Each hijo As Form In frmMenuPrincipal.MdiChildren
                If hijo.Visible = True Then
                    contador += 1
                End If
            Next
            If contador = 0 Then
                Dim frm As Form = frmMenu
                frm.Text = "MENU PRINCIPAL"
                frm.MdiParent = frmMenuPrincipal
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            End If
        Catch ex As Exception
        End Try

    End Sub

    'Funcion para establecer los indicadores
    Public Sub fnIndicadores(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal col As Integer)
        Try
            'Recorremos el grid para establecer los indicadores
            Dim i As Integer = 0
            For i = 0 To grd.RowCount - 1
                'Obtenemos las variables
                Dim tipo As String = grd.Rows(i).Cells("Pagos").Value
                Dim codSalida As Integer = grd.Rows(i).Cells("Codigo").Value
                Dim total As Decimal = grd.Rows(i).Cells("Total").Value
                Dim codClie As Integer = grd.Rows(i).Cells("Clave").Value
                Dim estado As Integer = 0
                Dim descripcion As String = ""

                ''Obtenemos el numero de factura de la salida
                'Dim nFac As Long = 0
                'Try
                '    nFac = (From x In ctx.tblSalidas Where x.idSalida = codSalida Select x.IdFactura).FirstOrDefault
                'Catch ex As Exception
                '    nFac = 0
                'End Try

                'If nFac <> 0 Then
                'Analizamos si el pedido ya tiene guias
                Dim sl As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codSalida).FirstOrDefault

                If sl.despachar = False Then
                    estado = 0
                    descripcion = ""
                Else
                    Dim guias = (From x In ctx.tblEnvios Join y In ctx.tblFacturas On x.factura Equals y.IdFactura
                                 Join z In ctx.tblSalidas On y.IdFactura Equals z.IdFactura Where z.idSalida = codSalida Select x).Count

                    If guias > 0 Then
                        'Si el documento ya tiene guias pues establecemos el estado como enviado, y lo ponemos color azul
                        estado = 2
                        descripcion = "Enviado"
                    Else
                        'Obtenemos la informacion del cliente
                        Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codClie Select x).FirstOrDefault

                        'Obtenemos el estado
                        Dim dEstado As String = grd.Rows(i).Cells("Estado").Value

                        If dEstado = "Anulado" Then
                            estado = 0
                            descripcion = ""
                        ElseIf tipo = "Contado" Then
                            'Si no tiene guias y fue al contado

                            'Obtenemos el saldo a favor del cliente que es igual al valor absoluto del saldo negativo - el saldo de la empresa
                            Dim saldoFavor As Decimal = cliente.saldo - mdlPublicVars.Empresa_MargenMonetario

                            'Obtenemos el saldo en transito del cliente
                            Dim saldoTransito As Decimal = cliente.pagosTransito + mdlPublicVars.Empresa_MargenMonetario

                            'Al saldo a favor le sumamos la venta 
                            Dim residuo As Decimal = saldoFavor + total

                            ' si da diferencia negativa es porque el cliente tiene saldo para pagar
                            If residuo <= 0 Then
                                estado = 4
                                descripcion = "Liberado"
                            Else
                                'Verificamos si el cliente tiene en saldo en transito para pagar la venta
                                Dim residuo2 = saldoTransito - total

                                If residuo2 > 0 Then
                                    'Si el cliente tiene saldo en transito para pagar
                                    estado = 5
                                    descripcion = "Pend.Confirmar"
                                Else
                                    'De lo contrario, el cliente no tiene ni saldo a favor, ni saldo en transito
                                    estado = 1
                                    descripcion = "No depositado"
                                End If
                            End If
                        ElseIf tipo = "Credito" Then
                            'Obtemos el saldo del cliente, el limite de credito, ademas le añadimos su sobregiro y por consecuente su saldo disponible
                            Dim saldoDisponible = (cliente.limiteCredito + (cliente.limiteCredito * (If(cliente.porcentajeCredito = 0, 0, cliente.porcentajeCredito / 100)))) - cliente.saldo

                            'Sacamos la diferencia entre el saldo disponible y el total de la venta
                            Dim residuo = saldoDisponible - total

                            'Si da un residuo positivo es porque el cliente tiene el suficiente credito para que se le venda
                            If residuo > 0 Then
                                estado = 4
                                descripcion = "Liberado"
                            Else
                                estado = 1
                                descripcion = "Sobregiro"
                            End If
                        End If
                    End If
                    'Else
                    'End If

                End If

                'Establecemos el estado y la descripcion
                grd.Rows(i).Cells(col).Value = estado
                grd.Rows(i).Cells("Descripcion").Value = descripcion
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Funcion que se utilizara para cuando solo se factura una salida
    Public Sub GuardarFacturacion(ByVal codSalida As Integer)
        'variables para errores.
        Dim success As Boolean = True
        Dim errContenido As String = ""
        Dim fecha As DateTime = fnFecha_horaServidor()

        Dim conteo As Integer = 0
        Dim totalFactura As Decimal = 0
        Dim saldo As Double = 0
        Dim credito As Boolean = False
        'Obtenemos el total
        Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codSalida Select x).FirstOrDefault
        totalFactura = salida.total
        credito = salida.credito

        Using transaction As New TransactionScope
            Try
                'Variables para Guardar el numero de correlativo consultado...
                Dim NoCorrelativo As Int64 = 0
                Dim codigoFactura As Int64 = 0

                'Buscamos el correlativo en la tabla correlativo...
                Dim DataCorrelativo As tblCorrelativo = (From x In ctx.tblCorrelativos _
                                      Where x.idTipoMovimiento = mdlPublicVars.Factura_CodigoMovimiento And x.idEmpresa = mdlPublicVars.idEmpresa _
                                      Select x).FirstOrDefault

                If DataCorrelativo Is Nothing Then
                    Dim nuevoCorrelativo As New tblCorrelativo
                    nuevoCorrelativo.idEmpresa = mdlPublicVars.idEmpresa
                    nuevoCorrelativo.idTipoMovimiento = mdlPublicVars.Factura_CodigoMovimiento
                    nuevoCorrelativo.correlativo = 1
                    ctx.AddTotblCorrelativos(nuevoCorrelativo)
                    ctx.SaveChanges()
                    NoCorrelativo = nuevoCorrelativo.correlativo
                    nuevoCorrelativo.correlativo = NoCorrelativo + 1
                    ctx.SaveChanges()
                Else
                    NoCorrelativo = DataCorrelativo.correlativo
                    DataCorrelativo.correlativo = (NoCorrelativo + 1)
                    ctx.SaveChanges()
                End If

                'CREAMOS LA VARIABLE QUE PERMITA CONECTAR A LA TABLA FACTURA..
                Dim NewFactura As New tblFactura
                NewFactura.Idusuario = mdlPublicVars.idUsuario
                NewFactura.Monto = totalFactura
                NewFactura.Fecha = fecha
                NewFactura.FechaTransaccion = fecha
                NewFactura.anulado = 0
                'Guardamos el nuevo numero de Factura....
                NewFactura.DocumentoFactura = (NoCorrelativo)

                'Si la factura fue al contado
                If credito = False Then
                    NewFactura.contado = True
                    NewFactura.saldo = totalFactura
                    NewFactura.pagos = 0
                    NewFactura.pagosTransito = 0
                    NewFactura.pagado = 0
                    NewFactura.credito = False
                Else
                    NewFactura.credito = True
                    NewFactura.contado = False
                End If

                ctx.AddTotblFacturas(NewFactura)
                ctx.SaveChanges()

                codigoFactura = NewFactura.IdFactura
                NoCorrelativo = NewFactura.DocumentoFactura

                Dim TablaSalida As tblSalida = (From x In ctx.tblSalidas _
                          Where x.idSalida = codSalida _
                          Select x).First

                TablaSalida.facturado = True
                TablaSalida.fechaFacturado = fecha
                TablaSalida.documentoFactura = NoCorrelativo
                TablaSalida.IdFactura = codigoFactura
                ctx.SaveChanges()

                'Si la Salida seleccionada fue emitida al credito se genera una cuenta por cobrar, si es al contado no se hace nada...
                'If rbtCredito.Checked = True Then

                'Generamos un nuevo objeto para agregar los nuevos datos para la Cuenta por cobrar..
                Dim TablaCtaCobrar As New tblCtaCobrar
                TablaCtaCobrar.fecha = Format(fecha, mdlPublicVars.formatoFecha)
                TablaCtaCobrar.idCliente = salida.idCliente
                TablaCtaCobrar.idSalida = salida.idSalida
                TablaCtaCobrar.idUsuario = mdlPublicVars.idUsuario
                TablaCtaCobrar.monto = salida.total
                TablaCtaCobrar.saldo = salida.total
                TablaCtaCobrar.pagado = 0
                TablaCtaCobrar.cancelada = False

                'Guardamos los cambios en la tabla CuentaporCobrar
                ctx.AddTotblCtaCobrars(TablaCtaCobrar)
                ctx.SaveChanges()

                'Si la facturacion fue al credito aumenta el saldo del cliente
                Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = salida.idCliente Select x).FirstOrDefault

                'Aumentamos el saldo
                cli.saldo += NewFactura.Monto
                saldo = cli.saldo
                ctx.SaveChanges()

                ''Si existe un error mandamos el mensaje e interrumpimos la aplicación
                'If success = False Then
                '    alerta.contenido = errContenido
                '    alerta.fnFaltantes()
                '    Exit Try
                'End If

                ''Para Capturar la Fecha de Facturación...
                'mdlPublicVars.superSearchFecha = Nothing
                'frmSalidaFechaVencimiento.StartPosition = FormStartPosition.CenterScreen
                'frmSalidaFechaVencimiento.Text = "Fecha de vencimiento"
                'frmSalidaFechaVencimiento.dias = cli.diasCredito
                'frmSalidaFechaVencimiento.fecha = Format(fecha, mdlPublicVars.formatoFecha)
                'frmSalidaFechaVencimiento.ShowDialog()

                'If mdlPublicVars.superSearchFecha <> Nothing Then
                'Else
                '    errContenido = "Error al seleccionar la fecha."
                '    success = False
                '    Exit Try
                'End If

                'Dim fechaVencimiento As Date = mdlPublicVars.superSearchFecha

                'completar la transaccion.
                transaction.Complete()

            Catch ex As System.Data.EntityException
                MsgBox(ex.Message)
                success = False
            Catch ex As Exception
                success = False
                MsgBox(ex.Message)
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
            If credito = False Then
                frmPagoNuevo.Text = "Pagos"
                frmPagoNuevo.bitCliente = True
                frmPagoNuevo.codigoCP = salida.idCliente
                frmPagoNuevo.lblSaldo.Text = saldo
                frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                frmPagoNuevo.ShowDialog()
            End If
        Else
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Sub

    'Funcion utilizada para eliminar un registro en un grid
    Public Sub fnGrid_EliminarFila(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs, ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal columna As String)
        Dim f As Integer = grd.CurrentRow.Index

        Dim filas As Integer = -1
        Dim index
        For index = 0 To grd.Rows.Count - 1
            Dim elimina As Integer = CType(grd.Rows(index).Cells("elimina").Value, Integer)
            If elimina = 0 Then
                filas += 1
            End If
        Next

        Dim detalle = 0
        If f >= 0 Then
            detalle = CType(grd.Rows(f).Cells(columna).Value, Integer)
        End If

        If e.KeyCode = Keys.Delete And detalle > 0 Then
            grd.Rows(f).Cells("elimina").Value = 1
            grd.Rows(f).IsVisible = False

            If f >= 0 And f < filas Then
                grd.Rows(f + 1).IsCurrent = True
            ElseIf f = filas And f <> 0 Then
                grd.Rows(f - 1).IsCurrent = True
            End If
        ElseIf e.KeyCode = Keys.Delete And detalle = 0 Then
            grd.Rows.RemoveAt(f)
            If f >= 0 And f < filas Then
                grd.Rows(f).IsCurrent = True
            ElseIf f = filas And f <> 0 Then
                grd.Rows(f - 1).IsCurrent = True
            End If
        End If
    End Sub

End Module
