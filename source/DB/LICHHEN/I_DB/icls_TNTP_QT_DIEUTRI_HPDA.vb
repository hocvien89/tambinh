Public Interface ITNTP_QT_DIEUTRI_HPDA

    Function SelectAll(ByVal uId_Khachhang As String) As System.Collections.Generic.List(Of CM.TNTP_QT_DIEUTRI_HPEntity)

    Function SelectAllTable(ByVal uId_Khachhang As String, ByVal uId_Nhomdichvu As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_QT_Dieutri_HP As String) As CM.TNTP_QT_DIEUTRI_HPEntity

    Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_HPEntity) As Boolean

	Function DeleteByID(ByVal uId_QT_Dieutri_HP AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_QT_DIEUTRI_HPEntity) As Boolean

    Function SelectByKH_Ngay(ByVal uId_Khachhang As String, ByVal d_Ngay As DateTime) As System.Data.DataTable

End Interface