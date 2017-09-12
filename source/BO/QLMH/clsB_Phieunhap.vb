Public Class clsB_Phieunhap
    Dim IQLMH_PHIEUNHAP As DB.iClsD_Phieunhap = New DB.clsD_Phieunhap

#Region "Phieu nhap - Header"

    Public Function SelectAll(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_PHIEUNHAP.SelectAll(uId_Cuahang)
    End Function


    Public Function Timkiem(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return IQLMH_PHIEUNHAP.TimKiem(uId_Kho, TuNgay, DenNgay)
    End Function


    Public Function Insert(ByVal obj As CM.cls_Phieunhap) As String
        Return IQLMH_PHIEUNHAP.Insert(obj)
    End Function


    Public Function Update(ByVal obj As CM.cls_Phieunhap) As Boolean
        Return IQLMH_PHIEUNHAP.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phieunhap As String) As Boolean
        Return IQLMH_PHIEUNHAP.DeleteByID(uId_Phieunhap)
    End Function

    Public Function SelectByID(ByVal uId_Phieunhap As String) As CM.cls_Phieunhap
        Return IQLMH_PHIEUNHAP.SelectByID(uId_Phieunhap)
    End Function

    Public Function SelectByMaVach(ByVal uId_Phieunhap As String) As CM.cls_Phieunhap
        Return IQLMH_PHIEUNHAP.SelectByID(uId_Phieunhap)
    End Function

    Public Function SelectByMa(ByVal Maphieu As String) As CM.cls_Phieunhap
        Return IQLMH_PHIEUNHAP.SelectByMaPhieu(Maphieu)
    End Function
#End Region

#Region "Phieu nhap - Detail"

    Public Function Insert_Detail(ByVal obj As CM.cls_Phieunhap) As Boolean
        Return IQLMH_PHIEUNHAP.Insert_PHIEUNHAP_CHITIET(obj)
    End Function

    Public Function Update_PHIEUNHAP_CHITIET(ByVal obj As CM.cls_Phieunhap) As Boolean
        Return IQLMH_PHIEUNHAP.Update_PHIEUNHAP_CHITIET(obj)
    End Function

    Public Function DeleteByID_PHIEUNHAP_CHITIET(ByVal uId_Phieunhap_Chitiet As String) As Boolean
        Return IQLMH_PHIEUNHAP.DeleteByID_PHIEUNHAP_CHITIET(uId_Phieunhap_Chitiet)
    End Function
    Public Function SelectPNChitiet_ByIDSP(ByVal v_Sophieu As String, ByVal uId_Mathang As String) As String
        Return IQLMH_PHIEUNHAP.SelectPNChitiet_ByIDSP(v_Sophieu, uId_Mathang)
    End Function
    Public Function SelectByID_PHIEUNHAP_CHITIET(ByVal uId_Phieunhap As String) As System.Data.DataTable
        Return IQLMH_PHIEUNHAP.SelectByID_PHIEUNHAP_CHITIET(uId_Phieunhap)
    End Function

#End Region
#Region "Phieu nhap - Tim kiem"
    Public Function Select_By_MaTenMypham(ByVal uId_Phieunhap As String, ByVal nv_TenMathang_vn As String) As DataTable
        Return IQLMH_PHIEUNHAP.Select_By_MaTenMypham(uId_Phieunhap, nv_TenMathang_vn)
    End Function
#End Region
    Function SelectTonghopNhap_Update(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_PHIEUNHAP.SelectTonghopNhap_Update(uId_Kho, TuNgay, DenNgay, uId_Cuahang)
    End Function

    Function SelectByTongthucte(uid_Phieunhap As String) As Double
        Return IQLMH_PHIEUNHAP.SelectByTongthucte(uid_Phieunhap)
    End Function
    Function UpdateTongtien(uid_Phieunhap As String) As Boolean
        Return IQLMH_PHIEUNHAP.UpdateTongtien(uid_Phieunhap)
    End Function

    Function UpdateTongthucte(uid_Phieunhap As String, f_Giamgia As Double, f_Tongthucte As Double) As Boolean
        Return IQLMH_PHIEUNHAP.UpdateTongthucte(uid_Phieunhap, f_Giamgia, f_Tongthucte)
    End Function

    'xuanhieu 231214 baocao tong nhap
    Function BCTonghopnhap(uId_kho As String, d_Tungay As DateTime, d_Denngay As DateTime) As DataTable
        Return IQLMH_PHIEUNHAP.BCTonghopnhap(uId_kho, d_Tungay, d_Denngay)
    End Function
    Public Function InPhieunhap_ByID(ByVal uId_Phieunhap As String) As DataTable
        Return IQLMH_PHIEUNHAP.InPhieunhapByID(uId_Phieunhap)
    End Function
End Class
