Public Class Source
    Inherits System.Web.UI.Page
    Private objFcNguon As BO.CRM_DM_NGUONFacade
    Private objEnNguon As CM.CRM_DM_NGUONEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub

    Private Sub loaddata()
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim dt As DataTable
        dt = objFcNguon.SelectByIDNguon()
        Grid_Other.DataSource = dt
        Grid_Other.DataBind()
    End Sub

    Protected Sub Grid_Other_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnNguon = New CM.CRM_DM_NGUONEntity
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim type As String
        type = e.NewValues("vType").ToString
        Try
            With objEnNguon
                .nv_Nguon_vn = e.NewValues("nv_Nguon_vn")
                .vType = type

            End With
            objFcNguon.Insert(objEnNguon)
            Grid_Other.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Other_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnNguon = New CM.CRM_DM_NGUONEntity
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim type As String = e.Keys(0).ToString
        Try
            With objEnNguon
                .uId_Nguon = type
                .nv_Nguon_vn = e.NewValues("nv_Nguon_vn")
                .vType = "NGUON"

            End With
            objFcNguon.Update(objEnNguon)
            Grid_Other.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Other_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim uId_Nguon As String
        uId_Nguon = e.Keys(0).ToString
        Try
            objFcNguon.DeleteByID(uId_Nguon)
            Grid_Other.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub
End Class