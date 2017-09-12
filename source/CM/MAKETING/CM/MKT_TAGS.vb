Public Class MKT_TAGS
    Implements IMKT_TAGS
    Private _MaLoai As Integer
    Private _nv_TagName_vn As String
    Private _uId_Tags As String

    Public Property MaLoai() As Integer Implements IMKT_TAGS.MaLoai
        Get
            Return _MaLoai
        End Get
        Set(ByVal value As Integer)
            _MaLoai = value
        End Set
    End Property

    Public Property nv_TagName_vn() As String Implements IMKT_TAGS.nv_TagName_vn
        Get
            Return _nv_TagName_vn
        End Get
        Set(ByVal value As String)
            _nv_TagName_vn = value
        End Set
    End Property

    Public Property uId_Tags() As String Implements IMKT_TAGS.uId_Tags
        Get
            Return _uId_Tags
        End Get
        Set(ByVal value As String)
            _uId_Tags = value
        End Set
    End Property
End Class
