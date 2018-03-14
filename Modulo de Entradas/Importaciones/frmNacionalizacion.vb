Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmNacionalizacion

    Dim _idinvoice As Integer

    Public Property idinvoice As Integer
        Get
            idinvoice = _idinvoice
        End Get
        Set(value As Integer)
            _idinvoice = value
        End Set
    End Property

    Private Sub frmNacionalizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarInformacion()
        fnTotal()
    End Sub

    Public Sub fnLlenarInformacion()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim invoice As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = idinvoice Select x).FirstOrDefault
                Dim contadorproductos As Integer = (From x In conexion.tblEntradasDetalles Where x.idEntrada = idinvoice Select x).Count
                Dim sumatasaproveedor As Decimal = (From x In conexion.tblCajas Where x.proveedor = CInt(invoice.idProveedor) And x.anulado = False Select CDec(x.tipoCambio)).Sum
                Dim contadortasaproveedor As Integer = (From x In conexion.tblCajas Where x.proveedor = CInt(invoice.idProveedor) And x.anulado = False Select x).Count

                Me.lblDocumentoImportacion.Text = CStr(invoice.serieDocumento + "-" + invoice.documento)
                Me.lblCantidadProductos.Text = CStr(contadorproductos)
                Me.lblTotalImportacionDolar.Text = Format(CDec(invoice.total), formatoMonedaDolar)
                Me.lblTasaCambio.Text = Format(CDec(sumatasaproveedor / contadortasaproveedor), formatoMoneda)
                Me.lblValorMercaderiaQ.Text = Format(CDec(CDec(Replace(Me.lblTotalImportacionDolar.Text, "$", "")) * CDec(Replace(Me.lblTasaCambio.Text, "Q", ""))), formatoMoneda)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnTotal()
        Try
            Dim totalGastos As Decimal = 0

            totalGastos += CDec(Me.txtGastosNaviera.Text) + CDec(Me.txtIvaImportacion.Text) + CDec(Me.txtImpuestoImportacion.Text) + CDec(Me.txtTramitesAduanales.Text) +
                  CDec(Me.txtTransporte.Text) + CDec(Me.txtSeguridad.Text) + CDec(Me.txtComisiones.Text) + CDec(Me.txtOtrosGastos.Text) + CDec(Me.txtFleteNaviera.Text)

            Me.lblTotalGastos.Text = Format(totalGastos, formatoMoneda)
            Me.lblTasaIncremento.Text = Format((CDec((Replace(Me.lblTotalGastos.Text, "Q", ""))) / CDec(Replace(Me.lblValorMercaderiaQ.Text, "Q", ""))), formatoMoneda)
            fnTotalMercaderiaQuetzalez()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnTotalMercaderiaQuetzalez()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim tasaincremento As Decimal = CDec(Replace(Me.lblTasaIncremento.Text, "Q", "")) + 1
                Dim tasapromedio As Decimal = CDec(Replace(Me.lblTasaCambio.Text, "Q", ""))
                Dim totalmercaderiaquetzalez As Decimal = 0

                Dim productos As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = idinvoice Select x).ToList

                For Each articulos As tblEntradasDetalle In productos
                    totalmercaderiaquetzalez += ((articulos.costoIVA * tasaincremento * tasapromedio) * CDec(articulos.cantidad))
                Next

                Me.lblTotalMercaderiaQ.Text = Format(totalmercaderiaquetzalez + CDec(Replace(Me.lblTotalGastos.Text, "Q", "")), formatoMoneda)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

#Region "Eventos Enter"

    Private Sub txtGastosNaviera_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGastosNaviera.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtGastosNaviera.Text = Format(CDec(Me.txtGastosNaviera.Text), formatoMoneda)
            fnTotal()
            Me.txtIvaImportacion.Focus()
        End If
    End Sub

    Private Sub txtIvaImportacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIvaImportacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtIvaImportacion.Text = Format(CDec(Me.txtIvaImportacion.Text), formatoMoneda)
            fnTotal()
            Me.txtImpuestoImportacion.Focus()
        End If
    End Sub

    Private Sub txtImpuestoImportacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtImpuestoImportacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtImpuestoImportacion.Text = Format(CDec(Me.txtImpuestoImportacion.Text), formatoMoneda)
            fnTotal()
            Me.txtTramitesAduanales.Focus()
        End If
    End Sub

    Private Sub txtTramitesAduanales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTramitesAduanales.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtTramitesAduanales.Text = Format(CDec(Me.txtTramitesAduanales.Text), formatoMoneda)
            fnTotal()
            Me.txtTransporte.Focus()
        End If
    End Sub

    Private Sub txtTransporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtTransporte.Text = Format(CDec(Me.txtTransporte.Text), formatoMoneda)
            fnTotal()
            Me.txtSeguridad.Focus()
        End If
    End Sub

    Private Sub txtSeguridad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSeguridad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtSeguridad.Text = Format(CDec(Me.txtSeguridad.Text), formatoMoneda)
            fnTotal()
            Me.txtComisiones.Focus()
        End If
    End Sub

    Private Sub txtComisiones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComisiones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtComisiones.Text = Format(CDec(Me.txtComisiones.Text), formatoMoneda)
            fnTotal()
            Me.txtOtrosGastos.Focus()
        End If
    End Sub

    Private Sub txtOtrosGastos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtrosGastos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtOtrosGastos.Text = Format(CDec(Me.txtOtrosGastos.Text), formatoMoneda)
            fnTotal()
            Me.txtFleteNaviera.Focus()
        End If
    End Sub

    Private Sub txtFleteNaviera_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFleteNaviera.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtFleteNaviera.Text = Format(CDec(Me.txtFleteNaviera.Text), formatoMoneda)
            fnTotal()
            Me.txtNumeroPoliza.Focus()
        End If
    End Sub

    Private Sub txtNumeroPoliza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroPoliza.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtGastosNaviera.Focus()
        End If
    End Sub
#End Region

#Region "Evento Formatos y Totales"



#End Region

#Region "Registrar"
    Private Sub fnGuardar() Handles Me.panel0
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)



                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class
