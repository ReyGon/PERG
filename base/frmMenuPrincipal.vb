Imports CrystalDecisions.CrystalReports.Engine
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Linq
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.EntityClient

Public Class frmMenuPrincipal
    Dim ctlMDI As MdiClient
    Private mdiChildCount As Integer = 0
    Dim permiso As New clsPermisoUsuario
    Dim base As New clsBase


    Private Sub FrmInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'MenuReportes.Visibility = Telerik.WinControls.ElementVisibility.Hidden

        Dim fechahoy As Date = fnFechaServidor()

        Dim usuario As tblUsuario = (From x In ctx.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

        If Day(usuario.fechaNac) = Day(fechahoy) Then
            If Month(usuario.fechaNac) = Month(fechahoy) Then
                frmCumpleanios.ShowDialog()
                frmCumpleanios.Dispose()
            End If
        End If

        itemUsuario.Text = mdlPublicVars.usuario
        itemBD.Text = mdlPublicVars.BaseDatosNombre
        FnLoad()
        fnCrearCarpetas()
    End Sub

    'Funcion utilizada para crear carpetas
    Private Sub fnCrearCarpetas()
        Dim carpetas As New ArrayList()
        carpetas.Add(mdlPublicVars.General_CarpetaImagenes)
        carpetas.Add(mdlPublicVars.BuscarArticulo_CarpetaCatalogo)
        carpetas.Add(mdlPublicVars.General_CarpetaFotosVendedor)
        carpetas.Add(mdlPublicVars.BancoCredito_CarpetaArchivos)
        carpetas.Add(mdlPublicVars.General_CarpetaDocImpresion.ToString & "\docImpresion\" + mdlPublicVars.bd.ToString & "\")

        For Each carpeta As Object In carpetas
            Dim generaCarpeta As New bl_ManejaCarpetas
            generaCarpeta.direccion = Cstr2(carpeta)
            generaCarpeta.fnPreparar()
        Next
    End Sub

    Public Function FnLoad()
        'agregar columnas a las tablas.
        mdlPublicVars.fnInicio()
        frmMenu.Text = "MENU PRINCIPAL"
        frmMenu.MdiParent = Me
        frmMenu.WindowState = FormWindowState.Maximized
        frmMenu.Show()

        'asignar metodos abreviados.
        base.FnAsignaMetodoAbreviado(Me)
        Return False
    End Function

    Private Sub ItemMenuPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMenuPrincipal.Click
        Dim frm As Form = frmMenu
        frm.Text = "MENU PRINCIPAL"
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub frmMenuPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If RadMessageBox.Show("Desea cerrar !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Application.ExitThread()
                Application.Exit()
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub tmHora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmHora.Tick
    '    lblValorFechaHora.Text = Now
    'End Sub

    Private Sub itemMenuEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemMenuEmpresa.Click
        Dim frm = frmEmpresa
        frm.Text = "Empresas"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm,True)
    End Sub

    Private Sub itemUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemUsuarios.Click
        Dim frm = frmUsuario
        frm.Text = "Usuarios"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemImpresoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemImpresoras.Click
        Dim frm = frmImpresora
        frm.Text = "Impresoras"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemCorrelativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemCorrelativos.Click
        Dim frm = frmCorrelativos
        frm.Text = "Correlativos"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemGrupoUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemGrupoUsuarios.Click
        Dim frm = frmGruposUsuarios
        frm.Text = "Grupos de Usuarios"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemGruposFormas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemGruposFormas.Click
        Dim frm = frmGruposFormas
        frm.Text = "Grupos y Formularios"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm,True)
    End Sub

    Private Sub itemReporteVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemReporteVentas.Click
        Dim frm = frmReporteVentas
        frm.Text = "Reporte de Ventas"
        frm.MdiParent = Me
        permiso.PermisoFrmEspeciales(frm, True)
    End Sub

    Private Sub itemVendedor_Click(sender As System.Object, e As System.EventArgs) Handles itemVendedor.Click
        Dim frm = frmVendedor
        frm.Text = "Vendedor"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemReporteInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemReporteInventario.Click
        frmReporteInventario.Text = "Reporte de Inventario"
        frmReporteInventario.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmReporteInventario)
        frmReporteInventario.Dispose()
    End Sub

    Private Sub itemConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemConfiguracion.Click
        frmConfiguracion.Text = "Configuración Sistema"
        frmConfiguracion.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmConfiguracion)
        frmConfiguracion.Dispose()
    End Sub

    Private Sub itemPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemPerfil.Click
        frmPerfilUsuario.Text = "Perfil"
        frmPerfilUsuario.StartPosition = FormStartPosition.CenterScreen
        frmPerfilUsuario.ShowDialog()
        frmPerfilUsuario.Dispose()
    End Sub

    Private Sub itemCambioUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemCambioUsuario.Click
        frmCambioUsuario.Text = "Cambio Usuario"
        frmCambioUsuario.StartPosition = FormStartPosition.CenterScreen
        frmCambioUsuario.ShowDialog()
        frmCambioUsuario.Dispose()
    End Sub

    Private Sub itemReporteVentasMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemReporteVentasMes.Click
        frmComprasVentasMes.Text = "Reporte Ventas/Mes"
        frmComprasVentasMes.bitVenta = True
        frmComprasVentasMes.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmComprasVentasMes)
        frmComprasVentasMes.Dispose()
    End Sub

    Private Sub itemReporteComprasMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemReporteComprasMes.Click
        frmComprasVentasMes.Text = "Reporte Compras/Mes"
        frmComprasVentasMes.bitCompra = True
        frmComprasVentasMes.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmComprasVentasMes)
        frmComprasVentasMes.Dispose()
    End Sub

    Private Sub itemImportarVentas_Click(sender As System.Object, e As System.EventArgs) Handles itemImportarVentas.Click
        frmImportarVentas.Text = "Importar Ventas"
        frmImportarVentas.StartPosition = FormStartPosition.CenterParent
        frmImportarVentas.Show()
    End Sub

    Private Sub itemImportarCompras_Click(sender As System.Object, e As System.EventArgs) Handles itemImportarCompras.Click
        frmImportarCompras.Text = "Importar Compras"
        frmImportarCompras.StartPosition = FormStartPosition.CenterParent
        frmImportarCompras.Show()
    End Sub

    Private Sub itemImportarPagos_Click(sender As Object, e As EventArgs) Handles itemImportarPagos.Click
        frmImportarPagos.Text = "Importar Pagos"
        frmImportarPagos.StartPosition = FormStartPosition.CenterParent
        frmImportarPagos.Show()
    End Sub

    Private Sub itemClasificacionBitacora_Click(sender As Object, e As EventArgs) Handles itemClasificacionBitacora.Click
        Try
            Dim frm = frmBitacoraCategoria
            frm.Text = "Clasificacion de Bitacoras"
            frm.MdiParent = Me
            permiso.PermisoMantenimientoTelerik(frm, True)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'IMPORTAR CLIENTES
    Private Sub itemImportarClientes_Click(sender As Object, e As EventArgs) Handles itemImportarClientes.Click
        frmImportarClientes.Text = "Importar Clientes"
        frmImportarClientes.StartPosition = FormStartPosition.CenterParent
        frmImportarClientes.Show()
    End Sub

    Private Sub itemImportarProveedores_Click(sender As Object, e As EventArgs) Handles itemImportarProveedores.Click
        frmImportarProveedor.Text = "Importar Proveedores"
        frmImportarProveedor.StartPosition = FormStartPosition.CenterParent
        frmImportarProveedor.Show()
    End Sub

    Private Sub itemResolucionFactura_Click(sender As Object, e As EventArgs) Handles itemResolucionFactura.Click
        frmFacturaResoluciones.Text = "Resoluciones de Factura"
        frmFacturaResoluciones.StartPosition = FormStartPosition.CenterScreen
        permiso.PermisoDialogEspeciales(frmFacturaResoluciones)
        frmFacturaResoluciones.Dispose()
    End Sub

    Private Sub itemImpuestos_Click(sender As Object, e As EventArgs) Handles itemImpuestos.Click
        Dim frm = frmImpuesto
        frm.Text = "Impuestos del Sistema"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemImpuestosPagar_Click(sender As Object, e As EventArgs)
        Dim frm = frmImpuestoPagar
        frm.Text = "Impuestos por Pagar"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemImpuestosPagarMovimientos_Click(sender As Object, e As EventArgs)
        Dim frm = frmImpuestoPagarMovimiento
        frm.text = "Impuesto por Pagar y Movimientos"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemImpuestosCobrar_Click(sender As Object, e As EventArgs)
        Dim frm = frmImpuestoCobrar
        frm.text = "Impuestos por Cobrar"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemImpuestosCobrarMovimientos_Click(sender As Object, e As EventArgs)
        Dim frm = frmImpuestoCobrarMovimiento
        frm.text = "Impuestos por Cobrar y Movimientos"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemTipoEmpleado_Click(sender As Object, e As EventArgs) Handles itemTipoEmpleado.Click
        Dim frm = frmTipoEmpleado
        frm.text = "Tipos de Empleado"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub itemEmpleado_Click(sender As Object, e As EventArgs) Handles itemEmpleado.Click
        Dim frm = frmEmpleados
        frm.text = "Empleados"
        frm.mdiparent = Me
        permiso.PermisoFrmBaseEspeciales(frm, True)
    End Sub

    ''Private Sub itemTiposTransportes_Click(sender As Object, e As EventArgs)
    ''    Dim frm = frmTiposTransportes
    ''    frm.text = "Tipos de Transporte"
    ''    frm.mdiparent = Me
    ''    permiso.PermisoMantenimientoTelerik(frm, True)
    ''End Sub

    ''Private Sub itemVehiculos_Click(sender As Object, e As EventArgs)
    ''    Dim frm = frmTransportes
    ''    frm.text = "Transporte"
    ''    frm.mdiparent = Me
    ''    permiso.PermisoMantenimientoTelerik(frm, True)
    ''End Sub

    ''Private Sub itemSectoresTiposTransportes_Click(sender As Object, e As EventArgs)
    ''    Dim frm = frmSectoresTiposTransportes
    ''    frm.text = "Sectores con Tipos de Transportes"
    ''    frm.mdiparent = Me
    ''    permiso.PermisoMantenimientoTelerik(frm, True)
    ''End Sub

    ''Private Sub itemSectores_Click(sender As Object, e As EventArgs)
    ''    Dim frm = frmSector
    ''    frm.text = "Sectores"
    ''    frm.mdiparent = Me
    ''    permiso.PermisoMantenimientoTelerik(frm, True)
    ''End Sub

    Private Sub itemSucursales_Click(sender As Object, e As EventArgs) Handles itemSucursales.Click
        Dim frm As New frmSucursales
        frm.Text = "Sucursales"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub rdmImpuestos_Click(sender As Object, e As EventArgs) Handles rdmImpuestos.Click
        Dim frm = frmImpuesto
        frm.Text = "Impuestos del Sistema"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub rdmImpuestosPorPagar_Click(sender As Object, e As EventArgs) Handles rdmImpuestosPorPagar.Click
        Dim frm = frmImpuestoPagar
        frm.Text = "Impuestos por Pagar"
        frm.MdiParent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub rdmImpuestosPorPagaryMovimientos_Click(sender As Object, e As EventArgs) Handles rdmImpuestosPorPagaryMovimientos.Click
        Dim frm = frmImpuestoPagarMovimiento
        frm.text = "Impuesto por Pagar y Movimientos"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub rdmImpuestosPorCobrar_Click(sender As Object, e As EventArgs) Handles rdmImpuestosPorCobrar.Click
        Dim frm = frmImpuestoCobrar
        frm.text = "Impuestos por Cobrar"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub rdmImpuestosPorCobraryMovimientos_Click(sender As Object, e As EventArgs) Handles rdmImpuestosPorCobraryMovimientos.Click
        Dim frm = frmImpuestoCobrarMovimiento
        frm.text = "Impuestos por Cobrar y Movimientos"
        frm.mdiparent = Me
        permiso.PermisoMantenimientoTelerik(frm, True)
    End Sub

    Private Sub rdmActualizador_Click(sender As Object, e As EventArgs) Handles rdmActualizador.Click
        Try
            frmActualizadorCreador.Text = "Actualizador/Creador"
            frmActualizadorCreador.WindowState = FormWindowState.Normal
            frmActualizadorCreador.StartPosition = FormStartPosition.CenterScreen
            frmActualizadorCreador.ShowDialog()
            frmActualizadorCreador.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdmConsultas_Click(sender As Object, e As EventArgs) Handles rdmConsultas.Click
        Dim frm = frmConsultasDinamicas
        frm.text = "Consultas BD"
        frm.mdiparent = Me
        permiso.PermisoFrmBaseEspeciales(frm, True)

        ''frmConsultasDinamicas.Text = "Consultas Dinamicas"
        ''frmConsultasDinamicas.StartPosition = FormStartPosition.CenterScreen
        ''frmConsultasDinamicas.WindowState = FormWindowState.Maximized
        ''frmConsultasDinamicas.ShowDialog()
        ''frmConsultasDinamicas.Dispose()

    End Sub

    Private Sub RadMenuItem1_Click(sender As Object, e As EventArgs)
        Dim frm = frmEnvioCorreo
        frm.text = "Correos"
        frm.mdiparent = Me
        permiso.PermisoFrmBaseEspeciales(frm, True)
    End Sub

    Private Sub rdmReportesAdministrativos_Click(sender As Object, e As EventArgs) Handles rdmReportesDinamicos.Click
        Dim frm = frmReportesDinamicos
        frm.text = "Reportes Dinamicos"
        frm.mdiparent = Me
        permiso.PermisoFrmBaseEspeciales(frm, True)
    End Sub

    Private Sub rdmReportesAdministrativos_Click_1(sender As Object, e As EventArgs) Handles rdmReportesAdministrativos.Click
        frmReportesAdministrativos.Text = "Reportes Administrativos"
        frmReportesAdministrativos.StartPosition = FormStartPosition.CenterScreen
        frmReportesAdministrativos.WindowState = FormWindowState.Normal
        permiso.PermisoDialogEspeciales(frmReportesAdministrativos)
        frmReportesAdministrativos.Dispose()
    End Sub

    Private Sub rmdToken_Click(sender As Object, e As EventArgs) Handles rmdToken.Click
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim u As tblUsuario = (From x In conexion.tblUsuarios Where x.idUsuario = mdlPublicVars.idUsuario Select x).FirstOrDefault

                If u.bitAutorizaVenta = True Then

                    Dim t As New Random()
                    Dim token As Integer = t.Next(1000, 9999)

                    Dim c As tblConfiguracion = (From x In conexion.tblConfiguracions Where x.id = 124 Select x).FirstOrDefault

                    c.valor = token
                    conexion.SaveChanges()

                    RadMessageBox.Show("El Token Generado es: " + CStr(token), nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                Else
                    RadMessageBox.Show("No Tiene Permiso Para Generar Tokens", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    conn.Close()
                    Exit Sub
                End If

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class