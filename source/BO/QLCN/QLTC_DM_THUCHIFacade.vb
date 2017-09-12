Public Class QLTC_DM_THUCHIFacade

    Dim IQLTC_DM_THUCHI As DB.IQLTC_DM_THUCHIDA = New DB.QLTC_DM_THUCHIDA

    Public Function SelectAll() As List(Of CM.QLTC_DM_THUCHIEntity)
        Return IQLTC_DM_THUCHI.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IQLTC_DM_THUCHI.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_DM_THUCHIEntity) As Boolean
        Return IQLTC_DM_THUCHI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLTC_DM_THUCHIEntity) As Boolean
        Return IQLTC_DM_THUCHI.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Thuchi As String) As Boolean
        Return IQLTC_DM_THUCHI.DeleteByID(uId_Thuchi)
    End Function

    Public Function SelectByTen(ByVal Tenthuchi As String) As CM.QLTC_DM_THUCHIEntity
        Return IQLTC_DM_THUCHI.SelectByTen(Tenthuchi)
    End Function
    Public Function SelectByID(ByVal uId_Thuchi As String) As CM.QLTC_DM_THUCHIEntity
        Return IQLTC_DM_THUCHI.SelectByID(uId_Thuchi)
    End Function

    Public Function SelectLoai(ByVal loai As Boolean) As System.Data.DataTable
        Return IQLTC_DM_THUCHI.SelectLoai(loai)
    End Function

   
End Class