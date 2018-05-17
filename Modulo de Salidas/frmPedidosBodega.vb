Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports System.Transactions
Imports System.Data.EntityClient


Public Class frmPedidosBodega
    Public bitNoEditable As Boolean = False

    Private _idSalida As Integer
    Public Property idSalida As Integer
        Get
            idSalida = _idSalida
        End Get
        Set(ByVal value As Integer)
            _idSalida = value
        End Set
    End Property

    Private Sub frmPedidosBodega_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Focus()
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdEmpacado)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdSacado)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdRevisado)

        mdlPublicVars.fnFormatoGridMovimientos(Me.grdEmpacado)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdSacado)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdRevisado)

        mdlPublicVars.fnGrid_iconos(Me.grdEmpacado)
        mdlPublicVars.fnGrid_iconos(Me.grdSacado)
        mdlPublicVars.fnGrid_iconos(Me.grdRevisado)

        fnLlenarGrid()
        fnLlenar()
    End Sub

    Private Sub fnLlenar()
        Try
            Dim salida As tblSalida = (From x In ctx.tblSalidas Where x.idSalida = idSalida Select x).FirstOrDefault
            lblCodigoSalida.Text = salida.idSalida
            lblDocumento.Text = salida.documento
            lblFecha.Text = salida.fechaRegistro
            lblObservacion.Text = salida.observacion
            lblTotal.Text = Format(salida.total, mdlPublicVars.formatoMoneda)
            lblCliente.Text = salida.tblCliente.Negocio
            lblVendedor.Text = salida.tblVendedor.nombre

            'Consultamos el registro de bodega
            Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalida = idSalida Select x).FirstOrDefault
            Dim sacado As Integer
            Dim revisado As Integer
            Dim empacado As Integer


            If bodega.sacado Is Nothing Then
                sacado = ""
            Else
                sacado = CType(bodega.sacado, Integer)
            End If

            If bodega.revisado Is Nothing Then
                revisado = 0
            Else
                revisado = CType(bodega.revisado, Integer)
            End If

            If bodega.empacado Is Nothing Then
                empacado = ""
            Else
                empacado = CType(bodega.empacado, Integer)
            End If


            ''cmbEmpacado.SelectedValue = empacado
            ''cmbRevisado.SelectedValue = revisado
            ''cmbSacado.SelectedValue = sacado
            txtObservacion.Text = bodega.observacion

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnLlenarGrid()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Me.grdSacado.Rows.Clear()
                Me.grdEmpacado.Rows.Clear()
                Me.grdRevisado.Rows.Clear()

                Dim empleados As List(Of tblEmpleado) = (From x In conexion.tblEmpleadoes Where x.idpuesto = 1 Order By x.nombre Ascending Select x).ToList

                Dim fila As Object()
                Dim fila2 As Object()

                For Each index As tblEmpleado In empleados

                    fila = {index.idEmpleado, 0, index.nombre}
                    fila2 = {index.idEmpleado, 0, index.nombre, 0}

                    Me.grdEmpacado.Rows.Add(fila)
                    Me.grdRevisado.Rows.Add(fila)
                    Me.grdSacado.Rows.Add(fila2)

                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try

        fnConfiguracionGrds()
        If idSalida > 0 Then
            fnCargarDatos()
        End If
    End Sub

    Private Sub fnCargarDatos()
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim salidabodega = (From x In conexion.tblsalidaBodegas Where x.idsalida = idSalida Select x.idsalidaBodega).FirstOrDefault

                Dim salidabodegac As Integer = salidabodega

                Dim bodegadetalle As List(Of tblsalidabodega_detalle) = (From x In conexion.tblsalidabodega_detalle Where x.idsalidabodega = salidabodegac Select x).ToList

                Dim codigo As Integer
                Dim codigoempleado As Integer

                For Each index As tblsalidabodega_detalle In bodegadetalle

                    codigo = index.idempleado

                    If index.empacado = True Then
                        For fila As Integer = 0 To Me.grdEmpacado.Rows.Count - 1
                            codigoempleado = Me.grdEmpacado.Rows(fila).Cells("Codigo").Value

                            If codigoempleado = codigo Then
                                Me.grdEmpacado.Rows(fila).Cells("chkAgregar").Value = True
                            End If
                        Next
                    ElseIf index.sacado = True Then
                        For fila As Integer = 0 To Me.grdSacado.Rows.Count - 1
                            codigoempleado = Me.grdSacado.Rows(fila).Cells("Codigo").Value

                            If codigoempleado = codigo Then
                                Me.grdSacado.Rows(fila).Cells("chkAgregar").Value = True
                                Me.grdSacado.Rows(fila).Cells("txmErrores").Value = index.errores
                            End If
                        Next
                    ElseIf index.revisado Then
                        For fila As Integer = 0 To Me.grdRevisado.Rows.Count - 1
                            codigoempleado = Me.grdRevisado.Rows(fila).Cells("Codigo").Value

                            If codigoempleado = codigo Then
                                Me.grdRevisado.Rows(fila).Cells("chkAgregar").Value = True
                            End If
                        Next
                    End If

                Next

                conn.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnConfiguracionGrds()
        Try

            Me.grdEmpacado.Columns("Codigo").IsVisible = False
            Me.grdRevisado.Columns("Codigo").IsVisible = False
            Me.grdSacado.Columns("Codigo").IsVisible = False

            Me.grdEmpacado.Columns("chkAgregar").Width = 50
            Me.grdRevisado.Columns("chkAgregar").Width = 50
            Me.grdSacado.Columns("chkAgregar").Width = 50

            ''Me.grdEmpacado.Columns("Nombre").ReadOnly = True
            ''Me.grdRevisado.Columns("Nombre").ReadOnly = True
            ''Me.grdSacado.Columns("Nombre").ReadOnly = True

            Me.grdSacado.Columns("Codigo").ReadOnly = True
            Me.grdSacado.Columns("chkAgregar").ReadOnly = False
            Me.grdSacado.Columns("Nombre").ReadOnly = True
            Me.grdSacado.Columns("txmErrores").ReadOnly = False

        Catch ex As Exception

        End Try
    End Sub

    Private Function fnValidarGuardado() As Boolean
        Try
            Dim conexion As dsi_pos_demoEntities
            Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
                conn.Open()
                conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

                Dim idsalidabodegas As Integer

                Dim salidabodega = (From x In conexion.tblsalidaBodegas Where x.idsalida = idSalida Select x.idsalidaBodega).FirstOrDefault

                idsalidabodegas = salidabodega

                Dim contador = (From x In conexion.tblsalidabodega_detalle Where x.idsalidabodega = idsalidabodegas Select x).Count


                If contador > 0 Then
                    Return True
                ElseIf contador = 0 Then
                    Return False
                ElseIf contador Is Nothing Then
                    Return False
                End If
                conn.Close()
            End Using


        Catch ex As Exception

        End Try
    End Function

    Private Sub pbModificar_Click() Handles Me.panel0
        If fnErrores() = True Then
            alerta.fnError()
            Exit Sub
        End If

        If fnValidarGuardado() = True Then
            alerta.contenido = "No se Puede Modificar"
            alerta.fnErrorContenido()
            Exit Sub
        End If

        Try
            If CInt(Me.txtErrores.Text) >= 0 Then

            Else
                alerta.contenido = "Errores no puede estar vacio. Coloque Cero o el numero correspondiente."
                alerta.fnErrorContenido()
                Exit Sub
            End If
        Catch ex As Exception
            alerta.contenido = "Errores no puede estar vacio. Coloque Cero o el numero correspondiente."
            alerta.fnErrorContenido()
            Exit Sub
        End Try

        Dim success As Boolean = True
        Dim codigoSalida As Integer = CType(lblCodigoSalida.Text, Integer)
        Using transaction As New TransactionScope

            Try
                Dim fecha As DateTime = fnFecha_horaServidor()
                Dim sacado As String ''= Me.cmbSacado.SelectedValue
                Dim revisado As Integer ''= Me.cmbRevisado.SelectedValue
                Dim empacado As String ''= Me.cmbEmpacado.SelectedValue
                Dim idsalidabodega As Integer

                'Obtenemos el registro de bodega a modificar
                Dim bodega As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalida = codigoSalida Select x).FirstOrDefault

                bodega.observacion = txtObservacion.Text
                bodega.errores = txtErrores.Text
                ctx.SaveChanges()

                idsalidabodega = bodega.idsalidaBodega

                Dim codigoempleado As Integer
                Dim errores As Integer


                For index As Integer = 0 To Me.grdEmpacado.Rows.Count - 1

                    If Me.grdEmpacado.Rows(index).Cells("chkAgregar").Value = True Then

                        Dim detalle As New tblsalidabodega_detalle

                        codigoempleado = Me.grdEmpacado.Rows(index).Cells("Codigo").Value

                        detalle.idsalidabodega = idsalidabodega
                        detalle.idempleado = codigoempleado
                        detalle.empacado = True
                        detalle.sacado = False
                        detalle.revisado = False

                        ctx.AddTotblsalidabodega_detalle(detalle)
                        ctx.SaveChanges()

                        Dim bode As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = idsalidabodega Select x).FirstOrDefault

                        bode.fechaEmpacado = fecha

                        ctx.SaveChanges()
                    End If
                Next

                For index As Integer = 0 To Me.grdRevisado.Rows.Count - 1

                    If Me.grdRevisado.Rows(index).Cells("chkAgregar").Value = True Then

                        Dim detalle As New tblsalidabodega_detalle

                        codigoempleado = Me.grdRevisado.Rows(index).Cells("Codigo").Value

                        detalle.idsalidabodega = idsalidabodega
                        detalle.idempleado = codigoempleado
                        detalle.empacado = False
                        detalle.sacado = False

                        ctx.AddTotblsalidabodega_detalle(detalle)
                        ctx.SaveChanges()

                        Dim bode As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = idsalidabodega Select x).FirstOrDefault

                        bode.fechaRevisado = fecha

                        ctx.SaveChanges()
                    End If
                Next

                For index As Integer = 0 To Me.grdSacado.Rows.Count - 1

                    If Me.grdSacado.Rows(index).Cells("chkAgregar").Value = True Then

                        Dim detalle As New tblsalidabodega_detalle

                        codigoempleado = Me.grdSacado.Rows(index).Cells("Codigo").Value
                        errores = Me.grdSacado.Rows(index).Cells("txmErrores").Value



                        detalle.idsalidabodega = idsalidabodega
                        detalle.idempleado = codigoempleado
                        detalle.empacado = False
                        detalle.sacado = True
                        detalle.revisado = False
                        detalle.errores = errores


                        ctx.AddTotblsalidabodega_detalle(detalle)
                        ctx.SaveChanges()

                        Dim bode As tblsalidaBodega = (From x In ctx.tblsalidaBodegas Where x.idsalidaBodega = idsalidabodega Select x).FirstOrDefault

                        bode.fechaSacado = fecha

                        ctx.SaveChanges()
                    End If
                Next

                transaction.Complete()

            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If

            End Try
        End Using

        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()
            'fnLlenar()
            Me.Close()
        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If
    End Sub

    'SALIR
    Private Sub fnSalir() Handles Me.panel1
        Me.Close()
    End Sub

    Private Sub grdRevisado_Click(sender As Object, e As EventArgs) Handles grdRevisado.Click
        Try
            If Me.grdRevisado.CurrentColumn.Name = "chkAgregar" Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdRevisado)

                Dim valor As Boolean

                valor = Me.grdRevisado.Rows(fila).Cells("chkAgregar").Value

                If valor = False Then
                    Me.grdRevisado.Rows(fila).Cells("chkAgregar").Value = True
                ElseIf valor = True Then
                    Me.grdRevisado.Rows(fila).Cells("chkAgregar").Value = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSacado_Click(sender As Object, e As EventArgs) Handles grdSacado.Click
        Try
            If Me.grdSacado.CurrentColumn.Name = "chkAgregar" Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdSacado)

                Dim valor As Boolean

                valor = Me.grdSacado.Rows(fila).Cells("chkAgregar").Value

                If valor = False Then
                    Me.grdSacado.Rows(fila).Cells("chkAgregar").Value = True
                ElseIf valor = True Then
                    Me.grdSacado.Rows(fila).Cells("chkAgregar").Value = False
                End If

                If valor = 2 Then

                    RadMessageBox.Show("No se permite seleccionar mas de 2 personas!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdEmpacado_Click(sender As Object, e As EventArgs) Handles grdEmpacado.Click
        Try
            If Me.grdEmpacado.CurrentColumn.Name = "chkAgregar" Then

                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdEmpacado)

                Dim valor As Boolean

                valor = Me.grdEmpacado.Rows(fila).Cells("chkAgregar").Value

                If valor = False Then
                    Me.grdEmpacado.Rows(fila).Cells("chkAgregar").Value = True
                ElseIf valor = True Then
                    Me.grdEmpacado.Rows(fila).Cells("chkAgregar").Value = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    'Funcion utilizada para verificar errores
    Private Function fnErrores() As Boolean

        If Me.txtErrores.Text.Length = 0 Or txtErrores.Text.Trim.Equals("") Then
            RadMessageBox.Show("El campo de errores no debe estar vacio!", mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Error)
            Return True
        End If

        Dim contador As Integer = 0

        ''Sacado
        For i As Integer = 0 To Me.grdSacado.Rows.Count - 1
            If Me.grdSacado.Rows(i).Cells("chkAgregar").Value = True Then
                contador += 1
            End If
        Next

        If contador = 0 Then
            RadMessageBox.Show("No ha seleccionado ninguna persona para Sacado!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            contador = 0
            Return True
        Else
            contador = 0
        End If

        ''Revisado
        For i As Integer = 0 To Me.grdRevisado.Rows.Count - 1
            If Me.grdRevisado.Rows(i).Cells("chkAgregar").Value = True Then
                contador += 1
            End If
        Next

        If contador = 0 Then
            RadMessageBox.Show("No ha seleccionado ninguna persona para Revisado!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            contador = 0
            Return True
        Else
            contador = 0
        End If

        ''Empacado
        For i As Integer = 0 To Me.grdEmpacado.Rows.Count - 1
            If Me.grdEmpacado.Rows(i).Cells("chkAgregar").Value = True Then
                contador += 1
            End If
        Next

        If contador = 0 Then
            RadMessageBox.Show("No ha seleccionado ninguna persona para Empacado!", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            contador = 0
            Return True
        Else
            contador = 0
        End If

        Return False

    End Function

    Private Sub grdSacado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSacado.KeyDown
        Try
            If Me.grdSacado.CurrentRow.Index >= 0 Then
                Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(grdSacado)
                Dim col As Integer = Me.grdSacado.CurrentColumn.Index
                Dim nombre As String = Me.grdSacado.Columns(col).Name

                If nombre = "txmErrores" Then
                    If e.KeyCode = Keys.Delete Then
                        Me.grdSacado.Rows(fila).Cells(nombre).Value = 0
                    ElseIf e.KeyCode = Keys.Back Then
                        Me.grdSacado.Rows(fila).Cells(nombre).Value = 0
                    End If

                    If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Then
                        If Me.grdSacado.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdSacado.Rows(fila).Cells(nombre).Value = Char.ConvertFromUtf32(e.KeyValue)
                        Else
                            Me.grdSacado.Rows(fila).Cells(nombre).Value += Char.ConvertFromUtf32(e.KeyValue)
                        End If
                    ElseIf (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) Then
                        If Me.grdSacado.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdSacado.Rows(fila).Cells(nombre).Value = e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                        Else
                            Me.grdSacado.Rows(fila).Cells(nombre).Value += e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1)
                        End If
                    ElseIf (e.KeyCode = 110) Or (e.KeyCode = 190) Then

                        If Me.grdSacado.Rows(fila).Cells(nombre).Value = "0" Then
                            Me.grdSacado.Rows(fila).Cells(nombre).Value += "."
                        Else
                            Me.grdSacado.Rows(fila).Cells(nombre).Value += "."
                        End If
                    ElseIf e.KeyValue >= 65 And e.KeyValue <= 90 Then
                        Me.grdSacado.Columns(nombre).ReadOnly = True
                        Me.grdSacado.Rows(fila).Cells(nombre).EndEdit()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
