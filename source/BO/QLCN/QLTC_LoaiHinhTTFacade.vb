Public Class QLTC_LoaiHinhTTFacade

    Dim IQLTC_LoaiHinhTT As DB.IQLTC_LoaiHinhTTDA = New DB.QLTC_LoaiHinhTTDA

    Public Function SelectAll() As List(Of CM.QLTC_LoaiHinhTTEntity)
        Return IQLTC_LoaiHinhTT.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IQLTC_LoaiHinhTT.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_LoaiHinhTTEntity) As Boolean
        Return IQLTC_LoaiHinhTT.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLTC_LoaiHinhTTEntity) As Boolean
        Return IQLTC_LoaiHinhTT.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_LoaiTT As String) As Boolean
        Return IQLTC_LoaiHinhTT.DeleteByID(uId_LoaiTT)
    End Function

    Public Function SelectByID(ByVal uId_LoaiTT As String) As CM.QLTC_LoaiHinhTTEntity
        Return IQLTC_LoaiHinhTT.SelectByID(uId_LoaiTT)
    End Function

End Class