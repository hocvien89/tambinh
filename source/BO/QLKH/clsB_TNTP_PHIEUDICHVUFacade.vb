Public Class TNTP_PHIEUDICHVUFacade

    Dim ITNTP_PHIEUDICHVU As DB.ITNTP_PHIEUDICHVUDA = New DB.TNTP_PHIEUDICHVUDA

    Public Function SelectAll() As List(Of CM.TNTP_PHIEUDICHVUEntity)
        Return ITNTP_PHIEUDICHVU.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectAllTable(uId_Khachhang)
    End Function
    Public Function SelectByDate(ByVal uId_Khachhang As String, ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectByDate(uId_Khachhang, d_Tungay, d_Denngay)
    End Function

    Public Function MaPDVMax(ByVal uId_Cuahang As String, ByVal ngaynhap As Date) As String
        Return ITNTP_PHIEUDICHVU.MaPDVMax(uId_Cuahang, ngaynhap)
    End Function

    Public Function SelectByDateDT(ByVal uId_Khachhang As String, ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectByDateDT(uId_Khachhang, d_Tungay, d_Denngay)
    End Function

    Public Function SelectByID_CNTT(ByVal uId_Congno_Thanhtoan As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectByID_CNTT(uId_Congno_Thanhtoan)
    End Function
    Public Function SelectDVNo(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectDVNo(uId_Khachhang)
    End Function
    Public Function SelectIDPDVNo(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectIDPDVNo(uId_Khachhang, uId_Phieudichvu)
    End Function
    Public Function SelectAllByGDV(ByVal uId_Khachhang As String, ByVal b_GoiDV As Byte, ByVal b_Trangthaiphieu As Byte) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectAllByGDV(uId_Khachhang, b_GoiDV, b_Trangthaiphieu)
    End Function
    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As String
        Return ITNTP_PHIEUDICHVU.Insert(obj)
    End Function
    Public Function TongDaDT(ByVal uId_Phieudichvu As String) As String
        Return ITNTP_PHIEUDICHVU.TongDaDT(uId_Phieudichvu)
    End Function
    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As Boolean
        Return ITNTP_PHIEUDICHVU.Update(obj)
    End Function
    Public Function Update_TTT(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As Boolean
        Return ITNTP_PHIEUDICHVU.Update_TTT(obj)
    End Function
	Public Function DeleteByID(ByVal uId_Phieudichvu AS String) AS Boolean
		Return ITNTP_PHIEUDICHVU.DeleteByID(uId_Phieudichvu)
	End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String) As CM.TNTP_PHIEUDICHVUEntity
        Return ITNTP_PHIEUDICHVU.SelectByID(uId_Phieudichvu)
    End Function

    Public Function SelectBySophieu(ByVal v_Sophieu As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU.SelectBySophieu(v_Sophieu)
    End Function

    Public Function KhoaSoNghiepVu(ByVal DenNgay As DateTime) As Boolean
        Return ITNTP_PHIEUDICHVU.KhoaSoNghiepVu(DenNgay)
    End Function

    Public Function BaocaoHH(ByVal uId_Nhanvien As String, ByVal Tungay As DateTime, ByVal Denngay As DateTime)
        Return ITNTP_PHIEUDICHVU.BaocaoHH(uId_Nhanvien, Tungay, Denngay)
    End Function

    Function Select_LoaihinhTT_ByID(uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.Select_LoaihinhTT_ByID(uId_Phieudichvu)
    End Function
    Function Select_ById_Table(ByVal uId_Phieudichvu) As DataTable
        Return ITNTP_PHIEUDICHVU.Select_ById_Table(uId_Phieudichvu)
    End Function

    Function SelectByID_Table(ByVal uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.SelectByID_Table_PDV(uId_Phieudichvu)
    End Function

    Function Select_Dichvu_ByID_Table(uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.Select_Dichvu_ByID_Table(uId_Phieudichvu)
    End Function

    Function Select_The_Taikhoan_By_PDV(uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.Select_The_Taikhoan_By_PDV(uId_Phieudichvu)
    End Function

    Function Select_ThongTin_The_Taikhoan_By_DV(uId_Phieudichvu As String, uId_Dichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.Select_ThongTin_The_Taikhoan_By_DV(uId_Phieudichvu, uId_Dichvu)
    End Function

    Function Select_Congno_ByID(uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.Select_Congno_ByID(uId_Phieudichvu)
    End Function

    Function Kiemtranhomdichvu_Thethaikhoan(uId_Phieudichvu As String) As DataTable
        Return ITNTP_PHIEUDICHVU.Kiemtranhomdichvu_Thethaikhoan(uId_Phieudichvu)
    End Function

End Class