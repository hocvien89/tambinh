Imports DevExpress.Web.ASPxGridView
Public Class SendSMS
    Inherits System.Web.UI.Page
    Private objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Private objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Private objFCBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
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
        Dim v_SSender As String = objFCThamsohethong.SelectTHAMSOHETHONGByID("v_SSender").v_Giatri
        Dim v_SUser As String = objFCThamsohethong.SelectTHAMSOHETHONGByID("v_SUser").v_Giatri
        Dim v_SPass As String = objFCThamsohethong.SelectTHAMSOHETHONGByID("v_SPass").v_Giatri
        objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "edf44f30-d081-47d0-bc1d-32f4c8382579")
        If Not objEnPhanQuyen.b_Enable Then
            lblFail.Text = "<span style='color:red'>Bạn không có quyền gửi tin nhắn!</span>"
            objEnPhanQuyen = Nothing
            objFCPhanQuyen = Nothing
            Exit Sub
        End If
        Dim oLib As New Lib_SAT.cls_Pub_Functions
        If Len(Trim(txtNoiDung.Text)) > 480 Then
            lblFail.Text = "<span style='color:red'>Nội dung không được vượt quá 480 ký tự!</span>"
            Exit Sub
        End If
        Dim mysms As New wsv_SMS.SMS
        Dim outsucess As String = ""
        Dim outfail As String = ""
        Dim sTel, sContent As String
        Dim Arr_Tel() As String = txtSDT.Text.Split(";")
        For i As Int16 = 0 To Arr_Tel.Length - 1
            sTel = oLib.NullProString(Arr_Tel(i))
            If IsNumeric(sTel) = True And (Len(sTel) = 10 Or Len(sTel) = 11) Then
                If sTel <> "" And (Len(sTel) = 10 Or Len(sTel) = 11) Then
                    Dim status As String
                    status = mysms.SendSMSBrandName("84" + Right(sTel, Len(sTel) - 1), txtNoiDung.Text, v_SSender, v_SUser, v_SPass)
                    If status = "1" Then
                        outsucess += sTel + "</br>"
                    Else
                        outfail += sTel + "</br>"
                    End If
                End If
            End If
        Next
        If outsucess <> "" Then
            lblSuccess.Text = "<span style='color:green'>" & outsucess & "</span>"
            txtSDT.Text = ""
            txtNoiDung.Text = ""
            Session("Dienthoaididong") = Nothing
        Else
            lblSuccess.Text = ""
        End If
        If outfail <> "" Then
            lblFail.Text = "<span style='color:red'>" & outfail & "</span>"
        Else
            lblFail.Text = ""
        End If
    End Sub

    Protected Sub btnGet_Click(sender As Object, e As EventArgs)
        Dim fieldValues As List(Of Object) = dgvDevexpress.GetSelectedFieldValues(New String() {"v_DienthoaiDD", "nv_Diachi_vn"})
        Dim str As String = ""
        For Each item As Object() In fieldValues
            str += item(0).ToString() + ";"
        Next item
        txtSDT.Text = str
    End Sub
End Class