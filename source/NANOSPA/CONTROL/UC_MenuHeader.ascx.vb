Public Partial Class UC_MenuRight
    Inherits System.Web.UI.UserControl
    Dim objFcAppoint As New BO.AppointmentsFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        dt = objFcAppoint.SelectWarming(30)
        If dt.Rows.Count > 0 Then

        End If
    End Sub

End Class