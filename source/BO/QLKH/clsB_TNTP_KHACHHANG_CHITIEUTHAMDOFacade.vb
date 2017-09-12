Public Class TNTP_KHACHHANG_CHITIEUTHAMDOFacade

    Dim ITNTP_KHACHHANG_CHITIEUTHAMDO As DB.ITNTP_KHACHHANG_CHITIEUTHAMDODA = New DB.TNTP_KHACHHANG_CHITIEUTHAMDODA

    Public Function SelectAll(ByVal uId_Khachhang As String) As List(Of CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity)
        Return ITNTP_KHACHHANG_CHITIEUTHAMDO.SelectAll(uId_Khachhang)
    End Function

	Public Function SelectAllTable(ByVal uId_Khachhang AS String) AS System.Data.DataTable
		Return ITNTP_KHACHHANG_CHITIEUTHAMDO.SelectAllTable(uId_Khachhang)
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) As Boolean
        Return ITNTP_KHACHHANG_CHITIEUTHAMDO.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) As Boolean
        Return ITNTP_KHACHHANG_CHITIEUTHAMDO.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Khachhang As String, ByVal uId_Chitieuthamdo As DateTime) As Boolean
        Return ITNTP_KHACHHANG_CHITIEUTHAMDO.DeleteByID(uId_Khachhang, uId_Chitieuthamdo)
    End Function

    Public Function SelectByID(ByVal uId_Khachhang As String, ByVal d_Ngaythamdo As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_CHITIEUTHAMDO.SelectByID(uId_Khachhang, d_Ngaythamdo)
    End Function

End Class