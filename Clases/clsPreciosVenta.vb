'------------------------------------------------------------------------------
' Clase clsPreciosVenta generada automáticamente con CrearClaseSQL
' de la tabla 'tblPreciosVenta' de la base 'data'
' Fecha: 25/jul/2012 21:31:33
'
' ©Guillermo 'guille' Som, 2004-2012
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class clsPreciosVenta
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idPrecioVenta As System.Int16
    Private _nombre As System.String
    Private _porcentual As System.Boolean
    Private _fijo As System.Boolean
    Private _fechaInicio As System.DateTime
    Private _fechaFin As System.DateTime
    Private _precio As System.Decimal
    Private _tipo As System.Int16
    Private _id As System.Int64
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
    Public Property idPrecioVenta() As System.Int16
        Get
            Return _idPrecioVenta
        End Get
        Set(ByVal value As System.Int16)
            _idPrecioVenta = value
        End Set
    End Property
    Public Property nombre() As System.String
        Get
            Return ajustarAncho(_nombre, 50)
        End Get
        Set(ByVal value As System.String)
            _nombre = value
        End Set
    End Property
    Public Property porcentual() As System.Boolean
        Get
            Return _porcentual
        End Get
        Set(ByVal value As System.Boolean)
            _porcentual = value
        End Set
    End Property
    Public Property fijo() As System.Boolean
        Get
            Return _fijo
        End Get
        Set(ByVal value As System.Boolean)
            _fijo = value
        End Set
    End Property
    Public Property fechaInicio() As System.DateTime
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As System.DateTime)
            _fechaInicio = value
        End Set
    End Property
    Public Property fechaFin() As System.DateTime
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As System.DateTime)
            _fechaFin = value
        End Set
    End Property
    Public Property precio() As System.Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As System.Decimal)
            _precio = value
        End Set
    End Property
    Public Property tipo() As System.Int16
        Get
            Return _tipo
        End Get
        Set(ByVal value As System.Int16)
            _tipo = value
        End Set
    End Property
    Public Property id() As System.Int64
        Get
            Return _id
        End Get
        Set(ByVal value As System.Int64)
            _id = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idPrecioVenta.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.porcentual.ToString()
            ElseIf index = 3 Then
                Return Me.fijo.ToString()
            ElseIf index = 4 Then
                Return Me.fechaInicio.ToString()
            ElseIf index = 5 Then
                Return Me.fechaFin.ToString()
            ElseIf index = 6 Then
                Return Me.precio.ToString()
            ElseIf index = 7 Then
                Return Me.tipo.ToString()
            ElseIf index = 8 Then
                Return Me.id.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idPrecioVenta = System.Int16.Parse("0" & value)
                Catch
                    Me.idPrecioVenta = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Try
                    Me.porcentual = System.Boolean.Parse(value)
                Catch
                    Me.porcentual = False
                End Try
            ElseIf index = 3 Then
                Try
                    Me.fijo = System.Boolean.Parse(value)
                Catch
                    Me.fijo = False
                End Try
            ElseIf index = 4 Then
                Try
                    Me.fechaInicio = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaInicio = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaInicio = System.DateTime.Now
                End Try
            ElseIf index = 5 Then
                Try
                    Me.fechaFin = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaFin = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaFin = System.DateTime.Now
                End Try
            ElseIf index = 6 Then
                Try
                    Me.precio = System.Decimal.Parse("0" & value)
                Catch
                    Me.precio = System.Decimal.Parse("0")
                End Try
            ElseIf index = 7 Then
                Try
                    Me.tipo = System.Int16.Parse("0" & value)
                Catch
                    Me.tipo = System.Int16.Parse("0")
                End Try
            ElseIf index = 8 Then
                Try
                    Me.id = System.Int64.Parse("0" & value)
                Catch
                    Me.id = System.Int64.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idPrecioVenta" Then
                Return Me.idPrecioVenta.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "porcentual" Then
                Return Me.porcentual.ToString()
            ElseIf index = "fijo" Then
                Return Me.fijo.ToString()
            ElseIf index = "fechaInicio" Then
                Return Me.fechaInicio.ToString()
            ElseIf index = "fechaFin" Then
                Return Me.fechaFin.ToString()
            ElseIf index = "precio" Then
                Return Me.precio.ToString()
            ElseIf index = "tipo" Then
                Return Me.tipo.ToString()
            ElseIf index = "id" Then
                Return Me.id.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idPrecioVenta" Then
                Try
                    Me.idPrecioVenta = System.Int16.Parse("0" & value)
                Catch
                    Me.idPrecioVenta = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "porcentual" Then
                Try
                    Me.porcentual = System.Boolean.Parse(value)
                Catch
                    Me.porcentual = False
                End Try
            ElseIf index = "fijo" Then
                Try
                    Me.fijo = System.Boolean.Parse(value)
                Catch
                    Me.fijo = False
                End Try
            ElseIf index = "fechaInicio" Then
                Try
                    Me.fechaInicio = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaInicio = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaInicio = System.DateTime.Now
                End Try
            ElseIf index = "fechaFin" Then
                Try
                    Me.fechaFin = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaFin = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaFin = System.DateTime.Now
                End Try
            ElseIf index = "precio" Then
                Try
                    Me.precio = System.Decimal.Parse("0" & value)
                Catch
                    Me.precio = System.Decimal.Parse("0")
                End Try
            ElseIf index = "tipo" Then
                Try
                    Me.tipo = System.Int16.Parse("0" & value)
                Catch
                    Me.tipo = System.Int16.Parse("0")
                End Try
            ElseIf index = "id" Then
                Try
                    Me.id = System.Int64.Parse("0" & value)
                Catch
                    Me.id = System.Int64.Parse("0")
                End Try
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn
    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblPreciosVenta"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsPreciosVenta
    Private Shared Function row2clsPreciosVenta(ByVal r As DataRow) As clsPreciosVenta
        ' asigna a un objeto clsPreciosVenta los datos del dataRow indicado
        Dim oclsPreciosVenta As New clsPreciosVenta
        '
        oclsPreciosVenta.idPrecioVenta = System.Int16.Parse("0" & r("idPrecioVenta").ToString())
        oclsPreciosVenta.nombre = r("nombre").ToString()
        Try
            oclsPreciosVenta.porcentual = System.Boolean.Parse(r("porcentual").ToString())
        Catch
            oclsPreciosVenta.porcentual = False
        End Try
        Try
            oclsPreciosVenta.fijo = System.Boolean.Parse(r("fijo").ToString())
        Catch
            oclsPreciosVenta.fijo = False
        End Try
        Try
            oclsPreciosVenta.fechaInicio = DateTime.Parse(r("fechaInicio").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsPreciosVenta.fechaInicio = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsPreciosVenta.fechaInicio = DateTime.Now
        End Try
        Try
            oclsPreciosVenta.fechaFin = DateTime.Parse(r("fechaFin").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsPreciosVenta.fechaFin = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsPreciosVenta.fechaFin = DateTime.Now
        End Try
        oclsPreciosVenta.precio = System.Decimal.Parse("0" & r("precio").ToString())
        oclsPreciosVenta.tipo = System.Int16.Parse("0" & r("tipo").ToString())
        oclsPreciosVenta.id = System.Int64.Parse("0" & r("id").ToString())
        '
        Return oclsPreciosVenta
    End Function
    '
    ' asigna un objeto clsPreciosVenta a la fila indicada
    Private Shared Sub clsPreciosVenta2Row(ByVal oclsPreciosVenta As clsPreciosVenta, ByVal r As DataRow)
        ' asigna un objeto clsPreciosVenta al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idPrecioVenta") = oclsPreciosVenta.idPrecioVenta
        r("nombre") = oclsPreciosVenta.nombre
        r("porcentual") = oclsPreciosVenta.porcentual
        r("fijo") = oclsPreciosVenta.fijo
        r("fechaInicio") = oclsPreciosVenta.fechaInicio
        r("fechaFin") = oclsPreciosVenta.fechaFin
        r("precio") = oclsPreciosVenta.precio
        r("tipo") = oclsPreciosVenta.tipo
        r("id") = oclsPreciosVenta.id
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsPreciosVenta
    Private Shared Sub nuevoclsPreciosVenta(ByVal dt As DataTable, ByVal oclsPreciosVenta As clsPreciosVenta)
        ' Crear un nuevo clsPreciosVenta
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsPreciosVenta = row2clsPreciosVenta(dr)
        '
        oc.idPrecioVenta = oclsPreciosVenta.idPrecioVenta
        oc.nombre = oclsPreciosVenta.nombre
        oc.porcentual = oclsPreciosVenta.porcentual
        oc.fijo = oclsPreciosVenta.fijo
        oc.fechaInicio = oclsPreciosVenta.fechaInicio
        oc.fechaFin = oclsPreciosVenta.fechaFin
        oc.precio = oclsPreciosVenta.precio
        oc.tipo = oclsPreciosVenta.tipo
        oc.id = oclsPreciosVenta.id
        '
        clsPreciosVenta2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblPreciosVenta
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosVenta")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsPreciosVenta
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsPreciosVenta As clsPreciosVenta = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosVenta")
        Dim sel As String = "SELECT * FROM tblPreciosVenta WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsPreciosVenta = row2clsPreciosVenta(dt.Rows(0))
        End If
        Return oclsPreciosVenta
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idPrecioVenta existe en la tabla.
    '             TODO: Si en lugar de idPrecioVenta usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idPrecioVenta que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblPreciosVenta WHERE idPrecioVenta = " & Me.idPrecioVenta.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosVenta")
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
        '       Yo compruebo que sea un campo llamado idPrecioVenta, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idPrecioVenta) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblPreciosVenta SET nombre = @nombre, porcentual = @porcentual, fijo = @fijo, fechaInicio = @fechaInicio, fechaFin = @fechaFin, precio = @precio, tipo = @tipo, id = @id  WHERE (idPrecioVenta = @idPrecioVenta)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idPrecioVenta", SqlDbType.SmallInt, 0, "idPrecioVenta")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@porcentual", SqlDbType.Bit, 0, "porcentual")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fijo", SqlDbType.Bit, 0, "fijo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fechaInicio", SqlDbType.DateTime, 0, "fechaInicio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fechaFin", SqlDbType.DateTime, 0, "fechaFin")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Decimal, 0, "precio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.SmallInt, 0, "tipo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@id", SqlDbType.BigInt, 0, "id")
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
            clsPreciosVenta2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsPreciosVenta")
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
        '       Yo compruebo que sea un campo llamado idPrecioVenta, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblPreciosVenta (nombre, porcentual, fijo, fechaInicio, fechaFin, precio, tipo, id)  VALUES(@nombre, @porcentual, @fijo, @fechaInicio, @fechaFin, @precio, @tipo, @id)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idPrecioVenta", SqlDbType.SmallInt, 0, "idPrecioVenta")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@porcentual", SqlDbType.Bit, 0, "porcentual")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fijo", SqlDbType.Bit, 0, "fijo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fechaInicio", SqlDbType.DateTime, 0, "fechaInicio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fechaFin", SqlDbType.DateTime, 0, "fechaFin")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@precio", SqlDbType.Decimal, 0, "precio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@tipo", SqlDbType.SmallInt, 0, "tipo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@id", SqlDbType.BigInt, 0, "id")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsPreciosVenta(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsPreciosVenta"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idPrecioVenta que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblPreciosVenta WHERE idPrecioVenta = " & Me.idPrecioVenta.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosVenta")
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
        '       Yo compruebo que sea un campo llamado idPrecioVenta, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblPreciosVenta WHERE (idPrecioVenta = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idPrecioVenta")
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
