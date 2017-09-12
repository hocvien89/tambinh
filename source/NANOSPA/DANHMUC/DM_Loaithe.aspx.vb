Imports System.IO

Partial Public Class DM_Loaithe
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_LOAITHEFacade
    Private objEn As New CM.TNTP_DM_LOAITHEEntity

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Dim oLib As New Lib_SAT.cls_Pub_Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvLoaithe.AllowPaging = False
        GvLoaithe.Columns(2).Visible = False
        GvLoaithe.Columns(3).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMLoaiThe_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvLoaithe)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvLoaithe.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "c2012c96-37f9-4867-a3a1-24b83a1a2dd4")
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
        GvLoaithe.DataSource = dt
        GvLoaithe.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvLoaithe.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvLoaithe.RowDeleting
        Dim id As String
        If GvLoaithe.DataKeys.Count <> 0 Then
            id = GvLoaithe.DataKeys(e.RowIndex).Values("uId_Loaithe").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvLoaithe.RowUpdating
        Dim grv As GridViewRow = GvLoaithe.Rows(e.RowIndex)
        Dim uId_Goidichvu As String = Convert.ToString(GvLoaithe.DataKeys(e.RowIndex)("uId_Loaithe"))
        With objEn
            .uId_Loaithe = uId_Goidichvu
            .nv_Tenloaithe_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .f_Sotiendinhmuc = oLib.NullProNumber(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
            .f_Phantramchietkhau = oLib.NullProNumber(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvLoaithe.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvLoaithe.PageIndexChanging
        GvLoaithe.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvLoaithe.RowEditing
        GvLoaithe.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvLoaithe.RowCancelingEdit
        GvLoaithe.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Loaithe.aspx")
    End Sub

End Class