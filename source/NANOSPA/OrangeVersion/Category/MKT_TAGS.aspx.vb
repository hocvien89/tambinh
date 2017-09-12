Imports DevExpress.Web.ASPxEditors
Public Class MKT_TAGS
    Inherits System.Web.UI.Page
    Private objEnTag As CM.MKT_TAGS
    Private objFcTag As BO.MKT_Tags

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then

        End If
        Grid_Loaddata()
    End Sub
    Private Sub Grid_Loaddata()
        objFcTag = New BO.MKT_Tags
        Dim dt As DataTable
        Try
            dt = objFcTag.SelectAllTable_P()
            Grid_Marketingtag.DataSource = dt
            Grid_Marketingtag.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Grid_Other_CellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
        If e.Column.FieldName = "MaLoai" Then
            objFcTag = New BO.MKT_Tags
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            cmb.ValueType = GetType(String)
            Dim item1 As New ListEditItem
            Dim item2 As New ListEditItem
            item1.Value = "1"
            item1.Text = "Dịch vụ"
            item2.Value = "2"
            item2.Text = "Khác"
            cmb.Items.Add(item1)
            cmb.Items.Add(item2)
        End If
    End Sub
    Protected Sub Grid_Marketingtag_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_Marketingtag.RowInserting
        objFcTag = New BO.MKT_Tags
        objEnTag = New CM.MKT_TAGS
        Dim type As Integer
        type = e.NewValues("MaLoai").ToString
       
        Try
            With objEnTag
                .MaLoai = type
                .nv_TagName_vn = e.NewValues("nv_TagName_vn").ToString
            End With
            objFcTag.Insert(objEnTag)
            Grid_Marketingtag.CancelEdit()
            e.Cancel = True
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Marketingtag_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_Marketingtag.RowUpdating
        objFcTag = New BO.MKT_Tags
        objEnTag = New CM.MKT_TAGS
        Dim type As Integer
        type = e.NewValues("MaLoai").ToString
        Dim matag As String
        matag = e.Keys(0).ToString
        Try
            With objEnTag

                .MaLoai = type

                .uId_Tags = matag

                .nv_TagName_vn = e.NewValues("nv_TagName_vn").ToString
            End With
            objFcTag.Update(objEnTag)
            Grid_Marketingtag.CancelEdit()
            e.Cancel = True
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Marketingtag_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_Marketingtag.RowDeleting
        objFcTag = New BO.MKT_Tags
        Dim uId_Tags As String
        uId_Tags = e.Keys(0).ToString
        Try
            objFcTag.DeleteByID(uId_Tags)
            Grid_Marketingtag.CancelEdit()
            e.Cancel = True
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub
End Class