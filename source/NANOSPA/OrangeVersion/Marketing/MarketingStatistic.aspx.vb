Public Class MarketingStatistic
    Inherits System.Web.UI.Page
    Dim objFCCongviec As BO.MKT_CongviecFacade
    Dim fc_Tags As BO.MKT_Tags
    Dim objEnTags As CM.MKT_TAGS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deTungay.Date = DateTime.Now
            deDenngay.Date = DateTime.Now
        End If
        LoadGridView()
        LocTheoTags(Session("tags_s"))
    End Sub
#Region "Load Thong tin"
    Private Sub LoadGridView()
        objFCCongviec = New BO.MKT_CongviecFacade
        Dim dt As DataTable
        dt = objFCCongviec.SelectTagByTime(BO.Util.ConvertDateTime(deTungay.Text), BO.Util.ConvertDateTime(deDenngay.Text))
        If dt.Rows.Count > 0 Then
            GVTukhoa.DataSource = dt
            GVTukhoa.DataBind()
        End If
    End Sub
    Private Sub LocTheoTags(ByVal tags As String)
        objFCCongviec = New BO.MKT_CongviecFacade
        fc_Tags = New BO.MKT_Tags
        Dim dt As DataTable
        Dim tempName As String = ""
        Dim tempId As String = ""
        If tags <> "" Then
            Dim arr As Array = tags.Split(";").ToArray()
            For index As Integer = 0 To arr.Length - 1
                If (arr(index) <> "null") Then
                    tempId += arr(index) & ";"
                    objEnTags = New CM.MKT_TAGS
                    objEnTags = fc_Tags.SelectByID(arr(index))
                    If objEnTags.nv_TagName_vn <> "" Then
                        tempName += "- " & objEnTags.nv_TagName_vn + "</br>"
                    End If
                End If
            Next
            dt = objFCCongviec.SelectByTagsChinhxac(tempId, BO.Util.ConvertDateTime(deTungay.Text), BO.Util.ConvertDateTime(deDenngay.Text), "0", "0", "0")
            If dt.Rows.Count > 0 Then
                GVLocTheoTags.DataSource = dt
                GVLocTheoTags.DataBind()
            Else
                GVLocTheoTags.DataSource = Nothing
                GVLocTheoTags.DataBind()
            End If
            GVLocTheoTags.JSProperties("cpIsSoLuong") = dt.Rows.Count.ToString
            GVLocTheoTags.JSProperties("cpIsTuKhoa") = tempName
            dt = Nothing
            objFCCongviec = Nothing
        End If
    End Sub
    Public Function SplitTags(ByVal tags As String) As String
        Dim rs As String = ""
        fc_Tags = New BO.MKT_Tags
        If tags <> Nothing Then
            Dim arr As Array = tags.Split(";").ToArray()
            For index As Integer = 0 To arr.Length - 1
                Dim tagsItem As New CM.MKT_TAGS
                tagsItem = fc_Tags.SelectByIDAndMaloai(arr(index), "0")
                If tagsItem.nv_TagName_vn <> "" Then
                    rs += "- " + tagsItem.nv_TagName_vn + "</br>"
                End If
            Next
        End If
        Return rs
    End Function

    Public Function SplitTags_DV(ByVal tags As String) As String
        Dim rs As String = ""
        fc_Tags = New BO.MKT_Tags
        If tags <> Nothing Then
            Dim arr As Array = tags.Split(";").ToArray()
            For index As Integer = 0 To arr.Length - 1
                Dim tagsItem As New CM.MKT_TAGS
                tagsItem = fc_Tags.SelectByIDAndMaloai(arr(index), "1")
                If tagsItem.nv_TagName_vn <> "" Then
                    rs += "- " + tagsItem.nv_TagName_vn + "</br>"
                End If
            Next
        End If
        Return rs
    End Function
#End Region
#Region "Button"
    Protected Sub btnXem_Click(sender As Object, e As EventArgs)
        LoadGridView()
    End Sub
    Protected Sub btnDSNo_Click(sender As Object, e As EventArgs)
        Dim tag As String = ""
        Dim fieldValues As List(Of Object) = GVTukhoa.GetSelectedFieldValues(New String() {"Tags", "nv_TagName_vn"})
        For Each item As Object() In fieldValues
            tag = tag & ";" & item(0).ToString
        Next item
        Session("tags_s") = tag
        LocTheoTags(Session("tags_s"))
    End Sub
#End Region
End Class