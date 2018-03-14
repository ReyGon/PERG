Imports System.Linq
Imports Telerik.WinControls

Public Class frmDetalleTelefono
    Private _idCliente As Integer

    Public Property idCliente As Integer
        Get
            idCliente = _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property


    Private Sub frmDetalleTelefono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)
        fnLlenarGrid()
    End Sub

    'LLENAR TELEFONOS
    Public Sub fnLlenarGrid()
        'Realizamos la consulta sobre chequeras
        Dim datos = (From x In ctx.tblClientes_Telefono _
                     Where x.cliente = idCliente
                     Select x.codigo, Telefono = x.telefono, Observacion = x.observacion)

        Me.grdDatos.DataSource = datos
        fnConfiguraTelefonos()
    End Sub

    'CONFIGURA GRID DE TELEFONOS
    Private Sub fnConfiguraTelefonos()
        If Me.grdDatos.ColumnCount > 0 Then
            Me.grdDatos.Columns("codigo").IsVisible = False

            Me.grdDatos.Columns("Telefono").Width = 35
            Me.grdDatos.Columns("Observacion").Width = 65
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If RadMessageBox.Show("¿Desea agregar el télefono?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnAgregar()
            fnLlenarGrid()
        End If
    End Sub

    'AGREGAR NUEVO TELEFONO
    Private Function fnAgregar() As Boolean
        Try
            Dim telefono As New tblClientes_Telefono
            telefono.telefono = txtTelefono.Text
            telefono.observacion = txtObservacion.Text
            telefono.cliente = idCliente
            ctx.AddTotblClientes_Telefono(telefono)
            ctx.SaveChanges()
            RadMessageBox.Show("Registro agregado exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
            txtTelefono.Text = ""
            Return True
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        End Try
    End Function

End Class