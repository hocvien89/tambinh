Public Class QLMH_DM_MATHANGFacade

    Dim IQLMH_DM_MATHANG As DB.IQLMH_DM_MATHANGDA = New DB.QLMH_DM_MATHANGDA

    Public Function SelectAll() As List(Of CM.QLMH_DM_MATHANGEntity)
        Return IQLMH_DM_MATHANG.SelectAll()
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable
		Return IQLMH_DM_MATHANG.SelectAllTable()
    End Function
    Public Function SelectTimKiem(ByVal uId_Loaimathang As String, ByVal uId_NhomMathang As String, ByVal nv_TenMathang_vn As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.SelectTimKiem(uId_Loaimathang, uId_NhomMathang, nv_TenMathang_vn)
    End Function
    Public Function SelectByBarcode(ByVal uId_Mathang As String, ByVal v_MaBarcode As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.SelectByBarcode(uId_Mathang, v_MaBarcode)
    End Function

    Public Function SelectAllBarcode(ByVal uId_NhomMathang As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.SelectAllBarcode(uId_NhomMathang)
    End Function
    Public Function Insert(ByVal obj As CM.QLMH_DM_MATHANGEntity) As String
        Return IQLMH_DM_MATHANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_MATHANGEntity) As Boolean
        Return IQLMH_DM_MATHANG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Mathang AS String) AS Boolean
		Return IQLMH_DM_MATHANG.DeleteByID(uId_Mathang)
	End Function

    Public Function SelectByID(ByVal uId_Mathang As String) As CM.QLMH_DM_MATHANGEntity
        Return IQLMH_DM_MATHANG.SelectByID(uId_Mathang)
    End Function
    Public Function SelectByMaVach(ByVal v_MaBarcode As String) As CM.QLMH_DM_MATHANGEntity
        Return IQLMH_DM_MATHANG.SelectByMaVach(v_MaBarcode)
    End Function
    Public Function SelectBarcodeMax(ByVal barcode As String) As CM.QLMH_DM_MATHANGEntity
        Return IQLMH_DM_MATHANG.SelectBarcodeMax(barcode)
    End Function

    Public Function Select_Banggia_Nhap(ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Nhap(uId_Kho)
    End Function

    Public Function Select_Banggia_Xuatban(ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Xuatban(uId_Kho)
    End Function

    Public Function Select_Banggia_Nhap_ByLoaimathang(ByVal uId_Loaimathang As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Nhap_ByLoaimathang(uId_Loaimathang, uId_Kho)
    End Function
    Public Function Select_Banggia_Xuat_ByLoaimathang(ByVal uId_Loaimathang As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Xuat_ByLoaimathang(uId_Loaimathang, uId_Kho)
    End Function

    Public Function Select_Banggia_Nhap_ByNhommathang(ByVal uId_Nhommathang As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Nhap_ByNhommathang(uId_Nhommathang, uId_Kho)
    End Function
    Public Function Select_Banggia_Xuat_ByNhommathang(ByVal uId_Nhommathang As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Xuat_ByNhommathang(uId_Nhommathang, uId_Kho)
    End Function
    Public Function Select_Banggia_Xuat(ByVal uId_Nhommathang As String, ByVal uId_Loaimathang As String, ByVal uId_Kho As String, ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Xuat(uId_Nhommathang, uId_Loaimathang, uId_Kho, d_Ngay, uId_Cuahang)
    End Function

    Public Function Bang_Tonghop_Ton(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Bang_Tonghop_Ton(TuNgay, DenNgay, uId_Kho, uId_Cuahang)
    End Function
    Public Function Bang_Tonghop_Ton_TimTheoTen(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Kho As String, ByVal uId_Cuahang As String, ByVal sTenMatHang As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Bang_Tonghop_Ton_TimTheoTen(TuNgay, DenNgay, uId_Kho, uId_Cuahang, sTenMatHang)
    End Function
    Public Function Bang_Tonghop_Ton_Canhbao_SapQuahan(ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Bang_Tonghop_Ton_Canhbao_SapQuahan(uId_Kho, uId_Cuahang)
    End Function

    Public Function Bang_Tonghop_Ton_Canhbao(ByVal TuNgay As Date, ByVal DenNgay As Date) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Bang_Tonghop_Ton_Canhbao(TuNgay, DenNgay)
    End Function

    Public Function SelectByMamathang(ByVal Mamathang As String) As CM.QLMH_DM_MATHANGEntity
        Return IQLMH_DM_MATHANG.SelectByMamathang(Mamathang)
    End Function

    Public Function Select_Banggia_Xuat_ByTenMathang(ByVal sTenMatHang As String, ByVal uId_Kho As String, ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Xuat_ByTenMathang(sTenMatHang, uId_Kho, d_Ngay, uId_Cuahang)
    End Function

    Public Function SelectByMamathangVaKho(ByVal Mamathang As String, ByVal uId_Kho As String) As CM.QLMH_DM_MATHANGEntity
        Return IQLMH_DM_MATHANG.SelectByMamathangVaKho(Mamathang, uId_Kho)
    End Function

    Public Function LaySLTonByTime(ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String, ByVal uId_Mathang As String) As Integer
        Return IQLMH_DM_MATHANG.LaySLTonByTime(DenNgay, uId_Kho, uId_Cuahang, uId_Mathang)
    End Function

    Public Function Select_Banggia_Nhap_Update(ByVal uId_Kho As String, ByVal key As String) As System.Data.DataTable
        Return IQLMH_DM_MATHANG.Select_Banggia_Nhap_Update(uId_Kho, key)
    End Function

    Public Function SelectGiaKhuyenMai(ByVal uId_Mathang As String, ByVal d_Ngay As Date) As Double
        Return IQLMH_DM_MATHANG.SelectGiaKhuyenMai(uId_Mathang, d_Ngay)
    End Function

    Public Function QuyDoiVeDonViNhoNhat(MaVatTu As String, MaDonVi As String, SoLuong As Double) As Integer
        Return IQLMH_DM_MATHANG.QuyDoiVeDonViNhoNhat(MaVatTu, MaDonVi, SoLuong)
    End Function

    Public Function SelectSearchByName(uId_Kho As String, uId_Cuahang As String, nv_Tenmathang As String) As DataTable
        Return IQLMH_DM_MATHANG.SelectSearchByName(uId_Kho, uId_Cuahang, nv_Tenmathang)
    End Function

    Public Function CreateMa()
        Return IQLMH_DM_MATHANG.CreateMa()
    End Function

    Function Select_By_Mathang_Table(v_Mamathang As String) As DataTable
        Return IQLMH_DM_MATHANG.Select_By_Mathang_Table(v_Mamathang)
    End Function

End Class