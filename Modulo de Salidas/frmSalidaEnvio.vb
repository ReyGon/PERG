Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions


Public Class frmSalidaEnvio

    Private _tblGuias As DataTable
    Public alerta As New bl_Alertas
    Public _codigoCliente As Integer
    Private _Codigo As Integer

    Public Property tblGuias As DataTable
        Get
            tblGuias = _tblGuias
        End Get
        Set(ByVal value As DataTable)
            _tblGuias = value
        End Set
    End Property


    Private _bitTemporal As Boolean
    Public Property bitTemporal As Boolean
        Get
            bitTemporal = _bitTemporal
        End Get
        Set(ByVal value As Boolean)
            _bitTemporal = value
        End Set
    End Property


    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set

    End Property

    Public Property codigoCliente() As Integer
        Get
            Return _codigoCliente
        End Get
        Set(ByVal value As Integer)
            _codigoCliente = value
        End Set

    End Property


    Private Sub frm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        base.fnResize(rgbDatos, Me, rpv)
    End Sub

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnx0Nuevo.Visible = True
        pnx0Nuevo.Enabled = True
        fnLlenarDatos()
        llenarCombos()
        llenagrid()
    End Sub

    'Funcion utilizada para llenar la informacion
    Private Sub fnLlenarDatos()

        Try
            If bitTemporal = False Then


                'Obtenemos la primer salida de esa factura
                Dim salida As tblSalida = (From x In ctx.tblSalidas.AsEnumerable Where x.idSalida = Codigo _
                                          Select x).FirstOrDefault


                'Asignamos los datos
                lblDocumento.Text = salida.documento ' 
                lblFecha.Text = Format(salida.fechaRegistro, mdlPublicVars.formatoFecha)
                lblCliente.Text = salida.tblCliente.Negocio

            ElseIf bitTemporal = True Then

                Dim cli = (From y In ctx.tblClientes Where y.idCliente = codigoCliente Select y.Nombre1).FirstOrDefault

                lblDocumento.Text = "En Proceso"
                lblFecha.Text = fnFechaServidor()
                lblCliente.Text = cli

            End If
        Catch ex As Exception

        End Try
        
    End Sub


    Private Sub llenarCombos()

        Try

            Dim cas2 = From s In ctx.tblEnvioTipoes _
                      Select Codigo = s.codigo, Nombre = s.nombre

            With Me.cmbEnvioTipo
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cas2
            End With

            Dim con = From x In ctx.tblEnvio_Empresa
                      Select Codigo = x.codigo, Nombre = x.nombre

            With Me.cmbEmpresa
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = con
            End With

        Catch ex As Exception

        End Try


    End Sub

    Private Sub llenagrid()


        If bitTemporal = False Then
            Dim companyInfo = From x In ctx.tblEnvio_Salida Where x.salida = Codigo
                Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
                envioTipo = x.tblEnvio.tblEnvioTipo.nombre, Empresa = x.tblEnvio.tblEnvio_Empresa.nombre, Observacion = x.tblEnvio.observacion,
                Precio = x.tblEnvio.precio, Documento = x.tblEnvio.documento

            'Dim companyInfo = From x In ctx.tblEnvio_Salida Where x.salida = Codigo
            '    Select Codigo = x.codigo, Numero = x.tblEnvio.numero, Paquetes = x.tblEnvio.paquetes,
            '    envioTipo = x.tblEnvio.tblEnvioTipo.nombre, Empresa = x.tblEnvio.tb.nombre, Observacion = x.tblEnvio.observacion,
            '    Precio = x.tblEnvio.precio, Documento = x.tblEnvio.documento
            'tblProveedorTipoFletes()


            Me.grdDatos.DataSource = companyInfo

            Me.grdDatos.Columns("envioTipo").HeaderText = "Tipo Envio"
            Me.grdDatos.Columns("Numero").HeaderText = "Documento"

            Me.grdDatos.Columns("Documento").IsVisible = False

        ElseIf bitTemporal = True Then

            'llenar el grid view con tabla temporal.
            Me.grdDatos.DataSource = tblGuias

            'ocultamos columnas 
            grdDatos.Columns("usuario").IsVisible = False
            grdDatos.Columns("fechatransaccion").IsVisible = False
            grdDatos.Columns("noEnvioTipo").IsVisible = False
            grdDatos.Columns("envio_empresa").IsVisible = False

            grdDatos.Columns("numero").HeaderText = "Documento"
            grdDatos.Columns("envioTipo").HeaderText = "Tipo Envio"

            grdDatos.Columns("codigo").HeaderText = "Codigo"
            grdDatos.Columns("paquetes").HeaderText = "Paquetes"
            grdDatos.Columns("empresa").HeaderText = "Empresa"
            grdDatos.Columns("observacion").HeaderText = "Observacion"
            grdDatos.Columns("precio").HeaderText = "Precio"

        End If

    End Sub

    Private Sub frm_nuevoRegistro() Handles Me.nuevoRegistro
        Call limpiaCampos()


    End Sub

    Private Sub frm_modificaRegistro() Handles Me.modificaRegistro
        fnModificar()
    End Sub

    Private Sub frm_grabaRegistro() Handles Me.grabaRegistro
        fnGuardar()
    End Sub

    Private Function fnModificar() As Boolean

        Dim success As Boolean = True

        If Me.grdDatos.Rows.Count = 0 Then
            Exit Function

        End If

        If Me.grdDatos.Rows.Count > 0 Then
            If Me.grdDatos.CurrentRow.Index < 0 Then
                Exit Function
            End If
        End If


        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim codEmperesa As Integer = CType(cmbEmpresa.SelectedValue, Integer)


        Using transaction As New TransactionScope


        Try
            If bitTemporal = False Then


                Dim env = (From y In ctx.tblEnvio_Salida Where y.codigo = Me.txtCodigo.Text).FirstOrDefault
                Dim codEnvio As Integer = env.envio



                Dim cod As Integer = CType(cmbEnvioTipo.SelectedValue, Integer)

                Dim m As tblEnvio = (From e1 In ctx.tblEnvios Where e1.codigo = codEnvio Select e1).First() '

                m.paquetes = txtPaquetes.Text
                m.numero = txtNumero.Text
                m.envioTipo = (CType(cmbEnvioTipo.SelectedValue, Integer))
                m.observacion = txtObservacion.Text
                m.precio = nm2Precio.Value
                m.envio_empresa = CType(cmbEmpresa.SelectedValue, Integer)
                m.documento = txtNumero.Text

                ctx.SaveChanges()
                Call llenagrid()


            ElseIf bitTemporal = True Then


                'modificar en tabla temporal.

                Dim codigo As Integer = txtCodigo.Text

                Dim cod As Integer = CType(cmbEnvioTipo.SelectedValue, Integer) 'capturamos el valor del combo
                Dim te As tblEnvioTipo = (From x In ctx.tblEnvioTipoes Where x.codigo = cod Select x).First
                Dim em As tblEnvio_Empresa = (From y In ctx.tblEnvio_Empresa Where y.codigo = codEmperesa Select y).First

                For i As Integer = 0 To tblGuias.Rows.Count - 1

                    If CType(tblGuias.Rows(i).Item("codigo"), Integer) = txtCodigo.Text Then

                        tblGuias.Rows(i).Item("numero") = txtNumero.Text
                        tblGuias.Rows(i).Item("paquetes") = txtPaquetes.Text
                        tblGuias.Rows(i).Item("noEnvioTipo") = te.codigo
                        tblGuias.Rows(i).Item("envioTipo") = te.nombre

                        tblGuias.Rows(i).Item("envio_empresa") = em.codigo
                        tblGuias.Rows(i).Item("empresa") = em.nombre
                        tblGuias.Rows(i).Item("usuario") = mdlPublicVars.idUsuario
                        tblGuias.Rows(i).Item("fechatransaccion") = fecha
                        tblGuias.Rows(i).Item("observacion") = txtObservacion.Text
                        tblGuias.Rows(i).Item("precio") = nm2Precio.Value
                        ' tblGuias.Rows.Add(maximo + 1, txtNumero.Text, txtPaquetes.Text, te.codigo, te.nombre, codEmperesa, em.nombre, mdlPublicVars.idUsuario, fecha, txtObservacion.Text, nm2Precio.Value)
                        i = i + 1
                    End If
                Next

                llenagrid()

            End If

                transaction.Complete()

            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    success = False
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Function

    Private Sub frm_eliminaRegistro() Handles Me.eliminaRegistro


        fnEliminarRegistro()


    End Sub

    Private Function fnGuardar() As Boolean

        Dim success As Boolean = True


        If RadMessageBox.Show("¿Dese agregar la guia?", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Function
        End If

        Dim fecha As DateTime = mdlPublicVars.fnFecha_horaServidor
        Dim codEmperesa As Integer = CType(cmbEmpresa.SelectedValue, Integer)


        Using transaction As New TransactionScope

            Dim m As New tblEnvio
            Try

                If bitTemporal = False Then

                    Dim cod As Integer = CType(cmbEnvioTipo.SelectedValue, Integer)

                    Dim te As tblEnvioTipo = (From x In ctx.tblEnvioTipoes Where x.codigo = cod Select x).First

                    m.paquetes = txtPaquetes.Text
                    m.numero = txtNumero.Text

                    m.envioTipo = (CType(cmbEnvioTipo.SelectedValue, Integer))

                    m.usuario = mdlPublicVars.idUsuario
                    m.fechatransaccion = fecha
                    m.observacion = txtObservacion.Text
                    m.precio = nm2Precio.Value
                    m.documento = txtNumero.Text 'verificar si es el mismo de numero
                    m.envio_empresa = codEmperesa ' codigo de empresa de transporte

                    ctx.AddTotblEnvios(m)

                    'Agregamos el registro en la tabla intermedia
                    Dim guia_factura As New tblEnvio_Salida
                    guia_factura.envio = m.codigo
                    guia_factura.salida = Codigo

                    ctx.AddTotblEnvio_Salida(guia_factura)

                    ctx.SaveChanges()
                    Call llenagrid()
                    frm_nuevoRegistro()

                ElseIf bitTemporal = True Then


                    Dim em As tblEnvio_Empresa = (From y In ctx.tblEnvio_Empresa Where y.codigo = codEmperesa Select y).First

                    Dim cod As Integer = CType(cmbEnvioTipo.SelectedValue, Integer)

                    Dim te As tblEnvioTipo = (From x In ctx.tblEnvioTipoes Where x.codigo = cod Select x).First

                    Dim maximo As Integer = 0 ' variable para guardar el codigo en el grid

                    For i As Integer = 0 To tblGuias.Rows.Count - 1
                        Dim temporal As Integer = CType(tblGuias.Rows(i).Item("Codigo").ToString, Integer)

                        If temporal > maximo Then
                            maximo = temporal
                        End If
                    Next

                    tblGuias.Rows.Add(maximo + 1, txtNumero.Text, txtPaquetes.Text, te.codigo, te.nombre, em.codigo, em.nombre, mdlPublicVars.idUsuario, fecha, txtObservacion.Text, nm2Precio.Value)

                    llenagrid()

                End If

                transaction.Complete()

            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    success = False
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If



    End Function

    Private Sub fnDocSalida() Handles Me.reporte
        If Me.grdDatos.RowCount > 0 And Not txtCodigo.Text.Equals("") Then
            Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdDatos)
            Dim codigo As Integer = Me.grdDatos.Rows(fila).Cells("Codigo").Value

            'Obtenemos el id del cliente
            Dim codClie As Integer? = (From x In ctx.tblEnvio_Salida Join s In ctx.tblSalidas On s.idSalida Equals x.tblSalida.idSalida _
                                       Where x.codigo = codigo
                                      Group By s.idSalida, Cliente = s.idCliente
                                      Into Group Select Cliente).FirstOrDefault

            Dim c As New clsReporte
            c.tabla = mdlPublicVars.EntitiToDataTable(ctx.sp_reporteGuia("", codigo))

            c.nombreParametro = "@filtro"
            c.reporte = "rptGuiaFactura.rpt"
            c.parametro = ""

            frmDocumentosSalida.reporteBase = c.DocumentoReporte
            frmDocumentosSalida.bitGenerico = False
            frmDocumentosSalida.bitCliente = True
            frmDocumentosSalida.bitImg = False
            frmDocumentosSalida.codigo = codClie
            frmDocumentosSalida.bitListaCombo = False
            frmDocumentosSalida.ListaCombo = ""
            frmDocumentosSalida.Text = "Impresión"
            frmDocumentosSalida.Show()
        End If
    End Sub



    Private Function fnEliminarRegistro() As Boolean
        Dim success As Boolean = True

        If MsgBox("Esta seguro de eliminar este registro", vbYesNo + vbInformation, "!!!") = vbNo Then
            Exit Function
        End If


        Using transaction As New TransactionScope
            Try

                If bitTemporal = False Then


                    Dim env As tblEnvio_Salida = (From y In ctx.tblEnvio_Salida Where y.codigo = Me.txtCodigo.Text).FirstOrDefault
                    Dim codEnvio As Integer = env.envio  'Capturamos el codigo de envio

                    'hacer proceso normal.
                    Dim m As tblEnvio_Salida = (From e1 In ctx.tblEnvio_Salida Where e1.codigo = Me.txtCodigo.Text Select e1).First()
                    ctx.DeleteObject(m)
                    ctx.SaveChanges()

                    Dim guia As tblEnvio = (From x In ctx.tblEnvios Where x.codigo = codEnvio).FirstOrDefault
                    ctx.DeleteObject(guia)
                    ctx.SaveChanges()
                    Call llenagrid()


                ElseIf bitTemporal = True Then

                    'eliminar fila de tabla temporal.
                    Dim codigo As Integer = txtCodigo.Text

                    For i As Integer = 0 To tblGuias.Rows.Count - 1

                        If CType(tblGuias.Rows(i).Item("codigo"), Integer) = txtCodigo.Text Then
                            tblGuias.Rows().RemoveAt(i)
                            i = i + 1
                        End If
                    Next

                    llenagrid()

                End If

                ctx.SaveChanges()

                'paso 8, completar la transaccion.
                transaction.Complete()
            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    success = False
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alerta.contenido = "Registro guardado correctamente"
            alerta.fnGuardar()
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If


    End Function




End Class
