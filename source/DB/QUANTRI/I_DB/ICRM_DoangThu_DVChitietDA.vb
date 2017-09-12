Public Interface ICRM_DoangThu_DVChitietDA

    Function SelectByMonthBuffer(ByVal Ngay As DateTime) As System.Data.DataTable

    Function SelectByMonth(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

End Interface
