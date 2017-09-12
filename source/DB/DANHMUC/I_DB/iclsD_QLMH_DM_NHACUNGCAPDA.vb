Public Interface IQLMH_DM_NHACUNGCAPDA

    Function SelectAll() As List(Of CM.QLMH_DM_NHACUNGCAPEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Nhacungcap As String) As CM.QLMH_DM_NHACUNGCAPEntity

    Function Insert(ByVal obj As CM.QLMH_DM_NHACUNGCAPEntity) As Boolean

	Function DeleteByID(ByVal uId_Nhacungcap AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DM_NHACUNGCAPEntity) As Boolean

End Interface