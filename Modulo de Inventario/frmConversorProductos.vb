Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows
Imports System.Linq

Public Class frmConversorProductos

    Dim permiso As New clsPermisoUsuario

#Region "Eventos"

    Private Sub frmConversorProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)
        mdlPublicVars.fnGrid_iconos(Me.grdProductos)

        fnNuevaFila()
        fnConfiguracion()
    End Sub

    Private Sub grdProductos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If Me.grdProductos.RowCount > 0 Then

            If e.KeyCode = Keys.F2 Then

                Dim c As Integer = Me.grdProductos.CurrentColumn.Index
                Dim f As Integer = 0

                Try
                    f = Me.grdProductos.CurrentRow.Index
                Catch ex As Exception
                    f = -1
                End Try

                If Me.grdProductos.Columns("txbArticulo").IsCurrent Then
                    If Me.grdProductos.CurrentRow.Index >= 0 Then
                        If Me.grdProductos.Rows(f).Cells(c).Value Is Nothing Then
                            mdlPublicVars.superSearchNombre = ""
                        Else
                            mdlPublicVars.superSearchNombre = LTrim(RTrim(CStr(Me.grdProductos.Rows(f).Cells(c).Value)))
                        End If
                        frmBuscarArticuloVentaPequenia.bitConversion = True
                        frmBuscarArticuloVentaPequenia.codClie = mdlPublicVars.idCliente
                        frmBuscarArticuloVentaPequenia.codVendedor = mdlPublicVars.idVendedor
                        frmBuscarArticuloVentaPequenia.StartPosition = FormStartPosition.CenterScreen
                        frmBuscarArticuloVentaPequenia.OpcionRetorno = "Salidas"
                        frmBuscarArticuloVentaPequenia.Text = "Buscar Articulos"
                        frmBuscarArticuloVentaPequenia.bitCliente = False
                        frmBuscarArticuloVentaPequenia.bitProveedor = False
                        frmBuscarArticuloVentaPequenia.bitMovimientoInventario = False
                        frmBuscarArticuloVentaPequenia.grdIngresados = grdProductos
                        frmBuscarArticuloVentaPequenia.ventaPequenia = 1
                        ''mdlPublicVars.SiempreEncima(Me.Handle.ToInt32)

                        permiso.PermisoDialogEspeciales(frmBuscarArticuloVentaPequenia)
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "Funciones"

    Public Sub fnNuevaFila()
        fnEliminaVacias()
        Me.grdProductos.Rows.AddNew()
        ''If superSearchValorDescuento > 0 Then
        ''    fnAgregarDescuento(superSearchValorDescuento)
        ''End If
    End Sub

    'ELIMINA FILAS VACIAS
    Private Sub fnEliminaVacias()
        Try
            'Recorremos el grid

            Dim nombre As String = ""
            For i As Integer = 0 To Me.grdProductos.Rows.Count - 1
                'Obtenemo el valor del nombre
                nombre = CStr(Me.grdProductos.Rows(i).Cells("txbArticulo").Value)

                If IsNothing(nombre) Then
                    Me.grdProductos.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Public Sub fnAgregar_Articulos()
        'agregar productos a grid.
        Dim filas() As Object

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim articulo As tblArticulo = (From x In conexion.tblArticuloes.AsEnumerable Where x.idArticulo = mdlPublicVars.superSearchId Select x).FirstOrDefault

            'id, codigo,nombre,precio,cantidad
            filas = {mdlPublicVars.superSearchId.ToString, mdlPublicVars.superSearchCodigo, mdlPublicVars.superSearchNombre}
            conn.Close()
        End Using

        grdProductos.Rows.Add(filas)
    End Sub

    Private Sub fnConfiguracion()
        ''Tamanios
        Me.grdProductos.Columns(0).Width = 50
        Me.grdProductos.Columns(1).Width = 60
        Me.grdProductos.Columns(2).Width = 150
        Me.grdProductos.Columns(3).Width = 100

        ''Visibles
        Me.grdProductos.Columns(0).IsVisible = False

        ''Editables
        Me.grdProductos.Columns(1).ReadOnly = False
    End Sub

    'REMOVER LA FILA ACTUAL DEL GRID DE PRODUCTOS
    Public Sub fnRemoverFila()
        Dim filaActual As Integer = CType(Me.grdProductos.CurrentRow.Index, Integer)

        If filaActual >= 0 Then
            Dim index As Integer = 0
            Dim yaBorro As Boolean = False

            For index = filaActual To Me.grdProductos.Rows.Count - 1
                Dim codigoArt As Integer = CType(Me.grdProductos.Rows(filaActual).Cells("Id").Value, Integer)
                If yaBorro = False Then
                    'Si borrar es igual a false, elimina la fila
                    Me.grdProductos.Rows.RemoveAt(filaActual)
                    yaBorro = True
                Else
                    'Si estamos es una fila que no tiene datos la eliminamos
                    If codigoArt = 0 Then
                        Me.grdProductos.Rows.RemoveAt(filaActual)
                    End If
                End If
            Next
        End If
    End Sub

#End Region
End Class
