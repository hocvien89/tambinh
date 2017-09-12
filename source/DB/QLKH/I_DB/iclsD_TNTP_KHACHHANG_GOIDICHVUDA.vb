Public Interface ITNTP_KHACHHANG_GOIDICHVUDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_GOIDICHVUEntity)

    Function SelectAllTable_ByKH(ByVal uId_Khachhang As String, ByVal DK As Integer) As System.Data.DataTable

    Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Khachhang_Goidichvu As String) As CM.TNTP_KHACHHANG_GOIDICHVUEntity

    Function SelectByvBarcode(ByVal uId_Khachhang_Goidichvu As String) As CM.TNTP_KHACHHANG_GOIDICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As String

    Function DeleteByID(ByVal uId_Khachhang_Goidichvu As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean

    Function ThanhToan(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean

    Function Hoantien(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean

    Function UpdateTrangthai(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean

    Function SelectAllTable_DSTHE_Daban(ByVal uId_Cuahang As String, ByVal vType As String) As System.Data.DataTable

    Function chkExist_MaTheThanhtoan(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean

    Function BaoCao_DSTheKhachHang(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Keyword As String) As System.Data.DataTable

    Function LichSuThanhtoan(ByVal v_MaThe As String) As System.Data.DataTable

    Function SelectByDate(ByVal TuNgay As DateTime, DenNgay As DateTime, uId_Cuahang As String, uId_Trangthai As String) As System.Data.DataTable
    Function CreateMaCode() As String

    Function Check_Capthe_By_PDV(uId_Phieudichvu As String, uId_Dichvu As String) As DataTable

    Function Select_TheTaiKhoan_By_Khachhang(uId_Khachhang As String, Luachon As Integer) As DataTable

    Function SelectBy_Mathe(v_Mathe As String) As DataTable

    Function Update_Khachhang_GoiDichvu(uId_Khachhang_Goidichvu As String) As Boolean

End Interface