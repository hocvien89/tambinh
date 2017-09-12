Public Class TNTP_KHACHHANG_THEFacade

    Dim ITNTP_KHACHHANG_THE As DB.ITNTP_KHACHHANG_THEDA = New DB.TNTP_KHACHHANG_THEDA

    Public Function SelectAll() As List(Of CM.TNTP_KHACHHANG_THEEntity)
        Return ITNTP_KHACHHANG_THE.SelectAll()
    End Function

    Public Function SelectAllKH_KM(ByVal uId_Khachhang As String, ByVal v_MaKM As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_THE.SelectAllKH_KM(uId_Khachhang, v_MaKM)
    End Function

    Public Function SelectTheKHTichluy(ByVal uId_Khachhang As String, ByVal v_MaKM As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_THE.SelectTheKHTichluy(uId_Khachhang, v_MaKM)
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String, ByVal DK As Int32) As System.Data.DataTable
        Return ITNTP_KHACHHANG_THE.SelectAllTable(uId_Khachhang, DK)
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_THE.SelectAllTable(uId_Cuahang)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As String
        Return ITNTP_KHACHHANG_THE.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As Boolean
        Return ITNTP_KHACHHANG_THE.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_The AS String) AS Boolean
		Return ITNTP_KHACHHANG_THE.DeleteByID(uId_The)
	End Function

    Public Function SelectByID(ByVal uId_The As String) As CM.TNTP_KHACHHANG_THEEntity
        Return ITNTP_KHACHHANG_THE.SelectByID(uId_The)
    End Function

    Public Function ThanhToan(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As Boolean
        Return ITNTP_KHACHHANG_THE.ThanhToan(obj)
    End Function

    Public Function SelectAllTable_DS_TheHetHan(ByVal DK As Integer) As System.Data.DataTable
        Return ITNTP_KHACHHANG_THE.SelectAllTable_DS_TheHetHan(DK)
    End Function
End Class