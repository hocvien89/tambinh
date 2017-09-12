Public Interface ITNTP_KHACHHANG_CHITIEUTHAMDODA

    Function SelectAll(ByVal uId_Khachhang As String) As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity)

	Function SelectAllTable(ByVal uId_Khachhang AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Khachhang As String, ByVal d_Ngaythamdo As DateTime) As System.Data.DataTable

    Function Insert(ByVal obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) As Boolean

    Function DeleteByID(ByVal uId_Khachhang As String, ByVal uId_Chitieuthamdo As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_KHACHHANG_CHITIEUTHAMDOEntity) As Boolean

End Interface