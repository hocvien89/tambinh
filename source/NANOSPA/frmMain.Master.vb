Public Partial Class frmMain
    Inherits System.Web.UI.MasterPage
    Dim objFcAppoint As New BO.AppointmentsFacade
    Protected Overrides Sub Render(writer As HtmlTextWriter)
        'html minifier & JS at bottom
        ' not tested
        If Me.Request.Headers("X-MicrosoftAjax") <> "Delta=true" Then
            Dim reg As New System.Text.RegularExpressions.Regex("<script[^>]*>[\w|\t|\r|\W]*?</script>")
            Dim sb As New System.Text.StringBuilder()
            Dim sw As New System.IO.StringWriter(sb)
            Dim hw As New HtmlTextWriter(sw)
            MyBase.Render(hw)
            Dim html As String = sb.ToString()
            Dim mymatch As System.Text.RegularExpressions.MatchCollection = reg.Matches(html)
            html = reg.Replace(html, String.Empty)
            reg = New System.Text.RegularExpressions.Regex("(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}|(?=[\r])\s{2,}")
            html = reg.Replace(html, String.Empty)
            reg = New System.Text.RegularExpressions.Regex("</body>")
            Dim str As String = String.Empty
            For Each match As System.Text.RegularExpressions.Match In mymatch
                str += match.ToString()
            Next
            html = reg.Replace(html, str & Convert.ToString("</body>"))
            writer.Write(html)
        Else
            MyBase.Render(writer)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Kiem tra da dang nhap chua, neu chua bawt buoc phai dang nhap
        'Dim dt As DataTable
        'dt = objFcAppoint.SelectWarming(30)
        'If dt.Rows.Count > 0 Then
        '    ltr.Text = "Bạn có " & dt.Rows.Count.ToString.ToUpper & " lịch hẹn"
        'Else
        '    ltr.Text = "::: NANO-SPA 2015 ::: - Phần mềm quản lý spa, salon"
        'End If
        Dim sUid_Nhanvien_Dangnhap As String = ""
        Try
            sUid_Nhanvien_Dangnhap = Session("uId_Nhanvien_Dangnhap")
        Catch ex As Exception
        Finally
            If sUid_Nhanvien_Dangnhap = "" Then Response.Redirect("~/LoginSys.aspx")
        End Try
    End Sub
End Class