Public Class DMDonviFacade

    Dim IDMDonvi As DB.IDMDonviDA = New DB.DMDonviDA

    Public Function SelectAll() As List(Of CM.DMDonviEntity)
        Return IDMDonvi.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IDMDonvi.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.DMDonviEntity) As Boolean
        Return IDMDonvi.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.DMDonviEntity) As Boolean
        Return IDMDonvi.Update(obj)
    End Function

    Public Function DeleteByID(ByVal madonvi As String) As Boolean
        Return IDMDonvi.DeleteByID(madonvi)
    End Function

    Public Function SelectByID(ByVal madonvi As String) As CM.DMDonviEntity
        Return IDMDonvi.SelectByID(madonvi)
    End Function

End Class