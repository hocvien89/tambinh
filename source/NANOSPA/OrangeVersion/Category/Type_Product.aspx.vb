Public Class Type_Product
    Inherits System.Web.UI.Page
    Dim objEnLoaimathang As CM.QLMH_DM_LOAIMATHANGEntity
    Dim objFcLoaimathang As BO.QLMH_DM_LOAIMATHANGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFcLoaimathang = New BO.QLMH_DM_LOAIMATHANGFacade
        Dim dt As DataTable
        Try
            dt = objFcLoaimathang.SelectAllTable()
            Grid_TypeProduct.DataSource = dt
            Grid_TypeProduct.DataBind()
        Catch ex As Exception

        End Try
        dt = Nothing
    End Sub

    Protected Sub Grid_TypeProduct_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_TypeProduct.RowDeleting
        objFcLoaimathang = New BO.QLMH_DM_LOAIMATHANGFacade
        Dim uid_Loai As String
        Try
            uid_Loai = e.Keys(0).ToString
            objFcLoaimathang.DeleteByID(uid_Loai)
            Grid_TypeProduct.CancelEdit()
            e.Cancel = True
        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_TypeProduct_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_TypeProduct.RowInserting
        objEnLoaimathang = New CM.QLMH_DM_LOAIMATHANGEntity
        objFcLoaimathang = New BO.QLMH_DM_LOAIMATHANGFacade
        Dim Maloai As String
        Maloai = e.NewValues("nv_Tenloaimathang_en").ToString
        Try
            If e.NewValues("nv_Tenloaimathang_vn").ToString <> "" And e.NewValues("nv_Tenloaimathang_en").ToString <> "" Then
                If objFcLoaimathang.SellectcheckMa(Maloai) = "" Then
                    With objEnLoaimathang
                        .nv_Tenloaimathang_vn = e.NewValues("nv_Tenloaimathang_vn").ToString
                        .nv_Tenloaimathang_en = e.NewValues("nv_Tenloaimathang_en").ToString
                    End With
                    objFcLoaimathang.Insert(objEnLoaimathang)
                    Grid_TypeProduct.CancelEdit()
                    e.Cancel = True
                End If
            End If        
        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_TypeProduct_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_TypeProduct.RowUpdating
        Dim uid_Loaimathang As String
        uid_Loaimathang = e.Keys(0).ToString
        objEnLoaimathang = New CM.QLMH_DM_LOAIMATHANGEntity
        objFcLoaimathang = New BO.QLMH_DM_LOAIMATHANGFacade
        Dim uidcheck As String
        uidcheck = objFcLoaimathang.SellectcheckMa(e.NewValues("nv_Tenloaimathang_en").ToString)
        Try
            If e.NewValues("nv_Tenloaimathang_vn").ToString <> "" And e.NewValues("nv_Tenloaimathang_en").ToString <> "" Then
                If uid_Loaimathang = uidcheck Or uidcheck = "" Then
                    With objEnLoaimathang
                        .nv_Tenloaimathang_en = e.NewValues("nv_Tenloaimathang_en").ToString
                        .nv_Tenloaimathang_vn = e.NewValues("nv_Tenloaimathang_vn").ToString
                        .uId_Loaimathang = uid_Loaimathang
                    End With
                    objFcLoaimathang.Update(objEnLoaimathang)
                    Grid_TypeProduct.CancelEdit()
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
        loaddata()
    End Sub
End Class