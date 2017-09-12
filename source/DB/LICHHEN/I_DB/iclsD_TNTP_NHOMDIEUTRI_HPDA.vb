Public Interface ITNTP_NHOMDIEUTRI_HPDA

    Function SelectAll(ByVal uId_Khachhang As String, ByVal uId_Nhomdichvu As String) As System.Collections.Generic.List(Of CM.TNTP_NHOMDIEUTRI_HPEntity)

	Function SelectAllTable(ByVal uId_Khachhang AS String,ByVal uId_Nhomdichvu AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Nhomdieutri As String) As CM.TNTP_NHOMDIEUTRI_HPEntity

    Function Insert(ByVal obj As CM.TNTP_NHOMDIEUTRI_HPEntity) As Boolean

	Function DeleteByID(ByVal uId_Nhomdieutri AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_NHOMDIEUTRI_HPEntity) As Boolean

End Interface