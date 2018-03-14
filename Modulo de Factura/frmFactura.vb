Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI

Public Class frmFactura
    Public codigoCliente As Integer
    Public codSalida As Integer
    Private permiso As New clsPermisoUsuario

    'Evento principal del formulario
    Private Sub frmFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdProductos.ImageList = frmControles.ImageListAdministracion
        mdlPublicVars.fnFormatoGridMovimientos(grdProductos)
        'iniciamos la etiqueta de totales a 0
        lblTotalPagar.Text = 0
        fnLlenarDatos()

    End Sub

    'Funcion utilizada para llenar los datos del cliente
    Private Sub fnLlenarDatos()
        Try
            'Obtenemos la informacion de cliente
            Dim cliente As tblCliente = (From x In ctx.tblClientes.AsEnumerable Where x.idCliente = codigoCliente Select x).FirstOrDefault
            lblCliente.Text = cliente.Negocio
            lblClave.Text = cliente.idCliente
            lblSaldoCliente.Text = Format(cliente.saldo)
            LlenarGrid()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Procedimiento que busca los clientes Que cuenten con salidas en las fechas seleccionadas, y que no hayan sido facturas.
    Private Sub CargarClientes()
        Try

            'Buscamos los clientes que tengan registros en salida y que estos a la vez no hayan sido facturados...
            Dim DataCliente = From x In ctx.tblSalidas _
                              Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa _
                              Select Nombre = x.tblCliente.Negocio, Codigo = x.tblCliente.idCliente Distinct Order By Nombre Ascending


            'Mostrar los datos encontrados en el combo de clientes...
            'With cmbCliente
            '    .DataSource = Nothing
            '    .ValueMember = "Codigo"
            '    .DisplayMember = "Nombre"
            '    .DataSource = DataCliente
            'End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Procedimiento que busca los registros de salida en base al cliente seleccionado.
    Private Sub LlenarGrid()
        'Variable para guardar el codigo del cliente que está seleccionada en el combo y se crea el objeto para guardar la consulta.
        Dim codClie As Integer = codigoCliente

        Dim DataGrid

        Try
            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codSalida Select x).FirstOrDefault
            'Consultamos todos los registros de la salida del cliente seleccionada en el combo, los que no han sido facturados.

            DataGrid = (From x In ctx.tblSalidas _
                           Where x.idEmpresa = mdlPublicVars.idEmpresa And x.idCliente = codClie And x.cliente = salida.cliente And x.nit = salida.nit And x.direccionEnvio = salida.direccionEnvio _
                           And x.facturado = False And x.empacado = True And x.anulado = False _
                           Select Codigo = x.idSalida,
                           Fecha = x.fechaRegistro, Cliente = x.cliente, Nit = x.nit, Documento = x.documento, Pagos = If(x.contado = True, "Contado", "Credito"),
                           DireccionEnvio = x.direccionEnvio, _
                           DireccionFacturacion = x.direccionFacturacion, Vendedor = x.tblVendedor.nombre,
                           Total = x.total, clrEstado = 0, Estado = "Revisado", Clave = codClie)


            'Convertimos el Ojeto "DataGrid con EntitiToDataTable   a Tabla y luego pasarselo al Gridproductos.
            grdProductos.DataSource = EntitiToDataTable(DataGrid)
            Me.grdProductos.Columns("DireccionFacturacion").HeaderText = "Direccion de Facturacion"
            Me.grdProductos.Columns("DireccionEnvio").HeaderText = "Direccion de Envio"

            fnConfiguracion()
            mdlPublicVars.fnIndicadores(grdProductos, Me.grdProductos.Columns("clrEstado").Index)
        Catch ex As Exception
        End Try

    End Sub

    'Se carga el total de las salidas que están seleccionados(usando el combo de la primera columna) y se muestra en la etiqueta superior Derecha.
    Public Sub ObtieneTotalPagar()
        'Variables para guardar el total para luego mostrar en la Label Total a Pagar.
        Dim total As Decimal = 0

        'Revisamos cada fila del grid, si la columna de CheckBox esta seleccionada, sumamos el total para obtener el Total a pagar.
        For i As Integer = 0 To grdProductos.Rows.Count - 1
            'Si esta Activado el Checkbox guardamos el total de la fila seleccionada.
            If grdProductos.Rows(i).Cells(0).Value = True Then
                total = total + grdProductos.Rows(i).Cells(10).Value
            End If
        Next

        'mostramos el Total a pagar para la factura, en la label que se ubica en la parte superior...
        If total = 0 Then
            lblTotalPagar.Text = 0
        Else
            lblTotalPagar.Text = Format(total, mdlPublicVars.formatoMoneda)
        End If

    End Sub

    'Cuando se cambia el valor de alguna celda en el grid... se obtiene el evento y se manda a llamar al procedimiento ObtieneTotalPagar
    Private Sub grdProductos_CellValueChanged(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdProductos.CellValueChanged
        Dim indice As Integer = e.RowIndex
        lblClave.Focus()
        lblClave.Select()
        ObtieneTotalPagar()
        grdProductos.Focus()
        grdProductos.Rows(indice).Cells(0).IsSelected = True
    End Sub

    'Cuando se preciona un click con el mouse en el grid... se obtiene el evento y se manda a llamar al procedimiento ObtieneTotalPagar
    Private Sub grdProductos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdProductos.MouseClick
        Try
            Dim indice As Integer = grdProductos.CurrentRow.Index
            lblClave.Focus()
            lblClave.Select()
            ObtieneTotalPagar()
            grdProductos.Focus()
            grdProductos.Rows(indice).Cells(0).IsSelected = True
        Catch ex As Exception
            alerta.fnErrorRequiereInformacion()
        End Try
    End Sub

    'Cuando se termina de escribir o modificar una celda en el grid... se obtiene el evento y se manda a llamar al procedimiento ObtieneTotalPagar
    Private Sub grdProductos_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.ValueChanged
        Dim indice As Integer = grdProductos.CurrentRow.Index
        lblClave.Focus()
        lblClave.Select()
        ObtieneTotalPagar()
        grdProductos.Focus()
        grdProductos.Rows(indice).Cells(0).IsSelected = True

    End Sub

    'Funcion utilizada para llamar al formulario de facturar
    Private Sub fnFacturar()
        Try
            'Vaciamos la tabla con los codigos
            mdlPublicVars.General_CodigoSalida.Rows.Clear()

            Dim activas As Integer = 0
            Dim facturar As Boolean = False
            Dim codigo As Integer = 0
            Dim fecha As DateTime = Nothing
            Dim documento As String = ""
            Dim vendedor As String = ""
            Dim total As Decimal = 0
            Dim direccion As String = ""
            Dim tipo As String = ""

            'Recorremos el grid, y verificamos si esta activada la casilla
            For i As Integer = 0 To Me.grdProductos.RowCount - 1
                facturar = Me.grdProductos.Rows(i).Cells("chkAgregar").Value
                codigo = Me.grdProductos.Rows(i).Cells("Codigo").Value
                fecha = Me.grdProductos.Rows(i).Cells("Fecha").Value
                documento = Me.grdProductos.Rows(i).Cells("Documento").Value
                vendedor = Me.grdProductos.Rows(i).Cells("Vendedor").Value
                total = Me.grdProductos.Rows(i).Cells("Total").Value
                direccion = Me.grdProductos.Rows(i).Cells("DireccionFacturacion").Value
                If facturar = True Then
                    mdlPublicVars.General_CodigoSalida.Rows.Add(codigo, Format(fecha, mdlPublicVars.formatoFecha), documento, vendedor, Format(total, mdlPublicVars.formatoMoneda))
                    tipo = Me.grdProductos.Rows(i).Cells("Pagos").Value
                    activas += 1
                End If
            Next

            If activas > 0 Then
                Dim totalFacturas As Decimal = mdlPublicVars.fnTotalTablaFacturas

                mdlPublicVars.GuardarFacturacion(codSalida)

                frmFacturaImprimir.Text = "Facturar"
                If tipo = "Contado" Then
                    frmFacturaImprimir.bitContado = True
                    frmFacturaImprimir.bitCredito = False
                Else
                    frmFacturaImprimir.bitContado = False
                    frmFacturaImprimir.bitCredito = True
                End If
                Me.Close()
                'frmFacturaImprimir.codClie = Me.codigoCliente
                'frmFacturaImprimir.dirFact = direccion
                'frmFacturaImprimir.StartPosition = FormStartPosition.CenterScreen
                'permiso.PermisoDialogEspeciales(frmFacturaImprimir)
                'frmFacturaImprimir.Dispose()
            Else
                alerta.contenido = "Debe seleccionar al menos una venta"
                alerta.fnErrorContenido()
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub fnConfiguracion()
        'Asignamos la columna Agregar (Con los CheckBox) como de lectura y escritura "Editable"
        'Me.grdProductos.Columns("Agregar").ReadOnly = False
        Me.grdProductos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        Me.grdProductos.Columns("chkAgregar").Width = 100

        Me.grdProductos.Columns("Estado").IsVisible = False
        Me.grdProductos.Columns("Clave").IsVisible = False
        Me.grdProductos.Columns("Codigo").IsVisible = False

        Me.grdProductos.Columns(0).Width = 50 ' Agregar
        Me.grdProductos.Columns(2).Width = 50 ' fecha
        Me.grdProductos.Columns(3).Width = 130 ' cliente
        Me.grdProductos.Columns(4).Width = 50 ' nit
        Me.grdProductos.Columns(5).Width = 55 ' documento
        Me.grdProductos.Columns(6).Width = 50 ' pagos
        Me.grdProductos.Columns(7).Width = 130 ' direccion de envio
        Me.grdProductos.Columns(8).Width = 130 ' direccion de facturacion
        Me.grdProductos.Columns(9).Width = 65 ' vende
        Me.grdProductos.Columns(10).Width = 60 ' total
        Me.grdProductos.Columns(11).Width = 30 ' estado
        Me.grdProductos.Columns(12).Width = 40 ' estado
        'Me.grdProductos.Columns(6).Width =  ' codclie


        For i As Integer = 0 To Me.grdProductos.ColumnCount - 1
            Me.grdProductos.Columns(i).ReadOnly = True
        Next

        Me.grdProductos.Columns(0).ReadOnly = False

        mdlPublicVars.fnGridTelerik_formatoFecha(grdProductos, "Fecha")
        mdlPublicVars.fnGridTelerik_formatoMoneda(grdProductos, "Total")
        Me.grdProductos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        Me.grdProductos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        Me.grdProductos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        Me.grdProductos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        Me.grdProductos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter


    End Sub

    Private Function fnAnalizaDirecciones() As Boolean
        Try
            Dim direcciones As New ArrayList
            Dim diferentes As Boolean = False
            Dim direccionInicial As String
            'Verificamos si existe una salida seleccionada para procedeer a facturar..
            For i As Integer = 0 To grdProductos.Rows.Count - 1
                'MsgBox("Valor:  " & grdProductos.Rows(i).Cells(0).Value.ToString)
                'Si está seleccionada el checkbox de la primera celda, aumentar el contador para dar a conocer que hubo un registro seleccionado.
                If grdProductos.Rows(i).Cells(0).Value = True Then
                    direcciones.Add(Me.grdProductos.Rows(i).Cells("DireccionFacturacion").Value)
                End If
            Next

            direccionInicial = direcciones.Item(0)

            For contador As Integer = 1 To direcciones.Count - 1
                If direccionInicial <> direcciones.Item(contador) Then
                    diferentes = True
                    Return diferentes
                End If
            Next

        Catch ex As Exception

        End Try


       
    End Function

    'Funcion utilizada para analizar si los pedidos seleccionados son del mismo tipo de pago

    Private Function fnAnalizaTipos() As Boolean


        Dim diferentes As Boolean = False

        Try
            Dim direcciones As New ArrayList

            Dim direccionInicial As String
            'Verificamos si existe una salida seleccionada para procedeer a facturar..
            For i As Integer = 0 To grdProductos.Rows.Count - 1
                'MsgBox("Valor:  " & grdProductos.Rows(i).Cells(0).Value.ToString)
                'Si está seleccionada el checkbox de la primera celda, aumentar el contador para dar a conocer que hubo un registro seleccionado.
                If grdProductos.Rows(i).Cells(0).Value = True Then
                    direcciones.Add(Me.grdProductos.Rows(i).Cells("Pagos").Value)
                End If
            Next

            direccionInicial = direcciones.Item(0)

            For contador As Integer = 1 To direcciones.Count - 1
                If direccionInicial <> direcciones.Item(contador) Then
                    diferentes = True

                End If
            Next
        Catch ex As Exception

        End Try


        'Agregamor el retrun ak 
        Return diferentes

    End Function

    Private Sub pbx0Facturar_Click() Handles Me.panel0
        Try
            If fnAnalizaDirecciones() = False Then
                If fnAnalizaTipos() = False Then
                    'Llamamos al procedimiento que permite guardar la facturacion de las salidas seleccionadas.
                    fnFacturar()
                Else
                    alerta.contenido = "Debe elegir, pedidos que tengan el mismo tipo de pago"
                    alerta.fnErrorContenido()
                End If
            Else
                alerta.contenido = "Debe elegir, pedidos que tengan las mismas direcciones de facturacion"
                alerta.fnErrorContenido()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub grdProductos_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdProductos.CellFormatting
        base.fnFormato(sender, e)
    End Sub

End Class
