Public Class CTKM_DICHVU_CHITIETFacade

    Dim ICTKM_DICHVU_CHITIET As DB.ICTKM_DICHVU_CHITIETDA = New DB.CTKM_DICHVU_CHITIETDA

    Public Function SelectAll() As List(Of CM.CTKM_DICHVU_CHITIETEntity)
        Return ICTKM_DICHVU_CHITIET.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal strTukhoa As String) As System.Data.DataTable
        Return ICTKM_DICHVU_CHITIET.SelectAllTable(uId_ChuongtrinhKhuyenmai, strTukhoa)
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_DICHVU_CHITIETEntity) As Boolean
        Return ICTKM_DICHVU_CHITIET.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CTKM_DICHVU_CHITIETEntity) As Boolean
        Return ICTKM_DICHVU_CHITIET.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_CTKM_Chitiet As String) As Boolean
        Return ICTKM_DICHVU_CHITIET.DeleteByID(uId_CTKM_Chitiet)
    End Function

    Public Function SelectByID(ByVal uId_CTKM_Chitiet As String) As CM.CTKM_DICHVU_CHITIETEntity
        Return ICTKM_DICHVU_CHITIET.SelectByID(uId_CTKM_Chitiet)
    End Function

End Class