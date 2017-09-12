Public Interface ITNTP_DM_KHUYENMAIDA

    Function SelectAll() As List(Of CM.TNTP_DM_KHUYENMAIEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectAllKhachHangKM(ByVal uId_DM_Khuyenmai As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_DM_Khuyenmai As String) As CM.TNTP_DM_KHUYENMAIEntity

    Function Insert(ByVal obj As CM.TNTP_DM_KHUYENMAIEntity) As Boolean

	Function DeleteByID(ByVal uId_DM_Khuyenmai AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_KHUYENMAIEntity) As Boolean

End Interface