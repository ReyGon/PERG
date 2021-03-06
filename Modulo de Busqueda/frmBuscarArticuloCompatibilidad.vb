﻿Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class frmBuscarArticuloCompatibilidad

    Private _codigo As Integer

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Private Sub frmBuscarArticuloCompatibilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.fnFormatoGridEspeciales(grdModelos)
            fnLlenarDatos()
            fnConfiguracion()
            lblGrid2.Text = ProductoGrid2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarDatos()
        Try
            'Obtenemos los modelos compatibles con el articulo
            Dim listaModelos = (From x In ctx.tblArticulo_ModeloVehiculo Where x.articulo = codigo _
                                Select Codigo = x.articuloModeloVehiculo, Modelo = x.tblArticuloModeloVehiculo.nombre,
                                Abreviatura = x.tblArticuloModeloVehiculo.abreviatura)

            grdModelos.DataSource = listaModelos

            'Llenamos el encabezado
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault
            lblArticulo.Text = articulo.nombre1
            lblCodigo.Text = articulo.codigo1
        Catch ex As Exception
            grdModelos.DataSource = Nothing
        End Try
    End Sub

    Private Sub fnConfiguracion()
        Me.grdModelos.Columns("Codigo").Width = 50
        Me.grdModelos.Columns("Modelo").Width = 150
        Me.grdModelos.Columns("Abreviatura").Width = 120
    End Sub


    
    'SALIR
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
