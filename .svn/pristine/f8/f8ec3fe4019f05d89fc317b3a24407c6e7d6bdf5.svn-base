Imports Telerik.Charting
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class frmReporteVentasGrafica


    Private _grdBase As Telerik.WinControls.UI.RadGridView

    Public Property grdBase() As Telerik.WinControls.UI.RadGridView
        Get
            grdBase = _grdBase
        End Get
        Set(ByVal value As Telerik.WinControls.UI.RadGridView)
            _grdBase = value
        End Set
    End Property

    Private _datos As DataTable

    Public Property datos() As DataTable
        Get
            datos = _datos
        End Get
        Set(ByVal value As DataTable)
            _datos = value
        End Set
    End Property

#Region "LOAD"
    Private Sub frmReporteVentasGrafica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rchGrafica.ChartTitle.TextBlock.Text = "Mi grafico"
        rbnAnho.Checked = True
        fnGraficar()
    End Sub

#End Region

#Region "Eventos"
    
#End Region

#Region "Funciones"


    'Funcion utilizada para obtener las columnas agrupadas
    Public Function fnCrearTabla() As DataTable
        
        Dim tColumnas As New DataTable

        Dim dt As New DataTable
        dt = datos

        Try
            '-----------AGREGAR DIMENSION DE TIEMPO.
            If rbnAnho.Checked = True Then
                tColumnas.Columns.Add("Anho")
            End If

            If rbnPorMes.Checked = True Then
                tColumnas.Columns.Add("Mes")
            End If

            If rbnPorDia.Checked = True Then
                tColumnas.Columns.Add("Dia")
            End If


            'AGREGAR DIMENSIONES DE GRUPO.

            For Each grupo As GroupDescriptor In Me.grdBase.MasterTemplate.GroupDescriptors
                tColumnas.Columns.Add(grupo.GroupNames(0).PropertyName)
            Next

            'AGREGAR DIMENSIONES DE VALORES.
            tColumnas.Columns.Add("Precio")
            tColumnas.Columns.Add("Costo")
            tColumnas.Columns.Add("Utilidad")


            Dim index = 0
            Dim col = 0
            Dim arr As New ArrayList
            Dim Encontrada As Boolean = False
            Dim nombre As String = ""

            For col = 0 To grdBase.Columns.Count - 1 'tabla que contiene la tabla general.
                Encontrada = False

                For index = 0 To tColumnas.Columns.Count - 1 'tabla que contiene la informacion.

                    nombre = grdBase.Columns(col).Name.ToString

                    If tColumnas.Columns(index).columnname.ToString = grdBase.Columns(col).Name.ToString Then
                        Encontrada = True
                    End If
                Next

                If Encontrada = True Then
                    'no eliminar
                Else
                    'eliminar
                    If dt.Columns(nombre) IsNot Nothing Then
                        dt.Columns.Remove(dt.Columns(nombre))
                        col = col - 1
                        If col = -1 Then
                            Exit For
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
        End Try
        

   

        Return dt
    End Function


    'Funcion utilizada para graficar
    Private Sub fnGraficar() Handles Me.panel0

        'configuracion.
        rchGrafica.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = 320
        rchGrafica.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.BlueViolet
        rchGrafica.PlotArea.Appearance.Dimensions.Margins.Bottom = Telerik.Charting.Styles.Unit.Percentage(25)
        rchGrafica.PlotArea.Appearance.Dimensions.Margins.Left = Telerik.Charting.Styles.Unit.Percentage(20)


        'limpiar las series.
        'rchGrafica.Series.Clear()

        Dim seriex As New ChartSeries()
        seriex.Type = ChartSeriesType.Bar
        seriex.Name = "Region 1 - Costo"

        'agregar los items.
        seriex.AddItem(15, "2012")
        seriex.AddItem(45, "2013")


        rchGrafica.AddChartSeries(seriex)

        Dim seriex2 As New ChartSeries()
        seriex2.Type = ChartSeriesType.Bar
        seriex2.Name = "Region 2 - Precio"

        'agregar los items.
        seriex2.AddItem(18, "Region 2, Costo")
        seriex2.AddItem(40, "Region 2, Utilidad")
        seriex2.AddItem(30, "Region 2, Precio")

        rchGrafica.AddChartSeries(seriex2)


    End Sub

#End Region

    
End Class
