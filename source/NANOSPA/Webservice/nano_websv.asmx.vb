Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class nano_websv
    Inherits System.Web.Services.WebService
#Region "var khach hang"
    Dim objFCKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnKhachhang As CM.CRM_DM_KhachhangEntity
    Dim objFCCuaHang As BO.QT_DM_CUAHANGFacade
    Dim objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Dim objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Dim objFCCongNo As BO.QLCN_CONGNOFacade
    Dim objEnCongNo As CM.QLCN_CONGNOEntity
    Dim objEnCongnoSP As CM.QLCN_CONGNO_SPEntity
    Dim objFcCongnoSP As BO.QLCN_CONGNO_SPFacade
    Dim objFCQTDieutri As BO.TNTP_QT_DieutriFacade
    Dim objFCGoi As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objEnGoi As CM.TNTP_KHACHHANG_GOIDICHVUEntity
    Private objFcThechuyentien As BO.clsB_TTV_KH_THECHUYENTIENFacade
    Private objEnThechuyentien As CM.icls_TTV_KH_THECHUYENTIENEntity
    Dim objFc_MKT_Sale As BO.clsB_MKT_SALES
    Dim objFc_Lichhen As BO.AppointmentsFacade
#End Region
#Region "var dich vu"
    Dim objFCPhieuDV As BO.TNTP_PHIEUDICHVUFacade
    Dim objEnPhieuDV As CM.TNTP_PHIEUDICHVUEntity
    Dim objFCChitietDV As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Dim objEnChitietDV As CM.TNTP_PHIEUDICHVU_CHITIETEntity
    Dim objFcDMDichvu As BO.TNTP_DM_DICHVUFacade
    Dim objEnDMDichvu As CM.TNTP_DM_DICHVUEntity
    Dim objFCPhieuDVLoaiTT As BO.TNTP_PHIEUDICHVU_LOAITTFacade
    Dim objEnPhieuDVLoaiTT As CM.TNTP_PHIEUDICHVU_LOAITTEntity
    Private objEnGoidichvu As CM.TNTP_GOIDICHVU_DICHVUEntity
    Private objFcGoidichvu As BO.TNTP_GOIDICHVU_DICHVUFacade
#End Region
#Region "var mat hang"
    Dim objFcPhieuxuatLoaiTT As BO.QLMH_PHIEUXUAT_LOAITTFacade
    Dim objEnPhieuxuatLoaiTT As CM.QLMH_PHIEUXUAT_LOAITTEntity
    Dim objEnPhieunhap As CM.cls_Phieunhap
    Dim objFcPhieunhap As BO.clsB_Phieunhap
    Dim objEnPhieuxuat As CM.QLMH_PHIEUXUATEntity
    Dim objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim objEnMathang As CM.QLMH_DM_MATHANGEntity
    Dim objFcMathang As BO.QLMH_DM_MATHANGFacade
    Dim objFcDonviQD As BO.DMQuyDoiDonViFacade
    Dim objEnDonviQD As CM.DMQuyDoiDonViEntity
#End Region
#Region "var Tai chinh"
    Dim objEnPhieunhapCn As CM.cls_Phieunhap_Congno
    Dim objFcPhieunhapCn As BO.clsB_Phieunhap_Congno
    Dim objEnPhieunhapCnTt As CM.cls_Phieunhap_Congno_Thanhtoan
    Dim objFcPhieunhapCnTt As BO.clsB_Phieunhap_Congno_Thanhtoan
    Dim objFcPhieuthuchi As BO.QLTC_PhieuthuchiFacade
    Dim objEnPhieuthuchi As CM.QLTC_PhieuthuchiEntity
    Dim objFcCongNoTT As BO.QLCN_CONGNO_THANHTOANFacade
    Dim objEnCongNoTT As CM.QLCN_CONGNO_THANHTOANEntity
#End Region
#Region "var nhan vien"
    Dim objEnNhanvien As CM.QT_DM_NHANVIENEntity
    Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Dim objFcChucnang As BO.QT_DM_CHUCNANGFacade
    Dim objFcKHTiemnang As BO.MKT_KH_TIEMNANGFacade
    Dim objEnKHTiemnang As CM.MKT_KH_TIEMNANGEntity
    Dim objFcMKTChuyendoi As BO.MKT_ChuyendoiFacade
#End Region
    Dim Log As New LogError.ShowError
    Dim oLibP As New Lib_SAT.cls_Pub_Functions
    Dim pc As New Public_Class
    Private objFCNhatKy As New BO.NHATKYSUDUNGFacade
    Dim objFCThamsohethong As BO.clsB_QT_THAMSOHETHONG
    Private objEnThamsohethong As CM.cls_QT_THAMSOHETHONG
    Private objFcResource As BO.ResourcesFacade
    Private objFcLuongcoban As BO.QLL_QUATRINHLUONGFacade
    Private objFcTTLuong As BO.QLL_THONGTINLUONGFacade
    Private objEnTTLuong As CM.QLL_THONGTINLUONGEntity

#Region "var the tich diem"
    Private objEnThetichdiem As CM.cls_TTV_KH_ThetichdiemEntity
    Private objFcThetichdiem As BO.clsB_TTV_KH_Thetichdiem
    Private objFcTTDChuyendoi As BO.clsB_TTV_DM_Thetichdiem_Chuyendoi
    Private objFcTTDLichsu As BO.clsB_TTV_KH_Thetichdiem_Lichsu
    Private objEnTTDLichsu As CM.cls_TTV_KH_Thetichdiem_LichsuEntity
    Private objFcDMthetichdiem As BO.clsB_TTV_DM_THETICHDIEM
    Private objEnDmthetichdiem As CM.icls_TTV_DM_ThetichdiemEntity
#End Region
#Region "Load Thong tin"
    'Load Thong tin khach hang
    <WebMethod()> _
    Public Function LoadThongTinKhachHang(ByVal uId_Khachhang As String) As String
        Dim rs As String
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        objEnKhachhang = objFCKhachhang.SelectByID(uId_Khachhang)
        rs = objEnKhachhang.d_Ngayden & "$" & objEnKhachhang.v_Makhachang & "$" & objEnKhachhang.nv_Hoten_vn &
            "$" & objEnKhachhang.d_Ngaysinh & "$" & objEnKhachhang.b_Gioitinh & "$" & objEnKhachhang.nv_Diachi_vn &
              "$" & objEnKhachhang.v_DienthoaiDD & "$" & objEnKhachhang.v_Email & "$" & objEnKhachhang.uId_Nghenghiep &
              "$" & objEnKhachhang.uId_Nguonden & "$" & objEnKhachhang.nv_Ghichu_vn & "$" & objEnKhachhang.nv_Hinhanh &
              "$" & objEnKhachhang.uId_Nguoigioithieu & "$" & objEnKhachhang.nv_Diachi_en & "$" & objEnKhachhang.nv_Nguyenquan_en &
              "$" & objEnKhachhang.nv_Hoten_en & "$" & objEnKhachhang.d_NgaycapCMT &
        "$" & objEnKhachhang.v_Dienthoaikhac & "$" & objEnKhachhang.nv_Noicap_en & "$" & objEnKhachhang.nv_Diachi_en
        Return rs
    End Function
    <WebMethod> _
    Public Function SelectName(uId_Khachhang As String)
        Dim objFcThetd = New BO.clsB_TTV_KH_Thetichdiem
        Dim rs As String
        If objFcThetd.SelectName(uId_Khachhang).Rows.Count > 0 Then
            rs = objFcThetd.SelectName(uId_Khachhang).Rows(0)(0).ToString
        Else
            rs = ""
        End If


        Return rs
    End Function
    <WebMethod(True)> _
    Public Function Loadlichhen() As String
        Dim dt As DataTable
        Dim objFcAppoint = New BO.AppointmentsFacade
        Dim rs As String
        Dim ab As String
        dt = objFcAppoint.SelectWarming(30)
        If dt.Rows.Count > 0 Then
            ab = "Bạn có " & dt.Rows.Count.ToString & " lịch hẹn"
        Else
            ab = "::: NANO-SPA 2015 ::: - Phần mềm quản lý spa, salon"
        End If
        rs = ab
        Return rs

    End Function
    <WebMethod(True)> _
    Public Function Get_Usd() As Double
        Dim db As Double
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        db = objFCThamsohethong.SelectTHAMSOHETHONGByID("vUsd").v_Giatri
        Return db
    End Function
    <WebMethod> _
    Public Function ThongkeKH() As List(Of CM.CRM_DM_KhachhangEntity)
        Dim objFC_dmdichvu As New BO.CRM_DM_KhachhangFacade
        Dim ab As New System.Collections.Generic.List(Of CM.CRM_DM_KhachhangEntity)()
        ab = objFC_dmdichvu.Thongketheonam()
        Return ab
    End Function
    'Tao moi ma khach hang
    <WebMethod(True)> _
    Public Function CreateNewCustomerCode() As String
        Dim strMaCH As String
        Dim strMaKH As String
        Dim strMa As String = ""
        objFCCuaHang = New BO.QT_DM_CUAHANGFacade
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        If Session("uId_Cuahang") <> Nothing Then
            Dim dt As DataTable = objFCCuaHang.SelectByID(Session("uId_Cuahang").ToString)
            strMaCH = dt.Rows(0)("v_Macuahang").ToString
            strMaKH = objFCKhachhang.MaKH(Session("uId_Cuahang").ToString)
            If strMaKH.Length < 6 Then
                For i As Integer = strMaKH.Length To 5
                    strMaKH = "0" + strMaKH
                Next
            End If
            strMa = strMaCH + strMaKH
            objFCCuaHang = Nothing
            objFCKhachhang = Nothing
            dt = Nothing
        End If
        Return strMa
    End Function

    'Them thong tin phieu dich vu
    <WebMethod(True)> _
    Public Function InsertPhieudichvu(ByVal v_Sophieu As String, ByVal d_Ngay As String, ByVal uId_Dichvu As String, ByVal f_GiamgiaDV As String, ByVal uId_Nhanvien As String, ByVal uId_LoaiTT As String) As String
        Dim struId_Phieudichvu As String = ""
        Dim str_DVType As String = ""
        If Session("uId_Cuahang") <> Nothing And Session("uId_Khachhang") <> Nothing Then
            objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
            objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
            objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
            objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
            objFcDMDichvu = New BO.TNTP_DM_DICHVUFacade
            objEnDMDichvu = New CM.TNTP_DM_DICHVUEntity
            objFcDMthetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
            Dim uutien As String = objFcDMthetichdiem.SelectUutienByKH(Session("uId_Khachhang"))
            Dim dt_phieu As DataTable
            dt_phieu = objFCPhieuDV.SelectBySophieu(v_Sophieu)
            If Session("uId_Phieudichvu") = Nothing Then
                objFCKhachhang = New BO.CRM_DM_KhachhangFacade
                If dt_phieu.Rows.Count = 0 Then
                    With objEnPhieuDV
                        .uId_Cuahang = oLibP.NullProString(Session("uId_Cuahang"))
                        .uId_Khachhang = oLibP.NullProString(Session("uId_Khachhang"))
                        .v_Sophieu = v_Sophieu.Split("$")(0)
                        .d_Ngay = BO.Util.ConvertDateTime(d_Ngay)
                        .d_Ngayketthuc = BO.Util.ConvertDateTime(d_Ngay).AddYears(1)
                        .uId_Nhanvien = uId_Nhanvien
                        .uId_LoaiTT = uId_LoaiTT
                        .f_Tongtienthuc = 0
                        .nv_Ghichu_en = uutien
                    End With
                    Try
                        Session("uId_Phieudichvu") = (objFCPhieuDV.Insert(objEnPhieuDV))
                        struId_Phieudichvu = Session("uId_Phieudichvu").ToString + "$PDV"
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu " & v_Sophieu & " cho khách hàng " & objFCKhachhang.SelectByID(Session("uId_Khachhang")).nv_Hoten_vn)
                    Catch ex As Exception
                        Log.WriteLog("InsertPhieudichvu-wsv", ex.Message.ToString)
                    End Try
                End If
            Else
                struId_Phieudichvu = Session("uId_Phieudichvu").ToString + "$ PDV"
            End If
            objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu").ToString)
            If objEnPhieuDV.f_Tongtienthuc <> 0 Then
                struId_Phieudichvu += "$ 1" ' da thanh toan ko them duoc dich vu
            Else
                'kiem tra dv la loai dv hay goi dich vu
                objEnDMDichvu = New CM.TNTP_DM_DICHVUEntity
                objFcDMDichvu = New BO.TNTP_DM_DICHVUFacade
                objEnDMDichvu = objFcDMDichvu.SelectByID(uId_Dichvu)
                'neu la loai goi dich vu
                If objEnDMDichvu.b_Goidichvu = True Then
                    '    'lay ve bang dv cua goi dich vu do
                    Dim dtgdv As DataTable
                    objFcGoidichvu = New BO.TNTP_GOIDICHVU_DICHVUFacade
                    dtgdv = objFcGoidichvu.SelectAllTable(uId_Dichvu)
                    'luu dich vu thuoc loai goi dich vu vao truong uidngoai te
                    If dtgdv.Rows.Count > 0 Then
                        For Each row As DataRow In dtgdv.Rows
                            objEnChitietDV.uId_Dichvu = row("uId_Dichvu").ToString
                            objEnChitietDV.uId_Phieudichvu = oLibP.NullProString(Session("uId_Phieudichvu"))
                            objEnDMDichvu = objFcDMDichvu.SelectByID(uId_Dichvu)
                            objEnChitietDV.f_Solan = objEnDMDichvu.i_Solan_Dieutri
                            objEnChitietDV.f_Soluong = Convert.ToDouble(row("f_Soluong").ToString)
                            objEnChitietDV.f_Dongia = Convert.ToDouble(row("f_Dongia").ToString)
                            objEnChitietDV.f_Giamgia = 0
                            objEnChitietDV.uId_Nhanvien = uId_Nhanvien
                            objEnChitietDV.b_BaoHanh = False
                            objEnChitietDV.uId_Ngoaite = uId_Dichvu

                            objFCChitietDV.Insert(objEnChitietDV)
                        Next
                    Else

                    End If
                Else
                    objEnChitietDV.uId_Dichvu = uId_Dichvu
                    objEnChitietDV.uId_Phieudichvu = oLibP.NullProString(Session("uId_Phieudichvu"))
                    objEnDMDichvu = objFcDMDichvu.SelectByID(uId_Dichvu)
                    objEnChitietDV.f_Solan = objEnDMDichvu.i_Solan_Dieutri
                    objEnChitietDV.f_Soluong = 1 'So luong mac dinh la 1
                    objEnChitietDV.f_Dongia = objEnDMDichvu.f_Gia
                    'objEnChitietDV.f_Giamgia = CDbl(f_GiamgiaDV) * objEnDMDichvu.f_Gia / 100
                    objEnChitietDV.f_Giamgia = objEnDMDichvu.f_Gia_Giam
                    objEnChitietDV.uId_Nhanvien = uId_Nhanvien
                    objEnChitietDV.b_BaoHanh = False
                    objFCChitietDV.Insert(objEnChitietDV)
                    objEnChitietDV.uId_Ngoaite = uutien
                End If
            End If

        End If
        Return struId_Phieudichvu
    End Function
    <WebMethod> _
    Public Function Thongke() As List(Of CM.TNTP_DM_DICHVUEntity)
        Dim objFC_dmdichvu As New BO.TNTP_DM_DICHVUFacade
        Dim ab As New System.Collections.Generic.List(Of CM.TNTP_DM_DICHVUEntity)()
        ab = objFC_dmdichvu.ThongkeKH()
        Return ab
    End Function
    <WebMethod(True)> _
    Public Function CreateNewCodeGDV() As String
        Dim pc = New Public_Class
        Dim strMa As String
        strMa = pc.ReturnAutoString("THE")
        Return strMa
    End Function
    'Update thong tin phieu dich vu
    <WebMethod(True)> _
    Public Function UpdatePhieudichvu(ByVal v_Sophieu As String, ByVal d_Ngay As String, ByVal f_Tongtienthuc As String, ByVal tienthua As String, ByVal uId_LoaiTT As String, ByVal f_Giamgia As String, ByVal uId_Nhanvien As String, ByVal nv_Ghichu_vn As String, ByVal HH As String, ByVal Id_Nhomphieu As String, f_Khachtra As String, nv_Lydogiamgia As String) As String
        Dim rs As String = ""
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnCongNo = New CM.QLCN_CONGNOEntity
        objFCCongNo = New BO.QLCN_CONGNOFacade
        objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
        objEnPhieuDVLoaiTT = New CM.TNTP_PHIEUDICHVU_LOAITTEntity
        objFCGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        objEnGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        objEnThechuyentien = New CM.cls_TTV_KH_THECHUYENTIENEntity
        Dim checkKhoaPhieu As Boolean
        Dim dt_Check_TTT As DataTable = objFCPhieuDV.Kiemtranhomdichvu_Thethaikhoan(Session("uId_Phieudichvu"))
        checkKhoaPhieu = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu")).b_IsKhoa
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Then
            '1. Kiem tra Quyen
            objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "DFED47F7-0C73-4169-93CB-18A2A65C8EF7")
            If Not objEnPhanQuyen.b_Enable Then
                rs = "Bạn không có quyền thanh toán phiếu!"
            End If
            If oLibP.NullProString(Session("uId_Phieudichvu")) <> Nothing Then
                '2.3 Nếu thanh toán Tiền Mặt, Chuyển khoản, Voucher
                If (Val(f_Tongtienthuc) >= 0) Then
                    'Update thong tin phieu dich vu - Header
                    With objEnPhieuDV
                        .v_Sophieu = v_Sophieu
                        .d_Ngay = BO.Util.ConvertDateTime(d_Ngay)
                        .uId_Phieudichvu = oLibP.NullProString(Session("uId_Phieudichvu"))
                        .nv_Lydogiamgia = nv_Lydogiamgia
                        'Truong hop thanh toan khong thanh toan tu the
                        If (tienthua <= 0 And dt_Check_TTT.Rows.Count = 0) Then 'thanh toan het trong 1 lan
                            Dim uId_Khachhang As String = Session("uId_Khachhang")
                            Dim f_Tongthanhtoan As Double = Convert.ToDouble(f_Khachtra)
                            chekKHTtd(uId_Khachhang, f_Tongthanhtoan, v_Sophieu, "Mua phiếu dịch vụ")
                            'If chekKHTtd(Session("uId_Khachhang").ToString, f_Khachtra, v_Sophieu, "Mua phiếu dịch vụ") = True Then
                            '    'tinh diem tich luy cho nguoi gioi thieu
                            '    'objEnKhachhang = objFCKhachhang.SelectByID(Session("uId_Khachhang"))
                            '    'If objEnKhachhang.uId_Nguoigioithieu <> Nothing Then
                            '    '    chekKHTtd(objEnKhachhang.uId_Nguoigioithieu, f_Khachtra, v_Sophieu, "Người giới thiệu phiếu dịch vụ")
                            '    'End If
                            'End If
                        End If
                        If (Session("uId_Khachhang_Goidichvu_TT") = Nothing) Then
                            'Manhtt:Truong hop khach hang tra thua tien thi luu so tien thuc nhan
                            .f_Tongtienthuc = Val(f_Tongtienthuc)
                            .uId_LoaiTT = uId_LoaiTT ' Mặc định là tiền mặt
                            'Manhtt Dong thoi luu vao bang loai hinh thanh toan de sau nay chi dung bao cao o bang nay
                            If uId_LoaiTT <> "163d42af-840f-4877-9c26-b079cde2a636" And uId_LoaiTT <> "2391e70e-951c-40db-a985-4ba41f888bf9" Then  'Neu loai hinh thanh toan khac voi hinh thuc nhieu hinh thuc
                                objEnPhieuDVLoaiTT.uId_LoaiTT = uId_LoaiTT
                                objEnPhieuDVLoaiTT.uId_Phieudichvu = Session("uId_Phieudichvu").ToString
                                objEnPhieuDVLoaiTT.f_Sotien = f_Tongtienthuc
                                objEnPhieuDVLoaiTT.v_Maso = ""
                                objEnPhieuDVLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFCPhieuDVLoaiTT.Insert(objEnPhieuDVLoaiTT)
                                Catch ex As Exception

                                End Try
                            End If
                            'xuanhieu200115: sua thanh toan tu the
                            '- tienthua=tienthe-tienphieu -> tienthua>0 la tienthua = so tien du the nguoc lai la khách can tra them
                            '- 
                            'Phuongdv_Insert loai TT The KH

                            If uId_LoaiTT = "2391e70e-951c-40db-a985-4ba41f888bf9" And checkKhoaPhieu = False Then
                                objEnPhieuDVLoaiTT.uId_LoaiTT = uId_LoaiTT
                                objEnPhieuDVLoaiTT.uId_Phieudichvu = Session("uId_Phieudichvu").ToString
                                objEnPhieuDVLoaiTT.f_Sotien = f_Tongtienthuc
                                objEnPhieuDVLoaiTT.v_Maso = ""
                                objEnPhieuDVLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFCPhieuDVLoaiTT.Insert(objEnPhieuDVLoaiTT)
                                Catch ex As Exception

                                End Try
                                'objEnThechuyentien = objFcThechuyentien.SelectByID(Session("uId_Khachhang").ToString)
                                'objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu").ToString)
                                'If (objEnThechuyentien.f_Sotien < (objEnPhieuDV.f_Tongtienthuc - objEnPhieuDV.f_Giamgia)) Then
                                '    rs = "Số tiền trong tài khoản của bạn không đủ để thanh toán toàn bộ giá trị phiếu"
                                'End If
                                Dim dttb As DataTable
                                dttb = objFcThechuyentien.SelectByID_TB(Session("uId_Khachhang"))
                                If dttb.Rows.Count > 0 Then
                                    If dttb.Rows(0)("f_Sotien") < f_Tongtienthuc Then

                                        rs = "Không thể thanh toán"
                                    Else
                                        objFcThechuyentien.Update_Loai_TT(Session("uId_Khachhang").ToString, Session("uId_Phieudichvu").ToString)
                                    End If
                                    objEnCongNo = objFCCongNo.SelectByID(Session("uId_Phieudichvu"))


                                    If Val(tienthua) > 0 Then
                                        objEnCongNo.uId_Phieudichvu = oLibP.NullProString(Session("uId_Phieudichvu"))
                                        objEnCongNo.f_Sotien = Val(tienthua)
                                        objFCCongNo.Insert(objEnCongNo)
                                    End If

                                End If

                            End If
                            'xuanhieu200115: sua thanh toan tu the
                            '- tienthua=tienthe-tienphieu -> tienthua>0 la tienthua = so tien du the nguoc lai la khách can tra them
                            '- 
                        Else 'Truong hop thanh toan tu the 
                            .uId_LoaiTT = "01d16c43-7a03-49dc-afd2-39e79a1439f1" ' Truong hop thanh toan tu the
                            'Insert vao bang ke khai loai thanh (luu tru du lieu thanh toan phieu bang the)
                            If Val(tienthua) < 0 Then
                                'Truong hop so tien cua the thanh toan nho hon so tien phai thanh toan
                                'Truong hop so tien the thanh toan nhieu hon hoc bang
                                .f_Tongtienthuc = Val(f_Tongtienthuc)
                                objEnGoi.f_Sotien = Math.Abs(Val(tienthua))
                                objEnPhieuDVLoaiTT.uId_LoaiTT = objFCPhieuDVLoaiTT.QLTC_LoaiHinhTT_SelectByMa("THE")
                                objEnPhieuDVLoaiTT.uId_Phieudichvu = Session("uId_Phieudichvu").ToString
                                objEnPhieuDVLoaiTT.f_Sotien = f_Tongtienthuc
                                objEnPhieuDVLoaiTT.v_Maso = Session("v_MaTTT")
                                objEnPhieuDVLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFCPhieuDVLoaiTT.Insert(objEnPhieuDVLoaiTT)
                                Catch ex As Exception

                                End Try
                            Else
                                .f_Tongtienthuc = Val(tienthua) 'Truong hop nay thi tien thuc chinh la tien cua the
                                objEnGoi.f_Sotien = 0
                                objEnPhieuDVLoaiTT.uId_LoaiTT = objFCPhieuDVLoaiTT.QLTC_LoaiHinhTT_SelectByMa("THE")
                                objEnPhieuDVLoaiTT.uId_Phieudichvu = Session("uId_Phieudichvu").ToString
                                objEnPhieuDVLoaiTT.f_Sotien = Val(tienthua)
                                objEnPhieuDVLoaiTT.v_Maso = Session("v_MaTTT")
                                objEnPhieuDVLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFCPhieuDVLoaiTT.Insert(objEnPhieuDVLoaiTT)
                                Catch ex As Exception

                                End Try
                            End If
                            objEnGoi.uId_Khachhang_Goidichvu = oLibP.NullProString(Session("uId_Khachhang_Goidichvu_TT"))
                            objFCGoi.ThanhToan(objEnGoi)
                            Session("uId_Khachhang_Goidichvu_TT") = Nothing
                        End If
                        .f_Giamgia = Val(f_Giamgia)
                        .d_Ngayketthuc = BO.Util.ConvertDateTime(d_Ngay).AddYears(1)
                        .uId_Nhanvien = uId_Nhanvien
                        .nv_Ghichu_vn = nv_Ghichu_vn

                        'Manhtt: Cho nguoi dung tu nhap hoa hong cho nhan vien theo phieu
                        .HHPhieu = BO.Util.IsDouble(HH)
                        'Manhtt: Chon loai phieu (VD: Thanh toan dich vu, thanh toan the le, the goi)
                        .Id_Nhomphieu = Integer.Parse(Id_Nhomphieu)
                        Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLockBill")
                        If oThamsohethong.v_Giatri = "1" Then
                            .b_IsKhoa = True
                        Else
                            .b_IsKhoa = False
                        End If
                        .b_IsPayed = True
                    End With
                    If (objFCPhieuDV.Update(objEnPhieuDV)) Then
                        objFCPhieuDVLoaiTT.updatesotien(uId_LoaiTT, Session("uId_Phieudichvu").ToString, Convert.ToDouble(f_Tongtienthuc))

                        rs = "Thanh toán thành công!"
                        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thanh toán phiếu " & v_Sophieu & " cho khách hàng " & objFCKhachhang.SelectByID(Session("uId_Khachhang")).nv_Hoten_vn)
                    Else
                        rs = "Có lỗi xảy ra!"
                    End If
                    objFCPhieuDV = Nothing
                Else
                    rs = "Không có phiếu để thanh toán"
                End If
                objEnCongNo = objFCCongNo.SelectByID(Session("uId_Phieudichvu"))


                If Val(tienthua) > 0 Then
                    objEnCongNo.uId_Phieudichvu = oLibP.NullProString(Session("uId_Phieudichvu"))
                    objEnCongNo.f_Sotien = Val(tienthua)
                    objFCCongNo.Insert(objEnCongNo)
                End If


                '3. Neu khach hang co lo thi chuyen vao Cong no KH

            Else
                rs = "Không có thông tin phiếu để thanh toán!"
            End If
        Else
            rs = "Phiếu đã khóa!"
        End If
        Return rs
    End Function
    <WebMethod(True)>
    Public Function CheckTK() As String
        Dim rs As String
        objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        objEnThechuyentien = New CM.cls_TTV_KH_THECHUYENTIENEntity
        objEnThechuyentien = objFcThechuyentien.SelectByID(Session("uId_Khachhang").ToString)
        rs = objEnThechuyentien.f_Sotien
        Return rs
    End Function
    'Load Thong tin dich vu cap the
    <WebMethod()> _
    Public Function LoadThongTinCapThe(ByVal uId_Phieudichvu As String) As String
        Dim rs As String = ""
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable
        dt = objFCPhieuDV.Select_The_Taikhoan_By_PDV(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            rs = dt.Rows(0).Item("vType").ToString & "$" & dt.Rows(0).Item("nv_Tendichvu_vn").ToString & "$" & dt.Rows(0).Item("f_Gia").ToString & "$" & dt.Rows(0).Item("uId_Dichvu").ToString
        End If
        Return rs
    End Function
    <WebMethod()> _
    Public Function LoadThongTinTheByDichvu(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As String
        Dim rs As String = ""
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable
        dt = objFCPhieuDV.Select_ThongTin_The_Taikhoan_By_DV(uId_Phieudichvu, uId_Dichvu)
        If dt.Rows.Count > 0 Then
            rs = dt.Rows(0).Item("vType").ToString & "$" & dt.Rows(0).Item("nv_Tendichvu_vn").ToString & "$" & dt.Rows(0).Item("f_Gia").ToString & "$" & dt.Rows(0).Item("uId_Dichvu").ToString
        End If
        Return rs
    End Function

    'Load Thong tin phieu dich vu
    <WebMethod()> _
    Public Function LoadThongTinPhieuDichVu(ByVal uId_Phieudichvu As String) As String
        Dim rs As String
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objEnPhieuDV = objFCPhieuDV.SelectByID(uId_Phieudichvu)
        rs = objEnPhieuDV.v_Sophieu & "$" & objEnPhieuDV.d_Ngay & "$" & objEnPhieuDV.f_Tongtienthuc &
            "$" & objEnPhieuDV.f_Giamgia & "$" & objEnPhieuDV.uId_LoaiTT & "$" & objEnPhieuDV.uId_Nhanvien &
            "$" & objEnPhieuDV.nv_Ghichu_en & "$" & objEnPhieuDV.nv_Ghichu_vn & "$" & objEnPhieuDV.HHPhieu &
            "$" & objEnPhieuDV.Id_Nhomphieu & "$" & objEnPhieuDV.b_IsPayed & "$" & objEnPhieuDV.nv_Lydogiamgia
        Return rs
    End Function

    'Xoa thong tin phieu chi tiet
    <WebMethod(True)> _
    Public Function DeletePhieuchitiet(ByVal v_Sophieu As String, ByVal uId_Dichvu As String) As String
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        Dim str As String = uId_Dichvu
        Try
            Dim dt As DataTable
            dt = objFCPhieuDV.SelectBySophieu(v_Sophieu)
            Dim uId_Phieudichvu As String = ""
            uId_Phieudichvu = dt.Rows(0)("uId_Phieudichvu").ToString
            objEnPhieuDV = objFCPhieuDV.SelectByID(uId_Phieudichvu)
            If objEnPhieuDV.f_Tongtienthuc <> 0 Then
                str = uId_Phieudichvu + "$ PDV"
            Else
                objEnDMDichvu = New CM.TNTP_DM_DICHVUEntity
                objFcDMDichvu = New BO.TNTP_DM_DICHVUFacade
                objEnDMDichvu = objFcDMDichvu.SelectByID(uId_Dichvu)
                If objEnDMDichvu.b_Goidichvu = True Then
                    objFCChitietDV.DeleteByIDPhieu(uId_Phieudichvu, "")
                Else
                    objFCChitietDV.DeleteByIDPhieu(uId_Phieudichvu, uId_Dichvu)
                End If
                Dim dtpdvct As DataTable
                dtpdvct = objFCChitietDV.SelectByID(uId_Phieudichvu)
                If dtpdvct.Rows.Count > 0 Then
                    str = uId_Phieudichvu + "$ PDV"
                Else
                    objFCPhieuDV.DeleteByID(uId_Phieudichvu)
                    str = ""
                End If
            End If
        Catch ex As Exception

        End Try
        Return str
    End Function

    'Tao moi ma phieu dich vu
    <WebMethod(True)> _
    Public Function CreateSoPhieuDichVu(ByVal ngaynhap As String) As String
        Dim rs As String = ""
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim strMa As String = objFCPhieuDV.MaPDVMax(oLibP.NullProString(Session("uId_Cuahang")), BO.Util.ConvertDateTime(ngaynhap))
        If strMa.Length < 4 Then
            For m As Integer = strMa.Length To 3
                strMa = "0" + strMa
            Next
        End If
        rs = ReturnStringByDate("P", BO.Util.ConvertDateTime(ngaynhap)) + strMa
        Return rs
    End Function

    'Ham ho tro tao ma phieu
    Public Function ReturnStringByDate(ByVal ID As String, ByVal ngaynhap As Date) As String
        Dim yc As String = ngaynhap.Year.ToString
        Dim mc As String = ngaynhap.Month.ToString
        Dim dc As String = ngaynhap.Day.ToString
        If (Val(mc) < 10) Then mc = mc.Replace("0", "")
        If (Val(dc) < 10) Then dc = dc.Replace("0", "")
        Return ID + dc + mc + yc + "."
    End Function
    <WebMethod>
    Public Function LoadHH(ByVal uId_Dichvu As String) As String
        Dim rs As String
        objFcDMDichvu = New BO.TNTP_DM_DICHVUFacade
        rs = objFcDMDichvu.SelectByID(uId_Dichvu).f_PhantramHH_KTV
        Return rs
    End Function
    'Load lan dieu tri tu dong
    <WebMethod(True)> _
    Public Function Loadlandieutri(ByVal uId_Dichvu As String) As String
        Dim rs As String = ""
        Dim f_Solan As Integer
        objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        objEnChitietDV = objFCChitietDV.SelectByIDDichvu(Session("uId_Phieudichvu"), uId_Dichvu)
        Dim dt As DataTable
        dt = objFCChitietDV.SelectByIDChitiet(objEnChitietDV.uId_Phieudichvu_Chitiet)
        If objEnChitietDV.b_BaoHanh = False Then
            If dt.Rows.Count > 0 Then
                rs = dt.Rows(0)("f_Solan")
                f_Solan = dt.Rows(0)("f_Solan")
                If (Session("uId_QT_Dieutri") = Nothing) Then
                    rs = rs & "$" & CStr(dt.Rows(0)("i_SL_daDieutri") + 1) & "$" & Format(CDbl(dt.Rows(0)("f_Gia1lan")), "N0")
                End If
            End If
            Session("b_BaoHanh") = Nothing
        Else
            'Truong hop bao hanh vinh vien se khong tinh lieu trinh
            rs = "N/A"
            Session("b_BaoHanh") = "True"
        End If
        dt = New DataTable
        dt = objFCQTDieutri.SelectAllByIdDV(Session("uId_Phieudichvu"), uId_Dichvu)
        Dim iSolan_Dadieutri As Integer = dt.Rows.Count
        rs = rs & "$" & Str(CInt(f_Solan) - iSolan_Dadieutri)
        Return rs
    End Function

    'Load mot ma phieu thu chi theo thoi gian
    <WebMethod()> _
    Public Function CreateTimeCode(ByVal headtext As String) As String
        Dim rs As String = ""
        rs = pc.ReturnAutoString(headtext)
        Return rs
    End Function


    'Lay thong tin no cua phieu dich vu
    <WebMethod()> _
    Public Function GetNoPhieuDV(ByVal uId_Phieudichvu) As String
        objEnCongNo = New CM.QLCN_CONGNOEntity
        objFCCongNo = New BO.QLCN_CONGNOFacade
        Dim rs As String = ""
        objEnCongNo = objFCCongNo.SelectByID(uId_Phieudichvu)
        If objEnCongNo.f_Sotien <> Nothing Then
            rs = objEnCongNo.f_Sotien.ToString
        End If
        Return rs
    End Function

    'Lay thong tin no cua phieu xuat
    <WebMethod()> _
    Public Function GetNobjEnPhieuxuat(ByVal uId_Phieuxuat) As String
        objEnCongnoSP = New CM.QLCN_CONGNO_SPEntity
        objFcCongnoSP = New BO.QLCN_CONGNO_SPFacade
        Dim rs As String = ""
        objEnCongnoSP = objFcCongnoSP.SelectByID(uId_Phieuxuat)
        If objEnCongnoSP.f_Sotien <> Nothing Then
            rs = objEnCongnoSP.f_Sotien.ToString
        End If
        Return rs
    End Function

    'Insert thong tin phieu nhap chi tiet
    <WebMethod(True)> _
    Public Function InsertPhieunhapchitiet(ByVal v_MaMathang As String, ByVal f_Soluong As String, ByVal MaDonVi As String) As String
        'v_MaMathang Thuc chat la uId_Mathang
        Dim rs As String = ""
        Dim f_Tongthanhtoan As Integer
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        objFcDonviQD = New BO.DMQuyDoiDonViFacade
        objEnPhieunhap = objFcPhieunhap.SelectByID(Session("uId_Phieunhap"))
        f_Tongthanhtoan = objEnPhieunhap.f_Tongthanhtoan
        If f_Tongthanhtoan = 0 Then
            objEnMathang = objFcMathang.SelectByMamathangVaKho(objFcMathang.SelectByID(v_MaMathang).v_MaMathang, objEnPhieunhap.uId_Kho)
            objEnPhieunhap.uId_Phieunhap = Session("uId_Phieunhap")
            objEnPhieunhap.uId_Mathang = objEnMathang.uId_Mathang
            objEnPhieunhap.f_Soluong = Val(f_Soluong)
            'Gia nay lay theo: gia don vi nho nhat * so luong nho nhat
            'Truoc het la lay ti le quy doi
            Dim TileQD As Integer
            TileQD = objFcDonviQD.LayGiaTriQuyDoi(objEnMathang.uId_Mathang, MaDonVi)
            objEnPhieunhap.f_Donggia = objEnMathang.f_Gianhap * TileQD
            'objEnPhieunhap.f_Donggia = objEnMathang.f_Gianhap
            objEnPhieunhap.f_Thanhtien = objEnPhieunhap.f_Soluong * objEnPhieunhap.f_Donggia
            objEnPhieunhap.MaDonVi = MaDonVi
            Try
                objFcPhieunhap.Insert_Detail(objEnPhieunhap)
                objFcPhieunhap.UpdateTongtien(Session("uId_Phieunhap"))
                rs = "Success"
            Catch ex As Exception
                rs = "Fail"
            End Try
        Else
            rs = "Phiếu nhập đã thanh toán không thể thay đổi thông tin! "
        End If
        Return rs
    End Function

    'Load thong tin phieu nhap
    <WebMethod(True)> _
    Public Function LoadThongTinPhieuNhap(ByVal uId_Phieunhap As String) As String
        Dim rs As String
        objFcPhieunhap = New BO.clsB_Phieunhap
        objEnPhieunhap = New CM.cls_Phieunhap
        objEnPhieunhap = objFcPhieunhap.SelectByID(uId_Phieunhap)
        rs = objEnPhieunhap.v_Maphieunhap & "$" & objEnPhieunhap.uId_Kho & "$" & objEnPhieunhap.d_Ngaynhap & "$" & objEnPhieunhap.uId_Nhacungcap _
            & "$" & objEnPhieunhap.nv_Noidung_vn & "$" & objEnPhieunhap.f_Giamgia & "$" & objEnPhieunhap.f_Tongtien & "$" & objEnPhieunhap.f_Tongthanhtoan
        Return rs
    End Function

    'Insert thong tin phieu xuat chi tiet
    <WebMethod(True)> _
    Public Function InsertPhieuxuatchitiet(ByVal v_MaMathang As String, ByVal f_Soluong As String, ByVal MaDonVi As String) As String
        'v_MaMathang Thuc chat la uId_Mathang
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFcDonviQD = New BO.DMQuyDoiDonViFacade
        Dim rs As String = ""
        Dim checkKhoaPhieu As Boolean
        checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).b_IsKhoa
        Dim dt_KP As New DataTable
        dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt_KP.Rows.Count > 0 Then
            Dim d_Ngayxuat As Date
            d_Ngayxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).d_Ngayxuat
            Dim uId_Kho As String = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).uId_Kho
            objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
            objEnMathang = objFcMathang.SelectByMamathangVaKho(objFcMathang.SelectByID(v_MaMathang).v_MaMathang, uId_Kho)
            objEnPhieuxuat.uId_Phieuxuat = Session("uId_Phieuxuat")
            objEnPhieuxuat.uId_Mathang = objEnMathang.uId_Mathang

            objEnPhieuxuat.f_Soluong = f_Soluong
            'Gia nay lay theo: gia don vi nho nhat * so luong nho nhat
            'Truoc het la lay ti le quy doi
            Dim TileQD As Integer
            TileQD = objFcDonviQD.LayGiaTriQuyDoi(objEnMathang.uId_Mathang, MaDonVi)
            objEnPhieuxuat.f_Dongia = objEnMathang.f_Giaban * TileQD
            If objFcMathang.SelectGiaKhuyenMai(objEnMathang.uId_Mathang, d_Ngayxuat) > 100 Then
                objEnPhieuxuat.f_Giamgia = objFcMathang.SelectGiaKhuyenMai(objEnMathang.uId_Mathang, d_Ngayxuat)
            Else
                objEnPhieuxuat.f_Giamgia = (objEnPhieuxuat.f_Soluong * objEnPhieuxuat.f_Dongia) * objFcMathang.SelectGiaKhuyenMai(objEnMathang.uId_Mathang, d_Ngayxuat) / 100
            End If
            objEnPhieuxuat.f_Tongtien = objEnPhieuxuat.f_Soluong * objEnPhieuxuat.f_Dongia - objEnPhieuxuat.f_Giamgia
            objEnPhieuxuat.MaDonVi = MaDonVi
            'Quy doi ve so luong nho nhat theo ma don vi
            Dim LaySLNhoNhat As Integer
            LaySLNhoNhat = objFcMathang.QuyDoiVeDonViNhoNhat(objEnMathang.uId_Mathang, MaDonVi, Val(f_Soluong))
            If objFcMathang.LaySLTonByTime(d_Ngayxuat, uId_Kho, Session("uId_Cuahang").ToString(), objEnMathang.uId_Mathang) >= LaySLNhoNhat Then
                objFcPhieuxuat.Insert_QLMH_PHIEUXUAT_CHITIET(objEnPhieuxuat)
                rs = "Success"
            Else
                rs = "Mặt hàng đã hết trong kho! Vui lòng kiểm tra lại"
            End If
        Else
            rs = "Phiếu đã khóa!"
        End If
        Return rs
    End Function

    'Load thong tin phieu xuat chua thanh toan
    <WebMethod(True)> _
    Public Function LoadThongTinPhieuXuatChuaThanhToan() As String
        Dim rs As String
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objEnPhieuxuat = objFcPhieuxuat.SelectByIDChuaThanhtoan(Session("uId_Phieuxuat"))
        rs = objEnPhieuxuat.f_Tongtien & "$" & objEnPhieuxuat.f_Giamgia & "$" & objEnPhieuxuat.f_Tongtienthuc
        Return rs
    End Function

    'Thanh toan phieu xuat san pham
    <WebMethod(True)> _
    Public Function UpdatePhieuxuat(ByVal v_Sophieu As String, ByVal d_Ngay As String, ByVal f_Tongtienthuc As String, ByVal tienthua As String, ByVal uId_LoaiTT As String _
                                      , ByVal f_Giamgia As String, ByVal uId_Nhanvien As String, ByVal nv_Ghichu_vn As String, ByVal uId_Kho As String, f_Khachtra As String, ByVal i_Sothang As Integer, ByVal f_Giathang As Double, ByVal b_Kedon As Boolean) As String
        Dim rs As String = ""
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnCongnoSP = New CM.QLCN_CONGNO_SPEntity
        objFcCongnoSP = New BO.QLCN_CONGNO_SPFacade
        objFcPhieuxuatLoaiTT = New BO.QLMH_PHIEUXUAT_LOAITTFacade
        objEnPhieuxuatLoaiTT = New CM.QLMH_PHIEUXUAT_LOAITTEntity
        objFCGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        objEnGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        Dim checkKhoaPhieu As Boolean
        checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).b_IsKhoa
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt.Rows.Count > 0 Then
            '1. Kiem tra Quyen
            objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "DFED47F7-0C73-4169-93CB-18A2A65C8EF7")
            If Not objEnPhanQuyen.b_Enable Then
                rs = "Bạn không có quyền thanh toán phiếu!"
            End If
            If oLibP.NullProString(Session("uId_Phieuxuat")) <> Nothing Then
                '2.3 Nếu thanh toán Tiền Mặt, Chuyển khoản, Voucher
                If (Val(f_Tongtienthuc) >= 0) Then
                    'Update thong tin phieu dich vu - Header
                    With objEnPhieuxuat
                        .v_Maphieuxuat = v_Sophieu
                        .d_Ngayxuat = BO.Util.ConvertDateTime(d_Ngay)
                        .uId_Phieuxuat = oLibP.NullProString(Session("uId_Phieuxuat"))
                        .uId_Kho = uId_Kho
                        .b_Dathanhtoan = b_Kedon
                        .i_Soluog = i_Sothang
                        .f_Gia = f_Giathang
                        'Truong hop thanh toan khong thanh toan tu the
                        If (Session("uId_Khachhang_Goidichvu_TT") = Nothing) Then
                            'Manhtt:Truong hop khach hang tra thua tien thi luu so tien thuc nhan
                            .f_Tongtienthuc = Val(f_Tongtienthuc)
                            .uId_LoaiTT = uId_LoaiTT ' Mặc định là tiền mặt
                            If uId_LoaiTT <> "163d42af-840f-4877-9c26-b079cde2a636" And uId_LoaiTT <> "2391e70e-951c-40db-a985-4ba41f888bf9" Then 'Neu loai hinh thanh toan khac voi hinh thuc nhieu hinh thuc

                                objEnPhieuxuatLoaiTT.uId_LoaiTT = uId_LoaiTT
                                objEnPhieuxuatLoaiTT.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                                objEnPhieuxuatLoaiTT.f_Sotien = f_Tongtienthuc
                                objEnPhieuxuatLoaiTT.v_Maso = ""
                                objEnPhieuxuatLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFcPhieuxuatLoaiTT.Insert(objEnPhieuxuatLoaiTT)
                                    If tienthua <= 0 Then 'thanh toan het trong 1 lan
                                        Dim uId_Khachhang As String = Session("uId_Khachhang")
                                        Dim f_Tongthanhtoan As Double = Convert.ToDouble(f_Khachtra)
                                        chekKHTtd(uId_Khachhang, f_Tongthanhtoan, v_Sophieu, "Mua phiếu mặt hàng")
                                        'If chekKHTtd(Session("uId_Khachhang").ToString, f_Khachtra, v_Sophieu, "Mua phiếu mặt hàng") = True Then
                                        '    'tinh diem tich luy cho nguoi gioi thieu
                                        '    'objEnKhachhang = objFCKhachhang.SelectByID(Session("uId_Khachhang"))
                                        '    'If objEnKhachhang.uId_Nguoigioithieu <> Nothing Then
                                        '    '    chekKHTtd(objEnKhachhang.uId_Nguoigioithieu, f_Khachtra, v_Sophieu, "Người giới thiệu phiếu mặt hàng")
                                        '    'End If
                                        'End If
                                    End If
                                Catch ex As Exception

                                End Try

                            End If
                            If uId_LoaiTT = "2391e70e-951c-40db-a985-4ba41f888bf9" And checkKhoaPhieu = False Then


                                objEnPhieuxuatLoaiTT.uId_LoaiTT = uId_LoaiTT
                                objEnPhieuxuatLoaiTT.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                                objEnPhieuxuatLoaiTT.f_Sotien = f_Tongtienthuc
                                objEnPhieuxuatLoaiTT.v_Maso = ""
                                objEnPhieuxuatLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFcPhieuxuatLoaiTT.Insert(objEnPhieuxuatLoaiTT)
                                Catch ex As Exception

                                End Try
                                Try
                                    Dim table As DataTable
                                    table = objFcThechuyentien.SelectByID_TB(Session("uId_Khachhang"))
                                    If table.Rows.Count > 0 Then
                                        If table.Rows(0)("f_Sotien") < f_Tongtienthuc Then

                                            rs = "Không thể thanh toán"
                                        Else
                                            objFcThechuyentien.Update_Loai_TT_Phieuxuat(Session("uId_Khachhang").ToString, Session("uId_Phieuxuat").ToString)
                                        End If

                                    End If
                                Catch ex As Exception

                                End Try


                            End If
                        Else 'Truong hop thanh toan tu the thi set Tong tien thuc = 0
                            .uId_LoaiTT = "01d16c43-7a03-49dc-afd2-39e79a1439f1" ' Truong hop thanh toan tu the
                            'Insert vao bang ke khai loai thanh (luu tru du lieu thanh toan phieu bang the)
                            If Val(tienthua) > 0 Then
                                'Truong hop so tien cua the thanh toan nho hon so tien phai thanh toan
                                .f_Tongtienthuc = Val(f_Tongtienthuc) 'Truong hop nay thi tien thuc chinh la tien cua the
                                objEnGoi.f_Sotien = 0
                                objEnPhieuxuatLoaiTT.uId_LoaiTT = objFCPhieuDVLoaiTT.QLTC_LoaiHinhTT_SelectByMa("THE")
                                objEnPhieuxuatLoaiTT.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                                objEnPhieuxuatLoaiTT.f_Sotien = f_Tongtienthuc
                                objEnPhieuxuatLoaiTT.v_Maso = Session("v_MaTTT")
                                objEnPhieuxuatLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFcPhieuxuatLoaiTT.Insert(objEnPhieuxuatLoaiTT)
                                Catch ex As Exception

                                End Try
                            Else
                                'Truong hop so tien the thanh toan nhieu hon hoc bang
                                .f_Tongtienthuc = Val(f_Tongtienthuc) + Val(tienthua)
                                objEnGoi.f_Sotien = Math.Abs(Val(tienthua))
                                objEnPhieuxuatLoaiTT.uId_LoaiTT = objFCPhieuDVLoaiTT.QLTC_LoaiHinhTT_SelectByMa("THE")
                                objEnPhieuxuatLoaiTT.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                                objEnPhieuxuatLoaiTT.f_Sotien = Val(f_Tongtienthuc) + Val(tienthua)
                                objEnPhieuxuatLoaiTT.v_Maso = Session("v_MaTTT")
                                objEnPhieuxuatLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
                                Try
                                    objFcPhieuxuatLoaiTT.Insert(objEnPhieuxuatLoaiTT)
                                Catch ex As Exception

                                End Try
                            End If
                            objEnGoi.uId_Khachhang_Goidichvu = oLibP.NullProString(Session("uId_Khachhang_Goidichvu_TT"))
                            objFCGoi.ThanhToan(objEnGoi)
                            Session("uId_Khachhang_Goidichvu_TT") = Nothing
                        End If
                        .f_Giamgia_Tong = Val(f_Giamgia)
                        .uId_Nhanvien = uId_Nhanvien
                        .nv_Noidungxuat_vn = nv_Ghichu_vn
                        Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLockBill")
                        If oThamsohethong.v_Giatri = "1" Then
                            .b_IsKhoa = True
                        Else
                            .b_IsKhoa = False
                        End If
                    End With
                    If (objFcPhieuxuat.Update(objEnPhieuxuat)) Then
                        rs = "Thanh toán thành công!"
                    Else
                        rs = "Có lỗi xảy ra!"
                    End If
                    objFcPhieuxuat = Nothing
                Else
                    rs = "Không có phiếu thanh toán"
                End If
                '3. Neu khach hang co lo thi chuyen vao Cong no KH
                If Val(tienthua) > 0 Then
                    objEnCongnoSP.uId_Phieuxuat = oLibP.NullProString(Session("uId_Phieuxuat"))
                    objEnCongnoSP.f_Sotien = tienthua
                    objFcCongnoSP.Insert(objEnCongnoSP)
                End If
            Else
                rs = "Không có thông tin phiếu để thanh toán!"
            End If
        Else
            rs = "Phiếu đã khóa!"
        End If
        Return rs
    End Function

    'Load thong tin phieu xuat
    <WebMethod(True)> _
    Public Function LoadThongTinPhieuXuat(ByVal uId_Phieuxuat As String) As String
        Dim rs As String
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(uId_Phieuxuat)
        rs = objEnPhieuxuat.v_Maphieuxuat & "$" & objEnPhieuxuat.uId_Kho & "$" & objEnPhieuxuat.uId_Khachhang & "$" & objEnPhieuxuat.d_Ngayxuat _
            & "$" & objEnPhieuxuat.nv_Noidungxuat_vn & "$" & objEnPhieuxuat.f_Giamgia_Tong & "$" & objEnPhieuxuat.nv_Noidungxuat_en & "$" & objEnPhieuxuat.f_Tongtienthuc _
            & "$" & objEnPhieuxuat.uId_LoaiTT & "$" & objEnPhieuxuat.uId_Nhanvien & "$" & objEnPhieuxuat.b_Dathanhtoan & "$" & objEnPhieuxuat.i_Soluog & "$" & objEnPhieuxuat.f_Gia
        Return rs
    End Function

    ''Check ton tai SDT, Email Khachhang tiem nang
    <WebMethod(True)> _
    Public Function CheckExistEmailSDT(ByVal SDT As String, ByVal Email As String) As String
        objFcKHTiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim rs As String = ""
        Dim dt As DataTable
        If Email = "N/A" Then
            dt = objFcKHTiemnang.KiemtraTontaiSDT(SDT, "N/A")
            If dt.Rows.Count > 0 And Session("uId_KH_Tiemnang") = Nothing Then
                rs = "existsdt"
            Else
                rs = "correctsdt"
            End If
        End If
        If SDT = "N/A" Then
            dt = objFcKHTiemnang.KiemtraTontaiSDT("N/A", Email)
            If dt.Rows.Count > 0 And Session("uId_KH_Tiemnang") = Nothing Then
                rs = "existemail"
            Else
                rs = "correctemail"
            End If
        End If
        Return rs
    End Function

    'Load Thong tin khach hang tiem nang
    <WebMethod()> _
    Public Function LoadThongTinKhachHangTiemNang(ByVal uId_KHTiemnang As String, ByVal uId_Chuyendoi As String) As String
        Dim rs As String
        objFcKHTiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnKHTiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFcMKTChuyendoi = New BO.MKT_ChuyendoiFacade
        Dim uId_TrangthaiKH As String
        uId_TrangthaiKH = objFcMKTChuyendoi.SelectByID(uId_Chuyendoi).uId_TrangthaiKH
        objEnKHTiemnang = objFcKHTiemnang.SelectByID(uId_KHTiemnang)
        rs = objEnKHTiemnang.d_Ngaynhap & "$" & objEnKHTiemnang.v_Makhachhang & "$" & objEnKHTiemnang.nv_Hoten_vn &
            "$" & objEnKHTiemnang.d_Ngaysinh.Year & "$" & objEnKHTiemnang.b_Gioitinh & "$" & objEnKHTiemnang.nv_Diachi_vn &
              "$" & objEnKHTiemnang.v_DienthoaiDD & "$" & objEnKHTiemnang.v_Email & "$" & objEnKHTiemnang.uId_Cuahang &
              "$" & objEnKHTiemnang.Ghichu & "$" & uId_TrangthaiKH



        Return rs
    End Function

    'Tao moi ma khach hang tiem nang
    <WebMethod(True)> _
    Public Function CreateNewCustomerMarketCode() As String
        Dim strMaKH As String = ""
        objFcKHTiemnang = New BO.MKT_KH_TIEMNANGFacade
        If Session("uId_KH_Tiemnang") = Nothing Then
            strMaKH = objFcKHTiemnang.MaKH()
            If strMaKH.Length < 6 Then
                For i As Integer = strMaKH.Length To 5
                    strMaKH = "0" + strMaKH
                Next
            End If
        End If
        Return strMaKH
    End Function

    'Lay thong tin the tai khoan khach hang theo ma barcode
    <WebMethod(True)> _
    Public Function GetBarCodeCard(ByVal v_BarCode As String) As String
        Dim rs As String
        objEnGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        objFCGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        objEnGoi = objFCGoi.SelectByvMaBarcode(v_BarCode)
        rs = objEnGoi.uId_Khachhang_Goidichvu & "$" & objEnGoi.f_Giatrigoi
        Return rs
    End Function
#End Region
    'Xuan hieu - 2910
#Region "dịch vụ"
    <WebMethod()> _
    Public Function loadDichvu(uId_Dichvu As String) As String
        Dim dv As String
        objFcDMDichvu = New BO.TNTP_DM_DICHVUFacade
        objEnDMDichvu = New CM.TNTP_DM_DICHVUEntity
        objEnDMDichvu = objFcDMDichvu.SelectByID(uId_Dichvu)
        dv = objEnDMDichvu.nv_Tendichvu_vn & "$" & objEnDMDichvu.uId_Nhomdichvu & "$" & objEnDMDichvu.f_Gia & "$" & objEnDMDichvu.f_Phidichvu &
         "$" & objEnDMDichvu.uId_Ngoaite & "$" & objEnDMDichvu.f_Sophutchuanbi & "$" & objEnDMDichvu.f_Sophutthuchien & "$" & objEnDMDichvu.i_Solan_Dieutri &
         "$" & objEnDMDichvu.b_Goidichvu & "$" & objEnDMDichvu.b_TinhHoahong & "$" & objEnDMDichvu.b_Tinhthue & "$" & objEnDMDichvu.f_PhantramHH_TVV &
         "$" & objEnDMDichvu.f_PhantramHH_CTV & "$" & objEnDMDichvu.f_PhantramHH_KTV & "$" & objEnDMDichvu.f_PhantramHH_NV & "$" & objEnDMDichvu.f_Gia_Giam & "$" & objEnDMDichvu.i_Songayquaylai
        Return dv
    End Function
    'xuanhieu 290115 them anh vao cong doan dich vu
    <WebMethod()> _
    Public Function CongdoanImageInsert(nv_Hinhanh As String, uId_QT_Dieutri As String) As String
        Dim i As Integer = 0
        Dim msg As String = ""
        Dim dt As DataTable
        Dim objEnDieutriHinhanh As New CM.cls_TNTP_QT_Dieutri_Hinhanh
        Dim objFcDieutriHinhanh As New BO.clsB_TNTP_Dieutri_Hinhanh
        Try
            dt = objFcDieutriHinhanh.SelectByuId_Dieutri(uId_QT_Dieutri)
            i = dt.Rows.Count
            If i < 6 Then
                objEnDieutriHinhanh.nv_Hinhanh_nv = nv_Hinhanh
                objEnDieutriHinhanh.uId_QT_Dieutri = uId_QT_Dieutri
                objFcDieutriHinhanh.Insert(objEnDieutriHinhanh)
                msg = "Thêm ảnh thành công"
            Else
                msg = "Số ảnh đã tối đa 6 tấm"
            End If
        Catch ex As Exception
        End Try
        Return msg
    End Function

    <WebMethod()> _
    Public Function DeleteHinhanhCongdoan(uId_HinhanhCongdoan As String) As String
        Dim msg As String = ""
        Dim objFcDieutriHinhanh As New BO.clsB_TNTP_Dieutri_Hinhanh
        Try
            objFcDieutriHinhanh.Delete(uId_HinhanhCongdoan)
            msg = "Xóa ảnh thành công"
        Catch ex As Exception

        End Try
        Return msg
    End Function
    'hieutx luu goi dichvu
    <WebMethod()> _
    Public Function InsertGoidichvu(sPara As String) As String
        Dim sList() As String
        sList = sPara.Split("$")
        Dim str As String = ""
        objEnGoidichvu = New CM.TNTP_GOIDICHVU_DICHVUEntity
        objFcGoidichvu = New BO.TNTP_GOIDICHVU_DICHVUFacade
        Try
            objEnGoidichvu = objFcGoidichvu.SelectByID(sList(1).ToString, sList(2).ToString)
            If objEnGoidichvu.uId_Goidichvu = "" Then
                With objEnGoidichvu
                    .uId_Goidichvu = sList(1).ToString
                    .uId_Dichvu = sList(2).ToString
                    .f_Soluong = Convert.ToDouble(sList(3))
                    .f_Dongia = Convert.ToDouble(sList(4))
                    .f_Thanhtien = objEnGoidichvu.f_Dongia * objEnGoidichvu.f_Soluong
                End With
                objFcGoidichvu.Insert(objEnGoidichvu)
                str = "Thêm mới thành công"
            Else
                With objEnGoidichvu
                    .f_Soluong = Convert.ToDouble(sList(3))
                    .f_Dongia = Convert.ToDouble(sList(4))
                    .f_Thanhtien = objEnGoidichvu.f_Dongia * objEnGoidichvu.f_Soluong
                End With
                objFcGoidichvu.Update(objEnGoidichvu)
                str = "Cập nhật thành công"
            End If
        Catch ex As Exception
            Log.WriteLog("InsertGoidichvu:", ex.Message)
        End Try
        Return str
    End Function
#End Region
#Region "mat hang"
    <WebMethod()> _
    Public Function loadmathang(uId_Mathang As String) As String
        Dim mh As String
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFcDonviQD = New BO.DMQuyDoiDonViFacade
        objEnDonviQD = New CM.DMQuyDoiDonViEntity
        objEnDonviQD = objFcDonviQD.SelectByID(uId_Mathang)
        objEnMathang = objFcMathang.SelectByID(uId_Mathang)
        mh = objEnMathang.uId_Nhommathang & "$" & objEnMathang.uId_Loaimathang & "$" & objEnMathang.uId_Xuatxu & "$" & objEnMathang.v_MaMathang &
            "$" & objEnMathang.v_MaBarcode & "$" & objEnMathang.nv_TenMathang_vn & "$" & objEnMathang.f_PhantramHH_KTV & "$" & objEnMathang.f_PhantramHH_TVV &
            "$" & objEnMathang.f_PhantramHH_NV & "$" & objEnMathang.f_PhamtramHH_CTV & "$" & objEnMathang.f_Hanmuc_Ton & "$" & objEnMathang.i_Songaycanhbao_Ton &
            "$" & objEnMathang.i_Songaycanhbao_HethanSD & "$" & objEnMathang.nv_Ghichu_vn & "$" & objEnDonviQD.MaDonVi1 & "$" & objEnDonviQD.MaDonVi21 &
            "$" & objEnDonviQD.MaDonVi32 & "$" & objEnDonviQD.SoLuong21 & "$" & objEnDonviQD.SoLuong32 & "$" & objEnMathang.f_Gianhap & "$" & objEnMathang.f_Giaban
        Return mh
    End Function
    <WebMethod(True)> _
    Public Function CreateNewProductCode() As String
        Dim objfcDm_Mhathang = New BO.QLMH_DM_MATHANGFacade
        Dim strMa As String = ""
        strMa = objfcDm_Mhathang.CreateMa()
        If strMa.Length < 6 Then
            For i As Integer = strMa.Length To 5
                strMa = "0" + strMa
            Next
        End If
        strMa = "SP" + strMa
        Return strMa
    End Function
    'xuanhieu 121214
    <WebMethod(True)> _
    Public Function LoadPhieunhapThanhtoan() As String
        Dim str As String = ""
        objFcPhieunhap = New BO.clsB_Phieunhap
        objEnPhieunhap = New CM.cls_Phieunhap
        objEnPhieunhap = objFcPhieunhap.SelectByID(Session("uId_Phieunhap"))
        str = objEnPhieunhap.f_Giamgia & "$" & objEnPhieunhap.f_Tongtien & "$" & objEnPhieunhap.f_Tongthanhtoan
        Return str
    End Function

    <WebMethod(True)> _
    Public Function UpdatePhieunhap(f_Tongtienthuc As String, tienthieu As String, f_Giamgia As String) As String
        Dim str As String = ""
        objFcPhieunhap = New BO.clsB_Phieunhap
        objEnPhieunhap = New CM.cls_Phieunhap
        objEnPhieunhapCn = New CM.cls_Phieunhap_Congno
        objFcPhieunhapCn = New BO.clsB_Phieunhap_Congno
        objFcPhieunhapCnTt = New BO.clsB_Phieunhap_Congno_Thanhtoan
        objEnPhieunhapCnTt = New CM.cls_Phieunhap_Congno_Thanhtoan
        Dim f_tongthanhtoan As Double
        f_tongthanhtoan = objFcPhieunhap.SelectByID(Session("uId_Phieunhap").ToString).f_Tongthanhtoan
        Try
            If f_tongthanhtoan = 0 Then
                objFcPhieunhap.UpdateTongthucte(Session("uId_Phieunhap"), Double.Parse(f_Giamgia), Double.Parse(f_Tongtienthuc))
                If Convert.ToDouble(tienthieu) <> 0 Then
                    With objEnPhieunhapCn
                        .f_Tienno = Double.Parse(tienthieu)
                        .uId_Phieunhap = Session("uId_Phieunhap")
                        .uId_Thuchi = "984614f3-3304-4185-87a3-d27be7c91f00"
                    End With
                    objFcPhieunhapCn.Insert(objEnPhieunhapCn)
                End If
                str = "Success"
            Else
                str = "phiếu nhập này không được phép chỉnh sửa thông tin"
            End If
        Catch ex As Exception
        End Try
        Return str
    End Function
    'hieutx 190615 ma barecode
    <WebMethod(True)> _
    Public Function loadMavach(Luachon As String) As String
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Dim dblMa As Double
        Dim strCode As String
        Dim strMaCH As String
        strMaCH = objFCThamsohethong.SelectTHAMSOHETHONGByID("v_Macuahang").v_Giatri
        Dim str As String = ""
        Try
            If Luachon = "128" Then
                objEnMathang = objFcMathang.SelectBarcodeMax(strMaCH + "SP")
                dblMa = Val(Right(objEnMathang.v_MaBarcode, 10)) + 1
                strCode = CStr(dblMa)
                If strCode.Length < 10 Then
                    For i As Integer = strCode.Length To 9
                        strCode = "0" + strCode
                    Next
                End If
                str = strMaCH + "SP" + strCode
            Else
                objEnMathang = objFcMathang.SelectBarcodeMax(pc.BarcodeSP)
                dblMa = Val(Mid(objEnMathang.v_MaBarcode, 8, 12)) + 1
                strCode = CStr(dblMa)
                If strCode.Length < 5 Then
                    For i As Integer = strCode.Length To 4
                        strCode = "0" + strCode
                    Next
                End If
                strCode = pc.BarcodeSP + strCode
                str = InsertCheckSum(strCode)
            End If
        Catch ex As Exception

        End Try
        Return str
    End Function
    'hieutx 2206 using barcode
    <WebMethod()> _
    Public Function GetInfoProductByBarcode(v_Barcode As String) As String
        Dim str As String
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        str = objFcMathang.SelectBarcodeMax(v_Barcode).uId_Mathang
        If str = Nothing Then
            str = "null"
        End If
        Return str
    End Function
    'hieutx 2206 using insert or update phieu xuat
    <WebMethod(True)> _
    Public Function InsertPhieuxuat(sPara As String) As String
        Dim str As String = ""
        Dim sList() As String
        sList = sPara.Split("$")
        If Session("uId_Khachhang") <> Nothing Then
            objFCPhanQuyen = New BO.QT_PHANQUYENFacade
            objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
            objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
            objFCNhatKy = New BO.NHATKYSUDUNGFacade
            Dim checkKhoaPhieu As Boolean
            checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).b_IsKhoa
            Dim dt_KP As New DataTable
            'khoa so nghiep vu
            dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
            If checkKhoaPhieu = False Or dt_KP.Rows.Count > 0 Then
                Dim sUid_Phieuxuat As String = ""
                objEnPhieuxuat.uId_Khachhang = Session("uId_Khachhang")
                objEnPhieuxuat.uId_Kho = sList(0)
                objEnPhieuxuat.uId_Nhanvien = sList(1)
                objEnPhieuxuat.v_Maphieuxuat = sList(2)
                objEnPhieuxuat.d_Ngayxuat = BO.Util.ConvertDateTime(sList(3))
                objEnPhieuxuat.nv_Noidungxuat_vn = sList(4)
                objEnPhieuxuat.b_Dathanhtoan = Boolean.Parse(sList(5)) 'chi ke
                objEnPhieuxuat.i_Soluog = Convert.ToInt32(sList(6)) 'so thang
                If Session("uId_Phieuxuat") = Nothing Then
                    objEnPhieuxuat.f_Giamgia_Tong = 0
                    objEnPhieuxuat.f_Tongtienthuc = 0
                    Dim dt_Test As DataTable
                    dt_Test = objFcPhieuxuat.SelectBySoPhieuXuat(sList(2))
                    If dt_Test.Rows.Count > 0 Then
                        str = "1$Trùng mã phiếu"
                    Else
                        sUid_Phieuxuat = objFcPhieuxuat.Insert(objEnPhieuxuat)
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu xuất mã " & sList(2))
                        str = "2$Thêm mới thành công"
                        Session("uId_Phieuxuat") = sUid_Phieuxuat
                    End If
                Else
                    objEnPhieuxuat.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                    objFcPhieuxuat.Update(objEnPhieuxuat)
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu xuất mã " & sList(2))
                    str = "3$Cập nhật thành công"
                End If
            Else
                str = "4$Phiếu đã khóa"
            End If
        Else
            str = "5$Chưa chọn khách hàng!"
        End If
        Return str
    End Function
    'hieutx 2206 using insert or update phieu nhap
    <WebMethod(True)> _
    Public Function InsertPhieunhap(Spara As String) As String
        Dim str As String
        Dim sList() As String
        sList = Spara.Split("$")
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim sUid_Phieunhap As String = ""
        objEnPhieunhap.v_Maphieunhap = sList(0)
        objEnPhieunhap.d_Ngaynhap = BO.Util.ConvertDateTime(sList(1))
        objEnPhieunhap.nv_Noidung_vn = sList(2)
        objEnPhieunhap.uId_Kho = sList(3)
        objEnPhieunhap.uId_Nhacungcap = sList(4)
        objEnPhieunhap.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
        objEnPhieunhap.f_Giamgia = 0
        objEnPhieunhap.f_Tongthanhtoan = 0
        objEnPhieunhap.f_Tongtien = 0
        If Session("uId_Phieunhap") = Nothing Then
            sUid_Phieunhap = objFcPhieunhap.Insert(objEnPhieunhap)
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu nhập mã " & sList(0))
            Session("uId_Phieunhap") = sUid_Phieunhap
            str = "0$Thêm phiếu nhập thành công!"
        Else
            objEnPhieunhap.uId_Phieunhap = Session("uId_Phieunhap").ToString
            objFcPhieunhap.Update(objEnPhieunhap)
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu nhập mã " & sList(0))
            str = "1$Cập nhật phiếu nhập thành công!"
        End If
        Return str
    End Function
    'hieutx 2306 using create ma phieu nhap - xuat
    <WebMethod()> _
    Public Function CreatePhieunhapxuatCode(sPara As String) As String
        Dim str As String
        str = pc.ReturnAutoString(sPara)
        Return str
    End Function
    Private Function InsertCheckSum(ByVal code As String) As String
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim j As Integer = 11
        For i As Integer = 1 To 12
            If i Mod 2 = 0 Then
                X += Val(code(j))
            Else
                Y += Val(code(j))
            End If
            j -= 1
        Next

        Dim Z As Integer = X + (3 * Y)
        Return code + ((10 - (Z Mod 10)) Mod 10).ToString
    End Function
#End Region
#Region "Nhân viên"
    <WebMethod()> _
    Public Function loadNhanvien(uId_Nhanvien As String) As String
        Dim Nv As String
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objEnNhanvien = New CM.QT_DM_NHANVIENEntity
        objEnNhanvien = objFcNhanvien.SelectByID(uId_Nhanvien)
        Nv = objEnNhanvien.uId_Nhanvien & "$" & objEnNhanvien.v_Manhanvien & "$" & objEnNhanvien.nv_Hoten_vn & "$" & objEnNhanvien.nv_Chucvu_vn & "$" & objEnNhanvien.d_Ngaysinh &
            "$" & objEnNhanvien.nv_Diachi_vn & "$" & objEnNhanvien.d_Ngayvaolam & "$" & objEnNhanvien.v_Dienthoai & "$" & objEnNhanvien.b_Danglamviec &
            "$" & objEnNhanvien.v_Email & "$" & objEnNhanvien.v_Tendangnhap & "$" & objEnNhanvien.v_Matkhau & "$" & objEnNhanvien.b_ActiveLogin & "$" & objEnNhanvien.nv_Quequan_en
        Return Nv
    End Function
    'xuanhieu 15/11/2014 load phan quyen chuc nang
    <WebMethod()> _
    Public Function LoadPhanquyen(uId_Nhanvien As String) As String
        Dim quyenhan As String = ""
        Dim Strsplit As String = "$"
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        Dim dt As DataTable
        Try
            dt = objFCPhanQuyen.SelectByuId_Nhanvien(uId_Nhanvien)
            If dt.Rows.Count > 0 Then
                Dim Strstart As String = dt.Rows(0)("uId_Chucnang").ToString
                Dim Strend As String = dt.Rows(dt.Rows.Count - 1)("uId_Chucnang").ToString
                For i As Integer = 1 To dt.Rows.Count - 2 Step 1
                    Strstart += Strsplit & dt.Rows(i)("uId_Chucnang").ToString
                Next
                quyenhan = Strstart + Strsplit + Strend
            Else
                dt.Rows.Add(dt.NewRow)
            End If
        Catch ex As Exception

        End Try
        Return quyenhan
    End Function
    'xuanhieu 17/11/2014 insert phan quyen chuc nang
    <WebMethod()> _
    Public Function InertPhanquyen(uid_chucnang As String, uid_nhanvien As String) As String
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        Dim tb As String = ""
        Try
            With objEnPhanQuyen
                .b_Enable = True
                .b_Visible = True
                .uId_Nhanvien = uid_nhanvien
                .uId_Chucnang = uid_chucnang
            End With
            If objFCPhanQuyen.CheckPhanquyen(uid_chucnang, uid_nhanvien) = True Then
                objFCPhanQuyen.Update(objEnPhanQuyen)
                tb = "chức năng đã được kích hoạt"
            Else
                objFCPhanQuyen.Insert(objEnPhanQuyen)
                tb = "Thêm mới chức năng cho nhân viên thành công"
            End If
            Dim dt As DataTable
            dt = objFCPhanQuyen.SelectByuId_Nhanvien(uid_nhanvien)
            Dim sochucnang As Integer = dt.Rows.Count
            tb += "$" + sochucnang.ToString
        Catch ex As Exception

        End Try
        Return tb
    End Function
    'xuanhieu 17/11/2014 delete phan quyen chuc nang
    <WebMethod()> _
    Public Function DeletePhanquyen(uid_chucnang As String, uid_nhanvien As String) As String
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        Dim tb As String = ""
        Try
            If objFCPhanQuyen.DeleteByID(uid_nhanvien, uid_chucnang) = True Then
                tb = "Xóa chức năng của nhân viên thành công"
                Dim dt As DataTable
                dt = objFCPhanQuyen.SelectByuId_Nhanvien(uid_nhanvien)
                Dim sochucnang As Integer = dt.Rows.Count
                tb += "$" + sochucnang.ToString
            End If
        Catch ex As Exception
        End Try
        Return tb
    End Function
    'xuanhieu 21/11/2014 them het phan quyen
    <WebMethod()> _
    Public Function InsertAllPhanquyen(uid_nhanvien As String) As String
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFcChucnang = New BO.QT_DM_CHUCNANGFacade
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        Dim dtcn As DataTable
        Dim j As Integer = 0
        Dim str As String = ""
        dtcn = objFcChucnang.Selectquyenhan()
        objFCPhanQuyen.DeleteAllById(uid_nhanvien)
        Try
            For Each rowcn As DataRow In dtcn.Rows
                With objEnPhanQuyen
                    .uId_Chucnang = rowcn("uId_Chucnang").ToString
                    .uId_Nhanvien = uid_nhanvien
                    .b_Visible = True
                    .b_Enable = True
                End With
                objFCPhanQuyen.Insert(objEnPhanQuyen)
                j += 1
            Next
        Catch ex As Exception
        End Try
        str = "Thêm mới " + j.ToString + " Chức năng cho nhân viên"
        dtcn.Dispose()
        Return str
    End Function
    'xuanhieu-21/11/2014 xoa tat ca chuc nang cua 1 nhan vien
    <WebMethod()> _
    Public Function DeleteAllPhanquyen(uid_nhanvien As String) As String
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        Dim str As String = ""
        Try
            If uid_nhanvien <> "44E842B8-8BBB-47F1-A0D1-9F16C1E0899C" Then
                objFCPhanQuyen.DeleteAllById(uid_nhanvien)
                str = "Xóa tất cả chức năng của nhân viên thành cônng !"
            End If

        Catch ex As Exception

        End Try
        Return str
    End Function
#End Region
#Region "Util Method"
    <WebMethod(True)> _
    Public Function ClearSession(ByVal sessionname As String) As String
        If HttpContext.Current.Session(sessionname) <> Nothing Then
            HttpContext.Current.Session(sessionname) = Nothing
            Return "1"
        Else
            Return "0"
        End If
    End Function
    <WebMethod(True)> _
    Public Sub CreateSession(ByVal sessionname As String, ByVal value As String)
        HttpContext.Current.Session(sessionname) = value
    End Sub
    <WebMethod(True)> _
    Public Function GetSession(ByVal sessionname As String) As String
        Return HttpContext.Current.Session(sessionname)
    End Function
    <WebMethod(True)> _
    Public Function CheckRole(ByVal uId_Chucnang As String) As String
        Dim rs As String = ""
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, uId_Chucnang)
        If objEnPhanQuyen.b_Enable = False Then
            rs = "false"
        Else
            rs = "true"
        End If
        Return rs
    End Function
#End Region

#Region "the tich diem"
    'them mot muc chuyen doi tien thanh diem 
    <WebMethod()> _
    Public Function Update_Addpoint(uId_Thetichdiem As String, f_Giatri As Double, i_Diem As Integer) As String
        Dim str As String = ""
        Dim objEnChuyendoi As New CM.cls_TTV_DM_Thetichdiem_ChuyendoiEntity
        Dim objFcChuyendoi As New BO.clsB_TTV_DM_Thetichdiem_Chuyendoi
        Dim dt As DataTable
        dt = objFcChuyendoi.SelectByIdThe(uId_Thetichdiem)
        If dt.Rows.Count > 0 Then 'da co chi update
            With objEnChuyendoi
                .uId_TTDChuyendoi = dt.Rows(0)("uId_TTDChuyendoi").ToString
                .uId_Thetichdiem = uId_Thetichdiem
                .f_Giatri = f_Giatri
                .i_Diem = i_Diem
                .nv_Tenchuyendoi = "Tổng tiền"
                .v_Machuyendoi = dt.Rows(0)("v_Machuyendoi").ToString
                .b_Trangthai = True
            End With
            objFcChuyendoi.Update(objEnChuyendoi)
            str = "Chỉnh sửa thành công"
        Else ' them moi 1 muc chuyen doi
            With objEnChuyendoi
                .uId_Thetichdiem = uId_Thetichdiem
                .f_Giatri = f_Giatri
                .i_Diem = i_Diem
                .v_Machuyendoi = pc.ReturnAutoString("TTD")
                .nv_Tenchuyendoi = "Tổng tiền"
                .b_Trangthai = True
            End With
            objFcChuyendoi.Insert(objEnChuyendoi)
            str = "Thêm mới thành công"
        End If
        Return str
    End Function
    'xuanhieu thuc hien tich diem tu dong cho khach hang
    Public Function chekKHTtd(uId_Khachhang As String, f_tongtienthuc As Double, v_Sophieu As String, nv_noidung As String) As Boolean
        Dim dtttd As DataTable
        Dim dtdmThe As DataTable
        objEnThetichdiem = New CM.cls_TTV_KH_ThetichdiemEntity
        objFcThetichdiem = New BO.clsB_TTV_KH_Thetichdiem
        objFcTTDChuyendoi = New BO.clsB_TTV_DM_Thetichdiem_Chuyendoi
        objEnTTDLichsu = New CM.cls_TTV_KH_Thetichdiem_LichsuEntity
        objFcTTDLichsu = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
        objFcDMthetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Try
            dtttd = objFcThetichdiem.SelectByIdKH(uId_Khachhang)
            If dtttd.Rows.Count > 0 Then 'co the tich diem
                If dtttd.Rows(0)("b_Trangthai") = True Then ' the dang duoc kick hoat
                    dtdmThe = objFcDMthetichdiem.SelectAllTable(Session("uId_Cuahang").ToString)
                    If dtdmThe.Rows.Count > 0 Then ' the cua khach co trong muc chuyen doi 
                        For i As Integer = 0 To dtdmThe.Rows.Count - 1
                            If dtdmThe.Rows(i)("uId_Thetichdiem").ToString = dtttd.Rows(0)("uId_Thetichdiem").ToString Then
                                'Dim f_giatri As Double = Convert.ToDouble(dtdmThe.Rows(i)("f_Sotiendoi").ToString)
                                'Dim i_Diem As Integer = dtdmThe.Rows(i)("i_Sodiemdoi")
                                'Dim AutoAddPoint As Integer = i_Diem * Val(f_tongtienthuc) / f_giatri
                                Dim AutoAddPoint As Double = f_tongtienthuc
                                Dim dtdiem As DataTable
                                dtdiem = objFcThetichdiem.SelectPointById(dtttd.Rows(0)("uId_KH_The").ToString)
                                Dim f_Tongdiemtl As Double = Convert.ToDouble(dtdiem.Rows(0)("f_Tongtichluy").ToString) + AutoAddPoint
                                Dim f_diemht As Double = Convert.ToDouble(dtdiem.Rows(0)("f_Diemhientai").ToString) + AutoAddPoint
                                objFcThetichdiem.UpdatePoint(f_Tongdiemtl, f_diemht, dtttd.Rows(0)("uId_KH_The").ToString)
                                'luu vao bang lich su tich diem
                                With objEnTTDLichsu
                                    .f_Diem = AutoAddPoint
                                    .d_Ngaythuchien = Date.Now.ToString
                                    .b_Luachon = True
                                    '.nv_Noidung = nv_noidung + " mã " + v_Sophieu + " mức quy đổi " + dtdmThe.Rows(i)("f_Sotiendoi").ToString + " - " + dtdmThe.Rows(i)("i_Sodiemdoi").ToString
                                    .nv_Noidung = nv_noidung + " mã " + v_Sophieu
                                    .uId_KH_The = dtttd.Rows(0)("uId_KH_The").ToString
                                    .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
                                    .uId_Sukien = Nothing
                                End With
                                objFcTTDLichsu.Insert(objEnTTDLichsu)
                            End If

                        Next
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'get du lieu chuyen doi tien thanh diem theo id the tich diem
    <WebMethod()> _
    Public Function Getchuyendoidiem(uId_Thetichdiem As String) As String
        Dim st As String = ""
        objFcTTDChuyendoi = New BO.clsB_TTV_DM_Thetichdiem_Chuyendoi
        Dim dt As DataTable
        dt = objFcTTDChuyendoi.SelectByIdThe(uId_Thetichdiem)
        If dt.Rows.Count > 0 Then
            st += dt.Rows(0)("f_Giatri").ToString & "$" & dt.Rows(0)("i_Diem").ToString
        End If
        Return st
    End Function

    'get muc uu tien cua ttd
    <WebMethod()> _
    Public Function GetMucuutienTTD(uId_Khachhang As String) As String
        objFcDMthetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim str As String = ""
        Try
            str = objFcDMthetichdiem.SelectUutienByKH(uId_Khachhang)
            Return str
        Catch ex As Exception
            Log.WriteLog("Select uutien the tich diem:", ex.Message)
            Return ""
        End Try
    End Function
#End Region
#Region "phieu thu chi "
    'Lay thong tin phieu thu chi
    <WebMethod()> _
    Public Function LoadPhieuthuchi(ByVal uId_Phieuthuchi As String) As String
        Dim rs As String = ""
        objEnPhieuthuchi = New CM.QLTC_PhieuthuchiEntity
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        objFcCongNoTT = New BO.QLCN_CONGNO_THANHTOANFacade
        objEnCongNoTT = New CM.QLCN_CONGNO_THANHTOANEntity
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim objFcDMThuchi As New BO.QLTC_DM_THUCHIFacade
        objEnCongNoTT = objFcCongNoTT.SelectByIDPTC(uId_Phieuthuchi)
        Dim nv_Hoten_vn As String
        If objFcNhanvien.SelectByID(objEnCongNoTT.uId_Khachhang).uId_Nhanvien <> Nothing Then
            nv_Hoten_vn = objFcNhanvien.SelectByID(objEnCongNoTT.uId_Khachhang).nv_Hoten_vn
        Else
            nv_Hoten_vn = objFCKhachhang.SelectByID(objEnCongNoTT.uId_Khachhang).nv_Hoten_vn

        End If
        objEnPhieuthuchi = objFcPhieuthuchi.SelectByID(uId_Phieuthuchi)
        rs = objEnPhieuthuchi.v_Maphieu & "$" & objEnPhieuthuchi.uId_Thuchi & "$" & objEnPhieuthuchi.d_Ngay &
            "$" & objEnPhieuthuchi.nv_Lydo_vn & "$" & objEnPhieuthuchi.f_Sotien & "$" & objEnPhieuthuchi.nv_Ghichu &
            "$" & nv_Hoten_vn & "$" & objEnPhieuthuchi.uId_Nhanvien &
            "$" & objFcDMThuchi.SelectByID(objEnPhieuthuchi.uId_Thuchi).b_ThuChi
        Return rs
    End Function
    'hieutx 230615 tao ma phieu thu chi
    <WebMethod(True)> _
    Public Function CreateMaphieuthuchi(ddate As String, sLoaiphieu As String) As String
        Dim str As String = ""
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        Dim strMa As String
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        Dim sdate As Date = BO.Util.ConvertDateTime(ddate)
        Try
            strMa = objFcPhieuthuchi.GetMaMaxBydate(Session("uId_Cuahang").ToString, sdate, sLoaiphieu)
            If strMa.Length < 4 Then
                For m As Integer = strMa.Length To 3
                    strMa = "0" + strMa
                Next
            End If
            str = ReturnStringByDate(sLoaiphieu, BO.Util.ConvertDateTime(ddate)) + strMa
        Catch ex As Exception

        End Try

        Return str
    End Function
#End Region
    <WebMethod(True)> _
    Public Function LoadThongTinResource(Resource As Integer, dStart As DateTime, dEnd As DateTime) As String
        objFcResource = New BO.ResourcesFacade
        Dim dt As DataTable
        Dim str As String = "Yes"
        Dim uId_Nhanvien As String = objFcResource.SelectByResourceId(Resource)
        Try
            If uId_Nhanvien <> "" Then
                objFcNhanvien = New BO.QT_DM_NHANVIENFacade
                dt = objFcNhanvien.SelectnhanvienByLichhen(Session("uId_Nhanvien"), dStart, dEnd, uId_Nhanvien)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        If row("uId_Nhanvien").ToString = uId_Nhanvien Then
                            If row("trangthai").ToString = "1" Then
                                str = "No"
                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
        Return str
    End Function
    <WebMethod()> _
    Public Function Checkdichvu(ByVal uId_Phieudichvu_Chitiet As String, ByVal uId_Phieudichvu As String)

        Dim objFCPhieuChitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objEnPhieudichvu_chitiet = objFCPhieuChitiet.SelectByIDDichvu(uId_Phieudichvu, uId_Phieudichvu_Chitiet)
        objFcDMDichvu = New BO.TNTP_DM_DICHVUFacade
        objEnDMDichvu = New CM.TNTP_DM_DICHVUEntity
        Dim str As String = ""
        Dim dt As DataTable = objFCPhieuChitiet.CheckDV(objEnPhieudichvu_chitiet.uId_Phieudichvu_Chitiet)
        Dim tiendv As Double
        Dim tientip As Double
        objEnDMDichvu = objFcDMDichvu.SelectByID(uId_Phieudichvu_Chitiet)
        If (dt.Rows(0)("f_Dongia") * dt.Rows(0)("f_Soluong") = dt.Rows(0)("f_Tongtien") And Convert.ToDouble(dt.Rows(0).Item("f_Tongtien")) > 0) Then
            str = objEnDMDichvu.f_PhantramHH_KTV & "$" & objEnDMDichvu.f_PhantramHH_NV
        ElseIf dt.Rows(0)("f_Dongia") * dt.Rows(0)("f_Soluong") - dt.Rows(0)("f_Tongtien") > 0 Then
            tiendv = objEnDMDichvu.f_PhantramHH_KTV * 0.7
            tientip = objEnDMDichvu.f_PhantramHH_NV * 0.7
            str = tiendv & "$" & tientip
        ElseIf dt.Rows(0)("f_Tongtien") = 0 Then
            tiendv = objEnDMDichvu.f_PhantramHH_KTV * 0.5
            tientip = 0
            str = tiendv & "$" & tientip
        End If
        Return str
    End Function
    <WebMethod()> _
    Public Function LoadInfoLuong(sPara As String) As String

        Dim str As String
        Dim sList() As String
        sList = sPara.Split("$")
        Dim dt As DataTable
        objFcLuongcoban = New BO.QLL_QUATRINHLUONGFacade
        Try
            dt = objFcLuongcoban.SelectAllTable(sList(0))
            If dt.Rows.Count > 0 Then
                str = dt.Rows(0)("uId_QuatrinhLuong").ToString & "$" & dt.Rows(0)("d_Ngayquyetdinh").ToString & "$" &
                    dt.Rows(0)("f_Mucluong_Codinh").ToString & "$" & dt.Rows(0)("f_Mucluong_Ngoaigio").ToString & "$" &
                    dt.Rows(0)("f_Mucluong_Trachnhiem").ToString & "$" & dt.Rows(0)("f_Antrua").ToString
            Else
                str = "NoInfo"
            End If
        Catch
            str = "Error"
        End Try
        Return str
    End Function
    <WebMethod()> _
    Public Function InserTTLuong(sPara As String) As String
        objFcTTLuong = New BO.QLL_THONGTINLUONGFacade
        objEnTTLuong = New CM.QLL_THONGTINLUONGEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        pc = New Public_Class
        Dim str As String = ""
        Dim Slist() As String
        Slist = sPara.Split("$")

        Try
            If objFcTTLuong.chk_CheckTTLuong(Convert.ToInt32(Slist(1)), Convert.ToInt32(Slist(2)), Slist(0)) = True Then
                objEnTTLuong = objFcTTLuong.SelectInfobyNV(Convert.ToInt32(Slist(1)), Convert.ToInt32(Slist(2)), Slist(0))
                If objEnTTLuong.b_Khoaso = True Then
                    str = "Đã khóa sổ không thể thay đổi thông tin"
                Else
                    With objEnTTLuong
                        .f_Ngaycong = pc.Convertstringtodb(Slist(3))
                        .f_Ngaynghi = pc.Convertstringtodb(Slist(4))
                        .f_Tienthuong = pc.Convertstringtodb(Slist(5))
                        .f_Tientru = pc.Convertstringtodb(Slist(6))
                        .f_Tamung = pc.Convertstringtodb(Slist(7))
                    End With
                    objFcTTLuong.Update(objEnTTLuong)
                    str = "Cập nhật thành công"
                End If
            Else
                With objEnTTLuong
                    .uId_Nhanvien = Slist(0)
                    .i_Nam = Convert.ToInt32(Slist(2))
                    .i_Thang = Convert.ToInt32(Slist(1))
                    .f_Ngaycong = pc.Convertstringtodb(Slist(3))
                    .f_Ngaynghi = pc.Convertstringtodb(Slist(4))
                    .f_Tienthuong = pc.Convertstringtodb(Slist(5))
                    .f_Tientru = pc.Convertstringtodb(Slist(6))
                    .f_Tamung = pc.Convertstringtodb(Slist(7))
                End With
                If objFcTTLuong.Insert(objEnTTLuong) Then
                    str = "Thiết lập lương cho nhân viên thành công"
                Else
                    str = "Kiểm tra lại thông tin"
                End If
            End If
        Catch ex As Exception

        End Try




        Return str
    End Function
    <WebMethod()> _
    Public Function Load_MKT_Sale(ByVal uId_Sale As String) As String
        Dim result As String = ""
        objFc_MKT_Sale = New BO.clsB_MKT_SALES
        Dim dt As DataTable = objFc_MKT_Sale.Select_ByID(uId_Sale)
        If dt.Rows.Count > 0 Then
            result = dt.Rows(0)("uId_Sale").ToString & "$" & dt.Rows(0)("nv_Tenchuongtrinh_vn").ToString & "$" &
                  dt.Rows(0)("f_Giamgia_percent").ToString & "$" & dt.Rows(0)("f_Giamgia_money").ToString & "$" &
                  dt.Rows(0)("d_Start").ToString & "$" & dt.Rows(0)("d_End").ToString
        Else
            result = "Error"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function Kiemtralichhentrung(ByVal Resource As String, ByVal dStart As DateTime, ByVal dEnd As DateTime, ByVal uId_Nhanvien As String) As String
        objFc_Lichhen = New BO.AppointmentsFacade
        Dim dt As DataTable = objFc_Lichhen.Kiemtralichhentrung(Resource, dStart, dEnd, uId_Nhanvien)
        Dim result As String = ""
        If Convert.ToInt16(dt.Rows(0).Item("b_Return")) = 2 Then
            result = "ALL"
        ElseIf Convert.ToInt16(dt.Rows(0).Item("b_Return")) = 1 Then
            result = "YES"
        Else
            result = "NO"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function Kiemtralichhentrung_Kythuat(ByVal Resource As String, ByVal dStart As DateTime, ByVal dEnd As DateTime, ByVal uId_Nhanvien As String) As String
        objFc_Lichhen = New BO.AppointmentsFacade
        Dim dt As DataTable = objFc_Lichhen.Kiemtralichhentrung_Kythuat(Resource, dStart, dEnd, uId_Nhanvien)
        Dim result As String = ""
        If Convert.ToInt16(dt.Rows(0).Item("b_Return")) = 2 Then
            result = "ALL"
        ElseIf Convert.ToInt16(dt.Rows(0).Item("b_Return")) = 1 Then
            result = "YES"
        Else
            result = "NO"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function Kiemtratrungphongdichvu(ByVal Resource As String, ByVal dStart As DateTime, ByVal dEnd As DateTime) As String
        objFc_Lichhen = New BO.AppointmentsFacade
        Dim check As Boolean = objFc_Lichhen.Kiemtratrungphongdichvu(Resource, dStart, dEnd)
        Dim result As String = ""
        If check = True Then
            result = "YES"
        Else
            result = "NO"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function Update_Thekhachhang(ByVal uId_Khachhang_Goidichvu As String) As String
        Dim objFcGoiKH As New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim check As Boolean = objFcGoiKH.Update_Khachhang_GoiDichvu(uId_Khachhang_Goidichvu)
        Dim result As String = ""
        If check = True Then
            result = "YES"
        Else
            result = "NO"
        End If
        Return result
    End Function
    <WebMethod()> _
    Public Function Insert_Hinhthuc_ThanhToan_PX(ByVal uId_LoaiTT As String, ByVal nv_Ghichu_vn As String, ByVal v_Sophieu As String, ByVal f_Sotien As Double, ByVal uId_Phieuxuat As String) As Boolean
        Dim f_Result As Boolean = False
        If uId_Phieuxuat <> Nothing Then
            Dim f_Giatrigoi As Double
            Dim objEnPhieuxuatLoaiTT = New CM.QLMH_PHIEUXUAT_LOAITTEntity
            Dim objFcPhieuxuatLoaiTT = New BO.QLMH_PHIEUXUAT_LOAITTFacade
            Dim objFCGoiDV = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
            Dim objEnGoiDV = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
            objEnPhieuxuatLoaiTT.uId_LoaiTT = uId_LoaiTT
            objEnPhieuxuatLoaiTT.uId_Phieuxuat = uId_Phieuxuat
            objEnPhieuxuatLoaiTT.f_Sotien = f_Sotien
            objEnPhieuxuatLoaiTT.v_Maso = v_Sophieu
            objEnPhieuxuatLoaiTT.nv_Ghichu_vn = nv_Ghichu_vn
            Try
                f_Result = objFcPhieuxuatLoaiTT.Insert(objEnPhieuxuatLoaiTT)
                'Lay ra gia tri goi the tai khoan cua khach hang hien tai
                objEnGoiDV = objFCGoiDV.SelectByvMaBarcode(v_Sophieu)
                f_Giatrigoi = objEnGoiDV.f_Giatrigoi

                objEnGoiDV = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
                If (f_Giatrigoi > CDbl(f_Sotien)) Then
                    objEnGoiDV.f_Sotien = f_Giatrigoi - CDbl(f_Sotien)
                Else
                    objEnGoiDV.f_Sotien = 0
                End If
                objEnGoiDV.uId_Khachhang_Goidichvu = oLibP.NullProString(Session("uId_Khachhang_Goidichvu_TT"))
                objFCGoiDV.ThanhToan(objEnGoiDV)
            Catch ex As Exception
            End Try
            objEnPhieuxuatLoaiTT = Nothing
            objFcPhieuxuatLoaiTT = Nothing
        End If
        Return f_Result
    End Function

    'huy phieu xuat
    <WebMethod()>
    Public Function huyPhieuXuat(ByVal uidPhieuxuat As String, ByVal uidKhachhang As String) As String
        Dim objEnPhieuxuat As New CM.QLMH_PHIEUXUATEntity
        Dim objEnPhieuthuhci As New CM.QLTC_PhieuthuchiEntity
        Dim objFcPhieuthuchi As New BO.QLTC_PhieuthuchiFacade
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        Try
            objEnPhieuxuat = objFcPhieuxuat.SelectByID(uidPhieuxuat)
            objEnPhieuxuat.b_Dathanhtoan = 1
            objEnPhieuxuat.nv_Noidungxuat_en = "khách hàng trả thuốc"
            objFcPhieuxuat.Update(objEnPhieuxuat)
            objEnPhieuthuhci.d_Ngay = Date.Now()
            objEnPhieuthuhci.f_Sotien = objEnPhieuxuat.f_Tongtienthuc
            objEnPhieuthuhci.uId_Cuahang = Session("uId_Cuahang")
            objEnPhieuthuhci.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
            objEnPhieuthuhci.nv_Lydo_vn = "Khách hàng trả thuốc phiếu " + objEnPhieuxuat.v_Maphieuxuat
            objEnPhieuthuhci.v_Maphieu = CreateMaphieuthuchi(Date.Now, "PC")
            objEnPhieuthuhci.nv_Ghichu = uidPhieuxuat
            objEnPhieuthuhci.b_IsKhoa = 1
            objFcPhieuthuchi.Insert(objEnPhieuthuhci)
            Return "1$Khách hàng trả thuốc thành công"
        Catch e As Exception
            Return "2$Có lỗ sảy ra khi xử lý"
        End Try
    End Function

End Class