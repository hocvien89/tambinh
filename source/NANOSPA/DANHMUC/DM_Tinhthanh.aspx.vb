Imports System.IO

Partial Public Class DM_Tinhthanh
    Inherits System.Web.UI.Page

    Private objFC As New BO.CRM_DM_TINHTHANHFacade
    Private objEn As New CM.CRM_DM_TINHTHANHEntity

    Private objFCCuaHang As New BO.CRM_DM_QUOCGIAFacade
    Private objEnCuaHang As New CM.CRM_DM_QUOCGIAEntity

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
        Me.GvTinhthanh.AllowPaging = False
        GvTinhthanh.Columns(3).Visible = False
        GvTinhthanh.Columns(4).Visible = False
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

        frm.Controls.Add(GvTinhthanh)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvTinhthanh.AllowPaging = True
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
        'Lay Uid_QUocgia
        Dim suId_Quocgia As String = oLib.NullProString(Session("suId_Quocgia"))

        Dim dt As New DataTable
        dt = objFC.SelectAllTable(suId_Quocgia)
       
        GvTinhthanh.DataSource = dt
        GvTinhthanh.DataBind()
    End Sub

    Private Sub GvTinhthanh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvTinhthanh.SelectedIndexChanged
        Dim grv As GridViewRow = GvTinhthanh.Rows(GvTinhthanh.SelectedIndex)
        Dim uId_Tinhthanh As String = Convert.ToString(GvTinhthanh.DataKeys(GvTinhthanh.SelectedIndex)("uId_Tinhthanh"))
        Session("suId_Tinhthanh") = uId_Tinhthanh
        Response.Redirect("DM_Quanhuyen.aspx")
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvTinhthanh.PreRender
        If Me.GvTinhthanh.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvTinhthanh.Rows(GvTinhthanh.EditIndex).FindControl("ddlQuocgia"), DropDownList)
            Dim dt As New DataTable()
            dt = objFCCuaHang.SelectAllTable
            ddl.DataSource = dt
            ddl.DataTextField = "nv_Tenquocgia"
            ddl.DataValueField = "uId_Quocgia"
            ddl.DataBind()
        End If
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvTinhthanh.RowDeleting
        Dim id As String
        If GvTinhthanh.DataKeys.Count <> 0 Then
            id = GvTinhthanh.DataKeys(e.RowIndex).Values("uId_Tinhthanh").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvTinhthanh.RowUpdating
        Dim grv As GridViewRow = GvTinhthanh.Rows(e.RowIndex)
        Dim uId_Kho As String = Convert.ToString(GvTinhthanh.DataKeys(e.RowIndex)("uId_Tinhthanh"))
        With objEn
            .uId_Tinhthanh = uId_Kho
            .uId_Quocgia = CStr(CType(grv.FindControl("ddlQuocgia"), DropDownList).SelectedValue)
            .v_MaTinhthanh = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Tentinhthanh = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvTinhthanh.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvTinhthanh.PageIndexChanging
        GvTinhthanh.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvTinhthanh.RowEditing
        GvTinhthanh.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvTinhthanh.RowCancelingEdit
        GvTinhthanh.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Tinhthanh.aspx")
    End Sub

End Class