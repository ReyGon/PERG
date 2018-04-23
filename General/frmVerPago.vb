Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports System.Data.OleDb
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient

Public Class frmVerPago
    Private _codigo As Integer
    Private permiso As New clsPermisoUsuario

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property


    Private Sub frmVerPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tipopago As String
        fnLlenarDatos()

        Dim pago As tblTipoPago = (From x In ctx.tblTipoPagoes Where x.codigo = 3 Select x).FirstOrDefault
        tipopago = pago.nombre

        If lblTipoPago.Text = tipopago Then
            Me.pnx1Imprimir.Visible = True
        Else
            Me.pnx1Imprimir.Visible = False
        End If

    End Sub

    'Funcion utilizada para llenar los datos
    Private Sub fnLlenarDatos()
        Try
            'Obtenemos la informacion del pago
            Dim pago As tblCaja = (From x In ctx.tblCajas Where x.codigo = codigo _
                                   Select x).FirstOrDefault

            If pago.cliente > 0 Then
                lblCliente.Visible = True
                lblProveedor.Visible = False
                lblCP.Visible = True
                lblCP.Text = pago.tblCliente.Negocio

                'Obtenemos información del cierre de caja asociado
                Dim cierreCaja As tblCierreCaja = (From x In ctx.tblCierreCajaDetalleCajas.AsEnumerable Where x.idCaja = pago.codigo Order By x.idCierreCaja Descending Select x.tblCierreCaja).FirstOrDefault

                If cierreCaja IsNot Nothing Then
                    lblBoletaCierre.Text = cierreCaja.documentoBoleta
                    lblDocCierre.Text = cierreCaja.correlativo
                    lblFechaCierre.Text = Format(cierreCaja.fechaConfirmado, mdlPublicVars.formatoFecha)
                Else
                    lblBoletaCierre.Text = ""
                    lblDocCierre.Text = ""
                    lblFechaCierre.Text = ""
                End If

            ElseIf pago.proveedor > 0 Then
                lblCliente.Visible = False
                lblProveedor.Visible = True
                lblCP.Visible = True
                lblCP.Text = pago.tblProveedor.negocio
            End If

            lblMonto.Text = Format(pago.monto, mdlPublicVars.formatoMoneda)
            lblusuario.Text = pago.tblUsuario1.nombre
            lblObservacion.Text = pago.observacionpago
            lblCodigoPago.Text = codigo
            lblDocumento.Text = pago.documento
            lblTipoPago.Text = pago.tblTipoPago.nombre
            lblFechaRegistro.Text = Format(pago.fecha, mdlPublicVars.formatoFecha)
            lblTransito.Text = If(pago.transito = True, "SI", "NO")
            lblConfirmado.Text = If(pago.confirmado = True, "SI", "NO")
            lblFechaConfirmado.Text = Format(pago.fechaCobro, mdlPublicVars.formatoFecha)

            lblFechaRechazo.Text = If(pago.bitRechazado, Format(pago.fechaRechazado, mdlPublicVars.formatoFecha), "")
            lblUsuarioRechazo.Text = If(pago.bitRechazado, pago.tblUsuario1.nombre, "")
            lblObservacionRechazo.Text = If(pago.bitRechazado, pago.observacionRechazado, "")
            lblRechazado.Text = If(pago.bitRechazado, "SI", "NO")

        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub fnNotaCredito() Handles Me.panel1

        Try

            Dim caja As tblCaja = (From x In ctx.tblCajas Where x.codigo = codigo).FirstOrDefault
            frmDocumentosSalida.tabla = EntitiToDataTable(ctx.sp_rptNotaCredito("", codigo))
            frmDocumentosSalida.reporteBase = Nothing
            frmDocumentosSalida.bitGenerico = False
            frmDocumentosSalida.bitImg = False
            frmDocumentosSalida.bitListaCombo = True
            frmDocumentosSalida.ListaCombo = "nota"

            frmDocumentosSalida.codigo = caja.cliente              'codigo enviamos codigo del cliente
            frmDocumentosSalida.txtTitulo.Text = "Nota Crédito : "
            frmDocumentosSalida.Text = "Nota Crédito"
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.codigoFactura = codigo ' enviamos el codigo de la factura
            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

        Catch ex As Exception
        End Try


        '    If RadMessageBox.Show("Desea Imprimir Nota de Crédito?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
        '        imprimirNotaCredito()
        '    End If
        'End Sub

        'Private Sub imprimirNotaCredito()

        '    Try
        '        Dim conexion As dsi_pos_demoEntities
        '        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
        '            conn.Open()
        '            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

        '            Dim r As New clsReporte

        '            r.tabla = EntitiToDataTable(conexion.sp_rptNotaCredito(codigo))


        '            r.reporte = "rptNotaCrédito.rpt"

        '            r.verReporte()

        '            conn.Close()
        '        End Using

        '    Catch ex As Exception

        '    End Try
    End Sub

    'Private Sub enviarEmail()
    '    Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
    '    Dim tablaParametros As New DataTable

    '    Dim path As String = System.AppDomain.CurrentDomain.BaseDirectory()
    '    Dim archivo As String = ""
    '    Dim msj As String = ""


    '    'Variables
    '    Dim x As New tblImpresion
    '    Dim listaCorreos As New Hashtable
    '    Dim tablaDatos As New DataTable
    '    Dim DsR As New dsReporte
    '    Dim r As New clsReporte

    '    Try

    '        Dim conexion As dsi_pos_demoEntities
    '        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    '            conn.Open()
    '            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

    '            r.tabla = EntitiToDataTable(conexion.sp_rptNotaCredito(codigo))

    '            r.reporte = "rptNotaCrédito.rpt"

    '            'Dim correos() As String = txtCorreo.Text.Split(",")
    '            'Dim i
    '            'For i = LBound(correos) To UBound(correos)
    '            '    listaCorreos.Add(i + 1, correos(i))
    '            'Next

    '            'r.emailTitulo = txtTitulo.Text
    '            'r.emailCuerpo = txtCuerpo.Text & vbCrLf & vbCrLf & "Correo enviado desde Sistema Pos DSI."
    '            'msj += r.EnviarCorreo(listaCorreos, x.url).ToString


    '            conn.Close()
    '        End Using

    '    Catch ex As Exception

    '    End Try

    'End Sub

End Class
