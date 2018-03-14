'------------------------------------------------------------------------------
' Clase clsProveedor generada automáticamente con CrearClaseSQL
' de la tabla 'tblProveedor' de la base 'posComercial'
' Fecha: 16/oct/2013 16:40:09
'
' ©Guillermo 'guille' Som, 2004-2013
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class clsProveedor
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idProveedor As System.Int16
    Private _nombre As System.String
    Private _direccion As System.String
    Private _telefono As System.String
    Private _habilitado As System.Boolean
    Private _contacto As System.String
    Private _diasCredito As System.Int16
    Private _correoEmpresa As System.String
    Private _correoViajero As System.String
    Private _nit As System.String
    '
    ' Este método se usará para ajustar los anchos de las propiedades
    Private Function ajustarAncho(cadena As String, ancho As Integer) As String
        Dim sb As New System.Text.StringBuilder(New String(" "c, ancho))
        ' devolver la cadena quitando los espacios en blanco
        ' esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        Return (cadena & sb.ToString()).Substring(0, ancho).Trim()
    End Function
    '
    ' Las propiedades públicas
    ' TODO: Revisar los tipos de las propiedades
    Public Property idProveedor() As System.Int16
        Get
            Return  _idProveedor
        End Get
        Set(value As System.Int16)
            _idProveedor = value
        End Set
    End Property
    Public Property nombre() As System.String
        Get
            Return ajustarAncho(_nombre,100)
        End Get
        Set(value As System.String)
            _nombre = value
        End Set
    End Property
    Public Property direccion() As System.String
        Get
            Return ajustarAncho(_direccion,100)
        End Get
        Set(value As System.String)
            _direccion = value
        End Set
    End Property
    Public Property telefono() As System.String
        Get
            Return ajustarAncho(_telefono,50)
        End Get
        Set(value As System.String)
            _telefono = value
        End Set
    End Property
    Public Property habilitado() As System.Boolean
        Get
            Return  _habilitado
        End Get
        Set(value As System.Boolean)
            _habilitado = value
        End Set
    End Property
    Public Property contacto() As System.String
        Get
            Return ajustarAncho(_contacto,200)
        End Get
        Set(value As System.String)
            _contacto = value
        End Set
    End Property
    Public Property diasCredito() As System.Int16
        Get
            Return  _diasCredito
        End Get
        Set(value As System.Int16)
            _diasCredito = value
        End Set
    End Property
    Public Property correoEmpresa() As System.String
        Get
            Return ajustarAncho(_correoEmpresa,100)
        End Get
        Set(value As System.String)
            _correoEmpresa = value
        End Set
    End Property
    Public Property correoViajero() As System.String
        Get
            Return ajustarAncho(_correoViajero,100)
        End Get
        Set(value As System.String)
            _correoViajero = value
        End Set
    End Property
    Public Property nit() As System.String
        Get
            Return ajustarAncho(_nit,15)
        End Get
        Set(value As System.String)
            _nit = value
        End Set
    End Property
    '
    Public Default Property Item(index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idProveedor.ToString()
            ElseIf index = 1 Then
                Return Me.nombre.ToString()
            ElseIf index = 2 Then
                Return Me.direccion.ToString()
            ElseIf index = 3 Then
                Return Me.telefono.ToString()
            ElseIf index = 4 Then
                Return Me.habilitado.ToString()
            ElseIf index = 5 Then
                Return Me.contacto.ToString()
            ElseIf index = 6 Then
                Return Me.diasCredito.ToString()
            ElseIf index = 7 Then
                Return Me.correoEmpresa.ToString()
            ElseIf index = 8 Then
                Return Me.correoViajero.ToString()
            ElseIf index = 9 Then
                Return Me.nit.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(value As String)
            If index = 0 Then
                Try
                    Me.idProveedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idProveedor = System.Int16.Parse("0")
                End Try
            ElseIf index = 1 Then
                Me.nombre = value
            ElseIf index = 2 Then
                Me.direccion = value
            ElseIf index = 3 Then
                Me.telefono = value
            ElseIf index = 4 Then
                Try
                    Me.habilitado = System.Boolean.Parse(value)
                Catch
                    Me.habilitado = False
                End Try
            ElseIf index = 5 Then
                Me.contacto = value
            ElseIf index = 6 Then
                Try
                    Me.diasCredito = System.Int16.Parse("0" & value)
                Catch
                    Me.diasCredito = System.Int16.Parse("0")
                End Try
            ElseIf index = 7 Then
                Me.correoEmpresa = value
            ElseIf index = 8 Then
                Me.correoViajero = value
            ElseIf index = 9 Then
                Me.nit = value
            End If
        End Set
    End Property
    Public Default Property Item(index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idProveedor" Then
                Return Me.idProveedor.ToString()
            ElseIf index = "nombre" Then
                Return Me.nombre.ToString()
            ElseIf index = "direccion" Then
                Return Me.direccion.ToString()
            ElseIf index = "telefono" Then
                Return Me.telefono.ToString()
            ElseIf index = "habilitado" Then
                Return Me.habilitado.ToString()
            ElseIf index = "contacto" Then
                Return Me.contacto.ToString()
            ElseIf index = "diasCredito" Then
                Return Me.diasCredito.ToString()
            ElseIf index = "correoEmpresa" Then
                Return Me.correoEmpresa.ToString()
            ElseIf index = "correoViajero" Then
                Return Me.correoViajero.ToString()
            ElseIf index = "nit" Then
                Return Me.nit.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(value As String)
            If index = "idProveedor" Then
                Try
                    Me.idProveedor = System.Int16.Parse("0" & value)
                Catch
                    Me.idProveedor = System.Int16.Parse("0")
                End Try
            ElseIf index = "nombre" Then
                Me.nombre = value
            ElseIf index = "direccion" Then
                Me.direccion = value
            ElseIf index = "telefono" Then
                Me.telefono = value
            ElseIf index = "habilitado" Then
                Try
                    Me.habilitado = System.Boolean.Parse(value)
                Catch
                    Me.habilitado = False
                End Try
            ElseIf index = "contacto" Then
                Me.contacto = value
            ElseIf index = "diasCredito" Then
                Try
                    Me.diasCredito = System.Int16.Parse("0" & value)
                Catch
                    Me.diasCredito = System.Int16.Parse("0")
                End Try
            ElseIf index = "correoEmpresa" Then
                Me.correoEmpresa = value
            ElseIf index = "correoViajero" Then
                Me.correoViajero = value
            ElseIf index = "nit" Then
                Me.nit = value
            End If
        End Set
    End Property
    '
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = "Data Source=USUARIO-PC\SQL08; Initial Catalog=posComercial; user id=sa; password=GpiSistemas"
    ' La cadena de selección
    Public Shared CadenaSelect As String = "SELECT * FROM tblProveedor"
    '
    Public Sub New()
    End Sub
    Public Sub New(conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsProveedor
    Private Shared Function row2clsProveedor(r As DataRow) As clsProveedor
        ' asigna a un objeto clsProveedor los datos del dataRow indicado
        Dim oclsProveedor As New clsProveedor
        '
        oclsProveedor.idProveedor = System.Int16.Parse("0" & r("idProveedor").ToString())
        oclsProveedor.nombre = r("nombre").ToString()
        oclsProveedor.direccion = r("direccion").ToString()
        oclsProveedor.telefono = r("telefono").ToString()
        Try
            oclsProveedor.habilitado = System.Boolean.Parse(r("habilitado").ToString())
        Catch
            oclsProveedor.habilitado = False
        End Try
        oclsProveedor.contacto = r("contacto").ToString()
        oclsProveedor.diasCredito = System.Int16.Parse("0" & r("diasCredito").ToString())
        oclsProveedor.correoEmpresa = r("correoEmpresa").ToString()
        oclsProveedor.correoViajero = r("correoViajero").ToString()
        oclsProveedor.nit = r("nit").ToString()
        '
        Return oclsProveedor
    End Function
    '
    ' asigna un objeto clsProveedor a la fila indicada
    Private Shared Sub clsProveedor2Row(oclsProveedor As clsProveedor, r As DataRow)
        ' asigna un objeto clsProveedor al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idProveedor") = oclsProveedor.idProveedor
        r("nombre") = oclsProveedor.nombre
        r("direccion") = oclsProveedor.direccion
        r("telefono") = oclsProveedor.telefono
        r("habilitado") = oclsProveedor.habilitado
        r("contacto") = oclsProveedor.contacto
        r("diasCredito") = oclsProveedor.diasCredito
        r("correoEmpresa") = oclsProveedor.correoEmpresa
        r("correoViajero") = oclsProveedor.correoViajero
        r("nit") = oclsProveedor.nit
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsProveedor
    Private Shared Sub nuevoclsProveedor(dt As DataTable, oclsProveedor As clsProveedor)
        ' Crear un nuevo clsProveedor
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsProveedor = row2clsProveedor(dr)
        '
        oc.idProveedor = oclsProveedor.idProveedor
        oc.nombre = oclsProveedor.nombre
        oc.direccion = oclsProveedor.direccion
        oc.telefono = oclsProveedor.telefono
        oc.habilitado = oclsProveedor.habilitado
        oc.contacto = oclsProveedor.contacto
        oc.diasCredito = oclsProveedor.diasCredito
        oc.correoEmpresa = oclsProveedor.correoEmpresa
        oc.correoViajero = oclsProveedor.correoViajero
        oc.nit = oclsProveedor.nit
        '
        clsProveedor2Row(oc, dr)
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
    Public Shared Function Tabla(sel As String) As DataTable
        ' devuelve una tabla con los datos de la tabla tblProveedor
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsProveedor")
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
    Public Shared Function Buscar(sWhere As String) As clsProveedor
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsProveedor As clsProveedor = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsProveedor")
        Dim sel As String = "SELECT * FROM tblProveedor WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsProveedor = row2clsProveedor(dt.Rows(0))
        End If
        Return oclsProveedor
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idProveedor existe en la tabla.
    '             TODO: Si en lugar de idProveedor usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idProveedor que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblProveedor WHERE idProveedor = " & Me.idProveedor.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsProveedor")
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
        ''       Yo compruebo que sea un campo llamado idProveedor, pero en tu caso puede ser otro
        ''       Ese campo, (en mi caso idProveedor) será el que hay que poner al final junto al WHERE.
        'sCommand = "UPDATE tblProveedor SET nombre = @nombre, direccion = @direccion, telefono = @telefono, habilitado = @habilitado, contacto = @contacto, diasCredito = @diasCredito, correoEmpresa = @correoEmpresa, correoViajero = @correoViajero, nit = @nit  WHERE (idProveedor = @idProveedor)"
        'da.UpdateCommand = New SqlCommand(sCommand, cnn)
        '' TODO: Comprobar el tipo de datos a usar...
        'da.UpdateCommand.Parameters.Add("@idProveedor", SqlDbType.SmallInt, 0, "idProveedor")
        'da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 100, "nombre")
        'da.UpdateCommand.Parameters.Add("@direccion", SqlDbType.NVarChar, 100, "direccion")
        'da.UpdateCommand.Parameters.Add("@telefono", SqlDbType.NVarChar, 50, "telefono")
        '' TODO: Comprobar el tipo de datos a usar...
        'da.UpdateCommand.Parameters.Add("@habilitado", SqlDbType.Bit, 0, "habilitado")
        'da.UpdateCommand.Parameters.Add("@contacto", SqlDbType.NVarChar, 200, "contacto")
        '' TODO: Comprobar el tipo de datos a usar...
        'da.UpdateCommand.Parameters.Add("@diasCredito", SqlDbType.SmallInt, 0, "diasCredito")
        'da.UpdateCommand.Parameters.Add("@correoEmpresa", SqlDbType.NVarChar, 100, "correoEmpresa")
        'da.UpdateCommand.Parameters.Add("@correoViajero", SqlDbType.NVarChar, 100, "correoViajero")
        'da.UpdateCommand.Parameters.Add("@nit", SqlDbType.NVarChar, 15, "nit")
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
            clsProveedor2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsProveedor")
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
        ''       Yo compruebo que sea un campo llamado idProveedor, pero en tu caso puede ser otro
        'sCommand = "INSERT INTO tblProveedor (nombre, direccion, telefono, habilitado, contacto, diasCredito, correoEmpresa, correoViajero, nit)  VALUES(@nombre, @direccion, @telefono, @habilitado, @contacto, @diasCredito, @correoEmpresa, @correoViajero, @nit)"
        'da.InsertCommand = New SqlCommand(sCommand, cnn)
        '' TODO: Comprobar el tipo de datos a usar...
        'da.InsertCommand.Parameters.Add("@idProveedor", SqlDbType.SmallInt, 0, "idProveedor")
        'da.InsertCommand.Parameters.Add("@nombre", SqlDbType.NVarChar, 100, "nombre")
        'da.InsertCommand.Parameters.Add("@direccion", SqlDbType.NVarChar, 100, "direccion")
        'da.InsertCommand.Parameters.Add("@telefono", SqlDbType.NVarChar, 50, "telefono")
        '' TODO: Comprobar el tipo de datos a usar...
        'da.InsertCommand.Parameters.Add("@habilitado", SqlDbType.Bit, 0, "habilitado")
        'da.InsertCommand.Parameters.Add("@contacto", SqlDbType.NVarChar, 200, "contacto")
        '' TODO: Comprobar el tipo de datos a usar...
        'da.InsertCommand.Parameters.Add("@diasCredito", SqlDbType.SmallInt, 0, "diasCredito")
        'da.InsertCommand.Parameters.Add("@correoEmpresa", SqlDbType.NVarChar, 100, "correoEmpresa")
        'da.InsertCommand.Parameters.Add("@correoViajero", SqlDbType.NVarChar, 100, "correoViajero")
        'da.InsertCommand.Parameters.Add("@nit", SqlDbType.NVarChar, 15, "nit")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsProveedor(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsProveedor"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idProveedor que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblProveedor WHERE idProveedor = " & Me.idProveedor.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsProveedor")
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
        ''       Yo compruebo que sea un campo llamado idProveedor, pero en tu caso puede ser otro
        'sCommand = "DELETE FROM tblProveedor WHERE (idProveedor = @p1)"
        'da.DeleteCommand = New SqlCommand(sCommand, cnn)
        '' TODO: Comprobar el tipo de datos a usar...
        'da.DeleteCommand.Parameters.Add("@p1", SqlDbType.SmallInt, 0, "idProveedor")
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
