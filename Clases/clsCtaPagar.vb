'------------------------------------------------------------------------------
' Clase clsCtaPagar generada automáticamente con CrearClaseSQL
' de la tabla 'tblCtaPagar' de la base 'laFuente'
' Fecha: 15/may/2008 09:45:45
'
' ©Guillermo 'guille' Som, 2004-2008
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class clsCtaPagar
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idCtaPagar As System.Int32
    Private _fecha As System.DateTime
    Private _idProveedor As System.Int16
    Private _idEntrada As System.Int32
    Private _monto As System.Decimal
    Private _cancelada As System.Boolean
    Private _idUsuario As System.Int16
    Private _pagado As System.Decimal
    Private _saldo As System.Decimal
    Private _observacion As System.String
    '
    ' Este método se usará para ajustar los anchos de las propiedades
    Private Function ajustarAncho(ByVal cadena As String, ByVal ancho As Integer) As String
        Dim sb As New System.Text.StringBuilder(New String(" "c, ancho))
        ' devolver la cadena quitando los espacios en blanco
        ' esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        Return (cadena & sb.ToString()).Substring(0, ancho).Trim()
    End Function
    '
    ' Las propiedades públicas
    ' TODO: Revisar los tipos de las propiedades
    Public Property idCtaPagar() As System.Int32
        Get
            Return _idCtaPagar
        End Get
        Set(ByVal value As System.Int32)
            _idCtaPagar = value
        End Set
    End Property
    Public Property fecha() As System.DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As System.DateTime)
            _fecha = value
        End Set
    End Property
    Public Property idProveedor() As System.Int16
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As System.Int16)
            _idProveedor = value
        End Set
    End Property
    Public Property idEntrada() As System.Int32
        Get
            Return _idEntrada
        End Get
        Set(ByVal value As System.Int32)
            _idEntrada = value
        End Set
    End Property
    Public Property monto() As System.Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As System.Decimal)
            _monto = value
        End Set
    End Property
    Public Property cancelada() As System.Boolean
        Get
            Return _cancelada
        End Get
        Set(ByVal value As System.Boolean)
            _cancelada = value
        End Set
    End Property
    Public Property idUsuario() As System.Int16
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As System.Int16)
            _idUsuario = value
        End Set
    End Property
    Public Property pagado() As System.Decimal
        Get
            Return _pagado
        End Get
        Set(ByVal value As System.Decimal)
            _pagado = value
        End Set
    End Property
    Public Property saldo() As System.Decimal
        Get
            Return _saldo
        End Get
        Set(ByVal value As System.Decimal)
            _saldo = value
        End Set
    End Property
    Public Property observacion() As System.String
        Get
            Return ajustarAncho(_observacion, 100)
        End Get
        Set(ByVal value As System.String)
            _observacion = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idCtaPagar.ToString()
            ElseIf index = 1 Then
                Return Me.fecha.ToString()
            ElseIf index = 2 Then
                Return Me.idProveedor.ToString()
            ElseIf index = 3 Then
                Return Me.idEntrada.ToString()
            ElseIf index = 4 Then
                Return Me.monto.ToString()
            ElseIf index = 5 Then
                Return Me.cancelada.ToString()
            ElseIf index = 6 Then
                Return Me.idUsuario.ToString()
            ElseIf index = 7 Then
                Return Me.pagado.ToString()
            ElseIf index = 8 Then
                Return Me.saldo.ToString()
            ElseIf index = 9 Then
                Return Me.observacion.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idCtaPagar = System.Int32.Parse("0" & value)
                Catch
                    Me.idCtaPagar = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.fecha = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fecha = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fecha = System.DateTime.Now
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idProveedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idProveedor = System.Int16.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.idEntrada = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntrada = System.Int32.Parse("0")
                End Try
            ElseIf index = 4 Then
                Try
                    Me.monto = System.Decimal.Parse("0" & value)
                Catch
                    Me.monto = System.Decimal.Parse("0")
                End Try
            ElseIf index = 5 Then
                Try
                    Me.cancelada = System.Boolean.Parse(value)
                Catch
                    Me.cancelada = False
                End Try
            ElseIf index = 6 Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = 7 Then
                Try
                    Me.pagado = System.Decimal.Parse("0" & value)
                Catch
                    Me.pagado = System.Decimal.Parse("0")
                End Try
            ElseIf index = 8 Then
                Try
                    Me.saldo = System.Decimal.Parse("0" & value)
                Catch
                    Me.saldo = System.Decimal.Parse("0")
                End Try
            ElseIf index = 9 Then
                Me.observacion = value
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idCtaPagar" Then
                Return Me.idCtaPagar.ToString()
            ElseIf index = "fecha" Then
                Return Me.fecha.ToString()
            ElseIf index = "idProveedor" Then
                Return Me.idProveedor.ToString()
            ElseIf index = "idEntrada" Then
                Return Me.idEntrada.ToString()
            ElseIf index = "monto" Then
                Return Me.monto.ToString()
            ElseIf index = "cancelada" Then
                Return Me.cancelada.ToString()
            ElseIf index = "idUsuario" Then
                Return Me.idUsuario.ToString()
            ElseIf index = "pagado" Then
                Return Me.pagado.ToString()
            ElseIf index = "saldo" Then
                Return Me.saldo.ToString()
            ElseIf index = "observacion" Then
                Return Me.observacion.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idCtaPagar" Then
                Try
                    Me.idCtaPagar = System.Int32.Parse("0" & value)
                Catch
                    Me.idCtaPagar = System.Int32.Parse("0")
                End Try
            ElseIf index = "fecha" Then
                Try
                    Me.fecha = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fecha = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fecha = System.DateTime.Now
                End Try
            ElseIf index = "idProveedor" Then
                Try
                    Me.idProveedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idProveedor = System.Int16.Parse("0")
                End Try
            ElseIf index = "idEntrada" Then
                Try
                    Me.idEntrada = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntrada = System.Int32.Parse("0")
                End Try
            ElseIf index = "monto" Then
                Try
                    Me.monto = System.Decimal.Parse("0" & value)
                Catch
                    Me.monto = System.Decimal.Parse("0")
                End Try
            ElseIf index = "cancelada" Then
                Try
                    Me.cancelada = System.Boolean.Parse(value)
                Catch
                    Me.cancelada = False
                End Try
            ElseIf index = "idUsuario" Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = "pagado" Then
                Try
                    Me.pagado = System.Decimal.Parse("0" & value)
                Catch
                    Me.pagado = System.Decimal.Parse("0")
                End Try
            ElseIf index = "saldo" Then
                Try
                    Me.saldo = System.Decimal.Parse("0" & value)
                Catch
                    Me.saldo = System.Decimal.Parse("0")
                End Try
            ElseIf index = "observacion" Then
                Me.observacion = value
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn
    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblCtaPagar"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsCtaPagar
    Private Shared Function row2clsCtaPagar(ByVal r As DataRow) As clsCtaPagar
        ' asigna a un objeto clsCtaPagar los datos del dataRow indicado
        Dim oclsCtaPagar As New clsCtaPagar
        '
        oclsCtaPagar.idCtaPagar = System.Int32.Parse("0" & r("idCtaPagar").ToString())
        Try
            oclsCtaPagar.fecha = DateTime.Parse(r("fecha").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsCtaPagar.fecha = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsCtaPagar.fecha = DateTime.Now
        End Try
        oclsCtaPagar.idProveedor = System.Int16.Parse("0" & r("idProveedor").ToString())
        oclsCtaPagar.idEntrada = System.Int32.Parse("0" & r("idEntrada").ToString())
        oclsCtaPagar.monto = System.Decimal.Parse("0" & r("monto").ToString())
        Try
            oclsCtaPagar.cancelada = System.Boolean.Parse(r("cancelada").ToString())
        Catch
            oclsCtaPagar.cancelada = False
        End Try
        oclsCtaPagar.idUsuario = System.Int16.Parse("0" & r("idUsuario").ToString())
        oclsCtaPagar.pagado = System.Decimal.Parse("0" & r("pagado").ToString())
        oclsCtaPagar.saldo = System.Decimal.Parse("0" & r("saldo").ToString())
        oclsCtaPagar.observacion = r("observacion").ToString()
        '
        Return oclsCtaPagar
    End Function
    '
    ' asigna un objeto clsCtaPagar a la fila indicada
    Private Shared Sub clsCtaPagar2Row(ByVal oclsCtaPagar As clsCtaPagar, ByVal r As DataRow)
        ' asigna un objeto clsCtaPagar al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idCtaPagar") = oclsCtaPagar.idCtaPagar
        r("fecha") = oclsCtaPagar.fecha
        r("idProveedor") = oclsCtaPagar.idProveedor
        r("idEntrada") = oclsCtaPagar.idEntrada
        r("monto") = oclsCtaPagar.monto
        r("cancelada") = oclsCtaPagar.cancelada
        r("idUsuario") = oclsCtaPagar.idUsuario
        r("pagado") = oclsCtaPagar.pagado
        r("saldo") = oclsCtaPagar.saldo
        r("observacion") = oclsCtaPagar.observacion
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsCtaPagar
    Private Shared Sub nuevoclsCtaPagar(ByVal dt As DataTable, ByVal oclsCtaPagar As clsCtaPagar)
        ' Crear un nuevo clsCtaPagar
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsCtaPagar = row2clsCtaPagar(dr)
        '
        oc.idCtaPagar = oclsCtaPagar.idCtaPagar
        oc.fecha = oclsCtaPagar.fecha
        oc.idProveedor = oclsCtaPagar.idProveedor
        oc.idEntrada = oclsCtaPagar.idEntrada
        oc.monto = oclsCtaPagar.monto
        oc.cancelada = oclsCtaPagar.cancelada
        oc.idUsuario = oclsCtaPagar.idUsuario
        oc.pagado = oclsCtaPagar.pagado
        oc.saldo = oclsCtaPagar.saldo
        oc.observacion = oclsCtaPagar.observacion
        '
        clsCtaPagar2Row(oc, dr)
        '
        dt.Rows.Add(dr)
    End Sub
    '
    ' Métodos públicos
    '
    ' devuelve una tabla con los datos indicados en la cadena de selección
    Public Shared Function Tabla() As DataTable
        Return Tabla(CadenaSelect)
    End Function
    Public Shared Function Tabla(ByVal sel As String) As DataTable
        ' devuelve una tabla con los datos de la tabla tblCtaPagar
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCtaPagar")
        '
        Try
            da = New SqlDataAdapter(sel, cadenaConexion)
            da.Fill(dt)
        Catch
            Return Nothing
        End Try
        '
        Return dt
    End Function
    '
    Public Shared Function Buscar(ByVal sWhere As String) As clsCtaPagar
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsCtaPagar As clsCtaPagar = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCtaPagar")
        Dim sel As String = "SELECT * FROM tblCtaPagar WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsCtaPagar = row2clsCtaPagar(dt.Rows(0))
        End If
        Return oclsCtaPagar
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idCtaPagar existe en la tabla.
    '             TODO: Si en lugar de idCtaPagar usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCtaPagar que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblCtaPagar WHERE idCtaPagar = " & Me.idCtaPagar.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCtaPagar")
        '
        cnn = New SqlConnection(cadenaConexion)
        'da = New SqlDataAdapter(CadenaSelect, cnn)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la más óptima, pero funcionará
        '-------------------------------------------
        'Dim cb As New SqlCommandBuilder(da)
        'da.UpdateCommand = cb.GetUpdateCommand()
        '
        '--------------------------------------------------------------------
        ' Esta está más optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        Dim sCommand As String
        '
        ' El comando UPDATE
        ' TODO: Comprobar cual es el campo de índice principal (sin duplicados)
        '       Yo compruebo que sea un campo llamado idCtaPagar, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idCtaPagar) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblCtaPagar SET fecha = @fecha, idProveedor = @idProveedor, idEntrada = @idEntrada, monto = @monto, cancelada = @cancelada, idUsuario = @idUsuario, pagado = @pagado, saldo = @saldo, observacion = @observacion  WHERE (idCtaPagar = @idCtaPagar)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idCtaPagar", SqlDbType.Int, 0, "idCtaPagar")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 0, "fecha")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idProveedor", SqlDbType.SmallInt, 0, "idProveedor")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEntrada", SqlDbType.Int, 0, "idEntrada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@monto", SqlDbType.Decimal, 0, "monto")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@cancelada", SqlDbType.Bit, 0, "cancelada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@pagado", SqlDbType.Decimal, 0, "pagado")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@saldo", SqlDbType.Decimal, 0, "saldo")
        da.UpdateCommand.Parameters.Add("@observacion", SqlDbType.NVarChar, 100, "observacion")
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        If dt.Rows.Count = 0 Then
            ' crear uno nuevo
            Return Crear()
        Else
            clsCtaPagar2Row(Me, dt.Rows(0))
        End If
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Actualizado correctamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Crear() As String
        ' Crear un nuevo registro
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCtaPagar")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(CadenaSelect, cnn)
        'da = New SqlDataAdapter(CadenaSelect, cadenaConexion)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la más óptima, pero funcionará
        '-------------------------------------------
        'Dim cb As New SqlCommandBuilder(da)
        'da.InsertCommand = cb.GetInsertCommand()
        '
        '--------------------------------------------------------------------
        ' Esta está más optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        Dim sCommand As String
        '
        ' El comando INSERT
        ' TODO: No incluir el campo de clave primaria incremental
        '       Yo compruebo que sea un campo llamado idCtaPagar, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblCtaPagar (fecha, idProveedor, idEntrada, monto, cancelada, idUsuario, pagado, saldo, observacion)  VALUES(@fecha, @idProveedor, @idEntrada, @monto, @cancelada, @idUsuario, @pagado, @saldo, @observacion)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idCtaPagar", SqlDbType.Int, 0, "idCtaPagar")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 0, "fecha")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idProveedor", SqlDbType.SmallInt, 0, "idProveedor")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEntrada", SqlDbType.Int, 0, "idEntrada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@monto", SqlDbType.Decimal, 0, "monto")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@cancelada", SqlDbType.Bit, 0, "cancelada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@pagado", SqlDbType.Decimal, 0, "pagado")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@saldo", SqlDbType.Decimal, 0, "saldo")
        da.InsertCommand.Parameters.Add("@observacion", SqlDbType.NVarChar, 100, "observacion")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsCtaPagar(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsCtaPagar"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCtaPagar que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblCtaPagar WHERE idCtaPagar = " & Me.idCtaPagar.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCtaPagar")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la más óptima, pero funcionará
        '-------------------------------------------
        'Dim cb As New SqlCommandBuilder(da)
        'da.DeleteCommand = cb.GetDeleteCommand()
        '
        '
        '--------------------------------------------------------------------
        ' Esta está más optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        Dim sCommand As String
        '
        ' El comando DELETE
        ' TODO: Sólo incluir el campo de clave primaria incremental
        '       Yo compruebo que sea un campo llamado idCtaPagar, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblCtaPagar WHERE (idCtaPagar = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idCtaPagar")
        'da.DeleteCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "")
        '
        '
        da.Fill(dt)
        '
        If dt.Rows.Count = 0 Then
            Return "ERROR: No hay datos"
        Else
            dt.Rows(0).Delete()
        End If
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Borrado satisfactoriamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
End Class
