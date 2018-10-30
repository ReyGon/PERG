Public Class FrmBaseMenu

    'eventos de paneles
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

    Public paneles As Panel()
    Dim contador As Integer = 0
    Dim actual As Integer
    Public AjustarTamano As Boolean = False

    Public izquierda As Boolean = False
    Public derecha As Boolean = False
    Public contadorOpen As Integer = 0

    Private Sub FrmBaseMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            actual = 0
            contadorOpen = contadorOpen + 1

            mdlPublicVars.fnFormulario_colocarBarraTitulo(Me)

            If contadorOpen <= 1 Then
                fnPaneles_agregar()
            End If

            ''Panel 0 como predeterminado 
            Try
                Dim index
                For index = 0 To contador - 1
                    paneles(index).BackColor = Color.SteelBlue
                Next
                paneles(0).BackColor = Color.BlueViolet
                actual = 0
            Catch ex As Exception

            End Try

        Catch ex As Exception
        End Try

    End Sub


    Private Function fnPaneles_agregar()
        contador = 0
        Dim nombre As String
        Dim iniciales As String
        Dim ctl
        Dim pnl As Panel

        'guardar el numero de panel maximo.
        Dim maximo As Integer = 0
        Dim numeroPanel As Integer

        For Each ctl In Me.Controls
            nombre = ctl.Name

            If nombre <> "" Then
                iniciales = mdlPublicVars.tipoControl(nombre)
                If iniciales = "pnl" Then
                    'asignar el control panel al panel
                    pnl = ctl

                    'numero de panel
                    numeroPanel = mdlPublicVars.tipoControlRango(nombre, 3, 1)

                    If maximo < numeroPanel Then
                        maximo = numeroPanel
                        ReDim Preserve paneles(maximo + 1)
                    End If

                    'agregar panel al numero que le corresponde.
                    paneles(numeroPanel) = pnl

                    'If numeroPanel = 0 Then
                    '    paneles(0).Focus()
                    '    paneles(0).BackColor = Color.LightBlue
                    '    actual = 0
                    'End If
                    'incrementar el contador
                    contador = contador + 1
                    'asignar evenetos
                    'AddHandler pnl.Enter, AddressOf paneles_Enter_mouseEnter
                    'AddHandler pnl.MouseEnter, AddressOf paneles_Enter_mouseEnter
                    'AddHandler pnl.Leave, AddressOf paneles_leave_mouseLeave

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
            Case 11
                AddHandler pnl.Click, AddressOf fnPanel11
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
                        Case 11
                            If iniciales = "lbl" Then
                                lbl = ctl
                                AddHandler lbl.Click, AddressOf fnPanel11
                            ElseIf iniciales = "pbx" Then
                                pbx = ctl
                                AddHandler pbx.Click, AddressOf fnPanel11
                            End If

                        Case Else

                    End Select


                End If

            End If

        Next


    End Sub

    'eventos de los paneles.
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

    Private Sub paneles_leave_mouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'borrar el color de fondo de todos los paneles.
        Dim index
        For index = 0 To contador - 1
            paneles(index).BackColor = Color.SteelBlue
        Next

        DirectCast(sender, Panel).BackColor = Color.BlueViolet

        Dim numero As String = mdlPublicVars.tipoControlRango(DirectCast(sender, Panel).Name, 3, 1)
        If IsNumeric(numero) Then
            actual = numero
            'lblActual.Text = actual
        End If

    End Sub

    Private Sub paneles_abajo_arriba(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        'Dim nombre As String = DirectCast(sender, Panel).Name
        'actual = mdlPublicVars.tipoControlRango(nombre, 3, 1)
        'lblActual.Text = actual

        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If

        'si presiono la tecla para abajo, aumentar asignar foco a panel nuevo
        If e.KeyValue = Keys.Down Or e.KeyValue = Keys.Up Or e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right Then
            Dim residuo As Integer = contador Mod 2
            'limpiar los paneles
            Dim index
            For index = 0 To contador - 1
                paneles(index).BackColor = Color.SteelBlue
            Next

            If (actual + 1 < contador) And (e.KeyValue = Keys.Right) Then
                actual = actual + 1
            End If

            If (actual + 1 < contador) And (e.KeyValue = Keys.Down) Then
                actual = actual + Math.Truncate(contador / 2) + residuo '+ CInt(If(contador Mod 2 = 0, 0, 1))

                If actual >= contador Then
                    actual = actual - Math.Truncate(contador / 2) - residuo
                End If
            End If

            If (actual - 1 >= 0) And (e.KeyValue = Keys.Left) Then
                actual = actual - 1
            End If

            If (actual - 1 >= 0) And (e.KeyValue = Keys.Up) Then
                actual = (actual - Math.Truncate(contador / 2)) - residuo
                If actual < 0 Then
                    actual = (actual + Math.Truncate(contador / 2) + residuo)
                End If
            End If

            'pintar el panel Actual.

            paneles(actual).Focus()
            paneles(actual).BackColor = Color.BlueViolet


            'lblActual.Text = actual.ToString
        End If

        If e.KeyValue = Keys.Enter Then
            'Dim numero As Integer
            'numero = mdlPublicVars.tipoControlRango(nombre, 3, 1)

            '    'agregar eventos de clic al panel
            Select Case actual
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
            End Select
        End If

    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmBarraLateral_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Escape Then
            Me.Hide()
        End If
    End Sub

End Class
