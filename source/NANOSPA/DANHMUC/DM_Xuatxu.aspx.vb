Imports System.IO

Partial Public Class DM_Xuatxu
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_XUATXUFacade
    Private objEn As New CM.QLMH_DM_XUATXUEntity
    Private objEn_List As List(Of CM.QLMH_DM_XUATXUEntity) = Nothing
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvXuatXu.AllowPaging = False
        GvXuatXu.Columns(1).Visible = False
        GvXuatXu.Columns(2).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMXuatXu_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvXuatXu)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvXuatXu.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "e8c8d906-7bcd-4077-9522-e8364a47fa58")
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

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable()
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvXuatXu.DataSource = dt
        GvXuatXu.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvXuatXu.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvXuatXu.RowDeleting
        Dim id As String
        If GvXuatXu.DataKeys.Count <> 0 Then
            id = GvXuatXu.DataKeys(e.RowIndex).Values("uid_Xuatxu").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvXuatXu.RowUpdating
        Dim grv As GridViewRow = GvXuatXu.Rows(e.RowIndex)
        Dim uId_Xuatxu As String = Convert.ToString(GvXuatXu.DataKeys(e.RowIndex)("uid_Xuatxu"))
        With objEn
            .uid_Xuatxu = uId_Xuatxu
            .nv_Tenxuatxu_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvXuatXu.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvXuatXu.PageIndexChanging
        GvXuatXu.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvXuatXu.RowEditing
        GvXuatXu.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvXuatXu.RowCancelingEdit
        GvXuatXu.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Xuatxu.aspx")
    End Sub
End Class
