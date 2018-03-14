Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class frmBuscarArticuloFoto
    Private _codigo As Integer
    Private _cliente As Integer

    Public Property codigo() As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property cliente As Integer
        Get
            cliente = _cliente
        End Get
        Set(ByVal value As Integer)
            _cliente = value
        End Set
    End Property

    Private Sub frmBuscarArticuloFoto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            mdlPublicVars.comboActivarFiltroLista(cmbFoto)

            fnLimpiar()
            fnLlenarCombo()
            fnLlenarDatos()
            cargaFoto(cmbFoto.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLlenarDatos()
        Try
            'Obtenemos el articulo
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes Where x.idArticulo = codigo Select x).FirstOrDefault
            lblArticulo.Text = articulo.nombre1
            lblCodigo.Text = articulo.codigo1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnLimpiar()
        Try
            With pbxFoto
                .Image = Nothing
            End With
            lblArticulo.Text = ""
            lblCodigo.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para cargar la foto
    Private Sub cargaFoto(ByVal direccion As String)
        'Quitamos la imagen que tenia
        If pbxFoto.Image IsNot Nothing Then
            pbxFoto.Image = Nothing
        End If

        Dim picture = New Bitmap(direccion)
        With pbxFoto
            .Image = picture
            .SizeMode = PictureBoxSizeMode.StretchImage
            .BorderStyle = BorderStyle.Fixed3D
        End With
    End Sub

    'Evento que maneja el cambio de valor del combo Foto
    Private Sub cmbFoto_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFoto.SelectedValueChanged
        Try
            cargaFoto(cmbFoto.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para cargar el combo de fotos
    Private Sub fnLlenarCombo()
        Try
            'Obtenemos las fotos
            Dim fotos As List(Of tblArticulo_Foto) = (From x In ctx.tblArticulo_Foto Where x.articulo = codigo Select x).ToList

            'Creamos la tabla que agregaremos al combo
            Dim tabla As New DataTable

            'Agregamos las columnas
            tabla.Columns.Add("Codigo")
            tabla.Columns.Add("Nombre")

            Dim i As Integer = 0
            For Each f As tblArticulo_Foto In fotos
                i += 1
                Dim fila As String()
                Dim ruta As String = Path.Combine(mdlPublicVars.General_CarpetaImagenes, f.codigo & ".jpg")
                fila = {ruta, "Imagen " & i}
                tabla.Rows.Add(fila)
            Next

            'Llenamos el combo con las fotos
            With Me.cmbFoto
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = tabla
            End With

        Catch ex As Exception
        End Try
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'AGREGAR IMPRESION
    Private Sub fnImprimir() Handles Me.panel0
        Try
            fnAgregarImpresion(CStr(cmbFoto.SelectedValue))
            RadMessageBox.Show("Foto agregada a la lista de impresión, exitosamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        Catch ex As Exception
            RadMessageBox.Show("Ocurrio un error al intentar agregar la foto a la lista de impresion", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    'Funcion utilizada para agregar la foto actual a la lista de impresion
    Private Sub fnAgregarImpresion(ByVal ruta As String)
        Dim fechaServidor As DateTime = mdlPublicVars.fnFecha_horaServidor

        Dim tipoImpresion As Integer = (From x In ctx.tblTipoImpresions Where x.bitFoto = True And x.nombre.Contains("Foto") _
                                        Select x.codigo).FirstOrDefault

        'Creamos el nuevo registro
        Dim impresion As New tblImpresion
        impresion.cliente = cliente
        impresion.bitImpreso = False
        impresion.fechaRegistro = fechaServidor
        impresion.tipoImpresion = tipoImpresion
        impresion.descripcion = lblArticulo.Text
        impresion.url = ruta
        impresion.usuarioRegistro = mdlPublicVars.idUsuario

        'Añadimos el registro
        ctx.AddTotblImpresions(impresion)
        ctx.SaveChanges()
    End Sub

End Class