
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

Public Class frmBaseLista


    'Creamos los eventos publicos para agregar, grabar y modificar
    Public Event focoDatos() ' coloca el foco en el primer campo indicado de forma manual.
    Public Event nuevoRegistro()
    Public Event grabaRegistro()
    Public Event eliminaRegistro()
    Public Event modificaRegistro()
    Public Event llenarLista()
    Public Event imprimir()
    Public Event Exportar()
    Public Event Filtro()
    Public Event reporte()
    Public Event botonClick()
    Public Event botonAceptar()
    Public Event botonCancelar()
    Public Event verRegistro()
    Public Event quitarFiltro()

    Public Event cambiaFilaGrdDatos()
    Public errores As New ErrorProviderExtended

    Public borrar As Boolean = False
    Private _tblView As DataTable
    Private _nuevo As Boolean
    Private _modificar As Boolean
    Private _eliminar As Boolean
    Private _grabar As Boolean
    Private _EliminarFila As Boolean = True

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
    Public frmBarraLateralBaseIzquierda As Telerik.WinControls.UI.RadForm

    'formulario de barra lateral
    Public frmBarraLateralBaseDerecha As Telerik.WinControls.UI.RadForm

    Dim permiso As New clsPermisoUsuario

    'patrontecnocom.servergame.com
    '
    ' --------------------------------VARIABLES Y EVENTOS PARA PANELES.--------------- -------------------

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

    Public paneles As Panel()
    Dim PanelContador As Integer = 0
    Dim PanelActual As Integer

    'cuando se carga el formulario una vez se ejecuta agregar panles pnx, y luego ya no tiene efecto.
    Dim panelesAgregarEvento As Integer = 0

    '-----------------------------------fin eventos y variables para paneles.--------------------------
    Private _ActivarBarraLateral As Boolean = False

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

    Private _grdScrollHorizontal As Boolean = False

    Public Property grdScrollHorizontal() As Boolean
        Get
            grdScrollHorizontal = _grdScrollHorizontal
        End Get
        Set(ByVal value As Boolean)
            _grdScrollHorizontal = value
        End Set
    End Property

    Public Property EliminarFila() As Boolean
        Get
            EliminarFila = _EliminarFila
        End Get
        Set(value As Boolean)
            _EliminarFila = value
        End Set
    End Property

    Public filtrarTecla As Boolean = True

    '--------------------------------FUNCIONES PARA CTRL (control).  
    Private Function fnPaneles_agregar(ByVal frm As Form)
        PanelContador = 0

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
                        ReDim Preserve paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    paneles(numeroPanel) = pnl

                    'incrementar el contador
                    PanelContador = PanelContador + 1

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
                        ReDim Preserve paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    paneles(NumeroPanel) = pnl

                    'incrementar el contador
                    PanelContador = PanelContador + 1

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

    Private Sub ActivarScrollHorizontal()
        If grdScrollHorizontal = True Then
            Me.grdDatos.HorizontalScroll.Enabled = True
        End If
    End Sub

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

                    If maximo < NumeroPanel Then
                        maximo = NumeroPanel
                        ReDim Preserve paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    paneles(NumeroPanel) = pnl

                    'incrementar el contador
                    PanelContador = PanelContador + 1

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
                        ReDim Preserve paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    paneles(NumeroPanel) = pnl

                    'incrementar el contador
                    PanelContador = PanelContador + 1

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
        RaiseEvent nuevoRegistro()
    End Sub

    Private Sub fnPanel1()
        RaiseEvent modificaRegistro()
    End Sub

    Private Sub fnPanel2()
        RaiseEvent eliminaRegistro()
    End Sub

    Private Sub fnPanel3()
        RaiseEvent imprimir()
    End Sub

    Private Sub fnPanel4()
        'RaiseEvent panel4()
        RaiseEvent Exportar()
    End Sub

    Private Sub fnPanel5()
        'RaiseEvent panel5()
        RaiseEvent quitarFiltro()
    End Sub

    Private Sub fnPanel6()
        'RaiseEvent panel6()
        Me.Close()
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
        For index = 0 To PanelContador - 1
            paneles(index).BackColor = Color.Navy
        Next

        DirectCast(sender, Panel).BackColor = Color.Green

        Dim numero As String = mdlPublicVars.tipoControlRango(DirectCast(sender, Panel).Name, 3, 1)
        If IsNumeric(numero) Then
            PanelActual = numero
            'lblActual.Text = actual
        End If

    End Sub

    Private Sub paneles_abajo_arriba(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        'Dim nombre As String = DirectCast(sender, Panel).Name

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

        'si presiono la tecla para abajo, aumentar asignar foco a panel nuevo
        If (e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right) Then

            'limpiar los paneles
            Dim index
            For index = 0 To PanelContador - 1
                paneles(index).BackColor = Color.Navy
            Next

            'si presiona abajo o derecha -- e.KeyValue = Keys.Down Or
            If (PanelActual + 1 < PanelContador) And (e.KeyValue = Keys.Right) Then
                PanelActual = PanelActual + 1
            End If

            'si presiona izquierda --e.KeyValue = Keys.Up Or
            If (PanelActual - 1 >= 0) And (e.KeyValue = Keys.Left) Then
                PanelActual = PanelActual - 1
            End If

            'pintar el panel Actual.
            paneles(PanelActual).Focus()
            paneles(PanelActual).BackColor = Color.Green

        End If


        If e.KeyValue = Keys.Enter Then

            '    'agregar eventos de clic al panel
            Select Case PanelActual
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


    Private Function tipoControl(ByVal nombre As String) As String
        Dim acronimo As String
        acronimo = nombre.Substring(0, 3)
        Return acronimo
    End Function


    Public Sub limpiaCampos()
        mdlPublicVars.limpiaCampos(Me)
    End Sub

    Private Sub FrmBaseTelerik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltroLista(cmbFiltroFecha)
        cmbFiltroFecha.Visible = False
        'Asignar que el panel actual
        PanelActual = 0
        frmMenuPrincipal.Text = Me.Text

        'agregar paneles para eventos.
        If panelesAgregarEvento = 0 Then
            fnPaneles_agregar(Me)
            FnAsignaMetodoAbreviado(Me)
            panelesAgregarEvento += 1
        End If

        ActivarScrollHorizontal()
        fnInicio()



    End Sub

    '-----------------------------FUNCIONES PARA FUNCIONAMIENTO.

    Public Function fnInicio()
        lblTitulo.Text = Me.Text

        mdlPublicVars.fnFormatoGridMovimientos(grdDatos)
        grdDatos.EnableGrouping = True

        grdDatos.MasterTemplate.ShowTotals = True
        Dim summaryId As New GridViewSummaryItem("Codigo", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
        Dim summaryCodigo1 As New GridViewSummaryItem("Codigo1", mdlPublicVars.SimboloRecuento + "={0}", GridAggregateFunction.Count)
        Dim summaryCantidad As New GridViewSummaryItem("Total", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoMonedaGridTelerik, GridAggregateFunction.Sum)
        Dim summaryDisponible As New GridViewSummaryItem("Disponible", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summaryTransito As New GridViewSummaryItem("Transito", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summarySurtir As New GridViewSummaryItem("Surtir", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summarySaldo As New GridViewSummaryItem("Saldo", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summaryMonto As New GridViewSummaryItem("Monto", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        'proveedores
        Dim summarySaldoFisico As New GridViewSummaryItem("SaldoFisico", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summarySaldoTransito As New GridViewSummaryItem("SaldoTransito", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)


        'Factura lista
        Dim summaryTotalDespacho As New GridViewSummaryItem("TotalDespacho", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)
        Dim summaryTotalFactura As New GridViewSummaryItem("TotalFacturado", mdlPublicVars.SimboloSuma + "=" + mdlPublicVars.formatoNumeroGridTelerik, GridAggregateFunction.Sum)


        'agregar la fila de operaciones aritmeticas
        Dim summaryRowItem As New GridViewSummaryRowItem(New GridViewSummaryItem() {summaryId, summaryCodigo1, summaryCantidad, summaryDisponible, summaryTransito, summarySurtir, summarySaldo, summarySaldoFisico, summarySaldoTransito, summaryMonto, summaryTotalDespacho, summaryTotalFactura})


        'agregar summario arreglo a grid
        grdDatos.SummaryRowsTop.Add(summaryRowItem)


        Me.grdDatos.Focus()


        'asociar el listado de imagenes. para columna Tipo Imagen.
        'Me.grdDatos.ImageList = frmControles.ImageListAdministracion
        Return True

    End Function

    Private Sub grdDatos_CellFormatting(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles grdDatos.CellFormatting
        Try
            base.fnFormato(sender, e)

            Dim cell As GridSummaryCellElement = TryCast(e.CellElement, GridSummaryCellElement)
            If cell IsNot Nothing Then
                Dim values As Object() = cell.Values
                If CInt(values(0)) > 5 Then
                    e.CellElement.ForeColor = Color.Red
                Else
                    e.CellElement.ForeColor = Color.Black
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FnNuevo()
        RaiseEvent nuevoRegistro()
    End Sub

    Private Sub fnGuardar()
        'If errores.CheckAndShowSummaryErrorMessage = False Then Exit Sub
        RaiseEvent grabaRegistro()

        Try
            Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).IsSelected = True
            Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).IsCurrent = True
            Me.grdDatos.MasterView.Rows(Me.grdDatos.Rows.Count - 1).EnsureVisible()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub fnModificar()
        If Me.grdDatos.Rows.Count > 0 Then
            If Me.grdDatos.CurrentRow.Index >= 0 Then
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

            End If

        End If

    End Sub

    Private Sub fnEliminar()
        If Me.grdDatos.CurrentRow.Index >= 0 Then
            filaSeleccionada = Me.grdDatos.CurrentRow.Index ' base.fnFilaSeleccionada_gridTelerik(Me.grdDatos, 0)
            RaiseEvent eliminaRegistro()

            Try
                'cuando no existan filas en el grid no seleccionar nada
                If Me.grdDatos.Rows.Count = 0 Then
                Else
                    'si la fila es mayor a cero, seleccionar la fila que estaba
                    'siempre que sea menor a contador

                    Me.grdDatos.MasterView.Rows(filaSeleccionada).IsSelected = True
                    Me.grdDatos.MasterView.Rows(filaSeleccionada).IsCurrent = True
                    Me.grdDatos.MasterView.Rows(filaSeleccionada).EnsureVisible()
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub fnExportar()
        RaiseEvent Exportar()
        mdlPublicVars.ConvertSelectedDataToString(Me.grdDatos, False)
        alertas.contenido = "Lista Copiada ..."
        alertas.fnErrorContenido()
    End Sub

    Private Sub FnImprimir()
        RaiseEvent imprimir()
    End Sub

    Private Sub fnSalir()
        If RadMessageBox.Show("Desea Salir de " + Me.Text.ToString, mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '---------------- FIN BOTONES

    ' -------------------------------------funciones jorge para colocar datos del grid en los textbox.


    Private Sub grdDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.SelectionChanged

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
            'base.fnInicio(Me.Controls, grdDatos, f, c)
        End If


    End Sub

    Private Sub FnAsignaMetodoAbreviado(ByVal frm As Form)
        'agregar al formulario
        'AddHandler frm.KeyDown, AddressOf fnMetodosAbreviados


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
                    AddHandler grd.KeyDown, AddressOf mdlPublicVars.gridcopyPaste
                End If
            End If
        Next

    End Sub

    Private Sub fnAsignaMetodoAbreviado_Page(ByVal rpv As Telerik.WinControls.UI.RadPageView)

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
                        AddHandler grd.KeyDown, AddressOf mdlPublicVars.gridcopyPaste
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
                    AddHandler grd.KeyDown, AddressOf mdlPublicVars.gridcopyPaste
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
        'telerik rad view page (rvp)
        Dim rpv As Telerik.WinControls.UI.RadPageView
        Dim grd As Telerik.WinControls.UI.RadGridView
        'Dim rgb As Telerik.WinControls.UI.RadGroupBox
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
                    AddHandler grd.KeyDown, AddressOf mdlPublicVars.gridcopyPaste
                End If
            End If


        Next

    End Sub


    Private Function fnMetodosAbreviados(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

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


        If e.KeyValue = Keys.F3 Then
            mdlPublicVars.frmPosX = Me.Location.X
            mdlPublicVars.frmPosY = Me.Location.Y
            mdlPublicVars.frmX = Me.Size.Width
            mdlPublicVars.frmY = frmMenuPrincipal.Size.Height
            Try
                permiso.PermisoDialogBarra(frmBarraLateralBaseDerecha)
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
            If RadMessageBox.Show("Desea Cerrar !!!", mdlPublicVars.nombreSistema, MessageBoxButtons.YesNo, RadMessageIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If

        If e.KeyValue = Keys.F1 Then
            Dim frm As Form = frmMenu
            frm.MdiParent = frmMenuPrincipal
            frm.Text = "Menú Principal"
            permiso.PermisoFrmEspeciales(frm, True)
            Me.Close()
        End If

        'eliminar
        If e.KeyValue = Keys.Delete Then
            If EliminarFila = True Then
                fnEliminar()
            End If
        End If

        'actualizar grid view
        If e.KeyValue = Keys.F5 Then
            RaiseEvent llenarLista()
            Me.grdDatos.PerformLayout()
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
                '    'limpiar los paneles
                Dim index
                For index = 0 To PanelContador - 1
                    paneles(index).BackColor = Color.Navy
                Next

                '    'pintar el panel Actual.
                paneles(PanelActual).Focus()
                paneles(PanelActual).BackColor = Color.Green
            Catch ex As Exception
            End Try

        End If

        Return 0
    End Function

    Private Sub fnAceptar(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent botonAceptar()
    End Sub

    Private Sub fnCancelar(ByVal sender As Object, ByVal e As System.EventArgs)
        RaiseEvent botonCancelar()
    End Sub

    Private Sub grdDatos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdDatos.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            RaiseEvent verRegistro()
        Else
            If filtrarTecla Then
                txtFiltro.Focus()
            End If
        End If
    End Sub

    Private Sub fnActualizarCampos(ByVal e)

        If e.KeyChar = ChrW(Keys.Enter) Then

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
                lblRegistros.Text = "Registro " + Format(Me.grdDatos.SelectedRows(0).Index + 1, mdlPublicVars.formatoNumero) + " de " + Format(Me.grdDatos.Rows.Count, mdlPublicVars.formatoNumero)
            Catch ex As Exception
                lblRegistros.Text = "0"
            End Try

            'base.fnInicio(Me.Controls, grdDatos, f, c)
        End If
    End Sub

    Private Sub txtFiltro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyDown

        If e.KeyValue = Keys.Enter Then
            RaiseEvent llenarLista()
            borrar = True
        Else
            If e.KeyValue = Keys.Down Then
                Me.grdDatos.Focus()
            ElseIf borrar = True Then
                txtFiltro.Text = ""
                borrar = False
            End If
        End If
    End Sub

    Private Sub grdDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles grdDatos.CellDoubleClick
        RaiseEvent verRegistro()
    End Sub


    Private Sub pbxSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx6Salir.Click, lbl6Salir.Click, pnx6Salir.Click
        Me.Close()
    End Sub


    Private Sub lblListas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblListas.Click, pnlListas.Click
        mdlPublicVars.frmPosX = Me.Location.X
        mdlPublicVars.frmPosY = Me.Location.Y
        mdlPublicVars.frmX = Me.Size.Width
        mdlPublicVars.frmY = frmMenuPrincipal.Size.Height
        Try
            permiso.PermisoDialogBarra(frmBarraLateralBaseIzquierda)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblOpciones.Click, pnlOpciones.Click

        mdlPublicVars.frmPosX = Me.Location.X
        mdlPublicVars.frmPosY = Me.Location.Y
        mdlPublicVars.frmX = Me.Size.Width
        mdlPublicVars.frmY = frmMenuPrincipal.Size.Height
        Try
            permiso.PermisoDialogBarra(frmBarraLateralBaseDerecha)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub grdDatos_GroupSummaryEvaluate(sender As Object, e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs) Handles grdDatos.GroupSummaryEvaluate

        Try
            fnResumen(e, "Cliente")
            fnResumen(e, "Nombre")
            fnResumen(e, "Negocio")
            fnResumen(e, "Proveedor")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub fnResumen(e As Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs, col As String)

        If e.SummaryItem.Name = col Then
            Dim contactsCount As Integer = e.Group.ItemCount
            Dim contactsInCanada As Integer = 0
            Dim suma As Double = 0
            For Each row As GridViewRowInfo In e.Group
                suma += row.Cells("Total").Value
            Next
            e.FormatString = [String].Format("{0} :    # {1}     " + mdlPublicVars.SimboloSuma.ToString + " {2: ###,###.#0} ", e.Value, contactsCount, suma)
        End If
    End Sub

    Public Sub cmbFiltroFecha_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbFiltroFecha.SelectedValueChanged

    End Sub
End Class