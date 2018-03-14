Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls



Public Class frmBuscarClientePequenio



    Public contenido As String ' variable para capturar lo que se va a abuscar

    Private Sub frmBuscarClientePequenio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fnFormatoGridEspeciales(grdDatos)


        llenarGrid()
    End Sub


    Private Sub llenarGrid()
        Try
            Dim c = (From x In ctx.tblClientes Where x.Nombre1.Contains(contenido) Select Codigo = x.idCliente, Clave = x.clave, Nombre = x.Nombre1,
                     Nit = x.nit1, Direccion = x.direccionEnvio1)

            grdDatos.DataSource = c

            grdDatos.Columns("Codigo").IsVisible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnx0Salir_Click(sender As System.Object, e As System.EventArgs) Handles pnx0Salir.Click, pbx0Salir.Click, lbl0Salir.Click
        mdlPublicVars.superSearchId = 0
        Me.Close()
    End Sub





    'Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs)

    '    Try
    '        Dim codigo As Integer = fnGrid_codigoFilaSeleccionada(grdDatos)
    '        mdlPublicVars.superSearchId = grdDatos.Rows(codigo).Cells("Codigo").Value
    '        mdlPublicVars.superSearchNombre = grdDatos.Rows(codigo).Cells("Nombre").Value
    '        mdlPublicVars.superSearchClave = grdDatos.Rows(codigo).Cells("Clave").Value
    '        mdlPublicVars.superSearchNit = grdDatos.Rows(codigo).Cells("Nit").Value
    '        Me.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub pbAceptar_Click() Handles Me.panel1

        Try
            Dim codigo As Integer = fnGrid_codigoFilaSeleccionada(grdDatos)
            mdlPublicVars.superSearchId = grdDatos.Rows(codigo).Cells("Codigo").Value
            mdlPublicVars.superSearchNombre = grdDatos.Rows(codigo).Cells("Nombre").Value
            mdlPublicVars.superSearchClave = grdDatos.Rows(codigo).Cells("Clave").Value
            mdlPublicVars.superSearchNit = grdDatos.Rows(codigo).Cells("Nit").Value
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub



   

    Private Sub grdDatos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grdDatos.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try
                Dim codigo As Integer = fnGrid_codigoFilaSeleccionada(grdDatos)
                mdlPublicVars.superSearchId = grdDatos.Rows(codigo).Cells("Codigo").Value
                mdlPublicVars.superSearchNombre = grdDatos.Rows(codigo).Cells("Nombre").Value
                mdlPublicVars.superSearchClave = grdDatos.Rows(codigo).Cells("Clave").Value
                mdlPublicVars.superSearchNit = grdDatos.Rows(codigo).Cells("Nit").Value
                Me.Close()
            Catch ex As Exception

            End Try


        End If

    End Sub
End Class
