'------------------------------------------------------------------------------
' Clase clsEmpresa generada automáticamente con CrearClaseSQL
' de la tabla 'tblEmpresa' de la base 'laFuente'
' Fecha: 02/abr/2008 14:15:58
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
Public Class clsEmpresa
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idEmpresa As System.Int16
    Private _nombre As System.String
    Private _direccion As System.String
    Private _telefono As System.String
    Private _habilitada As System.Boolean
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
    Public Property idEmpresa() As System.Int16
        Get
            Return _idEmpresa
        End Get
        Set(ByVal value As System.Int16)
            _idEmpresa = value
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
    Public Property direccion() As System.String
        Get
            Return ajustarAncho(_direccion, 50)
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
    Public Property habilitada() As System.Boolean
        Get
            Return _habilitada
        End Get
        Set(ByVal value As System.Boolean)
            _habilitada = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idEmpresa.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.direccion.ToString()
            ElseIf index = 3 Then
                Return Me.telefono.ToString()
            ElseIf index = 4 Then
                Return Me.habilitada.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idEmpresa = System.Int16.Parse("0" & value)
                Catch
                    Me.idEmpresa = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Me.direccion = value
            ElseIf index = 3 Then
                Me.telefono = value
            ElseIf index = 4 Then
                Try
                    Me.habilitada = System.Boolean.Parse(value)
                Catch
                    Me.habilitada = False
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idEmpresa" Then
                Return Me.idEmpresa.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "direccion" Then
                Return Me.direccion.ToString()
            ElseIf index = "telefono" Then
                Return Me.telefono.ToString()
            ElseIf index = "habilitada" Then
                Return Me.habilitada.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idEmpresa" Then
                Try
                    Me.idEmpresa = System.Int16.Parse("0" & value)
                Catch
                    Me.idEmpresa = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "direccion" Then
                Me.direccion = value
            ElseIf index = "telefono" Then
                Me.telefono = value
            ElseIf index = "habilitada" Then
                Try
                    Me.habilitada = System.Boolean.Parse(value)
                Catch
                    Me.habilitada = False
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblEmpresa"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsEmpresa
    Private Shared Function row2clsEmpresa(ByVal r As DataRow) As clsEmpresa
        ' asigna a un objeto clsEmpresa los datos del dataRow indicado
        Dim oclsEmpresa As New clsEmpresa
        '
        oclsEmpresa.idEmpresa = System.Int16.Parse("0" & r("idEmpresa").ToString())
        oclsEmpresa.nombre = r("nombre").ToString()
        oclsEmpresa.direccion = r("direccion").ToString()
        oclsEmpresa.telefono = r("telefono").ToString()
        Try
            oclsEmpresa.habilitada = System.Boolean.Parse(r("habilitada").ToString())
        Catch
            oclsEmpresa.habilitada = False
        End Try
        '
        Return oclsEmpresa
    End Function
    '
    ' asigna un objeto clsEmpresa a la fila indicada
    Private Shared Sub clsEmpresa2Row(ByVal oclsEmpresa As clsEmpresa, ByVal r As DataRow)
        ' asigna un objeto clsEmpresa al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idEmpresa") = oclsEmpresa.idEmpresa
        r("nombre") = oclsEmpresa.nombre
        r("direccion") = oclsEmpresa.direccion
        r("telefono") = oclsEmpresa.telefono
        r("habilitada") = oclsEmpresa.habilitada
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsEmpresa
    Private Shared Sub nuevoclsEmpresa(ByVal dt As DataTable, ByVal oclsEmpresa As clsEmpresa)
        ' Crear un nuevo clsEmpresa
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsEmpresa = row2clsEmpresa(dr)
        '
        oc.idEmpresa = oclsEmpresa.idEmpresa
        oc.nombre = oclsEmpresa.nombre
        oc.direccion = oclsEmpresa.direccion
        oc.telefono = oclsEmpresa.telefono
        oc.habilitada = oclsEmpresa.habilitada
        '
        clsEmpresa2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblEmpresa
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEmpresa")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsEmpresa
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsEmpresa As clsEmpresa = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEmpresa")
        Dim sel As String = "SELECT * FROM tblEmpresa WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsEmpresa = row2clsEmpresa(dt.Rows(0))
        End If
        Return oclsEmpresa
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idEmpresa existe en la tabla.
    '             TODO: Si en lugar de idEmpresa usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idEmpresa que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblEmpresa WHERE idEmpresa = " & Me.idEmpresa.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEmpresa")
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
        '       Yo compruebo que sea un campo llamado idEmpresa, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idEmpresa) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblEmpresa SET nombre = @nombre, direccion = @direccion, telefono = @telefono, habilitada = @habilitada  WHERE (idEmpresa = @idEmpresa)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        da.UpdateCommand.Parameters.Add("@direccion", SqlDbType.NVarChar, 50, "direccion")
        da.UpdateCommand.Parameters.Add("@telefono", SqlDbType.NVarChar, 50, "telefono")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@habilitada", SqlDbType.Bit, 0, "habilitada")
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
            clsEmpresa2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsEmpresa")
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
        '       Yo compruebo que sea un campo llamado idEmpresa, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblEmpresa (nombre, direccion, telefono, habilitada)  VALUES(@nombre, @direccion, @telefono, @habilitada)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        da.InsertCommand.Parameters.Add("@direccion", SqlDbType.NVarChar, 50, "direccion")
        da.InsertCommand.Parameters.Add("@telefono", SqlDbType.NVarChar, 50, "telefono")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@habilitada", SqlDbType.Bit, 0, "habilitada")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsEmpresa(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsEmpresa"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idEmpresa que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblEmpresa WHERE idEmpresa = " & Me.idEmpresa.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEmpresa")
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
        '       Yo compruebo que sea un campo llamado idEmpresa, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblEmpresa WHERE (idEmpresa = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idEmpresa")
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
