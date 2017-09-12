Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Public Class Loyalty_Card
    Inherits System.Web.UI.Page
    Private objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Private objFcThetichdiem As BO.clsB_TTV_DM_THETICHDIEM
    Private objEnTheKH As CM.cls_TTV_KH_ThetichdiemEntity
    Private objFcTheKH As BO.clsB_TTV_KH_Thetichdiem
    Private objFcTheLichsu As BO.clsB_TTV_KH_Thetichdiem_Lichsu
    Private objEnTheLichsu As CM.cls_TTV_KH_Thetichdiem_LichsuEntity
    Private objFcLichsu As BO.clsB_TTV_KH_Thetichdiem_Lichsu
    Private objEnPublic As Public_Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'cbo_Loadtheauto()
            loadtime()
        End If
        cbo_loadKH()
        cbo_LoadThetichdiem()
        Grid_Loaddata()
        'LoadStyleTichiem()
    End Sub
#Region "load du lieu"
    Private Sub cbo_loadKH()
        Dim dt As DataTable
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        dt = objFcKhachhang.SelectAllTable(Session("uId_Cuahang"))
        Try
            If dt.Rows.Count > 0 Then
                cbo_Khachhang.DataSource = dt
                cbo_Khachhang.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadtime()
        Date_Ngaykichhoat.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Date_Ngayhethan.Text = Strings.Format(DateAndTime.DateAdd(DateInterval.Year, +1, DateAndTime.Now), "dd/MM/yyyy")
    End Sub
    Private Sub cbo_LoadThetichdiem()
        Dim dt As DataTable
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        dt = objFcThetichdiem.SelectAllTable(Session("uId_Cuahang"))
        Try
            If dt.Rows.Count > 0 Then
                cbo_Loaithetichdiem.DataSource = dt
                cbo_Loaithetichdiem.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cbo_Loadtheauto()
    '    Dim dt As DataTable
    '    objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
    '    dt = objFcThetichdiem.SelectAllTable(Session("uId_Cuahang"))
    '    Try
    '        'Dim item As New ListEditItem
    '        'item.Text = "Tất cả"
    '        'item.Value = "Tatca"
    '        'cbo_Theauto.Items.Add(item)
    '        If dt.Rows.Count > 0 Then
    '            For Each row As DataRow In dt.Rows
    '                Dim items As New ListEditItem
    '                items.Text = row("nv_Tenthetichdiem")
    '                items.Value = row("uId_Thetichdiem")
    '                cbo_Theauto.Items.Add(items)
    '            Next
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub Grid_Loaddata()
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        Dim dt As DataTable
        dt = objFcTheKH.SelectKHthe(Session("uId_Cuahang"))
        Try
            Grid_Thekichhoat.DataSource = dt
            Grid_Thekichhoat.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadStyleTichiem()
        chk_Tichdiem.Checked = False
        txt_Sodiem.Enabled = False
        txt_Noidung.Enabled = False
        'radio_Tichluy.Enabled = False
        'radio_Cong.Enabled = False
        'radio_Tru.Enabled = False
        btn_Update.Enabled = False
    End Sub
#End Region
#Region "button event"
    ' kich hoat the cho khach hang
    Private Sub btn_Active_Click(sender As Object, e As EventArgs) Handles btn_Active.Click
        lbl_Thongbao.Text = ""
        objEnTheKH = New CM.cls_TTV_KH_ThetichdiemEntity
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        objEnPublic = New Public_Class
        Dim uId_Khachhang As String
        Dim uid_Thetichdiem As String
        Dim uid_KHthe As String
        uId_Khachhang = cbo_Khachhang.Value.ToString
        uid_Thetichdiem = cbo_Loaithetichdiem.Value.ToString
        Dim dt As DataTable = objFcThetichdiem.SelectById_Thetichdiem(uid_Thetichdiem)
        Dim i As Integer
        i = CheckKH()

        Try
            With objEnTheKH
                .uId_Khachhang = uId_Khachhang
                .uId_Thetichdiem = uid_Thetichdiem
                .d_Ngaycap = Date_Ngaykichhoat.Value
                .d_Ngayhethan = Date_Ngayhethan.Value
                .f_Tongtichluy = 0
                .b_Isdelete = False 'true = xoa logic
                .b_Trangthai = True ' true = kich hoat, fales= khoa
            End With
            If hiddf_uIdKHThe.Value = "" Then ' them moi khach hang
                If i = 1 Then
                    lbl_Thongbao.Text = "Khách đã có thẻ ưu đãi được kích hoạt"
                ElseIf i = 4 Then
                    lbl_Thongbao.Text = "Khách đã có thẻ ưu đãi tạm khóa"
                Else
                    Dim uId_Kh_The As String
                    If dt.Rows.Count > 0 Then
                        objEnTheKH.f_Diemhientai = Double.Parse(dt.Rows(0).Item("f_Diemkichhoat"))
                        objEnTheKH.f_Tongtichluy = Double.Parse(dt.Rows(0).Item("f_Diemkichhoat"))
                    Else
                        objEnTheKH.f_Tongtichluy = 0
                        objEnTheKH.f_Diemhientai = 0
                    End If
                    If txt_Mathe.Text <> "" Then
                        If checkInsert(txt_Mathe.Text) = 0 Then
                            objEnTheKH.v_Mathekhachhang = txt_Mathe.Text
                        Else
                            lbl_Thongbao.Text = "Trùng mã thẻ "
                            Return
                        End If
                    Else
                        objEnTheKH.v_Mathekhachhang = objEnPublic.ReturnAutoString("TTD")
                    End If
                    uId_Kh_The = objFcTheKH.Insert(objEnTheKH)
                    hiddf_uIdKHThe.Value = uId_Kh_The
                    lbl_Thongbao.Text = "Thêm mới thành công"
                    Grid_Loaddata()
                End If
            Else ' update thong tin khach hang
                uid_KHthe = hiddf_uIdKHThe.Value
                If checkUpdate(txt_Mathe.Text, uid_KHthe) = 0 Then
                    objEnTheKH.uId_KH_The = uid_KHthe
                    objEnTheKH.v_Mathekhachhang = txt_Mathe.Text
                    objEnTheKH.d_Ngaycap = Date_Ngaykichhoat.Value
                    objEnTheKH.d_Ngayhethan = Date_Ngayhethan.Value
                    objEnTheKH.uId_Thetichdiem = cbo_Loaithetichdiem.Value
                    objFcTheKH.Update(objEnTheKH)
                    lbl_Thongbao.Text = "Sửa thành công"
                    Grid_Loaddata()
                Else
                    lbl_Thongbao.Text = "Trùng mã thẻ"
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    'khoa the tam thoi. khi khoa the thì the se ko dc tich diem
    Private Sub btn_lock_Click(sender As Object, e As EventArgs) Handles btn_lock.Click
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        lbl_Thongbao.Text = ""
        Dim uid_kh_the As String
        Dim btnText As String
        Dim b_trangthai As Boolean
        btnText = txt_butonevent.Text
        Try
            If btnText = "Khoathe" Then
                b_trangthai = False
                btn_lock.Text = "Mở thẻ"
                txt_butonevent.Text = "Mothe"
            ElseIf btnText = "Mothe" Then
                b_trangthai = True
                btn_lock.Text = "Khóa thẻ"
                txt_butonevent.Text = "Khoathe"
            End If
            uid_kh_the = hiddf_uIdKHThe.Value
            objFcTheKH.Khoathe(uid_kh_the, b_trangthai)
            Grid_Loaddata()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        objFcTheLichsu = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
        objEnTheLichsu = New CM.cls_TTV_KH_Thetichdiem_LichsuEntity
        lbl_Thongbao.Text = ""
        Dim uidthe As String
        Dim noidung As String
        Dim f_tong As Double
        Dim f_Dhientai As Double
        uidthe = hiddf_uIdKHThe.Value
        Dim dt As DataTable
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        Try
            If uidthe <> "" Then
                If CheckKH() = 4 Then
                    lbl_Thongbao.Text = "Thẻ tạm khóa không tích lũy"
                    Return
                End If
                noidung = txt_Noidung.Text
                dt = objFcTheKH.SelectPointById(uidthe)
                If dt.Rows.Count > 0 Then
                    With objEnTheLichsu
                        .d_Ngaythuchien = Date.Now.ToString
                        .nv_Noidung = noidung
                        .uId_KH_The = uidthe.ToString
                        .uId_Sukien = Nothing
                        .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
                    End With
                    If radio_Cong.Checked = True Then
                        For Each row As DataRow In dt.Rows
                            f_tong = Double.Parse(row("f_Tongtichluy")) + Double.Parse(txt_Sodiem.Text)
                            f_Dhientai = Double.Parse(row("f_Diemhientai")) + Double.Parse(txt_Sodiem.Text)
                            objFcTheKH.UpdatePoint(f_tong, f_Dhientai, uidthe)
                        Next
                        objEnTheLichsu.f_Diem = Double.Parse(txt_Sodiem.Text)
                        objEnTheLichsu.b_Luachon = True
                        objFcTheLichsu.Insert(objEnTheLichsu)
                    ElseIf radio_Tru.Checked = True Then
                        If Double.Parse(txt_Sodiem.Text) <= Double.Parse(dt.Rows(0)("f_Diemhientai")) Then
                            f_Dhientai = Double.Parse(dt.Rows(0)("f_Diemhientai")) - Double.Parse(txt_Sodiem.Text)
                            f_tong = dt.Rows(0)("f_Tongtichluy")
                            objFcTheKH.UpdatePoint(f_tong, f_Dhientai, uidthe)
                        Else
                            Return
                        End If
                        objEnTheLichsu.f_Diem = Double.Parse(txt_Sodiem.Text)
                        objEnTheLichsu.b_Luachon = False
                        objFcTheLichsu.Insert(objEnTheLichsu)
                    ElseIf radio_Tichluy.Checked = True Then
                        If txt_Sodiem.Text <> "" Then
                            Dim f_diem As Double
                            f_tong = Double.Parse(txt_Sodiem.Text)
                            f_Dhientai = Double.Parse(dt.Rows(0)("f_Diemhientai"))
                            objFcTheKH.UpdatePoint(f_tong, f_Dhientai, uidthe)
                            If txt_Noidung.Text = "" Then
                                objEnTheLichsu.nv_Noidung = "Thay đổi điểm tích lũy"
                            Else
                                objEnTheLichsu.nv_Noidung = txt_Noidung.Text
                            End If
                            f_diem = Double.Parse(txt_Sodiem.Text) - Double.Parse(dt.Rows(0)("f_Tongtichluy"))
                            If f_diem <= 0 Then
                                f_diem = Math.Abs(f_diem)
                                objEnTheLichsu.f_Diem = f_diem
                                objEnTheLichsu.b_Luachon = False
                                objFcTheLichsu.Insert(objEnTheLichsu)
                            Else
                                objEnTheLichsu.f_Diem = f_diem
                                objEnTheLichsu.b_Luachon = True
                                objFcTheLichsu.Insert(objEnTheLichsu)
                            End If
                        End If
                    End If

                End If
            End If
        Catch ex As Exception

        End Try

        txt_Sodiem.Text = ""
        txt_Sodiem.Focus()
        Grid_Loaddata()
    End Sub
    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        Dim uidthe As String
        uidthe = hiddf_uIdKHThe.Value
        Try
            objFcTheKH.Huythe(uidthe, 1)
            Grid_Loaddata()
            lbl_Thongbao.Text = "Hủy thẻ thành công"
            hiddf_uIdKHThe.Value = ""
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "support"
    'i=0 duoc them, i>0 da ton tai
    Private Function checkInsert(mathe As String) As Integer
        Dim dt As DataTable
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        Dim i As Integer = 0
        dt = objFcTheKH.CheckMathe()
        Try
            If dt.Rows.Count = 0 Then
                Return i
            Else
                For Each row As DataRow In dt.Rows
                    If mathe = row("v_Mathekhachhang").ToString Then
                        i += 1
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
        Return i
    End Function

    Private Function checkUpdate(mathe As String, uid_thetichdiem As String) As Integer
        Dim dt As DataTable
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        Dim i As Integer = 0
        Dim k As Integer = 0
        dt = objFcTheKH.CheckMathe()
        Try
            For Each row As DataRow In dt.Rows
                If row("uid_KH_The").ToString = uid_thetichdiem Then
                    If row("v_Mathekhachhang").ToString = mathe Then
                        Return i ' duoc up date ma the giu nguyen
                    Else
                        For j As Integer = 0 To dt.Rows.Count - 1 Step 1
                            If dt.Rows(j)("v_Mathekhachhang").ToString <> mathe Then
                                k += 1
                            End If
                        Next
                        If k < dt.Rows.Count Then
                            i += 1
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
        Return i
    End Function

    'kiem tra khach hang da duoc cap the va trang thai the 
    Private Function CheckKH() As Integer
        Dim uId_Khachhang As String
        Dim i As Integer = 0
        uId_Khachhang = txt_uidKHThe_an.Text
        objFcTheKH = New BO.clsB_TTV_KH_Thetichdiem
        Dim dt As DataTable
        dt = objFcTheKH.CheckKH(uId_Khachhang)
        Dim boo As Boolean = True
        Try
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If row("b_Trangthai") = True Then
                        i = 1 'khach hang da co the dang kick hoat update
                    Else
                        i = 4 ' khach hang da co the dang tam khoa
                    End If
                    If row("b_Isdelete") = True Then
                        i = 2 'the khach hang da huy
                    End If
                Next
            Else
                i = 3 'khach hang chua co the
            End If
        Catch ex As Exception

        End Try
        Return i
    End Function
#End Region

    Protected Sub Grid_LichsuThe_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim dt As DataTable
        Dim Grid As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_The As String
        objFcLichsu = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
        Try
            uId_The = Grid.GetMasterRowKeyValue().ToString
            dt = objFcLichsu.SelectAllTable(uId_The)
            Grid.DataSource = dt
        Catch ex As Exception

        End Try
        dt = Nothing
    End Sub
End Class