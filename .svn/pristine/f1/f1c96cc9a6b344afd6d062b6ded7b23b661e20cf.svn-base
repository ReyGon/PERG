Imports System.Linq

Public Class frmBitacoraConcepto
    Public ver As Boolean
    Public superSearchId As Integer = 0

    Private _idCliente As Integer
    Private _idVendedor As Integer
    Private _fecha As DateTime
    Private _proveedor As Boolean

    Public Property idCliente() As Integer
        Get
            idCliente = _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property

    Public Property idVendedor() As Integer
        Get
            idVendedor = _idVendedor
        End Get
        Set(ByVal value As Integer)
            _idVendedor = value
        End Set
    End Property

    Public Property fecha() As DateTime
        Get
            fecha = _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Property proveedor() As Boolean
        Get
            proveedor = _proveedor
        End Get
        Set(ByVal value As Boolean)
            _proveedor = value
        End Set
    End Property

    Private Sub fnLlenarBitacora()
        Dim bitacora As tblBitacora = (From x In ctx.tblBitacoras Where x.IdBitacora = superSearchId Select x).FirstOrDefault
        If bitacora.proveedor > 0 Then
            lblCP.Text = (From x In ctx.tblProveedors Where x.idProveedor = bitacora.proveedor
                          Select x.negocio).FirstOrDefault
        Else
            lblCP.Text = (From x In ctx.tblClientes Where x.idCliente = bitacora.cliente
                          Select x.Negocio).FirstOrDefault
        End If

        lblConcepto.Text = bitacora.tblBitacoraCategoria.Nombre
        lblObservacion.Text = bitacora.observacion
        If bitacora.recordatorio = True Then
            chkResponsables.Checked = bitacora.recordatorio
            dtpFechaRecordatorio.Text = bitacora.programacion

            'Llena la lista de responsables
            Dim vendedor As String = ""
            Dim index
            Dim contador As Integer = 0

            'Llenamos la lista de responsables
            For index = 0 To Me.lstResponsables.Items.Count - 1
                contador = 0
                vendedor = lstResponsables.Items(index).ToString

                Dim consulta = (From x In ctx.tblBitacoraResponsables Where x.idbitacora = superSearchId And x.tblVendedor.nombre = vendedor Select x).FirstOrDefault

                Dim chkstate As CheckState
                If consulta Is Nothing Then
                    chkstate = CheckState.Unchecked
                Else
                    chkstate = CheckState.Checked
                End If

                lstResponsables.SetItemCheckState(index, chkstate)
            Next

            Me.grdSoluciones.Rows.Clear()

            'Llenamos el grid de soluciones
            Dim soluciones As List(Of tblBitacoraSolucione) = (From x In ctx.tblBitacoraSoluciones Where x.bitacora = superSearchId Select x).ToList
            Dim solucion As New tblBitacoraSolucione

            For Each solucion In soluciones
                Dim fila As String()
                fila = {solucion.usuario, solucion.tblUsuario.nombre, solucion.solucion, solucion.codigo}
                grdSoluciones.Rows.Add(fila)
            Next

            'Establecemos si ha sido cerrado o solucionada.
            chkSolucionado.Checked = bitacora.cerrado
            'Si ha sido solucionado se bloquean los controles
            If bitacora.cerrado = True Then
                fnBloquear()
            End If
        End If
        lstResponsables.Enabled = False
    End Sub

    Private Sub fnBloquear()
        Me.chkResponsables.Enabled = False
        Me.chkSolucionado.Enabled = False
        Me.dtpFechaRecordatorio.Enabled = False
        Me.lblObservacion.Enabled = False
    End Sub

    Private Sub frmBitacoraConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grdSoluciones.Rows.Clear()
        mdlPublicVars.fnFormatoGridEspeciales(grdSoluciones)

        If ver = True Then
            fnLlenarBitacora()
            fnBloquear()
        End If
    End Sub

    'Funcion utilizada para salir del grid
    Private Sub fnSalir() Handles Me.panel0
        Me.Close()
    End Sub
End Class
