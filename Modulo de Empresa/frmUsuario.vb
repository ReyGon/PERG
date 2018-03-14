Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmUsuario

    Dim blUsr As New bl_Usuario

    Private Sub frmUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        llenagrid()
    End Sub

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    'Funcion utilizada para llenar los combos
    Private Sub llenarCombos()
        Try
            'Vendedores
            Dim vendedores = (From x In ctx.tblVendedors Select Codigo = x.idVendedor, Nombre = x.nombre)

            With cmbVendedor
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = vendedores
            End With

            'Grupos
            Dim grupos = (From x In ctx.tblGrupoUsuarios Select Codigo = x.idGrupo, Nombre = x.nombre)

            With cmbGrupo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = grupos
            End With

            Dim precio = (From x In ctx.tblArticuloTipoPrecios Where x.bitEspecial = False Select Codigo = x.codigo, Nombre = x.nombre)

            With cmbTipoPrecio
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = precio
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros en la tabla Surtir Categoria.. 
            Dim Data = From x In ctx.tblUsuarios _
                       Select Codigo = x.idUsuario, Nombre = x.nombre, Grupo = x.tblGrupoUsuario.nombre, Vendedor = x.tblVendedor.nombre, _
                       Clave = x.ClaveAccesos, chkBloqueado = x.bloqueado, chkSuperUsuario = x.superUsuario, chkEditaPreciosLiquidacion = x.editaPreciosLiquidacion, _
                       chkAutorizaCreditos = x.AutorizaCredito, ModuloImpresionCorreo = x.ModuloImpresion_correo, chkAutorizaVentas = x.bitAutorizaVenta,
                       chkConfirmaPago = x.bitConfirmaPago, chkPrecioUltimasVentas = x.bitUltimasVentas, chkAutorizaPrecios = x.bitAutorizaPrecios, TipoPrecio = x.tblArticuloTipoPrecio.nombre


            'Llenamos el grid de los datos con la consulta..
            Me.grdDatos.DataSource = Data
            'grdDatos.Columns(0).Width = 150

            Me.grdDatos.Columns("TipoPrecio").IsVisible = False
        Catch ex As Exception
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

        Dim clave As String = InputBox("", "Clave, Minimo 5 caracteres")
        If clave.Length > 4 Then

        Else
            alertas.contenido = "Requiere minimo 5 caracteres"
            alertas.fnErrorContenido()
            Exit Sub
        End If

        Dim m As New tblUsuario
        Try
            m.nombre = txtNombre.Text
            m.idVendedor = cmbVendedor.SelectedValue
            m.idGrupo = cmbGrupo.SelectedValue
            m.AutorizaCredito = chkAutorizaCreditos.Checked
            m.bloqueado = chkBloqueado.Checked
            m.ClaveAccesos = txtClave.Text
            m.editaPreciosLiquidacion = chkEditaPreciosLiquidacion.Checked
            m.superUsuario = chkSuperUsuario.Checked
            m.clave = blUsr.fnSerieEncriptadaValida(clave)
            m.ModuloImpresion_correo = chkModuloImpresionCorreo.Checked
            m.bitAutorizaVenta = chkAutorizaVentas.Checked
            m.bitConfirmaPago = chkConfirmaPago.Checked
            m.bitUltimasVentas = chkPrecioUltimasVentas.Checked
            m.bitAutorizaPrecios = chkAutorizaPrecios.Checked
            m.tipoprecio = cmbTipoPrecio.SelectedValue


            ctx.AddTotblUsuarios(m)
            ctx.SaveChanges()

            Dim ue As New tblusuarioEmpresa
            ue.idempresa = mdlPublicVars.idEmpresa
            ue.idusuario = m.idUsuario
            ctx.AddTotblusuarioEmpresas(ue)

            ctx.SaveChanges()

            alertas.fnGuardar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
    End Sub

    Private Function creaUsuarioBd(ByVal opcion As Integer) As Int16
        Dim tbl As New clsDevuelveTabla
        Dim str As String
        Dim contraseña As String = "0"
        If opcion = 1 Then
            contraseña = InputBox("Ingrese su password", "!!!")
        End If

        str = "exec sp_adminUser " & opcion & "," & mdlPublicVars.bd & "," & Me.txtNombre.Text & "," & contraseña
        tbl.sqlString = str
        Return tbl.ejecutaSQL
    End Function

    Private Sub cambioContraseña()
        Dim tbl As New clsDevuelveTabla
        Dim str As String
        Dim pwActual, pwNuevo As String
        pwActual = InputBox("Contraseña Actual", "!!!")
        pwNuevo = InputBox("Contraseña Nueva", "!!!")

        str = "exec sp_password '" & pwActual & "','" & pwNuevo & "','" & Me.txtNombre.Text & "'"
        tbl.sqlString = str
        If tbl.ejecutaSQL() <> 0 Then
            MsgBox("Contraseña grabada satisfactoriamente", MsgBoxStyle.Exclamation, "!!!")
            Exit Sub
        End If
    End Sub


    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try
            Dim m As tblUsuario = (From e1 In ctx.tblUsuarios Where e1.idUsuario = Me.txtCodigo.Text Select e1).First()
            m.nombre = txtNombre.Text
            m.idVendedor = cmbVendedor.SelectedValue
            m.idGrupo = cmbGrupo.SelectedValue
            m.AutorizaCredito = chkAutorizaCreditos.Checked
            m.bloqueado = chkBloqueado.Checked
            m.ClaveAccesos = txtClave.Text
            m.editaPreciosLiquidacion = chkEditaPreciosLiquidacion.Checked
            m.superUsuario = chkSuperUsuario.Checked
            m.ModuloImpresion_correo = chkModuloImpresionCorreo.Checked
            m.bitAutorizaVenta = chkAutorizaVentas.Checked
            m.bitConfirmaPago = chkConfirmaPago.Checked
            m.bitUltimasVentas = chkPrecioUltimasVentas.Checked
            m.bitAutorizaPrecios = chkAutorizaPrecios.Checked
            m.tipoprecio = cmbTipoPrecio.SelectedValue

            ctx.SaveChanges()
            alertas.fnModificar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try
    End Sub


    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
            Dim m As tblUsuario = (From e1 In ctx.tblUsuarios Where e1.idUsuario = Me.txtCodigo.Text Select e1).First()

            m.bloqueado = False
            ctx.SaveChanges()

            alertas.fnEliminar()

            Call llenagrid()

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try
    End Sub

    Private Sub frmUsuario_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnDocSalida() Handles Me.reporte
        frmDocumentosSalida.txtTitulo.Text = "Lista: Usuarios"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub btnCambioClave_Click(sender As System.Object, e As System.EventArgs) Handles btnCambioClave.Click
        Try
            If RadMessageBox.Show("Desea cambiar la clave", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then

                Dim clave As String = InputBox("", "Clave Nueva, minimo 5 caracteres")

                If clave.Length > 4 Then
                    Dim cod As Integer = txtCodigo.Text
                    Dim usr As tblUsuario = (From x In ctx.tblUsuarios Where x.idUsuario = cod Select x).FirstOrDefault

                    If usr IsNot Nothing Then
                        'cambiar clave
                        usr.clave = blUsr.fnSerieEncriptadaValida(clave)
                        ctx.SaveChanges()
                        alertas.fnGuardar()
                    Else
                        'no cambiar clave
                        alertas.fnError()
                    End If
                Else
                    alertas.contenido = "Requiere minimo 5 caracteres"
                    alertas.fnErrorContenido()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
