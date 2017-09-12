Public Class rp_ConsultService
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim objEnDMKhachhang = New CM.CRM_DM_KhachhangEntity
        Dim objEnDmCuahang = New CM.QT_DM_CUAHANGEntity
        Dim objFcDMCuahang = New BO.QT_DM_CUAHANGFacade
        objEnDMKhachhang = objFcDMKhachhang.SelectByID(Session("uId_Khachhang"))
        Dim dt As New DataTable
        dt = objFcDMCuahang.SelectByID(Session("uId_Cuahang"))
        Dim BC As New Xtr_Consult
        BC.lbSDT.Text= objEnDMKhachhang.v_DienthoaiDD
        BC.lbDiachi.Text = objEnDMKhachhang.nv_Diachi_vn
        BC.txtHoten.Text = objEnDMKhachhang.nv_Hoten_vn
        BC.lblSpaName.Text = Session("nv_Tencuahang_vn")
        BC.lb_sdt.Text = dt.Rows(0).Item("nv_Dienthoai").ToString
        BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
        ReportViewerControl.ReportViewer.Report = BC
    End Sub

End Class