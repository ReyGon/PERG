Imports System.Data.SqlClient
Imports System.Linq


Public Class frmProductoInformacion

    Public codigoProduto As Integer = 0
    Private permiso As New clsPermisoUsuario


    Private Sub frmProductoInformacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridEspeciales(grdDatosReserva)

        Try
            
            Dim p As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigoProduto Select x).FirstOrDefault
            Dim i As tblInventario = (From y In ctx.tblInventarios Where y.idArticulo = p.idArticulo And y.idTipoInventario = CType(mdlPublicVars.General_InventarioLiquidacion, Integer) Select y).FirstOrDefault

            lblCodigo.Text = p.codigo1
            lblNombre.Text = p.nombre1
            lblCantidadMaxima.Text = p.ventaMaxima
            lblCodigo2.Text = p.codigo2
            lblNombre2.Text = p.nombre2

            If i IsNot Nothing Then
                lblLiquidacion.Text = i.saldo
            Else
                lblLiquidacion.Text = ""
            End If

            fnReserva()
            fnConfiguracion()

        Catch ex As Exception

        End Try
       

    End Sub

    Private Sub fnReserva()
        Try

            Dim mireserva = (From x In ctx.tblSalidaDetalles Join y In ctx.tblSalidas On x.idSalida Equals y.idSalida
                             Join z In ctx.tblArticuloes On x.idArticulo Equals z.idArticulo
                             Join t In ctx.tblArticuloTipoPrecios On x.tipoPrecio Equals t.codigo
                             Join r In ctx.tblClientes On y.idCliente Equals r.idCliente
                             Join v In ctx.tblVendedors On v.idVendedor Equals y.idVendedor
                             Where y.anulado = False And y.facturado = False And y.despachar = False And y.reservado = True And x.idArticulo = codigoProduto
                               Select Codigo = y.idSalida, Documento = y.documentoFactura, Cant = x.cantidad, Vendedor = v.nombre, Cliente = r.Negocio, Fecha = y.fechaRegistro).ToList

            Me.grdDatosReserva.DataSource = mireserva
        Catch ex As Exception

        End Try

    End Sub


    'CONFIGURACION
    Private Sub fnConfiguracion()
        If Me.grdDatosReserva.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdDatosReserva.ColumnCount - 1
                Me.grdDatosReserva.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            mdlPublicVars.fnGridTelerik_formatoFecha(grdDatosReserva, "Fecha")

            ''fecha, cliente, documento, precio, cantidad, tipo Precio.
            Me.grdDatosReserva.Columns("codigo").Width = 40
            Me.grdDatosReserva.Columns("documento").Width = 55
            Me.grdDatosReserva.Columns("cant").Width = 40
            Me.grdDatosReserva.Columns("vendedor").Width = 95
            Me.grdDatosReserva.Columns("cliente").Width = 120
            Me.grdDatosReserva.Columns("fecha").Width = 60
            '
        End If
    End Sub

    Private Sub fnTransito()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnx1Salir_Click(sender As System.Object, e As System.EventArgs) Handles pnx1Salir.Click, pbx1Salir.Click, lbl1Salir.Click
        Me.Close()
    End Sub

    Private Sub pnx0kardex_Click(sender As System.Object, e As System.EventArgs) Handles pnx0kardex.Click, pbx0kardex.Click, lbl0kardex.Click

        frmProductoKardex.Text = "Kardex"
        frmProductoKardex.StartPosition = FormStartPosition.CenterScreen
        frmProductoKardex.articulo = codigoProduto
        permiso.PermisoDialogEspeciales(frmProductoKardex)
        frmProductoKardex.Dispose()

    End Sub
End Class
