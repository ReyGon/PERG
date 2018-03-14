'------------------------------------------------------------------------------
' Clase clsUsuarios generada automáticamente con CrearClaseSQL
' de la tabla 'tblUsuarios' de la base 'data'
' Fecha: 29/jul/2012 22:00:11
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
Public Class clsUsuarios
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idUsuario As System.Int16
    Private _nombre As System.String
    Private _bloqueado As System.Boolean
    Private _superUsuario As System.Boolean
    Private _idGrupo As System.Int32
    Private _idVendedor As System.Int16
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
    Public Property idUsuario() As System.Int16
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As System.Int16)
            _idUsuario = value
        End Set
    End Property
    Public Property nombre() As System.String
        Get
            Return ajustarAncho(_nombre, 20)
        End Get
        Set(ByVal value As System.String)
            _nombre = value
        End Set
    End Property
    Public Property bloqueado() As System.Boolean
        Get
            Return _bloqueado
        End Get
        Set(ByVal value As System.Boolean)
            _bloqueado = value
        End Set
    End Property
    Public Property superUsuario() As System.Boolean
        Get
            Return _superUsuario
        End Get
        Set(ByVal value As System.Boolean)
            _superUsuario = value
        End Set
    End Property
    Public Property idGrupo() As System.Int32
        Get
            Return _idGrupo
        End Get
        Set(ByVal value As System.Int32)
            _idGrupo = value
        End Set
    End Property
    Public Property idVendedor() As System.Int16
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As System.Int16)
            _idVendedor = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idUsuario.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.bloqueado.ToString()
            ElseIf index = 3 Then
                Return Me.superUsuario.ToString()
            ElseIf index = 4 Then
                Return Me.idGrupo.ToString()
            ElseIf index = 5 Then
                Return Me.idVendedor.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Try
                    Me.bloqueado = System.Boolean.Parse(value)
                Catch
                    Me.bloqueado = False
                End Try
            ElseIf index = 3 Then
                Try
                    Me.superUsuario = System.Boolean.Parse(value)
                Catch
                    Me.superUsuario = False
                End Try
            ElseIf index = 4 Then
                Try
                    Me.idGrupo = System.Int32.Parse("0" & value)
                Catch
                    Me.idGrupo = System.Int32.Parse("0")
                End Try
            ElseIf index = 5 Then
                Try
                    Me.idVendedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idVendedor = System.Int16.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idUsuario" Then
                Return Me.idUsuario.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "bloqueado" Then
                Return Me.bloqueado.ToString()
            ElseIf index = "superUsuario" Then
                Return Me.superUsuario.ToString()
            ElseIf index = "idGrupo" Then
                Return Me.idGrupo.ToString()
            ElseIf index = "idVendedor" Then
                Return Me.idVendedor.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idUsuario" Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "bloqueado" Then
                Try
                    Me.bloqueado = System.Boolean.Parse(value)
                Catch
                    Me.bloqueado = False
                End Try
            ElseIf index = "superUsuario" Then
                Try
                    Me.superUsuario = System.Boolean.Parse(value)
                Catch
                    Me.superUsuario = False
                End Try
            ElseIf index = "idGrupo" Then
                Try
                    Me.idGrupo = System.Int32.Parse("0" & value)
                Catch
                    Me.idGrupo = System.Int32.Parse("0")
                End Try
            ElseIf index = "idVendedor" Then
                Try
                    Me.idVendedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idVendedor = System.Int16.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblUsuarios"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsUsuarios
    Private Shared Function row2clsUsuarios(ByVal r As DataRow) As clsUsuarios
        ' asigna a un objeto clsUsuarios los datos del dataRow indicado
        Dim oclsUsuarios As New clsUsuarios
        '
        oclsUsuarios.idUsuario = System.Int16.Parse("0" & r("idUsuario").ToString())
        oclsUsuarios.nombre = r("nombre").ToString()
        Try
            oclsUsuarios.bloqueado = System.Boolean.Parse(r("bloqueado").ToString())
        Catch
            oclsUsuarios.bloqueado = False
        End Try
        Try
            oclsUsuarios.superUsuario = System.Boolean.Parse(r("superUsuario").ToString())
        Catch
            oclsUsuarios.superUsuario = False
        End Try
        oclsUsuarios.idGrupo = System.Int32.Parse("0" & r("idGrupo").ToString())
        oclsUsuarios.idVendedor = System.Int16.Parse("0" & r("idVendedor").ToString())
        '
        Return oclsUsuarios
    End Function
    '
    ' asigna un objeto clsUsuarios a la fila indicada
    Private Shared Sub clsUsuarios2Row(ByVal oclsUsuarios As clsUsuarios, ByVal r As DataRow)
        ' asigna un objeto clsUsuarios al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idUsuario") = oclsUsuarios.idUsuario
        r("nombre") = oclsUsuarios.nombre
        r("bloqueado") = oclsUsuarios.bloqueado
        r("superUsuario") = oclsUsuarios.superUsuario
        r("idGrupo") = oclsUsuarios.idGrupo
        r("idVendedor") = oclsUsuarios.idVendedor
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsUsuarios
    Private Shared Sub nuevoclsUsuarios(ByVal dt As DataTable, ByVal oclsUsuarios As clsUsuarios)
        ' Crear un nuevo clsUsuarios
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsUsuarios = row2clsUsuarios(dr)
        '
        oc.idUsuario = oclsUsuarios.idUsuario
        oc.nombre = oclsUsuarios.nombre
        oc.bloqueado = oclsUsuarios.bloqueado
        oc.superUsuario = oclsUsuarios.superUsuario
        oc.idGrupo = oclsUsuarios.idGrupo
        oc.idVendedor = oclsUsuarios.idVendedor
        '
        clsUsuarios2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblUsuarios
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsUsuarios")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsUsuarios
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsUsuarios As clsUsuarios = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsUsuarios")
        Dim sel As String = "SELECT * FROM tblUsuarios WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsUsuarios = row2clsUsuarios(dt.Rows(0))
        End If
        Return oclsUsuarios
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idUsuario existe en la tabla.
    '             TODO: Si en lugar de idUsuario usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idUsuario que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblUsuarios WHERE idUsuario = " & Me.idUsuario.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsUsuarios")
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
        '       Yo compruebo que sea un campo llamado idUsuario, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idUsuario) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblUsuarios SET nombre = @nombre, bloqueado = @bloqueado, superUsuario = @superUsuario, idGrupo = @idGrupo, idVendedor = @idVendedor  WHERE (idUsuario = @idUsuario)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 20, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@bloqueado", SqlDbType.Bit, 0, "bloqueado")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@superUsuario", SqlDbType.Bit, 0, "superUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idGrupo", SqlDbType.Int, 0, "idGrupo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idVendedor", SqlDbType.SmallInt, 0, "idVendedor")
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
            clsUsuarios2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsUsuarios")
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
        '       Yo compruebo que sea un campo llamado idUsuario, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblUsuarios (nombre, bloqueado, superUsuario, idGrupo, idVendedor)  VALUES(@nombre, @bloqueado, @superUsuario, @idGrupo, @idVendedor)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 20, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@bloqueado", SqlDbType.Bit, 0, "bloqueado")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@superUsuario", SqlDbType.Bit, 0, "superUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idGrupo", SqlDbType.Int, 0, "idGrupo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idVendedor", SqlDbType.SmallInt, 0, "idVendedor")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsUsuarios(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsUsuarios"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idUsuario que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblUsuarios WHERE idUsuario = " & Me.idUsuario.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsUsuarios")
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
        '       Yo compruebo que sea un campo llamado idUsuario, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblUsuarios WHERE (idUsuario = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idUsuario")
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
