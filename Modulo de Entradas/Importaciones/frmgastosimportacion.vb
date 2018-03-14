Imports System.Linq
Imports Telerik.WinControls.UI
Imports System.Transactions

Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Data.OleDb
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Public Class frmgastosimportacion
    Public filas As Integer

    Public total As Decimal
    Dim tbl As New clsDevuelveTabla
    Private Sub frmgastosimportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mdlPublicVars.fnFormatoGridEspeciales(Me.grdproductos)
        mdlPublicVars.fnGrid_iconos(grdproductos)
        Me.grdproductos.Columns(2).ReadOnly = False
        Me.grdproductos.Columns("txmMonto").ReadOnly = False
        Me.grdproductos.Columns("Rubro").ReadOnly = True
        fnNuevo()
        fnllenargrid()

    End Sub

    Private Sub fnNuevo()
        Try

            Me.grdproductos.AllowDeleteRow = True


            Me.grdproductos.Rows.Clear()

            'If bitEditarEntrada = False Then
            Me.grdproductos.Rows.AddNew()
            'End If
            Me.grdproductos.Columns(0).ReadOnly = True
            Me.grdproductos.Columns(1).ReadOnly = True
            Me.grdproductos.Columns(2).ReadOnly = False

        Catch ex As Exception
        End Try
    End Sub
    Private Sub fnllenargrid()
        Dim idrubro As Integer
        Dim rubro As String

        Dim conexion As New dsi_pos_demoEntities

        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)


            Dim listado As List(Of tblrubrogasto) = (From x In conexion.tblrubrogastos Select x).ToList

            Dim listadorubros As tblrubrogasto

            'Limpiar las filas del grid View.
            Me.grdproductos.Rows.Clear()
            For Each listadorubros In listado
                'Creamos la fila

                Dim fila As Object()
                fila = {listadorubros.idrubro, listadorubros.rubro}

                'La añadimos al grid
                grdproductos.Rows.Add(fila)
            Next

            'cerrar la conexion.
            conn.Close()

        End Using



    End Sub

    Private Sub fnguardar_Click() Handles Me.panel0


        filas = Me.grdproductos.Rows.Count - 1

        For i As Integer = 0 To filas

            total = total + Me.grdproductos.Rows(i).Cells("txmMonto").Value
        Next

        frmImportaciones.totalgastos = total
        ''frmproformaimportacion.lbltgastos.Text = total

        mdlPublicVars.supergridview = Me.grdproductos
        'fn_grabaRegistro()
        Me.Hide()
      
    End Sub


    'Public Sub fn_grabaRegistro()
    '    Dim entradas As Integer
    '    Dim identrada5 As Long
    '    Dim conexion As New dsi_pos_demoEntities
    '    Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
    '        conn.Open()
    '        conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

    '        Dim success As Boolean = True
    '        Dim m As New tblgastosimportacion

    '        Dim e = (From x In conexion.tblEntradas Select x.idEntrada).Max

    '        identrada5 = e + 1


    '        'crear el encabezado de la transaccion
    '        Using transaction As New TransactionScope
    '            'inicio de excepcion
    '            Dim consulta As String
    '            Try
    '                Dim totalgasto As Decimal
    '                Dim filas2 As Integer
    '                filas2 = Me.grdproductos.Rows.Count - 1
    '                For y As Integer = 0 To filas2
    '                    totalgasto = totalgasto + Me.grdproductos.Rows(y).Cells("txmMonto").Value
    '                Next

    '                m.fechagasto = Today.ToString
    '                m.idusuario = mdlPublicVars.idUsuario
    '                m.totalgasto = totalgasto
    '                m.identrada = identrada5

    '                conexion.AddTotblgastosimportacions(m)
    '                conexion.SaveChanges()

    '                Dim filas = grdproductos.Rows.Count - 1
    '                Dim idgasto As Integer
    '                Dim idrubro As Integer
    '                Dim monto As Decimal


    '                idgasto = m.idgasto


    '                For x As Integer = 0 To filas
    '                    Dim d As New tblgastosimportaciondetalle
    '                    idrubro = grdproductos.Rows(x).Cells("idrubro").Value

    '                    monto = grdproductos.Rows(x).Cells("txmMonto").Value
    '                    d.idrubro = idrubro
    '                    d.idgasto = idgasto
    '                    d.monto = monto
    '                    conexion.AddTotblgastosimportaciondetalles(d)
    '                    conexion.SaveChanges()
    '                Next





    '                'completar la transaccion.
    '                success = True
    '                transaction.Complete()
    '                MsgBox("Guardado")
    '            Catch ex As System.Data.EntityException
    '                success = False
    '            Catch ex As Exception
    '                success = False
    '                ' Handle errors and deadlocks here and retry if needed. 
    '                ' Allow an UpdateException to pass through and 
    '                ' retry, otherwise stop the execution. 
    '                If ex.[GetType]() <> GetType(UpdateException) Then
    '                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)

    '                    Exit Try
    '                    ' If we get to this point, the operation will be retried. 
    '                End If
    '            End Try
    '        End Using

    '        If success = True Then
    '            ctx.AcceptAllChanges()


    '        Else

    '            Console.WriteLine("La operacion no pudo ser completada")
    '        End If
    '    End Using
    'End Sub



    Private Sub fnsalir() Handles Me.panel1
        Me.Hide()
    End Sub

    Private Sub fnreporte() Handles Me.panel2
        frmReporteGastosfiltro.Text = "Reporte Gastos"
        frmReporteGastosfiltro.Show()
    End Sub

End Class
