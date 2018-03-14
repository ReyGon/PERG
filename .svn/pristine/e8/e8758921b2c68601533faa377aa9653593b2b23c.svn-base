Imports System.Data.SqlClient

Public Class clsBaseDatos

    'Private NombreInstancia As String = "sql08"
    Private Clave As String = mdlPublicVars.claveSistema



    Public Function fnVerificarBD(nombrebd As String)

        Dim servidorSQL As String = mdlPublicVars.servidor.ToString
        Dim cnn As New SqlConnection("Server=" + servidorSQL.ToString + ";uid=sa;pwd=" + Clave.ToString + ";database=master")
        Dim da As New SqlDataAdapter("EXEC sp_databases", cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim tbl1 As New DataTable
        tbl1 = ds.Tables(0)

        Dim bitBDexiste As Boolean = False

        Dim index As Integer = 0
        For index = 0 To tbl1.Rows.Count - 1
            If tbl1.Rows(index).Item(0).ToString.ToLower = nombrebd.ToLower Then
                Return True
            End If
        Next

        Return False
    End Function


    Public Function fnCrearBD(nombreBd As String) As Boolean



        ' La conexión a usar, indicando la base master
        Dim cnn As New SqlConnection( _
                        "Server=" & mdlPublicVars.servidor & "; " & _
                        "database=master; integrated security=yes")
        ' La orden T-SQL para crear la tabla
        Dim s As String = "CREATE DATABASE " & nombreBd.ToString

        Dim cmd As New SqlCommand(s, cnn)

        Try
            ' Abrimos la conexión y ejecutamos el comando
            cnn.Open()
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            MsgBox("Error al crear la base de datos")
            MessageBox.Show(ex.Message, _
                            "Error al crear la base", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Por si se produce un error,
            ' comprobar si la conexión está abierta
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
        End Try



        Return False
    End Function

    Public Function fnRestaurarBD(nombreBd As String) As Boolean

        Dim completado As Boolean = False

        Dim direccionBackUp As String = System.IO.Path.Combine(Application.StartupPath, "bd.bak")

        Dim sBackup As String = "RESTORE DATABASE " & nombreBd.ToString & _
                                " FROM DISK = '" & direccionBackUp.ToString & "'" & _
                                " WITH REPLACE"

        Dim csb As New SqlConnectionStringBuilder
        csb.DataSource = mdlPublicVars.servidor.ToString
        ' Es mejor abrir la conexión con la base Master
        csb.InitialCatalog = "master"
        csb.IntegratedSecurity = True

        Using con As New SqlConnection(csb.ConnectionString)
            Try
                con.Open()

                Dim cmdBackUp As New SqlCommand(sBackup, con)
                cmdBackUp.ExecuteNonQuery()
               
                con.Close()

                completado = True

            Catch ex As Exception
                completado = False
            End Try
        End Using

        Return completado
    End Function



    Public Function fnLlenarBaseDatos(cmb As Telerik.WinControls.UI.RadDropDownList)
        Try
            Dim servidorSQL As String = mdlPublicVars.servidor
            Dim cnn As New SqlConnection("Server=" + servidorSQL.ToString + ";uid=sa;pwd=" + Clave.ToString + ";database=master")
            Dim da As New SqlDataAdapter("EXEC sp_databases", cnn)
            Dim ds As New DataSet
            da.Fill(ds)
            Dim tbl1 As New DataTable
            tbl1 = ds.Tables(0)

            Dim bitBDexiste As Boolean = False

            Dim index As Integer = 0
            Dim nombre As String = ""
            Dim nombres() As String
            Dim correlativo As Integer = 0

            For index = 0 To tbl1.Rows.Count - 1
                nombre = tbl1.Rows(index).Item(0).ToString
                nombres = nombre.Split("_")
                If nombres.Length = 3 Then
                    If nombres(0).ToLower = "dsi" And nombres(1).ToLower = "pos" Then
                        correlativo += 1
                        cmb.Items.Add(nombres(2).ToString)
                    End If
                End If
            Next

            If correlativo = 0 Then
            Else
                cmb.SelectedIndex = 0
            End If

        Catch ex As Exception

        End Try
        
        Return False
    End Function
End Class
