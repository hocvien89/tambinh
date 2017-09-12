Public Class Supplier
    Inherits System.Web.UI.Page
    Private objEnNhaCC As New CM.QLMH_DM_NHACUNGCAPEntity
    Private objFcNhaCC As New BO.QLMH_DM_NHACUNGCAPFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
#Region "load dữ liệu"
    Private Sub loaddata()
        Dim dt As DataTable
        dt = objFcNhaCC.SelectAllTable()
        Try
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
            End If
            If dt.Rows.Count <> 0 Then
                Grid_Supplier.DataSource = dt
                Grid_Supplier.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Protected Sub Grid_Supplier_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Nhacc As String = e.Keys(0).ToString
        Try
            objFcNhaCC.DeleteByID(uId_Nhacc)
            Grid_Supplier.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Supplier_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Try
            With objEnNhaCC
                .nv_Diachi_en = ""
                .nv_Diachi_vn = e.NewValues("nv_Diachi_vn")
                .nv_Tennhacungcap_en = ""
                .nv_Tennhacungcap_vn = e.NewValues("nv_Tennhacungcap_vn").ToString
                .v_Manhacungcap = e.NewValues("v_Manhacungcap").ToString
            End With
            objFcNhaCC.Insert(objEnNhaCC)
            Grid_Supplier.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Supplier_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim uId_Nhacc As String = e.Keys(0).ToString
        Try
            With objEnNhaCC
                .uId_Nhacungcap = uId_Nhacc
                .nv_Diachi_en = ""
                .nv_Diachi_vn = e.NewValues("nv_Diachi_vn")
                .nv_Tennhacungcap_en = ""
                .nv_Tennhacungcap_vn = e.NewValues("nv_Tennhacungcap_vn").ToString
                .v_Manhacungcap = e.NewValues("v_Manhacungcap").ToString
            End With
            objFcNhaCC.Update(objEnNhaCC)
            Grid_Supplier.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub
End Class