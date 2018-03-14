Imports System.Linq
Imports Telerik.WinControls

Public Class frmClienteDevolucionGuia
    Private _Codigo As Integer

    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set

    End Property

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnx0Nuevo.Visible = False
        pnx0Nuevo.Enabled = False
        fnLlenarDatos()
        llenarCombos()
        llenagrid()
    End Sub

    'Funcion utilizada para llenar la informacion
    Private Sub fnLlenarDatos()
        'Obtenemos los datos de la devolucion
        Dim devolucion As tblDevolucionCliente = (From x In ctx.tblDevolucionClientes.AsEnumerable Where x.codigo = Codigo _
                                                  Select x).FirstOrDefault


        'Asignamos los datos
        lblDocumento.Text = devolucion.documento
        lblFecha.Text = Format(devolucion.fechaRegistro, mdlPublicVars.formatoFecha)
        lblCliente.Text = devolucion.tblCliente.Negocio
    End Sub


    Private Sub llenarCombos()

        Dim cas2 = From s In ctx.tblEnvioTipoes _
                  Select Codigo = s.codigo, Nombre = s.nombre

        With Me.cmbEnvioTipo
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = cas2
        End With

    End Sub

    Private Sub llenagrid()

        Dim companyInfo = From x In ctx.tblEnvio_DevolucionCliente Where x.devolucionCliente = Codigo
                Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
                TipoEnvio = x.tblEnvio.tblEnvioTipo.nombre, Observacion = x.tblEnvio.observacion,
                Precio = x.tblEnvio.precio

        Me.grdDatos.DataSource = companyInfo
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        fnModificar()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        fnModificar()
    End Sub

    Private Sub fnModificar()
        If Me.grdDatos.Rows.Count = 0 Then
            Exit Sub

        End If

        If Me.grdDatos.Rows.Count > 0 Then
            If Me.grdDatos.CurrentRow.Index < 0 Then
                Exit Sub
            End If
        End If

        Try
            Dim cod As Integer = cmbEnvioTipo.SelectedValue

            Dim m As tblEnvio = (From e1 In ctx.tblEnvios Where e1.codigo = Me.txtCodigo.Text Select e1).First()

            m.paquetes = txtPaquetes.Text
            m.numero = txtNumero.Text
            m.envioTipo = (CType(cmbEnvioTipo.SelectedValue, Integer))
            m.observacion = txtObservacion.Text
            m.precio = nm2Precio.Value

            ctx.SaveChanges()
            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            Dim m As tblEnvio_DevolucionCliente = (From e1 In ctx.tblEnvio_DevolucionCliente Where e1.envio = Me.txtCodigo.Text Select e1).First()
            ctx.DeleteObject(m)

            Dim guia As tblEnvio = (From x In ctx.tblEnvios Where x.codigo = Me.txtCodigo.Text).FirstOrDefault
            ctx.DeleteObject(guia)
            ctx.SaveChanges()
            Call llenagrid()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If RadMessageBox.Show("¿Dese agregar la guia?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor

        Dim m As New tblEnvio
        Try
            Dim cod As Integer = cmbEnvioTipo.SelectedValue
            m.paquetes = txtPaquetes.Text
            m.numero = txtNumero.Text
            m.envioTipo = (CType(cmbEnvioTipo.SelectedValue, Integer))
            m.usuario = mdlPublicVars.idUsuario
            m.fechatransaccion = fecha
            m.observacion = txtObservacion.Text
            m.precio = nm2Precio.Value
            ctx.AddTotblEnvios(m)

            'Agregamos el registro en la tabla intermedia
            Dim guia_factura As New tblEnvio_DevolucionCliente
            guia_factura.envio = m.codigo
            guia_factura.devolucionCliente = Codigo

            ctx.AddTotblEnvio_DevolucionCliente(guia_factura)

            ctx.SaveChanges()
            Call llenagrid()
            frm_nuevoRegistro()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Sub
End Class
