Public Class CTKM_MATHANG_CHITIETFacade

    Dim ICTKM_MATHANG_CHITIET As DB.ICTKM_MATHANG_CHITIETDA = New DB.CTKM_MATHANG_CHITIETDA

    Public Function SelectAll() As List(Of CM.CTKM_MATHANG_CHITIETEntity)
        Return ICTKM_MATHANG_CHITIET.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal strTukhoa As String) As System.Data.DataTable
        Return ICTKM_MATHANG_CHITIET.SelectAllTable(uId_ChuongtrinhKhuyenmai, strTukhoa)
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_MATHANG_CHITIETEntity) As Boolean
        Return ICTKM_MATHANG_CHITIET.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CTKM_MATHANG_CHITIETEntity) As Boolean
        Return ICTKM_MATHANG_CHITIET.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_CTKM_Chitiet As String) As Boolean
        Return ICTKM_MATHANG_CHITIET.DeleteByID(uId_CTKM_Chitiet)
    End Function

    Public Function SelectByID(ByVal uId_CTKM_Chitiet As String) As CM.CTKM_MATHANG_CHITIETEntity
        Return ICTKM_MATHANG_CHITIET.SelectByID(uId_CTKM_Chitiet)
    End Function

End Class