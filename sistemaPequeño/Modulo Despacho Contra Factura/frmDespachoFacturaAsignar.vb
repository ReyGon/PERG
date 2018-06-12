Option Strict On

Imports System.Data
Imports System.Data.EntityClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.Transactions

Public Class frmDespachoFacturaAsignar

#Region "Variables Privadas"
    Private _listaAgregar As List(Of GridViewRowInfo)
    Private _listaEmpleados As List(Of Tuple(Of Integer, String))
#End Region

#Region "Propiedades"

   Public Property listaEmpleados As List(Of Tuple(Of Integer, String))
        Get
            listaEmpleados = _listaEmpleados
        End Get
        Set(value As List(Of Tuple(Of Integer, String)))
            _listaEmpleados = value
        End Set
    End Property

    Public Property listaAgregar As List(Of GridViewRowInfo)
        Get
            listaAgregar = _listaAgregar
        End Get
        Set(value As List(Of GridViewRowInfo))
            _listaAgregar = value
        End Set
    End Property

#End Region

#Region "Eventos"
    'LOAD
    Private Sub frmDespachoFacturaAsignar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(grdClientes)
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)

        mdlPublicVars.comboActivarFiltro(cmbPiloto)
        mdlPublicVars.comboActivarFiltro(cmbSucursalSalida)
        mdlPublicVars.comboActivarFiltro(cmbTipoTransporte)
        mdlPublicVars.comboActivarFiltro(cmbTransporte)

        fnLlenarCombos()
        fnLlenarDatos()

        listaEmpleados = New List(Of Tuple(Of Integer, String))
    End Sub

    'GUARDAR LA ASIGNACION
    Private Sub fnGuardar_Click() Handles Me.panel0
        ''If RadMessageBox.Show("¿Desea guardar el transporte?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
        ''    Dim conexion As dsi_pos_demoEntities
        ''    Dim success As Boolean = True
        ''    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
        ''        conn.Open()
        ''        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
        ''        Using transaction As New TransactionScope
        ''            Try
        ''                '---- ENCABEZADO TRANSPORTE
        ''                Dim salidaTransporteMedio As New tblSalidasTransportesMedio
        ''                salidaTransporteMedio.idTransporte = CInt(cmbTransporte.SelectedValue)
        ''                salidaTransporteMedio.idPiloto = CInt(cmbPiloto.SelectedValue)
        ''                salidaTransporteMedio.idSucursalSalida = CInt(cmbSucursalSalida.SelectedValue)
        ''                salidaTransporteMedio.idEmpresa = mdlPublicVars.idEmpresa
        ''                salidaTransporteMedio.fechaTransporte = CDate(txtFecha.Text)
        ''                salidaTransporteMedio.salida = False
        ''                ''salidaTransporteMedio.costo = CDec(nm2Costo.Value)
        ''                salidaTransporteMedio.observacion = txtObservacion.Text
        ''                salidaTransporteMedio.correlativo = CInt(lblCorrelativo.Text)
        ''                salidaTransporteMedio.NumeroViaje = CInt(txtNoViaje.Text)
        ''                salidaTransporteMedio.KMGalon = CDec(lblKMGalon.Text)
        ''                salidaTransporteMedio.entrada = False
        ''                salidaTransporteMedio.conceptoEntrada = 1
        ''                salidaTransporteMedio.TotalKms = 0
        ''                salidaTransporteMedio.CostoCombustible = 0
        ''                salidaTransporteMedio.TotalCombustible = 0
        ''                salidaTransporteMedio.TotalPlanilla = 0
        ''                salidaTransporteMedio.Costo = 0
        ''                salidaTransporteMedio.TotalCobro = 0
        ''                salidaTransporteMedio.idusuario = mdlPublicVars.idUsuario
        ''                salidaTransporteMedio.GastosEnvio = False

        ''                conexion.AddTotblSalidasTransportesMedios(salidaTransporteMedio)
        ''                conexion.SaveChanges()

        ''                '---- DETALLE TRANSPORTE -> PRODUCTOS
        ''                'For Each dato As Tuple(Of Integer, Integer, Integer, String, String, String, Tuple(Of String, String)) In listaProductos
        ''                For Each fila As GridViewRowInfo In Me.grdProductos.Rows
        ''                    Dim salidaTransporteMedioDetalle As New tblSalidasTransportesMediosDetalle
        ''                    salidaTransporteMedioDetalle.idSalidaTransporteMedio = salidaTransporteMedio.idSalidaTransporteMedio
        ''                    salidaTransporteMedioDetalle.idSalidaDetalle = CInt(fila.Cells("idSalidaDetalle").Value)
        ''                    salidaTransporteMedioDetalle.idSalidaTransporte = CInt(fila.Cells("idSalidaTransporte").Value)
        ''                    salidaTransporteMedioDetalle.cantidad = CDec(fila.Cells("cantidad").Value)
        ''                    salidaTransporteMedioDetalle.reenviado = False
        ''                    conexion.AddTotblSalidasTransportesMediosDetalles(salidaTransporteMedioDetalle)
        ''                    conexion.SaveChanges()
        ''                Next

        ''                '---- DETALLE TRANSPORTE -> EMPLEADOS
        ''                For Each dato As Tuple(Of Integer, String) In listaEmpleados
        ''                    Dim salidaTransporteMedioEmpleado As New tblSalidasTransportesMediosEmpleado
        ''                    salidaTransporteMedioEmpleado.idSalidaTransporteMedio = salidaTransporteMedio.idSalidaTransporteMedio
        ''                    salidaTransporteMedioEmpleado.idEmpleado = dato.Item1

        ''                    conexion.AddTotblSalidasTransportesMediosEmpleados(salidaTransporteMedioEmpleado)
        ''                    conexion.SaveChanges()
        ''                Next

        ''                transaction.Complete()
        ''            Catch ex As Exception
        ''                success = False
        ''            End Try
        ''            conn.Close()
        ''        End Using
        ''    End Using

        ''    If success Then
        ''        alerta.fnGuardar()

        ''        RadMessageBox.Show("Transporte guardado exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)

        ''        Me.Close()
        ''    Else
        ''        alerta.contenido = "Ocurrio un error"
        ''        alerta.fnErrorContenido()
        ''    End If
        ''End If
    End Sub

    'SALIR DEL FORMULARIO
    Private Sub fnSalir_Click() Handles Me.panel1
        Me.Close()
    End Sub

    'AGREGAR PORDILLEROS
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim form As New frmDespachoFacturaPordilleros
            form.listaEmpleados = listaEmpleados
            form.Text = "Empleados agregados"
            form.StartPosition = FormStartPosition.CenterScreen
            form.WindowState = FormWindowState.Normal
            form.ShowDialog()
            form.Dispose()
            listaEmpleados = mdlPublicVars.superSearchLista2

            lblNoPordilleros.Text = CStr2(listaEmpleados.Count)
            lblPordilleros.Text = ""
            For Each empleado As Tuple(Of Integer, String) In listaEmpleados
                lblPordilleros.Text += empleado.Item2 & ", "
            Next
        Catch

        End Try
    End Sub

#End Region

#Region "Funciones"
    'NUEVO PEDIDO
    Private Sub fnNuevo()
        listaEmpleados = New List(Of Tuple(Of Integer, String))
        txtObservacion.Text = ""
        txtFecha.Text = ""
        ''nm2Costo.Value = 0
        lblPordilleros.Text = ""
        lblNoPordilleros.Text = "#"
    End Sub

    'LLENAR COMBOS
    Private Sub fnLlenarCombos()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim empleados As IQueryable = (From x In conexion.tblEmpleadoes Where x.bitpiloto = True Select codigo = x.idEmpleado, nombre = x.nombre)
            Dim tipostransportes As IQueryable = (From x In conexion.tblTiposTransportes Select codigo = x.idTipoTransporte, nombre = x.descripcion)
            Dim sucursales As iqueryable = (From x In conexion.tblSucursales Select codigo = x.idSucursal, nombre = x.descripcion)

            fnLlenarComboBox(empleados, cmbPiloto)
            fnLlenarComboBox(tipostransportes, cmbTipoTransporte)
            fnLlenarComboBox(sucursales, cmbSucursalSalida)

            conn.Close()
        End Using
    End Sub

    'LLENAR UN COMBOBOX CON DATASOURCE
    Private Sub fnLlenarComboBox(datos As IQueryable, combo As ComboBox)
        With combo
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = datos
        End With
    End Sub

    'LLENAR DATOS
    Private Sub fnLlenarDatos()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim listaSalidasTransportes As New List(Of Integer)
            ' Recorremos el listado de filas de los productos a agregar
            For Each fila As GridViewRowInfo In listaAgregar
                Dim nuevaFila As Object() = {fila.Cells("idSalidaDetalle").Value, fila.Cells("ID").Value, fila.Cells("CodigoProd").Value,
                                            fila.Cells("Producto").Value, fila.Cells("txmCantEnviar").Value}
                Me.grdProductos.Rows.Add(nuevaFila)
                listaSalidasTransportes.Add(CInt(fila.Cells("ID").Value))
            Next

            Dim correlativo As Integer = (From x In conexion.tblSalidasTransportesMedios Select x).Count()

            ' Obtenemos las salidas transportes a agregar
            Dim salidasTransporte As DataTable = EntitiToDataTable(From x In conexion.tblSalidasTransportes Where listaSalidasTransportes.Contains(x.idSalidaTransporte) _
                Select x.idSalidaTransporte, x.idSalida, Cliente = x.tblSalida.cliente, Documento = x.tblSalida.documento, Fecha = x.tblSalida.fechaDespachado,
                Municipio = x.tblSectore.tblMunicipio.nombre, Sector = x.tblSectore.descripcion, Ubicacion = x.direccion, Observacion = x.observacion)

            Me.grdClientes.DataSource = salidasTransporte

            'Configurar el grid de clientes
            If Me.grdClientes.ColumnCount > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdClientes, "Fecha")

                Me.grdClientes.Columns("idSalidaTransporte").IsVisible = False
                Me.grdClientes.Columns("idSalida").IsVisible = False

                For i As Integer = 0 To Me.grdClientes.ColumnCount - 1
                    Me.grdClientes.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdClientes.Columns("Cliente").Width = 20
                Me.grdClientes.Columns("Documento").Width = 10
                Me.grdClientes.Columns("Fecha").Width = 10
                Me.grdClientes.Columns("Municipio").Width = 15
                Me.grdClientes.Columns("Sector").Width = 15
                Me.grdClientes.Columns("Ubicacion").Width = 15
                Me.grdClientes.Columns("Observacion").Width = 15
            End If

            lblCorrelativo.Text = CStr(correlativo + 1)
            conn.Close()
        End Using
    End Sub

    'CAMBIO TIPO TRANSPORTE
    Private Sub cmbTipoVehiculo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoTransporte.SelectedValueChanged
        Dim idTipoTransporte As Integer = CInt(cmbTipoTransporte.SelectedValue)

        If idTipoTransporte > 0 Then
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim transportes As IQueryable = (From x In conexion.tblTransportes Where x.idTipoTransporte = idTipoTransporte Select codigo = x.idTransporte, nombre = x.descripcion)
                fnLlenarComboBox(transportes, cmbTransporte)
                conn.Close()
            End Using
        End If
    End Sub

    'CAMBIO DE TRANSPORTE
    Private Sub cmbTransporte_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTransporte.SelectedValueChanged
        Dim idTransporte As Integer = CInt(cmbTransporte.SelectedValue)
        lblPlaca.Text = ""
        lblKMGalon.Text = ""
        If idTransporte > 0 Then
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim transporte As tblTransporte = (From x In conexion.tblTransportes Where x.idTransporte = idTransporte Select x).FirstOrDefault
                lblPlaca.Text = transporte.placas
                lblKMGalon.Text = CStr(transporte.KMGalon)

                ''Dim kilometros As tblTransporte = (From x In conexion.tblTransportes Where x.idTransporte = idTransporte Select x).fi

                conn.Close()
            End Using
        End If
    End Sub

    'CERRANDO EL FORMULARIO
    Private Sub frmDespachoFacturaAsignar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmDespachoFacturaListaAsignar.frm_llenarLista()
    End Sub

#End Region


    ''Private Sub fnDiferencia()
    ''    Dim costo As Decimal
    ''    Dim cobrado As Decimal
    ''    Dim diferencia As Decimal

    ''    costo = CDec(nm2Costo.Value)
    ''    cobrado = CDec(nm2Cobrado.Value)

    ''    diferencia = costo - cobrado

    ''    Me.txtDiferencia.Text = CStr(diferencia)
    ''End Sub


    ''Private Sub nm2Cobrado_MouseUp(sender As Object, e As MouseEventArgs)
    ''    Me.nm2Cobrado.Maximum = Me.nm2Costo.Value
    ''    fnDiferencia()
    ''End Sub

    ''Private Sub nm2Costo_MouseUp(sender As Object, e As MouseEventArgs)
    ''    Me.nm2Cobrado.Maximum = Me.nm2Costo.Value
    ''    fnDiferencia()
    ''End Sub
End Class