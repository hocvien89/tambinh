Public Interface IQLP_DM_GIUONGDA

    Function SelectAll() As List(Of CM.QLP_DM_GIUONGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Giuong As String) As CM.QLP_DM_GIUONGEntity

    Function Insert(ByVal obj As CM.QLP_DM_GIUONGEntity) As Boolean

    Function DeleteByID(ByVal uId_Giuong As String) As Boolean

    Function Update(ByVal obj As CM.QLP_DM_GIUONGEntity) As Boolean

    Function SelectGiuongtrongtheophong(uId_Phong As String) As System.Data.DataTable

    Function UpdateTrangThai(uId_Giuong As String, Status As Boolean) As Boolean

    Function SelectGiuongtheophong(uId_Phong As String) As System.Data.DataTable

    Function SelectInfoGiuong(uId_Giuong As String, d_time As DateTime) As DataTable
End Interface