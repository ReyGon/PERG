Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions

Public Class frmBancoCheque

    Private Sub frmBancoCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        mdlPublicVars.comboActivarFiltroLista(cmbBanco)
        mdlPublicVars.comboActivarFiltroLista(cmbCuenta)
        mdlPublicVars.comboActivarFiltroLista(cmbChequera)
        mdlPublicVars.comboActivarFiltro(cmbBeneficiario)
        fnLlenarCombo()
        fnNuevo()
    End Sub

    'NUEVO
    Private Sub fnNuevo()
        grdDatos.Rows.Clear()
        grdDatos.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        lblTotal.Text = 0
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

        'Le asignamos el data source al grid
        Dim cuenta = (From x In ctx.tblBanco_MovimientoConcepto Where x.bitCheque
                      Select x.codigo, valor = x.nombre)

        Dim chequeConcepto As New GridViewComboBoxColumn()
        chequeConcepto.FieldName = "concepto"
        chequeConcepto.Name = "concepto"
        chequeConcepto.HeaderText = "concepto"
        chequeConcepto.Width = 250
        With chequeConcepto
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "valor"
            .DataSource = cuenta
        End With

        Me.grdDatos.Columns.Add(chequeConcepto)
        'Me.grdDatos.Columns.Move(Me.grdDatos.ColumnCount - 1, Me.grdDatos.Columns("elimina").Index)

        Dim decimalColumn As New GridViewDecimalColumn()
        decimalColumn.Name = "monto"
        decimalColumn.HeaderText = "Monto"
        decimalColumn.FieldName = "Monto"
        decimalColumn.DecimalPlaces = 2
        decimalColumn.FormatString = "{0:N2}"
        decimalColumn.Width = 150
        grdDatos.Columns.Add(decimalColumn)
        'Me.grdDatos.Columns.Move(Me.grdDatos.ColumnCount - 1, Me.grdDatos.Columns("elimina").Index)
    End Sub

    'OBTENER CORRELATIVO
    Private Sub fnObtenerCorrelativo()
        'Obtenemos el correlativo de - Cheques -, si no existe lo creamos
        Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos.AsEnumerable Where x.idTipoMovimiento = mdlPublicVars.Cheque_CodigoMovimieto _
                                            Select x).FirstOrDefault

        If correlativo Is Nothing Then
            'Creamos el registro de correlativo
            Dim nuevoCorrelativo As New tblCorrelativo
            nuevoCorrelativo.idEmpresa = mdlPublicVars.idEmpresa
            nuevoCorrelativo.correlativo = 0
            nuevoCorrelativo.inicio = 1
            nuevoCorrelativo.fin = 500
            nuevoCorrelativo.idTipoMovimiento = mdlPublicVars.Cheque_CodigoMovimieto
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

    'Funcion utilizada pra calcular el total
    Private Sub fnTotal()
        Dim total As Double = 0
        For Each dato As GridViewRowInfo In grdDatos.Rows
            Try
                total += dato.Cells("monto").Value
            Catch ex As Exception
                total += 0
            End Try
        Next
        lblTotal.Text = Format(total, mdlPublicVars.formatoMoneda)
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

    Private Sub cmbCuenta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuenta.SelectedValueChanged
        'Obtenemos el codigo de la cuenta
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)

        If idCuenta > 0 Then
            'Obtenemos todas las chequeras de esa cuenta, en las cuales el correlativo sea menor que el fin
            Dim chequeras = (From x In ctx.tblBanco_Chequera Where x.cuenta = idCuenta And x.correlativo < x.fin And x.habilitada
                             Select x.codigo, nombre = x.descripcion)

            With cmbChequera
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = chequeras
            End With
        Else
            cmbChequera.DataSource = Nothing
        End If
    End Sub

    Private Sub grdDatos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellEndEdit
        fnTotal()
    End Sub

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean
        'Recorremos el grid
        Dim descrip As String = ""
        Dim monto As Double = 0
        Dim cuenta As Integer = 0

        If Me.grdDatos.RowCount <= 0 Then
            RadMessageBox.Show("Debe ingresar al menos un movimiento!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbBeneficiario.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir un beneficiario!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbChequera.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir una chequera!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        For Each fila As GridViewRowInfo In Me.grdDatos.Rows
            descrip = fila.Cells("descripcion").Value
            If descrip Is Nothing Then
                RadMessageBox.Show("Debe ingresar una descripcion!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                fila.IsCurrent = True
                fila.Cells("descripcion").IsSelected = True
                Return True
            End If

            cuenta = fila.Cells("concepto").Value
            If cuenta <= 0 Then
                RadMessageBox.Show("Debe elegir un concepto!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                fila.IsCurrent = True
                fila.Cells("concepto").IsSelected = True
                Return True
            End If

            monto = fila.Cells("monto").Value

            If monto <= 0 Then
                RadMessageBox.Show("Debe ingresar una monto mayor a cero(0) o válido!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                fila.IsCurrent = True
                fila.Cells("monto").IsSelected = True
                Return True
            End If

        Next
        Return False
    End Function

    'GUARDAR MOVIMIENTO
    Private Function fnGuardarMovimiento() As Boolean
        Dim success As Boolean = True
        Dim fechaServer As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)
        Dim idChequera As Integer = CInt(cmbChequera.SelectedValue)

        Using transaction As New TransactionScope
            Try
                Dim numeroCorrelativo As Integer = 0
                Dim numeroDocumento As Integer = 0

                'CORRELATIVO
                Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Cheque_CodigoMovimieto
                                                     Select x).FirstOrDefault

                correlativo.correlativo += 1
                numeroCorrelativo = correlativo.correlativo
                ctx.SaveChanges()

                'DOCUMENTO
                Dim chequera As tblBanco_Chequera = (From x In ctx.tblBanco_Chequera Where x.codigo = idChequera _
                                                     Select x).FirstOrDefault

                numeroDocumento = chequera.correlativo
                chequera.correlativo += 1
                ctx.SaveChanges()

                'Creamos el encabezado del cheque
                Dim cheque As New tblBanco_Cheque
                cheque.beneficiario = CInt(cmbBeneficiario.SelectedValue)
                cheque.bitAnulado = False
                cheque.bitConfirmado = False
                cheque.chequera = idChequera
                cheque.correlativo = numeroCorrelativo
                cheque.documento = numeroDocumento
                cheque.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                cheque.nombre = cmbBeneficiario.Text
                cheque.total = CDec(lblTotal.Text)
                cheque.usuarioRegistra = mdlPublicVars.idUsuario
                ctx.AddTotblBanco_Cheque(cheque)
                ctx.SaveChanges()

                Dim idConcepto As Integer = 0
                Dim monto As Decimal = 0
                Dim descripcion As String = ""

                'Recorremos el grid para guardar el detalle del cheque
                For i As Integer = 0 To Me.grdDatos.RowCount - 1
                    descripcion = Me.grdDatos.Rows(i).Cells("descripcion").Value
                    monto = Me.grdDatos.Rows(i).Cells("monto").Value
                    idConcepto = Me.grdDatos.Rows(i).Cells("concepto").Value

                    'Creamos el detalle del cheque
                    Dim detalle As New tblBanco_ChequeDetalle
                    detalle.cheque = cheque.codigo
                    detalle.concepto = idConcepto
                    detalle.descripcion = descripcion
                    detalle.monto = monto

                    ctx.AddTotblBanco_ChequeDetalle(detalle)
                    ctx.SaveChanges()
                Next

                'Obtenemos la cuenta para modificar saldo
                Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = idCuenta
                                                 Select x).FirstOrDefault

                cuenta.pagosTransito += cheque.total
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
            alerta.fnErrorGuardar()
        End If
        Return success
    End Function

    'BOTON GUARDAR
    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar el cheque?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not fnErrores() Then
                If fnGuardarMovimiento() Then
                    If RadMessageBox.Show("¿Desea realizar otro cheque?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

    Private Sub cmbChequera_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChequera.SelectedValueChanged
        'Obtenemos el id de la chequera
        Dim idChequera As Integer = CInt(cmbChequera.SelectedValue)

        If idChequera > 0 Then
            'Obtenemos la chequera
            Dim chequera As tblBanco_Chequera = (From x In ctx.tblBanco_Chequera.AsEnumerable Where x.codigo = idChequera
                                                 Select x).FirstOrDefault

            lblDocumento.Text = chequera.correlativo
        Else
            lblDocumento.Text = 0
        End If
    End Sub

    Private Sub grdDatos_UserAddedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdDatos.UserAddedRow
        fnTotal()
    End Sub

    Private Sub frmBancoCheque_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmBancoChequesLista.frm_llenarLista()
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
        'Obtenemos la lista de los beneficiarios
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