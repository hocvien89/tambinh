Imports DevExpress.Web.ASPxGridView

Public Class Debt
    Inherits System.Web.UI.Page
#Region "Khai bao"
    Dim objFCKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objFCPhieuDV As BO.TNTP_PHIEUDICHVUFacade
    Dim objEnPhieudDV As CM.TNTP_PHIEUDICHVUEntity
    Dim objFCPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim objEnPhieuxuat As CM.QLMH_PHIEUXUATEntity
    Dim objFCChitietDV As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Dim objFCLoaiTT As BO.QLTC_LoaiHinhTTFacade
    Dim objEnThuChi As CM.QLTC_PhieuthuchiEntity
    Dim objFcThuChi As BO.QLTC_PhieuthuchiFacade
    Dim objEnThanhToanCongNo As CM.QLCN_CONGNO_THANHTOANEntity
    Dim objFcThanhToanCongNo As BO.QLCN_CONGNO_THANHTOANFacade
    Dim objEnCongNo As CM.QLCN_CONGNOEntity
    Dim objFcCongNo As BO.QLCN_CONGNOFacade
    Dim objFcCongNoSP As BO.QLCN_CONGNO_SPFacade
    Dim objEnCongNoSP As CM.QLCN_CONGNO_SPEntity
    Private objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim objFCThamsohethong As BO.clsB_QT_THAMSOHETHONG
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dateNgay.Date = Date.Now
            LoadDropDownList()
            deNgaytra.Date = DateTime.Now.ToString
            dgvDevexpress.DataBind()
            If Session("uId_Phieudichvu") <> Nothing Then
                LoadDichVuNo(Session("uId_Phieudichvu"))
            End If
            If Session("uId_Phieuxuat") <> Nothing Then
                LoadXuatNo(Session("uId_Phieuxuat"))
            End If
        End If
        loadDSPhieuCongnoTT()
    End Sub
#Region "Function"
    Private Sub LoadDichVuNo(ByVal uId_Phieudichvu As String)
        objFcCongNo = New BO.QLCN_CONGNOFacade
        objEnPhieudDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieudDV = objFCPhieuDV.SelectByID(uId_Phieudichvu)
        txtGhichu.Text = "Thanh toán công nợ phiếu dịch vụ " & Request.QueryString("pdv")
        lblSophieu.Text = Request.QueryString("pdv")
        Dim tienno As String
        tienno = String.Format("{0:#,##}", objFcCongNo.SelectByID(uId_Phieudichvu).f_Sotien)
        lblSotienno.Text = tienno
        txtSotien.Text = tienno
        'Hidden Field
        hdfuId_Khachhang.Value = objEnPhieudDV.uId_Khachhang
        hdfuId_Phieudichvu.Value = uId_Phieudichvu
        hdff_Sotienno.Value = tienno
        hdfuId_Dmthuchi.Value = "cee5edc6-769d-4d44-a3fb-24e2c4eb1175"
        hdfv_Sophieu.Value = Request.QueryString("pdv")
    End Sub
    Private Sub LoadXuatNo(ByVal uId_Phieuxuat As String)
        objFcCongNoSP = New BO.QLCN_CONGNO_SPFacade
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFCPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = objFCPhieuxuat.SelectByID(uId_Phieuxuat)
        txtGhichu.Text = "Thanh toán công nợ xuất " & Request.QueryString("px")
        lblSophieu.Text = Request.QueryString("px")
        Dim tienno As String
        tienno = String.Format("{0:#,##}", objFcCongNoSP.SelectByID(uId_Phieuxuat).f_Sotien)
        lblSotienno.Text = tienno
        txtSotien.Text = tienno
        'Hidden Field
        hdfuId_Khachhang.Value = objEnPhieuxuat.uId_Khachhang
        hdfuId_Phieudichvu.Value = uId_Phieuxuat
        hdff_Sotienno.Value = tienno
        hdfuId_Dmthuchi.Value = "cb74ca0b-0559-431e-8988-47a0275ae60b"
        hdfv_Sophieu.Value = Request.QueryString("px")
    End Sub
    Private Sub LoadGridNo()
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As New DataTable
        dt = objFCKhachhang.SelectKhachhangNo(Session("uId_Cuahang"))
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        dgvDevexpress.DataSource = dt
    End Sub
    Private Sub LoadDropDownList()
        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        ddlLoaithanhtoan.DataSource = objFCLoaiTT.SelectAllTable()
        ddlLoaithanhtoan.TextField = "nv_TenLoaiTT"
        ddlLoaithanhtoan.ValueField = "uId_LoaiTT"
        ddlLoaithanhtoan.DataBind()
        ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"
    End Sub
    Private Sub loadDSPhieuCongnoTT()
        Dim objFcCongno As New BO.QLCN_CONGNO_THANHTOANFacade
        Dim dt As DataTable
        dt = objFcCongno.SelectCongnoTTByDate(dateNgay.Date)
        If dt.Rows.Count > 0 Then
            GrvDanhsachCongno.DataSource = dt
            GrvDanhsachCongno.DataBind()
        End If
    End Sub
#End Region
#Region "GridView"
    Protected Sub dgvDevexpress_DataBinding(sender As Object, e As EventArgs)
        LoadGridNo()
    End Sub

    Protected Sub dgvPhieudichvu_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable = objFCPhieuDV.SelectDVNo(uId_Khachhang)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuDV = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvPhieuxuat_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable = objFCPhieuxuat.SelectAllTablePXNo(uId_Khachhang)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuDV = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvPhieuchitiet_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieudichvu As String
        uId_Phieudichvu = detailGridView.GetMasterRowKeyValue().ToString
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt As DataTable = objFCChitietDV.SelectByID(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCChitietDV = Nothing
    End Sub

    Protected Sub dgvPhieuxuatchitiet_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieuxuat As String
        uId_Phieuxuat = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable = objFCPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuxuat = Nothing
        dt = Nothing
    End Sub
#End Region
#Region "Button"
    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        objEnThuChi = New CM.QLTC_PhieuthuchiEntity
        objFcThuChi = New BO.QLTC_PhieuthuchiFacade
        objEnThanhToanCongNo = New CM.QLCN_CONGNO_THANHTOANEntity
        objFcThanhToanCongNo = New BO.QLCN_CONGNO_THANHTOANFacade
        objFcCongNo = New BO.QLCN_CONGNOFacade
        objEnCongNo = New CM.QLCN_CONGNOEntity
        objFcCongNoSP = New BO.QLCN_CONGNO_SPFacade
        objEnCongNoSP = New CM.QLCN_CONGNO_SPEntity
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Dim str As String = ""
        Dim struId_CongnoTT As String = ""
        If (hdfuId_Khachhang.Value <> "") Then
            With objEnThuChi
                .v_Maphieu = hdfv_Sophieu.Value
                .d_Ngay = BO.Util.ConvertDateTime(deNgaytra.Text)
                .nv_Lydo_vn = CStr(txtGhichu.Text)
                .f_Sotien = CInt(Me.txtSotien.Text.Replace(",", ""))
                .uId_Thuchi = hdfuId_Dmthuchi.Value
                .uId_Cuahang = Session("uId_Cuahang")
                .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
                .nv_Ghichu = objFCKhachhang.SelectByID(hdfuId_Khachhang.Value.ToString).nv_Hoten_vn
                .uId_LoaiTT = ddlLoaithanhtoan.Value.ToString
                Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLockBill")
                If oThamsohethong.v_Giatri = "1" Then
                    .b_IsKhoa = True
                Else
                    .b_IsKhoa = False
                End If
            End With
            Try
                str = objFcThuChi.Insert(objEnThuChi)
            Catch ex As Exception

            End Try
            With objEnThanhToanCongNo
                .uId_Khachhang = hdfuId_Khachhang.Value
                .uId_Phieuthuchi = str
                .vTypeThanhToan = hdfuId_Phieudichvu.Value.Split("$")(1)
            End With
            'If Val(txtSotien.Text.Replace(",", "")) > Val(hdff_Sotienno.Value.Replace(",", "")) Then
            '    objEnThanhToanCongNo.f_Sotien_Nolai = 0
            'Else
            '    objEnThanhToanCongNo.f_Sotien_Nolai = Val(hdff_Sotienno.Value.Replace(",", "")) - Val(txtSotien.Text.Replace(",", ""))
            'End If
            objEnThanhToanCongNo.f_Sotien_Nolai = Val(txtSotien.Text.Replace(",", ""))
            objEnThanhToanCongNo.uId_Phieuno = hdfuId_Phieudichvu.Value.Split("")(0)
            Try
                struId_CongnoTT = objFcThanhToanCongNo.Insert(objEnThanhToanCongNo)
            Catch ex As Exception

            End Try
            HttpContext.Current.Session("uIdConNoThanhToan") = struId_CongnoTT
            'If hdfuId_Dmthuchi.Value = "cee5edc6-769d-4d44-a3fb-24e2c4eb1175" Then
            '    With objEnCongNo
            '        .f_Sotien = Val(hdff_Sotienno.Value.Replace(",", "")) - Val(txtSotien.Text.Replace(",", ""))
            '        .uId_Phieudichvu = hdfuId_Phieudichvu.Value
            '        .uId_Congno_Thanhtoan = struId_CongnoTT
            '    End With
            '    objFcCongNo.Update(objEnCongNo)
            'End If
            'If hdfuId_Dmthuchi.Value = "cb74ca0b-0559-431e-8988-47a0275ae60b" Then
            '    With objEnCongNoSP
            '        .f_Sotien = Val(hdff_Sotienno.Value.Replace(",", "")) - Val(txtSotien.Text.Replace(",", ""))
            '        .uId_Phieuxuat = hdfuId_Phieudichvu.Value
            '    End With
            '    objFcCongNoSP.Update(objEnCongNoSP)
            'End If
            ShowMessage(Me, "Thanh toán nợ thành công!")
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Công nợ: " & txtGhichu.Text & " của khách hàng " & objEnThuChi.nv_Ghichu & ". Số tiền trả " & txtSotien.Text)
            hdfuId_Khachhang.Value = ""
            hdfuId_Phieudichvu.Value = ""
            hdfv_Sophieu.Value = ""
            hdfuId_Dmthuchi.Value = ""
            hdff_Sotienno.Value = ""
            txtSotien.Text = ""
            txtGhichu.Text = ""
            lblSophieu.Text = ""
            Session("uId_Phieudichvu") = Nothing
            Session("uId_Phieuxuat") = Nothing
            dgvDevexpress.DataBind()
        End If
    End Sub
#End Region

End Class