Imports System.Linq
Imports Telerik.WinControls

Public Class frmVentasGuia

    Private _Codigo As Integer

    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set

    End Property


    Private Sub fnLLenarGrid()

        Dim companyInfo = From x In ctx.tblEnvio_Salida Where x.salida = Codigo
                Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
                TipoEnvio = x.tblEnvio.tblEnvioTipo.nombre, Observacion = x.tblEnvio.observacion,
                Precio = x.tblEnvio.precio

        Me.grdDatos.DataSource = companyInfo




        ''   Dim companyInfo = From x In ctx.tblEnvio_Entrada Where x.entrada = Codigo
        '        Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
        '        TipoEnvio = x.tblEnvio.tblEnvioTipo.nombre, Observacion = x.tblEnvio.observacion,
        '        Precio = x.tblEnvio.precio



    End Sub



    Private Sub llenarCombos()

        Dim cas2 = From s In ctx.tblEnvioTipoes _
                  Select Codigo = s.codigo, Nombre = s.nombre

        With Me.cmbEnvio
            .DataSource = Nothing
            .ValueMember = "Codigo"
            .DisplayMember = "Nombre"
            .DataSource = cas2
        End With

    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If RadMessageBox.Show("¿Dese agregar la guia?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If


        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor

        Dim m As New tblEnvio
        Try
            Dim cod As Integer = cmbEnvio.SelectedValue
            Dim te As tblEnvioTipo = (From x In ctx.tblEnvioTipoes Where x.codigo = cod Select x).First

            m.paquetes = txtPaquetes.Text
            m.numero = txtNumeroGuia.Text
            m.envioTipo = (CType(cmbEnvio.SelectedValue, Integer))
            m.usuario = mdlPublicVars.idUsuario
            m.fechatransaccion = fecha
            m.observacion = txtObservacion.Text
            m.precio = nm2Precio.Value

            ctx.AddTotblEnvios(m)

            'Agregamos el registro en la tabla intermedia
            Dim guia_factura As New tblEnvio_Salida
            guia_factura.envio = m.codigo
            guia_factura.salida = Codigo

            ctx.AddTotblEnvio_Salida(guia_factura)

            ctx.SaveChanges()
            '   Call llenagrid()
            ' frm_nuevoRegistro()
        Catch ex As System.Data.EntityException
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try


    End Sub

    Private Sub frmVentasGuia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fnLLenarGrid()
        llenarCombos()

    End Sub
End Class


