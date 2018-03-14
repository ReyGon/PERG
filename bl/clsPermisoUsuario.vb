Imports System.Windows.Forms
Imports Telerik.WinControls

Public Class clsPermisoUsuario

    'permisoDialog para dialogos con abc
    Public Sub PermisoDialogMantenimiento(ByVal formulario As frmBaseTelerik)
        If mdlPublicVars.superUsuario = True Then
            formulario.ShowDialog()
            formulario.Dispose()
            Exit Sub
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            formulario.nuevo = tb.Rows(0).Item("nuevo")
            formulario.modificar = tb.Rows(0).Item("modifica")
            formulario.eliminar = tb.Rows(0).Item("elimina")
            formulario.grabar = tb.Rows(0).Item("crea")
            formulario.WindowState = FormWindowState.Normal
            formulario.StartPosition = FormStartPosition.CenterScreen
            formulario.ShowDialog()
            formulario.Dispose()
        End If
    End Sub

    'Permiso para las barras derechas
    Public Sub PermisoDialogBarra(ByVal formulario As FrmBarraLateral)
        If mdlPublicVars.superUsuario = True Then
            formulario.ShowDialog()

            Exit Sub
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            formulario.WindowState = FormWindowState.Normal
            formulario.StartPosition = FormStartPosition.CenterScreen
            formulario.ShowDialog()

        End If
    End Sub

    Public Sub PermisoDialogEspeciales(ByVal formulario As Form)
        Try
            If mdlPublicVars.superUsuario = True Then
                formulario.ShowDialog()
                formulario.Dispose()
                Exit Sub
            End If

            Dim str As String
            Dim tbl As New clsDevuelveTabla
            Dim tb As System.Data.DataTable
            str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
            tb = tbl.tablaSP(str)

            If formulario.Name.Equals("frmBaseLista") Then
                RadMessageBox.Show("ERROR!")
            End If

            If tb.Rows.Count = 0 Then
                RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Sub
            Else

                formulario.ShowDialog()
                formulario.Dispose()
            End If
        Catch ex As Exception
            RadMessageBox.Show("Error en el Formulario", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'permisoDialog para dialogos con abc
    Public Sub PermisoDialogMantenimientoTelerik(ByVal formulario As frmBaseTelerik)
        If mdlPublicVars.superUsuario = True Then
            formulario.ShowDialog()
            formulario.Dispose()
            Exit Sub
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            formulario.nuevo = tb.Rows(0).Item("nuevo")
            formulario.modificar = tb.Rows(0).Item("modifica")
            formulario.eliminar = tb.Rows(0).Item("elimina")
            formulario.grabar = tb.Rows(0).Item("crea")
            'formulario.WindowState = FormWindowState.Normal
            formulario.StartPosition = FormStartPosition.CenterScreen
            formulario.ShowDialog()
            formulario.Dispose()
        End If
    End Sub

    'permisoDialog para dialogos con abc
    Public Sub PermisoDialogMantenimientoTelerik2(ByVal formulario As frmBaseTelerik2)
        If mdlPublicVars.superUsuario = True Then
            formulario.ShowDialog()
            formulario.Dispose()
            Exit Sub
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            formulario.nuevo = tb.Rows(0).Item("nuevo")
            formulario.modificar = tb.Rows(0).Item("modifica")
            formulario.eliminar = tb.Rows(0).Item("elimina")
            formulario.grabar = tb.Rows(0).Item("crea")
            'formulario.WindowState = FormWindowState.Normal
            formulario.StartPosition = FormStartPosition.CenterScreen
            formulario.ShowDialog()
            formulario.Dispose()
        End If
    End Sub

    '''''-------------nuevo permisos para telerik base --------------USADOS.
    'mantenimiento maximizado o normal.
    Public Function PermisoMantenimientoTelerik(ByVal formulario As frmBaseTelerik, ByVal Maximinzado As Boolean) As Boolean
        If mdlPublicVars.superUsuario = True Then
            If Maximinzado Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
            End If
            formulario.Show()
            Return True
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        Else
            formulario.nuevo = tb.Rows(0).Item("nuevo")
            formulario.modificar = tb.Rows(0).Item("modifica")
            formulario.eliminar = tb.Rows(0).Item("elimina")
            formulario.grabar = tb.Rows(0).Item("crea")
            If Maximinzado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
                formulario.StartPosition = FormStartPosition.CenterScreen
            End If

            formulario.Show()
            Return True

        End If
    End Function

    Public Sub PermisoMantenimientoTelerik2(ByVal formulario As frmBaseTelerik2, ByVal Maximinzado As Boolean)
        If mdlPublicVars.superUsuario = True Then
            If Maximinzado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
            End If
            formulario.Show()
            Exit Sub
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Exit Sub
        Else
            formulario.nuevo = tb.Rows(0).Item("nuevo")
            formulario.modificar = tb.Rows(0).Item("modifica")
            formulario.eliminar = tb.Rows(0).Item("elimina")
            formulario.grabar = tb.Rows(0).Item("crea")
            If Maximinzado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
                formulario.StartPosition = FormStartPosition.CenterScreen
            End If

            formulario.Show()

        End If
    End Sub

    Public Function PermisoMantenimientoLista(ByVal formulario As frmBaseLista, ByVal Maximinzado As Boolean) As Boolean
        If mdlPublicVars.superUsuario = True Then
            If Maximinzado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
            End If
            formulario.Show()
            Return True
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        Else

            If Maximinzado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
                formulario.StartPosition = FormStartPosition.CenterScreen
            End If

            formulario.Show()
            Return True
        End If
    End Function


    'permiso simple para frm especiales.
    Public Function PermisoFrmEspeciales(ByVal formulario As Form, ByVal maximizado As Boolean) As Boolean
        If mdlPublicVars.superUsuario = True Then
            If maximizado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
                formulario.StartPosition = FormStartPosition.CenterScreen
            End If
            formulario.Show()
            Return True
        End If

        Dim str As String
        Dim tbl As New clsDevuelveTabla
        Dim tb As System.Data.DataTable
        str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
        tb = tbl.tablaSP(str)

        If formulario.Name.Equals("frmBaseLista") Then
            RadMessageBox.Show("ERROR!")
        End If

        If tb.Rows.Count = 0 Then
            RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return False
        Else
            If maximizado = True Then
                formulario.WindowState = FormWindowState.Maximized
            Else
                formulario.WindowState = FormWindowState.Normal
                formulario.StartPosition = FormStartPosition.CenterScreen
            End If

            formulario.Show()
            Return True
        End If


    End Function

   

    Public Sub PermisoFrmBaseEspeciales(formulario As FrmBaseEspeciales, ByVal maximizado As Boolean)
        Try
            If mdlPublicVars.superUsuario = True Then
                If maximizado = True Then
                    formulario.WindowState = FormWindowState.Maximized
                Else
                    formulario.WindowState = FormWindowState.Normal
                    formulario.StartPosition = FormStartPosition.CenterScreen
                End If
                formulario.Show()
                Exit Sub
            End If

            Dim str As String
            Dim tbl As New clsDevuelveTabla
            Dim tb As System.Data.DataTable
            str = "sp_permisos " & mdlPublicVars.idUsuario & ",'" & formulario.Name & "'"
            tb = tbl.tablaSP(str)

            If formulario.Name.Equals("frmBaseLista") Then
                RadMessageBox.Show("ERROR!")
            End If


            If tb.Rows.Count = 0 Then
                RadMessageBox.Show("Sin permisos para esta opcion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Sub
            Else
                formulario.WindowState = FormWindowState.Maximized
                formulario.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub


End Class
