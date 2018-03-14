'------------------------------------------------------------------------------
' Clase clsCajaConcepto generada automáticamente con CrearClaseSQL
' de la tabla 'tblCajaConcepto' de la base 'data'
' Fecha: 18/feb/2012 23:25:14
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
Public Class clsCajaConcepto
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idCajaConcepto As System.Int32
    Private _nombre As System.String
    Private _entrada As System.Boolean
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
    Public Property idCajaConcepto() As System.Int32
        Get
            Return _idCajaConcepto
        End Get
        Set(ByVal value As System.Int32)
            _idCajaConcepto = value
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
    Public Property entrada() As System.Boolean
        Get
            Return _entrada
        End Get
        Set(ByVal value As System.Boolean)
            _entrada = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idCajaConcepto.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.entrada.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idCajaConcepto = System.Int32.Parse("0" & value)
                Catch
                    Me.idCajaConcepto = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Try
                    Me.entrada = System.Boolean.Parse(value)
                Catch
                    Me.entrada = False
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idCajaConcepto" Then
                Return Me.idCajaConcepto.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "entrada" Then
                Return Me.entrada.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idCajaConcepto" Then
                Try
                    Me.idCajaConcepto = System.Int32.Parse("0" & value)
                Catch
                    Me.idCajaConcepto = System.Int32.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "entrada" Then
                Try
                    Me.entrada = System.Boolean.Parse(value)
                Catch
                    Me.entrada = False
                End Try
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn.ToString
    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblCajaConcepto"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsCajaConcepto
    Private Shared Function row2clsCajaConcepto(ByVal r As DataRow) As clsCajaConcepto
        ' asigna a un objeto clsCajaConcepto los datos del dataRow indicado
        Dim oclsCajaConcepto As New clsCajaConcepto
        '
        oclsCajaConcepto.idCajaConcepto = System.Int32.Parse("0" & r("idCajaConcepto").ToString())
        oclsCajaConcepto.nombre = r("nombre").ToString()
        Try
            oclsCajaConcepto.entrada = System.Boolean.Parse(r("entrada").ToString())
        Catch
            oclsCajaConcepto.entrada = False
        End Try
        '
        Return oclsCajaConcepto
    End Function
    '
    ' asigna un objeto clsCajaConcepto a la fila indicada
    Private Shared Sub clsCajaConcepto2Row(ByVal oclsCajaConcepto As clsCajaConcepto, ByVal r As DataRow)
        ' asigna un objeto clsCajaConcepto al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idCajaConcepto") = oclsCajaConcepto.idCajaConcepto
        r("nombre") = oclsCajaConcepto.nombre
        r("entrada") = oclsCajaConcepto.entrada
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsCajaConcepto
    Private Shared Sub nuevoclsCajaConcepto(ByVal dt As DataTable, ByVal oclsCajaConcepto As clsCajaConcepto)
        ' Crear un nuevo clsCajaConcepto
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsCajaConcepto = row2clsCajaConcepto(dr)
        '
        oc.idCajaConcepto = oclsCajaConcepto.idCajaConcepto
        oc.nombre = oclsCajaConcepto.nombre
        oc.entrada = oclsCajaConcepto.entrada
        '
        clsCajaConcepto2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblCajaConcepto
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCajaConcepto")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsCajaConcepto
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsCajaConcepto As clsCajaConcepto = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCajaConcepto")
        Dim sel As String = "SELECT * FROM tblCajaConcepto WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsCajaConcepto = row2clsCajaConcepto(dt.Rows(0))
        End If
        Return oclsCajaConcepto
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idCajaConcepto existe en la tabla.
    '             TODO: Si en lugar de idCajaConcepto usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCajaConcepto que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblCajaConcepto WHERE idCajaConcepto = " & Me.idCajaConcepto.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCajaConcepto")
        '
        cnn = New SqlConnection(cadenaConexion)
        'da = New SqlDataAdapter(CadenaSelect, cnn)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la más óptima, pero funcionará
        '-------------------------------------------
        Dim cb As New SqlCommandBuilder(da)
        da.UpdateCommand = cb.GetUpdateCommand()
        '
        '--------------------------------------------------------------------
        ' Esta está más optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        'Dim sCommand As String
        ''
        '' El comando UPDATE
        '' TODO: Comprobar cual es el campo de índice principal (sin duplicados)
        ''       Yo compruebo que sea un campo llamado idCajaConcepto, pero en tu caso puede ser otro
        ''       Ese campo, (en mi caso idCajaConcepto) será el que hay que poner al final junto al WHERE.
        'sCommand = "UPDATE tblCajaConcepto SET nombre = @nombre, entrada = @entrada  WHERE (idCajaConcepto = @idCajaConcepto)"
        'da.UpdateCommand = New SqlCommand(sCommand, cnn)
        '' TODO: Comprobar el tipo de datos a usar...
        'da.UpdateCommand.Parameters.Add("@idCajaConcepto", SqlDbType.Int, 0, "idCajaConcepto")
        'da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        '' TODO: Comprobar el tipo de datos a usar...
        'da.UpdateCommand.Parameters.Add("@entrada", SqlDbType.Bit, 0, "entrada")
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
            clsCajaConcepto2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsCajaConcepto")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(CadenaSelect, cnn)
        'da = New SqlDataAdapter(CadenaSelect, cadenaConexion)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la más óptima, pero funcionará
        '-------------------------------------------
        Dim cb As New SqlCommandBuilder(da)
        da.InsertCommand = cb.GetInsertCommand()
        '
        '--------------------------------------------------------------------
        ' Esta está más optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        'Dim sCommand As String
        ''
        '' El comando INSERT
        '' TODO: No incluir el campo de clave primaria incremental
        ''       Yo compruebo que sea un campo llamado idCajaConcepto, pero en tu caso puede ser otro
        'sCommand = "INSERT INTO tblCajaConcepto (nombre, entrada)  VALUES(@nombre, @entrada)"
        'da.InsertCommand = New SqlCommand(sCommand, cnn)
        '' TODO: Comprobar el tipo de datos a usar...
        'da.InsertCommand.Parameters.Add("@idCajaConcepto", SqlDbType.Int, 0, "idCajaConcepto")
        'da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        '' TODO: Comprobar el tipo de datos a usar...
        'da.InsertCommand.Parameters.Add("@entrada", SqlDbType.Bit, 0, "entrada")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsCajaConcepto(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsCajaConcepto"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCajaConcepto que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblCajaConcepto WHERE idCajaConcepto = " & Me.idCajaConcepto.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCajaConcepto")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la más óptima, pero funcionará
        '-------------------------------------------
        Dim cb As New SqlCommandBuilder(da)
        da.DeleteCommand = cb.GetDeleteCommand()
        '
        '
        '--------------------------------------------------------------------
        ' Esta está más optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        'Dim sCommand As String
        ''
        '' El comando DELETE
        '' TODO: Sólo incluir el campo de clave primaria incremental
        ''       Yo compruebo que sea un campo llamado idCajaConcepto, pero en tu caso puede ser otro
        'sCommand = "DELETE FROM tblCajaConcepto WHERE (idCajaConcepto = @p1)"
        'da.DeleteCommand = New SqlCommand(sCommand, cnn)
        '' TODO: Comprobar el tipo de datos a usar...
        'da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idCajaConcepto")
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
