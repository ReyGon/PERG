Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmGuiasLista
    Private _bitFactura As Boolean
    Private _bitCompra As Boolean
    Private _bitDevolucionCliente As Boolean
    Private _bitDevolucionProveedor As Boolean
    Private permiso As New clsPermisoUsuario
    Public Property bitFactura As Boolean
        Get
            bitFactura = _bitFactura
        End Get
        Set(ByVal value As Boolean)
            _bitFactura = value
        End Set
    End Property

    Public Property bitCompra As Boolean
        Get
            bitCompra = _bitCompra
        End Get
        Set(ByVal value As Boolean)
            _bitCompra = value
        End Set
    End Property

    Public Property bitDevolucionCliente As Boolean
        Get
            bitDevolucionCliente = _bitDevolucionCliente
        End Get
        Set(ByVal value As Boolean)
            _bitDevolucionCliente = value
        End Set
    End Property

    Public Property bitDevolucionProveedor As Boolean
        Get
            bitDevolucionProveedor = _bitDevolucionProveedor
        End Get
        Set(ByVal value As Boolean)
            _bitDevolucionProveedor = value
        End Set
    End Property

    Public registroActual As Integer = 0

    Private Sub frmPedidosLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion

        Try
            If bitDevolucionCliente Then
                Dim iz As New frmClientesBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            ElseIf bitFactura Then
                Dim iz As New frmPedidosFacturasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
                frmBarraLateralBaseDerecha = frmPedidosListaBarraDerecha
            ElseIf bitDevolucionProveedor Or bitCompra Then
                Dim iz As New frmComprasBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
            End If

            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        llenagrid()
    End Sub

    Private Sub llenagrid()
        Try
            Dim consulta = Nothing
            Dim filtro As String = txtFiltro.Text

            If bitFactura Then
                'Codigo,Fecha, Cliente,Numero,Paquetes,TipoEnvio,Factura,Observacion,Usuario
                consulta = (From x In ctx.tblSalidas Join y In ctx.tblEnvio_Salida On x.idSalida Equals y.salida _
                               Where x.cliente.Contains(filtro) Or x.tblUsuario.nombre.Contains(filtro)
                               Group By idFactura = x.IdFactura, Codigo = y.codigo, Fecha = y.tblEnvio.fechatransaccion, Cliente = x.tblCliente.Negocio, _
                               Numero = y.tblEnvio.numero, Paquetes = y.tblEnvio.paquetes, TipoEnvio = y.tblEnvio.tblEnvioTipo.nombre, Factura = x.documentoFactura, _
                               Observacion = y.tblEnvio.observacion, Usuario = x.tblUsuario.nombre, Precio = y.tblEnvio.precio, Empresa = y.tblEnvio.tblEnvio_Empresa.nombre
                               Into Group _
                               Select Codigo, Fecha, Cliente, Numero, Paquetes, TipoEnvio, Precio, Factura, Empresa, Observacion, Usuario _
                               Order By Fecha Descending)
            ElseIf bitCompra Then
                consulta = (From x In ctx.tblEnvio_Entrada _
                            Where x.tblEntrada.tblProveedor.negocio.Contains(filtro) And x.tblEnvio.numero.Contains(filtro)
                            Select Codigo = x.codigo, Fecha = x.tblEnvio.fechatransaccion, Proveedor = x.tblEntrada.tblProveedor.negocio, Numero = x.tblEnvio.numero, _
                            Paquetes = x.tblEnvio.paquetes, TipoEnvio = x.tblEnvio.tblEnvioTipo.nombre, Precio = x.tblEnvio.precio, Compra = x.tblEntrada.documento, _
                            Observacion = x.tblEnvio.observacion, Usuario = x.tblEnvio.tblUsuario.nombre)
            ElseIf bitDevolucionCliente Then
                consulta = (From x In ctx.tblEnvio_DevolucionCliente _
                            Where x.tblDevolucionCliente.tblCliente.Negocio.Contains(filtro) And x.tblEnvio.tblUsuario.nombre.Contains(filtro)
                           Select Codigo = x.codigo, Fecha = x.tblEnvio.fechatransaccion, Cliente = x.tblDevolucionCliente.tblCliente.Negocio, Numero = x.tblEnvio.numero, _
                            Paquetes = x.tblEnvio.paquetes, TipoEnvio = x.tblEnvio.tblEnvioTipo.nombre, Precio = x.tblEnvio.precio, Devolucion = x.tblDevolucionCliente.documento, _
                            Observacion = x.tblEnvio.observacion, Usuario = x.tblEnvio.tblUsuario.nombre)
            ElseIf bitDevolucionProveedor Then
                consulta = (From x In ctx.tblEnvio_DevolucionProveedor _
                            Where x.tblDevolucionProveedor.tblProveedor.negocio.Contains(filtro) And x.tblEnvio.tblUsuario.nombre
                           Select Codigo = x.codigo, Fecha = x.tblEnvio.fechatransaccion, Proveedor = x.tblDevolucionProveedor.tblProveedor.negocio, Numero = x.tblEnvio.numero, _
                            Paquetes = x.tblEnvio.paquetes, TipoEnvio = x.tblEnvio.tblEnvioTipo.nombre, Precio = x.tblEnvio.precio, Devolucion = x.tblDevolucionProveedor.documento, _
                            Observacion = x.tblEnvio.observacion, Usuario = x.tblEnvio.tblUsuario.nombre)
            End If

            Me.grdDatos.DataSource = consulta
            mdlPublicVars.fnGrid_iconos(Me.grdDatos)

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            fnConfiguracion()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
        fnCambioFila()
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Columns.Count > 0 Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Precio")
                Me.grdDatos.Columns("Codigo").IsVisible = False

                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next
                'Codigo,Fecha, Cliente,Numero,Paquetes,TipoEnvio,Factura,Observacion,Usuario
                Me.grdDatos.Columns("Codigo").Width = 55
                Me.grdDatos.Columns("Fecha").Width = 60

                If bitFactura Or bitDevolucionCliente Then
                    Me.grdDatos.Columns("Cliente").Width = 120
                Else
                    Me.grdDatos.Columns("Proveedor").Width = 120
                End If

                If bitFactura Then
                    Me.grdDatos.Columns("Factura").Width = 60
                ElseIf bitCompra Then
                    Me.grdDatos.Columns("Compra").Width = 60
                Else
                    Me.grdDatos.Columns("Devolucion").Width = 60
                End If


                Me.grdDatos.Columns("Numero").Width = 60
                Me.grdDatos.Columns("Paquetes").Width = 80
                Me.grdDatos.Columns("TipoEnvio").Width = 80
                Me.grdDatos.Columns("Precio").Width = 70

                Me.grdDatos.Columns("Observacion").Width = 160
                Me.grdDatos.Columns("Usuario").Width = 80
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.CurrentRow.Index >= 0 Then
                mdlPublicVars.superSearchId = CType(Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Codigo").Value, Integer)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        RadMessageBox.Show("Para crear una nueva guia dirigase al Modulo de FACTURAS", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        RadMessageBox.Show("Para eliminar una nueva guia dirigase al Modulo de FACTURAS", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                RadMessageBox.Show("Para modificar una nueva guia dirigase al Modulo de FACTURAS", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmSalir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Guias de: " & If(bitFactura, "Facturas", If(bitCompra, _
                                            "Compras", If(bitDevolucionCliente, "Devoluciones de Clientes", _
                                            If(bitDevolucionProveedor, "Devolucion de Proveedor", ""))))
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
