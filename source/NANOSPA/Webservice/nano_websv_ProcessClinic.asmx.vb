Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Dapper
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class nano_websv_ProcessClinic
    Inherits System.Web.Services.WebService
    Private log As New LogError.ShowError
#Region "var"
    Private objFc
#End Region
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod()> _
    Public Function ChuyenPhong(sPara As String) As String
        Dim objFcTrangthai As New BO.PQP_TRANGTHAIKHCHOXULYFacade
        Dim objFcphong As New BO.QLP_DM_PHONGFacade
        Dim sList() As String
        sList = sPara.Split("$")

    End Function
    <WebMethod()> _
    Public Function GetHistory(Info As String) As String
        Dim objFcDieutri As New BO.TNTP_QT_DieutriFacade
        Dim str As String = ""
        Dim dt As DataTable
        dt = objFcDieutri.SelectInfoDieutri(Info, "INFO")
        If dt.Rows.Count = 1 Then
            Try
                str = dt.Rows(0)("nv_Tinhtrangcothe").ToString &
                    "#" & dt.Rows(0)("nv_Sinhhoamau").ToString &
                    "#" & dt.Rows(0)("nv_Bieuhienbenh").ToString &
                    "#" & dt.Rows(0)("nv_PhuongphapDT").ToString &
                    "#" & dt.Rows(0)("nv_Ghichu").ToString
            Catch ex As Exception
                log.WriteLog("Load thong tin dieu tri", ex.Message)
            End Try

        End If
        Return str
    End Function

    <WebMethod()> _
    Public Function GetTrangThaiByPhong(uId_Phong As String) As String
        Try
            Dim connStr As String = ConfigurationManager.ConnectionStrings("NANO_SPA.My.MySettings.sConnect").ConnectionString
            Dim db As IDbConnection = New SqlConnection(connStr)
            Dim dt As New DataTable
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@uId_Phong", uId_Phong.Split("$")(0), DbType.String, ParameterDirection.Input, 1000)
            para.Add("@vType", uId_Phong.Split("$")(1), DbType.String, ParameterDirection.Input, 1000)
            dt.Load(db.ExecuteReader("dbo.PQP_QUANLYPHONG_GetTrangThai", para, CommandType.StoredProcedure))
            db.Close()
            Return dt.Rows(0)(0).ToString.ToLower
        Catch ex As Exception
            log.WriteLog("nano_websv_ProcessClinic-GetTrangThaiByPhong", ex.Message)
            Return ""
        End Try
    End Function

    <WebMethod(True)> _
    Public Function KetThucKhamBenh(uId_Phieudichvu As String) As String
        Try
            Dim connStr As String = ConfigurationManager.ConnectionStrings("NANO_SPA.My.MySettings.sConnect").ConnectionString
            Dim db As IDbConnection = New SqlConnection(connStr)
            Dim dt As New DataTable
            Dim para = New DynamicParameters()
            db.Open()
            para.Add("@uId_Phieudichvu", uId_Phieudichvu, DbType.String, ParameterDirection.Input, 1000)
            para.Add("@vType", "KETTHUC", DbType.String, ParameterDirection.Input, 1000)
            para.Add("@uId_Phongchuyen", Session("uId_Phongban_NV_Current"), DbType.String, ParameterDirection.Input, 1000)
            dt.Load(db.ExecuteReader("dbo.TNTP_PHIEUDICHVU_Ketthuckham", para, CommandType.StoredProcedure))
            db.Close()
            Return dt.Rows(0)(0).ToString.ToLower
        Catch ex As Exception
            log.WriteLog("nano_websv_ProcessClinic-GetTrangThaiByPhong", ex.Message)
            Return ""
        End Try
    End Function
End Class