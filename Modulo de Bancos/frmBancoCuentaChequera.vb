Imports Telerik.WinControls
Imports System.Linq
Imports System.Transactions

Public Class frmBancoCuentaChequera
    Private _cuenta As Integer

    Public Property cuenta As Integer
        Get
            cuenta = _cuenta
        End Get
        Set(ByVal value As Integer)
            _cuenta = value
        End Set
    End Property


    Private Sub frmBancoCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'activar el uso de barra lateral
        ActivarBarraLateral = False

        'pasar como parametro el componente de paginas
        rpvBase = rpv

        'activar/desactiva la opcion de llenado de campos automaticos
        ActualizaCamposAutomatico = True

        'activa/desactiva opciones extendidas del grid, como botones, imagenes, y otros.
        ActivarOpcionesExtendidasGrid = False

        llenagrid()

        mdlPublicVars.fnSeleccionarDefault(grdDatos, codigoDefault, seleccionDefault)
        lbl1Modificar.Text = "Guardar"

        If NuevoIniciar = True Then
            Call limpiaCampos()
            pnx1Modificar.Visible = False
            pnx0Guardar.Visible = True
        End If
    End Sub

    Private Sub llenagrid()
        Try
            Dim consulta = From x In ctx.tblBanco_Chequera
                           Select x.codigo, Descripcion = x.descripcion,
                           Inicio = x.inicio, Fin = x.fin, Correlativo = x.correlativo, chkHabilitada = x.habilitada

            Me.grdDatos.DataSource = consulta
            fnConfiguracion()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'FUNCION UTILIZADA PARA CONFIGURAR EL GRID
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            Me.grdDatos.Columns("codigo").IsVisible = False

            Me.grdDatos.Columns("Descripcion").Width = 120
            Me.grdDatos.Columns("Inicio").Width = 80
            Me.grdDatos.Columns("Fin").Width = 80
            Me.grdDatos.Columns("Correlativo").Width = 80
        End If
    End Sub

    'GUARDAR
    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        If IsNumeric(lblCodigo.Text) Then
            If Not fnErrores() Then
                fnModificarChequera()
            End If
        Else
            If Not fnErrores() Then
                fnGuardarChequera()
            End If
        End If
    End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        If IsNumeric(lblCodigo.Text) Then
            If Not fnErrores() Then
                fnModificarChequera()
            End If
        Else
            If Not fnErrores() Then
                fnGuardarChequera()
            End If
        End If
    End Sub

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean
        If txtDescripcion.Text.Trim.Length = 0 Then
            alertas.contenido = "Debe ingresar un descripcion"
            alertas.fnErrorContenido()
            Return True
        End If

        Return False
    End Function

    'Funcion utilizada para guardar una cuenta
    Private Sub fnGuardarChequera()
        Dim success As Boolean = True

        Using transaction As New TransactionScope
            Try
                'Creamos la nueva cuenta
                Dim chequera As New tblBanco_Chequera
                chequera.correlativo = nm0Correlativo.Value
                chequera.cuenta = cuenta
                chequera.descripcion = txtDescripcion.Text
                chequera.fin = nm0Fin.Value
                chequera.inicio = nm0Inicio.Value
                chequera.habilitada = chkHabilitada.Checked
                ctx.AddTotblBanco_Chequera(chequera)
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
    Private Sub fnModificarChequera()
        Dim success As Boolean = True
        Dim codigo As Integer = CInt(lblCodigo.Text)
        Using transaction As New TransactionScope
            Try
                'Obtenemos la cuenta
                Dim chequera As tblBanco_Chequera = (From x In ctx.tblBanco_Chequera
                                                 Where x.codigo = codigo
                                                 Select x).FirstOrDefault

                chequera.correlativo = nm0Correlativo.Value
                chequera.cuenta = cuenta
                chequera.descripcion = txtDescripcion.Text
                chequera.fin = nm0Fin.Value
                chequera.inicio = nm0Inicio.Value
                chequera.habilitada = chkHabilitada.Checked
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
            frmBancoCuenta.fnLlenarChequeras(cuenta)
        End If
    End Sub

End Class