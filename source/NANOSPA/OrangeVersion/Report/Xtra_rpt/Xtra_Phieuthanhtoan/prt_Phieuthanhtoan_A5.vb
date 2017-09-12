Imports System.Drawing
Imports DevExpress.XtraPrinting.Drawing
Imports DevExpress.XtraReports.UI
Public Class rpt_Phieuthanhtoan_A5
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
        Dim objFc_Cuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt_ch As DataTable
        Dim dt_tt As DataTable
        dt_tt = objFcPhieudichvu.Select_LoaihinhTT_ByID(uId_Phieudichvu)
        If dt_tt.Rows.Count > 0 Then
            lbl_Tienmat.Text = String.Format("{0:#,##}", dt_tt.Rows(0).Item("f_Tienmat").ToString)
            lbl_Card.Text = String.Format("{0:#,##}", dt_tt.Rows(0).Item("f_Card").ToString)
            lbl_Banking.Text = String.Format("{0:#,##}", dt_tt.Rows(0).Item("f_Banking").ToString)
        Else
            lbl_Tienmat.Text = ""
            lbl_Card.Text = ""
            lbl_Banking.Text = ""
        End If
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachhang)
        objEnPhieuDV = objFcPhieudichvu.SelectByID(uId_Phieudichvu)
        Dim dt_pdv As DataTable = objFcPhieudichvu.Select_ById_Table(uId_Phieudichvu)
        dt_ch = objFc_Cuahang.SelectByID(dt_pdv.Rows(0).Item("uId_Cuahang").ToString)
        Dim dt As DataTable = objFCChitietDV.SelectByID(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            BindingSource_BC.DataSource = dt
            dt.Dispose()
        End If
        lblSpaName.Text = nv_Tencuahang_vn
        lblSpaAddress.Text = nv_Diachicuahang
        lbl_Sophieu.Tag = objEnPhieuDV.v_Sophieu
        lblTenKH.Text = objEnKhachhang.nv_Hoten_vn
        lblKhachhangKy.Text = objEnKhachhang.nv_Hoten_vn
        lblSDT.Text = objEnKhachhang.v_DienthoaiDD
        lblDiachi.Text = objEnKhachhang.nv_Diachi_vn
        lblTongtien.Text = String.Format("{0:#,##}", Val(objEnPhieuDV.nv_Ghichu_en))
        lbl_Tieno.Text = String.Format("{0:#,##}", Val(objEnPhieuDV.nv_Ghichu_en) - Val(dt_tt.Rows(0).Item("f_Tongtien").ToString))
        lbl_Letan.Text = objFCNhanvien.SelectByID(objEnPhieuDV.uId_Nhanvien).nv_Hoten_vn
        XrPictureBox_logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
    End Sub
End Class