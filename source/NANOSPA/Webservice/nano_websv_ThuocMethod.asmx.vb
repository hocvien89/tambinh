Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class nano_websv_ThuocMethod
    Inherits System.Web.Services.WebService
#Region "Khai bao"
    Dim objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Dim objEnPhieuxuat As CM.QLMH_PHIEUXUATEntity
    Dim objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim log As New LogError.ShowError
    Dim pc As New Public_Class
#End Region
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod(True)> _
    Public Function InsertPhieuxuat(sPara As String) As String
        Dim sList() As String
        sList = sPara.Split("$")
        Dim str As String = ""
        If Session("uId_Khachhang") <> Nothing Then
            objFCPhanQuyen = New BO.QT_PHANQUYENFacade
            objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
            objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
            objFCNhatKy = New BO.NHATKYSUDUNGFacade
            Dim checkKhoaPhieu As Boolean
            checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).b_IsKhoa
            Dim dt_KP As New DataTable
            dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "3a1703a5-8349-4ea7-8611-0208270b888f")
            Try
                If dt_KP.Rows.Count > 0 Then
                    Dim sUid_Phieuxuat As String = ""
                    objEnPhieuxuat.uId_Khachhang = Session("uId_Khachhang")
                    objEnPhieuxuat.uId_Kho = sList(0)
                    objEnPhieuxuat.uId_Nhanvien = sList(1)
                    objEnPhieuxuat.v_Maphieuxuat = sList(2)
                    objEnPhieuxuat.d_Ngayxuat = BO.Util.ConvertDateTime(sList(3))
                    objEnPhieuxuat.nv_Noidungxuat_vn = sList(4)
                    objEnPhieuxuat.f_Giamgia_Tong = 0
                    objEnPhieuxuat.f_Tongtienthuc = 0
                    objEnPhieuxuat.nv_Noidungxuat_en = Session("uId_Phieudichvu1").ToString
                    objEnPhieuxuat.i_Soluog = Convert.ToInt32(sList(6))
                    objEnPhieuxuat.vTypeGia = "New"
                    'b_IsKhoa = true la phieu chi ke (ko tinh ton kho          
                    If Session("uId_Phieuxuat") = Nothing Then
                        If sList(5) = "false" Then
                            objEnPhieuxuat.b_IsKhoa = False
                        Else
                            objEnPhieuxuat.b_IsKhoa = True
                        End If
                        Dim dt_Test As DataTable
                        dt_Test = objFcPhieuxuat.SelectBySoPhieuXuat(sList(2))
                        If dt_Test.Rows.Count > 0 Then
                            str = "Trùng mã đơn thuốc"
                        Else
                            sUid_Phieuxuat = objFcPhieuxuat.Insert(objEnPhieuxuat)
                            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu xuất mã " & sList(2))
                            str = "Thêm đơn thuốc thành công "
                            HttpContext.Current.Session("uId_Phieuxuat") = sUid_Phieuxuat
                        End If
                    Else
                        objEnPhieuxuat.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                        objFcPhieuxuat.Update(objEnPhieuxuat)
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu xuất mã " & sList(2))
                        str = "Cập nhật đơn thuốc thành công"
                    End If
                Else
                    str = "Không có quyền thực hiện chức năng này!"
                End If
            Catch ex As Exception
                log.WriteLog("Insert phieu xuat", ex.Message)
            End Try
        End If
        Return str
    End Function
    <WebMethod()> _
    Public Function GetDongiathangByDM(sPara As String) As String
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        Dim str As String = ""
        str = objFcPhieuxuat.GetdongiaThangbyDM(sPara)
        Return str
    End Function
    <WebMethod(True)> _
    Public Function SaoChepDonThuocMau(sPara As String) As String
        Dim sList() As String
        Dim str As String
        Dim IdPhieuxuat As String = ""
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        sList = sPara.Split("$")
        Dim objEnPhieuxuat As New CM.QLMH_PHIEUXUATEntity
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat"))
        With objEnPhieuxuat
            .v_Maphieuxuat = pc.ReturnAutoString("PX")
            .uId_Nhanvien = sList(0)
            .nv_Noidungxuat_vn = sList(1)
            .i_Soluog = sList(4)
            .vTypeGia = "Coppy"
            .d_Ngayxuat = BO.Util.ConvertDateTime(sList(3))
        End With
        If sList(3) = "false" Then
            objEnPhieuxuat.b_IsKhoa = False
        Else
            objEnPhieuxuat.b_IsKhoa = True
        End If
        IdPhieuxuat = objFcPhieuxuat.Insert(objEnPhieuxuat)
        If IdPhieuxuat <> "" Then
            Session("uId_Phieuxuat") = IdPhieuxuat
            str = objEnPhieuxuat.v_Maphieuxuat
        Else
            str = "error"
        End If
        Return str
    End Function
End Class