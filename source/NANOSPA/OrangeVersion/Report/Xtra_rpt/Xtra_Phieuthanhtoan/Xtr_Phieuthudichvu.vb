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
        Dim dt_Congno As DataTable = objFcPhieudichvu.Select_Congno_ByID(uId_Phieudichvu)
        Dim dt_tt As DataTable
        dt_tt = objFcPhieudichvu.Select_LoaihinhTT_ByID(uId_Phieudichvu)
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachhang)
        lbkhachhang.Text = objEnKhachhang.nv_Hoten_vn
        lbdiachi.Text = objEnKhachhang.nv_Diachi_vn
        lbdienthoai.Text = objEnKhachhang.v_DienthoaiDD
        lbsinhnhat.Text = objEnKhachhang.d_Ngaysinh
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
        xtrlogo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
        lbbangchu.Text = ToStrings(Convert.ToDouble(dt_tt.Rows(0)("f_Tienmat").ToString))
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