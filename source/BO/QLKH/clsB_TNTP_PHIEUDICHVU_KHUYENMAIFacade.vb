Public Class TNTP_PHIEUDICHVU_KHUYENMAIFacade

    Dim ITNTP_PHIEUDICHVU_KHUYENMAI As DB.ITNTP_PHIEUDICHVU_KHUYENMAIDA = New DB.TNTP_PHIEUDICHVU_KHUYENMAIDA

    Public Function SelectAll() As List(Of CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity)
        Return ITNTP_PHIEUDICHVU_KHUYENMAI.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_PHIEUDICHVU_KHUYENMAI.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_KHUYENMAI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_KHUYENMAI.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Phieudichvu AS String,ByVal uId_DM_Khuyenmai AS String) AS Boolean
		Return ITNTP_PHIEUDICHVU_KHUYENMAI.DeleteByID(uId_Phieudichvu,uId_DM_Khuyenmai)
	End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String, ByVal uId_DM_Khuyenmai As String) As CM.TNTP_PHIEUDICHVU_KHUYENMAIEntity
        Return ITNTP_PHIEUDICHVU_KHUYENMAI.SelectByID(uId_Phieudichvu, uId_DM_Khuyenmai)
    End Function

End Class