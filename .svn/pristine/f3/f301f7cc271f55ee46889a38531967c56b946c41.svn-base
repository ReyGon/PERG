Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsDevuelveTabla

    Private _sqlString As String
    'Private _Transaccion As System.Data.IDbTransaction

    'Variables de transaccion.
    Public Transaccion As System.Data.IDbTransaction
    Public SqlConexion As New System.Data.SqlClient.SqlConnection
    Public SqlComando As System.Data.SqlClient.SqlCommand
    Public xx As String

    'Public Property Transaccion() As System.Data.IDbTransaction
    '    Get
    '        Transaccion = _Transaccion
    '    End Get
    '    Set(ByVal value As System.Data.IDbTransaction)

    '    End Set
    'End Property

    Public Property sqlString() As String
        Get
            sqlString = _sqlString
        End Get
        Set(ByVal value As String)
            _sqlString = value
        End Set
    End Property


    Public Function Tabla() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim adp As New System.Data.SqlClient.SqlDataAdapter(Me.sqlString, mdlPublicVars.cnn)
        adp.Fill(dt)
        adp.Dispose()
        adp = Nothing
        Return dt
    End Function


    Public Function tablaSP(ByVal spNombre As String) As System.Data.DataTable


        Dim cnString As String
        Dim cn As New SqlClient.SqlConnection
        Dim adp As New SqlClient.SqlDataAdapter
        'Dim adp1 As New SqlClient.SqlDataAdapter
        Dim dt As New DataTable

        cnString = mdlPublicVars.cnn
        'Abrimos la conexion hacia nuestra BD


        cn.ConnectionString = cnString
        cn.Open()


        'Llenamos nuestra data Table con la informacion devuelta por storeProcedure
        adp.SelectCommand = New SqlClient.SqlCommand(spNombre, cn)
        adp.SelectCommand.CommandTimeout = 100000
        adp.Fill(dt)

        adp.Dispose()
        adp = Nothing
        cn.Close()
        cn.Dispose()
        cn = Nothing
        Return dt


    End Function

    Public Function ejecutaSQL() As Int16
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Try
            cnn.ConnectionString = mdlPublicVars.cnn
            cnn.Open()
            Dim cm As New System.Data.SqlClient.SqlCommand(Me.sqlString, cnn)
            Return cm.ExecuteNonQuery
            cnn.Close()
            cm = Nothing
            cnn = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!!")
        End Try
    End Function



    '--------------------------------------------------MIS FUNCIONES.  JORGE SANTOS................

    'ejecuta la consulta devolviendo un dato de retorno como codmax.
    't.consulta=""
    't.devuelveUnValor()
    Public Function DevuelveUnValor() As String
        Try
            Dim tbl As DataTable = Tabla()
            If tbl.Rows.Count > 0 Then
                Return tbl.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            Return "0"
        End Try

        Return "0"
    End Function

    Public Function DevuelveUnValorXY(ByVal fila As Integer, ByVal columna As Integer) As String
        Try
            Dim tbl As DataTable = Tabla()
            If tbl.Rows.Count > 0 Then
                Return tbl.Rows(fila).Item(columna).ToString
            End If
        Catch ex As Exception
            Return "0"
        End Try

        Return "0"
    End Function


    'se ejecuta una consulta por medio de una transaccion previamente inicializada,
    'devulve como resultado un dataTable


    Public Function FnEjecutarConsultaDevuelteTabla(ByVal consulta As String)
        Dim r As SqlClient.SqlDataReader
        Dim dt As New DataTable

        Try
            SqlComando = New System.Data.SqlClient.SqlCommand(consulta, SqlConexion)
            SqlComando.Transaction = Transaccion
            r = SqlComando.ExecuteReader()

            'agregar columnas a la tabla.
            For index As Integer = 0 To r.FieldCount - 1
                dt.Columns.Add(index.ToString)
            Next
            Dim filas As Integer = 0
            'agregar datos a la tabla
            While r.Read()
                dt.Rows.Add()
                For index As Integer = 0 To r.FieldCount - 1
                    dt.Rows(filas).Item(index) = r.Item(index)
                Next
                filas = filas + 1
            End While
            r.Close()

        Catch ex As Exception
            Transaccion.Rollback()
            SqlConexion.Close()
        End Try

        Return dt
    End Function

    'ejecuta un sp pero del cual solo obtenemos una fila y queremos leer el valor de la columna x y la fila x.
    Public Function fnEjecutaSPDevulveUnValor(ByVal sp As String, ByVal fila As Integer, ByVal col As Integer)
        Dim tbl As DataTable = tablaSP(sp)

        Try
            Return tbl.Rows(fila).Item(col).ToString
        Catch ex As Exception
            Return "0"
        End Try

        Return 0
    End Function

    Public Function FnDevulveDato(ByVal consulta As String) As String
        Dim r As SqlClient.SqlDataReader
        Dim devolver As String = "0"
        Try
            SqlComando = New System.Data.SqlClient.SqlCommand(consulta, SqlConexion)
            SqlComando.Transaction = Transaccion
            r = SqlComando.ExecuteReader()
            While r.Read()
                devolver = r(0).ToString
            End While
            r.Close()
        Catch ex As Exception
            Transaccion.Rollback()
            SqlConexion.Close()
            MsgBox("Error, no se puedo guardar el documento. DEVUELVE DATO " + ex.ToString)
        End Try


        Return devolver
    End Function

    'ejecuta un procedimeinto por medio de transaccione previamente habierta, como la funcion fnEjecutaConsulta

    Public Function FnEjecutarSP(ByVal sp As String)

        Dim adp As New SqlClient.SqlDataAdapter
        Dim dt As New DataTable

        Try
            'Llenamos nuestra data Table con la informacion devuelta por storeProcedure
            SqlComando = New SqlClient.SqlCommand(sp, SqlConexion)
            SqlComando.Transaction = Transaccion
            SqlComando.CommandTimeout = 100000
            adp.SelectCommand = SqlComando
            adp.Fill(dt)
        Catch ex As Exception
            Transaccion.Rollback()
            SqlConexion.Close()
            MsgBox("Error !!! " + ex.ToString)
        End Try

        adp.Dispose()
        adp = Nothing
        Return dt

    End Function

    Public Function FnEjecutarConsulta(ByVal consulta As String)
        Try
            SqlComando = New System.Data.SqlClient.SqlCommand(consulta, SqlConexion)
            SqlComando.Transaction = Transaccion
            SqlComando.ExecuteNonQuery()
        Catch ex As Exception
            Transaccion.Rollback()
            SqlConexion.Close()

            MsgBox("Error !!!")
            Return False
        End Try


        Return True
    End Function


    Public Function FnEjecutarConsultaConTransaccion(ByVal consulta As String)
        Dim errores As Boolean = False

        '2do Establecer la cadena de conecion y abrir la conexion
        SqlConexion.ConnectionString = mdlPublicVars.cnn
        SqlConexion.Open()

        '3ro. Iniciar la transaccion.
        Transaccion = SqlConexion.BeginTransaction


        Try
            SqlComando = New System.Data.SqlClient.SqlCommand(consulta, SqlConexion)
            SqlComando.Transaction = Transaccion
            SqlComando.ExecuteNonQuery()
        Catch ex As Exception
            Transaccion.Rollback()
            SqlConexion.Close()
            errores = True
            MsgBox("Error !!! " + ex.ToString)
        End Try

        If errores = False Then
            Transaccion.Commit()
            SqlConexion.Close()
            Return False
        End If

        'retorna true si la transaccion se completo con exito
        Return True
    End Function

  
    Public Function fnHoraActual_lb(ByVal lb As Label)
        lb.Text = Format(Now, "hh:mm tt").ToString
        Return 0
    End Function
    Public Function fnFechaActual_lb(ByVal lb As Label)
        lb.Text = Format(Now, "dd/MM/yyyy").ToString
        Return 0
    End Function

    Public Function fnQuitarPuntodeFecha(ByVal fecha As String)

        Dim vector() As String
        vector = Split(fecha, ".")
        Dim retorno As String = ""

        For index As Integer = 0 To vector.Length - 1
            retorno = RTrim(LTrim(retorno)) + RTrim(LTrim(vector(index))).ToString
        Next

        Return retorno
    End Function


    Public Function fnSepararCadena(ByVal cadena As String, ByVal separador As String) As Hashtable
        Dim vector() As String
        vector = Split(cadena, separador)
        Dim has As New Hashtable
        Dim contador As Integer = 0

        For index As Integer = 0 To vector.Length - 1
            has.Add(index + 1, vector(index).ToString)
        Next
        Return has
    End Function

    '-----------funciones para realizar insert
    Public Function fnNullBoolean(ByVal valor As Boolean)
        If valor = True Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Public Function fnNullCombo(ByVal texto, ByVal codigo) As String
        If IsNumeric(codigo) Then
        Else
            Return "Null"
        End If

        If codigo = 0 Then
            Return "Null"
        ElseIf texto.ToString.Length = 0 Then
            Return "Null"
        End If

        Return "'" + codigo.ToString + "'"
    End Function

    Public Function fnNullFechas(ByVal fecha As String)
        If fecha.Length < 4 Then
            Return "Null"
        Else
            Return "'" + fecha.ToString + "'"
        End If

    End Function

    Public Function fnNullString(ByVal texto As String)
        If texto.Length = 0 Or texto.Equals("0") Then
            Return "Null"
        Else
            Return "'" + texto + "'"
        End If
    End Function

    Public Function fnNullChk(ByVal valor As Boolean)
        If valor = True Then
            Return "1".ToString
        Else
            Return "0".ToString
        End If

    End Function

    Public Function fnNullNumero(ByVal valor As Double)
        If valor = 0 Then
            Return "0"
        ElseIf IsNumeric(valor) Then
            Return Format(valor, "########.##")
        Else
            Return "0"
        End If
    End Function


    ' lenar un combo con solo una linea.
    Public Function llenarCombo(ByVal codigo As String, ByVal campo As String, ByVal tabla As String, ByVal combo As System.Windows.Forms.ComboBox)
        Dim consulta As String
        Dim tbl As New clsDevuelveTabla
        consulta = " Select " + codigo + " codigo," + campo + " nombre from " + tabla + " "
        tbl.sqlString = consulta
        combo.DataSource = tbl.Tabla
        combo.ValueMember = "codigo"
        combo.DisplayMember = "nombre"
        Return True
    End Function

    ' tipo de control para el frm base
    Public Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function



    'pinta a un label resultado deacuerdo a un valor y un formato
    Public Function fnFormatoLabel(ByVal lb As Label, ByVal valor As Double, ByVal formato As String)
        If IsNumeric(valor) Then
            Dim resultado As String = Format(valor, formato)
            If resultado.Length > 0 Then
                lb.Text = resultado.ToString
            Else
                lb.Text = "0"
            End If
        Else
            lb.Text = "0"
        End If

        Return True
    End Function

    Public Function fnFormato(ByVal valor As Double, ByVal formato As String)
        If IsNumeric(valor) Then

            Dim resultado As String = Format(valor, formato)

            If resultado.Length > 0 Then
                Return resultado.ToString
            Else
                Return "0"
            End If
        Else
            Return "0"
        End If

        Return "0"
    End Function

    Public Function fnFormatoMoneda(ByVal valor As Double)
        If IsNumeric(valor) Then

            Dim resultado As String = Format(valor, "###,###.##")

            If resultado.Length > 0 Then
                Return resultado.ToString
            Else
                Return "0"
            End If
        Else
            Return "0"
        End If

        Return "0"
    End Function

    Public Function fnFormatoNumero(ByVal valor As String)
        If IsNumeric(valor) Then

            Dim resultado As String = Format(CType(valor, Double), "######.##")

            If resultado.Length > 0 Then
                Return resultado.ToString
            Else
                Return "0"
            End If
        Else
            Return "0"
        End If

        Return "0"
    End Function

    Public Function fnGuardarTipoCambio(ByVal tabla As DataTable)
        Dim errores As Boolean = False

        '2do Establecer la cadena de conecion y abrir la conexion
        SqlConexion.ConnectionString = mdlPublicVars.cnn
        SqlConexion.Open()

        '3ro. Iniciar la transaccion.
        Transaccion = SqlConexion.BeginTransaction

        Try
            Dim consulta As String

            For index As Integer = 0 To tabla.Rows.Count - 1
                'fecha de registro.
                Dim fecha As String = Format(tabla.Rows(index).Item(1), "dd/MM/yyyy").ToString

                'insertar el tipo de cambio en la tabla cambio.
                consulta = " insert into cambio (fecha,tipocambio,coduser) values ('" + Format(tabla.Rows(index).Item(1), "dd/MM/yyyy").ToString + " 00:00:00" + "','" + tabla.Rows(index).Item(2).ToString + "','" + mdlPublicVars.idUsuario.ToString + "')"
                FnEjecutarConsulta(consulta)

                'consultar el ultimo codigo de tipo de cambio
                Dim codigoCambio As String = FnDevulveDato("select max(codcamb) from cambio")

                'Actualizar el codigo de las entregas deacuerdo a la fecha.
                consulta = "update entrega set codcamb=" + codigoCambio.ToString + " where convert(varchar(50),fechaRegistro,103)='" + fecha.ToString + "'"
                FnEjecutarConsulta(consulta)

            Next


        Catch ex As Exception
            errores = True
        End Try


        If errores = False Then
            Transaccion.Commit()
            SqlConexion.Close()
            Return True
        Else
            Return False
        End If


        Return True
    End Function


    'Llenar el grid deacuerdo a una tabla, esto para data grid view con formato establecido y no usando data source
    Public Function fnLLenarGrid(ByVal grd As DataGridView, ByVal tabla As DataTable)
        grd.Rows.Clear()

        Dim columnas As Integer = tabla.Columns.Count - 1

        For index As Integer = 0 To tabla.Rows.Count - 1
            Dim vector As New Hashtable()
            Dim cadena(columnas) As String

            For col As Integer = 0 To tabla.Columns.Count - 1
                vector.Add(col, tabla.Rows(index).Item(col))
                cadena(col) = (tabla.Rows(index).Item(col).ToString)
            Next
            grd.Rows.Add(cadena)
        Next



        Return True

    End Function

    Public Function fnLLenarGridTelerik(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal tabla As DataTable)
        grd.Rows.Clear()

        Dim columnas As Integer = tabla.Columns.Count - 1

        For index As Integer = 0 To tabla.Rows.Count - 1
            Dim vector As New Hashtable()
            Dim cadena(columnas) As String

            For col As Integer = 0 To tabla.Columns.Count - 1
                vector.Add(col, tabla.Rows(index).Item(col))
                cadena(col) = (tabla.Rows(index).Item(col).ToString)
            Next
            grd.Rows.Add(cadena)
        Next



        Return True

    End Function

    Public Function fnOcultarCodigos(ByVal grd As DataGridView)
        Dim columna As String
        For index As Integer = 0 To grd.Columns.Count - 1
            columna = grd.Columns(index).Name.ToString
            If columna.Length > 2 Then
                If tipoControl(columna) = "cod" Then
                    grd.Columns(index).Visible = False
                End If
            End If
        Next


        Return 0
    End Function

    Public Function fnOcultarCodigosTelerik(ByVal grd As Telerik.WinControls.UI.RadGridView)

        Dim columna As String
        For index As Integer = 0 To grd.Columns.Count - 1
            columna = grd.Columns(index).Name.ToString
            If columna.Length > 2 Then
                If tipoControl(columna) = "cod" Then
                    grd.Columns(index).IsVisible = False
                End If
            End If
        Next


        Return 0
    End Function


    '' extrae de un grid la columna x llmada "columna" esta seleccionada en otra columna llamada colEstado esta activada.
    Public Function fnExtraerCadenaCodigosGridView(ByVal grd As DataGridView, ByVal columna As Integer, ByVal colEstado As Integer) As String
        'entrada: el grid y columna donde esta el codigo que se desea leer.


        '1ro. extraer los codigos de producto.
        Dim codigo As String = ""
        Dim codigoCount As Integer = 0

        For index As Integer = 0 To grd.Rows.Count - 1

            'si el producto es true, agregarlo al string.
            If grd.Item(colEstado, index).Value = True Then
                codigoCount = codigoCount + 1

                If codigoCount = 1 Then
                    codigo = grd.Item(columna, index).Value.ToString
                End If
                If codigoCount > 1 Then
                    codigo = codigo + "," + grd.Item(columna, index).Value.ToString
                End If
            End If

        Next
        If codigo.Length = 0 Then
            Return "0"
        End If

        Return codigo
    End Function

    Public Function fnExtraerCadenaCodigosGridViewTelerik(ByVal grd As Telerik.WinControls.UI.RadGridView, ByVal columna As Integer, ByVal colEstado As Integer) As String
        'entrada: el grid y columna donde esta el codigo que se desea leer
        '1ro. extraer los codigos de producto.
        Dim codigo As String = ""
        Dim codigoCount As Integer = 0

        For index As Integer = 0 To grd.Rows.Count - 1

            'si el producto es true, agregarlo al string.
            If grd.Rows(index).Cells(colEstado).Value = True Then

                codigoCount = codigoCount + 1

                If codigoCount = 1 Then
                    codigo = grd.Rows(index).Cells(columna).Value.ToString
                End If
                If codigoCount > 1 Then
                    codigo = codigo + "," + grd.Rows(index).Cells(columna).Value.ToString
                End If
            End If

        Next
        If codigo.Length = 0 Then
            Return "0"
        End If

        Return codigo
    End Function

    Public Function fnConvertir_grid_A_tabla(ByVal grd As DataGridView) As DataTable
        Dim tabla As New DataTable
        'Agregar Columnas.
        For index As Integer = 0 To grd.Columns.Count - 1
            tabla.Columns.Add(grd.Columns(index).Name.ToString)
        Next

        'Agregar Filas
        For fil As Integer = 0 To grd.Rows.Count - 1
            tabla.Rows.Add()
            For col As Integer = 0 To grd.Columns.Count - 1
                tabla.Rows(fil).Item(col) = grd.Rows(fil).Cells(col).Value
            Next
        Next

        Return tabla
    End Function

    Public Function fnConvertir_gridTelerik_A_tabla(ByVal grd As Telerik.WinControls.UI.RadGridView) As DataTable
        Dim tabla As New DataTable
        'Agregar Columnas.
        For index As Integer = 0 To grd.Columns.Count - 1
            tabla.Columns.Add(grd.Columns(index).Name.ToString)
        Next

        'Agregar Filas
        For fil As Integer = 0 To grd.Rows.Count - 1
            tabla.Rows.Add()
            For col As Integer = 0 To grd.Columns.Count - 1
                tabla.Rows(fil).Item(col) = grd.Rows(fil).Cells(col).Value
            Next
        Next

        Return tabla
    End Function
End Class
