Public Class TNTP_CHITIEUTHAMDOFacade

    Dim ITNTP_CHITIEUTHAMDO As DB.ITNTP_CHITIEUTHAMDODA = New DB.TNTP_CHITIEUTHAMDODA

    Public Function SelectAll(ByVal uId_NhomThamdo As String) As List(Of CM.TNTP_CHITIEUTHAMDOEntity)
        Return ITNTP_CHITIEUTHAMDO.SelectAll(uId_NhomThamdo)
    End Function

	Public Function SelectAllTable(ByVal uId_NhomThamdo AS String) AS System.Data.DataTable
		Return ITNTP_CHITIEUTHAMDO.SelectAllTable(uId_NhomThamdo)
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_CHITIEUTHAMDOEntity) As Boolean
        Return ITNTP_CHITIEUTHAMDO.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_CHITIEUTHAMDOEntity) As Boolean
        Return ITNTP_CHITIEUTHAMDO.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Chitieuthamdo AS String) AS Boolean
		Return ITNTP_CHITIEUTHAMDO.DeleteByID(uId_Chitieuthamdo)
	End Function

    Public Function SelectByID(ByVal uId_Chitieuthamdo As String) As CM.TNTP_CHITIEUTHAMDOEntity
        Return ITNTP_CHITIEUTHAMDO.SelectByID(uId_Chitieuthamdo)
    End Function

End Class