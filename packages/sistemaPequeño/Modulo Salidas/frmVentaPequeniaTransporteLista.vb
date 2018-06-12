Option Strict On

Imports System.Linq
Imports System.Data.EntityClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmVentaPequeniaTransporteLista

#Region "Variables"
    Private _listaTransportes As List(Of tblSalidasTransporte)
    Private _listaTransportesEliminar As List(Of tblSalidasTransporte)
#End Region

#Region "Propiedades"
    Public Property listaTransportes As List(Of tblSalidasTransporte)
        Get
            listaTransportes = _listaTransportes
        End Get
        Set(value As List(Of tblSalidasTransporte))
            _listaTransportes = value
        End Set
    End Property

    Public Property listaTransportesEliminar As List(Of tblSalidasTransporte)
        Get
            listaTransportesEliminar = _listaTransportesEliminar
        End Get
        Set(value As List(Of tblSalidasTransporte))
            _listaTransportesEliminar = value
        End Set
    End Property

#End Region

#Region "Eventos"
    'INICIO DEL FORMULARIO
    Private Sub frmVentaPequeniaTransporteLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdTransportes)

        fnLlenarGrid()
    End Sub

    'SALIR
    Private Sub fnSalir_Click() Handles Me.panel1
        Me.Close()
    End Sub

    'AGREGAR
    Private Sub fnAgregar_Click() Handles Me.panel0
        Dim formTransporte As New frmVentaPequeniaTransporteAgregar
        formTransporte.Text = "AGREGAR TRANSPORTE"
        formTransporte.StartPosition = FormStartPosition.CenterScreen
        formTransporte.listaTransportes = Me.listaTransportes
        formTransporte.ShowDialog()

        Me.listaTransportes = formTransporte.listaTransportes
        fnLlenarGrid()
        formTransporte.Dispose()
    End Sub

    'CLICK EN LAS COLUMNAS EDITAR Y ELIMINAR
    Private Sub grdTransportes_CommandCellClick(sender As Object, e As EventArgs) Handles grdTransportes.CommandCellClick
        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdTransportes)

        If fila >= 0 Then
            Dim columna As Integer = Me.grdTransportes.CurrentColumn.Index

            If columna >= 0 Then
                If grdTransportes.Columns(columna).Name = "eliminar" Then
                    'Eliminar
                    If RadMessageBox.Show("¿Desea eliminar el transporte?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        'Si el elemento tiene un id se pasa a la lista de transportes a eliminar
                        If listaTransportes.Item(fila).idSalidaTransporte > 0 Then
                            listaTransportesEliminar.Add(listaTransportes.Item(fila))
                        End If

                        listaTransportes.RemoveAt(fila)
                        fnLlenarGrid()
                    End If
                ElseIf grdTransportes.Columns(columna).Name = "editar" Then
                    'Editar
                    frmVentaPequeniaTransporteAgregar.Text = "Editar Transporte"
                    frmVentaPequeniaTransporteAgregar.bitEditar = True
                    frmVentaPequeniaTransporteAgregar.indice = fila
                    frmVentaPequeniaTransporteAgregar.listaTransportes = listaTransportes
                    frmVentaPequeniaTransporteAgregar.ShowDialog()
                    frmVentaPequeniaTransporteAgregar.Dispose()
                    fnLlenarGrid()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Funciones"
    'LLENAR EL GRID  CON LOS DATOS DE TRANSPORTES
    Private Sub fnLlenarGrid()
        Me.grdTransportes.Rows.Clear()

        Dim conexion As dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            For Each transporte As tblSalidasTransporte In listaTransportes
                Dim transporteCosteo As tblTransporteCosteo = (From x In conexion.tblTransporteCosteos.AsEnumerable Where x.idTransporteCosteo = transporte.idTransporteCosteo).FirstOrDefault
                Dim sector As tblSectore = (From x In conexion.tblSectores.AsEnumerable Where x.idSector = transporte.idSector).FirstOrDefault

                Dim fila As Object() = {transporte.idTransporteCosteo, transporte.idSector, transporteCosteo.descripcion, sector.tblMunicipio.nombre + ", " + sector.descripcion,
                                        transporte.direccion, transporte.precio, transporte.cantidad, transporte.observacion}

                Me.grdTransportes.Rows.Add(fila)
            Next

            conn.Close()
        End Using
    End Sub
#End Region

End Class