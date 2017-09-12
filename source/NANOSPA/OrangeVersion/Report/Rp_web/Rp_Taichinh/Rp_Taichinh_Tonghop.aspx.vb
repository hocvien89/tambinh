Imports DevExpress.Web.ASPxEditors

Public Class Rp_Taichinh_Tonghop
    Inherits System.Web.UI.Page
    Private objFCBaoCao As New BO.clsB_Baocao_Taichinh
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Dim BC As New Xtr_Tonghop_Kinhdoanh
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            loadCuahang()
            cbo_Cuahang.SelectedIndex = 0
        End If
        loadData()
    End Sub
#Region "load du lieu"
    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Private Sub loadCuahang()
        Dim dt As DataTable
        dt = objFCCuaHang.SelectAllTable()
        Dim item As New ListEditItem
        item.Value = "Tatca"
        item.Text = "Tất cả"
        cbo_Cuahang.Items.Add(item)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim items As New ListEditItem
                items.Text = row("nv_Tencuahang_vn").ToString
                items.Value = row("uId_Cuahang")
                cbo_Cuahang.Items.Add(items)
            Next
        End If
    End Sub
    Private Sub loadData()
        Dim tungay As Date
        Dim denngay As Date
        Dim uId_Cuahang As String
        Dim str() As String
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        If cbo_Cuahang.SelectedIndex = 0 Then
            uId_Cuahang = Nothing
            BC.lbl_Diachi.Text = ""
        Else
            uId_Cuahang = cbo_Cuahang.Value
            BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn").ToString
        End If
        str = objFCBaoCao.TChinhTonghop(tungay, denngay, uId_Cuahang).Split("/")
        '0: tienthucDv, 1: thettDv , 2: thucteSp, 3: TheTTsp, 4: TheTTnosp , 5: TheTTnoDv, 6: thunoDv, 7: ThunoSp
        '8: ThuctenoDv, 9:ThuctenoSp
        For i As Integer = 0 To str.Length - 1 Step 1
            If str(i) = "" Or str(i) = Nothing Then
                str(i) = "0"
            End If
        Next
        Dim dt As DataTable = objFCBaoCao.BaocaoTonghop_Luong(tungay, denngay)
        Dim dtth As DataTable = objFCBaoCao.Baocaotonghop_Tieuhao(tungay, denngay)
        Dim TheTTDv As Double = Convert.ToDouble(str(1))
        Dim TheTTSp As Double = Convert.ToDouble(str(3))
        Dim ThucteDv As Double = Convert.ToDouble(str(0))
        Dim ThucteSP As Double = Convert.ToDouble(str(2))
        Dim ThuKhachnoDv As Double = Convert.ToDouble(str(6))
        Dim ThuKhachnoSp As Double = Convert.ToDouble(str(7))
        Dim ThucteKhachnoDv As Double = Convert.ToDouble(str(8))
        Dim ThucteKhachnoSp As Double = Convert.ToDouble(str(9))
        Dim TheTTKhachnoDV As Double = Convert.ToDouble(str(5))
        Dim TheTTKhachnoSp As Double = Convert.ToDouble(str(4))
        Dim Thu_Dichvu As Double = (Val(objFCBaoCao.Thanhtoantructiep(tungay, denngay, uId_Cuahang)))
        Dim Thu_bansanpham As Double = Val(objFCBaoCao.Bansanpham(tungay, denngay, uId_Cuahang))
        Dim Thu_Khac As Double = Val(objFCBaoCao.Thukhac(tungay, denngay, uId_Cuahang))
        Dim No_Sanpham As Double = Val(objFCBaoCao.Khachhangnosp(tungay, denngay, uId_Cuahang))
        Dim No_Dichvu As Double = Val(objFCBaoCao.Khachhangnolai(tungay, denngay, uId_Cuahang))
        Dim Chi_Nhapsanpham As Double = objFCBaoCao.BaocaoSL_Mathang(tungay, denngay).Rows(0)("sl")
        Dim Chi_Khac As Double = Val(objFCBaoCao.Chikhac(tungay, denngay, uId_Cuahang))
        Dim ChiLuong As Double = dt.Rows(0)("tong")
        Dim Tieuhao As Double = dtth.Rows(0)("tien")
        Dim Tong_Tienthu As Double = Thu_bansanpham + Thu_Dichvu
        Dim Tong_ThucteThu As Double = ThucteDv + ThucteSP + Thu_Khac
        Dim Tong_TheTTThu As Double = TheTTDv + TheTTKhachnoDV + TheTTKhachnoSp + TheTTSp
        Dim Tong_tienchi As Double = Chi_Nhapsanpham + Tieuhao + ChiLuong
        Dim Tong_NoThu As Double = No_Dichvu + No_Sanpham
        Dim Tong_tien_Thuchi As Double = Tong_Tienthu - Tong_tienchi
        Dim Tong_thucte_thuchi As Double = Tong_ThucteThu - Tong_tienchi
        BC.Parameters("Thu_Dichvu").Value = Thu_Dichvu
        BC.Parameters("Thu_Bansanpham").Value = Thu_bansanpham
        BC.Parameters("ThuKhachnoDv").Value = ThuKhachnoDv
        BC.Parameters("ThuKhachnoSp").Value = ThuKhachnoSp
        BC.Parameters("Thu_Khac").Value = Thu_Khac
        BC.Parameters("ThucteKhachnoDv").Value = ThucteKhachnoDv
        BC.Parameters("ThucteKhachnoSp").Value = ThucteKhachnoSp
        BC.Parameters("TheTTKhachnoDv").Value = TheTTKhachnoDV
        BC.Parameters("TheTTKhachnoSp").Value = TheTTKhachnoSp
        BC.Parameters("Chi_Nhapmypham").Value = Chi_Nhapsanpham
        BC.Parameters("Chi_Khac").Value = Chi_Khac
        BC.Parameters("Tong_NoThu").Value = Tong_NoThu
        BC.Parameters("No_Sanpham").Value = No_Sanpham
        BC.Parameters("No_Dichvu").Value = No_Dichvu
        BC.Parameters("TheTTDv").Value = TheTTDv
        BC.Parameters("TheTTSP").Value = TheTTSp
        BC.Parameters("ThucteDv").Value = ThucteDv
        BC.Parameters("ThucteSP").Value = ThucteSP
        BC.Parameters("Chiluong").Value = ChiLuong
        BC.Parameters("Tong_Tienthu").Value = Tong_Tienthu
        BC.Parameters("Tong_Tienchi").Value = Tong_tienchi
        BC.Parameters("Tong_ThucteThu").Value = Tong_ThucteThu
        BC.Parameters("Tong_TheTTThu").Value = Tong_TheTTThu
        BC.Parameters("Tong_Tien_Thuchi").Value = Tong_tien_Thuchi
        BC.Parameters("Tong_Thucte_Thuchi").Value = Tong_thucte_thuchi
        BC.Parameters("Tieuhao").Value = Tieuhao
        BC.lbl_Tungay.Text = Aspx_Tungay.Text
        BC.lbl_Denngay.Text = Aspx_Denngay.Text
        BC.lbl_Tencuahang.Text = cbo_Cuahang.SelectedItem.ToString
        ReportViewer1.Report = BC
    End Sub
#End Region
#Region "Button click"
    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadData()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
#End Region

End Class