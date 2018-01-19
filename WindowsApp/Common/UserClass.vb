Public Class UserClass
    Private m_UserSignId As String
    Private m_UserSignSn As String
    Private m_UserId As String

    Public Property UserId As String
        Get
            Return m_UserId
        End Get
        Set(value As String)
            m_UserId = value
        End Set
    End Property

    Public Property UserSignId As String
        Get
            Return m_UserSignId
        End Get
        Set(value As String)
            m_UserSignId = value
        End Set
    End Property

    Public Property UserSignSn As String
        Get
            Return m_UserSignSn
        End Get
        Set(value As String)
            m_UserSignSn = value
        End Set
    End Property
End Class
