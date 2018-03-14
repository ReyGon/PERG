Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmBancoCuenta

    Dim permiso As New clsPermisoUsuario

    Private Sub frmBancoCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbBanco)
        mdlPublicVars.fnFormatoGridEspeciales(grdChequeras)

        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automaticos
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        'Me.errores.Controls.Add(Me.txtCodigo1, "Codigo1")
        'Me.errores.SummaryMessage = "Faltan datos"
        llenarCombos()
        llenagrid()

        mdlPublicVars.fnSeleccionarDefault(grdDatos, codigoDefault, seleccionDefault)
        lbl1Modificar.Text = "Guardar"

        If NuevoIniciar = True Then
            Call limpiaCampos()
            pnx1Modificar.Visible = False
            pnx0Guardar.Visible = True
            lblSaldoActual.Text = 0
            lblSaldoTransito.Text = 0
            lblPagosTransito.Text = 0
            lblCodigo.Text = ""
        End If
    End Sub

    Private Sub llenagrid()
        Try
            Dim consulta = From x In ctx.tblBanco_Cuenta
                           Select chkHabilitada = x.habilitada, cuenta = x.numeroCuenta, banco = x.tblBanco.nombre, _
                           descripcion = x.descripcion, saldoActual = x.saldo, x.saldoTransito,x.pagosTransito, x.codigo

            Me.grdDatos.DataSource = consulta
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub llenarCombos()

        Dim banco = From x In ctx.tblBancoes Select Codigo = x.idbanco, Nombre = x.nombre

        With Me.cmbBanco
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = banco
        End With
    End Sub

    'GUARDAR
    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        If IsNumeric(lblCodigo.Text) Then
            If Not fnErrores() Then
                fnModificarCuenta()
            End If
        Else
            If Not fnErrores() Then
                fnGuardarCuenta()
            End If
        End If
    End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        If IsNumeric(lblCodigo.Text) Then
            If Not fnErrores() Then
                fnModificarCuenta()
            End If
        Else
            If Not fnErrores() Then
                fnGuardarCuenta()
            End If
        End If
    End Sub

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean
        If txtCuenta.Text.Trim.Length = 0 Then
            alertas.contenido = "Debe ingresar un numero de cuenta"
            alertas.fnErrorContenido()
            Return True
        End If

        If Not CInt(cmbBanco.SelectedValue) <> 0 Then
            alertas.contenido = "Debe elegir un banco"
            alertas.fnErrorContenido()
            Return True
        End If

        If txtDescripcion.Text.Trim.Length = 0 Then
            alertas.contenido = "Debe ingresar un descripcion"
            alertas.fnErrorContenido()
            Return True
        End If

        Return False
    End Function

    'Funcion utilizada para guardar una cuenta
    Private Sub fnGuardarCuenta()
        Dim success As Boolean = True

        Using transaction As New TransactionScope
            Try
                'Creamos la nueva cuenta
                Dim cuenta As New tblBanco_Cuenta
                cuenta.numeroCuenta = txtCuenta.Text
                cuenta.banco = CInt(cmbBanco.SelectedValue)
                cuenta.descripcion = txtDescripcion.Text
                cuenta.habilitada = True
                cuenta.saldo = 0
                cuenta.saldoTransito = 0
                cuenta.pagosTransito = 0

                ctx.AddTotblBanco_Cuenta(cuenta)
                ctx.SaveChanges()

                transaction.Complete()
            Catch ex As Exception
                success = False
            End Try
        End Using

        If success Then
            ctx.AcceptAllChanges()
            alertas.fnGuardar()
            llenagrid()
        Else
            alertas.fnErrorGuardar()
        End If
    End Sub

    'Funcion utilizada para modificar una cuenta
    Private Sub fnModificarCuenta()
        Dim success As Boolean = True
        Dim codigo As Integer = CInt(lblCodigo.Text)
        Using transaction As New TransactionScope
            Try
                'Obtenemos la cuenta
                Dim cuenta As tblBanco_Cuenta = (From x In ctx.tblBanco_Cuenta
                                                 Where x.codigo = codigo
                                                 Select x).FirstOrDefault

                cuenta.numeroCuenta = txtCuenta.Text
                cuenta.banco = CInt(cmbBanco.SelectedValue)
                cuenta.descripcion = txtDescripcion.Text
                cuenta.habilitada = chkHabilitada.Checked

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
            alertas.fnErrorModificar()
        End If
    End Sub

    Private Sub frmProducto_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Not verRegistro Then
            frmBancoCuentaLista.frm_llenarLista()
        End If

    End Sub

    'CAMBIO DE CUENTA
    Private Sub frm_txtcodigo() Handles lblCodigo.TextChanged
        'llenar clasificacion de compra del cliente.
        If Not NuevoIniciar Then
            Try
                fnLlenarChequeras(CInt(lblCodigo.Text))
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

    'LLENAR CHEQUERAS
    Public Sub fnLlenarChequeras(ByVal idCuenta As Integer)
        'Realizamos la consulta sobre chequeras
        Dim datos = (From x In ctx.tblBanco_Chequera _
                     Where x.cuenta = idCuenta
                     Select x.codigo, Descripcion = x.descripcion, Inicio = x.inicio, Fin = x.fin, Correlativo = x.correlativo)

        Me.grdChequeras.DataSource = datos
        fnConfigurarChequeras()
    End Sub

    'CONFIGURAR GRID DE CHEQUERAS
    Private Sub fnConfigurarChequeras()
        If Me.grdChequeras.ColumnCount > 0 Then

            For i As Integer = 0 To Me.grdChequeras.ColumnCount - 1
                Me.grdChequeras.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdChequeras.Columns(i).ReadOnly = True
            Next

            Me.grdChequeras.Columns("codigo").IsVisible = False
            Me.grdChequeras.Columns("Descripcion").Width = 130
            Me.grdChequeras.Columns("Inicio").Width = 80
            Me.grdChequeras.Columns("Fin").Width = 80
            Me.grdChequeras.Columns("Correlativo").Width = 80
        End If
    End Sub

    'AGREGAR CHEQUERA
    Private Sub btnAgregarChequera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarChequera.Click
        If Not IsNumeric(lblCodigo.Text) Then
            RadMessageBox.Show("Se debe guardar primero la cuenta para poder agregar una chequera")
        Else
            frmBancoCuentaChequera.seleccionDefault = False
            frmBancoCuentaChequera.Text = "Chequeras"
            frmBancoCuentaChequera.cuenta = CInt(lblCodigo.Text)
            frmBancoCuentaChequera.NuevoIniciar = True
            permiso.PermisoDialogMantenimientoTelerik2(frmBancoCuentaChequera)
            frmBancoCuentaChequera.Dispose()
        End If
    End Sub

    'DOBLE CLIC EN EL GRID DE CHEQUERAS
    Private Sub grdChequeras_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdChequeras.CellDoubleClick
        If grdChequeras.RowCount > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdChequeras)
            Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("codigo").Value
            frmBancoCuentaChequera.seleccionDefault = True
            frmBancoCuentaChequera.Text = "Chequeras"
            frmBancoCuentaChequera.cuenta = CInt(lblCodigo.Text)
            frmBancoCuentaChequera.NuevoIniciar = False
            permiso.PermisoDialogMantenimientoTelerik2(frmBancoCuentaChequera)
            frmBancoCuentaChequera.Dispose()
        End If
    End Sub

    'ELIMINAR UNA CHEQUERA
    Private Sub grdChequeras_UserDeletingRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowCancelEventArgs) Handles grdChequeras.UserDeletingRow
        If RadMessageBox.Show("¿Desea eliminar la chequera?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = Me.grdChequeras.Rows(fila).Cells("codigo").Value
            fnEliminarChequera(codigo)
            fnLlenarChequeras(CInt(lblCodigo.Text))
        Else
            e.Cancel = True
        End If
    End Sub

    'FUNCION UTILIZADA PARA ELIMINAR UNA CHEQUERA
    Private Sub fnEliminarChequera(ByVal idChequera As Integer)
        'Obtenemos la chequera
        Dim chequera As tblBanco_Chequera = (From x In ctx.tblBanco_Chequera Where x.codigo = idChequera
                                             Select x).FirstOrDefault

        ctx.DeleteObject(chequera)
        ctx.SaveChanges()
        alertas.fnEliminar()
    End Sub

End Class