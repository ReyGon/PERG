Imports Telerik.WinControls
Imports System.IO

Public Class frmBusquedaArticuloCatalogoFiltro

#Region "LOAD"
    Private Sub frmBusquedaArticuloCatalogoFiltro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mdlPublicVars.comboActivarFiltro(cmbCarpeta)
        mdlPublicVars.comboActivarFiltro(cmbPagina)
        fnLlenarCombo()
    End Sub
#End Region

#Region "Funciones"
    'LLENAR COMBO
    Private Sub fnLlenarCombo()
        Try
            'Tabla para el combo de catalogos
            Dim cat As New DataTable
            cat.Columns.Add("Codigo")
            cat.Columns.Add("Nombre")

            'Carpetas 
            Dim catalogos As String() = Directory.GetDirectories(mdlPublicVars.BuscarArticulo_CarpetaCatalogo)
            Dim direccion As String()
            Dim imagen As String
            'Recorremos el arreglo con catalogos
            For i As Integer = 0 To UBound(catalogos)
                direccion = Split(catalogos(i), "\")
                imagen = direccion(UBound(direccion))

                If Not imagen.Equals("Thumbs") Then
                    cat.Rows.Add(catalogos(i), imagen)
                End If
            Next

            With cmbCarpeta
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = cat
            End With
        Catch ex As Exception
            RadMessageBox.Show(ex.Message, mdlPublicVars.nombreSistema, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
        End Try
    End Sub
#End Region

#Region "Eventos"
    'CAMBIO DE ELECCION EN EL COMBO DE CARPETAS
    Private Sub cmbCarpeta_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbCarpeta.SelectedValueChanged
        'Obtenemos las fotos del articulo
        Dim carpeta As String = CStr(cmbCarpeta.SelectedValue)

        'Obtenemos los archivos de las fotos
        If carpeta IsNot Nothing Then
            Dim fotos As New DataTable
            fotos.Columns.Add("Codigo")
            fotos.Columns.Add("Nombre")
            Dim archivos As String() = Directory.GetFiles(carpeta)
            Dim direccion As String()
            Dim imagen As String
            'Recorremos el arreglo con catalogos
            For i As Integer = 0 To UBound(archivos)
                direccion = Split(archivos(i), "\")
                imagen = direccion(UBound(direccion))
                fotos.Rows.Add(archivos(i), imagen.Substring(0, imagen.LastIndexOf(".")))
            Next

            With cmbPagina
                .DataSource = Nothing
                .ValueMember = "Codigo"
                .DisplayMember = "Nombre"
                .DataSource = fotos
            End With
        End If
    End Sub

    'FILTRAR 
    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        frmBuscarArticuloCatalogo.fnLlenarDatos(cmbPagina.SelectedValue)
        Me.Close()
    End Sub

    'SALIR 
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
#End Region

End Class
