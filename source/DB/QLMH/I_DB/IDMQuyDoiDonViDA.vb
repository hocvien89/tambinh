Public Interface IDMQuyDoiDonViDA

    Function SelectAll() As List(Of CM.DMQuyDoiDonViEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal MaVatTu As String) As CM.DMQuyDoiDonViEntity

    Function Insert(ByVal obj As CM.DMQuyDoiDonViEntity) As Boolean

    Function DeleteByID(ByVal MaVatTu As String) As Boolean

    Function Update(ByVal obj As CM.DMQuyDoiDonViEntity) As Boolean

    Function LoadDSDonViTheoVatTu(ByVal MaVatTu As String) As System.Data.DataTable

    Function LayGiaTriQuyDoi(ByVal MaVatTu As String, ByVal MaDonVi As String) As Integer

    'Xuan hieu 29102014
    Function Selectcheck(Mavattu As String) As Boolean
End Interface