Public Class rp_ThuhoiCongno
    Inherits System.Web.UI.Page
    Private objFcPhieuttcongno As BO.QLCN_CONGNO_THANHTOANFacade
    Private objEnPhieuttcongno As CM.QLCN_CONGNO_THANHTOANEntity
    Private pl As Public_Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim uid As String
        uid = Request.QueryString("uId")
        loaddata(uid)
    End Sub
    Private Sub loaddata(uId_phieuthanhtoan As String)
        pl = New Public_Class
        Dim uId_Phieu As String = uId_phieuthanhtoan.Split("$")(0)
        Dim luachon As String = uId_phieuthanhtoan.Split("$")(1)
        objFcPhieuttcongno = New BO.QLCN_CONGNO_THANHTOANFacade
        objEnPhieuttcongno = New CM.QLCN_CONGNO_THANHTOANEntity
        Dim xtr_congno As New rpt_InThanhtoanCongno
        xtr_congno.lbl_Cuahang.Text = Session("nv_Tencuahang_vn")
        xtr_congno.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
        objEnPhieuttcongno = objFcPhieuttcongno.SelectByID(uId_phieuthanhtoan)
        Dim dt As DataTable
        dt = objFcPhieuttcongno.SelectInfoThanhtoan(uId_Phieu, luachon)
        xtr_congno.XrCellKhachhang.Text = dt.Rows(0)("nv_Hoten_vn").ToString
        xtr_congno.XrCellSophieu.Text = dt.Rows(0)("v_Sophieu").ToString
        xtr_congno.XrCellSotieno.Text = Format(Convert.ToDouble(dt.Rows(0)("f_Sotien").ToString), "n0") + " VND"
        xtr_congno.XrCellSotiennhan.Text = Format(Convert.ToDouble(dt.Rows(0)("f_Sotiennolai").ToString), "n0") + " VND"
        xtr_congno.lbl_Maphieu.Text = dt.Rows(0)("v_Maphieu").ToString
        xtr_congno.XrCellBangchu.Text = pl.ToStrings(Convert.ToDouble(dt.Rows(0)("f_Sotiennolai")))
        ReportViewerControl.ReportViewer.Report = xtr_congno
    End Sub
End Class