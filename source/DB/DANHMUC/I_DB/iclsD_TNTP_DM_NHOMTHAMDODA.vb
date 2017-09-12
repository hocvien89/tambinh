Public Interface ITNTP_DM_NHOMTHAMDODA

    Function SelectAll() As List(Of CM.TNTP_DM_NHOMTHAMDOEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_NhomThamdo As String) As CM.TNTP_DM_NHOMTHAMDOEntity

    Function Insert(ByVal obj As CM.TNTP_DM_NHOMTHAMDOEntity) As Boolean

	Function DeleteByID(ByVal uId_NhomThamdo AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_NHOMTHAMDOEntity) As Boolean

End Interface