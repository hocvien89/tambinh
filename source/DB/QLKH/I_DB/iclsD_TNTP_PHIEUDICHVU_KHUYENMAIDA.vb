Public Interface ITNTP_PHIEUDICHVU_KHUYENMAIDA

    Function SelectAll() As List(Of CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Phieudichvu As String, ByVal uId_DM_Khuyenmai As String) As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity

    Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) As Boolean

	Function DeleteByID(ByVal uId_Phieudichvu AS String,ByVal uId_DM_Khuyenmai AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) As Boolean

End Interface