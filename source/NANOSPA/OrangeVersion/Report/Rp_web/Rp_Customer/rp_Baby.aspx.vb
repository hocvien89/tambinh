Imports DevExpress.Web.ASPxEditors
Public Class rp_Baby
    Inherits System.Web.UI.Page
    Private objFcDichvu As BO.clsB_BaoCao_Khachhang
    Private objFcPhieudichvu As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Private objFcbaocaokhachhang As BO.clsB_BaoCao_Khachhang
    Private objFcPhieudichvuchitiet As BO.TNTP_PHIEUDICHVU_CHITIETFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
        End If
        loadcombokhachhang()
        loadreport()
    End Sub
    Private Sub loadcombokhachhang()
        Dim objFcDichvu = New BO.clsB_BaoCao_Khachhang

        Dim dt As DataTable
        dt = objFcDichvu.SelectThongkeKH_Damua_Sanpham()
        If dt.Rows.Count > 0 Then
            cbo_khachhang.DataSource = dt
            cbo_khachhang.ValueField = "uId_Khachhang"
            cbo_khachhang.TextField = "nv_Hoten_vn"
            cbo_khachhang.DataBind()

        End If
    End Sub
    Private Sub loadreport()
        Dim rp_Mother As New Xtr_Baby
        If cbo_Phieuchitiet.SelectedIndex <> -1 Then

            'Dim dt As New DataTable
            'Dim objFcDichvu = New BO.clsB_BaoCao_Khachhang
            'Dim objFcBaocaokhachhang As New BO.clsB_BaoCao_Khachhang
            'Dim objFcPhieudichvuchitiet As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
            rp_Mother.Bindata(cbo_khachhang.Value.ToString, cbo_Phieuchitiet.Value.ToString)

        End If
        ReportViewer1.Report = rp_Mother
    End Sub
    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs)
        loadreport()
    End Sub

    Protected Sub cbo_Phieuchitiet_Callback1(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Dim objFcPhieudichvu = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt2 As DataTable
        dt2 = objFcPhieudichvu.SelectDVByID_Khachhang(e.Parameter)
        If dt2.Rows.Count > 0 Then
            cbo_Phieuchitiet.DataSource = dt2
            cbo_Phieuchitiet.ValueField = "uId_Phieudichvu_Chitiet"
            cbo_Phieuchitiet.TextField = "nv_Tendichvu_vn"
            cbo_Phieuchitiet.DataBind()


        End If
    End Sub

    Protected Sub btnback_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/OrangeVersion/Customer/ReportForm_Cus.aspx")
    End Sub
End Class