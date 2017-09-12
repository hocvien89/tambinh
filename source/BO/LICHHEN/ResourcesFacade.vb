Public Class ResourcesFacade

    Dim IResources As DB.IResourcesDA = New DB.ResourcesDA

    Public Function SelectAll() As List(Of CM.ResourcesEntity)
        Return IResources.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IResources.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.ResourcesEntity) As Boolean
        Return IResources.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.ResourcesEntity) As Boolean
        Return IResources.Update(obj)
    End Function

    Public Function DeleteByID(ByVal UniqueID As Int32) As Boolean
        Return IResources.DeleteByID(UniqueID)
    End Function

    Public Function SelectByID(ByVal UniqueID As Int32) As CM.ResourcesEntity
        Return IResources.SelectByID(UniqueID)
    End Function
    Public Function SelectByResourceId(RsID As Integer) As String
        Return IResources.SelectByResourceId(RsID)
    End Function
    Public Function Insert_Resource_Up(ByVal obj As CM.ResourcesEntity) As Boolean
        Return IResources.Insert_Resource_Up(obj)
    End Function

    Function Select_Thongtin_ByID(id As String) As DataTable
        Return IResources.Select_Thongtin_ByID(id)
    End Function

End Class