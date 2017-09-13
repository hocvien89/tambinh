Public Class Public_Class
    Public BarcodeSP As String = "8931234"
    Public Function ReturnAutoString(ByVal ID As String) As String
        Dim yc As String = Mid(CStr(Year(Now.Date)), 3, 2)
        Dim mc As String = CStr(Month(Now.Date))
        Dim dc As String = CStr(Now.Day)
        Dim hc As String = CStr(Now.Hour)
        Dim mic As String = CStr(Now.Minute)
        Dim sc As String = CStr(Now.Second)
        Dim msc As String = CStr(Now.Millisecond)
        If (Val(mc) < 10) Then mc = "0" + mc
        If (Val(dc) < 10) Then dc = "0" + dc
        If (Val(hc) < 10) Then hc = "0" + hc
        If (Val(mic) < 10) Then mic = "0" + mic
        If (Val(sc) < 10) Then sc = "0" + sc
        If (Val(msc) < 10) Then msc = "0" + msc
        Return ID + dc + mc + yc + hc + mic + sc + msc
    End Function

    Public Function ReturnAutoStringByDate(ByVal ID As String) As String
        Dim yc As String = Mid(CStr(Year(Now.Date)), 3, 2)
        Dim mc As String = CStr(Month(Now.Date))
        Dim dc As String = CStr(Now.Day)
        'Dim hc As String = CStr(Now.Hour)
        'Dim mic As String = CStr(Now.Minute)
        'Dim sc As String = CStr(Now.Second)
        If (Val(mc) < 10) Then mc = "0" + mc
        If (Val(dc) < 10) Then dc = "0" + dc
        'If (Val(hc) < 10) Then hc = "0" + hc
        'If (Val(mic) < 10) Then mic = "0" + mic
        'If (Val(sc) < 10) Then sc = "0" + sc
        Return ID + dc + mc + yc + "."
    End Function
    Public Function Convertstringtodb(str As String) As Double
        If str = "" Then
            Return 0
        Else
            Return Convert.ToDouble(Replace(str, ",", ""))
        End If
    End Function
    Public Function TuDongSinhMa(ByVal sKyTuBatDau As String, ByVal iSoPhieuHientai As Integer) As String
        Dim sMa As String = ""
        sMa = sKyTuBatDau
        'sMa = sMa & Now.Year.ToString().Substring(2) & Now.Month.ToString("00") & Now.Day.ToString("00") & Now.Hour.ToString("00") & Now.Minute.ToString("00")
        sMa = sMa & Now.Year.ToString().Substring(2) & Now.Month.ToString("00")
        iSoPhieuHientai = iSoPhieuHientai + 1
        sMa = sMa & iSoPhieuHientai.ToString("0000")
        Return sMa
    End Function

    Public Function TestSymbol(ByVal strInputString As String, ByVal strSymbolAllow As String) As Integer
        If strInputString.Trim <> "" Then
            Dim i, j As Integer
            Dim strSymbol As String = "';%*&) (@!#$^|~`:""?-+\.="
            If strSymbolAllow <> "" Then
                For i = 0 To strSymbol.Length - 1
                    For j = 0 To strSymbolAllow.Length - 1
                        If InStr(strSymbol, strSymbolAllow(j)) <> 0 Then
                            strSymbol = Left(strSymbol, InStr(strSymbol, strSymbolAllow(j)) - 1) & Right(strSymbol, (strSymbol.Length - InStr(strSymbol, strSymbolAllow(j)) - 1))
                        End If
                    Next
                Next
            End If
            For i = 0 To strSymbol.Length - 1
                If InStr(strInputString.ToString, strSymbol(i)) <> 0 Then
                    Return 1
                End If
            Next
        Else
            Return 0
        End If
    End Function

    Public Shared Function CheckUser(ByVal page As Page, ByVal dt As DataTable)
        For Each rw As DataRow In dt.Rows
            For Each masterControl As Control In page.Controls
                If TypeOf masterControl Is MasterPage Then
                    For Each formControl As Control In masterControl.Controls
                        If TypeOf formControl Is System.Web.UI.HtmlControls.HtmlForm Then
                            For Each contentControl As Control In formControl.Controls
                                If TypeOf contentControl Is ContentPlaceHolder Then
                                    For Each tableControl As Control In contentControl.Controls
                                        If TypeOf tableControl Is Table Then
                                            For Each btnTemp As Control In tableControl.Controls
                                                If TypeOf btnTemp.FindControl(rw("nv_Tenbien")) Is Button Then
                                                    Dim newButton As Button = btnTemp.FindControl(rw("nv_Tenbien"))
                                                    newButton.Enabled = rw("b_Enable")
                                                End If
                                                If TypeOf btnTemp.FindControl(rw("nv_Tenbien")) Is GridView Then
                                                    Dim newGridView As GridView = btnTemp.FindControl(rw("nv_Tenbien"))
                                                    newGridView.Enabled = rw("b_Enable")
                                                End If

                                            Next
                                        Else
                                            If TypeOf tableControl.FindControl(rw("nv_Tenbien")) Is Button Then
                                                Dim newButton As Button = tableControl.FindControl(rw("nv_Tenbien"))
                                                newButton.Enabled = rw("b_Enable")
                                            End If
                                            If TypeOf tableControl.FindControl(rw("nv_Tenbien")) Is GridView Then
                                                Dim newGridView As GridView = tableControl.FindControl(rw("nv_Tenbien"))
                                                newGridView.Enabled = rw("b_Enable")
                                            End If
                                        End If

                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next

            'Response.Write("<%" & rw("nv_Tenbien") & ".Enabled =" & rw("b_Enable") & "%>")
        Next
        Return True
    End Function

    Public Function GetTuoiByNamSinh(namsinh As Integer) As Integer
        Dim namhientai As Integer
        namhientai = Date.Now.Year
        Return namhientai - namsinh
    End Function
    Public Shared Function ToStrings(number As Decimal) As String
        Dim s As String = number.ToString("#")
        Dim so As String() = New String() {"không", "một", "hai", "ba", "bốn", "năm", _
            "sáu", "bảy", "tám", "chín"}
        Dim hang As String() = New String() {"", "nghìn ", "triệu ", "tỷ "}
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
        Dim hang As String() = New String() {"", "nghìn ", "triệu", "tỷ "}
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
        Return UplowerFirstString(str & Convert.ToString("đồng chẵn"))
    End Function
    Function ConvertString(chuthuong As String) As String
        Dim chuhoa As String
        chuhoa = StrConv(chuthuong, 3)
        Return chuhoa
    End Function
    Public Shared Function ToCapFist(value As String) As String
        If String.IsNullOrEmpty(value) Then
            Return String.Empty
        End If
        If value.Length = 1 Then
            Return value.ToUpper
        End If
        Return String.Concat(Char.ToUpper(value(0)), value.Substring(1).ToLower())
    End Function
    Public Shared Function UplowerFirstString(s As String) As String
        Dim arrValue() As String
        Dim sfirst As String
        arrValue = s.Split(" ")
        If arrValue.Length > 1 Then
            sfirst = arrValue(0)
            sfirst = ToCapFist(sfirst)
            Return sfirst + s.Substring(sfirst.Length, s.Length - sfirst.Length)
        Else
            Return ToCapFist(s)
        End If
    End Function
End Class


