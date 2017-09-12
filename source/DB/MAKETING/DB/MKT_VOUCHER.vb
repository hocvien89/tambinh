Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports LogError

Public Class MKT_VOUCHER
    Implements IMKT_VOUCHER


    Private log As New LogError.ShowError


    Public Function sp_CTKM_DM_LoaiVOUCHER_Delete(ByVal uId_Loaivoucher As String) As Boolean Implements IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_Delete
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_DM_LoaiVOUCHER_Delete]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaivoucher", DbType.String, uId_Loaivoucher)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function sp_CTKM_DM_LoaiVOUCHER_Update(ByVal uId_Loaivoucher As String, ByVal nv_Tenloaivoucher As String, ByVal nv_mota As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal f_Menhgia As Double, ByVal i_sl As Integer, ByVal uId_GioihanVOUCHER As String) As Boolean Implements IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_DM_LoaiVOUCHER_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenloaivoucher", DbType.String, nv_Tenloaivoucher)
            db.AddInParameter(objCmd, "@nv_Mota", DbType.String, nv_mota)
            db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.Date, d_Ngaybatdau)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, d_Ngayketthuc)
            db.AddInParameter(objCmd, "@uId_Loaivoucher", DbType.String, uId_Loaivoucher)
            db.AddInParameter(objCmd, "@f_Menhgia", DbType.Double, f_Menhgia)
            db.AddInParameter(objCmd, "@i_sl", DbType.Int32, i_sl)
            db.AddInParameter(objCmd, "@uId_GioihanVOUCHER", DbType.String, uId_GioihanVOUCHER)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
    Public Function GioihanVoucher() As System.Data.DataTable Implements IMKT_VOUCHER.GioihanVoucher
        Dim db As Database
        Dim sp As String = "[dbo].[spCTKM_DM_GioihanVOUCHER]"
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

    Public Function sp_CTKM_DM_LoaiVOUCHER_Insert(ByVal nv_Tenloaivoucher As String, nv_Mota As String, d_Ngaybatdau As Date, d_Ngayketthuc As Date, b_Hoatdong As Boolean, f_Menhgia As Double, i_sl As Integer, uId_GioihanVOUCHER As String) As Boolean Implements IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_DM_LoaiVOUCHER_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@nv_Tenloaivoucher", DbType.String, nv_Tenloaivoucher)
            db.AddInParameter(objCmd, "@nv_Mota", DbType.String, nv_Mota)
            db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.Date, d_Ngaybatdau)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, d_Ngayketthuc)
            db.AddInParameter(objCmd, "@b_Hoatdong", DbType.Boolean, True)
            db.AddInParameter(objCmd, "@f_Menhgia", DbType.Double, f_Menhgia)
            db.AddInParameter(objCmd, "@i_sl", DbType.Int32, i_sl)
            db.AddInParameter(objCmd, "@uId_GioihanVOUCHER", DbType.String, uId_GioihanVOUCHER)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_DM_LoaiVOUCHER_SelectAll(ByVal s_Trangthai As String) As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_DM_LoaiVOUCHER_SelectAll]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@s_Trangthai", DbType.String, s_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_VOUCHER_Insert(ByVal uId_LoaiVoucher As String, ByVal v_Mavoucher As String, ByVal uId_Khachhang As String, ByVal d_Ngayphat As Date, ByVal d_Ngayketthuc As Date) As Boolean Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_Insert
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_Insert]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_LoaiVoucher", DbType.String, uId_LoaiVoucher)
            db.AddInParameter(objCmd, "@v_Mavoucher", DbType.String, v_Mavoucher)
            db.AddInParameter(objCmd, "@uId_Khachhang", DbType.String, uId_Khachhang)
            db.AddInParameter(objCmd, "@d_Ngayphat", DbType.Date, d_Ngayphat)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, d_Ngayketthuc)


            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_VOUCHER_Update(ByVal v_Mavoucher As String, ByVal d_ngaythu As Date) As Boolean Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_Update
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_Update]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaVoucher", DbType.String, v_Mavoucher)
            db.AddInParameter(objCmd, "@d_Ngaythu", DbType.Date, Date.Now.Date)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function sp_CTKM_VOUCHER_SelectByMaVoucher(ByVal v_Mavoucher As String, ByVal b_Trangthai As String) As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_SelectByMaVoucher
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_SelectByMaVoucher]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_Mavoucher", DbType.String, v_Mavoucher)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.String, b_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_VOUCHER_SelectAll() As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_SelectAll
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_SelectAll]"
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

    Public Function sp_CTKM_VOUCHER_SELECTALLTABLE() As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_SELECTALLTABLE
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_SELECTALLTABLE]"
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

    Public Function sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai(ByVal b_Trangthai As String) As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.String, b_Trangthai)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthaibyLoaiVoucher(ByVal b_Trangthai As String, ByVal uId_Loaivoucher As String) As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthaibyLoaiVoucher
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthaibyLoaiVoucher]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@b_Trangthai", DbType.String, b_Trangthai)
            db.AddInParameter(objCmd, "@uId_Loaivoucher", DbType.String, uId_Loaivoucher)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function sp_CTKM_DM_LoaiVoucher_SelectByID(ByVal uId_Loaivoucher As String) As System.Data.DataTable Implements IMKT_VOUCHER.sp_CTKM_DM_LoaiVoucher_SelectByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_DM_LoaiVoucher_SelectByID]"
        Dim objCmd As DbCommand
        Dim objDs As DataSet
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Loaivoucher", DbType.String, uId_Loaivoucher)
            objDs = db.ExecuteDataSet(objCmd)
            Return objDs.Tables(0)
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return New DataTable
        End Try
    End Function

    Public Function DeleteByID(uId_voucher As String) As Boolean Implements IMKT_VOUCHER.DeleteByID
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_voucher", DbType.String, uId_voucher)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function

    Public Function Update_Obj(obj As CM.MKT_VOUCHEREntity) As Boolean Implements IMKT_VOUCHER.Update_Obj
        Dim db As Database
        Dim sp As String = "[dbo].[sp_CTKM_VOUCHER_Update_obj]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@v_MaVoucher", DbType.String, obj.v_Maloaivoucher)
            db.AddInParameter(objCmd, "@d_Ngaybatdau", DbType.Date, obj.d_Ngayphat)
            db.AddInParameter(objCmd, "@d_Ngayketthuc", DbType.Date, obj.d_Ngaykethuc)

            db.AddInParameter(objCmd, "@uId_voucher", DbType.String, obj.uId_voucher)
            db.ExecuteNonQuery(objCmd)
            Return True
        Catch ex As Exception
            log.WriteLog(sp, ex.Message)
            Return False
        End Try
    End Function
End Class
