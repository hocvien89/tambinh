Imports System.IO

Partial Public Class DM_Goidichvu
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_GOIDICHVUFacade
    Private objEn As New CM.TNTP_DM_GOIDICHVUEntity

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()

        End If
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "c375132c-73dc-42de-88d8-f5a3ae104270")
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvGoidichvu.AllowPaging = False
        GvGoidichvu.Columns(1).Visible = False
        GvGoidichvu.Columns(2).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMGoiDichVu_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvGoidichvu)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvGoidichvu.AllowPaging = True
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles GvGoidichvu.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GvGoidichvu.PageIndex
        GvGoidichvu.DataSource = SortDataTable(GetData(), False)
        GvGoidichvu.DataBind()
        GvGoidichvu.PageIndex = pageIndex
    End Sub

    Private Function GetData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable()
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        Return dt
    End Function

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable()
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvGoidichvu.DataSource = dt
        GvGoidichvu.DataBind()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvGoidichvu.PageIndexChanging
        GvGoidichvu.DataSource = SortDataTable(GetData(), True)
        GvGoidichvu.PageIndex = e.NewPageIndex
        GvGoidichvu.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvGoidichvu.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvGoidichvu.RowDeleting
        Dim id As String
        If GvGoidichvu.DataKeys.Count <> 0 Then
            id = GvGoidichvu.DataKeys(e.RowIndex).Values("uId_Goidichvu").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvGoidichvu.RowUpdating
        Dim grv As GridViewRow = GvGoidichvu.Rows(e.RowIndex)
        Dim uId_Goidichvu As String = Convert.ToString(GvGoidichvu.DataKeys(e.RowIndex)("uId_Goidichvu"))
        With objEn
            .uId_Goidichvu = uId_Goidichvu
            .nv_Tengoi_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvGoidichvu.EditIndex = -1
        LoadData()
    End Sub


    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvGoidichvu.RowEditing
        GvGoidichvu.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvGoidichvu.RowCancelingEdit
        GvGoidichvu.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Goidichvu.aspx")
    End Sub

End Class