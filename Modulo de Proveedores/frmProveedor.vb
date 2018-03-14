Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmProveedor

    Private _proveedorlocal As Boolean

    Public Property proveedorlocal As Boolean
        Get
            proveedorlocal = _proveedorlocal
        End Get
        Set(ByVal value As Boolean)
            _proveedorlocal = value
        End Set
    End Property


    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frmProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdMarcaRepuesto)
        mdlPublicVars.fnFormatoGridEspeciales(grdTipoRepuesto)
        mdlPublicVars.fnFormatoGridEspeciales(grdTipoVehiculo)
        mdlPublicVars.fnFormatoGridEspeciales(grdCuentas)
        ''mdlPublicVars.fnFormatoGridEspeciales(grdFlete)
        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automatico
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        Me.errores.Controls.Add(Me.txtNegocio, "Nombre")
        Me.errores.SummaryMessage = "Faltan datos"
        llenarCombos()
        llenagrid()
        llenadatos()

        mdlPublicVars.fnSeleccionarDefault(grdDatos, codigoDefault, seleccionDefault)

        If NuevoIniciar = True Then
            Call limpiaCampos()
            fnLlenar_Listas()
            txtNegocio.Focus()
            pnx1Modificar.Visible = False
            pnx0Guardar.Visible = True
            Me.grdCuentas.Columns("elimina").IsVisible = False
            ''Me.grdFlete.Columns("elimina").IsVisible = False
        End If
        fnFuncionesExtra()
        lblCombo1.Text = mdlPublicVars.ProductoCombo1
        lblCombo2.Text = mdlPublicVars.ProductoCombo2
        lblGrid1.Text = mdlPublicVars.ProductoGrid1

        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
        fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto)
        fngrd_contador(grdMarcaRepuesto, lblRecuentoMarcaRepuesto)
    End Sub

    Private Sub fnFuncionesExtra()
        Try

            If proveedorlocal = True Then
                Me.pgTransferencias.Enabled = False
            Else
                Me.cmbClasificacion.Enabled = False
                Me.cmbProcedencia.Enabled = False

                Me.txtMontoPresupuesto.Enabled = False
                Me.txtFechaPagoProgramado.Enabled = False
                Me.txtFechaCortePresupuestado.Enabled = False
                Me.txtFechaProgramado.Enabled = False
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenadatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim provee As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codigoDefault Select x).FirstOrDefault

                Me.txtDireccion.Text = provee.direccion
                Me.txtTelefono.Text = provee.telefono
                Me.txtCorreo1.Text = provee.correo1
                Me.txtNombreContacto.Text = provee.contacto
                Me.txtTelefonoContacto.Text = provee.telefonoContacto
                Me.txtCorreo2.Text = provee.correo2
                Me.txtNumeroReferencia.Text = provee.NumeroReferencia
                Me.txtMontoPresupuesto.Text = If(provee.montotp Is Nothing, 0, provee.montotp)
                Me.txtFechaCortePresupuestado.Text = If(provee.FechaCorte Is Nothing, "", provee.FechaCorte)
                Me.txtFechaPagoProgramado.Text = If(provee.FechaPago Is Nothing, "", provee.FechaPago)
                Me.cmbProcedencia.SelectedValue = provee.procedencia
                Me.cmbClasificacion.SelectedValue = provee.idClasificacionNegocio

                If verRegistro = True Then
                    Me.txtDireccion.Enabled = False
                    Me.txtTelefono.Enabled = False
                    Me.txtCorreo1.Enabled = False
                    Me.txtNombreContacto.Enabled = False
                    Me.txtTelefonoContacto.Enabled = False
                    Me.txtCorreo2.Enabled = False
                    Me.cmbProcedencia.Enabled = False
                    Me.cmbClasificacion.Enabled = False
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarCombos()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)



            Dim banco = From x In conexion.tblBancoes Select Codigo = x.idbanco, Nombre = x.nombre

            With cmbBanco
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = banco
            End With

            Dim procedencia = From x In conexion.tblProveedorProcedencias Where x.bitlocal = True Select Codigo = x.codigo, Nombre = x.nombre

            With cmbProcedencia
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = procedencia
            End With

            Dim flete = From x In conexion.tblProveedorTipoFletes Select Codigo = x.codigo, Nombre = x.nombre

            ''With Me.cmbFlete
            ''    .DataSource = Nothing
            ''    .ValueMember = "Codigo"
            ''    .DisplayMember = "Nombre"
            ''    .DataSource = flete
            ''End With

            Dim tipoPago = From x In conexion.tblProveedorTipoPagoes Select Codigo = x.codigo, Nombre = x.nombre

            With Me.cmbTipoPago
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tipoPago
            End With

            ''Contabilidad Combos

            Dim partida = (From x In conexion.tblPartidas Select Codigo = x.idpartida, Nombre = x.descripcion)

            With Me.cmbTipoCuenta
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = partida
            End With

            Dim departamento = (From x In conexion.tblDepartamentoEmpresas Select Codigo = x.iddepartamento, Nombre = x.descripcioin)

            With cmbDepartamento
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = departamento
            End With

            Dim pago = (From x In conexion.tblTipoPagoGastos Select codigo = x.idtipopago, nombre = x.descripcion)

            With cmbClasificacionPago
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = pago
            End With

            Dim gasto = (From x In conexion.tblTipoGastoes Select codigo = x.idtipogasto, nombre = x.descripcion)

            With cmbTipoGasto
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = gasto
            End With

            Dim tipocompra = (From x In conexion.tblTipoCompras Select codigo = x.idtipocompra, nombre = x.descripcion)

            With cmbTipoCompra
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = tipocompra
            End With

            ''Fin contabilidad Bancos

            Dim clasificacion = From x In conexion.tblProveedorClasificacionNegocios Select Codigo = x.idProveedorClasificacionNegocio, Nombre = x.nombre

            With Me.cmbClasificacion
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = clasificacion
            End With

            conn.Close()
        End Using
    End Sub

    'Funcion para modificar un proveedor
    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Dim codigo As Integer = CType(txtCodigo.Text, Integer)
        Dim success As Boolean = True

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim m As tblProveedor = (From x In conexion.tblProveedors Where x.idProveedor = codigo Select x).FirstOrDefault
            Using transaction As New TransactionScope

                Try
                    m.habilitado = chkHabilitado.Checked
                    m.negocio = txtNegocio.Text
                    m.direccion = txtDireccion.Text
                    m.telefono = txtTelefono.Text
                    m.contacto = txtNombreContacto.Text
                    m.telefonoContacto = txtTelefonoContacto.Text
                    m.correo1 = txtCorreo1.Text
                    m.correo2 = txtCorreo2.Text
                    ''m.codigoVenta = txtNombreCheque.Text
                    m.procedencia = CType(cmbProcedencia.SelectedValue, Integer)
                    m.clave = txtClave.Text
                    m.diasCredito = nm0DiasCredito.Value
                    m.montoCredito = nm2MontoCredito.Value
                    m.idClasificacionNegocio = CInt(cmbClasificacion.SelectedValue)
                    m.NumeroReferencia = Me.txtNumeroReferencia.Text
                    m.FechaCorte = Me.txtFechaCortePresupuestado.Text
                    m.FechaPago = Me.txtFechaPagoProgramado.Text

                    'Guardamos el tipo de pago
                    Dim cPago As Integer = CInt(cmbTipoPago.SelectedValue)
                    Dim tPago As tblProveedorTipoPago = (From x In conexion.tblProveedorTipoPagoes Where x.codigo = cPago _
                                                         Select x).FirstOrDefault
                    m.tipoPago = cPago
                    If tPago.credito = True Then
                        m.diasCredito = nm0DiasCredito.Value
                        m.montoCredito = nm2MontoCredito.Value
                    End If

                    conexion.SaveChanges()



                    Dim t As tblProveedorTransferencia = (From x In conexion.tblProveedorTransferencias Where x.Idproveedor = codigo Select x).FirstOrDefault

                    If t Is Nothing Then

                    Else
                        t.Tipomoneda = Me.txtTipoMoneda.Text
                        t.Empresa = Me.txtEmpresa.Text
                        t.Direccion = Me.txtDireccionT.Text
                        t.Paismoneda = Me.txtPaisT.Text
                        t.Telefono = Me.txtTelefonoT.Text
                        t.Numerocuentamoneda = Me.txtNoCuenta.Text

                        t.TipoCodigoReceptor = Me.txtTipoCodigoR.Text
                        t.CodigoSwift = Me.txtCodigoSwift.Text
                        t.Nombrereceptor = Me.txtNombreR.Text
                        t.Ciudadreceptor = Me.txtCiudadR.Text
                        t.Paisreceptor = Me.txtPaisR.Text

                        t.TipoCodigoIntermediario = Me.txtTipoCodigoI.Text
                        t.Codigointermediario = Me.txtCodigoI.Text
                        t.Nombreintermediario = Me.txtNombreI.Text
                        t.Numerocuentaintermediario = Me.txtNoCuentaI.Text
                        t.Ciudadintermediario = Me.txtCiudadI.Text
                        t.Paisintermediario = Me.txtPaisI.Text

                        conexion.SaveChanges()

                    End If
                   
                    Dim index
                    Dim estado As Boolean = False
                    Dim cod As Integer
                    Dim i As Integer
                    Dim id As Integer
                    Dim grd As Telerik.WinControls.UI.RadGridView

                    '------------------MODIFICAR---------------

                    'AGREGAR TIPO DE VEHICULO.
                    grd = Me.grdTipoVehiculo
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells(0).Value
                        cod = grd.Rows(i).Cells(2).Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblProveedor_TipoVehiculo
                                tv.proveedor = m.idProveedor
                                tv.tipoVehiculo = cod
                                conexion.AddTotblProveedor_TipoVehiculo(tv)
                                conexion.SaveChanges()
                            End If
                        Else ' si estado = falso

                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells(1).Value
                                Dim tv As tblProveedor_TipoVehiculo = (From x In conexion.tblProveedor_TipoVehiculo Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    conexion.DeleteObject(tv)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    'AGREGAR TIPO REPUESTO
                    grd = Me.grdTipoRepuesto
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells(0).Value
                        cod = grd.Rows(i).Cells(2).Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblProveedor_Repuesto
                                tv.proveedor = m.idProveedor
                                tv.Repuesto = cod
                                conexion.AddTotblProveedor_Repuesto(tv)
                                conexion.SaveChanges()
                            End If
                        Else ' si estado = falso

                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells(1).Value
                                Dim tv As tblProveedor_Repuesto = (From x In conexion.tblProveedor_Repuesto Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    conexion.DeleteObject(tv)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    'AGREGAR MARCA REPUESTO
                    grd = Me.grdMarcaRepuesto
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells(0).Value
                        cod = grd.Rows(i).Cells(2).Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblProveedor_marca
                                tv.proveedor = m.idProveedor
                                tv.marcaRepuesto = cod
                                conexion.AddTotblProveedor_marca(tv)
                                conexion.SaveChanges()
                            End If
                        Else ' si estado = falso

                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells(1).Value
                                Dim tv As tblProveedor_marca = (From x In conexion.tblProveedor_marca Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    conexion.DeleteObject(tv)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    '------------------------------------------

                    'Agregamos las cuentas de los proveedores
                    For index = 0 To Me.grdCuentas.Rows.Count - 1

                        Dim idCuenta As Integer = CType(Me.grdCuentas.Rows(index).Cells(0).Value, Integer)

                        If idCuenta > 0 Then
                        Else
                            Dim cuentaProveedor As New tblProveedor_cuenta
                            Dim cuenta As String = CType(grdCuentas.Rows(index).Cells(1).Value, String)
                            Dim banco As Integer = CType(Me.grdCuentas.Rows(index).Cells(3).Value, Integer)


                            cuentaProveedor.proveedor = m.idProveedor
                            cuentaProveedor.noCuenta = cuenta
                            cuentaProveedor.banco = banco
                            conexion.AddTotblProveedor_cuenta(cuentaProveedor)
                            conexion.SaveChanges()
                        End If

                        If Me.grdCuentas.Rows(index).Cells(5).Value = True Then
                            Dim cuentaProveedor As tblProveedor_cuenta = (From x In conexion.tblProveedor_cuenta Where x.proveedor = m.idProveedor Select x).FirstOrDefault
                            conexion.DeleteObject(cuentaProveedor)
                            conexion.SaveChanges()
                        End If
                    Next

                    ' ''Agregamos los fletes de los proveedores
                    ''For index = 0 To Me.grdFlete.Rows.Count - 1
                    ''    Dim idCuenta As Integer = CType(Me.grdFlete.Rows(index).Cells(0).Value, Integer)
                    ''    Dim elimina As Boolean = CType(Me.grdFlete.Rows(index).Cells(3).Value, Boolean)
                    ''    If idCuenta > 0 Then
                    ''    Else
                    ''        Dim fleteProveedor As New tblProveedor_TipoFlete
                    ''        Dim cuenta As String = CType(grdFlete.Rows(index).Cells(1).Value, String)
                    ''        Dim flete As Integer = CType(Me.grdFlete.Rows(index).Cells(2).Value, Integer)

                    ''        fleteProveedor.proveedor = m.idProveedor
                    ''        fleteProveedor.tipoFlete = flete
                    ''        conexion.AddTotblProveedor_TipoFlete(fleteProveedor)
                    ''        conexion.SaveChanges()
                    ''    End If

                    ''    If elimina = True Then
                    ''        Dim fleteProveedor As tblProveedor_TipoFlete = (From x In conexion.tblProveedor_TipoFlete Where x.proveedor = m.idProveedor Select x).FirstOrDefault
                    ''        conexion.DeleteObject(fleteProveedor)
                    ''        conexion.SaveChanges()
                    ''    End If
                    ''Next

                    conexion.SaveChanges()
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

            conn.Close()
        End Using

        If success = True Then
            conexion.AcceptAllChanges()
            alertas.fnGuardar()
            llenagrid()
        Else
            alertas.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    Private Sub llenagrid()

        Try
            Dim proveedor = From x In ctx.tblProveedors Where x.idProveedor > 0 _
                              Select Codigo = x.idProveedor, Negocio = x.negocio, Direccion = x.direccion, Telefono = x.telefono, Correo1 = x.correo1, _
                              NombreContacto = x.contacto, TelefonoContacto = x.telefonoContacto, Correo2 = x.correo2, _
                              CodigoVenta = x.codigoVenta, Procedencia = x.tblProveedorProcedencia.nombre, DiasCredito = x.diasCredito, MontoCredito = x.montoCredito, _
                              UltimaCompra = x.ultimaCompra, SaldoActual = x.saldoActual, SaldoTransito = x.saldoTransito, chkHabilitado = x.habilitado, _
                              TipoPago = x.tblProveedorTipoPago.nombre, Clave = x.clave, Clasificacion = x.tblProveedorClasificacionNegocio.nombre

            Me.grdDatos.DataSource = proveedor
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    'Funcion utilizada para llenar los grid's
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
        Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre _
                 Select Agregar = If(((From y In ctx.tblProveedor_TipoVehiculo _
                            Where x.codigo = y.tipoVehiculo And y.proveedor = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblProveedor_TipoVehiculo _
                            Where x.codigo = y.tipoVehiculo And y.proveedor = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoVehiculo.Rows.Clear()
        Dim v
        For Each v In tp
            Me.grdTipoVehiculo.Rows.Add(v.AGREGAR, v.iddetalle, v.CODIGO, v.NOMBRE)
        Next


        'modelo de vehiculo con grid
        Dim mv = (From x In ctx.tblArticuloRepuestoes Order By x.nombre
                 Select Agregar = If(((From y In ctx.tblProveedor_Repuesto _
                            Where x.codigo = y.Repuesto And y.proveedor = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblProveedor_Repuesto _
                            Where x.codigo = y.Repuesto And y.proveedor = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdTipoRepuesto.Rows.Clear()
        Dim v2
        For Each v2 In mv
            Me.grdTipoRepuesto.Rows.Add(v2.AGREGAR, v2.iddetalle, v2.CODIGO, v2.NOMBRE)
        Next



        'modelo de vehiculo con grid
        Dim marcav = (From x In ctx.tblArticuloMarcaRepuestoes Order By x.nombre
                 Select Agregar = If(((From y In ctx.tblProveedor_marca _
                            Where x.codigo = y.marcaRepuesto And y.proveedor = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = ((From y In ctx.tblProveedor_marca _
                            Where x.codigo = y.marcaRepuesto And y.proveedor = id _
                            Select y.codigo).FirstOrDefault),
                           Codigo = x.codigo, Nombre = x.nombre)



        Me.grdMarcaRepuesto.Rows.Clear()
        Dim v3
        For Each v3 In marcav
            Me.grdMarcaRepuesto.Rows.Add(v3.AGREGAR, v3.iddetalle, v3.CODIGO, v3.NOMBRE)
        Next
    End Sub

    Private Sub frm_focoDatos() Handles Me.focoDatos
        txtNegocio.Focus()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        fnLlenar_Listas()
        txtNegocio.Focus()
        rpv.SelectedPage = pageDatos
    End Sub


    Private Sub frm_txtcodigo() Handles txtCodigo.TextChanged
        'llenar clasificacion de compra del cliente.
        If NuevoIniciar = False Then
            Try
                Dim id As Integer = txtCodigo.Text
                Dim nombre As String = ""
                Dim contador As Integer = 0

                fnLlenar_Listas()

                'Llenamos el grid de cuentas
                llenarGridCuentas()

                'Llenamos el grid de fletes
                llenarGridFletes()

            Catch ex As Exception

            End Try
        Else

        End If

    End Sub

    Private Sub llenarGridCuentas()
        Dim id As Integer = CType(txtCodigo.Text, Integer)
        Me.grdCuentas.Rows.Clear()

        Try
            Dim consulta As List(Of tblProveedor_cuenta) = (From x In ctx.tblProveedor_cuenta Where x.proveedor = id Select x).ToList
            Dim cuenta As New tblProveedor_cuenta

            For Each cuenta In consulta
                Dim fila As String()
                fila = {cuenta.codigo, cuenta.nombrecuenta, cuenta.noCuenta, cuenta.tblBanco.nombre, cuenta.tblBanco.idbanco}
                Me.grdCuentas.Rows.Add(fila)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarGridFletes()
        Dim id As Integer = CType(txtCodigo.Text, Integer)
        ''Me.grdFlete.Rows.Clear()

        Try
            Dim consulta As List(Of tblProveedor_TipoFlete) = (From x In ctx.tblProveedor_TipoFlete Where x.proveedor = id Select x).ToList
            Dim flete As New tblProveedor_TipoFlete

            For Each flete In consulta
                Dim fila As String()
                fila = {flete.codigo, flete.tblProveedorTipoFlete.nombre, flete.tblProveedorTipoFlete.codigo}
                '' Me.grdFlete.Rows.Add(fila)
            Next

        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para guardar un nuevo registro
    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim m As New tblProveedor
        Dim success As Boolean = True

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Using transaction As New TransactionScope
                Try
                    m.habilitado = True
                    m.negocio = txtNegocio.Text
                    m.direccion = txtDireccion.Text
                    m.telefono = txtTelefono.Text
                    m.contacto = txtNombreContacto.Text
                    m.telefonoContacto = txtTelefonoContacto.Text
                    m.correo1 = txtCorreo1.Text
                    m.correo2 = txtCorreo2.Text
                    ''m.codigoVenta = txtNombreCheque.Text
                    m.procedencia = CType(cmbProcedencia.SelectedValue, Integer)
                    m.clave = txtClave.Text
                    m.diasCredito = nm0DiasCredito.Value
                    m.montoCredito = nm2MontoCredito.Value
                    m.empresa = mdlPublicVars.idEmpresa
                    m.saldoActual = 0
                    m.saldoTransito = 0
                    m.pagos = 0
                    m.pagosTransito = 0
                    m.saldoDolar = 0
                    m.pagosDolar = 0
                    m.pagosTransitoDolar = 0
                    m.idClasificacionNegocio = CInt(cmbClasificacion.SelectedValue)
                    m.NumeroReferencia = Me.txtNumeroReferencia.Text
                    m.FechaPago = Me.txtFechaPagoProgramado.Text
                    m.FechaCorte = Me.txtFechaCortePresupuestado.Text

                    If Me.txtMontoPresupuesto.Text = "" Then
                        m.montotp = 0
                    Else
                        m.montotp = Me.txtMontoPresupuesto.Text
                    End If




                    'Guardamos el tipo de pago
                    Dim cPago As Integer = CInt(cmbTipoPago.SelectedValue)
                    Dim tPago As tblProveedorTipoPago = (From x In conexion.tblProveedorTipoPagoes Where x.codigo = cPago _
                                                         Select x).FirstOrDefault
                    m.tipoPago = cPago
                    If tPago.credito = True Then
                        m.diasCredito = nm0DiasCredito.Text
                        m.montoCredito = CType(nm2MontoCredito.Text, Double)

                    End If

                    m.habilitado = True
                    conexion.AddTotblProveedors(m)
                    conexion.SaveChanges()

                    ''Informacion de Transferencias
                    Dim t As New tblProveedorTransferencia

                    t.Idproveedor = m.idProveedor

                    t.Tipomoneda = Me.txtTipoMoneda.Text
                    t.Empresa = Me.txtEmpresa.Text
                    t.Direccion = Me.txtDireccionT.Text
                    t.Paismoneda = Me.txtPaisT.Text
                    t.Telefono = Me.txtTelefonoT.Text
                    t.Numerocuentamoneda = Me.txtNoCuenta.Text

                    t.TipoCodigoReceptor = Me.txtTipoCodigoR.Text
                    t.CodigoSwift = Me.txtCodigoSwift.Text
                    t.Nombrereceptor = Me.txtNombreR.Text
                    t.Ciudadreceptor = Me.txtCiudadR.Text
                    t.Paisreceptor = Me.txtPaisR.Text

                    t.TipoCodigoIntermediario = Me.txtTipoCodigoI.Text
                    t.Codigointermediario = Me.txtCodigoI.Text
                    t.Nombreintermediario = Me.txtNombreI.Text
                    t.Numerocuentaintermediario = Me.txtNoCuentaI.Text
                    t.Ciudadintermediario = Me.txtCiudadI.Text
                    t.Paisintermediario = Me.txtPaisI.Text

                    conexion.AddTotblProveedorTransferencias(t)
                    conexion.SaveChanges()
                    ''Informacion de Transferencias

                    'agregar las tipos de vehiculo
                    Dim index
                    Dim i
                    Dim valor
                    Dim cod As Integer
                    For i = 0 To Me.grdTipoVehiculo.Rows.Count - 1
                        valor = Me.grdTipoVehiculo.Rows(i).Cells(0).Value

                        If valor = True Then 'agregar el tipo de vehiculo
                            cod = CType(Me.grdTipoVehiculo.Rows(i).Cells(2).Value, Integer)
                            Dim tv As New tblProveedor_TipoVehiculo
                            tv.proveedor = m.idProveedor
                            tv.tipoVehiculo = cod
                            conexion.AddTotblProveedor_TipoVehiculo(tv)
                            conexion.SaveChanges()
                        End If
                    Next

                    'marca de vehiculo
                    For i = 0 To Me.grdTipoRepuesto.Rows.Count - 1
                        valor = Me.grdTipoRepuesto.Rows(i).Cells(0).Value

                        If valor = True Then 'agregar el tipo de vehiculo
                            cod = CType(Me.grdTipoRepuesto.Rows(i).Cells(2).Value, Integer)
                            Dim tv As New tblProveedor_Repuesto
                            tv.proveedor = m.idProveedor
                            tv.Repuesto = cod
                            conexion.AddTotblProveedor_Repuesto(tv)
                            conexion.SaveChanges()
                        End If
                    Next

                    'modelo de vehiculo
                    For i = 0 To Me.grdMarcaRepuesto.Rows.Count - 1
                        valor = Me.grdMarcaRepuesto.Rows(i).Cells(0).Value

                        If valor = True Then 'agregar el tipo de vehiculo
                            cod = CType(Me.grdMarcaRepuesto.Rows(i).Cells(2).Value, Integer)
                            Dim tv As New tblProveedor_marca
                            tv.proveedor = m.idProveedor
                            tv.marcaRepuesto = cod
                            conexion.AddTotblProveedor_marca(tv)
                            conexion.SaveChanges()
                        End If
                    Next

                    'Agregamos las cuentas de los proveedores
                    For index = 0 To Me.grdCuentas.Rows.Count - 1
                        Dim cuentaProveedor As New tblProveedor_cuenta
                        Dim cuenta As String = CType(grdCuentas.Rows(index).Cells(2).Value, String)
                        Dim banco As Integer = CType(Me.grdCuentas.Rows(index).Cells(4).Value, Integer)
                        Dim nombrecuenta As String = CType(grdCuentas.Rows(index).Cells(1).Value, String)

                        cuentaProveedor.proveedor = m.idProveedor
                        cuentaProveedor.noCuenta = cuenta
                        cuentaProveedor.banco = banco
                        cuentaProveedor.nombrecuenta = nombrecuenta
                        conexion.AddTotblProveedor_cuenta(cuentaProveedor)
                        conexion.SaveChanges()
                    Next

                    'Agregamos los fletes de los proveedores
                    ''For index = 0 To Me.grdFlete.Rows.Count - 1
                    ''    Dim fleteProveedor As New tblProveedor_TipoFlete
                    ''    Dim flete As Integer = CType(Me.grdFlete.Rows(index).Cells(2).Value, Integer)

                    ''    fleteProveedor.proveedor = m.idProveedor
                    ''    fleteProveedor.tipoFlete = flete
                    ''    conexion.AddTotblProveedor_TipoFlete(fleteProveedor)
                    ''    conexion.SaveChanges()
                    ''Next

                    conexion.SaveChanges()
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
                alertas.fnGuardar()
                If RadMessageBox.Show("Desea agregar otro proveedor", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    frm_nuevoRegistro()
                Else
                    Me.Close()
                End If
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            conn.Close()
        End Using
    End Sub

    Private Sub btnAgregarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    ''Private Sub btnAgregarFlete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    'Agregamos el flete a el grid de fletes
    ''    Dim fila As String()
    ''    fila = {"0", cmbFlete.Text, cmbFlete.SelectedValue}
    ''    Me.grdFlete.Rows.Add(fila)
    ''End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If RadMessageBox.Show("¿Esta seguro de eliminar este registro?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Try
            Dim m As tblProveedor = (From e1 In ctx.tblProveedors Where e1.idProveedor = Me.txtCodigo.Text Select e1).First()
            m.habilitado = False
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub grdCuentas_CellValueChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs)
        If Me.grdCuentas.Columns(4).IsCurrent = True Then
            Me.grdCuentas.Columns(2).IsCurrent = True
            Me.grdCuentas.Columns(4).IsCurrent = True
        End If
    End Sub

    Private Sub grdCuentas_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Me.grdCuentas.Columns(4).IsCurrent = True Then
            Me.grdCuentas.Columns(2).IsCurrent = True
            Me.grdCuentas.Columns(4).IsCurrent = True
        End If
    End Sub

    Private Sub grdCuentas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.grdCuentas.Columns(4).IsCurrent = True Then
            Me.grdCuentas.Columns(2).IsCurrent = True
            Me.grdCuentas.Columns(4).IsCurrent = True
        End If
    End Sub

    ''Private Sub grdFlete_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Try
    ''        Dim fila As Integer = Me.grdFlete.CurrentRow.Index
    ''        Dim col As Integer = Me.grdFlete.CurrentColumn.Index

    ''        txtCodigo.Focus()
    ''        txtCodigo.Select()
    ''        Me.grdFlete.Rows(fila).IsCurrent = True
    ''        Me.grdFlete.Columns(fila).IsCurrent = True
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    ''Private Sub grdFlete_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''    If Me.grdFlete.Columns(3).IsCurrent = True Then
    ''        Me.grdFlete.Columns(2).IsCurrent = True
    ''        Me.grdFlete.Columns(3).IsCurrent = True
    ''    End If
    ''End Sub

    ''Private Sub grdFlete_CellValueChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs)
    ''    If Me.grdFlete.Columns(3).IsCurrent = True Then
    ''        Me.grdFlete.Columns(2).IsCurrent = True
    ''        Me.grdFlete.Columns(3).IsCurrent = True
    ''    End If
    ''End Sub

    'Funcion utilizada para actualizar el recuento de elementos seleccionados
    Private Sub fngrd_contador(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal lbl As Label)
        Try
            Dim indice As Integer = grd.CurrentRow.Index
            txtCodigo.Focus()
            txtCodigo.Select()

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
            grd.Rows(indice).Cells(0).IsSelected = True
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdTipoVehiculo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoVehiculo.ValueChanged
        fngrd_contador(grdTipoVehiculo, lblRecuentoTipoVehiculo)
    End Sub


    Private Sub grdTipoRepuesto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdTipoRepuesto.ValueChanged
        fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto)
    End Sub


    Private Sub grdMarcaRepuesto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdMarcaRepuesto.ValueChanged
        fngrd_contador(grdMarcaRepuesto, lblRecuentoMarcaRepuesto)
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

    Private Sub chkTodosRepuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosRepuesto.CheckedChanged
        fnActivaTodos(grdTipoRepuesto, chkTodosRepuesto.Checked)
        fngrd_contador(grdTipoRepuesto, lblRecuentoTipoRepuesto)
    End Sub

    Private Sub chkTodosMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosMarca.CheckedChanged
        fnActivaTodos(grdMarcaRepuesto, chkTodosMarca.Checked)
        fngrd_contador(grdMarcaRepuesto, lblRecuentoMarcaRepuesto)
    End Sub

    Private Sub frmProveedor_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If verRegistro = False Then
            frmProveedorLista.frm_llenarLista()
        End If
    End Sub

    Private Sub cmbClasificacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClasificacion.SelectedValueChanged
        Try

            Dim codigo As Integer = Me.cmbClasificacion.SelectedValue()

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim cla As tblProveedorClasificacionNegocio = (From x In conexion.tblProveedorClasificacionNegocios Where x.idProveedorClasificacionNegocio = codigo Select x).FirstOrDefault

                Me.cmbClasificacionPago.SelectedValue = cla.idtipopago
                Me.cmbTipoGasto.SelectedValue = cla.idtipogasto
                Me.cmbTipoCompra.SelectedValue = cla.idtipocompra
                Me.cmbTipoCuenta.SelectedValue = cla.idpartida
                Me.cmbDepartamento.SelectedValue = cla.iddepartamento

                Dim procedencia As Integer = Me.cmbProcedencia.SelectedValue()

                Dim proced As tblProveedorProcedencia = (From x In conexion.tblProveedorProcedencias Where x.codigo = procedencia Select x).FirstOrDefault

                If proced.bitclasificacion = True Then
                    pgClasificacion.Enabled = True
                Else
                    pgClasificacion.Enabled = False
                End If

                conn.Close()
            End Using

            fnPagosTipo()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProcedencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProcedencia.SelectedValueChanged
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim procedencia As Integer = Me.cmbProcedencia.SelectedValue()

                Dim proced As tblProveedorProcedencia = (From x In conexion.tblProveedorProcedencias Where x.codigo = procedencia Select x).FirstOrDefault

                If proced.bitclasificacion = True Then
                    pgClasificacion.Enabled = True
                Else
                    pgClasificacion.Enabled = False
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnAgregarCuenta_Click_1(sender As Object, e As EventArgs) Handles btnAgregarCuenta.Click
        'Agregamos el numero de cuenta al grid de cuentas
        If txtNoCuenta.Text.Length > 0 Then
            Dim fila As String()
            fila = {"0", txtNombreCuenta.Text, txtNoCuenta.Text, cmbBanco.Text, cmbBanco.SelectedValue}
            Me.grdCuentas.Rows.Add(fila)
            txtNoCuenta.Text = ""
        End If
    End Sub

    Private Sub fnPagosTipo()
        Try
            If Me.cmbClasificacionPago.SelectedValue = PagoProgramado Then
                Me.txtFechaCortePresupuestado.Enabled = False
                Me.txtMontoPresupuesto.Enabled = False
                Me.txtFechaProgramado.Enabled = True
                Me.txtFechaPagoProgramado.Enabled = True
            ElseIf Me.cmbClasificacionPago.SelectedValue = PagoPresupuestado Then
                Me.txtFechaProgramado.Enabled = False
                Me.txtFechaPagoProgramado.Enabled = False
                Me.txtFechaCortePresupuestado.Enabled = True
                Me.txtMontoPresupuesto.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
