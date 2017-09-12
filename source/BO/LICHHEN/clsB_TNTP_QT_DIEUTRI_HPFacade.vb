Public Class TNTP_QT_DIEUTRI_HPFacade

    Dim ITNTP_QT_DIEUTRI_HP As DB.ITNTP_QT_DIEUTRI_HPDA = New DB.TNTP_QT_DIEUTRI_HPDA

    Public Function SelectAll(ByVal uId_Khachhang As String) As List(Of CM.TNTP_QT_DIEUTRI_HPEntity)
        Return ITNTP_QT_DIEUTRI_HP.SelectAll(uId_Khachhang)
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String, ByVal uId_Nhomdichvu As String) As System.Data.DataTable
        Return ITNTP_QT_DIEUTRI_HP.SelectAllTable(uId_Khachhang, uId_Nhomdichvu)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_HPEntity) As Boolean
        Return ITNTP_QT_DIEUTRI_HP.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_QT_DIEUTRI_HPEntity) As Boolean
        Return ITNTP_QT_DIEUTRI_HP.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_QT_Dieutri_HP AS String) AS Boolean
		Return ITNTP_QT_DIEUTRI_HP.DeleteByID(uId_QT_Dieutri_HP)
	End Function

    Public Function SelectByID(ByVal uId_QT_Dieutri_HP As String) As CM.TNTP_QT_DIEUTRI_HPEntity
        Return ITNTP_QT_DIEUTRI_HP.SelectByID(uId_QT_Dieutri_HP)
    End Function

    Public Function SelectByKH_Ngay(ByVal uId_Khachhang As String, ByVal d_Ngay As DateTime) As System.Data.DataTable
        Return ITNTP_QT_DIEUTRI_HP.SelectByKH_Ngay(uId_Khachhang, d_Ngay)
    End Function

End Class