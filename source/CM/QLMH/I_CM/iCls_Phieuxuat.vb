Public Interface IQLMH_PHIEUXUATEntity

    'Header
    Property uId_Phieuxuat() As String
    Property uId_Khachhang() As String
    Property uId_Kho() As String
    Property uId_Nhanvien() As String
    Property v_Maphieuxuat() As String
    Property d_Ngayxuat() As DateTime
    Property nv_Noidungxuat_vn() As String
    Property nv_Noidungxuat_en() As String
    Property f_Giamgia_Tong() As Double
    Property f_Tongtienthuc() As Double
    Property b_IsKhoa() As Boolean
    Property uId_LoaiTT As String
    Property b_Dathanhtoan() As Boolean
    Property vTypeGia() As String
    Property f_Gia() As Double
    Property i_Soluog() As Integer
    Property b_Chike() As Boolean

    'Detail
    Property uId_Phieuxuat_Chitiet() As String
    Property uId_Mathang() As String
    Property f_Soluong() As Double
    Property f_Dongia() As Double
    Property f_Giamgia() As Double
    Property f_Tongtien() As Double
    Property nv_Ghichu() As String
    Property MaDonVi As String
    Property f_Soluongnhonhat As Double
End Interface
