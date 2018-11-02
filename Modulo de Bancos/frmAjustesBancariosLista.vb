Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient

Public Class frmAjustesBancariosLista
    Public filtroActivo As Boolean
    Private permiso As New clsPermisoUsuario

    Private Sub frmAjustesBancariosLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmBancoDebitoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbl2Eliminar.Text = "Anular"
            Dim iz As New frmBancoBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
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
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim filtro As String = txtFiltro.Text
                If filtroActivo Then

                Else
                    
                    Dim consulta = (From x In conexion.tblajuste_bancarios
                                 Select Ajuste = x.idajuste, Fecha = x.fechaRegitro, Concepto = x.tblconcepto_ajustebancario.concepto,
                                 Documento = x.transaccion, Total = x.monto,
                                 clrEstado = CType(If(x.anulado, "0", If(Not x.aprobado, "1", If(x.aprobado, "4", "0"))), Int32),
                                 Descripcion = If(x.anulado, "Anulado", If(Not x.aprobado, "No confirmado", If(x.aprobado, "Confirmado", "Anulado"))),
                                 chmConfirmar = x.aprobado)


                    grdDatos.DataSource = consulta
                End If

                ''Para saber cuantas filas tiene el grid
                mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
                mdlPublicVars.fnGrid_iconos(grdDatos)
                fnCambioFila()
                fnconfiguracion()

            End Using

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End Try
    End Sub

    Private Sub fnconfiguracion()
        If Me.grdDatos.Columns.Count > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Total")

            Me.grdDatos.Columns("Ajuste").IsVisible = False
            Me.grdDatos.Columns("Fecha").Width = 70
            Me.grdDatos.Columns("Concepto").Width = 150
            Me.grdDatos.Columns("Documento").Width = 90
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
            frmAjustesBancarios.Text = "Ajustes Bancarios"
            frmAjustesBancarios.StartPosition = FormStartPosition.CenterScreen
            frmAjustesBancarios.ShowDialog()
            frmAjustesBancarios.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub


    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            If Me.grdDatos.RowCount > 0 Then
                If RadMessageBox.Show("¿Desea anular el debito?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                    fnAnula(grdDatos.Rows(fila).Cells("Ajuste").Value())
                    Call llenagrid()
                End If
            End If
        Catch ex As Exception
            frmNotificacion.lblNotificacion.Text = "El error: " + vbLf + CStr(ex.Message)
            frmNotificacion.Show()
        End Try
    End Sub

    Private Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
        Try
            If Me.grdDatos.RowCount > 0 Then
                If Me.grdDatos.CurrentRow.Index >= 0 Then
                    mdlPublicVars.superSearchId = Me.grdDatos.Rows(mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)).Cells("Ajuste").Value
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnAnula(ByVal idAjuste As Integer)
        Dim succes As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


                'Obtenemos el encabezado del ajuste
                Dim Ajuste As tblajuste_bancarios = (From x In conexion.tblajuste_bancarios Where x.idajuste = idAjuste Select x).FirstOrDefault
                Ajuste.fechaAnulacion = fechaServer
                Ajuste.usuarioAnulacion = mdlPublicVars.idUsuario
                Ajuste.anulado = True
                conexion.SaveChanges()

                conn.Close()

            End Using

            If succes Then
                conexion.AcceptAllChanges()
                alertas.fnModificar()
                llenagrid()
            Else
            End If

        Catch ex As Exception
            succes = False
        End Try

    End Sub

    Private Sub fnQuitarFiltro() Handles Me.quitarFiltro
        filtroActivo = False
        alertas.contenido = "Filtro: Desactivado"
        llenagrid()
    End Sub

    Private Sub fnGrid_valueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.Click

        If Me.grdDatos.Rows.Count >= 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            If (Me.grdDatos.CurrentColumn.Name = "chmConfirmar") And fila >= 0 Then
                Dim estado As Integer = Me.grdDatos.Rows(fila).Cells("clrEstado").Value

                If estado = 0 Then
                    'Anulado
                    frmNotificacion.lblNotificacion.Text = "Ajuste ya" + vbLf + "anulado"
                    frmNotificacion.Show()
                ElseIf estado = 1 Then
                    'Por Confirmar
                    If RadMessageBox.Show("¿Desea confirmar el Ajuste?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If fnConfirmarAjuste(Me.grdDatos.Rows(fila).Cells("Ajuste").Value) Then
                            Me.frm_llenarLista()
                        Else
                            Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = False
                        End If
                    Else
                        Me.grdDatos.Rows(fila).Cells("chmConfirmar").Value = False
                    End If
                ElseIf estado = 4 Then
                    'Confirmado
                    frmNotificacion.lblNotificacion.Text = "Ajuste ya" + vbLf + "confirmado"
                    frmNotificacion.Show()
                End If
            End If
        End If
    End Sub

    Private Function fnConfirmarAjuste(ByVal idAjuste As Integer) As Boolean
        Dim success As Boolean = True
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor

        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim movimiento As tblajuste_bancarios = (From x In conexion.tblajuste_bancarios Where x.idajuste = idAjuste _
                                                         Select x).FirstOrDefault

                movimiento.fechaAprobacion = fechaServer
                movimiento.aprobado = True
                movimiento.usuarioAprobacion = mdlPublicVars.idUsuario
                conexion.SaveChanges()

                'Obtenemos la cuenta del ajuste
                Dim cuenta As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = movimiento.cuentabancaria _
                                                 Select x).FirstOrDefault

                Dim cuenta2 As tblBanco_Cuenta = (From x In conexion.tblBanco_Cuenta Where x.codigo = movimiento.cuentabancaria2 _
                                                Select x).FirstOrDefault

                Dim concepto As tblconcepto_ajustebancario = (From x In conexion.tblconcepto_ajustebancario Where x.idconcepto = movimiento.idconcepto _
                                                                      Select x).FirstOrDefault

                If concepto.bitDecremento = True Then

                    If movimiento.monto > cuenta.saldo Then
                        frmNotificacion.lblNotificacion.Text = "Saldo insuficiente" + vbLf + "en la cuetna"
                        frmNotificacion.Show()
                        success = False
                        Exit Try
                    Else
                        'realizamos el ajuste 

                        'cuenta.saldo -= movimiento.monto
                        'conexion.SaveChanges()

                        If movimiento.cuentabancaria2 > 0 Then
                           
                            cuenta.saldo -= movimiento.monto
                            conexion.SaveChanges()
                            cuenta2.saldo += movimiento.monto
                            conexion.SaveChanges()

                        Else

                            cuenta.saldo -= movimiento.monto
                            conexion.SaveChanges()

                        End If

                    End If

                Else

                    cuenta.saldo += movimiento.monto
                    conexion.SaveChanges()

                End If
                
                llenagrid()

                conn.Close()
            End Using

        Catch ex As Exception

        End Try

    End Function

End Class


