'------------------------------------------------------------------------------
' Clase clsGrupoUsuarios generada automáticamente con CrearClaseSQL
' de la tabla 'tblGrupoUsuarios' de la base 'imprenta'
' Fecha: 01/mar/2009 08:47:28
'
' ©Guillermo 'guille' Som, 2004-2009
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class clsGrupoUsuarios
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idGrupo As System.Int16
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
    Public Property idGrupo() As System.Int16
        Get
            Return _idGrupo
        End Get
        Set(ByVal value As System.Int16)
            _idGrupo = value
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
                Return Me.idGrupo.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idGrupo = System.Int16.Parse("0" & value)
                Catch
                    Me.idGrupo = System.Int16.Parse("0")
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
            If index = "idGrupo" Then
                Return Me.idGrupo.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idGrupo" Then
                Try
                    Me.idGrupo = System.Int16.Parse("0" & value)
                Catch
                    Me.idGrupo = System.Int16.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblGrupoUsuarios"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsGrupoUsuarios
    Private Shared Function row2clsGrupoUsuarios(ByVal r As DataRow) As clsGrupoUsuarios
        ' asigna a un objeto clsGrupoUsuarios los datos del dataRow indicado
        Dim oclsGrupoUsuarios As New clsGrupoUsuarios
        '
        oclsGrupoUsuarios.idGrupo = System.Int16.Parse("0" & r("idGrupo").ToString())
        oclsGrupoUsuarios.nombre = r("nombre").ToString()
        '
        Return oclsGrupoUsuarios
    End Function
    '
    ' asigna un objeto clsGrupoUsuarios a la fila indicada
    Private Shared Sub clsGrupoUsuarios2Row(ByVal oclsGrupoUsuarios As clsGrupoUsuarios, ByVal r As DataRow)
        ' asigna un objeto clsGrupoUsuarios al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idGrupo") = oclsGrupoUsuarios.idGrupo
        r("nombre") = oclsGrupoUsuarios.nombre
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsGrupoUsuarios
    Private Shared Sub nuevoclsGrupoUsuarios(ByVal dt As DataTable, ByVal oclsGrupoUsuarios As clsGrupoUsuarios)
        ' Crear un nuevo clsGrupoUsuarios
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsGrupoUsuarios = row2clsGrupoUsuarios(dr)
        '
        oc.idGrupo = oclsGrupoUsuarios.idGrupo
        oc.nombre = oclsGrupoUsuarios.nombre
        '
        clsGrupoUsuarios2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblGrupoUsuarios
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoUsuarios")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsGrupoUsuarios
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsGrupoUsuarios As clsGrupoUsuarios = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoUsuarios")
        Dim sel As String = "SELECT * FROM tblGrupoUsuarios WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsGrupoUsuarios = row2clsGrupoUsuarios(dt.Rows(0))
        End If
        Return oclsGrupoUsuarios
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idGrupo existe en la tabla.
    '             TODO: Si en lugar de idGrupo usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idGrupo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblGrupoUsuarios WHERE idGrupo = " & Me.idGrupo.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoUsuarios")
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
        '       Yo compruebo que sea un campo llamado idGrupo, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idGrupo) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblGrupoUsuarios SET nombre = @nombre  WHERE (idGrupo = @idGrupo)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idGrupo", SqlDbType.SmallInt, 0, "idGrupo")
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
            clsGrupoUsuarios2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsGrupoUsuarios")
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
        '       Yo compruebo que sea un campo llamado idGrupo, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblGrupoUsuarios (nombre)  VALUES(@nombre)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idGrupo", SqlDbType.SmallInt, 0, "idGrupo")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsGrupoUsuarios(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsGrupoUsuarios"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idGrupo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblGrupoUsuarios WHERE idGrupo = " & Me.idGrupo.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoUsuarios")
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
        '       Yo compruebo que sea un campo llamado idGrupo, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblGrupoUsuarios WHERE (idGrupo = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idGrupo")
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
