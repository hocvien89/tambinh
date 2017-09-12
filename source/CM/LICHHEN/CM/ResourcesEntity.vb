Public Class ResourcesEntity
    Implements IResourcesEntity

    Private _UniqueID As Int32
    Private _ResourceID As Int32
    Private _ResourceName As String
    Private _Color As Int32
    Private _CustomField1 As String

    Public Property UniqueID() As Int32 Implements IResourcesEntity.UniqueID
        Get
            Return _UniqueID
        End Get
        Set(ByVal value As Int32)
            _UniqueID = value
        End Set
    End Property

    Public Property ResourceID() As Int32 Implements IResourcesEntity.ResourceID
        Get
            Return _ResourceID
        End Get
        Set(ByVal value As Int32)
            _ResourceID = value
        End Set
    End Property

    Public Property ResourceName() As String Implements IResourcesEntity.ResourceName
        Get
            Return _ResourceName
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _ResourceName = String.Empty
            Else
                _ResourceName = value.Trim
            End If
        End Set
    End Property

    Public Property Color() As Int32 Implements IResourcesEntity.Color
        Get
            Return _Color
        End Get
        Set(ByVal value As Int32)
            _Color = value
        End Set
    End Property

    Public Property CustomField1() As String Implements IResourcesEntity.CustomField1
        Get
            Return _CustomField1
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _CustomField1 = String.Empty
            Else
                _CustomField1 = value.Trim
            End If
        End Set
    End Property

End Class
