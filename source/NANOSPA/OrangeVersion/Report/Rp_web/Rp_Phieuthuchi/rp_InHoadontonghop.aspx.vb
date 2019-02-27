Imports DevExpress.Web.ASPxEditors

Public Class rp_InHoadontonghop
    Inherits System.Web.UI.Page
    Private objFcPhieuthuchi As BO.QLTC_PhieuthuchiFacade
    Private SLuahchon As String
    Private objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Private objFcPhieudichvu As BO.TNTP_PHIEUDICHVUFacade
    Private objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Private objEnKhachhang As CM.CRM_DM_KhachhangEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SLuahchon = Request.QueryString("Luachon")
        loadPhieuxuatByKh()
        LoadPhieuDVByKH()
        If SLuahchon = "Phieuxuat" Then
            cboPhieuxuat.Value = Session("uId_Phieuxuat")
            cboPhieudichvu.SelectedIndex = 0
        Else
            cboPhieudichvu.Value = Session("uId_Phieudichvu")
            cboPhieuxuat.SelectedIndex = 0
        End If
        loadInfoIn()
    End Sub
    Private Sub loadInfoIn()
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim dt As DataTable
        Dim BC As New Xtr_InHoadonChungSPDV
        If SLuahchon = "Phieuxuat" Then
            dt = objFcPhieuthuchi.InHoadonTonghop(Session("uId_Khachhang"), Session("uId_Phieuxuat"), cboPhieudichvu.Value)
        Else
            dt = objFcPhieuthuchi.InHoadonTonghop(Session("uId_Khachhang"), cboPhieuxuat.Value, Session("uId_Phieudichvu"))
        End If
        For i As Integer = 0 To dt.Rows.Count - 2
                If dt.Rows(i)("v_Phieu").ToString = dt.Rows(i + 1)("v_Phieu").ToString Then
                    dt.Rows(i + 1)("f_tongthanhtoan") = 0
                End If
        Next
        Dim strngay() As String
        Dim str As String = Date.Now.Date
        strngay = str.Split("/")
        BC.lblNgay.Text = "Ngày :" + strngay(1) + "/" + strngay(0) + "/" + strngay(2)
        objEnKhachhang = objFcKhachhang.SelectByID(Session("uId_Khachhang"))
        BC.XrCellKhachhang.Text = objEnKhachhang.nv_Hoten_vn
        BC.XrCellDiachi.Text = objEnKhachhang.nv_Diachi_vn
        BC.XrCellDienthoai.Text = objEnKhachhang.v_DienthoaiDD
        BC.lblTencuahang.Html = Session("nv_Tencuahang_en")
        BC.lblDiachi.Html = Session("nv_DiachiCH_en")
        BC.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        BC.XrPictureBox_logo.ImageUrl = "~" + objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        BC.bindata(dt)
        ReportViewerControl.ReportViewer.Report = BC
    End Sub
    Private Sub loadPhieuxuatByKh()
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable
        dt = objFcPhieuxuat.SelectByKH(Session("uId_Khachhang"), "1/1/2010", DateTime.Now)
        If dt.Rows.Count > 0 Then
            cboPhieuxuat.DataSource = dt
            cboPhieuxuat.TextField = "v_Maphieuxuat"
            cboPhieuxuat.ValueField = "uId_Phieuxuat"
            cboPhieuxuat.DataBind()
        Else
            Dim item As New ListEditItem
            item.Text = "Không có phiếu xuất"
            item.Value = ""
            cboPhieuxuat.Items.Add(item)
            cboPhieuxuat.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadPhieuDVByKH()
        objFcPhieudichvu = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable
        dt = objFcPhieudichvu.SelectAllTable(Session("uId_Khachhang"))
        If dt.Rows.Count > 0 Then
            cboPhieudichvu.DataSource = dt
            cboPhieudichvu.TextField = "v_Sophieu"
            cboPhieudichvu.ValueField = "uId_Phieudichvu"
            cboPhieudichvu.DataBind()
        Else
            Dim item As New ListEditItem
            item.Text = "Không có phiếu dịch vụ"
            item.Value = ""
            cboPhieudichvu.Items.Add(item)
            cboPhieudichvu.SelectedIndex = 0
        End If
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        loadInfoIn()
    End Sub
End Class