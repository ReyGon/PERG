''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Linq
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Drawing
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net.Mail
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmDespachoFacturaBarraDerecha

#Region "Variables"

    Public alerta As New bl_Alertas
    Private blPedidos As New bl_Pedidos
    Private permiso As New clsPermisoUsuario
    Private _bitCrearImprimpir As Boolean
    Public creadevolucion As Boolean = False
#End Region

#Region "Eventos"

    Private Sub frmDespachoFacturaBarraDerecha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ''frmDespachoFacturaListaTransportes.fnLlenarLista()
    End Sub
    'LOAD
    Private Sub frmDespachoFacturaBarraDerecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        izquierda = False
        derecha = True
        fnAjustarTamano()
        pnl1.Focus()
    End Sub

    'VER FLETES
    Private Sub fnPanel1() Handles Me.panel1
        ''Try

        ''    creadevolucion = False

        ''    frmDespachoFacturaListaTransportes.fnCambioFila()

        ''    If mdlPublicVars.superSearchFilasGrid > 0 Then

        ''        Dim valor As Boolean = superSearchConfirmado

        ''        ''If valor = False Then
        ''        Dim idsalid As Integer = CInt(superSearchId)

        ''        frmDevolucionTransporte.Text = "Devolucion Envio"
        ''        ''frmDevolucionTransporte.MdiParent = frmMenuPrincipal
        ''        frmDevolucionTransporte.idenvio = CInt(mdlPublicVars.superSearchId)
        ''        frmDevolucionTransporte.DevListado = False
        ''        frmDevolucionTransporte.WindowState = FormWindowState.Normal
        ''        frmDevolucionTransporte.StartPosition = FormStartPosition.CenterScreen
        ''        frmDevolucionTransporte.ShowDialog()
        ''        frmDevolucionTransporte.Dispose()


        ''        ''Solo entrar si se realizo alguna devolucion
        ''        If creadevolucion = True Then
        ''            Dim conexion As dsi_pos_demoEntities
        ''            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
        ''                conn.Open()
        ''                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

        ''                Dim salida As tblSalidasTransportesMedio = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = idsalid Select x).FirstOrDefault

        ''                salida.Entrada = True
        ''                salida.ConceptoEntrada = 6

        ''                conexion.SaveChanges()

        ''                Dim saldet As tblSalidasTransportesMediosDetalle = (From x In conexion.tblSalidasTransportesMediosDetalles Where x.idSalidaTransporteMedio = idsalid Select x).Take(1).FirstOrDefault

        ''                Dim saldetventa As tblSalidaDetalle = (From x In conexion.tblSalidaDetalles Where x.idSalidaDetalle = saldet.idSalidaDetalle Select x).Take(1).FirstOrDefault

        ''                Dim salventa As tblSalida = (From x In conexion.tblSalidas Where x.idSalida = saldetventa.idSalida Select x).FirstOrDefault

        ''                ''fnEnviarDevolucionCorreo(salventa.idCliente, salventa.idSalida)

        ''                conn.Close()
        ''            End Using
        ''        End If
        ''    End If
        ''Catch
        ''End Try
    End Sub

    Private Sub fnPanel2() Handles Me.panel2

        ''frmDespachoFacturaListaTransportes.fnCambioFilaTransporte()

        ''If mdlPublicVars.superSearchFilasGrid > 0 Then

        ''    Dim idsalida As Integer = CInt(mdlPublicVars.superSearchId)
        ''    Dim totalkms As Decimal = CDec(mdlPublicVars.superSearchTotalKms)
        ''    Dim costocombustible As Decimal = CDec(mdlPublicVars.superSearchCostoCombustible)
        ''    Dim totalcombustible As Decimal = CDec(mdlPublicVars.superSearchTotalCombustible)
        ''    Dim totalplanilla As Decimal = CDec(mdlPublicVars.superSearchTotalPlanilla)
        ''    Dim costo As Decimal = CDec(mdlPublicVars.superSearchCosto)
        ''    Dim totalcobro As Decimal = CDec(mdlPublicVars.superSearchTotalCobro)
        ''    Dim GastosEnvio As Boolean = CBool(mdlPublicVars.superSearchGastosConfirmado)

        ''    If GastosEnvio = True Then
        ''        RadMessageBox.Show("Los Gastos de Envio ya Fueron Ingresados", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        ''    Else

        ''        Dim conexion As dsi_pos_demoEntities
        ''        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
        ''            conn.Open()
        ''            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

        ''            Dim salida As tblSalidasTransportesMedio = (From x In conexion.tblSalidasTransportesMedios Where x.idSalidaTransporteMedio = idsalida Select x).FirstOrDefault

        ''            salida.TotalKms = totalkms
        ''            salida.CostoCombustible = costocombustible
        ''            salida.TotalCombustible = totalcombustible
        ''            salida.TotalPlanilla = totalplanilla
        ''            salida.Costo = costo
        ''            salida.TotalCobro = totalcobro
        ''            salida.GastosEnvio = True

        ''            conexion.SaveChanges()

        ''            RadMessageBox.Show("Los Gastos de Envio se Guardaron Correctamente", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

        ''            conn.Close()
        ''        End Using
        ''    End If
        ''End If

    End Sub
#End Region

#Region "Funciones"

#End Region

    Private Function frmDespachoFacturaListaTransportes() As Object
        Throw New NotImplementedException
    End Function

End Class