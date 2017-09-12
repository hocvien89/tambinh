

Public Class Group_Product
    Inherits System.Web.UI.Page
    Dim objEnNhommathang As CM.QLMH_DM_NHOMMATHANGEntity
    Dim objFcNhommathang As BO.QLMH_DM_NHOMMATHANGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objEnNhommathang = New CM.QLMH_DM_NHOMMATHANGEntity
        objFcNhommathang = New BO.QLMH_DM_NHOMMATHANGFacade
        Dim dt As DataTable
        Try
            dt = objFcNhommathang.SelectAllTable()
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
            End If
            If dt.Rows.Count > 0 Then
                Grid_GroupProduct.DataSource = dt
                Grid_GroupProduct.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_GroupProduct_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_GroupProduct.RowDeleting
        objFcNhommathang = New BO.QLMH_DM_NHOMMATHANGFacade
        Dim uId_Nhommathang As String
        Try
            uId_Nhommathang = e.Keys(0).ToString
            'kiem tra nhom mat hang nay da duoc su dung trong bang mat hang chua
            objFcNhommathang.DeleteByID(uId_Nhommathang)
            Grid_GroupProduct.CancelEdit()
            e.Cancel = True
        Catch ex As Exception
        End Try
        loaddata()
    End Sub

    Protected Sub Grid_GroupProduct_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_GroupProduct.RowInserting
        objEnNhommathang = New CM.QLMH_DM_NHOMMATHANGEntity
        objFcNhommathang = New BO.QLMH_DM_NHOMMATHANGFacade
        Try
                If objFcNhommathang.SelectcheckMa(e.NewValues("nv_Tennhommathang_en").ToString) = "" Then
                    With objEnNhommathang
                        .nv_Tennhommathang_vn = e.NewValues("nv_Tennhommathang_vn").ToString
                        .nv_Tennhommathang_en = e.NewValues("nv_Tennhommathang_en").ToString
                    End With
                    objFcNhommathang.Insert(objEnNhommathang)
                    Grid_GroupProduct.CancelEdit()
                    e.Cancel = True
                End If
        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_GroupProduct_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_GroupProduct.RowUpdating
        Dim uid_Nhom As String
        uid_Nhom = e.Keys(0).ToString
        objEnNhommathang = New CM.QLMH_DM_NHOMMATHANGEntity
        objFcNhommathang = New BO.QLMH_DM_NHOMMATHANGFacade
        Dim uidcheck As String
        uidcheck = objFcNhommathang.SelectcheckMa(e.NewValues("nv_Tennhommathang_en").ToString)
        Try
            If e.NewValues("nv_Tennhommathang_vn").ToString <> "" And e.NewValues("nv_Tennhommathang_en").ToString <> "" Then
                If uid_Nhom = uidcheck.ToString Or uidcheck = "" Then
                    With objEnNhommathang
                        .nv_Tennhommathang_en = e.NewValues("nv_Tennhommathang_en").ToString
                        .nv_Tennhommathang_vn = e.NewValues("nv_Tennhommathang_vn").ToString
                        .uId_Nhommathang = uid_Nhom
                    End With
                    objFcNhommathang.Update(objEnNhommathang)
                    Grid_GroupProduct.CancelEdit()
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try

        e.Cancel = True
        loaddata()
    End Sub
End Class