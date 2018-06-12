Option Strict On

Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
''Imports System.Data.SqlClient
Imports System.Linq
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class frmDescuentos

    Public _bitVentaContado As Boolean = False
    Public _bitVentaCredito As Boolean = False

    Public Property bitVentaContado As Boolean
        Get
            bitVentaContado = _bitVentaContado
        End Get
        Set(value As Boolean)
            _bitVentaContado = value
        End Set
    End Property

    Public Property bitVentaCredito As Boolean
        Get
            bitVentaCredito = _bitVentaCredito
        End Get
        Set(value As Boolean)
            _bitVentaCredito = value
        End Set
    End Property

    Private Sub frmDescuentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''If superSearchIdDescuento > 0 Then
        ''    If supersearchDescuentoPorcentaje Then
        ''        rbtPorcentaje.Checked = True
        ''        rbtValor.Checked = False
        ''        fnRadioButtons()
        ''    Else
        ''        rbtValor.Checked = True
        ''        rbtPorcentaje.Checked = False
        ''        fnRadioButtons()
        ''    End If
        ''Else
        rbtValor.Checked = True
        fnRadioButtons()
        ''fnLlenarCombo()
        ''End If

    End Sub

    Private Sub fnRadioButtons()
        If rbtValor.Checked = True Then
            rbtPorcentaje.Checked = False
        ElseIf rbtPorcentaje.Checked = True Then

        End If
    End Sub



    Private Sub fnLlenarCombo()

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim biValor As Boolean
            Dim biPorcentaje As Boolean

            If rbtPorcentaje.Checked = True Then
                biPorcentaje = True
                biValor = False
            ElseIf rbtValor.Checked = True Then
                biValor = True
                biPorcentaje = False
            End If

            Dim descuento As Object = (From x In conexion.tblDescuentos Where x.bitValor = biValor And x.bitPorcentaje = biPorcentaje And x.bitContado = bitVentaContado And x.bitCredito = bitVentaCredito Select Id = x.idDescuento, Nombre = x.nombre)


            With cmbDescuento
                .DataSource = Nothing
                .ValueMember = "Id"
                .DisplayMember = "Nombre"
                .DataSource = descuento
            End With

            ''If superSearchIdDescuento > 0 Then
            ''    cmbDescuento.SelectedValue = superSearchIdDescuento
            ''End If

            conn.Close()
        End Using

    End Sub

    Private Sub rbtValor_CheckedChanged(sender As Object, e As EventArgs) Handles rbtValor.CheckedChanged
        fnRadioButtons()
        fnLlenarCombo()
    End Sub

    Private Sub fnSalir_Click() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub cmbDescuento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDescuento.SelectedValueChanged

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim codigo As Integer = CInt(cmbDescuento.SelectedValue)

            Dim descuen As Object = (From x In conexion.tblDescuentos Where x.idDescuento = codigo Select x.descuento).FirstOrDefault

            Me.txtValor.Text = CStr(descuen)

            conn.Close()
        End Using
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnAgregarDescuento.Click

        Dim bitvalor As Boolean = rbtValor.Checked
        Dim bitporcentaje As Boolean = rbtPorcentaje.Checked

        Dim valor As Decimal = CDec(Me.txtValor.Text)

        If valor > 0 Then

            If bitporcentaje Then
                supersearchDescuentoPorcentaje = True
            Else
                supersearchDescuentoPorcentaje = False
            End If

            superSearchValorDescuento = valor
            superSearchIdDescuento = CInt(cmbDescuento.SelectedValue)
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnQuitarDescuento.Click
        superSearchIdDescuento = 0
        supersearchDescuentoPorcentaje = False
        superSearchValorDescuento = 0
        Me.Close()
    End Sub
End Class
