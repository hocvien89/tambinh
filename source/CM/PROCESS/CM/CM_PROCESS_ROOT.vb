Public Class CM_PROCESS_ROOT
    Implements ICM_PROCESS_ROOT
    Private _Code As String
    Public Property Code() As String Implements ICM_PROCESS_ROOT.Code
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property
    Private _Process_Name As String
    Public Property Process_Name() As String Implements ICM_PROCESS_ROOT.Process_Name
        Get
            Return _Process_Name
        End Get
        Set(ByVal value As String)
            _Process_Name = value
        End Set
    End Property
End Class
