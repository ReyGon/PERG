Imports System.Linq
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.IO
Imports System.Transactions

Public Class frmBancoCreditoAdjuntarArchivo
    Private _idMovimiento As Integer
    Public Property idMovimiento As Integer
        Get
            idMovimiento = _idMovimiento
        End Get
        Set(ByVal value As Integer)
            _idMovimiento = value
        End Set
    End Property

    Private Sub frmBancoCreditoConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdDirecciones)
        fnLlenarDatos()
        fnLlenarFotos(idMovimiento)
    End Sub


    'LLENA LOS DATOS
    Private Sub fnLlenarDatos()
        'Obtenemos el encabezado del cheque
        Dim movimiento As tblBanco_Creditos = (From x In ctx.tblBanco_Creditos Where x.codigo = idMovimiento
                                         Select x).FirstOrDefault

        If movimiento IsNot Nothing Then
            'Llenamos los datos del movimiento
            lblFechaRegistro.Text = Format(movimiento.fechaRegistro, mdlPublicVars.formatoFecha)
            lblAnulado.Text = If(movimiento.bitAnulado, "SI", "NO")
            lblBanco.Text = movimiento.tblBanco_Cuenta.tblBanco.nombre

            lblConfirmado.Text = If(movimiento.bitConfirmado, "SI", "NO")
            lblCorrelativo.Text = movimiento.correlativo
            lblCuenta.Text = movimiento.tblBanco_Cuenta.numeroCuenta
            lblDocumento.Text = movimiento.documento
            lblFechaAnulado.Text = If(movimiento.fechaAnulado Is Nothing, "", Format(movimiento.fechaAnulado, mdlPublicVars.formatoFecha))
            lblFechaConfirmado.Text = If(movimiento.fechaConfirmado Is Nothing, "", Format(movimiento.fechaConfirmado, mdlPublicVars.formatoFecha))
            lblTotal.Text = Format(movimiento.total, mdlPublicVars.formatoMoneda)
            lblUsuarioAnulo.Text = If(movimiento.usuarioAnula Is Nothing, "", movimiento.tblUsuario.nombre)
            lblUsuarioConfirmo.Text = If(movimiento.usuarioConfirma Is Nothing, "", movimiento.tblUsuario1.nombre)
        End If
    End Sub

    'GUARDAR CAMBIOS
    Private Sub fnGuardarCambios()
        Dim success As Boolean = True

        Try
            If pctVisorFoto.Image IsNot Nothing Then
                pctVisorFoto.Image = Nothing
            End If

            'Recorremos el grid para guardar los cambios
            For i As Integer = 0 To Me.grdDirecciones.RowCount - 1
                fnGuardar_foto(idMovimiento, i, grdDirecciones.Rows(i).Cells("extension").Value)
            Next

        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            success = False
        End Try


        If success Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
            fnLlenarFotos(idMovimiento)
        Else
            alerta.fnErrorGuardar()
        End If

    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    'EVENTO GUARDAR
    Private Sub fnGuardar() Handles Me.panel0
        If RadMessageBox.Show("¿Desea guardar los cambios?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            fnGuardarCambios()
        End If
    End Sub

    'CLIC BOTON SUBIR FOTO
    Private Sub btnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        fnSubirFoto(pctVisorFoto)
    End Sub

    'SUBIR FOTO
    Private Sub fnSubirFoto(ByRef pct)
        Dim abrir As New OpenFileDialog
        With abrir
            .InitialDirectory = ""
            .Filter = "Todos los Archivos|*.*|JPEGs|*.jpg|GIFs|*.gif|Bitmaps|*.bmp|PNGs|*.png"
            .FilterIndex = 2
        End With

        If (abrir.ShowDialog = DialogResult.OK) Then

            Dim stream As New System.IO.StreamReader(abrir.FileName)
            pct.Image = Image.FromStream(stream.BaseStream)
            stream.Dispose()
            pct.SizeMode = PictureBoxSizeMode.StretchImage
            pct.BorderStyle = BorderStyle.Fixed3D

            'Obtenemos la extension del archivo
            Dim extension As String = Split(abrir.SafeFileName, ".").ElementAt(1)

            'Agregamos una fila al grid
            Dim fila As String() = {"0", abrir.FileName.ToString, "0", "", extension}
            Me.grdDirecciones.Rows.Add(fila)
        End If
    End Sub

    'Funcion utilizada para guardar una foto
    Private Sub fnGuardar_foto(ByVal codigo As Integer, ByVal fila As Integer, ByVal extension As String)
        Dim success As Boolean = True

        Using transaction As New TransactionScope
            Try
                'Obtenemos el codigo de la imagen
                Dim idFoto As Integer = CType(Me.grdDirecciones.Rows(fila).Cells("codigo").Value, Integer)
                Dim direccion As String = CType(Me.grdDirecciones.Rows(fila).Cells("direccion").Value, String)
                Dim elimina As Integer = CType(Me.grdDirecciones.Rows(fila).Cells("elimina").Value, Integer)

                'Si elimin
                If elimina > 0 Then
                    'Obtenemos y eliminamos la foto de la carpeta de imagenes
                    Dim foto As tblBanco_CreditoFoto = (From x In ctx.tblBanco_CreditoFoto Where x.codigo = idFoto Select x).FirstOrDefault
                    'Si ya tiene codigo
                    fnEliminaFoto(Path.Combine(mdlPublicVars.General_CarpetaImagenes, foto.codigo & "." & foto.extension))
                    ctx.DeleteObject(foto)
                    ctx.SaveChanges()
                ElseIf idFoto = 0 Then
                    'Creamos la nueva imagen
                    Dim foto As New tblBanco_CreditoFoto
                    foto.credito = codigo
                    foto.extension = extension
                    ctx.AddTotblBanco_CreditoFoto(foto)
                    ctx.SaveChanges()
                    Dim codFoto As Integer = foto.codigo
                    'guardar la imagen.
                    Dim Ruta As String = Path.Combine(mdlPublicVars.BancoCredito_CarpetaArchivos, codFoto & "." & extension)
                    Dim stream As New System.IO.StreamReader(direccion)
                    Dim imagen As Image = Image.FromStream(stream.BaseStream)
                    stream.Dispose()
                    Dim bmap As Bitmap = New Bitmap(imagen)
                    bmap.Save(Ruta, imagen.RawFormat)
                    bmap.Dispose()
                    ctx.SaveChanges()
                End If
                transaction.Complete()
            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If

            End Try
        End Using
    End Sub

    'Elimina una foto
    Private Sub fnEliminaFoto(ByVal dir As String)
        Try
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
        Catch ex As Exception

        End Try
    End Sub

    'Llena el grid de fotos
    Private Sub fnLlenarFotos(ByVal codigo As Integer)
        Try
            Me.grdDirecciones.Rows.Clear()
            'Obtenemos las fotos del articulo
            Dim fotos As List(Of tblBanco_CreditoFoto) = (From x In ctx.tblBanco_CreditoFoto Where x.credito = codigo Select x).ToList
            Dim i As Integer = 0
            For Each foto As tblBanco_CreditoFoto In fotos
                i += 1
                Dim fila As String()
                Dim ruta As String = Path.Combine(mdlPublicVars.BancoCredito_CarpetaArchivos, foto.codigo & "." & foto.extension)
                fila = {foto.codigo, ruta, "0", "Imagen " & i}
                Me.grdDirecciones.Rows.Add(fila)
            Next
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub grdDirecciones_UserAddedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdDirecciones.UserAddedRow
        If grdDirecciones.RowCount > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDirecciones)
            fnCargarFoto(pctVisorFoto, Me.grdDirecciones.Rows(fila).Cells("direccion").Value)
        End If
    End Sub

    'Maneja el evento de la tecla DELETE
    Private Sub grdProductos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDirecciones.KeyDown
        If RadMessageBox.Show("¿Desea eliminar la imagen?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            mdlPublicVars.fnGrid_EliminarFila(sender, e, grdDirecciones, "codigo")
        End If
    End Sub

    Private Sub grdDirecciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDirecciones.SelectionChanged
        If Me.grdDirecciones.RowCount > 0 Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDirecciones)
            fnCargarFoto(pctVisorFoto, Me.grdDirecciones.Rows(fila).Cells("direccion").Value)
        End If
    End Sub

    'Funcion utilizada para cargar las fotos
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

    Private Sub grdDirecciones_UserDeletedRow(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs) Handles grdDirecciones.UserDeletedRow
        If Me.grdDirecciones.RowCount = 0 Then
            pctVisorFoto.Image = Nothing
        End If
    End Sub
End Class
