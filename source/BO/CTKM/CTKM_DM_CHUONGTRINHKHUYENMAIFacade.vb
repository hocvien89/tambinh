Public Class CTKM_DM_CHUONGTRINHKHUYENMAIFacade

    Dim ICTKM_DM_CHUONGTRINHKHUYENMAI As DB.ICTKM_DM_CHUONGTRINHKHUYENMAIDA = New DB.CTKM_DM_CHUONGTRINHKHUYENMAIDA

    Public Function SelectAll() As List(Of CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity)
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.SelectAllTable()
    End Function
    Public Function Timkiem(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As System.Data.DataTable
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.Timkiem(obj)
    End Function
    Public Function Insert(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As String
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity) As Boolean
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_ChuongtrinhKhuyenmai As String) As Boolean
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.DeleteByID(uId_ChuongtrinhKhuyenmai)
    End Function

    Public Function SelectByID(ByVal uId_ChuongtrinhKhuyenmai As String) As CM.CTKM_DM_CHUONGTRINHKHUYENMAIEntity
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.SelectByID(uId_ChuongtrinhKhuyenmai)
    End Function
    Public Function Baocao(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal b_Loai As String) As System.Data.DataTable
        Return ICTKM_DM_CHUONGTRINHKHUYENMAI.Baocao(uId_ChuongtrinhKhuyenmai, Tungay, Denngay, b_Loai)
    End Function
End Class