Imports System.IO

Partial Public Class DM_Loaimathang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objEn As New CM.QLMH_DM_LOAIMATHANGEntity
    Private objEn_List As List(Of CM.QLMH_DM_LOAIMATHANGEntity) = Nothing

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvLoaimathang.AllowPaging = False
        GvLoaimathang.Columns(1).Visible = False
        GvLoaimathang.Columns(2).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMLoaiMatHang_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvLoaimathang)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvLoaimathang.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "2bfdd5bb-dd3a-46ec-a9be-6717c60f41ee")
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
        GvLoaimathang.DataSource = dt
        GvLoaimathang.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvLoaimathang.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvLoaimathang.RowDeleting
        Dim id As String
        If GvLoaimathang.DataKeys.Count <> 0 Then
            id = GvLoaimathang.DataKeys(e.RowIndex).Values("uId_Loaimathang").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvLoaimathang.RowUpdating
        Dim grv As GridViewRow = GvLoaimathang.Rows(e.RowIndex)
        Dim uId_Cuahang As String = Convert.ToString(GvLoaimathang.DataKeys(e.RowIndex)("uId_Loaimathang"))
        With objEn
            .uId_Loaimathang = uId_Cuahang
            .nv_Tenloaimathang_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvLoaimathang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvLoaimathang.PageIndexChanging
        GvLoaimathang.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvLoaimathang.RowEditing
        GvLoaimathang.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvLoaimathang.RowCancelingEdit
        GvLoaimathang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Loaimathang.aspx")
    End Sub
End Class