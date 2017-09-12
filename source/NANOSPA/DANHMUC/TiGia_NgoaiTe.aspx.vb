Imports System.IO

Partial Public Class TiGia_NgoaiTe
    Inherits System.Web.UI.Page
    Private objFCTigia As New BO.TNTP_NGOAITE_TYGIAFacade
    Private objEnTigia As New CM.TNTP_NGOAITE_TYGIAEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvNgoaite.AllowPaging = False
        GvNgoaite.Columns(3).Visible = False
        GvNgoaite.Columns(4).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=TiGiaNgoaiTe_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvNgoaite)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvNgoaite.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "56758d3f-d0b8-4467-88d8-2dfdd1ee7cb1")
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
        dt = objFCTigia.SelectAllTable("")
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvNgoaite.DataSource = dt
        GvNgoaite.DataBind()
    End Sub



    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvNgoaite.RowDeleting
        Dim id As String
        Dim ngay As Date
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        If GvNgoaite.DataKeys.Count <> 0 Then
            id = GvNgoaite.DataKeys(e.RowIndex).Values("uId_Ngoaite").ToString()
            ngay = Convert.ToDateTime(CType(GvNgoaite.Rows(e.RowIndex).FindControl("Label1"), Label).Text, sFormat)
            objFCTigia.DeleteByID(id, ngay)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvNgoaite.RowUpdating
        Dim grv As GridViewRow = GvNgoaite.Rows(e.RowIndex)
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        Dim uId_Ngoaite As String = Convert.ToString(GvNgoaite.DataKeys(e.RowIndex)("uId_Ngoaite"))
        With objEnTigia
            .uId_Ngoaite = uId_Ngoaite
            .d_Ngay = Convert.ToDateTime(CType(grv.FindControl("Label1"), Label).Text, sFormat)
            .f_Tygia_VND = CStr(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
        End With
        objFCTigia.Update(objEnTigia)
        GvNgoaite.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvNgoaite.PageIndexChanging
        GvNgoaite.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvNgoaite.RowEditing
        GvNgoaite.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvNgoaite.RowCancelingEdit
        GvNgoaite.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_TiGia_NgoaiTe.aspx")
    End Sub

End Class