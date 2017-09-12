
Public Interface iClsD_Phieunhap

#Region "Phieu nhap - header"

    Function SelectAll(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function TimKiem(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectByID(ByVal uId_Phieunhap As String) As CM.cls_Phieunhap

    Function Insert(ByVal obj As CM.cls_Phieunhap) As String

    Function DeleteByID(ByVal uId_Phieunhap As String) As Boolean

    Function Update(ByVal obj As CM.cls_Phieunhap) As Boolean

    Function SelectByMaPhieu(ByVal MaPhieu As String) As CM.cls_Phieunhap
#End Region
#Region "Phieu nhap - Detail"
    Function SelectByID_PHIEUNHAP_CHITIET(ByVal uId_Phieunhap As String) As System.Data.DataTable
    Function Insert_PHIEUNHAP_CHITIET(ByVal obj As CM.cls_Phieunhap) As Boolean
    Function Update_PHIEUNHAP_CHITIET(ByVal obj As CM.cls_Phieunhap) As Boolean
    Function DeleteByID_PHIEUNHAP_CHITIET(ByVal uId_Phieuxuat As String) As Boolean
    Function SelectPNChitiet_ByIDSP(ByVal v_Sophieu As String, ByVal uId_Mathang As String) As String
#End Region
#Region "Phieu nhap - Tim kiem"
    Function Select_By_MaTenMypham(ByVal uId_Phieunhap As String, ByVal uId_Mathang As String) As DataTable
#End Region
    Function SelectTonghopNhap_Update(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function UpdateTongthucte(uid_Phieunhap As String, f_Giamgia As Double, f_Tongthucte As Double) As Boolean
    Function SelectByTongthucte(uid_Phieunhap As String) As Double
    Function UpdateTongtien(uid_Phieunhap As String) As Boolean
    'xuanhieu 231214 baocao tong nhap
    Function BCTonghopnhap(uId_kho As String, d_Tungay As DateTime, d_Denngay As DateTime) As DataTable
    Function InPhieunhapByID(ByVal uId_phieunhap As String) As DataTable
End Interface
