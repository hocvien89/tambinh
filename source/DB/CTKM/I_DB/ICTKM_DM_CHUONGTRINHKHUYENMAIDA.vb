Public Interface ICTKM_DM_CHUONGTRINHKHUYENMAIDA

    Function SelectAll() As List(Of CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function Timkiem(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As System.Data.DataTable

    Function SelectByID(ByVal uId_ChuongtrinhKhuyenmai As String) As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity

    Function Insert(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As String

    Function DeleteByID(ByVal uId_ChuongtrinhKhuyenmai As String) As Boolean

    Function Update(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As Boolean

    Function Baocao(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal b_Loai As String) As System.Data.DataTable

End Interface