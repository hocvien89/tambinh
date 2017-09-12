Public Interface ITNTP_CHITIEUTHAMDODA

    Function SelectAll(ByVal uId_NhomThamdo As String) As System.Collections.Generic.List(Of CM.TNTP_CHITIEUTHAMDOEntity)

	Function SelectAllTable(ByVal uId_NhomThamdo AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Chitieuthamdo As String) As CM.TNTP_CHITIEUTHAMDOEntity

    Function Insert(ByVal obj As CM.TNTP_CHITIEUTHAMDOEntity) As Boolean

	Function DeleteByID(ByVal uId_Chitieuthamdo AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_CHITIEUTHAMDOEntity) As Boolean

End Interface