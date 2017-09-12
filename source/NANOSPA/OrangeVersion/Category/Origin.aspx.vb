Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Public Class Origin1
    Inherits System.Web.UI.Page
    Private objFcOrigin As BO.QLMH_DM_XUATXUFacade
    Private objEnOrigin As CM.QLMH_DM_XUATXUEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Loaddata()
        End If
    End Sub
    Protected Sub Loaddata()
        Dim objFcOrigin = New BO.QLMH_DM_XUATXUFacade
        Dim objEnOrigin = New CM.QLMH_DM_XUATXUEntity
        Dim dt As DataTable
        Try
            dt = objFcOrigin.SelectAllTable()
            Grid_Origin.DataSource = dt
            Grid_Origin.DataBind()
        Catch ex As Exception
           
        End Try
    End Sub

    Protected Sub Grid_Origin_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_Origin.RowDeleting
        Dim objFcOrigin = New BO.QLMH_DM_XUATXUFacade
        Dim uid_Xuatxu As String
        uid_Xuatxu = e.Keys(0).ToString
        Try
            objFcOrigin.DeleteByID(uid_Xuatxu)
            Grid_Origin.CancelEdit()
            e.Cancel = True
            Loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Origin_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_Origin.RowInserting
        objEnOrigin = New CM.QLMH_DM_XUATXUEntity
        objFcOrigin = New BO.QLMH_DM_XUATXUFacade

       
        Try
            With objEnOrigin
                .nv_Tenxuatxu_en = ""
                .nv_Tenxuatxu_vn = e.NewValues("nv_Tenxuatxu_vn").ToString              
                .v_Maxuatxu = e.NewValues("v_Maxuatxu").ToString
            End With
            objFcOrigin.Insert(objEnOrigin)
            Grid_Origin.CancelEdit()
            e.Cancel = True
            Loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Origin_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_Origin.RowUpdating
        objEnOrigin = New CM.QLMH_DM_XUATXUEntity
        objFcOrigin = New BO.QLMH_DM_XUATXUFacade

        Dim uId_Xuatxu As String
        uId_Xuatxu = e.Keys(0).ToString
        Try
            With objEnOrigin
                .nv_Tenxuatxu_en = ""
                .nv_Tenxuatxu_vn = e.NewValues("nv_Tenxuatxu_vn").ToString
                .uId_Xuatxu = uId_Xuatxu
                .v_Maxuatxu = e.NewValues("v_Maxuatxu").ToString
            End With
            objFcOrigin.Update(objEnOrigin)
            Grid_Origin.CancelEdit()
            e.Cancel = True
            Loaddata()
        Catch ex As Exception

        End Try
    End Sub
End Class