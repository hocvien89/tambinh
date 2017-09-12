
Public Interface iClisD_Nhanvien

    Function SelectAll_Admin() As DataTable

    Function SelectAll() As DataTable

    Function SelectByID(ByVal uId_Nhanvien As String) As CM.cls_Nhanvien

    Function Insert(ByVal obj As CM.cls_Nhanvien) As Boolean

    Function DeleteByID(ByVal uId_Nhanvien As String) As Boolean

    Function Update(ByVal obj As CM.cls_Nhanvien) As Boolean

End Interface

