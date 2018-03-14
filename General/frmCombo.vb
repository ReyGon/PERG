Public Class frmCombo

    Private _RetonoGrid As Boolean

    Public Property RetornoGrid() As Boolean
        Get
            RetornoGrid = _RetonoGrid
        End Get
        Set(ByVal value As Boolean)
            _RetonoGrid = value
        End Set
    End Property


    Private _grd As Telerik.WinControls.UI.RadGridView
    Public Property grd() As Telerik.WinControls.UI.RadGridView
        Get
            grd = _grd
        End Get
        Set(ByVal value As Telerik.WinControls.UI.RadGridView)
            _grd = value
        End Set
    End Property


    Private _colRetorno As Integer
    Public Property colRetorno() As Integer
        Get
            colRetorno = _colRetorno
        End Get
        Set(ByVal value As Integer)
            _colRetorno = value
        End Set
    End Property

    Dim b As New clsBase

    Private Sub frmCombo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.superSearchId = 0
        mdlPublicVars.superSearchNombre = ""
        mdlPublicVars.comboActivarFiltro(combo)
    End Sub

 

    Private Sub fnAgregar()
        Try
            mdlPublicVars.superSearchId = Me.combo.SelectedValue
            mdlPublicVars.superSearchNombre = Me.combo.Text
            Me.Close()
        Catch ex As Exception
            mdlPublicVars.superSearchId = 0
            mdlPublicVars.superSearchNombre = ""
        End Try

        Me.Close()
    End Sub

    Private Sub combo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles combo.KeyDown
        If e.KeyValue = Keys.Enter Then
            fnAgregar()
        End If
    End Sub

    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
        fnAgregar()
    End Sub
End Class
