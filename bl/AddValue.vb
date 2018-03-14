Public Class AddValue
    Private m_Display As String
    Private m_Value As Long
    Public Sub New(ByVal Display As String, ByVal Value As Long)
        m_Display = Display
        m_Value = Value

    End Sub
    Public ReadOnly Property Display() As String
        Get
            Return m_Display
        End Get

    End Property
    Public ReadOnly Property Value() As Long
        Get
            Return m_Value
        End Get

    End Property

End Class
