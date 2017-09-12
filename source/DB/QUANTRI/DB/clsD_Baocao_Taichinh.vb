Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_Baocao_Taichinh
    Implements iclsD_Baocao_Taichinh



    Private log As New LogError.ShowError
    Public Function BC_TongThu_KH(ByVal uId_Cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As DataTable Implements iclsD_Baocao_Taichinh.BC_Tongthu_KH
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_TongThu_KH]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            Return db.ExecuteDataSet(objCmd).Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Thanhtoantructiep(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Thanhtoantructiep
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Thanhtoantructiep]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Banthe(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Banthe
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Banthe]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Thukhac(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Thukhac
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Thukhac]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Chikhac(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Chikhac
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Chikhac]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Bangoidichvu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Bangoidichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Bangoidichvu]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Bansanpham(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Bansanpham
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Xuatsanpham]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Khachhangthanhtoanno(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Khachhangthanhtoanno
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Khachhangthanhtoanno]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Nhapsanpham(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Nhapsanpham
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Nhapsanpham]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Khachhangnolai(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Khachhangnolai
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Khachhangnolai]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function Khachhangnosp(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.Khachhangnosp
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Khachhangnosp]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Doanhthu_Dichvu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Doanhthu_Dichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhthuDichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Theodoi_CongNo(ByVal uId_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Theodoi_CongNo
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_CongNoKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Doanhthu_Dichvu_Ngay_HP(ByVal Ngay As Date, ByVal uId_NhomDV As String, ByVal i As Integer) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Doanhthu_Dichvu_Ngay_HP
        Dim db As Database
        Dim sp As String = Nothing
        If i = 0 Then
            sp = "[dbo].[spBAOCAO_DoanhthuDichvuByNgay_HP]"
        ElseIf i = 1 Then
            sp = "[dbo].[spBAOCAO_DoanhthuDichvuByNgay_NhomDV_HP]"
        End If
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_NhomDV)
            db.AddInParameter(objCmd, "@Ngay", DbType.DateTime, Ngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function Doanhthu_Dichvu_Ngay(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_NhomDV As String, ByVal i As Integer) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Doanhthu_Dichvu_Ngay
        Dim db As Database
        Dim sp As String = Nothing
        If i = 0 Then
            sp = "[dbo].[spBAOCAO_DoanhthuDichvuByNgay]"
        ElseIf i = 1 Then
            sp = "[dbo].[spBAOCAO_DoanhthuDichvuByNgay_NhomDV]"
        End If
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            If i = 0 Then db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, uId_NhomDV)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Doanhthu_Dichvu_KhoangTG_HP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal i As Integer) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Doanhthu_Dichvu_KhoangTG_HP
        Dim db As Database
        Dim sp As String = Nothing
        If i = 0 Then
            sp = "[spBAOCAO_DoanhthuDichvuByThang_NhomDV_HP]"
        End If
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Doanhthu_Dichvu_Nhanvien(ByVal uId_Nhanvien As String, ByVal TuNgay As Date, ByVal DenNgay As Date) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Doanhthu_Dichvu_Nhanvien
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhthuDichvuNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Phantram_HoaHong_Dieutri(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Phantram_HoaHong_Dieutri
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_HoahongQuatrinhDT]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Phantram_HoaHong_BanSP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.Phantram_HoaHong_BanSP
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_HoahongSanpham]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function BaoCao_PDV_SoToTien(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.BaoCao_PDV_SoToTien
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_PHIEUDICHVU_SOTOTIEN]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BAOCAO_DoanhThuTongHop(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_Baocao_Taichinh.BAOCAO_DoanhThuTongHop
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_DoanhThuTongHop]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function ThongKeDoanhThuTheoThoiGian(TuNgay As Date, DenNgay As Date, uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.ThongKeDoanhThuTheoThoiGian
        Dim db As Database
        Dim sp As String = "[dbo].[sp_ThongKeDoanhThuTheoThoiGian]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, TuNgay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, DenNgay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return ""
        End Try
    End Function
    'xuanhieu 01052015 bao cao tong hop kinh doanh
    Public Function TChinhTonghop(Tungay As Date, Denngay As Date, uId_Cuahang As String) As String Implements iclsD_Baocao_Taichinh.TChinhTonghop
        Dim db As Database
        '0: tienthucDv, 1: thettDv , 2: thucteSp, 3: TheTTsp, 4: TheTTnosp , 5: TheTTnoDv, 6: thunoDv, 7: ThunoSp
        '8: ThuctenoDv, 9:ThuctenoSp
        Dim sp() As String = {"[dbo].[spBAOCAO_ThuTienThuc_DV]",
                              "[dbo].[spBAOCAO_ThuQuaTheTT_DV]",
                              "[dbo].[spBAOCAO_ThuTienThuc_SP]",
                              "[dbo].[spBAOCAO_ThuQuaTheTT_SP]",
                              "[dbo].[spBAOCAO_ThanhToanNoSP_ThuQuaThe]",
                              "[dbo].[spBAOCAO_ThanhToanNoDV_ThuQuaThe]",
                              "[dbo].[spBAOCAO_Khachhangthanhtoanno_DV]",
                              "[dbo].[spBAOCAO_Khachhangthanhtoanno_SP]",
                              "[dbo].[spBAOCAO_ThanhToanNoDV_ThuTienThuc]",
                              "[dbo].[spBAOCAO_ThanhToanNoSP_ThuTienThuc]"}
        Dim objCmd As DbCommand
        Dim str As String = ""
        Try
            db = DatabaseFactory.CreateDatabase()
            For i As Integer = 0 To sp.Length - 1 Step 1
                Dim strr As String = sp(i)
                objCmd = db.GetStoredProcCommand(strr)
                db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, Tungay)
                db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, Denngay)
                db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
                If i <= sp.Length - 2 Then
                    str += db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString + "/"
                ElseIf i = sp.Length - 1 Then
                    str += db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
                End If
            Next
            Return str
        Catch ex As Exception
            log.WriteLog(sp(0), ex.Message)
            Return ""
        End Try
    End Function

    Public Function BaocaoTonghop_Luong(Ngay As DateTime, nam As DateTime) As DataTable Implements iclsD_Baocao_Taichinh.BaocaoTonghop_Luong
        Dim db As Database
        Dim sp As String = "[dbo].[spQLL_THONGTINLUONG_SelectAll_tinh]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Thang", DbType.DateTime, Ngay)
            db.AddInParameter(objCmd, "@i_Nam", DbType.DateTime, nam)


            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Baocaotonghop_Tieuhao(Tungay As Date, Denngay As Date) As DataTable Implements iclsD_Baocao_Taichinh.Baocaotonghop_Tieuhao
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Getsotientieuhao]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)


            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BaocaoSL_Mathang(Tungay As Date, Denngay As Date) As DataTable Implements iclsD_Baocao_Taichinh.BaocaoSL_Mathang
        Dim db As Database
        Dim sp As String = "[dbo].[sp_BaocaoSPBan]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)


            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function DoanhthuTV(uId_Nhanvien As String, Tungay As Date, Denngay As Date) As DataTable Implements iclsD_Baocao_Taichinh.DoanhthuTV
        Dim db As Database
        Dim sp As String = "[dbo].[sp_DoanhthuByNhanvien]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.DateTime, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.DateTime, Denngay)
            db.AddInParameter(objCmd, "@uId_Nhanvien", DbType.String, uId_Nhanvien)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
