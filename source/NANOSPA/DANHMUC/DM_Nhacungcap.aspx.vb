Imports System.IO

Partial Public Class DM_Nhacungcap
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_NHACUNGCAPFacade
    Private objEn As New CM.QLMH_DM_NHACUNGCAPEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvNhacungcap.AllowPaging = False
        GvNhacungcap.Columns(3).Visible = False
        GvNhacungcap.Columns(4).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMNhaCungCap_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvNhacungcap)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvNhacungcap.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "99a9ef03-9855-4860-a49c-5995ee0282fb")
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
        GvNhacungcap.DataSource = dt
        GvNhacungcap.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvNhacungcap.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvNhacungcap.RowDeleting
        Dim id As String
        If GvNhacungcap.DataKeys.Count <> 0 Then
            id = GvNhacungcap.DataKeys(e.RowIndex).Values("uId_Nhacungcap").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvNhacungcap.RowUpdating
        Dim grv As GridViewRow = GvNhacungcap.Rows(e.RowIndex)
        Dim uId_Nhacungcap As String = Convert.ToString(GvNhacungcap.DataKeys(e.RowIndex)("uId_Nhacungcap"))
        With objEn
            .uId_Nhacungcap = uId_Nhacungcap
            .v_Manhacungcap = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Tennhacungcap_vn = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
            .nv_Diachi_vn = CStr(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvNhacungcap.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvNhacungcap.PageIndexChanging
        GvNhacungcap.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvNhacungcap.RowEditing
        GvNhacungcap.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvNhacungcap.RowCancelingEdit
        GvNhacungcap.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Nhacungcap.aspx")
    End Sub
End Class