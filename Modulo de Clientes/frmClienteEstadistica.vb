Option Strict On

Imports System.Linq
Imports Telerik.WinControls
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports Telerik.Charting
Imports System.Data.Objects
Imports System.Management
Imports System.Data.Common
Imports System.Data.EntityClient

Public Class frmClienteEstadistica

#Region "Variables"
    Dim _idCliente As Integer   'Recibe como parametro el id del cliente
    Dim _frecuenciaCompra As Decimal
    Dim _ventaAcumulada As Decimal
    Dim _ventapromedio As Decimal

    Public Property idCliente As Integer
        Get
            idCliente = _idCliente
        End Get
        Set(value As Integer)
            _idCliente = value
        End Set
    End Property

    Public Property frecuenciacompra As Decimal
        Get
            frecuenciacompra = _frecuenciaCompra
        End Get
        Set(value As Decimal)
            _frecuenciaCompra = value
        End Set
    End Property

    Public Property ventaAcumulada As Decimal
        Get
            ventaAcumulada = _ventaAcumulada
        End Get
        Set(value As Decimal)
            _ventaAcumulada = value
        End Set
    End Property

    Public Property ventapromedio As Decimal
        Get
            ventapromedio = _ventapromedio
        End Get
        Set(value As Decimal)
            _ventapromedio = value
        End Set
    End Property

#End Region

#Region "Eventos"
    'Carga del formulario
    Private Sub frmClienteEstadistica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Configuramos los grid y el combo de busqueda
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoRepuesto)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdTipoVehiculo)

        mdlPublicVars.comboActivarFiltro(cmbCliente)

        'Llenar el combo de clientes
        fnLlenarCombo()
        gaugeVenta.NeedleType = NeedleType.Advance

    End Sub

    'Click sobre el boton buscar
    Private Sub btnInfoCliente_Click(sender As Object, e As EventArgs) Handles btnInfoCliente.Click
        ' Obtenemos el id
        Dim idClienteCombo As Integer = CInt(cmbCliente.SelectedValue)
        If idClienteCombo > 0 Then
            fnLlenarEstadistica(idClienteCombo)
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
#End Region

#Region "Funciones"
    'Llenar el combo de clientes
    Private Sub fnLlenarCombo()
        Dim consulta As IQueryable = (From x In ctx.tblClientes Select codigo = 0, nombre = "Eliga un cliente").Union(From x In ctx.tblClientes
                               Order By x.Negocio
                              Select codigo = x.idCliente, nombre = x.Negocio)
        With Me.cmbCliente
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = consulta
        End With

        If idCliente > 0 Then
            cmbCliente.SelectedValue = idCliente
            fnLlenarEstadistica(idCliente)
        End If
    End Sub

    'Llenar las estadisticas
    Private Sub fnLlenarEstadistica(codigo As Integer)
        Dim conexion As New dsi_pos_demoEntities
        
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                ' INFORMACION DE CLIENTE
                Dim cliente As tblCliente = (From x In conexion.tblClientes.AsEnumerable Where x.idCliente = codigo Select x).FirstOrDefault

                ' GRIDS
                Dim tiposrepuestos As DataTable = mdlPublicVars.EntitiToDataTable((From x In conexion.sp_ClienteTiposRepuestos(codigo, mdlPublicVars.idEmpresa) Select x))
                Dim tiposvehiculos As DataTable = mdlPublicVars.EntitiToDataTable((From x In conexion.sp_ClienteTiposVehiculos(codigo, mdlPublicVars.idEmpresa) Select x))

                Me.grdTipoRepuesto.DataSource = tiposrepuestos
                Me.grdTipoVehiculo.DataSource = tiposvehiculos

                fnGridTelerik_formatoPorcentaje(grdTipoRepuesto, "Porcentaje")
                fnGridTelerik_formatoPorcentaje(grdTipoVehiculo, "Porcentaje")

                ' INDICADORES
                Dim indicadores As sp_ClienteIndicadorVenta_Result = (From x In conexion.sp_ClienteIndicadorVenta(12, codigo, mdlPublicVars.idEmpresa) Select x).FirstOrDefault

                If indicadores IsNot Nothing Then
                    lblCompraAcumulada.Text = Format(ventaAcumulada, CStr(mdlPublicVars.formatoMoneda))
                    lblFrecuenciaCompra.Text = CStr(frecuenciacompra)
                    lblUltimaCompra.Text = Format(cliente.FechaUltimaCompra, CStr(mdlPublicVars.formatoFecha))
                    lblClave.Text = cliente.clave.ToString
                    Try
                        gaugeVenta.Value = ventaAcumulada / 1000
                    Catch ex As Exception
                        gaugeVenta.Value = 0
                    End Try
                    ''If indicadores.IndicadorVenta > 200 Then
                    ''    gaugeVenta.Value = 100
                    ''Else
                    ''    gaugeVenta.Value = CInt(indicadores.IndicadorVenta / 2)
                    ''End If

                    rcGrafica.ChartTitle.TextBlock.Text = "Ventas por Mes vs Promedio(Q. " & ventapromedio.ToString & ")"
                End If

                ' GRAFICA
                ' Configuramos el dataset
                Dim grafica As List(Of sp_GraficaVentas_Result) = (From x In conexion.sp_GraficaVentas(3, codigo, mdlPublicVars.idEmpresa)).ToList
                rcGrafica.Series.Clear()
                Dim cs As New ChartSeries()
                Dim cs1 As New ChartSeries()
                For Each resultado As sp_GraficaVentas_Result In grafica
                    Dim ventaMes As New ChartSeriesItem(CDbl(resultado.TotalVenta), "Q. " & Decimal.Round(CDec(resultado.TotalVenta), 2).ToString() & resultado.Mes)
                    ''Dim ventaMes As New ChartSeriesItem(CDbl(resultado.TotalVenta), "Q. " & Decimal.Round(CDec(resultado.TotalVenta), 2).ToString() & resultado.TotalVenta)
                    ventaMes.Label.TextBlock.Text = (Format((resultado.TotalVenta / 1000), formatoNumero) & vbLf & resultado.Mes).ToString
                    cs.Items.Add(ventaMes)
                    cs1.Items.Add(New ChartSeriesItem(CDbl(ventapromedio)))
                Next
                cs.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.White
                ''cs.Appearance.TextAppearance.TextProperties.Font.Bold = True
                cs.Appearance.LabelAppearance.RotationAngle = -20
                cs.Type = ChartSeriesType.Line
                cs.Name = "Ventas por Mes"
                cs1.Appearance.TextAppearance.Visible = False
                cs1.Type = ChartSeriesType.Line
                cs1.Name = "Venta Promedio"
                rcGrafica.Series.Add(cs)
                rcGrafica.Series.Add(cs1)
                rcGrafica.Update()
                rcGrafica.UpdateGraphics()
            Catch ex As Exception
                RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
            conn.Close()
        End Using

    End Sub
#End Region


End Class