Imports System.IO

Partial Public Class DM_Trangthai
    Inherits System.Web.UI.Page
    Private objFC As New BO.CRM_DM_TRANGTHAIFacade
    Private objEn As New CM.CRM_DM_TRANGTHAIEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvTrangthai.AllowPaging = False
        GvTrangthai.Columns(5).Visible = False
        GvTrangthai.Columns(6).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMTrangThai_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvTrangthai)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvTrangthai.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "8019d326-f613-4c74-8702-fab99cfd9117")
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
        GvTrangthai.DataSource = dt
        GvTrangthai.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvTrangthai.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvTrangthai.RowDeleting
        Dim id As String
        If GvTrangthai.DataKeys.Count <> 0 Then
            id = GvTrangthai.DataKeys(e.RowIndex).Values("uId_Trangthai").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvTrangthai.RowUpdating
        Dim grv As GridViewRow = GvTrangthai.Rows(e.RowIndex)
        Dim uId_Trangthai As String = Convert.ToString(GvTrangthai.DataKeys(e.RowIndex)("uId_Trangthai"))
        With objEn
            .uId_Trangthai = uId_Trangthai
            .v_Matrangthai = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Tentrangthai_vn = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
            .v_Mau_Chu = CStr(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
            .v_Mau_Nen = CStr(CType(grv.Cells(3).Controls(0), TextBox).Text.Trim)
            .i_Type = CInt(CType(grv.Cells(4).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvTrangthai.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvTrangthai.PageIndexChanging
        GvTrangthai.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvTrangthai.RowEditing
        GvTrangthai.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvTrangthai.RowCancelingEdit
        GvTrangthai.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Trangthai.aspx")
    End Sub

End Class