Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions

Public Class frmSustitutoLista


    Private Sub frmSustitutoLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()
        fnLlenar()
        fnConfiguracion()
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdDatos)
    End Sub

    Private Sub fnLlenar()
        Try
            Dim articulo As Integer = mdlPublicVars.superSearchId

            Dim ar As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = articulo Select x).FirstOrDefault
            If ar Is Nothing Then
                lblArticulo.Text = ""
                lblCodigo.Text = ""
                Exit Sub
            Else
                lblArticulo.Text = ar.nombre1
                lblCodigo.Text = ar.codigo1
            End If

            Dim sustituto As tblSustituto = (From x In ctx.tblSustitutoes Where x.idarticulo = articulo Select x).FirstOrDefault

            If sustituto IsNot Nothing Then

                Dim consulta = (From x In ctx.tblSustitutoes Join y In ctx.tblArticuloes On x.idarticulo Equals y.idArticulo Order By y.codigo1
                          Where x.idSustitutoCategoria = sustituto.idSustitutoCategoria And y.idArticulo <> articulo
                          Select Codigo = y.codigo1, Nombre = y.nombre1, Marca = y.tblArticuloMarcaRepuesto.nombre, Costo = y.costoIVA, PrecioPublico = y.precioPublico, _
                          PrecioNormal = (From z In ctx.tblArticulo_TipoNegocio Where z.tblClienteTipoNegocio.nombre = "Distribuidor" And z.articulo = y.idArticulo Select z.tblArticulo.precioPublico * (100 - z.descuento) / 100).FirstOrDefault, _
                          Existencia = (From z In ctx.tblInventarios Where z.idArticulo = y.idArticulo Select z.saldo).FirstOrDefault)

                Me.grdDatos.DataSource = consulta
            Else
                Me.grdDatos.DataSource = Nothing
            End If

        Catch ex As Exception
            Me.grdDatos.DataSource = Nothing
        End Try

    End Sub

    'Funcion que se utiliza para configurar el grid
    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.Rows.Count > 0 Then
                'Datos centrados
                Me.grdDatos.Columns(0).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
                Me.grdDatos.Columns(6).TextAlignment = ContentAlignment.MiddleCenter

                'Formato de Columnas
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Costo")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioPublico")
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "PrecioNormal")

                Me.grdDatos.Columns("Costo").IsVisible = False
                Me.grdDatos.Columns("PrecioPublico").IsVisible = False
                Me.grdDatos.Columns("PrecioNormal").IsVisible = False

                'Margenes
                Me.grdDatos.Columns(0).Width = 60
                Me.grdDatos.Columns(1).Width = 200
                Me.grdDatos.Columns(2).Width = 100
                Me.grdDatos.Columns(3).Width = 100
                Me.grdDatos.Columns(4).Width = 100
                Me.grdDatos.Columns(5).Width = 100
                Me.grdDatos.Columns(6).Width = 80
            End If
        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
