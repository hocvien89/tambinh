Public Class QT_PHANQUYENFacade

    Dim IQT_PHANQUYEN As DB.IQT_PHANQUYENDA = New DB.QT_PHANQUYENDA

    Public Function SelectAll(ByVal uId_Nhanvien As String) As List(Of CM.QT_PHANQUYENEntity)
        Return IQT_PHANQUYEN.SelectAll(uId_Nhanvien)
    End Function

    Public Function SelectAllTable(ByVal uId_Nhanvien As String, ByVal uId_Phanhe As String) As System.Data.DataTable
        Return IQT_PHANQUYEN.SelectAllTable(uId_Nhanvien, uId_Phanhe)
    End Function

    Public Function Insert(ByVal obj As CM.QT_PHANQUYENEntity) As Boolean
        Return IQT_PHANQUYEN.Insert(obj)
    End Function
    Public Function InsertAdmin(ByVal uId_Nhanvien As String) As Boolean
        Return IQT_PHANQUYEN.InsertAdmin(uId_Nhanvien)
    End Function
    Public Function Update(ByVal obj As CM.QT_PHANQUYENEntity) As Boolean
        Return IQT_PHANQUYEN.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Nhanvien AS String,ByVal uId_Chucnang AS String) AS Boolean
		Return IQT_PHANQUYEN.DeleteByID(uId_Nhanvien,uId_Chucnang)
	End Function

    Public Function SelectByID(ByVal uId_Nhanvien As String, ByVal uId_Chucnang As String) As CM.QT_PHANQUYENEntity
        Return IQT_PHANQUYEN.SelectByID(uId_Nhanvien, uId_Chucnang)
    End Function
    '15/11/2014
    Public Function SelectByuId_Nhanvien(uId_Nhanvien As String) As DataTable
        Return IQT_PHANQUYEN.SelectByuIdNhanvien(uId_Nhanvien)
    End Function
    '17/11/2014
    Public Function CheckPhanquyen(uid_chucnang As String, uid_nhanvien As String) As Boolean
        Return IQT_PHANQUYEN.CheckPhanquyen(uid_chucnang, uid_nhanvien)
    End Function
    'xuanhieu 21/11/2014 xoa tat ca 
    Public Function DeleteAllById(uid_nhanvien As String) As Boolean
        Return IQT_PHANQUYEN.DeleteAllById(uid_nhanvien)
    End Function
End Class