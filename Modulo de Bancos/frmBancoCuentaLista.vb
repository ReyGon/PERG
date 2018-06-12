Imports System.Linq
Imports System.Transactions
Imports Telerik.WinControls

Public Class frmBancoCuentaLista

    Public filtroActivo As Boolean
    Private permiso As New clsPermisoUsuario

    Private Sub frmProductoLista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub frmProductoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbl2Eliminar.Text = "Deshabilitar"
            Dim iz As New frmBancoBarraIzquierda
            iz.frmAnterior = Me
            frmBarraLateralBaseIzquierda = iz
            frmBarraLateralBaseDerecha = frmBancoCuentaBarraDerecha
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
        Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        'Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        llenagrid()
        Me.grdDatos.Focus()
    End Sub

    Private Sub llenagrid()
        Try
            Dim filtro As String = txtFiltro.Text
            If filtroActivo Then
                frmProductoFiltro.fnFiltrar()
            Else
                Dim consulta = (From x In ctx.tblBanco_Cuenta _
                                Where x.numeroCuenta.Contains(filtro) And x.tblBanco.nombre.Contains(filtro)
                                Select Codigo = x.codigo, chkHabilitada = x.habilitada, Descripcion = x.descripcion, Cuenta = x.numeroCuenta,
                                Banco = x.tblBanco.nombre, Saldo = x.saldo, SaldoTransito = x.saldoTransito, PagosTransito = x.pagosTransito)

                grdDatos.DataSource = consulta
            End If

            'Para saber cuantas filas tiene el grid
            mdlPublicVars.superSearchFilasGrid = Me.grdDatos.Rows.Count
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

            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Saldo")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "SaldoTransito")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "PagosTransito")

            Me.grdDatos.Columns("Codigo").IsVisible = False
            Me.grdDatos.Columns("chkHabilitada").Width = 50
            Me.grdDatos.Columns("Descripcion").Width = 120
            Me.grdDatos.Columns("Cuenta").Width = 120
            Me.grdDatos.Columns("Banco").Width = 100
            Me.grdDatos.Columns("Saldo").Width = 80
            Me.grdDatos.Columns("SaldoTransito").Width = 80
            Me.grdDatos.Columns("PagosTransito").Width = 80
        End If
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        fnCambioFila()
        Try
            frmBancoCuenta.seleccionDefault = False
            frmBancoCuenta.Text = "Modulo de Bancos"
            frmBancoCuenta.NuevoIniciar = True
            frmBancoCuenta.StartPosition = FormStartPosition.CenterScreen
            permiso.PermisoDialogMantenimientoTelerik2(frmBancoCuenta)
            frmBancoCuenta.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        fnCambioFila()
        Try
            If Me.grdDatos.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim permiso As New clsPermisoUsuario
            frmBancoCuenta.seleccionDefault = True
            frmBancoCuenta.codigoDefault = mdlPublicVars.superSearchId
            frmBancoCuenta.NuevoIniciar = False
            frmBancoCuenta.StartPosition = FormStartPosition.CenterScreen
            frmBancoCuenta.Text = "Modulo de Bancos"
            permiso.PermisoDialogMantenimientoTelerik2(frmBancoCuenta)
            frmBancoCuenta.Dispose()
        Catch ex As Exception
            alertas.fnError()
        End Try

    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            If RadMessageBox.Show("¿Desea deshabilitar la cuenta?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
                fnDeshabilita(grdDatos.Rows(fila).Cells("codigo").Value())
                Call llenagrid()
            End If
        Catch ex As Exception
            alertas.fnError()
        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        fnCambioFila()
        frmBancoCuenta.seleccionDefault = True
        frmBancoCuenta.codigoDefault = mdlPublicVars.superSearchId
        frmBancoCuenta.NuevoIniciar = False
        frmBancoCuenta.verRegistro = True
        frmBancoCuenta.Text = "Modulo de Bancos"
        frmBancoCuenta.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogMantenimientoTelerik2(frmBancoCuenta)
        frmBancoCuenta.Dispose()
    End Sub

    Private Sub fnCambioFila() Handles Me.cambiaFilaGrdDatos
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
    Private Sub fnDeshabilita(ByVal codigo As Integer)
        'Obtenemos el encabezado de la cuenta
        Dim success As Boolean = True

        'Using transaction As New TransactionScope
        Try
            'Obtenemos el encabezado de la cuenta
            Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta Where x.codigo = codigo Select x).FirstOrDefault

            cuenta.habilitada = False
            ctx.SaveChanges()
        Catch ex As Exception
            success = False
        End Try
        ' End Using

        If success Then
            ctx.AcceptAllChanges()
            'alertas.fnErrorGuardar()
        Else
            'alertas.fnErrorGuardar()
        End If
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista de Cuentas"
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

End Class