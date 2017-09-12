Imports DevExpress.Web.ASPxEditors

Public Class DMThuchi
    Inherits System.Web.UI.Page
    Private objEnThuchi As CM.QLTC_DM_THUCHIEntity
    Private objFcThuchi As BO.QLTC_DM_THUCHIFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
#Region "Load dữ liệu"
    Private Sub loaddata()
        objEnThuchi = New CM.QLTC_DM_THUCHIEntity
        objFcThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim dt As DataTable
        dt = objFcThuchi.SelectAllTable()
        Try
            If dt.Rows.Count > 0 Then
                Grid_DMThuchi.DataSource = dt
                Grid_DMThuchi.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Protected Sub Grid_DMThuchi_CellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
        If e.Column.FieldName = "b_Thuchi" Then
            Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
            Dim item1 As New ListEditItem
            item1.Text = "Thu"
            item1.Value = True
            Dim item2 As New ListEditItem
            item2.Text = "Chi"
            item2.Value = False
            cmb.Items.Add(item1)
            cmb.Items.Add(item2)
        End If
    End Sub

    Protected Sub Grid_DMThuchi_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim uId_Thuchi As String
        uId_Thuchi = e.Keys(0).ToString
        Try
            objFcThuchi.DeleteByID(uId_Thuchi)
            Grid_DMThuchi.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_DMThuchi_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objFcThuchi = New BO.QLTC_DM_THUCHIFacade
        objEnThuchi = New CM.QLTC_DM_THUCHIEntity
        Try
            With objEnThuchi
                .nv_Tenthuchi_en = ""
                .nv_Tenthuchi_vn = e.NewValues("nv_Tenthuchi_vn").ToString
                .v_Mathuchi = e.NewValues("v_Mathuchi").ToString
                If e.NewValues("b_Thuchi").ToString = "Thu" Then
                    .b_ThuChi = True
                Else
                    .b_ThuChi = False
                End If
            End With
            objFcThuchi.Insert(objEnThuchi)
            Grid_DMThuchi.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_DMThuchi_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnThuchi = New CM.QLTC_DM_THUCHIEntity
        objFcThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim uId_thuchi As String
        Dim thuchi As String = e.NewValues("b_Thuchi")
        Dim thuchiold As String = e.OldValues("b_Thuchi")
        If thuchi <> thuchiold Then
            objEnThuchi.b_ThuChi = e.NewValues("b_Thuchi")
        Else
            If thuchiold = "Thu" Then
                objEnThuchi.b_ThuChi = True
            Else
                objEnThuchi.b_ThuChi = False
            End If
        End If
        uId_thuchi = e.Keys(0).ToString
        Try
            With objEnThuchi

                .nv_Tenthuchi_en = ""
                .nv_Tenthuchi_vn = e.NewValues("nv_Tenthuchi_vn").ToString
                .v_Mathuchi = e.NewValues("v_Mathuchi").ToString
                .uId_Thuchi = uId_thuchi
            End With
            objFcThuchi.Update(objEnThuchi)
            Grid_DMThuchi.CancelEdit()
            e.Cancel = True
            loaddata()
        Catch ex As Exception

        End Try
    End Sub
End Class