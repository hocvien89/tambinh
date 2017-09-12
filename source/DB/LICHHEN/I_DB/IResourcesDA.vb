Public Interface IResourcesDA

    Function SelectAll() As List(Of CM.ResourcesEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal UniqueID As Int32) As CM.ResourcesEntity

    Function Insert(ByVal obj As CM.ResourcesEntity) As Boolean

    Function DeleteByID(ByVal UniqueID As Int32) As Boolean

    Function Update(ByVal obj As CM.ResourcesEntity) As Boolean

    Function SelectByResourceId(RsID As Integer) As String

    Function Insert_Resource_Up(ByVal obj As CM.ResourcesEntity) As Boolean

    Function Select_Thongtin_ByID(id As String) As DataTable

End Interface