Public Class MKT_LOAITAGFacade
    Dim IMKT_LoaiTags As DB.IMKT_LOAITAGSDA = New DB.MKT_LOAITAGDA

    Public Function Insert(ByVal obj As CM.MKT_LOAITAGSEntity) As Boolean
        Return IMKT_LoaiTags.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_LOAITAGSEntity) As Boolean
        Return IMKT_LoaiTags.Update(obj)
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_LoaiTags.SelectAll()
    End Function

    Public Function SelectById(ByVal Id_Loaitag As Integer) As CM.MKT_LOAITAGSEntity
        Return IMKT_LoaiTags.SelectById(Id_Loaitag)
    End Function
    Public Function DeleteByID(ByVal i_Thutu As Integer) As Boolean
        Return IMKT_LoaiTags.DeleteByID(i_Thutu)
    End Function
End Class
