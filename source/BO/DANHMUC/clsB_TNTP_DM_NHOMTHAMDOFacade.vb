Public Class TNTP_DM_NHOMTHAMDOFacade

    Dim ITNTP_DM_NHOMTHAMDO As DB.ITNTP_DM_NHOMTHAMDODA = New DB.TNTP_DM_NHOMTHAMDODA

    Public Function SelectAll() As List(Of CM.TNTP_DM_NHOMTHAMDOEntity)
        Return ITNTP_DM_NHOMTHAMDO.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_DM_NHOMTHAMDO.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_NHOMTHAMDOEntity) As Boolean
        Return ITNTP_DM_NHOMTHAMDO.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_NHOMTHAMDOEntity) As Boolean
        Return ITNTP_DM_NHOMTHAMDO.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_NhomThamdo AS String) AS Boolean
		Return ITNTP_DM_NHOMTHAMDO.DeleteByID(uId_NhomThamdo)
	End Function

    Public Function SelectByID(ByVal uId_NhomThamdo As String) As CM.TNTP_DM_NHOMTHAMDOEntity
        Return ITNTP_DM_NHOMTHAMDO.SelectByID(uId_NhomThamdo)
    End Function

End Class