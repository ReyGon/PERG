Imports System.Linq
Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports System.Data.EntityClient
Imports Telerik.WinControls

Public Class frmEmpleados

    Private Sub frmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnLlenarCombo()
        llenagrid()
        mdlPublicVars.comboActivarFiltro(cmbPuesto)
        mdlPublicVars.fnGrid_iconos(Me.grdEmpleado)
        mdlPublicVars.fnFormatoGridEspeciales(Me.grdEmpleado)
        mdlPublicVars.fnFormatoGridMovimientos(Me.grdEmpleado)
    End Sub

    'Llenar combos
    Private Sub fnLlenarCombo()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ToString)

            Dim puestos = From x In conexion.tblpuestoes Select codigo = x.idpuesto, nombre = x.nombre
            With cmbPuesto
                .DataSource = Nothing
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .DataSource = puestos
            End With
            conn.Close()
        End Using
    End Sub

    'Llenar grid
    Private Sub llenagrid()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            'CONSULTAR REGISTROS
            Dim datos = From x In conexion.tblEmpleadoes Select Codigo = x.idEmpleado, Puesto = x.tblpuesto.nombre, Nombre = x.nombre, Direccion = x.direccion, Telefono = x.telefono, Piloto = x.bitpiloto, Pordillero = x.bitpordillero

            ''Dim datos As DataTable = EntitiToDataTable(From x In conexion.sp_lista_empleados(mdlPublicVars.idEmpresa, "") Select x)

            Me.grdEmpleado.DataSource = datos

            conn.Close()
        End Using
        fnconfiguracion()

    End Sub

    Private Sub fnconfiguracion()
        If Me.grdEmpleado.Rows.Count - 1 > 0 Then

            Me.grdEmpleado.Columns("codigo").Width = 75
            Me.grdEmpleado.Columns("puesto").Width = 100
            Me.grdEmpleado.Columns("nombre").Width = 125
            Me.grdEmpleado.Columns("direccion").Width = 100
            Me.grdEmpleado.Columns("telefono").Width = 75
            Me.grdEmpleado.Columns("piloto").Width = 100
            Me.grdEmpleado.Columns("pordillero").Width = 100

        End If
    End Sub

    Private Sub fnGuardar()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Dim m As New tblEmpleado
            Try
                m.idpuesto = cmbPuesto.SelectedValue
                m.nombre = txtNombre.Text
                m.direccion = txtDireccion.Text
                m.telefono = txtTelefono.Text

                If rbtPiloto.Checked = True Then
                    m.bitpiloto = True
                    m.bitpordillero = False
                Else
                    m.bitpiloto = False
                    m.bitpordillero = True
                End If

                conexion.AddTotblEmpleadoes(m)
                conexion.SaveChanges()
                alerta.fnGuardar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alerta.fnErrorGuardar()
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub fnModificar()
        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try
                Dim m As tblEmpleado = (From e1 In conexion.tblEmpleadoes Where e1.idEmpleado = Me.txtCodigo.Text Select e1).First()
                m.idpuesto = cmbPuesto.SelectedValue
                m.nombre = txtNombre.Text
                m.direccion = txtDireccion.Text
                m.telefono = txtTelefono.Text

                If rbtPiloto.Checked = True Then
                    m.bitpiloto = True
                    m.bitpordillero = False
                Else
                    m.bitpiloto = False
                    m.bitpordillero = True
                End If

                conexion.SaveChanges()
                alerta.fnModificar()
                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alerta.fnErrorModificar()
            End Try

            conn.Close()
        End Using
    End Sub

    Private Sub fnEliminar()
        If RadMessageBox.Show("Esta seguro de eliminar este registro", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = vbNo Then
            Exit Sub
        End If

        Dim conexion As New dsi_pos_demoEntities
        Using conn As EntityConnection = New EntityConnection(mdlPublicVars.entityBuilder.ToString)
            conn.Open()
            conexion = New dsi_pos_demoEntities(mdlPublicVars.entityBuilder.ConnectionString)

            Try

                Dim codigo As Integer

                Try
                    codigo = Me.txtCodigo.Text
                Catch ex As Exception
                    RadMessageBox.Show("Debe de seleccionar un empleado", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Exit Sub
                End Try

                'obtenemos el el dato de Surtir Categoria en base al Id ó codigo que está seleccionado...
                Dim m As tblEmpleado = (From x In conexion.tblEmpleadoes Where x.idEmpleado = codigo Select x).FirstOrDefault

                conexion.DeleteObject(m)
                conexion.SaveChanges()

                alerta.fnEliminar()

                Call llenagrid()
            Catch ex As System.Data.EntityException
            Catch ex As Exception
                alerta.fnErrorEliminar()
                RadMessageBox.Show("Asegurese de que el empleado no tenga registros Asignados", nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            End Try
            conn.Close()
        End Using
    End Sub

    Private Sub fnNuevo() Handles Me.panel0
        Me.txtCodigo.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtNombre.Text = ""
        fnLlenarCombo()
    End Sub

    Private Sub fnGuardarRegistro() Handles Me.panel1
        If Me.txtCodigo.Text = "" Then
            fnGuardar()
        Else
            fnModificar()
        End If
    End Sub

    Private Sub fnEliminarRegistro() Handles Me.panel2
        fnEliminar()
    End Sub

    Private Sub Salir_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub fnSalir() Handles Me.panel3
        mdlPublicVars.fnMenu_Hijos(Me)
    End Sub

    Private Sub pnlBarra_Paint(sender As Object, e As PaintEventArgs) Handles pnlBarra.Paint

    End Sub

    Private Sub grdEmpleado_MouseClick(sender As Object, e As MouseEventArgs) Handles grdEmpleado.MouseClick

        Dim fila As Integer = mdlPublicVars.fnGrid_codigoFilaSeleccionada(Me.grdEmpleado)

        Me.txtCodigo.Text = Me.grdEmpleado.Rows(fila).Cells("codigo").Value
        Me.txtNombre.Text = Me.grdEmpleado.Rows(fila).Cells("nombre").Value
        Me.txtDireccion.Text = Me.grdEmpleado.Rows(fila).Cells("direccion").Value
        Me.txtTelefono.Text = Me.grdEmpleado.Rows(fila).Cells("telefono").Value

        If Me.grdEmpleado.Rows(fila).Cells("piloto").Value = True Then
            Me.rbtPiloto.Checked = True
            Me.rbtPordillero.Checked = False
        Else
            Me.rbtPiloto.Checked = False
            Me.rbtPordillero.Checked = True
        End If

    End Sub
End Class
