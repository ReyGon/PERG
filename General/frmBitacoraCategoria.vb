Imports System.Data.EntityClient
Imports System.Linq



Public Class frmBitacoraCategoria


    Private _bitCliente As Boolean

    Public Property bitCliente() As Boolean
        Get
            bitCliente = _bitCliente
        End Get
        Set(value As Boolean)
            _bitCliente = value
        End Set
    End Property

    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub


    Private Sub frmBitacoraCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarGrid()
    End Sub

    Private Sub fnLlenarGrid()
        Try


            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim consulta = (From x In conexion.tblBitacoraCategorias Select Codigo = x.IdBitacoraCategoria, Nombre = x.Nombre,
                                    chkCliente = x.cliente, chkProveedor = x.proveedor).ToList

                grdDatos.DataSource = consulta
                conn.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub



    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()
        Me.txtNombre.Focus()
    End Sub


    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        Dim conexion As New dsi_pos_demoEntities

        Try


            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim bitacora As New tblBitacoraCategoria
                bitacora.Nombre = txtNombre.Text
                bitacora.proveedor = chkProveedor.Checked
                bitacora.cliente = chkCliente.Checked

                conexion.AddTotblBitacoraCategorias(bitacora)
                conexion.SaveChanges()

                conn.Close()
            End Using


        Catch ex As Exception
            alertas.fnErrorGuardar()
        End Try
        fnLlenarGrid()
    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        Try
            Dim conexion As New dsi_pos_demoEntities

            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim bitacora As tblBitacoraCategoria = (From b In conexion.tblBitacoraCategorias Where b.IdBitacoraCategoria = txtCodigo.Text Select b).FirstOrDefault
                bitacora.Nombre = txtNombre.Text
                bitacora.proveedor = chkProveedor.Checked
                bitacora.cliente = chkCliente.Checked

                conexion.SaveChanges()
                conn.Close()


            End Using

        Catch ex As System.Data.EntityException
        Catch ex As Exception
            alertas.fnErrorModificar()
        End Try

        fnLlenarGrid()

    End Sub

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro




        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Sub
        End If

        Try
            Dim conexion As New dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

                Dim bitacora As tblBitacoraCategoria = (From b In conexion.tblBitacoraCategorias Where b.IdBitacoraCategoria = txtCodigo.Text Select b).FirstOrDefault

                conexion.DeleteObject(bitacora)

                conexion.SaveChanges()
                conn.Close()

            End Using

            fnLlenarGrid()

        Catch ex As Exception
            alertas.fnErrorEliminar()
        End Try



    End Sub



    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

End Class
