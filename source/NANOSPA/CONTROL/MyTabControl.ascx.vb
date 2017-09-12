Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxRoundPanel

Public Class TabControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            createTabcontrol()
        End If
    End Sub
    Private Sub createTabcontrol()
        Dim oTab As New ASPxTabControl
        Dim oGroup As New ASPxRoundPanel
        Dim oPageContainer As New ASPxPageControl
        oPageContainer.ID = "Mypagecontainer"
        oTab.ID = "MyTab1"
        oTab.TextField = "Tab số 1"

        oGroup.ID = "MyGroup"
        oGroup.HeaderText = "My group"

        oTab.Controls.Add(oGroup)
        oPageContainer.Controls.Add(oTab)
        form1.Controls.Add(oPageContainer)
    End Sub
End Class