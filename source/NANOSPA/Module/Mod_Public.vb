Module Mod_Public

    Public Sub MessageBoxShow(ByVal sMessage As String)
        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("alert(""" & sMessage & """)" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("</SCRIPT>")
    End Sub

    Public Sub ShowMessage(ByVal senderpage As System.Web.UI.Page, ByVal alertMsg As String)
        'Create by: Mr Thang, 2013.11.26
        'NMT - FUN: Ham Hien thi mot Messgase box trong ASP.NET

        'Dim alertKey As String = ""
        'Dim strScript As String = "alert ('" + alertMsg + "');</script>"
        'If (Not senderpage.ClientScript.IsStartupScriptRegistered(alertKey)) Then
        '    senderpage.ClientScript.RegisterStartupScript(senderpage.GetType(), alertKey, strScript, True)
        'End If

        System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("alert(""" & alertMsg & """)" & vbCrLf)
        System.Web.HttpContext.Current.Response.Write("</SCRIPT>")
    End Sub

    'Public Sub OpenWindow(ByVal sender As Object, ByVal e As EventArgs, ByVal url As String)
    '    Dim s As String = "window.open('" & url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');"
    '    ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    'End Sub


    Public Function fCal_Thangtuoi(ByVal iThang As Integer, ByVal iNam As Integer)
        Dim iThangtuoi, iNam_No As Integer
        If Now.Year - iNam = 0 Then
            iThangtuoi = IIf((Now.Month - iThang) > 0, Now.Month - iThang, 0)
        ElseIf Now.Year - iNam > 0 Then
            iNam_No = Now.Year - iNam
            iThangtuoi = ((iNam_No - 1) * 12) + (13 - iThang) + Now.Month
        End If
        Return iThangtuoi
    End Function
End Module
