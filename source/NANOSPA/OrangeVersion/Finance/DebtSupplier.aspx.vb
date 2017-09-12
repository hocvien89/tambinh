Imports DevExpress.Web.ASPxGridView

Public Class Debtsupplier
    Inherits System.Web.UI.Page
    Dim objEnThuChi As CM.QLTC_PhieuthuchiEntity
    Dim objFcThuChi As BO.QLTC_PhieuthuchiFacade
    Private objFcPhieunhapCNTt As BO.clsB_Phieunhap_Congno_Thanhtoan
    Private objEnPhieunhapCNTt As CM.cls_Phieunhap_Congno_Thanhtoan
    Private objFcNhacungcap As BO.QLMH_DM_NHACUNGCAPFacade
    Private objFcPhieunhapCn As BO.clsB_Phieunhap_Congno
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dgvDevexpress.DataBind()
            deNgaytra.Value = Date.Now
        End If

    End Sub
#Region "load data"
    Private Sub loadNCC()
        objFcPhieunhapCNTt = New BO.clsB_Phieunhap_Congno_Thanhtoan
        Dim dt As DataTable
        dt = objFcPhieunhapCNTt.SelectAllTable()
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
        End If
        objFcPhieunhapCNTt = Nothing
    End Sub

    Private Function LoadPhieuno(uId_Nhacungcap As String) As DataTable
        objFcPhieunhapCNTt = New BO.clsB_Phieunhap_Congno_Thanhtoan
        Dim dt As New DataTable
        dt = objFcPhieunhapCNTt.SelectCongnoPhieu(uId_Nhacungcap)
        Return dt
    End Function

    Private Function LoadPhieunhapChitiet(uId_Phieunhap As String) As DataTable
        objFcPhieunhapCNTt = New BO.clsB_Phieunhap_Congno_Thanhtoan
        Dim dt As New DataTable
        dt = objFcPhieunhapCNTt.SelectChitietPhieu(uId_Phieunhap)
        Return dt
    End Function
#End Region

    Protected Sub dgvPhieuNoNCC_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Nhacungcap As String
        uId_Nhacungcap = detailGridView.GetMasterRowKeyValue().ToString
        Dim dt As DataTable
        dt = LoadPhieuno(uId_Nhacungcap)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        dt = Nothing
    End Sub


    Protected Sub dgvPhieuchitiet_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieunhap As String
        uId_Phieunhap = detailGridView.GetMasterRowKeyValue().ToString
        Dim dt As DataTable
        dt = LoadPhieunhapChitiet(uId_Phieunhap)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        dt = Nothing
    End Sub

    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        objEnThuChi = New CM.QLTC_PhieuthuchiEntity
        objEnPhieunhapCNTt = New CM.cls_Phieunhap_Congno_Thanhtoan
        objFcThuChi = New BO.QLTC_PhieuthuchiFacade
        objFcPhieunhapCNTt = New BO.clsB_Phieunhap_Congno_Thanhtoan
        objFcNhacungcap = New BO.QLMH_DM_NHACUNGCAPFacade
        objFcPhieunhapCn = New BO.clsB_Phieunhap_Congno
        Dim str As String = ""
        With objEnThuChi
            .f_Sotien = txtSotien.Text
            .v_Maphieu = hdfv_Maphieunhap.Value.ToString
            .uId_Cuahang = Session("uId_Cuahang")
            .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
            .uId_Thuchi = "984614f3-3304-4185-87a3-d27be7c91f00"
            .nv_Lydo_vn = CStr(txtGhichu.Text)
            .d_Ngay = BO.Util.ConvertDateTime(deNgaytra.Text)
            .nv_Ghichu = objFcNhacungcap.SelectByID(hdfuId_Nhacungcap.Value.ToString).nv_Tennhacungcap_vn
        End With
        Try
            str = objFcThuChi.Insert(objEnThuChi)
        Catch ex As Exception

        End Try
        'insert vao phieu nhap cong no thanh toan
        Dim dt As DataTable
        dt = objFcPhieunhapCn.SelectByuIdPhieunhap(hdfuId_Phieunhap.Value.ToString)
        With objEnPhieunhapCNTt
            .uId_Phhieuthuchi = str
            .uId_Phieunhap_Congno = dt.Rows(0)("uId_Phieunhap_Congno").ToString
        End With
        Try
            objFcPhieunhapCNTt.Insert(objEnPhieunhapCNTt)
        Catch ex As Exception

        End Try
        ' update tien no trong phieu nhap cong no 
        Try
            objFcPhieunhapCn.UpdateTienno(hdfuId_Phieunhap.Value.ToString, hdff_Tiennomoi.Value.ToString)
        Catch ex As Exception

        End Try
        ShowMessage(Me, "Thanh toán công nợ thành công")
        hdff_Tienno.Value = ""
        hdff_Tiennomoi.Value = ""
        hdfuId_Dmthuchi.Value = ""
        hdfuId_Nhacungcap.Value = ""
        hdfuId_Phieunhap.Value = ""
        hdfv_Maphieunhap.Value = ""
        txtGhichu.Text = ""
        txtSotien.Text = ""
        lblSophieu.Text = ""
        lblSotienno.Text = ""
        dgvDevexpress.DataBind()
    End Sub

    Protected Sub dgvDevexpress_DataBinding(sender As Object, e As EventArgs)
        loadNCC()
    End Sub
End Class