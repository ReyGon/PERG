
'Imports DgvFilterPopup
Imports System.Transactions
Imports Telerik.WinControls.UI
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Telerik.WinControls
Imports System.IO
Imports System.Diagnostics
Imports Telerik.WinControls.Primitives

Public Class frmBaseTelerik
    Public permiso As New clsPermisoUsuario

    'Creamos los eventos publicos para agregar, grabar y modificar
    Public Event focoDatos() ' coloca el foco en el primer campo indicado de forma manual.
    Public Event nuevoRegistro()
    Public Event grabaRegistro()
    Public Event eliminaRegistro()
    Public Event modificaRegistro()
    Public Event llenarLista()
    Public Event reporte()

    Public Event botonClick()

    Public Event botonAceptar()
    Public Event botonCancelar()


    '-----------------------------   EVENTOS DE PANELES. ----------------------------
    Public Event panel0()
    Public Event panel1()
    Public Event panel2()
    Public Event panel3()
    Public Event panel4()
    Public Event panel5()
    Public Event panel6()
    Public Event panel7()
    Public Event panel8()
    Public Event panel9()
    Public Event panel10()


    Public Event cambiaFilaGrdDatos()
    Public errores As New ErrorProviderExtended

    Private _tblView As DataTable
    Private _nuevo As Boolean
    Private _modificar As Boolean
    Private _eliminar As Boolean
    Private _grabar As Boolean

    'Control de fila actual, en otros eventos.
    Private _filaActual As Integer = 0

    'seleccion de filas para eventos.
    Private _filaSeleccionada As Integer

    Private _ActualizaCamposAutomatico As Boolean = True
    Private _ActivarOpcionesExtendidasGrid As Boolean = True

    Dim s As System.Type
    Public base As New clsBase
    Dim tbl As New clsDevuelveTabla
    Public alertas As New bl_Alertas

    'si toolstip es activado recibe de parametro la cadena a mostrar.
    Public Toolstip As Boolean = False

    'componente de paginas.
    Public rpvBase As Telerik.WinControls.UI.RadPageView

    'formulario de barra lateral
    Public frmBarraLateralBase As Form
    Private _ActivarBarraLateral As Boolean = False


    'seleccionar codigo default
    Public seleccionDefault As Integer
    Public codigoDefault As Integer

    'formulario de barra lateral
    Public frmBarraLateralBaseIzquierda As Telerik.WinControls.UI.RadForm

    Public Property ActivarBarraLateral() As Boolean
        Get
            ActivarBarraLateral = _ActivarBarraLateral
        End Get
        Set(ByVal value As Boolean)
            _ActivarBarraLateral = value
        End Set
    End Property


    Public Property ActivarOpcionesExtendidasGrid() As Boolean
        Get
            ActivarOpcionesExtendidasGrid = _ActivarOpcionesExtendidasGrid
        End Get
        Set(ByVal value As Boolean)
            _ActivarOpcionesExtendidasGrid = value
        End Set
    End Property

    Public Property ActualizaCamposAutomatico() As Boolean
        Get
            ActualizaCamposAutomatico = _ActualizaCamposAutomatico
        End Get
        Set(ByVal value As Boolean)
            _ActualizaCamposAutomatico = value
        End Set
    End Property


    Private _tabla As String

    Public Property tabla() As String
        Get
            tabla = _tabla
        End Get
        Set(ByVal value As String)
            _tabla = value
        End Set
    End Property


    Public Property filaActual() As Integer
        Get
            filaActual = _filaActual
        End Get
        Set(ByVal value As Integer)
            _filaActual = value
        End Set
    End Property

    Public Property filaSeleccionada() As Integer
        Get
            filaSeleccionada = _filaSeleccionada
        End Get
        Set(ByVal value As Integer)
            _filaSeleccionada = value
        End Set
    End Property


    Public Property nuevo() As Boolean
        Get
            nuevo = _nuevo
        End Get
        Set(ByVal value As Boolean)
            _nuevo = value
        End Set
    End Property

    Public Property modificar() As Boolean
        Get
            modificar = _modificar
        End Get
        Set(ByVal value As Boolean)
            _modificar = value
        End Set
    End Property

    Public Property eliminar() As Boolean
        Get
            eliminar = _eliminar
        End Get
        Set(ByVal value As Boolean)
            _eliminar = value
        End Set
    End Property

    Public Property tblView() As DataTable
        Get
            tblView = _tblView
        End Get
        Set(ByVal value As DataTable)
            _tblView = value
        End Set
    End Property

    Public Property grabar() As Boolean
        Get
            grabar = _grabar
        End Get
        Set(ByVal value As Boolean)
            _grabar = value
        End Set
    End Property

    Dim agregarEventos As Integer = 0

    Public Sub textoImpresion(ByVal texto As String)
        Me.pbx4Reporte.Text = texto
    End Sub

    Private Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function


    Public Sub limpiaCampos()
        mdlPublicVars.limpiaCampos(Me)
    End Sub

    Private Sub FrmBaseTelerik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Asignar que el panel actual
        base.PanelActual = 0

        If agregarEventos = 0 Then
            'agregar paneles para eventos.
            fnPaneles_agregar(Me)
            FnAsignaMetodoAbreviado()
            agregarEventos += 1
        End If

        fnInicio()

    End Sub

    '-----------------------------FUNCIONES PARA FUNCIONAMIENTO.

    Public Function fnInicio()

        lbHora.Text = Format(Now, "hh:mm tt")
        lbTituloFrm.Text = Me.Text
        txtFecha.Text = Format(Now, "dd/MM/yyyy")

        'ajustar columnas. auto size.
        grdDatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill

        'Opciones de filtro.
        Me.grdDatos.EnableFiltering = True
        Me.grdDatos.MasterTemplate.ShowFilteringRow = True

        Me.grdDatos.Focus()

        'asociar el listado de imagenes. para columna Tipo Imagen.
        'Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Return True

    End Function

    Private Sub FnNuevo()
        RaiseEvent nuevoRegistro()
        Me.pbx2Guardar.Visible = True
        Me.lbl2Guardar.Visible = True
        Me.pnx2Guardar.Visible = True

        Me.pbx1Modificar.Visible = False
        Me.lbl1Modificar.Visible = False
        Me.pnx1Modificar.Visible = False

    End Sub

    Private Sub fnGuardar()
        If errores.CheckAndShowSummaryErrorMessage = False Then Exit Sub
        RaiseEvent grabaRegistro()

        'seleccionar el ultimo dato que fue el registro guardado luego de llenar el grid view.
        Try
            Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).IsSelected = True
            Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).IsCurrent = True
            Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).EnsureVisible()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub fnModificar()
        filaSeleccionada = Me.grdDatos.CurrentRow.Index 'base.fnFilaSeleccionada_gridTelerik(Me.grdDatos, 0)
        If errores.CheckAndShowSummaryErrorMessage = False Then Exit Sub
        RaiseEvent modificaRegistro()
        'seleccionar la fila actual luego de llenar el grid view.
        Try
            Me.grdDatos.MasterView.Rows(filaSeleccionada).IsSelected = True
            Me.grdDatos.MasterView.Rows(filaSeleccionada).IsCurrent = True
            Me.grdDatos.MasterView.Rows(filaSeleccionada).EnsureVisible()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub fnEliminar()



        Try
            filaSeleccionada = Me.grdDatos.CurrentRow.Index ' base.fnFilaSeleccionada_gridTelerik(Me.grdDatos, 0)
            RaiseEvent eliminaRegistro()
            'cuando no existan filas en el grid no seleccionar nada
            If Me.grdDatos.Rows.Count = 0 Then
            Else
                'si la fila es mayor a cero, seleccionar la fila que estaba
                'siempre que sea menor a contador
                If filaSeleccionada < Me.grdDatos.Rows.Count Then
                    Me.grdDatos.MasterView.Rows(filaSeleccionada).IsSelected = True
                    Me.grdDatos.MasterView.Rows(filaSeleccionada).IsCurrent = True
                    Me.grdDatos.MasterView.Rows(filaSeleccionada).EnsureVisible()
                Else
                    Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).IsSelected = True
                    Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).IsCurrent = True
                    Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).EnsureVisible()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fnSalir()
        If RadMessageBox.Show("Desea Salir de " + Me.Text.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '---------------- FIN BOTONES

    Private Sub tmrHora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHora.Tick
        Me.lbHora.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    ' -------------------------------------funciones jorge para colocar datos del grid en los textbox.

    Private Sub grdDatos_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdDatos.CellFormatting
        If ActivarOpcionesExtendidasGrid = False Then
            Exit Sub
        End If

        If TypeOf e.CellElement.RowInfo Is GridViewFilteringRowInfo Then
            Return
        End If

        Dim celda As String = e.CellElement.ColumnInfo.Name.ToString
        Dim columnaNombre As String = e.Column.Name.ToString


        'condiciones para colocar formato es . largo mayor a 3.
        If celda.Length > 3 Then
            Dim iniciales As String = tbl.tipoControl(celda)

            If iniciales.ToString.ToLower = "cod" Then
                'e.Column.IsVisible = False
                e.Column.Width = 50

            ElseIf iniciales = "prg" Then
                If celda.Substring(3, celda.Length - 3).ToLower = columnaNombre.Substring(3, columnaNombre.Length - 3).ToLower Then

                    'cambiar de celda al header de la columna
                    e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)

                    If e.CellElement.Children.Count = 0 Then
                        If TypeOf e.CellElement.ColumnInfo Is GridViewDataColumn Then
                            If Not (TypeOf e.CellElement.RowElement Is GridGroupHeaderRowElement) Then
                                e.CellElement.Children.Clear()
                                Dim valor As Integer
                                Dim element As New RadProgressBarElement()
                                element.Minimum = 0
                                element.Maximum = 100
                                element.StretchHorizontally = True
                                element.StretchVertically = True
                                Try
                                    valor = e.CellElement.Value
                                    If valor < 0 Then
                                        element.Value1 = 0
                                        element.Text = valor.ToString + "%"
                                    ElseIf valor > 100 Then
                                        valor = 100
                                        element.Value1 = 100
                                        element.Text = valor.ToString + "%"
                                    Else
                                        element.Value1 = e.CellElement.Value
                                        element.Text = valor.ToString + "%"
                                    End If
                                Catch ex As Exception
                                    valor = 0
                                    element.Value1 = 0
                                    element.Text = valor.ToString + "%"
                                End Try
                                e.CellElement.Children.Add(element)
                            End If
                        End If

                    Else '' Actualizar.
                        e.CellElement.Children.Clear()
                        Dim valor As Integer
                        Dim element As New RadProgressBarElement()
                        element.Minimum = 0
                        element.Maximum = 100
                        element.StretchHorizontally = True
                        element.StretchVertically = True
                        Try
                            valor = e.CellElement.Value
                            If valor < 0 Then
                                element.Value1 = 0
                                element.Text = valor.ToString + "%"
                            ElseIf valor > 100 Then
                                valor = 100
                                element.Value1 = 100
                                element.Text = valor.ToString + "%"
                            Else
                                element.Value1 = e.CellElement.Value
                                element.Text = valor.ToString + "%"
                            End If
                        Catch ex As Exception
                            valor = 0
                            element.Value1 = 0
                            element.Text = valor.ToString + "%"
                        End Try
                        e.CellElement.Children.Add(element)


                    End If

                End If
            ElseIf iniciales = "but" Then
                'si el nombre de la celda coincide con el nombre de la columna.
                If celda.Substring(3, celda.Length - 3).ToLower = columnaNombre.Substring(3, columnaNombre.Length - 3).ToLower Then

                    If e.CellElement.Children.Count = 0 Then
                        Dim element As New RadButtonElement

                        'colocar eventos a los botones.
                        If celda.Substring(3, celda.Length - 3) = "Aceptar" Then
                            AddHandler element.Click, AddressOf fnAceptar
                        ElseIf celda.Substring(3, celda.Length - 3) = "Cancelar" Then
                            AddHandler element.Click, AddressOf fnCancelar
                        End If

                        element.Text = e.CellElement.Value.ToString
                        element.Name = celda

                        e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                        e.CellElement.Children.Add(element)

                    Else ' si ya existe, borrar todos los elementos. y crear un boton 
                        'eliminar todos los elementos.
                        e.CellElement.Children.Clear()

                        'Crear el nuevo elemento.
                        Dim element As New RadButtonElement

                        'colocar eventos a los botones.
                        If celda.Substring(3, celda.Length - 3) = "Aceptar" Then
                            AddHandler element.Click, AddressOf fnAceptar
                        ElseIf celda.Substring(3, celda.Length - 3) = "Cancelar" Then
                            AddHandler element.Click, AddressOf fnCancelar
                        End If

                        element.Text = e.CellElement.Value.ToString
                        element.Name = celda

                        e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                        e.CellElement.Children.Add(element)

                    End If



                End If

            ElseIf iniciales = "clr" Then
                If celda.Substring(3, celda.Length - 3).ToLower = columnaNombre.Substring(3, columnaNombre.Length - 3).ToLower Then

                    Try
                        If e.CellElement.Children.Count = 0 Then
                            'Crear

                            'If celda.ToLower.Equals(columnaNombre.ToLower) Then
                            If TypeOf e.CellElement.ColumnInfo Is GridViewDataColumn Then
                                If Not (TypeOf e.CellElement.RowElement Is GridGroupHeaderRowElement) Then

                                    'cambiar de celda al header de la columna
                                    e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                                    Dim valor As Integer = e.CellElement.Value
                                    Dim imageColumn As New RadImageButtonElement
                                    imageColumn.ImageIndex = valor
                                    e.CellElement.Children.Add(imageColumn)
                                End If
                            End If
                            'End If
                        Else
                            'Existe, actualizar su valor.
                            e.CellElement.Children.Clear()
                            e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                            Dim valor As Integer = e.CellElement.Value
                            Dim imageColumn As New RadImageButtonElement
                            imageColumn.ImageIndex = valor
                            e.CellElement.Children.Add(imageColumn)
                            'Dim element As RadImageButtonElement = e.CellElement.Children(0)
                            'Dim valor As Integer = e.CellElement.Value
                            'element.ImageIndex = valor

                        End If
                    Catch ex As Exception

                    End Try

                End If
            ElseIf iniciales = "chk" Then
                'cambiar de celda al header de la columna
                e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)

            Else
                'cambiar de celda al header de la columna

                e.CellElement.Children.Clear()
            End If

        Else
            Dim acronimo As String
            acronimo = celda.Substring(0, 2)
            If acronimo.ToString.ToLower = "id" Then
                e.CellElement.Alignment = ContentAlignment.BottomLeft
                e.CellElement.TextAlignment = ContentAlignment.BottomLeft
                e.Column.Width = "50"
            End If

            e.CellElement.Children.Clear()
        End If
    End Sub

    Private Sub grdDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.SelectionChanged
        Me.lbl1Modificar.Visible = True
        Me.pbx1Modificar.Visible = True
        Me.pnx1Modificar.Visible = True

        Me.pbx2Guardar.Visible = False
        Me.lbl2Guardar.Visible = False
        Me.pnx2Guardar.Visible = False

        Dim f As Integer = Me.grdDatos.MasterView.CurrentRow.Index
        Dim c As Integer = grdDatos.Columns.Count

        'obtener el valor de toda la fila seleccionada
        If f > 0 Then
            Me.filaActual = f
        Else
            Me.filaActual = 0
        End If

        RaiseEvent cambiaFilaGrdDatos()

        'colocar el registro
        Try
            lblRegistros.Text = "Registro " + Format(Me.grdDatos.SelectedRows(0).Index + 1, mdlPublicVars.formatoCantidad) + " de " + Format(Me.grdDatos.Rows.Count, mdlPublicVars.formatoCantidad)
        Catch ex As Exception
            lblRegistros.Text = "0"
        End Try

        If ActualizaCamposAutomatico = True Then
            base.fnInicio(Me.Controls, grdDatos, f, c)
        End If


    End Sub

    Private Sub fnAsignaMetodoAbreviado_Page(ByVal rpv As Telerik.WinControls.UI.RadPageView)
        'AddHandler element.Click, AddressOf fnMetodosAbreviados
        Dim ctl As New Control
        Dim nombre As String
        Dim iniciales As String
        Dim txt As System.Windows.Forms.TextBox
        Dim cmb As System.Windows.Forms.ComboBox
        Dim chk As CheckBox
        Dim pnl As Panel
        Dim msk As MaskedTextBox
        Dim dtp As DateTimePicker
        Dim nm0 As System.Windows.Forms.NumericUpDown 'numero, nm0= numero con cero decimales hasta nm5= numero 5 decimales.
        Dim prg As RadProgressBar
        Dim clr As RadToggleButton
        Dim lbl As Label
        Dim rbn As RadioButton
        'telerik rad view page (rvp)
        'recorrer las paginas
        Dim pagina
        For Each pagina In rpv.Pages

            'recorrer los controles de las paginas
            For Each ctl In pagina.Controls


                nombre = ctl.Name
                If nombre <> "" Then
                    iniciales = tipoControl(nombre)
                    If iniciales = "pnl" Then
                        pnl = ctl
                        AddHandler pnl.KeyDown, AddressOf fnMetodosAbreviados
                        Call fnAsignaMetodoAbreviado_panel(pnl)
                    ElseIf iniciales = "rpv" Then
                        rpv = ctl
                        AddHandler rpv.KeyDown, AddressOf fnMetodosAbreviados
                        Call fnAsignaMetodoAbreviado_Page(rpv)
                    ElseIf iniciales = "rbn" Then
                        rbn = ctl
                        AddHandler rbn.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "lbl" Then
                        lbl = ctl
                        AddHandler lbl.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "clr" Then
                        clr = ctl
                        AddHandler clr.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "prg" Then
                        prg = ctl
                        AddHandler prg.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "txt" Then
                        txt = ctl
                        AddHandler txt.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "cmb" Then
                        cmb = ctl
                        AddHandler cmb.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "dtp" Then
                        dtp = ctl
                        AddHandler dtp.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "chk" Then
                        chk = ctl
                        AddHandler chk.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "msk" Then
                        msk = ctl
                        AddHandler msk.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                        nm0 = ctl
                        AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                    End If
                End If

            Next
        Next
    End Sub

    Private Sub fnAsignaMetodoAbreviado_panel(ByVal pnl As Panel)
        'AddHandler element.Click, AddressOf fnMetodosAbreviados
        Dim ctl As New Control
        Dim nombre As String
        Dim iniciales As String
        Dim txt As System.Windows.Forms.TextBox
        Dim cmb As System.Windows.Forms.ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim dtp As DateTimePicker
        Dim nm0 As System.Windows.Forms.NumericUpDown 'numero, nm0= numero con cero decimales hasta nm5= numero 5 decimales.
        Dim prg As RadProgressBar
        Dim clr As RadToggleButton
        Dim lbl As Label
        Dim rbn As RadioButton
        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView


        For Each ctl In pnl.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                iniciales = tipoControl(nombre)
                If iniciales = "pnl" Then
                    pnl = ctl
                    AddHandler pnl.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_panel(pnl)
                ElseIf iniciales = "rpv" Then
                    rpv = ctl
                    AddHandler rpv.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_Page(rpv)
                ElseIf iniciales = "rbn" Then
                    rbn = ctl
                    AddHandler rbn.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "lbl" Then
                    lbl = ctl
                    AddHandler lbl.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "clr" Then
                    clr = ctl
                    AddHandler clr.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "prg" Then
                    prg = ctl
                    AddHandler prg.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "txt" Then
                    txt = ctl
                    AddHandler txt.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "cmb" Then
                    cmb = ctl
                    AddHandler cmb.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "dtp" Then
                    dtp = ctl
                    AddHandler dtp.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "chk" Then
                    chk = ctl
                    AddHandler chk.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "msk" Then
                    msk = ctl
                    AddHandler msk.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                End If
            End If


        Next

    End Sub

    Private Sub FnAsignaMetodoAbreviado()
        'agregar al formulario
        AddHandler Me.KeyDown, AddressOf fnMetodosAbreviados

        'agregar al grid
        AddHandler Me.grdDatos.KeyDown, AddressOf fnMetodosAbreviados
        AddHandler Me.grdDatos.KeyDown, AddressOf mdlPublicVars.gridcopyPaste

        'agregar a todos los controles
        Dim ctl As New Control
        Dim nombre As String
        Dim iniciales As String
        Dim txt As System.Windows.Forms.TextBox
        Dim cmb As System.Windows.Forms.ComboBox
        Dim chk As CheckBox
        Dim pnl As Panel
        Dim msk As MaskedTextBox
        Dim dtp As DateTimePicker
        Dim nm0 As System.Windows.Forms.NumericUpDown 'numero, nm0= numero con cero decimales hasta nm5= numero 5 decimales.
        Dim prg As RadProgressBar
        Dim clr As RadToggleButton
        Dim lbl As Label
        Dim rbn As RadioButton
        Dim grd As RadGridView

        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView


        For Each ctl In Me.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                iniciales = tipoControl(nombre)
                If iniciales = "pnl" Then
                    pnl = ctl
                    AddHandler pnl.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_panel(pnl)
                ElseIf iniciales = "rpv" Then
                    rpv = ctl
                    AddHandler rpv.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_Page(rpv)
                ElseIf iniciales = "rbn" Then
                    rbn = ctl
                    AddHandler rbn.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "lbl" Then
                    lbl = ctl
                    AddHandler lbl.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "clr" Then
                    clr = ctl
                    AddHandler clr.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "prg" Then
                    prg = ctl
                    AddHandler prg.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "txt" Then
                    txt = ctl
                    AddHandler txt.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "cmb" Then
                    cmb = ctl
                    AddHandler cmb.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "dtp" Then
                    dtp = ctl
                    AddHandler dtp.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "chk" Then
                    chk = ctl
                    AddHandler chk.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "msk" Then
                    msk = ctl
                    AddHandler msk.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    AddHandler grd.KeyDown, AddressOf fnMetodosAbreviados
                    AddHandler grd.KeyDown, AddressOf mdlPublicVars.gridcopyPaste
                End If
            End If


        Next

    End Sub

    Private Sub fnAceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent botonAceptar()
    End Sub

    Private Sub fnCancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent botonCancelar()
    End Sub

    'Private Sub pbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx0Nuevo.Click, lbl0Nuevo.Click, pnx0Nuevo.Click
    '    FnNuevo()
    'End Sub

    'Private Sub pbGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx2Guardar.Click, pnx2Guardar.Click, lbl2Guardar.Click
    '    fnGuardar()
    'End Sub

    'Private Sub pbModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx1Modificar.Click, lbl1Modificar.Click, pnx1Modificar.Click
    '    fnModificar()
    'End Sub

    'Private Sub pbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx3Eliminar.Click, lbl3Eliminar.Click, pnx3Eliminar.Click
    '    fnEliminar()
    'End Sub

    'Private Sub pbReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx4Reporte.Click
    '    RaiseEvent reporte()
    'End Sub

    Private Sub grdDatos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdDatos.KeyPress
        fnActualizarCampos(e)
    End Sub

    Private Sub fnActualizarCampos(ByVal e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.lbl1Modificar.Visible = True
            Me.pbx1Modificar.Visible = True

            Me.lbl2Guardar.Visible = False
            Me.lbl2Guardar.Visible = False

            Dim f As Integer = Me.grdDatos.MasterView.CurrentRow.Index
            Dim c As Integer = grdDatos.Columns.Count

            'obtener el valor de toda la fila seleccionada
            If f > 0 Then
                Me.filaActual = f
            Else
                Me.filaActual = 0
            End If

            RaiseEvent cambiaFilaGrdDatos()

            'colocar el registro
            Try
                lblRegistros.Text = "Registro " + Format(Me.grdDatos.SelectedRows(0).Index + 1, mdlPublicVars.formatoCantidad) + " de " + Format(Me.grdDatos.Rows.Count, mdlPublicVars.formatoCantidad)
            Catch ex As Exception
                lblRegistros.Text = "0"
            End Try

            base.fnInicio(Me.Controls, grdDatos, f, c)
        End If
    End Sub

    Private Function fnMetodosAbreviados(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        '
        If e.KeyValue = Keys.F1 And ActivarBarraLateral = True Then
            Dim frm As Form = frmMenu
            frm.Text = "Menú Principal"
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)
            Me.Close()
        End If

        If e.KeyValue = Keys.F2 And ActivarBarraLateral = True Then
            mdlPublicVars.frmPosX = Me.Location.X
            mdlPublicVars.frmPosY = Me.Location.Y
            mdlPublicVars.frmX = Me.Size.Width
            mdlPublicVars.frmY = frmMenuPrincipal.Size.Height
            Try
                permiso.PermisoDialogBarra(frmBarraLateralBaseIzquierda)
            Catch ex As Exception

            End Try

        End If


        'foco a los datos, el primer campo
        If e.KeyValue = Keys.F11 Then
            Me.grdDatos.Focus()
        End If

        'foco a los datos, el primer campo
        If e.KeyValue = Keys.F10 Then
            RaiseEvent focoDatos()
        End If

        'F6= mover para atras, F7 mover hacia adelante
        If e.KeyValue = Keys.F8 Or e.KeyValue = Keys.F9 Then
            Try
                Dim pagina As Telerik.WinControls.UI.RadPageViewPage
                pagina = rpvBase.SelectedPage

                Dim contador As Integer = rpvBase.Pages.Count - 1
                Dim actual As Integer = 0
                Dim index

                'obtener la pagina actual
                For index = 0 To contador
                    If rpvBase.Pages(index).Name = pagina.Name Then
                        actual = index
                    End If
                Next

                'atras
                If actual > 0 And e.KeyValue = Keys.F8 Then
                    pagina = rpvBase.Pages(actual - 1)
                    rpvBase.SelectedPage = pagina
                End If

                'adelante
                If actual < contador And e.KeyValue = Keys.F9 Then
                    pagina = rpvBase.Pages(actual + 1)
                    rpvBase.SelectedPage = pagina
                End If

            Catch ex As Exception

            End Try

        End If

        'cerrar formulario
        If e.KeyValue = Keys.Escape Then
            If RadMessageBox.Show("Desea cerrar !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If

        'nuevo registro
        'If e.KeyValue = Keys.F2 Then
        '    FnNuevo()
        'End If

        ''modificar
        'If e.KeyValue = Keys.F3 Then
        '    fnModificar()
        'End If

        'guardar
        'If e.KeyValue = Keys.F4 Then
        '    fnGuardar()
        'End If

        'eliminar
        'If e.KeyValue = Keys.Delete Then
        'fnEliminar()
        'End If

        'actualizar grid view
        If e.KeyValue = Keys.F5 Then
            RaiseEvent llenarLista()
            Me.grdDatos.Focus()
        End If

        'mover en el grid para abajo F6 y para arriba F7
        If e.KeyValue = Keys.F6 Or e.KeyValue = Keys.F7 Then
            Dim fila As Integer = Me.grdDatos.CurrentRow.Index
            Dim filas As Integer = Me.grdDatos.Rows.Count - 1

            If fila > 0 And e.KeyValue = Keys.F7 Then
                Me.grdDatos.Rows(fila - 1).IsSelected = True
                Me.grdDatos.Rows(fila - 1).IsCurrent = True
                Me.grdDatos.Rows(fila - 1).EnsureVisible()
            End If

            If fila < filas And e.KeyValue = Keys.F6 Then
                Me.grdDatos.Rows(fila + 1).IsSelected = True
                Me.grdDatos.Rows(fila + 1).IsCurrent = True
                Me.grdDatos.Rows(fila + 1).EnsureVisible()
            End If
        End If




        If e.KeyValue = 17 Then
            Try
                'limpiar los paneles
                Dim index
                For index = 0 To base.PanelContador - 1
                    base.paneles(index).BackColor = Color.Navy
                Next

                'pintar el panel Actual.
                base.paneles(base.PanelActual).Focus()
                base.paneles(base.PanelActual).BackColor = Color.Green
            Catch ex As Exception
            End Try

        End If

        Return 0
    End Function





    '--------------------------------FUNCIONES PARA CTRL (control).  
    Private Function fnPaneles_agregar(ByVal frm As Form)
        base.PanelContador = 0

        Dim nombre As String
        Dim iniciales As String
        Dim ctl

        'controles de envio a funciones para paneles.
        Dim pnl As Panel

        Dim tlp As TableLayoutPanel
        Dim rgb As Telerik.WinControls.UI.RadGroupBox


        'guardar el numero de panel maximo.
        Dim maximo As Integer = 0
        Dim numeroPanel As Integer

        'recorerr cada uno de los controles.
        For Each ctl In frm.Controls

            'Obtener el nombre del control
            nombre = ctl.name

            'si el control tiene largo mayor a 3
            If nombre.Length > 3 Then

                'consultar las iniciales.
                iniciales = tipoControl(nombre)

                If iniciales = "tlp" Then 'table layout page.
                    tlp = ctl
                    fnPaneles_agregar_TablaLayoutPage(ctl, maximo, numeroPanel)
                ElseIf iniciales = "pnl" Then 'panel
                    pnl = ctl
                    fnPaneles_agregar_Panel(ctl, maximo, numeroPanel)
                ElseIf iniciales = "rgb" Then ' rad group box
                    rgb = ctl
                    fnPaneles_agregar_GroupBox(rgb, maximo, numeroPanel)
                ElseIf iniciales = "pnx" Then ' pnx es un panel que se debe agregar a paneles para opciones con teclas.
                    pnl = ctl

                    'obtener el numero del panel
                    numeroPanel = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)

                    If maximo < numeroPanel Then
                        maximo = numeroPanel
                        ReDim Preserve base.paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    base.paneles(numeroPanel) = pnl

                    'incrementar el contador
                    base.PanelContador = base.PanelContador + 1

                    'AGREGAR EVENTOS DE MOUSE PARA PANELES.
                    AddHandler pnl.MouseLeave, AddressOf paneles_leave_mouseLeave
                    AddHandler pnl.PreviewKeyDown, AddressOf paneles_abajo_arriba

                    'agregar eventos clic a los componentes del panel
                    FnPanel_agregarEventos(pnl)

                End If
            End If
        Next

        Return 0
    End Function

    Private Function fnPaneles_agregar_TablaLayoutPage(ByVal tlp As System.Windows.Forms.TableLayoutPanel, ByVal maximo As Integer, ByVal NumeroPanel As Integer)
        Dim nombre As String
        Dim iniciales As String
        Dim ctl

        'controles de envio a funciones para paneles.
        Dim pnl As Panel
        Dim rgb As Telerik.WinControls.UI.RadGroupBox


        'recorerr cada uno de los controles.
        For Each ctl In tlp.Controls

            'Obtener el nombre del control
            nombre = ctl.name

            'si el control tiene largo mayor a 3
            If nombre.Length > 3 Then

                'consultar las iniciales.
                iniciales = tipoControl(nombre)

                If iniciales = "tlp" Then 'table layout page.
                    tlp = ctl
                    fnPaneles_agregar_TablaLayoutPage(ctl, maximo, NumeroPanel)
                ElseIf iniciales = "pnl" Then 'panel
                    pnl = ctl
                    fnPaneles_agregar_Panel(ctl, maximo, NumeroPanel)
                ElseIf iniciales = "rgb" Then ' rad group box
                    rgb = ctl
                    fnPaneles_agregar_GroupBox(rgb, maximo, NumeroPanel)
                ElseIf iniciales = "pnx" Then ' pnx es un panel que se debe agregar a paneles para opciones con teclas.
                    pnl = ctl

                    'obtener el numero del panel
                    NumeroPanel = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)

                    If maximo < NumeroPanel Then
                        maximo = NumeroPanel
                        ReDim Preserve base.paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    base.paneles(NumeroPanel) = pnl

                    'incrementar el contador
                    base.PanelContador = base.PanelContador + 1

                    'AGREGAR EVENTOS DE MOUSE PARA PANELES.
                    AddHandler pnl.MouseLeave, AddressOf paneles_leave_mouseLeave
                    AddHandler pnl.PreviewKeyDown, AddressOf paneles_abajo_arriba

                    'agregar eventos clic a los componentes del panel
                    FnPanel_agregarEventos(pnl)

                End If

            End If

        Next

        Return 0
    End Function

    Private Function fnPaneles_agregar_Panel(ByVal pnl As Panel, ByVal maximo As Integer, ByVal NumeroPanel As Integer)
        Dim nombre As String
        Dim iniciales As String
        Dim ctl

        'controles de envio a funciones para paneles.
        Dim tlp As TableLayoutPanel
        Dim rgb As Telerik.WinControls.UI.RadGroupBox

        'recorerr cada uno de los controles.
        For Each ctl In pnl.Controls

            'Obtener el nombre del control
            nombre = ctl.name

            'si el control tiene largo mayor a 3
            If nombre.Length > 3 Then

                'consultar las iniciales.
                iniciales = tipoControl(nombre)

                If iniciales = "tlp" Then 'table layout page.
                    tlp = ctl
                    fnPaneles_agregar_TablaLayoutPage(ctl, maximo, NumeroPanel)
                ElseIf iniciales = "pnl" Then 'panel
                    pnl = ctl
                    fnPaneles_agregar_Panel(ctl, maximo, NumeroPanel)
                ElseIf iniciales = "rgb" Then ' rad group box
                    rgb = ctl
                    fnPaneles_agregar_GroupBox(rgb, maximo, NumeroPanel)
                ElseIf iniciales = "pnx" Then ' pnx es un panel que se debe agregar a paneles para opciones con teclas.
                    pnl = ctl

                    'obtener el numero del panel
                    NumeroPanel = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)

                    If maximo <= NumeroPanel Then
                        maximo = NumeroPanel
                        ReDim Preserve base.paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    base.paneles(NumeroPanel) = pnl

                    'incrementar el contador
                    base.PanelContador = base.PanelContador + 1

                    'AGREGAR EVENTOS DE MOUSE PARA PANELES.
                    AddHandler pnl.MouseLeave, AddressOf paneles_leave_mouseLeave
                    AddHandler pnl.PreviewKeyDown, AddressOf paneles_abajo_arriba

                    'agregar eventos clic a los componentes del panel
                    FnPanel_agregarEventos(pnl)

                End If

            End If

        Next
        Return 0
    End Function

    Private Function fnPaneles_agregar_GroupBox(ByVal rgb As Telerik.WinControls.UI.RadGroupBox, ByVal maximo As Integer, ByVal NumeroPanel As Integer)
        Dim nombre As String
        Dim iniciales As String
        Dim ctl

        'controles de envio a funciones para paneles.
        Dim pnl As Panel
        Dim tlp As TableLayoutPanel


        'recorerr cada uno de los controles.
        For Each ctl In rgb.Controls

            'Obtener el nombre del control
            nombre = ctl.name

            'si el control tiene largo mayor a 3
            If nombre.Length > 3 Then

                'consultar las iniciales.
                iniciales = tipoControl(nombre)

                If iniciales = "tlp" Then 'table layout page.
                    tlp = ctl
                    fnPaneles_agregar_TablaLayoutPage(ctl, maximo, NumeroPanel)
                ElseIf iniciales = "pnl" Then 'panel
                    pnl = ctl
                    fnPaneles_agregar_Panel(ctl, maximo, NumeroPanel)
                ElseIf iniciales = "rgb" Then ' rad group box
                    rgb = ctl
                    fnPaneles_agregar_GroupBox(rgb, maximo, NumeroPanel)
                ElseIf iniciales = "pnx" Then ' pnx es un panel que se debe agregar a paneles para opciones con teclas.
                    pnl = ctl

                    'obtener el numero del panel
                    NumeroPanel = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)

                    If maximo < NumeroPanel Then
                        maximo = NumeroPanel
                        ReDim Preserve base.paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    base.paneles(NumeroPanel) = pnl

                    'incrementar el contador
                    base.PanelContador = base.PanelContador + 1

                    'AGREGAR EVENTOS DE MOUSE PARA PANELES.
                    AddHandler pnl.MouseLeave, AddressOf paneles_leave_mouseLeave
                    AddHandler pnl.PreviewKeyDown, AddressOf paneles_abajo_arriba

                    'agregar eventos clic a los componentes del panel
                    FnPanel_agregarEventos(pnl)

                End If

            End If

        Next
        Return 0
    End Function

    Private Sub FnPanel_agregarEventos(ByVal pnl As Panel)
        Dim iniciales As String
        Dim pbx As PictureBox
        Dim lbl As Label
        Dim nombre As String = pnl.Name
        Dim ctl
        Dim numero As Integer

        numero = mdlPublicVars.tipoControlRango(nombre, 3, 1)

        'agregar eventos de clic al panel
        Select Case numero
            Case 0
                AddHandler pnl.Click, AddressOf fnPanel0
                'AddHandler pnl.PreviewKeyDown, AddressOf fn
            Case 1
                AddHandler pnl.Click, AddressOf fnPanel1
                'AddHandler pnl.Enter, AddressOf fnPanel1
            Case 2
                AddHandler pnl.Click, AddressOf fnPanel2
            Case 3
                AddHandler pnl.Click, AddressOf fnPanel3
            Case 4
                AddHandler pnl.Click, AddressOf fnPanel4
            Case 5
                AddHandler pnl.Click, AddressOf fnPanel5
            Case 6
                AddHandler pnl.Click, AddressOf fnPanel6
            Case 7
                AddHandler pnl.Click, AddressOf fnPanel7
            Case 8
                AddHandler pnl.Click, AddressOf fnPanel8
            Case 9
                AddHandler pnl.Click, AddressOf fnPanel9
            Case 10
                AddHandler pnl.Click, AddressOf fnPanel10
        End Select


        For Each ctl In pnl.Controls
            nombre = ctl.Name

            If nombre <> "" Then

                iniciales = mdlPublicVars.tipoControl(nombre)
                If IsNumeric(mdlPublicVars.tipoControlRango(nombre, 3, 1)) Then
                    numero = mdlPublicVars.tipoControlRango(nombre, 3, 1)


                    Select Case numero
                        Case 0

                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel0
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel0
                            End If

                        Case 1
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel1
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel1
                            End If

                        Case 2
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel2
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel2
                            End If

                        Case 3
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel3
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel3
                            End If

                        Case 4
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel4
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel4
                            End If

                        Case 5
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel5
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel5
                            End If

                        Case 6
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel6
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel6
                            End If

                        Case 7
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel7
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel7
                            End If

                        Case 8
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel8
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel8
                            End If

                        Case 9
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel9
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel9
                            End If
                        Case 10
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel10
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel10
                            End If

                        Case Else

                    End Select


                End If

            End If

        Next


    End Sub

    '---------------------------------------- Eventos de los paneles.
    Private Sub fnPanel0()
        FnNuevo()
    End Sub

    Private Sub fnPanel1()
        fnModificar()
    End Sub

    Private Sub fnPanel2()
        fnGuardar()
    End Sub

    Private Sub fnPanel3()
        fnEliminar()
    End Sub

    Private Sub fnPanel4()
        RaiseEvent reporte()
    End Sub

    Private Sub fnPanel5()
        If RadMessageBox.Show("Desea salir !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub fnPanel6()

    End Sub

    Private Sub fnPanel7()
        RaiseEvent panel7()
    End Sub

    Private Sub fnPanel8()
        RaiseEvent panel8()
    End Sub

    Private Sub fnPanel9()
        RaiseEvent panel9()
    End Sub

    Private Sub fnPanel10()
        RaiseEvent panel10()
    End Sub

    Private Sub paneles_leave_mouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'borrar el color de fondo de todos los paneles.
        Dim index
        For index = 0 To base.PanelContador - 1
            base.paneles(index).BackColor = Color.Navy
        Next

        DirectCast(sender, Panel).BackColor = Color.Green

        Dim numero As String = mdlPublicVars.tipoControlRango(DirectCast(sender, Panel).Name, 3, 1)
        If IsNumeric(numero) Then
            base.PanelActual = numero
            'lblActual.Text = actual
        End If

    End Sub

    Private Sub paneles_abajo_arriba(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

        'si presiono la tecla para abajo, aumentar asignar foco a panel nuevo
        If e.KeyValue = Keys.Down Or e.KeyValue = Keys.Up Or e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right Then

            'limpiar los paneles
            Dim index
            For index = 0 To base.PanelContador - 1
                base.paneles(index).BackColor = Color.Navy
            Next

            If (base.PanelActual + 1 < base.PanelContador) And (e.KeyValue = Keys.Down Or e.KeyValue = Keys.Right) Then
                base.PanelActual = base.PanelActual + 1
            End If

            If (base.PanelActual - 1 >= 0) And (e.KeyValue = Keys.Up Or e.KeyValue = Keys.Left) Then
                base.PanelActual = base.PanelActual - 1
            End If

            ' si base = 2 y guardar visible = falso.
            If base.PanelActual = 2 And pnx2Guardar.Visible = False Then
                'sumar uno para que seleccione eliminar
                If e.KeyValue = Keys.Right Then
                    base.PanelActual = base.PanelActual + 1
                End If
                'restar uno para que seleccione modificar.
                If e.KeyValue = Keys.Left Then
                    base.PanelActual = base.PanelActual - 1
                End If
            End If

            'si actual = 1 y modificar visible = falso.
            If base.PanelActual = 1 And pnx1Modificar.Visible = False Then

                'sumar uno para seleccionar guardar.
                If e.KeyValue = Keys.Right Then
                    base.PanelActual = base.PanelActual + 1
                End If
                'restar uno para seleccionar nuevo.
                If e.KeyValue = Keys.Left Then
                    base.PanelActual = base.PanelActual - 1
                End If

            End If

            'pintar el panel Actual.
            base.paneles(base.PanelActual).Focus()
            base.paneles(base.PanelActual).BackColor = Color.Green

        End If

        If e.KeyValue = Keys.Enter Then

            '    'agregar eventos de clic al panel
            Select Case base.PanelActual
                Case 0
                    fnPanel0()
                Case 1
                    fnPanel1()
                Case 2
                    fnPanel2()
                Case 3
                    fnPanel3()
                Case 4
                    fnPanel4()
                Case 5
                    fnPanel5()
                Case 6
                    fnPanel6()
                Case 7
                    fnPanel7()
                Case 8
                    fnPanel8()
                Case 9
                    fnPanel9()
                Case 10
                    fnPanel10()
            End Select
        End If

    End Sub

    '---------------------------------------FIN DE CONFIGURACION DE PANELES. --------------------------------------------

End Class