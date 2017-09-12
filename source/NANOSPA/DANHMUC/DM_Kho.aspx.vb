Imports System.IO

Partial Public Class DM_Kho
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_KHOFacade
    Private objEn As New CM.QLMH_DM_KHOEntity
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
        Me.GvKho.AllowPaging = False
        GvKho.Columns(3).Visible = False
        GvKho.Columns(4).Visible = False
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

        frm.Controls.Add(GvKho)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvKho.AllowPaging = True
    End Sub

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
        dt = objFC.SelectAllTable(Session("uId_Cuahang"))
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvKho.DataSource = dt
        GvKho.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvKho.PreRender
        If Me.GvKho.EditIndex <> -1 Then
            Dim ddl As DropDownList = TryCast(GvKho.Rows(GvKho.EditIndex).FindControl("ddlCuaHang"), DropDownList)
            Dim dt As New DataTable()
            dt = objFCCuaHang.SelectAllTable
            ddl.DataSource = dt
            ddl.DataTextField = "nv_Tencuahang_vn"
            ddl.DataValueField = "uId_Cuahang"
            ddl.DataBind()
        End If
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvKho.RowDeleting
        Dim id As String
        If GvKho.DataKeys.Count <> 0 Then
            id = GvKho.DataKeys(e.RowIndex).Values("uId_Kho").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvKho.RowUpdating
        Dim grv As GridViewRow = GvKho.Rows(e.RowIndex)
        Dim uId_Kho As String = Convert.ToString(GvKho.DataKeys(e.RowIndex)("uId_Kho"))
        With objEn
            .uId_Kho = uId_Kho
            .uId_Cuahang = CStr(CType(grv.FindControl("ddlCuaHang"), DropDownList).SelectedValue)
            .v_Makho = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Tenkho_vn = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvKho.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvKho.PageIndexChanging
        GvKho.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvKho.RowEditing
        GvKho.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvKho.RowCancelingEdit
        GvKho.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Kho.aspx")
    End Sub

End Class