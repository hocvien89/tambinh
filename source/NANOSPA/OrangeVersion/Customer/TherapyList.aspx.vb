Public Class TherapyList
    Inherits System.Web.UI.Page
    Private objFckhachhang As BO.CRM_DM_KhachhangFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_Songay.Text = 3
            LoadGrid()
        End If
        LoadGrid()
    End Sub
#Region "load Data"
    Private Function GetTherapylist() As DataTable
        Dim dt As DataTable
        Dim soNgay As String
        objFckhachhang = New BO.CRM_DM_KhachhangFacade
        If txt_Songay.Text = "" Then
            soNgay = 3
        Else
            soNgay = txt_Songay.Text.ToString
        End If
        dt = objFckhachhang.NhacNhoKHLamLieuTrinh(soNgay)
        Return dt
    End Function

    Private Sub LoadGrid()
        Dim dt As DataTable
        dt = GetTherapylist()
        Grid_Lieutrinh.DataSource = dt
        Grid_Lieutrinh.DataBind()
    End Sub
#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        LoadGrid()
    End Sub

    'Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
    '    Response.Redirect("~/OrangeVersion/Customer/ReportForm_Cus.aspx")
    'End Sub

    Protected Sub ExportExcel_Click(sender As Object, e As EventArgs)
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
End Class