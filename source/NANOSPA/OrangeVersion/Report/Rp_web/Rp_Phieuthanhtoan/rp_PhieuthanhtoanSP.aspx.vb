Public Class rp_PhieuthanhtoanSP
    Inherits System.Web.UI.Page
    'Cau hinh 0 la may in nhiet
    'Cau hinh 1 la may in A5 ngang
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vInPhieudichvu")
        If Not (oThamsohethong Is Nothing) Then
            If oThamsohethong.v_Giatri = "0" Then
                Dim rp_A6 As New rpt_Phieuthanhtoan_SP_A6 'May in nhiet(Ko goi la A6)
                rp_A6.lblTencuahang.Html = Session("nv_Tencuahang_en")
                rp_A6.lblDiachi.Html = Session("nv_DiachiCH_en")
                rp_A6.BindData(Session("uId_Phieuxuat"), Session("uId_Khachhang"), Session("nv_Tencuahang_vn"), Session("nv_DiachiCH_vn"))
                ReportViewerControl.ReportViewer.Report = rp_A6
            ElseIf oThamsohethong.v_Giatri = "1" Then
                Dim rp_A5 As New rpt_Phieuthanhtoan_SP_A5
                rp_A5.lblTencuahang.Html = Session("nv_Tencuahang_en")
                rp_A5.lblDiachi.Html = Session("nv_DiachiCH_en")
                rp_A5.BindData(Session("uId_Phieuxuat"), Session("uId_Khachhang"), Session("nv_Tencuahang_vn"), Session("nv_DiachiCH_vn"))
                ReportViewerControl.ReportViewer.Report = rp_A5
            End If
        End If
    End Sub

End Class