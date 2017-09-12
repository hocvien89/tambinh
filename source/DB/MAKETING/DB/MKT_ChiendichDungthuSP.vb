Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError
Public Class MKT_ChiendichDungthuSP
    Implements IMKT_ChiendichDungthuSP

    Private log As New LogError.ShowError

    Public Function sp_CTKM_ChiendichMarketing_Insert(nv_Tenchiendich_vn As String, d_Ngaybatdau As Date, d_Ngayketthuc As Date, nv_Mota As String) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Insert]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenchiendich_vn", DbType.String, nv_Tenchiendich_vn)
            db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.Date, d_Ngaybatdau)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, d_Ngayketthuc)
            db.AddInParameter(objCmd, "@nv_Mota", DbType.String, nv_Mota)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_update_Main(ByVal uId_ChiendichMarketing As String, ByVal nv_Tenchiendich_vn As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal nv_Mota As String) As Boolean Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_update_Main
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_update_Main]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@nv_Tenchiendich_vn", DbType.String, nv_Tenchiendich_vn)
            db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.Date, d_Ngaybatdau)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, d_Ngayketthuc)
            db.AddInParameter(objCmd, "@nv_Mota", DbType.String, nv_Mota)
            objDs = db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function CTKM_ChiendichMarketing_Delete(ByVal uId_ChiendichMarketing As String) As Boolean Implements IMKT_ChiendichDungthuSP.CTKM_ChiendichMarketing_Delete
        Dim db As Database
        Dim sp As String = "[dbo].[CTKM_ChiendichMarketing_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function sp_CTKM_ChiendichMarketing_Update(ByVal uId_ChiendichMarketing As String) As Boolean Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Dichvu_ALL_ByID(ByVal uId_ChiendichMarketing As String) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Dichvu_ALL_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Dichvu_ALL_ByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_SelectByID(ByVal uId_ChiendichMarketing As String) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(ByVal uId_ChiendichMarketing As String, ByVal s_Trangthai As String) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_CiendichMarketing_Chitiet_Select_ALL
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_CiendichMarketing_Chitiet_Select_ALL]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@s_Trangthai", DbType.String, s_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String, ByVal nv_Phanhoi As String, ByVal d_Ngaydungthu As Date) As Boolean Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@nv_Phanhoi", DbType.String, nv_Phanhoi)
            db.AddInParameter(objCmd, "@d_Ngaydungthu", DbType.Date, d_Ngaydungthu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Dichvu_SelectByID(ByVal uId_ChiendichMarketing As String) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Dichvu_SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Dichvu_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_KH_SelectById(ByVal uId_ChiendichMarketing) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_KH_SelectById
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_KH_SelectById]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_Check_KH_CTKM_DungthuSP(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String) As System.Data.DataTable Implements IMKT_ChiendichDungthuSP.sp_Check_KH_CTKM_DungthuSP
        Dim db As Database
        Dim sp As String = "[dbo].[sp_Check_KH_CTKM_DungthuSP]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function


    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert(ByVal uId_ChiendichMarketing_Chitiet As String, ByVal uId_Dichvu As String) As Boolean Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing_Chitiet", DbType.String, uId_ChiendichMarketing_Chitiet)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            objDs = db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Dichvu_ByID(ByVal uId_ChiendichMarketing As String) As System.Data.DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Dichvu_ByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Dichvu_ByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
    Public Function sp_CTKM_ChiendichMarketing_SelectByTrangthai(ByVal nv_Trangthai As String) As System.Data.DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_SelectByTrangthai
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_SelectByTrangthai]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Trangthai", DbType.String, nv_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu(ByVal nv_Tendichvu_vn As String) As System.Data.DataTable Implements IMKT_ChiendichDungthuSP.spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Nhomdichvu", DbType.String, "")
            db.AddInParameter(objCmd, "@uId_Cuahang", DbType.String, "24E1A59B-F645-4240-9A31-D91A90E58793")
            db.AddInParameter(objCmd, "@nv_Tendichvu_vn", DbType.String, nv_Tendichvu_vn)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function CTKM_ChiendichMarketing_Dichvu_Insert(ByVal uId_ChiendichMarketing As String, ByVal uId_Dichvu As String) As Boolean Implements IMKT_ChiendichDungthuSP.CTKM_ChiendichMarketing_Dichvu_Insert
        Dim db As Database
        Dim sp As String = "[dbo].[CTKM_ChiendichMarketing_Dichvu_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@uId_Dichvu", DbType.String, uId_Dichvu)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Insert(uId_ChiendichMarketing As String, uId_Khachhang As String, d_Ngaytang As Date, d_Ngayketthuc As Date) As DataTable Implements IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Insert


        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Chitiet_Insert]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing", DbType.String, uId_ChiendichMarketing)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@d_Ngaytang", DbType.Date, d_Ngaytang)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, d_Ngayketthuc)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try

    End Function

    Public Function DeleteByID(uId_ChiendichMarketing_Chitiet As String) As Boolean Implements IMKT_ChiendichDungthuSP.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Chitiet_Delete]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing_Chitiet", DbType.String, uId_ChiendichMarketing_Chitiet)
            objDs = db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update(obj As CM.IMKT_Chiendichmarketing_Chitiet_Entity) As Boolean Implements IMKT_ChiendichDungthuSP.Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_ChiendichMarketing_Chitiet_Update]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_ChiendichMarketing_Chitiet", DbType.String, obj.uId_ChiendichMarketing_Chitiet)
            db.AddInParameter(objCmd, "@d_Ngaytang", DbType.String, obj.d_Ngaytang)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.String, obj.d_Ngayketthuc)
            objDs = db.ExecuteDataSet(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function TrangThaiKH(LoaiKH As String) As DataTable Implements IMKT_ChiendichDungthuSP.TrangThaiKH
        Dim db As Database
        Dim sp As String = "[dbo].[spMKT_KH_ChamsocKH_CSKH]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)


            db.AddInParameter(objCmd, "@Loaikh", DbType.String, LoaiKH)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function
End Class
