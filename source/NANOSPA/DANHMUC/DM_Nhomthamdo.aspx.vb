Public Partial Class DM_Nhomthamdo
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_NHOMTHAMDOFacade
    Private objEn As New CM.TNTP_DM_NHOMTHAMDOEntity
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
        dt = objFC.SelectAllTable()
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvNhomthamdo.DataSource = dt
        GvNhomthamdo.DataBind()
    End Sub

    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvNhomthamdo.PreRender

    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvNhomthamdo.RowDeleting
        Dim id As String
        If GvNhomthamdo.DataKeys.Count <> 0 Then
            id = GvNhomthamdo.DataKeys(e.RowIndex).Values("uId_NhomThamdo").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvNhomthamdo.RowUpdating
        Dim grv As GridViewRow = GvNhomthamdo.Rows(e.RowIndex)
        Dim uId_NhomThamdo As String = Convert.ToString(GvNhomthamdo.DataKeys(e.RowIndex)("uId_NhomThamdo"))
        With objEn
            .uId_NhomThamdo = uId_NhomThamdo
            .nv_TennhomThamdo_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvNhomthamdo.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvNhomthamdo.PageIndexChanging
        GvNhomthamdo.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvNhomthamdo.RowEditing
        GvNhomthamdo.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvNhomthamdo.RowCancelingEdit
        GvNhomthamdo.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Response.Redirect("~/DANHMUC/Add_DM_Nhomthamdo.aspx")
    End Sub
End Class