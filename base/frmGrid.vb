﻿''Option Strict On

Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Imports System.Linq


Public Class FrmGrid

    Private _bitkit As Boolean
    Private _bitProduccion As Boolean
    Private _bitVenta As Boolean

    ''Filtros

    Private _filtro1 As String
    Private _filtro2 As String

    Public Property bitkit() As Boolean
        Get
            bitkit = _bitkit
        End Get
        Set(value As Boolean)
            _bitkit = value
        End Set
    End Property

    Public Property filtro1() As String
        Get
            filtro1 = _filtro1
        End Get
        Set(value As String)
            _filtro1 = value
        End Set
    End Property

    Public Property filtro2() As String
        Get
            filtro2 = _filtro2
        End Get
        Set(value As String)
            _filtro2 = value
        End Set
    End Property

    Public Property bitProduccion() As Boolean
        Get
            bitProduccion = _bitProduccion
        End Get
        Set(value As Boolean)
            _bitProduccion = value
        End Set
    End Property

    Public Property bitVenta() As Boolean
        Get
            bitVenta = _bitVenta
        End Get
        Set(value As Boolean)
            _bitVenta = value
        End Set
    End Property


    Private Sub frmGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdDatos)
        fnLlenarGrid()
        mdlPublicVars.fnFormulario_quitaBarraTitulo(Me)
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub fnLlenarGrid()
        Try
            If bitkit = True Then

                Dim detalle = From p In (From x In ctx.tblArticulo_UnidadMedida Where x.tblArticulo.idArticulo = x.idArticulo And x.tblArticulo.idArticulo = filtro1 And x.tblUnidadMedida.idunidadMedida = x.idUnidadMedida
                           Select codigo = x.idArticulo_UnidadMedida,
                           UnidadMedida = x.tblUnidadMedida.nombre,
                           Costo = x.tblArticulo.costoIVA * x.valor,
                           Unidades = x.valor,
                           Precio = x.precio) _
                           Select p.codigo, p.UnidadMedida, p.Costo, p.Unidades

                grdDatos.DataSource = detalle

            End If

            fnConfiguracion()

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    ''FUNCION UTILIZADO PARA CONFIGURAR EL GRID
    Private Sub fnConfiguracion()
        Try

            If Me.grdDatos.ColumnCount > 0 Then
                If bitkit = True Then
                    Me.grdDatos.Columns("codigo").IsVisible = False
                    Me.grdDatos.Columns("UnidadMedida").Width = 150
                    Me.grdDatos.Columns("Costo").Width = 150
                    Me.grdDatos.Columns("Unidades").Width = 100
                End If
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        fnAgregar()
    End Sub

    Private Sub grdDatos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            fnAgregar()
        End If
    End Sub

    ''FUNCION DE AGREGADO   
    Private Sub fnAgregar()
        Try

            If Me.grdDatos.RowCount > 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)

                If bitkit = True Then
                    mdlPublicVars.superSearchId = Me.grdDatos.Rows(fila).Cells("Codigo").Value
                    mdlPublicVars.superSearchCosto = Me.grdDatos.Rows(fila).Cells("Costo").Value
                    mdlPublicVars.superSearchNombre = Me.grdDatos.Rows(fila).Cells("UnidadMedida").Value
                    mdlPublicVars.superSearchUnidadMedidaValor = Me.grdDatos.Rows(fila).Cells("Unidades").Value
                End If
            Else
                mdlPublicVars.superSearchId = -1
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnsalir() Handles Me.panel0
        Me.Close()
    End Sub

End Class
