Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmAjustesBancarios

    Private Sub frmAjustesBancarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fnLlenarCombo()
            fnNuevo()
        Catch ex As Exception
        End Try
    End Sub

    'Nuevo
    Private Sub fnNuevo()
        txtMonto.Text = " "
        txtTransaccion.Text = " "
        rbtAjustes.Checked = True
    End Sub

    'Boton Salir
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub fnCargarCombos()
        Try
            If Me.rbtAjustes.Checked = True Then
                Me.cmbBancos.Enabled = False
                Me.cmbCuentas2.Enabled = False
                Me.lblotrosal.Enabled = False
            End If

            If Me.rbtTransferencia.Checked = True Then
                Me.cmbBancos.Enabled = True
                Me.cmbCuentas2.Enabled = True
                Me.lblotrosal.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtAjustes_chekedChanged(sender As Object, e As EventArgs) Handles rbtAjustes.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtTransferencia_chekedChanged(sender As Object, e As EventArgs) Handles rbtTransferencia.CheckedChanged
        Try
            fnCargarCombos()
        Catch ex As Exception

        End Try
    End Sub

    'Llenar Combos
    Private Sub fnLlenarCombo()

        Dim Bancos = Nothing
        Dim Bancos2 = Nothing
        Dim Ajustes = Nothing

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                'Bancos
                Bancos = (From x In conexion.tblBancoes
                          Select codigo = x.idbanco, x.nombre)

                With cmbBanco
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = Bancos
                End With

                'Bancos 2

                Bancos2 = (From x In conexion.tblBancoes
                           Select codigo = x.idbanco, x.nombre)

                With cmbBancos
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = Bancos2
                End With


                'Ajustes 

                Ajustes = (From x In conexion.tblconcepto_ajustebancario Where x.habilitado
                           Select codigo = x.idconcepto, nombre = x.concepto)

                With cmbAjuste
                    .DataSource = Nothing
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .DataSource = Ajustes
                End With

            Catch ex As Exception

            End Try
            conn.Close()
        End Using

    End Sub

    'Combo de Bancos y Cuentas
    Private Sub cmbBanco_selectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedValueChanged

        'Conexion Nueva
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
            Try

                'Obtenemos el codigo del banco
                Dim idBanco As Integer = CInt(cmbBanco.SelectedValue)

                If idBanco > 0 Then
                    'Obtenemos todas las cuetnas de ese banco
                    Dim Cuentas = (From x In conexion.tblBanco_Cuenta Where x.banco = idBanco _
                                   Select x.codigo, nombre = x.descripcion)

                    With cmbCuenta
                        .DataSource = Nothing
                        .ValueMember = "codigo"
                        .DisplayMember = "Nombre"
                        .DataSource = Cuentas
                    End With
                Else
                    cmbCuenta.DataSource = Nothing
                End If

            Catch ex As Exception
                conn.Close()
            End Try

        End Using
    End Sub

    'Combo de Bancos y Cuentas cuando sea la opcion de traslado
    Private Sub cmbBancos_selectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBancos.SelectedValueChanged

        'Conexion Nueva
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)
            Try

                'Obtenemos el codigo del banco
                Dim idBanco As Integer = CInt(cmbBancos.SelectedValue)

                If idBanco > 0 Then
                    'Obtenemos todas las cuetnas de ese banco
                    Dim Cuentas = (From x In conexion.tblBanco_Cuenta Where x.banco = idBanco _
                                   Select x.codigo, nombre = x.descripcion)

                    With cmbCuentas2
                        .DataSource = Nothing
                        .ValueMember = "codigo"
                        .DisplayMember = "Nombre"
                        .DataSource = Cuentas
                    End With
                Else
                    cmbCuentas2.DataSource = Nothing
                End If

            Catch ex As Exception
                conn.Close()
            End Try

        End Using
    End Sub

    'Combo de cuentas para la obtencion de saldos
    Private Sub cmbCuenta_selectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuenta.SelectedValueChanged

        'Conexion nueva
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                Dim codigo As Integer = CInt(cmbCuenta.SelectedValue)

                Dim s As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = codigo Select x).FirstOrDefault

                If s.saldo <> 0 Then
                    lblSaldo.Text = Format(s.saldo, mdlPublicVars.formatoMoneda)
                Else
                    lblSaldo.Text = 0
                End If

            Catch ex As Exception

            End Try
            conn.Close()

        End Using
    End Sub

    'Combo de cuentas para la obtencion de saldos cuando sea traslado

    Private Sub cmbCuentas_selectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Conexion nueva
        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Try
                Dim codigo As Integer = CInt(cmbCuentas2.SelectedValue)

                Dim s As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = codigo Select x).FirstOrDefault

                If s.saldo <> 0 Then
                    lblotrosal.Text = Format(s.saldo, mdlPublicVars.formatoMoneda)
                Else
                    lblotrosal.Text = 0
                End If

            Catch ex As Exception

            End Try
            conn.Close()

        End Using
    End Sub

    'Funcionn utilizada para verificar errores

    Private Function fnErrores() As Boolean

        Dim cuenta As Integer = 0

        If CDec(txtMonto.text) <= 0 Then
            RadMessageBox.Show("El monto debe de ser mayor a 0", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        Return False
    End Function

    'Guardar Ajuste

    Public Sub fnGuardarMovimiento()

        Try

            Dim saldoInsuficiente As Boolean = True
            Dim idcuenta As Integer = CInt(cmbCuenta.SelectedValue)
            Dim idConcepto As Integer = CInt(cmbAjuste.SelectedValue)
            Dim movimiento As New tblajuste_bancarios
            Dim hora As String = fnHoraServidor()
            Dim fechaServer As DateTime = CType(fnFecha_horaServidor(), DateTime)

            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                movimiento.banco = CInt(cmbBanco.SelectedValue)
                movimiento.anulado = False
                movimiento.transaccion = txtTransaccion.Text
                movimiento.fechaRegitro = dtpFechaRegistro.Text & " " & hora
                movimiento.monto = CDec(txtMonto.text)
                movimiento.cuentabancaria = idcuenta
                movimiento.idconcepto = idConcepto
                'movimiento.usuarioRegistra = mdlPublicVars.idUsuario agregar despues


                'Obtenemos la cuenta 
                Dim cuenta As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = idcuenta _
                   Select x).FirstOrDefault

                'Verificamos si contamos con saldo en la cuenta
                'If CDec(txtMonto.text) > cuenta.saldo Then
                '    saldoInsuficiente = True
                '    Exit Try
                'End If

                'Descontamos el saldo de la cuenta esto despues

                'Dim concepto As tblconcepto_ajustebancario = (From x In conexion.tblconcepto_ajustebancario Where x.idconcepto = idConcepto _
                '   Select x).FirstOrDefault

                ''Si es un Aumento
                'If concepto.bitAumento = True Then
                '    cuenta.saldo += CDec(txtMonto.text)
                'Else
                '    cuenta.saldo -= CDec(txtMonto.text)
                '    conexion.SaveChanges()
                'End If

                conexion.AddTotblajuste_bancarios(movimiento)
                conexion.SaveChanges()
                conn.Close()

            End Using

            frmNotificacion.lblNotificacion.Text = "Registo Guardado" + vbLf + "Correctamente"
            frmNotificacion.Show()

        Catch ex As Exception
            frmNotificacion.lblNotificacion.Text = "El error: " + vbLf + CStr(ex.Message)
            frmNotificacion.Show()
        End Try

    End Sub

    'Boton Guardar 

    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar el Ajuste?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not fnErrores() Then
                fnGuardarMovimiento()
                fnNuevo()
            End If
        End If
    End Sub

    Private Sub frmAjusteBancarios_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmAjustesBancariosLista.frm_llenarLista()
    End Sub

End Class
