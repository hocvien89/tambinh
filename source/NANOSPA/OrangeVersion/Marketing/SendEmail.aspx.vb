Imports DevExpress.Web.ASPxGridView

Public Class SendEmail
    Inherits System.Web.UI.Page

    Private objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Private objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Private objFCBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
    Dim send As New BO.SendEmail
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDSKhachhang("01/01/2012", DateTime.Now)
    End Sub
#Region "Function"
    Private Sub LoadDSKhachhang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime)
        objFCBaocaoKhachhang = New BO.clsB_BaoCao_Khachhang
        Dim dt As DataTable
        dt = objFCBaocaoKhachhang.SelectThongkeKH_ByTime("01/01/2012", DateTime.Now, Session("uId_Cuahang").ToString)
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
        End If
        dgvDevexpress.DataBind()
        objFCBaocaoKhachhang = Nothing
    End Sub
    Private Function getRowEnabledStatus(ByVal VisibleIndex As Integer) As Boolean
        Dim CategoryID As Integer = Convert.ToInt32(dgvDevexpress.GetRowValues(VisibleIndex, "uId_Khachhang"))

        If (CategoryID <> 2) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub cbAll_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim indexesUnselected As New List(Of Integer)()
        Dim indexesSelected As New List(Of Integer)()

        For i As Integer = 0 To dgvDevexpress.VisibleRowCount - 1
            indexesSelected.Add(i)
        Next i
        Session("WebManagement_IndexesUnselected") = indexesUnselected
        Session("WebManagement_IndexesSelected") = indexesSelected
    End Sub
    Protected Sub grid_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        dgvDevexpress.JSProperties("cpPageSize") = dgvDevexpress.SettingsPager.PageSize
    End Sub
    Protected Sub grid_CustomJSProperties(ByVal sender As Object, ByVal e As ASPxGridViewClientJSPropertiesEventArgs)
        Dim indexesUnselected As List(Of Integer) = TryCast(Session("WebManagement_IndexesUnselected"), List(Of Integer))
        Dim indexesSelected As List(Of Integer) = TryCast(Session("WebManagement_IndexesSelected"), List(Of Integer))
        e.Properties("cpIndexesUnselected") = indexesUnselected
        e.Properties("cpIndexesSelected") = indexesSelected
    End Sub
#End Region

    Protected Sub btnOk_Click(sender As Object, e As EventArgs)
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim v_Email_Sender As String = objFCThamsohethong.SelectTHAMSOHETHONGByID("v_Email_Sender").v_Giatri
        Dim v_Email_Pass As String = objFCThamsohethong.SelectTHAMSOHETHONGByID("v_Email_Pass").v_Giatri
        objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "edf44f30-d081-47d0-bc1d-32f4c8382579")
        If Not objEnPhanQuyen.b_Enable Then
            lblFail.Text = "<span style='color:red'>Bạn không có quyền gửi tin nhắn!</span>"
            objEnPhanQuyen = Nothing
            objFCPhanQuyen = Nothing
            Exit Sub
        End If
        Dim oLib As New Lib_SAT.cls_Pub_Functions
        Dim sTel As String = ""
        Dim sContent As String = ""
        Dim Arr_Tel() As String = txtSDT.Text.Split(",")
        Try
            For i As Int16 = 0 To Arr_Tel.Length - 1
                sTel = oLib.NullProString(Arr_Tel(i))
                If sTel <> "" Then
                    sContent = sContent & sTel & ","
                End If
            Next
            sendMail(v_Email_Sender, v_Email_Pass, txtChude.Text, v_Email_Sender, sContent, htmleditor_noidung.Html())
            lblFail.Text = "<span style='color:green'>Gửi thành công!</span>"
        Catch ex As Exception
            lblFail.Text = "<span style='color:green'>Có vài lỗi xảy ra!</span>"
        End Try
    End Sub

    Protected Sub btnGet_Click(sender As Object, e As EventArgs)
        Dim fieldValues As List(Of Object) = dgvDevexpress.GetSelectedFieldValues(New String() {"v_Email", "nv_Diachi_vn"})
        Dim str As String = ""
        For Each item As Object() In fieldValues
            str += item(0).ToString() + ","
        Next item
        txtSDT.Text = str
    End Sub
    Public Function sendMail(sender As String, passsender As String, subject As String, ByVal email As String, cc As String, ByVal body As String) As Boolean
        Dim domain As String
        domain = Request.Url.Host
        Dim emailFrom As String = sender
        Dim StrDefaultUrl As String = domain
        Dim StrSubject As String = subject
        Dim StrHost As String = "smtp.gmail.com"
        Dim passemailFrom As String = passsender
        Dim Iport As Integer = 587
        Try
            emailFrom = sender
            send.StrFromEmail = emailFrom
            send.StrToEmail = email
            send.StrCCEmail = cc
            StrDefaultUrl = "StrDefaultUrl"
            send.StrDefaultUrl = StrDefaultUrl
            Dim displayname As String = "[" + domain + "]"
            send.StrDisplayName = displayname
            StrSubject = StrSubject
            send.StrSubject = StrSubject
            send.BIsBodyHtml = True
            If body = "" Then
                send.HtmlBody = ""
            Else
                send.HtmlBody = body
            End If
            send.StrHost = StrHost
            send.StrCreEmail = emailFrom
            send.StrCrePass = passemailFrom
            Iport = Iport
            send.Iport = Iport
            send.BEndableSLL = True
            If send.SentEmail() Then
                Return True
            End If
        Catch
        End Try
        Return False
    End Function

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        txtSDT.Text = ""
        txtChude.Text = ""
        htmleditor_noidung.Html = ""
    End Sub
End Class