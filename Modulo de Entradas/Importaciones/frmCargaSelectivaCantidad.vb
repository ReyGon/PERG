Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Windows
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmCargaSelectivaCantidad

    Dim _cantidad As Integer = 0
    Dim carga As Integer = 0

    Public Property cantidad As Integer
        Get
            cantidad = _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Private Sub frmCargaSelectivaCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtCantidad.Text = cantidad
        Me.txtCantidad.Select()
        Me.txtCantidad.Focus()
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtCantidad.Text <> "" Then
                    carga = Me.txtCantidad.Text
                ElseIf Me.txtCantidad.Text > 0 Then
                    carga = Me.txtCantidad.Text
                Else
                    carga = 0
                End If

                If carga > cantidad Then
                    frmNotificacion.lblNotificacion.Text = "¡La cantidad tabulada supera la cantidad de la Invoice!"
                    frmNotificacion.Show()
                    Me.txtCantidad.Select()
                    Me.txtCantidad.Focus()
                    Exit Sub
                End If

                frmCargaSelectivaImportacion.cantidadCarga = carga
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
