Imports Telerik.WinControls.UI
Imports System.Windows.Forms.Form
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Telerik.WinControls

Public Class clsBase
    Dim tbl As New clsDevuelveTabla
    Dim permiso As New clsPermisoUsuario

    'Public Event botonAceptarSinHerencia()
    'Public Event botonCancelarSinHerencia()

    ' --------------------------------VARIABLES Y EVENTOS PARA PANELES.--------------- -------------------
    Public Event panel11()


    Public paneles As Panel()
    Public PanelContador As Integer = 0
    Public PanelActual As Integer
    '-----------------------------------fin eventos y variables para paneles.--------------------------


    Public frm As RadForm

    Public Function fnGrid_seleccionarEspacio(ByVal grd As RadGridView, ByVal col As Integer, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal valor As Boolean)
        Try
            If e.KeyChar = ChrW(Keys.Space) Then
                Dim bitActual As Boolean = CType(grd.Rows(grd.SelectedRows(0).Index).Cells(col).Value, Boolean)
                If bitActual = True Then
                    grd.Rows(grd.SelectedRows(0).Index).Cells(col).Value = False
                Else
                    grd.Rows(grd.SelectedRows(0).Index).Cells(col).Value = True
                End If
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Public Sub FnAsignaMetodoAbreviado(ByVal frmEntrada As RadForm)
        'agregar al formulario
        frm = frmEntrada

        'agregar al formulario
        AddHandler frm.KeyDown, AddressOf fnMetodosAbreviados

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
        Dim clb As CheckedListBox
        Dim rpv As Telerik.WinControls.UI.RadPageView
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox
        Dim rme As Telerik.WinControls.UI.RadMenu
        Dim rss As Telerik.WinControls.UI.RadStatusStrip

        For Each ctl In frm.Controls
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
                ElseIf iniciales = "rgb" Then
                    rgb = ctl
                    AddHandler rgb.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_Group(rgb)
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
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    AddHandler clb.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    AddHandler grd.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "rme" Then
                    rme = ctl
                    AddHandler rme.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "rss" Then
                    rss = ctl
                    AddHandler rss.KeyDown, AddressOf fnMetodosAbreviados
                End If
            End If


        Next
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
        Dim clb As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox
        Dim tlp As TableLayoutPanel

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
                    ElseIf iniciales = "rgb" Then
                        rgb = ctl
                        AddHandler rgb.KeyDown, AddressOf fnMetodosAbreviados
                        Call fnAsignaMetodoAbreviado_Group(rgb)
                    ElseIf iniciales = "tlp" Then
                        tlp = ctl
                        AddHandler tlp.KeyDown, AddressOf fnMetodosAbreviados
                        Call fnAsignaMetodoAbreviado_TableLayoutPanel(tlp)
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
                    ElseIf iniciales = "clb" Then
                        clb = ctl
                        AddHandler clb.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                        nm0 = ctl
                        AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                    ElseIf iniciales = "grd" Then
                        grd = ctl
                        AddHandler grd.KeyDown, AddressOf fnMetodosAbreviados
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
        Dim clb As CheckedListBox
        Dim rpv As Telerik.WinControls.UI.RadPageView
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox
        Dim tlp As TableLayoutPanel

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
                ElseIf iniciales = "rgb" Then
                    rgb = ctl
                    AddHandler rgb.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_Group(rgb)
                ElseIf iniciales = "tlp" Then
                    tlp = ctl
                    AddHandler tlp.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_TableLayoutPanel(tlp)
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
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    AddHandler clb.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    AddHandler grd.KeyDown, AddressOf fnMetodosAbreviados
                End If
            End If


        Next

    End Sub

    Private Sub fnAsignaMetodoAbreviado_Group(ByVal rgb As Telerik.WinControls.UI.RadGroupBox)
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
        Dim clb As CheckedListBox
        Dim rpv As Telerik.WinControls.UI.RadPageView
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim tlp As TableLayoutPanel
        Dim pnl As Panel

        For Each ctl In rgb.Controls
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
                ElseIf iniciales = "rgb" Then
                    rgb = ctl
                    AddHandler rgb.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_Group(rgb)
                ElseIf iniciales = "tlp" Then
                    tlp = ctl
                    AddHandler tlp.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_TableLayoutPanel(tlp)
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
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    AddHandler clb.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    AddHandler grd.KeyDown, AddressOf fnMetodosAbreviados
                End If
            End If


        Next

    End Sub

    Private Sub fnAsignaMetodoAbreviado_TableLayoutPanel(ByVal tlp As TableLayoutPanel)
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
        Dim clb As CheckedListBox
        Dim rpv As Telerik.WinControls.UI.RadPageView
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox
        Dim pnl As Panel

        For Each ctl In tlp.Controls
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
                ElseIf iniciales = "rgb" Then
                    RGB = ctl
                    AddHandler RGB.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_Group(rgb)
                ElseIf iniciales = "tlp" Then
                    tlp = ctl
                    AddHandler tlp.KeyDown, AddressOf fnMetodosAbreviados
                    Call fnAsignaMetodoAbreviado_TableLayoutPanel(tlp)
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
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    AddHandler clb.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    AddHandler nm0.KeyDown, AddressOf fnMetodosAbreviados
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    AddHandler grd.KeyDown, AddressOf fnMetodosAbreviados
                End If
            End If


        Next

    End Sub

    Private Function fnMetodosAbreviados(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.F1 Then
            Dim frm As Form = frmMenu
            frm.MdiParent = frmMenuPrincipal
            permiso.PermisoFrmEspeciales(frm, True)
        End If


        If e.KeyValue = Keys.Escape Then
            If frm.Name.ToString.ToLower = "frmmenuprincipal" Then
                If RadMessageBox.Show("Desea Cerrar el sistema !!!", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Application.Exit()
                End If
                Return False
                Exit Function
            End If

            If RadMessageBox.Show("Desea Cerrar !!!", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                frm.Close()
            End If

        End If


        If e.KeyValue = 17 Then
            Try
                'limpiar los paneles
                Dim index
                For index = 0 To PanelContador - 1
                    paneles(index).BackColor = Color.Navy
                Next

                'pintar el panel Actual.
                paneles(PanelActual).Focus()
                paneles(PanelActual).BackColor = Color.Green
            Catch ex As Exception
            End Try

        End If

        Return False
    End Function

    Public Function fnGrid_seleccionarEnter(ByVal grd As RadGridView, ByVal col As Integer, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal valor As Boolean)
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim bitActual As Boolean = CType(grd.Rows(grd.SelectedRows(0).Index).Cells(col).Value, Boolean)
                If bitActual = True Then
                    grd.Rows(grd.SelectedRows(0).Index).Cells(col).Value = False
                Else
                    grd.Rows(grd.SelectedRows(0).Index).Cells(col).Value = True
                End If
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Public Function fnResize(ByVal pnl As Telerik.WinControls.UI.RadGroupBox, ByVal frm As Telerik.WinControls.UI.RadForm, ByVal rpv As Telerik.WinControls.UI.RadPageView)
        'si finaliza el cambio de tamaño del formulario.
        Try
            'colocar valores en textos.
            'txtAltoFrm.Text = Me.Size.Height.ToString
            'txtAnchoFrm.Text = Me.Size.Width.ToString

            'contenedor donde esta el titulo y los botones.
            Dim altoMenuContenedor As Integer = 50

            'espacios del grid view y el contenedor de paginas.
            Dim espaciosPageYgrid As Integer = 15

            'espacios no utilizados o restar al tamaño total del frm.
            Dim PanelDatos_Alto As Integer = altoMenuContenedor + CType(rpv.Size.Height, Integer) + espaciosPageYgrid

            'colocar la posicion donde queremos que inicie el panel contenedor del grid o listado.
            pnl.Location = New Point(pnl.Location.X, PanelDatos_Alto)

            'alto de formulario menos la posiscion inicial modificada del grid.
            Dim separadorPieGrid As Integer = 34

            'nuevo alto del grid view ajustable.
            Dim tamañoGrid_Alto As Integer = CType(frm.Size.Height, Integer) - PanelDatos_Alto - separadorPieGrid

            'cambiar el tamaño del panel que contiene el grid o lista.
            pnl.Size = New Size(frm.Size.Width - 30, tamañoGrid_Alto)

        Catch ex As Exception
        End Try

        Return False
    End Function

    Public Function fnInicio(ByVal controles As ControlCollection, ByVal grdDatos As Telerik.WinControls.UI.RadGridView, ByVal f As Integer, ByVal c As Integer)

        Dim columnaNombre As String
        Dim celda As String
        Try
            If f >= 0 Then
                For index As Integer = 0 To grdDatos.Columns.Count - 1
                    columnaNombre = grdDatos.Columns(index).Name.ToString
                    Try
                        celda = grdDatos.SelectedRows(0).Cells(index).Value.ToString


                    Catch ex As Exception
                        celda = ""
                    End Try

                    llenaCampos(celda, columnaNombre, controles)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return True
    End Function

    Public Sub llenaCampos(ByVal celda As String, ByVal columna As String, ByVal controles As ControlCollection)
        Dim ctl As New Control
        Dim nombre As String
        Dim txt As System.Windows.Forms.TextBox
        Dim cmb As System.Windows.Forms.ComboBox
        Dim chk As CheckBox
        Dim pnl As Panel
        Dim msk As MaskedTextBox
        Dim iniciales As String
        Dim dtp As DateTimePicker
        Dim nm0 As System.Windows.Forms.NumericUpDown 'numero, nm0= numero con cero decimales hasta nm5= numero 5 decimales.
        Dim prg As RadProgressBar
        Dim clr As RadToggleButton
        Dim lbl As Label
        Dim rbn As RadioButton
        Dim pct As PictureBox

        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView

        For Each ctl In controles
            nombre = ctl.Name
            If nombre <> "" Then
                iniciales = tipoControl(nombre)

                If iniciales = "pnl" Then
                    pnl = ctl
                    Call llenaCamposPanel2(pnl, celda, columna)
                ElseIf iniciales = "rpv" Then
                    rpv = ctl
                    Call llenaCamposPage(rpv, celda, columna)

                ElseIf iniciales = "rbn" Then

                    rbn = ctl
                    If rbn.Name.ToString.ToLower = columna.ToLower Then
                        If celda.ToString.Length = 0 Or celda.Equals("0") Or celda.Equals("False") Then
                            rbn.Checked = False
                        Else
                            rbn.Checked = True
                        End If
                    End If

                ElseIf iniciales = "lbl" Then
                    lbl = ctl
                    If lbl.Name.Substring(3, lbl.Name.Length - 3).ToLower = columna.ToLower Then
                        lbl.Text = celda
                    End If
                ElseIf iniciales = "clr" Then
                    clr = ctl
                    'clr.ImageList = frmControles.ImageListAdministracion
                    If clr.Name.ToString.ToLower = columna.ToLower Then
                        clr.ImageIndex = celda
                    End If
                ElseIf iniciales = "prg" Then
                    prg = ctl
                    If prg.Name.ToString.ToLower = columna.ToLower Then

                        If IsNumeric(celda) Then
                            Dim valor As Double = celda
                            If valor < 0 Then
                                prg.Value1 = 0
                                prg.Text = "0%"
                            ElseIf celda > 100 Then
                                prg.Value1 = 100
                                prg.Text = "100%"
                            Else
                                prg.Value1 = valor
                                prg.Text = valor.ToString + "%"
                            End If
                        Else
                            prg.Value1 = 0
                            prg.Text = "0%"
                        End If
                    End If


                ElseIf iniciales = "txt" Then
                    txt = ctl
                    If txt.Name.Substring(3, txt.Name.Length - 3).ToLower = columna.ToLower Then
                        If celda.ToString.Length = 0 Then
                            ctl.Text = ""
                        Else
                            ctl.Text = celda
                        End If
                    End If
                ElseIf iniciales = "cmb" Then
                    cmb = ctl
                    If columna.Length > 3 Then

                        If cmb.Name.Substring(3, cmb.Name.Length - 3).ToLower = columna.ToLower Then

                            If celda.ToString.Length = 0 Then
                                cmb.Text = ""
                            Else
                                'cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                                'cmb.AutoCompleteSource = AutoCompleteSource.ListItems
                                cmb.Text = celda
                            End If
                        End If
                    End If
                ElseIf iniciales = "dtp" Then
                    dtp = ctl
                    If dtp.Name.Substring(3, dtp.Name.Length - 3).ToString.ToLower = columna.ToLower Then
                        If celda.ToString.Length = 0 Then
                            dtp.Text = ""
                        Else
                            dtp.Text = celda
                        End If

                    End If
                ElseIf iniciales = "chk" Then
                    chk = ctl
                    If chk.Name.ToString.ToLower = columna.ToLower Then
                        If celda.ToString.Length = 0 Or celda.Equals("0") Or celda.Equals("False") Then
                            chk.Checked = False
                        Else
                            chk.Checked = True
                        End If
                    End If
                ElseIf iniciales = "msk" Then
                    msk = ctl
                    If msk.Name.ToString.ToLower = columna.ToLower Then
                        If celda.ToString.Length = 0 Then
                            msk.Text = ""
                        Else
                            msk.Text = celda
                        End If
                    End If
                ElseIf iniciales = "pct" Then
                    pct = ctl
                    If pct.Name.Substring(3, pct.Name.Length - 3).ToLower = columna.ToLower Then
                        If celda.Length > 0 Then
                            If My.Computer.FileSystem.FileExists(celda) Then
                                Dim stream As New System.IO.StreamReader(celda)
                                pct.Image = Image.FromStream(stream.BaseStream)
                                stream.Dispose()
                            Else
                                pct.Image = Nothing
                            End If
                        Else
                            pct.Image = Nothing
                        End If
                    End If
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    If nm0.Name.Substring(3, nm0.Name.Length - 3).ToLower = columna.ToLower Then
                        If celda.ToLower.Length = 0 Then
                            nm0.Value = 0
                        Else
                            'verificar posicion de decimales.
                            Dim numeroDecimal As Integer = iniciales.Substring(2, 1)
                            nm0.DecimalPlaces = numeroDecimal
                            nm0.Value = celda
                            nm0.TextAlign = HorizontalAlignment.Right
                        End If
                    End If
                End If
            End If

        Next
    End Sub

    Public Sub llenaCamposPanel2(ByVal panel As Panel, ByVal celda As String, ByVal columna As String)
        Dim ctl As New Control
        Dim nombre As String
        Dim txt As System.Windows.Forms.TextBox
        Dim cmb As System.Windows.Forms.ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim dtp As DateTimePicker
        Dim iniciales As String
        Dim prg As RadProgressBar
        Dim clr As RadToggleButton
        Dim lbl As Label
        Dim rbn As RadioButton
        Dim nm0 As System.Windows.Forms.NumericUpDown
        Dim pct As PictureBox
        Try
            For Each ctl In panel.Controls
                nombre = ctl.Name
                If nombre <> "" Then
                    iniciales = tipoControl(nombre)

                    If iniciales = "rbn" Then

                        rbn = ctl
                        If rbn.Name.ToString.ToLower = columna.ToLower Then
                            If celda.ToString.Length = 0 Or celda.Equals("0") Or celda.Equals("False") Then
                                rbn.Checked = False
                            Else
                                rbn.Checked = True
                            End If
                        End If

                    ElseIf iniciales = "lbl" Then
                        lbl = ctl
                        If lbl.Name.Substring(3, lbl.Name.Length - 3).ToLower = columna.ToLower Then
                            lbl.Text = celda
                        End If
                    ElseIf iniciales = "clr" Then
                        clr = ctl
                        'clr.ImageList = frmControles.ImageListAdministracion
                        If clr.Name.ToString.ToLower = columna.ToLower Then
                            clr.ImageIndex = celda
                        End If
                    ElseIf iniciales = "prg" Then
                        prg = ctl
                        If prg.Name.ToString.ToLower = columna.ToLower Then

                            If IsNumeric(celda) Then
                                Dim valor As Double = celda
                                If valor < 0 Then
                                    prg.Value1 = 0
                                    prg.Text = "0%"
                                ElseIf celda > 100 Then
                                    prg.Value1 = 100
                                    prg.Text = "100%"
                                Else
                                    prg.Value1 = valor
                                    prg.Text = valor.ToString + "%"
                                End If
                            Else
                                prg.Value1 = 0
                                prg.Text = "0%"
                            End If
                        End If


                    ElseIf iniciales = "txt" Then
                        txt = ctl
                        If txt.Name.Substring(3, txt.Name.Length - 3).ToLower = columna.ToLower Then
                            If celda.ToString.Length = 0 Then
                                ctl.Text = ""
                            Else
                                ctl.Text = celda
                            End If
                        End If
                    ElseIf iniciales = "cmb" Then
                        cmb = ctl
                        If columna.Length > 3 Then

                            If cmb.Name.Substring(3, cmb.Name.Length - 3).ToLower = columna.ToLower Then

                                If celda.ToString.Length = 0 Then
                                    cmb.Text = ""
                                Else
                                    'cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                                    'cmb.AutoCompleteSource = AutoCompleteSource.ListItems
                                    cmb.Text = celda
                                End If
                            End If
                        End If
                    ElseIf iniciales = "dtp" Then
                        dtp = ctl
                        If dtp.Name.Substring(3, dtp.Name.Length - 3).ToString.ToLower = columna.ToLower Then
                            If celda.ToString.Length = 0 Then
                                dtp.Text = ""
                            Else
                                dtp.Text = celda
                            End If

                        End If
                    ElseIf iniciales = "chk" Then
                        chk = ctl
                        If chk.Name.ToString.ToLower = columna.ToLower Then
                            If celda.ToString.Length = 0 Or celda.Equals("0") Or celda.Equals("False") Then
                                chk.Checked = False
                            Else
                                chk.Checked = True
                            End If
                        End If
                    ElseIf iniciales = "msk" Then
                        msk = ctl
                        If msk.Name.ToString.ToLower = columna.ToLower Then
                            If celda.ToString.Length = 0 Then
                                msk.Text = ""
                            Else
                                msk.Text = celda
                            End If
                        End If
                    ElseIf iniciales = "pct" Then
                        pct = ctl
                        If pct.Name.Substring(3, pct.Name.Length - 3).ToLower = columna.ToLower Then
                            If celda.Length > 0 Then
                                If My.Computer.FileSystem.FileExists(celda) Then
                                    Dim stream As New System.IO.StreamReader(celda)
                                    pct.Image = Image.FromStream(stream.BaseStream)
                                    stream.Dispose()
                                Else
                                    pct.Image = Nothing
                                End If
                            Else
                                pct.Image = Nothing
                            End If
                        End If
                    ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                        nm0 = ctl
                        If nm0.Name.Substring(3, nm0.Name.Length - 3).ToLower = columna.ToLower Then
                            If celda.ToLower.Length = 0 Then
                                nm0.Value = 0
                            Else
                                'verificar posicion de decimales.
                                Dim numeroDecimal As Integer = iniciales.Substring(2, 1)
                                nm0.DecimalPlaces = numeroDecimal
                                nm0.Value = celda
                                nm0.TextAlign = HorizontalAlignment.Right
                            End If
                        End If
                    End If
                End If


            Next

        Catch ex As Exception
            MsgBox("LLenaPanel " + ex.ToString)
        End Try


    End Sub

    Public Sub llenaCamposPage(ByVal paginas As Telerik.WinControls.UI.RadPageView, ByVal celda As String, ByVal columna As String)
        Dim ctl As New Control
        Dim nombre As String
        Dim txt As System.Windows.Forms.TextBox
        Dim cmb As System.Windows.Forms.ComboBox
        Dim chk As CheckBox
        Dim msk As MaskedTextBox
        Dim dtp As DateTimePicker
        Dim iniciales As String
        Dim prg As RadProgressBar
        Dim clr As RadToggleButton
        Dim lbl As Label
        Dim rbn As RadioButton
        Dim nm0 As System.Windows.Forms.NumericUpDown
        Dim pct As PictureBox

        Try
            Dim pagina As Telerik.WinControls.UI.RadPageViewPage
            'recorrer las paginas
            For Each pagina In paginas.Pages

                'recorrer los controles de las paginas
                For Each ctl In pagina.Controls

                    nombre = ctl.Name
                    If nombre <> "" Then
                        iniciales = tipoControl(nombre)
                        If iniciales = "rbn" Then

                            rbn = ctl
                            If rbn.Name.ToString.ToLower = columna.ToLower Then
                                If celda.ToString.Length = 0 Or celda.Equals("0") Or celda.Equals("False") Then
                                    rbn.Checked = False
                                Else
                                    rbn.Checked = True
                                End If
                            End If

                        ElseIf iniciales = "lbl" Then
                            lbl = ctl
                            If lbl.Name.Substring(3, lbl.Name.Length - 3).ToLower = columna.ToLower Then
                                lbl.Text = celda
                            End If
                        ElseIf iniciales = "clr" Then
                            clr = ctl
                            'clr.ImageList = frmControles.ImageListAdministracion
                            If clr.Name.ToString.ToLower = columna.ToLower Then
                                clr.ImageIndex = celda
                            End If
                        ElseIf iniciales = "prg" Then
                            prg = ctl
                            If prg.Name.ToString.ToLower = columna.ToLower Then

                                If IsNumeric(celda) Then
                                    Dim valor As Double = celda
                                    If valor < 0 Then
                                        prg.Value1 = 0
                                        prg.Text = "0%"
                                    ElseIf celda > 100 Then
                                        prg.Value1 = 100
                                        prg.Text = "100%"
                                    Else
                                        prg.Value1 = valor
                                        prg.Text = valor.ToString + "%"
                                    End If
                                Else
                                    prg.Value1 = 0
                                    prg.Text = "0%"
                                End If
                            End If


                        ElseIf iniciales = "txt" Then
                            txt = ctl
                            If txt.Name.Substring(3, txt.Name.Length - 3).ToLower = columna.ToLower Then
                                If celda.ToString.Length = 0 Then
                                    ctl.Text = ""
                                Else
                                    ctl.Text = celda
                                End If
                            End If
                        ElseIf iniciales = "cmb" Then
                            cmb = ctl
                            If columna.Length > 3 Then

                                If cmb.Name.Substring(3, cmb.Name.Length - 3).ToLower = columna.ToLower Then

                                    If celda.ToString.Length = 0 Then
                                        cmb.Text = ""
                                    Else
                                        'cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                                        'cmb.AutoCompleteSource = AutoCompleteSource.ListItems
                                        cmb.Text = celda
                                    End If
                                End If
                            End If
                        ElseIf iniciales = "dtp" Then
                            dtp = ctl
                            If dtp.Name.Substring(3, dtp.Name.Length - 3).ToString.ToLower = columna.ToLower Then
                                If celda.ToString.Length = 0 Then
                                    dtp.Text = ""
                                Else
                                    dtp.Text = celda
                                End If

                            End If
                        ElseIf iniciales = "chk" Then
                            chk = ctl
                            If chk.Name.ToString.ToLower = columna.ToLower Then
                                If celda.ToString.Length = 0 Or celda.Equals("0") Or celda.Equals("False") Then
                                    chk.Checked = False
                                Else
                                    chk.Checked = True
                                End If
                            End If
                        ElseIf iniciales = "msk" Then
                            msk = ctl
                            If msk.Name.ToString.ToLower = columna.ToLower Then
                                If celda.ToString.Length = 0 Then
                                    msk.Text = ""
                                Else
                                    msk.Text = celda
                                End If
                            End If
                        ElseIf iniciales = "pct" Then
                            pct = ctl
                            If pct.Name.Substring(3, pct.Name.Length - 3).ToLower = columna.ToLower Then
                                If celda.Length > 0 Then
                                    If My.Computer.FileSystem.FileExists(celda) Then
                                        Dim stream As New System.IO.StreamReader(celda)
                                        pct.Image = Image.FromStream(stream.BaseStream)
                                        stream.Dispose()
                                    Else
                                        pct.Image = Nothing
                                    End If
                                Else
                                    pct.Image = Nothing
                                End If
                            End If
                        ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                            nm0 = ctl
                            If nm0.Name.Substring(3, nm0.Name.Length - 3).ToLower = columna.ToLower Then
                                If celda.ToLower.Length = 0 Then
                                    nm0.Value = 0
                                Else
                                    'verificar posicion de decimales.
                                    Dim numeroDecimal As Integer = iniciales.Substring(2, 1)
                                    nm0.DecimalPlaces = numeroDecimal
                                    nm0.Value = celda
                                    nm0.TextAlign = HorizontalAlignment.Right
                                End If
                            End If
                        End If
                    End If


                Next


            Next



        Catch ex As Exception
            MsgBox("LLenaPanel " + ex.ToString)
        End Try


    End Sub

    Private Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function

    Public Function fnFormato(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)

        If TypeOf e.CellElement.RowInfo Is GridViewFilteringRowInfo Then
            Return False
        End If

        Dim celda As String = e.CellElement.ColumnInfo.Name.ToString
        Dim columnaNombre As String = e.Column.Name.ToString

        'condiciones para colocar formato es . largo mayor a 3.
        If celda.Length > 3 Then
            Dim iniciales As String = tipoControl(celda)
            If iniciales = "cod" Then
                e.Column.IsVisible = False

                'ElseIf iniciales = "txb" Or iniciales = "txm" Then 'edicion, modificar

                '    If celda.Substring(3, celda.Length - 3).ToLower = columnaNombre.Substring(3, columnaNombre.Length - 3).ToLower Then
                '        If TypeOf e.CellElement.ColumnInfo Is GridViewDataColumn Then
                '            If Not (TypeOf e.CellElement.RowElement Is GridGroupHeaderRowElement) Then
                '                'cambiar de celda al header de la columna
                '                e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                '            End If
                '        End If

                '    End If
            ElseIf iniciales = "prg" Then

                If celda.Substring(3, celda.Length - 3).ToLower = columnaNombre.Substring(3, columnaNombre.Length - 3).ToLower Then


                    If TypeOf e.CellElement.ColumnInfo Is GridViewDataColumn Then
                        If Not (TypeOf e.CellElement.RowElement Is GridGroupHeaderRowElement) Then

                            'cambiar de celda al header de la columna
                            e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)

                            If e.CellElement.Children.Count > 0 Then

                                'Actualizar valores.
                                Dim valor As Integer
                                Dim prg As RadProgressBarElement = e.CellElement.Children(0)
                                prg.Minimum = 0
                                prg.Maximum = 100
                                prg.StretchHorizontally = True
                                prg.StretchVertically = True
                                Try
                                    valor = e.CellElement.Value
                                    If valor < 0 Then
                                        prg.Value1 = 0
                                        prg.Text = valor.ToString + "%"
                                    ElseIf valor > 100 Then
                                        valor = 100
                                        prg.Value1 = 100
                                        prg.Text = valor.ToString + "%"
                                    Else
                                        prg.Value1 = e.CellElement.Value
                                        prg.Text = valor.ToString + "%"
                                    End If
                                Catch ex As Exception
                                    valor = 0
                                    prg.Value1 = 0
                                    prg.Text = valor.ToString + "%"
                                End Try

                            Else
                                'Crear 
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
                            'Existe actualizar su valor.
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

                        e.Column.Width = 70
                    Catch ex As Exception

                    End Try

                End If
            ElseIf iniciales = "chk" Then
                'cambiar de celda al header de la columna
                e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)

            ElseIf iniciales = "chb" Then ' buscar
                'cambiar de celda al header de la columna
                e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                'opciones de icono para checkbox
                'e.Column.HeaderImage = laFuente.My.Resources.Resources.search20x20
                'e.Column.TextImageRelation = TextImageRelation.TextBeforeImage
            ElseIf iniciales = "chm" Then 'Modificar
                'cambiar de celda al header de la columna
                e.CellElement.ColumnInfo.HeaderText = celda.Substring(3, celda.Length - 3)
                'opciones de icono para checkbox
                'e.Column.HeaderImage = laFuente.My.Resources.Resources.edit20x20
                'e.Column.TextImageRelation = TextImageRelation.TextBeforeImage
            Else
                'cambiar de celda al header de la columna
                e.CellElement.Children.Clear()
            End If

        Else
            Dim acronimo As String
            acronimo = celda.Substring(0, 2)
            If acronimo = "Id" Then
                e.CellElement.Alignment = ContentAlignment.BottomLeft
                e.CellElement.TextAlignment = ContentAlignment.BottomLeft
                e.Column.Width = "50"
            End If

            e.CellElement.Children.Clear()
        End If
        Return True
    End Function

    Public Function fnAceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        'RaiseEvent botonAceptar()

        Return True
    End Function

    Public Function fnCancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        'RaiseEvent botonCancelar()
        Return True
    End Function



    '-------------------------------------DESHABILITAR CAMPOS
    Public Sub FnDeshabilitarHabilitarCampos(frm As Form, estado As Boolean)
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
        Dim clb As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox

        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView


        For Each ctl In frm.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                iniciales = tipoControl(nombre)
                If iniciales = "pnl" Then
                    pnl = ctl
                    Call fnDeshabilitarHabilitar_panel(pnl, estado)
                ElseIf iniciales = "rpv" Then
                    rpv = ctl
                    Call fnDeshabilitarHabilitar_Page(rpv, estado)
                ElseIf iniciales = "rgb" Then
                    rgb = ctl
                    Call fnDeshabilitarHabilitar_Grupo(rgb, estado)
                ElseIf iniciales = "rbn" Then
                    rbn = ctl
                    rbn.Enabled = estado
                ElseIf iniciales = "lbl" Then
                    lbl = ctl
                    lbl.Enabled = estado
                ElseIf iniciales = "clr" Then
                    clr = ctl
                    clr.Enabled = estado
                ElseIf iniciales = "prg" Then
                    prg = ctl
                    prg.Enabled = estado
                ElseIf iniciales = "txt" Then
                    txt = ctl
                    txt.Enabled = estado
                ElseIf iniciales = "cmb" Then
                    cmb = ctl
                    cmb.Enabled = estado
                ElseIf iniciales = "dtp" Then
                    dtp = ctl
                    dtp.Enabled = estado
                ElseIf iniciales = "chk" Then
                    chk = ctl
                    chk.Enabled = estado
                ElseIf iniciales = "msk" Then
                    msk = ctl
                    msk.Enabled = estado
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    clb.Enabled = estado
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    nm0.Enabled = estado
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    fnDeshabilitarGrid(grd, estado)
                End If
            End If
        Next
    End Sub

    Private Sub fnDeshabilitarGrid(grd As Telerik.WinControls.UI.RadGridView, estado As Boolean)
        grd.AllowEditRow = False
        Dim index
        For index = 0 To grd.Columns.Count - 1
            grd.Columns(index).readonly = True
        Next

    End Sub

    Private Sub fnDeshabilitarHabilitar_Page(ByVal rpv As Telerik.WinControls.UI.RadPageView, estado As Boolean)
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
        Dim clb As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox

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
                        Call fnDeshabilitarHabilitar_panel(pnl, estado)
                    ElseIf iniciales = "rpv" Then
                        rpv = ctl
                        Call fnDeshabilitarHabilitar_Page(rpv, estado)
                    ElseIf iniciales = "rgb" Then
                        rgb = ctl
                        Call fnDeshabilitarHabilitar_Grupo(rgb, estado)
                    ElseIf iniciales = "rbn" Then
                        rbn = ctl
                        rbn.Enabled = estado
                    ElseIf iniciales = "lbl" Then
                        lbl = ctl
                        lbl.Enabled = estado
                    ElseIf iniciales = "clr" Then
                        clr = ctl
                        clr.Enabled = estado
                    ElseIf iniciales = "prg" Then
                        prg = ctl
                        prg.Enabled = estado
                    ElseIf iniciales = "txt" Then
                        txt = ctl
                        txt.Enabled = estado
                    ElseIf iniciales = "cmb" Then
                        cmb = ctl
                        cmb.Enabled = estado
                    ElseIf iniciales = "dtp" Then
                        dtp = ctl
                        dtp.Enabled = estado
                    ElseIf iniciales = "chk" Then
                        chk = ctl
                        chk.Enabled = estado
                    ElseIf iniciales = "msk" Then
                        msk = ctl
                        msk.Enabled = estado
                    ElseIf iniciales = "clb" Then
                        clb = ctl
                        clb.Enabled = estado
                    ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                        nm0 = ctl
                        nm0.Enabled = estado
                    ElseIf iniciales = "grd" Then
                        grd = ctl
                        fnDeshabilitarGrid(grd, estado)
                    End If
                End If

            Next
        Next
    End Sub

    Private Sub fnDeshabilitarHabilitar_panel(ByVal pnl As Panel, estado As Boolean)
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
        Dim clb As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim rgb As Telerik.WinControls.UI.RadGroupBox

        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView


        For Each ctl In pnl.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                iniciales = tipoControl(nombre)
                If iniciales = "pnl" Then
                    pnl = ctl
                    Call fnDeshabilitarHabilitar_panel(pnl, estado)
                ElseIf iniciales = "rpv" Then
                    rpv = ctl
                    Call fnDeshabilitarHabilitar_Page(rpv, estado)
                ElseIf iniciales = "rgb" Then
                    rgb = ctl
                    Call fnDeshabilitarHabilitar_Grupo(rgb, estado)
                ElseIf iniciales = "rbn" Then
                    rbn = ctl
                    rbn.Enabled = estado
                ElseIf iniciales = "lbl" Then
                    lbl = ctl
                    lbl.Enabled = estado
                ElseIf iniciales = "clr" Then
                    clr = ctl
                    clr.Enabled = estado
                ElseIf iniciales = "prg" Then
                    prg = ctl
                    prg.Enabled = estado
                ElseIf iniciales = "txt" Then
                    txt = ctl
                    txt.Enabled = estado
                ElseIf iniciales = "cmb" Then
                    cmb = ctl
                    cmb.Enabled = estado
                ElseIf iniciales = "dtp" Then
                    dtp = ctl
                    dtp.Enabled = estado
                ElseIf iniciales = "chk" Then
                    chk = ctl
                    chk.Enabled = estado
                ElseIf iniciales = "msk" Then
                    msk = ctl
                    msk.Enabled = estado
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    clb.Enabled = estado
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    nm0.Enabled = estado
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    fnDeshabilitarGrid(grd, estado)
                End If
            End If


        Next

    End Sub

    Private Sub fnDeshabilitarHabilitar_Grupo(ByVal rgb As Telerik.WinControls.UI.RadGroupBox, estado As Boolean)
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
        Dim clb As CheckedListBox
        Dim grd As Telerik.WinControls.UI.RadGridView
        Dim pnl As Panel

        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView


        For Each ctl In rgb.Controls
            nombre = ctl.Name
            If nombre <> "" Then
                iniciales = tipoControl(nombre)
                If iniciales = "pnl" Then
                    pnl = ctl
                    Call fnDeshabilitarHabilitar_panel(pnl, estado)
                ElseIf iniciales = "rpv" Then
                    rpv = ctl
                    Call fnDeshabilitarHabilitar_Page(rpv, estado)
                ElseIf iniciales = "rgb" Then
                    rgb = ctl
                    Call fnDeshabilitarHabilitar_Grupo(rgb, estado)
                ElseIf iniciales = "rbn" Then
                    rbn = ctl
                    rbn.Enabled = estado
                ElseIf iniciales = "lbl" Then
                    lbl = ctl
                    lbl.Enabled = estado
                ElseIf iniciales = "clr" Then
                    clr = ctl
                    clr.Enabled = estado
                ElseIf iniciales = "prg" Then
                    prg = ctl
                    prg.Enabled = estado
                ElseIf iniciales = "txt" Then
                    txt = ctl
                    txt.Enabled = estado
                ElseIf iniciales = "cmb" Then
                    cmb = ctl
                    cmb.Enabled = estado
                ElseIf iniciales = "dtp" Then
                    dtp = ctl
                    dtp.Enabled = estado
                ElseIf iniciales = "chk" Then
                    chk = ctl
                    chk.Enabled = estado
                ElseIf iniciales = "msk" Then
                    msk = ctl
                    msk.Enabled = estado
                ElseIf iniciales = "clb" Then
                    clb = ctl
                    clb.Enabled = estado
                ElseIf iniciales = "nm0" Or iniciales = "nm1" Or iniciales = "nm2" Or iniciales = "nm3" Or iniciales = "nm4" Or iniciales = "nm5" Then
                    nm0 = ctl
                    nm0.Enabled = estado
                ElseIf iniciales = "grd" Then
                    grd = ctl
                    fnDeshabilitarGrid(grd, estado)
                End If
            End If


        Next

    End Sub

End Class

