'------------------------------------------------------------------------------
' Clase clsSalidaDetalle generada automáticamente con CrearClaseSQL
' de la tabla 'tblSalidaDetalle' de la base 'laFuente'
' Fecha: 09/abr/2008 14:52:28
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
Public Class clsSalidaDetalle
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idSalidaDetalle As System.Int32
    Private _idSalida As System.Int32
    Private _idArticulo As System.Int32
    Private _cantidad As System.Int16
    Private _precio As System.Decimal
    Private _comentario As System.String
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
    Public Property idSalidaDetalle() As System.Int32
        Get
            Return _idSalidaDetalle
        End Get
        Set(ByVal value As System.Int32)
            _idSalidaDetalle = value
        End Set
    End Property
    Public Property idSalida() As System.Int32
        Get
            Return _idSalida
        End Get
        Set(ByVal value As System.Int32)
            _idSalida = value
        End Set
    End Property
    Public Property idArticulo() As System.Int32
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As System.Int32)
            _idArticulo = value
        End Set
    End Property
    Public Property cantidad() As System.Int16
        Get
            Return _cantidad
        End Get
        Set(ByVal value As System.Int16)
            _cantidad = value
        End Set
    End Property
    Public Property precio() As System.Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As System.Decimal)
            _precio = value
        End Set
    End Property
    Public Property comentario() As System.String
        Get
            Return ajustarAncho(_comentario, 50)
        End Get
        Set(ByVal value As System.String)
            _comentario = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idSalidaDetalle.ToString()
            ElseIf index = 1 Then
                Return Me.idSalida.ToString()
            ElseIf index = 2 Then
                Return Me.idArticulo.ToString()
            ElseIf index = 3 Then
                Return Me.cantidad.ToString()
            ElseIf index = 4 Then
                Return Me.precio.ToString()
            ElseIf index = 5 Then
                Return Me.comentario.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idSalidaDetalle = System.Int32.Parse("0" & value)
                Catch
                    Me.idSalidaDetalle = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idSalida = System.Int32.Parse("0" & value)
                Catch
                    Me.idSalida = System.Int32.Parse("0")
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idArticulo = System.Int32.Parse("0" & value)
                Catch
                    Me.idArticulo = System.Int32.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.cantidad = System.Int16.Parse("0" & value)
                Catch
                    Me.cantidad = System.Int16.Parse("0")
                End Try
            ElseIf index = 4 Then
                Try
                    Me.precio = System.Decimal.Parse("0" & value)
                Catch
                    Me.precio = System.Decimal.Parse("0")
                End Try
            ElseIf index = 5 Then
                Me.comentario = value
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idSalidaDetalle" Then
                Return Me.idSalidaDetalle.ToString()
            ElseIf index = "idSalida" Then
                Return Me.idSalida.ToString()
            ElseIf index = "idArticulo" Then
                Return Me.idArticulo.ToString()
            ElseIf index = "cantidad" Then
                Return Me.cantidad.ToString()
            ElseIf index = "precio" Then
                Return Me.precio.ToString()
            ElseIf index = "comentario" Then
                Return Me.comentario.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idSalidaDetalle" Then
                Try
                    Me.idSalidaDetalle = System.Int32.Parse("0" & value)
                Catch
                    Me.idSalidaDetalle = System.Int32.Parse("0")
                End Try
            ElseIf index = "idSalida" Then
                Try
                    Me.idSalida = System.Int32.Parse("0" & value)
                Catch
                    Me.idSalida = System.Int32.Parse("0")
                End Try
            ElseIf index = "idArticulo" Then
                Try
                    Me.idArticulo = System.Int32.Parse("0" & value)
                Catch
                    Me.idArticulo = System.Int32.Parse("0")
                End Try
            ElseIf index = "cantidad" Then
                Try
                    Me.cantidad = System.Int16.Parse("0" & value)
                Catch
                    Me.cantidad = System.Int16.Parse("0")
                End Try
            ElseIf index = "precio" Then
                Try
                    Me.precio = System.Decimal.Parse("0" & value)
                Catch
                    Me.precio = System.Decimal.Parse("0")
                End Try
            ElseIf index = "comentario" Then
                Me.comentario = value
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn
    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblSalidaDetalle"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsSalidaDetalle
    Private Shared Function row2clsSalidaDetalle(ByVal r As DataRow) As clsSalidaDetalle
        ' asigna a un objeto clsSalidaDetalle los datos del dataRow indicado
        Dim oclsSalidaDetalle As New clsSalidaDetalle
        '
        oclsSalidaDetalle.idSalidaDetalle = System.Int32.Parse("0" & r("idSalidaDetalle").ToString())
        oclsSalidaDetalle.idSalida = System.Int32.Parse("0" & r("idSalida").ToString())
        oclsSalidaDetalle.idArticulo = System.Int32.Parse("0" & r("idArticulo").ToString())
        oclsSalidaDetalle.cantidad = System.Int16.Parse("0" & r("cantidad").ToString())
        oclsSalidaDetalle.precio = System.Decimal.Parse("0" & r("precio").ToString())
        oclsSalidaDetalle.comentario = r("comentario").ToString()
        '
        Return oclsSalidaDetalle
    End Function
    '
    ' asigna un objeto clsSalidaDetalle a la fila indicada
    Private Shared Sub clsSalidaDetalle2Row(ByVal oclsSalidaDetalle As clsSalidaDetalle, ByVal r As DataRow)
        ' asigna un objeto clsSalidaDetalle al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idSalidaDetalle") = oclsSalidaDetalle.idSalidaDetalle
        r("idSalida") = oclsSalidaDetalle.idSalida
        r("idArticulo") = oclsSalidaDetalle.idArticulo
        r("cantidad") = oclsSalidaDetalle.cantidad
        r("precio") = oclsSalidaDetalle.precio
        r("comentario") = oclsSalidaDetalle.comentario
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsSalidaDetalle
    Private Shared Sub nuevoclsSalidaDetalle(ByVal dt As DataTable, ByVal oclsSalidaDetalle As clsSalidaDetalle)
        ' Crear un nuevo clsSalidaDetalle
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsSalidaDetalle = row2clsSalidaDetalle(dr)
        '
        oc.idSalidaDetalle = oclsSalidaDetalle.idSalidaDetalle
        oc.idSalida = oclsSalidaDetalle.idSalida
        oc.idArticulo = oclsSalidaDetalle.idArticulo
        oc.cantidad = oclsSalidaDetalle.cantidad
        oc.precio = oclsSalidaDetalle.precio
        oc.comentario = oclsSalidaDetalle.comentario
        '
        clsSalidaDetalle2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblSalidaDetalle
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalidaDetalle")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsSalidaDetalle
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsSalidaDetalle As clsSalidaDetalle = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalidaDetalle")
        Dim sel As String = "SELECT * FROM tblSalidaDetalle WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsSalidaDetalle = row2clsSalidaDetalle(dt.Rows(0))
        End If
        Return oclsSalidaDetalle
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idSalidaDetalle existe en la tabla.
    '             TODO: Si en lugar de idSalidaDetalle usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idSalidaDetalle que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblSalidaDetalle WHERE idSalidaDetalle = " & Me.idSalidaDetalle.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalidaDetalle")
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
        '       Yo compruebo que sea un campo llamado idSalidaDetalle, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idSalidaDetalle) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblSalidaDetalle SET idSalida = @idSalida, idArticulo = @idArticulo, cantidad = @cantidad, precio = @precio, comentario = @comentario  WHERE (idSalidaDetalle = @idSalidaDetalle)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idSalidaDetalle", SqlDbType.Int, 0, "idSalidaDetalle")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idSalida", SqlDbType.Int, 0, "idSalida")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idArticulo", SqlDbType.Int, 0, "idArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.SmallInt, 0, "cantidad")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Decimal, 0, "precio")
        da.UpdateCommand.Parameters.Add("@comentario", SqlDbType.NVarChar, 50, "comentario")
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
            clsSalidaDetalle2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsSalidaDetalle")
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
        '       Yo compruebo que sea un campo llamado idSalidaDetalle, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblSalidaDetalle (idSalida, idArticulo, cantidad, precio, comentario)  VALUES(@idSalida, @idArticulo, @cantidad, @precio, @comentario)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idSalidaDetalle", SqlDbType.Int, 0, "idSalidaDetalle")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idSalida", SqlDbType.Int, 0, "idSalida")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idArticulo", SqlDbType.Int, 0, "idArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@cantidad", SqlDbType.SmallInt, 0, "cantidad")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@precio", SqlDbType.Decimal, 0, "precio")
        da.InsertCommand.Parameters.Add("@comentario", SqlDbType.NVarChar, 50, "comentario")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsSalidaDetalle(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsSalidaDetalle"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idSalidaDetalle que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblSalidaDetalle WHERE idSalidaDetalle = " & Me.idSalidaDetalle.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalidaDetalle")
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
        '       Yo compruebo que sea un campo llamado idSalidaDetalle, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblSalidaDetalle WHERE (idSalidaDetalle = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idSalidaDetalle")
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
