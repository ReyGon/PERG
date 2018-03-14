
Public Class frmCrystalViewver
    Private _parametroReporte As String = ""
    Private _parametroReporteNombre As String = ""
    Private _reporte As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Public Property parametroReporte() As String
        Get
            parametroReporte = _parametroReporte
        End Get
        Set(ByVal value As String)
            _parametroReporte = value
        End Set
    End Property

    Public Property parametroReporteNombre() As String
        Get
            parametroReporteNombre = _parametroReporteNombre
        End Get
        Set(ByVal value As String)
            _parametroReporteNombre = value
        End Set
    End Property

    Public Property reporte() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Get
            reporte = _reporte
        End Get
        Set(ByVal value As CrystalDecisions.CrystalReports.Engine.ReportDocument)
            _reporte = value
        End Set
    End Property


    Private Sub frmCrystalViewver_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        crView.Dispose()
    End Sub


    Private Sub frmCrystalViewver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FieldCollection = New CrystalDecisions.Shared.ParameterFields


        Dim NewField As New CrystalDecisions.Shared.ParameterField
        Dim NewParam As New CrystalDecisions.Shared.ParameterDiscreteValue
        If Me.parametroReporteNombre <> "" Then
            NewParam.IsRange = True
            NewField.Name = Me.parametroReporteNombre
            NewParam.Value = Me.parametroReporte
            NewField.HasCurrentValue = True
            NewField.CurrentValues.Add(NewParam)
            FieldCollection.Add(NewField)

            Me.crView.ParameterFieldInfo = FieldCollection
        End If


        Me.crView.ReportSource = reporte
        'Me.crView.RefreshReport()
    End Sub
End Class