Public Class clsReportes
    Dim tbl As New clsDevuelveTabla

    Public Function rptEntrada_Historial(ByVal fi As String, ByVal ff As String, ByVal codmaterial As Integer, ByVal codMovimiento As Integer, ByVal sfiltro As String, ByVal codlugar As Integer, ByVal codFinca As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte
            r.reporte = "rptEntradaHistorial.rpt"
            r.tabla = tbl.tablaSP("sp_Entrada_Reporte '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codmaterial.ToString + "','" + codMovimiento.ToString + "','" + codlugar.ToString + "','" + codFinca.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()
        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try
        Return True
    End Function

    Public Function rptEntrada_FormatoImpresion(ByVal sfiltro As String, ByVal codigo As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte

            r.reporte = "rptEntradaFormato.rpt"
            r.tabla = tbl.tablaSP("sp_entrada_reporte_formato '" + f.ToString + "','" + codigo.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()

        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try

        Return True
    End Function


    Public Function rptTraslado_Historial(ByVal fi As String, ByVal ff As String, ByVal codmaterial As Integer, ByVal codMovimiento As Integer, ByVal sfiltro As String, ByVal codlugar As Integer, ByVal codFinca As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte
            r.reporte = "rptTrasladoHistorial.rpt"
            r.tabla = tbl.tablaSP("sp_Traslado_Reporte '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codmaterial.ToString + "','" + codMovimiento.ToString + "','" + codlugar.ToString + "','" + codFinca.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()
        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try
        Return True
    End Function


    Public Function rptTraslado_FormatoImpresion(ByVal sfiltro As String, ByVal codigo As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte

            r.reporte = "rptTrasladoFormato.rpt"
            r.tabla = tbl.tablaSP("sp_Traslado_reporte_formato '" + f.ToString + "','" + codigo.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()

        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try

        Return True
    End Function

    '-------------------------------- salidas
    Public Function rptSalida_Historial(ByVal fi As String, ByVal ff As String, ByVal codmaterial As Integer, ByVal codMovimiento As Integer, ByVal sfiltro As String,codlugar As Integer,codFinca As Integer)


        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte

            r.reporte = "rptSalidaHistorial.rpt"
            r.tabla = tbl.tablaSP("sp_Salida_Reporte '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codmaterial.ToString + "','" + codMovimiento.ToString + "','" + codlugar.ToString + "','" + codFinca.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()

        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try

        Return True
    End Function


    Public Function rptEntrada_Resumen(ByVal fi As String, ByVal ff As String, ByVal codfinca As Integer, ByVal codLugar As Integer, ByVal sfiltro As String, ByVal codmaterial As Integer, ByVal codtipoMovimiento As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte
            r.reporte = "rptEntradaResumen.rpt"
            r.tabla = tbl.tablaSP("sp_Entrada_reporte_resumen '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codfinca.ToString + "','" + codLugar.ToString + "','" + codmaterial.ToString + "','" + codtipoMovimiento.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()
        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try
        Return True
    End Function

    Public Function rptTraslado_Resumen(ByVal fi As String, ByVal ff As String, ByVal codfinca As Integer, ByVal codLugar As Integer, ByVal sfiltro As String, ByVal codmaterial As Integer, ByVal codTipoMovimiento As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte
            r.reporte = "rptTrasladoResumen.rpt"
            r.tabla = tbl.tablaSP("sp_Traslado_reporte_resumen '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codfinca.ToString + "','" + codLugar.ToString + "','" + codmaterial.ToString + "','" + codTipoMovimiento.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()
        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try
        Return True
    End Function


    Public Function rptSalida_Resumen(ByVal fi As String, ByVal ff As String, ByVal codfinca As Integer, ByVal codLugar As Integer, ByVal sfiltro As String, ByVal codmaterial As Integer, ByVal codtipoMovimiento As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte
            r.reporte = "rptSalidaResumen.rpt"
            r.tabla = tbl.tablaSP("sp_salida_reporte_resumen '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codfinca.ToString + "','" + codLugar.ToString + "','" + codmaterial.ToString + "','" + codtipoMovimiento.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()
        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try
        Return True
    End Function


    Public Function rptSalida_Estimacion(ByVal fi As String, ByVal ff As String, ByVal codfinca As Integer, ByVal codLugar As Integer, ByVal sfiltro As String, ByVal codmaterial As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte
            r.reporte = "rptSalidaEstimar.rpt"
            r.tabla = tbl.tablaSP("sp_salida_reporte_Estimacion '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codfinca.ToString + "','" + codLugar.ToString + "','" + codmaterial.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()
        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try
        Return True
    End Function



    Public Function rptSalida_noViajes(ByVal fi As String, ByVal ff As String, ByVal sFiltro As String, ByVal codMaterial As Integer, ByVal codTipoMovimiento As Integer, ByVal codfinca As Integer, ByVal codlugar As Integer)


        Dim f As String
        If sFiltro.Length > 0 Then
            f = sFiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte

            r.reporte = "rptSalidaViajes.rpt"
            r.tabla = tbl.tablaSP("sp_salida_Viajes '" + f.ToString + "','" + fi.ToString + "','" + ff.ToString + "','" + codMaterial.ToString + "','" + codTipoMovimiento.ToString + "','" + codfinca.ToString + "','" + codlugar.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()

        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try

        Return True
    End Function


    Public Function rptSalida_FormatoImpresion(ByVal sfiltro As String, ByVal codigo As Integer)
        Dim f As String
        If sfiltro.Length > 0 Then
            f = sfiltro
        Else
            f = ""
        End If
        Try
            Dim r As New clsReporte

            r.reporte = "rptSalidaFormato.rpt"
            r.tabla = tbl.tablaSP("sp_Salida_reporte_formato '" + f.ToString + "','" + codigo.ToString + "'")
            r.nombreParametro = "@filtro"
            r.parametro = ""
            r.verReporte()

        Catch ex As Exception
            MsgBox("No se puede abrir el reporte")
        End Try

        Return True
    End Function

End Class