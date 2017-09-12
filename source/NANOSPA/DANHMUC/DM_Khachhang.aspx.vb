Public Partial Class DM_Khachhang
    Inherits System.Web.UI.Page
    Private objFC As New BO.CRM_DM_KhachhangFacade
    Private objEn As New CM.CRM_DM_KhachhangEntity

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
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "1a2a3c23-4c7c-48ca-a2f5-ce628192a06c")
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
        dt = objFC.SelectAllTable(Session("uId_Cuahang").ToString)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvKhachhang.DataSource = dt
        GvKhachhang.DataBind()
    End Sub
    Public Function DisplayByValue(ByVal gioitinh As Object)
        Dim str As String = Nothing
        Dim str1 As String = "Nam"
        Dim str2 As String = "Nữ"
        If gioitinh = False Then
            str = str2
        End If
        If gioitinh = True Then
            str = str1
        End If
        Return str
    End Function

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvKhachhang.PreRender
       
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvKhachhang.RowDeleting
        Dim id As String
        If GvKhachhang.DataKeys.Count <> 0 Then
            id = GvKhachhang.DataKeys(e.RowIndex).Values("uId_Khachhang").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvKhachhang.RowUpdating
        Dim grv As GridViewRow = GvKhachhang.Rows(e.RowIndex)
        Dim uId_Khachhang As String = Convert.ToString(GvKhachhang.DataKeys(e.RowIndex)("uId_Khachhang"))
        With objEn
            .uId_Khachhang = uId_Khachhang
            .b_Gioitinh = CByte(CType(grv.FindControl("ddlGioitinh"), DropDownList).SelectedValue)
            .d_Ngayden = CDate(CType(grv.FindControl("cldNgayden"), Calendar).SelectedDate)
            .v_Makhachang = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .nv_Hoten_vn = CStr(CType(grv.Cells(1).Controls(0), TextBox).Text.Trim)
            .d_Ngaysinh = CStr(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
            .nv_Diachi_vn = CStr(CType(grv.Cells(4).Controls(0), TextBox).Text.Trim)
            .nv_Nguyenquan_vn = CStr(CType(grv.Cells(5).Controls(0), TextBox).Text.Trim)
            .v_DienthoaiDD = CStr(CType(grv.Cells(6).Controls(0), TextBox).Text.Trim)
            .v_Dienthoaikhac = CStr(CType(grv.Cells(7).Controls(0), TextBox).Text.Trim)
            .v_Email = CStr(CType(grv.Cells(8).Controls(0), TextBox).Text.Trim)
            .i_SoCMT = CInt(CType(grv.Cells(9).Controls(0), TextBox).Text.Trim)
            .d_NgaycapCMT = CStr(CType(grv.Cells(10).Controls(0), TextBox).Text.Trim)
            .nv_Noicap_vn = CStr(CType(grv.Cells(11).Controls(0), TextBox).Text.Trim)

        End With
        objFC.Update(objEn)
        GvKhachhang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvKhachhang.PageIndexChanging
        GvKhachhang.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvKhachhang.RowEditing
        GvKhachhang.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvKhachhang.RowCancelingEdit
        GvKhachhang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Khachhang.aspx")
    End Sub
End Class