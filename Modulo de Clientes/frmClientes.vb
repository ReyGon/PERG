Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports Telerik.WinControls
Imports System.Data.EntityClient

Public Class frmClientes
    Dim r As New clsReporte


    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdModelos)
        mdlPublicVars.fnFormatoGridEspeciales(grdPrecios)
        mdlPublicVars.fnFormatoGridEspeciales(grdDirecciones)
        mdlPublicVars.fnFormatoGridEspeciales(grdClasificacion)
        mdlPublicVars.fnFormatoGridEspeciales(grdFormatoImpresion)
        mdlPublicVars.fnFormatoGridEspeciales(grdTelefono)
        Me.grdDirecciones.AllowDeleteRow = False
        Me.grdTelefono.AllowDeleteRow = False
        mdlPublicVars.comboActivarFiltro(cmbDirDepartamento)
        mdlPublicVars.comboActivarFiltroLista(cmbDirMunicipio)
        mdlPublicVars.comboActivarFiltroLista(cmbFormatoImpresion)
        mdlPublicVars.comboActivarFiltroLista(cmbTipoNegocio)
        mdlPublicVars.comboActivarFiltroLista(cmbClasificacionNegocio)
        mdlPublicVars.comboActivarFiltroLista(cmbVendedor)
        mdlPublicVars.comboActivarFiltroLista(cmbTipoPago)
        mdlPublicVars.comboActivarFiltroLista(cmbCategoriaCliente)


        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automatico
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        'Me.errores.Controls.Add(Me.txtNegocio, "Nombre")
        'Me.errores.SummaryMessage = "Faltan datos"
        llenarCombos()
        llenagrid()
        fnLlenar_Listas()

        mdlPublicVars.fnSeleccionarDefault(grdDatos, codigoDefault, seleccionDefault)
        If NuevoIniciar = True Then
            Call limpiaCampos()
            lblSaldo.Text = 0
            lblPagos.Text = 0
            lblPagosTransito.Text = 0
            fnLlenar_Listas()
            txtNegocio.Focus()
            pnx1Modificar.Visible = False
            pnx0Guardar.Visible = True
            'asignar numero de clave automaticamente.
            Try
                Dim px As Integer = (From x In ctx.tblClientes Select CType(x.clave, Integer?)).Max
                txtClave.Text = px + 1
            Catch ex As Exception
                txtClave.Text = 0
            End Try
        Else
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
                Dim cliente As tblCliente = (From x In conexion.tblClientes Where x.idCliente = codigoDefault Select x).FirstOrDefault

                If cliente Is Nothing Then

                Else
                    Me.cmbDirDepartamento.SelectedValue = cliente.tblMunicipio.tbldepartamento.iddepartamento
                    Me.cmbDirMunicipio.SelectedValue = cliente.idMunicipio
                    Me.txtDireccion.Text = cliente.direccionEnvio1
                    Me.cmbCategoriaCliente.SelectedValue = cliente.idcategoria
                    Me.dtpFechaNac.Value = CDate(cliente.fechanac).ToShortDateString
                End If

                conn.Close()
            End Using

        End If
    End Sub

    'Llena los combos
    Private Sub llenarCombos()

        Dim tp = From x In ctx.tblClienteTipoPagoes
               Select Codigo = x.idtipoPago, Nombre = x.nombre

        With Me.cmbTipoPago
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = tp
        End With

        Dim cl = From x In ctx.tblClienteClasificacionNegocios
               Select Codigo = x.idClasificacionNegocio, Nombre = x.nombre

        With Me.cmbClasificacionNegocio
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = cl
        End With

        Dim tn = From x In ctx.tblClienteTipoNegocios
                Select Codigo = x.idTipoNegocio, Nombre = x.nombre

        With Me.cmbTipoNegocio
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = tn
        End With

        Dim vendedor = From x In ctx.tblVendedors _
                       Select Codigo = x.idVendedor, Nombre = x.nombre

        With Me.cmbVendedor
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = vendedor
        End With

        'Llena el combo de departamentos de las direccion
        Dim dirDep = From x In ctx.tblpais _
                     Select Codigo = x.idpais, Nombre = x.nombre

        With Me.cmbPais
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = dirDep
        End With

        'Formatos de impresion
        Dim formatos = From x In ctx.tblTipoImpresions Where x.bitEstadoCuenta Or x.bitFactura _
                       Select Codigo = x.codigo, Nombre = x.nombre

        With Me.cmbFormatoImpresion
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = formatos
        End With


        Dim categoria = From x In ctx.tblClienteCategorias Select Codigo = x.idcategoria, Nombre = x.descripcion

        With Me.cmbCategoriaCliente
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = categoria
        End With

    End Sub

    Private Sub llenagrid()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                Dim companyInfo = From x In conexion.tblClientes Where x.idCliente > 0 _
                                Select Codigo = x.idCliente, chkHabilitado = x.habillitado, Clave = x.clave, chkMostrador = x.bitMostrador, _
                                Negocio = x.Negocio, Nombre1 = x.Nombre1, _
                                Nit1 = x.nit1, Nombre2 = x.Nombre2, Nit2 = x.nit2, _
                                Telefono = x.telefono, Contacto = x.contacto, _
                                Direccion1 = x.direccionFactura1, Direccion2 = x.direccionFactura2, _
                                DirEnvio1 = x.direccionEnvio1, DirEnvio2 = x.direccionEnvio2, _
                                Correo = x.email, Observacion = x.observacion, _
                                TipoPago = x.tblClienteTipoPago.nombre, _
                                ClasificacionNegocio = x.tblClienteClasificacionNegocio.nombre, _
                                TipoNegocio = x.tblClienteTipoNegocio.nombre, _
                                Georeferencia = x.georeferencia,
                                LimiteCredito = x.limiteCredito, PorcentajeCredito = x.porcentajeCredito, DiasCredito = x.diasCredito, _
                                Pais = x.tblMunicipio.tbldepartamento.tblregion.tblpai.nombre, Region = x.tblMunicipio.tbldepartamento.tblregion.nombre, _
                                Departamento = x.tblMunicipio.tbldepartamento.nombre, Municipio = x.tblMunicipio.nombre, Vendedor = x.tblVendedor.nombre

                Me.grdDatos.DataSource = companyInfo
            Catch ex As Exception

            End Try

            conn.Close()
        End Using
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
        Dim tp = (From x In ctx.tblArticuloTipoVehiculoes Order By x.nombre _
                 Select Agregar = If(((From y In ctx.tblCliente_clasificacionCompra _
                            Where x.codigo = y.tipoVehiculo And y.idCliente = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = (From y In ctx.tblCliente_clasificacionCompra _
                            Where x.codigo = y.tipoVehiculo And y.idCliente = id _
                            Select y.codigo).FirstOrDefault,
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdClasificacion.Rows.Clear()
        Dim v
        For Each v In tp
            Me.grdClasificacion.Rows.Add(v.AGREGAR, v.iddetalle, v.CODIGO, v.NOMBRE)
        Next

        'Agremamos las modelos
        Dim modelos = (From x In ctx.tblArticuloModeloVehiculoes Order By x.nombre _
                 Select Agregar = If(((From y In ctx.tblCliente_ModeloVehiculo _
                            Where x.codigo = y.modeloVehiculo And y.cliente = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = (From y In ctx.tblCliente_ModeloVehiculo _
                            Where x.codigo = y.modeloVehiculo And y.cliente = id _
                            Select y.codigo).FirstOrDefault,
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdModelos.Rows.Clear()
        Dim mr
        For Each mr In modelos
            Me.grdModelos.Rows.Add(mr.AGREGAR, mr.iddetalle, mr.CODIGO, mr.NOMBRE)
        Next

        'Agregamos los precios
        Dim con = (From x In ctx.tblArticuloTipoPrecios Where x.bitEspecial = False Order By x.nombre _
                 Select Agregar = If(((From y In ctx.tblCliente_Precio _
                            Where x.codigo = y.precio And y.cliente = id _
                            Select y.codigo).FirstOrDefault) > 0, True, False), _
                            IdDetalle = (From y In ctx.tblCliente_Precio _
                            Where x.codigo = y.precio And y.cliente = id _
                            Select y.codigo).FirstOrDefault,
                           Codigo = x.codigo, Nombre = x.nombre)

        Me.grdPrecios.Rows.Clear()
        Dim cn
        For Each cn In con
            Me.grdPrecios.Rows.Add(cn.AGREGAR, cn.iddetalle, cn.CODIGO, cn.NOMBRE)
        Next
    End Sub

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

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub fnNegocios() Handles Me.botonAceptar
        Dim permiso As New clsPermisoUsuario
        Try
            Dim codigo As Integer = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells(0).Value
            Dim frm As Form = frmClienteClasificacionNegocio
            frmClienteClasificacionNegocio.codigoCliente = codigo
            frm.Text = "Negocios"
            permiso.PermisoMantenimientoTelerik(frm, False)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_focoDatos() Handles Me.focoDatos
        txtClave.Focus()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        fnLlenar_Listas()
        txtNegocio.Focus()
        pnx1Modificar.Visible = False
        pnx0Guardar.Visible = True
        rpv.SelectedPage = pageDatos

       
        'asignar numero de clave automaticamente.
        Try
            Dim px As Integer = (From x In ctx.tblClientes Select CType(x.clave, Integer?)).Max
            txtClave.Text = px + 1
        Catch ex As Exception
            txtClave.Text = 0
        End Try

        txtDiasCredito.Text = 0
        txtLimiteCredito.Text = 0
        txtPorcentajeCredito.Text = 0

    End Sub

    Private Sub frm_txtcodigo() Handles txtCodigo.TextChanged
        'llenar clasificacion de compra del cliente.
        Try
            If Not txtCodigo.Text.Equals("") Then
                'llenar lista de modelo, marcas, tipo de vehiculo.
                fnLlenar_Listas()
                fnDirecciones()
                fnLlenarFormatos(CInt(txtCodigo.Text))
                fnLlenarTelefono(CInt(txtCodigo.Text))
                fnLlenarEstado(CInt(txtCodigo.Text))
                fngrd_contador(grdClasificacion, lblRecuentoClasificacion)
                fngrd_contador(grdModelos, lblRecuentoModeloVehiculo)
                fngrd_contador(grdPrecios, lblRecuentoPrecios)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para mostrar las direcciones de envio
    Private Sub fnDirecciones()
        Try
            'Limpiamos el grid
            Me.grdDirecciones.Rows.Clear()

            'Obtenemos el codigo del cliente
            Dim cliente As Integer = CType(txtCodigo.Text, Integer)

            'Obtenemos las listas de las direcciones
            Dim listaDir As List(Of tblCliente_UbicacionMercado) = (From x In ctx.tblCliente_UbicacionMercado Where x.cliente = cliente _
                                                                 Select x).ToList

            Dim dir As tblCliente_UbicacionMercado
            For Each dir In listaDir
                'Creamos la fila
                Dim fila As Object() = {dir.codigo, dir.direccion, dir.municipio, dir.tblMunicipio.nombre, _
                                        dir.tblMunicipio.tbldepartamento.nombre, dir.tblMunicipio.tbldepartamento.tblregion.tblpai.nombre, _
                                        dir.tblMunicipio.competencias, dir.tblMunicipio.motos, "0"}
                Me.grdDirecciones.Rows.Add(fila)
            Next
        Catch ex As Exception

        End Try

    End Sub

    'Funcion utilizada para llenar la pestaña estado del cliente
    Private Sub fnLlenarEstado(idCliente)
        If idCliente > 0 Then
            'Nueva conexion 
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Try
                    'Obtenemos al cliente 
                    Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable
                                                 Where x.idCliente = idCliente
                                                 Select x).FirstOrDefault
                    ' SALDO
                    lblSaldo.Text = Format(cliente.saldo, mdlPublicVars.formatoMoneda)
                    lblPagos.Text = Format(cliente.pagosTransito, mdlPublicVars.formatoMoneda)
                    lblPagosTransito.Text = Format(cliente.pagos, mdlPublicVars.formatoMoneda)
                    txtLimiteCredito.Text = cliente.limiteCredito
                    txtPorcentajeCredito.Text = cliente.porcentajeCredito
                    txtDiasCredito.Text = cliente.diasCredito
                    cmbTipoNegocio.SelectedValue = cliente.idTipoNegocio
                    cmbClasificacionNegocio.SelectedValue = cliente.idClasificacionNegocio
                    cmbTipoPago.SelectedValue = cliente.idTipoPago
                    cmbVendedor.SelectedValue = cliente.idVendedor
                Catch ex As Exception
                    RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                End Try
                conn.Close()
            End Using
        End If
    End Sub

    'GUARDAR
    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        If fnVerificaExisteClave() = True Then
            alertas.contenido = "Clave ya existe !!!"
            alertas.fnErrorContenido()
            Exit Sub
        End If

        'Verificamos que no falten los campos requeridos
        If fnRequeridos.Length > 0 Then
            alertas.contenido = fnRequeridos()
            alertas.fnErrorContenido()
            Exit Sub
        End If

        If fnVerificaExisteNIT() = True Then
            alertas.contenido = "NIT ya existe!!!"
            alertas.fnErrorContenido()

            If RadMessageBox.Show("Desea Activar el Cliente?", nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim conexion As dsi_pos_demoEntities
                Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                    conn.Open()
                    conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                    Dim cli As tblCliente = (From x In conexion.tblClientes Where x.nit1.Equals(Me.txtNit1.Text) Select x).FirstOrDefault

                    cli.habillitado = True

                    conexion.SaveChanges()

                    conn.Close()
                End Using

            End If
        End If

        Dim success As Boolean = True
        Dim fecha As Date = mdlPublicVars.fnFecha_horaServidor()
        Dim m As New tblCliente

        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope
            'inicio de excepcion
            Try
                m.habillitado = 1
                m.Negocio = txtNegocio.Text
                m.Nombre1 = txtNombre1.Text
                m.Nombre2 = txtNombre2.Text
                m.nit1 = txtNit1.Text
                m.nit2 = txtNit2.Text
                m.direccionFactura1 = txtDireccion1.Text
                m.direccionFactura2 = txtDireccion2.Text
                m.contacto = txtContacto.Text
                m.email = txtCorreo.Text
                m.fechaCreacion = fecha
                m.observacion = txtObservacion.Text
                m.idEmpresa = mdlPublicVars.idEmpresa
                m.bitMostrador = chkMostrador.Checked
                m.direccionEnvio1 = txtDirEnvio1.Text
                m.direccionEnvio2 = txtDirEnvio2.Text
                m.idcategoria = Me.cmbCategoriaCliente.SelectedValue
                'm.competencias = nm0Competencias.Value
                'm.motos = nm0Motos.Value

                m.devoluciones = 0
                m.casos = 0
                m.saldo = 0
                m.pagos = 0
                m.pagosTransito = 0
                m.direccionEnvio1 = Me.txtDireccion.Text
                m.fechanac = dtpFechaNac.Value.ToShortDateString
                'm.idMunicipio = CType(cmbMunicipio.SelectedValue, Integer)
                m.georeferencia = txtGeoreferencia.Text

                Dim claveClienteExiste = (From x In ctx.tblClientes Where x.clave = txtClave.Text Select x).Count
                If claveClienteExiste = 0 Then
                    m.clave = txtClave.Text
                Else
                    'obtener la clave maxima de los clientes.
                    Dim claveMaxima As Integer = (From x In ctx.tblClientes Select CType(x.clave, Integer?)).Max + 1

                    'asignar nueva clave.
                    m.clave = claveMaxima
                    RadMessageBox.Show("La clave " & txtClave.Text & " ya existe, se creo la nueva clave :" & claveMaxima, mdlPublicVars.nombreSistema)

                End If

                m.idClasificacionNegocio = CType(cmbClasificacionNegocio.SelectedValue, Integer)
                m.idTipoNegocio = CType(cmbTipoNegocio.SelectedValue, Integer)
                m.idTipoPago = CType(cmbTipoPago.SelectedValue, Integer)
                m.idVendedor = CType(cmbVendedor.SelectedValue, Integer)
                'agregar tipo de vehiculo.
                Dim i
                Dim valor As Boolean = False
                Dim cod As Integer = 0

                'Verificamos si el tipo de pago seleccionado es al credito
                Dim tipoPago As Integer = CType(cmbTipoPago.SelectedValue, Integer)
                Dim credito As tblClienteTipoPago = (From x In ctx.tblClienteTipoPagoes Where x.idtipoPago = tipoPago Select x).FirstOrDefault

                If credito.credito = True Then
                    m.diasCredito = If(IsNumeric(txtDiasCredito.Text), CInt(txtDiasCredito.Text), 0)
                    m.limiteCredito = If(IsNumeric(txtLimiteCredito.Text), CDbl(txtLimiteCredito.Text), 0)
                    m.porcentajeCredito = If(IsNumeric(txtPorcentajeCredito.Text), CInt(txtPorcentajeCredito.Text), 0)
                Else
                    m.diasCredito = 0
                    m.limiteCredito = 0
                    m.porcentajeCredito = 0
                End If

                'verificar si la clave ya existe.

                m.idMunicipio = Me.cmbDirMunicipio.SelectedValue
                ctx.AddTotblClientes(m)
                ctx.SaveChanges()

                ctx.SaveChanges()

                'Clasificacion
                For i = 0 To Me.grdClasificacion.Rows.Count - 1
                    valor = Me.grdClasificacion.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdClasificacion.Rows(i).Cells(2).Value
                        Dim tv As New tblCliente_clasificacionCompra
                        tv.idCliente = m.idCliente
                        tv.tipoVehiculo = cod
                        ctx.AddTotblCliente_clasificacionCompra(tv)
                        ctx.SaveChanges()
                    End If
                Next

                'Marca
                For i = 0 To Me.grdModelos.Rows.Count - 1
                    valor = Me.grdModelos.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdModelos.Rows(i).Cells(2).Value
                        Dim tv As New tblCliente_ModeloVehiculo
                        tv.cliente = m.idCliente
                        tv.modeloVehiculo = cod
                        ctx.AddTotblCliente_ModeloVehiculo(tv)
                        ctx.SaveChanges()
                    End If
                Next

                'Precios
                For i = 0 To Me.grdPrecios.Rows.Count - 1
                    valor = Me.grdPrecios.Rows(i).Cells(0).Value

                    If valor = True Then 'agregar el tipo de vehiculo
                        cod = Me.grdPrecios.Rows(i).Cells(2).Value
                        Dim tv As New tblCliente_Precio
                        tv.cliente = m.idCliente
                        tv.precio = cod
                        ctx.AddTotblCliente_Precio(tv)
                        ctx.SaveChanges()
                    End If
                Next

                Dim codMun As Integer = 0
                Dim dir As String = ""
                'Agregamos las direcciones de envio al cliente
                For i = 0 To Me.grdDirecciones.Rows.Count - 1
                    codMun = CType(Me.grdDirecciones.Rows(i).Cells(2).Value, Integer)
                    dir = CType(Me.grdDirecciones.Rows(i).Cells(1).Value, String)

                    'Creamos la nueva direccion
                    Dim direccion As New tblCliente_UbicacionMercado
                    direccion.cliente = m.idCliente
                    direccion.direccion = dir
                    direccion.municipio = codMun
                    ctx.AddTotblCliente_UbicacionMercado(direccion)
                    ctx.SaveChanges()
                Next

                'Agregamos los telefonos del cliente
                For i = 0 To Me.grdTelefono.Rows.Count - 1
                    Dim telefono As New tblClientes_Telefono
                    telefono.cliente = m.idCliente
                    telefono.observacion = Me.grdTelefono.Rows(i).Cells("observacion").Value
                    telefono.telefono = Me.grdTelefono.Rows(i).Cells("telefono").Value

                    ctx.AddTotblClientes_Telefono(telefono)
                    ctx.SaveChanges()
                Next

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
            If RadMessageBox.Show("Desea agregar otro cliente", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                frm_nuevoRegistro()
            Else
                Me.Close()
            End If
        Else
            alertas.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro

        If fnVerificaExisteClave() = True Then
            alertas.contenido = "Clave ya existe !!!"
            alertas.fnErrorContenido()
            Exit Sub
        End If


        Dim success As Boolean = True

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Using transaction As New TransactionScope
                Try
                    Dim m As tblCliente = (From e1 In conexion.tblClientes Where e1.idCliente = Me.txtCodigo.Text Select e1).First()

                    m.clave = txtClave.Text
                    m.habillitado = chkHabilitado.Checked
                    m.Negocio = txtNegocio.Text
                    m.Nombre1 = txtNombre1.Text
                    m.Nombre2 = txtNombre2.Text
                    m.nit1 = txtNit1.Text
                    m.nit2 = txtNit2.Text
                    m.direccionFactura1 = txtDireccion1.Text
                    m.direccionFactura2 = txtDireccion2.Text
                    m.contacto = txtContacto.Text
                    m.email = txtCorreo.Text
                    m.observacion = txtObservacion.Text
                    m.direccionEnvio1 = txtDirEnvio1.Text
                    m.direccionEnvio2 = txtDirEnvio2.Text
                    m.bitMostrador = chkMostrador.Checked
                    m.idMunicipio = Me.cmbDirMunicipio.SelectedValue
                    m.direccionEnvio1 = Me.txtDireccion.Text
                    m.idcategoria = Me.cmbCategoriaCliente.SelectedValue
                    m.fechanac = dtpFechaNac.Value.ToShortDateString
                    'm.competencias = nm0Competencias.Value
                    'm.motos = nm0Motos.Value

                    'm.idMunicipio = CType(cmbMunicipio.SelectedValue, Integer)
                    m.georeferencia = txtGeoreferencia.Text

                    m.idClasificacionNegocio = CType(cmbClasificacionNegocio.SelectedValue, Integer)
                    m.idTipoNegocio = CType(cmbTipoNegocio.SelectedValue, Integer)
                    m.idTipoPago = CType(cmbTipoPago.SelectedValue, Integer)
                    m.idVendedor = CType(cmbVendedor.SelectedValue, Integer)


                    'Verificamos si el tipo de pago seleccionado es al credito
                    Dim tipoPago As Integer = CType(cmbTipoPago.SelectedValue, Integer)
                    Dim credito As tblClienteTipoPago = (From x In conexion.tblClienteTipoPagoes Where x.idtipoPago = tipoPago Select x).FirstOrDefault

                    If credito.credito = True Then
                        m.diasCredito = If(IsNumeric(txtDiasCredito.Text), CInt(txtDiasCredito.Text), 0)
                        m.limiteCredito = If(IsNumeric(txtLimiteCredito.Text), CDbl(txtLimiteCredito.Text), 0)
                        m.porcentajeCredito = If(IsNumeric(txtPorcentajeCredito.Text), CInt(txtPorcentajeCredito.Text), 0)
                    Else
                        m.diasCredito = 0
                        m.limiteCredito = 0
                        m.porcentajeCredito = 0
                    End If

                    conexion.SaveChanges()
                    conexion.SaveChanges()

                    Dim estado As Boolean = False
                    Dim cod As Integer
                    Dim i As Integer
                    Dim id As Integer
                    Dim grd As Telerik.WinControls.UI.RadGridView

                    'Agregamos los precios del cliente
                    grd = Me.grdPrecios
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells(0).Value
                        cod = grd.Rows(i).Cells(2).Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblCliente_Precio
                                tv.cliente = m.idCliente
                                tv.precio = cod
                                conexion.AddTotblCliente_Precio(tv)
                                conexion.SaveChanges()
                            End If
                        Else ' si estado = falso

                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells(1).Value
                                Dim tv As tblCliente_Precio = (From x In conexion.tblCliente_Precio Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    conexion.DeleteObject(tv)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If

                    Next

                    'agregar las clasificaciones de clientes.
                    grd = Me.grdClasificacion
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells(0).Value
                        cod = grd.Rows(i).Cells(2).Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then

                            Else
                                Dim tv As New tblCliente_clasificacionCompra
                                tv.idCliente = m.idCliente
                                tv.tipoVehiculo = cod
                                conexion.AddTotblCliente_clasificacionCompra(tv)
                                conexion.SaveChanges()
                            End If
                        Else ' si estado = falso
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells(1).Value
                                Dim tv As tblCliente_clasificacionCompra = (From x In conexion.tblCliente_clasificacionCompra Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    conexion.DeleteObject(tv)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    'Agregar marcas
                    grd = Me.grdModelos
                    For i = 0 To grd.Rows.Count - 1
                        estado = grd.Rows(i).Cells(0).Value
                        cod = grd.Rows(i).Cells(2).Value
                        'si estado = true y existe, no hacer nada
                        If estado = True Then
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                            Else
                                Dim tv As New tblCliente_ModeloVehiculo
                                tv.cliente = m.idCliente
                                tv.modeloVehiculo = cod
                                conexion.AddTotblCliente_ModeloVehiculo(tv)
                                conexion.SaveChanges()
                            End If
                        Else ' si estado = falso
                            If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                                'eliminar el registro.
                                id = grd.Rows(i).Cells(1).Value
                                Dim tv As tblCliente_ModeloVehiculo = (From x In conexion.tblCliente_ModeloVehiculo Where x.codigo = id Select x).FirstOrDefault
                                If tv Is Nothing Then
                                Else
                                    conexion.DeleteObject(tv)
                                    conexion.SaveChanges()
                                End If
                            End If
                        End If
                    Next

                    Dim codMun As Integer = 0
                    Dim dir As String = ""
                    Dim elimina As Integer = 0
                    Dim codDir As Integer = 0

                    'Agregamos las direcciones de envio al cliente
                    For i = 0 To Me.grdDirecciones.Rows.Count - 1
                        codDir = CType(Me.grdDirecciones.Rows(i).Cells(0).Value, Integer)
                        dir = CType(Me.grdDirecciones.Rows(i).Cells(1).Value, String)
                        codMun = CType(Me.grdDirecciones.Rows(i).Cells(2).Value, Integer)
                        elimina = CType(Me.grdDirecciones.Rows(i).Cells("elimina").Value, Integer)

                        If elimina = 1 Then
                            'Eliminamos la direccion
                            Dim direccion As tblCliente_UbicacionMercado = (From x In conexion.tblCliente_UbicacionMercado Where x.codigo = codDir _
                                                                        Select x).FirstOrDefault
                            If direccion IsNot Nothing Then
                                conexion.DeleteObject(direccion)
                                conexion.SaveChanges()
                            End If
                        ElseIf codDir = 0 Then
                            'Creamos la nueva direccion
                            Dim direccion As New tblCliente_UbicacionMercado
                            direccion.cliente = m.idCliente
                            direccion.direccion = dir
                            direccion.municipio = codMun
                            conexion.AddTotblCliente_UbicacionMercado(direccion)
                            conexion.SaveChanges()
                        End If
                    Next

                    'Guardamos los telefonos
                    Dim idTelefono As Integer = 0

                    For i = 0 To Me.grdTelefono.Rows.Count - 1
                        idTelefono = Me.grdTelefono.Rows(i).Cells("codigo").Value
                        elimina = Me.grdTelefono.Rows(i).Cells("elimina").Value

                        If elimina > 0 Then
                            'ELIMINAR
                            'Obtenemos el telefono
                            Dim telefono As tblClientes_Telefono = (From x In conexion.tblClientes_Telefono Where x.codigo = idTelefono
                                                                   Select x).FirstOrDefault

                            'Eliminamos el telefono
                            conexion.DeleteObject(telefono)
                            conexion.SaveChanges()
                        ElseIf idTelefono > 0 Then
                            'Modificamos el telefono
                            Dim telefono As tblClientes_Telefono = (From x In conexion.tblClientes_Telefono Where x.codigo = idTelefono
                                                                   Select x).FirstOrDefault

                            telefono.observacion = Me.grdTelefono.Rows(i).Cells("observacion").Value
                            conexion.SaveChanges()
                        Else
                            'Creamos el nuevo telefono
                            Dim telefono As New tblClientes_Telefono
                            telefono.telefono = Me.grdTelefono.Rows(i).Cells("telefono").Value
                            telefono.observacion = Me.grdTelefono.Rows(i).Cells("observacion").Value
                            telefono.cliente = m.idCliente
                            conexion.AddTotblClientes_Telefono(telefono)
                            conexion.SaveChanges()
                        End If
                    Next

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
                alertas.fnModificar()
                Call llenagrid()
            Else
                alertas.fnErrorGuardar()
                Console.WriteLine("La operacion no pudo ser completada")
            End If

            conn.Close()
        End Using
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro
        If MsgBox("Esta seguro de Deshabilitar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el municipio
            Dim m As tblCliente = (From e1 In ctx.tblClientes Where e1.idCliente = Me.txtCodigo.Text Select e1).First()
            m.habillitado = False
            'ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.contenido = "Registro Deshabilitado !!!"
            alertas.fnErrorContenido()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    'Funcion que se utlizara para saber si todos los campos requeridos estan llenos
    Private Function fnRequeridos() As String
        'Variables que se utiliran para el control
        Dim errores As String = ""

        'Creamos el arreglo que contenera los errores
        Dim coleccion As New ArrayList
        Dim objeto As String = "Cliente"

        'Verificamos que tenga nombre y codigo
        If txtNegocio.TextLength = 0 Then
            coleccion.Add("Nombre de " & objeto)
        End If

        If txtNombre1.TextLength = 0 Then
            coleccion.Add("Nombre Facturarion 1 " & objeto)
        End If

        If txtNit1.TextLength = 0 Then
            coleccion.Add("Nit 1 de" & objeto)
        End If

        If txtDireccion1.TextLength = 0 Then
            coleccion.Add("Direccion de Facturacion 1 de" & objeto)
        End If

        'Verificamos si el tipo de pago seleccionado es al credito
        Dim tipoPago As Integer = CType(cmbTipoPago.SelectedValue, Integer)
        Dim credito As tblClienteTipoPago = (From x In ctx.tblClienteTipoPagoes Where x.idtipoPago = tipoPago Select x).FirstOrDefault

        If credito.credito = True Then
            If txtDiasCredito.TextLength = 0 Then
                coleccion.Add("Dias de Credito de " & objeto)
            End If

            If txtLimiteCredito.TextLength = 0 Then
                coleccion.Add("Limite de Credito de " & objeto)
            End If

            If txtPorcentajeCredito.TextLength = 0 Then
                coleccion.Add("Porcentaje de Credito de " & objeto)
            End If
        End If


        If CInt(lblRecuentoClasificacion.Text) = 0 Then
            coleccion.Add("Agregar Clasificacion de " & objeto)
        End If

        If cmbClasificacionNegocio.Text.Length = 0 Then
            coleccion.Add("Clasificacion de Negocio de " & objeto)
        End If

        If cmbTipoNegocio.Text.Length = 0 Then
            coleccion.Add("Tipo de Negocio de " & objeto)
        End If

        If cmbTipoPago.Text.Length = 0 Then
            coleccion.Add("Tipo de Pago de " & objeto)
        End If

        If cmbVendedor.Text.Length = 0 Then
            coleccion.Add(" Vendedor de " & objeto)
        End If

        Dim cont
        For cont = 0 To coleccion.Count - 1
            errores += "Falta " & coleccion.Item(cont) & vbCrLf
        Next

        Return errores
    End Function

    'Evento que maneja el uso de la tecla DELETE
    Private Sub grdDirecciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDirecciones.KeyDown
        mdlPublicVars.fnGrid_EliminarFila(sender, e, grdDirecciones, "codigo")
    End Sub

    'Evento utilizado para agregar una direccion
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            fnAgregarDireccion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para agregar las direcciones al grid
    Private Sub fnAgregarDireccion()
        Try
            Dim dir As String = Me.txtDireccion.Text
            Dim mun As Integer = CType(cmbDirMunicipio.SelectedValue, Integer)

            'Seleccionamos el municio
            Dim muni As tblMunicipio = (From x In ctx.tblMunicipios Where x.idmunicipio = mun Select x).FirstOrDefault


            If dir IsNot Nothing Or dir.Length > 0 Then
                'Agregamos la direccion al grid
                Dim fila As Object() = {"0", dir, mun, muni.nombre, muni.tbldepartamento.nombre, _
                                        muni.tbldepartamento.tblregion.tblpai.nombre, muni.competencias, muni.motos, "0"}
                Me.grdDirecciones.Rows.Add(fila)
                txtDireccion.Text = ""
            Else
                alertas.contenido = "Debe ingresar una direccion"
                alertas.fnErrorContenido()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdPrecios_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPrecios.ValueChanged
        Try
            Dim fila As Integer = Me.grdPrecios.CurrentRow.Index
            Dim col As Integer = Me.grdPrecios.CurrentColumn.Index

            txtCodigo.Focus()
            txtCodigo.Select()
            Me.grdPrecios.Rows(fila).IsCurrent = True
            Me.grdPrecios.Columns(col).IsCurrent = True
            fngrd_contador(grdPrecios, lblRecuentoPrecios)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbPais_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedValueChanged
        Try
            Dim pais As Integer = CType(cmbPais.SelectedValue, Integer)
            Dim cas = From s In ctx.tbldepartamentoes _
                        Where s.tblregion.tblpai.idpais = pais _
                        Select Codigo = s.iddepartamento, Nombre = s.nombre _
                        Order By Nombre Ascending

            With Me.cmbDirDepartamento
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cas
            End With

        Catch ex As Exception

        End Try
    End Sub

    'Evento que se utiliza para actualizar el como de municipios
    Private Sub cmbDirDepartamento_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDirDepartamento.SelectedValueChanged

        Try
            Dim dep As Integer = CType(cmbDirDepartamento.SelectedValue, Integer)
            Dim cas = From s In ctx.tblMunicipios _
                        Where s.iddepartamento = dep _
                        Select Codigo = s.idmunicipio, Nombre = s.nombre _
                        Order By Nombre Ascending


            With Me.cmbDirMunicipio
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cas
            End With

            Dim depa As tbldepartamento = (From x In ctx.tbldepartamentoes Where x.iddepartamento = dep Select x).FirstOrDefault

            lblRegion.Text = depa.tblregion.nombre
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdClasificacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdClasificacion.ValueChanged
        Try
            Dim fila As Integer = Me.grdClasificacion.CurrentRow.Index
            Dim col As Integer = Me.grdClasificacion.CurrentColumn.Index

            txtCodigo.Focus()
            txtCodigo.Select()
            Me.grdClasificacion.Rows(fila).IsCurrent = True
            Me.grdClasificacion.Columns(col).IsCurrent = True
            fngrd_contador(grdClasificacion, lblRecuentoClasificacion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdModelos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdModelos.ValueChanged
        Try
            Dim fila As Integer = Me.grdModelos.CurrentRow.Index
            Dim col As Integer = Me.grdModelos.CurrentColumn.Index

            txtCodigo.Focus()
            txtCodigo.Select()
            Me.grdModelos.Rows(fila).IsCurrent = True
            Me.grdModelos.Columns(col).IsCurrent = True
            fngrd_contador(grdModelos, lblRecuentoModeloVehiculo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkTodosModelo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosModelo.CheckedChanged
        fnActivaTodos(grdModelos, chkTodosModelo.Checked)
        fngrd_contador(grdModelos, lblRecuentoModeloVehiculo)
    End Sub


    Private Sub chkTodosClasificacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodosClasificacion.CheckedChanged
        fnActivaTodos(grdClasificacion, chkTodosClasificacion.Checked)
        fngrd_contador(grdClasificacion, lblRecuentoClasificacion)
    End Sub

    'Funcion utilizada para activar todos los elementos de un grid
    Private Sub fnActivaTodos(ByRef grd As Telerik.WinControls.UI.RadGridView, ByVal estado As Boolean)
        'Recorremos el grid
        For i As Integer = 0 To grd.Rows.Count - 1
            grd.Rows(i).Cells(0).Value = estado
        Next
    End Sub

    Private Sub chkPorcentajeManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPorcentajeManual.CheckedChanged
        nm2Porcentaje.Enabled = chkPorcentajeManual.Checked
    End Sub

    'AGREGAR FORMATO DE IMPRESION
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            If pnx1Modificar.Visible Then
                fnAgregarFormato()
            Else
                RadMessageBox.Show("Debe de guardar el cliente primero!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    'Funcion utilizada para agregar un formato de impresion
    Private Sub fnAgregarFormato()
        'Verificamos errores
        If chkPorcentajeManual.Checked And nm2Porcentaje.Value <= 0 Then
            RadMessageBox.Show("Debe de agregar un porcentaje mayor a cero ( 0 )", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Exit Sub
        End If

        'Creamos el nuevo formato para el cliente
        Dim formato As New tblCliente_FacturaTipoImpresion
        formato.cliente = txtCodigo.Text
        formato.bitPorcentajeManual = chkPorcentajeManual.Checked
        formato.tipoImpresion = CInt(cmbFormatoImpresion.SelectedValue)
        formato.porcentaje = If(chkPorcentajeManual.Checked, nm2Porcentaje.Value, 0)

        'Agregamos el formato al modelo
        ctx.AddTotblCliente_FacturaTipoImpresion(formato)
        ctx.SaveChanges()

        RadMessageBox.Show("Formato agregado exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        fnLlenarFormatos(CInt(txtCodigo.Text))
        nm2Porcentaje.Value = 0
        chkPorcentajeManual.Checked = False
    End Sub

    'ELIMINAR FORMATO IMPRESION
    Private Sub grdFormatoImpresion_UserDeletingRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowCancelEventArgs) Handles grdFormatoImpresion.UserDeletingRow
        If RadMessageBox.Show("¿Desea eliminar el formato de impresion del cliente?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Obtenemos la fila seleccionada y el codio del registro
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdFormatoImpresion)
            Dim codigo As Integer = Me.grdFormatoImpresion.Rows(fila).Cells("iddetalle").Value

            'Obtenemos  el registro
            Dim formato As tblCliente_FacturaTipoImpresion = (From x In ctx.tblCliente_FacturaTipoImpresion Where x.codigo = codigo _
                                                              Select x).First

            If formato IsNot Nothing Then
                ctx.DeleteObject(formato)
                ctx.SaveChanges()

                RadMessageBox.Show("Formato eliminado exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                fnLlenarFormatos(CInt(txtCodigo.Text))
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    'Funcion utilizada para llenar los formatos de impresion del cliente
    Private Sub fnLlenarFormatos(ByVal cliente As Integer)
        'Limpiamos el grid
        grdFormatoImpresion.Rows.Clear()

        'Obtenemos la lista de formatos
        Dim lFormatos As List(Of tblCliente_FacturaTipoImpresion) = (From x In ctx.tblCliente_FacturaTipoImpresion
                                                                     Where x.cliente = cliente
                                                                     Select x).ToList

        For Each formato As tblCliente_FacturaTipoImpresion In lFormatos
            'Creamos la fila
            Dim fila As Object() = {formato.codigo, formato.tblTipoImpresion.nombre, formato.tblTipoImpresion.observacion, formato.bitPorcentajeManual, formato.porcentaje}
            'Agregamos la fila
            Me.grdFormatoImpresion.Rows.Add(fila)
        Next
    End Sub

    'CAMBIO DE SELECCION DE FORMATO
    Private Sub cmbFormatoImpresion_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormatoImpresion.SelectedValueChanged

        If cmbFormatoImpresion.Items.Count > 0 Then
            'Obtenemos el codigo
            Dim codigo As Integer = CInt(cmbFormatoImpresion.SelectedValue)

            Dim formato As tblTipoImpresion = (From x In ctx.tblTipoImpresions Where x.codigo = codigo _
                                                      Select x).FirstOrDefault

            If formato IsNot Nothing Then
                lblObservacion.Text = formato.observacion
            End If
        End If
    End Sub

    Private Sub frmClientes_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not verRegistro Then
            If verRegistro = False Then
                frmClienteLista.frm_llenarLista()
            End If
        End If
    End Sub

    Private Sub btnAgregarArroba_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregaArroba.Click
        fnAgregarArroba()
    End Sub

    Private Sub fnAgregarArroba()
        If txtCorreo.Enabled = True Then
            txtCorreo.Text = txtCorreo.Text + "@"
            txtCorreo.Focus()
            txtCorreo.SelectionStart = txtCorreo.Text.Length
            txtCorreo.Focus()
        End If
    End Sub

    Private Sub btnAgregarTelefonos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarTelefonos.Click
        If RadMessageBox.Show("¿Desea agregar el télefono?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnAgregarTelefono()
        End If
    End Sub

    'LLENAR TELEFONOS
    Public Sub fnLlenarTelefono(ByVal idCliente As Integer)
        grdTelefono.Rows.Clear()

        'Obtenemos la lista de telefonos
        Dim lTelefonos As List(Of tblClientes_Telefono) = (From x In ctx.tblClientes_Telefono Where x.cliente = idCliente
                                                         Select x).ToList

        Dim fila As Object()
        'Recorremos la lista y agregamos los telefonos
        For Each telefono As tblClientes_Telefono In lTelefonos
            fila = {telefono.codigo, telefono.telefono, telefono.observacion, 0}
            grdTelefono.Rows.Add(fila)
        Next

        fnConfiguraTelefonos()
    End Sub

    'CONFIGURA GRID DE TELEFONOS
    Private Sub fnConfiguraTelefonos()
        If Me.grdTelefono.ColumnCount > 0 Then
            Me.grdTelefono.Columns("codigo").IsVisible = False

            Me.grdTelefono.Columns("Telefono").Width = 35
            Me.grdTelefono.Columns("Observacion").Width = 65
        End If
    End Sub

    'AGREGAR NUEVO TELEFONO
    Private Function fnAgregarTelefono() As Boolean
        Try
            Dim fila As Object()
            fila = {0, txtTelefonoAgrega.Text, txtObservacionTelefono.Text, 0}
            Me.grdTelefono.Rows.Add(fila)
            txtTelefonoAgrega.Text = ""
            txtObservacionTelefono.Text = ""
            Return True
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End Try
    End Function

    'retorna true si la clave existe, de lo cotrario false
    Private Function fnVerificaExisteClave()
        'Verificamos que no exista ningun cliente con esa clave
        Dim clave As String = txtClave.Text

        If clave.Equals("") Then
            Return False
        End If

        Dim cliente As tblCliente

        If txtCodigo.Text = "" Then
            cliente = (From x In ctx.tblClientes.AsEnumerable Where x.clave.Equals(clave)).FirstOrDefault
        Else
            cliente = (From x In ctx.tblClientes.AsEnumerable Where x.clave.Equals(clave) And x.idCliente <> CType(txtCodigo.Text, Integer)).FirstOrDefault
        End If

        If cliente IsNot Nothing Then
            Return True
        End If


        Return False
    End Function

    Private Function fnVerificaExisteNIT()
        'Verificamos que no exista ningun cliente con esa clave
        Dim clave As String = txtNit1.Text

        If clave.Equals("") Then
            Return False
        End If

        Dim cliente As tblCliente

        If txtNit1.Text = "" Then
            cliente = (From x In ctx.tblClientes.AsEnumerable Where x.nit1.Equals(clave)).FirstOrDefault
        Else
            Dim val As Integer

            Try
                val = txtCodigo.Text
            Catch ex As Exception
                val = 0
            End Try

            cliente = (From x In ctx.tblClientes.AsEnumerable Where x.nit1.Equals(clave) And x.idCliente <> CType(val, Integer)).FirstOrDefault
        End If

        If cliente IsNot Nothing Then
            Return True
        End If


        Return False
    End Function

    Private Sub grdTelefono_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdTelefono.KeyDown
        mdlPublicVars.fnGrid_EliminarFila(sender, e, grdTelefono, "codigo")
    End Sub

    Private Sub btnInfoCliente_Click(sender As Object, e As EventArgs) Handles botonInfoCliente.Click
        'Abrir el formulario de estadisticas
        Dim codigo As Integer = 0

        If IsNumeric(txtCodigo.Text.Trim) Then
            codigo = CInt(txtCodigo.Text)
        End If

        frmClienteEstadistica.idCliente = codigo
        frmClienteEstadistica.StartPosition = FormStartPosition.CenterScreen
        frmClienteEstadistica.WindowState = FormWindowState.Normal
        frmClienteEstadistica.Text = "Estadistica de Venta"
        frmClienteEstadistica.ShowDialog()
    End Sub

    Private Sub txtDirEnvio1_Leave(sender As Object, e As EventArgs) Handles txtDirEnvio1.Leave
        Me.txtDireccion.Text = Me.txtDirEnvio1.Text
    End Sub
End Class