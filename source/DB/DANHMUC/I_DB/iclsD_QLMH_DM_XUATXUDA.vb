Public Interface IQLMH_DM_XUATXUDA

    Function SelectAll() As List(Of CM.QLMH_DM_XUATXUEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uid_Xuatxu As String) As CM.QLMH_DM_XUATXUEntity

    Function Insert(ByVal obj As CM.QLMH_DM_XUATXUEntity) As Boolean

	Function DeleteByID(ByVal uid_Xuatxu AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DM_XUATXUEntity) As Boolean

End Interface