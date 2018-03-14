Imports System.Linq
Imports Telerik.WinControls

Public Class frmBancoDebitoConcepto
    Private _idMovimiento As Integer
    Private _bitDebito As Boolean
    Private _bitCredito As Boolean

    Public Property idMovimiento As Integer
        Get
            idMovimiento = _idMovimiento
        End Get
        Set(ByVal value As Integer)
            _idMovimiento = value
        End Set
    End Property

    Public Property bitDebito As Boolean
        Get
            bitDebito = _bitDebito
        End Get
        Set(ByVal value As Boolean)
            _bitDebito = value
        End Set
    End Property

    Public Property bitCredito As Boolean
        Get
            bitCredito = _bitCredito
        End Get
        Set(ByVal value As Boolean)
            _bitCredito = value
        End Set
    End Property

    Private Sub frmBancoChequeConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarDatos()
    End Sub

    'LLENA LOS DATOS
    Private Sub fnLlenarDatos()
        'Obtenemos el encabezado del cheque
        Dim movimiento = Nothing

        If bitDebito Then
            movimiento = New tblBanco_Debitos
            movimiento = (From x In ctx.tblBanco_Debitos Where x.codigo = idMovimiento
                                         Select x).FirstOrDefault
            If movimiento IsNot Nothing Then
                'Llenamos los datos del movimiento
                lblFechaRegistro.Text = Format(movimiento.fechaRegistro, mdlPublicVars.formatoFecha)
                lblAnulado.Text = If(movimiento.bitAnulado, "SI", "NO")
                lblBanco.Text = movimiento.tblBanco_Cuenta.tblBanco.nombre
                lblBeneficiario.Text = movimiento.nombre
                lblConfirmado.Text = If(movimiento.bitConfirmado, "SI", "NO")
                lblCorrelativo.Text = movimiento.correlativo
                lblCuenta.Text = movimiento.tblBanco_Cuenta.numeroCuenta
                lblConcepto.Text = movimiento.tblBanco_MovimientoConcepto.nombre
                lblDocumento.Text = movimiento.documento
                lblFechaAnulado.Text = If(movimiento.fechaAnulado Is Nothing, "", Format(movimiento.fechaAnulado, mdlPublicVars.formatoFecha))
                lblFechaConfirmado.Text = If(movimiento.fechaConfirmado Is Nothing, "", Format(movimiento.fechaConfirmado, mdlPublicVars.formatoFecha))
                lblTotal.Text = Format(movimiento.monto, mdlPublicVars.formatoMoneda)
                lblUsuarioAnulo.Text = If(movimiento.usuarioAnula Is Nothing, "", movimiento.tblUsuario.nombre)
                lblUsuarioConfirmo.Text = If(movimiento.usuarioConfirma Is Nothing, "", movimiento.tblUsuario1.nombre)
            End If
        ElseIf bitCredito Then
            movimiento = New tblBanco_Creditos
            movimiento = (From x In ctx.tblBanco_Creditos Where x.codigo = idMovimiento
                                        Select x).FirstOrDefault

            If movimiento IsNot Nothing Then
                'Llenamos los datos del movimiento
                lblFechaRegistro.Text = Format(movimiento.fechaRegistro, mdlPublicVars.formatoFecha)
                lblAnulado.Text = If(movimiento.bitAnulado, "SI", "NO")
                lblBanco.Text = movimiento.tblBanco_Cuenta.tblBanco.nombre
                lblBeneficiario.Text = movimiento.nombre
                lblConfirmado.Text = If(movimiento.bitConfirmado, "SI", "NO")
                lblCorrelativo.Text = movimiento.correlativo
                lblCuenta.Text = movimiento.tblBanco_Cuenta.numeroCuenta
                lblConcepto.Text = movimiento.tblBanco_MovimientoConcepto.nombre
                lblDocumento.Text = movimiento.documento
                lblFechaAnulado.Text = If(movimiento.fechaAnulado Is Nothing, "", Format(movimiento.fechaAnulado, mdlPublicVars.formatoFecha))
                lblFechaConfirmado.Text = If(movimiento.fechaConfirmado Is Nothing, "", Format(movimiento.fechaConfirmado, mdlPublicVars.formatoFecha))
                lblTotal.Text = Format(movimiento.monto, mdlPublicVars.formatoMoneda)
                lblUsuarioAnulo.Text = If(movimiento.usuarioAnula Is Nothing, "", movimiento.tblUsuario.nombre)
                lblUsuarioConfirmo.Text = If(movimiento.usuarioConfirma Is Nothing, "", movimiento.tblUsuario1.nombre)
            End If
        End If



    End Sub


    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub
End Class
