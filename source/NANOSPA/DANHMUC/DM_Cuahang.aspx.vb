Imports System.IO

Partial Public Class DM_Cuahang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QT_DM_CUAHANGFacade
    Private objEn As New CM.QT_DM_CUAHANGEntity
    Private objEn_List As List(Of CM.QT_DM_CUAHANGEntity) = Nothing

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Private objFCNhanvien As New BO.QT_DM_NHANVIENFacade
    Private objEnNhanvien As New CM.QT_DM_NHANVIENEntity
    Dim pc As New Public_Class

    Private Sub DM_Cuahang_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Kiem tra da dang nhap chua, neu chua bawt buoc phai dang nhap
        Dim sUid_Nhanvien_Dangnhap As String = ""
        Try
            sUid_Nhanvien_Dangnhap = Session("uId_Nhanvien_Dangnhap")
        Catch ex As Exception
        Finally
            If sUid_Nhanvien_Dangnhap = "" Then Response.Redirect("../Login.aspx")
        End Try
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "02a4897a-ba97-4cf5-89ba-87fa5e83ef67")
        If dt.Rows.Count = 0 Then
            Response.Redirect("../ThongBaoQuyen.aspx")
        Else
            Public_Class.CheckUser(Me.Page, dt)
        End If
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvCuahang.AllowPaging = False
        GvCuahang.Columns(4).Visible = False
        GvCuahang.Columns(5).Visible = False

        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMCuaHang_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvCuahang)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvCuahang.AllowPaging = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
            CheckUser()
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles GvCuahang.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GvCuahang.PageIndex
        GvCuahang.DataSource = SortDataTable(GetData(), False)
        GvCuahang.DataBind()
        GvCuahang.PageIndex = pageIndex
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
        GvCuahang.DataSource = dt
        GvCuahang.DataBind()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvCuahang.PageIndexChanging
        GvCuahang.DataSource = SortDataTable(GetData(), True)
        GvCuahang.PageIndex = e.NewPageIndex
        GvCuahang.DataBind()
    End Sub

    Protected Sub Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Session("uId_CuahangMoi") = Nothing
        Response.Redirect("~/DANHMUC/Add_DM_Cuahang.aspx")
    End Sub

    Protected Sub GvCuahang_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvCuahang.RowDeleting
        Dim id As String
        If GvCuahang.DataKeys.Count <> 0 Then
            id = GvCuahang.DataKeys(e.RowIndex).Values("uId_Cuahang").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub GvCuahang_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvCuahang.RowUpdating
        Dim grv As GridViewRow = GvCuahang.Rows(e.RowIndex)
        Dim uId_Cuahang As String = Convert.ToString(GvCuahang.DataKeys(e.RowIndex)("uId_Cuahang"))
        With objEn
            .uId_Cuahang = uId_Cuahang
            .v_Macuahang = CStr(grv.Cells(0).Text.Trim)
            .nv_Tencuahang_vn = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
            .nv_Diachi_vn = CStr(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
            .b_Active = CByte(CType(grv.Cells(3).Controls(0), CheckBox).Checked)
        End With
        objFC.Update(objEn)
        GvCuahang.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub GvCuahang_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvCuahang.SelectedIndexChanged
        Session("uId_CuahangMoi") = Convert.ToString(GvCuahang.DataKeys(GvCuahang.SelectedIndex)("uId_Cuahang"))
        Response.Redirect("Add_DM_Cuahang.aspx")
    End Sub

    Protected Sub GvCuahang_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GvCuahang.RowCommand
        If e.CommandName = "Select" Then
            'GvCuahang .SelectedIndex =
        End If
    End Sub

    Protected Sub GvCuahang_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvCuahang.RowCancelingEdit
        GvCuahang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub GvCuahang_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvCuahang.RowEditing
        GvCuahang.EditIndex = e.NewEditIndex
        LoadData()
    End Sub


End Class


