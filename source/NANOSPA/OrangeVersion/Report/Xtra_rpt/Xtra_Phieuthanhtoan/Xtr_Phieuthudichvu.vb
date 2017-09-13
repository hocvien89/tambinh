Public Class Xtr_Phieuthudichvu
    Public Sub Bindata(ByVal uId_Phieudichvu As String, ByVal uId_Khachhang As String, ByVal Tencuahang As String, ByVal Diachi As String)
        Dim oLibP As New Lib_SAT.cls_Pub_Functions
        Dim objFCLoaihinhTT As New BO.QLTC_LoaiHinhTTFacade
        Dim objFCChitietDV As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim objFCNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objEnPhieuDV As New CM.TNTP_PHIEUDICHVUEntity
        Dim objFcPhieudichvu As New BO.TNTP_PHIEUDICHVUFacade
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim objFc_Cuahang = New BO.QT_DM_CUAHANGFacade
        Dim public_class As New Public_Class
        Dim dt_Congno As DataTable = objFcPhieudichvu.Select_Congno_ByID(uId_Phieudichvu)
        Dim dt_tt As DataTable
        dt_tt = objFcPhieudichvu.Select_LoaihinhTT_ByID(uId_Phieudichvu)
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachhang)
        lbkhachhang.Text = objEnKhachhang.nv_Hoten_vn
        lbdiachi.Text = objEnKhachhang.nv_Diachi_vn
        lbdienthoai.Text = objEnKhachhang.v_DienthoaiDD
        lbsinhnhat.Text = objEnKhachhang.d_Ngaysinh
        lblPKName.Text = "PHÒNG KHÁM TÂM BÌNH"
        xtrlogo.ImageUrl = "~/images/icon_logo/tambinh.jpg"
        Dim table As DataTable
        table = objFcKhachhang.SelectByIDTable_PDV(uId_Phieudichvu)
        If table.Rows.Count > 0 Then
            lbnguon.Text = table.Rows(0).Item("nv_Nguon_vn").ToString
            lbtuvan.Text = table.Rows(0).Item("nv_Tuvan_vn").ToString
        Else
            lbnguon.Text = ""
            lbtuvan.Text = ""
        End If
        lbemail.Text = objEnKhachhang.v_Email
        objEnPhieuDV = objFcPhieudichvu.SelectByID(uId_Phieudichvu)
        lblGiamgia.Text = String.Format("{0:#,##}", Val(objEnPhieuDV.f_Giamgia))
        lbcongno.Text = String.Format("{0:#,##}", Val(dt_Congno.Rows(0).Item("f_Tienno")))
        lbcuahang.Text = Diachi
        lbsophieu.Text = objEnPhieuDV.v_Sophieu
        Dim dt As DataTable = objFCChitietDV.SelectByID(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            BindingSource1.DataSource = dt
            dt.Dispose()
        End If
        lbtienmat.Text = String.Format("{0:#,##}", Val(dt_tt.Rows(0)("f_Tienmat").ToString))
        lbnganhang.Text = String.Format("{0:#,##}", Val(dt_tt.Rows(0)("f_Banking").ToString))
        lbbangchu.Text = public_class.ToStrings(Convert.ToDouble(dt_tt.Rows(0)("f_Tienmat").ToString))
        lbsinhnhat.Text = objEnKhachhang.d_Ngaysinh.Year
        Dim ndate As New Date
        ndate = Date.Now
        lblNgay.Text = ndate.Day.ToString
        lblThang.Text = ndate.Month.ToString
        lblNam.Text = ndate.Year.ToString
    End Sub
   
End Class