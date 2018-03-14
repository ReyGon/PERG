Imports Telerik.WinControls.UI

Public Class bl_Alertas
    Dim alert As New RadDesktopAlert
    Dim titulo As String = ""
    Public contenido As String = ""
    Public filtro As String = ""


    Public Sub fnConfiguracion(ByVal Titulo As String, ByVal contenido As String)
        alert.ScreenPosition = AlertScreenPosition.TopCenter

        alert.AutoClose = True
        'alert.FadeAnimationType = FadeAnimationType.FadeIn
        'alert.FadeAnimationType = FadeAnimationType.FadeOut
        alert.AutoCloseDelay = 4
        alert.FixedSize = New Size(CInt(Fix(500)), CInt(Fix(150)))
        alert.ShowCloseButton = True
        alert.ShowPinButton = False
        alert.ShowOptionsButton = False

        alert.CaptionText = "<html><br/><span style='font-size:17pt;margin:0 auto;'><color=Black>" + Titulo.ToString + "</span></html>"
        'alert.ContentText = "<html><br/><span><color=Blue>" + contenido + "</span></html>"
        alert.ContentText = "<html><br/><br/><span style=font-size:13pt;><color=Black>" + contenido + "</span></html>"
        'style="font-size:10pt;
        alert.Show()
    End Sub
    Public Sub fnErrorAutorizacionCredito()
        titulo = "Registro de Eventos"
        contenido = "Este usuario no puede autoriza crédito " + filtro.ToString
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnErrorContenido()
        titulo = "Registro de Eventos"
        'contenido = "Falta Informacion " + filtro.ToString
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnErrorRequiereInformacion()
        titulo = "Registro de Eventos"
        contenido = "Falta Informacion " + filtro.ToString
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnErrorRequiereCamposLlenos()
        titulo = "Registro de Eventos"
        contenido = "Requiere campos llenos"
        fnConfiguracion(titulo, contenido)
    End Sub


    Public Sub fnFaltanDatos()
        titulo = "Registro de Eventos"
        contenido = "Revise los datos requeridos..."
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnNoEditable()
        titulo = "Registro de Eventos"
        contenido = "Registro no se puede modificar, su estado no es editable"
        fnConfiguracion(titulo, contenido)
    End Sub
    Public Sub fnFinalizar()
        titulo = "Registro de Eventos"
        contenido = "Registro Finalizado Correctamente..."
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnGuardar()
        titulo = "Registro de Eventos"
        contenido = "Registro Guardado Correctamente..."
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnModificar()
        titulo = "Registro de Eventos"
        contenido = "Registro Modificado..."
        fnConfiguracion(titulo, contenido)
    End Sub
    Public Sub fnUtiliceModificar()
        titulo = "Registro de Eventos"
        contenido = "Error al Guardar, Utilice la opcion Modificar..."
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnUtiliceGuardar()
        titulo = "Registro de Eventos"
        contenido = "Error al Modificar, Utilice guardar porque es un registro nuevo"
        fnConfiguracion(titulo, contenido)
    End Sub
    Public Sub fnEliminar()
        titulo = "Registro de Eventos"
        contenido = "Registro Eliminado..."
        fnConfiguracion(titulo, contenido)
    End Sub


    Public Sub fnAnulado()
        titulo = "Registro de Eventos"
        contenido = "Registro Anulado..."
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnErrorMantenimiento()
        titulo = "Registro de Eventos"
        contenido = "Operacion Incorrecta"
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnError()
        titulo = "Registro de Eventos"
        contenido = "Error en la operacion"
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnErrorGuardar()
        titulo = "Registro de Eventos"
        contenido = "Error al Guardar"
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnErrorModificar()
        titulo = "Registro de Eventos"
        contenido = "Error al Guardar"
        fnConfiguracion(titulo, contenido)
    End Sub


    Public Sub fnErrorEliminar()
        titulo = "Registro de Eventos"
        contenido = "Error al Eliminar"
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnNuevo()
        titulo = "Registro de Eventos"
        contenido = "Nuevo Registro !!!"
        fnConfiguracion(titulo, contenido)
    End Sub

    Public Sub fnFaltantes()
        titulo = "Registro de Eventos"
        fnConfiguracion(titulo, contenido)
    End Sub
End Class
