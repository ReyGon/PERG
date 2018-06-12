
Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Transactions
Imports System.Linq

Public Class frmCargaSelectivaImportacion

    Private _Id As Integer

    Public Property Id As Integer
        Get
            Id = _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property


    Private Sub frmCargaSelectivaImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
            mdlPublicVars.fnGrid_iconos(Me.grdProductos)

            fnCargarNacionalizacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnCargarNacionalizacion()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                ''Dim n As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = Id Select x).FirstOrDefault
                Dim nac As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.idEntrada = Id Order By x.nocaja Select x).ToList

                For Each n As tblEntradasDetalle In nac

                    Me.grdProductos.Rows.Add(CBool(False), n.idArticulo, n.nocaja, n.tblArticulo.codigo1, n.tblArticulo.nombre1, n.cantidad)

                Next

                Me.lblContadorProductos.Text = CStr(Me.grdProductos.Rows.Count)

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_CellClick(sender As Object, e As GridViewCellEventArgs) Handles grdProductos.CellClick

    End Sub
End Class
