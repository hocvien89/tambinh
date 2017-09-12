Public Class MyDataviewControl
    Inherits System.Web.UI.UserControl
#Region "var"
    Private objFcGiuong As BO.QLP_DM_GIUONGFacade
    Private objFcPhong As BO.QLP_DM_PHONGFacade
    Public uId_Phong As String
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadGuongByPhong()
    End Sub
    Public Sub loadGuongByPhong()
        objFcGiuong = New BO.QLP_DM_GIUONGFacade
        Dim dt As DataTable
        dt = objFcGiuong.SelectGiuongtheophong(uId_Phong)
        If dt.Rows.Count > 0 Then
            DavDMGiuong.DataSource = dt
            DavDMGiuong.DataBind()
        End If

    End Sub
End Class