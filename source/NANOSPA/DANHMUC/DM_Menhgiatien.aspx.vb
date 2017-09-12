Imports System.IO
Partial Public Class DM_Menhgiatien
    Inherits System.Web.UI.Page
    Private objFCNgoaite As New BO.TNTP_DM_NGOAITEFacade
    Private objEnNgoaite As New CM.TNTP_DM_NGOAITEEntity
    Private objEnMenhGia As New CM.TNTP_DM_MENHGIATIENEntity
    Private objFCMenhgia As New BO.TNTP_DM_MENHGIATIENFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadddlNgoaite()
            LoadData()
        End If
    End Sub
    Private Sub LoadddlNgoaite()
        Dim dt As New DataTable
        dt = objFCNgoaite.SelectAllTable()
        ddlNgoaite.DataSource = dt
        ddlNgoaite.DataValueField = "uId_Ngoaite"
        ddlNgoaite.DataTextField = "v_Ma"
        ddlNgoaite.DataBind()
    End Sub
    Protected Sub LoadData()
        Dim dt As DataTable
        dt = objFCMenhgia.SelectAllTable(ddlNgoaite.SelectedValue)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
        End If
        GvMenhGia.DataSource = dt
        GvMenhGia.DataBind()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvMenhGia.AllowPaging = False
        GvMenhGia.Columns(2).Visible = False
        GvMenhGia.Columns(3).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMMenhgia_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvMenhGia)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvMenhGia.AllowPaging = True
    End Sub
    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Session("uId_Menhgiatien") = Nothing
        Response.Redirect("Add_DM_Menhgiatien.aspx")
    End Sub
    Protected Sub GvMenhGia_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvMenhGia.PreRender
        If Me.GvMenhGia.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvMenhGia.Rows(GvMenhGia.EditIndex).FindControl("ddlNgoaite"), DropDownList)
            Dim dt As New DataTable()
            dt = objFCNgoaite.SelectAllTable()
            ddl.DataSource = dt
            ddl.DataTextField = "v_Ma"
            ddl.DataValueField = "uId_Ngoaite"
            ddl.DataBind()
        End If
    End Sub
    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvMenhGia.RowDeleting
        Dim id As String
        If GvMenhGia.DataKeys.Count <> 0 Then
            id = GvMenhGia.DataKeys(e.RowIndex).Values("uId_Menhgiatien").ToString()
            objFCMenhgia.DeleteByID(id)
        End If
        LoadData()
    End Sub
    Protected Sub Gv_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvMenhGia.SelectedIndexChanged
        Dim grv As GridViewRow = GvMenhGia.Rows(GvMenhGia.SelectedIndex)
        Dim uId_Menhgiatien As String = Convert.ToString(GvMenhGia.DataKeys(GvMenhGia.SelectedIndex)("uId_Menhgiatien"))
        Session("uId_Menhgiatien") = uId_Menhgiatien
        Response.Redirect("Add_DM_Menhgiatien.aspx")
    End Sub
    Protected Sub ddlNgoaite_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlNgoaite.SelectedIndexChanged
        LoadData()
    End Sub
End Class