Imports System.IO

Partial Public Class DM_Mathang
    Inherits System.Web.UI.Page
    Private objEn_LoaiMathang As New CM.QLMH_DM_LOAIMATHANGEntity
    Private objFC_LoaiMathang As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objEn_NhomMathang As New CM.QLMH_DM_NHOMMATHANGEntity
    Private objFC_NhomMathang As New BO.QLMH_DM_NHOMMATHANGFacade
    Private objFCXuatxu As New BO.QLMH_DM_XUATXUFacade
    Private objEnXuatxu As New CM.QLMH_DM_XUATXUEntity
    Private objFC As New BO.QLMH_DM_MATHANGFacade
    Private objEn As New CM.QLMH_DM_MATHANGEntity

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CheckUser()
            LoadDDLLoaimathang()
            LoadDDLNhommathang()
            Me.LoadData()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvMathang.AllowPaging = False
        GvMathang.Columns(10).Visible = False
        GvMathang.Columns(11).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMMatHang_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvMathang)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvMathang.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "f3e70724-d8d5-4896-b96b-22e7f208d7e6")
        If dt.Rows.Count = 0 Then
            Response.Redirect("../ThongBaoQuyen.aspx")
        Else
            For Each rw As DataRow In dt.Rows
                Dim btnTemp As Button
                btnTemp = tblBatdongsan_Moi.FindControl(rw("nv_Tenbien"))
                btnTemp.Enabled = rw("b_Enable")
                'Response.Write("<%" & rw("nv_Tenbien") & ".Enabled =" & rw("b_Enable") & "%>")
            Next
        End If
    End Sub

    Private Property GridViewSortDirection() As String
        Get
            Return If(TryCast(ViewState("SortDirection"), String), "ASC")
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Private Property GridViewSortExpression() As String
        Get
            Return If(TryCast(ViewState("SortExpression"), String), String.Empty)
        End Get
        Set(ByVal value As String)
            ViewState("SortExpression") = value
        End Set
    End Property

    Private Function GetSortDirection() As String
        Select Case GridViewSortDirection
            Case "ASC"
                GridViewSortDirection = "DESC"
                Exit Select
            Case "DESC"
                GridViewSortDirection = "ASC"
                Exit Select
        End Select

        Return GridViewSortDirection
    End Function

    Protected Function SortDataTable(ByVal dataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView
        If dataTable IsNot Nothing Then
            Dim dataView As New DataView(dataTable)
            If GridViewSortExpression <> String.Empty Then
                If isPageIndexChanging Then
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)
                Else
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())
                End If
            End If
            Return dataView
        Else
            Return New DataView()
        End If
    End Function

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles GvMathang.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GvMathang.PageIndex
        GvMathang.DataSource = SortDataTable(GetData(), False)
        GvMathang.DataBind()
        GvMathang.PageIndex = pageIndex
    End Sub

    Private Function GetData()
        Dim dt As New DataTable
        dt = objFC.SelectTimKiem(ddlLoaimathang.SelectedValue, ddlNhommathang.SelectedValue, txtTenMH.Text.Trim)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        Return dt
    End Function

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectTimKiem(ddlLoaimathang.SelectedValue, ddlNhommathang.SelectedValue, txtTenMH.Text)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvMathang.DataSource = dt
        GvMathang.DataBind()
    End Sub
    Private Sub LoadDDLLoaimathang()
        Dim dt As New DataTable
        dt = objFC_LoaiMathang.SelectAllTable
        ddlLoaimathang.DataSource = dt
        ddlLoaimathang.DataTextField = "nv_Tenloaimathang_vn"
        ddlLoaimathang.DataValueField = "uId_Loaimathang"
        ddlLoaimathang.DataBind()
    End Sub

    Private Sub LoadDDLNhommathang()
        Dim dt As New DataTable
        dt = objFC_NhomMathang.SelectAllTable
        ddlNhommathang.DataSource = dt
        ddlNhommathang.DataTextField = "nv_Tennhommathang_vn"
        ddlNhommathang.DataValueField = "uId_Nhommathang"
        ddlNhommathang.DataBind()
    End Sub
    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvMathang.PageIndexChanging
        GvMathang.DataSource = SortDataTable(GetData(), True)
        GvMathang.PageIndex = e.NewPageIndex
        GvMathang.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvMathang.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvMathang.RowDeleting
        Dim id As String
        If GvMathang.DataKeys.Count <> 0 Then
            id = GvMathang.DataKeys(e.RowIndex).Values("uId_Mathang").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvMathang.RowUpdating

    End Sub


    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvMathang.RowEditing

    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvMathang.RowCancelingEdit

    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Session("uId_Mathang") = ""
        Response.Redirect("Add_DM_Mathang.aspx")
    End Sub
    Protected Sub btnTaoMaVach_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTaoMaVach.Click
        Session("DS_SPBarcode") = ""
        Response.Redirect("DS_SPBarcode.aspx")
    End Sub
    Protected Sub GvDichvu_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvMathang.SelectedIndexChanged
        Dim grv As GridViewRow = GvMathang.Rows(GvMathang.SelectedIndex)
        Dim uId_Mathang As String = Convert.ToString(GvMathang.DataKeys(GvMathang.SelectedIndex)("uId_Mathang"))
        Session("uId_Mathang") = uId_Mathang
        Response.Redirect("Add_DM_Mathang.aspx")
    End Sub
    Protected Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
        LoadData()
    End Sub
End Class