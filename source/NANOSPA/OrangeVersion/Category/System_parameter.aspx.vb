Public Class System_parameter
    Inherits System.Web.UI.Page
    Private objEnThamsohethong As CM.cls_QT_THAMSOHETHONG
    Private objFcThamsohethong As BO.clsB_QT_THAMSOHETHONG
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadGenererTab()
        End If
        Grid_loaddata()
    End Sub

#Region "load du lieu"
    Private Sub LoadGenererTab()
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Dim src As String
        src = objFcThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
        img_Logo.ImageUrl = src
    End Sub
    Private Sub Grid_loaddata()
        Dim dt As DataTable
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        dt = objFcThamsohethong.SelectAllTable()
        Try
            If dt.Rows.Count > 0 Then
                Grid_ThamsoHethong.DataSource = dt
                Grid_ThamsoHethong.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Grid event"
    Protected Sub Grid_ThamsoHethong_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uid As String
        uid = e.Keys(0).ToString
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Try
            objFcThamsohethong.Delete(uid)
            Grid_ThamsoHethong.CancelEdit()
            e.Cancel = True
            Grid_loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_ThamsoHethong_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnThamsohethong = New CM.cls_QT_THAMSOHETHONG
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Try
            With objEnThamsohethong
                .b_Hoatdong = e.NewValues("b_Hoatdong")
                .f_Giatri = Nothing
                .i_STT = e.NewValues("i_STT")
                .nv_Mota_vn = e.NewValues("nv_Mota_vn")
                .v_Tenbien = e.NewValues("v_Tenbien")
                .v_Giatri = e.NewValues("v_Giatri").ToString
            End With
            objFcThamsohethong.Insert(objEnThamsohethong)
            Grid_ThamsoHethong.CancelEdit()
            e.Cancel = True
            Grid_loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_ThamsoHethong_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnThamsohethong = New CM.cls_QT_THAMSOHETHONG
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Dim uid As String = e.Keys(0).ToString
        Try
            With objEnThamsohethong
                .b_Hoatdong = e.NewValues("b_Hoatdong")
                .f_Giatri = Nothing
                .i_STT = e.NewValues("i_STT")
                .nv_Mota_vn = e.NewValues("nv_Mota_vn")
                .v_Tenbien = e.NewValues("v_Tenbien")
                .uId_Thamsohethong = uid
                .v_Giatri = e.NewValues("v_Giatri").ToString
            End With
            objFcThamsohethong.Update(objEnThamsohethong)
            Grid_ThamsoHethong.CancelEdit()
            e.Cancel = True
            Grid_loaddata()
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Button"
    Protected Sub bnLuuLogo_Click(sender As Object, e As EventArgs)
        objEnThamsohethong = New CM.cls_QT_THAMSOHETHONG
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        With objEnThamsohethong
            .b_Hoatdong = True
            .f_Giatri = Nothing
            .i_STT = 4
            .nv_Mota_vn = "Logo cơ sở"
            .v_Tenbien = "vLogo"
            .uId_Thamsohethong = "0e483293-eede-4d91-a4fa-e24d47cc713b"
            .v_Giatri = hdfLogo.Value
        End With
        objFcThamsohethong.Update(objEnThamsohethong)
        img_Logo.ImageUrl = hdfLogo.Value
    End Sub
#End Region
End Class