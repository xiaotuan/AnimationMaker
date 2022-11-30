Module Animation

    Private m_Directory As String
    Private m_Pictures As ArrayList

    Public Property Directory() As String
        Get
            Return m_Directory
        End Get
        Set(value As String)
            m_Directory = value
        End Set
    End Property

    Public Property Pictures As ArrayList
        Get
            Return m_Pictures
        End Get
        Set(value As ArrayList)
            m_Pictures = value
        End Set
    End Property
End Module
