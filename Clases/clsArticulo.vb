'------------------------------------------------------------------------------
' Clase clsArticulo generada automáticamente con CrearClaseSQL
' de la tabla 'tblArticulo' de la base 'data'
' Fecha: 25/ago/2012 19:57:54
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
Public Class clsArticulo
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idArticulo As System.Int32
    Private _idOrigen As System.Int16
    Private _idTipoArticulo As System.Int16
    Private _idAplicacion As System.Int16
    Private _idMarca As System.Int16
    Private _codigo As System.String
    Private _codigoEquivalente As System.String
    Private _nombre As System.String
    Private _costo As System.Decimal
    Private _minimo As System.Int32
    Private _fechaUltimaCompra As System.DateTime
    Private _fechaCrea As System.DateTime
    Private _idUsuario As System.Int16
    Private _ubi1 As System.String
    Private _ubi2 As System.String
    Private _categoria As System.String
    Private _asignaPrecio As System.Boolean
    Private _precio As System.Decimal
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
    Public Property idArticulo() As System.Int32
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As System.Int32)
            _idArticulo = value
        End Set
    End Property
    Public Property idOrigen() As System.Int16
        Get
            Return _idOrigen
        End Get
        Set(ByVal value As System.Int16)
            _idOrigen = value
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
    Public Property idAplicacion() As System.Int16
        Get
            Return _idAplicacion
        End Get
        Set(ByVal value As System.Int16)
            _idAplicacion = value
        End Set
    End Property
    Public Property idMarca() As System.Int16
        Get
            Return _idMarca
        End Get
        Set(ByVal value As System.Int16)
            _idMarca = value
        End Set
    End Property
    Public Property codigo() As System.String
        Get
            Return ajustarAncho(_codigo, 50)
        End Get
        Set(ByVal value As System.String)
            _codigo = value
        End Set
    End Property
    Public Property codigoEquivalente() As System.String
        Get
            Return ajustarAncho(_codigoEquivalente, 50)
        End Get
        Set(ByVal value As System.String)
            _codigoEquivalente = value
        End Set
    End Property
    Public Property nombre() As System.String
        Get
            Return ajustarAncho(_nombre, 200)
        End Get
        Set(ByVal value As System.String)
            _nombre = value
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
    Public Property minimo() As System.Int32
        Get
            Return _minimo
        End Get
        Set(ByVal value As System.Int32)
            _minimo = value
        End Set
    End Property
    Public Property fechaUltimaCompra() As System.DateTime
        Get
            Return _fechaUltimaCompra
        End Get
        Set(ByVal value As System.DateTime)
            _fechaUltimaCompra = value
        End Set
    End Property
    Public Property fechaCrea() As System.DateTime
        Get
            Return _fechaCrea
        End Get
        Set(ByVal value As System.DateTime)
            _fechaCrea = value
        End Set
    End Property
    Public Property idUsuario() As System.Int16
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As System.Int16)
            _idUsuario = value
        End Set
    End Property
    Public Property ubi1() As System.String
        Get
            Return ajustarAncho(_ubi1, 2)
        End Get
        Set(ByVal value As System.String)
            _ubi1 = value
        End Set
    End Property
    Public Property ubi2() As System.String
        Get
            Return ajustarAncho(_ubi2, 2)
        End Get
        Set(ByVal value As System.String)
            _ubi2 = value
        End Set
    End Property
    Public Property categoria() As System.String
        Get
            Return ajustarAncho(_categoria, 50)
        End Get
        Set(ByVal value As System.String)
            _categoria = value
        End Set
    End Property
    Public Property asignaPrecio() As System.Boolean
        Get
            Return _asignaPrecio
        End Get
        Set(ByVal value As System.Boolean)
            _asignaPrecio = value
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
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idArticulo.ToString()
            ElseIf index = 1 Then
                Return Me.idOrigen.ToString()
            ElseIf index = 2 Then
                Return Me.idTipoArticulo.ToString()
            ElseIf index = 3 Then
                Return Me.idAplicacion.ToString()
            ElseIf index = 4 Then
                Return Me.idMarca.ToString()
            ElseIf index = 5 Then
                Return Me.codigo.ToString()
            ElseIf index = 6 Then
                Return Me.codigoEquivalente.ToString()
            ElseIf index = 7 Then
                Return Me.nombre.ToString()
            ElseIf index = 8 Then
                Return Me.costo.ToString()
            ElseIf index = 9 Then
                Return Me.minimo.ToString()
            ElseIf index = 10 Then
                Return Me.fechaUltimaCompra.ToString()
            ElseIf index = 11 Then
                Return Me.fechaCrea.ToString()
            ElseIf index = 12 Then
                Return Me.idUsuario.ToString()
            ElseIf index = 13 Then
                Return Me.ubi1.ToString()
            ElseIf index = 14 Then
                Return Me.ubi2.ToString()
            ElseIf index = 15 Then
                Return Me.categoria.ToString()
            ElseIf index = 16 Then
                Return Me.asignaPrecio.ToString()
            ElseIf index = 17 Then
                Return Me.precio.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idArticulo = System.Int32.Parse("0" & value)
                Catch
                    Me.idArticulo = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idOrigen = System.Int16.Parse("0" & value)
                Catch
                    Me.idOrigen = System.Int16.Parse("0")
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idTipoArticulo = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoArticulo = System.Int16.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.idAplicacion = System.Int16.Parse("0" & value)
                Catch
                    Me.idAplicacion = System.Int16.Parse("0")
                End Try
            ElseIf index = 4 Then
                Try
                    Me.idMarca = System.Int16.Parse("0" & value)
                Catch
                    Me.idMarca = System.Int16.Parse("0")
                End Try
            ElseIf index = 5 Then
                Me.codigo = value
            ElseIf index = 6 Then
                Me.codigoEquivalente = value
            ElseIf index = 7 Then
                Me.nombre = value
            ElseIf index = 8 Then
                Try
                    Me.costo = System.Decimal.Parse("0" & value)
                Catch
                    Me.costo = System.Decimal.Parse("0")
                End Try
            ElseIf index = 9 Then
                Try
                    Me.minimo = System.Int32.Parse("0" & value)
                Catch
                    Me.minimo = System.Int32.Parse("0")
                End Try
            ElseIf index = 10 Then
                Try
                    Me.fechaUltimaCompra = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaUltimaCompra = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaUltimaCompra = System.DateTime.Now
                End Try
            ElseIf index = 11 Then
                Try
                    Me.fechaCrea = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaCrea = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaCrea = System.DateTime.Now
                End Try
            ElseIf index = 12 Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = 13 Then
                Me.ubi1 = value
            ElseIf index = 14 Then
                Me.ubi2 = value
            ElseIf index = 15 Then
                Me.categoria = value
            ElseIf index = 16 Then
                Try
                    Me.asignaPrecio = System.Boolean.Parse(value)
                Catch
                    Me.asignaPrecio = False
                End Try
            ElseIf index = 17 Then
                Try
                    Me.precio = System.Decimal.Parse("0" & value)
                Catch
                    Me.precio = System.Decimal.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idArticulo" Then
                Return Me.idArticulo.ToString()
            ElseIf index = "idOrigen" Then
                Return Me.idOrigen.ToString()
            ElseIf index = "idTipoArticulo" Then
                Return Me.idTipoArticulo.ToString()
            ElseIf index = "idAplicacion" Then
                Return Me.idAplicacion.ToString()
            ElseIf index = "idMarca" Then
                Return Me.idMarca.ToString()
            ElseIf index = "codigo" Then
                Return Me.codigo.ToString()
            ElseIf index = "codigoEquivalente" Then
                Return Me.codigoEquivalente.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "costo" Then
                Return Me.costo.ToString()
            ElseIf index = "minimo" Then
                Return Me.minimo.ToString()
            ElseIf index = "fechaUltimaCompra" Then
                Return Me.fechaUltimaCompra.ToString()
            ElseIf index = "fechaCrea" Then
                Return Me.fechaCrea.ToString()
            ElseIf index = "idUsuario" Then
                Return Me.idUsuario.ToString()
            ElseIf index = "ubi1" Then
                Return Me.ubi1.ToString()
            ElseIf index = "ubi2" Then
                Return Me.ubi2.ToString()
            ElseIf index = "categoria" Then
                Return Me.categoria.ToString()
            ElseIf index = "asignaPrecio" Then
                Return Me.asignaPrecio.ToString()
            ElseIf index = "precio" Then
                Return Me.precio.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idArticulo" Then
                Try
                    Me.idArticulo = System.Int32.Parse("0" & value)
                Catch
                    Me.idArticulo = System.Int32.Parse("0")
                End Try
            ElseIf index = "idOrigen" Then
                Try
                    Me.idOrigen = System.Int16.Parse("0" & value)
                Catch
                    Me.idOrigen = System.Int16.Parse("0")
                End Try
            ElseIf index = "idTipoArticulo" Then
                Try
                    Me.idTipoArticulo = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoArticulo = System.Int16.Parse("0")
                End Try
            ElseIf index = "idAplicacion" Then
                Try
                    Me.idAplicacion = System.Int16.Parse("0" & value)
                Catch
                    Me.idAplicacion = System.Int16.Parse("0")
                End Try
            ElseIf index = "idMarca" Then
                Try
                    Me.idMarca = System.Int16.Parse("0" & value)
                Catch
                    Me.idMarca = System.Int16.Parse("0")
                End Try
            ElseIf index = "codigo" Then
                Me.codigo = value
            ElseIf index = "codigoEquivalente" Then
                Me.codigoEquivalente = value
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "costo" Then
                Try
                    Me.costo = System.Decimal.Parse("0" & value)
                Catch
                    Me.costo = System.Decimal.Parse("0")
                End Try
            ElseIf index = "minimo" Then
                Try
                    Me.minimo = System.Int32.Parse("0" & value)
                Catch
                    Me.minimo = System.Int32.Parse("0")
                End Try
            ElseIf index = "fechaUltimaCompra" Then
                Try
                    Me.fechaUltimaCompra = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaUltimaCompra = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaUltimaCompra = System.DateTime.Now
                End Try
            ElseIf index = "fechaCrea" Then
                Try
                    Me.fechaCrea = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaCrea = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaCrea = System.DateTime.Now
                End Try
            ElseIf index = "idUsuario" Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = "ubi1" Then
                Me.ubi1 = value
            ElseIf index = "ubi2" Then
                Me.ubi2 = value
            ElseIf index = "categoria" Then
                Me.categoria = value
            ElseIf index = "asignaPrecio" Then
                Try
                    Me.asignaPrecio = System.Boolean.Parse(value)
                Catch
                    Me.asignaPrecio = False
                End Try
            ElseIf index = "precio" Then
                Try
                    Me.precio = System.Decimal.Parse("0" & value)
                Catch
                    Me.precio = System.Decimal.Parse("0")
                End Try
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblArticulo"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsArticulo
    Private Shared Function row2clsArticulo(ByVal r As DataRow) As clsArticulo
        ' asigna a un objeto clsArticulo los datos del dataRow indicado
        Dim oclsArticulo As New clsArticulo
        '
        oclsArticulo.idArticulo = System.Int32.Parse("0" & r("idArticulo").ToString())
        oclsArticulo.idOrigen = System.Int16.Parse("0" & r("idOrigen").ToString())
        oclsArticulo.idTipoArticulo = System.Int16.Parse("0" & r("idTipoArticulo").ToString())
        oclsArticulo.idAplicacion = System.Int16.Parse("0" & r("idAplicacion").ToString())
        oclsArticulo.idMarca = System.Int16.Parse("0" & r("idMarca").ToString())
        oclsArticulo.codigo = r("codigo").ToString()
        oclsArticulo.codigoEquivalente = r("codigoEquivalente").ToString()
        oclsArticulo.nombre = r("nombre").ToString()
        oclsArticulo.costo = System.Decimal.Parse("0" & r("costo").ToString())
        oclsArticulo.minimo = System.Int32.Parse("0" & r("minimo").ToString())
        Try
            oclsArticulo.fechaUltimaCompra = DateTime.Parse(r("fechaUltimaCompra").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsArticulo.fechaUltimaCompra = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsArticulo.fechaUltimaCompra = DateTime.Now
        End Try
        Try
            oclsArticulo.fechaCrea = DateTime.Parse(r("fechaCrea").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsArticulo.fechaCrea = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsArticulo.fechaCrea = DateTime.Now
        End Try
        oclsArticulo.idUsuario = System.Int16.Parse("0" & r("idUsuario").ToString())
        oclsArticulo.ubi1 = r("ubi1").ToString()
        oclsArticulo.ubi2 = r("ubi2").ToString()
        oclsArticulo.categoria = r("categoria").ToString()
        Try
            oclsArticulo.asignaPrecio = System.Boolean.Parse(r("asignaPrecio").ToString())
        Catch
            oclsArticulo.asignaPrecio = False
        End Try
        oclsArticulo.precio = System.Decimal.Parse("0" & r("precio").ToString())
        '
        Return oclsArticulo
    End Function
    '
    ' asigna un objeto clsArticulo a la fila indicada
    Private Shared Sub clsArticulo2Row(ByVal oclsArticulo As clsArticulo, ByVal r As DataRow)
        ' asigna un objeto clsArticulo al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idArticulo") = oclsArticulo.idArticulo
        r("idOrigen") = oclsArticulo.idOrigen
        r("idTipoArticulo") = oclsArticulo.idTipoArticulo
        r("idAplicacion") = oclsArticulo.idAplicacion
        r("idMarca") = oclsArticulo.idMarca
        r("codigo") = oclsArticulo.codigo
        r("codigoEquivalente") = oclsArticulo.codigoEquivalente
        r("nombre") = oclsArticulo.nombre
        r("costo") = oclsArticulo.costo
        r("minimo") = oclsArticulo.minimo
        r("fechaUltimaCompra") = oclsArticulo.fechaUltimaCompra
        r("fechaCrea") = oclsArticulo.fechaCrea
        r("idUsuario") = oclsArticulo.idUsuario
        r("ubi1") = oclsArticulo.ubi1
        r("ubi2") = oclsArticulo.ubi2
        r("categoria") = oclsArticulo.categoria
        r("asignaPrecio") = oclsArticulo.asignaPrecio
        r("precio") = oclsArticulo.precio
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsArticulo
    Private Shared Sub nuevoclsArticulo(ByVal dt As DataTable, ByVal oclsArticulo As clsArticulo)
        ' Crear un nuevo clsArticulo
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsArticulo = row2clsArticulo(dr)
        '
        oc.idArticulo = oclsArticulo.idArticulo
        oc.idOrigen = oclsArticulo.idOrigen
        oc.idTipoArticulo = oclsArticulo.idTipoArticulo
        oc.idAplicacion = oclsArticulo.idAplicacion
        oc.idMarca = oclsArticulo.idMarca
        oc.codigo = oclsArticulo.codigo
        oc.codigoEquivalente = oclsArticulo.codigoEquivalente
        oc.nombre = oclsArticulo.nombre
        oc.costo = oclsArticulo.costo
        oc.minimo = oclsArticulo.minimo
        oc.fechaUltimaCompra = oclsArticulo.fechaUltimaCompra
        oc.fechaCrea = oclsArticulo.fechaCrea
        oc.idUsuario = oclsArticulo.idUsuario
        oc.ubi1 = oclsArticulo.ubi1
        oc.ubi2 = oclsArticulo.ubi2
        oc.categoria = oclsArticulo.categoria
        oc.asignaPrecio = oclsArticulo.asignaPrecio
        oc.precio = oclsArticulo.precio
        '
        clsArticulo2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblArticulo
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsArticulo")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsArticulo
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsArticulo As clsArticulo = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsArticulo")
        Dim sel As String = "SELECT * FROM tblArticulo WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsArticulo = row2clsArticulo(dt.Rows(0))
        End If
        Return oclsArticulo
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idArticulo existe en la tabla.
    '             TODO: Si en lugar de idArticulo usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idArticulo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblArticulo WHERE idArticulo = " & Me.idArticulo.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsArticulo")
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
        '       Yo compruebo que sea un campo llamado idArticulo, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idArticulo) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblArticulo SET idOrigen = @idOrigen, idTipoArticulo = @idTipoArticulo, idAplicacion = @idAplicacion, idMarca = @idMarca, codigo = @codigo, codigoEquivalente = @codigoEquivalente, nombre = @nombre, costo = @costo, minimo = @minimo, fechaUltimaCompra = @fechaUltimaCompra, fechaCrea = @fechaCrea, idUsuario = @idUsuario, ubi1 = @ubi1, ubi2 = @ubi2, categoria = @categoria, asignaPrecio = @asignaPrecio, precio = @precio  WHERE (idArticulo = @idArticulo)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idArticulo", SqlDbType.Int, 0, "idArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idOrigen", SqlDbType.SmallInt, 0, "idOrigen")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoArticulo", SqlDbType.SmallInt, 0, "idTipoArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idAplicacion", SqlDbType.SmallInt, 0, "idAplicacion")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idMarca", SqlDbType.SmallInt, 0, "idMarca")
        da.UpdateCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "codigo")
        da.UpdateCommand.Parameters.Add("@codigoEquivalente", SqlDbType.NVarChar, 50, "codigoEquivalente")
        da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 200, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@costo", SqlDbType.Decimal, 0, "costo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@minimo", SqlDbType.Int, 0, "minimo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fechaUltimaCompra", SqlDbType.DateTime, 0, "fechaUltimaCompra")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fechaCrea", SqlDbType.DateTime, 0, "fechaCrea")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        da.UpdateCommand.Parameters.Add("@ubi1", SqlDbType.NVarChar, 2, "ubi1")
        da.UpdateCommand.Parameters.Add("@ubi2", SqlDbType.NVarChar, 2, "ubi2")
        da.UpdateCommand.Parameters.Add("@categoria", SqlDbType.NVarChar, 50, "categoria")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@asignaPrecio", SqlDbType.Bit, 0, "asignaPrecio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Decimal, 0, "precio")
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
            clsArticulo2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsArticulo")
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
        '       Yo compruebo que sea un campo llamado idArticulo, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblArticulo (idOrigen, idTipoArticulo, idAplicacion, idMarca, codigo, codigoEquivalente, nombre, costo, minimo, fechaUltimaCompra, fechaCrea, idUsuario, ubi1, ubi2, categoria, asignaPrecio, precio)  VALUES(@idOrigen, @idTipoArticulo, @idAplicacion, @idMarca, @codigo, @codigoEquivalente, @nombre, @costo, @minimo, @fechaUltimaCompra, @fechaCrea, @idUsuario, @ubi1, @ubi2, @categoria, @asignaPrecio, @precio)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idArticulo", SqlDbType.Int, 0, "idArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idOrigen", SqlDbType.SmallInt, 0, "idOrigen")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoArticulo", SqlDbType.SmallInt, 0, "idTipoArticulo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idAplicacion", SqlDbType.SmallInt, 0, "idAplicacion")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idMarca", SqlDbType.SmallInt, 0, "idMarca")
        da.InsertCommand.Parameters.Add("@codigo", SqlDbType.NVarChar, 50, "codigo")
        da.InsertCommand.Parameters.Add("@codigoEquivalente", SqlDbType.NVarChar, 50, "codigoEquivalente")
        da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 200, "nombre")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@costo", SqlDbType.Decimal, 0, "costo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@minimo", SqlDbType.Int, 0, "minimo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fechaUltimaCompra", SqlDbType.DateTime, 0, "fechaUltimaCompra")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fechaCrea", SqlDbType.DateTime, 0, "fechaCrea")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        da.InsertCommand.Parameters.Add("@ubi1", SqlDbType.NVarChar, 2, "ubi1")
        da.InsertCommand.Parameters.Add("@ubi2", SqlDbType.NVarChar, 2, "ubi2")
        da.InsertCommand.Parameters.Add("@categoria", SqlDbType.NVarChar, 50, "categoria")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@asignaPrecio", SqlDbType.Bit, 0, "asignaPrecio")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@precio", SqlDbType.Decimal, 0, "precio")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsArticulo(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsArticulo"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idArticulo que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblArticulo WHERE idArticulo = " & Me.idArticulo.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsArticulo")
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
        '       Yo compruebo que sea un campo llamado idArticulo, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblArticulo WHERE (idArticulo = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idArticulo")
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
