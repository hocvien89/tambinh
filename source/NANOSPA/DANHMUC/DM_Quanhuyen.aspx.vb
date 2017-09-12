Imports System.IO

Partial Public Class DM_Quanhuyen
    Inherits System.Web.UI.Page

    Private objFC As New BO.CRM_DM_QUANHUYENFacade
    Private objEn As New CM.CRM_DM_QUANHUYENEntity

    Private objFCTinhthanh As New BO.CRM_DM_TINHTHANHFacade
    Private objEnTinhthanh As New CM.CRM_DM_TINHTHANHEntity

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Dim oLib As New Lib_SAT.cls_Pub_Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub btn_XuatExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvQuanhuyen.AllowPaging = False
        GvQuanhuyen.Columns(3).Visible = False
        GvQuanhuyen.Columns(4).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMKho_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvQuanhuyen)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvQuanhuyen.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "f535ac03-b889-4ef1-b9d1-7645e2f90a8b")
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
        'Lay Uid_Tinhthanh
        Dim suId_Tinhthanh As String = oLib.NullProString(Session("suId_Tinhthanh"))

        Dim dt As New DataTable
        dt = objFC.SelectAllTable(suId_Tinhthanh)

        GvQuanhuyen.DataSource = dt
        GvQuanhuyen.DataBind()
    End Sub

    Private Sub GvQuanhuyen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvQuanhuyen.SelectedIndexChanged
        Dim grv As GridViewRow = GvQuanhuyen.Rows(GvQuanhuyen.SelectedIndex)
        Dim uId_Quanhuyen As String = Convert.ToString(GvQuanhuyen.DataKeys(GvQuanhuyen.SelectedIndex)("uId_Quanhuyen"))
        Session("suId_Quanhuyen") = uId_Quanhuyen
        Response.Redirect("DM_Xaphuong.aspx")
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvQuanhuyen.PreRender
        If Me.GvQuanhuyen.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvQuanhuyen.Rows(GvQuanhuyen.EditIndex).FindControl("ddlTinhthanh"), DropDownList)
            Dim dt As New DataTable()
            Dim suId_Quocgia As String = oLib.NullProString(Session("suId_Quocgia"))
            dt = objFCTinhthanh.SelectAllTable(suId_Quocgia)
            ddl.DataSource = dt
            ddl.DataTextField = "nv_TenTinhthanh"
            ddl.DataValueField = "uId_Tinhthanh"
            ddl.DataBind()
        End If
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvQuanhuyen.RowDeleting
        Dim id As String
        If GvQuanhuyen.DataKeys.Count <> 0 Then
            id = GvQuanhuyen.DataKeys(e.RowIndex).Values("uId_Quanhuyen").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvQuanhuyen.RowUpdating
        Dim grv As GridViewRow = GvQuanhuyen.Rows(e.RowIndex)
        Dim uId_Quanhuyen As String = Convert.ToString(GvQuanhuyen.DataKeys(e.RowIndex)("uId_Quanhuyen"))
        With objEn
            .uId_Quanhuyen = uId_Quanhuyen
            .uId_Tinhthanh = CStr(CType(grv.FindControl("ddlTinhthanh"), DropDownList).SelectedValue)
            .v_MaQuanhuyen = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Tenquanhuyen = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvQuanhuyen.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvQuanhuyen.PageIndexChanging
        GvQuanhuyen.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvQuanhuyen.RowEditing
        GvQuanhuyen.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvQuanhuyen.RowCancelingEdit
        GvQuanhuyen.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Quanhuyen.aspx")
    End Sub

End Class