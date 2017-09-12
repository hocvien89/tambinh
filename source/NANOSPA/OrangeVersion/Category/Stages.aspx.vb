Public Class Stages
    Inherits System.Web.UI.Page
    Private objFCCongdoan As BO.TNTP_QT_DIEUTRI_CONGDOANFacade
    Private objEnCongdoan As CM.ITNTP_QT_DIEUTRI_CONGDOANEntity


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFCCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        objEnCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        Dim dt As DataTable
        dt = objFCCongdoan.SelectAllTable()
        Grid_DMCongdoan.DataSource = dt
        Grid_DMCongdoan.DataBind()
    End Sub

    Protected Sub Grid_DMCongdoan_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_DMCongdoan.RowInserting
        objEnCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        objFCCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        Try

            With objEnCongdoan
                .nv_Tencongdoan_vn = e.NewValues("nv_Tencongdoan_vn").ToString
                .v_Macongdoan = e.NewValues("v_Macongdoan").ToString
            End With
            objFCCongdoan.Insert(objEnCongdoan)
            Grid_DMCongdoan.CancelEdit()
            e.Cancel = True

        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_DMCongdoan_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_DMCongdoan.RowUpdating
        objEnCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        objFCCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        Dim uId_Congdoan As String
        uId_Congdoan = e.Keys(0).ToString
        Try

            With objEnCongdoan
                .uId_Congdoan = uId_Congdoan
                .v_Macongdoan = e.NewValues("v_Macongdoan").ToString
                .nv_Tencongdoan_vn = e.NewValues("nv_Tencongdoan_vn").ToString

            End With
            objFCCongdoan.Update(objEnCongdoan)
            Grid_DMCongdoan.CancelEdit()
            e.Cancel = True

        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_DMCongdoan_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_DMCongdoan.RowDeleting
        objEnCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        objFCCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        Dim uId_Congdoan As String
        uId_Congdoan = e.Keys(0).ToString
        Try

            With objEnCongdoan
                .uId_Congdoan = uId_Congdoan
                
            End With
            objFCCongdoan.DeleteByID(uId_Congdoan)
            Grid_DMCongdoan.CancelEdit()
            e.Cancel = True

        Catch ex As Exception

        End Try
        loaddata()
    End Sub
End Class