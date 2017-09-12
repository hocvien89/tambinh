Imports System.IO

Partial Public Class DM_Thietbi
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLP_DM_THIETBIFacade
    Private objEn As New CM.QLP_DM_THIETBIEntity
    Private objEn_List As List(Of CM.QLP_DM_PHONGEntity) = Nothing
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvThietBi.AllowPaging = False
        GvThietBi.Columns(4).Visible = False
        GvThietBi.Columns(5).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMThietBi_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvThietBi)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvThietBi.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "858a950d-ac1a-4261-b7b7-2cd2529fb85c")
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles GvThietBi.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GvThietBi.PageIndex
        GvThietBi.DataSource = SortDataTable(GetData(), False)
        GvThietBi.DataBind()
        GvThietBi.PageIndex = pageIndex
    End Sub

    Private Function GetData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable("")
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        Return dt
    End Function

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable("")
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvThietBi.DataSource = dt
        GvThietBi.DataBind()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvThietBi.PageIndexChanging
        GvThietBi.DataSource = SortDataTable(GetData(), True)
        GvThietBi.PageIndex = e.NewPageIndex
        GvThietBi.DataBind()
    End Sub

    Protected Sub GvThietBi_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvThietBi.PreRender
        If Me.GvThietBi.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvThietBi.Rows(GvThietBi.EditIndex).FindControl("ddlCuaHang"), DropDownList)
            Dim dt As New DataTable()
            dt = objFCCuaHang.SelectAllTable
            ddl.DataSource = dt
            ddl.DataTextField = "nv_Tencuahang_vn"
            ddl.DataValueField = "uId_Cuahang"
            ddl.DataBind()
        End If
    End Sub

    Protected Sub GvThietBi_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvThietBi.RowDeleting
        Dim id As String
        If GvThietBi.DataKeys.Count <> 0 Then
            id = GvThietBi.DataKeys(e.RowIndex).Values("uId_Thietbi").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub GvThietBi_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvThietBi.RowUpdating
        Dim grv As GridViewRow = GvThietBi.Rows(e.RowIndex)
        Dim uId_Thietbi As String = Convert.ToString(GvThietBi.DataKeys(e.RowIndex)("uId_Thietbi"))
        With objEn
            .uId_Thietbi = uId_Thietbi
            .uId_Cuahang = CStr(CType(grv.FindControl("ddlCuaHang"), DropDownList).SelectedValue)
            .v_Mathietbi = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Tenthietbi_vn = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
            .nv_Ghichu_vn = CStr(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvThietBi.EditIndex = -1
        LoadData()
    End Sub


    Protected Sub GvThietBi_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvThietBi.RowEditing
        GvThietBi.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub GvThietBi_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvThietBi.RowCancelingEdit
        GvThietBi.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Thietbi.aspx")
    End Sub
End Class