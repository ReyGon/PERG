Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmBancoReporteCheques

    Private Sub frmBancoReporteCheques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltroLista(cmbBanco)
        mdlPublicVars.comboActivarFiltroLista(cmbCuenta)
        mdlPublicVars.comboActivarFiltroLista(cmbChequera)
        mdlPublicVars.comboActivarFiltro(cmbBeneficiario)
        mdlPublicVars.comboActivarFiltro(cmbConcepto)

        mdlPublicVars.fnFormatoGridEspeciales(grdDatos)

        fnSumarios()
        fnLlenaCombo()
    End Sub

    'FILAS SUMMARY's
    Private Sub fnSumarios()
        Try
            'Agregamos antes las filas de sumas
            Dim summaryId As New GridViewSummaryItem("Descripcion", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
            Dim summaryMonto As New GridViewSummaryItem("Monto", mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
            'agregar la fila de operaciones aritmeticas
            Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryMonto})

            grdDatos.SummaryRowsTop.Add(summaryRowItem)
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub


    'LLENAR COMBOS
    Private Sub fnLlenaCombo()
        'BANCOS
        Dim banco = (From x In ctx.tblBancoes Take 1 Select New With {.codigo = 0, .nombre = "Todos"}).Union(
                     From x In ctx.tblBancoes Select New With {.codigo = x.idbanco, .nombre = x.nombre})

        With cmbBanco
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = banco
        End With

        'BENEFICIARIO
        Dim beneficiario = (From x In ctx.tblBanco_Beneficiario Where x.bitDebitoCheque Take 1 Select New With {.codigo = 0, .nombre = "Todos"}).Union(
                            From x In ctx.tblBanco_Beneficiario Select New With {.codigo = x.codigo, .nombre = x.nombre})


        With cmbBeneficiario
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = beneficiario
        End With

        'CONCEPTO
        Dim concepto = (From x In ctx.tblBanco_MovimientoConcepto Take 1 Select New With {.codigo = 0, .nombre = "Todos"}).Union(
                        From x In ctx.tblBanco_MovimientoConcepto Select New With {.codigo = x.codigo, .nombre = x.nombre})

        With cmbConcepto
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = concepto
        End With
    End Sub


    Private Sub cmbBanco_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBanco.SelectedValueChanged
        Dim idBanco As Integer = CInt(cmbBanco.SelectedValue)

        Try
            If idBanco >= 0 Then
                Dim cuentas = (From x In ctx.tblBanco_Cuenta Take 1 Select New With {.codigo = 0, .nombre = "Todos"}).Union(
                               From x In ctx.tblBanco_Cuenta Where (idBanco = 0 Or (idBanco > 0 And x.banco = idBanco))
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

    Private Sub cmbCuenta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuenta.SelectedValueChanged
        Dim idBanco As Integer = CInt(cmbBanco.SelectedValue)
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)

        Try
            If idCuenta >= 0 Then
                Dim chequeras = (From x In ctx.tblBanco_Chequera Take 1 Select New With {.codigo = 0, .nombre = "Todos"}).Union(
                                 From x In ctx.tblBanco_Chequera
                                 Where (idCuenta = 0 And x.tblBanco_Cuenta.banco = idBanco Or (idCuenta > 0 And x.cuenta = idCuenta))
                                 Select New With {x.codigo, .nombre = x.descripcion})

                With cmbChequera
                    .DataSource = Nothing
                    .ValueMember = "codigo"
                    .DisplayMember = "nombre"
                    .DataSource = chequeras
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
        Dim idBeneficiario As Integer = CInt(cmbBeneficiario.SelectedValue)
        Dim idConcepto As Integer = CInt(cmbConcepto.SelectedValue)
        Dim idBanco As Integer = CInt(cmbBanco.SelectedValue)
        Dim idCuenta As Integer = CInt(cmbCuenta.SelectedValue)
        Dim idChequera As Integer = CInt(cmbChequera.SelectedValue)
        Dim bitTodos As Integer = chlbEstados.GetItemCheckState(0)
        Dim bitConfirmados As Integer = chlbEstados.GetItemCheckState(1)
        Dim bitTransito As Integer = chlbEstados.GetItemCheckState(2)
        Dim bitAnulado As Integer = chlbEstados.GetItemCheckState(3)

        Dim datos As DataTable = EntitiToDataTable(ctx.sp_reporteCheques("", desde, hasta, idBeneficiario, idConcepto, idBanco, idCuenta, idChequera,
                                                                         bitAnulado, bitTransito, bitConfirmados, bitTodos, mdlPublicVars.idEmpresa))

        Me.grdDatos.DataSource = datos
        fnConfiguracion()
    End Sub

    'CONFIGURAR EL GRID
    Private Sub fnConfiguracion()
        If Me.grdDatos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdDatos.Columns("Empresa").IsVisible = False
            Me.grdDatos.Columns("DireccionEmpresa").IsVisible = False
            Me.grdDatos.Columns("CorreoEmpresa").IsVisible = False
            Me.grdDatos.Columns("TelefonoEmpresa").IsVisible = False
            Me.grdDatos.Columns("desde").IsVisible = False
            Me.grdDatos.Columns("hasta").IsVisible = False

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "fechaRegistro")
            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatos, "fechaConfirmado")
            mdlPublicVars.fnGridTelerik_formatoMoneda(grdDatos, "Monto")

            Me.grdDatos.Columns("fechaRegistro").HeaderText = "Fecha de Reg."
            Me.grdDatos.Columns("fechaConfirmado").HeaderText = "Fecha de Conf."
            Me.grdDatos.Columns("Documento").HeaderText = "Doc."
            Me.grdDatos.Columns("Correlativo").HeaderText = "Corr."

            Me.grdDatos.Columns("fechaRegistro").Width = 70
            Me.grdDatos.Columns("fechaConfirmado").Width = 70
            Me.grdDatos.Columns("Banco").Width = 100
            Me.grdDatos.Columns("Cuenta").Width = 140
            Me.grdDatos.Columns("Chequera").Width = 115
            Me.grdDatos.Columns("Documento").Width = 60
            Me.grdDatos.Columns("Correlativo").Width = 60
            Me.grdDatos.Columns("Beneficiario").Width = 125
            Me.grdDatos.Columns("Concepto").Width = 110
            Me.grdDatos.Columns("Estado").Width = 75
            Me.grdDatos.Columns("Monto").Width = 80
        End If
    End Sub

    'BUSCAR
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnLlenarGrid()
    End Sub

    'REPORTE
    Public Sub fnReporte() Handles Me.panel0
        Dim r As New clsReporte
        Dim permiso As New clsPermisoUsuario
        Try
            r.reporte = "rptCheques.rpt"
            r.tabla = grdDatos.DataSource
            r.nombreParametro = "filtro"
            r.parametro = "Filtro del reporte:  "

            frmDocumentosSalida.txtTitulo.Text = "Listado de Conceptos de Cheques, Desde " & dtpFechaInicio.Text & " Hasta " & dtpFechaFin.Text
            frmDocumentosSalida.Text = "Docs. de Salida"
            frmDocumentosSalida.bitCliente = False
            frmDocumentosSalida.reporteBase = r.DocumentoReporte()

            permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub
End Class