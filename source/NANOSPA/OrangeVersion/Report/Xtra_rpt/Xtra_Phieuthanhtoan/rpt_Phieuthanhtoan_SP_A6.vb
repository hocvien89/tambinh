Public Class rpt_Phieuthanhtoan_SP_A6
    Public Sub BindData(ByVal uId_Phieuxuat As String, ByVal uId_Khachhang As String, ByVal nv_Tencuahang_vn As String, ByVal nv_Diachicuahang As String)
       Dim oLibP As New Lib_SAT.cls_Pub_Functions
        Dim objFCLoaihinhTT As New BO.QLTC_LoaiHinhTTFacade
        Dim objFCNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objEnPhieuxuat As New CM.QLMH_PHIEUXUATEntity
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachhang)
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(uId_Phieuxuat)
        Dim dt As DataTable = objFcPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat)
        If dt.Rows.Count > 0 Then
            BindingSource1.DataSource = dt
            dt.Dispose()
        End If
        lblSpaName.Text = nv_Tencuahang_vn
        lblSpaAddress.Text = nv_Diachicuahang
        lblNgaylap.Text = "Ngày lập: " & objEnPhieuxuat.d_Ngayxuat.ToString("dd/MM/yyyy")
        lblTenKH.Text = objEnKhachhang.nv_Hoten_vn
        lblDiachi.Text = objEnKhachhang.nv_Diachi_vn
        lblTongtien.Text = String.Format("{0:#,##}", Val(objEnPhieuxuat.nv_Noidungxuat_en))
        lblGiamgia.Text = String.Format("{0:#,##}", objEnPhieuxuat.f_Giamgia_Tong)
        lblConlai.Text = String.Format("{0:#,##}", Val(objEnPhieuxuat.nv_Noidungxuat_en) - Val(objEnPhieuxuat.f_Giamgia_Tong))
        Dim tiennhan As Integer
        tiennhan = Integer.Parse(BO.Util.IsDouble(objEnPhieuxuat.f_Tongtienthuc))
        If tiennhan > 0 Then
            lblKhachtra.Text = String.Format("{0:#,##}", tiennhan)
        Else
            lblKhachtra.Text = "0"
        End If
        Dim tienthua As Double
        tienthua = Val(objEnPhieuxuat.nv_Noidungxuat_en) - Val(objEnPhieuxuat.f_Giamgia_Tong) - tiennhan
        If tienthua < 0 Then
            lbTienthutext.Text = "Tiền thừa"
            tienthua = tienthua * (-1)
        End If
        pic_Logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
        lblTienthua.Text = String.Format("{0:#,##}", Val(objEnPhieuxuat.nv_Noidungxuat_en) - Val(objEnPhieuxuat.f_Giamgia_Tong) - tiennhan)
        lblNhanvien.Text = objFCNhanvien.SelectByID(objEnPhieuxuat.uId_Nhanvien).nv_Hoten_vn
    End Sub
End Class