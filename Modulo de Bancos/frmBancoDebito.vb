Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions

Public Class frmBancoDebito

    Private _bitDebito As Boolean

    Public Property bitDebito As Boolean
        Get
            bitDebito = _bitDebito
        End Get
        Set(ByVal value As Boolean)
            _bitDebito = value
        End Set
    End Property

    Private Sub frmBancoCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltroLista(cmbBanco)
        mdlPublicVars.comboActivarFiltroLista(cmbCuenta)
        mdlPublicVars.comboActivarFiltro(cmbBeneficiario)
        fnLlenarCombo()
        fnNuevo()
    End Sub

    'NUEVO
    Private Sub fnNuevo()
        chkProgramado.Visible = bitDebito
        nm2Monto.Value = 0
        fnObtenerCorrelativo()
    End Sub

    'Llenar Combos
    Private Sub fnLlenarCombo()
        'BANCOS
        Dim bancos = (From x In ctx.tblBancoes
                      Select codigo = x.idbanco, x.nombre)

        With cmbBanco
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = bancos
        End With

        'BENEFICIARIO
        fnLlenaBeneficiarios(0)

        'CONCEPTOS
        Dim conceptos = (From x In ctx.tblBanco_MovimientoConcepto Where x.bitCredito
                         Select x.codigo, x.nombre)

        With cmbConcepto
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = conceptos
        End With

    End Sub

    'OBTENER CORRELATIVO
    Private Sub fnObtenerCorrelativo()
        Dim tipoMovimiento As Integer = mdlPublicVars.Debito_CodigoMovimiento


        'Obtenemos el correlativo de - Cheques -, si no existe lo creamos
        Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos.AsEnumerable Where x.idTipoMovimiento = tipoMovimiento _
                                            Select x).FirstOrDefault

        If correlativo Is Nothing Then
            'Creamos el registro de correlativo
            Dim nuevoCorrelativo As New tblCorrelativo
            nuevoCorrelativo.idEmpresa = mdlPublicVars.idEmpresa
            nuevoCorrelativo.correlativo = 0
            nuevoCorrelativo.inicio = 1
            nuevoCorrelativo.fin = 500
            nuevoCorrelativo.idTipoMovimiento = tipoMovimiento
            nuevoCorrelativo.porcentajeAviso = 20
            nuevoCorrelativo.serie = ""

            'Agregamos el correlativo a la BD
            ctx.AddTotblCorrelativos(nuevoCorrelativo)
            ctx.SaveChanges()
            lblCorrelativo.Text = "1"
        Else
            lblCorrelativo.Text = correlativo.correlativo + 1
        End If

    End Sub

    Private Sub cmbBanco_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedValueChanged
        'Obtenemos el codigo del banco
        Dim idBanco As Integer = CInt(cmbBanco.SelectedValue)

        If idBanco > 0 Then
            'Obtenemos todas las cuenta de ese banco
            Dim cuentas = (From x In ctx.tblBanco_Cuenta Where x.banco = idBanco _
                           Select x.codigo, nombre = x.descripcion)

            With cmbCuenta
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = cuentas
            End With
        Else
            cmbCuenta.DataSource = Nothing
        End If
    End Sub

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean
        'Recorremos el grid
        Dim descrip As String = ""
        Dim monto As Double = 0
        Dim cuenta As Integer = 0


        If Not (CInt(cmbBeneficiario.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir un beneficiario!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbCuenta.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir una cuenta!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbConcepto.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir un concepto!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If nm2Monto.Value <= 0 Then
            RadMessageBox.Show("Monto debe de ser mayor a cero (0)!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        Return False
    End Function

    'GUARDAR DEBITO o CREDITO
    Private Function fnGuardarMovimiento() As Boolean
        Dim success As Boolean = True
        Dim saldoInsuficiente As Boolean = False
        Dim fechaServer As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)
        Dim idConcepto As Integer = CInt(cmbConcepto.SelectedValue)

        Dim tipoMovimiento As Integer = mdlPublicVars.Debito_CodigoMovimiento
     

        Using transaction As New TransactionScope
            Try
                Dim numeroCorrelativo As Integer = 0

                'CORRELATIVO
                Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = tipoMovimiento
                                                     Select x).FirstOrDefault

                correlativo.correlativo += 1
                numeroCorrelativo = correlativo.correlativo
                ctx.SaveChanges()

                'Creamos el encabezado del cheque
                Dim movimiento As New tblBanco_Debitos
       
                movimiento.beneficiario = CInt(cmbBeneficiario.SelectedValue)
                movimiento.bitAnulado = False
                movimiento.correlativo = numeroCorrelativo
                movimiento.documento = txtDocumento.Text
                movimiento.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                movimiento.nombre = cmbBeneficiario.Text
                movimiento.monto = nm2Monto.Value
                movimiento.cuenta = idCuenta
                movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                movimiento.concepto = idConcepto

                'Obtenemos la cuenta
                Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = idCuenta _
                                                 Select x).FirstOrDefault

                movimiento.bitConfirmado = Not chkProgramado.Checked
                If Not chkProgramado.Checked Then
                    movimiento.fechaConfirmado = dtpFechaRegistro.Text & " " & hora
                    movimiento.usuarioConfirma = mdlPublicVars.idUsuario
                    'Verificamos si contamos con saldo en la cuenta
                    If nm2Monto.Value > cuenta.saldo Then
                        saldoInsuficiente = True
                        Exit Try
                    Else
                        'Descontamos del saldo de la cuenta
                        cuenta.saldo -= nm2Monto.Value
                        ctx.SaveChanges()
                    End If
                Else
                    'Aumentamos los pagos en transito de la cuenta
                    cuenta.pagosTransito += nm2Monto.Value
                    ctx.SaveChanges()
                End If

                ctx.AddTotblBanco_Debitos(movimiento)


                ctx.SaveChanges()

                transaction.Complete()
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                success = False
            End Try
        End Using

        If success Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
        Else
            If saldoInsuficiente Then
                alerta.contenido = "Saldo insuficiente en la cuenta"
                alerta.fnErrorContenido()
            Else
                alerta.fnErrorGuardar()
            End If
        End If
        Return success
    End Function

    'BOTON GUARDAR
    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar el débito ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not fnErrores() Then
                If fnGuardarMovimiento() Then
                    If RadMessageBox.Show("¿Desea realizar otro débito ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnNuevo()
                    Else
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub

    'BOTON SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub frmBancoCheque_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmBancoDebitoLista.frm_llenarLista()
    End Sub

    Private Sub btnAgregarBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarBeneficiario.Click
        If Not cmbBeneficiario.Text.Equals("") Or cmbBanco.Text.Length > 0 Then
            fnAgregaBeneficiario()
        End If
    End Sub

    'AGREGA BENEFICIARIOS
    Private Sub fnAgregaBeneficiario()
        Dim nombre As String = cmbBeneficiario.Text

        'Verificamos si no existe un beneficiario ya con ese nombre
        Dim verifica As tblBanco_Beneficiario = (From x In ctx.tblBanco_Beneficiario.AsEnumerable Where Trim(x.nombre) = Trim(nombre)
                                                 Select x).FirstOrDefault

        If verifica Is Nothing Then
            'Creo el nuevo beneficiario
            Dim beneficiario As New tblBanco_Beneficiario
            beneficiario.nombre = nombre
            beneficiario.bitCredito = False
            beneficiario.bitDebitoCheque = True
            beneficiario.observacion = ""

            'Lo agregamos a la BD
            ctx.AddTotblBanco_Beneficiario(beneficiario)
            ctx.SaveChanges()

            fnLlenaBeneficiarios(beneficiario.codigo)
            RadMessageBox.Show("Beneficiario agregado exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        Else
            'Existe el codigo
            RadMessageBox.Show("Ya existe un beneficiario con ese nombre", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End If
    End Sub

    'LLENA COMBO BENEFICIARIOS
    Private Sub fnLlenaBeneficiarios(ByVal ultimo As Integer)
        'Obtenemos la lista de los beneficiarios0
        ''Dim beneficiario = (From x In ctx.tblBanco_Beneficiario
        ''Where x.bitDebitoCheque Select x.codigo, x.nombre)

        Dim beneficiario = (From x In ctx.tblBanco_Beneficiario
                            Select x.codigo, x.nombre)

        With cmbBeneficiario
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = beneficiario
        End With

        If ultimo > 0 Then
            cmbBeneficiario.SelectedValue = ultimo
        End If
    End Sub

End Class
