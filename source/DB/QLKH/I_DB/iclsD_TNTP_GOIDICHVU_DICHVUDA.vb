Public Interface ITNTP_GOIDICHVU_DICHVUDA

    Function SelectAll(ByVal uId_Goidichvu As String) As System.Collections.Generic.List(Of CM.TNTP_GOIDICHVU_DICHVUEntity)

	Function SelectAllTable(ByVal uId_Goidichvu AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Goidichvu As String, ByVal uId_Dichvu As String) As CM.TNTP_GOIDICHVU_DICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_GOIDICHVU_DICHVUEntity) As Boolean

	Function DeleteByID(ByVal uId_Goidichvu AS String,ByVal uId_Dichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_GOIDICHVU_DICHVUEntity) As Boolean



End Interface