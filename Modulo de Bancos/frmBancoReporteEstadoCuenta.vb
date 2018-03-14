Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient

Public Class frmBancoReporteEstadoCuenta

    Private Sub frmBancoEstadoCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)
        mdlPublicVars.comboActivarFiltroLista(cmbBanco)
        mdlPublicVars.comboActivarFiltroLista(cmbCuenta)
        fnSumarios()
        fnLlenaCombo()
    End Sub

    'FILAS SUMMARY's
    Private Sub fnSumarios()
        Try
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Fecha", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryDebito As New GridViewSummaryItem("Debito", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            Dim summaryCredito As New GridViewSummaryItem("Credito", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryDebito, summaryCredito})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    'LLENAR COMBOS
    Private Sub fnLlenaCombo()
        'BANCOS
        Dim banco = From x In ctx.tblBancoes Select New With {.codigo = x.idbanco, .nombre = x.nombre}

        With cmbBanco
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = banco
        End With
    End Sub

    'CAMBIO DE BANCO
    Private Sub cmbBanco_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedValueChanged
        Dim idBanco As Integer = CInt(cmbBanco.SelectedValue)

        Try
            If idBanco >= 0 Then
                Dim cuentas = (From x In ctx.tblBanco_Cuenta Where x.banco = idBanco
                               Select New With {x.codigo, .nombre = x.numeroCuenta + " , " + x.descripcion})

                With cmbCuenta
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = cuentas
                End With
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'LLENAR GRID
    Private Sub fnLlenarGrid()
        Dim desde As DateTime = dtpFechaInicio.Text
        Dim hasta As DateTime = dtpFechaFin.Text + " 23:59:59"
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)

        ''Dim datos As DataTable = EntitiToDataTable(From z In ctx.sp_reporteEstadoCuentaBancaria("", idCuenta, desde, hasta, mdlPublicVars.idEmpresa) Select z)

        ''Me.grdDatos.DataSource = datos
        fnConfiguracion()
    End Sub

    'CONFIGURAR EL GRID
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(i).IsVisible = False
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Debito")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Credito")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Saldo")

            Me.grdDatos.Columns("Fecha").IsVisible = True
            Me.grdDatos.Columns("Tipo").IsVisible = True
            Me.grdDatos.Columns("Concepto").IsVisible = True
            Me.grdDatos.Columns("Beneficiario").IsVisible = True
            Me.grdDatos.Columns("Documento").IsVisible = True
            Me.grdDatos.Columns("Debito").IsVisible = True
            Me.grdDatos.Columns("Credito").IsVisible = True
            Me.grdDatos.Columns("Saldo").IsVisible = True

            Me.grdDatos.Columns("Fecha").Width = 50
            Me.grdDatos.Columns("Tipo").Width = 50
            Me.grdDatos.Columns("Concepto").Width = 110
            Me.grdDatos.Columns("Beneficiario").Width = 120
            Me.grdDatos.Columns("Documento").Width = 60
            Me.grdDatos.Columns("Debito").Width = 65
            Me.grdDatos.Columns("Credito").Width = 65
            Me.grdDatos.Columns("Saldo").Width = 65

            Me.grdDatos.Columns.Move(Me.grdDatos.Columns("Concepto").Index, Me.grdDatos.Columns("Documento").Index)
            Me.grdDatos.Columns.Move(Me.grdDatos.Columns("Beneficiario").Index, Me.grdDatos.Columns("Documento").Index)
        End If
    End Sub

    'BUSCAR
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnLlenarGrid()
    End Sub

    'REPORTE
    Public Sub fnReporte() Handles Me.panel0
        If CInt(cmbCuenta.SelectedValue) > 0 Then
            Dim r As New clsReporte
            Dim permiso As New clsPermisoUsuario
            Try
                r.reporte = "rptEstadoCuentaBancaria.rpt"
                r.tabla = grdDatos.DataSource
                r.nombreParametro = "filtro"
                r.parametro = "Filtro del reporte:  "

                frmDocumentosSalida.txtTitulo.Text = "Estado Cuenta Bancaria, Desde " & dtpFechaInicio.Text & " Hasta " & dtpFechaFin.Text
                frmDocumentosSalida.Text = "Docs. de Salida"
                frmDocumentosSalida.bitCliente = False
                frmDocumentosSalida.reporteBase = r.DocumentoReporte()

                permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub
End Class