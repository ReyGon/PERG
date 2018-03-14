Imports System.Linq
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Transactions

Public Class FrmBaseEspeciales
    Public tbl As New clsDevuelveTabla
    Public alerta As New bl_Alertas
    Public errores As New ErrorProviderExtended
    Public base As New clsBase

    Public verRegistro As Boolean = False

    Public Event Evento_Reporte()
    Public Event Evento_Ayuda()

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
    Public Event panel11()
    Public Event panel12()
    Public Event panel13()
    Public Event panel14()



    Dim contador As Integer = 0

    Private Sub FrmBaseEspeciales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        contador = contador + 1

        tbl.fnFechaActual_lb(txtFecha)
        tbl.fnHoraActual_lb(lbHora)
        lbTituloFrm.Text = Me.Text
        lbHora.Text = Format(Now, "hh:mm:ss tt")
        Me.Icon = frmMenuPrincipal.Icon

        If contador = 1 Then
            base.FnAsignaMetodoAbreviado(Me)

            'Asignar que el panel actual
            base.PanelActual = 0

            'agregar paneles para eventos.
            fnPaneles_agregar(Me)
        End If

        If verRegistro = True Then
            'se manda de parametro el formulario y el estado a deshabilitado.
            base.FnDeshabilitarHabilitarCampos(Me, False)
        End If
    End Sub

    Private Sub pbReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent Evento_Reporte()
    End Sub

    Private Sub tmrHora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHora.Tick
        Me.lbHora.Text = Format(Now, "hh:mm:ss tt")
    End Sub

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
                    'obtener el numero del panel
                    Dim NumeroPanelChar As String = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)
                    If NumeroPanelChar = "A" Then
                        numeroPanel = 10
                    ElseIf NumeroPanelChar = "B" Then
                        numeroPanel = 11
                    Else
                        numeroPanel = NumeroPanelChar
                    End If

                    If maximo <= numeroPanel Then
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
                    'obtener el numero del panel
                    Dim NumeroPanelChar As String = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)
                    If NumeroPanelChar = "A" Then
                        NumeroPanel = 10
                    ElseIf NumeroPanelChar = "B" Then
                        NumeroPanel = 11
                    ElseIf NumeroPanelChar = "C" Then
                        NumeroPanel = 12
                    Else
                        NumeroPanel = NumeroPanelChar
                    End If

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
                    Dim NumeroPanelChar As String = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)



                    If NumeroPanelChar = "A" Then
                        NumeroPanel = 10
                    ElseIf NumeroPanelChar = "B" Then
                        NumeroPanel = 11
                    ElseIf NumeroPanelChar = "C" Then
                        NumeroPanel = 12
                    ElseIf NumeroPanelChar = "D" Then
                        NumeroPanel = 13
                    ElseIf NumeroPanelChar = "E" Then
                        NumeroPanel = 14
                    Else
                        NumeroPanel = NumeroPanelChar
                    End If


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
                    'obtener el numero del panel
                    Dim NumeroPanelChar As String = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)

                    NumeroPanel = NumeroPanelChar

                    If NumeroPanelChar = "A" Then
                        NumeroPanel = 10
                    End If

                    If NumeroPanelChar = "B" Then
                        NumeroPanel = 11
                    End If

                    If NumeroPanelChar = "C" Then
                        NumeroPanel = 12
                    End If

                    If NumeroPanelChar = "D" Then
                        NumeroPanel = 13
                    End If

                    If NumeroPanelChar = "E" Then
                        NumeroPanel = 14
                    End If



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

    Private Sub FnPanel_agregarEventos(ByVal pnl As Panel)
        Dim iniciales As String
        Dim pbx As PictureBox
        Dim lbl As Label
        Dim nombre As String = pnl.Name
        Dim ctl
        Dim numero As Integer
        Dim numeroChar As String

        numeroChar = mdlPublicVars.tipoControlRango(nombre, 3, 1)
        If numeroChar = "A" Then
            numero = 10
        ElseIf numeroChar = "B" Then
            numero = 11
        ElseIf numeroChar = "C" Then
            numero = 12
        ElseIf numeroChar = "D" Then
            numero = 13
        ElseIf numeroChar = "E" Then
            numero = 14
        Else
            numero = numeroChar
        End If


        'agregar eventos de clic al panel
        Select Case numero
            Case 0
                AddHandler pnl.Click, AddressOf fnPanel0
            Case 1
                AddHandler pnl.Click, AddressOf fnPanel1
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
            Case 11
                AddHandler pnl.Click, AddressOf fnPanel11
            Case 12
                AddHandler pnl.Click, AddressOf fnPanel12
            Case 13
                AddHandler pnl.Click, AddressOf fnPanel13
            Case 14
                AddHandler pnl.Click, AddressOf fnPanel14
        End Select


        For Each ctl In pnl.Controls
            nombre = ctl.Name

            If nombre <> "" Then

                iniciales = mdlPublicVars.tipoControl(nombre)
                'obtener el numero del panel
                Dim NumeroPanelChar As String = mdlPublicVars.tipoControlRango(pnl.Name, 3, 1)
                If NumeroPanelChar = "A" Then
                    numero = 10
                ElseIf NumeroPanelChar = "B" Then
                    numero = 11
                ElseIf NumeroPanelChar = "C" Then
                    numero = 12
                ElseIf NumeroPanelChar = "D" Then
                    numero = 13
                ElseIf NumeroPanelChar = "E" Then
                    numero = 14
                Else
                    numero = NumeroPanelChar
                End If

                If IsNumeric(numero) Then


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
                        Case 11
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel11
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel11
                            End If
                        Case 12
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel12
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel12
                            End If
                        Case 13
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel13
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel13
                            End If

                        Case 14
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel14
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel14
                            End If
                        Case Else

                    End Select


                End If

            End If

        Next


    End Sub

    '---------------------------------------- Eventos de los paneles.
    Private Sub fnPanel0()
        RaiseEvent panel0()
    End Sub

    Private Sub fnPanel1()
        RaiseEvent panel1()
    End Sub

    Private Sub fnPanel2()
        RaiseEvent panel2()
    End Sub

    Private Sub fnPanel3()
        RaiseEvent panel3()
    End Sub

    Private Sub fnPanel4()
        RaiseEvent panel4()
    End Sub

    Private Sub fnPanel5()
        RaiseEvent panel5()
    End Sub

    Private Sub fnPanel6()
        RaiseEvent panel6()
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

    Private Sub fnPanel11()
        RaiseEvent panel11()
    End Sub

    Private Sub fnPanel12()
        RaiseEvent panel12()
    End Sub


    Private Sub fnPanel13()
        RaiseEvent panel13()
    End Sub

    Private Sub fnPanel14()
        RaiseEvent panel14()
    End Sub

    Private Sub paneles_leave_mouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'borrar el color de fondo de todos los paneles.
        Dim index
        For index = 0 To base.PanelContador - 1
            base.paneles(index).BackColor = Color.Navy
        Next

        DirectCast(sender, Panel).BackColor = Color.Green
        Dim numero As String = mdlPublicVars.tipoControlRango(DirectCast(sender, Panel).Name, 3, 1)
        If numero = "A" Then
            numero = 10
        ElseIf numero = "B" Then
            numero = 11
        ElseIf numero = "C" Then
            numero = 12
        ElseIf numero = "D" Then
            numero = 13
        ElseIf numero = "E" Then
            numero = 14
        End If

        If IsNumeric(numero) Then
            base.PanelActual = numero
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
                Case 11
                    fnPanel11()
                Case 12
                    fnPanel12()
                Case 13
                    fnPanel13()
                Case 14
                    fnPanel14()
            End Select
        End If

    End Sub

    '---------------------------------------FIN DE CONFIGURACION DE PANELES. --------------------------------------------

End Class
