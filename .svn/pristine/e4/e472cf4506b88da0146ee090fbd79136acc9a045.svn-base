Imports System.Transactions
Imports System.Linq

Public Class frmCrearEmpresa


    Private Sub fnGuardar()
        Dim bd As New clsBaseDatos
        Dim nombreBd As String = "dsi_pos_" & txtNombre.Text
        If bd.fnVerificarBD(nombreBd) = True Then
            alerta.contenido = "Base de datos ya existe"
            alerta.fnErrorContenido()
            Exit Sub
        End If

        If bd.fnCrearBD(nombreBd) = False Then
            alerta.contenido = "No pudo crear la Base de Datos"
            alerta.fnErrorContenido()
            Exit Sub
        End If

        If bd.fnRestaurarBD(nombreBd) = False Then
            alerta.contenido = "No pudo Restaurar la Base de Datos"
            alerta.fnErrorContenido()
            Exit Sub
        End If

        mdlPublicVars.bd = nombreBd
        mdlPublicVars.conexionEntity()

        Dim fecha As DateTime = fnFecha_horaServidor()
        Dim hora As String = fnHoraServidor()
        Dim success As Boolean = True
        Dim errContenido As String = ""

        Using transaction As New TransactionScope

            'inicio de excepcion
            Try

                Dim m As tblEmpresa = (From x In ctx.tblEmpresas Where x.idEmpresa = 2 Select x).FirstOrDefault

                m.nombre = txtNombre.Text
                m.direccion = txtDireccion.Text
                m.telefono = txtTelefono.Text
                m.habilitada = True
                m.codigoPostal = txtCodigoPostal.Text
                m.nit = txtNit.Text
                m.idmunicipio = 1
                m.responsable = txtResponsable.Text

                ctx.SaveChanges()
                'paso 8, completar la transaccion.
                transaction.Complete()


            Catch ex As System.Data.EntityException
                success = False
            Catch ex As Exception
                success = False
                ' Handle errors and deadlocks here and retry if needed. 
                ' Allow an UpdateException to pass through and 
                ' retry, otherwise stop the execution. 
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("An error occured. " & "The operation cannot be retried.") + ex.Message)
                    alerta.fnErrorGuardar()
                    Exit Try
                    ' If we get to this point, the operation will be retried. 
                End If
            End Try
        End Using


        If success = True Then
            ctx.AcceptAllChanges()
            alerta.fnGuardar()

        Else
            alerta.fnErrorGuardar()
            Console.WriteLine("La operacion no pudo ser completada")
        End If

    End Sub




    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        fnGuardar()
    End Sub
End Class
