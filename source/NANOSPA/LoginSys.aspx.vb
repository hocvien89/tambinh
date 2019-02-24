Public Class LoginSys
    Inherits System.Web.UI.Page
    Private oLog As New LogError.ShowError
    Private oCls_Nhansu As New CM.cls_Nhanvien
    Private oClsB_Nhansu As New BO.clsB_Nhanvien
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Dim objFCThamsohethong As BO.clsB_QT_THAMSOHETHONG
    Private objEnthamsohethong As CM.cls_QT_THAMSOHETHONG
    'Private objNhanVienPhong As New BO.PQP_NHANVIEN_PHONGFacade
    Private pc As New Public_Class

#Region "Init, Dispose"

    Private Sub Login_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            oLog.strPathFileLog = Server.MapPath("Log").ToString & "\"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Login_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        oCls_Nhansu = New CM.cls_Nhanvien
        oClsB_Nhansu = New BO.clsB_Nhanvien
        oLog = New LogError.ShowError
    End Sub

    Private Sub Login_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oCls_Nhansu = Nothing
        oClsB_Nhansu = Nothing
        oLog = Nothing
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Xoa Het session
        Session.Clear()
        txtTendangnhap.Focus()
    End Sub

    Protected Sub cmdDangnhap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDangnhap.Click
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        objEnthamsohethong = New CM.cls_QT_THAMSOHETHONG
        'Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vExD")
        'Dim ds As Integer
        'ds = DateDiff(DateInterval.Day, Convert.ToDateTime(oThamsohethong.v_Giatri), DateTime.Now)
        'If ds > 365 Then
        '    ShowMessage(Me, "Đã hết hạn sử dụng! vui lòng liên hệ NANOSOFT để được gia hạn phần mềm")
        '    Exit Sub
        'End If
        Try
            Dim i As Integer
            i = pc.TestSymbol(txtTendangnhap.Text, "")
            If (i = 1) Then
                lblTrangthai.Text = "Không được nhập các ký tự đặc biệt và ký tự trống!!!"
                txtTendangnhap.Focus()
            Else
                oCls_Nhansu.v_Tendangnhap = txtTendangnhap.Text
                oCls_Nhansu.v_Matkhau = txtMatkhau.Text

                If oClsB_Nhansu.chk_CheckLogin(oCls_Nhansu) Then
                    'Wirte session
                    Session("sTendangnhap") = txtTendangnhap.Text
                    Session("uId_Nhanvien_Dangnhap") = oClsB_Nhansu.chk_GetIDLogin(oCls_Nhansu)
                    '===Manhtt===
                    'FC: Lay phong cua nhan vien
                    'If Session("uId_Nhanvien_Dangnhap") <> Nothing Then
                    '    Dim NVPhong As New CM.PQP_NHANVIEN_PHONGEntity
                    '    Dim uIdNV As String = Session("uId_Nhanvien_Dangnhap").ToString()
                    '    NVPhong = objNhanVienPhong.SelectPhongByMaNV(uIdNV)
                    '    Session("uId_Phongban_NV_Current") = NVPhong.uId_Phongban
                    'End If
                    '===End Manhtt===
                    If String.Equals(txtTendangnhap.Text.ToLower, "supperadmin") Then
                        Session("uId_Cuahang") = "supperadmin"
                        Session("nv_Tencuahang_vn") = ""
                        Session("nv_DiachiCH_vn") = ""
                    Else
                        If txtTendangnhap.Text = "quantri" Then
                            Session("uId_Cuahang") = "quantri"
                        Else
                            Session("uId_Cuahang") = oClsB_Nhansu.chk_GetIDCuahangLogin(oCls_Nhansu)
                            Dim dt As DataTable = objFCCuaHang.SelectByID(Session("uId_Cuahang"))
                            Session("nv_Tencuahang_vn") = dt.Rows(0)("nv_Tencuahang_vn").ToString
                            Session("nv_Tencuahang_en") = dt.Rows(0)("nv_Tencuahang_en").ToString
                            Session("nv_DiachiCH_vn") = dt.Rows(0)("nv_Diachi_vn").ToString
                            Session("nv_DiachiCH_en") = dt.Rows(0)("nv_Diachi_en").ToString
                            Session("nv_Dienthoai") = dt.Rows(0)("nv_Dienthoai").ToString
                        End If
                    End If
                    'Redirect toi Trang chu
                    If (txtTendangnhap.Text.Contains("letan")) Then
                        Response.Redirect("Default.aspx", True)
                    Else
                        'objEnthamsohethong = objFCThamsohethong.SelectTHAMSOHETHONGByID("PageStart")
                        Response.Redirect("Default.aspx", True)
                    End If
                Else
                    lblTrangthai.Text = "Tài khoản đăng nhập không đúng! Vui lòng đăng nhập lại?"
                    txtTendangnhap.Focus()
                End If
            End If
        Catch ex As Exception
            oLog.WriteLog("cmdDangnhap_Click()", ex.Message)
        End Try
    End Sub

End Class