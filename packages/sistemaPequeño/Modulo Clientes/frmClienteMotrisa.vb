Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports Telerik.WinControls


Public Class frmClienteMotrisa

    Private Sub frmClienteMotrisa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdPrecios)
        mdlPublicVars.fnFormatoGridEspeciales(grdClasificacion)

        Me.grdDatos.Visible = False ' oculta el grd base
        Me.rgbDatos.Visible = False


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


        End If

    End Sub


    Private Sub llenarCombos()

        Dim tp = From x In ctx.tblClienteTipoPagoes
               Select Codigo = x.idtipoPago, Nombre = x.nombre

        With Me.cmbTipoPago
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = tp
        End With

        Dim tn = From x In ctx.tblClienteTipoNegocios
               Select Codigo = x.idTipoNegocio, Nombre = x.nombre

        With Me.cmbTipoNegocio
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = tn
        End With


        Dim cl = From x In ctx.tblClienteClasificacionNegocios
              Select Codigo = x.idClasificacionNegocio, Nombre = x.nombre

        With Me.cmbClasificacionNegocio
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = cl
        End With

    End Sub


    Private Sub llenagrid()

        Try
            Dim companyInfo = From x In ctx.tblClientes Where x.idCliente > 0 _
                            Select Codigo = x.idCliente, chkHabilitado = x.habillitado, Clave = x.clave, chkMostrador = x.bitMostrador, _
                            Negocio = x.Negocio, Nombre1 = x.Nombre1, _
                            Nit1 = x.nit1, Nombre2 = x.Nombre2, Nit2 = x.nit2, _
                            Telefono = (From y In ctx.tblClientes_Telefono Where y.cliente = x.idCliente Select y.telefono).FirstOrDefault,
                            Contacto = x.contacto, _
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
    End Sub



    Private Sub frm_txtcodigo() Handles txtCodigo.TextChanged
        'llenar clasificacion de compra del cliente.
        Try
            If Not txtCodigo.Text.Equals("") Then
                'llenar lista de modelo, marcas, tipo de vehiculo.
                fnLlenar_Listas()
                ' fnDirecciones()

                'fnLlenarFormatos(CInt(txtCodigo.Text))
                ' fnLlenarTelefono(CInt(txtCodigo.Text))

                fngrd_contador(grdClasificacion, lblRecuentoClasificacion)
                'fngrd_contador(grdModelos, lblRecuentoModeloVehiculo)
                fngrd_contador(grdPrecios, lblRecuentoPrecios)
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
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

        Dim success As Boolean = True
        Dim fecha As Date = fnFecha_horaServidor()
        Dim m As New tblCliente

        'crear el encabezado de la transaccion
        Using transaction As New TransactionScope
            'inicio de excepcion
            Try
                m.habillitado = 1
                m.Negocio = txtNegocio.Text
                m.Nombre1 = txtNombre1.Text
                m.Nombre2 = ""
                m.nit1 = txtNit1.Text
                m.nit2 = ""
                m.direccionEnvio1 = txtDireccion1.Text
                m.direccionEnvio2 = ""
                m.fechaCreacion = fecha
                m.direccionFactura1 = txtDireccion1.Text
                m.direccionFactura2 = ""
                m.contacto = ""
                m.email = ""
                m.observacion = ""
                m.idEmpresa = mdlPublicVars.idEmpresa
                m.georeferencia = ""
                m.telefono = txtTelefono.Text

                m.idClasificacionNegocio = CType(cmbClasificacionNegocio.SelectedValue, Integer)
                m.bitMostrador = chkMostrador.Checked

                'm.bitMostrador = chkMostrador.Checked   'verificar si va
                'm.competencias = nm0Competencias.Value
                'm.motos = nm0Motos.Value

                m.devoluciones = 0
                m.casos = 0
                m.saldo = 0
                m.pagos = 0
                m.pagosTransito = 0
                m.idVendedor = mdlPublicVars.idVendedor
                If mdlPublicVars.PuntoVentaPequeno_Activado = True Then
                    m.idMunicipio = mdlPublicVars.PuntoVentaPequeno_codigoMunicipio
                Else
                    m.idMunicipio = mdlPublicVars.General_MunicipioLocal
                End If

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


                m.idTipoNegocio = CType(cmbTipoNegocio.SelectedValue, Integer)
                m.idTipoPago = CType(cmbTipoPago.SelectedValue, Integer)

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
                    'm.porcentajeCredito = If(IsNumeric(txtPorcentajeCredito.Text), CInt(txtPorcentajeCredito.Text), 0)
                    m.porcentajeCredito = 0
                Else
                    m.diasCredito = 0
                    m.limiteCredito = 0
                    m.porcentajeCredito = 0
                End If


                ctx.AddTotblClientes(m)
                ctx.SaveChanges()

                ''ctx.SaveChanges()

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



                'Agregamos los telefonos del cliente

                Dim telefono As New tblClientes_Telefono
                telefono.cliente = m.idCliente
                telefono.telefono = txtTelefono.Text

                ctx.AddTotblClientes_Telefono(telefono)
                ctx.SaveChanges()



                'Añadimos el tipo de impresion de Factura por defecto
                Dim cft As New tblCliente_FacturaTipoImpresion
                Dim codigoCliente = (From x In ctx.tblClientes Select x.idCliente).Max

                cft.cliente = codigoCliente
                cft.tipoImpresion = 2  'Factura por defecto
                cft.bitPorcentajeManual = 0
                cft.porcentaje = 0
                ctx.AddTotblCliente_FacturaTipoImpresion(cft)

                ctx.SaveChanges()




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

        Dim success As Boolean = True
        Using transaction As New TransactionScope
            Try
                Dim m As tblCliente = (From e1 In ctx.tblClientes Where e1.idCliente = Me.txtCodigo.Text Select e1).First()

                m.clave = txtClave.Text

                ' m.habillitado = chkHabilitado.Checked

                m.Negocio = txtNegocio.Text
                m.Nombre1 = txtNombre1.Text
                'm.Nombre2 = txtNombre2.Text
                m.nit1 = txtNit1.Text
                'm.nit2 = txtNit2.Text
                m.direccionFactura1 = txtDireccion1.Text
                'm.direccionFactura2 = txtDireccion2.Text
                'm.contacto = txtContacto.Text
                'm.email = txtCorreo.Text
                'm.observacion = txtObservacion.Text
                m.direccionEnvio1 = txtDireccion1.Text
                'm.direccionEnvio2 = txtDirEnvio2.Text

                m.bitMostrador = chkMostrador.Checked

                'm.competencias = nm0Competencias.Value
                'm.motos = nm0Motos.Value

                'm.idMunicipio = CType(cmbMunicipio.SelectedValue, Integer)
                'm.georeferencia = txtGeoreferencia.Text

                ' m.idClasificacionNegocio = CType(cmbClasificacionNegocio.SelectedValue, Integer)

                m.idTipoNegocio = CType(cmbTipoNegocio.SelectedValue, Integer)
                m.idTipoPago = CType(cmbTipoPago.SelectedValue, Integer)

                'm.idVendedor = CType(cmbVendedor.SelectedValue, Integer)


                'Verificamos si el tipo de pago seleccionado es al credito
                Dim tipoPago As Integer = CType(cmbTipoPago.SelectedValue, Integer)
                Dim credito As tblClienteTipoPago = (From x In ctx.tblClienteTipoPagoes Where x.idtipoPago = tipoPago Select x).FirstOrDefault


                If credito.credito = True Then
                    m.diasCredito = If(IsNumeric(txtDiasCredito.Text), CInt(txtDiasCredito.Text), 0)
                    m.limiteCredito = If(IsNumeric(txtLimiteCredito.Text), CDbl(txtLimiteCredito.Text), 0)
                    m.porcentajeCredito = 0 'If(IsNumeric(txtPorcentajeCredito.Text), CInt(txtPorcentajeCredito.Text), 0)
                Else
                    m.diasCredito = 0
                    m.limiteCredito = 0
                    m.porcentajeCredito = 0
                End If

                ctx.SaveChanges()

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
                            ctx.AddTotblCliente_Precio(tv)
                            ctx.SaveChanges()
                        End If
                    Else ' si estado = falso

                        If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                            'eliminar el registro.
                            id = grd.Rows(i).Cells(1).Value
                            Dim tv As tblCliente_Precio = (From x In ctx.tblCliente_Precio Where x.codigo = id Select x).FirstOrDefault
                            If tv Is Nothing Then
                            Else
                                ctx.DeleteObject(tv)
                                ctx.SaveChanges()
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
                            ctx.AddTotblCliente_clasificacionCompra(tv)
                            ctx.SaveChanges()
                        End If
                    Else ' si estado = falso
                        If CType(grd.Rows(i).Cells(1).Value, Integer) > 0 Then
                            'eliminar el registro.
                            id = grd.Rows(i).Cells(1).Value
                            Dim tv As tblCliente_clasificacionCompra = (From x In ctx.tblCliente_clasificacionCompra Where x.codigo = id Select x).FirstOrDefault
                            If tv Is Nothing Then
                            Else
                                ctx.DeleteObject(tv)
                                ctx.SaveChanges()
                            End If
                        End If
                    End If
                Next


                ' -------------------------------------------------------------------------------------


                '-------------------------------------------------------------------


                '------------------------------------------------------------------------------------------------------------


                'Modificamos el telefono

                ''Dim telefono As tblClientes_Telefono = (From x In ctx.tblClientes_Telefono Where x.cliente = txtCodigo.Text Select x).FirstOrDefault

                ''telefono.telefono = txtTelefono.Text
                ''ctx.SaveChanges()




                '--------------------------------------------------------------------------------------------------------
                ctx.SaveChanges()
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
            Call llenagrid()
        Else
            alertas.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If


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

        'If credito.credito = True Then
        '    If txtDiasCredito.TextLength = 0 Then
        '        coleccion.Add("Dias de Credito de " & objeto)
        '    End If

        '    If txtLimiteCredito.TextLength = 0 Then
        '        coleccion.Add("Limite de Credito de " & objeto)
        '    End If

        '    If txtPorcentajeCredito.TextLength = 0 Then
        '        coleccion.Add("Porcentaje de Credito de " & objeto)
        '    End If
        'End If


        If CInt(lblRecuentoClasificacion.Text) = 0 Then
            coleccion.Add("Agregar Clasificacion de " & objeto)
        End If


        If cmbTipoNegocio.Text.Length = 0 Then
            coleccion.Add("Tipo de Negocio de " & objeto)
        End If

        If cmbTipoPago.Text.Length = 0 Then
            coleccion.Add("Tipo de Pago de " & objeto)
        End If


        Dim cont
        For cont = 0 To coleccion.Count - 1
            errores += "Falta " & coleccion.Item(cont) & vbCrLf
        Next

        Return errores
    End Function


    'Evento que maneja el uso de la tecla DELETE
    'Private Sub grdDirecciones_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDirecciones.KeyDown
    '    mdlPublicVars.fnGrid_EliminarFila(sender, e, grdDirecciones, "codigo")
    'End Sub








    ''Evento utilizado para agregar una direccion
    'Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
    '    Try
    '        fnAgregarDireccion()
    '    Catch ex As Exception
    '        RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
    '    End Try
    'End Sub

    'Funcion utilizada para agregar las direcciones al grid
    'Private Sub fnAgregarDireccion()
    '    Try
    '        Dim dir As String = Me.txtDireccion.Text
    '        Dim mun As Integer = CType(cmbDirMunicipio.SelectedValue, Integer)

    '        'Seleccionamos el municio
    '        Dim muni As tblMunicipio = (From x In ctx.tblMunicipios Where x.idmunicipio = mun Select x).FirstOrDefault


    '        If dir IsNot Nothing Or dir.Length > 0 Then
    '            'Agregamos la direccion al grid
    '            Dim fila As Object() = {"0", dir, mun, muni.nombre, muni.tbldepartamento.nombre, _
    '                                    muni.tbldepartamento.tblregion.tblpai.nombre, muni.competencias, muni.motos, "0"}
    '            Me.grdDirecciones.Rows.Add(fila)
    '            txtDireccion.Text = ""
    '        Else
    '            alertas.contenido = "Debe ingresar una direccion"
    '            alertas.fnErrorContenido()
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub



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



    'Carga el listado de clientes al cerrar el formulario
    Private Sub frmClientes_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not verRegistro Then
            If verRegistro = False Then
                frmClientePequenioLista.frm_llenarLista()

            End If
        End If
    End Sub



    'retorna true si la clave existe, de lo cotrario false
    Private Function fnVerificaExisteClave()
        'Verificamos que no exista ningun cliente con esa clave
        Dim clave As String = txtClave.Text

        If clave.Equals("") Then
            Return False
        End If

        Dim cliente As tblCliente = (From x In ctx.tblClientes.AsEnumerable Where x.clave.Equals(clave)).FirstOrDefault

        If cliente IsNot Nothing Then
            Return True
        End If


        Return False
    End Function












    Private Sub frmClienteMotrisa_SizeChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub
End Class
