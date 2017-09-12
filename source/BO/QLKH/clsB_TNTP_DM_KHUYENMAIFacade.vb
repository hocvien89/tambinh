Public Class TNTP_DM_KHUYENMAIFacade

    Dim ITNTP_DM_KHUYENMAI As DB.ITNTP_DM_KHUYENMAIDA = New DB.TNTP_DM_KHUYENMAIDA

    Public Function SelectAll() As List(Of CM.TNTP_DM_KHUYENMAIEntity)
        Return ITNTP_DM_KHUYENMAI.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_DM_KHUYENMAI.SelectAllTable()
	End Function

    Public Function SelectAllKhachHangKM(ByVal uId_DM_Khuyenmai As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ITNTP_DM_KHUYENMAI.SelectAllKhachHangKM(uId_DM_Khuyenmai, TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_KHUYENMAIEntity) As Boolean
        Return ITNTP_DM_KHUYENMAI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_KHUYENMAIEntity) As Boolean
        Return ITNTP_DM_KHUYENMAI.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_DM_Khuyenmai AS String) AS Boolean
		Return ITNTP_DM_KHUYENMAI.DeleteByID(uId_DM_Khuyenmai)
	End Function

    Public Function SelectByID(ByVal uId_DM_Khuyenmai As String) As CM.TNTP_DM_KHUYENMAIEntity
        Return ITNTP_DM_KHUYENMAI.SelectByID(uId_DM_Khuyenmai)
    End Function

End Class