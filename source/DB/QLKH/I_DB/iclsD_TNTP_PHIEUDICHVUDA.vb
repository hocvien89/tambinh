Public Interface ITNTP_PHIEUDICHVUDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_PHIEUDICHVUEntity)

    Function SelectAllTable(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function SelectByDate(ByVal uId_Khachhang As String, ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable

    Function MaPDVMax(ByVal uId_Cuahang As String, ByVal ngaynhap As Date) As String

    Function SelectByDateDT(ByVal uId_Khachhang As String, ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable

    Function SelectDVNo(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function SelectByID_CNTT(ByVal uId_Congno_Thanhtoan As String) As System.Data.DataTable

    Function SelectIDPDVNo(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function SelectAllByGDV(ByVal uId_Khachhang As String, ByVal b_GoiDV As Byte, ByVal b_Trangthaiphieu As Byte) As System.Data.DataTable

    Function SelectByID(ByVal uId_Phieudichvu As String) As CM.TNTP_PHIEUDICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As String

	Function DeleteByID(ByVal uId_Phieudichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As Boolean

    Function Update_TTT(ByVal obj As CM.TNTP_PHIEUDICHVUEntity) As Boolean

    Function TongDaDT(ByVal uId_Phieudichvu As String) As String

    Function SelectBySophieu(ByVal v_Sophieu As String) As System.Data.DataTable

    Function KhoaSoNghiepVu(ByVal DenNgay As DateTime) As Boolean

    Function BaocaoHH(ByVal uId_Nhanvien As String, ByVal Tungay As DateTime, ByVal Denngay As String) As DataTable

    Function Select_LoaihinhTT_ByID(uId_Phieudichvu As String) As DataTable

    Function Select_ById_Table(uId_Phieudichvu As String) As DataTable

    Function SelectByID_Table_PDV(uId_Phieudichvu) As DataTable

    Function Select_Dichvu_ByID_Table(uId_Phieudichvu As String) As DataTable

    Function Select_The_Taikhoan_By_PDV(uId_Phieudichvu As String) As DataTable

    Function Select_ThongTin_The_Taikhoan_By_DV(uId_Phieudichvu As String, uId_Dichvu As String) As DataTable

    Function Select_Congno_ByID(uId_Phieudichvu As String) As DataTable

    Function Kiemtranhomdichvu_Thethaikhoan(uId_Phieudichvu As String) As DataTable

End Interface