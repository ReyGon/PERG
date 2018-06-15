Imports System.Linq
Imports System.Transactions
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Public Class frmProductoPrecio
    Public grdBase As RadGridView = Nothing
    Dim alerta As New bl_Alertas
    Dim permiso As New clsPermisoUsuario
    Public nuevoProducto As Boolean = False
    Public codigoProductoNuevo As String = ""
    Public nombreProductoNuevo As String = ""
    Public importanciaProductoNuevo As Integer = 0
    Public idPendientePedir As Integer = 0
    Public posicion As Integer = 0
    Public bitNuevoEntrada As Boolean = False
    Public bitNuevoPendiente As Boolean = False

    Private Sub frmProductoPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdOtrosPrecios)
        'mdlPublicVars.fnFormatoGridEspeciales(grdOtrosPreciosSucursal)
        mdlPublicVars.fnFormatoGridEspeciales(grdPrecios)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridMovimientos(grdModeloVehiculo)
        mdlPublicVars.fnFormatoGridEspeciales(grdSustitutos)
        mdlPublicVars.fnFormatoGridEspeciales(grdPreciosSustitutos)
        mdlPublicVars.fnFormatoGridEspeciales(grdUltimasCompras)
        mdlPublicVars.fnFormatoGridMovimientos(grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridMovimientos(grdModeloVehiculo)

        'mdlPublicVars.fnFormatoGridEspeciales(grdPreciosCompe)
        mdlPublicVars.fnFormatoGridEspeciales(grdUltimasVentas)
        'mdlPublicVars.fnFormatoGridEspeciales(grdPreciosMotriza)
        'mdlPublicVars.fnGrid_iconos(grdPreciosMotriza)
        mdlPublicVars.fnGrid_iconos(grdOtrosPrecios)
        'mdlPublicVars.fnGrid_iconos(grdOtrosPreciosSucursal)
        mdlPublicVars.fnGrid_iconos(grdPrecios)
        mdlPublicVars.fnFormatoGridMovimientos(grdUltimasCompras)
        mdlPublicVars.comboActivarFiltro(cmbNombre1)
        mdlPublicVars.comboActivarFiltro(cmbCodigo1)

        mdlPublicVars.comboActivarFiltro(cmbImportancia)
        mdlPublicVars.comboActivarFiltro(cmbMarcaRepuesto)
        mdlPublicVars.comboActivarFiltro(cmbTipoRepuesto)

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdFotos)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdFotos)

        lbl1Modificar.Text = "Guardar"

        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automatico
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        'Me.errores.Controls.Add(Me.txtCodigo1, "Codigo1")
        'Me.errores.SummaryMessage = "Faltan datos"

        fnLlenarCombo()
        fnLlenarCombo2()

        Me.cmbNombre1.SelectedValue = mdlPublicVars.superSearchId
        Me.cmbCodigo1.SelectedValue = mdlPublicVars.superSearchId

        llenagrid()


        fnConfiguracion()
        mdlPublicVars.fnSeleccionarDefault(grdDatos, mdlPublicVars.superSearchId, True)
        mdlPublicVars.fnSeleccionarDefault(grdDatos, codigoDefault, seleccionDefault)

        Call frm_txtcodigo()

        pctFoto.SizeMode = PictureBoxSizeMode.StretchImage
        pctFoto.BorderStyle = BorderStyle.Fixed3D

        lbl1Modificar.Text = "Guardar"
        Me.grdModeloVehiculo.Font = New System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        chkKit.Enabled = NuevoIniciar
        chkProducto.Enabled = NuevoIniciar
        chkServicio.Enabled = NuevoIniciar

        chkUnidadMedida.Enabled = NuevoIniciar
        chkProducto.Checked = True
        fnLlenar_Listas()

        Me.grdDatos.Visible = False
        lblRegistros.Visible = False

        fnPrecioC()

    End Sub

    Private Sub llenagrid()
        Try

            Dim consulta = From x In ctx.tblArticuloes Order By x.codigo1 Where x.empresa = mdlPublicVars.idEmpresa _
                           Select Codigo = x.idArticulo, Codigo1 = x.codigo1, Nombre1 = x.nombre1 + " - " + x.codigo1, _
                           Existencia = (From i In ctx.tblInventarios Where x.idArticulo = i.idArticulo Select i.saldo).FirstOrDefault, _
                           Importacia = x.tblArticuloImportancia.nombre, Minimo = x.minimo, PrecioPublico = x.precioPublico, PrecioPublicoMotriza = x.preciopublicosucursal, Importancia = x.tblArticuloImportancia.nombre, _
                           CostoLocal = x.costoIVA, CostoImportacion = 0, Costo = (x.costoIVA + 0), Observaciones = x.observacionPrecio, _
                           Codigo2 = x.codigo2, Nombre2 = x.nombre2, Obser = x.Observacion, marcarepuesto = x.tblArticuloMarcaRepuesto.nombre, tiporepuesto = x.tblArticuloRepuesto.nombre Order By Codigo


            Me.grdDatos.DataSource = consulta
            fnLlenaPrecios()
            fnCalculaNormales()
            fnUltimasCompras()
            fnUltimasVentas()
            'calcular los costos
            fnCalculaOtros()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub llenagrid2()
        Try
            Dim consulta2 = From x In ctx.tblInventarios Where _
               x.tblArticulo.empresa = mdlPublicVars.idEmpresa And x.idTipoInventario = InventarioPrincipal _
                              And x.IdAlmacen = BodegaPrincipal _
                              Select Codigo = x.tblArticulo.idArticulo, Productomod = x.tblArticulo.nombre1,
                              Codigo2 = x.tblArticulo.codigo2, _
                               Nombre2 = x.tblArticulo.nombre2,
                              Observacion = x.tblArticulo.Observacion, TipoRepuesto = x.tblArticulo.tblArticuloRepuesto.nombre, _
                                MarcaRepuesto = x.tblArticulo.tblArticuloMarcaRepuesto.nombre, Importancia = x.tblArticulo.tblArticuloImportancia.nombre,
                                chkNoEstanteria = x.tblArticulo.bitNoEstanteria, _
                                chkNoFoto = x.tblArticulo.bitNoFotos, chkProducto = x.tblArticulo.bitProducto,
                                chkServicio = x.tblArticulo.bitServicio, chkKit = x.tblArticulo.bitKit, _
                                CostoKit = x.tblArticulo.costoIVA, chkUnidadMedida = x.tblArticulo.bitUnidadMedida


            Me.grdDatos.DataSource = consulta2

            fnClasificacion()


            'Verificamos si esta activo el filtro entonces mostramos solo productos del grid filtrado
            If frmProductoLista.filtroActivo Then
                Dim lFiltro = (From x As GridViewRowInfo In grdBase.Rows Join y As GridViewRowInfo In grdDatos.Rows
                                    On x.Cells("ID").Value Equals y.Cells("Codigo").Value _
                                    Select Codigo = y.Cells("Codigo").Value, Observacion = y.Cells("Observacion").Value,
                                    Productomod = y.Cells("Nombre1").Value, TipoRepuesto = y.Cells("TipoRepuesto").Value,
                                    MarcaRepuesto = y.Cells("MarcaRepuesto").Value,
                                    Importancia = y.Cells("Importancia").Value,
                                    chkNoEstanteria = y.Cells("chkNoEstanteria").Value, chkNofoto = y.Cells("chkNoFoto").Value,
                                    chkProducto = y.Cells("chkProducto").Value, chkServicio = y.Cells("chkServicio").Value, chkKit = y.Cells("chkKit").Value,
                                    CostoKit = y.Cells("CostoKit").Value, chkUnidadMedida = y.Cells("bitUnidadMedida").Value
                                    ).ToList

                Me.grdDatos.DataSource = lFiltro
            End If

            If pctFoto.Image IsNot Nothing Then
                pctFoto.Image = Nothing
            End If
            Me.grdFotos.Rows.Clear()
            If Me.grdDatos.Rows.Count > 0 Then
                fnLlenarFotos(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Codigo").Value)
                fnFoto()
            End If


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    'Aplica configuraciones de formato a los grid, textbox, label...
    Private Sub fnConfiguracion()
        Try
            Dim costo As Decimal = lblCosto.Text
            lblCosto.Text = Format(costo, mdlPublicVars.formatoMoneda)

            'Configuramos el grid de sustitutos
            If Me.grdSustitutos.Rows.Count > 0 Then
                Me.grdSustitutos.Columns(0).IsVisible = False
                Me.grdSustitutos.Columns(1).Width = 80
                Me.grdSustitutos.Columns(2).Width = 200
                Me.grdSustitutos.Columns(3).Width = 100
                Me.grdSustitutos.Columns(4).Width = 100
                Me.grdSustitutos.Columns(5).Width = 100


                Me.grdSustitutos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdSustitutos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter

                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "Costo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioPublico")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioNormal")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioA")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioB")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdSustitutos, "PrecioOferta")


                'Definimos que columnas no se podran editar
                Me.grdSustitutos.Columns(0).ReadOnly = True
                Me.grdSustitutos.Columns(1).ReadOnly = True
                Me.grdSustitutos.Columns(2).ReadOnly = True
                Me.grdSustitutos.Columns(3).ReadOnly = True
                Me.grdSustitutos.Columns(4).ReadOnly = True
                Me.grdSustitutos.Columns(6).ReadOnly = True
                Me.grdSustitutos.Columns(10).ReadOnly = True

                Me.grdSustitutos.Columns(5).ReadOnly = False
                Me.grdSustitutos.Columns(7).ReadOnly = False
                Me.grdSustitutos.Columns(8).ReadOnly = False
                Me.grdSustitutos.Columns(9).ReadOnly = False
            End If

            If Me.grdUltimasCompras.Columns.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdUltimasCompras, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdUltimasCompras, "Costo")
                Me.grdUltimasCompras.Columns(0).Width = 100
                Me.grdUltimasCompras.Columns(1).Width = 200
                Me.grdUltimasCompras.Columns(2).Width = 100
                Me.grdUltimasCompras.Columns(3).Width = 100

                For i As Integer = 0 To Me.grdUltimasCompras.Columns.Count - 1
                    Me.grdUltimasCompras.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next
            End If

            If Me.grdUltimasVentas.Columns.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdUltimasVentas, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdUltimasVentas, "Precio")

                Me.grdUltimasVentas.Columns(0).Width = 80
                Me.grdUltimasVentas.Columns(1).Width = 160
                Me.grdUltimasVentas.Columns(2).Width = 70
                Me.grdUltimasVentas.Columns(3).Width = 60
                Me.grdUltimasVentas.Columns(4).Width = 70
                Me.grdUltimasVentas.Columns(5).Width = 70
            End If


            '   If Me.grdPreciosCompe.RowCount > 0 Then
            'mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdPreciosCompe, "Fecha")
            'mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdPreciosCompe, "Precio")

            'For i As Integer = 0 To Me.grdPreciosCompe.ColumnCount - 1
            'Me.grdPreciosCompe.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            'Next

            'Me.grdPreciosCompe.Columns(0).Width = 15
            'Me.grdPreciosCompe.Columns(1).Width = 35
            'Me.grdPreciosCompe.Columns(2).Width = 15
            'Me.grdPreciosCompe.Columns(3).Width = 35
            'End If
        Catch ex As Exception
        End Try
    End Sub

    'Ultimas Ventas
    Private Sub fnUltimasVentas()
        Dim codArt As Integer = CInt(cmbNombre1.SelectedValue)
        Dim general = (From x In ctx.tblSalidaDetalles Where x.tblSalida.anulado = False And x.tblSalida.empacado = True And x.idArticulo = codArt _
                        Select Fecha = x.tblSalida.fechaRegistro, Cliente = x.tblSalida.tblCliente.Negocio, Documento = x.tblSalida.documento, Cantidad = x.cantidad, Precio = x.precio, _
                         TipoPrecio = (From y In ctx.tblArticuloTipoPrecios Where x.tipoPrecio = y.codigo Select y.nombre).FirstOrDefault _
                        Order By Fecha Descending)

        Me.grdUltimasVentas.DataSource = general
    End Sub

    'Funcion utilizada para llenar el combo
    Private Sub fnLlenarCombo()
        Try
            'Realizamos la consulta
            Dim cons = (From x In ctx.tblArticuloes _
            Select Codigo = x.idArticulo, Nombre = x.nombre1.Trim() + "- (" + x.codigo1.Trim() + ")")

            'Llenamos el combo1
            With Me.cmbNombre1
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cons
            End With

            Dim cons2 = (From x In ctx.tblArticuloes _
                       Select Codigo = x.idArticulo, Nombre = x.codigo1.Trim())

            'Llenamos el combo1
            With Me.cmbCodigo1
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cons2
            End With

        Catch ex As Exception

        End Try
    End Sub
    'Funcion utilizada para llenar el combo
    Private Sub fnLlenarCombo2()
        Try
            'Realizamos la consulta

            Dim tipoRepuesto = From x In ctx.tblArticuloRepuestoes Select Codigo = x.codigo, Nombre = x.nombre Order By Nombre

            With Me.cmbTipoRepuesto
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tipoRepuesto
            End With

            Dim marcaRepuesto = From x In ctx.tblArticuloMarcaRepuestoes Select Codigo = x.codigo, Nombre = x.nombre Order By Nombre

            With Me.cmbMarcaRepuesto
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = marcaRepuesto
            End With


            Dim importancia = From x In ctx.tblArticuloImportancias Select Codigo = x.codigo, Nombre = x.nombre Order By Nombre

            With Me.cmbImportancia
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = importancia
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_llenarLista() Handles MyBase.llenarLista
        llenagrid()
        llenagrid2()
    End Sub

    'Private Sub frm_focoDatos() Handles Me.focoDatos
    '   lblCodigo1.Focus()
    'End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles MyBase.modificaRegistro
        Try
            Dim success As Boolean = True
            Dim codArt As Integer = CType(txtCodigo.Text, Integer)
            Dim fechaServidor As DateTime = fnFecha_horaServidor()

            Using transaction As New TransactionScope


                Try
                    'Obtenemos el articulo que queremos modificar
                    Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codArt Select x).FirstOrDefault

                    Dim precioPublico As Decimal = 0
                    Dim preciopublicosucursal As Decimal = 0

                    If IsNumeric(txtPrecioPublico.Text) Then
                        precioPublico = CDec(txtPrecioPublico.Text)
                    End If

                    If IsNumeric(txtPrecioPublicoMotriza.Text) Then
                        preciopublicosucursal = CDec(txtPrecioPublicoMotriza.Text)
                    End If

                    'Modificamos los precios del articulo
                    articulo.precioPublico = precioPublico
                    articulo.preciopublicosucursal = preciopublicosucursal
                    articulo.observacionPrecio = txtObservacion.Text
                    articulo.fechaprecio = CDate(fnFecha_horaServidor())

                    'Recorremos el grid de precio para guardar los precios.
                    Dim i = 0
                    Dim descuento As Double = 0
                    Dim utilidad As String = ""
                    Dim precio As Decimal = 0
                    Dim preciosucursal As Decimal = 0
                    Dim tipoNegocio As Integer = 0
                    Dim codigo As Integer = 0
                    Dim descuentosucursal As Double = 0


                    For i = 0 To Me.grdPrecios.Rows.Count - 1
                        Dim desc As String = CType(Me.grdPrecios.Rows(i).Cells("txmDescuento").Value, String)
                        descuento = desc.Substring(0, desc.LastIndexOf("%"))
                        '  Dim desc2 As String = CType(Me.grdPreciosMotriza.Rows(i).Cells("txmDescuento").Value, String)
                        ' descuentosucursal = desc2.Substring(0, desc2.LastIndexOf("%"))


                        utilidad = CType(Me.grdPrecios.Rows(i).Cells("utilidad").Value, String)
                        precio = CType(Me.grdPrecios.Rows(i).Cells("precioNormal").Value, Decimal)
                        tipoNegocio = CType(Me.grdPrecios.Rows(i).Cells("codTipoNegocio").Value, Integer)
                        codigo = CType(Me.grdPrecios.Rows(i).Cells("codigo").Value, Integer)
                        If codigo > 0 Then
                            'Si tipo de precio es mayor a cero, modificamos el registro
                            Dim tipo As tblArticulo_TipoNegocio = (From x In ctx.tblArticulo_TipoNegocio Where x.codigo = codigo _
                                                                      Select x).FirstOrDefault
                            'tipo.precioNormal = precio
                            'tipo.utilidad = utilidad.Substring(0, utilidad.Length - 2)
                            tipo.descuento = descuento
                            tipo.descuentosucursal = descuentosucursal
                            tipo.articulo = articulo.idArticulo
                            tipo.tipoNegocio = tipoNegocio
                            ctx.SaveChanges()
                        Else
                            'De lo contrario creamos el registro
                            Dim tipo As New tblArticulo_TipoNegocio
                            'tipo.precioNormal = precio
                            'tipo.utilidad = utilidad.Substring(0, utilidad.Length - 2)
                            tipo.descuento = descuento
                            tipo.descuentosucursal = descuentosucursal
                            tipo.articulo = articulo.idArticulo
                            tipo.tipoNegocio = tipoNegocio
                            ctx.AddTotblArticulo_TipoNegocio(tipo)
                            ctx.SaveChanges()
                        End If
                    Next



                    'Variables utilizadas para recorrer el grid de precios
                    'Recorremos el grid de otros precios para guardar los precios
                    Dim activa As Boolean = False
                    Dim perdida As Boolean = False
                    Dim cantEsta As Boolean = False
                    Dim fechaEsta As Boolean = False
                    Dim tPrecio As Integer = 0
                    Dim porcen As String = ""
                    Dim fInici As DateTime = Nothing
                    Dim fFin As DateTime = Nothing
                    Dim minima As Integer = 0
                    Dim activasucursal As Boolean = False
                    Dim perdidasucursal As Boolean = False
                    Dim cantestasucursal As Boolean = False
                    Dim fechaestasucursal As Boolean = False
                    Dim tpreciosucursal As Integer = 0
                    Dim porcensucursal As String = ""
                    Dim finicisucursal As DateTime = Nothing
                    Dim ffinsucursal As DateTime = Nothing
                    Dim minimasucursal As Integer = 0



                    '--- BITACORA DE PRECIOS
                    'Obtenemos la lista de otros precios
                    Dim lPrecio As List(Of tblArticulo_Precio) = (From x In ctx.tblArticulo_Precio.AsEnumerable Where x.articulo = codArt And Not x.tblArticuloTipoPrecio.bitEspecial _
                                                                  Select x).ToList
                    'Cadena utilizada para guardar la bitacora
                    Dim bitacora As String = ""
                    'Recorremos la lista de precios y el grid a la vez
                    For Each dPrecio As tblArticulo_Precio In lPrecio

                        For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                            'Reseteamos la cadena de bitacora
                            bitacora = ""

                            activa = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmActiva").Value, Boolean)
                            codigo = CType(Me.grdOtrosPrecios.Rows(i).Cells("codigo").Value, Integer)
                            precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, Decimal)
                            perdida = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minima = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            fechaEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)
                            Try
                                fInici = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)
                            Catch ex As Exception
                                fInici = Nothing
                            End Try

                            Try
                                fFin = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)
                            Catch ex As Exception
                                fFin = Nothing
                            End Try

                            'Verificamos si tienen el mismo codigo entonces procedemos a revisar cambios
                            If dPrecio.codigo = codigo Then
                                'SI SE ACTIVO O DESACTIVO PRECIO
                                If dPrecio.habilitado <> activa Then
                                    bitacora += "Se " & If(activa, "activo", "desactivo") & " precio" & vbCrLf
                                End If

                                'SI SE CAMBIO PRECIO
                                If dPrecio.precio <> precio Then
                                    bitacora += "Se cambio precio, Anterior: " & Format(dPrecio.precio, mdlPublicVars.formatoMoneda) _
                                        & " - Ahora: " & Format(precio, mdlPublicVars.formatoMoneda) & vbCrLf
                                End If

                                'SI SE ACTIVO POLITICA DE CANTIDAD MINIMA
                                If dPrecio.bitCantidad <> cantEsta Then
                                    bitacora += "Se " & If(cantEsta, "activo", "desactivo") & " politica de cantidad "

                                    If cantEsta Then
                                        bitacora += ", minimo : " & minima & vbCrLf
                                    End If

                                End If

                                'SI SE ACTIVO POLITICA DE FECHAS
                                If dPrecio.bitFecha <> fechaEsta Then
                                    bitacora += "Se " & If(fechaEsta, "activo", "desactivo") & " politica de fechas, "

                                    If fechaEsta Then
                                        bitacora += "De : " & fInici.ToShortDateString & " - Hasta :" & fFin.ToShortDateString
                                    End If
                                End If

                                If bitacora.Length > 0 Or Not bitacora.Equals("") Then
                                    'Creamos el nuevo registro de bitacora
                                    Dim eBitacora As New tblBitacoraPreciosArticulo
                                    eBitacora.articulo_precio = codigo
                                    eBitacora.descripcion = bitacora
                                    eBitacora.fechaRegistro = fechaServidor

                                    'Agregamos el registro al contexto
                                    ctx.AddTotblBitacoraPreciosArticuloes(eBitacora)
                                    ctx.SaveChanges()
                                End If
                            End If
                        Next

                    Next


                    '--- FIN DE BITACORA

                    Dim noempresa As Integer
                    Dim empresa As String

                    Dim idempresa As tblEmpresa = (From x In ctx.tblEmpresas _
                                          Select x).FirstOrDefault

                    noempresa = idempresa.idEmpresa

                    Dim nombreempresa As tblEmpresa = (From x In ctx.tblEmpresas Where x.idEmpresa = noempresa _
                                                 Select x).FirstOrDefault
                    empresa = nombreempresa.nombre

                    If empresa = "PRIMSA" Then
                        For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                            activa = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmActiva").Value, Boolean)
                            codigo = CType(Me.grdOtrosPrecios.Rows(i).Cells("codigo").Value, Integer)
                            tPrecio = CType(Me.grdOtrosPrecios.Rows(i).Cells("codPrecio").Value, Integer)
                            precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, Decimal)
                            'activasucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("chmActiva").Value, Boolean)
                            Try
                                'preciosucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("txmPreciosucursal").Value, Decimal)
                            Catch ex As Exception

                            End Try


                            porcen = CType(Me.grdOtrosPrecios.Rows(i).Cells("MargenUtilidad").Value, String)
                            perdida = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minima = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            fechaEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)

                            porcensucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("MargenUtilidad").Value, String)
                            perdidasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantestasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minimasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            ''fechaestasucursal = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)

                            Try
                                fInici = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)
                                ''finicisucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)
                                finicisucursal = Nothing
                            Catch ex As Exception
                                fInici = Nothing
                                finicisucursal = Nothing
                            End Try

                            Try
                                fFin = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)
                                ''ffinsucursal = CType(Me.grdOtrosPreciosSucursal.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)
                                ffinsucursal = Nothing
                            Catch ex As Exception
                                fFin = Nothing
                                ffinsucursal = Nothing
                            End Try


                            If codigo > 0 Then
                                'Modificamos el registro
                                Dim registro As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.codigo = codigo _
                                                                    Select x).FirstOrDefault
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio

                                registro.preciosucursal = preciosucursal
                                registro.habilitadosucursal = activasucursal
                                registro.bitcantidadsucursal = cantestasucursal
                                registro.bitfechasucursal = fechaestasucursal
                                registro.cantidadminimasucursal = minimasucursal
                                registro.porcentajesucursal = porcensucursal.Substring(0, porcensucursal.Length - 2)

                                finicisucursal = Nothing
                                ffinsucursal = Nothing

                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                    ''registro.fechaInicioSucursal = finicisucursal
                                    ''registro.fechaFin = ffinsucursal
                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing

                                    ''registro.fechaInicioSucursal = Nothing
                                    ''registro.fechaFinSucursal = Nothing
                                End If
                                ctx.SaveChanges()
                            Else
                                'Creamos el registro
                                Dim registro As New tblArticulo_Precio
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio

                                registro.preciosucursal = preciosucursal
                                registro.habilitadosucursal = activasucursal
                                registro.bitcantidadsucursal = cantestasucursal
                                registro.bitfechasucursal = fechaestasucursal
                                registro.bitpermiteperdidasucursal = perdidasucursal
                                registro.cantidadminimasucursal = minimasucursal
                                registro.porcentajesucursal = porcensucursal.Substring(0, porcen.Length - 2)


                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                    ''registro.fechaInicioSucursal = finicisucursal
                                    ''registro.fechaFinSucursal = ffinsucursal
                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing

                                    ''registro.fechaInicioSucursal = Nothing
                                    ''registro.fechaFinSucursal = Nothing
                                End If
                                ctx.AddTotblArticulo_Precio(registro)
                                ctx.SaveChanges()
                            End If
                        Next


                    Else

                        For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                            activa = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmActiva").Value, Boolean)
                            codigo = CType(Me.grdOtrosPrecios.Rows(i).Cells("codigo").Value, Integer)
                            tPrecio = CType(Me.grdOtrosPrecios.Rows(i).Cells("codPrecio").Value, Integer)
                            precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, Decimal)


                            porcen = CType(Me.grdOtrosPrecios.Rows(i).Cells("MargenUtilidad").Value, String)
                            perdida = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmPerdida").Value, Boolean)
                            cantEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmCantEstado").Value, Boolean)
                            minima = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmMinima").Value, Integer)
                            fechaEsta = CType(Me.grdOtrosPrecios.Rows(i).Cells("chmFechaEstado").Value, Boolean)



                            Try
                                fInici = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaInicio").Value + " 00:00:00", DateTime)


                            Catch ex As Exception
                                fInici = Nothing

                            End Try

                            Try
                                fFin = CType(Me.grdOtrosPrecios.Rows(i).Cells("txbFechaFinal").Value + " 23:59:59", DateTime)


                            Catch ex As Exception
                                fFin = Nothing

                            End Try


                            If codigo > 0 Then
                                'Modificamos el registro
                                Dim registro As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.codigo = codigo _
                                                                    Select x).FirstOrDefault
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio

                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing

                                End If
                                ctx.SaveChanges()
                            Else
                                'Creamos el registro
                                Dim registro As New tblArticulo_Precio
                                registro.habilitado = activa
                                registro.bitCantidad = cantEsta
                                registro.bitFecha = fechaEsta
                                registro.bitPermitePerdida = perdida
                                registro.articulo = articulo.idArticulo
                                registro.cantidadMinima = minima
                                registro.porcentaje = porcen.Substring(0, porcen.Length - 2)
                                registro.precio = precio
                                registro.tipoPrecio = tPrecio



                                If fechaEsta = True Then
                                    registro.fechaInicio = fInici
                                    registro.fechaFin = fFin

                                Else
                                    registro.fechaInicio = Nothing
                                    registro.fechaFin = Nothing
                                End If
                                ctx.AddTotblArticulo_Precio(registro)
                                ctx.SaveChanges()
                            End If
                        Next

                    End If

                    'Modificamos los sustitutos
                    Dim pPub As Decimal = 0
                    Dim pA As Decimal = 0
                    Dim pB As Decimal = 0
                    Dim pOfer As Decimal = 0
                    Dim idSust As Decimal = 0
                    Dim costo As Decimal = 0
                    For i = 0 To Me.grdSustitutos.Rows.Count - 1
                        idSust = Me.grdSustitutos.Rows(i).Cells("ID").Value
                        Try
                            pPub = Me.grdSustitutos.Rows(i).Cells("PrecioPublico").Value
                        Catch ex As Exception
                            pPub = 0
                        End Try
                        Try
                            pA = Me.grdSustitutos.Rows(i).Cells("PrecioA").Value
                        Catch ex As Exception
                            pA = 0
                        End Try
                        Try
                            pB = Me.grdSustitutos.Rows(i).Cells("PrecioB").Value
                        Catch ex As Exception
                            pB = 0
                        End Try


                        Try
                            pOfer = Me.grdSustitutos.Rows(i).Cells("PrecioOferta").Value
                        Catch ex As Exception
                            pOfer = 0
                        End Try
                        Try
                            costo = Me.grdSustitutos.Rows(i).Cells("Costo").Value
                        Catch ex As Exception
                            costo = 0
                        End Try


                        'Seleccionamos el articulo que modificaremos
                        Dim art As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = idSust Select x).FirstOrDefault
                        art.precioPublico = pPub
                        ctx.SaveChanges()

                        'Modificamos el precioA, precioB, precioOferta

                        'Obtenemos los precios
                        Dim listaP As List(Of tblArticulo_Precio) = (From x In ctx.tblArticulo_Precio _
                                                                     Where x.articulo = idSust Select x).ToList
                        Dim pre As tblArticulo_Precio
                        Dim marge As Decimal = 0
                        'Recorremos la lista de precios
                        For Each pre In listaP

                            If pre.tblArticuloTipoPrecio.nombre = "Precio A" Then
                                pre.precio = pA
                                Try
                                    utilidad = (1 - (pA / costo)) * 100
                                Catch ex As Exception
                                    utilidad = 0
                                End Try

                            ElseIf pre.tblArticuloTipoPrecio.nombre = "Precio B" Then
                                pre.precio = pB
                                Try
                                    utilidad = (1 - (pB / costo)) * 100
                                Catch ex As Exception
                                    utilidad = 0
                                End Try

                            ElseIf pre.tblArticuloTipoPrecio.nombre = "Precio Oferta" Then
                                pre.precio = pOfer
                                Try
                                    utilidad = (1 - (pOfer / costo)) * 100
                                Catch ex As Exception
                                    utilidad = 0
                                End Try
                            End If
                            pre.porcentaje = utilidad
                            ctx.SaveChanges()
                        Next

                    Next

                    ctx.SaveChanges()

                    transaction.Complete()
                Catch ex As System.Data.EntityException
                    'success = False
                Catch ex As Exception
                    'success = False
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
                alerta.fnModificar()
                Call llenagrid()
            Else
                alerta.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            ''fnModificarProducto()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar el grid de precios

    Private Sub fnLlenaPrecios()
        Try
            Me.grdPrecios.Rows.Clear()
            'Me.grdPreciosMotriza.Rows.Clear()
            'Obtenemos los tipos de negocios
            Dim listaNegocios As List(Of tblClienteTipoNegocio) = (From x In ctx.tblClienteTipoNegocios Select x Order By x.porcentaje Descending).ToList
            Dim negocio As tblClienteTipoNegocio
            Dim idArt As Integer = CInt(txtCodigo.Text)
            For Each negocio In listaNegocios

                'Seleccionamos el el registro del articulo 
                Dim pArt As tblArticulo_TipoNegocio = (From x In ctx.tblArticulo_TipoNegocio _
                                                                 Where x.articulo = idArt And x.tipoNegocio = negocio.idTipoNegocio _
                                                                 Select x).FirstOrDefault
                'Creamos la fila
                Dim fila As Object() = Nothing
                Dim filas As Object() = Nothing
                If pArt IsNot Nothing Then
                    fila = {pArt.codigo, pArt.tblClienteTipoNegocio.idTipoNegocio, pArt.tblClienteTipoNegocio.nombre, _
                            Format(pArt.descuento / 100, mdlPublicVars.formatoPorcentaje), "", ""}

                    filas = {pArt.codigo, pArt.tblClienteTipoNegocio.idTipoNegocio, pArt.tblClienteTipoNegocio.nombre, _
                            Format(pArt.descuentosucursal / 100, mdlPublicVars.formatoPorcentaje), "", ""}
                Else
                    fila = {"0", negocio.idTipoNegocio, negocio.nombre, negocio.porcentaje, "", ""}

                    filas = {"0", negocio.idTipoNegocio, negocio.nombre, negocio.porcentaje, "", ""}

                End If

                'Agregamos la fila al grid
                Me.grdPrecios.Rows.Add(fila)
                'Me.grdPreciosMotriza.Rows.Add(filas)

            Next
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para calcular los precio Normales
    Private Sub fnCalculaNormales()
        Try
            'Verificamos si el grid tiene datos
            If Me.grdPrecios.Rows.Count > 0 Then
                'Obtenemos el precio publico y costo Promedio
                Dim pPub As Decimal = 0
                Dim pPub2 As Decimal = 0

                If IsNumeric(txtPrecioPublico.Text) Then
                    pPub = CDec(txtPrecioPublico.Text)
                End If
                If IsNumeric(txtPrecioPublicoMotriza.Text) Then
                    pPub2 = CDec(txtPrecioPublicoMotriza.Text)
                End If

                '' Dim cProm As Decimal = CDec(lblCostoProm.Text) ''Pruebadatos lblCosto
                Dim cProm As Decimal = CDec(lblCosto.Text)
                'Recorremos el grid
                Dim index
                For index = 0 To Me.grdPrecios.Rows.Count - 1
                    Dim desc As String = CType(Me.grdPrecios.Rows(index).Cells("txmDescuento").Value, String)
                    '   Dim descsucursal As String = CType(Me.grdPreciosMotriza.Rows(index).Cells("txmDescuento").Value, String)
                    Dim descuento As Decimal = 0
                    Dim descuentosucursal As Decimal = 0

                    If desc.Contains("%") Then
                        descuento = CType(desc.Substring(0, desc.LastIndexOf("%")), Decimal) / 100
                    Else
                        descuento = CType(desc, Decimal) / 100
                    End If

                    'If descsucursal.Contains("%") Then
                    'descuentosucursal = CType(descsucursal.Substring(0, descsucursal.LastIndexOf("%")), Decimal) / 100
                    ' Else
                    ' descuentosucursal = CType(descsucursal, Decimal) / 100
                    ' End If


                    Dim pNor As Decimal = 0
                    Dim utili As Decimal = 0
                    Dim pNorSucursal As Decimal = 0
                    Dim utiliSucursal As Decimal = 0

                    'Realizamos las operaciones
                    pNor = pPub - (pPub * (descuento))
                    If pNor > 0 Then
                        utili = (1 - (cProm / pNor))
                    End If

                    'Realizamos las operaciones
                    pNorSucursal = pPub2 - (pPub2 * (descuentosucursal))
                    If pNorSucursal > 0 Then
                        utiliSucursal = (1 - (cProm / pNorSucursal))
                    End If

                    'Modificamos el grid
                    Me.grdPrecios.Rows(index).Cells("precioNormal").Value = Format(pNor, mdlPublicVars.formatoMoneda)
                    'Me.grdPreciosMotriza.Rows(index).Cells("precioNormal").Value = Format(pNorSucursal, mdlPublicVars.formatoMoneda)

                    Me.grdPrecios.Rows(index).Cells("utilidad").Value = Format(utili, mdlPublicVars.formatoPorcentaje)
                    'Me.grdPreciosMotriza.Rows(index).Cells("Utilidad").Value = Format(utiliSucursal, mdlPublicVars.formatoPorcentaje)

                    Me.grdPrecios.Rows(index).Cells("txmDescuento").Value = Format(descuento, mdlPublicVars.formatoPorcentaje)
                    'Me.grdPreciosMotriza.Rows(index).Cells("txmDescuento").Value = Format(descuentosucursal, mdlPublicVars.formatoPorcentaje)

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se utiliza para recalcular los precios normales, cuando se termina de editar una celda
    Private Sub grdPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdPrecios.CellEndEdit
        Try
            fnCalculaNormales()

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdPrecios)

            If fila = 1 Then
                fnPrecioC()
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Evento que se utiliza pra recalcular los precios normales, cuando se cambia el precio publico
    Private Sub txtPrecioPublico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioPublico.TextChanged
        Try
            fnCalculaNormales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecioPublicoMotriza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioPublicoMotriza.TextChanged
        Try
            fnCalculaNormales()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar el grid de otros precios
    Private Sub fnLlenaOtrosPrecios()
        Try
            Me.grdOtrosPrecios.Rows.Clear()
            Me.grdOtrosPrecios2.Rows.Clear()
            'Me.grdOtrosPreciosSucursal.Rows.Clear()
            Dim noempresa As Integer
            'Obtenemos los otros precios
            Dim listaPrecio As List(Of tblArticuloTipoPrecio) = (From x In ctx.tblArticuloTipoPrecios Where x.bitEspecial = False).ToList
            Dim precio As tblArticuloTipoPrecio
            Dim idArt As Integer = CInt(txtCodigo.Text)
            Dim empresa As String
            'Recorremos los precios
            For Each precio In listaPrecio
                'Seleccionamos el registro
                Dim pArt As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.articulo = idArt And x.tipoPrecio = precio.codigo _
                                                  Select x).FirstOrDefault


                Dim idempresa As tblEmpresa = (From x In ctx.tblEmpresas _
                                      Select x).FirstOrDefault

                noempresa = idempresa.idEmpresa

                Dim nombreempresa As tblEmpresa = (From x In ctx.tblEmpresas Where x.idEmpresa = noempresa _
                                             Select x).FirstOrDefault
                empresa = nombreempresa.nombre
                'Creamos la fila
                Dim fila As Object() = Nothing
                Dim fila2 As Object() = Nothing
                Dim filasucursal As Object() = Nothing



                If empresa = "PRIMSA" Then
                    If pArt IsNot Nothing Then
                        fila = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda), _
                                pArt.habilitado, pArt.porcentaje, "0", pArt.bitPermitePerdida, pArt.bitCantidad, Format(pArt.cantidadMinima, mdlPublicVars.formatoCantidad), pArt.bitFecha, _
                                Format(pArt.fechaInicio, mdlPublicVars.formatoFecha), Format(pArt.fechaFin, mdlPublicVars.formatoFecha)}

                        filasucursal = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.preciosucursal, mdlPublicVars.formatoMoneda), _
                                pArt.habilitadosucursal, pArt.porcentajesucursal, "0", pArt.bitpermiteperdidasucursal, pArt.bitcantidadsucursal, Format(pArt.cantidadminimasucursal, mdlPublicVars.formatoCantidad), pArt.bitfechasucursal, _
                                Format(pArt.fechainiciosucursal, mdlPublicVars.formatoFecha), Format(pArt.fechafinsucursal, mdlPublicVars.formatoFecha)}


                        fila2 = {pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda)}
                    Else
                        fila = {"0", precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda), False, precio.porcentaje, "0", False, False, "0", False, "", ""}
                        filasucursal = {"0", precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda), False, precio.porcentaje, "0", False, False, "0", False, "", ""}

                        fila2 = {precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda)}
                    End If
                    'Agregamos la fila al grid
                    Me.grdOtrosPrecios.Rows.Add(fila)
                    Me.grdOtrosPrecios2.Rows.Add(fila2)
                    'Me.grdOtrosPreciosSucursal.Rows.Add(filasucursal)


                Else
                    If pArt IsNot Nothing Then
                        fila = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda), _
                                pArt.habilitado, pArt.porcentaje, "0", pArt.bitPermitePerdida, pArt.bitCantidad, Format(pArt.cantidadMinima, mdlPublicVars.formatoCantidad), pArt.bitFecha, _
                                Format(pArt.fechaInicio, mdlPublicVars.formatoFecha), Format(pArt.fechaFin, mdlPublicVars.formatoFecha)}


                        fila2 = {pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda)}
                    Else
                        fila = {"0", precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda), False, precio.porcentaje, "0", False, False, "0", False, "", ""}

                        fila2 = {precio.codigo, precio.nombre, Format(0, mdlPublicVars.formatoMoneda)}
                    End If
                    'Agregamos la fila al grid
                    Me.grdOtrosPrecios.Rows.Add(fila)
                    Me.grdOtrosPrecios2.Rows.Add(fila2)
                End If

            Next

        Catch ex As Exception
            System.Console.WriteLine(ex.ToString())
        End Try
    End Sub

    'Funcion que se utiliza para calcular los otros precios
    Private Sub fnCalculaOtros()
        Try
            'Verificamos si el grid tiene datos
            If Me.grdOtrosPrecios.Rows.Count > 0 Then
                'Recorremos el grid
                Dim index

                Dim precioBase As Decimal = 0
                Dim utilidad As Decimal = 0
                '' Dim costoPromedio As Double = lblCostoProm.Text  ''pruebadatos  lblcosto.tex
                Dim costoPromedio As Double = lblCosto.Text

                For index = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                    precioBase = CType(Me.grdOtrosPrecios.Rows(index).Cells("txmPrecio").Value, Decimal)

                    Try
                        utilidad = 1 - (costoPromedio / precioBase)
                    Catch ex As Exception
                        utilidad = 0
                    End Try

                    If mdlPublicVars.empresa = "PRIMSA" Then
                        Me.grdOtrosPrecios.Rows(index).Cells("MargenUtilidad").Value = Format(utilidad, mdlPublicVars.formatoPorcentaje).ToString
                        '        Me.grdOtrosPreciosSucursal.Rows(index).Cells("MargenUtilidad").Value = Format(utilidad, mdlPublicVars.formatoPorcentaje).ToString

                        'Me.grdOtrosPrecios.Rows(index).Cells("txmPrecio").Value = Format(precioBase, mdlPublicVars.formatoMoneda)
                    Else
                        Me.grdOtrosPrecios.Rows(index).Cells("MargenUtilidad").Value = Format(utilidad, mdlPublicVars.formatoPorcentaje).ToString

                    End If

                Next


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdOtrosPrecios.CellEndEdit
        Try
            fnCalculaOtros()

            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdOtrosPrecios)

            If fila = 0 Or fila = 1 Then
                fnPrecioC()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdOtrosPrecios.ValueChanged
        Try
            Dim fil As Integer = CInt(Me.grdOtrosPrecios.CurrentRow.Index)
            Dim col As Integer = CInt(Me.grdOtrosPrecios.CurrentColumn.Index)
            Dim nombre = mdlPublicVars.tipoControl(Me.grdOtrosPrecios.Columns(col).Name)

            If mdlPublicVars.tipoControl(nombre) = "chm" Then
                txtCodigo.Focus()
                txtCodigo.Select()
                grdOtrosPrecios.Focus()
                Me.grdPrecios.Rows(fil).Cells(col).IsSelected = True
            End If

            'Copiamos los cambios al grid 2
            Dim i
            Dim precio As String
            For i = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                precio = CType(Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value, String)

                'Asignamos el cambio al otro grid
                Me.grdOtrosPrecios2.Rows(i).Cells("txmPrecio").Value = precio

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdOtrosPrecios.KeyDown
        Try
            'Si presionamos la tecla F2
            If e.KeyCode = Keys.F2 Then
                fnFechas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnFechas()
        Dim fil = Me.grdOtrosPrecios.CurrentRow.Index
        Dim col = Me.grdOtrosPrecios.CurrentColumn.Index

        Dim acFecha As Boolean = CType(Me.grdOtrosPrecios.Rows(fil).Cells("chmFechaEstado").Value, Boolean)

        If acFecha = True And col > 10 Then
            frmFecha.Text = "Fecha"
            If col = 11 Then
                frmFecha.opcionRetorno = "precioInicio"
                frmFecha.bitgrid1 = True
            ElseIf col = 12 Then
                frmFecha.opcionRetorno = "precioFinal"
                frmFecha.bitgrid1 = True
            End If
            frmFecha.StartPosition = FormStartPosition.CenterScreen
            frmFecha.ShowDialog()
        End If
    End Sub

    'Private Sub fnFechasSucursal()
    'Dim fil = Me.grdOtrosPreciosSucursal.CurrentRow.Index
    'Dim col = Me.grdOtrosPreciosSucursal.CurrentColumn.Index

    'Dim acFecha As Boolean = CType(Me.grdOtrosPreciosSucursal.Rows(fil).Cells("chmFechaEstado").Value, Boolean)

    'If acFecha = True And col > 10 Then
    'frmFecha.Text = "Fecha"
    'If col = 11 Then
    '    frmFecha.opcionRetorno = "precioInicio"
    '   frmFecha.bitgrid1 = False
    '  ElseIf col = 12 Then
    ' frmFecha.opcionRetorno = "precioFinal"
    'frmFecha.bitgrid1 = False
    'End If
    'frmFecha.StartPosition = FormStartPosition.CenterScreen
    'frmFecha.ShowDialog()
    'End If
    'End Sub
    'Funcion para agregar la fecha seleecionada
    Public Sub fnAgregarFecha()
        Try
            If mdlPublicVars.superSearchId = 1 Then
                Me.grdOtrosPrecios.Rows(Me.grdOtrosPrecios.CurrentRow.Index).Cells("txbFechaInicio").Value = mdlPublicVars.superSearchFecha.ToShortDateString
            ElseIf mdlPublicVars.superSearchId = 2 Then
                Me.grdOtrosPrecios.Rows(Me.grdOtrosPrecios.CurrentRow.Index).Cells("txbFechaFinal").Value = mdlPublicVars.superSearchFecha.ToShortDateString
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub fnAgregarFechaSucursal()
    ' Try
    '    If mdlPublicVars.superSearchId = 1 Then
    '       Me.grdOtrosPreciosSucursal.Rows(Me.grdOtrosPreciosSucursal.CurrentRow.Index).Cells("txbFechaInicio").Value = mdlPublicVars.superSearchFecha.ToShortDateString
    '  ElseIf mdlPublicVars.superSearchId = 2 Then
    '     Me.grdOtrosPreciosSucursal.Rows(Me.grdOtrosPreciosSucursal.CurrentRow.Index).Cells("txbFechaFinal").Value = mdlPublicVars.superSearchFecha.ToShortDateString
    'End If
    '    Catch ex As Exception
    '
    '   End Try
    'End Sub

    Private Sub lblCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCosto.TextChanged
        Try
            fnLlenaPrecios()
            fnCalculaNormales()
            fnLlenaOtrosPrecios()
            fnCalculaOtros()
            fnConfiguracion()
            lblCostoProm.Text = lblCosto.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdOtrosPrecios2_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs)
        Try
            'Recorremos el grid de precios.
            Dim i
            Dim precio As Decimal = 0
            For i = 0 To Me.grdOtrosPrecios2.Rows.Count - 1
                precio = CType(Me.grdOtrosPrecios2.Rows(i).Cells("txmPrecio").Value, Decimal)

                Me.grdOtrosPrecios2.Rows(i).Cells("txmPrecio").Value = Format(precio, mdlPublicVars.formatoMoneda)
                Me.grdOtrosPrecios.Rows(i).Cells("txmPrecio").Value = Format(precio, mdlPublicVars.formatoMoneda)
            Next

            fnCalculaOtros()
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar los sustitutos
    Private Sub fnLlenarSustitutos()
        Try
            'Codigo
            Dim codArt As Integer = CType(Me.txtCodigo.Text, Integer)
            Dim sustituto As tblSustituto = (From x In ctx.tblSustitutoes Where x.idarticulo = codArt Select x).FirstOrDefault

            If sustituto IsNot Nothing Then
                Dim consulta = (From x In ctx.tblSustitutoes Join y In ctx.tblArticuloes On x.idarticulo Equals y.idArticulo Order By y.codigo1
                             Where x.idSustitutoCategoria = sustituto.idSustitutoCategoria And y.idArticulo <> codArt
                             Select ID = y.idArticulo, Codigo = y.codigo1, Nombre = y.nombre1, Marca = y.tblArticuloMarcaRepuesto.nombre, _
                             Costo = y.costoIVA, PrecioPublico = y.precioPublico, _
                             PrecioNormal = (From a In ctx.tblArticulo_TipoNegocio Where a.articulo = y.idArticulo And a.tipoNegocio = 6 Select a.tblArticulo.precioPublico * (100 - a.descuento) / 100).FirstOrDefault, _
                             PrecioA = (From a In ctx.tblArticulo_Precio Where a.articulo = y.idArticulo And a.tipoPrecio = 1 Select a.precio).FirstOrDefault, _
                             PrecioB = (From a In ctx.tblArticulo_Precio Where a.articulo = y.idArticulo And a.tipoPrecio = 2 Select a.precio).FirstOrDefault, _
                             PrecioOferta = (From a In ctx.tblArticulo_Precio Where a.articulo = y.idArticulo And a.tipoPrecio = 3 Select a.precio).FirstOrDefault, _
                             Existencia = (From z In ctx.tblInventarios Where z.idArticulo = y.idArticulo Select z.saldo).FirstOrDefault).ToList

                Me.grdSustitutos.DataSource = consulta

            Else
                Me.grdSustitutos.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se maneja cada vez que se cambia de sustituto
    Private Sub grdSustitutos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdSustitutos.SelectionChanged
        Try
            'Codigo articulo
            Dim codArt As Integer = Me.grdSustitutos.Rows(Me.grdSustitutos.CurrentRow.Index).Cells("ID").Value
            fnLlenarPreciosSustitutos(codArt)
        Catch ex As Exception

        End Try
    End Sub

    'Funcion que se utiliza para llenar los precios del sustituto
    Private Sub fnLlenarPreciosSustitutos(ByVal codArt As Integer)
        Try
            Me.grdPreciosSustitutos.Rows.Clear()
            'Obtenemos los otros precios
            Dim listaPrecio As List(Of tblArticuloTipoPrecio) = (From x In ctx.tblArticuloTipoPrecios _
                                                                 Where x.bitEspecial = False).ToList
            Dim precio As tblArticuloTipoPrecio
            'Recorremos los precios
            For Each precio In listaPrecio
                'Seleccionamos el registro
                Dim pArt As tblArticulo_Precio = (From x In ctx.tblArticulo_Precio Where x.articulo = codArt And x.tipoPrecio = precio.codigo _
                                                  Select x).FirstOrDefault

                'Creamos la fila
                Dim fila As Object() = Nothing

                If pArt IsNot Nothing Then
                    fila = {pArt.codigo, pArt.tblArticuloTipoPrecio.codigo, pArt.tblArticuloTipoPrecio.nombre, Format(pArt.precio, mdlPublicVars.formatoMoneda), _
                            pArt.habilitado, Format(pArt.porcentaje / 100, mdlPublicVars.formatoPorcentaje), "0", pArt.bitPermitePerdida, pArt.bitCantidad, Format(pArt.cantidadMinima, mdlPublicVars.formatoCantidad), pArt.bitFecha, _
                            Format(pArt.fechaInicio, mdlPublicVars.formatoFecha), Format(pArt.fechaFin, mdlPublicVars.formatoFecha)}

                Else
                    fila = {"0", precio.codigo, precio.nombre, "0.00", False, Format(precio.porcentaje / 100, mdlPublicVars.formatoPorcentaje), _
                            "0", False, False, "0", False, "", ""}

                End If
                'Agregamos la fila al grid
                Me.grdPreciosSustitutos.Rows.Add(fila)

            Next
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se utiliza para manejar el cambio de articulo
    Private Sub cmbNombre1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombre1.SelectedValueChanged
        Try
            'Obtenemos el id del articulo
            Dim codArt As Integer = CType(cmbNombre1.SelectedValue, Integer)
            fnBuscaArticulo(codArt)
            fnUltimasVentas()
            fnUltimasCompras()
            fnClasificacion()
        Catch ex As Exception

        End Try
    End Sub

    'Evento que se utiliza para manejar el cambio de articulo
    Private Sub cmbCodigo1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodigo1.SelectedValueChanged
        Try
            'Obtenemos el id del articulo
            Dim codArt As Integer = CType(cmbCodigo1.SelectedValue, Integer)
            fnBuscaArticulo(codArt)
            fnUltimasVentas()
            fnUltimasCompras()
            fnClasificacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnClasificacion()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim id As Integer = Me.cmbNombre1.SelectedValue

                Dim a As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).FirstOrDefault

                Me.txtCodigoM1.Text = a.codigo1
                Me.txtCodigoM2.Text = a.codigo2
                Me.txtProductoM1.Text = a.nombre1
                Me.txtProductoM2.Text = a.nombre2
                Me.txtObs.Text = a.Observacion


                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para posicionarse en el grid de articulos segun el codigo del producto
    Private Sub fnBuscaArticulo(ByVal codArt As Integer)
        Try
            'Variable utilizada para recorrer el grid
            Dim i

            'Variable utilizada temporalmente para guardar temporalmente el id de articulo
            Dim id As Integer = 0
            'Recorremos el grid
            For i = 0 To Me.grdDatos.Rows.Count - 1
                id = CType(grdDatos.Rows(i).Cells("Codigo").Value, Integer)

                If id = codArt Then
                    Me.grdDatos.Rows(i).IsSelected = True
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    'Funcion utilizada para llenar las ultimas compras del producto
    Private Sub fnUltimasCompras()
        Try
            Dim codArt As Integer = Me.txtCodigo.Text ''Me.cmbNombre1.SelectedValue
            Dim lista = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False And x.tblEntrada.compra = True And x.idArticulo = codArt _
                        Select Fecha = x.tblEntrada.fechaRegistro, Proveedor = x.tblEntrada.tblProveedor.negocio, Cantidad = x.cantidad, Costo = x.costoIVA _
                        Order By Fecha Descending)
            'Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

            Me.grdUltimasCompras.DataSource = lista
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar las ultimas compras del producto
    'Private Sub fnUltimasCompras2()
    '    Try
    ' Dim codArt As Integer = CInt(cmbCodigo1.SelectedValue)
    'Dim lista = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False And x.tblEntrada.compra = True And x.idArticulo = codArt _
    '          Select Fecha = x.tblEntrada.fechaRegistro, Proveedor = x.tblEntrada.tblProveedor.negocio, Cantidad = x.cantidad, Costo = x.costoIVA _
    '            Order By Fecha Descending)
    'Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

    '       Me.grdUltimasCompras.DataSource = lista
    '   Catch ex As Exception

    '   End Try
    ' End Sub

    'Funcion utilizada para llenar los precios de la competencia
    Private Sub fnPreciosCompetencia()
        Try
            'Obtenemos los precios de la competencia en base a el articulo
            Dim codArt As Integer = CInt(cmbNombre1.SelectedValue)

            Dim cons = (From x In ctx.tblPrecioCompetencias Where x.articulo = codArt _
                        Select Fecha = x.fechaRegistro, Cliente = x.tblCliente.Negocio, Precio = x.precio, Observacion = x.observacion _
                        Order By Fecha Descending)

            'Me.grdPreciosCompe.DataSource = cons
        Catch ex As Exception
        End Try
    End Sub

    'Funcion utilizada para llenar los precios de la competencia
    'Private Sub fnPreciosCompetencia2()
    'Try
    'Obtenemos los precios de la competencia en base a el articulo
    ' Dim codArt As Integer = CInt(cmbCodigo1.SelectedValue)

    'Dim cons = (From x In ctx.tblPrecioCompetencias Where x.articulo = codArt _
    '         Select Fecha = x.fechaRegistro, Cliente = x.tblCliente.Negocio, Precio = x.precio, Observacion = x.observacion _
    '      Order By Fecha Descending)

    '    Me.grdPreciosCompe.DataSource = cons
    '  Catch ex As Exception
    '  End Try
    ' End Sub


    Private Sub frmProductoPrecio_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmPriceLista.frm_llenarLista()
        ''frmProductoLista.frm_llenarLista()
    End Sub

    Private Sub grdOtrosPrecios_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdOtrosPrecios.CellDoubleClick
        fnFechas()
    End Sub

    Private Sub btnActualizarCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCosto.Click
        frmIngresaClave.Text = "Ingrese clave"
        frmIngresaClave.StartPosition = FormStartPosition.CenterScreen
        frmIngresaClave.ShowDialog()
        frmIngresaClave.Dispose()
        If mdlPublicVars.fnAutorizaClave(mdlPublicVars.superSearchClave) Then
            frmEditaCosto.Text = "Edita Costo"
            frmEditaCosto.articulo = CInt(cmbNombre1.SelectedValue)
            frmEditaCosto.StartPosition = FormStartPosition.CenterParent
            frmEditaCosto.ShowDialog()
            frmEditaCosto.Dispose()
            llenagrid()
        Else
            RadMessageBox.Show("La contraseña ingresada es incorrecta", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End If
    End Sub


    ' Private Sub btnPrecioCompetencia_Click(sender As Object, e As EventArgs) Handles btnPrecioCompetencia.Click
    '    Try
    '   frmBuscarArticuloPrecioCompetencia.Text = "Precios Competencia"
    '   frmBuscarArticuloPrecioCompetencia.codigoArticulo = CType(txtCodigo.Text, Integer)
    '  frmBuscarArticuloPrecioCompetencia.bitBloquearCombo = False
    ' frmBuscarArticuloPrecioCompetencia.StartPosition = FormStartPosition.CenterScreen
    ' permiso.PermisoDialogEspeciales(frmBuscarArticuloPrecioCompetencia)
    ' frmBuscarArticuloPrecioCompetencia.Dispose()
    'fnPreciosCompetencia()
    ' Catch ex As Exception
    ' RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
    '  End Try
    'End Sub


    ' Private Sub grdOtrosPreciosSucursal_KeyDown(sender As Object, e As KeyEventArgs)
    '  Try
    'Si presionamos la tecla F2
    '   If e.KeyCode = Keys.F2 Then
    '     fnFechasSucursal()
    '  End If
    '  Catch ex As Exception
    '
    ' End Try
    ' End Sub

    'Funcion utilizada para cuando se cambia de producto
    Private Sub frm_txtcodigo() Handles txtCodigo.TextChanged
        Try
            fnLlenaPrecios()
            fnCalculaNormales()
            fnLlenaOtrosPrecios()
            fnCalculaOtros()
            fnLlenarSustitutos()
            fnPreciosCompetencia()
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub frm_focoDatos() Handles MyBase.focoDatos
        cmbCodigo1.Focus()
    End Sub

    'Funcion que se utiliza para poder crear un nuevo campo
    Private Sub frm_nuevoRegistro() Handles MyBase.nuevoRegistro
        limpiaCampos()
        cmbCodigo1.Focus()
        If pctFoto.Image IsNot Nothing Then
            pctFoto.Image = Nothing
        End If
        If verRegistro = True Then
            'se manda de parametro el formulario y el estado a deshabilitado.
            base.FnDeshabilitarHabilitarCampos(Me, False)
        End If
    End Sub

    Private Sub frm_cmbCodigo1() Handles txtCodigo.TextChanged
        fnLlenar_Listas()
        'llenar lista de modelo, marcas, tipo de vehiculo.
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
        fngrd_contador(grdModeloVehiculo, lblRecuentoModelo)

        'llenar clasificacion de compra del cliente.
        If NuevoIniciar = False Then
            Try
                'Llenamos las ubicaciones
                Dim ubicaciones As tblArticuloAlmacen = (From x In ctx.tblArticuloAlmacens Where x.articulo = txtCodigo.Text).FirstOrDefault
                If ubicaciones Is Nothing Then
                    txtUbicacionCajas.Text = ""
                    txtUbicacionEstanteria.Text = ""
                Else
                    txtUbicacionCajas.Text = ubicaciones.ubicacionCajas
                    txtUbicacionEstanteria.Text = ubicaciones.ubicacionEstanteria
                End If

                'Liberamos las fotos
                If pctFoto.Image IsNot Nothing Then
                    pctFoto.Image = Nothing
                End If

                'Llenamos el grid de fotos
                fnLlenarFotos(CType(txtCodigo.Text, Integer))

                If Me.grdFotos.Rows.Count > 0 Then
                    fnFoto()
                End If

                ''If chkKit.Checked = True Then
                ''    lblCostoKit.Visible = True
                ''Else
                ''    lblCostoKit.Visible = False
                ''End If

                'Llenamos los codigos de barra

            Catch ex As Exception

            End Try
        Else
        End If
    End Sub

    'Funcion utilizada para cargar las fotos
    Private Sub fnCargarFoto(ByRef pct As PictureBox, ByVal direccion As String)
        Try
            'Vaciamos la imagen
            If pct.Image IsNot Nothing Then
                pct.Image = Nothing
            End If

            If direccion IsNot Nothing Then
                If direccion.Length > 0 Then
                    Dim stream As New System.IO.StreamReader(direccion)
                    pct.Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    pct.SizeMode = PictureBoxSizeMode.StretchImage
                    pct.BorderStyle = BorderStyle.Fixed3D
                End If
            End If
        Catch ex As Exception
            alertas.contenido = "Ocurrio un error al intentar abrir la imagen"
            alertas.fnErrorContenido()
        End Try
    End Sub

    '''GUARDAR
    ''Private Sub frm_grabaRegistro() Handles MyBase.grabaRegistro
    ''    If IsNumeric(txtCodigo.Text) Then
    ''        fnModificarProducto()
    ''    Else
    ''        fnGuardarProducto()
    ''    End If
    ''End Sub


    'Funcion utilizada para modificar un producto
    Private Sub fnModificarProducto()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codigo As Integer = 0
            Dim success As Boolean = True
            Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor

            'crear el encabezado de la transaccion
            Using transaction As New TransactionScope

                'inicio de excepcion
                Try
                    ''Modificaciones de Kits y Unidades de Medida
                    If chkKit.Checked = True Then

                        '---- Si es kit guardamos el kit
                        fnGuardaKit()

                    ElseIf chkUnidadMedida.Checked = True Then

                    End If

                    '---si es unidad medida guardamos la unidad
                    Dim val As Boolean


                    ctx.SaveChanges()
                    ''Fin de modificaciones de Kits y Unidades de Medida

                    Dim m As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = txtCodigo.Text Select x).FirstOrDefault

                    'recuento de numero de transacciones en salida, entrada.
                    Dim noSalidas As Integer = (From x In ctx.tblSalidaDetalles Where x.idArticulo = m.idArticulo).Count + (From x In ctx.tblEntradasDetalles Where x.idArticulo = m.idArticulo).Count

                    If m.codigo1.Equals(cmbCodigo1.Text) Then
                        'no hay problemas
                    ElseIf noSalidas > 0 Then
                        'asignar el contenido del error.
                        alertas.contenido = "No puede cambiar el codigo del producto porque ya tiene registros"
                        'muestra el error.
                        alertas.fnErrorContenido()
                        Exit Sub
                    End If


                    m.idArticuloImportancia = cmbImportancia.SelectedValue
                    m.idArticuloMarcaRepuesto = cmbMarcaRepuesto.SelectedValue
                    m.idArticuloRepuesto = cmbTipoRepuesto.SelectedValue

                    m.idUsuario = mdlPublicVars.idUsuario
                    m.nombre1 = cmbNombre1.Text 'antes combo

                    m.nombre1 = cmbNombre1.Text
                    m.codigo1 = cmbCodigo1.Text



                    m.Observacion = txtObservacion.Text



                    codigo = m.idArticulo

                    If m.bitKit Then
                        m.costoSinIVA = m.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                    End If
                    ctx.SaveChanges()
                    'Guardamos las ubicaciones en el alamacen
                    'guarda la ubicacion en el almacen


                    Dim inv As tblInventario = (From x In ctx.tblInventarios Where x.idArticulo = txtCodigo.Text).FirstOrDefault
                    inv.idTipoInventario = 1 'Me.cmbInventario.SelectedValue
                    inv.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal

                    ctx.SaveChanges()


                    Dim ub As tblArticuloAlmacen = (From x In ctx.tblArticuloAlmacens Where x.articulo = txtCodigo.Text).FirstOrDefault

                    If ub Is Nothing Then
                        Dim nuevaUbicacion As New tblArticuloAlmacen
                        nuevaUbicacion.articulo = m.idArticulo
                        nuevaUbicacion.almacen = mdlPublicVars.General_idAlmacenPrincipal
                        nuevaUbicacion.ubicacionCajas = txtUbicacionCajas.Text
                        nuevaUbicacion.ubicacionEstanteria = txtUbicacionEstanteria.Text
                        ctx.AddTotblArticuloAlmacens(nuevaUbicacion)
                        ctx.SaveChanges()
                    Else
                        ub.almacen = mdlPublicVars.General_idAlmacenPrincipal
                        ub.articulo = m.idArticulo
                        ub.ubicacionCajas = txtUbicacionCajas.Text
                        ub.ubicacionEstanteria = txtUbicacionEstanteria.Text
                        ctx.SaveChanges()
                    End If

                    Dim estado As Boolean = False
                    Dim cod As Integer
                    Dim i As Integer
                    Dim id As Integer
                    Dim grd As Telerik.WinControls.UI.RadGridView


                    'AGREGAR TIPO DE VEHICULO.
                    grd = Me.grdTipoVehiculo
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells("Agregar").Value
                        cod = grd.Rows(i).Cells("Codigo").Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblArticulo_TipoVehiculo
                                tv.articuloTipoVehiculo = cod
                                tv.articulo = m.idArticulo
                                ctx.AddTotblArticulo_TipoVehiculo(tv)
                                ctx.SaveChanges()
                            End If
                        Else ' si estado = falso

                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells("Id").Value
                                Dim tv As tblArticulo_TipoVehiculo = (From x In ctx.tblArticulo_TipoVehiculo Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    ctx.DeleteObject(tv)
                                    ctx.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    'AGREGAR MODELO DE VEHICULO
                    grd = Me.grdModeloVehiculo
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells("Agregar").Value
                        cod = grd.Rows(i).Cells("Codigo").Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then
                            Else
                                Dim tv As New tblArticulo_ModeloVehiculo
                                tv.articuloModeloVehiculo = cod
                                tv.articulo = m.idArticulo
                                ctx.AddTotblArticulo_ModeloVehiculo(tv)
                                ctx.SaveChanges()
                            End If
                        Else ' si estado = falso
                            If CType(grd.Rows(i).Cells("Id").Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells("Id").Value
                                Dim tv As tblArticulo_ModeloVehiculo = (From x In ctx.tblArticulo_ModeloVehiculo Where x.codigo = id Select x).FirstOrDefault
                                If tv IsNot Nothing Then
                                    ctx.DeleteObject(tv)
                                    ctx.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    '---- SUSTITUTOS -----
                    fnGuardaSustitutos()

                    'completar la transaccion.
                    success = True
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
                ctx.AcceptAllChanges()
                alertas.fnModificar()
                'Vaciamos el picture box
                ''If pctFoto.Image IsNot Nothing Then
                ''    pctFoto.Image = Nothing
                ''End If

                ' ''Guardamos las imagenes
                ''If Me.grdFotos.Rows.Count > 0 Then
                ''    For i As Integer = 0 To Me.grdFotos.Rows.Count - 1
                ''        fnGuardar_foto(codigo, i)
                ''    Next
                ''End If

                Call llenagrid()
                Call llenagrid2()
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            conn.Close()
        End Using

        'Funcion utilizada para guardar un producto
    End Sub

    Private Sub fnGuardarProducto()
        'Verificamos que no falten los campos requeridos
        If fnRequeridos.Length > 0 Then
            alertas.contenido = fnRequeridos()
            alertas.fnErrorContenido()
            Exit Sub
        End If

        'Verificamos si aun no existe el codigo
        If fnVerificaCodigo(cmbCodigo1.Text) = True Then
            RadMessageBox.Show("El codigo " & cmbCodigo1.Text & " ya existe !!!", nombreSistema)

            If RadMessageBox.Show("Desea Habilitarlo?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim articulo As tblArticulo = (From x In conexion.tblArticuloes Where x.codigo1 = cmbCodigo1.Text And x.empresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

                    articulo.Habilitado = True

                    conexion.SaveChanges()

                    conn.Close()
                End Using
            End If

            Exit Sub
        End If

        Dim codigoArticulo As String = ""
        Dim codigo As Integer = 0
        Dim success As Boolean = True
        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim m As New tblArticulo
        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope

            'inicio de excepcion
            Try
                m.Habilitado = True
                m.idArticuloImportancia = cmbImportancia.SelectedValue
                m.idArticuloMarcaRepuesto = cmbMarcaRepuesto.SelectedValue
                m.idArticuloRepuesto = cmbTipoRepuesto.SelectedValue
                m.empresa = mdlPublicVars.idEmpresa
                m.idUsuario = mdlPublicVars.idUsuario
                m.nombre1 = cmbNombre1.Text

                m.codigo1 = cmbCodigo1.Text
                m.costoIVA = 0
                m.costoSinIVA = 0
                m.Observacion = txtObservacion.Text

                m.fechaCrea = fecha
                m.preciopublicosucursal = 0

                m.bitProducto = chkProducto.Checked
                m.bitServicio = chkServicio.Checked
                m.bitKit = chkKit.Checked
                m.bitUnidadMedida = chkUnidadMedida.Checked
                m.UltimoPrecio = False



                m.idUnidadMedida = mdlPublicVars.UnidadMedidaDefault


                m.UltimoPrecio = False

                If (Not chkProducto.Checked And Not chkServicio.Checked And Not chkKit.Checked And Not chkUnidadMedida.Checked) Then
                    m.bitProducto = True
                End If

                If m.bitKit Then
                    m.costoSinIVA = m.costoIVA / (1 + (mdlPublicVars.General_IVA / 100))
                End If

                ctx.AddTotblArticuloes(m)
                ctx.SaveChanges()
                codigo = m.idArticulo
                codigoArticulo = m.codigo1
                'guarda la ubicacion en el almacen
                Dim ub As New tblArticuloAlmacen
                ub.almacen = mdlPublicVars.General_idAlmacenPrincipal
                ub.articulo = m.idArticulo
                ub.ubicacionCajas = txtUbicacionCajas.Text
                ub.ubicacionEstanteria = txtUbicacionEstanteria.Text
                ctx.AddTotblArticuloAlmacens(ub)
                ctx.SaveChanges()

                'crear registro de inventario.
                Dim inv As New tblInventario
                inv.idArticulo = m.idArticulo
                inv.entrada = 0
                inv.salida = 0
                inv.saldo = 0
                inv.reserva = 0
                inv.idTipoInventario = 1 'Me.cmbInventario.SelectedValue
                inv.IdAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                inv.transito = 0
                ctx.AddTotblInventarios(inv)
                ctx.SaveChanges()
                'agregar tipo de vehiculo.
                Dim i
                Dim valor As Boolean = False
                Dim cod As Integer = 0

                For i = 0 To Me.grdTipoVehiculo.Rows.Count - 1
                    valor = Me.grdTipoVehiculo.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdTipoVehiculo.Rows(i).Cells(2).Value
                        Dim tv As New tblArticulo_TipoVehiculo
                        tv.articulo = m.idArticulo
                        tv.articuloTipoVehiculo = cod
                        ctx.AddTotblArticulo_TipoVehiculo(tv)
                        ctx.SaveChanges()
                    End If
                Next

                'modelo de vehiculo
                For i = 0 To Me.grdModeloVehiculo.Rows.Count - 1
                    valor = Me.grdModeloVehiculo.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdModeloVehiculo.Rows(i).Cells(2).Value
                        Dim tv As New tblArticulo_ModeloVehiculo
                        tv.articulo = m.idArticulo
                        tv.articuloModeloVehiculo = cod
                        ctx.AddTotblArticulo_ModeloVehiculo(tv)
                        ctx.SaveChanges()
                    End If
                Next




                alertas.fnGuardar()

                'completar la transaccion.
                success = True
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
            ctx.AcceptAllChanges()
            alertas.fnGuardar()

            Me.Close()
        Else
            Call llenagrid()
            NuevoIniciar = False
            If RadMessageBox.Show("¿Desea guardar otro registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
            Else
                Me.Close()
            End If
        End If
        alertas.fnErrorGuardar()
        Console.WriteLine("La operacion no pudo ser completada")
    End Sub

    'Funcion utilizada para guardar una foto
    Private Sub fnGuardar_foto(ByVal codigo As Integer, ByVal fila As String)
        Dim success As Boolean = True


        Using transaction As New TransactionScope
            Try
                'Obtenemos el codigo de la imagen
                Dim idFoto As Integer = CType(Me.grdFotos.Rows(fila).Cells("codigo").Value, Integer)
                Dim direccion As String = CType(Me.grdFotos.Rows(fila).Cells("direccion").Value, String)
                Dim elimina As Integer = CType(Me.grdFotos.Rows(fila).Cells("elimina").Value, Integer)

                'Si elimin
                If idFoto > 0 Then
                    'Creamos la nueva imagen
                    Dim foto As New tblArticulo_Foto

                    foto.articulo = codigo
                    ctx.AddTotblArticulo_Foto(foto)
                    ctx.SaveChanges()
                    Dim codFoto As Integer = foto.codigo
                    'guardar la imagen.
                    Dim Ruta As String = Path.Combine(mdlPublicVars.General_CarpetaImagenes, codFoto & ".jpg")
                    Dim stream As New System.IO.StreamReader(direccion)
                    Dim imagen As Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    Dim bmap As Bitmap = New Bitmap(imagen)
                    bmap.Save(Ruta, imagen.RawFormat)
                    bmap.Dispose()
                    ctx.SaveChanges()
                End If
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
            ctx.AcceptAllChanges()
        Else

        End If
    End Sub

    'Llena el grid de fotos
    Private Sub fnLlenarFotos(ByVal codigo As Integer)
        Try
            Me.grdFotos.Rows.Clear()
            'Obtenemos las fotos del articulo
            Dim fotos As List(Of tblArticulo_Foto) = (From x In ctx.tblArticulo_Foto Where x.articulo = codigo Select x).ToList
            Dim foto As tblArticulo_Foto
            Dim i As Integer = 0
            For Each foto In fotos
                i += 1
                Dim fila As String()
                Dim ruta As String = Path.Combine(mdlPublicVars.General_CarpetaImagenes, foto.codigo & ".jpg")
                fila = {foto.codigo, ruta, "0", "Imagen " & i}
                Me.grdFotos.Rows.Add(fila)
            Next
        Catch ex As Exception
        End Try

    End Sub

    'Funcion que se utlizara para saber si todos los campos requeridos estan llenos
    Private Function fnRequeridos() As String
        'Variables que se utiliran para el control
        Dim errores As String = ""

        'Creamos el arreglo que contenera los errores
        Dim coleccion As New ArrayList
        Dim objeto As String = "Producto"

        'Verificamos que tenga nombre y codigo
        If cmbNombre1.Text = 0 Then
            coleccion.Add("Nombre de " & objeto)
        End If


        If cmbCodigo1.Text = 0 Then
            coleccion.Add("Codigo de " & objeto)
        End If

        If (cmbImportancia.Text.Length = 0) Then
            coleccion.Add("Importancia de " & objeto)
        End If

        If (cmbMarcaRepuesto.Text.Length = 0) Then
            coleccion.Add("Marca de " & objeto)
        End If

        If (cmbTipoRepuesto.Text.Length = 0) Then
            coleccion.Add("Tipo de " & objeto)
        End If

        Dim cont
        For cont = 0 To coleccion.Count - 1
            errores += "Falta " & coleccion.Item(cont) & vbCrLf
        Next


        Return errores
    End Function

    'Coloca la foto
    Private Sub fnFoto()
        Try

            'Seleccionamos la direccion
            Dim direccion As String = CType(Me.grdFotos.Rows(Me.grdFotos.CurrentRow.Index).Cells("direccion").Value, String)
            fnCargarFoto(pctFoto, direccion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdFotos_Click(sender As Object, e As EventArgs) Handles grdFotos.Click
        Try
            fnFoto()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub grdDirecciones_UserAddedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdFotos.UserAddedRow
        If grdFotos.RowCount > 0 Then
            fnFoto()
        End If
    End Sub

    Private Sub fnLlenar_Listas()
        Dim id As Integer

        If NuevoIniciar = True Then
            id = 0
        Else
            Try
                id = txtCodigo.Text
            Catch ex As Exception
                id = 0
            End Try

        End If
        'tipo de vehiculo con grid
        Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre
                 Select Agregar = If(((From y In ctx.tblArticulo_TipoVehiculo _
                            Where x.codigo = y.articuloTipoVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblArticulo_TipoVehiculo _
                            Where x.codigo = y.articuloTipoVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)



        Me.grdTipoVehiculo.Rows.Clear()
        Dim v
        For Each v In tp
            Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.iddetalle, v.CODIGO, v.NOMBRE)
        Next


        'modelo de vehiculo con grid
        Dim mv = (From x In ctx.tblArticuloModeloVehiculoes Order By x.nombre
                 Select Agregar = If(((From y In ctx.tblArticulo_ModeloVehiculo _
                            Where x.codigo = y.articuloModeloVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblArticulo_ModeloVehiculo _
                            Where x.codigo = y.articuloModeloVehiculo And y.articulo = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdModeloVehiculo.Rows.Clear()
        Dim v2
        For Each v2 In mv
            Me.grdModeloVehiculo.Rows.Add(v2.AGREGAR, v2.iddetalle, v2.CODIGO, v2.NOMBRE)
        Next

    End Sub



    'Funcion utilizada para guardar kit de un producto
    Public Sub fnGuardaKit()
        Dim codArt As Integer = CInt(txtCodigo.Text)

        'Guardamos todos los detalles de kit
        Dim elimina As Integer = 0
        Dim idDetalle As Integer = 0
        Dim idArticulo As Integer = 0
        Dim cantidad As Decimal = 0
        Dim codArticuloUnidadMedida As String
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        If elimina = 1 Then
            '-- Elimina el articulo del kit
            'Obtenemos el articulo de la lista
            Dim detalle As tblArticulo_Kit = (From x In ctx.tblArticulo_Kit Where x.codigo = idDetalle Select x).FirstOrDefault

            'Eliminamos el objeto del contexto
            ctx.DeleteObject(detalle)
            ctx.SaveChanges()
        ElseIf idDetalle > 0 Then
            '-- Modificamos el articulo del kit
            'Obtenemos el articulo para poder modificarlo
            Dim detalle As tblArticulo_Kit = (From x In ctx.tblArticulo_Kit Where x.codigo = idDetalle Select x).FirstOrDefault

            detalle.cantidad = cantidad
            detalle.idArticulo_UnidadMedida = codArticuloUnidadMedida
            ctx.SaveChanges()
        Else
            '-- Agregamos el articulo al kit

            'Creamos un nuevo objeto del tipo tblArticulo_Kit
            Dim articulo As New tblArticulo_Kit
            articulo.cantidad = cantidad
            articulo.articuloBase = codArt
            articulo.articulo = idArticulo
            articulo.fecha = fechaServer
            articulo.usuario = mdlPublicVars.idUsuario
            If codArticuloUnidadMedida > 0 Then
                articulo.idArticulo_UnidadMedida = codArticuloUnidadMedida
            End If


            ctx.AddTotblArticulo_Kit(articulo)
            ctx.SaveChanges()
        End If
    End Sub

    'Funcion utilizada para guardar sustitutos
    Public Sub fnGuardaSustitutos()
        Dim id As Integer = CType(txtCodigo.Text, Integer)

        Dim categoria = (From x In ctx.tblSustitutoes _
                       Where x.idarticulo = id And x.idempresa = mdlPublicVars.idEmpresa And x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                       And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                       Select x)

        Dim contador As Integer = 0
        Dim valor As New tblSustituto
        For Each valor In categoria
            contador = contador + 1
        Next

        If contador > 0 Then
            Dim idCategoria As Integer = CType(valor.idSustitutoCategoria, Integer)
            'Eliminamos toda la categoria de sustitutos anteriores
            Dim listaSustitutos As List(Of tblSustituto) = (From x In ctx.tblSustitutoes Where x.idSustitutoCategoria = idCategoria Select x).ToList
            Dim sust As New tblSustituto
            For Each sust In listaSustitutos
                ctx.DeleteObject(sust)
                ctx.SaveChanges()
            Next
        End If

        'Si el grid de sustitutos es mayor a cero
        If Me.grdSustitutos.RowCount > 0 Then
            Dim sustitutos As Integer = 0
            For i As Integer = 0 To Me.grdSustitutos.RowCount - 1
                If Me.grdSustitutos.Rows(i).IsVisible = True Then
                    sustitutos += 1
                End If
            Next

            If sustitutos >= 1 Then

                'Si sustitutos es mayor o igual 1, se crean los sustitutos
                'Creamos la nueva categoria de sutitutos
                Dim categoriaNueva As New tblSustitutoCategoria
                ctx.AddTotblSustitutoCategorias(categoriaNueva)
                ctx.SaveChanges()
                Dim cat As Integer = CType(categoriaNueva.idSustitutoCategoria, Integer)

                'Guardamos el articulo base
                Dim sustitutoBase As New tblSustituto
                sustitutoBase.idarticulo = id
                sustitutoBase.idSustitutoCategoria = cat
                sustitutoBase.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                sustitutoBase.idempresa = mdlPublicVars.idEmpresa
                sustitutoBase.idTipoInventario = mdlPublicVars.General_idTipoInventario
                ctx.AddTotblSustitutoes(sustitutoBase)
                ctx.SaveChanges()
                'Guardamos todos los sutitutos
                Dim elimina As Integer = 0
                For contador = 0 To Me.grdSustitutos.Rows.Count - 1
                    elimina = grdSustitutos.Rows(contador).Cells("elimina").Value

                    If elimina = 0 Then
                        Dim sustituto As New tblSustituto
                        Dim idArticulo As Integer = CType(Me.grdSustitutos.Rows(contador).Cells("id").Value, Integer)
                        sustituto.idarticulo = idArticulo
                        sustituto.idSustitutoCategoria = cat
                        sustituto.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal
                        sustituto.idempresa = mdlPublicVars.idEmpresa
                        sustituto.idTipoInventario = mdlPublicVars.General_idTipoInventario
                        ctx.AddTotblSustitutoes(sustituto)
                        ctx.SaveChanges()
                    End If
                Next
            End If
        End If
    End Sub



    Public Sub llenarGridSustitutos()
        Try
            Dim articulo As Integer = CType(txtCodigo.Text, Integer)

            Dim categoria = (From x In ctx.tblSustitutoes _
                           Where x.idarticulo = articulo And x.idempresa = mdlPublicVars.idEmpresa And x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal _
                           And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                           Select x).ToList

            Dim listaCategoria As List(Of tblSustituto) = categoria

            Dim contador As Integer = 0
            Dim valor As New tblSustituto
            For Each valor In listaCategoria
                contador = contador + 1
            Next

            If contador > 0 Then
                Dim categoriaSustituto As Integer = CType(valor.idSustitutoCategoria, Integer)
                Dim sustitutos As List(Of tblSustituto) = (From x In ctx.tblSustitutoes Join y In ctx.tblArticuloes On x.idarticulo Equals y.idArticulo _
                                Where x.idAlmacen = mdlPublicVars.General_idAlmacenPrincipal And x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                                And x.idempresa = mdlPublicVars.idEmpresa And x.idSustitutoCategoria = categoriaSustituto And x.idarticulo <> articulo _
                                Select x).ToList
                Dim arti As New tblSustituto
                For Each arti In sustitutos
                    Dim fila As String()
                    fila = {arti.idSustituto, arti.idarticulo, arti.tblArticulo.codigo1, arti.tblArticulo.codigo2, arti.tblArticulo.nombre1, arti.tblArticulo.nombre2, "0", arti.tblArticulo.tblArticuloMarcaRepuesto.nombre}
                    Me.grdSustitutos.Rows.Add(fila)
                Next

            Else
                Me.grdSustitutos.DataSource = Nothing

            End If

        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para llenar el grid con los detalles de kit
    Private Sub fnLlenarGridKit()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codigoArt As Integer = CInt(txtCodigo.Text)
            Dim lDetalleKit As List(Of tblArticulo_Kit) = (From x In conexion.tblArticulo_Kit Where x.articuloBase = codigoArt Select x).ToList
            Dim idArticuloUnidadMedida As Integer
            Dim unidadmedida As String
            Dim unidadesmedida As Decimal

            For Each detalle As tblArticulo_Kit In lDetalleKit
                Dim fila As String()

                If IsNothing(detalle.idArticulo_UnidadMedida) Then
                    idArticuloUnidadMedida = Nothing
                    unidadmedida = "Unidad"
                    unidadesmedida = 1.0
                Else
                    idArticuloUnidadMedida = detalle.idArticulo_UnidadMedida
                    unidadmedida = detalle.tblArticulo_UnidadMedida.tblUnidadMedida.nombre
                    unidadesmedida = detalle.tblArticulo_UnidadMedida.valor
                End If


                ''iddetalle,id,codigo1,nombre1,nombre2,elimina,marca,cantidad
                'fila = {detalle.codigo, detalle.tblArticulo1.idArticulo, detalle.tblArticulo1.codigo1, detalle.tblArticulo1.nombre1,
                '"0", detalle.tblArticulo1.tblArticuloMarcaRepuesto.nombre, Format(detalle.cantidad, mdlPublicVars.formatoNumero), Format(detalle.tblArticulo1.costoIVA * unidadesmedida, mdlPublicVars.formatoNumero), idArticuloUnidadMedida, unidadmedida, Format(unidadesmedida, mdlPublicVars.formatoNumero)}
                'Me.grdKit.Rows.Add(fila)

            Next

            conn.Close()
        End Using

    End Sub

    Public Sub llenarGridInventarios()
        Dim id As Integer = txtCodigo.Text
        Try
            Dim inventario As List(Of tblTipoInventario) = (From x In ctx.tblTipoInventarios Select x).ToList

            Dim tipo As New tblTipoInventario
            For Each tipo In inventario
                Dim saldo As tblInventario = (From x In ctx.tblInventarios Where x.idTipoInventario = tipo.idTipoinventario And x.tblArticulo.empresa = mdlPublicVars.idEmpresa _
                             And x.IdAlmacen = General_idAlmacenPrincipal And x.idArticulo = id Select x).FirstOrDefault

                Dim saldoInventario As Integer
                If saldo Is Nothing Then
                    saldoInventario = 0
                Else
                    saldoInventario = saldo.saldo
                End If
                Dim fila As String()
                fila = {tipo.idTipoinventario, tipo.nombre, saldoInventario}
            Next

        Catch ex As Exception

        End Try


    End Sub



    Public Sub fnPendienteSurtir()
        Dim codigo As Integer = txtCodigo.Text
        Dim pendiente = (From x In ctx.tblSurtirs Where x.articulo = codigo And x.saldo > 0 _
                                      Select x.cantidad).Sum
        Dim surtir As Integer
        If pendiente Is Nothing Then
            surtir = 0
        Else
            surtir = pendiente
        End If
    End Sub

    'Funcion que verifica si el codigo del producto no existe aun
    Private Function fnVerificaCodigo(ByVal codigo As String) As Boolean
        Try
            'Realizamos la consulta
            Dim consulta As tblArticulo = (From x In ctx.tblArticuloes Where x.codigo1 = codigo And x.empresa = mdlPublicVars.idEmpresa Select x).FirstOrDefault

            If consulta Is Nothing Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    Private Sub grdModeloVehiculo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdModeloVehiculo.ValueChanged
        fngrd_contador(grdModeloVehiculo, lblRecuentoModelo)
    End Sub

    Private Sub grdDirecciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFotos.SelectionChanged
        Try
            fnFoto()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label)

        Try
            Dim indice As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grd)
            cmbNombre1.Focus()
            cmbNombre1.Select()

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

            grd.Focus()
            'grd.Rows(indice).Cells(0).IsSelected = True
            'End If
        Catch ex As Exception
            alertas.contenido = ex.ToString
            alertas.fnErrorContenido()
        End Try

    End Sub

    Private Sub chkKit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKit.CheckedChanged
        If chkKit.Checked Then
            chkServicio.Checked = False
            chkProducto.Checked = False
            chkUnidadMedida.Checked = False
        End If
    End Sub


    ''LA VALIDACION DE SI ES UNIDAD DE MEDIDA O NO
    Private Sub chkUnidadMedida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnidadMedida.CheckedChanged
        If chkUnidadMedida.Checked Then
            chkServicio.Checked = False
            chkKit.Checked = False
            chkProducto.Checked = False
        End If
    End Sub

    Private Sub chkProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProducto.CheckedChanged
        If chkProducto.Checked Then
            chkServicio.Checked = False
            chkUnidadMedida.Checked = False
            chkKit.Checked = False
        End If
    End Sub

    Private Sub chkServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkServicio.CheckedChanged
        If chkServicio.Checked Then
            chkKit.Checked = False
            chkProducto.Checked = False
            chkUnidadMedida.Checked = False
        End If
    End Sub


    'Despliega Combo
    Private Sub cmbTipoRepuesto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTipoRepuesto.KeyDown
        If e.KeyCode = Keys.F2 Then
            cmbTipoRepuesto.AllowDrop = True
            cmbTipoRepuesto.DroppedDown = True
        End If
    End Sub

    'Funcion utilizada para activar todos los elementos de un grid
    Private Sub fnActivaTodos(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal estado As Boolean)
        Try
            'Recorremos el grid
            Dim i
            For i = 0 To grd.Rows.Count - 1
                grd.Rows(i).Cells(0).Value = estado
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chkTodosVehiculo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosVehiculo.CheckedChanged
        fnActivaTodos(grdTipoVehiculo, chkTodosVehiculo.Checked)
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        fnActivaTodos(grdModeloVehiculo, chkTodosModelo.Checked)
        fngrd_contador(grdModeloVehiculo, lblRecuentoModelo)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If mdlPublicVars.superSearchFilasGrid > 0 Then
            Dim idArticulo As Integer = mdlPublicVars.superSearchId
            frmProductoKardex.Text = "Kardex"
            frmProductoKardex.StartPosition = FormStartPosition.CenterScreen
            frmProductoKardex.articulo = idArticulo
            permiso.PermisoDialogEspeciales(frmProductoKardex)
            frmProductoKardex.Dispose()
        End If
    End Sub

    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim id As Integer = Me.cmbNombre1.SelectedValue

                Dim a As tblArticulo = (From x In conexion.tblArticuloes Where x.idArticulo = id Select x).FirstOrDefault

                a.codigo2 = Me.txtCodigoM2.Text
                a.nombre1 = Me.txtProductoM1.Text
                a.nombre2 = Me.txtProductoM2.Text
                a.Observacion = Me.txtObs.Text

                conexion.SaveChanges()
                Call llenagrid()

                conn.Close()
            End Using


        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnPrecioC()
        Try

            Dim filad, filaa, filab, filac As Integer

            For i As Integer = 0 To Me.grdPrecios.Rows.Count - 1
                If Me.grdPrecios.Rows(i).Cells("tipoNegocio").Value = "Distribuidor (A)" Then
                    filad = i
                End If
            Next

            For i As Integer = 0 To Me.grdOtrosPrecios.Rows.Count - 1
                If Me.grdOtrosPrecios.Rows(i).Cells("tipoPrecio").Value = "Precio A" Then
                    filaa = i
                ElseIf Me.grdOtrosPrecios.Rows(i).Cells("tipoPrecio").Value = "Precio B" Then
                    filab = i
                ElseIf Me.grdOtrosPrecios.Rows(i).Cells("tipoPrecio").Value = "Precio C" Then
                    filac = i
                End If
            Next

            Dim precioD, PrecioA, PrecioB, PrecioC As Decimal

            precioD = Me.grdPrecios.Rows(filad).Cells("precionormal").Value

            If Me.grdOtrosPrecios.Rows(filaa).Cells("chmActiva").Value = True Then
                PrecioA = Me.grdOtrosPrecios.Rows(filaa).Cells("txmPrecio").Value
            Else
                PrecioA = 0
            End If
            If Me.grdOtrosPrecios.Rows(filab).Cells("chmActiva").Value = True Then
                PrecioB = Me.grdOtrosPrecios.Rows(filab).Cells("txmPrecio").Value
            Else
                PrecioB = 0
            End If

            Dim acum As Decimal = 0
            Dim nm As Decimal = 0
            ''Dim lista As Decimal() ''= {precioD, PrecioA, PrecioB}
            Dim lista As New List(Of Decimal)

            If precioD <> 0 Then
                lista.Add(precioD)
            End If
            If PrecioB <> 0 Then
                lista.Add(PrecioB)
            End If
            If PrecioA <> 0 Then
                lista.Add(PrecioA)
            End If

            For Each a As Object In lista
                ''If a <> 0 Then
                If acum = 0 Then
                    acum = nm
                End If
                nm = Convert.ToDecimal(a)
                If nm < acum Then
                    acum = nm
                End If
                ''End If
            Next

            If acum <> 0 Then
                PrecioC = acum
            Else
                PrecioC = nm
            End If

            Me.grdOtrosPrecios.Rows(filac).Cells("txmPrecio").Value = PrecioC + (PrecioC * 0.2)

        Catch ex As Exception

        End Try
    End Sub
End Class
