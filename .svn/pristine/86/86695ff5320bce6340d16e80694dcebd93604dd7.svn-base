'------------------------------------------------------------------------------
' Clase clsPreciosTipoArticulo generada automáticamente con CrearClaseSQL
' de la tabla 'tblPreciosTipoArticulo' de la base 'data'
' Fecha: 08/ago/2012 18:43:54
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
Public Class clsPreciosTipoArticulo
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idPrecioTipoArticulo As System.Int32
    Private _idPrecio As System.Int16
    Private _idTipoArticulo As System.Int16
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
    Public Property idPrecioTipoArticulo() As System.Int32
        Get
            Return _idPrecioTipoArticulo
        End Get
        Set(ByVal value As System.Int32)
            _idPrecioTipoArticulo = value
        End Set
    End Property
    Public Property idPrecio() As System.Int16
        Get
            Return _idPrecio
        End Get
        Set(ByVal value As System.Int16)
            _idPrecio = value
        End Set
    End Property
    Public Property idTipoArticulo() As System.Int16
        Get
            Return _idTipoArticulo
        End Get
        Set(ByVal value As System.Int16)
            _idTipoArticulo = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idPrecioTipoArticulo.ToString()
            ElseIf index = 1 Then
                Return Me.idPrecio.ToString()
            ElseIf index = 2 Then
                Return Me.idTipoArticulo.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idPrecioTipoArticulo = System.Int32.Parse("0" & value)
                Catch
                    Me.idPrecioTipoArticulo = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idPrecio = System.Int16.Parse("0" & value)
                Catch
                    Me.idPrecio = System.Int16.Parse("0")
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idTipoArticulo = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoArticulo = System.Int16.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idPrecioTipoArticulo" Then
                Return Me.idPrecioTipoArticulo.ToString()
            ElseIf index = "idPrecio" Then
                Return Me.idPrecio.ToString()
            ElseIf index = "idTipoArticulo" Then
                Return Me.idTipoArticulo.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idPrecioTipoArticulo" Then
                Try
                    Me.idPrecioTipoArticulo = System.Int32.Parse("0" & value)
                Catch
                    Me.idPrecioTipoArticulo = System.Int32.Parse("0")
                End Try
            ElseIf index = "idPrecio" Then
                Try
                    Me.idPrecio = System.Int16.Parse("0" & value)
                Catch
                    Me.idPrecio = System.Int16.Parse("0")
                End Try
            ElseIf index = "idTipoArticulo" Then
                Try
                    Me.idTipoArticulo = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoArticulo = System.Int16.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblPreciosTipoArticulo"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsPreciosTipoArticulo
    Private Shared Function row2clsPreciosTipoArticulo(ByVal r As DataRow) As clsPreciosTipoArticulo
        ' asigna a un objeto clsPreciosTipoArticulo los datos del dataRow indicado
        Dim oclsPreciosTipoArticulo As New clsPreciosTipoArticulo
        '
        oclsPreciosTipoArticulo.idPrecioTipoArticulo = System.Int32.Parse("0" & r("idPrecioTipoArticulo").ToString())
        oclsPreciosTipoArticulo.idPrecio = System.Int16.Parse("0" & r("idPrecio").ToString())
        oclsPreciosTipoArticulo.idTipoArticulo = System.Int16.Parse("0" & r("idTipoArticulo").ToString())
        '
        Return oclsPreciosTipoArticulo
    End Function
    '
    ' asigna un objeto clsPreciosTipoArticulo a la fila indicada
    Private Shared Sub clsPreciosTipoArticulo2Row(ByVal oclsPreciosTipoArticulo As clsPreciosTipoArticulo, ByVal r As DataRow)
        ' asigna un objeto clsPreciosTipoArticulo al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idPrecioTipoArticulo") = oclsPreciosTipoArticulo.idPrecioTipoArticulo
        r("idPrecio") = oclsPreciosTipoArticulo.idPrecio
        r("idTipoArticulo") = oclsPreciosTipoArticulo.idTipoArticulo
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsPreciosTipoArticulo
    Private Shared Sub nuevoclsPreciosTipoArticulo(ByVal dt As DataTable, ByVal oclsPreciosTipoArticulo As clsPreciosTipoArticulo)
        ' Crear un nuevo clsPreciosTipoArticulo
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsPreciosTipoArticulo = row2clsPreciosTipoArticulo(dr)
        '
        oc.idPrecioTipoArticulo = oclsPreciosTipoArticulo.idPrecioTipoArticulo
        oc.idPrecio = oclsPreciosTipoArticulo.idPrecio
        oc.idTipoArticulo = oclsPreciosTipoArticulo.idTipoArticulo
        '
        clsPreciosTipoArticulo2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblPreciosTipoArticulo
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosTipoArticulo")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsPreciosTipoArticulo
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsPreciosTipoArticulo As clsPreciosTipoArticulo = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosTipoArticulo")
        Dim sel As String = "SELECT * FROM tblPreciosTipoArticulo WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsPreciosTipoArticulo = row2clsPreciosTipoArticulo(dt.Rows(0))
        End If
        Return oclsPreciosTipoArticulo
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idPrecioTipoArticulo existe en la tabla.
    '             TODO: Si en lugar de idPrecioTipoArticulo usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idPrecioTipoArticulo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblPreciosTipoArticulo WHERE idPrecioTipoArticulo = " & Me.idPrecioTipoArticulo.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosTipoArticulo")
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
        '       Yo compruebo que sea un campo llamado idPrecioTipoArticulo, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idPrecioTipoArticulo) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblPreciosTipoArticulo SET idPrecio = @idPrecio, idTipoArticulo = @idTipoArticulo  WHERE (idPrecioTipoArticulo = @idPrecioTipoArticulo)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idPrecioTipoArticulo", SqlDbType.Int, 0, "idPrecioTipoArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idPrecio", SqlDbType.SmallInt, 0, "idPrecio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoArticulo", SqlDbType.SmallInt, 0, "idTipoArticulo")
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
            clsPreciosTipoArticulo2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsPreciosTipoArticulo")
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
        '       Yo compruebo que sea un campo llamado idPrecioTipoArticulo, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblPreciosTipoArticulo (idPrecio, idTipoArticulo)  VALUES(@idPrecio, @idTipoArticulo)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idPrecioTipoArticulo", SqlDbType.Int, 0, "idPrecioTipoArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idPrecio", SqlDbType.SmallInt, 0, "idPrecio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoArticulo", SqlDbType.SmallInt, 0, "idTipoArticulo")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsPreciosTipoArticulo(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsPreciosTipoArticulo"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idPrecioTipoArticulo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblPreciosTipoArticulo WHERE idPrecioTipoArticulo = " & Me.idPrecioTipoArticulo.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPreciosTipoArticulo")
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
        '       Yo compruebo que sea un campo llamado idPrecioTipoArticulo, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblPreciosTipoArticulo WHERE (idPrecioTipoArticulo = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idPrecioTipoArticulo")
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
