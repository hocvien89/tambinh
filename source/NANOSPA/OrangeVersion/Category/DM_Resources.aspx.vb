Public Class DM_Resources
    Inherits System.Web.UI.Page

    Private objFcResource As BO.ResourcesFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFcResource = New BO.ResourcesFacade
        Dim dt As DataTable
        dt = objFcResource.SelectAllTable()
        Grid_DMThuchi.DataSource = dt
        Grid_DMThuchi.DataBind()
    End Sub

    Protected Sub Grid_DMThuchi_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objFcResource = New BO.ResourcesFacade
        Dim objEnResource = New CM.ResourcesEntity
        Try
            With objEnResource
                .ResourceName = e.NewValues("ResourceName")
            End With
            objFcResource.Insert_Resource_Up(objEnResource)
            loaddata()
            Grid_DMThuchi.CancelEdit()
            e.Cancel = True
        Catch ex As Exception
            ShowMessage(Me, "Lỗi khi thêm mới!")
        End Try
    End Sub

    Protected Sub Grid_DMThuchi_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcResource = New BO.ResourcesFacade
        Try
            objFcResource.DeleteByID(e.Keys(0).ToString)
            Grid_DMThuchi.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_DMThuchi_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objFcResource = New BO.ResourcesFacade
        Dim objEnResource = New CM.ResourcesEntity
        Try
            With objEnResource
                .ResourceID = e.Keys(0).ToString
                .ResourceName = e.NewValues("ResourceName")
            End With
            objFcResource.Update(objEnResource)
            loaddata()
            Grid_DMThuchi.CancelEdit()
            e.Cancel = True
        Catch ex As Exception
            ShowMessage(Me, "Lỗi khi Update!")
        End Try

    End Sub
End Class