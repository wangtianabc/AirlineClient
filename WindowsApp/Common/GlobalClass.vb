Public Class GlobalClass
    Private Shared m_UserObj As UserClass

    Public Shared Property UserObj As UserClass
        Get
            Return m_UserObj
        End Get
        Set(value As UserClass)
            m_UserObj = value
        End Set
    End Property
End Class
