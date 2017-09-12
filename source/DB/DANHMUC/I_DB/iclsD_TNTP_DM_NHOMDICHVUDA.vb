Public Interface ITNTP_DM_NHOMDICHVUDA

    Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.TNTP_DM_NHOMDICHVUEntity)

	Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Nhomdichvu As String) As CM.TNTP_DM_NHOMDICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_DM_NHOMDICHVUEntity) As Boolean

	Function DeleteByID(ByVal uId_Nhomdichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_NHOMDICHVUEntity) As Boolean

    Function SelectByname(tencuahang As String) As String
End Interface