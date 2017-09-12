Public Class CM_PROCESS_DETAIL
    Implements ICM_PROCESS_DETAIL
    Private _ID As Integer
    Public Property ID() As Integer Implements ICM_PROCESS_DETAIL.ID
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Private _uId_Phongban As String
    Public Property uId_Phongban() As String Implements ICM_PROCESS_DETAIL.uId_Phongban
        Get
            Return _uId_Phongban
        End Get
        Set(ByVal value As String)
            _uId_Phongban = value
        End Set
    End Property
    Private _uId_Step As String
    Public Property uId_Step() As String Implements ICM_PROCESS_DETAIL.uId_Step
        Get
            Return _uId_Step
        End Get
        Set(ByVal value As String)
            _uId_Step = value
        End Set
    End Property
    Private _RootId As String
    Public Property RootId() As String Implements ICM_PROCESS_DETAIL.RootId
        Get
            Return _RootId
        End Get
        Set(ByVal value As String)
            _RootId = value
        End Set
    End Property
End Class
