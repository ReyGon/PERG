Imports System.Linq
Imports System.Transactions
Imports Telerik.WinControls

Public Class frmBancoCreditoLista
    Public filtroActivo As Boolean
    Private permiso As New clsPermisoUsuario

    Private Sub frmBancoCreditoLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmBancoCreditoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbl2Eliminar.Text = "Anular"
            Dim iz As New frmBancoBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmBancoCreditoBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        llenagrid()
        Me.grdDatos.Focus()
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            If filtroActivo Then

            Else
                'DATOS
                Dim consulta = (From x In ctx.tblBanco_Creditos
                                Select x.codigo, Fecha = x.fechaRegistro, Usuario = x.tblUsuario1.nombre, Banco = x.tblBanco_Cuenta.tblBanco.nombre,
                                Cuenta = x.tblBanco_Cuenta.numeroCuenta, Documento = x.documento, Correlativo = x.correlativo, Total = x.total,
                                clrEstado = CType(If(x.bitAnulado, "0", If(Not x.bitConfirmado, "1", If(x.bitConfirmado, "4", "0"))), Int32),
                                Descripcion = If(x.bitAnulado, "Anulado", If(Not x.bitConfirmado, "No confirmado", If(x.bitConfirmado, "Confirmado", "Anulado"))),
                                chmConfirmar = x.bitConfirmado)

                grdDatos.DataSource = consulta
            End If

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
            mdlPublicVars.fnGrid_iconos(grdDatos)
            fnCambioFila()
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnConfiguracion()
        If Me.grdDatos.Columns.Count > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Total")

            Me.grdDatos.Columns("codigo").IsVisible = False
            Me.grdDatos.Columns("Fecha").Width = 70
            Me.grdDatos.Columns("Documento").Width = 90
            Me.grdDatos.Columns("Correlativo").Width = 60
            Me.grdDatos.Columns("Total").Width = 90
            Me.grdDatos.Columns("clrEstado").Width = 70
            Me.grdDatos.Columns("Descripcion").Width = 100
            Me.grdDatos.Columns("chmConfirmar").Width = 80
        End If
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        fnCambioFila()
        Try
            frmBancoCredito.Text = "Crédito"
            frmBancoCredito.StartPosition = FormStartPosition.CenterScreen
            frmBancoCredito.ShowDialog()
            frmBancoCredito.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        If Me.grdDatos.Rows.Count = 0 Then
            Exit Sub
        End If
        'RadMessageBox.Show("No se puede modificar un cheque, anulelo y creelo nuevamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            If Me.grdDatos.RowCount > 0 Then

                'Dim idCredito As Integer = Me.grdDatos.Rows(fila).Cells("codigo").Value
                'Obtenemos informacion del credito
                'Dim credito As tblBanco_Creditos = (From x In ctx.tblBanco_Creditos.AsEnumerable Where x.codigo = idCredito Select x)

                'If credito.bitAnulado Then
                'RadMessageBox.Show("El crédito ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                'ElseIf credito.bitConfirmado Then
                '   RadMessageBox.Show("El crédito ya ha sido confirmado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                If RadMessageBox.Show("¿Desea anular el crédito?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                    fnAnula(grdDatos.Rows(fila).Cells("codigo").Value())
                    Call llenagrid()
                End If
            End If
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        fnCambioFila()
        frmBancoCreditoConcepto.Text = "Crédito"
        frmBancoCreditoConcepto.idMovimiento = mdlPublicVars.superSearchId
        frmBancoCreditoConcepto.StartPosition = FormStartPosition.CenterScreen
        frmBancoCreditoConcepto.ShowDialog()
        frmBancoCreditoConcepto.Dispose()
    End Sub

    Public Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.RowCount > 0 Then
                If Me.grdDatos.CurrentRow.Index >= 0 Then
                    mdlPublicVars.superSearchId = Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("codigo").Value
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para desabilitar un producto
    Private Sub fnAnula(ByVal idCredito As Integer)
        Dim success As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

        Using transaction As New TransactionScope
            Try
                'Obtenemos el encabezado del cheque
                Dim credito As tblBanco_Creditos = (From x In ctx.tblBanco_Creditos Where x.codigo = idCredito Select x).FirstOrDefault

                credito.fechaAnulado = fechaServer
                credito.usuarioAnula = mdlPublicVars.idUsuario
                credito.bitAnulado = True
                ctx.SaveChanges()

                'Obtenemos la cuenta
                Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = credito.cuenta
                   Select x).FirstOrDefault

                cuenta.saldo -= credito.total
                ctx.SaveChanges()

                transaction.Complete()
            Catch ex As Exception
                success = False
            End Try
        End Using

        If success Then
            ctx.AcceptAllChanges()
            alertas.fnModificar()
            llenagrid()
        Else
            alertas.fnErrorGuardar()
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista : Movimientos de Crédito"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub fnFiltros() Handles Me.Exportar

    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: DESACTIVADO"
        alertas.fnErrorContenido()
        llenagrid()
    End Sub

    Private Sub fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Me.grdDatos.Rows.Count > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If (Me.grdDatos.CurrentColumn.Name = "chmConfirmar") And fila >= 0 Then
                Dim estado As Integer = Me.grdDatos.Rows(fila).Cells("clrEstado").Value

                If estado = 0 Then
                    'ANULADO
                    RadMessageBox.Show("El crédito ya ha sido anulado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                ElseIf estado = 1 Then
                    'POR CONFIRMAR
                    If RadMessageBox.Show("¿Desea confirmar el crédito?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If fnConfirmarCredito(Me.grdDatos.Rows(fila).Cells("codigo").Value) Then
                            llenagrid()
                        Else
                            Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = False
                        End If
                    Else
                        Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = False
                    End If
                ElseIf estado = 4 Then
                    'CONFIMADO
                    RadMessageBox.Show("El crédito ya ha sido confirmado", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                End If
            End If
        End If
    End Sub

    'Funcion utilizada para confirmar un cheque
    Private Function fnConfirmarCredito(ByVal idCredito As Integer) As Boolean
        Dim success As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

        Using transaction As New TransactionScope

            Try
                'Obtenemos el encabezado de cheque
                Dim movimiento As tblBanco_Creditos = (From x In ctx.tblBanco_Creditos Where x.codigo = idCredito _
                                                 Select x).FirstOrDefault

                movimiento.fechaConfirmado = fechaServer
                movimiento.bitConfirmado = True
                movimiento.usuarioConfirma = mdlPublicVars.idUsuario

                ctx.SaveChanges()
                'Obtenemos la cuenta del cheque
                Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = movimiento.cuenta _
                                                 Select x).FirstOrDefault

                cuenta.saldo += movimiento.total
                ctx.SaveChanges()
                transaction.Complete()
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End Using

        If success Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
        Else
            alertas.fnErrorGuardar()
        End If

        Return success
    End Function

End Class