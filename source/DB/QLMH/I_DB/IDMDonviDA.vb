Public Interface IDMDonviDA

    Function SelectAll() As List(Of CM.DMDonviEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal madonvi As String) As CM.DMDonviEntity

    Function Insert(ByVal obj As CM.DMDonviEntity) As Boolean

    Function DeleteByID(ByVal madonvi As String) As Boolean

    Function Update(ByVal obj As CM.DMDonviEntity) As Boolean

End Interface