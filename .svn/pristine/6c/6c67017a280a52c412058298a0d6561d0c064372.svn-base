Imports System.Linq
Imports AForge.Video.DirectShow
Imports AForge.Video
Imports Telerik.WinControls
Imports System.IO

Public Class frmCapturarFoto

#Region "Variables"
    Private camaras As Boolean = False
    Private DispositivosDeVideo As FilterInfoCollection
    Private FuenteDeVideo As VideoCaptureDevice = Nothing

    Private _bitVendedor As Boolean
    Private _bitProducto As Boolean
    Private _codigo As Integer

    Private buscada As Boolean
    Private dirBuscada As String
    Private capturada As Boolean

    Public Property bitVendedor As Boolean
        Get
            bitVendedor = _bitVendedor
        End Get
        Set(ByVal value As Boolean)
            _bitVendedor = value
        End Set
    End Property

    Public Property bitProducto As Boolean
        Get
            bitProducto = _bitProducto
        End Get
        Set(ByVal value As Boolean)
            _bitProducto = value
        End Set
    End Property

    Public Property codigo As Integer
        Get
            codigo = _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

#End Region

#Region "LOAD"
    Private Sub frmCapturarFoto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fnLlenarDatos()
        BuscarDispositivos()
        pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage
        pbxFoto.BorderStyle = BorderStyle.Fixed3D
    End Sub
#End Region

#Region "Funciones"
    'Utilizada para llenar los datos
    Private Sub fnLlenarDatos()
        Try
            If bitVendedor Then
                Dim vendedor As tblVendedor = (From x In ctx.tblVendedors.AsEnumerable
                                               Where x.idVendedor = codigo
                                               Select x).FirstOrDefault

                lblCodigo.Text = vendedor.idVendedor
                lblNombre.Text = vendedor.nombre

                'Obtenemos la ruta de la foto
                Dim ruta As String = vendedor.foto

                If ruta IsNot Nothing Then
                    fnCargarFoto(pbxFoto, ruta)
                End If
            ElseIf bitProducto Then
                Dim articulo As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable
                                               Where x.idArticulo = codigo
                                               Select x).FirstOrDefault

                lblCodigo.Text = articulo.codigo1
                lblNombre.Text = articulo.nombre1

                btnSubirImagen.Visible = False
                btnCapturarImagen.Dock = DockStyle.Top
            End If
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
        
    End Sub

    'CARGAR FOTO
    Private Sub fnCargarFoto(ByRef pct As PictureBox, ByVal direccion As String)
        Try
            'Vaciamos la imagen
            If pct.Image IsNot Nothing Then
                pct.Image = Nothing
            End If

            If direccion IsNot Nothing Then
                If direccion.Length > 0 Then
                    Dim stream As New System.IO.StreamReader(direccion)
                    pct.Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    pct.SizeMode = PictureBoxSizeMode.StretchImage
                    pct.BorderStyle = BorderStyle.Fixed3D
                End If
            End If
        Catch ex As Exception
            alerta.contenido = "Ocurrio un error al intentar abrir la imagen"
            alerta.fnErrorContenido()
        End Try
    End Sub

    'SUBIR FOTO
    Private Sub fnSubirFoto(ByRef pct As PictureBox)
        Dim abrir As New OpenFileDialog
        With abrir
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp"
            .FilterIndex = 2
        End With

        If (abrir.ShowDialog = DialogResult.OK) Then
            Dim stream As New System.IO.StreamReader(abrir.FileName)
            pct.Image = Image.FromStream(stream.BaseStream)
            stream.Dispose()
            pct.SizeMode = PictureBoxSizeMode.StretchImage
            pct.BorderStyle = BorderStyle.Fixed3D
            buscada = True
            dirBuscada = abrir.FileName
            capturada = False
        End If
    End Sub

    'GUARDAR FOTO
    Private Sub fnGuardarFoto(ByVal dir As String)
        If bitVendedor Then
            'Obtenemos el vendedor
            Dim vendedor As tblVendedor = (From x In ctx.tblVendedors Where x.idVendedor = codigo _
                                           Select x).FirstOrDefault

            vendedor.foto = dir
            ctx.SaveChanges()

            RadMessageBox.Show("Imagen guardada exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
        End If
    End Sub

    'CARGAR CAMARAS
    Public Sub CargarDispositivos()
        For i As Integer = 0 To DispositivosDeVideo.Count - 1
            cmbCamara.Items.Add(DispositivosDeVideo(i).Name.ToString())
        Next
        cmbCamara.Text = cmbCamara.Items(0).ToString()
    End Sub

    'BUSCAR CAMARAS
    Public Sub BuscarDispositivos()
        DispositivosDeVideo = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        If DispositivosDeVideo.Count = 0 Then
            camaras = False
        Else
            camaras = True
            CargarDispositivos()
            btnCapturarImagen.Enabled = True
        End If
    End Sub

    'TERMINAR CAMARA
    Public Sub TerminarFuenteDeVideo()
        If Not (FuenteDeVideo Is Nothing) Then
            If FuenteDeVideo.IsRunning Then
                FuenteDeVideo.SignalToStop()
                FuenteDeVideo = Nothing
                buscada = False
                capturada = True
            End If
        End If
    End Sub

    'COPIAR IMAGEN DE CAMARA A PICTURE BOX
    Private Sub video_NuevoFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        Try
            Dim Imagen As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            pbxFoto.Image = Imagen
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try

    End Sub

    'ELIMINAR FOTO
    Private Sub fnEliminaFoto(ByVal dir As String)
        'verifica si existe la elimina.
        If dir IsNot Nothing Then
            If dir.Length > 0 Then
                'veririfica si existe el archivo
                If My.Computer.FileSystem.FileExists(dir) Then
                    'eliminar el archivo.
                    My.Computer.FileSystem.DeleteFile(dir)
                End If
            End If
        End If
    End Sub

    'GUARDAR LA IMAGEN
    Private Function fnGuardarFotoFisica(ByVal codVendedor As Integer) As String
        Dim ruta As String = Path.Combine(mdlPublicVars.General_CarpetaFotosVendedor, codVendedor & ".jpg")
        fnEliminaFoto(ruta)
        Dim imagen As Image = pbxFoto.Image
        Dim bmap As Bitmap = New Bitmap(imagen)
        bmap.Save(ruta, imagen.RawFormat)
        bmap.Dispose()

        Return ruta
    End Function

    'GUARDAR IMAGEN DEL PRODUCTO
    Private Sub fnImagenProducto()
        'Creamos la nueva imagen
        Dim foto As New tblArticulo_Foto
        foto.articulo = codigo
        ctx.AddTotblArticulo_Foto(foto)
        ctx.SaveChanges()
        Dim codFoto As Integer = foto.codigo
        'guardar la imagen.
        Dim ruta As String = Path.Combine(mdlPublicVars.General_CarpetaImagenes, codFoto & ".jpg")
        Dim imagen As Image = pbxFoto.Image
        Dim bmap As Bitmap = New Bitmap(imagen)
        bmap.Save(ruta, imagen.RawFormat)
        bmap.Dispose()
        ctx.SaveChanges()

        'Agregamos una fila al grid
        Dim fila As String() = {foto.codigo, ruta, "0"}
        frmProducto.grdFotos.Rows.Add(fila)
    End Sub

#End Region

#Region "Eventos"
    'GUARDAR FOTO
    Private Sub fnGuardar() Handles Me.panel0

        If bitVendedor Then
            fnGuardarFoto(fnGuardarFotoFisica(codigo))
        Else
            If RadMessageBox.Show("¿Desea guardar la imagen del producto?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                fnImagenProducto()
                alerta.contenido = "Imagen guardada exitosamente!"
                alerta.fnErrorContenido()
                Me.Close()
            End If
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'BOTON CARGAR FOTO
    Private Sub btnSubirImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubirImagen.Click
        fnSubirFoto(pbxFoto)
    End Sub

    'EMPEZAR A CAPTURAR IMAGEN
    Private Sub btnCapturarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapturarImagen.Click
        Try
            FuenteDeVideo = New VideoCaptureDevice(DispositivosDeVideo(cmbCamara.SelectedIndex).MonikerString)
            AddHandler FuenteDeVideo.NewFrame, AddressOf video_NuevoFrame
            FuenteDeVideo.Start()
            btnCapturarImagen.Enabled = False
            btnStop.Enabled = True
        Catch ex As Exception
            btnStop.Enabled = False
            btnCapturarImagen.Enabled = True
        End Try
    End Sub

    'DEJAR DE CAPTURAR
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        btnCapturarImagen.Enabled = True
        btnStop.Enabled = False
        TerminarFuenteDeVideo()
    End Sub

#End Region

    Private Sub frmCapturarFoto_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        btnStop.PerformClick()
    End Sub
End Class
