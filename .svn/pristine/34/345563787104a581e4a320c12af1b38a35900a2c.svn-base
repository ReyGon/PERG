Imports System.Linq
Imports Telerik.WinControls

Public Class frmCierreCajaAjuste


#Region "Variables"
    Private _idCierreCaja As Integer
    Public Property idCierreCaja As Integer
        Get
            idCierreCaja = _idCierreCaja
        End Get
        Set(value As Integer)
            _idCierreCaja = value
        End Set
    End Property


#End Region

#Region "Funciones"
    'GUARDAR AJUSTE DE CIERRE DE CAJA
    Private Sub fnGuardarAjuste()
        Try
            If txtObservacion.Text.Trim.Length = 0 Then
                RadMessageBox.Show("Ingrese una observación", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

            If nm2Monto.Value <= 0 Then
                RadMessageBox.Show("Ingrese un monto mayor a cero", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End If

            Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor
            'Obtenemos el encabezado del cierre de caja
            Dim cierre As tblCierreCaja = (From x In ctx.tblCierreCajas Where x.codigo = idCierreCaja Select x).FirstOrDefault

            cierre.fechaAjuste = fechaServidor
            cierre.bitAjuste = True
            cierre.observacionAjuste = txtObservacion.Text
            cierre.usuarioAjuste = mdlPublicVars.idUsuario
            cierre.montoAjuste = nm2Monto.Value

            ctx.SaveChanges()
            alerta.fnGuardar()
            frmCierreCajaRevision.fnLlenarDatos()
            Me.Close()
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub
#End Region

#Region "#Eventos"
    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If RadMessageBox.Show("¿Desea realizar el ajuste?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardarAjuste()
        End If
    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
#End Region

End Class
