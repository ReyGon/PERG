Imports System.Windows
''Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Data.EntityClient
Imports System.Transactions
Imports System.Linq

Public Class frmCargaSelectivaImportacion

    Private _Id As Integer
    Private _cantidadcarga As Integer
    Public tblRetorno As New DataTable

    Public Property Id As Integer
        Get
            Id = _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property cantidadCarga As Integer
        Get
            cantidadCarga = _cantidadcarga
        End Get
        Set(value As Integer)
            _cantidadcarga = value
        End Set
    End Property


    Private Sub frmCargaSelectivaImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdNacionalizado)
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdCarga)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdNacionalizado)
            mdlPublicVars.fnFormatoGridMovimientos(Me.grdCarga)
            mdlPublicVars.fnGrid_iconos(Me.grdNacionalizado)
            mdlPublicVars.fnGrid_iconos(Me.grdCarga)

            fnCargarNacionalizacion()
            fnDescontarCargas()

            tblRetorno.Columns.Clear()
            tblRetorno.Columns.Add("Id")
            tblRetorno.Columns.Add("Caja")
            tblRetorno.Columns.Add("Codigo")
            tblRetorno.Columns.Add("Nombre")
            tblRetorno.Columns.Add("Cantidad")
            tblRetorno.Columns.Add("Costo")

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

                    Me.grdNacionalizado.Rows.Add(CBool(False), n.idArticulo, n.nocaja, n.tblArticulo.codigo1, n.tblArticulo.nombre1, n.cantidad, n.costoIVA)

                Next

                Me.lblContadorProductos.Text = CStr(Me.grdNacionalizado.Rows.Count)

                conn.Close()
                fnConfiguracion()
                Me.grdNacionalizado.Rows(0).IsSelected = True
                Me.grdNacionalizado.Rows(0).Cells("producto").IsSelected = True
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnDescontarCargas()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)


                Dim cargas As List(Of tblEntradasDetalle) = (From x In conexion.tblEntradasDetalles Where x.tblEntrada.IdNacionalizacion = Id Select x).ToList

                Dim cantidad As Integer
                Dim caja As String
                Dim codigo As String

                Try
                    For Each ca As tblEntradasDetalle In cargas

                        Dim c As tblEntradasDetalle = (From x In conexion.tblEntradasDetalles Where x.idEntradaDetalle = ca.idEntradaDetalle Select x).FirstOrDefault

                        ''MessageBox.Show(CStr(c.tblArticulo.codigo1) + " - " + CStr(c.cantidad))

                        For i As Integer = 0 To Me.grdNacionalizado.Rows.Count - 1

                            If Me.grdNacionalizado.Rows(i).Cells("cajano").Value = c.nocaja And Me.grdNacionalizado.Rows(i).Cells("Codigo").Value = c.tblArticulo.codigo1 Then
                                Try

                                    ''MessageBox.Show(CStr(c.tblArticulo.codigo1) + " ! " + CStr(Me.grdNacionalizado.Rows(i).Cells("cantidad").Value) + "-=" + CStr(c.cantidad))
                                    Me.grdNacionalizado.Rows(i).Cells("cantidad").Value -= c.cantidad


                                    If Me.grdNacionalizado.Rows(i).Cells("Cantidad").Value <= 0 Then
                                        Me.grdNacionalizado.Rows(i).Cells("Eliminar").Value = 1
                                    End If

                                Catch ex As Exception

                                End Try
                            End If

                        Next

                    Next

                    For e As Integer = 0 To Me.grdNacionalizado.Rows.Count - 1
                        If Me.grdNacionalizado.Rows(e).Cells("Eliminar").Value = 1 Then
                            ''MessageBox.Show("Entro a ocultar fila")
                            Me.grdNacionalizado.Rows(e).IsVisible = False
                        End If
                    Next

                Catch ex As Exception

                End Try

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try
            Me.grdNacionalizado.Columns("chmAgregar").Width = 60
            Me.grdNacionalizado.Columns("cajano").Width = 60
            Me.grdNacionalizado.Columns("codigo").Width = 75
            Me.grdNacionalizado.Columns("producto").Width = 120
            Me.grdNacionalizado.Columns("cantidad").Width = 60
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdProductos_Click(sender As Object, e As EventArgs) Handles grdNacionalizado.Click
        If Me.grdNacionalizado.CurrentColumn.Name = "chmAgregar" Then
            fnCargaIndividual()
        End If
    End Sub

    Private Sub fnCargaIndividual()
        Try
            Dim fila As Integer = 0

            fila = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdNacionalizado)

            Dim idarticulo As Integer = Me.grdNacionalizado.Rows(fila).Cells("idArticulo").Value
            Dim nombre As String = Me.grdNacionalizado.Rows(fila).Cells("producto").Value
            Dim caja As String = Me.grdNacionalizado.Rows(fila).Cells("cajano").Value
            Dim cantidad As Integer = Me.grdNacionalizado.Rows(fila).Cells("Cantidad").Value
            Dim codigo As String = Me.grdNacionalizado.Rows(fila).Cells("Codigo").Value
            Dim costo As Decimal = Me.grdNacionalizado.Rows(fila).Cells("Costo").Value

            frmCargaSelectivaCantidad.Text = "Cantidad Selectiva"
            frmCargaSelectivaCantidad.lblInformacion.Text = "El articulo " & CStr(nombre).ToLower & " tiene una cantidad de " & CStr(cantidad) _
                                                            & " unidad(es) en la(s) caja(s) " & CStr(caja)
            frmCargaSelectivaCantidad.WindowState = FormWindowState.Normal
            frmCargaSelectivaCantidad.StartPosition = FormStartPosition.CenterScreen
            frmCargaSelectivaCantidad.cantidad = cantidad
            frmCargaSelectivaCantidad.ShowDialog()
            frmCargaSelectivaCantidad.Dispose()

            If cantidadCarga > 0 Then
                Dim f As Object()

                f = {idarticulo, caja, codigo, nombre, cantidadCarga, costo, cantidadCarga * costo}

                Me.grdCarga.Rows.Add(f)

                If Me.grdNacionalizado.Rows(fila).Cells("cantidad").Value - cantidadCarga <= 0 Then
                    Me.grdNacionalizado.Rows(fila).Delete()
                Else
                    Me.grdNacionalizado.Rows(fila).Cells("cantidad").Value -= cantidadCarga
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdNacionalizado_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNacionalizado.KeyDown
        If e.KeyCode = Keys.Enter Then
            fnCargaIndividual()
        End If
    End Sub

    Private Sub fnGuardar() Handles Me.panel0
        Try
            For i As Integer = 0 To Me.grdCarga.Rows.Count - 1
                tblRetorno.Rows.Add(Me.grdCarga.Rows(i).Cells("idArticulo").Value, Me.grdCarga.Rows(i).Cells("cajano").Value, Me.grdCarga.Rows(i).Cells("Codigo").Value, _
                                    Me.grdCarga.Rows(i).Cells("Producto").Value, Me.grdCarga.Rows(i).Cells("Cantidad").Value, Me.grdCarga.Rows(i).Cells("Costo").Value)
            Next

            Me.Close()
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
