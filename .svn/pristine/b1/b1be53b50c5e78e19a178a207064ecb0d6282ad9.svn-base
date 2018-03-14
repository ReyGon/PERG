Imports System.Linq
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmClienteTelefono
    Private _idCliente As Integer

    Public Property idCliente As Integer
        Get
            idCliente = _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property


    Private Sub frmClienteTelefono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim consulta = From x In ctx.tblClientes_Telefono Where x.cliente = idCliente
                           Select x.codigo, Telefono = x.telefono, Observacion = x.observacion


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

            Me.grdDatos.Columns("Telefono").Width = 70
            Me.grdDatos.Columns("Observacion").Width = 30
        End If
    End Sub

    'GUARDAR
    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        If IsNumeric(lblCodigo.Text) Then
            If Not fnErrores() Then
                fnModificarTelefono()
            End If
        Else
            If Not fnErrores() Then
                fnGuardarTelefono()
            End If
        End If
    End Sub

    'MODIFICAR
    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        If IsNumeric(lblCodigo.Text) Then
            If Not fnErrores() Then
                fnModificarTelefono()
            End If
        Else
            If Not fnErrores() Then
                fnGuardarTelefono()
            End If
        End If
    End Sub

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean
        If txtTelefono.Text.Trim.Length = 0 Then
            alertas.contenido = "Debe ingresar un descripcion"
            alertas.fnErrorContenido()
            Return True
        End If

        Return False
    End Function

    'Funcion utilizada para guardar una cuenta
    Private Sub fnGuardarTelefono()
        Dim success As Boolean = True

        Using transaction As New TransactionScope
            Try
                'Creamos la nueva cuenta
                Dim telefono As New tblClientes_Telefono
                telefono.telefono = txtTelefono.Text
                telefono.observacion = txtObservacion.Text
                telefono.cliente = idCliente
                ctx.AddTotblClientes_Telefono(telefono)
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
    Private Sub fnModificarTelefono()
        Dim success As Boolean = True
        Dim codigo As Integer = CInt(lblCodigo.Text)
        Using transaction As New TransactionScope
            Try
                'Obtenemos el telefono
                Dim telefono As tblClientes_Telefono = (From x In ctx.tblClientes_Telefono
                                                 Where x.codigo = codigo
                                                 Select x).FirstOrDefault

                telefono.telefono = txtTelefono.Text
                telefono.observacion = txtObservacion.Text
                telefono.cliente = idCliente

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
            frmClientes.fnLlenarTelefono(idCliente)
        End If
    End Sub
End Class