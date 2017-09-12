Imports System.IO

Partial Public Class DM_Nhomdichvu
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_NHOMDICHVUFacade
    Private objEn As New CM.TNTP_DM_NHOMDICHVUEntity
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvNhomdichvu.AllowPaging = False
        GvNhomdichvu.Columns(2).Visible = False
        GvNhomdichvu.Columns(3).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMNhomDichVu_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvNhomdichvu)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvNhomdichvu.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "f56a579c-db30-46f7-9d39-d4e03a21eb04")
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

    Private Property GridViewSortDirection() As String
        Get
            Return If(TryCast(ViewState("SortDirection"), String), "ASC")
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Private Property GridViewSortExpression() As String
        Get
            Return If(TryCast(ViewState("SortExpression"), String), String.Empty)
        End Get
        Set(ByVal value As String)
            ViewState("SortExpression") = value
        End Set
    End Property

    Private Function GetSortDirection() As String
        Select Case GridViewSortDirection
            Case "ASC"
                GridViewSortDirection = "DESC"
                Exit Select
            Case "DESC"
                GridViewSortDirection = "ASC"
                Exit Select
        End Select

        Return GridViewSortDirection
    End Function

    Protected Function SortDataTable(ByVal dataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView
        If dataTable IsNot Nothing Then
            Dim dataView As New DataView(dataTable)
            If GridViewSortExpression <> String.Empty Then
                If isPageIndexChanging Then
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)
                Else
                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())
                End If
            End If
            Return dataView
        Else
            Return New DataView()
        End If
    End Function

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles GvNhomdichvu.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GvNhomdichvu.PageIndex
        GvNhomdichvu.DataSource = SortDataTable(GetData(), False)
        GvNhomdichvu.DataBind()
        GvNhomdichvu.PageIndex = pageIndex
    End Sub

    Private Function GetData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable(Session("uId_Cuahang"))
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        Return dt
    End Function

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable(Session("uId_Cuahang"))
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvNhomdichvu.DataSource = dt
        GvNhomdichvu.DataBind()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvNhomdichvu.PageIndexChanging
        GvNhomdichvu.DataSource = SortDataTable(GetData(), True)
        GvNhomdichvu.PageIndex = e.NewPageIndex
        GvNhomdichvu.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvNhomdichvu.PreRender
        If Me.GvNhomdichvu.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvNhomdichvu.Rows(GvNhomdichvu.EditIndex).FindControl("ddlCuaHang"), DropDownList)
            Dim dt As New DataTable()
            dt = objFCCuaHang.SelectAllTable
            ddl.DataSource = dt
            ddl.DataTextField = "nv_Tencuahang_vn"
            ddl.DataValueField = "uId_Cuahang"
            ddl.DataBind()
        End If
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvNhomdichvu.RowDeleting
        Dim id As String
        If GvNhomdichvu.DataKeys.Count <> 0 Then
            id = GvNhomdichvu.DataKeys(e.RowIndex).Values("uId_Nhomdichvu").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvNhomdichvu.RowUpdating
        Dim grv As GridViewRow = GvNhomdichvu.Rows(e.RowIndex)
        Dim uId_Nhomdichvu As String = Convert.ToString(GvNhomdichvu.DataKeys(e.RowIndex)("uId_Nhomdichvu"))
        With objEn
            .uId_Nhomdichvu = uId_Nhomdichvu
            .uId_Cuahang = CStr(CType(grv.FindControl("ddlCuaHang"), DropDownList).SelectedValue)
            .nv_TennhomDichvu_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvNhomdichvu.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub GvDichvu_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvNhomdichvu.SelectedIndexChanged
        Dim grv As GridViewRow = GvNhomdichvu.Rows(GvNhomdichvu.SelectedIndex)
        Dim uId_Nhomdichvu As String = Convert.ToString(GvNhomdichvu.DataKeys(GvNhomdichvu.SelectedIndex)("uId_Nhomdichvu"))
        Session("uId_Nhomdichvu") = uId_Nhomdichvu
        Response.Redirect("~/DANHMUC/Add_DM_Nhomdichvu.aspx")
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvNhomdichvu.RowEditing
        Session("uId_Nhomdichvu") = Convert.ToString(GvNhomdichvu.DataKeys(GvNhomdichvu.SelectedIndex)("uId_Nhomdichvu"))
        Response.Redirect("~/DANHMUC/Add_DM_Nhomdichvu.aspx")
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvNhomdichvu.RowCancelingEdit
        GvNhomdichvu.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Nhomdichvu.aspx")
    End Sub
End Class