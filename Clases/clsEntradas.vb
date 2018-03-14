'------------------------------------------------------------------------------
' Clase clsEntradas generada autom�ticamente con CrearClaseSQL
' de la tabla 'tblEntradas' de la base 'data'
' Fecha: 27/ago/2012 22:10:15
'
' �Guillermo 'guille' Som, 2004-2012
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class clsEntradas
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idEntrada As System.Int32
    Private _idEmpresa As System.Int16
    Private _idUsuario As System.Int16
    Private _idTipoMovimiento As System.Int16
    Private _idProveedor As System.Int16
    Private _fecha As System.DateTime
    Private _documento As System.String
    Private _observacion As System.String
    Private _anulado As System.Boolean
    Private _flete As System.Decimal
    Private _total As System.Decimal
    '
    ' Este m�todo se usar� para ajustar los anchos de las propiedades
    Private Function ajustarAncho(ByVal cadena As String, ByVal ancho As Integer) As String
        Dim sb As New System.Text.StringBuilder(New String(" "c, ancho))
        ' devolver la cadena quitando los espacios en blanco
        ' esto asegura que no se devolver� un tama�o mayor ni espacios "extras"
        Return (cadena & sb.ToString()).Substring(0, ancho).Trim()
    End Function
    '
    ' Las propiedades p�blicas
    ' TODO: Revisar los tipos de las propiedades
    Public Property idEntrada() As System.Int32
        Get
            Return _idEntrada
        End Get
        Set(ByVal value As System.Int32)
            _idEntrada = value
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
    Public Property idTipoMovimiento() As System.Int16
        Get
            Return _idTipoMovimiento
        End Get
        Set(ByVal value As System.Int16)
            _idTipoMovimiento = value
        End Set
    End Property
    Public Property idProveedor() As System.Int16
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As System.Int16)
            _idProveedor = value
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
    Public Property documento() As System.String
        Get
            Return ajustarAncho(_documento, 20)
        End Get
        Set(ByVal value As System.String)
            _documento = value
        End Set
    End Property
    Public Property observacion() As System.String
        Get
            Return ajustarAncho(_observacion, 50)
        End Get
        Set(ByVal value As System.String)
            _observacion = value
        End Set
    End Property
    Public Property anulado() As System.Boolean
        Get
            Return _anulado
        End Get
        Set(ByVal value As System.Boolean)
            _anulado = value
        End Set
    End Property
    Public Property flete() As System.Decimal
        Get
            Return _flete
        End Get
        Set(ByVal value As System.Decimal)
            _flete = value
        End Set
    End Property
    Public Property total() As System.Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As System.Decimal)
            _total = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el �ndice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idEntrada.ToString()
            ElseIf index = 1 Then
                Return Me.idEmpresa.ToString()
            ElseIf index = 2 Then
                Return Me.idUsuario.ToString()
            ElseIf index = 3 Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = 4 Then
                Return Me.idProveedor.ToString()
            ElseIf index = 5 Then
                Return Me.fecha.ToString()
            ElseIf index = 6 Then
                Return Me.documento.ToString()
            ElseIf index = 7 Then
                Return Me.observacion.ToString()
            ElseIf index = 8 Then
                Return Me.anulado.ToString()
            ElseIf index = 9 Then
                Return Me.flete.ToString()
            ElseIf index = 10 Then
                Return Me.total.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idEntrada = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntrada = System.Int32.Parse("0")
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
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = 4 Then
                Try
                    Me.idProveedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idProveedor = System.Int16.Parse("0")
                End Try
            ElseIf index = 5 Then
                Try
                    Me.fecha = System.DateTime.Parse(value)
                Catch
                    ' TODO: Usa el valor de fecha que quieras predeterminar
                    '       Una fecha ficticia:
                    'Me.fecha = New System.DateTime(1900, 1, 1)
                    '       o la fecha de hoy:
                    Me.fecha = System.DateTime.Now
                End Try
            ElseIf index = 6 Then
                Me.documento = value
            ElseIf index = 7 Then
                Me.observacion = value
            ElseIf index = 8 Then
                Try
                    Me.anulado = System.Boolean.Parse(value)
                Catch
                    Me.anulado = False
                End Try
            ElseIf index = 9 Then
                Try
                    Me.flete = System.Decimal.Parse("0" & value)
                Catch
                    Me.flete = System.Decimal.Parse("0")
                End Try
            ElseIf index = 10 Then
                Try
                    Me.total = System.Decimal.Parse("0" & value)
                Catch
                    Me.total = System.Decimal.Parse("0")
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el �ndice corresponde al nombre de la columna)
        Get
            If index = "idEntrada" Then
                Return Me.idEntrada.ToString()
            ElseIf index = "idEmpresa" Then
                Return Me.idEmpresa.ToString()
            ElseIf index = "idUsuario" Then
                Return Me.idUsuario.ToString()
            ElseIf index = "idTipoMovimiento" Then
                Return Me.idTipoMovimiento.ToString()
            ElseIf index = "idProveedor" Then
                Return Me.idProveedor.ToString()
            ElseIf index = "fecha" Then
                Return Me.fecha.ToString()
            ElseIf index = "documento" Then
                Return Me.documento.ToString()
            ElseIf index = "observacion" Then
                Return Me.observacion.ToString()
            ElseIf index = "anulado" Then
                Return Me.anulado.ToString()
            ElseIf index = "flete" Then
                Return Me.flete.ToString()
            ElseIf index = "total" Then
                Return Me.total.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idEntrada" Then
                Try
                    Me.idEntrada = System.Int32.Parse("0" & value)
                Catch
                    Me.idEntrada = System.Int32.Parse("0")
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
            ElseIf index = "idTipoMovimiento" Then
                Try
                    Me.idTipoMovimiento = System.Int16.Parse("0" & value)
                Catch
                    Me.idTipoMovimiento = System.Int16.Parse("0")
                End Try
            ElseIf index = "idProveedor" Then
                Try
                    Me.idProveedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idProveedor = System.Int16.Parse("0")
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
            ElseIf index = "documento" Then
                Me.documento = value
            ElseIf index = "observacion" Then
                Me.observacion = value
            ElseIf index = "anulado" Then
                Try
                    Me.anulado = System.Boolean.Parse(value)
                Catch
                    Me.anulado = False
                End Try
            ElseIf index = "flete" Then
                Try
                    Me.flete = System.Decimal.Parse("0" & value)
                Catch
                    Me.flete = System.Decimal.Parse("0")
                End Try
            ElseIf index = "total" Then
                Try
                    Me.total = System.Decimal.Parse("0" & value)
                Catch
                    Me.total = System.Decimal.Parse("0")
                End Try
            End If
        End Set
    End Property
    '
    ' Campos y m�todos compartidos (est�ticos) para gestionar la base de datos
    '
    ' La cadena de conexi�n a la base de datos
    Private Shared cadenaConexion As String = mdlPublicVars.cnn
    ' La cadena de selecci�n
    Public Shared CadenaSelect As String = "SELECT * FROM tblEntradas"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' M�todos compartidos (est�ticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsEntradas
    Private Shared Function row2clsEntradas(ByVal r As DataRow) As clsEntradas
        ' asigna a un objeto clsEntradas los datos del dataRow indicado
        Dim oclsEntradas As New clsEntradas
        '
        oclsEntradas.idEntrada = System.Int32.Parse("0" & r("idEntrada").ToString())
        oclsEntradas.idEmpresa = System.Int16.Parse("0" & r("idEmpresa").ToString())
        oclsEntradas.idUsuario = System.Int16.Parse("0" & r("idUsuario").ToString())
        oclsEntradas.idTipoMovimiento = System.Int16.Parse("0" & r("idTipoMovimiento").ToString())
        oclsEntradas.idProveedor = System.Int16.Parse("0" & r("idProveedor").ToString())
        Try
            oclsEntradas.fecha = DateTime.Parse(r("fecha").ToString())
        Catch
            ' TODO: Usa el valor de fecha que quieras predeterminar
            '       Una fecha ficticia:
            'oclsEntradas.fecha = New DateTime(1900, 1, 1)
            '       o la fecha de hoy:
            oclsEntradas.fecha = DateTime.Now
        End Try
        oclsEntradas.documento = r("documento").ToString()
        oclsEntradas.observacion = r("observacion").ToString()
        Try
            oclsEntradas.anulado = System.Boolean.Parse(r("anulado").ToString())
        Catch
            oclsEntradas.anulado = False
        End Try
        oclsEntradas.flete = System.Decimal.Parse("0" & r("flete").ToString())
        oclsEntradas.total = System.Decimal.Parse("0" & r("total").ToString())
        '
        Return oclsEntradas
    End Function
    '
    ' asigna un objeto clsEntradas a la fila indicada
    Private Shared Sub clsEntradas2Row(ByVal oclsEntradas As clsEntradas, ByVal r As DataRow)
        ' asigna un objeto clsEntradas al dataRow indicado
        ' TODO: Comprueba si esta asignaci�n debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o �nico
        'r("idEntrada") = oclsEntradas.idEntrada
        r("idEmpresa") = oclsEntradas.idEmpresa
        r("idUsuario") = oclsEntradas.idUsuario
        r("idTipoMovimiento") = oclsEntradas.idTipoMovimiento
        r("idProveedor") = oclsEntradas.idProveedor
        r("fecha") = oclsEntradas.fecha
        r("documento") = oclsEntradas.documento
        r("observacion") = oclsEntradas.observacion
        r("anulado") = oclsEntradas.anulado
        r("flete") = oclsEntradas.flete
        r("total") = oclsEntradas.total
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsEntradas
    Private Shared Sub nuevoclsEntradas(ByVal dt As DataTable, ByVal oclsEntradas As clsEntradas)
        ' Crear un nuevo clsEntradas
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsEntradas = row2clsEntradas(dr)
        '
        oc.idEntrada = oclsEntradas.idEntrada
        oc.idEmpresa = oclsEntradas.idEmpresa
        oc.idUsuario = oclsEntradas.idUsuario
        oc.idTipoMovimiento = oclsEntradas.idTipoMovimiento
        oc.idProveedor = oclsEntradas.idProveedor
        oc.fecha = oclsEntradas.fecha
        oc.documento = oclsEntradas.documento
        oc.observacion = oclsEntradas.observacion
        oc.anulado = oclsEntradas.anulado
        oc.flete = oclsEntradas.flete
        oc.total = oclsEntradas.total
        '
        clsEntradas2Row(oc, dr)
        '
        dt.Rows.Add(dr)
    End Sub
    '
    ' M�todos p�blicos
    '
    ' devuelve una tabla con los datos indicados en la cadena de selecci�n
    Public Shared Function Tabla() As DataTable
        Return Tabla(CadenaSelect)
    End Function
    Public Shared Function Tabla(ByVal sel As String) As DataTable
        ' devuelve una tabla con los datos de la tabla tblEntradas
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradas")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsEntradas
        ' Busca en la tabla los datos indicados en el par�metro
        ' el par�metro contendr� lo que se usar� despu�s del WHERE
        Dim oclsEntradas As clsEntradas = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradas")
        Dim sel As String = "SELECT * FROM tblEntradas WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsEntradas = row2clsEntradas(dt.Rows(0))
        End If
        Return oclsEntradas
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se crear� uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idEntrada existe en la tabla.
    '             TODO: Si en lugar de idEntrada usas otro campo, indicalo en la cadena SELECT
    '                   Tambi�n puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aqu� la selecci�n a realizar para acceder a este registro
        '       yo uso el idEntrada que es el identificador �nico de cada registro
        Dim sel As String = "SELECT * FROM tblEntradas WHERE idEntrada = " & Me.idEntrada.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El par�metro, que es una cadena de selecci�n, indicar� el criterio de actualizaci�n
        '
        ' En caso de error, devolver� la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradas")
        '
        cnn = New SqlConnection(cadenaConexion)
        'da = New SqlDataAdapter(CadenaSelect, cnn)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la m�s �ptima, pero funcionar�
        '-------------------------------------------
        'Dim cb As New SqlCommandBuilder(da)
        'da.UpdateCommand = cb.GetUpdateCommand()
        '
        '--------------------------------------------------------------------
        ' Esta est� m�s optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        Dim sCommand As String
        '
        ' El comando UPDATE
        ' TODO: Comprobar cual es el campo de �ndice principal (sin duplicados)
        '       Yo compruebo que sea un campo llamado idEntrada, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idEntrada) ser� el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblEntradas SET idEmpresa = @idEmpresa, idUsuario = @idUsuario, idTipoMovimiento = @idTipoMovimiento, idProveedor = @idProveedor, fecha = @fecha, documento = @documento, observacion = @observacion, anulado = @anulado, flete = @flete, total = @total  WHERE (idEntrada = @idEntrada)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEntrada", SqlDbType.Int, 0, "idEntrada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idProveedor", SqlDbType.SmallInt, 0, "idProveedor")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 0, "fecha")
        da.UpdateCommand.Parameters.Add("@documento", SqlDbType.NVarChar, 20, "documento")
        da.UpdateCommand.Parameters.Add("@observacion", SqlDbType.NVarChar, 50, "observacion")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@anulado", SqlDbType.Bit, 0, "anulado")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@flete", SqlDbType.Decimal, 0, "flete")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@total", SqlDbType.Decimal, 0, "total")
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
            clsEntradas2Row(Me, dt.Rows(0))
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
        ' En caso de error, devolver� la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradas")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(CadenaSelect, cnn)
        'da = New SqlDataAdapter(CadenaSelect, cadenaConexion)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la m�s �ptima, pero funcionar�
        '-------------------------------------------
        'Dim cb As New SqlCommandBuilder(da)
        'da.InsertCommand = cb.GetInsertCommand()
        '
        '--------------------------------------------------------------------
        ' Esta est� m�s optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        Dim sCommand As String
        '
        ' El comando INSERT
        ' TODO: No incluir el campo de clave primaria incremental
        '       Yo compruebo que sea un campo llamado idEntrada, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblEntradas (idEmpresa, idUsuario, idTipoMovimiento, idProveedor, fecha, documento, observacion, anulado, flete, total)  VALUES(@idEmpresa, @idUsuario, @idTipoMovimiento, @idProveedor, @fecha, @documento, @observacion, @anulado, @flete, @total)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEntrada", SqlDbType.Int, 0, "idEntrada")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idEmpresa", SqlDbType.SmallInt, 0, "idEmpresa")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idUsuario", SqlDbType.SmallInt, 0, "idUsuario")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idTipoMovimiento", SqlDbType.SmallInt, 0, "idTipoMovimiento")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idProveedor", SqlDbType.SmallInt, 0, "idProveedor")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@fecha", SqlDbType.DateTime, 0, "fecha")
        da.InsertCommand.Parameters.Add("@documento", SqlDbType.NVarChar, 20, "documento")
        da.InsertCommand.Parameters.Add("@observacion", SqlDbType.NVarChar, 50, "observacion")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@anulado", SqlDbType.Bit, 0, "anulado")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@flete", SqlDbType.Decimal, 0, "flete")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@total", SqlDbType.Decimal, 0, "total")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsEntradas(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsEntradas"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aqu� la selecci�n a realizar para acceder a este registro
        '       yo uso el idEntrada que es el identificador �nico de cada registro
        Dim sel As String = "SELECT * FROM tblEntradas WHERE idEntrada = " & Me.idEntrada.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolver� la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsEntradas")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '
        '-------------------------------------------
        ' Esta no es la m�s �ptima, pero funcionar�
        '-------------------------------------------
        'Dim cb As New SqlCommandBuilder(da)
        'da.DeleteCommand = cb.GetDeleteCommand()
        '
        '
        '--------------------------------------------------------------------
        ' Esta est� m�s optimizada pero debes comprobar que funciona bien...
        '--------------------------------------------------------------------
        Dim sCommand As String
        '
        ' El comando DELETE
        ' TODO: S�lo incluir el campo de clave primaria incremental
        '       Yo compruebo que sea un campo llamado idEntrada, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblEntradas WHERE (idEntrada = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idEntrada")
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
