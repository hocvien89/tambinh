Public Class rp_Mathangquantam
    Inherits System.Web.UI.Page
    Private BC As Xtr_Mathangquantam
    Private objFCKHQT As New BO.clsB_BaoCao_Khachhang

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTinhthanh()
        End If
        loadBC()
    End Sub

    Protected Sub LoadTinhthanh()
        Dim dt As DataTable
        dt = objFCKHQT.spCRM_DM_TINHTHANH_SelectAll()
        ASPxTinhthanh.DataSource = dt
        ASPxTinhthanh.ValueField = "uId_Tinhthanh"
        ASPxTinhthanh.TextField = "nv_Tentinhthanh"
        ASPxTinhthanh.DataBind()
    End Sub


    Protected Sub ASPxQuanhuyen_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles ASPxQuanhuyen.Callback
        Dim dt As DataTable
        dt = objFCKHQT.spCRM_DM_QUANHUYEN_SelectAllByID(e.Parameter)
        ASPxQuanhuyen.DataSource = dt
        ASPxQuanhuyen.ValueField = "uId_Quanhuyen"
        ASPxQuanhuyen.TextField = "nv_Tenquanhuyen"
        ASPxQuanhuyen.DataBind()
    End Sub

    Protected Sub loadBC()
        Dim title As String
        Dim gt As String
        Dim Tuoitu As Integer
        Dim Tuoiden As Integer
        Dim Quanhuyen As String
        title = ""
        If rb_Nam.Checked = True Then
            gt = "Nam"

        ElseIf rb_Nu.Checked = True Then
            gt = "Nu"
        Else
            gt = "All"
        End If

        If ASPx_Tuoitu.Text = Nothing Then
            Tuoitu = Nothing
        Else
            Tuoitu = ASPx_Tuoitu.Text
            title = title + "Tuổi từ : " + Tuoitu.ToString()
        End If
        If ASPx_Tuoiden.Text = Nothing Then
            Tuoiden = Nothing
        Else
            Tuoiden = ASPx_Tuoiden.Text
            title = title + "  Tuổi đến : " + Tuoiden.ToString()
        End If
        If ASPxQuanhuyen.Items.Count = 0 Then
            Quanhuyen = Nothing
        Else
            Quanhuyen = ASPxQuanhuyen.SelectedItem.Value
            title = title + "    Quận huyện : " + ASPxQuanhuyen.SelectedItem.Text
        End If
        BC = New Xtr_Mathangquantam
        Dim dt As DataTable
        dt = objFCKHQT.spBAOCAO_LuongKH(Tuoiden, Tuoitu, gt, Quanhuyen)
        BC.XrLabel2.Text = title
        BC.Bind(dt)
        ReportViewer1.Report = BC

        dt = Nothing

    End Sub

    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadBC()
    End Sub
End Class