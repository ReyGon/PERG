Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmBuscarArticuloVentas
    Private _codigo As Integer
    Private _tipo As String
    Private _codClie As Integer

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property tipo() As String
        Get
            tipo = _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Public Property codClie() As Integer
        Get
            codClie = _codClie
        End Get
        Set(ByVal value As Integer)
            _codClie = value
        End Set
    End Property

    Private Sub frmBuscarArticuloVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(grdModelos)
            mdlPublicVars.fnFormatoGridEspeciales(grdGeneral)
            mdlPublicVars.fnNoModificarTam(Me)
            fnLimpiar()
            fnLlenarDatos()
            fnConfiguracion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarDatos()
        Try
            Dim nombreCP As String = ""
            'Informacion del articulo
            Dim art As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault

            lblArticulo.Text = art.nombre1
            lblCodigo.Text = art.codigo1

            'Obtenemos los modelos compatibles con el articulo
            Dim lista = Nothing
            Dim general = Nothing
            If tipo = "entrada" Then
                lista = (From x In ctx.tblEntradasDetalles
                         Where x.tblEntrada.anulado = False And x.idArticulo = codigo And x.tblEntrada.idProveedor = codClie _
                        Select Fecha = x.tblEntrada.fechaRegistro, Documento = x.tblEntrada.documento, Cantidad = x.cantidad, Costo = x.costoIVA _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

                general = (From x In ctx.tblEntradasDetalles Where x.tblEntrada.anulado = False And x.idArticulo = codigo _
                           And x.tblEntrada.idProveedor <> codClie _
                        Select Fecha = x.tblEntrada.fechaRegistro, Documento = x.tblEntrada.documento, Proveedor = x.tblEntrada.tblProveedor.negocio, Cantidad = x.cantidad, Costo = x.costoIVA _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

                Dim prov As tblProveedor = (From x In ctx.tblProveedors Where x.idProveedor = codClie _
                                                 Select x).FirstOrDefault
                nombreCP = prov.negocio

                Me.Text = "Ultimas Compras"
                lbTituloFrm.Text = "Ultimas Compras"

            ElseIf tipo = "salidas" Then
                lista = (From x In ctx.tblSalidaDetalles Where x.tblSalida.anulado = False _
                         And x.tblSalida.empacado = True And x.idArticulo = codigo And x.tblSalida.idCliente = codClie _
                        Select Fecha = x.tblSalida.fechaRegistro, Documento = x.tblSalida.documento, Cantidad = x.cantidad, Precio = x.precio,
                        TipoPrecio = (From y In ctx.tblArticuloTipoPrecios Where x.tipoPrecio = y.codigo Select y.nombre).FirstOrDefault _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

                general = (From x In ctx.tblSalidaDetalles Where x.tblSalida.anulado = False And x.tblSalida.empacado = True And x.idArticulo = codigo _
                           And x.tblSalida.idCliente <> codClie _
                        Select Fecha = x.tblSalida.fechaRegistro, Cliente = x.tblSalida.tblCliente.Negocio, Documento = x.tblSalida.documento, Cantidad = x.cantidad, Precio = x.precio, _
                         TipoPrecio = (From y In ctx.tblArticuloTipoPrecios Where x.tipoPrecio = y.codigo Select y.nombre).FirstOrDefault _
                        Order By Fecha Descending Take mdlPublicVars.buscarArticulo_cantidadUltimasVentas)

                'Informacion del cliente
                Dim cli As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codClie Select x).FirstOrDefault
                nombreCP = cli.Negocio
                Me.Text = "Ultimas Ventas"
                lbTituloFrm.Text = "Ultimas Ventas"
            End If

            lblCliente.Text = nombreCP

            Me.grdModelos.DataSource = lista
            Me.grdGeneral.DataSource = general

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracion()
        Try

            If tipo = "salidas" Then
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdModelos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdModelos, "Precio")

                Me.grdModelos.Columns(0).Width = 70
                Me.grdModelos.Columns(1).Width = 80
                Me.grdModelos.Columns(2).Width = 70
                Me.grdModelos.Columns(3).Width = 100
                Me.grdModelos.Columns(4).Width = 120

                Me.grdModelos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdModelos.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdModelos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter

                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdGeneral, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdGeneral, "Precio")

                Me.grdGeneral.Columns(0).Width = 80
                Me.grdGeneral.Columns(1).Width = 160
                Me.grdGeneral.Columns(2).Width = 70
                Me.grdGeneral.Columns(3).Width = 60
                Me.grdGeneral.Columns(4).Width = 70
                Me.grdGeneral.Columns(5).Width = 70

                Me.grdGeneral.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdGeneral.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdGeneral.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdGeneral.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdGeneral.Columns(5).TextAlignment = ContentAlignment.MiddleCenter


            Else
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdModelos, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdModelos, "Costo")

                Me.grdModelos.Columns(0).Width = 100
                Me.grdModelos.Columns(1).Width = 90
                Me.grdModelos.Columns(2).Width = 120
                Me.grdModelos.Columns(3).Width = 90

                For i As Integer = 0 To Me.grdModelos.ColumnCount - 1
                    Me.grdModelos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdGeneral, "Fecha")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdGeneral, "Costo")

                Me.grdGeneral.Columns(0).Width = 90
                Me.grdGeneral.Columns(1).Width = 90
                Me.grdGeneral.Columns(2).Width = 140
                Me.grdGeneral.Columns(3).Width = 80
                Me.grdGeneral.Columns(4).Width = 80

                For i As Integer = 0 To Me.grdGeneral.ColumnCount - 1
                    Me.grdGeneral.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub fnLimpiar()
        Try
            grdModelos.DataSource = Nothing
        Catch ex As Exception

        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
