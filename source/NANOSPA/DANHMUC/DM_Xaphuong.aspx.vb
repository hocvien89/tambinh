Imports System.IO

Partial Public Class DM_Xaphuong
    Inherits System.Web.UI.Page

    Private objFC As New BO.CRM_DM_XAPHUONGFacade
    Private objEn As New CM.CRM_DM_XAPHUONGEntity

    Private objFCQuanhuyen As New BO.CRM_DM_QUANHUYENFacade
    Private objEnQuanhuyen As New CM.CRM_DM_QUANHUYENEntity

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
        Me.GvXaphuong.AllowPaging = False
        GvXaphuong.Columns(3).Visible = False
        GvXaphuong.Columns(4).Visible = False
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

        frm.Controls.Add(GvXaphuong)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvXaphuong.AllowPaging = True
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
        'Lay Uid_Quanhuyen
        Dim suId_Quanhuyen As String = oLib.NullProString(Session("suId_Quanhuyen"))

        Dim dt As New DataTable
        dt = objFC.SelectAllTable(suId_Quanhuyen)

        GvXaphuong.DataSource = dt
        GvXaphuong.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvXaphuong.PreRender
        If Me.GvXaphuong.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvXaphuong.Rows(GvXaphuong.EditIndex).FindControl("ddlQuanhuyen"), DropDownList)
            Dim dt As New DataTable()
            Dim suId_Tinhthanh As String = oLib.NullProString(Session("suId_Tinhthanh"))
            dt = objFCQuanhuyen.SelectAllTable(suId_Tinhthanh)
            ddl.DataSource = dt
            ddl.DataTextField = "nv_TenQuanhuyen"
            ddl.DataValueField = "uId_Quanhuyen"
            ddl.DataBind()
        End If
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvXaphuong.RowDeleting
        Dim id As String
        If GvXaphuong.DataKeys.Count <> 0 Then
            id = GvXaphuong.DataKeys(e.RowIndex).Values("uId_Xaphuong").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvXaphuong.RowUpdating
        Dim grv As GridViewRow = GvXaphuong.Rows(e.RowIndex)
        Dim uId_Xaphuong As String = Convert.ToString(GvXaphuong.DataKeys(e.RowIndex)("uId_Xaphuong"))
        With objEn
            .uId_Xaphuong = uId_Xaphuong
            .uId_Quanhuyen = CStr(CType(grv.FindControl("ddlQuanhuyen"), DropDownList).SelectedValue)
            .v_MaXaphuong = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_TenXaphuong = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvXaphuong.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvXaphuong.PageIndexChanging
        GvXaphuong.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvXaphuong.RowEditing
        GvXaphuong.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvXaphuong.RowCancelingEdit
        GvXaphuong.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Xaphuong.aspx")
    End Sub

End Class