Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmBitacoraLista
    Private permiso As New clsPermisoUsuario
    Private _proveedor As Boolean

    Public Property proveedor() As Boolean
        Get
            proveedor = _proveedor
        End Get
        Set(ByVal value As Boolean)
            _proveedor = value
        End Set
    End Property

    Private Sub frmBitacoraLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If proveedor Then
                Dim iz As New frmProveedorBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
                ActivarBarraLateral = True
            Else
                Dim iz As New frmClientesBarraIzquierda
                iz.frmAnterior = Me
                frmBarraLateralBaseIzquierda = iz
                ActivarBarraLateral = True
            End If

            pnlOpciones.Visible = False
            pnlOpciones.Enabled = False
        Catch ex As Exception

        End Try
        llenagrid()
    End Sub

    Private Sub llenagrid()
        Try
            Me.grdDatos.DataSource = Nothing
            Dim filtro As String = txtFiltro.Text
            Dim bitacoraInfo = Nothing
            If proveedor = True Then
                bitacoraInfo = (From x In ctx.tblBitacoras _
                                Where x.IdEmpresa = mdlPublicVars.idEmpresa And x.bitProveedor = True And x.bitCliente = False _
                                And (CType(x.tblProveedor.idProveedor, String).Contains(filtro) Or x.tblProveedor.negocio.Contains(filtro) Or x.tblBitacoraCategoria.Nombre.Contains(filtro)) _
                                Select Codigo = x.IdBitacora, Fecha = x.FechaRegistro, Clave = x.tblProveedor.idProveedor, Nombre = x.tblProveedor.negocio, Concepto = x.tblBitacoraCategoria.Nombre, _
                                Observacion = x.observacion, chkRecordatorio = x.recordatorio, FechaRecordatorio = x.programacion, chkCerrado = x.cerrado, FechaCerrado = x.fechaCerrado)
            Else
                'Clientes
                bitacoraInfo = (From x In ctx.tblBitacoras _
                                Where x.IdEmpresa = mdlPublicVars.idEmpresa And x.bitProveedor = False And x.bitCliente = True _
                                And (CType(x.tblCliente.clave, String).Contains(filtro) Or x.tblCliente.Negocio.Contains(filtro) Or x.tblBitacoraCategoria.Nombre.Contains(filtro)) _
                                Select Codigo = x.IdBitacora, Fecha = x.FechaRegistro, Clave = x.tblCliente.clave, Nombre = x.tblCliente.Negocio, Concepto = x.tblBitacoraCategoria.Nombre, _
                                Observacion = x.observacion, chkRecordatorio = x.recordatorio, FechaRecordatorio = x.programacion, chkCerrado = x.cerrado, FechaCerrado = x.fechaCerrado)
            End If

            
            Me.grdDatos.DataSource = bitacoraInfo
            fnConfiguracion()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then

                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "FechaRecordatorio")
                Me.grdDatos.Columns("Codigo").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Clave").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("Nombre").TextAlignment = ContentAlignment.MiddleLeft
                Me.grdDatos.Columns("Concepto").TextAlignment = ContentAlignment.MiddleLeft
                Me.grdDatos.Columns("Observacion").TextAlignment = ContentAlignment.MiddleLeft
                Me.grdDatos.Columns("chkRecordatorio").TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns("FechaRecordatorio").TextAlignment = ContentAlignment.MiddleCenter

                Me.grdDatos.Columns("Codigo").Width = 60
                Me.grdDatos.Columns("Fecha").Width = 80
                Me.grdDatos.Columns("Clave").Width = 60
                Me.grdDatos.Columns("Nombre").Width = 170
                Me.grdDatos.Columns("Concepto").Width = 100
                Me.grdDatos.Columns("Observacion").Width = 170
                Me.grdDatos.Columns("chkRecordatorio").Width = 80
                Me.grdDatos.Columns("FechaRecordatorio").Width = 80
                Me.grdDatos.Columns("chkCerrardo").Width = 70

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub

    Private Sub frm_nuevo() Handles Me.nuevoRegistro
        If Me.grdDatos.Rows.Count > 0 Then
            frmBitacora.StartPosition = FormStartPosition.CenterScreen
            frmBitacora.idCliente = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells(2).Value
            frmBitacora.Text = "Bitacora"
            permiso.PermisoFrmEspeciales(frmBitacora, False)
        End If
        'permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub frm_modificar() Handles Me.modificaRegistro
        If Me.grdDatos.Rows.Count > 0 Then
            Dim permiso As New clsPermisoUsuario
            frmBitacora.StartPosition = FormStartPosition.CenterScreen
            Dim recordatorio As Boolean = CType(grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells(6).Value, Boolean)
            Dim cerrado As Boolean = CType(grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells(8).Value, Boolean)
            If cerrado = True And recordatorio = True Then
                alertas.contenido = "Registro cerrado"
                alertas.fnErrorContenido()
            ElseIf recordatorio = True Then
                frmBitacora.Text = "Bitacora"
                frmBitacora.superSearchId = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells(0).Value
                frmBitacora.modifica = True
                permiso.PermisoFrmEspeciales(frmBitacora, False)
            Else
                alertas.contenido = "Este registro no se puede modificar"
                alertas.fnErrorContenido()
            End If
        End If
    End Sub

    Private Sub frm_eliminar() Handles Me.eliminaRegistro
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                alertas.contenido = "Bitacora no se puede eliminar"
                alertas.fnErrorContenido()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_ver() Handles Me.verRegistro
        If Me.grdDatos.Rows.Count > 0 Then
            Dim permiso As New clsPermisoUsuario
            frmBitacora.StartPosition = FormStartPosition.CenterScreen
            frmBitacora.Text = "Bitacora"
            frmBitacora.superSearchId = Me.grdDatos.Rows(Me.grdDatos.CurrentRow.Index).Cells(0).Value
            frmBitacora.ver = True
            permiso.PermisoFrmEspeciales(frmBitacora, False)
        End If
    End Sub

    Private Sub frmBitacoraLista_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Lista Bitacoras de: " & If(proveedor, "Proveedores", "Clientes")
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub
End Class
