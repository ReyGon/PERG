Option Strict On

Imports Telerik.WinControls
Imports System.Linq
Imports System.Data.EntityClient

Public Class frmVentaPequeniaTransporteAgregar

#Region "Variables"
    Private _listaTransportes As List(Of tblSalidasTransporte)
    Private _bitEditar As Boolean
    Private _indice As Integer
#End Region

#Region "Propiedades"
    Public Property listaTransportes As List(Of tblSalidasTransporte)
        Get
            listaTransportes = _listaTransportes
        End Get
        Set(value As List(Of tblSalidasTransporte))
            _listaTransportes = value
        End Set
    End Property

    Public Property bitEditar As Boolean
        Get
            bitEditar = _bitEditar
        End Get
        Set(value As Boolean)
            _bitEditar = value
        End Set
    End Property

    Public Property indice As Integer
        Get
            indice = _indice
        End Get
        Set(value As Integer)
            _indice = value
        End Set
    End Property

#End Region

#Region "Eventos"
    'LOAD
    Private Sub frmVentaPequeniaTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbCosteo)
        mdlPublicVars.comboActivarFiltro(cmbMunicipio)
        mdlPublicVars.comboActivarFiltro(cmbSucursal)
        fnLlenarCombos()

        Me.cmbSucursal.Enabled = False

        If bitEditar Then
            fnLlenarDatos()
        End If
    End Sub

    'SALIR DEL FORMULARIO
    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub

    'CAMBIO DE SECTOR
    Private Sub cmbMunicipio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMunicipio.SelectedValueChanged
        Dim idSector As Integer = CInt(cmbMunicipio.SelectedValue)
        If idSector > 0 Then
            'Obtener la informacion del sector
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim sector As tblSectoresTiposTransporte = (From x In conexion.tblSectoresTiposTransportes Where x.idSectoresTiposTransporte = idSector Select x).FirstOrDefault
                nm2Precio.Value = CDec(sector.precio)
                nm2PrecioMinimo.Minimum = CDec(sector.preciominimo)
                nm2PrecioMinimo.Value = CDec(sector.preciominimo)
                nm2PrecioMinimo.Maximum = nm2Precio.Value
                conn.Close()
            End Using
        End If

    End Sub

    'AUMENTA O DISMINUYE CANTIDAD
    Private Sub nm2Cantidad_ValueChanged(sender As Object, e As EventArgs) Handles nm2Cantidad.ValueChanged
        Dim idSector As Integer = CInt(cmbMunicipio.SelectedValue)
        If idSector > 0 Then
            fnCalcularTotales()
        End If
    End Sub

    'CAMBIA PRECIO MINIMO
    Private Sub chkPrecioMinimo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrecioMinimo.CheckedChanged
        Dim idsector As Integer = CInt(cmbMunicipio.SelectedValue)
        If idsector > 0 Then
            If chkPrecioMinimo.Checked Then
                nm2PrecioMinimo.Enabled = True
            Else
                nm2PrecioMinimo.Enabled = False
                nm2PrecioMinimo.Value = nm2PrecioMinimo.Minimum
            End If
            fnCalcularTotales()
        End If
    End Sub

    'CAMBIA DE VALOR EN PRECIO MINIMO
    Private Sub nm2PrecioMinimo_ValueChanged(sender As Object, e As EventArgs) Handles nm2PrecioMinimo.ValueChanged
        If chkPrecioMinimo.Checked Then
            fnCalcularTotales()
        End If
    End Sub

    'CLICK AL BOTON PROCESAR
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'OBTENER VARIABLES
        Dim idSectorTransporte As Integer = CInt(cmbMunicipio.SelectedValue)
        Dim idTransporteCosteo As Integer = CInt(cmbCosteo.SelectedValue)
        Dim idSucursal As Integer = CInt(cmbSucursal.SelectedValue)
        Dim direccion As String = txtDireccion.Text
        Dim contacto As String = txtContacto.Text
        Dim telefono As String = txtTelefono.Text
        Dim observacion As String = txtObservacion.Text

        Dim descuento As Decimal = nm2Descuento.Value
        Dim bitDescuento As Boolean = chkPrecioMinimo.Checked
        Dim precio As Decimal = CDec(If(bitDescuento, nm2PrecioMinimo.Value, nm2Precio.Value))
        Dim cantidad As Integer = CInt(nm2Cantidad.Value)
        Dim success As Boolean = True

        'VALIDAR
        If idSectorTransporte <= 0 Then
            RadMessageBox.Show("Debe elegir un sector y el tipo de transporte", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            cmbMunicipio.Focus()
            Exit Sub
        ElseIf idTransporteCosteo <= 0 Then
            RadMessageBox.Show("Debe elegir un tipo de costeo", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            cmbCosteo.Focus()
            Exit Sub
        ElseIf idSucursal <= 0 Then
            RadMessageBox.Show("Debe elegir una sucursal", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            cmbSucursal.Focus()
            Exit Sub
        ElseIf direccion.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar una direccion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            txtDireccion.Focus()
            Exit Sub
        ElseIf contacto.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar un contacto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            txtContacto.Focus()
            Exit Sub
        ElseIf telefono.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar un telefono", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            txtTelefono.Focus()
            Exit Sub
        ElseIf cantidad < 0 Then
            RadMessageBox.Show("Debe ingresar una cantidad valida", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            nm2Cantidad.Focus()
            Exit Sub
        End If

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            'AGREGAR EL TRANSPORTE
            Dim sectorTransporte As tblSectoresTiposTransporte = (From x In conexion.tblSectoresTiposTransportes Where x.idSectoresTiposTransporte = idSectorTransporte
                    Select x).FirstOrDefault

            Dim salidaTransporte As tblSalidasTransporte
            If bitEditar Then
                salidaTransporte = listaTransportes(indice)
            Else
                salidaTransporte = New tblSalidasTransporte
            End If

            salidaTransporte.idTipoTransporte = sectorTransporte.idTipoTransporte
            salidaTransporte.idSector = sectorTransporte.idSector
            salidaTransporte.idSucursal = idSucursal
            salidaTransporte.idTransporteCosteo = idTransporteCosteo
            salidaTransporte.direccion = direccion
            salidaTransporte.observacion = observacion
            salidaTransporte.cantidad = cantidad
            salidaTransporte.precio = precio
            salidaTransporte.bitDescuento = bitDescuento
            salidaTransporte.descuento = descuento
            salidaTransporte.contacto = contacto
            salidaTransporte.telefono = telefono
            salidaTransporte.estado = 0

            If bitEditar Then
                listaTransportes.Item(indice) = salidaTransporte
            Else
                listaTransportes.Add(salidaTransporte)
            End If

            conn.Close()
        End Using

        If success Then
            alerta.fnGuardar()
            If RadMessageBox.Show("¿Desea agregar otro transporte?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnNuevo()
            Else
                Me.Close()
            End If
        End If
    End Sub
#End Region

#Region "Funciones"
    'EDITAR TRANSPORTE
    Private Sub fnLlenarDatos()
        Dim salidaTransporte As tblSalidasTransporte = listaTransportes.Item(indice)
        Dim conexion As dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim sectorTipoTransporte As tblSectoresTiposTransporte = (From x In conexion.tblSectoresTiposTransportes.AsEnumerable
                                                                      Where x.idSector = salidaTransporte.idSector And x.idTipoTransporte = salidaTransporte.idTipoTransporte Select x).FirstOrDefault
            'tblSectoresTiposTransportes

            cmbSucursal.SelectedValue = salidaTransporte.idSucursal
            cmbCosteo.SelectedValue = salidaTransporte.idTransporteCosteo
            cmbMunicipio.SelectedValue = sectorTipoTransporte.idSectoresTiposTransporte
            txtDireccion.Text = salidaTransporte.direccion
            nm2Cantidad.Value = CDec(salidaTransporte.cantidad)
            chkPrecioMinimo.Checked = CBool(salidaTransporte.bitDescuento)
            nm2PrecioMinimo.Value = CDec(salidaTransporte.precio)
            txtContacto.Text = salidaTransporte.contacto
            txtTelefono.Text = salidaTransporte.telefono
            txtObservacion.Text = salidaTransporte.observacion

            conn.Close()
        End Using


    End Sub

    'NUEVO TRANSPORTE
    Private Sub fnNuevo()
        txtDireccion.Text = ""
        txtContacto.Text = ""
        txtTelefono.Text = ""
        txtObservacion.Text = ""
        chkPrecioMinimo.Checked = False
    End Sub

    'LLENAR LOS COMBOS
    Private Sub fnLlenarCombos()
        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim costeos As IQueryable = (From x In conexion.tblTransporteCosteos Select codigo = x.idTransporteCosteo, nombre = x.descripcion)

            Dim municipios As IQueryable = (From y In (From x In conexion.tblSectoresTiposTransportes Select codigo = x.idSectoresTiposTransporte,
                nombre = String.Concat(x.tblSectore.tblMunicipio.tbldepartamento.nombre, " - ", x.tblSectore.tblMunicipio.nombre), _
                nombre2 = String.Concat(x.tblSectore.descripcion, " - ", x.tblTiposTransporte.descripcion) Order By nombre Ascending) _
                Select codigo = y.codigo, nombre = String.Concat(y.nombre, " - ", y.nombre2))

            Dim sucursales As IQueryable = (From x In conexion.tblSucursales Where x.idEmpresa = mdlPublicVars.idEmpresa And x.bitDefault = True _
                Select codigo = x.idSucursal, nombre = x.descripcion Order By nombre Ascending)

            With cmbCosteo
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = costeos
            End With

            With cmbMunicipio
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = municipios
            End With

            With cmbSucursal
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = sucursales
            End With

            conn.Close()
        End Using
    End Sub

    'CALCULAR TOTALES
    Private Sub fnCalcularTotales()
        Dim cantidad As Integer = CInt(nm2Cantidad.Value)
        nm2Total.Value = nm2Cantidad.Value * nm2Precio.Value
        nm2Descuento.Value = 0
        If chkPrecioMinimo.Checked Then
            nm2TotalFinal.Value = nm2Cantidad.Value * nm2PrecioMinimo.Value
            nm2Descuento.Value = nm2Total.Value - nm2TotalFinal.Value
        Else
            nm2TotalFinal.Value = nm2Total.Value
        End If
    End Sub
#End Region

End Class