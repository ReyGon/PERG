'------------------------------------------------------------------------------
' Clase clsEntradasDetalle generada automáticamente con CrearClaseSQL
' de la tabla 'tblEntradasDetalle' de la base 'laFuente'
' Fecha: 03/abr/2008 18:26:28
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
Public Class clsEntradasDetalle
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idEntradaDetalle As System.Int32
    Private _idEntrada As System.Int32
    Private _idArticulo As System.Int32
    Private _cantidad As System.Int16
    Private _costo As System.Decimal
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
    Public Property idEntradaDetalle() As System.Int32
        Get
            Return _idEntradaDetalle
        End Get
        Set(ByVal value As System.Int32)
            _idEntradaDetalle = value
        End Set
    End Property
    Public Property idEntrada() As System.Int32
        Get
            Return _idEntrada
        End Get
        Set(ByVal value As System.Int32)
            _idEntrada = value
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
    Public Property costo() As System.Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As System.Decimal)
            _costo = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idEntradaDetalle.ToString()
            ElseIf index = 1 Then
                Return Me.idEntrada.ToString()
            ElseIf index = 2 Then
                Return Me.idArticulo.ToString()
            ElseIf index = 3 Then
                Return Me.cantidad.ToString()
            ElseIf index = 4 Then
                Return Me.costo.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idEntradaDetalle = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntradaDetalle = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idEntrada = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntrada = System.Int32.Parse("0")
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
                    Me.costo = System.Decimal.Parse("0" & value)
                Catch
                    Me.costo = System.Decimal.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idEntradaDetalle" Then
                Return Me.idEntradaDetalle.ToString()
            ElseIf index = "idEntrada" Then
                Return Me.idEntrada.ToString()
            ElseIf index = "idArticulo" Then
                Return Me.idArticulo.ToString()
            ElseIf index = "cantidad" Then
                Return Me.cantidad.ToString()
            ElseIf index = "costo" Then
                Return Me.costo.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idEntradaDetalle" Then
                Try
                    Me.idEntradaDetalle = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntradaDetalle = System.Int32.Parse("0")
                End Try
            ElseIf index = "idEntrada" Then
                Try
                    Me.idEntrada = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntrada = System.Int32.Parse("0")
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
            ElseIf index = "costo" Then
                Try
                    Me.costo = System.Decimal.Parse("0" & value)
                Catch
                    Me.costo = System.Decimal.Parse("0")
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblEntradasDetalle"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsEntradasDetalle
    Private Shared Function row2clsEntradasDetalle(ByVal r As DataRow) As clsEntradasDetalle
        ' asigna a un objeto clsEntradasDetalle los datos del dataRow indicado
        Dim oclsEntradasDetalle As New clsEntradasDetalle
        '
        oclsEntradasDetalle.idEntradaDetalle = System.Int32.Parse("0" & r("idEntradaDetalle").ToString())
        oclsEntradasDetalle.idEntrada = System.Int32.Parse("0" & r("idEntrada").ToString())
        oclsEntradasDetalle.idArticulo = System.Int32.Parse("0" & r("idArticulo").ToString())
        oclsEntradasDetalle.cantidad = System.Int16.Parse("0" & r("cantidad").ToString())
        oclsEntradasDetalle.costo = System.Decimal.Parse("0" & r("costo").ToString())
        '
        Return oclsEntradasDetalle
    End Function
    '
    ' asigna un objeto clsEntradasDetalle a la fila indicada
    Private Shared Sub clsEntradasDetalle2Row(ByVal oclsEntradasDetalle As clsEntradasDetalle, ByVal r As DataRow)
        ' asigna un objeto clsEntradasDetalle al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idEntradaDetalle") = oclsEntradasDetalle.idEntradaDetalle
        r("idEntrada") = oclsEntradasDetalle.idEntrada
        r("idArticulo") = oclsEntradasDetalle.idArticulo
        r("cantidad") = oclsEntradasDetalle.cantidad
        r("costo") = oclsEntradasDetalle.costo
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsEntradasDetalle
    Private Shared Sub nuevoclsEntradasDetalle(ByVal dt As DataTable, ByVal oclsEntradasDetalle As clsEntradasDetalle)
        ' Crear un nuevo clsEntradasDetalle
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsEntradasDetalle = row2clsEntradasDetalle(dr)
        '
        oc.idEntradaDetalle = oclsEntradasDetalle.idEntradaDetalle
        oc.idEntrada = oclsEntradasDetalle.idEntrada
        oc.idArticulo = oclsEntradasDetalle.idArticulo
        oc.cantidad = oclsEntradasDetalle.cantidad
        oc.costo = oclsEntradasDetalle.costo
        '
        clsEntradasDetalle2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblEntradasDetalle
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradasDetalle")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsEntradasDetalle
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsEntradasDetalle As clsEntradasDetalle = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradasDetalle")
        Dim sel As String = "SELECT * FROM tblEntradasDetalle WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsEntradasDetalle = row2clsEntradasDetalle(dt.Rows(0))
        End If
        Return oclsEntradasDetalle
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idEntradaDetalle existe en la tabla.
    '             TODO: Si en lugar de idEntradaDetalle usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idEntradaDetalle que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblEntradasDetalle WHERE idEntradaDetalle = " & Me.idEntradaDetalle.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradasDetalle")
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
        '       Yo compruebo que sea un campo llamado idEntradaDetalle, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idEntradaDetalle) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblEntradasDetalle SET idEntrada = @idEntrada, idArticulo = @idArticulo, cantidad = @cantidad, costo = @costo  WHERE (idEntradaDetalle = @idEntradaDetalle)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEntradaDetalle", SqlDbType.Int, 0, "idEntradaDetalle")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEntrada", SqlDbType.Int, 0, "idEntrada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idArticulo", SqlDbType.Int, 0, "idArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.SmallInt, 0, "cantidad")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@costo", SqlDbType.Decimal, 0, "costo")
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
            clsEntradasDetalle2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsEntradasDetalle")
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
        '       Yo compruebo que sea un campo llamado idEntradaDetalle, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblEntradasDetalle (idEntrada, idArticulo, cantidad, costo)  VALUES(@idEntrada, @idArticulo, @cantidad, @costo)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEntradaDetalle", SqlDbType.Int, 0, "idEntradaDetalle")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEntrada", SqlDbType.Int, 0, "idEntrada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idArticulo", SqlDbType.Int, 0, "idArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@cantidad", SqlDbType.SmallInt, 0, "cantidad")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@costo", SqlDbType.Decimal, 0, "costo")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsEntradasDetalle(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsEntradasDetalle"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idEntradaDetalle que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblEntradasDetalle WHERE idEntradaDetalle = " & Me.idEntradaDetalle.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradasDetalle")
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
        '       Yo compruebo que sea un campo llamado idEntradaDetalle, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblEntradasDetalle WHERE (idEntradaDetalle = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idEntradaDetalle")
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
