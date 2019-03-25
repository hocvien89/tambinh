Public Interface IQLMH_DM_MATHANGDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.QLMH_DM_MATHANGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectTimKiem(ByVal uId_Loaimathang As String, ByVal uId_NhomMathang As String, ByVal nv_TenMathang_vn As String) As System.Data.DataTable

    Function SelectAllBarcode(ByVal uId_NhomMathang As String) As System.Data.DataTable

    Function SelectByBarcode(ByVal uId_Mathang As String, ByVal v_MaBarcode As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Mathang As String) As CM.QLMH_DM_MATHANGEntity

    Function SelectByMaVach(ByVal v_MaBarcode As String) As CM.QLMH_DM_MATHANGEntity

    Function SelectBarcodeMax(ByVal barcode As String) As CM.QLMH_DM_MATHANGEntity

    Function Insert(ByVal obj As CM.QLMH_DM_MATHANGEntity) As String

	Function DeleteByID(ByVal uId_Mathang AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DM_MATHANGEntity) As Boolean

    Function Select_Banggia_Nhap(ByVal uId_Kho As String) As System.Data.DataTable

    Function Select_Banggia_Xuatban(ByVal uId_Kho As String) As System.Data.DataTable

    Function Select_Banggia_Nhap_ByLoaimathang(ByVal uId_Loaimathang As String, ByVal uId_Kho As String) As System.Data.DataTable

    Function Select_Banggia_Xuat_ByLoaimathang(ByVal uId_Loaimathang As String, ByVal uId_Kho As String) As System.Data.DataTable


    Function Select_Banggia_Xuat_ByTenMathang(ByVal sTenMatHang As String, ByVal uId_Kho As String, ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable


    Function Select_Banggia_Nhap_ByNhommathang(ByVal uId_Nhommathang As String, ByVal uId_Kho As String) As System.Data.DataTable

    Function Select_Banggia_Xuat_ByNhommathang(ByVal uId_Nhommathang As String, ByVal uId_Kho As String) As System.Data.DataTable

    Function Select_Banggia_Xuat(ByVal uId_Nhommathang As String, ByVal uId_Loaimathang As String, ByVal uId_Kho As String, ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function Bang_Tonghop_Ton(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function Bang_Tonghop_Ton_TimTheoTen(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String, ByVal sTenMatHang As String) As System.Data.DataTable

    Function Bang_Tonghop_Ton_Canhbao_SapQuahan(ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function Bang_Tonghop_Ton_Canhbao_Quahan(ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable


    Function Bang_Tonghop_Ton_Canhbao(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectByMamathang(ByVal Mamathang As String) As CM.QLMH_DM_MATHANGEntity

    Function SelectByMamathangVaKho(ByVal Mamathang As String, ByVal uId_Kho As String) As CM.QLMH_DM_MATHANGEntity

    Function LaySLTonByTime(ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String, ByVal uId_Mathang As String) As Integer

    Function Select_Banggia_Nhap_Update(ByVal uId_Kho As String, ByVal key As String) As System.Data.DataTable

    Function SelectGiaKhuyenMai(ByVal uId_Mathang As String, ByVal d_Ngay As DateTime) As Double

    Function QuyDoiVeDonViNhoNhat(ByVal MaVatTu As String, ByVal MaDonVi As String, ByVal SoLuong As Double) As Integer

    Function SelectSearchByName(uId_Kho As String, uId_Cuahang As String, nv_Tenmathang As String) As DataTable

    Function CreateMa() As String

    Function Select_By_Mathang_Table(v_Mamathang As String) As DataTable

    Function reportInventory(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Kho As String, ByVal uId_Cuahang As String) As System.Data.DataTable

End Interface