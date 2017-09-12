Imports System.IO

Partial Public Class DM_Quocgia
    Inherits System.Web.UI.Page

    Private objFC As New BO.CRM_DM_QUOCGIAFacade
    Private objEn As New CM.CRM_DM_QUOCGIAEntity

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

#Region "Events In Form"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Quocgia.aspx")
    End Sub

    Protected Sub btn_XuatExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvQuocgia.AllowPaging = False
        GvQuocgia.Columns(3).Visible = False
        GvQuocgia.Columns(4).Visible = False
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

        frm.Controls.Add(GvQuocgia)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvQuocgia.AllowPaging = True
    End Sub
#End Region

#Region "Events of  Grid"
    Private Sub GvQuocgia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GvQuocgia.SelectedIndexChanged
        Dim grv As GridViewRow = GvQuocgia.Rows(GvQuocgia.SelectedIndex)
        Dim uId_Quocgia As String = Convert.ToString(GvQuocgia.DataKeys(GvQuocgia.SelectedIndex)("uId_Quocgia"))
        Session("suId_Quocgia") = uId_Quocgia
        Response.Redirect("DM_Tinhthanh.aspx")
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvQuocgia.RowDeleting
        Dim id As String
        If GvQuocgia.DataKeys.Count <> 0 Then
            id = GvQuocgia.DataKeys(e.RowIndex).Values("uId_Quocgia").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvQuocgia.RowUpdating
        Dim grv As GridViewRow = GvQuocgia.Rows(e.RowIndex)
        Dim uId_Quocgia As String = Convert.ToString(GvQuocgia.DataKeys(e.RowIndex)("uId_Quocgia"))

        With objEn
            .uId_Quocgia = uId_Quocgia
            .v_MaQuocgia = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_TenQuocgia = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvQuocgia.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvQuocgia.PageIndexChanging
        GvQuocgia.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvQuocgia.RowEditing
        GvQuocgia.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvQuocgia.RowCancelingEdit
        GvQuocgia.EditIndex = -1
        LoadData()
    End Sub
#End Region

#Region "User Fucntions"

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
        Dim dt As New DataTable
        dt = objFC.SelectAllTable
        'If dt.Rows.Count = 0 Then
        '    dt.Rows.Add(dt.NewRow())
        'End If
        GvQuocgia.DataSource = dt
        GvQuocgia.DataBind()
    End Sub
#End Region

  
End Class