Public Class CUAHANG_NHANVIENFacade

    Dim ICUAHANG_NHANVIEN As DB.ICUAHANG_NHANVIENDA = New DB.CUAHANG_NHANVIENDA

    Public Function SelectAll() As List(Of CM.CUAHANG_NHANVIENEntity)
        Return ICUAHANG_NHANVIEN.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ICUAHANG_NHANVIEN.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.CUAHANG_NHANVIENEntity) As Boolean
        Return ICUAHANG_NHANVIEN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CUAHANG_NHANVIENEntity) As Boolean
        Return ICUAHANG_NHANVIEN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Cuahang_Nhanvien As String) As Boolean
        Return ICUAHANG_NHANVIEN.DeleteByID(uId_Cuahang_Nhanvien)
    End Function

    Public Function SelectByID(ByVal uId_Cuahang_Nhanvien As String) As CM.CUAHANG_NHANVIENEntity
        Return ICUAHANG_NHANVIEN.SelectByID(uId_Cuahang_Nhanvien)
    End Function

End Class