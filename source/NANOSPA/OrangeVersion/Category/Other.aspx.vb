Imports DevExpress.Web.ASPxEditors

Public Class Other
    Inherits System.Web.UI.Page
    Private objEnNguon As CM.CRM_DM_NGUONEntity
    Private objFcNguon As BO.CRM_DM_NGUONFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        Grid_Loaddata()
    End Sub
#Region "load du lieu"
    Private Sub Grid_Loaddata()
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim dt As DataTable
        Try
            dt = objFcNguon.SelectAllTable()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                    If dt.Rows(i)("vType") = "NGUON" Then
                        dt.Rows(i)("vType") = "Nguồn"
                    ElseIf dt.Rows(i)("vType") = "NGHENGHIEP" Then
                        dt.Rows(i)("vType") = "Nghề nghiệp"
                    End If
                Next
                Grid_Other.DataSource = dt
                Grid_Other.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Gridview event"
    Protected Sub Grid_Other_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim uId_Nguon As String
        uId_Nguon = e.Keys(0).ToString
        Try
            objFcNguon.DeleteByID(uId_Nguon)
            Grid_Other.CancelEdit()
            e.Cancel = True
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Other_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnNguon = New CM.CRM_DM_NGUONEntity
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim type As String
        type = e.NewValues("vType").ToString
        Try
            With objEnNguon
                If CheckLoaiDm(e.NewValues("nv_Nguon_vn")) = 1 Then
                    .nv_Nguon_vn = e.NewValues("nv_Nguon_vn").ToString
                Else
                    Return
                End If
                .vType = type
                .nv_Nguon_en = e.NewValues("nv_Nguon_vn")
            End With
            objFcNguon.Insert(objEnNguon)
            Grid_Other.CancelEdit()
            e.Cancel = True
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Other_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnNguon = New CM.CRM_DM_NGUONEntity
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim type As String
        Dim uId_Nguon As String
        Type = e.NewValues("vType").ToString
        uId_Nguon = e.Keys(0).ToString
        Try
            With objEnNguon
                .uId_Nguon = uId_Nguon
                .nv_Nguon_vn = e.NewValues("nv_Nguon_vn").ToString
                .nv_Nguon_en = Nothing
                .vType = type
            End With
            objFcNguon.Update(objEnNguon)
            Grid_Other.CancelEdit()
            e.Cancel = True
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "support"
    Private Function CheckLoaiDm(ma As String) As Integer
        objFcNguon = New BO.CRM_DM_NGUONFacade
        Dim dt As DataTable
        Dim i As Integer = 0
        dt = objFcNguon.SelectAllTable_ByvType(ma)
        Try
            If dt.Rows.Count > 0 Then
                i = 0 ' da ton tai
            Else
                i = 1 'duoc them
            End If
        Catch ex As Exception

        End Try
        Return i
    End Function
#End Region

    Protected Sub Grid_Other_CellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
        If e.Column.FieldName = "vType" Then
            objFcNguon = New BO.CRM_DM_NGUONFacade
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            cmb.ValueType = GetType(String)
            Dim item1 As New ListEditItem
            Dim item2 As New ListEditItem
            Dim item3 As New ListEditItem
            item1.Value = "NGHENGHIEP"
            item1.Text = "Nghề nghiệp"
            item2.Value = "NGUON"
            item2.Text = "Nguồn"
            cmb.Items.Add(item1)
            cmb.Items.Add(item2)
        End If
    End Sub
End Class