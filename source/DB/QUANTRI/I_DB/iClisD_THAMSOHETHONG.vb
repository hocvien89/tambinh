
Public Interface iClisD_THAMSOHETHONG
    Function SelectByV_Tenbien(ByVal uId_Nhanvien As String) As CM.cls_QT_THAMSOHETHONG
    Function UpdateByV_Tenbien(ByVal obj As CM.cls_QT_THAMSOHETHONG) As Boolean

    Function Insert(objEnThamso As CM.cls_QT_THAMSOHETHONG) As Boolean

    Function Delete(uId_Thamso As String) As Boolean

    Function SelectAllTable() As DataTable

    Function Update(objEnThamso As CM.cls_QT_THAMSOHETHONG) As Boolean
End Interface

