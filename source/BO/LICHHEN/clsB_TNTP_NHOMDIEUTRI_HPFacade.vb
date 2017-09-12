Public Class TNTP_NHOMDIEUTRI_HPFacade

    Dim ITNTP_NHOMDIEUTRI_HP As DB.ITNTP_NHOMDIEUTRI_HPDA = New DB.TNTP_NHOMDIEUTRI_HPDA

    Public Function SelectAll(ByVal uId_Khachhang As String, ByVal uId_Nhomdichvu As String) As List(Of CM.TNTP_NHOMDIEUTRI_HPEntity)
        Return ITNTP_NHOMDIEUTRI_HP.SelectAll(uId_Khachhang, uId_Nhomdichvu)
    End Function

	Public Function SelectAllTable(ByVal uId_Khachhang AS String,ByVal uId_Nhomdichvu AS String) AS System.Data.DataTable
		Return ITNTP_NHOMDIEUTRI_HP.SelectAllTable(uId_Khachhang,uId_Nhomdichvu)
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_NHOMDIEUTRI_HPEntity) As Boolean
        Return ITNTP_NHOMDIEUTRI_HP.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_NHOMDIEUTRI_HPEntity) As Boolean
        Return ITNTP_NHOMDIEUTRI_HP.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Nhomdieutri AS String) AS Boolean
		Return ITNTP_NHOMDIEUTRI_HP.DeleteByID(uId_Nhomdieutri)
	End Function

    Public Function SelectByID(ByVal uId_Nhomdieutri As String) As CM.TNTP_NHOMDIEUTRI_HPEntity
        Return ITNTP_NHOMDIEUTRI_HP.SelectByID(uId_Nhomdieutri)
    End Function

End Class