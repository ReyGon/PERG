Imports System.Linq
Imports Telerik.WinControls

Public Class frmProductoPreciosCompeLista
    Private permiso As New clsPermisoUsuario

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim iz As New frmProductosBarraIzquierda
            iz.frmAnterior = Me

            frmBarraLateralBaseIzquierda = iz
            'frmBarraLateralBaseDerecha = frmProductosBarraDerecha
            ActivarBarraLateral = True

        Catch ex As Exception

        End Try
        pnx0Nuevo.Visible = False
        llenagrid()
        fnConfiguracion()
        Me.grdDatos.Font = New System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.Focus()
    End Sub

    Private Sub llenagrid()
        Try

            Dim filtro As String = txtFiltro.Text

            Dim productoInfo = (From x In ctx.tblPrecioCompetencias Where x.tblArticulo.nombre1.Contains(filtro) _
                        Select Fecha = x.fechaRegistro, Codigo = x.tblArticulo.codigo1, Articulo = x.tblArticulo.nombre1, _
                        Cliente = x.tblCliente.Negocio, Precio = x.precio, Observacion = x.observacion _
                        Order By Fecha Descending)

            Me.grdDatos.DataSource = EntitiToDataTable(productoInfo)
            fnConfiguracion()


        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    Private Sub fnConfiguracion()
        Try
            If Me.grdDatos.ColumnCount > 0 Then
                mdlPublicVars.fnGridTelerik_formatoMoneda(Me.grdDatos, "Precio")
                mdlPublicVars.fnGridTelerik_formatoFecha(Me.grdDatos, "Fecha")
                For i As Integer = 0 To Me.grdDatos.ColumnCount - 1
                    Me.grdDatos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
                Next

                Me.grdDatos.Columns("Fecha").Width = 60
                Me.grdDatos.Columns("Codigo").Width = 80
                Me.grdDatos.Columns("Articulo").Width = 120
                Me.grdDatos.Columns("Cliente").Width = 130
                Me.grdDatos.Columns("Precio").Width = 90
                Me.grdDatos.Columns("Observacion").Width = 170
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub frm_llenarLista() Handles Me.llenarLista
        llenagrid()
    End Sub


    Private Sub fnDocSalida() Handles Me.imprimir
        frmDocumentosSalida.txtTitulo.Text = "Price de Productos"
        frmDocumentosSalida.grd = Me.grdDatos
        frmDocumentosSalida.Text = "Docs. de Salida"
        frmDocumentosSalida.codigo = 0
        frmDocumentosSalida.bitCliente = False
        frmDocumentosSalida.bitGenerico = True
        permiso.PermisoFrmEspeciales(frmDocumentosSalida, False)
    End Sub

    Private Sub frmSalir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

End Class
