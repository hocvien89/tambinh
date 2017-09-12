Public Class QLMH_DINHMUC_GIAMATHANGFacade

    Dim IQLMH_DINHMUC_GIAMATHANG As DB.IQLMH_DINHMUC_GIAMATHANGDA = New DB.QLMH_DINHMUC_GIAMATHANGDA

    Public Function SelectAll() As List(Of CM.QLMH_DINHMUC_GIAMATHANGEntity)
        Return IQLMH_DINHMUC_GIAMATHANG.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Kho As String, ByVal uId_Nhommathang As String) As System.Data.DataTable
        Return IQLMH_DINHMUC_GIAMATHANG.SelectAllTable(uId_Kho, uId_Nhommathang)
    End Function
    Public Function SelectAllTable_ByuId_Loaimathang(ByVal uId_Kho As String, ByVal uId_Loaimathang As String) As System.Data.DataTable
        Return IQLMH_DINHMUC_GIAMATHANG.SelectAllTable_ByuId_Loaimathang(uId_Kho, uId_Loaimathang)
    End Function
    Public Function SelectTim_ByTensanpham(ByVal uId_Kho As String, ByVal sTensanpham As String) As System.Data.DataTable
        Return IQLMH_DINHMUC_GIAMATHANG.SelectTim_ByTensanpham(uId_Kho, sTensanpham)
    End Function
    Public Function Insert(ByVal obj As CM.QLMH_DINHMUC_GIAMATHANGEntity) As Boolean
        Return IQLMH_DINHMUC_GIAMATHANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DINHMUC_GIAMATHANGEntity) As Boolean
        Return IQLMH_DINHMUC_GIAMATHANG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Dinhmuc_Giamathang AS String) AS Boolean
		Return IQLMH_DINHMUC_GIAMATHANG.DeleteByID(uId_Dinhmuc_Giamathang)
	End Function

    Public Function SelectByID(ByVal uId_Dinhmuc_Giamathang As String) As CM.QLMH_DINHMUC_GIAMATHANGEntity
        Return IQLMH_DINHMUC_GIAMATHANG.SelectByID(uId_Dinhmuc_Giamathang)
    End Function

    Public Function SelectById_Mathang(uId_Mathang As String, uId_Cuahang As String) As DataTable
        Return IQLMH_DINHMUC_GIAMATHANG.SelectById_Mathang(uId_Mathang, uId_Cuahang)
    End Function
    '27/10/2014
    Public Function SelectCheck(uId_mathang As String, uId_kho As String) As DataTable
        Return IQLMH_DINHMUC_GIAMATHANG.Selectcheck(uId_mathang, uId_kho)
    End Function
End Class