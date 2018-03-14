

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Public Class frmFiltro
    Private _columnas As DataColumnCollection
    Private _filtro As String

    Public Property filtro() As String
        Get
            filtro = _filtro
        End Get
        Set(ByVal value As String)
            _filtro = value
        End Set
    End Property
    Public Property columnas() As DataColumnCollection
        Get
            columnas = _columnas
        End Get
        Set(ByVal value As DataColumnCollection)
            _columnas = value
        End Set
    End Property


    Private Sub validaIngreso()
        Dim ctl As Control
        Dim chk As CheckBox
        Dim chkfiltro As CheckBox
        Dim columna As String = ""
        Dim strFiltro As String = ""
        Dim i As Integer = 0
        For Each ctl In Me.Controls
            If tipoControl(ctl.Name) = "chk" Then
                chk = ctl
                If chk.Checked Then
                    i += 1
                    columna = Replace(chk.Name, "chk", "")
                    If columnas(columna).DataType Is System.Type.GetType("System.Int32") Or columnas(columna).DataType Is System.Type.GetType("System.Decimal") _
                    Or columnas(columna).DataType Is System.Type.GetType("System.Int64") _
                    Or columnas(columna).DataType Is System.Type.GetType("System.Int16") Then
                        If Not IsNumeric(Me.Controls("txtf" & columna).Text) _
                        Or columnas(columna).DataType Is System.Type.GetType("System.Double") Then
                            MsgBox(columna & " Debe de ser un numero", MsgBoxStyle.Critical, "!!!")
                            Exit Sub
                        Else
                            'iniciamos a concatenar los filtros
                            strFiltro = strFiltro & columna & " = " & Me.Controls("txtf" & columna).Text & " AND "
                        End If
                    End If
                    'asignamos el filtro para texto
                    If columnas(columna).DataType Is System.Type.GetType("System.String") Then

                        'iniciamos a concatenar los filtros
                        strFiltro = strFiltro & columna & " like '%" & Me.Controls("txtf" & columna).Text & "%' AND "
                    End If


                    If columnas(columna).DataType Is System.Type.GetType("System.DateTime") Then
                        strFiltro = strFiltro & columna & " = '" & Me.Controls("dtpf" & columna).Text & "' AND "
                    End If

                    If columnas(columna).DataType Is System.Type.GetType("System.Boolean") Then
                        chkfiltro = Me.Controls("cckf" & columna)
                        If chkfiltro.Checked Then
                            strFiltro = strFiltro & columna & " = " & True & " AND "
                        Else
                            strFiltro = strFiltro & columna & " = " & False & " AND "

                        End If
                    End If
                End If
            End If




        Next

        If i = 0 Then
            mdlPublicVars.filtro = ""
        Else
            strFiltro = strFiltro.Substring(0, strFiltro.Length - 5)
            mdlPublicVars.filtro = strFiltro
        End If
        
        Me.Close()

    End Sub
    Private Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function

    Private Sub frmFiltro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub

 

    Private Sub frmFiltro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim columna As Data.DataColumn
  
        Dim i As Integer = 1
        For Each columna In columnas
            Dim texto As New TextBox
            Dim textoFiltro As New TextBox
            Dim chkFiltro As New CheckBox
            Dim chk As New CheckBox
            Dim fechaFiltro As New DateTimePicker

            chk.Name = "chk" & columna.ColumnName
            chk.Checked = False
            chk.Location = New Point(30, 3 + (i * 25))

            
            texto.Name = "txt" & i
            texto.Text = columna.ColumnName
            texto.Enabled = False
            texto.Location = New Point(60, 3 + (i * 25))


            chkFiltro.Name = "cckf" & columna.ColumnName
            chkFiltro.Checked = False
            chkFiltro.Location = New Point(200, 3 + (i * 25))


            textoFiltro.Name = "txtf" & columna.ColumnName
            textoFiltro.Text = ""
            textoFiltro.Enabled = True
            textoFiltro.BackColor = Color.White
            textoFiltro.Width = 200
            textoFiltro.Location = New Point(200, 3 + (i * 25))

            fechaFiltro.Name = "dtpf" & columna.ColumnName
            fechaFiltro.Enabled = True
            fechaFiltro.Location = New Point(200, 2 + (i * 25))
            fechaFiltro.Format = DateTimePickerFormat.Short

            Me.Controls.Add(texto)
            Me.Controls.Add(chk)



            If columna.DataType Is System.Type.GetType("System.Boolean") Then
                Me.Controls.Add(chkFiltro)
            ElseIf columna.DataType Is System.Type.GetType("System.DateTime") Then
                Me.Controls.Add(fechaFiltro)
            Else

                Me.Controls.Add(textoFiltro)

            End If


            i += 1
        Next

        Me.Size = New Drawing.Size(550, i * 38)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call validaIngreso()
    End Sub
End Class