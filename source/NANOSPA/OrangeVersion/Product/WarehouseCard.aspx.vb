Public Class WarehouseCard
    Inherits System.Web.UI.Page
    Private objFcDMKho As BO.QLMH_DM_KHOFacade
    Private objFcMathang As BO.QLMH_DM_MATHANGFacade
    Private objFcBaoCaoMH As BO.clsb_BaoCaoQLMH
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Load_DropDownList_Kho()
            deTuNgay.Date = Now.Month.ToString & "/01" & "/" & Now.Year.ToString
            deDenNgay.Date = DateTime.Now
        End If
        Load_DropDownListDMMathang()
    End Sub
#Region "Load thong tin"
    Private Sub Load_DropDownList_Kho()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        ddlKho.DataSource = objFcDMKho.SelectAllTable(Session("uId_Cuahang"))
        ddlKho.TextField = "nv_Tenkho_vn"
        ddlKho.ValueField = "uId_Kho"
        ddlKho.SelectedIndex = 0
        ddlKho.DataBind()
    End Sub
    Private Sub Load_DropDownListDMMathang()
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        ddlMathang.DataSource = objFcMathang.SelectTimKiem("0", "0", "")
        ddlMathang.TextField = "nv_TenMathang_vn"
        ddlMathang.ValueField = "uId_Mathang"
        ddlMathang.DataBind()
    End Sub
#End Region
#Region "Button"
    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        objFcBaoCaoMH = New BO.clsb_BaoCaoQLMH
        Dim dt As DataTable
        dt = objFcBaoCaoMH.TheKho(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text), ddlMathang.SelectedItem.Value.ToString, ddlKho.SelectedItem.Value.ToString)
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
            dgvDevexpress.DataBind()
        End If
    End Sub
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Product/ReportForm_Product.aspx")
    End Sub
#End Region
End Class