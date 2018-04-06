Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions

Public Class frmBancoCredito

    Private Sub frmBancoCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltroLista(cmbBanco)
        mdlPublicVars.comboActivarFiltroLista(cmbCuenta)
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenarCombo()
        fnNuevo()
    End Sub

    'NUEVO
    Private Sub fnNuevo()
        txtDocumento.Text = ""
        grdDatos.Rows.Clear()
        grdDatos.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        fnObtenerCorrelativo()
        fnTotal()
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

        Dim credito = (From x In ctx.tblBanco_MovimientoConcepto Where x.bitCredito
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
            .DataSource = credito
        End With

        Me.grdDatos.Columns.Add(chequeConcepto)

        Dim acreditador = (From x In ctx.tblBanco_Beneficiario Where x.bitCredito
                      Select x.codigo, valor = x.nombre)

        Dim acreditadores As New GridViewComboBoxColumn()
        acreditadores.FieldName = "acreditador"
        acreditadores.Name = "acreditador"
        acreditadores.HeaderText = "Acreditador"
        acreditadores.Width = 200
        With acreditadores
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "valor"
            .DataSource = acreditador
        End With

        Me.grdDatos.Columns.Add(acreditadores)


        Dim decimalColumn As New GridViewDecimalColumn()
        decimalColumn.Name = "monto"
        decimalColumn.HeaderText = "Monto"
        decimalColumn.FieldName = "Monto"
        decimalColumn.DecimalPlaces = 2
        decimalColumn.FormatString = "{0:N2}"
        decimalColumn.Width = 125
        grdDatos.Columns.Add(decimalColumn)
    End Sub

    'OBTENER CORRELATIVO
    Private Sub fnObtenerCorrelativo()
        Dim tipoMovimiento As Integer = 0
        tipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento

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

    'BOTON GUARDAR
    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar el crédito ?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not fnErrores() Then
                If fnGuardarMovimiento() Then
                    If RadMessageBox.Show("¿Desea realizar otro crédito", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

    'GUARDAR MOVIMIENTO
    Private Function fnGuardarMovimiento() As Boolean
        Dim success As Boolean = True
        Dim fechaServer As DateTime = CType(fnFecha_horaServidor(), DateTime)
        Dim hora As String = fnHoraServidor()
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)

        Using transaction As New TransactionScope
            Try
                Dim numeroCorrelativo As Integer = 0
                'CORRELATIVO
                Dim correlativo As tblCorrelativo = (From x In ctx.tblCorrelativos Where x.idTipoMovimiento = mdlPublicVars.Credito_CodigoMovimiento
                                                     Select x).FirstOrDefault

                correlativo.correlativo += 1
                numeroCorrelativo = correlativo.correlativo
                ctx.SaveChanges()

                'Creamos el encabezado del cheque
                Dim movimiento As New tblBanco_Creditos
                movimiento.bitAnulado = False
                movimiento.correlativo = numeroCorrelativo
                movimiento.documento = txtDocumento.Text
                movimiento.fechaRegistro = dtpFechaRegistro.Text & " " & hora
                movimiento.total = CDec(Replace(lblTotal.Text, "Q", " "))
                movimiento.usuarioRegistra = mdlPublicVars.idUsuario
                movimiento.bitConfirmado = True
                movimiento.fechaConfirmado = fechaServer
                movimiento.usuarioConfirma = mdlPublicVars.idUsuario
                movimiento.cuenta = idCuenta
                ctx.AddTotblBanco_Creditos(movimiento)
                ctx.SaveChanges()
                Dim idConcepto As Integer = 0
                Dim monto As Decimal = 0
                Dim descripcion As String = ""
                Dim idAcreditador As Integer = 0

                'Recorremos el grid para guardar el detalle del cheque
                For i As Integer = 0 To Me.grdDatos.RowCount - 1
                    descripcion = Me.grdDatos.Rows(i).Cells("descripcion").Value
                    monto = Me.grdDatos.Rows(i).Cells("monto").Value
                    idConcepto = Me.grdDatos.Rows(i).Cells("concepto").Value
                    idAcreditador = Me.grdDatos.Rows(i).Cells("acreditador").Value

                    'Obtenemos el nombre actual del acreditador
                    Dim acreditador As tblBanco_Beneficiario = (From x In ctx.tblBanco_Beneficiario.AsEnumerable Where x.codigo = idAcreditador _
                                                                Select x).FirstOrDefault

                    'Creamos el detalle del cheque
                    Dim detalle As New tblBanco_CreditosDetalle
                    detalle.credito = movimiento.codigo
                    detalle.acreditador = idAcreditador
                    detalle.concepto = idConcepto
                    detalle.descripcion = descripcion
                    detalle.monto = monto
                    detalle.nombre = acreditador.nombre

                    ctx.AddTotblBanco_CreditosDetalle(detalle)
                    ctx.SaveChanges()
                Next

                'Obtenemos la cuenta para modificar saldo
                Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = idCuenta
                                                 Select x).FirstOrDefault

                cuenta.saldo += movimiento.total
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

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean
        'Recorremos el grid
        Dim descrip As String = ""
        Dim monto As Double = 0
        Dim cuenta As Integer = 0
        Dim beneficiario As String = ""

        If Me.grdDatos.RowCount <= 0 Then
            RadMessageBox.Show("Debe ingresar al menos un movimiento!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbCuenta.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir una cuenta!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If txtDocumento.Text.Length = 0 Or txtDocumento.Text.Trim.Equals("") Then
            RadMessageBox.Show("Debe ingresar un documento!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
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

            beneficiario = fila.Cells("acreditador").Value
            If descrip Is Nothing Then
                RadMessageBox.Show("Debe ingresar un acreditador!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
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

    'Agrega Fila
    Private Sub grdDatos_UserAddedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdDatos.UserAddedRow
        fnTotal()
    End Sub

    'CALCULA TOTAL
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

    'TERMINA EDICION
    Private Sub grdDatos_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellEndEdit
        fnTotal()
    End Sub

    'CERRANDO FORMULARIO
    Private Sub frmBancoCredito_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmBancoCreditoLista.frm_llenarLista()
    End Sub
End Class