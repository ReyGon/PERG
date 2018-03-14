Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmEntradaMovimiento

    Private Sub frmEntradaMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenarCombos()
        fnLlenarGrid()
        fnConfiguracion()
    End Sub

    Private Sub grdDatos_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdDatos.CellFormatting
        base.fnFormato(sender, e)
    End Sub

    Private Sub fnLlenarCombos()
        'Dim datos As New DataTable
        'datos.Columns.Add("Codigo")
        'datos.Columns.Add("Nombre")
        'datos.Rows.Add("0", "Todos...")
        'Dim proveedores = (From x In ctx.tblProveedors Select codigo = x.idProveedor, nombre = x.negocio)
        'Dim prov

        'For Each prov In proveedores
        '    datos.Rows.Add(CType(prov.codigo, Integer), prov.nombre)
        'Next

        'With Me.cmbProveedores
        '    .DataSource = Nothing
        '    .ValueMember = "Codigo"
        '    .DisplayMember = "Nombre"
        '    .DataSource = datos
        'End With

    End Sub

    Private Sub fnLlenarGrid()
        Dim fechai As DateTime = dtpFechaInicio.Text + " 00:00:00"
        Dim fechaf As DateTime = dtpFechaFin.Text + " 23:59:59"
        'Dim prov As Integer = CType(cmbProveedores.SelectedValue, Integer)

        Dim consulta = (From x In ctx.tblEntradas Where (x.fechaRegistro > fechai And x.fechaRegistro < fechaf) And x.anulado = False _
                       Select ID = x.idEntrada, Fecha = x.fechaRegistro, Clave = x.tblProveedor.idProveedor, Proveedor = x.tblProveedor.negocio, _
                        Documento = x.documento, Monto = x.total, Pagos = x.pagos, Saldo = x.saldo, _
                        clrEstado = CType(If(x.cancelado = False, "1", If(x.cancelado = True, "4", "0")), Int32))

        Me.grdDatos.DataSource = consulta
    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                fnGridTelerik_formatoMoneda(Me.grdDatos, "Monto")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pbBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBuscar.Click, lblBuscar.Click
        fnLlenarGrid()
    End Sub

    Private Sub pbModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbModificar.Click
        Try
            Dim idEntrada As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("ID").Value, Double)
            Dim saldo = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Saldo").Value
            If saldo Is Nothing Then
                Dim idproveedor As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("Clave").Value, Double)
                frmPagoNuevo.Text = "Modulo de Compras"
                frmPagoNuevo.bitProveedor = True
                frmPagoNuevo.bitCliente = False
                frmPagoNuevo.bitSalida = False
                frmPagoNuevo.bitEntrada = False

                frmPagoNuevo.codigoCP = idproveedor
                frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                frmPagoNuevo.ShowDialog()
            Else
                If saldo > 0 Then


                    frmPagoNuevo.Text = "Modulo de Compras"
                    frmPagoNuevo.bitSalida = True
                    frmPagoNuevo.bitProveedor = False
                    frmPagoNuevo.bitCliente = False
                    frmPagoNuevo.bitEntrada = False
                    frmPagoNuevo.lblSaldo.Text = saldo.ToString
                    frmPagoNuevo.codigoES = idEntrada
                    frmPagoNuevo.StartPosition = FormStartPosition.CenterScreen
                    frmPagoNuevo.ShowDialog()

                Else
                    alerta.contenido = "Compra ya ha sido cancelada"
                    alerta.fnErrorContenido()
                End If
            End If


        Catch ex As Exception

        End Try

        fnLlenarGrid()
    End Sub

    Private Sub fnAnularEntrada()
        Dim success As Boolean = True

        '-------------------Creamos el encabezado de la compra------------'
        Using transaction As New TransactionScope
            Try
                'Primero anulamos la entrada
                Dim idEntrada As Integer = CType(Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells("ID").Value, Integer)
                Dim entrada As tblEntrada = (From x In ctx.tblEntradas Where x.idEntrada = idEntrada Select x).FirstOrDefault

                entrada.anulado = 1
                ctx.SaveChanges()

                'Si la entrada fue al credito entonces...
                If entrada.credito = True Then

                    'Anulamos la cuenta por pagar del proveedor
                    Dim ctaPagar As tblCtaPagar = (From x In ctx.tblCtaPagars Where x.idEntrada = entrada.idEntrada Select x).FirstOrDefault
                    ctaPagar.anulado = 1

                    ctx.SaveChanges()

                    'Reasignamos los saldos y pagos al proveedor
                    Dim listaCuentas As List(Of tblCtaPagar) = (From x In ctx.tblCtaPagars.AsEnumerable Where x.anulado = False Select x).ToList
                    Dim cta As tblCtaPagar

                    Dim nuevoSaldo As Double = 0
                    Dim nuevoPago As Double = 0

                    For Each cta In listaCuentas
                        nuevoSaldo += cta.saldo
                        nuevoSaldo += cta.pagado
                    Next

                    'Buscamos al proveedor, y le modificamos su saldo y sus pagos
                    Dim proveedor As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = entrada.idProveedor Select x).FirstOrDefault
                    proveedor.saldoActual = nuevoSaldo
                    proveedor.pagos = nuevoPago

                    ctx.SaveChanges()
                    'Si la entrada fue al contado entonces
                ElseIf entrada.contado = True Then
                    'Anulamos los pagos hechos a la compra
                    Dim listaPagos As List(Of tblCaja) = (From x In ctx.tblCajas Where x.codigoSalida = entrada.idEntrada And x.anulado = False Select x).ToList
                    Dim pago As tblCaja

                    For Each pago In listaPagos
                        pago.anulado = 1
                    Next
                    ctx.SaveChanges()
                End If



                'paso 8, completar la transaccion.
                transaction.Complete()
            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    success = False
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alerta.contenido = "Compra anulada correctamente"
            alerta.fnGuardar()
            fnLlenarGrid()
        Else

            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub

    Private Sub pbReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReporte.Click, lblAnular.Click
        fnAnularEntrada()
    End Sub
End Class
