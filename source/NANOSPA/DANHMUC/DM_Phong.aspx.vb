Imports System.IO

Partial Public Class DM_Phong
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLP_DM_PHONGFacade
    Private objEn As New CM.QLP_DM_PHONGEntity
    Private objEn_List As List(Of CM.QLP_DM_PHONGEntity) = Nothing
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CheckUser()
            Me.LoadData()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click
        Me.GvPhong.AllowPaging = False
        GvPhong.Columns(7).Visible = False
        GvPhong.Columns(8).Visible = False
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMPhong_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvPhong)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvPhong.AllowPaging = True
    End Sub

    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "b17e7239-4df9-4eec-8166-cbe96bd9aa52")
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
        GvPhong.DataSource = dt
        GvPhong.DataBind()
    End Sub


    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Phong.aspx")
    End Sub

    Protected Sub GvPhong_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvPhong.RowDeleting
        Dim id As String
        If GvPhong.DataKeys.Count <> 0 Then
            id = GvPhong.DataKeys(e.RowIndex).Values("uId_Phong").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub GvPhong_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvPhong.RowCancelingEdit
        GvPhong.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub GvPhong_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvPhong.RowEditing
        GvPhong.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub GvPhong_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvPhong.RowUpdating
        Dim grv As GridViewRow = GvPhong.Rows(e.RowIndex)
        Dim uId_Cuahang As String = Convert.ToString(GvPhong.DataKeys(e.RowIndex)("uId_Phong"))
        With objEn
            .uId_Phong = uId_Cuahang
            .uId_Cuahang = Session("uId_Cuahang") 'CStr(CType(grv.FindControl("ddlCuaHang"), DropDownList).SelectedValue)
            .nv_Tenphong_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .i_Thutu = CInt(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
            .i_Sokhachtoida = CInt(CType(grv.Cells(3).Controls(0), TextBox).Text.Trim)
            .v_Dienthoai = CStr(CType(grv.Cells(4).Controls(0), TextBox).Text.Trim)
            .v_Mauchu = CStr(CType(grv.Cells(6).Controls(0), TextBox).Text.Trim)
            .v_Maunen = CStr(CType(grv.Cells(5).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvPhong.EditIndex = -1
        LoadData()

    End Sub

    Protected Sub GvPhong_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles GvPhong.DataBound

    End Sub



    'Protected Sub GvPhong_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvPhong.PreRender
    '    If Me.GvPhong.EditIndex <> -1 Then
    '        Dim ddl As DropDownList = TryCast(GvPhong.Rows(GvPhong.EditIndex).FindControl("ddlCuaHang"), DropDownList)
    '        Dim dt As New DataTable()
    '        dt = objFCCuaHang.SelectAllTable
    '        ddl.DataSource = dt
    '        ddl.DataTextField = "nv_Tencuahang_vn"
    '        ddl.DataValueField = "uId_Cuahang"
    '        ddl.DataBind()
    '    End If
    'End Sub

    Protected Sub GvPhong_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvPhong.PageIndexChanging
        GvPhong.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

End Class