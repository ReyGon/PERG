Imports System.Windows.Forms
Imports System.Windows
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Linq

Public Class frmCargasImportaciones

    Private _Invoice As Integer

    Public Property Invoice As Integer
        Get
            Invoice = _Invoice
        End Get
        Set(value As Integer)
            _Invoice = value
        End Set
    End Property


    Private Sub frmCargasImportaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtFiltroArticulo.Enabled = False
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdProductos)

            fnDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim i As tblEntrada = (From x In conexion.tblEntradas Where x.idEntrada = Invoice Select x).FirstOrDefault

                lblInvoice.Text = i.serieDocumento + "-" + i.documento

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImportacion_Click(sender As Object, e As EventArgs) Handles btnImportacion.Click
        Try
            frmImportar.Text = "Importar"
            frmImportar.bitEntrada = True
            frmImportar.ShowDialog()

            Dim tblR As DataTable = frmImportar.tblRetorno
            frmImportar.Dispose()
            If tblR.Rows.Count > 0 Then

                'buscar fila con id en blanco.
                Dim filaBlanco As Integer = -1

                Dim index
                For index = 0 To Me.grdProductos.Rows.Count - 1
                    If Me.grdProductos.Rows(index).Cells(1).Value Is Nothing Then
                        Me.grdProductos.Rows.RemoveAt(index)
                    ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value.ToString)).Length = 0 Then
                        filaBlanco = index
                    ElseIf LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value.ToString)).Length = 1 And LTrim(RTrim(Me.grdProductos.Rows(index).Cells(1).Value.ToString)) = 0 Then
                        filaBlanco = index
                    End If
                Next

                Dim inicio As Integer = 0

                If filaBlanco = -1 Then
                Else
                    'agregar al grid si nueva fila.
                    Me.grdProductos.Rows(filaBlanco).Cells(1).Value = tblR.Rows(0).Item(0)
                    Me.grdProductos.Rows(filaBlanco).Cells(2).Value = tblR.Rows(0).Item(1)
                    Me.grdProductos.Rows(filaBlanco).Cells(3).Value = tblR.Rows(0).Item(2)
                    Me.grdProductos.Rows(filaBlanco).Cells(4).Value = tblR.Rows(0).Item(3)
                    Me.grdProductos.Rows(filaBlanco).Cells(5).Value = tblR.Rows(0).Item(4)

                    inicio = 1
                End If

                'agregar los elementos restantes al grid.
                For index = inicio To tblR.Rows.Count - 1
                    Me.grdProductos.Rows.Add(tblR.Rows(index).Item(0), tblR.Rows(index).Item(1), tblR.Rows(index).Item(2), tblR.Rows(index).Item(3), Format(CType(tblR.Rows(index).Item(4), Double), formatoNumero), Format(tblR.Rows(index).Item(3) * tblR.Rows(index).Item(4), formatoNumero))
                Next


                Dim j As Integer
                Dim filas As Integer
                Dim costod As Decimal
                Dim cantidad As Integer
                filas = grdProductos.Rows.Count - 1

                For m As Integer = 0 To filas
                    costod = grdProductos.Rows(m).Cells("CostoTotal").Value

                    Dim lbtotalcarga As Decimal
                    Try
                        lbtotalcarga = Replace(lblTotalCarga.Text, "Q", "")
                    Catch ex As Exception
                        lbtotalcarga = 0
                    End Try

                    'lbltotaldolares.Text = lbltotaldolares.Text + costod
                    lblTotalCarga.Text = Format(CDec(If(lbtotalcarga = 0, 0, CDec(lbtotalcarga))) + (CDec(grdProductos.Rows(m).Cells("CostoTotal").Value)), mdlPublicVars.formatoMoneda)

                    ''''fnTotalProrrateo()
                    fnActualizar_Total()
                    ''Me.grdproductos.Rows.AddNew()

                Next

                fnEliminaVacias()
                fnConfiguracion()
                fnActivarFiltro()
                Me.grdProductos.Rows.AddNew()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnActivarFiltro()
        Try
            If Me.grdProductos.Rows.Count - 1 > 0 Then
                Me.txtFiltroArticulo.Enabled = True
            Else
                Me.txtFiltroArticulo.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            Me.grdProductos.Columns("Codigo").Width = 75
            Me.grdProductos.Columns("Producto").Width = 150
            Me.grdProductos.Columns("Cantidad").Width = 60
            Me.grdProductos.Columns("Costo").Width = 50
            Me.grdProductos.Columns("CostoTotal").Width = 50
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fnActualizar_Total()
        ''lblRecuento.Text = Me.grdproductos.Rows.Count

        Try
            If Me.grdproductos.Rows.Count > 0 Then
                Dim cantidad As Double = 0
                Dim precio As Double = 0
                Dim totalCompra As Double = 0

                For index As Integer = 0 To Me.grdproductos.Rows.Count - 1
                    Dim producto As String = CType(Me.grdProductos.Rows(index).Cells("Producto").Value, String)

                    If producto IsNot Nothing Then

                        cantidad = CType(Me.grdProductos.Rows(index).Cells("Cantidad").Value, Double)
                        precio = CType(Me.grdProductos.Rows(index).Cells("Costo").Value.ToString, Double)

                        If (cantidad * precio) = 0 Then
                            Me.grdProductos.Rows(index).Cells("CotoTotal").Value = "0"
                        Else
                            Me.grdProductos.Rows(index).Cells("CostoTotal").Value = Format(cantidad * precio, "###,###.##").ToString
                        End If

                        totalCompra += (cantidad * precio)

                    End If

                Next

                lblTotalCarga.Text = Format(totalCompra, mdlPublicVars.formatoMonedaDolar)
            Else
                lblTotalCarga.Text = 0
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub fnEliminaVacias()
        Try
            If Me.grdproductos.Rows.Count > 0 Then
                'Recorremos el grid
                Dim nombre As String = ""
                For i As Integer = 0 To Me.grdproductos.Rows.Count - 1
                    'Obtenemo el valor del nombre
                    nombre = Me.grdProductos.Rows(i).Cells("Producto").Value
                    If IsNothing(nombre) Then
                        Me.grdproductos.Rows.RemoveAt(i)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtFiltroArticulo_Click(sender As Object, e As EventArgs) Handles txtFiltroArticulo.Click
        Try
            Me.txtFiltroArticulo.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFiltroArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltroArticulo.KeyDown
        Try

            If Me.txtFiltroArticulo.Text = "" Then

                For a As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    Me.grdProductos.Rows(a).IsVisible = True

                Next

            ElseIf Me.txtFiltroArticulo.Text <> "" Then

                For a As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    If Me.grdProductos.Rows(a).Cells("Producto").Value.ToString.ToLower.Contains(Me.txtFiltroArticulo.Text.ToString.ToLower) Then

                    Else
                        Me.grdProductos.Rows(a).IsVisible = False
                    End If

                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnGuardar() Handles Me.panel0
        Try

            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim idprecarga As Integer = 0
                Dim p As New tblPrecarga

                p.fechaRegistro = fnFecha_horaServidor()
                p.idusuario = mdlPublicVars.idUsuario
                p.idinvoice = Invoice
                p.confirmado = False
                p.anulado = False
                p.Total = CDec(Replace(Me.lblTotalCarga.Text, "$", ""))

                conexion.AddTotblPrecargas(p)
                conexion.SaveChanges()

                idprecarga = p.idPrecarga

                Dim pd As New tblPrecargaDetalle

                For a As Integer = 0 To Me.grdProductos.Rows.Count - 1

                    pd.idPrecarga = idprecarga
                    pd.idArticulo = Me.grdProductos.Rows(a).Cells("IdArticulo").Value
                    pd.cantidad = Me.grdProductos.Rows(a).Cells("Cantidad").Value
                    pd.costo = Me.grdProductos.Rows(a).Cells("Costo").Value

                    conexion.AddTotblPrecargaDetalles(pd)
                    conexion.SaveChanges()

                Next

                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir() Handles Me.panel1
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class
