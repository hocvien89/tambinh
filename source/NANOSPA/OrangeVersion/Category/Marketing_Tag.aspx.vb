
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Drawing
Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.XtraPrinting
Public Class Marketing_Tag
    Inherits System.Web.UI.Page
    Private objFCTags As New BO.MKT_Tags
    Private objEnTags As New CM.MKT_TAGS
    Private objFcLoaiTag As New BO.MKT_LOAITAGFacade
    Private objEnLoaiTag As New CM.MKT_LOAITAGSEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadCombo()
        End If
        loaddataLoaiTag()
        LoaddataTag()
    End Sub
    Private Sub loaddataLoaiTag()
        Dim objFCTags = New BO.MKT_Tags
        Dim dt As DataTable
        dt = objFCTags.SelectAllTable_LoaiTag()
        Grid_DMLoaiTag.DataSource = dt
        Grid_DMLoaiTag.DataBind()
    End Sub
    Private Sub LoaddataTag()
        Dim objFCTags = New BO.MKT_Tags
        Dim dt As DataTable
        dt = objFCTags.SelectAlltable_Nokey()
        Grid_DMTag.DataSource = dt
        Grid_DMTag.DataBind()
    End Sub
    Private Sub LoadCombo()
        Dim objFcLoaiTag = New BO.MKT_LOAITAGFacade
        Dim item As New ListEditItem
        item.Text = "Không xác định"
        item.Value = "Khong xac dinh"
        cbo_LoaiTag.Items.Add(item)
        Dim dt As DataTable
        dt = objFcLoaiTag.SelectAllTable()
        For Each row As DataRow In dt.Rows
            Dim item2 As New ListEditItem
            item2.Value = row("i_Thutu")
            item2.Text = row("nv_TenLoaiTag_vn")
            cbo_LoaiTag.Items.Add(item2)
        Next
        cbo_LoaiTag.SelectedIndex = 0

    End Sub
    Protected Sub Grid_DMLoaiTag_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles Grid_DMLoaiTag.RowInserting
        objFcLoaiTag = New BO.MKT_LOAITAGFacade
        objEnLoaiTag = New CM.MKT_LOAITAGSEntity
        Try
            With objEnLoaiTag

                .nv_TenLoaiTag_vn = (e.NewValues("nv_TenLoaiTag_vn").ToString)
                .i_Thutu = e.NewValues("i_Thutu").ToString
               
            End With
            objFcLoaiTag.Insert(objEnLoaiTag)
            Grid_DMLoaiTag.CancelEdit()
            e.Cancel = True
            loaddataLoaiTag()
            LoadCombo()
            LoaddataTag()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_DMLoaiTag_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_DMLoaiTag.RowUpdating
        objFcLoaiTag = New BO.MKT_LOAITAGFacade
        objEnLoaiTag = New CM.MKT_LOAITAGSEntity
        Dim uId_Tag As String
        uId_Tag = e.Keys(0).ToString
        Try
            With objEnLoaiTag
                .Id_LoaiTag = uId_Tag
                .nv_TenLoaiTag_vn = (e.NewValues("nv_TenLoaiTag_vn").ToString)
                .i_Thutu = e.NewValues("i_Thutu").ToString
            End With
            objFcLoaiTag.Update(objEnLoaiTag)
            Grid_DMLoaiTag.CancelEdit()
            e.Cancel = True
            loaddataLoaiTag()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_DMLoaiTag_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_DMLoaiTag.RowDeleting
        objFcLoaiTag = New BO.MKT_LOAITAGFacade

        Dim Id_Tag As Integer
        Id_Tag = e.Keys(0).ToString
        Try
            objFcLoaiTag.DeleteByID(Id_Tag)
            Grid_DMLoaiTag.CancelEdit()
            e.Cancel = True
            loaddataLoaiTag()
            LoaddataTag()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btOK_Click(sender As Object, e As EventArgs)
        Dim objFCTags = New BO.MKT_Tags
        Dim objEnTags = New CM.MKT_TAGS
        Try
            With objEnTags
                .MaLoai = cbo_LoaiTag.Value.ToString
                .nv_TagName_vn = txtTentag.Text
            End With
            objFCTags.Insert(objEnTags)
            Grid_DMTag.CancelEdit()
            LoaddataTag()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Grid_DMTag_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_DMTag.RowDeleting
        objFCTags = New BO.MKT_Tags

        Dim Id_Tag As String
        Id_Tag = e.Keys(0).ToString
        Try
            objFCTags.DeleteByID(Id_Tag)
            Grid_DMTag.CancelEdit()
            e.Cancel = True

            LoaddataTag()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_DMTag_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_DMTag.RowUpdating
        objFCTags = New BO.MKT_Tags
        objEnTags = New CM.MKT_TAGS
        Dim uId_Tag As String
        uId_Tag = e.Keys(0).ToString
        Try
            With objEnTags
                .uId_Tags = uId_Tag
                .MaLoai = (e.NewValues("MaLoai").ToString)
                .nv_TagName_vn = e.NewValues("nv_TagName_vn").ToString
            End With
            objFCTags.Update(objEnTags)
            Grid_DMTag.CancelEdit()
            e.Cancel = True
            LoaddataTag()
        Catch ex As Exception

        End Try
    End Sub
End Class