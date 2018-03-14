Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmBuscarArticuloPrecioCompetencia

    Public codigoCliente As Integer = 0
    Public codigoArticulo As Integer = 0
    Public bitBloquearCombo As Boolean = False ' variable que define el bloqueo del combo cliente




    Private Sub frmBuscarArticuloPrecioCompetencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(Me.grdProductos)
            fnLlenarDatos()
            fnLlenar()

            fnConfiguracion()

            fnLLenarCombo()
           

        Catch ex As Exception
        End Try
    End Sub

    Private Sub fnLLenarCombo()
        Try
            Dim cliente = (From x In ctx.tblClientes Select Codigo = x.idCliente, Nombre = x.Nombre1).ToList

            With cmbCliente
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cliente
            End With


            If bitBloquearCombo = True Then
                cmbCliente.SelectedValue = codigoCliente
                cmbCliente.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub


    'Esta funcion sirve para agregar el encabezado del formulario(codigo,articulo,clave,cliente)
    Private Sub fnLlenarDatos()
        Try
            'Obtenemos el articulo
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.idArticulo = codigoArticulo Select x).FirstOrDefault

            lblCodigo.Text = articulo.codigo1
            lblArticulo.Text = articulo.nombre1



            'Obtenemos el cliente
            'Dim cliente As tblCliente = (From x In ctx.tblClientes.AsEnumerable Where x.idCliente = codigoCliente Select x).FirstOrDefault
            ' lblClave.Text = cliente.idCliente
            ' lblCliente.Text = cliente.Negocio
        Catch ex As Exception

        End Try
    End Sub

    'Esta funcion agrega los precios de competencia ya guardados filtrando por articulo y por cliente
    Private Sub fnLlenar()
        Try
            'Realizamos la consulta
            Dim consulta = (From x In ctx.tblPrecioCompetencias Where x.articulo = codigoArticulo _
                            Select Fecha = x.fechaRegistro, Cliente = x.tblCliente.Negocio, Precio = x.precio, Observacion = x.observacion Order By Fecha Descending)

            'Llenamos el grid con la consulta
            Me.grdProductos.DataSource = consulta
        Catch ex As Exception
            Me.grdProductos.DataSource = Nothing
        End Try
    End Sub

    'Esta funcion configura el tamaño del grid
    Private Sub fnConfiguracion()
        Try
            mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdProductos, "Fecha")
            mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdProductos, "Precio")

            Me.grdProductos.Columns("Fecha").TextAlignment = ContentAlignment.MiddleCenter
            Me.grdProductos.Columns(0).Width = 70
            Me.grdProductos.Columns(1).Width = 150
            Me.grdProductos.Columns(2).Width = 90


        Catch ex As Exception
            Me.grdProductos.DataSource = Nothing
        End Try
    End Sub

    'Guardamos el nuevo precio de competencia
    Private Sub fnGuardar()
        Try
            Dim observacion As String = txtObservacion.Text
            Dim precio As Decimal = CDec(txtPrecio.Text)

            If observacion <> "" And precio > 0 Then
                Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor
                'Creamos el nuevo precio de competencia
                Dim nuevoPrecio As New tblPrecioCompetencia
                nuevoPrecio.articulo = codigoArticulo
                nuevoPrecio.cliente = cmbCliente.SelectedValue
                nuevoPrecio.precio = precio
                nuevoPrecio.observacion = observacion
                nuevoPrecio.fechaRegistro = fecha
                ctx.AddTotblPrecioCompetencias(nuevoPrecio)
                ctx.SaveChanges()

                'Modificamos el precio de competencia del articulo
                Dim art As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigoArticulo Select x).FirstOrDefault
                art.precioCompetencia = precio
                ctx.SaveChanges()
            Else
                alerta.contenido = "Ingrese precio u observacion"
                alerta.fnErrorContenido()
            End If
            fnLlenar()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub lblAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            fnGuardar()
            txtObservacion.Text = ""
            txtPrecio.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    'Salir
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged

        Try
            Dim codigo As Integer = cmbCliente.SelectedValue
            Dim cliente As tblCliente = (From x In ctx.tblClientes Where x.idCliente = codigo Select x).FirstOrDefault

            lblClave.Text = cliente.clave

        Catch ex As Exception

        End Try

    End Sub


End Class
