'------------------------------------------------------------------------------
' Clase clsClientes generada automáticamente con CrearClaseSQL
' de la tabla 'tblClientes' de la base 'data'
' Fecha: 22/jul/2012 19:45:50
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
Public Class clsClientes
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idCliente As System.Int16
    Private _nombre As System.String
    Private _nit As System.String
    Private _direccion As System.String
    Private _telefono As System.String
    Private _diasCredito As System.Int16
    Private _limiteCredito As System.Decimal
    Private _idTipoCliente As System.Int16
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
    Public Property idCliente() As System.Int16
        Get
            Return _idCliente
        End Get
        Set(ByVal value As System.Int16)
            _idCliente = value
        End Set
    End Property
    Public Property nombre() As System.String
        Get
            Return ajustarAncho(_nombre, 100)
        End Get
        Set(ByVal value As System.String)
            _nombre = value
        End Set
    End Property
    Public Property nit() As System.String
        Get
            Return ajustarAncho(_nit, 75)
        End Get
        Set(ByVal value As System.String)
            _nit = value
        End Set
    End Property
    Public Property direccion() As System.String
        Get
            Return ajustarAncho(_direccion, 100)
        End Get
        Set(ByVal value As System.String)
            _direccion = value
        End Set
    End Property
    Public Property telefono() As System.String
        Get
            Return ajustarAncho(_telefono, 50)
        End Get
        Set(ByVal value As System.String)
            _telefono = value
        End Set
    End Property
    Public Property diasCredito() As System.Int16
        Get
            Return _diasCredito
        End Get
        Set(ByVal value As System.Int16)
            _diasCredito = value
        End Set
    End Property
    Public Property limiteCredito() As System.Decimal
        Get
            Return _limiteCredito
        End Get
        Set(ByVal value As System.Decimal)
            _limiteCredito = value
        End Set
    End Property
    Public Property idTipoCliente() As System.Int16
        Get
            Return _idTipoCliente
        End Get
        Set(ByVal value As System.Int16)
            _idTipoCliente = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idCliente.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.nit.ToString()
            ElseIf index = 3 Then
                Return Me.direccion.ToString()
            ElseIf index = 4 Then
                Return Me.telefono.ToString()
            ElseIf index = 5 Then
                Return Me.diasCredito.ToString()
            ElseIf index = 6 Then
                Return Me.limiteCredito.ToString()
            ElseIf index = 7 Then
                Return Me.idTipoCliente.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idCliente = System.Int16.Parse("0" & value)
                Catch
                    Me.idCliente = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Me.nit = value
            ElseIf index = 3 Then
                Me.direccion = value
            ElseIf index = 4 Then
                Me.telefono = value
            ElseIf index = 5 Then
                Try
                    Me.diasCredito = System.Int16.Parse("0" & value)
                Catch
                    Me.diasCredito = System.Int16.Parse("0")
                End Try
            ElseIf index = 6 Then
                Try
                    Me.limiteCredito = System.Decimal.Parse("0" & value)
                Catch
                    Me.limiteCredito = System.Decimal.Parse("0")
                End Try
            ElseIf index = 7 Then
                Try
                    Me.idTipoCliente = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoCliente = System.Int16.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idCliente" Then
                Return Me.idCliente.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "nit" Then
                Return Me.nit.ToString()
            ElseIf index = "direccion" Then
                Return Me.direccion.ToString()
            ElseIf index = "telefono" Then
                Return Me.telefono.ToString()
            ElseIf index = "diasCredito" Then
                Return Me.diasCredito.ToString()
            ElseIf index = "limiteCredito" Then
                Return Me.limiteCredito.ToString()
            ElseIf index = "idTipoCliente" Then
                Return Me.idTipoCliente.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idCliente" Then
                Try
                    Me.idCliente = System.Int16.Parse("0" & value)
                Catch
                    Me.idCliente = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "nit" Then
                Me.nit = value
            ElseIf index = "direccion" Then
                Me.direccion = value
            ElseIf index = "telefono" Then
                Me.telefono = value
            ElseIf index = "diasCredito" Then
                Try
                    Me.diasCredito = System.Int16.Parse("0" & value)
                Catch
                    Me.diasCredito = System.Int16.Parse("0")
                End Try
            ElseIf index = "limiteCredito" Then
                Try
                    Me.limiteCredito = System.Decimal.Parse("0" & value)
                Catch
                    Me.limiteCredito = System.Decimal.Parse("0")
                End Try
            ElseIf index = "idTipoCliente" Then
                Try
                    Me.idTipoCliente = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoCliente = System.Int16.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblClientes"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsClientes
    Private Shared Function row2clsClientes(ByVal r As DataRow) As clsClientes
        ' asigna a un objeto clsClientes los datos del dataRow indicado
        Dim oclsClientes As New clsClientes
        '
        oclsClientes.idCliente = System.Int16.Parse("0" & r("idCliente").ToString())
        oclsClientes.nombre = r("nombre").ToString()
        oclsClientes.nit = r("nit").ToString()
        oclsClientes.direccion = r("direccion").ToString()
        oclsClientes.telefono = r("telefono").ToString()
        oclsClientes.diasCredito = System.Int16.Parse("0" & r("diasCredito").ToString())
        oclsClientes.limiteCredito = System.Decimal.Parse("0" & r("limiteCredito").ToString())
        oclsClientes.idTipoCliente = System.Int16.Parse("0" & r("idTipoCliente").ToString())
        '
        Return oclsClientes
    End Function
    '
    ' asigna un objeto clsClientes a la fila indicada
    Private Shared Sub clsClientes2Row(ByVal oclsClientes As clsClientes, ByVal r As DataRow)
        ' asigna un objeto clsClientes al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idCliente") = oclsClientes.idCliente
        r("nombre") = oclsClientes.nombre
        r("nit") = oclsClientes.nit
        r("direccion") = oclsClientes.direccion
        r("telefono") = oclsClientes.telefono
        r("diasCredito") = oclsClientes.diasCredito
        r("limiteCredito") = oclsClientes.limiteCredito
        r("idTipoCliente") = oclsClientes.idTipoCliente
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsClientes
    Private Shared Sub nuevoclsClientes(ByVal dt As DataTable, ByVal oclsClientes As clsClientes)
        ' Crear un nuevo clsClientes
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsClientes = row2clsClientes(dr)
        '
        oc.idCliente = oclsClientes.idCliente
        oc.nombre = oclsClientes.nombre
        oc.nit = oclsClientes.nit
        oc.direccion = oclsClientes.direccion
        oc.telefono = oclsClientes.telefono
        oc.diasCredito = oclsClientes.diasCredito
        oc.limiteCredito = oclsClientes.limiteCredito
        oc.idTipoCliente = oclsClientes.idTipoCliente
        '
        clsClientes2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblClientes
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsClientes")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsClientes
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsClientes As clsClientes = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsClientes")
        Dim sel As String = "SELECT * FROM tblClientes WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsClientes = row2clsClientes(dt.Rows(0))
        End If
        Return oclsClientes
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idCliente existe en la tabla.
    '             TODO: Si en lugar de idCliente usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCliente que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblClientes WHERE idCliente = " & Me.idCliente.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsClientes")
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
        '       Yo compruebo que sea un campo llamado idCliente, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idCliente) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblClientes SET nombre = @nombre, nit = @nit, direccion = @direccion, telefono = @telefono, diasCredito = @diasCredito, limiteCredito = @limiteCredito, idTipoCliente = @idTipoCliente  WHERE (idCliente = @idCliente)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idCliente", SqlDbType.SmallInt, 0, "idCliente")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 100, "nombre")
        da.UpdateCommand.Parameters.Add("@nit", SqlDbType.NVarChar, 75, "nit")
        da.UpdateCommand.Parameters.Add("@direccion", SqlDbType.NVarChar, 100, "direccion")
        da.UpdateCommand.Parameters.Add("@telefono", SqlDbType.NVarChar, 50, "telefono")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@diasCredito", SqlDbType.SmallInt, 0, "diasCredito")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@limiteCredito", SqlDbType.Decimal, 0, "limiteCredito")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoCliente", SqlDbType.SmallInt, 0, "idTipoCliente")
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
            clsClientes2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsClientes")
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
        '       Yo compruebo que sea un campo llamado idCliente, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblClientes (nombre, nit, direccion, telefono, diasCredito, limiteCredito, idTipoCliente)  VALUES(@nombre, @nit, @direccion, @telefono, @diasCredito, @limiteCredito, @idTipoCliente)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idCliente", SqlDbType.SmallInt, 0, "idCliente")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 100, "nombre")
        da.InsertCommand.Parameters.Add("@nit", SqlDbType.NVarChar, 75, "nit")
        da.InsertCommand.Parameters.Add("@direccion", SqlDbType.NVarChar, 100, "direccion")
        da.InsertCommand.Parameters.Add("@telefono", SqlDbType.NVarChar, 50, "telefono")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@diasCredito", SqlDbType.SmallInt, 0, "diasCredito")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@limiteCredito", SqlDbType.Decimal, 0, "limiteCredito")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoCliente", SqlDbType.SmallInt, 0, "idTipoCliente")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsClientes(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsClientes"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCliente que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblClientes WHERE idCliente = " & Me.idCliente.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsClientes")
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
        '       Yo compruebo que sea un campo llamado idCliente, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblClientes WHERE (idCliente = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idCliente")
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
