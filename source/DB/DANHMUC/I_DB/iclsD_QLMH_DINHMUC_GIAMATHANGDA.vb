Public Interface IQLMH_DINHMUC_GIAMATHANGDA

    Function SelectAll() As List(Of CM.QLMH_DINHMUC_GIAMATHANGEntity)

    Function SelectAllTable(ByVal uId_Kho As String, ByVal uId_Nhommathang As String) As System.Data.DataTable
    Function SelectAllTable_ByuId_Loaimathang(ByVal uId_Kho As String, ByVal uId_Loaimathang As String) As System.Data.DataTable

    Function SelectTim_ByTensanpham(ByVal uId_Kho As String, ByVal sTensanpham As String) As System.Data.DataTable


    Function SelectByID(ByVal uId_Dinhmuc_Giamathang As String) As CM.QLMH_DINHMUC_GIAMATHANGEntity

    Function Insert(ByVal obj As CM.QLMH_DINHMUC_GIAMATHANGEntity) As Boolean

	Function DeleteByID(ByVal uId_Dinhmuc_Giamathang AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DINHMUC_GIAMATHANGEntity) As Boolean

    Function SelectById_Mathang(uId_Mathang As String, uId_Cuahang As String) As DataTable

    '27/10/2014 kiem tra mat hang da duoc dinh gia trong kho nao
    Function Selectcheck(uId_Mathang As String, uId_Kho As String) As DataTable
End Interface