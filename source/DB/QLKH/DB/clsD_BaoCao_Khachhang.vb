Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class clsD_BaoCao_Khachhang
    Implements iclsD_BaoCao_Khachhang
    Private log As New LogError.ShowError

    Public Function SelectGoiDV_KhachhangNo() As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectGoiDV_KhachhangNo
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_Goidichvu_KhachHangNo]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectTheDV_KhachhangNo() As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectTheDV_KhachhangNo
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_The_KhachHangNo]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectThongkeKH_Gioitinh(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal b_Gioitinh As Byte, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_Gioitinh
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_ThongkeKH_Gioitinh]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Byte, b_Gioitinh)
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

    Public Function SelectThongkeKH_Dotuoi(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_Dotuoi
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_ThongkeKH_Dotuoi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuoiTu", DbType.Int32, TuoiTu)
            db.AddInParameter(objCmd, "@TuoiDen", DbType.Int32, TuoiDen)
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

    Public Function SelectThongkeKH_Nguon(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Nguonden As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_Nguon
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_ThongkeKH_Nguon]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nguonden", DbType.String, uId_Nguonden)
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

    Public Function SelectThongkeKH_Tatca(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_Tatca
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_ThongkeKH_Tatca]"
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

    'Long them
    Public Function spCRM_DM_TINHTHANH_SelectAll() As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.spCRM_DM_TINHTHANH_SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_TINHTHANH_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function spCRM_DM_QUANHUYEN_SelectAllByID(ByVal uId_Tinhthanh As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.spCRM_DM_QUANHUYEN_SelectAllByID
        Dim db As Database
        Dim sp As String = "spCRM_DM_QUANHUYEN_SelectAllByID"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Tinhthanh", DbType.String, uId_Tinhthanh)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectAll_DS_KH_BoDT(ByVal i_Sothang As Integer, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectAll_DS_KH_BoDT
        Dim db As Database
        Dim sp As String = "[dbo].[spCRM_DM_Khachhang_SelectAll_KH_LauNgay]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_Sothang", DbType.Int32, i_Sothang)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectThongkeKH_ByTime(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_ByTime
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_ThongkeKH_ByTime]"
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

    'Long them
    Public Function spBAOCAO_LuongKH(i_DenTuoi As Integer, i_TuTuoi As Integer, b_Gioitinh As String, uId_Quanhuyen As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.spBAOCAO_LuongKH
        Dim db As Database
        Dim sp As String = "[dbo].[spBAOCAO_LuongKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@i_DenTuoi", DbType.Int16, i_DenTuoi)
            db.AddInParameter(objCmd, "@i_TuTuoi", DbType.Int16, i_TuTuoi)
            db.AddInParameter(objCmd, "@b_GioiTinh", DbType.String, b_Gioitinh)
            db.AddInParameter(objCmd, "@uId_Quanhuyen", DbType.String, uId_Quanhuyen)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


#Region "Thống kê"
    Public Function ThongkeKH_Tatca(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.ThongkeKH_Tatca
        Dim db As Database
        Dim sp As String = "[dbo].[spThongkeKH_Tatca]"
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

    Public Function ThongkeKH_Gioitinh(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal b_Gioitinh As Byte, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.ThongkeKH_Gioitinh
        Dim db As Database
        Dim sp As String = "[dbo].[spThongkeKH_Gioitinh]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@b_Gioitinh", DbType.Byte, b_Gioitinh)
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

    Public Function ThongkeKH_Dotuoi(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.ThongkeKH_Dotuoi
        Dim db As Database
        Dim sp As String = "[dbo].[spThongkeKH_Dotuoi]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuoiTu", DbType.Int32, TuoiTu)
            db.AddInParameter(objCmd, "@TuoiDen", DbType.Int32, TuoiDen)
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

    Public Function ThongkeKH_Nguon(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Nguonden As String, ByVal uId_Cuahang As String) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.ThongkeKH_Nguon
        Dim db As Database
        Dim sp As String = "[dbo].[spThongkeKH_Nguon]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nguonden", DbType.String, uId_Nguonden)
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

#End Region

    Public Function Baocao_taichinh_Dichvu(tungay As Date, denngay As Date, uId_Cuahang As String) As DataTable Implements iclsD_BaoCao_Khachhang.Baocao_taichinh_Dichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spBaocao_Doanhthu_Charmnguyenspa]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@TuNgay", DbType.DateTime, tungay)
            db.AddInParameter(objCmd, "@DenNgay", DbType.DateTime, denngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Function SelectThongkeKH_Dichvu_ByTime(ByVal Thang As DateTime, ByVal Tungay As DateTime) As System.Data.DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_Dichvu_ByTime
        Dim db As Database
        Dim sp As String = "[dbo].[BaoCaoDichvu_Thang]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Ngay_bd", DbType.DateTime, Thang)
            db.AddInParameter(objCmd, "@d_Ngay_tim", DbType.DateTime, Tungay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function SelectThongkeKH_Damua_Sanpham() As DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_Damua_Sanpham
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CSKH_DM_KhachhangdadungDVSelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectThongkeKH_chuamua_Sanpham() As DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKH_chuamua_Sanpham
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Dichvu_SanPham_chuamua]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectThongkeKHByDichvu(ByVal uId_Dichvu As String) As DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKHByDichvu
        Dim db As Database
        Dim sp As String = "[dbo].[sp_SelectKH_ByDichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function SelectThongkeKHAll() As DataTable Implements iclsD_BaoCao_Khachhang.SelectThongkeKHAll
        Dim db As Database
        Dim sp As String = "[dbo].[sp_SelectKHAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function BaocaoHopDong_MevaBe(uId_Khachhang As String, uId_Phieudichvu_Chitiet As String) As DataTable Implements iclsD_BaoCao_Khachhang.BaocaoHopDong_MevaBe
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Baocao_Hopdongchamsocbau]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@uId_Phieuchitiet", DbType.String, uId_Phieudichvu_Chitiet)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function ConnoKH_ByID(Tungay As Date, Denngay As Date, uId_Cuahang As String, uId_Khachhang As String) As DataTable Implements iclsD_BaoCao_Khachhang.ConnoKH_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[spQLCN_SelectCongnoByTime_ByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.String, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.String, Denngay)
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, uId_Cuahang)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Baocaothongkenguon(uId_Nguon As String, Tungay As Date, Denngay As Date) As DataTable Implements iclsD_BaoCao_Khachhang.Baocaothongkenguon
        Dim db As Database
        Dim sp As String = "[dbo].[sp_TongKHByuId_Nguon]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@Tungay", DbType.String, Tungay)
            db.AddInParameter(objCmd, "@Denngay", DbType.String, Denngay)
            db.AddInParameter(objCmd, "@uId_Nguon", DbType.String, uId_Nguon)

            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Baocao_DoanhThu_Tonghop(d_Tungay As Date, d_Denngay As Date) As DataTable Implements iclsD_BaoCao_Khachhang.Baocao_DoanhThu_Tonghop
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Baocaotonghop_Doanhthu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.String, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.String, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function Baocao_Dichvu_Tonghop(d_Tungay As Date, d_Denngay As Date) As DataTable Implements iclsD_BaoCao_Khachhang.Baocao_Dichvu_Tonghop
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Baocaodichvu_By_Time]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@d_Tungay", DbType.String, d_Tungay)
            db.AddInParameter(objCmd, "@d_Denngay", DbType.String, d_Denngay)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
