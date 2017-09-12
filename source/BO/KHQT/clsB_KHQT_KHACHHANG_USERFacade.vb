Public Class KHQT_KHACHHANG_USERFacade

    Dim IKHQT_KHACHHANG_USER As DB.IKHQT_KHACHHANG_USERDA = New DB.KHQT_KHACHHANG_USERDA

    Public Function SelectAll() As List(Of CM.KHQT_KHACHHANG_USEREntity)
        Return IKHQT_KHACHHANG_USER.SelectAll()
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable
		Return IKHQT_KHACHHANG_USER.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean
        Return IKHQT_KHACHHANG_USER.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean
        Return IKHQT_KHACHHANG_USER.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Khachhang AS String) AS Boolean
		Return IKHQT_KHACHHANG_USER.DeleteByID(uId_Khachhang)
	End Function

    Public Function SelectByID(ByVal uId_Khachhang As String) As CM.KHQT_KHACHHANG_USEREntity
        Return IKHQT_KHACHHANG_USER.SelectByID(uId_Khachhang)
    End Function

    Public Function BaoCaoDichVu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Uid_Khachhang As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IKHQT_KHACHHANG_USER.BaoCaoDichVu(TuNgay, DenNgay, Uid_Khachhang, uId_Cuahang)
    End Function

    Public Function BAOCAO_DoanhThuTongHop(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IKHQT_KHACHHANG_USER.BAOCAO_DoanhThuTongHop(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function BAOCAO_PHIEUTHUCHI(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Type As String) As System.Data.DataTable
        Return IKHQT_KHACHHANG_USER.BAOCAO_PHIEUTHUCHI(TuNgay, DenNgay, uId_Cuahang, Type)
    End Function

    Public Function BAOCAO_TONGHOPTHUCHI(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Type As String) As System.Data.DataTable
        Return IKHQT_KHACHHANG_USER.BAOCAO_TONGHOPTHUCHI(TuNgay, DenNgay, uId_Cuahang, Type)
    End Function

    Public Function SoNhatKyChung(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Uid_Khachhang As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IKHQT_KHACHHANG_USER.SoNhatKyChung(TuNgay, DenNgay, Uid_Khachhang, uId_Cuahang)
    End Function

#Region "NMT- Doi mat khau"
    Public Function Doimatkhau(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean
        Return IKHQT_KHACHHANG_USER.Doimatkhau(obj)
    End Function
#End Region

#Region "NMT- Kiem tra dang nhap"
    Public Function chk_CheckLogin(ByVal oCls_Nhansu As CM.KHQT_KHACHHANG_USEREntity)
        'Create by: Minh Thang, 2011.09.01
        'NMT - Fun: Ham check mot user co quyen dang nhap hay khong
        'Update by: 
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim bKT As Boolean = False

        Dim DR() As DataRow = SelectAllTable().Select("v_Tendangnhap='" & oCls_Nhansu.v_Tendangnhap & "' and v_Matkhau='" & oCls_Nhansu.v_Matkhau & "'")
        If DR.Length > 0 Then bKT = True

        Return bKT

    End Function

    Public Function chk_GetIDLogin(ByVal oCls_Nhansu As CM.KHQT_KHACHHANG_USEREntity)
        'Create by: Minh Thang, 2011.09.01
        'NMT - Fun: Ham check mot user co quyen dang nhap hay khong
        'Update by: 
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim id As String = ""

        Dim DR() As DataRow = SelectAllTable().Select("v_Tendangnhap='" & oCls_Nhansu.v_Tendangnhap & "' and v_Matkhau='" & oCls_Nhansu.v_Matkhau & "'")
        If DR.Length > 0 Then
            id = DR(0).Item(0).ToString()
        End If
        Return id
    End Function

#End Region


End Class