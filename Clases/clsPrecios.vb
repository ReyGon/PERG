'------------------------------------------------------------------------------
' Clase clsPrecios generada automáticamente con CrearClaseSQL
' de la tabla 'tblPrecios' de la base 'data'
' Fecha: 29/jul/2012 19:58:31
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
Public Class clsPrecios
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idPrecio As System.Int16
    Private _nombre As System.String
    Private _porcentaje As System.Decimal
    Private _costoDesde As System.Decimal
    Private _costoHasta As System.Decimal
    Private _aceptaDescuento As System.Boolean
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
    Public Property idPrecio() As System.Int16
        Get
            Return _idPrecio
        End Get
        Set(ByVal value As System.Int16)
            _idPrecio = value
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
    Public Property porcentaje() As System.Decimal
        Get
            Return _porcentaje
        End Get
        Set(ByVal value As System.Decimal)
            _porcentaje = value
        End Set
    End Property
    Public Property costoDesde() As System.Decimal
        Get
            Return _costoDesde
        End Get
        Set(ByVal value As System.Decimal)
            _costoDesde = value
        End Set
    End Property
    Public Property costoHasta() As System.Decimal
        Get
            Return _costoHasta
        End Get
        Set(ByVal value As System.Decimal)
            _costoHasta = value
        End Set
    End Property
    Public Property aceptaDescuento() As System.Boolean
        Get
            Return _aceptaDescuento
        End Get
        Set(ByVal value As System.Boolean)
            _aceptaDescuento = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idPrecio.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.porcentaje.ToString()
            ElseIf index = 3 Then
                Return Me.costoDesde.ToString()
            ElseIf index = 4 Then
                Return Me.costoHasta.ToString()
            ElseIf index = 5 Then
                Return Me.aceptaDescuento.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idPrecio = System.Int16.Parse("0" & value)
                Catch
                    Me.idPrecio = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Try
                    Me.porcentaje = System.Decimal.Parse("0" & value)
                Catch
                    Me.porcentaje = System.Decimal.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.costoDesde = System.Decimal.Parse("0" & value)
                Catch
                    Me.costoDesde = System.Decimal.Parse("0")
                End Try
            ElseIf index = 4 Then
                Try
                    Me.costoHasta = System.Decimal.Parse("0" & value)
                Catch
                    Me.costoHasta = System.Decimal.Parse("0")
                End Try
            ElseIf index = 5 Then
                Try
                    Me.aceptaDescuento = System.Boolean.Parse(value)
                Catch
                    Me.aceptaDescuento = False
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idPrecio" Then
                Return Me.idPrecio.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "porcentaje" Then
                Return Me.porcentaje.ToString()
            ElseIf index = "costoDesde" Then
                Return Me.costoDesde.ToString()
            ElseIf index = "costoHasta" Then
                Return Me.costoHasta.ToString()
            ElseIf index = "aceptaDescuento" Then
                Return Me.aceptaDescuento.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idPrecio" Then
                Try
                    Me.idPrecio = System.Int16.Parse("0" & value)
                Catch
                    Me.idPrecio = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "porcentaje" Then
                Try
                    Me.porcentaje = System.Decimal.Parse("0" & value)
                Catch
                    Me.porcentaje = System.Decimal.Parse("0")
                End Try
            ElseIf index = "costoDesde" Then
                Try
                    Me.costoDesde = System.Decimal.Parse("0" & value)
                Catch
                    Me.costoDesde = System.Decimal.Parse("0")
                End Try
            ElseIf index = "costoHasta" Then
                Try
                    Me.costoHasta = System.Decimal.Parse("0" & value)
                Catch
                    Me.costoHasta = System.Decimal.Parse("0")
                End Try
            ElseIf index = "aceptaDescuento" Then
                Try
                    Me.aceptaDescuento = System.Boolean.Parse(value)
                Catch
                    Me.aceptaDescuento = False
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblPrecios"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsPrecios
    Private Shared Function row2clsPrecios(ByVal r As DataRow) As clsPrecios
        ' asigna a un objeto clsPrecios los datos del dataRow indicado
        Dim oclsPrecios As New clsPrecios
        '
        oclsPrecios.idPrecio = System.Int16.Parse("0" & r("idPrecio").ToString())
        oclsPrecios.nombre = r("nombre").ToString()
        oclsPrecios.porcentaje = System.Decimal.Parse("0" & r("porcentaje").ToString())
        oclsPrecios.costoDesde = System.Decimal.Parse("0" & r("costoDesde").ToString())
        oclsPrecios.costoHasta = System.Decimal.Parse("0" & r("costoHasta").ToString())
        Try
            oclsPrecios.aceptaDescuento = System.Boolean.Parse(r("aceptaDescuento").ToString())
        Catch
            oclsPrecios.aceptaDescuento = False
        End Try
        '
        Return oclsPrecios
    End Function
    '
    ' asigna un objeto clsPrecios a la fila indicada
    Private Shared Sub clsPrecios2Row(ByVal oclsPrecios As clsPrecios, ByVal r As DataRow)
        ' asigna un objeto clsPrecios al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idPrecio") = oclsPrecios.idPrecio
        r("nombre") = oclsPrecios.nombre
        r("porcentaje") = oclsPrecios.porcentaje
        r("costoDesde") = oclsPrecios.costoDesde
        r("costoHasta") = oclsPrecios.costoHasta
        r("aceptaDescuento") = oclsPrecios.aceptaDescuento
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsPrecios
    Private Shared Sub nuevoclsPrecios(ByVal dt As DataTable, ByVal oclsPrecios As clsPrecios)
        ' Crear un nuevo clsPrecios
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsPrecios = row2clsPrecios(dr)
        '
        oc.idPrecio = oclsPrecios.idPrecio
        oc.nombre = oclsPrecios.nombre
        oc.porcentaje = oclsPrecios.porcentaje
        oc.costoDesde = oclsPrecios.costoDesde
        oc.costoHasta = oclsPrecios.costoHasta
        oc.aceptaDescuento = oclsPrecios.aceptaDescuento
        '
        clsPrecios2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblPrecios
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPrecios")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsPrecios
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsPrecios As clsPrecios = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPrecios")
        Dim sel As String = "SELECT * FROM tblPrecios WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsPrecios = row2clsPrecios(dt.Rows(0))
        End If
        Return oclsPrecios
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idPrecio existe en la tabla.
    '             TODO: Si en lugar de idPrecio usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idPrecio que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblPrecios WHERE idPrecio = " & Me.idPrecio.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPrecios")
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
        '       Yo compruebo que sea un campo llamado idPrecio, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idPrecio) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblPrecios SET nombre = @nombre, porcentaje = @porcentaje, costoDesde = @costoDesde, costoHasta = @costoHasta, aceptaDescuento = @aceptaDescuento  WHERE (idPrecio = @idPrecio)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idPrecio", SqlDbType.SmallInt, 0, "idPrecio")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@porcentaje", SqlDbType.Decimal, 0, "porcentaje")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@costoDesde", SqlDbType.Decimal, 0, "costoDesde")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@costoHasta", SqlDbType.Decimal, 0, "costoHasta")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@aceptaDescuento", SqlDbType.Bit, 0, "aceptaDescuento")
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
            clsPrecios2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsPrecios")
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
        '       Yo compruebo que sea un campo llamado idPrecio, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblPrecios (nombre, porcentaje, costoDesde, costoHasta, aceptaDescuento)  VALUES(@nombre, @porcentaje, @costoDesde, @costoHasta, @aceptaDescuento)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idPrecio", SqlDbType.SmallInt, 0, "idPrecio")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 50, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@porcentaje", SqlDbType.Decimal, 0, "porcentaje")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@costoDesde", SqlDbType.Decimal, 0, "costoDesde")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@costoHasta", SqlDbType.Decimal, 0, "costoHasta")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@aceptaDescuento", SqlDbType.Bit, 0, "aceptaDescuento")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsPrecios(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsPrecios"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idPrecio que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblPrecios WHERE idPrecio = " & Me.idPrecio.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsPrecios")
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
        '       Yo compruebo que sea un campo llamado idPrecio, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblPrecios WHERE (idPrecio = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idPrecio")
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
