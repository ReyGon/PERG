Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmTiposPago

    Public bitCliente As Boolean
    Public bitProveedor As Boolean


    Private Sub frmTiposPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If bitCliente = True Then
                Dim iz As New frmClientesBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
                ActivarBarraLateral = True
            End If

            If bitProveedor = True Then
                Dim iz As New frmProveedorBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
                ActivarBarraLateral = True
            End If
            fnLlenarCombo()
        Catch ex As Exception
        End Try
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar el grid
    Private Sub fnLlenarCombo()
        Dim cuenta = (From x In ctx.tblCajas Take 1 Select New With {.codigo = 0, .nombre = "Ninguna"}).Union(
                      From x In ctx.tblBanco_Cuenta Select New With {.codigo = x.codigo, .nombre = x.numeroCuenta & " (" & x.tblBanco.nombre & ")"})

        With cmbCuenta
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = cuenta
        End With
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblTipoPagoes Select Codigo = x.codigo, Nombre = x.nombre, chkCalendarizado = x.calendarizada, _
                       chkSalida = x.salida, chkEntrada = x.entrada, chkNecesitaFecha = x.prefechado,
                       Cuenta = x.tblBanco_Cuenta.numeroCuenta & " (" & x.tblBanco_Cuenta.tblBanco.nombre & ")", chkCaja = x.caja, chkCheque = x.cheque

            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            grdDatos.Columns(0).Width = 150
        Catch e As Exception
        End Try
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_primerCampo() Handles Me.focoDatos
        Me.txtNombre.Focus()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro

        Dim m As New tblTipoPago
        Try
            m.nombre = txtNombre.Text

            If chkCalendarizado.Checked = True Then
                m.calendarizada = True
                m.transito = True
            Else
                m.calendarizada = False
                m.transito = False
            End If

            m.entrada = chkEntrada.Checked
            m.salida = chkSalida.Checked
            m.prefechado = chkNecesitaFecha.Checked
            m.caja = chkCaja.Checked
            m.cheque = chkCheque.Checked

            If CInt(cmbCuenta.SelectedValue) > 0 Then
                m.cuenta = CInt(cmbCuenta.SelectedValue)
            Else
                m.cuenta = Nothing
            End If


            ctx.AddTotblTipoPagoes(m)
            ctx.SaveChanges()

            alertas.fnGuardar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try

            Dim m As tblTipoPago = (From e1 In ctx.tblTipoPagoes Where e1.codigo = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            If chkCalendarizado.Checked = True Then
                m.calendarizada = True
                m.transito = True
            Else
                m.calendarizada = False
                m.transito = False
            End If

            m.entrada = chkEntrada.Checked
            m.salida = chkSalida.Checked
            m.prefechado = chkNecesitaFecha.Checked
            m.caja = chkCaja.Checked
            m.cheque = chkCheque.Checked

            If CInt(cmbCuenta.SelectedValue) > 0 Then
                m.cuenta = CInt(cmbCuenta.SelectedValue)
            Else
                m.cuenta = Nothing
            End If
            ctx.SaveChanges()

            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If RadMessageBox.Show("¿Esta seguro de eliminar este registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblTipoPago = (From e1 In ctx.tblTipoPagoes Where e1.codigo = Me.txtCodigo.Text Select e1).First()

            ctx.DeleteObject(m)
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub chkEntrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEntrada.CheckedChanged
        If chkEntrada.Checked = True Then
            chkSalida.Checked = False
        Else
            chkSalida.Checked = True
        End If
    End Sub

    Private Sub chkSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalida.CheckedChanged
        If chkSalida.Checked = True Then
            chkEntrada.Checked = False
        Else
            chkEntrada.Checked = True
        End If
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista de Tipos de Pagos de Clientes"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub


End Class
