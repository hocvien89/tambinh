Public Class rpt_Phieuthanhtoan_A6
    Public Sub BindData(ByVal uId_Phieudichvu As String, ByVal uId_Khachhang As String, ByVal nv_Tencuahang_vn As String, ByVal nv_Diachicuahang As String)
        Dim oLibP As New Lib_SAT.cls_Pub_Functions
        Dim objFCLoaihinhTT As New BO.QLTC_LoaiHinhTTFacade
        Dim objFCChitietDV As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim objFCNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objEnPhieuDV As New CM.TNTP_PHIEUDICHVUEntity
        Dim objFcPhieudichvu As New BO.TNTP_PHIEUDICHVUFacade
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachhang)
        objEnPhieuDV = objFcPhieudichvu.SelectByID(uId_Phieudichvu)
        Dim uutien As Double
        uutien = Convert.ToDouble(objEnPhieuDV.nv_Ghichu_en.Split("$")(1).ToString)
        If uutien < 100 Then
            uutien = Convert.ToDouble(objEnPhieuDV.nv_Ghichu_en.Split("$")(0).ToString) * 0.01 * uutien
        Else
            uutien = Convert.ToDouble(objEnPhieuDV.nv_Ghichu_en.Split("$")(1).ToString)
        End If


        Dim dt As DataTable = objFCChitietDV.SelectByID(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            BindingSource1.DataSource = dt
            dt.Dispose()
        End If
        lblNgaylap.Text = "Ngày lập: " & objEnPhieuDV.d_Ngay.ToString("dd/MM/yyyy")
        lblTenKH.Text = objEnKhachhang.nv_Hoten_vn
        lblDiachi.Text = objEnKhachhang.nv_Diachi_vn
        lblTongtien.Text = String.Format("{0:#,##}", Val(objEnPhieuDV.nv_Ghichu_en))
        lblGiamgia.Text = String.Format("{0:#,##}", objEnPhieuDV.f_Giamgia)
        lblConlai.Text = String.Format("{0:#,##}", Val(objEnPhieuDV.nv_Ghichu_en) - Val(objEnPhieuDV.f_Giamgia) - uutien)
        Dim tiennhan As Integer
        tiennhan = Integer.Parse(BO.Util.IsDouble(objEnPhieuDV.f_Tongtienthuc))
        If tiennhan > 0 Then
            lblKhachtra.Text = String.Format("{0:#,##}", tiennhan)
        Else
            lblKhachtra.Text = "0"
        End If
        Dim tienthua As Double
        tienthua = Val(objEnPhieuDV.nv_Ghichu_en) - Val(objEnPhieuDV.f_Giamgia) - tiennhan - uutien
        If tienthua < 0 Then
            lbTienthutext.Text = "Tiền thừa"
            tienthua = tienthua * (-1)
        End If
        lblTienthua.Text = String.Format("{0:#,##}", tienthua)
        pic_Logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
        lblNhanvien.Text = objFCNhanvien.SelectByID(objEnPhieuDV.uId_Nhanvien).nv_Hoten_vn
        lblHinhThucTT.Text = objFCLoaihinhTT.SelectByID(objEnPhieuDV.uId_LoaiTT).nv_TenLoaiTT
    End Sub
End Class