'------------------------------------------------------------------------------
' Clase clsSalida generada automáticamente con CrearClaseSQL
' de la tabla 'tblSalida' de la base 'laFuente'
' Fecha: 01/may/2008 09:57:18
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
Public Class clsSalida
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idSalida As System.Int32
    Private _idEmpresa As System.Int16
    Private _idUsuario As System.Int16
    Private _fecha As System.DateTime
    Private _idCliente As System.Int16
    Private _idTipoMovimiento As System.Int16
    Private _documento As System.String
    Private _cerrado As System.Boolean
    Private _documentoFactura As System.String
    Private _observacion As System.String
    Private _idVendedor As System.Int16
    Private _fechaFactura As System.DateTime
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
    Public Property idSalida() As System.Int32
        Get
            Return _idSalida
        End Get
        Set(ByVal value As System.Int32)
            _idSalida = value
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
    Public Property idUsuario() As System.Int16
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As System.Int16)
            _idUsuario = value
        End Set
    End Property
    Public Property fecha() As System.DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As System.DateTime)
            _fecha = value
        End Set
    End Property
    Public Property idCliente() As System.Int16
        Get
            Return _idCliente
        End Get
        Set(ByVal value As System.Int16)
            _idCliente = value
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
    Public Property documento() As System.String
        Get
            Return ajustarAncho(_documento, 20)
        End Get
        Set(ByVal value As System.String)
            _documento = value
        End Set
    End Property
    Public Property cerrado() As System.Boolean
        Get
            Return _cerrado
        End Get
        Set(ByVal value As System.Boolean)
            _cerrado = value
        End Set
    End Property
    Public Property documentoFactura() As System.String
        Get
            Return ajustarAncho(_documentoFactura, 20)
        End Get
        Set(ByVal value As System.String)
            _documentoFactura = value
        End Set
    End Property
    Public Property observacion() As System.String
        Get
            Return ajustarAncho(_observacion, 200)
        End Get
        Set(ByVal value As System.String)
            _observacion = value
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
    Public Property fechaFactura() As System.DateTime
        Get
            Return _fechaFactura
        End Get
        Set(ByVal value As System.DateTime)
            _fechaFactura = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idSalida.ToString()
            ElseIf index = 1 Then
                Return Me.idEmpresa.ToString()
            ElseIf index = 2 Then
                Return Me.idUsuario.ToString()
            ElseIf index = 3 Then
                Return Me.fecha.ToString()
            ElseIf index = 4 Then
                Return Me.idCliente.ToString()
            ElseIf index = 5 Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = 6 Then
                Return Me.documento.ToString()
            ElseIf index = 7 Then
                Return Me.cerrado.ToString()
            ElseIf index = 8 Then
                Return Me.documentoFactura.ToString()
            ElseIf index = 9 Then
                Return Me.observacion.ToString()
            ElseIf index = 10 Then
                Return Me.idVendedor.ToString()
            ElseIf index = 11 Then
                Return Me.fechaFactura.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idSalida = System.Int32.Parse("0" & value)
                Catch
                    Me.idSalida = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idEmpresa = System.Int16.Parse("0" & value)
                Catch
                    Me.idEmpresa = System.Int16.Parse("0")
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.fecha = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fecha = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fecha = System.DateTime.Now
                End Try
            ElseIf index = 4 Then
                Try
                    Me.idCliente = System.Int16.Parse("0" & value)
                Catch
                    Me.idCliente = System.Int16.Parse("0")
                End Try
            ElseIf index = 5 Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = 6 Then
                Me.documento = value
            ElseIf index = 7 Then
                Try
                    Me.cerrado = System.Boolean.Parse(value)
                Catch
                    Me.cerrado = False
                End Try
            ElseIf index = 8 Then
                Me.documentoFactura = value
            ElseIf index = 9 Then
                Me.observacion = value
            ElseIf index = 10 Then
                Try
                    Me.idVendedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idVendedor = System.Int16.Parse("0")
                End Try
            ElseIf index = 11 Then
                Try
                    Me.fechaFactura = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaFactura = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaFactura = System.DateTime.Now
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idSalida" Then
                Return Me.idSalida.ToString()
            ElseIf index = "idEmpresa" Then
                Return Me.idEmpresa.ToString()
            ElseIf index = "idUsuario" Then
                Return Me.idUsuario.ToString()
            ElseIf index = "fecha" Then
                Return Me.fecha.ToString()
            ElseIf index = "idCliente" Then
                Return Me.idCliente.ToString()
            ElseIf index = "idTipoMovimiento" Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = "documento" Then
                Return Me.documento.ToString()
            ElseIf index = "cerrado" Then
                Return Me.cerrado.ToString()
            ElseIf index = "documentoFactura" Then
                Return Me.documentoFactura.ToString()
            ElseIf index = "observacion" Then
                Return Me.observacion.ToString()
            ElseIf index = "idVendedor" Then
                Return Me.idVendedor.ToString()
            ElseIf index = "fechaFactura" Then
                Return Me.fechaFactura.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idSalida" Then
                Try
                    Me.idSalida = System.Int32.Parse("0" & value)
                Catch
                    Me.idSalida = System.Int32.Parse("0")
                End Try
            ElseIf index = "idEmpresa" Then
                Try
                    Me.idEmpresa = System.Int16.Parse("0" & value)
                Catch
                    Me.idEmpresa = System.Int16.Parse("0")
                End Try
            ElseIf index = "idUsuario" Then
                Try
                    Me.idUsuario = System.Int16.Parse("0" & value)
                Catch
                    Me.idUsuario = System.Int16.Parse("0")
                End Try
            ElseIf index = "fecha" Then
                Try
                    Me.fecha = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fecha = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fecha = System.DateTime.Now
                End Try
            ElseIf index = "idCliente" Then
                Try
                    Me.idCliente = System.Int16.Parse("0" & value)
                Catch
                    Me.idCliente = System.Int16.Parse("0")
                End Try
            ElseIf index = "idTipoMovimiento" Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = "documento" Then
                Me.documento = value
            ElseIf index = "cerrado" Then
                Try
                    Me.cerrado = System.Boolean.Parse(value)
                Catch
                    Me.cerrado = False
                End Try
            ElseIf index = "documentoFactura" Then
                Me.documentoFactura = value
            ElseIf index = "observacion" Then
                Me.observacion = value
            ElseIf index = "idVendedor" Then
                Try
                    Me.idVendedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idVendedor = System.Int16.Parse("0")
                End Try
            ElseIf index = "fechaFactura" Then
                Try
                    Me.fechaFactura = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fechaFactura = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fechaFactura = System.DateTime.Now
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblSalida"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsSalida
    Private Shared Function row2clsSalida(ByVal r As DataRow) As clsSalida
        ' asigna a un objeto clsSalida los datos del dataRow indicado
        Dim oclsSalida As New clsSalida
        '
        oclsSalida.idSalida = System.Int32.Parse("0" & r("idSalida").ToString())
        oclsSalida.idEmpresa = System.Int16.Parse("0" & r("idEmpresa").ToString())
        oclsSalida.idUsuario = System.Int16.Parse("0" & r("idUsuario").ToString())
        Try
            oclsSalida.fecha = DateTime.Parse(r("fecha").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsSalida.fecha = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsSalida.fecha = DateTime.Now
        End Try
        oclsSalida.idCliente = System.Int16.Parse("0" & r("idCliente").ToString())
        oclsSalida.idTipoMovimiento = System.Int16.Parse("0" & r("idTipoMovimiento").ToString())
        oclsSalida.documento = r("documento").ToString()
        Try
            oclsSalida.cerrado = System.Boolean.Parse(r("cerrado").ToString())
        Catch
            oclsSalida.cerrado = False
        End Try
        oclsSalida.documentoFactura = r("documentoFactura").ToString()
        oclsSalida.observacion = r("observacion").ToString()
        oclsSalida.idVendedor = System.Int16.Parse("0" & r("idVendedor").ToString())
        Try
            oclsSalida.fechaFactura = DateTime.Parse(r("fechaFactura").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsSalida.fechaFactura = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsSalida.fechaFactura = DateTime.Now
        End Try
        '
        Return oclsSalida
    End Function
    '
    ' asigna un objeto clsSalida a la fila indicada
    Private Shared Sub clsSalida2Row(ByVal oclsSalida As clsSalida, ByVal r As DataRow)
        ' asigna un objeto clsSalida al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idSalida") = oclsSalida.idSalida
        r("idEmpresa") = oclsSalida.idEmpresa
        r("idUsuario") = oclsSalida.idUsuario
        r("fecha") = oclsSalida.fecha
        r("idCliente") = oclsSalida.idCliente
        r("idTipoMovimiento") = oclsSalida.idTipoMovimiento
        r("documento") = oclsSalida.documento
        r("cerrado") = oclsSalida.cerrado
        r("documentoFactura") = oclsSalida.documentoFactura
        r("observacion") = oclsSalida.observacion
        r("idVendedor") = oclsSalida.idVendedor
        r("fechaFactura") = oclsSalida.fechaFactura
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsSalida
    Private Shared Sub nuevoclsSalida(ByVal dt As DataTable, ByVal oclsSalida As clsSalida)
        ' Crear un nuevo clsSalida
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsSalida = row2clsSalida(dr)
        '
        oc.idSalida = oclsSalida.idSalida
        oc.idEmpresa = oclsSalida.idEmpresa
        oc.idUsuario = oclsSalida.idUsuario
        oc.fecha = oclsSalida.fecha
        oc.idCliente = oclsSalida.idCliente
        oc.idTipoMovimiento = oclsSalida.idTipoMovimiento
        oc.documento = oclsSalida.documento
        oc.cerrado = oclsSalida.cerrado
        oc.documentoFactura = oclsSalida.documentoFactura
        oc.observacion = oclsSalida.observacion
        oc.idVendedor = oclsSalida.idVendedor
        oc.fechaFactura = oclsSalida.fechaFactura
        '
        clsSalida2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblSalida
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalida")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsSalida
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsSalida As clsSalida = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalida")
        Dim sel As String = "SELECT * FROM tblSalida WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsSalida = row2clsSalida(dt.Rows(0))
        End If
        Return oclsSalida
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idSalida existe en la tabla.
    '             TODO: Si en lugar de idSalida usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idSalida que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblSalida WHERE idSalida = " & Me.idSalida.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalida")
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
        '       Yo compruebo que sea un campo llamado idSalida, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idSalida) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblSalida SET idEmpresa = @idEmpresa, idUsuario = @idUsuario, fecha = @fecha, idCliente = @idCliente, idTipoMovimiento = @idTipoMovimiento, documento = @documento, cerrado = @cerrado, documentoFactura = @documentoFactura, observacion = @observacion, idVendedor = @idVendedor, fechaFactura = @fechaFactura  WHERE (idSalida = @idSalida)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idSalida", SqlDbType.Int, 0, "idSalida")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 0, "fecha")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idCliente", SqlDbType.SmallInt, 0, "idCliente")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        da.UpdateCommand.Parameters.Add("@documento", SqlDbType.NVarChar, 20, "documento")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@cerrado", SqlDbType.Bit, 0, "cerrado")
        da.UpdateCommand.Parameters.Add("@documentoFactura", SqlDbType.NVarChar, 20, "documentoFactura")
        da.UpdateCommand.Parameters.Add("@observacion", SqlDbType.NVarChar, 200, "observacion")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idVendedor", SqlDbType.SmallInt, 0, "idVendedor")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fechaFactura", SqlDbType.DateTime, 0, "fechaFactura")
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
            clsSalida2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsSalida")
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
        '       Yo compruebo que sea un campo llamado idSalida, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblSalida (idEmpresa, idUsuario, fecha, idCliente, idTipoMovimiento, documento, cerrado, documentoFactura, observacion, idVendedor, fechaFactura)  VALUES(@idEmpresa, @idUsuario, @fecha, @idCliente, @idTipoMovimiento, @documento, @cerrado, @documentoFactura, @observacion, @idVendedor, @fechaFactura)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idSalida", SqlDbType.Int, 0, "idSalida")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 0, "fecha")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idCliente", SqlDbType.SmallInt, 0, "idCliente")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        da.InsertCommand.Parameters.Add("@documento", SqlDbType.NVarChar, 20, "documento")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@cerrado", SqlDbType.Bit, 0, "cerrado")
        da.InsertCommand.Parameters.Add("@documentoFactura", SqlDbType.NVarChar, 20, "documentoFactura")
        da.InsertCommand.Parameters.Add("@observacion", SqlDbType.NVarChar, 200, "observacion")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idVendedor", SqlDbType.SmallInt, 0, "idVendedor")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fechaFactura", SqlDbType.DateTime, 0, "fechaFactura")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsSalida(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsSalida"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idSalida que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblSalida WHERE idSalida = " & Me.idSalida.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsSalida")
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
        '       Yo compruebo que sea un campo llamado idSalida, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblSalida WHERE (idSalida = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idSalida")
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
