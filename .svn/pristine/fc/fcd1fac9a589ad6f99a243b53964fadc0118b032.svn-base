Public Class frmClientesBarraDerecha
    Dim permiso As New clsPermisoUsuario

    Private Sub frmClientesBarraLateral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl2.Focus()
    End Sub

    Private Sub fnPanel1() Handles Me.panel1
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                'Dim frm As Form = frmClienteDevolucion
                frmClienteDevolucion.Text = "Devolución de Cliente"
                frmClienteDevolucion.MdiParent = frmMenuPrincipal
                permiso.PermisoFrmEspeciales(frmClienteDevolucion, True)
                Me.Hide()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmClienteEstadoCuenta.Text = "Estado de Cuenta"
                frmClienteEstadoCuenta.cliente = CType(mdlPublicVars.superSearchId, Integer)
                frmClienteEstadoCuenta.StartPosition = FormStartPosition.CenterScreen
                frmClienteEstadoCuenta.BringToFront()
                frmClienteEstadoCuenta.Focus()
                permiso.PermisoDialogEspeciales(frmClienteEstadoCuenta)
                frmClienteEstadoCuenta.Dispose()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnPanel3() Handles Me.panel3
        Try
            If mdlPublicVars.superSearchFilasGrid > 0 Then
                frmBitacora.idCliente = CType(mdlPublicVars.superSearchId, Integer)
                frmBitacora.idVendedor = mdlPublicVars.idVendedor
                frmBitacora.fecha = CType(mdlPublicVars.fnFecha_horaServidor, DateTime)
                frmBitacora.proveedor = False
                frmBitacora.Text = "Bitacora"
                frmBitacora.StartPosition = FormStartPosition.CenterScreen
                permiso.PermisoDialogEspeciales(frmBitacora)
                frmBitacora.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'PENDIENTES POR PEDIR
    Private Sub fnPanel4() Handles Me.panel4
        frmBuscarArticuloPendientePedir.Text = "Productos por Pedir"
        frmBuscarArticuloPendientePedir.codigo = CType(mdlPublicVars.superSearchId, Integer)
        frmBuscarArticuloPendientePedir.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmBuscarArticuloPendientePedir)
        frmBuscarArticuloPendientePedir.Dispose()
    End Sub

    'agregar boleta a cliente
    Private Sub fnPanel5() Handles Me.panel5
        frmBuscarArticuloPendientePedir.Text = "Agregar Boleta"
        frmBuscarArticuloPendientePedir.codigo = CType(mdlPublicVars.superSearchId, Integer)
        frmBuscarArticuloPendientePedir.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmBuscarArticuloPendientePedir)
        frmBuscarArticuloPendientePedir.Dispose()
    End Sub

End Class
