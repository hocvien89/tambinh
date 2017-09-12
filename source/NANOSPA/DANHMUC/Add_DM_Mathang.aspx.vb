Public Partial Class Add_DM_Mathang
    Inherits System.Web.UI.Page
    Private objFCNhommathang As New BO.QLMH_DM_NHOMMATHANGFacade
    Private objEnNhommathang As New CM.QLMH_DM_NHOMMATHANGEntity
    Private objFCLoaimathang As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objEnLoaimathang As New CM.QLMH_DM_LOAIMATHANGEntity
    Private objFCXuatxu As New BO.QLMH_DM_XUATXUFacade
    Private objEnXuatxu As New CM.QLMH_DM_XUATXUEntity
    Private objFC As New BO.QLMH_DM_MATHANGFacade
    Private objEn As New CM.QLMH_DM_MATHANGEntity
    Private objFCGiaMH As New BO.QLMH_DINHMUC_GIAMATHANGFacade
    Private objEnGiaMH As New CM.QLMH_DINHMUC_GIAMATHANGEntity
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private pc As New Public_Class
    Private BC As New BaoCao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadMaMathang()
            LoadData()
            LoadDropDownListLoaimathang()
            LoadDropDownListNhommathang()
            LoadDropDownListXuatxu()
        End If
    End Sub
    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFCCuaHang.SelectByID(Session("uId_Cuahang"))
        Session("strMaCH") = dt.Rows(0)("v_Macuahang").ToString
        If Session("uId_Mathang") <> Nothing Then
            Dim objNew As New CM.QLMH_DM_MATHANGEntity
            objNew = objFC.SelectByID(Session("uId_Mathang"))
            txtDVT.Text = objNew.nv_DVT_vn
            txtGhichu.Text = objNew.nv_Ghichu_vn
            txtHanmucTon.Text = objNew.f_Hanmuc_Ton
            txtHoahongCTV.Text = Format(objNew.f_PhamtramHH_CTV, "N0")
            txtHoahongKTV.Text = Format(objNew.f_PhantramHH_KTV, "N0")
            txtHoahongNV.Text = Format(objNew.f_PhantramHH_NV, "N0")
            txtHoahongTVV.Text = Format(objNew.f_PhantramHH_TVV, "N0")
            txtHSD.Text = objNew.i_Songaycanhbao_HethanSD
            txtMaMH.Text = objNew.v_MaMathang
            txtTenMH.Text = objNew.nv_TenMathang_vn
            txtBarcode.Text = objNew.v_MaBarcode
            txtTon.Text = objNew.i_Songaycanhbao_Ton
            ddlLoaimathang.SelectedValue = objNew.uId_Loaimathang
            ddlNhommathang.SelectedValue = objNew.uId_Nhommathang
            ddlXuatXu.SelectedValue = objNew.uId_Xuatxu
        Else : LoadMavachSP()
            LoadMaMathang()
        End If
    End Sub
    Private Sub LoadMavachSP()
        Dim dblMa As Double
        Dim strCode As String
        If ddlBarcodeType.SelectedValue.ToString = "128" Then

            objEn = objFC.SelectBarcodeMax(Session("strMaCH") + "SP")
            dblMa = Val(Right(objEn.v_MaBarcode, 6)) + 1
            strCode = CStr(dblMa)
            If strCode.Length < 6 Then
                For i As Integer = strCode.Length To 5
                    strCode = "0" + strCode
                Next
            End If
            txtBarcode.Text = Session("strMaCH") + "SP" + strCode
        Else
            objEn = objFC.SelectBarcodeMax(BC.BarcodeSP)
            dblMa = Val(Mid(objEn.v_MaBarcode, 8, 12)) + 1
            strCode = CStr(dblMa)
            If strCode.Length < 5 Then
                For i As Integer = strCode.Length To 4
                    strCode = "0" + strCode
                Next
            End If
            strCode = BC.BarcodeSP + strCode
            txtBarcode.Text = InsertCheckSum(strCode)
        End If
    End Sub
    Private Function InsertCheckSum(ByVal code As String) As String
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim j As Integer = 11
        For i As Integer = 1 To 12
            If i Mod 2 = 0 Then
                X += Val(code(j))
            Else
                Y += Val(code(j))
            End If
            j -= 1
        Next

        Dim Z As Integer = X + (3 * Y)
        Return code + ((10 - (Z Mod 10)) Mod 10).ToString
    End Function
    Private Sub LoadDropDownListNhommathang()
        ddlNhommathang.DataSource = objFCNhommathang.SelectAllTable()
        ddlNhommathang.DataTextField = "nv_Tennhommathang_vn"
        ddlNhommathang.DataValueField = "uId_Nhommathang"
        ddlNhommathang.DataBind()
    End Sub
    Protected Sub btnTaoMa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTaoMaVach.Click
        If txtBarcode.Text.Trim <> "" Then
            lblMaVach.Text = txtBarcode.Text
            Session("Codetype") = ddlBarcodeType.SelectedValue
            Session("MaVachSP") = txtBarcode.Text
            imgMaVach.ImageUrl = "MaVachSP.aspx"
            btn_In.Visible = True
        End If
    End Sub
    Private Sub LoadMaMathang()
        If Session("uId_Mathang") = Nothing Then
            txtMaMH.Text = pc.ReturnAutoString("H")
        End If
    End Sub
    Protected Sub ddlBarcodeType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlBarcodeType.SelectedIndexChanged
        LoadMavachSP()
    End Sub
    Private Sub LoadDropDownListLoaimathang()
        ddlLoaimathang.DataSource = objFCLoaimathang.SelectAllTable()
        ddlLoaimathang.DataTextField = "nv_Tenloaimathang_vn"
        ddlLoaimathang.DataValueField = "uId_Loaimathang"
        ddlLoaimathang.DataBind()
    End Sub

    Private Sub LoadDropDownListXuatxu()
        ddlXuatXu.DataSource = objFCXuatxu.SelectAllTable()
        ddlXuatXu.DataTextField = "nv_Tenxuatxu_vn"
        ddlXuatXu.DataValueField = "uid_Xuatxu"
        ddlXuatXu.DataBind()
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_OK.Click
        If txtBarcode.Text <> "" Then
            If ddlBarcodeType.SelectedValue = "128" Then
                If (txtBarcode.Text.Length <> 10) Or (Left(txtBarcode.Text, 4) <> Session("strMaCH") + "SP") Then
                    ShowMessage(Me, "Mã vạch không hợp lệ!")
                    Exit Sub
                End If
            ElseIf (txtBarcode.Text.Length <> 13) Or Not IsNumeric(txtBarcode.Text) Then
                ShowMessage(Me, "Mã vạch không hợp lệ!")
                Exit Sub
            End If
            Dim dt As DataTable
            dt = objFC.SelectByBarcode(Session("uId_Mathang"), txtBarcode.Text)
            If dt.Rows.Count > 0 Then
                ShowMessage(Me, "Mã vạch đã có!Xin kiểm tra lại")
                Exit Sub
            End If
        End If
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        With objEn
            If Session("uId_Mathang") <> Nothing Then
                .uId_Mathang = Session("uId_Mathang")
            End If
            .uId_Loaimathang = CStr(Me.ddlLoaimathang.SelectedValue)
            .uId_Nhommathang = CStr(Me.ddlNhommathang.SelectedValue)
            .uId_Xuatxu = CStr(Me.ddlXuatXu.SelectedValue)
            .v_MaMathang = CStr(Me.txtMaMH.Text.Trim)
            .v_MaBarcode = txtBarcode.Text
            .nv_TenMathang_vn = CStr(Me.txtTenMH.Text.Trim)
            .nv_DVT_vn = CStr(Me.txtDVT.Text.Trim)
            .nv_Ghichu_vn = CStr(Me.txtGhichu.Text.Trim)
            .f_Hanmuc_Ton = CInt(Val(Me.txtHanmucTon.Text.Trim))
            .i_Songaycanhbao_HethanSD = CInt(Val(Me.txtHSD.Text.Trim))
            .i_Songaycanhbao_Ton = CInt(Val(Me.txtTon.Text.Trim))
            .f_PhantramHH_KTV = CInt(Val(Me.txtHoahongKTV.Text.Trim.Replace(",", "")))
            .f_PhamtramHH_CTV = CInt(Val(Me.txtHoahongCTV.Text.Trim.Replace(",", "")))
            .f_PhantramHH_NV = CInt(Val(Me.txtHoahongNV.Text.Trim.Replace(",", "")))
            .f_PhantramHH_TVV = CInt(Val(Me.txtHoahongTVV.Text.Trim.Replace(",", "")))
        End With
        If Session("uId_Mathang") <> Nothing Then
            If objFC.Update(objEn) Then
                ShowMessage(Me, "Cập nhập mặt hàng thành công!")
            End If
        Else : Dim str As String = ""
            str = objFC.Insert(objEn)
            If str <> "" Then
                Session("uId_Mathang") = str
                ShowMessage(Me, "Thêm mới mặt hàng thành công!")
            End If
        End If
        LamMoi()
        'With objEnGiaMH
        '    .uId_Mathang = str
        '    .d_Ngay = Convert.ToDateTime(txtngay.Text, sFormat)
        '    .f_Giaban = CInt(Me.txtGiaxuat.Text)
        '    .f_Biendo_Giaban = CInt(Me.txtBiendoGiaxuat.Text)
        '    .f_Gianhap = CInt(Me.txtGianhap.Text)
        '    .f_Biendo_Gianhap = CInt(Me.txtBiendoGianhap.Text)
        'End With
        'objFCGiaMH.Insert(objEnGiaMH)
        'Response.Redirect("~/DANHMUC/DM_Mathang.aspx")
    End Sub
    Protected Sub LamMoi()
        Session("uId_Mathang") = Nothing
        txtDVT.Text = ""
        txtGhichu.Text = ""
        txtHanmucTon.Text = ""
        txtHoahongCTV.Text = ""
        txtHoahongKTV.Text = ""
        txtHoahongNV.Text = ""
        txtHoahongTVV.Text = ""
        txtHSD.Text = ""
        LoadMaMathang()
        txtTenMH.Text = ""
        txtBarcode.Text = ""
        txtTon.Text = ""
    End Sub
    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Mathang.aspx")
    End Sub

End Class