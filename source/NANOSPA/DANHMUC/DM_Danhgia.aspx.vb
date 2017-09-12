Public Partial Class DM_Danhgia
    Inherits System.Web.UI.Page
    Dim objFCDanhgia As New BO.CRM_DM_DANHGIAFacade
    Dim objEnDanhgia As New CM.CRM_DM_DANHGIAEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Session("DSDanhgia") = ""
            LoadGrid()
        End If
    End Sub
    Private Sub LoadGrid()
        Dim dt As New DataTable
        dt = objFCDanhgia.SelectAllTable()
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
        End If
        GvDanhgia.DataSource = dt
        GvDanhgia.DataBind()
        Dim chk As CheckBox
        Dim checkboxIdsList As New List(Of String)
        For Each rowItem As GridViewRow In GvDanhgia.Rows
            chk = CType(rowItem.Cells(0).FindControl("ChkChon"), CheckBox)
            checkboxIdsList.Add(chk.ClientID)
        Next

        Dim checkboxIds As String = String.Join("|", checkboxIdsList.ToArray())
        CType(GvDanhgia.HeaderRow.Cells(0).FindControl("chkSelectAll"), CheckBox).Attributes.Add("onclick", "selectAll('" & checkboxIds & "',this)")
        If Session("DSDanhgia").ToString <> "" Then
            Dim strDS_SP As String = Session("DSDanhgia").ToString
            For i As Integer = 0 To GvDanhgia.Rows.Count - 1
                If (InStr(strDS_SP, GvDanhgia.DataKeys(i).Values("uId_Danhgia").ToString()) > 0) Then
                    CType(GvDanhgia.Rows(i).Cells(0).FindControl("ChkChon"), CheckBox).Checked = True
                End If
            Next
        End If
    End Sub
    Private Sub SaveDS_Danhgia()
        Dim strDS_Sp As String = Session("DSDanhgia").ToString
        For i As Integer = 0 To GvDanhgia.Rows.Count - 1
            If (CType(GvDanhgia.Rows(i).Cells(0).FindControl("ChkChon"), CheckBox).Checked) Then
                If (InStr(strDS_Sp, GvDanhgia.DataKeys(i).Values("uId_Danhgia").ToString()) = 0) And (GvDanhgia.DataKeys(i).Values("uId_Danhgia").ToString() > 10) Then
                    strDS_Sp = strDS_Sp + GvDanhgia.DataKeys(i).Values("uId_Danhgia").ToString() + ";"
                End If
            Else : strDS_Sp = strDS_Sp.Replace(GvDanhgia.DataKeys(i).Values("uId_Danhgia").ToString() + ";", "")
            End If
        Next
        Session("DSDanhgia") = strDS_Sp
    End Sub
    Private Sub Lammoi()
        txtCauhoi.Text = ""
        Session("uId_Danhgia") = Nothing
        Session("DSDanhgia") = ""
        GvDanhgia.DataBind()
    End Sub
    Protected Sub btnXoa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnXoa.Click
        SaveDS_Danhgia()
        Dim strNumber As String() = Split(Session("DSDanhgia"), ";")
        For Each stri As String In strNumber
            objFCDanhgia.DeleteByID(stri)
        Next
        LoadGrid()
    End Sub
    Protected Sub btnLammoi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLammoi.Click
        Lammoi()
    End Sub
    Protected Sub btn_Luu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
        With objEnDanhgia
            .nv_Cauhoi_vn = txtCauhoi.Text
        End With
        If Session("uId_Danhgia") <> Nothing Then
            objEnDanhgia.uId_Danhgia = Session("uId_Danhgia")
            If objFCDanhgia.Update(objEnDanhgia) Then
                ShowMessage(Me, "Cập nhật thành công!")
            End If
        Else
            If objFCDanhgia.Insert(objEnDanhgia) Then
                ShowMessage(Me, "Thêm thành công!")
            End If
        End If
        LoadGrid()
    End Sub
    Protected Sub Gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvDanhgia.RowDeleting
        Dim id As String
        If GvDanhgia.DataKeys.Count <> 0 Then
            id = GvDanhgia.DataKeys(e.RowIndex).Values("uId_Danhgia").ToString()
            objFCDanhgia.DeleteByID(id)
        End If
        LoadGrid()
    End Sub
    Protected Sub GvDanhgia_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GvDanhgia.SelectedIndexChanged
        Dim uId_Danhgia As String = Convert.ToString(GvDanhgia.DataKeys(GvDanhgia.SelectedIndex)("uId_Danhgia"))
        Session("uId_Danhgia") = uId_Danhgia
        objEnDanhgia = objFCDanhgia.SelectByID(uId_Danhgia)
        txtCauhoi.Text = objEnDanhgia.nv_Cauhoi_vn
    End Sub
    Protected Sub GvDanhgia_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvDanhgia.PageIndexChanging
        SaveDS_Danhgia()
        GvDanhgia.PageIndex = e.NewPageIndex
        LoadGrid()
    End Sub
End Class