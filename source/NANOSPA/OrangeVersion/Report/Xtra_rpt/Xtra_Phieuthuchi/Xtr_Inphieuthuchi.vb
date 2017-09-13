Public Class Xtr_Inphieuthuchi
    Private objFcPhieuthuchi As BO.QLTC_PhieuthuchiFacade
    Private objEnPhieuthuchi As CM.QLTC_PhieuthuchiEntity
    Private objFcDMThuchi As BO.QLTC_DM_THUCHIFacade
    Private objEnDMThuchi As CM.QLTC_DM_THUCHIEntity
    Private objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Private objEnKhachhang As CM.CRM_DM_KhachhangEntity
    Public Sub Bindata(uId_phieuthuchi As String, nv_tencuahang As String, nv_DiachiCH As String)
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        objEnPhieuthuchi = New CM.QLTC_PhieuthuchiEntity
        objFcDMThuchi = New BO.QLTC_DM_THUCHIFacade
        objEnDMThuchi = New CM.QLTC_DM_THUCHIEntity
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        Dim public_class As New Public_Class
        Dim datenow As DateTime = Date.Now
        objEnPhieuthuchi = objFcPhieuthuchi.SelectByID(uId_phieuthuchi)
        objEnDMThuchi = objFcDMThuchi.SelectByID(objEnPhieuthuchi.uId_Thuchi)
        lblPKName.Text = "PHÒNG KHÁM TÂM BÌNH"
        If objEnDMThuchi.b_ThuChi = True Then
            XrCel_Nguoi.Text = "Người nộp"
            lbl_Tenphieu.Text = "PHIẾU THU"
            objEnKhachhang = objFcKhachhang.SelectByID(objEnPhieuthuchi.nv_Ghichu)
            If String.IsNullOrEmpty(objEnKhachhang.uId_Khachhang) = False Then
                XrCel_Nguoinop.Text = objEnKhachhang.nv_Hoten_vn.ToString
                XrCel_Diachi.Text = objEnKhachhang.nv_Diachi_vn.ToString
            End If
        Else
            XrCel_Nguoi.Text = "Người nhận"
            lbl_Tenphieu.Text = "PHIẾU CHI"
            XrCel_Nguoinop.Text = objEnPhieuthuchi.nv_Ghichu.ToString
        End If
        lblNgayThang.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        XrCel_Lydo.Text = objEnPhieuthuchi.nv_Lydo_vn.ToString
        XrCel_Sotien.Text = Format(objEnPhieuthuchi.f_Sotien, "n0") + " VND"
        lbl_Maphieu.Text = objEnPhieuthuchi.v_Maphieu.ToString
        XrCel_Bangchu.Text = public_class.ToStrings(objEnPhieuthuchi.f_Sotien)
        xtrlogo.ImageUrl = "~/images/icon_logo/tambinh.jpg"
        'Strings.Format(objEnPhieuthuchi.f_Sotien, "{0:n0}")
    End Sub
    Public Shared Function ToStrings(number As Decimal) As String
        Dim s As String = number.ToString("#")
        Dim so As String() = New String() {"không", "một", "hai", "ba", "bốn", "năm", _
            "sáu", "bảy", "tám", "chín"}
        Dim hang As String() = New String() {"", "nghìn", "triệu", "tỷ"}
        Dim i As Integer, j As Integer, donvi As Integer, chuc As Integer, tram As Integer
        Dim str As String = " "
        Dim booAm As Boolean = False
        Dim decS As Decimal = 0
        'Tung addnew
        Try
            decS = Convert.ToDecimal(s.ToString())
        Catch
        End Try
        If decS < 0 Then
            decS = -decS
            s = decS.ToString()
            booAm = True
        End If
        i = s.Length
        If i = 0 Then
            str = so(0) + str
        Else
            j = 0
            While i > 0
                donvi = Convert.ToInt32(s.Substring(i - 1, 1))
                i -= 1
                If i > 0 Then
                    chuc = Convert.ToInt32(s.Substring(i - 1, 1))
                Else
                    chuc = -1
                End If
                i -= 1
                If i > 0 Then
                    tram = Convert.ToInt32(s.Substring(i - 1, 1))
                Else
                    tram = -1
                End If
                i -= 1
                If (donvi > 0) OrElse (chuc > 0) OrElse (tram > 0) OrElse (j = 3) Then
                    str = hang(j) + str
                End If
                j += 1
                If j > 3 Then
                    j = 1
                End If
                If (donvi = 1) AndAlso (chuc > 1) Then
                    str = Convert.ToString("một ") & str
                Else
                    If (donvi = 5) AndAlso (chuc > 0) Then
                        str = Convert.ToString("lăm ") & str
                    ElseIf donvi > 0 Then
                        str = Convert.ToString(so(donvi) + " ") & str
                    End If
                End If
                If chuc < 0 Then
                    Exit While
                Else
                    If (chuc = 0) AndAlso (donvi > 0) Then
                        str = Convert.ToString("lẻ ") & str
                    End If
                    If chuc = 1 Then
                        str = Convert.ToString("mười ") & str
                    End If
                    If chuc > 1 Then
                        str = Convert.ToString(so(chuc) + " mươi ") & str
                    End If
                End If
                If tram < 0 Then
                    Exit While
                Else
                    If (tram > 0) OrElse (chuc > 0) OrElse (donvi > 0) Then
                        str = Convert.ToString(so(tram) + " trăm ") & str
                    End If
                End If
                str = Convert.ToString("") & str
            End While
        End If
        If booAm Then
            str = Convert.ToString("Âm ") & str
        End If
        Return str & Convert.ToString("đồng chẵn")
    End Function

    Public Shared Function ToStrings(number As Double) As String
        Dim s As String = number.ToString("#")
        Dim so As String() = New String() {"không", "một", "hai", "ba", "bốn", "năm", _
            "sáu", "bảy", "tám", "chín"}
        Dim hang As String() = New String() {"", "nghìn", "triệu", "tỷ"}
        Dim i As Integer, j As Integer, donvi As Integer, chuc As Integer, tram As Integer
        Dim str As String = " "
        Dim booAm As Boolean = False
        Dim decS As Double = 0
        'Tung addnew
        Try
            decS = Convert.ToDouble(s.ToString())
        Catch
        End Try
        If decS < 0 Then
            decS = -decS
            s = decS.ToString()
            booAm = True
        End If
        i = s.Length
        If i = 0 Then
            str = so(0) + str
        Else
            j = 0
            While i > 0
                donvi = Convert.ToInt32(s.Substring(i - 1, 1))
                i -= 1
                If i > 0 Then
                    chuc = Convert.ToInt32(s.Substring(i - 1, 1))
                Else
                    chuc = -1
                End If
                i -= 1
                If i > 0 Then
                    tram = Convert.ToInt32(s.Substring(i - 1, 1))
                Else
                    tram = -1
                End If
                i -= 1
                If (donvi > 0) OrElse (chuc > 0) OrElse (tram > 0) OrElse (j = 3) Then
                    str = hang(j) + str
                End If
                j += 1
                If j > 3 Then
                    j = 1
                End If
                If (donvi = 1) AndAlso (chuc > 1) Then
                    str = Convert.ToString("một ") & str
                Else
                    If (donvi = 5) AndAlso (chuc > 0) Then
                        str = Convert.ToString("lăm ") & str
                    ElseIf donvi > 0 Then
                        str = Convert.ToString(so(donvi) + " ") & str
                    End If
                End If
                If chuc < 0 Then
                    Exit While
                Else
                    If (chuc = 0) AndAlso (donvi > 0) Then
                        str = Convert.ToString("lẻ ") & str
                    End If
                    If chuc = 1 Then
                        str = Convert.ToString("mười ") & str
                    End If
                    If chuc > 1 Then
                        str = Convert.ToString(so(chuc) + " mươi ") & str
                    End If
                End If
                If tram < 0 Then
                    Exit While
                Else
                    If (tram > 0) OrElse (chuc > 0) OrElse (donvi > 0) Then
                        str = Convert.ToString(so(tram) + " trăm ") & str
                    End If
                End If
                str = Convert.ToString("") & str
            End While
        End If
        If booAm Then
            str = Convert.ToString("Âm ") & str
        End If
        Return str & Convert.ToString("đồng chẵn")
    End Function
    Function ConvertString(chuthuong As String) As String
        Dim chuhoa As String
        chuhoa = StrConv(chuthuong, 3)
        Return chuhoa
    End Function
End Class