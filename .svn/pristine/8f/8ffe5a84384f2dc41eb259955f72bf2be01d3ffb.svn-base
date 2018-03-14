Imports System.Linq
Imports Telerik.WinControls

Public Class frmBusquedaArticuloModificaPendiente
    Private _idPendiente As Integer

    Public Property idPendiente As Integer
        Get
            idPendiente = _idPendiente
        End Get
        Set(value As Integer)
            _idPendiente = value
        End Set
    End Property


    Private Sub frmBusquedaArticuloModificaPendiente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.fnFormatoGridEspeciales(grdProductos)
        mdlPublicVars.comboActivarFiltroLista(cmbImportancia)
        fnLlenarCombo()
        fnLlenarDatos()
    End Sub

    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Dim importancia = (From x In ctx.tblArticuloImportancias Select x.codigo, x.nombre)

        With cmbImportancia
            .DataSource = Nothing
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .DataSource = importancia
        End With
    End Sub

    'LLENAR DATOS
    Private Sub fnLlenarDatos()
        'Obtenemos el pendiente por pedir
        Dim pendiente As tblPendientePorPedir = (From x In ctx.tblPendientePorPedirs.AsEnumerable
                                                 Where x.codigo = idPendiente
                                                 Select x).FirstOrDefault

        txtCodigo.Text = pendiente.codigoArticulo
        txtDescripcion.Text = pendiente.descripcion
        txtObservacion.Text = pendiente.observacion
        cmbImportancia.SelectedValue = pendiente.importancia
        nm0Cantidad.Value = pendiente.cantidad

        If pendiente.bitCreado Then
            txtCodigo.Enabled = False
            txtDescripcion.Enabled = False
            txtObservacion.Enabled = False
            cmbImportancia.Enabled = False
            nm0Cantidad.Enabled = False
        End If
    End Sub

    'VERIFICAR
    Private Sub btnVerificar_Click(sender As System.Object, e As System.EventArgs) Handles btnVerificar.Click
        Dim codArt As String = txtCodigo.Text
        grdProductos.DataSource = Nothing

        If Not codArt.Equals("") Then
            'Verifica si hay productos con ese codigo
            Dim productos = (From x In ctx.tblInventarios Where x.idTipoInventario = mdlPublicVars.General_idTipoInventario _
                             And x.tblArticulo.codigo1.Contains(codArt)
                             Select Codigo = x.tblArticulo.codigo1, Articulo = x.tblArticulo.nombre1)
            Me.grdProductos.DataSource = productos

            fnConfiguraProductos()
        End If
    End Sub

    'CONFIGURA PRODUCTOS
    Private Sub fnConfiguraProductos()
        If Me.grdProductos.ColumnCount > 0 Then
            For i As Integer = 0 To Me.grdProductos.ColumnCount - 1
                Me.grdProductos.Columns(i).TextAlignment = ContentAlignment.MiddleCenter
            Next

            Me.grdProductos.Columns("Codigo").Width = 25
            Me.grdProductos.Columns("Articulo").Width = 75
        End If
    End Sub

    'GUARDAR
    Private Sub fnGuardar() Handles Me.panel0
        If txtCodigo.Enabled Then
            If Not fnErrores() Then
                'Verificamos si el codigo no existe
                If Not fnBuscarArticulo(txtCodigo.Text) Then
                    If RadMessageBox.Show("¿Desea guardar los cambios?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnAgregarPendiente(False, txtCodigo.Text)
                        RadMessageBox.Show("Registro modificado exitosamente", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        fnLlenarDatos()
                    End If
                Else
                    If RadMessageBox.Show("Ya existe un articulo con ese código,Desea guardar los cambios y agregar pendiente por surtir? ", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        fnAgregarPendiente(True, txtCodigo.Text)
                        RadMessageBox.Show("Registro modificado exitosamente!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Info)
                        fnLlenarDatos()
                    End If
                End If

            End If
        End If
    End Sub

    'BUSCA ARTICULO
    Private Function fnBuscarArticulo(ByVal codArt As String) As Boolean
        Dim articulo As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable
                                       Where x.codigo1 = codArt
                                       Select x).FirstOrDefault

        If articulo IsNot Nothing Then
            Return True
        End If

        Return False
    End Function

    'GUARDAR CAMBIOS  PENDIENTE
    Private Sub fnAgregarPendiente(codigoExiste As Boolean, codArt As String)
        Dim fechaServer As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim hora As String = mdlPublicVars.fnHoraServidor

        'Agregamos el articulo a la tabla de pendientes por pedir
        Dim pendiente As tblPendientePorPedir = (From x In ctx.tblPendientePorPedirs Where x.codigo = idPendiente Select x).FirstOrDefault
        pendiente.bitCreado = codigoExiste
        pendiente.anulado = False
        pendiente.cantidad = nm0Cantidad.Value
        pendiente.codigoArticulo = codArt
        pendiente.descripcion = txtDescripcion.Text
        pendiente.importancia = CInt(cmbImportancia.SelectedValue)
        pendiente.observacion = txtObservacion.Text
        pendiente.saldo = nm0Cantidad.Value
        pendiente.usuario = mdlPublicVars.idUsuario

        ctx.SaveChanges()

        'Si el codigo existe agregamos un nuevo pendiente por surtir
        If codigoExiste Then
            'Obtenemos informacion del articulo
            Dim articulo As tblArticulo = (From x In ctx.tblArticuloes.AsEnumerable Where x.codigo1 = codArt Select x).FirstOrDefault

            Dim surtir As New tblSurtir
            'Creamos el pendiente por surtir
            surtir.articulo = articulo.idArticulo
            surtir.cantidad = nm0Cantidad.Value
            surtir.saldo = nm0Cantidad.Value
            surtir.fechaTransaccion = pendiente.fechaRegistro
            surtir.anulado = False
            surtir.usuario = mdlPublicVars.idUsuario
            surtir.vendedor = mdlPublicVars.idVendedor
            surtir.cliente = idCliente

            ctx.AddTotblSurtirs(surtir)
            ctx.SaveChanges()

            pendiente.pendienteSurtir = surtir.codigo
            ctx.SaveChanges()
        End If

    End Sub

    'VERIFICA ERRORES
    Private Function fnErrores() As Boolean
        If txtCodigo.Text.Equals("") Or txtCodigo.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar un codigo!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If txtDescripcion.Text.Equals("") Or txtDescripcion.Text.Trim.Length = 0 Then
            RadMessageBox.Show("Debe ingresar un descripción!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If Not (CInt(cmbImportancia.SelectedValue) > 0) Then
            RadMessageBox.Show("Debe elegir una importancia!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        If nm0Cantidad.Value <= 0 Then
            RadMessageBox.Show("Cantidad debe de ser mayor a cero (0)!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        Return False
    End Function

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

End Class