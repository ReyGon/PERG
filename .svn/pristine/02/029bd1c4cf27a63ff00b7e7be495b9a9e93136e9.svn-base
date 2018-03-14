'------------------------------------------------------------------------------
' Clase clsGrupoFormas generada automáticamente con CrearClaseSQL
' de la tabla 'tblGrupoFormas' de la base 'imprenta'
' Fecha: 01/mar/2009 09:28:16
'
' ©Guillermo 'guille' Som, 2004-2009
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class clsGrupoFormas
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _idGrupoForma As System.Int32
    Private _idgrupo As System.Int16
    Private _idForma As System.Int16
    Private _nuevo As System.Boolean
    Private _modifica As System.Boolean
    Private _elimina As System.Boolean
    Private _crea As System.Boolean
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
    Public Property idGrupoForma() As System.Int32
        Get
            Return _idGrupoForma
        End Get
        Set(ByVal value As System.Int32)
            _idGrupoForma = value
        End Set
    End Property
    Public Property idgrupo() As System.Int16
        Get
            Return _idgrupo
        End Get
        Set(ByVal value As System.Int16)
            _idgrupo = value
        End Set
    End Property
    Public Property idForma() As System.Int16
        Get
            Return _idForma
        End Get
        Set(ByVal value As System.Int16)
            _idForma = value
        End Set
    End Property
    Public Property nuevo() As System.Boolean
        Get
            Return _nuevo
        End Get
        Set(ByVal value As System.Boolean)
            _nuevo = value
        End Set
    End Property
    Public Property modifica() As System.Boolean
        Get
            Return _modifica
        End Get
        Set(ByVal value As System.Boolean)
            _modifica = value
        End Set
    End Property
    Public Property elimina() As System.Boolean
        Get
            Return _elimina
        End Get
        Set(ByVal value As System.Boolean)
            _elimina = value
        End Set
    End Property
    Public Property crea() As System.Boolean
        Get
            Return _crea
        End Get
        Set(ByVal value As System.Boolean)
            _crea = value
        End Set
    End Property
    '
    Default Public Property Item(ByVal index As Integer) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde con la columna de la tabla)
        Get
            If index = 0 Then
                Return Me.idGrupoForma.ToString()
            ElseIf index = 1 Then
                Return Me.idgrupo.ToString()
            ElseIf index = 2 Then
                Return Me.idForma.ToString()
            ElseIf index = 3 Then
                Return Me.nuevo.ToString()
            ElseIf index = 4 Then
                Return Me.modifica.ToString()
            ElseIf index = 5 Then
                Return Me.elimina.ToString()
            ElseIf index = 6 Then
                Return Me.crea.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = 0 Then
                Try
                    Me.idGrupoForma = System.Int32.Parse("0" & value)
                Catch
                    Me.idGrupoForma = System.Int32.Parse("0")
                End Try
            ElseIf index = 1 Then
                Try
                    Me.idgrupo = System.Int16.Parse("0" & value)
                Catch
                    Me.idgrupo = System.Int16.Parse("0")
                End Try
            ElseIf index = 2 Then
                Try
                    Me.idForma = System.Int16.Parse("0" & value)
                Catch
                    Me.idForma = System.Int16.Parse("0")
                End Try
            ElseIf index = 3 Then
                Try
                    Me.nuevo = System.Boolean.Parse(value)
                Catch
                    Me.nuevo = False
                End Try
            ElseIf index = 4 Then
                Try
                    Me.modifica = System.Boolean.Parse(value)
                Catch
                    Me.modifica = False
                End Try
            ElseIf index = 5 Then
                Try
                    Me.elimina = System.Boolean.Parse(value)
                Catch
                    Me.elimina = False
                End Try
            ElseIf index = 6 Then
                Try
                    Me.crea = System.Boolean.Parse(value)
                Catch
                    Me.crea = False
                End Try
            End If
        End Set
    End Property
    Default Public Property Item(ByVal index As String) As String
        ' Devuelve el contenido del campo indicado en index
        ' (el índice corresponde al nombre de la columna)
        Get
            If index = "idGrupoForma" Then
                Return Me.idGrupoForma.ToString()
            ElseIf index = "idgrupo" Then
                Return Me.idgrupo.ToString()
            ElseIf index = "idForma" Then
                Return Me.idForma.ToString()
            ElseIf index = "nuevo" Then
                Return Me.nuevo.ToString()
            ElseIf index = "modifica" Then
                Return Me.modifica.ToString()
            ElseIf index = "elimina" Then
                Return Me.elimina.ToString()
            ElseIf index = "crea" Then
                Return Me.crea.ToString()
            End If
            ' Para que no de error el compilador de C#
            Return ""
        End Get
        Set(ByVal value As String)
            If index = "idGrupoForma" Then
                Try
                    Me.idGrupoForma = System.Int32.Parse("0" & value)
                Catch
                    Me.idGrupoForma = System.Int32.Parse("0")
                End Try
            ElseIf index = "idgrupo" Then
                Try
                    Me.idgrupo = System.Int16.Parse("0" & value)
                Catch
                    Me.idgrupo = System.Int16.Parse("0")
                End Try
            ElseIf index = "idForma" Then
                Try
                    Me.idForma = System.Int16.Parse("0" & value)
                Catch
                    Me.idForma = System.Int16.Parse("0")
                End Try
            ElseIf index = "nuevo" Then
                Try
                    Me.nuevo = System.Boolean.Parse(value)
                Catch
                    Me.nuevo = False
                End Try
            ElseIf index = "modifica" Then
                Try
                    Me.modifica = System.Boolean.Parse(value)
                Catch
                    Me.modifica = False
                End Try
            ElseIf index = "elimina" Then
                Try
                    Me.elimina = System.Boolean.Parse(value)
                Catch
                    Me.elimina = False
                End Try
            ElseIf index = "crea" Then
                Try
                    Me.crea = System.Boolean.Parse(value)
                Catch
                    Me.crea = False
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
    Public Shared CadenaSelect As String = "SELECT * FROM tblGrupoFormas"
    '
    Public Sub New()
    End Sub
    Public Sub New(ByVal conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto clsGrupoFormas
    Private Shared Function row2clsGrupoFormas(ByVal r As DataRow) As clsGrupoFormas
        ' asigna a un objeto clsGrupoFormas los datos del dataRow indicado
        Dim oclsGrupoFormas As New clsGrupoFormas
        '
        oclsGrupoFormas.idGrupoForma = System.Int32.Parse("0" & r("idGrupoForma").ToString())
        oclsGrupoFormas.idgrupo = System.Int16.Parse("0" & r("idgrupo").ToString())
        oclsGrupoFormas.idForma = System.Int16.Parse("0" & r("idForma").ToString())
        Try
            oclsGrupoFormas.nuevo = System.Boolean.Parse(r("nuevo").ToString())
        Catch
            oclsGrupoFormas.nuevo = False
        End Try
        Try
            oclsGrupoFormas.modifica = System.Boolean.Parse(r("modifica").ToString())
        Catch
            oclsGrupoFormas.modifica = False
        End Try
        Try
            oclsGrupoFormas.elimina = System.Boolean.Parse(r("elimina").ToString())
        Catch
            oclsGrupoFormas.elimina = False
        End Try
        Try
            oclsGrupoFormas.crea = System.Boolean.Parse(r("crea").ToString())
        Catch
            oclsGrupoFormas.crea = False
        End Try
        '
        Return oclsGrupoFormas
    End Function
    '
    ' asigna un objeto clsGrupoFormas a la fila indicada
    Private Shared Sub clsGrupoFormas2Row(ByVal oclsGrupoFormas As clsGrupoFormas, ByVal r As DataRow)
        ' asigna un objeto clsGrupoFormas al dataRow indicado
        ' TODO: Comprueba si esta asignación debe hacerse
        '       pero mejor lo dejas comentado ya que es un campo autoincremental o único
        'r("idGrupoForma") = oclsGrupoFormas.idGrupoForma
        r("idgrupo") = oclsGrupoFormas.idgrupo
        r("idForma") = oclsGrupoFormas.idForma
        r("nuevo") = oclsGrupoFormas.nuevo
        r("modifica") = oclsGrupoFormas.modifica
        r("elimina") = oclsGrupoFormas.elimina
        r("crea") = oclsGrupoFormas.crea
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto clsGrupoFormas
    Private Shared Sub nuevoclsGrupoFormas(ByVal dt As DataTable, ByVal oclsGrupoFormas As clsGrupoFormas)
        ' Crear un nuevo clsGrupoFormas
        Dim dr As DataRow = dt.NewRow()
        Dim oc As clsGrupoFormas = row2clsGrupoFormas(dr)
        '
        oc.idGrupoForma = oclsGrupoFormas.idGrupoForma
        oc.idgrupo = oclsGrupoFormas.idgrupo
        oc.idForma = oclsGrupoFormas.idForma
        oc.nuevo = oclsGrupoFormas.nuevo
        oc.modifica = oclsGrupoFormas.modifica
        oc.elimina = oclsGrupoFormas.elimina
        oc.crea = oclsGrupoFormas.crea
        '
        clsGrupoFormas2Row(oc, dr)
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
        ' devuelve una tabla con los datos de la tabla tblGrupoFormas
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoFormas")
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
    Public Shared Function Buscar(ByVal sWhere As String) As clsGrupoFormas
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oclsGrupoFormas As clsGrupoFormas = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoFormas")
        Dim sel As String = "SELECT * FROM tblGrupoFormas WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oclsGrupoFormas = row2clsGrupoFormas(dt.Rows(0))
        End If
        Return oclsGrupoFormas
    End Function
    '
    ' Actualizar: Actualiza los datos en la tabla usando la instancia actual
    '             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
    '             Para comprobar si el objeto en memoria coincide con uno existente,
    '             se comprueba si el idGrupoForma existe en la tabla.
    '             TODO: Si en lugar de idGrupoForma usas otro campo, indicalo en la cadena SELECT
    '                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
    Public Function Actualizar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idGrupoForma que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblGrupoFormas WHERE idGrupoForma = " & Me.idGrupoForma.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(ByVal sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoFormas")
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
        '       Yo compruebo que sea un campo llamado idGrupoForma, pero en tu caso puede ser otro
        '       Ese campo, (en mi caso idGrupoForma) será el que hay que poner al final junto al WHERE.
        sCommand = "UPDATE tblGrupoFormas SET idgrupo = @idgrupo, idForma = @idForma, nuevo = @nuevo, modifica = @modifica, elimina = @elimina, crea = @crea  WHERE (idGrupoForma = @idGrupoForma)"
        da.UpdateCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idGrupoForma", SqlDbType.Int, 0, "idGrupoForma")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idgrupo", SqlDbType.SmallInt, 0, "idgrupo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@idForma", SqlDbType.SmallInt, 0, "idForma")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@nuevo", SqlDbType.Bit, 0, "nuevo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@modifica", SqlDbType.Bit, 0, "modifica")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@elimina", SqlDbType.Bit, 0, "elimina")
        ' TODO: Comprobar el tipo de datos a usar...
        da.UpdateCommand.Parameters.Add("@crea", SqlDbType.Bit, 0, "crea")
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
            clsGrupoFormas2Row(Me, dt.Rows(0))
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
        Dim dt As New DataTable("clsGrupoFormas")
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
        '       Yo compruebo que sea un campo llamado idGrupoForma, pero en tu caso puede ser otro
        sCommand = "INSERT INTO tblGrupoFormas (idgrupo, idForma, nuevo, modifica, elimina, crea)  VALUES(@idgrupo, @idForma, @nuevo, @modifica, @elimina, @crea)"
        da.InsertCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idGrupoForma", SqlDbType.Int, 0, "idGrupoForma")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idgrupo", SqlDbType.SmallInt, 0, "idgrupo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@idForma", SqlDbType.SmallInt, 0, "idForma")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@nuevo", SqlDbType.Bit, 0, "nuevo")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@modifica", SqlDbType.Bit, 0, "modifica")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@elimina", SqlDbType.Bit, 0, "elimina")
        ' TODO: Comprobar el tipo de datos a usar...
        da.InsertCommand.Parameters.Add("@crea", SqlDbType.Bit, 0, "crea")
        '
        '
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoclsGrupoFormas(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo clsGrupoFormas"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        ' TODO: Poner aquí la selección a realizar para acceder a este registro
        '       yo uso el idGrupoForma que es el identificador único de cada registro
        Dim sel As String = "SELECT * FROM tblGrupoFormas WHERE idGrupoForma = " & Me.idGrupoForma.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(ByVal sel As String) As String
        ' Borrar el registro al que apunta esta clase
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("clsGrupoFormas")
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
        '       Yo compruebo que sea un campo llamado idGrupoForma, pero en tu caso puede ser otro
        sCommand = "DELETE FROM tblGrupoFormas WHERE (idGrupoForma = @p1)"
        da.DeleteCommand = New SqlCommand(sCommand, cnn)
        ' TODO: Comprobar el tipo de datos a usar...
        da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int, 0, "idGrupoForma")
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
