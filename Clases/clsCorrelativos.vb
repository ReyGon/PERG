'------------------------------------------------------------------------------
' Clase clsCorrelativos generada automáticamente con CrearClaseSQL
' de la tabla 'tblCorrelativos' de la base 'laFuente'
' Fecha: 02/abr/2008 15:55:34
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
Public Class clsCorrelativos
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idCorrelativo As System.Int16
    Private _idTipoMovimiento As System.Int16
    Private _idEmpresa As System.Int16
    Private _correlativo As System.Int32
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
    Public Property idCorrelativo() As System.Int16
        Get
            Return _idCorrelativo
        End Get
        Set(ByVal value As System.Int16)
            _idCorrelativo = value
        End Set
    End Property
    Public Property idTipoMovimiento() As System.Int16
        Get
            Return _idTipoMovimiento
        End Get
        Set(ByVal value As System.Int16)
            _idTipoMovimiento = value
        End Set
    End Property
    Public Property idEmpresa() As System.Int16
        Get
            Return _idEmpresa
        End Get
        Set(ByVal value As System.Int16)
            _idEmpresa = value
        End Set
    End Property
    Public Property correlativo() As System.Int32
        Get
            Return _correlativo
        End Get
        Set(ByVal value As System.Int32)
            _correlativo = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idCorrelativo.ToString()
            ElseIf index = 1 Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = 2 Then
                Return Me.idEmpresa.ToString()
            ElseIf index = 3 Then
                Return Me.correlativo.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idCorrelativo = System.Int16.Parse("0" & value)
                Catch
                    Me.idCorrelativo = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idEmpresa = System.Int16.Parse("0" & value)
                Catch
                    Me.idEmpresa = System.Int16.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.correlativo = System.Int32.Parse("0" & value)
                Catch
                    Me.correlativo = System.Int32.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idCorrelativo" Then
                Return Me.idCorrelativo.ToString()
            ElseIf index = "idTipoMovimiento" Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = "idEmpresa" Then
                Return Me.idEmpresa.ToString()
            ElseIf index = "correlativo" Then
                Return Me.correlativo.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idCorrelativo" Then
                Try
                    Me.idCorrelativo = System.Int16.Parse("0" & value)
                Catch
                    Me.idCorrelativo = System.Int16.Parse("0")
                End Try
            ElseIf index = "idTipoMovimiento" Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = "idEmpresa" Then
                Try
                    Me.idEmpresa = System.Int16.Parse("0" & value)
                Catch
                    Me.idEmpresa = System.Int16.Parse("0")
                End Try
            ElseIf index = "correlativo" Then
                Try
                    Me.correlativo = System.Int32.Parse("0" & value)
                Catch
                    Me.correlativo = System.Int32.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblCorrelativos"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsCorrelativos
    Private Shared Function row2clsCorrelativos(ByVal r As DataRow) As clsCorrelativos
        ' asigna a un objeto clsCorrelativos los datos del dataRow indicado
        Dim oclsCorrelativos As New clsCorrelativos
        '
        oclsCorrelativos.idCorrelativo = System.Int16.Parse("0" & r("idCorrelativo").ToString())
        oclsCorrelativos.idTipoMovimiento = System.Int16.Parse("0" & r("idTipoMovimiento").ToString())
        oclsCorrelativos.idEmpresa = System.Int16.Parse("0" & r("idEmpresa").ToString())
        oclsCorrelativos.correlativo = System.Int32.Parse("0" & r("correlativo").ToString())
        '
        Return oclsCorrelativos
    End Function
    '
    ' asigna un objeto clsCorrelativos a la fila indicada
    Private Shared Sub clsCorrelativos2Row(ByVal oclsCorrelativos As clsCorrelativos, ByVal r As DataRow)
        ' asigna un objeto clsCorrelativos al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idCorrelativo") = oclsCorrelativos.idCorrelativo
        r("idTipoMovimiento") = oclsCorrelativos.idTipoMovimiento
        r("idEmpresa") = oclsCorrelativos.idEmpresa
        r("correlativo") = oclsCorrelativos.correlativo
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsCorrelativos
    Private Shared Sub nuevoclsCorrelativos(ByVal dt As DataTable, ByVal oclsCorrelativos As clsCorrelativos)
        ' Crear un nuevo clsCorrelativos
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsCorrelativos = row2clsCorrelativos(dr)
        '
        oc.idCorrelativo = oclsCorrelativos.idCorrelativo
        oc.idTipoMovimiento = oclsCorrelativos.idTipoMovimiento
        oc.idEmpresa = oclsCorrelativos.idEmpresa
        oc.correlativo = oclsCorrelativos.correlativo
        '
        clsCorrelativos2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblCorrelativos
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCorrelativos")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsCorrelativos
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsCorrelativos As clsCorrelativos = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCorrelativos")
        Dim sel As String = "SELECT * FROM tblCorrelativos WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsCorrelativos = row2clsCorrelativos(dt.Rows(0))
        End If
        Return oclsCorrelativos
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idCorrelativo existe en la tabla.
    '             TODO: Si en lugar de idCorrelativo usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCorrelativo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblCorrelativos WHERE idCorrelativo = " & Me.idCorrelativo.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCorrelativos")
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
        '       Yo compruebo que sea un campo llamado idCorrelativo, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idCorrelativo) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblCorrelativos SET idTipoMovimiento = @idTipoMovimiento, idEmpresa = @idEmpresa, correlativo = @correlativo  WHERE (idCorrelativo = @idCorrelativo)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idCorrelativo", SqlDbType.SmallInt, 0, "idCorrelativo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@correlativo", SqlDbType.Int, 0, "correlativo")
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
            clsCorrelativos2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsCorrelativos")
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
        '       Yo compruebo que sea un campo llamado idCorrelativo, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblCorrelativos (idTipoMovimiento, idEmpresa, correlativo)  VALUES(@idTipoMovimiento, @idEmpresa, @correlativo)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idCorrelativo", SqlDbType.SmallInt, 0, "idCorrelativo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@correlativo", SqlDbType.Int, 0, "correlativo")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsCorrelativos(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsCorrelativos"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idCorrelativo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblCorrelativos WHERE idCorrelativo = " & Me.idCorrelativo.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsCorrelativos")
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
        '       Yo compruebo que sea un campo llamado idCorrelativo, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblCorrelativos WHERE (idCorrelativo = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idCorrelativo")
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
