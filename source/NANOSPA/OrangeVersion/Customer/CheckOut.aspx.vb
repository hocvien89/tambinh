Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Public Class CheckOut
    Inherits System.Web.UI.Page
    Dim objFcChoXyLy As BO.PQP_TRANGTHAIKHCHOXULYFacade
    Dim objFcDMTrangthai As BO.CRM_DM_TRANGTHAIFacade
    Dim objEnDMPhong As CM.QLP_DM_PHONGEntity
    Dim objFcDMPhong As BO.QLP_DM_PHONGFacade
    Dim objFC_dmdichvu As BO.TNTP_DM_DICHVUFacade
    Dim objFcDMKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnDMKhachhang As CM.CRM_DM_KhachhangEntity
    Dim objFCPhieuDV As BO.TNTP_PHIEUDICHVUFacade
    Dim objFCChitietDV As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Dim objEnChitietDV As CM.TNTP_PHIEUDICHVU_CHITIETEntity
    Dim objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Dim objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Dim objEnPhieuDV As CM.TNTP_PHIEUDICHVUEntity
    Dim objFC_Nhanvien As BO.QT_DM_NHANVIENFacade
    Dim objFCLoaiTT As BO.QLTC_LoaiHinhTTFacade
    Dim objFCGoiDV As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objFCHuyDV As BO.MKT_HUYDV
    Dim objEnHuyDV As CM.MKT_HUYDV
    Dim oLibP As New Lib_SAT.cls_Pub_Functions
    Dim objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim objFCNhomphieu As BO.clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
    Dim objEnGoiKH As CM.TNTP_KHACHHANG_GOIDICHVUEntity
    Dim objFCGoiKH As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objFCPhieuDVLoaiTT As BO.TNTP_PHIEUDICHVU_LOAITTFacade
    Dim objEnLoaiTT As CM.QLTC_LoaiHinhTTEntity
    Dim objEnPhieuDVLoaiTT As CM.TNTP_PHIEUDICHVU_LOAITTEntity
    Private objFCBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
    Dim objFCPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim pc As New Public_Class
    Dim nhanvien As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadDropDownList()
            objEnDMPhong = New CM.QLP_DM_PHONGEntity
            objFcDMPhong = New BO.QLP_DM_PHONGFacade
            objEnDMPhong = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current"))
            dat_Ngaychuyen.Date = DateTime.Now.ToString
            If Session("uId_Khachhang") <> Nothing Then
                LoadThongTinKhachHang(objEnDMPhong.nv_Tenphong_vn)
                dgvDanhsachphieu.DataBind()
                dgvDSPhieuno.DataBind()
                dgvDsTheTT.DataBind()
            Else
                'ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>THANH TOÁN PHIẾU CHO KHÁCH HÀNG - TẠI " & objEnDMPhong.nv_Tenphong_vn & "</p>"
            End If
            If Session("uId_Phieudichvu") <> Nothing Then
                LoadThongTinPhieuDichVu(Session("uId_Phieudichvu"))
                dgvPhieuchitiet.DataBind()

            End If
            LoadDSPhong()
            deNgaycap.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
            deNgayhethan.Text = Strings.Format(DateAndTime.DateAdd(DateInterval.Year, +1, DateAndTime.Now), "dd/MM/yyyy")
        End If
        LoadPhieuXuatChoThanhToan()
        LoadDSKhachHangTheoPhong()
        If Session("uId_Phieudichvu") <> Nothing Then
            dgvDanhsachcho.FocusedRowIndex = dgvDanhsachcho.FindVisibleIndexByKeyValue(Session("uId_Phieudichvu").ToString)
        End If
    End Sub
#Region "Load thong tin"
    Private Sub LoadPhieuXuatChoThanhToan()
        Dim dt_Phieuxuat As New DataTable
        objFCPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        dt_Phieuxuat = objFCPhieuxuat.SelectDSChoThanhToan(False, "0", "1/1/2014", "12/31/" & DateTime.Now.Year, Session("uId_Cuahang"))
        If dt_Phieuxuat.Rows.Count > 0 Then
            'lbtnPhieuxuat.Text = "Có " & dt_Phieuxuat.Rows.Count & " phiếu xuất chờ thanh toán"
            dgvPhieuxuatcho.DataSource = dt_Phieuxuat
            dgvPhieuxuatcho.DataBind()
        End If
    End Sub
    Private Sub LoadDropDownList()
        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        Dim dt As DataTable
        dt = objFCLoaiTT.SelectAllTable()
        For Each row As DataRow In dt.Rows
            Dim item As New ListEditItem
            item.Value = row("uId_LoaiTT")
            item.Text = row("nv_TenLoaiTT")
            ddlLoaithanhtoan.Items.Add(item)
        Next
        ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"

        objFCNhomphieu = New BO.clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
        ddlNhomphieu.DataSource = objFCNhomphieu.SelectAllTable()
        ddlNhomphieu.TextField = "nv_Tennhomphieu_vn"
        ddlNhomphieu.ValueField = "Id_Nhomphieu"
        ddlNhomphieu.DataBind()
        ddlNhomphieu.SelectedIndex = 0

        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        For Each row As DataRow In dt.Rows
            If row("v_MaLoaiTT") <> "MUTIL" Then
                Dim item As New ListEditItem
                item.Value = row("uId_LoaiTT")
                item.Text = row("nv_TenLoaiTT")
                ddlHinhthucTT_Pop.Items.Add(item)
            End If
        Next
        objFCLoaiTT = Nothing
    End Sub
    Private Sub LoadThongTinKhachHang(nv_TenPhong As String)
        objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnDMKhachhang = New CM.CRM_DM_KhachhangEntity
        objEnDMKhachhang = objFcDMKhachhang.SelectByID(Session("uId_Khachhang"))
        lblHoten.Text = objEnDMKhachhang.nv_Hoten_vn
        'ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>THANH TOÁN PHIẾU CHO KHÁCH HÀNG <span style='color:red;text-transform:uppercase;font-size:16px'>" & objEnDMKhachhang.nv_Hoten_vn & "</span> - TẠI " & nv_TenPhong & "</p>"
    End Sub
    Private Sub LoadThongTinPhieuDichVu(uId_Phieudichvu As String)
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objEnPhieuDV = objFCPhieuDV.SelectByID(uId_Phieudichvu)
        lblSophieu.Text = objEnPhieuDV.v_Sophieu
        'deNgaylap.Date = objEnPhieuDV.d_Ngay
        lblTongtien.Text = String.Format("{0:#,##0}", BO.Util.IsDouble(objEnPhieuDV.nv_Ghichu_en))
        txtGiamgiaPhieu.Text = objEnPhieuDV.f_Giamgia
        lblConlai.Text = String.Format("{0:#,##0}", Val(objEnPhieuDV.nv_Ghichu_en) - Val(objEnPhieuDV.f_Giamgia))
        Dim tiennhan As Integer
        tiennhan = Integer.Parse(BO.Util.IsDouble(objEnPhieuDV.f_Tongtienthuc))

        If tiennhan > 0 Then
            txtSotiennhan.Text = String.Format("{0:#,##0}", tiennhan)
            If tiennhan >= Val(objEnPhieuDV.nv_Ghichu_en) - Val(objEnPhieuDV.f_Giamgia) Then
                lblTienthuatext.Text = "Trả khách: "
            Else
                lblTienthuatext.Text = "Khách nợ: "
            End If
            lblKhachtra.Text = "Đã thanh toán: "
            If Session("sTendangnhap").ToString = "admin" Then
                hdfCheckthanhtoan.Value = 0
            Else
                hdfCheckthanhtoan.Value = 1
            End If
        Else
            txtSotiennhan.Text = String.Format("{0:#,##0}", lblConlai.Text)
            lblKhachtra.Text = "Cần thanh toán: "
            hdfCheckthanhtoan.Value = 0
        End If
        If BO.Util.IsDouble(objEnPhieuDV.nv_Ghichu_en) = 0 Then
            hdfCheckthanhtoan.Value = 2
        End If
        lblTienthua.Text = String.Format("{0:#,##0}", Val(lblConlai.Text.Replace(",", "")) - Val(txtSotiennhan.Text.Replace(",", "")))
        txtGhichu.Text = objEnPhieuDV.nv_Ghichu_vn
        If objEnPhieuDV.uId_LoaiTT <> "" And objEnPhieuDV.uId_LoaiTT <> Nothing Then
            ddlLoaithanhtoan.Value = objEnPhieuDV.uId_LoaiTT
        Else
            ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"
        End If
        If objEnPhieuDV.uId_Nhanvien <> "" And objEnPhieuDV.uId_Nhanvien <> Nothing Then
            'ddlNhanvien.Value = objEnPhieuDV.uId_Nhanvien
        Else
            'ddlNhanvien.Value = Session("uId_Nhanvien_Dangnhap")
        End If
        txtHH.Text = objEnPhieuDV.HHPhieu.ToString
        ddlNhomphieu.Value = objEnPhieuDV.Id_Nhomphieu.ToString

        'Load thong tin popup hinh thuc thanh toan
        'lblSophieuTT.Text = objEnPhieuDV.v_Sophieu
        'txtSotiennhanTT.Text = objEnPhieuDV.f_Tongtienthuc.ToString()
        'kiem tra phieu dich vu do co phai la the thanh toan hay o
    End Sub
    Private Sub LoadDSKhachHangTheoPhong()
        Dim dt As New DataTable
        If Session("uId_Phongban_NV_Current") <> Nothing Then
            objFCBaocaoKhachhang = New BO.clsB_BaoCao_Khachhang
            dt = objFCBaocaoKhachhang.SelectThongkeKH_ByTimeAndByPhong(DateAndTime.DateAdd(DateInterval.Day, -365, DateAndTime.Now), DateAndTime.Now, Session("uId_Cuahang").ToString, Session("uId_Phongban_NV_Current").ToString(), "3", "")
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("b_Trangthai", GetType(String))
                For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                    Dim tien As String = dt.Rows(i)("f_Tongtienthuc").ToString
                    If tien <> "" Then
                        If Convert.ToDouble(dt.Rows(i)("f_Tongtienthuc").ToString) > 0 Then
                            dt.Rows(i)("b_Trangthai") = "Đã thanh toán"
                        Else
                            dt.Rows(i)("b_Trangthai") = "Chờ thanh toán"
                        End If
                    Else
                        dt.Rows(i)("b_Trangthai") = "Chờ thanh toán"
                    End If
                Next
                dgvDanhsachcho.DataSource = dt
                dgvDanhsachcho.DataBind()
                dt = Nothing
            Else
                dgvDanhsachcho.DataSource = Nothing
                dgvDanhsachcho.DataBind()
            End If
            objFCBaocaoKhachhang = Nothing
        End If
    End Sub
    Private Sub LoadPhieuDVChitiet()
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt As DataTable = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
        If dt.Rows.Count > 0 Then
            dgvPhieuchitiet.DataSource = dt
        Else
            dgvPhieuchitiet.DataSource = New DataTable
        End If
    End Sub
    Private Sub LoadDSPhong()
        LoadDMTrangThai()
        Dim dt As New DataTable
        Dim giatriphong As String
        Dim giatritrangthai As String
        If Session("uId_Cuahang") <> Nothing Then
            objFcDMPhong = New BO.QLP_DM_PHONGFacade
            dt = objFcDMPhong.SelectAllTable(Session("uId_Cuahang").ToString)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim item As New ListEditItem
                    item.Value = row("uId_Phong").ToString()
                    item.Text = row("nv_Tenphong_vn")
                    ddlDMPhong.Items.Add(item)
                Next
            End If
            If Session("uId_Phieudichvu") <> Nothing Then
                objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
                Dim dt2 As DataTable
                dt2 = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
                Dim objFcNhomdichvu As New BO.TNTP_DM_NHOMDICHVUFacade
                Dim objFcDichvu As New BO.TNTP_DM_DICHVUFacade
                Dim str As String            
                For Each row As DataRow In dt2.Rows
                    str = objFcNhomdichvu.SelectByID(objFcDichvu.SelectByID(row("uId_Dichvu")).uId_Nhomdichvu).nv_TennhomDichvu_en
                    If str = "KHAM" Then
                        giatriphong = "67be576f-54fe-43a3-bd33-27f42e88b3fe"
                        giatritrangthai = "715ae9db-98a3-47b1-9ee5-52d6db7d895f"
                    ElseIf str = "CHUA" Then
                        giatriphong = "4586b88c-794b-4277-a661-101b5a00ee43"
                        giatritrangthai = "633e14b6-e05e-4d13-8ef9-942c90b3c8a9"
                    Else : str = "KE"
                        giatriphong = "4586b88c-794b-4277-a661-101b5a00ee43"
                        giatritrangthai = "633e14b6-e05e-4d13-8ef9-942c90b3c8a9"
                    End If
                Next
                ddlDMPhong.Value = giatriphong
                ddlTrangthai.Value = giatritrangthai
            End If        
        End If
    End Sub
    Private Sub LoadDMTrangThai()
        Dim dt As New DataTable
        objFcDMTrangthai = New BO.CRM_DM_TRANGTHAIFacade
        dt = objFcDMTrangthai.SelectByIType("3")
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim item As New ListEditItem
                item.Value = row("uId_Trangthai").ToString()
                item.Text = row("nv_Tentrangthai_vn")
                ddlTrangthai.Items.Add(item)
            Next
            ddlTrangthai.SelectedIndex = 0
        End If
    End Sub
    Private Sub Loaddanhsachphieu()
        'Load Thong tin danh sach phieu
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As New DataTable
        dt = objFCPhieuDV.SelectAllByGDV(Session("uId_Khachhang"), 2, 1)
        If dt.Rows.Count > 0 Then
            dgvDanhsachphieu.DataSource = dt
        End If
    End Sub
    Private Sub LoadDanhsachno()
        Dim dt As DataTable
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        dt = objFCPhieuDV.SelectDVNo(Session("uId_Khachhang"))
        If dt.Rows.Count > 0 Then
            dgvDSPhieuno.DataSource = dt
        End If
    End Sub
    Private Sub LoadDSTheTT()
        objFCGoiDV = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim dt As DataTable
        dt = objFCGoiDV.SelectAllTable(Session("uId_Khachhang"), 2)
        dgvDsTheTT.DataSource = dt
    End Sub
    Private Sub LoadDSLoaiTT()
        objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
        Dim dt As DataTable
        dt = objFCPhieuDVLoaiTT.SelectByPhieuDV(Session("uId_Phieudichvu").ToString)
        If dt.Rows.Count > 0 Then
            dgvLoaiTT.DataSource = dt
            dgvLoaiTT.DataBind()
        Else
            dgvLoaiTT.DataSource = Nothing
            dgvLoaiTT.DataBind()
        End If
        objFCLoaiTT = Nothing
    End Sub
    Private Function CheckPhieuCuMoi()
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu"))
        If Val(objEnPhieuDV.f_Tongtienthuc) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function IsDouble(ByVal value As String) As Double
        If value = "" Or value = Nothing Then
            Return 0
        Else
            Return CDbl(value)
        End If
    End Function
#End Region
#Region "Button"
    Protected Sub btnLidoxoa_Click(sender As Object, e As EventArgs)
        If txtLidoxoa.Text.Trim <> "" And Session("uId_Phieuchitiet") <> Nothing And Session("uId_Dichvu_huy") <> Nothing And Session("uId_Phieudichvu") <> Nothing Then
            objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
            objFCChitietDV.DeleteByID(Session("uId_Phieuchitiet").ToString)
            objFCHuyDV = New BO.MKT_HUYDV
            objEnHuyDV = New CM.MKT_HUYDV
            objFCNhatKy = New BO.NHATKYSUDUNGFacade
            objEnHuyDV.uId_Dichvu = Session("uId_Dichvu_huy").ToString
            objEnHuyDV.uId_Phieudichvu = Session("uId_Phieudichvu")
            objEnHuyDV.uId_Khachhang = Session("uId_Khachhang").ToString
            objEnHuyDV.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
            objEnHuyDV.Date = DateTime.Now
            objEnHuyDV.nv_Ghichu_vn = txtLidoxoa.Text
            Try
                objFCHuyDV.Insert(objEnHuyDV)
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa dịch vụ " & Session("nv_Tendichvu_huy") & " sau thanh toán trong phiếu " & lblSophieu.Text)
                ShowMessage(Me, "Đã xóa thành công")
            Catch ex As Exception

            End Try
            objFCChitietDV = Nothing
            objFCHuyDV = Nothing
            Session("uId_Phieuchitiet") = Nothing
            Session("uId_Dichvu_huy") = Nothing
            Session("nv_Tendichvu_huy") = Nothing
            txtLidoxoa.Text = ""
            Response.Redirect(Request.RawUrl)
        End If
    End Sub

    Protected Sub btLuuthe_Click(sender As Object, e As EventArgs)
        objEnGoiKH = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        objFCGoiKH = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        'Tao mot the
        With objEnGoiKH
            .uId_Cuahang = Session("uId_Cuahang")
            .uId_Khachhang = Session("uId_Khachhang")
            .uId_Goidichvu = Session("uId_Dichvu_The")
            .uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
            .f_Sotien = Val(BO.Util.IsDouble(hdfDongiathe.Value.Replace(",", "")))
            .f_Giatrigoi = Val(BO.Util.IsDouble(txtGiatri.Text.Replace(",", ""))) 'Dung ham nay
            .i_TongSolanthuchien = 1
            .d_Ngaymua = BO.Util.ConvertDateTime(deNgaycap.Text)
            .d_NgayBD = BO.Util.ConvertDateTime(deNgaycap.Text)
            .d_NgayKT = BO.Util.ConvertDateTime(deNgayhethan.Text)
            If txtMavach.Text = "" Then
                .vMaBarcode = pc.ReturnAutoString("THE")
            Else
                .vMaBarcode = Trim(txtMavach.Text)
            End If
        End With
        'Kiem tra MaThe co trung ko?
        If objFCGoiKH.chkExist_MaTheThanhtoan(objEnGoiKH) Then
            ltrError.Text = "<span class='error' id='error'>Trùng mã thẻ!</span>"
            txtMavach.Focus()
            Exit Sub
        End If

        Dim str As String = objFCGoiKH.Insert(objEnGoiKH)
        If (str = "") Then
            ltrError.Text = "<span class='error' id='error'>Có lỗi xảy ra!</span>"
            ltrSuccess.Text = ""
        Else
            ltrSuccess.Text = "<span class='success' id='success'>Cấp thẻ mã số " & txtMavach.Text & " thành công!</span>"
            ltrError.Text = ""
        End If
    End Sub

    Protected Sub btnLuuHinhthuc_Click(sender As Object, e As EventArgs)
        If Session("uId_Phieudichvu") <> Nothing Then
            Dim f_Giatrigoi As Double
            objEnPhieuDVLoaiTT = New CM.TNTP_PHIEUDICHVU_LOAITTEntity
            objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
            objFCGoiKH = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
            objEnGoiKH = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
            Dim Tongtien As String = ""
            Tongtien = objFCPhieuDVLoaiTT.SelectTongtien(Session("uId_Phieudichvu"))
            'sum = Convert.ToDouble(IsDouble(Tongtien))
            'sums = sum + Convert.ToDouble(IsDouble(txtSotienTT_Pop.Text.Replace(",", "")))
            'If sums > Convert.ToDouble(IsDouble(txtSotiennhanTT.Text.Replace(",", ""))) Then
            '    lblError.Text = "<span style='color:red; font-style:italic'>Tổng kê khai phải nhỏ hơn số tiền nhận</span>"
            'Else
            '    lblError.Text = ""

            'End If
            objEnPhieuDVLoaiTT.uId_LoaiTT = ddlHinhthucTT_Pop.SelectedItem.Value.ToString
            objEnPhieuDVLoaiTT.uId_Phieudichvu = Session("uId_Phieudichvu").ToString
            objEnPhieuDVLoaiTT.f_Sotien = txtSotienTT_Pop.Text.Replace(",", "")
            objEnPhieuDVLoaiTT.v_Maso = txtMaSoTT_Pop.Text
            objEnPhieuDVLoaiTT.nv_Ghichu_vn = txtGhichu.Text
            Try
                objFCPhieuDVLoaiTT.Insert(objEnPhieuDVLoaiTT)
                'Lay ra gia tri goi the tai khoan cua khach hang hien tai
                objEnGoiKH = objFCGoiKH.SelectByvMaBarcode(txtMaSoTT_Pop.Text)
                f_Giatrigoi = objEnGoiKH.f_Giatrigoi

                objEnGoiKH = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
                If (f_Giatrigoi > CDbl(txtSotienTT_Pop.Text.Replace(",", ""))) Then
                    objEnGoiKH.f_Sotien = f_Giatrigoi - CDbl(txtSotienTT_Pop.Text.Replace(",", ""))
                Else
                    objEnGoiKH.f_Sotien = 0
                End If
                objEnGoiKH.uId_Khachhang_Goidichvu = oLibP.NullProString(Session("uId_Khachhang_Goidichvu_TT"))
                objFCGoiKH.ThanhToan(objEnGoiKH)
                Session("uId_Khachhang_Goidichvu_TT") = Nothing
                txtMaSoTT_Pop.Text = ""
                txtGhichu.Text = ""
                txtSotienTT_Pop.Text = ""
                txtSotienTT_Pop.Focus()
                LoadDSLoaiTT()
            Catch ex As Exception

            End Try
            objEnPhieuDVLoaiTT = Nothing
            objFCPhieuDVLoaiTT = Nothing
        End If
    End Sub

    Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Session.Remove("uId_Khachhang")
        Session.Remove("uId_Phieudichvu")
        Session.Remove("uId_TrangthaiKH")
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub btnChuyen_Click(sender As Object, e As EventArgs)
        Dim trangthaiKHentity As New CM.PQP_TRANGTHAIKHCHOXULYEntity
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        objFcChoXyLy = New BO.PQP_TRANGTHAIKHCHOXULYFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        trangthaiKHentity.uId_Trangthai = ddlTrangthai.SelectedItem.Value.ToString
        trangthaiKHentity.uId_Phong = ddlDMPhong.SelectedItem.Value.ToString
        trangthaiKHentity.d_Ngay = dat_Ngaychuyen.Value
        trangthaiKHentity.uId_Phongchuyen = Session("uId_Phongban_NV_Current").ToString
        If Session("uId_Khachhang") <> Nothing Then
            Dim trangthaiKHUpdate As New CM.PQP_TRANGTHAIKHCHOXULYEntity
            If Session("uId_TrangthaiKH") <> Nothing Then
                trangthaiKHUpdate = objFcChoXyLy.SelectByID(Session("uId_TrangthaiKH"))
                If trangthaiKHUpdate.uId_Trangthai <> "d55b80ca-1001-49aa-80ae-9bb650c40a17" Then
                    trangthaiKHUpdate.uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
                    objFcChoXyLy.Update(trangthaiKHUpdate)
                End If
            End If
            If Session("uId_Phieudichvu") <> Nothing Then
                trangthaiKHentity.uId_Phieudichvu = Session("uId_Phieudichvu")
                trangthaiKHentity.nv_Ghichu = txtNote.Text
                Try
                    objFcChoXyLy.Insert(trangthaiKHentity)
                    Dim roomname As String = ""
                    If Session("uId_Phongban_NV_Current") <> Nothing Then
                        roomname = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_vn
                    End If
                    objFCNhatKy.Write(Session("sTendangnhap"), "", "Chuyển KH " & lblHoten.Text & " (" & objEnPhieuDV.v_Sophieu & ") từ " & roomname & " đến " & ddlDMPhong.SelectedItem.Text & ". Trạng thái " & ddlTrangthai.SelectedItem.Text)
                  
                    Session.Remove("uId_Khachhang")
                    Session.Remove("uId_Phieudichvu")
                    Session.Remove("uId_TrangthaiKH")
                    LoadDSKhachHangTheoPhong()
                    LoadPhieuDVChitiet()
                    lblSophieu.Text = ""
                    lblHoten.Text = ""
                    ShowMessage(Me, "Chuyển thành công")
                    ' Response.Redirect(Request.RawUrl)
                Catch ex As Exception
                    'ShowMessage(Me, "Lỗi trong quá trình chuyển")
                End Try
            End If
        End If
    End Sub
#End Region
#Region "Grid Event"
    Protected Sub dgvDanhsachcho_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim id = e.Keys(2).ToString()
        objFcChoXyLy = New BO.PQP_TRANGTHAIKHCHOXULYFacade
        Try
            objFcChoXyLy.DeleteByID(id)
            dgvDanhsachcho.CancelEdit()
            e.Cancel = True
            LoadDSKhachHangTheoPhong()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgvPhieuchitiet_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnHuyDV = New CM.MKT_HUYDV
        objFCHuyDV = New BO.MKT_HUYDV
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim uId_Phieuchitiet As String
        uId_Phieuchitiet = e.Keys(0).ToString
        Session("uId_Phieuchitiet") = uId_Phieuchitiet
        Session("uId_Dichvu_huy") = e.Keys(1).ToString
        Session("nv_Tendichvu_huy") = e.Keys(2).ToString()
        objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu"))
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If objEnPhieuDV.b_IsKhoa = False Or dt.Rows.Count > 0 Then
            If CheckPhieuCuMoi() Then
                objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "73D3F2E2-9B4D-46CF-AB34-469044887578")
                If Not objEnPhanQuyen.b_Enable Then
                    ShowMessage(Me, "Bạn không có quyền xóa DV trong phiếu cũ!")
                    Exit Sub
                End If
            Else
                objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "FB558160-D9D0-4D88-A908-FA1B13515D49")
                If Not objEnPhanQuyen.b_Enable Then
                    ShowMessage(Me, "Bạn không có quyền xóa DV trong phiếu mới!")
                    Exit Sub
                End If
            End If
            Try
                'If objEnPhieuDV.f_Tongtienthuc = "" Then
                '    'objFCChitietDV.DeleteByID(uId_Phieuchitiet)
                '    'Phuong thuc nay de goi o client sau khi call back grid
                '    CType(sender, ASPxGridView).JSProperties("cpIsHuyDV") = "before"
                '    objEnHuyDV.uId_Dichvu = e.Keys(1).ToString
                '    objEnHuyDV.uId_Phieudichvu = Session("uId_Phieudichvu")
                '    objEnHuyDV.Date = DateTime.Now
                '    objEnHuyDV.uId_Khachhang = Session("uId_Khachhang").ToString
                '    objEnHuyDV.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
                '    objEnHuyDV.nv_Ghichu_vn = "Hủy trước thanh toán"
                '    Try
                '        objFCHuyDV.Insert(objEnHuyDV)
                '        objFCNhatKy.Write(Session("sTendangnhap"), System.Web.HttpContext.Current.Request.UserHostAddress, "Xóa dịch vụ " & e.Keys(2).ToString() & " trước thanh toán trong phiếu " & objEnPhieuDV.v_Sophieu)
                '    Catch ex As Exception

                '    End Try
                'Else
                '    CType(sender, ASPxGridView).JSProperties("cpIsHuyDV") = "after"
                '    Session("dv_Tendv") = e.Keys(2).ToString()
                'End If
                If uId_Phieuchitiet <> "" Then
                    hdfIDdichvuhuy.Value = uId_Phieuchitiet
                End If
            Catch ex As Exception

            End Try
        Else
            ShowMessage(Me, "Phiếu đã khóa!")
        End If
        e.Cancel = True
    End Sub

    Protected Sub dgvPhieuchitiet_DataBinding(sender As Object, e As EventArgs)
        LoadPhieuDVChitiet()
    End Sub

    Protected Sub dgvPhieuchitiet_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        CType(sender, ASPxGridView).JSProperties("cpIsUpdated") = "update"
        CType(sender, ASPxGridView).JSProperties("cpf_Dongia_new") = e.NewValues(3)
        CType(sender, ASPxGridView).JSProperties("cpf_Dongia_old") = e.OldValues(3)
        Dim checkKhoaPhieu As Boolean = False
        checkKhoaPhieu = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu")).b_IsKhoa
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt.Rows.Count > 0 Then
            Dim uId_Phieudichvu_Chitiet As String
            uId_Phieudichvu_Chitiet = e.Keys(0).ToString
            Dim f_SoLan_interface As Integer = CInt(Val(e.NewValues(1)))
            Dim i_SoLan_Dieutri As Integer = CInt(objFCChitietDV.SelectByIDChitiet(uId_Phieudichvu_Chitiet)(0)("i_SoLan_Dieutri"))
            Dim f_SoLuong_interface As Integer = CInt(Val(e.NewValues(4)))
            With objEnChitietDV
                .uId_Phieudichvu_Chitiet = uId_Phieudichvu_Chitiet
                If f_SoLan_interface > (f_SoLuong_interface * i_SoLan_Dieutri) Then
                    .f_Solan = f_SoLan_interface
                Else
                    .f_Solan = f_SoLuong_interface * i_SoLan_Dieutri
                End If
                .f_Soluong = CInt(Val(e.NewValues(4)))
                .f_Dongia = CInt(Val(e.NewValues(3)))
                .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
                'Dim strGiamgia As String = e.NewValues(5).ToString
                Dim strGiamgia As String = DirectCast(dgvPhieuchitiet.FindEditRowCellTemplateControl(TryCast(dgvPhieuchitiet.Columns("f_Giamgia"), GridViewDataColumn), "txtGiamgia"), TextBox).Text
                If InStr(strGiamgia, "%") > 0 Then
                    .f_Giamgia = .f_Soluong * .f_Dongia * CInt(strGiamgia.Replace("%", "")) / 100
                Else : .f_Giamgia = CInt(Val(strGiamgia))
                End If
                .b_BaoHanh = False
            End With

            objFCChitietDV.Update(objEnChitietDV)
            dgvPhieuchitiet.CancelEdit()
            LoadThongTinPhieuDichVu(Session("uId_Phieudichvu"))
            e.Cancel = True
        Else
            ShowMessage(Me, "Phiếu đã khóa!")
        End If
    End Sub

    Protected Sub dgvDanhsachphieu_DataBinding(sender As Object, e As EventArgs)
        Loaddanhsachphieu()
    End Sub

    Protected Sub dgvDevexpress_DataBound(sender As Object, e As EventArgs)
        'objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        'Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
        'Dim dt As DataTable = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
        'Dim check As Boolean = False
        'For i As Int32 = 0 To grid.VisibleRowCount - 1
        '    check = False
        '    For ii As Integer = 0 To dt.Rows.Count - 1
        '        If dt.Rows(ii)("uId_Dichvu").ToString = grid.GetRowValues(i, "uId_Dichvu").ToString Then
        '            check = True
        '        End If
        '    Next
        '    If check = True Then
        '        grid.Selection.SetSelection(i, True)
        '    Else
        '        grid.Selection.SetSelection(i, False)
        '    End If
        'Next i
    End Sub

    Protected Sub dgvDSPhieuno_DataBinding(sender As Object, e As EventArgs)
        LoadDanhsachno()
    End Sub

    Protected Sub dgvDanhsachphieu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "FB558160-D9D0-4D88-A908-FA1B13515D49")
        If Not objEnPhanQuyen.b_Enable Then
            ltrErrorPuPhieu.Text = "Bạn không có quyền xóa phiếu dịch vụ!"
            e.Cancel = True
            Exit Sub
        End If
        Dim uId_Phieudichvu As String
        uId_Phieudichvu = e.Keys(0).ToString
        objFCPhieuDV.DeleteByID(uId_Phieudichvu)
        dgvDanhsachphieu.DataBind()
        e.Cancel = True
    End Sub

    Protected Sub dgvDsTheTT_DataBinding(sender As Object, e As EventArgs)
        LoadDSTheTT()
    End Sub

    Protected Sub dgvLoaiTT_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Phieudichvu As String = Session("uId_Phieudichvu").ToString
        objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
        objFCPhieuDVLoaiTT.DeleteByID(uId_Phieudichvu, e.Keys(0).ToString)
        LoadDSLoaiTT()
        e.Cancel = True
        objFCPhieuDVLoaiTT = Nothing
    End Sub
#End Region

    Protected Sub btnHuydichvu_Click(sender As Object, e As EventArgs)
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objEnHuyDV = New CM.MKT_HUYDV
        objFCHuyDV = New BO.MKT_HUYDV
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu"))
        objEnChitietDV.f_Tongtien = Convert.ToDouble(objFCChitietDV.SelectByIDChitiet(hdfIDdichvuhuy.Value).Rows(0)("f_Tongtien"))
        objEnChitietDV.uId_Dichvu = objFCChitietDV.SelectByIDChitiet(hdfIDdichvuhuy.Value).Rows(0)("uId_Dichvu").ToString
        If objEnPhieuDV.f_Tongtienthuc <> "" Then
            Dim tien As Double
            tien = Convert.ToDouble(objEnPhieuDV.f_Tongtienthuc) - Convert.ToDouble(objEnChitietDV.f_Tongtien)
            If tien >= 0 Then
                objEnPhieuDV.f_Tongtienthuc = tien
            End If
            objFCPhieuDV.Update_TTT(objEnPhieuDV)
        End If
        objFCChitietDV.DeleteByID(hdfIDdichvuhuy.Value)
        With objEnHuyDV
            .uId_Phieudichvu = Session("uId_Phieudichvu")
            .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
            .uId_Dichvu = objEnChitietDV.uId_Dichvu
            .uId_Khachhang = Session("uId_Khachhang")
            .nv_Ghichu_vn = txtLydohuydv.Text
            .Date = DateTime.Now.ToString
        End With
        objFCHuyDV.Insert(objEnHuyDV)
        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa dịch vụ " & Session("nv_Tendichvu_huy") & " Ly do:  " & txtLydohuydv.Text & " Phiếu: " & lblSophieu.Text)
        ClientScript.RegisterStartupScript(GetType(String), "ANY_KEY", "window.parent.closeloginWindow();", True)
    End Sub
End Class