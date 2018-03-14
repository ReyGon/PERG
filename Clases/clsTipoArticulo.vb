'------------------------------------------------------------------------------
' Clase clsTipoArticulo generada automáticamente con CrearClaseSQL
' de la tabla 'tblTipoArticulo' de la base 'laFuente'
' Fecha: 27/mar/2008 06:01:03
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
Public Class clsTipoArticulo
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idTipoArticulo As System.Int16
    Private _nombre As System.String
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
    Public Property idTipoArticulo() As System.Int16
        Get
            Return _idTipoArticulo
        End Get
        Set(ByVal value As System.Int16)
            _idTipoArticulo = value
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
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idTipoArticulo.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idTipoArticulo = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoArticulo = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idTipoArticulo" Then
                Return Me.idTipoArticulo.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idTipoArticulo" Then
                Try
                    Me.idTipoArticulo = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoArticulo = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn
    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblTipoArticulo"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsTipoArticulo
    Private Shared Function row2clsTipoArticulo(ByVal r As DataRow) As clsTipoArticulo
        ' asigna a un objeto clsTipoArticulo los datos del dataRow indicado
        Dim oclsTipoArticulo As New clsTipoArticulo
        '
        oclsTipoArticulo.idTipoArticulo = System.Int16.Parse("0" & r("idTipoArticulo").ToString())
        oclsTipoArticulo.nombre = r("nombre").ToString()
        '
        Return oclsTipoArticulo
    End Function
    '
    ' asigna un objeto clsTipoArticulo a la fila indicada
    Private Shared Sub clsTipoArticulo2Row(ByVal oclsTipoArticulo As clsTipoArticulo, ByVal r As DataRow)
        ' asigna un objeto clsTipoArticulo al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idTipoArticulo") = oclsTipoArticulo.idTipoArticulo
        r("nombre") = oclsTipoArticulo.nombre
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsTipoArticulo
    Private Shared Sub nuevoclsTipoArticulo(ByVal dt As DataTable, ByVal oclsTipoArticulo As clsTipoArticulo)
        ' Crear un nuevo clsTipoArticulo
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsTipoArticulo = row2clsTipoArticulo(dr)
        '
        oc.idTipoArticulo = oclsTipoArticulo.idTipoArticulo
        oc.nombre = oclsTipoArticulo.nombre
        '
        clsTipoArticulo2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblTipoArticulo
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoArticulo")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsTipoArticulo
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsTipoArticulo As clsTipoArticulo = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoArticulo")
        Dim sel As String = "SELECT * FROM tblTipoArticulo WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsTipoArticulo = row2clsTipoArticulo(dt.Rows(0))
        End If
        Return oclsTipoArticulo
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idTipoArticulo existe en la tabla.
    '             TODO: Si en lugar de idTipoArticulo usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idTipoArticulo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblTipoArticulo WHERE idTipoArticulo = " & Me.idTipoArticulo.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoArticulo")
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
        '       Yo compruebo que sea un campo llamado idTipoArticulo, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idTipoArticulo) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblTipoArticulo SET nombre = @nombre  WHERE (idTipoArticulo = @idTipoArticulo)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoArticulo", SqlDbType.SmallInt, 0, "idTipoArticulo")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
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
            clsTipoArticulo2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsTipoArticulo")
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
        '       Yo compruebo que sea un campo llamado idTipoArticulo, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblTipoArticulo (nombre)  VALUES(@nombre)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoArticulo", SqlDbType.SmallInt, 0, "idTipoArticulo")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsTipoArticulo(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsTipoArticulo"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idTipoArticulo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblTipoArticulo WHERE idTipoArticulo = " & Me.idTipoArticulo.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoArticulo")
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
        '       Yo compruebo que sea un campo llamado idTipoArticulo, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblTipoArticulo WHERE (idTipoArticulo = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idTipoArticulo")
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
