Public Interface IQT_PHANQUYENDA

    Function SelectAll(ByVal uId_Nhanvien As String) As System.Collections.Generic.List(Of CM.QT_PHANQUYENEntity)

    Function SelectAllTable(ByVal uId_Nhanvien As String, ByVal uId_Phanhe As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Nhanvien As String, ByVal uId_Chucnang As String) As CM.QT_PHANQUYENEntity

    Function Insert(ByVal obj As CM.QT_PHANQUYENEntity) As Boolean

    Function InsertAdmin(ByVal uId_Nhanvien As String) As Boolean

	Function DeleteByID(ByVal uId_Nhanvien AS String,ByVal uId_Chucnang AS String) AS Boolean

    Function Update(ByVal obj As CM.QT_PHANQUYENEntity) As Boolean
    '15/11/2014 xuanhieu
    Function SelectByuIdNhanvien(uId_Nhanvien As String, vType As String, uId_Phanhe As String) As DataTable
    'xuanhieu 17/11/2014
    Function CheckPhanquyen(uid_chucnang As String, uid_nhanvien As String) As Boolean
    'xuanhieu 21/11/2014
    Function DeleteAllById(uid_nhanvien As String) As Boolean
    'hieutx 3/07/2015 kiem tra quyen han cua nhan vien theo chuc nang
    Function CheckQuyenhanBychucnang(uId_Nhanvien As String, nv_Tenbien As String) As CM.QT_PHANQUYENEntity
    'hieutx 3/07/3015 xoa chuc nang theo phan he
    Function InsertDeleteByPhanhe(uId_Nhanvien As String, uId_Phanhe As String, vType As String) As Boolean
End Interface