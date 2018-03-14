'------------------------------------------------------------------------------
' Clase clsTipoMovimiento generada automáticamente con CrearClaseSQL
' de la tabla 'tblTipoMovimiento' de la base 'laFuente'
' Fecha: 02/abr/2008 15:41:53
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
Public Class clsTipoMovimiento
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idTipoMovimiento As System.Int16
    Private _nombre As System.String
    Private _disminuyeInventario As System.Boolean
    Private _actualizaCosto As System.Boolean
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
    Public Property idTipoMovimiento() As System.Int16
        Get
            Return _idTipoMovimiento
        End Get
        Set(ByVal value As System.Int16)
            _idTipoMovimiento = value
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
    Public Property disminuyeInventario() As System.Boolean
        Get
            Return _disminuyeInventario
        End Get
        Set(ByVal value As System.Boolean)
            _disminuyeInventario = value
        End Set
    End Property
    Public Property actualizaCosto() As System.Boolean
        Get
            Return _actualizaCosto
        End Get
        Set(ByVal value As System.Boolean)
            _actualizaCosto = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.disminuyeInventario.ToString()
            ElseIf index = 3 Then
                Return Me.actualizaCosto.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Try
                    Me.disminuyeInventario = System.Boolean.Parse(value)
                Catch
                    Me.disminuyeInventario = False
                End Try
            ElseIf index = 3 Then
                Try
                    Me.actualizaCosto = System.Boolean.Parse(value)
                Catch
                    Me.actualizaCosto = False
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idTipoMovimiento" Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "disminuyeInventario" Then
                Return Me.disminuyeInventario.ToString()
            ElseIf index = "actualizaCosto" Then
                Return Me.actualizaCosto.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idTipoMovimiento" Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "disminuyeInventario" Then
                Try
                    Me.disminuyeInventario = System.Boolean.Parse(value)
                Catch
                    Me.disminuyeInventario = False
                End Try
            ElseIf index = "actualizaCosto" Then
                Try
                    Me.actualizaCosto = System.Boolean.Parse(value)
                Catch
                    Me.actualizaCosto = False
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblTipoMovimiento"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsTipoMovimiento
    Private Shared Function row2clsTipoMovimiento(ByVal r As DataRow) As clsTipoMovimiento
        ' asigna a un objeto clsTipoMovimiento los datos del dataRow indicado
        Dim oclsTipoMovimiento As New clsTipoMovimiento
        '
        oclsTipoMovimiento.idTipoMovimiento = System.Int16.Parse("0" & r("idTipoMovimiento").ToString())
        oclsTipoMovimiento.nombre = r("nombre").ToString()
        Try
            oclsTipoMovimiento.disminuyeInventario = System.Boolean.Parse(r("disminuyeInventario").ToString())
        Catch
            oclsTipoMovimiento.disminuyeInventario = False
        End Try
        Try
            oclsTipoMovimiento.actualizaCosto = System.Boolean.Parse(r("actualizaCosto").ToString())
        Catch
            oclsTipoMovimiento.actualizaCosto = False
        End Try
        '
        Return oclsTipoMovimiento
    End Function
    '
    ' asigna un objeto clsTipoMovimiento a la fila indicada
    Private Shared Sub clsTipoMovimiento2Row(ByVal oclsTipoMovimiento As clsTipoMovimiento, ByVal r As DataRow)
        ' asigna un objeto clsTipoMovimiento al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idTipoMovimiento") = oclsTipoMovimiento.idTipoMovimiento
        r("nombre") = oclsTipoMovimiento.nombre
        r("disminuyeInventario") = oclsTipoMovimiento.disminuyeInventario
        r("actualizaCosto") = oclsTipoMovimiento.actualizaCosto
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsTipoMovimiento
    Private Shared Sub nuevoclsTipoMovimiento(ByVal dt As DataTable, ByVal oclsTipoMovimiento As clsTipoMovimiento)
        ' Crear un nuevo clsTipoMovimiento
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsTipoMovimiento = row2clsTipoMovimiento(dr)
        '
        oc.idTipoMovimiento = oclsTipoMovimiento.idTipoMovimiento
        oc.nombre = oclsTipoMovimiento.nombre
        oc.disminuyeInventario = oclsTipoMovimiento.disminuyeInventario
        oc.actualizaCosto = oclsTipoMovimiento.actualizaCosto
        '
        clsTipoMovimiento2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblTipoMovimiento
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoMovimiento")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsTipoMovimiento
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsTipoMovimiento As clsTipoMovimiento = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoMovimiento")
        Dim sel As String = "SELECT * FROM tblTipoMovimiento WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsTipoMovimiento = row2clsTipoMovimiento(dt.Rows(0))
        End If
        Return oclsTipoMovimiento
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idTipoMovimiento existe en la tabla.
    '             TODO: Si en lugar de idTipoMovimiento usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idTipoMovimiento que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblTipoMovimiento WHERE idTipoMovimiento = " & Me.idTipoMovimiento.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoMovimiento")
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
        '       Yo compruebo que sea un campo llamado idTipoMovimiento, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idTipoMovimiento) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblTipoMovimiento SET nombre = @nombre, disminuyeInventario = @disminuyeInventario, actualizaCosto = @actualizaCosto  WHERE (idTipoMovimiento = @idTipoMovimiento)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@disminuyeInventario", SqlDbType.Bit, 0, "disminuyeInventario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@actualizaCosto", SqlDbType.Bit, 0, "actualizaCosto")
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
            clsTipoMovimiento2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsTipoMovimiento")
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
        '       Yo compruebo que sea un campo llamado idTipoMovimiento, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblTipoMovimiento (nombre, disminuyeInventario, actualizaCosto)  VALUES(@nombre, @disminuyeInventario, @actualizaCosto)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@disminuyeInventario", SqlDbType.Bit, 0, "disminuyeInventario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@actualizaCosto", SqlDbType.Bit, 0, "actualizaCosto")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsTipoMovimiento(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsTipoMovimiento"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idTipoMovimiento que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblTipoMovimiento WHERE idTipoMovimiento = " & Me.idTipoMovimiento.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsTipoMovimiento")
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
        '       Yo compruebo que sea un campo llamado idTipoMovimiento, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblTipoMovimiento WHERE (idTipoMovimiento = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idTipoMovimiento")
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

