Public Class TransferRoomHistory
    Inherits System.Web.UI.Page
    Private objFCBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
    Dim objEnDMPhong As CM.QLP_DM_PHONGEntity
    Dim objFcDMPhong As BO.QLP_DM_PHONGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            objEnDMPhong = New CM.QLP_DM_PHONGEntity
            objFcDMPhong = New BO.QLP_DM_PHONGFacade
            objEnDMPhong = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current"))
            ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>LỊCH SỬ CHUYỂN PHÒNG - TẠI " & objEnDMPhong.nv_Tenphong_vn & "</p>"
        End If
        LoadDSKhachHangTheoPhong()
    End Sub
#Region "Load thong tin KH"
    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Private Sub LoadDSKhachHangTheoPhong()
        Dim dt As New DataTable
        If Session("uId_Phongban_NV_Current") <> Nothing Then
            objFCBaocaoKhachhang = New BO.clsB_BaoCao_Khachhang
            dt = objFCBaocaoKhachhang.SelectThongkeKH_ByTimeAndByPhongOption(Aspx_Tungay.Value, Aspx_Denngay.Value, Session("uId_Cuahang").ToString, Session("uId_Phongban_NV_Current").ToString(), "2", txt_key.Text)
            If dt.Rows.Count > 0 Then
                dgvDevexpress.DataSource = dt
                dgvDevexpress.DataBind()
                dt = Nothing
            Else
                dgvDevexpress.DataSource = Nothing
                dgvDevexpress.DataBind()
            End If
            objFCBaocaoKhachhang = Nothing
        End If
    End Sub
#End Region
#Region "Button"
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoadDSKhachHangTheoPhong()
    End Sub
#End Region
End Class