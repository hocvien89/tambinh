Imports System.IO

Partial Public Class DM_Dichvu
    Inherits System.Web.UI.Page
    Private objFCNhomdichvu As New BO.TNTP_DM_NHOMDICHVUFacade
    Private objEnNhomdichvu As New CM.TNTP_DM_NHOMDICHVUEntity
    Private objFCNgoaite As New BO.TNTP_DM_NGOAITEFacade
    Private objEnNgoaite As New CM.TNTP_DM_NGOAITEEntity
    Private objFC As New BO.TNTP_DM_DICHVUFacade
    Private objEn As New CM.TNTP_DM_DICHVUEntity

    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CheckUser()
            Me.LoadDDLNhomDV()
            If ddlNhomdichvu.Items.Count > 1 Then
                Me.LoadData()
            Else : ShowMessage(Me, "Xin nhập nhóm dịch vụ trước!")
                btn_Them.Enabled = False
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_XuatExcel.Click


        Me.GvDichvu.AllowPaging = False
        GvDichvu.Columns(14).Visible = False
        GvDichvu.Columns(15).Visible = False
        'If you are binding GridView under Code Behind
        'Me.gdvCustomer.DataSource = GetCustomer
        LoadData()
        Dim tw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Page.Response.ContentType = "application/vnd.xls"
        Page.Response.AddHeader("content-disposition", "attachment; filename=DMDichVu_" + Strings.Format(DateAndTime.Now, "dd/MM/yyyy").Trim + ".xls")
        Page.Response.Charset = ""
        Page.EnableViewState = False
        Page.Response.ContentEncoding = System.Text.Encoding.UTF8
        hw.WriteLine("<meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8""/>")
        frm.Attributes("runat") = "server"
        Controls.Add(frm)

        frm.Controls.Add(GvDichvu)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        Me.GvDichvu.AllowPaging = True
    End Sub

    Public Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "33bbbca7-e458-4d40-ad6d-54bbb339cab8")
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles GvDichvu.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GvDichvu.PageIndex
        GvDichvu.DataSource = SortDataTable(GetData(), False)
        GvDichvu.DataBind()
        GvDichvu.PageIndex = pageIndex
    End Sub

    Private Function GetData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable(ddlNhomdichvu.SelectedValue, Session("uId_Cuahang"))
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        Return dt
    End Function

    Private Sub LoadDDLNhomDV()
        Dim dt As New DataTable
        dt = objFCNhomdichvu.SelectAllTable(Session("uId_Cuahang"))
        If dt.Rows.Count > 0 Then
            ddlNhomdichvu.DataSource = dt
            ddlNhomdichvu.DataTextField = "nv_TennhomDichvu_vn"
            ddlNhomdichvu.DataValueField = "uId_Nhomdichvu"
            ddlNhomdichvu.DataBind()
        End If
    End Sub

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable(ddlNhomdichvu.SelectedValue, Session("uId_Cuahang"))
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvDichvu.DataSource = dt
        GvDichvu.DataBind()
    End Sub

    Protected Sub ddlNhomdichvu_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlNhomdichvu.SelectedIndexChanged
        LoadData()
    End Sub

    Protected Sub Gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvDichvu.PageIndexChanging
        GvDichvu.DataSource = SortDataTable(GetData(), True)
        GvDichvu.PageIndex = e.NewPageIndex
        GvDichvu.DataBind()
    End Sub


    Protected Sub Gv_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles GvDichvu.PreRender
        If Me.GvDichvu.EditIndex <> -1 Then
            Dim ddlNhomdichvu As DropDownList = TryCast(GvDichvu.Rows(GvDichvu.EditIndex).FindControl("ddlNhomdichvu"), DropDownList)
            Dim ddlNgoaite As DropDownList = TryCast(GvDichvu.Rows(GvDichvu.EditIndex).FindControl("ddlNgoaite"), DropDownList)
            ddlNhomdichvu.DataSource = objFCNhomdichvu.SelectAllTable("")
            ddlNhomdichvu.DataTextField = "nv_TennhomDichvu_vn"
            ddlNhomdichvu.DataValueField = "uId_Nhomdichvu"
            ddlNhomdichvu.DataBind()
            ddlNgoaite.DataSource = objFCNgoaite.SelectAllTable()
            ddlNgoaite.DataTextField = "v_Ma"
            ddlNgoaite.DataValueField = "uId_Ngoaite"
            ddlNgoaite.DataBind()
        End If
    End Sub

    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvDichvu.RowDeleting
        Dim id As String
        If GvDichvu.DataKeys.Count <> 0 Then
            id = GvDichvu.DataKeys(e.RowIndex).Values("uId_Dichvu").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub Gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvDichvu.RowUpdating
        Dim grv As GridViewRow = GvDichvu.Rows(e.RowIndex)
        Dim uId_Dichvu As String = Convert.ToString(GvDichvu.DataKeys(e.RowIndex)("uId_Dichvu"))
        With objEn
            .uId_Dichvu = uId_Dichvu
            .uId_Nhomdichvu = CStr(CType(grv.FindControl("ddlNhomdichvu"), DropDownList).SelectedValue)
            .uId_Ngoaite = CStr(CType(grv.FindControl("ddlNgoaite"), DropDownList).SelectedValue)
            .nv_Tendichvu_vn = CStr(CType(grv.Cells(0).Controls(0), TextBox).Text.Trim)
            .f_Gia = CInt(CType(grv.Cells(3).Controls(0), TextBox).Text.Trim)
            .f_Phidichvu = CInt(CType(grv.Cells(4).Controls(0), TextBox).Text.Trim)
            .i_Solan_Dieutri = CInt(CType(grv.Cells(5).Controls(0), TextBox).Text.Trim)
            .f_Sophutchuanbi = CStr(CType(grv.Cells(6).Controls(0), TextBox).Text.Trim)
            .f_Sophutthuchien = CStr(CType(grv.Cells(7).Controls(0), TextBox).Text.Trim)
            .f_PhantramHH_KTV = CStr(CType(grv.Cells(10).Controls(0), TextBox).Text.Trim)
            .f_PhantramHH_CTV = CStr(CType(grv.Cells(12).Controls(0), TextBox).Text.Trim)
            .f_PhantramHH_TVV = CStr(CType(grv.Cells(11).Controls(0), TextBox).Text.Trim)
            .f_PhantramHH_NV = CStr(CType(grv.Cells(13).Controls(0), TextBox).Text.Trim)
            .b_Tinhthue = CByte(CType(grv.Cells(8).Controls(0), CheckBox).Checked)
            .b_TinhHoahong = CByte(CType(grv.Cells(9).Controls(0), CheckBox).Checked)
            .b_Goidichvu = CBool(CType(grv.Cells(14).Controls(0), CheckBox).Checked)
        End With
        objFC.Update(objEn)
        GvDichvu.EditIndex = -1
        LoadData()
    End Sub
    Protected Sub GvDichvu_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvDichvu.SelectedIndexChanged
        Dim grv As GridViewRow = GvDichvu.Rows(GvDichvu.SelectedIndex)
        Dim uId_Mathang As String = Convert.ToString(GvDichvu.DataKeys(GvDichvu.SelectedIndex)("uId_Dichvu"))
        Session("uId_Dichvu") = uId_Mathang
        Response.Redirect("~/DANHMUC/Add_DM_Dichvu.aspx")
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, _
ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If (e.CommandName = "Congdoan") Then
            Dim uId_Dichvu As String = e.CommandArgument.ToString
            Session("uId_Dichvu") = uId_Dichvu
            Response.Write("<script language=javascript> window.open('Add_DM_Dichvu_Congdoan.aspx','Window1','menubar=no,width=500,height=500,toolbar=no,scrollbars=yes')</script>")
        End If
    End Sub

    Protected Sub Gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvDichvu.RowEditing
        Session("uId_Dichvu") = Convert.ToString(GvDichvu.DataKeys(GvDichvu.SelectedIndex)("uId_Dichvu"))
        Response.Redirect("~/DANHMUC/Add_DM_Dichvu.aspx")
    End Sub

    Protected Sub Gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvDichvu.RowCancelingEdit
        GvDichvu.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Session("uId_Dichvu") = Nothing
        Response.Redirect("~/DANHMUC/Add_DM_Dichvu.aspx")
    End Sub

End Class