Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class nano_websv_CheckInCheckOut
    Inherits System.Web.Services.WebService
#Region "var"
    Private objFcDMPhong As BO.QLP_DM_PHONGFacade
    Private objFcDMGiuong As BO.QLP_DM_GIUONGFacade
    Dim objEnCheckin As CM.TNTP_CHECKINCHECKOUTEntity
    Dim objFcCheckin As BO.TNTP_CHECKINCHECKOUTFacade
    Dim objEnGiuong As CM.QLP_DM_GIUONGEntity
    Dim objEnPhong As CM.QLP_DM_PHONGEntity
#End Region
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod()> _
    Public Function LoadInfoBed(uId_Giuong As String) As String
        Dim str As String = ""
        Dim dt As DataTable
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        dt = objFcDMGiuong.SelectInfoGiuong(uId_Giuong, Date.Now)
        objEnGiuong = objFcDMGiuong.SelectByID(uId_Giuong)
        objEnPhong = objFcDMPhong.SelectByID(objEnGiuong.uId_Phong)
        str += objEnGiuong.nv_TenGiuong_vn & "$" & objEnPhong.nv_Tenphong_vn
        If dt.Rows.Count > 0 Then
            Dim time As DateTime
            Dim time1 As Double = Convert.ToDouble(dt.Rows(0)("f_Sophutthuchien").ToString)
            Dim time2 As DateTime = Convert.ToDateTime(dt.Rows(0)("dt_checkin"))
            time = DateAdd(DateInterval.Minute, time1, time2)
            Dim sophut As Double
            sophut = DateDiff(DateInterval.Minute, Date.Now, time)
            Dim sogiay As Double = sophut * 60
            Try
                Dim ostr As String = dt.Rows(0)("nv_TenGiuong_vn").ToString '0
                str += "$" & dt.Rows(0)("nv_Tendichvu_vn").ToString &
                "$" & dt.Rows(0)("uId_Khachhang").ToString &
                "$" & dt.Rows(0)("i_Lanthu").ToString &
                "$" & dt.Rows(0)("f_Sophutthuchien").ToString &
               "$" & dt.Rows(0)("tenkhachhang").ToString &
               "$" & dt.Rows(0)("tennhanvien").ToString &
               "$" & dt.Rows(0)("trangthai").ToString &
                "$" & Convert.ToDateTime(dt.Rows(0)("dt_checkin").ToString).TimeOfDay.ToString &
                 "$" & dt.Rows(0)("uId_QT_Dieutri").ToString &
                 "$" & sogiay.ToString
            Catch ex As Exception
                str += "Error"
            End Try

        End If
        Return str
    End Function
    <WebMethod()> _
    Public Function checkOut(uId_Dieutri As String) As String
        Dim str As String = ""
        objFcCheckin = New BO.TNTP_CHECKINCHECKOUTFacade
        objEnCheckin = New CM.TNTP_CHECKINCHECKOUTEntity
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        If uId_Dieutri <> Nothing And uId_Dieutri <> "" Then
            objEnCheckin = objFcCheckin.SelectByIDDieuTri(uId_Dieutri)
            objFcCheckin.Checkout(uId_Dieutri, DateTime.Now, True)
            objFcDMGiuong.UpdateTrangThai(objEnCheckin.uId_Giuong, False)
            str = "Check out Thành công!"
        Else
            str = "Check out lỗi!"
        End If
        objFcCheckin = Nothing
        objFcDMGiuong = Nothing
        objEnCheckin = Nothing
        Return str
    End Function

    'kiem tra qtdieutri da duoc check in chua . da duoc su dung
    <WebMethod()> _
    Public Function TestCheckIn(uId_Dieutri As String) As String
        Dim str As String = "False"
        objEnCheckin = New CM.TNTP_CHECKINCHECKOUTEntity
        objFcCheckin = New BO.TNTP_CHECKINCHECKOUTFacade
        objEnCheckin = objFcCheckin.SelectByIDDieuTri(uId_Dieutri)
        If objEnCheckin.uId_Check <> "" And objEnCheckin.uId_Check <> Nothing Then
            str = "True"
        End If
        Return str
    End Function
End Class