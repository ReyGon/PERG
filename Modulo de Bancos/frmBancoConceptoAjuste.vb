Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmBancoConceptoAjuste
    'Cargar la barra izquierda de opciones del banco
    Private Sub frmBancoConceptoAjuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim iz As New frmBancoBarraIzquierda
            iz.frmAnterior = Me
            frmBancoBarraIzquierda = iz
            ActivarBarraLateral = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_siceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub llenagrid()
        Try
            'Consultamos todos los registros de la tabla 
       
            'Lenamos el grid de los datos con la consulta
           
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_LlenarGrid() Handles Me.llenarLista
        llenagrid()
    End Sub

End Class

