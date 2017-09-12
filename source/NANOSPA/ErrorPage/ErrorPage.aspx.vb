Public Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnJust_Click(sender As Object, e As EventArgs)
        Dim str As String
        str = Request.QueryString("aspxerrorpath")
        Response.Redirect("~/" & str)
    End Sub
End Class