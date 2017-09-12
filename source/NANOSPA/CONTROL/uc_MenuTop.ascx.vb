Public Class uc_MenuTop
    Inherits System.Web.UI.UserControl
    Dim objFcAppoint As New BO.AppointmentsFacade
    Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        dt = objFcAppoint.SelectWarming(30)
        If dt.Rows.Count > 0 Then
            ltrNotice.Text = "<span class='number_notice'>" & dt.Rows.Count & "</span>"
        Else
            ltrNotice.Text = ""
        End If
    End Sub

End Class