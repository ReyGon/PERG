'------------------------------------------------------------------------------
' Clase clsVendedor generada automáticamente con CrearClaseSQL
' de la tabla 'tblVendedor' de la base 'laFuente'
' Fecha: 06/abr/2008 19:53:25
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
Public Class clsVendedor
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idVendedor As System.Int16
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
    Public Property idVendedor() As System.Int16
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As System.Int16)
            _idVendedor = value
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
                Return Me.idVendedor.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idVendedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idVendedor = System.Int16.Parse("0")
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
            If index = "idVendedor" Then
                Return Me.idVendedor.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idVendedor" Then
                Try
                    Me.idVendedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idVendedor = System.Int16.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblVendedor"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsVendedor
    Private Shared Function row2clsVendedor(ByVal r As DataRow) As clsVendedor
        ' asigna a un objeto clsVendedor los datos del dataRow indicado
        Dim oclsVendedor As New clsVendedor
        '
        oclsVendedor.idVendedor = System.Int16.Parse("0" & r("idVendedor").ToString())
        oclsVendedor.nombre = r("nombre").ToString()
        '
        Return oclsVendedor
    End Function
    '
    ' asigna un objeto clsVendedor a la fila indicada
    Private Shared Sub clsVendedor2Row(ByVal oclsVendedor As clsVendedor, ByVal r As DataRow)
        ' asigna un objeto clsVendedor al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idVendedor") = oclsVendedor.idVendedor
        r("nombre") = oclsVendedor.nombre
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsVendedor
    Private Shared Sub nuevoclsVendedor(ByVal dt As DataTable, ByVal oclsVendedor As clsVendedor)
        ' Crear un nuevo clsVendedor
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsVendedor = row2clsVendedor(dr)
        '
        oc.idVendedor = oclsVendedor.idVendedor
        oc.nombre = oclsVendedor.nombre
        '
        clsVendedor2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblVendedor
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsVendedor")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsVendedor
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsVendedor As clsVendedor = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsVendedor")
        Dim sel As String = "SELECT * FROM tblVendedor WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsVendedor = row2clsVendedor(dt.Rows(0))
        End If
        Return oclsVendedor
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idVendedor existe en la tabla.
    '             TODO: Si en lugar de idVendedor usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idVendedor que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblVendedor WHERE idVendedor = " & Me.idVendedor.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsVendedor")
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
        '       Yo compruebo que sea un campo llamado idVendedor, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idVendedor) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblVendedor SET nombre = @nombre  WHERE (idVendedor = @idVendedor)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idVendedor", SqlDbType.SmallInt, 0, "idVendedor")
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
            clsVendedor2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsVendedor")
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
        '       Yo compruebo que sea un campo llamado idVendedor, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblVendedor (nombre)  VALUES(@nombre)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idVendedor", SqlDbType.SmallInt, 0, "idVendedor")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsVendedor(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsVendedor"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idVendedor que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblVendedor WHERE idVendedor = " & Me.idVendedor.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsVendedor")
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
        '       Yo compruebo que sea un campo llamado idVendedor, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblVendedor WHERE (idVendedor = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idVendedor")
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
