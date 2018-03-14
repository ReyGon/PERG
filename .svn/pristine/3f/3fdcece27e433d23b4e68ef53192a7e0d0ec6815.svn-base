Imports System.Linq
Imports Telerik.WinControls

Public Class frmCajaMovimiento

    Private Sub frmCajaMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarCombo()
    End Sub


    'Funcion utilizada para llenar el combo de conceptos
    Private Sub fnLlenarCombo()
        Dim concepto = (From x In ctx.tblTipoPagoes Where x.caja Select x.codigo, x.nombre)

        With cmbConcepto
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = concepto
        End With
    End Sub

    'Funcion utilizada para guardar el movimiento de caja
    Private Sub fnGuardarMovimiento()
        Try
            'Variables
            Dim hora = fnHoraServidor()
            Dim fechaServer As DateTime = fnFecha_horaServidor()
            Dim tipoPago As Integer = CInt(cmbConcepto.SelectedValue)

            'Creamos el nuevo movimiento
            Dim movimiento As New tblCaja

            'Obtenemos el tipo de pago
            Dim pago As tblTipoPago = (From x In ctx.tblTipoPagoes.AsEnumerable Where x.codigo = tipoPago Select x).FirstOrDefault

            movimiento.fecha = dtpFecha.Text & " " & hora
            movimiento.fechaTransaccion = fechaServer
            movimiento.fechaCobro = movimiento.fecha
            movimiento.anulado = False
            movimiento.descripcion = pago.nombre
            movimiento.documento = txtDocumento.Text
            movimiento.empresa = mdlPublicVars.idEmpresa
            movimiento.monto = nm2Monto.Value
            movimiento.tipoPago = tipoPago
            If pago.cuenta IsNot Nothing Then
                movimiento.cuenta = pago.cuenta
                movimiento.numeroCuenta = pago.tblBanco_Cuenta.numeroCuenta
            End If
            movimiento.observacion = txtObservacion.Text
            movimiento.usuario = mdlPublicVars.idUsuario
            If pago.calendarizada Then
                movimiento.transito = 1
                movimiento.confirmado = 0
            Else
                movimiento.transito = 0
                movimiento.confirmado = 1
            End If

            ctx.AddTotblCajas(movimiento)
            ctx.SaveChanges()

            alerta.fnGuardar()

            If RadMessageBox.Show("¿Desea realizar otro movimiento de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnNuevo()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'GUARDAR
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Not fnErrores() Then
            If RadMessageBox.Show("¿Desea guardar el movimiento de caja?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnGuardarMovimiento()
            End If
        End If
    End Sub

    'Errores
    Private Function fnErrores() As Boolean
        'Verificamos si hay concepto
        If Not (CInt(cmbConcepto.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir un concepto", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Return True
        End If

        'Verificamos que el monto sea mayor a 0(cero)
        If Not (nm2Monto.Value > 0) Then
            RadMessageBox.Show("El monto ingresado debe ser mayor a 0(cero)", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Return True
        End If

        Return False
    End Function

    'NUEVO
    Private Sub fnNuevo() Handles Me.panel0
        txtDocumento.Text = ""
        txtObservacion.Text = ""
        nm2Monto.Value = 0
        dtpFecha.Value = Today
        cmbConcepto.SelectedValue = Nothing
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

   
End Class