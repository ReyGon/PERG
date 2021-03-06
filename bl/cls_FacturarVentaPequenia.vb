﻿Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Imports System.Linq
Imports Telerik.WinControls



Public Class cls_FacturarVentaPequenia

    Public alerta As New bl_Alertas
    Private permiso As New clsPermisoUsuario


    Public _codCliente As Integer
    Public _codSalida As Integer

    Dim totalPagar As Double = 0
    Dim descuento As Double = 0

    Public Property codCliente As Integer
        Get
            codCliente = _codCliente
        End Get
        Set(value As Integer)
            _codCliente = value
        End Set
    End Property


    Public Property codSalida As Integer
        Get
            codSalida = _codSalida
        End Get
        Set(value As Integer)
            _codSalida = value
        End Set
    End Property



    Public Sub fnFacturarSalida()
        Try

            'Debemos de revisar si el pedido ya se reviso, y luego si el cliente tiene o no mas pedidos
            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = codSalida Select x).FirstOrDefault

            If salida.anulado = True Or salida.facturado = True Then
                alerta.contenido = "Venta Facturada o Anulada "
                alerta.fnErrorContenido()
                Exit Sub
            End If

            If salida IsNot Nothing Then
                'Si la salida ya esta revisada
                If salida.empacado = True And salida.anulado = False Then
                    'Obtenemos el estado
                    Dim estado = ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, salida.idSalida).ToList

                    For Each es As sp_salida_Estado_Result In estado
                        'If es.clrEnvio <> 1 Then
                        fnFacturar(salida)
                    Next
                Else
                    If salida.anulado Then
                        alerta.contenido = "El pedido ya ha sido anulado"
                    Else
                        alerta.contenido = "El pedido no ha sido revisado"
                    End If
                    alerta.fnErrorContenido()
                End If
            Else
                alerta.contenido = "Error en la operacion"
                alerta.fnErrorContenido()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub



    Private Sub fnFacturar(ByVal salida As tblSalida)

        Try
            Dim consulta = (From x In ctx.tblSalidas _
                                                      Where x.idSalida = salida.idSalida And salida.facturado = False And x.anulado = False _
                                                      Select Codigo = x.idSalida, Pagos = If(x.contado = True, "Contado", "Credito"), Fecha = x.fechaRegistro, Documento = x.documento, _
                                                      DireccionFacturacion = x.direccionFacturacion, Vendedor = x.tblVendedor.nombre, Total = x.total, clrEstado = 0, Estado = "Revisado", Descripcion = "", Clave = salida.idCliente).FirstOrDefault

            Dim codigo1 = consulta.Codigo
            Dim pagos1 = consulta.Pagos
            Dim fecha1 = consulta.Fecha
            Dim documento1 = consulta.Documento
            Dim vendedor1 = consulta.Vendedor
            Dim total1 = consulta.Total
            Dim direccion1 = consulta.DireccionFacturacion
            Dim codigoCliente = consulta.Clave

            Dim agregar As Integer = 0
            'Verificamos si el cliente tiene mas facturas
            'Dim nFacturas As Integer = From x In ctx.tblSalidas _
            '                            Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa And x.idCliente = salida.idCliente _
            '                            And fnSalidaEstado(mdlPublicVars.idEmpresa, x.idSalida) <> 1 And x.anulado = False Select x

            Dim consFacturas = (From x In ctx.tblSalidas
                                        Where x.facturado = False And x.empacado = True And x.idEmpresa = mdlPublicVars.idEmpresa And x.idCliente = salida.idCliente _
                                         And x.anulado = False Select x.idSalida).ToList()

            Dim nFacturas As Integer = 0
            Dim xx
            For Each xx In consFacturas
                Dim estado = ctx.sp_salida_Estado(mdlPublicVars.idEmpresa, xx).ToList
                For Each es As sp_salida_Estado_Result In estado
                    nFacturas = nFacturas + 1
                Next
            Next

            If nFacturas > 1 Then
                If RadMessageBox.Show("¿Tiene " & nFacturas & " Pedidos, desea elegir cuales facturar?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    frmFactura.Text = "Factura"
                    frmFactura.MdiParent = frmMenuPrincipal
                    frmFactura.codigoCliente = codigoCliente
                    frmFactura.WindowState = FormWindowState.Maximized
                    permiso.PermisoFrmEspeciales(frmFactura, True)

                    ' Me.Hide() 'Verificar si no afecta

                Else
                    'If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                    'quitamos el if para la venta pequenia
                    agregar = 1
                    nFacturas = 1
                    'End If ' 
                End If

            ElseIf nFacturas = 1 Then

                ' If RadMessageBox.Show("¿Desea facturar el pedido?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbYes Then
                agregar = 1
                nFacturas = 1
                'End If
            Else

            End If

            If nFacturas < 2 Then
                If agregar = 1 Then
                    'Vaciamos la tabla con los codigos
                    mdlPublicVars.General_CodigoSalida.Rows.Clear()
                    mdlPublicVars.General_CodigoSalida.Rows.Add(codigo1, Format(fecha1, mdlPublicVars.formatoFecha), documento1, vendedor1, Format(total1, mdlPublicVars.formatoMoneda))
                    Dim total As Decimal = mdlPublicVars.fnTotalTablaFacturas

                    mdlPublicVars.GuardarFacturacion(salida.idSalida) 'Se cambio ahora solo le enviamos el codigo de salida
                End If


                '----------------- ya no es necesario en punto de venta pequenio -------

                'frmFacturaImprimir.Text = "Facturar"

                'If pagos1 = "Contado" Then
                '    frmFacturaImprimir.bitContado = True
                '    frmFacturaImprimir.bitCredito = False
                'Else
                '    frmFacturaImprimir.bitContado = False
                '    frmFacturaImprimir.bitCredito = True
                'End If

                'frmFacturaImprimir.codClie = salida.idCliente
                'frmFacturaImprimir.dirFact = direccion1
                'frmFacturaImprimir.StartPosition = FormStartPosition.CenterScreen
                'frmFacturaImprimir.ShowDialog()
                'frmFacturaImprimir.Dispose()
                'permiso.PermisoFrmEspeciales(frmFacturaImprimir, False)

                '---------------------------------fin de lineas no necesarias

            End If

            'llenanmos nuevament el listado
            frmVentaPequeniaLista.frm_llenarLista()
        Catch ex As Exception

        End Try


    End Sub


End Class
