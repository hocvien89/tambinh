Public Class CTKM_LOAIGIAMGIAFacade

    Dim ICTKM_LOAIGIAMGIA As DB.ICTKM_LOAIGIAMGIADA = New DB.CTKM_LOAIGIAMGIADA

    Public Function SelectAll() As List(Of CM.CTKM_LOAIGIAMGIAEntity)
        Return ICTKM_LOAIGIAMGIA.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ICTKM_LOAIGIAMGIA.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.CTKM_LOAIGIAMGIAEntity) As Boolean
        Return ICTKM_LOAIGIAMGIA.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CTKM_LOAIGIAMGIAEntity) As Boolean
        Return ICTKM_LOAIGIAMGIA.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_LoaiGiamgia As String) As Boolean
        Return ICTKM_LOAIGIAMGIA.DeleteByID(uId_LoaiGiamgia)
    End Function

    Public Function SelectByID(ByVal uId_LoaiGiamgia As String) As CM.CTKM_LOAIGIAMGIAEntity
        Return ICTKM_LOAIGIAMGIA.SelectByID(uId_LoaiGiamgia)
    End Function

End Class