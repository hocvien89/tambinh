Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Dapper

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class nano_websv_Clinic
    Inherits System.Web.Services.WebService
    Dim connStr As String = ConfigurationManager.ConnectionStrings("NANO_SPA.My.MySettings.sConnect").ConnectionString
    Dim db As IDbConnection = New SqlConnection(connStr)
    Dim log As New LogError.ShowError
    Dim pc As New Public_Class
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod()> _
    Public Function MenuActive(sPara As String) As String
        Dim sList As String()
        sList = sPara.Split("$")
        Dim dt As New DataTable
        Try
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@IDPhong", sList(0), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@IDMenu", sList(1), DbType.Int32, ParameterDirection.Input, 1000)
            para.Add("@vType", sList(2), DbType.String, ParameterDirection.Input, 1000)
            dt.Load(db.ExecuteReader("dbo.MenuActive", para, CommandType.StoredProcedure))
            db.Close()
            Return dt.Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog("nano_websv_Clinic-MenuActive", ex.Message)
            Return ""
        End Try
    End Function

    <WebMethod(True)> _
    Public Function InsertPhieutiepdon(sPara As String) As String
        Dim slist As String()
        slist = sPara.Split("$")
        Dim dt As New DataTable
        Try
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@uId_Khachhang", Session("uId_Khachhang"), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@dNgay", DateTime.Now, DbType.DateTime, ParameterDirection.Input, 1000)
            para.Add("@nv_Nguon", slist(0), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@uId_Bacsikham", slist(2), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@uId_Bacsigioithieu", slist(1), DbType.String, ParameterDirection.Input, 1000)
            dt.Load(db.ExecuteReader("dbo.CMR_KHACHHANG_PHIEUTIEPDON_Insert", para, CommandType.StoredProcedure))
            db.Close()
            Return dt.Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog("nano_websv_Clinic-InsertPhieutiepdon", ex.Message)
            Return ""
        End Try
    End Function
    <WebMethod()> _
    Public Function InsertCallphone(sPara As String) As String
        Dim sList As String()
        sList = sPara.Split("$")
        Dim dt As New DataTable
        Try
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@uId_Khachhang", sList(0), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@uId_Nhanvien", sList(1), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@d_Ngay", DateTime.Now, DbType.DateTime, ParameterDirection.Input, 1000)
            para.Add("@nv_Noidung", sList(2), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@nv_Link", sList(3), DbType.String, ParameterDirection.Input, 1000)
            If sList(4) = "In" Then
                dt.Load(db.ExecuteReader("dbo.spQT_QUANLYCUOCGOI_Insert", para, CommandType.StoredProcedure))
                db.Close()
                Return dt.Rows(0)(0).ToString
            Else
                para.Add("@uId_Cuocgoi", sList(5), DbType.String, ParameterDirection.Input, 1000)
                db.Execute("dbo.spQT_QUANLYCUOCGOI_Update", para, CommandType.StoredProcedure)
                db.Close()
                Return "Sửa dữ liệu thành công!"
            End If
        Catch ex As Exception
            log.WriteLog("nano_websv_Clinic-InsertCallphone", ex.Message)
            Return ""
        End Try
    End Function

    <WebMethod()> _
    Public Function SelectCuocGoiByID(sPara As String) As String
        Dim dt As New DataTable
        Dim rs As String = ""
        Try
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@uId_Callphone", sPara, DbType.String, ParameterDirection.Input, 1000)

            dt.Load(db.ExecuteReader("dbo.spQT_QUANLYCUOCGOI_SelectCuocGoiByID", para, CommandType.StoredProcedure))
            db.Close()
            rs = dt.Rows(0)("d_Ngay").ToString & "$" & dt.Rows(0)("uId_Khachhang").ToString & "$" & dt.Rows(0)("uId_Nhanvien").ToString &
                "$" & dt.Rows(0)("nv_Noidung").ToString & "$" & dt.Rows(0)("nv_Link").ToString
            Return rs
        Catch ex As Exception
            log.WriteLog("nano_websv_Clinic-InsertCallphone", ex.Message)
            Return ""
        End Try
    End Function

    <WebMethod()> _
    Public Function HuyAudio(sPara As String) As String
        Dim rs As String = ""
        Dim dt As New DataTable
        Try
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@uId_Callphone", sPara, DbType.String, ParameterDirection.Input, 1000)
            dt.Load(db.ExecuteReader("dbo.spQT_QUANLYCUOCGOI_HuyAudio", para, CommandType.StoredProcedure))
            Return dt.Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog("nano_websv_Clinic-HuyAudio", ex.Message)
            Return ""
        End Try
    End Function

    <WebMethod()> _
    Public Function CallDeleteByDate(Tungay As String, Denngay As String)
        Dim rs As String = ""
        Dim dt As New DataTable
        Try
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@Tungay", pc.ConvertDateToString(Tungay), DbType.Date, ParameterDirection.Input, 1000)
            para.Add("@Denngay", pc.ConvertDateToString(Denngay), DbType.Date, ParameterDirection.Input, 1000)
            dt.Load(db.ExecuteReader("dbo.spQT_QUANLYCUOCGOI_DeleteByDate", para, CommandType.StoredProcedure))
            Return dt.Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog("nano_websv_Clinic-HuyAudio", ex.Message)
            Return ""
        End Try
    End Function
End Class