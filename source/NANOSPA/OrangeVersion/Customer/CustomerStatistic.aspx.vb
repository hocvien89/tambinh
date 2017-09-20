Imports DevExpress.Web.ASPxGridView

Public Class CustomerStatistic
    Inherits System.Web.UI.Page
    Private objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Private objFcPhanQuyen As BO.QT_PHANQUYENFacade
    Private objFcNguon As BO.CRM_DM_NGUONFacade
    Private objFcBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
    Private BC As Xtr_CustomerStatistic
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Grid_Khahhang.Visible = True
            ReportToolbar1.Visible = False
            ReportToolbar1.Visible = False
            loadNguon()
            loadTime()
            loaddata()
        Else
            loadReport()
            loaddata()
        End If

    End Sub
#Region "load dữ liệu"
    Private Sub loaddata()
        Dim dt As DataTable
        dt = Getdata()
        Grid_Khahhang.DataSource = dt
        Grid_Khahhang.DataBind()
    End Sub
    Private Function Getdata() As DataTable
        objFcBaocaoKhachhang = New BO.clsB_BaoCao_Khachhang
        Dim dt As New DataTable
        Try
            If chk_Nguon.Checked Then
                dt = objFcBaocaoKhachhang.ThongkeKH_Nguon(Aspx_Tungay.Value, Aspx_Denngay.Value, cbo_Nguon.Value.ToString, Session("uId_Cuahang"))
            Else
                dt = objFcBaocaoKhachhang.ThongkeKH_Tatca(Aspx_Tungay.Value, Aspx_Denngay.Value, Session("uId_Cuahang"))
            End If
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
            End If
        Catch ex As Exception

        End Try
        Return dt
    End Function
    Private Sub loadNguon()
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Try
            cbo_Nguon.DataSource = objFcNguon.SelectAllTable
            cbo_Nguon.ValueField = "uId_Nguon"
            cbo_Nguon.TextField = "nv_Nguon_vn"
            cbo_Nguon.SelectedIndex = 0
            cbo_Nguon.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub loadReport()
        Try
            Dim dt As DataTable
            dt = Getdata()
            BC = New Xtr_CustomerStatistic
            BC.bind(dt)
            ReportViewer1.Report = BC
            If chk_Nguon.Checked Then
                BC.lbl_Tieuchi.Text = "Nguồn " + cbo_Nguon.SelectedItem.ToString
            Else
                BC.lbl_Tieuchi.Text = "Tất cả"
            End If
            BC.lbl_Tungay.Text = Aspx_Tungay.Text
            BC.lbl_Denngay.Text = Aspx_Denngay.Text
            Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
            Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
            objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
            BC.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
            BC.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
            BC.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
            BC.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
            'BC.lbl_Tencuahang.Text = Session("nv_Tencuahang_vn")
            'BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "support"
    Private Sub CheckPhanQuyen()
        objEnPhanQuyen = objFcPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "01532f63-c150-4590-8f37-18dbc57b7cfb")
        If Not objEnPhanQuyen.b_Enable Then
            Response.Redirect("../ThongBaoQuyen.aspx")
        End If
    End Sub
    Private Sub UpdateExportMode()
        Grid_Khahhang.SettingsDetail.ExportMode = CType(System.Enum.Parse(GetType(GridViewDetailExportMode), GridViewDetailExportMode.None.ToString()), GridViewDetailExportMode)
    End Sub
#End Region

    Private Sub btn_Report_Click(sender As Object, e As EventArgs) Handles btn_Report.Click
        Grid_Khahhang.Visible = False
        ReportToolbar1.Visible = True
        ReportViewer1.Visible = True
        loadReport()
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        Grid_Khahhang.Visible = True
        ReportToolbar1.Visible = False
        ReportViewer1.Visible = False
        loaddata()
    End Sub

    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        UpdateExportMode()
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Customer/ReportForm_Cus.aspx")
    End Sub
End Class