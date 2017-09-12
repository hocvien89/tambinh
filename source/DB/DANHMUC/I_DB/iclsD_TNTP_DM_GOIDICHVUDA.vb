Public Interface ITNTP_DM_GOIDICHVUDA

    Function SelectAll() As List(Of CM.TNTP_DM_GOIDICHVUEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Goidichvu As String) As CM.TNTP_DM_GOIDICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_DM_GOIDICHVUEntity) As Boolean

	Function DeleteByID(ByVal uId_Goidichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_GOIDICHVUEntity) As Boolean

    Function SelectAllTable_List_Goi_The_Dichvu(ByVal vType As String, ByVal uId_Nhomdichvu As String) As System.Data.DataTable

    Function SelectAllTable_ListLoai_Goi_The_Dichvu(ByVal vType As String) As System.Data.DataTable

End Interface